using static WinApiWrapper.Managed.UserInterface.NationalLanguageSupport.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportCallbacks;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportStructures;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.Diagnostics.ErrorHandling.ErrorHandlingFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageConstants;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages;
using System.ComponentModel;
using System.Text;
using WinApiWrapper.UserInterface.NationalLanguageSupport;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Permette di utilizzare le funzionalità NLS.
    /// </summary>
    public static class NLSManaged
    {
        /// <summary>
        /// Informazioni enumerate.
        /// </summary>
        private static List<string>? EnumeratedInfo;

        /// <summary>
        /// ID della code page.
        /// </summary>
        private static List<int>? CodePages;

        /// <summary>
        /// Nomi località.
        /// </summary>
        private static List<LocaleInfo>? LocalesData;

        /// <summary>
        /// Informazioni enumerate da tutti i calendari.
        /// </summary>
        private static Dictionary<CalendarID, List<string>>? AllCalendarsEnumeratedInfo;

        /// <summary>
        /// Bit USB associato con il range e la descrizione dei caratteri Unicode che rappresentano.
        /// </summary>
        internal static Dictionary<byte, (string Subrange, string Description)[]> UnicodeSubsetBitfields = new()
        {
            {0, new (string, string)[1]{("0000-007F", "Basic Latin")} },
            {1, new (string, string)[1]{("0080-00FF", "Latin-1 Supplement")} },
            {2, new (string, string)[1]{("0100-017F", "Latin Extended-A")} },
            {3, new (string, string)[1]{("0180-024F", "Latin Extended-B")} },
            {4, new (string, string)[3]{("0250-02AF", "IPA Extensions"), ("1D00-1D7F", "Phonetic Extensions"), ("1D80-1DBF", "Phonetic Extensions Supplement")} },
            {5, new (string, string)[2]{("02B0", "Spacing Modifier Letters"), ("A700-A71F", "Modifier Tone Letters")} },
            {6, new (string, string)[2]{("0300-036F", "Combining Diacritical Marks"), ("1DC0-1DFF", "Combining Diacritical Marks Supplement")} },
            {7, new (string, string)[1]{("0370-03FF", "Greek and Coptic")} },
            {8, new (string, string)[1]{("2C80-2CFF", "Coptic")} },
            {9, new (string, string)[4]{("0400-04FF", "Cyrillic"), ("0500-052F", "Cyrillic Supplement"), ("2DE0-2DFF", "Cyrillic Extended-A"), ("A640-A69F", "Cyrillic Extended-B")} },
            {10, new (string, string)[1]{("0530-058F", "Armenian")} },
            {11, new (string, string)[1]{("0590-05FF", "Hebrew")} },
            {12, new (string, string)[1]{("A500-A63F", "Vai")} },
            {13, new (string, string)[2]{("0600-06FF", "Arabic"), ("0750-077F", "Arabic Supplement")} },
            {14, new (string, string)[1]{("07C0-07FF", "NKo")} },
            {15, new (string, string)[1]{("0900-097F", "Devangari")} },
            {16, new (string, string)[1]{("0980-09FF", "Bangla")} },
            {17, new (string, string)[1]{("0A00-0A7F", "Gurmukhi")} },
            {18, new (string, string)[1]{("0A80-0AFF", "Gujarati")} },
            {19, new (string, string)[1]{("0B00-0B7F", "Odia")} },
            {20, new (string, string)[1]{("0B80-0BFF", "Tamil")} },
            {21, new (string, string)[1]{("0C00-0C7F", "Telugu")} },
            {22, new (string, string)[1]{("0C80-0CFF", "Kannada")} },
            {23, new (string, string)[1]{("0D00-0D7F", "Malayalam")} },
            {24, new (string, string)[1]{("0E00-0E7F", "Thai")} },
            {25, new (string, string)[1]{("0E80-0EFF", "Lao")} },
            {26, new (string, string)[2]{("10A0-10FF", "Georgian"), ("2D00-2D2F", "Georgian Supplement")} },
            {27, new (string, string)[1]{("1B00-1B7F", "Balinese")} },
            {28, new (string, string)[1]{("1100-11FF", "Hangul Jamo")} },
            {29, new (string, string)[3]{("1E00-1EFF", "Latin Extended Additional"), ("2C60-2C7F", "Latin Extended-C"), ("A720-A7FF", "Latin Extended-D")} },
            {30, new (string, string)[1]{("1F00-1FFF", "Greek Extended")} },
            {31, new (string, string)[2]{("2000-206F", "General Punctuation"), ("2E00-2E7F", "Supplemental Punctuation")} },
            {32, new (string, string)[1]{("2070-209F", "Superscripts and Subscripts")} },
            {33, new (string, string)[1]{("20A0-20CF", "Currency Symbols")} },
            {34, new (string, string)[1]{("20D0-20FF", "Combining Diacritical Marks For Symbols")} },
            {35, new (string, string)[1]{("2100-214F", "Letterlike Symbols")} },
            {36, new (string, string)[1]{("2150-218F", "Number Forms")} },
            {37, new (string, string)[4]{("2190-21FF", "Arrows"), ("27F0-27FF", "Supplemental Arrows-A"), ("2900-297F", "Supplemental Arrows-B"), ("2B00-2BFF", "Miscellaneous Symbols and Arrows")} },
            {38, new (string, string)[4]{("2200-22FF", "Mathematical Operators"), ("27C0-27EF", "Miscellaneous Mathematical Symbols-A"), ("2980-29FF", "Miscellaneous Mathematical Symbols-B"), ("2A00-2AFF", "Supplemental Mathematical Operators")} },
            {39, new (string, string)[1]{("2300-23FF", "Miscellaneous Technical")} },
            {40, new (string, string)[1]{("2400-243F", "Control Pictures")} },
            {41, new (string, string)[1]{("2440-245F", "Optical Character Recognition")} },
            {42, new (string, string)[1]{("2460-24FF", "Enclosed Alphanumerics")} },
            {43, new (string, string)[1]{("2500-257F", "Box Drawing")} },
            {44, new (string, string)[1]{("2580-259F", "Block Elements")} },
            {45, new (string, string)[1]{("25A0-25FF", "Geometric Shapes")} },
            {46, new (string, string)[1]{("2600-26FF", "Miscellanous Symbols")} },
            {47, new (string, string)[1]{("2700-27BF", "Dingbats")} },
            {48, new (string, string)[1]{("3000-303F", "CJK Symbols And Punctuation")} },
            {49, new (string, string)[1]{("3040-309F", "Hiragana")} },
            {50, new (string, string)[2]{("30A0-30FF", "Katakana"), ("31F0-31FF", "Katakana Phonetic Extensions")} },
            {51, new (string, string)[2]{("3100-312F", "Bopomofo"), ("31A0-31BF", "Bopomofo Extended")} },
            {52, new (string, string)[1]{("3130-318F", "Hangul Compatibility Jamo")} },
            {53, new (string, string)[1]{("A840-A87F", "Phags-pa")} },
            {54, new (string, string)[1]{("3200-32FF", "Enclosed CJK LettersAndMonths")} },
            {55, new (string, string)[1]{("3300-33FF", "CJK Compatibility")} },
            {56, new (string, string)[1]{("AC00-D7AF", "Hangul Syllables")} },
            {57, new (string, string)[1]{("D800-DFFF", "Non-Plane 0")} },
            {58, new (string, string)[1]{("10900-1091F", "Phoenician")} },
            {59, new (string, string)[7]{("2E80-2EFF", "CJK Radicals Suppplement"), ("2F00-2FDF", "Kangxi Radicals"), ("2FF0-2FFF", "Ideographic Description Characters"), ("3190-319F", "Kanbun"), ("3400-4DBF", "CJK Unified Ideographs Extension A"), ("4E00-9FFF", "CJK Unified Ideographs"), ("20000-2A6DF", "CJK Unified Ideographs Extension B")} },
            {60, new (string, string)[1]{("E000-F8FF", "Private Use Area")} },
            {61, new (string, string)[3]{("31C0-31EF", "CJK Strokes"), ("F900-FAFF", "CJK Compatibility Ideographs"), ("2F800-2FA1F", "CJK Compatibility Ideographs Supplement")} },
            {62, new (string, string)[1]{("FB00-FB4F", "Alphabetic Presentation Forms")} },
            {63, new (string, string)[1]{("FB50-FDFF", "Arabic Presentation Forms")} },
            {64, new (string, string)[1]{("FE20-FE2F", "Combining Half Marks")} },
            {65, new (string, string)[2]{("FE10-FE1F", "Vertical Forms"), ("FE30-FE4F", "CJK Compatibility Forms")} },
            {66, new (string, string)[1]{("FE50-FE6F", "Small Form Variants")} },
            {67, new (string, string)[1]{("FE70-FEFF", "Arabic Presentation Forms-B")} },
            {68, new (string, string)[1]{("FF00-FFEF", "Halfwidth And Fullwidth Forms")} },
            {69, new (string, string)[1]{("FFF0-FFFF", "Specials")} },
            {70, new (string, string)[1]{("0F00-0FFF", "Tibetan")} },
            {71, new (string, string)[1]{("0700-074F", "Syriac")} },
            {72, new (string, string)[1]{("0780-07BF", "Thaana")} },
            {73, new (string, string)[1]{("0D80-0DFF", "Sinhala")} },
            {74, new (string, string)[1]{("1000-109F", "Myanmar")} },
            {75, new (string, string)[3]{("1200-137F", "Ethiopic"), ("1380-139F", "Ethiopic Supplement"), ("2D80-2DDF", "Ethiopic Extended")} },
            {76, new (string, string)[1]{("13A0-13FF", "Cherokee")} },
            {77, new (string, string)[1]{("1400-167F", "Unified Canadian Aboriginal Syllabics")} },
            {78, new (string, string)[1]{("1680-169F", "Ogham")} },
            {79, new (string, string)[1]{("16A0-16FF", "Runic")} },
            {80, new (string, string)[2]{("1780-17FF", "Khmer"), ("19E0-19FF", "Khmer Symbols")} },
            {81, new (string, string)[1]{("1800-18AF", "Mongolian")} },
            {82, new (string, string)[1]{("2800-28FF", "Braille Patterns")} },
            {83, new (string, string)[2]{("A000-A48F", "Yi Syllables"), ("A490-A4CF", "Yi Radicals")} },
            {84, new (string, string)[4]{("1700-171F", "Tagalog"), ("1720-173F", "Hanunoo"), ("1740-175F", "Buhid"), ("1760-177F", "Tagbanwa")} },
            {85, new (string, string)[1]{("10300-1032F", "Old Italic")} },
            {86, new (string, string)[1]{("10330-1034F", "Gothic")} },
            {87, new (string, string)[1]{("10400-1044F", "Deseret")} },
            {88, new (string, string)[3]{("1D000-1D0FF", "Byzantine Musical Symbols"), ("1D100-1D1FF", "Musical Symbols"), ("1D200-1D24F", "Ancient Greek Musical Notation")} },
            {89, new (string, string)[1]{("1D400-1D7FF", "Mathematical Alphanumeric Symbols")} },
            {90, new (string, string)[2]{("FF000-FFFFD", "Private Use (plane 15)"), ("100000-10FFFD", "Private Use (plane 16)")} },
            {91, new (string, string)[2]{("FE00-FE0F", "Variation Selectors"), ("E0100-E01EF", "Variation Selectors Supplement")} },
            {92, new (string, string)[1]{("E0000-E007F", "Tags")} },
            {93, new (string, string)[1]{("1900-194F", "Limbu")} },
            {94, new (string, string)[1]{("1950-197F", "Tai Le")} },
            {95, new (string, string)[1]{("1980-19DF", "New Tai Lue")} },
            {96, new (string, string)[1]{("1A00-1A1F", "Buginese")} },
            {97, new (string, string)[1]{("2C000-2C5F", "Glagolitic")} },
            {98, new (string, string)[1]{("2D30-2D7F", "Tifinagh")} },
            {99, new (string, string)[1]{("4DC0-4DFF", "Yijing Hexagram Symbols")} },
            {100, new (string, string)[1]{("A800-A82F", "Syloti Nagri")} },
            {101, new (string, string)[3]{("10000-1007F", "Linear B Syllabary"), ("10080-100FF", "Linear B Ideograms"), ("10100-1013F", "Aegean Numbers")} },
            {102, new (string, string)[1]{("10140-1018F", "Ancient Greek Numbers")} },
            {103, new (string, string)[1]{("10380-1039F", "Ugaritic")} },
            {104, new (string, string)[1]{("103A0-103DF", "Old Persian")} },
            {105, new (string, string)[1]{("10450-1047F", "Shavian")} },
            {106, new (string, string)[1]{("10480-104AF", "Osmanya")} },
            {107, new (string, string)[1]{("10800-1083F", "Cypriot Syllabary")} },
            {108, new (string, string)[1]{("10A00-10A5F", "Kharoshthi")} },
            {109, new (string, string)[1]{("1D300-1D35F", "Tai Xuan Jing Symbols")} },
            {110, new (string, string)[2]{("12000-123FF", "Cuneiform"), ("12400-1247F", "Cuneiform Numbers and Punctuation")} },
            {111, new (string, string)[1]{("1D360-1D37F", "Counting Rod Numerals")} },
            {112, new (string, string)[1]{("1B80-1BBF", "Sundanese")} },
            {113, new (string, string)[1]{("1C00-1C4F", "Lepcha")} },
            {114, new (string, string)[1]{("1C50-1C7F", "Ol Chiki")} },
            {115, new (string, string)[1]{("A880-A8DF", "Saurashtra")} },
            {116, new (string, string)[1]{("A900-A92F", "Kayah Li")} },
            {117, new (string, string)[1]{("A930-A95F", "Rejang")} },
            {118, new (string, string)[1]{("AA00-AA5F", "Cham")} },
            {119, new (string, string)[1]{("10190-101CF", "Ancient Symbols")} },
            {120, new (string, string)[1]{("101D0-101FF", "Phaistos Disc")} },
            {121, new (string, string)[3]{("10280-1029F", "Lycian"), ("102A0-102DF", "Carian"), ("10920-1093F", "Lydian")} },
            {122, new (string, string)[2]{("1F000-1F02F", "Mahjong Tiles"), ("1F030-1F09F", "Domino Tiles")} },
            {123, new (string, string)[1]{(string.Empty, "Layout progress: horizontal from right to left")} },
            {124, new (string, string)[1]{(string.Empty, "Layout progress: vertical before horizontal")} },
            {125, new (string, string)[1]{(string.Empty, "Layout progress: vertical bottom to top")} }
        };

        /// <summary>
        /// Bit associati con una code page e relativa descrizione.
        /// </summary>
        internal static Dictionary<byte, (string CodePageID, string Description)> CodePageBitFields = new()
        {
            {0, ("1252", "Latin 1") },
            {1, ("1250", "Latin 2: Central Europe") },
            {2, ("1251", "Cyrillic") },
            {3, ("1253", "Greek") },
            {4, ("1254", "Turkish") },
            {5, ("1255", "Hebrew") },
            {6, ("1256", "Arabic") },
            {7, ("1257", "Baltic") },
            {8, ("1258", "Vietnamese") },
            {16, ("874", "Thai") },
            {17, ("932", "Japanese, Shift-JIS") },
            {18, ("936", "Simplified Chinese (PRC, Singapore)") },
            {19, ("949", "Korean Unified Hangul Code (Hangul TongHabHyung Code)") },
            {20, ("1252", "Traditional Chinese (Taiwan, Hong Kong SAR, PRC") },
            {21, ("1361", "Korean (Johab)") },
            {47, ("1258", "Vietnamese") },
            {48, ("869", "Modern Greek") },
            {49, ("866", "Russian") },
            {50, ("865", "Nordic") },
            {51, ("864", "Arabic") },
            {52, ("863", "Canadian French") },
            {53, ("862", string.Empty) },
            {54, ("861", "Icelandic") },
            {55, ("860", "Portuguese") },
            {56, ("857", "Turkish") },
            {57, ("855", "Cyrillic, primarily Russian") },
            {58, ("852", "Latin 2") },
            {59, ("775", "Baltic") },
            {60, ("737", "Greek, formerly 437G") },
            {61, ("708;720", "ASMO 708;Arabic") },
            {62, ("850", "Multilingual Latin 1") },
            {63, ("437", "US") }
        };

        /// <summary>
        /// Enumera l'informazione richiesta su un calendario.
        /// </summary>
        /// <param name="Calendar">Calendario.</param>
        /// <param name="Info">Informazione da enumerare.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita del sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica se ignorare le impostazioni utente e usare quelle predefinite di sistema.</param>
        /// <param name="ReturnGenitiveNames">Indica se restituire i nomi genitivi dei mesi.</param>
        /// <returns>Array di stringhe con i componenti dell'informazione richiesta.</returns>
        /// <remarks>Alcuni valore di <see cref="CalendarInformation"/> restituiscono liste di stringhe, il valore <see cref="Calendar.All"/> di <paramref name="Calendar"/> non è valido per questo metodo.<br/><br/>
        /// Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.</remarks>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string[] EnumerateCalendarInfo(Calendar Calendar, CalendarInformation Info, string? LocaleName, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false, bool ReturnGenitiveNames = false)
        {
            if (EnumeratedInfo is null)
            {
                EnumeratedInfo = new();
            }
            else
            {
                EnumeratedInfo.Clear();
            }
            EnumCalendarInfoProc Callback = new(CalendarEnumerationInfoCallback);
            if (Calendar is Calendar.All)
            {
                throw new InvalidOperationException("Invalid value for this method, use EnumerateAllCalendarInfo");
            }
            CalendarID ID = (CalendarID)Calendar;
            if (Info is CalendarInformation.JapaneseEraEnglishNames or CalendarInformation.JapaneseEraAbbreviatedEnglishNames or CalendarInformation.JapaneseFirstYear)
            {
                if (Calendar is not Calendar.Japan)
                {
                    throw new ArgumentException("The requested info is valid only for the japanese calendar.", nameof(Info));
                }
            }
            uint TypeFlags = (uint)Info;
            if (UseSystemDefaults)
            {
                TypeFlags |= CAL_NOUSEROVERRIDE;
            }
            if (ReturnGenitiveNames)
            {
                TypeFlags |= CAL_RETURN_GENITIVE_NAMES;
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale name must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (!EnumCalendarInfo(Callback, LocaleName, ID, null, TypeFlags, HMODULE.Zero))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return EnumeratedInfo.ToArray();
        }

        /// <summary>
        /// Callback per l'enumerazione delle informazioni su un calendario.
        /// </summary>
        /// <param name="CalendarInfo">Informazione richiesta.</param>
        /// <param name="Calendar">Calendario.</param>
        /// <param name="Reserved">Riservato.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false altrimenti.</returns>
        private static bool CalendarEnumerationInfoCallback(LPWSTR CalendarInfo, CalendarID Calendar, string Reserved, HMODULE lParam)
        {
            EnumeratedInfo!.Add(CalendarInfo);
            return true;
        }

        /// <summary>
        /// Recupera l'informazione richiesta per tutti i calendari.
        /// </summary>
        /// <param name="Info">Informazione da enumerare.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita del sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica se ignorare le impostazioni utente e usare quelle predefinite di sistema.</param>
        /// <param name="ReturnGenitiveNames">Indica se restituire i nomi genitivi dei mesi.</param>
        /// <returns>Array di stringhe con i componenti dell'informazione richiesta.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static Dictionary<Calendar, string[]> EnumerateAllCalendarInfo(CalendarInformation Info, string? LocaleName, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false, bool ReturnGenitiveNames = false)
        {
            if (AllCalendarsEnumeratedInfo is null)
            {
                AllCalendarsEnumeratedInfo = new();
            }
            else
            {
                AllCalendarsEnumeratedInfo.Clear();
            }
            EnumCalendarInfoProc Callback = new(AllCalendarEnumerationInfoCallback);
            CalendarID ID = CalendarID.ENUM_ALL_CALENDARS;
            uint TypeFlags = (uint)Info;
            if (UseSystemDefaults)
            {
                TypeFlags |= CAL_NOUSEROVERRIDE;
            }
            if (ReturnGenitiveNames)
            {
                TypeFlags |= CAL_RETURN_GENITIVE_NAMES;
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale name must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (!EnumCalendarInfo(Callback, LocaleName, ID, null, TypeFlags, HMODULE.Zero))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            Dictionary<Calendar, string[]> Results = new();
            foreach (KeyValuePair<CalendarID, List<string>> pair in AllCalendarsEnumeratedInfo)
            {
                Results.Add((Calendar)pair.Key, pair.Value.ToArray());
            }
            return Results;
        }

        /// <summary>
        /// Callback per l'enumerazione delle informazioni su tutti i calendari.
        /// </summary>
        /// <param name="CalendarInfo">Informazione richiesta.</param>
        /// <param name="Calendar">Calendario.</param>
        /// <param name="Reserved">Riservato.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false altrimenti.</returns>
        private static bool AllCalendarEnumerationInfoCallback(LPWSTR CalendarInfo, CalendarID Calendar, string Reserved, HMODULE lParam)
        {
            if (AllCalendarsEnumeratedInfo!.ContainsKey(Calendar))
            {
                AllCalendarsEnumeratedInfo[Calendar].Add(CalendarInfo);
            }
            else
            {
                AllCalendarsEnumeratedInfo.Add(Calendar, new());
                AllCalendarsEnumeratedInfo[Calendar].Add(CalendarInfo);
            }
            return true;
        }

        /// <summary>
        /// Enumera le code page.
        /// </summary>
        /// <param name="OnlyInstalledCodePages">Indica se enumerare solo le code page installate.</param>
        /// <returns>Un array di ID delle code page.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static int[] EnumerateSystemCodePages(bool OnlyInstalledCodePages)
        {
            if (CodePages is null)
            {
                CodePages = new();
            }
            else
            {
                CodePages.Clear();
            }
            EnumCodePagesProc Callback = new(CodePagesEnumerationCallback);
            CodePageType Type;
            if (!OnlyInstalledCodePages)
            {
                Type = CodePageType.CP_SUPPORTED;
            }
            else
            {
                Type = CodePageType.CP_INSTALLED;
            }
            if (!EnumSystemCodePages(Callback, Type))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return CodePages.ToArray();
        }

        /// <summary>
        /// Callback per l'enumerazione delle code page.
        /// </summary>
        /// <param name="CodePageString">ID della code page come stringa.</param>
        /// <returns>true per continuare l'enumerazione, false altrimenti.</returns>
        private static bool CodePagesEnumerationCallback(string CodePageString)
        {
            CodePages!.Add(Convert.ToInt32(CodePageString));
            return true;
        }

        /// <summary>
        /// Enumera i formati di data disponibili per la località.
        /// </summary>
        /// <param name="Format">Formato della data.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <returns>Array di stringhe che contiene i formati di data supportati.</returns>
        /// <remarks>Gli unici valori dell'enumerazione <see cref="Enumerations.DateFormat"/> per questo metodo sono:<br/><br/>
        /// <see cref="Enumerations.DateFormat.Long"/><br/>
        /// <see cref="Enumerations.DateFormat.Short"/><br/>
        /// <see cref="Enumerations.DateFormat.MonthDay"/><br/>
        /// <see cref="Enumerations.DateFormat.YearMonth"/><br/><br/>
        /// Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string[] EnumerateDateFormats(Enumerations.DateFormat Format, string? LocaleName, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (EnumeratedInfo is null)
            {
                EnumeratedInfo = new();
            }
            else
            {
                EnumeratedInfo.Clear();
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale name must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (Format is not Enumerations.DateFormat.Short and not Enumerations.DateFormat.Long and not Enumerations.DateFormat.YearMonth and not Enumerations.DateFormat.MonthDay)
            {
                throw new ArgumentException("Invalid format.", nameof(Format));
            }
            EnumDateFormatsProc Callback = new(DateFormatsEnumerationCallback);
            if (!EnumDateFormats(Callback, LocaleName, (NationalLanguageSupportEnumerations.DateFormat)Format, HMODULE.Zero))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return EnumeratedInfo!.ToArray();
        }

        /// <summary>
        /// Callback per l'enumerazione dei formati della date.
        /// </summary>
        /// <param name="DateFormatString">Formato della data.</param>
        /// <param name="CalendarID">ID calendario.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per fermarla.</returns>
        private static bool DateFormatsEnumerationCallback(LPWSTR DateFormatString, CalendarID CalendarID, LPARAM lParam)
        {
            EnumeratedInfo!.Add(DateFormatString);
            return true;
        }

        /// <summary>
        /// Enumera le località installate nel sistema.
        /// </summary>
        /// <param name="LocaleType">Tipo di località.</param>
        /// <returns>Array di istanze di <see cref="LocaleInfo"/> con le informazioni sulle località.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static LocaleInfo[] EnumerateSystemLocales(Enumerations.LocaleType LocaleType)
        {
            if (LocalesData is null)
            {
                LocalesData = new();
            }
            else
            {
                LocalesData.Clear();
            }
            if (LocaleType is Enumerations.LocaleType.Replacement)
            {
                throw new ArgumentException("Invalid locale type.", nameof(LocaleType));
            }
            EnumLocalesProc Callback = new(SystemLocalesEnumerationCallback);
            if (!EnumSystemLocales(Callback, (NationalLanguageSupportEnumerations.LocaleType)LocaleType, HMODULE.Zero, HMODULE.Zero))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return LocalesData.ToArray();
        }

        /// <summary>
        /// Callback per l'enumerazione dei nomi località.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Type">Tipo di località.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        private static bool SystemLocalesEnumerationCallback(string LocaleName, NationalLanguageSupportEnumerations.LocaleType Type, HMODULE lParam)
        {
            LocalesData!.Add(new(LocaleName, (Enumerations.LocaleType)Type));
            return true;
        }

        /// <summary>
        /// Enumera i nomi geografici.
        /// </summary>
        /// <returns>Un array di stringhe con i nomi geografici.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string[] EnumerateSystemGeoNames()
        {
            if (EnumeratedInfo is null)
            {
                EnumeratedInfo = new();
            }
            else
            {
                EnumeratedInfo.Clear();
            }
            EnumGeoNamesProc Callback = new(GeoNamesEnumerationCallback);
            if (!EnumSystemGeoNames(SYSGEOTYPE.GEOCLASS_NATION, Callback, HMODULE.Zero))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return EnumeratedInfo.ToArray();
        }

        /// <summary>
        /// Callback per l'enumerazione dei nomi geografici.
        /// </summary>
        /// <param name="GeoName">Nome geografico.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        private static bool GeoNamesEnumerationCallback(LPWSTR GeoName, LPARAM lParam)
        {
            EnumeratedInfo!.Add(GeoName);
            return true;
        }

        /// <summary>
        /// Enumera i formati orari.
        /// </summary>
        /// <param name="EnumerateShortTimeFormats">Indica se enumerare i formati dell'ora corta.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutrale.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita del sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località prefefinita dell'utente.</param>
        /// <returns>Un array con le stringhe di formato orario supportate dalla località.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string[] EnumerateTimeFormats(bool EnumerateShortTimeFormats, string LocaleName, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (EnumeratedInfo is null)
            {
                EnumeratedInfo = new();
            }
            else
            {
                EnumeratedInfo.Clear();
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale name must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            NationalLanguageSupportEnumerations.TimeFormat Format;
            if (!EnumerateShortTimeFormats)
            {
                Format = NationalLanguageSupportEnumerations.TimeFormat.CurrentLongTime;
            }
            else
            {
                Format = NationalLanguageSupportEnumerations.TimeFormat.TIME_NOSECONDS;
            }
            EnumTimeFormatsProc Callback = new(TimeFormatEnumerationCallback);
            if (!EnumTimeFormats(Callback, LocaleName, Format, HMODULE.Zero))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return EnumeratedInfo.ToArray();
        }

        /// <summary>
        /// Callback per l'enumerazione delle stringhe di formato orarie.
        /// </summary>
        /// <param name="TimeFormatString">Stringa di formato.</param>
        /// <param name="lParam">Parametro fornito dall'applicazione.</param>
        /// <returns>true per continuare l'enumerazione, false per terminarla.</returns>
        private static bool TimeFormatEnumerationCallback(LPWSTR TimeFormatString, LPARAM lParam)
        {
            EnumeratedInfo!.Add(TimeFormatString);
            return true;
        }

        /// <summary>
        /// Recupera l'ID della code page ANSI corrente del sistema.
        /// </summary>
        /// <returns></returns>
        public static uint GetSystemCurrentCodePageID()
        {
            return GetCurrentAnsiCodePage();
        }

        /// <summary>
        /// Recupera un'informazione da un calendario.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Calendar">Calendario da cui recuperare l'informazione.</param>
        /// <param name="Info">Informazione da recuperare.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutrale.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località di sistema predefinita.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="ReturnNumber">Indica se il risultato deve essere restituito come un numero.</param>
        /// <param name="ReturnMonthGenitiveNames">Indica se devono essere restituisti i nomi genitivi dei mesi.</param>
        /// <param name="UseSystemDefaults">Indica se ignorare le impostazioni utente.</param>
        /// <returns>L'informazione richiesta.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// <paramref name="ReturnNumber"/> può essere true solo se <paramref name="Info"/> include uno dei seguenti valori:<br/><br/>
        /// <see cref="CalendarInformation.AlternateCalendarType"/><br/>
        /// <see cref="CalendarInformation.EraOffsetRanges"/><br/>
        /// <see cref="CalendarInformation.TwoDigitYearMaxValue"/><br/><br/>
        /// <paramref name="UseSystemDefaults"/> ha effetto solo se <paramref name="Info"/> include <see cref="CalendarInformation.TwoDigitYearMaxValue"/>.<br/><br/>
        /// Il valore <see cref="Calendar.All"/> non è valido per <paramref name="Calendar"/>.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static object GetCalendarInfo(string? LocaleName, Calendar Calendar, CalendarInformation Info, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool ReturnNumber = false, bool ReturnMonthGenitiveNames = false, bool UseSystemDefaults = false)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "Locale name must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            CALTYPE Flags = (CALTYPE)Info;
            if (ReturnNumber)
            {
                if (Info is not CalendarInformation.AlternateCalendarType and not CalendarInformation.EraOffsetRanges and not CalendarInformation.TwoDigitYearMaxValue)
                {
                    throw new ArgumentException("The requested information cannot be returned as a number.", nameof(Info));
                }
                else
                {
                    Flags |= CAL_RETURN_NUMBER;
                }
            }
            if (Calendar is Calendar.All)
            {
                throw new ArgumentException("Invalid calendar.", nameof(Calendar));
            }
            if (ReturnMonthGenitiveNames)
            {
                Flags |= CAL_RETURN_GENITIVE_NAMES;
            }
            if (UseSystemDefaults)
            {
                Flags |= CAL_NOUSEROVERRIDE;
            }
            if (!ReturnNumber)
            {
                int BufferSize = NationalLanguageSupportFunctions.GetCalendarInfo(LocaleName, (CalendarID)Calendar, null, Flags, null, 0, HMODULE.Zero);
                if (BufferSize is not 0)
                {
                    StringBuilder InfoBuffer = new(BufferSize);
                    if (NationalLanguageSupportFunctions.GetCalendarInfo(LocaleName, (CalendarID)Calendar, null, Flags, InfoBuffer, BufferSize, HMODULE.Zero) is > 0)
                    {
                        return InfoBuffer.ToString();
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                HMODULE NumberValuePointer = Marshal.AllocHGlobal(4);
                if (NationalLanguageSupportFunctions.GetCalendarInfo(LocaleName, (CalendarID)Calendar, null, Flags, null, 0, NumberValuePointer) is 2)
                {
                    int Value = Marshal.ReadInt32(NumberValuePointer);
                    Marshal.FreeHGlobal(NumberValuePointer);
                    return Value;
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
        }

        /// <summary>
        /// Recupera informazioni su una code page.
        /// </summary>
        /// <param name="CodePage">Code page della quale recuperare le informazioni.</param>
        /// <param name="UseWindowsANSIDefaultCodePage">Indica se usare la code page Windows ANSI predefinita.</param>
        /// <param name="UseMacintoshDefaultCodePage">Indica se usare la code page Macintosh predefinita.</param>
        /// <param name="UseOEMDefaultCodePage">Indica se usare la code page OEM predefinita.</param>
        /// <param name="UseCurrentThreadANSICodePage">Indica se usare la code page ANSI corrente del thread.</param>
        /// <returns>Istanza di <see cref="CodePageInfo"/> con le informazioni.</returns>
        /// <remarks>Se <paramref name="CodePage"/> è nullo, uno tra <paramref name="UseWindowsANSIDefaultCodePage"/>, <paramref name="UseMacintoshDefaultCodePage"/>, <paramref name="UseOEMDefaultCodePage"/> e <paramref name="UseCurrentThreadANSICodePage"/> deve essere true.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static CodePageInfo GetCodePageInfo(int? CodePage, bool UseWindowsANSIDefaultCodePage = false, bool UseMacintoshDefaultCodePage = false, bool UseOEMDefaultCodePage = false, bool UseCurrentThreadANSICodePage = false)
        {
            if (CodePage is null)
            {
                if (!UseWindowsANSIDefaultCodePage && !UseMacintoshDefaultCodePage && !UseOEMDefaultCodePage && !UseCurrentThreadANSICodePage)
                {
                    throw new ArgumentNullException(nameof(CodePage), "A code page ID must be provided.");
                }
                else
                {
                    if (UseWindowsANSIDefaultCodePage)
                    {
                        CodePage = (int)CodePageDefault.CP_ACP;
                    }
                    else if (UseMacintoshDefaultCodePage)
                    {
                        CodePage = (int)CodePageDefault.CP_MACCP;
                    }
                    else if (UseOEMDefaultCodePage)
                    {
                        CodePage = (int)CodePageDefault.CP_OEMCP;
                    }
                    else if (UseCurrentThreadANSICodePage)
                    {
                        CodePage = (int)CodePageDefault.CP_THREAD_ACP;
                    }
                }
            }
            else
            {
                if (!IsValidCodePage((uint)CodePage.Value))
                {
                    throw new ArgumentException("Invalid code page.", nameof(CodePage));
                }
            }
            if (NationalLanguageSupportFunctions.GetCodePageInfo((uint)CodePage!, 0, out CPINFOEX Info))
            {
                return new CodePageInfo(Info);
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Formatta una stringa come valuta.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="OriginalString">Stringa da formattare.</param>
        /// <param name="FormatInfo">Informazioni di formattazione.</param>
        /// <param name="UseSystemDefaults">Indica se usare le impostazioni predefinite del sistema al posto di quelle dell'utente.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutrale.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <returns>La string formattata.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// Perché <paramref name="OriginalString"/> sia valida, deve rispettare le seguenti condizioni:<br/><br/>
        /// 1) può contenere solo i caratteri da "0" a "9"<br/>
        /// 2) ci può essere un solo punto ("."), se il numero è con la virgola<br/>
        /// 3) ci può essere un solo segno negativo e deve essere il primo carattere, se il numero è negativo</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string FormatStringAsCurrency(string? LocaleName, string OriginalString, CurrencyFormatInfo? FormatInfo, bool UseSystemDefaults = false, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (string.IsNullOrWhiteSpace(OriginalString))
            {
                throw new ArgumentNullException(nameof(OriginalString), "No string to convert provided.");
            }
            else
            {
                char[] OriginalStringCharacters = OriginalString.ToCharArray();
                if (OriginalStringCharacters.Any((character) => char.IsLetter(character)))
                {
                    throw new FormatException("The original string can't contain letters.");
                }
                int DotCount = OriginalStringCharacters.Count((character) => character is '.');
                if (DotCount > 1)
                {
                    throw new FormatException("The original string can't contain more than one dot.");
                }
                int MinusSignCount = OriginalStringCharacters.Count((character) => character is '-');
                if (MinusSignCount > 1)
                {
                    throw new FormatException("The original string can't have more than one minus sign.");
                }
                else if (MinusSignCount is 1)
                {
                    if (OriginalString.IndexOf('-') is not 0)
                    {
                        throw new FormatException("The minus sign in the original string must be the first character.");
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            uint Flags = 0;
            HMODULE FormatStructurePointer;
            if (FormatInfo is null)
            {
                FormatStructurePointer = HMODULE.Zero;
                if (UseSystemDefaults)
                {
                    Flags |= LOCALE_NOUSEROVERRIDE;
                }
            }
            else
            {
                FormatStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CURRENCYFMT)));
                CURRENCYFMT FormatStructure = FormatInfo.ToStruct();
                Marshal.StructureToPtr(FormatStructure, FormatStructurePointer, false);
            }
            int BufferSize = GetCurrencyFormat(LocaleName, Flags, OriginalString, FormatStructurePointer, null, 0);
            if (BufferSize is 0)
            {
                if (FormatInfo is not null)
                {
                    Marshal.FreeHGlobal(FormatStructurePointer);
                }
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                StringBuilder FormattedString = new(BufferSize);
                if (GetCurrencyFormat(LocaleName, Flags, OriginalString, FormatStructurePointer, FormattedString, BufferSize) is 0)
                {
                    if (FormatInfo is not null)
                    {
                        Marshal.FreeHGlobal(FormatStructurePointer);
                    }
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
                else
                {
                    if (FormatInfo is not null)
                    {
                        Marshal.FreeHGlobal(FormatStructurePointer);
                    }
                    return FormattedString.ToString();
                }
            }
        }

        /// <summary>
        /// Formatta una stringa come data.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Format">Formato della data.</param>
        /// <param name="Date">Struttura <see cref="DateTime"/> che contiene i dati da usare per la creazione della stringa formattata.</param>
        /// <param name="FormatString">Stringa di formato che indica la struttura della stringa formattata.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutrale.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica di usare le impostazioni predefinite del sistema al posto di quelle dell'utente.</param>
        /// <param name="ApplyRTLMarks">Indica se applicare gli indicatori per la lettura da destra a sinistra alla stringa formattata.</param>
        /// <param name="ApplyLTRMarks">Indica se applicare gli indicatori per la lettura da sinistra a destra alla stringa formattata.</param>
        /// <param name="UseAlternateCalendar">Indica se usare il calendario alternativo per la località, se esiste.</param>
        /// <returns>La stringa formattata.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> o <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// Se <paramref name="Format"/> è nullo, <see cref="Enumerations.DateFormat.Short"/> è l'impostazione predefinita.<br/><br/>
        /// Se <paramref name="FormatString"/> è nullo, verranno usate le impostazioni della località per la struttura della stringa formattata.<br/><br/>
        /// Se <paramref name="Date"/> è nullo, verra usata la data corrente.<br/><br/>
        /// Se sia <paramref name="ApplyLTRMarks"/> che <paramref name="ApplyRTLMarks"/> sono false, la necessità di marcatori per la lettura verrà determinata automaticamente, solo uno dei parametri può essere true, l'altro verrà ignorato.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string FormatStringAsDate(string? LocaleName, Enumerations.DateFormat? Format, DateTime? Date, string? FormatString, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false, bool ApplyRTLMarks = false, bool ApplyLTRMarks = false, bool UseAlternateCalendar = false)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            HMODULE DateStructurePointer;
            uint Flags = 0;
            if (string.IsNullOrWhiteSpace(FormatString) && UseSystemDefaults)
            {
                Flags |= LOCALE_NOUSEROVERRIDE;
            }
            if (!Date.HasValue)
            {
                DateStructurePointer = HMODULE.Zero;
                if (string.IsNullOrWhiteSpace(FormatString))
                {
                    if (Format.HasValue)
                    {
                        Flags = (uint)Format;
                    }
                    else
                    {
                        Flags = (uint)NationalLanguageSupportEnumerations.DateFormat.DATE_SHORTDATE;
                    }
                    if (!ApplyLTRMarks && !ApplyRTLMarks)
                    {
                        Flags |= (uint)NationalLanguageSupportEnumerations.DateFormat.DATE_AUTOLAYOUT;
                    }
                    else
                    {
                        if (ApplyLTRMarks)
                        {
                            Flags |= (uint)NationalLanguageSupportEnumerations.DateFormat.DATE_LTRREADING;
                        }
                        else if (ApplyRTLMarks)
                        {
                            Flags |= (uint)NationalLanguageSupportEnumerations.DateFormat.DATE_RTLREADING;
                        }
                    }
                    if (UseAlternateCalendar)
                    {
                        Flags |= (uint)NationalLanguageSupportEnumerations.DateFormat.DATE_USE_ALT_CALENDAR;
                    }
                }
            }
            else
            {
                DateStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SYSTEMTIME)));
                SYSTEMTIME DateStructure = new()
                {
                    Year = (ushort)Date!.Value.Year,
                    Month = (ushort)Date.Value.Month,
                    Day = (ushort)Date.Value.Day,
                    DayOfWeek = (ushort)Date.Value.DayOfWeek,
                    Hour = 0,
                    Minute = 0,
                    Second = 0,
                    Millisecond = 0
                };
                Marshal.StructureToPtr(DateStructure, DateStructurePointer, false);
            }
            int BufferSize = GetDateFormat(LocaleName, Flags, DateStructurePointer, FormatString, null, 0, null);
            if (BufferSize is 0)
            {
                if (Date.HasValue)
                {
                    Marshal.FreeHGlobal(DateStructurePointer);
                }
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                StringBuilder FormattedString = new(BufferSize);
                if (GetDateFormat(LocaleName, Flags, DateStructurePointer, FormatString, FormattedString, BufferSize, null) is not 0)
                {
                    if (Date.HasValue)
                    {
                        Marshal.FreeHGlobal(DateStructurePointer);
                    }
                    return FormattedString.ToString();
                }
                else
                {
                    if (Date.HasValue)
                    {
                        Marshal.FreeHGlobal(DateStructurePointer);
                    }
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
        }

        /// <summary>
        /// Formatta una stringa come durata.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Duration">Struttura <see cref="TimeSpan"/> che esprime la durata.</param>
        /// <param name="Seconds">Durata da convertire, in secondi.</param>
        /// <param name="FormatString">Stringa di formato che indica la struttura della stringa formattata.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutrale.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica di usare le impostazioni predefinite del sistema al posto di quelle dell'utente.</param>
        /// <returns>La stringa formattata.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> o <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// <paramref name="UseSystemDefaults"/> e <paramref name="Seconds"/> vengono ignorati se <paramref name="FormatString"/> non è nullo</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string FormatStringAsDuration(string? LocaleName, TimeSpan? Duration, int? Seconds, string? FormatString, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            HMODULE DurationStructurePointer;
            uint Flags = 0;
            ulong Ticks = 0;
            if (string.IsNullOrWhiteSpace(FormatString) && UseSystemDefaults)
            {
                Flags |= LOCALE_NOUSEROVERRIDE;
            }
            if (!Duration.HasValue)
            {
                DurationStructurePointer = HMODULE.Zero;
                if (!Seconds.HasValue)
                {
                    throw new ArgumentNullException(nameof(Seconds), "Seconds can't be null if Duration is null.");
                }
                else
                {
                    Ticks = TimeSpan.TicksPerSecond * (ulong)Seconds;
                }
            }
            else
            {
                DurationStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SYSTEMTIME)));
                SYSTEMTIME DateStructure = new()
                {
                    Year = 0,
                    Month = 0,
                    Day = (ushort)Duration!.Value.Days,
                    DayOfWeek = 0,
                    Hour = (ushort)Duration!.Value.Hours,
                    Minute = (ushort)Duration.Value.Minutes,
                    Second = (ushort)Duration.Value.Seconds,
                    Millisecond = (ushort)Duration.Value.Milliseconds
                };
                Marshal.StructureToPtr(DateStructure, DurationStructurePointer, false);
            }
            int BufferSize = GetDurationFormat(LocaleName, Flags, DurationStructurePointer, Ticks, FormatString, null, 0);
            if (BufferSize is 0)
            {
                if (Duration.HasValue)
                {
                    Marshal.FreeHGlobal(DurationStructurePointer);
                }
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                StringBuilder FormattedString = new(BufferSize);
                if (GetDurationFormat(LocaleName, Flags, DurationStructurePointer, Ticks, FormatString, FormattedString, BufferSize) is 0)
                {
                    if (Duration.HasValue)
                    {
                        Marshal.FreeHGlobal(DurationStructurePointer);
                    }
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
                else
                {
                    if (Duration.HasValue)
                    {
                        Marshal.FreeHGlobal(DurationStructurePointer);
                    }
                    return FormattedString.ToString();
                }
            }
        }

        /// <summary>
        /// Recupera un'informazione geografica su una località.
        /// </summary>
        /// <param name="LocationID">ID località.</param>
        /// <param name="Info">Informazione da recuperare.</param>
        /// <returns>L'informazione richiesta.</returns>
        /// <remarks>Per recuperare i valori validi per <paramref name="LocationID"/>, utilizzare <see cref="EnumerateSystemGeoNames"/>.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static object GetGeographicalInfo(string LocationID, GeoInfo Info)
        {
            if (string.IsNullOrWhiteSpace(LocationID))
            {
                throw new ArgumentNullException(nameof(LocationID), "The location ID can't be null.");
            }
            HMODULE DataValuePointer = HMODULE.Zero;
            int BufferSize = 0;
            bool ValueIsFloatingPoint = false;
            if (Info is GeoInfo.Latitude or GeoInfo.Longitude)
            {
                DataValuePointer = Marshal.AllocHGlobal(4);
                ValueIsFloatingPoint = true;
            }
            else
            {
                BufferSize = GetGeoInfo(LocationID, (SYSGEOTYPE)Info, HMODULE.Zero, 0);
                if (BufferSize is 0)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            if (!ValueIsFloatingPoint)
            {
                DataValuePointer = Marshal.AllocHGlobal(BufferSize);
            }
            if (GetGeoInfo(LocationID, (SYSGEOTYPE)Info, DataValuePointer, BufferSize) is 0)
            {
                Marshal.FreeHGlobal(DataValuePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                if (ValueIsFloatingPoint)
                {
                    float Value = Marshal.ReadInt32(DataValuePointer);
                    Marshal.FreeHGlobal(DataValuePointer);
                    return Value;
                }
                else
                {
                    string Value = Marshal.PtrToStringUni(DataValuePointer, BufferSize - 1)!;
                    Marshal.FreeHGlobal(DataValuePointer);
                    return Value;
                }
            }
        }

        /// <summary>
        /// Recupera un'informazione su una località.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="Info">Informazione da recuperare.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica se ignorare le impostazioni dell'utente.</param>
        /// <returns>L'informazione richiesta, il tipo di dati dipende da <paramref name="Info"/>.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> o <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// I seguenti valori di <paramref name="Info"/> restituiscono un intero a 32 bit:<br/><br/>
        /// <see cref="Enumerations.LocaleInfo.DialingCode"/><br/>
        /// <see cref="Enumerations.LocaleInfo.CurrencyFractionalDigitsCount"/><br/>
        /// <see cref="Enumerations.LocaleInfo.FractionalDigitsCount"/><br/><br/>
        /// I seguenti valori di <paramref name="Info"/> restituiscono una enumerazione:<br/><br/>
        /// <see cref="Enumerations.LocaleInfo.CurrencyNegativeSignPosition"/> => <see cref="CurrencyNegativeSignPosition"/><br/>
        /// <see cref="Enumerations.LocaleInfo.OptionalCalendarType"/> => <see cref="Calendar"/><br/>
        /// <see cref="Enumerations.LocaleInfo.PositivePercentageFormat"/> => <see cref="PositivePercentageMode"/><br/>
        /// <see cref="Enumerations.LocaleInfo.CurrencyPositiveSignPosition"/> => <see cref="CurrencyNegativeSignPosition"/> (escluso <see cref="CurrencyNegativeSignPosition.AmountAndSymbolSurroundedByParenthesis"/>)<br/>
        /// <see cref="Enumerations.LocaleInfo.DigitSubstitutionType"/> => <see cref="DigitSubstitutionMode"/><br/>
        /// <see cref="Enumerations.LocaleInfo.FirstWeekOfYear"/> => <see cref="Enumerations.FirstWeekOfYear"/><br/>
        /// <see cref="Enumerations.LocaleInfo.PaperSize"/> => <see cref="PaperSize"/><br/>
        /// <see cref="Enumerations.LocaleInfo.ReadingLayout"/> => <see cref="ReadingLayout"/><br/>
        /// <see cref="Enumerations.LocaleInfo.NegativeCurrencyFormat"/> => <see cref="NegativeCurrencyFormat"/><br/>
        /// <see cref="Enumerations.LocaleInfo.NegativeNumberFormat"/> => <see cref="NegativeNumberFormat"/><br/><br/>
        /// I seguenti valori restituiscono un booleano:<br/><br/>
        /// <see cref="Enumerations.LocaleInfo.LeadingZerosAreUsed"/><br/>
        /// <see cref="Enumerations.LocaleInfo.PositiveCurrencySymbolSeparatedBySpace"/><br/>
        /// <see cref="Enumerations.LocaleInfo.NegativeCurrencySymbolSeparatedBySpace"/><br/>
        /// <see cref="Enumerations.LocaleInfo.MeasuringSystem"/> (false: sistema metrico, true: sistema statunitense)<br/>
        /// <see cref="Enumerations.LocaleInfo.CurrencySymbolPosition"/> (false: il simbolo segue il valore, true: il simbolo precede il valore)<br/><br/>
        /// Se <paramref name="Info"/> ha valore <see cref="Enumerations.LocaleInfo.FontSignature"/> il valore restituito è un'istanza di <see cref="FontSignature"/>.<br/><br/>
        /// Qualunque altro valore di <paramref name="Info"/> restituisce una stringa.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static object GetLocaleInfo(string? LocaleName, Enumerations.LocaleInfo Info, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            bool IsNumber = false;
            bool IsBoolean = false;
            switch (Info)
            {
                case Enumerations.LocaleInfo.DialingCode:
                case Enumerations.LocaleInfo.CurrencyFractionalDigitsCount:
                case Enumerations.LocaleInfo.FractionalDigitsCount:
                case Enumerations.LocaleInfo.NegativePercentageFormat:
                case Enumerations.LocaleInfo.CurrencyNegativeSignPosition:
                case Enumerations.LocaleInfo.OptionalCalendarType:
                case Enumerations.LocaleInfo.PositivePercentageFormat:
                case Enumerations.LocaleInfo.CurrencyPositiveSignPosition:
                case Enumerations.LocaleInfo.CalendarType:
                case Enumerations.LocaleInfo.PositiveCurrencySymbolPosition:
                case Enumerations.LocaleInfo.DigitSubstitutionType:
                case Enumerations.LocaleInfo.FirstWeekOfYear:
                case Enumerations.LocaleInfo.PaperSize:
                case Enumerations.LocaleInfo.ReadingLayout:
                case Enumerations.LocaleInfo.NegativeCurrencyFormat:
                case Enumerations.LocaleInfo.NegativeNumberFormat:
                case Enumerations.LocaleInfo.FirstDayOfTheWeek:
                    IsNumber = true;
                    break;
                case Enumerations.LocaleInfo.LeadingZerosAreUsed:
                case Enumerations.LocaleInfo.PositiveCurrencySymbolSeparatedBySpace:
                case Enumerations.LocaleInfo.NegativeCurrencySymbolSeparatedBySpace:
                case Enumerations.LocaleInfo.MeasuringSystem:
                case Enumerations.LocaleInfo.CurrencySymbolPosition:
                    IsBoolean = true;
                    break;
                default:
                    break;
            }
            int ValueAsNumber;
            string ValueAsString;
            HMODULE Buffer;
            uint Flags = (uint)Info;
            if (UseSystemDefaults)
            {
                Flags |= LOCALE_NOUSEROVERRIDE;
            }
            if (Info is not Enumerations.LocaleInfo.FontSignature)
            {
                if (!IsNumber && !IsBoolean)
                {
                    int BufferSize = NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, Flags, HMODULE.Zero, 0);
                    if (BufferSize is not 0)
                    {
                        Buffer = Marshal.AllocHGlobal(BufferSize * 2);
                        if (NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, Flags, Buffer, BufferSize) is not 0)
                        {
                            ValueAsString = Marshal.PtrToStringUni(Buffer, BufferSize);
                            Marshal.FreeHGlobal(Buffer);
                            return ValueAsString;
                        }
                        else
                        {
                            Marshal.FreeHGlobal(Buffer);
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else if (IsNumber)
                {
                    Buffer = Marshal.AllocHGlobal(4);
                    if (NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, Flags | LOCALE_RETURN_NUMBER, Buffer, 2) is not 0)
                    {
                        if (Info is Enumerations.LocaleInfo.NegativePercentageFormat)
                        {
                            int Number = Marshal.ReadInt32(Buffer);
                            Marshal.FreeHGlobal(Buffer);
                            ValueAsString = Number switch
                            {
                                0 => "Negative sign, number, space, percent",
                                1 => "Negative sign, number, percent",
                                2 => "Negative sign, percent, number",
                                3 => "Percent, negative sign, number",
                                4 => "Percent, number, negative sign",
                                5 => "Number, negative sign, percent",
                                6 => "Number, percent, negative sign",
                                7 => "Negative sign, percent, space, number",
                                8 => "Number, space, percent, negative sign",
                                9 => "Percent, space, number, negative sign",
                                10 => "Percent, space, negative sign, number",
                                11 => "Number, negative sign, space, percent",
                                _ => string.Empty,
                            };
                            return ValueAsString;
                        }
                        else if (Info is Enumerations.LocaleInfo.FirstDayOfTheWeek)
                        {
                            int FirstDay = Marshal.ReadInt32(Buffer);
                            var BufferSize = FirstDay switch
                            {
                                0 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME1, HMODULE.Zero, 0),
                                1 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME2, HMODULE.Zero, 0),
                                2 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME3, HMODULE.Zero, 0),
                                3 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME4, HMODULE.Zero, 0),
                                4 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME5, HMODULE.Zero, 0),
                                5 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME6, HMODULE.Zero, 0),
                                6 => NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)GeoInfoType.LOCALE_SDAYNAME7, HMODULE.Zero, 0),
                                _ => 0,
                            };
                            if (BufferSize is not 0)
                            {
                                Buffer = Marshal.ReAllocHGlobal(Buffer, (HMODULE)(BufferSize * 2));
                                if (NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, Flags, Buffer, BufferSize) is not 0)
                                {
                                    ValueAsString = Marshal.PtrToStringUni(Buffer, BufferSize);
                                    Marshal.FreeHGlobal(Buffer);
                                    return ValueAsString;
                                }
                                else
                                {
                                    Marshal.FreeHGlobal(Buffer);
                                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                                }
                            }
                            else
                            {
                                Marshal.FreeHGlobal(Buffer);
                                throw new Win32Exception(Marshal.GetLastPInvokeError());
                            }
                        }
                        else
                        {
                            ValueAsNumber = Marshal.ReadInt32(Buffer);
                            Marshal.FreeHGlobal(Buffer);
                            return ValueAsNumber;
                        }
                    }
                    else
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    Buffer = Marshal.AllocHGlobal(4);
                    if (NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, Flags | LOCALE_RETURN_NUMBER, Buffer, 2) is not 0)
                    {
                        ValueAsNumber = Marshal.ReadInt32(Buffer);
                        Marshal.FreeHGlobal(Buffer);
                        return Convert.ToBoolean(ValueAsNumber);
                    }
                    else
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
            }
            else
            {
                int BufferSize = Marshal.SizeOf(typeof(LOCALESIGNATURE));
                Buffer = Marshal.AllocHGlobal(BufferSize);
                if (NationalLanguageSupportFunctions.GetLocaleInfo(LocaleName, (uint)Info, Buffer, BufferSize / 2) is not 0)
                {
                    LOCALESIGNATURE Structure = (LOCALESIGNATURE)Marshal.PtrToStructure(Buffer, typeof(LOCALESIGNATURE))!;
                    Marshal.FreeHGlobal(Buffer);
                    return new FontSignature(Structure);
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
        }

        /// <summary>
        /// Formatta una stringa come numero.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="OriginalString">Stringa da formattare.</param>
        /// <param name="FormatInfo">Istanza di <see cref="NumberFormatInfo"/> che contiene informazioni di formattazione.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica se usare le impostazioni di default del sistema.</param>
        /// <returns>La stringa formattata.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// Perché <paramref name="OriginalString"/> sia valida, deve rispettare le seguenti condizioni:<br/><br/>
        /// 1) può contenere solo i caratteri da "0" a "9"<br/>
        /// 2) ci può essere un solo punto ("."), se il numero è con la virgola<br/>
        /// 3) ci può essere un solo segno negativo e deve essere il primo carattere, se il numero è negativo</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string FormatStringAsNumber(string? LocaleName, string OriginalString, NumberFormatInfo? FormatInfo, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false)
        {
            if (string.IsNullOrWhiteSpace(OriginalString))
            {
                throw new ArgumentNullException(nameof(OriginalString), "No string to convert provided.");
            }
            else
            {
                char[] OriginalStringCharacters = OriginalString.ToCharArray();
                if (OriginalStringCharacters.Any((character) => char.IsLetter(character)))
                {
                    throw new FormatException("The original string can't contain letters.");
                }
                int DotCount = OriginalStringCharacters.Count((character) => character is '.');
                if (DotCount > 1)
                {
                    throw new FormatException("The original string can't contain more than one dot.");
                }
                int MinusSignCount = OriginalStringCharacters.Count((character) => character is '-');
                if (MinusSignCount > 1)
                {
                    throw new FormatException("The original string can't have more than one minus sign.");
                }
                else if (MinusSignCount is 1)
                {
                    if (OriginalString.IndexOf('-') is not 0)
                    {
                        throw new FormatException("The minus sign in the original string must be the first character.");
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            uint Flags = FormatInfo is not null && UseSystemDefaults ? LOCALE_NOUSEROVERRIDE : 0;
            if (FormatInfo is not null)
            {
                NUMBERFMT NumberFormatInfo = FormatInfo.ToStruct();
                HMODULE StructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(NumberFormatInfo));
                Marshal.StructureToPtr(NumberFormatInfo, StructurePointer, false);
                int BufferSize = GetNumberFormat(LocaleName, Flags, OriginalString, StructurePointer, null, 0);
                if (BufferSize > 0)
                {
                    StringBuilder FormattedString = new(BufferSize);
                    if (GetNumberFormat(LocaleName, Flags, OriginalString, StructurePointer, FormattedString, BufferSize) is not 0)
                    {
                        Marshal.FreeHGlobal(StructurePointer);
                        return FormattedString.ToString();
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                int BufferSize = GetNumberFormat(LocaleName, Flags, OriginalString, HMODULE.Zero, null, 0);
                if (BufferSize > 0)
                {
                    StringBuilder FormattedString = new(BufferSize);
                    if (GetNumberFormat(LocaleName, Flags, OriginalString, HMODULE.Zero, FormattedString, BufferSize) is not 0)
                    {
                        return FormattedString.ToString();
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
        }

        /// <summary>
        /// Recupera l'ID della code page OEM attuale.
        /// </summary>
        /// <returns>ID della code page.</returns>
        public static int GetOEMCodePage()
        {
            return (int)NationalLanguageSupportFunctions.GetOEMCodePage();
        }

        /// <summary>
        /// Recupera la lista di script presenti in una stringa.
        /// </summary>
        /// <param name="String">Stringa da analizzare.</param>
        /// <param name="IncludeInheritedAndCommonScripts">Indica se includere gli script comuni ed ereditati.</param>
        /// <returns>Un array di stringhe che contiene gli script presenti nella stringa, nella notazione a 4 caratteri usata in ISO 15924.<br/>
        /// Se non sono stati trovati script viene restituito un array vuoto.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string[] GetStringScripts(string String, bool IncludeInheritedAndCommonScripts = false)
        {
            if (string.IsNullOrWhiteSpace(String))
            {
                throw new ArgumentNullException(nameof(String), "No string provided.");
            }
            uint Flags = IncludeInheritedAndCommonScripts ? GSS_ALLOW_INHERITED_COMMON : 0;
            int BufferSize = NationalLanguageSupportFunctions.GetStringScripts(Flags, String, String.Length, null, 0);
            if (BufferSize is not 0 and not 1)
            {
                StringBuilder Scripts = new(BufferSize);
                if (NationalLanguageSupportFunctions.GetStringScripts(Flags, String, String.Length, Scripts, BufferSize) is not 0)
                {
                    _ = Scripts.Remove(Scripts.Length - 1, 1);
                    return Scripts.ToString().Split(';');
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else if (BufferSize is 1)
            {
                return Array.Empty<string>();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera informazioni sui caratteri di una stringa.
        /// </summary>
        /// <param name="String">Stringa da analizzare.</param>
        /// <param name="Info">Informazione da recuperare.</param>
        /// <returns>Un'array di istanze di classi derivate da <see cref="CharacterInfo"/>.</returns>
        /// <remarks>Il tipo di istanza restituita dipende da <paramref name="Info"/>:<br/><br/>
        /// Se <paramref name="Info"/> ha valore <see cref="StringCharacterInfo.TypeInfo"/>, l'array contiene istanze di <see cref="CharacterTypeInfo"/>.<br/>
        /// Se <paramref name="Info"/> ha valore <see cref="StringCharacterInfo.BidirectionalLayoutInfo"/>, l'array contiene istanze di <see cref="CharacterBidirectionaLayoutInfo"/>.<br/>
        /// Se <paramref name="Info"/> ha valore <see cref="StringCharacterInfo.TextProcessingInfo"/>, l'array contiene istanze di <see cref="TextProcessingInfo"/>.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static CharacterInfo[] GetStringCharactersInfo(string String, StringCharacterInfo Info)
        {
            if (string.IsNullOrWhiteSpace(String))
            {
                throw new ArgumentNullException(nameof(String), "No string provided.");
            }
            if (Info is not StringCharacterInfo.TypeInfo and not StringCharacterInfo.BidirectionalLayoutInfo and not StringCharacterInfo.TextProcessingInfo)
            {
                throw new InvalidEnumArgumentException(nameof(Info), (int)Info, typeof(StringCharacterInfo));
            }
            if (!IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, HMODULE.Zero, String, String.Length))
            {
                throw new ArgumentException("The string is not a valid NLS string.", nameof(String));
            }
            ushort[] InfoValues = new ushort[String.Length];
            List<CharacterInfo> CharactersData = new();
            if (!GetStringType(LOCALE_USER_DEFAULT, (StringCharacterTypeInfo)Info, String, String.Length, InfoValues))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                switch (Info)
                {
                    case StringCharacterInfo.TypeInfo:
                        for (int i = 0; i < InfoValues.Length; i++)
                        {
                            CharactersData.Add(new CharacterTypeInfo(String[i], (CharacterTypeValues)InfoValues[i]));
                        }
                        break;
                    case StringCharacterInfo.BidirectionalLayoutInfo:
                        for (int i = 0; i < InfoValues.Length; i++)
                        {
                            CharactersData.Add(new CharacterBidirectionaLayoutInfo(String[i], (StringLayoutValues)InfoValues[i]));
                        }
                        break;
                    case StringCharacterInfo.TextProcessingInfo:
                        for (int i = 0; i < InfoValues.Length; i++)
                        {
                            CharactersData.Add(new TextProcessingInfo(String[i], (StringTextProcessingValues)InfoValues[i]));
                        }
                        break;
                }
                return CharactersData.ToArray();
            }
        }

        /// <summary>
        /// Recupera la località predefinita del sistema.
        /// </summary>
        /// <returns>Il nome della località.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string GetSystemDefaultLocaleName()
        {
            StringBuilder LocaleName = new(LOCALE_NAME_MAX_LENGTH);
            if (NationalLanguageSupportFunctions.GetSystemDefaultLocaleName(LocaleName, LOCALE_NAME_MAX_LENGTH) is not 0)
            {
                return LocaleName.ToString();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera la località predefinita dell'utente.
        /// </summary>
        /// <returns>Il nome della località.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string GetUserDefaultLocaleName()
        {
            StringBuilder LocaleName = new(LOCALE_NAME_MAX_LENGTH);
            if (NationalLanguageSupportFunctions.GetUserDefaultLocaleName(LocaleName, LOCALE_NAME_MAX_LENGTH) is not 0)
            {
                return LocaleName.ToString();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera la località del thread corrente.
        /// </summary>
        /// <returns>Il nome della località.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string GetCurrentThreadLocaleName()
        {
            LCID Locale = GetThreadLocale();
            StringBuilder LocaleName = new(LOCALE_NAME_MAX_LENGTH);
            if (LCIDToLocaleName(Locale, LocaleName, LocaleName.Capacity, 0) is not 0)
            {
                return LocaleName.ToString();
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera il codice ISO 3166-1 o il codice UN M.49 che rappresenta la località geografica corrente dell'utente.
        /// </summary>
        /// <returns>Il codice che rappresenta la località.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string GetUserDefaultGeographicalLocation()
        {
            int BufferSize = GetUserDefaultGeoName(null, 0);
            if (BufferSize is not 0)
            {
                StringBuilder GeoName = new(BufferSize);
                if (GetUserDefaultGeoName(GeoName, BufferSize) is not 0)
                {
                    return GeoName.ToString();
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Trasforma un orario in una stringa in base alle informazioni di formattazione fornite.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="FormatOptions">Opzioni di formattazione.</param>
        /// <param name="Time">Struttura <see cref="TimeOnly"/> con le informazioni da formattare.</param>
        /// <param name="FormatString">Stringa di formato che indica come formattare il contenuto di <paramref name="Time"/>.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <param name="UseSystemDefaults">Indica se usare le impostazioni di sistema al posto di quelle dell'utente.</param>
        /// <returns>L'orario in formato di stringa.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// Se <paramref name="Time"/> è nullo, verrà usato l'orario locale di sistema.<br/><br/>
        /// Se <paramref name="FormatString"/> è nullo, verranno usato le informazioni di formattazione fornite dalla località.<br/><br/>
        /// Il valore <see cref="Enumerations.TimeFormat.CurrentUseLongTime"/> non può essere incluso in <paramref name="FormatOptions"/>.<br/><br/>
        /// I marcatori temporali (se esistono) sono inclusi nella stringa anche se <paramref name="FormatOptions"/> specifica <see cref="Enumerations.TimeFormat.Force24HourFormat"/> (a meno che non sia incluso anche <see cref="Enumerations.TimeFormat.NoTimeMarkers"/>).<br/><br/>
        /// La stringa non include i millisecondi.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string FormatStringAsTime(string? LocaleName, Enumerations.TimeFormat FormatOptions, TimeOnly? Time, string? FormatString, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false, bool UseSystemDefaults = false)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (FormatOptions is Enumerations.TimeFormat.CurrentUseLongTime)
            {
                throw new InvalidEnumArgumentException(nameof(FormatOptions), (int)FormatOptions, typeof(Enumerations.TimeFormat));
            }
            uint Flags = (uint)FormatOptions;
            if (UseSystemDefaults)
            {
                Flags |= LOCALE_NOUSEROVERRIDE;
            }
            HMODULE TimeStructurePointer = HMODULE.Zero;
            if (Time.HasValue)
            {
                SYSTEMTIME TimeStructure = new()
                {
                    Hour = (ushort)Time.Value.Hour,
                    Minute = (ushort)Time.Value.Minute,
                    Second = (ushort)Time.Value.Second,
                    Millisecond = (ushort)Time.Value.Millisecond
                };
                TimeStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(TimeStructure));
                Marshal.StructureToPtr(TimeStructure, TimeStructurePointer, false);
            }
            int BufferSize = GetTimeFormat(LocaleName, Flags, TimeStructurePointer, FormatString, null, 0);
            if (BufferSize is not 0)
            {
                StringBuilder FormattedString = new(BufferSize);
                if (GetTimeFormat(LocaleName, Flags, TimeStructurePointer, FormatString, FormattedString, BufferSize) is not 0)
                {
                    if (TimeStructurePointer != HMODULE.Zero)
                    {
                        Marshal.FreeHGlobal(TimeStructurePointer);
                    }
                    return FormattedString.ToString();
                }
                else
                {
                    if (TimeStructurePointer != HMODULE.Zero)
                    {
                        Marshal.FreeHGlobal(TimeStructurePointer);
                    }
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                if (TimeStructurePointer != HMODULE.Zero)
                {
                    Marshal.FreeHGlobal(TimeStructurePointer);
                }
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Converte una stringa IDN.
        /// </summary>
        /// <param name="IDN">Nome di dominio internazionalizzato (IDN).</param>
        /// <param name="Options">Opzioni di conversione.</param>
        /// <param name="ResultString">Risultato della conversione.</param>
        /// <returns>La stringa convertita.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static string ConvertIDNString(string IDN, IDNConversionOptions Options, IDNConversionResult ResultString)
        {
            if (string.IsNullOrWhiteSpace(IDN))
            {
                throw new ArgumentNullException(nameof(IDN), "IDN string not provided.");
            }
            int BufferSize;
            StringBuilder? ConvertedString = null;
            switch (ResultString)
            {
                case IDNConversionResult.AsciiString:
                    BufferSize = IdnToAscii((IdnConversionOptions)Options, IDN, -1, ConvertedString, 0);
                    if (BufferSize is not 0)
                    {
                        ConvertedString = new(BufferSize);
                        if (IdnToAscii((IdnConversionOptions)Options, IDN, -1, ConvertedString, BufferSize) is 0)
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    break;
                case IDNConversionResult.NameprepString:
                    BufferSize = IdnToNameprepUnicode((IdnConversionOptions)Options, IDN, -1, ConvertedString, 0);
                    if (BufferSize is not 0)
                    {
                        ConvertedString = new(BufferSize);
                        if (IdnToNameprepUnicode((IdnConversionOptions)Options, IDN, -1, ConvertedString, BufferSize) is 0)
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    break;
                case IDNConversionResult.UnicodeString:
                    BufferSize = IdnToUnicode((IdnConversionOptions)Options, IDN, -1, ConvertedString, 0);
                    if (BufferSize is not 0)
                    {
                        ConvertedString = new(BufferSize);
                        if (IdnToUnicode((IdnConversionOptions)Options, IDN, -1, ConvertedString, BufferSize) is 0)
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(ResultString), (int)ResultString, typeof(IDNConversionResult));
            }
            return ConvertedString.ToString();
        }

        /// <summary>
        /// Trasforma una stringa in base alle impostazioni fornite dall'utente.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="SourceString">Stringa originale.</param>
        /// <param name="Transformation">Trasformazione da effettuare.</param>
        /// <param name="SortKeyOptions">Opzioni per la generazione di una chiave di ordinamento.</param>
        /// <param name="IgnoreNonSpacingChars">Indica se ignorare i caratteri non spacing.</param>
        /// <param name="IgnoreSymbols">Indica se ignorare i simboli e la punteggiatura.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <returns>Il metodo restituisce i seguenti risultati nei seguenti casi:<br/><br/>
        /// Un array di byte, se <paramref name="Transformation"/> include <see cref="StringTransformationType.SortKey"/><br/>
        /// Un intero a 32 bit, se <paramref name="Transformation"/> include <see cref="StringTransformationType.Hash"/><br/>
        /// Una stringa, in tutti gli altri casi</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// I seguenti valori di <paramref name="Transformation"/> non possono essere specificati insieme:<br/><br/>
        /// <see cref="StringTransformationType.Hash"/> e <see cref="StringTransformationType.SortKey"/><br/>
        /// <see cref="StringTransformationType.HiraganaToKatakana"/> e <see cref="StringTransformationType.KatakanaToHiragana"/><br/>
        /// <see cref="StringTransformationType.UseNarrowChars"/> e <see cref="StringTransformationType.UseWideChars"/><br/>
        /// <see cref="StringTransformationType.ToLowercase"/>, <see cref="StringTransformationType.ToUpperCase"/> e <see cref="StringTransformationType.ToTitleCase"/><br/>
        /// <see cref="StringTransformationType.SimplifiedChineseToTraditionalChinese"/> e <see cref="StringTransformationType.TraditionalChineseToSimplifiedChinese"/><br/><br/>
        /// Il valore <see cref="StringTransformationType.UseLinguisticRulesForCasing"/> per <paramref name="Transformation"/> può essere usato solo con <see cref="StringTransformationType.ToLowercase"/> oppure con <see cref="StringTransformationType.ToUpperCase"/>.<br/><br/>
        /// Se <paramref name="IgnoreNonSpacingChars"/> oppure <paramref name="IgnoreSymbols"/> è true, <paramref name="Transformation"/> deve avere uno dei seguenti valori:<br/><br/>
        /// <see cref="StringTransformationType.None"/><br/>
        /// <see cref="StringTransformationType.SortKey"/><br/>
        /// <see cref="StringTransformationType.ByteReversal"/><br/>
        /// la combinazione di <see cref="StringTransformationType.SortKey"/> e <see cref="StringTransformationType.ByteReversal"/><br/><br/>
        /// Il parametro <paramref name="SortKeyOptions"/> è preso in considerazione solo se <paramref name="Transformation"/> ha valore <see cref="StringTransformationType.SortKey"/>.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static object ConvertString(string? LocaleName, string SourceString, StringTransformationType Transformation, SortKeyOptions? SortKeyOptions = null, bool IgnoreNonSpacingChars = false, bool IgnoreSymbols = false, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (string.IsNullOrWhiteSpace(SourceString))
            {
                throw new ArgumentNullException(nameof(SourceString), "No source string provided.");
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (Transformation.HasFlag(StringTransformationType.UseWideChars) && Transformation.HasFlag(StringTransformationType.UseNarrowChars))
            {
                throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
            }
            if (Transformation.HasFlag(StringTransformationType.KatakanaToHiragana) && Transformation.HasFlag(StringTransformationType.HiraganaToKatakana))
            {
                throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
            }
            if (Transformation.HasFlag(StringTransformationType.UseLinguisticRulesForCasing))
            {
                if (!Transformation.HasFlag(StringTransformationType.ToLowercase) && !Transformation.HasFlag(StringTransformationType.ToUpperCase))
                {
                    throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
                }
            }
            if (Transformation.HasFlag(StringTransformationType.ToLowercase) && Transformation.HasFlag(StringTransformationType.ToUpperCase))
            {
                throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
            }
            if ((Transformation.HasFlag(StringTransformationType.ToLowercase) || Transformation.HasFlag(StringTransformationType.ToUpperCase)) && Transformation.HasFlag(StringTransformationType.ToTitleCase))
            {
                throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
            }
            if (Transformation.HasFlag(StringTransformationType.Hash) && Transformation.HasFlag(StringTransformationType.SortKey))
            {
                throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
            }
            if (Transformation.HasFlag(StringTransformationType.TraditionalChineseToSimplifiedChinese) && Transformation.HasFlag(StringTransformationType.SimplifiedChineseToTraditionalChinese))
            {
                throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
            }
            if (IgnoreNonSpacingChars || IgnoreSymbols)
            {
                if (Transformation is not StringTransformationType.None)
                {
                    if (Transformation is not StringTransformationType.SortKey and not StringTransformationType.ByteReversal && Transformation != (StringTransformationType.ByteReversal | StringTransformationType.SortKey))
                    {
                        throw new InvalidEnumArgumentException(nameof(Transformation), (int)Transformation, typeof(StringTransformationType));
                    }
                }
            }
            uint Flags = (uint)Transformation;
            if (Transformation.HasFlag(StringTransformationType.SortKey) && SortKeyOptions is not null)
            {
                Flags |= (uint)SortKeyOptions;
            }
            if (IgnoreNonSpacingChars)
            {
                Flags |= (uint)StringComparisonOptions.NORM_IGNORENONSPACE;
            }
            if (IgnoreSymbols)
            {
                Flags |= (uint)StringComparisonOptions.NORM_IGNORESYMBOLS;
            }
            NLSVersionInfo VersionInfo = new()
            {
                Size = (uint)Marshal.SizeOf(typeof(NLSVersionInfo))
            };
            if (GetNLSVersion(SYSNLS_FUNCTION.COMPARE_STRING, LocaleName, ref VersionInfo))
            {
                HMODULE Buffer;
                string ConvertedString;
                int Hash;
                byte[] SortKey;
                if (Transformation.HasFlag(StringTransformationType.Hash))
                {
                    Buffer = Marshal.AllocHGlobal(4);
                    if (NationalLanguageSupportFunctions.ConvertString(LocaleName, Flags, SourceString, SourceString.Length, Buffer, 4, VersionInfo, HMODULE.Zero, HMODULE.Zero) is not 0)
                    {
                        Hash = Marshal.ReadInt32(Buffer);
                        Marshal.FreeHGlobal(Buffer);
                        return Hash;
                    }
                    else
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    int BufferSize = NationalLanguageSupportFunctions.ConvertString(LocaleName, Flags, SourceString, SourceString.Length, HMODULE.Zero, 0, VersionInfo, HMODULE.Zero, HMODULE.Zero);
                    if (BufferSize is not 0)
                    {
                        if (Transformation.HasFlag(StringTransformationType.SortKey))
                        {
                            Buffer = Marshal.AllocHGlobal(BufferSize);
                            if (NationalLanguageSupportFunctions.ConvertString(LocaleName, Flags, SourceString, SourceString.Length, Buffer, BufferSize, VersionInfo, HMODULE.Zero, HMODULE.Zero) is not 0)
                            {
                                SortKey = new byte[BufferSize];
                                Marshal.Copy(Buffer, SortKey, 0, BufferSize);
                                Marshal.FreeHGlobal(Buffer);
                                return SortKey;
                            }
                            else
                            {
                                Marshal.FreeHGlobal(Buffer);
                                throw new Win32Exception(Marshal.GetLastPInvokeError());
                            }
                        }
                        else
                        {
                            Buffer = Marshal.AllocHGlobal(BufferSize * 2);
                            if (NationalLanguageSupportFunctions.ConvertString(LocaleName, Flags, SourceString, SourceString.Length, Buffer, BufferSize, VersionInfo, HMODULE.Zero, HMODULE.Zero) is not 0)
                            {
                                ConvertedString = Marshal.PtrToStringUni(Buffer, BufferSize);
                                Marshal.FreeHGlobal(Buffer);
                                return ConvertedString;
                            }
                            else
                            {
                                Marshal.FreeHGlobal(Buffer);
                                throw new Win32Exception(Marshal.GetLastPInvokeError());
                            }
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Normalizza una stringa in base alle regole Unicode 4.0 TR#15.
        /// </summary>
        /// <param name="SourceString">Stringa originale.</param>
        /// <param name="NormalizationForm">Tipo di normalizzazione.</param>
        /// <returns>Stringa normalizzata.</returns>
        /// <remarks>Se la stringa è già normalizzata, viene restituita senza modifiche.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string NormalizeString(string SourceString, NormalizationMode NormalizationForm)
        {
            if (string.IsNullOrWhiteSpace(SourceString))
            {
                throw new ArgumentNullException(nameof(SourceString), "No string provided.");
            }
            SetLastError(ERROR_SUCCESS);
            if (!IsNormalizedString((NORM_FORM)NormalizationForm, SourceString, SourceString.Length))
            {
                int ErrorCode = Marshal.GetLastPInvokeError();
                if (ErrorCode is not ERROR_SUCCESS)
                {
                    throw new Win32Exception(ErrorCode);
                }
                else
                {
                    int BufferSize = NationalLanguageSupportFunctions.NormalizeString((NORM_FORM)NormalizationForm, SourceString, -1, null, 0);
                    if (BufferSize is <= 0)
                    {
                        StringBuilder NormalizedString = new(BufferSize);
                        if (NationalLanguageSupportFunctions.NormalizeString((NORM_FORM)NormalizationForm, SourceString, -1, NormalizedString, BufferSize) is not <= 0)
                        {
                            return NormalizedString.ToString();
                        }
                        else
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
            }
            else
            {
                return SourceString;
            }
        }

        /// <summary>
        /// Mappa una stringa a un'altra, eseguendo la trasformazione specificata.
        /// </summary>
        /// <param name="OriginalString">Stringa originale.</param>
        /// <param name="Transformation">Trasformazione da effettuare.</param>
        /// <returns>La stringa risultato della mappatura.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="FormatException"></exception>
        public static string MapString(string OriginalString, StringTransformationType2 Transformation)
        {
            if (string.IsNullOrWhiteSpace(OriginalString))
            {
                throw new ArgumentNullException(nameof(OriginalString), "No string provided.");
            }
            if (IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, HMODULE.Zero, OriginalString, OriginalString.Length))
            {
                int BufferSize = ConvertString2((StringMappingTransformation2)Transformation, OriginalString, -1, null, 0);
                if (BufferSize is not 0)
                {
                    StringBuilder ConvertedString = new(BufferSize);
                    if (ConvertString2((StringMappingTransformation2)Transformation, OriginalString, -1, ConvertedString, BufferSize) is not 0)
                    {
                        return ConvertedString.ToString();
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                throw new FormatException("The string is not defined under NLS.");
            }
        }

        /// <summary>
        /// Trova una stringa all'interno di un'altra.
        /// </summary>
        /// <param name="FoundStringSize">Dimensione, in caratteri, della stringa trovata.</param>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="SourceString">Stringa originale.</param>
        /// <param name="ValueToFind">Stringa da trovare.</param>
        /// <param name="SearchStartingPoint">Punto di partenza della ricerca.</param>
        /// <param name="SearchFilter">Opzioni di ricerca.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.</remarks>
        /// <returns>L'indice, basato su 0, all'interno di <paramref name="SourceString"/> dove si trova l'inizio di <paramref name="ValueToFind"/>, -1 se <paramref name="ValueToFind"/> non è stata trovata.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static int FindString(out int FoundStringSize, string? LocaleName, string SourceString, string ValueToFind, SearchOptions SearchStartingPoint, StringSearchFilter? SearchFilter = null, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (string.IsNullOrWhiteSpace(SourceString))
            {
                throw new ArgumentNullException(nameof(SourceString), "No source string provided.");
            }
            if (string.IsNullOrWhiteSpace(ValueToFind))
            {
                throw new ArgumentNullException(nameof(SourceString), "No value provided.");
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            uint Flags = (uint)SearchStartingPoint;
            if (SearchFilter is not null)
            {
                Flags |= (uint)SearchFilter;
            }
            int ValueStartingIndex = NationalLanguageSupportFunctions.FindString(LocaleName, Flags, SourceString, SourceString.Length, ValueToFind, ValueToFind.Length, out FoundStringSize, HMODULE.Zero, HMODULE.Zero, HMODULE.Zero);
            if (ValueStartingIndex is not -1)
            {
                return ValueStartingIndex;
            }
            else
            {
                int ErrorCode = Marshal.GetLastPInvokeError();
                return ErrorCode is ERROR_SUCCESS ? ValueStartingIndex : throw new Win32Exception(ErrorCode);
            }
        }

        /// <summary>
        /// Trova una stringa all'interno di un'altra stringa, usando il confronto binario.
        /// </summary>
        /// <param name="SearchStartingPoint">Punto di partenza della ricerca.</param>
        /// <param name="SourceString">Stringa originale.</param>
        /// <param name="ValueToFind">Stringa da trovare.</param>
        /// <param name="IgnoreCasing">Indica se ignorare la distinzione tra maiuscole e minuscole.</param>
        /// <returns>L'indice, basato su 0, dove si trova <paramref name="ValueToFind"/> all'interno di <paramref name="SourceString"/>, -1 se <paramref name="ValueToFind"/> non è stata trovata.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static int FindStringOrdinal(SearchOptions SearchStartingPoint, string SourceString, string ValueToFind, bool IgnoreCasing)
        {
            if (string.IsNullOrWhiteSpace(SourceString))
            {
                throw new ArgumentNullException(nameof(SourceString), "No source string provided.");
            }
            if (string.IsNullOrWhiteSpace(ValueToFind))
            {
                throw new ArgumentNullException(nameof(SourceString), "No value provided.");
            }
            int ValueStartingIndex = NationalLanguageSupportFunctions.FindStringOrdinal((StringSearchStartingPosition)SearchStartingPoint, SourceString, SourceString.Length, ValueToFind, ValueToFind.Length, IgnoreCasing);
            if (ValueStartingIndex is not -1)
            {
                return ValueStartingIndex;
            }
            else
            {
                int ErrorCode = Marshal.GetLastPInvokeError();
                return ErrorCode is ERROR_SUCCESS ? ValueStartingIndex : throw new Win32Exception(ErrorCode);
            }
        }

        /// <summary>
        /// Confronta due stringhe.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="ComparisonOptions">Opzioni di confronto.</param>
        /// <param name="String1">Prima stringa da confrontare.</param>
        /// <param name="String2">Seconda stringa da confrontare.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <returns>Il metodo ritorna uno dei seguenti valori:<br/><br/>
        /// -1 se la prima stringa ha un valore lessicale minore della seconda stringa<br/>
        /// 0 se la prima stringa ha un valore lessicale identico alla seconda stringa<br/>
        /// 1 se la prima stringa ha un valore lessicale superiore alla seconda stringa</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static int CompareString(string? LocaleName, StringComparison? ComparisonOptions, string String1, string String2, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (string.IsNullOrWhiteSpace(String1))
            {
                throw new ArgumentNullException(nameof(String1), "One of the strings to compare has not been provided.");
            }
            if (string.IsNullOrWhiteSpace(String2))
            {
                throw new ArgumentNullException(nameof(String2), "One of the strings to compare has not been provided.");
            }
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (!IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, HMODULE.Zero, String1, String1.Length) || !IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, HMODULE.Zero, String2, String2.Length))
            {
                throw new FormatException("One of the provided strings is not defined in NLS.");
            }
            else
            {
                uint Flags = ComparisonOptions is not null ? (uint)ComparisonOptions : 0;
                NLSVersionInfo VersionInfo = new()
                {
                    Size = (uint)Marshal.SizeOf(typeof(NLSVersionInfo))
                };
                if (GetNLSVersion(SYSNLS_FUNCTION.COMPARE_STRING, LocaleName, ref VersionInfo))
                {
                    StringComparisonResult Result = NationalLanguageSupportFunctions.CompareString(LocaleName, Flags, String1, String1.Length, String2, String2.Length, VersionInfo, HMODULE.Zero, HMODULE.Zero);
                    if (Result is not StringComparisonResult.Failed)
                    {
                        return (int)Result - 2;
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
        }

        /// <summary>
        /// Confronta due stringhe eseguendo il confronto binario.
        /// </summary>
        /// <param name="String1">Prima stringa da confrontare.</param>
        /// <param name="String2">Seconda stringa da confrontare.</param>
        /// <param name="IgnoreCasing">Indica se ignorare la distinzione tra maiuscole e minuscole.</param>
        /// <returns>Il metodo ritorna uno dei seguenti valori:<br/><br/>
        /// -1 se la prima stringa ha un valore minore della seconda stringa<br/>
        /// 0 se la prima stringa ha un valore identico alla seconda stringa<br/>
        /// 1 se la prima stringa ha un valore superiore alla seconda stringa</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static int CompareStringOrdinal(string String1, string String2, bool IgnoreCasing)
        {
            if (string.IsNullOrWhiteSpace(String1))
            {
                throw new ArgumentNullException(nameof(String1), "One of the strings to compare has not been provided.");
            }
            if (string.IsNullOrWhiteSpace(String2))
            {
                throw new ArgumentNullException(nameof(String2), "One of the strings to compare has not been provided.");
            }
            if (!IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, HMODULE.Zero, String1, String1.Length) || !IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, HMODULE.Zero, String2, String2.Length))
            {
                throw new FormatException("One of the provided strings is not defined in NLS.");
            }
            else
            {
                StringComparisonResult Result = NationalLanguageSupportFunctions.CompareStringOrdinal(String1, String1.Length, String2, String2.Length, IgnoreCasing);
                if (Result is not StringComparisonResult.Failed)
                {
                    return (int)Result - 2;
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
        }

        /// <summary>
        /// Imposta il valore massimo per gli anni a due cifre.
        /// </summary>
        /// <param name="Calendar">Calendario sul quale applicare l'impostazione.</param>
        /// <param name="NewValue">Nuovo valore per gli anni a due cifre.</param>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetMaximumTwoDigitYearValue(Calendar Calendar, int NewValue)
        {
            if (Calendar is Calendar.All)
            {
                throw new InvalidEnumArgumentException(nameof(Calendar), (int)Calendar, typeof(Calendar));
            }
            string NewValueAsString = Convert.ToString(NewValue);
            if (!SetCalendarInfo(LOCALE_USER_DEFAULT, (CalendarID)Calendar, CalendarInfo.CAL_ITWODIGITYEARMAX, NewValueAsString))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta un oggetto delle informazioni della località.
        /// </summary>
        /// <param name="Info">Informazione da impostare.</param>
        /// <param name="NewValue">Nuovo valore.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static void SetLocaleInfo(LocaleInfoSet Info, object NewValue)
        {
            if (NewValue is null)
            {
                throw new ArgumentNullException(nameof(NewValue), "New value for setting not provided.");
            }
            bool IsNumber = false;
            bool IsBoolean = false;
            switch (Info)
            {
                case LocaleInfoSet.CurrencyFractionalDigitsCount:
                case LocaleInfoSet.FractionalDigitsCount:
                case LocaleInfoSet.PositiveCurrencySymbolPosition:
                case LocaleInfoSet.DigitsShape:
                case LocaleInfoSet.FirstDayOfWeek:
                case LocaleInfoSet.FirstWeekOfYear:
                case LocaleInfoSet.PaperSize:
                case LocaleInfoSet.ReadingOrder:
                case LocaleInfoSet.NegativeCurrencyFormat:
                case LocaleInfoSet.NegativeNumberMode:
                    IsNumber = true;
                    break;
                case LocaleInfoSet.UseDecimalLeadingZeroes:
                case LocaleInfoSet.MeasureSystem:
                    IsBoolean = true;
                    break;
                default:
                    break;
            }
            string Data;
            if (!IsNumber && !IsBoolean)
            {
                Data = (string)NewValue;
                if (!string.IsNullOrWhiteSpace(Data))
                {
                    if (!NationalLanguageSupportFunctions.SetLocaleInfo(LOCALE_USER_DEFAULT, (GeoInfoType)Info, Data))
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid value provided");
                }
            }
            else
            {
                if (IsNumber)
                {
                    Data = Convert.ToString((int)NewValue);
                    if (!NationalLanguageSupportFunctions.SetLocaleInfo(LOCALE_USER_DEFAULT, (GeoInfoType)Info, Data))
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else if (IsBoolean)
                {
                    Data = Convert.ToString(Convert.ToInt32((bool)NewValue));
                    if (!NationalLanguageSupportFunctions.SetLocaleInfo(LOCALE_USER_DEFAULT, (GeoInfoType)Info, Data))
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
            }
            _ = SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, HMODULE.Zero, HMODULE.Zero, SendMessageBehaviour.SMTO_NORMAL, 3000, out _);
        }

        /// <summary>
        /// Imposta la località geografica per l'utente corrente al codice ISO 3166-1 o UN M.49 specificato.
        /// </summary>
        /// <param name="GeoName">codice ISO 3166-1 o UN M.49.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetUserGeographicalName(string GeoName)
        {
            if (!string.IsNullOrWhiteSpace(GeoName))
            {
                throw new ArgumentNullException(nameof(GeoName), "No name provided.");
            }
            if (!SetUserGeoName(GeoName))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Determina se una specifica località supporta gli script indicati o quelli presenti in una stringa fornita.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="TestScripts">Array che contiene gli script da testare nel formato ISO 15924.</param>
        /// <param name="String">Stringa dalla quale verranno determinati gli script da testare.</param>
        /// <param name="LatinAlwaysPresent">Indica se lo script "Latn" deve essere trattato come sempre presente nella lista di script della località.</param>
        /// <param name="UseInvariantLocale">Indica se usare la località neutra.</param>
        /// <param name="UseSystemDefaultLocale">Indica se usare la località predefinita di sistema.</param>
        /// <param name="UseUserDefaultLocale">Indica se usare la località predefinita dell'utente.</param>
        /// <returns>true se la località supporta tutti gli script, false altrimenti.</returns>
        /// <remarks>Se <paramref name="LocaleName"/> è nullo, uno tra <paramref name="UseInvariantLocale"/>, <paramref name="UseSystemDefaultLocale"/> e <paramref name="UseUserDefaultLocale"/> deve essere true.<br/><br/>
        /// Uno tra <paramref name="TestScripts"/> e <paramref name="String"/> deve avere un valore valido.<br/>
        /// Se <paramref name="TestScripts"/> è valido, <paramref name="String"/> verrà ignorato.<br/><br/>
        /// Se viene usato <paramref name="String"/> al posto di <paramref name="TestScripts"/>, la stringa verrà analizzata per determinare quali script compaiono all'interno di essa.<br/>
        /// La lista poi sara confrontata con quella degli script supportati dalla località.<br/><br/>
        /// Se non vengono trovati script nella stringa questo metodo restituisce false.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool AreScriptsSupported(string? LocaleName, string[]? TestScripts, string? String, bool LatinAlwaysPresent = false, bool UseInvariantLocale = false, bool UseSystemDefaultLocale = false, bool UseUserDefaultLocale = false)
        {
            if (string.IsNullOrWhiteSpace(LocaleName))
            {
                if (!UseInvariantLocale && !UseSystemDefaultLocale && !UseUserDefaultLocale)
                {
                    throw new ArgumentNullException(nameof(LocaleName), "A locale must be provided.");
                }
                else
                {
                    if (UseInvariantLocale)
                    {
                        LocaleName = LOCALE_NAME_INVARIANT;
                    }
                    else if (UseSystemDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_SYSTEM_DEFAULT;
                    }
                    else if (UseUserDefaultLocale)
                    {
                        LocaleName = LOCALE_NAME_USER_DEFAULT;
                    }
                }
            }
            else
            {
                if (!IsValidLocaleName(LocaleName))
                {
                    throw new ArgumentException("Invalid locale.", nameof(LocaleName));
                }
            }
            if (TestScripts is null && string.IsNullOrWhiteSpace(String))
            {
                throw new ArgumentNullException(nameof(string.Empty), "No string or list of scripts provided.");
            }
            uint Flags = LatinAlwaysPresent ? VS_ALLOW_LATIN : 0;
            string LocaleScripts = (string)GetLocaleInfo(LocaleName, Enumerations.LocaleInfo.ISO15924ScriptList, UseInvariantLocale, UseSystemDefaultLocale, UseUserDefaultLocale, false);
            if (TestScripts is not null)
            {
                if (TestScripts.Length is 0)
                {
                    throw new ArgumentException("The list of test script is empty.", nameof(TestScripts));
                }
                StringBuilder TestScriptStringBuilder = new();
                foreach (string script in TestScripts)
                {
                    TestScriptStringBuilder.Append(script);
                    TestScriptStringBuilder.Append(';');
                }
                bool Result = VerifyScripts(Flags, LocaleScripts, LocaleScripts.Length, TestScriptStringBuilder.ToString(), TestScriptStringBuilder.Length);
                if (!Result)
                {
                    int ErrorCode = Marshal.GetLastPInvokeError();
                    return ErrorCode is not ERROR_SUCCESS ? throw new Win32Exception(ErrorCode) : Result;
                }
                else
                {
                    return Result;
                }
            }
            else
            {
                string[] Scripts = GetStringScripts(String!);
                if (Scripts.Length > 0)
                {
                    StringBuilder TestScriptStringBuilder = new();
                    foreach (string script in Scripts)
                    {
                        TestScriptStringBuilder.Append(script);
                        TestScriptStringBuilder.Append(';');
                    }
                    bool Result = VerifyScripts(Flags, LocaleScripts, LocaleScripts.Length, TestScriptStringBuilder.ToString(), TestScriptStringBuilder.Length);
                    if (!Result)
                    {
                        int ErrorCode = Marshal.GetLastPInvokeError();
                        return ErrorCode is not ERROR_SUCCESS ? throw new Win32Exception(ErrorCode) : Result;
                    }
                    else
                    {
                        return Result;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}