namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Enumerazioni DWM.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// Motivo per cui una finestra è nascosta.
        /// </summary>
        public enum WindowCloakedReason
        {
            /// <summary>
            /// L'applicazione proprietaria ha nascosto la finestra.
            /// </summary>
            App = 1,
            /// <summary>
            /// La shell ha nascosto la finestra.
            /// </summary>
            Shell,
            /// <summary>
            /// La finestra proprietaria determina lo stato.
            /// </summary>
            Inherited = 4
        }

        /// <summary>
        /// Politica di rendering dell'area non client.
        /// </summary>
        public enum NonClientAreaRenderingPolicy
        {
            /// <summary>
            /// L'area non client viene renderizzata in base allo stile della finestra.
            /// </summary>
            UseWindowStyle,
            /// <summary>
            /// Il rendering dell'area non client è disattivato.
            /// </summary>
            Disabled,
            /// <summary>
            /// Il rendering dell'area non client è attivato.
            /// </summary>
            Enabled
        }

        /// <summary>
        /// Politica Flip3D.
        /// </summary>
        public enum Flip3DWindowPolicy
        {
            /// <summary>
            /// Usa gli stili della finestra per determinare la politica Flip3D.
            /// </summary>
            UseWindowStyle,
            /// <summary>
            /// Esclude la finestra da Flip3D e la visualizza sotto il rendering della funzionalità.
            /// </summary>
            ExcludeAndDisplayBelow,
            /// <summary>
            /// Esclude la finestra da Flip3D e la visualizza sopra il rendering della funzionalità.
            /// </summary>
            ExcludeAndDisplayAbove
        }

        /// <summary>
        /// Preferenza per gli angoli arrotondati.
        /// </summary>
        public enum WindowCornerPreference
        {
            /// <summary>
            /// Lascia decidere al sistema quando arrotondare gli angoli delle finestre.
            /// </summary>
            LetSystemDecide,
            /// <summary>
            /// Non arrotondare mai gli angoli delle finestre.
            /// </summary>
            DoNotRound,
            /// <summary>
            /// Arrotonda gli angoli se appropriato.
            /// </summary>
            RoundIfAppropriate,
            /// <summary>
            /// Arrotonda gli angoli, se appropriato, usando un raggio piccolo.
            /// </summary>
            RoundIfAppropriateSmallRadius
        }

        /// <summary>
        /// Tipo di gesto.
        /// </summary>
        public enum GestureType
        {
            /// <summary>
            /// Tocco di una penna.
            /// </summary>
            PenTap,
            /// <summary>
            /// Doppio tocco di una penna.
            /// </summary>
            PenDoubleTap,
            /// <summary>
            /// Tocco destro di una penna.
            /// </summary>
            PenRightTap,
            /// <summary>
            /// Tocco continuo di una penna.
            /// </summary>
            PenPressAndHold,
            /// <summary>
            /// Annullamento del tocco continuo di una penna.
            /// </summary>
            PenPressAndHoldAbort,
            /// <summary>
            /// Tocco.
            /// </summary>
            TouchTap,
            /// <summary>
            /// Doppio tocco.
            /// </summary>
            TouchDoubleTap,
            /// <summary>
            /// Tocco destro.
            /// </summary>
            TouchRightTap,
            /// <summary>
            /// Tocco continuo.
            /// </summary>
            TouchPressAndHold,
            /// <summary>
            /// Annullamento del tocco continuo.
            /// </summary>
            TouchPressAndHoldAbort,
            /// <summary>
            /// Pressione e tocco.
            /// </summary>
            TouchPressAndTap
        }

        /// <summary>
        /// Tipo di contatto.
        /// </summary>
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro visibile pubblicamente
        [Flags]
        public enum ContactType : uint
        {
            Down = 0x00000001,
            Up = 0x00000002,
            Drag = 0x00000004,
            Hold = 0x00000008,
            PenBarrel = 0x00000010,
            None = 0x00000000,
            All = 0xFFFFFFFF
        }
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro visibile pubblicamente

        /// <summary>
        /// Transizione per le finestre di utilità.
        /// </summary>
        public enum ToolWindowTransition
        {
            /// <summary>
            /// Nessuna transizione.
            /// </summary>
            None = -1,
            /// <summary>
            /// Riposiziona la finestra.
            /// </summary>
            RepositionWindow
        }
    }
}