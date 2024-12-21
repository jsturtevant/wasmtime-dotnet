using System.Runtime.InteropServices;

namespace Wasmtime.Interop;

internal static unsafe partial class Wasmtime
{
    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("wasmtime_error_t *")]
    public static extern void* wasmtime_table_new([NativeTypeName("wasmtime_context_t *")] void* store, [NativeTypeName("const wasm_tabletype_t *")] void* ty, [NativeTypeName("const wasmtime_val_t *")] Value* init, [NativeTypeName("wasmtime_table_t *")] ExternTable* table);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("wasm_tabletype_t *")]
    public static extern void* wasmtime_table_type([NativeTypeName("const wasmtime_context_t *")] void* store, [NativeTypeName("const wasmtime_table_t *")] ExternTable* table);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte wasmtime_table_get([NativeTypeName("wasmtime_context_t *")] void* store, [NativeTypeName("const wasmtime_table_t *")] ExternTable* table, [NativeTypeName("uint64_t")] ulong index, [NativeTypeName("wasmtime_val_t *")] Value* val);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("wasmtime_error_t *")]
    public static extern void* wasmtime_table_set([NativeTypeName("wasmtime_context_t *")] void* store, [NativeTypeName("const wasmtime_table_t *")] ExternTable* table, [NativeTypeName("uint64_t")] ulong index, [NativeTypeName("const wasmtime_val_t *")] Value* value);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("uint64_t")]
    public static extern ulong wasmtime_table_size([NativeTypeName("const wasmtime_context_t *")] void* store, [NativeTypeName("const wasmtime_table_t *")] ExternTable* table);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("wasmtime_error_t *")]
    public static extern void* wasmtime_table_grow([NativeTypeName("wasmtime_context_t *")] void* store, [NativeTypeName("const wasmtime_table_t *")] ExternTable* table, [NativeTypeName("uint64_t")] ulong delta, [NativeTypeName("const wasmtime_val_t *")] Value* init, [NativeTypeName("uint64_t *")] ulong* prev_size);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("wasmtime_error_t *")]
    public static extern void* wasmtime_error_new([NativeTypeName("const char *")] sbyte* param0);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void wasmtime_error_delete([NativeTypeName("wasmtime_error_t *")] void* error);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void wasmtime_error_message([NativeTypeName("const wasmtime_error_t *")] void* error, [NativeTypeName("wasm_name_t *")] void* message);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte wasmtime_error_exit_status([NativeTypeName("const wasmtime_error_t *")] void* param0, int* status);

    [DllImport("wasmtime.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void wasmtime_error_wasm_trace([NativeTypeName("const wasmtime_error_t *")] void* param0, [NativeTypeName("wasm_frame_vec_t *")] void* @out);
}
