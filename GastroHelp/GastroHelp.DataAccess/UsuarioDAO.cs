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
    public class UsuarioDAO
    {
        public void Inserir(Usuario obj)
        {

            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=GastroHelp;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {

                string strSQL = @"INSERT INTO usuario (nome, endereco, telefone, mensagem) 
                                  VALUES (@nome, @endereco, @telefone, @mensagem);";


                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.nome;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = obj.senha;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email;
                    cmd.Parameters.Add("@nome_usuario", SqlDbType.VarChar).Value = obj.nome_usuario;
                    cmd.Parameters.Add("@moderador", SqlDbType.Bit).Value = obj.moderador;



                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public List<Usuario> BuscarTodos()
        {
            var lstUsuario = new List<Usuario>();

            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=GastroHelp;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM usuario;";

                using (SqlCommand cmd = new SqlCommand(strSQL))

                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = strSQL;


                var dataReader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dataReader);

                conn.Close();

                //Percorrendo todos os registros encontrados na base de dados e adicionando em uma lista
                foreach (DataRow row in dt.Rows)
                {
                    var usuario = new Usuario()
                    {
                        id_usuario = Convert.ToInt32(row["id_usuario"]),
                        nome = row["nome"].ToString(),
                        senha = row["senha"].ToString(),
                        email = row["email"].ToString(),
                        nome_usuario = row["nome_usuario"].ToString()
                    };

                    lstUsuario.Add(usuario);
                }
            }

            return lstUsuario;
        }
    }
}
