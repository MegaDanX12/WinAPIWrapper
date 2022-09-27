using WinApiWrapper.Managed.GraphicsAndMultimedia.Fonts;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Icons.IconStructures;

namespace WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Configuration
{
    /// <summary>
    /// Metriche scalabili associate alle icone.
    /// </summary>
    public class IconMetricsInfo
    {
        /// <summary>
        /// Spazio orizzontale, in pixel, per ogni icona ordinata.
        /// </summary>
        public int HorizontalSpacing { get; }

        /// <summary>
        /// Spazio verticale, in pixel, per ogni icona ordinata.
        /// </summary>
        public int VerticalSpacing { get; }

        /// <summary>
        /// Indica se i titoli delle icone andranno a capo automaticamente.
        /// </summary>
        public bool TitleWrapActive { get; }

        /// <summary>
        /// Font da usare per i titoli delle icone.
        /// </summary>
        public FontInfo FontInfo { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="IconMetricsInfo"/>.
        /// </summary>
        /// <param name="DataStructure">Struttura <see cref="ICONMETRICS"/> con le informazioni.</param>
        internal IconMetricsInfo(ICONMETRICS DataStructure)
        {
            HorizontalSpacing = DataStructure.HorizontalSpacing;
            VerticalSpacing = DataStructure.VerticalSpacing;
            TitleWrapActive = Convert.ToBoolean(DataStructure.TitleWrap);
            FontInfo = new(DataStructure.Font);
        }
    }
}