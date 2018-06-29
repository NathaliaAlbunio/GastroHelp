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
            //Verifica se é a primeira vez que a página carrega
            if (IsPostBack)
                return;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //Declarando uma variável para receber o login
            var usuario = new Usuario();
            usuario.Nome_Usuario = TxtNomeUsuario.Text;
            usuario.Senha = TxtSenha.Text;

            //Se não exister o dado de login, aparecerá a mensagem de erro
            var obj = new UsuarioDAO().Logar(usuario);
            if (obj == null)
            {
                lblMsg.Text = "Login ou senha inválido!";
                pnlMsg.Visible = true;
                return;
            }

            //Usuário que eu busquei no banco de dados e armazeno no cache do navegador
            var userData = new JavaScriptSerializer().Serialize(obj);
            FormsAuthenticationUtil.SetCustomAuthCookie(obj.Nome_Usuario, userData, false);

            if (obj == null)
            {
                Response.Redirect("LoginDeUsuario.aspx");
            }
            else
            {
                //Se o bit moderador estiver verdadeiro ele envia pra tela de aprovação de receita
                if (obj.Moderador)
                {
                    //Redireciona para a tela de aprovação
                    Response.Redirect("AprovacaoDeReceita.aspx");
                }
                //Redireciona para a tela default
                Response.Redirect("Default.aspx");
            }
        }
    }
}