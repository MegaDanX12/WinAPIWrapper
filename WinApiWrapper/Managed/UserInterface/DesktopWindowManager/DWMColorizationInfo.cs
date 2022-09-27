using System.Drawing;

namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Informazioni sulla colorizzazione DWM.
    /// </summary>
    public class DWMColorizationInfo
    {
        /// <summary>
        /// Colore usato da DWM per la composizione.
        /// </summary>
        public Color ColorizationColor { get; }

        /// <summary>
        /// Indica se il colore è una miscela opaca.
        /// </summary>
        public bool IsOpaqueBlend { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DWMColorizationInfo"/>.
        /// </summary>
        /// <param name="Color">Colore usato da DWM.</param>
        /// <param name="IsOpaqueBlend">Indica se il colore è una miscela opaca.</param>
        internal DWMColorizationInfo(DWORD Color, BOOL IsOpaqueBlend)
        {
            ColorizationColor = ColorTranslator.FromWin32((int)Color);
            this.IsOpaqueBlend = IsOpaqueBlend;
        }
    }
}