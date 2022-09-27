namespace WinApiWrapper.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Costanti DWM.
    /// </summary>
    internal static class DWMConstants
    {
        /// <summary>
        /// La finestra è stata nascosta dal proprietario.
        /// </summary>
        internal const int DWM_CLOAKED_APP = 0x0000001;

        /// <summary>
        /// La finestra è stata nascosta dalla shell.
        /// </summary>
        internal const int DWM_CLOAKED_SHELL = 0x0000002;

        /// <summary>
        /// La finestra è stata nascosta in base al valore ereditato dalla finestra proprietaria.
        /// </summary>
        internal const int DWM_CLOAKED_INHERITED = 0x0000004;

        /// <summary>
        /// Indica a DWM di mostrare una cornice attorno al bitmap fornito.
        /// </summary>
        internal const DWORD DWM_SIT_DISPLAYFRAME = 0x00000001;
    }
}