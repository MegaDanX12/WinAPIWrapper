using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;

namespace WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration
{
    /// <summary>
    /// Strutture usate per la configurazione del sistema.
    /// </summary>
    internal static class ConfigurationStructures
    {
        /// <summary>
        /// Informazioni sugli effetti delle animazioni associate con le azioni dell'utente.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct ANIMATIONINFO
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// true se le animazioni relative alla minimizazione e al ripristino delle finestre sono attive, false altrimenti.
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public bool MinAnimate;
        }

        /// <summary>
        /// Metriche scalabili associate con le finestre minimizzate.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MINIMIZEDMETRICS
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Larghezza delle finestre minimizzate, in pixel.
            /// </summary>
            public int Width;
            /// <summary>
            /// Spazio orizzontale tra finestre minimizzate ordinate, in pixel.
            /// </summary>
            public int HorizontalGap;
            /// <summary>
            /// Spazio verticale tra finestre minizzate ordinate, in pixel.
            /// </summary>
            public int VerticalGap;
            /// <summary>
            /// Posizione di partenza e direzione usate per ordinare le finestre minimizzate.
            /// </summary>
            /// <remarks>I valori validi sono presenti nell'enumerazione <see cref="MinimizedWindowArrangeSettings"/></remarks>
            public int Arrange;
        }

        /// <summary>
        /// Metriche scalabili associate con l'area non client di una finestra non minimizzata.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NONCLIENTMETRICS
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Spessore del bordo di ridimensionamento, in pixel.
            /// </summary>
            /// <remarks>Il valore predefinito è 1.</remarks>
            public int BorderWidth;
            /// <summary>
            /// Larghezza di una barra di scorrimento verticale standard, in pixel.
            /// </summary>
            public int ScrollWidth;
            /// <summary>
            /// Altezza di una barra di scorrimento orizzontale standard, in pixel.
            /// </summary>
            public int ScrollHeight;
            /// <summary>
            /// Larghezza dei pulsanti sulla barra del titolo, in pixel.
            /// </summary>
            public int CaptionWidth;
            /// <summary>
            /// Altezza dei pulsanti sulla barra del titolo, in pixel.
            /// </summary>
            public int CaptionHeight;
            /// <summary>
            /// Struttura <see cref="LOGFONT"/> che contiene le informazioni sul font della barra del titolo.
            /// </summary>
            public LOGFONT CaptionFont;
            /// <summary>
            /// Larghezza dei pulsanti piccoli sulla barra del titolo, in pixel.
            /// </summary>
            public int SmCaptionWidth;
            /// <summary>
            /// Altezza dei pulsanti piccoli sulla barra del titolo, in pixel.
            /// </summary>
            public int SmCaptionHeight;
            /// <summary>
            /// Struttura <see cref="LOGFONT"/> che contiene le informazioni sul font usato dalle barre del titolo piccole.
            /// </summary>
            public LOGFONT SmCaptionFont;
            /// <summary>
            /// Larghezza dei pulsanti della barra dei menù, in pixel.
            /// </summary>
            public int MenuWidth;
            /// <summary>
            /// Altezza dei pulsanti della barra dei menù, in pixel.
            /// </summary>
            public int MenuHeight;
            /// <summary>
            /// Struttura <see cref="LOGFONT"/> che contiene le informazioni sul font usato nelle barre dei menù.
            /// </summary>
            public LOGFONT MenuFont;
            /// <summary>
            /// Struttura <see cref="LOGFONT"/> che contiene le informazioni sul font usato nelle barre di stato e nei tooltip.
            /// </summary>
            public LOGFONT StatusFont;
            /// <summary>
            /// Struttura <see cref="LOGFONT"/> che contiene le informazioni sul font usato nelle finestre di messaggio.
            /// </summary>
            public LOGFONT MessageFont;
            /// <summary>
            /// Spessore del bordo imbottito, in pixel.
            /// </summary>
            /// <remarks>Il valore predefinito è 4.</remarks>
            public int PaddedBorderWidth;
        }
    }
}