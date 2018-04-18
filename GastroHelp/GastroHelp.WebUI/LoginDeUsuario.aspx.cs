using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class LoginDeUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            usuario.Nome_Usuario = TxtNomeUsuario.Text;
            usuario.Senha = TxtSenha.Text;

            var obj = new UsuarioDAO().Logar(usuario);

            if(obj == null)
            {
                Response.Redirect("LoginDeUsuario.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}