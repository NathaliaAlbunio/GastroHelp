using GastroHelp.Models;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastroHelp.DataAccess
{
    public class CategoriaDAO
    {
        public void Inserir(Categoria obj)
        {
            using (SqlConnection conn =
                new SqlConnection(@"initial Catalog= GastroHelp;
                                Data Source=localhost;
                                   Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO categoria (nome) values (@nome);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
                                                                                                                                                        
        public List<Categoria> BuscarTodos()
        {
            var lst = new List<Categoria>();

            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog= GastroHelp;
                    Data Source=localhost;
                    Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM categoria;";

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
                        var categoria = new Categoria();
                        {
                            Id_categoria = Convert.ToInt32(row["Id_categoria"]),
                            Nome = row["nome"].ToString(),
                        };

                        lst.Add(categoria);
                    }
                }
            }
        }
    }
}





