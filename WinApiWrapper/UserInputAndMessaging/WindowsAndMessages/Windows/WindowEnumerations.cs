namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows
{
    /// <summary>
    /// Enumerazioni finestre.
    /// </summary>
    internal static class WindowEnumerations
    {
        /// <summary>
        /// Valori di ritorno per il messaggio <see cref="WindowMessages.WM_NCHITTEST"/>.
        /// </summary>
        internal enum HitTestMessageReturn
        {
            /// <summary>
            /// Bordo di una finestra che non ha un bordo di ridimensionamento.
            /// </summary>
            HTBORDER = 18,
            /// <summary>
            /// Bordo orizzontale inferiore di una finestra ridimensionabile.
            /// </summary>
            HTBOTTOM = 15,
            /// <summary>
            /// Angolo inferiore sinistro del bordo di una finestra ridimensionabile.
            /// </summary>
            HTBOTTOMLEFT,
            /// <summary>
            /// Angolo inferiore destro del bordo di una finestra ridimensionabile.
            /// </summary>
            HTBOTTOMRIGHT,
            /// <summary>
            /// Barra del titolo.
            /// </summary>
            HTCAPTION = 2,
            /// <summary>
            /// Area client.
            /// </summary>
            HTCLIENT = 1,
            /// <summary>
            /// Pulsane Chiudi.
            /// </summary>
            HTCLOSE = 20,
            /// <summary>
            /// Sfondo dello schermo oppure linea di divisione tra finestre.
            /// </summary>
            HTERROR = -2,
            /// <summary>
            /// Size box.
            /// </summary>
            HTGROWBOX = 4,
            /// <summary>
            /// Pulsante Aiuto.
            /// </summary>
            HTHELP = 21,
            /// <summary>
            /// Barra di scorrimento orizzontale.
            /// </summary>
            HTHSCROLL = 6,
            /// <summary>
            /// Bordo sinistro di una finestra ridimensionabile.
            /// </summary>
            HTLEFT = 10,
            /// <summary>
            /// Menù.
            /// </summary>
            HTMENU = 5,
            /// <summary>
            /// Pulsante Ingrandisci.
            /// </summary>
            HTMAXBUTTON = 9,
            /// <summary>
            /// Pulsante Riduci a icona.
            /// </summary>
            HTMINBUTTON = 8,
            /// <summary>
            /// Sfondo dello schermo oppure sulla linea di divisione tra finestre.
            /// </summary>
            HTNOWHERE = 0,
            /// <summary>
            /// Pulsante Riduci a icona.
            /// </summary>
            HTREDUCE = HTMINBUTTON,
            /// <summary>
            /// Bordo destro di una finestra ridimensionabile.
            /// </summary>
            HTRIGHT = 11,
            /// <summary>
            /// Size box.
            /// </summary>
            HTSIZE = HTGROWBOX,
            /// <summary>
            /// Menù della finestra o nel pulsante Chiudi di una finestra figlia.
            /// </summary>
            HTSYSMENU = 3,
            /// <summary>
            /// Bordo orizzonatale superiore della finestra.
            /// </summary>
            HTTOP = 12,
            /// <summary>
            /// Angolo superiore sinistro del bordo della finestra.
            /// </summary>
            HTTOPLEFT,
            /// <summary>
            /// Angolo superiore destro del bordo della finestra.
            /// </summary>
            HTTOPRIGHT,
            /// <summary>
            /// Finestra coperta da un'altra finestra nello stesso thread.
            /// </summary>
            HTTRANSPARENT = -1,
            /// <summary>
            /// Barra di scorrimento verticale.
            /// </summary>
            HTVSCROLL = 7,
            /// <summary>
            /// Pulsante Ingrandisci.
            /// </summary>
            HTZOOM = HTMAXBUTTON
        }

        /// <summary>
        /// Valori del parametro wParam per il messaggio <see cref="WindowMessages.WM_NCXBUTTONDBLCLK"/>.
        /// </summary>
        internal enum XButtonDoubleClickWParamValues
        {
            /// <summary>
            /// Doppio click sul primo pulsante X.
            /// </summary>
            XBUTTON1 = 0x0001,
            /// <summary>
            /// Doppio click sul secondo pulsante X.
            /// </summary>
            XBUTTON2 = 0x0002
        }

        /// <summary>
        /// Stili di una finestra.
        /// </summary>
        [Flags]
        internal enum WindowStyle : DWORD
        {
            /// <summary>
            /// La finestra ha un bordo fine.
            /// </summary>
            WS_BORDER = 0x00800000,
            /// <summary>
            /// La finestra include una barra del titolo.
            /// </summary>
            WS_CAPTION = 0x00C00000,
            /// <summary>
            /// La finestra è una finestra figlia.
            /// </summary>
            WS_CHILD = 0x40000000,
            /// <summary>
            /// La finestra è una finestra figlia.
            /// </summary>
            WS_CHILDWINDOW = WS_CHILD,
            /// <summary>
            /// Esclude l'area occupata dalle finestre figlie quando l'operazione di disegno avviene all'interno della finestra padre.
            /// </summary>
            WS_CLIPCHILDREN = 0x02000000,
            /// <summary>
            /// Taglia le finestre figlie tra di loro.
            /// </summary>
            /// <remarks>Questo valore fa in modo che non sia possibile disegnare sulle aree client di finestre sovrapposte a quella attualmente in disegno.</remarks>
            WS_CLIPSIBLINGS = 0x04000000,
            /// <summary>
            /// La finestra è inizialmente disattivata.
            /// </summary>
            WS_DISABLED = 0x08000000,
            /// <summary>
            /// La finestra ha un bordo tipico delle finestre di dialogo.
            /// </summary>
            /// <remarks>Le finestre con questo stile non possono avere barre del titolo.</remarks>
            WS_DLGFRAME = 0x00400000,
            /// <summary>
            /// La finestra è il primo controllo in un gruppo di controlli.
            /// </summary>
            WS_GROUP = 0x00020000,
            /// <summary>
            /// La finestra ha una barra di scorrimento orizzontale.
            /// </summary>
            WS_HSCROLL = 0x00100000,
            /// <summary>
            /// La finestra è inizialmente minimizzata.
            /// </summary>
            WS_ICONIC = 0x20000000,
            /// <summary>
            /// La finestra è inizialmente massimizzata.
            /// </summary>
            WS_MAXIMIZE = 0x01000000,
            /// <summary>
            /// La finestra ha un pulsante di ingrandimento.
            /// </summary>
            /// <remarks>Questo valore non pul essere combinato con <see cref="WindowExtendedStyle.WS_EX_CONTEXT_HELP"/>, lo stile <see cref="WS_SYSMENU"/> deve essere specificato.</remarks>
            WS_MAXIMIZEBOX = 0x00010000,
            /// <summary>
            /// La finestra è inizialmente minimizata.
            /// </summary>
            WS_MINIMIZE = WS_ICONIC,
            /// <summary>
            /// La finestra ha un pulsante di riduzione a icona.
            /// </summary>
            WS_MINIMIZEBOX = 0x00020000,
            /// <summary>
            /// La finestra è una finestra sovrapposta.
            /// </summary>
            WS_OVERLAPPED = 0x00000000,
            /// <summary>
            /// La finestra è una finestra sovrapposta.
            /// </summary>
            WS_OVERLAPPEDWINDOW = 
                WS_OVERLAPPED |
                WS_CAPTION |
                WS_SYSMENU |
                WS_THICKFRAME |
                WS_MINIMIZEBOX |
                WS_MAXIMIZEBOX,
            /// <summary>
            /// La finestra è una finestra pop-up.
            /// </summary>
            /// <remarks>Questo stile non può essere usato insieme a <see cref="WS_CHILD"/>.</remarks>
            WS_POPUP = 0x80000000,
            /// <summary>
            /// La finestra è una finestra pop-up.
            /// </summary>
            /// <remarks>Deve essere combinato con <see cref="WS_CAPTION"/> per rendere la finestra visibile.</remarks>
            WS_POPUPWINDOW = 
                WS_POPUP |
                WS_BORDER |
                WS_SYSMENU,
            /// <summary>
            /// La finestra ha un bordo usato per il ridimensionamento.
            /// </summary>
            WS_SIZEBOX = 0x00040000,
            /// <summary>
            /// La finestra ha un menù sulla barra del titolo.
            /// </summary>
            /// <remarks>Deve essere combinato con <see cref="WS_CAPTION"/>.</remarks>
            WS_SYSMENU = 0x00080000,
            /// <summary>
            /// La finestra è un controllo che può ricevere il focus della tastiera quando l'utente preme il tasto TAB.
            /// </summary>
            WS_TABSTOP = 0x00010000,
            /// <summary>
            /// La finestra ha un bordo usato per il ridimensionamento.
            /// </summary>
            WS_THICKFRAME = WS_SIZEBOX,
            /// <summary>
            /// La finestra è una finestra sovrapposta.
            /// </summary>
            WS_TILED = WS_OVERLAPPED,
            /// <summary>
            /// La finestra è una finestra sovrapposta.
            /// </summary>
            WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
            /// <summary>
            /// La finestra è inizialmente visibile.
            /// </summary>
            WS_VISIBLE = 0x10000000,
            /// <summary>
            /// La finestra ha una barra di scorrimento verticale.
            /// </summary>
            WS_VSCROLL = 0x00200000,
        }

        /// <summary>
        /// Stili estesi delle finestre.
        /// </summary>
        [Flags]
        internal enum WindowExtendedStyle : DWORD
        {
            /// <summary>
            /// La finestra accetta il rilascia di file su di essa.
            /// </summary>
            WS_EX_ACCEPTFILES = 0x00000010,
            /// <summary>
            /// Forza una finestra top-level sulla barra delle applicazioni quando la finestra è visibile.
            /// </summary>
            WS_EX_APPWINDOW = 0x00040000,
            /// <summary>
            /// La finestra ha un bordo infossato.
            /// </summary>
            WS_EX_CLIENTEDGE = 0x00000200,
            /// <summary>
            /// Disegna tutte le finestre figlie di una finestra dal basso verso l'alto usando il buffering boppio.
            /// </summary>
            WS_EX_COMPOSITED = 0x02000000,
            /// <summary>
            /// La barra del titolo di una finestra include un punto di domanda.
            /// </summary>
            WS_EX_CONTEXT_HELP = 0x00000400,
            /// <summary>
            /// La finestra stessa contiene finestre figlie che dovrebbe prendere parte alla navigazione del box di dialogo.
            /// </summary>
            WS_EX_CONTROLPARENT = 0x00010000,
            /// <summary>
            /// La finestra ha un bordo doppio.
            /// </summary>
            WS_EX_DLGMODALFRAME = 0x00000001,
            /// <summary>
            /// La finestra è una finestra a strati.
            /// </summary>
            WS_EX_LAYERED = 0x00080000,
            /// <summary>
            /// Se il linguaggio della shell supporta l'allineamento dell'ordine di lettura, l'origine orizzonatale della finestra si trova sul bordo destro.
            /// </summary>
            WS_EX_LAYOUTRTL = 0x00400000,
            /// <summary>
            /// La finestra ha proprietà generiche con allineamento a sinistra.
            /// </summary>
            WS_EX_LEFT = 0x00000000,
            /// <summary>
            /// Se il linguaggio della shell supporta l'allineamento dell'ordine di lettura, la barra di scorrimento verticale (se presente) si trova a sinistra dell'area client.
            /// </summary>
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            /// <summary>
            /// Il testo della finestra viene visualizzato usando l'ordine di lettura da sinistra a destra.
            /// </summary>
            WS_EX_LTRREADING = WS_EX_LEFT,
            /// <summary>
            /// La finestra è una finestra figlia MDI.
            /// </summary>
            WS_EX_MDICHILD = 0x00000040,
            /// <summary>
            /// Questa finestra non può essere attivata se non tramite la funzione <see cref="SetActiveWindow"/> oppure <see cref="SetForegroundWindow"/>, la finestra inoltre non appare sulla barra delle applicazioni.
            /// </summary>
            WS_EX_NOACTIVATE = 0x08000000,
            /// <summary>
            /// La finestra non passa il suo layout alla sue finestre figlie.
            /// </summary>
            WS_EX_NOINHERITLAYOUT = 0x00100000,
            /// <summary>
            /// La finestra non notifica la propria finestra padre quando viene creata o distrutta.
            /// </summary>
            WS_EX_NOPARENTNOFITY = 0x00000004,
            /// <summary>
            /// La finestra non viene renderizzata su una superficie di ridirezione.
            /// </summary>
            WS_EX_NOREDIRECTIONBITMAP = 0x00200000,
            /// <summary>
            /// La finestra è una finestra sovrapposta.
            /// </summary>
            WS_EX_OVERLAPPEDWINDOW =
                WS_EX_WINDOWEDGE |
                WS_EX_CLIENTEDGE,
            /// <summary>
            /// La finestra è una finestra di comando.
            /// </summary>
            WS_EX_PALETTEWINDOW =
                WS_EX_WINDOWEDGE |
                WS_EX_TOOLWINDOW |
                WS_EX_TOPMOST,
            /// <summary>
            /// La finestra ha proprietà generiche con allineamento a destra.
            /// </summary>
            /// <remarks>Questo valore ha effetto solo se la lingua della shell supporta l'allineamento dell'ordine di lettura.</remarks>
            WS_EX_RIGHT = 0x00001000,
            /// <summary>
            /// Se il linguaggio della shell supporta l'allineamento dell'ordine di lettura, la barra di scorrimento verticale (se presente) si trova a destra dell'area client.
            /// </summary>
            WS_EX_RIGHTSCROLLBAR = 0x00000000,
            /// <summary>
            /// Il testo della finestra viene visualizzato usando l'ordine di lettura da destra a sinistra.
            /// </summary>
            WS_EX_RTLREADING = 0x00002000,
            /// <summary>
            /// La finestra ha un bordo tridimensionale da essere usato per oggetti che non accettato l'input dell'utente.
            /// </summary>
            WS_EX_STATICEDGE = 0x00020000,
            /// <summary>
            /// La finestra deve essere usata come toolbar fluttuante.
            /// </summary>
            WS_EX_TOOLWINDOW = 0x00000080,
            /// <summary>
            /// La finestra dovrebbe essere posizionata sopra tutte le finestre non-topmost e dovrebbe stare al di sopra di esse, anche quando la finestra è disattivata.
            /// </summary>
            WS_EX_TOPMOST = 0x00000008,
            /// <summary>
            /// La finestra non dovrebbe essere disegnata fino a quando le finestre figlie sotto di essa (creato dallo stesso thread) sono state disegnato.
            /// </summary>
            WS_EX_TRANSPARENT = 0x00000020,
            /// <summary>
            /// La finestra ha un bordo rialzato.
            /// </summary>
            WS_EX_WINDOWEDGE = 0x00000100
        }

        /// <summary>
        /// Valore di lParam per messaggi <see cref="WindowMessages.WM_NOTIFYFORMAT"/>.
        /// </summary>
        internal enum NotifyFormatMessageCommand
        {
            /// <summary>
            /// Query per determinare il tipo di strutture da usare in messaggi <see cref="WindowMessages.WM_NOTIFY"/>.
            /// </summary>
            /// <remarks>Inviato da un controllo alla sua finestra padre durante la creazione o in risposta a un comando <see cref="NF_REQUERY"/>.</remarks>
            NF_QUERY = 3,
            /// <summary>
            /// Richiesta per un controllo di inviare una forma <see cref="NF_QUERY"/> de messaggio <see cref="WindowMessages.WM_NOTIFYFORMAT"/> alla sua finestra padre.
            /// </summary>
            /// <remarks>Questo comando è inviato dalla finestra padre.<br/><br/>
            /// La finestra padre sta richiedendo al controllo il tipo di strutture da usare nei messaggi <see cref="WindowMessages.WM_NOTIFY"/>.<br/>
            /// Se lParam è <see cref="NF_REQUERY"/>, il valore restituito è il risultato di un'operazione di requery.</remarks>
            NF_REQUERY
        }

        /// <summary>
        /// Valori di ritorno per messaggi <see cref="WindowMessages.WM_NOTIFYFORMAT"/>.
        /// </summary>
        internal enum NotifyFormatReturnValue
        {
            /// <summary>
            /// Si è verificato un errore.
            /// </summary>
            Error,
            /// <summary>
            /// Indica che dovrebbero essere usate le versioni ANSI delle strutture per i messaggi <see cref="WindowMessages.WM_NOTIFY"/> inviato da un controllo.
            /// </summary>
            NFR_ANSI = 1,
            /// <summary>
            /// Indica che dovrebbero essere usate le versioni Unicode delle strutture per i messaggi <see cref="WindowMessages.WM_NOTIFY"/> inviato da un controllo.
            /// </summary>
            NFR_UNICODE
        }

        /// <summary>
        /// Valori speciali del parametro Index della funzione <see cref="WindowsFunctions.GetWindowLongPtr"/>.
        /// </summary>
        internal enum WindowDataSpecialOffset
        {
            /// <summary>
            /// Stili estesi della finestra.
            /// </summary>
            GWL_EXSTYLE = -20,
            /// <summary>
            /// Handle all'istanza dell'applicazione.
            /// </summary>
            GWL_HINSTANCE = -6,
            /// <summary>
            /// Handle alla finestra padre.
            /// </summary>
            GWL_HWNDPARENT = -8,
            /// <summary>
            /// ID della finestra.
            /// </summary>
            GWL_ID = -12,
            /// <summary>
            /// Stili della finestra.
            /// </summary>
            GWL_STYLE = -16,
            /// <summary>
            /// Dati utente.
            /// </summary>
            GWL_USERDATA = -21,
            /// <summary>
            /// Puntatore alla procedura della finestra.
            /// </summary>
            /// <remarks>La funzione <see cref="WindowsFunctions.CallWindowProc"/> deve essere usata per chiamare la procedura.</remarks>
            GWL_WNDPROC = -4,
            /// <summary>
            /// Il valore restituto dall'elaborazione di un messaggio da parte della procedura di una finestra di dialogo.
            /// </summary>
            DWLP_MGSRESULT = 0
        }

        /// <summary>
        /// Risultato del confronto di due oggetti durante l'elaborazione di un messaggio <see cref="WindowMessages.WM_COMPAREITEM"/>.
        /// </summary>
        internal enum CompareItemResult
        {
            /// <summary>
            /// Oggetto 1 precede l'oggetto 2 nell'ordine.
            /// </summary>
            ItemPrecedes = -1,
            /// <summary>
            /// Gli oggetti sono equivalenti.
            /// </summary>
            ItemEquivalent,
            /// <summary>
            /// Oggetto 1 segue l'oggetto 2 nell'ordine.
            /// </summary>
            ItemFollows
        }
    }
}