namespace WinApiWrapper.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Costanti MUI.
    /// </summary>
    internal static class MUIConstants
    {
        /// <summary>
        /// Costante usata dalla funzione <see cref="MUIFunctions.GetSystemPreferredUILanguages"/>.
        /// </summary>
        /// <remarks>Questa costante indica alla funzione di recuperare la lista dei linguaggi preferiti controllando solamente se ogni nome della lingua corrisponde a una località NLS valida.</remarks>
        internal const DWORD MUI_MACHINE_LANGUAGE_SETTINGS = 0x400;

        /// <summary>
        /// Versione della struttura <see cref="MUIStructures.FILEMUIINFO"/>.
        /// </summary>
        internal const DWORD MUI_FILEINFO_VERSION = 0x001;
    }
}