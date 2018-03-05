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

public partial class student_lessonchanges : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select a.intid, a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,a.strsubject from tblsetlessonplan a,tblemployee b where a.intschool='" + Session["SchoolID"].ToString() + "' and a.intteacher=b.intid and a.intid=" + Request["lesson"];
            ds = da.ExceuteSql(sql);
            lblteacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
            lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
        }
    }
    protected void btnchanges_Click(object sender, EventArgs e)
    {
        if (Request["lesson"] != null)
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "insert into tblsetlessonplanchanges(intlessonid,strreqchanges,intchanges)values(" + Request["lesson"].ToString() + ",'" + txtchanges.Text + "',0)";
            ds = da.ExceuteSql(sql);

            DataSet ds2 = new DataSet();
            sql = "select max(intid) as intid from tblsetlessonplanchanges";
            ds2 = da.ExceuteSql(sql);
            Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplanchanges", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'approve_lesson_plan.aspx'; </script>");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'approve_lesson_plan.aspx'; </script>");
    }
}
