using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastroHelp.WebUI
{
    public class Usuario
    {
        public string Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Confirmar_senha { get; set; }
        public string Email { get; set; }
    }
}