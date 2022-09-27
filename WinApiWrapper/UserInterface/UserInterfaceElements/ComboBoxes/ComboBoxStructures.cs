using static WinApiWrapper.General.GeneralStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes
{
    /// <summary>
    /// Strutture relative ai ComboBox.
    /// </summary>
    internal static class ComboBoxStructures
    {
        /// <summary>
        /// Informazioni di stato per un ComboBox.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct COMBOBOXINFO
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            /// <remarks>Questo campo deve essere impostato dall'applicazione.</remarks>
            public DWORD Size;
            /// <summary>
            /// Coordinate del zona di modifica.
            /// </summary>
            public RECT EditBoxCoordinates;
            /// <summary>
            /// Coordinate della freccia del drop-down.
            /// </summary>
            public RECT DropDownArrowCoordinates;
            /// <summary>
            /// Stato del pulsante del ComboBox.
            /// </summary>
            public ComboBoxEnumerations.ComboBoxButtonState State;
            /// <summary>
            /// Handle al ComboBox.
            /// </summary>
            public HWND ComboBoxHandle;
            /// <summary>
            /// Handle alla zona di modifica.
            /// </summary>
            public HWND EditBoxHandle;
            /// <summary>
            /// Handle al dropdown.
            /// </summary>
            public HWND DropDownListHandle;
        }
    }
}