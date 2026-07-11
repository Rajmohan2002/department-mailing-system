using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ParentViewStudentAttendance : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {

                if (Session["RegNo"] != null && Session["SName"] != null)
                {
                    TextBox1.Text = Session["RegNo"].ToString();
                    TextBox2.Text = Session["SName"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select  Semester.....";
                return;
            }
            if (DropDownList1.SelectedIndex == 7)
            {
                adp = new SqlDataAdapter("select * from attendancetable where regno=@regno ", con);
                adp.SelectCommand.Parameters.AddWithValue("regno", TextBox1.Text);
                dt = new DataTable();
                adp.Fill(dt);
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {

                adp = new SqlDataAdapter("select * from attendancetable where regno=@regno and semester=@semester", con);
                adp.SelectCommand.Parameters.AddWithValue("regno", TextBox1.Text);
                adp.SelectCommand.Parameters.AddWithValue("semester", DropDownList1.SelectedItem.Text);
                dt = new DataTable();
                adp.Fill(dt);
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}