using System.Drawing;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;
using static WinApiWrapper.UserInputAndMessaging.LegacyUserInteraction.KeyboardInput.KeyboardInputEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Common
{
    /// <summary>
    /// Struttura comuni a tutti i controlli Windows.
    /// </summary>
    internal static class CommonStructures
    {
        /// <summary>
        /// Informazioni usate per caricare le classi di controlli comuni dalla DLL.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct INITCOMMONCONTROLSEX
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Classi da caricare.
            /// </summary>
            public CommonEnumerations.CommonClasses ClassesLoaded;
        }

        /// <summary>
        /// Informazioni su un messaggio di notifica.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMHDR
        {
            /// <summary>
            /// Handle alla finestra che invia il messaggio.
            /// </summary>
            public HWND SenderWindowHandle;
            /// <summary>
            /// ID del controllo che invia il messaggio.
            /// </summary>
            public uint SenderControlID;
            /// <summary>
            /// Codice della notifica.
            /// </summary>
            public int NotificationCode;
        }

        /// <summary>
        /// Informazioni su una notifica <see cref="CommonNotifications.NM_CUSTOMDRAW"/>.
        /// </summary>
        /// <remarks>Il valore restituito dall'applicazione dipende dal passaggio in corso della procedura di disegno.<br/>
        /// Il campo <see cref="DrawStage"/> contiene tale informazione.<br/><br/>
        /// Quando <see cref="DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_PREPAINT"/> oppure <see cref="DrawstageFlags.CDDS_PREERASE"/>, alcuni controlli inviamo il messaggio <see cref="DrawstageFlags.CDDS_PREERASE"/> prima e si aspettano che il valore di ritorno indica quale sia il messaggio seguente.</remarks>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMCUSTOMDRAW
        {
            /// <summary>
            /// Struttura <see cref="NMHDR"/> con informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationCodeInfo;
            /// <summary>
            /// Passaggio della procedura di disegno.
            /// </summary>
            public DrawstageFlags DrawStage;
            /// <summary>
            /// Handle al contesto dispositivo.
            /// </summary>
            public HDC DeviceContextHandle;
            /// <summary>
            /// Bordi dell'area di disegno.
            /// </summary>
            public RECT BoundingRectangle;
            /// <summary>
            /// Numero dell'oggetto.
            /// </summary>
            /// <remarks>Le informazioni contenute in questo campo, se presenti, dipendono dal tipo di controllo che sta inviando la notifica.</remarks>
            public DWORD_PTR ItemSpec;
            /// <summary>
            /// Stato dell'oggetto.
            /// </summary>
            public ItemState State;
            /// <summary>
            /// Dati definiti dall'applicazione associati all'oggetto.
            /// </summary>
            public LPARAM ItemData;
        }

        /// <summary>
        /// Informazioni su una notifica <see cref="CommonNotifications.NM_CUSTOMDRAW"/> (list view).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMLVCUSTOMDRAW
        {
            /// <summary>
            /// Informazioni generali sulla notifica.
            /// </summary>
            public NMCUSTOMDRAW GeneralInfo;
            /// <summary>
            /// Colore del testo in foreground;
            /// </summary>
            public COLORREF ForegroundTextColor;
            /// <summary>
            /// Colore del testo in background;
            /// </summary>
            public COLORREF BackgroundTextColor;
            /// <summary>
            /// Indice del subitem in corso di disegno.
            /// </summary>
            public int SubItemIndex;
            /// <summary>
            /// Tipo di oggetto da disegnare.
            /// </summary>
            public ListViewItemType ItemType;
            /// <summary>
            /// Colore da usare per visualizzare la faccia di un oggetto.
            /// </summary>
            public Color ItemFaceColor;
            /// <summary>
            /// Valore che indica l'effetto applicato a un'icona.
            /// </summary>
            public int IconEffect;
            /// <summary>
            /// Fase dell'icona.
            /// </summary>
            public int IconPhase;
            /// <summary>
            /// ID della parte dell'oggetto da disegnare.
            /// </summary>
            public int PartID;
            /// <summary>
            /// ID dello stato dell'oggetto da disegnare.
            /// </summary>
            public int StateID;
            /// <summary>
            /// Rettangolo dentro il quale il testo deve essere disegnato.
            /// </summary>
            public RECT TextRectangle;
            /// <summary>
            /// Allineamento del gruppo.
            /// </summary>
            public GroupAlignment GroupAlignment;
        }

        /// <summary>
        /// Informazioni su una notifica <see cref="CommonNotifications.NM_CUSTOMDRAW"/> (tooltip).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMTTCUSTOMDRAW
        {
            /// <summary>
            /// Informazioni generali sulla notifica.
            /// </summary>
            public NMCUSTOMDRAW GeneralInfo;
            /// <summary>
            /// Formato del testo.
            /// </summary>
            public TextFormat TextFormat;
        }

        /// <summary>
        /// Informazioni su una notifica <see cref="CommonNotifications.NM_CUSTOMDRAW"/> (tree view).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMTVCUSTOMDRAW
        {
            /// <summary>
            /// Informazioni generali sulla notifica.
            /// </summary>
            public NMCUSTOMDRAW GeneralInfo;
            /// <summary>
            /// Colore del testo in foreground;
            /// </summary>
            public COLORREF ForegroundTextColor;
            /// <summary>
            /// Colore del testo in background
            /// </summary>
            public COLORREF BackgroundTextColor;
            /// <summary>
            /// Livello, basato su 0, dell'oggetto in corso di disegno.
            /// </summary>
            public int Level;
        }

        /// <summary>
        /// Informazioni su una notifica <see cref="CommonNotifications.NM_CUSTOMDRAW"/> (toolbar).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMTBCUSTOMDRAW
        {
            /// <summary>
            /// Informazioni generali sulla notifica.
            /// </summary>
            public NMCUSTOMDRAW GeneralInfo;
            /// <summary>
            /// Pennello da usare per disegnare lo sfondo di oggetti marcati oppure retinati.
            /// </summary>
            /// <remarks>Questo campo viene ignorato se il valore restituito è <see cref="Toolbars.ToolbarEnumerations.CustomDrawReturnFlags.TBCDRF_NOMARK"/>.</remarks>
            public HBRUSH MonoDitherBrush;
            /// <summary>
            /// Pennello da usare per disegnare le linee sui pulsanti.
            /// </summary>
            public HBRUSH LinesBrush;
            /// <summary>
            /// Penna da usare per disegnare le linee sui pulsanti.
            /// </summary>
            public HPEN LinesPen;
            /// <summary>
            /// Colore da usare per disegnare il testo sugli oggetti normali.
            /// </summary>
            public COLORREF NormalItemsTextColor;
            /// <summary>
            /// Colore dello sfondo da usare per disegnare il testo sugli oggetti marcati.
            /// </summary>
            public COLORREF MarkedItemsBackgroundTextColor;
            /// <summary>
            /// Colore da usare per disegnare il testo sugli oggetti evidenziati.
            /// </summary>
            public COLORREF HighlightedItemsTextColor;
            /// <summary>
            /// Colore della faccia da usare per il disegno dei pulsanti.
            /// </summary>
            public COLORREF ButtonFaceColor;
            /// <summary>
            /// Colore della faccia da usare per il disegno di oggetti evidenziati.
            /// </summary>
            public COLORREF HighlightedItemsFaceColor;
            /// <summary>
            /// Colore dello sfondo da usare per disegnare il testo sugli oggetti hot-tracked.
            /// </summary>
            /// <remarks>Questo campo viene ignorato se il valore restituito non è <see cref="Toolbars.ToolbarEnumerations.CustomDrawReturnFlags.TBCDRF_HILITEHOTRACK"/>.</remarks>
            public COLORREF HotTrackedItemsBackgroundTextColor;
            /// <summary>
            /// Rettangolo del testo dell'oggetto.
            /// </summary>
            public RECT ItemTextRectangle;
            /// <summary>
            /// Modalità dello sfondo usata dal controllo durante il disegno del testo di un oggetto non evidenziato.
            /// </summary>
            /// <remarks>Il valore di questo campo può essere <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants.TRANSPARENT"/> oppure <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants.OPAQUE"/>.</remarks>
            public int NonHighlightedItemsBackgroundMode;
            /// <summary>
            /// Modalità dello sfondo usata dal controllo durante il disegno del testo di un oggetto evidenziato.
            /// </summary>
            /// <remarks>Il valore di questo campo può essere <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants.TRANSPARENT"/> oppure <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants.OPAQUE"/>.</remarks>
            public int HighlightedItemsBackgroundMode;
            /// <summary>
            /// Distanza, in pixel logici, tra l'immagine del pulsante della toolbar e il testo.
            /// </summary>
            public int ListGap;
        }

        /// <summary>
        /// Informazioni sul carattere elaborato da una notifica <see cref="CommonNotifications.NM_CHAR"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMCHAR
        {
            /// <summary>
            /// Informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Il carattere in corso di elaborazione.
            /// </summary>
            public uint Character;
            /// <summary>
            /// Valore determinato dal controllo che invia la notifica.
            /// </summary>
            public DWORD PreviousItem;
            /// <summary>
            /// Valore determinato dal controllo che invia la notifica.
            /// </summary>
            public DWORD NextItem;
        }

        /// <summary>
        /// Informazioni usate con una notifica <see cref="CommonNotifications.NM_CUSTOMTEXT"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMCUSTOMTEXT
        {
            /// <summary>
            /// Informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Handle al contesto dispositivo dove disegnare.
            /// </summary>
            public HDC DeviceContextHandle;
            /// <summary>
            /// Stringa da disegnare.
            /// </summary>
            public LPCWSTR String;
            /// <summary>
            /// Lunghezza di <see cref="String"/>.
            /// </summary>
            public int StringLength;
            /// <summary>
            /// Puntatore a struttura <see cref="RECT"/> dove disegnare.
            /// </summary>
            public IntPtr DrawRectangle;
            /// <summary>
            /// Opzioni di formattazione del testo.
            /// </summary>
            public TextFormat TextFormat;
            /// <summary>
            /// Indica se il testo è un collegamento.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool IsLink;
        }

        /// <summary>
        /// Informazioni sui due rettangoli di uno split button.
        /// </summary>
        /// <remarks>Le informazioni della struttura vengono usate solo se il pulsante ha lo stile <see cref="Buttons.ButtonEnumerations.ButtonStyles.BS_SPLITBUTTON"/> oppure <see cref="Buttons.ButtonEnumerations.ButtonStyles.BS_DEFSPLITBUTTON"/>.</remarks>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMCUSTOMSPLITRECTINFO
        {
            /// <summary>
            /// Informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Struttura <see cref="RECT"/> che descrive l'area client occupata dal pulsante.
            /// </summary>
            public RECT ButtonRectangle;
            /// <summary>
            /// Struttura <see cref="RECT"/> che descrive il rettangolo che non contiene la freccia.
            /// </summary>
            public RECT RectangleWithoutDropdownArrow;
            /// <summary>
            /// Struttura <see cref="RECT"/> che descrive il rettangolo che contiene la freccia.
            /// </summary>
            public RECT RectangleWithDropdownArrow;
        }

        /// <summary>
        /// Informazioni usate con le notifiche relative ai tasti.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMKEY
        {
            /// <summary>
            /// Informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Codice virtuale del tasto.
            /// </summary>
            public VirtualKeyCodes KeyCode;
            /// <summary>
            /// Flag associate con il tasto.
            /// </summary>
            public uint KeyFlags;
        }

        /// <summary>
        /// Informazioni usate con le notifiche del mouse.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMMOUSE
        {
            /// <summary>
            /// Informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Identificativo specifico del controllo.
            /// </summary>
            public DWORD_PTR ItemSpec;
            /// <summary>
            /// Dati specifici del controllo.
            /// </summary>
            public DWORD_PTR ItemData;
            /// <summary>
            /// Coordinate del mouse dove è avvenuto il click.
            /// </summary>
            public POINT Coordinates;
            /// <summary>
            /// Informazioni sulla posizione nel controllo o nell'oggetto del puntatore.
            /// </summary>
            public LPARAM CursorPosition;
        }

        /// <summary>
        /// Informazioni usate con la notifica <see cref="CommonNotifications.NM_TOOLTIPSCREATED"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMTOOLTIPSCREATED
        {
            /// <summary>
            /// Struttura <see cref="NMHDR"/> che contiene altre informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Handle al tooltip creato.
            /// </summary>
            public HWND TooltipHandle;
        }

        /// <summary>
        /// Informazioni usate con la notifica <see cref="CommonNotifications.NM_TVSTATEIMAGECHANGING"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMTVSTATEIMAGECHANGING
        {
            /// <summary>
            /// Struttura <see cref="NMHDR"/> che contiene altre informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Handle al controllo vista ad albero la cui immagine di state sta cambiando.
            /// </summary>
            public HTREEITEM TreeViewHandle;
            /// <summary>
            /// Indice della vecchia immagine di state.
            /// </summary>
            public int OldStateImageIndex;
            /// <summary>
            /// Indice della nuova immagine di stato.
            /// </summary>
            public int NewStateImageIndex;
        }

        /// <summary>
        /// Informazioni usate con le notifiche <see cref="Toolbars.ToolbarNotifications.TBN_GETOBJECT"/>, <see cref="TCN_GETOBJECT "/> e <see cref="PropertySheets.PSEnumerations.PSN_GETOBJECT"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NMOBJECTNOTIFY
        {
            /// <summary>
            /// Struttura <see cref="NMHDR"/> con informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationInfo;
            /// <summary>
            /// Identificativo specifico del controllo.
            /// </summary>
            /// <remarks>Questo campo non è usato per la notifica <see cref="PSN_GETOBJECT"/>.</remarks>
            public int COntrolIdentifier;
            /// <summary>
            /// Puntatore a GUID identificativo dell'interfaccia.
            /// </summary>
            public IntPtr InterfaceIDPointer;
            /// <summary>
            /// Puntatore a oggetto fornito dalla finestra che elabora la notifica.
            /// </summary>
            /// <remarks>L'applicazione imposta questo campo.</remarks>
            public IntPtr Object;
            /// <summary>
            /// Codice di errore COM.
            /// </summary>
            /// <remarks>L'applicazione imposta questo campo.</remarks>
            public HRESULT ErrorCode;
            /// <summary>
            /// 
            /// </summary>
            public DWORD Flags;
        }
    }
}