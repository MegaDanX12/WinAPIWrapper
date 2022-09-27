using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonConstants;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Notifiche inviate dai pulsanti.
    /// </summary>
    internal static class ButtonNotifications
    {
        /// <summary>
        /// Inviato quando l'utente clicca la freccia di dropdown in un pulsante.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMBCDROPDOWN"/>, il campo <see cref="NMBCDROPDOWN.ButtonClientArea"/> descrive l'area del dropdown.<br/><br/>
        /// Non restituisce nulla.</remarks>
        internal const int BCN_DROPDOWN = BCN_FIRST + 2;

        /// <summary>
        /// Notifica il proprietario del pulsante che il mouse sta entrando nella o lasciando l'area client.
        /// </summary>
        /// <remarks>lParam: puntatore a struttura <see cref="NMBCHOTITEM"/>.<br/><br/>
        /// Non restituisce nulla.</remarks>
        internal const int BCN_HOTITEMCHANGE = BCN_FIRST + 1;

        /// <summary>
        /// Inviato quando l'utente clicca un pulsante.
        /// </summary>
        /// <remarks>wParam: gli ultimi 2 byte contengono l'ID del pulsante, i primi 2 byte contengono il codice di notifica.<br/><br/>
        /// lParam: handle al pulsante.</remarks>
        internal const int BN_CLICKED = 0;

        /// <summary>
        /// Inviato quando l'utente fa doppio click su un pulsante.
        /// </summary>
        /// <remarks>Pulsanti con i seguenti stili inviano automaticamente questa notifica:<br/><br/>
        /// <see cref="ButtonStyles.BS_RADIOBUTTON"/><br/>
        /// <see cref="ButtonStyles.BS_OWNERDRAW"/><br/><br/>
        /// I pulsanti che non hanno gli stili indicati applicati inviano questa notifica solo se hanno lo stile <see cref="ButtonStyles.BS_NOTIFY"/>.<br/><br/>
        /// wParam: gli ultimi 2 byte contengono l'ID del pulsante, i primi 2 byte contengono il codice di notifica.<br/><br/>
        /// lParam: handle al pulsante.</remarks>
        internal const int BN_DOUBLECLICKED = 5;

        /// <summary>
        /// Inviato quando un pulsante perde il focus della tastiera.
        /// </summary>
        /// <remarks>Il pulsante deve avere lo stile <see cref="ButtonStyles.BS_NOTIFY"/>.<br/><br/>
        /// wParam: gli ultimi 2 byte contengono l'ID del pulsante, i primi 2 byte contengono il codice di notifica.<br/><br/>
        /// lParam: handle al pulsante.</remarks>
        internal const int BN_KILLFOCUS = 7;

        /// <summary>
        /// Inviato quando un pulsante acquisisce il focus della tastiera.
        /// </summary>
        /// <remarks>Il pulsante deve avere lo stile <see cref="ButtonStyles.BS_NOTIFY"/>.<br/><br/>
        /// wParam: gli ultimi 2 byte contengono l'ID del pulsante, i primi 2 byte contengono il codice di notifica.<br/><br/>
        /// lParam: handle al pulsante.</remarks>
        internal const int BN_SETFOCUS = 6;
    }
}