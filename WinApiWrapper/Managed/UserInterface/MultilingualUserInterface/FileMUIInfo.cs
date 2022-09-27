using System.ComponentModel;
using static WinApiWrapper.Managed.UserInterface.MultilingualUserInterface.Enumerations;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIFunctions;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIStructures;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIConstants;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIEnumerations;

namespace WinApiWrapper.Managed.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Informazioni su un file relativamente al suo uso con MUI.
    /// </summary>
    public class FileMUIInfo
    {
        /// <summary>
        /// Checksum.
        /// </summary>
        public byte[]? Checksum { get; }

        /// <summary>
        /// Nome della lingua.
        /// </summary>
        public string? LanguageName { get; }

        /// <summary>
        /// Nomi e relativo ID delle risorse presenti in un file di lingua neutrale.
        /// </summary>
        public Dictionary<int, string>? ResourcesInfoNeutral { get; }

        /// <summary>
        /// Nomi e relativo ID delle risorse presenti in un file di risorse specifico della lingua.
        /// </summary>
        public Dictionary<int, string>? ResourcesInfoLanguageSpecific { get; }

        /// <summary>
        /// Tipo di file.
        /// </summary>
        public MUIFileType? FileType { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="FileMUIInfo"/>.
        /// </summary>
        /// <param name="FilePath">Percorso del file di cui recuperare le informazioni.</param>
        /// <param name="QueryType">Tipo di dati da recuperare.</param>
        public FileMUIInfo(string FilePath, MUIFileQueryType QueryType = MUIFileQueryType.All)
        {
            bool Result;
            uint BufferSize;
            HMODULE StructureBuffer;
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                throw new ArgumentNullException(nameof(FilePath), "The file path cannot be null.");
            }
            if (QueryType.HasFlag(MUIFileQueryType.LanguageName) || QueryType.HasFlag(MUIFileQueryType.ResourcesInfo))
            {
                BufferSize = 0;
                StructureBuffer = HMODULE.Zero;
                FILEMUIINFO Structure;
                bool AlreadyAllocated = false;
                do
                {
                    Result = GetFileMUIInfo((MUIQueryType)QueryType, FilePath, StructureBuffer, ref BufferSize);
                    if (!Result && Marshal.GetLastPInvokeError() is ERROR_INSUFFICIENT_BUFFER)
                    {
                        Structure = new()
                        {
                            Size = BufferSize,
                            Version = MUI_FILEINFO_VERSION
                        };
                        if (StructureBuffer == HMODULE.Zero)
                        {
                            StructureBuffer = Marshal.AllocHGlobal((int)BufferSize);
                        }
                        else
                        {
                            StructureBuffer = Marshal.ReAllocHGlobal(StructureBuffer, (HMODULE)BufferSize);
                        }
                        if (!AlreadyAllocated)
                        {
                            Marshal.StructureToPtr(Structure, StructureBuffer, false);
                            AlreadyAllocated = true;
                            Structure.Size = BufferSize;
                        }
                        else
                        {
                            Marshal.StructureToPtr(Structure, StructureBuffer, true);
                            Structure.Size = BufferSize;
                        }
                    }
                    else if (!Result)
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                while (!Result);
                Structure = (FILEMUIINFO)Marshal.PtrToStructure(StructureBuffer, typeof(FILEMUIINFO))!;
                if (QueryType.HasFlag(MUIFileQueryType.Type))
                {
                    FileType = (MUIFileType)Structure.FileType;
                }
                if (QueryType.HasFlag(MUIFileQueryType.Checksum))
                {
                    Checksum = Structure.Checksum;
                }
                if (QueryType.HasFlag(MUIFileQueryType.LanguageName))
                {
                    if (Structure.LanguageNameOffset > 0)
                    {
                        HMODULE LanguageNamePointer = StructureBuffer + (int)Structure.LanguageNameOffset;
                        LanguageName = Marshal.PtrToStringUni(LanguageNamePointer);
                    }
                }
                if (QueryType.HasFlag(MUIFileQueryType.ResourcesInfo))
                {
                    int[] ResourceIDs;
                    string[] ResourceNames;
                    HMODULE DataPointer;
                    if (Structure.TypeIDMUIOffset > 0)
                    {
                        ResourcesInfoLanguageSpecific = new();
                        ResourceIDs = new int[Structure.TypeIDMUISize];
                        ResourceNames = new string[Structure.TypeIDMUISize];
                        DataPointer = StructureBuffer + (int)Structure.TypeIDMUIOffset;
                        for (int i = 0; i < ResourceIDs.Length; i++)
                        {
                            ResourceIDs[i] = Marshal.ReadInt32(DataPointer);
                            DataPointer += 4;
                        }
                        DataPointer = StructureBuffer + (int)Structure.TypeNameMUIOffset;
                        for (int i = 0; i < ResourceNames.Length; i++)
                        {
                            ResourceNames[i] = ReadString(ref DataPointer);
                        }
                        for (int i = 0; i < ResourceIDs.Length; i++)
                        {
                            ResourcesInfoLanguageSpecific.Add(ResourceIDs[i], ResourceNames[i]);
                        }
                    }
                    if (Structure.TypeIDMainOffset > 0)
                    {
                        ResourcesInfoNeutral = new();
                        ResourceIDs = new int[Structure.TypeIDMainSize];
                        ResourceNames = new string[Structure.TypeIDMainSize];
                        DataPointer = StructureBuffer + (int)Structure.TypeIDMainOffset;
                        for (int i = 0; i < ResourceIDs.Length; i++)
                        {
                            ResourceIDs[i] = Marshal.ReadInt32(DataPointer);
                            DataPointer += 4;
                        }
                        DataPointer = StructureBuffer + (int)Structure.TypeIDMainOffset;
                        for (int i = 0; i < ResourceNames.Length; i++)
                        {
                            ResourceNames[i] = ReadString(ref DataPointer);
                        }
                        for (int i = 0; i < ResourceIDs.Length; i++)
                        {
                            ResourcesInfoNeutral.Add(ResourceIDs[i], ResourceNames[i]);
                        }
                    }
                }
            }
            else
            {
                BufferSize = (uint)Marshal.SizeOf(typeof(FILEMUIINFO));
                StructureBuffer = Marshal.AllocHGlobal((int)BufferSize);
                FILEMUIINFO Structure = new()
                {
                    Size = BufferSize,
                    Version = MUI_FILEINFO_VERSION
                };
                Marshal.StructureToPtr(Structure, StructureBuffer, false);
                Result = GetFileMUIInfo((MUIQueryType)QueryType, FilePath, StructureBuffer, ref BufferSize);
                if (Result)
                {
                    Structure = (FILEMUIINFO)Marshal.PtrToStructure(StructureBuffer, typeof(FILEMUIINFO))!;
                    if (QueryType.HasFlag(MUIFileQueryType.Type))
                    {
                        FileType = (MUIFileType)Structure.FileType;
                    }
                    if (QueryType.HasFlag(MUIFileQueryType.Checksum))
                    {
                        Checksum = Structure.Checksum;
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            Marshal.FreeHGlobal(StructureBuffer);
        }
    }
}