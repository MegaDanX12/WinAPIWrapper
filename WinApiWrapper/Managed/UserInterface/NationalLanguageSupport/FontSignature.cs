using System.Collections;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportStructures;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni relative alle code page ai range Unicode dei quali un font fornisce glifi.
    /// </summary>
    public class FontSignature
    {
        /// <summary>
        /// Subset Unicode supportati dal font.
        /// </summary>
        public UnicodeSubsetInfo[] SupportedSubsets { get; }

        /// <summary>
        /// Code page supportati dal font.
        /// </summary>
        public SupportedCodePageInfo[] SupportedCodePages { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="FontSignature"/>.
        /// </summary>
        /// <param name="Signature"></param>
        internal FontSignature(LOCALESIGNATURE Signature)
        {
            BitArray UsbBits = new(Array.ConvertAll(Signature.UnicodeSubsetBitfield, (item) => (int)item));
            BitArray CodePageDefaultBits = new(Array.ConvertAll(Signature.CodePageBitfieldsDefault, (item) => (int)item));
            BitArray CodePageSupportedBits = new(Array.ConvertAll(Signature.CodePageBitfieldsSupported, (item) => (int)item));
            List<UnicodeSubsetInfo> SupportedUnicodeSubsets = new();
            List<SupportedCodePageInfo> SupportedCodePagesData = new();
            (string Range, string Description)[] Data;
            for (int i = 0; i < UsbBits.Count - 2; i++)
            {
                if (UsbBits[i])
                {
                    Data = NLSManaged.UnicodeSubsetBitfields[(byte)i];
                    foreach ((string, string) SubrangeData in Data)
                    {
                        SupportedUnicodeSubsets.Add(new UnicodeSubsetInfo(SubrangeData.Item1, SubrangeData.Item2));
                    }
                }
            }
            (string Codepage, string Description) CPData;
            for (int i = 0; i < CodePageSupportedBits.Count; i++)
            {
                if (CodePageSupportedBits[i])
                {
                    if (i is < 8 or > 15 && i is < 22 or > 46)
                    {
                        if (i is 61)
                        {
                            CPData = NLSManaged.CodePageBitFields[(byte)i];
                            string[] CodePages = CPData.Codepage.Split(';');
                            string[] Descriptions = CPData.Codepage.Split(';');
                            for (int j = 0; j < CodePages.Length; j++)
                            {
                                SupportedCodePagesData.Add(new SupportedCodePageInfo(CodePages[j], Descriptions[j]));
                            }
                        }
                        else
                        {
                            CPData = NLSManaged.CodePageBitFields[(byte)i];
                            SupportedCodePagesData.Add(new SupportedCodePageInfo(CPData.Codepage, CPData.Description));
                        }
                    }
                }

            }
            SupportedSubsets = SupportedUnicodeSubsets.ToArray();
            SupportedCodePages = SupportedCodePagesData.ToArray();
        }
    }
}