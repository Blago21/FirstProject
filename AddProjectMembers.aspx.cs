using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace WebApplication2
{
    public partial class AddProjectMembers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                {
                    lblinfo.Text = Session["userName"].ToString() + ":" + Session["userRole"].ToString() + "\\" + Session["IDProject"].ToString();
                }
            }
            catch
            {
                lblinfo.Text = "Error";
            }
            
            if (!IsPostBack)
            {
                DropDownPerson();
                DropDownProject();
                MembersList();

                if ((Session["userRole"].ToString()).CompareTo("Admin") == 0)
                {
                    btnadd.Visible = true;
                    btndelete.Visible = true;
                }
                else
                {
                    btnadd.Visible = false;
                    btndelete.Visible = false;
                }
            }
        }
        protected void Display_db()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select FirstName from Project;";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        protected void DropDownPerson()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("select FirstName,IDEmployee from Registration");
            cmd.ExecuteNonQuery();
            ddlPerson.DataSource = cmd.ExecuteReader();
            ddlPerson.DataTextField = "FirstName";
            ddlPerson.DataValueField = "IDEmployee";
            ddlPerson.DataBind();
            con.Close();
        }
        protected void DropDownProject()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("select * from RolsProjects");
            cmd.ExecuteNonQuery();
            ddlSM.DataSource = cmd.ExecuteReader();
            ddlSM.DataTextField = "Name_Role";
            ddlSM.DataBind();
            con.Close();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        { 
            try
            {
                con.Open();
                int IDPerson = 0;
                Int32.TryParse(ddlPerson.SelectedValue, out IDPerson);
                int IDProject = 0;
                Int32.TryParse(Session["IDProject"].ToString(), out IDProject);
                SqlCommand com = con.CreateCommand();
                com.CommandText = "INSERT into ProjectMembers values (" + IDProject + "," + IDPerson + ",'" + ddlSM.Text + "')";
                com.CommandType = CommandType.Text;
                com.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                con.Close();
              }
            catch
            {
                lblinfo.Text = "Error";
            }
            finally { con.Close(); }
        }
        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void MembersList()
        {
            con.Open();
            int IDProject = 0;
            Int32.TryParse(Session["IDProject"].ToString(), out IDProject);
            string command = "select FirstName,LastName,IDEmployee from Registration WHERE IDEmployee in (select IDEmployee from ProjectMembers WHERE IDProject = " + IDProject + ")";
           // con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            lbmembers.Items.Clear();
            lbmembers.DataSource = cmd.ExecuteReader();
            lbmembers.DataTextField = "FirstName";
            lbmembers.DataValueField = "IDEmployee";
            lbmembers.DataBind();
            con.Close();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            con.Open();
            int IDProject = 0;
            Int32.TryParse(Session["IDProject"].ToString(), out IDProject);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int PersonID = 0;
            Int32.TryParse(lbmembers.SelectedItem.Value, out PersonID);
            cmd.CommandText = "delete from ProjectMembers where IDEmployee =" + PersonID + " AND IDProject =  " + IDProject;
            cmd.ExecuteNonQuery();
            lbmembers.Items.RemoveAt(lbmembers.Items.IndexOf(lbmembers.SelectedItem));
            con.Close();
        }
    }
}
