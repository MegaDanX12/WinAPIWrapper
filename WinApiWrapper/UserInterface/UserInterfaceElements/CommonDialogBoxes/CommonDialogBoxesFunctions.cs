using System.Text;
using static WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes.CommonDialogBoxesEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes.CommonDialogBoxesStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes
{
    /// <summary>
    /// Funzioni comuni delle finestre di dialogo.
    /// </summary>
    internal static class CommonDialogBoxesFunctions
    {
        /// <summary>
        /// Crea una finestra di dialogo di selezione colori che permette all'utente di selezionare un colore.
        /// </summary>
        /// <param name="ColorData">Struttura <see cref="CHOOSECOLOR"/> che contiene informazioni usate per inizializzare la finestra di dialogo.</param>
        /// <returns>Diverso da 0 se l'utente ha premuto il pulsante OK, 0 se l'utente annulla l'operazione.</returns>
        /// <remarks>Il parametro <paramref name="ColorData"/> conterrà il colore scelto dall'utente quando la funzione restituisce.<br/><br/>
        /// Se l'utente ha annullato l'operazione, la funzione <see cref="GetCommonDialogError"/> restituisce il codice di errore più specifico.<br/>
        /// I valori restituiti da tale funzione si trovano nell'enumerazione <see cref="DialogBoxErrorCode"/>.<br/><br/>
        /// I valori possibili sono:<br/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_DIALOGFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_FINDRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMLOCKFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_INITIALIZATION"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHINSTANCE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHOOK"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOTEMPLATE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADSTRFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_STRUCTSIZE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMALLOCFAILURE"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "ChooseColorW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL ChooseColor(ref CHOOSECOLOR ColorData);

        /// <summary>
        /// Crea una finestra di dialogo di selezione font che permette all'utente di selezionare gli attributi di un font logico.
        /// </summary>
        /// <param name="FontData">Struttura <see cref="CHOOSEFONT"/> che contiene informazioni per inizializzare la finestra di dialogo.</param>
        /// <returns>Diverso da 0 se l'utente ha premuto il pulsante OK, 0 se l'utente annulla l'operazione.</returns>
        /// <remarks>Il parametro <paramref name="FontData"/> conterrà il colore scelto dall'utente quando la funzione restituisce.<br/><br/>
        /// Se l'utente ha annullato l'operazione, la funzione <see cref="GetCommonDialogError"/> restituisce il codice di errore più specifico.<br/>
        /// I valori restituiti da tale funzione si trovano nell'enumerazione <see cref="DialogBoxErrorCode"/>.<br/><br/>
        /// I valori possibili sono:<br/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_DIALOGFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_FINDRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMLOCKFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_INITIALIZATION"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHINSTANCE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOHOOK"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_NOTEMPLATE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOADSTRFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_STRUCTSIZE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_MEMALLOCFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CDERR_LOCKRESFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.CFERR_MAXLESSTHANMIN"/><br/>
        /// <see cref="DialogBoxErrorCode.CFERR_NOFONTS"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "ChooseFont", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL ChooseFont(ref CHOOSEFONT FontData);

        /// <summary>
        /// Restituisce l'errore più recente durante l'esecuzione di una funzione delle finestre di dialogo comuni.
        /// </summary>
        /// <returns>Codice di errore.</returns>
        [DllImport("Comdlg32.dll", EntryPoint = "CommDlgExtendedError", SetLastError = true)]
        internal static extern DialogBoxErrorCode GetCommonDialogError();

        /// <summary>
        /// Crea una finestra di dialogo "Trova e sostituisci" che permette all'utente di specificare una stringa da cercare e le opzioni da usare per la ricerca di testo in un documento.
        /// </summary>
        /// <param name="DialogBoxData">Struttura <see cref="FINDREPLACE"/> che contiene le informazioni usate per inizializzare la finestra di dialogo.</param>
        /// <returns>Se l'operazione è riuscita, la funzione restituisce un handle alla finestra di dialogo, in caso contrario restituisce <see cref="IntPtr.Zero"/>.</returns>
        /// <remarks>La struttura a cui il parametro <paramref name="DialogBoxData"/> punta contiene informazioni sull'input dell'utente.<br/>
        /// Se l'operazione non riesce, la funzione <see cref="GetCommonDialogError"/> restituisce uno dei seguenti codici di errore:<br/><br/>
        /// <see cref="DialogBoxErrorCode.FRERR_BUFFERLENGTHZERO"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "FindTextW", SetLastError = true)]
        internal static extern HWND FindText(ref FINDREPLACE DialogBoxData);

        /// <summary>
        /// Recupera il nome di un file.
        /// </summary>
        /// <param name="FileName">Nome e posizione di un file.</param>
        /// <param name="FileNameBuffer">Buffer che riceve il nome del file.</param>
        /// <param name="BufferSize">Lunghezza, in caratteri, di <paramref name="FileNameBuffer"/>.</param>
        /// <returns>0 se l'operazione è riuscita, un numero negativo in caso contrario.</returns>
        /// <remarks>Se il nome del file non è valido, il valore restituito non è definito.<br/><br/>
        /// Se <paramref name="FileNameBuffer"/> è troppo piccolo, il valore restituito è un numero positivo che specifica la dimensione necessaria, in caratteri, incluso il carattere nullo finale.<br/><br/>
        /// Questa funzione restituisce la stringa che il sistema usa per visualizzare il nome del file all'utente.</remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "GetFileTitleW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern short GetFileTitle(string FileName, StringBuilder FileNameBuffer, WORD BufferSize);

        /// <summary>
        /// Crea un finestra di dialogo "Imposta pagina" che permette all'utente di specificare gli attributi di una pagina stampata.
        /// </summary>
        /// <param name="DialogData">Struttura <see cref="PAGESETUPDLG"/> con i dati necessari a inizializzare la finestra di dialogo.</param>
        /// <returns>true se l'utente clicca OK, 0 se l'utente clicca Annulla o in caso di errore.</returns>
        /// <remarks>Quando questa funzione restituisce, il parametro <paramref name="DialogData"/> contiene informazioni sulla selezione dell'utente.<br/>
        /// Se si è verificato un errore, la funzione <see cref="GetCommonDialogError"/> restituisce uno dei seguenti codici di errore:<br/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_CREATEICFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_DEFAULTDIFFERENT"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_DNDMMISMATCH"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_GETDEVMODEFAIL"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_INITFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_LOADDRVFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_NODEFAULTPRN"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_NODEVICES"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_PARSEFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_PRINTERNOTFOUND"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_RETDEFFAILURE"/><br/>
        /// <see cref="DialogBoxErrorCode.PDERR_SETUPFAILURE"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "PageSetupDlg", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool OpenPageSetup(ref PAGESETUPDLG DialogData);

        /// <summary>
        /// Visualizza una finestra di dialogo "Stampa" che permette all'utente di specificare le proprietà di un lavoro di stampa.
        /// </summary>
        /// <param name="DialogData">Puntatore a struttura <see cref="PRINTDLG"/> che contiene informazioni di inizializzazione della finestra di dialogo.</param>
        /// <returns><see cref="S_OK"/> se l'operazione è riuscita, uno codice di errore COM in caso contrario.</returns>
        /// <remarks>Tra i possibili codici di errore ci sono i seguenti:<br/><br/>
        /// <see cref="E_OUTOFMEMORY"/> (memoria insufficiente)<br/>
        /// <see cref="E_INVALIDARG"/> (parametro non valido)<br/>
        /// <see cref="E_POINTER"/> (puntatore non valido)<br/>
        /// <see cref="E_HANDLE"/> (handle non valido)<br/>
        /// <see cref="E_FAIL"/> (errore non specificato)<br/><br/>
        /// I valori di <see cref="PRINTDLG.DevModeMemoryObject"/> e <see cref="PRINTDLG.DevNamesMemoryObject"/> di <paramref name="DialogData"/> possono cambiare dopo il completamento dell'esecuzione della funzione.<br/>
        /// Assicurarsi di liberare la memoria allocata per questi campi.<br/><br/>
        /// Se <see cref="PRINTDLG.InitializationOptions"/> include <see cref="PrintDialogInitializationOptions.PD_RETURNDC"/> ma non include <see cref="PrintDialogInitializationOptions.PD_USEDEVMODECOPIESANDCOLLATE"/>, la funzione potrebbe restituire un valore non corretto per il numero di copie.<br/>
        /// Per evitare questo, chiamare questa funzione sempre con le opzioni <see cref="PrintDialogInitializationOptions.PD_RETURNDC"/> e <see cref="PrintDialogInitializationOptions.PD_USEDEVMODECOPIESANDCOLLATE"/> incluse in <see cref="PRINTDLG.InitializationOptions"/></remarks>
        [DllImport("Comdlg32.dll", EntryPoint = "PrintDlgEx", SetLastError = true)]
        internal static extern HRESULT ShowPrintDialog(IntPtr DialogData);
    }
}