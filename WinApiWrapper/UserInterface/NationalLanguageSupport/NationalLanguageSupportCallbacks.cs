using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;

namespace WinApiWrapper.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Callback usati dalle funzioni NLS.
    /// </summary>
    internal static class NationalLanguageSupportCallbacks
    {
        /// <summary>
        /// Callback per l'elaborazione delle informazioni di un calendario fornite dalla funzione <see cref="EnumCalendarInfo"/>.
        /// </summary>
        /// <param name="CalendarInfoString">Stringa con informazioni sul calendario.</param>
        /// <param name="Calendar">ID calendario associato.</param>
        /// <param name="Reserved">Riservato, deve essere nullo.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumCalendarInfoProc([MarshalAs(UnmanagedType.LPWStr)] LPWSTR CalendarInfoString, CalendarID Calendar, LPWSTR Reserved, LPARAM lParam);

        /// <summary>
        /// Callback per l'elaborazione delle informazioni relative alle code page fornite della funzione <see cref="EnumSystemCodePages"/>.
        /// </summary>
        /// <param name="CodePageString">ID della code page.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumCodePagesProc([MarshalAs(UnmanagedType.LPWStr)] LPTSTR CodePageString);

        /// <summary>
        /// Callback per l'elaborazione delle informazioni relative ai formati della data forniti da <see cref="EnumDateFormats"/>.
        /// </summary>
        /// <param name="DateFormatString">Stringa di formato data.</param>
        /// <param name="CalendarID">ID calendario associato alla stringa di formato.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumDateFormatsProc([MarshalAs(UnmanagedType.LPWStr)] LPWSTR DateFormatString, CalendarID CalendarID, LPARAM lParam);

        /// <summary>
        /// Callback per l'elaborazione dei nomi località ricevuti da <see cref="EnumSystemLocales"/>.
        /// </summary>
        /// <param name="LocaleName">Nome della località.</param>
        /// <param name="Type">Tipo di località.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumLocalesProc([MarshalAs(UnmanagedType.LPWStr)] LPWSTR LocaleName, LocaleType Type, LPARAM lParam);

        /// <summary>
        /// Callback per l'elaborazione dei formati orari ricevuti da <see cref="EnumTimeFormats"/>.
        /// </summary>
        /// <param name="TimeFormatString">Stringa di formato orario.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumTimeFormatsProc([MarshalAs(UnmanagedType.LPWStr)] LPWSTR TimeFormatString, LPARAM lParam);

        /// <summary>
        /// Callback per l'elaborazione dei nomi geografici ricevuti da <see cref="EnumSystemGeoNames"/>.
        /// </summary>
        /// <param name="GeoName">Nome geografico.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate BOOL EnumGeoNamesProc([MarshalAs(UnmanagedType.LPWStr)] LPWSTR GeoName, LPARAM lParam);
    }
}