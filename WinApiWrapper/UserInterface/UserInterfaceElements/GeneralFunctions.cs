using static WinApiWrapper.UserInterface.UserInterfaceElements.GeneralEnumerations;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements
{
    internal static class GeneralFunctions
    {
        /// <summary>
        /// Carica un'icona, un cursore, un cursore animato o un bitmap.
        /// </summary>
        /// <param name="ModuleInstance">Handle al modulo che contiene l'immagine.</param>
        /// <param name="ImageName">L'immagine da caricare.</param>
        /// <param name="ImageType">Tipo di immagine da caricare.</param>
        /// <param name="Width">Larghezza, in pixel, dell'icona o del cursore.</param>
        /// <param name="Height">Altezza, in pixel, dell'icona o del cursore.</param>
        /// <param name="LoadOptions">Opzioni di caricamento dell'immagine.</param>
        /// <returns>Handle all'immagine caricata, <see cref="IntPtr.Zero"/> in caso di errore.</returns>
        /// <remarks>Per caricare un'immagine OEM o una risorsa standalone, <paramref name="ModuleInstance"/> deve essere <see cref="IntPtr.Zero"/>.<br/><br/>
        /// Se <paramref name="ModuleInstance"/> non è <see cref="IntPtr.Zero"/> e <paramref name="LoadOptions"/> non include <see cref="LoadOptions.LR_LOADFROMFILE"/>, <paramref name="ImageName"/> specifica la risorsa nel modulo.<br/><br/>
        /// Se <paramref name="ModuleInstance"/> è <see cref="IntPtr.Zero"/> e <paramref name="LoadOptions"/> non include <see cref="LoadOptions.LR_LOADFROMFILE"/>, <paramref name="ImageName"/> specifica l'immagine OEM da caricare.<br/>
        /// Gli ID risorsa validi per le immagini OEM sono definiti nelle seguenti enumerazioni:<br/><br/>
        /// <see cref="OEMBitmapResource"/><br/>
        /// <see cref="OEMCursorResource"/><br/>
        /// <see cref="OEMIconResource"/><br/><br/>
        /// Per convertire i valori presenti nelle enumerazioni in valori validi per questa funzione passarli a <see cref="MAKEINTRESOURCE"/>.<br/><br/>
        /// Se <paramref name="LoadOptions"/> include <see cref="LoadOptions.LR_LOADFROMFILE"/>, <paramref name="ImageName"/> è il nome del file che contiene la risorsa stand-alone, <paramref name="ModuleInstance"/> deve essere <see cref="IntPtr.Zero"/>.</remarks>
        [DllImport("User32.dll", EntryPoint = "LoadImageW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HANDLE LoadImage(HINSTANCE ModuleInstance, LPCWSTR ImageName, ImageType ImageType, int Width, int Height, LoadOptions LoadOptions);
    }
}