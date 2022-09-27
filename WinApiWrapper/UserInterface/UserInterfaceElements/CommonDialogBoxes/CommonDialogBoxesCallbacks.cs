namespace WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes
{
    /// <summary>
    /// Callback comuni usati dalle finestre di dialogo.
    /// </summary>
    internal static class CommonDialogBoxesCallbacks
    {
        /// <summary>
        /// Delegato che riceve le notifiche per la procedura predefinita di una finestra di dialogo.
        /// </summary>
        /// <param name="DialogHandle">Handle alla finestra di dialogo.</param>
        /// <param name="Message">Messaggio ricevuto.</param>
        /// <param name="wParam">Informazioni addizionali relative al messaggio.</param>
        /// <param name="lParam">Informazioni addizionali relative al messaggio.</param>
        /// <returns>0 per permette alla procedura predefinita l'elaborazione del messaggio, diverso da 0 per fare in modo che la procedura predefinita ignori il messaggio.</returns>
        /// <remarks>Se il messaggio è <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_INITDIALOG"/>, lParam è un puntatore a una struttura <see cref="CommonDialogBoxesStructures.CHOOSECOLOR"/> oppure <see cref="CommonDialogBoxesStructures.CHOOSEFONT"/>.</remarks>
        internal delegate UINT_PTR NotificationHandlerProcedure(HWND DialogHandle, uint Message, WPARAM wParam, LPARAM lParam);
    }
}