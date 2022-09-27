using System.ComponentModel;
using System.Text;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportConstants;
using static WinApiWrapper.UserInterface.NationalLanguageSupport.NationalLanguageSupportFunctions;
using static WinApiWrapper.Managed.UserInterface.MultilingualUserInterface.Enumerations;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUICallbacks;
using static WinApiWrapper.UserInterface.MultilingualUserInterface.MUIFunctions;
using System.Globalization;
using Windows.Globalization;
using WinApiWrapper.UserInterface.MultilingualUserInterface;

namespace WinApiWrapper.Managed.UserInterface.MultilingualUserInterface
{
    /// <summary>
    /// Permette di interagire con le funzionalità MUI (Multilingual User Interface).
    /// </summary>
    public static class MUIManaged
    {
        /// <summary>
        /// Lista di lingue installate.
        /// </summary>
        private static List<UILanguageInfo>? EnumeratedLanguages;

        /// <summary>
        /// Enumera le lingue dell'interfaccia utente installate.
        /// </summary>
        /// <param name="Format">Formato delle lingue.</param>
        /// <returns>Un array di <see cref="UILanguageInfo"/> con le informazioni sulle lingue.</returns>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static UILanguageInfo[] EnumerateLanguages(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not Enumerations.LanguageFormat.ID and not Enumerations.LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            EnumeratedLanguages = new();
            EnumUILanguagesProc Callback = new(EnumerationCallback);
            GCHandle LanguageFormat = GCHandle.Alloc((uint)Format, GCHandleType.Pinned);
            if (EnumUILanguages(Callback, (MUIEnumerations.LanguageFormat)Format, LanguageFormat.AddrOfPinnedObject()))
            {
                LanguageFormat.Free();
                return EnumeratedLanguages.ToArray();
            }
            else
            {
                LanguageFormat.Free();
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Elabora le lingue enumerate da <see cref="EnumerateLanguages"/>.
        /// </summary>
        /// <param name="LanguageString">Nome o ID della lingua.</param>
        /// <param name="Param">Formato della lingua.</param>
        /// <returns>true per continuare l'enumerazione, false altrimenti.</returns>
        private static bool EnumerationCallback(HMODULE LanguageString, HMODULE Param)
        {
            try
            {
                string Language = Marshal.PtrToStringUni(LanguageString)!;
                LanguageFormat Format = (LanguageFormat)Marshal.ReadInt32(Param);
                UILanguageInfo LangInfo = new(Language, Format);
                EnumeratedLanguages!.Add(LangInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Recupera i percorsi dei file di risorse lingua specifici associati al file di lingua neutrale fornito.
        /// </summary>
        /// <param name="FilePath">Percorso del file di lingua neutrale.</param>
        /// <param name="Format">Formato della lingua.</param>
        /// <param name="Filter">Filtro da applicare alla ricerca.</param>
        /// <param name="FileType">Tipo del file indicato da <paramref name="FilePath"/>.</param>
        /// <param name="Language">Lingua di cui cercare i file di risorse.</param>
        /// <returns>Array di stringhe con i percorsi dei file.</returns>
        /// <remarks>Il file indicato da <paramref name="FilePath"/> può essere anche un file di tipo .txt, .inf, .msc specifico della lingua.<br/><br/>
        /// <paramref name="Filter"/> permette di specificare quali file recuperare di tutti quelli disponibili.<br/><br/>
        /// <paramref name="FileType"/> permette di specificare se il file indicato da <paramref name="FilePath"/> è un file di lingua neutrale o un file specifico della lingua.<br/><br/>
        /// Se <paramref name="Filter"/> ha un valore specificato, <paramref name="Language"/> viene ignorato.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static string[] GetLanguageResourceFilesPath(string FilePath, LanguageFormat Format = LanguageFormat.Name, ResourceFileSearchFilter? Filter = null, ResourceFileType? FileType = null, string Language = "")
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                throw new ArgumentNullException(nameof(FilePath), "The file path cannot be null.");
            }
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            List<string> FilePaths = new();
            StringBuilder LanguageName = new(LOCALE_NAME_MAX_LENGTH);
            StringBuilder MUIFilePath = new(MAX_PATH);
            uint LanguageNameSize = LOCALE_NAME_MAX_LENGTH;
            uint MUIFilePathSize = MAX_PATH;
            ulong Enumerator = 0;
            uint Flags = (uint)Format;
            if (Filter.HasValue)
            {
                if (Filter is not ResourceFileSearchFilter.FallbackLanguagesOnly and not ResourceFileSearchFilter.InstalledLanguagesOny and ResourceFileSearchFilter.AllLanguages)
                {
                    throw new InvalidEnumArgumentException(nameof(Filter), (int)Filter, typeof(ResourceFileSearchFilter));
                }
                Flags |= (uint)Filter.Value;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Language))
                {
                    if (Format is LanguageFormat.ID)
                    {
                        if (Language.StartsWith("0x"))
                        {
                            throw new ArgumentException("Language incorrectly formatted.", nameof(Language));
                        }
                    }
                    LanguageName.Append(Language);
                }
            }
            if (FileType.HasValue)
            {
                if (FileType is not ResourceFileType.LanguageNeutral and not ResourceFileType.NonLanguageNeutral)
                {
                    throw new InvalidEnumArgumentException(nameof(FileType), (int)FileType, typeof(ResourceFileType));
                }
                Flags |= (uint)FileType.Value;
            }
            bool Result = GetFileMUIPath(Flags, FilePath, LanguageName, ref LanguageNameSize, MUIFilePath, ref MUIFilePathSize, ref Enumerator);
            if (Result)
            {
                FilePaths.Add(MUIFilePath.ToString());
                while (Result)
                {
                    LanguageName.Clear();
                    Result = GetFileMUIPath(Flags, FilePath, LanguageName, ref LanguageNameSize, MUIFilePath, ref MUIFilePathSize, ref Enumerator);
                    if (Result)
                    {
                        FilePaths.Add(MUIFilePath.ToString());
                    }
                }
                int ErrorCode = Marshal.GetLastPInvokeError();
                if (ErrorCode is not ERROR_NO_MORE_FILES)
                {
                    throw new Win32Exception(ErrorCode);
                }
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            return FilePaths.ToArray();
        }

        /// <summary>
        /// Recupera la lingua predefinita del processo.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <returns>Il nome o l'ID della lingua predefinita del processo.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.<br/><br/>
        /// Se non è impostata una lingua predefinita oppure la lingua impostata non è valida il valore di ritorno è nullo.</remarks>
        public static string? GetProcessDefaultLanguage(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            bool Result = GetProcessPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                if (BufferSize > 2)
                {
                    string Language;
                    Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                    Result = GetProcessPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
                    if (!Result)
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    else
                    {
                        Language = Marshal.PtrToStringUni(Buffer)!;
                        Marshal.FreeHGlobal(Buffer);
                        return Language;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupera la lista di lingue preferite del processo.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <returns>Un array di stringhe che contiene le lingue preferite del processo.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, le stringhe contenute nell'array rappresentano un numero esadecimale senza prefisso.<br/><br/>
        /// Se non sono impostate delle lingue preferite oppure le lingue impostate non sono valide il valore di ritorno è nullo.</remarks>
        public static string[]? GetProcessPreferredLanguages(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            bool Result = GetProcessPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                string[] Languages;
                if (BufferSize > 2)
                {
                    Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                    Result = GetProcessPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
                    if (!Result)
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    else
                    {
                        HMODULE SecondBuffer = Buffer;
                        Languages = MultiStringToArray(SecondBuffer);
                    }
                    Marshal.FreeHGlobal(Buffer);
                    return Languages;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupera la lingua predefinita del thread.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <returns>La lingua predefinita del thread.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.<br/><br/>
        /// Se non è impostata una lingua predefinita oppure la lingua impostata non è valida il valore di ritorno è nullo.</remarks>
        public static string? GetThreadDefaultLanguage(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            uint Flags = (uint)Format | (uint)MUIEnumerations.ThreadLanguageFilter.MUI_UI_FALLBACK;
            bool Result = GetThreadPreferredUILanguages(Flags, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                if (BufferSize > 2)
                {
                    string Language;
                    Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                    Result = GetThreadPreferredUILanguages(Flags, out _, Buffer, ref BufferSize);
                    if (!Result)
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    else
                    {
                        Language = Marshal.PtrToStringUni(Buffer)!;
                        Marshal.FreeHGlobal(Buffer);
                        return Language;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupera la lista di lingue preferite del thread corrente.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <param name="IncludeNeutralLanguages">Indica se includere le lingue neutrali.</param>
        /// <param name="IncludeProcessUserAndSystemDefaultLanguages">Indica se includere le lingue preferite del processo, dell'utente, del sistema e la lingua predefinita di quest'ultimo.</param>
        /// <returns>Un array di stringhe che include le lingue preferite del thread.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.<br/><br/>
        /// Se la lista è vuota oppure se le lingue impostate non sono valide il valore di ritorno è nullo.</remarks>
        public static string[]? GetThreadPreferredLanguages(LanguageFormat Format = LanguageFormat.Name, bool IncludeNeutralLanguages = false, bool IncludeProcessUserAndSystemDefaultLanguages = false)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            uint Flags = (uint)Format;
            if (IncludeNeutralLanguages && IncludeProcessUserAndSystemDefaultLanguages)
            {
                Flags |= (uint)MUIEnumerations.ThreadLanguageFilter.MUI_UI_FALLBACK;
            }
            else
            {
                if (IncludeNeutralLanguages)
                {
                    Flags |= (uint)MUIEnumerations.ThreadLanguageFilter.MUI_MERGE_SYSTEM_FALLBACK;
                }
                if (IncludeProcessUserAndSystemDefaultLanguages)
                {
                    Flags |= (uint)MUIEnumerations.ThreadLanguageFilter.MUI_MERGE_USER_FALLBACK;
                }
            }
            if (!IncludeNeutralLanguages && !IncludeProcessUserAndSystemDefaultLanguages)
            {
                Flags |= (uint)MUIEnumerations.ThreadLanguageFilter.MUI_THREAD_LANGUAGES;
            }
            bool Result = GetThreadPreferredUILanguages(Flags, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                if (BufferSize > 2)
                {
                    string[] Languages;
                    Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                    Result = GetThreadPreferredUILanguages(Flags, out _, Buffer, ref BufferSize);
                    if (!Result)
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    else
                    {
                        Languages = MultiStringToArray(Buffer);
                    }
                    Marshal.FreeHGlobal(Buffer);
                    return Languages;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupera la lingua predefinita dell'utente.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <returns>La lingua predefinita dell'utente.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.</remarks>
        public static string GetUserDefaultLanguage(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            bool Result = GetUserPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                string Language;
                Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                Result = GetUserPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
                if (!Result)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
                else
                {
                    Language = Marshal.PtrToStringUni(Buffer)!;
                }
                Marshal.FreeHGlobal(Buffer);
                return Language;
            }
        }

        /// <summary>
        /// Recupera la lista di lingue preferite dell'utente.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <returns>Un array di stringhe che include le lingue preferite dell'utente.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.</remarks>
        public static string[] GetUserPreferredLanguages(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            bool Result = GetUserPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                string[] Languages;
                Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                Result = GetUserPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, out _, Buffer, ref BufferSize);
                if (!Result)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
                else
                {
                    Languages = MultiStringToArray(Buffer);
                }
                Marshal.FreeHGlobal(Buffer);
                return Languages;
            }
        }

        /// <summary>
        /// Recupera la lingua predefinita del sistema.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <returns>La lingua predefinita del sistema.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.<br/><br/>
        /// Se la lingua predefinita del sistema non è impostata il valore di ritorno è nullo.</remarks>
        public static string? GetSystemDefaultLanguage(LanguageFormat Format = LanguageFormat.Name)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            bool Result = GetSystemPreferredUILanguages((uint)Format, out _, Buffer, ref BufferSize);
            if (!Result)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                if (BufferSize > 2)
                {
                    string Language;
                    Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                    Result = GetSystemPreferredUILanguages((uint)Format, out _, Buffer, ref BufferSize);
                    if (!Result)
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    else
                    {
                        Language = Marshal.PtrToStringUni(Buffer)!;
                    }
                    Marshal.FreeHGlobal(Buffer);
                    return Language;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupera la lista di lingue preferite dal sistema.
        /// </summary>
        /// <param name="Format">Formato della lingua.</param>
        /// <param name="OnlyCheckIfValid">Indica se controllare solamente la validità delle voci della lista.</param>
        /// <returns>Un array di stringhe che include le lingue preferite del thread.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, la stringa restituita rappresenta un numero esadecimale senza prefisso.<br/><br/>
        /// Se la lista è vuota oppure se le lingue impostate non sono valide il valore di ritorno è nullo.<br/><br/>
        /// Se <paramref name="OnlyCheckIfValid"/> è true, la lista potrebbe: <br/><br/>
        /// Includere lingue non installate<br/>
        /// Includere voci duplicate<br/>
        /// Essere vuota<br/><br/>
        /// Se <paramref name="OnlyCheckIfValid"/> è false, la lista: <br/><br/>
        /// Comprende lingue che rappresentano una località valida<br/>
        /// Comprende lingue installate<br/>
        /// Non ha voci duplicate</remarks>
        public static string[]? GetSystemPreferredLanguages(LanguageFormat Format = LanguageFormat.Name, bool OnlyCheckIfValid = false)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            uint BufferSize = 0;
            HMODULE Buffer = HMODULE.Zero;
            uint Flags = (uint)Format;
            if (OnlyCheckIfValid)
            {
                Flags |= MUIConstants.MUI_MACHINE_LANGUAGE_SETTINGS;
            }
            bool Result = GetSystemPreferredUILanguages(Flags, out _, Buffer, ref BufferSize);
            if (!Result && Marshal.GetLastPInvokeError() is not ERROR_INSUFFICIENT_BUFFER)
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                string[] Languages;
                if (BufferSize > 2)
                {
                    Buffer = Marshal.AllocHGlobal((int)BufferSize * 2);
                    Result = GetSystemPreferredUILanguages(Flags, out _, Buffer, ref BufferSize);
                    if (!Result)
                    {
                        Marshal.FreeHGlobal(Buffer);
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                    else
                    {
                        HMODULE SecondBuffer = Buffer;
                        Languages = MultiStringToArray(SecondBuffer);
                    }
                    Marshal.FreeHGlobal(Buffer);
                    return Languages;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Imposta le lingue preferite per il processo.
        /// </summary>
        /// <param name="Languages">Lista di lingue.</param>
        /// <param name="Format">Formato delle lingue nella lista.</param>
        /// <param name="ClearList">Indica se la lista di lingue esistente deve essere svuotata.</param>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, le lingue nella lista devono essere indicate con i relativi ID esadecimali senza prefisso.<br/><br/>
        /// Si possono impostare massimo 5 lingue, in ordine di preferenza, tutte le altre verranno ignorate.<br/><br/>
        /// Se <paramref name="ClearList"/> è true, <paramref name="Languages"/> verrà ignorato.</remarks>
        public static void SetProcessPreferredLanguages(List<string>? Languages, LanguageFormat Format, bool ClearList = false)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            if ((Languages is null || Languages.Count == 0) && !ClearList)
            {
                throw new ArgumentException("The languages list cannot be null or empty.", nameof(Languages));
            }
            string? LanguagesMultiString = null;
            if (!ClearList)
            {
                if (Format is LanguageFormat.ID)
                {
                    foreach (string language in Languages!)
                    {
                        if (!uint.TryParse(language, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
                        {
                            throw new ArgumentException("The languages in the list are incorrectly formatted.", nameof(Languages));
                        }
                    }
                }
                else if (Format is LanguageFormat.Name)
                {
                    foreach (string language in Languages!)
                    {
                        if (!IsValidLocaleName(language))
                        {
                            throw new ArgumentException("The list contains invalid locales.", nameof(Languages));
                        }
                    }
                }
                StringBuilder LanguagesBufferBuilder = new();
                for (int i = 0; i < 5; i++)
                {
                    LanguagesBufferBuilder.Append(Languages![i]);
                    LanguagesBufferBuilder.Append('\0');
                }
                LanguagesBufferBuilder.Append('\0');
                LanguagesMultiString = LanguagesBufferBuilder.ToString();
            }
            if (!SetProcessPreferredUILanguages((MUIEnumerations.LanguageFormat)Format, LanguagesMultiString, out uint LanguagesCount))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta le lingue preferite per il thread.
        /// </summary>
        /// <param name="Languages">Lista di lingue.</param>
        /// <param name="Format">Formato delle lingue in <paramref name="Languages"/>.</param>
        /// <param name="Filter">Filtro da applicare alla lista.</param>
        /// <param name="ClearList">Indica se la lista di lingue esistente deve essere svuotata.</param>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>Se <paramref name="Format"/> ha valore <see cref="LanguageFormat.ID"/>, le lingue nella lista devono essere indicate con i relativi ID esadecimali senza prefisso.<br/><br/>
        /// Si possono impostare massimo 5 lingue, in ordine di preferenza, tutte le altre verranno ignorate.<br/><br/>
        /// Se <paramref name="ClearList"/> è true oppure se è stato assegnato un valore a <paramref name="Filter"/>, <paramref name="Languages"/> verrà ignorato.</remarks>
        public static void SetThreadPreferredLanguages(List<string>? Languages, LanguageFormat Format, ThreadSetFilter? Filter = null, bool ClearList = false)
        {
            if (Format is not LanguageFormat.ID and not LanguageFormat.Name)
            {
                throw new InvalidEnumArgumentException(nameof(Format), (int)Format, typeof(LanguageFormat));
            }
            if ((Languages is null || Languages.Count == 0) && !ClearList)
            {
                throw new ArgumentException("The languages list cannot be null or empty.", nameof(Languages));
            }
            uint Flags = (uint)Format;
            string? LanguagesMultiString = null;
            HMODULE LanguagesCountPointer = HMODULE.Zero;
            if (!Filter.HasValue)
            {
                if (ClearList)
                {
                    LanguagesMultiString = "\0\0";
                    Flags = 0;
                }
                else
                {
                    if (Format is LanguageFormat.ID)
                    {
                        foreach (string language in Languages!)
                        {
                            if (!uint.TryParse(language, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
                            {
                                throw new ArgumentException("The languages in the list are incorrectly formatted.", nameof(Languages));
                            }
                        }
                    }
                    else if (Format is LanguageFormat.Name)
                    {
                        foreach (string language in Languages!)
                        {
                            if (!IsValidLocaleName(language))
                            {
                                throw new ArgumentException("The list contains invalid locales.", nameof(Languages));
                            }
                        }
                    }
                    StringBuilder LanguagesBufferBuilder = new();
                    for (int i = 0; i < 5; i++)
                    {
                        LanguagesBufferBuilder.Append(Languages![i]);
                        LanguagesBufferBuilder.Append('\0');
                    }
                    LanguagesBufferBuilder.Append('\0');
                    LanguagesMultiString = LanguagesBufferBuilder.ToString();
                    LanguagesCountPointer = Marshal.AllocHGlobal(4);
                }
            }
            else
            {
                if (Filter.Value is not ThreadSetFilter.ResetFilters and not ThreadSetFilter.ReplaceNonConsoleUsableLanguages and not ThreadSetFilter.ReplaceComplexScriptLanguages)
                {
                    throw new InvalidEnumArgumentException(nameof(Filter), (int)Filter, typeof(ThreadSetFilter));
                }
                Flags |= (uint)Filter.Value;
            }
            if (!SetThreadPreferredUILanguages(Flags, LanguagesMultiString, LanguagesCountPointer))
            {
                Marshal.FreeHGlobal(LanguagesCountPointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
            else
            {
                Marshal.FreeHGlobal(LanguagesCountPointer);
            }
        }
    }
}