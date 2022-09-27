using System.ComponentModel;
using WinApiWrapper.UserInterface.ExtendedLinguisticServices;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesFunctions;
using static WinApiWrapper.UserInterface.ExtendedLinguisticServices.ExtendedLinguisticServicesStructures;

namespace WinApiWrapper.Managed.UserInterface.ExtendedLinguisticServices
{
    /// <summary>
    /// Permette di utilizzare la piattaforma ELS.
    /// </summary>
    public static class ELSManaged
    {
        /// <summary>
        /// Recupera le informazioni sui servizi ELS disponibili.
        /// </summary>
        /// <param name="Options">Istanza di <see cref="ELSEnumerationOptions"/> che influenza l'enumerazione dei servizi.</param>
        /// <returns>Array di oggetti <see cref="ELSServiceInfo"/> con le informazioni sui servizi.</returns>
        /// <remarks>Il metodo <see cref="UnloadServices"/> deve essere chiamato quando le funzionalità ELS non sono più necessarie..</remarks>
        /// <exception cref="Win32Exception"></exception>
        public static ELSServiceInfo[] GetELSServices(ELSEnumerationOptions? Options = null)
        {
            List<ELSServiceInfo> ServicesInfo = new();
            MAPPING_SERVICE_INFO ServiceInfo;
            if (Options is not null)
            {
                MAPPING_ENUM_OPTIONS OptionsStructure = Options.ToStruct();
                HMODULE OptionsStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(OptionsStructure));
                Marshal.StructureToPtr(OptionsStructure, OptionsStructurePointer, false);
                HRESULT OperationResult = MappingGetServices(OptionsStructurePointer, out ELSMetadata.ServicesDataPointer, out uint ServicesCount);
                if (OptionsStructure.Guid != HMODULE.Zero)
                {
                    Marshal.FreeHGlobal(OptionsStructure.Guid);
                }
                Marshal.FreeHGlobal(OptionsStructurePointer);
                if (OperationResult == S_OK)
                {
                    HMODULE SecondPointer = ELSMetadata.ServicesDataPointer;
                    for (int i = 0; i < ServicesCount; i++)
                    {
                        ServiceInfo = (MAPPING_SERVICE_INFO)Marshal.PtrToStructure(SecondPointer, typeof(MAPPING_SERVICE_INFO))!;
                        SecondPointer += ServiceInfo.Size.ToInt32();
                    }
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                return ServicesInfo.ToArray();
            }
            else
            {
                HRESULT OperationResult = MappingGetServices(HMODULE.Zero, out ELSMetadata.ServicesDataPointer, out uint ServicesCount);
                if (OperationResult == S_OK)
                {
                    HMODULE SecondPointer = ELSMetadata.ServicesDataPointer;
                    for (int i = 0; i < ServicesCount; i++)
                    {
                        ServiceInfo = (MAPPING_SERVICE_INFO)Marshal.PtrToStructure(SecondPointer, typeof(MAPPING_SERVICE_INFO))!;
                        SecondPointer += ServiceInfo.Size.ToInt32();
                        ServicesInfo.Add(new ELSServiceInfo(ServiceInfo));
                    }
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                return ServicesInfo.ToArray();
            }

        }

        /// <summary>
        /// Libera le risorse e la memoria allocata dalla piattaforma ELS.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public static void UnloadServices()
        {
            if (ELSMetadata.OptionsStructurePointer != HMODULE.Zero)
            {
                MAPPING_OPTIONS Options = (MAPPING_OPTIONS)Marshal.PtrToStructure(ELSMetadata.OptionsStructurePointer, typeof(MAPPING_OPTIONS))!;
                if (Options.RecognizeCallerData != HMODULE.Zero)
                {
                    Marshal.FreeHGlobal(Options.RecognizeCallerData);
                }
                Marshal.FreeHGlobal(ELSMetadata.OptionsStructurePointer);
            }
            HRESULT OperationResult = MappingFreePropertyBag(ref ELSMetadata.PropertyBag);
            if (OperationResult != S_OK)
            {
                Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                {
                    HResult = OperationResult
                };
                throw ex;
            }
            OperationResult = MappingFreeServices(ELSMetadata.ServicesDataPointer);
            if (OperationResult != S_OK)
            {
                Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                {
                    HResult = OperationResult
                };
                throw ex;
            }
        }

        /// <summary>
        /// Esegue il riconoscimento del testo.
        /// </summary>
        /// <param name="Service">Servizio da utilizzare per il riconoscimento del testo.</param>
        /// <param name="Text">Testo di cui eseguire il riconoscimento.</param>
        /// <param name="TextStartIndex">Indice all'interno del testo che il servizio deve usare.</param>
        /// <param name="Options">Istanza di <see cref="ELSTextRecognitionOptions"/> che influenza la procedura di riconoscimento del testo.</param>
        /// <returns>Istanza di <see cref="ELSTextRecognitionProperties"/> con i risultati del riconoscimento.</returns>
        /// <remarks>Impostare a 0 il parametro <paramref name="TextStartIndex"/> per elaborare tutto il testo.</remarks>
        /// <exception cref="Win32Exception"></exception>
        public static ELSTextRecognitionProperties RecognizeText(ELSServiceInfo Service, string Text, int TextStartIndex, ELSTextRecognitionOptions? Options = null)
        {
            if (Service == null || string.IsNullOrWhiteSpace(Text))
            {
                throw new ArgumentNullException(string.Empty, "The parameters " + nameof(Service) + " and " + nameof(Text) + " cannot be null.");
            }
            if (TextStartIndex < 0 || TextStartIndex > Text.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(TextStartIndex), "The parameter " + nameof(TextStartIndex) + " cannot be less than zero or more than the text length.");
            }
            ELSMetadata.Text = Text;
            if (Options is not null)
            {
                MAPPING_OPTIONS TextRecognitionOptions = Options.ToStruct();
                ELSMetadata.OptionsStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MAPPING_OPTIONS)));
                Marshal.StructureToPtr(TextRecognitionOptions, ELSMetadata.OptionsStructurePointer, false);
                ELSMetadata.PropertyBag = new()
                {
                    Size = (HMODULE)Marshal.SizeOf(typeof(MAPPING_PROPERTY_BAG))
                };
                if (TextRecognitionOptions.RecognizeCallerData != HMODULE.Zero)
                {
                    ELSMetadata.PropertyBag.CallerData = TextRecognitionOptions.RecognizeCallerData;
                    ELSMetadata.PropertyBag.CallerDataSize = TextRecognitionOptions.RecognizeCallerDataSize;
                }
                HRESULT OperationResult = MappingRecognizeText(ref Service.AssociatedStructure, ELSMetadata.Text, (uint)(Text.Length + 1), (uint)TextStartIndex, ELSMetadata.OptionsStructurePointer, ref ELSMetadata.PropertyBag);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                else
                {
                    return new(ELSMetadata.PropertyBag);
                }
            }
            else
            {
                ELSMetadata.PropertyBag = new()
                {
                    Size = (HMODULE)Marshal.SizeOf(typeof(MAPPING_PROPERTY_BAG))
                };
                HRESULT OperationResult = MappingRecognizeText(ref Service.AssociatedStructure, ELSMetadata.Text, (uint)(Text.Length + 1), (uint)TextStartIndex, HMODULE.Zero, ref ELSMetadata.PropertyBag);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                else
                {
                    return new(ELSMetadata.PropertyBag);
                }
            }
        }

        /// <summary>
        /// Esegue un'azione su una porzione del testo dopo il riconoscimento.
        /// </summary>
        /// <param name="StartingIndex">Indice di partenza nella sottosezione del testo su cui eseguire l'azione.</param>
        /// <param name="RangeResult">Istanza di <see cref="ELSTextRangeRecognitionResults"/> che rappresenta il risultato del riconoscimento su una sottosezione del testo.</param>
        /// <param name="ActionIndex">Indice, all'interno del campo <see cref="ELSTextRangeRecognitionResults.ActionDisplayNames"/>, che indica la posizione della stringa che identifica l'azione da eseguire.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ExecuteAction(int StartingIndex, ELSTextRangeRecognitionResults RangeResult, int ActionIndex)
        {
            if (RangeResult is null)
            {
                throw new ArgumentNullException(nameof(RangeResult), nameof(RangeResult) + " cannot be null.");
            }
            if (StartingIndex < 0 || StartingIndex > RangeResult.EndIndex || ActionIndex < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "The parameters " + nameof(StartingIndex) + " and " + nameof(ActionIndex) + " cannot be less than zero, " + nameof(StartingIndex) + "also cannot be higher than the text range length.");
            }
            HRESULT OperationResult = MappingDoAction(ref ELSMetadata.PropertyBag, (DWORD)StartingIndex, RangeResult.ActionIDs[ActionIndex]);
            if (OperationResult != S_OK)
            {
                Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                {
                    HResult = OperationResult
                };
                throw ex;
            }
        }

        /// <summary>
        /// Metodo per l'elaborazione asincrona dei risultati del riconoscimento del testo.
        /// </summary>
        /// <param name="Bag">Puntatore a una struttura <see cref="MAPPING_PROPERTY_BAG"/> che contiene i risultati della chiamata a <see cref="MappingRecognizeText"/>.</param>
        /// <param name="Data">Puntatore a dati privati dell'applicazione.</param>
        /// <param name="DataSize">Dimensione, in bytes, dei dati privati dell'applicazione.</param>
        /// <param name="Result">Valore restituito da <see cref="MappingRecognizeText"/>.</param>
        /// <exception cref="Win32Exception"></exception>
        internal static void TextRecognitionAsyncMethod(ref MAPPING_PROPERTY_BAG Bag, HMODULE Data, DWORD DataSize, HRESULT Result)
        {
            if (Result != S_OK)
            {
                _ = MappingFreePropertyBag(ref Bag);
                Win32Exception ex = new(Marshal.GetExceptionForHR(Result)!.Message)
                {
                    HResult = Result
                };
                throw ex;
            }
            else
            {
                MAPPING_OPTIONS Options = (MAPPING_OPTIONS)Marshal.PtrToStructure(ELSMetadata.OptionsStructurePointer, typeof(MAPPING_OPTIONS))!;
                if (Options.RecognizeCallerData != HMODULE.Zero)
                {
                    Marshal.FreeHGlobal(Options.RecognizeCallerData);
                }
                Marshal.FreeHGlobal(ELSMetadata.OptionsStructurePointer);
                ELSTextRecognitionProperties Results = new(ELSMetadata.PropertyBag);
                HRESULT OperationResult = MappingFreePropertyBag(ref ELSMetadata.PropertyBag);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                ELSMetadata.TextRecognitionUserAsyncMethod!.Invoke(Results);
                ELSMetadata.TextRecognitionUserAsyncMethod = null;
                ELSMetadata.InternalTextRecognitionCallback = null;
            }
        }

        /// <summary>
        /// Attiva il tracciamento della finestra attiva.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public static void SetActiveWindowTracking()
        {
            GCHandle ClientAreaAnimationStatus = GCHandle.Alloc(Convert.ToInt32(false), GCHandleType.Pinned);
            SystemParameterUserProfileUpdateOptions Option = SystemParameterUserProfileUpdateOptions.NoAction;
            if (WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions.SystemParametersInfo((uint)SystemParametersWindows.SPI_SETACTIVEWINDOWTRACKING, 0, ClientAreaAnimationStatus.AddrOfPinnedObject(), Option))
            {
                ClientAreaAnimationStatus.Free();
            }
            else
            {
                ClientAreaAnimationStatus.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }
    }
}