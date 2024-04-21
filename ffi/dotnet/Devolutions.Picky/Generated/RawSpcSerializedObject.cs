// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky.Raw;

#nullable enable

[StructLayout(LayoutKind.Sequential)]
public partial struct SpcSerializedObject
{
#if __IOS__
    private const string NativeLib = "libDevolutionsPicky.framework/libDevolutionsPicky";
#else
    private const string NativeLib = "DevolutionsPicky";
#endif

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SpcSerializedObject_get_class_id", ExactSpelling = true)]
    public static unsafe extern VecU8* GetClassId(SpcSerializedObject* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SpcSerializedObject_get_object_id", ExactSpelling = true)]
    public static unsafe extern VecU8* GetObjectId(SpcSerializedObject* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SpcSerializedObject_destroy", ExactSpelling = true)]
    public static unsafe extern void Destroy(SpcSerializedObject* self);
}