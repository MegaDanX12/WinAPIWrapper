using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonConstants;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Trackbars.TrackbarEnumerations;
using WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Common
{
    internal static class CommonNotifications
    {
        /// <summary>
        /// Notifica la finestra padre di un controllo relativamente a un'operazione di disegno personalizzata su di esso.
        /// </summary>
        /// <remarks>I valori di lParam, di wParam e quello restituito dipendono dal tipo di controllo che invia la notifica.<br/><br/>
        /// Se il controllo è un header o un rebar:<br/><br/>
        /// lParam punta a una struttura <see cref="NMCUSTOMDRAW"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemSpec"/> contiene l'indice dell'oggetto in corso di disegno.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemData"/> contiene i dati dell'oggetto.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>.<br/><br/>
        /// Se il controllo è un pulsante:<br/><br/>
        /// lParam punta a una struttura <see cref="NMCUSTOMDRAW"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemSpec"/> contiene l'indice dell'oggetto in corso di disegno.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemData"/> contiene i dati dell'oggetto.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>, deve essere restituito uno dei seguenti valori:<br/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NOTIFYPOSTERASE"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NOTIFYPOSTPAINT"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_SKIPDEFAULT"/><br/><br/>
        /// Se lo stile <see cref="ButtonStyles.BS_OWNERDRAW"/> è applicato, la notifica non viene inviata.<br/><br/>
        /// Se il controllo è una trackbar:<br/><br/>
        /// lParam punta a una struttura <see cref="NMCUSTOMDRAW"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemSpec"/> contiene uno dei valori dell'enumerazione <see cref="TrackbarParts"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemData"/> contiene i dati dell'oggetto.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>.<br/><br/>
        /// Se il controllo è una vista ad albero:<br/><br/>
        /// lParam punta a una struttura <see cref="NMTVCUSTOMDRAW"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemSpec"/> contiene un handle all'oggetto in corso di disegno.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemData"/> contiene i dati dell'oggetto.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>.<br/><br/>
        /// Se il controllo è un tooltip:<br/><br/>
        /// lParam punta a una struttura <see cref="NMTTCUSTOMDRAW"/>.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>.<br/><br/>
        /// Se il controllo è una list view:<br/><br/>
        /// lParam punta a una struttura <see cref="NMLVCUSTOMDRAW"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemSpec"/> contiene l'ID dell'oggetto in corso di disegno.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemData"/> contiene i dati dell'oggetto.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>, deve essere restituito uno dei valori dell'enumerazione <see cref="CustomDrawReturnFlags"/>.<br/><br/>
        /// Se il controllo è una toolbar:<br/><br/>
        /// lParam punta a una struttura <see cref="NMTBCUSTOMDRAW"/>.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemSpec"/> contiene l'ID dell'oggetto in corso di disegno.<br/>
        /// Il campo <see cref="NMCUSTOMDRAW.ItemData"/> contiene i dati dell'oggetto.<br/>
        /// Il valore restituito dipende dal passaggio in corso dell'operazione di disegno specificato dal campo <see cref="NMCUSTOMDRAW.DrawStage"/>, deve essere restituito uno dei valori delle seguenti enumerazioni:<br/><br/>
        /// <see cref="CustomDrawReturnFlags"/><br/>
        /// <see cref="Toolbars.ToolbarEnumerations.CustomDrawReturnFlags"/><br/><br/>
        /// Se il controllo è un header, una rebar, una trackbar, un vista ad albero oppure un tooltip, devono essere restituiti uno dei seguenti valori:<br/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_DODEFAULT"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NOTIFYITEMDRAW"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NOTIFYPOSTERASE"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NOTIFYPOSTPAINT"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NOTIFYSUBITEMDRAW"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_NEWFONT"/><br/>
        /// <see cref="CustomDrawReturnFlags.CDRF_SKIPDEFAULT"/></remarks>
        internal const int NM_CUSTOMDRAW = NM_FIRST - 12;

        /// <summary>
        /// Inviato da un controllo quando elabora un carattere.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMCHAR"/> con ulteriori informazioni sul carattere in elaborazione.<br/>
        /// Se il controllo è una toolbar il campo <see cref="NMCHAR.PreviousItem"/> contiene l'identificatore di comando dell'oggetto sul quale si trova il cursore, -1 se non esiste nessun oggetto del genere.<br/>
        /// Il campo <see cref="NMCHAR.NextItem"/> contiene l'identificatore di comando dell'oggetto che sul quale il cursore sta per passare sopra, -1 se il tasto non corrisponde a nessun acceleratore associato a un oggetto.
        /// Il valore restituito è ignorato da tutti i controlli tranne le toolbar.<br/>
        /// Per queste ultime true significa che la toolbar non deve elaborare il carattere, false, invece che la toolbar deve elaborare il carattere.</remarks>
        internal const int NM_CHAR = NM_FIRST - 18;

        /// <summary>
        /// Notifica la finestra padre di un controllo relativamente a un'operazione personalizzata relativa al testo.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMCUSTOMTEXT"/> che contiene altre informazioni sulla notifica.<br/><br/>
        /// Il valore restituito è ignorato dal controllo.</remarks>
        internal const int NM_CUSTOMTEXT = NM_FIRST - 24;

        /// <summary>
        /// Inviato da un controllo list view quando dopo il cambiamento del font.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> che contiene altre informazioni sulla notifica.<br/><br/>
        /// Il valore restituito è ignorato dal controllo.</remarks>
        internal const int NM_FONTCHANGED = NM_FIRST - 23;

        /// <summary>
        /// Inviato da un pulsante al suo controllo padre per richiedere misure per i due rettangolo dello split button.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMCUSTOMSPLITRECTINFO"/> che riceve le informazioni.<br/>
        /// La struttura viene inviata con la notifica come richiesta al padre di fornire le misure del rettangolo.<br/><br/>
        /// Questa notifica viene inviata da un pulsante prima del suo disegno, se i rettangoli restituiti dal controllo in lParam non sono validi, vengono ignorati.<br/><br/>
        /// Restituire <see cref="CustomDrawReturnFlags.CDRF_SKIPDEFAULT"/> per fare in modo che il pulsante usi i valori nella struttura, altrimenti restituire <see cref="CustomDrawReturnFlags.CDRF_DODEFAULT"/>.</remarks>
        internal const int NM_GETCUSTOMSPLITRECT = Buttons.ButtonConstants.BCN_FIRST + 3;

        /// <summary>
        /// Inviato da un controllo quando il mouse passa sopra un oggetto.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Restituire 0 per permettere al controllo di elaborare l'evento normalemente, diverso da 0 per impedire al controllo l'elaborazione.</remarks>
        internal const int NM_HOVER = NM_FIRST - 13;

        /// <summary>
        /// Inviato da un controllo che ha il focus della tastiera e l'utente preme un tasto.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMKEY"/> che contiene informazioni sul tasto che ha causato la notifica.<br/><br/>
        /// Restituire un valore diverso da 0 per impedire al controllo di elaborare il tasto, 0 altrimenti.</remarks>
        internal const int NM_KEYDOWN = NM_FIRST - 15;

        /// <summary>
        /// Notifica la finestra padre di un controllo che ha perso il focus dell'input.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> con informazioni sulla notifica.<br/><br/>
        /// Il valore retituito viene ignorato.</remarks>
        internal const int NM_KILLFOCUS = NM_FIRST - 8;

        /// <summary>
        /// Notifica la finestra padre di un controllo che il pulsante sinistro del mouse è stato premuto.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> con informazioni sulla notifica.<br/><br/>
        /// Il valore restituito viene ignorato.<br/><br/>
        /// Se il controllo è una toolbar:<br/><br/>
        /// lParam: puntatore a struttura <see cref="NMMOUSE"/> con informazioni sulla notifica.<br/><br/>
        /// Se il click è avvenuto su un oggetto della toolbar:<br/><br/>
        /// Il campo <see cref="NMMOUSE.ItemSpec"/> contiene l'identificatore dell'oggetto.<br/>
        /// Il campo <see cref="NMMOUSE.ItemData"/> contiene i dati dell'oggetto.<br/><br/>
        /// Se il click è avvenuto su un separatore:<br/><br/>
        /// Il campo <see cref="NMMOUSE.ItemSpec"/> contiene -1.<br/><br/>
        /// Restituire false per permettere alla toolbar di eseguire l'elaborazione predefinita dell'evento, true per impedire l'elaborazione.<br/><br/>
        /// Questa notifica viene inviata dopo la notifica <see cref="Toolbars.ToolbarNotifications.TBN_DROPDOWN"/>.</remarks>
        internal const int NM_LDOWN = NM_FIRST - 20;

        /// <summary>
        /// Inviato da una rebar quando il controllo riceve un messaggio <see cref="WindowMessages.WM_NCHITTEST"/>.
        /// </summary>
        /// <remarks>lParam: punatatore a struttura <see cref="NMMOUSE"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il campo <see cref="NMMOUSE.ItemSpec"/> contiene l'indice dell banda sulla quale il messaggio hit test è avvenuto.<br/>
        /// Il campo <see cref="NMMOUSE.Coordinates"/> contiene le coordinate del mouse del messaggio hit test.<br/><br/>
        /// Restituire 0 per permettere alla rebar di eseguire l'elaborazione predefinita del messaggio, restituire uno dei valori dell'enumerazione <see cref="WindowEnumerations.HitTestMessageReturn"/> per eseguire l'elaborazione non standard del messaggio.</remarks>
        internal const int NM_NCHITTEST = NM_FIRST - 14;

        /// <summary>
        /// Notifica la finestra padre di un controllo che quest'ultimo non ha potuto completare un'operazione perché la memoria è insufficiente.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il valore restituito viene ignorato del controllo.</remarks>
        internal const int NM_OUTOFMEMORY = NM_FIRST - 1;

        /// <summary>
        /// Notifica la finestra padre di un controllo che quest'ultimo sta rilasciando il puntatore del mouse.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> con informazioni sulla notifica.<br/><br/>
        /// Il valore di ritorno è ignorato.</remarks>
        internal const int NM_RELEASEDCAPTURE = NM_FIRST - 16;

        /// <summary>
        /// Notifica la finestra padre di un controllo che quest'ultimo ha ricevuto il focus dell'input e che l'utente ha premuto Invio.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il valore restituito è ignorato.<br/><br/>
        /// Se il controllo è una vista ad albero:<br/><br/>
        /// Restituire un valore diverso da 0 per impedire l'elaborazione predefinita, 0 per permetterla.</remarks>
        internal const int NM_RETURN = NM_FIRST - 4;

        /// <summary>
        /// Notifica la finestra padre di un controllo che quest'ultimo sta impostando il cursore in risposta a un messaggio <see cref="WindowMessages.WM_SETCURSOR"/>.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMMOUSE"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Restituire 0 per permettere al controllo l'impostazione del cursore, un valore diverso da 0 per impedire l'impostazione.</remarks>
        internal const int NM_SETCURSOR = NM_FIRST - 17;

        /// <summary>
        /// Notifica la finestra padre di un controllo che quest'ultimo ha ricevuto il focus dell'input.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il valore restituito è ignorato.</remarks>
        internal const int NM_SETFOCUS = NM_FIRST - 7;

        /// <summary>
        /// Notifica la finestra padre di un controllo che il tema è cambiato.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMHDR"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il valore restituito è ignorato.</remarks>
        internal const int NM_THEMECHANGED = NM_FIRST - 22;

        /// <summary>
        /// Notifica la finestra padre del controllo che quest'ultimo ha creato un tooltip.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMTOOLTIPSCREATED"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il valore restituito viene ignorato.</remarks>
        internal const int NM_TOOLTIPSCREATED = NM_FIRST - 19;

        /// <summary>
        /// Inviato da un controllo vista ad albero alla sua finestra padre, indica che l'immagine di stato sta cambiando.
        /// </summary>
        /// <remarks>lParam: puntatore a una struttura <see cref="NMTVSTATEIMAGECHANGING"/> che contiene informazioni sulla notifica.<br/><br/>
        /// Il valore restituito è ignorato.</remarks>
        internal const int NM_TVSTATEIMAGECHANGING = NM_FIRST - 24;
    }
}