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

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
        Menu m1 = (Menu)Master.FindControl("Menu1");
        m1.Visible = true;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      if(TextBox1.Text .Equals ("Admin") && TextBox2 .Text .Equals ("Admin"))
          Response.Redirect("StaffDetails.aspx");
        else
            Label1.Text = "Invalid UserName Or Password.....";
    }
}
