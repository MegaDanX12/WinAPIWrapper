using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Controls.WindowsControlsStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMEnumerations;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMStructures;

namespace WinApiWrapper.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Funzioni Desktop Window Manager (DWM).
    /// </summary>
    internal static class DWMFunctions
    {
        /// <summary>
        /// Procedura predefinita di DWM per hit test all'interno dell'area non-client di una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che ha ricevuto il messaggio.</param>
        /// <param name="Message">Messaggio.</param>
        /// <param name="wParam">Informazioni addizionali messaggio.</param>
        /// <param name="lParam">Informazioni addizionali messaggio.</param>
        /// <param name="Result">Puntatore a un valore che contiene, al momento del ritorno della funzione, il risultato dell'hit test.</param>
        /// <returns>true se la funzione ha gestito il messaggio, false altrimenti.</returns>
        /// <remarks>Questa funzione deve essere chiamata quando la finestra riceve il messaggio <see cref="WindowsAndMessages.Messages.WM_NCMOUSELEAVE"/>.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmDefWindowProc", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL DwmDefWindowProc(HWND WindowHandle, uint Message, WPARAM wParam, LPARAM lParam, ref LRESULT Result);

        /// <summary>
        /// Notifica DWM di partecipare o meno alla programmazione del servizio Multimedia Class Schedule (MMCSS) mentre il processo è in esecuzione.
        /// </summary>
        /// <param name="EnableMMCSS">true per notificare DWM di partecipare alla programmazione di MMCSS, false per terminare la partecipazione.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmEnableMMCSS", SetLastError = true)]
        internal static extern HRESULT DwmEnableMMCSS([MarshalAs(UnmanagedType.Bool)] BOOL EnableMMCSS);

        /// <summary>
        /// Estende la cornice della finestra nell'area client.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Margins">Puntatore a una struttura <see cref="MARGINS"/> che descrive i margini da usare durante l'estensione della cornice nell'area client.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Usare margini negativi per creare l'effetto "lastra di vetro" dove l'area client viene renderizzata come una superficie solida senza margine.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmExtendFrameIntoClientArea", SetLastError = true)]
        internal static extern HRESULT DwmExtendFrameIntoClientArea(HWND WindowHandle, ref MARGINS Margins);

        /// <summary>
        /// Blocca il chiamante fino a quando tutti gli aggiornamenti delle superfici DirectX messe in coda dal chiamante sono disegnato a schermo.
        /// </summary>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmFlush", SetLastError = true)]
        internal static extern HRESULT DwmFlush();

        /// <summary>
        /// Recupera il colore attualmente usato dalla composizione vetro di DWM.
        /// </summary>
        /// <param name="Colorization">Valore che riceve il colore usato per la composizione vetro.</param>
        /// <param name="OpaqueBlend">Valore che indica se il colore è opaco.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Il valore di <paramref name="Colorization"/> specifica un colore nel formato 0xAARRGGBB.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmGetColorizationColor", SetLastError = true)]
        internal static extern HRESULT DwmGetColorizationColor(out DWORD Colorization, [MarshalAs(UnmanagedType.Bool)] out BOOL OpaqueBlend);

        /// <summary>
        /// Recupera le informazioni sulle tempistiche attuali della composizione per una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="TimingInfo">Informazioni sulle tempistiche.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Il parametro <paramref name="WindowHandle"/> deve essere <see cref="IntPtr.Zero"/>, in caso contrario la funzione restituisce <see cref="E_INVALIDARG"/>.<br/><br/>
        /// La struttura <see cref="DWM_TIMING_INFO"/> deve avere il campo <see cref="DWM_TIMING_INFO.Size"/> impostato alla dimensione della struttura.<br/><br/>
        /// I campi <see cref="DWM_TIMING_INFO.FramesDisplayed"/>, <see cref="DWM_TIMING_INFO.FramesAvailable"/> e <see cref="DWM_TIMING_INFO.FramesDropped"/> avranno valori validi solo dopo la seconda chiamata a questa funzione.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmGetCompositionTimingInfo", SetLastError = true)]
        internal static extern HRESULT DwmGetCompositionTimingInfo(HWND WindowHandle, ref DWM_TIMING_INFO TimingInfo);

        /// <summary>
        /// Recupera gli attributi di trasporto.
        /// </summary>
        /// <param name="IsRemoting">Indica se il trasporto supporta il remoting.</param>
        /// <param name="IsConnected">Indica se il trasporto è connesso.</param>
        /// <param name="Generation">Generazione del trasporto.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmGetTransportAttributes", SetLastError = true)]
        internal static extern HRESULT DwmGetTransportAttributes([MarshalAs(UnmanagedType.Bool)] out BOOL IsRemoting, [MarshalAs(UnmanagedType.Bool)] out BOOL IsConnected, out DWORD Generation);

        /// <summary>
        /// Recupera il valore attuale di un attributo DWM applicato a una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Attribute">Attributo da recuperare.</param>
        /// <param name="AttributeValue">Puntatore a un valore che riceve il valore dell'attributo indicato da <paramref name="Attribute"/>.</param>
        /// <param name="AttributeSize">Dimensione, in bytes, del valore ricevuto attraverso il parametro <paramref name="AttributeValue"/>.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Il valore del parametro <paramref name="AttributeSize"/> e la dimensione del parametro <paramref name="AttributeValue"/> dipendono dal valore del parametro <paramref name="Attribute"/>.<br/>
        /// Riferirsi alla documentazione dell'enumerazione <see cref="DWMWINDOWATTRIBUTE"/> per impostare corretamente questi parametri.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmGetWindowAttribute", SetLastError = true)]
        internal static extern HRESULT DwmGetWindowAttribute(HWND WindowHandle, DWMWINDOWATTRIBUTE Attribute, IntPtr AttributeValue, DWORD AttributeSize);

        /// <summary>
        /// Indica che tutte le miniature fornite da una finestra non sono più valide e devono essere aggiornate.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>La finestra a cui l'handle, indicato nel parametro <paramref name="WindowHandle"/>, si riferisce deve appartenere al processo chiamante.<br/><br/>
        /// Questa funziona non dovrebbe essere chiamata di frequente in quanto potrebbe ridurre le prestazioni.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmInvalidateIconicBitmaps", SetLastError = true)]
        internal static extern HRESULT DwmInvalidateIconicBitmaps(HWND WindowHandle);

        /// <summary>
        /// Recupera la dimensione della fonte della miniatura DWM.
        /// </summary>
        /// <param name="ThumbnailHandle">Handle alla miniatura.</param>
        /// <param name="Size">Struttura <see cref="SIZE"/> che contiene i dati.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmQueryThumbnailSourceSize", SetLastError = true)]
        internal static extern HRESULT DwmQueryThumbnailSourceSize(HTHUMBNAIL ThumbnailHandle, out SIZE Size);

        /// <summary>
        /// Crea un'associazione tra le miniature di due finestre.
        /// </summary>
        /// <param name="DestinationWindow">Handle alla finestra che userà la miniatura DWM.</param>
        /// <param name="SourceWindow">Handle alla finestra da usare come fonte della miniatura.</param>
        /// <param name="ThumbnailID">Puntatore a un handle che rappresenta la registrazione della miniatura DWM.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>I parametri <paramref name="DestinationWindow"/> e <paramref name="SourceWindow"/> si devono riferire a finestre top-level, altrimenti la funzione restitusce <see cref="E_INVALIDARG"/>.<br/><br/>
        /// Registrare un'associazione non modifica la composizione del desktop.<br/><br/>
        /// La finestra a cui <paramref name="DestinationWindow"/> si riferisce deve essere il desktop o appartenere al processo che chiama questa funzione.<br/><br/>
        /// L'handle ottenuto da questa funzione è unico solo nell'ambito del processo chiamante.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmRegisterThumbnail", SetLastError = true)]
        internal static extern HRESULT DwmRegisterThumbnail(HWND DestinationWindow, HWND SourceWindow, out IntPtr ThumbnailID);

        /// <summary>
        /// Notifica DWM che un contatto è stato riconosciuto come gesto, e che DWM dovrebbe disegnare il feedback per tale gesto.
        /// </summary>
        /// <param name="GestureType">Tipo di gesto.</param>
        /// <param name="ContactsCount">Numero di contatti.</param>
        /// <param name="PointerID">ID del puntatore.</param>
        /// <param name="Points">Coordinata del punto.</param>
        /// <returns>Nessun valore di ritorno.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmRenderGesture", SetLastError = true)]
        internal static extern HRESULT DwmRenderGesture(GESTURE_TYPE GestureType, uint ContactsCount, ref DWORD PointerID, ref POINT Points);

        /// <summary>
        /// Imposta un bitmap statico in modo che mostri un'anteprima in tempo reale di una finestra o di una scheda.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="BitmapHandle">Handle al bitmap.</param>
        /// <param name="Client">Struttura <see cref="POINT"/> che indica l'offset della regione client di una scheda dall'host della cornice della finestra.</param>
        /// <param name="PreviewOptions">Opzioni per l'anteprima in tempo reale.</param>
        /// <returns>Restituisce <see cref="S_OK"/> se l'operazione è riuscita, un codice di errore altrimenti.</returns>
        /// <remarks>Il parametro <paramref name="PreviewOptions"/> può essere impostato a 0 oppure a <see cref="DWMConstants.DWM_SIT_DISPLAYFRAME"/> (mostrare una cornice attorno al bitmap).</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmSetIconicLivePreviewBitmap", SetLastError = true)]
        internal static extern HRESULT DwmSetIconicLivePreviewBitmap(HWND WindowHandle, HBITMAP BitmapHandle, IntPtr Client, DWORD PreviewOptions);

        /// <summary>
        /// Imposta un bitmap statico come miniatura.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="BitmapHandle">Handle al bitmap.</param>
        /// <param name="Options">Opzioni di visualizzazione della miniatura.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>I valori validi per il parametro <paramref name="Options"/> sono:<br/><br/>
        /// 0 (nessuna cornice viene mostrata attorno alla miniatura)<br/>
        /// <see cref="DWMConstants.DWM_SIT_DISPLAYFRAME"/> (mostrare una cornice attorno alla miniatura)</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmSetIconicThumbnail", SetLastError = true)]
        internal static extern HRESULT DwmSetIconicThumbnail(HWND WindowHandle, HBITMAP BitmapHandle, DWORD Options);

        /// <summary>
        /// Imposta i valori di DWM relativi agli attributi di rendering dell'area non-client per una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Attribute">Attributo da recuperare.</param>
        /// <param name="AttributeValue">Puntatore a un valore che riceve il valore dell'attributo indicato da <paramref name="Attribute"/>.</param>
        /// <param name="AttributeSize">Dimensione, in bytes, del valore ricevuto attraverso il parametro <paramref name="AttributeValue"/>.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Il valore del parametro <paramref name="AttributeSize"/> e la dimensione del parametro <paramref name="AttributeValue"/> dipendono dal valore del parametro <paramref name="Attribute"/>.<br/>
        /// Riferirsi alla documentazione dell'enumerazione <see cref="DWMWINDOWATTRIBUTE"/> per impostare corretamente questi parametri.<br/><br/>
        /// Il valore <see cref="DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED"/> non è valido per il parametro <paramref name="Attribute"/>, se si vuole abilitare o disabilitare il rendering dell'area non-client utilizzare il valore <see cref="DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY"/>.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmSetWindowAttribute", SetLastError = true)]
        internal static extern HRESULT DwmSetWindowAttribute(HWND WindowHandle, DWMWINDOWATTRIBUTE Attribute, IntPtr AttributeValue, DWORD AttributeSize);

        /// <summary>
        /// Specifica il feedback visuale da disegnare in risposta a un particolare contatto tocco o di penna.
        /// </summary>
        /// <param name="PointerID">ID del puntatore.</param>
        /// <param name="ShowContact">Tipo di contatto.</param>
        /// <returns>Se l'ID del puntatore non corrisponde a nessun contatto attualmente presente sullo schermo, questa funzione restituisce <see cref="E_INVALIDARG"/>, altrimenti restituisce <see cref="S_OK"/>.</returns>
        /// <remarks>Questa funzione può essere chiamare dal thread UI.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmShowContact", SetLastError = true)]
        internal static extern HRESULT DwmShowContact(DWORD PointerID, DWM_SHOWCONTACT ShowContact);

        /// <summary>
        /// Abilita il feedback grafico delle interazioni di tocco e trascinamento.
        /// </summary>
        /// <param name="PointerID">ID del puntatore.</param>
        /// <param name="Enable">Indica se abilitare il contatto.</param>
        /// <param name="Tether"></param>
        /// <returns>Nessun valore di ritorno.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmTetherContact", SetLastError = true)]
        internal static extern HRESULT DwmTetherContact(DWORD PointerID, [MarshalAs(UnmanagedType.Bool)] BOOL Enable, POINT Tether);

        /// <summary>
        /// Coordina le anizazione delle finestre tool con DWM.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Target">Comportamento della finestra.</param>
        /// <returns>Nessun valore di ritorno.</returns>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmTransitionOwnedWindow", SetLastError = true)]
        internal static extern HRESULT DwmTransitionOwnedWindow(HWND WindowHandle, DWMTRANSITION_OWNEDWINDOW_TARGET Target);

        /// <summary>
        /// Rimuove un'associazione tra le miniature di due finestre.
        /// </summary>
        /// <param name="ThumbnailID">Handle all'associazione da rimuovere.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Se l'handle indicato nel parametro <paramref name="ThumbnailID"/> è <see cref="IntPtr.Zero"/> o non esistente, questa funzione restituisce <see cref="E_INVALIDARG"/>.<br/><br/>
        /// Annullare la registrazione DWM deve essere fatto nel processo che ha registrato l'associazione.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmUnregisterThumbnail", SetLastError = true)]
        internal static extern HRESULT DwmUnregisterThumbnail(HTHUMBNAIL ThumbnailID);

        /// <summary>
        /// Aggiorna le proprietà per una miniatura DWM.
        /// </summary>
        /// <param name="ThumbnailID">Handle alla miniatura.</param>
        /// <param name="Properties">Struttura <see cref="DWM_THUMBNAIL_PROPERTIES"/> che contiene le nuove proprietà.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce <see cref="S_OK"/>, in caso di errore restituisce un codice HRESULT.</returns>
        /// <remarks>Se il parametro <paramref name="ThumbnailID"/> ha valore <see cref="IntPtr.Zero"/>, non è valido oppure si riferisce a miniature che sono proprietà di altri processi, questa funzione restituisce <see cref="E_INVALIDARG"/>.<br/><br/>
        /// Le relazioni tra miniatura create tramite <see cref="DwmRegisterThumbnail"/> non saranno renderizzate fino alla chiamata di questa funzione.</remarks>
        [DllImport("Dwmapi.dll", EntryPoint = "DwmUpdateThumbnailProperties", SetLastError = true)]
        internal static extern HRESULT DwmUpdateThumbnailProperties(HTHUMBNAIL ThumbnailID, ref DWM_THUMBNAIL_PROPERTIES Properties);
    }
}