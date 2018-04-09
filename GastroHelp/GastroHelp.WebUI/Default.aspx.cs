using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var lst = new List<Receita>();
            lst.Add(new Receita() { Id_Receita = 1 });
            lst.Add(new Receita() { Id_Receita = 2 });
            lst.Add(new Receita() { Id_Receita = 3 });
            lst.Add(new Receita() { Id_Receita = 4 });
            lst.Add(new Receita() { Id_Receita = 5 });
            lst.Add(new Receita() { Id_Receita = 6 });
            lst.Add(new Receita() { Id_Receita = 7 });

            gridView.DataSource = lst;
            gridView.DataBind();
        }
    }
}