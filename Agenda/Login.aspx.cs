using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            String email = txbemail.Text;
            String senha = txbsenha.Text;

            // capturar a string de conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connStrig;
            connStrig = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            // Cria um objeto de conexão 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connStrig.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from usuario where email =@email and senha = @senha";
            cmd.Parameters.AddWithValue("email", txbemail.Text);
            cmd.Parameters.AddWithValue("senha", txbsenha.Text);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                //cookie 
                HttpCookie login = new HttpCookie("login", txbemail.Text);
                Response.Cookies.Add(login);
//              Response.Cookies.Add(new HttpCookie("senha", txbsenha.Text));
                // DIRECIONAR PARA A PAGINA PRINCIPAL
                HttpContext.Current.Response.Redirect("~/index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Login Incorreto!')</script>");
               // IMsg.Text = "Email ou Senha incorretos!";
            }
          
        }
    }
}