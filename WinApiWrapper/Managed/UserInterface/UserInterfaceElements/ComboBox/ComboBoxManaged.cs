using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxConstants;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxMessages;
using static WinApiWrapper.UserInterface.UserInterfaceElements.ComboBoxes.ComboBoxFunctions;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ComboBox.Enumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageFunctions;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using System.ComponentModel;
using System.Text;
using WinApiWrapper.Managed.General;
using static WinApiWrapper.General.GeneralStructures;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ComboBox
{
    /// <summary>
    /// Metodi per l'interazione con i ComboBox.
    /// </summary>
    public static class ComboBoxManaged
    {
        /// <summary>
        /// Aggiunge i nomi dei file e delle sottodirectory presenti in una directory a un ComboBox.
        /// </summary>
        /// <param name="DialogInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra di dialogo che contiene il ComboBox.</param>
        /// <param name="Path">Percorso directory.</param>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al ComboBox.</param>
        /// <param name="StaticControlInfo">Istanza di <see cref="WindowInfo"/> associata a un controllo statico nella finestra di dialogo.</param>
        /// <param name="Attributes">Attributi dei file e delle directory da includere nel ComboBox.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <remarks><paramref name="Path"/> può contenere un percorso assoluto, relativo o un nome file.<br/>
        /// Un percorso assoluto può iniziare con una lettera di unità oppure con nome UNC.<br/><br/>
        /// Se <paramref name="Path"/> non specifica una directory, la ricerca viene eseguita nella directory corrente.<br/><br/>
        /// Se <paramref name="Path"/> include un nome file, esso deve contenere wildcard (? oppure *), se la stringa non include un nome file, il metodo si comporta come se l'asterisco (*) fosse stato specificato come nome file.<br/><br/>
        /// <paramref name="StaticControlInfo"/> rappresenta un controllo il cui testo sarà impostato per visualizare il disco e la directory corrente, può essere nullo se non si vuole visualizzare tale informazione.<br/><br/>
        /// Se <paramref name="Attributes"/> non specifica <see cref="Enumerations.FileAttributes.OnlySpecifiedAttributes"/>, i file senza attributi particolari sono sempre inclusi.</remarks>
        public static void ListFileAndSubdirectories(WindowInfo DialogInfo, string Path, ComboBoxInfo ComboBoxInfo, WindowInfo? StaticControlInfo, Enumerations.FileAttributes Attributes)
        {
            if (DialogInfo is null || ComboBoxInfo is null || string.IsNullOrWhiteSpace(Path))
            {
                throw new ArgumentNullException(string.Empty, "DialogInfo and ComboBoxInfo cannot be null.");
            }
            if (!ComboBoxInfo.ID.HasValue)
            {
                throw new InvalidOperationException("Unable to retrieve required info.");
            }
            bool Result;
            if (StaticControlInfo is null)
            {
                Result = Convert.ToBoolean(AddFileListToComboBox(DialogInfo.Handle, Path, ComboBoxInfo.ID!.Value, 0, (FileDirectoryAttributes)Attributes));
                if (!Result)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                if (StaticControlInfo.ID.HasValue)
                {
                    Result = Convert.ToBoolean(AddFileListToComboBox(DialogInfo.Handle, Path, ComboBoxInfo.ID!.Value, StaticControlInfo.ID.Value, (FileDirectoryAttributes)Attributes));
                    if (!Result)
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    Result = Convert.ToBoolean(AddFileListToComboBox(DialogInfo.Handle, Path, ComboBoxInfo.ID!.Value, 0, (FileDirectoryAttributes)Attributes));
                    if (!Result)
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
            }
            
        }

        /// <summary>
        /// Recupera la selezione corrente di un ComboBox.
        /// </summary>
        /// <param name="DialogInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra di dialogo che contiene il ComboBox.</param>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al ComboBox.</param>
        /// <returns>La selezione corrente.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string GetComboBoxCurrentSelection(WindowInfo DialogInfo, ComboBoxInfo ComboBoxInfo)
        {
            if (DialogInfo is null || ComboBoxInfo is null)
            {
                throw new ArgumentNullException(string.Empty, "DialogInfo e ComboBoxInfo cannot be null.");
            }
            if (!ComboBoxInfo.ID.HasValue)
            {
                throw new InvalidOperationException("Unable to retrieve required info.");
            }
            StringBuilder Selection = new(MAX_PATH);
            if (!GetCurrentSelection(DialogInfo.Handle, Selection, Selection.Capacity, ComboBoxInfo.ID!.Value))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                return Selection.ToString();
            }
        }

        /// <summary>
        /// Aggiunge un elemento a un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="StringToAdd">Stringa da aggiungere.</param>
        /// <returns>Indice basato su zero del nuovo elemento.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static int AddElement(ComboBoxInfo ComboBoxInfo, string StringToAdd)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            LPARAM StringPointer = Marshal.StringToHGlobalUni(StringToAdd);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_ADDSTRING, IntPtr.Zero, StringPointer);
            Marshal.FreeHGlobal(StringPointer);
            return Result == CB_ERR || Result == CB_ERRSPACE ? throw new Exception("Unable to add element.") : Result.ToInt32();
        }

        /// <summary>
        /// Elimina un elemento da un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associato al controllo.</param>
        /// <param name="ElementIndex">Indice dell'elemento da eliminare.</param>
        /// <param name="StringToRemove">Stringa da rimuovere.</param>
        /// <returns>Numero di elementi nel ComboBox dopo l'eliminazione.</returns>
        /// <remarks>Almeno uno tra <paramref name="ElementIndex"/> e <paramref name="StringToRemove"/> devono avere un valore valido.<br/>
        /// Se <paramref name="ElementIndex"/> ha un valore valido, <paramref name="StringToRemove"/> verrà ignorato.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static int DeleteElement(ComboBoxInfo ComboBoxInfo, int? ElementIndex, string? StringToRemove)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ElementIndex is null && string.IsNullOrWhiteSpace(StringToRemove))
            {
                throw new ArgumentNullException(string.Empty, "Either ElementIndex or StringToRemove must have a valid value.");
            }
            if (ElementIndex is not null)
            {
                if (ElementIndex.Value < 0)
                {
                    throw new ArgumentException("Invalid index.", nameof(ElementIndex));
                }
            }
            LRESULT Result;
            if (ElementIndex is not null)
            {
                Result = SendMessage(ComboBoxInfo.Handle, CB_DELETESTRING, new(ElementIndex.Value), IntPtr.Zero);
                return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to delete element.");
            }
            else
            {
                LPARAM StringPointer = Marshal.StringToHGlobalUni(StringToRemove);
                Result = SendMessage(ComboBoxInfo.Handle, CB_FINDSTRINGEXACT, new(-1), StringPointer);
                Marshal.FreeHGlobal(StringPointer);
                if (Result != CB_ERR)
                {
                    Result = SendMessage(ComboBoxInfo.Handle, CB_DELETESTRING, Result, IntPtr.Zero);
                    return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to delete element.");
                }
                else
                {
                    throw new Exception("Unable to find element.");
                }
            }
        }

        /// <summary>
        /// Trova una stringa in un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="SearchString">Stringa che contiene i caratteri da cercare. </param>
        /// <param name="ExactMatch">Indica se la stringa deve essere uguale al contenuto di <paramref name="SearchString"/>.</param>
        /// <param name="SearchStartIndex">Indice di partenza della ricerca.</param>
        /// <returns>Indice, basato su zero, della stringa trovata.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static int FindString(ComboBoxInfo ComboBoxInfo, string SearchString, bool ExactMatch = false, int SearchStartIndex = -1)
        {
            if (ComboBoxInfo is null || string.IsNullOrWhiteSpace(SearchString))
            {
                throw new ArgumentNullException(string.Empty, "ComboBoxInfo and StringToSearch cannot be null.");
            }
            LPARAM StringPointer;
            LRESULT Result;
            if (!ExactMatch)
            {
                StringPointer = Marshal.StringToHGlobalUni(SearchString);
                if (SearchStartIndex is not >= -1)
                {
                    SearchStartIndex = -1;
                }
                Result = SendMessage(ComboBoxInfo.Handle, CB_FINDSTRING, new(SearchStartIndex), StringPointer);
                Marshal.FreeHGlobal(StringPointer);
                return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to find string.");
            }
            else
            {
                StringPointer = Marshal.StringToHGlobalUni(SearchString);
                if (SearchStartIndex is not >= -1)
                {
                    SearchStartIndex = -1;
                }
                Result = SendMessage(ComboBoxInfo.Handle, CB_FINDSTRING, new(SearchStartIndex), StringPointer);
                Marshal.FreeHGlobal(StringPointer);
                return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to find string.");
            }
        }

        /// <summary>
        /// Recupera il conteggio di elementi presenti in un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>Il numero di elementi nel ComboBox.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static int GetItemsCount(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
            return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to get items count.");
        }

        /// <summary>
        /// Recupera il testo predefinito del controllo di modifica di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="TextLength">Lunghezza, in caratteri, del testo.</param>
        /// <returns>Il testo predefinito.</returns>
        /// <remarks>Se non c'è testo predefinito, viene restituita una stringa vuota.<br/><br/>
        /// Se il valore di <paramref name="TextLength"/> è troppo piccolo, la stringa restituita sarà troncata.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static string GetCueBanner(ComboBoxInfo ComboBoxInfo, int TextLength = 1024)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            IntPtr Buffer = Marshal.AllocHGlobal((TextLength * 2) + 2);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETCUEBANNER, Buffer, new(1024));
            if (Result.ToInt32() is 1)
            {
                string CueBannerText = Marshal.PtrToStringUni(Buffer, TextLength + 1)!;
                Marshal.FreeHGlobal(Buffer);
                return CueBannerText;
            }
            else if (Result.ToInt32() is not 0)
            {
                Marshal.FreeHGlobal(Buffer);
                throw new Exception("Unable to get the cue banner.");
            }
            else
            {
                Marshal.FreeHGlobal(Buffer);
                return string.Empty;
            }
        }

        /// <summary>
        /// Recupera l'indice dell'oggetto attualmente selezionato in un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>L'indice dell'oggetto selezionato, se esiste, altrimenti nullo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int? GetCurrentSelectionIndex(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
            return Result != CB_ERR ? Result.ToInt32() : null;
        }

        /// <summary>
        /// Recupera le coordinate dello schermo di un ComboBox aperto.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>Istanza di <see cref="Rectangle"/> che contiene le coordinate.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static Rectangle GetDroppedDownComboBoxScreenCoordinates(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            RECT Coordinates = new();
            LPARAM CoordinatesPointer = Marshal.AllocHGlobal(Marshal.SizeOf(Coordinates));
            Marshal.StructureToPtr(Coordinates, CoordinatesPointer, false);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETDROPPEDCONTROLRECT, IntPtr.Zero, CoordinatesPointer);
            if (Convert.ToBoolean(Result.ToInt32()))
            {
                Marshal.PtrToStructure(CoordinatesPointer, typeof(RECT));
                Marshal.FreeHGlobal(CoordinatesPointer);
                return new(Coordinates);
            }
            else
            {
                throw new Exception("Unable to retrieve the screen coordinates for the combobox in dropped down state.");
            }
        }

        /// <summary>
        /// Determina se il list box di un ComboBox è aperto.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>true se il list box è visibile, false altrimenti.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDroppedDown(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
            return Convert.ToBoolean(Result.ToInt32());
        }

        /// <summary>
        /// Recupera la larghezza minima permessa, in pixel, del list box di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>Larghezza minima permessa, in pixel.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static long GetMinimumAllowableWidth(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETDROPPEDWIDTH, IntPtr.Zero, IntPtr.Zero);
            return Result != CB_ERR ? Result.ToInt64() : throw new Exception("Unable to determine the minimum allowable width.");
        }

        /// <summary>
        /// Recupera la posizione di partenza e la posizione finale della selezione nel controllo di modifica in un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="OnlyStartIndex">Indica se recuperare solo la posizione di partenza.</param>
        /// <param name="OnlyEndIndex">Indica se recuperare solo la posizione finale.</param>
        /// <returns>Una tupla con i valori richiesti.</returns>
        /// <remarks>Il primo elemento della tupla è la posizione di partenza, il secondo è la posizione finale, uno dei due valori può essere nullo in base ai parametri <paramref name="OnlyStartIndex"/> e <paramref name="OnlyEndIndex"/>.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public static Tuple<int?, int?> GetEditControlSelectionIndexes(ComboBoxInfo ComboBoxInfo, bool OnlyStartIndex = false, bool OnlyEndIndex = false)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            GCHandle StartIndex;
            GCHandle EndIndex;
            if (OnlyStartIndex)
            {
                StartIndex = GCHandle.Alloc(0, GCHandleType.Pinned);
                _ = SendMessage(ComboBoxInfo.Handle, CB_GETEDITSEL, StartIndex.AddrOfPinnedObject(), IntPtr.Zero);
                Tuple<int?, int?> Values = new(Marshal.ReadInt32(StartIndex.AddrOfPinnedObject()), null);
                StartIndex.Free();
                return Values;
            }
            else if (OnlyEndIndex)
            {
                EndIndex = GCHandle.Alloc(0, GCHandleType.Pinned);
                _ = SendMessage(ComboBoxInfo.Handle, CB_GETEDITSEL, IntPtr.Zero, EndIndex.AddrOfPinnedObject());
                Tuple<int?, int?> Values = new(null, Marshal.ReadInt32(EndIndex.AddrOfPinnedObject()));
                EndIndex.Free();
                return Values;
            }
            else
            {
                StartIndex = GCHandle.Alloc(0, GCHandleType.Pinned);
                EndIndex = GCHandle.Alloc(0, GCHandleType.Pinned);
                _ = SendMessage(ComboBoxInfo.Handle, CB_GETEDITSEL, StartIndex.AddrOfPinnedObject(), EndIndex.AddrOfPinnedObject());
                Tuple<int?, int?> Values = new(Marshal.ReadInt32(StartIndex.AddrOfPinnedObject()), Marshal.ReadInt32(EndIndex.AddrOfPinnedObject()));
                StartIndex.Free();
                EndIndex.Free();
                return Values;
            }
        }

        /// <summary>
        /// Determina se l'interfaccia utente estesa è abilitata per un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>true se l'interfaccia utente estesa è abilitata, false altrimenti.</returns>
        /// <remarks>Per impostazione predefinita, il tasto F4 apre e chiude la lista, e la freccia verso il basso cambia la selezione corrente.<br/>
        /// Quando l'interfaccia utente estesa è abilitata, il tasto F4 è disabilitato e la freccia verso il basso apre la lista.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsExtendedUIEnabled(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            return Convert.ToBoolean(SendMessage(ComboBoxInfo.Handle, CB_GETEXTENDEDUI, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        /// Recupera la larghezza, in pixel, che il list box di un ComboBox può scorrere orizzontalmente.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>Larghezza, in pixel, che il list box può scorrere orizzontalmente.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static long GetScrollableWidth(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            return SendMessage(ComboBoxInfo.Handle, CB_GETHORIZONTALEXTENT, IntPtr.Zero, IntPtr.Zero).ToInt64();
        }

        /// <summary>
        /// Recupera i dati associati a un elemento nel ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata con il controllo.</param>
        /// <param name="ItemIndex">Indice dell'oggetto i cui dati vanno recuperati.</param>
        /// <returns>Se il controllo ha lo stile <see cref="ComboboxStyles.ContainsStrings"/> applicato, viene restituita la stringa, in caso contrario, viene restituito il valore <see cref="IntPtr"/> senza modifiche.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static string? GetItemData(ComboBoxInfo ComboBoxInfo, int ItemIndex)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ItemIndex < 0)
            {
                throw new ArgumentException("The parameter cannot be less than zero.", nameof(ItemIndex));
            }
            LRESULT Result;
            if (ComboBoxInfo.ComboBoxStyles is not null && ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.ContainsStrings))
            {
                Result = SendMessage(ComboBoxInfo.Handle, CB_GETLBTEXTLEN, new(ItemIndex), IntPtr.Zero);
                if (Result != CB_ERR)
                {
                    IntPtr StringBuffer = Marshal.AllocHGlobal((Result.ToInt32() * 2) + 2);
                    Result = SendMessage(ComboBoxInfo.Handle, CB_GETLBTEXT, new(ItemIndex), StringBuffer);
                    if (Result != CB_ERR)
                    {
                        string Item = Marshal.PtrToStringUni(StringBuffer, Result.ToInt32());
                        Marshal.FreeHGlobal(StringBuffer);
                        return Item;
                    }
                    else
                    {
                        Marshal.FreeHGlobal(StringBuffer);
                        throw new Exception("Unable to get string.");
                    }
                }
                else
                {
                    throw new Exception("Unable to get item data.");
                }
            }
            else
            {
                return null;
                /*Result = SendMessage(ComboBoxInfo.Handle, CB_GETITEMDATA, new(ItemIndex), IntPtr.Zero);
                return Result != CB_ERR ? (object)Result : throw new Exception("Unable to get item data.");*/
            }
        }

        /// <summary>
        /// Recupera l'altezza, in pixel, di un componente di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="ComboBoxComponent">Componente di cui recuperare l'altezza.</param>
        /// <returns>L'altezza del componente.</returns>
        /// <remarks>Per recuperare l'altezza del controllo di modifica, <paramref name="ComboBoxComponent"/> deve avere valore -1.<br/>
        /// Per recuperare l'altezza degli elementi della lista in un ComboBox senza lo stile <see cref="ComboboxStyles.OwnerDrawnVariableHeight"/> applicato, <paramref name="ComboBoxComponent"/> deve essere 0.<br/>
        /// Se tale stile è applicato, <paramref name="ComboBoxComponent"/> deve indicare l'indice dell'oggetto di cui recuperare l'altezza.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static int GetComboBoxComponentHeight(ComboBoxInfo ComboBoxInfo, int ComboBoxComponent)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxComponent is not >= -1)
            {
                throw new ArgumentException("The parameter value is invalid.", nameof(ComboBoxComponent));
            }
            WPARAM Component = new(ComboBoxComponent);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETITEMHEIGHT, Component, IntPtr.Zero);
            return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to retrieve component height.");
        }

        /// <summary>
        /// Recupera il numero minimo di elementi visibili nel dropdown di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>Il numero minimo di elementi visibili.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static int GetMinimumVisibleElementsCount(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null)
            {
                if (ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.ExactSize))
                {
                    throw new InvalidOperationException("This information cannot be obtained from a ComboBox with the current applied styles.");
                }
                else
                {
                    LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETMINVISIBLE, IntPtr.Zero, IntPtr.Zero);
                    return Result.ToInt32();
                }
            }
            else
            {
                LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_GETMINVISIBLE, IntPtr.Zero, IntPtr.Zero);
                return Result.ToInt32();
            }
        }

        /// <summary>
        /// Recupera l'indice del primo elemento attualemente visibile nella lista di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <returns>L'indice del primo elemento attualmente visibile.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetTopElementIndex(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            return SendMessage(ComboBoxInfo.Handle, CB_GETTOPINDEX, IntPtr.Zero, IntPtr.Zero).ToInt32();
        }

        /// <summary>
        /// Alloca memoria per l'inserimento di stringhe nella lista di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="ItemsCount">Numero di oggetti da aggiungere.</param>
        /// <param name="MemoryAmountBytes">Memoria da allocare, in byte.</param>
        /// <returns>Il numero di oggetti per cui la memoria è stata allocata.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        public static int AllocateMemory(ComboBoxInfo ComboBoxInfo, int ItemsCount, int MemoryAmountBytes)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ItemsCount < 0 || MemoryAmountBytes < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "ItemsCount and MemoryAmountBytes cannot be less than zero.");
            }
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_INITSTORAGE, new(ItemsCount), new(MemoryAmountBytes));
            return Result != CB_ERRSPACE ? Result.ToInt32() : throw new Exception("Unable to allocate memory.");
        }

        /// <summary>
        /// Inserisce un oggetto nella lista di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="StringToInsert">Stringa da inserire.</param>
        /// <param name="Index">Indice dove inserire la stringa.</param>
        /// <returns>Indice dove la stringa è stata inserita.</returns>
        /// <remarks><paramref name="Index"/> può avere valore -1, in questo caso la stringa viene inserita alla fine della lista.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        public static int InsertItem(ComboBoxInfo ComboBoxInfo, string StringToInsert, int Index)
        {
            if (ComboBoxInfo is null || string.IsNullOrWhiteSpace(StringToInsert))
            {
                throw new ArgumentNullException(string.Empty, "ComboBoxInfo and StringToInsert cannot be null.");
            }
            if (Index is not >= -1)
            {
                throw new ArgumentOutOfRangeException(nameof(Index), "The parameter cannot have a value lower than -1.");
            }
            WPARAM IndexValue = new(Index);
            LPARAM StringPointer = Marshal.StringToHGlobalUni(StringToInsert);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_INSERTSTRING, IndexValue, StringPointer);
            Marshal.FreeHGlobal(StringPointer);
            return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Unable to insert item.");
        }

        /// <summary>
        /// Limita la lunghezza del testo che l'utente può inserire nel controllo di modifica di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="CharCount">Numero di caratteri massimo.</param>
        /// <remarks>Se <paramref name="CharCount"/> è nullo, il numero massimo di caratteri è impostato a <see cref="int.MaxValue"/> - 1.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LimitTextLength(ComboBoxInfo ComboBoxInfo, int? CharCount)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (CharCount is < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(CharCount), "The character limit cannot be 0 or lower.");
            }
            WPARAM Count = IntPtr.Zero;
            if (CharCount.HasValue)
            {
                Count = new(CharCount.Value);
            }
            _ = SendMessage(ComboBoxInfo.Handle, CB_LIMITTEXT, Count, IntPtr.Zero);
        }

        /// <summary>
        /// Elimina tutti gli elementi da un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ResetComboBoxContent(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            _ = SendMessage(ComboBoxInfo.Handle, CB_RESETCONTENT, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Seleziona un oggetto nella lista di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="Chars">Caratteri iniziali della stringa da trovare.</param>
        /// <param name="StartIndex">Indica da cui iniziare la ricerca-</param>
        /// <returns>L'indice della stringa trovata.</returns>
        /// <remarks><paramref name="StartIndex"/> può essere nullo, in questo caso la ricerca inizia dal primo elemento.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        public static int SelectItem(ComboBoxInfo ComboBoxInfo, string Chars, int? StartIndex)
        {
            if (ComboBoxInfo is null || string.IsNullOrWhiteSpace(Chars))
            {
                throw new ArgumentNullException(string.Empty, "ComboBoxInfo and Chars cannot be null.");
            }
            if (StartIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(StartIndex), "The parameter value cannot be lower than 0.");
            }
            WPARAM StartIndexValue = new(-1);
            if (StartIndex.HasValue)
            {
                StartIndexValue = new(StartIndex.Value);
            }
            LPARAM StringPointer = Marshal.StringToHGlobalUni(Chars);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SELECTSTRING, StartIndexValue, StringPointer);
            Marshal.FreeHGlobal(StringPointer);
            return Result != CB_ERR ? Result.ToInt32() : throw new Exception("Item not found.");
        }

        /// <summary>
        /// Imposta il testo predefinito di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="Text">Testo predefinito.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetCueBanner(ComboBoxInfo ComboBoxInfo, string Text)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            LPARAM StringPointer;
            LRESULT Result;
            if (!string.IsNullOrWhiteSpace(Text))
            {
                StringPointer = Marshal.StringToHGlobalUni(Text);
                Result = SendMessage(ComboBoxInfo.Handle, CB_SETCUEBANNER, IntPtr.Zero, StringPointer);
                Marshal.FreeHGlobal(StringPointer);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Unable to set cue banner.");
                }
            }
            else
            {
                StringPointer = Marshal.AllocHGlobal(2);
                Marshal.WriteInt16(StringPointer, '\0');
                Result = SendMessage(ComboBoxInfo.Handle, CB_SETCUEBANNER, IntPtr.Zero, StringPointer);
                Marshal.FreeHGlobal(StringPointer);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Unable to set cue banner.");
                }
            }
        }

        /// <summary>
        /// Imposta l'elemento selezionato nel ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="Index">Indice dell'elemento da selezionare.</param>
        /// <param name="StringToSelect">Stringa da selezionare.</param>
        /// <remarks>Impostare <paramref name="Index"/> ha un valore di -1, annulla la selezione corrente.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetSelection(ComboBoxInfo ComboBoxInfo, int? Index, string? StringToSelect)
        {
            if (Index is null || string.IsNullOrWhiteSpace(StringToSelect))
            {
                throw new ArgumentNullException(string.Empty, "One of the parameters must have a valid value.");
            }
            if (Index is < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(Index), "Index cannot have a value lower than -1.");
            }
            if (Index is not null)
            {
                int ItemsCount = GetItemsCount(ComboBoxInfo);
                if (Index > ItemsCount - 1)
                {
                    throw new ArgumentException("Invalid index.", nameof(Index));
                }
                else
                {
                    WPARAM IndexValue = new(Index.Value);
                    _ = SendMessage(ComboBoxInfo.Handle, CB_SETCURSEL, IndexValue, IntPtr.Zero);
                }
            }
            else
            {
                int StringIndex = FindString(ComboBoxInfo, StringToSelect, true);
                WPARAM IndexValue = new(StringIndex);
                _ = SendMessage(ComboBoxInfo.Handle, CB_SETCURSEL, IndexValue, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Imposta la larghezza minima permessa per un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="Width">Larghezza minima.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetMinimumAllowedWidth(ComboBoxInfo ComboBoxInfo, long Width)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null)
            {
                if (!ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.Dropdown) && !ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.DisplayCurrentSelectionInStaticTextItem))
                {
                    throw new InvalidOperationException("The styles applied to the ComboBox are not valid.");
                }
            }
            if (Width is < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Width), "The width cannot be less than 0.");
            }
            WPARAM WidthValue = new(Width);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SETDROPPEDWIDTH, WidthValue, IntPtr.Zero);
            if (Result == CB_ERR)
            {
                throw new Exception("Unable to set minimum allowed width.");
            }
        }

        /// <summary>
        /// Seleziona testo in un controllo di modifica di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="StartingPosition">Posizione di partenza.</param>
        /// <param name="Length">Numero di caratteri da selezionare.</param>
        /// <remarks><paramref name="StartingPosition"/> può essere -1, in questo caso, qualunque selezione presente viene eliminata.<br/>
        /// Se <paramref name="Length"/> ha valore -1, tutti i caratteri a partire dall'indice indicato da <paramref name="StartingPosition"/> vengono selezionati.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SelectText(ComboBoxInfo ComboBoxInfo, short StartingPosition, short Length)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (StartingPosition is < -1 || Length is < -1)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "Invalid starting or ending position.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null && ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.DisplayCurrentSelectionInStaticTextItem))
            {
                throw new InvalidOperationException("The styles applied to the ComboBox are not valid.");
            }
            LRESULT Result;
            LPARAM SelectionValue;
            if (StartingPosition is -1)
            {
                SelectionValue = MAKELPARAM(StartingPosition, 0);
            }
            else
            {
                SelectionValue = MAKELPARAM(StartingPosition, Length);
            }
            Result = SendMessage(ComboBoxInfo.Handle, CB_SETEDITSEL, IntPtr.Zero, SelectionValue);
            if (!Convert.ToBoolean(Result.ToInt32()))
            {
                throw new Exception("Unable to select text in the ComboBox.");
            }
        }

        /// <summary>
        /// Abilita l'interfaccia utente estesa per un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void EnableExtendedUI(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null)
            {
                if (!ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.Dropdown) && !ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.DisplayCurrentSelectionInStaticTextItem))
                {
                    throw new InvalidOperationException("The styles applied to the ComboBox are not valid.");
                }
            }
            WPARAM Value = new(Convert.ToInt32(true));
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SETEXTENDEDUI, Value, IntPtr.Zero);
            if (Result != CB_OKAY)
            {
                throw new Exception("Unable to enable extended UI.");
            }
        }

        /// <summary>
        /// Disabilita l'interfaccia utente estesa per un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void DisableExtendedUI(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null)
            {
                if (!ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.Dropdown) && !ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.DisplayCurrentSelectionInStaticTextItem))
                {
                    throw new InvalidOperationException("The styles applied to the ComboBox are not valid.");
                }
            }
            WPARAM Value = new(Convert.ToInt32(false));
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SETEXTENDEDUI, Value, IntPtr.Zero);
            if (Result != CB_OKAY)
            {
                throw new Exception("Unable to enable extended UI.");
            }
        }

        /// <summary>
        /// Imposta la larghezza, in pixel, che un ComboBox può scorrere orizzontalemente.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="Width">Larghezza da impostare.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetScrollableWidth(ComboBoxInfo ComboBoxInfo, long Width)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (Width is < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Width), "The width cannot be less than 0.");
            }
            WPARAM WidthValue = new(Width);
            _ = SendMessage(ComboBoxInfo.Handle, CB_SETHORIZONTALEXTENT, WidthValue, IntPtr.Zero);
            long ScrollableWidth = GetScrollableWidth(ComboBoxInfo);
            if (ScrollableWidth != Width)
            {
                throw new Exception("Unable to set the ComboBox scrollable width.");
            }
        }


        /*public static void SetItemData(ComboBoxInfo ComboBoxInfo, object Data)
        {
            
        }*/

        /// <summary>
        /// Imposta l'altezza, in pixel, di un componente di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="Height">Altezza del componente, in pixel.</param>
        /// <param name="ComboBoxComponent">Componente di cui impostare l'altezza.</param>
        /// <remarks>Per impostare l'altezza del controllo di modifica, <paramref name="ComboBoxComponent"/> deve avere valore -1.<br/>
        /// Per impostare l'altezza degli elementi della lista in un ComboBox senza lo stile <see cref="ComboboxStyles.OwnerDrawnVariableHeight"/> applicato, <paramref name="ComboBoxComponent"/> deve essere 0.<br/>
        /// Se tale stile è applicato, <paramref name="ComboBoxComponent"/> deve indicare l'indice dell'oggetto di cui impostare l'altezza.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetComboBoxItemHeight(ComboBoxInfo ComboBoxInfo, int Height, int ComboBoxComponent)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxComponent is not >= -1)
            {
                throw new ArgumentException("The parameter value is invalid.", nameof(ComboBoxComponent));
            }
            WPARAM Component = new(ComboBoxComponent);
            LPARAM HeightValue = new(Height);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SETITEMHEIGHT, Component, HeightValue);
            if (Result == CB_ERR)
            {
                throw new Exception("Unable to set component height.");
            }
        }

        /// <summary>
        /// Imposta il numero minimo di oggetti visibili nel dropdown di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="MinimumItemsCount">Numero minimo di oggetti visibili.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetMinimumVisibleItemsCount(ComboBoxInfo ComboBoxInfo, int MinimumItemsCount)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (MinimumItemsCount is < 0)
            {
                throw new ArgumentException("The parameter value is invalid.", nameof(MinimumItemsCount));
            }
            WPARAM MinimumItems = new(MinimumItemsCount);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SETMINVISIBLE, MinimumItems, IntPtr.Zero);
            if (!Convert.ToBoolean(Result.ToInt32()))
            {
                throw new Exception("Unable to set minimum visible items count.");
            }
        }

        /// <summary>
        /// Imposta l'oggetto del list box visibile in cima alla lista.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <param name="ItemIndex">Indice dell'oggetto da rendere primo della lista.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetVisibleItem(ComboBoxInfo ComboBoxInfo, int ItemIndex)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ItemIndex is < 0)
            {
                throw new ArgumentException("The parameter value is invalid.", nameof(ItemIndex));
            }
            WPARAM Index = new(ItemIndex);
            LRESULT Result = SendMessage(ComboBoxInfo.Handle, CB_SETTOPINDEX, Index, IntPtr.Zero);
            if (Result == CB_ERR)
            {
                throw new Exception("Unable to set visible item.");
            }
        }

        /// <summary>
        /// Mostra il listbox di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void ShowDropDown(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null)
            {
                if (!ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.Dropdown) && !ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.DisplayCurrentSelectionInStaticTextItem))
                {
                    throw new InvalidOperationException("The styles applied to the ComboBox are not valid.");
                }
                if (ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.AlwaysDisplayListBox))
                {
                    throw new InvalidOperationException("This action is not valid for a ComboBox with the style \"AlwaysDisplayListbox\" applied.");
                }
            }
            WPARAM BoolValue = new(Convert.ToInt32(true));
            _ = SendMessage(ComboBoxInfo.Handle, CB_SHOWDROPDOWN, BoolValue, IntPtr.Zero);
            LRESULT ListVisible = SendMessage(ComboBoxInfo.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
            if (!Convert.ToBoolean(ListVisible.ToInt32()))
            {
                throw new Exception("Unable to show listbox.");
            }
        }

        /// <summary>
        /// Nasconde il listbox di un ComboBox.
        /// </summary>
        /// <param name="ComboBoxInfo">Istanza di <see cref="ComboBoxInfo"/> associata al controllo.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void HideDropDown(ComboBoxInfo ComboBoxInfo)
        {
            if (ComboBoxInfo is null)
            {
                throw new ArgumentNullException(nameof(ComboBoxInfo), "The parameter cannot be null.");
            }
            if (ComboBoxInfo.ComboBoxStyles is not null)
            {
                if (!ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.Dropdown) && !ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.DisplayCurrentSelectionInStaticTextItem))
                {
                    throw new InvalidOperationException("The styles applied to the ComboBox are not valid.");
                }
                if (ComboBoxInfo.ComboBoxStyles.Contains(ComboboxStyles.AlwaysDisplayListBox))
                {
                    throw new InvalidOperationException("This action is not valid for a ComboBox with the style \"AlwaysDisplayListbox\" applied.");
                }
            }
            WPARAM BoolValue = new(Convert.ToInt32(true));
            _ = SendMessage(ComboBoxInfo.Handle, CB_SHOWDROPDOWN, BoolValue, IntPtr.Zero);
            LRESULT ListVisible = SendMessage(ComboBoxInfo.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
            if (Convert.ToBoolean(ListVisible.ToInt32()))
            {
                throw new Exception("Unable to hide listbox.");
            }
        }
    }
}