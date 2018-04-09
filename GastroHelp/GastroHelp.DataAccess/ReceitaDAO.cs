using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GastroHelp.DataAccess
{
    public class ReceitaDAO
    {
        public void Inserir(Receita obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog= GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO RECEITA (ID_CATEGORIA, ID_USUARIO, NIVEL_DIFICULDADE, INGREDIENTES, MODO_PREPARO, NOME_REC, RENDIMENTO, DICA, PUBLICADA)
                                  VALUES (@ID_CATEGORIA, @ID_USUARIO, @NIVEL_DIFICULDADE, @INGREDIENTES, @MODO_PREPARO, @NOME_REC, @RENDIMENTO, @DICA, @PUBLICADA);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@ID_CATEGORIA", SqlDbType.Int).Value = obj.Categoria.Id_Categoria;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = obj.Usuario.Id_Usuario;
                    cmd.Parameters.Add("@NIVEL_DIFICULDADE", SqlDbType.VarChar).Value = obj.Nivel_Dificuldade;
                    cmd.Parameters.Add("@INGREDIENTES", SqlDbType.VarChar).Value = obj.Ingredientes;
                    cmd.Parameters.Add("@MODO_PREPARO", SqlDbType.VarChar).Value = obj.Modo_Preparo;
                    cmd.Parameters.Add("@NOME_REC", SqlDbType.VarChar).Value = obj.Nome_Receita;
                    cmd.Parameters.Add("@RENDIMENTO", SqlDbType.VarChar).Value = obj.Rendimento;
                    cmd.Parameters.Add("@DICA", SqlDbType.VarChar).Value = obj.Dica;
                    cmd.Parameters.Add("@PUBLICADA", SqlDbType.Bit).Value = obj.Publicada;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Receita> BuscarTodos()
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                var lst = new List<Receita>();
                string strSQL = @"SELECT *FROM RECEITA;";

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
                            Id_Receita = Convert.ToInt32(row["ID_RECEITA"]),
                            Publicada = Convert.ToBoolean(row["CATEGORIA"]),
                            Nivel_Dificuldade = row["NIVEL_DIFICULDADE"].ToString(),
                            Ingredientes = row["INGREDIENTES"].ToString(),
                            Modo_Preparo = row["MODO_PREPARO"].ToString(),
                            Nome_Receita = row["NOME_REC"].ToString(),
                            Rendimento = row["RENDIMENTO"].ToString(),
                            Dica = row["DICA"].ToString(),
                            Categoria = new Categoria()
                            {
                                Id_Categoria = Convert.ToInt32(row["ID_CATEGORIA"]),
                                Nome = row["NOME"].ToString()
                            },
                            Usuario = new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]),
                                Nome = row["NOME"].ToString(),
                                Senha = row["SENHA"].ToString(),
                                Email = row["EMAIL"].ToString(),
                                Nome_Usuario = row["NOME_USUARIO"].ToString(),
                                Moderador = Convert.ToBoolean(row["CATEGORIA"])
                            }
                        };
                        lst.Add(receita);
                    }

                    return lst;
                }
            }
        }
    }
}
