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
            //buscando apenas as receitas aprovadas (publicadas)
            var lst = new ReceitaDAO().BuscarAprovadas();
            //buscando as 10 receitas mais favoritadas
            gridView.DataSource = lst.OrderByDescending(r => r.QtdFavorito).Take(10).ToList();
            gridView.DataBind();
        }
    }
}