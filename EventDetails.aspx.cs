using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class EventDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Label1.Text = "";

            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
           


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {


            cmd = new SqlCommand("select * from etable where ename=@ename and edate=@edate", con);
            cmd.Parameters.AddWithValue("ename", TextBox1.Text);
            cmd.Parameters .AddWithValue("edate",TextBox5 .Text );
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Event Details Already Inserted.....";
                return;
            }

            cmd = new SqlCommand("insert into etable values(@ename,@etype,@description,@venue,@edate)", con);
            cmd.Parameters.AddWithValue("ename", TextBox1.Text);
            cmd.Parameters.AddWithValue("etype", TextBox2.Text);
            cmd.Parameters.AddWithValue("description", TextBox3.Text);
            cmd.Parameters.AddWithValue("venue", TextBox4.Text);
            cmd.Parameters.AddWithValue("edate", TextBox5.Text);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Event Details Inserted.....";

        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";

        TextBox1.Focus();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            TextBox5.Text = "";
            Calendar1.Visible = true;
        }
        catch (Exception ex)
        {
           
            Label1.Text = ex.Message;
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox5.Text = "";
            string cd = DateTime.Now.ToString("dd-MMM-yyyy");
            string ed = Calendar1.SelectedDate.ToString("dd-MMM-yyyy");
            DateTime cdate = DateTime.Parse(cd);
            DateTime edate = DateTime.Parse(ed);
            TimeSpan ts = edate.Subtract(cdate);
            int no = ts.Days;
            if (no < 0)
            {
                Label1.Text = "Event Date Must Be Greater Than Or Equal To " + cd;
                return;
            }
            TextBox5.Text = ed;
            Calendar1.Visible = false;
        }
        catch (Exception ex)
        {
           
            Label1.Text = ex.Message;
        }
    }
   
}
