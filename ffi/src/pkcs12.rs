use crate::error::ffi::PickyError;

#[diplomat::bridge]
pub mod ffi {
    use crate::error::ffi::PickyError;
    use crate::key::ffi::PrivateKey;
    use crate::x509::ffi::Cert;
    use diplomat_runtime::DiplomatWriteable;
    use picky::pkcs12;
    use picky_asn1::restricted_string::BMPString;
    use std::str::FromStr;
    use std::sync::{Arc, Mutex};

    #[diplomat::opaque]
    pub struct Pkcs12ParsingParams(pub(crate) pkcs12::Pkcs12ParsingParams);

    impl Pkcs12ParsingParams {
        pub fn new() -> Box<Pkcs12ParsingParams> {
            Box::new(Self(pkcs12::Pkcs12ParsingParams::default()))
        }

        /// Continue parsing if conversion to high level picky data structure fails (e.g. due to
        /// unsupported private key or certificate kind)
        pub fn set_skip_soft_parsing_errors(&mut self, value: bool) {
            self.0.skip_soft_parsing_errors = value;
        }

        /// Continue parsing if decryption fails and keep data in encrypted form
        pub fn set_skip_decryption_errors(&mut self, value: bool) {
            self.0.skip_decryption_errors = value;
        }

        /// Continue parsing if MAC validation fails.
        ///
        /// This is useful for parsing available unencrypted data from
        /// password-protected PFX files. Also could be useful if PFX integrity has been intentionally
        /// violated for testing purposes.
        pub fn set_skip_mac_validation(&mut self, value: bool) {
            self.0.skip_mac_validation = value;
        }
    }

    /// Crypto context to use when building a PFX.
    #[diplomat::opaque]
    pub struct Pkcs12CryptoContext(pub(crate) Arc<Mutex<pkcs12::Pkcs12CryptoContext>>);

    impl Pkcs12CryptoContext {
        pub fn with_password(password: &str) -> Box<Pkcs12CryptoContext> {
            Box::new(Self(Arc::new(Mutex::new(
                pkcs12::Pkcs12CryptoContext::new_with_password(password),
            ))))
        }

        pub fn no_password() -> Box<Pkcs12CryptoContext> {
            Box::new(Self(Arc::new(Mutex::new(
                pkcs12::Pkcs12CryptoContext::new_without_password(),
            ))))
        }
    }

    pub enum Pkcs12AttributeKind {
        FriendlyName,
        LocalKeyId,
        Custom,
    }

    /// Attributes which can be used to store additional information about safe (e.g. friendly name, key ID).
    #[diplomat::opaque]
    pub struct Pkcs12Attribute(pub(crate) pkcs12::Pkcs12Attribute);

    impl Pkcs12Attribute {
        /// Creates a new `friendly name` attribute. This attribute is used to store a human-readable
        /// name of the safe bag contents (e.g. certificate name).
        pub fn new_friendly_name(name: &str) -> Result<Box<Pkcs12Attribute>, Box<PickyError>> {
            let value = BMPString::from_str(name)?;
            Ok(Box::new(Self(pkcs12::Pkcs12Attribute::new_friendly_name(value))))
        }

        /// Creates a new `local key id` attribute. This attribute is used to indicate relation between
        /// private key and certificate (when set to same value on both objects).
        pub fn new_local_key_id(value: &[u8]) -> Box<Pkcs12Attribute> {
            Box::new(Self(pkcs12::Pkcs12Attribute::new_local_key_id(value.to_vec())))
        }

        pub fn get_kind(&self) -> Pkcs12AttributeKind {
            match self.0.kind() {
                pkcs12::Pkcs12AttributeKind::FriendlyName(..) => Pkcs12AttributeKind::FriendlyName,
                pkcs12::Pkcs12AttributeKind::LocalKeyId(..) => Pkcs12AttributeKind::LocalKeyId,
                pkcs12::Pkcs12AttributeKind::Custom(..) => Pkcs12AttributeKind::Custom,
            }
        }

        pub fn get_friendly_name(&self, writeable: &mut DiplomatWriteable) -> Result<(), Box<PickyError>> {
            use std::fmt::Write as _;

            if let pkcs12::Pkcs12AttributeKind::FriendlyName(name) = self.0.kind() {
                let name = name.to_utf8();
                writeable.write_str(&name)?;
            }

            writeable.flush();

            Ok(())
        }
    }

