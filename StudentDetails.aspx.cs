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


public partial class StudentDetails : System.Web.UI.Page
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
                    DropDownList1.Items.Add(i.ToString());
                DropDownList1.Items.Insert(0, "Day");
                for (int i = 1980; i <= DateTime.Now.Year; i++)
                    DropDownList3.Items.Add(i.ToString());
                DropDownList3.Items.Insert(0, "Select");

              
            }
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
        if (FileUpload1.HasFile == false)
        {
            Label1.Text = "Select File Name....";
            return;
        }
        HiddenField2 .Value ="";
        FileInfo fi = new FileInfo(FileUpload1.PostedFile.FileName);
        if (fi.Extension.ToLower().Equals(".jpg") || fi.Extension.ToLower().Equals(".gif"))
        {
            Image1.ImageUrl = fi.FullName;
            string fname=DateTime .Now .Ticks +"_"+fi.Name;
            FileUpload1.SaveAs(Server .MapPath("UploadPhoto\\"+fname));
            HiddenField2 .Value =fname ;
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
            if (RadioButtonList1.SelectedIndex == -1 || RadioButtonList2.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0 )
            {
                Label1.Text = "Select All Options....";
                return;
            }

            if (HiddenField2.Value == "")
            {
                Label1.Text = "Select Student Photo......";
                return;
            }

          
            cmd = new SqlCommand("select regno from studtable where regno=@regno", con);
           
            cmd.Parameters.AddWithValue("regno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Registration  Number Already Found.....";
                return;

            }



            string dob = DropDownList1.SelectedItem.Text + "-" + DropDownList2.SelectedItem.Text + "-" + DropDownList3.SelectedItem.Text;
            DateTime dob1 = DateTime.Parse(dob);
            cmd = new SqlCommand("insert into studtable values(@regno,@sname,@gender,@dob,@fname,@address1,@address2,@city,@contactno,@mailid,@medium,@studphoto,@byear)", con);
           
            cmd.Parameters.AddWithValue("regno", TextBox1.Text);

            cmd.Parameters.AddWithValue("sname", TextBox2.Text);
            cmd.Parameters.AddWithValue("gender", RadioButtonList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("dob", dob1.ToString("dd-MMM-yyyy"));
            cmd.Parameters.AddWithValue("fname", TextBox3.Text);
            cmd.Parameters.AddWithValue("address1", TextBox4.Text);
            cmd.Parameters.AddWithValue("address2", TextBox5.Text);
            cmd.Parameters.AddWithValue("city", TextBox6.Text);
            cmd.Parameters.AddWithValue("contactno", TextBox7.Text);
            cmd.Parameters.AddWithValue("mailid", TextBox8.Text);
            cmd.Parameters.AddWithValue("medium", RadioButtonList2.SelectedItem.Text);
         
            cmd.Parameters.AddWithValue("studphoto", HiddenField2.Value);
            cmd.Parameters.AddWithValue("byear", TextBox9.Text);
            int no = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (no != 0)
            {
                string[] year = new string[] { "I Year", "II Year", "III Year" };
                string[] semester = new string[] { "I", "II", "III", "IV", "V", "VI" };
                int kk = 0;
                int count = 0;
                for (int i = 0; i < semester.Length; i++)
                {


                    cmd = new SqlCommand("insert into studsemtable values(@regno,@year,@semester,@csemstatus,@byear)", con);

                 

                    cmd.Parameters.AddWithValue("regno", TextBox1.Text);
                    cmd.Parameters.AddWithValue("year", year[kk]);
                    cmd.Parameters.AddWithValue("semester", semester[i]);
                    if (i == 0)
                        cmd.Parameters.AddWithValue("csemstatus", "CurrentSem");
                    else
                        cmd.Parameters.AddWithValue("csemstatus", "No");

                    cmd.Parameters.AddWithValue("Byear", TextBox9.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    count++;
                    if (count % 2 == 0)
                        kk += 1;


                }

            }




            Label1.Text = "Student Details Inserted....";
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
        TextBox2.Text = "";
        TextBox3.Text = "";

        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
      
        RadioButtonList1.SelectedIndex = -1;
        RadioButtonList2.SelectedIndex = -1;
        Image1.ImageUrl = "";
        HiddenField2.Value = "";
    }
}

