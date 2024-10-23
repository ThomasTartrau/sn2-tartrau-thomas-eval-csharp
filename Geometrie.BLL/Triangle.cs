using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Triangle : Polygone
    {
        public Triangle(Point a, Point b, Point c) 
            : base(a, b, c)
        {
            //je calcule la taille de tous les côtés
            var cotes = new List<double>()
            {
                a.CalculerDistance(b), b.CalculerDistance(c), c.CalculerDistance(a)
            };
            //je les trie
            cotes.Sort();

            //si le plus grand est égale à la somme des 2 autres
            if (cotes[2] <= cotes[0] + cotes[1])
                throw new ArgumentException("Les points sont alignés");

        }

        public override double CalculerAire()
        {
            //Formule de Héron
            double p = CalculerPerimetre() / 2;
            double a = this[0].CalculerDistance(this[1]);
            double b = this[1].CalculerDistance(this[2]);
            double c = this[2].CalculerDistance(this[0]);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
