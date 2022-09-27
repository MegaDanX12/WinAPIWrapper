namespace WinApiWrapper.UserInterface.Accessibility
{
    /// <summary>
    /// Enumerazione accessibilità.
    /// </summary>
    internal static class AccessibilityEnumerations
    {
        /// <summary>
        /// Tipi di input puntatore.
        /// </summary>
        internal enum POINTER_INPUT_TYPE
        {
            /// <summary>
            /// Puntatore generico.
            /// </summary>
            PT_POINTER = 1,
            /// <summary>
            /// Tocco.
            /// </summary>
            PT_TOUCH,
            /// <summary>
            /// Penna.
            /// </summary>
            PT_PEN,
            /// <summary>
            /// Mouse.
            /// </summary>
            PT_MOUSE,
            /// <summary>
            /// Touchpad.
            /// </summary>
            PT_TOUCHPAD
        }

        /// <summary>
        /// Effetto applicato dalla funzionalità SoundSentry alle finestre.
        /// </summary>
        internal enum SoundSentryWindowsEffect : DWORD
        {
            /// <summary>
            /// Nessun segnale visuale.
            /// </summary>
            None,
            /// <summary>
            /// La barra del titolo della finestra attiva lampeggia.
            /// </summary>
            Title,
            /// <summary>
            /// La finestra attiva lampeggia.
            /// </summary>
            Window,
            /// <summary>
            /// Il display lampeggia.
            /// </summary>
            Display,
            /// <summary>
            /// Segnale visuale personalizzato.
            /// </summary>
            Custom
        }

        /// <summary>
        /// Comportamento del timeout delle funzionalità di accessibilità.
        /// </summary>
        [Flags]
        internal enum AccessTimeoutFlags : DWORD
        {
            /// <summary>
            /// Indica se il sistema operativo riproduce un suono quando il tempo di timeout è scaduto e le funzionalità di accessibilità sono disattivate.
            /// </summary>
            ATF_ONOFFFEEDBACK = 0x00000002,
            /// <summary>
            /// Indica se è impostato un timeout per le funzionalità di accessibilità, se non è impostato il periodo di timeout verrà ignorato anche se impostato.
            /// </summary>
            ATF_TIMEOUTON = 0x00000001
        }

        /// <summary>
        /// Proprietà della funzionalità Filtro Tasti.
        /// </summary>
        [Flags]
        internal enum FilterKeysProperties : DWORD
        {
            /// <summary>
            /// Indica se la funzionalità è disponibile.
            /// </summary>
            FKF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Indica se il computer riproduce un click quando un tasto viene premuto o accettato, se SlowKeys è attivo, un click viene generato quando il tasto viene premuto e di nuovo quando viene accettato.
            /// </summary>
            FKF_CLICKON = 0x00000040,
            /// <summary>
            /// Una finestra di dialogo di conferma viene attivata quando la funzionalità viene attivata usando la combinazione di tasti.
            /// </summary>
            FKF_CONFIRMHOTKEY = 0x00000008,
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            FKF_FILTERKEYSON = 0x00000001,
            /// <summary>
            /// Indica se la funzionalità può essere attivata o disattivata tenendo premuto lo SHIFT desto per 8 secondi.
            /// </summary>
            FKF_HOTKEYACTIVE = 0x00000004,
            /// <summary>
            /// Indica se il computer riprodurra un suono quando l'utente attiva o disattiva la funzionalità usando la combinazione di tasti.
            /// </summary>
            FKF_HOTKEYSOUND = 0x00000010,
            /// <summary>
            /// Un indicatore visuale viene visualizzato quando la funzionalità è attiva.
            /// </summary>
            FKF_INDICATOR = 0x00000020
        }

        /// <summary>
        /// Proprietà della funzionalità Alto Contrasto.
        /// </summary>
        [Flags]
        internal enum HighContrastProperties : DWORD
        {
            /// <summary>
            /// Indica se l'alto contrasto è attivato.
            /// </summary>
            HCF_HIGHCONTRASTON = 0x00000001,
            /// <summary>
            /// Indica se l'alto contrasto è disponibile.
            /// </summary>
            HCF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Indica che l'utente può attivare o disattivare la funzionalità tramite la combinazione di tasti ALT + SHIFT sinistro + PRINT SCREEN.
            /// </summary>
            HCF_HOTKEYACTIVE = 0x00000004,
            /// <summary>
            /// Indica se una finestra di dialogo di conferma verrà visualizzata quando la funzionalità viene attivata tramite la combinazione di tasti.
            /// </summary>
            HCF_CONFIRMHOTKEY = 0x00000008,
            /// <summary>
            /// Indica se un suono viene riprodotto quando l'utente attiva o disattiva la funzionalità usando la combinazione di tasti.
            /// </summary>
            HCF_HOTKEYSOUND = 0x00000010,
            /// <summary>
            /// Indica se la combinazione di tasti associata con la funzionalità può essere abilitata, questo valore non può essere impostato dalle applicazioni.
            /// </summary>
            HCF_HOTKEYAVAILABLE = 0x00000040,
            /// <summary>
            /// Questa opzione evita l'invio di messaggi relativi al cambio tema.
            /// </summary>
            /// <remarks>Questa opzione non può essere usata quando l'opzione <see cref="HCF_HIGHCONTRASTON"/> viene attivata.</remarks>
            HCF_OPTION_NOTHEMECHANGE = 0x00001000
        }

        /// <summary>
        /// Proprietà della funzionalità MouseKeys.
        /// </summary>
        [Flags]
        internal enum MouseKeysProperties : DWORD
        {
            /// <summary>
            /// Indica se la funzionalità è disponibile.
            /// </summary>
            MKF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Indica se una finestra di dialogo di conferma verrà visualizzata quando la funzionalità viene attivata tramite la combinazione di tasti.
            /// </summary>
            MKF_CONFIRMHOTKEY = 0x00000008,
            /// <summary>
            /// Indica se una finestra di dialogo di conferma appare quando la funzionalità viene attivata usando la combinazione di tasti.
            /// </summary>
            MKF_HOTKEYACTIVE = 0x00000004,
            /// <summary>
            /// Indica se il sistema emette un suono quando la funzionalità è attivata o disattivata tramite la combinazione di tasti.
            /// </summary>
            MKF_HOTKEYSOUND = 0x00000010,
            /// <summary>
            /// Un indicatore visuale viene mostrato quando la funzionalità è attiva.
            /// </summary>
            MKF_INDICATOR = 0x00000020,
            /// <summary>
            /// Il tasto sinistro del mouse è in stato premuto.
            /// </summary>
            MKF_LEFTBUTTONDOWN = 0x01000000,
            /// <summary>
            /// L'utente ha selezionato il tasto sinistro del mouse.
            /// </summary>
            MKF_LEFTBUTTONSEL = 0x10000000,
            /// <summary>
            /// Il tasto CTRL modifica la velocità del cursore del valore specificato dal campo <see cref="AccessibilityStructures.MOUSEKEYS.CtrlSpeed"/>, il tasto SHIFT causa il leggero ritardo del cursore dopo essersi mosso di un singolo pixel permettendo il posizionamento preciso.<br/>
            /// Se questa opzione non è usata i tasti CTRL e SHIFT vengono ignorati quando l'utente muove il cursore del mouse usando le frecce direzionali.
            /// </summary>
            MKF_MODIFIERS = 0x00000040,
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            MKF_MOUSEKEYSON = 0x00000001,
            /// <summary>
            /// Indica se il sistema sta elaborando l'input proveniente dal tastierino numero come comandi del mouse.
            /// </summary>
            MKF_MOUSEMODE = 0x80000000,
            /// <summary>
            /// Indica se il tastierino numerico muove il cursore del mouse quando NUM LOCK è attivato, se questa opzione non è attiva il mouse si muove quando NUM LOCK è disattivato.
            /// </summary>
            MKF_REPLACENUMBERS = 0x00000080,
            /// <summary>
            /// Il tasto destro del mouse è in stato premuto.
            /// </summary>
            MKF_RIGHTBUTTONDOWN = 0x02000000,
            /// <summary>
            /// L'utente ha selezionato il tasto destro del mouse.
            /// </summary>
            MKF_RIGHTBUTTONSEL = 0x20000000
        }

        /// <summary>
        /// Proprietà della funzionalità SerialKeys.
        /// </summary>
        [Flags]
        internal enum SerialKeysProperties : DWORD
        {
            /// <summary>
            /// Indica se la funzionalità è disponibile.
            /// </summary>
            SERKF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Indica se un indicatore visuale viene visualizzato quando la funzionalità è attiva.
            /// </summary>
            /// <remarks>Questo valore non è attualmente in uso e viene ignorato.</remarks>
            SERKF_INDICATOR = 0x00000004,
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            SERKF_SERIALKEYSON = 0x00000001
        }

        /// <summary>
        /// Stato della porta per la funzionalità SerialKeys.
        /// </summary>
        internal enum SerialKeysPortState : uint
        {
            /// <summary>
            /// Tutto l'input viene ignorato.
            /// </summary>
            InputIngnored,
            /// <summary>
            /// L'input viene elaborato quando nessun'altra applicazione ha la porta aperta.
            /// </summary>
            InputWatchedSingleApplication,
            /// <summary>
            /// Tutto l'input viene elaborato.
            /// </summary>
            InputWatched
        }

        /// <summary>
        /// Proprietà della funzionalità SoundSentry.
        /// </summary>
        [Flags]
        internal enum SoundSentryProperties : DWORD
        {
            /// <summary>
            /// Indica se la funzionalità è disponibile.
            /// </summary>
            SSF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Non implementato.
            /// </summary>
            SSF_INDICATOR = 0x00000004,
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            SSF_SOUNDSENTRYON = 0x00000001
        }

        /// <summary>
        /// Segnale visuale da mostrare quando un'applicazione in modalità testo genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
        /// </summary>
        internal enum SoundSentryTextEffect : DWORD
        {
            /// <summary>
            /// Nessun segnale visuale.
            /// </summary>
            SSTF_NONE,
            /// <summary>
            /// I caratteri all'angolo dello schermo lampeggiano.
            /// </summary>
            SSTF_CHARS,
            /// <summary>
            /// Il bordo dello schermo lampeggia.
            /// </summary>
            SSTF_BORDER,
            /// <summary>
            /// Il display lampeggia.
            /// </summary>
            SSTF_DISPLAY
        }

        /// <summary>
        /// Segnale visuale da mostrare quando un'applicazione in modalità grafica genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
        /// </summary>
        internal enum SoundSentryGrafEffect : DWORD
        {
            /// <summary>
            /// Nessun segnale visuale.
            /// </summary>
            SSGF_NONE,
            /// <summary>
            /// Il display lampeggia.
            /// </summary>
            SSGF_DISPLAY = 3
        }

        /// <summary>
        /// Proprietà della funzionalità Tasti permanenti.
        /// </summary>
        [Flags]
        internal enum StickyKeysProperties : DWORD
        {
            /// <summary>
            /// Indica se il sistema riproduce un suono quando l'utente aggancia, blocca o rilascia un tasto modificatore usando la funzionalità.
            /// </summary>
            SFK_AUDIBLEFEEDBACK = 0x00000040,
            /// <summary>
            /// Indica se la funzionalità è disponibile.
            /// </summary>
            SKF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Indica se viene visualizzata una finestra di dialogo di conferma quando la funzionalità è attivata tramite la combinazione di tasti.
            /// </summary>
            SKF_CONFIRMHOTKEY = 0x00000008,
            /// <summary>
            /// Indica se la funzionalità può essere attivata o disattivata premendo il tasto SHIFT 5 volte.
            /// </summary>
            SKF_HOTKEYACTIVE = 0x00000004,
            /// <summary>
            /// Indica se il sistema riproduce una suono quando l'utente attiva la funzionalità usando la combinazione di tasti.
            /// </summary>
            SKF_HOTKEYSOUND = 0x00000010,
            /// <summary>
            /// Indica se viene visualizzato un indicatore visuale quando la funzionalità è attiva.
            /// </summary>
            SKF_INDICATOR = 0x00000020,
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            SKF_STICKYKEYSON = 0x00000001,
            /// <summary>
            /// Indica se premere due di fila un tasto modificatore ne causa il blocco fino a quando l'utente non lo preme una terza volta.
            /// </summary>
            SKF_TRISTATE = 0x00000080,
            /// <summary>
            /// Indica se rilasciare un tasto modificatore che è stato premuto in combinazione con qualunque altro disattiva la funzionalità.
            /// </summary>
            SKF_TWOKEYSOFF = 0x00000100,
            /// <summary>
            /// Indica se il tasto ALT sinistro è agganciato.
            /// </summary>
            SKF_LALTLATCHED = 0x10000000,
            /// <summary>
            /// Indica se il tasto CTRL sinistro è agganciato.
            /// </summary>
            SKF_LCTLLATCHED = 0x04000000,
            /// <summary>
            /// Indica se il tasto SHIFT sinistro è agganciato.
            /// </summary>
            SKF_LSHIFTLATCHED = 0x01000000,
            /// <summary>
            /// Indica se il tasto ALT destro è agganciato.
            /// </summary>
            SKF_RALTLATCHED = 0x20000000,
            /// <summary>
            /// Indica se il tasto CTRL destro è agganciato.
            /// </summary>
            SKF_RCTLLATCHED = 0x08000000,
            /// <summary>
            /// Indica se il tasto SHIFT destro è agganciato.
            /// </summary>
            SKF_RSHIFTLATCHED = 0x02000000,
            /// <summary>
            /// Indica se il tasto ALT sinistro è bloccato.
            /// </summary>
            SFK_LALTLOCKED = 0x00100000,
            /// <summary>
            /// Indica se il tasto CTRL sinistro è bloccato.
            /// </summary>
            SKF_LCTLLOCKED = 0x00040000,
            /// <summary>
            /// Indica se il tasto SHIFT sinistro è bloccato.
            /// </summary>
            SKF_LSHIFTLOCKED = 0x00010000,
            /// <summary>
            /// Indica se il tasto ALT destro è bloccato.
            /// </summary>
            SKF_RALTLOCKED = 0x00200000,
            /// <summary>
            /// Indica se il tasto CTRL destro è bloccato.
            /// </summary>
            SKF_RCTLLOCKED = 0x00080000,
            /// <summary>
            /// Indica se il tasto SHIFT destro è bloccato.
            /// </summary>
            SKF_RSHIFTLOCKED = 0x00020000,
            /// <summary>
            /// Indica se il tasto Windows sinistro è agganciato.
            /// </summary>
            SKF_LWINLATCHED = 0x40000000,
            /// <summary>
            /// Indica se il tasto Windows destro è agganciato.
            /// </summary>
            SKF_RWINLATCHED = 0x80000000,
            /// <summary>
            /// Indica se il tasto Windows sinistro è bloccato.
            /// </summary>
            SKF_LWINLOCKED = 0x00400000,
            /// <summary>
            /// Indica se il tasto Windows destro è bloccato.
            /// </summary>
            SKF_RWINLOCKED = 0x00800000
        }

        /// <summary>
        /// Proprietà della funzionalità ToggleKeys.
        /// </summary>
        [Flags]
        internal enum ToggleKeysProperties : DWORD
        {
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            TKF_AVAILABLE = 0x00000002,
            /// <summary>
            /// Indica se verrà visualizzata un finestra di dialogo di conferma se la funzionalità viene attivata tramite la combinazione di tasti.
            /// </summary>
            TKF_CONFIRMHOTKEY = 0x00000008,
            /// <summary>
            /// Indica se la funzionalità può essere attivata o disattivata tenendo premuto il tasto NUM LOCK per 8 secondi.
            /// </summary>
            TKF_HOTKEYACTIVE = 0x00000004,
            /// <summary>
            /// Indica se il sistema emette un suono quando la funzionalità viene attivata tramite la combinazione di tasti.
            /// </summary>
            TKF_HOTKEYSOUND = 0x00000010,
            /// <summary>
            /// Non implementato.
            /// </summary>
            TKF_INDICATOR = 0x00000020,
            /// <summary>
            /// Indica se la funzionalità è attiva.
            /// </summary>
            TKF_TOGGLEKEYSON = 0x00000001
        }
    }
}