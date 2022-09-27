using static WinApiWrapper.UserInterface.Accessibility.AccessibilityEnumerations;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;
using WinApiWrapper.Managed.UserInterface.Accessibility;

namespace WinApiWrapper.UserInterface.Accessibility
{
    /// <summary>
    /// Metodi di utilità per la gestione delle funzionalità di accessibilità del sistema.
    /// </summary>
    internal static class AccessibilityUtilitiesManaged
    {
        /// <summary>
        /// Costruisce il valore del campo <see cref="ACCESSTIMEOUT.Flags"/>.
        /// </summary>
        /// <param name="TimeoutInfo">Istanza di <see cref="AccessibilityTimeoutInfo"/> con le informazioni.</param>
        /// <returns>Valore di enumerazione composito che indica le impostazioni del timeout delle funzioni di accessibilità.</returns>
        internal static AccessTimeoutFlags BuildAccessibilityTimeoutFlags(AccessibilityTimeoutInfo TimeoutInfo)
        {
            AccessTimeoutFlags Flags = 0;
            if (TimeoutInfo.SirenEnabled)
            {
                Flags |= AccessTimeoutFlags.ATF_ONOFFFEEDBACK;
            }
            if (TimeoutInfo.IsEnabled)
            {
                Flags |= AccessTimeoutFlags.ATF_TIMEOUTON;
            }
            return Flags;
        }

        /// <summary>
        /// Costruisce il valore del campo <see cref="FILTERKEYS.Flags"/>.
        /// </summary>
        /// <param name="FilterKeysInfo">Istanza di <see cref="FilterKeysInfo"/> con le informazioni.</param>
        /// <returns>Valore di enumerazione composito che indica le impostazioni della funzionalità Filtro tasti.</returns>
        internal static FilterKeysProperties BuildFilterKeysFlags(FilterKeysInfo FilterKeysInfo)
        {
            FilterKeysProperties Flags = 0;
            if (FilterKeysInfo.IsAvailable)
            {
                Flags |= FilterKeysProperties.FKF_AVAILABLE;
            }
            if (FilterKeysInfo.ClickSoundEnabled)
            {
                Flags |= FilterKeysProperties.FKF_CLICKON;
            }
            if (FilterKeysInfo.HotkeyConfirmationDialogEnabled)
            {
                Flags |= FilterKeysProperties.FKF_CONFIRMHOTKEY;
            }
            if (FilterKeysInfo.IsEnabled)
            {
                Flags |= FilterKeysProperties.FKF_FILTERKEYSON;
            }
            if (FilterKeysInfo.IsHotkeyActive)
            {
                Flags |= FilterKeysProperties.FKF_HOTKEYACTIVE;
            }
            if (FilterKeysInfo.IsHotkeySoundEnabled)
            {
                Flags |= FilterKeysProperties.FKF_HOTKEYSOUND;
            }
            if (FilterKeysInfo.IsVisualIndicatorEnabled)
            {
                Flags |= FilterKeysProperties.FKF_INDICATOR;
            }
            return Flags;
        }

        /// <summary>
        /// Costruisce il valore del campo <see cref="HIGHCONTRAST.Flags"/>.
        /// </summary>
        /// <param name="HighContrastInfo">Istanza di <see cref="HighContrastInfo"/></param>.
        /// <returns>Valore di enumerazione composito che indica le impostazioni della funzionalità Alto contrasto.</returns>
        internal static HighContrastProperties BuildHighContrastFlags(HighContrastInfo HighContrastInfo)
        {
            HighContrastProperties Flags = 0;
            if (HighContrastInfo.IsEnabled)
            {
                Flags |= HighContrastProperties.HCF_HIGHCONTRASTON;
            }
            if (HighContrastInfo.IsAvailable)
            {
                Flags |= HighContrastProperties.HCF_AVAILABLE;
            }
            if (HighContrastInfo.IsHotkeyActive)
            {
                Flags |= HighContrastProperties.HCF_HOTKEYACTIVE;
            }
            if (HighContrastInfo.IsHotkeyConfirmationDialogEnabled)
            {
                Flags |= HighContrastProperties.HCF_CONFIRMHOTKEY;
            }
            if (HighContrastInfo.IsHotkeySoundEnabled)
            {
                Flags |= HighContrastProperties.HCF_HOTKEYSOUND;
            }
            if (HighContrastInfo.IsHotkeyAvailable)
            {
                Flags |= HighContrastProperties.HCF_HOTKEYAVAILABLE;
            }
            if (HighContrastInfo.NoThemeChange)
            {
                Flags |= HighContrastProperties.HCF_OPTION_NOTHEMECHANGE;
            }
            return Flags;
        }

