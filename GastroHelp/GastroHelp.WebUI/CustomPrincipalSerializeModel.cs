using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastroHelp.WebUI
{
    public class CustomPrincipalSerializeModel
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Nome_Usuario { get; set; }
        public string Email { get; set; }
    }
}