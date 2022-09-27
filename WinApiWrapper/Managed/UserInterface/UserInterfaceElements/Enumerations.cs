using static WinApiWrapper.UserInterface.UserInterfaceElements.GeneralEnumerations;

namespace WinApiWrapper.Managed.UserInterface.UserInterfaceElements
{
    /// <summary>
    /// Enumerazione generali per gli elementi dell'interfaccia utente.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// ID delle risorse standard.
        /// </summary>
        public enum StandardResource
        {
            /// <summary>
            /// Cursore freccia standard.
            /// </summary>
            StandardArrowCursor = StandardResourceID.IDC_ARROW,
            /// <summary>
            /// Cursore I-beam.
            /// </summary>
            IBeamCursor = StandardResourceID.IDC_IBEAM,
            /// <summary>
            /// Cursore clessidra.
            /// </summary>
            HourglassCursor = StandardResourceID.IDC_WAIT,
            /// <summary>
            /// Cursore mirino.
            /// </summary>
            CrossCursor = StandardResourceID.IDC_CROSS,
            /// <summary>
            /// Cursore freccia verticale.
            /// </summary>
            UpArrowCursor = StandardResourceID.IDC_UPARROW,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato nord-ovest e sud-est.
            /// </summary>
            SizeCursorNWSE = StandardResourceID.IDC_SIZENWSE,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato nord-est e sud-ovest.
            /// </summary>
            SizeCursorNESW = StandardResourceID.IDC_SIZENESW,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato est e ovest.
            /// </summary>
            SizeCursorWE = StandardResourceID.IDC_SIZEWE,
            /// <summary>
            /// Cursore freccia a doppia punta direzionato nord e sud.
            /// </summary>
            SizeCursorNS = StandardResourceID.IDC_SIZENS,

            SizeCursor = StandardResourceID.IDC_SIZEALL,
            /// <summary>
            /// Cursore circolare.
            /// </summary>
            CircularCursor = StandardResourceID.IDC_NO,
            /// <summary>
            /// Cursore mano.
            /// </summary>
            HandCursor = StandardResourceID.IDC_HAND,
            /// <summary>
            /// Cursore freccia standard e piccola clessidra.
            /// </summary>
            StandardArrowWithSmallHourglassCursor = StandardResourceID.IDC_APPSTARTING,

            HelpCursor = StandardResourceID.IDC_HELP,

            PinCursor = StandardResourceID.IDC_PIN,

            PersonCursor = StandardResourceID.IDC_PERSON,
            /// <summary>
            /// Icona predefinita per le applicazioni.
            /// </summary>
            ApplicationDefaultIcon = StandardResourceID.IDI_APPLICATION,
            /// <summary>
            /// Icona a forma di mano.
            /// </summary>
            HandIcon = StandardResourceID.IDI_HAND,
            /// <summary>
            /// Icona a forma di punto di domanda.
            /// </summary>
            QuestionMarkIcon = StandardResourceID.IDI_QUESTION,
            /// <summary>
            /// Icona a forma di punto esclamativo.
            /// </summary>
            ExclamationMarkIcon = StandardResourceID.IDI_EXCLAMATION,
            /// <summary>
            /// Icona a forma di asterisco.
            /// </summary>
            AsteriskIcon = StandardResourceID.IDI_ASTERISK,
            /// <summary>
            /// Logo di Windows.
            /// </summary>
            WindowsLogoIcon = StandardResourceID.IDI_WINLOGO,
            /// <summary>
            /// Scudo di sicurezza.
            /// </summary>
            SecurityShieldIcon = StandardResourceID.IDI_SHIELD,
            /// <summary>
            /// Icona a forma di punto esclamativo.
            /// </summary>
            WarningIcon = StandardResourceID.IDI_WARNING,
            /// <summary>
            /// Icona a forma di mano.
            /// </summary>
            ErrorIcon = StandardResourceID.IDI_ERROR,
            /// <summary>
            /// Icona a forma di asterisco.
            /// </summary>
            InformationIcon = StandardResourceID.IDI_INFORMATION
        }
    }
}