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

public partial class admission_view_admission_result : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["lid"] != null)
                filldetails();
        }
    }
    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select b.intid,a.intapplication,a.strstandard,a.intmarksscored,a.strresult,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name,c.intmarksrequired,c.intpassmarks,d.strattendance from tbladmissionstudentmarks a,tblstudentadmission b,tbladmissionpassmarkassigned c,tbladmissionattendance d where b.intid=d.intapplication and a.intapplication=b.intid and a.strstandard=c.strstandard  and a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=" + Request["lid"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblno.Text = ds.Tables[0].Rows[0]["intapplication"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblstudentname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblmaximummarks.Text = ds.Tables[0].Rows[0]["intmarksrequired"].ToString();
            lblpassmarks.Text = ds.Tables[0].Rows[0]["intpassmarks"].ToString();
            lblmarksgained.Text = ds.Tables[0].Rows[0]["intmarksscored"].ToString();
            lblresult.Text = ds.Tables[0].Rows[0]["strresult"].ToString();
            lblattendance.Text = ds.Tables[0].Rows[0]["strattendance"].ToString();
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewselected_rejected_studentlist.aspx?lid");
    }
}