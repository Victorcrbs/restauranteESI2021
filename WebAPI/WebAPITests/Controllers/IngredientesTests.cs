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
    public class IngredientesTests
    {

        public IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        [TestMethod()]
        public void GetIngredientesTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new IngredientesController(configuration);


            // Act
            JsonResult retorno = controller.Get();

            // Assert

            Assert.IsNotNull(retorno);
        }

        [TestMethod()]
        public void PostIngredientesTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new IngredientesController(configuration);
            Ingredientes ing = new Ingredientes();
            ing.IngredienteNome = "Frango";
            ing.IngredienteQuantidade = 10;

            // Act
            JsonResult retorno = controller.Post(ing);

            // Assert
            Assert.AreEqual(retorno.Value,"Added Successfully");
        }

        [TestMethod()]
        public void PutIngredientesTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new IngredientesController(configuration);
            Ingredientes ing = new Ingredientes();
            ing.IngredienteId = 3;
            ing.IngredienteNome = "Batata Doce";
            ing.IngredienteQuantidade = 45;


            // Act
            JsonResult retorno = controller.Put(ing);
            // Assert

            Assert.AreEqual(retorno.Value, "Updated Successfully");
        }

        [TestMethod()]
        public void DeleteIngredientesTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new IngredientesController(configuration);


            // Act
            JsonResult retorno = controller.Delete(4);

            // Assert

            Assert.AreEqual(retorno.Value, "Deleted Successfully");
        }
    }
}