namespace WinApiWrapper.Diagnostics.ErrorHandling
{
    /// <summary>
    /// Funzione relative alla gestione degli errori.
    /// </summary>
    internal static class ErrorHandlingFunctions
    {
        /// <summary>
        /// Imposta il codice di errore per il thread chiamante.
        /// </summary>
        /// <param name="ErrorCode">Codice di errore.</param>
        [DllImport("Kernel32.dll", EntryPoint = "SetLastError")]
        internal static extern void SetLastError(DWORD ErrorCode);
    }
}