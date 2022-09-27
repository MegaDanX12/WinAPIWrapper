using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxEnumerations;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ComboBox
{
    /// <summary>
    /// Enumerazioni relative ai ComboBox.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Attributi dei file.
        /// </summary>
        [Flags]
        public enum FileAttributes
        {
            /// <summary>
            /// Include archivi.
            /// </summary>
            Archive = FileDirectoryAttributes.DDL_ARCHIVE,
            /// <summary>
            /// Include le sottodirectory.
            /// </summary>
            /// <remarks>Le sottodirectory sono indicate tramite parentesi quadre ([])</remarks>
            Subdirectories = FileDirectoryAttributes.DDL_DIRECTORY,
            /// <summary>
            /// Tutti i dischi mappati sono inclusi.
            /// </summary>
            /// <remarks>I dischi sono indicati nella forma [-x-], dove x è la lettera di unità.</remarks>
            Drives = FileDirectoryAttributes.DDL_DRIVES,
            /// <summary>
            /// Include solo i file con gli attributi specificati.
            /// </summary>
            /// <remarks>Normalmente i file in lettura/scrittura sono inclusi anche se <see cref="ReadWrite"/> non è utilizzato.</remarks>
            OnlySpecifiedAttributes = FileDirectoryAttributes.DDL_EXCLUSIVE,
            /// <summary>
            /// Include i file nascosti.
            /// </summary>
            Hidden = FileDirectoryAttributes.DDL_HIDDEN,
            /// <summary>
            /// Include i file in sola lettura.
            /// </summary>
            ReadOnly = FileDirectoryAttributes.DDL_READONLY,
            /// <summary>
            /// Includi i file in lettura/scrittura senza altri attributi.
            /// </summary>
            /// <remarks>Questa è l'impostazione predefinita.</remarks>
            ReadWrite = FileDirectoryAttributes.DDL_READWRITE,
            /// <summary>
            /// Include file di sistema.
            /// </summary>
            System = FileDirectoryAttributes.DDL_SYSTEM,
            /// <summary>
            /// Utilizzare <see cref="WindowsAndMessages.MessagesAndMessageQueues.MessageManaged.PostMessage"/> al posto di <see cref="WindowsAndMessages.MessagesAndMessageQueues.MessageManaged.SendMessage"/> per inviare messaggi al ComboBox.
            /// </summary>
            UsePostMessage = FileDirectoryAttributes.DDL_POSTMSGS
        }

        /// <summary>
        /// Stato del pulsante di dropdown di un ComboBox.
        /// </summary>
        public enum DropdownButtonState
        {
            /// <summary>
            /// Esistente ma non premuto.
            /// </summary>
            NotPressed = ComboBoxButtonState.NotPressed,
            /// <summary>
            /// Non c'è nessun pulsante.
            /// </summary>
            Invisible = ComboBoxButtonState.STATE_SYSTEM_INVISIBLE,
            /// <summary>
            /// Premuto.
            /// </summary>
            Pressed = ComboBoxButtonState.STATE_SYSTEM_PRESSED
        }

        /// <summary>
        /// Stili di un ComboBox.
        /// </summary>
        [Flags]
        public enum ComboboxStyles
        {
            /// <summary>
            /// Il testo scorre a sinistra in automatico in un controllo di modifica quando l'utente scrive un carattere alla fine della linea.
            /// </summary>
            /// <remarks>Se questo stile non è impostato, solo il testo che è visibile nei bordi rettangolari è permesso.</remarks>
            AutoHorizontalScroll = ComboBoxStyles.CBS_AUTOHSCROLL,
            /// <summary>
            /// Visualizza una barra di scorrimento verticale disattivata nel list box quando esso non contiene abbastanza elementi per lo scorrimento.
            /// </summary>
            ShowDisabledVerticalScrollbar = ComboBoxStyles.CBS_DISABLENOSCROLL,
            /// <summary>
            /// Simile a <see cref="AlwaysDisplayListBox"/>, eccetto che il list box non viene visualizzato a meno che l'utente non selezioni un'icona vicina al controllo di modifica.
            /// </summary>
            Dropdown = ComboBoxStyles.CBS_DROPDOWN,
            /// <summary>
            /// Simile a <see cref="Dropdown"/>, eccetto che il controllo di modifica è sostituito da testo statico che mostra la selezione corrente nel list box.
            /// </summary>
            DisplayCurrentSelectionInStaticTextItem = ComboBoxStyles.CBS_DROPDOWNLIST,
            /// <summary>
            /// Un ComboBox disegnato dal proprietario contiene stringhe.
            /// </summary>
            /// <remarks>Il controllo mantiene la memoria e gli indirizzi delle stringhe.</remarks>
            ContainsStrings = ComboBoxStyles.CBS_HASSTRINGS,
            /// <summary>
            /// Tutto il testo nel campo di selezione e nella lista è minuscolo.
            /// </summary>
            LowercaseText = ComboBoxStyles.CBS_LOWERCASE,
            /// <summary>
            /// La dimensione del ComboBox è esattamente la dimensione specificata dall'applicazione quando lo ha creato.
            /// </summary>
            ExactSize = ComboBoxStyles.CBS_NOINTEGRALHEIGHT,
            /// <summary>
            /// Converte il testo inserito in un ComboBox dal set di caratteri Windows al set di caratteri OEM e poi nuovamente al set di caratteri Windows.
            /// </summary>
            /// <remarks>Questo stile si può applicare a ComboBox che hanno anche <see cref="AlwaysDisplayListBox"/> oppure <see cref="Dropdown"/> applicato.</remarks>
            ConvertsCharToOEMCharset = ComboBoxStyles.CBS_OEMCONVERT,
            /// <summary>
            /// Specifica che il proprietario del list box è responsabile per il disegno dei suoi contenuto e che gli elementi del list box hanno la stessa altezza.
            /// </summary>
            OwnerDrawnSameHeight = ComboBoxStyles.CBS_OWNERDRAWFIXED,
            /// <summary>
            /// Specifica che il proprietario del list box è responsabile per il disegno dei suoi contenuto e che gli elementi del list box hanno altezza variabile.
            /// </summary>
            OwnerDrawnVariableHeight = ComboBoxStyles.CBS_OWNERDRAWVARIABLE,
            /// <summary>
            /// Mostra il list box sempre, la selezione corrente è visualizzata nel controllo di modifica.
            /// </summary>
            AlwaysDisplayListBox = ComboBoxStyles.CBS_SIMPLE,
            /// <summary>
            /// Ordina automaticamente le stringhe aggiunte al list box.
            /// </summary>
            SortStrings = ComboBoxStyles.CBS_SORT,
            /// <summary>
            /// Tutto il testo nel campo di selezione e nella lista è maiusolo.
            /// </summary>
            UppercaseText = ComboBoxStyles.CBS_UPPERCASE
        }
    }
}