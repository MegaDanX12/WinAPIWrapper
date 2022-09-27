namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues
{
    /// <summary>
    /// Constanti usate dai messaggi.
    /// </summary>
    internal static class MessageConstants
    {
        /// <summary>
        /// Indica di inviare un messaggio a tutte le finestre top-level.
        /// </summary>
        internal static HWND HWND_BROADCAST = new(65535);
    }
}