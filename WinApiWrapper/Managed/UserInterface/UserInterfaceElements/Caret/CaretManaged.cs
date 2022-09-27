using System.ComponentModel;
using System.Drawing;
using static WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface.GDIFunctions;
using static WinApiWrapper.General.GeneralStructures;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;
using WinApiWrapper.UserInterface.UserInterfaceElements.Caret;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.Caret
{
    /// <summary>
    /// Metodi per l'interazioni con i cursori di inserimento.
    /// </summary>
    public static class CaretManaged
    {
        /// <summary>
        /// Crea un cursore di inserimento testo e ne rende la finestra indicata la proprietaria.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra proprietaria del cursore.</param>
        /// <param name="CaretShape">Forma del cursore.</param>
        /// <param name="Width">Larghezza, in unità logiche, del cursore.</param>
        /// <param name="Height">Altezza, in unità logiche, del cursore.></param>
        /// <param name="IsCaretGray">Indica se il cursore deve essere grigio.</param>
        /// <param name="MakeCaretVisible">Indica se rendere visibile il cursore di inserimento.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks><paramref name="CaretShape"/> può essere nullo, in tal caso <paramref name="Width"/> e <paramref name="Height"/> devono avere valori validi.<br/><br/>
        /// Se <paramref name="CaretShape"/> non è nullo, <paramref name="Width"/>, <paramref name="Height"/> e <paramref name="IsCaretGray"/> vengono ignorati.<br/><br/>
        /// Se <paramref name="MakeCaretVisible"/> è false, il cursore non sarà visibile.</remarks>
        public static void CreateCaret(WindowInfo WindowInfo, Bitmap? CaretShape, int? Width, int? Height, bool IsCaretGray, bool MakeCaretVisible)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            if (CaretShape is null)
            {
                if (Width.HasValue && Width < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Width), "The parameter cannot have a value below 0.");
                }
                if (Height.HasValue && Height < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Height), "The parameter cannot have a value below 0.");
                }
            }
            if (CaretShape is not null)
            {
                HBITMAP BitmapHandle = CaretShape.GetHbitmap();
                bool Result = CaretFunctions.CreateCaret(WindowInfo.Handle, BitmapHandle, 0, 0);
                _ = DeleteObject(BitmapHandle);
                if (!Result)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            else
            {
                HBITMAP BitmapHandle = IsCaretGray ? (new(1)) : HMODULE.Zero;
                if (!CaretFunctions.CreateCaret(WindowInfo.Handle, BitmapHandle, Width!.Value, Height!.Value))
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
            }
            if (MakeCaretVisible)
            {
                ShowCaret(WindowInfo);
            }
        }

        /// <summary>
        /// Elimina un cursore di inserimento e lo rimuove dallo schermo.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public static void DestroyCaret()
        {
            if (!CaretFunctions.DestroyCaret())
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Recupera il tempo di lampeggiamento del cursore di inserimento.
        /// </summary>
        /// <returns>Il tempo di lampeggiamento in millisecondi.</returns>
        public static int GetCaretBlinkTime()
        {
            uint BlinkTime = CaretFunctions.GetCaretBlinkTime();
            return BlinkTime is not 0 ? (int)BlinkTime : throw new Win32Exception(Marshal.GetLastPInvokeError());
        }

        /// <summary>
        /// Recupera la posizione del cursore di inserimento.
        /// </summary>
        /// <returns>Struttura <see cref="Point"/> con le coordinate del cursore.</returns>
        /// <exception cref="Win32Exception"></exception>
        public static Point GetCaretPosition()
        {
            if (CaretFunctions.GetCaretPosition(out POINT Coordinates))
            {
                return new(Coordinates.x, Coordinates.y);
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Nasconde il cursore di inserimento.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> associata alla finestra proprietaria. del cursore.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void HideCaret(WindowInfo? WindowInfo)
        {
            HWND WindowHandle = WindowInfo is not null ? WindowInfo.Handle : HMODULE.Zero;
            if (!CaretFunctions.HideCaret(WindowHandle))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta il tempo di lampeggiamento del cursore di inserimento.
        /// </summary>
        /// <param name="Milliseconds">Nuovo tempo di lampeggiamento.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <remarks>-1 disabilita il lampeggiamento.</remarks>
        public static void SetCaretBlinkTime(int Milliseconds)
        {
            if (!CaretFunctions.SetCaretBlinkTime((uint)Milliseconds))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Imposta la posizione del cursore di inserimento.
        /// </summary>
        /// <param name="NewPosition">Struttura <see cref="Point"/> che contiene la nuova posizione del cursore.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void SetCaretPosition(Point NewPosition)
        {
            if (!CaretFunctions.SetCaretPosition(NewPosition.X, NewPosition.Y))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Visualizza a schermo il cursore di inserimento testo.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> associata con la finestra proprietaria del cursore.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void ShowCaret(WindowInfo? WindowInfo)
        {
            HWND WindowHandle = WindowInfo is not null ? WindowInfo.Handle : HMODULE.Zero;
            if (!CaretFunctions.ShowCaret(WindowHandle))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }
    }
}