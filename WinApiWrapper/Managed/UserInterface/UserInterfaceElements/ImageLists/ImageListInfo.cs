using System.Drawing;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists.ImageListFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Icons.IconFunctions;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ImageLists.Enumerations;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists.ImageListEnumerations;
using WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ImageLists
{
    /// <summary>
    /// Informazioni su una lista immagini.
    /// </summary>
    public class ImageListInfo : IDisposable
    {
        /// <summary>
        /// Handle alla lista immagini.
        /// </summary>
        internal HIMAGELIST Handle { get; }

        private bool disposedValue;

        /// <summary>
        /// Immagini contenute nella lista.
        /// </summary>
        public Bitmap[] Images { get; }

        /// <summary>
        /// Colore di sfondo della lista.
        /// </summary>
        public Color BackgroundColor { get; }

        /// <summary>
        /// Dimensione delle immagini nella lista.
        /// </summary>
        public Size? ImagesSize { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ImageListInfo"/>.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        internal ImageListInfo(HIMAGELIST ImageListHandle)
        {
            int ImageCount = GetImageCount(ImageListHandle);
            Images = new Bitmap[ImageCount];
            HMODULE IconHandle;
            for (int i = 0; i < ImageCount; i++)
            {
                IconHandle = GetIcon(ImageListHandle, i, ImageDrawStyle.ILD_NORMAL);
                Images[i] = Bitmap.FromHicon(IconHandle);
                _ = DestroyIcon(IconHandle);
            }
            COLORREF BackgroundColor = GetBackgroundColor(ImageListHandle);
            this.BackgroundColor = ColorTranslator.FromWin32((int)BackgroundColor);
            if (GetIconSize(ImageListHandle, out int Width, out int Height))
            {
                ImagesSize = new Size(Width, Height);
            }
            else
            {
                ImagesSize = null;
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ImageListInfo"/>.
        /// </summary>
        /// <param name="ImageFilePaths">Array di percorsi a file immagine.</param>
        /// <param name="ImageWidth">Larghezza delle immagini nella lista, in pixel.</param>
        /// <param name="ImageHeight">Altezza delle immagini nella lista, in pixel.</param>
        /// <param name="Options">Opzioni di creazione della lista.</param>
        /// <param name="GrowthAmount">Numero di immagini che il sistema può inserire quando deve fare spazio per nuove immagini.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public ImageListInfo(string[] ImageFilePaths, int ImageWidth, int ImageHeight, CreationOptions Options, int GrowthAmount)
        {
            HBITMAP BitmapHandle;
            Bitmap? Image;
            if (ImageFilePaths is not null && ImageFilePaths.Length > 0 && ImageWidth > 0 && ImageHeight > 0)
            {
                Handle = Create(ImageWidth, ImageHeight, (ImageListCreationOptions)Options, ImageFilePaths.Length, GrowthAmount);
                if (Handle != IntPtr.Zero)
                {
                    foreach (string imagepath in ImageFilePaths)
                    {
                        Image = (Bitmap)System.Drawing.Image.FromFile(imagepath);
                        BitmapHandle = Image.GetHbitmap();
                        if (AddImage(Handle, BitmapHandle, IntPtr.Zero) is -1)
                        {
                            _ = Destroy(Handle);
                            Image!.Dispose();
                            _ = DeleteObject(BitmapHandle);
                            throw new Exception("Could not add all images to the image list.");
                        }
                        _ = DeleteObject(BitmapHandle);
                        Image.Dispose();
                    }
                    Images = new Bitmap[ImageFilePaths.Length];
                    HICON IconHandle;
                    for (int i = 0; i < ImageFilePaths.Length; i++)
                    {
                        IconHandle = GetIcon(Handle, i, ImageDrawStyle.ILD_NORMAL);
                        Images[i] = Bitmap.FromHicon(IconHandle);
                        _ = DestroyIcon(IconHandle);
                    }
                    COLORREF BackgroundColor = GetBackgroundColor(Handle);
                    this.BackgroundColor = ColorTranslator.FromWin32((int)BackgroundColor);
                    ImagesSize = new Size(ImageWidth, ImageHeight);
                }
                else
                {
                    throw new Exception("Could not create image list.");
                }
            }
            else
            {
                throw new ArgumentNullException(string.Empty, "ImageFilePaths must not be null or empty, ImageWidth and ImageHeight must be higher than 0.");
            }
        }

        /// <summary>
        /// Elimina i bitmap e la lista immagini.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (Bitmap image in Images)
                    {
                        image.Dispose();
                    }
                }
                if (Handle != IntPtr.Zero)
                {
                    _ = Destroy(Handle);
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizzatore.
        /// </summary>
        ~ImageListInfo()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Libera le risorse utilizzate.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}