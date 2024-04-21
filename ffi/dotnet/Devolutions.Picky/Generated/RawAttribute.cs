// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky.Raw;

#nullable enable

[StructLayout(LayoutKind.Sequential)]
public partial struct Attribute
{
#if __IOS__
    private const string NativeLib = "libDevolutionsPicky.framework/libDevolutionsPicky";
#else
    private const string NativeLib = "DevolutionsPicky";
#endif

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Attribute_get_type", ExactSpelling = true)]
    public static unsafe extern IntPtr GetType(Attribute* self, DiplomatWriteable* writable);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Attribute_get_values", ExactSpelling = true)]
    public static unsafe extern AttributeValues* GetValues(Attribute* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Attribute_destroy", ExactSpelling = true)]
    public static unsafe extern void Destroy(Attribute* self);
}