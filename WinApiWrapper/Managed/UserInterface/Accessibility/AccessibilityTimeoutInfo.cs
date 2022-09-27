using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using System.ComponentModel;
using WinApiWrapper.UserInterface.Accessibility;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sul timeout delle funzionalità di accessibilità.
    /// </summary>
    public class AccessibilityTimeoutInfo
    {
        /// <summary>
        /// Indica se il sistema emette un suono allo scadere del timeout.
        /// </summary>
        public bool SirenEnabled { get; }

        /// <summary>
        /// Indica se il timeout è attivo.
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Tempo di timeout, in secondi.
        /// </summary>
        public int Timeout { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="AccessibilityTimeoutInfo"/>.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public AccessibilityTimeoutInfo()
        {
            ACCESSTIMEOUT TimeoutData = new();
            TimeoutData.Size = (uint)Marshal.SizeOf(typeof(ACCESSTIMEOUT));
            HMODULE TimeoutDataStructurePointer = Marshal.AllocHGlobal((int)TimeoutData.Size);
            Marshal.StructureToPtr(TimeoutData, TimeoutDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETACCESSTIMEOUT, TimeoutData.Size, TimeoutDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                TimeoutData = (ACCESSTIMEOUT)Marshal.PtrToStructure(TimeoutDataStructurePointer, typeof(ACCESSTIMEOUT))!;
                Timeout = (int)TimeoutData.Timeout / 1000;
                IsEnabled = TimeoutData.Flags.HasFlag(AccessibilityEnumerations.AccessTimeoutFlags.ATF_TIMEOUTON);
                SirenEnabled = TimeoutData.Flags.HasFlag(AccessibilityEnumerations.AccessTimeoutFlags.ATF_ONOFFFEEDBACK);
                Marshal.FreeHGlobal(TimeoutDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(TimeoutDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="AccessibilityTimeoutInfo"/>.
        /// </summary>
        /// <param name="Timeout">Tempo di timeout, in secondi.</param>
        /// <param name="Enabled">Indica se il timeout è attivo.</param>
        /// <param name="SirenEnabled">Indica se il sistema deve emettere un suono allo scadere del timeout.</param>
        public AccessibilityTimeoutInfo(int Timeout, bool Enabled, bool SirenEnabled)
        {
            this.Timeout = Timeout;
            IsEnabled = Enabled;
            this.SirenEnabled = SirenEnabled;
        }
    }
}