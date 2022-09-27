using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonMessages;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons.Enumerations;
using WinApiWrapper.UserInterface.UserInterfaceElements.Buttons;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Permette di utilizzare le funzioni di sistema relative ai pulsanti.
    /// </summary>
    public static class ButtonManaged
    {
        /// <summary>
        /// Recupera la dimensione ideale di un pulsante e della sua immagine.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> con informazioni sul pulsante.</param>
        /// <param name="Width">Larghezza desiderata del pulsante.</param>
        /// <returns>Una struttura <see cref="Size"/> con la dimensione ideale del pulsante, nullo se l'informazione non può essere recuperata.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static Size? GetButtonIdealSize(ButtonInfo ButtonInfo, int? Width = null)
        {
            if (ButtonInfo is not null)
            {
                LPARAM DesiredWidth = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SIZE)));
                SIZE SizeStructure = new();
                if (Width.HasValue)
                {
                    if (Width.Value is not > 0)
                    {
                        throw new ArgumentException("The parameter value must be higher than 0.");
                    }
                    else
                    {
                        SizeStructure.x = Width.Value;
                        SizeStructure.y = 0;
                    }
                }
                else
                {
                    SizeStructure.x = 0;
                    SizeStructure.y = 0;
                }
                Marshal.StructureToPtr(SizeStructure, DesiredWidth, false);
                LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_GETIDEALSIZE, HMODULE.Zero, DesiredWidth);
                if (Convert.ToBoolean(Result.ToInt32()))
                {
                    SizeStructure = (SIZE)Marshal.PtrToStructure(DesiredWidth, typeof(SIZE))!;
                    Marshal.FreeHGlobal(DesiredWidth);
                    return new(SizeStructure.x, SizeStructure.y);
                }
                else
                {
                    Marshal.FreeHGlobal(DesiredWidth);
                    return null;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Recupera lo stato di selezione di un pulsante.
        /// </summary>
        /// <param name="DialogInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra di dialogo che contiene il pulsante.</param>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <returns>Un valore dell'enumerazione <see cref="ButtonState"/> che indica lo stato del pulsante.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static ButtonState GetCheckState(WindowInfo DialogInfo, ButtonInfo ButtonInfo)
        {
            if (DialogInfo is not null && ButtonInfo is not null)
            {
                ButtonStyles Styles = (ButtonStyles)WindowsFunctions.GetWindowLongPtr(ButtonInfo.Handle, (int)WindowDataSpecialOffset.GWL_STYLE).ToInt32();
                bool HasValidStyle =
                    Styles.HasFlag(ButtonEnumerations.ButtonStyles.BS_AUTOCHECKBOX) ||
                    Styles.HasFlag(ButtonEnumerations.ButtonStyles.BS_AUTORADIOBUTTON) ||
                    Styles.HasFlag(ButtonEnumerations.ButtonStyles.BS_AUTO3STATE) ||
                    Styles.HasFlag(ButtonEnumerations.ButtonStyles.BS_CHECKBOX) ||
                    Styles.HasFlag(ButtonEnumerations.ButtonStyles.BS_RADIOBUTTON) ||
                    Styles.HasFlag(ButtonEnumerations.ButtonStyles.BS_3STATE);
                if (!HasValidStyle)
                {
                    if (ButtonInfo.ID.HasValue)
                    {
                        return (ButtonState)ButtonFunctions.IsButtonChecked(DialogInfo.Handle, ButtonInfo.ID.Value);
                    }
                    else
                    {
                        LRESULT Result = SendMessage(ButtonInfo.Handle, BM_GETCHECK, HMODULE.Zero, HMODULE.Zero);
                        return (ButtonState)Convert.ToInt32(Result.ToInt32());
                    }
                }
                else
                {
                    throw new InvalidOperationException("No valid style applied to the button.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Recupera lo/gli stato/i applicati al pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <returns>Un array di valori dell'enumerazione <see cref="ButtonState"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ButtonState[] GetState(ButtonInfo ButtonInfo)
        {
            if (ButtonInfo is not null)
            {
                LRESULT Result = SendMessage(ButtonInfo.Handle, BM_GETSTATE, HMODULE.Zero, HMODULE.Zero);
                ButtonState CompositionValue = (ButtonState)Result.ToInt32();
                List<ButtonState> States = new();
                int[] Values = (int[])Enum.GetValues(typeof(ButtonState));
                foreach (int value in Values)
                {
                    if (CompositionValue.HasFlag((ButtonState)value))
                    {
                        States.Add((ButtonState)value);
                    }
                }
                return States.ToArray();
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Cambio lo stato di selezione di un pulsante.
        /// </summary>
        /// <param name="DialogInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra di dialogo che contiene il pulsante.</param>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="NewState">Nuovo stato da impostare.</param>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void ChangeCheckState(WindowInfo DialogInfo, ButtonInfo ButtonInfo, ButtonState NewState)
        {
            if (DialogInfo is not null && ButtonInfo is not null)
            {
                if (NewState is not ButtonState.Unchecked and not ButtonState.Indeterminate and not ButtonState.Checked)
                {
                    throw new InvalidEnumArgumentException(nameof(NewState), (int)NewState, typeof(ButtonState));
                }
                else
                {
                    if (!ButtonInfo.ID.HasValue)
                    {
                        WPARAM NewCheckState = new((int)NewState);
                        _ = SendMessage(ButtonInfo.Handle, BM_SETCHECK, NewCheckState, HMODULE.Zero);
                        if (GetCheckState(DialogInfo, ButtonInfo) != NewState)
                        {
                            throw new Exception("The check state could not be changed.");
                        }
                    }
                    else
                    {
                        if (!ButtonFunctions.ChangeButtonState(DialogInfo.Handle, ButtonInfo.ID.Value, (ButtonEnumerations.ButtonState)NewState))
                        {
                            throw new Win32Exception(Marshal.GetLastPInvokeError());
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(string.Empty, "DialogInfo and ButtonInfo cannot be null.");
            }
        }

        /// <summary>
        /// Seleziona un radio button e deseleziona tutti gli altri appartenenti allo stesso gruppo.
        /// </summary>
        /// <param name="DialogInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra di dialogo che contiene il pulsante.</param>
        /// <param name="FirstButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al primo pulsante del gruppo.</param>
        /// <param name="LastButtonInfo">Istanza di <see cref="ButtonInfo"/> associata all'ultimo pulsante del gruppo.</param>
        /// <param name="ButtonToCheckInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante da selezionare.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CheckRadioButton(WindowInfo DialogInfo, ButtonInfo FirstButtonInfo, ButtonInfo LastButtonInfo, ButtonInfo ButtonToCheckInfo)
        {
            if (DialogInfo is not null && FirstButtonInfo is not null && LastButtonInfo is not null && ButtonToCheckInfo is not null)
            {
                if (FirstButtonInfo.ID.HasValue && LastButtonInfo.ID.HasValue && ButtonToCheckInfo.ID.HasValue)
                {
                    if (!ButtonFunctions.CheckRadioButton(DialogInfo.Handle, FirstButtonInfo.ID.Value, LastButtonInfo.ID.Value, ButtonToCheckInfo.ID.Value))
                    {
                        throw new Win32Exception(Marshal.GetLastPInvokeError());
                    }
                }
                else
                {
                    throw new InvalidOperationException("The IDs of the button must be available.");
                }
            }
            else
            {
                throw new ArgumentNullException(string.Empty, "All parameters must not be null.");
            }
        }

        /// <summary>
        /// Cambia lo stato del dropdown di un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="DropdownActive">Indica se il dropdown deve essere visibile o meno.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ChangeDropDownState(ButtonInfo ButtonInfo, bool DropdownActive)
        {
            if (ButtonInfo is not null)
            {
                WPARAM DropdownState = new(Convert.ToInt32(DropdownActive));
                LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_SETDROPDOWNSTATE, DropdownState, HMODULE.Zero);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not set the dropdown state.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Assegna una lista immagini a un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="ImageListInfo">Istanza di <see cref="ButtonImageListInfo"/> associa alla lista immagini.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AssignImageList(ButtonInfo ButtonInfo, ButtonImageListInfo ImageListInfo)
        {
            if (ImageListInfo is not null)
            {
                BUTTON_IMAGELIST ImageListDataStructure = ImageListInfo.ToStruct();
                LPARAM ImageListDataStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(ImageListDataStructure));
                Marshal.StructureToPtr(ImageListDataStructure, ImageListDataStructurePointer, false);
                LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_SETIMAGELIST, HMODULE.Zero, ImageListDataStructurePointer);
                Marshal.FreeHGlobal(ImageListDataStructurePointer);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not assign the image list to the button.");
                }
            }
            else
            {
                throw new ArgumentNullException(string.Empty, "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Imposta la nota associata al pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="NoteText">Testo della nota.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetNote(ButtonInfo ButtonInfo, string NoteText)
        {
            if (ButtonInfo is not null)
            {
                LPARAM NoteTextPointer = Marshal.StringToHGlobalUni(NoteText);
                LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_SETNOTE, HMODULE.Zero, NoteTextPointer);
                Marshal.FreeHGlobal(NoteTextPointer);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not set the note of the button.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Imposta lo stato di elevazione richiesto del pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="IsElevationRequired">Indica se il pulsante richiede l'elevazione o meno.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetElevationRequiredState(ButtonInfo ButtonInfo, bool IsElevationRequired)
        {
            if (ButtonInfo is not null)
            {
                LPARAM ElevationRequiredState = Marshal.AllocHGlobal(4);
                Marshal.WriteInt32(ElevationRequiredState, Convert.ToInt32(IsElevationRequired));
                LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_SETSHIELD, HMODULE.Zero, ElevationRequiredState);
                Marshal.FreeHGlobal(ElevationRequiredState);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not set the elevation required status for the button.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Imposta alcune informazioni su uno split button.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="SplitButtonInfo">Istanza di <see cref="SplitButtonInfo"/> che contiene le informazioni da impostare.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetSplitButtonInfo(ButtonInfo ButtonInfo, SplitButtonInfo SplitButtonInfo)
        {
            if (ButtonInfo is not null && SplitButtonInfo is not null)
            {
                if (ButtonInfo.ButtonStyles is not null)
                {
                    if (!ButtonInfo.ButtonStyles.Contains(ButtonStyles.SplitButton) && !ButtonInfo.ButtonStyles.Contains(ButtonStyles.AutoSelectionSplitButton))
                    {
                        throw new InvalidOperationException("No valid style applied to the button.");
                    }
                }
                BUTTON_SPLITINFO InfoStructure = SplitButtonInfo.ToStruct();
                LPARAM SplitButtonInfoStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(InfoStructure));
                Marshal.StructureToPtr(InfoStructure, SplitButtonInfoStructurePointer, false);
                LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_SETSPLITINFO, HMODULE.Zero, SplitButtonInfoStructurePointer);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not set information on the split button.");
                }
            }
            else
            {
                throw new ArgumentNullException(string.Empty, "The parameters cannot be null.");
            }
        }

        /// <summary>
        /// Imposta i margini del testo per un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="Margins">Istanza di <see cref="General.Rectangle"/> che definisce i margini del rettangolo.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetButtonTextMargins(ButtonInfo ButtonInfo, General.Rectangle Margins)
        {
            if (ButtonInfo is not null && Margins is not null)
            {
                if (Margins.Left > 0 && Margins.Right > 0 && Margins.Top > 0 && Margins.Bottom > 0)
                {
                    RECT MarginsStructure = Margins.ToRECT();
                    LPARAM MarginsStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(MarginsStructure));
                    LRESULT Result = SendMessage(ButtonInfo.Handle, BCM_SETTEXTMARGIN, HMODULE.Zero, MarginsStructurePointer);
                    Marshal.FreeHGlobal(MarginsStructurePointer);
                    if (!Convert.ToBoolean(Result.ToInt32()))
                    {
                        throw new Exception("Could not set the margins for the text.");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid margins.", nameof(Margins));
                }
            }
            else
            {
                throw new ArgumentNullException(string.Empty, "The parameters cannot be null.");
            }
        }

        /// <summary>
        /// Disabilita la generazione di notifiche "Clicked" per un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void DisableGenerationOfClickedNotifications(ButtonInfo ButtonInfo)
        {
            if (ButtonInfo is not null)
            {
                WPARAM NotificationStateValue = new(Convert.ToInt32(false));
                LRESULT Result = SendMessage(ButtonInfo.Handle, BM_SETDONTCLICK, NotificationStateValue, HMODULE.Zero);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not disable the generation of notifications.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Abilita la generazione di notifiche "Clicked" per un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void EnableGenerationOfClickedNotifications(ButtonInfo ButtonInfo)
        {
            if (ButtonInfo is not null)
            {
                WPARAM NotificationStateValue = new(Convert.ToInt32(true));
                LRESULT Result = SendMessage(ButtonInfo.Handle, BM_SETDONTCLICK, NotificationStateValue, HMODULE.Zero);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not enable the generation of notifications.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Imposta l'immagine di un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="BitmapImage">Immagine da impostare.</param>
        /// <param name="ImageType">Tipo di immagine.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetButtonImage(ButtonInfo ButtonInfo, Bitmap BitmapImage, ButtonImageType ImageType)
        {
            if (ButtonInfo is not null)
            {
                if (BitmapImage is null)
                {
                    throw new ArgumentNullException(string.Empty, "The image must not be null.");
                }
                else
                {
                    HMODULE ImageHandle = HMODULE.Zero;
                    switch (ImageType)
                    {
                        case ButtonImageType.Bitmap:
                            ImageHandle = BitmapImage.GetHbitmap();
                            break;
                        case ButtonImageType.Icon:
                            ImageHandle = BitmapImage.GetHicon();
                            break;
                    }
                    WPARAM ImageTypeValue = new((int)ImageType);
                    LRESULT Result = SendMessage(ButtonInfo.Handle, BM_SETIMAGE, ImageTypeValue, ImageHandle);
                    if (!Convert.ToBoolean(Result.ToInt32()))
                    {
                        throw new Exception("Could not set the new image.");
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Imposta lo stato di evidenziazione di un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="HighlightState">Indica lo stato di evidenziazione da usare.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetButtonHighlightState(ButtonInfo ButtonInfo, bool HighlightState)
        {
            if (ButtonInfo is not null)
            {
                WPARAM HighlightStateValue = new(Convert.ToInt32(HighlightState));
                LRESULT Result = SendMessage(ButtonInfo.Handle, BM_SETSTATE, HighlightStateValue, HMODULE.Zero);
                if (!Convert.ToBoolean(Result.ToInt32()))
                {
                    throw new Exception("Could not set the state.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }

        /// <summary>
        /// Imposta gli stili di un pulsante.
        /// </summary>
        /// <param name="ButtonInfo">Istanza di <see cref="ButtonInfo"/> associata al pulsante.</param>
        /// <param name="Styles">Stili da applicare.</param>
        /// <param name="Redraw">Indica se ridisegnare il pulsante.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetButtonStyle(ButtonInfo ButtonInfo, ButtonStyles Styles, bool Redraw)
        {
            if (ButtonInfo is not null)
            {
                WPARAM StylesValue = new((int)Styles);
                LPARAM RedrawValue = new(Convert.ToInt32(Redraw));
                LRESULT Result = SendMessage(ButtonInfo.Handle, BM_SETSTYLE, StylesValue, RedrawValue);
                ButtonStyles CurrentStyles = (ButtonStyles)WindowsFunctions.GetWindowLongPtr(ButtonInfo.Handle, (int)WindowDataSpecialOffset.GWL_STYLE).ToInt32();
                if ((int)Styles != (int)CurrentStyles)
                {
                    throw new Exception("Could not apply the styles to the button.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ButtonInfo), "The parameter cannot be null.");
            }
        }
    }
}