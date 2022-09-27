namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni su una code page supportata.
    /// </summary>
    public class SupportedCodePageInfo
    {
        /// <summary>
        /// ID della code page.
        /// </summary>
        public int CodePageID { get; }

        /// <summary>
        /// Descrizione.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="SupportedCodePageInfo"/>.
        /// </summary>
        /// <param name="CodePageID">ID della code page.</param>
        /// <param name="Description">Descrizione.</param>
        internal SupportedCodePageInfo(string CodePageID, string Description)
        {
            this.CodePageID = Convert.ToInt32(CodePageID);
            this.Description = Description;
        }
    }
}