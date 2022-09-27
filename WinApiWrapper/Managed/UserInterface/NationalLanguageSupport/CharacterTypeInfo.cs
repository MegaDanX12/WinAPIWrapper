using static WinApiWrapper.Managed.UserInterface.NationalLanguageSupport.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportEnumerations;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni sul tipo di carattere.
    /// </summary>
    public class CharacterTypeInfo : CharacterInfo
    {
        /// <summary>
        /// Informazioni sul tipo.
        /// </summary>
        public CharacterTypes[] Types { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="CharacterTypeInfo"/>.
        /// </summary>
        /// <param name="Character">Carattere.</param>
        /// <param name="CharacterInfo">Valore a 16 bit che contiene le informazioni sul carattere.</param>
        internal CharacterTypeInfo(char Character, CharacterTypeValues CharacterInfo) : base(Character)
        {
            List<CharacterTypes> TypesList = new();
            ushort[] Values = (ushort[])Enum.GetValues(typeof(CharacterTypeValues));
            foreach (ushort value in Values)
            {
                if (CharacterInfo.HasFlag((CharacterTypeValues)value))
                {
                    TypesList.Add((CharacterTypes)value);
                }
            }
            Types = TypesList.ToArray();
        }
    }
}