using static WinApiWrapper.UserInterface.UserInterfaceElements.GeneralFunctions;
using static WinApiWrapper.UserInterface.UserInterfaceElements.GeneralEnumerations;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Icons
{
    /// <summary>
    /// Funzioni per interagire con le icone.
    /// </summary>
    internal static class IconFunctions
    {
        /// <summary>
        /// Elimina un'icona e libera la memoria da essa utilizzata.
        /// </summary>
        /// <param name="IconHandle">Handle all'icona.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>L'icona non deve essere in uso.<br/><br/>
        /// Questa funzione non deve essere usata per eliminare un'icona condivisa, essa resta valida fino a quando il modulo da cui è stata caricata resta in memoria.</remarks>
        [DllImport("User32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyIcon(HICON IconHandle);

        /// <summary>
        /// Recupera informazioni su un'icona o su un cursore.
        /// </summary>
        /// <param name="IconHandle">Handle all'icona o al cursore.</param>
        /// <param name="IconInfo">Struttura <see cref="IconStructures.ICONINFOEX"/> che riceve le informazioni.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>Per recuperare informazioni su una risorsa di sistema, utilizzare <see cref="LoadImage"/>, usando uno dei valori dell'enumerazione <see cref="StandardResourceID"/> e <see cref="MAKEINTRESOURCE"/> per caricare l'immagine.<br/>
        /// Deve essere usata l'opzione <see cref="LoadOptions.LR_SHARED"/> per il caricamento.</remarks>
        [DllImport("User32.dll", EntryPoint = "GetIconInfoExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetIconInfo(HICON IconHandle, ref IconStructures.ICONINFOEX IconInfo);
    }
}