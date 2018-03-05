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

public partial class transport_requestpopup : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlsection.Items.Insert(0, "--Select--");
            ddlname.Items.Insert(0, "--Select--");
        }
    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        da = new DataAccess();
        ds = new DataSet();
        sql = "select intadmitno from tblstudent where intid=" + ddlname.SelectedValue + " and  intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        Session["admissionno"] = ds.Tables[0].Rows[0]["intadmitno"].ToString();
        //Response.Write("<script language=javascript> window.close();</script>");
        //Response.End();
        Session["studentid"] = ddlname.SelectedValue;
        Session["standard"] = ddlstandard.SelectedValue;
        Session["section"] = ddlsection.SelectedValue;
        string script = "this.window.opener.location=this.window.opener.location;this.window.close();";
        if (!ClientScript.IsClientScriptBlockRegistered("RequestWithdrawalForm.aspx"))
            ClientScript.RegisterClientScriptBlock(typeof(string), "RequestWithdrawalForm.aspx", script, true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript> window.close();</script>");
        Response.End();
    }
    protected void fillstandard()
    {
        string str = "select strstandard from tblstudent where intschool = '" + Session["SchoolID"].ToString() + "' group by strstandard ";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.Items.Clear();
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
    }
    protected void fillsection()
    {
        string str = " select strsection from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and intschool = '" + Session["SchoolID"].ToString() + "'  group by strsection ";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlsection.Items.Clear();
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        ddlsection.Items.Insert(0, "--Select--");
    }
    protected void fillname()
    {
        string strsql = "";
        DataAccess da = new DataAccess();
        strsql = " select strfirstname + ' ' + strmiddlename + ' ' + strlastname as name,intid from tblstudent where  intschool='" + Session["SchoolID"].ToString() + "'";
        if (ddlstandard.SelectedIndex > 0)
            strsql = strsql + " and strstandard='" + ddlstandard.SelectedValue + "'";
        if (ddlsection.SelectedIndex > 0)
            strsql = strsql + " and strsection='" + ddlsection.SelectedValue + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlname.Items.Clear();
        ddlname.DataSource = ds;
        ddlname.DataTextField = "name";
        ddlname.DataValueField = "intid";
        ddlname.DataBind();
        ddlname.Items.Insert(0, "--Select--");
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsection();
        fillname();
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillname();
    }
    protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
    {
        da = new DataAccess();
        ds = new DataSet();
        sql = "select intadmitno from tblstudent where intid=" + ddlname.SelectedValue + " and  intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        lbladmitno.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
    }
}
