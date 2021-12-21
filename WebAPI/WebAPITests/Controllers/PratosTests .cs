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
    public class PratosTests
    {

        public IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        [TestMethod()]
        public void GetPratosTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new PratosController(configuration);


            // Act
            String retorno = controller.Get();

            // Assert

            Assert.IsNotNull(retorno);
        }

        [TestMethod()]
        public void PostPratosTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new PratosController(configuration);
            Pratos prt = new Pratos();
            prt.PratoNome = "Pastel de carne";
            prt.PratoDescricao = "Pastel de carne com ovo cozido";
            prt.PratoPreco = 10;

            // Act
            JsonResult retorno = controller.Post(prt);

            // Assert
            Assert.AreEqual(retorno.Value,"Added Successfully");
        }

        [TestMethod()]
        public void PutPratosTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new PratosController(configuration);
            Pratos prt = new Pratos();
            prt.PratoId = 3;
            prt.PratoNome = "Strogonoff de frango";
            prt.PratoDescricao = "Strogonoff de frango, acompanha porção de arroz";
            prt.PratoPreco = 35;

            // Act
            JsonResult retorno = controller.Put(prt);

            // Assert

            Assert.AreEqual(retorno.Value, "Updated Successfully");
        }

        [TestMethod()]
        public void DeletePratosTest()
        {
            // Arrange
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var controller = new PratosController(configuration);

            // Act
            JsonResult retorno = controller.Delete(4);

            // Assert

            Assert.AreEqual(retorno.Value, "Deleted Successfully");
        }
    }
}