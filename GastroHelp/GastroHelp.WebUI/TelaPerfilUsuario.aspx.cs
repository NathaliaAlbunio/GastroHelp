using System;
using GastroHelp.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GastroHelp.Models;


namespace GastroHelp.WebUI
{
    public partial class TelaPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            var lst = new ReceitaDAO().BuscarPorFavoritos((Usuario)User);
            dgwfavorito.DataSource = lst;
            dgwfavorito.DataBind();
        }
    }
}