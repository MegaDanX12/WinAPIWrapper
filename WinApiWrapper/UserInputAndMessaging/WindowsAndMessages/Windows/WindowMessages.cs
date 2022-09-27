using WinApiWrapper.UserInterface.UserInterfaceElements;
using WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonStructures;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows
{
    /// <summary>
    /// Messaggi finestre.
    /// </summary>
    internal static class WindowMessages
    {
        #region Non Client Area Messages
        /// <summary>
        /// Inviato a una finestra per determinare quale parte di essa corrisponde a determinate coordinate dello schermo.
        /// </summary>
        /// <remarks>wParam: non usato.<br/>
        /// lParam: i primi 16 bit sono le coordinate x del cursore, i bit restanti sono le coordinate y del cursore.<br/>
        /// Entrambe le coordinate sono relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Il valore di ritorno per questo messaggio è un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>.</remarks>
        internal const uint WM_NCHITTEST = 0x0084;

        /// <summary>
        /// Inviato quando l'utente fa doppio click con il tasto sinistro del mouse mentre il cursore si trova all'interno dell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore.<br/>
        /// Se una finestra ha catturato il mouse, questo messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WindowMessages.WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCLBUTTONDBLCLK = 0x00A3;

        /// <summary>
        /// Inviato quando l'utente preme il tasto sinistro del mouse mentre il cursore si trova all'interno dell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore.
        /// Se una finestra ha catturato il mouse, questo messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WindowMessages.WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCLBUTTONDOWN = 0x00A1;

        /// <summary>
        /// Inviato quando l'utente rilascia il tasto sinistro del mouse mentre il cursore si trova all'interno dell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore.
        /// Se una finestra ha catturato il mouse, questo messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WindowMessages.WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCLBUTTONUP = 0x00A2;

        /// <summary>
        /// Inviato quando l'utente fa doppio click il tasto centrale del mouse mentre il cursore si trova all'interno dell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore.
        /// Se una finestra ha catturato il mouse, questo messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCMBUTTONDBLCLK = 0x00A9;

        /// <summary>
        /// Inviato quando l'utente preme il tasto centrale del mouse mentre il cursore si trova all'interno dell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore.
        /// Se una finestra ha catturato il mouse, questo messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCMBUTTONDOWN = 0x00A7;

        /// <summary>
        /// Inviato quando l'utente rilascia il tasto centrale del mouse mentre il cursore si trova all'interno dell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore.
        /// Se una finestra ha catturato il mouse, questo messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCMBUTTONUP = 0x00A8;

        /// <summary>
        /// Inviato quando il cursore passa sopra l'area non client di una finestra per un periodo di tempo specificato in una chiamata precedente alla funzione <see cref="LegacyUserInteraction.MouseInput.MouseInputFunctions.TrackMouseEvent"/>.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCMOUSEHOVER = 0x02A0;

        /// <summary>
        /// Inviato quando il cursore lascia l'area non client di una finestra specificata in una chiamata precedente alla funzione <see cref="LegacyUserInteraction.MouseInput.MouseInputFunctions.TrackMouseEvent"/>.
        /// </summary>
        /// <remarks>wParam: non usato, deve essere 0.<br/>
        /// lParam: non usato, deve essere 0.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCMOUSELEAVE = 0x02A2;

        /// <summary>
        /// Inviato quando il cursore si muove mentre si trova nell'area non client di una finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCMOUSEMOVE = 0x00A0;

        /// <summary>
        /// Inviato quando l'utente fa doppio click con il pulsante destro del mouse mentre il cursore si trova nell'area non client di una finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCRBUTTONDBLCLK = 0x00A6;

        /// <summary>
        /// Inviato quando l'utente preme il pulsante destro del mouse mentre il cursore si trova nell'area non client di una finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCRBUTTONDOWN = 0x00A4;

        /// <summary>
        /// Inviato quando l'utente rilascia il pulsante destro del mouse mentre il cursore si trova nell'area non client di una finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: Un valore dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/>, risultato dell'elaborazione del messaggio <see cref="WM_NCHITTEST"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, dovrebbe restituire 0.</remarks>
        internal const uint WM_NCRBUTTONUP = 0x00A5;

        /// <summary>
        /// Inviato quando l'utente fa doppio click sul primo o sul secondo pulsante X mentre il cursore si trova nell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: un valore dell'enumerazione <see cref="WindowEnumerations.XButtonDoubleClickWParamValues"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora il messaggio dovrebbe restituire true.</remarks>
        internal const uint WM_NCXBUTTONDBLCLK = 0x00AD;

        /// <summary>
        /// Inviato quando l'utente preme il primo o il secondo pulsante X mentre il cursore si trova nell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: un valore dell'enumerazione <see cref="WindowEnumerations.XButtonDoubleClickWParamValues"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora il messaggio dovrebbe restituire true.</remarks>
        internal const uint WM_NCXBUTTONDOWN = 0x00AB;

        /// <summary>
        /// Inviato quando l'utente rilascia il primo o il secondo pulsante X mentre il cursore si trova nell'area non client della finestra.<br/>
        /// Questo messaggio viene inviato alla finestra che contiene il cursore, se una finestra ha catturato il mouse, il messaggio non viene inviato.
        /// </summary>
        /// <remarks>wParam: un valore dell'enumerazione <see cref="WindowEnumerations.XButtonDoubleClickWParamValues"/>.<br/>
        /// lParam: Struttura <see cref="POINTS"/> che contiene le coordinate x e y del cursore, relative all'angolo superiore sinistro dello schermo.<br/><br/>
        /// Se l'applicazione elabora il messaggio dovrebbe restituire true.</remarks>
        internal const uint WM_NCXBUTTONUP = 0x00AC;
        #endregion
        /// <summary>
        /// Inviato alle finestre top-level quando le impostazioni o i criteri di gruppo sono cambiate.
        /// </summary>
        /// <remarks>wParam: se risultato da una chiamata a <see cref="Configuration.ConfigurationFunctions.SystemParametersInfo"/>, il valore corrisponde al parametro uiAction.<br/>
        /// Se risultato da un cambiamento nei criteri di gruppo, il parametro ha valore 0 se il cambiamento riguarda i criteri utente, 1 se rigurda i criteri di sistema.<br/>
        /// Se risultato di un cambiamento delle impostazioni della località, ha valore 0.<br/>
        /// Se inviato da un'applicazione, deve essere nullo.<br/><br/>
        /// lParam: se risultato da una chiamata a <see cref="Configuration.ConfigurationFunctions.SystemParametersInfo"/>, il valore è una stringa che indica l'area che contiene il parametro modificato..<br/>
        /// Se risultato da un cambiamento nei criteri di gruppo, è sempre la stringa "Policy".<br/>
        /// Se risultato di un cambiamento delle impostazioni della località, è sempre la string "intl".<br/>
        /// Potrebbe anche essere la stringa "Environment" per indicare un cambiamento nelle variabili di ambiente del sistema o dell'utente.<br/><br/>
        /// Se questo messaggio viene elaborato il valore restituito deve essere 0.</remarks>
        internal const int WM_SETTINGCHANGE = 0x001A;

        /// <summary>
        /// Inviato da un controllo comune alla sua finestra padre quando si verifica un evento o quando il controllo richiede informazioni.
        /// </summary>
        /// <remarks>wParam: ID del controllo comune che invia il messaggio, non è detto che sia univoco.<br/>
        /// Il campo <see cref="NMHDR.SenderWindowHandle"/> oppure <see cref="NMHDR.SenderControlID"/> dovrebbero essere usati per identificare il controllo.<br/><br/>
        /// lParam: puntatore a struttura <see cref="NMHDR"/> che contine il codice di notifica e altre informazioni.<br/>
        /// Per alcuni codici questo parametro punta a una struttura più grande il cui primo campo è una struttura <see cref="NMHDR"/>.<br/><br/>
        /// Il valore restituito viene ignorato eccetto per i messaggi di notifica che specificano altrimenti.</remarks>
        internal const int WM_NOTIFY = 0x004E;

        /// <summary>
        /// Inviato quando l'utente seleziona un'opzione da un menù, quando un controllo invia un messaggio di notifica alla finestra padre oppure quando la pressione di un pulsante di un acceleratore viene tradotta.
        /// </summary>
        /// <remarks>wParam: uno dei seguenti valori:<br/><br/>
        /// 0 (primi 2 byte), ID menù (ultimi 2 byte), se il controllo è un menù<br/>
        /// 1 (primi 2 byte), ID acceleratore (ultimi 2 byte), se il controllo è un acceleratore<br/>
        /// codice di notifica (primi 2 byte), ID controllo (ultimi 2 byte), per un controllo generico<br/><br/>
        /// lParam: uno dei seguenti valori:<br/><br/>
        /// 0 per un menù e un acceleratore<br/>
        /// Handle alla finestra padre per un controllo generico<br/><br/>
        /// Se questo messaggio viene elaborato il valore restituio deve essere 0.</remarks>
        internal const int WM_COMMAND = 0x0111;

        /// <summary>
        /// Inviato alla finestra padre di un pulsante prima dell'inizio dell sua procedura di disegno.
        /// </summary>
        /// <remarks>Solo i pulsanti disegnati dal proprietario rispondono all'elaborazione da parte della finestra padre di questo messaggio.<br/><br/>
        /// wParam: handle al contesto di visualizzazione per il pulsante.<br/><br/>
        /// lParam: handle al pulsante.<br/><br/>
        /// Se l'applicazione elabora questo messaggio, deve restituire un handle a un pennello.<br/><br/>
        /// Se l'handle si riferisce un pennello creato dall'applicazione, è sua responsabilità eliminarlo.</remarks>
        internal const int WM_CTLCOLORBTN = 0x0135;

        /// <summary>
        /// Determina se una finestra accetta strutture ANSI o Unicode nel messaggio <see cref="WM_NOTIFY"/>.
        /// </summary>
        /// <remarks>Questo messaggio è inviato da un controllo comune alla sua finestra padre e da quest'ultima al controllo.<br/><br/>
        /// wParam: handle alla finestra che sta inviando il messaggio.<br/>
        /// Se lParam è <see cref="WindowEnumerations.NotifyFormatMessageCommand.NF_QUERY"/>, questo parametro è l'handle al controllo.<br/>
        /// Se lParam è <see cref="WindowEnumerations.NotifyFormatMessageCommand.NF_REQUERY"/>, questo parametro è un handle alla finestra padre del controllo.<br/><br/>
        /// lParam: il comando che specifica la natura del messaggio, è uno dei valori dell'enumerazione <see cref="WindowEnumerations.NotifyFormatMessageCommand"/>.<br/><br/>
        /// Restituisce uno dei valori dell'enumerazione <see cref="WindowEnumerations.NotifyFormatReturnValue"/>.</remarks>
        internal const int WM_NOTIFYFORMAT = 0x0055;

        /// <summary>
        /// Definisce i messaggi privati da usare da classi di finestre private.
        /// </summary>
        internal const int WM_USER = 0x0400;

        /// <summary>
        /// Definisce i messaggi privati.
        /// </summary>
        internal const int WM_APP = 0x8000;

        /// <summary>
        /// Recupera informazioni sulla selezione corrente in una finestra di dialogo di selezione font.
        /// </summary>
        /// <remarks>wParam: non usato<br/><br/>
        /// lParam: puntatore a struttura <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures.LOGFONT"/> che riceve le informazioni sulla selezione corrente.<br/><br/>
        /// Questo messaggio non restituisce nulla.</remarks>
        internal const int WM_CHOOSEFONT_GETLOGFONT = WM_USER + 1;
        #region Control Specific Messages
        /// <summary>
        /// Inviato per determinare la posizione relativa di un nuovo oggetto nella lista ordinata di un ComboBox o di un list box disegnato dal suo proprietario.
        /// </summary>
        /// <remarks>Questo messaggio viene inviato dal sistema al proprietario del ComboBox o list box creati con lo stile <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_SORT"/> e <see cref="ListBoxEnumerations.ListBoxStyles.LBS_SORT"/> applicati rispettivamente.<br/><br/>
        /// wParam: ID del controllo che ha inviato il messaggio.<br/><br/>
        /// lParam: puntatore a struttura <see cref="WindowStructures.COMPAREITEMSTRUCT"/> che contiene gli ID e i dati forniti dall'applicazione per i due oggetti nel ComboBox o nel list box.<br/><br/>
        /// Il valore restituito indica la posizione relativa dei due oggetti, l'enumerazione <see cref="WindowEnumerations.CompareItemResult"/> include i valori possibili.<br/><br/>
        /// Quando il proprietario di un ComboBox o di un list box che è responsabile del loro disegno riceve questo messaggio, esso deve restituire un valore che indica quale degli oggetti specificati dalla struttura <see cref="WindowStructures.COMPAREITEMSTRUCT"/> appare prima dell'altro.<br/>
        /// In generale, il sistema invia questo messaggio più volte fino a quando non determina la posizione esatta per il nuovo oggetto.<br/>
        /// Se la procedura di una finestra di dialogo gestisce questo messaggio, dovrebbe convertire il valore da restituire in un BOOL e restituirlo direttamente.</remarks>
        internal const int WM_COMPAREITEM = 0x0039;

        /// <summary>
        /// Inviato alla finestra padre di un pulsante disegnato dal proprietario, di un ComboBox, di un list box o di un menù quando l'aspetto del controllo è cambiato.
        /// </summary>
        /// <remarks>wParam: ID del controllo che ha inviato il messaggio, 0 se il controllo è un menù.<br/><br/>
        /// lParam: puntatore a struttura <see cref="WindowStructures.DRAWITEMSTRUCT"/> che contiene le informazioni sull'oggetto da disegnare e il tipo di disegno richiesto.<br/><br/>
        /// Se un applicazione elabora questo messaggio, dovrebbe restituire true.<br/><br/>
        /// Il campo <see cref="WindowStructures.DRAWITEMSTRUCT.Action"/> specifica l'operazione di disegno da eseguire.<br/>
        /// Prima di terminare l'elaborazione del messaggio, l'applicazione dovrebbe assicurarsi che il contesto dispositivo identificato da campo <see cref="WindowStructures.DRAWITEMSTRUCT.DeviceContextHandle"/> sia nello stato predefinito.</remarks>
        internal const int WM_DRAWITEM = 0x002B;

        /// <summary>
        /// Inviato alla finestra padre di un ComboBox, di un list box, di un listview o di un oggetto menù al momento della sua creazione.
        /// </summary>
        /// <remarks>wParam: ID del controllo, 0 se inviato da un menù.<br/>
        /// Se il valore è diverso da zero oppure se ha valore 0 ma il valore del campo <see cref="WindowStructures.MEASUREITEMSTRUCT.ControlType"/> ha un valore diverso da <see cref="GeneralEnumerations.OwnerDrawnControlType.ODT_MENU"/>, il messaggio è stato inviato da un ComboBox o da un list box.<br/>
        /// Se il valore è diverso da zero e il valore del campo <see cref="WindowStructures.MEASUREITEMSTRUCT.ControlID"/> è 1, il messaggio è stato inviato dal controllo di modifica di un ComboBox.<br/><br/>
        /// lParam: puntatore a struttura <see cref="WindowStructures.MEASUREITEMSTRUCT"/> che contiene le dimensioni del controllo disegnato dal proprietario o del oggetto di menù.<br/><br/>
        /// Se un'applicazione elabora questo messaggio, dovrebbe restituire true.<br/><br/>
        /// Quando la finestra proprietaria riceve il messaggio deve riempire la struttura <see cref="WindowStructures.MEASUREITEMSTRUCT"/> puntata da lParam e poi restituire.</remarks>
        internal const int WM_MEASUREITEM = 0x002C;
        #endregion
        #region Dialog Boxes Messages
        /// <summary>
        /// Inviato a una finestra di dialogo prima che essa sia visualizzata.
        /// </summary>
        /// <remarks>wParam: handle al controllo che riceve il focus della tastiera.<br/><br/>
        /// lParam: altri dati di inizializzazione.<br/>
        /// Questi dati vengono passati tramite il parametro di tipo LPARAM nelle funzioni:<br/><br/>
        /// <see cref="UserInterfaceElements.DialogBoxes.DialogBoxesFunctions.CreateDialogIndirectParam"/><br/>
        /// <see cref="UserInterfaceElements.DialogBoxes.DialogBoxesFunctions.CreateDialogParam"/><br/>
        /// <see cref="UserInterfaceElements.DialogBoxes.DialogBoxesFunctions.DialogBoxIndirectParam"/><br/>
        /// <see cref="UserInterfaceElements.DialogBoxes.DialogBoxesFunctions.DialogBoxParam"/><br/><br/>
        /// Questo parametro è un puntatore a una struttura <see cref="UserInterfaceElements.PropertySheets.PropertySheetsStructures.PROPSHEETPAGE"/> se il controllo è una finestra di proprietà.<br/><br/>
        /// La procedura della finestra di dialogo dovrebbe restituire true per indicare al sistema di impostare il focus della tastiera al controllo specificato da wParam, altrimenti dovrebbe restituire false per impedire l'impostazione.<br/>
        /// Il valore dovrebbe essere restituito direttamente.<br/><br/>
        /// Un'applicazione può restituire false solo se ha impostato il focus della tastiera a uno dei controlli della finestra di dialogo.</remarks>
        internal const int WM_INITDIALOG = 0x0110;
        #endregion
    }
}