namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Attributi di trasporto DWM.
    /// </summary>
    public class DWMTransportAttributes
    {
        /// <summary>
        /// Indica se il trasporto supporta il remoting.
        /// </summary>
        public bool RemotingSupported { get; }

        /// <summary>
        /// Indica se il trasporto è connesso.
        /// </summary>
        public bool IsConnected { get; }

        /// <summary>
        /// Generazione del trasporto.
        /// </summary>
        public int Generation { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DWMTransportAttributes"/>.
        /// </summary>
        /// <param name="RemotingSupported">Indica se il trasporto supporta il remoting.</param>
        /// <param name="IsConnected">Indica se il trasporto è connesso.</param>
        /// <param name="Generation">Generazione del trasporto.</param>
        internal DWMTransportAttributes(BOOL RemotingSupported, BOOL IsConnected, DWORD Generation)
        {
            this.RemotingSupported = RemotingSupported;
            this.IsConnected = IsConnected;
            this.Generation = (int)Generation;
        }
    }
}