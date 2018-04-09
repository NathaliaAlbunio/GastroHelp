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
                string strSQL = @"INSERT INTO RECEITA (ID_CATEGORIA, ID_USUARIO, NIVEL_DIFICULDADE, INGREDIENTES, MODO_PREPARO, NOME_REC, RESUMO, RENDIMENTO, DICA, PUBLICADA, FOTO)
                                  VALUES (@ID_CATEGORIA, @ID_USUARIO, @NIVEL_DIFICULDADE, @INGREDIENTES, @MODO_PREPARO, @NOME_REC, @RESUMO, @RENDIMENTO, @DICA, @PUBLICADA, @FOTO);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@ID_CATEGORIA", SqlDbType.Int).Value = obj.Categoria.Id_Categoria;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = obj.Usuario.Id_Usuario;
                    cmd.Parameters.Add("@NIVEL_DIFICULDADE", SqlDbType.VarChar).Value = obj.Nivel_Dificuldade;
                    cmd.Parameters.Add("@INGREDIENTES", SqlDbType.VarChar).Value = obj.Ingredientes;
                    cmd.Parameters.Add("@MODO_PREPARO", SqlDbType.VarChar).Value = obj.Modo_Preparo;
                    cmd.Parameters.Add("@NOME_REC", SqlDbType.VarChar).Value = obj.Nome_Receita;
                    cmd.Parameters.Add("@RESUMO", SqlDbType.VarChar).Value = obj.Resumo;
                    cmd.Parameters.Add("@RENDIMENTO", SqlDbType.VarChar).Value = obj.Rendimento;
                    cmd.Parameters.Add("@DICA", SqlDbType.VarChar).Value = obj.Dica;
                    cmd.Parameters.Add("@PUBLICADA", SqlDbType.Bit).Value = obj.Publicada;
                    cmd.Parameters.Add("@FOTO", SqlDbType.VarChar).Value = obj.Foto;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public Receita BuscarPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT
	                                R.*,
	                                U.NOME AS NOME_USUARIO,
	                                C.NOME AS NOME_CATEGORIA
                                FROM RECEITA R 
                                INNER JOIN USUARIO U ON (U.ID_USUARIO = R.ID_USUARIO)
                                INNER JOIN CATEGORIA C ON (C.ID_CATEGORIA = R.ID_CATEGORIA)
                                WHERE ID_RECEITA = @ID_RECEITA;";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@ID_RECEITA", SqlDbType.Int).Value = id;
                    cmd.CommandText = strSQL;

                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    if (!(dt != null && dt.Rows.Count > 0))
                        return null;

                    var row = dt.Rows[0];
                    var receita = new Receita()
                    {
                        Id_Receita = Convert.ToInt32(row["ID_RECEITA"]),
                        Nome_Receita = row["NOME_REC"].ToString(),
                        Resumo = row["RESUMO"].ToString(),
                        Categoria = new Categoria()
                        {
                            Id_Categoria = Convert.ToInt32(row["ID_CATEGORIA"]),
                            Nome = row["NOME_CATEGORIA"].ToString()
                        },
                        Usuario = new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]),
                            Nome = row["NOME_USUARIO"].ToString()
                        },
                        Nivel_Dificuldade = row["NIVEL_DIFICULDADE"].ToString(),
                        Ingredientes = row["INGREDIENTES"].ToString(),
                        Modo_Preparo = row["MODO_PREPARO"].ToString(),
                        Rendimento = row["RENDIMENTO"].ToString(),
                        Dica = row["DICA"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["DATA_CADASTRO"]),
                        Publicada = Convert.ToBoolean(row["PUBLICADA"]),
                        Foto = row["FOTO"].ToString()
                    };

                    return receita;
                }
            }
        }

        public List<Receita> BuscarTodos()
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                var lst = new List<Receita>();
                string strSQL = @"SELECT 
	                                R.*,
	                                U.NOME AS NOME_USUARIO,
	                                C.NOME AS NOME_CATEGORIA
                                FROM RECEITA R 
                                INNER JOIN USUARIO U ON (U.ID_USUARIO = R.ID_USUARIO)
                                INNER JOIN CATEGORIA C ON (C.ID_CATEGORIA = R.ID_CATEGORIA);";

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
                            Nome_Receita = row["NOME_REC"].ToString(),
                            Resumo = row["RESUMO"].ToString(),
                            Categoria = new Categoria()
                            {
                                Id_Categoria = Convert.ToInt32(row["ID_CATEGORIA"]),
                                Nome = row["NOME_CATEGORIA"].ToString()
                            },
                            Usuario = new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]),
                                Nome = row["NOME_USUARIO"].ToString()
                            },
                            Nivel_Dificuldade = row["NIVEL_DIFICULDADE"].ToString(),
                            Ingredientes = row["INGREDIENTES"].ToString(),
                            Modo_Preparo = row["MODO_PREPARO"].ToString(),
                            Rendimento = row["RENDIMENTO"].ToString(),
                            Dica = row["DICA"].ToString(),
                            DataCadastro = Convert.ToDateTime(row["DATA_CADASTRO"]),
                            Publicada = Convert.ToBoolean(row["PUBLICADA"]),
                            Foto = row["FOTO"].ToString()
                        };
                        lst.Add(receita);
                    }

                    return lst;
                }
            }
        }
    }
}
