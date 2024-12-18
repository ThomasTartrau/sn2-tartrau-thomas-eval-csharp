using Geometrie.API.Controllers;
using Geometrie.DTO;
using Moq;

namespace Geometrie.API.Tests
{
    public class Cercle_Controller_Tests
    {
        //on test le constructeur et toutes les méthodes de Point_Controller en Moq de IPoint_Service
        [Fact]
        public void Cercle_Controller_Constructeur()
        {
            //arrange
            var service = new Mock<ICercle_Service>().Object;
            var controller = new Cercle_Controller(service);

            //assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void Cercle_Controller_Add()
        {
            //arrange
            var service = new Mock<ICercle_Service>();
            service.Setup(s => s.Add(It.IsAny<Cercle_DTO>())).Returns(new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 });
            var controller = new Cercle_Controller(service.Object);

            var cercle = new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 };

            //act
            var result = controller.Add(cercle);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.Centre.Id);
            Assert.Equal(3, result.Centre.X);
            Assert.Equal(4, result.Centre.Y);
            Assert.Equal(5, result.Rayon);
            service.Verify(s => s.Add(It.IsAny<Cercle_DTO>()), Times.Once);
        }

        [Fact]
        public void Cercle_Controller_DeleteObject()
        {
            //arrange
            var service = new Mock<ICercle_Service>();
            service.Setup(s => s.Delete(It.IsAny<Cercle_DTO>())).Returns(service.Object);
            var controller = new Cercle_Controller(service.Object);

            var cercle = new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 };

            //act
            var result = controller.Delete(cercle);

            //assert
            Assert.NotNull(result);
            service.Verify(s => s.Delete(It.IsAny<Cercle_DTO>()), Times.Once);
        }

        [Fact]
        public void Cercle_Controller_DeleteById()
        {
            //arrange
            var service = new Mock<ICercle_Service>();
            service.Setup(s => s.Delete(It.IsAny<int>())).Returns(service.Object);
            var controller = new Cercle_Controller(service.Object);

            //act
            var result = controller.Delete(1);

            //assert
            Assert.NotNull(result);
            service.Verify(s => s.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Cercle_Controller_GetAll()
        {
            //arrange
            var service = new Mock<ICercle_Service>();
            service.Setup(s => s.GetAll()).Returns(new List<Cercle_DTO>() { new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 }, new Cercle_DTO() { Id = 6, Centre = new Point_DTO() { Id = 7, X = 8, Y = 9 }, Rayon = 10 } });
            var controller = new Cercle_Controller(service.Object);

            //act
            var result = controller.GetAll();

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            /*Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(2, result.ElementAt(0).X);
            Assert.Equal(3, result.ElementAt(0).Y);
            Assert.Equal(4, result.ElementAt(1).Id);
            Assert.Equal(5, result.ElementAt(1).X);
            Assert.Equal(6, result.ElementAt(1).Y);*/
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(2, result.ElementAt(0).Centre.Id);
            Assert.Equal(3, result.ElementAt(0).Centre.X);
            Assert.Equal(4, result.ElementAt(0).Centre.Y);
            Assert.Equal(5, result.ElementAt(0).Rayon);
            Assert.Equal(6, result.ElementAt(1).Id);
            Assert.Equal(7, result.ElementAt(1).Centre.Id);
            Assert.Equal(8, result.ElementAt(1).Centre.X);
            Assert.Equal(9, result.ElementAt(1).Centre.Y);
            Assert.Equal(10, result.ElementAt(1).Rayon);

            service.Verify(s => s.GetAll(), Times.Once);
        }

        [Fact]
        public void Cercle_Controller_GetById()
        {
            //arrange
            var service = new Mock<ICercle_Service>();
            service.Setup(s => s.GetById(It.IsAny<int>())).Returns(new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 });
            var controller = new Cercle_Controller(service.Object);

            //act
            var result = controller.GetById(1);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.Centre.Id);
            Assert.Equal(3, result.Centre.X);
            Assert.Equal(4, result.Centre.Y);
            Assert.Equal(5, result.Rayon);

            service.Verify(s => s.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Cercle_Controller_Update()
        {
            //arrange
            var service = new Mock<ICercle_Service>();
            service.Setup(s => s.Update(It.IsAny<Cercle_DTO>())).Returns(new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 });
            var controller = new Cercle_Controller(service.Object);

            var cercle = new Cercle_DTO() { Id = 1, Centre = new Point_DTO() { Id = 2, X = 3, Y = 4 }, Rayon = 5 };

            //act
            var result = controller.Update(cercle);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.Centre.Id);
            Assert.Equal(3, result.Centre.X);
            Assert.Equal(4, result.Centre.Y);
            Assert.Equal(5, result.Rayon);

            service.Verify(s => s.Update(It.IsAny<Cercle_DTO>()), Times.Once);
        }
    }
}