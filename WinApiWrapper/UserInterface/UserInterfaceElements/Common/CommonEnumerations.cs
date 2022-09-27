namespace WinApiWrapper.UserInterface.UserInterfaceElements.Common
{
    /// <summary>
    /// Enumerazioni comuni per i controlli.
    /// </summary>
    internal static class CommonEnumerations
    {
        /// <summary>
        /// Azione del mouse.
        /// </summary>
        internal enum MouseAction
        {
            /// <summary>
            /// In entrata sul controllo.
            /// </summary>
            HICF_ENTERING = 16,
            /// <summary>
            /// In uscita dal controllo.
            /// </summary>
            HICF_LEAVING = 32
        }

        /// <summary>
        /// Valori di ritorno per la notifica <see cref="CommonNotifications.NM_CUSTOMDRAW"/>.
        /// </summary>
        [Flags]
        internal enum CustomDrawReturnFlags
        {
            /// <summary>
            /// Il controllo si disegna da solo.
            /// </summary>
            /// <remarks>Non verranno inviate notifiche di tipo <see cref="CommonNotifications.NM_CUSTOMDRAW"/> per questo ciclo di disegno.<br/><br/>
            /// <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREPAINT"/>.</remarks>
            CDRF_DODEFAULT,
            /// <summary>
            /// L'applicazione specifica un nuovo font per l'oggetto.
            /// </summary>
            /// <remarks>Il controllo userà il nuovo font.<br/><br/>
            /// <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            CDRF_NEWFONT = 2,
            /// <summary>
            /// L'applicazione ha disegnato l'oggetto manualmente, il controllo non disegnera l'oggetto.
            /// </summary>
            /// <remarks>Può essere usato solo se il campo <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREERASE"/> oppure <see cref="DrawstageFlags.CDDS_PREPAINT"/>.</remarks>
            CDRF_SKIPDEFAULT = 4,
            /// <summary>
            /// Il controllo disegnerà lo sfondo.
            /// </summary>
            CDRF_DOERASE = 8,
            /// <summary>
            /// Il controllo non disegnerà il rettangolo di focus.
            /// </summary>
            CDRF_SKIPPOSTPAINT = 256,
            /// <summary>
            /// Il controllo notifica il padre dopo il disegno di un oggetto.
            /// </summary>
            /// <remarks>Può essere usato solo se il campo <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREPAINT"/>.</remarks>
            CDRF_NOTIFYPOSTPAINT = 16,
            /// <summary>
            /// Il controllo notifica il padre di ogni operazione relative al disegno di oggetti.
            /// </summary>
            /// <remarks>Verranno inviate notifiche di tipo <see cref="CommonNotifications.NM_CUSTOMDRAW"/> prima e dopo aver disegnato gli oggetti.<br/><br/>
            /// <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREPAINT"/>.</remarks>
            CDRF_NOTIFYITEMDRAW = 32,
            /// <summary>
            /// Il controllo notifica il padre di ogni operazione relative al disegno di oggetti.
            /// </summary>
            /// <remarks>Verranno inviate notifiche di tipo <see cref="CommonNotifications.NM_CUSTOMDRAW"/> prima e dopo aver disegnato gli oggetti.<br/><br/>
            /// Se questo valore viene restituito in risposta a una notifica inviata da una list view, l'applicazione riceverà un altra notifica con il campo <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> impostato a <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/> | <see cref="DrawstageFlags.CDDS_SUBITEM"/> prima del disegno di ogni subitem della list view.<br/>
            /// Si può specificare font e colore per ogni subitem seperatamente o restituire <see cref="CDRF_DODEFAULT"/> per eseguire l'elaborazione predefinita.<br/><br/>
            /// <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREPAINT"/>.</remarks>
            CDRF_NOTIFYSUBITEMDRAW = CDRF_NOTIFYITEMDRAW,
            /// <summary>
            /// Il controllo notifica il padre dopo l'eliminazione dell'oggetto.
            /// </summary>
            /// <remarks>Può essere usato solo se il campo <see cref="CommonStructures.NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREERASE"/>.</remarks>
            CDRF_NOTIFYPOSTERASE = 64
        }

        /// <summary>
        /// Passaggio della procedura di disegno.
        /// </summary>
        internal enum DrawstageFlags
        {
            /// <summary>
            /// Prima che il ciclo di disegno inizia.
            /// </summary>
            CDDS_PREPAINT = 1,
            /// <summary>
            /// Dopo che il ciclo di disegno è completo.
            /// </summary>
            CDDS_POSTPAINT,
            /// <summary>
            /// Prima che il ciclo di eliminazione inizia.
            /// </summary>
            CDDS_PREERASE,
            /// <summary>
            /// Dopo che il ciclo di eliminazione è completo.
            /// </summary>
            CDDS_POSTERASE,
            /// <summary>
            /// Indica che i campi <see cref="CommonStructures.NMCUSTOMDRAW.ItemSpec"/> e <see cref="CommonStructures.NMCUSTOMDRAW.ItemData"/> sono validi.
            /// </summary>
            CDDS_ITEM = 65536,
            /// <summary>
            /// Prima che un oggetto sia disegnato.
            /// </summary>
            CDDS_ITEMPREPAINT = CDDS_ITEM | CDDS_PREPAINT,
            /// <summary>
            /// Dopo che un oggetto è stato disegnato.
            /// </summary>
            CDDS_ITEMPOSTPAINT = CDDS_ITEM | CDDS_POSTPAINT,
            /// <summary>
            /// Prima che un oggetto sia eliminato.
            /// </summary>
            CDDS_ITEMPREERASE = CDDS_ITEM | CDDS_PREERASE,
            /// <summary>
            /// Dopo che un oggetto è stato eliminato.
            /// </summary>
            CDDS_ITEMPOSTERASE = CDDS_ITEM | CDDS_POSTERASE,
            /// <summary>
            /// Opzione combinata con <see cref="CDDS_ITEMPREPAINT"/> oppure <see cref="CDDS_ITEMPOSTPAINT"/> se un subitem è in corso di disegno.
            /// </summary>
            /// <remarks>Viene impostato solamente se viene restituto <see cref="CustomDrawReturnFlags.CDRF_NOTIFYITEMDRAW"/> da <see cref="CDDS_PREPAINT"/>.</remarks>
            CDDS_SUBITEM = 131072
        }

        /// <summary>
        /// Formato del testo di un controllo.
        /// </summary>
        [Flags]
        internal enum TextFormat
        {
            /// <summary>
            /// Renderizza il testo nella parte superiore del rettangolo di visualizzazione.
            /// </summary>
            DT_TOP,
            /// <summary>
            /// Allinea il testo a sinistra.
            /// </summary>
            DT_LEFT = DT_TOP,
            /// <summary>
            /// Centra il testo orizzontalmente nel rettangolo di visualizzazione.
            /// </summary>
            DT_CENTER,
            /// <summary>
            /// Allinea il testo a destra.
            /// </summary>
            DT_RIGHT,
            /// <summary>
            /// Centra il testo verticalmente.
            /// </summary>
            /// <remarks>Utilizzato solamente con <see cref="DT_SINGLELINE"/>.</remarks>
            DT_VCENTER = 4,
            /// <summary>
            /// Renderizza il testo nella parte inferiore del rettangolo di visualizzazione.
            /// </summary>
            /// <remarks>Questo valore è utilizzato solo con <see cref="DT_SINGLELINE"/>.</remarks>
            DT_BOTTOM = 8,
            /// <summary>
            /// Interrompe le linee tra le parole se la parola si estende oltre il bordo del rettangolo di visualizzazione.
            /// </summary>
            DT_WORDBREAK = 16,
            /// <summary>
            /// Mostra il testo su una singola linea.
            /// </summary>
            DT_SINGLELINE = 32,
            /// <summary>
            /// Espande i caratteri di tabulazione.
            /// </summary>
            /// <remarks><see cref="DT_WORD_ELLIPSIS"/>, <see cref="DT_PATH_ELLIPSIS"/> e <see cref="DT_END_ELLIPSIS"/> non possono essere usati con questo formato.</remarks>
            DT_EXPANDTABS = 64,
            /// <summary>
            /// Imposta un tab stop.
            /// </summary>
            DT_TABSTOP = 128,
            /// <summary>
            /// Disegna il testo senza clippare il rettagolo di visualizzazione.
            /// </summary>
            DT_NOCLIP = 256,
            /// <summary>
            /// Include il leading esterno di un font nell'altezza della linea.
            /// </summary>
            DT_EXTERNALLEADING = 512,
            /// <summary>
            /// Determina l'altezza e la larghezza del rettangolo di visualizzazione.
            /// </summary>
            DT_CALCRECT = 1024,
            /// <summary>
            /// Disattiva l'elaborazione dei caratteri di prefisso.
            /// </summary>
            DT_NOPREFIX = 2048,
            /// <summary>
            /// 
            /// </summary>
            DT_INTERNAL = 4096,
            /// <summary>
            /// Duplica le caratteristiche di visualizzazione del testo di un controllo multilinea di modifica.
            /// </summary>
            DT_EDITCONTROL = 8192,
            /// <summary>
            /// Sostituisce i caratteri in mezzo al testo con i puntino di sospensione così che il testo non esca dal rettangolo di visualizzazione
            /// </summary>
            /// <remarks>Se la stringa contiene caratteri backslash, viene preservato il più possibile del testo dopo l'ultimo backslash.<br/><br/>
            /// La stringa non viene modificata a meno che <see cref="DT_MODIFYSTRING"/> non è specificato.</remarks>
            DT_PATH_ELLIPSIS = 16384,
            /// <summary>
            /// Tronca il testo più largo del rettangolo di visualizzazione e aggiunge i puntini di sospensione per indicare il troncamento.
            /// </summary>
            /// <remarks>Il testo non viene modificato a meno che <see cref="DT_MODIFYSTRING"/> non sia specificato.</remarks>
            DT_END_ELLIPSIS = 32768,
            /// <summary>
            /// Modifica la stringa perché corrisponda al testo visualizzato.
            /// </summary>
            /// <remarks>Non ha nessun effetto se non è specificato <see cref="DT_END_ELLIPSIS"/> oppure <see cref="DT_PATH_ELLIPSIS"/>.</remarks>
            DT_MODIFYSTRING = 65536,
            /// <summary>
            /// Il testo è posizionato in ordine da destra a sinistra per testo bidirezionale.
            /// </summary>
            DT_RTLLEADING = 131072,
            /// <summary>
            /// Tronca ogni parola troppo lunga per il rettangolo di visualizzazione e aggiunge i puntini di sospensione.
            /// </summary>
            DT_WORD_ELLIPSIS = 262144,
            /// <summary>
            /// Impedisce la fine della linea ai set di caratteri a due byte, così che la regola sia la stessa per i set di caratteri a singolo byte.
            /// </summary>
            /// <remarks>Non ha nessun effetto se <see cref="DT_WORDBREAK"/> non è specificato.</remarks>
            DT_NOFULLWIDTHCHARBREAK = 524288,
            /// <summary>
            /// Ignora il carattere prefisso "e commerciale" nel testo.
            /// </summary>
            DT_HIDEPREFIX = 1048576,
            /// <summary>
            /// Disegna solo una sottolineatura alla posizione del carattere che segue il prefisso "e commerciale".
            /// </summary>
            DT_PREFIXONLY = 2097152
        }

        /// <summary>
        /// Classi dei controlli comuni.
        /// </summary>
        [Flags]
        internal enum CommonClasses
        {
            /// <summary>
            /// Animate.
            /// </summary>
            ICC_ANIMATE_CLASS = 128,
            /// <summary>
            /// Toolbar, barra di stato, trackbar, tooltip.
            /// </summary>
            ICC_BAR_CLASSES = 4,
            /// <summary>
            /// Rebar.
            /// </summary>
            ICC_COOL_CLASSES = 1024,
            /// <summary>
            /// Selettore data o ora.
            /// </summary>
            ICC_DATE_CLASSES = 256,
            /// <summary>
            /// Hotkey.
            /// </summary>
            ICC_HOTKEY_CLASS = 64,
            /// <summary>
            /// Indirizzo IP.
            /// </summary>
            ICC_INTERNET_CLASSES = 2048,
            /// <summary>
            /// Collegamento ipertestuale.
            /// </summary>
            ICC_LINK_CLASS = 32768,
            /// <summary>
            /// List view e header.
            /// </summary>
            ICC_LISTVIEW_CLASS = 1,
            /// <summary>
            /// Font nativo.
            /// </summary>
            ICC_NATIVEFNTCTL_CLASS = 8192,
            /// <summary>
            /// Pager.
            /// </summary>
            ICC_PAGESCROLLER_CLASS = 4096,
            /// <summary>
            /// Barra di progresso.
            /// </summary>
            ICC_PROGRESS_CLASS = 32,
            /// <summary>
            /// Una delle classi intrinsiche User32.
            /// </summary>
            /// <remarks>I controlli utente includono:<br/><br/>
            /// pulsanti<br/>
            /// edit<br/>
            /// static<br/>
            /// listbox<br/>
            /// combobox<br/>
            /// barra di scorrimento</remarks>
            ICC_STANDARD_CLASSES = 16384,
            /// <summary>
            /// Tab e tooltip.
            /// </summary>
            ICC_TAB_CLASSES = 8,
            /// <summary>
            /// Treeview e tooltip.
            /// </summary>
            ICC_TREEVIEW_CLASSES = 2,
            /// <summary>
            /// Up-down.
            /// </summary>
            ICC_UPDOWN_CLASS = 16,
            /// <summary>
            /// ComboBoxEx.
            /// </summary>
            ICC_USEREX_CLASSES = 512,
            /// <summary>
            /// Animate, header, hotkey, listview, barra di progresso, barra di stato, tab, tooltip, toolbar, trackbar, treeview, up-down.
            /// </summary>
            ICC_WIN95_CLASSES = 255
        }

        /// <summary>
        /// Metrica da applicare al caricamento di un'icona.
        /// </summary>
        internal enum IconMetric
        {
            /// <summary>
            /// Larghezza raccomandata dell'icona piccola.
            /// </summary>
            LIM_SMALL,
            /// <summary>
            /// Larghezza predefinita di un'icona.
            /// </summary>
            LIM_LARGE
        }

        /// <summary>
        /// Stili comuni.
        /// </summary>
        [Flags]
        internal enum CommonStyles
        {
            /// <summary>
            /// Il controllo si posiziona nella parte superiore dell'area client dell finestra padre e imposta la propria larghezza allo stesso valore di quella della finestra.
            /// </summary>
            /// <remarks>Le toolbar hanno questo stile applicato per impostazione predefinita.</remarks>
            CCS_TOP = 1,
            /// <summary>
            /// Il controllo viene ridimensionato e si muove orizzontalmente ma non verticalmente, in risposta a un messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_SIZE"/>.
            /// </summary>
            /// <remarks>Se lo stile <see cref="CCS_NORESIZE"/> è applicato, questo non si applica.</remarks>
            CCS_NOMOVEY,
            /// <summary>
            /// Il controllo si posiziona nella parte inferiore dell'area client della finestra e imposta la larghezza uguale a quella della finestra.
            /// </summary>
            /// <remarks>Le finestre di stato hanno questo stile applicato in modo predefinito.</remarks>
            CCS_BOTTOM,
            /// <summary>
            /// Impedisce al controllo di usare l'altezza e la larghezza predefinite durante l'impostazione della dimensione iniziale o di una nuova dimensione.
            /// </summary>
            /// <remarks>Vengono usate l'altezza e la larghezza specificate nella richiesta di creazione o di ridimensionamento.</remarks>
            CCS_NORESIZE,
            /// <summary>
            /// Impedisce al controllo di muoversi automaticamente verso la parte superiore o inferiore della finestra padre.
            /// </summary>
            /// <remarks>il controllo mantiene la posizione nella finestra padre nonostante cambiamenti della sua dimensione.<br/>
            /// Se <see cref="CCS_TOP"/> oppure <see cref="CCS_BOTTOM"/> sono specificati, l'altezza diventa quella predefinita ma la posizione non cambia.</remarks>
            CCS_NOPARENTALIGN = 8,
            /// <summary>
            /// Abilita la funzionalità di personalizzazione di una toolbar.
            /// </summary>
            CCS_ADJUSTABLE = 32,
            /// <summary>
            /// Impedisce il disegno di area di evidenziazione di due pixel nella parte superiore del controllo.
            /// </summary>
            CCS_NODIVIDER = 64,
            /// <summary>
            /// Il controllo viene mostrato verticalmente.
            /// </summary>
            CCS_VERT = 128,
            /// <summary>
            /// Il controllo viene mostrato verticalmente nella parte sinistra della finestra padre.
            /// </summary>
            CCS_LEFT = CCS_VERT | CCS_TOP,
            /// <summary>
            /// Il controllo viene mostrato vericalmente nella parte destra della finestra padre.
            /// </summary>
            CCS_RIGHT = CCS_VERT | CCS_BOTTOM,
            /// <summary>
            /// Il controllo viene ridimensionato e si muove verticalmente ma non orizzontalmente, in risposta a un messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_SIZE"/>.
            /// </summary>
            /// <remarks>Se lo stile <see cref="CCS_NORESIZE"/> è applicato, questo non si applica.</remarks>
            CCS_NOMOVEX = CCS_VERT | CCS_NOMOVEY
        }

        /// <summary>
        /// Stato oggetto.
        /// </summary>
        internal enum ItemState
        {
            /// <summary>
            /// L'oggetto è selezionato.
            /// </summary>
            CDIS_SELECTED = 1,
            /// <summary>
            /// L'oggetto non è interagibile.
            /// </summary>
            CDIS_GRAYED,
            /// <summary>
            /// L'oggetto è disabilitato.
            /// </summary>
            CDIS_DISABLED = 4,
            /// <summary>
            /// L'oggetto è selezionato.
            /// </summary>
            CDIS_CHECKED = 8,
            /// <summary>
            /// L'oggetto è in fpcus.
            /// </summary>
            CDIS_FOCUS = 16,
            /// <summary>
            /// L'oggetto è nello stato predefinito.
            /// </summary>
            CDIS_DEFAULT = 32,
            /// <summary>
            /// Il puntatore si trova sull'oggetto.
            /// </summary>
            CDIS_HOT = 64,
            /// <summary>
            /// L'oggetto è evidenziato.
            /// </summary>
            CDIS_MARKED = 128,
            /// <summary>
            /// L'oggetto è in stato indeterminato.
            /// </summary>
            /// <remarks>Il significato di questo valore dipende dall'implementazione.</remarks>
            CDIS_INDETERMINATE = 256,
            /// <summary>
            /// L'oggetto stato mostrando le combinazioni di tasti associate.
            /// </summary>
            CDIS_SHOWKEYBOARDCUES = 512,
            /// <summary>
            /// L'oggetto è parte di un controllo sopra il quale si trova il puntatore del mouse.
            /// </summary>
            /// <remarks>Il significato di questo valore dipende dall'implementazione.</remarks>
            CDIS_NEARHOT = 1024,
            /// <summary>
            /// L'oggetto è parte di uno split button sopra il quale si trova il puntatore del mouse.
            /// </summary>
            /// <remarks>Il significato di questo valore dipende dall'implementazione.</remarks>
            CDIS_OTHERSIDEHOT = 2048,
            /// <summary>
            /// L'oggetto è il punto di rilascio di un'operazione di drag and drop.
            /// </summary>
            CDIS_DROPTHILITED = 4096
        }

        /// <summary>
        /// Tipo di oggetto da disegnare (list view).
        /// </summary>
        internal enum ListViewItemType
        {
            /// <summary>
            /// Un oggetto è in corso di disegno.
            /// </summary>
            LVCDI_ITEM,
            /// <summary>
            /// Un gruppo è in corso di disegno.
            /// </summary>
            LVCDI_GROUP,
            /// <summary>
            /// Tutti gli oggetti sono in corso di disegno.
            /// </summary>
            LVCDI_ITEMSLIST
        }

        /// <summary>
        /// Allineamento di un gruppo (list view).
        /// </summary>
        internal enum GroupAlignment
        {
            /// <summary>
            /// Allineamento a sinistra.
            /// </summary>
            LVGA_HEADER_LEFT = 1,
            /// <summary>
            /// Centra il gruppo.
            /// </summary>
            LVGA_HEADER_CENTER,
            /// <summary>
            /// Allineamento a destra.
            /// </summary>
            LVGA_HEADER_RIGHT = 4
        }
    }
}