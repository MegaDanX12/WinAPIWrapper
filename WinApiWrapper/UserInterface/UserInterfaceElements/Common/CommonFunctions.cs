using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Common
{
    /// <summary>
    /// Funzioni comuni a tutti i controlli Windows.
    /// </summary>
    internal static class CommonFunctions
    {
        /// <summary>
        /// Disegna testo con un'ombra.
        /// </summary>
        /// <param name="DeviceContextHandle">Handle a un contesto dispositivo.</param>
        /// <param name="Text">Testo da disegnare.</param>
        /// <param name="TextLength">Numero di caratteri di <paramref name="Text"/>.</param>
        /// <param name="Rectangle">Puntatore a struttura <see cref="RECT"/> che contiene, in coordinate logiche, il rettangolo nel quale il testo deve essere disegnato.</param>
        /// <param name="Flags">Opzioni di disegno del testo.</param>
        /// <param name="TextColor">Colore del testo.</param>
        /// <param name="TextShadowColor">Colore dell'ombra del testo.</param>
        /// <param name="CordinateX">Coordinata x dove il testo inizia.</param>
        /// <param name="CoordinateY">Coordinate y dove il testo inizia.</param>
        /// <returns>L'altezza, in unità logiche, se l'operazione è riuscita, 0 altrimenti.</returns>
        [DllImport("ComCtl32.dll", EntryPoint = "DrawShadowText", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int DrawShadowText(HDC DeviceContextHandle, LPCWSTR Text, uint TextLength, IntPtr Rectangle, TextFormat Flags, COLORREF TextColor, COLORREF TextShadowColor, int CordinateX, int CoordinateY);

        /// <summary>
        /// Calcola le dimensione del rettangolo nell'area client che contiene tutti i controlli specificati.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra la cui area client deve essere verificata.</param>
        /// <param name="RectanglePointer">Puntatore a struttura <see cref="RECT"/> che riceve la dimensione del rettangolo.</param>
        /// <param name="ControlsArrayPointer">Puntatore a un array di interi che identifica i controlli nell'area.</param>
        /// <remarks>L'array puntato da <paramref name="ControlsArrayPointer"/> contiene per ogni controllo due elementi.<br/>
        /// Il primo elemento deve essere diverso da 0 e il secondo elemento deve essere l'ID del controllo.<br/>
        /// Il primo elemento viene ignorato, l'ultimo elemento deve essere 0 per identificare la fine dell'array.</remarks>
        [DllImport("Comctl32.dll", EntryPoint = "GetEffectiveClientRect", SetLastError = true)]
        internal static extern void GetEffectiveClientRectangle(HWND WindowHandle, IntPtr RectanglePointer, IntPtr ControlsArrayPointer);

        /// <summary>
        /// Recupera la lingua attualmente usata dai controlli comuni per un processo.
        /// </summary>
        /// <returns>L'ID della lingua specificato da un'applicazione per i controlli comuni chiamando <see cref="InitMUILanguage"/>.</returns>
        /// <remarks>Se il processo non ha chiamato <see cref="InitMUILanguage"/> o se è stata chiamata da un altro processo viene restituito l'ID della lingua neutra.</remarks>
        [DllImport("Comctl32.dll", EntryPoint = "GetMUILanguage", SetLastError = true)]
        internal static extern ushort GetMUILanguage();

        /// <summary>
        /// Si assicura che la DLL dei controlli comuni sia caricata e registra le classi specificate.
        /// </summary>
        /// <param name="ClassesStructurePointer">Puntatore a struttura <see cref="INITCOMMONCONTROLSEX"/> che specifica le classi da registrare.</param>
        /// <returns>true se l'operazione è riuscita, false altrimenti.</returns>
        [DllImport("Comctl32.dll", EntryPoint = "InitCommonControlsEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool InitializeCommonControls(IntPtr ClassesStructurePointer);

        /// <summary>
        /// Permette a un'applicazione di specificare una lingua da usare per i controlli comuni diversa da quella di sistema.
        /// </summary>
        /// <param name="Language">ID lingua.</param>
        [DllImport("Comctl32.dll", EntryPoint = "InitMUILanguage", SetLastError = true)]
        internal static extern void InitMUILanguage(ushort Language);

        /// <summary>
        /// Carica un'icona con una specifica metrica.
        /// </summary>
        /// <param name="ModuleInstance">Handle al modulo che contiene l'icona da caricare.</param>
        /// <param name="IconLocation">Informazione su dove si trova l'icona.</param>
        /// <param name="Metric">Metrica da utilizzare per l'icona.</param>
        /// <param name="IconHandle">Handle all'icona.</param>
        /// <returns><see cref="S_OK"/> se l'operazione è riuscita, un codice di errore altrimenti.</returns>
        /// <remarks><paramref name="ModuleInstance"/> deve essere <see cref="IntPtr.Zero"/> se si intende caricare un'icona predefinita o un file icona.<br/><br/>
        /// Se <paramref name="ModuleInstance"/> ha valore <see cref="IntPtr.Zero"/>, <paramref name="IconLocation"/> può specificare:<br/><br/>
        /// 1) il nome di un file icona (.ico)<br/>
        /// 2) L'ID di un'icona predefinita, i seguenti ID sono riconosciuti:<br/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_APPLICATION"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_INFORMATION"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_ERROR"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_WARNING"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_SHIELD"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_QUESTION"/><br/><br/>
        /// Utilizzare <see cref="MAKEINTRESOURCE"/> per utilizzare tali ID con la funzione.<br/><br/>
        /// Se <paramref name="ModuleInstance"/> non ha valore <see cref="IntPtr.Zero"/>, <paramref name="IconLocation"/> può specificare:<br/><br/>
        /// 1) il nome dell'icona, se deve essere caricata per nome dal modulo<br/>
        /// 2) l'ordinale dell'icona, se deve essere caricata per ordinale dal modulo<br/><br/>
        /// In caso di errore, la funzione può restituire, tra gli altri, <see cref="E_INVALIDARG"/> se <paramref name="IconLocation"/> non è interpretabile.<br/><br/>
        /// L'applicazione è responsabile della chiamata a <see cref="Icons.IconFunctions.DestroyIcon"/> quando non è più necessaria.</remarks>
        [DllImport("Comctl32.dll", EntryPoint = "LoadIconMetric", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HRESULT LoadIconMetric(HINSTANCE ModuleInstance, PCWSTR IconLocation, IconMetric Metric, out HICON IconHandle);

        /// <summary>
        /// Carica un'icona.
        /// </summary>
        /// <param name="ModuleInstance">Handle al modulo che contiene l'icona da caricare.</param>
        /// <param name="IconLocation">Informazione su dove si trova l'icona.</param>
        /// <param name="Width">Larghezza, in pixel, dell'icona.</param>
        /// <param name="Height">Altezza, in pixel, dell'icona.</param>
        /// <param name="IconHandle">Handle all'icona.</param>
        /// <returns><see cref="S_OK"/> se l'operazione è riuscita, un codice di errore altrimenti.</returns>
        /// <remarks><paramref name="ModuleInstance"/> deve essere <see cref="IntPtr.Zero"/> se si intende caricare un'icona predefinita o un file icona.<br/><br/>
        /// Se <paramref name="ModuleInstance"/> ha valore <see cref="IntPtr.Zero"/>, <paramref name="IconLocation"/> può specificare:<br/><br/>
        /// 1) il nome di un file icona (.ico)<br/>
        /// 2) L'ID di un'icona predefinita, i seguenti ID sono riconosciuti:<br/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_APPLICATION"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_INFORMATION"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_ERROR"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_WARNING"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_SHIELD"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_QUESTION"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_ASTERISK"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_EXCLAMATION"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_HAND"/><br/>
        /// <see cref="GeneralEnumerations.StandardResourceID.IDI_WINLOGO"/><br/><br/>
        /// Utilizzare <see cref="MAKEINTRESOURCE"/> per utilizzare tali ID con la funzione.<br/><br/>
        /// Se <paramref name="ModuleInstance"/> non ha valore <see cref="IntPtr.Zero"/>, <paramref name="IconLocation"/> può specificare:<br/><br/>
        /// 1) il nome dell'icona, se deve essere caricata per nome dal modulo<br/>
        /// 2) l'ordinale dell'icona, se deve essere caricata per ordinale dal modulo<br/><br/>
        /// In caso di errore, la funzione può restituire, tra gli altri, <see cref="E_INVALIDARG"/> se <paramref name="IconLocation"/> non è interpretabile.</remarks>
        [DllImport("Comctl32.dll", EntryPoint = "LoadIconWithScaleDown", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern HRESULT LoadIconWithScaleDown(HINSTANCE ModuleInstance, PCWSTR IconLocation, int Width, int Height, out HICON IconHandle);
    }
}