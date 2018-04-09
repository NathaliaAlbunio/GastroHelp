using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GastroHelp.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome_Usuario { get; set; }
        public bool Moderador { get; set; }
    }
}
