namespace Geometrie.DAL.Tests
{
    public class PointTests
    {
        [Fact]
        public void Geometrie_DAL_Point_Constructor()
        {
            //on teste le premier constructeur de la classe Point
            //un test se passe en 3 phases : Arrange, Act, Assert

            //Arrange : initialisation des données
            //ici le Act est fait en même temps (instanciation de la classe)
            var point = new Point(1, 2, new DateTime(2021, 11, 12));

            //Assert : vérification des résultats
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
            Assert.Equal(new DateTime(2021, 11, 12), point.DateDeCreation);
        }

        //on teste le 2eme constructeur de la classe Point
        [Fact]
        public void Geometrie_DAL_Point_Constructor_With_Id()
        {
            //Arrange
            var point = new Point(1, 2, 3, new DateTime(2021, 11, 12), new DateTime(2021, 11, 13), null);

            //Assert
            Assert.Equal(1, point.Id);
            Assert.Equal(2, point.X);
            Assert.Equal(3, point.Y);
            Assert.Equal(new DateTime(2021, 11, 12), point.DateDeCreation);
            Assert.Equal(new DateTime(2021, 11, 13), point.DateDeModification);
            Assert.Null(point.Polygone);
        }

        //fait la même chose mais avec des theory
        [Theory]
        [InlineData(1, 2, 3, "2021-11-12", "2021-11-13")]
        [InlineData(4, 5, 6, "2021-11-14", "2021-11-15")]
        public void Geometrie_DAL_Point_Constructor_With_Id_Theory(int id, int x, int y, string dateDeCreation, string dateDeModification)
        {
            //Arrange
            var polygone = new Polygone();

            //Act
            var point = new Point(id, x, y, DateTime.Parse(dateDeCreation), DateTime.Parse(dateDeModification), polygone);
            
            //Assert
            Assert.Equal(id, point.Id);
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
            Assert.Equal(DateTime.Parse(dateDeCreation), point.DateDeCreation);
            Assert.Equal(DateTime.Parse(dateDeModification), point.DateDeModification);
            Assert.Equal(polygone, point.Polygone);
        }
    }
}