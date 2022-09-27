using static WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists.ImageListEnumerations;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ImageLists
{
    /// <summary>
    /// Enumerazioni usate dalle liste immagini.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Opzioni di creazione di una lista immagini.
        /// </summary>
        public enum CreationOptions
        {
            /// <summary>
            /// Usare una maschera.
            /// </summary>
            UseMask = ImageListCreationOptions.ILC_MASK,
            /// <summary>
            /// Profondità colori predefinita.
            /// </summary>
            DefaultColorDepth = ImageListCreationOptions.ILC_COLOR,
            /// <summary>
            /// Usare un bitmap dipendente dal dispositivo (DDB).
            /// </summary>
            UseDDB = ImageListCreationOptions.ILC_COLORDDB,
            /// <summary>
            /// Usare un bitmap a 4 bit indipendente dal dispositivo.
            /// </summary>
            DIB4Bit = ImageListCreationOptions.ILC_COLOR4,
            /// <summary>
            /// Usare un bitmap a 8 bit indipendente dal dispositivo.
            /// </summary>
            DIB8Bit = ImageListCreationOptions.ILC_COLOR8,
            /// <summary>
            /// Usare un bitmap a 16 bit indipendente dal dispositivo.
            /// </summary>
            DIB16Bit = ImageListCreationOptions.ILC_COLOR16,
            /// <summary>
            /// Usare un bitmap a 24 bit indipendente dal dispositivo.
            /// </summary>
            DIB24Bit = ImageListCreationOptions.ILC_COLOR24,
            /// <summary>
            /// Usare un bitmap a 32 bit indipendente dal dispositivo.
            /// </summary>
            DIB32Bit = ImageListCreationOptions.ILC_COLOR32,
            /// <summary>
            /// Inverti le icone contenute.
            /// </summary>
            MirrorIcons = ImageListCreationOptions.ILC_MIRROR,
            /// <summary>
            /// Inverti ogni oggetto al momento dell'inserimento nella lista al posto di invertire tutti gli elementi insieme.
            /// </summary>
            MirrorEveryItem = ImageListCreationOptions.ILC_PERITEMMIRROR,
            /// <summary>
            /// La lista dovrebbe accettare immagini più piccole da quanto indicato dalle impostazioni della lista e applicare la dimensione originale in base all'immagine aggiunta.
            /// </summary>
            OriginalSizeBasedOnImage = ImageListCreationOptions.ILC_ORIGINALSIZE
        }
    }
}