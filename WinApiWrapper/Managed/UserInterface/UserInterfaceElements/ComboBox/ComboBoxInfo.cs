using WinApiWrapper.Managed.General;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ComboBox.Enumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxStructures;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ComboBox
{
    /// <summary>
    /// Informazioni su un ComboBox.
    /// </summary>
    public class ComboBoxInfo : WindowInfo
    {
        /// <summary>
        /// Coordinate del box di modifica.
        /// </summary>
        public Rectangle? EditBoxCoordinates { get; }

        /// <summary>
        /// Coordinate del pulsante di dropdown.
        /// </summary>
        public Rectangle? DropDownButtonCoordinates { get; }

        /// <summary>
        /// Stato del pulsante di dropdown.
        /// </summary>
        public DropdownButtonState? DropdownButtonState { get; }

        /// <summary>
        /// Handle al box di modifica.
        /// </summary>
        internal IntPtr EditBoxHandle { get; }

        /// <summary>
        /// Handle alla lista di dropdown.
        /// </summary>
        internal IntPtr DropDownListHandle { get; }

        /// <summary>
        /// Stili applicati al ComboBox.
        /// </summary>
        public ComboboxStyles[]? ComboBoxStyles { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ComboBoxInfo"/>.
        /// </summary>
        /// <param name="Handle">Handle al ComboBox.</param>
        internal ComboBoxInfo(HWND Handle) : base(Handle)
        {
            IntPtr StyleValue = WindowsFunctions.GetWindowLongPtr(Handle, (int)WindowDataSpecialOffset.GWL_STYLE);
            if (StyleValue != IntPtr.Zero)
            {
                ComboboxStyles Styles = (ComboboxStyles)StyleValue.ToInt32();
                ComboBoxStyles = GetComboBoxStyles(Styles);
            }
            else
            {
                ComboBoxStyles = null;
            }
            COMBOBOXINFO Info = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(COMBOBOXINFO))
            };
            if (GetComboBoxInfo(Handle, ref Info))
            {
                EditBoxCoordinates = new(Info.EditBoxCoordinates);
                DropDownButtonCoordinates = new(Info.DropDownArrowCoordinates);
                DropdownButtonState = (DropdownButtonState)Info.State;
                EditBoxHandle = Info.EditBoxHandle;
                DropDownListHandle = Info.DropDownListHandle;
            }
            else
            {
                EditBoxCoordinates = null;
                DropDownButtonCoordinates = null;
                DropdownButtonState = null;
                EditBoxHandle = IntPtr.Zero;
                DropDownListHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Recupera gli stili del ComboBox.
        /// </summary>
        /// <param name="Styles">Valore composito che indica gli stili applicati al ComboBox.</param>
        /// <returns>Un array che contiene tutti gli stili applicati al ComboBox.</returns>
        private static ComboboxStyles[] GetComboBoxStyles(ComboboxStyles Styles)
        {
            List<ComboboxStyles> StylesList = new();
            foreach (ComboboxStyles style in Enum.GetValues(typeof(ComboboxStyles)))
            {
                if (Styles.HasFlag(style))
                {
                    StylesList.Add(style);
                }
            }
            return StylesList.ToArray();
        }
    }
}