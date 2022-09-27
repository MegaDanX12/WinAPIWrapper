using WinApiWrapper.Managed.GraphicsAndMultimedia.Fonts;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationStructures;

namespace WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Configuration
{
    /// <summary>
    /// Metriche scalabili relative all'area non client di finestre non minimizzate.
    /// </summary>
    public class NonClientMetricsInfo
    {
        /// <summary>
        /// Spessore del bordo di ridimensionamento, in pixel.
        /// </summary>
        public int BorderWidth { get; }

        /// <summary>
        /// Larghezza della barra di scorrimento verticale standard, in pixel.
        /// </summary>
        public int ScrollWidth { get; }

        /// <summary>
        /// Altezza della barra di scorrimento orizzontale, in pixel.
        /// </summary>
        public int ScrollHeight { get; }

        /// <summary>
        /// Larghezza dei pulsanti sulla barra del titolo, in pixel.
        /// </summary>
        public int CaptionWidth { get; }

        /// <summary>
        /// Altezza dei pulsanti sulla barra del titolo, in pixel.
        /// </summary>
        public int CaptionHeight { get; }

        /// <summary>
        /// Font usato sulla barra del titolo.
        /// </summary>
        public FontInfo CaptionFont { get; }

        /// <summary>
        /// Larghezza dei pulsanti piccoli sulla barra del titolo, in pixel.
        /// </summary>
        public int SmallCaptionWidth { get; }

        /// <summary>
        /// Altezza dei pulsanti piccoli sulla barra dei titolo, in pixel.
        /// </summary>
        public int SmallCaptionHeight { get; }

        /// <summary>
        /// Font usato sulla barra del titolo piccola.
        /// </summary>
        public FontInfo SmallCaptionFont { get; }

        /// <summary>
        /// Larghezza dei pulsanti delle barre dei menù, in pixel.
        /// </summary>
        public int MenuWidth { get; }

        /// <summary>
        /// Altezza dei pulsanti delle barre dei menù, in pixel.
        /// </summary>
        public int MenuHeight { get; }

        /// <summary>
        /// Font usato nelle barre dei menù.
        /// </summary>
        public FontInfo MenuFont { get; }

        /// <summary>
        /// Font usato nelle barre di stato e nei tooltip.
        /// </summary>
        public FontInfo StatusFont { get; }

        /// <summary>
        /// Font usato nelle finestre di messaggio.
        /// </summary>
        public FontInfo MessageFont { get; }

        /// <summary>
        /// Spessore del bordo imbottito, in pixel.
        /// </summary>
        public int PaddedBorderWidth { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="NonClientMetricsInfo"/>.
        /// </summary>
        /// <param name="DataStructure">Struttura <see cref="NONCLIENTMETRICS"/> con le informazioni.</param>
        internal NonClientMetricsInfo(NONCLIENTMETRICS DataStructure)
        {
            BorderWidth = DataStructure.BorderWidth;
            ScrollWidth = DataStructure.ScrollWidth;
            ScrollHeight = DataStructure.ScrollHeight;
            CaptionWidth = DataStructure.CaptionWidth;
            CaptionHeight = DataStructure.CaptionHeight;
            CaptionFont = new(DataStructure.CaptionFont);
            SmallCaptionWidth = DataStructure.SmCaptionWidth;
            SmallCaptionHeight = DataStructure.SmCaptionHeight;
            SmallCaptionFont = new(DataStructure.SmCaptionFont);
            MenuWidth = DataStructure.MenuWidth;
            MenuHeight = DataStructure.MenuHeight;
            MenuFont = new(DataStructure.MenuFont);
            StatusFont = new(DataStructure.StatusFont);
            MessageFont = new(DataStructure.MessageFont);
            PaddedBorderWidth = DataStructure.PaddedBorderWidth;
        }
    }
}