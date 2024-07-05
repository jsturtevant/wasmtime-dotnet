using System;
using System.Runtime.InteropServices;

namespace Wasmtime
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct ExternFunc
    {
        public ulong store;
        public nuint __private;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct ExternTable
    {
        public ulong store;
        public nuint __private;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct ExternMemory
    {
        public ulong store;
        public nuint __private;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct ExternInstance
    {
        public ulong store;
        public nuint __private;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct ExternGlobal
    {
        public ulong store;
        public nuint __private;
    }

    internal enum ExternKind : byte
    {
        Func,
        Global,
        Table,
        Memory,
        SharedMemory,
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct ExternUnion
    {
        [FieldOffset(0)]
        public ExternFunc func;

        [FieldOffset(0)]
        public ExternGlobal global;

        [FieldOffset(0)]
        public ExternTable table;

        [FieldOffset(0)]
        public ExternMemory memory;

        [FieldOffset(0)]
        public IntPtr sharedmemory;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Extern : IDisposable
    {
        public ExternKind kind;
        public ExternUnion of;

        public void Dispose()
        {
            Native.wasmtime_extern_delete(this);
        }

        private static class Native
        {
            [DllImport(Engine.LibraryName)]
            public static extern void wasmtime_extern_delete(in Extern self);
        }
    }
}
