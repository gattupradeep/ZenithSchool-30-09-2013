using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class noticeboard_editnoticetype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillnoticetype();
            trdate.Visible = false;
        }
    }
    protected void fillnoticetype()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblnoticeboard where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgnoticetype.DataSource = ds.Tables[0];
        dgnoticetype.DataBind();

    }
    protected void clear()
    {
        txtnoticename.Text = "";
        txtdate.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("SPnoticename", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@strnoticename", txtnoticename.Text.Trim());
        RegCommand.Parameters.Add("@dtdate","");
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 255);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 255);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully!')", true);
        } 
        fillnoticetype();
        clear();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void dgnoticetype_editcommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtnoticename.Text = e.Item.Cells[1].Text;
        txtdate.Text = e.Item.Cells[2].Text;
        btnSave.Text = "Update";
    }
    //protected void dgnoticetype_deletecommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblnoticeboard where intID=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblnoticeboard where intID=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),255);

        da.ExceuteSqlQuery(sql);
        fillnoticetype();
    }
}
