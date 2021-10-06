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
    public partial class Scienseinsert : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        protected void Display_db()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ScienceDegree";
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
            txtName.Text = "";
            txtstart.Text = "";
            txtfinish.Text = "";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")

                    lblError.Text = "Моля въведете име на проекта!";
                else
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT into ScienceDegree values  ('" + txtName.Text + "','" + txtstart.Text + "','" + txtfinish.Text + "')";
                    cmd.ExecuteNonQuery();
                    lblsave.Visible = true;
                    lblsave.Text = "Данните са въведини успешно!";

                    txtName.Text = "";
                    txtstart.Text = "";
                    txtfinish.Text = "";

                    Display_db();

                    Clear();
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
            try
            {
                if (txtName.Text == " ")
                    lblError.Text = "Моля въведете име на проекта!";
                SqlCommand com = con.CreateCommand();
                com.CommandText = ("UPDATE [ScienceDegree] SET [NameP]=@a1,Start=@a3,Finish=@a4 WHERE [IDProject]=@a8 ");
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("a8", txtIDProject.Text);
                com.Parameters.AddWithValue("a3", txtstart.Text);
                com.Parameters.AddWithValue("a4", txtfinish.Text);
                com.Parameters.AddWithValue("a1", txtName.Text);
                com.ExecuteNonQuery();
                com.CommandText = "select * from ScienceDegree";
                com.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                Display_db();
                lblsave.Text = "Успешно редактиране !";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lblError.Text = "Въведените данни съществуват! ";
                lblError.Visible = true;
            }

            finally { con.Close(); }
        }
        protected void btndelete_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ScienceDegree where NameP ='" + txtName.Text + "'";
            cmd.ExecuteNonQuery();
            lblsave.Text = "Данните са изтрити успешно!";
            Clear();
            Display_db();
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            Display_db();
        }
        protected void lnkEdit_Click(object sender, EventArgs e)

        {
            int IDProject = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ScienceDegree WHERE IDProject =" + IDProject.ToString();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtIDProject.Text = dt.Rows[0]["IDProject"].ToString();
            txtName.Text = dt.Rows[0]["NameP"].ToString();
            txtstart.Text = dt.Rows[0]["Start"].ToString();
            txtfinish.Text = dt.Rows[0]["Finish"].ToString();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDEmployee = Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtName.Text = dt.Rows[0]["Name SD"].ToString();
            txtstart.Text = dt.Rows[0]["Start_Project"].ToString();
            txtfinish.Text = dt.Rows[0]["Finish_Project"].ToString();
        }
    }
}