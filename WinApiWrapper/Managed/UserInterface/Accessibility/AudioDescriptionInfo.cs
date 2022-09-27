using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;
using System.ComponentModel;
using System.Text;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulle descrizioni audio.
    /// </summary>
    public class AudioDescriptionInfo
    {
        /// <summary>
        /// Indica se le descrizioni audio sono attive.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Nome della località che le descrizioni audio utilizzano.
        /// </summary>
        public string? LocaleName { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="AudioDescriptionInfo"/>.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public AudioDescriptionInfo()
        {
            AUDIODESCRIPTION AudioDescriptionData = new();
            AudioDescriptionData.Size = (uint)Marshal.SizeOf(typeof(AUDIODESCRIPTION));
            HMODULE AudioDescriptionDataStructurePointer = Marshal.AllocHGlobal((int)AudioDescriptionData.Size);
            Marshal.StructureToPtr(AudioDescriptionData, AudioDescriptionDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETAUDIODESCRIPTION, AudioDescriptionData.Size, AudioDescriptionDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                AudioDescriptionData = (AUDIODESCRIPTION)Marshal.PtrToStructure(AudioDescriptionDataStructurePointer, typeof(AUDIODESCRIPTION))!;
                IsEnabled = AudioDescriptionData.Enabled;
                StringBuilder LocaleNameBuilder = new(LOCALE_NAME_MAX_LENGTH);
                if (LCIDToLocaleName(AudioDescriptionData.Locale, LocaleNameBuilder, LocaleNameBuilder.Capacity, 0) != 0)
                {
                    LocaleName = LocaleNameBuilder.ToString();
                }
                else
                {
                    LocaleName = "Unknown";
                }
                Marshal.FreeHGlobal(AudioDescriptionDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(AudioDescriptionDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="AudioDescriptionInfo"/>.
        /// </summary>
        /// <param name="Enabled">Indica se la funzionalità è attiva.</param>
        /// <param name="LocaleName">Nome della località che indica la lingua delle descrizioni audio.</param>
        public AudioDescriptionInfo(bool Enabled, string? LocaleName)
        {
            IsEnabled = Enabled;
            this.LocaleName = LocaleName;
        }
    }
}