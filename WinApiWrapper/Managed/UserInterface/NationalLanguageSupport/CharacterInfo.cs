namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni su un carattere.
    /// </summary>
    public abstract class CharacterInfo
    {
        /// <summary>
        /// Carattere.
        /// </summary>
        public char Character { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="CharacterInfo"/>.
        /// </summary>
        /// <param name="Character">Carattere.</param>
        internal CharacterInfo(char Character)
        {
            this.Character = Character;
        }
    }
}