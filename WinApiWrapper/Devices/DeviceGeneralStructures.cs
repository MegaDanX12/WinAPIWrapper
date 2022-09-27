using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIConstants;

namespace WinApiWrapper.Devices
{
    /// <summary>
    /// Strutture generali usate per i dispositivi.
    /// </summary>
    internal static class DeviceGeneralStructures
    {

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DEVMODESCREEN
        {

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;

            public WORD StructureVersion;

            public WORD DriverVersion;

            public WORD Size;

            public WORD DriverExtra;


        }
    }
}