    #[diplomat::opaque]
    pub struct Pkcs12AttributeIterator(pub(crate) Box<dyn Iterator<Item = pkcs12::Pkcs12Attribute>>);

    impl Pkcs12AttributeIterator {
        #[allow(clippy::should_implement_trait)] // no traits for FFI
        pub fn next(&mut self) -> Option<Box<Pkcs12Attribute>> {
            self.0.next().map(|attr| Box::new(Pkcs12Attribute(attr)))
        }
    }

    pub enum SafeBagKind {
        PrivateKey,
        Certificate,
        Secret,
        Unknown,
    }

    /// PFX safe bag, the polymorphic container for all the data in a PKCS12 archive.
    #[diplomat::opaque]
    pub struct SafeBag(pub(crate) pkcs12::SafeBag);

    impl SafeBag {
        /// Creates new safe bag holding a private key.
        pub fn new_key(key: &PrivateKey) -> Result<Box<SafeBag>, Box<PickyError>> {
            let safe_bag = pkcs12::SafeBag::new_key(key.0.clone(), Vec::new())?;
            Ok(Box::new(Self(safe_bag)))
        }

        /// Creates new safe bag holding an encrypted private key.
        pub fn new_encrypted_key(
            key: &PrivateKey,
            crypto_context: &Pkcs12CryptoContext,
        ) -> Result<Box<SafeBag>, Box<PickyError>> {
            let mut crypto_context = crypto_context.0.lock().unwrap();

            let pbes2_encryption =
                pkcs12::Pbes2Encryption::new(pkcs12::Pbes2Cipher::Aes256Cbc, pkcs12::Pkcs12HashAlgorithm::Sha256);
            let encryption = pkcs12::Pkcs12Encryption::new_pbes2(pbes2_encryption, &mut crypto_context);

            let safe_bag = pkcs12::SafeBag::new_encrypted_key(key.0.clone(), Vec::new(), encryption, &crypto_context)?;

            Ok(Box::new(Self(safe_bag)))
        }

        /// Creates new safe bag holding a certificate.
        pub fn new_certificate(cert: &Cert) -> Result<Box<SafeBag>, Box<PickyError>> {
            let safe_bag = pkcs12::SafeBag::new_certificate(cert.0.clone(), Vec::new())?;
            Ok(Box::new(Self(safe_bag)))
        }

        /// Adds a PKCS12 attribute to this safe bag.
        pub fn add_attribute(&mut self, attribute: &Pkcs12Attribute) {
            self.0.add_attribute(attribute.0.clone());
        }

        pub fn get_kind(&self) -> SafeBagKind {
            match self.0.kind() {
                pkcs12::SafeBagKind::PrivateKey(..) => SafeBagKind::PrivateKey,
                pkcs12::SafeBagKind::EncryptedPrivateKey { .. } => SafeBagKind::PrivateKey,
                pkcs12::SafeBagKind::Certificate(..) => SafeBagKind::Certificate,
                pkcs12::SafeBagKind::Secret(..) => SafeBagKind::Secret,
                pkcs12::SafeBagKind::Unknown => SafeBagKind::Unknown,
                // NOTE: SafeBagIterator should handle this case so that library user doesn’t have to
                // know about nested safe bags.
                pkcs12::SafeBagKind::Nested(..) => SafeBagKind::Unknown,
            }
        }

        pub fn get_private_key(&self) -> Option<Box<PrivateKey>> {
            if let pkcs12::SafeBagKind::PrivateKey(key) | pkcs12::SafeBagKind::EncryptedPrivateKey { key, .. } =
                self.0.kind()
            {
                Some(Box::new(PrivateKey(key.clone())))
            } else {
                None
            }
        }

        pub fn get_certificate(&self) -> Option<Box<Cert>> {
            if let pkcs12::SafeBagKind::Certificate(cert) = self.0.kind() {
                Some(Box::new(Cert(cert.clone())))
            } else {
                None
            }
        }

