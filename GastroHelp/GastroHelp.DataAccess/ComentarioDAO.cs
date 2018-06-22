using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GastroHelp.DataAccess
{
    public class ComentarioDAO
    {
        public void EnviarComentario(Comentario obj)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                string strSQL = @"INSERT INTO COMENTARIO (TEXTO, ID_USUARIO, ID_RECEITA) VALUES (@TEXTO, @ID_USUARIO, @ID_RECEITA);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar).Value = obj.Texto;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = obj.Usuario.Id_Usuario;
                    cmd.Parameters.Add("@ID_RECEITA", SqlDbType.Int).Value = obj.Receita.Id_Receita;

                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public List<Comentario> BuscarPorReceita(int receita)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                var lst = new List<Comentario>();
                string strSQL = @"SELECT 
                                      C.*,
                                      U.ID_USUARIO,
                                      U.NOME AS NOME_USUARIO,
                                      R.ID_RECEITA
                                  FROM COMENTARIO C 
                                  INNER JOIN USUARIO U ON (U.ID_USUARIO = C.ID_USUARIO)
                                  INNER JOIN RECEITA R ON (R.ID_RECEITA = C.ID_RECEITA)
                                  WHERE C.ID_RECEITA = @ID_RECEITA;";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@ID_RECEITA", SqlDbType.Int).Value = receita;
                    cmd.CommandText = strSQL;

                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var comentario = new Comentario
                        {
                            Id_Comentario = Convert.ToInt32(row["ID_COMENTARIO"]),
                            Texto = row["TEXTO"].ToString(),
                            DataHora = Convert.ToDateTime(row["DATAHORA"]),
                            Usuario = new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]),
                                Nome = row["NOME_USUARIO"].ToString()
                            },
                            Receita = new Receita()
                            {
                                Id_Receita = Convert.ToInt32(row["ID_RECEITA"]),
                            }
                        };

                        lst.Add(comentario);
                    }

                    return lst;
                }
            }
        }
    }
}
