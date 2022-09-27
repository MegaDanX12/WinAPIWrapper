using System.ComponentModel;
using WinApiWrapper.UserInterface.Accessibility;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationEnumerations;
using static WinApiWrapper.UserInputAndMessaging.WindowsAndMessages.Configuration.ConfigurationFunctions;
using static WinApiWrapper.UserInterface.Accessibility.AccessibilityStructures;

namespace WinApiWrapper.Managed.UserInterface.Accessibility
{
    /// <summary>
    /// Informazioni sulla funzionalità MouseKeys.
    /// </summary>
    public class MouseKeysInfo
    {
        /// <summary>
        /// Indica se la funzionalità MouseKeys è disponibile.
        /// </summary>
        public bool IsMouseKeysAvailable { get; }

        /// <summary>
        /// Indica se verrà visualizzata una finestra di dialogo di conferma quando la funzionalità MouseKeys viene attivata tramite hotkey.
        /// </summary>
        public bool IsConfirmationDialogBoxEnabled { get; }

        /// <summary>
        /// Indica se la hotkey è attiva.
        /// </summary>
        public bool IsHotkeyActive { get; }

        /// <summary>
        /// Indica se il sistema emetterà un suono quando la funzionalità MouseKeys verrà attivata o disattivata tramite hotkey.
        /// </summary>
        public bool IsHotkeySoundEnabled { get; }

        /// <summary>
        /// Indica se un indicatore visuale verrà visualizzato quando la funzionalità MouseKeys è attiva.
        /// </summary>
        public bool IsVisualIndicatorEnabled { get; }

        /// <summary>
        /// Indica se il tasto sinistro del mouse è in stato "premuto".
        /// </summary>
        public bool IsLeftMouseButtonDown { get; }

        /// <summary>
        /// Indica se il tasto sinistro del mouse è quello selezionato per le azioni.
        /// </summary>
        public bool IsLeftMouseButtonSelected { get; }

        /// <summary>
        /// Indica se i tasti CTRL e SHIFT alterano il comportamento del cursore.
        /// </summary>
        /// <remarks>Il tasto CTRL modifica la velocità del mouse in base al valore del campo <see cref="CtrlMultiplier"/>, il tasto SHIFT causa un ritardo del movimento del cursore per ogni pixel.</remarks>
        public bool ModifierKeysAlterCursorBehaviour { get; }

        /// <summary>
        /// Indica se la funzionalità MouseKeys è abilitata.
        /// </summary>
        public bool IsMouseKeysEnabled { get; }

        /// <summary>
        /// Indica se l'input proveniente dal tastierino numerico viene trattato come comandi del mouse.
        /// </summary>
        public bool NumericKeypadAsMouseCommands { get; }

        /// <summary>
        /// Indica per quale stato del tasto NUM LOCK l'input del tastierino numerico causa il movimento del mouse.
        /// </summary>
        /// <remarks>Se true il NUM LOCK deve essere attivo perchè l'input del tastierino numerico muova il mouse, se false il NUM LOCK deve essere disattivato.</remarks>
        public bool ReplaceNumbers { get; }

        /// <summary>
        /// Indica se il tasto destro del mouse è in stato "premuto".
        /// </summary>
        public bool IsRightMouseButtonDown { get; }

        /// <summary>
        /// Indica se il tasto destro del mouse è quello selezionato per le azioni.
        /// </summary>
        public bool IsRightMouseButtonSelected { get; }

        /// <summary>
        /// Velocità massima del cursore.
        /// </summary>
        public int CursorMaxSpeed { get; }

        /// <summary>
        /// Tempo, in secondi, necessario per raggiungere la velocità massima del cursore.
        /// </summary>
        public int TimeToMaxSpeed { get; }

