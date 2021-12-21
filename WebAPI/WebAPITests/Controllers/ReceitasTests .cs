using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Tests
{
    [TestClass()]
    public class ReceitasTests
    {

        public IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        [TestMethod()]
        public void GetReceitasTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new ReceitasController(configuration);


            // Act
            JsonResult retorno = controller.Get(1);

            // Assert
            Assert.IsNotNull(retorno);
        }

        [TestMethod()]
        public void PostReceitasTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new ReceitasController(configuration);
            Receitas rct = new Receitas();
            rct.PratoId = 10;
            rct.IngredienteId = 5;
            rct.Quantidade = 5;

            // Act
            JsonResult retorno = controller.Post(rct);

            // Assert
            Assert.AreEqual(retorno.Value,"Added Successfully");
        }

        [TestMethod()]
        public void PutReceitasTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new ReceitasController(configuration);
            Receitas rct = new Receitas();
            rct.PratoId = 2;
            rct.IngredienteId = 4;
            rct.Quantidade = 5;

            // Act
            JsonResult retorno = controller.Put(rct);

            // Assert

            Assert.AreEqual(retorno.Value, "Updated Successfully");
        }

        [TestMethod()]
        public void DeleteReceitasTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new ReceitasController(configuration);

            // Act
            JsonResult retorno = controller.Delete(3);

            // Assert

            Assert.AreEqual(retorno.Value, "Deleted Successfully");
        }
    }
}