        pub fn contains_friendly_name(&self, value: &str) -> bool {
            self.0
                .attributes()
                .iter()
                .filter_map(|attr| {
                    if let pkcs12::Pkcs12AttributeKind::FriendlyName(name) = attr.kind() {
                        Some(name)
                    } else {
                        None
                    }
                })
                .any(|name| name.to_utf8() == value)
        }

        pub fn contains_local_key_id(&self, value: &[u8]) -> bool {
            self.0
                .attributes()
                .iter()
                .filter_map(|attr| {
                    if let pkcs12::Pkcs12AttributeKind::LocalKeyId(id) = attr.kind() {
                        Some(id.as_slice())
                    } else {
                        None
                    }
                })
                .any(|id| id == value)
        }

        #[allow(clippy::unnecessary_to_owned)] // rare ocurrence of false-positive for this clippy lint
        pub fn attributes(&self) -> Box<Pkcs12AttributeIterator> {
            let it = self.0.attributes().to_vec().into_iter();

            Box::new(Pkcs12AttributeIterator(Box::new(it)))
        }
    }

    #[diplomat::opaque]
    pub struct SafeBagIterator(pub(crate) Box<dyn Iterator<Item = pkcs12::SafeBag>>);

    impl SafeBagIterator {
        #[allow(clippy::should_implement_trait)] // no traits for FFI
        pub fn next(&mut self) -> Option<Box<SafeBag>> {
            self.0.next().map(|safe_bag| Box::new(SafeBag(safe_bag)))
        }
    }

    /// PFX (PKCS12 archive) builder.
    #[diplomat::opaque]
    pub struct PfxBuilder {
        safe_bags_acc: Vec<pkcs12::SafeBag>,
        safe_contents: Vec<pkcs12::SafeContents>,
        crypto_context: Arc<Mutex<pkcs12::Pkcs12CryptoContext>>,
    }

    impl PfxBuilder {
        pub fn init(crypto_context: &Pkcs12CryptoContext) -> Box<PfxBuilder> {
            Box::new(Self {
                safe_bags_acc: Vec::new(),
                safe_contents: Vec::new(),
                crypto_context: crypto_context.0.clone(),
            })
        }

        pub fn add_safe_bag_to_current_safe_contents(&mut self, safe_bag: &SafeBag) {
            self.safe_bags_acc.push(safe_bag.0.clone());
        }

        pub fn mark_safe_contents_as_ready(&mut self) {
            let safe_bags = std::mem::take(&mut self.safe_bags_acc);
            let safe_contents = pkcs12::SafeContents::new(safe_bags);
            self.safe_contents.push(safe_contents);
        }

        pub fn mark_encrypted_safe_contents_as_ready(&mut self) -> Result<(), Box<PickyError>> {
            let mut crypto_context = self.crypto_context.lock().unwrap();

            let safe_bags = std::mem::take(&mut self.safe_bags_acc);

            let pbes2_encryption =
                pkcs12::Pbes2Encryption::new(pkcs12::Pbes2Cipher::Aes256Cbc, pkcs12::Pkcs12HashAlgorithm::Sha256);
            let encryption = pkcs12::Pkcs12Encryption::new_pbes2(pbes2_encryption, &mut crypto_context);

            let safe_contents = pkcs12::SafeContents::new_encrypted(safe_bags, encryption, &crypto_context)?;

            self.safe_contents.push(safe_contents);

            Ok(())
        }

        pub fn build(&mut self) -> Result<Box<Pfx>, Box<PickyError>> {
            let mut crypto_context = self.crypto_context.lock().unwrap();

            let safe_bags = std::mem::take(&mut self.safe_bags_acc);
            let mut safe_contents = std::mem::take(&mut self.safe_contents);

            if !safe_bags.is_empty() {
                safe_contents.push(pkcs12::SafeContents::new(safe_bags));
            }

            let mac = pkcs12::Pkcs12MacAlgorithmHmac::new(pkcs12::Pkcs12HashAlgorithm::Sha256);

            let pfx = pkcs12::Pfx::new_with_hmac(safe_contents, mac, &mut crypto_context)?;

            Ok(Box::new(Pfx(pfx)))
        }
    }

    /// A PKCS12 archive.
    #[diplomat::opaque]
    pub struct Pfx(pub(crate) pkcs12::Pfx);

