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

public partial class usercontro_right_resources : System.Web.UI.UserControl 
{
    public DataAccess da;
    public DataSet ds;
    public string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcountry();
            fillstate();
            fillschool();
        }
    }

    protected void fillcountry()
    {
        try
        {
            DataAccess da = new DataAccess();
            str = "select * from tblcountry where id in(select intcountry from tbldetails group by intcountry) order by countryname";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcountry.DataSource = ds.Tables[0];
                ddlcountry.DataTextField = "countryname";
                ddlcountry.DataValueField = "id";
                ddlcountry.DataBind();
            }
        }
        catch { }
    }

    protected void fillstate()
    {
        try
        {
            DataAccess da = new DataAccess();
            str = "select * from tblstate where id in(select intstate from tbldetails where intcountry=" + ddlcountry.SelectedValue + " group by intstate) order by strstate";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlstate.DataSource = ds.Tables[0];
                ddlstate.DataTextField = "strstate";
                ddlstate.DataValueField = "id";
                ddlstate.DataBind();
            }
        }
        catch
        {
        }
    }

    protected void fillschool()
    {
        try
        {
            DataAccess da = new DataAccess();
            str = "select strschoolname,intschool from tbldetails where intcountry=" + ddlcountry.SelectedValue + " and intstate=" + ddlstate.SelectedValue + "  order by strschoolname";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlschool.DataSource = ds.Tables[0];
                ddlschool.DataTextField = "strschoolname";
                ddlschool.DataValueField = "intschool";
                ddlschool.DataBind();
            }
        }
        catch { }
    }
    protected void btngo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["SchoolID"] = ddlschool.SelectedValue;
            Response.Redirect("admin/login.aspx");
        }
        catch { }
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstate();
		fillschool();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillschool();
    }
}
