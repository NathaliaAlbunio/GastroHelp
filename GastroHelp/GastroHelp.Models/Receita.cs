using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastroHelp.Models
{
    public class Receita
    {
        public int id_receita { get; set;}
        public Usuario Usuario { get; set; }
        public string nivel_dificuldade { get; set; }
        public string ingredientes { get; set; }
        public string modo_preparo { get; set; }
        public string nome_rec { get; set; }
        public string rendimento { get; set; }
        public string dica { get; set; }
        public Categoria Categoria { get; set; }
        public bool publicada { get; set; }
    }
}
