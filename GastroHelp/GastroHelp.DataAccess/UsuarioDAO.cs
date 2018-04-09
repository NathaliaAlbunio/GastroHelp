using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GastroHelp.DataAccess
{
    public class UsuarioDAO
    {
        public void Inserir(Usuario obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO USUARIO (NOME, SENHA, EMAIL, NOME_USUARIO, MODERADOR) 
                                  VALUES (@NOME, @SENHA, @EMAIL, @NOME_USUARIO, @MODERADOR);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = obj.Senha;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = obj.Email;
                    cmd.Parameters.Add("@NOME_USUARIO", SqlDbType.VarChar).Value = obj.Nome_Usuario;
                    cmd.Parameters.Add("@MODERADOR", SqlDbType.Bit).Value = obj.Moderador;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Usuario> BuscarTodos()
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog= GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                var lst = new List<Usuario>();
                string strSQL = @"SELECT * FROM USUARIO;";

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
                        var usuario = new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]),
                            Nome = row["NOME"].ToString(),
                            Senha = row["SENHA"].ToString(),
                            Email = row["EMAIL"].ToString(),
                            Nome_Usuario = row["NOME_USUARIO"].ToString(),
                            Moderador = Convert.ToBoolean(row["MODERADOR"])
                        };

                        lst.Add(usuario);
                    }
                }

                return lst;
            }
        }
    }
}
