using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class student_viewlessons : System.Web.UI.Page
{
    public string str;
    public DataSet ds;
    public string viewlid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewlid = Request["lid"];
            filldetails();
            fillunitdetails();
        }
    }
    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        str = "select a.intid, a.strstandard,a.strsection,a.strsubject,a.strtextbook,convert(varchar(10),a.dtfromdate,103) as dtfromdate,convert(varchar(10),a.dttodate,103) as dttodate,a.intemployee,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as empname from tblsetlessondetails a, tblemployee b where a.intschool='" + Session["SchoolID"] + "' and a.intemployee=b.intid and a.intid='" + viewlid + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblclass.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblsection.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
            lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
            lbltextbook.Text = ds.Tables[0].Rows[0]["strtextbook"].ToString();
            lblfromdate.Text = ds.Tables[0].Rows[0]["dtfromdate"].ToString();
            lbltodate.Text = ds.Tables[0].Rows[0]["dttodate"].ToString();
            lblteachername.Text = ds.Tables[0].Rows[0]["empname"].ToString();
        }
        
    }
    protected void fillunitdetails()
    {
        DataAccess da = new DataAccess();
        str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strunitname,a.strlessonname,b.strlessonname as lessonname,a.strtopic,a.strdescription,a.noofperiods from tblsetlesson a, tblschoolsyllabus b where a.intlesson = '" + viewlid + "' and b.intid =a.strlessonname order by dtdate";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        dgviewlessons.DataSource = ds;
        dgviewlessons.DataBind();
    }
   
}
