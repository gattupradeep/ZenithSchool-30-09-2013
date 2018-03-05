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

public partial class reports_EReportcard_Individual : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds;
    public SqlDataAdapter da;
    public string strsql;
    public DataAccess dac;
    public DataSet dset;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillacademicyear();
            fillstandard();
            ddlstudent.Items.Insert(0, "-Select-");
        }
        else
        {
            if (ddlstandard.SelectedIndex > 0)
            {
                if (txtexamtype.Text != "")
                {
                    fillreport();
                }
            }
        }
    }
    protected void fillreport()
    {
        try
        {
            if (txtexamtype.Text != "")
            {
                string reportfilepath = "";

                DataAccess da1 = new DataAccess();
                DataSet ds1 = new DataSet();
                string strquery = "select intgroup from tblmarkcalculation where intschool = " + Session["SchoolID"] + " and strclass = '" + ddlstandard.SelectedValue + "'";
                ds1 = da1.ExceuteSql(strquery);
                if (ds1.Tables[0].Rows[0]["intgroup"].ToString() == "1")
                {
                    strsql = "select a1.*,avg,strgrade as Grade from";
                    strsql += " (select b.intstudent,g.strsubject as strsubjectname,a.strexampaper,a.intscoredmarks,b.strexamtype,(select top 1 strgrade";
                    strsql += " from tblschoolgrading where intschool=" + Session["SchoolID"] + " and a.intscoredmarks <= inttomarks and a.intscoredmarks >= intfrommarks order by";
                    strsql += " inttomarks desc ) as Grade1, b.strstandard as strclass,b.stryear, (select top 1 strbranch from tbldetails where intschool=" + Session["SchoolID"] + ")";
                    strsql += " as SchoolBranch , (select strfirstname+' '+strmiddlename+' '+strlastname as logedin from tblemployee where intid=" + Session["UserId"] + ")";
                    strsql += " as ReportGeneratedby , c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as strstudentname,";
                    strsql += " e.strfirstname+' '+e.strmiddlename+' '+e.strlastname as strhometeacher,g.intpassmark,g.intmaxmark,";
                    strsql += " g.intmaxmark as strmaxmark from tblstudentscoredmarks a,tblreportcard b,tblstudent c,tblemployee e,";
                    strsql += " tblhomeclass f,tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and";
                    strsql += " b.strexamtype in ('" + txtexamtype.Text.Replace(",", "','") + "') and a.intreportcard =b.intid and c.intid=b.intstudent";
                    strsql += " and f.strhomeclass=b.strstandard and f.intemployee=e.intid and b.strstandard = g.strclass and b.stryear='" + ddlacademicyear.SelectedValue + "' and";
                    strsql += " a.strexampaper=g.strexampapername and b.strexamtype = g.strexamtype";
                    if (ddlstandard.SelectedIndex > 0)
                    {
                        strsql += " and b.strstandard='" + ddlstandard.SelectedValue + "'";
                    }
                    strsql += " ) as a1,";
                    strsql += " (select intstudent,strexamtype, avg,strgrade from";
                    strsql += " (select b.intstudent,b.strexamtype,sum(a.intscoredmarks)/count(*) as avg from tblstudentscoredmarks a,";
                    strsql += " tblreportcard b,tblstudent c,tblemployee e, tblhomeclass f,tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + "";
                    strsql += " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and b.strexamtype in ('" + txtexamtype.Text.Replace(",", "','") + "')";
                    strsql += " and a.intreportcard =b.intid and c.intid=b.intstudent and f.strhomeclass=b.strstandard and ";
                    strsql += " f.intemployee=e.intid and b.strstandard = g.strclass and b.stryear='" + ddlacademicyear.SelectedValue + "' and a.strexampaper=g.strexampapername";
                    strsql += " and b.strexamtype = g.strexamtype";
                    if (ddlstandard.SelectedIndex > 0)
                    {
                        strsql += " and b.strstandard='" + ddlstandard.SelectedValue + "'";
                    }
                    strsql += " group by intstudent,b.strexamtype) as a,";
                    strsql += " tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " and avg>=intfrommarks and avg<=inttomarks) as b1 ";
                    strsql += " where a1.intstudent=b1.intstudent and a1.strexamtype=b1.strexamtype";

                    if (ddlstudent.SelectedIndex > 0)
                    {
                        strsql += " and b1.intstudent='" + ddlstudent.SelectedValue + "'";
                    }
                    if (rdPassed.Checked == true)
                    {
                        strsql += " and a1.intscoredmarks >= a1.intpassmark";
                    }
                    if (rdFailed.Checked == true)
                    {
                        strsql += " and a1.intscoredmarks < a1.intpassmark";
                    }
                }
                else
                {
                    strsql = "select x1.*,total,avg,strgrade as Grade from (select a1.*,subjecttotal,subjectmaxmark from (select b.intstudent,g.strsubject as strsubjectname,a.strexampaper,a.intscoredmarks,";
                    strsql += " b.strexamtype,(select top 1 strgrade from tblschoolgrading where intschool=" + Session["SchoolID"] + " and a.intscoredmarks <= inttomarks and ";
                    strsql += " a.intscoredmarks >= intfrommarks order by inttomarks desc ) as Grade1, b.strstandard as strclass,b.stryear, (select top 1 ";
                    strsql += " strbranch from tbldetails where intschool=" + Session["SchoolID"] + ") as SchoolBranch , (select strfirstname+' '+strmiddlename+' '+strlastname as ";
                    strsql += " logedin from tblemployee where intid=" + Session["UserID"] + ") as ReportGeneratedby , c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as ";
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
                    strsql += " f.strhomeclass=b.strstandard and  f.intemployee=e.intid and b.strstandard = g.strclass and b.stryear='" + ddlacademicyear.SelectedValue + "' and a.strexampaper=g.strexampapername ";
                    strsql += " and b.strexamtype = g.strexamtype and b.strstandard='" + ddlstandard.SelectedValue + "' group by intstudent,b.strexamtype,g.strsubject) as b1 ) as b2 where a1.intstudent=b2.intstudent and ";
                    strsql += " a1.strexamtype=b2.strexamtype and a1.strsubjectname=b2.strsubject and b2.intstudent=a1.intstudent) as x1,";
                    strsql += " (select intstudent,strexamtype,total, avg,strgrade from (select ";
                    strsql += " y2.intstudent,y2.strexamtype,sum(y2.subjecttotal) as total,(sum(y2.subjecttotal)*100/sum(y2.intmaxmark)) as avg from (select ";
                    strsql += " b.intstudent,b.strexamtype,g.strsubject,sum(a.intscoredmarks)/count(*)/count(*) as subjecttotal,sum(g.intmaxmark)/count(*)/count(*) as subjectmaxmark,g.intmaxmark from tblstudentscoredmarks a, tblreportcard b,tblstudent ";
                    strsql += " c,tblemployee e, tblhomeclass f,tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and ";
                    strsql += " b.strexamtype in ('" + txtexamtype.Text.Replace(",", "','") + "') and a.intreportcard =b.intid and c.intid=b.intstudent and ";
                    strsql += " f.strhomeclass=b.strstandard and  f.intemployee=e.intid and b.strstandard = g.strclass and a.strexampaper=g.strexampapername ";
                    strsql += " and b.strexamtype = g.strexamtype and b.strstandard='" + ddlstandard.SelectedValue + "' group by intstudent,b.strexamtype,g.strsubject,g.intmaxmark) as y2 group by y2.intstudent,y2.strexamtype) as y1, tblschoolgrading b ";
                    strsql += " where b.intschool=" + Session["SchoolID"] + " and avg>=intfrommarks and avg<=inttomarks) as b1  where x1.intstudent=b1.intstudent and ";
                    strsql += " x1.strexamtype=b1.strexamtype and b1.intstudent=x1.intstudent";
                    if (ddlstudent.SelectedIndex > 0)
                    {
                        strsql += " and b1.intstudent='" + ddlstudent.SelectedValue + "'";
                    }
                    if (rdPassed.Checked == true)
                    {
                        strsql += " and x1.intscoredmarks >= x1.intpassmark";
                    }
                    if (rdFailed.Checked == true)
                    {
                        strsql += " and x1.intscoredmarks < x1.intpassmark";
                    }                    
                }
                da = new SqlDataAdapter(strsql, conn);
                ds = new DataSet1();
                da.Fill(ds, "tbleroportcard");
                if (ds.tbleroportcard.Rows.Count > 0)
                {
                    if (rdPassed.Checked == true || rdFailed.Checked==true)
                    {
                        if (ds1.Tables[0].Rows[0]["intgroup"].ToString() == "1")
                        {
                            reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_PF.rpt");
                        }
                        else
                        {
                            reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Agg_PF.rpt");
                        }                        
                    }
                    else if (rdReportcard.Checked == true)
                    {
                        if (ds1.Tables[0].Rows[0]["intgroup"].ToString() == "1")
                        {
                            reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Reportcard.rpt");
                        }
                        else
                        {
                            reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Agg_Reportcard.rpt");
                        }
                    }
                    else if (rdCompare.Checked == true)
                    {
                        if (ds1.Tables[0].Rows[0]["intgroup"].ToString() == "1")
                        {
                        reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Withchart.rpt");
                        }
                        else
                        {
                            reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Agg_Withchart.rpt");
                        }
                    }
                    else
                    {
                        reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
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
        try
        {
            dac = new DataAccess();
            strsql = "select ID,intYear from tblacademicyear where intschool = " + Session["SchoolID"] + " order by ID desc";
            dset = new DataSet();
            dset = dac.ExceuteSql(strsql);
            ddlacademicyear.DataSource = dset;
            ddlacademicyear.DataTextField = "intYear";
            ddlacademicyear.DataValueField = "intYear";
            ddlacademicyear.DataBind();
        }
        catch { }
    }
    protected void fillstandard()
    {
        try
        {
            strsql = "select strstandard from tblreportcard where intschool = " + Session["SchoolID"] + " group by strstandard";
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            ddlstandard.DataSource = ds1;
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
        }
        catch { }
    }
    protected void fillstudent()
    {
        try
        {
            if (ddlstandard.SelectedIndex > 0)
            {
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as studentname from tblstudent where intschool = " + Session["SchoolID"] + " and strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "'";
                dac = new DataAccess();
                dset = new DataSet();
                dset = dac.ExceuteSql(strsql);
                ddlstudent.DataSource = dset;
                ddlstudent.DataTextField = "studentname";
                ddlstudent.DataValueField = "intid";
                ddlstudent.DataBind();
                ddlstudent.Items.Insert(0, "-All-");
            }
        }
        catch { }
    }
    protected void fillexamtype()
    {
        try
        {
            strsql = "select strexamtype from tblreportcard where intschool = " + Session["SchoolID"] + " and stryear = '" + ddlacademicyear.SelectedValue + "' and strstandard = '" + ddlstandard.SelectedValue + "' group by strexamtype";
            dac = new DataAccess();
            dset = new DataSet();
            dset = dac.ExceuteSql(strsql);
            ddlexamtype.DataSource = dset;
            ddlexamtype.DataTextField = "strexamtype";
            ddlexamtype.DataValueField = "strexamtype";
            ddlexamtype.DataBind();
        }
        catch { }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlstandard.SelectedIndex > 0)
            {
                fillstudent();
                txtexamtype.Text = "";
                fillexamtype();
            }
            else
            {
                ddlstudent.Items.Clear();
                ddlstudent.Items.Insert(0, "-Select-");
                ddlexamtype.Items.Clear();
            }
        }
        catch { }
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        try
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
            fillreport();
        }
        catch { }
    }
    protected void rdReportcard_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            if (txtexamtype.Text != "")
            {
                fillreport();
            }
        }
    }
    protected void rdPassed_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            if (txtexamtype.Text != "")
            {
                fillreport();
            }
        }
    }
    protected void rdFailed_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            if (txtexamtype.Text != "")
            {
                fillreport();
            }
        }
    }
    protected void rdCompare_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            if (txtexamtype.Text != "")
            {
                fillreport();
            }
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("EReportcard.aspx");
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("EReportcard_Perfomance.aspx");
    }
}
