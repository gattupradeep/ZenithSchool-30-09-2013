﻿using System;
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

public partial class specialclasses_search_view_specialclasses : System.Web.UI.Page
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
            fillclass();
            //filldetails();
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
            {
                ddlclass.SelectedValue = Session["StudentClass"].ToString();
                ddlclass.Enabled = false;
                fillsubject();
                filldetails();
            }
            if (Request.QueryString["Class"] != null)
            {
                ddlclass.SelectedValue = Request.QueryString["Class"];
                fillsubject();
                //fillteacher();
                filldetails();
            }
        }
    }
    protected void fillclass()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strClass from tblspecialclasses where intSchoolID=" + Session["SchoolID"].ToString() + " group by strClass";
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strClass";
        ddlclass.DataValueField = "strClass";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "--select--");
    }
    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strSubject from tblspecialclasses where intSchoolID=" + Session["SchoolID"].ToString() + " and strClass='"+ ddlclass.SelectedValue+"' group by strSubject";        
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strSubject";
        ddlsubject.DataValueField = "strSubject";
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "--Select--");
    }
    protected void fillteacher()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,a.intid from tblemployee a,tblspecialclasses b where a.intID=b.intEmployeeID and a.intSchool=" + Session["SchoolID"].ToString() + " and b.strClass='" + ddlclass.SelectedValue + "' and strSubject='" + ddlsubject.SelectedValue + "' and IsEmployeeOthers=0 group by a.strfirstname ,a.strmiddlename ,a.strlastname,a.intid ";
        strsql = strsql + " union all select 'Others' as  name,'' as intid";
        ds = da.ExceuteSql(strsql);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "name";
        ddlteacher.DataValueField = "intid";
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "--Select--");
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        filldetails();
    }

    protected void filldetails()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select a.*,convert(varchar(10),a.dtDate,103) as date,b.strfirstname + ' ' + b.strmiddlename + ' ' + b.strlastname as name from tblspecialclasses a,tblemployee b where a.intSchoolID=" + Session["SchoolID"].ToString() + " and b.intID=a.intEmployeeID ";
        if (ddlteacher.SelectedIndex > 0)
        {
            if (ddlteacher.SelectedItem.Text != "Others")
                strsql += "  and a.intEmployeeID=" + ddlteacher.SelectedValue + " and a.IsEmployeeOthers=0";
            else
                strsql += "  and a.IsEmployeeOthers=1 ";
        }
        if (ddlclass.SelectedIndex > 0)
            strsql = strsql + " and a.strClass='" + ddlclass.SelectedValue + "'";
        if (txtdate.Text != "")
            strsql = strsql + " and a.dtDate='" + txtdate.Text.Trim() + "'";
        if (ddlsubject.SelectedIndex > 0)
            strsql = strsql + " and a.strSubject='" + ddlsubject.SelectedValue + "'";
        strsql += " order by dtDate desc";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgspecialclass.DataSource = ds;
            dgspecialclass.DataBind();
            lblmsg.Visible = false;
            dgspecialclass.Visible = true;
        }
        else
        {
            lblmsg.Text = "No search criteria found for selected";
            lblmsg.Visible = true;
            dgspecialclass.Visible = false;
        }
    }
    
    protected void dgspecialclass_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("view_specialclasses.aspx?Vid=" + e.Item.Cells[0].Text);
    }

    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        filldetails();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillteacher();
        filldetails();
    }
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
    }
}
