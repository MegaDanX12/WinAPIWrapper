using WinApiWrapper.UserInterface.ExtendedLinguisticServices;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;
using static WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices.Enumerations;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Opzioni per l'enumerazione dei servizi ELS.
    /// </summary>
    public class ELSEnumerationOptions
    {
        /// <summary>
        /// Categoria a cui appartiene il servizio.
        /// </summary>
        public ServiceCategory? Category { get; }

        /// <summary>
        /// Lingua di input.
        /// </summary>
        public string? InputLanguage { get; }

        /// <summary>
        /// Lingua di output.
        /// </summary>
        public string? OutputLanguage { get; }

        /// <summary>
        /// Script di input.
        /// </summary>
        public string? InputScript { get; }

        /// <summary>
        /// Script di output.
        /// </summary>
        public string? OutputScript { get; }

        /// <summary>
        /// Tipo MIME di contenuto input.
        /// </summary>
        public string? InputContentType { get; }

        /// <summary>
        /// Tipo MIME di contenuto output.
        /// </summary>
        public string? OutputContentType { get; }

        /// <summary>
        /// GUID del servizio.
        /// </summary>
        public Guid? GUID { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ELSEnumerationOptions"/>.
        /// </summary>
        /// <param name="Category">Categoria.</param>
        /// <param name="InputLanguage">Lingua di input.</param>
        /// <param name="OutputLanguage">Lingua di output.</param>
        /// <param name="InputScript">Script di input.</param>
        /// <param name="OutputScript">Script di output.</param>
        /// <param name="InputContentType">Tipo MIME di contenuto input.</param>
        /// <param name="OutputContentType">Tipo MIME di contenuto output.</param>
        /// <param name="GUID">GUID del servizio.</param>
        /// <remarks>Solo i parametri non nulli saranno usati come criteri di ricerca.</remarks>
        public ELSEnumerationOptions(ServiceCategory? Category = null, string? InputLanguage = null, string? OutputLanguage = null, string? InputScript = null, string? OutputScript = null, string? InputContentType = null, string? OutputContentType = null, Guid? GUID = null)
        {
            this.Category = Category;
            this.InputLanguage = InputLanguage;
            this.OutputLanguage = OutputLanguage;
            this.InputScript = InputScript;
            this.OutputScript = OutputScript;
            this.InputContentType = InputContentType;
            this.OutputContentType = OutputContentType;
            this.GUID = GUID;
        }

        /// <summary>
        /// Converte i dati di questa classe in una struttura <see cref="MAPPING_ENUM_OPTIONS"/>.
        /// </summary>
        /// <returns>Istanza di <see cref="MAPPING_ENUM_OPTIONS"/>.</returns>
        internal MAPPING_ENUM_OPTIONS ToStruct()
        {
            MAPPING_ENUM_OPTIONS Options = new();
            if (Category is not null)
            {
                switch (Category.Value)
                {
                    case ServiceCategory.LanguageDetection:
                        Options.Category = ExtendedLinguisticServicesCostants.LanguageDetectionCategory;
                        break;
                    case ServiceCategory.ScriptDetection:
                        Options.Category = ExtendedLinguisticServicesCostants.ScriptDetectionCategory;
                        break;
                    case ServiceCategory.Transliteration:
                        Options.Category = ExtendedLinguisticServicesCostants.TransliterationCategory;
                        break;
                }
            }
            if (InputLanguage is not null)
            {
                Options.InputLanguage = InputLanguage;
            }
            if (OutputLanguage is not null)
            {
                Options.OutputLanguage = OutputLanguage;
            }
            if (InputScript is not null)
            {
                Options.InputScript = InputScript;
            }
            if (OutputScript is not null)
            {
                Options.OutputScript = OutputScript;
            }
            if (InputContentType is not null)
            {
                Options.InputContentType = InputContentType;
            }
            if (OutputContentType is not null)
            {
                Options.OutputContentType = OutputContentType;
            }
            if (GUID is not null)
            {
                HMODULE GUIDPointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid)));
                Marshal.StructureToPtr(GUID, GUIDPointer, false);
                Options.Guid = GUIDPointer;
            }
            return Options;
        }
    }
}