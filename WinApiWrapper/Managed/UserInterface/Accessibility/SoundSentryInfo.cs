using System.ComponentModel;
using System.Drawing;
using WinApiWrapper.UserInterface.Accessibility;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;
using static WinApiWrapper.Managed.UserInterface.Accessibility.Enumerations;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulla funzionalità SoundSentry.
    /// </summary>
    public class SoundSentryInfo
    {
        /// <summary>
        /// Indica se la funzionalità SoundSentry è disponibile.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Indica se la funzionalità SoundSentry è abilitata.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Segnale visuale da mostrare quando un'applicazione in modalità testo genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
        /// </summary>
        public SoundSentryTextEffect TextEffect { get; }

        /// <summary>
        /// Durata del segnale visuale indicato da <see cref="TextEffect"/>, in secondi.
        /// </summary>
        public int TextEffectDuration { get; }

        /// <summary>
        /// Colore del segnale visuale indicato da <see cref="TextEffect"/>.
        /// </summary>
        public Color TextEffectColor { get; }

        /// <summary>
        /// Segnale visuale da mostrare quando un'applicazione in modalità grafica genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
        /// </summary>
        public SoundSentryGrafEffect GrafEffect { get; }

        /// <summary>
        /// Durata del segnale visuale indicato da <see cref="GrafEffect"/>, in secondi.
        /// </summary>
        public int GrafEffectDuration { get; }

        /// <summary>
        /// Colore del segnale visuale indicato da <see cref="GrafEffect"/>.
        /// </summary>
        public Color GrafEffectColor { get; }

        /// <summary>
        /// Effetto da applicare alle finestre.
        /// </summary>
        public SoundSentryWindowsEffect WindowsEffect { get; }

        /// <summary>
        /// Durata dell'effetto applicato alle finestre, in secondi.
        /// </summary>
        public int WindowsEffectDuration { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="SoundSentryInfo"/>.
        /// </summary>
        public SoundSentryInfo()
        {
            SOUNDSENTRY SoundSentryData = new();
            SoundSentryData.Size = (uint)Marshal.SizeOf(typeof(SOUNDSENTRY));
            HMODULE SoundSentryDataStructurePointer = Marshal.AllocHGlobal((int)SoundSentryData.Size);
            Marshal.StructureToPtr(SoundSentryData, SoundSentryDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETSOUNDSENTRY, SoundSentryData.Size, SoundSentryDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                SoundSentryData = (SOUNDSENTRY)Marshal.PtrToStructure(SoundSentryDataStructurePointer, typeof(SOUNDSENTRY))!;
                IsAvailable = SoundSentryData.Flags.HasFlag(AccessibilityEnumerations.SoundSentryProperties.SSF_AVAILABLE);
                IsEnabled = SoundSentryData.Flags.HasFlag(AccessibilityEnumerations.SoundSentryProperties.SSF_SOUNDSENTRYON);
                TextEffect = (SoundSentryTextEffect)SoundSentryData.TextEffect;
                TextEffectDuration = (int)(SoundSentryData.TextEffectMilliseconds / 1000);
                TextEffectColor = ColorTranslator.FromWin32((int)SoundSentryData.TextEffectColorBits);
                GrafEffect = (SoundSentryGrafEffect)SoundSentryData.GrafEffect;
                GrafEffectDuration = (int)(SoundSentryData.GrafEffectMilliseconds / 1000);
                GrafEffectColor = ColorTranslator.FromWin32((int)SoundSentryData.GrafEffectColor);
                WindowsEffect = (SoundSentryWindowsEffect)SoundSentryData.WindowsEffect;
                WindowsEffectDuration = (int)(SoundSentryData.WindowsEffectMilliseconds / 1000);
                Marshal.FreeHGlobal(SoundSentryDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(SoundSentryDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="SoundSentryInfo"/>.
        /// </summary>
        /// <param name="Available">Indica se la funzionalità è disponibile.</param>
        /// <param name="Enabled">Indica se la funzionalità è abilitata.</param>
        /// <param name="WindowsEffect">Effetto da applicare alle finestre.</param>
        public SoundSentryInfo(bool Available, bool Enabled, SoundSentryWindowsEffect WindowsEffect)
        {
            IsAvailable = Available;
            IsEnabled = Enabled;
            this.WindowsEffect = WindowsEffect;
        }
    }
}