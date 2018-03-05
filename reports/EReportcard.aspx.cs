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

public partial class reports_Exam_EReportcard : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds;
    public SqlDataAdapter da;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillacademicyear();
            fillexamtype();
            fillstandard();
            ddlstudent.Items.Insert(0, "-Select-");
        }
        else
        {
            fillreport();
        }
    }
    protected void fillreport()
    {
        try 
        {
            if (txtexamtype.Text != "" && ddlstandard.SelectedIndex > 0)
            {
                string reportfilepath = "";

                DataAccess da1 = new DataAccess();
                DataSet ds1 = new DataSet();
                string strquery = "select intgroup from tblmarkcalculation where intschool = " + Session["SchoolID"] + " and strclass = '" + ddlstandard.SelectedValue + "'";
                ds1 = da1.ExceuteSql(strquery);
                if (ds1.Tables[0].Rows[0]["intgroup"].ToString() == "1")
                {
                    strsql = "select g.strsubject as strsubjectname,a.strexampaper,a.intscoredmarks,b.strexamtype, b.strstandard as strclass,b.stryear,";
                    strsql += " (select top 1 strbranch from tbldetails where intschool=" + Session["SchoolID"] + ") as SchoolBranch ,";
                    strsql += " (select strfirstname+' '+strmiddlename+' '+strlastname as logedin from tblemployee where intid=" + Session["UserID"] + ") as ReportGeneratedby ,";
                    strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as strstudentname,e.strfirstname+' '+e.strmiddlename+' '+e.strlastname";
                    strsql += " as strhometeacher,g.intpassmark,g.intmaxmark from tblstudentscoredmarks a,tblreportcard b,tblstudent c,tblemployee e,";
                    strsql += " tblhomeclass f,tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"];
                    strsql += " and b.strexamtype in ('" + txtexamtype.Text.Replace(",", "','") + "') and a.intreportcard =b.intid and c.intid=b.intstudent";
                    strsql += " and f.strhomeclass=b.strstandard and f.intemployee=e.intid and b.strstandard = g.strclass and b.stryear='" + ddlacademicyear.SelectedValue + "' and";
                    strsql += " a.strexampaper=g.strexampapername and b.strexamtype = g.strexamtype";
                    if (ddlstandard.SelectedIndex > 0)
                    {
                        strsql += " and b.strstandard='" + ddlstandard.SelectedValue + "'";
                    }
                    if (ddlstudent.SelectedIndex > 0)
                    {
                        strsql += " and b.intstudent='" + ddlstudent.SelectedValue + "'";
                    }
                }
                else
                {
                    strsql = "select a1.*,subjecttotal,subjectmaxmark from (select b.intstudent,g.strsubject as strsubjectname,a.strexampaper,a.intscoredmarks,";
                    strsql += " b.strexamtype,(select top 1 strgrade from tblschoolgrading where intschool="+Session["SchoolID"]+" and a.intscoredmarks <= inttomarks and ";
                    strsql += " a.intscoredmarks >= intfrommarks order by inttomarks desc ) as Grade1, b.strstandard as strclass,b.stryear, (select top 1 ";
                    strsql += " strbranch from tbldetails where intschool=" + Session["SchoolID"] + ") as SchoolBranch , (select strfirstname+' '+strmiddlename+' '+strlastname as ";
                    strsql += " logedin from tblemployee where intid=2) as ReportGeneratedby , c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as ";
                    strsql += " strstudentname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname as strhometeacher,g.intpassmark,g.intmaxmark, ";
                    strsql += " g.intmaxmark as strmaxmark from tblstudentscoredmarks a,tblreportcard b,tblstudent c,tblemployee e, tblhomeclass f,";
                    strsql += " tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and b.strexamtype in ";
                    strsql += " ('" + txtexamtype.Text.Replace(",", "','") + "') and a.intreportcard =b.intid and c.intid=b.intstudent and f.strhomeclass=b.strstandard ";
                    strsql += " and f.intemployee=e.intid and b.strstandard = g.strclass and b.stryear='" + ddlacademicyear.SelectedValue + "' and a.strexampaper=g.strexampapername and b.strexamtype = ";
                    strsql += " g.strexamtype and b.strstandard='" + ddlstandard.SelectedValue + "' ) as a1,";
                    strsql += " (select intstudent,strexamtype,strsubject,subjecttotal,subjectmaxmark from (select ";
                    strsql += " b.intstudent,b.strexamtype,g.strsubject,sum(a.intscoredmarks)/count(*)/count(*) as subjecttotal,sum(g.intmaxmark)/count(*)/count(*) as subjectmaxmark from tblstudentscoredmarks a, tblreportcard b,tblstudent ";
                    strsql += " c,tblemployee e, tblhomeclass f,tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and ";
                    strsql += " b.strexamtype in ('" + txtexamtype.Text.Replace(",", "','") + "') and a.intreportcard =b.intid and c.intid=b.intstudent and ";
                    strsql += " f.strhomeclass=b.strstandard and  f.intemployee=e.intid and b.strstandard = g.strclass and a.strexampaper=g.strexampapername ";
                    strsql += " and b.strexamtype = g.strexamtype and b.strstandard='" + ddlstandard.SelectedValue + "' group by intstudent,b.strexamtype,g.strsubject) as b1 ) as b2 where a1.intstudent=b2.intstudent and ";
                    strsql += " a1.strexamtype=b2.strexamtype and a1.strsubjectname=b2.strsubject and b2.intstudent=a1.intstudent";
                    if (ddlstudent.SelectedIndex > 0)
                    {
                        strsql += " and b2.intstudent='" + ddlstudent.SelectedValue + "'";
                    }
                }
                da = new SqlDataAdapter(strsql, conn);
                ds = new DataSet1();
                da.Fill(ds, "tbleroportcard");
                if (ds.tbleroportcard.Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0]["intgroup"].ToString() == "1")
                    {
                        reportfilepath = Server.MapPath("CR_ExamReportcard/CR_ERportcard_General.rpt");
                    }
                    else
                    {
                        reportfilepath = Server.MapPath("CR_ExamReportcard/CR_ERportcard_Agg_General.rpt");
                    }   
                    
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                }
                ReportDocument repDoc = new ReportDocument();
                repDoc.Load(reportfilepath);
                repDoc.SetDataSource(ds);
                CrystalReportViewer1.ReportSource = repDoc;
                //CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.DataBind();
            }
        }
        catch { }
    }
    protected void fillacademicyear()
    {
        strsql = "select ID,intYear, convert(varchar(4),Year(StartDate)) +' - '+ convert(varchar(4),Year(EndDate)) as acdyear from tblacademicyear where intschool = " + Session["SchoolID"] + " order by ID desc";
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        ddlacademicyear.DataSource = ds1;
        ddlacademicyear.DataTextField = "intYear";
        ddlacademicyear.DataValueField = "intYear";
        ddlacademicyear.DataBind();
    }
    protected void fillexamtype()
    {
        strsql = "select strexamtype from dbo.tblreportcard where intschool = " + Session["SchoolID"] + " group by strexamtype";
        //strsql = "select strexamtype from tblschoolexamsettings where intschool = " + Session["SchoolID"] + " group by strexamtype";
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        ddlexamtype.DataSource = ds1;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataBind();
    }
    protected void fillstandard()
    {
        strsql = "select strstandard from tblreportcard where intschool = "+Session["SchoolID"]+" group by strstandard";
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        ddlstandard.DataSource = ds1;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0,"-Select-");
    }
    protected void fillstudent()
    {
        ddlstudent.Items.Clear();
        if (ddlstandard.SelectedIndex > 0)
        {
            strsql = "select a.intstudent,b.strfirstname+' '+b.strmiddlename+''+b.strlastname as studentname from dbo.tblreportcard a,tblstudent b where a.intschool = " + Session["SchoolID"] + " and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intstudent = b.intid group by b.strfirstname+' '+b.strmiddlename+''+b.strlastname,a.intstudent";
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            ddlstudent.DataSource = ds1;
            ddlstudent.DataTextField = "studentname";
            ddlstudent.DataValueField = "intstudent";
            ddlstudent.DataBind();
            ddlstudent.Items.Insert(0, "All");
        }
        else
        {
            ddlstudent.Items.Insert(0, "-Select-");
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        string examname = "";
        for (int i = 0; i < ddlexamtype.Items.Count; i++)
        {
            if (ddlexamtype.Items[i].Selected)
            {
                examname += ddlexamtype.Items[i].Text + ",";
            }
        }
        txtexamtype.Text = examname;
        if (ddlstandard.SelectedIndex > 0)
        {
            fillreport();
        }
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstudent.SelectedIndex > 0)
        {
            fillreport();
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("EReportcard_Perfomance.aspx");
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("EReportcard_Individual.aspx");
    }
}
