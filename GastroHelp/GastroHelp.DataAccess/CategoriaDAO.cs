using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GastroHelp.DataAccess
{
    public class CategoriaDAO
    {
        public void Inserir(Categoria obj)
        {
            using (SqlConnection conn = new SqlConnection(@"initial Catalog= GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO CATEGORIA (NOME) VALUES (@NOME);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Categoria> BuscarTodos()
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog= GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                var lst = new List<Categoria>();
                string strSQL = @"SELECT * FROM CATEGORIA;";

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
                            Id_Categoria = Convert.ToInt32(row["ID_CATEGORIA"]),
                            Nome = row["NOME"].ToString()
                        };

                        lst.Add(categoria);
                    }
                }

                return lst;
            }
        }
    }
}