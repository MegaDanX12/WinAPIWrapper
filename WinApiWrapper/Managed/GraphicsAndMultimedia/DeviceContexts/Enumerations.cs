using WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts.DCEnumerations;

namespace WinApiWrapper.Managed.GraphicsAndMultimedia.DeviceContexts
{
    /// <summary>
    /// Enumerazioni usati dai contesti dispositivo.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Tecnologia dispositivo.
        /// </summary>
        public enum DeviceTechnology
        {
            /// <summary>
            /// Plotter vettori.
            /// </summary>
            VectorPlotter = DeviceTecnology.DT_PLOTTER,
            /// <summary>
            /// Display raster.
            /// </summary>
            RasterDisplay = DeviceTecnology.DT_RASDISPLAY,
            /// <summary>
            /// Stampante raster.
            /// </summary>
            RasterPrinter = DeviceTecnology.DT_RASPRINTER,
            /// <summary>
            /// Telecamera raster.
            /// </summary>
            RasterCamera = DeviceTecnology.DT_RASCAMERA,
            /// <summary>
            /// Flusso di caratteri.
            /// </summary>
            CharacterStream = DeviceTecnology.DT_CHARSTREAM,
            /// <summary>
            /// Metafile.
            /// </summary>
            Metafile = DeviceTecnology.DT_METAFILE,
            /// <summary>
            /// File display.
            /// </summary>
            DisplayFile = DeviceTecnology.DT_DISPFILE
        }

