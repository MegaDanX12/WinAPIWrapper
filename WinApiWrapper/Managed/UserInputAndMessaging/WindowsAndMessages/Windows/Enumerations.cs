namespace WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows
{
    /// <summary>
    /// Enumerazioni usate per gestire le finestre.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Stili della finestra.
        /// </summary>
        [Flags]
        public enum WindowStyles : uint
        {
            /// <summary>
            /// La finestra ha un bordo sottile.
            /// </summary>
            HasThinLineBorder = 0x00800000,
            /// <summary>
            /// La finestra ha una barra del titolo.
            /// </summary>
            HasTitleBar = 0x00C00000,
            /// <summary>
            /// La finestra è una finestra figlia.
            /// </summary>
            IsChildWindow = 0x40000000,
            /// <summary>
            /// Esclude l'area occupata dalle finestre figlie quando avviene l'operazione di disegno nella finestra padre.
            /// </summary>
            ClipsChildren = 0x02000000,
            /// <summary>
            /// Taglia fuori le altre finestre figlie sovrapposte dalla regione della finestra da aggiornare.
            /// </summary>
            ClipSiblings = 0x04000000,
            /// <summary>
            /// La finestra è inizialemente disattivata.
            /// </summary>
            StartsDisabled = 0x08000000,
            /// <summary>
            /// La finestra ha un bordo simile a quello usato dai box di dialogo.
            /// </summary>
            /// <remarks>Questo tipo di finestre non può avere una barra del titolo.</remarks>
            HasDialogBoxStyleBorder = 0x00400000,
            /// <summary>
            /// La finestra è la prima di un gruppo di controlli
            /// </summary>
            FirstOfGroup = 0x00020000,
            /// <summary>
            /// La finestra ha una barra di scorrimento orizzontale.
            /// </summary>
            HasHorizontalScrollBar = 0x00100000,
            /// <summary>
            /// La finestra è inizialmente minimizzata.
            /// </summary>
            StartsMinimized = 0x20000000,
            /// <summary>
            /// La finestra è inizialmente massimizzata.
            /// </summary>
            StartsMaximized = 0x01000000,
            /// <summary>
            /// La finestra ha il pulsante di ingrandimento.
            /// </summary>
            HasMaximizeButton = 0x00010000,
            /// <summary>
            /// La finestra ha il pulsante di riduzione a icona.
            /// </summary>
            HasMinimizeButton = 0x00020000,
            /// <summary>
            /// Finestra con una barra del titolo e un bordo.
            /// </summary>
            Overlapped = 0x00000000,
            /// <summary>
            /// Finestra con barra del titolo, menù di sistema, bordo di ridimensionamento, pulsante di riduzione a icona e di ingrandimento.
            /// </summary>
            Overlapped2 =
                Overlapped |
                HasTitleBar |
                HasWindowMenu |
                HasSizingBorder |
                HasMinimizeButton |
                HasMaximizeButton,
            /// <summary>
            /// Finestra popup.
            /// </summary>
            /// <remarks>Lo stile <see cref="IsChildWindow"/> non può essere usato con questo valore.</remarks>
            IsPopupWindow = 0x80000000,
            /// <summary>
            /// Finestra popup con bordo sottile e menù di sistema.
            /// </summary>
            /// <remarks>Per rendere il menù visibile, questo valore deve essere combinato con <see cref="HasTitleBar"/>.</remarks>
            IsPopupWindow2 =
                IsPopupWindow |
                HasThinLineBorder |
                HasWindowMenu,
            /// <summary>
            /// La finestra ha un bordo di ridimensionamento.
            /// </summary>
            HasSizingBorder = 0x00040000,
            /// <summary>
            /// La finestra ha un menù di sistema.
            /// </summary>
            HasWindowMenu = 0x00080000,
            /// <summary>
            /// La finestra può ricevere il focus della tastiera tramite il tasto TAB.
            /// </summary>
            TabKeyboardFocus = 0x00010000,
            /// <summary>
            /// La finestra è inizialmente visibile.
            /// </summary>
            StartsVisible = 0x10000000,
            /// <summary>
            /// La finestra ha una barra di scorrimento verticale.
            /// </summary>
            HasVerticalScrollBar = 0x00200000
        }

        /// <summary>
        /// Stili estese delle finestre.
        /// </summary>
        [Flags]
        public enum ExtendedWindowStyles : uint
        {
            /// <summary>
            /// Accetta i file se trascinati e rilasciati su di essa.
            /// </summary>
            AcceptFilesOnDragAndDrop = 0x00000010,
            /// <summary>
            /// Una finestra top-level è presente sulla barra delle applicazione se visibile.
            /// </summary>
            ForcesOnTaskbarWhenVisible = 0x00040000,
            /// <summary>
            /// Ha un bordo infossato.
            /// </summary>
            HasBorderWithSunkenEdge = 0x00000200,
            /// <summary>
            /// Tutti i discendenti della finestra vengono disegnati dal basso verso l'alto.
            /// </summary>
            DescendantsBottomToTopPaintingOrder = 0x02000000,
            /// <summary>
            /// La barra del titolo ha un pulsante con un punto di domanda.
            /// </summary>
            TitleBarIncludesQuestionMark = 0x00000400,
            /// <summary>
            /// La finestra contiene finestre figlie che dovrebbe far parte della naviagazione del box di dialogo.
            /// </summary>
            ContainsChildWindows = 0x00010000,
            /// <summary>
            /// La finestra ha un bordo doppio.
            /// </summary>
            /// <remarks>Può essere creata con una barra del titolo specificando <see cref="WindowStyles.HasTitleBar"/>.</remarks>
            HasDoubleBorder = 0x00000001,
            /// <summary>
            /// La finestra è a strati.
            /// </summary>
            IsLayeredWindow = 0x00080000,
            /// <summary>
            /// La finestra ha un layout da destra verso sinistra per linguaggi che supporta l'ordine di lettura.
            /// </summary>
            RightToLeftLayout = 0x00400000,
            /// <summary>
            /// Le proprietà della finestra sono allineate a sinistra.
            /// </summary>
            HasLeftAlignedProperties = 0x00000000,
            /// <summary>
            /// La barra di scorrimento verticale, se presente, si trova a sinistra.
            /// </summary>
            VerticalScrollBarIsOnLeftSide = 0x00004000,
            /// <summary>
            /// Il testo della finestra è visualizzato da sinistra verso destra.
            /// </summary>
            LeftToRightReadingOrder = 0x00000000,
            /// <summary>
            /// E' una finestra figlia MDI.
            /// </summary>
            IsMdiChildWindow = 0x00000040,
            /// <summary>
            /// Può attivare solo chiamando le funzioni appropriate.
            /// </summary>
            IsActivateManually = 0x08000000,
            /// <summary>
            /// Le finestre figlie non ereditano il layout dal padre.
            /// </summary>
            ChildWindowsDoNotInheritLayout = 0x00100000,
            /// <summary>
            /// Le finestre figlie non notificato il padre al momento della loro creazione o distruzione.
            /// </summary>
            ParentNotNotifiedOnCreationOrDestruction = 0x00000004,
            /// <summary>
            /// La finestra non viene renderizzata su una superficie di ridirezionamento.
            /// </summary>
            NotRenderendToRedirectionSurface = 0x00200000,
            /// <summary>
            /// Finestra principale.
            /// </summary>
            Overlapped =
                HasBorderWithRaisedEdge |
                HasBorderWithSunkenEdge,
            /// <summary>
            /// Finestra con insieme di comandi.
            /// </summary>
            IsPaletteWindow =
                HasBorderWithRaisedEdge |
                IsToolWindow |
                IsTopMostWindow,
            /// <summary>
            /// Le proprietà della finestra sono allineate a destra.
            /// </summary>
            HasRightAlignedProperties = 0x00001000,
            /// <summary>
            /// La barra di scorrimento verticale, se presente, si trova a destra.
            /// </summary>
            VerticalScrollBarIsOnRightSide = 0x00000000,
            /// <summary>
            /// Il testo della finestra è visualizzato da destra verso sinistra.
            /// </summary>
            RightToLeftReadingOrder = 0x00002000,
            /// <summary>
            /// Ha un bordo tridimensionale inteso per ospitare oggetti che non accettano input dall'utente.
            /// </summary>
            HasThreeDimensionalBorder = 0x00020000,
            /// <summary>
            /// Finestra intesa per essere usata con toolbar fluttuante.
            /// </summary>
            IsToolWindow = 0x00000080,
            /// <summary>
            /// La finestra di trova sempre sopra tutte le altre che non hanno la stessa proprietà attiva.
            /// </summary>
            IsTopMostWindow = 0x00000008,
            /// <summary>
            /// La finestra viene disegnata dopo i figli che si trovano al di sotto di essa.
            /// </summary>
            PaintedAfterSiblings = 0x00000020,
            /// <summary>
            /// Ha un bordo rialzato.
            /// </summary>
            HasBorderWithRaisedEdge = 0x00000100
        }
    }
}