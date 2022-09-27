using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Funzioni relative ai pulsanti.
    /// </summary>
    internal static class ButtonFunctions
    {
        /// <summary>
        /// Cambia lo stato di un pulsante.
        /// </summary>
        /// <param name="DialogHandle">Handle alla finestra di dialogo.</param>
        /// <param name="ButtonID">ID del bottone.</param>
        /// <param name="State">Stato del pulsante.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Questa funzione invia il messaggio <see cref="ButtonMessages.BM_SETCHECK"/> al pulsante specificato nella finestra di dialogo specificata.</remarks>
        [DllImport("User32.dll", EntryPoint = "CheckDlgButton", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ChangeButtonState(HWND DialogHandle, int ButtonID, ButtonState State);

        /// <summary>
        /// Attiva un radio button in un gruppo e disattiva tutti gli altri nello stesso gruppo.
        /// </summary>
        /// <param name="DialogHandle">Handle alla finestra di dialogo.</param>
        /// <param name="FirstRadioButtonID">ID del primo radio button nel gruppo.</param>
        /// <param name="LastRadioButtonID">ID dell'ultimo radio button nel gruppo.</param>
        /// <param name="RadioButtonID">ID del radio button da attivare.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Questa funzione invia il messaggio <see cref="ButtonMessages.BM_SETCHECK"/> a ogni radio button nel gruppo.<br/><br/>
        /// <paramref name="FirstRadioButtonID"/> e <paramref name="LastRadioButtonID"/> specificano un gruppo di ID, la posizione dei pulsanti nell'ordine di selezione (tab order) è irrilevante.<br/>
        /// Se il pulsante fa parte di un gruppo ma il suo ID è fuori dal gruppo di valori indicato, la chiamata a questa funzione non ha effetto su di esso.</remarks>
        [DllImport("User32.dll", EntryPoint = "CheckRadioButton", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CheckRadioButton(HWND DialogHandle, int FirstRadioButtonID, int LastRadioButtonID, int RadioButtonID);

        /// <summary>
        /// Determina se il pulsante a cui corrisponde l'ID è attivo, in stato indeterminato o non attivo.
        /// </summary>
        /// <param name="DialogHandle">Handle alla finestra di dialogo.</param>
        /// <param name="ButtonID">ID del pulsante.</param>
        /// <returns>Uno dei segunti valori dell'enumerazione <see cref="ButtonState"/>:<br/><br/>
        /// <see cref="ButtonState.BST_CHECKED"/><br/>
        /// <see cref="ButtonState.BST_INDETERMINATE"/><br/>
        /// <see cref="ButtonState.BST_UNCHECKED"/><br/><br/>
        /// Viene restituito uno dei valore precedenti solo se il pulsante ha uno dei seguenti stili:<br/><br/>
        /// <see cref="ButtonStyles.BS_AUTOCHECKBOX"/><br/>
        /// <see cref="ButtonStyles.BS_AUTORADIOBUTTON"/><br/>
        /// <see cref="ButtonStyles.BS_AUTO3STATE"/><br/>
        /// <see cref="ButtonStyles.BS_CHECKBOX"/><br/>
        /// <see cref="ButtonStyles.BS_RADIOBUTTON"/><br/>
        /// <see cref="ButtonStyles.BS_3STATE"/><br/><br/>
        /// Se il pulsante non ha nessuno degli stili indicati il valore restituito è 0.</returns>
        /// <remarks>Questa funzione invia il messaggio <see cref="ButtonMessages.BM_SETCHECK"/> al pulsante specificato.</remarks>
        [DllImport("User32.dll", EntryPoint = "IsDlgButtonChecked", SetLastError = true)]
        internal static extern ButtonState IsButtonChecked(HWND DialogHandle, int ButtonID);
    }
}