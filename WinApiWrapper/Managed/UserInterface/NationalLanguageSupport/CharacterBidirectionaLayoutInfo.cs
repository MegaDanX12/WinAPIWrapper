using static WinApiWrapper.Managed.UserInterface.NationalLanguageSupport.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni sul layout di un carattere.
    /// </summary>
    public class CharacterBidirectionaLayoutInfo : CharacterInfo
    {
        /// <summary>
        /// Informazioni su un layout.
        /// </summary>
        public CharacterBidirectionalLayout LayoutInfo { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="CharacterBidirectionaLayoutInfo"/>.
        /// </summary>
        /// <param name="Character">Carattere.</param>
        /// <param name="LayoutInfo">Informazioni sul layout.</param>
        internal CharacterBidirectionaLayoutInfo(char Character, StringLayoutValues LayoutInfo) : base(Character)
        {
            this.LayoutInfo = (CharacterBidirectionalLayout)LayoutInfo;
        }
    }
}