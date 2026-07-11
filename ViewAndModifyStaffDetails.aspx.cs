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


public partial class ViewAndModifyStaffDetails : System.Web.UI.Page
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
            if(!IsPostBack )
                bindview();

            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
   


   
    void bindview()
    {
        try
        {
            FormView1.Visible = true;
            adp = new SqlDataAdapter("Select * from stafftable", con);
            
           
            ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                ds.Tables[0].Rows[i]["staffimage"] = Server.MapPath("UploadPhoto\\" + ds.Tables[0].Rows[i]["staffimage"].ToString());
            FormView1.DataSource = ds.Tables[0];
            FormView1.DataBind();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        FormView1.PageIndex = e.NewPageIndex;
        bindview();
    }

    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FormView1.ChangeMode(e.NewMode);
        bindview();
        // Response.Write (FormView1.CurrentMode);

    }
    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {

        try
        {
            string staffid = FormView1.DataKey[0].ToString();
            
          

            TextBox staffname = (TextBox)FormView1.FindControl("staffname");
            TextBox fname = (TextBox)FormView1.FindControl("fname");
            RadioButtonList gender = (RadioButtonList)FormView1.FindControl("gender");
            TextBox dob = (TextBox)FormView1.FindControl("dob");
            TextBox qualification = (TextBox)FormView1.FindControl("qualification");
            TextBox designation = (TextBox)FormView1.FindControl("designation");
            TextBox expyear = (TextBox)FormView1.FindControl("expyear");
          
            TextBox contactno = (TextBox)FormView1.FindControl("contactno");
            TextBox mailid = (TextBox)FormView1.FindControl("mailid");
            
            TextBox sknown = (TextBox)FormView1.FindControl("sknown");

            cmd = new SqlCommand(" update stafftable set staffname=@staffname,fname=@fname,gender=@gender,dob=@dob,qualification=@qualification,designation=@designation,expyear=@expyear,contactno=@contactno,mailid=@mailid,sknown=@sknown where staffid=@staffid  ", con);
            cmd.Parameters .AddWithValue ("staffname",staffname.Text );
            cmd.Parameters .AddWithValue ("fname",fname.Text );
            cmd.Parameters .AddWithValue ("gender",gender .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("dob",dob.Text );
            cmd.Parameters .AddWithValue ("qualification",qualification .Text );
            cmd.Parameters .AddWithValue ("designation",designation .Text );
            cmd.Parameters .AddWithValue ("expyear",expyear .Text );
          
            cmd.Parameters .AddWithValue ("contactno",contactno .Text );
            cmd.Parameters .AddWithValue ("mailid",mailid .Text );
            cmd.Parameters .AddWithValue ("sknown",sknown .Text );
        
            cmd.Parameters .AddWithValue ("staffid",staffid  );
          
                cmd.ExecuteNonQuery();
            cmd.Dispose();
            FormView1.ChangeMode(FormViewMode.ReadOnly);
            bindview();



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {
        try
        {
            string staffid = FormView1.DataKey[0].ToString();
         


            cmd = new SqlCommand("delete from  stafftable  where staffid=@staffid ", con);

          
            cmd.Parameters.AddWithValue("staffid", staffid);
            
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            FormView1.ChangeMode(FormViewMode.ReadOnly);
            bindview();


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}
