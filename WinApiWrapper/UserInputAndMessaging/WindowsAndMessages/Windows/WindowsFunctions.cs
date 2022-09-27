using System.Text;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowStructures;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows
{
    /// <summary>
    /// Funzioni relativi alle finestre.
    /// </summary>
    public static class WindowsFunctions
    {
        /// <summary>
        /// Determina se un handle identifica una finestra esistente.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <returns>true se l'handle identifica una finestra esistente, false altrimenti.</returns>
        [DllImport("User32.dll", EntryPoint = "IsWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL IsWindow(HWND WindowHandle);

        /// <summary>
        /// Recupera un handle al desktop.
        /// </summary>
        /// <returns>Handle al desktop.</returns>
        [DllImport("User32.dll", EntryPoint = "GetDesktopWindow", SetLastError = true)]
        internal static extern HWND GetDesktopWindow();

        /// <summary>
        /// Recupera informazioni su una finestra.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Info">Struttura <see cref="WINDOWINFO"/> che riceve le informazioni.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Il campo <see cref="WINDOWINFO.Size"/> deve essere impostato alla dimensione della struttura prima di chiamare questa funzione.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetWindowInfo", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetWindowInfo(HWND WindowHandle, ref WINDOWINFO Info);

        /// <summary>
        /// Recupera il nome della classe a cui una finestra appartiene.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="ClassName">Nome della classe.</param>
        /// <param name="MaxLength">Dimensione, in caratteri, di <paramref name="ClassName"/>.</param>
        /// <returns>Numero di caratteri copiati in <paramref name="ClassName"/> escluso il carattere nullo finale, 0 in caso di errore.</returns>
        [DllImport("User32.dll", EntryPoint = "GetClassNameW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetClassName(HWND WindowHandle, StringBuilder ClassName, int MaxLength);

        /// <summary>
        /// Recupera informazioni su una finestra oppure un valore a uno specifico offset nella memoria extra..
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra.</param>
        /// <param name="Index">Offset del valore da recuperare.</param>
        /// <returns>Il valore o l'informazione richiesta se l'operazione è riuscita, 0 in caso contrario.</returns>
        /// <remarks>I valori dell'enumerazione <see cref="WindowEnumerations.WindowDataSpecialOffset"/> sono validi per <paramref name="Index"/>.<br/>
        /// Inoltre anche i seguenti valori sono validi per <paramref name="Index"/>:<br/><br/>
        /// DWLP_DLGPROC (0 + <see cref="IntPtr.Size"/>)<br/>
        /// DWLP_USER (<see cref="IntPtr.Size"/> + <see cref="IntPtr.Size"/>)</remarks>
        [DllImport("User32.dll", EntryPoint = "GetWindowLongPtrW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern LONG_PTR GetWindowLongPtr(HWND WindowHandle, int Index);
    }
}