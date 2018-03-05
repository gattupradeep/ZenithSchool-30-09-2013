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
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
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

    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        string sql = "select strstandard + ' - ' + strsection as strclass from tblstandard_section_subject where intschool=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        DataSet ds = new DataSet();
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
        DataAccess da = new DataAccess();
        string sql = "select strsubject from tblstandard_section_subject where intschool=" + Session["SchoolID"].ToString() + " and strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "' group by strsubject";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataSource = ds;
        ddlsubject.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlsubject.Items.Insert(0, li);
    }


    protected void filldetails()
    {
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
            string qry;
            da = new DataAccess();
            ds = new DataSet();
            qry = "select strexampaper from tblschoolexampaper where intschool=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            ds = da.ExceuteSql(qry);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {

                for (int i = 0; i < chkexampapers.Items.Count; i++)
                {
                    if (chkexampapers.Items[i].Text == ds.Tables[0].Rows[j]["strexampaper"].ToString())
                        chkexampapers.Items[i].Selected = true;
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
                btnsave.Text = "Update";
            else
                btnsave.Text = "Save";
        }
        catch { }
    }

    protected void fillexampaper()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblexampaper"; 
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        chkexampapers.Items.Clear(); 
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strexampaper"].ToString(), ds.Tables[0].Rows[i]["strexampaper"].ToString());
            chkexampapers.Items.Add(li);
        }
    }

    protected void btnaddexam_Click(object sender, EventArgs e)
    {
        Session["SelectedExamPapers"] = selectedpapers();
        if (txtaddexampaper.Text != "")
        {
            try
            {
                string str;
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                str = "select * from tblexampaper where strexampaper='" + txtaddexampaper.Text.ToString() + "'";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Exam Paper Already Exists!')", true);
                }
                else
                {
                    strsql = " insert into tblexampaper(strexampaper)values('" + txtaddexampaper.Text + "')";
                    cmd = new SqlCommand(strsql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    txtaddexampaper.Text = "";
                    fillexampaper();
                    fillexampaper1();
                }
            }
            catch { }
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
            str = "delete tblschoolexampaper where intschool=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            da.ExceuteSqlQuery(str);
            for (int i = 0; i < chkexampapers.Items.Count; i++)
            {
                if (chkexampapers.Items[i].Selected == true)
                {
                    str = "";
                    da = new DataAccess();
                    str = "insert into tblschoolexampaper(strexampaper,intschool,strclass,strsubject)values('" + chkexampapers.Items[i].Value + "'," + Session["SchoolID"].ToString() + ",'" + ddlstandard.SelectedValue + "','" + ddlsubject.SelectedValue + "')";
                    da.ExceuteSqlQuery(str);
                }
            }
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class & Subject')", true);
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

    protected void redirectpages()
    {
        Session["UserRights"] = "No";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "";
        sql = "select * from tbldetails where intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        Session["SProfileIndex"] = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "";
            sql = "select * from tbltimingsandperiods where intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            Session["SProfileIndex"] = 2;
            if (ds.Tables[0].Rows.Count > 0)
            {
                da = new DataAccess();
                ds = new DataSet();
                sql = "";
                sql = "select * from tblworkingdays where intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(sql);
                Session["SProfileIndex"] = 3;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    da = new DataAccess();
                    ds = new DataSet();
                    sql = "";
                    sql = "select * from tblschoolstandard where intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(sql);
                    Session["SProfileIndex"] = 4;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        da = new DataAccess();
                        ds = new DataSet();
                        sql = "";
                        sql = "select * from tblstandard_section_subject where intschool=" + Session["SchoolID"].ToString();
                        ds = da.ExceuteSql(sql);
                        Session["SProfileIndex"] = 5;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            da = new DataAccess();
                            ds = new DataSet();
                            sql = "";
                            sql = "select * from tblexamorder where intschool=" + Session["SchoolID"].ToString();
                            ds = da.ExceuteSql(sql);
                            Session["SProfileIndex"] = 6;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                da = new DataAccess();
                                ds = new DataSet();
                                sql = "";
                                sql = "select * from tblschoolexampaper where intschool=" + Session["SchoolID"].ToString();
                                ds = da.ExceuteSql(sql);
                                Session["SProfileIndex"] = 7;
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    da = new DataAccess();
                                    ds = new DataSet();
                                    sql = "";
                                    sql = "select * from tblschoolexamsettings where intschool=" + Session["SchoolID"].ToString();
                                    ds = da.ExceuteSql(sql);
                                    Session["SProfileIndex"] = 8;
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        da = new DataAccess();
                                        ds = new DataSet();
                                        sql = "";
                                        sql = "select * from tblschoolgrading where intschool=" + Session["SchoolID"].ToString();
                                        ds = da.ExceuteSql(sql);
                                        Session["SProfileIndex"] = 9;
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            Session["SProfileIndex"] = 10;
                                            Session["UserRights"] = "Yes";
                                            Response.Redirect("viewschooldetails.aspx");
                                        }
                                        else
                                            Response.Redirect("schoolgrading.aspx");
                                    }
                                    else
                                        Response.Redirect("examdetailsettings.aspx");
                                }
                                else
                                    Response.Redirect("assignexampapers.aspx");
                            }
                            else
                                Response.Redirect("assignexamtypes.aspx");
                        }
                        else
                            Response.Redirect("subject_language_ExtraCurricular.aspx");
                    }
                    else
                        Response.Redirect("Class_Section_Subject_Details.aspx");
                }
                else
                    Response.Redirect("workingdays.aspx");
            }
            else
                Response.Redirect("timingsandperiods.aspx");
        }
        else
            Response.Redirect("schooldetails.aspx");
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
    }
}
