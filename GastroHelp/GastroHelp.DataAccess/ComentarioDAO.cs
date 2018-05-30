using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastroHelp.DataAccess
{
    public class ComentarioDAO
    {
        public void EnviarComentario(Comentario obj)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                string strSQL = @"Insert into comentario (texto, id_usuario, id_receita) values (@texto, @id_usuario, @id_receita);";

                using (SqlCommand cmdo = new SqlCommand(strSQL))
                {
                    cmdo.Connection = conn;
                    cmdo.Parameters.Add("@texto", SqlDbType.VarChar).Value = obj.texto;
                    cmdo.Parameters.Add("@id_usuario", SqlDbType.Int).Value = obj.Usuario.Id_Usuario;
                    cmdo.Parameters.Add("@id_receita", SqlDbType.Int).Value = obj.Receita.Id_Receita;

                    conn.Open();
                    cmdo.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public List<Comentario> BuscarComentario()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                var lst = new List<Comentario>();
                string strSQL = @"SELECT 
                                        C.*,
                                        U.id_usuario,
                                        R.id_receita
                                        from comentario C 
                                         INNER JOIN USUARIO U ON (U.ID_USUARIO = C.ID_USUARIO)
                                INNER JOIN receita R ON (R.ID_RECEITA = C.ID_RECEITA);";
                using (SqlCommand cmdo = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmdo.Connection = conn;
                    cmdo.CommandText = strSQL;

                    var dataReader = cmdo.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var comentario = new Comentario
                        {
                            id_comentario = Convert.ToInt32(row["id_comentario"]),
                            texto = row["texto"].ToString(),
                            DataHora = Convert.ToDateTime(row["DataHora"]),
                            Usuario = new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(row["Id_Usuario"]),
                            },
                            Receita = new Receita()
                            {
                                Id_Receita = Convert.ToInt32(row["Id_Receita"]),
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
