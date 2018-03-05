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

public partial class transport_driver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            fillgrid();
            Clear();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select intid,strdrivername,straddress+','+strarea+','+strcity+','+strstate as address,strcountry ,strphoneno+','+strmobileno as contact from tbldriver where intschool="+ Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgdriver.DataSource = ds;
        dgdriver.DataBind();
        Clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        conn.Open();
        command = new SqlCommand("SPdriver", conn);
        param = command.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;
        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        command.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intid", "0");
        }
        else
        {
            command.Parameters.Add("@intid", Session["intid"].ToString());
        }

        command.Parameters.Add("@strdrivername", txtdriver.Text.Trim());
        command.Parameters.Add("@dtdateofbirth", txtdateofbirth.Text.Trim());
        command.Parameters.Add("@strlicenceno", txtlicenceno.Text.Trim());
        command.Parameters.Add("@dtlicenceissuedate", txtissuedate.Text.Trim());
        command.Parameters.Add("@dtlicennceexpirydate", txtexpirydate.Text.Trim());
        command.Parameters.Add("@strmodeoflicence", ddlmode.SelectedValue);
        command.Parameters.Add("@straddress", txtaddress.Text.Trim());
        command.Parameters.Add("@strarea", txtarea.Text.Trim());
        command.Parameters.Add("@strcity", txtcity.Text.Trim());
        command.Parameters.Add("@strstate", txtstate.Text.Trim());
        command.Parameters.Add("@strcountry", txtcountry.Text.Trim());
        command.Parameters.Add("@strphoneno", txtphoneno.Text.Trim());
        command.Parameters.Add("@strmobileno", txtmobile.Text.Trim());
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.ExecuteNonQuery();
        conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldriver", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 115);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldriver", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 115);
        }
        Clear();
        fillgrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
    }
    private void Clear()
    {
        txtdriver.Text = "";
        txtphoneno.Text = "";
        txtaddress.Text = "";
        txtarea.Text = "";
        txtcountry.Text = "";
        txtcity.Text = "";
        txtstate.Text = "";       
        txtmobile.Text = "";
        txtlicenceno.Text = "";
        btnSave.Text = "Save";
        txtexpirydate.Text = "";
        txtdateofbirth.Text = "";
        txtissuedate.Text = "";
       
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    //protected void dgdriver_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tbldriver where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //    Clear();
    //}
    protected void dgdriver_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string sql = "select strdrivername,convert(varchar(10),dtdateofbirth,111) as dateofbirth,strlicenceno,convert(varchar(10),dtlicenceissuedate,111) as licenceissuedate,convert(varchar(10),dtlicennceexpirydate,111) as licennceexpirydate,strmodeoflicence,straddress,strarea,strcity,strstate,strcountry,strphoneno,strmobileno from tbldriver where intschool=" + Session["SchoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtdriver.Text = ds.Tables[0].Rows[0]["strdrivername"].ToString();
            txtdateofbirth.Text = ds.Tables[0].Rows[0]["dateofbirth"].ToString();
            txtlicenceno.Text = ds.Tables[0].Rows[0]["strlicenceno"].ToString();
            txtissuedate.Text = ds.Tables[0].Rows[0]["licenceissuedate"].ToString();
            txtexpirydate.Text = ds.Tables[0].Rows[0]["licennceexpirydate"].ToString();
            ddlmode.SelectedValue = ds.Tables[0].Rows[0]["strmodeoflicence"].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
            txtarea.Text = ds.Tables[0].Rows[0]["strarea"].ToString();
            txtcity.Text = ds.Tables[0].Rows[0]["strcity"].ToString();
            txtstate.Text = ds.Tables[0].Rows[0]["strstate"].ToString();
            txtcountry.Text = ds.Tables[0].Rows[0]["strcountry"].ToString();
            txtphoneno.Text = ds.Tables[0].Rows[0]["strphoneno"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["strmobileno"].ToString();
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
            string sql = "delete tbldriver where intid=" + item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbldriver", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 115);
            fillgrid();
            Clear();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
        }
    }
}

