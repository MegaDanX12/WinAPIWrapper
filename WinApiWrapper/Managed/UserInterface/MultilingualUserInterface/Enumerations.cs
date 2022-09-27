namespace WinApiWrapper.Managed.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Enumerazioni usate per interagire con le funzionalità MUI.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Formato della lingua.
        /// </summary>
        public enum LanguageFormat
        {
            /// <summary>
            /// Identificatore della lingua.
            /// </summary>
            ID = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.LanguageFormat.MUI_LANGUAGE_ID,
            /// <summary>
            /// Nome della lingua.
            /// </summary>
            Name = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.LanguageFormat.MUI_LANGUAGE_NAME
        }

        /// <summary>
        /// Tipo di lingua.
        /// </summary>
        public enum LanguageType
        {
            /// <summary>
            /// La lingua è completamente localizzata.
            /// </summary>
            FullyLocalized = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.LanguageAttributes.MUI_FULL_LANGUAGE,
            /// <summary>
            /// La lingue è parzialmente localizzata.
            /// </summary>
            PartiallyLocalized = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.LanguageAttributes.MUI_PARTIAL_LANGUAGE,
            /// <summary>
            /// La lingua è parte di un pacchetto LIP.
            /// </summary>
            LipLanguage = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.LanguageAttributes.MUI_LIP_LANGUAGE
        }

        /// <summary>
        /// Filtro per la ricerca dei file di risorse.
        /// </summary>
        public enum ResourceFileSearchFilter
        {
            /// <summary>
            /// Tutti i file di risorse specifici della lingua.
            /// </summary>
            AllLanguages = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ResourceFileLocationFilter.MUI_USE_SEARCH_ALL_LANGUAGES,
            /// <summary>
            /// Solo i file che implementano le lingua nella lista di fallback.
            /// </summary>
            FallbackLanguagesOnly = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ResourceFileLocationFilter.MUI_USER_PREFERRED_UI_LANGUAGES,
            /// <summary>
            /// Solo i file per le lingue installate nel computer.
            /// </summary>
            InstalledLanguagesOny = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ResourceFileLocationFilter.MUI_USE_INSTALLED_LANGUAGES
        }

        /// <summary>
        /// Tipo di file di risorse.
        /// </summary>
        public enum ResourceFileType
        {
            /// <summary>
            /// Il file è di lingua neutrale.
            /// </summary>
            LanguageNeutral = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ResourceFileNaming.MUI_LANG_NEUTRAL_PE_FILE,
            /// <summary>
            /// Il file non è di lingua neutrale.
            /// </summary>
            NonLanguageNeutral = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ResourceFileNaming.MUI_NON_LANG_NEUTRAL_FILE
        }

        /// <summary>
        /// Tipo di file MUI.
        /// </summary>
        public enum MUIFileType
        {
            /// <summary>
            /// File di lingua neutrale.
            /// </summary>
            LanguageNeutral = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.FileType.MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN,
            /// <summary>
            /// File specifico della lingua.
            /// </summary>
            LanguageSpecific = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.FileType.MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI,
            /// <summary>
            /// Il file non contiene dati relativi alle risorse lingua.
            /// </summary>
            NoResourceConfigurationData = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.FileType.MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL
        }

        /// <summary>
        /// Tipo di dati da recuperare da un file MUI.
        /// </summary>
        [Flags]
        public enum MUIFileQueryType
        {
            /// <summary>
            /// Tipo di file.
            /// </summary>
            Type = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.MUIQueryType.MUI_QUERY_TYPE,
            /// <summary>
            /// Checksum del file.
            /// </summary>
            Checksum = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.MUIQueryType.MUI_QUERY_CHECKSUM,
            /// <summary>
            /// Nome della lingua.
            /// </summary>
            LanguageName = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.MUIQueryType.MUI_QUERY_LANGUAGE_NAME,
            /// <summary>
            /// Informazioni sulle risorse.
            /// </summary>
            ResourcesInfo = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.MUIQueryType.MUI_QUERY_RESOURCE_TYPES,
            /// <summary>
            /// Tutti i dati.
            /// </summary>
            All = Type |
                  Checksum |
                  LanguageName |
                  ResourcesInfo
        }

        /// <summary>
        /// Filtri per l'impostazioni delle lingue preferite di un thread.
        /// </summary>
        public enum ThreadSetFilter
        {
            /// <summary>
            /// Sostituisce tutte le lingue con script complessi con le appropriate lingue di fallback.
            /// </summary>
            ReplaceComplexScriptLanguages = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ThreadLanguageSetFilter.MUI_COMPLEX_SCRIPT_FILTER,
            /// <summary>
            /// Sostituisce tutte le lingue che non possono essere visualizzate correttamente nella finestra della console con le appropriate lingue di fallback.
            /// </summary>
            ReplaceNonConsoleUsableLanguages = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ThreadLanguageSetFilter.MUI_CONSOLE_FILTER,
            /// <summary>
            /// Annulla tutti i filtri.
            /// </summary>
            ResetFilters = (int)WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations.ThreadLanguageSetFilter.MUI_RESET_FILTERS
        }
    }
}