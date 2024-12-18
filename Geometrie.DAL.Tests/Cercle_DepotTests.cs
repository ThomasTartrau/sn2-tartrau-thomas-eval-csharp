using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL.Tests
{
    public class Cercle_DepotTests
    {
        //on teste la classe Point_Depot en entier
        //on va tester les méthodes Add, Delete, GetAll, GetById, Update
        //on va tester les cas normaux et les cas d'erreurs
        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Add()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                //arrange
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3.0);

                //Act
                var result = depot.Add(cercle);

                //Assert
                Assert.NotNull(result);
                Assert.NotNull(result.Id);
                Assert.NotNull(result.Centre);
                Assert.Equal(1, result.Centre.X);
                Assert.Equal(2, result.Centre.Y);
                Assert.Equal(3, result.Rayon);
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Add_ArgumentNullException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Add(null));
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Delete()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3);
                depot.Add(cercle);

                //Act
                var result=depot.Delete(cercle);

                //Assert
                Assert.Same(depot, result);
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Delete_ArgumentNullException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Delete(null));
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Delete_ArgumentNullException_Id()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Delete(cercle));
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Delete_ArgumentException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentException>(() => depot.Delete(0));
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_GetAll()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3);

                depot.Add(cercle);

                //Act
                var result = depot.GetAll();

                //Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Contains(result, c => c.Centre.X == 1 && c.Centre.Y == 2 && c.Rayon == 3);
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_GetById()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3);
                var addCercle = depot.Add(cercle);

                //Act
                var result = depot.GetById(addCercle.Id.Value);

                //Assert
                Assert.NotNull(result);
                Assert.NotNull(result.Id);
                Assert.NotNull(result.Centre);
                Assert.Equal(1, result.Centre.X);
                Assert.Equal(2, result.Centre.Y);
                Assert.Equal(3, result.Rayon);
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Update()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3);
                var addedCercle = depot.Add(cercle);
                
                var updatedCercle = new Cercle(addedCercle.Id.Value, new Point(3, 4), 4);
                
                //Act
                var result = depot.Update(updatedCercle);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(addedCercle.Id, result.Id);
                Assert.NotNull(result.Centre);
                Assert.Equal(3, result.Centre.X);
                Assert.Equal(4, result.Centre.Y);
                Assert.Equal(4, result.Rayon);
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Update_ArgumentNullException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Update(null));
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Update_ArgumentNullException_Id()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(point, 3);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Update(cercle));
            }
        }

        [Fact]
        public void Geometrie_DAL_Cercle_Depot_Update_ArgumentException_Id()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Cercle_Depot(context);
                var point = new Point(1, 2);
                var cercle = new Cercle(int.MaxValue, point, 2); //on met un id qui n'existe pas (le dernier possible dans la BDD)

                //Act & Assert
                Assert.Throws<ArgumentException>(() => depot.Update(cercle));
            }
        }
    }
}
