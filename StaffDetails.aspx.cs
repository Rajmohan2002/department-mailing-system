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
using System.IO;
using System.Configuration;

public partial class StaffDetails : System.Web.UI.Page
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
     
            if (!IsPostBack)
            {

                for (int i = 1; i <= 31; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                  
                }
                DropDownList1.Items.Insert(0, "Day");
             
                for (int i = 1980; i <= DateTime.Now.Year; i++)
                    DropDownList3.Items.Add(i.ToString());
                DropDownList3.Items.Insert(0, "Select");

                autonumber();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(staffid),100)+1 from stafftable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    

       protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Select File Name....";
                return;
            }
            HiddenField2.Value = "";
            FileInfo fi = new FileInfo(FileUpload1.PostedFile.FileName);
            if (fi.Extension.ToLower().Equals(".jpg") || fi.Extension.ToLower().Equals(".gif"))
            {
                Image1.ImageUrl = fi.FullName;
                string fname = DateTime.Now.Ticks + "_" + fi.Name;
                FileUpload1.SaveAs(Server.MapPath("UploadPhoto\\" + fname));
                HiddenField2.Value = fname;
            }
            else
                Label1.Text = "Select Only Jpg or Gif  File....";
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
            if (RadioButtonList1.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0)
            {
                Label1.Text = "Select All Options....";
                return;
            }
            if (ListBox1.Items.Count == 0)
            {
                Label1.Text = "Subject Name Not Added.Please Add Subject Name....";
                return;

            }

            if (HiddenField2.Value == "")
            {
                Label1.Text = "Staff Image Not Selected.....";
                return;
            }


            cmd = new SqlCommand("select staffid from stafftable where staffid=@staffid ", con);
            cmd.Parameters.AddWithValue("staffid", TextBox1.Text);

            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "StaffID Already Found.Please Press Clear Button....";
                return;

            }


            string dob = DropDownList1.SelectedItem.Text + "-" + DropDownList2.SelectedItem.Text + "-" + DropDownList3.SelectedItem.Text;
            DateTime dob1 = DateTime.Parse(dob);
          

            string subname = "";

            foreach (ListItem l1 in ListBox1.Items)
            {
                subname += l1.Text + ",";
            }
            if (subname != "")
            {
                subname = subname.Substring(0, subname.Length - 1);
            }


            cmd = new SqlCommand("insert into stafftable values(@staffid,@staffname,@fname,@gender,@dob,@qualification,@designation,@expyear,@contactno,@mailid,@sknown,@staffimage)", con);
        
            cmd.Parameters.AddWithValue("staffid", TextBox1.Text);

            cmd.Parameters.AddWithValue("staffname", TextBox2.Text);
            cmd.Parameters.AddWithValue("fname", TextBox3.Text);
            cmd.Parameters.AddWithValue("gender", RadioButtonList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("dob", dob1.ToString("dd-MMM-yyyy"));
            cmd.Parameters.AddWithValue("qualification", TextBox4.Text);
            cmd.Parameters.AddWithValue("designation", TextBox5.Text);
            cmd.Parameters.AddWithValue("expyear", TextBox6.Text);
         
          
            cmd.Parameters.AddWithValue("contactno", TextBox7.Text);
            cmd.Parameters.AddWithValue("mailid", TextBox8.Text);
            cmd.Parameters.AddWithValue("sknown", subname);
            cmd.Parameters.AddWithValue("staffimage", HiddenField2.Value);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Staff Details Inserted....";

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
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;
      
        TextBox1.Text = "";

        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
     
        ListBox1.Items.Clear();
        RadioButtonList1.SelectedIndex = -1;
      
        LinkButton4.Enabled = true;
        ListBox1.Enabled = true;

        Image1.ImageUrl = "";
        HiddenField2.Value = "";
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        try
        {

            if (ListBox1.Items.Count != 0)
            {
                foreach (ListItem l1 in ListBox1.Items)
                {
                    if (l1.Text.ToLower() == TextBox9.Text.ToLower())
                    {
                        Label1.Text = "Subject Name Already Inserted.....";
                        return;
                    }
                }
            }

            ListBox1.Items.Add(TextBox9.Text);
            TextBox9.Text = "";
            TextBox9.Focus();



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}

