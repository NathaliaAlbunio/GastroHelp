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
    public partial class AprovacaoDeReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            CarregarGridView();
        }

        private void CarregarGridView()
        {
            var lstReceita = new ReceitaDAO().BuscarTodos();
            grdAprovacao.DataSource = lstReceita;
            grdAprovacao.DataBind();
        }

        protected void btnAceitar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(((LinkButton)sender).CommandArgument))
            {
                var id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                if (id > 0)
                {
                    var obj = new Receita() { Id_Receita = id };
                    new ReceitaDAO().Aceitar(obj);
                    Response.Redirect("~/AprovacaoDeReceita.aspx");
                }
            }
        }

        protected void bntExcluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(((LinkButton)sender).CommandArgument))
            {
                var id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                if (id > 0)
                {
                    var obj = new Receita() { Id_Receita = id };
                    new ReceitaDAO().Excluir(obj);
                    Response.Redirect("~/AprovacaoDeReceita.aspx");
                }
            }
        }
    }
}

