using GastroHelp.DataAccess;
using System;
using System.Web.UI;

namespace GastroHelp.WebUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            var lst = new ReceitaDAO().BuscarTodos();
            gridView.DataSource = lst;
            gridView.DataBind();
        }
    }
}