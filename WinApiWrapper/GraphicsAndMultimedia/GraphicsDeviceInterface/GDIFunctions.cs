using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;

namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface
{
    /// <summary>
    /// Funzioni GDI.
    /// </summary>
    internal static class GDIFunctions
    {
        /// <summary>
        /// Carica un'icona, un cursore, un cursore animato o un bitmap.
        /// </summary>
        /// <param name="Instance">Handle al modulo oppure alla DLL o all'eseguibile che contiene l'immagine.</param>
        /// <param name="Name">L'immagine da caricare.</param>
        /// <param name="Type">Tipo di immagine da caricare.</param>
        /// <param name="x">Larghezza, in pixel, dell'icona o del cursore.</param>
        /// <param name="y">Altezza, in pixel, dell'icona o del cursore.</param>
        /// <param name="LoadOptions">Opzioni di caricamento dell'immagine.</param>
        /// <returns>Handle all'immagine, <see cref="IntPtr.Zero"/> in caso di errore.</returns>
        /// <remarks>Per caricare un'immagine OEM oppure un'immagine stand-alone, <paramref name="Instance"/> deve essere <see cref="IntPtr.Zero"/>.<br/><br/>
        /// Se <paramref name="Instance"/> non ha valore <see cref="IntPtr.Zero"/> e <paramref name="LoadOptions"/> non include <see cref="LoadOptions.LR_LOADFROMFILE"/>, <paramref name="Name"/> specifica la risorsa nel modulo.<br/>
        /// Se la risorsa deve essere caricata per nome dal modulo, <paramref name="Name"/> indica il nome della risorsa.<br/>
        /// Se la risorsa deve essere caricata tramite ordinale dal modulo, il valore dell'ordinale deve essere preceduto da #.<br/>
        /// Se <paramref name="Instance"/> ha valore <see cref="IntPtr.Zero"/> e <paramref name="LoadOptions"/> non include <see cref="LoadOptions.LR_LOADFROMFILE"/>, <paramref name="Name"/> specifica l'immagine OEM da caricare.<br/>
        /// I valori costanti per le immagini OEM sono indicati nell'enumerazione <see cref="OEMImageOrdinals"/>.<br/>
        /// Se <paramref name="LoadOptions"/> include <see cref="LoadOptions.LR_LOADFROMFILE"/>, <paramref name="Name"/> è il nome del file che contiene la risorsa stand-alone, <paramref name="Instance"/> deve essere <see cref="IntPtr.Zero"/>.<br/><br/>
        /// Se <paramref name="x"/> ha valore 0 e <paramref name="LoadOptions"/> ha valore <see cref="LoadOptions.LR_DEFAULTSIZE"/>, la funzione utilizzera la metrica <see cref="SystemMetricValue.SM_CXICON"/> oppure <see cref="SystemMetricValue.SM_CXCURSOR"/> per impostare la larghezza.<br/>
        /// Se <paramref name="x"/> ha valore 0 e <paramref name="LoadOptions"/> non ha valore <see cref="LoadOptions.LR_DEFAULTSIZE"/>, la funzione usa l'effettiva larghezza della risorsa.<br/><br/>
        /// Se <paramref name="y"/> ha valore 0 e <paramref name="LoadOptions"/> ha valore <see cref="LoadOptions.LR_DEFAULTSIZE"/>, la funzione utilizzera la metrica <see cref="SystemMetricValue.SM_CYICON"/> oppure <see cref="SystemMetricValue.SM_CYCURSOR"/> per impostare l'altezza.<br/>
        /// Se <paramref name="y"/> ha valore 0 e <paramref name="LoadOptions"/> non ha valore <see cref="LoadOptions.LR_DEFAULTSIZE"/>, la funzione usa l'effettiva altezza della risorsa.</remarks>
        [DllImport("User32.dll", EntryPoint = "LoadImage", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HANDLE LoadImage(HINSTANCE Instance, LPCWSTR Name, ImageType Type, int x, int y, LoadOptions LoadOptions);

        /// <summary>
        /// Elimina un oggetto logico GDI (penna, pennello, font, bitmap, regione, oppure tavolozza), liberando tutte le risorse di sistema associate ad esso.
        /// </summary>
        /// <param name="ObjectHandle">Handle all'oggetto.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL DeleteObject(HGDIOBJ ObjectHandle);
    }
}