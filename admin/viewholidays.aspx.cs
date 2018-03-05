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

public partial class admin_viewholidays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            fillyear();
            fillcalender();
            //if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || Session["PatronType"].ToString() == "Teaching Staffs")
            //{
            //    trsidemenu.Visible = false;
            //}
        }
    }
    private void fillyear()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblacademicyear where intyear > = (select intyear from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "intyear";
        ddlyear.DataValueField = "intyear";
        ddlyear.DataBind();
    }
    private void fillcalender()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intid,convert(varchar(10),dtdate,111) as date,datename(dw,dtdate) as dayname,strholidayname from tblacademiccalender  where intschool=" + Session["SchoolID"].ToString() + " and  stryear='" + ddlyear.SelectedValue + "' order by dtdate asc";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgcalender.DataSource = ds;
            dgcalender.DataBind();
            dgcalender.Visible = true;
        }
        else
        {
            dgcalender.Visible = false;
        }       
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillcalender();
    }
}
