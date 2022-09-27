using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApiWrapper.SystemServices.DLLs
{
    /// <summary>
    /// Enumerazioni usate per la gestione delle DLL.
    /// </summary>
    internal static class DynamicLinkLibraryEnumerations
    {
        /// <summary>
        /// Opzioni di caricamento moduli.
        /// </summary>
        [Flags]
        internal enum ModuleHandleOptions
        {
            /// <summary>
            /// Viene fornito un indirizzo nel modulo.
            /// </summary>
            FROM_ADDRESS = 4,
            /// <summary>
            /// Il modulo resta caricato fino al termine del processo.
            /// </summary>
            /// <remarks>Questa opzione non può essere usata con <see cref="UNCHANGED_REFCOUNT"/>.</remarks>
            PIN = 1,
            /// <summary>
            /// Il numero di riferimenti al modulo non cambia.
            /// </summary>
            /// <remarks>Questa opzione non può essere usata con <see cref="PIN"/>.</remarks>
            UNCHANGED_REFCOUNT = 2
        }

        /// <summary>
        /// Opzioni di caricamento delle DLL.
        /// </summary>
        [Flags]
        internal enum LoadingOptions
        {
            /// <summary>
            /// Il sistema non controlla le regole AppLocker e non applica i criteri di restrizione software per la DLL.
            /// </summary>
            /// <remarks>Questa opzione è valida solo per la DLL in corso di caricamento e non per le sue dipendenze.</remarks>
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16,
            /// <summary>
            /// Il sistema mappa il file nello spazio di indirizzamento come file di dati.
            /// </summary>
            /// <remarks>Il file viene caricato senza eseguirlo e senza prepararlo per l'esecuzione.<br/><br/>
            /// Questa opzione può essere utilizzata con <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.</remarks>
            LOAD_LIBRARY_AS_DATAFILE = 2,
            /// <summary>
            /// Il sistema mappa il file nello spazio di indirizzamento come file di dati ed esso viene aperto con accesso esclusivo in scrittura per il processo chiamante.
            /// </summary>
            /// <remarks>Altri processi non possono aprire la DLL in scrittura mentre è in uso, ma può essere aperta da altri processi.<br/><br/>
            /// Il file viene caricato senza eseguirlo e senza prepararlo per l'esecuzione.<br/><br/>
            /// Questa opzione può essere utilizzata con <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.</remarks>
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 64,
            /// <summary>
            /// Il sistema mappa il file nello spazio di indirizzamento del processo come file immagine.
            /// </summary>
            /// <remarks>Non vengono caricati gli import statici e non vengono eseguite nessuna dei soliti passaggi per l'inizializzazione.<br/><br/>
            /// Questa opzione è consigliata per caricare una DLL da usare solo per estrarre messaggi o risorse da essa.<br/><br/>
            /// Questa opzione può essere combinata con <see cref="LOAD_LIBRARY_AS_DATAFILE"/> oppure <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> a meno che l'applicazione non richieda che il layout in memoria sia quello di un'immagine.</remarks>
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 32,
            /// <summary>
            /// La libreria e le sue dipendenze vengono ricercate solo nella directory dell'applicazione.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</remarks>
            LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 512,
            /// <summary>
            /// La directory che contiene la DLL viene temporaneamente aggiunta all'inizio della lista di directory ricercate per le dipendenze.
            /// </summary>
            /// <remarks>Le directory nei percorsi standard di ricerca non vengono utlizzate.<br/><br/>
            /// Deve essere specificato un percorso completo.<br/><br/>
            /// Questa opzione non può essere combinata con <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</remarks>
            LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 256,
            /// <summary>
            /// La libreria e le sue dipendenze vengono ricercate solo nella directory System32.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</remarks>
            LOAD_LIBRARY_SEARCH_SYSTEM32 = 2048,
            /// <summary>
            /// La libreria e le sue dipendenze vengono ricercate nelle directory specificate utilizzando le funzioni <see cref="DynamicLinkLibraryFunctions.AddDllDirectory"/> e <see cref="DynamicLinkLibraryFunctions.SetDllDirectory"/>.
            /// </summary>
            /// <remarks>L'ordine di ricerca nelle directory non è definito.<br/><br/>
            /// Questa opzione non può essere combinata con <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</remarks>
            LOAD_LIBRARY_SEARCH_USER_DIRS = 1024,
            /// <summary>
            /// Se viene specificato un percorso completo, il sistema usa la strategia di ricerca alternativa per trovare i moduli eseguibili associati a quello da caricare.
            /// </summary>
            /// <remarks>Se non viene specificato un percorso completo, il comportamento di questa opzione non è definito.<br/><br/>
            /// Questa opzione non può essere combinata con le seguenti opzioni:<br/><br/>
            /// <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/><br/>
            /// <see cref="LOAD_LIBRARY_SEARCH_DEFAULT_DIRS"/><br/>
            /// <see cref="LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR"/><br/>
            /// <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/><br/>
            /// <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/></remarks>
            LOAD_WITH_ALTERED_SEARCH_PATH = 8,
            /// <summary>
            /// La firma digitale dell'immagine deve essere controllata al momento del caricamento.
            /// </summary>
            LOAD_LIBRARY_REQUIRE_SIGNED_TARGET = 128,
            /// <summary>
            /// Permette il caricamento di una DLL dalla directory corrente solo se si trova tra le directory sicure.
            /// </summary>
            LOAD_LIBRARY_SAFE_CURRENT_DIRS = 8192,
            /// <summary>
            /// La ricerca della DLL e delle sue dipendenze viene eseguita nella directory dell'applicazione, nella directory System32 e nelle directory definite tramite le funzioni <see cref="DynamicLinkLibraryFunctions.AddDllDirectory"/> e <see cref="DynamicLinkLibraryFunctions.SetDllDirectory"/>.
            /// </summary>
            /// <remarks>Questa opzione non può essere combinata con <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</remarks>
            LOAD_LIBRARY_SEARCH_DEFAULT_DIRS =
                LOAD_LIBRARY_SEARCH_APPLICATION_DIR |
                LOAD_LIBRARY_SEARCH_SYSTEM32 |
                LOAD_LIBRARY_SEARCH_USER_DIRS
        }
    }
}