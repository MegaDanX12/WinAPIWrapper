using System.ComponentModel;
using WinApiWrapper.UserInterface.Accessibility;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulla funzionalità Filtro tasti.
    /// </summary>
    public class FilterKeysInfo
    {
        /// <summary>
        /// Indica se Filtro tasti è disponibile.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Indica se il computer emetterà un suono quando il tasto è premuto o accettato.
        /// </summary>
        public bool ClickSoundEnabled { get; }

        /// <summary>
        /// Indica se viene mostrata una finestra di dialogo di conferma quando Filtro tasti viene attivata tramite hotkey.
        /// </summary>
        public bool HotkeyConfirmationDialogEnabled { get; }

        /// <summary>
        /// Indica se Filtro tasti è abilitato.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Indica se l'hotkey è attiva.
        /// </summary>
        public bool IsHotkeyActive { get; }

        /// <summary>
        /// Indica se il computer emette un suono quando Filtro tasti viene attivato e disattivato tramite hotkey.
        /// </summary>
        public bool IsHotkeySoundEnabled { get; }

        /// <summary>
        /// Indica se viene visualizzato un indicatore visuale quando Filtro tasti è abilitato.
        /// </summary>
        public bool IsVisualIndicatorEnabled { get; }

        /// <summary>
        /// Tempo, in secondi, che l'utente deve tenere premuto il tasto prima che sia accettato dal computer.
        /// </summary>
        public int KeyAcceptWait { get; }

        /// <summary>
        /// Tempo, in secondi, che l'utente deve tenere premuto il tasto prima che inizi a ripetersi.
        /// </summary>
        public int KeyRepeatDelay { get; }

        /// <summary>
        /// Tempo, in secondi, tra la ripetizione della pressione del tasto.
        /// </summary>
        public int KeyRepeatTime { get; }

        /// <summary>
        /// Tempo, in secondi, che deve passare dal rilascio di un tasto prima che il computer accetti una nuova pressione dello stesso tasto.
        /// </summary>
        public int KeyBounceTime { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="FilterKeysInfo"/>.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public FilterKeysInfo()
        {
            FILTERKEYS FilteryKeysData = new();
            FilteryKeysData.Size = (uint)Marshal.SizeOf(typeof(FILTERKEYS));
            HMODULE FilterKeysDataStructurePointer = Marshal.AllocHGlobal((int)FilteryKeysData.Size);
            Marshal.StructureToPtr(FilteryKeysData, FilterKeysDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETFILTERKEYS, FilteryKeysData.Size, FilterKeysDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                FilteryKeysData = (FILTERKEYS)Marshal.PtrToStructure(FilterKeysDataStructurePointer, typeof(FILTERKEYS))!;
                IsAvailable = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_AVAILABLE);
                ClickSoundEnabled = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_CLICKON);
                HotkeyConfirmationDialogEnabled = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_CONFIRMHOTKEY);
                IsEnabled = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_FILTERKEYSON);
                IsHotkeyActive = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_HOTKEYACTIVE);
                IsHotkeySoundEnabled = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_HOTKEYSOUND);
                IsVisualIndicatorEnabled = FilteryKeysData.Flags.HasFlag(AccessibilityEnumerations.FilterKeysProperties.FKF_INDICATOR);
                KeyAcceptWait = (int)(FilteryKeysData.WaitMilliseconds / 1000);
                KeyRepeatDelay = (int)(FilteryKeysData.DelayMilliseconds / 1000);
                KeyRepeatTime = (int)(FilteryKeysData.RepeatMilliseconds / 1000);
                KeyBounceTime = (int)(FilteryKeysData.BounceMilliseconds / 1000);
                Marshal.FreeHGlobal(FilterKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(FilterKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="FilterKeysInfo"/>.
        /// </summary>
        /// <param name="Available">Indica se la funzionalità è disponibile.</param>
        /// <param name="ClickSoundEnabled">Indica se il computer emetterà un suono alla pressione e all'accettazione di un tasto.</param>
        /// <param name="ConfirmationDialogEnabled">Indica se verrà visualizzata una finestra di dialogo di conferma dopo l'attivazione della funzionalità tramite hotkey.</param>
        /// <param name="Active">Indica se la funzionalità è attiva.</param>
        /// <param name="HotkeyActive">Indica se la hotkey è attiva.</param>
        /// <param name="HotkeySoundEnabled">Indica se il computer emetterà un suono quando la funzionalità viene attivata o disattivata tramite hotkey.</param>
        /// <param name="VisualIndicatorEnabled"></param>
        /// <param name="WaitTime">Tempo di attesa, in secondi, prima che il computer accetti la pressione di un tasto.</param>
        /// <param name="DelayTime">Tempo, in secondi, durante il quale l'utente deve tenere premuto il tasto prima che inizi a ripetersi.</param>
        /// <param name="RepeatTime">Tempo, in secondi, che deve passare tra le ripetizione di un tasto.</param>
        /// <param name="BounceTime">Tempo, in secondi, che deve passare dopo il rilascio di un tasto prima che il computer accetti un'altra pressione dello stesso.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public FilterKeysInfo(bool Available, bool ClickSoundEnabled, bool ConfirmationDialogEnabled, bool Active, bool HotkeyActive, bool HotkeySoundEnabled, bool VisualIndicatorEnabled, int WaitTime, int DelayTime, int RepeatTime, int BounceTime)
        {
            IsAvailable = Available;
            this.ClickSoundEnabled = ClickSoundEnabled;
            HotkeyConfirmationDialogEnabled = ConfirmationDialogEnabled;
            IsEnabled = Active;
            IsHotkeyActive = HotkeyActive;
            IsHotkeySoundEnabled = HotkeySoundEnabled;
            IsVisualIndicatorEnabled = VisualIndicatorEnabled;
            if (WaitTime < 0 || DelayTime < 0 || RepeatTime < 0 || BounceTime < 0)
            {
                throw new ArgumentException("The parameters " + nameof(WaitTime) + ", " + nameof(DelayTime) + ", " + nameof(RepeatTime) + ", " + nameof(BounceTime) + " cannot be negative.");
            }
            else if (WaitTime > 20 || DelayTime > 20 || RepeatTime > 20 || BounceTime > 20)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "The maximum value for the parameters " + nameof(WaitTime) + ", " + nameof(DelayTime) + ", " + nameof(RepeatTime) + ", " + nameof(BounceTime) + " cannot be higher than 20.");
            }
            else
            {
                if (BounceTime > 0)
                {
                    if (WaitTime > 0 || DelayTime > 0 || RepeatTime > 0)
                    {
                        throw new ArgumentException("When the parameter " + nameof(BounceTime) + " is higher then zero, all other parameters must be zero.");
                    }
                    else
                    {
                        KeyBounceTime = BounceTime;
                        KeyAcceptWait = 0;
                        KeyRepeatDelay = 0;
                        KeyRepeatTime = 0;
                    }
                }
                else
                {
                    if (WaitTime is 0 && DelayTime is 0 && RepeatTime is 0)
                    {
                        throw new ArgumentException("When the parameter " + nameof(BounceTime) + " is zero, all other parameters must be nonzero.");
                    }
                    else
                    {
                        KeyBounceTime = 0;
                        KeyAcceptWait = WaitTime;
                        KeyRepeatDelay = DelayTime;
                        KeyRepeatTime = RepeatTime;
                    }
                }
            }
        }
    }
}