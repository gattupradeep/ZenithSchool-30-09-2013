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

public partial class Library_Mediastock : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlmt();
            fillddlmc();
            fillstockgrid();
        }
    }
    protected void fillddlmt()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblmediatype where intschool='" + Session["SchoolID"].ToString() + "' order by intid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlmt.DataSource = ds;
        ddlmt.DataTextField = "strmediatype";
        ddlmt.DataValueField = "intid";
        ddlmt.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlmt.Items.Insert(0, li);
    }

    protected void fillddlmc()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblmediacategory where intschool='" + Session["SchoolID"].ToString() + "' order by intid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlmc.DataSource = ds;
        ddlmc.DataTextField = "strmediacategory";
        ddlmc.DataValueField = "intid";
        ddlmc.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlmc.Items.Insert(0, li);
    }
   
    protected void fillstockgrid()
    {
        string sql;
        sql = "select a.*,ct,a.intnoofcopies-ct as avail,x.strmediatype,y.strmediacategory from tbladdmedia a,tblmediatype x, tblmediacategory y, (select intbarcode,isnull(count(*),0) as ct from tblissueamedia where intreturn=1 group by intbarcode union select intbarcode,0 as ct from tbladdmedia where intbarcode not in (select intbarcode from tblissueamedia where intreturn=1 group by intbarcode) group by intbarcode ) as b where a.intbarcode=b.intbarcode and a.intmediatype = x.intid and  a.intmediacategory = y.intid";
        if (ddlmt.SelectedIndex > 0)
            sql += " and a.intmediatype=" + ddlmt.SelectedValue;
        if (ddlmc.SelectedIndex > 0)
            sql += " and a.intmediacategory=" + ddlmc.SelectedValue;

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgmediastock.DataSource = ds;
        dgmediastock.DataBind();
    }

    protected void ddlmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstockgrid();
    }

    protected void ddlmc_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstockgrid();
    }
}

