using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageCallbacks;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues
{
    /// <summary>
    /// Funzioni relative ai messaggi.
    /// </summary>
    internal static class MessageFunctions
    {
        /// <summary>
        /// Invia un messaggio a una o più finestre.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che riceve il messaggio.</param>
        /// <param name="Message">Messaggio da inviare.</param>
        /// <param name="wParam">Informazione specifica del messaggio.</param>
        /// <param name="lParam">Informazione specifica del messaggio.</param>
        /// <param name="Behaviour">Comportamento della funzione.</param>
        /// <param name="Timeout">Timeout, in millisecondi.</param>
        /// <param name="Result">Risultato dell'elaborazione del messaggio.</param>
        /// <returns>Se l'operazione è riuscita il valore restituto è diverso da 0, in caso contrario ha valore 0.</returns>
        /// <remarks>Se la finestra ricevente appartiene a un altro thread, questa funzione restituisce solo dopo che il messaggio è stato elaborato o dopo che il tempo è scaduto.<br/>
        /// Se la finestra ricevente appartiene al thread corrente, la procedura viene chiamata direttamente, il tempo di timeout viene ignorato.<br/><br/>
        /// Se un thread non chiama <see cref="GetMessage"/> o simili entro 5 secondi, esso viene considerato bloccato.<br/><br/>
        /// Il sistema esegue il marshalling sono per i messaggi di sistema.<br/><br/>
        /// Se il codice di errore impostato è <see cref="ERROR_TIMEOUT"/>, il tempo è scaduto.</remarks>
        [DllImport("User32.dll", EntryPoint = "SendMessageTimeoutW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern LRESULT SendMessageTimeout(HWND WindowHandle, int Message, WPARAM wParam, LPARAM lParam, SendMessageBehaviour Behaviour, uint Timeout, out DWORD_PTR Result);

        /// <summary>
        /// Invia un messaggio a una o più finestre.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che riceve il messaggio.</param>
        /// <param name="Message">Messaggio da inviare.</param>
        /// <param name="wParam">Informazione specifica del messaggio.</param>
        /// <param name="lParam">Informazione specifica del messaggio.</param>
        /// <returns>Risultato dell'elaborazione del messaggio, dipende da quest'ultimo.</returns>
        /// <remarks><paramref name="WindowHandle"/> può essere impostato a <see cref="MessageConstants.HWND_BROADCAST"/>, in questo caso il messaggio è inviato a tutte le finestre top-level nel sistema.<br/>
        /// Il thread di un processo può inviare messaggi solo alle code di messaggi di thread in processi con livello di integrità inferiore o equivalente.<br/>
        /// Se si invia un messaggio a un processo con livello di integrità superiore, l'operazione fallisce e il codice di errore imposta è <see cref="ERROR_ACCESS_DENIED"/>.<br/><br/>
        /// Se il messaggio è inviato tra thread, quello che lo ha inviato restà bloccato fino a quando non viene elaborato.<br/>
        /// Il thread inviate continuerà comunque a elaborare messaggi non in coda mentre è in attesa.</remarks>
        [DllImport("User32.dll", EntryPoint = "SendMessageW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern LRESULT SendMessage(HWND WindowHandle, int Message, WPARAM wParam, LPARAM lParam);

        /// <summary>
        /// Invia un messaggio a una o più finestre.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che riceve il messaggio.</param>
        /// <param name="Message">Messaggio da inviare.</param>
        /// <param name="wParam">Informazione specifica del messaggio.</param>
        /// <param name="lParam">Informazione specifica del messaggio.</param>
        /// <param name="Callback">Callback chiamato dal sistema dopo l'elaborazione del messaggio da parte del ricevente.</param>
        /// <param name="Data">Valore fornito dall'applicazione che sarà passato all callback.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="WindowHandle"/> può avere valore <see cref="MessageConstants.HWND_BROADCAST"/>, in questo caso il messaggio viene inviato a tutte le finestre top-level, il callback viene chiamato per ogni finestra.<br/><br/>
        /// Se la finestra appartiene allo stesso thread del chiamante, la procedura viene chiamata in modo sincrono e il callback immediatamente dopo l'elaborazione del messaggio.<br/>
        /// Se la finestra appartiene a un altro thread, il callback viene chiamato solo quando il thread che ha chiamato questa funzione chiama <see cref="GetMessage"/>, <see cref="PeekMessage"/> oppure <see cref="WaitMessagge"/>.<br/><br/>
        /// I messaggi di sistema inviati tramite questa funzione non possono contenere puntatori.<br/><br/>
        /// Il sistema esegue il marshalling solo per messaggi di sistema.</remarks>
        [DllImport("User32.dll", EntryPoint = "SendMessageCallbackW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SendMessageCallback(HWND WindowHandle, int Message, WPARAM wParam, LPARAM lParam, MessageCallback Callback, ULONG_PTR Data);

        /// <summary>
        /// Invia un messaggio a una o più finestre.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che riceve il messaggio.</param>
        /// <param name="Message">Messaggio da inviare.</param>
        /// <param name="wParam">Informazione specifica del messaggio.</param>
        /// <param name="lParam">Informazione specifica del messaggio.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="WindowHandle"/> può essere impostato a <see cref="MessageConstants.HWND_BROADCAST"/>, in questo caso il messaggio è inviato a tutte le finestre top-level nel sistema.<br/><br/>
        /// I messaggi di sistema inviati tramite questa funzione non possono contenere puntatori.<br/><br/>
        /// Il sistema esegue il marshalling solo per messaggi di sistema.</remarks>
        [DllImport("User32.dll", EntryPoint = "SendNotifyMessageW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SendNotifyMessage(HWND WindowHandle, int Message, WPARAM wParam, LPARAM lParam);
    }
}