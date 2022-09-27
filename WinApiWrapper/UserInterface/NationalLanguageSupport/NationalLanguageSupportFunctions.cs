using System.Text;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportCallbacks;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportStructures;
using static WinApiWrapper.General.GeneralStructures;

namespace WinApiWrapper.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Funzioni NLS.
    /// </summary>
    internal static class NationalLanguageSupportFunctions
    {
        /// <summary>
        /// Converte un ID località nel rispettivo nome.
        /// </summary>
        /// <param name="Locale">ID località.</param>
        /// <param name="Name">Nome della località.</param>
        /// <param name="NameSize">Dimensione del parametro <paramref name="Name"/>.</param>
        /// <param name="Flags">Indica se la funziona deve restituire un nome neutrale (<see cref="LOCALE_ALLOW_NEUTRAL_NAMES"/>).</param>
        /// <returns>Il conteggio di caratteri, incluso il carattere nullo finale, del nome della località se l'operazione ha successo, 0 in caso di fallimento.</returns>
        /// <remarks>Il valore consigliato per il parametro <paramref name="NameSize"/> è <see cref="LOCALE_NAME_MAX_LENGTH"/> (85), se impostato a 0 la funzione restituisce la lunghezza del nome incluso il carattere nullo finale.<br/><br/>
        /// In caso di errore la funzione può restituire i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>: la dimensione del buffer è insufficiente oppure era nullo<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/>: almeno uno dei parametri non è valido</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "LCIDToLocaleName", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int LCIDToLocaleName(LCID Locale, StringBuilder Name, int NameSize, DWORD Flags);

        /// <summary>
        /// Converte un nome località nel rispettivo ID.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Flags">Indica se la funzione deve restituire un nome neutrale.</param>
        /// <returns>L'ID località corrispondente al nome località fornito.</returns>
        /// <remarks>Se il nome località corrisponde a una località personalizzata ed è quella predefinita dell'utente la funzione restituisce <see cref="LOCALE_CUSTOM_DEFAULT"/>, se corrisponde una località personalizzata che non è quella predefinita dell'utente, la funzione restituisce <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>.<br/><br/>
        /// Se la località fornita è compresa nel CLDR (Unicode Common Locale Data Repository), la funzione restituisce <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>.<br/><br/>
        /// La funzione restituisce 0, in caso di errore.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "LocaleNameToLCID", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern LCID LocaleNameToLCID(string? LocaleName, DWORD Flags);

        /// <summary>
        /// Determina se il nome località fornito è valido per una località installata e supportata dal sistema operativo.
        /// </summary>
        /// <param name="LocaleName">Nome località da controllare.</param>
        /// <returns>true se il nome è valido, false altrimenti.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "IsValidLocaleName", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL IsValidLocaleName(LPCWSTR LocaleName);

        /// <summary>
        /// Enumera le informazioni di un calendario per una località specificata da un nome.
        /// </summary>
        /// <param name="Callback">Callback che elabora le informazioni.</param>
        /// <param name="LocaleName">Nome della località.</param>
        /// <param name="Calendar">Calendario da cui recuperare le informazioni.</param>
        /// <param name="Reserved">Riservato, deve essere nullo.</param>
        /// <param name="CalType">Informazione da recuperare.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione da passare al callback.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/></remarks>
        [DllImport("Kernel32.dll", EntryPoint = "EnumCalendarInfoExEx", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumCalendarInfo([MarshalAs(UnmanagedType.FunctionPtr)] EnumCalendarInfoProc Callback, LPCWSTR? LocaleName, CalendarID Calendar, LPCWSTR? Reserved, CALTYPE CalType, LPARAM lParam);

        /// <summary>
        /// Enumera le code pages installate o supportate dal sistema operativo.
        /// </summary>
        /// <param name="Callback">Callback che elabora le informazioni.</param>
        /// <param name="Type">Tipo di code pages.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>La funzione può restituire i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_BADDB"/> (la funzione non ha potuto accedere ai dati)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il valore di <paramref name="Type"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "EnumSystemCodePagesW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumSystemCodePages([MarshalAs(UnmanagedType.FunctionPtr)] EnumCodePagesProc Callback, CodePageType Type);

        /// <summary>
        /// Enumera i formati delle date disponibili per una località.
        /// </summary>
        /// <param name="Callback">Callback che elabora le informazioni.</param>
        /// <param name="LocaleName">Nome della località.</param>
        /// <param name="Format">Formato della data.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione da passare al callback.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// La funzione può restituire i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_BADDB"/> (la funzione non ha potuto accedere ai dati)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il valore di <paramref name="Format"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "EnumDateFormatsExEx", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumDateFormats([MarshalAs(UnmanagedType.FunctionPtr)] EnumDateFormatsProc Callback, LPCWSTR? LocaleName, DateFormat Format, LPARAM lParam);

        /// <summary>
        /// Enumera le località installate oppure supportate dal sistema operativo.
        /// </summary>
        /// <param name="Callback">Funzione di callback che elabora i risultati.</param>
        /// <param name="Type">Tipo di località da recuperare.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione da passare al callback.</param>
        /// <param name="Reserved">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>La funzione può restituire i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_BADDB"/> (la funzione non ha potuto accedere ai dati)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il valore di <paramref name="Type"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "EnumSystemLocalesEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumSystemLocales([MarshalAs(UnmanagedType.FunctionPtr)] EnumLocalesProc Callback, LocaleType Type, LPARAM lParam, PVOID Reserved);

        /// <summary>
        /// Enumera i formati orari disponibili per una località.
        /// </summary>
        /// <param name="Callback">Funzione di callback che elabora i risultati.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Format">Formato orario.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione da passare al callback.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// La funzione può restituire i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_BADDB"/> (la funzione non ha potuto accedere ai dati)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il valore di <paramref name="Format"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "EnumTimeFormatsEx", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumTimeFormats([MarshalAs(UnmanagedType.FunctionPtr)] EnumTimeFormatsProc Callback, LPCWSTR? LocaleName, TimeFormat Format, LPARAM lParam);

        /// <summary>
        /// Enumera i codici ISO 3166-1 o UN M.49 disponibili nel sistema operativo.
        /// </summary>
        /// <param name="Class">Classe della posizione geografica su cui basare l'enumerazione.</param>
        /// <param name="Callback">Funzione di callback che elabora i risultati.</param>
        /// <param name="Data">Parametro fornito dall'applicazione da passare al callback.</param>
        /// <returns>true se l'opreazione è riuscita, false altrimenti.</returns>
        /// <remarks>La funzione può restituire i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il valore di <paramref name="Class"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "EnumSystemGeoNames", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumSystemGeoNames(SYSGEOTYPE Class, [MarshalAs(UnmanagedType.FunctionPtr)] EnumGeoNamesProc Callback, LPARAM Data);

        /// <summary>
        /// Recupera l'identificatore della code page corrente del sistema operativo.
        /// </summary>
        /// <returns>l'identificatore della code page.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "GetACP", SetLastError = true)]
        internal static extern uint GetCurrentAnsiCodePage();

        /// <summary>
        /// Recupera informazioni su un calendario per una località specificata.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Calendar">ID del calendario.</param>
        /// <param name="Reserved">Riservato, deve essere nullo.</param>
        /// <param name="CalendarInfo">Informazione da recuperare.</param>
        /// <param name="CalendarDataString">Informazione richiesta come stringa.</param>
        /// <param name="CalendarDataStringSize">Dimensione, in caratteri, di <paramref name="CalendarDataString"/>.</param>
        /// <param name="CalendarDataNumber">Informazione richiesta come numero.</param>
        /// <returns>Il numero di caratteri in <paramref name="CalendarDataString"/> se l'operazione ha successo, 0 in caso di errore.</returns>
        /// <remarks>I valori seguenti combinati con i valori dell'enumerazione <see cref="CalendarInfo"/> sono validi per <paramref name="CalendarInfo"/>:<br/><br/>
        /// <see cref="CAL_NOUSEROVERRIDE"/><br/>
        /// <see cref="CAL_RETURN_GENITIVE_NAMES"/><br/>
        /// <see cref="CAL_RETURN_NUMBER"/><br/><br/>
        /// Se <paramref name="CalendarDataStringSize"/> è impostato a 0 e <see cref="CAL_RETURN_NUMBER"/> non è specificato in <paramref name="CalendarInfo"/>, il valore restituito è la dimensione necessaria di <paramref name="CalendarDataString"/> per contenere le informazioni.<br/>
        /// Se <paramref name="CalendarDataStringSize"/> è impostato a 0 e <see cref="CAL_RETURN_NUMBER"/> è specificato in <paramref name="CalendarInfo"/>, il valore restituito è la dimensione del valore scritto in <paramref name="CalendarDataNumber"/> (2).<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Calendar"/> o <paramref name="CalendarInfo"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetCalendarInfoEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetCalendarInfo(LPCWSTR? LocaleName, CalendarID Calendar, LPCWSTR? Reserved, CALTYPE CalendarInfo, StringBuilder? CalendarDataString, int CalendarDataStringSize, IntPtr CalendarDataNumber);

        /// <summary>
        /// Recupera informazioni su una code page valida installata o disponibile.
        /// </summary>
        /// <param name="CodePage">Code page.</param>
        /// <param name="Flags">Riservato, deve essere 0.</param>
        /// <param name="Info">Struttura <see cref="CPINFOEX"/> che contiene le informazioni.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>I valori di <see cref="CodePageDefault"/> possono essere usati per <paramref name="CodePage"/>.<br/><br/>
        /// In caso di errore, il codice può essere <see cref="ERROR_INVALID_PARAMETER"/> se uno o più dei parametri non è valido.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetCPInfoExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetCodePageInfo(uint CodePage, DWORD Flags, out CPINFOEX Info);

        /// <summary>
        /// Formatta una stringa numerica come una stringa monetaria in base alla località fornita.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Flags">Parametro che modifica il comportamento della funzione.</param>
        /// <param name="Value">Stringa numerica da formattare.</param>
        /// <param name="FormatInfo">Puntatore a struttura <see cref="CURRENCYFMT"/> che contiene informazioni di formattazione.</param>
        /// <param name="CurrencyString">Stringa formattata.</param>
        /// <param name="CurrencyStringSize">Dimensione, in caratteri, di <paramref name="CurrencyString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="CurrencyString"/> se l'operazione ha avuto successo, 0 in caso di errore.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// Se <paramref name="FormatInfo"/> non è <see cref="IntPtr.Zero"/>, <paramref name="Flags"/> deve essere 0.<br/>
        /// In questo caso la funzione formatta <paramref name="Value"/> utilizzando i dati forniti nella struttura e usando le impostazioni della località fornita solo per le informazioni non fornite da essa.<br/>
        /// Se <paramref name="FormatInfo"/> è <see cref="IntPtr.Zero"/>, <paramref name="Flags"/> può specificare <see cref="LOCALE_NOUSEROVERRIDE"/>.<br/>
        /// Se <see cref="LOCALE_NOUSEROVERRIDE"/> è specificato, la funzione utilizza le impostazioni predefinite di sistema per la località specificata al posto di quelle dell'utente.<br/><br/>
        /// Se <paramref name="CurrencyStringSize"/> ha valore 0, il valore restituito rappresenta la dimensione necessaria di <paramref name="CurrencyString"/>, in questo caso <paramref name="CurrencyString"/> non viene usato.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Flags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetCurrencyFormatEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetCurrencyFormat(LPCWSTR? LocaleName, DWORD Flags, LPCWSTR Value, IntPtr FormatInfo, StringBuilder? CurrencyString, int CurrencyStringSize);

        /// <summary>
        /// Formatta una data come stringa in base alla località specificata.
        /// </summary>
        /// <param name="LocaleName">Nome della località.</param>
        /// <param name="Format">Formato della data.</param>
        /// <param name="Date">Struttura <see cref="SYSTEMTIME"/> che contiene la data da formattare.</param>
        /// <param name="FormatString">Stringa di formato che indica come formare la data.</param>
        /// <param name="DateString">Data formattata.</param>
        /// <param name="DateStringSize">Dimensione, in caratteri, di <paramref name="DateString"/>.</param>
        /// <param name="Calendar">Riservato, deve essere nullo.</param>
        /// <returns>Numero di caratteri in <paramref name="DateString"/> se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// <paramref name="Format"/> può includere anche <see cref="LOCALE_NOUSEROVERRIDE"/> e può essere combinato con i valori dell'enumerazione <see cref="DateFormat"/>.<br/>
        /// Se <paramref name="Format"/> non include <see cref="DateFormat.DATE_YEARMONTH"/>, <see cref="DateFormat.DATE_MONTHDAY"/>, <see cref="DateFormat.DATE_SHORTDATE"/> o <see cref="DateFormat.DATE_LONGDATE"/> e <paramref name="FormatString"/> è nullo, <see cref="DateFormat.DATE_SHORTDATE"/> è il valore predefinito.<br/><br/>
        /// Se <paramref name="FormatString"/> è nullo, la funzione userà le impostazioni della località per la formattazione.<br/><br/>
        /// <paramref name="Date"/> può essere <see cref="IntPtr.Zero"/>, in tal caso la funzione formatta la data corrente del sistema.<br/><br/>
        /// <paramref name="DateStringSize"/> può essere impostato a 0, in questo caso la funzione restituisce la lunghezza necessaria di <paramref name="DateString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Format"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetDateFormatEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetDateFormat(LPCWSTR? LocaleName, DWORD Format, IntPtr Date, LPCWSTR? FormatString, StringBuilder? DateString, int DateStringSize, LPCWSTR? Calendar);

        /// <summary>
        /// Formatta una durata come stringa in base alla località specificata.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Flags">Parametro che controlla il comportamento della funzione.</param>
        /// <param name="DurationStructure">Puntatore a struttura <see cref="SYSTEMTIME"/> che contiene la durata da formattare.</param>
        /// <param name="DurationTicks">Numero di intervalli di 100 nanosecondi (tick) nella durata.</param>
        /// <param name="FormatString">Stringa di formato da usare per formattare la durata.</param>
        /// <param name="DurationString">Stringa formattata.</param>
        /// <param name="DurationStringSize">Dimensione, in caratteri, di <paramref name="DurationString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="DurationString"/> se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// Se <paramref name="FormatString"/> non è nullo, <paramref name="Flags"/> deve essere 0, altrimenti può specificare <see cref="LOCALE_NOUSEROVERRIDE"/>.<br/>
        /// Se <paramref name="Flags"/> specifica <see cref="LOCALE_NOUSEROVERRIDE"/>, la funzione usa le impostazioni predefinite del sistema per la formattazione al posto di quelle dell'utente.<br/><br/>
        /// <paramref name="DurationStructure"/> può essere impostato a <see cref="IntPtr.Zero"/>, in questo caso verrà ignorato e verrà usato <paramref name="DurationTicks"/>.<br/>
        /// Se <paramref name="DurationStructure"/> e <paramref name="DurationTicks"/> sono entrambi impostati, <paramref name="DurationStructure"/> ha priorità.<br/><br/>
        /// Se <paramref name="DurationStringSize"/> ha valore 0, <paramref name="DurationString"/> deve essere nullo, in questo caso la funzione restituisce la dimensione necessaria, in caratteri, di <paramref name="DurationString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetDurationFormatEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetDurationFormat(LPCWSTR? LocaleName, DWORD Flags, IntPtr DurationStructure, ULONGLONG DurationTicks, LPCWSTR? FormatString, StringBuilder? DurationString, int DurationStringSize);

        /// <summary>
        /// Recupera informazioni su una posizione geografica.
        /// </summary>
        /// <param name="Location">Codice ISO 3166-1 o UN M.49 che identifica la località.</param>
        /// <param name="GeoInfoType">Tipo di informazione da recuperare.</param>
        /// <param name="GeoData">Buffer che conterrà l'informazione richiesta.</param>
        /// <param name="GeoDataSize">Dimensione, in caratteri, di <paramref name="GeoData"/>.</param>
        /// <returns>Numero di byte in <paramref name="GeoData"/> se l'operazione ha successo, 0 altrimenti.</returns>
        /// <remarks><see cref=" SYSGEOTYPE.GEOCLASS_NATION"/> non è un valore valido per <paramref name="GeoInfoType"/>.<br/><br/>
        /// Se <paramref name="GeoDataSize"/> ha valore 0, la funzione restituisce la dimensione necessaria, in byte, di <paramref name="GeoData"/>, non viene scritto nulla nel buffer.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="GeoInfoType"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetGeoInfoEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetGeoInfo(LPWSTR Location, SYSGEOTYPE GeoInfoType, IntPtr GeoData, int GeoDataSize);

        /// <summary>
        /// Recupera informazioni su una località.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Type">Informazione da recuperare.</param>
        /// <param name="LocaleData">Buffer che riceverà l'informazione richiesta.</param>
        /// <param name="LocaleDataSize">Dimensione, in caratteri, di <paramref name="LocaleData"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="LocaleData"/> se l'operazione ha successo, 0 altrimenti.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// Se <paramref name="Type"/> include <see cref="LOCALE_RETURN_NUMBER"/>, combinato con i valori appropriati di <see cref="GeoInfoType"/>, la funzione restituisce l'informazione richiesta come numero al posto che come stringa, la dimensione del buffer deve essere impostata di conseguenza (2).<br/>
        /// Se <paramref name="Type"/> specifica <see cref="GeoInfoType.LOCALE_IOPTIONALCALENDAR"/>, la funzione recupera solo il primo calendario alternativo.<br/><br/>
        /// Impostare a 0 <paramref name="LocaleDataSize"/> fa in modo che la funzione restituisca la dimensione necessaria, in caratteri, di <paramref name="LocaleData"/>, incluso il carattere nullo finale.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Type"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetLocaleInfoEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetLocaleInfo(LPCWSTR? LocaleName, uint Type, IntPtr LocaleData, int LocaleDataSize);

        /// <summary>
        /// Formatta una stringa come una stringa numerica basata sulla località fornita.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Flags">Parametro che controlla il comportamento della funzione.</param>
        /// <param name="Value">Stringa da formattare.</param>
        /// <param name="FormatInfo">Puntatore a struttura <see cref="NUMBERFMT"/> con informazioni di formattazione.</param>
        /// <param name="FormattedString">Buffer che conterrà la stringa formattata.</param>
        /// <param name="FormattedStringSize">Dimensione, in caratteri, di <paramref name="FormattedString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="FormattedString"/> se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// Se <paramref name="FormatInfo"/> non ha valore <see cref="IntPtr.Zero"/>, <paramref name="Flags"/> deve essere 0.<br/>
        /// In questo caso la stringa verrà formattata in base alle informazioni della struttura, per i campi non impostati in essa vengono usate le impostazioni della località.<br/>
        /// Se <paramref name="FormatInfo"/> ha valore <see cref="IntPtr.Zero"/>, <paramref name="Flags"/> può specificare <see cref="LOCALE_NOUSEROVERRIDE"/> per formattare la stringa usando le impostazioni predefinite di sistema al posto di quelle dell'utente per la località.<br/><br/>
        /// Se <paramref name="FormattedStringSize"/> ha valore 0 la funzione recuperare la dimensione necessaria, in caratteri, di <paramref name="FormattedString"/>, <paramref name="FormattedString"/> non viene usato.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Flags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_OUTOFMEMORY"/> (memoria insufficiente)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetNumberFormatEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetNumberFormat(LPCWSTR? LocaleName, DWORD Flags, LPCWSTR Value, IntPtr FormatInfo, StringBuilder? FormattedString, int FormattedStringSize);

        /// <summary>
        /// Recupera l'ID della code page OEM corrente per il sistema operativo.
        /// </summary>
        /// <returns>L'ID della code page OEM corrente.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "GetOEMCP", SetLastError = true)]
        internal static extern uint GetOEMCodePage();

        /// <summary>
        /// Fornisce una lista di script usati in una stringa Unicode.
        /// </summary>
        /// <param name="Flags">Opzioni per il recupero degli script.</param>
        /// <param name="String">Stringa Unicode da analizzare.</param>
        /// <param name="StringSize">Dimensione, in caratteri, di <paramref name="String"/>.</param>
        /// <param name="Scripts">Buffer che conterrà la lista di script.</param>
        /// <param name="ScriptsSize">Dimensione, in caratteri, di <paramref name="Scripts"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="Scripts"/>, incluso il carattere nullo finale se l'operazione è riuscita, 0 altrimenti.</returns>
        /// <remarks><paramref name="Flags"/> può includere <see cref="GSS_ALLOW_INHERITED_COMMON"/> per fare in modo di includere anche gli script comuni ed ereditati nella lista.<br/><br/>
        /// Se <paramref name="String"/> è a terminazione nulla, <paramref name="StringSize"/> deve essere -1.<br/>
        /// Se <paramref name="StringSize"/> ha valore 0, la funzione recupera una stringa vuota e restituisce 1.<br/><br/>
        /// Gli script nella lista presente in <paramref name="Scripts"/> usano la notazione a 4 caratteri ISO 15924, sono in ordine alfabetico e sono tutti separati, incluso l'ultimo, da un punto e virgola.<br/><br/>
        /// Se <paramref name="ScriptsSize"/> ha valore 0, <paramref name="Scripts"/> è nullo e la funzione restituisce la dimensione necessaria, in caratteri, di <paramref name="Scripts"/>.<br/><br/>
        /// La funzione restituisce 1 se non sono stati trovati script.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Flags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_BADDB"/> (la funzione non ha potuto accedere ai dati)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetStringScripts", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetStringScripts(DWORD Flags, LPCWSTR String, int StringSize, StringBuilder? Scripts, int ScriptsSize);

        /// <summary>
        /// Recupera informazioni sui tipi di caratteri in una stringa.
        /// </summary>
        /// <param name="Locale">ID località.</param>
        /// <param name="InfoType">Informazione da recuperare.</param>
        /// <param name="String">Stringa da analizzare.</param>
        /// <param name="StringSize">Dimensione, in caratteri, di <paramref name="String"/>.</param>
        /// <param name="CharacterTypes">Array di valori a 16 bit.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="Locale"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_USER_DEFAULT"/><br/>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/><br/>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/><br/>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/><br/><br/>
        /// Se <paramref name="StringSize"/> è negativo, la funzione presume che <paramref name="String"/> sia a terminazione nulla.<br/><br/>
        /// <paramref name="CharacterTypes"/> deve essere grande a sufficienza per ricevere un valore a 16 bit per ogni carattere in <paramref name="String"/>.<br/>
        /// Se <paramref name="StringSize"/> non è negativo, la dimensione di <paramref name="CharacterTypes"/> deve essere pari al valore del parametro.<br/>
        /// Se <paramref name="StringSize"/> è negativo, la dimensione di <paramref name="CharacterTypes"/> deve essere pari al numero di caratteri di <paramref name="String"/> + 1.<br/><br/>
        /// L'array conterrà un valore a 16 bit per ogni carattere in <paramref name="String"/>.<br/><br/>
        /// <paramref name="Locale"/> è usato solamente per convertire una stringa ANSI in Unicode.<br/><br/>
        /// Se <paramref name="InfoType"/> ha valore <see cref="StringCharacterTypeInfo.CT_CTYPE1"/>, i valori dei componenti di <paramref name="CharacterTypes"/> corrispondono o sono combinazioni dei valori contenuti in <see cref="CharacterTypeValues"/>.<br/>
        /// Se <paramref name="InfoType"/> ha valore <see cref="StringCharacterTypeInfo.CT_CTYPE2"/>, i valori dei componenti di <paramref name="CharacterTypes"/> corrispondono ai valori contenuti in <see cref="StringLayoutValues"/>.<br/>
        /// Se <paramref name="InfoType"/> ha valore <see cref="StringCharacterTypeInfo.CT_CTYPE3"/>, i valori dei componenti di <paramref name="CharacterTypes"/> corrispondono o sono combinazioni dei valori contenuti in <see cref="StringTextProcessingValues"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="InfoType"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/></remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetStringTypeExW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetStringType(LCID Locale, StringCharacterTypeInfo InfoType, LPCWSTR String, int StringSize, [Out] ushort[] CharacterTypes);

        /// <summary>
        /// Recupera il nome della località predefinita del sistema.
        /// </summary>
        /// <param name="LocaleName">Buffer che riceverà il nome località.</param>
        /// <param name="LocaleNameSize">Dimensione, in caratteri, di <paramref name="LocaleName"/>.</param>
        /// <returns>Lunghezza, in caratteri, di <paramref name="LocaleName"/>, incluso il carattere nullo finale, se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks>La dimensione massima e consigliata di <paramref name="LocaleName"/> è <see cref="LOCALE_NAME_MAX_LENGTH"/>, il parametro <paramref name="LocaleNameSize"/> dovrebbe essere impostato a tale valore.<br/><br/>
        /// In caso di errore la funzione può restituire il codice <see cref="ERROR_INSUFFICIENT_BUFFER"/>, se <paramref name="LocaleName"/> è troppo piccolo o nullo.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetSystemDefaultLocaleName", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetSystemDefaultLocaleName(StringBuilder? LocaleName, int LocaleNameSize);

        /// <summary>
        /// Recupera l'ID località della località corrente per il thread chiamante.
        /// </summary>
        /// <returns>L'ID località del thread chiamante.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "GetThreadLocale", SetLastError = true)]
        internal static extern LCID GetThreadLocale();

        /// <summary>
        /// Formatta un tempo come una stringa per una specifica località.
        /// </summary>
        /// <param name="LocaleName">Nome della località.</param>
        /// <param name="Flags">Opzioni di formattazione.</param>
        /// <param name="TimeStructure">Struttura <see cref="SYSTEMTIME"/> che contiene le informazioni da formattare.</param>
        /// <param name="FormatString">Stringa di formato che specifica come formattare le informazioni fornite.</param>
        /// <param name="FormattedString">Buffer che riceverà la stringa formattata.</param>
        /// <param name="FormattedStringSize">Dimensione, in caratteri, di <paramref name="FormattedString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="FormattedString"/> se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// <paramref name="Flags"/> può anche includere <see cref="LOCALE_NOUSEROVERRIDE"/>, combinato con i valori dell'enumerazione <see cref="TimeFormat"/>.<br/><br/>
        /// <paramref name="TimeStructure"/> contiene una struttura <see cref="SYSTEMTIME"/> con le informazioni da formattare, se ha valore <see cref="IntPtr.Zero"/>, la funzione utilizzera il tempo locale di sistema.<br/><br/>
        /// Se <paramref name="FormatString"/> non è nullo, essa viene usata per la formattazione usando le informazioni fornite dalla località sono se non presenti nella stringa, se è nullo, vengono usate le informazioni fornite dalla località.<br/><br/>
        /// Se <paramref name="FormattedStringSize"/> ha valore 0, la funzione restituisce la dimensione necessaria, in caratteri, di <paramref name="FormattedString"/>.<br/><br/>
        /// Se <paramref name="Flags"/> non include <see cref="TimeFormat.TIME_NOTIMEMARKER"/>, gli indicatori vengono localizzati in base alla località fornita.<br/>
        /// Se <paramref name="Flags"/> include <see cref="TimeFormat.TIME_NOMINUTESORSECONDS"/> oppure <see cref="TimeFormat.TIME_NOSECONDS"/>, vengono rimossi i separatori che precedono i minuti e/o i secondi.<br/>
        /// Se <paramref name="Flags"/> include <see cref="TimeFormat.TIME_NOTIMEMARKER"/>, vengono rimossi i separatori che precedono e seguono gli indicatori.<br/>
        /// Se <paramref name="Flags"/> include <see cref="TimeFormat.TIME_FORCE24HOURFORMAT"/>, gli indicatori sono comunque inclusi, a meno che <see cref="TimeFormat.TIME_NOTIMEMARKER"/> sia incluso in <paramref name="Flags"/>.<br/><br/>
        /// I millisecondi non sono inclusi nella stringa formattata.<br/><br/>
        /// Se la stringa di formato specificata in <paramref name="FormatString"/> contiene elementi non validi, la funzione non restituisce nessun errore ma cerca di formare la migliore stringa formattata possibile con i dati a disposizione.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Flags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_OUTOFMEMORY"/> (memoria insufficiente)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetTimeFormatEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetTimeFormat(LPCWSTR? LocaleName, uint Flags, IntPtr TimeStructure, LPCWSTR? FormatString, StringBuilder? FormattedString, int FormattedStringSize);

        /// <summary>
        /// Recupera il codice a 2 lettere ISO 3166-1 o il codice UN M.49 per la località geografica predefinità dell'utente.
        /// </summary>
        /// <param name="GeoName">Buffer che conterrà il codice.</param>
        /// <param name="GeoNameSize">Dimensione, in caratteri, di <paramref name="GeoName"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="GeoName"/> se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks>Se <paramref name="GeoNameSize"/> ha valore 0, la funzione restituisce la dimensione necessaria, in caratteri, di <paramref name="GeoName"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_BADDB"/> (la funzione non ha potuto accedere ai dati)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetUserDefaultGeoName", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetUserDefaultGeoName(StringBuilder? GeoName, int GeoNameSize);

        /// <summary>
        /// Recupera il nome della località predefinita dell'utente.
        /// </summary>
        /// <param name="LocaleName">Buffer che riceverà il nome località.</param>
        /// <param name="LocaleNameSize">Dimensione, in caratteri, di <paramref name="LocaleName"/>.</param>
        /// <returns>Lunghezza, in caratteri, di <paramref name="LocaleName"/>, incluso il carattere nullo finale, se l'operazione ha successo, 0 in caso contrario.</returns>
        /// <remarks>La dimensione massima e consigliata di <paramref name="LocaleName"/> è <see cref="LOCALE_NAME_MAX_LENGTH"/>, il parametro <paramref name="LocaleNameSize"/> dovrebbe essere impostato a tale valore.<br/><br/>
        /// In caso di errore la funzione può restituire il codice <see cref="ERROR_INSUFFICIENT_BUFFER"/>, se <paramref name="LocaleName"/> è troppo piccolo o nullo.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetUserDefaultLocaleName", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetUserDefaultLocaleName(StringBuilder? LocaleName, int LocaleNameSize);

        /// <summary>
        /// Converte un nome di dominio internazionalizzato (IDN) o un'altra etichetta internazionalizzata in una rappresentazione Unicode di una stringa ASCII rappresentante il nome seguendo la sintassi Punycode.
        /// </summary>
        /// <param name="Options">Opzioni di conversione.</param>
        /// <param name="IdnString">Stringa che rappresenta l'IDN o un'altra etichetta internazionalizzata.</param>
        /// <param name="IdnStringSize">Numero di caratteri in <paramref name="IdnString"/>.</param>
        /// <param name="ASCIIString">Buffer che riceve la stringa risultato della conversione.</param>
        /// <param name="ASCIIStringSize">Dimensione, in caratteri, di <paramref name="ASCIIString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="ASCIIString"/> se l'operazione ha avuto successo, 0 in caso contrario.</returns>
        /// <remarks>Se <paramref name="ASCIIStringSize"/> ha valore 0, <paramref name="ASCIIString"/> deve essere nullo e la funzione restituisce la dimensione necessaria, in caratteri, incluso il carattere nullo finale se esiste in <paramref name="IdnString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Options"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_INVALID_NAME"/> (errore di sintassi)<br/>
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/> (carattere unicode non valido trovato)</remarks>
        [DllImport("Normaliz.dll", EntryPoint = "IdnToAscii", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int IdnToAscii(IdnConversionOptions Options, LPCWSTR IdnString, int IdnStringSize, StringBuilder? ASCIIString, int ASCIIStringSize);

        /// <summary>
        /// Converte un nome di dominio internazionalizzato (IDN) o un'altra etichetta internazionalizzata nella forma specificata dal Network Working Group RFC 3491, non esegue una conversione a Punycode.
        /// </summary>
        /// <param name="Options">Opzioni di conversione.</param>
        /// <param name="IdnString">Stringa che rappresenta l'IDN o un'altra etichetta internazionalizzata.</param>
        /// <param name="IdnStringSize">Numero di caratteri in <paramref name="IdnString"/>.</param>
        /// <param name="NameprepString">Buffer che riceve la stringa risultato della conversione.</param>
        /// <param name="NameprepStringSize">Dimensione, in caratteri, di <paramref name="NameprepString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="NameprepString"/> se l'operazione ha avuto successo, 0 in caso contrario.</returns>
        /// <remarks>Se <paramref name="NameprepStringSize"/> ha valore 0, <paramref name="NameprepString"/> deve essere nullo e la funzione restituisce la dimensione necessaria, in caratteri, incluso il carattere nullo finale se esiste in <paramref name="IdnString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Options"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_INVALID_NAME"/> (errore di sintassi)<br/>
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/> (carattere unicode non valido trovato)</remarks>
        [DllImport("Normaliz.dll", EntryPoint = "IdnToNameprepUnicode", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int IdnToNameprepUnicode(IdnConversionOptions Options, LPCWSTR IdnString, int IdnStringSize, StringBuilder? NameprepString, int NameprepStringSize);

        /// <summary>
        /// Converte un nome di dominio internazionalizzato (IDN) o un'altra etichetta internazionalizzata in sintassi Punycode nella normale sintassi Unicode.
        /// </summary>
        /// <param name="Options">Opzioni di conversione.</param>
        /// <param name="PunycodeString">Stringa che rappresenta l'IDN o un'altra etichetta internazionalizzata.</param>
        /// <param name="PunycodeStringSize">Numero di caratteri in <paramref name="PunycodeString"/>.</param>
        /// <param name="UnicodeString">Buffer che riceve la stringa risultato della conversione.</param>
        /// <param name="UnicodeStringSize">Dimensione, in caratteri, di <paramref name="UnicodeString"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="UnicodeString"/> se l'operazione ha avuto successo, 0 in caso contrario.</returns>
        /// <remarks>Se <paramref name="UnicodeStringSize"/> ha valore 0, <paramref name="UnicodeString"/> deve essere nullo e la funzione restituisce la dimensione necessaria, in caratteri, incluso il carattere nullo finale se esiste in <paramref name="PunycodeString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Options"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_INVALID_NAME"/> (errore di sintassi)<br/>
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/> (carattere unicode non valido trovato)</remarks>
        [DllImport("Normaliz.dll", EntryPoint = "IdnToUnicode", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int IdnToUnicode(IdnConversionOptions Options, LPCWSTR PunycodeString, int PunycodeStringSize, StringBuilder? UnicodeString, int UnicodeStringSize);

        /// <summary>
        /// Verifica se una stringa è normalizzata in base a Unicode 4.0.
        /// </summary>
        /// <param name="NormalizationForm">Forma di normalizzazione da usare.</param>
        /// <param name="String">Stringa da verificare.</param>
        /// <param name="StringSize">Dimensione, in caratteri, di <paramref name="String"/>.</param>
        /// <returns>true se la stringa è normalizzata, false altrimenti.</returns>
        /// <remarks><paramref name="StringSize"/> può essere impostato a -1, in tal caso la funzione assume che <paramref name="String"/> è a terminazione nulla e calcola la lunghezza automaticamente.<br/><br/>
        /// La funzione ritorna false anche in caso di errore, i possibili codici sono:<br/><br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non è valido)<br/>
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/> (carattere Unicode non valido trovato nella stringa)<br/>
        /// <see cref="ERROR_SUCCESS"/> (l'operazione è stata completata ma non ci sono risultati)</remarks>
        [DllImport("Normaliz.dll", EntryPoint = "IsNormalizedString", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL IsNormalizedString(NORM_FORM NormalizationForm, LPCWSTR String, int StringSize);

        /// <summary>
        /// Determina se una code page è valida.
        /// </summary>
        /// <param name="CodePage">Code page da controllare.</param>
        /// <returns>true se la code page è valida, false altrimenti.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "IsValidCodePage", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL IsValidCodePage(uint CodePage);

        /// <summary>
        /// Normalizza i caratteri di una stringa in base a Unicode 4.0.
        /// </summary>
        /// <param name="NormalizationForm">Forma di normalizzazione.</param>
        /// <param name="OriginalString">Stringa originale non normalizzata.</param>
        /// <param name="OriginalStringSize">Dimensione, in caratteri, di <paramref name="OriginalString"/>.</param>
        /// <param name="NormalizedString">Buffer che riceve la stringa normalizzata.</param>
        /// <param name="NormalizedStringSize">Dimensione, in caratteri, di <paramref name="NormalizedStringSize"/>.</param>
        /// <returns>Numero di caratteri in <paramref name="NormalizedString"/> se l'operazione ha successo, 0 o un numero minore di 0 in caso contrario.</returns>
        /// <remarks>Se <paramref name="OriginalStringSize"/> ha valore -1, la funzione assume che la stringa termina con un carattere nullo e calcola la lunghezza automaticamente, inoltre <paramref name="NormalizedString"/> termina con un carattere nullo in questo caso.<br/><br/>
        /// Se <paramref name="NormalizedStringSize"/> ha valore 0, <paramref name="NormalizedString"/> ha valore <see cref="IntPtr.Zero"/> e la funzione restituisce la dimensione necessaria di <paramref name="NormalizedString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_SUCCESS"/> (operazione completata ma non ci sono stati risultati)<br/>
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/> (carattere unicode non valido trovato)</remarks>
        [DllImport("Normaliz.dll", EntryPoint = "NormalizeString", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int NormalizeString(NORM_FORM NormalizationForm, LPCWSTR OriginalString, int OriginalStringSize, StringBuilder? NormalizedString, int NormalizedStringSize);

        /// <summary>
        /// Trova una corrispondenza per un nome fornito.
        /// </summary>
        /// <param name="NameToResolve">Nome di cui trovare la corrispondenza.</param>
        /// <param name="LocaleName">Buffer che riceve il nome della località corrispondente.</param>
        /// <param name="LocaleNameSize">Dimensione, in caratteri, di <paramref name="LocaleName"/>.</param>
        /// <returns>Dimensione, in caratteri, di <paramref name="LocaleName"/> incluso il carattere nullo finale se l'operazione è riuscita, 0 altrimenti.</returns>
        /// <remarks>La dimensione massima e consigliata di <paramref name="LocaleName"/> è <see cref="LOCALE_NAME_MAX_LENGTH"/>.<br/><br/>
        /// In caso di errore la funzione può impostare il codice <see cref="ERROR_INSUFFICIENT_BUFFER"/>, nel caso <paramref name="LocaleName"/> sia troppo piccolo o nullo.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "ResolveLocaleName", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int ResolveLocaleName(LPCWSTR NameToResolve, StringBuilder? LocaleName, int LocaleNameSize);

        /// <summary>
        /// Imposta un oggetto delle informazioni di un calendario.
        /// </summary>
        /// <param name="Locale">ID località.</param>
        /// <param name="Calendar">ID del calendario del quale impostare le informazioni.</param>
        /// <param name="Type">Informazione da impostare.</param>
        /// <param name="CalendarData">Stringa che indica il valore dell'informazione da impostare.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="Locale"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_USER_DEFAULT"/><br/>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/><br/>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/><br/>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/><br/>
        /// <see cref="LOCALE_INVARIANT"/><br/><br/>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/><br/><br/>
        /// L'unico valore valido per <paramref name="Type"/> è <see cref="CalendarInfo.CAL_ITWODIGITYEARMAX"/>.<br/><br/>
        /// Questa funzione modifica soltanto gli override delle impostazioni di calendario, non cambia le impostazioni predefinite di sistema.<br/><br/>
        /// Il valore deve essere sempre passato come stringa a terminazione nulla, non è permesso passare numeri.<br/><br/>
        /// <see cref="CalendarInfo.CAL_ITWODIGITYEARMAX"/> può essere usato con qualunque calendario, che sia supportato o meno dalla località.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Type"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_INTERNAL_ERROR"/> (errore non previsto)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "SetCalendarPoint", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetCalendarInfo(LCID Locale, CalendarID Calendar, CalendarInfo Type, LPCWSTR CalendarData);

        /// <summary>
        /// Imposta un oggetto delle informazioni di una località.
        /// </summary>
        /// <param name="Locale">ID località.</param>
        /// <param name="Info">Informazione da impostare.</param>
        /// <param name="Data">Nuovo valore.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Il parametro <paramref name="Locale"/> viene ignorato.<br/><br/>
        /// Questa funzione può impostare i seguenti codici di errore:<br/><br/>
        /// <see cref="ERROR_ACCESS_DISABLED_BY_POLICY"/> (i criteri di gruppo del sistema o dell'utente non permettono l'operazione)<br/>
        /// <see cref="ERROR_INVALID_ACCESS"/> (codice di accesso non valido)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (parametro <paramref name="Info"/> non valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non è valido)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "SetLocaleInfoW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetLocaleInfo(LCID Locale, GeoInfoType Info, string Data);

        /// <summary>
        /// Imposta la posizione geografica per l'utente corrente.
        /// </summary>
        /// <param name="GeoName">Nuova posizione geografica.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks><paramref name="GeoName"/> deve essere un codice numerico a 2 lettere ISO 3166-1 oppure un codice numerico UN M.49.<br/><br/>
        /// Questa funzione scrive nel registro di sistema per uno specifico utente anzichè per una specifica applicazione, il suo uso è inteso da parte di applicazione il cui intento è cambiare le impostazioni utente.<br/><br/>
        /// Questa funzione dovrebbe essere chiamata solo se l'utente ha esplicitamente richiesto la modifica.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "SetUserGeoName", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetUserGeoName(LPWSTR GeoName);

        /// <summary>
        /// Confronta due liste enumerate di script.
        /// </summary>
        /// <param name="Flags">Opzioni di verifica.</param>
        /// <param name="LocaleScripts">Lista di località.</param>
        /// <param name="LocaleScriptsSize">Dimensione, in caratteri, di <paramref name="LocaleScripts"/>.</param>
        /// <param name="TestScripts">Lista di test.</param>
        /// <param name="TestScriptsSize">Dimensione, in caratteri, di <paramref name="TestScripts"/>.</param>
        /// <returns>true se <paramref name="TestScripts"/> non è vuota e tutti gli oggetti contenuti sono inclusi in <paramref name="LocaleScripts"/>, anche nel caso <paramref name="LocaleScripts"/> abbia più elementi, false in ogni altro caso.</returns>
        /// <remarks>L'unico valore valido per <paramref name="Flags"/> è <see cref="VS_ALLOW_LATIN"/>, se è specificato, la funzione si comporta come se "Latn" sia sempre presente in <paramref name="LocaleScripts"/>.<br/><br/>
        /// Gli script nelle liste sono stringhe di 4 caratteri seguiti da un punto e virgola, compreso l'ultimo.<br/><br/>
        /// In caso di errore la funzione può impostare i seguenti codici: <br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (<paramref name="Flags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non è valido)<br/>
        /// <see cref="ERROR_SUCCESS"/> (operazione completata ma non ci sono stati risultati)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "VerifyScripts", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL VerifyScripts(DWORD Flags, LPCWSTR LocaleScripts, int LocaleScriptsSize, LPCWSTR TestScripts, int TestScriptsSize);

        /// <summary>
        /// Trova una stringa Unicode o un suo equivalente in un'altra stringa Unicode in base a una località specificata.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Flags">Opzioni di ricerca.</param>
        /// <param name="StringSource">Stringa dove eseguire la ricerca.</param>
        /// <param name="StringSourceSize">Dimensione, in caratteri, di <paramref name="StringSource"/>.</param>
        /// <param name="StringValue">Stringa da trovare in <paramref name="StringSource"/>.</param>
        /// <param name="StringValueSize">Dimensione, in caratteri, di <paramref name="StringValue"/>.</param>
        /// <param name="FoundStringSize">Dimensione, in caratteri, della stringa trovata.</param>
        /// <param name="VersionInformation">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <param name="Reserved">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <param name="SortHandle">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <returns>Indice (basato su 0) in <paramref name="StringSource"/> se l'operazione è riuscita, -1 in caso contrario.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// <paramref name="Flags"/> può essere un valore che comprende i valori presenti nelle seguenti enumerazioni:<br/><br/>
        /// <see cref="StringSearchStartingPosition"/>: porzione dove eseguire e punto di partenza da dove iniziare la ricerca, non possono essere combinate tra loro<br/>
        /// <see cref="StringComparisonOptions"/>: applica filtri alla ricerca<br/><br/>
        /// <paramref name="StringValueSize"/> non può essere 0 o qualunque numero negativo diverso da -1, se impostato a tale valore, indica alla funzione che la stringa termina con un carattere nullo e che dovrebbe calcolare la dimensione automaticamente.<br/><br/>
        /// Il valore di <paramref name="FoundStringSize"/> è solitamente uguale a <paramref name="StringValueSize"/> tranne che nei seguenti casi:<br/><br/>
        /// Il valore di <paramref name="StringValueSize"/> è negativo<br/>
        /// Le stringhe sono equivalenti ma hanno diverse lunghezze<br/><br/>
        /// In caso di errore la funzione può impostare i seguenti codici: <br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (<paramref name="Flags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non è valido)<br/>
        /// <see cref="ERROR_SUCCESS"/> (operazione completata ma non ci sono stati risultati)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "FindNLSStringEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int FindString(LPCWSTR? LocaleName, DWORD Flags, LPCWSTR StringSource, int StringSourceSize, LPCWSTR StringValue, int StringValueSize, out int FoundStringSize, IntPtr VersionInformation, PVOID Reserved, LPARAM SortHandle);

        /// <summary>
        /// Trova una stringa Unicode in un'altra stringa Unicode per un confronto non linguistico.
        /// </summary>
        /// <param name="StartingPosition">Punto di partenza della ricerca.</param>
        /// <param name="SourceString">Stringa dove cercare <paramref name="Value"/>.</param>
        /// <param name="SourceStringSize">Dimensione, in caratteri, di <paramref name="SourceString"/>, questo valore esclude il carattere nullo finale.</param>
        /// <param name="Value">Stringa da cercare.</param>
        /// <param name="ValueSize">Dimensione, in caratteri, di <paramref name="Value"/>, questo valore esclude il carattere nullo finale.</param>
        /// <param name="IgnoreCase">Indica se ignorare la distinzione tra maiuscole e minuscole.</param>
        /// <returns>Indice (basato su 0) in <paramref name="SourceString"/> se l'operazione è riuscita, -1 in caso contrario.</returns>
        /// <remarks>Se l'operazione è riuscita, la dimensione della stringa trovata è uguale a quella di <paramref name="Value"/>.<br/><br/>
        /// I risultati di questa funzione non sono linguisticamente appropriati.<br/><br/>
        /// In caso di errore la funzione può impostare i seguenti codici: <br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (<paramref name="StartingPosition"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non è valido)<br/>
        /// <see cref="ERROR_SUCCESS"/> (operazione completata ma non ci sono stati risultati)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "FindStringOrdinal", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int FindStringOrdinal(StringSearchStartingPosition StartingPosition, LPCWSTR SourceString, int SourceStringSize, LPCWSTR Value, int ValueSize, [MarshalAs(UnmanagedType.Bool)] BOOL IgnoreCase);

        /// <summary>
        /// Recupera la versione di una specifica funzionalità NLS per una località specificata.
        /// </summary>
        /// <param name="Function">Funzionalità di cui recuperare la versione.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="VersionInformation">Struttura <see cref="NLSVersionInfo"/> che contiene le informazioni.</param>
        /// <returns>true il valore di <paramref name="VersionInformation"/> è valido, false altrimenti.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// Il campo <see cref="NLSVersionInfo.Size"/> deve essere impostato alla dimensione, in bytes, della struttura prima della chiamata della funzione.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Function"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetNLSVersionEx", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetNLSVersion(SYSNLS_FUNCTION Function, LPCWSTR? LocaleName, ref NLSVersionInfo VersionInformation);

        /// <summary>
        /// Determina se ogni carattere nella stringa ha un risultato definito per una specifica funzionalità NLS.
        /// </summary>
        /// <param name="Function">Funzionalità NLS.</param>
        /// <param name="Flags">Opzioni che determinano il comportamento della funzione, deve essere 0.</param>
        /// <param name="VersionInformationPointer">Puntatore a una struttura <see cref="NLSVersionInfo"/> che contiene le informazioni sulla versione.</param>
        /// <param name="String">Stringa da esaminare.</param>
        /// <param name="StringSize">Numero di caratteri presenti in <paramref name="String"/>.</param>
        /// <returns>true se <paramref name="String"/> è valida, false altrimenti.</returns>
        /// <remarks><paramref name="VersionInformationPointer"/> può essere <see cref="IntPtr.Zero"/>, in questo caso la funzione usa la versione corrente.<br/><br/>
        /// <paramref name="StringSize"/> può includere il carattere nullo finale.<br/>
        /// <paramref name="StringSize"/> dovrebbe avere valore -1 per indicare che <paramref name="String"/> termina con un carattere nullo, in questo caso la funzione calcola automaticamente la lunghezza della stringa.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="Function"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "IsNLSDefinedString", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL IsNLSDefinedString(SYSNLS_FUNCTION Function, DWORD Flags, IntPtr VersionInformationPointer, LPCWSTR String, int StringSize);

        /// <summary>
        /// Determina se la versione NLS è valida per una specifica funzionalità.
        /// </summary>
        /// <param name="Function">Funzionalità NLS.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="VersionInformation">Struttura <see cref="NLSVersionInfo"/> che contiene le informazioni.</param>
        /// <returns>Valore diverso da 0 se la versione è valida, 0 altrimenti.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// Inizializza la struttura <see cref="NLSVersionInfo"/> con una chiamata a <see cref="GetNLSVersion"/>.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "IsValidNLSVersion", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern DWORD IsValidNLSVersion(SYSNLS_FUNCTION Function, LPCWSTR? LocaleName, NLSVersionInfo VersionInformation);

        /// <summary>
        /// Converte una stringa in un'altra usando una specifica trasformazione, oppure genera una chiave di ordinamento per la stringa di input.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="MappingFlags">Opzioni di conversione.</param>
        /// <param name="SourceString">Stringa da convertire.</param>
        /// <param name="SourceStringSize">Dimensione, in caratteri, di <paramref name="SourceString"/>.</param>
        /// <param name="DestinationString">Buffer che riceverà la stringa convertita.</param>
        /// <param name="DestinationStringSize">Dimensione, in caratteri, di <paramref name="DestinationString"/>.</param>
        /// <param name="VersionInformation">Informazioni di versione NLS.</param>
        /// <param name="Reserved">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <param name="SortHandle">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <returns>Se la funzione viene usata per conversione, restituisce il numero di caratteri in <paramref name="DestinationString"/>.<br/>
        /// Se la funzione viene usata per generare una chiave di ordinamento, restituisce il numero di byte nella chiave.<br/>
        /// In caso di errore, restituisce 0.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// <paramref name="MappingFlags"/> può includere i valori delle seguenti enumerazioni:<br/><br/>
        /// <see cref="StringMappingTrasformation"/>, per specificare la trasformazione da eseguire<br/>
        /// <see cref="StringComparisonOptions"/> e <see cref="StringSortingOptions"/>, per alterare la trasformazione.<br/><br/>
        /// I valori <see cref="StringComparisonOptions.NORM_IGNORENONSPACE"/> e <see cref="StringComparisonOptions.NORM_IGNORESYMBOLS"/> possono essere usate da sole, in combinazione tra di loro o insieme a <see cref="StringMappingTrasformation.LCMAP_SORTKEY"/> e <see cref="StringMappingTrasformation.LCMAP_BYTEREV"/>.<br/><br/>
        /// Il resto dei valori delle enumerazioni <see cref="StringComparisonOptions"/> e <see cref="StringSortingOptions"/> possono essere usati solo con <see cref="StringMappingTrasformation.LCMAP_SORTKEY"/><br/><br/>
        /// La dimensione di <paramref name="SourceString"/> non può essere 0.<br/><br/>
        /// <paramref name="SourceStringSize"/> può includere il carattere nullo finale ma non è necessario.<br/>
        /// Può essere impostato a un valore negativo per indicare che la stringa termina con un carattere nullo, in questo caso la funzione calcola automaticamente la lunghezza, non può essere 0.<br/><br/>
        /// Se <paramref name="MappingFlags"/> contiene <see cref="StringMappingTrasformation.LCMAP_SORTKEY"/>:<br/><br/>
        /// La chiave viene memorizzata nel buffer e trattato come un array opaco di bytes, i valori possono includere 0 a qualunque posizione<br/>
        /// La stringa di destinazione può contenere un numero dispari di bytes, l'opzione <see cref="StringMappingTrasformation.LCMAP_BYTEREV"/> inverte solo un numero pari di byte<br/><br/>
        /// Se il chiamante richiede esplicitamente una parte della stringa, <paramref name="DestinationString"/> non contiene il carattere nullo finale a meno che non sia incluso in <paramref name="DestinationStringSize"/>.<br/><br/>
        /// Se l'applicazione usa la funzione per conversione, <paramref name="DestinationStringSize"/> contiene il numero di caratteri di <paramref name="DestinationString"/>, se <paramref name="SourceStringSize"/> include lo spazio per il carattere nullo finale, <paramref name="DestinationStringSize"/> deve includerlo anch'esso.<br/>
        /// Se l'applicazione usa la funzione per generare una chiave di ordinamento, <paramref name="DestinationStringSize"/> contiene il numero di byte, il valore deve includere lo spazio per il terminatore 0x00 per la chiave.<br/>
        /// <paramref name="DestinationStringSize"/> può essere impostato a 0, in questo caso la funzione non usa <paramref name="DestinationString"/> e restituisce la dimensione necessaria di <paramref name="DestinationString"/>.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (il buffer è troppo piccolo o è nullo)<br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="MappingFlags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "LCMapStringEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int ConvertString(LPCWSTR? LocaleName, DWORD MappingFlags, LPCWSTR SourceString, int SourceStringSize, IntPtr DestinationString, int DestinationStringSize, NLSVersionInfo VersionInformation, PVOID Reserved, LPARAM SortHandle);

        /// <summary>
        /// Confronta due stringhe Unicode in base alla località fornita.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="ComparisonFlags">Opzioni di confronto.</param>
        /// <param name="String1">Prima stringa da confrontare.</param>
        /// <param name="String1Size">Dimensione, in caratteri, di <paramref name="String1"/> escluso il carattere nullo finale.</param>
        /// <param name="String2">Seconda stringa da confrontare.</param>
        /// <param name="String2Size">Dimensione, in caratteri, di <paramref name="String2"/> escluso il carattere nullo finale.</param>
        /// <param name="VersionInformation">Informazioni di versione NLS.</param>
        /// <param name="Reserved">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <param name="lParam">Riservato, deve essere <see cref="IntPtr.Zero"/>.</param>
        /// <returns>Un valore dell'enumerazione <see cref="StringComparisonResult"/>.</returns>
        /// <remarks><paramref name="LocaleName"/> può avere anche i seguenti valori:<br/><br/>
        /// <see cref="LOCALE_NAME_INVARIANT"/><br/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/><br/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/><br/><br/>
        /// <paramref name="ComparisonFlags"/> può includere i valori delle enumerazioni <see cref="StringComparisonOptions"/> e <see cref="StringSortingOptions"/> oppure può essere impostato a 0 per il comportamento predefinito.<br/><br/>
        /// <paramref name="String1Size"/> e <paramref name="String2Size"/> possono avere valori negativi per indicare che le relative stringhe terminano con un carattere nullo, in questo caso la funzione calcola automaticamente la lunghezza.<br/><br/>
        /// La funzione è ottimizzata per essere eseguita alla massima velocità quando <paramref name="ComparisonFlags"/> ha valore 0 o <see cref="StringComparisonOptions.NORM_IGNORECASE"/>, <paramref name="String1Size"/> e <paramref name="String2Size"/> sono impostati a -1 e la località non supporta compressione linguistica.<br/><br/>
        /// La funzione ignora i kashidas arabi.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="ComparisonFlags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "CompareStringEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern StringComparisonResult CompareString(LPCWSTR? LocaleName, DWORD ComparisonFlags, LPCWCH String1, int String1Size, LPCWCH String2, int String2Size, NLSVersionInfo VersionInformation, PVOID Reserved, LPARAM lParam);

        /// <summary>
        /// Confronta due stringhe per verificare se la loro rappresentazione binaria è equivalente.
        /// </summary>
        /// <param name="String1">Prima stringa da confrontare.</param>
        /// <param name="String1Size">Dimensione, in caratteri, di <paramref name="String1"/>.</param>
        /// <param name="String2">Seconda stringa da confrontare.</param>
        /// <param name="String2Size">Dimensione, in caratteri, di <paramref name="String2"/>.</param>
        /// <param name="IgnoreCase">Indica se ignorare la differenza tra maiuscole e minuscole.</param>
        /// <returns>Un valore dell'enumerazione <see cref="StringComparisonResult"/>.</returns>
        /// <remarks><paramref name="String1Size"/> e <paramref name="String2Size"/> possono avere valore -1 se le stringhe terminano con un carattere nullo, in questo caso la funzione calcola la lunghezza automaticamente.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "CompareStringOrdinal", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern StringComparisonResult CompareStringOrdinal(LPCWCH String1, int String1Size, LPCWCH String2, int String2Size, [MarshalAs(UnmanagedType.Bool)] BOOL IgnoreCase);

        /// <summary>
        /// Trasforma una stringa Unicode in un'altra in base a una certa trasformazione.
        /// </summary>
        /// <param name="MappingFlags">Trasformazione da eseguire.</param>
        /// <param name="SourceString">Stringa da trasformare.</param>
        /// <param name="SourceStringSize">Dimensione, in caratteri, di <paramref name="SourceString"/> escluso il carattere nullo finale.</param>
        /// <param name="DestinationString">Buffer che riceverà la stringa trasformata.</param>
        /// <param name="DestinationStringSize">Dimensione, in caratteri, di <paramref name="DestinationString"/>.</param>
        /// <returns>Numero di caratteri della stringa trasformata incluso il carattere nullo finale se l'operazione è riuscita, 0 altrimenti.</returns>
        /// <remarks><paramref name="SourceStringSize"/> può essere negativo per indicare che <paramref name="SourceString"/> termina con un carattere nullo, in questo caso la funzione calcola automaticamente la dimensione della stringa e termina <paramref name="DestinationString"/> con un carattere nullo.<br/><br/>
        /// Se <paramref name="SourceStringSize"/> include lo spazio per il carattere nullo finale, <paramref name="DestinationStringSize"/> deve includerlo anch'esso.<br/>
        /// <paramref name="DestinationStringSize"/> può essere impostato a 0, in questo caso la funzione non utilizza <paramref name="DestinationString"/> e restituisce la dimensione necessaria, in caratteri, di <paramref name="DestinationString"/>.<br/><br/>
        /// I valori di <paramref name="SourceString"/> e <paramref name="DestinationString"/> non devono essere uguali.<br/><br/>
        /// La zona di compatibilità Unicode consise nei caratteri da 0xF900 a 0xFFEF che sono assegnati a caratteri da altri standard di codifica ma sono varianti di caratteri già presenti in Unicode.<br/>
        /// La zona di compatibilità è usta per supportare il mappaggio round-trip a quei standard, le applicazioni possono usare l'opzione <see cref="StringMappingTransformation2.MAP_FOLDCZONE"/> per evitare di supportare la duplicazione di caratteri nella zona di compatibilità.<br/><br/>
        /// In caso di errore, i possibili codici sono i seguenti:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (la dimensione di <paramref name="DestinationString"/> non è sufficiente o è nullo)
        /// <see cref="ERROR_INVALID_FLAGS"/> (il parametro <paramref name="MappingFlags"/> non è valido)<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non sono validi)<br/>
        /// <see cref="ERROR_INVALID_DATA"/> (dati non validi)<br/>
        /// <see cref="ERROR_MOD_NOT_FOUND"/> (modulo non trovato)<br/>
        /// <see cref="ERROR_OUTOFMEMORY"/> (memoria insufficiente)<br/>
        /// <see cref="ERROR_PROC_NOT_FOUND"/> (procedura non trovata)</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "FoldStringW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int ConvertString2(StringMappingTransformation2 MappingFlags, LPCWCH SourceString, int SourceStringSize, StringBuilder? DestinationString, int DestinationStringSize);
    }
}