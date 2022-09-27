using static WinApiWrapper.General.GeneralStructures;
using static WinApiWrapper.UserInterface.DesktopWindowManager.DWMEnumerations;

namespace WinApiWrapper.UserInterface.DesktopWindowManager
{
    /// <summary>
    /// Strutture DWM.
    /// </summary>
    internal static class DWMStructures
    {
        /// <summary>
        /// Tipo di dati usato da DWM, rappresenta un rapporto generico usato per diverse operazioni è unità.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct UNSIGNED_RATIO
        {
            /// <summary>
            /// Numeratore.
            /// </summary>
            public uint Numerator;
            /// <summary>
            /// Denominatore.
            /// </summary>
            public uint Denominator;
        }

        /// <summary>
        /// Informazioni riguardanti le tempistiche della composizione DWM.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct DWM_TIMING_INFO
        {
            /// <summary>
            /// Dimensione, in bytes, della struttura.
            /// </summary>
            public uint Size;
            /// <summary>
            /// Frequenza di aggiornamento del monitor.
            /// </summary>
            public UNSIGNED_RATIO RefreshRate;
            /// <summary>
            /// Periodo di aggiornamento del monitor.
            /// </summary>
            public QPC_TIME RefreshPeriod;
            /// <summary>
            /// Rapporto di composizione.
            /// </summary>
            public UNSIGNED_RATIO ComposeRate;
            /// <summary>
            /// Valore del contatore performance prima del vuoto verticale.
            /// </summary>
            public QPC_TIME VBlank;
            /// <summary>
            /// Contatore di aggiornamento DWM.
            /// </summary>
            public DWM_FRAME_COUNT Refresh;
            /// <summary>
            /// Contatore di aggiornamento DirectX.
            /// </summary>
            public uint DXRefresh;
            /// <summary>
            /// Valore del contatore performance per la composizione di un frame.
            /// </summary>
            public QPC_TIME Compose;
            /// <summary>
            /// Il numero del frame composto al momento indicato da <see cref="Compose"/>.
            /// </summary>
            public DWM_FRAME_COUNT Frame;
            /// <summary>
            /// Il numero DirectX usato per identificare i frame in rendering.
            /// </summary>
            public uint DXPresent;
            /// <summary>
            /// Il contatore di aggiornamento del frame composto al momento indicato da <see cref="Compose"/>.
            /// </summary>
            public DWM_FRAME_COUNT RefreshFrame;
            /// <summary>
            /// Il numero di frame DWM appena inviato.
            /// </summary>
            public DWM_FRAME_COUNT FrameSubmitted;
            /// <summary>
            /// Il numero DirectX del frame appena inviato.
            /// </summary>
            public uint DXPresentSubmitted;
            /// <summary>
            /// Il numero dell'ultimo frame DWM confermato come presentato.
            /// </summary>
            public DWM_FRAME_COUNT FrameConfirmed;
            /// <summary>
            /// Il numero DirectX dell'ultimo frame confermato come presentato.
            /// </summary>
            public uint DXPresentConfirmed;
            /// <summary>
            /// Il conteggio di aggiornamento obbiettivo dell'ultimo frame confermato come completato dalla GPU.
            /// </summary>
            public DWM_FRAME_COUNT RefreshConfirmed;
            /// <summary>
            /// Il conteggio di aggiornamento DirectX quando il frame è stato confermato come presentato.
            /// </summary>
            public uint DXRefreshConfirmed;
            /// <summary>
            /// Numero di frames che DWM ha presentato in ritardo.
            /// </summary>
            public DWM_FRAME_COUNT FramesLate;
            /// <summary>
            /// Numero di frame di composizione che sono stati inviati ma non ancora confermati come completati.
            /// </summary>
            public uint FramesOutstanding;
            /// <summary>
            /// L'ultimo frame visualizzato.
            /// </summary>
            public DWM_FRAME_COUNT FrameDisplayed;
            /// <summary>
            /// Il tempo del contatore performance del passaggio della composizione di quando il frame è stato visualizzato.
            /// </summary>
            public QPC_TIME FrameDisplayedQPC;
            /// <summary>
            /// Il conteggio di aggiornamento verticale quando il frame dovrebbe essere diventato visibile.
            /// </summary>
            public DWM_FRAME_COUNT RefreshFrameDisplayed;
            /// <summary>
            /// L'ID dell'ultimo frame indicato come completato.
            /// </summary>
            public DWM_FRAME_COUNT FrameComplete;
            /// <summary>
            /// Il tempo del contatore performance quando l'ultimo frame è stato indicato come completato.
            /// </summary>
            public QPC_TIME FrameCompleteQPC;
            /// <summary>
            /// L'ID dell'ultimo frame indicato come in attesa.
            /// </summary>
            public DWM_FRAME_COUNT FramePending;
            /// <summary>
            /// Il tempo del contatore performance quando l'ultimo frame è stato indicato come in attesa.
            /// </summary>
            public QPC_TIME FramePendingQPC;
            /// <summary>
            /// Numero di frame unici visualizzati.
            /// </summary>
            public DWM_FRAME_COUNT FramesDisplayed;
            /// <summary>
            /// Il numero di nuovi frame completati che sono stati ricevuti.
            /// </summary>
            public DWM_FRAME_COUNT FramesComplete;
            /// <summary>
            /// Il numero di nuovi frame inviati a DirectX ma non ancora completati.
            /// </summary>
            public DWM_FRAME_COUNT FramesPending;
            /// <summary>
            /// Il numero di frame disponibili ma non visualizzati, usati o ignorati.
            /// </summary>
            public DWM_FRAME_COUNT FramesAvailable;
            /// <summary>
            /// Numero di frame renderizzati che non sono mai stati visualizzati perché la composizione è avvenuta troppo tardi.
            /// </summary>
            public DWM_FRAME_COUNT FramesDropped;
            /// <summary>
            /// Numero di volte che un vecchio frame è stato composto quando un nuovo frame dovrebbe essere stato usato ma non era disponibile.
            /// </summary>
            public DWM_FRAME_COUNT FramesMissed;
            /// <summary>
            /// Il conteggio frame a cui il prossimo frame è programmato per essere visualizzato.
            /// </summary>
            public DWM_FRAME_COUNT RefreshNextDisplayed;
            /// <summary>
            /// Il conteggio frame a cui la prossima presentazione DirectX è programmato per essere visualizzato.
            /// </summary>
            public DWM_FRAME_COUNT RefreshNextPresented;
            /// <summary>
            /// Numero totale di aggiornamenti che sono stati visualizzati dall'applicazione.
            /// </summary>
            public DWM_FRAME_COUNT RefreshesDisplayed;
            /// <summary>
            /// Il numero totale di aggiornamenti che sono stati presentati dall'applicazione.
            /// </summary>
            public DWM_FRAME_COUNT RefreshesPresented;
            /// <summary>
            /// Il numero di aggiornamento quando la visualizzazione del contenuto per questa finestra è iniziato.
            /// </summary>
            public DWM_FRAME_COUNT RefreshStarted;
            /// <summary>
            /// Numero totale di pixel DirectX ridirezionati a DWM.
            /// </summary>
            public ULONGLONG PixelsReceived;
            /// <summary>
            /// Numero di pixel disegnati.
            /// </summary>
            public ULONGLONG PixelsDrawn;
            /// <summary>
            /// Numero di buffer vuoti nella flip chain.
            /// </summary>
            public DWM_FRAME_COUNT BuffersEmpty;
        }

        /// <summary>
        /// Specifica le proprietà di una miniatura DWM.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DWM_THUMBNAIL_PROPERTIES
        {
            /// <summary>
            /// Indica quali campi della struttura sono validi.
            /// </summary>
            public DwmThumbnailProperties Flags;
            /// <summary>
            /// Area nella finestra di destinazione dove la miniatura verrà renderizzata.
            /// </summary>
            public RECT Destination;
            /// <summary>
            /// La regione della finestra di origine da usare come miniatura.
            /// </summary>
            public RECT Source;
            /// <summary>
            /// L'opacità con cui renderizzare la miniatura.
            /// </summary>
            /// <remarks>0 significa completamente trasparente, 255 (default) significa completamente opaco.</remarks>
            public byte Opacity;
            /// <summary>
            /// true per rendere la miniatura visibile, false (default) altrimenti.
            /// </summary>
            public BOOL Visible;
            /// <summary>
            /// true per usare solamente l'area client della fonte della miniatura, false (default) altrimenti.
            /// </summary>
            public BOOL SourceClientAreaOnly;
        }
    }
}