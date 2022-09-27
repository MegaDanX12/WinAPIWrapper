using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Enumerazioni usate dai pulsanti.
    /// </summary>
    internal static class ButtonEnumerations
    {
        /// <summary>
        /// Stato del pulsante.
        /// </summary>
        [Flags]
        internal enum ButtonState
        {
            /// <summary>
            /// Non selezionato.
            /// </summary>
            BST_UNCHECKED,
            /// <summary>
            /// Selezionato.
            /// </summary>
            BST_CHECKED,
            /// <summary>
            /// Indeterminato.
            /// </summary>
            /// <remarks>Valido solo per i pulsanti il cui stile comprende <see cref="ButtonStyles.BS_3STATE"/> oppure <see cref="ButtonStyles.BS_AUTO3STATE"/>.</remarks>
            BST_INDETERMINATE,
            /// <summary>
            /// Il pulsante è in stato premuto.
            /// </summary>
            BST_PUSHED = 4,
            /// <summary>
            /// Il pulsante ha il focus della tastiera.
            /// </summary>
            BST_FOCUS = 8,
            /// <summary>
            /// Il mouse si trova sopra il cursore.
            /// </summary>
            BST_HOT = 512,
            /// <summary>
            /// Il drop-down del pulsante è aperto.
            /// </summary>
            BST_DROPDOWNPUSHED = 1024
        }

        /// <summary>
        /// Allineamento della lista immagini.
        /// </summary>
        internal enum ImagelistAlignment
        {
            /// <summary>
            /// Sinistra.
            /// </summary>
            BUTTON_IMAGELIST_ALIGN_LEFT,
            /// <summary>
            /// Destra.
            /// </summary>
            BUTTON_IMAGELIST_ALIGN_RIGHT,
            /// <summary>
            /// Superiore.
            /// </summary>
            BUTTON_IMAGELIST_ALIGN_TOP,
            /// <summary>
            /// Inferiore.
            /// </summary>
            BUTTON_IMAGELIST_ALIGN_BOTTOM,
            /// <summary>
            /// Centrale.
            /// </summary>
            BUTTON_IMAGELIST_ALIGN_CENTER
        }

        /// <summary>
        /// Indica quali membri della struttura <see cref="BUTTON_SPLITINFO"/> sono validi.
        /// </summary>
        [Flags]
        internal enum SplitButtonInfoValidMembers
        {
            /// <summary>
            /// Il campo <see cref="BUTTON_SPLITINFO.GlyphHandle"/> è valido.
            /// </summary>
            BCSIF_GLYPH = 1,
            /// <summary>
            /// Il campo <see cref="BUTTON_SPLITINFO.GlyphHandle"/> è valido.
            /// </summary>
            /// <remarks>Utilizzato solo quando il campo <see cref="BUTTON_SPLITINFO.SplitButtonStyle"/> ha valore <see cref="SplitButtonStyle.BCSS_IMAGE"/>.</remarks>
            BCSIF_IMAGE,
            /// <summary>
            /// Il campo <see cref="BUTTON_SPLITINFO.SplitButtonStyle"/> è valido.
            /// </summary>
            BCSIF_STYLE = 4,
            /// <summary>
            /// Il campo <see cref="BUTTON_SPLITINFO.GlyphSize"/> è valido.
            /// </summary>
            BCSIF_SIZE = 8
        }

        /// <summary>
        /// Stili di uno split button.
        /// </summary>
        [Flags]
        internal enum SplitButtonStyle
        {
            /// <summary>
            /// Nessuna divisione.
            /// </summary>
            BCSS_NOSPLIT = 1,
            /// <summary>
            /// Immagine allungata tentando di mantenere l'aspect ratio.
            /// </summary>
            BCSS_STRETCH,
            /// <summary>
            /// Allinea l'immagine o il glifo orizzontalmente con il margine sinistro.
            /// </summary>
            BCSS_ALIGNLEFT = 4,
            /// <summary>
            /// Disegna l'immagine dell'icona come glifo.
            /// </summary>
            BCSS_IMAGE = 8
        }

        /// <summary>
        /// Tipo di immagine.
        /// </summary>
        internal enum ButtonImageType
        {
            /// <summary>
            /// Bitmap.
            /// </summary>
            IMAGE_BITMAP,
            /// <summary>
            /// Icona.
            /// </summary>
            IMAGE_ICON
        }

        /// <summary>
        /// Stili di un pulsante.
        /// </summary>
        [Flags]
        internal enum ButtonStyles
        {
            /// <summary>
            /// Crea un push button che invia il messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_COMMAND"/> alla finestra proprietaria quando l'utente lo seleziona.
            /// </summary>
            BS_PUSHBUTTON,
            /// <summary>
            /// Crea un pulsante che si comporta come un <see cref="BS_PUSHBUTTON"/> ma ha diverso aspetto esteriore.
            /// </summary>
            /// <remarks>Se il pulsante si trova in un box di dialogo, l'utente può selezionare il pulsante premendo INVIO anche quando non ha il focus dell'input.</remarks>
            BS_DEFPUSHBUTTON,
            /// <summary>
            /// Crea un piccolo quadrato vuoto con testo.
            /// </summary>
            /// <remarks>Il testo viene mostrato alla destra del quadrato per impostazione predefinita.<br/>
            /// Combinare questo stile con <see cref="BS_LEFTTEXT"/> per mostrare il testo alla sinistra.</remarks>
            BS_CHECKBOX,
            /// <summary>
            /// Pulsante uguale a <see cref="BS_CHECKBOX"/>, eccetto che lo stato cambia ogni volta che l'utente lo seleziona.
            /// </summary>
            BS_AUTOCHECKBOX = 3,
            /// <summary>
            /// Crea un piccolo cerchio con testo.
            /// </summary>
            /// <remarks>Il testo viene mostrato alla destra del cerchio per impostazione predefinita.<br/>
            /// Combinare questo stile con <see cref="BS_LEFTTEXT"/> per mostrare il testo alla sinistra.<br/>
            /// Usare questi pulsanti per gruppi di scelti correlate ma mutuamente esclusive.</remarks>
            BS_RADIOBUTTON,
            /// <summary>
            /// Pulsante simile a <see cref="BS_CHECKBOX"/>, soltanto che può anche impostato in stato indeterminato.
            /// </summary>
            BS_3STATE = 5,
            /// <summary>
            /// Pulsante uguale <see cref="BS_3STATE"/>, soltanto che cambia il suo stato quando l'utente lo seleziona.
            /// </summary>
            /// <remarks>Lo stato del pulsante cicla tra attivo, indeterminato, disattivato.</remarks>
            BS_AUTO3STATE = 6,
            /// <summary>
            /// Crea un rettangolo in cui altri controlli possono essere raggruppati.
            /// </summary>
            /// <remarks>Il testo associato verrà visualizzato nell'angolo superiore sinistro del rettangolo.</remarks>
            BS_GROUPBOX = 7,
            /// <summary>
            /// Pulsante uguale <see cref="BS_RADIOBUTTON"/>, soltanto che quando l'utente lo seleziona, il sistema lo seleziona e deseleziona tutti gli altri nello stesso gruppo.
            /// </summary>
            BS_AUTORADIOBUTTON = 9,
            /// <summary>
            /// 
            /// </summary>
            BS_PUSHBOX = 10,
            /// <summary>
            /// Crea un pulsante disegnato dal proprietario.
            /// </summary>
            /// <remarks>Il proprietario riceve il messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_DRAWITEM"/> quando un aspetto visuale è cambiato.<br/><br/>
            /// Questo stilo non deve essere combinato con nessun altro.</remarks>
            BS_OWNERDRAW = 11,
            /// <summary>
            /// Crea uno split button, questi pulsanti hanno un drop down.
            /// </summary>
            BS_SPLITBUTTON,
            /// <summary>
            /// Crea uno split button che funziona come un <see cref="BS_PUSHBUTTON"/> ma ha anche un diverso aspetto esteriore.
            /// </summary>
            /// <remarks>Se il pulsante si trova in un box di dialogo, l'utente può selezionare il pulsante premendo INVIO anche quando non ha il focus dell'input.</remarks>
            BS_DEFSPLITBUTTON = 13,
            /// <summary>
            /// Crea un pulsante di comando che si comporta come un <see cref="BS_PUSHBUTTON"/>, ma ha una freccia verde sulla sinistra che punta al testo del pulsante.
            /// </summary>
            /// <remarks>Inviando il messaggio <see cref="ButtonMessages.BCM_SETNOTE"/> si può impostare una didascalia per il testo.</remarks>
            BS_COMMANDLINK = 14,
            /// <summary>
            /// Crea un pulsante di comando che si comporta come un <see cref="BS_PUSHBUTTON"/>, ma ha una freccia verde sulla sinistra che punta al testo del pulsante.
            /// </summary>
            /// <remarks>Se il pulsante si trova in un box di dialogo, l'utente può selezionare il pulsante premendo INVIO anche quando non ha il focus dell'input.</remarks>
            BS_DEFCOMMANDLINK = 15,
            /// <summary>
            /// Il pulsante mostra del testo.
            /// </summary>
            BS_TEXT = BS_PUSHBUTTON,
            /// <summary>
            /// Posiziona il testo alla sinistra del radio button o del checkbox.
            /// </summary>
            /// <remarks>Uguale a <see cref="BS_RIGHTBUTTON"/>.</remarks>
            BS_LEFTTEXT = 32,
            /// <summary>
            /// Il pulsante mostra un'icona.
            /// </summary>
            BS_ICON = 64,
            /// <summary>
            /// Il pulsante mostra un bitmap.
            /// </summary>
            BS_BITMAP = 128,
            /// <summary>
            /// Giustifica a sinistra il testo nel rettangolo del pulsante.
            /// </summary>
            /// <remarks>Se il pulsante è un <see cref="BS_CHECKBOX"/> o un <see cref="BS_RADIOBUTTON"/> che non ha lo stile <see cref="BS_RIGHTBUTTON"/> applicato, il testo è giustificato a sinistra a destra del pulsante.</remarks>
            BS_LEFT = 256,
            /// <summary>
            /// Giustifica a destra il testo nel rettangolo del pulsante.
            /// </summary>
            /// <remarks>Se il pulsante è un <see cref="BS_CHECKBOX"/> o un <see cref="BS_RADIOBUTTON"/> che non ha lo stile <see cref="BS_RIGHTBUTTON"/> applicato, il testo è giustificato a destra a destra del pulsante.</remarks>
            BS_RIGHT = 512,
            /// <summary>
            /// Centra il testo orizzontalmente nel rettangolo del pulsante.
            /// </summary>
            BS_CENTER = 768,
            /// <summary>
            /// Il testo è posizionato nella parte superiore del rettangolo del pulsante.
            /// </summary>
            BS_TOP = 1024,
            /// <summary>
            /// Il testo è posizionato nella parte inferiore del rettangolo del pulsante.
            /// </summary>
            BS_BOTTOM = 2048,
            /// <summary>
            /// Posiziona il testo in mezzo al rettangolo del pulsante.
            /// </summary>
            BS_VCENTER = 3072,
            /// <summary>
            /// Il pulsante ha lo stesso aspetto e agisce come un push button.
            /// </summary>
            BS_PUSHLIKE = 4096,
            /// <summary>
            /// Se il testo è troppo lungo per una singola linea viene diviso in più linee.
            /// </summary>
            BS_MULTILINE = 8192,
            /// <summary>
            /// Permette al pulsante di inviare il codice <see cref="ButtonNotifications.BN_KILLFOCUS"/> e il codice <see cref="ButtonNotifications.BN_SETFOCUS"/> alla sua finestra padre.
            /// </summary>
            /// <remarks>Perché il pulsante invii la notifica <see cref="ButtonNotifications.BN_DOUBLECLICKED"/>, deve avere lo stile <see cref="BS_RADIOBUTTON"/> oppure <see cref="BS_OWNERDRAW"/>.</remarks>
            BS_NOTIFY = 16384,
            /// <summary>
            /// Il pulsante è a due dimensioni, non usa lo shading predefinito per creare un'immagine 3D.
            /// </summary>
            BS_FLAT = 32768,
            /// <summary>
            /// Posiziona il cerchio o il quadrato del pulsante alla destra del rettangolo.
            /// </summary>
            /// <remarks>Equivale <see cref="BS_LEFTTEXT"/>.</remarks>
            BS_RIGHTBUTTON = BS_LEFTTEXT
        }
    }
}