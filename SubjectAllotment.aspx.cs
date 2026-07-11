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


public partial class SubjectAllotment : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;

            Label1.Text = "";
          
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
               
                cmd = new SqlCommand("select staffid from stafftable  ", con);
                rs = cmd.ExecuteReader();
                DropDownList2.DataSource = rs;
                DropDownList2.DataTextField = "staffid";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "Select");
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
  

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            RadioButtonList3.SelectedIndex = -1;

            foreach (ListItem l1 in RadioButtonList3.Items)
                l1.Enabled = false;

            ListBox1.Items.Clear();

            DropDownList2.SelectedIndex = 0;
            TextBox3.Text = "";
            ListBox2.Items.Clear();
            TextBox4.Text = "";
            TextBox5.Text = "";


            string s = DateTime.Now.ToString("MMMM");
            if (s.Equals("June") || s.Equals("July") || s.Equals("August") || s.Equals("September") || s.Equals("October") || s.Equals("November"))
            {
                if (RadioButtonList2.SelectedIndex == 0)
                {
                    foreach (ListItem l1 in RadioButtonList3.Items)
                    {
                        if (l1.Text == "I")
                        {
                            l1.Enabled = true;
                            l1.Selected = true;
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
                            l1.Selected = true;
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
                            l1.Selected = true;
                        }
                    }

                }
                else if (RadioButtonList2.SelectedIndex == 3)
                {
                    foreach (ListItem l1 in RadioButtonList3.Items)
                    {
                        if (l1.Text == "VII")
                        {
                            l1.Enabled = true;
                            l1.Selected = true;
                        }
                    }

                }

            }
            else if (s.Equals("December") || s.Equals("January") || s.Equals("February") || s.Equals("March") || s.Equals("April") || s.Equals("May"))
            {
                if (RadioButtonList2.SelectedIndex == 0)
                {
                    foreach (ListItem l1 in RadioButtonList3.Items)
                    {
                        if (l1.Text == "II")
                        {
                            l1.Enabled = true;
                            l1.Selected = true;
                        }
                    }
                }
                else if (RadioButtonList2.SelectedIndex == 1)
                {
                    foreach (ListItem l1 in RadioButtonList3.Items)
                    {
                        if (l1.Text == "IV")
                        {
                            l1.Enabled = true;
                            l1.Selected = true;
                        }
                    }
                }
                else if (RadioButtonList2.SelectedIndex == 2)
                {
                    foreach (ListItem l1 in RadioButtonList3.Items)
                    {
                        if (l1.Text == "VI")
                        {
                            l1.Enabled = true;
                            l1.Selected = true;
                        }
                    }

                }
                else if (RadioButtonList2.SelectedIndex == 3)
                {
                    foreach (ListItem l1 in RadioButtonList3.Items)
                    {
                        if (l1.Text == "VIII")
                        {
                            l1.Enabled = true;
                            l1.Selected = true;
                        }
                    }

                }
            }

            cmd = new SqlCommand("Select papername from spapertable1 where  year=@year and semester=@semester", con);
            
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            ListBox1.DataSource = rs;
            ListBox1.DataTextField = "papername";
            ListBox1.DataBind();
            rs.Close();
            cmd.Dispose();
            if (ListBox1.Items.Count == 0)
            {
                Label1.Text = RadioButtonList2.SelectedItem.Text + " " + RadioButtonList3.SelectedItem.Text + " Semester Paper Details Not Inserted.First Insert Paper Details....";
                return;
            }


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
            TextBox3.Text = "";
            ListBox2.Items.Clear();
            TextBox4.Text = "";
            if (DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select StaffID.....";
                return;
            }
            cmd = new SqlCommand("select staffname,sknown from stafftable where staffid=@staffid", con);
            cmd.Parameters.AddWithValue("staffid", DropDownList2.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox3.Text = rs["staffname"].ToString();
                string sknown = rs["sknown"].ToString();
                string ss = ",";
                char[] c = ss.ToCharArray();
                string[] sknown1 = sknown.Split(c);
                ListBox2.DataSource = sknown1;
                ListBox2.DataBind();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
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
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox4.Text = "";
            if (ListBox2.Items.Count == 0)
            {
                Label1.Text = "Select StaffID.....";
                return;
            }

            cmd = new SqlCommand("Select * from suballotment where year=@year and semester=@semester and pname=@pname and pcode=@pcode", con);
           
            
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("pname", ListBox1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("pcode", TextBox5.Text);
            rs = cmd.ExecuteReader();
            bool b1 = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b1)
            {
                Label1.Text = RadioButtonList2.SelectedItem.Text + " " + RadioButtonList3.SelectedItem.Text + " " + ListBox1.SelectedItem.Text + " Paper Allotment Details Already Inserted....";
                return;
            }

            bool b = false;
            string sub1 = ListBox1.SelectedItem.Text.ToLower();
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                if (ListBox2.Items[i].Text.ToLower() == sub1)
                {
                    b = true;
                    break;
                }
            }
            if (b)
            {
                TextBox4.Text = sub1;
            }
            else
            {
                TextBox4.Text = "";
                Label1.Text = sub1 + " Subject Not Handled The Staff(" + TextBox3.Text + ").....";
                return;
            }

        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
           
            if ( RadioButtonList2.SelectedIndex == -1 || RadioButtonList3.SelectedIndex == -1 || DropDownList2.SelectedIndex == 0 || ListBox1.SelectedIndex == -1)
            {
                Label1.Text = "Select All Options....";
                return;
            }
            cmd = new SqlCommand("Select * from suballotment where year=@year and semester=@semester and pname=@pname and pcode=@pcode", con);
              cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("pname", ListBox1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("pcode", TextBox5.Text);
           
            rs = cmd.ExecuteReader();
            bool b1 = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b1)
            {
                    Label1.Text = RadioButtonList2.SelectedItem.Text + " " + RadioButtonList3.SelectedItem.Text + " " + ListBox1.SelectedItem.Text + " Paper Allotment Details Already Inserted....";
                    return;
                }
  


            cmd = new SqlCommand("insert into suballotment values(@year,@semester,@staffid,@pname,@pcode)", con);
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("staffid", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("pname", TextBox4.Text);
            cmd.Parameters.AddWithValue("pcode", TextBox5.Text);
            int no = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (no != 0)
            {
                cmd = new SqlCommand("update spapertable1 set status='Allotment' where   year=@year and semester=@semester and papername=@papername", con);
                
             
                cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
                cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("papername", TextBox4.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = RadioButtonList2.SelectedItem.Text + " " + RadioButtonList3.SelectedItem.Text + " " + ListBox1.SelectedItem.Text + " Paper Allotment Details Inserted.....";
            }
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      
        RadioButtonList2.SelectedIndex = -1;
        RadioButtonList3.SelectedIndex = -1;

        foreach (ListItem l1 in RadioButtonList3.Items)
            l1.Enabled = false;

       
   
       
        ListBox1.Items.Clear();
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";

        ListBox2.Items.Clear();
        DropDownList2.SelectedIndex = 0;
    }

    
}
