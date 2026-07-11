using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

public partial class InsertStudentFeedback : System.Web.UI.Page
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
            TextBox2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!IsPostBack)
            {
                cmd = new SqlCommand("select distinct(byear) from studtable", con);
                rs = cmd.ExecuteReader();
                    DropDownList1 .DataSource =rs ;
                    DropDownList1.DataTextField = "byear";
                    DropDownList1.DataBind();
                    rs.Close();
                    cmd.Dispose ();
                    DropDownList1.Items.Insert(0, "Select");


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
            DropDownList2.Items.Clear();
            TextBox1.Text = "";
            TextBox3.Text = "";

            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Year.....";
                return;
            }

            cmd = new SqlCommand("select regno from studtable where byear=@byear", con);
            cmd.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            DropDownList2.DataSource = rs;
            DropDownList2.DataTextField = "regno";
            DropDownList2.DataBind();
            rs.Close();
            cmd.Dispose();
            DropDownList2.Items.Insert(0, "Select");

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            TextBox1.Text = "";
            TextBox3.Text = "";

            if (DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select Student Registration Number.....";
                return;
            }

            cmd = new SqlCommand("select sname from studtable where regno=@regno", con);
            cmd.Parameters.AddWithValue("regno", DropDownList2.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
                TextBox1.Text = rs["sname"].ToString();
            rs.Close();
            cmd.Dispose();


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
            if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select All Options....";
                return;
            }

            cmd = new SqlCommand("insert into ftable values(@byear,@regno,@sname,@fdate,@fdesc)", con);
            cmd.Parameters .AddWithValue ("byear",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("regno",DropDownList2 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("sname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("fdate",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("fdesc",TextBox3 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1.Text = "Send Student Feedback....";


            cmd = new SqlCommand("select mailid from studtable where regno=@regno", con);
            cmd.Parameters.AddWithValue("regno", DropDownList2.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            string mailid = "";
            if (rs.Read())
                mailid = rs["mailid"].ToString();
            rs.Close();
            cmd.Dispose();

            MailMessage mail = new MailMessage();

            string data = "<br>Registration Number :" + DropDownList2.SelectedItem.Text + "<Br>Student Name :" + TextBox1.Text + "<Br>Feedback Date :" + TextBox2.Text + "<br>Feedback Description :" + TextBox3.Text;
            mail.To.Add(mailid);//receiver
            mail.From = new MailAddress("customerproject404nf@gmail.com");//sender
            mail.Subject = "Feedback Details:";

            string Body = "<b>From:<b>" + mail.From + "<br/>" + data;
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address//refer server

            smtp.Credentials = new System.Net.NetworkCredential("customerproject404nf@gmail.com", "ssiaptech");//Or your Smtp Email ID and Password//security

            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        DropDownList2.Items.Clear();
        TextBox1.Text = "";
        TextBox3.Text = "";

    }
}