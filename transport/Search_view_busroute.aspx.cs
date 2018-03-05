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


public partial class transport_view_student_busroute : System.Web.UI.Page
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
            fillroute();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select convert(varchar(5),a.dtpickuptime,108) as dtpickuptime,convert(varchar(5),a.dtdroptime,108) as dtdroptime,b.strroutename,a.* from tblassignbusroute a, tblroute b where a.intschool=" + Session["SchoolID"].ToString() + " and a.introute=b.intid";
        if (ddlroute.SelectedIndex == 0)
        {
            sql += " and a.introute = ''";
        }
        if (ddlroute.SelectedIndex == 1)
        {
            sql += " and a.introute != ''";
        }
        if (ddlroute.SelectedIndex > 1)
        {
            sql += " and a.introute = '" + ddlroute.SelectedValue + "'";
        }
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgasgnbusroute.Visible = true;
            dgasgnbusroute.DataSource = ds.Tables[0];
            dgasgnbusroute.DataBind();
        }
        else
        {
            dgasgnbusroute.Visible = false;
        }
    }
    private void fillroute()
    {
        string sql;
        sql = "select * from tblroute where intschool="+ Session["SchoolID"];
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlroute.DataSource = ds;
        ddlroute.DataTextField = "strroutename";
        ddlroute.DataValueField = "intid";
        ddlroute.DataBind();
        ddlroute.Items.Insert(0, "-Select-");
        ddlroute.Items.Insert(1, "-All Routes-");
    }
    protected void ddlroute_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}

