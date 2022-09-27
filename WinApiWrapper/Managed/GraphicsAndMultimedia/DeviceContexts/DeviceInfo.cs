using static WinApiWrapper.Managed.GraphicsAndMultimedia.DeviceContexts.Enumerations;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts.DCFunctions;
using System.Drawing;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants;
using WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts;

namespace WinApiWrapper.Managed.GraphicsAndMultimedia.DeviceContexts
{
    /// <summary>
    /// Informazioni su un dispositivo.
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// Handle al contesto del dispositivo.
        /// </summary>
        internal HDC DeviceContextHandle { get; }

        /// <summary>
        /// Versione del driver.
        /// </summary>
        public int DriverVersion { get; }

        /// <summary>
        /// Tecnologia del dispositivo.
        /// </summary>
        public DeviceTechnology Technology { get; }

        /// <summary>
        /// Numero di piani di colore.
        /// </summary>
        public int PlanesCount { get; }

        /// <summary>
        /// Numero di pennelli specifici del dispositivo.
        /// </summary>
        public int BrushesCount { get; }

        /// <summary>
        /// Numero di penne specifiche del dispositivo.
        /// </summary>
        public int PensCount { get; }

        /// <summary>
        /// Numero di font specifici del dispositivo.
        /// </summary>
        public int FontsCount { get; }

        /// <summary>
        /// Numero di voci nella tabella di colori del dispositivo.
        /// </summary>
        public int ColorsCount { get; }

        /// <summary>
        /// Indica se il dispositivo può eseguire il taglio a un rettangolo.
        /// </summary>
        public bool ClipsToRectangle { get; }

        /// <summary>
        /// Numero di voci nella tavolozza di sistema.
        /// </summary>
        public int SystemPaletteSize { get; }

        /// <summary>
        /// Numero di voci riservate nella tavolozza di sistema.
        /// </summary>
        public int SystemPaletteReservedSize { get; }

        /// <summary>
        /// Effettiva risoluzione del colore, in bits per pixel.
        /// </summary>
        public int ColorResolution { get; }

        /// <summary>
        /// Capacità del dispositivo relative allo shading e al blending.
        /// </summary>
        public ShadingBlendingCapabilities[] ShadingBlendingCapabilities { get; }

        /// <summary>
        /// Capacità raster del dispositivo.
        /// </summary>
        public RasterCapabilities[] RasterCapabilities { get; }

        /// <summary>
        /// Capacità di disegno delle curve.
        /// </summary>
        public CurveCapabilities[] CurveCapabilities { get; }

        /// <summary>
        /// Capacità di disegno delle linee.
        /// </summary>
        public LineCapabilities[] LineCapabilities { get; }

        /// <summary>
        /// Capacità di disegno dei poligoni.
        /// </summary>
        public PolygonalCapabilities[] PolygonalCapabilities { get; }

        /// <summary>
        /// Capacità di disegno del testo.
        /// </summary>
        public TextCapabilities[] TextCapabilities { get; }

        /// <summary>
        /// Capacità di gestione colori.
        /// </summary>
        public ColorManagementCapabilities[] ColorManagementCapabilities { get; }

        /// <summary>
        /// Colore attuale del pennello.
        /// </summary>
        public Color CurrentBrushColor { get; }

        /// <summary>
        /// Colore attuale della penna.
        /// </summary>
        public Color CurrentPenColor { get; }

        /// <summary>
        /// Punto di origine finale della traslazione.
        /// </summary>
        public Point? TraslationOrigin { get; }

        /// <summary>
        /// Layout del contesto dispositivo.
        /// </summary>
        public DCLayout DeviceContextLayout { get; }

