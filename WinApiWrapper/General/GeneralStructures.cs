namespace WinApiWrapper.General
{
    /// <summary>
    /// Strutture usate in diversi punti della Windows API.
    /// </summary>
    internal static class GeneralStructures
    {
        /// <summary>
        /// Rappresenta un rettagolo.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            /// <summary>
            /// Coordinata x dell'angolo superiore sinistro del rettangolo.
            /// </summary>
            public LONG Left;
            /// <summary>
            /// Coordinata y dell'angolo superiore sinistro del rettangolo.
            /// </summary>
            public LONG Top;
            /// <summary>
            /// Coordinata x dell'angolo inferiore destro del rettangolo.
            /// </summary>
            public LONG Right;
            /// <summary>
            /// Coordinata y dell'angolo inferiore destro del rettangolo.
            /// </summary>
            public LONG Bottom;
        }

        /// <summary>
        /// Specifica la larghezza e l'altezza di un rettangolo.
        /// </summary>
        /// <remarks>L'unità usata dai campi di questa struttura dipende dalla funzione.</remarks>
        [StructLayout(LayoutKind.Sequential)]
        internal struct SIZE
        {
            /// <summary>
            /// Larghezza del rettagolo.
            /// </summary>
            public LONG x;
            /// <summary>
            /// Altezza del rettangolo.
            /// </summary>
            public LONG y;
        }

        /// <summary>
        /// Definisce le coordinate di un punto.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            /// <summary>
            /// Coordinata x del punto.
            /// </summary>
            public LONG x;
            /// <summary>
            /// Coordinata y del punto.
            /// </summary>
            public LONG y;
        }

        /// <summary>
        /// Definisce le coordinate di un punto.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINTS
        {
            /// <summary>
            /// Coordinata x del punto.
            /// </summary>
            public SHORT x;
            /// <summary>
            /// Coordinata y del punto.
            /// </summary>
            public SHORT y;
        }

        /// <summary>
        /// Specifica una data e ora.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEMTIME
        {
            /// <summary>
            /// Anno.
            /// </summary>
            /// <remarks>I valori validi vanno da 1601 a 30827.</remarks>
            public WORD Year;
            /// <summary>
            /// Mese.
            /// </summary>
            public WORD Month;
            /// <summary>
            /// Giorno della settimana.
            /// </summary>
            public WORD DayOfWeek;
            /// <summary>
            /// Giorno del mese.
            /// </summary>
            /// <remarks>I valori validi vanno da 1 a 31.</remarks>
            public WORD Day;
            /// <summary>
            /// Ora.
            /// </summary>
            /// <remarks>I valori validi vanno da 0 a 23.</remarks>
            public WORD Hour;
            /// <summary>
            /// Minuti.
            /// </summary>
            /// <remarks>I valori validi vanno da 0 a 59.</remarks>
            public WORD Minute;
            /// <summary>
            /// Secondi.
            /// </summary>
            /// <remarks>I valori validi vanno da 0 a 59.</remarks>
            public WORD Second;
            /// <summary>
            /// Millisecondi.
            /// </summary>
            /// <remarks>I valori validi vanno da 0 a 999.</remarks>
            public WORD Millisecond;
        }

        /// <summary>
        /// Valore a 64 bit che rappresenta il numero degli intervalli di 100 nanosecondi a partire dal 01/01/1601 (UTC).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct FILETIME
        {
            /// <summary>
            /// Primi 32 bit del valore.
            /// </summary>
            public uint LowDateTime;
            /// <summary>
            /// Ultimi 32 bit del valore.
            /// </summary>
            public uint HighDateTime;
        }
    }
}