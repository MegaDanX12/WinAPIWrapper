namespace WinApiWrapper.UserInterface.UserInterfaceElements.ImageLists
{
    /// <summary>
    /// Enumerazioni usate dalle liste immagini.
    /// </summary>
    internal static class ImageListEnumerations
    {
        /// <summary>
        /// Stile di disegno dell'immagine.
        /// </summary>
        [Flags]
        internal enum ImageDrawStyle
        {
            /// <summary>
            /// Disegna l'immagine, miscelandola per il 25% con il colore di evidenziazione del sistema.
            /// </summary>
            /// <remarks>Se la lista non contiene una maschera, questo valore non ha effetto.</remarks>
            ILD_BLEND25 = 2,
            /// <summary>
            /// Disegna l'immagine, miscelandola per il 50% con il colore di evidenziazione del sistema.
            /// </summary>
            /// <remarks>Se la lista non contiene una maschera, questo valore non ha effetto.</remarks>
            ILD_BLEND50 = 4,
            /// <summary>
            /// Indica se l'overlay non richiede una maschera per essere disegnato.
            /// </summary>
            ILD_IMAGE = 32,
            /// <summary>
            /// Disegna la maschera.
            /// </summary>
            ILD_MASK = 16,
            /// <summary>
            /// Disegna l'immagine usando il colore di sfondo della lista immagini.
            /// </summary>
            ILD_NORMAL = 0,
            /// <summary>
            /// Uguale a <see cref="ILD_BLEND50"/>.
            /// </summary>
            ILD_SELECTED = ILD_BLEND50,
            /// <summary>
            /// Disegna l'immagine in modo trasparente usando la maschera, senza tenere conto del colore di sfondo.
            /// </summary>
            /// <remarks>Se la lista non contiene una maschera, questo valore non ha effetto.</remarks>
            ILD_TRANSPARENT = 1,
            /// <summary>
            /// Uguale a <see cref="ILD_BLEND50"/>.
            /// </summary>
            ILD_BLEND = ILD_BLEND50,
            /// <summary>
            /// Uguale a <see cref="ILD_BLEND25"/>.
            /// </summary>
            ILD_FOCUS = ILD_BLEND25
        }

        /// <summary>
        /// Opzioni di creazione di una lista immagini.
        /// </summary>
        [Flags]
        internal enum ImageListCreationOptions
        {
            /// <summary>
            /// Usare una maschera.
            /// </summary>
            ILC_MASK = 1,
            /// <summary>
            /// Comportamento predefinito se nessuna delle opzioni ILC_COLOR è usata.
            /// </summary>
            ILC_COLOR = 0,
            /// <summary>
            /// Usare un bitmap dipendente dal dispositivo (DDB).
            /// </summary>
            ILC_COLORDDB = 254,
            /// <summary>
            /// Usare un bitmap a 4 bit indipendente dal dispositivo.
            /// </summary>
            ILC_COLOR4 = 4,
            /// <summary>
            /// Usare un bitmap a 8 bit indipendente dal dispositivo.
            /// </summary>
            ILC_COLOR8 = 8,
            /// <summary>
            /// Usare un bitmap a 16 bit indipendente dal dispositivo.
            /// </summary>
            ILC_COLOR16 = 16,
            /// <summary>
            /// Usare un bitmap a 24 bit indipendente dal dispositivo.
            /// </summary>
            ILC_COLOR24 = 24,
            /// <summary>
            /// Usare un bitmap a 32 bit indipendente dal dispositivo.
            /// </summary>
            ILC_COLOR32 = 32,
            /// <summary>
            /// Inverti le icone contenute.
            /// </summary>
            ILC_MIRROR = 8192,
            /// <summary>
            /// Inverti ogni oggetto al momento dell'inserimento nella lista al posto di invertire tutti gli elementi insieme.
            /// </summary>
            ILC_PERITEMMIRROR = 32768,
            /// <summary>
            /// La lista dovrebbe accettare immagini più piccole da quanto indicato dalle impostazioni della lista e applicare la dimensione originale in base all'immagine aggiunta.
            /// </summary>
            ILC_ORIGINALSIZE = 65536,
            /// <summary>
            /// Riservato.
            /// </summary>
            ILC_HIGHQUALITYSCALE = 131072
        }
    }
}