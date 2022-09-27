using static WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes.CommonDialogBoxesEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes.CommonDialogBoxesStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes
{
    /// <summary>
    /// Funzioni comuni delle finestre di dialogo.
    /// </summary>
    internal static class CommonDialogBoxesFunctions
    {
        /// <summary>
        /// Crea una finestra di dialogo di selezione colori che permette all'utente di selezionare un colore.
        /// </summary>
        /// <param name="ColorData">Struttura <see cref="CHOOSECOLOR"/> che contiene informazioni usate per inizializzare la finestra di dialogo.</param>
        /// <returns>Diverso da 0 se l'utente ha premuto il pulsante OK, 0 se l'utente annulla l'operazione.</returns>
        /// <remarks>Il parametro <paramref name="ColorData"/> conterrà il colore scelto dall'utente quando la funzione restituisce.<br/><br/>
        /// Se l'utente ha annullato l'operazione, la funzione <see cref="GetCommonDialogError"/> restituisce il codice di errore più specifico.<br/>
        /// I valori restituiti da tale funzione si trovano nell'enumerazione <see cref="CommonDialogBoxesEnumerations.DialogBoxErrorCode"/>.<br/><br/>
        /// I valori possibili sono:<br/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_DIALOGFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_FINDRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMLOCKFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_INITIALIZATION"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHINSTANCE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHOOK"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOTEMPLATE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADSTRFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_STRUCTSIZE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMALLOCFAILURE"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "ChooseColorW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL ChooseColor(ref CHOOSECOLOR ColorData);

        /// <summary>
        /// Crea una finestra di dialogo di selezione font che permette all'utente di selezionare gli attributi di un font logico.
        /// </summary>
        /// <param name="FontData">Struttura <see cref="CHOOSEFONT"/> che contiene informazioni per inizializzare la finestra di dialogo.</param>
        /// <returns>Diverso da 0 se l'utente ha premuto il pulsante OK, 0 se l'utente annulla l'operazione.</returns>
        /// <remarks>Il parametro <paramref name="FontData"/> conterrà il colore scelto dall'utente quando la funzione restituisce.<br/><br/>
        /// Se l'utente ha annullato l'operazione, la funzione <see cref="GetCommonDialogError"/> restituisce il codice di errore più specifico.<br/>
        /// I valori restituiti da tale funzione si trovano nell'enumerazione <see cref="CommonDialogBoxesEnumerations.DialogBoxErrorCode"/>.<br/><br/>
        /// I valori possibili sono:<br/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_DIALOGFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_FINDRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMLOCKFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_INITIALIZATION"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHINSTANCE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHOOK"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOTEMPLATE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADSTRFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_STRUCTSIZE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMALLOCFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOCKRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CFERR_MAXLESSTHANMIN"/><br/>
        /// <see cref="DialogBoxErrorCode.CFERR_NOFONTS"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "ChooseFont", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL ChooseFont(ref CHOOSEFONT FontData);
    }
}