namespace WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes
{
    /// <summary>
    /// Costanti comuni per le finestre di dialogo.
    /// </summary>
    internal static class CommonDialogBoxesCostants
    {
        /// <summary>
        /// Esclude i controlli di copia e di fascicolazione dalle pagine di proprietà del driver della stampante in una finestra di dialogo "Stampa".
        /// </summary>
        internal const DWORD PD_EXCL_COPIESANDCOLLATE = 256 | 32768;

        /// <summary>
        /// Identifica la pagina "Generale" della finestra di dialogo "Stampa".
        /// </summary>
        internal const DWORD START_PAGE_GENERAL = 4294967295;
    }
}