using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace GastroHelp.Models
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id_Usuario { get; set; }
        string Nome { get; set; }
        string Nome_Usuario { get; set; }
        string Email { get; set; }
    }
}
