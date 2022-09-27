using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;

namespace WinApiWrapper.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Costanti NLS.
    /// </summary>
    internal static class NationalLanguageSupportConstants
    {
        /// <summary>
        /// Permette la restituzione di nomi neutrali durante la conversione tra nomi località e ID località.
        /// </summary>
        internal const DWORD LOCALE_ALLOW_NEUTRAL_NAMES = 0x08000000;

        /// <summary>
        /// Lunghezza massima del nome della località.
        /// </summary>
        internal const int LOCALE_NAME_MAX_LENGTH = 85;

        /// <summary>
        /// Località personalizzata predefinita.
        /// </summary>
        internal const int LOCALE_CUSTOM_DEFAULT = 0x0C00;

        /// <summary>
        /// Località predefinita del sistema operativo.
        /// </summary>
        internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;

        /// <summary>
        /// Località predefinita per l'utente o il processo.
        /// </summary>
        internal const int LOCALE_USER_DEFAULT = 0x0400;

        /// <summary>
        /// Località personalizzata predefinita per MUI.
        /// </summary>
        internal const int LOCALE_CUSTOM_UI_DEFAULT = 0x1400;

        /// <summary>
        /// Località personalizzata non specificata.
        /// </summary>
        internal const int LOCALE_CUSTOM_UNSPECIFIED = 0x1000;

        /// <summary>
        /// Località usata per funzione del sistema operativo che richiedono risultati consistenti e indipendenti dalla località.
        /// </summary>
        internal const int LOCALE_INVARIANT = 0x007f;

        /// <summary>
        /// Nome località non variabile.
        /// </summary>
        internal const string LOCALE_NAME_INVARIANT = "";

        /// <summary>
        /// Indica di non usare gli override utente (non raccomandato).
        /// </summary>
        internal const DWORD LOCALE_NOUSEROVERRIDE = 0x80000000;

        /// <summary>
        /// Indica di restituire un numero al posto di una stringa.
        /// </summary>
        internal const DWORD LOCALE_RETURN_NUMBER = 0x20000000;

        /// <summary>
        /// Indica di restituire i nomi genitivi dei mesi.
        /// </summary>
        internal const DWORD LOCALE_RETURN_GENITIVE_NAMES = 0x10000000;

        /// <summary>
        /// Nome di località corrente del sistema operativo.
        /// </summary>
        internal const string LOCALE_NAME_SYSTEM_DEFAULT = "!x-sys-default-locale";

        /// <summary>
        /// Nome di località corrente dell'utente.
        /// </summary>
        internal const string LOCALE_NAME_USER_DEFAULT = null;

        /// <summary>
        /// Indica di non usare gli override utente (non raccomandato).
        /// </summary>
        internal const DWORD CAL_NOUSEROVERRIDE = LOCALE_NOUSEROVERRIDE;

        /// <summary>
        /// Indica di restituire un numero al posto di una stringa.
        /// </summary>
        internal const DWORD CAL_RETURN_NUMBER = LOCALE_RETURN_NUMBER;

        /// <summary>
        /// Indica di restituire i nomi genitivi dei mesi.
        /// </summary>
        internal const DWORD CAL_RETURN_GENITIVE_NAMES = LOCALE_RETURN_GENITIVE_NAMES;

        /// <summary>
        /// Numero massimo di byte iniziali.
        /// </summary>
        internal const DWORD MAX_LEADBYTES = 12;

        /// <summary>
        /// Dimensione massima, in bytes, di un carattere.
        /// </summary>
        internal const DWORD MAX_DEFAULTCHAR = 2;

        /// <summary>
        /// ID per gli script di output ereditati e comuni sono permessi.
        /// </summary>
        internal const DWORD GSS_ALLOW_INHERITED_COMMON = 1;

        /// <summary>
        /// Permette la presenza dello script "Latn" (script latino).
        /// </summary>
        /// <remarks>Usata dalla funzione <see cref="VerifyScripts"/>.</remarks>
        internal const DWORD VS_ALLOW_LATIN = 1;
    }
}