        /// <summary>
        /// Funzionalità di shading e blending.
        /// </summary>
        public enum ShadingBlendingCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NoSupport = DCEnumerations.ShadingBlendingCapabilities.SB_NONE,
            /// <summary>
            /// In grado di gestire il valore di transparenza alpha.
            /// </summary>
            HandlesConstantAlphaValue = DCEnumerations.ShadingBlendingCapabilities.SB_CONST_ALPHA,
            /// <summary>
            /// In grado di riempire rettangoli.
            /// </summary>
            CreatesGradientRectangles = DCEnumerations.ShadingBlendingCapabilities.SB_GRAD_RECT,
            /// <summary>
            /// In grado di riempire trinagoli.
            /// </summary>
            CreatesGradientTriangles = DCEnumerations.ShadingBlendingCapabilities.SB_GRAD_TRI,
            /// <summary>
            /// In grado di gestire l'alpha per pixel.
            /// </summary>
            HandlesPerPixelAlpha = DCEnumerations.ShadingBlendingCapabilities.SB_PIXEL_ALPHA,
            /// <summary>
            /// In grado di gestire l'alpha premoltiplicato.
            /// </summary>
            HandlesPremultipliedAlpha = DCEnumerations.ShadingBlendingCapabilities.SB_PREMULT_ALPHA
        }

        /// <summary>
        /// Funzionalità raster.
        /// </summary>
        public enum RasterCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NoSupport = DCEnumerations.RasterCapabilities.RC_NONE,
            /// <summary>
            /// Richiede supporto banding.
            /// </summary>
            RequiresBandingSupport = DCEnumerations.RasterCapabilities.RC_BANDING,
            /// <summary>
            /// In grado di trasferire bitmap.
            /// </summary>
            CanTransferBitmaps = DCEnumerations.RasterCapabilities.RC_BITBLT,
            /// <summary>
            /// In grado di supportare bitmap più grandi di 64 KB.
            /// </summary>
            SupportsLargeBitmaps = DCEnumerations.RasterCapabilities.RC_BITMAP64,
            /// <summary>
            /// Può impostare i bit in una bitmap.
            /// </summary>
            CanSetPixelsInBitmaps = DCEnumerations.RasterCapabilities.RC_DI_BITMAP,
            /// <summary>
            /// Può impostare i pixel di un rettangolo direttamente sul dispositivo.
            /// </summary>
            CanSetPixelsInRectangleOnDevice = DCEnumerations.RasterCapabilities.RC_DIBTODEV,
            /// <summary>
            /// In grado di eseguire flood fill.
            /// </summary>
            CanPerformFloodFills = DCEnumerations.RasterCapabilities.RC_FLOODFILL,
            /// <summary>
            /// Dispositivo basato su tavolozza.
            /// </summary>
            IsPaletteBased = DCEnumerations.RasterCapabilities.RC_PALETTE,
            /// <summary>
            /// In grado di eseguire lo scaling.
            /// </summary>
            CanScale = DCEnumerations.RasterCapabilities.RC_SCALING,
            /// <summary>
            /// In grado di allargare o comprimere bitmap.
            /// </summary>
            CanStretchCompressBitmaps = DCEnumerations.RasterCapabilities.RC_STRETCHBLT,
            /// <summary>
            /// In grado di allargare o comprimere le linee di colori perchè siano adatte a un rettangolo.
            /// </summary>
            CanStretchCompressColorRows = DCEnumerations.RasterCapabilities.RC_STRETCHDIB
        }

        /// <summary>
        /// Capacità di disegno delle curve.
        /// </summary>
        public enum CurveCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NoSupport = DCEnumerations.CurveCapabilities.CC_NONE,
            /// <summary>
            /// In grado di disegnare archi di accordi.
            /// </summary>
            CanDrawChordArcs = DCEnumerations.CurveCapabilities.CC_CHORD,
            /// <summary>
            /// In grado di disegnare curve.
            /// </summary>
            CanDrawCircles = DCEnumerations.CurveCapabilities.CC_CIRCLES,
            /// <summary>
            /// In grado di disegnare ellissi.
            /// </summary>
            CanDrawEllipses = DCEnumerations.CurveCapabilities.CC_ELLIPSES,
            /// <summary>
            /// In grado di disegnare interni.
            /// </summary>
            CanDrawInteriors = DCEnumerations.CurveCapabilities.CC_INTERIORS,
            /// <summary>
            /// In grado di disegnare spicchi di torta.
            /// </summary>
            CanDrawPieWedges = DCEnumerations.CurveCapabilities.CC_PIE,
            /// <summary>
            /// In grado di disegnare rettangoli arrotondati.
            /// </summary>
            CanDrawRoundedRectangles = DCEnumerations.CurveCapabilities.CC_ROUNDRECT,
            /// <summary>
            /// In grado di disegnare bordi in stile.
            /// </summary>
            CanDrawStyledBorders = DCEnumerations.CurveCapabilities.CC_STYLED,
            /// <summary>
            /// In grado di disegnare bordi spessi.
            /// </summary>
            CanDrawWideBorders = DCEnumerations.CurveCapabilities.CC_WIDE,
            /// <summary>
            /// In grado di disegnare bordi spessi in stile.
            /// </summary>
            CanDrawWideStyledBorders = DCEnumerations.CurveCapabilities.CC_WIDESTYLED
        }

        /// <summary>
        /// Capacità di disegno delle linee.
        /// </summary>
        public enum LineCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NoSupport = DCEnumerations.LineCapabilities.LC_NONE,
            /// <summary>
            /// In grado di disegnare interni.
            /// </summary>
            CanDrawInteriors = DCEnumerations.LineCapabilities.LC_INTERIORS,
            /// <summary>
            /// In grado di disegnare evidenziatori.
            /// </summary>
            CanDrawMarker = DCEnumerations.LineCapabilities.LC_MARKER,
            /// <summary>
            /// In grado di disegnare polilinee.
            /// </summary>
            CanDrawPolylines = DCEnumerations.LineCapabilities.LC_POLYLINE,
            /// <summary>
            /// In grado di disegnare evidenziatori multipli.
            /// </summary>
            CanDrawMultipleMarkers = DCEnumerations.LineCapabilities.LC_POLYMARKER,
            /// <summary>
            /// In grado di disegnare linee in stile.
            /// </summary>
            CanDrawSyledLines = DCEnumerations.LineCapabilities.LC_STYLED,
            /// <summary>
            /// In grado di disegnare linee spesse.
            /// </summary>
            CanDrawWideLines = DCEnumerations.LineCapabilities.LC_WIDE,
            /// <summary>
            /// In grado di disegnare linee spesse in stile.
            /// </summary>
            CanDrawWideStyledLines = DCEnumerations.LineCapabilities.LC_WIDESTYLED
        }

        /// <summary>
        /// Capacità di disegno dei poligoni.
        /// </summary>
        public enum PolygonalCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NoSupport = DCEnumerations.PolygonalCapabilities.PC_NONE,
            /// <summary>
            /// In grado di disegnare interni.
            /// </summary>
            CanDrawInteriors = DCEnumerations.PolygonalCapabilities.PC_INTERIORS,
            /// <summary>
            /// In grado di disegnare poligoni alternate-fill.
            /// </summary>
            CanDrawAlternateFillPolygons = DCEnumerations.PolygonalCapabilities.PC_POLYGON,
            /// <summary>
            /// In grado di disegnare rettangoli.
            /// </summary>
            CanDrawRectangles = DCEnumerations.PolygonalCapabilities.PC_RECTANGLE,
            /// <summary>
            /// In grado di disegnare una singola scanline.
            /// </summary>
            CanDrawSingleScanline = DCEnumerations.PolygonalCapabilities.PC_SCANLINE,
            /// <summary>
            /// In grado di disegnare bordi in stile.
            /// </summary>
            CanDrawStyledBorders = DCEnumerations.PolygonalCapabilities.PC_STYLED,
            /// <summary>
            /// In grado di disegnare bordi spessi.
            /// </summary>
            CanDrawWideBorders = DCEnumerations.PolygonalCapabilities.PC_WIDE,
            /// <summary>
            /// In grado di disegnare bordi spessi in stile.
            /// </summary>
            CanDrawWideStyledBorders = DCEnumerations.PolygonalCapabilities.PC_WIDESTYLED,
            /// <summary>
            /// In grado di disegnare poligoni tortuosi.
            /// </summary>
            CanDrawWindingFillPolygons = DCEnumerations.PolygonalCapabilities.PC_WINDPOLYGON
        }

        /// <summary>
        /// Capacità di disegno del testo.
        /// </summary>
        public enum TextCapabilities
        {
            /// <summary>
            /// In grado di regolare la precisione dell'output del carattere.
            /// </summary>
            CapableOfCharacterOutputPrecision = DCEnumerations.TextCapabilities.TC_OP_CHARACTER,
            /// <summary>
            /// In grado di regolare la precisione dell'output del tratto.
            /// </summary>
            CapableOfStrokeOutputPrecision = DCEnumerations.TextCapabilities.TC_OP_STROKE,
            /// <summary>
            /// In grado di regolare la precisione del taglio del tratto.
            /// </summary>
            CapableOfStrokeClipPrecision = DCEnumerations.TextCapabilities.TC_CP_STROKE,
            /// <summary>
            /// In grado di ruotare i caratteri di 90 gradi.
            /// </summary>
            CapableOf90DegreeCharacterRotation = DCEnumerations.TextCapabilities.TC_CR_90,
            /// <summary>
            /// In grado di ruotare i caratteri in qualunque modo.
            /// </summary>
            CapableOfAnyCharacterRotation = DCEnumerations.TextCapabilities.TC_CR_ANY,
            /// <summary>
            /// In grado di scalare in modo indipendente in x e y.
            /// </summary>
            XYIndipendentScaling = DCEnumerations.TextCapabilities.TC_SF_X_YINDEP,
            /// <summary>
            /// In grado di raddoppiare i caratteri per lo scaling.
            /// </summary>
            CanUseDoubledCharForScaling = DCEnumerations.TextCapabilities.TC_SA_DOUBLE,
            /// <summary>
            /// Utilizza multipli interi sono per lo scaling dei caratteri.
            /// </summary>
            UsesOnlyIntegerMultiplesForScaling = DCEnumerations.TextCapabilities.TC_SA_INTEGER,
            /// <summary>
            /// Utilizza qualunque multiplo per lo scaling esatto dei caratteri.
            /// </summary>
            UsesAnyMultiplesForExactScaling = DCEnumerations.TextCapabilities.TC_SA_CONTIN,
            /// <summary>
            /// In grado di disegnare caratteri double-weight.
            /// </summary>
            CanDrawDoubleWeightChars = DCEnumerations.TextCapabilities.TC_EA_DOUBLE,
            /// <summary>
            /// In grado di disegnare caratteri in corsivo.
            /// </summary>
            CanItalicize = DCEnumerations.TextCapabilities.TC_IA_ABLE,
            /// <summary>
            /// In grado di disegnare caratteri sottolineati.
            /// </summary>
            CanUnderline = DCEnumerations.TextCapabilities.TC_UA_ABLE,
            /// <summary>
            /// In grado di disegnare caratteri sbarrati.
            /// </summary>
            CanStrikeout = DCEnumerations.TextCapabilities.TC_SO_ABLE,
            /// <summary>
            /// In grado di disegnare font raster.
            /// </summary>
            CanDrawRasterFonts = DCEnumerations.TextCapabilities.TC_RA_ABLE,
            /// <summary>
            /// In grado di disegnare vector fonts.
            /// </summary>
            CanDrawVectorFonts = DCEnumerations.TextCapabilities.TC_VA_ABLE,
            /// <summary>
            /// Non può scorrere usando il trasferimento bit-block.
            /// </summary>
            CannotScrollUsingBitBlockTransfer = DCEnumerations.TextCapabilities.TC_SCROLLBLT
        }

        /// <summary>
        /// Capacità di gestione dei colori.
        /// </summary>
        public enum ColorManagementCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NoSupport = DCEnumerations.ColorManagementCapabilities.CM_NONE,
            /// <summary>
            /// Può accettare profili ICC nello spazio dei colori CMYK.
            /// </summary>
            CanAcceptCMYKColorSpaceICCColorProfile = DCEnumerations.ColorManagementCapabilities.CM_CMYK_COLOR,
            /// <summary>
            /// Può eseguire ICM sul driver del dispositivo o sul dispositivo.
            /// </summary>
            CanPerformICMOnDriverOrDevice = DCEnumerations.ColorManagementCapabilities.CM_DEVICE_ICM,
            /// <summary>
            /// In grado di impostare e recuperare la correzione gamma.
            /// </summary>
            CanAlterGammaValue = DCEnumerations.ColorManagementCapabilities.CM_GAMMA_RAMP
        }

        /// <summary>
        /// Layout del contesto del dispositivo.
        /// </summary>
        public enum DCLayout
        {
            /// <summary>
            /// Da sinistra a destra.
            /// </summary>
            LeftToRight,
            /// <summary>
            /// Da destra a sinistra.
            /// </summary>
            RightToLeft
        }
    }
}