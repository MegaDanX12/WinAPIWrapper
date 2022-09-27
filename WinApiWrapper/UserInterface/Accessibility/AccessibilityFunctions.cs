using static WinApiWrapper.UserInterface.Accessibility.AccessibilityEnumerations;

namespace WinApiWrapper.UserInterface.Accessibility
{
    /// <summary>
    /// Funzioni accessibilità.
    /// </summary>
    internal static class AccessibilityFunctions
    {
        /// <summary>
        /// Registra una finestra come bersaglio di tutto l'input di un puntatore di un tipo specifico.
        /// </summary>
        /// <param name="WindowHandle">Handle nativo alla finestra.</param>
        /// <param name="PointerType">Tipo di puntatore.</param>
        /// <returns>true se l'operazione ha successo, false in caso contrario.</returns>
        /// <remarks>Applicazioni con il privilegio UI Access possono usare questa funzione per registrare una propria finestra come bersaglio di tutto l'input di tipo di puntatore specifico.<br/><br/>
        /// Ogni desktop permette solamente a una finestra questa funzione, tale finestra continuerà ad essere il bersaglio fino a quando la registrazione non viene annullata o la finestra viene distrutta.<br/><br/>
        /// La finestra riceve input solo da processi diversi da quello proprietario.<br/><br/>
        /// Una singola finestra può essere registrata come bersaglio di diversi tipi di input.<br/><br/>
        /// Se il thread chiamante non ha il privilegio UI Access, se la finestra non appartiene al processo oppure se la finestra è già registrata come bersaglio del tipo di puntatore specificato, la funzione restituisce <see cref="ERROR_ACCESS_DENIED"/>.<br/>
        /// Se il tipo di puntatore specificato non è valido, la funzione restituisce <see cref="ERROR_INVALID_PARAMETER"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "RegisterPointerInputTarget", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL RegisterPointerInputTarget(HWND WindowHandle, POINTER_INPUT_TYPE PointerType);

        /// <summary>
        /// Annulla la registrazione di una finestra come bersaglio di tutto l'input del puntatore del tipo specificato.
        /// </summary>
        /// <param name="WindowHandle">Handle nativo alla finestra.</param>
        /// <param name="PointerType">Tipo di puntatore.</param>
        /// <returns>true se l'operazione ha successo, false in caso contrario.</returns>
        /// <remarks>Un'applicazione che ha utilizzato <see cref="RegisterPointerInputTarget"/> può usare questa funzione per annullare la registrazione della finestra per il tipo di input specificato.<br/><br/>
        /// Un'applicazione che ha registrato la stessa finestra come bersaglio di più input può chiamare questa funzione per annullare la registrazione per un tipo di input lasciando attivi gli altri.<br/><br/>
        /// Se il thread chiamante non ha il privilegio UI Access oppure se la finestra non appartiene al processo, la funzione restituisce <see cref="ERROR_ACCESS_DENIED"/>.<br/>
        /// Se il tipo di puntatore specificato non è valido, la funzione restituisce <see cref="ERROR_INVALID_PARAMETER"/>.<br/>
        /// Se la finestra specificata non è il bersaglio del tipo di input specificato, la funzione non esegue alcuna operazione e restituisce true.</remarks>
        [DllImport("User32.dll", EntryPoint = "UnregisterPointerInputTarget", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL UnregisterPointerInputTarget(HWND WindowHandle, POINTER_INPUT_TYPE PointerType);
    }
}