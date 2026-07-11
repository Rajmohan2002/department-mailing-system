using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewStudentDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds;
    
    
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
                if(Session ["RegNo"]!=null )
                bindview();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindview()
    {

        try
        {
            adp = new SqlDataAdapter("select s2.regno,sname,gender,dob,fname,address1,address2  ,city,contactno,mailid,medium,s1.byear,year,semester,studphoto from studsemtable s1,studtable s2 where s1.regno=s2.regno and s2.regno=@regno and csemstatus='CurrentSem'", con);
            adp.SelectCommand.Parameters.AddWithValue("regno", Session["RegNo"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}