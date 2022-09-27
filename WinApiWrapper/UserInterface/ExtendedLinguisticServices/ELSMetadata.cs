using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesCallbacks;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;
using WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices;

namespace WinApiWrapper.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Dati utilizzati dalla piattaforma ELS.
    /// </summary>
    internal static class ELSMetadata
    {
        /// <summary>
        /// Puntatore all'array con i dati dei servizi.
        /// </summary>
        internal static IntPtr ServicesDataPointer;

        /// <summary>
        /// Testo da riconoscere.
        /// </summary>
        internal static string? Text;

        /// <summary>
        /// Struttura <see cref="MAPPING_PROPERTY_BAG"/> che contiene i risultati del riconoscimento.
        /// </summary>
        internal static MAPPING_PROPERTY_BAG PropertyBag;

        /// <summary>
        /// Puntatore alla struttura <see cref="MAPPING_OPTIONS"/>.
        /// </summary>
        internal static IntPtr OptionsStructurePointer;

        /// <summary>
        /// Metodo fornito dall'utente per l'elaborazione dei risultati del riconoscimento testo quando eseguito in modalità asincrona.
        /// </summary>
        internal static Action<ELSTextRecognitionProperties>? TextRecognitionUserAsyncMethod;

        /// <summary>
        /// Callback interno per l'elaborazione dei risultati del riconoscimento testo.
        /// </summary>
        internal static PFN_MAPPINGCALLBACKPROC? InternalTextRecognitionCallback;
    }
}
