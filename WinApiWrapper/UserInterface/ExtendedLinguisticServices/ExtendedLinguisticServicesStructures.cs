using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesFunctions;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesCallbacks;

namespace WinApiWrapper.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Strutture dei servizi linguistici estesi.
    /// </summary>
    internal class ExtendedLinguisticServicesStructures
    {
        /// <summary>
        /// Proprietà di riconoscimento testo recuperate dalla funzione <see cref="MappingRecognizeText"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MAPPING_PROPERTY_BAG
        {
            /// <summary>
            /// Dimensione, in byte, della struttura, usato per verificare la versione della struttura.
            /// </summary>
            /// <remarks>Questo campo è obbligatorio.</remarks>
            public SIZE_T Size;
            /// <summary>
            /// Puntatore a un array di strutture <see cref="MAPPING_DATA_RANGE"/> che contiene tutti i risultati del testo riconosciuto.
            /// </summary>
            /// <remarks>Questo campo è impostato dalla funzione <see cref="MappingRecognizeText"/>.</remarks>
            public IntPtr ResultRanges;
            /// <summary>
            /// Numero di oggetti presenti nell'array puntato da <see cref="ResultRanges"/>.
            /// </summary>
            /// <remarks>Questo campo è impostato dalla funzione <see cref="MappingRecognizeText"/>.</remarks>
            public DWORD RangesCount;
            /// <summary>
            /// Puntatore a dati privati del servizio.
            /// </summary>
            /// <remarks>Il servizio può documentare il formato dei dati così che possano essere usati dall'applicazione.<br/>
            /// Il servizio gestisce la memoria per questi dati.<br/><br/>
            /// Questo campo è impostato dalla funzione <see cref="MappingRecognizeText"/>.</remarks>
            public PVOID ServiceData;
            /// <summary>
            /// Dimensione, in bytes, dei dati privati del servizio puntati da <see cref="ServiceData"/>.
            /// </summary>
            /// <remarks>Questo campo è impostato a 0 se non ci sono dati.<br/><br/>
            /// Questo campo è impostato dalla funzione <see cref="MappingRecognizeText"/>.</remarks>
            public DWORD ServiceDataSize;
            /// <summary>
            /// Puntatore a dati privati dell'applicazione.
            /// </summary>
            /// <remarks>L'applicazione gestisce la memoria di questi dati.</remarks>
            public PVOID CallerData;
            /// <summary>
            /// Dimensione, in bytes, dei dati privati dell'applicazione.
            /// </summary>
            /// <remarks>Questo campo è impostato a 0 se non ci sono dati.</remarks>
            public DWORD CallerDataSize;
            /// <summary>
            /// Riservato per uso interno.
            /// </summary>
            private PVOID Context;
        }

        /// <summary>
        /// Contiene i risultati per una sottosezione del testo riconosciuto.
        /// </summary>
        /// <remarks>Il campo <see cref="MAPPING_PROPERTY_BAG.ResultRanges"/> contiene un array di queste strutture.</remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct MAPPING_DATA_RANGE
        {
            /// <summary>
            /// Indice iniziale della sottosezione nel testo.
            /// </summary>
            /// <remarks>0 indica il carattere a cui si riferisce il puntatore passato a <see cref="MappingRecognizeText"/> invece che un offset all'indice passato alla funzione nel parametro Index.<br/><br/>
            /// Questo valore dovrebbe essere minore della lunghezza del testo.</remarks>
            public DWORD StartIndex;
            /// <summary>
            /// Indice finale della sottosezione nel testo.
            /// </summary>
            /// <remarks>0 indica il carattere a cui si riferisce il puntatore passato a <see cref="MappingRecognizeText"/> invece che un offset all'indice passato alla funzione nel parametro Index.<br/><br/>
            /// Questo valore dovrebbe essere minore della lunghezza del testo.</remarks>
            public DWORD EndIndex;
            /// <summary>
            /// Riservato.
            /// </summary>
            private string Description;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD DescriptionLength;
            /// <summary>
            /// Puntatore ai dati recuperati come output del servizio associato alla sottosezione.
            /// </summary>
            /// <remarks>Questi dati devono essere nel formato specificato da <see cref="ContentType"/>.</remarks>
            public PVOID Data;
            /// <summary>
            /// Dimensione, in bytes, dei dati specificati in <see cref="Data"/>.
            /// </summary>
            public DWORD DataSize;
            /// <summary>
            /// Tipo MIME di contenuto indicato da <see cref="Data"/>.
            /// </summary>
            /// <remarks>Questa campo è opzionale.</remarks>
            public string ContentType;
            /// <summary>
            /// ID delle azioni disponibile per la sottosezione, utilizzabili chiamando <see cref="MappingDoAction"/>.
            /// </summary>
            public IntPtr ActionIDs;
            /// <summary>
            /// Numero di azioni disponibilie per sottosezione.
            /// </summary>
            public DWORD ActionsCount;
            /// <summary>
            /// Stringhe di visualizzazione per le azioni associate alla sottosezione.
            /// </summary>
            public IntPtr ActionDisplayNames;
        }

        /// <summary>
        /// Opzioni usate dalla funzione <see cref="MappingGetServices"/> per enumerare i servizi ELS.
        /// </summary>
        /// <remarks>Tutti i campi, eccetto <see cref="Size"/>, sono opzionali.<br/>
        /// I campi non utilizzati devono essere nulli.</remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct MAPPING_ENUM_OPTIONS
        {
            /// <summary>
            /// DImensione, in bytes, della struttura, usata per convalidare la versione.
            /// </summary>
            /// <remarks>Questo campo è obbligatorio.</remarks>
            public SIZE_T Size;
            /// <summary>
            /// Categoria.
            /// </summary>
            public LPWSTR Category;
            /// <summary>
            /// Lingua di input, secondo le convenzioni IETF.
            /// </summary>
            public LPWSTR InputLanguage;
            /// <summary>
            /// Lingua di output, secondo le convenzioni IETF.
            /// </summary>
            public LPWSTR OutputLanguage;
            /// <summary>
            /// Nome Unicode di script che può essere accettato dal servizio.
            /// </summary>
            public LPWSTR InputScript;
            /// <summary>
            /// Nome Unicode di script usato dal servizio.
            /// </summary>
            public LPWSTR OutputScript;
            /// <summary>
            /// Tipo MIME di contenuto che il servizio deve essere in grado di interpretare.
            /// </summary>
            public LPWSTR InputContentType;
            /// <summary>
            /// Tipo MIME di contenuto nel quale i servizi recuperano i dati.
            /// </summary>
            public LPWSTR OutputContentType;
            /// <summary>
            /// Puntatore a GUID del servizio.
            /// </summary>
            public IntPtr Guid;
            /// <summary>
            /// Riservato per uso futuro.
            /// </summary>
            private uint OnlineService;
            /// <summary>
            /// Riservato per uso futuro.
            /// </summary>
            private uint ServiceType;
        }

        /// <summary>
        /// Informazioni su un servizio ELS.
        /// </summary>
        /// <remarks>Questa struttura viene generata da una chiamata alla funzione <see cref="MappingGetServices"/>.</remarks>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MAPPING_SERVICE_INFO
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura, usato per convalidare la versione.
            /// </summary>
            public SIZE_T Size;
            /// <summary>
            /// Informazioni copyright.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public LPWSTR Copyright;
            /// <summary>
            /// Numero di versione maggiore.
            /// </summary>
            public WORD MajorVersion;
            /// <summary>
            /// Numero di versione minore.
            /// </summary>
            public WORD MinorVersion;
            /// <summary>
            /// Numero di build.
            /// </summary>
            public WORD BuildVersion;
            /// <summary>
            /// Numero di step.
            /// </summary>
            public WORD StepVersion;
            /// <summary>
            /// Numero di tipi MIME di contenuto che il servizio può ricevere.
            /// </summary>
            public DWORD InputContentTypesCount;
            /// <summary>
            /// Puntatore a un array di tipi di contenuti MIME di input.
            /// </summary>
            public IntPtr InputContentTypes;
            /// <summary>
            /// Numero di tipi MIME di contenuto nei quali il servizio può formattare il risultato.
            /// </summary>
            public DWORD OutputContentTypesCount;
            /// <summary>
            /// Puntatore a un array di tipi di contenuti MIME di output.
            /// </summary>
            public IntPtr OutputContentTypes;
            /// <summary>
            /// Numero di lingue di input supportate dal servizio.
            /// </summary>
            /// <remarks>Impostato a 0 se il servizio supporta tutti i linguaggi.</remarks>
            public DWORD InputLanguagesCount;
            /// <summary>
            /// Puntatore a un array di lingue di input supportate dal servizio, nel formato IETF.
            /// </summary>
            /// <remarks>Questo campo è impostato a <see cref="IntPtr.Zero"/> se il servizio supporta tutti i linguaggi.</remarks>
            public IntPtr InputLanguages;
            /// <summary>
            /// Numero di lingue di output supportate dal servizio.
            /// </summary>
            /// <remarks>Impostato a 0 se il servizio supporta tutti i linguaggi oppure se ignora il linguaggio di output.</remarks>
            public DWORD OutputLanguagesCount;
            /// <summary>
            /// Puntatore a un array di lingue di output supportate dal servizio, nel formato IETF.
            /// </summary>
            /// <remarks>Questo campo è impostato a <see cref="IntPtr.Zero"/> se il servizio supporta tutti i linguaggi oppure se ignora il linguaggio di output.</remarks>
            public IntPtr OutputLanguages;
            /// <summary>
            /// Numero di script di input supportati dal servizio.
            /// </summary>
            /// <remarks>Impostato a 0 se il servizio supporta tutti gli script.</remarks>
            public DWORD InputScriptsCount;
            /// <summary>
            /// Puntatore a un array di script di input, supportati dal servizio.
            /// </summary>
            /// <remarks><see cref="IntPtr.Zero"/> se il servizio supporta tutti gli script oppure se li ignora.</remarks>
            public IntPtr InputScripts;
            /// <summary>
            /// Numero di script di output supportati dal servizio.
            /// </summary>
            /// <remarks>Impostato a 0 se il servizio supporta tutti gli script o se li ignora.</remarks>
            public DWORD OutputScriptsCount;
            /// <summary>
            /// Puntatore a un array di script di output, supportati dal servizio.
            /// </summary>
            /// <remarks><see cref="IntPtr.Zero"/> se il servizio supporta tutti gli script oppure se li ignora.</remarks>
            public IntPtr OutputScripts;
            /// <summary>
            /// GUID del servizio.
            /// </summary>
            public Guid GUID;
            /// <summary>
            /// Categoria del servizio.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public LPWSTR Category;
            /// <summary>
            /// Descrizione del servizio.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public LPWSTR Description;
            /// <summary>
            /// Dimensione, in bytes, dei dati privati del servizio.
            /// </summary>
            /// <remarks>Impostato a 0 se il servizio non ha dati privati.</remarks>
            public DWORD PrivateDataSize;
            /// <summary>
            /// Puntatore a dati privati che il servizio può esporre.
            /// </summary>
            /// <remarks>Questa informazione è statica e viene aggiornata durante l'installazione del servizio.</remarks>
            public PVOID PrivateData;
            /// <summary>
            /// Riservato per uso interno.
            /// </summary>
            private PVOID Context;
            /// <summary>
            /// Indica se la mappatura tra lingue di input e di output è supportata dal servizio.
            /// </summary>
            /// <remarks>I valori di questo campo hanno i seguenti significati:<br/><br/>
            /// false: le lingue di input e output non sono accoppiate e il servizio può ricevere dati in una qualunque delle lingue di input e renderizzare dati in qualunque delle lingue di output.<br/>
            /// true: le lingue di input e output sono accoppiate, questo significa che, per ognuna delle lingue di input, il servizio recupera testo nella lingua di output associata.<br/><br/>
            /// Solo il primo bit di questo campo contiene l'informazione.</remarks>
            public uint IsOneToOneLanguageMapping;
            /// <summary>
            /// Indica se il servizio ha dei sottoservizi.
            /// </summary>
            /// <remarks>Per sottoservizi si intende servizi che si connettono a questo.<br/><br/>
            /// I valori di questo campo hanno i seguenti significati:<br/><br/>
            /// false: il servizio non ha sottoservizi.<br/>
            /// true: il servizio agisce come padre per i suoi sottoservizi.<br/><br/>
            /// Solo il primo bit di questo campo contiene l'informazione.</remarks>
            public uint HasSubservices;
            /// <summary>
            /// Riservato per uso futuro.
            /// </summary>
            private uint OnlineOnly;
            /// <summary>
            /// Riservato per uso futuro.
            /// </summary>
            private uint ServiceType;
        }

        /// <summary>
        /// Opzioni per il riconoscimento del testo.
        /// </summary>
        /// <remarks>Tutti i campi, tranne <see cref="Size"/> sono facoltativi.</remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct MAPPING_OPTIONS
        {
            /// <summary>
            /// Dimensione, in byte, della struttura, usato per convalidare la versione della struttura.
            /// </summary>
            public SIZE_T Size;
            /// <summary>
            /// Lingua di input, nel formato IETF, che identifica la lingua che il servizio dovrebbe accettare.
            /// </summary>
            /// <remarks>Se nullo indica che il servizio è libero di interpretare l'input come qualunque lingua che supporta.</remarks>
            public LPWSTR InputLanguage;
            /// <summary>
            /// Lingua di output, nel formato IETF, che identifica la lingua nella quale il servizio dovrebbe produrre risultati.
            /// </summary>
            /// <remarks>Se nullo indica il servizio decide la lingua di output.</remarks>
            public LPWSTR OutputLanguage;
            /// <summary>
            /// Nome standard Unicode di uno script che il servizio dovrebbe accettare.
            /// </summary>
            /// <remarks>Se nullo il servizio decide da solo come gestire l'input.</remarks>
            public LPWSTR InputScript;
            /// <summary>
            /// Nome standard Unicode di uno script che il servizio dovrebbe usare per ricevere i risultati.
            /// </summary>
            /// <remarks>Se nullo il servizio decide da solo lo script di output.</remarks>
            public LPWSTR OutputScript;
            /// <summary>
            /// Formato MIME che il servizio dovrebbe essere in grado di interpretare quando l'applicazione passa i dati.
            /// </summary>
            /// <remarks>Se nullo il formato è "text/plain".</remarks>
            public LPWSTR InputContentType;
            /// <summary>
            /// Formato MIME nel quale il servizio dovrebbe recuperare i dati. 
            /// </summary>
            /// <remarks>Se nullo il servizio decide autonomamente il formato di output.</remarks>
            public LPWSTR OutputContentType;
            /// <summary>
            /// Riservato.
            /// </summary>
            private LPWSTR UILanguage;
            /// <summary>
            /// Funziona di callback che riceve i risultati dalla funzione <see cref="MappingRecognizeText"/>.
            /// </summary>
            /// <remarks>Se questo campo non è nullo, il riconoscimento del testo viene eseguito in modo asincrono e i risultati sono ottenuti tramite la funzione, in caso contrario il riconoscimento del testo viene eseguito in modo sincrono.</remarks>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public PFN_MAPPINGCALLBACKPROC RecognizeCallback;
            /// <summary>
            /// Puntatore a dati privati dell'applicazione passati alla funzione di callback da un servizio dopo il riconoscimento del testo.
            /// </summary>
            /// <remarks>Se non ci sono dati privati, questo campo deve essere <see cref="IntPtr.Zero"/>.</remarks>
            public PVOID RecognizeCallerData;
            /// <summary>
            /// Dimensione, in bytes, dei dati privati dell'applicazione puntati da <see cref="RecognizeCallerData"/>.
            /// </summary>
            public DWORD RecognizeCallerDataSize;
            /// <summary>
            /// Riservato.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            private PFN_MAPPINGCALLBACKPROC ActionCallback;
            /// <summary>
            /// Riservato.
            /// </summary>
            private PVOID ActionCallerData;
            /// <summary>
            /// Riservato.
            /// </summary>
            private DWORD ActionCallerDataSize;
            /// <summary>
            /// Opzione che il provider di un servizio definisce che influisce sul comportamento del servizio.
            /// </summary>
            public DWORD ServiceFlag;
            /// <summary>
            /// Riservato.
            /// </summary>
            private uint GetActionDisplayName;
        }
    }
}