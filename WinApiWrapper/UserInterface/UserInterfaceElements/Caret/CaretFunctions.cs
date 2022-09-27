using static WinApiWrapper.General.GeneralStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Caret
{
    /// <summary>
    /// Funzioni relative al cursore di inserimento testo.
    /// </summary>
    internal static class CaretFunctions
    {
        /// <summary>
        /// Crea una nuova forma per il cursore di inserimento testo di sistema e assegna la proprietà alla finestra specificata.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra proprietaria del cursore.</param>
        /// <param name="CaretShapeBitmap">Handle a un bitmap che definisce la forma del cursore.</param>
        /// <param name="Width">Larghezza del cursore, in unità logiche.</param>
        /// <param name="Height">Altezza del cursore, in unità logiche.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="CaretShapeBitmap"/> può essere <see cref="IntPtr.Zero"/>, in tal caso il cursore è solido.<br/>
        /// Se <paramref name="CaretShapeBitmap"/> ha valore 1, il cursore è grigio.<br/>
        /// Se <paramref name="CaretShapeBitmap"/> è un effettivo handle a un bitmap, il cursore assume la forma indicata da esso, <paramref name="Width"/> e <paramref name="Height"/> vengono ignorati.<br/><br/>
        /// <paramref name="Width"/> e <paramref name="Height"/> possono essere 0, in tal caso i valori vengono impostati al larghezza/altezza del bordo della finestra.<br/><br/>
        /// Questa funzione elimina automaticamente la forma precedente del cursore, se esiste, a prescindere dal proprietario.<br/><br/>
        /// Il sistema fornisce un cursore per coda, una finestra dovrebbre creare un cursore solo quando ha il focus della tastiera o è attiva e dovrebbe essere eliminato prima che essa per il focus della tastiera o di disattivarsi.<br/><br/>
        /// Il cursore resta nascosto finche non viene chiamata la funzione <see cref="ShowCaret"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "CreateCaret", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL CreateCaret(HWND WindowHandle, HBITMAP CaretShapeBitmap, int Width, int Height);

        /// <summary>
        /// Elimina la forma corrente del cursore di inserimento, lo libera dalla finestra e lo rimuove dallo schermo.
        /// </summary>
        /// <returns>true se l'operazione ha successo, false altrimenti.</returns>
        /// <remarks>Il cursore viene eliminato solo se una finestra nell'attività corrente ne è proprietaria.</remarks>
        [DllImport("User32.dll", EntryPoint = "DestroyCaret", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL DestroyCaret();

        /// <summary>
        /// Recupera il tempo necessario per invertire i pixel del cursore di inserimento.
        /// </summary>
        /// <returns>Il tempo di lampeggiamento, in millisecondi, 0 se l'operazione è fallita.</returns>
        /// <remarks>Se la funzione restituisce <see cref="INFINITE"/> il cursore non lampeggia.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetCaretBlinkTime", SetLastError = true)]
        internal static extern uint GetCaretBlinkTime();

        /// <summary>
        /// Recupera la posizione del cursore di inserimento.
        /// </summary>
        /// <param name="Coordinates">Struttura <see cref="POINT"/> che riceve le coordinate client del cursore di inserimento.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>La posizione del cursore viene sempre fornita in coordinate client della finestra che lo contiene.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetCaresPoint", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetCaretPosition(out POINT Coordinates);

        /// <summary>
        /// Rimuove il cursore di inserimento dallo schermo.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra proprietaria del cursore.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Nascondere il cursore non elimina la sua forma attuale e il punto di inserimento resta valido.<br/><br/>
        /// <paramref name="WindowHandle"/> può essere <see cref="IntPtr.Zero"/>, in tal caso la funzione cerca nell'attività corrente la finestra c proprietaria.<br/><br/>
        /// Se <paramref name="WindowHandle"/> si riferisce a una finestra e quest'ultima non è proprietaria del cursore, l'operazione fallisce.<br/><br/>
        /// Le chiamata a questa funzione sono cumulative.</remarks>
        [DllImport("User32.dll", EntryPoint = "HideCaret", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL HideCaret(HWND WindowHandle);

        /// <summary>
        /// Imposta il tempo di lampeggiamento del cursore di inserimento a un numero specificato di millisecondi.
        /// </summary>
        /// <param name="Milliseconds">Il nuovo tempo di lampeggiamento, in millisecondi.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("User32.dll", EntryPoint = "SetCaretBlinkTime", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetCaretBlinkTime(uint Milliseconds);

        /// <summary>
        /// Muove il cursore di inserimento alle coordinate specificate.
        /// </summary>
        /// <param name="X">Coordinata x.</param>
        /// <param name="Y">Coordinata y.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>La funzione muove il cursore anche se nascosto.<br/>
        /// Il cursore può essere mosso solo dalla finestra proprietaria.</remarks>
        [DllImport("User32.dll", EntryPoint = "SetCaretPos", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetCaretPosition(int X, int Y);

        /// <summary>
        /// Rende il cursore di inserimento visibile alla sua attuale posizione.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra proprietaria del cursore.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Se <paramref name="WindowHandle"/> ha valore <see cref="IntPtr.Zero"/>, la funzione ricerca la proprietaria nell'attuale attività.<br/><br/>
        /// Se <paramref name="WindowHandle"/> si riferisce a una finestra, il cursore è reso visibile solo se essa è sua proprietaria, se esso ha una forma e se non è stato nascosto due o più volte.</remarks>
        [DllImport("User32.dll", EntryPoint = "ShowCaret", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL ShowCaret(HWND WindowHandle);
    }
}