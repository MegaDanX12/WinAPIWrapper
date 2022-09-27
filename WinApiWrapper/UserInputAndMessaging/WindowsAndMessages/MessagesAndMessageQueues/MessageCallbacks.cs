namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues
{
    /// <summary>
    /// Callback per l'elaborazione dei messaggi.
    /// </summary>
    internal static class MessageCallbacks
    {
        /// <summary>
        /// Callback usato per eseguire operazione dopo l'elaborazione di un messaggio inviato a una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che ha ricevuto il messaggio.</param>
        /// <param name="Message">Messaggio inviato.</param>
        /// <param name="Value">Valore fornito dall'applicazione.</param>
        /// <param name="ProcessingResult">Risultato dell'elaborazione del messaggio.</param>
        internal delegate void MessageCallback(HWND WindowHandle, uint Message, ULONG_PTR Value, LRESULT ProcessingResult);
    }
}