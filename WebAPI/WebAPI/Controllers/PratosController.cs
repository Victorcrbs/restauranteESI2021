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
using Newtonsoft.Json;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PratosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            string query = @"
                    select * from dbo.Pratos LEFT JOIN dbo.Receitas ON dbo.Receitas.PratoId = dbo.Pratos.PratoId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ESIAppCon");
            SqlDataReader myReader;
            List<ReceitaPrato> receitaPratos = new List<ReceitaPrato>();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    foreach (DataRow linha in table.Rows)
                    {
                        string PratoId = linha["PratoId"].ToString();
                        string PratoNome = linha["PratoNome"].ToString();
                        decimal PratoPreco = (decimal)linha["PratoPreco"];
                        int ingrediente = (int)linha["IngredienteId"];
                        decimal quantidade = (decimal)linha["Quantidade"];
                        ReceitaPrato currentReceitaPrato = receitaPratos.Find(x => x.PratoId == PratoId);
                        if(currentReceitaPrato.PratoId == null)
                        {
                            currentReceitaPrato = new ReceitaPrato(PratoId, PratoNome, PratoPreco, new IngredienteQTD(ingrediente, quantidade));
                            receitaPratos.Add(currentReceitaPrato);
                        } else
                        {
                            currentReceitaPrato.ListaIngredientes.Add(new IngredienteQTD(ingrediente, quantidade));
                        }

                       // Console.WriteLine("Lendo: " + nome + " Ingrediente: " + ingrediente + " Quantidade:" + quantidade);
                    }
                    myReader.Close();
                    myCon.Close();
                }
            }

            JsonResult results = new JsonResult(table);
            List<ReceitaPrato> receitaPratosFinal = new List<ReceitaPrato>(receitaPratos);
            foreach (ReceitaPrato receitaPrato in receitaPratos)
            {
                bool hasIngredients = true;
                IngredientesController ingredientesController = new IngredientesController(_configuration);
                foreach (IngredienteQTD ingredienteQTD in receitaPrato.ListaIngredientes)
                {
                    int ingredient = ingredientesController.GetIngredientAvailability(ingredienteQTD.IngredienteId, ingredienteQTD.Quantidade);
                    if(ingredient == 0)
                    {
                        hasIngredients = false;
                    }
                }
                if (!hasIngredients)
                {
                    receitaPratosFinal.Remove(receitaPrato);
                }
            }

            foreach(ReceitaPrato receitaFinal in receitaPratosFinal)
            {
                Console.WriteLine(receitaFinal.ToString());
            }
            return JsonConvert.SerializeObject(receitaPratosFinal);
        }

        public struct ReceitaPrato {
            public string PratoId, PratoNome;
            public decimal PratoPreco;
            public List<IngredienteQTD> ListaIngredientes;
            public override string ToString()
            {
                string listaIngredientesString = "";
                foreach(var ingrediente in ListaIngredientes)
                {
                    listaIngredientesString += ingrediente.ToString();
                }
                return "Prato ID: " + PratoId + "Lista Ing: " + listaIngredientesString;
            }
            public ReceitaPrato(string _pratoId, string _pratoNome, decimal _pratoPreco, IngredienteQTD novoIngrediente)
            {
                this.PratoNome = _pratoNome;
                this.PratoPreco = _pratoPreco;
                this.ListaIngredientes = new List<IngredienteQTD>();
                this.PratoId = _pratoId;
                this.ListaIngredientes.Add(novoIngrediente);
            }
        }
        public struct IngredienteQTD {
            public int IngredienteId;
            public decimal Quantidade;

            public override string ToString()
            {
                return "[Ingrediente: " + this.IngredienteId + " | Quantidade: " + this.Quantidade + "]";
            }
            public IngredienteQTD(int _ingrediente, decimal _quantidade)
            {
                this.IngredienteId = _ingrediente;
                this.Quantidade = _quantidade;
            }
        }


        [HttpPost]
        public JsonResult Post(Pratos prato)
        {
            decimal dec = prato.PratoPreco;
            dec.ToString().Replace(",", ".");
            string str = dec.ToString().Replace(",", ".");
            string query = @"
                    insert into dbo.Pratos values
                    ('" + prato.PratoId + @"' ,
                       '" + prato.PratoNome + @"' , 
                    '" + prato.PratoDescricao + @"',
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
        public JsonResult Put(Pratos prato)
        {
            decimal dec = prato.PratoPreco;
            dec.ToString().Replace(",", ".");
            string str = dec.ToString().Replace(",", ".");
            string query = @"
                    update dbo.Pratos set
                    PratoNome = '" + prato.PratoNome + @"',
                    PratoDescricao = '" + prato.PratoDescricao + @"',
                    PratoPreco = "+ str + @"
                    where PratoId = " + prato.PratoId + @"
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
                    delete from dbo.Pratos
                    where PratoId = " + id + @"
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
