using static WinApiWrapper.UserInterface.HighDPI.HighDPIMessages;

namespace WinApiWrapper.UserInterface.HighDPI
{
    /// <summary>
    /// Enumerazioni usate dalle funzioni che tengono conto dei DPI.
    /// </summary>
    internal static class HighDPIEnumerations
    {
        /// <summary>
        /// Impostazioni DPI per un thread, un processo o una finestra.
        /// </summary>
        internal enum DPI_AWARENESS
        {
            /// <summary>
            /// Valore non valido.
            /// </summary>
            DPI_AWARENESS_INVALID = -1,
            /// <summary>
            /// Non tiene conto dei DPI.
            /// </summary>
            /// <remarks>Il processo non ridimensiona in caso di cambi del valore DPI e assume sempre un fattore di scala del 100% (96 DPI).<br/><br/>
            /// Il sistema eseguirà il ridimensionamento su ogni altra impostazione DPI.</remarks>
            DPI_AWARENESS_UNAWARE,
            /// <summary>
            /// Tiene conto dei DPI di sistema.
            /// </summary>
            /// <remarks>Il processo non ridimensiona in caso di cambi del valore DPI.<br/><br/>
            /// Il processo richiederà il valore DPI una sola volta e lo userà per tutto il suo tempo di esecuzione, non si adatterà a cambi del valore DPI.<br/><br/>
            /// Il sistema eseguirà il ridimensionamento su ogni altra impostazione DPI.</remarks>
            DPI_AWARENESS_SYSTEM_AWARE,
            /// <summary>
            /// Tiene conto dei DPI per monitor.
            /// </summary>
            /// <remarks>Il processo controlla il valore dei DPI quando viene creato e adatta il fattore di scala quando cambia.<br/><br/>
            /// Il sistema non esegue il ridimensionamento.</remarks>
            DPI_AWARENESS_PER_MONITOR_AWARE
        }

        /// <summary>
        /// Tipo di impostazione DPI per un monitor.
        /// </summary>
        internal enum MONITOR_DPI_TYPE
        {
            /// <summary>
            /// DPI effettivo.
            /// </summary>
            /// <remarks>Questo valore dovrebbe essere usato quando si determina il corretto fattore di scala per ridimensionare gli elementi dell'interfaccia utente.<br/>
            /// Incorpora il fattore di scala impostato dall'utente per lo specifico display.</remarks>
            MDT_EFFECTIVE_DPI,
            /// <summary>
            /// DPI angolare.
            /// </summary>
            /// <remarks>Questo DPI assicura che il rendering a una risoluzione angolare sullo schermo.<br/>
            /// Non include il fattore di scala impostato dall'utente per lo specifico display.</remarks>
            MDT_ANGULAR_DPI,
            /// <summary>
            /// DPI puro.
            /// </summary>
            /// <remarks>Valore DPI misurato sullo schermo stesso.<br/><br/>
            /// Valore da usare quando si vuole leggere la densità dei pixel e l'impostazione di ridimensionamento raccomandata.<br/>
            /// Non include il fattore di scala impostato dall'utente per lo specifico display e non è garantito che sia un valore supportato.</remarks>
            MDT_RAW_DPI,
            /// <summary>
            /// Impostazione di default (<see cref="MDT_EFFECTIVE_DPI"/>).
            /// </summary>
            MDT_DEFAULT = MDT_EFFECTIVE_DPI
        }

