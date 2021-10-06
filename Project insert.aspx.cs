using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WebApplication2
{
    public partial class Project_insert : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
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
        }
        protected void Display_db()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Project";
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
        void Clear()
        {
            txtNP.Text = "";
            txtstart.Text = "";
            txtfinish.Text = "";
            txttype.Text = "";
            txtworkf.Text = "";
            txtfp.Text = "";
            txtbudget.Text = "";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNP.Text.Trim().Length == 0)
                    lblError.Text = "Моля въведете име на проекта!";
                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    String Myquery = "INSERT into Project (Name_Project,Start_Project,Finish_Project,Type,Workflow,FinancePlan,Budget) values ('" + txtNP.Text.Trim() + "','" + txtstart.Text + "','" + txtfinish.Text + "','" + txttype.Text.Trim() + "' ,'" + txtworkf.Text.Trim() + "', '" + txtfp.Text.Trim() + "', '" + txtbudget.Text.Trim() + "')";
                    cmd.CommandText = Myquery;
                    cmd.ExecuteNonQuery();
                    lblsave.Visible = true;
                    lblsave.Text = "Данните са въведини успешно!";
                    Clear();
                    Display_db();       
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lblError.Text = "Въведените данни съществуват! ";
                lblError.Visible = true;
            }

            finally { con.Close(); }
        }
          
        protected void Update_Click(object sender, EventArgs e)
        {
            SqlCommand com = con.CreateCommand();
            com.CommandText = ("UPDATE [Project] SET [Name_Project]=@a1,Start_Project=@a2,Finish_Project=@a3,Type=@a4,Workflow=@a5,FinancePlan=@a6,Budget=@a7 WHERE [ID_Project]=@a8 ");

            com.CommandType = CommandType.Text;

            com.Parameters.AddWithValue("a1",txtNP.Text);
            com.Parameters.AddWithValue("a2",txtstart.Text);
            com.Parameters.AddWithValue("a3", txtfinish.Text);
            com.Parameters.AddWithValue("a4", txttype.Text);
            com.Parameters.AddWithValue("a5", txtworkf.Text);
            com.Parameters.AddWithValue("a6", txtfp.Text);
            com.Parameters.AddWithValue("a7", txtbudget.Text);
            com.Parameters.AddWithValue("a8", txtID.Text);
            com.ExecuteNonQuery();
            com.CommandText = "select * from Project";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            Display_db();
            lblsave.Text = "Успешно редактиране !";
        }
        protected void btndelete_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Project where Name_Project ='" + txtNP.Text + "' OR ID_Project = '" + txtID.Text + "'";
            cmd.ExecuteNonQuery();
            lblsave.Visible = true;
            lblsave.Text = "Данните са изтрити успешно!";
            Clear();
            txtNP.Text = "";
            Display_db();
            Clear();
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            Display_db();
        }
        protected void lnkEdit_Click(object sender, EventArgs e)            
        {
            int ID_Project = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Project where ID_Project = " + ID_Project.ToString();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtID.Text = dt.Rows[0]["ID_Project"].ToString();
            txtNP.Text = dt.Rows[0]["Name_Project"].ToString();
            txtstart.Text = dt.Rows[0]["Start_Project"].ToString();
            txtfinish.Text = dt.Rows[0]["Finish_Project"].ToString();
            txttype.Text = dt.Rows[0]["Type"].ToString();
            txtworkf.Text = dt.Rows[0]["Workflow"].ToString();
            txtfp.Text = dt.Rows[0]["FinancePlan"].ToString();
            txtbudget.Text = dt.Rows[0]["Budget"].ToString();
            btnaddPM.Enabled = true;
        }
        protected void btnaddPM_Click(object sender, EventArgs e)
        {
            Session["IDProject"] = txtID.Text;
            Response.Redirect("AddProjectMembers.aspx");
        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FilesUpload.HasFile)
                foreach (HttpPostedFile uploadedFile in FilesUpload.PostedFiles)
                    try
                    {
                        uploadedFile.SaveAs(Server.MapPath("~/uploads/") +
                                            uploadedFile.FileName);
                        FileUploadedList.Text += "File name: " +
                           uploadedFile.FileName + "<br>" +
                           uploadedFile.ContentLength + " kb<br>" +
                           "Content type: " + uploadedFile.ContentType + "<br><br>";
                    }
                    catch (Exception ex)
                    {
                        FileUploadedList.Text = "ERROR: " + ex.Message.ToString();
                    }
            else
            {
                FileUploadedList.Text = "Моля , изберете файл....";
            }
        }

    }
}
   