        /// <summary>
        /// Indica se l'orientamento dei bitmap è conservato.
        /// </summary>
        public bool IsOrientationPreserved { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DeviceInfo"/>.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo che rappresenta.</param>
        internal DeviceInfo(HDC DeviceContextHandle)
        {
            DriverVersion = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.DRIVERVERSION);
            Technology = (DeviceTechnology)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.TECHNOLOGY);
            PlanesCount = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.PLANES);
            BrushesCount = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.NUMBRUSHES);
            PensCount = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.NUMPENS);
            FontsCount = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.NUMFONTS);
            ColorsCount = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.NUMCOLORS);
            ClipsToRectangle = Convert.ToBoolean(GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.CLIPCAPS));
            SystemPaletteSize = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.SIZEPALETTE);
            SystemPaletteReservedSize = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.NUMRESERVED);
            ColorResolution = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.COLORRES);
            DCEnumerations.ShadingBlendingCapabilities ShBlCapabilitiesValue = (DCEnumerations.ShadingBlendingCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.SHADEBLENDCAPS);
            ShadingBlendingCapabilities = GetShadingBlendingCapabilities(ShBlCapabilitiesValue);
            DCEnumerations.RasterCapabilities RasterCapabilitiesValue = (DCEnumerations.RasterCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.RASTERCAPS);
            RasterCapabilities = GetRasterCapabilities(RasterCapabilitiesValue);
            DCEnumerations.CurveCapabilities CurveCapabilitiesValue = (DCEnumerations.CurveCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.CURVECAPS);
            CurveCapabilities = GetCurveCapabilities(CurveCapabilitiesValue);
            DCEnumerations.LineCapabilities LineCapabilitiesValue = (DCEnumerations.LineCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.LINECAPS);
            LineCapabilities = GetLineCapabilities(LineCapabilitiesValue);
            DCEnumerations.PolygonalCapabilities PolygonalCapabilitiesValue = (DCEnumerations.PolygonalCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.POLYGONALCAPS);
            PolygonalCapabilities = GetPolygonalCapabilities(PolygonalCapabilitiesValue);
            DCEnumerations.TextCapabilities TextCapabilitiesValue = (DCEnumerations.TextCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.TEXTCAPS);
            TextCapabilities = GetTextCapabilities(TextCapabilitiesValue);
            DCEnumerations.ColorManagementCapabilities ColorManagementCapabilitiesValue = (DCEnumerations.ColorManagementCapabilities)GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.COLORMGMTCAPS);
            ColorManagementCapabilities = GetColorManagementCapabilities(ColorManagementCapabilitiesValue);
            CurrentBrushColor = ColorTranslator.FromWin32((int)GetBrushColor(DeviceContextHandle));
            POINT TraslationOriginStructure = new();
            HMODULE TraslationOriginStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(TraslationOriginStructure));
            Marshal.StructureToPtr(TraslationOriginStructure, TraslationOriginStructurePointer, false);
            bool Result = GetTranslationOrigin(DeviceContextHandle, TraslationOriginStructurePointer);
            if (Result)
            {
                TraslationOrigin = GetTraslationOrigin((POINT)Marshal.PtrToStructure(TraslationOriginStructurePointer, typeof(POINT))!);
            }
            else
            {
                TraslationOrigin = null;
            }
            Marshal.FreeHGlobal(TraslationOriginStructurePointer);
            int LayoutInfo = GetLayout(DeviceContextHandle);
            if (LayoutInfo is 0)
            {
                DeviceContextLayout = DCLayout.LeftToRight;
                IsOrientationPreserved = false;
            }
            else
            {
                if (LayoutInfo is LAYOUT_RTL)
                {
                    DeviceContextLayout = DCLayout.RightToLeft;
                    IsOrientationPreserved = false;
                }
                else if (LayoutInfo is LAYOUT_BITMAPORIENTATIONPRESERVED)
                {
                    DeviceContextLayout = DCLayout.LeftToRight;
                    IsOrientationPreserved = true;
                }
                else
                {
                    DeviceContextLayout = DCLayout.RightToLeft;
                    IsOrientationPreserved = true;
                }
            }
        }

        /// <summary>
        /// Recupera le capacità di shading e blending del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private ShadingBlendingCapabilities[] GetShadingBlendingCapabilities(DCEnumerations.ShadingBlendingCapabilities Capabilities)
        {
            List<ShadingBlendingCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.ShadingBlendingCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.ShadingBlendingCapabilities)value))
                {
                    CapabilitiesList.Add((ShadingBlendingCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera le capacità raster del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private RasterCapabilities[] GetRasterCapabilities(DCEnumerations.RasterCapabilities Capabilities)
        {
            List<RasterCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.RasterCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.RasterCapabilities)value))
                {
                    CapabilitiesList.Add((RasterCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera le capacità di disegno di curve del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private CurveCapabilities[] GetCurveCapabilities(DCEnumerations.CurveCapabilities Capabilities)
        {
            List<CurveCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.CurveCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.CurveCapabilities)value))
                {
                    CapabilitiesList.Add((CurveCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera le capacità di disegno delle linee del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private LineCapabilities[] GetLineCapabilities(DCEnumerations.LineCapabilities Capabilities)
        {
            List<LineCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.LineCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.LineCapabilities)value))
                {
                    CapabilitiesList.Add((LineCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera le capacità di disegno dei poligoni del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private PolygonalCapabilities[] GetPolygonalCapabilities(DCEnumerations.PolygonalCapabilities Capabilities)
        {
            List<PolygonalCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.PolygonalCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.PolygonalCapabilities)value))
                {
                    CapabilitiesList.Add((PolygonalCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera le capacità di disegno del testo del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private TextCapabilities[] GetTextCapabilities(DCEnumerations.TextCapabilities Capabilities)
        {
            List<TextCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.TextCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.TextCapabilities)value))
                {
                    CapabilitiesList.Add((TextCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera le capacità di gestione colori del dispositivo.
        /// </summary>
        /// <param name="Capabilities">Valore composito che rappresenta le capacità del dispositivo.</param>
        /// <returns>Un array che indica le capacità del dispositivo.</returns>
        private ColorManagementCapabilities[] GetColorManagementCapabilities(DCEnumerations.ColorManagementCapabilities Capabilities)
        {
            List<ColorManagementCapabilities> CapabilitiesList = new();
            int[] Values = (int[])Enum.GetValues(typeof(DCEnumerations.ColorManagementCapabilities));
            foreach (int value in Values)
            {
                if (Capabilities.HasFlag((DCEnumerations.ColorManagementCapabilities)value))
                {
                    CapabilitiesList.Add((ColorManagementCapabilities)value);
                }
            }
            return CapabilitiesList.ToArray();
        }

        /// <summary>
        /// Recupera l'origine finale della traslazione.
        /// </summary>
        /// <param name="TraslationOrigin">Struttura <see cref="POINT"/> che contiene l'origine della traslazione.</param>
        /// <returns>Struttura <see cref="Point"/> che contiene l'origine della traslazione.</returns>
        private Point GetTraslationOrigin(POINT TraslationOrigin)
        {
            return new(TraslationOrigin.x, TraslationOrigin.y);
        }
    }
}