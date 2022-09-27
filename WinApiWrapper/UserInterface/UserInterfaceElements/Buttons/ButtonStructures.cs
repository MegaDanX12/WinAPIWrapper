using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonEnumerations;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Buttons.ButtonConstants;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Buttons
{
    /// <summary>
    /// Strutture usate dai pulsanti.
    /// </summary>
    internal static class ButtonStructures
    {
        /// <summary>
        /// Informazioni su una lista immagini usata con un pulsante.
        /// </summary>
        internal struct BUTTON_IMAGELIST
        {
            /// <summary>
            /// Handle alla lista.
            /// </summary>
            /// <remarks>Potrebbe avere il valore <see cref="BCCL_NOGLYPH"/>.</remarks>
            public HIMAGELIST ImageListHandle;
            /// <summary>
            /// Margini attorno all'icona.
            /// </summary>
            public RECT Margins;
            /// <summary>
            /// Allineamento della lista.
            /// </summary>
            public ImagelistAlignment Alignment;
        }

        /// <summary>
        /// Informazioni su uno split button.
        /// </summary>
        internal struct BUTTON_SPLITINFO
        {
            /// <summary>
            /// Indica quali membri della struttura sono validi.
            /// </summary>
            public SplitButtonInfoValidMembers ValidMembers;
            /// <summary>
            /// Handle alla lista immagini.
            /// </summary>
            public HIMAGELIST GlyphHandle;
            /// <summary>
            /// Stili dello split button.
            /// </summary>
            public SplitButtonStyle SplitButtonStyle;
            /// <summary>
            /// Struttura <see cref="SIZE"/> che specifica la dimensione del glifo indicato da <see cref="GlyphHandle"/>.
            /// </summary>
            public SIZE GlyphSize;
        }

        /// <summary>
        /// Informazioni su una notifica <see cref="ButtonNotifications.BCN_DROPDOWN"/>.
        /// </summary>
        internal struct NMBCDROPDOWN
        {
            /// <summary>
            /// Struttura <see cref="NMHDR"/> con informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationData;
            /// <summary>
            /// Area client del pulsante.
            /// </summary>
            public RECT ButtonClientArea;
        }

        /// <summary>
        /// Informazioni sul movimento del mouse sopra un pulsante.
        /// </summary>
        internal struct NMBCHOTITEM
        {
            /// <summary>
            /// Informazioni sulla notifica.
            /// </summary>
            public NMHDR NotificationData;
            /// <summary>
            /// Azione del mouse.
            /// </summary>
            public MouseAction Flags;
        }
    }
}