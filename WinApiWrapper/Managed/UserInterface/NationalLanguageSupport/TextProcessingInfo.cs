using System.Collections;
using static WinApiWrapper.Managed.UserInterface.NationalLanguageSupport.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni sui ruoli di un carattere nell'elaborazione del testo.
    /// </summary>
    public class TextProcessingInfo : CharacterInfo
    {
        /// <summary>
        /// Informazioni sul ruolo del carattere nell'elaborazione del testo.
        /// </summary>
        public TextProcessing[] CharacterTextProcessingInfo { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="TextProcessingInfo"/>.
        /// </summary>
        /// <param name="Character">Carattere.</param>
        /// <param name="TextProcessingInfo">Ruolo del carattere nell'elabotazione del testo.</param>
        internal TextProcessingInfo(char Character, StringTextProcessingValues TextProcessingInfo) : base(Character)
        {
            List<TextProcessing> TextProcessingRoles = new();
            ushort[] Values = (ushort[])Enum.GetValues(typeof(StringTextProcessingValues));
            foreach (ushort value in Values)
            {
                if (TextProcessingInfo.HasFlag((StringTextProcessingValues)value))
                {
                    TextProcessingRoles.Add((TextProcessing)value);
                }
            }
            CharacterTextProcessingInfo = TextProcessingRoles.ToArray();
        }
    }
}