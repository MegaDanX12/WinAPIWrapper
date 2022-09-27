using WinApiWrapper.UserInterface.ExtendedLinguisticServices;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Costanti ELS.
    /// </summary>
    public static class ELSCostants
    {
#pragma warning disable CA2211 // I campi non costanti non devono essere visibili
        #region Service GUIDs
        #region Language Detection Services
        /// <summary>
        /// GUID del servizio Microsoft Language Detection.
        /// </summary>
        public static Guid MicrosoftLanguageDetectionGUID = ExtendedLinguisticServicesCostants.MicrosoftLanguageDetectionGUID;
        #endregion
        #region Script Detection Services
        /// <summary>
        /// GUID del servizio Microsoft Script Detection.
        /// </summary>

        public static Guid MicrosoftScriptDetectionGUID = ExtendedLinguisticServicesCostants.MicrosoftScriptDetectionGUID;
        #endregion
        #region Transliteration Services
        /// <summary>
        /// GUID del servizio di transliterazione HantToHans.
        /// </summary>
        public static Guid TransliterationHantToHansGUID = ExtendedLinguisticServicesCostants.TransliterationHantToHansGUID;

        /// <summary>
        /// GUID del servizio di transliterazione HansToHant.
        /// </summary>
        public static Guid TransliterationHansToHantGUID = ExtendedLinguisticServicesCostants.TransliterationHansToHantGUID;

        /// <summary>
        /// GUID del servizio di transliterazione MalayalamToLatin.
        /// </summary>
        public static Guid TransliterationMalayalamToLatinGUID = ExtendedLinguisticServicesCostants.TransliterationMalayalamToLatinGUID;

        /// <summary>
        /// GUID del servizio di transliterazione DevanagariToLatin.
        /// </summary>
        public static Guid TransliterationDevanagariToLatinGUID = ExtendedLinguisticServicesCostants.TransliterationDevanagariToLatinGUID;

        /// <summary>
        /// GUID del servizio di transliterazione CyrillicToLatin.
        /// </summary>
        public static Guid CyrillicToLatinGUID = ExtendedLinguisticServicesCostants.CyrillicToLatinGUID;

        /// <summary>
        /// GUID del servizio di transliterazione BengaliToLatin.
        /// </summary>
        public static Guid BengaliToLatinGUID = ExtendedLinguisticServicesCostants.BengaliToLatinGUID;
        #endregion
        #endregion
#pragma warning restore CA2211 // I campi non costanti non devono essere visibili
    }
}