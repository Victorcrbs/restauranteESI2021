using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Pratos
    {
        public int PratoId { get; set; }
        public string PratoNome { get; set; }
        public string PratoDescricao { get; set; }
        public decimal PratoPreco { get; set; }
    }
}
