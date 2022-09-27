using System.Text;
using WinApiWrapper.Managed.General;
using WinApiWrapper.Managed.UserInterface.HighDPI;
using WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Controls;
using WinApiWrapper.UserInterface.HighDPI;
using static WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows.Enumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowsFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowStructures;

namespace WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows
{
    /// <summary>
    /// Informazioni su una finestra.
    /// </summary>
    public class WindowInfo
    {
        /// <summary>
        /// Handle alla finestra.
        /// </summary>
        internal HWND Handle;

        /// <summary>
        /// Handle al tema attivo che contiene gli stili visuali della finestra.
        /// </summary>
        internal HTHEME AssociatedTheme;

        /// <summary>
        /// ID della finestra.
        /// </summary>
        public int? ID { get; }

        /// <summary>
        /// Indica se la finestra è stata associata con il tema attivo.
        /// </summary>
        public bool AssociatedWithActiveTheme
        {
            get
            {
                return AssociatedTheme != IntPtr.Zero;
            }
        }

        /// <summary>
        /// Coordinate della finestra.
        /// </summary>
        public Rectangle? WindowCoordinates { get; }

        /// <summary>
        /// Coordinate dell'area client.
        /// </summary>
        public Rectangle? ClientAreaCoordinates { get; }

        /// <summary>
        /// Stili della finestra.
        /// </summary>
        public WindowStyles[]? Styles { get; }

        /// <summary>
        /// Stili estesi della finestra.
        /// </summary>
        public ExtendedWindowStyles[]? ExtendedStyles { get; }

        /// <summary>
        /// Indica se la finestra è attiva.
        /// </summary>
        public bool? IsActive { get; }

        /// <summary>
        /// Larghezza del bordo della finestra, in pixel.
        /// </summary>
        public int? BorderWidth { get; }

        /// <summary>
        /// Altezza del bordo della finestra, in pixel.
        /// </summary>
        public int? BorderHeight { get; }

        /// <summary>
        /// ATOM (identificativo univoco) che identifica la classe della finestra.
        /// </summary>
        public short? ClassAtom { get; }

