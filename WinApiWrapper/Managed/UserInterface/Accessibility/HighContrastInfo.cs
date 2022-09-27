using System.ComponentModel;
using WinApiWrapper.UserInterface.Accessibility;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulla funzionalità Alto Contrasto.
    /// </summary>
    public class HighContrastInfo
    {
        /// <summary>
        /// Indica se l'alto contrasto è attivo.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Indica se l'alto contrasto è disponibile.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Indica se è possibile attivare o disattivare l'alto contrasto tramite hotkey.
        /// </summary>
        public bool IsHotkeyActive { get; }

        /// <summary>
        /// Indica se viene visualizzata una finestra di dialogo di conferma quando l'alto contrasto viene attivato tramite hotkey.
        /// </summary>
        public bool IsHotkeyConfirmationDialogEnabled { get; }

        /// <summary>
        /// Indica se il sistema emette un suono quando l'alto contrasto viene attivato o disattivato tramite hotkey.
        /// </summary>
        public bool IsHotkeySoundEnabled { get; }

        /// <summary>
        /// Indica se l'hotkey è disponibile.
        /// </summary>
        public bool IsHotkeyAvailable { get; }

        /// <summary>
        /// Indica se impedire l'invio di messagi di cambio tema.
        /// </summary>
        internal bool NoThemeChange { get; }

        /// <summary>
        /// Nome dello schema di colori impostato come default.
        /// </summary>
        public string DefaultSchemeName { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="HighContrastInfo"/>.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public HighContrastInfo()
        {
            HIGHCONTRAST HighContrastData = new();
            HighContrastData.Size = (uint)Marshal.SizeOf(typeof(HIGHCONTRAST));
            HMODULE HighContrastDataStructurePointer = Marshal.AllocHGlobal((int)HighContrastData.Size);
            Marshal.StructureToPtr(HighContrastData, HighContrastDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETHIGHCONTRAST, HighContrastData.Size, HighContrastDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                HighContrastData = (HIGHCONTRAST)Marshal.PtrToStructure(HighContrastDataStructurePointer, typeof(HIGHCONTRAST))!;
                IsEnabled = HighContrastData.Flags.HasFlag(AccessibilityEnumerations.HighContrastProperties.HCF_HIGHCONTRASTON);
                IsAvailable = HighContrastData.Flags.HasFlag(AccessibilityEnumerations.HighContrastProperties.HCF_AVAILABLE);
                IsHotkeyActive = HighContrastData.Flags.HasFlag(AccessibilityEnumerations.HighContrastProperties.HCF_HOTKEYACTIVE);
                IsHotkeyConfirmationDialogEnabled = HighContrastData.Flags.HasFlag(AccessibilityEnumerations.HighContrastProperties.HCF_CONFIRMHOTKEY);
                IsHotkeySoundEnabled = HighContrastData.Flags.HasFlag(AccessibilityEnumerations.HighContrastProperties.HCF_HOTKEYSOUND);
                IsHotkeyAvailable = HighContrastData.Flags.HasFlag(AccessibilityEnumerations.HighContrastProperties.HCF_HOTKEYAVAILABLE);
                DefaultSchemeName = string.IsNullOrWhiteSpace(HighContrastData.DefaultScheme) ? "Undefined" : HighContrastData.DefaultScheme;
                Marshal.FreeHGlobal(HighContrastDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(HighContrastDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="HighContrastInfo"/>.
        /// </summary>
        /// <param name="Enabled">Indica se la funzionalità è abilitata.</param>
        /// <param name="Available">Indica se la funzionalità è disponibile.</param>
        /// <param name="HotkeyActive">Indica se l'hotkey è attiva.</param>
        /// <param name="ConfirmationDialogEnabled">Indica se attivare tramite hotkey la funzionalità causerà la visualizzazione di una finestra di dialogo di conferma.</param>
        /// <param name="HotkeySoundEnabled">Indica se il sistema emette un suono quando la funzionalità è attivata o disattivata tramite hotkey.</param>
        /// <param name="NoThemeChange">Indica se impedire l'invio di messaggi di cambio tema.</param>
        /// <param name="DefaultSchemeName">Nome dello schema di colori che sarà impostato come predefinito.</param>
        /// <exception cref="ArgumentException"></exception>
        public HighContrastInfo(bool Enabled, bool Available, bool HotkeyActive, bool ConfirmationDialogEnabled, bool HotkeySoundEnabled, bool NoThemeChange, string DefaultSchemeName)
        {
            IsEnabled = Enabled;
            IsAvailable = Available;
            IsHotkeyActive = HotkeyActive;
            IsHotkeyConfirmationDialogEnabled = ConfirmationDialogEnabled;
            IsHotkeySoundEnabled = HotkeySoundEnabled;
            if (Enabled && NoThemeChange)
            {
                throw new ArgumentException(nameof(NoThemeChange) + " cannot be true if " + nameof(Enabled) + " is also true.", nameof(NoThemeChange));
            }
            else
            {
                this.NoThemeChange = NoThemeChange;
            }
            this.DefaultSchemeName = DefaultSchemeName;
        }
    }
}