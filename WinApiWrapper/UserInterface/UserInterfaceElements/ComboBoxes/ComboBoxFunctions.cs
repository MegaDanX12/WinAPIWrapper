using System.Text;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes
{
    /// <summary>
    /// Funzioni relative ai ComboBox.
    /// </summary>
    internal static class ComboBoxFunctions
    {
        /// <summary>
        /// Sotituisce i contenuti di un ComboBox con i nomi delle sottodirectory e dei file nella directory specificata.
        /// </summary>
        /// <param name="DialogHandle">Handle alla finestra di dialogo che contiene il ComboBox.</param>
        /// <param name="PathData">Percorso della cartella.</param>
        /// <param name="ComboBoxID">ID del ComboBox.</param>
        /// <param name="StaticControlID">ID di un controllo statico che visualizzerà il disco e la directory corrente.</param>
        /// <param name="FileAttributes">Attributi dei file o delle directory da includere nel ComboBox.</param>
        /// <returns>Diverso da 0 se l'operazione è riuscita, 0 in caso contrario.</returns>
        /// <remarks><paramref name="PathData"/> può contenere un percorso completo, un percorso relativo o un nome file.<br/>
        /// Il percorso assoluto può iniziare con una lettera di unità o con un nome UNC.<br/><br/>
        /// La funzione divide <paramref name="PathData"/> in una directory e in un nome file, vengono ricercati all'interno della directory i file il cui nome corrisponde a quello specificato.<br/>
        /// Se <paramref name="PathData"/> contiene un nome file, esso deve includere almeno una wildcard (? oppure *), se il parametro non contiene un nome file, la funzione si comporta come se fosse stato specificato "*" come nome file.<br/>
        /// Se <paramref name="PathData"/> non specifica una directory, la ricerca avviene nella directory corrente.<br/><br/>
        /// Tutti i file nella directory specificata il cui nome corrisponde a quello specificato e che hanno gli attributi specificati da <paramref name="FileAttributes"/> sono aggiunti alla lista del ComboBox.<br/><br/>
        /// <paramref name="StaticControlID"/> può essere 0 se non è necessario mostrare il disco e la directory corrente.<br/><br/>
        /// Se <paramref name="FileAttributes"/> include <see cref="FileDirectoryAttributes.DDL_DIRECTORY"/> e <paramref name="PathData"/> specifica una directory di primo livello, il ComboBox include sempre una voce ".." per la directory radice.<br/>
        /// Questo avviene anche se la directory radice è nascosta o di sistema e <paramref name="FileAttributes"/> non specifica né <see cref="FileDirectoryAttributes.DDL_HIDDEN"/> né <see cref="FileDirectoryAttributes.DDL_SYSTEM"/>.<br/><br/>
        /// Questa funzione invia i messaggi <see cref="ComboBoxMessages.CB_RESETCONTENT"/> e <see cref="ComboBoxMessages.CB_DIR"/> al controllo.</remarks>
        [DllImport("User32.dll", EntryPoint = "DlgDirListComboBoxW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int AddFileListToComboBox(HWND DialogHandle, LPWSTR PathData, int ComboBoxID, int StaticControlID, FileDirectoryAttributes FileAttributes);

        /// <summary>
        /// Recupera la selezione corrente da un ComboBox riempito tramite la funzione <see cref="AddFileListToComboBox"/>.
        /// </summary>
        /// <param name="DialogHandle">Handle alla finestra di dialogo che contiene il ComboBox.</param>
        /// <param name="SelectedPath">Buffer che conterrà il percorso selezionato.</param>
        /// <param name="PathLength">Lunghezza, in caratteri, di <paramref name="SelectedPath"/>.</param>
        /// <param name="ComboBoxID">ID del ComboBox.</param>
        /// <returns>Se la selezione corrente è un nome di directory, il valore restituito è diverso da 0, in caso contrario il valore restituito è 0.</returns>
        /// <remarks>Se la selezione corrente specifica un nome di directory o una lettera di unità, la funzione rimuove le parentesi quadre così che il nome o la lettera siano pronti per essere inseriti in un nuovo percorso o nome file.<br/>
        /// Se nulla è stato selezionato, i contenuti di <paramref name="SelectedPath"/> non cambiano.<br/><br/>
        /// La funzione restituisce al massimo solo un nome file.<br/><br/>
        /// Se la stringa è lunga quanto o di più del buffer, quest'ultimo conterrà la stringa troncata con un carattere nullo finale.<br/><br/>
        /// Questa funzione invia i messaggi <see cref="ComboBoxMessages.CB_GETCURSEL"/> e <see cref="ComboBoxMessages.CB_GETLBTEXT"/> al controllo.</remarks>
        [DllImport("User32.dll", EntryPoint = "DlgDirSelectComboBoxExW", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCurrentSelection(HWND DialogHandle, StringBuilder SelectedPath, int PathLength, int ComboBoxID);

        /// <summary>
        /// Recupera informazioni su un ComboBox.
        /// </summary>
        /// <param name="ComboBoxHandle">Handle al ComboBox.</param>
        /// <param name="Info">Struttura <see cref="COMBOBOXINFO"/> che riceve le informazioni.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Il campo <see cref="COMBOBOXINFO.Size"/> deve essere impostato prima della chiamata alla funzione.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetComboBoxInfo", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetComboBoxInfo(HWND ComboBoxHandle, ref COMBOBOXINFO Info);
    }
}