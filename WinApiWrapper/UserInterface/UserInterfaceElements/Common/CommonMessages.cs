using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonConstants;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Common
{
    /// <summary>
    /// Messaggi comuni a tutti i controlli.
    /// </summary>
    internal static class CommonMessages
    {
        /// <summary>
        /// Abilita lo scaling dpi automatico.
        /// </summary>
        /// <remarks>Lo scaling è abilitato per i seguenti controlli:<br/><br/>
        /// Vista ad albero<br/>
        /// ListView<br/>
        /// ComboBoxEx<br/>
        /// Header<br/>
        /// Pulsante<br/>
        /// Toolbar<br/>
        /// Animazione<br/>
        /// Lista immagini<br/><br/>
        /// wParam: deve avere valore true.<br/><br/>
        /// lParam: deve essere 0.<br/><br/>
        /// Il valore restituito non è usato.</remarks>
        internal const int CCM_DPISCALE = CCM_FIRST + 12;

        /// <summary>
        /// Recupera un valore che indica se il controllo usa caratteri Unicode.
        /// </summary>
        /// <remarks>wParam e lParam devono essere 0.<br/><br/>
        /// Restituisce un valore diverso da 0 se il controllo usa caratteri Unicode, 0 se usa caratteri ANSI.</remarks>
        internal const int CCM_GETUNICODEFORMAT = CCM_FIRST + 6;

        /// <summary>
        /// Recupera la versione di un controllo impostata dal più recente messaggio <see cref="CCM_SETVERSION"/>.
        /// </summary>
        /// <remarks>wParam e lParam devono essere 0.<br/><br/>
        /// Restituisce il numero di versione impostato dal messaggio <see cref="CCM_SETVERSION"/> più recente, se tale messaggio non è stato inviato, restituisce 0.</remarks>
        internal const int CCM_GETVERSION = CCM_FIRST + 8;

        /// <summary>
        /// Imposta un valore che indica se il controllo usa caratteri Unicode.
        /// </summary>
        /// <remarks>wParam: valore che determina il set di caratteri usato dal controllo.<br/>
        /// Se ha valore true, il controllo usa caratteri Unicode, se ha valore false, il controllo usa caratteri ANSI.<br/><br/>
        /// lParam: deve essere 0.<br/><br/>
        /// Restituisce il valore precedente che era impostato nel controllo.</remarks>
        internal const int CCM_SETUNICODEFORMAT = CCM_FIRST + 5;

        /// <summary>
        /// Usato per informare il controllo che deve avere un comportamento associato a una specifica versione.
        /// </summary>
        /// <remarks>wParam: numero di versione.<br/><br/>
        /// lParam: deve essere 0.<br/><br/>
        /// Restituisce la versione specificata in un messaggio <see cref="CCM_SETVERSION"/> precedente, se wParam è impostato a un valore più elevato della versione corrente della DLL, restituisce -1.</remarks>
        internal const int CCM_SETVERSION = CCM_FIRST + 7;

        /// <summary>
        /// Imposta gli stili visuali di un controllo.
        /// </summary>
        /// <remarks>wParam: deve essere 0.<br/><br/>
        /// lParam: puntatore a stringa Unicode che contiene il controlli visuali da impostare.<br/><br/>
        /// Il valore restituito non è usato.</remarks>
        internal const int CCM_SETWINDOWTHEME = CCM_FIRST + 11;
    }
}