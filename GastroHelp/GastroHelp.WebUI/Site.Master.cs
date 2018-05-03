using GastroHelp.Models;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.UI;

namespace GastroHelp.WebUI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            //link login só vai aparecer se não tiver nenhum usuário logado
            lnkLogin.Visible = HttpContext.Current.User == null || HttpContext.Current.User.GetType() == typeof(WindowsPrincipal);
            //link sair só vai aparecer se tiver algum usuário logado
            lnkSair.Visible = HttpContext.Current.User != null && ((Usuario)HttpContext.Current.User) != null;
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginDeUsuario.aspx");
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogOff.aspx");
        }
    }
}