        /// <summary>
        /// Costruisce il valore del campo <see cref="MOUSEKEYS.Flags"/>.
        /// </summary>
        /// <param name="MouseKeysInfo">Istanza di <see cref="MouseKeysInfo"/></param>.
        /// <returns>Valore di enumerazione composito che indica le impostazioni della funzionalità MouseKeys.</returns>
        internal static MouseKeysProperties BuildMouseKeysFlags(MouseKeysInfo MouseKeysInfo)
        {
            MouseKeysProperties Flags = 0;
            if (MouseKeysInfo.IsMouseKeysAvailable)
            {
                Flags |= MouseKeysProperties.MKF_AVAILABLE;
            }
            if (MouseKeysInfo.IsConfirmationDialogBoxEnabled)
            {
                Flags |= MouseKeysProperties.MKF_CONFIRMHOTKEY;
            }
            if (MouseKeysInfo.IsHotkeyActive)
            {
                Flags |= MouseKeysProperties.MKF_HOTKEYACTIVE;
            }
            if (MouseKeysInfo.IsHotkeySoundEnabled)
            {
                Flags |= MouseKeysProperties.MKF_HOTKEYSOUND;
            }
            if (MouseKeysInfo.IsVisualIndicatorEnabled)
            {
                Flags |= MouseKeysProperties.MKF_INDICATOR;
            }
            if (MouseKeysInfo.ModifierKeysAlterCursorBehaviour)
            {
                Flags |= MouseKeysProperties.MKF_MODIFIERS;
            }
            if (MouseKeysInfo.IsMouseKeysEnabled)
            {
                Flags |= MouseKeysProperties.MKF_MOUSEKEYSON;
            }
            if (MouseKeysInfo.ReplaceNumbers)
            {
                Flags |= MouseKeysProperties.MKF_REPLACENUMBERS;
            }
            return Flags;
        }

        /// <summary>
        /// Costruisce il valore del campo <see cref="SOUNDSENTRY.Flags"/>.
        /// </summary>
        /// <param name="SoundSentryInfo">Istanza di <see cref="SoundSentryInfo"/></param>.
        /// <returns>Valore di enumerazione composito che indica le impostazioni della funzionalità SoundSentry.</returns>
        internal static SoundSentryProperties BuildSoundSentryFlags(SoundSentryInfo SoundSentryInfo)
        {
            SoundSentryProperties Flags = 0;
            if (SoundSentryInfo.IsAvailable)
            {
                Flags |= SoundSentryProperties.SSF_AVAILABLE;
            }
            if (SoundSentryInfo.IsEnabled)
            {
                Flags |= SoundSentryProperties.SSF_SOUNDSENTRYON;
            }
            return Flags;
        }

        /// <summary>
        /// Costruisce il valore del campo <see cref="STICKYKEYS.Flags"/>.
        /// </summary>
        /// <param name="StickyKeysInfo">Istanza di <see cref="StickyKeysInfo"/></param>.
        /// <returns>Valore di enumerazione composito che indica le impostazioni della funzionalità Tasti permanenti.</returns>
        internal static StickyKeysProperties BuildStickyKeysFlags(StickyKeysInfo StickyKeysInfo)
        {
            StickyKeysProperties Flags = 0;
            if (StickyKeysInfo.IsAudibleFeedbackEnabled)
            {
                Flags |= StickyKeysProperties.SFK_AUDIBLEFEEDBACK;
            }
            if (StickyKeysInfo.IsAvailable)
            {
                Flags |= StickyKeysProperties.SKF_AVAILABLE;
            }
            if (StickyKeysInfo.IsConfirmationDialogEnabled)
            {
                Flags |= StickyKeysProperties.SKF_CONFIRMHOTKEY;
            }
            if (StickyKeysInfo.IsHotkeyActive)
            {
                Flags |= StickyKeysProperties.SKF_HOTKEYACTIVE;
            }
            if (StickyKeysInfo.IsSoundEnabled)
            {
                Flags |= StickyKeysProperties.SKF_HOTKEYSOUND;
            }
            if (StickyKeysInfo.IsVisualIndicatorEnabled)
            {
                Flags |= StickyKeysProperties.SKF_INDICATOR;
            }
            if (StickyKeysInfo.IsEnabled)
            {
                Flags |= StickyKeysProperties.SKF_STICKYKEYSON;
            }
            if (StickyKeysInfo.DoubleModifierKeyPressLock)
            {
                Flags |= StickyKeysProperties.SKF_TRISTATE;
            }
            if (StickyKeysInfo.ModifierKeyReleaseDisable)
            {
                Flags |= StickyKeysProperties.SKF_TWOKEYSOFF;
            }
            return Flags;
        }

        /// <summary>
        /// Costruisce il valore del campo <see cref="TOGGLEKEYS.Flags"/>.
        /// </summary>
        /// <param name="ToggleKeysInfo">Istanza di <see cref="ToggleKeysInfo"/></param>.
        /// <returns>Valore di enumerazione composito che indica le impostazioni della funzionalità ToggleKeys.</returns>
        internal static ToggleKeysProperties BuildToggleKeysFlags(ToggleKeysInfo ToggleKeysInfo)
        {
            ToggleKeysProperties Flags = 0;
            if (ToggleKeysInfo.IsAvailable)
            {
                Flags |= ToggleKeysProperties.TKF_AVAILABLE;
            }
            if (ToggleKeysInfo.IsConfirmationDialogEnabled)
            {
                Flags |= ToggleKeysProperties.TKF_CONFIRMHOTKEY;
            }
            if (ToggleKeysInfo.IsHotkeyActive)
            {
                Flags |= ToggleKeysProperties.TKF_HOTKEYACTIVE;
            }
            if (ToggleKeysInfo.IsHotkeySoundEnabled)
            {
                Flags |= ToggleKeysProperties.TKF_HOTKEYSOUND;
            }
            if (ToggleKeysInfo.IsEnabled)
            {
                Flags |= ToggleKeysProperties.TKF_TOGGLEKEYSON;
            }
            return Flags;
        }
    }
}