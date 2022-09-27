using static WinApiWrapper.UserInterface.Accessibility.AccessibilityEnumerations;

namespace WinApiWrapper.UserInterface.Accessibility
{
    /// <summary>
    /// Callback delle funzionalità di accessibilità.
    /// </summary>
    internal static class AccessiblityCallbacks
    {
        /// <summary>
        /// Produce un segnale visuale personalizzato quando la funzionalità Sound Sentry è attiva e un'applicazione basata su Windows (o in esecuzione in una finestra) genera un suono tramite l'altoparlante integrato del computer.
        /// </summary>
        /// <param name="Milliseconds">Durata, in millisecondi, del segnale visuale.</param>
        /// <param name="Effect">Tipo di segnale visuale da visualizzare.</param>
        /// <returns>Se il segnale visuale è stato o verrà visualizzato correttamente, il valore di ritorno deve essere true, se il segnale è asincrono e lo stato non è disponibile al momento della chiamata, dovrebbe restituire true.<br/><br/>
        /// Se un errore ha impedito la visualizzazione del segnale, il valori di ritorno deve essere false.</returns>
        /// <remarks>La funzione deve essere definita in una DLL e quest'ultima deve esportare una funzione con il nome SoundSentryProc.</remarks>
        internal delegate LRESULT SoundSentryProc(DWORD Milliseconds, SoundSentryWindowsEffect Effect);
    }
}