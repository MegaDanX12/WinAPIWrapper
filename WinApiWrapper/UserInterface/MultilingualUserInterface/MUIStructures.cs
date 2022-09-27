using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations;

namespace WinApiWrapper.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Strutture usate dalla funzionalità MUI.
    /// </summary>
    internal static class MUIStructures
    {
        /// <summary>
        /// Informazioni sull'uso da parte di MUI di un file.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct FILEMUIINFO
        {
            /// <summary>
            /// Dimensione, incluso il buffer, in bytes, della struttura.
            /// </summary>
            public DWORD Size;
            /// <summary>
            /// Versione della struttura.
            /// </summary>
            public DWORD Version;
            /// <summary>
            /// Tipo di file.
            /// </summary>
            public FileType FileType;
            /// <summary>
            /// Checksum del file.
            /// </summary>
            /// <remarks>Questo campo è valido solo se <see cref="FileType"/> è <see cref="FileType.MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN"/> o <see cref="FileType.MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI"/>.</remarks>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U1)]
            public byte[] Checksum;
            /// <summary>
            /// Checksum del file.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U1)]
            public byte[] ServiceChecksum;
            /// <summary>
            /// Offset, in byte, dall'inizio della struttura alla stringa del nome del linguaggio per un file specifico della lingua, oppure dell'ultimo nome della linguage per un file LN.
            /// </summary>
            public DWORD LanguageNameOffset;
            /// <summary>
            /// Dimensione dell'array il cui offset è indicato da <see cref="TypeIDMainOffset"/>, indica anche il numero di stringhe presenti nell'array indicato da <see cref="TypeNameMainOffset"/>.
            /// </summary>
            public DWORD TypeIDMainSize;
            /// <summary>
            /// Offset, in byte, dall'inizio della struttura a un array di interi a 32 bit che indicato i tipi di risorse contenuti nel file LN.
            /// </summary>
            public DWORD TypeIDMainOffset;
            /// <summary>
            /// Offset, in byte, dall'inizio della struttura a una serie di stringhe a terminazione nulla che indicano i nomi delle risorse contenute nel file LN.
            /// </summary>
            public DWORD TypeNameMainOffset;
            /// <summary>
            /// Dimensione dell'array il cui offset è indicato da <see cref="TypeIDMUIOffset"/>, indica anche il numero di stringhe nella serie di stringhe indicate da <see cref="TypeNameMUIOffset"/>.
            /// </summary>
            public DWORD TypeIDMUISize;
            /// <summary>
            /// Offset, in byte, dall'inizio della struttura a un array di interi a 32 bit che indicano i tipi di risorse presenti in un file MUI.
            /// </summary>
            public DWORD TypeIDMUIOffset;
            /// <summary>
            /// Offset, in byte, dall'inizio della struttura a una serie di stringhe a terminazione nulla che indicano i nomi delle risorse contenute nel file MUI.
            /// </summary>
            public DWORD TypeNameMUIOffset;
            /// <summary>
            /// Memoria rimanente.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.U1)]
            public byte[] RemainingBuffer;
        }
    }
}