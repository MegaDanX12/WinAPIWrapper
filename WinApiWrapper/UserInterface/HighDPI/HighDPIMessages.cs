using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIEnumerations;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIConstants;
using WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows;

namespace WinApiWrapper.UserInterface.HighDPI
{
    /// <summary>
    /// Messaggi per finestre che tengono conto dei DPI.
    /// </summary>
    public static class HighDPIMessages
    {
        /// <summary>
        /// Inviato quando i DPI per una finestra sono cambiati.
        /// </summary>
        /// <remarks>wParam: gli ultimi 2 byte del valore sono i nuovi DPI per l'asse x, i primi 2 byte sono i nuovi DPI per l'asse y.<br/>
        /// lParam: puntatore a una struttura <see cref="RECT"/> che suggerisce una dimensione e una posizione per la finestra ridimensionata per il nuovo valore DPI.<br/><br/>
        /// Se un'applicazione elabora questo messaggio dovrebbe restituire 0.<br/><br/>
        /// Questo messaggio è rilevante solo per processi <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> o per thread <see cref="DPI_AWARENESS.DPI_AWARENESS_PER_MONITOR_AWARE"/>.<br/><br/>
        /// I valori DPI per l'asse x e l'asse y sono uguali.<br/><br/>
        /// Per gestire correttamente questo messaggio, la finestra dovrebbe essere ridimensionata e riposizionata basandosi sul suggerimento fornito da lParam.</remarks>
        public const int WM_DPICHANGED = 0x02E0;

        /// <summary>
        /// Inviato a tutti i HWND nel albero dei figli di una finestra top-level con <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/> dove è in corso l'elaboazione del cambio del valore dei DPI.
        /// </summary>
        /// <remarks>Questo messaggio viene ricevuto prima che la finestra top-level riceva <see cref="WM_DPICHANGED"/> e attraverso l'albero dei figli dal basso verso l'alto.<br/><br/>
        /// La funzione <see cref="WindowsFunctions.DefWindowProc"/> non ha una gestione predefinita per questo messaggio, il valore restituito è inutilizzato.</remarks>
        public const int WM_DPICHANGED_BEFOREPARENT = 0x02E2;

        /// <summary>
        /// Inviato a tutti i HWND nel albero dei figli di una finestra top-level con <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/> dove è in corso l'elaboazione del cambio del valore dei DPI.
        /// </summary>
        /// <remarks>Questo messaggio viene ricevuto dopo che la finestra top-level ha ricevuto <see cref="WM_DPICHANGED"/> e attraverso l'albero dei figli dall'alto verso il basso.<br/><br/>
        /// La funzione <see cref="WindowsFunctions.DefWindowProc"/> non ha una gestione predefinita per questo messaggio, il valore restituito è inutilizzato.</remarks>
        public const int WM_DPICHANGED_AFTERPARENT = 0x02E3;

        /// <summary>
        /// Questo messaggio dice al sistema operativo che la finestra sarà ridimensionata con dimensioni diverse da quelle predefinite.
        /// </summary>
        /// <remarks>wParam: valori DPI.<br/>
        /// lParam: puntatore in/out a una struttura <see cref="SIZE"/>, quando il messaggio viene ricevuto lParam è la dimensione della finestra dopo l'azione dell'utente o a una chiamata a <see cref="WindowsFunctions.SetWindowPos"/>.<br/>
        /// Se la finestra è in corso di ridimensionamento questa dimensione non è detto che sia la stessa di quella attuale quando il messaggio viene ricevuto.<br/>
        /// In uscita, il valore di lParam deve indicare la dimensione scalata della finestra corrispondente al valore DPI fornito in wParam.<br/><br/>
        /// Il valore restituito deve essere true se la nuova dimensione è stata calcolata, false se il messaggio non verrà gestito e si dovrebbe ridimensionare la finestra in base al comportamento predefinito.<br/><br/>
        /// Questo messaggio viene inviato solo a finestre con <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/>.<br/><br/>
        /// La funzione <see cref="WindowsFunctions.DefWindowProc"/> non ha una gestione predefinita per questo messaggio.</remarks>
        public const int WM_GETDPISCALESIZE = 0x02E4;
    }
}