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

public partial class transport_owner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select intID, strownername, straddress +','+strarea+','+strcity+','+strstate as address,strcountry,strphoneno+','+strmobile as contact from tblowner where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgowner.DataSource = ds;
        dgowner.DataBind();
        Clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        Conn.Open();
        RegCommand = new SqlCommand("SPowner", Conn);
        param = RegCommand.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
        }
        RegCommand.Parameters.Add("@strownername", txtowner.Text.Trim());
        RegCommand.Parameters.Add("@straddress", txtaddress.Text.Trim());
        RegCommand.Parameters.Add("@strarea", txtarea.Text.Trim());
        RegCommand.Parameters.Add("@strcity", txtcity.Text.Trim());
        RegCommand.Parameters.Add("@strstate", txtstate.Text.Trim());
        RegCommand.Parameters.Add("@strcountry", txtcountry.Text.Trim());
        RegCommand.Parameters.Add("@strphoneno", txtphone.Text.Trim());
        RegCommand.Parameters.Add("@strmobile", txtmobile.Text.Trim());
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Vendor is already Available!");
        }
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblowner", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 114);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblowner", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 114);
        }
        fillgrid();
        Clear();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtowner.Text = "";
        txtaddress.Text = "";
        txtarea.Text = "";
        txtcountry.Text = "";
        txtcity.Text = "";
        txtstate.Text = "";        
        txtphone.Text = "";
        txtmobile.Text = "";
        btnSave.Text = "Save";
    }
    //protected void dgowner_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblowner where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //    Clear();
    //}
    protected void dgowner_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string sql = "select * from tblowner where intschool=" + Session["SchoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtowner.Text = ds.Tables[0].Rows[0]["strownername"].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
            txtarea.Text = ds.Tables[0].Rows[0]["strarea"].ToString();
            txtcity.Text = ds.Tables[0].Rows[0]["strcity"].ToString();
            txtstate.Text = ds.Tables[0].Rows[0]["strstate"].ToString();
            txtcountry.Text = ds.Tables[0].Rows[0]["strcountry"].ToString();
            txtphone.Text = ds.Tables[0].Rows[0]["strphoneno"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["strmobile"].ToString();
        }
        btnSave.Text = "Update";
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblowner where intid=" + item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            Functions.UserLogs(Session["UserID"].ToString(), "tblowner", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 114);
            fillgrid();
            Clear();
        }
        catch 
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
        }
    }
}
