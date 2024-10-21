using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Polygone
    {
        private ArrayList lesPoints;

        //indexeur
        public Point this[int index]
        {
            get
            {
                return (Point)lesPoints[index];
            }
            set
            {
                lesPoints[index] = value;
            }
        }


        //public int Count
        //{
        //    get
        //    {
        //        return lesPoints.Count;
        //    }
        //}
        /// <summary>
        /// Nombre de points du polygone
        /// </summary>
        //version abrégée
        public int Count => lesPoints.Count;

        /// <summary>
        /// Contructeur d'un polygone
        /// </summary>
        /// <param name="a">1er point</param>
        /// <param name="b">2eme point</param>
        /// <param name="c">3ème point</param>
        /// <param name="autresPoints">Autres points</param>
        /// <exception cref="ArgumentNullException">si un des 3 points obligatoires est null</exception>
        public Polygone(Point a, Point b, Point c, params Point[]? autresPoints)
        {
            if(a == null || b == null || c == null)
                throw new ArgumentNullException();

            lesPoints = new ArrayList();
            lesPoints.Add(a);
            lesPoints.Add(b);
            lesPoints.Add(c);
            if(autresPoints != null)
                lesPoints.AddRange(autresPoints);
        }
    }
}
