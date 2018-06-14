using GastroHelp.DataAccess;
using System;
using System.Linq;
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
            //buscando as 10 receitas mais favoritadas
            gridView.DataSource = lst.OrderByDescending(r => r.QtdFavorito).Take(10).ToList();
            gridView.DataBind();
        }
    }
}