using System.Drawing;
using WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonMessages;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.MessagesAndMessageQueues.MessageFunctions;
using static WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons.Enumerations;
using static WinApiWrapper.General.GeneralStructures;
using WinApiWrapper.Managed.General;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using WinApiWrapper.UserInterface.UserInterfaceElements.Buttons;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Informazioni su un pulsante.
    /// </summary>
    public class ButtonInfo : WindowInfo
    {
        /// <summary>
        /// Stili del pulsante.
        /// </summary>
        public ButtonStyles[]? ButtonStyles { get; }

        /// <summary>
        /// Informazioni sulla lista di immagini associata al pulsante.
        /// </summary>
        public ButtonImageListInfo? ImageListInfo { get; }

        /// <summary>
        /// Note associata.
        /// </summary>
        /// <remarks>Valido solo se <see cref="ButtonStyles"/> contiene <see cref="ButtonStyles.CommandLink"/> oppure <see cref="ButtonStyles.AutoSelectionCommandLink"/>.</remarks>
        public string? Note { get; }

        /// <summary>
        /// Informazioni specifiche per uno split button.
        /// </summary>
        public SplitButtonInfo? SplitButtonInfo { get; }

        /// <summary>
        /// Margini del testo.
        /// </summary>
        public General.Rectangle? TextMargins { get; }

        /// <summary>
        /// Immagine associata al pulsante.
        /// </summary>
        public Bitmap? AssociatedImage { get; }

        /// <summary>
        /// Icona associata al pulsante.
        /// </summary>
        public Icon? AssociatedIcon { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="ButtonInfo"/>.
        /// </summary>
        /// <param name="Handle">Handle al pulsante.</param>
        internal ButtonInfo(HWND Handle) : base(Handle)
        {
            IntPtr StyleValue = WindowsFunctions.GetWindowLongPtr(Handle, (int)WindowDataSpecialOffset.GWL_STYLE);
            if (StyleValue != IntPtr.Zero)
            {
                ButtonStyles Styles = (ButtonStyles)StyleValue.ToInt32();
                ButtonStyles = GetButtonStyles(Styles);
            }
            else
            {
                ButtonStyles = null;
            }
            ImageListInfo = GetImageListInfo();
            Note = GetNote();
            SplitButtonInfo = GetSplitButtonInfo();
            TextMargins = GetTextMargins();
            AssociatedImage = GetImage();
            AssociatedIcon = GetIcon();
        }

        /// <summary>
        /// Recupera informazioni sulla lista immagini associata a un pulsante.
        /// </summary>
        /// <returns>Istanza di <see cref="ButtonImageListInfo"/> con le informazioni sulla lista, nullo se l'informazione non può essere recuperata.</returns>
        private ButtonImageListInfo? GetImageListInfo()
        {
            LPARAM ImageListDataStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BUTTON_IMAGELIST)));
            BUTTON_IMAGELIST ImageListDataStructure = new();
            Marshal.StructureToPtr(ImageListDataStructure, ImageListDataStructurePointer, false);
            LRESULT Result = SendMessage(Handle, BCM_GETIMAGELIST, IntPtr.Zero, ImageListDataStructurePointer);
            if (Convert.ToBoolean(Result.ToInt32()))
            {
                ImageListDataStructure = (BUTTON_IMAGELIST)Marshal.PtrToStructure(ImageListDataStructurePointer, typeof(BUTTON_IMAGELIST))!;
                Marshal.FreeHGlobal(ImageListDataStructurePointer);
                return new ButtonImageListInfo(ImageListDataStructure);
            }
            else
            {
                Marshal.FreeHGlobal(ImageListDataStructurePointer);
                return null;
            }
        }

        /// <summary>
        /// Recupera la nota associato a un pulsante di comando.
        /// </summary>
        /// <returns>Il testo della nota, nullo se non è stato possibile recuperare l'informazione, una stringa vuota se la nota non contiene testo.</returns>
        public string? GetNote()
        {
            if (ButtonStyles is not null)
            {
                if (ButtonStyles.Contains(Enumerations.ButtonStyles.CommandLink) || ButtonStyles.Contains(Enumerations.ButtonStyles.AutoSelectionCommandLink))
                {
                    LRESULT Result = SendMessage(Handle, BCM_GETNOTELENGTH, IntPtr.Zero, IntPtr.Zero);
                    if (Result != IntPtr.Zero)
                    {
                        WPARAM BufferSize = new(Result.ToInt32() + 1);
                        LPARAM BufferPointer = Marshal.AllocHGlobal(Result.ToInt32() * 2);
                        Result = SendMessage(Handle, BCM_GETNOTE, BufferSize, BufferPointer);
                        if (Convert.ToBoolean(Result.ToInt32()))
                        {
                            string NoteText = Marshal.PtrToStringUni(BufferPointer)!;
                            Marshal.FreeHGlobal(BufferPointer);
                            return NoteText;
                        }
                        else
                        {
                            Marshal.FreeHGlobal(BufferPointer);
                            return null;
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Recupera informazioni specifiche per uno split button.
        /// </summary>
        /// <returns>Istanza di <see cref="SplitButtonInfo"/> con le informazioni.</returns>
        private SplitButtonInfo? GetSplitButtonInfo()
        {
            if (ButtonStyles is not null)
            {
                if (ButtonStyles.Contains(Enumerations.ButtonStyles.SplitButton) || ButtonStyles.Contains(Enumerations.ButtonStyles.AutoSelectionSplitButton))
                {
                    BUTTON_SPLITINFO Info = new()
                    {
                        ValidMembers =
                            ButtonEnumerations.SplitButtonInfoValidMembers.BCSIF_GLYPH |
                            ButtonEnumerations.SplitButtonInfoValidMembers.BCSIF_IMAGE |
                            ButtonEnumerations.SplitButtonInfoValidMembers.BCSIF_STYLE |
                            ButtonEnumerations.SplitButtonInfoValidMembers.BCSIF_SIZE
                    };
                    LPARAM SplitButtonInfoStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(Info));
                    Marshal.StructureToPtr(Info, SplitButtonInfoStructurePointer, false);
                    LRESULT Result = SendMessage(Handle, BCM_GETSPLITINFO, IntPtr.Zero, SplitButtonInfoStructurePointer);
                    if (Convert.ToBoolean(Result.ToInt32()))
                    {
                        Info = (BUTTON_SPLITINFO)Marshal.PtrToStructure(SplitButtonInfoStructurePointer, typeof(BUTTON_SPLITINFO))!;
                        Marshal.FreeHGlobal(SplitButtonInfoStructurePointer);
                        return new SplitButtonInfo(Info);
                    }
                    else
                    {
                        Marshal.FreeHGlobal(SplitButtonInfoStructurePointer);
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Recupera i margini del testo.
        /// </summary>
        /// <returns>Istanza di <see cref="Rectangle"/> con le informazioni.</returns>
        private General.Rectangle? GetTextMargins()
        {
            RECT MarginsRectangle = new();
            LPARAM RectangleStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(MarginsRectangle));
            Marshal.StructureToPtr(MarginsRectangle, RectangleStructurePointer, false);
            LRESULT Result = SendMessage(Handle, BCM_GETTEXTMARGIN, IntPtr.Zero, RectangleStructurePointer);
            if (Convert.ToBoolean(Result.ToInt32()))
            {
                MarginsRectangle = (RECT)Marshal.PtrToStructure(RectangleStructurePointer, typeof(RECT))!;
                Marshal.FreeHGlobal(RectangleStructurePointer);
                return new General.Rectangle(MarginsRectangle);
            }
            else
            {
                Marshal.FreeHGlobal(RectangleStructurePointer);
                return null;
            }
        }

        /// <summary>
        /// Recupera l'immagine associata al pulsante come bitmap.
        /// </summary>
        /// <returns>L'immagine associata, nullo se non è stato possibile recuperare l'informazione.</returns>
        private Bitmap? GetImage()
        {
            WPARAM ImageType = new((int)ButtonImageType.Bitmap);
            LRESULT Result = SendMessage(Handle, BM_GETIMAGE, ImageType, IntPtr.Zero);
            if (Result != IntPtr.Zero)
            {
                return Image.FromHbitmap(Result);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Recupera l'immagine associata al pulsante come icona.
        /// </summary>
        /// <returns>L'immagine associata come icona, nullo se non è stato possibile recuperare l'informazione.</returns>
        private Icon? GetIcon()
        {
            WPARAM ImageType = new((int)ButtonImageType.Icon);
            LRESULT Result = SendMessage(Handle, BM_GETIMAGE, ImageType, IntPtr.Zero);
            if (Result != IntPtr.Zero)
            {
                return Icon.FromHandle(Result);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Recupera gli stili del pulsante.
        /// </summary>
        /// <param name="Styles">Valore composito che indica gli stili applicati al pulsante.</param>
        /// <returns>Un array che contiene tutti gli stili applicati al pulsante.</returns>
        private static ButtonStyles[] GetButtonStyles(ButtonStyles Styles)
        {
            List<ButtonStyles> StylesList = new();
            foreach (ButtonStyles style in Enum.GetValues(typeof(ButtonStyles)))
            {
                if (Styles.HasFlag(style))
                {
                    StylesList.Add(style);
                }
            }
            return StylesList.ToArray();
        }
    }
}