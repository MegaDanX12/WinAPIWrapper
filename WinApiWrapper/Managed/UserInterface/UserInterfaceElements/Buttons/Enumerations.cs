using WinApiWrapper.UserInterface.UserInterfaceElements.Buttons;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonEnumerations;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Enumerazioni usate dai pulsanti.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Allineamento dell'immagine del pulsante.
        /// </summary>
        public enum ButtonImageAlignment
        {
            /// <summary>
            /// Immagine allineata a sinistra.
            /// </summary>
            Left = ImagelistAlignment.BUTTON_IMAGELIST_ALIGN_LEFT,
            /// <summary>
            /// Immagine allineata a destra.
            /// </summary>
            Right = ImagelistAlignment.BUTTON_IMAGELIST_ALIGN_RIGHT,
            /// <summary>
            /// Immagine allineata al margine superiore.
            /// </summary>
            Top = ImagelistAlignment.BUTTON_IMAGELIST_ALIGN_TOP,
            /// <summary>
            /// Immagine allineata al margine inferiore.
            /// </summary>
            Bottom = ImagelistAlignment.BUTTON_IMAGELIST_ALIGN_BOTTOM,
            /// <summary>
            /// Immagine centrata.
            /// </summary>
            Center = ImagelistAlignment.BUTTON_IMAGELIST_ALIGN_CENTER
        }

        /// <summary>
        /// Stili di un pulsante.
        /// </summary>
        [Flags]
        public enum ButtonStyles
        {
            /// <summary>
            /// Pulsante simile a <see cref="Checkbox"/>, soltanto che può anche impostato in stato indeterminato.
            /// </summary>
            ThreeStateCheckbox = ButtonEnumerations.ButtonStyles.BS_3STATE,
            /// <summary>
            /// Pulsante uguale <see cref="ThreeStateCheckbox"/>, soltanto che cambia il suo stato quando l'utente lo seleziona.
            /// </summary>
            /// <remarks>Lo stato del pulsante cicla tra attivo, indeterminato, disattivato.</remarks>
            AutoThreeStateCheckbox = ButtonEnumerations.ButtonStyles.BS_AUTO3STATE,
            /// <summary>
            /// Pulsante uguale a <see cref="Checkbox"/>, eccetto che lo stato cambia ogni volta che l'utente lo seleziona.
            /// </summary>
            AutoCheckbox = ButtonEnumerations.ButtonStyles.BS_AUTOCHECKBOX,
            /// <summary>
            /// Pulsante uguale <see cref="RadioButton"/>, soltanto che quando l'utente lo seleziona, il sistema lo seleziona e deseleziona tutti gli altri nello stesso gruppo.
            /// </summary>
            AutoRadioButton = ButtonEnumerations.ButtonStyles.BS_AUTORADIOBUTTON,
            /// <summary>
            /// Il pulsante mostra un bitmap.
            /// </summary>
            DisplaysBitmap = ButtonEnumerations.ButtonStyles.BS_BITMAP,
            /// <summary>
            /// Il testo è posizionato nella parte inferiore del rettangolo del pulsante.
            /// </summary>
            TextAtBottom = ButtonEnumerations.ButtonStyles.BS_BOTTOM,
            /// <summary>
            /// Centra il testo orizzontalmente nel rettangolo del pulsante.
            /// </summary>
            TextHorizontallyCentered = ButtonEnumerations.ButtonStyles.BS_CENTER,
            /// <summary>
            /// Crea un piccolo quadrato vuoto con testo.
            /// </summary>
            /// <remarks>Il testo viene mostrato alla destra del quadrato per impostazione predefinita.<br/>
            /// Combinare questo stile con <see cref="TextOnRightSideOfRectangle"/> per mostrare il testo alla sinistra.</remarks>
            Checkbox = ButtonEnumerations.ButtonStyles.BS_CHECKBOX,
            /// <summary>
            /// Crea un pulsante di comando che si comporta come un <see cref="PushButton"/>, ma ha una freccia verde sulla sinistra che punta al testo del pulsante.
            /// </summary>
            /// <remarks>Inviando il messaggio <see cref="ButtonMessages.BCM_SETNOTE"/> si può impostare una didascalia per il testo.</remarks>
            CommandLink = ButtonEnumerations.ButtonStyles.BS_COMMANDLINK,
            /// <summary>
            /// Crea un pulsante di comando che si comporta come un <see cref="PushButton"/>, ma ha una freccia verde sulla sinistra che punta al testo del pulsante.
            /// </summary>
            /// <remarks>Se il pulsante si trova in un box di dialogo, l'utente può selezionare il pulsante premendo INVIO anche quando non ha il focus dell'input.</remarks>
            AutoSelectionCommandLink = ButtonEnumerations.ButtonStyles.BS_DEFCOMMANDLINK,
            /// <summary>
            /// Crea un pulsante che si comporta come un <see cref="PushButton"/> ma ha diverso aspetto esteriore.
            /// </summary>
            /// <remarks>Se il pulsante si trova in un box di dialogo, l'utente può selezionare il pulsante premendo INVIO anche quando non ha il focus dell'input.</remarks>
            AutoSelectionPushButton = ButtonEnumerations.ButtonStyles.BS_DEFPUSHBUTTON,
            /// <summary>
            /// Crea uno split button che funziona come un <see cref="PushButton"/> ma ha anche un diverso aspetto esteriore.
            /// </summary>
            /// <remarks>Se il pulsante si trova in un box di dialogo, l'utente può selezionare il pulsante premendo INVIO anche quando non ha il focus dell'input.</remarks>
            AutoSelectionSplitButton = ButtonEnumerations.ButtonStyles.BS_DEFSPLITBUTTON,
            /// <summary>
            /// Crea un rettangolo in cui altri controlli possono essere raggruppati.
            /// </summary>
            /// <remarks>Il testo associato verrà visualizzato nell'angolo superiore sinistro del rettangolo.</remarks>
            Groupbox = ButtonEnumerations.ButtonStyles.BS_GROUPBOX,
            /// <summary>
            /// Il pulsante mostra un'icona.
            /// </summary>
            DisplaysIcon = ButtonEnumerations.ButtonStyles.BS_ICON,
            /// <summary>
            /// Giustifica a sinistra il testo nel rettangolo del pulsante.
            /// </summary>
            /// <remarks>Se il pulsante è un <see cref="Checkbox"/> o un <see cref="RadioButton"/> che non ha lo stile <see cref="TextOnRightSideOfRectangle"/> applicato, il testo è giustificato a sinistra a destra del pulsante.</remarks>
            TextLeftJustified = ButtonEnumerations.ButtonStyles.BS_LEFT,
            /// <summary>
            /// Posiziona il cerchio o il quadrato del pulsante alla destra del rettangolo.
            /// </summary>
            TextOnLeftSide = ButtonEnumerations.ButtonStyles.BS_LEFTTEXT,
            /// <summary>
            /// Se il testo è troppo lungo per una singola linea viene diviso in più linee.
            /// </summary>
            MultilineText = ButtonEnumerations.ButtonStyles.BS_MULTILINE,
            /// <summary>
            /// Permette al pulsante di inviare il codice <see cref="ButtonNotifications.BN_KILLFOCUS"/> e il codice <see cref="ButtonNotifications.BN_SETFOCUS"/> alla sua finestra padre.
            /// </summary>
            /// <remarks>Perché il pulsante invii la notifica <see cref="ButtonNotifications.BN_DOUBLECLICKED"/>, deve avere lo stile <see cref="RadioButton"/> oppure <see cref="DrawnByOwner"/>.</remarks>
            SendsFocusNotifications = ButtonEnumerations.ButtonStyles.BS_NOTIFY,
            /// <summary>
            /// Crea un pulsante disegnato dal proprietario.
            /// </summary>
            /// <remarks>Il proprietario riceve il messaggio <see cref="Windows.WindowMessages.WM_DRAWITEM"/> quando un aspetto visuale è cambiato.<br/><br/>
            /// Questo stilo non deve essere combinato con nessun altro.</remarks>
            DrawnByOwner = ButtonEnumerations.ButtonStyles.BS_OWNERDRAW,
            /// <summary>
            /// Crea un push button che invia il messaggio <see cref="Windows.WindowMessages.WM_COMMAND"/> alla finestra proprietaria quando l'utente lo seleziona.
            /// </summary>
            PushButton = ButtonEnumerations.ButtonStyles.BS_PUSHBUTTON,
            /// <summary>
            /// Il pulsante ha lo stesso aspetto e agisce come un push button.
            /// </summary>
            PushButtonAlike = ButtonEnumerations.ButtonStyles.BS_PUSHLIKE,
            /// <summary>
            /// Crea un piccolo cerchio con testo.
            /// </summary>
            /// <remarks>Il testo viene mostrato alla destra del cerchio per impostazione predefinita.<br/>
            /// Combinare questo stile con <see cref="TextOnRightSideOfRectangle"/> per mostrare il testo alla sinistra.<br/>
            /// Usare questi pulsanti per gruppi di scelti correlate ma mutuamente esclusive.</remarks>
            RadioButton = ButtonEnumerations.ButtonStyles.BS_RADIOBUTTON,
            /// <summary>
            /// Giustifica a destra il testo nel rettangolo del pulsante.
            /// </summary>
            /// <remarks>Se il pulsante è un <see cref="Checkbox"/> o un <see cref="RadioButton"/> che non ha lo stile <see cref="TextOnRightSideOfRectangle"/> applicato, il testo è giustificato a destra a destra del pulsante.</remarks>
            TextRightJustified = ButtonEnumerations.ButtonStyles.BS_RIGHT,

            TextOnRightSideOfRectangle = ButtonEnumerations.ButtonStyles.BS_RIGHTBUTTON,
            /// <summary>
            /// Crea uno split button, questi pulsanti hanno un drop down.
            /// </summary>
            SplitButton = ButtonEnumerations.ButtonStyles.BS_SPLITBUTTON,
            /// <summary>
            /// Il pulsante mostra del testo.
            /// </summary>
#pragma warning disable CA1069 // I valori di enumerazione non devono essere duplicati
            DisplaysText = ButtonEnumerations.ButtonStyles.BS_TEXT,
#pragma warning restore CA1069 // I valori di enumerazione non devono essere duplicati
            /// <summary>
            /// Il testo è posizionato nella parte superiore del rettangolo del pulsante.
            /// </summary>
            TextAtTop = ButtonEnumerations.ButtonStyles.BS_TOP,
            /// <summary>
            /// Posiziona il testo in mezzo al rettangolo del pulsante.
            /// </summary>
            TextVerticallyCentered = ButtonEnumerations.ButtonStyles.BS_VCENTER
        }

        /// <summary>
        /// Stili di uno split button.
        /// </summary>
        [Flags]
        public enum SplitButtonStyles
        {
            /// <summary>
            /// Immagine allineata al margine sinistro.
            /// </summary>
            LeftAlignedImage = SplitButtonStyle.BCSS_ALIGNLEFT,
            /// <summary>
            /// Usa un'icona come immagine.
            /// </summary>
            IconAsGlyph = SplitButtonStyle.BCSS_IMAGE,
            /// <summary>
            /// Nessuna divisione.
            /// </summary>
            NoSplit = SplitButtonStyle.BCSS_NOSPLIT,
            /// <summary>
            /// Immagine allungata tentando di mantenere l'aspect ratio.
            /// </summary>
            GlyphStretched = SplitButtonStyle.BCSS_STRETCH
        }

        /// <summary>
        /// Tipo di immagine del pulsante.
        /// </summary>
        public enum ButtonImageType
        {
            /// <summary>
            /// Bitmap.
            /// </summary>
            Bitmap = ButtonEnumerations.ButtonImageType.IMAGE_BITMAP,
            /// <summary>
            /// Icona.
            /// </summary>
            Icon = ButtonEnumerations.ButtonImageType.IMAGE_ICON
        }

        /// <summary>
        /// Stato del pulsante.
        /// </summary>
        [Flags]
        public enum ButtonState
        {
            /// <summary>
            /// Non selezionato.
            /// </summary>
            Unchecked = ButtonEnumerations.ButtonState.BST_UNCHECKED,
            /// <summary>
            /// Selezionato.
            /// </summary>
            Checked = ButtonEnumerations.ButtonState.BST_CHECKED,
            /// <summary>
            /// Indeterminato.
            /// </summary>
            Indeterminate = ButtonEnumerations.ButtonState.BST_INDETERMINATE,
            /// <summary>
            /// Il pulsante è in stato premuto.
            /// </summary>
            Pushed = ButtonEnumerations.ButtonState.BST_PUSHED,
            /// <summary>
            /// Il pulsante ha il focus della tastiera.
            /// </summary>
            HasFocus = ButtonEnumerations.ButtonState.BST_FOCUS,
            /// <summary>
            /// Il mouse si trova sopra il cursore.
            /// </summary>
            IsUnderCursor = ButtonEnumerations.ButtonState.BST_HOT,
            /// <summary>
            /// Il drop-down del pulsante è aperto.
            /// </summary>
            DropdownOpen = ButtonEnumerations.ButtonState.BST_DROPDOWNPUSHED
        }
    }
}