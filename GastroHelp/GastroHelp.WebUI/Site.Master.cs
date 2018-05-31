using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            if (IsPostBack)
                return;            
            //link login só vai aparecer se não tiver nenhum usuário logado
            lnkLogin.Visible = HttpContext.Current.User == null || HttpContext.Current.User.GetType() == typeof(WindowsPrincipal);
            //link sair só vai aparecer se tiver algum usuário logado
            lnkSair.Visible = HttpContext.Current.User != null && HttpContext.Current.User.GetType() != typeof(WindowsPrincipal) && ((Usuario)HttpContext.Current.User) != null;
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginDeUsuario.aspx");
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogOff.aspx");
        }    

        protected void rptReceitasPesq_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerMais")
            {
                Response.Redirect(string.Format("~/TelaReceita.aspx?id={0}", Convert.ToInt32(e.CommandArgument)));
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var receitas = (List<string>)ViewState["lstReceitas"];


            rptReceitasPesq.DataSource = receitas;
            rptReceitasPesq.DataBind();
        }
    }
}