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
        }

        private void LimparCampos()
        {
            TxtNome.Text = string.Empty;
            TxtSenha.Text = string.Empty;
            TxtNomeUsuario.Text = string.Empty;
            TxtConfirmarSenha.Text = string.Empty;
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

            if (string.IsNullOrWhiteSpace(TxtConfirmarSenha.Text))
                return false;
            return true;
        }

        private void Salvar()
        {
            var obj = new Usuario();
            obj.Nome = TxtNome.Text;
            obj.Senha = TxtSenha.Text;
            obj.Email = Txtemail.Text;

            using (SqlConnection conn =
                new SqlConnection(@"initial Catalog=GastroHelp;
                    Data Source=localhost;
                    Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO usuario (nome, senha, confirmar_senha, email)";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = obj.Senha;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}
