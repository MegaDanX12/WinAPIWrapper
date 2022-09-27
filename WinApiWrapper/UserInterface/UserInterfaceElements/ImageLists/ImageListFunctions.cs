using static WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists.ImageListEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists.ImageListStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists
{
    /// <summary>
    /// Funzioni che permettono di interagire con liste di immagini.
    /// </summary>
    internal static class ImageListFunctions
    {
        /// <summary>
        /// Recupera informazioni su un'immagine contenuta in una lista immagini.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        /// <param name="ImageIndex">Indice dell'immagine.</param>
        /// <param name="ImageInfoPointer">Puntatore a struttura <see cref="IMAGEINFO"/> che riceve le informazioni sull'immagine.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_GetImageInfo", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetImageInfo(HIMAGELIST ImageListHandle, int ImageIndex, IntPtr ImageInfoPointer);

        /// <summary>
        /// Recupera l'attuale colore di sfondo per una lista immagini.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        /// <returns>Il colore di sfondo.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_GetBkColor", SetLastError = true)]
        internal static extern COLORREF GetBackgroundColor(HIMAGELIST ImageListHandle);

        /// <summary>
        /// Recupera la dimensione delle immagini in una lista immagini.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        /// <param name="Width">Larghezza, in pixel, delle immagini.</param>
        /// <param name="Height">Altezza, in pixel, delle immagini.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_GetIconSize", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetIconSize(HIMAGELIST ImageListHandle, out int Width, out int Height);

        /// <summary>
        /// Recupera il numero di immagini in una lista immagini.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        /// <returns>Il numero delle immagini.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_GetImageCount", SetLastError = true)]
        internal static extern int GetImageCount(HIMAGELIST ImageListHandle);

        /// <summary>
        /// Crea un icona da un'immagine e una maschera in una lista immagini.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        /// <param name="ImageIndex">Indice dell'immagine.</param>
        /// <param name="DrawStyle">Stile di disegno dell'immagine.</param>
        /// <returns>Handle all'icona se l'operazione è riuscita, <see cref="IntPtr.Zero"/> altrimenti.</returns>
        /// <remarks>L'applicazione deve chiamare <see cref="Icons.IconFunctions.DestroyIcon"/> per eliminare l'icona.</remarks>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_GetIcon", SetLastError = true)]
        internal static extern HICON GetIcon(HIMAGELIST ImageListHandle, int ImageIndex, ImageDrawStyle DrawStyle);

        /// <summary>
        /// Crea una nuova lista immagini.
        /// </summary>
        /// <param name="ImageWidth">Larghezza, in pixel, di ogni immagine.</param>
        /// <param name="ImageHeight">Altezza, in pixel, di ogni immagine.</param>
        /// <param name="Options">Opzioni di creazione della lista.</param>
        /// <param name="InitialSize">Dimensione iniziale della lista.</param>
        /// <param name="GrowSize">Ingrandimento massimo.</param>
        /// <returns>Handle alla lista immagini se l'operazione è riuscita, <see cref="IntPtr.Zero"/> in caso contrario.</returns>
        /// <remarks><paramref name="Options"/> può contenere solo una delle opzioni ILC_COLORx.<br/><br/>
        /// <paramref name="GrowSize"/> indica di quanto la lista si può ingrandire quando il sistema deve ridimensionarla per fare spazio ad altre immagini.</remarks>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_Create", SetLastError = true)]
        internal static extern HIMAGELIST Create(int ImageWidth, int ImageHeight, ImageListCreationOptions Options, int InitialSize, int GrowSize);

        /// <summary>
        /// Elimina una lista di immagini.
        /// </summary>
        /// <param name="ImagelistHandle">Handle alla lista immagini.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_Destroy", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL Destroy(HIMAGELIST ImagelistHandle);

        /// <summary>
        /// Aggiunge una o più immagini a una lista immagini.
        /// </summary>
        /// <param name="ImagelistHandle">Handle alla lista immagini.</param>
        /// <param name="BitmapHandle">Handle al bitmap che contiene l'immagine o le immagini da aggiungere.</param>
        /// <param name="MaskBitmapHandle">Handle al bitmap che contiene la maschera.</param>
        /// <returns>Indice della prima nuova immagine se l'operazione ha successo, -1 in caso contrario.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_Add", SetLastError = true)]
        internal static extern int AddImage(HIMAGELIST ImagelistHandle, HBITMAP BitmapHandle, HBITMAP MaskBitmapHandle);

        /// <summary>
        /// Aggiunge una o più immagini a una lista immagini, generando una maschera dal bitmap specificato.
        /// </summary>
        /// <param name="ImageListHandle">Handle alla lista immagini.</param>
        /// <param name="BitmapHandle">Handle al bitmap che contiene le immagini.</param>
        /// <param name="MaskColor">Colore da usare per generare la maschera.</param>
        /// <returns>Indice della prima nuova immagine se l'operazione ha successo, -1 in caso contrario.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "ImageList_AddMasked", SetLastError = true)]
        internal static extern int AddImageMasked(HIMAGELIST ImageListHandle, HBITMAP BitmapHandle, COLORREF MaskColor);
    }
}