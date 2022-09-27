using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;

namespace WinApiWrapper.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Strutture NLS.
    /// </summary>
    internal static class NationalLanguageSupportStructures
    {
        /// <summary>
        /// Informazioni su una code page.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct CPINFOEX
        {
            /// <summary>
            /// Dimensione massima, in bytes, di un carattere nella code page.
            /// </summary>
            public uint MaxCharSize;
            /// <summary>
            /// Carattere predefinito usato per tradurre stringhe nella code page.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)MAX_DEFAULTCHAR)]
            public byte[] DefaultChar;
            /// <summary>
            /// Array di lunghezza fissa di porzioni di byte iniziali.
            /// </summary>
            /// <remarks>Se la code page non ha byte iniziali, i valori di questo array sono 0, in caso contrario l'array specifica un valore iniziale e un valore finale per ogni porzione.<br/>
            /// I valori sono inclusi e il numero massimo di porzioni è 5.<br/><br/>
            /// L'array usa due byte per descrivere ogni porzione, con due byte come terminatore dopo l'ultima porzione.</remarks>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)MAX_LEADBYTES)]
            public byte[] LeadByte;
            /// <summary>
            /// Carattere Unicode predefinito usato nella traduzione dalla code page.
            /// </summary>
            public WCHAR UnicodeDefaultChar;
            /// <summary>
            /// ID code page.
            /// </summary>
            public uint CodePage;
            /// <summary>
            /// Nome completo della code page.
            /// </summary>
            /// <remarks>Questo nome è localizzato e non è garantito per unicità o consistenza tra versioni del sistema operativo o computer.</remarks>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PATH)]
            public WCHAR[] CodePageName;
        }

        /// <summary>
        /// Informazioni sul formato di una stringa monetaria.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CURRENCYFMT
        {
            /// <summary>
            /// Numero di cifre frazionarie.
            /// </summary>
            public uint FractionalDigitsCount;
            /// <summary>
            /// Indica se le decine devono essere preceduta dallo 0.
            /// </summary>
            public uint LeadingZero;
            /// <summary>
            /// Raggruppamento delle cifre.
            /// </summary>
            public uint Grouping;
            /// <summary>
            /// Separatore delle decine.
            /// </summary>
            public LPWSTR DecimalSeparatorString;
            /// <summary>
            /// Separatore delle migliaia.
            /// </summary>
            public LPWSTR ThousandSeparatorString;
            /// <summary>
            /// Formato del numero monetario negativo.
            /// </summary>
            public NegativeCurrencyMode NegativeOrder;
            /// <summary>
            /// Posizione del simbolo in un numero monetario positivo.
            /// </summary>
            public SymbolPositionPositiveCurrency PositiveOrder;
            /// <summary>
            /// Simbolo della moneta.
            /// </summary>
            public LPWSTR CurrencySymbol;
        }

        /// <summary>
        /// Informazioni estese sulla firma di un font, inclusi i due campi di bit che definiscono i set di caratteri e le code page predefinite e supportate.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct LOCALESIGNATURE
        {
            /// <summary>
            /// USB (Unicode subset bitfield) a 128 bit, che identifica fino a 122 subranges Unicode.
            /// </summary>
            /// <remarks>Ogni bit, eccetto i 5 più significativi, rappresentano un singolo subrange.<br/>
            /// Il bit più significativo è sempre 1, il secondo è riservato e deve essere 0.</remarks>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public DWORD[] UnicodeSubsetBitfield;
            /// <summary>
            /// Campo di bit di code page che indica le code page predefinite OEM e ANSI per una località.
            /// </summary>
            /// <remarks>Le code page possono essere identificate da diversi bit o da un singolo bit rappresentante una code page comune OEM e ANSI.</remarks>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public DWORD[] CodePageBitfieldsDefault;
            /// <summary>
            /// Campo di bit di code page che indica quelle in cui la località è supportata.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public DWORD[] CodePageBitfieldsSupported;
        }

        /// <summary>
        /// Informazioni di formattazione per una stringa numerica.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct NUMBERFMT
        {
            /// <summary>
            /// Numero di cifre frazionarie.
            /// </summary>
            public uint FractionalDigitsCount;
            /// <summary>
            /// Indica se le decine devono essere precedute dallo 0.
            /// </summary>
            public uint LeadingZero;
            /// <summary>
            /// Raggruppamento delle cifre.
            /// </summary>
            public uint Grouping;
            /// <summary>
            /// Separatore decimale.
            /// </summary>
            public LPWSTR DecimalSeparator;
            /// <summary>
            /// Separatore delle migliaia.
            /// </summary>
            public LPWSTR ThousandSeparator;
            /// <summary>
            /// Formato del numero negativo.
            /// </summary>
            public NegativeNumberMode NegativeOrder;
        }

        /// <summary>
        /// Informazioni di versione di una funzionalità NLS.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NLSVersionInfo
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Versione NLS.
            /// </summary>
            public DWORD NLSVersion;
            /// <summary>
            /// Deprecato.
            /// </summary>
            public DWORD DefinedVersion;
            /// <summary>
            /// Deprecato.
            /// </summary>
            public DWORD EffectiveID;
            /// <summary>
            /// GUID univoco per il comportamento di una funzionalità personalizzata di ordinamento usata dalla località per la versione.
            /// </summary>
            public Guid CustomVersionGUID;
        }
    }   
}