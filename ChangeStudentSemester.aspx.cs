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

public partial class ChangeStudentSemester : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    DataTable dt;
    SqlDataAdapter adp;
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
                cmd = new SqlCommand("select distinct(byear) from studtable ", con);
               
                rs = cmd.ExecuteReader();
                DropDownList1.DataSource = rs;
                DropDownList1.DataTextField = "byear";
                DropDownList1.DataBind();
                rs.Close();
                cmd.Dispose();
                DropDownList1.Items.Insert(0, "Select");
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
            HiddenField1.Value = "";
            TextBox1.Text = "";
            GridView1.Visible = false;

            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Batch Year...";
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
        adp = new SqlDataAdapter("select sname,regno from studtable where  byear=@byear order by regno", con);

        adp.SelectCommand.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        HiddenField1.Value = dt.Rows.Count.ToString();



        string s1 = "1-jun-" + DropDownList1 .SelectedItem .Text ;
        DateTime syear1 = DateTime.Parse(s1);
        DateTime cyear1 = DateTime.Now;

        TimeSpan dyear1 = cyear1.Subtract(syear1);

        int dd = dyear1.Days;
        string[] year = new string[] { "I Year", "II Year", "III Year" };
        string[] semester = new string[] { "I", "II", "III", "IV", "V", "VI" };
        string[] csemester = new string[6];

        if (dd >= 0 && dd <= 182)
        {

            csemester[0] = "CurrentSem";
            csemester[1] = "No";

            csemester[2] = "No";
            csemester[3] = "No";

            csemester[4] = "No";
            csemester[5] = "No";
        }
        else if (dd >= 183 && dd <= 365)
        {

            csemester[0] = "Completed";
            csemester[1] = "CurrentSem";

            csemester[2] = "No";
            csemester[3] = "No";

            csemester[4] = "No";
            csemester[5] = "No";
         
        }
        else if (dd >= 366 && dd <= 548)
        {

            csemester[0] = "Completed";
            csemester[1] = "Completed";

            csemester[2] = "CurrentSem";
            csemester[3] = "No";

            csemester[4] = "No";
            csemester[5] = "No";
          
        }
        else if (dd >= 549 && dd <= 730)
        {

            csemester[0] = "Completed";
            csemester[1] = "Completed";

            csemester[2] = "Completed";
            csemester[3] = "CurrentSem";

            csemester[4] = "No";
            csemester[5] = "No";
         
        }
        else if (dd >= 731 && dd <= 913)
        {

            csemester[0] = "Completed";
            csemester[1] = "Completed";

            csemester[2] = "Completed";
            csemester[3] = "Completed";

            csemester[4] = "CurrentSem";
            csemester[5] = "No";
          
        }
        else if (dd >= 914 && dd <= 1095)
        {

            csemester[0] = "Completed";
            csemester[1] = "Completed";

            csemester[2] = "Completed";
            csemester[3] = "Completed";

            csemester[4] = "Completed";
            csemester[5] = "CurrentSem";
      
        }
        else if (dd >= 1096 && dd <= 1277)
        {

            csemester[0] = "Completed";
            csemester[1] = "Completed";

            csemester[2] = "Completed";
            csemester[3] = "Completed";

            csemester[4] = "Completed";
            csemester[5] = "Completed";
        
        }

       

        int kk = 0;
        int count = 0;
        for (int i = 0; i < semester.Length; i++)
        {

            cmd = new SqlCommand("update studsemtable set csemstatus=@csemstatus where  year=@year and semester=@semester and byear=@byear", con);
            cmd.Parameters.AddWithValue("csemstatus", csemester[i]);
            cmd.Parameters.AddWithValue("year", year[kk]);
            cmd.Parameters.AddWithValue("semester", semester[i]);
            cmd.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            count++;
            if (count % 2 == 0)
                kk += 1;
        }


        cmd = new SqlCommand("select count(*) from studsemtable where  byear=@byear and csemstatus='completed'", con);

    
        cmd.Parameters.AddWithValue("byear", DropDownList1.SelectedItem.Text);
        rs = cmd.ExecuteReader();
        int scount = 0;
        if (rs.Read())
        {
            scount = int.Parse(rs[0].ToString());
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
        }
        RadioButtonList2.SelectedIndex = -1;
        RadioButtonList3.SelectedIndex = -1;

        foreach (ListItem l1 in RadioButtonList2.Items)
            l1.Enabled = false;

        foreach (ListItem l1 in RadioButtonList3.Items)
            l1.Enabled = false;
        if (scount == 0)
        {
            TextBox1.Text = "0";

            foreach (ListItem l1 in RadioButtonList2.Items)
            {
                if (l1.Text == "I Year")
                {
                    l1.Enabled = true;
                    l1.Selected = true;
                    break;
                }
            }
            foreach (ListItem l1 in RadioButtonList3.Items)
            {
                if (l1.Text == "I")
                {
                    l1.Enabled = true;
                    l1.Selected = true;
                    break;
                }
            }


        }
        else
        {

            scount = scount / int.Parse(HiddenField1.Value);
            TextBox1.Text = scount.ToString();

            if (scount == 1)
            {

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "I Year")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "II")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }



            }

            else if (scount == 2)
            {

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "II Year")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "III")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
            }

            else if (scount == 3)
            {

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "II Year")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "IV")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
            }
            else if (scount == 4)
            {

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "III Year")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "V")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
            }

            else if (scount == 5)
            {

                foreach (ListItem l1 in RadioButtonList2.Items)
                {
                    if (l1.Text == "III Year")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }
                foreach (ListItem l1 in RadioButtonList3.Items)
                {
                    if (l1.Text == "VI")
                    {
                        l1.Enabled = true;
                        l1.Selected = true;
                        break;
                    }
                }


            }

            if (scount == 6)
                Label1.Text = "Complete All Semester.....";
            else
                Label1.Text = "Currently <font color='red'>" + RadioButtonList2.SelectedItem.Text + "</font><font color='green'> " + RadioButtonList3.SelectedItem.Text + " Semester</font>.....";

        }

    }
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        TextBox1.Text = "";
        GridView1.Visible = false;
        RadioButtonList2.SelectedIndex = -1;
        RadioButtonList3.SelectedIndex = -1;
        foreach (ListItem l1 in RadioButtonList2.Items)
            l1.Enabled = false;
        foreach (ListItem l1 in RadioButtonList3.Items)
            l1.Enabled = false;
    }
    
}
