using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ParentViewEventDetails : System.Web.UI.Page
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

                adp = new SqlDataAdapter("select * from etable", con);
                dt = new DataTable();
                adp.Fill(dt);
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