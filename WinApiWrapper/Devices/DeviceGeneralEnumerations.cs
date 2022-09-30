namespace WinApiWrapper.Devices
{
    /// <summary>
    /// Enumerazioni generali usate per i dispositivi.
    /// </summary>
    internal static class DeviceGeneralEnumerations
    {
        /// <summary>
        /// Membri validi per la struttura <see cref="DeviceGeneralStructures.DEVMODESCREEN"/> e <see cref="DeviceGeneralStructures.DEVMODEPRINTER"/>.
        /// </summary>
        [Flags]
        internal enum DevmodeStructureValidMembers
        {

            DM_ORIENTATION = 1,

            DM_PAPERSIZE = 2,

            DM_PAPERLENGTH = 4,

            DM_PAPERWIDTH = 8,

            DM_SCALE = 16,

            DM_POSITION = 32,

            DM_NUP = 64,

            DM_DISPLAYORIENTATION = 128,

            DM_COPIES = 256,

            DM_DEFAULTSOURCE = 512,

            DM_PRINTQUALITY = 1024,

            DM_COLOR = 2048,

            DM_DUPLEX = 4096,

            DM_YRESOLUTION = 8192,

            DM_TTOPTION = 16384,

            DM_COLLATE = 32768,

            DM_FORMNAME = 65536,

            DM_LOGPIXELS = 131072,

            DM_BITSPERPEL = 262144,

            DM_PELSWIDTH = 524288,
            
            DM_PELSHEIGHT = 1048576,

            DM_DISPLAYFLAGS = 207152,

            DM_DISPLAYFREQUENCY = 4194304,

            DM_ICMMETHOD = 8388608,

            DM_ICMINTENT = 1677216,

            DM_MEDIATYPE = 33554432,

            DM_DITHERTYPE = 67108864,

            DM_PANNINGWIDTH = 134217728,

            DM_PANNINGHEIGHT = 268435456,

            DM_DISPLAYFIXEDOUTPUT = 536870912
        }

        /// <summary>
        /// Orientamento della pagina.
        /// </summary>
        internal enum PageOrientation : short
        {
            /// <summary>
            /// Verticale.
            /// </summary>
            DMORIENT_PORTRAIT = 1,
            /// <summary>
            /// Orizzontale.
            /// </summary>
            DMORIENT_LANDSCAPE
        }

        /// <summary>
        /// Fonte della carta.
        /// </summary>
        internal enum PrintingSource : short
        {

            DMBIN_UPPER = 1,

            DMBIN_ONLYONE = DMBIN_UPPER,

            DMBIN_LOWER,

            DMBIN_MIDDLE,

            DMBIN_MANUAL,

            DMBIN_ENVELOPE,

            DMBIN_ENVMANUAL,

            DMBIN_AUTO,

            DMBIN_TRACTOR,

            DMBIN_SMALLFMT,

            DMBIN_LARGEFMT,

            DMBIN_LARGECAPACITY,

            DMBIN_CASSETTE,

            DMBIN_FORMSOURCE
        }

        /// <summary>
        /// Qualità di stampa.
        /// </summary>
        internal enum PrintingQuality : short
        {
            /// <summary>
            /// Bozza.
            /// </summary>
            DMRES_DRAFT = -1,
            /// <summary>
            /// Bassa qualità.
            /// </summary>
            DMRES_LOW = -2,
            /// <summary>
            /// Qualità normale.
            /// </summary>
            DMRES_MEDIUM = -3,
            /// <summary>
            /// Qualità alta.
            /// </summary>
            DMRES_HIGH = -4
        }

        /// <summary>
        /// Rotazione dello schermo.
        /// </summary>
        internal enum ScreenOrientation
        {
            /// <summary>
            /// Rotazione predefinita.
            /// </summary>
            DMDO_DEFAULT,
            /// <summary>
            /// Rotazione di 90°.
            /// </summary>
            DMDO_90,
            /// <summary>
            /// Rotazione di 180°.
            /// </summary>
            DMDO_180,
            /// <summary>
            /// Rotazione di 270°.
            /// </summary>
            DMDO_270
        }

        /// <summary>
        /// Modalità di visualizzazione di immagini con risoluzione più bassa di quella dello schermo.
        /// </summary>
        internal enum LowerResolutionPresentationMode
        {
            /// <summary>
            /// Impostazione predefinita.
            /// </summary>
            DMDFO_DEFAULT,
            /// <summary>
            /// Immagine allargata.
            /// </summary>
            DMDFO_STRETCH,
            /// <summary>
            /// Immagine centrata.
            /// </summary>
            DMDFO_CENTER
        }

        /// <summary>
        /// Modalità di stampa colore.
        /// </summary>
        internal enum PrintingColors : short
        {
            /// <summary>
            /// Bianco e nero.
            /// </summary>
            DMCOLOR_MONOCHROME = 1,
            /// <summary>
            /// Colore.
            /// </summary>
            DMCOLOR_COLOR
        }

        /// <summary>
        /// Modalità di stampa duplex.
        /// </summary>
        internal enum DuplexPrintingMode : short
        {
            /// <summary>
            /// Stampa a faccia singola.
            /// </summary>
            DMDUP_SIMPLEX = 1,
            /// <summary>
            /// Stampa a doppia faccia, usando il bordo lungo.
            /// </summary>
            DMDUP_VERTICAL,
            /// <summary>
            /// Stampa a doppia faccia, usando il bordo corto.
            /// </summary>
            DMDUP_HORIZONTAL
        }

        /// <summary>
        /// Impostazione di fascicolazione.
        /// </summary>
        internal enum CollateSetting : short
        {
            /// <summary>
            /// Fascicolazione disabilitata.
            /// </summary>
            DMCOLLATE_FALSE,
            /// <summary>
            /// Fasciolazione abilitata.
            /// </summary>
            DMCOLLATE_TRUE
        }

        /// <summary>
        /// Modalità di gestione della stampa di pagine multiple su singola pagina fisica.
        /// </summary>
        internal enum N_UPPrintHandlingMode
        {
            /// <summary>
            /// Gestito dal sistema di stampa.
            /// </summary>
            DMNUP_SYSTEM = 1,
            /// <summary>
            /// L'applicazione gestisce l'operazione.
            /// </summary>
            DNUP_ONEUP
        }

        /// <summary>
        /// Modalità di gestione dell'ICM.
        /// </summary>
        internal enum IcmMethod
        {
            /// <summary>
            /// Nessuna.
            /// </summary>
            DMICMMETHOD_NONE = 1,
            /// <summary>
            /// Gestito dal sistema.
            /// </summary>
            DMICMMETHOD_SYSTEM,
            /// <summary>
            /// Gestito dal driver.
            /// </summary>
            DMICMMETHOD_DRIVER,
            /// <summary>
            /// Gestito dal dispositivo.
            /// </summary>
            DMICMMETHOD_DEVICE,
            /// <summary>
            /// Valore iniziale per modalità specifiche del dispositivo.
            /// </summary>
            DMICMMETHOD_USER = 256
        }

        /// <summary>
        /// Operazione ICM.
        /// </summary>
        internal enum IcmIntents
        {
            /// <summary>
            /// Saturazione colore massimizzata.
            /// </summary>
            DMICM_SATURATE = 1,
            /// <summary>
            /// Contrasto colore massimizzato.
            /// </summary>
            DMICM_CONTRAST,
            /// <summary>
            /// Uso di una specifica metrica di colore.
            /// </summary>
            DMICM_COLORIMETRIC,
            /// <summary>
            /// Uso di una specifica metrica di colore.
            /// </summary>
            DMICM_ABS_COLORIMETRIC,
            /// <summary>
            /// Valore iniziale per operazioni specifiche del dispositivo.
            /// </summary>
            DMICM_USER = 256
        }

        /// <summary>
        /// Tipo di carta.
        /// </summary>
        internal enum MediaType
        {
            /// <summary>
            /// Standard.
            /// </summary>
            DMMEDIA_STANDARD = 1,
            /// <summary>
            /// Trasparente.
            /// </summary>
            DMMEDIA_TRANSPARENCY,
            /// <summary>
            /// Lucida.
            /// </summary>
            DMMEDIA_GLOSSY,
            /// <summary>
            /// Valore iniziale per tipi specifici del dispositivo.
            /// </summary>
            DMMEDIA_USER = 256
        }

        /// <summary>
        /// Tipo di dithering.
        /// </summary>
        internal enum DitherType
        {
            /// <summary>
            /// Nessuno.
            /// </summary>
            DMDITHER_NONE = 1,
            /// <summary>
            /// Eseguito in modo grossolano. 
            /// </summary>
            DMDITHER_COARSE,
            /// <summary>
            /// Eseguito con un pennello fine.
            /// </summary>
            DMDITHER_FINE,
            /// <summary>
            /// Lineart.
            /// </summary>
            DMDITHER_LINEART,
            /// <summary>
            /// Lineart.
            /// </summary>
            DMDITHER_ERRORDIFFUSION,
            /// <summary>
            /// Lineart.
            /// </summary>
            DMDITHER_RESERVED6,
            /// <summary>
            /// Lineart.
            /// </summary>
            DMDITHER_RESERVED7,
            /// <summary>
            /// Lineart.
            /// </summary>
            DMDITHER_RESERVED8,
            /// <summary>
            /// Lineart.
            /// </summary>
            DMDITHER_RESERVED9,
            /// <summary>
            /// Il dispositivo esegue la scala di grigi.
            /// </summary>
            DMDITHER_GRAYSCALE,
            /// <summary>
            /// Valore iniziale per comportamento specifici del dispositivo.
            /// </summary>
            DMDITHER_USER = 256
        }
    }
}