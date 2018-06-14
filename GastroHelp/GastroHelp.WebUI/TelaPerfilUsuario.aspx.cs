using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;



namespace GastroHelp.WebUI
{
    public partial class TelaPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (User == null || User.GetType() != typeof(Usuario))
            {
                Response.Redirect("~/LoginDeUsuario.aspx");
            }

            var usuarioLogado = (Usuario)User;
            var lst = new ReceitaDAO().BuscarPorFavoritos(usuarioLogado);
            dgwfavorito.DataSource = lst;
            dgwfavorito.DataBind();

            lblNomeUsuario.Text = usuarioLogado.Nome;
        }
    }
}
