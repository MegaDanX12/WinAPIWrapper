namespace WinApiWrapper.UserInterface.UserInterfaceElements.CommonDialogBoxes
{
    /// <summary>
    /// Enumerazioni comuni delle finestre di dialogo.
    /// </summary>
    internal static class CommonDialogBoxesEnumerations
    {
        /// <summary>
        /// Opzioni di inizializzazione di una finestra di dialogo di scelta colori.
        /// </summary>
        [Flags]
        internal enum ColorDialogInitializationOptions
        {
            /// <summary>
            /// La finestra di dialogo visualizzare tutti i colori disponibili nel set di colori base.
            /// </summary>
            CC_ANYCOLOR = 256,
            /// <summary>
            /// Abilita la procedura di hook.
            /// </summary>
            /// <remarks>Questa opzione è usata solo per inizializzare la finestra di dialogo.</remarks>
            CC_ENABLEHOOK = 16,
            /// <summary>
            /// Indica che deve essere usato il modello specificato tramite handle al modulo che lo contiene e nome al posto di quello predefinito.
            /// </summary>
            /// <remarks>Questa opzione è usata solo per inizializzare la finestra di dialogo.</remarks>
            CC_ENABLETEMPLATE = 32,
            /// <summary>
            /// Indica che deve essere usato il modello precaricato specificato tramite handle.
            /// </summary>
            /// <remarks>Questa opzione è usata solo per inizializzare la finestra di dialogo.</remarks>
            CC_ENABLETEMPLATEHANDLE = 64,
            /// <summary>
            /// La finestra di dialogo visualizza controlli addizionali che permettono di creare colori personalizzazi.
            /// </summary>
            CC_FULLOPEN = 2,
            /// <summary>
            /// Disabilita il pulsante "Definisci colori personalizzati".
            /// </summary>
            CC_PREVENTFULLOPEN = 4,
            /// <summary>
            /// La finestra di dialogo usa un colore specificato come selezione iniziale.
            /// </summary>
            CC_RGBINIT = 1,
            /// <summary>
            /// La finestra di dialogo include il pulsante "Aiuto".
            /// </summary>
            /// <remarks>Deve essere specificata la finestra che riceve la notifica <see cref="CommonDialogBoxesNotifications.HELPMSGSTRING"/>.</remarks>
            CC_SHOWHELP = 8,
            /// <summary>
            /// La finestra di dialogo mostra soltanto colori solidi nel set di colori base.
            /// </summary>
            CC_SOLIDCOLOR = 128
        }

        /// <summary>
        /// Opzioni di inizializzazione della finestra di dialogo di selezione font.
        /// </summary>
        [Flags]
        internal enum FontDialogInitializationOptions
        {
            /// <summary>
            /// La finestra di dialogo mostra il pulsante Applica.
            /// </summary>
            /// <remarks>E' necessaria una procedura per elaborare i messaggi <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_COMMAND"/> per il pulsante.<br/><br/>
            /// La procedura può inviare il messaggio <see cref="UserInputAndMessaging.WindowsAndMessages.Windows.WindowMessages.WM_CHOOSEFONT_GETLOGFONT"/> alla finestra di dialogo per recuperare l'indirizzo della struttura che contiene la selezione corrente.</remarks>
            CF_APPLY = 512,
            /// <summary>
            /// La finestra di dialogo visualizza i controlli che permettono all'utente di specificare "barrato", "sottolineato" e il colore del testo.
            /// </summary>
            CF_EFFECTS = 256,
            /// <summary>
            /// Abilita l'hook.
            /// </summary>
            CF_ENABLEHOOK = 8,
            /// <summary>
            /// Indica che deve essere usato il modello presente nel modulo indicato e con il nome specificato.
            /// </summary>
            CF_ENABLETEMPLATE = 16,
            /// <summary>
            /// Indica che deve essere usato il modello precaricato indicato da un handle.
            /// </summary>
            CF_ENABLETEMPLATEHANDLE = 32,
            /// <summary>
            /// Dovrebbero essere enumerati solo i font la cui angolazione è fissa.
            /// </summary>
            CF_FIXEDPITCHONLY = 16384,
            /// <summary>
            /// La finestra di dialogo deve visualizzare un errore se l'utente tenta di selezionare un font o uno stile non presente.
            /// </summary>
            CF_FORCEFONTEXIST = 65536,
            /// <summary>
            /// La finestra di dialogo deve visualizzare anche i font impostati come nascosti.
            /// </summary>
            CF_INACTIVEFONTS = 33554432,
            /// <summary>
            /// La finestra di dialogo deve usare la struttura <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures.LOGFONT"/> fornita per inizializzare i controlli.
            /// </summary>
            CF_INITLOGFONTSTRUCT = 64,
            /// <summary>
            /// La finestra di dialogo deve visualizzare solo i font le cui dimensioni rientrano in quelle specificate
            /// </summary>
            CF_LIMITSIZE = 8192,
            /// <summary>
            /// La finestra di dialogo non permette la selezione di font vettori.
            /// </summary>
            CF_NOVECTORFONTS = 2048,
            /// <summary>
            /// Uguale a <see cref="CF_NOVECTORFONTS"/>.
            /// </summary>
            CF_NOOEMFONTS = CF_NOVECTORFONTS,
            /// <summary>
            /// Impedisce la visualizzazione di una selezione iniziale quando la struttura <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures.LOGFONT"/> viene usata per inizializzare la finestra di dialogo.
            /// </summary>
            CF_NOFACESEL = 524288,
            /// <summary>
            /// Il ComboBox "Script" è disabilitato.
            /// </summary>
            /// <remarks>Questa opzione è utilizzata solo per inizializzare la finestra di dialogo.</remarks>
            CF_NOSCRIPTSEL = 8388608,
            /// <summary>
            /// La finestra di dialogo non permette la selezione e non visualizza le simulazioni di font.
            /// </summary>
            CF_NOSIMULATIONS = 4096,
            /// <summary>
            /// /// <summary>
            /// Impedisce la visualizzazione di una selezione iniziale della dimensione di un font quando la struttura <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures.LOGFONT"/> viene usata per inizializzare la finestra di dialogo.
            /// </summary>
            /// </summary>
            CF_NOSIZESEL = 2097152,
            /// <summary>
            /// Impedisce la visualizzazione di una selezione iniziale relativa allo stile quando la struttura <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures.LOGFONT"/> viene usata per inizializzare la finestra di dialogo.
            /// </summary>
            CF_NOSTYLESEL = 1048576,
            /// <summary>
            /// La finestra di dialogo elenca soltanto i font orizzontali.
            /// </summary>
            CF_NOVERTFONTS = 16777216,
            /// <summary>
            /// La finestra di dialogo permette la selezione solo di font scalabili.
            /// </summary>
            CF_SCALABLEONLY = 131072,
            /// <summary>
            /// La finestra di dialogo permette la selezione solo di font non-OEM e set di caratteri composti da simboli e set di caratteri ANSI.
            /// </summary>
            CF_SCRIPTSONLY = 1024,
            /// <summary>
            /// Quando specificato in input, solo i font con il set di caratteri indicato nel campo <see cref="GraphicsAndMultimedia.GraphicsDeviceInterface.Fonts.FontStructures.LOGFONT.Charset"/> vengono visualizzati.
            /// </summary>
            /// <remarks>All'utente non è permesso cambiare il set di caratteri.</remarks>
            CF_SELECTSCRIPT = 4194304,
            /// <summary>
            /// La finestra di dialogo include il pulsante "Aiuto".
            /// </summary>
            /// <remarks>Deve essere specificata la finestra che riceve la notifica <see cref="CommonDialogBoxesNotifications.HELPMSGSTRING"/>.</remarks>
            CF_SHOWHELP = 4,
            /// <summary>
            /// La finestra di dialogo elenca e permette la selezione solo di font TrueType.
            /// </summary>
            CF_TTONLY = 262144,
            /// <summary>
            /// Indica che dovrebbe usare i dati relativi allo stile forniti per inizializzare il ComboBox "Stile font".
            /// </summary>
            CF_USESTYLE = 128
        }

        /// <summary>
        /// Tipo di font selezionato.
        /// </summary>
        [Flags]
        internal enum FontType : ushort
        {
            /// <summary>
            /// Grassetto.
            /// </summary>
            BOLD_FONTTYPE = 256,
            /// <summary>
            /// Corsivo.
            /// </summary>
            ITALIC_FONTTYPE = 512,
            /// <summary>
            /// Font stampante.
            /// </summary>
            PRINTER_FONTTYPE = 16384,
            /// <summary>
            /// Normale.
            /// </summary>
            REGULAR_FONTTYPE = 1024,
            /// <summary>
            /// Font schermo.
            /// </summary>
            SCREEN_FONTTYPE = 8192,
            /// <summary>
            /// Font simulato da GDI.
            /// </summary>
            SIMULATED_FONTTYPE = 32768
        }

        /// <summary>
        /// Codici di errore per le finestre di dialogo.
        /// </summary>
        internal enum DialogBoxErrorCode
        {
            #region Common Error Codes
            /// <summary>
            /// La finestra di dialogo non è stata creata.
            /// </summary>
            CDERR_DIALOGFAILURE = 65535,
            /// <summary>
            /// Risorsa non trovata.
            /// </summary>
            CDERR_FINDRESFAILURE = 6,
            /// <summary>
            /// Errore durante l'inizializzazione.
            /// </summary>
            CDERR_INITIALIZATION = 2,
            /// <summary>
            /// Errore durante il caricamento di una risorsa.
            /// </summary>
            CDERR_LOADRESFAILURE = 7,
            /// <summary>
            /// Errore durante il caricamento di una stringa.
            /// </summary>
            CDERR_LOADSTRFAILURE = 5,
            /// <summary>
            /// Impossibile bloccare una risorsa.
            /// </summary>
            CDERR_LOCKRESFAILURE = 8,
            /// <summary>
            /// Impossibile allocare la memoria necessaria.
            /// </summary>
            CDERR_MEMALLOCFAILURE = 9,
            /// <summary>
            /// Impossibile bloccare la memoria associata con un handle.
            /// </summary>
            CDERR_MEMLOCKFAILURE = 10,
            /// <summary>
            /// Handle all'istanza non fornito.
            /// </summary>
            CDERR_NOHINSTANCE = 4,
            /// <summary>
            /// Puntatore a procedura di hook non fornito.
            /// </summary>
            CDERR_NOHOOK = 11,
            /// <summary>
            /// Modello non fornito.
            /// </summary>
            CDERR_NOTEMPLATE = 3,
            /// <summary>
            /// Registrazione messaggio fallita.
            /// </summary>
            CDERR_REGISTERMSGFAIL = 12,
            /// <summary>
            /// Il campo che indica la dimensione della struttura non è stato impostato.
            /// </summary>
            CDERR_STRUCTSIZE = 1,
            #endregion
            #region Print Dialog Error Codes
            /// <summary>
            /// Creazione del contesto di informazione non riuscita.
            /// </summary>
            PDERR_CREATEICFAILURE = 4106,
            /// <summary>
            /// 
            /// </summary>
            PDERR_DEFAULTDIFFERENT = 4108,

            PDERR_DNDMMISMATCH = 4105,

            PDERR_GETDEVMODEFAIL = 4101,

            PDERR_INITFAILURE = 4102,

            PDERR_LOADDRVFAILURE = 4100,

            PDERR_NODEFAULTPRN = 4104,

            PDERR_NODEVICES = 4103,

            PDERR_PARSEFAILURE = 4098,

            PDERR_PRINTERNOTFOUND = 4107,

            PDERR_RETDEFFAILURE = 4099,

            PDERR_SETUPFAILURE = 4097
            #endregion
        }
    }
}