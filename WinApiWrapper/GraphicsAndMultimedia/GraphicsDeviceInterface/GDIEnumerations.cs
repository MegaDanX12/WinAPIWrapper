namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface
{
    /// <summary>
    /// Enumerazioni GDI.
    /// </summary>
    internal class GDIEnumerations
    {
        /// <summary>
        /// Ordinali che identificano i bitmap, le icone e i cursori OEM.
        /// </summary>
        internal enum OEMImageOrdinals
        {
            #region Bitmaps
            OBM_LFARROWI = 32734,
            OBM_RGARROWI,
            OBM_DNARROWI,
            OBM_UPARROWI,
            OBM_COMBO,
            OBM_MNARROW,
            OBM_LFARROWD,
            OBM_RGARROWD,
            OBM_DNARROWD,
            OBM_UPARROWD,
            OBM_RESTORED,
            OBM_ZOOMD,
            OBM_REDUCED,
            OBM_RESTORE,
            OBM_ZOOM,
            OBM_REDUCE,
            OBM_LFARROW,
            OBM_RGARROW,
            OBM_DNARROW,
            OBM_UPARROW,
            OBM_CLOSE,
            OBM_OLD_RESTORE,
            OBM_OLD_ZOOM,
            OBM_OLD_REDUCE,
            OBM_BTNCORNERS,
            OBM_CHECKBOXES,
            OBM_CHECK,
            OBM_BTSIZE,
            OBM_OLD_LFARROW,
            OBM_OLD_RGARROW,
            OBM_OLD_DNARROW,
            OBM_OLD_UPARROW,
            OBM_SIZE,
            OBM_OLD_CLOSE,
            #endregion
            #region Icons
            OIC_SAMPLE = 32512,
            OIC_HAND,
            OIC_QUES,
            OIC_BANG,
            OIC_NOTE,
            OIC_WARNING = OIC_BANG,
            OIC_ERROR = OIC_HAND,
            OIC_INFORMATION = OIC_NOTE,
            OIC_WINLOGO,
            OIC_SHIELD,
            #endregion
            #region Cursors
            OCR_NORMAL = 32512,
            OCR_IBEAM,
            OCR_WAIT,
            OCR_CROSS,
            OCR_UP,
            OCR_SIZE = 32640,
            OCR_ICON,
            OCR_SIZENWSE,
            OCR_SIZENESW,
            OCR_SIZEWE,
            OCR_SIZENS,
            OCR_SIZEALL,
            OCR_ICOCUR,
            OCR_NO,
            OCR_HAND,
            OCR_APPSTARTING
            #endregion
        }

        /// <summary>
        /// Tipo di immagine da caricare.
        /// </summary>
        internal enum ImageType : uint
        {
            /// <summary>
            /// Bitmap.
            /// </summary>
            IMAGE_BITMAP,
            /// <summary>
            /// Cursore.
            /// </summary>
            IMAGE_CURSOR,
            /// <summary>
            /// Icona.
            /// </summary>
            IMAGE_ICON
        }

        /// <summary>
        /// Opzioni di caricamento dell'immagine.
        /// </summary>
        [Flags]
        internal enum LoadOptions : uint
        {
            /// <summary>
            /// Se viene specificato <see cref="ImageType.IMAGE_BITMAP"/>, viene restituito una sezione DIB bitmap anziché di un bitmap compatibile.
            /// </summary>
            /// <remarks>Questa opzione viene usata per caricare un bitmap senza mapparlo ai colori del dispositivo di visualizzazione.</remarks>
            LR_CREATEDIBSECTION = 0x00002000,
            /// <summary>
            /// Nessun effetto.
            /// </summary>
            LR_DEFAULTCOLOR = 0x00000000,
            /// <summary>
            /// Usa la larghezza e l'altezza specificate dalla metrica di sistema per i cursori o le icone se i valori non sono esplicitamente indicati.
            /// </summary>
            /// <remarks>Se questa opzione non è specificata e larghezza e altezza non sono esplicitamente indicati, il sistema usa l'effettiva dimensione della risorsa, se esistono immagini multiple viene utilizzata la dimensione della prima.</remarks>
            LR_DEFAULTSIZE = 0x00000040,
            /// <summary>
            /// Carica un'immagine da un file specificato.
            /// </summary>
            LR_LOADFROMFILE = 0x00000010,
            /// <summary>
            /// Cerca la tabella dei colori per l'immagine e sostituisce alcune tonalità di grigio con i corrispondenti colori 3D.
            /// </summary>
            /// <remarks>Le tonalità di grigio sostituite sono le seguenti:<br/><br/>
            /// Grigio scuro, RGB(128, 128, 128) con <see cref="ColorTypes.COLOR_3DSHADOW"/>.<br/>
            /// Grigio, RGB(192, 192, 192) con <see cref="ColorTypes.COLOR_3DFACE"/>.<br/>
            /// Grigio chiaro, RGB(223, 223, 223) con <see cref="ColorTypes.COLOR_3DLIGHT"/>.<br/><br/>
            /// Non usare questa opzione se si sta caricando un bitmap con una profondità del colore superiore a 8bpp.</remarks>
            LR_LOADMAP3DCOLORS = 0x00001000,
            /// <summary>
            /// Recupera il valore del colore del primo pixel dell'immagine e lo sostituisce la voce corrispondente nella tabella dei colori con il colore predefinito della finestra (<see cref="ColorTypes.COLOR_WINDOW"/>.
            /// </summary>
            /// <remarks>Tutti i pixel dell'immagine che usano quella voce diventano del colore predefinito delle finestre.<br/>
            /// Si applica solo alle immagini che hanno le tabelle dei colori corrispondenti.<br/><br/>
            /// Non usare questa opzione se si sta caricando un bitmap con una profondità del colore superiore a 8bpp.<br/><br/>
            /// Se è inclusa anche l'opzione <see cref="LR_LOADMAP3DCOLORS"/> oltre a questa, quest'ultima ha precedenza ma la voce nella tabella dei colori viene sostituita con <see cref="ColorTypes.COLOR_3DFACE"/>.</remarks>
            LR_LOADTRANSPARENT = 0x00000020,
            /// <summary>
            /// Carica l'immagine in bianco e nero.
            /// </summary>
            LR_MONOCHROME = 0x00000001,
            /// <summary>
            /// L'handle all'immagine è condiviso.
            /// </summary>
            /// <remarks>Se questa opzione è impostata e l'immagine viene caricata più volte viene restituito lo stesso handle, se non è impostato verrà restituito un handle diverso ogni volta.<br/><br/>
            /// Non usare questa opzione per immagini di dimensioni non standard, che potrebbero cambiare dopo il caricamento oppure che sono caricate da un file.<br/>
            /// Il sistema eliminerà la risorsa quando non è più necessaria.<br/><br/>
            /// Questa opzione deve essere utilizzata quando si carica un'icone o un cursore di sistema.</remarks>
            LR_SHARED = 0x00008000,
            /// <summary>
            /// Usa veri color VGA.
            /// </summary>
            LR_VGACOLOR = 0x00000080
        }
    }
}