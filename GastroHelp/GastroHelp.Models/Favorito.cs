using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastroHelp.Models
{
    public class Favorito
    {
        public int Id_favorito { get; set; }
        public Receita Receita { get; set; }
        public Usuario Usuario { get; set; }
    }
}
