using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Icons.IconStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationStructures;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration
{
    internal static class ConfigurationEnumerations
    {
        /// <summary>
        /// Comportamento dopo l'impostazione di un parametro di sistema.
        /// </summary>
        [Flags]
        internal enum SystemParameterUserProfileUpdateOptions : uint
        {
            /// <summary>
            /// Nessuna azione.
            /// </summary>
            NoAction,
            /// <summary>
            /// Scrive il nuovo parametro di sistema nel profilo utente.
            /// </summary>
            UpdateIniFile = 0x0001,
            /// <summary>
            /// Invia il messaggio <see cref="WindowsAndMessages.Messages.WM_SETTINGCHANGE"/> dopo aver aggiornato il profilo utente.
            /// </summary>
            SendChange = 0x0002,
            /// <summary>
            /// Stesso comportamento di <see cref="SendChange"/>.
            /// </summary>
            SendWinIniChange = SendChange
        }
        #region System Parameters Enumerations
        /// <summary>
        /// Parametri di accessibilità del sistema.
        /// </summary>
        internal enum SystemParametersAccessibility : uint
        {
            #region Get Data Values
            /// <summary>
            /// Recupera informazioni sul periodo di timeout associato con le funzionalità di accessibilità.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="FILTERKEYS"/>.<br/>
            /// Il campo <see cref="FILTERKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_GETACCESSTIMEOUT = 0x0003C,
            /// <summary>
            /// Determina se le descrizioni audio sono abilitate o disabilitate.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="AUDIODESCRIPTION"/>.<br/>
            /// Il campo <see cref="AUDIODESCRIPTION.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_GETAUDIODESCRIPTION = 0x0074,
            /// <summary>
            /// Determina se le animazioni sono abilitate o disabilitate.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETCLIENTAREAANIMATION = 0x1042,
            /// <summary>
            /// Determina se il contenuto sovrapposto è abilitato o disabilitato.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETDISABLEOVERLAPPEDCONTENT = 0x1040,
            /// <summary>
            /// Recupera informazioni sulla funzionalità Filtro tasti.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="FILTERKEYS"/>.<br/>
            /// Il campo <see cref="FILTERKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_GETFILTERKEYS = 0x0032,
            /// <summary>
            /// Recupera l'altezza, in pixel, degli angoli superiore e inferiore del rettangolo di focus.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a un valore di tipo uint.</remarks>
            SPI_GETFOCUSBORDERHEIGHT = 0x2010,
            /// <summary>
            /// Recupera la larghezza, in pixel, degli angoli sinistro e destro del rettangolo di focus.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a un valore di tipo uint.</remarks>
            SPI_GETFOCUSBORDERWIDTH = 0x200E,
            /// <summary>
            /// Recupera informazioni sulla funzionalità di accessibilità Alto Contrasto.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="HIGHCONTRAST"/>.<br/>
            /// Il campo <see cref="HIGHCONTRAST.Size"/> e il paramtro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_GETHIGHCONTRAST = 0x0042,
            /// <summary>
            /// Recupera il tempo durante il quale le notifiche a comparsa dovrebbero essere visualizzate, in secondi.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a un valore <see cref="ULONG"/>.</remarks>
            SPI_GETMESSAGEDURATION = 0x2016,
            /// <summary>
            /// Recupera lo stato della funzionalità di blocco del tasto del mouse.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a un valore di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETMOUSECLICKLOCK = 0x101E,
            /// <summary>
            /// Recupera il tempo, in millisecondi, prima che il tasto del mouse sia bloccato.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETMOUSECLICKLOCKTIME = 0x2008,
            /// <summary>
            /// Recupera informazioni sulla funzionalità MouseKeys.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="MOUSEKEYS"/>.<br/>
            /// Il campo <see cref="MOUSEKEYS.Size"/> e il parametro uiParam deve essere impostato alla dimensione della struttura.</remarks>
            SPI_GETMOUSEKEYS = 0x0036,
            /// <summary>
            /// Recupera lo stato della funzionalità Mouse Sonar.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETMOUSESONAR = 0x101C,
            /// <summary>
            /// Recupera lo stato della funzionalità Mouse Vanish.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETMOUSEVANISH = 0x1020,
            /// <summary>
            /// Determina se un'utilità di lettura schermo è in esecuzione.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETSCREENREADER = 0x0046,
            /// <summary>
            /// Determina se i suoni vengono visualizzati a schermo.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>.</remarks>
            SPI_GETSHOWSOUNDS = 0x0038,
            /// <summary>
            /// Recupera informazioni sulla funzionalità SoundSentry.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="SOUNDSENTRY"/>.<br/>
            /// Il campo <see cref="SOUNDSENTRY.Size"/> e il parametro uiParam deve essere impostato alla dimensione della struttura.</remarks>
            SPI_GETSOUNDSENTRY = 0x0040,
            /// <summary>
            /// Recupera informazioni sulla funzionalità Tasti permanenti.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="STICKYKEYS"/>.<br/>
            /// Il campo <see cref="STICKYKEYS.Size"/> e il paramtro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_GETSTICKYKEYS = 0x003A,
            /// <summary>
            /// Recupera informazioni sulla funzionalità ToggleKeys.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="TOGGLEKEYS"/>.<br/>
            /// Il campo <see cref="TOGGLEKEYS.Size"/> e il paramtro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_GETTOGGLEKEYS = 0x0034,
            #endregion
            #region Set Data Values
            /// <summary>
            /// Imposta il tempo di timeout delle funzionalità di accessibilità.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="FILTERKEYS"/> con i nuovi parametri.<br/>
            /// Il campo <see cref="FILTERKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETACCESSTIMEOUT = 0x003D,
            /// <summary>
            /// Attiva o disattiva le descrizioni audio.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="AUDIODESCRIPTION"/> con i nuovi parametri.<br/>
            /// Il campo <see cref="AUDIODESCRIPTION.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETAUDIODESCRIPTION = 0x0075,
            /// <summary>
            /// Attiva o disattiva le animazioni.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una variabile di tipo <see cref="BOOL"/>, true per abilitare le animazioni, false per disabilitarle.</remarks>
            SPI_SETCLIENTAREAANIMATION = 0x1043,
            /// <summary>
            /// Attiva o disattiva il contenuto sovrapposto.
            /// </summary>
            /// <remarks>Il parametro pvParam deve ountare a una variabile di tipo <see cref="BOOL"/>, true per abilitare il contenuto sovrapposto, false per disabilitarlo.</remarks>
            SPI_SETDISABLEOVERLAPPEDCONTENT = 0x1041,
            /// <summary>
            /// Imposta i parametri per la funzionalità Filtro tasti.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="FILTERKEYS"/> con i nuovi parametri.<br/>
            /// Il campo <see cref="FILTERKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETFILTERKEYS = 0x0033,
            /// <summary>
            /// Imposta l'altezza dei bordi superiore e inferiore del rettagolo di focus.
            /// </summary>
            /// <remarks>Il nuovo valore deve essere specificato nel parametro pvParam.</remarks>
            SPI_SETFOCUSBORDERHEIGHT = 0x2011,
            /// <summary>
            /// Imposta l'altezza dei bordi destro e sinistro del rettangolo di focus.
            /// </summary>
            /// <remarks>Il nuovo valore deve essere specificato nel parametro pvParam.</remarks>
            SPI_SETFOCUSBORDERWIDTH = 0x200F,
            /// <summary>
            /// Imposta i parametri per la funzionalità Alto Contrasto.
            /// </summary>
            /// <remarks>Il parametro pvParam deve ountare a una struttura <see cref="HIGHCONTRAST"/>.<br/>
            /// Il campo <see cref="HIGHCONTRAST.Size"/> e il parametro uiParam deve essere impostato alla dimensione della struttura.</remarks>
            SPI_SETHIGHCONTRAST = 0x0043,
            /// <summary>
            /// Imposta il tempo di visualizzazione delle notifiche a comparsa, in secondi.
            /// </summary>
            /// <remarks>Il parametro pvParam specifica il tempo di visualizzazione.</remarks>
            SPI_SETMESSAGEDURATION = 0x2017,
            /// <summary>
            /// Attiva o disattiva la funzionalità di accessibilità Mouse ClickLock.
            /// </summary>
            /// <remarks>Il parametro pvParam specifica true per attivarla, false per disattivarla.<br/>
            /// La funzionalità è disattivata di default.</remarks>
            SPI_SETMOUSECLICKLOCK = 0x101F,
            /// <summary>
            /// Imposta il tempo che deve passare prima che il tasto primario del mouse sia bloccato.
            /// </summary>
            /// <remarks>Il parametro uiParam dovrebbe essere impostato a 0, il parametro pvParam punta a un valore <see cref="DWORD"/> che specifica il tempo, in millisecondi.<br/>
            /// Il valore predefinito è 1200.</remarks>
            SPI_SETMOUSECLICKLOCKTIME = 0x2009,
            /// <summary>
            /// Imposta i parametri della funzionalità MouseKeys.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="MOUSEKEYS"/>.<br/>
            /// Il campo <see cref="MOUSEKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETMOUSEKEYS = 0x0037,
            /// <summary>
            /// Attiva o disattiva la funzionalità Mouse Sonar.
            /// </summary>
            /// <remarks>Il parametro pvParam specifica true per attivarla, false per disattivarla.<br/>
            /// La funzionalità è disattivata di default.</remarks>
            SPI_SETMOUSESONAR = 0x101D,
            /// <summary>
            /// Attiva o disattiva la funzionalità Mouse Vanish.
            /// </summary>
            /// <remarks>Il parametro pvParam specifica true per attivarla, false per disattivarla.<br/>
            /// La funzionalità è disattivata di default.</remarks>
            SPI_SETMOUSEVANISH = 0x1021,
            /// <summary>
            /// Determina se un'utilità di lettura schermo è in esecuzione.
            /// </summary>
            /// <remarks>Il parametro uiParam specifica true quando attivo, false in caso contrario.</remarks>
            SPI_SETSCREENREADER = 0x0047,
            /// <summary>
            /// Attiva o disattiva la funzionalità ShowSounds.
            /// </summary>
            /// <remarks>Il parametro uiParam specifica true quando attiva, false in caso contrario.</remarks>
            SPI_SETSHOWSOUNDS = 0x0039,
            /// <summary>
            /// Imposta i parametri per la funzionalità SoundSentry.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="SOUNDSENTRY"/>.<br/>
            /// Il campo <see cref="SOUNDSENTRY.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETSOUNDSENTRY = 0x0041,
            /// <summary>
            /// Imposta i parametri per la funzionalità Tasti permanenti.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="STICKYKEYS"/>.<br/>
            /// Il campo <see cref="STICKYKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETSTICKYKEYS = 0x003B,
            /// <summary>
            /// Imposta i parametri per la funzionalità ToggleKeys.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="TOGGLEKEYS"/>.<br/>
            /// Il campo <see cref="TOGGLEKEYS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura.</remarks>
            SPI_SETTOGGLEKEYS = 0x0035
            #endregion
        }

        /// <summary>
        /// Parametri relativi alle icone del sistema.
        /// </summary>
        internal enum SystemParametersIcons : uint
        {
            /// <summary>
            /// Recupera le metriche associate alle icone.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a una struttura <see cref="ICONMETRICS"/>, il campo <see cref="ICONMETRICS.Size"/> e il parametro uiParam devono essere impostati alla dimensione della struttura, in bytes.</remarks>
            SPI_GETICONMETRICS = 0x002D,
            /// <summary>
            /// Recupera le informazioni sul font logico per il font attuale del titolo delle icone.
            /// </summary>
            /// <remarks>Il parametro uiParam specifica la dimensione della struttura <see cref="LOGFONT"/>, il parametro pvParam deve puntare ad essa.</remarks>
            SPI_GETICONTITLELOGFONT = 0x001F,
            /// <summary>
            /// Determina se il ritorno a capo automatico dei titoli delle icone è abilitato.
            /// </summary>
            /// <remarks>Il parametro pvParam deve puntare a un valore di tipo <see cref="BOOL"/>, true se il ritorno a capo automatico è abilitato, false altrimenti.</remarks>
            SPI_GETICONTITLEWRAP = 0x0019,
            /// <summary>
            /// Recupera o imposta la larghezza, in pixel, della cella dell'icona.
            /// </summary>
            /// <remarks>Per impostare il valore il parametro uiParam deve esse impostato al nuvo valore, pvParam deve essere <see cref="IntPtr.Zero"/>.<br/>
            /// Il valore non può essere minore di quello restituito da <see cref="GetSystemMetrics"/> per la metrica <see cref="SystemMetricValue.SM_CXICON"/>.<br/><br/>
            /// Per recuperare questo valore, pvParam deve puntare a un intero.</remarks>
            SPI_ICONHORIZONTALSPACING = 0x000D,
            /// <summary>
            /// Recupera o imposta l'altezza, in pixel, della cella dell'icona.
            /// </summary>
            /// <remarks>Per impostare il valore il parametro uiParam deve esse impostato al nuvo valore, pvParam deve essere <see cref="IntPtr.Zero"/>.<br/>
            /// Il valore non può essere minore di quello restituito da <see cref="GetSystemMetrics"/> per la metrica <see cref="SystemMetricValue.SM_CYICON"/>.<br/><br/>
            /// Per recuperare questo valore, pvParam deve puntare a un intero.</remarks>
            SPI_ICONVERTICALSPACING = 0x0018,
            /// <summary>
            /// Imposta le metriche associate con le icone.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="ICONMETRICS"/> che contiene i nuovi parametri.<br/><br/>
            /// uiParam e il campo <see cref="ICONMETRICS.Size"/> devono essere impostato alla dimensione, in bytes, della struttura.</remarks>
            SPI_SETICONMETRICS = 0x002E,
            /// <summary>
            /// Ricarica le icone di sistema.
            /// </summary>
            /// <remarks>uiParam deve essere impostato a 0, pvParam deve essere impostato a <see cref="IntPtr.Zero"/>.</remarks>
            SPI_SETICONS = 0x0058,
            /// <summary>
            /// Imposta il font da usare per i titoli delle icone.
            /// </summary>
            /// <remarks>uiParam deve specificare la dimensione di una struttura <see cref="LOGFONT"/>, pvParam deve puntare a tale struttura.</remarks>
            SPI_SETICONTITLELOGFONT = 0x0022,
            /// <summary>
            /// Attiva o disattiva il ritorno a capo automatico dei titoli delle icone.
            /// </summary>
            /// <remarks>uiParam deve specificare true per attivarlo, false per disattivarlo.</remarks>
            SPI_SETICONTITLEWRAP = 0x001A
        }

        /// <summary>
        /// Parametri di sistema relativi alle finestre.
        /// </summary>
        internal enum SystemParametersWindows : uint
        {
            #region Get Data Values
            /// <summary>
            /// Determina se il tracciamento della finestra attiva è abilitato.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true indica che il tracciamento è attivo, false altrimenti.</remarks>
            SPI_GETACTIVEWINDOWTRACKING = 0x1000,
            /// <summary>
            /// Determina se le finestre attivate tramite il tracciamento della finestra attiva saranno portate sopra tutte le altre.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se la funzionalità è attiva, false altrimenti.</remarks>
            SPI_GETACTIVEWNDTRKZORDER = 0x100C,
            /// <summary>
            /// Recupera il ritardo nel rilevamento della finestra attiva, in millisecondi.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="DWORD"/>.</remarks>
            SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,
            /// <summary>
            /// Recupera le informazioni sulle animazioni associate con le azioni utente.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="ANIMATIONINFO"/>, il campo <see cref="ANIMATIONINFO.Size"/> e uiParam devono essere impostati alla dimensione, in byte, della struttura.</remarks>
            SPI_GETANIMATION = 0x0048,
            /// <summary>
            /// Recupera il moltiplicatore che determina la larghezza del bordo di ridimensionamento di una finestra.
            /// </summary>
            /// <remarks>pvParam deve puntare a un intero.</remarks>
            SPI_GETBORDER = 0x0005,
            /// <summary>
            /// Recupera la dimensione del cursore lampeggiante in controlli di modifica, in pixel.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="DWORD"/>.</remarks>
            SPI_GETCARETWIDTH = 0x2006,
            /// <summary>
            /// Determina se una finestra viene agganciata quando viene spostata verso il bordo superiore, sinistro o a destro del monitor o di un array di monitor.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se il comportamento è abilitato, false altrimenti.</remarks>
            SPI_GETDOCKMOVING = 0x0090,
            /// <summary>
            /// Determina se una finestra ingrandita viene ripristinata quando la sua barra del titolo viene trascinata.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se il comportamento è abilitato, false altrimenti.</remarks>
            SPI_GETDRAGFROMMAXIMIZE = 0x008C,
            /// <summary>
            /// Determina se il trascinamento di finestre intere è abilitato.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se il trascinamento di finestre intere è abilitato, false altrimenti.</remarks>
            SPI_GETDRAGFULLWINDOWS = 0x0026,
            /// <summary>
            /// Recupera il numero di volte che il pulsante di una finestra sulla la barra delle applicazioni lampeggia quando la richiesta della finestra di essere portata in primo piano non viene esaudita.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="DWORD"/>.</remarks>
            SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,
            /// <summary>
            /// Recupera il tempo, in millisecondi, dopo l'input dell'utente, durante il quale il sistema non permette alle applicazioni di essere messe in primo piano.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="DWORD"/>.</remarks>
            SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,
            /// <summary>
            /// Recupera le metriche associate con le finestre minimizzate.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="MINIMIZEDMETRICS"/>, uiParam e il campo <see cref="MINIMIZEDMETRICS.Size"/> devono essere impostati alla dimensione, in byte, della struttura.</remarks>
            SPI_GETMINIMIZEDMETRICS = 0x002B,
            /// <summary>
            /// Recupera la soglia, in pixel, dove il comportamento di aggancio viene attivato dal trascinamento di una finestra al bordo del monitor o dell'array di monitor.
            /// </summary>
            /// <remarks>La soglia di default è 1.<br/><br/>
            /// pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETMOUSEDOCKTHRESHOLD = 0x007E,
            /// <summary>
            /// Recupera la soglia, in pixel, dove il comportamento di sgancio viene attivato dal trascinamento di una finestra dal bordo del monitor o dell'array di monitor verso il centro.
            /// </summary>
            /// <remarks>La sogla di default è 20.<br/><br/>
            /// pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETMOUSEDRAGOUTTHRESHOLD = 0x0084,
            /// <summary>
            /// Recupera la soglia, in pixel, dalla parte superiore di un monitor o di un array di monitor dove una finestra ingrandita verticalmente viene ripristinata quando trascinata con il mouse.
            /// </summary>
            /// <remarks>La soglia di default è 50.<br/><br/>
            /// pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETMOUSESIDEMOVETHRESHOLD = 0x0088,
            /// <summary>
            /// Recupera le metriche associate con l'area non client delle finestre non minimizzate.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="NONCLIENTMETRICS"/>, il campo <see cref="NONCLIENTMETRICS.Size"/> e uiParam devono essere impostati alla dimensione, in byte, della struttura.</remarks>
            SPI_GETNONCLIENTMETRICS = 0x0029,
            /// <summary>
            /// Recupera la soglia, in pixel, dove il comportamento di aggancio viene attivato dal trascinamento di una finestra al bordo del monitor o dell'array di monitor usando una penna.
            /// </summary>
            /// <remarks>La soglia di default è 30.<br/><br/>
            /// pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETPENDOCKTHRESHOLD = 0x0080,
            /// <summary>
            /// Recupera la soglia, in pixel, dove il comportamento di sgancio viene attivato dal trascinamento di una finestra dal bordo del monitor o dell'array di monitor verso il centro usando una penna.
            /// </summary>
            /// <remarks>La sogla di default è 30.<br/><br/>
            /// pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETPENDRAGOUTTHRESHOLD = 0x0086,
            /// <summary>
            /// Recupera la soglia, in pixel, dalla parte superiore di un monitor o di un array di monitor dove una finestra ingrandita verticalmente viene ripristinata quando trascinata usando una penna.
            /// </summary>
            /// <remarks>La soglia di default è 50.<br/><br/>
            /// pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_GETPENSIDEMOVETHRESHOLD = 0x008A,
            /// <summary>
            /// Determina se la finestra di stato IME è visibile (per utente).
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se la finestra è visibile, false altrimenti.</remarks>
            SPI_GETSHOWIMEUI = 0x006E,
            /// <summary>
            /// Determina se una finestra viene verticalmente ingrandita quando viene ridimensionata fino a toccare la parte superiore del monitor o del'array di monitor.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se il comportamento è abilitato, false altrimenti.</remarks>
            SPI_GETSNAPSIZING = 0x008E,
            /// <summary>
            /// Determina se l'ordinamento delle finestre è attivo.
            /// </summary>
            /// <remarks>pvParam deve puntare a una variabile <see cref="BOOL"/>, true se l'ordinamento è attivato, false altrimenti.<br/><br/>
            /// L'ordinamento delle finestre riduce le interazioni eseguite con il mouse, una penna o tramite tocco necessari per spostare le finestre top-level semplificando il comportamento predefinito di una finestra quando viene trascinata o ridimensionata.<br/><br/>
            /// I seguenti parametri recuperare le impostazioni individuali dell'ordinamento delle finestre:<br/><br/>
            /// <see cref="SPI_GETDOCKMOVING"/><br/>
            /// <see cref="SPI_GETMOUSEDOCKTHRESHOLD"/><br/>
            /// <see cref="SPI_GETMOUSEDRAGOUTTHRESHOLD"/><br/>
            /// <see cref="SPI_GETMOUSESIDEMOVETHRESHOLD"/><br/>
            /// <see cref="SPI_GETPENDOCKTHRESHOLD"/><br/>
            /// <see cref="SPI_GETPENDRAGOUTTHRESHOLD"/><br/>
            /// <see cref="SPI_GETPENSIDEMOVETHRESHOLD"/><br/>
            /// <see cref="SPI_GETSNAPSIZING"/></remarks>
            SPI_GETWINARRANGING = 0x0082,
            #endregion
            #region Set Data Values
            /// <summary>
            /// Imposta il tracciamento della finestra attiva.
            /// </summary>
            /// <remarks>pvParam deve avere valore true per abilitare il comportamento, false per disabilitarlo.</remarks>
            SPI_SETACTIVEWINDOWTRACKING = 0x1001,
            /// <summary>
            /// Imposta se le finestre attivate tramite il tracciamento della finestra attiva devono essere portate in primo piano.
            /// </summary>
            /// <remarks>pvParam deve avere valore true per abilitare il comportamento, false per disabilitarlo.</remarks>
            SPI_SETACTIVEWNDTRKZORDER = 0x100D,
            /// <summary>
            /// Imposta il ritardo per il tracciamento della finestra attiva.
            /// </summary>
            /// <remarks>pvParam deve essere impostato al nuovo valore, deve essere espresso in millisecondi.</remarks>
            SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,
            /// <summary>
            /// Imposta le animazioni associate con le azioni utente.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="ANIMATIONINFO"/>, il campo <see cref="ANIMATIONINFO.Size"/> e uiParam devono essere impostati alla dimensione, in byte, della struttura.</remarks>
            SPI_SETANIMATION = 0x0049,
            /// <summary>
            /// Imposta il moltiplicatore da applicare alla larghezza del bordo di ridimensionamento di una finestra.
            /// </summary>
            /// <remarks>uiParam deve essere impostato al nuovo valore.</remarks>
            SPI_SETBORDER = 0x0006,
            /// <summary>
            /// Imposta la larghezza del cursore lampeggiante nei controlli di modifica.
            /// </summary>
            /// <remarks>pvParam deve essere impostato al nuovo valore, in pixel, il valore minimo è 1.</remarks>
            SPI_SETCARETWIDTH = 0x2007,
            /// <summary>
            /// Imposta se una finestra verrà agganciata quando spostata sulle posizioni di aggancio superiori, sinistre e destre sul monitor o sull'array di monitor.
            /// </summary>
            /// <remarks>pvParam deve essere true per abilitare il comportamento, false altrimenti.</remarks>
            SPI_SETDOCKMOVING = 0x0091,
            /// <summary>
            /// Imposta se una finestra ingrandita verrà ripristinata quando la sua barra del titolo viene trascinata.
            /// </summary>
            /// <remarks>pvParam deve essere true per abilitare il comportamento, false altrimenti.</remarks>
            SPI_SETDRAGFROMMAXIMIZE = 0x008D,
            /// <summary>
            /// Imposta se il trascinamento di finestre intere è permesso.
            /// </summary>
            /// <remarks>uiParam deve essere impostato al nuovo valore, true per permettere il trascinamento di finestre intere, false altrimenti.</remarks>
            SPI_SETDRAGFULLWINDOWS = 0x0025,
            /// <summary>
            /// Imposta l'altezza, in pixel, del rettangolo usato per determinare l'inizio di un'operazione di trascinamento.
            /// </summary>
            /// <remarks>uiParam deve essere impostato al nuovo valore.</remarks>
            SPI_SETDRAGHEIGHT = 0x004D,
            /// <summary>
            /// Imposta la larghezza, in pixel, del rettangolo usato per determinare l'inizio di un'operazione di trascinamento.
            /// </summary>
            /// <remarks>uiParam deve essere impostato al nuovo valore.</remarks>
            SPI_SETDRAGWIDTH = 0x004C,
            /// <summary>
            /// Imposta il numero di volte che il pulsante di una finestra sulla barra delle applicazioni lampeggia quando una richiesta da parte della finestra di essere portata in primo piano è stata rifiutata.
            /// </summary>
            /// <remarks>pvParam deve essere impostato al nuovo valore.</remarks>
            SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,
            /// <summary>
            /// Imposta il tempo, in millisecondi, durante il quale il sistema non permette alle applicazioni di portarsi in primo piano.
            /// </summary>
            /// <remarks>pvParam deve essere impostato al nuovo valore.<br/><br/>
            /// Il thread chiamante deve poter cambiare la finestra in primo piano.</remarks>
            SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,
            /// <summary>
            /// Imposta le metriche associate alle finestre minimizzate.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="MINIMIZEDMETRICS"/>, il campo <see cref="MINIMIZEDMETRICS.Size"/> e uiParam devono essere impostati alla dimensione, in byte, della struttura.</remarks>
            SPI_SETMINIMIZEDMETRICS = 0x002C,
            /// <summary>
            /// Imposta la soglia, in pixel, dove il comportamento di aggancio viene attivato usando il mouse per trascinare una finestra al bordo del monitor o dell'array di monitor.
            /// </summary>
            /// <remarks>La soglia predefinita è 1, pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_SETMOUSEDOCKTHRESHOLD = 0x007F,
            /// <summary>
            /// Imposta la soglia, in pixel, dove il comportamento di sgancio viene attivato usando il mouse per trascinare una finestra dal bordo del monitor o dell'array di monitor verso il centro.
            /// </summary>
            /// <remarks>La soglia predefinita è 20, pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_SETMOUSEDRAGOUTTHRESHOLD = 0x0085,
            /// <summary>
            /// Imposta la soglia, in pixel, dalla parte superiore del monitor dove una finestra verticalmente ingrandita deve essere ripristinata quando trascinata con il mouse.
            /// </summary>
            /// <remarks>La soglia predefinita è 50, pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_SETMOUSESIDEMOVETHRESHOLD = 0x0089,
            /// <summary>
            /// Imposta le metriche associate all'area non client delle finestre non miminizzate.
            /// </summary>
            /// <remarks>pvParam deve puntare a una struttura <see cref="NONCLIENTMETRICS"/>, il campo <see cref="NONCLIENTMETRICS.Size"/> e uiParam devono essere impostati alla dimensione della struttura, in byte.<br/><br/>
            /// Il campo <see cref="LOGFONT.Height"/> di tutte le strutture <see cref="LOGFONT"/> deve essere negativo.</remarks>
            SPI_SETNONCLIENTMETRICS = 0x002A,
            /// <summary>
            /// Imposta la soglia, in pixel, dove il comportamento di aggancio viene attivato usando una penna per trascinare una finestra al bordo del monitor o dell'array di monitor.
            /// </summary>
            /// <remarks>La soglia predefinita è 30, pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_SETPENDOCKTHRESHOLD = 0x0081,
            /// <summary>
            /// Imposta la soglia, in pixel, dove il comportamento di sgancio viene attivato usando una penna per trascinare una finestra dal bordo del monitor o dell'array di monitor verso il centro.
            /// </summary>
            /// <remarks>La soglia predefinita è 30, pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_SETPENDRAGOUTTHRESHOLD = 0x0087,
            /// <summary>
            /// Imposta la soglia, in pixel, dalla parte superiore del monitor dove una finestra verticalmente ingrandita deve essere ripristinata quando trascinata con una penna.
            /// </summary>
            /// <remarks>La soglia predefinita è 50, pvParam deve puntare a un valore <see cref="DWORD"/>.</remarks>
            SPI_SETPENSIDEMOVETHRESHOLD = 0x008B,
            /// <summary>
            /// Imposta se la finestra di stato IME è visibile, l'impostazione è valida per utente.
            /// </summary>
            /// <remarks>uiParam deve essere true rendere la finestra visibile, false altrimenti.</remarks>
            SPI_SETSHOWIMEUI = 0x006F,
            /// <summary>
            /// Imposta se una finestra viene verticalmente ingrandita quando viene ridimensionata fino alla parte superiore o inferiore del monitor.
            /// </summary>
            /// <remarks>pvParam deve essere impostato a true per abilitare il comportamento, false per disabilitarlo.</remarks>
            SPI_SETSNAPSIZING = 0x008F,
            /// <summary>
            /// Imposta se l'ordinamento dell finestre è attivo.
            /// </summary>
            /// <remarks>pvParam deve essere impostato a true per abilitare l'ordinamento, false per disabilitarlo.<br/><br/>
            /// L'ordinamento delle finestre riduce le interazioni eseguite con il mouse, una penna o tramite tocco necessari per spostare le finestre top-level semplificando il comportamento predefinito di una finestra quando viene trascinata o ridimensionata.<br/><br/>
            /// I seguenti parametri recuperare le impostazioni individuali dell'ordinamento delle finestre:<br/><br/>
            /// <see cref="SPI_GETDOCKMOVING"/><br/>
            /// <see cref="SPI_GETMOUSEDOCKTHRESHOLD"/><br/>
            /// <see cref="SPI_GETMOUSEDRAGOUTTHRESHOLD"/><br/>
            /// <see cref="SPI_GETMOUSESIDEMOVETHRESHOLD"/><br/>
            /// <see cref="SPI_GETPENDOCKTHRESHOLD"/><br/>
            /// <see cref="SPI_GETPENDRAGOUTTHRESHOLD"/><br/>
            /// <see cref="SPI_GETPENSIDEMOVETHRESHOLD"/><br/>
            /// <see cref="SPI_GETSNAPSIZING"/></remarks>
            SPI_SETWINARRAGING = 0x0083
            #endregion
        }
        #endregion

        /// <summary>
        /// Metrica di sistema.
        /// </summary>
        internal enum SystemMetricValue
        {
            /// <summary>
            /// Specifica come il sistema distribuisce le finestre minimizzate.
            /// </summary>
            /// <remarks></remarks>
            SM_ARRANGE = 56,
            /// <summary>
            /// Indica come è stato avviato il sistema.
            /// </summary>
            /// <remarks>0: avvio normale<br/>
            /// 1: avvio sicuro<br/>
            /// 2: avvio sicuro tramite rete</remarks>
            SM_CLEANBOOT = 67,
            /// <summary>
            /// Numero di monitor su un desktop.
            /// </summary>
            /// <remarks>Questa opzione conta soltanto i monitor visibili.</remarks>
            SM_CMONITORS = 80,
            /// <summary>
            /// Numero di pulsanti del mouse.
            /// </summary>
            /// <remarks>Questa opzione restitusce 0 se non è installato un mouse.</remarks>
            SM_CMOUSEBUTTONS = 43,
            /// <summary>
            /// Stato del laptop.
            /// </summary>
            /// <remarks>0 per modalità tablet, diverso da 0 in altri casi.<br/><br/>
            /// Questa informazioni non si applica ai PC desktop.</remarks>
            SM_CONVERTIBLESLATEMODE = 0x2003,
            /// <summary>
            /// Larghezza del bordo della finestra, in pixel.
            /// </summary>
            SM_CXBORDER = 5,
            /// <summary>
            /// Larghezza del cursore, in pixel.
            /// </summary>
            /// <remarks>Il sistema non può creare cursori di altre dimensioni.</remarks>
            SM_CXCURSOR = 13,
            /// <summary>
            /// Identico a <see cref="SM_CXFIXEDFRAME"/>.
            /// </summary>
            SM_CXDLGFRAME = 7,
            /// <summary>
            /// Larghezza del rettangolo attorno alla posizione del primo click in una sequenza di doppio click, in pixel.
            /// </summary>
            SM_CXDOUBLECLK = 36,
            /// <summary>
            /// Numero di pixel, su entrambe le parti di un punto di pressione del tasto del mouse, dove il mouse può muoversi prima di iniziare l'operazione di trascinamento.
            /// </summary>
            SM_CXDRAG = 68,
            /// <summary>
            /// Larghezza di un bordo 3D, in pixel.
            /// </summary>
            SM_CXEDGE = 45,
            /// <summary>
            /// Spessore della cornice attorno al perimetro di una finestra che ha una barra del titolo ma non è ridimensionabile, in pixel.
            /// </summary>
            /// <remarks>Questo valore restituisce l'altezza del bordo orizzontale.</remarks>
            SM_CXFIXEDFRAME = SM_CXDLGFRAME,
            /// <summary>
            /// Larghezza degli angoli sinistro e destro del rettangolo di focus, in pixel.
            /// </summary>
            SM_CXFOCUSBORDER = 83,
            /// <summary>
            /// Indentico a <see cref="SM_CXSIZEFRAME"/>.
            /// </summary>
            SM_CXFRAME = 32,
            /// <summary>
            /// Larghezza dell'area client per una finestra a schermo intero sul monitor primario, in pixel.
            /// </summary>
            SM_CXFULLSCREEN = 16,
            /// <summary>
            /// Larghezza del bitmap della freccia su una barra di scorrimento orizzontale, in pixel.
            /// </summary>
            SM_CXHSCROLL = 21,
            /// <summary>
            /// Larghezza del thumb box in una barra di scorrimento orizzontale, in pixel.
            /// </summary>
            SM_CXHTHUMB = 10,
            /// <summary>
            /// Larghezza di default di un'icona, in pixel.
            /// </summary>
            SM_CXICON = 11,
            /// <summary>
            /// Larghezza della cella per oggetti nella vista grande dell'icona, in pixel.
            /// </summary>
            SM_CXICONSPACING = 38,
            /// <summary>
            /// Larghezza, di default, in pixel, della finestra top-level ingrandità sul monitor primario.
            /// </summary>
            SM_CXMAXIMIZED = 61,
            /// <summary>
            /// Larghezza massima di default di una finestra che ha una barra del titolo e un bordo di ridimensionamento, in pixel.
            /// </summary>
            /// <remarks>Questo valore si riferisce al desktop intero.</remarks>
            SM_CXMAXTRACK = 59,
            /// <summary>
            /// Larghezza del bitmap di default della spunta di un menù, in pixel.
            /// </summary>
            SM_CXMENUCHECK = 71,
            /// <summary>
            /// Larghezza dei pulsanti di una barra dei menù, in pixel.
            /// </summary>
            SM_CXMENUSIZE = 54,
            /// <summary>
            /// Larghezza minima di una finestra, in pixel.
            /// </summary>
            SM_CXMIN = 28,
            /// <summary>
            /// Larghezza di una finestra minimizzata, in pixel.
            /// </summary>
            SM_CXMINIMIZED = 57,
            /// <summary>
            /// Larghezza della cella della griglia per una finestra minimizzata, in pixel.
            /// </summary>
            SM_CXMINSPACING = 47,
            /// <summary>
            /// Larghezza minima di una finestra alla quale l'utente può ridurre una finestra trascinando il bordo, in pixel.
            /// </summary>
            SM_CXMINTRACK = 34,
            /// <summary>
            /// Quantità di riempimento del bordo per finestre con barra del titolo, in pixel.
            /// </summary>
            SM_CXPADDEDBORDER = 92,
            /// <summary>
            /// Larghezza dello schermo del monitor primario, in pixel.
            /// </summary>
            SM_CXSCREEN = 0,
            /// <summary>
            /// Larghezza del pulsante in una barra del titolo, in pixel.
            /// </summary>
            SM_CXSIZE = 30,
            /// <summary>
            /// Spessore del bordo di ridimensionamento attorno al perimetro di una finestra ridimensionabile, in pixel.
            /// </summary>
            /// <remarks>Questo valore indica la larghezza del bordo orizzontale.</remarks>
            SM_CXSIZEFRAME = SM_CXFRAME,
            /// <summary>
            /// Larghezza raccomandata di un'icona piccola, in pixel.
            /// </summary>
            SM_CXSMICON = 49,
            /// <summary>
            /// Larghezza dei pulsanti della barra del titolo piccoli, in pixel.
            /// </summary>
            SM_CXSMSIZE = 52,
            /// <summary>
            /// Larghezza dello schermo virtuale, in pixel.
            /// </summary>
            SM_CXVIRTUALSCREEN = 78,
            /// <summary>
            /// Larghezza di una barra di scorrimento verticale, in pixel.
            /// </summary>
            SM_CXVSCROLL = 2,
            /// <summary>
            /// Altezza del bordo di una finestra, in pixel.
            /// </summary>
            SM_CYBORDER = 6,
            /// <summary>
            /// Altezza della barra del titolo, in pixel.
            /// </summary>
            SM_CYCAPTION = 4,
            /// <summary>
            /// Altezza del cursore, in pixel.
            /// </summary>
            /// <remarks>Il sistema non può creare cursori di altre dimensioni.</remarks>
            SM_CYCURSOR = 14,
            /// <summary>
            /// Identico a <see cref="SM_CYFIXEDFRAME"/>.
            /// </summary>
            SM_CYDLGFRAME = 8,
            /// <summary>
            /// Altezza del rettangolo attorno alla posizione del primo click in una sequenza di doppio click.
            /// </summary>
            SM_CYDOUBLECLK = 37,
            /// <summary>
            /// Numero di pixel, sopra e sotto il punto di pressione del tasto del mouse, dove il mouse può muoversi prima di iniziare l'operazione di trascinamento.
            /// </summary>
            SM_CYDRAG = 69,
            /// <summary>
            /// Altezza del bordo 3D, in pixel.
            /// </summary>
            SM_CYEDGE = 46,
            /// <summary>
            /// Spessore della cornice attorno al perimetro di una finestra con barra del titolo ma non ridimensionabile, in pixel.
            /// </summary>
            /// <remarks>Questo valore si riferisce alla larghezza del bordo verticale.</remarks>
            SM_CYFIXEDFRAME = SM_CYDLGFRAME,
            /// <summary>
            /// Altezza degli angoli superiore e inferiore del rettangolo di focus, in pixel.
            /// </summary>
            SM_CYFOCUSBORDER = 84,
            /// <summary>
            /// Identico a <see cref="SM_CYSIZEFRAME"/>.
            /// </summary>
            SM_CYFRAME = 33,
            /// <summary>
            /// Altezza dell'area client di una finestra a schermo intero sul monitor primario, in pixel.
            /// </summary>
            SM_CYFULLSCREEN = 17,
            /// <summary>
            /// Altezza di una barra di scorrimento orizzontale, in pixel.
            /// </summary>
            SM_CYHSCROLL = 3,
            /// <summary>
            /// Altezza di default di un'icona, in pixel.
            /// </summary>
            SM_CYICON = 12,
            /// <summary>
            /// Altezza della griglia di oggetti nella vista grande per l'icona, in pixel.
            /// </summary>
            SM_CYICONSPACING = 39,
            /// <summary>
            /// Altezza della finestra Kanji in basso sullo schermo, in pixel.
            /// </summary>
            /// <remarks>Valore valido solo per versioni del sistema con set di caratteri a doppio byte.</remarks>
            SM_CMKANJIWINDOW = 18,
            /// <summary>
            /// Altezza di default, in pixel, della finestra top-level ingrandita sul monitor primario.
            /// </summary>
            SM_CYMAXIMIZED = 62,
            /// <summary>
            /// Altezza massima di una finestra che ha una barra del titolo e un bordo di rimensionamento, in pixel.
            /// </summary>
            /// <remarks>Questo valore si riferisce all'intero desltop.</remarks>
            SM_CYMAXTRACK = 60,
            /// <summary>
            /// Altezza di un menù a singola linea, in pixel.
            /// </summary>
            SM_CYMENU = 15,
            /// <summary>
            /// Altezza dei default del bitmap della spunta di un menù, in pixel.
            /// </summary>
            SM_CYMENUCHECK = 72,
            /// <summary>
            /// Altezza dei pulsanti di una barra dei menù.
            /// </summary>
            SM_CYMENUSIZE = 55,
            /// <summary>
            /// Altezza minima di una finestra, in pixel.
            /// </summary>
            SM_CYMIN = 29,
            /// <summary>
            /// Altezza delle finestre minimizzate, in pixel.
            /// </summary>
            SM_CYMINIMIZED = 58,
            /// <summary>
            /// Altezza della cella della griglia per una finestra minimizzata, in pixel.
            /// </summary>
            SM_CYMINSPACING = 48,
            /// <summary>
            /// Altezza minima di una finestra quando l'utente la ridimensiona, in pixel.
            /// </summary>
            SM_CYMINRACK = 35,
            /// <summary>
            /// Altezza dello schermo del monitor primario, in pixel.
            /// </summary>
            SM_CYSCREEN = 1,
            /// <summary>
            /// Altezza di un pulsante nella barra del titolo, in pixel.
            /// </summary>
            SM_CYSIZE = 31,
            /// <summary>
            /// Spessore del bordo di ridimensionamento attorno al perimetro di una finestra ridimensionabile, in pixel.
            /// </summary>
            /// <remarks>Questo valore si riferisce all'altezza del bordo verticale.</remarks>
            SM_CYSIZEFRAME = SM_CYFRAME,
            /// <summary>
            /// Altezza di una piccola barra del titolo, in pixel.
            /// </summary>
            SM_CYSMCAPTION = 51,
            /// <summary>
            /// Altezza raccomandata di un'icona piccola, in pixel.
            /// </summary>
            SM_CYSMICON = 50,
            /// <summary>
            /// Altezza di un pulsante piccolo della barra del titolo, in pixel.
            /// </summary>
            SM_CYSMSIZE = 53,
            /// <summary>
            /// Altezza dello schermo virtuale, in pixel.
            /// </summary>
            SM_CYVIRTUALSCREEN = 79,
            /// <summary>
            /// Altezza del bitmap della freccia su una barra di scorrimento verticale, in pixel.
            /// </summary>
            SM_CYVSCROLL = 20,
            /// <summary>
            /// Altezza del thumb box in una barra di scorrimento verticale, in pixel.
            /// </summary>
            SM_CYVTHUMB = 9,
            /// <summary>
            /// true se User32.dll supporta DBCS, false altrimenti.
            /// </summary>
            SM_DBCSENABLED = 42,
            /// <summary>
            /// true se una versione di debug di User.exe è installata, false altrimenti.
            /// </summary>
            SM_DEBUG = 22,
            /// <summary>
            /// true se le funzionalità Input Method Manager/Input Method Editor sono abilitate, false altrimenti.
            /// </summary>
            SM_IMMENABLED = 82,
            /// <summary>
            /// true se ci sono digitizer nel sistema, false altrimenti.
            /// </summary>
            /// <remarks>Se ci sono digitizer nel sistema, questo valore restituisce la somma totale del numero di contatti massimi per ogni digitizer nel sistema.</remarks>
            SM_MAXIMUMTOUCHES = 95,
            /// <summary>
            /// true se i menù dropdown sono allineati a destra con il corrispondente oggetto della barra dei menù, false se sono allineati a sinistra.
            /// </summary>
            SM_MENUDROPALIGNMENT = 40,
            /// <summary>
            /// true se il sistema è abilitato per linguaggi arabi o ebrei, false altrimenti.
            /// </summary>
            SM_MIDEASTENABLED = 74,
            /// <summary>
            /// true se un mouse è installato, false altrimenti.
            /// </summary>
            SM_MOUSEPRESENT = 19,
            /// <summary>
            /// true se il mouse presenta una rotella di scorrimento orizzontale, false altrimenti.
            /// </summary>
            SM_MOUSEHORIZONTALWHEELPRESENT = 75,
            /// <summary>
            /// L'ultimo bit indica se si è connessi a una rete.
            /// </summary>
            /// <remarks>Gli altri bit sono riservati per uso futuro.</remarks>
            SM_NETWORK = 63,
            /// <summary>
            /// true se le estensioni Microsoft Windows for Pen sono installate, false altrimenti.
            /// </summary>
            SM_PENWINDOWS = 41,
            /// <summary>
            /// true se la sessione Terminal Services attuale è controllata da remoto, false altrimenti.
            /// </summary>
            SM_REMOTECONTROL = 0x2001,
            /// <summary>
            /// true se il processo chiamante è associato a una sessione client Terminal Services, false se invece è associato alla console.
            /// </summary>
            SM_REMOTESESSION = 0x1000,
            /// <summary>
            /// true se tutti i monitor hanno lo stesso formato colore, false altrimenti.
            /// </summary>
            SM_SAMEDISPLAYFORMAT = 81,
            /// <summary>
            /// true se l'utente richiede alle applicazioni di presentare informazioni in modo visuale in situazioni dove sarebbero state presentato solo in modo sonoro, false altrimenti.
            /// </summary>
            SM_SHOWSOUNDS = 70,
            /// <summary>
            /// true se la sessione corrente è in corso di spegnimento, false altrimenti.
            /// </summary>
            SM_SHUTTINGDOWN = 0x2000,
            /// <summary>
            /// true se il computer ha un processore lento, false altrimenti.
            /// </summary>
            SM_SLOWMACHINE = 73,
            /// <summary>
            /// true se il significato dei tasti sinistro e destro del mouse sono invertiti, false altrimenti.
            /// </summary>
            SM_SWAPBUTTON = 23,
            /// <summary>
            /// false per modalità non agganciata (undocked), true altrimenti (docked).
            /// </summary>
            SM_SYSTEMDOCKED = 0x2004,
            /// <summary>
            /// Coordinate della parte sinistra dello schermo virtuale.
            /// </summary>
            SM_XVIRTUALSCREEN = 76,
            /// <summary>
            /// Coordinate della parte superiore dello schermo virtuale.
            /// </summary>
            SM_YVIRTUALSCREEN = 77
        }

        /// <summary>
        /// Impostazione di distribuzione delle finestre minimizzate.
        /// </summary>
        [Flags]
        internal enum MinimizedWindowArrangeSettings
        {
            #region Starting Positions
            /// <summary>
            /// Angolo inferiore sinistro dello schermo, default.
            /// </summary>
            ARW_BOTTOMLEFT = 0x0000,
            /// <summary>
            /// Angolo inferiore destro dello schermo.
            /// </summary>
            ARW_BOTTOMRIGHT = 0x0001,
            /// <summary>
            /// Angolo superiore sinistro dello schermo.
            /// </summary>
            ARW_TOPLEFT = 0x0002,
            /// <summary>
            /// Angolo superiore destro dello schermo.
            /// </summary>
            ARW_TOPRIGHT = 0x0003,
            #endregion
            #region Directions
            /// <summary>
            /// Distribuzione orizzontale, da sinistra a destra.
            /// </summary>
            ARW_LEFT = 0x0000,
            /// <summary>
            /// Distribuzione orizzontale, da destra a sinistra.
            /// </summary>
            ARW_RIGHT = ARW_LEFT,
            /// <summary>
            /// Distribuzione verticale, da basso verso alto.
            /// </summary>
            ARW_UP = 0x0004,
            /// <summary>
            /// Distribuzione verticale, da alto verso basso.
            /// </summary>
            ARW_DOWN = ARW_UP,
            /// <summary>
            /// Nasconde le finestre muovendole fuori dall'area visibile dello schermo.
            /// </summary>
            ARW_HIDE = 0x0008
            #endregion
        }
    }
}