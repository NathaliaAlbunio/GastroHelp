using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GastroHelp.Models
{
    public class Receita
    {
        public int Id_Receita { get; set; }
        public Usuario Usuario { get; set; }
        public string Nivel_Dificuldade { get; set; }
        public string Ingredientes { get; set; }
        public string Modo_Preparo { get; set; }
        public string Nome_Receita { get; set; }
        public string Rendimento { get; set; }
        public string Dica { get; set; }
        public Categoria Categoria { get; set; }
        public bool Publicada { get; set; }
    }
}
