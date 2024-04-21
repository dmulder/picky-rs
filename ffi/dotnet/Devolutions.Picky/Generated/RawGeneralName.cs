// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky.Raw;

#nullable enable

[StructLayout(LayoutKind.Sequential)]
public partial struct GeneralName
{
#if __IOS__
    private const string NativeLib = "libDevolutionsPicky.framework/libDevolutionsPicky";
#else
    private const string NativeLib = "DevolutionsPicky";
#endif

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_get_type", ExactSpelling = true)]
    public static unsafe extern GeneralNameType GetType(GeneralName* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_other_name", ExactSpelling = true)]
    public static unsafe extern OtherName* ToOtherName(GeneralName* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_rfc822_name", ExactSpelling = true)]
    public static unsafe extern IntPtr ToRfc822Name(GeneralName* self, DiplomatWriteable* writable);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_dns_name", ExactSpelling = true)]
    public static unsafe extern IntPtr ToDnsName(GeneralName* self, DiplomatWriteable* writable);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_directory_name", ExactSpelling = true)]
    public static unsafe extern AttributeTypeAndValueNestedIterator* ToDirectoryName(GeneralName* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_edi_party_name", ExactSpelling = true)]
    public static unsafe extern EdiPartyName* ToEdiPartyName(GeneralName* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_uri", ExactSpelling = true)]
    public static unsafe extern IntPtr ToUri(GeneralName* self, DiplomatWriteable* writable);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_ip_address", ExactSpelling = true)]
    public static unsafe extern VecU8* ToIpAddress(GeneralName* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_to_registered_id", ExactSpelling = true)]
    public static unsafe extern IntPtr ToRegisteredId(GeneralName* self, DiplomatWriteable* writable);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GeneralName_destroy", ExactSpelling = true)]
    public static unsafe extern void Destroy(GeneralName* self);
}