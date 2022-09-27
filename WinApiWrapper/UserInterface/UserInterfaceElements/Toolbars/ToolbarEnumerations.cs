using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonStructures;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;

namespace WinApiWrapper.UserInterface.UserInterfaceElements.Toolbars
{
    /// <summary>
    /// Enumerazioni usate dalle toolbar.
    /// </summary>
    internal static class ToolbarEnumerations
    {
        /// <summary>
        /// Valori di ritorno per <see cref="Common.CommonNotifications.NM_CUSTOMDRAW"/>.
        /// </summary>
        internal enum CustomDrawReturnFlags
        {
            /// <summary>
            /// Non disegnare i bordi del pulsante.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_NOEDGES = 65536,
            /// <summary>
            /// Usa il campo <see cref="NMTBCUSTONDRAW.HighlightHotTrackColor"/> per disegnare lo sfondo degli oggetti tracciati.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_HILITEHOTRACK = 131072,
            /// <summary>
            /// Non spostare il pulsante quando è premuto.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_NOOFFSET = 262144,
            /// <summary>
            /// Non disegnare l'evidenziazione predefinita degli oggetti il cui stato è <see cref="ToolbarButtonState.TBSTATE_MARKED"/>.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_NOMARK = 524288,
            /// <summary>
            /// Non disegnare l'effetto inciso per gli oggetti disabilitati.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_NOETCHEFFECT = 1048576,
            /// <summary>
            /// Mimetizza il pulsante con lo sfondo per il 50%.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_BLENDICON = 2097152,
            /// <summary>
            /// Non disegnare lo sfondo dei pulsanti.
            /// </summary>
            /// <remarks>Si verifica quando <see cref="NMCUSTOMDRAW.DrawStage"/> ha valore <see cref="DrawstageFlags.CDDS_ITEMPREPAINT"/>.</remarks>
            TBCDRF_NOBACKGROUND = 4194304,
            /// <summary>
            /// Usa il colori di disegno personalizzati per renderizzare il testo senza tenere conto degli stili visuali.
            /// </summary>
            TBCDRF_USECDCOLORS = 8388608
        }
    }
}