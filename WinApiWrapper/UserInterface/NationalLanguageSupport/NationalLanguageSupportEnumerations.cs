using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportStructures;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;

namespace WinApiWrapper.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Enumerazioni NLS.
    /// </summary>
    internal static class NationalLanguageSupportEnumerations
    {
        /// <summary>
        /// Informazioni sul calendario.
        /// </summary>
        internal enum CalendarInfo : CALTYPE
        {
            /// <summary>
            /// Tipo di calendario come numero intero.
            /// </summary>
            CAL_ICALINTVALUE = 1,
            /// <summary>
            /// Nome nativo del calendario.
            /// </summary>
            CAL_SCALNAME,
            /// <summary>
            /// Una o più stringhe a terminazione nulla che specificano gli offset per ognuna delle ere.
            /// </summary>
            /// <remarks>La lista termina con un carattere nullo.</remarks>
            CAL_IYEAROFFSETRANGE,
            /// <summary>
            /// Una o più stringhe a terminazione nulla che specifica le ere associate con <see cref="CAL_IYEAROFFSETRANGE"/>.
            /// </summary>
            /// <remarks>La stringa termina con un carattere nullo.</remarks>
            CAL_SERASTRING,
            /// <summary>
            /// Data corta.
            /// </summary>
            CAL_SSHORTDATE,
            /// <summary>
            /// Data lunga.
            /// </summary>
            CAL_SLONGDATE,
            /// <summary>
            /// Nome nativo del primo giorno della settimana.
            /// </summary>
            CAL_SDAYNAME1,
            /// <summary>
            /// Nome nativo del secondo giorno della settimana.
            /// </summary>
            CAL_SDAYNAME2,
            /// <summary>
            /// Nome nativo del terzo giorno della settimana.
            /// </summary>
            CAL_SDAYNAME3,
            /// <summary>
            /// Nome nativo del quarto giorno della settimana.
            /// </summary>
            CAL_SDAYNAME4,
            /// <summary>
            /// Nome nativo del quinto giorno della settimana.
            /// </summary>
            CAL_SDAYNAME5,
            /// <summary>
            /// Nome nativo del sesto giorno della settimana.
            /// </summary>
            CAL_SDAYNAME6,
            /// <summary>
            /// Nome nativo del settimo giorno della settimana.
            /// </summary>
            CAL_SDAYNAME7,
            /// <summary>
            /// Nome nativo abbreviato del primo giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME1,
            /// <summary>
            /// Nome nativo abbreviato del secondo giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME2,
            /// <summary>
            /// Nome nativo abbreviato del terzo giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME3,
            /// <summary>
            /// Nome nativo abbreviato del quarto giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME4,
            /// <summary>
            /// Nome nativo abbreviato del quinto giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME5,
            /// <summary>
            /// Nome nativo abbreviato del sesto giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME6,
            /// <summary>
            /// Nome nativo abbreviato del settimo giorno della settimana.
            /// </summary>
            CAL_SABBREVDAYNAME7,
            /// <summary>
            /// Nome nativo del primo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME1,
            /// <summary>
            /// Nome nativo del secondo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME2,
            /// <summary>
            /// Nome nativo del terzo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME3,
            /// <summary>
            /// Nome nativo del quarto mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME4,
            /// <summary>
            /// Nome nativo del quinto mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME5,
            /// <summary>
            /// Nome nativo del sesto mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME6,
            /// <summary>
            /// Nome nativo del settimo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME7,
            /// <summary>
            /// Nome nativo dell'ottavo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME8,
            /// <summary>
            /// Nome nativo del nono mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME9,
            /// <summary>
            /// Nome nativo del decimo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME10,
            /// <summary>
            /// Nome nativo dell'undicesimo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME11,
            /// <summary>
            /// Nome nativo del dodicesimo mese dell'anno.
            /// </summary>
            CAL_SMONTHNAME12,
            /// <summary>
            /// Nome nativo del tredicesimo mese dell'anno, se esiste.
            /// </summary>
            CAL_SMONTHNAME13,
            /// <summary>
            /// Nome nativo abbreviato del primo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME1,
            /// <summary>
            /// Nome nativo abbreviato del secondo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME2,
            /// <summary>
            /// Nome nativo abbreviato del terzo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME3,
            /// <summary>
            /// Nome nativo abbreviato del quarto mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME4,
            /// <summary>
            /// Nome nativo abbreviato del quinto mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME5,
            /// <summary>
            /// Nome nativo abbreviato del sesto mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME6,
            /// <summary>
            /// Nome nativo abbreviato del settimo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME7,
            /// <summary>
            /// Nome nativo abbreviato dell'ottavo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME8,
            /// <summary>
            /// Nome nativo abbreviato del nono mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME9,
            /// <summary>
            /// Nome nativo abbreviato del decimo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME10,
            /// <summary>
            /// Nome nativo abbreviato dell'undicesimo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME11,
            /// <summary>
            /// Nome nativo abbreviato del dodicesimo mese dell'anno.
            /// </summary>
            CAL_SABBREVMONTHNAME12,
            /// <summary>
            /// Nome nativo abbreviato del tredicesimo mese dell'anno, se esiste.
            /// </summary>
            CAL_SABBREVMONTHNAME13,
            /// <summary>
            /// I formati mese/anno.
            /// </summary>
            CAL_SYEARMONTH,
            /// <summary>
            /// Intero che indica il valore massimo per gli anni a due cifre.
            /// </summary>
            CAL_ITWODIGITYEARMAX,
            /// <summary>
            /// Nome nativo corto del primo giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME1,
            /// <summary>
            /// Nome nativo corto del secondo giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME2,
            /// <summary>
            /// Nome nativo corto del terzo giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME3,
            /// <summary>
            /// Nome nativo corto del quarto giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME4,
            /// <summary>
            /// Nome nativo corto del quinto giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME5,
            /// <summary>
            /// Nome nativo corto del sesto giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME6,
            /// <summary>
            /// Nome nativo corto del settimo giorno della settimana.
            /// </summary>
            CAL_SSHORTESTDAYNAME7,
            /// <summary>
            /// Formato del mese e del giorno.
            /// </summary>
            CAL_SMONTHDAY,
            /// <summary>
            /// Nome nativo abbreviato dell'era.
            /// </summary>
            CAL_SABBREVERASTRING,
            /// <summary>
            /// Data lunga senza anno, giorno della settimanta, mese, data.
            /// </summary>
            CAL_SRELATIVELONGDATE,
            /// <summary>
            /// Nomi inglesi delle ere per compatibilità con .Net.
            /// </summary>
            /// <remarks>Solo calendario giapponese.</remarks>
            CAL_SENGLISHERANAME,
            /// <summary>
            /// Nomi inglesi abbreviati delle ere per compatibilità con .Net.
            /// </summary>
            /// <remarks>Solo calendario giapponese.</remarks>
            CAL_SENGLISHABBREVERANAME,
            /// <summary>
            /// Primo anno ichinen o gannen.
            /// </summary>
            CAL_SJAPANESEFIRSTYEAR
        }

        /// <summary>
        /// ID calendario.
        /// </summary>
        internal enum CalendarID : CALID
        {
            /// <summary>
            /// Calendario gregoriano localizzato.
            /// </summary>
            CAL_GREGORIAN = 1,
            /// <summary>
            /// Calendario gregoriano Stati Uniti.
            /// </summary>
            CAL_GREGORIAN_US,
            /// <summary>
            /// Calendario ere giapponese.
            /// </summary>
            CAL_JAPAN,
            /// <summary>
            /// Calendario Taiwan.
            /// </summary>
            CAL_TAIWAN,
            /// <summary>
            /// Calendario delle ere coreano Tangun.
            /// </summary>
            CAL_KOREA,
            /// <summary>
            /// Calendario Hijri (arabico lunare).
            /// </summary>
            CAL_HIJRI,
            /// <summary>
            /// Calendario Thai.
            /// </summary>
            CAL_THAI,
            /// <summary>
            /// Calendario ebreo (lunare).
            /// </summary>
            CAL_HEBREW,
            /// <summary>
            /// Calendario gregoriano Middle East francese.
            /// </summary>
            CAL_GREGORIAN_ME_FRENCH,
            /// <summary>
            /// Calendario gregoriano arabico.
            /// </summary>
            CAL_GREGORIAN_ARABIC,
            /// <summary>
            /// Calendario gregoriano inglese transliterato.
            /// </summary>
            CAL_GREGORIAN_XLIT_ENGLISH,
            /// <summary>
            /// Calendario gregoriano francese transliterato.
            /// </summary>
            CAL_GREGORIAN_XLIT_FRENCH,
            /// <summary>
            /// Calendario persiano (Hijri solare).
            /// </summary>
            CAL_PERSIAN = 22,
            /// <summary>
            /// Calendario UmAlQura Hijri (arabico lunare).
            /// </summary>
            CAL_UMALQURA,
            /// <summary>
            /// Enumera tutti i calendari.
            /// </summary>
            ENUM_ALL_CALENDARS = 0xffffffff
        }

        /// <summary>
        /// Tipo di code page.
        /// </summary>
        internal enum CodePageType : DWORD
        {
            /// <summary>
            /// Solo le code pages installate.
            /// </summary>
            CP_INSTALLED = 1,
            /// <summary>
            /// Tutte le code pages supportate.
            /// </summary>
            CP_SUPPORTED
        }

        /// <summary>
        /// Formato data.
        /// </summary>
        [Flags]
        internal enum DateFormat : DWORD
        {
            /// <summary>
            /// Data corta.
            /// </summary>
            DATE_SHORTDATE = 1,
            /// <summary>
            /// Data lunga.
            /// </summary>
            DATE_LONGDATE = 2,
            /// <summary>
            /// Usa calendario alternativo.
            /// </summary>
            DATE_USE_ALT_CALENDAR = 4,
            /// <summary>
            /// Formato mese/anno.
            /// </summary>
            DATE_YEARMONTH = 8,
            /// <summary>
            /// Aggiunge indicatori per lettura da sinistra a destra.
            /// </summary>
            DATE_LTRREADING = 16,
            /// <summary>
            /// Aggiunge indicatori per lettura da destra a sinistra.
            /// </summary>
            DATE_RTLREADING = 32,
            /// <summary>
            /// Aggiunge indicatori appropriati per l'ordine di lettura.
            /// </summary>
            DATE_AUTOLAYOUT = 64,
            /// <summary>
            /// Formato mese/giorno.
            /// </summary>
            DATE_MONTHDAY = 128
        }

        /// <summary>
        /// Tipo di informazione geografica.
        /// </summary>
        internal enum SYSGEOTYPE
        {
            /// <summary>
            /// Latitudine.
            /// </summary>
            GEO_LATITUDE = 2,
            /// <summary>
            /// Longitudine.
            /// </summary>
            GEO_LONGITUDE,
            /// <summary>
            /// Codice ISO a 2 lettere.
            /// </summary>
            GEO_ISO2,
            /// <summary>
            /// Codice ISO a 3 lettere.
            /// </summary>
            GEO_ISO3,
            /// <summary>
            /// Nome della nazione.
            /// </summary>
            GEO_FRIENDLYNAME = 8,
            /// <summary>
            /// Nome ufficiale della nazione.
            /// </summary>
            GEO_OFFICIALNAME,
            /// <summary>
            /// Equivalente a <see cref="GEO_ISO3"/>.
            /// </summary>
            GEO_ISO_UN_NUMBER = 12,
            /// <summary>
            /// ID della regione padre.
            /// </summary>
            GEO_PARENT,
            /// <summary>
            /// Prefisso telefonico.
            /// </summary>
            GEO_DIALINGCODE,
            /// <summary>
            /// Codice a 3 lettere che rappresenta la moneta.
            /// </summary>
            GEO_CURRENCYCODE,
            /// <summary>
            /// 
            /// </summary>
            GEOCLASS_NATION = 16,
            /// <summary>
            /// Simbolo della moneta.
            /// </summary>
            GEO_CURRENCYSYMBOL = 16,
            /// <summary>
            /// Codice ISO a 2 lettere oppure codice numerico UN M.49.
            /// </summary>
            GEO_NAME
        }

        /// <summary>
        /// Tipo di località.
        /// </summary>
        [Flags]
        internal enum LocaleType : DWORD
        {
            /// <summary>
            /// Tutte le località.
            /// </summary>
            LOCALE_ALL,
            /// <summary>
            /// Località incluse oppure sosituzioni per esse.
            /// </summary>
            LOCALE_WINDOWS,
            /// <summary>
            /// Località supplementali.
            /// </summary>
            LOCALE_SUPPLEMENTAL,
            /// <summary>
            /// Località che hanno un ordinamento alternativo.
            /// </summary>
            LOCALE_ALTERNATE_SORTS = 4,
            /// <summary>
            /// Località che ha sostituito una località inclusa.
            /// </summary>
            /// <remarks>Questo valore è valido solo per il callback.</remarks>
            LOCALE_REPLACEMENT = 8,
            /// <summary>
            /// Località neutrali (solo lingua).
            /// </summary>
            LOCALE_NEUTRALDATA = 16,
            /// <summary>
            /// Località specifiche (con lingua e regione).
            /// </summary>
            LOCALE_SPECIFICDATA = 32
        }

        /// <summary>
        /// Formato orario.
        /// </summary>
        [Flags]
        internal enum TimeFormat : DWORD
        {
            /// <summary>
            /// Formato orario lungo dell'utente corrente.
            /// </summary>
            CurrentLongTime,
            /// <summary>
            /// Non usare i minuti o i secondi.
            /// </summary>
            TIME_NOMINUTESORSECONDS = 1,
            /// <summary>
            /// Non usare i secondi.
            /// </summary>
            TIME_NOSECONDS = 2,
            /// <summary>
            /// Non usare gli indicatori orari.
            /// </summary>
            TIME_NOTIMEMARKER = 4,
            /// <summary>
            /// Usa sempre il formato a 24 ore.
            /// </summary>
            TIME_FORCE24HOURFORMAT = 8,
        }

        /// <summary>
        /// Valori predefiniti per le code page.
        /// </summary>
        internal enum CodePageDefault : uint
        {
            /// <summary>
            /// ANSI code page.
            /// </summary>
            CP_ACP,
            /// <summary>
            /// OEM code page.
            /// </summary>
            CP_OEMCP,
            /// <summary>
            /// MAC code page.
            /// </summary>
            CP_MACCP,
            /// <summary>
            /// ANSI code page del thread corrente.
            /// </summary>
            CP_THREAD_ACP,
            /// <summary>
            /// Traduzione simboli.
            /// </summary>
            CP_SYMBOL = 42,
            /// <summary>
            /// Traduzione UTF-7.
            /// </summary>
            CP_UTF7 = 65000,
            /// <summary>
            /// Traduzione UTF-8.
            /// </summary>
            CP_UTF8
        }

        /// <summary>
        /// Formato del numero negativo per la moneta.
        /// </summary>
        internal enum NegativeCurrencyMode : uint
        {
            /// <summary>
            /// ($1.1)
            /// </summary>
            Mode0,
            /// <summary>
            /// -$1.1
            /// </summary>
            Mode1,
            /// <summary>
            /// $-1.1
            /// </summary>
            Mode2,
            /// <summary>
            /// $1.1-
            /// </summary>
            Mode3,
            /// <summary>
            /// (1.1$)
            /// </summary>
            Mode4,
            /// <summary>
            /// -1.1$
            /// </summary>
            Mode5,
            /// <summary>
            /// 1.1-$
            /// </summary>
            Mode6,
            /// <summary>
            /// 1.1$-
            /// </summary>
            Mode7,
            /// <summary>
            /// -1.1$
            /// </summary>
            Mode8,
            /// <summary>
            /// -$ 1.1
            /// </summary>
            Mode9,
            /// <summary>
            /// 1.1 $-
            /// </summary>
            Mode10,
            /// <summary>
            /// $ 1.1-
            /// </summary>
            Mode11,
            /// <summary>
            /// $ -1.1
            /// </summary>
            Mode12,
            /// <summary>
            /// 1.1- $
            /// </summary>
            Mode13,
            /// <summary>
            /// ($ 1.1)
            /// </summary>
            Mode14,
            /// <summary>
            /// (1.1 $)
            /// </summary>
            Mode15
        }

        /// <summary>
        /// Formato del numero negativo.
        /// </summary>
        internal enum NegativeNumberMode
        {
            /// <summary>
            /// (1.1)
            /// </summary>
            Mode0,
            /// <summary>
            /// -1.1
            /// </summary>
            Mode1,
            /// <summary>
            /// - 1.1
            /// </summary>
            Mode2,
            /// <summary>
            /// 1.1-
            /// </summary>
            Mode3,
            /// <summary>
            /// 1.1 -
            /// </summary>
            Mode4
        }

        /// <summary>
        /// Posizione del segno negativo.
        /// </summary>
        internal enum NegativeSignPositionCurrency : uint
        {
            /// <summary>
            /// Le parentesi circondano il numero e il simbolo.
            /// </summary>
            ParenthesisSurrounded,
            /// <summary>
            /// Prima del numero.
            /// </summary>
            BeforeNumber,
            /// <summary>
            /// Dopo il numero.
            /// </summary>
            AfterNumber,
            /// <summary>
            /// Prima del simbolo.
            /// </summary>
            BeforeSymbol,
            /// <summary>
            /// Dopo il simbolo.
            /// </summary>
            AfterSymbol
        }

        /// <summary>
        /// Posizione del simbolo in un valore monetario positivo.
        /// </summary>
        internal enum SymbolPositionPositiveCurrency : uint
        {
            /// <summary>
            /// $1.1
            /// </summary>
            PrefixNoSeparation,
            /// <summary>
            /// 1.1$
            /// </summary>
            SuffixNoSeparation,
            /// <summary>
            /// $ 1.1
            /// </summary>
            PrefixSingleCharacterSeparation,
            /// <summary>
            /// 1.1 $
            /// </summary>
            SuffixSingleCharacterSeparation
        }

        /// <summary>
        /// Informazione geografica da recuperare.
        /// </summary>
        internal enum GeoInfoType : LCTYPE
        {
            /// <summary>
            /// Nome completo localizzato della lingua dell'interfaccia utente.
            /// </summary>
            /// <remarks>la dimensione massima di questa stringa è di 80 caratteri.</remarks>
            LOCALE_SLOCALIZEDDISPLAYNAME = 0x02,
            /// <summary>
            /// Nome visualizzato della località in inglese.
            /// </summary>
            LOCALE_SENGLISHDISPLAYNAME = 0x72,
            /// <summary>
            /// Nome visualizzato della località nella lingua nativa.
            /// </summary>
            LOCALE_SNATIVEDISPLAYNAME = 0x73,
            /// <summary>
            /// Nome primario completo localizzato della lingua dell'interfaccia utente incluse nel nome visualizzato localizzato.
            /// </summary>
            LOCALE_SLOCALIZEDLANGUAGENAME = 0x6F,
            /// <summary>
            /// Nome inglese della lingua, come indicato dallo standard ISO 639.
            /// </summary>
            LOCALE_SENGLISHLANGUAGENAME = 0x1001,
            /// <summary>
            /// Nome nativo della lingua.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri.</remarks>
            LOCALE_SNATIVELANGUAGENAME = 0x04,
            /// <summary>
            /// Nome completo localizzato della nazione/regione.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri.</remarks>
            LOCALE_SLOCALIZEDCOUNTRYNAME = 0x06,
            /// <summary>
            /// Nome inglese della nazione/regione.
            /// </summary>
            LOCALE_SENGLISHCOUNTRYNAME = 0x1002,
            /// <summary>
            /// Nome nativo della nazione/regione.
            /// </summary>
            /// <remarks>La dimensiona massima di questa stringa è di 80 caratteri, incluso il carettere nullo finale.</remarks>
            LOCALE_SNATIVECOUNTRYNAME = 0x08,
            /// <summary>
            /// Prefisso telefonico internazionale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 6 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_IDIALINGCODE = 0x05,
            /// <summary>
            /// Carattere/i usati per separare oggetti in una lista.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SLIST = 0x0C,
            /// <summary>
            /// Sistema di misura.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di due caratteri, incluso il carattere nullo finale.<br/><br/>
            /// 0 se viene usato il sistema metrico decimale, 1 se viene usato il sistema statunitense.</remarks>
            LOCALE_IMEASURE = 0x0D,
            /// <summary>
            /// Carattere/i usati come separatore decimale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDECIMAL = 0x0E,
            /// <summary>
            /// Caratteri usati per separare i gruppi di cifre alla sinistra di un decimale.
            /// </summary>
            /// <remarks>La dimensiona massima della stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_STHOUSAND = 0x0F,
            /// <summary>
            /// Dimensioni per ogni gruppo di cifre alla sinistra di un decimale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 10 caratteri, incluso il carattere nullo finale.<br/>
            /// Deve essere indicata la dimensione di ogni gruppo, le dimensioni sono separate da punti e virgola.<br/>
            /// Se l'ultimo valore è 0, il valore precedente è ripetuto.<br/>
            /// Località Indic raggruppano le prime migliaia e poi ragguppano per centinaia.</remarks>
            LOCALE_SGROUPING = 0x10,
            /// <summary>
            /// Numero di cifre frazionarie dopo il separatore decimale.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è 2 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_IDIGITS = 0x11,
            /// <summary>
            /// Presenza di zero iniziali.
            /// </summary>
            /// <remarks>0 se non ci sono zero iniziali, 1 in caso contrario.</remarks>
            LOCALE_ILZERO = 0x12,
            /// <summary>
            /// Formato per i numeri negativi.
            /// </summary>
            /// <remarks>I valori sono i seguenti (seguiti da esempi):<br/><br/>
            /// 0: (1.1)<br/>
            /// 1: -1.1<br/>
            /// 2: - 1.1<br/>
            /// 3: 1.1-<br/>
            /// 4: 1.1 -</remarks>
            LOCALE_INEGNUMBER = 0x1010,
            /// <summary>
            /// Equivalenti nativi dei numeri ASCII da 0 a 9.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 11 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SNATIVEDIGITS = 0x13,
            /// <summary>
            /// Simbolo monetario.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 13 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SCURRENCY = 0x14,
            /// <summary>
            /// Tre caratteri che rappresentano il simbolo monetario internazionale come specificato in ISO 4217, seguiti dal carattere che separa questa stringa dalla quantità.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SINTLSYMBOL = 0x15,
            /// <summary>
            /// Carattere/i usato/i come separatore decimale per la valuta.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONDECIMALSEP = 0x16,
            /// <summary>
            /// Carattere/i usato/i come separatore tra gruppi di cifre alla sinistra del decimale per la valuta.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 4 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHOUSANDSEP = 0x17,
            /// <summary>
            /// Dimensioni per ogni gruppo di cifre alla sinistra di un decimale per la valuta.
            /// </summary>
            /// <remarks>La dimensione massima della stringa è di 10 caratteri, incluso il carattere nullo finale.<br/>
            /// Deve essere indicata la dimensione di ogni gruppo, le dimensioni sono separate da punti e virgola.<br/>
            /// Se l'ultimo valore è 0, il valore precedente è ripetuto.<br/>
            /// Località Indic raggruppano le prime migliaia e poi ragguppano per centinaia.</remarks>
            LOCALE_SMONGROUPING = 0x18,
            /// <summary>
            /// Numero di cifre frazionarie per il formato monetario locale.
            /// </summary>
            /// <remarks>La dimensiona massimo della stringa è di due caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_ICURRDIGITS = 0x19,
            /// <summary>
            /// Posizione del simbolo della valuta in un valore positivo.
            /// </summary>
            /// <remarks>I valori possibili sono:<br/><br/>
            /// 0: Prefisso, non separato, es. $1.1<br/>
            /// 1: Suffisso, non separato, es. 1.1$<br/>
            /// 2: Prefisso, separato da uno spazio, es. $ 1.1<br/>
            /// 3: Suffisso, separato da uno spazio, es. 1.1 $</remarks>
            LOCALE_ICURRENCY = 0x1B,
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
            LOCALE_INEGCURR = 0x1C,
            /// <summary>
            /// Stringa di formato per la data corta.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SSHORTDATE = 0x1F,
            /// <summary>
            /// Stringa di formato per la data lunga.
            /// </summary>
            /// <remarks>La dimensiona massima per questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SLONGDATE = 0x20,
            /// <summary>
            /// Stringa di formato per le ore.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_STIMEFORMAT = 0x1003,
            /// <summary>
            /// Stringa per il designatore AM.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 15 carattere, incluso il carattere nullo finale.</remarks>
            LOCALE_SAM = 0x28,
            /// <summary>
            /// Stringa per il designatore PM.
            /// </summary>
            /// <remarks>La dimensione massima per questa stringa è di 15 carattere, incluso il carattere nullo finale.</remarks>
            LOCALE_SPM = 0x29,
            /// <summary>
            /// Tipo di calendario.
            /// </summary>
            /// <remarks>I valori possibili sono inclusi nell'enumerazione <see cref="CalendarInfo"/>.</remarks>
            LOCALE_ICALENDARTYPE = 0x1009,
            /// <summary>
            /// Tipo di calendario facoltativo.
            /// </summary>
            /// <remarks>I valori possibili sono inclusi nell'enumerazione <see cref="CalendarInfo"/>.</remarks>
            LOCALE_IOPTIONALCALENDAR = 0x100B,
            /// <summary>
            /// Primo giorno della settimana come numero.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: <see cref="LOCALE_SDAYNAME1"/><br/>
            /// 1: <see cref="LOCALE_SDAYNAME2"/><br/>
            /// 2: <see cref="LOCALE_SDAYNAME3"/><br/>
            /// 3: <see cref="LOCALE_SDAYNAME4"/><br/>
            /// 4: <see cref="LOCALE_SDAYNAME5"/><br/>
            /// 5: <see cref="LOCALE_SDAYNAME6"/><br/>
            /// 6: <see cref="LOCALE_SDAYNAME7"/></remarks>
            LOCALE_IFIRSTDAYOFWEEK = 0x100C,
            /// <summary>
            /// Prima settimanta dell'anno.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: Settimana che contiene 1/1<br/>
            /// 1: Prima settimana completa che segue 1/1<br/>
            /// 2: Prima settimana che contiene almeno quattro giorni, compatibile con ISO 8601.</remarks>
            LOCALE_IFIRSTWEEKOFYEAR = 0x100D,
            /// <summary>
            /// Nome nativo per Lunedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME1 = 0x2A,
            /// <summary>
            /// Nome nativo per Martedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME2 = 0x2B,
            /// <summary>
            /// Nome nativo per Mercoledì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME3 = 0x2C,
            /// <summary>
            /// Nome nativo per Giovedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME4 = 0x2D,
            /// <summary>
            /// Nome nativo per Venerdì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME5 = 0x2E,
            /// <summary>
            /// Nome nativo per Sabato.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME6 = 0x2F,
            /// <summary>
            /// Nome nativo per Domenica.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SDAYNAME7 = 0x30,
            /// <summary>
            /// Nome nativo abbreviato per Lunedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME1 = 0x31,
            /// <summary>
            /// Nome nativo abbreviato per Martedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME2 = 0x32,
            /// <summary>
            /// Nome nativo abbreviato per Mercoledì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME3 = 0x33,
            /// <summary>
            /// Nome nativo abbreviato per Giovedì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME4 = 0x34,
            /// <summary>
            /// Nome nativo abbreviato per Venerdì.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME5 = 0x35,
            /// <summary>
            /// Nome nativo abbreviato per Sabato.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME6 = 0x36,
            /// <summary>
            /// Nome nativo abbreviato per Domenica.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVDAYNAME7 = 0x37,
            /// <summary>
            /// Nome lungo nativo per Gennaio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME1 = 0x38,
            /// <summary>
            /// Nome lungo nativo per Febbraio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME2 = 0x39,
            /// <summary>
            /// Nome lungo nativo per Marzo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME3 = 0x3A,
            /// <summary>
            /// Nome lungo nativo per Aprile.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME4 = 0x3B,
            /// <summary>
            /// Nome lungo nativo per Maggio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME5 = 0x3C,
            /// <summary>
            /// Nome lungo nativo per Giugno.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME6 = 0x3D,
            /// <summary>
            /// Nome lungo nativo per Luglio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME7 = 0x3E,
            /// <summary>
            /// Nome lungo nativo per Agosto.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME8 = 0x3F,
            /// <summary>
            /// Nome lungo nativo per Settembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME9 = 0x40,
            /// <summary>
            /// Nome lungo nativo per Ottobre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME10 = 0x41,
            /// <summary>
            /// Nome lungo nativo per Novembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME11 = 0x42,
            /// <summary>
            /// Nome lungo nativo per Dicembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME12 = 0x43,
            /// <summary>
            /// Nome lungo nativo per un tredicesimo mese, se esiste.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SMONTHNAME13 = 0x100E,
            /// <summary>
            /// Nome abbreviato nativo per Gennaio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME1 = 0x44,
            /// <summary>
            /// Nome abbreviato nativo per Febbraio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME2 = 0x45,
            /// <summary>
            /// Nome abbreviato nativo per Marzo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME3 = 0x46,
            /// <summary>
            /// Nome abbreviato nativo per Aprile.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME4 = 0x47,
            /// <summary>
            /// Nome abbreviato nativo per Maggio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME5 = 0x48,
            /// <summary>
            /// Nome abbreviato nativo per Giugno.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME6 = 0x49,
            /// <summary>
            /// Nome abbreviato nativo per Luglio.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME7 = 0x4A,
            /// <summary>
            /// Nome abbreviato nativo per Agosto.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME8 = 0x4B,
            /// <summary>
            /// Nome abbreviato nativo per Settembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME9 = 0x4C,
            /// <summary>
            /// Nome abbreviato nativo per Ottobre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME10 = 0x4D,
            /// <summary>
            /// Nome abbreviato nativo per Novembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME11 = 0x4E,
            /// <summary>
            /// Nome abbreviato nativo per Dicembre.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME12 = 0x4F,
            /// <summary>
            /// Nome abbreviato nativo per un tredicesimo mese, se esiste.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SABBREVMONTHNAME13 = 0x100F,
            /// <summary>
            /// Stringa localizzata per il simbolo positivo per la località.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 5 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SPOSITIVESIGN = 0x50,
            /// <summary>
            /// Stringa localizzata per il simbolo negativo per la località.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 5 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SNEGATIVESIGN = 0x51,
            /// <summary>
            /// Indice del simbolo positivo.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 1: Il segno precede il numero<br/>
            /// 2: Il segno segue il numero<br/>
            /// 3: Il segno precede il simbolo della valuta<br/>
            /// 4: Il segno segue il simbolo della valuta</remarks>
            LOCALE_IPOSSIGNPOSN = 0x52,
            /// <summary>
            /// Indice del simbolo negativo.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: Le parentesi circondano la quantità e il simbolo della valuta<br/>
            /// 1: Il segno precede il numero<br/>
            /// 2: Il segno segue il numero<br/>
            /// 3: Il segno precede il simbolo della valuta<br/>
            /// 4: Il segno segue il simbolo della valuta</remarks>
            LOCALE_INEGSIGNPOSN = 0x53,
            /// <summary>
            /// Posizione del simbolo della valuta in un valore positivo.
            /// </summary>
            /// <remarks>0 se il simbolo segue il valore, 1 se, invece, il simbolo precede il valore.</remarks>
            LOCALE_IPOSSYMPRECEDES = 0x54,
            /// <summary>
            /// Separazione del simbolo della valuta in un valore positivo.
            /// </summary>
            /// <remarks>0 se il simbolo non è separato da una spazio, 1 in caso contrario.</remarks>
            LOCALE_IPOSSEPBYSPACE = 0x55,
            /// <summary>
            /// Posizione del simbolo della valuta in un valore negativo.
            /// </summary>
            /// <remarks>0 se il simbolo segue il valore, 1 se, invece, il simbolo precede il valore.</remarks>
            LOCALE_INEGSYMPRECEDES = 0x56,
            /// <summary>
            /// Separazione del simbolo della valuta in un valore negativo.
            /// </summary>
            /// <remarks>0 se il simbolo non è separato da una spazio, 1 in caso contrario.</remarks>
            LOCALE_INEGSEPBYSPACE = 0x57,
            /// <summary>
            /// Uno specifico modello di bit che determina la relazione tra la copertura di caratteri necessaria per supportate la località e i contenuti del font.
            /// </summary>
            /// <remarks>Una struttura <see cref="LOCALESIGNATURE"/> raccoglie i dati di questo valore.</remarks>
            LOCALE_FONTSIGNATURE = 0x58,
            /// <summary>
            /// Nome abbreviato della lingua basato sui valori dello standard ISO 639, in minuscolo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SISO639LANGNAME = 0x59,
            /// <summary>
            /// Nome della nazione/regione, basato sullo standard ISO 3166.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SISO3166CTRYNAME = 0x5A,
            /// <summary>
            /// Dimensione predefinita della carta associata con la località.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 1: Lettera US<br/>
            /// 5: carta legale US<br/>
            /// 8: A3<br/>
            /// 9: A4</remarks>
            LOCALE_IPAPERSIZE = 0x100A,
            /// <summary>
            /// Nome inglese completo della valuta associata alla località.
            /// </summary>
            LOCALE_SENGCURRNAME = 0x1007,
            /// <summary>
            /// Nome nativo completo della valuta associata alla località.
            /// </summary>
            LOCALE_SNATIVECURRNAME = 0x1008,
            /// <summary>
            /// Stringa di formato anno-mese per la località.
            /// </summary>
            /// <remarks>La dimensiona massima di caratteri di questa stringa è di 80 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SYEARMONTH = 0x1006,
            /// <summary>
            /// Nome della località da usare per l'ordinamento o il comportamento relativamente alle maiuscole.
            /// </summary>
            LOCALE_SSORTNAME = 0x1013,
            /// <summary>
            /// Forma delle cifre.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: sostituzione basato sul contesto<br/>
            /// 1: nessuna sostituzione<br/>
            /// 2: sostituzione nativa, in base a <see cref="LOCALE_SNATIVEDIGITS"/>.</remarks>
            LOCALE_IDIGITSUBSTITUTION = 0x1014,
            /// <summary>
            /// Nome località, tag multi parte che la identifica in modo univoco.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è pari al valore di <see cref="LOCALE_NAME_MAX_LENGTH"/>, incluso il carattere nullo finale.<br/><br/>
            /// Il tag è basato sulle convenzioni del documento IETF BCP 47.</remarks>
            LOCALE_SNAME = 0x5C,
            /// <summary>
            /// Stringa di formato per la durata.
            /// </summary>
            LOCALE_SDURATION = 0x5D,
            /// <summary>
            /// Nome nativo corto del primo giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME1 = 0x60,
            /// <summary>
            /// Nome nativo corto del secondo giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME2 = 0x61,
            /// <summary>
            /// Nome nativo corto del terzo giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME3 = 0x62,
            /// <summary>
            /// Nome nativo corto del quarto giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME4 = 0x63,
            /// <summary>
            /// Nome nativo corto del quinto giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME5 = 0x64,
            /// <summary>
            /// Nome nativo corto del sesto giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME6 = 0x65,
            /// <summary>
            /// Nome nativo corto del settimo giorno della settimana.
            /// </summary>
            LOCALE_SSHORTESTDAYNAME7 = 0x66,
            /// <summary>
            /// Nome ISO a tre lettere della lingua, minuscolo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SISO639LANGNAME2 = 0x67,
            /// <summary>
            /// Nome ISO a tre lettere della regione, minuscolo.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è di 9 caratteri, incluso il carattere nullo finale.</remarks>
            LOCALE_SISO3166CTRYNAME2 = 0x68,
            /// <summary>
            /// Valore per "Not a number".
            /// </summary>
            LOCALE_SNAN = 0x69,
            /// <summary>
            /// Valore per "infinito positivo".
            /// </summary>
            LOCALE_SPOSINFINITY = 0x6A,
            /// <summary>
            /// Valore per "infinito negativo".
            /// </summary>
            LOCALE_SNEGINFINITY = 0x6B,
            /// <summary>
            /// Lista di script, usando la notazione a 4 caratteri di ISO 15924.
            /// </summary>
            /// <remarks>la lista è in ordine alfabetico, tutti i nomi, compreso l'ultimo sono seguiti da un punto e virgola.</remarks>
            LOCALE_SSCRIPTS = 0x6C,
            /// <summary>
            /// Località di fallback, usata dal caricatore risorse.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è pari al valore di <see cref="LOCALE_NAME_MAX_LENGTH"/>, incluso il carattere nullo finale.</remarks>
            LOCALE_SPARENT = 0x6D,
            /// <summary>
            /// Località preferita da usare per la visualizzazione del testo nella console.
            /// </summary>
            /// <remarks>La dimensione massima di questa stringa è pari al valore di <see cref="LOCALE_NAME_MAX_LENGTH"/>, incluso il carattere nullo finale.</remarks>
            LOCALE_SCONSOLEFALLBACKNAME = 0x6E,
            /// <summary>
            /// Direzione di lettura.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: lettura da sinistra a destra<br/>
            /// 1: lettura da destra a sinistra<br/>
            /// 2: lettura verticale dall'alto verso il basso, con colonne che vanno da destra verso sinistra, oppure lettura in linee orizzontali da sinistra a destra.
            /// 3: lettura verticale dall'alto verso il basso cono colonne che vanno da sinistra a destra.</remarks>
            LOCALE_IREADINGLAYOUT = 0x70,
            /// <summary>
            /// Tipo di località.
            /// </summary>
            /// <remarks>0 indica una località specifica, 1 indica una località neutrale.</remarks>
            LOCALE_INEUTRAL = 0x71,
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
            LOCALE_INEGATIVEPERCENT = 0x74,
            /// <summary>
            /// Stringa di formato per la percentuale positiva.
            /// </summary>
            /// <remarks>I valori possibili sono i seguenti:<br/><br/>
            /// 0: numero, spazio, percentuale<br/>
            /// 1: numero, percentuale<br/>
            /// 2: percentuale, numero<br/>
            /// 3: percentuale, spazio, numero</remarks>
            LOCALE_IPOSITIVEPERCENT = 0x75,
            /// <summary>
            /// Simbolo usato per indicare la percentuale.
            /// </summary>
            /// <remarks>La stringa può avere fino a tre caratteri.</remarks>
            LOCALE_SPERCENT = 0x76,
            /// <summary>
            /// Simbolo usato per indicare il permille.
            /// </summary>
            LOCALE_SPERMILLE = 0x77,
            /// <summary>
            /// Stringa di formato per visualizzare solo il mese e il giorno.
            /// </summary>
            LOCALE_SMONTHDAY = 0x78,
            /// <summary>
            /// Stringa di formato per l'ora corta.
            /// </summary>
            /// <remarks>Possono essere restituiti più formati, separati dal punto e virgola.</remarks>
            LOCALE_SSHORTTIME = 0x79,
            /// <summary>
            /// Tag di lingua OpenType usato per recuperare le funzionalità tipografiche culturalmente appropriate.
            /// </summary>
            LOCALE_SOPENTYPELANGUAGETAG = 0x7A,
            /// <summary>
            /// Nome della località da usare per l'ordinamento e il comportamento relativo alle maiuscole.
            /// </summary>
            LOCALE_SSORTLOCALE = 0x7B,
            /// <summary>
            /// Data lunga senza anno, giorno della settimana, mese e data.
            /// </summary>
            LOCALE_SRELATIVELONGDATE = 0x7C,
            /// <summary>
            /// Indica se la località è "costruita", cioè creata con dati da diverse fonti.
            /// </summary>
            /// <remarks>0 se la località non è "costruita", 1 in caso contrario.</remarks>
            LOCALE_ICONSTRUCTEDLOCALE = 0x7D,
            /// <summary>
            /// Indicatore AM più corto possibile.
            /// </summary>
            LOCALE_SSHORTESTAM = 0x7E,
            /// <summary>
            /// Indicatore PM più corto possibile.
            /// </summary>
            LOCALE_SSHORTESTPM = 0x7F,
            /// <summary>
            /// Code page legacy da usare su una macchina non UTF-8.
            /// </summary>
            LOCALE_IUSEUTF8LEGACYACP = 0x666,
            /// <summary>
            /// Code page OEM legacy da usare su una macchina non UTF-8.
            /// </summary>
            LOCALE_IUSEUTF8LEGACYOEMCP = 0x999,
            /// <summary>
            /// Lista di tastiere separate da punti e virgola da potenzialmente installare per la località ed essere usate internamente da Windows.
            /// </summary>
            LOCALE_SKEYBOARDSTOINSTALL = 0x5E
        }

        /// <summary>
        /// Informazioni sui caratteri da recuperare.
        /// </summary>
        internal enum StringCharacterTypeInfo : DWORD
        {
            /// <summary>
            /// Tipo di caratteri.
            /// </summary>
            CT_CTYPE1 = 1,
            /// <summary>
            /// Informazioni sul layout.
            /// </summary>
            CT_CTYPE2 = 2,
            /// <summary>
            /// Informazioni sull'elaborazione del testo.
            /// </summary>
            CT_CTYPE3 = 4
        }

        /// <summary>
        /// Tipi di caratteri in una stringa.
        /// </summary>
        [Flags]
        internal enum CharacterTypeValues : ushort
        {
            /// <summary>
            /// Maiuscolo.
            /// </summary>
            C1_UPPER = 1,
            /// <summary>
            /// Minuscolo.
            /// </summary>
            C1_LOWER = 2,
            /// <summary>
            /// Cifra decimale.
            /// </summary>
            C1_DIGIT = 4,
            /// <summary>
            /// Spazio.
            /// </summary>
            C1_SPACE = 8,
            /// <summary>
            /// Punteggiatura.
            /// </summary>
            C1_PUNCT = 16,
            /// <summary>
            /// Carattere di controllo.
            /// </summary>
            C1_CNTRL = 32,
            /// <summary>
            /// Carattere vuoto.
            /// </summary>
            C1_BLANK = 64,
            /// <summary>
            /// Cifra esadecimale.
            /// </summary>
            C1_XDIGIT = 128,
            /// <summary>
            /// Qualunque carattere linguistico (alfabetico, sillabario, ideografico).
            /// </summary>
            C1_ALPHA = 256,
            /// <summary>
            /// Carattere definito, ma non è nessuno degli altri tipi.
            /// </summary>
            C1_DEFINED = 512
        }

        /// <summary>
        /// Informazioni del layout dei caratteri.
        /// </summary>
        internal enum StringLayoutValues : ushort
        {
            /// <summary>
            /// Da sinistra a destra.
            /// </summary>
            C2_LEFTTORIGHT = 1,
            /// <summary>
            /// Da destra a sinistra.
            /// </summary>
            C2_RIGHTTOLEFT,
            /// <summary>
            /// Numero europeo. cifra europea.
            /// </summary>
            C2_EUROPENUMBER,
            /// <summary>
            /// Separatore numerico europeo.
            /// </summary>
            C2_EUROPESEPARATOR,
            /// <summary>
            /// Terminatore numerico europeo.
            /// </summary>
            C2_EUROPETERMINATOR,
            /// <summary>
            /// Numero arabo.
            /// </summary>
            C2_ARABICNUMBER,
            /// <summary>
            /// Separatore numerico comune.
            /// </summary>
            C2_COMMONSEPARATOR,
            /// <summary>
            /// Separatore blocco.
            /// </summary>
            C2_BLOCKSEPARATOR,
            /// <summary>
            /// Separatore segmento.
            /// </summary>
            C2_SEGMENTSEPARATOR,
            /// <summary>
            /// Spazio bianco.
            /// </summary>
            C2_WHITESPACE,
            /// <summary>
            /// Altri caratteri neutrali.
            /// </summary>
            C2_OTHERNEUTRAL,
            /// <summary>
            /// Nessuna direzionalità implicita.
            /// </summary>
            C2_NOTAPPLICABLE = 0
        }

        /// <summary>
        /// Informazioni di elaborazione testo.
        /// </summary>
        [Flags]
        internal enum StringTextProcessingValues : ushort
        {
            /// <summary>
            /// Segno nonspacing.
            /// </summary>
            C3_NONSPACING = 1,
            /// <summary>
            /// Segno diacritico nonspacing.
            /// </summary>
            C3_DIACRITIC = 2,
            /// <summary>
            /// Segno nonspacing di una vocale.
            /// </summary>
            C3_VOWELMARK = 4,
            /// <summary>
            /// Simbolo.
            /// </summary>
            C3_SYMBOL = 8,
            /// <summary>
            /// Carattere katakana.
            /// </summary>
            C3_KATAKANA = 16,
            /// <summary>
            /// Carattere hiragana.
            /// </summary>
            C3_HIRAGANA = 32,
            /// <summary>
            /// Carattere a metà dimensione (half-width).
            /// </summary>
            C3_HALFWIDTH = 64,
            /// <summary>
            /// Carattere a piena dimensione (full-width).
            /// </summary>
            C3_FULLWIDTH = 128,
            /// <summary>
            /// Carattere ideografico.
            /// </summary>
            C3_IDEOGRAPH = 256,
            /// <summary>
            /// Carattere arabo kashida.
            /// </summary>
            C3_KASHIDA = 512,
            /// <summary>
            /// Punteggiatura che conta come parte della parola.
            /// </summary>
            C3_LEXICAL = 1024,
            /// <summary>
            /// Tutti i caratteri linguistici (alfabetico, sillabario, ideografico).
            /// </summary>
            C3_ALPHA = 32768,
            /// <summary>
            /// 
            /// </summary>
            C3_HIGHSURROGATE = 2048,
            /// <summary>
            /// 
            /// </summary>
            C3_LOWSURROGATE = 4096,
            /// <summary>
            /// Non applicabile.
            /// </summary>
            C3_NOTAPPLICABLE = 0
        }

        /// <summary>
        /// Opzioni di conversione IDN.
        /// </summary>
        internal enum IdnConversionOptions : DWORD
        {
            /// <summary>
            /// Permette la presenza di code points non assegnati.
            /// </summary>
            IDN_ALLOW_UNASSIGNED = 1,
            /// <summary>
            /// Filtra i caratteri ASCII non permessi nei nomi STD3.
            /// </summary>
            /// <remarks>Gli unici caratteri autorizzati sono lettere, cifre e il segno "-", la stringa non può iniziare né finire con quest'ultimo e non può contenere caratteri che non possono esserci in nomi di dominio oppure caratteri di controllo o il carattere "delete".<br/><br/>
            /// Questa opzione non ha effetto sui carattere non-ASCII.</remarks>
            IDN_USE_STD3_ASCII_RULES,
            /// <summary>
            /// Abilita il fallback algoritmico EAI (Email Address Internationalization) per la parte locale dell'indirizzo email.
            /// </summary>
            IDN_EMAIL_ADDRESS = 4,
            /// <summary>
            /// Disabilità la convalida e la mappatura di Punycode.
            /// </summary>
            IDN_RAW_PUNYCODE = 8,
        }

        /// <summary>
        /// Forme normalizzate di una stringa.
        /// </summary>
        internal enum NORM_FORM
        {
            /// <summary>
            /// Non supportato.
            /// </summary>
            NormalizationOther,
            /// <summary>
            /// Composizione canonica.
            /// </summary>
            /// <remarks>Trasforma ogni raggruppamento decomposto nel suo equivalente precomposto.</remarks>
            NormalizationC,
            /// <summary>
            /// Decomposizione canonica.
            /// </summary>
            /// <remarks>Trasforma ogni carattere precomposto nel suo equivalente decomposto canonico.</remarks>
            NormalizationD,
            /// <summary>
            /// Composizione per compatibilità
            /// </summary>
            /// <remarks>Trasforma ogni base più carattere combinato nell'equivalente precomposto e tutti i caratteri di compatibilità nei loro equivalenti.</remarks>
            NormalizationKC = 5,
            /// <summary>
            /// Decomposizione per compatibilità.
            /// </summary>
            /// <remarks>Trasforma ogni carattere precomposto nell'equivalente decomposto canonico e tutti i caratteri di compatibilità nei loro equivalenti.</remarks>
            NormalizationKD
        }

        /// <summary>
        /// Posizione di partenza dove iniziare la ricerca.
        /// </summary>
        internal enum StringSearchStartingPosition : DWORD
        {
            /// <summary>
            /// Controlla l'inizio della stringa.
            /// </summary>
            FIND_STARTSWITH = 0x00100000,
            /// <summary>
            /// Controlla la fine della stringa.
            /// </summary>
            FIND_ENDSWITH = 0x00200000,
            /// <summary>
            /// Controlla l'intera stringa, partendo dall'inizio.
            /// </summary>
            FIND_FROMSTART = 0x00400000,
            /// <summary>
            /// Controlla l'intera stringa, partendo dalla fine.
            /// </summary>
            FIND_FROMEND = 0x00800000
        }

        /// <summary>
        /// Opzioni per il confronto tra stringhe.
        /// </summary>
        [Flags]
        internal enum StringComparisonOptions : DWORD
        {
            /// <summary>
            /// Non distinguere tra maiuscole e minuscole.
            /// </summary>
            /// <remarks>Per alcuni script, questa opzione distingue tra le diverse forme di un carattere ma le differenze potrebbero non essere linguistiche.<br/>
            /// <see cref="LINGUISTIC_IGNORECASE"/> ignora solo casi linguistici.</remarks>
            NORM_IGNORECASE = 1,
            /// <summary>
            /// Ignora caratteri non spacing.
            /// </summary>
            /// <remarks>Alcuni script usano i diacritici per altre ragioni, queste differenze possono non corrispondere a una differenza linguistica.<br/>
            /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/> ignora solo effettivi diacritici.</remarks>
            NORM_IGNORENONSPACE,
            /// <summary>
            /// Ignora i simboli e la punteggiatura.
            /// </summary>
            NORM_IGNORESYMBOLS = 4,
            /// <summary>
            /// Non distinguere tra maiuscole e minuscole.
            /// </summary>
            LINGUISTIC_IGNORECASE = 16,
            /// <summary>
            /// Ignora i diacritici.
            /// </summary>
            LINGUISTIC_IGNOREDIACRITIC = 32,
            /// <summary>
            /// Non distinguere i caratteri hiragana dai caratteri katakana.
            /// </summary>
            NORM_IGNOREKANATYPE = 65536,
            /// <summary>
            /// Ignora la differenza tra caratteri half-width e full-width.
            /// </summary>
            NORM_IGNOREWIDTH = 131072,
            /// <summary>
            /// Usa regole linguistiche per la differenza tra maiuscole e minuscole al posto delle regole del file system.
            /// </summary>
            NORM_LINGUISTIC_CASING = 134217728
        }

        /// <summary>
        /// Funzionalità NLS.
        /// </summary>
        internal enum SYSNLS_FUNCTION
        {
            /// <summary>
            /// Confronti tra stringhe.
            /// </summary>
            COMPARE_STRING = 1
        }

        /// <summary>
        /// Trasformazione da effettuare.
        /// </summary>
        [Flags]
        internal enum StringMappingTrasformation : DWORD
        {
            /// <summary>
            /// Mappa tutti i caratteri ai loro equivalenti minuscoli.
            /// </summary>
            LCMAP_LOWERCASE = 256,
            /// <summary>
            /// Mappa tutti i caratteri ai loro equivalenti maiuscoli.
            /// </summary>
            LCMAP_UPPERCASE = 512,
            /// <summary>
            /// Sostituisci tutte le prime lettere di ogni parole con l'equivalente maiuscolo.
            /// </summary>
            LCMAP_TITLECASE = 768,
            /// <summary>
            /// Crea una chiave di ordinamento normalizzata.
            /// </summary>
            LCMAP_SORTKEY = 1024,
            /// <summary>
            /// Inversione dei byte.
            /// </summary>
            LCMAP_BYTEREV = 2048,
            /// <summary>
            /// Mappa tutti i caratteri katakana ai caratteri hiragana.
            /// </summary>
            /// <remarks>Non può essere combinato con <see cref="LCMAP_KATAKANA"/>.</remarks>
            LCMAP_HIRAGANA = 1048576,
            /// <summary>
            /// Mappa tutti i caratteri hiragana ai caratteri katakana.
            /// </summary>
            /// <remarks>Non può essere combinato con <see cref="LCMAP_HIRAGANA"/>.</remarks>
            LCMAP_KATAKANA = 2097152,
            /// <summary>
            /// Usa caratteri half-width dove applicabile.
            /// </summary>
            /// <remarks>Non può essere combinato con <see cref="LCMAP_FULLWIDTH"/>.</remarks>
            LCMAP_HALFWIDTH = 4194304,
            /// <summary>
            /// Usa caratteri full-width dove applicabile.
            /// </summary>
            /// <remarks>Non può essere combinato con <see cref="LCMAP_HALFWIDTH"/>.</remarks>
            LCMAP_FULLWIDTH = 8388608,
            /// <summary>
            /// Usa le regole linguistiche al posto di quelle del file system per le lettere maiuscole.
            /// </summary>
            /// <remarks>Può essere combinato solo con <see cref="LCMAP_LOWERCASE"/> e <see cref="LCMAP_UPPERCASE"/>.</remarks>
            LCMAP_LINGUISTIC_CASING = 16777216,
            /// <summary>
            /// Mappa i caratteri cinesi tradizionali ai caratteri semplificati.
            /// </summary>
            /// <remarks>Non può essere usato con <see cref="LCMAP_TRADITIONAL_CHINESE"/>.</remarks>
            LCMAP_SIMPLIFIED_CHINESE = 33554432,
            /// <summary>
            /// Mappa i caratteri cinesi semplificati ai caratteri tradizionali.
            /// </summary>
            /// <remarks>Non può essere usato con <see cref="LCMAP_SIMPLIFIED_CHINESE"/>.</remarks>
            LCMAP_TRADITIONAL_CHINESE = 67108864,
            /// <summary>
            /// Restituisce un toke che rappresenta i parametri di ordinamento per la località.
            /// </summary>
            /// <remarks>Il buffer deve essere della dimensione di un valore di tipo <see cref="LPARAM"/>.</remarks>
            LCMAP_SORTHANDLE = 536870912,
            /// <summary>
            /// Restituisce un hash dei pesi di ordinamento di una stringa.
            /// </summary>
            /// <remarks>Il buffer deve essere della dimensione di un valore di tipo <see cref="int"/>.</remarks>
            LCMAP_HASH = 262144
        }

        /// <summary>
        /// Opzioni di ordinamento stringhe.
        /// </summary>
        [Flags]
        internal enum StringSortingOptions : DWORD
        {
            /// <summary>
            /// Tratta la punteggiatura allo stesso modo dei simboli.
            /// </summary>
            SORT_STRINGSORT = 4096,
            /// <summary>
            /// Tratta le cifre come numeri durante l'ordinamento.
            /// </summary>
            SORT_DIGITSASNUMBERS = 8
        }

        /// <summary>
        /// Risultato del confronto tra stringhe.
        /// </summary>
        internal enum StringComparisonResult
        {
            /// <summary>
            /// Confronto non riuscito.
            /// </summary>
            Failed,
            /// <summary>
            /// Stringa 1 ha un valore lessicale minore rispetto a stringa 2.
            /// </summary>
            CSTR_LESS_THAN = 1,
            /// <summary>
            /// Stringa 1 e stringa 2 hanno equivalente valore lessicale.
            /// </summary>
            CSTR_EQUAL,
            /// <summary>
            /// Stringa 1 ha un valore lessicale maggiore rispetto a stringa 2.
            /// </summary>
            CSTR_GREATER_THAN
        }

        /// <summary>
        /// Trasformazione da effettuare.
        /// </summary>
        /// <remarks>Questa enumerazione è usata dalla funzione <see cref="NationalLanguageSupportFunctions.ConvertString2"/>.</remarks>
        [Flags]
        internal enum StringMappingTransformation2 : DWORD
        {
            /// <summary>
            /// Trasforma i caratteri della zona di compatibilità nei loro equivalenti Unicode.
            /// </summary>
            MAP_FOLDCZONE = 16,
            /// <summary>
            /// Mappa i caratteri accentati ai relativi caratteri precomposti.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="MAP_COMPOSITE"/>.</remarks>
            MAP_PRECOMPOSED = 32,
            /// <summary>
            /// Mappa i caratteri accentati ai relativi caratteri decomposti.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="MAP_PRECOMPOSED"/>.</remarks>
            MAP_COMPOSITE = 64,
            /// <summary>
            /// Mappa tutte le cifre ai caratteri Unicode da 0 a 9.
            /// </summary>
            MAP_FOLDDIGITS = 128,
            /// <summary>
            /// Espande tutti i caratteri di legatura così che siano rappresentati dai loro equivalenti a due caratteri.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="MAP_PRECOMPOSED"/> o <see cref="MAP_COMPOSITE"/>.</remarks>
            MAP_EXPAND_LIGATURES = 8192
        }

        /// <summary>
        /// Forma delle cifre.
        /// </summary>
        internal enum DigitsShape
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
            ContextBased,
            /// <summary>
            /// Nessuna sostituzione.
            /// </summary>
            NoSubstitution,
            /// <summary>
            /// Sostituzione con cifre native.
            /// </summary>
            NativeDigitSubstituion
        }

        /// <summary>
        /// Prima settimana dell'anno.
        /// </summary>
        internal enum FirstWeekOfYear
        {
            /// <summary>
            /// Settimana contenente 1/1.
            /// </summary>
            WeekContaining1_1,
            /// <summary>
            /// Prima settimana completa dopo 1/1.
            /// </summary>
            FirstFullWeekAfter1_1,
            /// <summary>
            /// Prima settimana contenente almeno quattro giorni, compatibile con ISO 8601.
            /// </summary>
            FirstWeekWithFourDaysISO8601
        }

        /// <summary>
        /// Dimensione predefinita della carta.
        /// </summary>
        internal enum DefaultPaperSize : short
        {
            None,
            /// <summary>
            /// Lettera Stati Uniti.
            /// </summary>
            DMPAPER_LETTER = 1,

            DMPAPER_LETTER_SMALL,

            DMPAPER_TABLOID,

            DMPAPER_LEDGER,
            /// <summary>
            /// Lettera legale Stati Uniti.
            /// </summary>
            DMPAPER_LEGAL,

            DMPAPER_STATEMENT,

            DMPAPER_EXECUTIVE,
            /// <summary>
            /// A3.
            /// </summary>
            DMPAPER_A3,
            /// <summary>
            /// A4.
            /// </summary>
            DMPAPER_A4,

            DMPAPER_A4SMALL,

            DMPAPER_A5,

            DMPAPER_B4,

            DMPAPER_B5,

            DMPAPER_FOLIO,

            DMPAPER_QUARTO,

            DMPAPER_10X14,

            DMPAPER_11X17,

            DMPAPER_NOTE,

            DMPAPER_ENV_9,

            DMPAPER_ENV_10,

            DMPAPER_ENV_11,

            DMPAPER_ENV_12,

            DMPAPER_ENV_14,

            DMPAPER_CSHEET,

            DMPAPER_DSHEET,

            DMPAPER_ESHEET,

            DMPAPER_ENV_DL,

            DMPAPER_ENV_C5,

            DMPAPER_ENV_C3,

            DMPAPER_ENV_C4,

            DMPAPER_ENV_C6,

            DMPAPER_ENV_C65,

            DMPAPER_ENV_B4,

            DMPAPER_ENV_B5,

            DMPAPER_ENV_B6,

            DMPAPER_ENV_ITALY,

            DMPAPER_ENV_MONARCH,

            DMPAPER_ENV_PERSONAL,

            DMPAPER_FANFOLD_US,

            DMPAPER_FANFOLD_STD_GERMAN,

            DMPAPER_FANFOLD_LGL_GERMAN,

            DMPAPER_ISO_B4,

            DMPAPER_JAPANESE_POSTCARD,

            DMPAPER_9X11,

            DMPAPER_10X11,

            DMPAPER_15X11,

            DMPAPER_ENV_INVITE,

            DMPAPER_LETTER_EXTRA = 50,

            DMPAPER_LEGAL_EXTRA,

            DMPAPER_TABLOID_EXTRA,

            DMPAPER_A4_EXTRA,

            DMPAPER_LETTER_TRANSVERSE,

            DMPAPER_A4_TRANSVERSE,

            DMPAPER_LETTER_EXTRA_TRANSVERSE,

            DMPAPER_A_PLUS,

            DMPAPER_B_PLUS,

            DMPAPER_LETTER_PLUS,

            DMPAPER_A4_PLUS,

            DMPAPER_A5_TRANSVERSE,

            DMPAPER_B5_TRANSVERSE,

            DMPAPER_A3_EXTRA,

            DMPAPER_A5_EXTRA,

            DMPAPER_B5_EXTRA,

            DMPAPER_A2,

            DMPAPER_A3_TRANSVERSE,

            DMPAPER_A3_EXTRA_TRASVERSE,

            DMPAPER_DBL_JAPANESE_POSTCARD,

            DMPAPER_A6,

            DMPAPER_JENV_KAKU2,

            DMPAPER_JENV_KAKU3,

            DMPAPER_JENV_CHOU3,

            DMPAPER_JENV_CHOU4,

            DMPAPER_LETTER_ROTATED,

            DMPAPER_A3_ROTATED,

            DMPAPER_A4_ROTATED,

            DMPAPER_A5_ROTATED,

            DMPAPER_B4_JIS_ROTATED,

            DMPAPER_B5_JIS_ROTATED,

            DMPAPER_JAPANESE_POSTCARD_ROTATED,

            DMPAPER_DBL_JAPANESE_POSTCARD_ROTATED,

            DMPAPER_A6_ROTATED,

            DMPAPER_JENV_KAKU2_ROTATED,

            DMPAPER_JENV_KAKU3_ROTATED,

            DMPAPER_JENV_CHOU3_ROTATED,

            DMPAPER_JENV_CHOU4_ROTATED,

            DMPAPER_B6_JIS,

            DMPAPER_B6_JIS_ROTATED,

            DMPAPER_12X11,

            DMPAPER_JENV_YOU4,

            DMPAPER_JENV_YOU4_ROTATED,

            DMPAPER_P16K,

            DMPAPER_P32K,

            DMPAPER_P32KBIG,

            DMPAPER_PENV_1,

            DMPAPER_PENV_2,

            DMPAPER_PENV_3,

            DMPAPER_PENV_4,

            DMPAPER_PENV_5,

            DMPAPER_PENV_6,

            DMPAPER_PENV_7,

            DMPAPER_PENV_8,

            DMPAPER_PENV_9,

            DMPAPER_PENV_10,

            DMPAPER_P16K_ROTATED,

            DMPAPER_P32K_ROTATED,

            DMPAPER_P32KBIG_ROTATED,

            DMPAPER_PENV_1_ROTATED,

            DMPAPER_PENV_2_ROTATED,

            DMPAPER_PENV_3_ROTATED,

            DMPAPER_PENV_4_ROTATED,

            DMPAPER_PENV_5_ROTATED,

            DMPAPER_PENV_6_ROTATED,

            DMPAPER_PENV_7_ROTATED,

            DMPAPER_PENV_8_ROTATED,

            DMPAPER_PENV_9_ROTATED,

            DMPAPER_PENV_10_ROTATED
        }

        /// <summary>
        /// Ordine di lettura.
        /// </summary>
        internal enum ReadingOrder
        {
            /// <summary>
            /// Da sinista a destra.
            /// </summary>
            LeftToRight,
            /// <summary>
            /// Da destra a sinistra.
            /// </summary>
            RightToLeft,
            /// <summary>
            /// Verticalmente dall'alto verso il basso da destra a sinistra oppure orizzontalmente da sinistra a destra.
            /// </summary>
            VerticallyTopToBottomRightToLeftOrHorizontalLeftToRight,
            /// <summary>
            /// Verticalmente dall'alto verso il basso da sinistra a destra.
            /// </summary>
            VerticallyTopToBottomLeftToRight
        }
    }
}