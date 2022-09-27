using System.Globalization;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni su un subset Unicode.
    /// </summary>
    public class UnicodeSubsetInfo
    {
        /// <summary>
        /// Valore iniziale del subset.
        /// </summary>
        public int? RangeStart { get; }

        /// <summary>
        /// Valore finale del subset.
        /// </summary>
        public int? RangeEnd { get; }

        /// <summary>
        /// Descrizione.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="UnicodeSubsetInfo"/>.
        /// </summary>
        /// <param name="Range">Raggio dei valori che compongono il subset.</param>
        /// <param name="Description">Descrizione del subset.</param>
        internal UnicodeSubsetInfo(string Range, string Description)
        {
            this.Description = Description;
            if (!string.IsNullOrWhiteSpace(Range))
            {
                string[] RangeValues = Range.Split('-');
                int RangeValue;
                if (int.TryParse(RangeValues[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out RangeValue))
                {
                    RangeStart = RangeValue;
                }
                else
                {
                    RangeStart = null;
                }
                if (int.TryParse(RangeValues[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out RangeValue))
                {
                    RangeEnd = RangeValue;
                }
                else
                {
                    RangeEnd = null;
                }
            }
            else
            {
                RangeStart = null;
                RangeEnd = null;
            }

        }
    }
}