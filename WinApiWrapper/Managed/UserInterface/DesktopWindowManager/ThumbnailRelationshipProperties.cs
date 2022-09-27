using System.ComponentModel;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMEnumerations;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMFunctions;
using WinApiWrapper.Managed.General;

namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Proprietà della relazione creata tra due finestre per la miniatura DWM.
    /// </summary>
    public class ThumbnailRelationshipProperties : IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// Handle alla miniatura.
        /// </summary>
        internal HMODULE ThumbnailHandle { get; set; }

        /// <summary>
        /// Regione, nella finestra di destinazione, dove visualizzare la miniatura.
        /// </summary>
        public Rectangle DestinationRegion { get; }

        /// <summary>
        /// Regione, nella finestra di origine, da usare come fonte della miniatura.
        /// </summary>
        public Rectangle? SourceRegion { get; }

        /// <summary>
        /// Opacità della miniatura.
        /// </summary>
        public byte? Opacity { get; }

        /// <summary>
        /// Indica se la miniatura è visibile.
        /// </summary>
        public bool? IsVisible { get; }

        /// <summary>
        /// Indica se usare solo l'area client della finestra di origine per la miniatura.
        /// </summary>
        public bool? ClientAreaOnly { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ThumbnailRelationshipProperties"/>.
        /// </summary>
        /// <param name="DestinationRegion">Regione, nella finestra di destinazione, dove visualizzare la miniatura.</param>
        /// <param name="SourceRegion">Regione, nella finestra di origine, da usare come fonte della miniatura.</param>
        /// <param name="Opacity">Opacità della miniatura.</param>
        /// <param name="Visible">Indica se la miniatura è visibile.</param>
        /// <param name="ClientAreaOnly">Indica se usare solo l'area client della finestra di origine per la miniatura.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>Il valore 0 per <paramref name="Opacity"/> indica completamente trasparente, 255 indica completamente opaco.</remarks>
        public ThumbnailRelationshipProperties(Rectangle DestinationRegion, Rectangle? SourceRegion = null, byte? Opacity = null, bool? Visible = null, bool? ClientAreaOnly = null)
        {
            if (DestinationRegion is null)
            {
                throw new ArgumentNullException(nameof(DestinationRegion), nameof(DestinationRegion) + " cannot be null.");
            }
            else
            {
                this.DestinationRegion = DestinationRegion;
                if (SourceRegion is not null)
                {
                    this.SourceRegion = SourceRegion;
                }
                if (Opacity.HasValue)
                {
                    this.Opacity = Opacity;
                }
                if (Visible.HasValue)
                {
                    IsVisible = Visible;
                }
                if (ClientAreaOnly.HasValue)
                {
                    this.ClientAreaOnly = ClientAreaOnly;
                }
            }
        }

        /// <summary>
        /// Recupera la dimensione di origine della miniatura DWM.
        /// </summary>
        /// <returns>Struttura <see cref="System.Drawing.Size"/> che indica la dimensione della miniatura.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public System.Drawing.Size GetSourceSize()
        {
            HRESULT OperationResult = DwmQueryThumbnailSourceSize(ThumbnailHandle, out SIZE Size);
            if (OperationResult != S_OK)
            {
                Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                {
                    HResult = OperationResult
                };
                throw ex;
            }
            else
            {
                return new(Size.x, Size.y);
            }
        }

        /// <summary>
        /// Converte i dati di questa istanza in una struttura <see cref="DWM_THUMBNAIL_PROPERTIES"/>.
        /// </summary>
        /// <returns>Struttura <see cref="DWM_THUMBNAIL_PROPERTIES"/> risultato della conversione.</returns>
        internal DWM_THUMBNAIL_PROPERTIES ToStructure()
        {
            RECT DestinationRectangle = DestinationRegion.ToRECT();
            DWM_THUMBNAIL_PROPERTIES ThumbnailProperties = new()
            {
                Flags = DwmThumbnailProperties.DWM_TNP_RECTDESTINATION,
                Destination = DestinationRectangle
            };
            RECT SourceRectangle;
            if (SourceRegion is not null)
            {
                SourceRectangle = SourceRegion.ToRECT();
                ThumbnailProperties.Source = SourceRectangle;
                ThumbnailProperties.Flags |= DwmThumbnailProperties.DWM_TNP_RECTSOURCE;
            }
            if (Opacity is not null)
            {
                ThumbnailProperties.Opacity = Convert.ToByte(Opacity.Value);
                ThumbnailProperties.Flags |= DwmThumbnailProperties.DWM_TNP_OPACITY;
            }
            if (IsVisible is not null)
            {
                ThumbnailProperties.Visible = IsVisible.Value;
                ThumbnailProperties.Flags |= DwmThumbnailProperties.DWM_TNP_VISIBLE;
            }
            if (ClientAreaOnly is not null)
            {
                ThumbnailProperties.SourceClientAreaOnly = ClientAreaOnly.Value;
                ThumbnailProperties.Flags |= DwmThumbnailProperties.DWM_TNP_SOURCECLIENTAREAONLY;
            }
            return ThumbnailProperties;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                HRESULT OperationResult = DwmUnregisterThumbnail(ThumbnailHandle);
                if (OperationResult != S_OK)
                {
                    disposedValue = false;
                }
                else
                {
                    disposedValue = true;
                }
            }
        }

        ~ThumbnailRelationshipProperties()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Interrompe la cattura della miniatura.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}