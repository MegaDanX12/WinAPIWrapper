using System.Collections;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures;
using static WinApiWrapper.Managed.GraphicsAndMultimedia.Fonts.Enumerations;

namespace WinApiWrapper.Managed.GraphicsAndMultimedia.Fonts
{
    /// <summary>
    /// Informazioni su un font.
    /// </summary>
    public class FontInfo
    {
        /// <summary>
        /// Altezza, in unità logiche.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Larghezza media, in unità logiche.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Angolo, in decimi di grado, tra il vettore di scappamento e l'asse x del dispositivo.
        /// </summary>
        public int EscapementAngle { get; }

        /// <summary>
        /// Angolo, in decimi di grado, tra la linea di base di un carattere e l'asse x del dispositivo.
        /// </summary>
        public int Orientation { get; }

        /// <summary>
        /// Peso del font.
        /// </summary>
        public FontWeight Weight { get; }

        /// <summary>
        /// Indica se il font è italico.
        /// </summary>
        public bool IsItalic { get; }

        /// <summary>
        /// Indica se il font è sottolineato.
        /// </summary>
        public bool IsUnderlined { get; }

        /// <summary>
        /// Indica se il font è barrato.
        /// </summary>
        public bool IsStrikeOut { get; }

        /// <summary>
        /// Set di carateri di cui fa parte il font.
        /// </summary>
        public CharacterSet Charset { get; }

        /// <summary>
        /// Precisione di output.
        /// </summary>
        public FontOutputPrecision OutputPrecision { get; }

        /// <summary>
        /// Precisione di taglio.
        /// </summary>
        public FontClipPrecision ClipPrecision { get; }

        /// <summary>
        /// Qualità.
        /// </summary>
        public FontQuality Quality { get; }

        /// <summary>
        /// Larghezza.
        /// </summary>
        public FontPitch Pitch { get; }

        /// <summary>
        /// Famiglia del font.
        /// </summary>
        public FontFamily Family { get; }

        /// <summary>
        /// Tipo di font.
        /// </summary>
        public string FaceName { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="FontInfo"/>.
        /// </summary>
        /// <param name="FontDataStructure">Struttura <see cref="LOGFONT"/> con le informazioni.</param>
        internal FontInfo(LOGFONT FontDataStructure)
        {
            Height = FontDataStructure.Height;
            Width = FontDataStructure.Width;
            EscapementAngle = FontDataStructure.Escapement;
            Orientation = FontDataStructure.Orientation;
            Weight = (FontWeight)FontDataStructure.Weight;
            IsItalic = FontDataStructure.Italic;
            IsUnderlined = FontDataStructure.Underline;
            IsStrikeOut = FontDataStructure.Strikeout;
            Charset = (CharacterSet)FontDataStructure.Charset;
            OutputPrecision = (FontOutputPrecision)FontDataStructure.OutputPrecision;
            ClipPrecision = (FontClipPrecision)FontDataStructure.ClipPrecision;
            Quality = (FontQuality)FontDataStructure.Quality;
            Enum[] PitchAndFamilyValue = GetFontPitchAndFamily(FontDataStructure.PitchAndFamily);
            Pitch = (FontPitch)PitchAndFamilyValue[0];
            Family = (FontFamily)PitchAndFamilyValue[1];
            FaceName = FontDataStructure.FaceName;
        }

        /// <summary>
        /// Recupera il valore della larghezza e della famiglia di un font.
        /// </summary>
        /// <param name="Value">Valore composito.</param>
        /// <returns>Array di valori enumerativi che contiene le informazioni.</returns>
        /// <remarks>Il primo elemento è un valore di tipo <see cref="FontPitch"/>, il secondo elemento è un valore di tipo <see cref="FontFamily"/>.</remarks>
        private static Enum[] GetFontPitchAndFamily(byte Value)
        {
            Enum[] PitchAndFamily = new Enum[2];
            byte[] Bytes = new byte[1];
            Bytes[0] = Value;
            BitArray Bits = new(Bytes);
            BitArray PitchBits = new(2);
            for (int i = 0; i < PitchBits.Count; i++)
            {
                PitchBits[i] = Bits[i];
            }
            BitArray FamilyBits = new(4);
            for (int i = 0; i < FamilyBits.Count; i++)
            {
                FamilyBits[i] = Bits[i + 4];
            }
            byte[] PitchBytes = new byte[1];
            byte[] FamilyBytes = new byte[1];
            PitchBits.CopyTo(PitchBytes, 0);
            FamilyBits.CopyTo(FamilyBytes, 0);
            PitchAndFamily[0] = (FontPitch)PitchBytes[0];
            PitchAndFamily[1] = (FontFamily)FamilyBytes[0];
            return PitchAndFamily;
        }
    }
}