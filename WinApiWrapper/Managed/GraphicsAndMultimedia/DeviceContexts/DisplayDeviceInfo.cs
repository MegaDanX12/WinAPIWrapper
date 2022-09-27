using WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts.DCFunctions;

namespace WinApiWrapper.Managed.GraphicsAndMultimedia.DeviceContexts
{
    /// <summary>
    /// Informazioni su un display.
    /// </summary>
    public class DisplayDeviceInfo : DeviceInfo
    {
        /// <summary>
        /// Larghezza, in centimetri, dello schermo fisico.
        /// </summary>
        public int WidthCentimeters { get; }

        /// <summary>
        /// Altezza, in centimetri, dello schermo fisico.
        /// </summary>
        public int HeightCentimeters { get; }

        /// <summary>
        /// Larghezza, in pixel, dello schermo.
        /// </summary>
        public int WidthPixels { get; }

        /// <summary>
        /// Altezza, in linee raster, dello schermo.
        /// </summary>
        public int HeightRasterLines { get; }

        /// <summary>
        /// Numero di pixel per inch logico sulla larghezza dello schermo.
        /// </summary>
        public int WidthPixelPerLogicalInch { get; }

        /// <summary>
        /// Numero di pixel per inch logico sull'altezza dello schermo.
        /// </summary>
        public int HeightPixelPerLogicalInch { get; }

        /// <summary>
        /// Numero di bit di colore adiacente per ogni pixel.
        /// </summary>
        public int AdjacentColorBitsPerPixelCount { get; }

        /// <summary>
        /// Larghezza relativa di un pixel del dispositivo usato per disegnare le linee.
        /// </summary>
        public int PixelRelativeWidth { get; }

        /// <summary>
        /// Altezza relativa di un pixel del dispositivo usato per disegnare le linee.
        /// </summary>
        public int PixelRelativeHeight { get; }

        /// <summary>
        /// Diagonale di un pixel del dispositivo usato per disegnare le linee.
        /// </summary>
        public int PixelDiagonalWidth { get; }

        /// <summary>
        /// Frequenza di aggiornamento verticale, in Hz.
        /// </summary>
        public int VerticalRefreshRate { get; }

        /// <summary>
        /// Allineamento orizzontale preferito di disegno, espresso in un multipli di pixel.
        /// </summary>
        public int PreferredHorizontalDrawingAlignment { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DisplayDeviceInfo"/>.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo.</param>
        internal DisplayDeviceInfo(HDC DeviceContextHandle) : base(DeviceContextHandle)
        {
            WidthCentimeters = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.HORZSIZE) / 10;
            HeightCentimeters = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.VERTSIZE) / 10;
            WidthPixels = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.HORZRES);
            HeightRasterLines = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.VERTRES);
            WidthPixelPerLogicalInch = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.LOGPIXELSX);
            HeightPixelPerLogicalInch = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.LOGPIXELSY);
            AdjacentColorBitsPerPixelCount = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.BITSPIXEL);
            PixelRelativeWidth = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.ASPECTX);
            PixelRelativeHeight = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.ASPECTY);
            PixelDiagonalWidth = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.ASPECTXY);
            VerticalRefreshRate = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.VREFRESH);
            PreferredHorizontalDrawingAlignment = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.BLTALIGNMENT);
        }
    }
}