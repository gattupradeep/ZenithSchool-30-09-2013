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

public partial class specialclasses_view_specialclasses : System.Web.UI.Page
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
            if (Request["Vid"] != null)
            {
                filldetails();
            }
        }
    }
    protected void filldetails()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select *,convert(varchar(10),dtDate,103) as date,strStartTime+'-'+strEndTime as time,b.strfirstname + ' ' + b.strmiddlename + ' ' + b.strlastname as name from tblspecialclasses a,tblemployee b  where a.intSchoolID=" + Session["SchoolID"].ToString() + " and a.intEmployeeID=b.intid and intSpecialClassesID=" + Request["Vid"].ToString();

        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblclass.Text = ds.Tables[0].Rows[0]["strClass"].ToString();
            lbldate.Text = ds.Tables[0].Rows[0]["date"].ToString();
            lbltime.Text = ds.Tables[0].Rows[0]["time"].ToString();
            lblsubject.Text = ds.Tables[0].Rows[0]["strSubject"].ToString();
            lblteacher.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblremarks.Text = ds.Tables[0].Rows[0]["strRemarks"].ToString();
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_view_specialclasses.aspx?Class=" + lblclass.Text);
    }
}
