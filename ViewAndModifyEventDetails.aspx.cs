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

public partial class ViewAndModifyEventDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
    SqlCommand cmd;

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
                BindGrid();


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void BindGrid()
    {
        adp = new SqlDataAdapter("select * from etable ", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string ename= GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            DateTime edate = DateTime.Parse(GridView1.DataKeys[e.RowIndex].Values[1].ToString());
            TextBox etype = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox description = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox venue = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
            cmd = new SqlCommand("update etable set  etype=@etype,description=@description,venue =@venue where ename=@ename and edate=@edate", con);
            cmd.Parameters .AddWithValue ("etype",etype .Text );
            cmd.Parameters .AddWithValue ("description",description .Text );
            cmd.Parameters.AddWithValue("venue", venue.Text);
            cmd.Parameters.AddWithValue("ename", ename);
            cmd.Parameters .AddWithValue ("edate",edate .ToString ("dd-MMM-yyyy") );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            GridView1.EditIndex = -1;
            BindGrid();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
           string ename = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
           DateTime edate = DateTime.Parse(GridView1.DataKeys[e.RowIndex].Values[1].ToString());

            cmd = new SqlCommand("delete from etable where ename=@ename and edate=@edate", con);
            cmd.Parameters.AddWithValue("ename", ename);
            cmd.Parameters.AddWithValue("edate", edate.ToString("dd-MMM-yyyy"));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            BindGrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
