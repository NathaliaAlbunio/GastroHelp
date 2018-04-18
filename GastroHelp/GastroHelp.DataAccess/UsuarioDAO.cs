﻿using GastroHelp.Models;
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

        public Usuario Logar(Usuario obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=GastroHelp; Data Source=localhost; Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM USUARIO WHERE NOME_USUARIO = @NOME_USUARIO AND SENHA = @SENHA";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@NOME_USUARIO", SqlDbType.VarChar).Value = obj.Nome_Usuario;
                    cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = obj.Senha;

                    cmd.CommandText = strSQL;

                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    if (!(dt != null && dt.Rows.Count > 0))
                        return null;

                    var row = dt.Rows[0];
                    var usuario = new Usuario()
                    {

                        Id_Usuario = Convert.ToInt32(row["ID_USUARIO"]),
                        Nome = row["NOME"].ToString(),
                        Senha = row["SENHA"].ToString(),
                        Email = row["EMAIL"].ToString(),
                        Nome_Usuario = row["NOME_USUARIO"].ToString(),
                        Moderador = Convert.ToBoolean(row["MODERADOR"])
                    };

                    return usuario;
                }
            }
        }

        private void CarregarReceitasAprovacao()
        {
            var lstReceitas = new List<Receita>();

            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=GastroHelp;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT 
                                      r.*,
                                      c.nome as categoria
                                  FROM receita r
                                  INNER JOIN categoria c on (r.id_categoria = c.id_categoria)";

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
                            Id_Receita = Convert.ToInt32(row["id_receita"]),
                            Nome_Receita = row["nome_rec"].ToString(),
                            Usuario = new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(row["id_usuario"]),
                                Nome = row["usuario"].ToString()
                            },

                        };
                        lstReceitas.Add(receita);
                    }
                }
            }
        }
    }
}
