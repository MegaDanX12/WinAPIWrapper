using System.ComponentModel;
using static WinApiWrapper.Managed.UserInterface.DesktopWindowManager.Enumerations;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMEnumerations;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMFunctions;
using static WinApiWrapper.General.GeneralStructures;
using WinApiWrapper.Managed.General;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;

namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Attributi DWM applicati a una finestra.
    /// </summary>
    public class DWMWindowAttributes
    {
        /// <summary>
        /// Indica se il rendering dell'area non client è abilitato.
        /// </summary>
        public bool NonClientRenderingEnabled { get; }

        /// <summary>
        /// Bordi dell'area del pulsante della barra del titolo nello spazio relativo alla finestra.
        /// </summary>
        /// <remarks>Questo valore non è valido se la finestra non è visibile.</remarks>
        public Rectangle CaptionButtonAreaBounds { get; }

        /// <summary>
        /// Bordi della cornice estesa nello spazio dello schermo.
        /// </summary>
        public Rectangle ExtendedFrameBounds { get; }

        /// <summary>
        /// Motivo per cui la finestra è nascosta.
        /// </summary>
        public WindowCloakedReason CloakReason { get; }

        /// <summary>
        /// Larghezza del bordo esterno disegnato da DWM attorno alla finestra.
        /// </summary>
        public int OuterBorderWidth { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DWMWindowAttributes"/>.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> che si riferisce alla finestra di cui recuperare gli attributi.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="AccessViolationException"></exception>
        internal DWMWindowAttributes(WindowInfo WindowInfo)
        {
            HMODULE AttributeValuePointer = HMODULE.Zero;
            try
            {
                uint Size = 4;
                AttributeValuePointer = Marshal.AllocHGlobal((int)Size);
                HRESULT OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    NonClientRenderingEnabled = Convert.ToBoolean(Marshal.ReadInt32(AttributeValuePointer));
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                Size = (uint)Marshal.SizeOf(typeof(RECT));
                AttributeValuePointer = Marshal.ReAllocHGlobal(AttributeValuePointer, (HMODULE)Size);
                OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_CAPTION_BUTTON_BOUNDS, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    RECT CaptionButtonBounds = (RECT)Marshal.PtrToStructure(AttributeValuePointer, typeof(RECT))!;
                    CaptionButtonAreaBounds = new(CaptionButtonBounds);
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                AttributeValuePointer = Marshal.ReAllocHGlobal(AttributeValuePointer, (HMODULE)Size);
                OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    RECT ExtendedFrameBounds = (RECT)Marshal.PtrToStructure(AttributeValuePointer, typeof(RECT))!;
                    this.ExtendedFrameBounds = new(ExtendedFrameBounds);
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                Size = 4;
                AttributeValuePointer = Marshal.ReAllocHGlobal(AttributeValuePointer, (HMODULE)Size);
                OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_CLOAKED, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    CloakReason = (WindowCloakedReason)Marshal.ReadInt32(AttributeValuePointer);
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
                AttributeValuePointer = Marshal.ReAllocHGlobal(AttributeValuePointer, (HMODULE)Size);
                OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_VISIBLE_FRAME_BORDER_THICKNESS, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    OuterBorderWidth = Marshal.ReadInt32(AttributeValuePointer);
                }
                else
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
            finally
            {
                if (AttributeValuePointer != HMODULE.Zero)
                {
                    Marshal.FreeHGlobal(AttributeValuePointer);
                }
            }
        }
    }
}