        /// <summary>
        /// Nome della classe.
        /// </summary>
        public string? ClassName { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="WindowInfo"/>.
        /// </summary>
        /// <param name="Handle">Handle alla finestra.</param>
        internal WindowInfo(HWND Handle)
        {
            if (!IsWindow(Handle))
            {
                throw new ArgumentException("Invalid window.", nameof(Handle));
            }
            else
            {
                this.Handle = Handle;
                LONG_PTR WindowID = GetWindowLongPtr(Handle, (int)WindowDataSpecialOffset.GWL_ID);
                ID = WindowID != LONG_PTR.Zero ? WindowID.ToInt32() : null;
                WINDOWINFO Info = new()
                {
                    Size = (uint)Marshal.SizeOf(typeof(WINDOWINFO))
                };
                if (GetWindowInfo(Handle, ref Info))
                {
                    WindowCoordinates = new(Info.WindowCoordinate);
                    ClientAreaCoordinates = new(Info.ClientAreaCoordinates);
                    Styles = GetWindowStyles(Info.Styles);
                    ExtendedStyles = GetExtendedWindowStyles(Info.ExtendedStyles);
                    IsActive = Info.Status;
                    BorderWidth = (int)Info.BorderWidth;
                    BorderHeight = (int)Info.BorderHeigth;
                    ClassAtom = (short)Info.ClassAtom;
                }
                StringBuilder ClassNameBuilder = new(256);
                if (GetClassName(Handle, ClassNameBuilder, ClassNameBuilder.Capacity) is not 0)
                {
                    ClassName = ClassNameBuilder.ToString();
                }
            }
        }

        /// <summary>
        /// Recupera gli stili della finestra.
        /// </summary>
        /// <param name="Styles">Valore composito che indica gli stili attivi della finestra.</param>
        /// <returns>Un array che contiene tutti gli stili.</returns>
        private static WindowStyles[] GetWindowStyles(WindowStyle Styles)
        {
            List<WindowStyles> StylesList = new();
            foreach (WindowStyle style in Enum.GetValues(typeof(WindowStyle)))
            {
                if (Styles.HasFlag(style))
                {
                    StylesList.Add((WindowStyles)style);
                }
            }
            return StylesList.ToArray();
        }

        /// <summary>
        /// Recupera gli stili estesi della finestra.
        /// </summary>
        /// <param name="ExtendedStyles">Valore composito che indica gli stili estesi della finestra.</param>
        /// <returns>Un array che contiene tutti gli stili estesi.</returns>
        private static ExtendedWindowStyles[] GetExtendedWindowStyles(WindowExtendedStyle ExtendedStyles)
        {
            List<ExtendedWindowStyles> StylesList = new();
            foreach (WindowExtendedStyle style in Enum.GetValues(typeof(WindowExtendedStyle)))
            {
                if (ExtendedStyles.HasFlag(style))
                {
                    StylesList.Add((ExtendedWindowStyles)style);
                }
            }
            return StylesList.ToArray();
        }

        /// <summary>
        /// Recupera i dati del tema attivo e li associa con la finestra.
        /// </summary>
        /// <param name="DPI">Valore DPI al quale associare i dati del tema.</param>
        /// <param name="Classes">Lista di classi con cui associare i dati del tema.</param>
        /// <returns>true se i dati del tema sono stati recuperati, false altrimenti.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool GetActiveThemeDataForWindow(int DPI = -1, string[]? Classes = null)
        {
            if (DPI is -1)
            {
                if (Classes is null || Classes.Length is 0)
                {
                    if (ClassName is not null)
                    {
                        AssociatedTheme = WindowsControlsFunctions.OpenThemeData(Handle, ClassName);
                    }
                    else
                    {
                        throw new InvalidOperationException("The class name of the window is unavailable.");
                    }
                }
                else
                {
                    if (Classes.Length is 1)
                    {
                        AssociatedTheme = WindowsControlsFunctions.OpenThemeData(Handle, Classes[0]);
                    }
                    else
                    {
                        StringBuilder ClassesListBuilder = new();
                        for (int i = 0; i < Classes.Length; i++)
                        {
                            ClassesListBuilder.Append(Classes[i]);
                            if (i != Classes.Length - 1)
                            {
                                ClassesListBuilder.Append(';');
                            }
                        }
                        AssociatedTheme = WindowsControlsFunctions.OpenThemeData(Handle, ClassesListBuilder.ToString());
                    }
                }
            }
            else
            {
                if (DPI is 0)
                {
                    DPI = HighDPIManaged.GetThreadDPI();
                    if (DPI is 0)
                    {
                        throw new ArgumentException("Unable to retrieve DPI value for the current thread.", nameof(DPI));
                    }
                }
                if (Classes is null || Classes.Length is 0)
                {
                    if (ClassName is not null)
                    {
                        AssociatedTheme = HighDPIFunctions.OpenThemeDataForDpi(Handle, ClassName, (uint)DPI);
                    }
                    else
                    {
                        throw new InvalidOperationException("The class name of the window is unavailable.");
                    }
                }
                else
                {
                    if (Classes.Length is 1)
                    {
                        AssociatedTheme = HighDPIFunctions.OpenThemeDataForDpi(Handle, Classes[0], (uint)DPI);
                    }
                    else
                    {
                        StringBuilder ClassesListBuilder = new();
                        for (int i = 0; i < Classes.Length; i++)
                        {
                            ClassesListBuilder.Append(Classes[i]);
                            if (i != Classes.Length - 1)
                            {
                                ClassesListBuilder.Append(';');
                            }
                        }
                        AssociatedTheme = HighDPIFunctions.OpenThemeDataForDpi(Handle, ClassesListBuilder.ToString(), (uint)DPI);
                    }
                }
            }
            return AssociatedTheme != IntPtr.Zero;
        }
    }
}