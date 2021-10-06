using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class MainPage : System.Web.UI.Page
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["userName"] != null)

                {
                    lblName.Text = Session["userName"].ToString() + ":" + Session["userRole"].ToString();
                }
                           
            }
            catch
            {
                lblName.Text = "Error";
            }

        }
           protected void btnselect_Click(object sender, EventArgs e)

            {
                if (ddlredirect.SelectedValue == "Project/Science Page")
                {
                    Response.Redirect("ProjectView.aspx");
                }
                else if (ddlredirect.SelectedValue == "Registrations")
                {
                    Response.Redirect("RegForm.aspx");
                }
            }

        
        protected void ddlredirect_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
    }
