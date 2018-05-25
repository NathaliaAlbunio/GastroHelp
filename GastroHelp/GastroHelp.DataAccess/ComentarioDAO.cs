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
        public void EnviarComentario (Comentario obj)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                string strSQL = @"Insert into comentario (texto), (DataHora) values (@texto), (@DataHora);";

                using (SqlCommand cmdo = new SqlCommand(strSQL))
                {
                    cmdo.Connection = conn;
                    cmdo.Parameters.Add("@texto", SqlDbType.VarChar).Value = obj.texto;
                    cmdo.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = obj.DataHora;
                    conn.Open();

                    cmdo.ExecuteNonQuery();
                    conn.Close();
                    
                }
            }
        }

    }
}
