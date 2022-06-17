

using CarWash.Database;
using CarWash.Database.Models;
using CarWash.Database.Repositories;
using CarWash.Database.Repositories.Holders;
using CarWash.Database.Repositories.Interfaces;
using CarWash.MVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CasrWash.Tests
{
    [TestClass]
    public class BrandsControllerTests
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Brand>>();

            var mockContext = new Mock<DataContext>(new DbContextOptions<DataContext>());
            mockContext.SetupGet(x => x.Brands).Returns(mockSet.Object);

            var mockRepository = new Mock<BrandRepository>(mockContext.Object);

            var mockRepsHolder = new Mock<IRepositoriesHolder>();
            mockRepsHolder.SetupGet(x => x.BrandRepository).Returns(mockRepository.Object);

            BrandsController brandsController = new BrandsController(mockRepsHolder.Object);

            //Act
            ViewResult result = (ViewResult)brandsController.Index();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}