using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DAL;
using Geometrie.DTO;

namespace Geometrie.Service
{
    public class Point_Service : IService<Point_DTO>
    {
        private GeometrieContext context;
        private Point_Depot depot;

        public Point_Service(GeometrieContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            this.context = context;
            depot = new Point_Depot(context);
        }

        public Point_DTO Add(Point_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var point_BLL= new Point(element.X, element.Y);
            depot.Add(point_BLL);
            element.Id = point_BLL.Id;

            return element;
        }

        public IService<Point_DTO> Delete(Point_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IService<Point_DTO> Delete(int Id)
        {
            depot.Delete(Id);

            return this;
        }

        public IEnumerable<Point_DTO> GetAll()
        {
            return depot.GetAll().Select(p=>new Point_DTO() { Id = p.Id, X = p.X, Y = p.Y });
        }

        public Point_DTO? GetById(int id)
        {
            var point_BLL = depot.GetById(id);
            if (point_BLL == null)
                return null;

            return new Point_DTO() { Id = point_BLL.Id, X = point_BLL.X, Y = point_BLL.Y };
        }

        public Point_DTO Update(Point_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var point_BLL = new Point(element.Id.Value, element.X, element.Y);
            depot.Update(point_BLL);

            return element;
        }
    }
}
