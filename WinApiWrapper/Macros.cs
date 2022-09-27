using System.Globalization;

namespace WinApiWrapper
{
    /// <summary>
    /// Metodi che emulano il funzionamento delle macro definite nella WinApi.
    /// </summary>
    internal static class Macros
    {
        /// <summary>
        /// Recupera i primi due byte di un intero a 32 bit.
        /// </summary>
        /// <param name="Value">Intero a 32 bit da cui estrarre i byte.</param>
        /// <returns>Valore a 16 bit risultato della conversione.</returns>
        internal static WORD LOWORD(int Value)
        {
            return IntPtr.Size is 4 ? (WORD)(Value & 0xffff) : (WORD)(((long)Value) & 0xffff);
        }

        /// <summary>
        /// Recupera gli ultimi due byte di un intero a 32 bit.
        /// </summary>
        /// <param name="Value">Intero a 32 bit da cui estrarre i byte.</param>
        /// <returns>Valore a 16 bit risultato della conversione.</returns>
        internal static WORD HIWORD(int Value)
        {
            return IntPtr.Size is 4 ? (WORD)((Value >> 16) & 0xffff) : (WORD)((((long)Value) >> 16) & 0xffff);
        }

        /// <summary>
        /// Crea un intero a 32 bit concatenando i valori specificati.
        /// </summary>
        /// <param name="LowWord">Primi due byte del nuovo valore.</param>
        /// <param name="HighWord">Ultimi due byte del nuovo valore.</param>
        /// <returns>Intero a 32 bit risultato della concatenazione.</returns>
        internal static LONG MAKELONG(short LowWord, short HighWord)
        {
            return IntPtr.Size is 4
                ? (LONG)(((WORD)(LowWord & 0xffff)) | (((DWORD)(WORD)(HighWord & 0xffff)) << 16))
                : (LONG)(((WORD)(((long)LowWord) & 0xffff)) | (((DWORD)(WORD)(((long)HighWord) & 0xffff)) << 16));
        }

        /// <summary>
        /// Crea un valore utilizzabile come lParam in un messaggio.
        /// </summary>
        /// <param name="LowWord">Primi due byte del nuovo valore.</param>
        /// <param name="HighWord">Ultimi due byte del nuovo valore.</param>
        /// <returns>Il valore utilizzabile come lParam.</returns>
        internal static LPARAM MAKELPARAM(short LowWord, short HighWord)
        {
            return new LPARAM((DWORD)MAKELONG(LowWord, HighWord));
        }

        /// <summary>
        /// Crea un Locale ID.
        /// </summary>
        /// <param name="LangID">Language ID.</param>
        /// <param name="SortID">Sort ID.</param>
        /// <returns>Il Locale ID creato dalla concatenazione dei valori.</returns>
        internal static LCID MAKELCID(short LangID, short SortID)
        {
            return (((DWORD)(WORD)SortID) << 16) | (WORD)LangID;
        }

        /// <summary>
        /// Recupera l'ID della lingua dall'ID località.
        /// </summary>
        /// <param name="LocaleID">ID località da cui estrarre l'ID della lingua.</param>
        /// <returns>L'ID della lingua.</returns>
        internal static LANGID LANGIDFROMLCID(LCID LocaleID)
        {
            return (WORD)LocaleID;
        }

        /// <summary>
        /// Restituisce un ID risorsa come una stringa utilizzabile con alcune funzioni.
        /// </summary>
        /// <param name="Value">ID risorsa.</param>
        /// <returns>ID della risorsa come stringa.</returns>
        internal static string MAKEINTRESOURCE(int Value)
        {
            return "#" + Value.ToString("D0", CultureInfo.InvariantCulture);
        }
    }
}