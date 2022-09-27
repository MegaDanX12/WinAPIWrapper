using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIConstants;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;

namespace WinApiWrapper.UserInterface.HighDPI
{
    /// <summary>
    /// Funzioni che tengono conto dei DPI per la loro esecuzione.
    /// </summary>
    internal static class HighDPIFunctions
    {
        /// <summary>
        /// Calcola la dimensione necessaria per il rettangolo della finestra, basandosi sulla dimensione desiderata del rettangolo client e sui DPI forniti.
        /// </summary>
        /// <param name="Rect">Puntatore a struttura <see cref="RECT"/> che contiene le coordinate dei angoli superiore sinistro e inferiore destro dell'area client desiderata.</param>
        /// <param name="Style">Stili della finestra.</param>
        /// <param name="HasMenu">Indica se la finestra ha un menù.</param>
        /// <param name="ExtendedStyle">Stili estesi della finestra.</param>
        /// <param name="DPI">DPI da usare per il ridimensionamento.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("User32.dll", EntryPoint = "AdjustWindowRectExForDpi", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL AdjustWindowRectExForDpi(ref RECT Rect, WindowStyle Style, [MarshalAs(UnmanagedType.Bool)] BOOL HasMenu, WindowExtendedStyle ExtendedStyle, uint DPI);

