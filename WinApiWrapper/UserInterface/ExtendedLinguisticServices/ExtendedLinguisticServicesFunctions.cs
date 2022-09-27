using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;

namespace WinApiWrapper.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Funzioni dei servizi linguistici estesi.
    /// </summary>
    internal static class ExtendedLinguisticServicesFunctions
    {
        /// <summary>
        /// Fa in modo che un servizio ELS esegua un azione dopo il riconoscimento del testo.
        /// </summary>
        /// <param name="Bag">Puntatore a una struttura <see cref="MAPPING_PROPERTY_BAG"/> che contiene i risultati di una chiamata precedente alla funzione <see cref="MappingRecognizeText"/>.</param>
        /// <param name="RangeIndex">Indice iniziale all'interno dei risultato di riconoscimento testo per uno specifica sezione del testo riconosciuto.</param>
        /// <param name="ActionID">Identificatore dell'azione da eseguire.</param>
        /// <returns>Restituisce <see cref="S_OK"/> se l'operazione ha successo, un codice HRESULT in caso di errore.</returns>
        /// <remarks>I parametri <paramref name="Bag"/> e <paramref name="ActionID"/> non possono essere nulli.</remarks>
        [DllImport("Elscore.dll", EntryPoint = "MappingDoAction", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HRESULT MappingDoAction(ref MAPPING_PROPERTY_BAG Bag, DWORD RangeIndex, LPCWSTR ActionID);

        /// <summary>
        /// Libera la memoria e le risorse allocate durante un'operazione ELS di riconoscimento testo.
        /// </summary>
        /// <param name="Bag">Puntatore a istanza di <see cref="MAPPING_PROPERTY_BAG"/>.</param>
        /// <returns>Restituisce <see cref="S_OK"/> se l'operazione ha successo, un codice HRESULT in caso di errore.</returns>
        /// <remarks>Il parametro <paramref name="Bag"/> non può essere nullo.</remarks>
        [DllImport("Elscore.dll", EntryPoint = "MappingFreePropertyBag", SetLastError = true)]
        internal static extern HRESULT MappingFreePropertyBag(ref MAPPING_PROPERTY_BAG Bag);

        /// <summary>
        /// Libera la memoria e le risorse allocate dall'applicazione per interagire con uno o più i servizi ELS.
        /// </summary>
        /// <param name="ServiceInfo">Puntatore a un array di strutture <see cref="MAPPING_SERVICE_INFO"/> che contengono le descrizioni del servizio recuperate da una chiamate precedente a <see cref="MappingGetServices"/>.</param>
        /// <returns>Restituisce <see cref="S_OK"/> se l'operazione ha successo, un codice HRESULT in caso di errore.</returns>
        /// <remarks>Il parametro <paramref name="ServiceInfo"/> non può essere <see cref="IntPtr.Zero"/>.</remarks>
        [DllImport("Elscore.dll", EntryPoint = "MappingFreeServices", SetLastError = true)]
        internal static extern HRESULT MappingFreeServices(IntPtr ServiceInfo);

        /// <summary>
        /// Recupera una lista dei servizi ELS supportati dalla piattaforma, con le relative informazioni, in base ai criteri specificati.
        /// </summary>
        /// <param name="Options">Puntatore a una struttura <see cref="MAPPING_ENUM_OPTIONS"/> che contiene i criteri da usare durante l'enumerazione dei servizi.</param>
        /// <param name="Services">Indirizzo di un puntatore a un array di strutture <see cref="MAPPING_SERVICE_INFO"/> che contengolo le informazioni sui servizi.</param>
        /// <param name="ServicesCount">Numero di servizi recuperati.</param>
        /// <returns><see cref="S_OK"/> se l'operazione ha successo, un codice HRESULT in caso di errore.</returns>
        /// <remarks>Il parametro <paramref name="Options"/> può essere <see cref="IntPtr.Zero"/>, in questo caso vengono recuperati tutti i servizi.</remarks>
        [DllImport("Elscore.dll", EntryPoint = "MappingGetServices", SetLastError = true)]
        internal static extern HRESULT MappingGetServices(IntPtr Options, out IntPtr Services, out DWORD ServicesCount);

        /// <summary>
        /// Utilizza un servizio ELS per riconoscere il testo.
        /// </summary>
        /// <param name="ServiceInfo">Puntatore a una struttura <see cref="MAPPING_SERVICE_INFO"/> che contiene informazioni sul servizio da usare.</param>
        /// <param name="Text">Testo da riconoscere.</param>
        /// <param name="Length">Lunghezza, in caratteri, del testo.</param>
        /// <param name="Index">Indica nel testo che deve essere usato dal servizio.</param>
        /// <param name="Options">Puntatore a struttura <see cref="MAPPING_OPTIONS"/> che contiene le opzioni che influenzato il risultato e il comportamento del riconoscimento del testo.</param>
        /// <param name="Bag">Puntatore a struttura <see cref="MAPPING_PROPERTY_BAG"/>.</param>
        /// <returns><see cref="S_OK"/> se l'operazione ha successo, un codice HRESULT in caso di errore.</returns>
        /// <remarks><paramref name="ServiceInfo"/>, <paramref name="Text"/> e <paramref name="Bag"/> non possono essere nulli.<br/><br/>
        /// La struttura puntata da <paramref name="ServiceInfo"/> deve essere una di quelle recuperate da una chiamata precedente a <see cref="MappingGetServices"/>.<br/>
        /// Il testo del parametro <paramref name="Text"/> deve essere in codifica UTF-16, alcuni servizi potrebbero avere altri requisiti.<br/>
        /// Il valore di <paramref name="Index"/> deve essere tra 0 e la lunghezza del testo - 1, se l'applicazione vuole elaborare tutto il testo, il valore deve essere 0.<br/><br/>
        /// Non è necessario specificare tutti i campi per la struttura puntata da <paramref name="Options"/>, impostarlo a <see cref="IntPtr.Zero"/> se si vuole usare le opzioni di default.<br/><br/>
        /// Come input, il parametro <paramref name="Bag"/> deve essere la struttura con solo il campo <see cref="MAPPING_PROPERTY_BAG.Size"/> impostato, la funzione imposta tutti gli altri campi.</remarks>
        [DllImport("Elscore.dll", EntryPoint = "MappingRecognizeText", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HRESULT MappingRecognizeText(ref MAPPING_SERVICE_INFO ServiceInfo, LPCWSTR Text, DWORD Length, DWORD Index, IntPtr Options, ref MAPPING_PROPERTY_BAG Bag);
    }
}