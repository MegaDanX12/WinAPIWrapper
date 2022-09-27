using System.ComponentModel;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulle funzionalità di accessibilità del sistema.
    /// </summary>
    public class AccessibilityInfo
    {
        /// <summary>
        /// Informazioni sul timeout delle funzionalità di accessibilità.
        /// </summary>
        public AccessibilityTimeoutInfo TimeoutInfo { get; }

        /// <summary>
        /// Informazioni sulle descrizioni audio.
        /// </summary>
        public AudioDescriptionInfo AudioDescriptionInfo { get; }

        /// <summary>
        /// Indica se le animazioni sono abilitate.
        /// </summary>
        public bool? AnimationsEnabled { get; }

        /// <summary>
        /// Indica se il contenuto sovrapposto è abilitato.
        /// </summary>
        public bool? IsOverlappedContentEnabled { get; }

        /// <summary>
        /// Informazioni sulla funzionalità Filtro tasti.
        /// </summary>
        public FilterKeysInfo FilterKeysInfo { get; }

        /// <summary>
        /// Altezza, in pixel, degli angoli superiore e inferiore del rettangolo di focus.
        /// </summary>
        public int? FocusBorderHeight { get; }

        /// <summary>
        /// Altezza, in pixel, degli angoli destro e sinistro del rettangolo di focus.
        /// </summary>
        public int? FocusBorderWidth { get; }

        /// <summary>
        /// Informazioni sulla funzionalità Alto contrasto.
        /// </summary>
        public HighContrastInfo HighContrastInfo { get; }

        /// <summary>
        /// Tempo di visualizzazione delle notifiche a comparsa, in secondi.
        /// </summary>
        public int? MessageDuration { get; }

        /// <summary>
        /// Indica se il blocco del tasto del mouse è attivo.
        /// </summary>
        public bool? IsMouseClickLockEnabled { get; }

        /// <summary>
        /// Tempo che deve passare prima che il tasto del mouse venga bloccato, in secondi.
        /// </summary>
        public int? MouseClickLockTime { get; }

        /// <summary>
        /// Informazioni sulla funzionalità MouseKeys.
        /// </summary>
        public MouseKeysInfo MouseKeysInfo { get; }

        /// <summary>
        /// Indica se MouseSonar è abilitato.
        /// </summary>
        public bool? IsMouseSonarEnabled { get; }

        /// <summary>
        /// Indica se MouseVanish è abilitato.
        /// </summary>
        public bool? IsMouseVanishEnabled { get; }

        /// <summary>
        /// Indica se è in esecuzione una utilità di lettura schermo.
        /// </summary>
        public bool? IsScreenReaderRunning { get; }

        /// <summary>
        /// Indica se i suoni verranno visualizzati a schermo.
        /// </summary>
        public bool? ShowSoundsEnabled { get; }

        /// <summary>
        /// Informazioni sulla funzionalità SoundSentry.
        /// </summary>
        public SoundSentryInfo SoundSentryInfo { get; }

        /// <summary>
        /// Informazioni sulla funzionalità Tasti permanenti.
        /// </summary>
        public StickyKeysInfo StickyKeysInfo { get; }

        /// <summary>
        /// Informazioni sulla funzionalità ToggleKeys.
        /// </summary>
        public ToggleKeysInfo ToggleKeysInfo { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="AccessibilityInfo"/>.
        /// </summary>
        public AccessibilityInfo()
        {
            TimeoutInfo = new();
            AudioDescriptionInfo = new();
            AnimationsEnabled = GetClientAreaAnimationStatus();
            IsOverlappedContentEnabled = GetOverlappedContentStatus();
            FilterKeysInfo = new();
            int[] FocusBorderData = GetFocusBorderWidthAndHeight();
            FocusBorderHeight = FocusBorderData[0];
            FocusBorderWidth = FocusBorderData[1];
            HighContrastInfo = new();
            MessageDuration = GetPopupMessageDuration();
            IsMouseClickLockEnabled = GetMouseClickLockStatus();
            MouseClickLockTime = GetMouseClickLockTime();
            MouseKeysInfo = new();
            IsMouseSonarEnabled = GetMouseSonarStatus();
            IsMouseVanishEnabled = GetMouseVanishStatus();
            IsScreenReaderRunning = GetScreenReaderUtilityStatus();
            ShowSoundsEnabled = GetShowSoundsStatus();
            SoundSentryInfo = new();
            StickyKeysInfo = new();
            ToggleKeysInfo = new();
        }

        /// <summary>
        /// Recupera lo stato delle animazioni dell'area client delle finestre.
        /// </summary>
        /// <returns>true se le animazioni sono attive, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetClientAreaAnimationStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETCLIENTAREAANIMATION, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool ClientAreaAnimationStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return ClientAreaAnimationStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera lo stato del contenuto sovrapposto.
        /// </summary>
        /// <returns>true se il contenuto sovrapposto è attivo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetOverlappedContentStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETDISABLEOVERLAPPEDCONTENT, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool OverlappedContentStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return OverlappedContentStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera l'altezza e la larghezza del rettangolo di focus.
        /// </summary>
        /// <returns>Un array di due <see cref="uint"/>, il primo elemento è l'altezza, il secondo è la larghezza.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static int[] GetFocusBorderWidthAndHeight()
        {
            int[] FocusBorderRectData = new int[2];
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETFOCUSBORDERHEIGHT, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                FocusBorderRectData[0] = Marshal.ReadInt32(DataPointer);
                Marshal.FreeHGlobal(DataPointer);
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETFOCUSBORDERWIDTH, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                FocusBorderRectData[1] = Marshal.ReadInt32(DataPointer);
                Marshal.FreeHGlobal(DataPointer);
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return FocusBorderRectData;
        }

        /// <summary>
        /// Recupera la durata, in secondi, delle notifiche a comparsa.
        /// </summary>
        /// <returns>La durata delle notifiche.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static int GetPopupMessageDuration()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETMESSAGEDURATION, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                int PopupMessageDuration = Marshal.ReadInt32(DataPointer);
                Marshal.FreeHGlobal(DataPointer);
                return PopupMessageDuration;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera lo stato della funzionalità di blocco dei tasti del mouse.
        /// </summary>
        /// <returns>true se la funzionalità è attiva, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetMouseClickLockStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETMOUSECLICKLOCK, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool MouseClickLockStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return MouseClickLockStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera il tempo, in secondi, prima che il tasto del mouse venga bloccato.
        /// </summary>
        /// <returns>Il tempo prima che il tasto del mouse venga bloccato.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static int GetMouseClickLockTime()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETMOUSECLICKLOCKTIME, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                int MouseClickLockTime = Marshal.ReadInt32(DataPointer);
                Marshal.FreeHGlobal(DataPointer);
                return MouseClickLockTime / 1000;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera lo stato della funzionalità MouseSonar.
        /// </summary>
        /// <returns>true se MouseSonar è attivo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetMouseSonarStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETMOUSESONAR, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool MouseSonarStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return MouseSonarStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera lo stato della funzionalità MouseVanish.
        /// </summary>
        /// <returns>true se MouseVanish è attivo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetMouseVanishStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETMOUSEVANISH, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool MouseVanishStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return MouseVanishStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera lo stato dell'utilità di lettura schermo.
        /// </summary>
        /// <returns>true se è in esecuzione un'utilità di lettura schermo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetScreenReaderUtilityStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETSCREENREADER, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool ScreenReaderUtilityStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return ScreenReaderUtilityStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera lo stato di ShowSounds.
        /// </summary>
        /// <returns>true se i suoni vengono visualizzati a schermo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        internal static bool GetShowSoundsStatus()
        {
            HMODULE DataPointer = Marshal.AllocHGlobal(4);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETSHOWSOUNDS, 0, DataPointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                bool ShowSoundsStatus = Convert.ToBoolean(Marshal.ReadInt32(DataPointer));
                Marshal.FreeHGlobal(DataPointer);
                return ShowSoundsStatus;
            }
            else
            {
                Marshal.FreeHGlobal(DataPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }
    }
}