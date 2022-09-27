namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Controls
{
    /// <summary>
    /// Strutture controlli finestre.
    /// </summary>
    internal static class WindowsControlsStructures
    {
        /// <summary>
        /// Margini delle finestre che hanno gli stili visuali applicati.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MARGINS
        {
            /// <summary>
            /// Larghezza del bordo sinistro che mantiene la sua dimensione.
            /// </summary>
            public int LeftBorderWidth;
            /// <summary>
            /// Larghezza del bordo destro che mantiene la sua dimesione.
            /// </summary>
            public int RightBorderWidth;
            /// <summary>
            /// Altezza del bordo superiore che mantiene la sua dimensione.
            /// </summary>
            public int TopBorderHeight;
            /// <summary>
            /// Altezza del bordo inferiore che mantiene la sua dimensione.
            /// </summary>
            public int BottomBorderHeight;
        }
    }
}