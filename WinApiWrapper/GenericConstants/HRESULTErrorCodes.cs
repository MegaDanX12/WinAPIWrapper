namespace WinApiWrapper.GenericConstants
{
    /// <summary>
    /// Codici di errore HRESULT.
    /// </summary>
    internal static class HRESULTErrorCodes
    {
        /// <summary>
        /// Operazione riuscita.
        /// </summary>
        internal const int S_OK = 0;

        /// <summary>
        /// Parametro non valido.
        /// </summary>
        internal const uint E_INVALIDARG = 2147942487;

        /// <summary>
        /// Accesso negato.
        /// </summary>
        internal const uint E_ACCESSDENIED = 2147942405;

        /// <summary>
        /// Memoria insufficiente.
        /// </summary>
        internal const uint E_OUTOFMEMORY = 2147942414;

        /// <summary>
        /// Puntatore non valido.
        /// </summary>
        internal const uint E_POINTER = 2147500035;

        /// <summary>
        /// Handle non valido.
        /// </summary>
        internal const uint E_HANDLE = 2147942406;

        /// <summary>
        /// Errore non specificato.
        /// </summary>
        internal const uint E_FAIL = 2147500037;
    }
}