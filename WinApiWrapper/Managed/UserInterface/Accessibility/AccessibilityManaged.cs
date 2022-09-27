using System.ComponentModel;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityEnumerations;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityUtilitiesManaged;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.Managed.UserInterface.Accessibility.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using SoundSentryWindowsEffect = WinApiWrapper.UserInterface.Accessibility.AccessibilityEnumerations.SoundSentryWindowsEffect;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Permette il controllo delle funzionalità di accessibilità del sistema.
    /// </summary>
    public static class AccessibilityManaged
    {
        /// <summary>
        /// Registra una finestra come bersaglio di un tipo di input specificato.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con informazioni sulla finestra.</param>
        /// <param name="PointerType">Tipo in input.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void RegisterWindowAsInputTarget(WindowInfo WindowInfo, PointerType PointerType)
        {
            if (PointerType is not PointerType.Generic)
            {
                POINTER_INPUT_TYPE Type = (POINTER_INPUT_TYPE)PointerType;
                if (!RegisterPointerInputTarget(WindowInfo.Handle, Type))
                {
                    int ErrorCode = Marshal.GetLastPInvokeError();
                    switch (ErrorCode)
                    {
                        case ERROR_INVALID_PARAMETER:
                            throw new Win32Exception(ErrorCode, "Invalid input type");
                        case ERROR_ACCESS_DENIED:
                            throw new Win32Exception(ErrorCode, "The thread does not have UI access privilege, the process does not own the window or it has been already registered for this type of input");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid pointer type", nameof(PointerType));
            }
        }

        /// <summary>
        /// Annulla la registrazione di una finestra come bersaglio di un tipo di input specificato.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="PointerType">Tipo in input.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void UnregisterWindowAsInputTarget(WindowInfo WindowInfo, PointerType PointerType)
        {
            if (PointerType is not PointerType.Generic)
            {
                POINTER_INPUT_TYPE Type = (POINTER_INPUT_TYPE)PointerType;
                if (!UnregisterPointerInputTarget(WindowInfo.Handle, Type))
                {
                    int ErrorCode = Marshal.GetLastPInvokeError();
                    switch (ErrorCode)
                    {
                        case ERROR_INVALID_PARAMETER:
                            throw new Win32Exception(ErrorCode, "Invalid input type");
                        case ERROR_ACCESS_DENIED:
                            throw new Win32Exception(ErrorCode, "The thread does not have UI access privilege or the process does not own the window");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid pointer type", nameof(PointerType));
            }
        }
        #region Get Accessibility Parameters Methods
        /// <summary>
        /// Recupera lo stato delle animazioni dell'area client delle finestre.
        /// </summary>
        /// <returns>true se le animazioni sono attive, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetClientAreaAnimationStatus()
        {
            return AccessibilityInfo.GetClientAreaAnimationStatus();
        }

        /// <summary>
        /// Recupera lo stato del contenuto sovrapposto.
        /// </summary>
        /// <returns>true se il contenuto sovrapposto è attivo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetOverlappedContentStatus()
        {
            return AccessibilityInfo.GetOverlappedContentStatus();
        }

        /// <summary>
        /// Recupera l'altezza e la larghezza del rettangolo di focus.
        /// </summary>
        /// <returns>Un array di due <see cref="uint"/>, il primo elemento è l'altezza, il secondo è la larghezza.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static int[] GetFocusBorderData()
        {
            return AccessibilityInfo.GetFocusBorderWidthAndHeight();
        }

        /// <summary>
        /// Recupera la durata, in secondi, delle notifiche a comparsa.
        /// </summary>
        /// <returns>La durata delle notifiche.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static int GetPopupMessageDuration()
        {
            return AccessibilityInfo.GetPopupMessageDuration();
        }

        /// <summary>
        /// Recupera lo stato della funzionalità di blocco dei tasti del mouse.
        /// </summary>
        /// <returns>true se la funzionalità è attiva, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetMouseClickLockStatus()
        {
            return AccessibilityInfo.GetMouseClickLockStatus();
        }

        /// <summary>
        /// Recupera il tempo, in secondi, prima che il tasto del mouse venga bloccato.
        /// </summary>
        /// <returns>Il tempo prima che il tasto del mouse venga bloccato.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static int GetMouseClickLockTime()
        {
            return AccessibilityInfo.GetMouseClickLockTime();
        }

        /// <summary>
        /// Recupera lo stato della funzionalità MouseSonar.
        /// </summary>
        /// <returns>true se MouseSonar è attivo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetMouseSonarStatus()
        {
            return AccessibilityInfo.GetMouseSonarStatus();
        }

        /// <summary>
        /// Recupera lo stato della funzionalità MouseVanish.
        /// </summary>
        /// <returns>true se MouseVanish è attivo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetMouseVanishStatus()
        {
            return AccessibilityInfo.GetMouseVanishStatus();
        }

        /// <summary>
        /// Recupera lo stato dell'utilità di lettura schermo.
        /// </summary>
        /// <returns>true se è in esecuzione un'utilità di lettura schermo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetScreenReaderStatus()
        {
            return AccessibilityInfo.GetScreenReaderUtilityStatus();
        }

        /// <summary>
        /// Recupera lo stato di ShowSounds.
        /// </summary>
        /// <returns>true se i suoni vengono visualizzati a schermo, false altrimenti.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static bool GetShowSoundsStatus()
        {
            return AccessibilityInfo.GetShowSoundsStatus();
        }
        #endregion
        #region Set Accessibility Parameters Methods
        /// <summary>
        /// Imposta il timeout delle funzionalità di accessibilità.
        /// </summary>
        /// <param name="TimeoutInfo">Istanza di <see cref="AccessibilityInfo"/> con le informazioni sul timeout.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetAccessibilityTimeout(AccessibilityTimeoutInfo TimeoutInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            ACCESSTIMEOUT TimeoutData = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(FILTERKEYS)),
                Flags = BuildAccessibilityTimeoutFlags(TimeoutInfo),
                Timeout = (uint)(TimeoutInfo.Timeout * 1000)
            };
            HMODULE TimeoutDataStructurePointer = Marshal.AllocHGlobal((int)TimeoutData.Size);
            Marshal.StructureToPtr(TimeoutData, TimeoutDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETACCESSTIMEOUT, TimeoutData.Size, TimeoutDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(TimeoutDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(TimeoutDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta le descrizioni audio.
        /// </summary>
        /// <param name="AudioDescriptionInfo">Istanza di <see cref="AudioDescriptionInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetAudioDescription(AudioDescriptionInfo AudioDescriptionInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            AUDIODESCRIPTION AudioDescriptionData = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(AUDIODESCRIPTION)),
                Enabled = AudioDescriptionInfo.IsEnabled
            };
            if (string.IsNullOrWhiteSpace(AudioDescriptionInfo.LocaleName))
            {
                LCID ID = LocaleNameToLCID(null, 0);
                if (ID == LOCALE_CUSTOM_DEFAULT || ID == LOCALE_CUSTOM_UNSPECIFIED)
                {
                    AudioDescriptionData.Locale = LocaleNameToLCID(LOCALE_NAME_INVARIANT, 0);
                }
                else
                {
                    AudioDescriptionData.Locale = ID;
                }
            }
            else
            {
                LCID ID = LocaleNameToLCID(AudioDescriptionInfo.LocaleName, 0);
                if (ID is 0)
                {
                    ID = LocaleNameToLCID(null, 0);
                    if (ID == LOCALE_CUSTOM_DEFAULT || ID == LOCALE_CUSTOM_UNSPECIFIED)
                    {
                        AudioDescriptionData.Locale = LocaleNameToLCID(LOCALE_NAME_INVARIANT, 0);
                    }
                    else
                    {
                        AudioDescriptionData.Locale = ID;
                    }
                }
                else
                {
                    AudioDescriptionData.Locale = ID;
                }
            }
            HMODULE AudioDescriptionDataStructurePointer = Marshal.AllocHGlobal((int)AudioDescriptionData.Size);
            Marshal.StructureToPtr(AudioDescriptionData, AudioDescriptionDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETAUDIODESCRIPTION, AudioDescriptionData.Size, AudioDescriptionDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(AudioDescriptionDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(AudioDescriptionDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Abilita o disabilita le animazioni dell'area client delle finestre.
        /// </summary>
        /// <param name="Enable">Indica se abilitare o disabilitare le animazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetClientAreaAnimationStatus(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle ClientAreaAnimationStatus = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETCLIENTAREAANIMATION, 0, ClientAreaAnimationStatus.AddrOfPinnedObject(), Option))
            {
                ClientAreaAnimationStatus.Free();
            }
            else
            {
                ClientAreaAnimationStatus.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Abilita o disabilita le animazioni dell'area client delle finestre.
        /// </summary>
        /// <param name="Enable">Indica se abilitare o disabilitare le animazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetOverlappedContentStatus(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle ClientAreaAnimationStatus = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETDISABLEOVERLAPPEDCONTENT, 0, ClientAreaAnimationStatus.AddrOfPinnedObject(), Option))
            {
                ClientAreaAnimationStatus.Free();
            }
            else
            {
                ClientAreaAnimationStatus.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità Filtro tasti.
        /// </summary>
        /// <param name="FilterKeysInfo">Istanza di <see cref="FilterKeysInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetFilterKeys(FilterKeysInfo FilterKeysInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            FILTERKEYS FilterKeysData = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(FILTERKEYS)),
                Flags = BuildFilterKeysFlags(FilterKeysInfo),
                WaitMilliseconds = (uint)(FilterKeysInfo.KeyAcceptWait * 1000),
                DelayMilliseconds = (uint)(FilterKeysInfo.KeyRepeatDelay * 1000),
                RepeatMilliseconds = (uint)(FilterKeysInfo.KeyRepeatTime * 1000),
                BounceMilliseconds = (uint)(FilterKeysInfo.KeyBounceTime * 1000)
            };
            HMODULE FilterKeysDataStructurePointer = Marshal.AllocHGlobal((int)FilterKeysData.Size);
            Marshal.StructureToPtr(FilterKeysData, FilterKeysDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETACCESSTIMEOUT, FilterKeysData.Size, FilterKeysDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(FilterKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(FilterKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta l'altezza degli angoli superiore e inferiore de rettangolo di focus.
        /// </summary>
        /// <param name="BorderHeight">Altezza degli angoli.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetFocusBorderHeight(int BorderHeight, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle BorderHeightValue = GCHandle.Alloc(BorderHeight, GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETFOCUSBORDERHEIGHT, 0, BorderHeightValue.AddrOfPinnedObject(), Option))
            {
                BorderHeightValue.Free();
            }
            else
            {
                BorderHeightValue.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta l'altezza degli angoli superiore e inferiore de rettangolo di focus.
        /// </summary>
        /// <param name="BorderWidth">Altezza degli angoli.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetFocusBorderWidth(int BorderWidth, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle BorderWidthValue = GCHandle.Alloc(BorderWidth, GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETFOCUSBORDERWIDTH, 0, BorderWidthValue.AddrOfPinnedObject(), Option))
            {
                BorderWidthValue.Free();
            }
            else
            {
                BorderWidthValue.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la modalità Alto contrasto.
        /// </summary>
        /// <param name="HighContrastInfo">Istanza di <see cref="HighContrastInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetHighContrast(HighContrastInfo HighContrastInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            HIGHCONTRAST HighContrastData = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(HIGHCONTRAST)),
                Flags = BuildHighContrastFlags(HighContrastInfo),
                DefaultScheme = HighContrastInfo.DefaultSchemeName
            };
            HMODULE HighContrastDataStructurePointer = Marshal.AllocHGlobal((int)HighContrastData.Size);
            Marshal.StructureToPtr(HighContrastData, HighContrastDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETHIGHCONTRAST, HighContrastData.Size, HighContrastDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(HighContrastDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(HighContrastDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la durata delle notifica a comparsa.
        /// </summary>
        /// <param name="Time">Durata notifiche.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMessageDuration(int Time, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle MessageDurationValue = GCHandle.Alloc(Time, GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETMESSAGEDURATION, 0, MessageDurationValue.AddrOfPinnedObject(), Option))
            {
                MessageDurationValue.Free();
            }
            else
            {
                MessageDurationValue.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta lo stato del blocco dello pulsante del mouse.
        /// </summary>
        /// <param name="Enable">Indica se abilitare la funzionalità.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMouseClickLockStatus(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle MouseClickLockStatus = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETMOUSECLICKLOCK, 0, MouseClickLockStatus.AddrOfPinnedObject(), Option))
            {
                MouseClickLockStatus.Free();
            }
            else
            {
                MouseClickLockStatus.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta il tempo di blocco del tasto del mouse.
        /// </summary>
        /// <param name="Time">Tempo di blocco, in secondi.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMouseClickLockTime(int Time, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle MouseClickLockTimeValue = GCHandle.Alloc(Time * 1000, GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETMOUSECLICKLOCKTIME, 0, MouseClickLockTimeValue.AddrOfPinnedObject(), Option))
            {
                MouseClickLockTimeValue.Free();
            }
            else
            {
                MouseClickLockTimeValue.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità MouseKeys.
        /// </summary>
        /// <param name="MouseKeysInfo">Istanza di <see cref="MouseKeysInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMouseKeys(MouseKeysInfo MouseKeysInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            MOUSEKEYS MouseKeysData = new();
            MouseKeysData.Size = (uint)Marshal.SizeOf(typeof(MOUSEKEYS));
            MouseKeysData.Flags = BuildMouseKeysFlags(MouseKeysInfo);
            MouseKeysData.MaxSpeed = (uint)MouseKeysInfo.CursorMaxSpeed;
            MouseKeysData.TimeToMaxSpeed = (uint)MouseKeysInfo.TimeToMaxSpeed;
            MouseKeysData.CtrlSpeed = (uint)MouseKeysInfo.CtrlMultiplier;
            HMODULE MouseKeysDataStructurePointer = Marshal.AllocHGlobal((int)MouseKeysData.Size);
            Marshal.StructureToPtr(MouseKeysData, MouseKeysDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETMOUSEKEYS, MouseKeysData.Size, MouseKeysDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(MouseKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(MouseKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità MouseSonar.
        /// </summary>
        /// <param name="Enable">Indica se abilitare la funzionalità.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMouseSonarStatus(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle MouseSonarStatus = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETMOUSESONAR, 0, MouseSonarStatus.AddrOfPinnedObject(), Option))
            {
                MouseSonarStatus.Free();
            }
            else
            {
                MouseSonarStatus.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità MouseVanish.
        /// </summary>
        /// <param name="Enable">Indica se abilitare la funzionalità.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMouseVanishStatus(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            GCHandle MouseVanishStatus = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETMOUSEVANISH, 0, MouseVanishStatus.AddrOfPinnedObject(), Option))
            {
                MouseVanishStatus.Free();
            }
            else
            {
                MouseVanishStatus.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta l'indicazione che un'utilità di lettura schermo è in esecuzione.
        /// </summary>
        /// <param name="Enable">Indica se abilitare l'indicazione.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetScreenReaderStatus(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (!SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETSCREENREADER, Convert.ToUInt32(Enable), HMODULE.Zero, Option))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità ShowSounds.
        /// </summary>
        /// <param name="Enable">Indica se la funzionalità è attiva.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetShowSoundsAccessibilityFlag(bool Enable, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (!SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETSHOWSOUNDS, Convert.ToUInt32(Enable), HMODULE.Zero, Option))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità SoundSentry.
        /// </summary>
        /// <param name="SoundSentryInfo">Istanza di <see cref="SoundSentryInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetSoundSentry(SoundSentryInfo SoundSentryInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            SOUNDSENTRY SoundSentryData = new();
            SoundSentryData.Size = (uint)Marshal.SizeOf(typeof(SOUNDSENTRY));
            SoundSentryData.Flags = BuildSoundSentryFlags(SoundSentryInfo);
            SoundSentryData.WindowsEffect = (SoundSentryWindowsEffect)SoundSentryInfo.WindowsEffect;
            HMODULE SoundSentryDataStructurePointer = Marshal.AllocHGlobal((int)SoundSentryData.Size);
            Marshal.StructureToPtr(SoundSentryData, SoundSentryDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETSOUNDSENTRY, SoundSentryData.Size, SoundSentryDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(SoundSentryDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(SoundSentryDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità Tasti permanenti.
        /// </summary>
        /// <param name="StickyKeysInfo">Istanza di <see cref="StickyKeysInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetStickyKeys(StickyKeysInfo StickyKeysInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            STICKYKEYS StickyKeysData = new();
            StickyKeysData.Size = (uint)Marshal.SizeOf(typeof(STICKYKEYS));
            StickyKeysData.Flags = BuildStickyKeysFlags(StickyKeysInfo);
            HMODULE StickyKeysDataStructurePointer = Marshal.AllocHGlobal((int)StickyKeysData.Size);
            Marshal.StructureToPtr(StickyKeysData, StickyKeysDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETSTICKYKEYS, StickyKeysData.Size, StickyKeysDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(StickyKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(StickyKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la funzionalità ToggleKeys.
        /// </summary>
        /// <param name="ToggleKeysInfo">Istanza di <see cref="ToggleKeysInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetToggleKeys(ToggleKeysInfo ToggleKeysInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            TOGGLEKEYS ToggleKeysData = new();
            ToggleKeysData.Size = (uint)Marshal.SizeOf(typeof(TOGGLEKEYS));
            ToggleKeysData.Flags = BuildToggleKeysFlags(ToggleKeysInfo);
            HMODULE StickyKeysDataStructurePointer = Marshal.AllocHGlobal((int)ToggleKeysData.Size);
            Marshal.StructureToPtr(ToggleKeysData, StickyKeysDataStructurePointer, false);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (UpdateUserProfileAndSendChange)
            {
                Option = SystemParameterUserProfileUpdateOptions.SendChange;
            }
            else
            {
                if (UpdateUserProfile)
                {
                    Option = SystemParameterUserProfileUpdateOptions.UpdateIniFile;
                }
            }
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_SETTOGGLEKEYS, ToggleKeysData.Size, StickyKeysDataStructurePointer, Option))
            {
                Marshal.FreeHGlobal(StickyKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(StickyKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }
        #endregion
        /// <summary>
        /// Imposta le funzionalità di accessibilità.
        /// </summary>
        /// <param name="AccessibilityInfo">Istanza di <see cref="AccessibilityInfo"/> con le informazioni.</param>
        /// <param name="UpdateUserProfile">Indica se aggiornare il profilo utente.</param>
        /// <param name="UpdateUserProfileAndSendChange">Indica se aggiornare il profilo utente e inviare una notifica del cambio.</param>
        public static void SetAccessibilityOptions(AccessibilityInfo AccessibilityInfo, bool UpdateUserProfile = false, bool UpdateUserProfileAndSendChange = false)
        {
            if (AccessibilityInfo.TimeoutInfo is not null)
            {
                SetAccessibilityTimeout(AccessibilityInfo.TimeoutInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.AudioDescriptionInfo is not null)
            {
                SetAudioDescription(AccessibilityInfo.AudioDescriptionInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.AnimationsEnabled is not null)
            {
                SetClientAreaAnimationStatus(AccessibilityInfo.AnimationsEnabled.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.IsOverlappedContentEnabled is not null)
            {
                SetOverlappedContentStatus(AccessibilityInfo.IsOverlappedContentEnabled.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.FilterKeysInfo is not null)
            {
                SetFilterKeys(AccessibilityInfo.FilterKeysInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.FocusBorderHeight is not null)
            {
                SetFocusBorderHeight(AccessibilityInfo.FocusBorderHeight.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.FocusBorderWidth is not null)
            {
                SetFocusBorderWidth(AccessibilityInfo.FocusBorderWidth.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.HighContrastInfo is not null)
            {
                SetHighContrast(AccessibilityInfo.HighContrastInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.MessageDuration is not null)
            {
                SetMessageDuration(AccessibilityInfo.MessageDuration.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.IsMouseClickLockEnabled is not null)
            {
                SetMouseClickLockStatus(AccessibilityInfo.IsMouseClickLockEnabled.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.MouseClickLockTime is not null)
            {
                SetMouseClickLockTime(AccessibilityInfo.MouseClickLockTime.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.MouseKeysInfo is not null)
            {
                SetMouseKeys(AccessibilityInfo.MouseKeysInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.IsMouseSonarEnabled is not null)
            {
                SetMouseSonarStatus(AccessibilityInfo.IsMouseSonarEnabled.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.IsMouseVanishEnabled is not null)
            {
                SetMouseVanishStatus(AccessibilityInfo.IsMouseVanishEnabled.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.IsScreenReaderRunning is not null)
            {
                SetScreenReaderStatus(AccessibilityInfo.IsScreenReaderRunning.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.ShowSoundsEnabled is not null)
            {
                SetShowSoundsAccessibilityFlag(AccessibilityInfo.ShowSoundsEnabled.Value, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.SoundSentryInfo is not null)
            {
                SetSoundSentry(AccessibilityInfo.SoundSentryInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.StickyKeysInfo is not null)
            {
                SetStickyKeys(AccessibilityInfo.StickyKeysInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
            if (AccessibilityInfo.ToggleKeysInfo is not null)
            {
                SetToggleKeys(AccessibilityInfo.ToggleKeysInfo, UpdateUserProfile, UpdateUserProfileAndSendChange);
            }
        }
    }
}