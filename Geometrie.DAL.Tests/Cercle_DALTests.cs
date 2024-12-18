namespace Geometrie.DAL.Tests
{
    public class Cercle_DALTests
    {
        [Fact]
        public void Geometrie_DAL_Cercle_Constructor()
        {
            //on teste le premier constructeur de la classe Centre
            //un test se passe en 3 phases : Arrange, Act, Assert

            //Arrange : initialisation des données
            //ici le Act est fait en même temps (instanciation de la classe)
            var point = new Point_DAL(1, 2);
            var cercle = new Cercle_DAL(point, 3);

            //Assert : vérification des résultats
            Assert.NotNull(cercle.Centre);
            Assert.Equal(1, cercle.Centre.X);
            Assert.Equal(2, cercle.Centre.Y);
            Assert.Equal(3, cercle.Rayon);
        }

        //on teste le 2eme constructeur de la classe Centre
        [Fact]
        public void Geometrie_DAL_Cercle_Constructor_With_Id()
        {
            //Arrange
            var point = new Point_DAL(1, 2);
            var cercle = new Cercle_DAL(1, point, 3);

            //Assert
            Assert.NotNull(cercle.Centre);
            Assert.Equal(1, cercle.Centre.X);
            Assert.Equal(2, cercle.Centre.Y);
            Assert.Equal(3, cercle.Rayon);
            Assert.Equal(1, cercle.Id);
        }

        //fait la même chose mais avec des theory
        [Theory]
        [InlineData(1, 2, 1, 3)]
        [InlineData(4, 5, 8, 6)]
        public void Geometrie_DAL_Cercle_Constructor_With_Id_Theory(int pointX, int pointY, int cercleId, int rayon)
        {
            //Arrange

            //Act
            var point = new Point_DAL(pointX, pointY);
            var cercle = new Cercle_DAL(cercleId, point, rayon);

            //Assert
            Assert.NotNull(cercle.Centre);
            Assert.Equal(pointX, cercle.Centre.X);
            Assert.Equal(pointY, cercle.Centre.Y);
            Assert.Equal(rayon, cercle.Rayon);
            Assert.Equal(cercleId, cercle.Id);
        }
    }
}