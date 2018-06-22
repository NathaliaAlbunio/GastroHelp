using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;
using System.IO;
using System.Security.Principal;
using System.Web;

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
                imgRec.Attributes.Add("src", Page.ResolveUrl(Path.Combine("~/Uploads", obj.Foto)));
                lblNomeReceita.Text = obj.Nome_Receita;
                lblCategoria.Text = string.Format("Categoria: {0}", obj.Categoria.Nome);
                lblNivel.Text = string.Format("Nível de dificuldade: {0}", obj.Nivel_Dificuldade);
                lblUsuario.Text = string.Format("Enviado por {0} em {1:dd/MM/yyyy} às {1:HH:mm}", obj.Usuario.Nome, obj.DataCadastro);
                lblIngredientes.Text = obj.Ingredientes;
                lblModoDePreparo.Text = obj.Modo_Preparo;
                lblResumo.Text = obj.Resumo;

                //usuário está logado, vai mostrar o botão de favoritos
                if (HttpContext.Current.User.GetType() != typeof(WindowsPrincipal))
                {
                    var lstFavoritos = new FavoritoDAO().Buscar(obj.Id_Receita, ((Usuario)HttpContext.Current.User).Id_Usuario);
                    btnFavoritar.Visible = !(lstFavoritos != null && lstFavoritos.Count > 0);
                    txtComentario.Visible = true;
                    btnEnviar.Visible = true;
                }
                else
                {
                    //senão esconde o botão de favoritos
                    btnFavoritar.Visible = false;
                    txtComentario.Visible = false;
                    btnEnviar.Visible = false;
                }

                var lst = new ComentarioDAO().BuscarPorReceita(obj.Id_Receita);
                gridViewComentario.DataSource = lst;
                gridViewComentario.DataBind();
            }
        }

        protected void btnFavoritar_Click(object sender, EventArgs e)
        {
            Favoritar();
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

        private void Favoritar()
        {
            if (User == null || User.GetType() != typeof(Usuario))
            {
                Response.Redirect("~/LoginDeUsuario.aspx");
            }

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
            obj.Texto = txtComentario.Text;
            obj.Usuario = new Usuario() { Id_Usuario = ((Usuario)HttpContext.Current.User).Id_Usuario };
            //PARA PEGAR O ID DA RECEITA VC DEVE COLOCAR O REQUEST.QUERTSTRING ID
            obj.Receita = new Receita() { Id_Receita = Convert.ToInt32(Request.QueryString["id"]) };
            new ComentarioDAO().EnviarComentario(obj);
        }

        private void LimparCampos()
        {
            txtComentario.Text = string.Empty;
        }
    }
}
