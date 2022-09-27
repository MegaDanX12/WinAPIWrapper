namespace WinApiWrapper.Managed.UserInterface.HighDPI
{
    /// <summary>
    /// Enumerazioni usate dai metodi che tengono conto dei DPI.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Livello di consapevolezza relativo ai DPI.
        /// </summary>
        public enum DpiAwareness
        {
            /// <summary>
            /// Non tiene conto dei DPI.
            /// </summary>
            Unaware,
            /// <summary>
            /// Tiene conto dei DPI di sistema.
            /// </summary>
            SystemAware,
            /// <summary>
            /// Tiene conto dei DPI per monitor.
            /// </summary>
            PerMonitorAware
        }

        /// <summary>
        /// Tipo di DPI del monitor.
        /// </summary>
        public enum MonitorDpiType
        {
            /// <summary>
            /// DPI effettivo.
            /// </summary>
            /// <remarks>Questo valore incorpora il fattore di scala impostato dall'utente per il display.</remarks>
            Effective,
            /// <summary>
            /// DPI angolare.
            /// </summary>
            /// <remarks>Permette il rendering a una risoluzione angolare valida sullo schermo, non include il fattore di scala impostato dall'utente per il display.</remarks>
            Angular,
            /// <summary>
            /// DPI puro.
            /// </summary>
            /// <remarks>Valore misurato sullo schermo stesso, non include il fattore di scala impostato dall'utente per il display e non garantito che sia un valore supportato.<br/><br/>
            /// Il valore restituito è utile per calcolare la densità dei pixel.</remarks>
            Raw,
            /// <summary>
            /// Impostazione predefinita.
            /// </summary>
            /// <remarks>L'impostazione predefinita è <see cref="Effective"/>.</remarks>
            Default = Effective
        }

        /// <summary>
        /// Contesto di consapevolezza DPI.
        /// </summary>
        public enum DpiAwarenessContext
        {
            /// <summary>
            /// Non consapevole dei DPI.
            /// </summary>
            Unaware,
            /// <summary>
            /// Consapevole dei DPI del sistema.
            /// </summary>
            SystemAware,
            /// <summary>
            /// Consapevole dei DPI del monitor.
            /// </summary>
            PerMonitorAware,
            /// <summary>
            /// Consapevole dei DPI del monitor, miglioramento di <see cref="PerMonitorAware"/>.
            /// </summary>
            PerMonitorAwareV2,
            /// <summary>
            /// Non consapevole dei DPI, permette al sistema di migliorare la qualità di rendering del testo e altri primitivi GDI.
            /// </summary>
            UnawareGDIScaled
        }

        /// <summary>
        /// Comportamento delle finestre quando ospitano una finestra con un contesto di consapevolezza DPI diverso.
        /// </summary>
        public enum DpiHostingBehavior
        {
            /// <summary>
            /// Comportamento di default, la finestra non può creare o diventare il padre di finestre con un contesto di consapevolezza DPI diverso.
            /// </summary>
            Default,
            /// <summary>
            /// Comportamento misto, la finestra può creare o diventare il padre di finestre con un contesto di consapevolezza DPI diverso.
            /// </summary>
            /// <remarks>Le finestre figlie verranno scalate automaticamente dal sistema operativo.</remarks>
            Mixed
        }
    }
}