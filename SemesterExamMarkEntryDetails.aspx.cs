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
using System.Net.Mail;

public partial class SemesterExamMarkEntryDetails : System.Web.UI.Page
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
            DropDownList2.Items.Clear();
            GridView1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            if (DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select Year....";
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
                    if (l1.Text == "I Year" )
                    {

                        l1.Enabled = true;
                    }
                }
                         
                }
              
                else if (dd >= 366 && dd <= 730)
                {
                   
                     foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "I Year" )
                    {

                        l1.Enabled = true;
                    }

  	if (l1.Text == "II Year" )
                    {

                        l1.Enabled = true;
                    }
                }
                }
              
                else if (dd >= 731 && dd <= 1095)
                {
                   
                    foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "I Year" )
                    {

                        l1.Enabled = true;
                    }

  	if (l1.Text == "II Year" )
                    {

                        l1.Enabled = true;
                    }
if (l1.Text == "III Year" )
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
            DropDownList2.Items.Clear();
            GridView1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";



            foreach (ListItem l1 in RadioButtonList3.Items)
                l1.Enabled = false;

          

            if (RadioButtonList2.SelectedIndex == 0)
            {
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "I" )
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


           
            DropDownList2.Items.Clear();
            GridView1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";


            cmd = new SqlCommand("select distinct(papername) from spapertable1 where  year=@year and semester=@semester", con);
           
            cmd.Parameters .AddWithValue ("year",RadioButtonList2 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("semester",RadioButtonList3 .SelectedItem .Text );

            rs = cmd.ExecuteReader();
            DropDownList2.DataSource = rs;
            DropDownList2.DataTextField = "papername";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Select");
            rs.Close();
            cmd.Dispose();


        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            if (DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select Paper Name....";
                return;
            }
            cmd = new SqlCommand("select * from semetable where byear=@byear and year=@year and semester=@semester and papername=@papername", con);
            cmd.Parameters .AddWithValue ("byear",DropDownList1 .SelectedItem .Text );
         
            cmd.Parameters .AddWithValue ("year",RadioButtonList2 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("semester",RadioButtonList3 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("papername",DropDownList2 .SelectedItem .Text );
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Semester Mark Entry Details Already Inserted....";
                return;
            }

            cmd = new SqlCommand("select staffid,pcode from suballotment where pname=@pname", con);
            cmd.Parameters.AddWithValue("pname", DropDownList2.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox1.Text = rs["pcode"].ToString();
                TextBox2.Text = rs["staffid"].ToString();
                rs.Close();
                cmd.Dispose();

            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found. Check SubAllotment Table....";
                return;
            }

            cmd = new SqlCommand("select staffname from stafftable where staffid=@staffid", con);
            cmd.Parameters.AddWithValue("staffid", TextBox2.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox3.Text = rs["staffname"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check StaffTable....";
                return;
            }




            bindgrid();

        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }


    }

    void bindgrid()
    {
        try
        {


            cmd = new SqlCommand("select regno from studsemtable where  byear=@byear and year=@year and semester=@semester ", con);
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


            adp = new SqlDataAdapter("select regno,sname from studtable where "+s+" order by regno", con);

           
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                LinkButton1.Enabled = true;
                GridView1.Visible  = true;
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

                    TextBox fimark = (TextBox)gr.Cells[2].FindControl("FIMark");
                    TextBox fquiz = (TextBox)gr.Cells[3].FindControl("FQuiz");
                    TextBox fass = (TextBox)gr.Cells[4].FindControl("FAss");
                    TextBox simark = (TextBox)gr.Cells[5].FindControl("SIMark");
                    TextBox squiz = (TextBox)gr.Cells[6].FindControl("SQuiz");
                    TextBox sass = (TextBox)gr.Cells[7].FindControl("SAss");
                    TextBox ext = (TextBox)gr.Cells[8].FindControl("Ext");
                     float per = 0;

                     float tot = (float.Parse(fimark.Text) + float.Parse(fquiz.Text) + float.Parse(fass.Text) + float.Parse(simark.Text) + float.Parse(squiz.Text) + float.Parse(sass.Text));
                     float pp = tot / 6;
                     per = float.Parse (ext.Text ) + pp;






                    cmd = new SqlCommand("insert into semetable values(@byear,@year,@semester,@papername,@pcode,@regno,@sname,@fimark,@fquiz,@fass,@simark,@squiz,@sass,@emark,@percentage)", con);
                    cmd.Parameters.AddWithValue("byear", DropDownList1 .SelectedItem .Text );
                    cmd.Parameters.AddWithValue("year", RadioButtonList2 .SelectedItem .Text );
                    cmd.Parameters.AddWithValue("semester", RadioButtonList3 .SelectedItem .Text );
                    cmd.Parameters.AddWithValue("papername", DropDownList2 .SelectedItem .Text );
                    cmd.Parameters.AddWithValue("pcode", TextBox1.Text);
                    cmd.Parameters.AddWithValue("regno", regno);
                    cmd.Parameters.AddWithValue("sname", name);
                    cmd.Parameters.AddWithValue("fimark", fimark.Text);
                    cmd.Parameters .AddWithValue ("fquiz",fquiz .Text );
                    cmd.Parameters .AddWithValue ("fass",fass .Text );
                    cmd.Parameters .AddWithValue ("simark",simark .Text );
                    cmd.Parameters .AddWithValue ("squiz",squiz .Text );
                    cmd.Parameters .AddWithValue ("sass",sass .Text );
                    cmd.Parameters .AddWithValue ("emark",ext.Text );
                   
                    cmd.Parameters .AddWithValue ("percentage",per);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    

                }


                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow gr = GridView1.Rows[i];
                    string regno1 = gr.Cells[0].Text;
                    string name1 = gr.Cells[1].Text;

                    TextBox fimark1 = (TextBox)gr.Cells[2].FindControl("FIMark");
                    TextBox fquiz1 = (TextBox)gr.Cells[3].FindControl("FQuiz");
                    TextBox fass1 = (TextBox)gr.Cells[4].FindControl("FAss");
                    TextBox simark1 = (TextBox)gr.Cells[5].FindControl("SIMark");
                    TextBox squiz1 = (TextBox)gr.Cells[6].FindControl("SQuiz");
                    TextBox sass1 = (TextBox)gr.Cells[7].FindControl("SAss");
                    TextBox ext1 = (TextBox)gr.Cells[8].FindControl("Ext");
                  
                    float per1 = 0;

                    float tot1 = (float.Parse(fimark1.Text) + float.Parse(fquiz1.Text) + float.Parse(fass1.Text) + float.Parse(simark1.Text) + float.Parse(squiz1.Text) + float.Parse(sass1.Text));
                    float pp1 = tot1 / 6;
                    per1 = float.Parse(ext1.Text) + pp;


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

                    string data = "<br>Registration No :" + regno1 + "<br>Student Name :" + name1 + "<br>First Internal Mark  :" + fimark1.Text + "<br>First Quiz Mark :" + fquiz1.Text + "<br>First Assesment Mark :" + fass1.Text + "<Br>Second Internal Mark :" + simark1.Text + "<br>Second Quiz Mark :" + squiz1.Text + "<br>Second Assesment Mark " + sass1.Text+"<br>External Mark "+ext1 .Text +"<br>Percentage :"+per1 ;

                    MailMessage mail = new MailMessage();

                    //mail.To.Add("aptech266goodshed@gmail.com");//receiver
                    mail.To.Add(mailid);//receiver
                    mail.From = new MailAddress("customerproject404nf@gmail.com");//sender
                    mail.Subject = "Mark Details:";

                    string Body = "<b>From:<b>" + mail.From + "<br/>" + data ;
                    mail.Body = Body;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address//refer server

                    smtp.Credentials = new System.Net.NetworkCredential("customerproject404nf@gmail.com", "ssiaptech");//Or your Smtp Email ID and Password//security

                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                }


                Label1.Text = "SemesterExam Mark Details Inserted....";
                LinkButton1.Enabled = false;

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
        DropDownList2.Items.Clear();
       
        RadioButtonList2.SelectedIndex = -1;
        RadioButtonList3.SelectedIndex = -1;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";

        foreach (ListItem l1 in RadioButtonList2.Items)
            l1.Enabled = true;
        foreach (ListItem l1 in RadioButtonList3.Items)
            l1.Enabled = true ;


        GridView1.Visible = false;
        LinkButton1.Enabled = false;

    }

    
}
