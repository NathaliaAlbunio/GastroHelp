using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Web.Script.Serialization;

namespace GastroHelp.Models
{
    public class Usuario : ICustomPrincipal
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome_Usuario { get; set; }
        public bool Moderador { get; set; }

        [ScriptIgnore]
        [IgnoreDataMember]
        public IIdentity Identity
        {
            get
            {
                return new GenericIdentity(this.Nome_Usuario, "Usuario");
            }
            set { }
        }

        public bool IsInRole(string role)
        {
            return (role == "Admin");
        }

        public Usuario()
        {

        }

        public Usuario(string nomeUsuario)
        {
            Identity = new GenericIdentity(nomeUsuario, "Usuario");
        }
    }
}
