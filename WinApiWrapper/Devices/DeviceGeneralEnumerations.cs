namespace WinApiWrapper.Devices
{
    /// <summary>
    /// Enumerazioni generali usate per i dispositivi.
    /// </summary>
    internal static class DeviceGeneralEnumerations
    {
        /// <summary>
        /// Membri validi per la struttura <see cref="DeviceGeneralStructures.DEVMODESCREEN"/> e <see cref="DeviceGeneralStructures.DEVMODEPRINTER"/>.
        /// </summary>
        [Flags]
        internal enum DevmodeStructureValidMembers
        {

            DM_ORIENTATION = 1,

            DM_PAPERSIZE = 2,

            DM_PAPERLENGTH = 4,

            DM_PAPERWIDTH = 8,

            DM_SCALE = 16,

            DM_POSITION = 32,

            DM_NUP = 64,

            DM_DISPLAYORIENTATION = 128,

            DM_COPIES = 256,

            DM_DEFAULTSOURCE = 512,

            DM_PRINTQUALITY = 1024,

            DM_COLOR = 2048,

            DM_DUPLEX = 4096,

            DM_YRESOLUTION = 8192,

            DM_TTOPTION = 16384,

            DM_COLLATE = 32768,

            DM_FORMNAME = 65536,

            DM_LOGPIXELS = 131072,

            DM_BITSPERPEL = 262144,

            DM_PELSWIDTH = 524288,
            
            DM_PELSHEIGHT = 1048576,

            DM_DISPLAYFLAGS = 207152,

            DM_DISPLAYFREQUENCY = 4194304,

            DM_ICMMETHOD = 8388608,

            DM_ICMINTENT = 1677216,

            DM_MEDIATYPE = 33554432,

            DM_DITHERTYPE = 67108864,

            DM_PANNINGWIDTH = 134217728,

            DM_PANNINGHEIGHT = 268435456,

            DM_DISPLAYFIXEDOUTPUT = 536870912
        }

        /// <summary>
        /// Orientamento della pagina.
        /// </summary>
        internal enum PageOrientation
        {
            /// <summary>
            /// Verticale.
            /// </summary>
            DMORIENT_PORTRAIT = 1,
            /// <summary>
            /// Orizzontale.
            /// </summary>
            DMORIENT_LANDSCAPE
        }


        internal enum PrintingSource
        {

            DMBIN_UPPER = 1,

            DMBIN_ONLYONE = DMBIN_UPPER,

            DMBIN_LOWER,

            DMBIN_MIDDLE,

            DMBIN_MANUAL,

            DMBIN_ENVELOPE,

            DMBIN_ENVMANUAL,

            DMBIN_AUTO,

            DMBIN_TRACTOR,


        }
    }
}