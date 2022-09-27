using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesFunctions;

namespace WinApiWrapper.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Callback per i servizi linguistici estesi.
    /// </summary>
    internal static class ExtendedLinguisticServicesCallbacks
    {
        /// <summary>
        /// Funzione di callback definita dall'applicazione che elabora i dati prodotti dalla funzione <see cref="MappingRecognizeText"/>.
        /// </summary>
        /// <param name="Bag">Puntatore a una struttura <see cref="MAPPING_PROPERTY_BAG"/> che contiene i risultati della chiamata a <see cref="MappingRecognizeText"/>.</param>
        /// <param name="Data">Puntatore a dati privati dell'applicazione.</param>
        /// <param name="DataSize">Dimensione, in bytes, dei dati privati dell'applicazione.</param>
        /// <param name="Result">Valore restituito da <see cref="MappingRecognizeText"/>.</param>
        /// <remarks>Il puntatore indicato nel parametro <paramref name="Data"/> è lo stesso passato nel campo <see cref="MAPPING_OPTIONS.RecognizeCallerData"/>.<br/>
        /// Il valore del parametro <paramref name="DataSize"/> è lo stesso passato nel campo <see cref="MAPPING_OPTIONS.RecognizeCallerDataSize"/>.<br/><br/>
        /// Il valore di <paramref name="Result"/> è <see cref="S_OK"/> se l'operazione ha avuto successo, un codice di errore in caso di errore.</remarks>
        internal delegate void PFN_MAPPINGCALLBACKPROC(ref MAPPING_PROPERTY_BAG Bag, IntPtr Data, DWORD DataSize, HRESULT Result);
    }
}