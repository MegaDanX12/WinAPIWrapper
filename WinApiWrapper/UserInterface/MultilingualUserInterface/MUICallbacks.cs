using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIFunctions;

namespace WinApiWrapper.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Callback per funzionalità MUI.
    /// </summary>
    internal static class MUICallbacks
    {
        /// <summary>
        /// Funzione di callback chiamata da <see cref="EnumUILanguages"/>, utilizzata per elaborare i risultati dell'enumerazione.
        /// </summary>
        /// <param name="LanguageString">ID del linguaggio.</param>
        /// <param name="lParam">Dati definiti dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per interromperla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumUILanguagesProc(IntPtr LanguageString, LONG_PTR lParam);
    }
}