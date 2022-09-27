using static WinApiWrapper.SystemServices.DLLs.DynamicLinkLibraryEnumerations;

namespace WinApiWrapper.SystemServices.DLLs
{
    /// <summary>
    /// Funzioni usate per la gestione delle DLL.
    /// </summary>
    internal static class DynamicLinkLibraryFunctions
    {
        /// <summary>
        /// Recupera un handle a un modulo.
        /// </summary>
        /// <param name="Options">Opzioni di caricamento del modulo.</param>
        /// <param name="ModuleName">Nome del modulo.</param>
        /// <param name="ModuleHandle">Handle al modulo.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="ModuleName"/> può contenere il nome del file o un indirizzo nel modulo.<br/><br/>
        /// <paramref name="ModuleName"/> può contenere un indirizzo solo se <paramref name="Options"/> include <see cref="ModuleHandleOptions.FROM_ADDRESS"/>.<br/><br/>
        /// Se <paramref name="ModuleName"/> continene il nome del file, se l'estensione è omessa viene automaticamente aggiunta l'estensione .dll a meno che non finisca con un punto che indica che il file non ha estensione.<br/>
        /// Se <paramref name="ModuleName"/> è nullo, la funzione restituisce un handle al file usato per creare il processo chiamante.<br/><br/>
        /// In caso di errore <paramref name="ModuleHandle"/> ha valore <see cref="IntPtr.Zero"/>.<br/>
        /// Questa funzione non restituisce handle a moduli caricati usando l'opzione <see cref="LibraryLoadingOptions.LOAD_LIBRARY_AS_DATAFILE"/>.<br/><br/>
        /// L'handle restituito non è né globale né ereditabile, non può essere duplicato o usato in un altro processo.<br/><br/>
        /// Se <paramref name="Options"/> include <see cref="ModuleHandleOptions.UNCHANGED_REFCOUNT"/>, il modulo viene caricato senza aumentare il conteggio di riferimenti.<br/>
        /// In questo caso l'handle non deve essere passato a <see cref="FreeLibrary"/>.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetModuleHandleExW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetModuleHandle(ModuleHandleOptions Options, string? ModuleName, out HMODULE ModuleHandle);

        /// <summary>
        /// Libera un modulo DLL caricato e, se necessario, riduce il numero di riferimenti.
        /// </summary>
        /// <param name="ModuleHandle">Handle al modulo.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Se il numero di riferimenti al modulo raggiunge zero, esso viene scaricato dallo spazio di indirizzamento del processo e l'handle non è più valido.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "FreeLibrary", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL FreeLibrary(HMODULE ModuleHandle);

        /// <summary>
        /// Carica un modulo nello spazio di indirizzamento del processo chiamante.
        /// </summary>
        /// <param name="LibraryFileName">Nome del file del modulo da caricare.</param>
        /// <param name="FileHandle">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <param name="Options">Opzioni di caricamento del modulo.</param>
        /// <returns>Handle al modulo caricato, <see cref="IntPtr.Zero"/> in caso di errore.</returns>
        /// <remarks><paramref name="LibraryFileName"/> può specificare un file .dll o un file .exe, in quest'ultimo caso gli import statici non vengono caricati.<br/><br/>
        /// Se <paramref name="LibraryFileName"/> non contiene un percorso, l'estensione è omessa e la stringa fornita non termina con un punto, viene aggiunta l'estensione .dll.<br/><br/>
        /// Se <paramref name="LibraryFileName"/> contiene un percorso completo, il modulo viene ricercato solo in quel percorso.<br/><br/>
        /// Se <paramref name="LibraryFileName"/> non contiene un percorso e esistono più moduli già caricati con lo stesso nome ed estensione, viene restituito un handle al modulo caricato per primo.<br/><br/>
        /// Se <paramref name="LibraryFileName"/> non specifica un percorso e non esiste nessun modulo caricato con lo stesso nome oppure se il percorso indicato è relativo, la funzione ricerca il modulo e le sue dipendenze, le directory dove avviene la ricerca dipendono dal valore di <paramref name="Options"/>.<br/><br/>
        /// Se la funzione non riesce a trovare il modulo o una delle sue dipendenze l'operazione fallisce.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "LoadLibraryExW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HMODULE LoadLibrary(string LibraryFileName, HANDLE FileHandle, LoadingOptions Options);
    }
}