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

public partial class admin_UserLogs : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string sql;
    public DataAccess da;
    public DataSet ds;
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstaffname();
            fillmenuname();
            fillactiontype();
        }
    }
    protected void fillactiontype()
    {
        sql = "select strActionType from tblUserLogs group by strActionType";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlActionType.DataSource = ds;
        ddlActionType.DataTextField = "strActionType";
        ddlActionType.DataValueField = "strActionType";
        ddlActionType.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlActionType.Items.Insert(0, li);
    }
    protected void fillstaffname()
    {
        sql = "select intid,strfirstname+' ' +ltrim(strmiddlename)+' ' +ltrim(strlastname) as name from tblemployee where intschool=" + Session["SchoolID"].ToString();
        sql += " union all select '' as intid,'Super Admin' as name";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "name";
        ddlstaffname.DataValueField = "intid";
        ddlstaffname.DataBind();
        ListItem li = new ListItem("-Select-", "-1");
        ddlstaffname.Items.Insert(0, li);
    }
    protected void fillmenuname()
    {
        sql = "select c.menuid,c.menuname from tblmenus c,tblUserLogs a,tblemployee b where a.intschoolid=" + Session["SchoolID"].ToString() + " and a.menuid=c.menuid ";
        if (ddlstaffname.SelectedIndex > 0)
        {
            sql += " a.intStaffID=b.intID ";
        }
        sql += " group by c.menuid,c.menuname";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlmenuname.DataSource = ds;
        ddlmenuname.DataTextField = "menuname";
        ddlmenuname.DataValueField = "menuid";
        ddlmenuname.DataBind();
        ddlmenuname.Items.Insert(0, "-Select-");
    }

    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();

        string strsql = "select a.intUserLogsID,a.dtDate,a.strActionType,convert(varchar(10),a.dtDate,103) as dtDate,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name";
        strsql += " ,c.menuname from tblUserLogs a,tblemployee b,tblmenus c where a.menuid=c.menuid and a.intStaffID=b.intID ";
        strsql += " and a.intschoolID=" + Session["SchoolID"].ToString();
        if (ddlActionType.SelectedIndex > 0)
        {
            strsql += " and a.strActionType='" + ddlActionType.SelectedValue + "'";
        }
        if (ddlstaffname.SelectedIndex > 0)
        {
            strsql += " and a.intStaffID= '" + ddlstaffname.SelectedValue + "'";
        }
        if (ddlmenuname.SelectedIndex > 0)
        {
            strsql += " and c.menuid='" + ddlmenuname.SelectedValue + "'";
        }
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            strsql += " and a.dtDate between convert(datetime,'" + txtfromdate.Text.Trim() + "',103) and convert(datetime,'" + txttodate.Text.Trim() + " 23:59:41.740',103)";
        }
        strsql += " group by b.strfirstname,b.strlastname,b.strmiddlename,a.intUserLogsID,a.strActionType,a.dtDate,c.menuname";
        strsql += " union all select a.intUserLogsID,a.dtDate,a.strActionType,convert(varchar(10),a.dtDate,103) as dtDate,'Super Admin' as name";
        strsql += " ,c.menuname from tblUserLogs a,tblemployee b,tblmenus c where a.menuid=c.menuid and a.intStaffID=0";
        strsql += " and a.intschoolID=" + Session["SchoolID"].ToString();
        if (ddlActionType.SelectedIndex > 0)
        {
            strsql += " and a.strActionType='" + ddlActionType.SelectedValue + "'";
        }
        if (ddlstaffname.SelectedIndex > 0)
        {
            strsql += " and a.intStaffID= '" + ddlstaffname.SelectedValue + "'";
        }
        if (ddlmenuname.SelectedIndex > 0)
        {
            strsql += " and c.menuid='" + ddlmenuname.SelectedValue + "'";
        }
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            strsql += " and a.dtDate between convert(datetime,'" + txtfromdate.Text.Trim() + "',103) and convert(datetime,'" + txttodate.Text.Trim() + " 23:59:41.740',103)";
        }
        strsql += " group by a.intUserLogsID,a.strActionType,a.dtDate,c.menuname ";

        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dguserlogs.DataSource = ds;
            dguserlogs.DataBind();
            
        }
        else
        {
            dguserlogs.DataSource = null;
            dguserlogs.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('No Data Found')", true);
            //MsgBox.alert("No Data Found");
        }            
    }
    protected void ddlActionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void dguserlogs_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dguserlogs.SelectedIndex = -1;
        dguserlogs.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
        ShowStats();

    }
    void ShowStats()
    {
       dguserlogs.CurrentPageIndex = 0;
    }
    protected void ddlmenuname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
