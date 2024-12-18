using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DAL;
using Geometrie.DTO;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Geometrie.Service
{
    public class Cercle_Service : ICercle_Service
    {
        private GeometrieContext? context;
        private IDepot<Cercle> cercle_depot;
        private IDepot<Point> point_depot;

        public Cercle_Service(IDepot<Cercle> unDepotDeCercle, IDepot<Point> unDepotDePoint)
        {
            ArgumentNullException.ThrowIfNull(unDepotDeCercle);
            ArgumentNullException.ThrowIfNull(unDepotDePoint);

            cercle_depot = unDepotDeCercle;
            point_depot = unDepotDePoint;
        }
        public Cercle_Service(GeometrieContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            this.context = context;
            cercle_depot = new Cercle_Depot(context);
            point_depot = new Point_Depot(context);
        }

        public Cercle_DTO Add(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var point_BLL = new Point(element.Centre.X, element.Centre.Y);
            
            var cercle_BLL = new Cercle(point_BLL, element.Rayon);
            cercle_BLL = cercle_depot.Add(cercle_BLL);
            element.Id = cercle_BLL.Id;

            return element;
        }

        public double CalculerAire(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_BLL = new Cercle(ConvertPointDTOToPointBLL(element.Centre), element.Rayon);
            return cercle_BLL.CalculerAire();
        }

        public IService<Cercle_DTO> Delete(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IService<Cercle_DTO> Delete(int Id)
        {
            cercle_depot.Delete(Id);

            return this;
        }

        public IEnumerable<Cercle_DTO> GetAll()
        {
            return cercle_depot.GetAll().Select(c => new Cercle_DTO()
            {
                Id = c.Id,
                Centre = new Point_DTO() { X = c.Centre.X, Y = c.Centre.Y },
                Rayon = c.Rayon
            });
        }

        public Cercle_DTO? GetById(int id)
        {
            var cercle_BLL = cercle_depot.GetById(id);
            if (cercle_BLL == null)
                return null;

            return new Cercle_DTO() { Id = cercle_BLL.Id, Centre = ConvertPointBLLToPointDTO(cercle_BLL.Centre), Rayon = cercle_BLL.Rayon };
        }

        public Cercle_DTO Update(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));
            ArgumentNullException.ThrowIfNull(element.Centre.Id, nameof(element.Centre.Id));

            var point_BLL = new Point(element.Centre.Id.Value, element.Centre.X, element.Centre.Y);
            var cercle_BLL = new Cercle(point_BLL, element.Rayon);
            
            point_depot.Update(point_BLL);
            cercle_depot.Update(cercle_BLL);

            return element;
        }

        internal Point ConvertPointDTOToPointBLL(Point_DTO point)
        {
            return point.Id == null ? new Point(point.X, point.Y) : new Point(point.Id.Value, point.X, point.Y);
        }

        internal Point_DTO ConvertPointBLLToPointDTO(Point point)
        {
            return point.Id == null ? new Point_DTO() { X = point.X, Y = point.Y } : new Point_DTO() { Id = point.Id, X = point.X, Y = point.Y };
        }
    }
}
