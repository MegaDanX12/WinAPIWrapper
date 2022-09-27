namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Enumerazione accessibilità.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Tipo di puntatore.
        /// </summary>
        public enum PointerType
        {
            /// <summary>
            /// Puntatore generico.
            /// </summary>
            Generic = 1,
            /// <summary>
            /// Tocco.
            /// </summary>
            Touch,
            /// <summary>
            /// Penna.
            /// </summary>
            Pen,
            /// <summary>
            /// Mouse.
            /// </summary>
            Mouse,
            /// <summary>
            /// Touchpad.
            /// </summary>
            Touchpad
        }

        /// <summary>
        /// Effetto applicato dalla funzionalità SoundSentry alle finestre.
        /// </summary>
        public enum SoundSentryWindowsEffect
        {
            /// <summary>
            /// Nessun segnale visuale.
            /// </summary>
            None,
            /// <summary>
            /// La barra del titolo della finestra attiva lampeggia.
            /// </summary>
            TitleBlink,
            /// <summary>
            /// La finestra attiva lampeggia.
            /// </summary>
            ActiveWindowBlink,
            /// <summary>
            /// Il display lampeggia.
            /// </summary>
            DisplayBlink,
            /// <summary>
            /// Segnale visuale personalizzato.
            /// </summary>
            CustomEffect
        }

        /// <summary>
        /// Segnale visuale da mostrare quando un'applicazione in modalità testo genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
        /// </summary>
        public enum SoundSentryTextEffect
        {
            /// <summary>
            /// Nessun segnale visuale.
            /// </summary>
            None,
            /// <summary>
            /// I caratteri all'angolo dello schermo lampeggiano.
            /// </summary>
            CharBlink,
            /// <summary>
            /// Il bordo dello schermo lampeggia.
            /// </summary>
            ScreenBorderBlink,
            /// <summary>
            /// Il display lampeggia.
            /// </summary>
            DisplayBlink
        }

        /// <summary>
        /// Segnale visuale da mostrare quando un'applicazione in modalità grafica genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
        /// </summary>
        public enum SoundSentryGrafEffect
        {
            /// <summary>
            /// Nessun segnale visuale.
            /// </summary>
            None,
            /// <summary>
            /// Il display lampeggia.
            /// </summary>
            DisplayBlink = 3
        }
    }
}