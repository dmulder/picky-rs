// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky.Raw;

#nullable enable

[StructLayout(LayoutKind.Sequential)]
public partial struct Pkcs12ParsingParams
{
#if __IOS__
    private const string NativeLib = "libDevolutionsPicky.framework/libDevolutionsPicky";
#else
    private const string NativeLib = "DevolutionsPicky";
#endif

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Pkcs12ParsingParams_new", ExactSpelling = true)]
    public static unsafe extern Pkcs12ParsingParams* New();

    /// <summary>
    /// Continue parsing if conversion to high level picky data structure fails (e.g. due to
    /// unsupported private key or certificate kind)
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Pkcs12ParsingParams_set_skip_soft_parsing_errors", ExactSpelling = true)]
    public static unsafe extern void SetSkipSoftParsingErrors(Pkcs12ParsingParams* self, [MarshalAs(UnmanagedType.U1)] bool value);

    /// <summary>
    /// Continue parsing if decryption fails and keep data in encrypted form
    /// </summary>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Pkcs12ParsingParams_set_skip_decryption_errors", ExactSpelling = true)]
    public static unsafe extern void SetSkipDecryptionErrors(Pkcs12ParsingParams* self, [MarshalAs(UnmanagedType.U1)] bool value);

    /// <summary>
    /// Continue parsing if MAC validation fails.
    /// </summary>
    /// <remarks>
    /// This is useful for parsing available unencrypted data from
    /// password-protected PFX files. Also could be useful if PFX integrity has been intentionally
    /// violated for testing purposes.
    /// </remarks>
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Pkcs12ParsingParams_set_skip_mac_validation", ExactSpelling = true)]
    public static unsafe extern void SetSkipMacValidation(Pkcs12ParsingParams* self, [MarshalAs(UnmanagedType.U1)] bool value);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Pkcs12ParsingParams_destroy", ExactSpelling = true)]
    public static unsafe extern void Destroy(Pkcs12ParsingParams* self);
}