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
        internal const uint E_INVALIDARG = 0x80070057;

        /// <summary>
        /// Accesso negato.
        /// </summary>
        internal const uint E_ACCESSDENIED = 0x80070005;
    }
}