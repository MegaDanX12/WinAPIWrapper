using System.Text;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUICallbacks;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIStructures;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIConstants;

namespace WinApiWrapper.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Funzioni relative alla funzionalità MUI (Multilingual User Interface).
    /// </summary>
    internal static class MUIFunctions
    {
        /// <summary>
        /// Esegue l'enumerazione delle lingue dell'interfaccia utente disponibili al sistema operativo e chiama la funzione di callback per ognuna di esse.
        /// </summary>
        /// <param name="CallbackFunction">Funzione di callback.</param>
        /// <param name="Flags">Formato delle lingue.</param>
        /// <param name="lParam">Valore definito dall'applicazione.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("Kernel32.dll", EntryPoint = "EnumUILanguagesW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL EnumUILanguages(EnumUILanguagesProc CallbackFunction, LanguageFormat Flags, LONG_PTR lParam);

        /// <summary>
        /// Recupera le informazioni relative alle risorse su un file.
        /// </summary>
        /// <param name="Flags">Informazione da recuperare.</param>
        /// <param name="FilePath">Percorso del file.</param>
        /// <param name="FileMUIInfoStructurePointer">Puntatore a struttura <see cref="FILEMUIINFO"/> che contiene le informazioni.</param>
        /// <param name="FileMUIInfoSize">Dimensione del buffer puntato da <paramref name="FileMUIInfoStructurePointer"/>.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Il buffer puntato da <paramref name="FileMUIInfoStructurePointer"/> può essere più grande della dimensione della struttura <see cref="FILEMUIINFO"/>.<br/>
        /// Il parametro può essere <see cref="IntPtr.Zero"/>, in tal caso la funzione recupera la dimensione necessario nel parametro <paramref name="FileMUIInfoSize"/>.<br/><br/>
        /// <paramref name="FileMUIInfoSize"/> può essere impostato a 0, per recuperare la dimensione necessaria del buffer, in tal caso <paramref name="FileMUIInfoStructurePointer"/> deve essere <see cref="IntPtr.Zero"/>.<br/>
        /// Il campo <see cref="FILEMUIINFO.Size"/> deve essere impostato allo stesso valore a cui è impostato <paramref name="FileMUIInfoSize"/>.<br/><br/>
        /// Il campo <see cref="FILEMUIINFO.Version"/> deve essere impostato a <see cref="MUI_FILEINFO_VERSION"/>.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetFileMUIInfo", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetFileMUIInfo(MUIQueryType Flags, PCWSTR FilePath, IntPtr FileMUIInfoStructurePointer, ref DWORD FileMUIInfoSize);

        /// <summary>
        /// Recupera i percorsi a tutti i file di risorse lingua associati al file di lingua neutrale fornito.
        /// </summary>
        /// <param name="Flags">Formato e opzioni di filtraggio della ricerca.</param>
        /// <param name="FilePath">Percorso del file.</param>
        /// <param name="Language">In input ID o nome della lingua della quale cercare i file di risorse, in output la lingua le file di risorse specifico trovato.</param>
        /// <param name="LanguageBufferSize">Dimensione, in caratteri, di <paramref name="Language"/>.</param>
        /// <param name="FileMUIPath">Percorso al file di lingua specifico.</param>
        /// <param name="FileMUIPathSize">Dimensione, in caratteri, di <paramref name="FileMUIPath"/>, in output indica la dimensione del percorso recuperato.</param>
        /// <param name="Enumerator">Variabile di enumerazione.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Per <paramref name="Flags"/> è possibile usare i valori dell'enumerazione <see cref="LanguageFormat"/> per specificare il formato della lingua indicata da <paramref name="Language"/>.<br/>
        /// Per specificare le opzioni di filtraggio è possibile usare i valori dell'enumerazione <see cref="ResourceFileLocationFilter"/>.<br/>
        /// E' possibile inoltre utilizzare i valori dell'enumerazione <see cref="ResourceFileNaming"/> per indicare se inserire o meno l'estensione .mui al nome del file in <paramref name="FilePath"/>.<br/><br/>
        /// <paramref name="Enumerator"/> deve essere impostato a 0 e il suo valore non deve essere modificato.<br/><br/>
        /// Se <paramref name="Flags"/> specifica <see cref="LanguageFormat.MUI_LANGUAGE_ID"/>, <paramref name="Language"/> deve essere un identificatore esadecimale (escluso 0x), il valore restituito avrà lo stesso formato.<br/><br/>
        /// Per ricevere informazioni su tutti i linguaggi questa funzione deve essere chiamata più volte fino a che non restituisce false, <paramref name="Language"/> deve essere resettato prima di ogni chiamata.<br/><br/>
        /// In caso di errore la funzione può restituire i seguenti codici:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (la dimensione di uno dei buffer è insufficiente o il buffer è nullo).<br/>
        /// <see cref="ERROR_NO_MORE_FILES"/> (non ci sono più file da elaborare).</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetFileMUIPath", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetFileMUIPath(DWORD Flags, PCWSTR FilePath, StringBuilder Language, ref ULONG LanguageBufferSize, StringBuilder FileMUIPath, ref ULONG FileMUIPathSize, ref ULONGLONG Enumerator);

        /// <summary>
        /// Recupera le lingue preferite del processo.
        /// </summary>
        /// <param name="Flags">Formato della lingua.</param>
        /// <param name="LanguagesCount">Numero di linguaggi recuperati.</param>
        /// <param name="LanguagesBuffer">Puntatore a buffer che contiene una lista di stringhe separate da caratteri nulli, la lista termina con un carattere nullo.</param>
        /// <param name="LanguagesBufferSize">Dimensione, in caratteri, di <paramref name="LanguagesBuffer"/>, in output indica la dimensione del buffer recuperato.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>In caso di errore la funzione può restituire i seguenti codici:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (la dimensione del buffer è troppo piccola oppure è nullo).<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (almeno uno dei parametri non è valido).<br/><br/>
        /// Se la lista delle lingue preferite è vuota o le lingue specificate per il processo non sono valide, <paramref name="LanguagesBuffer"/> è vuoto e <paramref name="LanguagesBufferSize"/> ha valore 2.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetProcessPreferredUILanguages", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetProcessPreferredUILanguages(LanguageFormat Flags, out ULONG LanguagesCount, IntPtr LanguagesBuffer, ref ULONG LanguagesBufferSize);

        /// <summary>
        /// Recupera le lingue preferite del sistema.
        /// </summary>
        /// <param name="Flags">Formato della lingua e opzioni di filtraggio.</param>
        /// <param name="LanguagesCount">Numero di linguaggi recuperati.</param>
        /// <param name="LanguagesBuffer">Puntatore a buffer che contiene una lista di stringhe separate da caratteri nulli, la lista termina con un carattere nullo.</param>
        /// <param name="LanguagesBufferSize">Dimensione, in caratteri, di <paramref name="LanguagesBuffer"/>, in output indica la dimensione del buffer recuperato.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>In caso di errore la funzione può restituire i seguenti codici:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (la dimensione del buffer è troppo piccola oppure è nullo).<br/><br/>
        /// In caso di errore <paramref name="LanguagesBuffer"/> e <paramref name="LanguagesCount"/> non sono definiti.<br/><br/>
        /// Se <paramref name="Flags"/> include <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/> la lista potrebbe includere:<br/><br/>
        /// Linguaggi non installati nel sistema<br/>
        /// Voci duplicate<br/>
        /// Una stringa vuota<br/><br/>
        /// Se <paramref name="Flags"/> include <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/> e la lista è vuota, <paramref name="LanguagesBuffer"/> contiene due caratteri nulli, <paramref name="LanguagesCount"/> ha valore 0 e <paramref name="LanguagesBufferSize"/> ha valore 2.<br/><br/>
        /// Se <paramref name="Flags"/> non include <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/> la lista include:<br/><br/>
        /// Solo lingue che rappresentano una località NLS valida<br/>
        /// Solo lingue installate nel sistema<br/>
        /// Una voce per ogni lingua, senza duplicati</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetSystemPreferredUILanguages", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetSystemPreferredUILanguages(uint Flags, out ULONG LanguagesCount, IntPtr LanguagesBuffer, ref ULONG LanguagesBufferSize);

        /// <summary>
        /// Recupera le lingue preferite del thread.
        /// </summary>
        /// <param name="Flags">Formato della lingua e opzioni di filtraggio.</param>
        /// <param name="LanguagesCount">Numero di linguaggi recuperati.</param>
        /// <param name="LanguagesBuffer">Puntatore a buffer che contiene una lista di stringhe separate da caratteri nulli, la lista termina con un carattere nullo.</param>
        /// <param name="LanguagesBufferSize">Dimensione, in caratteri, di <paramref name="LanguagesBuffer"/>, in output indica la dimensione del buffer recuperato.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Per <paramref name="Flags"/> è possibile usare i valori dell'enumerazione <see cref="LanguageFormat"/> per specificare il formato della lingua.<br/>
        /// Per specificare le opzioni di filtraggio è possibile usare i valori dell'enumerazione <see cref="ThreadLanguageFilter"/>.<br/><br/>
        /// Impostando <paramref name="LanguagesBuffer"/> a <see cref="IntPtr.Zero"/> e <paramref name="LanguagesBufferSize"/> a 0, quest'ultimo parametro conterrà la dimensione necessaria per <paramref name="LanguagesBuffer"/>.<br/><br/>
        /// In caso di errore la funzione può restituire i seguenti codici:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (la dimensione del buffer è troppo piccola oppure è nullo).<br/><br/>
        /// In caso di errore <paramref name="LanguagesBuffer"/> e <paramref name="LanguagesCount"/> non sono definiti.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetThreadPreferredUILanguages", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetThreadPreferredUILanguages(DWORD Flags, out ULONG LanguagesCount, IntPtr LanguagesBuffer, ref ULONG LanguagesBufferSize);

        /// <summary>
        /// Recupera informazioni su una lingua dell'interfaccia utente installata.
        /// </summary>
        /// <param name="Flags">Formato della lingua.</param>
        /// <param name="Language">Lingue di cui recuperare le informazioni, questo parametro è una lista separata da caratteri nulli, la lista termina con un carattere nullo.</param>
        /// <param name="FallbackLanguages">Buffer che contiene la lista di lingue di fallback, il formato è uguale a quello di <paramref name="Language"/>.</param>
        /// <param name="FallbacklanguagesSize">Dimensione, in caratteri, di <paramref name="FallbackLanguages"/>.</param>
        /// <param name="Attributes">Attributi della lingua indicata da <paramref name="Language"/>.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>In caso di errore la funzione può restituire i seguenti codici di errore, tra gli altri:<br/><br/>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/> (la dimensione del buffer è troppo piccola o è nullo).<br/>
        /// <see cref="ERROR_INVALID_PARAMETER"/> (uno o più dei parametri non è valido).<br/><br/>
        /// Se la funzione restituisce qualunque altro codice di errore, <paramref name="FallbackLanguages"/> e <paramref name="Attributes"/> non sono definiti.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetUILanguageInfo", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetUILanguageInfo(LanguageFormat Flags, string Language, IntPtr FallbackLanguages, ref DWORD FallbacklanguagesSize, out LanguageAttributes Attributes);

        /// <summary>
        /// Recupera informazioni sull'impostazione della lingua di visualizzazione.
        /// </summary>
        /// <param name="Flags">Formato della lingua.</param>
        /// <param name="LanguagesCount">Numero di lingue.</param>
        /// <param name="LanguagesBuffer">Buffer che contiene una lista di stringhe separate da caratteri null, la lista termina con un carattere nullo.</param>
        /// <param name="LanguagesBufferSize">Dimensione, in caratteri, di <paramref name="LanguagesBuffer"/>, in output il paraemetro contiene la dimensione recuperata del buffer.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>In caso di errore la funzione può restituire il codice <see cref="ERROR_INSUFFICIENT_BUFFER"/> tra gli altri, questo codice viene restituito se il buffer è troppo piccolo o nullo.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "GetUserPreferredUILanguages", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetUserPreferredUILanguages(LanguageFormat Flags, out ULONG LanguagesCount, IntPtr LanguagesBuffer, ref ULONG LanguagesBufferSize);

        /// <summary>
        /// Imposta le lingue preferite per il processo.
        /// </summary>
        /// <param name="Flags">Formato della lingua.</param>
        /// <param name="Languages">Lista di lingue in ordine decrescente di preferenza da impostare, massimo 5.</param>
        /// <param name="LanguagesCount">Numero di lingue impostate nella lista di lingue preferite del processo.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>La lista in <paramref name="Languages"/> deve terminare con un carattere nullo, ogni elemento di esso deve essere separato da un carattere nullo.<br/><br/>
        /// In caso di errore, la funzione può restituire <see cref="ERROR_INVALID_PARAMETER"/> nel caso i parametri non siano validi.<br/><br/>
        /// Se <paramref name="Languages"/> è nullo, la lista di lingue preferite per il processo viene svuotata.<br/><br/>
        /// Se le lingue indicate non sono valide, <paramref name="LanguagesCount"/> viene impostato a 0 in output.</remarks>
        [DllImport("Kernel32.dll", EntryPoint = "SetProcessPreferredUILanguages", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetProcessPreferredUILanguages(LanguageFormat Flags, string? Languages, out ULONG LanguagesCount);

        /// <summary>
        /// Imposta le lingue preferite per il thread.
        /// </summary>
        /// <param name="Flags">Opzioni di formato e di filtraggio delle lingue da impostare.</param>
        /// <param name="Languages">Lista di stringhe separate da caratteri nulli che termina con un carattere nullo.</param>
        /// <param name="LanguagesCount">Numero di lingue impostate nella lista.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Per specificare il formato in <paramref name="Flags"/> è possibile usare i valori dell'enumerazione <see cref="LanguageFormat"/>.<br/>
        /// Per specificare le opzioni di filtraggio è possibile usare i valori dell'enumerazione <see cref="ThreadLanguageSetFilter"/>.<br/>
        /// Se <paramref name="Flags"/> contiene uno qualunque dei valori dell'enumerazione <see cref="ThreadLanguageSetFilter"/>, <paramref name="Languages"/> e <paramref name="LanguagesCount"/> devono essere nulli.<br/><br/>
        /// Si possono impostare massimo 5 lingue in ordine di preferenza, se <paramref name="Languages"/> specifica più lingue del massimo verranno impostate sono le prime 5 valide.<br/><br/>
        /// </remarks>
        [DllImport("Kernel32.dll", EntryPoint = "SetThreadPreferredUILanguages", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL SetThreadPreferredUILanguages(DWORD Flags, string? Languages, IntPtr LanguagesCount);
    }
}
