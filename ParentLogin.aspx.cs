using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class ParentLogin : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
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
            cmd = new SqlCommand("Select * from studtable where  regno=@regno  and sname=@sname", con);

            cmd.Parameters.AddWithValue("regno", TextBox1.Text);
            cmd.Parameters.AddWithValue("sname", TextBox2.Text);

            rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                string emailid = rs["mailid"].ToString();
                string regno = TextBox1.Text;
                Session.Add("PEMailID", emailid);
                Session.Add("RegNo", regno);
                Session.Add("SName", TextBox2.Text);

                rs.Close();
                cmd.Dispose();

                Response.Redirect("ParentViewStudentFeedback.aspx");
              


            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid Regisitration Number and Student Name....";
            }
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }
    }
}
