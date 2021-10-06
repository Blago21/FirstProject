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
    public partial class Administrator : System.Web.UI.Page
    {
        string m_userrole = "Admin";
        string m_username = "none";
        protected void Page_Load(object sender, EventArgs e)
        {       
          if (PreviousPage != null)
                {
                    try
                    {
                        m_userrole = ((Login)PreviousPage).UserRole;
                        m_username = ((Login)PreviousPage).UserName;
                    }

                    catch
                    {
                         try
                            {
                                m_userrole = ((Administrator)PreviousPage).UserRole;
                                m_username = ((Administrator)PreviousPage).UserName;
                            }

                            catch
                            {
                                m_userrole = "Admin";
                                m_username = "Error";
                            }
                        
                    }

                    lblName.Text = m_username + ":" + " " + m_userrole;
                }
                else lblName.Text = "Error";
            }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddladmin.SelectedIndex.Equals(2))
            {
                Response.Redirect("/RegForm.aspx");
            }
                if (ddladmin.SelectedIndex.Equals(1))
            {
                Response.Redirect("/Project insert.aspx");
            }
        }

        public string UserName
        {
            get { return m_username; }
        }

        public string UserRole
        {
            get { return m_userrole; }
        }

        protected void ddladmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}