        /// <summary>
        /// Determina se due valori DPI_AWARENESS_CONTEXT sono identici.
        /// </summary>
        /// <param name="ContextA">Primo valore da confrontare.</param>
        /// <param name="ContextB">Secondo valore da confrontare.</param>
        /// <returns>true se sono uguali, false altrimenti.</returns>
        [DllImport("User32.dll", EntryPoint = "AreDpiAwarenessContextsEqual", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL AreDpiAwarenessContextsEqual(DPI_AWARENESS_CONTEXT ContextA, DPI_AWARENESS_CONTEXT ContextB);

        /// <summary>
        /// Abilita il ridimensionamento automatico dell'area non client di una specifica finestra top-level.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Questa funzione deve essere chiamata durante l'inizializzazione della finestra.<br/><br/>
        /// Chiamare questa funzione abilita il ridimensionamento dell'area non client per una finestra top-level con un DPI_AWARENESS_CONTEXT di <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/>.<br/>
        /// Se l'intero processo è in esecuzione in modalità <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/>, chiamare questa funzione abilita il ridimensionamento dell'area non client di tutte le finestre top-level del processo.<br/><br/>
        /// Se il DPI_AWARENESS_CONTEXT del processo o della finestra non ha nessuno dei valori indicati, o se questa funzione viene chiamata da qualunque altra finestra, l'operazione non riuscirà e la funzione restituira false.<br/><br/>
        /// Il ridimensionamento non client è disattivato di default, è necessario chiamare questa funzione per abilitarlo, una volta fatto non può più essere disabilitato.<br/><br/>
        /// L'effetto della chiamata a questa funzione è visibile solo sulle finestre top-level.<br/><br/>
        /// Se l'applicazione è in esecuzione in un DPI_AWARENESS_CONTEXT di <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/> chiamare questa funzione non è necessario, in quanto il ridimensionamento dell'area non client è attivo di default.</remarks>
        [DllImport("User32.dll", EntryPoint = "EnableNonClientDpiScaling", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnableNonClientDpiScaling(HWND WindowHandle);

        /// <summary>
        /// Recupera il valore <see cref="DPI_AWARENESS"/> da un DPI_AWARENESS_CONTEXT.
        /// </summary>
        /// <param name="Value">Valore DPI_AWARENESS_CONTEXT da esaminare.</param>
        /// <returns>Un valore dell'enumerazione <see cref="DPI_AWARENESS"/>.<br/><br/>
        /// Se il valore fornito è nullo o non valido, la funzione restituisce <see cref="DPI_AWARENESS.DPI_AWARENESS_INVALID"/>.</returns>
        [DllImport("User32.dll", EntryPoint = "GetAwarenessFromDpiAwarenessContext", SetLastError = true)]
        internal static extern DPI_AWARENESS GetAwarenessFromDpiAwarenessContext(DPI_AWARENESS_CONTEXT Value);

        /// <summary>
        /// Richiede i DPI di un display.
        /// </summary>
        /// <param name="Monitor">Handle al monitor.</param>
        /// <param name="Type">Tipo di DPI richiesto.</param>
        /// <param name="DpiX">Valore DPI sull'asse X, questo valore si riferisce sempre al bordo orizzontale, anche quando lo schermo è ruotato.</param>
        /// <param name="DpiY">Valore DPI sull'asse Y, questo valore si riferisce sempre al bordo verticale, anche quando lo schermo è ruotato.</param>
        /// <returns><see cref="S_OK"/> se l'operazione ha successo, <see cref="E_INVALIDARG"/> se l'handle, il tipo di DPI o i puntatori non sono validi.</returns>
        /// <remarks>Questa funzione non tiene conto dei DPI e non dovrebbe essere usata se il thread chiamante tiene conto dei DPI per monitor.<br/><br/>
        /// I valori di <paramref name="DpiX"/> e <paramref name="DpiY"/> sono identici.<br/><br/>
        /// Quando <paramref name="Type"/> ha valore <see cref="MONITOR_DPI_TYPE.MDT_ANGULAR_DPI"/> oppure <see cref="MONITOR_DPI_TYPE.MDT_RAW_DPI"/>, il valore restituito non include cambiamenti fatti dall'utente tramite il Pannello di controllo.</remarks>
        [DllImport("Shcore.dll", EntryPoint = "GetDpiForMonitor", SetLastError = true)]
        internal static extern HRESULT GetDpiForMonitor(HMONITOR Monitor, MONITOR_DPI_TYPE Type, out uint DpiX, out uint DpiY);

        /// <summary>
        /// Restituisce i DPI del sistema.
        /// </summary>
        /// <returns>Il valore DPI del sistema.</returns>
        /// <remarks>Se il thread corrente ha un valore <see cref="DPI_AWARENESS"/> di <see cref="DPI_AWARENESS.DPI_AWARENESS_UNAWARE"/>, la funzione restituirà 96 perché il contesto corrente assume un DPI di 96, per gli altri valori, la funzione restituirà l'effettivo DPI di sistema.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetDpiForSystem", SetLastError = true)]
        internal static extern uint GetDpiForSystem();

        /// <summary>
        /// Resituisce i DPI per una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <returns>Il valore restituito dipende dal valore <see cref="DPI_AWARENESS"/> della finestra: <br/><br/>
        /// <see cref="DPI_AWARENESS.DPI_AWARENESS_UNAWARE"/>: 96<br/>
        /// <see cref="DPI_AWARENESS.DPI_AWARENESS_SYSTEM_AWARE"/>: DPI di sistema<br/>
        /// <see cref="DPI_AWARENESS.DPI_AWARENESS_PER_MONITOR_AWARE"/>: DPI del monitor dove la finestra di trova<br/><br/>
        /// Se <paramref name="WindowHandle"/> non è valido, la funzione restituisce 0.</returns>
        [DllImport("User32l.dll", EntryPoint = "GetDpiForWindow", SetLastError = true)]
        internal static extern uint GetDpiForWindow(HWND WindowHandle);

        /// <summary>
        /// Recupera il valore di consapevolezza DPI per un processo.
        /// </summary>
        /// <param name="Process">Handle al processo.</param>
        /// <param name="Value">Valore di consapevolezza DPI del processo.</param>
        /// <returns>La funzione restituisce uno dei seguenti valori:<br/><br/>
        /// <see cref="S_OK"/>: l'operazione è riuscita.<br/>
        /// <see cref="E_INVALIDARG"/>: l'handle o il puntatore non sono validi.<br/>
        /// <see cref="E_ACCESSDENIED"/>: privilegi insufficienti.</returns>
        [DllImport("Shcore.dll", EntryPoint = "GetProcessDpiAwareness", SetLastError = true)]
        internal static extern HRESULT GetProcessDpiAwareness(HANDLE Process, out PROCESS_DPI_AWARENESS Value);

        /// <summary>
        /// Recupera il valore di una metrica o di una impostazione di sistema tenendo conto dei DPI forniti.
        /// </summary>
        /// <param name="Index">Metrica o impostazione di sistema da recuperare.</param>
        /// <param name="DPI">DPI da usare per scalare la metrica.</param>
        /// <returns>true se l'operazione ha successo, false altrimenti.</returns>
        [DllImport("User32.dll", EntryPoint = "GetSystemMetricsForDpi", SetLastError = true)]
        internal static extern int GetSystemMetricsForDpi(SystemMetricValue Index, uint DPI);

        /// <summary>
        /// Recupera il DPI_AWARENESS_CONTEXT per il thread corrente.
        /// </summary>
        /// <returns>Il valore DPI_AWARENESS_CONTEXT del thread.</returns>
        /// <remarks>Questa funzione restituisce l'ultimo valore inviato alla funzione <see cref="SetThreadDpiAwarenessContext"/>, se quest'ultima non è mai stata chiamata, viene restituito il valore per il processo.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetThreadDpiAwarenessContext", SetLastError = true)]
        internal static extern DPI_AWARENESS_CONTEXT GetThreadDpiAwarenessContext();

        /// <summary>
        /// Recupera il DPI_AWARENESS_CONTEXT associato con una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <returns>Il valore DPI_AWARENESS_CONTEXT per la finestra, se l'handle non è valido, la funzione restituisce <see cref="IntPtr.Zero"/>.</returns>
        [DllImport("User32.dll", EntryPoint = "GetWindowDpiAwarenessContext", SetLastError = true)]
        internal static extern DPI_AWARENESS_CONTEXT GetWindowDpiAwarenessContext(HWND WindowHandle);

        /// <summary>
        /// Determina se un certo DPI_AWARENESS_CONTEXT è valido e supportato dal sistema.
        /// </summary>
        /// <param name="Value">Contesto di cui determinare la validità.</param>
        /// <returns>true se il contesto fornito è supportato, false altrimenti.</returns>
        /// <remarks>se <paramref name="Value"/> è nullo, viene considerato come non valido, la funzione restituisce false.</remarks>
        [DllImport("User32.dll", EntryPoint = "IsValidAwarenessContext", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL IsValidDpiAwarenessContext(DPI_AWARENESS_CONTEXT Value);

        /// <summary>
        /// Converte un punto in una finestra da coordinate logiche in coordinate fisiche, senza tenere conto del tipo di awareness dei DPI del chiamante.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Point">Puntatore a struttura <see cref="POINT"/> che specifica le coordinate logiche da convertire.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Le nuove coordinate fisiche sono copiate nella struttura puntata da <paramref name="Point"/> se l'operazione ha successo.</remarks>
        [DllImport("User32.dll", EntryPoint = "LogicalToPhysicalPointForPerMonitorDPI", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL LogicalToPhysicalPointForPerMonitorDPI(HWND WindowHandle, ref POINT Point);

        /// <summary>
        /// Converte un punto in una finestra da coordinate fisiche in coordinate logiche, senza tenere conto del tipo di awareness dei DPI del chiamante.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Point">Puntatore a struttura <see cref="POINT"/> che specifica le coordinate fisiche da convertire.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Le nuove coordinate logiche sono copiate nella struttura puntata da <paramref name="Point"/> se l'operazione ha successo.</remarks>
        [DllImport("User32.dll", EntryPoint = "PhysicalToLogicalPointForPerMonitorDPI", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL PhysicalToLogicalPointForPerMonitorDPI(HWND WindowHandle, ref POINT Point);

        /// <summary>
        /// Imposta il livello di DPI awareness per il processo.
        /// </summary>
        /// <param name="Value">Valore da impostare.</param>
        /// <returns>Questa funzione restituisce uno dei seguenti valori:<br/><br/>
        /// <see cref="S_OK"/>: operazione riuscita.<br/>
        /// <see cref="E_INVALIDARG"/>: valore non valido.<br/>
        /// <see cref="E_ACCESSDENIED"/>: il livello di DPI awareness è già stato impostato.</returns>
        [DllImport("Shcore.dll", EntryPoint = "SetProcessDpiAwareness", SetLastError = true)]
        internal static extern HRESULT SetProcessDpiAwareness(PROCESS_DPI_AWARENESS Value);

        /// <summary>
        /// Imposta il livello di DPI awareness per il thread corrente.
        /// </summary>
        /// <param name="Context">Livello DPI awareness da impostare.</param>
        /// <returns>Il valore DPI awareness precedente.</returns>
        /// <remarks>Se <paramref name="Context"/> non è valido, il thread non viene aggiornato e il valore di ritorno è <see cref="IntPtr.Zero"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "SetThreadDpiAwarenessContext", SetLastError = true)]
        internal static extern DPI_AWARENESS_CONTEXT SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT Context);

        /// <summary>
        /// Recupera il valore di uno dei parametri di sistema, tenendo conto del valore DPI fornito.
        /// </summary>
        /// <param name="uiAction">Parametro da recuperare.</param>
        /// <param name="uiParam">L'uso e il formato di questo parametro dipende da <paramref name="uiAction"/>.</param>
        /// <param name="pvParam">L'uso e il formato di questo parametro dipende da <paramref name="uiAction"/>.</param>
        /// <param name="Options">Nessun effetto.</param>
        /// <param name="DPI">DPI da usare per scalare la metrica.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Questa funzione ha effetto solo per i seguenti valori di <paramref name="uiAction"/>:<br/><br/>
        /// <see cref="SystemParametersIcons.SPI_GETICONTITLELOGFONT"/><br/>
        /// <see cref="SystemParametersIcons.SPI_GETICONMETRICS"/><br/>
        /// <see cref="SystemParametersWindows.SPI_GETNONCLIENTMETRICS"/><br/><br/>
        /// Utilizzare questa funzione per qualsiasi altro valore restituisce false.</remarks>
        [DllImport("User32.dll", EntryPoint = "SystemParametersInfoForDpi", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SystemParametersInfoForDpi(uint uiAction, uint uiParam, IntPtr pvParam, SystemParameterUserProfileUpdateOptions Options, uint DPI);

        /// <summary>
        /// Imposta il livello di DPI awareness per il processo corrente.
        /// </summary>
        /// <param name="Value">Valore da impostare.</param>
        /// <returns>true se l'operazione ha successo, false altrimenti.</returns>
        /// <remarks>Errori possibili sono:<br/><br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> per input non valido.<br/>
        /// <see cref="ERROR_ACCESS_DENIED"/> se il livello di DPI awareness di default è già stato impostato.</remarks>
        [DllImport("User32.dll", EntryPoint = "SetProcessDpiAwarenessContext", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT Value);

        /// <summary>
        /// Imposta come il gestore dialogi deve gestire il cambio del valore DPI per le finestre di dialogo.
        /// </summary>
        /// <param name="DialogHandle">Handle al dialogo.</param>
        /// <param name="Mask">Comportamenti da modificare.</param>
        /// <param name="Values">Valori da impostare.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Possibili errori sono: <br/><br/>
        /// <see cref="ERROR_INVALID_HANDLE"/> se il dialogo non è valido.<br/>
        /// <see cref="ERROR_ACCESS_DENIED"/> se il dialogo non appartiene al processo.<br/><br/>
        /// Le impostazioni non avranno effetto se il contesto non è Per Monitor v2.</remarks>
        [DllImport("User32.dll", EntryPoint = "SetDialogDpiChangeBehavior", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetDialogDpiChangeBehavior(HWND DialogHandle, DIALOG_DPI_CHANGE_BEHAVIORS Mask, DIALOG_DPI_CHANGE_BEHAVIORS Values);

        /// <summary>
        /// Restituisce le impostazioni del gestore dialoghi per il cambio del valore DPI per un dialogo.
        /// </summary>
        /// <param name="DialogHandle">Handle al dialogo.</param>
        /// <returns>Un campo di bit che indica il comportamento del gestore dialoghi se l'operazione è riuscita, 0 in caso di errore.</returns>
        /// <remarks>Se l'handle non è valido, il codice di errore è impostato a <see cref="ERROR_INVALID_HANDLE"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetDialogDpiChangeBehavior", SetLastError = true)]
        internal static extern DIALOG_DPI_CHANGE_BEHAVIORS GetDialogDpiChangeBehavior(HWND DialogHandle);

        /// <summary>
        /// Imposta come il gestore dialogi deve gestire il cambio del valore DPI per le finestre figlie dei dialoghi.
        /// </summary>
        /// <param name="DialogHandle">Handle al dialogo.</param>
        /// <param name="Mask">Comportamenti da modificare.</param>
        /// <param name="Values">Valori da impostare.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Possibili errori sono: <br/><br/>
        /// <see cref="ERROR_INVALID_HANDLE"/> se l'handle non è valido.<br/>
        /// <see cref="ERROR_ACCESS_DENIED"/> se la finestra non appartiene al processo.<br/><br/>
        /// Il comportamento si può impostare su qualunque finestra ma avranno effetto solo quando essa diventa una figlia diretta di un dialogo che il ridimensionamento basato sui DPI per monitor.</remarks>
        [DllImport("User32.dll", EntryPoint = "SetDialogControlDpiChangeBehavior", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetDialogControlDpiChangeBehavior(HWND DialogHandle, DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS Mask, DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS Values);

        /// <summary>
        /// Restituisce le impostazioni del gestore dialoghi per il cambio del valore DPI per le finestre figlie di un dialogo.
        /// </summary>
        /// <param name="DialogHandle">Handle al dialogo.</param>
        /// <returns>Un campo di bit che indica il comportamento del gestore dialoghi se l'operazione è riuscita, 0 in caso di errore.</returns>
        /// <remarks>Se l'handle non è valido, il codice di errore è impostato a <see cref="ERROR_INVALID_HANDLE"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetDialogControlDpiChangeBehavior", SetLastError = true)]
        internal static extern DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS GetDialogControlDpiChangeBehavior(HWND DialogHandle);

        /// <summary>
        /// Apre un handle a un tema associato a uno specifico valore DPI.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="ClassList">Lista di classi.</param>
        /// <param name="DPI">Valore DPI da usare per associare l'handle del tema.</param>
        /// <returns>Handle al tema, <see cref="IntPtr.Zero"/> se l'associazione tra le classi e il tema è fallita.</returns>
        /// <remarks><paramref name="ClassList"/> è una lista separata da punto e virgola.<br/><br/>
        /// Per ogni classe fornita la funzione tenta di associarla alla sezione relativa ai dati delle classi per il tema attivo, se viene trovata una corrispondenza viene restituto un handle ad esso.<br/><br/>
        /// Il valore di <paramref name="DPI"/> non può essere al di fuori di quello associato ai monitor connessi.<br/><br/>
        /// L'handle al tema non è più valido ogni volta che il sistema ricarica i dati del tema.</remarks>
        [DllImport("User32.dll", EntryPoint = "OpenThemeDataForDpi", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HTHEME OpenThemeDataForDpi(HWND WindowHandle, string ClassList, uint DPI);

        /// <summary>
        /// Recupera il valore dei DPI di sistema associati con un processo.
        /// </summary>
        /// <param name="ProcessHandle">Handle al processo.</param>
        /// <returns>Il valore dei DPI di sistema per il processo.</returns>
        /// <remarks>Se <paramref name="ProcessHandle"/> ha valore <see cref="IntPtr.Zero"/>, la funzione si comporta allo stesso modo di <see cref="GetDpiForSystem"/>.<br/><br/>
        /// Se il processo corrente ha un valore <see cref="DPI_AWARENESS"/> di <see cref="DPI_AWARENESS.DPI_AWARENESS_UNAWARE"/>, la funzione restituirà 96 perché il contesto corrente assume un DPI di 96, per gli altri valori, la funzione restituirà l'effettivo DPI di sistema.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetSystemDpiForProcess", SetLastError = true)]
        internal static extern uint GetSystemDpiForProcess(HANDLE ProcessHandle);

        /// <summary>
        /// Recupera i DPI da un handle DPI_AWARENESS_CONTEXT.
        /// </summary>
        /// <param name="Value">Valore da esaminare.</param>
        /// <returns>I DPI associati a <paramref name="Value"/>.</returns>
        /// <remarks>Per handle DPI_AWARENESS_CONTEXT associati al valore <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/> e <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/>, la funzione restituisce 0 come valore DPI, in quanto il valore può cambiare e può recuperato solo avendo l'handle a una finestra.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetDpiFromDpiAwarenessContext", SetLastError = true)]
        internal static extern uint GetDpiFromAwarenessContext(DPI_AWARENESS_CONTEXT Value);

        /// <summary>
        /// Imposta il comportamento di hosting del thread.
        /// </summary>
        /// <param name="Value">Il nuovo comportamento per il thread corrente.</param>
        /// <returns>Il valore <see cref="DPI_HOSTING_BEHAVIOR"/> precedente associato al thread, <see cref="DPI_HOSTING_BEHAVIOR.DPI_HOSTING_BEHAVIOR_INVALID"/> se <paramref name="Value"/> non è valido, il thread non verrà aggiornato.</returns>
        /// <remarks>Il comportamento di hosting misto permette a finestre padre create da un thread di ospitare finestre figli con un DPI_AWARENESS_CONTEXT diverso.<br/><br/>
        /// Il comportamento di hosting misto non permette a finestre con un DPI_AWARENESS_CONTEXT per monitor di essere ospitate da finestre con DPI_AWARENESS_CONTEXT di sistema o se non tiene conto dei DPI.</remarks>
        [DllImport("User32.dll", EntryPoint = "SetThreadDpiHostingBehavior", SetLastError = true)]
        internal static extern DPI_HOSTING_BEHAVIOR SetThreadDpiHostingBehavior(DPI_HOSTING_BEHAVIOR Value);

        /// <summary>
        /// Restituisce il valore <see cref="DPI_HOSTING_BEHAVIOR"/> per il thread corrente.
        /// </summary>
        /// <returns>Il valore <see cref="DPI_HOSTING_BEHAVIOR"/> per il thread corrente.</returns>
        /// <remarks>Questa funzione restituisce il valore impostato precedentemente da una chiamata a <see cref="SetThreadDpiAwarenessContext"/>, restituisce <see cref="DPI_HOSTING_BEHAVIOR.DPI_HOSTING_BEHAVIOR_DEFAULT"/> se la funzione non è mai stata chiamata.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetThreadDpiHostingBehavior", SetLastError = true)]
        internal static extern DPI_HOSTING_BEHAVIOR GetThreadDpiHostingBehavior();

        /// <summary>
        /// Restituisce il valore <see cref="DPI_HOSTING_BEHAVIOR"/> per una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <returns>Il valore <see cref="DPI_HOSTING_BEHAVIOR"/> per la finestra.</returns>
        [DllImport("User32.dll", EntryPoint = "GetWindowDpiHostingBehavior", SetLastError = true)]
        internal static extern DPI_HOSTING_BEHAVIOR GetWindowDpiHostingBehavior(HWND WindowHandle);
    }
}