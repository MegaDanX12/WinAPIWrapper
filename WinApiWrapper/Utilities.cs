using Microsoft.VisualBasic;
using System.Collections;
using System.Text;
using Windows.Globalization;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;

namespace WinApiWrapper
{
    /// <summary>
    /// Metodi di utilità.
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Controlla se il valore fornito indicante gli stili di una finestra è valido.
        /// </summary>
        /// <param name="Styles">Valore da controllare.</param>
        /// <returns>true se il valore è valido, false altrimenti.</returns>
        internal static bool ValidateWindowStylesValue(WindowStyle Styles)
        {
            if (Styles.HasFlag(WindowStyle.WS_CHILD) && Styles.HasFlag(WindowStyle.WS_POPUP))
            {
                return false;
            }
            if (Styles.HasFlag(WindowStyle.WS_MAXIMIZEBOX) && !Styles.HasFlag(WindowStyle.WS_SYSMENU))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Interpreta una multi stringa e la restituisce come array di stringhe.
        /// </summary>
        /// <param name="Buffer">Puntatore all'inizio della multi stringa.</param>
        /// <returns>Un'array di stringa che contiene le diverse stringhe presenti nella multi stringa.</returns>
        internal static string[] MultiStringToArray(IntPtr Buffer)
        {
            List<string> Strings = new();
            StringBuilder String = new();
            char Character;
            bool End = false;
            do
            {
                Character = (char)Marshal.ReadInt16(Buffer);
                if (Character is not '\0')
                {
                    String.Append(Character);
                    Buffer += 2;
                }
                else
                {
                    if (String.Length is 0)
                    {
                        End = true;
                    }
                    else
                    {
                        Strings.Add(String.ToString());
                        Buffer += 2;
                        String.Clear();
                    }
                }
            }
            while (!End);
            return Strings.ToArray();
        }

        /// <summary>
        /// Legge una stringa dalla memoria non gestita.
        /// </summary>
        /// <param name="Buffer">Puntatore all'inizio della stringa.</param>
        /// <returns>La stringa letta.</returns>
        internal static string ReadString(ref IntPtr Buffer)
        {
            StringBuilder StringValue = new();
            char Character;
            do
            {
                Character = (char)Marshal.ReadInt16(Buffer);
                if (Character is not '\0')
                {
                    StringValue.Append(Character);
                    Buffer += 2;
                }
                else
                {
                    Buffer += 2;
                }
            }
            while (Character is not '\0');
            return StringValue.ToString();
        }
    }
}