using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda
{
    public partial class Contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInserirContato_Click(object sender, EventArgs e)
        {
            //Validação de Campos
            try
            {
                if (txbEmail.Text != null 
                    && txbEmail.Text != "" 
                    && txbNome.Text != null
                    || txbNome.Text != ""
                    && txbTelefone.Text != null
                    || txbTelefone.Text != "")
                {

                    // capturar a string de conexão
                    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                    System.Configuration.ConnectionStringSettings connStrig;
                    connStrig = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
                    // Cria um objeto de conexão 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = connStrig.ToString();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into contato (nome, email, telefone) values (@nome, @email, @telefone)";
                    cmd.Parameters.AddWithValue("nome", txbNome.Text);
                    cmd.Parameters.AddWithValue("email", txbEmail.Text);
                    cmd.Parameters.AddWithValue("telefone", txbTelefone.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                else
                {
                    throw new Exception("Campos em Branco");
                }
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
        }
    }
}