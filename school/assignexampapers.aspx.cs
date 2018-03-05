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

public partial class admin_assignexampapers : System.Web.UI.Page
{
    public DataAccess da, da1;
    public string str, sql;
    public DataSet ds, ds1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillsubject();
            fillexampaper();
            allclear();
            if (Request["sid"] != null)
                filldetails();
        }
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewexampapers.aspx");
    }

    protected void btnsave_Click1(object sender, EventArgs e)
    {
        selectedexampapers();
        redirectpages();
    }

    protected void btnaddexam_Click(object sender, EventArgs e)
    {
        Session["SelectedExamPapers"] = selectedpapers();
        if (txtaddexampaper.Text != "")
        {
            try
            {
                string str = "";
                DataSet ds = new DataSet();
                DataAccess da = new DataAccess();
                str = "select * from tblexampaper where strexampaper='" + txtaddexampaper.Text.ToString() + "'";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Exam Paper Already Exists!')", true);
                }
                else
                {
                    str = " insert into tblexampaper(strexampaper)values('" + txtaddexampaper.Text + "')";
                    da.ExceuteSqlQuery(str);
                    txtaddexampaper.Text = "";
                    fillexampaper();
                    fillexampaper1();

                    DataSet ds2 = new DataSet();
                    str = "select max(intexampaperid) as intexampaperid from tblexampaper";
                    ds2 = da.ExceuteSql(str);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblexampaper", ds2.Tables[0].Rows[0]["intexampaperid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),44);

                }
            }
            catch { }
        }
    }

    protected void fillstandard()
    {
        string str = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        str = "select strstandard + ' - ' + strsection as strclass from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        ds = da.ExceuteSql(str);
        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataSource = ds;
        ddlstandard.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlstandard.Items.Insert(0, li);
    }

    protected void fillsubject()
    {
        string str = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        str = "select strsubject from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(str);

        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataSource = ds;
        ddlsubject.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlsubject.Items.Insert(0, li);
    }

    protected void filldetails()
    {
        string str = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        try
        {
            if (Request["sid"] != null)
            {
                ddlstandard.SelectedValue = Session["ExamPaperStandard"].ToString();
                fillsubject();
                ddlsubject.SelectedValue = Session["ExamPaperSubject"].ToString();
                ddlstandard.Enabled = false;
                ddlsubject.Enabled = false;
            }

            str = "select strexampaper from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            ds = da.ExceuteSql(str);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < chkexampapers.Items.Count; i++)
                {
                    if (chkexampapers.Items[i].Text == ds.Tables[0].Rows[j]["strexampaper"].ToString())
                    {
                        chkexampapers.Items[i].Selected = true;
                        str = " select * from dbo.tblschoolexamsettings  where strexampapername='" + chkexampapers.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(str);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chkexampapers.Items[i].Enabled = false;
                        }
                    }
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnsave.Text = "Update";
                //Response.Redirect("../school/viewexampapers.aspx");
            }

            else
            {
                btnsave.Text = "Save";
            }

        }
        catch { }
    }

    protected void fillexampaper()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tblexampaper"; 
        ds = da.ExceuteSql(sql);

        chkexampapers.Items.Clear(); 
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strexampaper"].ToString(), ds.Tables[0].Rows[i]["strexampaper"].ToString());
            chkexampapers.Items.Add(li);
        }
    }

    protected void fillexampaper1()
    {
        try
        {
            for (int i = 0; i < chkexampapers.Items.Count; i++)
            {
                string[] abc = Session["SelectedExamPapers"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chkexampapers.Items[i].Value.ToString() == abc[j].Trim())
                        chkexampapers.Items[i].Selected = true;
                }
            }
        }
        catch { }
    }

    protected string selectedpapers()
    {
        string str = "";
        for (int i = 0; i < chkexampapers.Items.Count; i++)
        {
            if (chkexampapers.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkexampapers.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkexampapers.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected void allclear()
    {
        for (int i = 0; i < chkexampapers.Items.Count; i++)
        {
            chkexampapers.Items[i].Selected = false;
        }
    }

    protected void selectedexampapers()
    {
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
        {
            string str;
            DataAccess da = new DataAccess();
            str = "select intschoolexampaperid from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolexampaper", ds.Tables[0].Rows[i]["intschoolexampaperid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),44);

                }
            }

            str = "delete tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            da.ExceuteSqlQuery(str);
            for (int i = 0; i < chkexampapers.Items.Count; i++)
            {
                if (chkexampapers.Items[i].Selected == true)
                {
                    str = "";
                    da = new DataAccess();
                    str = "insert into tblschoolexampaper(strexampaper,intschoolid,strclass,strsubject)values('" + chkexampapers.Items[i].Value + "'," + Session["SchoolID"].ToString() + ",'" + ddlstandard.SelectedValue + "','" + ddlsubject.SelectedValue + "')";
                    da.ExceuteSqlQuery(str);

                    DataSet ds2 = new DataSet();
                    str = "select max(intschoolexampaperid) as intschoolexampaperid from tblschoolexampaper";
                    ds2 = da.ExceuteSql(str);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolexampaper", ds2.Tables[0].Rows[0]["intschoolexampaperid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),44);

                }
            }
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class & Subject')", true);
    }

    protected void redirectpages()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        Session["UserRights"] = "No";

        sql = "select * from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        Session["SProfileIndex"] = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            sql = "select * from tbltimingsandperiods where intschoolid = " + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            Session["SProfileIndex"] = 2;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sql = "select * from tblworkingdays where intschoolid = " + Session["SchoolID"].ToString();
                ds = new DataSet();
                ds = da.ExceuteSql(sql);
                Session["SProfileIndex"] = 3;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "select * from tblschoolstandard where intschoolid = " + Session["SchoolID"].ToString();
                    ds = new DataSet();
                    ds = da.ExceuteSql(sql);
                    Session["SProfileIndex"] = 4;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sql = "select * from tblstandard_section_subject where intschoolid = " + Session["SchoolID"].ToString();
                        ds = new DataSet();
                        ds = da.ExceuteSql(sql);
                        Session["SProfileIndex"] = 5;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sql = "select * from tblexamorder where intschoolid = " + Session["SchoolID"].ToString();
                            ds = new DataSet();
                            ds = da.ExceuteSql(sql);
                            Session["SProfileIndex"] = 6;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "select * from tblschoolexampaper where intschoolid = " + Session["SchoolID"].ToString();
                                ds = new DataSet();
                                ds = da.ExceuteSql(sql);
                                Session["SProfileIndex"] = 7;
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sql = "select * from tblschoolexamsettings where intschoolid = " + Session["SchoolID"].ToString();
                                    ds = new DataSet();
                                    ds = da.ExceuteSql(sql);
                                    Session["SProfileIndex"] = 8;
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        sql = "select * from tblschoolgrading where intschoolid = " + Session["SchoolID"].ToString();
                                        ds = new DataSet();
                                        ds = da.ExceuteSql(sql);
                                        Session["SProfileIndex"] = 9;
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            Session["SProfileIndex"] = 10;
                                            Session["UserRights"] = "Yes";
                                            Response.Redirect("../school/viewschooldetails.aspx");
                                        }
                                        else
                                            Response.Redirect("../school/schoolgrading.aspx");
                                    }
                                    else
                                        Response.Redirect("../school/examdetailsettings.aspx");
                                }
                                else
                                    Response.Redirect("../school/assignexampapers.aspx");
                            }
                            else
                                Response.Redirect("../school/assignexamtypes.aspx");
                        }
                        else
                            Response.Redirect("../school/subject_language_ExtraCurricular.aspx");
                    }
                    else
                        Response.Redirect("../school/Class_Section_Subject_Details.aspx");
                }
                else
                    Response.Redirect("../school/workingdays.aspx");
            }
            else
                Response.Redirect("../school/timingsandperiods.aspx");
        }
        else
            Response.Redirect("../school/schooldetails.aspx");
    }
    
}
