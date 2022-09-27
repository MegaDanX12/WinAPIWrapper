namespace WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes
{
    /// <summary>
    /// Costanti usati dai ComboBox.
    /// </summary>
    internal static class ComboBoxConstants
    {
        /// <summary>
        /// Operazione riuscita.
        /// </summary>
        internal static IntPtr CB_OKAY = IntPtr.Zero;

        /// <summary>
        /// Si è verificato un errore.
        /// </summary>
        internal static IntPtr CB_ERR = new(-1);

        /// <summary>
        /// Spazio insufficiente.
        /// </summary>
        internal static IntPtr CB_ERRSPACE = new(-2);

        /// <summary>
        /// Valore iniziale per i messaggi relativi ai ComboBox;
        /// </summary>
        internal const int CBM_FIRST = 5888;
    }
}
