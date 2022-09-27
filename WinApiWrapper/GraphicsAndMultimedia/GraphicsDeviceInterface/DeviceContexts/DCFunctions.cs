using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts.DCEnumerations;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants;

namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.DeviceContexts
{
    /// <summary>
    /// Funzioni relativi ai contesti dispositivo.
    /// </summary>
    internal static class DCFunctions
    {
        /// <summary>
        /// Recupera informazioni specifiche di un dispositivo.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo.</param>
        /// <param name="Index">Informazione da recuperare.</param>
        /// <returns>L'informazione richiesta.</returns>
        /// <remarks>Quando <paramref name="Index"/> ha valore <see cref="DeviceCapabilities.BITSPIXEL"/> e il dispositivo ha 15 o 16 bit per pixel, il valore restituito è 16.</remarks>
        [DllImport("Gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        internal static extern int GetDeviceCapabilities(HDC DeviceContextHandle, DeviceCapabilities Index);

        /// <summary>
        /// Recupera il tipo dell'oggetto specificato.
        /// </summary>
        /// <param name="ObjectHandle">Handle all'oggetto.</param>
        /// <returns>Un membro dell'enumerazione <see cref="GDIObjectType"/> che indica il tipo di oggetto.</returns>
        [DllImport("Gdi32.dll", EntryPoint = "GetObjectType", SetLastError = true)]
        internal static extern GDIObjectType GetObjectType(HGDIOBJ ObjectHandle);

        /// <summary>
        /// Recupera il colore attuale del pennello per un contesto dispositivo.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo.</param>
        /// <returns>Colore del pennello se l'operazione è riuscita, <see cref="CLR_INVALID"/> altrimenti.</returns>
        [DllImport("Gdi32.dll", EntryPoint = "GetDCBrushColor", SetLastError = true)]
        internal static extern COLORREF GetBrushColor(HDC DeviceContextHandle);

        /// <summary>
        /// Recupera l'origine finale della traslazione per un contesto dispositivo.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo.</param>
        /// <param name="CoordinatesStructurePointer">Puntatore a struttura <see cref="General.GeneralStructures.POINT"/> che riceve le coordinate, espresse in coordinate dispositivo.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        /// <remarks>L'origine finale di traslazione è relativa all'origine fisica dello schermo.</remarks>
        [DllImport("Gdi32.dll", EntryPoint = "GetDCOrgEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL GetTranslationOrigin(HDC DeviceContextHandle, IntPtr CoordinatesStructurePointer);

        /// <summary>
        /// Recupera il colore attuale della penna per un contesto dispositivo.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo.</param>
        /// <returns>Il colore della penna se l'operazione è riuscita, <see cref="CLR_INVALID"/> altrimenti.</returns>
        [DllImport("Gdi32.dll", EntryPoint = "GetDCPenColor", SetLastError = true)]
        internal static extern COLORREF GetPenColor(HDC DeviceContextHandle);

        /// <summary>
        /// Recupera il layout del contesto del dispositivo.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle al contesto dispositivo.</param>
        /// <returns>Opzioni relative al layout impostate per il contesto dispositivo se l'operazione è riuscita, <see cref="GDI_ERROR"/> altrimenti.</returns>
        /// <remarks>Se l'operazione è riuscita, la funzione restituisce uno o un valore composito composto dai seguenti valori:<br/><br/>
        /// <see cref="LAYOUT_RTL"/><br/>
        /// <see cref="LAYOUT_BITMAPORIENTATIONPRESERVED"/></remarks>
        [DllImport("Gdi32.dll", EntryPoint = "GetLayout", SetLastError = true)]
        internal static extern int GetLayout(HDC DeviceContextHandle);
    }
}