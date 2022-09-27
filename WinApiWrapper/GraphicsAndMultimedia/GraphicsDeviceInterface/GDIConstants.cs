using WinApiWrapper.Devices.Printing.GDIPrint;

namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface
{
    /// <summary>
    /// Costanti GDI.
    /// </summary>
    internal static class GDIConstants
    {
        /// <summary>
        /// Trasparente.
        /// </summary>
        internal const int TRANSPARENT = 1;

        /// <summary>
        /// Opaco.
        /// </summary>
        internal const int OPAQUE = 2;

        /// <summary>
        /// Colore non valido.
        /// </summary>
        internal const int CLR_INVALID = -1;

        /// <summary>
        /// Errore GDI.
        /// </summary>
        internal const int GDI_ERROR = -1;

        /// <summary>
        /// Da destra a sinistra
        /// </summary>
        internal const int LAYOUT_RTL = 1;

        /// <summary>
        /// Dal basso verso l'alto.
        /// </summary>
        internal const int LAYOUT_BTT = 2;

        /// <summary>
        /// Verticale prima di orizzontale.
        /// </summary>
        internal const int LAYOUT_VBH = 4;

        /// <summary>
        /// Tutti i possibili valori di orientamento testo.
        /// </summary>
        internal const int LAYOUT_ORIENTATIONMASK = LAYOUT_RTL | LAYOUT_BTT | LAYOUT_VBH;

        /// <summary>
        /// Disattiva la riflessione.
        /// </summary>
        internal const int LAYOUT_BITMAPORIENTATIONPRESERVED = 8;

        /// <summary>
        /// Lunghezza del nome di un dispositivo.
        /// </summary>
        internal const int CCHDEVICENAME = 32;

        /// <summary>
        /// Versione della struttura <see cref="Devices.DeviceGeneralStructures.DEVMODESCREEN"/> e <see cref="Devices.DeviceGeneralStructures.DEVMODEPRINTER"/>.
        /// </summary>
        internal const int DM_SPECVERSION = 1025;
    }
}