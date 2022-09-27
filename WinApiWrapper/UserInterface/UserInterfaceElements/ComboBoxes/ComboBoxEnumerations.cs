using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageFunctions;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes
{
    /// <summary>
    /// Enumerazioni usate dai controlli ComboBox.
    /// </summary>
    internal static class ComboBoxEnumerations
    {
        /// <summary>
        /// Attributi dei file e delle directory da aggiungere a un ComboBox.
        /// </summary>
        [Flags]
        internal enum FileDirectoryAttributes
        {
            /// <summary>
            /// Includi i file in lettura/scrittura senza altri attributi.
            /// </summary>
            /// <remarks>Questa è l'impostazione predefinita.</remarks>
            DDL_READWRITE,
            /// <summary>
            /// Include i file in sola lettura.
            /// </summary>
            DDL_READONLY,
            /// <summary>
            /// Include i file nascosti.
            /// </summary>
            DDL_HIDDEN,
            /// <summary>
            /// Include file di sistema.
            /// </summary>
            DDL_SYSTEM = 4,
            /// <summary>
            /// Include le sottodirectory.
            /// </summary>
            /// <remarks>Le sottodirectory sono indicate tramite parentesi quadre ([])</remarks>
            DDL_DIRECTORY = 16,
            /// <summary>
            /// Include archivi.
            /// </summary>
            DDL_ARCHIVE = 32,
            /// <summary>
            /// Utilizzare <see cref="PostMessage"/> al posto di <see cref="SendMessage"/> per inviare messaggi al ComboBox.
            /// </summary>
            DDL_POSTMSGS = 8192,
            /// <summary>
            /// Tutti i dischi mappati sono inclusi.
            /// </summary>
            /// <remarks>I dischi sono indicati nella forma [-x-], dove x è la lettera di unità.</remarks>
            DDL_DRIVES = 16384,
            /// <summary>
            /// Include solo i file con gli attributi specificati.
            /// </summary>
            /// <remarks>Normalmente i file in lettura/scrittura sono inclusi anche se <see cref="DDL_READWRITE"/> non è utilizzato.</remarks>
            DDL_EXCLUSIVE = 32768
        }

        /// <summary>
        /// Stato del pulsante di un ComboBox.
        /// </summary>
        internal enum ComboBoxButtonState
        {
            /// <summary>
            /// Il pulsante esiste e non è premuto.
            /// </summary>
            NotPressed,
            /// <summary>
            /// Non esiste nessun pulsante.
            /// </summary>
            STATE_SYSTEM_INVISIBLE = 32768,
            /// <summary>
            /// Il pulsante è premuto.
            /// </summary>
            STATE_SYSTEM_PRESSED = 8
        }

        /// <summary>
        /// Stili dei ComboBox.
        /// </summary>
        [Flags]
        internal enum ComboBoxStyles
        {
            /// <summary>
            /// Mostra il list box sempre, la selezione corrente è visualizzata nel controllo di modifica.
            /// </summary>
            CBS_SIMPLE = 1,
            /// <summary>
            /// Simile a <see cref="CBS_SIMPLE"/>, eccetto che il list box non viene visualizzato a meno che l'utente non selezioni un'icona vicina al controllo di modifica.
            /// </summary>
            CBS_DROPDOWN,
            /// <summary>
            /// Simile a <see cref="CBS_DROPDOWN"/>, eccetto che il controllo di modifica è sostituito da testo statico che mostra la selezione corrente nel list box.
            /// </summary>
            CBS_DROPDOWNLIST,
            /// <summary>
            /// Specifica che il proprietario del list box è responsabile per il disegno dei suoi contenuto e che gli elementi del list box sono tutti della stessa altezza.
            /// </summary>
            CBS_OWNERDRAWFIXED = 16,
            /// <summary>
            /// Specifica che il proprietario del list box è responsabile per il disegno dei suoi contenuto e che gli elementi del list box hanno altezza variabile.
            /// </summary>
            CBS_OWNERDRAWVARIABLE = 32,
            /// <summary>
            /// Il testo scorre a sinistra in automatico in un controllo di modifica quando l'utente scrive un carattere alla fine della linea.
            /// </summary>
            /// <remarks>Se questo stile non è impostato, solo il testo che è visibile nei bordi rettangolari è permesso.</remarks>
            CBS_AUTOHSCROLL = 64,
            /// <summary>
            /// Converte il testo inserito in un ComboBox dal set di caratteri Windows al set di caratteri OEM e poi nuovamente al set di caratteri Windows.
            /// </summary>
            /// <remarks>Questo stile si può applicare a ComboBox che hanno anche <see cref="CBS_SIMPLE"/> oppure <see cref="CBS_DROPDOWN"/> applicato.</remarks>
            CBS_OEMCONVERT = 128,
            /// <summary>
            /// Ordina automaticamente le stringhe aggiunte al list box.
            /// </summary>
            CBS_SORT = 256,
            /// <summary>
            /// Un ComboBox disegnato dal proprietario contiene stringhe.
            /// </summary>
            /// <remarks>Il controllo mantiene la memoria e gli indirizzi delle stringhe.</remarks>
            CBS_HASSTRINGS = 512,
            /// <summary>
            /// La dimensione del ComboBox è esattamente la dimensione specificata dall'applicazione quando lo ha creato.
            /// </summary>
            CBS_NOINTEGRALHEIGHT = 1024,
            /// <summary>
            /// Visualizza una barra di scorrimento verticale disattivata nel list box quando esso non contiene abbastanza elementi per lo scorrimento.
            /// </summary>
            CBS_DISABLENOSCROLL = 2048,
            /// <summary>
            /// Tutto il testo nel campo di selezione e nella lista è maiusolo.
            /// </summary>
            CBS_UPPERCASE = 8192,
            /// <summary>
            /// Tutto il testo nel campo di selezione e nella lista è minuscolo.
            /// </summary>
            CBS_LOWERCASE = 16384
        }
    }
}