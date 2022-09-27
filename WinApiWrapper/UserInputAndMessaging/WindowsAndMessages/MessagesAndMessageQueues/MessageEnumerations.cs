namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues
{
    /// <summary>
    /// Enumerazioni relative ai messaggi.
    /// </summary>
    internal static class MessageEnumerations
    {
        /// <summary>
        /// Comportamento della funzione <see cref="MessageFunctions.SendMessageTimeout"/>.
        /// </summary>
        internal enum SendMessageBehaviour
        {
            /// <summary>
            /// Il thread chiamante può elaborare altre richieste mentre è in attesa del termine dell'operazione.
            /// </summary>
            SMTO_NORMAL,
            /// <summary>
            /// Il thread chiamante non può elaborare altre richieste mentre è in attesa del termine dell'operazione.
            /// </summary>
            SMTO_BLOCK,
            /// <summary>
            /// L'operazione termina senza aspettare lo scadere del timeout se il thread ricevente non risponde.
            /// </summary>
            SMTO_ABORTIFHUNG,
            /// <summary>
            /// Il timeout viene ignorato se il thread ricevente sta elaborando messaggi.
            /// </summary>
            SMTO_NOTIMEOUTIFNOTHUNG = 8,
            /// <summary>
            /// La distruzione della finestra ricevente o il termine del suo thread proprietario avviene durante l'elaborazione del messaggio, questo evento deve essere considerato un errore.
            /// </summary>
            SMTO_ERRORONEXIT = 32
        }
    }
}