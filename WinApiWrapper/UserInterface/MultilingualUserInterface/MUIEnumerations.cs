using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIStructures;

namespace WinApiWrapper.UserInterface.MultilingualUserInterface
{
    internal static class MUIEnumerations
    {
        /// <summary>
        /// Formato delle lingue restituite da <see cref="MUIFunctions.EnumUILanguages"/>.
        /// </summary>
        internal enum LanguageFormat : DWORD
        {
            /// <summary>
            /// ID del linguaggio.
            /// </summary>
            MUI_LANGUAGE_ID = 0x4,
            /// <summary>
            /// Nome del linguaggio.
            /// </summary>
            MUI_LANGUAGE_NAME = 0x8,
        }

        /// <summary>
        /// Tipo di file MUI.
        /// </summary>
        internal enum FileType : DWORD
        {
            /// <summary>
            /// Il file di input non ha dati di configurazione delle risorse.
            /// </summary>
            MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL = 0x001,
            /// <summary>
            /// Il file di input è un file LN (Language Neutral).
            /// </summary>
            MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN = 0x002,
            /// <summary>
            /// Il file di imput è un file specifico della lingua.
            /// </summary>
            MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI = 0x004
        }

        /// <summary>
        /// Tipo di dati da recuperare dalle informazioni MUI di un file.
        /// </summary>
        [Flags]
        internal enum MUIQueryType : DWORD
        {
            /// <summary>
            /// Tipo del file.
            /// </summary>
            /// <remarks>Il valore recuperato si trova nel campo <see cref="FILEMUIINFO.FileType"/>.</remarks>
            MUI_QUERY_TYPE = 0x001,
            /// <summary>
            /// Checksum della risorsa.
            /// </summary>
            /// <remarks>Il valore recuperato si trova nel campo <see cref="FILEMUIINFO.Checksum"/>, ha valore 0 se l'informazione non è disponibile.</remarks>
            MUI_QUERY_CHECKSUM = 0x002,
            /// <summary>
            /// Lingua associata al file di input.
            /// </summary>
            MUI_QUERY_LANGUAGE_NAME = 0x004,
            /// <summary>
            /// Lista di tipi di risorse.
            /// </summary>
            MUI_QUERY_RESOURCE_TYPES = 0x008
        }

        /// <summary>
        /// Filtro per la ricerca dei file di risorse.
        /// </summary>
        internal enum ResourceFileLocationFilter : DWORD
        {
            /// <summary>
            /// Soltanto i file che implementano linguaggi nella lista di fallback.
            /// </summary>
            MUI_USER_PREFERRED_UI_LANGUAGES = 0x10,
            /// <summary>
            /// Soltanto i file per le lingue installate nel computer.
            /// </summary>
            MUI_USE_INSTALLED_LANGUAGES = 0x20,
            /// <summary>
            /// Tutti i file specifici della lingua presenti nel percorso.
            /// </summary>
            MUI_USE_SEARCH_ALL_LANGUAGES = 0x40
        }

        /// <summary>
        /// Specifica se aggiungere o meno l'estensione .mui.
        /// </summary>
        internal enum ResourceFileNaming : DWORD
        {
            /// <summary>
            /// Aggiunge l'estensione .mui al nome del file.
            /// </summary>
            MUI_LANG_NEUTRAL_PE_FILE = 0x100,
            /// <summary>
            /// Non aggiunge l'estensione .mui al nome del file.
            /// </summary>
            MUI_NON_LANG_NEUTRAL_FILE = 0x200
        }

        /// <summary>
        /// Filtro delle lingue di un thread.
        /// </summary>
        [Flags]
        internal enum ThreadLanguageFilter : DWORD
        {
            /// <summary>
            /// Usa il fallback di sistema per recuperare una lista che corrisponde esattamente al quella usata dal caricatore di risorse.
            /// </summary>
            /// <remarks>Questa opzione può essere combinata solo con <see cref="MUI_MERGE_USER_FALLBACK"/>.</remarks>
            MUI_MERGE_SYSTEM_FALLBACK = 0x10,
            /// <summary>
            /// Recupera una lista di lingue nel seguente ordine:<br/><br/>
            /// 1) lingue preferite del thread<br/>
            /// 2) lingue preferite del sistema<br/>
            /// 3) lingue preferite dell'utente<br/>
            /// 4) lingua predefinita di sistema dell'interfaccia utente<br/>
            /// I duplicati vengono ignorati.<br/><br/>
            /// Se la lista di lingue preferite dall'utente è vuota, vengono recuperate le lingue preferite del sistema.<br/><br/>
            /// Questa opzione non può essere combinata con <see cref="MUI_THREAD_LANGUAGES"/>.</summary>
            MUI_MERGE_USER_FALLBACK = 0x20,
            /// <summary>
            /// Recupera una lista completa di lingue preferite dal thread insieme alle lingue fallback e neutrali associate.
            /// </summary>
            MUI_UI_FALLBACK = MUI_MERGE_SYSTEM_FALLBACK | MUI_MERGE_USER_FALLBACK,
            /// <summary>
            /// Recupera solo le lingue preferite dal thread oppure una lista vuota se non sono impostate lingue preferite per il thread.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="MUI_MERGE_USER_FALLBACK"/> e <see cref="MUI_MERGE_SYSTEM_FALLBACK"/>.</remarks>
            MUI_THREAD_LANGUAGES = 0x40
        }

        /// <summary>
        /// Attributi di una lingua.
        /// </summary>
        [Flags]
        internal enum LanguageAttributes : DWORD
        {
            /// <summary>
            /// Lingua con localizzazione completa.
            /// </summary>
            MUI_FULL_LANGUAGE = 0x01,
            /// <summary>
            /// Lingua con localizzazione parziale.
            /// </summary>
            MUI_PARTIAL_LANGUAGE = 0x02,
            /// <summary>
            /// Lingua parte di un pacchetto di installazione lingue (LIP).
            /// </summary>
            MUI_LIP_LANGUAGE = 0x04,
            /// <summary>
            /// La lingua è installata.
            /// </summary>
            MUI_LANGUAGE_INSTALLED = 0x20,
            /// <summary>
            /// La lingua ha la licenza appropriata per l'utente corrente.
            /// </summary>
            MUI_LANGUAGE_LICENSED = 0x40
        }

        /// <summary>
        /// Opzioni di filtraggio per l'impostazione delle lingue preferite di un thread.
        /// </summary>
        internal enum ThreadLanguageSetFilter : DWORD
        {
            /// <summary>
            /// Tutte le lingue che non possono essere visualizzate correttamente in una finestra della console devono essere sostituite con le lingue fallback appropriate in base alle impostazioni del sistema operativo.
            /// </summary>
            MUI_CONSOLE_FILTER = 0x100,
            /// <summary>
            /// Tutte le lingue con script complessi devono essere sostituite con le lingue di fallback appropriate.
            /// </summary>
            MUI_COMPLEX_SCRIPT_FILTER = 0x200,
            /// <summary>
            /// Rimuove i filtri.
            /// </summary>
            MUI_RESET_FILTERS = 0x001
        }
    }
}