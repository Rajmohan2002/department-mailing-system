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
using System.Data .SqlClient ;
using System.Configuration;

public partial class ViewAndModifyStudentDetails : System.Web.UI.Page
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
                bindview();
            }
        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.Message;
        }

    }
 
    void bindview()
    {
        try
        {
            FormView1.Visible = true;
            adp = new SqlDataAdapter("Select * from studtable ", con);
              ds = new DataSet();
              adp.Fill(ds);
            for (int i=0 ;i<ds.Tables [0].Rows .Count ;i++)
                ds.Tables [0].Rows [i]["studphoto"]=Server.MapPath ("UploadPhoto\\"+ds.Tables [0].Rows [i]["studphoto"].ToString ());
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
           string regno=FormView1.DataKey[0].ToString();
            TextBox sname = (TextBox )FormView1.FindControl("sname");
            RadioButtonList gender=(RadioButtonList )FormView1 .FindControl ("gender");
            TextBox dob=(TextBox )FormView1.FindControl ("dob");
            TextBox fname=(TextBox )FormView1.FindControl ("fname");
            TextBox address1=(TextBox )FormView1.FindControl ("address1");
            TextBox address2=(TextBox )FormView1.FindControl ("address2");
            TextBox city=(TextBox )FormView1.FindControl ("city");
            TextBox contactno=(TextBox )FormView1.FindControl ("contactno");
            TextBox mailid=(TextBox )FormView1.FindControl ("mailid");
            RadioButtonList medium = (RadioButtonList)FormView1.FindControl("medium");
     
            cmd=new SqlCommand ("update studtable set sname=@sname,gender=@gender,dob=@dob,fname=@fname,address1=@address1,address2=@address2,city=@city,contactno=@contactno,mailid=@mailid,medium=@medium where  regno=@regno ",con );
            cmd.Parameters .AddWithValue ("sname",sname.Text );
            cmd.Parameters .AddWithValue ("gender",gender .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("dob",dob.Text );
            cmd.Parameters .AddWithValue ("fname",fname.Text );
            cmd.Parameters .AddWithValue ("address1",address1 .Text );
            cmd.Parameters .AddWithValue ("address2",address2 .Text );
            cmd.Parameters .AddWithValue ("city",city .Text );
            cmd.Parameters .AddWithValue ("contactno",contactno .Text );
            cmd.Parameters .AddWithValue ("mailid",mailid .Text );
            cmd.Parameters .AddWithValue ("medium",medium .SelectedItem .Text  );
            cmd.Parameters .AddWithValue ("regno",regno );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            FormView1 .ChangeMode (FormViewMode.ReadOnly );
            bindview ();

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
            string regno = FormView1.DataKey[0].ToString();
            cmd = new SqlCommand("delete from  studtable  where  regno=@regno ", con);
            cmd.Parameters.AddWithValue("regno", regno);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = new SqlCommand("delete from  studsemtable  where  regno=@regno ", con);
            cmd.Parameters.AddWithValue("regno", regno);
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
