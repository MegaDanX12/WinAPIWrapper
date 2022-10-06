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
            /// Modalità di stampa colore.
            /// </summary>
            public PrintingColors Colors;
            /// <summary>
            /// Modalità di stampa duplex.
            /// </summary>
            public DuplexPrintingMode DuplexPrintingMode;
            /// <summary>
            /// Risoluzione verticale della stampante, in DPI.
            /// </summary>
            public short YResolution;
            /// <summary>
            /// Impostazione di fascicolazione.
            /// </summary>
            public CollateSetting Collate;
            /// <summary>
            /// Tipo di carta.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string FormName;
            /// <summary>
            /// Numero di pixel logici per inch del dispositivo di visualizzazione.
            /// </summary>
            public WORD LogicalPixelPerInch;
            /// <summary>
            /// Risoluzione del colore, in bits per pixel, di un dispositivo di visualizzazione.
            /// </summary>
            public DWORD BitsPerPel;
            /// <summary>
            /// Larghezza, in pixel, della superficie visibile di un dispositivo di visualizzazione.
            /// </summary>
            public DWORD VisibleDeviceSurfaceWidth;
            /// <summary>
            /// Altezza, in pixel, della superficie visibile di un dispositivo di visualizzazione.
            /// </summary>
            public DWORD VisibleDeviceSurfaceHeight;
            /// <summary>
            /// Modalità di visualizzazione del dispositivo.
            /// </summary>
            public DWORD DisplayFlags;
            /// <summary>
            /// Frequenza, in Hertz, del dispositivo di visualizzazione nella sua modalità attuale.
            /// </summary>
            public DWORD DisplayFrequency;
            /// <summary>
            /// Modalità di gestione dell'ICM.
            /// </summary>
            public IcmMethod ICMMethod;
            /// <summary>
            /// Operazione ICM.
            /// </summary>
            public IcmIntents ICMIntents;
            /// <summary>
            /// Tipo di carta.
            /// </summary>
            public MediaType MediaType;
            /// <summary>
            /// Tipo di dithering.
            /// </summary>
            public DitherType DitherType;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD Reserved1;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD Reserved2;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD PanningWidth;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD PanningHeight;
        }

        /// <summary>
        /// Caratteristiche di una stampante.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DEVMODEPRINTER
        {
            /// <summary>
            /// Nome della stampante.
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
            /// Orientamento della pagina.
            /// </summary>
            public PageOrientation Orientation;
            /// <summary>
            /// Dimensione della pagina.
            /// </summary>
            /// <remarks>Questo campo deve essere impostato a <see cref="DefaultPaperSize.None"/> se la lunghezza e la larghezza sono specificate in <see cref="PaperLength"/> e <see cref="PaperWidth"/>.</remarks>
            public DefaultPaperSize PaperSize;
            /// <summary>
            /// Lunghezza della pagina, in decimi di millimetro.
            /// </summary>
            /// <remarks>Questo campo ha priorità su <see cref="PaperSize"/>.</remarks>
            public short PaperLength;
            /// <summary>
            /// Larghezza della pagina, in decimi di millimetro.
            /// </summary>
            /// <remarks>Questo campo ha priorità su <see cref="PaperSize"/> e deve essere usato se <see cref="PaperLength"/> è impostato.</remarks>
            public short PaperWidth;
            /// <summary>
            /// Scala.
            /// </summary>
            public short Scale;
            /// <summary>
            /// Numero di copie.
            /// </summary>
            public short Copies;
            /// <summary>
            /// Fonte della carta.
            /// </summary>
            public PrintingSource Source;
            /// <summary>
            /// Qualità di stampa.
            /// </summary>
            public PrintingQuality Quality;
            /// <summary>
            /// Modalità di stampa colore.
            /// </summary>
            public PrintingColors Colors;
            /// <summary>
            /// Modalità di stampa duplex.
            /// </summary>
            public DuplexPrintingMode DuplexPrintingMode;
            /// <summary>
            /// Risoluzione verticale della stampante, in DPI.
            /// </summary>
            public short YResolution;
            /// <summary>
            /// Impostazione di fascicolazione.
            /// </summary>
            public CollateSetting Collate;
            /// <summary>
            /// Tipo di carta.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string FormName;
            /// <summary>
            /// Numero di pixel logici per inch del dispositivo di visualizzazione.
            /// </summary>
            public WORD LogicalPixelPerInch;
            /// <summary>
            /// Risoluzione del colore, in bits per pixel, di un dispositivo di visualizzazione.
            /// </summary>
            public DWORD BitsPerPel;
            /// <summary>
            /// Larghezza, in pixel, della superficie visibile di un dispositivo di visualizzazione.
            /// </summary>
            public DWORD VisibleDeviceSurfaceWidth;
            /// <summary>
            /// Altezza, in pixel, della superficie visibile di un dispositivo di visualizzazione.
            /// </summary>
            public DWORD VisibleDeviceSurfaceHeight;
            /// <summary>
            /// Modalità di gestione della stampa di pagine multiple su singola pagina fisica.
            /// </summary>
            public N_UPPrintHandlingMode N_UPPrintingHandleMode;
            /// <summary>
            /// Frequenza, in Hertz, del dispositivo di visualizzazione nella sua modalità attuale.
            /// </summary>
            public DWORD DisplayFrequency;
            /// <summary>
            /// Modalità di gestione dell'ICM.
            /// </summary>
            public IcmMethod ICMMethod;
            /// <summary>
            /// Operazione ICM.
            /// </summary>
            public IcmIntents ICMIntents;
            /// <summary>
            /// Tipo di carta.
            /// </summary>
            public MediaType MediaType;
            /// <summary>
            /// Tipo di dithering.
            /// </summary>
            public DitherType DitherType;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD Reserved1;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD Reserved2;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD PanningWidth;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD PanningHeight;
        }
    }
}