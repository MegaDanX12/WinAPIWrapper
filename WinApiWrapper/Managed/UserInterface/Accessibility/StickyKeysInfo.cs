using System.ComponentModel;
using WinApiWrapper.UserInterface.Accessibility;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulla funzionalità Tasti permanenti.
    /// </summary>
    public class StickyKeysInfo
    {
        /// <summary>
        /// Indica se il sistema emette un suono quando l'utente aggancia, blocca o rilascia i tasti modificatori.
        /// </summary>
        public bool IsAudibleFeedbackEnabled { get; }

        /// <summary>
        /// Indica se Tasti permanenti è disponibile.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Indica se il sistema visualizza una finestra di dialogo di conferma quando Tasti permanenti viene attivato usando l'hotkey.
        /// </summary>
        public bool IsConfirmationDialogEnabled { get; }

        /// <summary>
        /// Indica se l'hotkey è attiva.
        /// </summary>
        public bool IsHotkeyActive { get; }

        /// <summary>
        /// Indica se il sistema emette un suono quando l'utente attiva o disattiva Tasti permanenti usando l'hotkey.
        /// </summary>
        public bool IsSoundEnabled { get; }

        /// <summary>
        /// Indica se l'indicatore visuale è attivo.
        /// </summary>
        public bool IsVisualIndicatorEnabled { get; }

        /// <summary>
        /// Indica se Tasti permanenti è abilitato.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Indica se premere un tasto modificatore due volte di fila blocca quest'ultimo fino a che l'utente non lo preme una terza volta.
        /// </summary>
        public bool DoubleModifierKeyPressLock { get; }

        /// <summary>
        /// Indica se rilasciare un tasto modificatore premuto insieme a qualunque altro tasto disattiva Tasti permanenti.
        /// </summary>
        public bool ModifierKeyReleaseDisable { get; }

        /// <summary>
        /// Indica se il tasto ALT sinistro è agganciato.
        /// </summary>
        public bool IsLeftAltLatched { get; }

        /// <summary>
        /// Indica se il tasto CTRL sinistro è agganciato.
        /// </summary>
        public bool IsLeftCtrlLatched { get; }

        /// <summary>
        /// Indica se il tasto SHIFT sinistro è agganciato.
        /// </summary>
        public bool IsLeftShiftLatched { get; }

        /// <summary>
        /// Indica se il tasto ALT destro è agganciato.
        /// </summary>
        public bool IsRightAltLatched { get; }

        /// <summary>
        /// Indica se il tasto CTRL destro è agganciato.
        /// </summary>
        public bool IsRightCtrlLatched { get; }

        /// <summary>
        /// Indica se il tasto SHIFT destro è agganciato.
        /// </summary>
        public bool IsRightShiftLatched { get; }

        /// <summary>
        /// Indica se il tasto ALT sinistro è bloccato.
        /// </summary>
        public bool IsLeftAltLocked { get; }

        /// <summary>
        /// Indica se il tasto CTRL sinistro è bloccato.
        /// </summary>
        public bool IsLeftCtrlLocked { get; }

        /// <summary>
        /// Indica se il tasto sinistro SHIFT è bloccato.
        /// </summary>
        public bool IsLeftShiftLocked { get; }

        /// <summary>
        /// Indica se il tasto ALT destro è bloccato.
        /// </summary>
        public bool IsRightAltLocked { get; }

        /// <summary>
        /// Indica se il tasto CTRL destro è bloccato.
        /// </summary>
        public bool IsRightCtrlLocked { get; }

        /// <summary>
        /// Indica se il tasto SHIFT destro è bloccato.
        /// </summary>
        public bool IsRightShiftLocked { get; }

        /// <summary>
        /// Indica se il tasto Windows sinistro è agganciato.
        /// </summary>
        public bool IsLeftWindowsKeyLatched { get; }

        /// <summary>
        /// Indica se il tasto Windows destro è agganciato.
        /// </summary>
        public bool IsRightWindowsKeyLatched { get; }

        /// <summary>
        /// Indica se il tasto Windows sinistro è bloccato.
        /// </summary>
        public bool IsLeftWindowsKeyLocked { get; }

        /// <summary>
        /// Indica se il tasto Windows destro è bloccato.
        /// </summary>
        public bool IsRightWindowsKeyLocked { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="StickyKeysInfo"/>.
        /// </summary>
        public StickyKeysInfo()
        {
            STICKYKEYS StickyKeysData = new();
            StickyKeysData.Size = (uint)Marshal.SizeOf(typeof(STICKYKEYS));
            HMODULE StickyKeysDataStructurePointer = Marshal.AllocHGlobal((int)StickyKeysData.Size);
            Marshal.StructureToPtr(StickyKeysData, StickyKeysDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETSTICKYKEYS, StickyKeysData.Size, StickyKeysDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                StickyKeysData = (STICKYKEYS)Marshal.PtrToStructure(StickyKeysDataStructurePointer, typeof(STICKYKEYS))!;
                IsAudibleFeedbackEnabled = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SFK_AUDIBLEFEEDBACK);
                IsAvailable = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_AVAILABLE);
                IsConfirmationDialogEnabled = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_CONFIRMHOTKEY);
                IsHotkeyActive = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_HOTKEYACTIVE);
                IsSoundEnabled = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_HOTKEYSOUND);
                IsVisualIndicatorEnabled = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_INDICATOR);
                IsEnabled = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_STICKYKEYSON);
                DoubleModifierKeyPressLock = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_TRISTATE);
                ModifierKeyReleaseDisable = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_TWOKEYSOFF);
                IsLeftAltLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LALTLATCHED);
                IsLeftCtrlLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LCTLLATCHED);
                IsLeftShiftLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LSHIFTLATCHED);
                IsRightAltLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RALTLATCHED);
                IsRightCtrlLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RCTLLATCHED);
                IsRightShiftLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RSHIFTLATCHED);
                IsLeftAltLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SFK_LALTLOCKED);
                IsLeftCtrlLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LCTLLOCKED);
                IsLeftShiftLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LSHIFTLOCKED);
                IsRightAltLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RALTLOCKED);
                IsRightCtrlLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RCTLLOCKED);
                IsRightShiftLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RSHIFTLOCKED);
                IsLeftWindowsKeyLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LWINLATCHED);
                IsLeftWindowsKeyLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_LWINLOCKED);
                IsRightWindowsKeyLatched = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RWINLATCHED);
                IsRightWindowsKeyLocked = StickyKeysData.Flags.HasFlag(AccessibilityEnumerations.StickyKeysProperties.SKF_RWINLOCKED);
                Marshal.FreeHGlobal(StickyKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(StickyKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="StickyKeysInfo"/>.
        /// </summary>
        /// <param name="AudibleFeedbackEnabled">Indica se il sistema emette un suono quando l'utente aggancia, blocca o rilascia i tasti modificatori.</param>
        /// <param name="Available">Indica se la funzionalità è disponibile.</param>
        /// <param name="ConfirmationDialogEnabled">Indica se il sistema visualizza una finestra di dialogo di conferma quando Tasti permanenti viene attivato usando l'hotkey.</param>
        /// <param name="HotkeyActive">Indica se l'hotkey è attiva.</param>
        /// <param name="HotkeySoundEnabled">Indica se il sistema emette un suono quando l'utente attiva o disattiva Tasti permanenti usando l'hotkey.</param>
        /// <param name="VisualIndicatorEnabled">Indica se il sistema emette un suono quando l'utente attiva o disattiva Tasti permanenti usando l'hotkey.</param>
        /// <param name="Enabled">Indica se la funzionalità è abilitata.</param>
        /// <param name="DoubleModifierKeyPressLock">Indica se premere un tasto modificatore due volte di fila blocca quest'ultimo fino a che l'utente non lo preme una terza volta.</param>
        /// <param name="ModifierKeyReleaseDisable">Indica se rilasciare un tasto modificatore premuto insieme a qualunque altro tasto disattiva la funzionalità.</param>
        public StickyKeysInfo(bool AudibleFeedbackEnabled, bool Available, bool ConfirmationDialogEnabled, bool HotkeyActive, bool HotkeySoundEnabled, bool VisualIndicatorEnabled, bool Enabled, bool DoubleModifierKeyPressLock, bool ModifierKeyReleaseDisable)
        {
            IsAudibleFeedbackEnabled = AudibleFeedbackEnabled;
            IsAvailable = Available;
            IsConfirmationDialogEnabled = ConfirmationDialogEnabled;
            IsHotkeyActive = HotkeyActive;
            IsSoundEnabled = HotkeySoundEnabled;
            IsVisualIndicatorEnabled = VisualIndicatorEnabled;
            IsEnabled = Enabled;
            this.DoubleModifierKeyPressLock = DoubleModifierKeyPressLock;
            this.ModifierKeyReleaseDisable = ModifierKeyReleaseDisable;
        }
    }
}