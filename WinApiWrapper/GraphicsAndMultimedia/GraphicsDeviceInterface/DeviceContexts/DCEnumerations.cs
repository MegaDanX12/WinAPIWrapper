namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts
{
    /// <summary>
    /// Enumerazioni usate dai contesti dispositivo.
    /// </summary>
    internal static class DCEnumerations
    {
        /// <summary>
        /// Capacità del dispositivo.
        /// </summary>
        internal enum DeviceCapabilities
        {
            /// <summary>
            /// Versione del driver.
            /// </summary>
            DRIVERVERSION,
            /// <summary>
            /// Tecnologia del dispositivo.
            /// </summary>
            TECHNOLOGY = 2,
            /// <summary>
            /// Larghezza, in millimetri, dello schermo fisico.
            /// </summary>
            HORZSIZE = 4,
            /// <summary>
            /// Altezza, in millimetri, dello schermo fisico.
            /// </summary>
            VERTSIZE = 6,
            /// <summary>
            /// Larghezza, in pixel, dello schermo.
            /// </summary>
            /// <remarks>Per le stampanti, la larghezza, in pixel, dell'area stampabile.</remarks>
            HORZRES = 8,
            /// <summary>
            /// Altezza, in linee raster, dello schermo.
            /// </summary>
            /// <remarks>Per le stampanti, l'altezza, in pixel, dell'area stampabile.</remarks>
            VERTRES = 10,
            /// <summary>
            /// Numero di bit dei colori adiacenti per ogni pixel.
            /// </summary>
            BITSPIXEL = 12,
            /// <summary>
            /// Numero di piiani dei colori.
            /// </summary>
            PLANES = 14,
            /// <summary>
            /// Numero di pennelli specifici del dispositivo.
            /// </summary>
            NUMBRUSHES = 16,
            /// <summary>
            /// Numero di penne specifiche del dispositivo.
            /// </summary>
            NUMPENS = 18,
            /// <summary>
            /// Numero di evidenziatori specifici del dispositivo.
            /// </summary>
            NUMMARKERS = 20,
            /// <summary>
            /// Numero di font specifici del dispositivo.
            /// </summary>
            NUMFONTS = 22,
            /// <summary>
            /// Numero di voci nella tabella dei colori del dispositivo, se il dispositivo ha una profondità di colore non superiore a 8 bit per pixel.
            /// </summary>
            /// <remarks>Per dispositivi con profondità dei colori superiore, il valore restituito è 1.</remarks>
            NUMCOLORS = 24,
            /// <summary>
            /// Capacità di disegno delle curve.
            /// </summary>
            CURVECAPS = 28,
            /// <summary>
            /// Capacità di disegno delle linee.
            /// </summary>
            LINECAPS = 30,
            /// <summary>
            /// Capacità di disegno dei poligoni.
            /// </summary>
            POLYGONALCAPS = 32,
            /// <summary>
            /// Capacità di disegno del testo.
            /// </summary>
            TEXTCAPS = 34,
            /// <summary>
            /// Indica la capacità di taglio del dispositivo.
            /// </summary>
            /// <remarks>1, se il dispositivo può essere tagliato a un rettangolo, altrimenti 0.</remarks>
            CLIPCAPS = 36,
            /// <summary>
            /// Capacità raster del dispositivo.
            /// </summary>
            RASTERCAPS = 38,
            /// <summary>
            /// Larghezza relativa del pixel del dispositivo usato per il disegno di una linea.
            /// </summary>
            ASPECTX = 40,
            /// <summary>
            /// Altezza relativa del pixel del dispositivo usato per il disegno di una linea.
            /// </summary>
            ASPECTY = 42,
            /// <summary>
            /// Larghezza diagonale del pixel del dispositivo usato per il disegno di una linea.
            /// </summary>
            ASPECTXY = 44,
            /// <summary>
            /// Numero di pixel per inch logico per la larghezza dello schermo.
            /// </summary>
            /// <remarks>In un sistema a display multipli, questo valore è uguale per ogni monitor.</remarks>
            LOGPIXELSX = 88,
            /// <summary>
            /// Numero di pixel per inch logico per l'altezza dello schermo.
            /// </summary>
            /// <remarks>In un sistema a display multipli, questo valore è uguale per ogni monitor.</remarks>
            LOGPIXELSY = 90,
            /// <summary>
            /// Numero di voci nella tavolozza di sistema.
            /// </summary>
            SIZEPALETTE = 104,
            /// <summary>
            /// Numero di voci riservate nella tavolozza di sistema.
            /// </summary>
            NUMRESERVED = 106,
            /// <summary>
            /// Effettiva risoluzione del colore del dispositivo, in bit per pixel.
            /// </summary>
            COLORRES = 108,
            /// <summary>
            /// Larghezza della pagina fisica, in unità dispositivo.
            /// </summary>
            PHYSICALWIDTH = 110,
            /// <summary>
            /// Altezza della pagina fisica, in unità dispositivo.
            /// </summary>
            PHYSICALHEIGHT = 111,
            /// <summary>
            /// Distanza, in unità dispositivo, dal bordo sinistro della pagina fisica al bordo sinistro dell'area stampabile.
            /// </summary>
            PHYSICALOFFSETX,
            /// <summary>
            /// Distanza, in unità dispositivo, dal bordo superiore della pagina fisica al bordo superiore dell'area stampabile.
            /// </summary>
            PHYSICALOFFSETY,
            /// <summary>
            /// Fattore di scala per l'asse x della stampante.
            /// </summary>
            SCALINGFACTORX,
            /// <summary>
            /// Fattore di scala per l'asse y della stampante.
            /// </summary>
            SCALINGFACTORY,
            /// <summary>
            /// Attuale frequenza di aggiornamento del dispositivo,in Hz.
            /// </summary>
            VREFRESH,
            /// <summary>
            /// Larghezza dell'intero desktop, in pixel.
            /// </summary>
            DESKTOPVERTRES,
            /// <summary>
            /// Altezza dell'intero desktop, in pixel.
            /// </summary>
            DESKTOPHORZRES,
            /// <summary>
            /// Allineamento orizzontale di disegno preferito, espresso come multiplo di pixel.
            /// </summary>
            /// <remarks>0 indica che il dispositivo è accelerato e può essere usato qualunque allineamento.</remarks>
            BLTALIGNMENT,
            /// <summary>
            /// Capacità relativo allo shading e al blending del dispositivo.
            /// </summary>
            SHADEBLENDCAPS,
            /// <summary>
            /// Capacità di gestione del color del dispositivo.
            /// </summary>
            COLORMGMTCAPS
        }

        /// <summary>
        /// Tecnologia del dispositivo.
        /// </summary>
        internal enum DeviceTecnology
        {
            /// <summary>
            /// Plotter vettori.
            /// </summary>
            DT_PLOTTER,
            /// <summary>
            /// Display raster.
            /// </summary>
            DT_RASDISPLAY,
            /// <summary>
            /// Stampante raster.
            /// </summary>
            DT_RASPRINTER,
            /// <summary>
            /// Telecamera raster.
            /// </summary>
            DT_RASCAMERA,
            /// <summary>
            /// Flusso di caratteri.
            /// </summary>
            DT_CHARSTREAM,
            /// <summary>
            /// Metafile.
            /// </summary>
            DT_METAFILE,
            /// <summary>
            /// File di display.
            /// </summary>
            DT_DISPFILE
        }

        /// <summary>
        /// Capacità di shading e blending.
        /// </summary>
        internal enum ShadingBlendingCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            SB_NONE,
            /// <summary>
            /// In grado di gestire il valore di transparenza alpha (campo <see cref="GDIStructures.BLENDFUNCTION.SourceConstantAlpha"/>) .
            /// </summary>
            SB_CONST_ALPHA,
            /// <summary>
            /// In grado di gestire l'alpha per pixel.
            /// </summary>
            SB_PIXEL_ALPHA,
            /// <summary>
            /// In grado di gestire l'alpha premoltiplicato.
            /// </summary>
            SB_PREMULT_ALPHA = 4,
            /// <summary>
            /// In grado di riempire rettangoli a modo della funzione <see cref="GDIFunctions.GradientFill"/>.
            /// </summary>
            SB_GRAD_RECT = 16,
            /// <summary>
            /// In grado di riempire trinagoli a modo della funzione <see cref="GDIFunctions.GradientFill"/>.
            /// </summary>
            SB_GRAD_TRI = 32
        }

        /// <summary>
        /// Capacità raster.
        /// </summary>
        internal enum RasterCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            RC_NONE,
            /// <summary>
            /// In grado di trasferire bitmap.
            /// </summary>
            RC_BITBLT,
            /// <summary>
            /// Richiede supporto banding.
            /// </summary>
            RC_BANDING,
            /// <summary>
            /// In grado di eseguire lo scaling.
            /// </summary>
            RC_SCALING = 4,
            /// <summary>
            /// In grado di supportare bitmap più grandi di 64 KB.
            /// </summary>
            RC_BITMAP64 = 8,
            /// <summary>
            /// Supporta la versione 2.0 delle chiamate output.
            /// </summary>
            RC_GDI20_OUTPUT = 16,
            /// <summary>
            /// 
            /// </summary>
            RC_GDI20_STATE = 32,
            /// <summary>
            /// 
            /// </summary>
            RC_SAVEBITMAP = 64,
            /// <summary>
            /// Supporta le funzioni <see cref="Bitmaps.BitmapFunctions.SetDIBits"/> e <see cref="Bitmaps.BitmapFunctions.GetDIBits"/>.
            /// </summary>
            RC_DI_BITMAP = 128,
            /// <summary>
            /// Specifica un dispositivo basato su tavolozza.
            /// </summary>
            RC_PALETTE = 256,
            /// <summary>
            /// In grado di supportare la funzione <see cref="Bitmaps.BitmapFunctions.SetDIBitsToDevice"/>.
            /// </summary>
            RC_DIBTODEV = 512,
            /// <summary>
            /// Supporta font più grandi di 64 KB.
            /// </summary>
            RC_BIGFONT = 1024,
            /// <summary>
            /// In grado di eseguire la funzione <see cref="Bitmaps.BitmapFunctions.StretchBlt"/>.
            /// </summary>
            RC_STRETCHBLT = 2048,
            /// <summary>
            /// In grado di eseguire la funzione <see cref="Bitmaps.BitmapFunctions.FloodFill"/>.
            /// </summary>
            RC_FLOODFILL = 4096,
            /// <summary>
            /// In grado di eseguire la funzione <see cref="Bitmaps.BitmapFunctions.StretchDIBits"/>.
            /// </summary>
            RC_STRETCHDIB = 8192,
            /// <summary>
            /// 
            /// </summary>
            RC_OP_DX_OUTPUT = 16384,
            /// <summary>
            /// 
            /// </summary>
            RC_DEVBITS = 32768
        }

        /// <summary>
        /// Capacità di disegno delle curve.
        /// </summary>
        internal enum CurveCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            CC_NONE,
            /// <summary>
            /// In grado di disegnare curve.
            /// </summary>
            CC_CIRCLES,
            /// <summary>
            /// In grado di disegnare spicchi di torta.
            /// </summary>
            CC_PIE,
            /// <summary>
            /// In grado di disegnare archi di accordi.
            /// </summary>
            CC_CHORD = 4,
            /// <summary>
            /// In grado di disegnare ellissi.
            /// </summary>
            CC_ELLIPSES = 8,
            /// <summary>
            /// In grado di disegnare bordi spessi.
            /// </summary>
            CC_WIDE = 16,
            /// <summary>
            /// In grado di disegnare bordi in stile.
            /// </summary>
            CC_STYLED = 32,
            /// <summary>
            /// In grado di disegnare bordi spessi in stile.
            /// </summary>
            CC_WIDESTYLED = 64,
            /// <summary>
            /// In grado di disegnare interni.
            /// </summary>
            CC_INTERIORS = 128,
            /// <summary>
            /// In grado di disegnare rettangoli arrotondati.
            /// </summary>
            CC_ROUNDRECT = 256
        }

        /// <summary>
        /// Capacità di disegnare linee.
        /// </summary>
        internal enum LineCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            LC_NONE,
            /// <summary>
            /// In grado di disegnare polilinee.
            /// </summary>
            LC_POLYLINE = 2,
            /// <summary>
            /// In grado di disegnare evidenziatori.
            /// </summary>
            LC_MARKER = 4,
            /// <summary>
            /// In grado di disegnare evidenziatori multipli.
            /// </summary>
            LC_POLYMARKER = 8,
            /// <summary>
            /// In grado di disegnare linee spesse.
            /// </summary>
            LC_WIDE = 16,
            /// <summary>
            /// In grado di disegnare linee in stile.
            /// </summary>
            LC_STYLED = 32,
            /// <summary>
            /// In grado di disegnare linee spesse in stile.
            /// </summary>
            LC_WIDESTYLED = 64,
            /// <summary>
            /// In grado di disegnare interni.
            /// </summary>
            LC_INTERIORS = 128
        }

        /// <summary>
        /// Capacità di disegno dei poligoni.
        /// </summary>
        internal enum PolygonalCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            PC_NONE,
            /// <summary>
            /// In grado di disegnare poligoni alternate-fill.
            /// </summary>
            PC_POLYGON,
            /// <summary>
            /// In grado di disegnare rettangoli.
            /// </summary>
            PC_RECTANGLE,
            /// <summary>
            /// In grado di disegnare poligoni tortuosi.
            /// </summary>
            PC_WINDPOLYGON = 4,
            /// <summary>
            /// In grado di disegnare poligoni tortuosi.
            /// </summary>
            PC_TRAPEZOID = PC_WINDPOLYGON,
            /// <summary>
            /// In grado di disegnare una singola scanline.
            /// </summary>
            PC_SCANLINE = 8,
            /// <summary>
            /// In grado di disegnare bordi spessi.
            /// </summary>
            PC_WIDE = 16,
            /// <summary>
            /// In grado di disegnare bordi in stile.
            /// </summary>
            PC_STYLED = 32,
            /// <summary>
            /// In grado di disegnare bordi spessi in stile.
            /// </summary>
            PC_WIDESTYLED = 64,
            /// <summary>
            /// In grado di disegnare interni.
            /// </summary>
            PC_INTERIORS = 128,
            /// <summary>
            /// In grado di disegnare poligoni multipli.
            /// </summary>
            PC_POLYPOLYGON = 256,
            /// <summary>
            /// In grado di disegnare percorsi.
            /// </summary>
            PC_PATHS = 512
        }

        /// <summary>
        /// Capacità di disegno testo.
        /// </summary>
        internal enum TextCapabilities
        {
            /// <summary>
            /// In grado di regolare la precisione dell'output del carattere.
            /// </summary>
            TC_OP_CHARACTER = 1,
            /// <summary>
            /// In grado di regolare la precisione dell'output del tratto.
            /// </summary>
            TC_OP_STROKE,
            /// <summary>
            /// In grado di regolare la precisione del taglio del tratto.
            /// </summary>
            TC_CP_STROKE = 4,
            /// <summary>
            /// In grado di ruotare i caratteri di 90 gradi.
            /// </summary>
            TC_CR_90 = 8,
            /// <summary>
            /// In grado di ruotare i caratteri in qualunque modo.
            /// </summary>
            TC_CR_ANY = 16,
            /// <summary>
            /// In grado di scalare in modo indipendente in x e y.
            /// </summary>
            TC_SF_X_YINDEP = 32,
            /// <summary>
            /// In grado di raddoppiare i caratteri per lo scaling.
            /// </summary>
            TC_SA_DOUBLE = 64,
            /// <summary>
            /// Utilizza multipli interi sono per lo scaling dei caratteri.
            /// </summary>
            TC_SA_INTEGER = 128,
            /// <summary>
            /// Utilizza qualunque multiplo per lo scaling esatto dei caratteri.
            /// </summary>
            TC_SA_CONTIN = 256,
            /// <summary>
            /// In grado di disegnare caratteri double-weight.
            /// </summary>
            TC_EA_DOUBLE = 512,
            /// <summary>
            /// In grado di disegnare caratteri in corsivo.
            /// </summary>
            TC_IA_ABLE = 1024,
            /// <summary>
            /// In grado di disegnare caratteri sottolineati.
            /// </summary>
            TC_UA_ABLE = 2048,
            /// <summary>
            /// In grado di disegnare caratteri sbarrati.
            /// </summary>
            TC_SO_ABLE = 4096,
            /// <summary>
            /// In grado di disegnare font raster.
            /// </summary>
            TC_RA_ABLE = 8192,
            /// <summary>
            /// In grado di disegnare vector fonts.
            /// </summary>
            TC_VA_ABLE = 16384,
            /// <summary>
            /// Riservato.
            /// </summary>
            TC_RESERVED = 32768,
            /// <summary>
            /// Non può scorrere usando il trasferimento bit-block.
            /// </summary>
            TC_SCROLLBLT = 65536
        }

        /// <summary>
        /// Capacità di gestione dei colori.
        /// </summary>
        internal enum ColorManagementCapabilities
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            CM_NONE,
            /// <summary>
            /// Può eseguire ICM sul driver del dispositivo o sul dispositivo.
            /// </summary>
            CM_DEVICE_ICM,
            /// <summary>
            /// In grado di impostare e recuperare la correzione gamma.
            /// </summary>
            CM_GAMMA_RAMP,
            /// <summary>
            /// Può accettare profili ICC nello spazio dei colori CMYK.
            /// </summary>
            CM_CMYK_COLOR = 4
        }

        /// <summary>
        /// Tipo di oggetto GDI.
        /// </summary>
        internal enum GDIObjectType
        {
            /// <summary>
            /// Si è verificato un errore.
            /// </summary>
            Error,
            /// <summary>
            /// Penna.
            /// </summary>
            OBJ_PEN = 1,
            /// <summary>
            /// Pennello.
            /// </summary>
            OBJ_BRUSH,
            /// <summary>
            /// Contesto dispositivo.
            /// </summary>
            OBJ_DC,
            /// <summary>
            /// Contesto dispositivo metafile.
            /// </summary>
            OBJ_METADC,
            /// <summary>
            /// Tavolozza.
            /// </summary>
            OBJ_PAL,
            /// <summary>
            /// Font.
            /// </summary>
            OBJ_FONT,
            /// <summary>
            /// Bitmap.
            /// </summary>
            OBJ_BITMAP,
            /// <summary>
            /// Regione.
            /// </summary>
            OBJ_REGION,
            /// <summary>
            /// Metafile.
            /// </summary>
            OBJ_METAFILE,
            /// <summary>
            /// Contesto dispositivo memoria.
            /// </summary>
            OBJ_MEMDC,
            /// <summary>
            /// Penna estesa.
            /// </summary>
            OBJ_EXTPEN,
            /// <summary>
            /// Contesto dispositivo metafile migliorato.
            /// </summary>
            OBJ_ENHMETADC,
            /// <summary>
            /// Metafile migliorato.
            /// </summary>
            OBJ_ENHMETAFILE,
            /// <summary>
            /// Spazio dei colori.
            /// </summary>
            OBJ_COLORPSACE
        }
    }
}