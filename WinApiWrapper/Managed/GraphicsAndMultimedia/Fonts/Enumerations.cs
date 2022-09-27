namespace WinApiWrapper.Managed.GraphicsAndMultimedia.Fonts
{
    /// <summary>
    /// Enumerazioni dei font.
    /// </summary>
    public class Enumerations
    {
        /// <summary>
        /// Peso del font.
        /// </summary>
        public enum FontWeight
        {
            Default,
            Thin = 100,
            Extralight = 200,
            Ultralight = Extralight,
            Light = 300,
            Normal = 400,
            Regular = Normal,
            Medium = 500,
            Semibold = 600,
            Demibold = Semibold,
            Bold = 700,
            Extrabold = 800,
            Ultrabold = Extrabold,
            Heavy = 900,
            Black = Heavy
        }

        /// <summary>
        /// Set di caratteri.
        /// </summary>
        public enum CharacterSet : byte
        {
            Ansi,
            Default,
            Symbol,
            Japanese = 128,
            KoreanHangeul,
            KoreanHangul = KoreanHangeul,
            SimplifiedChinese = 134,
            TraditionalChinese = 136,
            Oem = 255,
            KoreanJohab = 130,
            Hebrew = 177,
            Arabic,
            Greek = 161,
            Turkish,
            Vietnamese,
            Thai = 222,
            EastEurope = 238,
            Russina = 204,
            Mac = 77,
            Baltic = 186
        }

        /// <summary>
        /// Precisione output del font.
        /// </summary>
        public enum FontOutputPrecision : byte
        {
            /// <summary>
            /// Comportamento predefinito.
            /// </summary>
            Default,
            /// <summary>
            /// Non usato dal font mapper ma restituito quando i raster font vengono enumerati.
            /// </summary>
            StringPrecision,
            /// <summary>
            /// Non usato dal font mapper ma restituito quando i raster font vengono enumerati.
            /// </summary>
            StrokePrecision = 3,
            /// <summary>
            /// Selezionare un font TrueType quando il sistema contiene diversi font con lo stesso nome.
            /// </summary>
            TrueTypePreferred,
            /// <summary>
            /// Selezionare un font dispositivo quando il sistema contiene diversi font con lo stesso nome.
            /// </summary>
            DevicePreferred,
            /// <summary>
            /// Selezionare un font raster quando il sistema contiene diversi font con lo stesso nome.
            /// </summary>
            RasterPreferred,
            /// <summary>
            /// Selezionare solo font TrueType, se non ne esistono la scelta verrà effettuata in base al comportamento predefinito.
            /// </summary>
            TrueTypeOnly,
            /// <summary>
            /// Selezionare font TrueType e altri font basati sull'outline.
            /// </summary>
            OutlineBasedOnly,
            /// <summary>
            /// Preferenza per font TrueType e altri basati sull'outline.
            /// </summary>
            OutlineBasePreferred,
            /// <summary>
            /// Selezionare sono font PostScript, se non ne esistono la scelta verrà effettuata in base al comportamento predefinito.
            /// </summary>
            PostScriptOnly
        }

        /// <summary>
        /// Precisione di taglio del font.
        /// </summary>
        [Flags]
        public enum FontClipPrecision : byte
        {
            /// <summary>
            /// Comportamento predefinito.
            /// </summary>
            Defaukt,
            /// <summary>
            /// Non usato dal font mapper ma restituito quando font raster, vector o TrueType vengono enumerati.
            /// </summary>
            StrokePrecision = 2,
            /// <summary>
            /// La rotazione dei font dipende dall'orientamento del sistema di coordinate.
            /// </summary>
            /// <remarks>Se non viene usato i font dispositivo vengono ruotari sempre in direzione antioraria, la rotazione degli altri font dipende dall'orientamento del sistema di coordinate.</remarks>
            CoordinateSystemDependent = 1 << 4,
            /// <summary>
            /// Disattiva l'associazione per il font.
            /// </summary>
            /// <remarks>Questa impostazione non è detto che abbia effetto su nessuna piattaforma dopo Windows Server 2003.</remarks>
            FontAssociationDisabled = 4 << 4,
            /// <summary>
            /// Necessario per utilizzare un font integrato di sola lettura.
            /// </summary>
            Embedded = 8 << 4
        }

        /// <summary>
        /// Qualità del font.
        /// </summary>
        public enum FontQuality : byte
        {
            /// <summary>
            /// L'aspetto del font non ha importanza.
            /// </summary>
            Default,
            /// <summary>
            /// L'aspetto del font è meno importante rispetto a <see cref="High"/>.
            /// </summary>
            /// <remarks>Per font raster GDI, il ridimensionamento è abilitato, i font grassetto, corsivo e sbarrato sono sintetizzati se necessario.</remarks>
            Low,
            /// <summary>
            /// La qualità del font è più importante della corrispondenza esatta degli attributi del font logico.
            /// </summary>
            /// <remarks>Per font raster GDI, il ridimensionamento è disattivato e il font più vicino in dimesione è selezionato, i font grassetto, corsivo e sbarrato sono sintetizzati se necessario.</remarks>
            High,
            /// <summary>
            /// Al font non viene applicato l'antialiasing.
            /// </summary>
            NonAntialised,
            /// <summary>
            /// Al font viene applicato l'antialiasing se è supportato e se la dimensione del font non è troppo piccola o troppo grande.
            /// </summary>
            Antialised,
            /// <summary>
            /// Se impostato, il testo viene renderizzato (quando possibile) usando ClearType.
            /// </summary>
            /// <remarks>L'antialiasing ClearType non è supportato nelle seguenti situazioni: <br/><br/>
            /// Il testo viene renderizzato su una stampante.<br/>
            /// Il display è impostato su 256 colori o meno.<br/>
            /// Il testo viene renderizzato su un client terminal server.<br/>
            /// Il font non è TrueType o OpenType con outline TrueType.<br/></remarks>
            ClearType,
            /// <summary>
            /// 
            /// </summary>
            ClearTypeNatural
        }

        /// <summary>
        /// Larghezza del font.
        /// </summary>
        public enum FontPitch : byte
        {
            Default,
            Fixed,
            Variable
        }

        /// <summary>
        /// Famiglia del font.
        /// </summary>
        public enum FontFamily : byte
        {
            /// <summary>
            /// Font di default.
            /// </summary>
            Default = 0 << 4,
            /// <summary>
            /// Font con larghezza variabile (proporzionale) e con serif.
            /// </summary>
            ProportionalWithSerifs = 1 << 4,
            /// <summary>
            /// Font con larghezza variabile (proporzionale) senza serif.
            /// </summary>
            ProportiionalWithoutSerifs = 2 << 4,
            /// <summary>
            /// Font con larghezza statica (monospazio), con o senza serif.
            /// </summary>
            Monospace = 3 << 4,
            /// <summary>
            /// Font creati per somigliare alla scrittura a mano.
            /// </summary>
            HandwritingLike = 4 << 4,
            /// <summary>
            /// 
            /// </summary>
            Novelty = 5 << 4
        }
    }
}