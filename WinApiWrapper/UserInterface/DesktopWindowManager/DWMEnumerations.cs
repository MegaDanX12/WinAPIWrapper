using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMStructures;

namespace WinApiWrapper.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Enumerazioni DWM.
    /// </summary>
    internal static class DWMEnumerations
    {
        /// <summary>
        /// Opzioni usate per recupera o impostare gli attributi delle finestre da DWM.
        /// </summary>
        internal enum DWMWINDOWATTRIBUTE : DWORD
        {
            /// <summary>
            /// Recupera lo stato del rendering dell'area non-client.
            /// </summary>
            /// <remarks>Recupera un valore di tipo BOOL, true se il rendering è attivo, false altrimenti.</remarks>
            DWMWA_NCRENDERING_ENABLED = 1,
            /// <summary>
            /// Imposta la politica di rendering dell'area non client.
            /// </summary>
            /// <remarks>Il valore da indicare è uno dei valori dell'enumerazione <see cref="DWMNCRENDERINGPOLICY"/>.</remarks>
            DWMWA_NCRENDERING_POLICY,
            /// <summary>
            /// Abilita o disabilita forzatamente le transizioni DWM.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo <see cref="BOOL"/>, true per disabilitare le transizioni, false per abilitarle.</remarks>
            DWMWA_TRANSITIONS_FORCEDISABLED,
            /// <summary>
            /// Permette al contenuto renderizzato nell'area non-client di essere visibile sul frame disegnato da DWM.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per permette al contenuto di essere visibile, false per non permettere al contenuto di essere visibile.</remarks>
            DWMWA_ALLOW_NCPAINT,
            /// <summary>
            /// Recupera i limiti del bottone della barra del titolo nello spazio relativo alla finestra.
            /// </summary>
            /// <remarks>Il valore recuperate è di tipo <see cref="General.GeneralStructures.RECT"/>.<br/><br/>
            /// Se la finestra non è visibile all'utente, il valore recuperato non è definito.</remarks>
            DWMWA_CAPTION_BUTTON_BOUNDS,
            /// <summary>
            /// Imposta se il contenuto non-client è RTL (right-to-left) rispecchiato.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per imposta il contenuto, false latrimenti.</remarks>
            DWMWA_NONCLIENT_RTL_LAYOUT,
            /// <summary>
            /// Forza la finestra a visualizzare una miniatura anche se uno snapshot della finestra è disponibile.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per richiedere una miniatura, false altrimenti.</remarks>
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            /// <summary>
            /// Imposta come Flip3D tratta la finestra.
            /// </summary>
            /// <remarks>Il valore da indicare è un valore dell'enumerazione <see cref="DWMFLIP3DWINDOWPOLICY"/>.</remarks>
            DWMWA_FLIP3D_POLICY,
            /// <summary>
            /// Recupera i limiti estesi del rettangolo nello spazio dello schermo.
            /// </summary>
            /// <remarks>Il valore recuperato è di tipo <see cref="General.GeneralStructures.RECT"/>.</remarks>
            DWMWA_EXTENDED_FRAME_BOUNDS,
            /// <summary>
            /// Imposta se la finestra fornirà un bitmap per uso da parte di DWM come miniatura per essa.
            /// </summary>
            /// <remarks>Questo valore può essere utilizzato insieme a <see cref="DWMWA_FORCE_ICONIC_REPRESENTATION"/>.<br/><br/>
            /// Il valore da indicare è di tipo <see cref="BOOL"/>, true per informare DWM che la finestra fornirà una miniatura, false altrimenti.</remarks>
            DWMWA_HAS_ICONIC_BITMAP,
            /// <summary>
            /// Disattiva la miniatura per la finestra.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per disabilitare la miniatura, false altrimenti.</remarks>
            DWMWA_DISALLOW_PEEK,
            /// <summary>
            /// Impedisce a una finestra di trasformarsi in una lastra di vetro quando peek viene utilizzato.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per impedire alla finestra di trasformarsi in una lastra di vetro, false altrimenti.</remarks>
            DWMWA_EXCLUDED_FROM_PEEK,
            /// <summary>
            /// Nasconde la finestra così che non sia visibile all'utente, la finestra viene ancora compostra da DWM.
            /// </summary>
            DWMWA_CLOAK,
            /// <summary>
            /// Se la finestra è nascosta, questo valore restituisce uno dei seguenti valori:<br/><br/>
            /// <see cref="DWMConstants.DWM_CLOAKED_APP"/> (nascosta dal proprietario)<br/>
            /// <see cref="DWMConstants.DWM_CLOAKED_SHELL"/> (nascosta dalla shell)<br/>
            /// <see cref="DWMConstants.DWM_CLOAKED_INHERITED"/> (nascosta in base alla finestra proprietaria.
            /// </summary>
            DWMWA_CLOAKED,
            /// <summary>
            /// Blocca la miniatura della finestra nell'attuale aspetto.
            /// </summary>
            DWMWA_FREEZE_REPRESENTATION,
            /// <summary>
            /// Imposta se aggiornare la finestra solo quando la composizione del desktop avviene per altri motivi.
            /// </summary>
            /// Il valore da indicare è di tipo BOOL, true per abilitare questo comportamento, false altrimenti.
            DWMWA_PASSIVE_UPDATE_MODE,
            /// <summary>
            /// Permette a una finestra non-UWP di usare i pennelli di sfondo dell'host.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per permettere di usare i pennelli, false altrimenti.</remarks>
            DWMWA_USE_HOSTBACKDROPBRUSH,
            /// <summary>
            /// Permette alla cornice della finestra di essere disegnata con i colori della modalità scura quando essa è attivata.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo BOOL, true per permettere l'uso dei colori della modalità scura, false altrimenti.</remarks>
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            /// <summary>
            /// Specifica la preferenza per gli angoli arrotondati di una finestra.
            /// </summary>
            /// <remarks>Il valore da indicare è uno dei valori dell'enumerazione <see cref="DWM_WINDOW_CORNER_PREFERENCE"/>.</remarks>
            DWMWA_WINDOW_CORNER_PREFERENCE = 33,
            /// <summary>
            /// Specifica il colore del bordo della finestra.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo COLORREF (<see cref="DWORD"/>).</remarks>
            DWMWA_BORDER_COLOR,
            /// <summary>
            /// Specifica il colore della barra del titolo.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo COLORREF (<see cref="DWORD"/>).</remarks>
            DWMWA_CAPTION_COLOR,
            /// <summary>
            /// Specifica il colore del testo della barra del titolo.
            /// </summary>
            /// <remarks>Il valore da indicare è di tipo COLORREF (<see cref="DWORD"/>).</remarks>
            DWMWA_TEXT_COLOR,
            /// <summary>
            /// Recupera la larghezza del bordo esterno che DWM disegna attorno alla finestra.
            /// </summary>
            /// <remarks>Il valore recuperato è di tipo <see cref="uint"/>.</remarks>
            DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
            /// <summary>
            /// Valore massimo dell'enumerazione.
            /// </summary>
            DWMWA_LAST
        }

        /// <summary>
        /// Valori usati per impostare la politica di rendering da parte di DWM dell'area non-client di una finestra.
        /// </summary>
        internal enum DWMNCRENDERINGPOLICY
        {
            /// <summary>
            /// Il rendering dell'area non-client è eseguito in basi agli stili della finestra.
            /// </summary>
            DWMNCRP_USEWINDOWSTYLE,
            /// <summary>
            /// Il rendering dell'area non-client è disattivato.
            /// </summary>
            DWMNCRP_DISABLED,
            /// <summary>
            /// Il rendering dell'area non-client è attivato.
            /// </summary>
            DWMNCRP_ENABLED,
            /// <summary>
            /// Valore massimo dell'enumerazione.
            /// </summary>
            DWMNCRP_LAST
        }

        /// <summary>
        /// Valori usati per impostare la politica Flip3D per una finestra.
        /// </summary>
        internal enum DWMFLIP3DWINDOWPOLICY
        {
            /// <summary>
            /// Usa le impostazioni di stile e di visibilità per determinare se nascondere o includere la finestra nel rendering Flip3D.
            /// </summary>
            DWMFLIP3D_DEFAULT,
            /// <summary>
            /// Esclude la finestra da Flip3D e la visualizza sotto il rendering Flip3D.
            /// </summary>
            DWMFLIP3D_EXCLUDEBELOW,
            /// <summary>
            /// Esclude la finestra da Flip3D e la visualizza sopra il rendering Flip3D.
            /// </summary>
            DWMFLIP3D_EXCLUDEABOVE,
            /// <summary>
            /// Valore massimo dell'enumerazione.
            /// </summary>
            DWMFLIP3D_LAST
        }

        /// <summary>
        /// Opzioni usate per la preferenza sugli angoli arrotondati per una finestra.
        /// </summary>
        internal enum DWM_WINDOW_CORNER_PREFERENCE
        {
            /// <summary>
            /// Lascia decidere al sistema quando arrotondare gli angoli.
            /// </summary>
            DWMWCP_DEFAULT,
            /// <summary>
            /// Non arrotondare mai gli angoli.
            /// </summary>
            DWMWCP_DONOTROUND,
            /// <summary>
            /// Arrotondare gli angoli, se appropriato.
            /// </summary>
            DWMWCP_ROUND,
            /// <summary>
            /// Arrotondare gli angoli, se appropriato, con un piccolo raggio.
            /// </summary>
            DWMWCP_ROUNDSMALL
        }

        /// <summary>
        /// Tipo di gesto.
        /// </summary>
        internal enum GESTURE_TYPE
        {
            /// <summary>
            /// Tocco di una penna.
            /// </summary>
            GT_PEN_TAP,
            /// <summary>
            /// Doppio tocco di una penna.
            /// </summary>
            GT_PEN_DOUBLETAP,
            /// <summary>
            /// Tocco destro di una penna.
            /// </summary>
            GT_PEN_RIGHTTAP,
            /// <summary>
            /// Tocco continuo di una penna.
            /// </summary>
            GT_PEN_PRESSANDHOLD,
            /// <summary>
            /// Annullamento del tocco continuo di una penna.
            /// </summary>
            GT_PEN_PRESSANDHOLDABORT,
            /// <summary>
            /// Tocco.
            /// </summary>
            GT_TOUCH_TAP,
            /// <summary>
            /// Doppio tocco.
            /// </summary>
            GT_TOUCH_DOUBLETAP,
            /// <summary>
            /// Tocco destro.
            /// </summary>
            GT_TOUCH_RIGHTTAP,
            /// <summary>
            /// Tocco continuo.
            /// </summary>
            GT_TOUCH_PRESSANDHOLD,
            /// <summary>
            /// Annullamento del tocco continuo.
            /// </summary>
            GT_TOUCH_PRESSANDHOLDABORT,
            /// <summary>
            /// Pressione e tocco.
            /// </summary>
            GT_TOUCH_PRESSANDTAP
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        internal enum DWM_SHOWCONTACT : DWORD
        {
            DWMSC_DOWN = 0x00000001,
            DWMSC_UP = 0x00000002,
            DWMSC_DRAG = 0x00000004,
            DWMSC_HOLD = 0x00000008,
            DWMSC_PENBARREL = 0x00000010,
            DWMSC_NONE = 0x00000000,
            DWMSC_ALL = 0xFFFFFFFF
        }

        /// <summary>
        /// Identifica l'obbiettivo.
        /// </summary>
        internal enum DWMTRANSITION_OWNEDWINDOW_TARGET
        {
            /// <summary>
            /// Nessuna animazione.
            /// </summary>
            DWMTRANSITION_OWNEDWINDOW_NULL = -1,
            /// <summary>
            /// La finestra viene riposizionata.
            /// </summary>
            DWMTRANSITION_OWNEDWINDOW_REPOSITION
        }

        /// <summary>
        /// Valori usati dal campo <see cref="DWM_THUMBNAIL_PROPERTIES.Flags"/>, indica quali campi della struttura contengono informazioni valide.
        /// </summary>
        [Flags]
        internal enum DwmThumbnailProperties : DWORD
        {
            /// <summary>
            /// Il campo <see cref="DWM_THUMBNAIL_PROPERTIES.Destination"/> è valido.
            /// </summary>
            DWM_TNP_RECTDESTINATION = 0x00000001,
            /// <summary>
            /// Il campo <see cref="DWM_THUMBNAIL_PROPERTIES.Source"/> è valido.
            /// </summary>
            DWM_TNP_RECTSOURCE = 0x00000002,
            /// <summary>
            /// Il campo <see cref="DWM_THUMBNAIL_PROPERTIES.Opacity"/> è valido.
            /// </summary>
            DWM_TNP_OPACITY = 0x00000004,
            /// <summary>
            /// Il campo <see cref="DWM_THUMBNAIL_PROPERTIES.Visible"/> è valido.
            /// </summary>
            DWM_TNP_VISIBLE = 0x00000008,
            /// <summary>
            /// Il campo <see cref="DWM_THUMBNAIL_PROPERTIES.SourceClientAreaOnly"/> è valido.
            /// </summary>
            DWM_TNP_SOURCECLIENTAREAONLY = 0x00000010
        }
    }
}