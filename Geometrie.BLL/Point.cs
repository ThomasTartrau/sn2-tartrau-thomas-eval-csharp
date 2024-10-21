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
            return System.Math.Sqrt(System.Math.Pow(X - autre.X, 2) + System.Math.Pow(Y - autre.Y, 2));
        }
    }
}
