using WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes;
using Windows.Web.UI;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.GeneralEnumerations;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows
{
    /// <summary>
    /// Struttura delle finestre.
    /// </summary>
    internal static class WindowStructures
    {
        /// <summary>
        /// Informazioni su una finestra.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWINFO
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Coordinate della finestra.
            /// </summary>
            public RECT WindowCoordinate;
            /// <summary>
            /// Coordinate dell'area client della finestra.
            /// </summary>
            public RECT ClientAreaCoordinates;
            /// <summary>
            /// Stili della finestra.
            /// </summary>
            public WindowStyle Styles;
            /// <summary>
            /// Stili estesi della finestra.
            /// </summary>
            public WindowExtendedStyle ExtendedStyles;
            /// <summary>
            /// Indica se la finestra è attiva.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public bool Status;
            /// <summary>
            /// Larghezza del bordo della finestra, in pixel.
            /// </summary>
            public uint BorderWidth;
            /// <summary>
            /// Altezza del bordo della finestra, in pixel.
            /// </summary>
            public uint BorderHeigth;
            /// <summary>
            /// ATOM che identifica la classe della finestra.
            /// </summary>
            public ATOM ClassAtom;
            /// <summary>
            /// Versione di Windows dell'applicazione che ha creato la finestra.
            /// </summary>
            public WORD CreatorVersion;
        }

        /// <summary>
        /// Fornisce gli ID e i dati forniti dall'applicazione per due oggetti in un list box o in un ComboBox ordinato e disegnato dal suo proprietario.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct COMPAREITEMSTRUCT
        {
            /// <summary>
            /// Tipo di controllo.
            /// </summary>
            public OwnerDrawnControlType Type;
            /// <summary>
            /// ID del list box o del ComboBox.
            /// </summary>
            public uint ID;
            /// <summary>
            /// Handle al controllo.
            /// </summary>
            public HWND ControlHandle;
            /// <summary>
            /// Indice del primo oggetto nel list box o ComboBox che deve essere confrontato.
            /// </summary>
            /// <remarks>Questa campo ha valore -1 se l'oggetto non è stato inserito o durante la ricerca di un potenziale oggetto nel list box o ComboBox.</remarks>
            public int FirstItemIndex;
            /// <summary>
            /// Dati forniti dall'applicazione per il primo oggetto da confrontare.
            /// </summary>
            public ULONG_PTR FirstItemData;
            /// <summary>
            /// Indice del secondo oggetto nel list box o ComboBox da confrontare.
            /// </summary>
            ///  <remarks>Questo campo avrà valore -1 se l'oggetto non è stato inserito o durante la ricerca di un potenziale oggetto nel list box o ComboBox.</remarks>
            public int SecondItemIndex;
            /// <summary>
            /// Dati forniti dall'applicazione per il secondo oggetto da confrontare.
            /// </summary>
            public ULONG_PTR SecondItemData;
            /// <summary>
            /// ID località.
            /// </summary>
            public LCID LocaleID;
        }

        /// <summary>
        /// Fornisce informazioni usate per determinare come disegnare un controllo disegnato dal proprietario o un oggetto di un menù.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DRAWITEMSTRUCT
        {
            /// <summary>
            /// Tipo di controllo.
            /// </summary>
            /// <remarks>Alcuni tipi di controlli non impostano il valore di questo campo.</remarks>
            public OwnerDrawnControlType Type;
            /// <summary>
            /// ID del controllo.
            /// </summary>
            /// <remarks>Questo campo non è usato per i menù.</remarks>
            public int ControlID;
            /// <summary>
            /// ID dell'oggetto.
            /// </summary>
            /// <remarks>Per un menù, questo campo è l'ID dell'oggetto, per un list box o un ComboBox è l'indice dell'oggetto.<br/><br/>
            /// Questo campo ha valore -1 per un list box o un ComboBox vuoto, in questo caso indica all'utente se il controllo ha il focus o meno.</remarks>
            public int ItemID;
            /// <summary>
            /// Azione di disegno da eseguire.
            /// </summary>
            public OwnerDrawAction Action;
            /// <summary>
            /// Stato visivo del oggetto dopo che l'azione attuale di disegno è stata eseguita.
            /// </summary>
            public OwnerDrawControlState State;
            /// <summary>
            /// Handle al controllo, per i menù, questo campo è un handle al menù che contiene l'oggetto.
            /// </summary>
            public HWND ControlHandle;
            /// <summary>
            /// Handle al contesto dispositivo.
            /// </summary>
            /// <remarks>Questo contesto dispositivo può essere usato per eseguire operazioni di disegno sul controllo.</remarks>
            public HDC DeviceContextHandle;
            /// <summary>
            /// Rettangolo che definisce i limiti del controllo da disegnare.
            /// </summary>
            public RECT ControlBoundaries;
            /// <summary>
            /// Valore fornito dall'applicazione associato con l'oggetto di menù.
            /// </summary>
            /// <remarks>Per un controllo questo campo specifica l'ultimo valore assegnato al list box o al ComboBox dai messaggi <see cref="ListBoxMessages.LB_SETITEMDATA"/> o <see cref="ComboBoxMessages.CB_SETITEMDATA"/> rispettivamente.<br/><br/>
            /// Se il list box o il ComboBox ha lo stile <see cref="ListBoxEnumerations.ListBoxStyles.LBS_HASSTRINGS"/> o <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_HASSTRINGS"/> applicato rispettivamente, questo campo ha inizialmente valore 0, altrimenti ha il valore fornito da uno dei seguenti messaggi:<br/><br/>
            /// <see cref="ComboBoxMessages.CB_ADDSTRING"/><br/>
            /// <see cref="ComboBoxMessages.CB_INSERTSTRING"/><br/>
            /// <see cref="ListBoxMessages.LB_ADDSTRING"/><br/>
            /// <see cref="ListBoxMessages.LB_INSERTSTRING"/><br/><br/>
            /// Se <see cref="Type"/> ha valore <see cref="OwnerDrawnControlType.ODT_BUTTON"/> oppure <see cref="OwnerDrawnControlType.ODT_STATIC"/>, questo campo ha valore 0.</remarks>
            public ULONG_PTR ItemData;
        }

        /// <summary>
        /// Informa il sistema delle dimensioni di un controllo disegnato dal proprietario o dell'oggetto di menù..
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MEASUREITEMSTRUCT
        {
            /// <summary>
            /// Tipo di controllo.
            /// </summary>
            public OwnerDrawnControlType ControlType;
            /// <summary>
            /// ID del controllo.
            /// </summary>
            /// <remarks>Questo campo non è usato per i menù.</remarks>
            public int ControlID;
            /// <summary>
            /// Larghezza, in pixel, di un elemento di un menù.
            /// </summary>
            /// <remarks>Il proprietario dell'elemento di menù deve impostare questo campo.</remarks>
            public int Width;
            /// <summary>
            /// Altezza, in pixel dell'elemento singolo in un list box o di un menù.
            /// </summary>
            /// <remarks>Il proprietario del controllo o dell'elemento di menù deve impostare questo campo.</remarks>
            public int Height;
            /// <summary>
            /// Valore fornito dall'applicazione associato con l'oggetto di menù.
            /// </summary>
            /// <remarks>Per un controllo questo campo specifica l'ultimo valore assegnato al list box o al ComboBox dai messaggi <see cref="ListBoxMessages.LB_SETITEMDATA"/> o <see cref="ComboBoxMessages.CB_SETITEMDATA"/> rispettivamente.<br/><br/>
            /// Se il list box o il ComboBox ha lo stile <see cref="ListBoxEnumerations.ListBoxStyles.LBS_HASSTRINGS"/> o <see cref="ComboBoxEnumerations.ComboBoxStyles.CBS_HASSTRINGS"/> applicato rispettivamente, questo campo ha inizialmente valore 0, altrimenti ha il valore fornito da uno dei seguenti messaggi:<br/><br/>
            /// <see cref="ComboBoxMessages.CB_ADDSTRING"/><br/>
            /// <see cref="ComboBoxMessages.CB_INSERTSTRING"/><br/>
            /// <see cref="ListBoxMessages.LB_ADDSTRING"/><br/>
            /// <see cref="ListBoxMessages.LB_INSERTSTRING"/></remarks>
            public ULONG_PTR ItemData;
        }
    }
}