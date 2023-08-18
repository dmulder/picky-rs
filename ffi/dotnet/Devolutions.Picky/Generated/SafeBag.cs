// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

/// <summary>
/// PFX safe bag, the polymorphic container for all the data in a PKCS12 archive.
/// </summary>
public partial class SafeBag: IDisposable
{
    private unsafe Raw.SafeBag* _inner;

    public Cert? Certificate
    {
        get
        {
            return GetCertificate();
        }
    }

    public SafeBagKind Kind
    {
        get
        {
            return GetKind();
        }
    }

    public PrivateKey? PrivateKey
    {
        get
        {
            return GetPrivateKey();
        }
    }

    /// <summary>
    /// Creates a managed <c>SafeBag</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// <br/>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe SafeBag(Raw.SafeBag* handle)
    {
        _inner = handle;
    }

    /// <summary>
    /// Creates new safe bag holding a private key.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>SafeBag</c> allocated on Rust side.
    /// </returns>
    public static SafeBag NewKey(PrivateKey key)
    {
        unsafe
        {
            Raw.PrivateKey* keyRaw;
            keyRaw = key.AsFFI();
            if (keyRaw == null)
            {
                throw new ObjectDisposedException("PrivateKey");
            }
            IntPtr resultPtr = Raw.SafeBag.NewKey(keyRaw);
            Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError result = Marshal.PtrToStructure<Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError>(resultPtr);
            Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError.Destroy(resultPtr);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.SafeBag* retVal = result.Ok;
            return new SafeBag(retVal);
        }
    }

    /// <summary>
    /// Creates new safe bag holding an encrypted private key.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>SafeBag</c> allocated on Rust side.
    /// </returns>
    public static SafeBag NewEncryptedKey(PrivateKey key, Pkcs12CryptoContext cryptoContext)
    {
        unsafe
        {
            Raw.PrivateKey* keyRaw;
            keyRaw = key.AsFFI();
            if (keyRaw == null)
            {
                throw new ObjectDisposedException("PrivateKey");
            }
            Raw.Pkcs12CryptoContext* cryptoContextRaw;
            cryptoContextRaw = cryptoContext.AsFFI();
            if (cryptoContextRaw == null)
            {
                throw new ObjectDisposedException("Pkcs12CryptoContext");
            }
            IntPtr resultPtr = Raw.SafeBag.NewEncryptedKey(keyRaw, cryptoContextRaw);
            Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError result = Marshal.PtrToStructure<Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError>(resultPtr);
            Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError.Destroy(resultPtr);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.SafeBag* retVal = result.Ok;
            return new SafeBag(retVal);
        }
    }

    /// <summary>
    /// Creates new safe bag holding a certificate.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>SafeBag</c> allocated on Rust side.
    /// </returns>
    public static SafeBag NewCertificate(Cert cert)
    {
        unsafe
        {
            Raw.Cert* certRaw;
            certRaw = cert.AsFFI();
            if (certRaw == null)
            {
                throw new ObjectDisposedException("Cert");
            }
            IntPtr resultPtr = Raw.SafeBag.NewCertificate(certRaw);
            Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError result = Marshal.PtrToStructure<Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError>(resultPtr);
            Raw.Pkcs12FfiResultBoxSafeBagBoxPickyError.Destroy(resultPtr);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.SafeBag* retVal = result.Ok;
            return new SafeBag(retVal);
        }
    }

    /// <summary>
    /// Adds a PKCS12 attribute to this safe bag.
    /// </summary>
    public void AddAttribute(Pkcs12Attribute attribute)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            Raw.Pkcs12Attribute* attributeRaw;
            attributeRaw = attribute.AsFFI();
            if (attributeRaw == null)
            {
                throw new ObjectDisposedException("Pkcs12Attribute");
            }
            Raw.SafeBag.AddAttribute(_inner, attributeRaw);
        }
    }

    /// <returns>
    /// A <c>SafeBagKind</c> allocated on C# side.
    /// </returns>
    public SafeBagKind GetKind()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            Raw.SafeBagKind retVal = Raw.SafeBag.GetKind(_inner);
            return (SafeBagKind)retVal;
        }
    }

    /// <returns>
    /// A <c>PrivateKey</c> allocated on Rust side.
    /// </returns>
    public PrivateKey? GetPrivateKey()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            Raw.PrivateKey* retVal = Raw.SafeBag.GetPrivateKey(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new PrivateKey(retVal);
        }
    }

    /// <returns>
    /// A <c>Cert</c> allocated on Rust side.
    /// </returns>
    public Cert? GetCertificate()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            Raw.Cert* retVal = Raw.SafeBag.GetCertificate(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new Cert(retVal);
        }
    }

    public bool ContainsFriendlyName(string value)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            byte[] valueBuf = DiplomatUtils.StringToUtf8(value);
            nuint valueBufLength = (nuint)valueBuf.Length;
            fixed (byte* valueBufPtr = valueBuf)
            {
                bool retVal = Raw.SafeBag.ContainsFriendlyName(_inner, valueBufPtr, valueBufLength);
                return retVal;
            }
        }
    }

    public bool ContainsLocalKeyId(byte[] value)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            nuint valueLength = (nuint)value.Length;
            fixed (byte* valuePtr = value)
            {
                bool retVal = Raw.SafeBag.ContainsLocalKeyId(_inner, valuePtr, valueLength);
                return retVal;
            }
        }
    }

    /// <returns>
    /// A <c>Pkcs12AttributeIterator</c> allocated on Rust side.
    /// </returns>
    public Pkcs12AttributeIterator Attributes()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            Raw.Pkcs12AttributeIterator* retVal = Raw.SafeBag.Attributes(_inner);
            return new Pkcs12AttributeIterator(retVal);
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.SafeBag* AsFFI()
    {
        return _inner;
    }

    /// <summary>
    /// Destroys the underlying object immediately.
    /// </summary>
    public void Dispose()
    {
        unsafe
        {
            if (_inner == null)
            {
                return;
            }

            Raw.SafeBag.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~SafeBag()
    {
        Dispose();
    }
}
