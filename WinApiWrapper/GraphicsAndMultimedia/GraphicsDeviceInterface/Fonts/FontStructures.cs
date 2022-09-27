using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontEnumerations;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontConstants;

namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts
{
    /// <summary>
    /// Strutture relative ai font.
    /// </summary>
    internal static class FontStructures
    {
        /// <summary>
        /// Attributi di un font.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct LOGFONT
        {
            /// <summary>
            /// Altezza, in unità logiche, del carattere.
            /// </summary>
            /// <remarks>Il font mapper interpreta il valore di questo campo nel seguente modo:<br/><br/>
            /// maggiore di 0: il valore viene trasformato in unità dispositivo e confronto con l'altezza dei font disponibili.<br/>
            /// 0: altezza di default.<br/>
            /// minore di 0: il valore viene trasformato in unità dispositivo e il suo valore assoluto viene confrontato con l'altezza dei font disponibili.</remarks>
            public LONG Height;
            /// <summary>
            /// Larghezza media, in unità logiche, dei caratteri nel font.
            /// </summary>
            /// <remarks>Se ha valore 0, il rapporto d'aspetto del dispositivo viene confrontato con il rapporto d'aspetto di digitalizzazione dei font disponibili per trovare la corrispondenza più vicina, determinato dal valore assoluto della differenza.</remarks>
            public LONG Width;
            /// <summary>
            /// Angolo, in decimi di grado, tra il vettore di scappamento e l'asse x del dispositivo.
            /// </summary>
            /// <remarks>Il vettore di scappamento è parallelo alla base di una stringa di testo.<br/><br/>
            /// Quando la modalità grafica è GM_ADVANCED, l'angolo di scappamento della stringa può essere specificato indipendentemente dall'angolo di orientamento dei caratteri della stringa.<br/><br/>
            /// Quando la modalità grafica è GM_COMPATBILE, questo campo specifica l'angolo e l'orientamento, <see cref="Escapement"/> e <see cref="Orientation"/> dovrebbero avere lo stesso valore.</remarks>
            public LONG Escapement;
            /// <summary>
            /// Angolo, in decimi di grado, tra la linea base di ogni carattere e l'asse x del dispositivo.
            /// </summary>
            public LONG Orientation;
            /// <summary>
            /// Peso del carattere tra 0 e 1000.
            /// </summary>
            public FontWeight Weight;
            /// <summary>
            /// Indica se il font è italico.
            /// </summary>
            [MarshalAs(UnmanagedType.U1)]
            public bool Italic;
            /// <summary>
            /// Indica se il font è sottolineato.
            /// </summary>
            [MarshalAs(UnmanagedType.U1)]
            public bool Underline;
            /// <summary>
            /// Indica se il font è sbarrato.
            /// </summary>
            [MarshalAs(UnmanagedType.U1)]
            public bool Strikeout;
            /// <summary>
            /// Set di caratteri.
            /// </summary>
            public CharacterSet Charset;
            /// <summary>
            /// Precisione dell'output.
            /// </summary>
            public FontOutputPrecision OutputPrecision;
            /// <summary>
            /// Precisione di taglio.
            /// </summary>
            public FontClipPrecision ClipPrecision;
            /// <summary>
            /// Qualità.
            /// </summary>
            public FontQuality Quality;
            /// <summary>
            /// Larghezza e famiglia del font.
            /// </summary>
            /// <remarks>I primi due bit sono la larghezza, i bit da 4 a 7 indicano la famiglia.</remarks>
            public byte PitchAndFamily;
            /// <summary>
            /// Nome del tipo del font.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
            public string FaceName;
        }
    }
}