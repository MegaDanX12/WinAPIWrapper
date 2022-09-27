using WinApiWrapper.Managed.General;
using WinApiWrapper.UserInterface.UserInterfaceElements.Buttons;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons.Enumerations;
using WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ImageLists;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Informazioni su una lista immagini associata a un pulsante.
    /// </summary>
    public class ButtonImageListInfo : IDisposable
    {
        /// <summary>
        /// Informazioni sulla lista immagini.
        /// </summary>
        public ImageListInfo ImageListInfo { get; }

        /// <summary>
        /// Margini dell'icona.
        /// </summary>
        public Rectangle IconMargin { get; }

        /// <summary>
        /// Allineamento dell'immagine.
        /// </summary>
        public ButtonImageAlignment ImageAlignment { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ButtonImageListInfo"/>.
        /// </summary>
        /// <param name="ListInfo">Struttura <see cref="BUTTON_IMAGELIST"/> con informazioni sulla lista.</param>
        internal ButtonImageListInfo(BUTTON_IMAGELIST ListInfo)
        {
            ImageListInfo = new(ListInfo.ImageListHandle);
            IconMargin = new(ListInfo.Margins);
            ImageAlignment = (ButtonImageAlignment)ListInfo.Alignment;
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ButtonImageListInfo"/>.
        /// </summary>
        /// <param name="ImageListInfo">Istanza di <see cref="ImageListInfo"/> con informazioni sulla lista immagini.</param>
        /// <param name="IconMargins">Margini dell'icona.</param>
        /// <param name="ImageAlignment">Allineamento dell'immagine.</param>
        public ButtonImageListInfo(ImageListInfo ImageListInfo, Rectangle IconMargins, ButtonImageAlignment ImageAlignment)
        {
            this.ImageListInfo = ImageListInfo;
            IconMargin = IconMargins;
            this.ImageAlignment = ImageAlignment;
        }

        /// <summary>
        /// Restituisce una struttura <see cref="BUTTON_IMAGELIST"/> derivata dai dati presenti in questa classe.
        /// </summary>
        /// <returns>Struttura <see cref="BUTTON_IMAGELIST"/> con i dati presenti in questa classe.</returns>
        internal BUTTON_IMAGELIST ToStruct()
        {
            BUTTON_IMAGELIST ImageListDataStructure = new()
            {
                ImageListHandle = ImageListInfo.Handle,
                Margins = IconMargin.ToRECT(),
                Alignment = (ButtonEnumerations.ImagelistAlignment)ImageAlignment
            };
            return ImageListDataStructure;
        }

        /// <summary>
        /// Libera le risorse utilizzate.
        /// </summary>
        public void Dispose()
        {
            ImageListInfo.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
