﻿using System;
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

public partial class timetable_showallsecondlanguage : System.Web.UI.Page
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
        str = "select b.strfirstname + ' ' + b.strmiddlename + ' ' + b.strlastname as strteachername,strlanguage as strlanguage2,strstandard1 as strstandard,strsection1 as strsection from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and a.intschool='" + Session["SchoolID"].ToString() + "' and b.intschool='" + Session["SchoolID"].ToString() + "' and a.strstandard+' - ' + a.strsection='" + Session["2ndlangstandard"].ToString() + "' and a.strday='" + Session["2ndlangday"].ToString() + "' and a.strperiod='" + Session["2ndlangperiod"].ToString() + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        dg2.DataSource = ds;
        dg2.DataBind();

        lbltitle.Text = Session["2ndlangstandard"].ToString() + " - " + Session["2ndlangday"].ToString() + " - " + Session["2ndlangperiod"].ToString();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>self.close()</script>");
    }
}
