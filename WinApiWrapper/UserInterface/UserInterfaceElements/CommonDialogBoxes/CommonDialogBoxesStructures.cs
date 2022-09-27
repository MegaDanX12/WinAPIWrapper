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
    }
}