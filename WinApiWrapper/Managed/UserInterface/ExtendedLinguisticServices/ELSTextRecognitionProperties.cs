using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Risultati del riconoscimento testo.
    /// </summary>
    public class ELSTextRecognitionProperties
    {
        /// <summary>
        /// Risultati del riconoscimento delle porzioni del testo.
        /// </summary>
        public ELSTextRangeRecognitionResults[]? ResultRanges { get; }

        /// <summary>
        /// Dati privati del servizio.
        /// </summary>
        public byte[]? ServiceData { get; }

        /// <summary>
        /// Dati privati dell'applicazione.
        /// </summary>
        public byte[]? CallerData { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ELSTextRecognitionProperties"/>.
        /// </summary>
        /// <param name="Properties">Struttura <see cref="MAPPING_PROPERTY_BAG"/> con le informazioni.</param>
        internal ELSTextRecognitionProperties(MAPPING_PROPERTY_BAG Properties)
        {
            MAPPING_DATA_RANGE RangeResult;
            ResultRanges = new ELSTextRangeRecognitionResults[Properties.RangesCount];
            HMODULE SecondPointer = Properties.ResultRanges;
            for (int i = 0; i < Properties.RangesCount; i++)
            {
                RangeResult = GetResultRangeData(ref SecondPointer);
                ResultRanges[i] = new ELSTextRangeRecognitionResults(RangeResult);
            }
            ServiceData = Properties.ServiceDataSize is not 0 ? new byte[Properties.ServiceDataSize] : null;
            if (ServiceData is not null)
            {
                SecondPointer = Properties.ServiceData;
                for (int i = 0; i < Properties.ServiceDataSize; i++)
                {
                    ServiceData[i] = Marshal.ReadByte(SecondPointer);
                    SecondPointer += 1;
                }
            }
            CallerData = Properties.CallerDataSize is not 0 ? new byte[Properties.CallerDataSize] : null;
            if (CallerData is not null)
            {
                SecondPointer = Properties.CallerData;
                for (int i = 0; i < Properties.ServiceDataSize; i++)
                {
                    CallerData[i] = Marshal.ReadByte(SecondPointer);
                    SecondPointer += 1;
                }
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ELSTextRecognitionProperties"/>.
        /// </summary>
        /// <param name="ApplicationData">Dati privati dell'applicazione.</param>
        public ELSTextRecognitionProperties(byte[] ApplicationData)
        {
            CallerData = ApplicationData;
        }

        /// <summary>
        /// Recupera i dati sui risultati dell'elaborazione di una porzione del testo.
        /// </summary>
        /// <param name="ResultRangesPointer">Puntatore alla struttura che contiene i dati.</param>
        /// <returns>Una struttura <see cref="MAPPING_DATA_RANGE"/> con i dati recuperati.</returns>
        private static MAPPING_DATA_RANGE GetResultRangeData(ref HMODULE ResultRangesPointer)
        {
            MAPPING_DATA_RANGE ResultRange = new();
            ResultRange.StartIndex = (uint)Marshal.ReadInt32(ResultRangesPointer);
            ResultRangesPointer += 4;
            ResultRange.EndIndex = (uint)Marshal.ReadInt32(ResultRangesPointer);
            ResultRangesPointer += 4 + HMODULE.Size + 4;
            ResultRange.Data = Marshal.ReadIntPtr(ResultRangesPointer);
            ResultRangesPointer += HMODULE.Size;
            ResultRange.DataSize = (uint)Marshal.ReadInt32(ResultRangesPointer);
            ResultRangesPointer += 4;
            ResultRange.ContentType = Marshal.PtrToStringUni(ResultRangesPointer)!;
            ResultRangesPointer += HMODULE.Size;
            ResultRange.ActionIDs = Marshal.ReadIntPtr(ResultRangesPointer);
            ResultRangesPointer += HMODULE.Size;
            ResultRange.ActionsCount = (uint)Marshal.ReadInt32(ResultRangesPointer);
            ResultRangesPointer += 4;
            ResultRange.ActionDisplayNames = Marshal.ReadIntPtr(ResultRangesPointer);
            return ResultRange;
        }
    }
}