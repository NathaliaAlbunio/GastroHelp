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

            var lst = new ComentarioDAO().BuscarComentario();
            gridViewComentario.DataSource = lst;
            gridViewComentario.DataBind();
            

        }

        protected void btnFavoritar_Click(object sender, EventArgs e)
        {
            Favoritar();

        }

        private void Favoritar()
        {
            var obj = new Favorito();
            obj.Usuario = new Usuario() { Id_Usuario = ((Usuario)HttpContext.Current.User).Id_Usuario };
            obj.Receita = new Receita() { Id_Receita = Convert.ToInt32(Request.QueryString["id"]) };

            new FavoritoDAO().Favoritar(obj);
            Response.Redirect(string.Format("~/TelaReceita.aspx?id={0}", obj.Receita.Id_Receita));
        }

        private bool Validar()
        {

            if (string.IsNullOrWhiteSpace(txtComentario.Text))
                return false;

            return true;
        }

        private void Salvar()
        {
            var obj = new Comentario();
            obj.texto = txtComentario.Text;
            obj.Usuario = new Usuario() { Id_Usuario = ((Usuario)HttpContext.Current.User).Id_Usuario };
            obj.Receita = new Receita() { Id_Receita = Convert.ToInt32(Request.QueryString["id"]) };
            //PARA PEGAR O ID DA RECEITA VC DEVE COLOCAR O REQUEST.QUERTSTRING ID
            new ComentarioDAO().EnviarComentario(obj);
        }

        private void LimparCampos()
        {
            txtComentario.Text = string.Empty;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Salvar();
                LimparCampos();
                Response.Redirect(string.Format("~/TelaReceita.aspx?id={0}", Request.QueryString["id"]));
            }
        }
    }
}
