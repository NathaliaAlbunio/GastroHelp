using GastroHelp.DataAccess;
using System;

namespace GastroHelp.WebUI
{
    public partial class TelaReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var obj = new ReceitaDAO().BuscarPorId(Convert.ToInt32(Request.QueryString["id"]));
                lblNomeReceita.Text = obj.Nome_Receita;
                lblCategoria.Text = string.Format("Categoria: {0}", obj.Categoria.Nome);
                lblNivel.Text = string.Format("Nível de dificuldade: {0}", obj.Nivel_Dificuldade);
                lblUsuario.Text = string.Format("Enviado por {0} em {1:dd/MM/yyyy} às {1:HH:mm}", obj.Usuario.Nome, obj.DataCadastro);
                lblIngredientes.Text = obj.Ingredientes;
                lblModoDePreparo.Text = obj.Modo_Preparo;
                lblResumo.Text = obj.Resumo;
            }
        }
    }
}