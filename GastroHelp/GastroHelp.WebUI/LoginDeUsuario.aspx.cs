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
            if (IsPostBack) //Verifica se é a primeira vez que a página carrega
                return;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //Declando uma variável para receber o login
            var usuario = new Usuario();
            usuario.Nome_Usuario = TxtNomeUsuario.Text;
            usuario.Senha = TxtSenha.Text;

            var obj = new UsuarioDAO().Logar(usuario);
            //Se não exister o dado de login, aparecerá a mensagem de erro
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
            {//Se o bit moderador estiver verdadeiro ele envia pra tela de aprovação de receita
                if (obj.Moderador)
                {
                    Response.Redirect("AprovacaoDeReceita.aspx"); //Redireciona para a tela de aprovação
                }
                Response.Redirect("Default.aspx"); //Redireciona para a tela default
            }
        }
    }
}