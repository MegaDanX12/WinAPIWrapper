using System.Drawing;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Icons.IconFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Icons.IconStructures;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIFunctions;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Icons
{
    /// <summary>
    /// Informazioni su un'icona.
    /// </summary>
    public class IconInfo : IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// Handle all'icona.
        /// </summary>
        internal HICON IconHandle { get; }

        /// <summary>
        /// Icona.
        /// </summary>
        public Icon Icon { get; }

        /// <summary>
        /// Bitmap della bitmask dell'icona.
        /// </summary>
        /// <remarks>Se l'icona è in bianco e nero, questo campo è formattata in modo che la metà superiore sia l'icona e la bitmask mentre la metà inferiore è solo l'icona.<br/>
        /// In questo caso l'altezza dovrebbe essere un multiplo di due.<br/><br/>
        /// Se l'icona è colorata, questo campo include sempre l'icona e la bitmask.</remarks>
        public Bitmap? IconBitmask { get; }

        /// <summary>
        /// Bitmap del colore dell'icona.
        /// </summary>
        /// <remarks>Se l'icona è in bianco e nero questo campo è opzionale.</remarks>
        public Bitmap? IconColor { get; }

        /// <summary>
        /// Percorso completo del modulo che contiene l'icona.
        /// </summary>
        public string? ModuleFullPath { get; }

        /// <summary>
        /// Percorso completo della risorsa.
        /// </summary>
        public string? ResourceFullPath { get; }

        /// <summary>
        /// Indica se l'icona è condivisa.
        /// </summary>
        private bool IsSharedIcon { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="IconInfo"/>.
        /// </summary>
        /// <param name="IconHandle">Handle all'icona.</param>
        /// <param name="IsSharedIcon">Indica se l'icona è condivisa.</param>
        internal IconInfo(HICON IconHandle, bool IsSharedIcon)
        {
            this.IconHandle = IconHandle;
            Icon = Icon.FromHandle(IconHandle);
            this.IsSharedIcon = IsSharedIcon;
            ICONINFOEX IconInfo = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(ICONINFOEX))
            };
            if (GetIconInfo(IconHandle, ref IconInfo))
            {
                IconBitmask = Image.FromHbitmap(IconInfo.IconBitmask);
                IconColor = Image.FromHbitmap(IconInfo.IconColorBitmap);
                ModuleFullPath = IconInfo.ModulePath;
                ResourceFullPath = IconInfo.ResourcePath;
                _ = DeleteObject(IconInfo.IconBitmask);
                _ = DeleteObject(IconInfo.IconColorBitmap);
            }
            else
            {
                IconBitmask = null;
                IconColor = null;
                ModuleFullPath = null;
                ResourceFullPath = null;
            }
        }

        /// <summary>
        /// Libera le risorse utilizzate.
        /// </summary>
        /// <param name="disposing">Indica se liberare le risorse gestite.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Icon.Dispose();
                    if (IconBitmask is not null && IconColor is not null)
                    {
                        IconBitmask.Dispose();
                        IconColor.Dispose();
                    }
                }
                if (!IsSharedIcon)
                {
                    _ = DestroyIcon(IconHandle);
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizzatore.
        /// </summary>
        ~IconInfo()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Libera le risorse utlizzate.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}