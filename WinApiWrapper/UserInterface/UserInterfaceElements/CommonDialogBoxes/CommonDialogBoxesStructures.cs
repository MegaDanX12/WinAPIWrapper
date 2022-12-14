using ABI.Windows.Foundation;
using static WinApiWrapper.Devices.DeviceGeneralStructures;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes.CommonDialogBoxesCallbacks;
using static WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes.CommonDialogBoxesEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes
{
    /// <summary>
    /// Strutture usate da tutte le finestre di dialogo.
    /// </summary>
    internal static class CommonDialogBoxesStructures
    {
        /// <summary>
        /// Informazioni di inizializzazione di una finestra di dialogo selezione colori.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CHOOSECOLOR
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Handle alla finestra proprietaria della finestra di dialogo.
            /// </summary>
            /// <remarks>Questo campo può essere un qualunque handle valido o può essere <see cref="IntPtr.Zero"/> se la finestra di dialogo non ha un proprietario.</remarks>
            public HWND DialogOwner;
            /// <summary>
            /// Handle al modulo che contiene il modello oppure al modello precaricato da usare al posto di quello predefinito.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> contiene <see cref="ColorDialogInitializationOptions.CC_ENABLETEMPLATEHANDLE"/>, questo campo è un handle al modello precaricato, se, invece, <see cref="InitializationOptions"/> contiene <see cref="ColorDialogInitializationOptions.CC_ENABLETEMPLATE"/>, questo campo è un handle al modulo che contiene il modello.<br/>
            /// Questo campo è ignorato se nessuna delle opzioni è impostata.</remarks>
            public HWND ModuleInstance;
            /// <summary>
            /// Colore selezionato al momento della creazione della finestra di dialogo.
            /// </summary>
            /// <remarks>Se questo campo ha valore 0 o se <see cref="InitializationOptions"/> non include <see cref="ColorDialogInitializationOptions.CC_RGBINIT"/>, il colore selezionato è nero.<br/>
            /// Quando l'utente preme OK, questo campo contiene il colore selezionato.</remarks>
            public COLORREF InitialSelection;
            /// <summary>
            /// Array di 16 elementi che contiene i valori RGB dei colori personalizzati.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public COLORREF[] CustomColors;
            /// <summary>
            /// Opzioni di inizializzazione della finestra di dialogo.
            /// </summary>
            public ColorDialogInitializationOptions InitializationOptions;
            /// <summary>
            /// Data definiti dall'applicazione da passare al delegato indicato da <see cref="HookProcedure"/>.
            /// </summary>
            /// <remarks>Quando il sistema invia il messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_INITDIALOG"/> al delegato, lParam specifica un puntatore alla struttura <see cref="CHOOSECOLOR"/> specificata quando la finestra di dialogo è stata creata, questo puntatore può essere usato per recuperare i dati di questo campo.</remarks>
            public LPARAM CustomData;
            /// <summary>
            /// Puntatore al delegato che elabora i messaggi intesi per la finestra di dialogo.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> non contiene <see cref="ColorDialogInitializationOptions.CC_ENABLEHOOK"/>, questo campo viene ignorato.</remarks>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public NotificationHandlerProcedure HookProcedure;
            /// <summary>
            /// Nome del modello all'interno del modulo identificato da <see cref="ModuleInstance"/>.
            /// </summary>
            /// <remarks>Le stringhe restituite da <see cref="MAKEINTRESOURCE"/> sono valide per questo campo.<br/><br/>
            /// Se <see cref="InitializationOptions"/> non include <see cref="ColorDialogInitializationOptions.CC_ENABLETEMPLATE"/>, questo campo viene ignorato.</remarks>
            public LPCWSTR TemplateName;
        }

        /// <summary>
        /// Informazioni di inizializzazione di una finestra di dialogo selezione font.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CHOOSEFONT
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Handle alla finestra proprietaria della finestra di dialogo.
            /// </summary>
            public HWND OwnerHandle;
            /// <summary>
            /// Membro ignorato.
            /// </summary>
            private HDC DeviceContextHandle;
            /// <summary>
            /// Puntatore a struttura <see cref="LOGFONT"/>.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> include <see cref="FontDialogInitializationOptions.CF_INITLOGFONTSTRUCT"/> e i membri della struttura sono impostati, la finestra di dialogo viene inizializzata usando tali informazioni.<br/><br/>
            /// Quando l'utente preme OK i membri della struttura vengono impostati in base alla selezione.</remarks>
            public IntPtr FontStructurePointer;
            /// <summary>
            /// Dimensione, in unità di 1/10 di punto, del font.
            /// </summary>
            /// <remarks>Questo valore viene impostato dopo che l'utente chiude la finestra di dialogo.</remarks>
            public int FontSize;
            /// <summary>
            /// Opzioni di inizializzazione della finestra di dialogo.
            /// </summary>
            public FontDialogInitializationOptions InitializationOptions;
            /// <summary>
            /// Colore inizialmente selezionato del font.
            /// </summary>
            /// <remarks>Questo campo viene ignorato se <see cref="InitializationOptions"/> non include <see cref="FontDialogInitializationOptions.CF_EFFECTS"/>.</remarks>
            public COLORREF Colors;
            /// <summary>
            /// Data definiti dall'applicazione da passare al delegato indicato da <see cref="HookProcedure"/>.
            /// </summary>
            /// <remarks>Quando il sistema invia il messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_INITDIALOG"/> al delegato, lParam specifica un puntatore alla struttura <see cref="CHOOSEFONT"/> specificata quando la finestra di dialogo è stata creata, questo puntatore può essere usato per recuperare i dati di questo campo.</remarks>
            public LPARAM CustomData;
            /// <summary>
            /// Puntatore al delegato che elabora i messaggi intesi per la finestra di dialogo.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> non contiene <see cref="ColorDialogInitializationOptions.CC_ENABLEHOOK"/>, questo campo viene ignorato.</remarks>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public NotificationHandlerProcedure HookProcedure;
            /// <summary>
            /// Nome del modello all'interno del modulo identificato da <see cref="ModuleHandle"/>.
            /// </summary>
            /// <remarks>Le stringhe restituite da <see cref="MAKEINTRESOURCE"/> sono valide per questo campo.<br/><br/>
            /// Se <see cref="InitializationOptions"/> non include <see cref="FontDialogInitializationOptions.CF_ENABLETEMPLATE"/>, questo campo viene ignorato.</remarks>
            public LPCWSTR TemplateName;
            /// <summary>
            /// Handle al modulo che contiene il modello oppure al modello precaricato da usare al posto di quello predefinito.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> contiene <see cref="FontDialogInitializationOptions.CF_ENABLETEMPLATEHANDLE"/>, questo campo è un handle al modello precaricato, se, invece, <see cref="InitializationOptions"/> contiene <see cref="FontDialogInitializationOptions.CF_ENABLETEMPLATE"/>, questo campo è un handle al modulo che contiene il modello.<br/>
            /// Questo campo è ignorato se nessuna delle opzioni è impostata.</remarks>
            public HINSTANCE ModuleHandle;
            /// <summary>
            /// Informazioni sullo stile iniziale.
            /// </summary>
            public LPWSTR StyleData;
            /// <summary>
            /// Tipo di font.
            /// </summary>
            public FontType FontType;
            /// <summary>
            /// Allineamento.
            /// </summary>
            private WORD Alignment;
            /// <summary>
            /// Dimensione minima di un font.
            /// </summary>
            public int MinimumSize;
            /// <summary>
            /// Dimensione massima di un font.
            /// </summary>
            public int MaximumSize;
        }

        /// <summary>
        /// Informazioni identificative per una stampante.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DEVNAMES
        {
            /// <summary>
            /// Offset, in caratteri, dall'inizio di questa struttura fino alla stringa a terminazione nulla che contiene il nome del file senza estensione del driver di dispositivo.
            /// </summary>
            /// <remarks>In input, questa stringa è usata per determinare la stampante da mostrare inizialmente nella finestra di dialogo.</remarks>
            public WORD DriverOffset;
            /// <summary>
            /// Offset, in caratteri, dall'inizio di questa struttura fino alla stringa a terminazione nulla che contiene il nome del dispositivo.
            /// </summary>
            public WORD DeviceOffset;
            /// <summary>
            /// Offset, in caratteri, dall'inizio di questa struttura fino alla stringa terminazione nulla che contiene il nome del dispositivo per la porta di output.
            /// </summary>
            public WORD OutputOffset;
            /// <summary>
            /// Indica se le stringhe nella struttura identificano la stampante predefinita.
            /// </summary>
            public WORD Default;
        }

        /// <summary>
        /// Informazioni usate dalle funzioni <see cref="CommonDialogBoxesFunctions.FindText"/> e <see cref="CommonDialogBoxesFunctions.ReplaceText"/> per inizializzare la finestra di dialogo "Trova e sostituisci".
        /// </summary>
        /// <remarks>Il messaggio registrato <see cref="CommonDialogBoxesNotifications.FINDMSGSTRING"/> usa questa struttura per passare l'input dell'utente al proprietario della finestra di dialogo.</remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct FINDREPLACE
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public DWORD StructureSize;
            /// <summary>
            /// Handle alla finestra proprietaria della finestra di dialogo.
            /// </summary>
            /// <remarks>Questa finestra riceve i messaggi <see cref="CommonDialogBoxesNotifications.FINDMSGSTRING"/>.<br/><br/>
            /// Il campo non può essere nullo.</remarks>
            public HWND Owner;
            /// <summary>
            /// Handle a un modello di finestra di dialogo.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> include <see cref="FindDialogInitializationOptions.FR_ENABLETEMPLATEHANDLE"/>, questo campo è un handle a un oggetto che contiene il modello.<br/>
            /// Se <see cref="InitializationOptions"/> include <see cref="FindDialogInitializationOptions.FR_ENABLETEMPLATE"/>, questo campo è un handle al modulo che contiele il modello il cui nome è specificato da <see cref="TemplateName"/>.<br/>
            /// Se nessuna delle due opzioni e impostata, questo campo viene ignorato.</remarks>
            public HINSTANCE ModuleHandle;
            /// <summary>
            /// Opzioni di inizializzazione e informazioni sull'input dell'utente.
            /// </summary>
            public FindDialogInitializationOptions InitializationOptions;
            /// <summary>
            /// La stringa che l'utente ha scritto nel controllo di modifica "Trova".
            /// </summary>
            /// <remarks>Il buffer che contiene la stringa deve essere allocato dinamicamente oppure deve essere un array globale o statico così che sia sempre disponibile fino alla chiusura della finestra di dialogo.<br/>
            /// Il buffer dovrebbe avere una lunghezza di almeno 80 caratteri.<br/>
            /// Se il buffer contiene una stringa al momento dell'inizializzazione, essa verrà visualizzata nel controllo di modifica.<br/><br/>
            /// Se il messaggio <see cref="CommonDialogBoxesNotifications.FINDMSGSTRING"/> specifica <see cref="FindDialogInitializationOptions.FR_FINDNEXT"/>, il campo contiene contiene la stringa da cercare.<br/>
            /// Le opzioni <see cref="FindDialogInitializationOptions.FR_DOWN"/>, <see cref="FindDialogInitializationOptions.FR_WHOLEWORD"/> e <see cref="FindDialogInitializationOptions.FR_MATCHCASE"/> indicano la direzione e il tipo di ricerca.<br/>
            /// Se il messaggio <see cref="CommonDialogBoxesNotifications.FINDMSGSTRING"/> specifica <see cref="FindDialogInitializationOptions.FR_REPLACE"/> oppure <see cref="FindDialogInitializationOptions.FR_REPLACEALL"/>, il campo contiene la stringa da sostituire.</remarks>
            public string FindWhat;
            /// <summary>
            /// La stringa sostitutiva che l'utente ha scritto nel controllo di modifica "Sostituisci".
            /// </summary>
            /// <remarks>Il buffer che contiene la stringa deve essere allocato dinamicamente oppure deve essere un array globale o statico così che sia sempre disponibile fino alla chiusura della finestra di dialogo.<br/>
            /// Il buffer dovrebbe avere una lunghezza di almeno 80 caratteri.<br/>
            /// Se il buffer contiene una stringa al momento dell'inizializzazione, essa verrà visualizzata nel controllo di modifica.<br/><br/>
            /// Se il messaggio <see cref="CommonDialogBoxesNotifications.FINDMSGSTRING"/> specifica <see cref="FindDialogInitializationOptions.FR_REPLACE"/> oppure <see cref="FindDialogInitializationOptions.FR_REPLACEALL"/>, il campo contiene la stringa da sostituire.</remarks>
            public string ReplaceWith;
            /// <summary>
            /// Lunghezza, in bytes, del buffer puntato da <see cref="FindWhat"/>.
            /// </summary>
            public WORD FindWhatLength;
            /// <summary>
            /// Lunghezza, in bytes, del buffer puntato da <see cref="ReplaceWith"/>.
            /// </summary>
            public WORD ReplaceWithLength;
            /// <summary>
            /// Data forniti dall'applicazione passati all'hook specificato da <see cref="HookProcedure"/>.
            /// </summary>
            public LPARAM CustomData;
            /// <summary>
            /// Puntatore al delegato che elabora i messaggi intesi per la finestra di dialogo.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public NotificationHandlerProcedure HookProcedure;
            /// <summary>
            /// Nome del modello di finestra di dialogo nel modulo identificato da <see cref="ModuleHandle"/>.
            /// </summary>
            /// <remarks>I valori restituiti da <see cref="MAKEINTRESOURCE"/> sono validi per questo campo.</remarks>
            public string TemplateName;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct PAGESETUPDLG
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public DWORD StructureSize;
            /// <summary>
            /// Handle alla proprietaria della finestra di dialogo.
            /// </summary>
            public HWND Owner;
            /// <summary>
            /// Handle a un oggetto globale di memoria che contiene una struttura <see cref="Devices.DeviceGeneralStructures.DEVMODEPRINTER"/>.
            /// </summary>
            /// <remarks>In input, se viene specificato un handle, la struttura viene utilizzata per inizializzare i controlli della finestra di dialogo.<br/>
            /// In output, la finestra di dialogo imposta questo campo a un handle a un oggetto globale di memoria che contiene una struttura <see cref="Devices.DeviceGeneralStructures.DEVMODEPRINTER"/> che specifica la selezione dell'utente.<br/>
            /// Se le selezioni dell'utente non sono disponibili questo campo è impostato a <see cref="IntPtr.Zero"/>.</remarks>
            public HGLOBAL DevModeMemoryObject;
            /// <summary>
            /// Handle a un oggetto globale di memoria che contiene una struttura <see cref="DEVNAMES"/>.
            /// </summary>
            /// <remarks>In input, se viene specificato un handle, la struttura viene utilizzata per inizializzare i controlli della finestra di dialogo.<br/>
            /// In output, la finestra di dialogo imposta questo campo a un handle a un oggetto globale di memoria che contiene una struttura <see cref="DEVNAMES"/> che specifica la selezione dell'utente.<br/>
            /// Se le selezioni dell'utente non sono disponibili questo campo è impostato a <see cref="IntPtr.Zero"/>.</remarks>
            public HGLOBAL DevNamesMemoryObject;
            /// <summary>
            /// Opzioni di inizializzazione.
            /// </summary>
            public PageSetupDialogInitializationOptions InitializationOptions;
            /// <summary>
            /// Dimensioni della pagine selezionata dall'utente.
            /// </summary>
            /// <remarks>Le opzioni <see cref="PageSetupDialogInitializationOptions.PSD_INTHOUSANDTHSOFINCHES"/> e <see cref="PageSetupDialogInitializationOptions.PSD_INHUNDREDTHSOFMILLIMETERS"/> specificano le unità di misura.</remarks>
            public POINT PaperSize;
            /// <summary>
            /// Le larghezze minime per i margini sinistro, superiore, destro e inferiore.
            /// </summary>
            /// <remarks>Questo campo viene ignorato se l'opzione <see cref="PageSetupDialogInitializationOptions.PSD_MINMARGINS"/> non è impostata.<br/><br/>
            /// Il valore di questo campo deve essere minore o uguale a quello di <see cref="Margin"/>.<br/><br/>
            /// Le opzioni <see cref="PageSetupDialogInitializationOptions.PSD_INTHOUSANDTHSOFINCHES"/> e <see cref="PageSetupDialogInitializationOptions.PSD_INHUNDREDTHSOFMILLIMETERS"/> specificano le unità di misura.</remarks>
            public RECT MinimumMargin;
            /// <summary>
            /// Le larghezze dei margini sinistro, superiore, destro e inferiore.
            /// </summary>
            /// <remarks>Se l'opzione <see cref="PageSetupDialogInitializationOptions.PSD_MARGINS"/> è impostata, questo campo specifica i margini iniziali.<br/><br/>
            /// Questo campo viene impostato alle larghezze dei margini selezionate dall'utente.<br/><br/>
            /// Le opzioni <see cref="PageSetupDialogInitializationOptions.PSD_INTHOUSANDTHSOFINCHES"/> e <see cref="PageSetupDialogInitializationOptions.PSD_INHUNDREDTHSOFMILLIMETERS"/> specificano le unità di misura.</remarks>
            public RECT Margin;
            /// <summary>
            /// Handle al modulo che contiene il modello di finestra di dialogo il cui nome è specificato in <see cref="PageSetupTemplateName"/>.
            /// </summary>
            public HINSTANCE ModuleHandle;
            /// <summary>
            /// Dati definiti dall'applicazione.
            /// </summary>
            public LPARAM CustomData;
            /// <summary>
            /// Hook che elabora i messaggi intesi per la finestra di dialogo.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public NotificationHandlerProcedure PageSetupHook;
            /// <summary>
            /// Hook che elabora i messaggi relativi al ridisegno della pagine di esempio.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public NotificationHandlerProcedure PagePaintHook;
            /// <summary>
            /// Nome del modello di finestra di dialogo presente nel modulo indicato da <see cref="ModuleHandle"/>.
            /// </summary>
            /// <remarks>Le stringhe restituite da <see cref="MAKEINTRESOURCE"/> sono valide per questo campo.</remarks>
            public string PageSetupTemplateName;
            /// <summary>
            /// Handle a un oggetto di memoria che contiene il modello della finestra di dialogo.
            /// </summary>
            public HGLOBAL PageSetupTemplate;
        }

        /// <summary>
        /// Informazioni di inizializzazione della finestra di dialogo "Stampa".
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct PRINTDLG
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public DWORD StructureSize;
            /// <summary>
            /// Handle alla proprietaria delaa finestra di dialogo.
            /// </summary>
            public HWND OwnerHandle;
            /// <summary>
            /// Handle all'oggetto di memoria mobile globale che contiene una struttura <see cref="DEVMODEPRINTER"/>.
            /// </summary>
            /// <remarks>Se questo campo non è nullo, il blocco di memoria allocato deve contenere una struttura <see cref="DEVMODEPRINTER"/> inizializzata.<br/>
            /// I dati in questa struttura sono usati per inizializzare i controlli nella finestra, alla chiusura di essa, la struttura contiene l'input dell'utente.<br/><br/>
            /// Se questo campo è nullo, l'allocazione della memoria e l'inizializzazione della struttura sono eseguiti automaticamente con l'input dell'utente, il campo viene impostato a un handle all'oggetto di memoria.</remarks>
            public HGLOBAL DevModeMemoryObject;
            /// <summary>
            /// Handle all'oggetto di memoria mobile globale che contiene una struttura <see cref="DEVNAMES"/>.
            /// </summary>
            /// <remarks>Se questo campo non è nullo, il blocco di memoria allocato deve contenere una struttura <see cref="DEVNAMES"/> inizializzata.<br/>
            /// I dati in questa struttura sono usati per inizializzare i controlli nella finestra, alla chiusura di essa, la struttura contiene informazioni sulla stampante scelta.<br/><br/>
            /// Se questo campo è nullo, l'allocazione della memoria e l'inizializzazione della struttura sono eseguiti automaticamente con l'input dell'utente, il campo viene impostato a un handle all'oggetto di memoria.</remarks>
            public HGLOBAL DevNamesMemoryObject;
            /// <summary>
            /// Handle al contesto dispositivo o al contesto d'informazione, in base al valore di <see cref="InitializationOptions"/>.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> contiene <see cref="PrintDialogInitializationOptions.PD_RETURNDC"/>, il campo è un handle a un contesto dispositivo.<br/>
            /// Se <see cref="InitializationOptions"/> contiene <see cref="PrintDialogInitializationOptions.PD_RETURNIC"/>, il campo è un handle a un contesto d'informazione.<br/><br/>
            /// Se <see cref="InitializationOptions"/> contiene entrambe le opzioni, <see cref="PrintDialogInitializationOptions.PD_RETURNDC"/> ha priorità.</remarks>
            public HDC DeviceContextHandle;
            /// <summary>
            /// Opzioni di inizializzazione della finestra di dialogo.
            /// </summary>
            public PrintDialogInitializationOptions InitializationOptions;
            /// <summary>
            /// 
            /// </summary>
            public DWORD Flags2;
            /// <summary>
            /// Indica se escludere i controlli "Copie" e "Fascicola" dalle pagine di proprietà del driver.
            /// </summary>
            public DWORD ExclusionFlags;
            /// <summary>
            /// In input, indica il numero iniziale di insiemi di pagine nell'array puntato da <see cref="PageRanges"/>, in output, indica il numero di insiemi di pagine specificati dall'utente presenti nell'array.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_NOPAGENUMS"/>, il valore di questo campo non è valido.</remarks>
            public DWORD PageRangesCount;
            /// <summary>
            /// Dimensione dell'array puntato da <see cref="PageRanges"/>.
            /// </summary>
            /// <remarks>Questo valore indica il numero massimo di insiemi di pagine che possono essere inclusi nell'array.<br/>
            /// Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_NOPAGENUMS"/>, questo valore non è valido, in caso contrario, questo valore deve essere maggiore di 0.</remarks>
            public DWORD MaxPageRangesCount;
            /// <summary>
            /// Puntatore a un buffer che contiene un'array di strutture <see cref="PRINTPAGERANGE"/>.
            /// </summary>
            /// <remarks>In input, l'array contiene gli insiemi di pagine iniziali ma visualizzare nel controllo di modifica "Pagine".<br/>
            /// In output, l'array contiene gli insiemi di pagine specificati dall'utente.<br/><br/>
            /// Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_NOPAGENUMS"/>, questo valore non è valido, in caso contrario, questo campo non deve essere nullo.</remarks>
            public IntPtr PageRanges;
            /// <summary>
            /// Il valore minimo per gli insiemi di pagine specificati nel controllo di modifica "Pagine".
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_NOPAGENUMS"/>, questo valore non è valido.</remarks>
            public DWORD MinimumPageRanges;
            /// <summary>
            /// Il valore massimo per gli insiemi di pagine specificati nel controllo di modifica "Pagine".
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_NOPAGENUMS"/>, questo valore non è valido.</remarks>
            public DWORD MaximumPageRanges;
            /// <summary>
            /// Numero iniziale di copie presente nel controllo di modifica "Copie" quando <see cref="DevModeMemoryObject"/> è nullo.
            /// </summary>
            /// <remarks>Se <see cref="DevModeMemoryObject"/> non è nullo, <see cref="DEVMODEPRINTER.Copies"/> contiene il valore iniziale.<br/><br/>
            /// In output, questo campo contiene il numero effettivo di copie che l'applicazione deve stampare.<br/>
            /// Il valore dipende dal responsabile dell'esecuzione dell'operazione.<br/><br/>
            /// Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_USEDEVMODECOPIESANDCOLLATE"/>, questo campo ha sempre valore 1 in output e il driver della stampante è responsabile della stampa di copie multiple.<br/>
            /// In caso contrario, l'applicazione è responsabile dell'operazione.</remarks>
            public DWORD CopiesCount;
            /// <summary>
            /// Handle al modulo o all'oggetto di memoria che contiene un modello di finestra di dialogo.
            /// </summary>
            /// <remarks>Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_ENABLEPRINTTEMPLATE"/>, questo campo è un handle all'applicazione o al modulo che contiene il modello di finestra di dialogo il cui nome è specificato da <see cref="PrintDialogTemplateName"/>.<br/>
            /// Se <see cref="InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_ENABLEPRINTTEMPLATEHANDLE"/>, questo campo è un handle a un oggetto di memoria che contiene il modello di finestra di dialogo.<br/>
            /// Se nessuna delle opzioni è impostata, questo campo dovrebbe essere nullo.</remarks>
            public HINSTANCE ModuleHandle;
            /// <summary>
            /// Nome del modello di finestra di dialogo presente nel modulo identificato da <see cref="ModuleHandle"/>.
            /// </summary>
            public string PrintDialogTemplateName;
            /// <summary>
            /// Puntatore a un oggetto di callback definito dall'applicazione.
            /// </summary>
            /// <remarks>L'oggetto dovrebbe contenere una classe IPrintDialogCallback per ricevere i messaggi dalle finestre di dialogo figlie nella parte inferiore della pagina "Generale".<br/>
            /// L'oggetto di callback dovrebbe anche contenere una classe IObjectWithSite per ricevere un puntatore all'interfaccia IPrintDialogServices.<br/><br/>
            /// Se non è necessaria nessuna informazione di callback, impostare a <see cref="IntPtr.Zero"/> questo campo.</remarks>
            public IntPtr CallbackObjectPointer;
            /// <summary>
            /// Numero di handle presenti nell'array puntato da <see cref="PropertyPageHandles"/>.
            /// </summary>
            public DWORD PropertyPagesCount;
            /// <summary>
            /// Array di handle a pagine di proprietà da aggiungere alla finestra di dialogo "Stampa".
            /// </summary>
            /// <remarks>Alla chiusura della finestra di dialogo tutti gli handle nell'array non sono più validi.<br/>
            /// Se <see cref="PropertyPagesCount"/> è 0, questo campo dovrebbe essere nullo.</remarks>
            public IntPtr PropertyPageHandles;
            /// <summary>
            /// La pagine di proprietà che deve essere inizialmente visualizzata.
            /// </summary>
            /// <remarks>Per visualizzare la pagina "Generale" specificare <see cref="CommonDialogBoxesCostants.START_PAGE_GENERAL"/>, altrimenti specificare l'indica su base 0 nell'array puntato da <see cref="PropertyPageHandles"/>.</remarks>
            public DWORD InitialPropertyPageIndex;
            /// <summary>
            /// Risultato della finestra di dialogo.
            /// </summary>
            /// <remarks>In input, questo membro deve avere valore 0, in output, questo campo è valido solo se l'operazione è riuscita.</remarks>
            public PrintDialogResult DialogResult;
        }

        /// <summary>
        /// Rappresenta un insieme di pagine di un lavoro di stampa.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct PRINTPAGERANGE
        {
            /// <summary>
            /// Prima pagina dell'insieme.
            /// </summary>
            public DWORD RangeFirstPage;
            /// <summary>
            /// Ultima pagina dell'insieme.
            /// </summary>
            public DWORD RangeLastPage;
        }
    }
}