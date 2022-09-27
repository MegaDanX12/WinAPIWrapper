using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportStructures;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni su una code page.
    /// </summary>
    public class CodePageInfo
    {
        /// <summary>
        /// Dimensione, in bytes, di un carattere nella code page.
        /// </summary>
        public int MaxCharacterSize { get; }

        /// <summary>
        /// Carattere predefinito usato durante la traduzione di stringhe nella code page.
        /// </summary>
        public char DefaultChar { get; }

        /// <summary>
        /// Valori iniziali e finali dei byte iniziali della code page.
        /// </summary>
        public Tuple<byte, byte>[]? LeadBytes { get; }

        /// <summary>
        /// Carattere Unicode predefinito usato in traduzioni dalla code page.
        /// </summary>
        public char UnicodeDefaultChar { get; }

        /// <summary>
        /// ID della code page.
        /// </summary>
        public int CodePage { get; }

        /// <summary>
        /// Nome completo localizzato della codepage.
        /// </summary>
        public string CodePageName { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="CodePageInfo"/>.
        /// </summary>
        /// <param name="CodePageInfo">Struttura <see cref="CPINFOEX"/> con le informazioni.</param>
        internal CodePageInfo(CPINFOEX CodePageInfo)
        {
            MaxCharacterSize = (int)CodePageInfo.MaxCharSize;
            CodePage = (int)CodePageInfo.CodePage;
            DefaultChar = BitConverter.ToChar(CodePageInfo.DefaultChar, 0);
            if (CodePageInfo.LeadByte.All((item) => item == 0))
            {
                LeadBytes = null;
            }
            else
            {
                Tuple<byte, byte>[] LeadByteRanges = new Tuple<byte, byte>[5];
                for (int i = 0; i < LeadByteRanges.Length; i++)
                {
                    LeadByteRanges[i] = new Tuple<byte, byte>(CodePageInfo.LeadByte[i], CodePageInfo.LeadByte[i + 1]);
                }
            }
            UnicodeDefaultChar = CodePageInfo.UnicodeDefaultChar;
            char[] StringValueAsArray = CodePageInfo.CodePageName.Where((item) => item is not '\0').ToArray();
            CodePageName = new string(StringValueAsArray);
        }
    }
}