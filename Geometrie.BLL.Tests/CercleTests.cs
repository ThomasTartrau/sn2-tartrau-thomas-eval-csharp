namespace Geometrie.BLL.Tests
{
    public class CercleTests
    {
        //Des TU xUnit pour la classe Point
        [Fact]
        public void Geometrie_BLL_Cercle_Constructor()
        {
            //Arrange
            //Act
            var point = new Point(1, 2);
            var cercle = new Cercle(point, 10.0);

            //Assert
            Assert.Equal(1, cercle.Centre.X);
            Assert.Equal(2, cercle.Centre.Y);
            Assert.Equal(10.0, cercle.Rayon);
        }

        [Fact]
        public void Geometrie_BLL_Cercle_Constructor_With_Id()
        {
            //Arrange
            //Act
            var point = new Point(1, 2);
            var cercle = new Cercle(1, point, 10.0);

            //Assert
            Assert.Equal(1, cercle.Centre.X);
            Assert.Equal(2, cercle.Centre.Y);
            Assert.Equal(10.0, cercle.Rayon);
            Assert.Equal(1, cercle.Id);
        }

        [Fact]
        public void Geometrie_BLL_Cercle_Perimetre()
        {
            //Arrange
            var point = new Point(1, 2);
            var cercle = new Cercle(point, 12.0);

            //Act
            var perimetre = cercle.CalculerPerimetre();

            //Assert
            Assert.Equal(75.39822368615503, perimetre);
        }

        [Fact]
        public void Geometrie_BLL_Cercle_Aire()
        {
            //Arrange
            var point = new Point(1, 2);
            var cercle = new Cercle(point, 12.0);

            //Act
            var aire = cercle.CalculerAire();

            //Assert
            Assert.Equal(452.3893421169302, aire);
        }
    }
}