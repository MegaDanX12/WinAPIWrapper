using WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts.DCFunctions;

namespace WinApiWrapper.Managed.GraphicsAndMultimedia.DeviceContexts
{
    /// <summary>
    /// Informazioni su un dispositivo stampante.
    /// </summary>
    public class PrinterDeviceInfo : DeviceInfo
    {
        /// <summary>
        /// Larghezza, in pixel, dell'area stampabile della pagina.
        /// </summary>
        public int PrintableAreaWidth { get; }

        /// <summary>
        /// Altezza, in pixel, dell'area stampabile della pagina.
        /// </summary>
        public int PrintableAreaHeight { get; }

        /// <summary>
        /// Larghezza della pagina fisica.
        /// </summary>
        public int PhysicalPageWidth { get; }

        /// <summary>
        /// Altezza della pagina fisica.
        /// </summary>
        public int PhysicalPageHeight { get; }

        /// <summary>
        /// Distanza dal bordo sinistro della pagina fisica all bordo sinistro dell'area stampabile, in unità dispositivo.
        /// </summary>
        public int HorizontalOffset { get; }

        /// <summary>
        /// Distanza dal bordo superiore della pagina fisica al bordo superiore dell'area stampabile, in unità dispositivo.
        /// </summary>
        public int VerticalOffset { get; }

        /// <summary>
        /// Fattore di scala dell'asse x della stampante.
        /// </summary>
        public int HorizontalScaleFactor { get; }

        /// <summary>
        /// Fattore di scala dell'asse y della stampante.
        /// </summary>
        public int VerticalScaleFactor { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="PrinterDeviceInfo"/>.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto del dispositivo.</param>
        internal PrinterDeviceInfo(HDC DeviceContextHandle) : base(DeviceContextHandle)
        {
            PrintableAreaWidth = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.HORZRES);
            PrintableAreaHeight = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.VERTRES);
            PhysicalPageWidth = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.PHYSICALWIDTH);
            PhysicalPageHeight = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.PHYSICALHEIGHT);
            HorizontalOffset = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.PHYSICALOFFSETX);
            VerticalOffset = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.PHYSICALOFFSETY);
            HorizontalScaleFactor = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.SCALINGFACTORX);
            VerticalScaleFactor = GetDeviceCapabilities(DeviceContextHandle, DCEnumerations.DeviceCapabilities.SCALINGFACTORY);
        }
    }
}