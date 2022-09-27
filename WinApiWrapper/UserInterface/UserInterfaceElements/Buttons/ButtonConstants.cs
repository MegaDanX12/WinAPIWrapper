namespace WinApiWrapper.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Costanti usate dai pulsanti.
    /// </summary>
    internal static class ButtonConstants
    {
        /// <summary>
        /// Indica di non mostrare nessuna immagine.
        /// </summary>
        internal static HIMAGELIST BCCL_NOGLYPH = new(-1);

        /// <summary>
        /// Inizio dei valori per i messaggi dei pulsanti.
        /// </summary>
        internal const int BCM_FIRST = 5632;

        /// <summary>
        /// Inizio dei valori per le notifiche dei pulsanti.
        /// </summary>
        internal const int BCN_FIRST = 0 - 1250;
    }
}