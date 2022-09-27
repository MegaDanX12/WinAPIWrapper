using System.Drawing;
using System.Text;
using System.ComponentModel;
using Rectangle = WinApiWrapper.Managed.General.Rectangle;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.CommonControls.CommonControlsEnumerations;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using static WinApiWrapper.SystemServices.DLLs.DynamicLinkLibraryEnumerations;
using static WinApiWrapper.SystemServices.DLLs.DynamicLinkLibraryFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonConstants;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonControlsClasses;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonMessages;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonNotifications;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonStructures;
using WinApiWrapper.Managed.GraphicsAndMultimedia.DeviceContexts;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using WinApiWrapper.UserInterface.UserInterfaceElements.Common;
using WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Icons;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.CommonControls
{
    /// <summary>
    /// Funzionalità comuni dei controlli Windows.
    /// </summary>
    public static class CommonControlsManaged
    {
        /// <summary>
        /// Disegna testo con ombra.
        /// </summary>
        /// <param name="Device">Istanza di <see cref="DeviceInfo"/> che rappresenta il dispositivo sul quale disegnare il testo.</param>
        /// <param name="Text">Testo da disegnare.</param>
        /// <param name="TextRectangle">Rettangolo nel quale disegnare il testo.</param>
        /// <param name="TextFormat">Opzioni di formattazione del testo.</param>
        /// <param name="TextColor">Colore del testo.</param>
        /// <param name="ShadowColor">Colore dell'ombra.</param>
        /// <param name="OffsetX">Coordinata x dove il testo deve iniziare.</param>
        /// <param name="OffsetY">Coordinata y dove il testo deve iniziare.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <remarks><paramref name="TextRectangle"/> è espresso in coordinate logiche.</remarks>
        public static void DrawTextWithShadow(DeviceInfo Device, string Text, Rectangle TextRectangle, CommonControlsEnumerations.TextFormat TextFormat, Color TextColor, Color ShadowColor, int OffsetX, int OffsetY)
        {
            if (Device is null || string.IsNullOrWhiteSpace(Text) || TextRectangle is null)
            {
                throw new ArgumentNullException(string.Empty, "Device, Text and TextRectangle cannot be null.");
            }
            RECT TextRectangleStructure = TextRectangle.ToRECT();
            HMODULE RectangleStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(TextRectangleStructure));
            Marshal.StructureToPtr(TextRectangleStructure, RectangleStructurePointer, false);
            CommonEnumerations.TextFormat Format = (CommonEnumerations.TextFormat)TextFormat;
            int TextHeight = DrawShadowText(Device.DeviceContextHandle, Text, (uint)Text.Length, RectangleStructurePointer, Format, (uint)ColorTranslator.ToWin32(TextColor), (uint)ColorTranslator.ToWin32(ShadowColor), OffsetX, OffsetY);
            Marshal.FreeHGlobal(RectangleStructurePointer);
            if (TextHeight is 0)
            {
                throw new Exception("Couldn't draw text.");
            }
        }

        /// <summary>
        /// Calcola le dimensioni effettive dell'area client che contiene tutti i controlli specificati.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> che rappresenta la finestra la cui area client deve essere controllata.</param>
        /// <param name="ClientAreaControls">Array di istanze di <see cref="WindowInfo"/> che rappresentano i controlli presenti nell'area client.</param>
        /// <returns>Istanza di <see cref="Rectangle"/> che specifica le dimensioni dell'area client.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Rectangle GetEffectiveClientAreaRectangle(WindowInfo WindowInfo, WindowInfo[]? ClientAreaControls)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            int[] ControlsArray = Array.Empty<int>(); ;
            if (ClientAreaControls is not null && ClientAreaControls.Length is not 0)
            {
                int[] ControlIDs = new int[ClientAreaControls.Length];
                for (int i = 0; i < ClientAreaControls.Length; i++)
                {
                    if (ClientAreaControls[i].ID.HasValue)
                    {
                        ControlIDs[i] = ClientAreaControls[i].ID!.Value;
                    }
                }
                ControlsArray = new int[ControlIDs.Length * 2 + 1];
                for (int i = 0; i < ControlIDs.Length; i++)
                {
                    if (i == ControlIDs.Length - 1)
                    {
                        ControlsArray[i] = 0;
                    }
                    else
                    {
                        ControlsArray[i] = 1;
                        ControlsArray[i + 1] = ControlIDs[i];
                    }
                }
            }
            HMODULE ArrayPointer = HMODULE.Zero;
            if (ControlsArray.Length is not 0)
            {
                ArrayPointer = Marshal.AllocHGlobal(4 * ControlsArray.Length);
                Marshal.Copy(ControlsArray, 0, ArrayPointer, ControlsArray.Length);
            }
            RECT RectangleStructure = new();
            HMODULE RectangleStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(RectangleStructure));
            Marshal.StructureToPtr(RectangleStructure, RectangleStructurePointer, false);
            GetEffectiveClientRectangle(WindowInfo.Handle, RectangleStructurePointer, ArrayPointer);
            if (ArrayPointer != HMODULE.Zero)
            {
                Marshal.FreeHGlobal(ArrayPointer);
            }
            RectangleStructure = (RECT)Marshal.PtrToStructure(RectangleStructurePointer, typeof(RECT))!;
            Marshal.FreeHGlobal(RectangleStructurePointer);
            return new(RectangleStructure);
        }

        /// <summary>
        /// Recupera la lingua attualmente usata dai controlli comuni per un processo.
        /// </summary>
        /// <returns>Il nome località della lingua.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string GetMuiLanguage()
        {
            LANGID LangID = GetMUILanguage();
            LCID LocaleID = MAKELCID((short)LangID, 0);
            StringBuilder LocaleName = new(LOCALE_NAME_MAX_LENGTH);
            int CharCount = LCIDToLocaleName(LocaleID, LocaleName, LOCALE_NAME_MAX_LENGTH, LOCALE_ALLOW_NEUTRAL_NAMES);
            if (CharCount is not 0)
            {
                return LocaleName.ToString();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza la libreria dei controlli comuni e carica le classi specificate.
        /// </summary>
        /// <param name="Classes">Valore composito delle classi da caricare.</param>
        /// <exception cref="Exception"></exception>
        public static void InitializeCommonControlClasses(CommonControlsEnumerations.CommonControlsClasses Classes)
        {
            INITCOMMONCONTROLSEX ControlsStructure = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(INITCOMMONCONTROLSEX)),
                ClassesLoaded = (CommonClasses)Classes
            };
            HMODULE ControlClassesStructurePointer = Marshal.AllocHGlobal((int)ControlsStructure.Size);
            Marshal.StructureToPtr(ControlsStructure, ControlClassesStructurePointer, false);
            if (!InitializeCommonControls(ControlClassesStructurePointer))
            {
                throw new Exception("Unable to load the control library.");
            }
        }

        /// <summary>
        /// Imposta la lingua usata dai controlli comuni per il processo.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMuiLanguage(string LocaleName)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                throw new ArgumentNullException(nameof(LocaleName), "The parameter cannot be null.");
            }
            if (!IsValidLocaleName(LocaleName))
            {
                throw new ArgumentException("Invalid locale.", nameof(LocaleName));
            }
            LCID LocaleID = LocaleNameToLCID(LocaleName, LOCALE_ALLOW_NEUTRAL_NAMES);
            if (LocaleID is not 0)
            {
                LANGID LanguageID = LANGIDFROMLCID(LocaleID);
                InitMUILanguage(LanguageID);
                string Language = GetMuiLanguage();
                if (Language != LocaleName)
                {
                    throw new Exception("Could not set the language.");
                }
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Carica un'icona usando la metrica specificata.
        /// </summary>
        /// <param name="IconPath">Percorso dell'icona.</param>
        /// <param name="Size">Metrica da caricare.</param>
        /// <param name="IconName">Nome dell'icona nel file eseguibile o di libreria che la contiene.</param>
        /// <param name="IconOrdinal">Ordinale dell'icona nel file eseguibile o di libreria che la contiene.</param>
        /// <param name="ID">ID di icone standard di sistema.</param>
        /// <returns>Istanza di <see cref="IconInfo"/> associata all'icona.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="IconPath"/> è nullo, <paramref name="ID"/> deve avere un valore tra i seguenti:<br/><br/>
        /// <see cref="StandardResource.ApplicationDefaultIcon"/><br/>
        /// <see cref="StandardResource.InformationIcon"/><br/>
        /// <see cref="StandardResource.ErrorIcon"/><br/>
        /// <see cref="StandardResource.WarningIcon"/><br/>
        /// <see cref="StandardResource.SecurityShieldIcon"/><br/>
        /// <see cref="StandardResource.QuestionMarkIcon"/><br/><br/>
        /// <paramref name="IconPath"/> può specificare percorsi a file .dll, .exe o .ico.<br/>
        /// Se <paramref name="IconPath"/> specifica il percorso per un file .dll o .exe, <paramref name="IconName"/> oppure <paramref name="IconOrdinal"/> devono avere un valore valido.<br/>
        /// Se sia <paramref name="IconName"/> che <paramref name="IconOrdinal"/> hanno un valore valido, <paramref name="IconName"/> ha priorità.</remarks>
        public static IconInfo LoadIconMetric(string? IconPath, IconSize Size, string? IconName = null, int? IconOrdinal = null, StandardResource? ID = null)
        {
            if (string.IsNullOrWhiteSpace(IconPath))
            {
                if (!ID.HasValue)
                {
                    throw new ArgumentNullException(nameof(ID), "A standard resource ID must be specified if IconPath is null.");
                }
                else
                {
                    if (ID is not StandardResource.ApplicationDefaultIcon and not StandardResource.InformationIcon and not StandardResource.ErrorIcon and not StandardResource.WarningIcon and not StandardResource.SecurityShieldIcon and not StandardResource.QuestionMarkIcon)
                    {
                        throw new ArgumentException("Invalid standard resource.", nameof(ID));
                    }
                }
            }
            else
            {
                if (!File.Exists(IconPath))
                {
                    throw new FileNotFoundException("The file does not exist.");
                }
                string Extension = Path.GetExtension(IconPath);
                if (Extension == string.Empty)
                {
                    throw new ArgumentException("Invalid path.", nameof(IconPath));
                }
                else
                {
                    if (Extension is not ".exe" and not ".dll" and not ".ico")
                    {
                        throw new ArgumentException("Invalid extension.", nameof(IconPath));
                    }
                    else
                    {
                        if (Extension is ".exe" or ".dll")
                        {
                            if (IconName is null && IconOrdinal is null)
                            {
                                throw new ArgumentNullException(string.Empty, "Either IconName or IconOrdinal must have a valid value when IconPath points to an .exe or .dll file.");
                            }
                        }
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(IconPath))
            {
                string ResourceID = MAKEINTRESOURCE((int)ID!.Value);
                HRESULT Result = CommonFunctions.LoadIconMetric(HMODULE.Zero, ResourceID, (IconMetric)Size, out HMODULE IconHandle);
                if (Result is S_OK)
                {
                    return new IconInfo(IconHandle, true);
                }
                else
                {
                    throw new Win32Exception(Result);
                }
            }
            else
            {
                string Extension = Path.GetExtension(IconPath);
                if (Extension is ".exe" or ".dll")
                {
                    bool ModuleMustBeFreed = false;
                    HMODULE ModuleHandle;
                    if (!GetModuleHandle(ModuleHandleOptions.UNCHANGED_REFCOUNT, IconPath, out ModuleHandle))
                    {
                        LoadingOptions LoadingFlags = LoadingOptions.LOAD_LIBRARY_AS_IMAGE_RESOURCE | LoadingOptions.LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE;
                        ModuleHandle = LoadLibrary(IconPath, HMODULE.Zero, LoadingFlags);
                        if (ModuleHandle == HMODULE.Zero)
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                        else
                        {
                            ModuleMustBeFreed = true;
                        }
                    }
                    HRESULT Result;
                    if (!string.IsNullOrWhiteSpace(IconName))
                    {
                        Result = CommonFunctions.LoadIconMetric(ModuleHandle, IconName, (IconMetric)Size, out HMODULE IconHandle);
                        if (Result is not S_OK)
                        {
                            if (ModuleMustBeFreed)
                            {
                                _ = FreeLibrary(ModuleHandle);
                            }
                            throw new Win32Exception(Result);
                        }
                        IconInfo IconData = new(IconHandle, false);
                        if (ModuleMustBeFreed)
                        {
                            _ = FreeLibrary(ModuleHandle);
                        }
                        return IconData;
                    }
                    else
                    {
                        string IconID = MAKEINTRESOURCE(IconOrdinal!.Value);
                        Result = CommonFunctions.LoadIconMetric(ModuleHandle, IconID, (IconMetric)Size, out HMODULE IconHandle);
                        if (Result is not S_OK)
                        {
                            if (ModuleMustBeFreed)
                            {
                                _ = FreeLibrary(ModuleHandle);
                            }
                            throw new Win32Exception(Result);
                        }
                        if (ModuleMustBeFreed)
                        {
                            _ = FreeLibrary(ModuleHandle);
                        }
                        return new IconInfo(IconHandle, true);
                    }
                }
                else
                {
                    HRESULT Result = CommonFunctions.LoadIconMetric(HMODULE.Zero, IconPath, (IconMetric)Size, out HMODULE IconHandle);
                    if (Result is not S_OK)
                    {
                        throw new Win32Exception(Result);
                    }
                    return new IconInfo(IconHandle, true);
                }
            }
        }

        /// <summary>
        /// Carica un'icona riducendo di dimensione un'immagine più grande se la dimensione non è standard.
        /// </summary>
        /// <param name="IconPath">Percorso dell'icona.</param>
        /// <param name="Height">Altezza desiderata, in pixel, dell'icona.</param>
        /// <param name="Width">Larghezza desiderata, in pixel, dell'icona.</param>
        /// <param name="IconName">Nome dell'icona nel file eseguibile o di libreria che la contiene.</param>
        /// <param name="IconOrdinal">Ordinale dell'icona nel file eseguibile o di libreria che la contiene.</param>
        /// <param name="ID">ID di icone standard di sistema.</param>
        /// <returns>Istanza di <see cref="IconInfo"/> associata all'icona.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="IconPath"/> è nullo, <paramref name="ID"/> deve avere un valore tra i seguenti:<br/><br/>
        /// <see cref="StandardResource.ApplicationDefaultIcon"/><br/>
        /// <see cref="StandardResource.InformationIcon"/><br/>
        /// <see cref="StandardResource.ErrorIcon"/><br/>
        /// <see cref="StandardResource.WarningIcon"/><br/>
        /// <see cref="StandardResource.SecurityShieldIcon"/><br/>
        /// <see cref="StandardResource.QuestionMarkIcon"/><br/>
        /// <see cref="StandardResource.AsteriskIcon"/><br/>
        /// <see cref="StandardResource.ExclamationMarkIcon"/><br/>
        /// <see cref="StandardResource.HandIcon"/><br/>
        /// <see cref="StandardResource.WindowsLogoIcon"/><br/><br/>
        /// <paramref name="IconPath"/> può specificare percorsi a file .dll, .exe o .ico.<br/>
        /// Se <paramref name="IconPath"/> specifica il percorso per un file .dll o .exe, <paramref name="IconName"/> oppure <paramref name="IconOrdinal"/> devono avere un valore valido.<br/>
        /// Se sia <paramref name="IconName"/> che <paramref name="IconOrdinal"/> hanno un valore valido, <paramref name="IconName"/> ha priorità.</remarks>
        public static IconInfo LoadIconWithScaleDown(string? IconPath, int Width, int Height, string? IconName = null, int? IconOrdinal = null, StandardResource? ID = null)
        {
            if (string.IsNullOrWhiteSpace(IconPath))
            {
                if (!ID.HasValue)
                {
                    throw new ArgumentNullException(nameof(ID), "A standard resource ID must be specified if IconPath is null.");
                }
            }
            else
            {
                if (!File.Exists(IconPath))
                {
                    throw new FileNotFoundException("The file does not exist.");
                }
                string Extension = Path.GetExtension(IconPath);
                if (Extension == string.Empty)
                {
                    throw new ArgumentException("Invalid path.", nameof(IconPath));
                }
                else
                {
                    if (Extension is not ".exe" and not ".dll" and not ".ico")
                    {
                        throw new ArgumentException("Invalid extension.", nameof(IconPath));
                    }
                    else
                    {
                        if (Extension is ".exe" or ".dll")
                        {
                            if (IconName is null && IconOrdinal is null)
                            {
                                throw new ArgumentNullException(string.Empty, "Either IconName or IconOrdinal must have a valid value when IconPath points to an .exe or .dll file.");
                            }
                        }
                    }
                }
            }
            if (Width is not > 0 || Height is not > 0)
            {
                throw new ArgumentException("Invalid values for Width and Height");
            }
            if (string.IsNullOrWhiteSpace(IconPath))
            {
                string ResourceID = MAKEINTRESOURCE((int)ID!.Value);
                HRESULT Result = CommonFunctions.LoadIconWithScaleDown(HMODULE.Zero, ResourceID, Width, Height, out HMODULE IconHandle);
                if (Result is S_OK)
                {
                    return new IconInfo(IconHandle, true);
                }
                else
                {
                    throw new Win32Exception(Result);
                }
            }
            else
            {
                string Extension = Path.GetExtension(IconPath);
                if (Extension is ".exe" or ".dll")
                {
                    bool ModuleMustBeFreed = false;
                    HMODULE ModuleHandle;
                    if (!GetModuleHandle(ModuleHandleOptions.UNCHANGED_REFCOUNT, IconPath, out ModuleHandle))
                    {
                        LoadingOptions LoadingFlags = LoadingOptions.LOAD_LIBRARY_AS_IMAGE_RESOURCE | LoadingOptions.LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE;
                        ModuleHandle = LoadLibrary(IconPath, HMODULE.Zero, LoadingFlags);
                        if (ModuleHandle == HMODULE.Zero)
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                        else
                        {
                            ModuleMustBeFreed = true;
                        }
                    }
                    HRESULT Result;
                    if (!string.IsNullOrWhiteSpace(IconName))
                    {
                        Result = CommonFunctions.LoadIconWithScaleDown(ModuleHandle, IconName, Width, Height, out HMODULE IconHandle);
                        if (Result is not S_OK)
                        {
                            if (ModuleMustBeFreed)
                            {
                                _ = FreeLibrary(ModuleHandle);
                            }
                            throw new Win32Exception(Result);
                        }
                        IconInfo IconData = new(IconHandle, false);
                        if (ModuleMustBeFreed)
                        {
                            _ = FreeLibrary(ModuleHandle);
                        }
                        return IconData;
                    }
                    else
                    {
                        string IconID = MAKEINTRESOURCE(IconOrdinal!.Value);
                        Result = CommonFunctions.LoadIconWithScaleDown(ModuleHandle, IconID, Width, Height, out HMODULE IconHandle);
                        if (Result is not S_OK)
                        {
                            if (ModuleMustBeFreed)
                            {
                                _ = FreeLibrary(ModuleHandle);
                            }
                            throw new Win32Exception(Result);
                        }
                        if (ModuleMustBeFreed)
                        {
                            _ = FreeLibrary(ModuleHandle);
                        }
                        return new IconInfo(IconHandle, true);
                    }
                }
                else
                {
                    HRESULT Result = CommonFunctions.LoadIconWithScaleDown(HMODULE.Zero, IconPath, Width, Height, out HMODULE IconHandle);
                    if (Result is not S_OK)
                    {
                        throw new Win32Exception(Result);
                    }
                    return new IconInfo(IconHandle, true);
                }
            }
        }
    }
}