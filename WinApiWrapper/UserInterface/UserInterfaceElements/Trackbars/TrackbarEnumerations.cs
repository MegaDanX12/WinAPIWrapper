namespace WinApiWrapper.UserInterface.UserInterfaceElements.Trackbars
{
    /// <summary>
    /// Enumerazioni usate dalle trackbar.
    /// </summary>

    internal static class TrackbarEnumerations
    {
        /// <summary>
        /// Componente della trackbar.
        /// </summary>
        internal enum TrackbarParts
        {
            /// <summary>
            /// Segnetti visibili sul bordo del controllo.
            /// </summary>
            TBCD_TICS = 1,
            /// <summary>
            /// Pulsante che l'utente può muovere.
            /// </summary>
            TBCD_THUMB,
            /// <summary>
            /// Canale dove il pulsante di muove attraverso.
            /// </summary>
            TBCD_CHANNEL
        }
    }
}