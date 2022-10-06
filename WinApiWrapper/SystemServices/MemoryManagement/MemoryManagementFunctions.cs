using static WinApiWrapper.SystemServices.MemoryManagement.MemoryManagementEnumerations;

namespace WinApiWrapper.SystemServices.MemoryManagement
{
    /// <summary>
    /// Funzione per la gestione della memoria.
    /// </summary>
    internal static class MemoryManagementFunctions
    {
        /// <summary>
        /// Alloca un numero specificato di byte dall'heap.
        /// </summary>
        /// <param name="Options">Opzioni di allocazione.</param>
        /// <param name="AllocationSize">Quantità di memoria, in byte, da allocare.</param>
        /// <returns>Handle all'oggetto di memoria appena allocato se l'operazion è riuscita, <see cref="IntPtr.Zero"/> in caso contrario.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "GlobalAlloc", SetLastError = true)]
        internal static extern HGLOBAL GlobalAlloc(GlobalMemoryAllocationOptions Options, SIZE_T AllocationSize);

        /// <summary>
        /// Libera un oggetto di memoria e invalida il suo handle.
        /// </summary>
        /// <param name="MemoryObjectHandle">Handle all'oggetto.</param>
        /// <returns><see cref="IntPtr.Zero"/> se l'operazione è riuscita, un handle all'oggetto di memoria in caso contrario.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "GlobalFree", SetLastError = true)]
        internal static extern HGLOBAL GlobalFree(HGLOBAL MemoryObjectHandle);
    }
}