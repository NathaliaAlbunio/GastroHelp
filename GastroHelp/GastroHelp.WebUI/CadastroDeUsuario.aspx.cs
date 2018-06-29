using GastroHelp.DataAccess;
using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GastroHelp.WebUI
{
    public partial class CadastroDeUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Salvar();

                LimparCampos();

                Response.Redirect("~/Default.aspx");
            }
            else
            {
                var obj = new Usuario();
                new UsuarioDAO().Inserir(obj);

                lblMsg.Text = "Preencha todos os campos!";
                pnlMsg.Visible = true;
                return;
            }
        }

        private void LimparCampos()
        {
            TxtNome.Text = string.Empty;
            TxtSenha.Text = string.Empty;
            TxtNomeUsuario.Text = string.Empty;
            Txtemail.Text = string.Empty;

        }

        private bool Validar()
        {

            if (string.IsNullOrWhiteSpace(TxtNome.Text))
                return false;

            if (string.IsNullOrWhiteSpace(Txtemail.Text))
                return false;

            if (string.IsNullOrWhiteSpace(TxtNomeUsuario.Text))
                return false;

            if (string.IsNullOrWhiteSpace(TxtSenha.Text))
                return false;


            return true;
        }

        private void Salvar()
        {
            var obj = new Usuario();
            obj.Nome = TxtNome.Text;
            obj.Senha = TxtSenha.Text;
            obj.Email = Txtemail.Text;
            obj.Nome_Usuario = TxtNomeUsuario.Text;
            new UsuarioDAO().Inserir(obj);
        }
    }
}
