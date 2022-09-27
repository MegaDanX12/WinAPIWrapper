namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Controls
{
    /// <summary>
    /// Funzioni relative ai controlli.
    /// </summary>
    internal static class WindowsControlsFunctions
    {
        /// <summary>
        /// Recupera un handle ai dati del tema attivo per una finestra e la sua classe associata.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="ClassList">Lista di classi.</param>
        /// <returns>Handle ai dati del tema, <see cref="IntPtr.Zero"/> se l'associazione delle classi con le sezioni del tema relative ai dati delle classi non è riuscita.</returns>
        [DllImport("UxTheme.dll", EntryPoint = "OpenThemeData", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HTHEME OpenThemeData(HWND WindowHandle, LPCWSTR ClassList);
    }
}