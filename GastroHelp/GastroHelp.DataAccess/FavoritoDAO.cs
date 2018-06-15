using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GastroHelp.DataAccess
{
    public class FavoritoDAO
    {
        public void Favoritar(Favorito obj)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                string strSQL = @"INSERT INTO FAVORITO (ID_RECEITA, ID_USUARIO)
                                  VALUES (@ID_RECEITA, @ID_USUARIO);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@ID_RECEITA", SqlDbType.Int).Value = obj.Receita.Id_Receita;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = obj.Usuario.Id_Usuario;

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

        public List<Favorito> Buscar(int receita, int usuario)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                var lst = new List<Favorito>();
                string strSQL = @"SELECT * FROM FAVORITO WHERE ID_RECEITA = @ID_RECEITA AND ID_USUARIO = @ID_USUARIO;";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@ID_RECEITA", SqlDbType.Int).Value = receita;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = usuario;
                    cmd.CommandText = strSQL;

                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var favorito = new Favorito()
                        {
                            Id_favorito = Convert.ToInt32(row["ID_FAVORITO"]),
                            Receita = new Receita() { Id_Receita = Convert.ToInt32(row["ID_RECEITA"]) },
                            Usuario = new Usuario() { Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]) }
                        };

                        lst.Add(favorito);
                    }
                }

                return lst;
            }
        }
    }
}
