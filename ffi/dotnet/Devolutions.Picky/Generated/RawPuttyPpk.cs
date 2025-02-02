// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky.Raw;

#nullable enable

/// <summary>
/// PuTTY Private Key (PPK) format.
/// </summary>
/// <remarks>
/// ### Functionality
/// - Generation of new keys.
/// - Conversion to/from OpenSSH format.
/// - Encoding/decoding to/from string.
/// - Version upgrade/downgrade.
/// <br/>
/// ### Usage notes
/// - Ppk structure is immutable. All operations that modify the key return a new instance.
/// - When input file is encrypted, all operations with the private key will be unavailable until
/// ppk is decrypted via `PuttyPpk::decrypt`.
/// - Newly generated keys are always unencrypted. They should be encrypted via `PuttyPpk::encrypt`
/// when required
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public partial struct PuttyPpk
{
#if __IOS__
    private const string NativeLib = "libDevolutionsPicky.framework/libDevolutionsPicky";
#else
    private const string NativeLib = "DevolutionsPicky";
#endif

    /// <summary>
    /// Generate a new RSA key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_generate_rsa", ExactSpelling = true)]
    public static unsafe extern IntPtr GenerateRsa(nuint bits, byte* comment, nuint commentSz);

    /// <summary>
    /// Generate a new EC key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_generate_ec", ExactSpelling = true)]
    public static unsafe extern IntPtr GenerateEc(EcCurve curve, byte* comment, nuint commentSz);

    /// <summary>
    /// Generate a new Ed25519 key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_generate_ed25519", ExactSpelling = true)]
    public static unsafe extern IntPtr GenerateEd25519(byte* comment, nuint commentSz);

    /// <summary>
    /// Encode PPK key file to a string.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_to_repr", ExactSpelling = true)]
    public static unsafe extern IntPtr ToRepr(PuttyPpk* self, DiplomatWriteable* writeable);

    /// <summary>
    /// Parse a PPK key file from a string.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_parse", ExactSpelling = true)]
    public static unsafe extern IntPtr Parse(byte* ppk, nuint ppkSz);

    /// <summary>
    /// Convert an OpenSSH private key to a PPK key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_from_openssh_private_key", ExactSpelling = true)]
    public static unsafe extern IntPtr FromOpensshPrivateKey(SshPrivateKey* key);

    /// <summary>
    /// Convert a PPK key file to an OpenSSH private key.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_to_openssh_private_key", ExactSpelling = true)]
    public static unsafe extern IntPtr ToOpensshPrivateKey(PuttyPpk* self, byte* passphrase, nuint passphraseSz);

    /// <summary>
    /// Get the public key from the PPK key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_get_public_key", ExactSpelling = true)]
    public static unsafe extern IntPtr GetPublicKey(PuttyPpk* self);

    /// <summary>
    /// Get the private key from the PPK key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_get_private_key", ExactSpelling = true)]
    public static unsafe extern IntPtr GetPrivateKey(PuttyPpk* self);

    /// <summary>
    /// Extract the public key file (PuTTY format) from the PPK key file.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_extract_putty_public_key", ExactSpelling = true)]
    public static unsafe extern IntPtr ExtractPuttyPublicKey(PuttyPpk* self);

    /// <summary>
    /// Get the PPK key file version.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_get_version", ExactSpelling = true)]
    public static unsafe extern PuttyPpkVersion GetVersion(PuttyPpk* self);

    /// <summary>
    /// Get the PPK key file algorithm.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_get_algorithm", ExactSpelling = true)]
    public static unsafe extern PuttyPpkKeyAlgorithm GetAlgorithm(PuttyPpk* self);

    /// <summary>
    /// Get the PPK key file comment.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_get_comment", ExactSpelling = true)]
    public static unsafe extern IntPtr GetComment(PuttyPpk* self, DiplomatWriteable* writeable);

    /// <summary>
    /// Convert the PPK key file to a different version.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_to_version", ExactSpelling = true)]
    public static unsafe extern IntPtr ToVersion(PuttyPpk* self, PuttyPpkVersion version);

    /// <summary>
    /// Check if the PPK key file is encrypted.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_is_encrypted", ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe extern bool IsEncrypted(PuttyPpk* self);

    /// <summary>
    /// Get the Argon2 key derivation function parameters (if the key is encrypted).
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_argon2_params", ExactSpelling = true)]
    public static unsafe extern PuttyArgon2Params* Argon2Params(PuttyPpk* self);

    /// <summary>
    /// Decrypt the PPK key file and return as a new instance.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_decrypt", ExactSpelling = true)]
    public static unsafe extern IntPtr Decrypt(PuttyPpk* self, byte* passphrase, nuint passphraseSz);

    /// <summary>
    /// Encrypt the PPK key file and return as a new instance.
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_encrypt", ExactSpelling = true)]
    public static unsafe extern IntPtr Encrypt(PuttyPpk* self, byte* passphrase, nuint passphraseSz, PuttyPpkEncryptionConfig* config);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PuttyPpk_destroy", ExactSpelling = true)]
    public static unsafe extern void Destroy(PuttyPpk* self);
}
