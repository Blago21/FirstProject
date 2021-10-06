using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication2
{
    public partial class GuestViwe : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           try
            {
               {
                    lblName.Text = Session["userName"].ToString() + ":" + Session["userRole"].ToString();
               }

            }
            catch
            {
                lblName.Text = "Error";
            }
              if (con.State == ConnectionState.Open)
              {
                  con.Close();
              }
              con.Open();
           
            if ((Session["userRole"].ToString()).CompareTo("Admin") == 0)
            {
                btnupdate.Enabled = true;
            }
            else
            {
                btnupdate.Enabled = false;
            }
        }
        protected void Display_db()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Project;";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No Data";
               GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            getProject();
            getScienceDegree();
        }

        private void getProject()
        {
            String choice = ddlchoice.Text.Trim();
            String param = ddlparamet.Text.Trim();
            String tbox = txtparam.Text.Trim();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == "Project")
            {
                //cmd.CommandText = "select * from Project ";
                cmd.CommandText = "select * from Project where " + param + "=" + "\'" + tbox + "\'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        private void getProjects()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Project";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void getScienceDegree()
        {
            String choice = ddlchoice.Text.Trim();
            String param = ddlparamet.Text.Trim();
            String tbox = txtparam.Text.Trim();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == "ScienceDegree")
            {
                //cmd.CommandText = "select * from Project ";
                cmd.CommandText = "select * from ScienceDegree where " + param + "=" + "\'" + tbox + "\'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void getScienceDegrees()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from ScienceDegree";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void ddlchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            String choice = ddlchoice.Text.Trim();
            if (choice == "Project")
            {
                ddlparamet.Items.Clear();
                ddlparamet.Items.Add("ID_Project");
                ddlparamet.Items.Add("Name_Project");
                ddlparamet.Items.Add("Start_Project");
                ddlparamet.Items.Add("Finish_Project");
                getProjects();
            }
            else if (choice == "ScienceDegree")
            {
                ddlparamet.Items.Clear();
                ddlparamet.Items.Add("IDProject");
                ddlparamet.Items.Add("NameP");
                ddlparamet.Items.Add("Start");
                ddlparamet.Items.Add("Finish");
                getScienceDegrees();
            }

        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            {
                if (ddlchoice.Text == "Project")

                    Response.Redirect("Project insert.aspx");


                else if (ddlchoice.Text == "ScienceDegree")

                    Response.Redirect("~/Scienceinsert.aspx");

            }
        }
        protected void ddlparamet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlchoice_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
