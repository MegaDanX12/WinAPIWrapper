using static WinApiWrapper.UserInterface.Accessibility.AccessibilityEnumerations;

namespace WinApiWrapper.UserInterface.Accessibility
{
    /// <summary>
    /// Strutture accessibilità.
    /// </summary>
    internal static class AccessibilityStructures
    {
        /// <summary>
        /// Informazioni sul periodo di timeout delle funzionalità di accessibilità.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct ACCESSTIMEOUT
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Comportamento del timeout delle funzionalità di accessibiltaà.
            /// </summary>
            public AccessTimeoutFlags Flags;

            /// <summary>
            /// Tempo di timeout, in millisecondi.
            /// </summary>
            public DWORD Timeout;
        }

        /// <summary>
        /// Informazioni su Filtro Tasti.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct FILTERKEYS
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public FilterKeysProperties Flags;
            /// <summary>
            /// Tempo, in millisecondi, che l'utente deve tenere premuto un tasto prima che sia accettato dal computer.
            /// </summary>
            public DWORD WaitMilliseconds;
            /// <summary>
            /// Tempo, in millisecondi, che l'utente deve tenere premuto un tasto prima che si ripeta.
            /// </summary>
            public DWORD DelayMilliseconds;
            /// <summary>
            /// Tempo, in millisecondi, tra la ripetizione del tasto.
            /// </summary>
            public DWORD RepeatMilliseconds;
            /// <summary>
            /// Tempo, in millisecondi, che deve passare dopo il rilascio del tasto prima che il computer accetti una nuova pressione dello stesso tasto.
            /// </summary>
            public DWORD BounceMilliseconds;
        }

        /// <summary>
        /// Informazioni sulla funzionalità Alto Contrasto.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct HIGHCONTRAST
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public HighContrastProperties Flags;
            /// <summary>
            /// Schema di colori di default.
            /// </summary>
            public string DefaultScheme;
        }

        /// <summary>
        /// Informazioni sulla funzionalità MouseKeys.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEKEYS
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public MouseKeysProperties Flags;
            /// <summary>
            /// Massima velocità del cursore quando una freccia direzionale è tenuta premuta.
            /// </summary>
            public DWORD MaxSpeed;
            /// <summary>
            /// Tempo, in millisecondi, necessario al cursore per raggiungere la massima velocità quando una freccia direzionale è tenuta premuta.
            /// </summary>
            /// <remarks>I valori validi vanno da 1000 a 5000.</remarks>
            public DWORD TimeToMaxSpeed;
            /// <summary>
            /// Moltiplicatore da applicare alla velocità del cursore del mouse quando l'utente tiene premuto il tasto CTRL mentre usa le frecce direzionali per muovere il cursore, questo valore viene ignorato se <see cref="MouseKeysProperties.MKF_MODIFIERS"/> non è impostato.
            /// </summary>
            public DWORD CtrlSpeed;
            /// <summary>
            /// Riservato per uso futuro, deve essere impostato a 0.
            /// </summary>
            private DWORD Reserved1;
            /// <summary>
            /// Riservato per uso futuro, deve essere impostato a 0.
            /// </summary>
            private DWORD Reserved2;
        }

        /// <summary>
        /// Informazioni sulla funzionalità SerialKeys.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct SERIALKEYS
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public SerialKeysProperties Flags;
            /// <summary>
            /// Nome della porta seriale che riceve l'input quando la funzionelità è attiva.
            /// </summary>
            /// <remarks>Se nessuna porta è in uso questa campo è nullo.<br/>
            /// Se questo campo ha valore Auto, il sistema controlla tutte le porte seriali non utilizzate per input.</remarks>
            public string ActivePort;
            /// <summary>
            /// Riservato, deve essere nullo.
            /// </summary>
            private string Port;
            /// <summary>
            /// Velocità di trasmissione per la porta seriale specificata da <see cref="ActivePort"/>.
            /// </summary>
            /// <remarks>Se <see cref="ActivePort"/> è nullo, questo campo ha valore 0.</remarks>
            public uint BaudRate;
            /// <summary>
            /// Stato della porta specificata da <see cref="ActivePort"/>.
            /// </summary>
            /// <remarks>Se <see cref="ActivePort"/> è nullo, questo campo ha valore 0.</remarks>
            public SerialKeysPortState PortState;
            /// <summary>
            /// Porta attiva.
            /// </summary>
            public uint Active;
        }

        /// <summary>
        /// Informazioni sulla funzionalità SoundSentry.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct SOUNDSENTRY
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public SoundSentryProperties Flags;
            /// <summary>
            /// Segnale visuale da mostrare quando un'applicazione in modalità testo genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
            /// </summary>
            public SoundSentryTextEffect TextEffect;
            /// <summary>
            /// Durata, in millisecondi, del segnale visuale specificato da <see cref="TextEffect"/>.
            /// </summary>
            public DWORD TextEffectMilliseconds;
            /// <summary>
            /// Valore RGB del colore da usare per il segnale visuale specificato da <see cref="TextEffect"/>.
            /// </summary>
            public DWORD TextEffectColorBits;
            /// <summary>
            /// Segnale visuale da mostrare quando un'applicazione in modalità grafica genera un suono mentre è in esecuzione in una macchina virtuale a schermo intero.
            /// </summary>
            public SoundSentryGrafEffect GrafEffect;
            /// <summary>
            /// Durata, in millisecondi, del segnale visuale specificato da <see cref="GrafEffect"/>.
            /// </summary>
            public DWORD GrafEffectMilliseconds;
            /// <summary>
            /// Valore RGB del colore da usare per il segnale visuale specificato da <see cref="GrafEffect"/>.
            /// </summary>
            public DWORD GrafEffectColor;
            /// <summary>
            /// Segnale visuale da visualizzare quando un suono viene generato da un'applicazione basata su Windows o da un'applicazione MS-DOS in esecuzione in una finestra.
            /// </summary>
            public SoundSentryWindowsEffect WindowsEffect;
            /// <summary>
            /// Durata, in millisecondi, del segnale visuale specificato da <see cref="WindowsEffect"/>.
            /// </summary>
            public DWORD WindowsEffectMilliseconds;
            /// <summary>
            /// Riservato per uso futuro, deve essere nullo.
            /// </summary>
            private string WindowsEffectDLL;
            /// <summary>
            /// Riservato per uso futuro, deve essere nullo.
            /// </summary>
            private string WindowsEffectOrdinal;
        }

        /// <summary>
        /// Informazioni sulla funzionalità Tasti permanenti.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct STICKYKEYS
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;

            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public StickyKeysProperties Flags;
        }

        /// <summary>
        /// Informazioni sulla funzionalità ToogleKeys.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct TOGGLEKEYS
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Proprietà della funzionalità.
            /// </summary>
            public ToggleKeysProperties Flags;
        }

        /// <summary>
        /// Informazioni sulle descrizioni audio.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct AUDIODESCRIPTION
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Indica se le descrizioni audio sono attivate.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public BOOL Enabled;
            /// <summary>
            /// L'identificatore località del linguaggio delle descrizioni audio.
            /// </summary>
            public LCID Locale;
        }
    }
}