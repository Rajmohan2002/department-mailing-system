using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Net.Mail;

public partial class MonthlyAttendanceForm : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Label1.Text = "";

            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                cmd = new SqlCommand("select distinct(byear) from studtable", con);
                rs = cmd.ExecuteReader();
                DropDownList1.DataSource = rs;
                DropDownList1.DataTextField = "byear";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Select");
                rs.Close();
                cmd.Dispose();
            }

           
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }

    }

    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {


        try
        {

            RadioButtonList2.SelectedIndex = -1;
            RadioButtonList3.SelectedIndex = -1;
            DropDownList3.Items.Clear();
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Year........";
                return;
            }
      
            string s1 = "1-jun-" + DropDownList1 .SelectedItem .Text ;
            DateTime syear1 = DateTime.Parse(s1);
            DateTime cyear1 = DateTime.Now;

            TimeSpan dyear1 = cyear1.Subtract(syear1);

            int dd = dyear1.Days;

            foreach (ListItem l1 in RadioButtonList2.Items)
                l1.Enabled = false;





            if (dd >= 0 && dd <= 365)
            {


                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "I Year")
                    {

                        l1.Enabled = true;
                    }
                }

            }

            else if (dd >= 366 && dd <= 730)
           { 

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "I Year")
                    {

                        l1.Enabled = true;
                    }

                    if (l1.Text == "II Year")
                    {

                        l1.Enabled = true;
                    }
                }
            }

            else if (dd >= 731 && dd <= 1095)
            {

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "I Year")
                    {

                        l1.Enabled = true;
                    }

                    if (l1.Text == "II Year")
                    {

                        l1.Enabled = true;
                    }
                    if (l1.Text == "III Year")
                    {

                        l1.Enabled = true;
                    }
                }
            }

          



        }
        catch (Exception ex)
        {
         
            Label1.Text = ex.Message;
        }

    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            RadioButtonList3.SelectedIndex = -1;
            DropDownList3.Items.Clear();
            GridView1.Visible = false;


            foreach (ListItem l1 in RadioButtonList3.Items)
                l1.Enabled = false;



            if (RadioButtonList2.SelectedIndex == 0)
            {
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "I")
                    {

                        l1.Enabled = true;
                    }
                    if (l1.Text == "II")
                    {

                        l1.Enabled = true;
                    }
                }
            }
            else if (RadioButtonList2.SelectedIndex == 1)
            {
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "III")
                    {
                        l1.Enabled = true;

                    }
                    if (l1.Text == "IV")
                    {
                        l1.Enabled = true;

                    }
                }
            }
            else if (RadioButtonList2.SelectedIndex == 2)
            {
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "V")
                    {
                        l1.Enabled = true;

                    }
                    if (l1.Text == "VI")
                    {
                        l1.Enabled = true;

                    }
                }

            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {



            DropDownList3.Items.Clear();
            GridView1.Visible = false;

            DropDownList3.Items.Add("Select");
            foreach (ListItem l1 in RadioButtonList3.Items)
            {
                if ((l1.Selected  ==true ) && (l1.Text =="I" ||l1.Text =="III" || l1.Text =="V"))
                {

                    DropDownList3.Items.Add("Jun");
                    DropDownList3.Items.Add("Jul");
                    DropDownList3.Items.Add("Aug");
                    DropDownList3.Items.Add("Sep");
                    DropDownList3.Items.Add("Oct");
                    DropDownList3.Items.Add("Nov");
                    break;
                }
                else  if ((l1.Selected  == true) && (l1.Text == "II" || l1.Text == "IV" || l1.Text == "VI"))
                {

                    DropDownList3.Items.Add("Dec");
                    DropDownList3.Items.Add("Jan");
                    DropDownList3.Items.Add("Feb");
                    DropDownList3.Items.Add("Mar");
                    DropDownList3.Items.Add("Apr");
                    DropDownList3.Items.Add("May");
                    break;
                }
            }

           

        }
        catch (Exception ex)
        {
            
            Label1.Text = ex.Message;
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {

        try
        {

           
            GridView1.Visible = false;
            if (DropDownList3.SelectedIndex == 0)
            {

                Label1.Text = "Select Month.....";
                return;
            }

            if (DropDownList3.SelectedItem.Text == "Feb")
            {
                if (int.Parse(TextBox1.Text) >= 28)
                {
                    Label1.Text = "Enter Total Working Day<28.....";
                    return;
                }
            }

            else 
            {
                if (int.Parse(TextBox1.Text) >= 30)
                {
                    Label1.Text = "Enter Total Working Day<30.....";
                    return;
                }
            }


            cmd = new SqlCommand("select * from attendancetable where  byear=@byear and year=@year and semester=@semester and attmonth=@attmonth ", con);

          
            cmd.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("attmonth", DropDownList3.SelectedItem.Text);
           
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = DropDownList3 .SelectedItem .Text  + " Month Attendance  Details Already Inserted....";
                return;
            }
            bindgrid();

        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }
    }
   
    void bindgrid()
    {
        try
        {


            cmd = new SqlCommand("select regno from studsemtable where  byear=@byear and  year=@year and semester=@semester and csemstatus='CurrentSem'", con);
            cmd.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
            
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            ArrayList a = new ArrayList();
            while (rs.Read())
                a.Add(rs["regno"].ToString());
            rs.Close();
            cmd.Dispose();
            if (a.Count == 0)
            {
                Label1.Text = "Record Not Found....";
                return;
            }
            string s = "";
            for (int i = 0; i < a.Count; i++)
                s += " regno='" + a[i].ToString() + "' or ";
            if (s != "")
                s = s.Substring(0, s.LastIndexOf(" or "));



            //adp = new SqlDataAdapter("Select regno,sname from studtable where regno=(select regno from studsemtable where  deptcode=@deptcode and batchno=@batchno and year=@year and semester=@semester ) order by regno", con);

            adp = new SqlDataAdapter("select regno,sname from studtable where  " + s + " order by regno", con);


            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                LinkButton1.Enabled = true;
                GridView1.Visible = true;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }

    }


  
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            int no = GridView1.Rows.Count;
            if (no != 0)
            {
                for (int i = 0; i < no; i++)
                {
                    GridViewRow gr = GridView1.Rows[i];
                    string regno = gr.Cells[0].Text;
                    string name = gr.Cells[1].Text;

                    TextBox tday1 = (TextBox)gr.Cells[2].FindControl("tday");


                    if (DropDownList3.SelectedItem.Text == "Feb")
                    {
                        if (int.Parse(tday1.Text) >= 28)
                        {
                            Label1.Text = "Enter Total Present Day<28.....";
                            return;
                        }
                    }

                    else
                    {
                        if (int.Parse(tday1.Text) >= 30)
                        {
                            Label1.Text = "Enter Total Present Day<30.....";
                            return;
                        }
                    }


                    cmd = new SqlCommand("insert into attendancetable values(@byear,@year,@semester,@attmonth,@tworkingday,@regno,@sname,@tpresentday)", con);
                    cmd.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("attmonth", DropDownList3.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("tworkingday", TextBox1 .Text );
                    cmd.Parameters.AddWithValue("regno", regno);
                    cmd.Parameters.AddWithValue("sname", name);
                    cmd.Parameters.AddWithValue("tpresentday", tday1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                }
                Label1.Text = "Attendance Details Inserted....";
                LinkButton1.Enabled = false;


                for (int i = 0; i < GridView1.Rows.Count; i++ )
                {
                    GridViewRow gr = GridView1.Rows[i];
                    string regno1 = gr.Cells[0].Text;
                    string name1 = gr.Cells[1].Text;
                    TextBox tday11 = (TextBox)gr.Cells[2].FindControl("tday");
                    cmd = new SqlCommand("select mailid from studtable where regno=@regno", con);
                    cmd.Parameters.AddWithValue("regno", regno1);
                    string mailid = "";
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        mailid = rs["mailid"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        return;
                    }

                    string data = "<br>Registration No :" + regno1 + "<br>Student Name :" + name1 + "<br>Year :" + DateTime.Now.Year + "<br>Month :" + DropDownList3.SelectedItem.Text + "<br>Total Number of Working Days :" + TextBox1.Text + "<br>Total Present Day :" + tday11.Text; 

                    MailMessage mail = new MailMessage();

                    //mail.To.Add("aptech266goodshed@gmail.com");//receiver
                    mail.To.Add(mailid);//receiver
                    mail.From = new MailAddress("customerproject404nf@gmail.com");//sender
                    mail.Subject = "Attendace Details:";

                    string Body = "<b>From:<b>" + mail.From + "<br/>" + data;
                    mail.Body = Body;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address//refer server

                    smtp.Credentials = new System.Net.NetworkCredential("customerproject404nf@gmail.com", "ssiaptech");//Or your Smtp Email ID and Password//security

                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                }

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
     
        DropDownList3.Items.Clear();
        RadioButtonList2.SelectedIndex = -1;
        RadioButtonList3.SelectedIndex = -1;
        TextBox1.Text = "";

        foreach (ListItem l1 in RadioButtonList2.Items)
            l1.Enabled = true;
        foreach (ListItem l1 in RadioButtonList3.Items)
            l1.Enabled = true;

        GridView1.Visible = false;
        LinkButton1.Enabled = false;

    }

  
}
