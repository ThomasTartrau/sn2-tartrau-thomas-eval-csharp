namespace Geometrie.BLL
{
    /// <summary>
    /// Représente un point dans un espace à deux dimensions.
    /// avec des coordonnées X et Y.
    /// </summary>
    public class Point
    {
        //un champ privé
        private int x;

        /// <summary>
        /// Abscisse du point
        /// </summary>
        //l'accesseur (propriété) pour aller avec le champ
        public int X
        {
            get { return x; }
            private set { x = value; }
        }

        /// <summary>
        /// Ordonnée du point
        /// </summary>
        //la version automatique de la propriété
        public int Y { get; private set; }

        /// <summary>
        /// Constructeur d'un point
        /// </summary>
        /// <param name="x">abscisse du point</param>
        /// <param name="y">ordonnée du point</param>
        public Point(int x, int y)
        {
            X = x; //le this.X est implicite
            Y = y;
        }

        /// <summary>
        /// Calcule la distance entre ce point et un autre.
        /// </summary>
        /// <param name="autre">Un autre <see cref="Point"/></param>
        /// <returns>la distance</returns>
        public double CalculerDistance(Point autre)
        {
            if (autre == null)
                throw new ArgumentNullException(nameof(autre));

            return Math.Sqrt(Math.Pow(X - autre.X, 2) + Math.Pow(Y - autre.Y, 2));
        }

        //public override string ToString()
        //{
        //    return $"({X}, {Y})";
        //}
        //version abrégée
        public override string ToString() => $"({X}, {Y})";
        ///"(" + X + ", " + Y + ")";
        ///

        //on implémente l'opérateur ==
        public static bool operator ==(Point p1, Point p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Point p1, Point p2) => !(p1 == p2);

    }
}