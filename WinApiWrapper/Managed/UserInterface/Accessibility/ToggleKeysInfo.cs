using System.ComponentModel;
using WinApiWrapper.UserInterface.Accessibility;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulla funzionalità ToggleKeys.
    /// </summary>
    public class ToggleKeysInfo
    {
        /// <summary>
        /// Indica se ToggleKeys è disponibile.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Indica se attivare ToggleKeys tramite hotkey causa la visualizzazione di una finestra di dialogo di conferma.
        /// </summary>
        public bool IsConfirmationDialogEnabled { get; }

        /// <summary>
        /// Indica se l'hotkey è attiva.
        /// </summary>
        public bool IsHotkeyActive { get; }

        /// <summary>
        /// Indica se il sistema emette un suono quando l'utente attiva o disattiva la funzionalità ToggleKeys tramite hotkey.
        /// </summary>
        public bool IsHotkeySoundEnabled { get; }

        /// <summary>
        /// Indica se la funzionalità ToggleKeys è attiva.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ToggleKeysInfo"/>.
        /// </summary>
        public ToggleKeysInfo()
        {
            TOGGLEKEYS ToggleKeysData = new();
            ToggleKeysData.Size = (uint)Marshal.SizeOf(typeof(TOGGLEKEYS));
            HMODULE ToggleKeysDataStructurePointer = Marshal.AllocHGlobal((int)ToggleKeysData.Size);
            Marshal.StructureToPtr(ToggleKeysData, ToggleKeysDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETTOGGLEKEYS, ToggleKeysData.Size, ToggleKeysDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                ToggleKeysData = (TOGGLEKEYS)Marshal.PtrToStructure(ToggleKeysDataStructurePointer, typeof(TOGGLEKEYS))!;
                IsAvailable = ToggleKeysData.Flags.HasFlag(AccessibilityEnumerations.ToggleKeysProperties.TKF_AVAILABLE);
                IsConfirmationDialogEnabled = ToggleKeysData.Flags.HasFlag(AccessibilityEnumerations.ToggleKeysProperties.TKF_CONFIRMHOTKEY);
                IsHotkeyActive = ToggleKeysData.Flags.HasFlag(AccessibilityEnumerations.ToggleKeysProperties.TKF_HOTKEYACTIVE);
                IsHotkeySoundEnabled = ToggleKeysData.Flags.HasFlag(AccessibilityEnumerations.ToggleKeysProperties.TKF_HOTKEYSOUND);
                IsEnabled = ToggleKeysData.Flags.HasFlag(AccessibilityEnumerations.ToggleKeysProperties.TKF_TOGGLEKEYSON);
                Marshal.FreeHGlobal(ToggleKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(ToggleKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ToggleKeysInfo"/>.
        /// </summary>
        /// <param name="Available">Indica se la funzionalità è disponibilità.</param>
        /// <param name="ConfirmationDialogEnabled">Indica se attivare la funzionalità tramite hotkey causa la visualizzazione di una finestra di dialogo di conferma.</param>
        /// <param name="HotkeyActive">Indica se l'hotkey è attiva.</param>
        /// <param name="HotkeySoundEnabled">Indica se il sistema emette un suono quando l'utente attiva o disattiva la funzionalità ToggleKeys tramite hotkey.</param>
        /// <param name="Enabled">Indica se la funzionalità è attiva.</param>
        public ToggleKeysInfo(bool Available, bool ConfirmationDialogEnabled, bool HotkeyActive, bool HotkeySoundEnabled, bool Enabled)
        {
            IsAvailable = Available;
            IsConfirmationDialogEnabled = ConfirmationDialogEnabled;
            IsHotkeyActive = HotkeyActive;
            IsHotkeySoundEnabled = HotkeySoundEnabled;
            IsEnabled = Enabled;
        }
    }
}