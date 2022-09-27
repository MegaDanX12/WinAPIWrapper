using WinApiWrapper.UserInterface.NationalLanguageSupport;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Enumerazioni NLS.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Calendario.
        /// </summary>
        public enum Calendar : uint
        {
            /// <summary>
            /// Gregoriano localizzato.
            /// </summary>
            Gregorian = CalendarID.CAL_GREGORIAN,
            /// <summary>
            /// Gregoriano inglese.
            /// </summary>
            GregorianEnglish = CalendarID.CAL_GREGORIAN_US,
            /// <summary>
            /// Giapponese.
            /// </summary>
            Japan = CalendarID.CAL_JAPAN,
            /// <summary>
            /// Taiwanese.
            /// </summary>
            Taiwan = CalendarID.CAL_TAIWAN,
            /// <summary>
            /// Coreano era Tangun.
            /// </summary>
            Korea = CalendarID.CAL_KOREA,
            /// <summary>
            /// Arabico lunare (Hijri).
            /// </summary>
            ArabicLunar = CalendarID.CAL_HIJRI,
            /// <summary>
            /// Thai.
            /// </summary>
            Thai = CalendarID.CAL_THAI,
            /// <summary>
            /// Ebreo (lunare).
            /// </summary>
            HebrewLunar = CalendarID.CAL_HEBREW,
            /// <summary>
            /// Francese Middle East.
            /// </summary>
            MiddleEastFrenchGregorian = CalendarID.CAL_GREGORIAN_ME_FRENCH,
            /// <summary>
            /// Gregoriano arabo.
            /// </summary>
            ArabicGregorian = CalendarID.CAL_GREGORIAN_ARABIC,
            /// <summary>
            /// Gregoriano inglese transliterato.
            /// </summary>
            TransliteratedEnglishGregorian = CalendarID.CAL_GREGORIAN_XLIT_ENGLISH,
            /// <summary>
            /// Gregoriano francese transliterato.
            /// </summary>
            TransliteratedFrenchGregorian = CalendarID.CAL_GREGORIAN_XLIT_FRENCH,
            /// <summary>
            /// Persiano (Hijri solare).
            /// </summary>
            Persian = CalendarID.CAL_PERSIAN,
            /// <summary>
            /// UmAlQura arabico lunare (Hijri).
            /// </summary>
            UmAlQuraArabicLunar = CalendarID.CAL_UMALQURA,
            /// <summary>
            /// Tutti i calendari.
            /// </summary>
            All = CalendarID.ENUM_ALL_CALENDARS
        }

        /// <summary>
        /// Informazioni del calendario.
        /// </summary>
        public enum CalendarInformation : uint
        {
            /// <summary>
            /// Calendario alternativo.
            /// </summary>
            AlternateCalendarType = CalendarInfo.CAL_ICALINTVALUE,
            /// <summary>
            /// Valore massimo per gli anni a due cifre.
            /// </summary>
            TwoDigitYearMaxValue = CalendarInfo.CAL_ITWODIGITYEARMAX,
            /// <summary>
            /// Una o più stringhe che specificano gli offset per ogni era.
            /// </summary>
            EraOffsetRanges = CalendarInfo.CAL_IYEAROFFSETRANGE,
            /// <summary>
            /// Nome nativo abbreviato del primo giorno della settimana.
            /// </summary>
            NativeAbbreviatedFirstWeekday = CalendarInfo.CAL_SABBREVDAYNAME1,
            /// <summary>
            /// Nome nativo abbreviato del secondo giorno della settimana.
            /// </summary>
            NativeAbbreviatedSecondWeekday = CalendarInfo.CAL_SABBREVDAYNAME2,
            /// <summary>
            /// Nome nativo abbreviato del terzo giorno della settimana.
            /// </summary>
            NativeAbbreviatedThirdWeekday = CalendarInfo.CAL_SABBREVDAYNAME3,
            /// <summary>
            /// Nome nativo abbreviato del quarto giorno della settimana.
            /// </summary>
            NativeAbbreviatedFourthWeekday = CalendarInfo.CAL_SABBREVDAYNAME4,
            /// <summary>
            /// Nome nativo abbreviato del quinto giorno della settimana.
            /// </summary>
            NativeAbbreviatedFifthWeekday = CalendarInfo.CAL_SABBREVDAYNAME5,
            /// <summary>
            /// Nome nativo abbreviato del sesto giorno della settimana.
            /// </summary>
            NativeAbbreviatedSixthWeekday = CalendarInfo.CAL_SABBREVDAYNAME6,
            /// <summary>
            /// Nome nativo abbreviato del settimo giorno della settimana.
            /// </summary>
            NativeAbbreviatedSeventhWeekday = CalendarInfo.CAL_SABBREVDAYNAME7,
            /// <summary>
            /// Nome abbreviato dell'era.
            /// </summary>
            NativeAbbreviatedEraName = CalendarInfo.CAL_SABBREVERASTRING,
            /// <summary>
            /// Nome nativo abbreviato del primo mese dell'anno.
            /// </summary>
            NativeAbbreviatedFirstMonthName = CalendarInfo.CAL_SABBREVMONTHNAME1,
            /// <summary>
            /// Nome nativo abbreviato del secondo mese dell'anno.
            /// </summary>
            NativeAbbreviatedSecondMonthName = CalendarInfo.CAL_SABBREVMONTHNAME2,
            /// <summary>
            /// Nome nativo abbreviato del terzo mese dell'anno.
            /// </summary>
            NativeAbbreviatedThirdMonthName = CalendarInfo.CAL_SABBREVMONTHNAME3,
            /// <summary>
            /// Nome nativo abbreviato del quarto mese dell'anno.
            /// </summary>
            NativeAbbreviatedFourthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME4,
            /// <summary>
            /// Nome nativo abbreviato del quinto mese dell'anno.
            /// </summary>
            NativeAbbreviatedFifthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME5,
            /// <summary>
            /// Nome nativo abbreviato del sesto mese dell'anno.
            /// </summary>
            NativeAbbreviatedSixthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME6,
            /// <summary>
            /// Nome nativo abbreviato del settimo mese dell'anno.
            /// </summary>
            NativeAbbreviatedSeventhMonthName = CalendarInfo.CAL_SABBREVMONTHNAME7,
            /// <summary>
            /// Nome nativo abbreviato dell'ottavo mese dell'anno.
            /// </summary>
            NativeAbbreviatedEighthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME8,
            /// <summary>
            /// Nome nativo abbreviato del nono mese dell'anno.
            /// </summary>
            NativeAbbreviatedNinthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME9,
            /// <summary>
            /// Nome nativo abbreviato del decimo mese dell'anno.
            /// </summary>
            NativeAbbreviatedTenthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME10,
            /// <summary>
            /// Nome nativo abbreviato dell'undicesimo mese dell'anno.
            /// </summary>
            NativeAbbreviatedEleventhMonthName = CalendarInfo.CAL_SABBREVMONTHNAME11,
            /// <summary>
            /// Nome nativo abbreviato del dodicesimo mese dell'anno.
            /// </summary>
            NativeAbbreviatedTwelfthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME12,
            /// <summary>
            /// Nome nativo abbreviato del tredicesimo mese dell'anno.
            /// </summary>
            NativeAbbreviatedThirteenthMonthName = CalendarInfo.CAL_SABBREVMONTHNAME13,
            /// <summary>
            /// Nome nativo del calendario alternativo.
            /// </summary>
            AlternateCalendarNativeName = CalendarInfo.CAL_SCALNAME,
            /// <summary>
            /// Nome nativo del primo giorno della settimana.
            /// </summary>
            NativeFirstWeekday = CalendarInfo.CAL_SDAYNAME1,
            /// <summary>
            /// Nome nativo del secondo giorno della settimana.
            /// </summary>
            NativeSecondWeekday = CalendarInfo.CAL_SDAYNAME2,
            /// <summary>
            /// Nome nativo del terzo giorno della settimana.
            /// </summary>
            NativeThirdWeekday = CalendarInfo.CAL_SDAYNAME3,
            /// <summary>
            /// Nome nativo del quarto giorno della settimana.
            /// </summary>
            NativeFourthWeekday = CalendarInfo.CAL_SDAYNAME4,
            /// <summary>
            /// Nome nativo del quinto giorno della settimana.
            /// </summary>
            NativeFifthWeekday = CalendarInfo.CAL_SDAYNAME5,
            /// <summary>
            /// Nome nativo del sesto giorno della settimana.
            /// </summary>
            NativeSixthWeekday = CalendarInfo.CAL_SDAYNAME6,
            /// <summary>
            /// Nome nativo del settimo giorno della settimana.
            /// </summary>
            NativeSeventhWeekday = CalendarInfo.CAL_SDAYNAME7,
            /// <summary>
            /// Nome nativo dell'era.
            /// </summary>
            NativeEraName = CalendarInfo.CAL_SERASTRING,
            /// <summary>
            /// Formato della data lunga.
            /// </summary>
            LongDateFormat = CalendarInfo.CAL_SLONGDATE,
            /// <summary>
            /// Formato della data con solo mese e giorno.
            /// </summary>
            MonthDayFormat = CalendarInfo.CAL_SMONTHDAY,
            /// <summary>
            /// Nome nativo del primo mese dell'anno.
            /// </summary>
            NativeFirstMonthName = CalendarInfo.CAL_SMONTHNAME1,
            /// <summary>
            /// Nome nativo del secondo mese dell'anno.
            /// </summary>
            NativeSecondMonthName = CalendarInfo.CAL_SMONTHNAME2,
            /// <summary>
            /// Nome nativo del terzo mese dell'anno.
            /// </summary>
            NativeThirdMonthName = CalendarInfo.CAL_SMONTHNAME3,
            /// <summary>
            /// Nome nativo del quarto mese dell'anno.
            /// </summary>
            NativeFourthMonthName = CalendarInfo.CAL_SMONTHNAME4,
            /// <summary>
            /// Nome nativo del quinto mese dell'anno.
            /// </summary>
            NativeFifthMonthName = CalendarInfo.CAL_SMONTHNAME5,
            /// <summary>
            /// Nome nativo del sesto mese dell'anno.
            /// </summary>
            NativeSixthMonthName = CalendarInfo.CAL_SMONTHNAME6,
            /// <summary>
            /// Nome nativo del settimo mese dell'anno.
            /// </summary>
            NativeSeventhMonthName = CalendarInfo.CAL_SMONTHNAME7,
            /// <summary>
            /// Nome nativo dell'ottavo mese dell'anno.
            /// </summary>
            NativeEighthMonthName = CalendarInfo.CAL_SMONTHNAME8,
            /// <summary>
            /// Nome nativo del nono mese dell'anno.
            /// </summary>
            NativeNinthMonthName = CalendarInfo.CAL_SMONTHNAME9,
            /// <summary>
            /// Nome nativo del decimo mese dell'anno.
            /// </summary>
            NativeTenthMonthName = CalendarInfo.CAL_SMONTHNAME10,
            /// <summary>
            /// Nome nativo dell'undicesimo mese dell'anno.
            /// </summary>
            NativeEleventhMonthName = CalendarInfo.CAL_SMONTHNAME11,
            /// <summary>
            /// Nome nativo del dodicesimo mese dell'anno.
            /// </summary>
            NativeTwelfthMonthName = CalendarInfo.CAL_SMONTHNAME12,
            /// <summary>
            /// Nome nativo del tredicesimo mese dell'anno.
            /// </summary>
            NativeThirteenthMonthName = CalendarInfo.CAL_SMONTHNAME13,
            /// <summary>
            /// Formato della data corta.
            /// </summary>
            ShortDateFormat = CalendarInfo.CAL_SSHORTDATE,
            /// <summary>
            /// Nome nativo corto del primo giorno della settimana.
            /// </summary>
            NativeFirstWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME1,
            /// <summary>
            /// Nome nativo corto del secondo giorno della settimana.
            /// </summary>
            NativeSecondWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME2,
            /// <summary>
            /// Nome nativo corto del terzo giorno della settimana.
            /// </summary>
            NativeThirdWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME3,
            /// <summary>
            /// Nome nativo corto del quarto giorno della settimana.
            /// </summary>
            NativeFourthWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME4,
            /// <summary>
            /// Nome nativo corto del quinto giorno della settimana.
            /// </summary>
            NativeFifthWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME5,
            /// <summary>
            /// Nome nativo corto del sesto giorno della settimana.
            /// </summary>
            NativeSixthWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME6,
            /// <summary>
            /// Nome nativo corto del settimo giorno della settimana.
            /// </summary>
            NativeSeventhWeekdayShortName = CalendarInfo.CAL_SSHORTESTDAYNAME7,
            /// <summary>
            /// Formato della data con solo mese e anno.
            /// </summary>
            YearMonthFormat = CalendarInfo.CAL_SYEARMONTH,
            /// <summary>
            /// Data lunga senza anno, giorno della settimana e mese.
            /// </summary>
            RelativeLongDate = CalendarInfo.CAL_SRELATIVELONGDATE,
            /// <summary>
            /// Nomi delle ere giapponesi in inglese.
            /// </summary>
            /// <remarks>Valido solo per <see cref="Calendar.Japan"/>.</remarks>
            JapaneseEraEnglishNames = CalendarInfo.CAL_SENGLISHERANAME,
            /// <summary>
            /// Nomi abbreviati delle ere giapponesi in inglese.
            /// </summary>
            /// <remarks>Valido solo per <see cref="Calendar.Japan"/>.</remarks>
            JapaneseEraAbbreviatedEnglishNames = CalendarInfo.CAL_SENGLISHABBREVERANAME,
            /// <summary>
            /// Primo anno giapponese.
            /// </summary>
            JapaneseFirstYear = CalendarInfo.CAL_SJAPANESEFIRSTYEAR
        }

        /// <summary>
        /// Formato data.
        /// </summary>
        public enum DateFormat : uint
        {
            /// <summary>
            /// Data corta.
            /// </summary>
            Short = NationalLanguageSupportEnumerations.DateFormat.DATE_SHORTDATE,
            /// <summary>
            /// Data lunga.
            /// </summary>
            Long = NationalLanguageSupportEnumerations.DateFormat.DATE_LONGDATE,
            /// <summary>
            /// Data con solo mese e anno.
            /// </summary>
            YearMonth = NationalLanguageSupportEnumerations.DateFormat.DATE_YEARMONTH,
            /// <summary>
            /// Data con solo mese e giorno.
            /// </summary>
            MonthDay = NationalLanguageSupportEnumerations.DateFormat.DATE_MONTHDAY,
        }

        /// <summary>
        /// Tipo di località.
        /// </summary>
        public enum LocaleType : uint
        {
            /// <summary>
            /// Tutte.
            /// </summary>
            All = NationalLanguageSupportEnumerations.LocaleType.LOCALE_ALL,
            /// <summary>
            /// Località che hanno un ordinamento alternativo.
            /// </summary>
            AlternateSortOrder = NationalLanguageSupportEnumerations.LocaleType.LOCALE_ALTERNATE_SORTS,
            /// <summary>
            /// Località neutrale (senza regione).
            /// </summary>
            Neutral = NationalLanguageSupportEnumerations.LocaleType.LOCALE_NEUTRALDATA,
            /// <summary>
            /// Località specifica (con regione).
            /// </summary>
            Specific = NationalLanguageSupportEnumerations.LocaleType.LOCALE_SPECIFICDATA,
            /// <summary>
            /// Località supplementali.
            /// </summary>
            Supplemental = NationalLanguageSupportEnumerations.LocaleType.LOCALE_SUPPLEMENTAL,
            /// <summary>
            /// Località integrate oppure sostituzioni per esse.
            /// </summary>
            Windows = NationalLanguageSupportEnumerations.LocaleType.LOCALE_WINDOWS,
            /// <summary>
            /// Località che ha sostituito una località inclusa.
            /// </summary>
            Replacement = NationalLanguageSupportEnumerations.LocaleType.LOCALE_REPLACEMENT
        }

        /// <summary>
        /// Formato dell'ora.
        /// </summary>
        [Flags]
        public enum TimeFormat : uint
        {
            /// <summary>
            /// Ora lunga dell'utente corrente.
            /// </summary>
            CurrentUseLongTime = NationalLanguageSupportEnumerations.TimeFormat.CurrentLongTime,
            /// <summary>
            /// Non usare i secondi o i minuti.
            /// </summary>
            NoMinutesOrSeconds = NationalLanguageSupportEnumerations.TimeFormat.TIME_NOMINUTESORSECONDS,
            /// <summary>
            /// Non usare i secondi.
            /// </summary>
            NoSeconds = NationalLanguageSupportEnumerations.TimeFormat.TIME_NOSECONDS,
            /// <summary>
            /// Non usare gli indicatori orari.
            /// </summary>
            NoTimeMarkers = NationalLanguageSupportEnumerations.TimeFormat.TIME_NOTIMEMARKER,
            /// <summary>
            /// Usa sempre il formato a 24 ore.
            /// </summary>
            Force24HourFormat = NationalLanguageSupportEnumerations.TimeFormat.TIME_FORCE24HOURFORMAT
        }

        /// <summary>
        /// Formato del numero negativo per la moneta.
        /// </summary>
        public enum NegativeCurrencyFormat : uint
        {
            /// <summary>
            /// ($1.1)
            /// </summary>
            Mode0 = NegativeCurrencyMode.Mode0,
            /// <summary>
            /// -$1.1
            /// </summary>
            Mode1 = NegativeCurrencyMode.Mode1,
            /// <summary>
            /// $-1.1
            /// </summary>
            Mode2 = NegativeCurrencyMode.Mode2,
            /// <summary>
            /// $1.1-
            /// </summary>
            Mode3 = NegativeCurrencyMode.Mode3,
            /// <summary>
            /// (1.1$)
            /// </summary>
            Mode4 = NegativeCurrencyMode.Mode4,
            /// <summary>
            /// -1.1$
            /// </summary>
            Mode5 = NegativeCurrencyMode.Mode5,
            /// <summary>
            /// 1.1-$
            /// </summary>
            Mode6 = NegativeCurrencyMode.Mode6,
            /// <summary>
            /// 1.1$-
            /// </summary>
            Mode7 = NegativeCurrencyMode.Mode7,
            /// <summary>
            /// -1.1$
            /// </summary>
            Mode8 = NegativeCurrencyMode.Mode8,
            /// <summary>
            /// -$ 1.1
            /// </summary>
            Mode9 = NegativeCurrencyMode.Mode9,
            /// <summary>
            /// 1.1 $-
            /// </summary>
            Mode10 = NegativeCurrencyMode.Mode10,
            /// <summary>
            /// $ 1.1-
            /// </summary>
            Mode11 = NegativeCurrencyMode.Mode11,
            /// <summary>
            /// $ -1.1
            /// </summary>
            Mode12 = NegativeCurrencyMode.Mode12,
            /// <summary>
            /// 1.1- $
            /// </summary>
            Mode13 = NegativeCurrencyMode.Mode13,
            /// <summary>
            /// ($ 1.1)
            /// </summary>
            Mode14 = NegativeCurrencyMode.Mode14,
            /// <summary>
            /// (1.1 $)
            /// </summary>
            Mode15 = NegativeCurrencyMode.Mode15
        }

        /// <summary>
        /// Posizione del simbolo in un valore monetario positivo.
        /// </summary>
        public enum SymbolPositionPositiveCurrency : uint
        {
            /// <summary>
            /// $1.1
            /// </summary>
            PrefixNoSeparation = NationalLanguageSupportEnumerations.SymbolPositionPositiveCurrency.PrefixNoSeparation,
            /// <summary>
            /// 1.1$
            /// </summary>
            SuffixNoSeparation = NationalLanguageSupportEnumerations.SymbolPositionPositiveCurrency.SuffixNoSeparation,
            /// <summary>
            /// $ 1.1
            /// </summary>
            PrefixSingleCharacterSeparation = NationalLanguageSupportEnumerations.SymbolPositionPositiveCurrency.PrefixSingleCharacterSeparation,
            /// <summary>
            /// 1.1 $
            /// </summary>
            SuffixSingleCharacterSeparation = NationalLanguageSupportEnumerations.SymbolPositionPositiveCurrency.SuffixSingleCharacterSeparation
        }

        /// <summary>
        /// Informazione geografica.
        /// </summary>
        /// <remarks>Le informazioni sono sotto forma di stringa se non indicato diversamente.</remarks>
        public enum GeoInfo : uint
        {
            /// <summary>
            /// Latitudine.
            /// </summary>
            /// <remarks>L'informazione è sotto forma di un numero a virgola mobile.</remarks>
            Latitude = SYSGEOTYPE.GEO_LATITUDE,
            /// <summary>
            /// Longitudine.
            /// </summary>
            /// <remarks>L'informazione è sotto forma di un numero a virgola mobile.</remarks>
            Longitude = SYSGEOTYPE.GEO_LONGITUDE,
            /// <summary>
            /// Codice ISO a 2 lettere.
            /// </summary>
            ISO2Code = SYSGEOTYPE.GEO_ISO2,
            /// <summary>
            /// Codice ISO a 3 lettere.
            /// </summary>
            ISO3Code = SYSGEOTYPE.GEO_ISO3,
            /// <summary>
            /// Nome comune della nazione.
            /// </summary>
            FriendlyName = SYSGEOTYPE.GEO_FRIENDLYNAME,
            /// <summary>
            /// Nome ufficiale della nazione.
            /// </summary>
            OfficialName = SYSGEOTYPE.GEO_OFFICIALNAME,
            /// <summary>
            /// Codice ISO a 3 lettere.
            /// </summary>
            ISOUnitedNationsNumber = SYSGEOTYPE.GEO_ISO_UN_NUMBER,
            /// <summary>
            /// ID della nazione padre.
            /// </summary>
            ParentID = SYSGEOTYPE.GEO_PARENT,
            /// <summary>
            /// Prefisso telefonico.
            /// </summary>
            DialingCode = SYSGEOTYPE.GEO_DIALINGCODE,
            /// <summary>
            /// Simbolo per la valuta.
            /// </summary>
            CurrencySymbol = SYSGEOTYPE.GEO_CURRENCYSYMBOL,
            /// <summary>
            /// Codice a tre lettere della valuta.
            /// </summary>
            CurrencyCode = SYSGEOTYPE.GEO_CURRENCYCODE,
            /// <summary>
            /// Codice ISO 3166-1 oppure codice UN M.49.
            /// </summary>
            ID = SYSGEOTYPE.GEO_NAME
        }

        /// <summary>
        /// Informazioni località.
        /// </summary>
        public enum LocaleInfo : uint
        {
            /// <summary>
            /// Nome completo localizzato della lingua dell'interfaccia utente.
            /// </summary>
            /// <remarks>la dimensione massima di questa stringa è di 80 caratteri.</remarks>
            LocalizedDisplayName = GeoInfoType.LOCALE_SLOCALIZEDDISPLAYNAME,
            /// <summary>
            /// Nome visualizzato della località in inglese.
            /// </summary>
            EnglishDisplayName = GeoInfoType.LOCALE_SENGLISHDISPLAYNAME,
            /// <summary>
            /// Nome visualizzato della località nella lingua nativa.
            /// </summary>
            NativeDisplayName = GeoInfoType.LOCALE_SNATIVEDISPLAYNAME,
            /// <summary>
            /// Nome primario completo localizzato della lingua dell'interfaccia utente incluse nel nome visualizzato localizzato.
            /// </summary>
            LocalizedLanguageName = GeoInfoType.LOCALE_SLOCALIZEDLANGUAGENAME,
            /// <summary>
            /// Nome inglese della lingua, come indicato dallo standard ISO 639.
            /// </summary>
            EnglishLanguageName = GeoInfoType.LOCALE_SENGLISHLANGUAGENAME,
            /// <summary>
            /// Nome nativo della lingua.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri.</remarks>
            NativeLanguageName = GeoInfoType.LOCALE_SNATIVELANGUAGENAME,
            /// <summary>
            /// Nome completo localizzato della nazione/regione.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri.</remarks>
            LocalizedCountryName = GeoInfoType.LOCALE_SLOCALIZEDCOUNTRYNAME,
            /// <summary>
            /// Nome inglese della nazione/regione.
            /// </summary>
            EnglishCountryName = GeoInfoType.LOCALE_SENGLISHCOUNTRYNAME,
            /// <summary>
            /// Nome nativo della nazione/regione.
            /// </summary>
            /// <remarks>La dimensiona massima di questa stringa è di 80 caratteri, incluso il carettere nullo finale.</remarks>
            NativeCountryName = GeoInfoType.LOCALE_SNATIVECOUNTRYNAME,
            /// <summary>
            /// Prefisso telefonico internazionale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 6 caratteri, incluso il carattere nullo finale.</remarks>
            DialingCode = GeoInfoType.LOCALE_IDIALINGCODE,
            /// <summary>
            /// Carattere/i usati per separare oggetti in una lista.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            ListSeparator = GeoInfoType.LOCALE_SLIST,
            /// <summary>
            /// Sistema di misura.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di due caratteri, incluso il carattere nullo finale.<br/><br/>
            /// 0 se viene usato il sistema metrico decimale, 1 se viene usato il sistema statunitense.</remarks>
            MeasuringSystem = GeoInfoType.LOCALE_IMEASURE,
            /// <summary>
            /// Carattere/i usati come separatore decimale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            DecimalSeparator = GeoInfoType.LOCALE_SDECIMAL,
            /// <summary>
            /// Caratteri usati per separare i gruppi di cifre alla sinistra di un decimale.
            /// </summary>
            /// <remarks>La dimensiona massima della stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            ThousandSeparator = GeoInfoType.LOCALE_STHOUSAND,
            /// <summary>
            /// Dimensioni per ogni gruppo di cifre alla sinistra di un decimale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 10 caratteri, incluso il carattere nullo finale.<br/>
            /// Deve essere indicata la dimensione di ogni gruppo, le dimensioni sono separate da punti e virgola.<br/>
            /// Se l'ultimo valore è 0, il valore precedente è ripetuto.<br/>
            /// Località Indic raggruppano le prime migliaia e poi ragguppano per centinaia.</remarks>
            Grouping = GeoInfoType.LOCALE_SGROUPING,
            /// <summary>
            /// Numero di cifre frazionarie dopo il separatore decimale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è 2 caratteri, incluso il carattere nullo finale.</remarks>
            FractionalDigitsCount = GeoInfoType.LOCALE_IDIGITS,
            /// <summary>
            /// Presenza di zero iniziali.
            /// </summary>
            /// <remarks>0 se non ci sono zero iniziali, 1 in caso contrario.</remarks>
            LeadingZerosAreUsed = GeoInfoType.LOCALE_ILZERO,
            /// <summary>
            /// Formato per i numeri negativi.
            /// </summary>
            /// <remarks>I valori sono i seguenti (seguiti da esempi):<br/><br/>
            /// 0: (1.1)<br/>
            /// 1: -1.1<br/>
            /// 2: - 1.1<br/>
            /// 3: 1.1-<br/>
            /// 4: 1.1 -</remarks>
            NegativeNumberFormat = GeoInfoType.LOCALE_INEGNUMBER,
            /// <summary>
            /// Equivalenti nativi dei numeri ASCII da 0 a 9.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 11 caratteri, incluso il carattere nullo finale.</remarks>
            NativeDigits = GeoInfoType.LOCALE_SNATIVEDIGITS,
            /// <summary>
            /// Simbolo monetario.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 13 caratteri, incluso il carattere nullo finale.</remarks>
            CurrencySymbol = GeoInfoType.LOCALE_SCURRENCY,
            /// <summary>
            /// Tre caratteri che rappresentano il simbolo monetario internazionale come specificato in ISO 4217, seguiti dal carattere che separa questa stringa dalla quantità.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            InternationalCurrencySymbol = GeoInfoType.LOCALE_SINTLSYMBOL,
            /// <summary>
            /// Carattere/i usato/i come separatore decimale per la valuta.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            CurrencyDecimalSeparator = GeoInfoType.LOCALE_SMONDECIMALSEP,
            /// <summary>
            /// Carattere/i usato/i come separatore tra gruppi di cifre alla sinistra del decimale per la valuta.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            CurrencyThousandSeparator = GeoInfoType.LOCALE_SMONTHOUSANDSEP,
            /// <summary>
            /// Dimensioni per ogni gruppo di cifre alla sinistra di un decimale per la valuta.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 10 caratteri, incluso il carattere nullo finale.<br/>
            /// Deve essere indicata la dimensione di ogni gruppo, le dimensioni sono separate da punti e virgola.<br/>
            /// Se l'ultimo valore è 0, il valore precedente è ripetuto.<br/>
            /// Località Indic raggruppano le prime migliaia e poi ragguppano per centinaia.</remarks>
            CurrencyGroupingSeparator = GeoInfoType.LOCALE_SMONGROUPING,
            /// <summary>
            /// Numero di cifre frazionarie per il formato monetario locale.
            /// </summary>
            /// <remarks>La dimensiona massimo della stringa è di due caratteri, incluso il carattere nullo finale.</remarks>
            CurrencyFractionalDigitsCount = GeoInfoType.LOCALE_ICURRDIGITS,
            /// <summary>
            /// Posizione del simbolo della valuta in un valore positivo.
            /// </summary>
            /// <remarks>I valori possibili sono:<br/><br/>
            /// 0: Prefisso, non separato, es. $1.1<br/>
            /// 1: Suffisso, non separato, es. 1.1$<br/>
            /// 2: Prefisso, separato da uno spazio, es. $ 1.1<br/>
            /// 3: Suffisso, separato da uno spazio, es. 1.1 $</remarks>
            PositiveCurrencySymbolPosition = GeoInfoType.LOCALE_ICURRENCY,
            /// <summary>
            /// Formato valuta negativa.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti (con relativi esempi):<br/><br/>
            /// 0: ($1.1)<br/>
            /// 1: -$1.1<br/>
            /// 2: $-1.1<br/>
            /// 3: $1.1-<br/>
            /// 4: (1.1$)<br/>
            /// 5: -1.1$<br/>
            /// 6: 1.1-$<br/>
            /// 7: 1.1$-<br/>
            /// 8: -1.1$<br/>
            /// 9: -$ 1.1<br/>
            /// 10: 1.1 $-<br/>
            /// 11: $ -1.1<br/>
            /// 12: $ -1.1<br/>
            /// 13: 1.1- $<br/>
            /// 14: ($ 1.1)<br/>
            /// 15: (1.1 $)</remarks>
            NegativeCurrencyFormat = GeoInfoType.LOCALE_INEGCURR,
            /// <summary>
            /// Stringa di formato per la data corta.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            ShortDateFormat = GeoInfoType.LOCALE_SSHORTDATE,
            /// <summary>
            /// Stringa di formato per la data lunga.
            /// </summary>
            /// <remarks>La dimensiona massima per questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LongDateFormat = GeoInfoType.LOCALE_SLONGDATE,
            /// <summary>
            /// Stringa di formato per le ore.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            TimeFormat = GeoInfoType.LOCALE_STIMEFORMAT,
            /// <summary>
            /// Stringa per il designatore AM.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 15 carattere, incluso il carattere nullo finale.</remarks>
            AMDesignator = GeoInfoType.LOCALE_SAM,
            /// <summary>
            /// Stringa per il designatore PM.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 15 carattere, incluso il carattere nullo finale.</remarks>
            PMDesignator = GeoInfoType.LOCALE_SPM,
            /// <summary>
            /// Tipo di calendario.
            /// </summary>
            /// <remarks>I valori possibili sono inclusi nell'enumerazione <see cref="CalendarInfo"/>.</remarks>
            CalendarType = GeoInfoType.LOCALE_ICALENDARTYPE,
            /// <summary>
            /// Tipo di calendario facoltativo.
            /// </summary>
            /// <remarks>I valori possibili sono inclusi nell'enumerazione <see cref="CalendarID"/>.</remarks>
            OptionalCalendarType = GeoInfoType.LOCALE_IOPTIONALCALENDAR,
            /// <summary>
            /// Primo giorno della settimana come numero.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: <see cref="FirstWeekday"/><br/>
            /// 1: <see cref="SecondWeekday"/><br/>
            /// 2: <see cref="ThirdWeekday"/><br/>
            /// 3: <see cref="FourthWeekday"/><br/>
            /// 4: <see cref="FifthWeekday"/><br/>
            /// 5: <see cref="SixthWeekday"/><br/>
            /// 6: <see cref="SeventhWeekday"/></remarks>
            FirstDayOfTheWeek = GeoInfoType.LOCALE_IFIRSTDAYOFWEEK,
            /// <summary>
            /// Prima settimanta dell'anno.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: Settimana che contiene 1/1<br/>
            /// 1: Prima settimana completa che segue 1/1<br/>
            /// 2: Prima settimana che contiene almeno quattro giorni, compatibile con ISO 8601.</remarks>
            FirstWeekOfYear = GeoInfoType.LOCALE_IFIRSTWEEKOFYEAR,
            /// <summary>
            /// Nome nativo per Lunedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            FirstWeekday = GeoInfoType.LOCALE_SDAYNAME1,
            /// <summary>
            /// Nome nativo per Martedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            SecondWeekday = GeoInfoType.LOCALE_SDAYNAME2,
            /// <summary>
            /// Nome nativo per Mercoledì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            ThirdWeekday = GeoInfoType.LOCALE_SDAYNAME3,
            /// <summary>
            /// Nome nativo per Giovedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            FourthWeekday = GeoInfoType.LOCALE_SDAYNAME4,
            /// <summary>
            /// Nome nativo per Venerdì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            FifthWeekday = GeoInfoType.LOCALE_SDAYNAME5,
            /// <summary>
            /// Nome nativo per Sabato.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            SixthWeekday = GeoInfoType.LOCALE_SDAYNAME6,
            /// <summary>
            /// Nome nativo per Domenica.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            SeventhWeekday = GeoInfoType.LOCALE_SDAYNAME7,
            /// <summary>
            /// Nome nativo abbreviato per Lunedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedFirstWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME1,
            /// <summary>
            /// Nome nativo abbreviato per Martedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedSecondWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME2,
            /// <summary>
            /// Nome nativo abbreviato per Mercoledì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedThirdWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME3,
            /// <summary>
            /// Nome nativo abbreviato per Giovedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedFourthWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME4,
            /// <summary>
            /// Nome nativo abbreviato per Venerdì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedFifthWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME5,
            /// <summary>
            /// Nome nativo abbreviato per Sabato.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedSixthWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME6,
            /// <summary>
            /// Nome nativo abbreviato per Domenica.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedSeventhWeekday = GeoInfoType.LOCALE_SABBREVDAYNAME7,
            /// <summary>
            /// Nome lungo nativo per Gennaio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            FirstMonth = GeoInfoType.LOCALE_SMONTHNAME1,
            /// <summary>
            /// Nome lungo nativo per Febbraio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            SecondMonth = GeoInfoType.LOCALE_SMONTHNAME2,
            /// <summary>
            /// Nome lungo nativo per Marzo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            ThirdMonth = GeoInfoType.LOCALE_SMONTHNAME3,
            /// <summary>
            /// Nome lungo nativo per Aprile.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            FourthMonth = GeoInfoType.LOCALE_SMONTHNAME4,
            /// <summary>
            /// Nome lungo nativo per Maggio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            FifthMonth = GeoInfoType.LOCALE_SMONTHNAME5,
            /// <summary>
            /// Nome lungo nativo per Giugno.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            SixthMonth = GeoInfoType.LOCALE_SMONTHNAME6,
            /// <summary>
            /// Nome lungo nativo per Luglio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            SeventhMonth = GeoInfoType.LOCALE_SMONTHNAME7,
            /// <summary>
            /// Nome lungo nativo per Agosto.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            EighthMonth = GeoInfoType.LOCALE_SMONTHNAME8,
            /// <summary>
            /// Nome lungo nativo per Settembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            NinthMonth = GeoInfoType.LOCALE_SMONTHNAME9,
            /// <summary>
            /// Nome lungo nativo per Ottobre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            TenthMonth = GeoInfoType.LOCALE_SMONTHNAME10,
            /// <summary>
            /// Nome lungo nativo per Novembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            EleventhMonth = GeoInfoType.LOCALE_SMONTHNAME11,
            /// <summary>
            /// Nome lungo nativo per Dicembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            TwelfthMonth = GeoInfoType.LOCALE_SMONTHNAME12,
            /// <summary>
            /// Nome lungo nativo per un tredicesimo mese, se esiste.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            ThirteenthMonth = GeoInfoType.LOCALE_SMONTHNAME13,
            /// <summary>
            /// Nome abbreviato nativo per Gennaio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedFirstMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME1,
            /// <summary>
            /// Nome abbreviato nativo per Febbraio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedSecondMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME2,
            /// <summary>
            /// Nome abbreviato nativo per Marzo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedThirdMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME3,
            /// <summary>
            /// Nome abbreviato nativo per Aprile.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedFourthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME4,
            /// <summary>
            /// Nome abbreviato nativo per Maggio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedFifthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME5,
            /// <summary>
            /// Nome abbreviato nativo per Giugno.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedSixthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME6,
            /// <summary>
            /// Nome abbreviato nativo per Luglio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedSeventhMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME7,
            /// <summary>
            /// Nome abbreviato nativo per Agosto.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedEighthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME8,
            /// <summary>
            /// Nome abbreviato nativo per Settembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedNinthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME9,
            /// <summary>
            /// Nome abbreviato nativo per Ottobre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedTenthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME10,
            /// <summary>
            /// Nome abbreviato nativo per Novembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedEleventhMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME11,
            /// <summary>
            /// Nome abbreviato nativo per Dicembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedTwelfthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME12,
            /// <summary>
            /// Nome abbreviato nativo per un tredicesimo mese, se esiste.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            AbbreviatedThirteenthMonth = GeoInfoType.LOCALE_SABBREVMONTHNAME13,
            /// <summary>
            /// Stringa localizzata per il simbolo positivo per la località.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 5 caratteri, incluso il carattere nullo finale.</remarks>
            PositiveSign = GeoInfoType.LOCALE_SPOSITIVESIGN,
            /// <summary>
            /// Stringa localizzata per il simbolo negativo per la località.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 5 caratteri, incluso il carattere nullo finale.</remarks>
            NegativeSign = GeoInfoType.LOCALE_SNEGATIVESIGN,
            /// <summary>
            /// Indice del simbolo positivo in un valore monetario.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 1: Il segno precede il numero<br/>
            /// 2: Il segno segue il numero<br/>
            /// 3: Il segno precede il simbolo della valuta<br/>
            /// 4: Il segno segue il simbolo della valuta</remarks>
            CurrencyPositiveSignPosition = GeoInfoType.LOCALE_IPOSSIGNPOSN,
            /// <summary>
            /// Indice del simbolo negativo in un valore monetario.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: Le parentesi circondano la quantità e il simbolo della valuta<br/>
            /// 1: Il segno precede il numero<br/>
            /// 2: Il segno segue il numero<br/>
            /// 3: Il segno precede il simbolo della valuta<br/>
            /// 4: Il segno segue il simbolo della valuta</remarks>
            CurrencyNegativeSignPosition = GeoInfoType.LOCALE_INEGSIGNPOSN,
            /// <summary>
            /// Posizione del simbolo della valuta in un valore positivo.
            /// </summary>
            /// <remarks>0 se il simbolo segue il valore, 1 se, invece, il simbolo precede il valore.</remarks>
            CurrencyPositiveSymbolPosition = GeoInfoType.LOCALE_IPOSSYMPRECEDES,
            /// <summary>
            /// Separazione del simbolo della valuta in un valore positivo.
            /// </summary>
            /// <remarks>0 se il simbolo non è separato da una spazio, 1 in caso contrario.</remarks>
            PositiveCurrencySymbolSeparatedBySpace = GeoInfoType.LOCALE_IPOSSEPBYSPACE,
            /// <summary>
            /// Posizione del simbolo della valuta in un valore negativo.
            /// </summary>
            /// <remarks>0 se il simbolo segue il valore, 1 se, invece, il simbolo precede il valore.</remarks>
            CurrencySymbolPosition = GeoInfoType.LOCALE_INEGSYMPRECEDES,
            /// <summary>
            /// Separazione del simbolo della valuta in un valore negativo.
            /// </summary>
            /// <remarks>0 se il simbolo non è separato da una spazio, 1 in caso contrario.</remarks>
            NegativeCurrencySymbolSeparatedBySpace = GeoInfoType.LOCALE_INEGSEPBYSPACE,
            /// <summary>
            /// Uno specifico modello di bit che determina la relazione tra la copertura di caratteri necessaria per supportate la località e i contenuti del font.
            /// </summary>
            /// <remarks>Un'istanza di <see cref="ManagedInfoClasses.FontSignature"/> raccoglie i dati di questo valore.</remarks>
            FontSignature = GeoInfoType.LOCALE_FONTSIGNATURE,
            /// <summary>
            /// Nome abbreviato della lingua basato sui valori dello standard ISO 639, in minuscolo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            ISO639LanguageName = GeoInfoType.LOCALE_SISO639LANGNAME,
            /// <summary>
            /// Nome della nazione/regione, basato sullo standard ISO 3166.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            ISO3166CountryName = GeoInfoType.LOCALE_SISO3166CTRYNAME,
            /// <summary>
            /// Dimensione predefinita della carta associata con la località.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 1: Lettera US<br/>
            /// 5: carta legale US<br/>
            /// 8: A3<br/>
            /// 9: A4</remarks>
            PaperSize = GeoInfoType.LOCALE_IPAPERSIZE,
            /// <summary>
            /// Nome inglese completo della valuta associata alla località.
            /// </summary>
            EnglishCurrencyName = GeoInfoType.LOCALE_SENGCURRNAME,
            /// <summary>
            /// Nome nativo completo della valuta associata alla località.
            /// </summary>
            NativeCurrencyName = GeoInfoType.LOCALE_SNATIVECURRNAME,
            /// <summary>
            /// Stringa di formato anno-mese per la località.
            /// </summary>
            /// <remarks>La dimensiona massima di caratteri di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            YearMonthFormat = GeoInfoType.LOCALE_SYEARMONTH,
            /// <summary>
            /// Nome della località da usare per l'ordinamento o il comportamento relativamente alle maiuscole.
            /// </summary>
            SortingName = GeoInfoType.LOCALE_SSORTNAME,
            /// <summary>
            /// Forma delle cifre.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: sostituzione basato sul contesto<br/>
            /// 1: nessuna sostituzione<br/>
            /// 2: sostituzione nativa, in base a <see cref="NativeDigits"/>.</remarks>
            DigitSubstitutionType = GeoInfoType.LOCALE_IDIGITSUBSTITUTION,
            /// <summary>
            /// Nome località, tag multi parte che la identifica in modo univoco.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è 85, incluso il carattere nullo finale.<br/><br/>
            /// Il tag è basato sulle convenzioni del documento IETF BCP 47.</remarks>
            UniqueLocaleTag = GeoInfoType.LOCALE_SNAME,
            /// <summary>
            /// Stringa di formato per la durata.
            /// </summary>
            DurationFormat = GeoInfoType.LOCALE_SDURATION,
            /// <summary>
            /// Nome nativo corto del primo giorno della settimana.
            /// </summary>
            ShortestFirstWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME1,
            /// <summary>
            /// Nome nativo corto del secondo giorno della settimana.
            /// </summary>
            ShortestSecondWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME2,
            /// <summary>
            /// Nome nativo corto del terzo giorno della settimana.
            /// </summary>
            ShortestThirdWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME3,
            /// <summary>
            /// Nome nativo corto del quarto giorno della settimana.
            /// </summary>
            ShortestFourthWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME4,
            /// <summary>
            /// Nome nativo corto del quinto giorno della settimana.
            /// </summary>
            ShortestFifthWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME5,
            /// <summary>
            /// Nome nativo corto del sesto giorno della settimana.
            /// </summary>
            ShortestSixthWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME6,
            /// <summary>
            /// Nome nativo corto del settimo giorno della settimana.
            /// </summary>
            ShortestSeventhWeekday = GeoInfoType.LOCALE_SSHORTESTDAYNAME7,
            /// <summary>
            /// Nome ISO a tre lettere della lingua, minuscolo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            ISOThreeLetterRegionName = GeoInfoType.LOCALE_SISO639LANGNAME2,
            /// <summary>
            /// Nome ISO a tre lettere della regione, minuscolo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            ISOThreeLetterCountryName = GeoInfoType.LOCALE_SISO3166CTRYNAME2,
            /// <summary>
            /// Valore per "Not a number".
            /// </summary>
            NotANumber = GeoInfoType.LOCALE_SNAN,
            /// <summary>
            /// Valore per "infinito positivo".
            /// </summary>
            PositiveInfinity = GeoInfoType.LOCALE_SPOSINFINITY,
            /// <summary>
            /// Valore per "infinito negativo".
            /// </summary>
            NegativeInfinity = GeoInfoType.LOCALE_SNEGINFINITY,
            /// <summary>
            /// Lista di script, usando la notazione a 4 caratteri di ISO 15924.
            /// </summary>
            /// <remarks>la lista è in ordine alfabetico, tutti i nomi, compreso l'ultimo sono seguiti da un punto e virgola.</remarks>
            ISO15924ScriptList = GeoInfoType.LOCALE_SSCRIPTS,
            /// <summary>
            /// Località di fallback, usata dal caricatore risorse.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è 85, incluso il carattere nullo finale.</remarks>
            FallbackLocale = GeoInfoType.LOCALE_SPARENT,
            /// <summary>
            /// Località preferita da usare per la visualizzazione del testo nella console.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è 85, incluso il carattere nullo finale.</remarks>
            ConsoleFallbackName = GeoInfoType.LOCALE_SCONSOLEFALLBACKNAME,
            /// <summary>
            /// Direzione di lettura.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: lettura da sinistra a destra<br/>
            /// 1: lettura da destra a sinistra<br/>
            /// 2: lettura verticale dall'alto verso il basso, con colonne che vanno da destra verso sinistra, oppure lettura in linee orizzontali da sinistra a destra.
            /// 3: lettura verticale dall'alto verso il basso cono colonne che vanno da sinistra a destra.</remarks>
            ReadingLayout = GeoInfoType.LOCALE_IREADINGLAYOUT,
            /// <summary>
            /// Tipo di località.
            /// </summary>
            /// <remarks>0 indica una località specifica, 1 indica una località neutrale.</remarks>
            IsNeutralLocale = GeoInfoType.LOCALE_INEUTRAL,
            /// <summary>
            /// Stringa di formato per la percentuale negativa.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti (con relativi esempi):<br/><br/>
            /// 0: segno negativo, numero, spazio, percentuale<br/>
            /// 1: segno negativo, numero, percentuale<br/>
            /// 2: segno negativo, percentuale, numero<br/>
            /// 3: percentuale, segno negativo, numero<br/>
            /// 4: percentuale, numero, segno negativo<br/>
            /// 5: numero, segno negativo, percentuale<br/>
            /// 6: numero, percentuale, segno negativo<br/>
            /// 7: segno negativo, percentuale, spazio, numero<br/>
            /// 8: numero, spazio, percentuale, segno negativo<br/>
            /// 9: percentuale, spazio, numero, segno negativo<br/>
            /// 10: percentuale, spazio, segno negativo, numero<br/>
            /// 11: numero, segno negativo, spazio, percentuale</remarks>
            NegativePercentageFormat = GeoInfoType.LOCALE_INEGATIVEPERCENT,
            /// <summary>
            /// Stringa di formato per la percentuale positiva.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: numero, spazio, percentuale<br/>
            /// 1: numero, percentuale<br/>
            /// 2: percentuale, numero<br/>
            /// 3: percentuale, spazio, numero</remarks>
            PositivePercentageFormat = GeoInfoType.LOCALE_IPOSITIVEPERCENT,
            /// <summary>
            /// Simbolo usato per indicare la percentuale.
            /// </summary>
            /// <remarks>La stringa può avere fino a tre caratteri.</remarks>
            PercentSymbol = GeoInfoType.LOCALE_SPERCENT,
            /// <summary>
            /// Simbolo usato per indicare il permille.
            /// </summary>
            PermilleSymbol = GeoInfoType.LOCALE_SPERMILLE,
            /// <summary>
            /// Stringa di formato per visualizzare solo il mese e il giorno.
            /// </summary>
            MonthDayFormat = GeoInfoType.LOCALE_SMONTHDAY,
            /// <summary>
            /// Stringa di formato per l'ora corta.
            /// </summary>
            /// <remarks>Possono essere restituiti più formati, separati dal punto e virgola.</remarks>
            ShortTimeFormat = GeoInfoType.LOCALE_SSHORTTIME,
            /// <summary>
            /// Tag di lingua OpenType usato per recuperare le funzionalità tipografiche culturalmente appropriate.
            /// </summary>
            OpenTypeLanguageTag = GeoInfoType.LOCALE_SOPENTYPELANGUAGETAG,
            /// <summary>
            /// Nome della località da usare per l'ordinamento e il comportamento relativo alle maiuscole.
            /// </summary>
            SortingLocaleName = GeoInfoType.LOCALE_SSORTLOCALE,
            /// <summary>
            /// Data lunga senza anno, giorno della settimana, mese e data.
            /// </summary>
            RelativeLongDate = GeoInfoType.LOCALE_SRELATIVELONGDATE,
            /// <summary>
            /// Indica se la località è "costruita", cioè creata con dati da diverse fonti.
            /// </summary>
            /// <remarks>0 se la località non è "costruita", 1 in caso contrario.</remarks>
            IsConstructedLocale = GeoInfoType.LOCALE_ICONSTRUCTEDLOCALE,
            /// <summary>
            /// Indicatore AM più corto possibile.
            /// </summary>
            ShortestAMIndicator = GeoInfoType.LOCALE_SSHORTESTAM,
            /// <summary>
            /// Indicatore PM più corto possibile.
            /// </summary>
            ShortestPMIndicator = GeoInfoType.LOCALE_SSHORTESTPM,
            /// <summary>
            /// Code page legacy da usare su una macchina non UTF-8.
            /// </summary>
            UTF8LegacyCodePage = GeoInfoType.LOCALE_IUSEUTF8LEGACYACP,
            /// <summary>
            /// Code page OEM legacy da usare su una macchina non UTF-8.
            /// </summary>
            UTF8LegacyOEMCodePage = GeoInfoType.LOCALE_IUSEUTF8LEGACYOEMCP,
            /// <summary>
            /// Lista di tastiere separate da punti e virgola da potenzialmente installare per la località ed essere usate internamente da Windows.
            /// </summary>
            KeyboardToInstallList = GeoInfoType.LOCALE_SKEYBOARDSTOINSTALL
        }

        /// <summary>
        /// Posizione del segno negativo in un valore monetario.
        /// </summary>
        public enum CurrencyNegativeSignPosition : uint
        {
            /// <summary>
            /// Il segno non è presente, il valore e il simbolo sono all'interndo di parentesi.
            /// </summary>
            AmountAndSymbolSurroundedByParenthesis = NegativeSignPositionCurrency.ParenthesisSurrounded,
            /// <summary>
            /// Prima del valore numerico.
            /// </summary>
            BeforeAmount = NegativeSignPositionCurrency.BeforeNumber,
            /// <summary>
            /// Dopo il valore numerico.
            /// </summary>
            AfterAmount = NegativeSignPositionCurrency.AfterNumber,
            /// <summary>
            /// Prima del simbolo monetario.
            /// </summary>
            BeforeSymbol = NegativeSignPositionCurrency.BeforeSymbol,
            /// <summary>
            /// Dopo il simbolo monetario.
            /// </summary>
            AfterSymbol = NegativeSignPositionCurrency.AfterSymbol
        }

        /// <summary>
        /// Formato della percentuale positiva.
        /// </summary>
        public enum PositivePercentageMode
        {
            /// <summary>
            /// Numero, spazio, percentuale.
            /// </summary>
            Mode0,
            /// <summary>
            /// Numero, percentuale.
            /// </summary>
            Mode1,
            /// <summary>
            /// Percentuale, numero.
            /// </summary>
            Mode2,
            /// <summary>
            /// Percentuale, spazio, numero.
            /// </summary>
            Mode3
        }

        /// <summary>
        /// Forma delle cifre.
        /// </summary>
        public enum DigitSubstitutionMode
        {
            /// <summary>
            /// Basata sul contesto.
            /// </summary>
            /// <remarks>Le cifre vengono mostrate in base al testo precedente nello stesso output.<br/>
            /// Le cifre europee sono basate sugli script latini, quelle arabe sono basate sugli script arabi, le altre cifre nazionali sono basate su diversi script.<br/><br/>
            /// Se le cifre non sono preceduto da testo, la località e l'ordine di lettura determinano la forma delle cifre, come indicato di seguito:<br/><br/>
            /// Formato: (località, ordine di lettura) => cifre usate<br/><br/>
            /// (Arabo, da destra a sinistra) => cifre arabe-indi<br/>
            /// (Thai, da sinistra a destra) => cifre thai<br/>
            /// (tutte le altre, qualunque) => nessuna sostituzione</remarks>
            ContextBased = DigitsShape.ContextBased,
            /// <summary>
            /// Nessuna sostituzione.
            /// </summary>
            NoSubstitution = DigitsShape.NoSubstitution,
            /// <summary>
            /// Sostituzione con cifre native.
            /// </summary>
            NativeDigitSubstituion = DigitsShape.NativeDigitSubstituion
        }

        /// <summary>
        /// Prima settimana dell'anno.
        /// </summary>
        public enum FirstWeekOfYear
        {
            /// <summary>
            /// Settimana contenente 1/1.
            /// </summary>
            WeekContaining1_1 = NationalLanguageSupportEnumerations.FirstWeekOfYear.WeekContaining1_1,
            /// <summary>
            /// Prima settimana completa dopo 1/1.
            /// </summary>
            FirstFullWeekAfter1_1 = NationalLanguageSupportEnumerations.FirstWeekOfYear.FirstFullWeekAfter1_1,
            /// <summary>
            /// Prima settimana contenente almeno quattro giorni, compatibile con ISO 8601.
            /// </summary>
            FirstWeekWithFourDaysISO8601 = NationalLanguageSupportEnumerations.FirstWeekOfYear.FirstWeekWithFourDaysISO8601
        }

        /// <summary>
        /// Dimensione predefinita della carta.
        /// </summary>
        public enum PaperSize
        {
            /// <summary>
            /// Lettera Stati Uniti.
            /// </summary>
            USLetter = DefaultPaperSize.DMPAPER_LETTER,

            USLetterSmall = DefaultPaperSize.DMPAPER_LETTER_SMALL,

            USTabloid = DefaultPaperSize.DMPAPER_TABLOID,

            USLedger = DefaultPaperSize.DMPAPER_LEDGER,
            /// <summary>
            /// Lettera legale Stati Uniti.
            /// </summary>
            USLegal = DefaultPaperSize.DMPAPER_LEGAL,

            USStatement = DefaultPaperSize.DMPAPER_STATEMENT,

            USExecutive = DefaultPaperSize.DMPAPER_EXECUTIVE,
            /// <summary>
            /// A3.
            /// </summary>
            A3 = DefaultPaperSize.DMPAPER_A3,
            /// <summary>
            /// A4.
            /// </summary>
            A4 = DefaultPaperSize.DMPAPER_A4,

            A4Small = DefaultPaperSize.DMPAPER_A4SMALL,

            A5 = DefaultPaperSize.DMPAPER_A5,

            B4 = DefaultPaperSize.DMPAPER_B4,

            B5 = DefaultPaperSize.DMPAPER_B5,

            Folio = DefaultPaperSize.DMPAPER_FOLIO,

            Quarto = DefaultPaperSize.DMPAPER_QUARTO,

            Paper10x14 = DefaultPaperSize.DMPAPER_10X14,

            Paper11x17 = DefaultPaperSize.DMPAPER_11X17,

            USNote = DefaultPaperSize.DMPAPER_NOTE,

            USEnvelope9 = DefaultPaperSize.DMPAPER_ENV_9,

            USEnvelope10 = DefaultPaperSize.DMPAPER_ENV_10,

            USEnvelope11 = DefaultPaperSize.DMPAPER_ENV_11,

            USEnvelope12 = DefaultPaperSize.DMPAPER_ENV_12,

            USEnvelope14 = DefaultPaperSize.DMPAPER_ENV_14,

            CSheet = DefaultPaperSize.DMPAPER_CSHEET,

            DSheet = DefaultPaperSize.DMPAPER_DSHEET,

            ESheet = DefaultPaperSize.DMPAPER_ESHEET,

            EnvelopeDL = DefaultPaperSize.DMPAPER_ENV_DL,

            EnvelopeC5 = DefaultPaperSize.DMPAPER_ENV_C5,

            EnvelopeC3 = DefaultPaperSize.DMPAPER_ENV_C3,

            EnvelopeC4 = DefaultPaperSize.DMPAPER_ENV_C4,

            EnvelopeC6 = DefaultPaperSize.DMPAPER_ENV_C6,

            EnvelopeC65 = DefaultPaperSize.DMPAPER_ENV_C65,

            EnvelopeB4 = DefaultPaperSize.DMPAPER_ENV_B4,

            EnvelopeB5 = DefaultPaperSize.DMPAPER_ENV_B5,

            EnvelopeB6 = DefaultPaperSize.DMPAPER_ENV_B6,

            EnvelopeItaly = DefaultPaperSize.DMPAPER_ENV_ITALY,

            USEnvelopeMonarch = DefaultPaperSize.DMPAPER_ENV_MONARCH,

            USEnvelopePersonal = DefaultPaperSize.DMPAPER_ENV_PERSONAL,

            USFanfold = DefaultPaperSize.DMPAPER_FANFOLD_US,

            GermanStandardFanfold = DefaultPaperSize.DMPAPER_FANFOLD_STD_GERMAN,

            GermanLegalFanfold = DefaultPaperSize.DMPAPER_FANFOLD_LGL_GERMAN,

            IsoB4 = DefaultPaperSize.DMPAPER_ISO_B4,

            JapanesePostcard = DefaultPaperSize.DMPAPER_JAPANESE_POSTCARD,

            Paper9x11 = DefaultPaperSize.DMPAPER_9X11,

            Paper10x11 = DefaultPaperSize.DMPAPER_10X11,

            Paper15x11 = DefaultPaperSize.DMPAPER_15X11,

            EnvelopeInvite = DefaultPaperSize.DMPAPER_ENV_INVITE,

            USLetterExtra = DefaultPaperSize.DMPAPER_LETTER_EXTRA,

            USLegalExtra = DefaultPaperSize.DMPAPER_LEGAL_EXTRA,

            USTabloidExtra = DefaultPaperSize.DMPAPER_TABLOID_EXTRA,

            A4Extra = DefaultPaperSize.DMPAPER_A4_EXTRA,

            LetterTransverse = DefaultPaperSize.DMPAPER_LETTER_TRANSVERSE,

            A4Transverse = DefaultPaperSize.DMPAPER_A4_TRANSVERSE,

            LetterExtraTransverse = DefaultPaperSize.DMPAPER_LETTER_EXTRA_TRANSVERSE,

            APlus = DefaultPaperSize.DMPAPER_A_PLUS,

            BPlus = DefaultPaperSize.DMPAPER_B_PLUS,

            USLetterPlus = DefaultPaperSize.DMPAPER_LETTER_PLUS,

            A4Plus = DefaultPaperSize.DMPAPER_A4_PLUS,

            A5Transverse = DefaultPaperSize.DMPAPER_A5_TRANSVERSE,

            B5Trasverse = DefaultPaperSize.DMPAPER_B5_TRANSVERSE,

            A3Extra = DefaultPaperSize.DMPAPER_A3_EXTRA,

            A5Extra = DefaultPaperSize.DMPAPER_A5_EXTRA,

            B5Extra = DefaultPaperSize.DMPAPER_B5_EXTRA,

            A2 = DefaultPaperSize.DMPAPER_A2,

            A3Transverse = DefaultPaperSize.DMPAPER_A3_TRANSVERSE,

            A3ExtraTransverse = DefaultPaperSize.DMPAPER_A3_EXTRA_TRASVERSE,

            JapaneseDoublePostcard = DefaultPaperSize.DMPAPER_DBL_JAPANESE_POSTCARD,

            A6 = DefaultPaperSize.DMPAPER_A6,

            JapaneseEnvelopeKaku2 = DefaultPaperSize.DMPAPER_JENV_KAKU2,

            JapaneseEnvelopeKaku3 = DefaultPaperSize.DMPAPER_JENV_KAKU3,

            JapaneseEnvelopeChou3 = DefaultPaperSize.DMPAPER_JENV_CHOU3,

            JapaneseEnvelopeChou4 = DefaultPaperSize.DMPAPER_JENV_CHOU4,

            LetterRotated = DefaultPaperSize.DMPAPER_LETTER_ROTATED,

            A3Rotated = DefaultPaperSize.DMPAPER_A3_ROTATED,

            A4Rotated = DefaultPaperSize.DMPAPER_A4_ROTATED,

            A5Rotated = DefaultPaperSize.DMPAPER_A5_ROTATED,

            JISB4Rotated = DefaultPaperSize.DMPAPER_B4_JIS_ROTATED,

            JISB5Rotated = DefaultPaperSize.DMPAPER_B5_JIS_ROTATED,

            JapanesePostcardRotated = DefaultPaperSize.DMPAPER_DBL_JAPANESE_POSTCARD_ROTATED,

            DoubleJapanesePostcardRotated = DefaultPaperSize.DMPAPER_DBL_JAPANESE_POSTCARD_ROTATED,

            A6Rotated = DefaultPaperSize.DMPAPER_A6_ROTATED,

            JapaneseEnvelopeKaku2Rotated = DefaultPaperSize.DMPAPER_JENV_KAKU2_ROTATED,

            JapaneseEnvelopeKaku3Rotated = DefaultPaperSize.DMPAPER_JENV_KAKU3_ROTATED,

            JapaneseEnvelopeChou3Rotated = DefaultPaperSize.DMPAPER_JENV_CHOU3_ROTATED,

            JapaneseEnvelopeChou4Rotated = DefaultPaperSize.DMPAPER_JENV_CHOU4_ROTATED,

            JISB6 = DefaultPaperSize.DMPAPER_B6_JIS,

            JISB6Rotated = DefaultPaperSize.DMPAPER_B6_JIS_ROTATED,

            Paper12x11 = DefaultPaperSize.DMPAPER_12X11,

            JapaneseEnvelopeYou4 = DefaultPaperSize.DMPAPER_JENV_YOU4,

            JapaneseEnvelopeYou4Rotated = DefaultPaperSize.DMPAPER_JENV_YOU4_ROTATED,

            PRC16K = DefaultPaperSize.DMPAPER_P16K,

            PRC32K = DefaultPaperSize.DMPAPER_P32K,

            PRC32KBig = DefaultPaperSize.DMPAPER_P32KBIG,

            PRCEnvelope1 = DefaultPaperSize.DMPAPER_PENV_1,

            PRCEnvelope2 = DefaultPaperSize.DMPAPER_PENV_2,

            PRCEnvelope3 = DefaultPaperSize.DMPAPER_PENV_3,

            PRCEnvelope4 = DefaultPaperSize.DMPAPER_PENV_4,

            PRCEnvelope5 = DefaultPaperSize.DMPAPER_PENV_5,

            PRCEnvelope6 = DefaultPaperSize.DMPAPER_PENV_6,

            PRCEnvelope7 = DefaultPaperSize.DMPAPER_PENV_7,

            PRCEnvelope8 = DefaultPaperSize.DMPAPER_PENV_8,

            PRCEnvelope9 = DefaultPaperSize.DMPAPER_PENV_9,

            PRCEnvelope10 = DefaultPaperSize.DMPAPER_PENV_10,

            PRC16KRotated = DefaultPaperSize.DMPAPER_P16K_ROTATED,

            PRC32KRotated = DefaultPaperSize.DMPAPER_P32K_ROTATED,

            PRC32KBigRotated = DefaultPaperSize.DMPAPER_P32KBIG_ROTATED,

            PRCEnvelope1Rotated = DefaultPaperSize.DMPAPER_PENV_1_ROTATED,

            PRCEnvelope2Rotated = DefaultPaperSize.DMPAPER_PENV_2_ROTATED,

            PRCEnvelope3Rotated = DefaultPaperSize.DMPAPER_PENV_3_ROTATED,

            PRCEnvelope4Rotated = DefaultPaperSize.DMPAPER_PENV_4_ROTATED,

            PRCEnvelope5Rotated = DefaultPaperSize.DMPAPER_PENV_5_ROTATED,

            PRCEnvelope6Rotated = DefaultPaperSize.DMPAPER_PENV_6_ROTATED,

            PRCEnvelope7Rotated = DefaultPaperSize.DMPAPER_PENV_7_ROTATED,

            PRCEnvelope8Rotated = DefaultPaperSize.DMPAPER_PENV_8_ROTATED,

            PRCEnvelope9Rotated = DefaultPaperSize.DMPAPER_PENV_9_ROTATED,

            PRCEnvelope10Rotated = DefaultPaperSize.DMPAPER_PENV_10_ROTATED,
        }

        /// <summary>
        /// Ordine di lettura.
        /// </summary>
        public enum ReadingLayout
        {
            /// <summary>
            /// Da sinista a destra.
            /// </summary>
            LeftToRight = ReadingOrder.LeftToRight,
            /// <summary>
            /// Da destra a sinistra.
            /// </summary>
            RightToLeft = ReadingOrder.RightToLeft,
            /// <summary>
            /// Verticalmente dall'alto verso il basso da destra a sinistra oppure orizzontalmente da sinistra a destra.
            /// </summary>
            VerticallyTopToBottomRightToLeftOrHorizontalLeftToRight = ReadingOrder.VerticallyTopToBottomRightToLeftOrHorizontalLeftToRight,
            /// <summary>
            /// Verticalmente dall'alto verso il basso da sinistra a destra.
            /// </summary>
            VerticallyTopToBottomLeftToRight = ReadingOrder.VerticallyTopToBottomLeftToRight
        }

        /// <summary>
        /// Formato del numero negativo.
        /// </summary>
        public enum NegativeNumberFormat
        {
            /// <summary>
            /// (1.1)
            /// </summary>
            Mode0 = NegativeNumberMode.Mode0,
            /// <summary>
            /// -1.1
            /// </summary>
            Mode1 = NegativeNumberMode.Mode1,
            /// <summary>
            /// - 1.1
            /// </summary>
            Mode2 = NegativeNumberMode.Mode2,
            /// <summary>
            /// 1.1-
            /// </summary>
            Mode3 = NegativeNumberMode.Mode3,
            /// <summary>
            /// 1.1 -
            /// </summary>
            Mode4 = NegativeNumberMode.Mode4
        }

        /// <summary>
        /// Informazioni sui caratteri.
        /// </summary>
        public enum StringCharacterInfo : uint
        {
            /// <summary>
            /// Tipo di carattere.
            /// </summary>
            TypeInfo = StringCharacterTypeInfo.CT_CTYPE1,
            /// <summary>
            /// Layout del carattere.
            /// </summary>
            BidirectionalLayoutInfo = StringCharacterTypeInfo.CT_CTYPE2,
            /// <summary>
            /// Informazioni di elaborazione del testo.
            /// </summary>
            TextProcessingInfo = StringCharacterTypeInfo.CT_CTYPE3
        }

        /// <summary>
        /// Tipi di carattere.
        /// </summary>
        [Flags]
        public enum CharacterTypes : ushort
        {
            /// <summary>
            /// Carattere maiuscolo.
            /// </summary>
            UpperCase = CharacterTypeValues.C1_UPPER,
            /// <summary>
            /// Carattere minuscolo.
            /// </summary>
            LowerCase = CharacterTypeValues.C1_LOWER,
            /// <summary>
            /// Cifra decimale.
            /// </summary>
            DecimalDigit = CharacterTypeValues.C1_DIGIT,
            /// <summary>
            /// Spazio.
            /// </summary>
            Space = CharacterTypeValues.C1_SPACE,
            /// <summary>
            /// Carattere di punteggiatura.
            /// </summary>
            Punctuation = CharacterTypeValues.C1_PUNCT,
            /// <summary>
            /// Carattere di controllo.
            /// </summary>
            ControlChar = CharacterTypeValues.C1_CNTRL,
            /// <summary>
            /// Carattere vuoto.
            /// </summary>
            Blank = CharacterTypeValues.C1_BLANK,
            /// <summary>
            /// Cifra esadecimale.
            /// </summary>
            HexadecimalDigit = CharacterTypeValues.C1_XDIGIT,
            /// <summary>
            /// Carattere linguistico generico.
            /// </summary>
            LinguisticChar = CharacterTypeValues.C1_ALPHA,
            /// <summary>
            /// Carattere definito diverso dagli altri tipi.
            /// </summary>
            DefinedChar = CharacterTypeValues.C1_DEFINED
        }

        /// <summary>
        /// Layout bidirezionale.
        /// </summary>
        public enum CharacterBidirectionalLayout : ushort
        {
            /// <summary>
            /// Da sinistra a destra.
            /// </summary>
            LeftToRight = StringLayoutValues.C2_LEFTTORIGHT,
            /// <summary>
            /// Da destra a sinistra.
            /// </summary>
            RightToLeft = StringLayoutValues.C2_RIGHTTOLEFT,
            /// <summary>
            /// Numero europeo.
            /// </summary>
            EuropeanNumber = StringLayoutValues.C2_EUROPENUMBER,
            /// <summary>
            /// Separatore numerico europeo.
            /// </summary>
            EuropeanNumericSeparator = StringLayoutValues.C2_EUROPESEPARATOR,
            /// <summary>
            /// Terminatore numerico europeo.
            /// </summary>
            EuropeanNumericTerminator = StringLayoutValues.C2_EUROPETERMINATOR,
            /// <summary>
            /// Numero arabo.
            /// </summary>
            ArabicNumber = StringLayoutValues.C2_ARABICNUMBER,
            /// <summary>
            /// Separatore numerico comune.
            /// </summary>
            CommonNumericSeparator = StringLayoutValues.C2_COMMONSEPARATOR,
            /// <summary>
            /// Separatore blocco.
            /// </summary>
            BlockSeparator = StringLayoutValues.C2_BLOCKSEPARATOR,
            /// <summary>
            /// Separatore segmento.
            /// </summary>
            SegmentSeparator = StringLayoutValues.C2_SEGMENTSEPARATOR,
            /// <summary>
            /// Spazio vuoto.
            /// </summary>
            Whitespace = StringLayoutValues.C2_WHITESPACE,
            /// <summary>
            /// Altri caratteri neutrali.
            /// </summary>
            OtherNeutral = StringLayoutValues.C2_OTHERNEUTRAL,
            /// <summary>
            /// Nessuna direzionalità applicabile.
            /// </summary>
            NotApplicable = StringLayoutValues.C2_NOTAPPLICABLE
        }

        /// <summary>
        /// Informazioni di elaborazione testo.
        /// </summary>
        public enum TextProcessing : ushort
        {
            /// <summary>
            /// Marcatore nonspacing.
            /// </summary>
            NonspacingMark = StringTextProcessingValues.C3_NONSPACING,
            /// <summary>
            /// Marcatore diacritico nonspacing.
            /// </summary>
            DiacriticNonspacingMark = StringTextProcessingValues.C3_DIACRITIC,
            /// <summary>
            /// Marcatore vocale nonspacing.
            /// </summary>
            VowelNonspacingMark = StringTextProcessingValues.C3_VOWELMARK,
            /// <summary>
            /// Simbolo.
            /// </summary>
            Symbol = StringTextProcessingValues.C3_SYMBOL,
            /// <summary>
            /// Carattere katakana.
            /// </summary>
            KatakanaChar = StringTextProcessingValues.C3_KATAKANA,
            /// <summary>
            /// Carattere hiragana.
            /// </summary>
            HiraganaChar = StringTextProcessingValues.C3_HIRAGANA,
            /// <summary>
            /// Carattere a mezza larghezza.
            /// </summary>
            NarrowChar = StringTextProcessingValues.C3_HALFWIDTH,
            /// <summary>
            /// Carattere a larghezza completa.
            /// </summary>
            WideChar = StringTextProcessingValues.C3_FULLWIDTH,
            /// <summary>
            /// Ideogramma.
            /// </summary>
            Ideograph = StringTextProcessingValues.C3_IDEOGRAPH,
            /// <summary>
            /// Kashida arabo.
            /// </summary>
            ArabicKashida = StringTextProcessingValues.C3_KASHIDA,
            /// <summary>
            /// Carattere di punteggiatura considerato parte della parola.
            /// </summary>
            LexicalPunctuation = StringTextProcessingValues.C3_LEXICAL,
            /// <summary>
            /// Carattere linguistico generico.
            /// </summary>
            GeneralLinguisticChar = StringTextProcessingValues.C3_ALPHA,
            /// <summary>
            /// 
            /// </summary>
            HighSurrogateCodeUnit = StringTextProcessingValues.C3_HIGHSURROGATE,
            /// <summary>
            /// 
            /// </summary>
            LowSurrogateCodeUnit = StringTextProcessingValues.C3_LOWSURROGATE
        }

        /// <summary>
        /// Opzioni di conversione per un nome di dominio internazionalizzato (IDN).
        /// </summary>
        [Flags]
        public enum IDNConversionOptions : uint
        {
            /// <summary>
            /// Permette la presenza di code points non assegnati in Punycode.
            /// </summary>
            AllowUnassignedCodePoints = IdnConversionOptions.IDN_ALLOW_UNASSIGNED,
            /// <summary>
            /// Filtra i caratteri non permessi in nomi STD3.
            /// </summary>
            UseStd3AsciiRules = IdnConversionOptions.IDN_USE_STD3_ASCII_RULES,
            /// <summary>
            /// Abilita il fallback algoritmico per la parte locale di un indirizzo email.
            /// </summary>
            EnableEAIAlgorithmicFallback = IdnConversionOptions.IDN_EMAIL_ADDRESS,
            /// <summary>
            /// Disabilita la convalida e la mappatura di Punycode.
            /// </summary>
            DisablePunycodeValidationAndMapping = IdnConversionOptions.IDN_RAW_PUNYCODE
        }

        /// <summary>
        /// Risultato della conversione di una stringa IDN.
        /// </summary>
        public enum IDNConversionResult
        {
            /// <summary>
            /// Stringa Unicode con solo caratteri ASCII.
            /// </summary>
            AsciiString,
            /// <summary>
            /// Stringa nel formato specificato dal documento RFC 3491 del Network Working Group.
            /// </summary>
            NameprepString,
            /// <summary>
            /// Stringa Unicode.
            /// </summary>
            /// <remarks>La stringa originale deve essere nel formato Punycode.</remarks>
            UnicodeString
        }

        /// <summary>
        /// Tipo di trasformazione da effettuare.
        /// </summary>
        [Flags]
        public enum StringTransformationType : uint
        {
            /// <summary>
            /// Nessuna trasformazione.
            /// </summary>
            None,
            /// <summary>
            /// Inversione byte.
            /// </summary>
            ByteReversal = StringMappingTrasformation.LCMAP_BYTEREV,
            /// <summary>
            /// Usare caratteri full-width dove possibile.
            /// </summary>
            UseWideChars = StringMappingTrasformation.LCMAP_FULLWIDTH,
            /// <summary>
            /// Usare caratteri half-width dove possibile.
            /// </summary>
            UseNarrowChars = StringMappingTrasformation.LCMAP_HALFWIDTH,
            /// <summary>
            /// Mappa i caratteri katakana agli equivalenti hiragana.
            /// </summary>
            KatakanaToHiragana = StringMappingTrasformation.LCMAP_HIRAGANA,
            /// <summary>
            /// Mappa i caratteri hiragana agli equivalenti katakana.
            /// </summary>
            HiraganaToKatakana = StringMappingTrasformation.LCMAP_KATAKANA,
            /// <summary>
            /// Usa le regole linguistiche al posto di quelle del file system per le lettere maiuscole.
            /// </summary>
            UseLinguisticRulesForCasing = StringMappingTrasformation.LCMAP_LINGUISTIC_CASING,
            /// <summary>
            /// Trasforma tutte le lettere maiuscole nelle loro equivalenti minuscole.
            /// </summary>
            ToLowercase = StringMappingTrasformation.LCMAP_LOWERCASE,
            /// <summary>
            /// Restituire un hash dei pesi di ordinamento della stringa.
            /// </summary>
            Hash = StringMappingTrasformation.LCMAP_HASH,
            /// <summary>
            /// Mappa i caratteri del cinese tradizionale agli equivalenti del cinese semplificato.
            /// </summary>
            TraditionalChineseToSimplifiedChinese = StringMappingTrasformation.LCMAP_SIMPLIFIED_CHINESE,
            /// <summary>
            /// Generare una chiave di ordinamento normalizzata.
            /// </summary>
            SortKey = StringMappingTrasformation.LCMAP_SORTKEY,
            /// <summary>
            /// Mappa le prime lettere di ogni parola nei loro equivalenti maiuscoli.
            /// </summary>
            ToTitleCase = StringMappingTrasformation.LCMAP_TITLECASE,
            /// <summary>
            /// Mappa i caratteri del cinese semplificato agli equivalenti del cinese tradizionale.
            /// </summary>
            SimplifiedChineseToTraditionalChinese = StringMappingTrasformation.LCMAP_TRADITIONAL_CHINESE,
            /// <summary>
            /// Trasforma tutte le lettere minuscole nelle loro equivalenti maiuscole.
            /// </summary>
            ToUpperCase = StringMappingTrasformation.LCMAP_UPPERCASE
        }

        /// <summary>
        /// Opzioni creazione chiave di ordinamento.
        /// </summary>
        [Flags]
        public enum SortKeyOptions : uint
        {
            /// <summary>
            /// Ignora la differenza tra minuscole e maiuscole seguendo le regole della lingua.
            /// </summary>
            IgnoreCaseLinguistic = StringComparisonOptions.LINGUISTIC_IGNORECASE,
            /// <summary>
            /// Ignora i caratteri nonspacing seguendo le regole della lingua.
            /// </summary>
            IgnoreDiacriticLinguistic = StringComparisonOptions.LINGUISTIC_IGNOREDIACRITIC,
            /// <summary>
            /// Ignora la differenza tra minuscole e maiuscole.
            /// </summary>
            /// <remarks>Questa opzione non tiene conto delle regole della lingua.</remarks>
            IgnoreCase = StringComparisonOptions.NORM_IGNORECASE,
            /// <summary>
            /// Ignora la differenza tra hiragana e katakana.
            /// </summary>
            IgnoreKanatype = StringComparisonOptions.NORM_IGNOREKANATYPE,
            /// <summary>
            /// Ignora la differenza tra caratteri half-width e caratteri full-width.
            /// </summary>
            IgnoreWidth = StringComparisonOptions.NORM_IGNOREWIDTH,
            /// <summary>
            /// Usare le regole linguistiche al posto di quelle del file system per le maisucole.
            /// </summary>
            UseLinguisticRulesForCasing = StringComparisonOptions.NORM_LINGUISTIC_CASING,
            /// <summary>
            /// Tratta le cifre come numeri.
            /// </summary>
            TreatDigitsAsNumbers = StringSortingOptions.SORT_DIGITSASNUMBERS,
            /// <summary>
            /// Tratta la punteggiatura come simboli.
            /// </summary>
            TreatPunctuationAsSymbols = StringSortingOptions.SORT_STRINGSORT
        }

        /// <summary>
        /// Forma di normalizzazione.
        /// </summary>
        public enum NormalizationMode
        {
            /// <summary>
            /// Composizione canonica.
            /// </summary>
            /// <remarks>Trasforma ogni raggruppamento decomposto nel suo equivalente precomposto.</remarks>
            C,
            /// <summary>
            /// Decomposizione canonica.
            /// </summary>
            /// <remarks>Trasforma ogni carattere precomposto nel suo equivalente decomposto canonico.</remarks>
            D,
            /// <summary>
            /// Composizione per compatibilità
            /// </summary>
            /// <remarks>Trasforma ogni base più carattere combinato nell'equivalente precomposto e tutti i caratteri di compatibilità nei loro equivalenti.</remarks>
            KC,
            /// <summary>
            /// Decomposizione per compatibilità.
            /// </summary>
            /// <remarks>Trasforma ogni carattere precomposto nell'equivalente decomposto canonico e tutti i caratteri di compatibilità nei loro equivalenti.</remarks>
            KD
        }

        /// <summary>
        /// Trasformazione da effettuare, usato dal metodo <see cref="NLSManaged.MapString"/>.
        /// </summary>
        public enum StringTransformationType2 : uint
        {
            /// <summary>
            /// Mappa i caratteri accentati ai relativi caratteri decomposti.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="AccentedCharsToPrecomposedChars"/>.</remarks>
            AccentedCharsToDecomposedChars = StringMappingTransformation2.MAP_COMPOSITE,
            /// <summary>
            /// Espande tutti i caratteri di legatura così che siano rappresentati dai loro equivalenti a due caratteri.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="AccentedCharsToDecomposedChars"/> o <see cref="AccentedCharsToPrecomposedChars"/>.</remarks>
            ExpandLigatureChars = StringMappingTransformation2.MAP_EXPAND_LIGATURES,
            /// <summary>
            /// Trasforma i caratteri della zona di compatibilità nei loro equivalenti Unicode.
            /// </summary>
            CompatibilityZoneCharsToUnicodeEquivalents = StringMappingTransformation2.MAP_FOLDCZONE,
            /// <summary>
            /// Mappa tutte le cifre ai caratteri Unicode da 0 a 9.
            /// </summary>
            DigitsToEquivalentChars = StringMappingTransformation2.MAP_FOLDDIGITS,
            /// <summary>
            /// Mappa i caratteri accentati ai relativi caratteri precomposti.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="AccentedCharsToDecomposedChars"/>.</remarks>
            AccentedCharsToPrecomposedChars = StringMappingTransformation2.MAP_PRECOMPOSED
        }

        /// <summary>
        /// Opzioni di ricerca.
        /// </summary>
        public enum SearchOptions : uint
        {
            /// <summary>
            /// La ricerca parte dall'inizio della stringa.
            /// </summary>
            SearchFromStart = StringSearchStartingPosition.FIND_FROMSTART,
            /// <summary>
            /// La ricerca parte dalla fine della stringa.
            /// </summary>
            SearchFromEnd = StringSearchStartingPosition.FIND_FROMEND,
            /// <summary>
            /// Controlla se la stringa inizia con il valore.
            /// </summary>
            StartsWith = StringSearchStartingPosition.FIND_STARTSWITH,
            /// <summary>
            /// Controlla se la stringa finisce con il valore.
            /// </summary>
            EndsWith = StringSearchStartingPosition.FIND_ENDSWITH
        }

        /// <summary>
        /// FIltro applicato alla ricerca di una stringa.
        /// </summary>
        [Flags]
        public enum StringSearchFilter : uint
        {
            /// <summary>
            /// Ignora la distinzione tra maiuscole e minuscole, secondo le regole della lingua.
            /// </summary>
            IgnoreCaseLinguistic = SortKeyOptions.IgnoreCaseLinguistic,
            /// <summary>
            /// Ignora i diacritici, secondo le regole della lingua.
            /// </summary>
            IgnoreDiacriticLinguistic = SortKeyOptions.IgnoreDiacriticLinguistic,
            /// <summary>
            /// Ignora la distinzione tra maiuscole e minuscole.
            /// </summary>
            /// <remarks>Questa opzione non tiene conto delle regole della lingua.</remarks>
            IgnoreCase = SortKeyOptions.IgnoreCase,
            /// <summary>
            /// Ignora la distinzione tra i caratteri hiragana e katakana.
            /// </summary>
            IgnoreKanatype = SortKeyOptions.IgnoreKanatype,
            /// <summary>
            /// Ignora caratteri non spacing.
            /// </summary>
            /// <remarks>Alcuni script usano i diacritici per altre ragioni, queste differenze possono non essere linguistiche.</remarks>
            IgnoreNonSpacingChars = StringComparisonOptions.NORM_IGNORENONSPACE,
            /// <summary>
            /// Ignora i simboli e la punteggiatura.
            /// </summary>
            IgnoreSymbolsAndPunctuation = StringComparisonOptions.NORM_IGNORESYMBOLS,
            /// <summary>
            /// Ignora la differenza tra i caratteri half-width e full-width.
            /// </summary>
            IgnoreWidth = SortKeyOptions.IgnoreWidth,
            /// <summary>
            /// Usa le regole linguistiche al posto di quelle del file system.
            /// </summary>
            UseLinguisticRulesForCasing = SortKeyOptions.UseLinguisticRulesForCasing
        }

        /// <summary>
        /// Opzioni di confronto tra stringhe.
        /// </summary>
        [Flags]
        public enum ComparisonOptions : uint
        {
            /// <summary>
            /// Ignora la distinzione tra maiuscole e minuscole seguendo le regole della lingua.
            /// </summary>
            IgnoreCaseLinguistic = StringComparisonOptions.LINGUISTIC_IGNORECASE,
            /// <summary>
            /// Ignora la distinzione tra maiuscole e minuscole.
            /// </summary>
            IgnoreCase = StringComparisonOptions.NORM_IGNORECASE,
            /// <summary>
            /// Ignora la distinzione tra i caratteri hiragana e katakana.
            /// </summary>
            IgnoreKanatype = StringComparisonOptions.NORM_IGNOREKANATYPE,
            /// <summary>
            /// Ignora i caratteri non spacing.
            /// </summary>
            IgnoreNonSpacingChars = StringComparisonOptions.NORM_IGNORENONSPACE,
            /// <summary>
            /// Ignora i simboli e la punteggiatura.
            /// </summary>
            IgnoreSymbolsAndPunctuation = StringComparisonOptions.NORM_IGNORESYMBOLS,
            /// <summary>
            /// Ignora la differenza tra i caratteri half-width e full-width.
            /// </summary>
            IgnoreWidth = StringComparisonOptions.NORM_IGNOREWIDTH,
            /// <summary>
            /// Usa le regole linguistiche al posto di quelle del file system per le maiuscole.
            /// </summary>
            UseLinguisticRulesForCasing = StringComparisonOptions.NORM_LINGUISTIC_CASING,
            /// <summary>
            /// Tratta le cifre come numeri.
            /// </summary>
            TreatDigitsAsNumbers = StringSortingOptions.SORT_DIGITSASNUMBERS,
            /// <summary>
            /// Tratta la punteggiatura allo stesso modo dei simboli.
            /// </summary>
            TreatPunctuationAsSymbols = StringSortingOptions.SORT_STRINGSORT
        }

        /// <summary>
        /// Informazioni località impostabili.
        /// </summary>
        public enum LocaleInfoSet : uint
        {
            /// <summary>
            /// Numero di cifre frazionarie per la valuta.
            /// </summary>
            CurrencyFractionalDigitsCount = GeoInfoType.LOCALE_ICURRDIGITS,
            /// <summary>
            /// Posizione del simbolo monetario in un valore monetario positivo.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="SymbolPositionPositiveCurrency"/>.</remarks>
            PositiveCurrencySymbolPosition = GeoInfoType.LOCALE_ICURRENCY,
            /// <summary>
            /// Numero di cifre frazionarie dopo il separatore decimale.
            /// </summary>
            FractionalDigitsCount = GeoInfoType.LOCALE_IDIGITS,
            /// <summary>
            /// Forma delle cifre.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="DigitSubstitutionMode"/>.</remarks>
            DigitsShape = GeoInfoType.LOCALE_IDIGITSUBSTITUTION,
            /// <summary>
            /// Primo giorno della settimana.
            /// </summary>
            /// <remarks>I valori validi sono i seguenti:<br/><br/>
            /// 0 => <see cref="LocaleInfo.FirstWeekday"/><br/>
            /// 1 => <see cref="LocaleInfo.SecondWeekday"/><br/>
            /// 2 => <see cref="LocaleInfo.ThirdWeekday"/><br/>
            /// 3 => <see cref="LocaleInfo.FourthWeekday"/><br/>
            /// 4 => <see cref="LocaleInfo.FirstWeekday"/><br/>
            /// 5 => <see cref="LocaleInfo.SixthWeekday"/><br/>
            /// 6 => <see cref="LocaleInfo.SeventhWeekday"/></remarks>
            FirstDayOfWeek = GeoInfoType.LOCALE_IFIRSTDAYOFWEEK,
            /// <summary>
            /// Prima settimana dell'anno.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="Enumerations.FirstWeekOfYear"/></remarks>
            FirstWeekOfYear = GeoInfoType.LOCALE_IFIRSTWEEKOFYEAR,
            /// <summary>
            /// Uso di zeri iniziali in numeri decimali.
            /// </summary>
            /// <remarks>true per abilitarne l'uso, false altrimenti.</remarks>
            UseDecimalLeadingZeroes = GeoInfoType.LOCALE_ILZERO,
            /// <summary>
            /// Sistema di misura.
            /// </summary>
            /// <remarks>true per il sistema statunitense, false per il sistema metrico.</remarks>
            MeasureSystem = GeoInfoType.LOCALE_IMEASURE,
            /// <summary>
            /// Formato dei valori monetari negativi.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="Enumerations.NegativeCurrencyFormat"/>.</remarks>
            NegativeCurrencyFormat = GeoInfoType.LOCALE_INEGCURR,
            /// <summary>
            /// Formato dei numeri negativi.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="NegativeNumberFormat"/>.</remarks>
            NegativeNumberMode = GeoInfoType.LOCALE_INEGNUMBER,
            /// <summary>
            /// Dimensione predefinita della carta.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="Enumerations.PaperSize"/>.</remarks>
            PaperSize = GeoInfoType.LOCALE_IPAPERSIZE,
            /// <summary>
            /// Ordine di lettura.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="ReadingLayout"/>.</remarks>
            ReadingOrder = GeoInfoType.LOCALE_IREADINGLAYOUT,
            /// <summary>
            /// Stringa per il designatore AM.
            /// </summary>
            /// <remarks>Dimensione massima di 14 caratteri.</remarks>
            AmDesignator = GeoInfoType.LOCALE_SAM,
            /// <summary>
            /// Stringa per il designatore PM.
            /// </summary>
            /// <remarks>Dimensione massima di 14 caratteri.</remarks>
            PmDesignator = GeoInfoType.LOCALE_SPM,
            /// <summary>
            /// Simbolo monetario.
            /// </summary>
            /// <remarks>Dimensiona massima di 12 caratteri.</remarks>
            CurrencySymbol = GeoInfoType.LOCALE_SCURRENCY,
            /// <summary>
            /// Separatore decimale.
            /// </summary>
            /// <remarks>Dimensione massima di 3 caratteri.</remarks>
            DecimalSeparator = GeoInfoType.LOCALE_SDECIMAL,
            /// <summary>
            /// Dimensione dei gruppi di cifre alla sinistra del decimale.
            /// </summary>
            /// <remarks>Dimensione massima di 9 caratteri.<br/><br/>
            /// La stringa deve specificare una dimensione per ogni gruppo e devono essere separate da punti e virgola.<br/>
            /// Se l'ultimo valore è 0 il valore precedente è ripetuto.</remarks>
            DigitGroupSize = GeoInfoType.LOCALE_SGROUPING,
            /// <summary>
            /// Separatore degli elementi di una lista.
            /// </summary>
            /// <remarks>Dimensione massima di 3 caratteri.</remarks>
            ListSeparator = GeoInfoType.LOCALE_SLIST,
            /// <summary>
            /// Formato della data lunga.
            /// </summary>
            /// <remarks>Dimensione massima di 79 caratteri.</remarks>
            LongDateFormatString = GeoInfoType.LOCALE_SLONGDATE,
            /// <summary>
            /// Separatore decimale per valori monetari.
            /// </summary>
            /// <remarks>Dimensione massima di 3 caratteri.</remarks>
            CurrencyDecimalSeparator = GeoInfoType.LOCALE_SMONDECIMALSEP,
            /// <summary>
            /// Dimensione di gruppi di cifre alla sinistra del decimale per valori monetari.
            /// </summary>
            /// <remarks>Dimensione massima di 9 caratteri.<br/><br/>
            /// La stringa deve specificare una dimensione per ogni gruppo e devono essere separate da punti e virgola.<br/>
            /// Se l'ultimo valore è 0 il valore precedente è ripetuto.</remarks>
            CurrencyDigitGroupSize = GeoInfoType.LOCALE_SMONGROUPING,
            /// <summary>
            /// Separatore dei gruppi alla sinistra del decimale per valori monetari.
            /// </summary>
            /// <remarks>Dimensione massima di 3 caratteri.</remarks>
            CurrencyThousandSeparator = GeoInfoType.LOCALE_SMONTHOUSANDSEP,
            /// <summary>
            /// Equivalenti nativi dei caratteri ASCII da 0 a 9.
            /// </summary>
            /// <remarks>Dimensione massima di 10 caratteri.</remarks>
            NativeDigits = GeoInfoType.LOCALE_SNATIVEDIGITS,
            /// <summary>
            /// Segno negativo.
            /// </summary>
            /// <remarks>Dimensione massima di 4 caratteri.</remarks>
            NegativeSign = GeoInfoType.LOCALE_SNEGATIVESIGN,
            /// <summary>
            /// Segno positivo.
            /// </summary>
            /// <remarks>Dimensione massima di 4 caratteri.</remarks>
            PositiveSign = GeoInfoType.LOCALE_SPOSITIVESIGN,
            /// <summary>
            /// Formato data corta.
            /// </summary>
            /// <remarks>Dimensione massima di 79 caratteri.</remarks>
            ShortDateFormat = GeoInfoType.LOCALE_SSHORTDATE,
            /// <summary>
            /// Formato orario corto.
            /// </summary>
            ShortTimeFormat = GeoInfoType.LOCALE_SSHORTTIME,
            /// <summary>
            /// Separatore dei gruppi alla sinistra del decimale.
            /// </summary>
            /// <remarks>Dimensione massima di 3 caratteri.</remarks>
            DigitsGroupSeparator = GeoInfoType.LOCALE_STHOUSAND,
            /// <summary>
            /// Formato orario.
            /// </summary>
            /// <remarks>Dimensione massima di 79 caratteri.</remarks>
            TimeFormat = GeoInfoType.LOCALE_STIMEFORMAT,
            /// <summary>
            /// Formato della stringa anno-mese.
            /// </summary>
            /// <remarks>Dimensione massima di 79 caratteri.</remarks>
            YearMonthFormat = GeoInfoType.LOCALE_SYEARMONTH
        }
    }
}