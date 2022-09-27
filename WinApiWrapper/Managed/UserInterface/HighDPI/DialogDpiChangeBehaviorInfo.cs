using System.Collections;
using static WinApiWrapper.UserInterface.HighDPI.HighDPIEnumerations;

namespace WinApiWrapper.Managed.UserInterface.HighDPI
{
    /// <summary>
    /// Informazioni sul comportamento delle finestre di dialogo quando il valore DPI viene modificato.
    /// </summary>
    public class DialogDpiChangeBehaviorInfo
    {
        /// <summary>
        /// Indica se il ridimensionamento della finestra di dialogo è abilitato.
        /// </summary>
        public bool IsDialogResizeEnabled { get; }

        /// <summary>
        /// Indica se il relayout dei controlli della finestra di dialogo è abilitato.
        /// </summary>
        public bool IsControlRelayoutEnabled { get; }

        /// <summary>
        /// Indica se disabilitare tutti i comportamenti.
        /// </summary>
        /// <remarks>Anche se <see cref="IsDialogResizeEnabled"/> e <see cref="IsControlRelayoutEnabled"/> i font di ogni controllo e del dialogo stesso verranno comunque aggiornati, questo campo se impostato a true indica di disattivare anche tali comportamenti.</remarks>
        public bool DisableAll { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DialogDpiChangeBehaviorInfo"/>.
        /// </summary>
        /// <param name="Behavior">Valore che indica il comportamento della finestre di dialogo.</param>
        internal DialogDpiChangeBehaviorInfo(DIALOG_DPI_CHANGE_BEHAVIORS Behavior)
        {
            if (Behavior is DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DEFAULT)
            {
                IsDialogResizeEnabled = true;
                IsControlRelayoutEnabled = true;
                DisableAll = false;
            }
            else
            {
                byte[] Bytes = BitConverter.GetBytes((int)Behavior);
                BitArray ValueBits = new(Bytes);
                if (ValueBits[0])
                {
                    IsDialogResizeEnabled = false;
                    IsControlRelayoutEnabled = false;
                    DisableAll = true;
                }
                else
                {
                    if (ValueBits[1])
                    {
                        IsDialogResizeEnabled = false;
                    }
                    else
                    {
                        IsDialogResizeEnabled = true;
                    }
                    if (ValueBits[2])
                    {
                        IsControlRelayoutEnabled = false;
                    }
                    else
                    {
                        IsControlRelayoutEnabled = true;
                    }
                    DisableAll = false;
                }
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="DialogDpiChangeBehaviorInfo"/>.
        /// </summary>
        /// <param name="DisableAll">Indica se tutti i comportamenti sono disattivati.</param>
        /// <param name="DialogResizeEnabled">Indica se il ridimensionamento del dialogo è abilitato.</param>
        /// <param name="DialogControlRelayoutEnabled">Indica se il relayout dei controlli del dialogo è abilitato.</param>
        /// <remarks>Se <paramref name="DisableAll"/> è true, gli altri parametri vengono ignorati.</remarks>
        public DialogDpiChangeBehaviorInfo(bool DisableAll, bool DialogResizeEnabled, bool DialogControlRelayoutEnabled)
        {
            if (DisableAll)
            {
                this.DisableAll = true;
                IsDialogResizeEnabled = false;
                IsControlRelayoutEnabled = false;
            }
            else
            {
                DisableAll = false;
                IsDialogResizeEnabled = DialogResizeEnabled;
                IsControlRelayoutEnabled = DialogControlRelayoutEnabled;
            }
        }

        /// <summary>
        /// Restituise un valore singolo o composto da diversi valori dell'enumerazione <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/> che indica il nuovo comportamento da applicare.
        /// </summary>
        /// <returns></returns>
        internal DIALOG_DPI_CHANGE_BEHAVIORS ToEnumValue()
        {
            if (DisableAll)
            {
                return DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DISABLE_ALL;
            }
            else
            {
                if (IsDialogResizeEnabled || IsControlRelayoutEnabled)
                {
                    return DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DEFAULT;
                }
                else
                {
                    DIALOG_DPI_CHANGE_BEHAVIORS Behavior = DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DEFAULT;
                    if (!IsDialogResizeEnabled)
                    {
                        Behavior |= DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DISABLE_RESIZE;
                    }
                    if (!IsControlRelayoutEnabled)
                    {
                        Behavior |= DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DISABLE_CONTROL_RELAYOUT;
                    }
                    return Behavior;
                }
            }
        }
    }
}