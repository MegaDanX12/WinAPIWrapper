namespace WinApiWrapper.UserInputAndMessaging.LegacyUserInteraction.KeyboardInput
{
    /// <summary>
    /// Enumerazioni input tastiera.
    /// </summary>
    internal static class KeyboardInputEnumerations
    {
        /// <summary>
        /// Codici virtuali dei tasti usati dal sistema.
        /// </summary>
        internal enum VirtualKeyCodes
        {
            /// <summary>
            /// Tasto sinistro del mouse.
            /// </summary>
            VK_LBUTTON = 1,
            /// <summary>
            /// Tasto destro del mouse.
            /// </summary>
            VK_RBUTTON,
            /// <summary>
            /// Tasto Canc.
            /// </summary>
            VK_CANCEL,
            /// <summary>
            /// Tasto centrale del mouse.
            /// </summary>
            VK_MBUTTON,
            /// <summary>
            /// Pulsante X1 del mouse.
            /// </summary>
            VK_XBUTTON1,
            /// <summary>
            /// Pulsante X2 del mouse.
            /// </summary>
            VK_XBUTTON2,
            /// <summary>
            /// Tasto backspace.
            /// </summary>
            VK_BACK = 8,
            /// <summary>
            /// Tasto TAB.
            /// </summary>
            VK_TAB,
            /// <summary>
            /// Tasto CLEAR.
            /// </summary>
            VK_CLEAR = 12,
            /// <summary>
            /// Tasto Invio.
            /// </summary>
            VK_RETURN,
            /// <summary>
            /// Tasto SHIFT.
            /// </summary>
            VK_SHIFT = 16,
            /// <summary>
            /// Tasto CTRL.
            /// </summary>
            VK_CONTROL,
            /// <summary>
            /// Tasto ALT.
            /// </summary>
            VK_MENU,
            /// <summary>
            /// Tasto PAUSE.
            /// </summary>
            VK_PAUSE,
            /// <summary>
            /// Tasto CAPS LOCK.
            /// </summary>
            VK_CAPITAL,
            /// <summary>
            /// Modalità IME Kana.
            /// </summary>
            VK_KANA,
            /// <summary>
            /// Modalità IME Hanguel.
            /// </summary>
            VK_HANGUEL = VK_KANA,
            /// <summary>
            /// Modalità IME Hangul.
            /// </summary>
            VK_HANGUL = VK_KANA,
            /// <summary>
            /// IME On.
            /// </summary>
            VK_IME_ON,
            /// <summary>
            /// Modalità IME Junja.
            /// </summary>
            VK_JUNJA,
            /// <summary>
            /// Modalità finale IME.
            /// </summary>
            VK_FINAL,
            /// <summary>
            /// Modalità IME Hanja.
            /// </summary>
            VK_HANJA,
            /// <summary>
            /// Modalità IME Kanji.
            /// </summary>
            VK_KANJI = VK_HANJA,
            /// <summary>
            /// IME Off.
            /// </summary>
            VK_IME_OFF,
            /// <summary>
            /// Tasto ESC.
            /// </summary>
            VK_ESCAPE,
            /// <summary>
            /// IME convert.
            /// </summary>
            VK_CONVERT,
            /// <summary>
            /// IME nonconvert.
            /// </summary>
            VK_NONCONVERT,
            /// <summary>
            /// IME accept.
            /// </summary>
            VK_ACCEPT,
            /// <summary>
            /// Richiesta di cambio modalità IME.
            /// </summary>
            VK_MODECHANGE,
            /// <summary>
            /// Barra spaziatrice.
            /// </summary>
            VK_SPACE,
            /// <summary>
            /// Tasto PAGE UP.
            /// </summary>
            VK_PRIOR,
            /// <summary>
            /// Tasto PAGE DOWN.
            /// </summary>
            VK_NEXT,
            /// <summary>
            /// Tasto Fine.
            /// </summary>
            VK_END,
            /// <summary>
            /// Tasto Inizio.
            /// </summary>
            VK_HOME,
            /// <summary>
            /// Freccia sinistra.
            /// </summary>
            VK_LEFT,
            /// <summary>
            /// Frecca su.
            /// </summary>
            VK_UP,
            /// <summary>
            /// Freccia destra.
            /// </summary>
            VK_RIGHT,
            /// <summary>
            /// Freccia verso il basso.
            /// </summary>
            VK_DOWN,
            /// <summary>
            /// Tasto SELECT.
            /// </summary>
            VK_SELECT,
            /// <summary>
            /// Tasto PRINT.
            /// </summary>
            VK_PRINT,
            /// <summary>
            /// Tasto EXECUTE.
            /// </summary>
            VK_EXECUTE,
            /// <summary>
            /// Tasto STAMP.
            /// </summary>
            VK_SNAPSHOT,
            /// <summary>
            /// Tasto INS.
            /// </summary>
            VK_INSERT,
            /// <summary>
            /// Tasto Canc.
            /// </summary>
            VK_DELETE,
            /// <summary>
            /// Tasto HELP.
            /// </summary>
            VK_HELP,
            /// <summary>
            /// 0.
            /// </summary>
            NUMBER0,
            /// <summary>
            /// 1.
            /// </summary>
            NUMBER1,
            /// <summary>
            /// 2.
            /// </summary>
            NUMBER2,
            /// <summary>
            /// 3.
            /// </summary>
            NUMBER3,
            /// <summary>
            /// 4.
            /// </summary>
            NUMBER4,
            /// <summary>
            /// 5.
            /// </summary>
            NUMBER5,
            /// <summary>
            /// 6.
            /// </summary>
            NUMBER6,
            /// <summary>
            /// 7.
            /// </summary>
            NUMBER7,
            /// <summary>
            /// 8.
            /// </summary>
            NUMBER8,
            /// <summary>
            /// 9.
            /// </summary>
            NUMBER9,
            /// <summary>
            /// A.
            /// </summary>
            A = 65,
            /// <summary>
            /// B.
            /// </summary>
            B,
            /// <summary>
            /// C.
            /// </summary>
            C,
            /// <summary>
            /// D.
            /// </summary>
            D,
            /// <summary>
            /// E.
            /// </summary>
            E,
            /// <summary>
            /// F.
            /// </summary>
            F,
            /// <summary>
            /// G.
            /// </summary>
            G,
            /// <summary>
            /// H.
            /// </summary>
            H,
            /// <summary>
            /// I.
            /// </summary>
            I,
            /// <summary>
            /// J.
            /// </summary>
            J,
            /// <summary>
            /// K.
            /// </summary>
            K,
            /// <summary>
            /// L.
            /// </summary>
            L,
            /// <summary>
            /// M.
            /// </summary>
            M,
            /// <summary>
            /// N.
            /// </summary>
            N,
            /// <summary>
            /// O.
            /// </summary>
            O,
            /// <summary>
            /// P.
            /// </summary>
            P,
            /// <summary>
            /// Q.
            /// </summary>
            Q,
            /// <summary>
            /// R.
            /// </summary>
            R,
            /// <summary>
            /// S.
            /// </summary>
            S,
            /// <summary>
            /// T.
            /// </summary>
            T,
            /// <summary>
            /// U.
            /// </summary>
            U,
            /// <summary>
            /// V.
            /// </summary>
            V,
            /// <summary>
            /// W.
            /// </summary>
            W,
            /// <summary>
            /// X.
            /// </summary>
            X,
            /// <summary>
            /// Y.
            /// </summary>
            Y,
            /// <summary>
            /// Z.
            /// </summary>
            Z,
            /// <summary>
            /// Tasto Windows sinistro.
            /// </summary>
            VK_LWIN,
            /// <summary>
            /// Tasto Windows destro.
            /// </summary>
            VK_RWIN,
            /// <summary>
            /// Tasto applicazioni.
            /// </summary>
            VK_APPS,
            /// <summary>
            /// Tasto sospensione computer.
            /// </summary>
            VK_SLEEP = 95,
            /// <summary>
            /// 0 (tastierino).
            /// </summary>
            VK_NUMPAD0,
            /// <summary>
            /// 1 (tastierino).
            /// </summary>
            VK_NUMPAD1,
            /// <summary>
            /// 2 (tastierino).
            /// </summary>
            VK_NUMPAD2,
            /// <summary>
            /// 3 (tastierino).
            /// </summary>
            VK_NUMPAD3,
            /// <summary>
            /// 4 (tastierino).
            /// </summary>
            VK_NUMPAD4,
            /// <summary>
            /// 5 (tastierino).
            /// </summary>
            VK_NUMPAD5,
            /// <summary>
            /// 6 (tastierino).
            /// </summary>
            VK_NUMPAD6,
            /// <summary>
            /// 7 (tastierino).
            /// </summary>
            VK_NUMPAD7,
            /// <summary>
            /// 8 (tastierino).
            /// </summary>
            VK_NUMPAD8,
            /// <summary>
            /// 9 (tastierino).
            /// </summary>
            VK_NUMPAD9,
            /// <summary>
            /// Tasto * (tastierino).
            /// </summary>
            VK_MULTIPLY,
            /// <summary>
            /// Tasto + (tastierino).
            /// </summary>
            VK_ADD,
            /// <summary>
            /// Tasto / (tastierino).
            /// </summary>
            VK_SEPARATOR,
            /// <summary>
            /// Tasto - (tastierino).
            /// </summary>
            VK_SUBTRACT,
            /// <summary>
            /// Tasto punto decimale (.) (tastierino).
            /// </summary>
            VK_DECIMAL,
            /// <summary>
            /// Tasto divisione (tastierino).
            /// </summary>
            VK_DIVIDE,
            /// <summary>
            /// F1.
            /// </summary>
            VK_F1,
            /// <summary>
            /// F2.
            /// </summary>
            VK_F2,
            /// <summary>
            /// F3.
            /// </summary>
            VK_F3,
            /// <summary>
            /// F4.
            /// </summary>
            VK_F4,
            /// <summary>
            /// F5.
            /// </summary>
            VK_F5,
            /// <summary>
            /// F6.
            /// </summary>
            VK_F6,
            /// <summary>
            /// F7.
            /// </summary>
            VK_F7,
            /// <summary>
            /// F8.
            /// </summary>
            VK_F8,
            /// <summary>
            /// F9.
            /// </summary>
            VK_F9,
            /// <summary>
            /// F10.
            /// </summary>
            VK_F10,
            /// <summary>
            /// F11.
            /// </summary>
            VK_F11,
            /// <summary>
            /// F12.
            /// </summary>
            VK_F12,
            /// <summary>
            /// F13.
            /// </summary>
            VK_F13,
            /// <summary>
            /// F14.
            /// </summary>
            VK_F14,
            /// <summary>
            /// F15.
            /// </summary>
            VK_F15,
            /// <summary>
            /// F16.
            /// </summary>
            VK_F16,
            /// <summary>
            /// F17.
            /// </summary>
            VK_F17,
            /// <summary>
            /// F18.
            /// </summary>
            VK_F18,
            /// <summary>
            /// F19.
            /// </summary>
            VK_F19,
            /// <summary>
            /// F20.
            /// </summary>
            VK_F20,
            /// <summary>
            /// F21.
            /// </summary>
            VK_F21,
            /// <summary>
            /// F22.
            /// </summary>
            VK_F22,
            /// <summary>
            /// F23.
            /// </summary>
            VK_F23,
            /// <summary>
            /// F24.
            /// </summary>
            VK_F24,
            /// <summary>
            /// Tasto Bloc Num (tastierino).
            /// </summary>
            VK_NUMLOCK = 144,
            /// <summary>
            /// Tasto Bloc Scorr.
            /// </summary>
            VK_SCROLL,
            /// <summary>
            /// Tasto SHIFT sinistro.
            /// </summary>
            VK_LSHIFT = 160,
            /// <summary>
            /// Tasto SHIFT destro.
            /// </summary>
            VK_RSHIFT,
            /// <summary>
            /// Tasto CTRL sinistro.
            /// </summary>
            VK_LCONTROL,
            /// <summary>
            /// Tasto CTRL destro.
            /// </summary>
            VK_RCONTROL,
            /// <summary>
            /// Tasto ALT sinistro.
            /// </summary>
            VK_LMENU,
            /// <summary>
            /// Tasto ALT destro.
            /// </summary>
            VK_RMENU,
            /// <summary>
            /// Tasto browser indietro.
            /// </summary>
            VK_BROWSER_BACK,
            /// <summary>
            /// Tasto browser avanti.
            /// </summary>
            VK_BROWSER_FORWARD,
            /// <summary>
            /// Tasto browser aggiorna.
            /// </summary>
            VK_BROWSER_REFRESH,
            /// <summary>
            /// Tasto browser interrompi.
            /// </summary>
            VK_BROWSER_STOP,
            /// <summary>
            /// Tasto browser cerca.
            /// </summary>
            VK_BROWSER_SEARCH,
            /// <summary>
            /// Tasto browser preferiti.
            /// </summary>
            VK_BROWSER_FAVORITES,
            /// <summary>
            /// Tasto browser home page.
            /// </summary>
            VK_BROWSER_HOME,
            /// <summary>
            /// Tasto volume muto.
            /// </summary>
            VK_VOLUME_MUTE,
            /// <summary>
            /// Tasto abbasssa volume.
            /// </summary>
            VK_VOLUME_DOWN,
            /// <summary>
            /// Tasto alza volume.
            /// </summary>
            VK_VOLUME_UP,
            /// <summary>
            /// Tasto prossima traccia.
            /// </summary>
            VK_MEDIA_NEXT_TRACK,
            /// <summary>
            /// Tasto traccia precedente.
            /// </summary>
            VK_MEDIA_PREV_TRACK,
            /// <summary>
            /// Tasto arresta riproduzione.
            /// </summary>
            VK_MEDIA_STOP,
            /// <summary>
            /// Tasto pausa/riprendi riproduzione.
            /// </summary>
            VK_MEDIA_PLAY_PAUSE,
            /// <summary>
            /// Tasto avvia Mail.
            /// </summary>
            VK_LAUNCH_MAIL,
            /// <summary>
            /// Tasto avvia riproduttore multimediale.
            /// </summary>
            VK_LAUNCH_MEDIA_SELECT,
            /// <summary>
            /// Tasto avvio applicazione 1.
            /// </summary>
            VK_LAUNCH_APP1,
            /// <summary>
            /// Tasto avvio applicazione 2.
            /// </summary>
            VK_LAUNCH_APP2,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_1 = 186,
            /// <summary>
            /// Tasto +.
            /// </summary>
            VK_OEM_PLUS,
            /// <summary>
            /// Tasto virgola (,).
            /// </summary>
            VK_OEM_COMMA,
            /// <summary>
            /// Tasto -.
            /// </summary>
            VK_OEM_MINUS,
            /// <summary>
            /// Tasto punto (.).
            /// </summary>
            VK_OEM_PERIOD,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_2,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_3,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_4 = 219,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_5,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_6,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_7,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_8,
            /// <summary>
            /// 
            /// </summary>
            VK_OEM_102 = 226,
            /// <summary>
            /// Tasto processe IME.
            /// </summary>
            VK_PROCESSKEY = 229,
            /// <summary>
            /// Usato per passare caratteri Unicode come se fossero tasti.
            /// </summary>
            /// <remarks>Questo valore si trova nei ultimi due byte di un codice tasto virtuale a 32 bit.</remarks>
            VK_PACKET = 231,
            /// <summary>
            /// Tato Attn.
            /// </summary>
            VK_ATTN = 246,
            /// <summary>
            /// Tasto Crsel.
            /// </summary>
            VK_CRSEL,
            /// <summary>
            /// Tasto Exsel.
            /// </summary>
            VK_EXSEL,
            /// <summary>
            /// Tasto cancellazione EOF.
            /// </summary>
            VK_EREOF,
            /// <summary>
            /// Tasto Play.
            /// </summary>
            VK_PLAY,
            /// <summary>
            /// Tasto Zoom.
            /// </summary>
            VK_ZOOM,
            /// <summary>
            /// Riservato.
            /// </summary>
            VK_NONAME,
            /// <summary>
            /// Tasto PA1.
            /// </summary>
            VK_PA1,
            /// <summary>
            /// Tasto Clear.
            /// </summary>
            VK_OEM_CLEAR
        }
    }
}