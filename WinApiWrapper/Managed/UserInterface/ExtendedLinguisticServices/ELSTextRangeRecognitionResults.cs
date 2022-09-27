using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Risultati per una sezione del testo.
    /// </summary>
    public class ELSTextRangeRecognitionResults
    {
        /// <summary>
        /// Indice iniziale della sottosezione nel testo.
        /// </summary>
        public int StartIndex { get; }

        /// <summary>
        /// Indice finale della sottosezione nel testo.
        /// </summary>
        public int EndIndex { get; }

        /// <summary>
        /// Dati recuperati come output del servizio associato alla sottosezione.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Tipo MIME di contenuto indicato da <see cref="Data"/>.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// ID delle azioni disponibile per la sottosezione.
        /// </summary>
        internal string[] ActionIDs;

        /// <summary>
        /// Stringhe di visualizzazione per le azioni associate alla sottosezione.
        /// </summary>
        public string[] ActionDisplayNames { get; }

        /// <summary>
        /// Inizializza un'istanza di <see cref="ELSTextRangeRecognitionResults"/>.
        /// </summary>
        /// <param name="RangeResults">Struttura <see cref="MAPPING_DATA_RANGE"/> con le informazioni necessarie.</param>
        internal ELSTextRangeRecognitionResults(MAPPING_DATA_RANGE RangeResults)
        {
            StartIndex = (int)RangeResults.StartIndex;
            EndIndex = (int)RangeResults.EndIndex;
            Data = new byte[RangeResults.DataSize];
            HMODULE SecondPointer = RangeResults.Data;
            for (int i = 0; i < RangeResults.DataSize; i++)
            {
                Data[i] = Marshal.ReadByte(SecondPointer);
                SecondPointer += 1;
            }
            ContentType = RangeResults.ContentType;
            SecondPointer = RangeResults.ActionIDs;
            ActionIDs = new string[RangeResults.ActionsCount];
            HMODULE StringPointer;
            for (int i = 0; i < RangeResults.ActionsCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                ActionIDs[i] = Marshal.PtrToStringUni(StringPointer)!;
                SecondPointer += HMODULE.Size;
            }
            ActionDisplayNames = new string[RangeResults.ActionsCount];
            SecondPointer = RangeResults.ActionDisplayNames;
            for (int i = 0; i < RangeResults.ActionsCount; i++)
            {
                StringPointer = Marshal.ReadIntPtr(SecondPointer);
                ActionDisplayNames[i] = Marshal.PtrToStringUni(StringPointer)!;
                SecondPointer += HMODULE.Size;
            }
        }
    }
}