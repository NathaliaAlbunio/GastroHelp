using GastroHelp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GastroHelp.WebUI
{
    public partial class PesquisaReceita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        } 

             public List<Receita> Pesquisar()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString))
            {
                var lst = new List<Receita>();
                string strSQL = @"SELECT 
	                                R.*,
	                            FROM RECEITA R ;";

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
                        var receita = new Receita()
                        {
                            Id_Receita = Convert.ToInt32(row["ID_RECEITA"]),
                            Nome_Receita = row["NOME_REC"].ToString(),
                            Resumo = row["RESUMO"].ToString(),

                        };
                        lst.Add(receita);
                    }

                    return lst;
                }
            }
        }
    }
    }
