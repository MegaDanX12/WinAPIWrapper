using System.ComponentModel;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMFunctions;

namespace WinApiWrapper.Managed.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Informazioni sulle tempistiche della composizione DWM.
    /// </summary>
    public class DWMCompositionTimingInfo
    {
        /// <summary>
        /// Frequenza di aggiornamento del monitor.
        /// </summary>
        public double RefreshRate { get; }

        /// <summary>
        /// Periodo di aggiornamento del monitor.
        /// </summary>
        public long RefreshPeriod { get; }

        /// <summary>
        /// Rapporto di composizione.
        /// </summary>
        public double CompositionRate { get; }

        /// <summary>
        /// Valore del contatore performance prima del vuoto verticale.
        /// </summary>
        public long VBlank { get; }

        /// <summary>
        /// Contatore di aggiornamento DWM.
        /// </summary>
        public long Refresh { get; }

        /// <summary>
        /// Contatore di aggiornamento DirectX.
        /// </summary>
        public int DirectXRefresh { get; }

        /// <summary>
        /// Valore del contatore performance per la composizione di un frame.
        /// </summary>
        public long Compose { get; }

        /// <summary>
        /// Il numero del frame composto al momento indicato da <see cref="Compose"/>.
        /// </summary>
        public long Frame { get; }

        /// <summary>
        /// Il numero del presente DirectX usato per identificare i frame in rendering.
        /// </summary>
        public int DirectXPresent { get; }

        /// <summary>
        /// Il contatore di aggiornamento del frame composto al momento indicato da <see cref="Compose"/>.
        /// </summary>
        public long RefreshFrame { get; }

        /// <summary>
        /// Il numero di frame DWM appena inviato.
        /// </summary>
        public long FrameSubmitted { get; }

        /// <summary>
        /// Il numero del presente DirectX del frame appena inviato.
        /// </summary>
        public int DirectXPresentSubmitted { get; }

        /// <summary>
        /// Il numero dell'ultimo frame DWM confermato come presentato.
        /// </summary>
        public long FrameConfirmed { get; }

        /// <summary>
        /// Il numero del presente DirectX dell'ultimo frame confermato come presentato.
        /// </summary>
        public int DirectXPresentConfirmed { get; }

        /// <summary>
        /// Il conteggio di aggiornamento obbiettivo dell'ultimo frame confermato come completato dalla GPU.
        /// </summary>
        public long RefreshConfirmed { get; }

        /// <summary>
        /// Il conteggio di aggiornamento DirectX quando il frame è stato confermato come presentato.
        /// </summary>
        public int DirectXRefreshConfirmed { get; }

        /// <summary>
        /// Numero di frames che DWM ha presentato in ritardo.
        /// </summary>
        public long FramesLate { get; }

        /// <summary>
        /// Numero di frame di composizione che sono stati inviati ma non ancora confermati come completati.
        /// </summary>
        public int FramesOutstanding { get; }

        /// <summary>
        /// L'ultimo frame visualizzato.
        /// </summary>
        public long FrameDisplayed { get; }

        /// <summary>
        /// Il tempo del contatore performance del passaggio della composizione di quando il frame è stato visualizzato.
        /// </summary>
        public long FrameDisplayedQPC { get; }

        /// <summary>
        /// Il conteggio di aggiornamento verticale quando il frame dovrebbe essere diventato visibile.
        /// </summary>
        public long RefreshFrameDisplayed { get; }

        /// <summary>
        /// L'ID dell'ultimo frame indicato come completato.
        /// </summary>
        public long FrameComplete { get; }

        /// <summary>
        /// Il tempo del contatore performance quando l'ultimo frame è stato indicato come completato.
        /// </summary>
        public long FrameCompleteQPC { get; }

        /// <summary>
        /// L'ID dell'ultimo frame indicato come in attesa.
        /// </summary>
        public long FramePending { get; }

        /// <summary>
        /// Il tempo del contatore performance quando l'ultimo frame è stato indicato come in attesa.
        /// </summary>
        public long FramePendingQPC { get; }

        /// <summary>
        /// Numero di frame unici visualizzati.
        /// </summary>
        public long FramesDisplayed { get; }

        /// <summary>
        /// Il numero di nuovi frame completati che sono stati ricevuti.
        /// </summary>
        public long FramesComplete { get; }

        /// <summary>
        /// Il numero di nuovi frame inviati a DirectX ma non ancora completati.
        /// </summary>
        public long FramesPending { get; }

        /// <summary>
        /// Il numero di frame disponibili ma non visualizzati, usati o ignorati.
        /// </summary>
        public long FramesAvailable { get; }

        /// <summary>
        /// Numero di frame renderizzati che non sono mai stati visualizzati perché la composizione è avvenuta troppo tardi.
        /// </summary>
        public long FramesDropped { get; }

        /// <summary>
        /// Numero di volte che un vecchio frame è stato composto quando un nuovo frame dovrebbe essere stato usato ma non era disponibile.
        /// </summary>
        public long FramesMissed { get; }

        /// <summary>
        /// Il conteggio frame a cui il prossimo frame è programmato per essere visualizzato.
        /// </summary>
        public long RefreshNextDisplayed { get; }

        /// <summary>
        /// Il conteggio frame a cui la prossima presentazione DirectX è programmato per essere visualizzato.
        /// </summary>
        public long RefreshNextPresented { get; }

        /// <summary>
        /// Numero totale di aggiornamenti che sono stati visualizzati dall'applicazione.
        /// </summary>
        public long RefreshesDisplayed { get; }

        /// <summary>
        /// Il numero totale di aggiornamenti che sono stati presentati dall'applicazione.
        /// </summary>
        public long RefreshesPresented { get; }

        /// <summary>
        /// Il numero di aggiornamento quando la visualizzazione del contenuto per questa finestra è iniziato.
        /// </summary>
        public long RefreshStarted { get; }

        /// <summary>
        /// Numero totale di pixel DirectX ridirezionati a DWM.
        /// </summary>
        public long PixelsReceived { get; }

        /// <summary>
        /// Numero di pixel disegnati.
        /// </summary>
        public long PixelsDrawn { get; }

        /// <summary>
        /// Numero di buffer vuoti nella flip chain.
        /// </summary>
        public long BuffersEmpty { get; }

        /// <summary>
        /// Inizializza una nuova istanza <see cref="DWMCompositionTimingInfo"/>.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        internal DWMCompositionTimingInfo()
        {
            DWM_TIMING_INFO Info = new();
            Info.Size = (uint)Marshal.SizeOf(typeof(DWM_TIMING_INFO));
            HRESULT OperationResult = DwmGetCompositionTimingInfo(HMODULE.Zero, ref Info);
            if (OperationResult == S_OK)
            {
                RefreshRate = (double)Info.RefreshRate.Numerator / Info.RefreshRate.Denominator;
                RefreshPeriod = (long)Info.RefreshPeriod;
                CompositionRate = (double)Info.ComposeRate.Numerator / Info.ComposeRate.Denominator;
                VBlank = (long)Info.VBlank;
                Refresh = (long)Info.Refresh;
                DirectXRefresh = (int)Info.DXRefresh;
                Compose = (long)Info.Compose;
                Frame = (long)Info.Frame;
                DirectXPresent = (int)Info.DXPresent;
                RefreshFrame = (long)Info.RefreshFrame;
                FrameSubmitted = (long)Info.FrameSubmitted;
                DirectXPresentSubmitted = (int)Info.DXPresentSubmitted;
                FrameConfirmed = (long)Info.FrameConfirmed;
                DirectXPresentConfirmed = (int)Info.DXPresentConfirmed;
                RefreshConfirmed = (long)Info.RefreshConfirmed;
                DirectXRefreshConfirmed = (int)Info.DXRefreshConfirmed;
                FramesLate = (long)Info.FramesLate;
                FramesOutstanding = (int)Info.FramesOutstanding;
                FrameDisplayed = (long)Info.FrameDisplayed;
                FrameDisplayedQPC = (long)Info.FrameDisplayedQPC;
                RefreshFrameDisplayed = (long)Info.RefreshFrameDisplayed;
                FrameComplete = (long)Info.FrameComplete;
                FrameCompleteQPC = (long)Info.FrameCompleteQPC;
                FramePending = (long)Info.FramePending;
                FramePendingQPC = (long)Info.FramePendingQPC;
                FramesDisplayed = (long)Info.FramesDisplayed;
                FramesComplete = (long)Info.FramesComplete;
                FramesPending = (long)Info.FramesPending;
                FramesAvailable = (long)Info.FramesAvailable;
                FramesDropped = (long)Info.FramesDropped;
                FramesMissed = (long)Info.FramesMissed;
                RefreshNextDisplayed = (long)Info.RefreshNextDisplayed;
                RefreshNextPresented = (long)Info.RefreshNextPresented;
                RefreshesDisplayed = (long)Info.RefreshesDisplayed;
                RefreshesPresented = (long)Info.RefreshesPresented;
                RefreshStarted = (long)Info.RefreshStarted;
                PixelsReceived = (long)Info.PixelsReceived;
                PixelsDrawn = (long)Info.PixelsDrawn;
                BuffersEmpty = (long)Info.BuffersEmpty;
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
}