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
            var lstCategoria = new List<Categoria>();

            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=GastroHelp;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM categoria";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var categoria = new Categoria()
                        {

                            Id_Categoria = Convert.ToInt32(row["id_categoria"]),
                            Nome = row["nome"].ToString(),
                        };
                        lstCategoria.Add(categoria);
                    }
                }
            }

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
            obj.Usuario = new Usuario() { Id_Usuario = 1 };

            if (rbFacil.Checked)
                obj.Nivel_Dificuldade = "Fácil";
            else if (rbMedio.Checked)
                obj.Nivel_Dificuldade = "Médio";
            else if (rbDificil.Checked)
                obj.Nivel_Dificuldade = "Difícil";

            obj.Categoria = new Categoria() { Id_Categoria = Convert.ToInt32(ddlCategoria.SelectedValue) };
            obj.Dica = txtDicas.Text;
            obj.Rendimento = txtRendimento.Text;

            using (SqlConnection conn =
                new SqlConnection(@"initial Catalog=GastroHelp;
                    Data Source=localhost;
                    Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO receita (id_usuario, nivel_dificuldade, ingredientes, modo_preparo, nome_rec, rendimento, dica, id_categoria, publicada)
                                  VALUES (@id_usuario, @nivel_dificuldade, @ingredientes, @modo_preparo, @nome_rec, @rendimento, @dica, @id_categoria, @publicada)";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = obj.Usuario.Id_Usuario;

                    if (rbFacil.Checked)
                        cmd.Parameters.Add("@nivel_dificuldade", SqlDbType.VarChar).Value = "Fácil";
                    else if (rbMedio.Checked)
                        cmd.Parameters.Add("@nivel_dificuldade", SqlDbType.VarChar).Value = "Médio";
                    else if (rbDificil.Checked)
                        cmd.Parameters.Add("@nivel_dificuldade", SqlDbType.VarChar).Value = "Difícil";

                    cmd.Parameters.Add("@ingredientes", SqlDbType.VarChar).Value = obj.Ingredientes;
                    cmd.Parameters.Add("@modo_preparo", SqlDbType.VarChar).Value = obj.Modo_Preparo;
                    cmd.Parameters.Add("@nome_rec", SqlDbType.VarChar).Value = obj.Nome_Receita;
                    cmd.Parameters.Add("@rendimento", SqlDbType.VarChar).Value = obj.Rendimento;
                    cmd.Parameters.Add("@dica", SqlDbType.VarChar).Value = obj.Dica;
                    cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = obj.Categoria.Id_Categoria;
                    cmd.Parameters.Add("@publicada", SqlDbType.Bit).Value = obj.Publicada;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}