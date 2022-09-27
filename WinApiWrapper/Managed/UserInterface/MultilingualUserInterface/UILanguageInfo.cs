using System.ComponentModel;
using System.Globalization;
using System.Text;
using WinApiWrapper.UserInterface.MultilingualUserInterface;
using WinApiWrapper.UserInterface.NationalLanguageSupport;
using static WinApiWrapper.Managed.UserInterface.MultilingualUserInterface.Enumerations;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIFunctions;

namespace WinApiWrapper.Managed.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Informazioni su una lingua dell'interfaccia utente.
    /// </summary>
    public class UILanguageInfo
    {
        /// <summary>
        /// Nome della lingua.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Indica se la lingua è installata.
        /// </summary>
        public bool IsInstalled { get; }

        /// <summary>
        /// Indica se la lingua è licenziata per l'utente corrente.
        /// </summary>
        public bool IsLicensed { get; }

        /// <summary>
        /// Tipo di lingua.
        /// </summary>
        public LanguageType Type { get; }

        /// <summary>
        /// Lingue di fallback.
        /// </summary>
        public List<string> FallbackLanguages { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="UILanguageInfo"/>.
        /// </summary>
        /// <param name="Language">Lingua di cui recuperare le informazioni.</param>
        /// <param name="Format">Formato della lingua.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public UILanguageInfo(string Language, Enumerations.LanguageFormat Format) : this(Language, (MUIEnumerations.LanguageFormat)Format) { }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="UILanguageInfo"/>.
        /// </summary>
        /// <param name="Language">Lingua di cui recuperare le informazioni.</param>
        /// <param name="Format">Formato della lingua.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        internal UILanguageInfo(string Language, MUIEnumerations.LanguageFormat Format)
        {
            if (string.IsNullOrWhiteSpace(Language))
            {
                throw new ArgumentNullException(nameof(Language), "No language provided.");
            }
            if (Format is MUIEnumerations.LanguageFormat.MUI_LANGUAGE_ID)
            {
                if (Language.StartsWith("0x"))
                {
                    throw new ArgumentException("Language is not correctly formatted.", nameof(Language));
                }
                else
                {
                    this.Language = GetLanguageName(Language);
                }
            }
            else if (Format is MUIEnumerations.LanguageFormat.MUI_LANGUAGE_NAME)
            {
                this.Language = Language;
            }
            else
            {
                throw new InvalidEnumArgumentException("Invalid format.", (int)Format, typeof(Enumerations.LanguageFormat));
            }
            FallbackLanguages = new();
            uint BufferSize = 0;
            _ = GetUILanguageInfo(Format, Language, HMODULE.Zero, ref BufferSize, out LanguageAttributes Attributes);
            if (BufferSize > 2)
            {
                uint BufferSizeBytes = BufferSize *= 2;
                HMODULE FallbackLanguagesBuffer = Marshal.AllocHGlobal((int)BufferSizeBytes);
                if (GetUILanguageInfo(Format, Language, FallbackLanguagesBuffer, ref BufferSize, out Attributes))
                {
                    string FallbackLanguage;
                    int StringBytes;
                    HMODULE SecondBuffer = FallbackLanguagesBuffer;
                    do
                    {
                        FallbackLanguage = Marshal.PtrToStringUni(SecondBuffer)!;
                        StringBytes = Encoding.Unicode.GetByteCount(FallbackLanguage) + 1;
                        SecondBuffer += StringBytes;
                        if (!string.IsNullOrWhiteSpace(FallbackLanguage))
                        {
                            if (Format is MUIEnumerations.LanguageFormat.MUI_LANGUAGE_ID)
                            {
                                FallbackLanguage = GetLanguageName(FallbackLanguage);
                            }
                            FallbackLanguages.Add(FallbackLanguage);
                        }
                    }
                    while (!string.IsNullOrWhiteSpace(FallbackLanguage));
                    Marshal.FreeHGlobal(FallbackLanguagesBuffer);
                }
                else
                {
                    Marshal.FreeHGlobal(FallbackLanguagesBuffer);
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            IsInstalled = Attributes.HasFlag(LanguageAttributes.MUI_LANGUAGE_INSTALLED);
            IsLicensed = Attributes.HasFlag(LanguageAttributes.MUI_LANGUAGE_LICENSED);
            if (Attributes.HasFlag(LanguageAttributes.MUI_FULL_LANGUAGE))
            {
                Type = LanguageType.FullyLocalized;
            }
            else if (Attributes.HasFlag(LanguageAttributes.MUI_PARTIAL_LANGUAGE))
            {
                Type = LanguageType.PartiallyLocalized;
            }
            else if (Attributes.HasFlag(LanguageAttributes.MUI_LIP_LANGUAGE))
            {
                Type = LanguageType.LipLanguage;
            }
        }

        /// <summary>
        /// Recupera il nome di una lingua dall'ID.
        /// </summary>
        /// <param name="LocaleID">ID della lingua.</param>
        /// <returns>Nome della lingua.</returns>
        /// <exception cref="Win32Exception"></exception>
        private static string GetLanguageName(string LocaleID)
        {
            bool Success = ushort.TryParse(LocaleID, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out ushort LANGID);
            if (Success)
            {
                LCID LCID = LANGID;
                StringBuilder LanguageName = new(NationalLanguageSupportConstants.LOCALE_NAME_MAX_LENGTH);
                if (NationalLanguageSupportFunctions.LCIDToLocaleName(LCID, LanguageName, NationalLanguageSupportConstants.LOCALE_NAME_MAX_LENGTH, NationalLanguageSupportConstants.LOCALE_ALLOW_NEUTRAL_NAMES) is 0)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError(), "Unable to convert locale ID to locale name.");
                }
                else
                {
                    return LanguageName.ToString();
                }
            }
            else
            {
                throw new ArgumentException("Language is not correctly formatted.", nameof(LocaleID));
            }
        }
    }
}