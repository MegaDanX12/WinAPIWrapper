using System.Collections;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Informazioni su un servizio ELS.
    /// </summary>
    public class ELSServiceInfo
    {
        /// <summary>
        /// Informazioni di copyright del servizio.
        /// </summary>
        public string Copyright { get; }

        /// <summary>
        /// Versione del servizio.
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Tipi MIME supportati in input.
        /// </summary>
        public List<string> InputContentTypes { get; } = new();

        /// <summary>
        /// Tipi MIME supportati in output.
        /// </summary>
        public List<string> OutputContentTypes { get; } = new();

        /// <summary>
        /// Lingue supportate, in formato IETF, in input.
        /// </summary>
        public List<string> InputLanguages { get; } = new();

        /// <summary>
        /// Lingue supportate, in formato IETF, in output.
        /// </summary>
        public List<string> OutputLanguages { get; } = new();

        /// <summary>
        /// Nomi standard Unicode di script supportati, in input.
        /// </summary>
        public List<string> InputScripts { get; } = new();

        /// <summary>
        /// Nomi standard Unicode di script supportati, in output.
        /// </summary>
        public List<string> OutputScripts { get; } = new();

        /// <summary>
        /// GUID del servizio.
        /// </summary>
        public Guid GUID { get; }

        /// <summary>
        /// Categoria di cui fa parte il servizio.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Descrizione del servizio.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Indica se il servizio restituisce un risultato in uno specifico linguaggio di output, dato un certo linguaggio di input.
        /// </summary>
        public bool IsOneToOneLanguageMapping { get; }

        /// <summary>
        /// Indica se il servizio è il padre di sottoservizi.
        /// </summary>
        public bool HasSubservices { get; }

        /// <summary>
        /// Struttura associata al servizio.
        /// </summary>
        internal MAPPING_SERVICE_INFO AssociatedStructure;

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ELSServiceInfo"/>.
        /// </summary>
        /// <param name="ServiceInfo">Struttura <see cref="MAPPING_SERVICE_INFO"/> con i dati sul servizio.</param>
        internal ELSServiceInfo(MAPPING_SERVICE_INFO ServiceInfo)
        {
            AssociatedStructure = ServiceInfo;
            Copyright = ServiceInfo.Copyright;
            Version = new(ServiceInfo.MajorVersion, ServiceInfo.MinorVersion, ServiceInfo.BuildVersion, ServiceInfo.StepVersion);
            HMODULE SecondPointer = ServiceInfo.InputContentTypes;
            HMODULE StringPointer;
            string ReadString;
            for (int i = 0; i < ServiceInfo.InputContentTypesCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                SecondPointer += HMODULE.Size;
                ReadString = Marshal.PtrToStringUni(StringPointer)!;
                InputContentTypes.Add(ReadString);
            }
            SecondPointer = ServiceInfo.OutputContentTypes;
            for (int i = 0; i < ServiceInfo.OutputContentTypesCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                SecondPointer += HMODULE.Size;
                ReadString = Marshal.PtrToStringUni(StringPointer)!;
                OutputContentTypes.Add(ReadString);
            }
            SecondPointer = ServiceInfo.InputLanguages;
            for (int i = 0; i < ServiceInfo.InputLanguagesCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                SecondPointer += HMODULE.Size;
                ReadString = Marshal.PtrToStringUni(StringPointer)!;
                InputLanguages.Add(ReadString);
            }
            SecondPointer = ServiceInfo.OutputLanguages;
            for (int i = 0; i < ServiceInfo.OutputLanguagesCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                SecondPointer += HMODULE.Size;
                ReadString = Marshal.PtrToStringUni(StringPointer)!;
                OutputLanguages.Add(ReadString);
            }
            SecondPointer = ServiceInfo.InputScripts;
            for (int i = 0; i < ServiceInfo.InputScriptsCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                SecondPointer += HMODULE.Size;
                ReadString = Marshal.PtrToStringUni(StringPointer)!;
                InputScripts.Add(ReadString);
            }
            SecondPointer = ServiceInfo.OutputScripts;
            for (int i = 0; i < ServiceInfo.OutputScriptsCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                SecondPointer += HMODULE.Size;
                ReadString = Marshal.PtrToStringUni(StringPointer)!;
                OutputScripts.Add(ReadString);
            }
            GUID = ServiceInfo.GUID;
            Category = ServiceInfo.Category;
            Description = ServiceInfo.Description;
            IsOneToOneLanguageMapping = GetFieldData(ServiceInfo.IsOneToOneLanguageMapping);
            HasSubservices = GetFieldData(ServiceInfo.HasSubservices);
        }


        private static bool GetFieldData(uint Field)
        {
            BitArray Bits = new(BitConverter.GetBytes(Field));
            return Bits[0];
        }
    }
}