using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts
{
    /// <summary>
    /// Enumerazioni relative ai font.
    /// </summary>
    internal static class FontEnumerations
    {
        /// <summary>
        /// Peso del font.
        /// </summary>
        internal enum FontWeight : LONG
        {
            FW_DONTCARE,
            FW_THIN = 100,
            FW_EXTRALIGHT = 200,
            FW_ULTRALIGHT = FW_EXTRALIGHT,
            FW_LIGHT = 300,
            FW_NORMAL = 400,
            FW_REGULAR = FW_NORMAL,
            FW_MEDIUM = 500,
            FW_SEMIBOLD = 600,
            FW_DEMIBOLD = FW_SEMIBOLD,
            FW_BOLD = 700,
            FW_EXTRABOLD = 800,
            FW_ULTRABOLD = FW_EXTRABOLD,
            FW_HEAVY = 900,
            FW_BLACK = FW_HEAVY
        }

        /// <summary>
        /// Set di caratteri.
        /// </summary>
        internal enum CharacterSet : byte
        {
            ANSI_CHARSET,
            DEFAULT_CHARSET,
            SYMBOL_CHARSET,
            SHIFTJS_CHARSET = 128,
            HANGEUL_CHARSET,
            HANGUL_CHARSET = HANGEUL_CHARSET,
            GB2312_CHARSET = 134,
            CHINESEBIG5_CHARSET = 136,
            OEM_CHARSET = 255,
            JOHAB_CHARSET = 130,
            HEBREW_CHARSET = 177,
            ARABIC_CHARSET,
            GREEK_CHARSET = 161,
            TURKISH_CHARSET,
            VIETNAMESE_CHARSET,
            THAI_CHARSET = 222,
            EASTEUROPE_CHARSET = 238,
            RUSSIAN_CHARSET = 204,
            MAC_CHARSET = 77,
            BALTIC_CHARSET = 186
        }

        /// <summary>
        /// Precisione output del font.
        /// </summary>
        internal enum FontOutputPrecision : byte
        {
            /// <summary>
            /// Comportamento predefinito.
            /// </summary>
            OUT_DEFAULT_PRECIS,
            /// <summary>
            /// Non usato dal font mapper ma restituito quando i raster font vengono enumerati.
            /// </summary>
            OUT_STRING_PRECIS,
            /// <summary>
            /// Non usato dal font mapper ma restituito quando i raster font vengono enumerati.
            /// </summary>
            OUT_STROKE_PRECIS = 3,
            /// <summary>
            /// Selezionare un font TrueType quando il sistema contiene diversi font con lo stesso nome.
            /// </summary>
            OUT_TT_PRECIS,
            /// <summary>
            /// Selezionare un font dispositivo quando il sistema contiene diversi font con lo stesso nome.
            /// </summary>
            OUT_DEVICE_PRECIS,
            /// <summary>
            /// Selezionare un font raster quando il sistema contiene diversi font con lo stesso nome.
            /// </summary>
            OUT_RASTER_PRECIS,
            /// <summary>
            /// Selezionare solo font TrueType, se non ne esistono la scelta verrà effettuata in base al comportamento predefinito.
            /// </summary>
            OUT_TT_ONLY_PRECIS,
            /// <summary>
            /// Selezionare font TrueType e altri font basati sull'outline.
            /// </summary>
            OUT_OUTLINE_PRECIS,
            /// <summary>
            /// 
            /// </summary>
            OUT_SCREEN_OUTLINE_PRECIS,
            /// <summary>
            /// Selezionare sono font PostScript, se non ne esistono la scelta verrà effettuata in base al comportamento predefinito.
            /// </summary>
            OUT_PS_ONLY_PRECIS
        }

        /// <summary>
        /// Precisione di taglio del font.
        /// </summary>
        [Flags]
        internal enum FontClipPrecision : byte
        {
            /// <summary>
            /// Comportamento predefinito.
            /// </summary>
            CLIP_DEFAULT_PRECIS,
            /// <summary>
            /// Non usato dal font mapper ma restituito quando font raster, vector o TrueType vengono enumerati.
            /// </summary>
            CLIP_STROKE_PRECIS = 2,
            /// <summary>
            /// La rotazione dei font dipende dall'orientamento del sistema di coordinate.
            /// </summary>
            /// <remarks>Se non viene usato i font dispositivo vengono ruotari sempre in direzione antioraria, la rotazione degli altri font dipende dall'orientamento del sistema di coordinate.</remarks>
            CLIP_LH_ANGLES = 1 << 4,
            /// <summary>
            /// Disattiva l'associazione per il font.
            /// </summary>
            /// <remarks>Questa impostazione non è detto che abbia effetto su nessuna piattaforma dopo Windows Server 2003.</remarks>
            CLIP_DFA_DISABLE = 4 << 4,
            /// <summary>
            /// Necessario per utilizzare un font integrato di sola lettura.
            /// </summary>
            CLIP_EMBEDDED = 8 << 4
        }

        /// <summary>
        /// Qualità del font.
        /// </summary>
        internal enum FontQuality : byte
        {
            /// <summary>
            /// L'aspetto del font non ha importanza.
            /// </summary>
            DEFAULT_QUALITY,
            /// <summary>
            /// L'aspetto del font è meno importante rispetto a <see cref="PROOF_QUALITY"/>.
            /// </summary>
            /// <remarks>Per font raster GDI, il ridimensionamento è abilitato, i font grassetto, corsivo e sbarrato sono sintetizzati se necessario.</remarks>
            DRAFT_QUALITY,
            /// <summary>
            /// La qualità del font è più importante della corrispondenza esatta degli attributi del font logico.
            /// </summary>
            /// <remarks>Per font raster GDI, il ridimensionamento è disattivato e il font più vicino in dimesione è selezionato, i font grassetto, corsivo e sbarrato sono sintetizzati se necessario.</remarks>
            PROOF_QUALITY,
            /// <summary>
            /// Al font non viene applicato l'antialiasing.
            /// </summary>
            NONANTIALISED_QUALITY,
            /// <summary>
            /// Al font viene applicato l'antialiasing se è supportato e se la dimensione del font non è troppo piccola o troppo grande.
            /// </summary>
            ANTIALISED_QUALITY,
            /// <summary>
            /// Se impostato, il testo viene renderizzato (quando possibile) usando ClearType.
            /// </summary>
            /// <remarks>L'antialiasing ClearType non è supportato nelle seguenti situazioni: <br/><br/>
            /// Il testo viene renderizzato su una stampante.<br/>
            /// Il display è impostato su 256 colori o meno.<br/>
            /// Il testo viene renderizzato su un client terminal server.<br/>
            /// Il font non è TrueType o OpenType con outline TrueType.<br/></remarks>
            CLEARTYPE_QUALITY,
            /// <summary>
            /// 
            /// </summary>
            CLEARTYPE_NATURAL_QUALITY
        }

        /// <summary>
        /// Larghezza del font.
        /// </summary>
        internal enum FontPitch : byte
        {
            DEFAULT_PITCH,
            FIXED_PITCH,
            VARIABLE_PITCH
        }

        /// <summary>
        /// Famiglia del font.
        /// </summary>
        internal enum FontFamily : byte
        {
            /// <summary>
            /// Font di default.
            /// </summary>
            FF_DONTCARE = 0 << 4,
            /// <summary>
            /// Font con larghezza variabile (proporzionale) e con serif.
            /// </summary>
            FF_ROMAN = 1 << 4,
            /// <summary>
            /// Font con larghezza variabile (proporzionale) senza serif.
            /// </summary>
            FF_SWISS = 2 << 4,
            /// <summary>
            /// Font con larghezza statica (monospazio), con o senza serif.
            /// </summary>
            FF_MODERN = 3 << 4,
            /// <summary>
            /// Font creati per somigliare alla scrittura a mano.
            /// </summary>
            FF_SCRIPT = 4 << 4,
            /// <summary>
            /// 
            /// </summary>
            FF_DECORATIVE = 5 << 4
        }
    }
}