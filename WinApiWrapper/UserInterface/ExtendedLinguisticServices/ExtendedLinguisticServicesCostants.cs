namespace WinApiWrapper.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Costanti dei servizi linguistici estesi.
    /// </summary>
    internal static class ExtendedLinguisticServicesCostants
    {
        #region Service Categories
        /// <summary>
        /// Rilevamento lingua.
        /// </summary>
        internal const string LanguageDetectionCategory = "LanguageDetection";

        /// <summary>
        /// Rilevamento script.
        /// </summary>
        internal const string ScriptDetectionCategory = "ScriptDetection";

        /// <summary>
        /// Transliterazione.
        /// </summary>
        internal const string TransliterationCategory = "Transliteration";
        #endregion
        #region Service GUIDs
        #region Language Detection Services
        /// <summary>
        /// GUID del servizio Microsoft Language Detection.
        /// </summary>
        internal static Guid MicrosoftLanguageDetectionGUID = new("CF7E00B1-909B-4d95-A8F4-611F7C377702");
        #endregion
        #region Script Detection Services
        /// <summary>
        /// GUID del servizio Microsoft Script Detection.
        /// </summary>
        internal static Guid MicrosoftScriptDetectionGUID = new("2D64B439-6CAF-4f6b-B688-E5D0F4FAA7D7");
        #endregion
        #region Transliteration Services
        /// <summary>
        /// GUID del servizio di transliterazione HantToHans.
        /// </summary>
        internal static Guid TransliterationHantToHansGUID = new("A3A8333B-F4FC-42f6-A0C4-0462FE7317CB");

        /// <summary>
        /// GUID del servizio di transliterazione HansToHant.
        /// </summary>
        internal static Guid TransliterationHansToHantGUID = new("3CACCDC8-5590-42dc-9A7B-B5A6B5B3B63B");

        /// <summary>
        /// GUID del servizio di transliterazione MalayalamToLatin.
        /// </summary>
        internal static Guid TransliterationMalayalamToLatinGUID = new("D8B983B1-F8BF-4a2b-BCD5-5B5EA20613E1");

        /// <summary>
        /// GUID del servizio di transliterazione DevanagariToLatin.
        /// </summary>
        internal static Guid TransliterationDevanagariToLatinGUID = new("C4A4DCFE-2661-4d02-9835-F48187109803");

        /// <summary>
        /// GUID del servizio di transliterazione CyrillicToLatin.
        /// </summary>
        internal static Guid CyrillicToLatinGUID = new("3DD12A98-5AFD-4903-A13F-E17E6C0BFE01");

        /// <summary>
        /// GUID del servizio di transliterazione BengaliToLatin.
        /// </summary>
        internal static Guid BengaliToLatinGUID = new("F4DFD825-91A4-489f-855E-9AD9BEE55727");
        #endregion
        #endregion
    }
}