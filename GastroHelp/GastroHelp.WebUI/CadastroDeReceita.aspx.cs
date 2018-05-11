using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class CadastroDeReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            //se não tiver nenhum usuário logado, redireciona para tela de login
            if (HttpContext.Current.User == null || HttpContext.Current.User.GetType() == typeof(WindowsPrincipal))
            {
                Response.Redirect("~/LoginDeUsuario.aspx");
            }

            CarregarCategoria();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Salvar();
                LimparCampos();
                Response.Redirect("~/Default.aspx");
            }
        }

        private void CarregarCategoria()
        {
            var lstCategoria = new CategoriaDAO().BuscarTodos();
            ddlCategoria.DataTextField = "Nome";
            ddlCategoria.DataValueField = "Id_Categoria";
            ddlCategoria.DataSource = lstCategoria.OrderBy(o => o.Nome).ToList();
            ddlCategoria.DataBind();
        }

        private void LimparCampos()
        {
            txtNomeDaReceita.Text = string.Empty;
            txtIngredientes.Text = string.Empty;
            txtModoPreparo.Text = string.Empty;
            ddlCategoria.ClearSelection();
            txtDicas.Text = string.Empty;
            txtResumo.Text = string.Empty;
            txtRendimento.Text = string.Empty;
        }

        private bool Validar()
        {

            if (string.IsNullOrWhiteSpace(txtNomeDaReceita.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtIngredientes.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtModoPreparo.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtResumo.Text))
                return false;

            if (string.IsNullOrWhiteSpace(ddlCategoria.SelectedValue))
                return false;

            if (string.IsNullOrWhiteSpace(txtDicas.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtRendimento.Text))
                return false;

            return true;
        }

        private void Salvar()
        {
            var obj = new Receita();
            obj.Nome_Receita = txtNomeDaReceita.Text;
            obj.Ingredientes = txtIngredientes.Text;
            obj.Modo_Preparo = txtModoPreparo.Text;
            obj.Resumo = txtResumo.Text;
            obj.Usuario = new Usuario() { Id_Usuario = ((Usuario)HttpContext.Current.User).Id_Usuario };

            if (rbFacil.Checked)
                obj.Nivel_Dificuldade = "Fácil";
            else if (rbMedio.Checked)
                obj.Nivel_Dificuldade = "Médio";
            else if (rbDificil.Checked)
                obj.Nivel_Dificuldade = "Difícil";

            obj.Categoria = new Categoria() { Id_Categoria = Convert.ToInt32(ddlCategoria.SelectedValue) };
            obj.Dica = txtDicas.Text;
            obj.Rendimento = txtRendimento.Text;
            obj.Foto = Path.GetFileName(fupArquivo.FileName);

            if (!Directory.Exists(Server.MapPath("~/Uploads")))
                Directory.CreateDirectory(Server.MapPath("~/Uploads"));

            var savedFileName = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(fupArquivo.FileName));
            fupArquivo.SaveAs(savedFileName);

            new ReceitaDAO().Inserir(obj);
        }
    }
}
