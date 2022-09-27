using System.Drawing;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons.Enumerations;
using WinApiWrapper.Managed.UserInterface.UserInterfaceElements.ImageLists;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Informazioni su uno split button.
    /// </summary>
    public class SplitButtonInfo
    {
        /// <summary>
        /// Informazioni sulla lista immagini associata.
        /// </summary>
        public ImageListInfo ImageListInfo { get; }

        /// <summary>
        /// Stili del pulsante.
        /// </summary>
        public SplitButtonStyles[] Styles { get; }

        /// <summary>
        /// Dimensioni dell'immagine associata.
        /// </summary>
        public Size ImageSize { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="SplitButtonInfo"/>.
        /// </summary>
        /// <param name="Info">Struttura <see cref="BUTTON_SPLITINFO"/> con le informazioni.</param>
        internal SplitButtonInfo(BUTTON_SPLITINFO Info)
        {
            ImageListInfo = new(Info.GlyphHandle);
            Styles = GetButtonStyles(Info.SplitButtonStyle);
            ImageSize = new(Info.GlyphSize.x, Info.GlyphSize.y);
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="SplitButtonInfo"/>.
        /// </summary>
        /// <param name="ImageListInfo">Istanza di <see cref="ImageLists.ManagedInfoClasses.ImageListInfo"/> associata alla lista immagini.</param>
        /// <param name="Style">Stili del pulsante.</param>
        /// <param name="ImageSize">Dimensione dell'immagine.</param>
        public SplitButtonInfo(ImageListInfo ImageListInfo, SplitButtonStyles Style, Size ImageSize)
        {
            this.ImageListInfo = ImageListInfo;
            Styles = GetButtonStyles((SplitButtonStyle)Style);
            this.ImageSize = ImageSize;
        }

        /// <summary>
        /// Recupera gli stili del pulsante.
        /// </summary>
        /// <param name="Styles">Valore composito che includi tutti gli stili applicati.</param>
        /// <returns>Un array di valori contenuti nell'enumerazione <see cref="SplitButtonStyles"/> che rappresentano gli stili applicati al pulsante.</returns>
        private static SplitButtonStyles[] GetButtonStyles(SplitButtonStyle Styles)
        {
            List<SplitButtonStyles> StylesList = new();
            foreach (SplitButtonStyle style in Enum.GetValues(typeof(SplitButtonStyle)))
            {
                if (Styles.HasFlag(style))
                {
                    StylesList.Add((SplitButtonStyles)style);
                }
            }
            return StylesList.ToArray();
        }

        /// <summary>
        /// Restituisce una struttura <see cref="BUTTON_SPLITINFO"/> derivata dai dati di questa istanza.
        /// </summary>
        /// <returns>Struttura <see cref="BUTTON_SPLITINFO"/> con i dati di questa istanza.</returns>
        internal BUTTON_SPLITINFO ToStruct()
        {
            SplitButtonStyle Style = 0;
            foreach (SplitButtonStyles style in Styles)
            {
                Style |= (SplitButtonStyle)style;
            }
            SIZE GlyphSize = new()
            {
                x = ImageSize.Width,
                y = ImageSize.Height
            };
            SplitButtonInfoValidMembers ValidMembers = SplitButtonInfoValidMembers.BCSIF_SIZE | SplitButtonInfoValidMembers.BCSIF_STYLE;
            if (Styles.Contains(SplitButtonStyles.IconAsGlyph))
            {
                ValidMembers |= SplitButtonInfoValidMembers.BCSIF_IMAGE;
            }
            else
            {
                ValidMembers |= SplitButtonInfoValidMembers.BCSIF_GLYPH;
            }
            BUTTON_SPLITINFO Info = new()
            {
                ValidMembers = ValidMembers,
                GlyphHandle = ImageListInfo.Handle,
                SplitButtonStyle = Style,
                GlyphSize = GlyphSize
            };
            return Info;
        }
    }
}