        /// <summary>
        /// Moltiplicatore da applicare alla velocità del cursore quando si tiene premuto il tasto CTRL mentre si usa le frecce direzionali per muovere il mouse.
        /// </summary>
        /// <remarks>Se <see cref="ModifierKeysAlterCursorBehaviour"/> è false, questo valore viene ignorato.</remarks>
        public int CtrlMultiplier { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="MouseKeysInfo"/>.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public MouseKeysInfo()
        {
            MOUSEKEYS MouseKeysData = new();
            MouseKeysData.Size = (uint)Marshal.SizeOf(typeof(MOUSEKEYS));
            HMODULE MouseKeysDataStructurePointer = Marshal.AllocHGlobal((int)MouseKeysData.Size);
            Marshal.StructureToPtr(MouseKeysData, MouseKeysDataStructurePointer, false);
            if (SystemParametersInfo((uint)SystemParametersAccessibility.SPI_GETMOUSEKEYS, MouseKeysData.Size, MouseKeysDataStructurePointer, SystemParameterUserProfileUpdateOptions.NoAction))
            {
                MouseKeysData = (MOUSEKEYS)Marshal.PtrToStructure(MouseKeysDataStructurePointer, typeof(MOUSEKEYS))!;
                IsMouseKeysAvailable = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_AVAILABLE);
                IsConfirmationDialogBoxEnabled = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_CONFIRMHOTKEY);
                IsHotkeyActive = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_HOTKEYACTIVE);
                IsHotkeySoundEnabled = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_HOTKEYSOUND);
                IsVisualIndicatorEnabled = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_INDICATOR);
                IsLeftMouseButtonDown = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_LEFTBUTTONDOWN);
                IsLeftMouseButtonSelected = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_LEFTBUTTONSEL);
                ModifierKeysAlterCursorBehaviour = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_MODIFIERS);
                IsMouseKeysEnabled = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_MOUSEKEYSON);
                NumericKeypadAsMouseCommands = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_MOUSEMODE);
                ReplaceNumbers = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_REPLACENUMBERS);
                IsRightMouseButtonDown = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_RIGHTBUTTONDOWN);
                IsRightMouseButtonSelected = MouseKeysData.Flags.HasFlag(AccessibilityEnumerations.MouseKeysProperties.MKF_RIGHTBUTTONSEL);
                CursorMaxSpeed = (int)MouseKeysData.MaxSpeed;
                TimeToMaxSpeed = (int)(MouseKeysData.TimeToMaxSpeed / 1000);
                CtrlMultiplier = (int)MouseKeysData.CtrlSpeed;
                Marshal.FreeHGlobal(MouseKeysDataStructurePointer);
            }
            else
            {
                Marshal.FreeHGlobal(MouseKeysDataStructurePointer);
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="MouseKeysInfo"/>.
        /// </summary>
        /// <param name="Available">Indica se la funzionalità è disponibile.</param>
        /// <param name="ConfirmationDialogEnabled">Indica se l'attivazione della funzionalità tramite hotkey causa la visualizzazione di una finestra di dialogo di conferma.</param>
        /// <param name="HotkeyActive">Indica se la hotkey è attiva.</param>
        /// <param name="HotkeySoundEnabled">Indica se il sistema emette un suono quando la funzionalità viene attivata o disattivata tramite hotkey.</param>
        /// <param name="VisualIndicatorEnabled">Indica se viene visualizzato un indicatore visuale quando la funzionalità è attiva.</param>
        /// <param name="ModifiersAlterBehaviour">Indica se i tasti CTRL e SHIFT alterano il comportamento del cursore.</param>
        /// <param name="Enabled">Indica se la funzionalità è attivata.</param>
        /// <param name="ReplaceNumbers">Indica per quale stato del tasto NUM LOCK l'input del tastierino numerico causa il movimento del mouse.</param>
        /// <param name="MaxSpeed">Velocità massima del cursore.</param>
        /// <param name="TimeToMaxSpeed">Tempo, in secondi, necessario per raggiungere la velocità massima da parte del cursore.</param>
        /// <param name="CtrlSpeed">Moltiplicatore da applicare alla velocità del cursore quando si tiene premuto il tasto CTRL mentre si usa le frecce direzionali per muovere il mouse.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public MouseKeysInfo(bool Available, bool ConfirmationDialogEnabled, bool HotkeyActive, bool HotkeySoundEnabled, bool VisualIndicatorEnabled, bool ModifiersAlterBehaviour, bool Enabled, bool ReplaceNumbers, int MaxSpeed, int TimeToMaxSpeed, int CtrlSpeed)
        {
            IsMouseKeysAvailable = Available;
            IsConfirmationDialogBoxEnabled = ConfirmationDialogEnabled;
            IsHotkeyActive = HotkeyActive;
            IsHotkeySoundEnabled = HotkeySoundEnabled;
            IsVisualIndicatorEnabled = VisualIndicatorEnabled;
            ModifierKeysAlterCursorBehaviour = ModifiersAlterBehaviour;
            IsMouseKeysEnabled = Enabled;
            this.ReplaceNumbers = ReplaceNumbers;
            CursorMaxSpeed = MaxSpeed;
            if (TimeToMaxSpeed is < 1 or > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(TimeToMaxSpeed), "The value of the parameter must be between 1 and 5 included.");
            }
            else
            {
                this.TimeToMaxSpeed = TimeToMaxSpeed;
            }
            CtrlMultiplier = CtrlSpeed;
        }
    }
}