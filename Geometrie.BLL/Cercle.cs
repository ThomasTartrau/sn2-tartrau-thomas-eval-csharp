using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Cercle : IForme
    {
        public int? Id { get; set; }
        public Point Centre { get; private set; }
        public double Rayon { get; private set; }

        public Cercle(Point centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }

        public Cercle(int id, Point centre, double rayon)
            : this(centre, rayon)
        {
            Id = id;
        }

        public double CalculerPerimetre() => 2 * Math.PI * Rayon;

        public double CalculerAire() => Math.PI * Math.Pow(Rayon, 2);

        internal DAL.Cercle_DAL ToDAL()
        {
            if (Id == null)
                return new DAL.Cercle_DAL(Centre.ToDAL(), Rayon);
            else
                return new DAL.Cercle_DAL(Id.Value, Centre.ToDAL(), Rayon);
        }
    }
}
