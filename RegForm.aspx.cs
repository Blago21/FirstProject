using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace WebApplication2
{
    public partial class RegForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True");
        protected void Page_Init(object sender, EventArgs e)
        { 

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                {
                    lblsave.Text = Session["userName"].ToString() + ":" + Session["userRole"].ToString();
                }
            }
            catch
            {
                lblError.Text = "Error";
            }


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (!IsPostBack)
            {
                DropDownRole();
                                
            }
        }
        protected void DropDownRole()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("select Name_Project from Project");
            cmd.ExecuteNonQuery();
            ddlassignedrole.DataSource = cmd.ExecuteReader();
            ddlassignedrole.DataBind();

            ListItem li = new ListItem("--Select--", "-1");
            ddlassignedrole.Items.Insert(0, li);
        }
        protected void Display_db()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration";
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
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemail.Text = "";
            txtgender.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtconfirmpassword.Text = "";
            ddlrole.Text = ddlrole.Items[0].Text;
            lblmessage.Text = "";
            lblsave.Text = "";
            lblError.Text = "";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusername.Text == "" || txtpassword.Text == "" || txtfirstname.Text == "")

                    lblError.Text = "Моля попълнете всички полета!";

                else if (txtpassword.Text != txtconfirmpassword.Text)
                    lblError.Text = "Паролата не съвпада!";
                else if (txtpassword.Text.Length < 8)
                    lblError.Text = "Паролата трябва да съдържа минимум 8 символа!";
                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT into Registration values  ('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtemail.Text + "', '" + txtgender.Text + "' ,'" + txtusername.Text + "','" + txtpassword.Text + "', '" + ddlrole.Text + "','" + ddlassignedrole.Text + "')";
                    cmd.ExecuteNonQuery();
                    lblsave.Visible = true;
                    Clear();
                    lblsave.Text = "Регистрацията е направена успешно!";    
                    Display_db();
                    
                }
            }
            catch (System.Data.DataException ex)
            {
                lblmessage.Text = "Проблем с ADO адаптер";
                lblmessage.Visible = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lblmessage.Text = "Потребителят съществува в базата данни!";
                lblmessage.Visible = true;
            }

            finally { con.Close(); }
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            Display_db();
        }
        protected void btndelete_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Registration where FirstName ='" + txtfirstname.Text + "' OR UserName ='" + txtusername.Text + "'";
            cmd.ExecuteNonQuery();
            Clear();
            lblsave.Text = "Данните са изтрити успешно!";
           
            txtfirstname.Text = "";
            txtusername.Text = "";

            Display_db();          
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            SqlCommand com = con.CreateCommand();
            com.CommandText = ("UPDATE [Registration] SET [FirstName]=@a1,LastName=@a2,EmailAddress=@a3,Gender=@a4,UserName=@a5,Password=@a6,Role=@a7,Project_assigned=@a8 WHERE [IDEmployee]=@a9");

            com.CommandType = CommandType.Text;

            com.Parameters.AddWithValue("a1", txtfirstname.Text);
            com.Parameters.AddWithValue("a2", txtlastname.Text);
            com.Parameters.AddWithValue("a3", txtemail.Text);
            com.Parameters.AddWithValue("a4", txtgender.Text);
            com.Parameters.AddWithValue("a5", txtusername.Text);
            com.Parameters.AddWithValue("a6", txtpassword.Text);
            com.Parameters.AddWithValue("a7", ddlrole.Text);
            com.Parameters.AddWithValue("a8", ddlassignedrole.Text);
            com.Parameters.AddWithValue("a9", txtEmployee.Text);
            com.ExecuteNonQuery();
            com.CommandText = "select * from Registration";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            Display_db();
            lblsave.Text = "Успешно редактиране !";
        }
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        protected void DisplayDataInDynamicallyTable(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }
        private void BindData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-CDVIPL2\BARO;Initial Catalog=VUTP;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Registration", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            htmlTable.Append("<table border='1'>");
            htmlTable.Append("<tr style='background-color:white; color: black;'><th>First Name.</th><th>Last Name</th><th>Email Address</th><th>Gender</th><th>User Name</th><th>Password</th><th>Role</th></tr>");

            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        htmlTable.Append("<tr style='color: White;'>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["FirstName"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["LastName"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["EmailAddress"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Gender"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["UserName"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Password"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Role"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Project_assigned"] + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    //  DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td align='center' colspan='4'>There is no Record.</td>");
                    htmlTable.Append("</tr>");
                }
            }
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            int IDEmployee = Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration where IDEmployee = " + IDEmployee.ToString();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            txtEmployee.Text = dt.Rows[0]["IDEmployee"].ToString();
            txtfirstname.Text = dt.Rows[0]["FirstName"].ToString();
            txtlastname.Text = dt.Rows[0]["LastName"].ToString();
            txtemail.Text = dt.Rows[0]["EmailAddress"].ToString();
            txtgender.Text = dt.Rows[0]["Gender"].ToString();
            txtusername.Text = dt.Rows[0]["UserName"].ToString();
            txtpassword.Text = dt.Rows[0]["Password"].ToString();
            ddlrole.Text = dt.Rows[0]["Role"].ToString();
            ddlassignedrole.Text = dt.Rows[0][8].ToString();
        }
        protected void btnexit_Click1(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }
        protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlassignedrole_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}


    
