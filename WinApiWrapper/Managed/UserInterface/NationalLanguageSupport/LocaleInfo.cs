using static WinApiWrapper.Managed.UserInterface.NationalLanguageSupport.Enumerations;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni su una località.
    /// </summary>
    public class LocaleInfo
    {
        /// <summary>
        /// Nome località.
        /// </summary>
        public string LocaleName { get; }

        /// <summary>
        /// Tipo località.
        /// </summary>
        public LocaleType? LocaleType { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="LocaleInfo"/>.
        /// </summary>
        /// <param name="LocaleName">Nome località.</param>
        /// <param name="LocaleType">Tipo località.</param>
        internal LocaleInfo(string LocaleName, LocaleType? LocaleType)
        {
            this.LocaleType = LocaleType;
            this.LocaleName = LocaleName;

        }
    }
}