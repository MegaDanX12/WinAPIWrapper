using static WinApiWrapper.General.GeneralStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists
{
    /// <summary>
    /// Strutture usate dalle liste di immagini.
    /// </summary>
    internal static class ImageListStructures
    {
        /// <summary>
        /// Informazioni su un'immagine presente in una lista di immagini.
        /// </summary>
        internal struct IMAGEINFO
        {
            /// <summary>
            /// Handle al bitmap che contiene le immagini.
            /// </summary>
            public HBITMAP ImageBitmapHandle;
            /// <summary>
            /// Handle al bitmap in bianco e nero che contiene le maschere per le immagini.
            /// </summary>
            /// <remarks>Se la lista non contiene una maschera, questo campo ha valore <see cref="IntPtr.Zero"/>.</remarks>
            public HBITMAP ImageMaskMonochromeBitmap;
            /// <summary>
            /// Non usato, deve essere 0.
            /// </summary>
            public int Unused1;
            /// <summary>
            /// Non usato, deve essere 0.
            /// </summary>
            public int Unused2;
            /// <summary>
            /// Rettangolo che contiene l'immagine nel bitmap specificato da <see cref="ImageBitmapHandle"/>.
            /// </summary>
            public RECT ImageRectangle;
        }
    }
}