    impl Pfx {
        pub fn builder(crypto_context: &Pkcs12CryptoContext) -> Box<PfxBuilder> {
            PfxBuilder::init(crypto_context)
        }

        /// Parses a PKCS12 archive (PFX) from its DER representation.
        pub fn from_der(
            der: &[u8],
            crypto_context: &Pkcs12CryptoContext,
            parsing_params: &Pkcs12ParsingParams,
        ) -> Result<Box<Pfx>, Box<PickyError>> {
            let crypto_context = crypto_context.0.lock().unwrap();
            let pfx = pkcs12::Pfx::from_der(der, &crypto_context, &parsing_params.0)?;
            Ok(Box::new(Self(pfx)))
        }

        /// Saves this PKCS12 archive to the filesystem.
        pub fn save_to_file(&self, path: &str) -> Result<(), Box<PickyError>> {
            use std::io::Write as _;

            let der = self.0.to_der()?;

            let mut file = std::fs::File::create(path).map(std::io::BufWriter::new)?;
            file.write_all(&der)?;

            Ok(())
        }

        /// Returns a `SafeBagIterator` to inspect PFX data
        #[allow(clippy::unnecessary_to_owned)] // rare ocurrence of false-positive for this clippy lint
        pub fn safe_bags(&self) -> Box<SafeBagIterator> {
            let it = self
                .0
                .safe_contents()
                .to_vec() // <- this `to_vec` is required in order to get an owned iterator ('static lifetime) that we can box
                .into_iter()
                .flat_map(|safe_contents| match safe_contents.into_kind() {
                    pkcs12::SafeContentsKind::SafeBags(safe_bags) => safe_bags.into_iter(),
                    pkcs12::SafeContentsKind::EncryptedSafeBags { safe_bags, .. } => safe_bags.into_iter(),
                    pkcs12::SafeContentsKind::Unknown => Vec::new().into_iter(),
                })
                .flat_map(|safe_bag| {
                    if matches!(safe_bag.kind(), pkcs12::SafeBagKind::Nested(_)) {
                        let pkcs12::SafeBagKind::Nested(safe_bags) = safe_bag.into_kind() else {
                            unreachable!();
                        };
                        safe_bags.into_iter()
                    } else {
                        vec![safe_bag].into_iter()
                    }
                });

            Box::new(SafeBagIterator(Box::new(it)))
        }
    }
}

/// Returns the required space in bytes to write the DER representation of this PKCS12 archive.
///
/// When an error occurs, 0 is returned.
///
/// # Safety
///
/// - `pfx` must be a pointer to a valid memory location containing a `Pfx` object.
#[no_mangle]
pub unsafe extern "C" fn Pfx_der_encoded_len(pfx: Option<&ffi::Pfx>) -> usize {
    if let Some(data) = pfx.and_then(|pfx| pfx.0.to_der().ok()) {
        data.len()
    } else {
        0
    }
}

/// Serializes the PKCS12 archive into DER representation.
///
/// Returns 0 (NULL) on success or a pointer to a `PickyError` on failure.
///
/// # Safety
///
/// - `pfx` must be a pointer to a valid memory location containing a `Pfx` object.
/// - `dst` must be valid for writes of `count` bytes.
#[no_mangle]
pub unsafe extern "C" fn Pfx_to_der(pfx: Option<&ffi::Pfx>, dst: *mut u8, count: usize) -> Option<Box<PickyError>> {
    let Some(pfx) = pfx else {
        return Some("received a null pointer".into());
    };

    let data = match pfx.0.to_der() {
        Ok(data) => data,
        Err(e) => return Some(e.into()),
    };

    let data_len = data.len();

    if data_len > count {
        return Some("not enough space to fit the DER-encoded PFX".into());
    }

    // Safety:
    // - `src` is valid for reads of `data_len` bytes.
    // - `dst` is valid for writes of `data_len` bytes, because it is valid for `count` bytes (caller is responsible for this invariant).
    // - Both `src` and `dst` are always properly aligned: u8 aligment is 1.
    // - Memory regions are not overlapping, `data` is created by us just above.
    std::ptr::copy_nonoverlapping(data.as_ptr(), dst, data_len);

    None
}
