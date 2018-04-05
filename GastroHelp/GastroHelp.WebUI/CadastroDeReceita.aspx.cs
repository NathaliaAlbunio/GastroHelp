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
    public partial class CadastroDeReceita : System.Web.UI.Page
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
            txtNomeDaReceita.Text = string.Empty;
            txtIngredientes.Text = string.Empty;
            txtModoPreparo.Text = string.Empty;
            //nivel
            ddlCategoria.ClearSelection();
            txtDicas.Text = string.Empty;
            txtRendimento.Text = string.Empty;
        }

        private bool Validar()
        {

            if (string.IsNullOrWhiteSpace(txtNomeDaReceita.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtIngredientes.Text))
                return false;

            //NIVEL

            if (string.IsNullOrWhiteSpace(txtModoPreparo.Text))
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
            obj.nome_rec = txtNomeDaReceita.Text;
            obj.ingredientes = txtIngredientes.Text;
            obj.modo_preparo = txtModoPreparo.Text;
            //nivel-- FALTA A MODEL "CATEGORIA" ANJO <-----------

            if (chkFacil.Checked)
                obj.nivel_dificuldade = "Fácil";
            else if (chkMedio.Checked)
                obj.nivel_dificuldade = "Médio";
            else if (chkDificil.Checked)
                obj.nivel_dificuldade = "Difícil";

            obj.Categoria = new Categoria() { Id_categoria = Convert.ToInt32(ddlCategoria.SelectedValue) };
            obj.dica = txtDicas.Text;
            obj.rendimento = txtRendimento.Text;

            using (SqlConnection conn =
                new SqlConnection(@"initial Catalog=GastroHelp;
                    Data Source=localhost;
                    Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO receita (id_usuario, nivel_dificuldade, ingredientes, modo_preparo, nome_rec, rendimento, dica, id_categoria, publicada  )
                                               VALUES (@id_usuario, @nivel_dificuldade, @ingredientes
                                                      @modo_preparo, @nome_rec, @rendimento, @dica, @id_categoria, @publicada  )";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = obj.Usuario.id_usuario;

                    //nivel   
                    if (chkFacil.Checked)
                        cmd.Parameters.Add("@modo_preparo", SqlDbType.VarChar).Value = "Fácil";
                    else if (chkMedio.Checked)
                        cmd.Parameters.Add("@modo_preparo", SqlDbType.VarChar).Value = "Médio";
                    else if (chkDificil.Checked)
                        cmd.Parameters.Add("@modo_preparo", SqlDbType.VarChar).Value = "Difícil";

                    cmd.Parameters.Add("@ingredientes", SqlDbType.VarChar).Value = obj.ingredientes;
                    cmd.Parameters.Add("@modo_preparo", SqlDbType.VarChar).Value = obj.modo_preparo;
                    cmd.Parameters.Add("@nome_rec", SqlDbType.VarChar).Value = obj.nome_rec;
                    cmd.Parameters.Add("@rendimento", SqlDbType.VarChar).Value = obj.rendimento;
                    cmd.Parameters.Add("@dica", SqlDbType.VarChar).Value = obj.dica;
                    cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = obj.Categoria.Id_categoria;
                    cmd.Parameters.Add("@publicada", SqlDbType.Bit).Value = obj.publicada;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}