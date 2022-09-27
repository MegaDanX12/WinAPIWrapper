using WinApiWrapper.UserInterface.UserInterfaceElements.Common;
using static WinApiWrapper.UserInterface.UserInterfaceElements.Common.CommonEnumerations;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements.CommonControls
{
    /// <summary>
    /// Enumerazioni controlli comuni.
    /// </summary>
    public static class CommonControlsEnumerations
    {
        /// <summary>
        /// Opzioni di formattazione del testo.
        /// </summary>
        public enum TextFormat
        {
            /// <summary>
            /// Renderizza il testo nella parte inferiore del rettangolo di visualizzazione.
            /// </summary>
            RenderAtBottom = CommonEnumerations.TextFormat.DT_BOTTOM,
            /// <summary>
            /// Determina l'altezza e la larghezza del rettangolo di visualizzazione.
            /// </summary>
            CalculateDisplayRectangle = CommonEnumerations.TextFormat.DT_CALCRECT,
            /// <summary>
            /// Centra il testo orizzontalmente nel rettangolo di visualizzazione.
            /// </summary>
            HorizontallyCenterText = CommonEnumerations.TextFormat.DT_CENTER,
            /// <summary>
            /// Duplica le caratteristiche di visualizzazione del testo di un controllo multilinea di modifica.
            /// </summary>
            MultilineEditControlLike = CommonEnumerations.TextFormat.DT_EDITCONTROL,
            /// <summary>
            /// Tronca il testo più largo del rettangolo di visualizzazione e aggiunge i puntini di sospensione per indicare il troncamento.
            /// </summary>
            /// <remarks>Il testo non viene modificato a meno che <see cref="EditString"/> non sia specificato.</remarks>
            TruncateWithEllipsis = CommonEnumerations.TextFormat.DT_END_ELLIPSIS,
            /// <summary>
            /// Espande i caratteri di tabulazione.
            /// </summary>
            /// <remarks><see cref="TruncateAllTooLongWords"/>, <see cref="EllipsisInMiddleOfText"/> e <see cref="TruncateWithEllipsis"/> non possono essere usati con questo formato.</remarks>
            ExpandTabChars = CommonEnumerations.TextFormat.DT_EXPANDTABS,
            /// <summary>
            /// Include il leading esterno di un font nell'altezza della linea.
            /// </summary>
            IncludeFontExternalLeading = CommonEnumerations.TextFormat.DT_EXTERNALLEADING,
            /// <summary>
            /// Ignora il carattere prefisso "e commerciale" nel testo.
            /// </summary>
            IgnorePrefixCommercialE = CommonEnumerations.TextFormat.DT_HIDEPREFIX,
            /// <summary>
            /// Allinea il testo a sinistra.
            /// </summary>
            AlignToTheLeft = CommonEnumerations.TextFormat.DT_LEFT,
            /// <summary>
            /// Modifica la stringa perché corrisponda al testo visualizzato.
            /// </summary>
            /// <remarks>Non ha nessun effetto se non è specificato <see cref="TruncateWithEllipsis"/> oppure <see cref="EllipsisInMiddleOfText"/>.</remarks>
            EditString = CommonEnumerations.TextFormat.DT_MODIFYSTRING,
            /// <summary>
            /// Disegna il testo senza clippare il rettagolo di visualizzazione.
            /// </summary>
            DoNotClipDisplayRectangle = CommonEnumerations.TextFormat.DT_NOCLIP,
            /// <summary>
            /// Impedisce la fine della linea ai set di caratteri a due byte, così che la regola sia la stessa per i set di caratteri a singolo byte.
            /// </summary>
            /// <remarks>Non ha nessun effetto se <see cref="BreakLineBetweenWordsIfTooLong"/> non è specificato.</remarks>
            NoDBCSLineBreak = CommonEnumerations.TextFormat.DT_NOFULLWIDTHCHARBREAK,
            /// <summary>
            /// Disattiva l'elaborazione dei caratteri di prefisso.
            /// </summary>
            DisablePrefixCharProcessing = CommonEnumerations.TextFormat.DT_NOPREFIX,
            /// <summary>
            /// Sostituisce i caratteri in mezzo al testo con i puntini di sospensione così che il testo non esca dal rettangolo di visualizzazione
            /// </summary>
            /// <remarks>Se la stringa contiene caratteri backslash, viene preservato il più possibile del testo dopo l'ultimo backslash.<br/><br/>
            /// La stringa non viene modificata a meno che <see cref="EditString"/> non è specificato.</remarks>
            EllipsisInMiddleOfText = CommonEnumerations.TextFormat.DT_PATH_ELLIPSIS,
            /// <summary>
            /// Disegna solo una sottolineatura alla posizione del carattere che segue il prefisso "e commerciale".
            /// </summary>
            DrawOnlyUnderline = CommonEnumerations.TextFormat.DT_PREFIXONLY,
            /// <summary>
            /// Allinea il testo a destra.
            /// </summary>
            AlignToTheRight = CommonEnumerations.TextFormat.DT_RIGHT,
            /// <summary>
            /// Il testo è posizionato in ordine da destra a sinistra per testo bidirezionale.
            /// </summary>
            RtlTextOrder = CommonEnumerations.TextFormat.DT_RTLLEADING,
            /// <summary>
            /// Mostra il testo su una singola linea.
            /// </summary>
            TextOnSingleLine = CommonEnumerations.TextFormat.DT_SINGLELINE,
            /// <summary>
            /// Imposta un tab stop.
            /// </summary>
            SetTabStops = CommonEnumerations.TextFormat.DT_TABSTOP,
            /// <summary>
            /// Renderizza il testo nella parte superiore del rettangolo di visualizzazione.
            /// </summary>
            RenderAtTop = CommonEnumerations.TextFormat.DT_TOP,
            /// <summary>
            /// Centra il testo verticalmente.
            /// </summary>
            /// <remarks>Utilizzato solamente con <see cref="TextOnSingleLine"/>.</remarks>
            VerticallyCenterText = CommonEnumerations.TextFormat.DT_VCENTER,
            /// <summary>
            /// Interrompe le linee tra le parole se la parola si estende oltre il bordo del rettangolo di visualizzazione.
            /// </summary>
            BreakLineBetweenWordsIfTooLong = CommonEnumerations.TextFormat.DT_WORDBREAK,
            /// <summary>
            /// Tronca ogni parola troppo lunga per il rettangolo di visualizzazione e aggiunge i puntini di sospensione.
            /// </summary>
            TruncateAllTooLongWords = CommonEnumerations.TextFormat.DT_WORD_ELLIPSIS
        }

        /// <summary>
        /// Classi dei controlli comuni.
        /// </summary>
        [Flags]
        public enum CommonControlsClasses
        {
            /// <summary>
            /// Animate.
            /// </summary>
            AnimateControl = CommonClasses.ICC_ANIMATE_CLASS,
            /// <summary>
            /// Toolbar, barra di stato, trackbar, tooltip.
            /// </summary>
            BarControls = CommonClasses.ICC_BAR_CLASSES,
            /// <summary>
            /// Rebar.
            /// </summary>
            RebarControl = CommonClasses.ICC_COOL_CLASSES,
            /// <summary>
            /// Selettore data o ora.
            /// </summary>
            DateTimePickerControl = CommonClasses.ICC_DATE_CLASSES,
            /// <summary>
            /// Hotkey.
            /// </summary>
            HotkeyControl = CommonClasses.ICC_HOTKEY_CLASS,
            /// <summary>
            /// Indirizzo IP.
            /// </summary>
            IPAddressControl = CommonClasses.ICC_INTERNET_CLASSES,
            /// <summary>
            /// Collegamento ipertestuale.
            /// </summary>
            HyperlinkControl = CommonClasses.ICC_LINK_CLASS,
            /// <summary>
            /// List view e header.
            /// </summary>
            ListViewAndHeaderControl = CommonClasses.ICC_LISTVIEW_CLASS,
            /// <summary>
            /// Font nativo.
            /// </summary>
            NativeFontControl = CommonClasses.ICC_NATIVEFNTCTL_CLASS,
            /// <summary>
            /// Pager.
            /// </summary>
            PagerControl = CommonClasses.ICC_PAGESCROLLER_CLASS,
            /// <summary>
            /// Barra di progresso.
            /// </summary>
            ProgressBarControl = CommonClasses.ICC_PROGRESS_CLASS,
            /// <summary>
            /// Una delle classi intrinsiche User32.
            /// </summary>
            /// <remarks>I controlli utente includono:<br/><br/>
            /// pulsanti<br/>
            /// edit<br/>
            /// static<br/>
            /// listbox<br/>
            /// combobox<br/>
            /// barra di scorrimento</remarks>
            StandardControls = CommonClasses.ICC_STANDARD_CLASSES,
            /// <summary>
            /// Tab e tooltip.
            /// </summary>
            TabTooltipControls = CommonClasses.ICC_TAB_CLASSES,
            /// <summary>
            /// Treeview e tooltip.
            /// </summary>
            TreeviewTooltipControls = CommonClasses.ICC_TREEVIEW_CLASSES,
            /// <summary>
            /// Up-down.
            /// </summary>
            UpDownControl = CommonClasses.ICC_UPDOWN_CLASS,
            /// <summary>
            /// ComboBoxEx.
            /// </summary>
            ComboBoxExControl = CommonClasses.ICC_USEREX_CLASSES,
            /// <summary>
            /// Animate, header, hotkey, listview, barra di progresso, barra di stato, tab, tooltip, toolbar, trackbar, treeview, up-down.
            /// </summary>
            Win95Controls = CommonClasses.ICC_WIN95_CLASSES
        }

        /// <summary>
        /// Dimensione dell'icona.
        /// </summary>
        public enum IconSize
        {
            /// <summary>
            /// Piccola.
            /// </summary>
            Small = IconMetric.LIM_SMALL,
            /// <summary>
            /// Grande.
            /// </summary>
            Large = IconMetric.LIM_LARGE
        }
    }
}