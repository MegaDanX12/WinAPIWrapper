namespace WinApiWrapper.UserInterface.UserInterfaceElements
{
    /// <summary>
    /// Enumerazioni generali degli elementi dell'interfaccia utente.
    /// </summary>
    internal static class GeneralEnumerations
    {
        /// <summary>
        /// ID risorsa bitmap OEM.
        /// </summary>
        internal enum OEMBitmapResource
        {
            OBM_LFARROWI = 32734,

            OBM_RGARROWI,

            OBM_DNARROWI,

            OBM_UPARROWI,

            OBM_COMBO,

            OBM_MNARROW,

            OBM_LFARROWD,

            OBM_RGARROWD,

            OBM_DNARROWD,

            OBM_UPARROWD,

            OBM_RESTORED,

            OBM_ZOOMD,

            OBM_REDUCED,

            OBM_RESTORE,

            OBM_ZOOM,

            OBM_REDUCE,

            OBM_LFARROW,

            OBM_RGARROW,

            OBM_DNARROW,

            OBM_UPARROW,

            OBM_CLOSE,

            OBM_OLD_RESTORE,

            OBM_OLD_ZOOM,

            OBM_OLD_REDUCE,

            OBM_BTMCORNERS,

            OBM_CHECKBOXES,

            OBM_CHECK,

            OBM_BTSIZE,

            OBM_OLD_LFARROW,

            OBM_OLD_RGARROW,

            OBM_OLD_DNARROW,

            OBM_OLD_UPARROW,

            OBM_SIZE,

            OBM_OLD_CLOSE
        }

        /// <summary>
        /// ID risorse cursore OEM.
        /// </summary>
        internal enum OEMCursorResource
        {

            OCR_NORMAL = 32512,

            OCR_IBEAM,

            OCR_WAIT,

            OCR_CROSS,

            OCR_UP,

            OCR_SIZE = 32640,

            OCR_ICON,

            OCR_SIZENWSE,

            OCR_SIZENESW,

            OCR_SIZEWE,

            OCR_SIZENS,

            OCR_SIZEALL,

            OCR_ICOCUR,

            OCR_NO,

            OCR_HAND,

            OCR_APPSTARTING
        }

        /// <summary>
        /// ID risorse icona OEM.
        /// </summary>
        internal enum OEMIconResource
        {

            OIC_SAMPLE = 32512,

            OIC_HAND,

            OIC_QUES,

            OIC_BANG,

            OIC_NOTE,

            OIC_WINLOGO,

            OIC_WARNING = OIC_BANG,

            OIC_ERROR = OIC_HAND,

            OIC_INFORMATION = OIC_NOTE,

            OIC_SHIELD = 32518
        }

        /// <summary>
        /// ID risorse standard.
        /// </summary>
        internal enum StandardResourceID
        {
            /// <summary>
            /// Cursore freccia standard.
            /// </summary>
            IDC_ARROW = 32512,
            /// <summary>
            /// Cursore I-beam.
            /// </summary>
            IDC_IBEAM,
            /// <summary>
            /// Cursore clessidra.
            /// </summary>
            IDC_WAIT,
            /// <summary>
            /// Cursore mirino.
            /// </summary>
            IDC_CROSS,
            /// <summary>
            /// Cursore freccia verticale.
            /// </summary>
            IDC_UPARROW,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato nord-ovest e sud-est.
            /// </summary>
            IDC_SIZENWSE = 32642,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato nord-est e sud-ovest.
            /// </summary>
            IDC_SIZENESW,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato est e ovest.
            /// </summary>
            IDC_SIZEWE,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato nord e sud.
            /// </summary>
            IDC_SIZENS,
            /// <summary>
            /// 
            /// </summary>
            IDC_SIZEALL,
            /// <summary>
            /// Cursore circolare.
            /// </summary>
            IDC_NO = 32648,
            /// <summary>
            /// Cursore mano.
            /// </summary>
            IDC_HAND,
            /// <summary>
            /// Cursore freccia standard e piccola clessidra.
            /// </summary>
            IDC_APPSTARTING,
            /// <summary>
            /// 
            /// </summary>
            IDC_HELP,
            /// <summary>
            /// 
            /// </summary>
            IDC_PIN = 32671,
            /// <summary>
            /// 
            /// </summary>
            IDC_PERSON,
            /// <summary>
            /// Icona predefinita per le applicazioni.
            /// </summary>
            IDI_APPLICATION = IDC_ARROW,
            /// <summary>
            /// Icona a forma di mano.
            /// </summary>
            IDI_HAND = IDC_IBEAM,
            /// <summary>
            /// Icona a forma di punto di domanda.
            /// </summary>
            IDI_QUESTION = IDC_WAIT,
            /// <summary>
            /// Icona a forma di punto esclamativo.
            /// </summary>
            IDI_EXCLAMATION = IDC_CROSS,
            /// <summary>
            /// Icona a forma di asterisco.
            /// </summary>
            IDI_ASTERISK = IDC_UPARROW,
            /// <summary>
            /// Logo di Windows.
            /// </summary>
            IDI_WINLOGO = 32517,
            /// <summary>
            /// Scudo di sicurezza.
            /// </summary>
            IDI_SHIELD = 32518,
            /// <summary>
            /// Icona a forma di punto esclamativo.
            /// </summary>
            IDI_WARNING = IDI_EXCLAMATION,
            /// <summary>
            /// Icona a forma di mano.
            /// </summary>
            IDI_ERROR = IDI_HAND,
            /// <summary>
            /// Icona a forma di asterisco.
            /// </summary>
            IDI_INFORMATION = IDI_ASTERISK
        }

        /// <summary>
        /// Tipo di controllo disegnato dal proprietario.
        /// </summary>
        internal enum OwnerDrawnControlType
        {
            /// <summary>
            /// Menù.
            /// </summary>
            ODT_MENU = 1,
            /// <summary>
            /// Listbox.
            /// </summary>
            ODT_LISTBOX,
            /// <summary>
            /// Combobox.
            /// </summary>
            ODT_COMBOBOX,
            /// <summary>
            /// Pulsante
            /// </summary>
            ODT_BUTTON,
            /// <summary>
            /// Controllo statico.
            /// </summary>
            ODT_STATIC,
            /// <summary>
            /// Header.
            /// </summary>
            ODT_HEADER = 100,
            /// <summary>
            /// Tab.
            /// </summary>
            ODT_TAB,
            /// <summary>
            /// Listview.
            /// </summary>
            ODT_LISTVIEW
        }

        /// <summary>
        /// Azione di disegno da eseguire.
        /// </summary>
        [Flags]
        internal enum OwnerDrawAction
        {
            /// <summary>
            /// L'intero controllo deve essere disegnato.
            /// </summary>
            ODA_DRAWENTIRE = 1,
            /// <summary>
            /// Lo stato di selezione è cambiato.
            /// </summary>
            ODA_SELECT,
            /// <summary>
            /// Il controllo ha perso o ha ricevuto il focus della tastiera.
            /// </summary>
            ODA_FOCUS
        }

        /// <summary>
        /// Stato di un controllo disegnato dal proprietario.
        /// </summary>
        [Flags]
        internal enum OwnerDrawControlState
        {
            /// <summary>
            /// Il menù è selezionato.
            /// </summary>
            ODS_SELECTED = 1,
            /// <summary>
            /// L'oggetto deve essere disattivato.
            /// </summary>
            /// <remarks>Utilizzato solo per i menù.</remarks>
            ODS_GRAYED,
            /// <summary>
            /// L'oggetto deve essere disegnato come disattivato.
            /// </summary>
            ODS_DISABLED = 4,
            /// <summary>
            /// L'oggetto del menù deve essere selezionato.
            /// </summary>
            /// <remarks>Utilizzato solo per i menù.</remarks>
            ODS_CHECKED = 8,
            /// <summary>
            /// L'oggetto ha il focus della tastiera.
            /// </summary>
            ODS_FOCUS = 16,
            /// <summary>
            /// L'oggetto è quello predefinito.
            /// </summary>
            ODS_DEFAULT = 32,
            /// <summary>
            /// L'operazione di disegno è condotta nel controllo di modifica di un ComboBox disegnato dal proprietario.
            /// </summary>
            ODS_COMBOBOXEDIT = 4096,
            /// <summary>
            /// L'oggetto sarà evidenziato quando il mouse si trova sull'oggetto.
            /// </summary>
            ODS_HOTLIGHT = 64,
            /// <summary>
            /// L'oggetto è inattivo e la finestra associata al menù anche.
            /// </summary>
            ODS_INACTIVE = 128,
            /// <summary>
            /// Il controllo è disegnato senza le combinazioni di tasti.
            /// </summary>
            ODS_NOACCEL = 256,
            /// <summary>
            /// Il controllo è disegnato senza il segnale indicatore di focus.
            /// </summary>
            ODS_NOFOCUSRECT = 512
        }
    }
}