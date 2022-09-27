namespace WinApiWrapper.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Messaggi DWM.
    /// </summary>
    internal static class DWMMessages
    {
        /// <summary>
        /// Informa tutte le finestre top-level che il colore della colorizzazione è cambiato.
        /// </summary>
        /// <remarks>wParam: specifica il nuovo colore, formato 0xAARRGGBB.<br/>
        /// lParam: specifica se il nuovo colore è mischiato con l'opacità.<br/><br/>
        /// Se il messaggio viene elaborato, il valore di ritorno dovrebbe essere 0.</remarks>
        internal const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;

        /// <summary>
        /// Inviato quando la politica di rendering dell'area non client è cambiata.
        /// </summary>
        /// <remarks>wParam: specifica se il rendering DWM è abilitato per l'area non client della finestra, true se abilitato, false altrimenti.<br/>
        /// lParam: non usato.<br/><br/>
        /// Se il messaggio viene elaborato, il valore di ritorno dovrebbe essere 0.</remarks>
        internal const int WM_DWMNCRENDERINGCHANGED = 0x031F;

        /// <summary>
        /// Comunica a una finestra che deve fornire un bitmap statico da usare come anteprima in tempo reale di essa.
        /// </summary>
        /// <remarks>Se il messaggio viene elaborato, il valore di ritorno dovrebbe essere 0.</remarks>
        internal const int WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326;

        /// <summary>
        /// Comunica a una finestra di fornire un bitmap statico da usare come miniatura di essa.
        /// </summary>
        /// <remarks>wParam: non usato.<br/>
        /// lParam: gli ultimi 16 bit di questo valore sono le coordinate x massime della miniatura, i 16 bit rimanenti sono le coordinate y della miniatura.<br/>
        /// Se le dimensioni della miniatura superano uno o entrambi questi valori, DWM non la accetta.<br/><br/>
        /// Se il messaggio viene elaborato, il valore di ritorno dovrebbe essere 0.</remarks>
        internal const int WM_DWMSENDICONICTHUMBNAIL = 0x0323;

        /// <summary>
        /// Inviato quando una finestra composta da DWM viene massimizzata.
        /// </summary>
        /// <remarks>wParam: impostato su true se la finestra è stata massimizzata.<br/>
        /// lParam: non usato.<br/><br/>
        /// Se il messaggio viene elaborato, il valore di ritorno dovrebbe essere 0.</remarks>
        internal const int WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321;
    }
}