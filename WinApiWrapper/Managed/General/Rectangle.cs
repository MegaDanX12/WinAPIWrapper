using static WinApiWrapper.General.GeneralStructures;

namespace WinApiWrapper.Managed.General
{
    /// <summary>
    /// Rappresenta un rettangolo.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Coordinata x dell'angolo superiore sinistro del rettangolo.
        /// </summary>
        public int Left { get; }

        /// <summary>
        /// Coordinata y dell'angolo superiore sinistro del rettangolo.
        /// </summary>
        public int Top { get; }

        /// <summary>
        /// Coordinata x dell'angolo inferiore destro del rettangolo.
        /// </summary>
        public int Right { get; }

        /// <summary>
        /// Coordinata y dell'angolo inferiore destro del rettangolo.
        /// </summary>
        public int Bottom { get; }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="Left">Coordinata x dell'angolo superiore sinistro del rettangolo.</param>
        /// <param name="Top">Coordinata y dell'angolo superiore sinistro del rettangolo.</param>
        /// <param name="Right">Coordinata x dell'angolo inferiore destro del rettangolo.</param>
        /// <param name="Bottom">Coordinata y dell'angolo inferiore destro del rettangolo.</param>
        public Rectangle(int Left, int Top, int Right, int Bottom)
        {
            this.Left = Left;
            this.Top = Top;
            this.Right = Right;
            this.Bottom = Bottom;
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="Rect">Struttura <see cref="RECT"/> con i dati necessari.</param>
        internal Rectangle(RECT Rect)
        {
            Left = Rect.Left;
            Top = Rect.Top;
            Right = Rect.Right;
            Bottom = Rect.Bottom;
        }

        /// <summary>
        /// Crea una struttura <see cref="RECT"/> con i dati di questa istanza.
        /// </summary>
        /// <returns>Una struttura <see cref="RECT"/> con gli stessi dati presenti in questa istanza.</returns>
        internal RECT ToRECT()
        {
            RECT Rect = new()
            {
                Left = Left,
                Top = Top,
                Right = Right,
                Bottom = Bottom
            };
            return Rect;
        }
    }
}