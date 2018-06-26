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

            //APARECERÁ SE O USUÁRIO ESTÁ LOGADO
            var usuarioLogado = (Usuario)User;
            lblNomeUsuario.Text = usuarioLogado.Nome;

            ///APARECER AS RECEITAS POSTADAS PELO USER
            var lstMinhasReceitas = new ReceitaDAO().BuscarMinhasReceitas(usuarioLogado);
            grdMinhasReceitas.DataSource = lstMinhasReceitas;
            grdMinhasReceitas.DataBind();

            ///APARECER AS RECEITAS FAVORITAS PELO USER
            var lstFavoritos = new ReceitaDAO().BuscarPorFavoritos(usuarioLogado);
            grdMeusFavoritos.DataSource = lstFavoritos;
            grdMeusFavoritos.DataBind();
        }
    }
}
