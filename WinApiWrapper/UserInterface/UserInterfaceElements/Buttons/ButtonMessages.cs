using WinApiWrapper.General;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonConstants;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Messaggi inviati e ricevuti dai pulsanti.
    /// </summary>
    internal static class ButtonMessages
    {
        /// <summary>
        /// Imposta o richiede la dimensione migliore del pulsante e dell'immagine, se è presente una lista di immagini.
        /// </summary>
        /// <remarks>wParam: non usato, deve essere 0.<br/><br/>
        /// lParam: puntatore a struttura <see cref="GeneralStructures.SIZE"/> che riceve la dimensione desiderata del pulsante inclusi testo e lista di immagini, se presenti.<br/>
        /// L'applicazione è responsabile dell'allocazione della struttura, i campi <see cref="GeneralStructures.SIZE.x"/> e <see cref="GeneralStructures.SIZE.y"/> possono essere impostato a 0 se si vuole recuperare l'altezza e la larghezza ideali.<br/>
        /// Per specificare la larghezza del pulsante, impostare <see cref="GeneralStructures.SIZE.x"/> al valore desiderato, il sistema calcola l'altezza ideale per la larghezza fornita.<br/><br/>
        /// Se l'operazione è riuscita, restituisce true, false altrimenti.</remarks>
        internal const int BCM_GETIDEALSIZE = BCM_FIRST + 1;

        /// <summary>
        /// Recupera una struttura <see cref="BUTTON_IMAGELIST"/> che descrive la lista di immagini assegnata a un pulsante.
        /// </summary>
        /// <remarks>wParam: non usato, deve essere 0.<br/><br/>
        /// lParam: puntatore a struttura <see cref="BUTTON_IMAGELIST"/> che contiene le informazioni sulla lista immagini.<br/><br/>
        /// Se l'operazione è riuscita, restituisce true, false altrimenti.</remarks>
        internal const int BCM_GETIMAGELIST = BCM_FIRST + 3;

        /// <summary>
        /// Recupera il testo della nota associata con un pulsante di comando.
        /// </summary>
        /// <remarks>Questo messaggio funziona solamente con pulsanti con lo stile <see cref="ButtonEnumerations.ButtonStyles.BS_COMMANDLINK"/> oppure <see cref="ButtonEnumerations.ButtonStyles.BS_DEFCOMMANDLINK"/><br/><br/>
        /// wParam: Dimensione, in caratteri, del buffer puntato da lParam.<br/><br/>
        /// lParam: il buffer che riceve il testo, deve essere grande a sufficienza per includere il carattere nullo.<br/><br/>
        /// Se l'operazione è riuscita, restituisce true, false altrimenti.<br/><br/>
        /// In caso di errore il codice di errore impostato è uno dei seguenti:<br/><br/>
        /// <see cref="ERROR_NOT_SUPPORTED"/> (il pulsante non ha nessuno degli stili validi applicati)<br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer puntato da lParam è troppo piccolo, wParam contiene la dimensione necessaria, in caratteri.</remarks>
        internal const int BCM_GETNOTE = BCM_FIRST + 10;

        /// <summary>
        /// Recupera la lunghezza del testo della nota mostrata nella descrizione di un pulsante di comando.
        /// </summary>
        /// <remarks>Questo messaggio funziona solamente con pulsanti con lo stile <see cref="ButtonEnumerations.ButtonStyles.BS_COMMANDLINK"/> oppure <see cref="ButtonEnumerations.ButtonStyles.BS_DEFCOMMANDLINK"/><br/><br/>
        /// wParam e lParam sono entrambi 0.<br/><br/>
        /// Restituisce la lunghezza del testo della nota, in caratteri, escluso il carattere nullo finale, 0 se non esiste testo.</remarks>
        internal const int BCM_GETNOTELENGTH = BCM_FIRST + 11;

        /// <summary>
        /// Recupera informazioni su uno split button.
        /// </summary>
        /// <remarks>Questo messaggio funziona solamente con pulsanti con lo stile <see cref="ButtonEnumerations.ButtonStyles.BS_SPLITBUTTON"/> oppure <see cref="ButtonEnumerations.ButtonStyles.BS_DEFSPLITBUTTON"/><br/><br/>
        /// wParam: deve essere 0.<br/><br/>
        /// lParam: puntatore a struttura <see cref="BUTTON_SPLITINFO"/> che riceve le informazioni.<br/>
        /// Il chiamante alloca la memoria per la struttura, impostare in modo appropriato il campo <see cref="BUTTON_SPLITINFO.ValidMembers"/> per ricevere le informazioni richieste.<br/><br/>
        /// Se l'operazione è riuscita restituisce true, false altrimenti.</remarks>
        internal const int BCM_GETSPLITINFO = BCM_FIRST + 8;

        /// <summary>
        /// Recupera i margini usati per disegnare in un pulsante.
        /// </summary>
        /// <remarks>wParam: non usato, deve essere 0.<br/><br/>
        /// lParam: puntatore a struttura <see cref="GeneralStructures.RECT"/> che contiene i margini da usare per disegnare il testo.<br/><br/>
        /// Se l'operazione è riuscita restituisce true, false altrimenti.</remarks>
        internal const int BCM_GETTEXTMARGIN = BCM_FIRST + 5;

        /// <summary>
        /// Imposta lo stato del drop down per un pulsante con lo stile <see cref="ToolbarEnumerations.ToolbarStyles.TBSTYLE_DROPDOWN"/>.
        /// </summary>
        /// <remarks>wParam: true per lo stato <see cref="ToolbarEnumerations.ToolbarButtonStatus.BST_DROPDOWNPUSHED"/>, false altrimenti.<br/><br/>
        /// lParam: deve essere 0.<br/><br/>
        /// Restituisce true se l'operazione è riuscita, false altrimenti.</remarks>
        internal const int BCM_SETDROPDOWNSTATE = BCM_FIRST + 6;

        /// <summary>
        /// Assegna una lista di immagini a un pulsante.
        /// </summary>
        /// <remarks>wParam: non usato, deve essere 0.<br/><br/>
        /// lParam: puntatore a una struttura <see cref="BUTTON_IMAGELIST"/> che contiene le informazioni sulla lista.<br/><br/>
        /// Restituisce true se l'operazione è riuscita, false altrimenti.</remarks>
        internal const int BCM_SETIMAGELIST = BCM_FIRST + 2;

        /// <summary>
        /// Imposta il testo della nota associato a un pulsante di comando.
        /// </summary>
        /// <remarks>Questo messaggio funziona solamente con pulsanti con lo stile <see cref="ButtonEnumerations.ButtonStyles.BS_COMMANDLINK"/> oppure <see cref="ButtonEnumerations.ButtonStyles.BS_DEFCOMMANDLINK"/><br/><br/>
        /// wParam: deve essere 0.<br/><br/>
        /// lParam: puntatore a stringa a terminazione nulla che contiene la nota.<br/><br/>
        /// Restituisce true se l'operazione è riuscita, false altrimenti.</remarks>
        internal const int BCM_SETNOTE = BCM_FIRST + 9;

        /// <summary>
        /// Imposta il livello di elevazione richiesto per un pulsante così da mostrare l'icona di elevazione.
        /// </summary>
        /// <remarks>wParam: deve essere 0.<br/><br/>
        /// lParam: true per disegnare l'icona, false altrimenti.</remarks>
        internal const int BCM_SETSHIELD = BCM_FIRST + 12;

        /// <summary>
        /// Recupera le informazioni su un split button.
        /// </summary>
        /// <remarks>Questo messaggio funziona solamente con pulsanti con lo stile <see cref="ButtonEnumerations.ButtonStyles.BS_SPLITBUTTON"/> oppure <see cref="ButtonEnumerations.ButtonStyles.BS_DEFSPLITBUTTON"/><br/><br/>
        /// wParam: deve essere 0.<br/><br/>
        /// lParam: puntatore a una struttura <see cref="BUTTON_SPLITINFO"/> che contiene le informazioni sul pulsante.<br/><br/>
        /// Restituisce true se l'operazione è riuscita, false altrimenti.</remarks>
        internal const int BCM_SETSPLITINFO = BCM_FIRST + 7;

        /// <summary>
        /// Imposta i margini per disegnare il testo in un pulsante.
        /// </summary>
        /// <remarks>wParam: non usato, deve essere 0.<br/><br/>
        /// lParam: puntatore a struttura <see cref="GeneralStructures.RECT"/> che specifica i margini da usare per disegnar il testo.<br/><br/>
        /// Restituisce true se l'operazione è riuscita, false altrimenti.</remarks>
        internal const int BCM_SETTEXTMARGIN = BCM_FIRST + 4;

        /// <summary>
        /// Simula la pressione di un pulsante.
        /// </summary>
        /// <remarks>wParam e lParam non sono usati, devono essere 0.<br/><br/>
        /// Questo messaggio non restituisce un valore.</remarks>
        internal const int BM_CLICK = 245;

        /// <summary>
        /// Recupera lo stato di un radio button o di un check box.
        /// </summary>
        /// <remarks>wParam e lParam non sono usati, devono essere 0.<br/><br/>
        /// Restituisce uno dei valori dell'enumerazione <see cref="ButtonEnumerations.ButtonState"/> per i pulsanti il cui stile comprende <see cref="ButtonEnumerations.ButtonStyles.BS_3STATE"/>, <see cref="ButtonEnumerations.ButtonStyles.BS_AUTO3STATE"/>, <see cref="ButtonEnumerations.ButtonStyles.BS_AUTOCHECKBOX"/>, <see cref="ButtonEnumerations.ButtonStyles.BS_AUTORADIOBUTTON"/>, <see cref="ButtonEnumerations.ButtonStyles.BS_CHECKBOX"/> oppure <see cref="ButtonEnumerations.ButtonStyles.BS_RADIOBUTTON"/>.<br/><br/>
        /// Se il pulsante non ha nessuno degli stili indicati, il messaggio restituisce 0.</remarks>
        internal const int BM_GETCHECK = 240;

        /// <summary>
        /// Recupera un handle a una immagine associata con un pulsante.
        /// </summary>
        /// <remarks>wParam: uno dei valori dell'enumerazione <see cref="ButtonEnumerations.ButtonImageType"/>.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Restituisce un handle all'immagine, se esiste, altrimenti <see cref="IntPtr.Zero"/>.</remarks>
        internal const int BM_GETIMAGE = 246;

        /// <summary>
        /// Recupera lo stato di un pulsante o di un check box.
        /// </summary>
        /// <remarks>wParam e lParam non sono usati.<br/><br/>
        /// Restituisce un valore dell'enumerazione <see cref="ButtonEnumerations.ButtonState"/>, oppure <see cref="ToolbarEnumerations.ToolbarButtonStatus.BST_DROPDOWNPUSHED"/>.</remarks>
        internal const int BM_GETSTATE = 242;

        /// <summary>
        /// Imposta lo stato di un radio button o di un checkbox.
        /// </summary>
        /// <remarks>wParam: può avere uno dei seguenti valori:<br/><br/>
        /// <see cref="ButtonEnumerations.ButtonState.BST_CHECKED"/><br/>
        /// <see cref="ButtonEnumerations.ButtonState.BST_INDETERMINATE"/><br/>
        /// <see cref="ButtonEnumerations.ButtonState.BST_UNCHECKED"/><br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Restituisce 0.</remarks>
        internal const int BM_SETCHECK = 241;

        /// <summary>
        /// Imposta un'opzione in un  radio button che controlla la generazione di notifiche <see cref="ButtonNotifications.BN_CLICKED"/> quando il pulsante riceve focus.
        /// </summary>
        /// <remarks>wParam: true per impostare l'opzione, false alrtimenti.<br/><br/>
        /// lParam: non usato, deve essere 0.<br/><br/>
        /// Non restituisce nulla.</remarks>
        internal const int BM_SETDONTCLICK = 248;

        /// <summary>
        /// Associa una nuova immagine al pulsante.
        /// </summary>
        /// <remarks>wParam: uno dei valori dell'enumerazione <see cref="ButtonEnumerations.ButtonImageType"/>.<br/><br/>
        /// lParam: handle all'immagine da associare.<br/><br/>
        /// Restituisce un handle all'immagine precedente se esiste, altrimenti <see cref="IntPtr.Zero"/>.</remarks>
        internal const int BM_SETIMAGE = 247;

        /// <summary>
        /// Evidendia il pulsante come se l'utente lo avesse premuto.
        /// </summary>
        /// <remarks>wParam: true per evidenziare il pulsante , false annulla o stato evidenziato.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Restiuisce 0.</remarks>
        internal const int BM_SETSTATE = 243;

        /// <summary>
        /// Imposta lo stile di un pulsante.
        /// </summary>
        /// <remarks>wParam: gli stili del pulsante, una combinazione dei valori dell'enumerazione <see cref="ButtonEnumerations.ButtonStyles"/>.<br/><br/>
        /// lParam: i primi 4 byte di questo valore sono un booleano che specifica se il pulsante deve essere ridisegnato, true ridisegna il pulsante, false non ridisegna il pulsante.<br/><br/>
        /// Restituisce 0.</remarks>
        internal const int BM_SETSTYLE = 244;
    }
}