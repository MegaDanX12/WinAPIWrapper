using static WinApiWrapper.UserInterface.HighDPI.HighDPIEnumerations;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIFunctions;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIConstants;
using static WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows.Enumerations;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.Managed.UserInterface.HighDPI.Enumerations;
using System.ComponentModel;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Icons.IconStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationStructures;
using WinApiWrapper.Managed.General;
using WinApiWrapper.Managed.GraphicsAndMultimedia.Fonts;
using WinApiWrapper.Managed.GraphicsAndMultimedia.MultipleDisplayMonitors;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Configuration;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using WinApiWrapper.UserInterface.HighDPI;

namespace WinApiWrapper.Managed.UserInterface.HighDPI
{
    /// <summary>
    /// Permette di eseguire operazioni quando è necessario tenere conto dei DPI.
    /// </summary>
    public static class HighDPIManaged
    {
        /// <summary>
        /// Calcola dimensione necessaria per il rettangolo della finestra basandosi sulla dimensione desiderata.
        /// </summary>
        /// <param name="DesiredClientArea">Dimensione desiderata della finestra.</param>
        /// <param name="Styles">Stili della finestra.</param>
        /// <param name="HasMenu">Indica se la finestra ha un menù.</param>
        /// <param name="ExtendedStyles">Stili estesi della finestra.</param>
        /// <param name="DPI">DPI da usare per scalare la dimensione.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static Rectangle CalculateWindowRectangleRequiredSize(Rectangle DesiredClientArea, WindowStyles Styles, bool HasMenu, ExtendedWindowStyles ExtendedStyles, int DPI)
        {
            if (DesiredClientArea is null)
            {
                throw new ArgumentNullException(nameof(DesiredClientArea), "The parameter cannot be null.");
            }
            if (Styles.HasFlag(WindowStyles.Overlapped))
            {
                throw new ArgumentException("The style " + WindowStyles.Overlapped.ToString() + " cannot be specified.", nameof(Styles));
            }
            if (ValidateWindowStylesValue((WindowStyle)Styles))
            {
                RECT ClientAreaRectangle = DesiredClientArea.ToRECT();
                if (AdjustWindowRectExForDpi(ref ClientAreaRectangle, (WindowStyle)Styles, HasMenu, (WindowExtendedStyle)ExtendedStyles, (uint)DPI))
                {
                    return new(ClientAreaRectangle);
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                throw new ArgumentException("The window styles are not valid.", nameof(Styles));
            }
        }

        /// <summary>
        /// Abilita la scalatura automatica delle porzioni non client della finestra top-level indicata.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static void EnableNonClientDpiScaling(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                DPI_AWARENESS_CONTEXT Context = GetWindowDpiAwarenessContext(WindowInfo.Handle);
                if (Context == HMODULE.Zero)
                {
                    throw new ArgumentException("The window is not valid.", nameof(WindowInfo));
                }
                else
                {
                    if (Context != DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2)
                    {
                        if (Context == DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE)
                        {
                            if (!HighDPIFunctions.EnableNonClientDpiScaling(WindowInfo.Handle))
                            {
                                throw new Win32Exception(Marshal.GetLastPInvokeError());
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("The DPI awareness context is not valid.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Recupera il livello di consapevolezza DPI del processo corrente.
        /// </summary>
        /// <returns>Valore dell'enumerazione <see cref="DpiAwareness"/> che indica il livello di consapevolezza DPI.</returns>
        public static DpiAwareness GetProcessDpiAwareness()
        {
            HRESULT OperationResult = HighDPIFunctions.GetProcessDpiAwareness(HMODULE.Zero, out PROCESS_DPI_AWARENESS Value);
            if (OperationResult == S_OK)
            {
                return (DpiAwareness)Value;
            }
            else
            {
                Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                {
                    HResult = OperationResult
                };
                throw ex;
            }
        }

        /// <summary>
        /// Recupera il livello di consapevolezza DPI del thread corrente.
        /// </summary>
        /// <returns>Valore dell'enumerazione <see cref="DpiAwareness"/> che indica il livello di consapevolezza DPI.</returns>
        public static DpiAwareness GetThreadDpiAwareness()
        {
            DPI_AWARENESS_CONTEXT Context = GetThreadDpiAwarenessContext();
            DPI_AWARENESS Awareness = GetAwarenessFromDpiAwarenessContext(Context);
            if (Awareness != DPI_AWARENESS.DPI_AWARENESS_INVALID)
            {
                return (DpiAwareness)Awareness;
            }
            else
            {
                throw new Win32Exception("Unable to retrieve the DPI awareness context for the current thread.");
            }
        }

        /// <summary>
        /// Recupera il livello di consapevolezza DPI di una finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <returns>Valore dell'enumerazione <see cref="DpiAwareness"/> che indica il livello di consapevolezza DPI.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static DpiAwareness GetWindowDpiAwareness(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            DPI_AWARENESS_CONTEXT Context = GetWindowDpiAwarenessContext(WindowInfo.Handle);
            if (Context == HMODULE.Zero)
            {
                throw new Win32Exception("Invalid window.");
            }
            else
            {
                DPI_AWARENESS Awareness = GetAwarenessFromDpiAwarenessContext(Context);
                if (Awareness != DPI_AWARENESS.DPI_AWARENESS_INVALID)
                {
                    return (DpiAwareness)Awareness;
                }
                else
                {
                    throw new Win32Exception("Unable to retrieve the DPI awareness context for the window.");
                }
            }
        }

        /// <summary>
        /// Recupera il valore DPI per un monitor.
        /// </summary>
        /// <param name="MonitorInfo">Istanza di <see cref="MonitorInfo"/> con le informazioni sul monitor.</param>
        /// <param name="DPIType">Tipo di DPI da recuperare.</param>
        /// <returns>DPI del monitor.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetMonitorDPI(MonitorInfo MonitorInfo, MonitorDpiType DPIType)
        {
            HRESULT OperationResult = GetDpiForMonitor(MonitorInfo.MonitorHandle, (MONITOR_DPI_TYPE)DPIType, out uint DpiX, out uint DpiY);
            if ((uint)OperationResult is E_INVALIDARG)
            {
                throw new ArgumentException("Invalid parameters.");
            }
            else
            {
                return (int)DpiX;
            }
        }

        /// <summary>
        /// Recupera il valore DPI del sistema.
        /// </summary>
        /// <returns>DPI del sistema.</returns>
        /// <remarks>Il valore restituito dipende dipende dalla consapevolezza DPI del thread chiamante.</remarks>
        public static int GetSystemDPI()
        {
            return (int)GetDpiForSystem();
        }

        /// <summary>
        /// Recupera il valore DPI per una finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> che contiene informazioni sulla finestra.</param>
        /// <returns>DPI della finestra.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <remarks>Il valore restituito dipende dalla consapevolezza DPI della finestra.</remarks>
        public static int GetWindowDPI(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            uint DPI = GetDpiForWindow(WindowInfo.Handle);
            if (DPI is 0)
            {
                throw new ArgumentException("Invalid window.", nameof(WindowInfo));
            }
            else
            {
                return (int)DPI;
            }
        }

        /// <summary>
        /// Recupera il valore DPI per il thread corrente.
        /// </summary>
        /// <returns>Il valore DPI.</returns>
        /// <remarks>Il valore restituito è 0 se i DPI non possono essere recuperati.</remarks>
        public static int GetThreadDPI()
        {
            HMODULE ThreadAwarenessContext = GetThreadDpiAwarenessContext();
            return (int)GetDpiFromAwarenessContext(ThreadAwarenessContext);
        }

        /// <summary>
        /// Converte le coordinate logiche in una finestra in coordinate fisiche.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Point">Coordinate logiche.</param>
        /// <returns>Struttura <see cref="System.Drawing.Point"/> con le coordinate fisiche.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static System.Drawing.Point ConvertLogicalCoordinatesToPhysicalCoordinates(WindowInfo WindowInfo, System.Drawing.Point Point)
        {
            POINT PointStructure = new()
            {
                x = Point.X,
                y = Point.Y
            };
            if (!LogicalToPhysicalPointForPerMonitorDPI(WindowInfo.Handle, ref PointStructure))
            {
                throw new Win32Exception("Unable to convert coordinates.");
            }
            else
            {
                return new System.Drawing.Point(PointStructure.x, PointStructure.y);
            }
        }

        /// <summary>
        /// Converte le coordinate fisiche in una finestra in coordinate logiche.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Point">Coordinate fisiche.</param>
        /// <returns>Struttura <see cref="System.Drawing.Point"/> con le coordinate logiche.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static System.Drawing.Point ConvertPhysicalCoordinatesToLogicalCoordinates(WindowInfo WindowInfo, System.Drawing.Point Point)
        {
            POINT PointStructure = new()
            {
                x = Point.X,
                y = Point.Y
            };
            if (!PhysicalToLogicalPointForPerMonitorDPI(WindowInfo.Handle, ref PointStructure))
            {
                throw new Win32Exception("Unable to convert coordinates.");
            }
            else
            {
                return new System.Drawing.Point(PointStructure.x, PointStructure.y);
            }
        }

        /// <summary>
        /// Imposta la consapevolezza DPI del processo.
        /// </summary>
        /// <param name="Awareness">Valore consapevolezza DPI.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void SetProcessDpiAwareness(DpiAwareness Awareness)
        {
            HRESULT OperationResult = HighDPIFunctions.SetProcessDpiAwareness((PROCESS_DPI_AWARENESS)Awareness);
            if ((uint)OperationResult is E_ACCESSDENIED)
            {
                throw new Win32Exception("DPI awareness already set.");
            }
            else if ((uint)OperationResult is E_INVALIDARG)
            {
                throw new ArgumentException("Invalid awareness value.", nameof(Awareness));
            }
        }

        /// <summary>
        /// Imposta il contesto di consapevolezza DPI per il thread corrente.
        /// </summary>
        /// <param name="Context">Contesto da impostare.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void SetThreadDpiAwarenessContext(DpiAwarenessContext Context)
        {
            HMODULE NewValue = HMODULE.Zero;
            switch (Context)
            {
                case DpiAwarenessContext.Unaware:
                    NewValue = DPI_AWARENESS_CONTEXT_UNAWARE;
                    break;
                case DpiAwarenessContext.SystemAware:
                    NewValue = DPI_AWARENESS_CONTEXT_SYSTEM_AWARE;
                    break;
                case DpiAwarenessContext.PerMonitorAware:
                    NewValue = DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE;
                    break;
                case DpiAwarenessContext.PerMonitorAwareV2:
                    NewValue = DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2;
                    break;
                case DpiAwarenessContext.UnawareGDIScaled:
                    NewValue = DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED;
                    break;
            }
            DPI_AWARENESS_CONTEXT OldContext = HighDPIFunctions.SetThreadDpiAwarenessContext(NewValue);
            if (OldContext == HMODULE.Zero)
            {
                throw new ArgumentException("Invalid context.", nameof(Context));
            }
        }

        /// <summary>
        /// Imposta il contesto di consapevolezza DPI per il processo corrente.
        /// </summary>
        /// <param name="Context">Contesto da impostare.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetProcessDpiAwarenessContext(DpiAwarenessContext Context)
        {
            HMODULE NewValue = HMODULE.Zero;
            switch (Context)
            {
                case DpiAwarenessContext.Unaware:
                    NewValue = DPI_AWARENESS_CONTEXT_UNAWARE;
                    break;
                case DpiAwarenessContext.SystemAware:
                    NewValue = DPI_AWARENESS_CONTEXT_SYSTEM_AWARE;
                    break;
                case DpiAwarenessContext.PerMonitorAware:
                    NewValue = DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE;
                    break;
                case DpiAwarenessContext.PerMonitorAwareV2:
                    NewValue = DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2;
                    break;
                case DpiAwarenessContext.UnawareGDIScaled:
                    NewValue = DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED;
                    break;
            }
            if (!HighDPIFunctions.SetProcessDpiAwarenessContext(NewValue))
            {
                int ErrorCode = Marshal.GetLastPInvokeError();
                if (ErrorCode is ERROR_INVALID_PARAMETER)
                {
                    throw new ArgumentException("Invalid context.", nameof(Context));
                }
                else if (ErrorCode is ERROR_ACCESS_DENIED)
                {
                    throw new InvalidOperationException("Context already set.");
                }
                else
                {
                    throw new Win32Exception(ErrorCode);
                }
            }
        }

        /// <summary>
        /// Recupera informazioni sul font usato dai titoli delle icone.
        /// </summary>
        /// <param name="DPI">Valore DPI sul quale scalare le informazioni.</param>
        /// <returns>Istanza di <see cref="FontInfo"/> con le informazioni.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static FontInfo GetIconTitleFontInfo(int DPI = 0)
        {
            if (DPI < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(DPI), "Invalid DPI value.");
            }
            else if (DPI is 0)
            {
                DPI = GetThreadDPI();
                if (DPI is 0)
                {
                    throw new ArgumentException("Unable to retrieve DPI value for the current thread.", nameof(DPI));
                }
            }
            uint StructureSize = (uint)Marshal.SizeOf(typeof(LOGFONT));
            LOGFONT FontData = new();
            HMODULE FontDataStructurePointer = Marshal.AllocHGlobal((int)StructureSize);
            Marshal.StructureToPtr(FontData, FontDataStructurePointer, false);
            if (SystemParametersInfoForDpi((uint)SystemParametersIcons.SPI_GETICONTITLELOGFONT, StructureSize, FontDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction, (uint)DPI))
            {
                FontData = (LOGFONT)Marshal.PtrToStructure(FontDataStructurePointer, typeof(LOGFONT))!;
                Marshal.FreeHGlobal(FontDataStructurePointer);
                return new FontInfo(FontData);
            }
            else
            {
                Marshal.FreeHGlobal(FontDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera le metriche delle icone.
        /// </summary>
        /// <param name="DPI">Valore DPI sul quale scalare i dati recuperati.</param>
        /// <returns>Istanza di <see cref="IconMetricsInfo"/> con le informazioni.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static IconMetricsInfo GetIconMetrics(int DPI = 0)
        {
            if (DPI < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(DPI), "Invalid DPI value.");
            }
            else if (DPI is 0)
            {
                DPI = GetThreadDPI();
                if (DPI is 0)
                {
                    throw new ArgumentException("Unable to retrieve DPI value for the current thread.", nameof(DPI));
                }
            }
            ICONMETRICS IconMetricsData = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(ICONMETRICS))
            };
            HMODULE IconMetricsDataStructurePointer = Marshal.AllocHGlobal((int)IconMetricsData.Size);
            Marshal.StructureToPtr(IconMetricsData, IconMetricsDataStructurePointer, false);
            if (SystemParametersInfoForDpi((uint)SystemParametersIcons.SPI_GETICONMETRICS, IconMetricsData.Size, IconMetricsDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction, (uint)DPI))
            {
                IconMetricsData = (ICONMETRICS)Marshal.PtrToStructure(IconMetricsDataStructurePointer, typeof(ICONMETRICS))!;
                Marshal.FreeHGlobal(IconMetricsDataStructurePointer);
                return new IconMetricsInfo(IconMetricsData);
            }
            else
            {
                Marshal.FreeHGlobal(IconMetricsDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera le metriche relative all'area non client delle finestre non minimizzate.
        /// </summary>
        /// <param name="DPI">Valore DPI in base al quale scalare i valori.</param>
        /// <returns>Istanza di <see cref="NonClientMetricsInfo"/> con le informazioni.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static NonClientMetricsInfo GetNonClientMetrics(int DPI = 0)
        {
            if (DPI < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(DPI), "Invalid DPI value.");
            }
            else if (DPI is 0)
            {
                DPI = GetThreadDPI();
                if (DPI is 0)
                {
                    throw new ArgumentException("Unable to retrieve DPI value for the current thread.", nameof(DPI));
                }
            }
            NONCLIENTMETRICS NonClientMetricsData = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(NONCLIENTMETRICS))
            };
            HMODULE NonClientMetricsDataStructurePointer = Marshal.AllocHGlobal((int)NonClientMetricsData.Size);
            Marshal.StructureToPtr(NonClientMetricsData, NonClientMetricsDataStructurePointer, false);
            if (SystemParametersInfoForDpi((uint)SystemParametersWindows.SPI_GETNONCLIENTMETRICS, NonClientMetricsData.Size, NonClientMetricsDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction, (uint)DPI))
            {
                NonClientMetricsData = (NONCLIENTMETRICS)Marshal.PtrToStructure(NonClientMetricsDataStructurePointer, typeof(NONCLIENTMETRICS))!;
                Marshal.FreeHGlobal(NonClientMetricsDataStructurePointer);
                return new NonClientMetricsInfo(NonClientMetricsData);
            }
            else
            {
                Marshal.FreeHGlobal(NonClientMetricsDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera il comportamento di una finestra di dialogo nel caso di un cambiamento del valore dei DPI.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> che rappresenta la finestra di dialogo.</param>
        /// <returns>Istanza di <see cref="DialogDpiChangeBehaviorInfo"/> che specifica il comportamento.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static DialogDpiChangeBehaviorInfo GetDialogDpiChangeBehavior(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            DIALOG_DPI_CHANGE_BEHAVIORS Behavior = HighDPIFunctions.GetDialogDpiChangeBehavior(WindowInfo.Handle);
            if (Behavior is DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DEFAULT)
            {
                int ErrorCode = Marshal.GetLastPInvokeError();
                if (ErrorCode is ERROR_INVALID_HANDLE)
                {
                    throw new Win32Exception(ErrorCode, "Invalid window.");
                }
                else if (ErrorCode is not ERROR_SUCCESS)
                {
                    throw new Win32Exception(ErrorCode);
                }
            }
            return new DialogDpiChangeBehaviorInfo(Behavior);
        }

        /// <summary>
        /// Imposta il comportamento di una finestra di dialogo nel caso di un cambiamento del valore dei DPI.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> che rappresenta la finestra di dialogo.</param>
        /// <param name="BehaviorInfo">Istanza di <see cref="DialogDpiChangeBehaviorInfo"/> che indica il nuovo comportamento.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetDialogDpiChangeBehavior(WindowInfo WindowInfo, DialogDpiChangeBehaviorInfo BehaviorInfo)
        {
            if (WindowInfo is null || BehaviorInfo is null)
            {
                throw new ArgumentNullException(string.Empty, "The parameters cannot be null.");
            }
            DIALOG_DPI_CHANGE_BEHAVIORS NewBehavior = BehaviorInfo.ToEnumValue();
            DIALOG_DPI_CHANGE_BEHAVIORS Mask = DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DISABLE_ALL | DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DISABLE_RESIZE | DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DISABLE_CONTROL_RELAYOUT;
            if (!HighDPIFunctions.SetDialogDpiChangeBehavior(WindowInfo.Handle, Mask, NewBehavior))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera il comportamento del thread relativamente all'hosting di finestre con contesto di consapevolezza DPI diverso.
        /// </summary>
        /// <returns>Un valore dell'enumerazione <see cref="DpiHostingBehavior"/> che indica il comportamento del thread.</returns>
        public static DpiHostingBehavior GetThreadDpiHostingBehavior()
        {
            return (DpiHostingBehavior)HighDPIFunctions.GetThreadDpiHostingBehavior();
        }

        /// <summary>
        /// Imposta il comportamento del thread relativamente all'hosting di finestre con contesto di consapevolezza DPI diverso.
        /// </summary>
        /// <param name="NewBehavior">Nuovo comportamento.</param>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static void SetThreadDpiHostingBehavior(DpiHostingBehavior NewBehavior)
        {
            DPI_HOSTING_BEHAVIOR FormerBehaviour = HighDPIFunctions.SetThreadDpiHostingBehavior((DPI_HOSTING_BEHAVIOR)NewBehavior);
            if (FormerBehaviour is DPI_HOSTING_BEHAVIOR.DPI_HOSTING_BEHAVIOR_INVALID)
            {
                throw new InvalidEnumArgumentException("Invalid behavior.", (int)NewBehavior, typeof(DpiHostingBehavior));
            }
        }

        /// <summary>
        /// Recupera il comportamento di una finestra relativamente all'hosting di finestre con contesto di consapevolezza DPI diverso.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> che si riferisce alla finestra.</param>
        /// <returns>Un valore dell'enumerazione <see cref="DpiHostingBehavior"/> che indica il comportamento della finestra.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DpiHostingBehavior GetWindowDpiHostingBehavior(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            return (DpiHostingBehavior)HighDPIFunctions.GetWindowDpiHostingBehavior(WindowInfo.Handle);
        }
    }
}