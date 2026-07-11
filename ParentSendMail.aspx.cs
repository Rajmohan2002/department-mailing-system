using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;

public partial class ParentSendMail : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Label1.Text = "";

            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            TextBox2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!IsPostBack)
            {
                if (Session["PEMailID"] != null && Session["RegNo"] != null && Session["SName"] != null)
                {
                    TextBox1.Text = Session["PEMailID"].ToString();
                    
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void mailcoding()
    {
        string data = "<br>Registration Number :" + Session["RegNo"].ToString() + "<br>Student Name :" + Session["SName"].ToString() + "<br>Message :" + TextBox3.Text;

        MailMessage mail = new MailMessage();

        //mail.To.Add("aptech266goodshed@gmail.com");//receiver
        mail.To.Add("College@gmail.com");//receiver
        mail.From = new MailAddress(TextBox1 .Text );//sender
        mail.Subject = "Parent Send Mail:";

        string Body = "<b>From:<b>" + mail.From + "<br/>Mailing Details:" +data ;
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address//refer server

        smtp.Credentials = new System.Net.NetworkCredential("customerproject404@gmail.com", "ssiaptech");//Or your Smtp Email ID and Password//security

        smtp.EnableSsl = true;
        smtp.Send(mail);

       
    }


    

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        try 
        {

            cmd = new SqlCommand("insert into mtable values(@femailid,@temailid,@mdate,@mcontent)", con);
            cmd.Parameters .AddWithValue ("femailid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("temailid","College@gmail.com");
            cmd.Parameters .AddWithValue ("mdate",DateTime .Now .ToString ("dd-MMM-yyyy"));
            cmd.Parameters .AddWithValue ("mcontent",TextBox3 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Successfully Send Your Mail......";
            mailcoding();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}