using static WinApiWrapper.Devices.DeviceGeneralEnumerations;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;

namespace WinApiWrapper.Devices
{
    /// <summary>
    /// Strutture generali usate per i dispositivi.
    /// </summary>
    internal static class DeviceGeneralStructures
    {
        /// <summary>
        /// Caratteristiche di un display.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DEVMODESCREEN
        {
            /// <summary>
            /// Nome della DLL del driver dello schermo.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;
            /// <summary>
            /// Versione della struttura.
            /// </summary>
            public WORD StructureVersion;
            /// <summary>
            /// Versione del driver.
            /// </summary>
            public WORD DriverVersion;
            /// <summary>
            /// Dimensione, in byte, della parte pubblica della struttura.
            /// </summary>
            public WORD Size;
            /// <summary>
            /// Numero di byte riservati ai dati privati del driver che seguono la struttura.
            /// </summary>
            public WORD DriverExtra;
            /// <summary>
            /// Indica quali campi della struttura sono validi.
            /// </summary>
            public DevmodeStructureValidMembers Fields;
            /// <summary>
            /// Coordinate dell'angolo superiore sinistro dello schermo.
            /// </summary>
            public POINT UpperLeftCornerCoordinates;
            /// <summary>
            /// Orientamento dello schermo.
            /// </summary>
            public ScreenOrientation Orientation;
            /// <summary>
            /// Modalità di presentazione di immagini a risoluzione più bassa.
            /// </summary>
            public LowerResolutionPresentationMode LowerResolutionPresentationMode;
            /// <summary>
            /// 
            /// </summary>
            public PrintingColors Colors;

            public DuplexPrintingMode DuplexPrintingMode;

            public short YResolution;

            public CollateSetting Collate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string FormName;

            public WORD LogicalPixelPerInch;

            public DWORD BitsPerPel;

            public DWORD VisibleDeviceSurfaceWidth;

            public DWORD VisibleDeviceSurfaceHeight;

            public DWORD DisplayFlags;

            public DWORD DisplayFrequency;

            public IcmMethod ICMMethod;

            public IcmIntents ICMIntents;

            public MediaType MediaType;

            public DitherType DitherType;

            public DWORD Reserved1;

            public DWORD Reserved2;

            public DWORD PanningWidth;

            public DWORD PanningHeight;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DEVMODEPRINTER
        {

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;

            public WORD StructureVersion;

            public WORD DriverVersion;

            public WORD Size;

            public WORD DriverExtra;

            public DevmodeStructureValidMembers Fields;

            public PageOrientation Orientation;

            public DefaultPaperSize PaperSize;

            public short PaperLength;

            public short PaperWidth;

            public short Scale;

            public short Copies;

            public PrintingSource Source;

            public PrintingQuality Quality;

            public PrintingColors Colors;

            public DuplexPrintingMode DuplexPrintingMode;

            public short YResolution;

            public CollateSetting Collate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string FormName;

            public WORD LogicalPixelPerInch;

            public DWORD BitsPerPel;

            public DWORD VisibleDeviceSurfaceWidth;

            public DWORD VisibleDeviceSurfaceHeight;

            public DWORD DisplayFlags;

            public DWORD DisplayFrequency;

            public IcmMethod ICMMethod;

            public IcmIntents ICMIntents;

            public MediaType MediaType;

            public DitherType DitherType;

            public DWORD Reserved1;

            public DWORD Reserved2;

            public DWORD PanningWidth;

            public DWORD PanningHeight;
        }
    }
}