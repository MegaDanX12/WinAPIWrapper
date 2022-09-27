using WinApiWrapper.UserInterface.NationalLanguageSupport;
using static WinApiWrapper.Managed.UserInterface.NationalLanguageSupport.Enumerations;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportStructures;

namespace WinApiWrapper.Managed.UserInterface.NationalLanguageSupport
{
    /// <summary>
    /// Informazioni di formattazione per formattare una stringa come numero.
    /// </summary>
    public class NumberFormatInfo
    {
        /// <summary>
        /// Numero di cifre frazionarie.
        /// </summary>
        public int FractionalDigitsCount { get; }

        /// <summary>
        /// Indica se esistono degli zeri iniziali nei campi decimali.
        /// </summary>
        public bool UseLeadingZeros { get; }

        /// <summary>
        /// Numero di cifre in ogni gruppo di numeri alla sinistra del separatore decimale indicato da <see cref="DecimalSeparator"/>.
        /// </summary>
        /// <remarks>La cifra più a sinistra indica il numero di cifre nel gruppo più vicino al separatore, ogni altra cifra indica la dimensione del gruppo di cifre alla sinistra del gruppo precedente.<br/>
        /// Se l'ultimo valore non è 0, i gruppi rimanenti ripetono sono uguali all'ultimo indicato.</remarks>
        public int Grouping { get; }

        /// <summary>
        /// Separatore decimale.
        /// </summary>
        public string DecimalSeparator { get; }

        /// <summary>
        /// Separatore delle migliaia.
        /// </summary>
        public string ThousandSeparator { get; }

        /// <summary>
        /// Formato dei numeri negativi.
        /// </summary>
        public NegativeNumberFormat NegativeNumberFormat { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="CurrencyFormatInfo"/>.
        /// </summary>
        /// <param name="FractionalDigitsCount">Numero di cifre frazionarie.</param>
        /// <param name="UseLeadingZeros">Indica se esistono degli zeri iniziali nei campi decimali.</param>
        /// <param name="Grouping">Numero di cifre in ogni gruppo di numeri alla sinistra del separatore decimale indicato da <see cref="DecimalSeparator"/>.</param>
        /// <param name="DecimalSeparator">Separatore decimale.</param>
        /// <param name="ThousandSeparator">Separatore delle migliaia.</param>
        /// <param name="NegativeFormat">Formato dei numeri negativi.</param>
        public NumberFormatInfo(int FractionalDigitsCount, bool UseLeadingZeros, int Grouping, string DecimalSeparator, string ThousandSeparator, NegativeNumberFormat NegativeFormat)
        {
            this.FractionalDigitsCount = FractionalDigitsCount;
            this.UseLeadingZeros = UseLeadingZeros;
            this.Grouping = Grouping;
            this.DecimalSeparator = DecimalSeparator;
            this.ThousandSeparator = ThousandSeparator;
            NegativeNumberFormat = NegativeFormat;
        }

        /// <summary>
        /// Converte i dati di questa classe in una struttura <see cref="NUMBERFMT"/>.
        /// </summary>
        /// <returns>Struttura <see cref="NUMBERFMT"/> risultato della conversione.</returns>
        internal NUMBERFMT ToStruct()
        {
            NUMBERFMT FormatInfo = new()
            {
                FractionalDigitsCount = (uint)FractionalDigitsCount,
                LeadingZero = Convert.ToUInt32(UseLeadingZeros),
                Grouping = (uint)Grouping,
                DecimalSeparator = DecimalSeparator,
                ThousandSeparator = ThousandSeparator,
                NegativeOrder = (NationalLanguageSupportEnumerations.NegativeNumberMode)NegativeNumberFormat
            };
            return FormatInfo;
        }
    }
}