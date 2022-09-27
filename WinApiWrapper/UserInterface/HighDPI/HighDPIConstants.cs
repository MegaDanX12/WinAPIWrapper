namespace WinApiWrapper.UserInterface.HighDPI
{
    /// <summary>
    /// Costanti usate dall funzioni che tengono conto dei DPI.
    /// </summary>
    internal static class HighDPIConstants
    {
        /// <summary>
        /// Non tiene conto dei DPI.
        /// </summary>
        /// <remarks>La finestra non si ridimensiona in caso di cambio di DPI e si presume che abbia sempre un fattore di scala del 100% (96 DPI).<br/>
        /// Verrà automaticamente ridimensionata dal sistema per altre impostazioni DPI.</remarks>
        internal static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE = (IntPtr)(-1);

        /// <summary>
        /// Tiene conto dei DPI del sistema.
        /// </summary>
        /// <remarks>La finestra non si ridimensiona in caso di cambio di DPI.<br/><br/>
        /// Richiedera il valore DPI una volta e userà quel valore per tutta la vita del processo.<br/>
        /// Se i DPI cambiano, il processo non si adatterà al nuovo valore.<br/><br/>
        /// Verrà automaticamente ridimensionata dal sistema quando i DPI cambiano rispetto al valore di sistema.</remarks>
        internal static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = (IntPtr)(-2);

        /// <summary>
        /// Tiene conto dei DPI per monitor.
        /// </summary>
        /// <remarks>La finestra controlla il valore dei DPI quando viene creata è adatta il fattore di scala quando cambiano i DPI.<br/><br/>
        /// Questi processi non vengono automaticamente ridimensionati dal sistema.</remarks>
        internal static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = (IntPtr)(-3);

        /// <summary>
        /// Questo valore aggiunge i seguenti comportamenti in più rispetto a <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/>:<br/><br/>
        /// L'intero albero di finestre viene notificato quando avvengono cambi nel valore DPI.<br/>
        /// Le aree client di tutte le finestre verrà disegnato tenendo conto dei DPI.<br/>
        /// Tutti i menù NTUSER creati in questo contesto saranno ridimensionati tenendo conto dei DPI.<br/>
        /// Finestre di dialogo create in questo contesto risponderanno automaticamente ai cambi del valore DPI.<br/>
        /// Diversi controlli comctl32 hanno un comportamento di ridimensionamento rispetto ai DPI migliorato.<br/>
        /// Handle UxTheme aperti in questo contesto opereranno rispetto ai DPI associati con la finestra.
        /// </summary>
        internal static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = (IntPtr)(-4);

        /// <summary>
        /// Non tiene conto dei DPI, qualità migliorata per contenuto basato su GDI.
        /// </summary>
        /// <remarks>Questa modalità funziona in modo simile a <see cref="DPI_AWARENESS_CONTEXT_UNAWARE"/> ma permette al sistema di migliorare automaticamente la qualità di rendering del testo e di altri primitivi GDI quando la finestra viene visualizzata su un monitor a DPI alti.</remarks>
        internal static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = (IntPtr)(-5);
    }
}