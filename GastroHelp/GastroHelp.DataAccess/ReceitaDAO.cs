using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastroHelp.DataAccess
{
    public class ReceitaDAO
    {
        public void Inserir(Receita obj)
        {
            using (SqlConnection conn =
            new SqlConnection(@"Initial Catalog= GastroHelp;
                    Data Source=localhost;
                    Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO receita (usuario, nivel_dificuldade, ingredientes, modo_preparo, nome_rec, rendimento, dica, categoria, publicada)
                              VALUES (@usuario, @nivel_dificuldade, @ingredientes, @modo_preparo, @nome_rec, @rendimento, @dica, @categoria, @publicada);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = obj.Usuario;
                    cmd.Parameters.Add("@nivel_dificuldade", SqlDbType.VarChar).Value = obj.nivel_dificuldade;
                    cmd.Parameters.Add("@ingredientes", SqlDbType.VarChar).Value = obj.ingredientes;
                    cmd.Parameters.Add("@modo_preparo", SqlDbType.VarChar).Value = obj.modo_preparo;
                    cmd.Parameters.Add("@nome_rec", SqlDbType.VarChar).Value = obj.nome_rec;
                    cmd.Parameters.Add("@rendimento", SqlDbType.VarChar).Value = obj.rendimento;
                    cmd.Parameters.Add("@dica", SqlDbType.VarChar).Value = obj.dica;
                    cmd.Parameters.Add("@categoria", SqlDbType.Int).Value = obj.Categoria;
                    cmd.Parameters.Add("@publicada", SqlDbType.Bit).Value = obj.publicada;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public List<Receita> BuscarTodos()
        {
            var lst = new List<Receita>();

            using (SqlConnection conn =
                  new SqlConnection(@"Initial Catalog=GastroHelp;
                    Data Source=localhost;
                    Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT *FROM receita;";

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
                        var receita = new Receita()
                        {
                            id_receita = Convert.ToInt32(row["id_receita"]),
                            publicada = Convert.ToBoolean(row["Categoria"]),
                            nivel_dificuldade = row["nivel_dificuldade"].ToString(),
                            ingredientes = row["ingredientes"].ToString(),
                            modo_preparo = row["modo_preparo"].ToString(),
                            nome_rec = row["nome_rec"].ToString(),
                            rendimento = row["rendimento"].ToString(),
                            dica = row["dica"].ToString(),
                            Categoria = new Categoria()
                            {
                                Id_categoria = Convert.ToInt32(row["Id_categoria"]),
                                Nome = row["nome"].ToString()
                            },
                            Usuario = new Usuario()
                            {
                                id_usuario = Convert.ToInt32(row["id_usuario"]),
                                nome = row["nome"].ToString(),
                                senha = row["senha"].ToString(),
                                email = row["email"].ToString(),
                                nome_usuario = row["nome_usuario"].ToString(),
                                moderador = Convert.ToBoolean(row["Categoria"]),
                            }


                        };
                        lst.Add(receita);
                    }
                }
            }

            return lst;
        }
    }
}
