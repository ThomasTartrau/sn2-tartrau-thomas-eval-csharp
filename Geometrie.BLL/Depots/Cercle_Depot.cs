using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Geometrie.BLL.Depots
{
    public class Cercle_Depot : IDepot<Cercle>
    {
        //un contexte pour accéder à la base de données
        private GeometrieContext context;

        public Cercle_Depot(GeometrieContext context)
        {
            this.context = context;
        }

        public Cercle Add(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_DAL = element.ToDAL();
            cercle_DAL.DateDeCreation = DateTime.Now;
            context.Cercles.Add(cercle_DAL);
            context.SaveChanges();//déclenche l'insert
            //on récupère l'id généré par la base de données
            element.Id = cercle_DAL.Id;

            return element;
        }

        public IDepot<Cercle> Delete(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IDepot<Cercle> Delete(int Id)
        {
            var cercle_DAL = context.Cercles.Find(Id);
            if (cercle_DAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(Id));

            context.Cercles.Remove(cercle_DAL);
            context.SaveChanges();
            return this;
        }

        public IEnumerable<Cercle> GetAll()
        {
            //avec du LINQ on transforme une IEnumerable<DAL.Point> en IEnumerable<BLL.Point>
            return context.Cercles.Select(c => new Cercle(c.Id.Value, ConvertPointDALToPoint(c.Centre), c.Rayon));
        }

        public Cercle? GetById(int id)
        {
            //le select
            var cercle_DAL = context.Cercles.Find(id);
            //on vérifie si on a trouvé le point
            if (cercle_DAL == null)
                return null;

            return new Cercle(id, ConvertPointDALToPoint(cercle_DAL.Centre), cercle_DAL.Rayon);
        }

        public Cercle Update(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var cercle_DAL = context.Cercles.Find(element.Id);
            if (cercle_DAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(element));

            cercle_DAL.Centre = element.Centre.ToDAL();
            cercle_DAL.Rayon = element.Rayon;
            cercle_DAL.DateDeModification = DateTime.Now;
            context.Update(cercle_DAL);
            context.SaveChanges();

            return element;

        }

        public static Point ConvertPointDALToPoint(Point_DAL point_DAL)
        {
            return point_DAL.Id == null ? new Point(point_DAL.X, point_DAL.Y) : new Point(point_DAL.Id.Value, point_DAL.X, point_DAL.Y);
        }
    }
}
