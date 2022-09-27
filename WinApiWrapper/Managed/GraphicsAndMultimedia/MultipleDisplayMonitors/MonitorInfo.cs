using WinApiWrapper.Managed.General;

namespace WinApiWrapper.Managed.GraphicsAndMultimedia.MultipleDisplayMonitors
{
    /// <summary>
    /// Informazioni su un monitor.
    /// </summary>
    public class MonitorInfo
    {
        /// <summary>
        /// Handle al monitor.
        /// </summary>
        internal HMODULE MonitorHandle { get; }

        /// <summary>
        /// Rettangolo del monitor, espresso in coordinate sullo schermo virtuale.
        /// </summary>
        public Rectangle MonitorRectangle { get; }

        /// <summary>
        /// Rettangolo dell'area di lavoro del monitor, espresso in coordinate sullo schermo virtuale.
        /// </summary>
        public Rectangle WorkArea { get; }

        /// <summary>
        /// Indica se è il monitor primario.
        /// </summary>
        public bool IsPrimaryMonitor { get; }

        /// <summary>
        /// Nome del dispositivo.
        /// </summary>
        public string DeviceName { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="MonitorInfo"/>.
        /// </summary>
        /// <param name="MonitorHandle">Handle al monitor.</param>
        internal MonitorInfo(HMONITOR MonitorHandle)
        {
            this.MonitorHandle = MonitorHandle;

        }
    }
}