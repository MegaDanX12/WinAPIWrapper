using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Icons
{
    /// <summary>
    /// Strutture relative alle icone.
    /// </summary>
    internal static class IconStructures
    {
        /// <summary>
        /// Metriche scalabili associate con le icone.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct ICONMETRICS
        {
            /// <summary>
            /// Dimensione, in byte, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Spazio orizzontale, in pixel, per ogni icona ordinata.
            /// </summary>
            public int HorizontalSpacing;
            /// <summary>
            /// Spazio verticale, in pixel, per ogni icona ordinata.
            /// </summary>
            public int VerticalSpacing;
            /// <summary>
            /// Indica se i titoli delle icone vanno automaticamente a capo.
            /// </summary>
            public int TitleWrap;
            /// <summary>
            /// Font da usare per i titoli delle icone.
            /// </summary>
            public LOGFONT Font;
        }

        /// <summary>
        /// Informazioni su un'icona o su un cursore.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct ICONINFOEX
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Indica se la struttura descrive un'icona o un cursore.
            /// </summary>
            /// <remarks>true se la struttura descrive un'icona, false se descrive un cursore.</remarks>
            [MarshalAs(UnmanagedType.Bool)]
            public BOOL Icon;
            /// <summary>
            /// Coordinata y dell'hotspot del cursore.
            /// </summary>
            /// <remarks>Questa campo è ignorato se la struttura descrive un'icona.</remarks>
            public DWORD CursorHotspotX;
            /// <summary>
            /// Coordinata x dell'hotspot del cursore.
            /// </summary>
            /// <remarks>Questa campo è ignorato se la struttura descrive un'icona.</remarks>
            public DWORD CursorHotspotY;
            /// <summary>
            /// Handle al bitmap della bitmask dell'icona.
            /// </summary>
            public HBITMAP IconBitmask;
            /// <summary>
            /// Handle al bitmap del colore dell'icona.
            /// </summary>
            public HBITMAP IconColorBitmap;
            /// <summary>
            /// Bit risorsa.
            /// </summary>
            public WORD ResourceID;
            /// <summary>
            /// Percorso completo del modulo.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string ModulePath;
            /// <summary>
            /// Percorso completo della risorsa.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string ResourcePath;
        }
    }
}