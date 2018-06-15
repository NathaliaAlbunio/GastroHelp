using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GastroHelp.Models
{
    public class Comentario
    {
        public int Id_Comentario { get; set; }
        public Usuario Usuario { get; set; }
        public Receita Receita { get; set; }
        public string Texto { get; set; }
        public DateTime DataHora { get; set; }
    }
}