        /// <summary>
        /// Identifica se il processo tiene conto dei DPI.
        /// </summary>
        internal enum PROCESS_DPI_AWARENESS
        {
            /// <summary>
            /// Non tiene conto dei DPI.
            /// </summary>
            /// <remarks>Il processo non ridimensiona in caso di cambi del valore DPI e assume sempre un fattore di scala del 100% (96 DPI).<br/><br/>
            /// Il sistema eseguirà il ridimensionamento su ogni altra impostazione DPI.</remarks>
            PROCESS_DPI_UNAWARE,
            /// <summary>
            /// Tiene conto dei DPI di sistema.
            /// </summary>
            /// <remarks>Il processo non ridimensiona in caso di cambi del valore DPI.<br/><br/>
            /// Il processo richiederà il valore DPI una sola volta e lo userà per tutto il suo tempo di esecuzione, non si adatterà a cambi del valore DPI.<br/><br/>
            /// Il sistema eseguirà il ridimensionamento su ogni altra impostazione DPI.</remarks>
            PROCESS_SYSTEM_DPI_AWARE,
            /// <summary>
            /// Tiene conto dei DPI per monitor.
            /// </summary>
            /// <remarks>Il processo controlla il valore dei DPI quando viene creato e adatta il fattore di scala quando cambia.<br/><br/>
            /// Il sistema non esegue il ridimensionamento.</remarks>
            PROCESS_PER_MONITOR_DPI_AWARE
        }

        /// <summary>
        /// Comportamento del gestore dialoghi in caso di cambio del valore dei DPI per le finestre di dialogo.
        /// </summary>
        [Flags]
        internal enum DIALOG_DPI_CHANGE_BEHAVIORS
        {
            /// <summary>
            /// Il comportamento predefinito del gestore dialoghi.
            /// </summary>
            /// <remarks>Il comportamento predefinito prevede che, in risposta a un cambio del valore dei DPI, il gestore dialoghi riposiziona i controlli, aggiorna il font di ogni controllo, ridimensione il dialogo e aggiorno il font del dialogo.</remarks>
            DDC_DEFAULT = 0x0000,
            /// <summary>
            /// Impedisce al gestore dialoghi di rispondere ai messaggi <see cref="WM_GETDPISCALEDSIZE"/> e <see cref="WM_DPICHANGED"/> disabilitando tutti i comportamenti.
            /// </summary>
            DDC_DISABLE_ALL = 0x0001,
            /// <summary>
            /// Impedisce al gestore dialoghi di ridimensionare il dialogo.
            /// </summary>
            DDC_DISABLE_RESIZE = 0x0002,
            /// <summary>
            /// Impedisce al gestore dialoghi di riposizionare i controlli di tutti i controlli figli diretti del dialogo.
            /// </summary>
            DDC_DISABLE_CONTROL_RELAYOUT = 0x0004
        }

        /// <summary>
        /// Comportamento del gestore dialoghi in caso di cambio del valore dei DPI per le finestre figlie di dialoghi.
        /// </summary>
        [Flags]
        internal enum DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS
        {
            /// <summary>
            /// Comportamento predefinito del gestore dialoghi.
            /// </summary>
            /// <remarks>Il comportamento predefinito prevede che il gestore dialoghi aggiorni il font, la dimensione e la posizione della finestra figlia.</remarks>
            DCDC_DEFAULT = 0x0000,
            /// <summary>
            /// Impedisce al gestore dialoghi di inviare il font aggiornato tramite il messaggio <see cref="WM_SETFONT"/>.
            /// </summary>
            DCDC_DISABLE_FONT_UPDATE = 0x0001,
            /// <summary>
            /// Impedisce al gestore dialoghi di ridimensionare e riposizionare le finestre figlie.
            /// </summary>
            DCDC_DISABLE_RELAYOUT = 0x0002
        }

        /// <summary>
        /// Comportamento di hosting per una finestra.
        /// </summary>
        internal enum DPI_HOSTING_BEHAVIOR
        {
            /// <summary>
            /// Comportamento hosting non valido.
            /// </summary>
            DPI_HOSTING_BEHAVIOR_INVALID = -1,
            /// <summary>
            /// Comportamento hosting predefinito.
            /// </summary>
            /// <remarks>La finestra non può creare o associarsi a finestre figlie con un DPI_AWARENESS_CONTEXT diverso dal proprio.</remarks>
            DPI_HOSTING_BEHAVIOR_DEFAULT,
            /// <summary>
            /// Comportamento hosting misto.
            /// </summary>
            /// <remarks>La finestra può creare o associarsi a finestre figlie con un DPI_AWARENESS_CONTEXT diverso dal proprio.</remarks>
            DPI_HOSTING_BEHAVIOR_MIXED
        }
    }
}