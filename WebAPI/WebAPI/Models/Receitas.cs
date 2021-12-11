using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Receitas
    {
        public int PratoId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
