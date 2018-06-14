using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;
using System.Web.Script.Serialization;

namespace GastroHelp.WebUI
{
    public partial class LoginDeUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            usuario.Nome_Usuario = TxtNomeUsuario.Text;
            usuario.Senha = TxtSenha.Text;

            var obj = new UsuarioDAO().Logar(usuario);

            if (obj == null)
            {
                lblMsg.Text = "Login ou senha inválido!";
                pnlMsg.Visible = true;
                return;
            }

            //usuario que eu busquei no banco de dados e armazeno no cache do navegador
            var userData = new JavaScriptSerializer().Serialize(obj);
            FormsAuthenticationUtil.SetCustomAuthCookie(obj.Nome_Usuario, userData, false);

            if (obj == null)
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