using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxConstants;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes
{
    /// <summary>
    /// Messaggi relativi ai ComboBox.
    /// </summary>
    internal static class ComboBoxMessages
    {
        /// <summary>
        /// Aggiunge una stringa al list box di un ComboBox.
        /// </summary>
        /// <remarks>Se il controllo non ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SORT"/> applicato, la stringa è inserita alla fine della lista, altrimento la lista viene ordinata.<br/><br/>
        /// wParam: non usato<br/><br/>
        /// lParam: puntatore alla stringa a terminazione nulla da aggiungere.<br/>
        /// Se il ComboBox è disegnato dal suo proprietario ma lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_HASSTRINGS"/> non è applicato, il valore di lParam è memorizzato come dato di un'elemento anziché come la stringa a cui punta.<br/>
        /// I dati di un elemento possono essere recuperati o modificati inviando i messaggi <see cref="CB_GETITEMDATA"/> e <see cref="CB_SETITEMDATA"/> rispettivamente.<br/><br/>
        /// Il valore restituito è l'indice basato su 0 della stringa nel list box del ComboBox, in caso di errore viene restituito <see cref="CB_ERR"/>, se non c'è spazio insufficiente per memorizzare la nuova stringa viene restituito <see cref="CB_ERRSPACE"/>.</remarks>
        internal const int CB_ADDSTRING = 323;

        /// <summary>
        /// Elimina una stringa dal list box di un ComboBox.
        /// </summary>
        /// <remarks>wParam: indice basato su zero della stringa da eliminare.<br/><br/>
        /// lParam: non usato<br/><br/>
        /// Il valore restituito è il conteggio delle stringhe che rimangono nella lista, se wParam specifica un indica superiore al numero di oggetti nella lista, viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_DELETESTRING = 324;

        /// <summary>
        /// Aggiunge nomi di directory e file che corrispondono a una specifica stringa e a un set di attributi.
        /// </summary>
        /// <remarks>wParam: attributi dei file o delle directory da aggiungere, è un valore singolo o composito dell'enumerazione <see cref="ComboBoxEnumerations.FileDirectoryAttributes"/> (escluso <see cref="ComboBoxEnumerations.FileDirectoryAttributes.DDL_POSTMSGS"/>).<br/><br/>
        /// lParam: puntatore a una stringa.<br/><br/>
        /// La string puntata da lParam può specificare un percorso assoluto, relativo o un nome file.<br/>
        /// Un percorso assoluto può iniziare con una lettere di unità o con un nome UNC.<br/>
        /// Se specifica il nome di un file o di una directory, quest'ultimo che ha gli attributi specificati da wParam viene aggiunto alla lista.<br/>
        /// Se il nome del file contiene wildcard, tutte le directory e i file che corrispondo all'espressione e hanno gli attributi specificati da wParam vengono aggiunti alla lista.<br/><br/>
        /// Se wParam include <see cref="ComboBoxEnumerations.FileDirectoryAttributes.DDL_DIRECTORY"/> e lParam specifica tutte le sottodirectory della directory di primo livello, il list box conterrà sempre un voce ".." per la directory radice.<br/>
        /// Questo succede anche se la directory radice è nascosta o di sistema e wParam non specifica né <see cref="ComboBoxEnumerations.FileDirectoryAttributes.DDL_HIDDEN"/> né <see cref="ComboBoxEnumerations.FileDirectoryAttributes.DDL_SYSTEM"/>.<br/><br/>
        /// Se l'operazione riesce, il valore restituito è l'indice basato su zero dell'ultimo nome aggiunto alla lista, altrimenti viene restituito <see cref="CB_ERR"/>, se lo spazio è insufficiente per memorizzare le nuove stringhe, viene restituito <see cref="CB_ERRSPACE"/>.</remarks>
        internal const int CB_DIR = 325;

        /// <summary>
        /// Cerca nel list box di un ComboBox un oggetto che inizia con i caratteri nella stringa specificati.
        /// </summary>
        /// <remarks>wParam: indice basato su zero dell'oggetto che precede il primo da ricercare, se la ricerca raggiunge il fondo del list box, essa riprende dall'inizio della lista fino all'oggetto specificato da wParam.<br/>
        /// Se wParam ha valore -1, la ricerca avviene dall'inizio.<br/><br/>
        /// lParam: puntatore a stringa a terminazione nulla che contiene i caratteri da cercare, la ricerca ignora la differenza tra le lettere maiuscole e minuscole.<br/><br/>
        /// Il valore restituto è l'indice basato su zero dell'oggetto corrispondente, se la ricerca non ha successo, viene restitutio <see cref="CB_ERR"/>.</remarks>
        internal const int CB_FINDSTRING = 332;

        /// <summary>
        /// Trova nel list box di un ComboBox il primo elemento che corrisponde a una stringa specificata.
        /// </summary>
        /// <remarks>wParam: indice basato su zero dell'oggetto che precede il primo da ricercare, se la ricerca raggiunge il fondo del list box, essa riprende dall'inizio della lista fino all'oggetto specificato da wParam.<br/>
        /// Se wParam ha valore -1, la ricerca avviene dall'inizio.<br/><br/>
        /// lParam: puntatore a stringa a terminazione nulla, la ricerca ignora la differenza tra le lettere maiuscole e minuscole.<br/><br/>
        /// Il valore restituito e l'indice basato su zero dell'oggetto corrispondente, se la ricerca non ha successo, viene restituito <see cref="CB_ERR"/>.<br/><br/>
        /// Questo messaggio ha successo solo se la stringa specificata e l'oggetto nel list box hanno la stessa lunghezza (eccetto per il carattere nullo finale) e gli stessi caratteri.</remarks>
        internal const int CB_FINDSTRINGEXACT = 344;

        /// <summary>
        /// Recupera informazioni sul ComboBox.
        /// </summary>
        /// <remarks>wParam: non usato<br/><br/>
        /// lParam: puntatore a struttura <see cref="ComboBoxStructures.COMBOBOXINFO"/> che riceve le informazioni.<br/><br/>
        /// Se l'operazione ha successo, il valore di ritorna è diverso da zero, altrimenti viene restituto zero.</remarks>
        internal const int CB_GETCOMBOBOXINFO = 164;

        /// <summary>
        /// Recupera il numero di oggetti nel list box nel ComboBox.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Il valore restituito il numero di oggetti nel list box, in caso di errore viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_GETCOUNT = 146;

        /// <summary>
        /// Recupera il testo di default visualizzato nel controllo di modifica di un ComboBox.
        /// </summary>
        /// <remarks>wParam: puntatore a un buffer di stringa Unicode che riceve il testo, l'applicazione è responsabile della gestione della memoria.<br/>
        /// La dimensione del buffer deve essere uguale alla lunghezza del testo in caratteri più uno per il carattere nullo finale.<br/><br/>
        /// lParam: dimensione del buffer puntato da wParam.<br/><br/>
        /// Restituisce 1 se l'operazione ha successo, un codice di errore in caso contrario.<br/>
        /// Se il testo di default non è impostato, viene restituito 0, se l'applicazione non alloca il buffer o non imposta lParam prima dell'invio del messaggio, il comportamento non è definito e il valore restituito non è affidabile.</remarks>
        internal const int CB_GETCUEBANNER = CBM_FIRST + 4;

        /// <summary>
        /// Recupera l'indice dell'oggetto attualmente selezionato, se presente, nel list box del ComboBox.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Il valore restituito è l'indice in base 0 dell'oggetto attualmente selezionato, se nessun oggetto è selezionato, viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_GETCURSEL = 327;

        /// <summary>
        /// Recupera le coordinate dello schermo di un ComboBox quando il drop-down è attivo.
        /// </summary>
        /// <remarks>wParam: non usato.<br/><br/>
        /// lParam: puntatore a struttura <see cref="RECT"/> che riceve le coordinate del ComboBox.<br/><br/>
        /// Se il messaggio ha successo, il valore restituito è diverso da 0, in caso contrario viene restituito 0.</remarks>
        internal const int CB_GETDROPPEDCONTROLRECT = 338;

        /// <summary>
        /// Determina se il list box di un ComboBox è aperto o meno.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Se il list box è visibile, viene restituito true, altrimenti viene restituito false.</remarks>
        internal const int CB_GETDROPPEDSTATE = 343;

        /// <summary>
        /// Recupera la larghezza minima permessa, in pixel, del list box del ComboBox con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWN"/> oppure lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/>.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Se il messaggio ha successo, il valore restitutito è la larghezza, in pixel, in caso contrario viene restituito <see cref="CB_ERR"/>.<br/><br/>
        /// Per impostazione predefinita, la larghezza minima permessa del list box è 0, la larghezza del list box è quella più grande tra la minima e la larghezza del ComboBox.</remarks>
        internal const int CB_GETDROPPEDWIDTH = 351;

        /// <summary>
        /// Recupera la posizione del carattere iniziale e quella di quello finale della selezione corrente nel controllo di modifica di un ComboBox.
        /// </summary>
        /// <remarks>wParam: puntatore a valore DWORD che riceve la posizione iniziale della selezione, può essere nullo.<br/><br/>
        /// lParam: ountatore a valore DWORD che riceve la posizione finale della selezione, può essere nullo.<br/><br/>
        /// Il valore restituito è un DWORD basato su zero con la posizione iniziale della selezione nei primi due byte e la posizione finale del primo carattere dopo l'ultimo selezionato negli ultimi due byte.</remarks>
        internal const int CB_GETEDITSEL = 320;

        /// <summary>
        /// Determina se il ComboBox ha un'interfaccia utente predefinita o un'interfaccia utente estesa.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Se il ComboBox ha un'interfaccia utente estesa, viene restituito true, altrimenti viene restituto false.</remarks>
        internal const int CB_GETEXTENDEDUI = 342;

        /// <summary>
        /// Recupera la larghezza, in pixel, che il list box può scorrere orizzontalmente.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Il valore restituito è la larghezza che il list box può scorrere orizzontalmente, in pixel.</remarks>
        internal const int CB_GETHORIZONTALEXTENT = 349;

        /// <summary>
        /// Recupera il valore fornito dall'applicazione associato con un oggetto specificato nel ComboBox.
        /// </summary>
        /// <remarks>wParam: indice basato su zero dell'oggetto.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Il valore restituito è il valore associato con l'oggetto, in caso di errore, viene restituto <see cref="CB_ERR"/>.</remarks>
        internal const int CB_GETITEMDATA = 336;

        /// <summary>
        /// Determina l'altezza degli oggetti della lista o del campo di selezione in un ComboBox.
        /// </summary>
        /// <remarks>wParam: il componente del ComboBox la cui altezza deve essere recuperata.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// wParam deve essere -1 per recuperare l'altezza del campo di selezione, 0 per recuperare l'altezza degli oggetti della lista.<br/>
        /// Se il ComboBox ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_OWNERDRAWVARIABLE"/> applicato e deve essere recuperata l'altezza di un oggetto della lista, wParam deve essere l'indice basato su zero di quest'ultimo.<br/><br/>
        /// Il valore restituito è l'altezza, in pixel, degli oggetti nella lista del ComboBox.<br/>
        /// Se lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_OWNERDRAWVARIABLE"/> è applicato, il valore restituito è altezza dell'oggetto specificato da wParam.<br/>
        /// Se wParam ha valore -1, viene restituita l'altezza del controllo di modifica del ComboBox.<br/>
        /// Se si verifica un errore, viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_GETITEMHEIGHT = 340;

        /// <summary>
        /// Recupera una stringa dalla lista del ComboBox.
        /// </summary>
        /// <remarks>wParam: indice basato su zero della stringa da recuperare.<br/><br/>
        /// lParam: puntatore a un buffer che riceve la stringa, deve avere sufficiente spazio per la stringa e il carattere nullo finale.<br/><br/>
        /// Il valore restituito è la lunghezza della stringa, in caratteri, escluso il carattere nullo finale, se wParam non specifica un indice valido, viene restituito <see cref="CB_ERR"/>.<br/><br/>
        /// Se il ComboBox è stato disegnato dal suo proprietario ma senza lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_HASSTRINGS"/> applicato, il buffer puntato da lParam riceve i dati associati con l'oggetto.</remarks>
        internal const int CB_GETLBTEXT = 328;

        /// <summary>
        /// Recupera la lunghezza, in caratteri, di una stringa nella lista del ComboBox.
        /// </summary>
        /// <remarks>wParam: indice basato su zero della stringa.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Il valore restituito è la lunghezza, in caratteri, della stringa escluso il carattere nullo finale, se wParam non specifica un indica valido, viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_GETLBTEXTLEN = 329;

        /// <summary>
        /// Recupera la località corrente di un ComboBox.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Il valore restituito specifica la località corrente del ComboBox.<br/>
        /// Gli ultimi due byte contengono il codice della regione/località, i primi due byte contengono l'ID lingua.</remarks>
        internal const int CB_GETLOCALE = 346;

        /// <summary>
        /// Recupera il numero minimo degli oggetti visibili nella lista del drop-down di un ComboBox.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Il valore restituito è il numero minimo di elementi visibili.<br/><br/>
        /// Questo messaggio viene ignorato se il ComboBox ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_NOINTEGRALHEIGHT"/> applicato.</remarks>
        internal const int CB_GETMINVISIBLE = CBM_FIRST + 2;

        /// <summary>
        /// Recupera l'indice basato su zero del primo oggetto visibile nel list box di un ComboBox.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Se il messaggio ha successo, il valore restituito è l'indice del primo oggetto visibile, in caso di errore restituisce <see cref="CB_ERR"/>.</remarks>
        internal const int CB_GETTOPINDEX = 347;

        /// <summary>
        /// Alloca memoria per inserire elementi nel list box di un ComboBox.
        /// </summary>
        /// <remarks>wParam: numero di oggetti da aggiungere.<br/><br/>
        /// lParam: quantità di memoria da allocare per le stringhe, in byte.<br/><br/>
        /// Se il messaggio ha successo, il valore restituito è il numero totale di oggetti per cui la memoria è stata preallocata, cioè il numero di oggetti aggiunti da tutti i messaggi <see cref="CB_INITSTORAGE"/> che hanno avuto successo.<br/>
        /// In caso di errore, il valore restituito è <see cref="CB_ERRSPACE"/>.</remarks>
        internal const int CB_INITSTORAGE = 353;

        /// <summary>
        /// Inserisce una stringa o dati di un oggetto nella lista di un ComboBox.
        /// </summary>
        /// <remarks>wParam: indice basato su zero della posizione in cui inserire la stringa, se questo parametro ha valore -1, la stringa viene aggiunta alla fine della lista.<br/><br/>
        /// lParam: puntatore alla stringa a terminazione nulla da inserire.<br/><br/>
        /// Il valore restituito è l'indice in cui la stringa è stata inserita, in caso di errore viene restituito <see cref="CB_ERR"/>, se non c'è spazio sufficiente, viene restituito <see cref="CB_ERRSPACE"/>.</remarks>
        internal const int CB_INSERTSTRING = 330;

        /// <summary>
        /// Limita la lunghezza del testo che l'utente può inserire nel controllo di modifica di un ComboBox.
        /// </summary>
        /// <remarks>wParam: numero massimo di caratteri che l'utente può inserire, escluso il carattere nullo finale.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Restituisce sempre true.<br/><br/>
        /// Se wParam ha valore 0, il limite viene impostato a 2147483646 caratteri.<br/>
        /// Se il ComboBox non ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_AUTOHSCROLL"/> applicato, impostare un limite maggiore della larghezza del controllo di modifica non ha effetto.<br/>
        /// Questo messaggio non ha effetto su testo già presente nel controllo di modifica al momento dell'invio e non ha effetto sulla lunghezza del testo copiato nel controllo quando una stringa viene selezionata nel list box.<br/>
        /// Il limite predefinito è di 30000 caratteri.</remarks>
        internal const int CB_LIMITTEXT = 321;

        /// <summary>
        /// Rimuove tutti gli oggetti dal list box e dal controllo di modifica di un ComboBox.
        /// </summary>
        /// <remarks>wParam e lParam: non usati, devono essere 0.<br/><br/>
        /// Questo messaggio restituisce sempre <see cref="CB_OKAY"/>.</remarks>
        internal const int CB_RESETCONTENT = 331;

        /// <summary>
        /// Ricerca nella lista di un ComboBox per un oggetto che inizia con i caratteri nella stringa specificata.
        /// </summary>
        /// <remarks>wParam: indice basato su zero dell'oggetto che precede il primo oggetto da cercare.<br/><br/>
        /// lParam: puntatore a una stringa a terminazione nulla che contiene i caratteri da cercare.<br/><br/>
        /// Se la ricerca raggiunge la fine della lista ricomincia dall'inizio fino all'oggetto il cui indice è specificato da wParam.<br/>
        /// Se wParam ha valore -1, la ricerca avviene dall'inizio.<br/>
        /// La ricerca ignora la differenza tra maiuscole e minuscole.<br/><br/>
        /// Se la ricerca ha successo, il valore restituito è l'indice dell'oggetto selezionato, in caso contrario viene restituito <see cref="CB_ERR"/> e la selezione corrente non cambia.<br/>
        /// La stringa viene selezionata solo se i caratteri dal punto di inizio corrispondono ai caratteri della stringa prefisso.</remarks>
        internal const int CB_SELECTSTRING = 333;

        /// <summary>
        /// Imposta il testo predefinito visibile nel controllo di modifica di un ComboBox.
        /// </summary>
        /// <remarks>wParam: deve essere 0.<br/>
        /// lParam: puntatore a stringa Unicode a terminazione nulla che contiene il testo.<br/><br/>
        /// Restituisce 1 se l'operazione ha successo, un codice di errore in caso contrario.</remarks>
        internal const int CB_SETCUEBANNER = CBM_FIRST + 3;

        /// <summary>
        /// Seleziona una stringa nella lista di un ComboBox, se necessario la lista scorre per portarla in vista.
        /// </summary>
        /// <remarks>Il testo del controllo di modifica canbia per riflettere la nuova selezione, ogni selezione precedente viene rimossa.<br/><br/>
        /// wParam: indice basato su zero della stringa da selezionare.<br/>
        /// lParam: non usato.<br/><br/>
        /// Se wParam ha valore -1, la sezione attuale nella lista viene rimossa e il controllo di modifica viene pulito.<br/><br/>
        /// Se il messaggio ha successo, il valore restituito è l'indice dell'oggetto selezionato, se wParam ha un valore maggiore del numero di oggetti nella lista oppure -1, viene restituito <see cref="CB_ERR"/> e la selezione viene rimossa.</remarks>
        internal const int CB_SETCURSEL = 334;

        /// <summary>
        /// Imposta la larghezza minima permessa, in pixel, del list box di un ComboBox con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWN"/> oppure lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/> applicato.
        /// </summary>
        /// <remarks>wParam: larghezza minima permessa del list box, in pixel.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Se il messaggio ha successo, il valore restituito e la nuova larghezza del list box, in caso di errore viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_SETDROPPEDWIDTH = 352;

        /// <summary>
        /// Seleziona caratteri nel controllo di modifica di un ComboBox.
        /// </summary>
        /// <remarks>wParam: non usato.<br/><br/>
        /// lParam: i primi due byte specificano la posizione di partenza, il terzo e il quarto byte specificano la posizione finale.<br/><br/>
        /// Se i primi due byte di lParam hanno valore -1, la selezione, se esiste, viene rimossa.<br/>
        /// Se il terzo e il quarto byte hanno valore -1, tutto il testo dalla posizione di partenza all'ultimo carattere nel controllo di modifica è selezionato.<br/><br/>
        /// Se il messaggio ha successo, restituisce true, se il messaggio viene inviato a un ComboBox che ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/> applicato, viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_SETEDITSEL = 322;

        /// <summary>
        /// Attiva o disattiva l'interfaccia utente estesa per un ComboBox.
        /// </summary>
        /// <remarks>wParam: true per usare l'interfaccia utente estesa, false per usare quella predefinita.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Se l'operazione ha successo, viene restituito <see cref="CB_OKAY"/>, in caso di errore viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_SETEXTENDEDUI = 341;

        /// <summary>
        /// Imposta la larghezza, in pixel, della quale il list box può scorrere orizzontalmente.
        /// </summary>
        /// <remarks>Se la larghezza del list box è più piccola del nuovo valore, la barra di scorrimento orizzontale scorre gli oggetti orizzontalmente, se è uguale o maggiore del nuovo valore, la barra di scorrimento è nascosta o disabilitata (se lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DISABLENOSCROLL"/>.<br/><br/>
        /// wParam: specifica la larghezza di scorrimento del list box, in pixel.<br/><br/>
        /// lParam: non usato.</remarks>
        internal const int CB_SETHORIZONTALEXTENT = 350;

        /// <summary>
        /// Imposta il valore associato a uno specifico oggetto in un ComboBox.
        /// </summary>
        /// <remarks>wParam: indice basato su zero dell'oggetto.<br/><br/>
        /// lParam: nuovo valore da associare all'oggetto.<br/><br/>
        /// Restituisce <see cref="CB_ERR"/> in caso di errore.</remarks>
        internal const int CB_SETITEMDATA = 337;

        /// <summary>
        /// Imposta l'altezza degli oggetti della lista o del campo di selezione in un ComboBox.
        /// </summary>
        /// <remarks>wParam: il componente del ComboBox del quale impostare l'altezza.<br/><br/>
        /// lParam: altezza, in pixel, del componente del ComboBox identificato da wParam.<br/><br/>
        /// wParam deve avere valore 1 per impostare l'altezza del campo di selezione, 0 per impostare l'altezza degli oggetti della lista.<br/>
        /// Se il ComboBox ha lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_OWNERDRAWVARIABLE"/> applicato, wParam deve essere l'indice basato su zero di uno specifico elemento.<br/><br/>
        /// Se l'indice o l'alteza non sono validi, viene restituito <see cref="CB_ERR"/>.</remarks>
        internal const int CB_SETITEMHEIGHT = 339;

        /// <summary>
        /// Imposta la località corrente del ComboBox.
        /// </summary>
        /// <remarks>wParam: ID località che il ComboBoc userà per l'ordinamento quando viene aggiunto testo.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Il valore restituito è l'ID località precedente, se wParam specifica una località non installata nel sistema, viene restituito <see cref="CB_ERR"/> e quella attuale non cambia.</remarks>
        internal const int CB_SETLOCALE = 345;

        /// <summary>
        /// Imposta il numero minimo di oggetti visibili nella lista drop-down di un ComboBox.
        /// </summary>
        /// <remarks>wParam: numero minimo di oggetti visibili.<br/><br/>
        /// lParam: non usato, deve essere 0.<br/><br/>
        /// Se il messaggio ha successo, il valore restituito è true, altrimenti è false.<br/><br/>
        /// Quando il numero di oggetti nella lista drop-down è maggiore del minimo, il ComboBox usa una barra di scorrimento.<br/>
        /// Il valore predefinito è di 30 elementi.</remarks>
        internal const int CB_SETMINVISIBLE = CBM_FIRST + 1;

        /// <summary>
        /// Assicura che un particolare oggetto sia visibile nel list box di un ComboBox.
        /// </summary>
        /// <remarks>Il sistema scorre il list box fino a quando l'oggetto specificato appare in alto oppure fino al massimo raggio di scorrimento.<br/><br/>
        /// wParam: indice basato su zero dell'oggetto della lista.<br/><br/>
        /// lParam: non usato.<br/><br/>
        /// Se il messaggio ha successo, il valore di ritorno è 0, in caso contrario, il valore di ritorno è <see cref="CB_ERR"/>.</remarks>
        internal const int CB_SETTOPINDEX = 348;

        /// <summary>
        /// Mostra o nasconde il list box di un ComboBox con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWN"/> oppure lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_DROPDOWNLIST"/> applicato.
        /// </summary>
        /// <remarks>wParam: true per visualizzare il list box, false per nasconderlo (Valore BOOL).<br/><br/>
        /// Restituisce sempre true.<br/><br/>
        /// Questo messaggio non ha effetto su un ComboBox creato con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SIMPLE"/> applicato.</remarks>
        internal const int CB_SHOWDROPDOWN = 335;
    }
}