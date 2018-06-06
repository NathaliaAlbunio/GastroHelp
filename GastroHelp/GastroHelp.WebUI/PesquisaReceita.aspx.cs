using GastroHelp.DataAccess;
using System;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class PesquisaReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (!string.IsNullOrWhiteSpace(Request.QueryString["texto"]))
            {
                var textoBusca = Request.QueryString["texto"];
                var receitas = new ReceitaDAO().BuscarPorTexto(textoBusca);

                rptReceitasPesq.DataSource = receitas;
                rptReceitasPesq.DataBind();
            }
        }

        protected void rptReceitasPesq_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerMais")
            {
                Response.Redirect(string.Format("~/TelaReceita.aspx?id={0}", Convert.ToInt32(e.CommandArgument)));
            }
        }
    }
}
