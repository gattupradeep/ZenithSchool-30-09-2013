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

public partial class admin_viewexampapers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["PatronType"].ToString() != "Admin" && Session["PatronType"].ToString() != "Super Admin")
            {
                btnedit.Visible = false;
                btnadd.Visible = false;
            }
        }
        catch
        {
            Response.Redirect("../login.aspx");
        }
        if (!IsPostBack)
        {
            fillstandard();
            fillsubject();
        }
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        trgrid.Visible = false;
        trerror.Visible = false;
        fillsubject();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillexampapers();
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        Session["ExamPaperStandard"] = null;
        Session["ExamPaperSubject"] = null;

        Response.Redirect("../school/assignexampapers.aspx");
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
        {
            Session["ExamPaperStandard"] = ddlstandard.SelectedValue;
            Session["ExamPaperSubject"] = ddlsubject.SelectedValue;
            Response.Redirect("assignexampapers.aspx?sid=" + Session["SchoolID"].ToString());
        }
    }

    protected void fillstandard()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select strstandard + ' - ' + strsection as strclass from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        ds = da.ExceuteSql(sql);

        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataSource = ds;
        ddlstandard.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlstandard.Items.Insert(0, li);
    }

    protected void fillsubject()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strsubject from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(sql);

        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataSource = ds;
        ddlsubject.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlsubject.Items.Insert(0, li);
    }

    protected void fillexampapers()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strexampaper from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " group by strexampaper ";
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            sql = "select strexampaper from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'  and strsubject='" + ddlsubject.SelectedValue + "'  group by strexampaper ";
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                blexampapers.DataSource = ds.Tables[0];
                blexampapers.DataTextField = "strexampaper";
                blexampapers.DataValueField = "strexampaper";
                blexampapers.DataBind();
                trgrid.Visible = true;
                trerror.Visible = false;
            }
            else
            {
                trgrid.Visible = false;
                trerror.Visible = true;
            }
        }
        else
            Response.Redirect("../school/assignexampapers.aspx");
    }
}

