using GastroHelp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class MinhaGeladeira : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            pnlMsg.Visible = false;
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ViewState["lstIngredientes"] == null)
            {
                ViewState["lstIngredientes"] = new List<string>();
            }

            var ingredientes = (List<string>)ViewState["lstIngredientes"];

            if (!string.IsNullOrWhiteSpace(txtIngrediente.Text))
            {
                ingredientes.Add(txtIngrediente.Text);
            }

            ViewState["lstIngredientes"] = ingredientes;

            if (ingredientes != null && ingredientes.Count > 5)
            {
                pnlMsg.Visible = true;
                lblMsg.Text = "Máximo permitido de 5 ingredientes!";
                txtIngrediente.Text = string.Empty;
                return;
            }

            txtIngrediente.Text = string.Empty;
            rptIngredientes.DataSource = ingredientes;
            rptIngredientes.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var ingredientes = (List<string>)ViewState["lstIngredientes"];

            if (!(ingredientes != null && ingredientes.Count > 0))
            {
                pnlMsg.Visible = true;
                lblMsg.Text = "Mínimo permitido de 3 ingredientes!";
                return;
            }

            if (ingredientes != null && ingredientes.Count < 3)
            {
                pnlMsg.Visible = true;
                lblMsg.Text = "Mínimo permitido de 3 ingredientes!";
                return;
            }

            var receitas = new ReceitaDAO().BuscarPorIngredientes(ingredientes);

            if (!(receitas != null && receitas.Count > 0))
            {
                pnlMsg.Visible = true;
                lblMsg.Text = "Nenhum resultado encontrado!";
            }

            pnlReceitas.Visible = receitas != null && receitas.Count > 0;
            rptReceitas.DataSource = receitas;
            rptReceitas.DataBind();
        }

        protected void rptReceitas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerMais")
            {
                Response.Redirect(string.Format("~/TelaReceita.aspx?id={0}", Convert.ToInt32(e.CommandArgument)));
            }
        }
    }
}