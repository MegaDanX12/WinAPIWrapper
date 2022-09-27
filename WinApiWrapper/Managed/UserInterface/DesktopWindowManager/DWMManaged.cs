using System.ComponentModel;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Controls.WindowsControlsStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMFunctions;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Windows.WindowsFunctions;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMEnumerations;
using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.Managed.UserInterface.DesktopWindowManager.Enumerations;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMConstants;
using WinApiWrapper.GraphicsAndMultimedia.GraphicsDeviceInterface;
using WinApiWrapper.Managed.General;
using WinApiWrapper.Managed.UserInputAndMessaging.WindowsAndMessages.Windows;

namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Permette la comunicazione con Desktop Window Manager (DWM).
    /// </summary>
    public static class DWMManaged
    {
        /// <summary>
        /// Notifica DWM di partecipare alla programmazione del servizio Multimedia Class Schedule (MMCSS).
        /// </summary>
        public static void EnableMMCSSSchedulingForDWM()
        {
            HRESULT OperationResult = DwmEnableMMCSS(true);
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
        /// Notifica DWM di annullare la partecipazioe alla programmazione del servizio Multimedia Class Schedule (MMCSS).
        /// </summary>
        public static void DisableMMCSSSchedulingForDWM()
        {
            HRESULT OperationResult = DwmEnableMMCSS(false);
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
        /// Estende la cornice di una finestra nella sua area client.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con informazioni sulla finestra.</param>
        /// <param name="WidthLeft">Larghezza del margine sinistro.</param>
        /// <param name="WidthRight">Larghezza del margine destro.</param>
        /// <param name="HeightTop">Altezza del margine superiore.</param>
        /// <param name="HeightBottom">Altezza del margine inferiore.</param>
        /// <remarks>Usare margini negativi per creare l'effetto "lastra di vetro" dove l'area client viene renderizzata come una superficie solida senza margine.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ExtendFrameIntoClientArea(WindowInfo WindowInfo, int WidthLeft, int WidthRight, int HeightTop, int HeightBottom)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null");
            }
            MARGINS Margins = new()
            {
                LeftBorderWidth = WidthLeft,
                RightBorderWidth = WidthRight,
                TopBorderHeight = HeightTop,
                BottomBorderHeight = HeightBottom
            };
            HRESULT OperationResult = DwmExtendFrameIntoClientArea(WindowInfo.Handle, ref Margins);
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
        /// Blocca il processo fino al termine dell'aggiornamento delle superfici DirectX sono disegnati a schermo.
        /// </summary>
        public static void WaitUntilNextPresent()
        {
            HRESULT OperationResult = DwmFlush();
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
        /// Recupera informazioni sulla colorizzazione usata da DWM.
        /// </summary>
        /// <returns>Istanza di <see cref="DWMColorizationInfo"/> con le informazioni.</returns>
        public static DWMColorizationInfo GetDWMColorizationInfo()
        {
            HRESULT OperationResult = DwmGetColorizationColor(out DWORD Colorization, out BOOL OpaqueBlend);
            if (OperationResult == S_OK)
            {
                return new DWMColorizationInfo(Colorization, OpaqueBlend);
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

        /// <summary>
        /// Recupera le tempistiche della composizione DWM.
        /// </summary>
        /// <returns>Istanza di <see cref="DWMCompositionTimingInfo"/> con i dati.</returns>
        public static DWMCompositionTimingInfo GetDWMTimings()
        {
            return new DWMCompositionTimingInfo();
        }

        /// <summary>
        /// Recupera gli attributi di trasporto DWM.
        /// </summary>
        /// <returns>Istanza di <see cref="DWMTransportAttributes"/> con i dati.</returns>
        public static DWMTransportAttributes GetTransportAttributes()
        {
            HRESULT OperationResult = DwmGetTransportAttributes(out BOOL IsRemoting, out BOOL IsConnected, out DWORD Generation);
            if (OperationResult == S_OK)
            {
                return new(IsRemoting, IsConnected, Generation);
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

        /// <summary>
        /// Recupera i dati sugli attributi DWM applicati a una finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <returns>Istanza di <see cref="DWMWindowAttributes"/> con le informazioni.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="AccessViolationException"></exception>
        public static DWMWindowAttributes GetDWMWindowAttributes(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                return new(WindowInfo);
            }
        }
        #region DWM Attributes Get Methods
        /// <summary>
        /// Determina se il rendering dell'area non client per una finestra è attivo.
        /// </summary>
        /// <param name="WindowInfo">Handle alla finestra.</param>
        /// <returns>true se il rendering è abilitato, false altrimenti.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsNonClientAreaRenderingEnabled(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                uint Size = 4;
                HMODULE AttributeValuePointer = Marshal.AllocHGlobal((int)Size);
                HRESULT OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    bool AttributeValue = Convert.ToBoolean(Marshal.ReadInt32(AttributeValuePointer));
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    return AttributeValue;
                }
                else
                {
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Recupera i limiti del pulsante della barra del titolo nello spazio relativo alla finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <returns>Istanza di <see cref="Rectangle"/> che rappresenta il limite.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Rectangle GetCaptionButtonBounds(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                uint Size = (uint)Marshal.SizeOf(typeof(RECT));
                HMODULE AttributeValuePointer = Marshal.AllocHGlobal((int)Size);
                HRESULT OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_CAPTION_BUTTON_BOUNDS, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    RECT CaptionButtonBounds = (RECT)Marshal.PtrToStructure(AttributeValuePointer, typeof(RECT))!;
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    return new(CaptionButtonBounds);
                }
                else
                {
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Recupera i bordi della cornice estesa nello spazio dello schermo.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <returns>Istanza di <see cref="Rectangle"/> che rappresenta i bordi della cornice.</returns>
        public static Rectangle GetExtendedFrameBounds(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                uint Size = (uint)Marshal.SizeOf(typeof(RECT));
                HMODULE AttributeValuePointer = Marshal.AllocHGlobal((int)Size);
                HRESULT OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    RECT CaptionButtonBounds = (RECT)Marshal.PtrToStructure(AttributeValuePointer, typeof(RECT))!;
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    return new(CaptionButtonBounds);
                }
                else
                {
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message);
                    ex.HResult = OperationResult;
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Recupera il motivo per cui la finestra non è visibile.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <returns>Un valore dell'enumerazione <see cref="WindowCloakedReason"/> che indica la motivazione.</returns>
        public static WindowCloakedReason GetWindowCloakedReason(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                uint Size = (uint)Marshal.SizeOf(4);
                HMODULE AttributeValuePointer = Marshal.AllocHGlobal((int)Size);
                HRESULT OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_CLOAKED, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    WindowCloakedReason Reason = (WindowCloakedReason)Marshal.ReadInt32(AttributeValuePointer);
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    return Reason;
                }
                else
                {
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Recupera la larghezza del bordo esterno che DWM disegna attorno alla finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <returns>La larghezza del bordo esterno.</returns>
        public static int GetOuterBorderWidth(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                uint Size = (uint)Marshal.SizeOf(4);
                HMODULE AttributeValuePointer = Marshal.AllocHGlobal((int)Size);
                HRESULT OperationResult = DwmGetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_VISIBLE_FRAME_BORDER_THICKNESS, AttributeValuePointer, Size);
                if (OperationResult == S_OK)
                {
                    int OuterBorderWidth = Marshal.ReadInt32(AttributeValuePointer);
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    return OuterBorderWidth;
                }
                else
                {
                    Marshal.FreeHGlobal(AttributeValuePointer);
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message);
                    ex.HResult = OperationResult;
                    throw ex;
                }
            }
        }
        #endregion
        #region DWM Attributes Set Methods
        /// <summary>
        /// Imposta la politica di rendering dell'area non client di DWM.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Policy">Valore dell'enumerazione <see cref="NonClientAreaRenderingPolicy"/> che indica la politica.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetDWMNonClientRenderingPolicy(WindowInfo WindowInfo, NonClientAreaRenderingPolicy Policy)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle NCRenderingPolicyValue = GCHandle.Alloc(Policy, GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, NCRenderingPolicyValue.AddrOfPinnedObject(), 4);
                NCRenderingPolicyValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Attiva o disattiva le transizioni DWM.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Enable">Indica se attivare o disattivare le transizioni.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetDWMTransitions(WindowInfo WindowInfo, bool Enable)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle DWMTransitionsStatusValue = GCHandle.Alloc(Convert.ToInt32(!Enable), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_TRANSITIONS_FORCEDISABLED, DWMTransitionsStatusValue.AddrOfPinnedObject(), 4);
                DWMTransitionsStatusValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Indica a DWM se il contenuto renderizzato nell'area non client deve essere visibile sulla cornice.
        /// </summary>
        /// <param name="WindowInfo">istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Allow">Indica se permettere la visualizzazione del contenuto o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetNonClientAreaPaintAllowed(WindowInfo WindowInfo, bool Allow)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle NonClientAreaPaintAllowedValue = GCHandle.Alloc(Convert.ToInt32(Allow), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_ALLOW_NCPAINT, NonClientAreaPaintAllowedValue.AddrOfPinnedObject(), 4);
                NonClientAreaPaintAllowedValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta se il contenuto non-client ha un layout RTL (right-to-left).
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con informazioni sulla finestra.</param>
        /// <param name="Enable">Indica se il contenuto deve avere un layout RTL o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetNonClientRTLLayout(WindowInfo WindowInfo, bool Enable)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle NonClientRTLLayoutValue = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_NONCLIENT_RTL_LAYOUT, NonClientRTLLayoutValue.AddrOfPinnedObject(), 4);
                NonClientRTLLayoutValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta se la finestra deve sempre fornire un bitmap statico come anteprima.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Force">Indica se forzare la finestra a fornire un bitmap statico o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetForceWindowIconicRepresentation(WindowInfo WindowInfo, bool Force)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle ForceWindowIconicRepresentationValue = GCHandle.Alloc(Convert.ToInt32(Force), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_FORCE_ICONIC_REPRESENTATION, ForceWindowIconicRepresentationValue.AddrOfPinnedObject(), 4);
                ForceWindowIconicRepresentationValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta la politica Flip3D per una finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Policy">Valore dell'enumerazione <see cref="Flip3DWindowPolicy"/> che indica la politica Flip3D.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetFlip3DWindowPolicy(WindowInfo WindowInfo, Flip3DWindowPolicy Policy)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle Flip3DWindowPolicy = GCHandle.Alloc(Policy, GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_FLIP3D_POLICY, Flip3DWindowPolicy.AddrOfPinnedObject(), 4);
                Flip3DWindowPolicy.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Indica a DWM che la finestra fornirà una miniatura statica come propria rappresentazione.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Enable">Indica se la finestra fornirà una miniatura statica o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetWindowToProvideIconicBitmap(WindowInfo WindowInfo, bool Enable)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle ProvideIconicBitmapValue = GCHandle.Alloc(Convert.ToInt32(Enable), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_HAS_ICONIC_BITMAP, ProvideIconicBitmapValue.AddrOfPinnedObject(), 4);
                ProvideIconicBitmapValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta se la verrà visualizza l'anteprima della finestra quado Peek viene utilizzato.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Allow">Indica se l'anteprima verrà visualizzata o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetPeekAllowed(WindowInfo WindowInfo, bool Allow)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle PeekAllowedValue = GCHandle.Alloc(Convert.ToInt32(!Allow), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_DISALLOW_PEEK, PeekAllowedValue.AddrOfPinnedObject(), 4);
                PeekAllowedValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta se la finestra non deve trasformarsi in una lastra di vetro mentre Peek è attivo.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Excluded">Indica se la finestra deve rimanere normale durante Peek o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetWindowExcludedFromPeek(WindowInfo WindowInfo, bool Excluded)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle ExcludedFromPeekValue = GCHandle.Alloc(Convert.ToInt32(Excluded), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_EXCLUDED_FROM_PEEK, ExcludedFromPeekValue.AddrOfPinnedObject(), 4);
                ExcludedFromPeekValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Nasconde la finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void CloakWindow(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_CLOAK, HMODULE.Zero, 0);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Blocca la miniatura della finestra nell'attuale aspetto.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void FreezeWindowRepresentation(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_FREEZE_REPRESENTATION, HMODULE.Zero, 0);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta se la finestra di un'applicazione non-UWP può usare i pennelli di sfondi dell'host.
        /// </summary>
        /// <param name="WindowInfo">Handle alla finestra.</param>
        /// <param name="Use">Indica se usare i pennelli o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetHostBackdropBrushUsage(WindowInfo WindowInfo, bool Use)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle HostBackdropBrushUsageValue = GCHandle.Alloc(Convert.ToInt32(Use), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_USE_HOSTBACKDROPBRUSH, HostBackdropBrushUsageValue.AddrOfPinnedObject(), 4);
                HostBackdropBrushUsageValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta se la cornice della finestra deve essere disegnata in modalità scura quando attiva.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="Use">Indica se la cornice userà la modalità scura o meno.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetImmersiveDarkModeUsage(WindowInfo WindowInfo, bool Use)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle HostBackdropBrushUsageValue = GCHandle.Alloc(Convert.ToInt32(Use), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, HostBackdropBrushUsageValue.AddrOfPinnedObject(), 4);
                HostBackdropBrushUsageValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta la preferenza relativa agli angoli arrotondati della finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="CornerPreference">Preferenza della finestra.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetWindowCornerPreference(WindowInfo WindowInfo, WindowCornerPreference CornerPreference)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle WindowCornerPreferenceValue = GCHandle.Alloc(CornerPreference, GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE, WindowCornerPreferenceValue.AddrOfPinnedObject(), 4);
                WindowCornerPreferenceValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta il colore del bordo della finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="BorderColor">Colore.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetWindowBorderColor(WindowInfo WindowInfo, System.Drawing.Color BorderColor)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle BorderColorUsageValue = GCHandle.Alloc(System.Drawing.ColorTranslator.ToWin32(BorderColor), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_BORDER_COLOR, BorderColorUsageValue.AddrOfPinnedObject(), 4);
                BorderColorUsageValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta il colore della barra del titolo della finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="CaptionColor">Colore.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetWindowCaptionColor(WindowInfo WindowInfo, System.Drawing.Color CaptionColor)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle CaptionColorUsageValue = GCHandle.Alloc(System.Drawing.ColorTranslator.ToWin32(CaptionColor), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_CAPTION_COLOR, CaptionColorUsageValue.AddrOfPinnedObject(), 4);
                CaptionColorUsageValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Imposta il colore del testo della barra del titolo della finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="TextColor">Colore.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetWindowTextColor(WindowInfo WindowInfo, System.Drawing.Color TextColor)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                GCHandle TextColorUsageValue = GCHandle.Alloc(System.Drawing.ColorTranslator.ToWin32(TextColor), GCHandleType.Pinned);
                HRESULT OperationResult = DwmSetWindowAttribute(WindowInfo.Handle, DWMWINDOWATTRIBUTE.DWMWA_TEXT_COLOR, TextColorUsageValue.AddrOfPinnedObject(), 4);
                TextColorUsageValue.Free();
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }
        #endregion
        /// <summary>
        /// Notifica a DWM che tutti i bitmap precedentemente forniti non sono più validi e devono essere aggiornati.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void UpdateIconicBitmaps(WindowInfo WindowInfo)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                HRESULT OperationResult = DwmInvalidateIconicBitmaps(WindowInfo.Handle);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Indica a DWM di visualizzare la miniatura di una finestra in una specifica regione di un'altra finestra.
        /// </summary>
        /// <param name="DestinationWindow">Istanza di <see cref="WindowInfo"/> con rappresenta la finestra dove visualizzare la miniatura.</param>
        /// <param name="SourceWindow">Istanza di <see cref="WindowInfo"/> che rappresenta la finestra fonte della miniatura.</param>
        /// <param name="Properties">Proprietà della miniatura.</param>
        /// <remarks>Le istanze di <see cref="WindowInfo"/> devono riferirsi a finestre top-level o al desktop.<br/>
        /// Se <paramref name="DestinationWindow"/> non si riferisce al desktop, la finestra a cui si riferisce deve appartenere al processo.<br/><br/>
        /// Solo il campo <see cref="ThumbnailRelationshipProperties.DestinationRegion"/> del parametro <paramref name="Properties"/> è obbligatorio.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void CaptureDWMThumbnailContents(WindowInfo DestinationWindow, WindowInfo SourceWindow, ThumbnailRelationshipProperties Properties)
        {
            if (DestinationWindow is null || SourceWindow is null || Properties is null)
            {
                throw new ArgumentNullException(string.Empty, "The parameters " + nameof(DestinationWindow) + ", " + nameof(SourceWindow) + "e " + nameof(Properties) + " cannot be null.");
            }
            else
            {

                HRESULT OperationResult = DwmRegisterThumbnail(DestinationWindow.Handle, SourceWindow.Handle, out HMODULE ThumbnailID);
                if (OperationResult == S_OK)
                {
                    DWM_THUMBNAIL_PROPERTIES ThumbnailProperties = Properties.ToStructure();
                    OperationResult = DwmUpdateThumbnailProperties(ThumbnailID, ref ThumbnailProperties);
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
                        Properties.ThumbnailHandle = ThumbnailID;
                    }
                }
                else if ((uint)OperationResult == E_INVALIDARG)
                {
                    throw new ArgumentException("One of the window handles does not refer to a top-level window.");
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
        }

        /// <summary>
        /// Imposta un bitmap statico come anteprima per una finestra.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="ImagePath">Percorso all'immagine da usare come bitmap statico.</param>
        /// <param name="DisplayFrame">Indica se mostrare una cornice attorno al bitmap o meno.</param>
        /// <param name="ClientAreaOffset">Offset dalla cornice dell'host della regione client della finestra.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetIconicLivePreviewBitmap(WindowInfo WindowInfo, string ImagePath, bool DisplayFrame, System.Drawing.Point? ClientAreaOffset = null)
        {
            if (WindowInfo is null || string.IsNullOrWhiteSpace(ImagePath))
            {
                throw new ArgumentNullException(string.Empty, "The parameters " + nameof(WindowInfo) + " and " + nameof(ImagePath) + " cannot be null.");
            }
            else
            {
                HMODULE BitmapHandle = GDIFunctions.LoadImage(HMODULE.Zero, ImagePath, GDIEnumerations.ImageType.IMAGE_BITMAP, 0, 0, GDIEnumerations.LoadOptions.LR_LOADFROMFILE);
                if (BitmapHandle == HMODULE.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
                DWORD Options = DisplayFrame ? DWM_SIT_DISPLAYFRAME : 0;
                HRESULT OperationResult;
                if (ClientAreaOffset is not null)
                {
                    POINT Offset = new()
                    {
                        x = ClientAreaOffset.Value.X,
                        y = ClientAreaOffset.Value.Y,
                    };
                    HMODULE PointStructurePointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(POINT)));
                    Marshal.StructureToPtr(Offset, PointStructurePointer, false);
                    OperationResult = DwmSetIconicLivePreviewBitmap(WindowInfo.Handle, BitmapHandle, PointStructurePointer, Options);
                    _ = GDIFunctions.DeleteObject(BitmapHandle);
                    if (OperationResult != S_OK)
                    {
                        Marshal.FreeHGlobal(PointStructurePointer);
                        Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                        {
                            HResult = OperationResult
                        };
                        throw ex;
                    }
                    else
                    {
                        Marshal.FreeHGlobal(PointStructurePointer);
                    }
                }
                else
                {
                    OperationResult = DwmSetIconicLivePreviewBitmap(WindowInfo.Handle, BitmapHandle, HMODULE.Zero, Options);
                    _ = GDIFunctions.DeleteObject(BitmapHandle);
                    if (OperationResult != S_OK)
                    {
                        Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                        {
                            HResult = OperationResult
                        };
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Imposta un bitmap statico come miniatura di una finestra o di una scheda.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="ImagePath">Percorso dell'immagine da usare come bitmap statico.</param>
        /// <param name="DisplayFrame">Indica se mostrare una cornice attorno al bitmap.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetIconicThumbnail(WindowInfo WindowInfo, string ImagePath, bool DisplayFrame)
        {
            if (WindowInfo is null || string.IsNullOrWhiteSpace(ImagePath))
            {
                throw new ArgumentNullException(string.Empty, "The parameters " + nameof(WindowInfo) + " and " + nameof(ImagePath) + " cannot be null.");
            }
            else
            {
                HMODULE BitmapHandle = GDIFunctions.LoadImage(HMODULE.Zero, ImagePath, GDIEnumerations.ImageType.IMAGE_BITMAP, 0, 0, GDIEnumerations.LoadOptions.LR_LOADFROMFILE);
                if (BitmapHandle == HMODULE.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastPInvokeError());
                }
                DWORD Options = DisplayFrame ? DWM_SIT_DISPLAYFRAME : 0;
                HRESULT OperationResult = DwmSetIconicThumbnail(WindowInfo.Handle, BitmapHandle, Options);
                _ = GDIFunctions.DeleteObject(BitmapHandle);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Specifica il tipo di feedback visuale da visualizzare in risposta a uno specifica contatto penna o tocco.
        /// </summary>
        /// <param name="PointerID">ID del contatto.</param>
        /// <param name="Type">Tipo di contatto.</param>
        public static void ShowContact(int PointerID, ContactType Type)
        {
            HRESULT OperationResult = DwmShowContact((uint)PointerID, (DWM_SHOWCONTACT)Type);
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
        /// Specifica la transizione delle finestre di utilità.
        /// </summary>
        /// <param name="WindowInfo">Istanza di <see cref="WindowInfo"/> con le informazioni sulla finestra.</param>
        /// <param name="TransitionType">Tipo di transizione.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Win32Exception"></exception>
        public static void SetToolWindowDWMAnimation(WindowInfo WindowInfo, ToolWindowTransition TransitionType)
        {
            if (WindowInfo is null)
            {
                throw new ArgumentNullException(nameof(WindowInfo), "The parameter cannot be null.");
            }
            else
            {
                HRESULT OperationResult = DwmTransitionOwnedWindow(WindowInfo.Handle, (DWMTRANSITION_OWNEDWINDOW_TARGET)TransitionType);
                if (OperationResult != S_OK)
                {
                    Win32Exception ex = new(Marshal.GetExceptionForHR(OperationResult)!.Message)
                    {
                        HResult = OperationResult
                    };
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Invia un messaggio a DWM.
        /// </summary>
        /// <param name="WindowHandle">Handle alla finestra che ha ricevuto il messaggio.</param>
        /// <param name="Message">Messaggio.</param>
        /// <param name="wParam">Primo parametro del messaggio.</param>
        /// <param name="lParam">Secondo parametro del messaggio.</param>
        /// <param name="Result">Risultato dell'elaborazione del messaggio.</param>
        /// <returns>true se il messaggio è stato elaborato, false altrimenti.</returns>
        public static bool SendMessageToDWM(HMODULE WindowHandle, uint Message, HMODULE wParam, HMODULE lParam, out int? Result)
        {
            HMODULE ResultPointer = Marshal.AllocHGlobal(4);
            bool Processed = DwmDefWindowProc(WindowHandle, Message, wParam, lParam, ref ResultPointer);
            if (!Processed)
            {
                Result = null;
                Marshal.FreeHGlobal(ResultPointer);
                return false;
            }
            else
            {
                Result = Marshal.ReadInt32(ResultPointer);
                Marshal.FreeHGlobal(ResultPointer);
                return true;
            }
        }
    }
}