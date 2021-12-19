using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;
using System.Globalization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public IngredientesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // 0 = falta de ingredientes
        // 1 = tem ingredientes suficientes
        public int GetIngredientAvailability(int id, decimal qtd)
        {
            string query = @"
                    select * from dbo.Ingredientes WHERE dbo.Ingredientes.id_ing = " + id + " AND dbo.Ingredientes.qtd_ing >= " + qtd;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ESIAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;
                    //Console.WriteLine("Linhas retornadas para id: " + id + " - " + table.Rows.Count);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return table.Rows.Count;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select * from dbo.Ingredientes";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ESIAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Ingredientes ing)
        {
            decimal dec = ing.IngredienteQuantidade;
            dec.ToString().Replace(",", ".");
            string str = dec.ToString().Replace(",", ".");
            string query = @"
                    insert into dbo.Ingredientes values
                    ('" + ing.IngredienteNome + @"', 
                    " + str + @")
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ESIAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Ingredientes ing)
        {
            decimal dec = ing.IngredienteQuantidade;
            dec.ToString().Replace(",", ".");
            string str = dec.ToString().Replace(",", ".");
            string query = @"
                    update dbo.Ingredientes set
                    IngredienteNome = '" + ing.IngredienteNome + @"',
                    IngredienteQuantidade = "+ str + @"
                    where IngredienteId = " + ing.IngredienteId + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ESIAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Ingredientes
                    where IngredienteId = " + id + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ESIAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }

    }
}
