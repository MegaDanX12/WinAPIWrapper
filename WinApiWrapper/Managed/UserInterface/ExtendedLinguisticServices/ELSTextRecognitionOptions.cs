using WinApiWrapper.UserInterface.ExtendedLinguisticServices;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesCallbacks;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Opzioni per il riconoscimento del testo.
    /// </summary>
    public class ELSTextRecognitionOptions
    {
        /// <summary>
        /// Lingua di input, formato IETF.
        /// </summary>
        public string? InputLanguage { get; set; }

        /// <summary>
        /// Lingua di output, formato IETF.
        /// </summary>
        public string? OutputLanguage { get; set; }

        /// <summary>
        /// Nome standard Unicode dello script di input.
        /// </summary>
        public string? InputScript { get; set; }

        /// <summary>
        /// Nome standard Unicode dello script di output.
        /// </summary>
        public string? OutputScript { get; set; }

        /// <summary>
        /// Tipo MIME di contenuto di input.
        /// </summary>
        public string? InputContentType { get; set; }

        /// <summary>
        /// Tipo MIME di contenuto di output.
        /// </summary>
        public string? OutputContentType { get; set; }

        /// <summary>
        /// Indica se l'operazione deve essere eseguita in modo asincrono.
        /// </summary>
        public bool Async { get; set; }

        /// <summary>
        /// Callback per l'esecuzione asincrona del riconoscimento del testo.
        /// </summary>
        public Action<ELSTextRecognitionProperties>? AsyncMethod { get; set; }

        /// <summary>
        /// Dati privati dell'applicazione.
        /// </summary>
        public byte[]? ApplicationData { get; set; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ELSTextRecognitionOptions"/>.
        /// </summary>
        /// <param name="InputLanguage">Lingua di input, formato IETF.</param>
        /// <param name="OutputLanguage">Lingua di output, formato IETF.</param>
        /// <param name="InputScript">Nome standard Unicode dello script di input.</param>
        /// <param name="OutputScript">Nome standard Unicode dello script di output.</param>
        /// <param name="InputContentType">Tipo MIME di contenuto di input.</param>
        /// <param name="OutputContentType">Tipo MIME di contenuto di output.</param>
        /// <param name="Async">Indica se l'operazione deve essere eseguita in modo asincrono.</param>
        /// <param name="AsyncMethod">Callback per l'esecuzione asincrona del riconoscimento del testo.</param>
        /// <param name="ApplicationData">Dati privati dell'applicazione.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ELSTextRecognitionOptions(string? InputLanguage = null, string? OutputLanguage = null, string? InputScript = null, string? OutputScript = null, string? InputContentType = null, string? OutputContentType = null, bool Async = false, Action<ELSTextRecognitionProperties>? AsyncMethod = null, byte[]? ApplicationData = null)
        {
            this.InputLanguage = InputLanguage;
            this.OutputLanguage = OutputLanguage;
            this.InputScript = InputScript;
            this.OutputScript = OutputScript;
            this.InputContentType = InputContentType;
            this.OutputContentType = OutputContentType;
            this.Async = Async;
            if (Async)
            {
                if (AsyncMethod is not null)
                {
                    this.AsyncMethod = AsyncMethod;
                }
                else
                {
                    throw new ArgumentNullException(nameof(AsyncMethod), "If the " + nameof(Async) + " parameter is true, the " + nameof(AsyncMethod) + " parameter cannot be null.");
                }
            }
            this.ApplicationData = ApplicationData;
        }

        /// <summary>
        /// Converte i dati di questa classe in una struttura <see cref="MAPPING_OPTIONS"/>.
        /// </summary>
        /// <returns>La struttura <see cref="MAPPING_OPTIONS"/> risultato della conversione.</returns>
        internal MAPPING_OPTIONS ToStruct()
        {
            MAPPING_OPTIONS Options = new();
            if (!string.IsNullOrWhiteSpace(InputLanguage))
            {
                Options.InputLanguage = InputLanguage;
            }
            if (!string.IsNullOrWhiteSpace(OutputLanguage))
            {
                Options.OutputLanguage = OutputLanguage;
            }
            if (!string.IsNullOrWhiteSpace(InputScript))
            {
                Options.InputScript = InputScript;
            }
            if (!string.IsNullOrWhiteSpace(OutputScript))
            {
                Options.OutputScript = OutputScript;
            }
            if (!string.IsNullOrWhiteSpace(InputContentType))
            {
                Options.InputContentType = InputContentType;
            }
            if (!string.IsNullOrWhiteSpace(OutputContentType))
            {
                Options.OutputContentType = OutputContentType;
            }
            if (Async)
            {
                ELSMetadata.TextRecognitionUserAsyncMethod = AsyncMethod!;
                ELSMetadata.InternalTextRecognitionCallback = new(ELSManaged.TextRecognitionAsyncMethod);
                Options.RecognizeCallback = ELSMetadata.InternalTextRecognitionCallback;
            }
            if (ApplicationData is not null)
            {
                Options.RecognizeCallerDataSize = (uint)ApplicationData.Length;
                Options.RecognizeCallerData = Marshal.AllocHGlobal(ApplicationData.Length);
                HMODULE SecondPointer = Options.RecognizeCallerData;
                foreach (byte data in ApplicationData)
                {
                    Marshal.WriteByte(SecondPointer, data);
                    SecondPointer += 1;
                }
            }
            else
            {
                Options.RecognizeCallerData = HMODULE.Zero;
            }
            return Options;
        }
    }
}