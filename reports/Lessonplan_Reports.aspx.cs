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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

public partial class reports_Lessonplan_Reports : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds;
    public SqlDataAdapter da;
    public string sql;
    protected void Page_init(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        }
        else
        {
            fillreport();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclass();
            filllessonstatus();
            fillteacher();
            ddlsubject.Items.Insert(0, "-Select-");
            //ddltextbook.Items.Insert(0, "-Select-");
            //ddlunitno.Items.Insert(0, "-Select-");
            //ddllesson.Items.Insert(0, "-Select-");
        }
    }
    protected void fillclass()
    {
        string strsql = "";
        strsql = "select strstandard + ' - ' + strsection as classandsec from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard + ' - ' + strsection ";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "classandsec";
        ddlclass.DataValueField = "classandsec";
        ddlclass.Items.Clear();
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
        ddlclass.Items.Insert(1, "-All-");
    }
    protected void filllessonstatus()
    {
        ddllessonstatus.Items.Insert(0, "-Select-");
        ddllessonstatus.Items.Insert(1, "-All-");
        ddllessonstatus.Items.Insert(2, "Completed");
        ddllessonstatus.Items.Insert(3, "Not Completed");
    }
    protected void fillteacher()
    {
        string strsql = "";
        if (ddlclass.SelectedIndex > 1)
        {
            strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername, a.intid from tblemployee a,tblteachingclass b where b.intschool =" + Session["SchoolID"] + " and b.strteachclass='" + ddlclass.SelectedValue + "' and a.intid=b.intemployee group by a.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname";
        }
        else
        {
            strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as teachername, intid from tblemployee where strtype='Teaching Staffs' and intschool =" + Session["SchoolID"].ToString();
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "teachername";
        ddlteacher.DataValueField = "intid";
        ddlteacher.Items.Clear();
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "-Select-");
        ddlteacher.Items.Insert(1, "-All-");
    }
    protected void fillsubject()
    {
        ddlsubject.Items.Clear();
        string strsql = "";
        strsql = "select strsubject from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard ='" + ddlclass.SelectedValue + "' group by strsubject";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.Items.Clear();
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "-Select-");
        ddlsubject.Items.Insert(1, "-All-");
    }
    protected void filltextbook()
    {
        if (ddlsubject.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + ddlclass.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddltextbook.DataSource = ds;
            ddltextbook.DataTextField = "strtextbookname";
            ddltextbook.DataValueField = "intid";
            ddltextbook.Items.Clear();
            ddltextbook.DataBind();
            ddltextbook.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(1, "-All-");
        }
        else
        {
        }
    }
    protected void fillunit()
    {
        if (ddltextbook.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select strunitno from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' group by strunitno";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlunitno.DataSource = ds;
            ddlunitno.DataTextField = "strunitno";
            ddlunitno.DataValueField = "strunitno";
            ddlunitno.Items.Clear();
            ddlunitno.DataBind();
            ddlunitno.Items.Insert(0, "-Select-");
            ddlunitno.Items.Insert(1, "-All-");
        }
        else
        {
            ddlunitno.Items.Clear();
            ddlunitno.Items.Insert(0, "-Select-");
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
    }
    protected void filllesson()
    {
        if (ddlunitno.SelectedIndex > 1 && ddltextbook.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select strlessonname from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' and strunitno='" + ddlunitno.SelectedValue + "' group by strlessonname";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddllesson.DataSource = ds;
            ddllesson.DataTextField = "strlessonname";
            ddllesson.DataValueField = "strlessonname";
            ddllesson.Items.Clear();
            ddllesson.DataBind();
            ddllesson.Items.Insert(0, "-Select-");
            ddllesson.Items.Insert(1, "-All-");
        }
        else
        {
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        unitreset();
        trtxtbook.Visible = false;
        fillteacher();
        fillsubject();
        fillreport();
    }
    protected void ddllessonstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillreport();
    }
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        fillreport();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedIndex > 1)
        {
            trtxtbook.Visible = true;
            filltextbook();
            fillreport();
        }
        else
        {
            unitreset();
            fillreport();
            trtxtbook.Visible = false;
        }
    }
    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillunit();
        fillreport();
    }
    protected void ddlunitno_SelectedIndexChanged(object sender, EventArgs e)
    {
        filllesson();
        fillreport();
    }
    protected void ddllesson_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillreport();
    }
    protected void unitreset()
    {
        ddltextbook.Items.Clear();
        ddlunitno.Items.Clear();
        ddllesson.Items.Clear();
        ddltextbook.Items.Insert(0, "-Select-");
        ddlunitno.Items.Insert(0, "-Select-");
        ddllesson.Items.Insert(0, "-Select-");
    }
    protected void fillreport()
    {
        string repFilePath = "";
        sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname from tblsetlessonplan a, tblemployee b,tblschooltextbook c where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intactivemode=0";
        if (ddlclass.SelectedIndex > 1)
        {
            sql += " and a.strclassperiod LIKE '%" + ddlclass.SelectedValue + "'";
        }
        if (ddlclass.SelectedIndex <= 1)
        {
            sql += " and a.strclassperiod !=''";
        }
        if (ddlteacher.SelectedIndex > 1)
        {
            sql += " and a.intteacher ='" + ddlteacher.SelectedValue + "'";
        }
        if (ddlteacher.SelectedIndex <= 1)
        {
            sql += " and a.intteacher !=''";
        }
        if (ddlsubject.SelectedIndex > 1)
        {
            sql += " and a.strsubject='" + ddlsubject.SelectedValue + "'";
        }
        if (ddlsubject.SelectedIndex <= 1)
        {
            sql += " and a.strsubject !=''";
        }
        if (ddltextbook.SelectedIndex > 1)
        {
            sql += " and a.inttextbook='" + ddltextbook.SelectedValue + "'";
        }
        if (ddltextbook.SelectedIndex <= 1)
        {
            sql += " and a.inttextbook !=''";
        }
        if (ddlunitno.SelectedIndex > 1)
        {
            sql += " and a.strunitname='" + ddlunitno.SelectedValue + "'";
        }
        if (ddlunitno.SelectedIndex <= 1)
        {
            sql += " and a.strunitname !=''";
        }
        if (ddllesson.SelectedIndex > 1)
        {
            sql += " and a.strlessonname='" + ddllesson.SelectedValue + "'";
        }
        if (ddllesson.SelectedIndex <= 1)
        {
            sql += " and a.strlessonname !=''";
        }
        if (ddllessonstatus.SelectedIndex == 2)
        {
            sql += " and a.intcompleted=1";
        }
        if (ddllessonstatus.SelectedIndex == 3)
        {
            sql += " and a.intcompleted=0";
        }
        if (ddllessonstatus.SelectedIndex < 2)
        {
            sql += " and a.intcompleted < 2";
        }
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            sql += " and a.dtdate between convert(datetime,'" + txtfromdate.Text + "',103) and convert(datetime,'" + txttodate.Text + "',103)";
        }
        sql += "order by dtdate";
        DataSet1 ds = new DataSet1();
        da = new SqlDataAdapter(sql, conn);
        da.Fill(ds, "tblLessonplan");
        DataAccess logrda = new DataAccess();
        DataSet logrds = new DataSet();
        string rsqlquery = string.Empty;
        if (Session["UserID"].ToString() != "0")
        {
            rsqlquery = "select strfirstname+' '+strmiddlename+' '+strlastname as logedinname from tblemployee where intID='" + Session["UserID"] + "' ";
        }
        else
        {
            rsqlquery = "select 'Super Admin' as logedinname";
        }
        logrds = logrda.ExceuteSql(rsqlquery);
        if (logrds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables["tblLessonplan"].Rows.Count; i++)
            {
                string reportsortby = "";
                ds.tblLessonplan.Rows[i]["ReportGeneratedby"] = logrds.Tables[0].Rows[0]["logedinname"];
                if (ddlclass.SelectedIndex > 0)
                {
                    reportsortby = ddlclass.SelectedValue;
                }
                if (ddllessonstatus.SelectedIndex > 0)
                {
                    reportsortby += " And " + ddllessonstatus.SelectedValue;
                }
                if (ddlsubject.SelectedIndex > 0)
                {
                    reportsortby += " And " + ddlsubject.SelectedValue;
                }
                if (txtfromdate.Text != "" && txttodate.Text != "")
                {
                    reportsortby += "From :" + txtfromdate.Text + " To :" + txttodate.Text;
                }
                ds.tblLessonplan.Rows[i]["Reportsortby"] = reportsortby;
            }
        }
        if (ds.Tables["tblLessonplan"].Rows.Count == 0)
        {
            repFilePath = Server.MapPath("CR_Nodatafound.rpt");
        }
        else
        {
            repFilePath = Server.MapPath("CR_Lessonplan/CR_Lesson_Plan.rpt");
        }
        ReportDocument repDoc = new ReportDocument();
        repDoc.Load(repFilePath);
        repDoc.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = repDoc;
        CrystalReportViewer1.DataBind();
    }
    protected void bttnsearch_click(object sender, EventArgs e)
    {
        fillreport();
    }
}

