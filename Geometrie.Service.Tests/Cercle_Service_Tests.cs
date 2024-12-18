using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DTO;
using Moq;

namespace Geometrie.Service.Tests
{
    public class Cercle_Service_Tests
    {
        [Fact]
        public void Cercle_Service_Constructeur()
        {
            //arrange
            var depot = new Moq.Mock<IDepot<Cercle>>().Object;
            var depotPoint = new Moq.Mock<IDepot<Point>>().Object;
            var service = new Cercle_Service(depot, depotPoint);

            //assert
            Assert.NotNull(service);
        }

        //méthode Add
        [Fact]
        public void Cercle_Service_Add()
        {
            //arrange
            //dans les tests unitaires, on ne teste pas la couche d'en dessous
            //on va la simuler avec un Moq
            //avec ce Moq je fais un "faux objet" depot
            //je n'utilise pas vraiment la couche BLL
            var depot = new Mock<IDepot<Cercle>>();
            var depotPoint = new Mock<IDepot<Point>>();
            //je paramètre une fausse méthode Add pour mon faux dépot
            //la fausse méthode imite la vraie : elle prend un Point en paramètre et retourne un Point
            depot.Setup(d => d.Add(It.IsAny<Cercle>())).Returns(new Cercle(1, new Point(1, 2, 3), 3));
            depotPoint.Setup(d => d.Add(It.IsAny<Point>())).Returns(new Point(1, 2, 3));
            //je peux créer mon service avec le faux objet
            var service = new Cercle_Service(depot.Object, depotPoint.Object);

            var cercle = new Cercle_DTO() { Centre = new Point_DTO() { Id = 1, X = 2, Y = 3}, Rayon = 3 };

            //act
            var result = service.Add(cercle);

            //assert
            //je vérifie le résulat
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(1, result.Centre.Id);
            Assert.Equal(2, result.Centre.X);
            Assert.Equal(3, result.Centre.Y);
            Assert.Equal(3, result.Rayon);
            //et avec Moq, je peux vérifier qu'il a bien appelé la méthode Add du dépot
            //une fois et une seule
            depot.Verify(d => d.Add(It.IsAny<Cercle>()), Times.Once);
            depotPoint.Verify(d => d.Add(It.IsAny<Point>()), Times.Once);
        }

        //méthode Delete
        [Fact]
        public void Cercle_Service_Delete()
        {
            //arrange
            var depot = new Mock<IDepot<Cercle>>();
            depot.Setup(d => d.Delete(It.IsAny<int>())).Returns(depot.Object);
            var depotPoint = new Mock<IDepot<Point>>();
            var service = new Cercle_Service(depot.Object, depotPoint.Object);

            var cercle = new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { X = 1, Y = 2 }, Rayon = 3 };

            //act
            var result = service.Delete(cercle);

            //assert
            Assert.NotNull(result);
            depot.Verify(d => d.Delete(It.IsAny<int>()), Times.Once);
        }

        //méthode delete avec un int
        [Fact]
        public void Cercle_Service_Delete_Id()
        {
            //arrange
            var depot = new Mock<IDepot<Cercle>>();
            depot.Setup(d => d.Delete(It.IsAny<int>())).Returns(depot.Object);
            var depotPoint = new Mock<IDepot<Point>>();
            depotPoint.Setup(d => d.Delete(It.IsAny<int>())).Returns(depotPoint.Object);
            var service = new Cercle_Service(depot.Object, depotPoint.Object);

            //act
            var result = service.Delete(1);

            //assert
            Assert.NotNull(result);
            depot.Verify(d => d.Delete(It.IsAny<int>()), Times.Once);
            depotPoint.Verify(d => d.Delete(It.IsAny<int>()), Times.Never);
        }

        //update
        [Fact]
        public void Cercle_Service_Update()
        {
            //arrange
            var depot = new Mock<IDepot<Cercle>>();
            depot.Setup(d => d.Update(It.IsAny<Cercle>())).Returns(new Cercle(1, new Point(9, 1, 2), 3));
            var depotPoint = new Mock<IDepot<Point>>();
            depotPoint.Setup(depotPoint => depotPoint.Update(It.IsAny<Point>())).Returns(new Point(9, 1, 2));
            var service = new Cercle_Service(depot.Object, depotPoint.Object);

            var point = new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 9, X = 1, Y = 2 }, Rayon = 3 };

            //act
            var result = service.Update(point);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(9, result.Centre.Id);
            Assert.Equal(1, result.Centre.X);
            Assert.Equal(2, result.Centre.Y);
            Assert.Equal(3, result.Rayon);
            depot.Verify(d => d.Update(It.IsAny<Cercle>()), Times.Once);
            depotPoint.Verify(d => d.Update(It.IsAny<Point>()), Times.Once);
        }
        [Fact]
        public void Cercle_Service_GetAll()
        {
            //arrange
            var depot = new Mock<IDepot<Cercle>>();
            depot.Setup(d => d.GetAll()).Returns(new List<Cercle>() { new Cercle(1, new Point(2, 3), 4), new Cercle(5, new Point(6, 7), 8) });
            var depotPoint = new Mock<IDepot<Point>>();
            var service = new Cercle_Service(depot.Object, depotPoint.Object);

            //act
            var result = service.GetAll();

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(2, result.ElementAt(0).Centre.X);
            Assert.Equal(3, result.ElementAt(0).Centre.Y);
            Assert.Equal(4, result.ElementAt(0).Rayon);
            Assert.Equal(5, result.ElementAt(1).Id);
            Assert.Equal(6, result.ElementAt(1).Centre.X);
            Assert.Equal(7, result.ElementAt(1).Centre.Y);
            Assert.Equal(8, result.ElementAt(1).Rayon);
            depot.Verify(d => d.GetAll(), Times.Once);
        }
        [Fact]
        public void Cercle_Service_GetById()
        {
            //arrange
            var depot = new Mock<IDepot<Cercle>>();
            depot.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Cercle(1, new Point(2, 3), 4));
            var depotPoint = new Mock<IDepot<Point>>();
            var service = new Cercle_Service(depot.Object, depotPoint.Object);

            //act
            var result = service.GetById(1);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.Centre.X);
            Assert.Equal(3, result.Centre.Y);
            Assert.Equal(4, result.Rayon);
            depot.Verify(d => d.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}