using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class timetable_showextraactivities : System.Web.UI.Page
{
    public string str;
    public DataSet ds, ds1;
    public DataAccess da, da1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillsecondgrid();
    }

    protected void fillsecondgrid()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds, ds1 = new DataSet();
        da = new DataAccess();
        str = "select b.strfirstname + ' ' + b.strmiddlename + ' ' + b.strlastname as strteachername,strlanguage as strlanguage2 from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and a.intschool='" + Session["SchoolID"].ToString() + "' and b.intschool='" + Session["SchoolID"].ToString() + "' and a.strstandard='" + Session["2ndlangstandard"].ToString() + "' and a.strsection='" + Session["2ndlangsection"].ToString() + "' and a.strday='" + Session["2ndlangday"].ToString() + "' and a.strperiod='" + Session["2ndlangperiod"].ToString() + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        dg2.DataSource = ds;
        dg2.DataBind();

        lbltitle.Text = Session["2ndlangstandard"].ToString() + " " + Session["2ndlangsection"].ToString() + " - " + Session["2ndlangday"].ToString() + " - " + Session["2ndlangperiod"].ToString();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>self.close()</script>");
    }
}
