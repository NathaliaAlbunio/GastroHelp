using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastroHelp.Models
{
    public class Comentario
    {
        public int id_comentario { get; set; }
        public Usuario Usuario { get; set; }
        public Receita Receita { get; set; }
        public string texto { get; set; }
        public DateTime DataHora { get; set; }
    }
}
