using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        string m_userrole = "Guest";
        string m_username = "none";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();          
        }
       
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
 
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
            try
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dbo.Registration where UserName = '" + UserName + "' and Password = '" + Password + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
               
                if (dt.Rows.Count > 0)
                {
                    m_username = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
                    m_userrole = dt.Rows[0][7].ToString();
                    Session["userName"] = m_username;
                    Session["userRole"] = m_userrole;
                    Response.Redirect("MainPage");
                }
                else
                {
                    lblmessage.Text = "Грешно потребителско име или парола";
                    lblmessage.Visible = true;
                }
            }
            catch (System.Data.DataException ex)
            {

                lblmessage.Text = "Проблем с ADO адаптер";
                lblmessage.Visible = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lblmessage.Text = "Проблем с връзката на базата данни ";
                lblmessage.Visible = true;
            }

            finally {con.Close(); }

    }
        public string UserName
        {
            get { return m_username; }
        }

        public string UserRole
        {
            get { return m_userrole; }
        }
    }


  
}