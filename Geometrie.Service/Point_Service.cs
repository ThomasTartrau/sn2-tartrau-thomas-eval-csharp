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
            throw new NotImplementedException();
        }

        public IService<Point_DTO> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Point_DTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Point_DTO? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Point_DTO Update(Point_DTO element)
        {
            throw new NotImplementedException();
        }
    }
}
