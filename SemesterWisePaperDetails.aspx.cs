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

public partial class SemesterWisePaperDetails : System.Web.UI.Page
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
        


        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }

    }
    
       protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ( RadioButtonList2.SelectedIndex == -1)
            {
                Label1.Text = "Select Year......";
                return;
            }
            cmd = new SqlCommand("Select * from spapertable where year=@year and semester=@semester", con);
          
            
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = RadioButtonList2.SelectedItem.Text + " " + RadioButtonList3.SelectedItem.Text + " Semester Paper Details Already Inserted....";
                LinkButton1.Enabled = false;
            }
            else
                LinkButton1.Enabled = true;
        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("Select * from spapertable1 where papername=@papername", con);
            cmd.Parameters.AddWithValue("papername", TextBox4.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = TextBox4.Text + " Paper Name Already Inserted.Please Type Another Paper Name....";
                return;
            }


            if (ListBox1.Items.Count != 0)
            {
                foreach (ListItem l1 in ListBox1.Items)
                {
                    if (l1.Text.ToLower() == TextBox4.Text.ToLower())
                    {
                        Label1.Text = "Paper Name Already Inserted.....";
                        return;
                    }
                }
            }

            ListBox1.Items.Add(TextBox4.Text);
            TextBox4.Text = "";
            TextBox4.Focus();



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
            if (RadioButtonList2.SelectedIndex == -1 || RadioButtonList3.SelectedIndex == -1)
            {
                Label1.Text = "Select All Options....";
                return;
            }
            if (int.Parse(TextBox3.Text) != ListBox1.Items.Count)
            {
                Label1.Text = "Enter " + TextBox3.Text + " Paper Name.....";
                return;
            }

            cmd = new SqlCommand("select * from spapertable  where year=@year and semester=@semester", con);
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = RadioButtonList2.SelectedItem.Text + " " + RadioButtonList3.SelectedItem.Text + " Semester Paper Details Already Inserted.....";
                return;
            }

            cmd = new SqlCommand("insert into spapertable values(@year,@semester,@totalpeper)", con);
            
           
            cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("totalpeper", TextBox3.Text);

            int no = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (no != 0)
            {
                for (int i = 0; i < int.Parse(TextBox3.Text); i++)
                {
                    cmd = new SqlCommand("insert into spapertable1 values(@year,@semester,@papername,@status)", con);
                   
                   
                    cmd.Parameters.AddWithValue("year", RadioButtonList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("semester", RadioButtonList3.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("papername", ListBox1.Items[i].Text);
                    cmd.Parameters.AddWithValue("status", "Not Allotment");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                Label1.Text = "SemesterWise Paper  Details Inserted....";
            }

        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

      
       
        RadioButtonList2.SelectedIndex = -1;
        RadioButtonList3.SelectedIndex = -1;

     
        TextBox3.Text = "";
        TextBox4.Text = "";
        ListBox1.Items.Clear();
        LinkButton1.Enabled = true;
    }

}
