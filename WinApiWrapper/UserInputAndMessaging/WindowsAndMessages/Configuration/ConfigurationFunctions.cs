using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration
{
    /// <summary>
    /// Funzioni relative alla configurazione del sistema.
    /// </summary>
    internal static class ConfigurationFunctions
    {
        /// <summary>
        /// Recupera o imposta i parametri di sistema.
        /// </summary>
        /// <param name="uiAction">Il parametro di sistema da recuperare o impostare.</param>
        /// <param name="uiParam">L'uso e il formato di questo parametro dipende dal parametro <paramref name="uiAction"/>.</param>
        /// <param name="pvParam">L'uso e il formato di questo parametro dipende dal parametro <paramref name="uiAction"/>.</param>
        /// <param name="WinIni">Indica se aggiornare il profilo utente dopo l'impostazione di un parametro, indica anche se inviare o meno il messaggio <see cref="WindowsAndMessages.Messages.WM_SETTINGCHANGE"/> dopo l'impostazione.</param>
        /// <returns>true se l'operazione ha successo, false in caso contrario.</returns>
        /// <remarks>A meno che indicato diversamente il parametro <paramref name="uiParam"/> deve avere valore 0.<br/><br/>
        /// A meno che indicato diversamente il parametro <paramref name="pvParam"/> deve avere valore <see cref="IntPtr.Zero"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "SystemParametersInfoW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, SystemParameterUserProfileUpdateOptions WinIni);
    }
}