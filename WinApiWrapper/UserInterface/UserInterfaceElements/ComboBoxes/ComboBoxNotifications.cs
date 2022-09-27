namespace WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes
{
    /// <summary>
    /// Notifiche usati dai ComboBox.
    /// </summary>
    internal static class ComboBoxNotifications
    {
        /// <summary>
        /// Inviata quando il list box di un ComboBox è stato chiuso.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Questa notifica non è inviato a un ComboBox con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SIMPLE"/> applicato.</remarks>
        internal const int CBN_CLOSEUP = 8;

        /// <summary>
        /// Inviata quando l'utente fa doppio click su una stringa nel list box di un ComboBox.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/>br/>
        /// Questa notifica viene inviato solo per i ComboBox con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SIMPLE"/> applicato.</remarks>
        internal const int CBN_DBLCLK = 2;

        /// <summary>
        /// Inviata quando il list box di un ComboBox sta per diventare visibile.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Questa notifica viene inviata solo dai ComboBox con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWN"/> oppure lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/> applicato.</remarks>
        internal const int CBN_DROPDOWN = 7;

        /// <summary>
        /// Inviata dopo che l'utente ha intrapreso un'azione che ha alterato il testo nel controllo di modifica.
        /// </summary>
        /// <remarks>Questa notifica viene inviata dopo che il sistema aggiorna lo schermo.<br/><br/>
        /// wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Questa notifica non viene inviata se lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/> è applicato al ComboBox.</remarks>
        internal const int CBN_EDITCHANGE = 5;

        /// <summary>
        /// Inviata quando il controllo di modifica di un ComboBox sta per visualizzare del testo alterato, dopo che il testo è stato formattato ma prima di mostrarlo.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Questa notifica non viene inviata se lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/> è applicato al ComboBox.</remarks>
        internal const int CBN_EDITUPDATE = 6;

        /// <summary>
        /// Inviata quando un ComboBox non può allocare abbastanza memoria per rispondere a una richiesta specifica.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.</remarks>
        internal const int CBN_ERRSPACE = -1;

        /// <summary>
        /// Inviata quando un ComboBox per il focus della tastiera.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.</remarks>
        internal const int CBN_KILLFOCUS = 4;

        /// <summary>
        /// Inviata quando l'utente cambia la selezione corrente nel list box di un ComboBox.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Per recuperare la selezione corrente, inviare il messaggio <see cref="ComboBoxMessages.CB_GETCURSEL"/> al controllo.<br/><br/>
        /// Questa notifica non viene inviata quando la selezione corrente cambia come risultato dell'elaborazione di un messaggio <see cref="ComboBoxMessages.CB_SETCURSEL"/>.</remarks>
        internal const int CBN_SELCHANGE = 1;

        /// <summary>
        /// Inviata quando l'utente seleziona un oggetto per poi dopo selezionare un'altro controllo oppure chiudere la finestra di dialogo.
        /// </summary>
        /// <remarks>Questa notifica indica che la selezione dell'utente è stata annullata.<br/><br/>
        /// wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Se un ComboBox ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SIMPLE"/> applicato, questa notifica non viene inviata.<br/>
        /// La notifica <see cref="CBN_SELENDOK"/> viene inviata immediatamente prima di ogni notifica <see cref="CBN_SELCHANGE"/>.</remarks>
        internal const int CBN_SELENDCANCEL = 10;

        /// <summary>
        /// Inviata quando l'utente seleziona un oggetto nella lista oppure quando seleziona un oggetto per poi chiudere la lista.
        /// </summary>
        /// <remarks>Questa notifica indica che la selezione del'utente deve essere elaborata.<br/><br/>
        /// wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.<br/><br/>
        /// Se il ComboBox ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SIMPLE"/>, questa notifica viene inviata immediatamente prima di ogni notifica <see cref="CBN_SELCHANGE"/>.</remarks>
        internal const int CBN_SELENDOK = 9;

        /// <summary>
        /// Inviata quando il ComboBox riceve il focus della tastiera.
        /// </summary>
        /// <remarks>wParam: i primi due byte contengono l'ID del ComboBox, il terzo e il quarto byte specificano il codice di notifica.<br/><br/>
        /// lParam: handle al ComboBox.</remarks>
        internal const int CBN_SETFOCUS = 3;
    }
}