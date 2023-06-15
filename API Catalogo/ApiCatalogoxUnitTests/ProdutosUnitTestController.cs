using ApiCatalogo.Repository;
using APICatalogo.Context;
using APICatalogo.Controllers;
using APICatalogo.Models;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoxUnitTests
{
    public class ProdutosUnitTestController
    {
        private IUnitOfWork repository;

        public static DbContextOptions<ApiDbContext> dbContextOptions { get; }

        public static string connectionString = "Server=localhost;DataBase=CatalogoDB;Uid=root;Pwd=''";
        static ProdutosUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApiDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
        }

        public ProdutosUnitTestController()
        {
            var context = new ApiDbContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }

        [Fact]
        public void GetProdutosById_Return_OkResult()
        {
            //Arrange
            var controller = new ProdutosController(repository);
            var catId = 2;
            //Act
            var data = controller.Get(catId);

            //Assert
            Assert.IsType<Produto>(data.Value);
        }

        [Fact]
        public void GetProdutosById_Return_NotFound()
        {
            //Arrange
            var controller = new ProdutosController(repository);
            var catId = 5;
            //Act
            var data = controller.Get(catId);

            //Assert
            Assert.IsType<NotFoundResult>(data.Result);
        }
    }
}
