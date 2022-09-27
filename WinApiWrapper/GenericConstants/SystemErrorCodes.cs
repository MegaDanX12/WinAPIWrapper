namespace WinApiWrapper.GenericConstants
{
    /// <summary>
    /// Codici di errore di sistema.
    /// </summary>
    internal static class SystemErrorCodes
    {
        /// <summary>
        /// Operazione riuscita.
        /// </summary>
        internal const int ERROR_SUCCESS = 0;

        /// <summary>
        /// Accesso negato.
        /// </summary>
        internal const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// Parametro non valido.
        /// </summary>
        internal const int ERROR_INVALID_PARAMETER = 87;

        /// <summary>
        /// L'area di dati passata a una system call è troppo piccola.
        /// </summary>
        internal const int ERROR_INSUFFICIENT_BUFFER = 122;

        /// <summary>
        /// Handle non valido.
        /// </summary>
        internal const int ERROR_INVALID_HANDLE = 6;

        /// <summary>
        /// Non ci sono altri dati.
        /// </summary>
        internal const int ERROR_NO_MORE_FILES = 18;

        /// <summary>
        /// Il registro di configurazione del sistema è danneggiato.
        /// </summary>
        internal const int ERROR_BADDB = 1009;

        /// <summary>
        /// Opzioni non valide.
        /// </summary>
        internal const int ERROR_INVALID_FLAGS = 1004;

        /// <summary>
        /// Memoria insufficiente per completare l'operazione.
        /// </summary>
        internal const int ERROR_OUTOFMEMORY = 14;

        /// <summary>
        /// Sintassi del nome incorretta.
        /// </summary>
        internal const int ERROR_INVALID_NAME = 123;

        /// <summary>
        /// Nessun carattere associabile al carattere Unicode esiste nella code page.
        /// </summary>
        internal const int ERROR_NO_UNICODE_TRANSLATION = 1113;

        /// <summary>
        /// Si è verificato un errore interno.
        /// </summary>
        internal const int ERROR_INTERNAL_ERROR = 1359;

        /// <summary>
        /// L'applicazione è bloccata da Criteri di gruppo.
        /// </summary>
        internal const int ERROR_ACCESS_DISABLED_BY_POLICY = 1260;

        /// <summary>
        /// Dati non validi.
        /// </summary>
        internal const int ERROR_INVALID_DATA = 13;

        /// <summary>
        /// Modulo non trovato.
        /// </summary>
        internal const int ERROR_MOD_NOT_FOUND = 126;

        /// <summary>
        /// Procedura non trovata.
        /// </summary>
        internal const int ERROR_PROC_NOT_FOUND = 127;

        /// <summary>
        /// Il tempo per eseguire l'operazione è scaduto.
        /// </summary>
        internal const int ERROR_TIMEOUT = 1460;

        /// <summary>
        /// E' stato un eseguito di caricare un programma in un formato non corretto.
        /// </summary>
        internal const int ERROR_INVALID_ACCESS = 12;

        /// <summary>
        /// La richiesta non è supportata.
        /// </summary>
        internal const int ERROR_NOT_SUPPORTED = 50;
    }
}