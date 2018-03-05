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

public partial class reports_EReportcard_Perfomance : System.Web.UI.Page
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
            ddlsection.Items.Insert(0,"-Select-");
            ddlsubject.Items.Insert(0,"-Select-");
        }
        else
        {
            if (ddlstandard.SelectedIndex > 0)
            {
                fillreport();
            }
        }
    }
    protected void fillreport()
    {
        try
        {
            string reportfilepath = "";
            if (ddlsubject.SelectedIndex > 0 && ddlstandard.SelectedIndex > 0)
            {
                strsql = "select (select top 1 strbranch from tbldetails where intschool=" + Session["SchoolID"] + ") as SchoolBranch,(select strfirstname+' '+strmiddlename+' '+strlastname as ";
                strsql += " logedin from tblemployee where intid=" + Session["UserID"] + ") as ReportGeneratedby , a1.*,strgrade as Grade from ";
                strsql += " (select b.intid,b.intstudent,g.strsubject as strsubjectname, c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as strstudentname,g.strclass, ";
                strsql += " e.strfirstname+' '+e.strmiddlename+' '+e.strlastname as strhometeacher,b.strstandard,b.strexamtype,sum(a.intscoredmarks) ";
                strsql += " as intscoredmarks, sum(g.intmaxmark) as totalmarks, sum(a.intscoredmarks) *100 /sum(g.intmaxmark) as Average from ";
                strsql += " tblstudentscoredmarks a,tblreportcard b ,tblstudent c,tblemployee e, tblhomeclass f,tblschoolexamsettings g where ";
                strsql += " b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + "  and g.intschool=" + Session["SchoolID"] + " and b.strexamtype ='" + ddlexamtype.SelectedValue + "' and a.intreportcard =b.intid and ";
                strsql += " c.intid=b.intstudent and f.strhomeclass=b.strstandard and f.intemployee=e.intid and b.strstandard = g.strclass and g.strsubject='" + ddlsubject.SelectedValue + "'";
                if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
                {
                    strsql += "  and b.strstandard Like '" + ddlstandard.SelectedValue + " -%'";
                }
                if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
                {
                    strsql += "  and b.strstandard ='" + ddlstandard.SelectedValue + " -" + ddlsection.SelectedValue + "'";
                }
                strsql += " and a.strexampaper=g.strexampapername and b.strexamtype = g.strexamtype and ";
                strsql += " b.stryear='" + ddlacademicyear.SelectedValue + "' group by b.intid, b.strexamtype,b.intstudent,b.strstandard,";
                strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,g.strclass,g.strsubject )";
                strsql += " as a1,tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " and  a1.Average>=intfrommarks and a1.Average<=inttomarks";
                if (txtavgfrom.Text != "" && txtavgto.Text != "")
                {
                    strsql += "  and Average in(select top " + ddltopten.SelectedValue + " a.* from  (select sum(a.intscoredmarks) *100 /sum(g.intmaxmark) as Average from tblstudentscoredmarks a,";
                    strsql += " tblreportcard b ,tblstudent c,tblemployee e, tblhomeclass f,";
                    strsql += " tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and b.strexamtype ='" + ddlexamtype.SelectedValue + "' ";
                    strsql += " and a.intreportcard =b.intid and c.intid=b.intstudent and f.strhomeclass=b.strstandard and f.intemployee=e.intid ";
                    strsql += " and b.strstandard = g.strclass and g.strsubject='" + ddlsubject.SelectedValue + "'";
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
                    {
                        strsql += "  and b.strstandard Like '" + ddlstandard.SelectedValue + " -%'";
                    }
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
                    {
                        strsql += "  and b.strstandard ='" + ddlstandard.SelectedValue + " -" + ddlsection.SelectedValue + "'";
                    }
                    strsql += " and a.strexampaper=g.strexampapername and ";
                    strsql += " b.strexamtype = g.strexamtype and b.stryear='" + ddlacademicyear.SelectedValue + "' group by b.intid, b.strexamtype,b.intstudent,b.strstandard,";
                    strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,g.strclass )";
                    strsql += " as a,tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " and a.Average between " + txtavgfrom.Text + " and " + txtavgto.Text + " group by Average";
                    strsql += " order by Average desc)";
                }
                else
                {
                    strsql += "  and intscoredmarks in(select top " + ddltopten.SelectedValue + " a.* from  (select sum(a.intscoredmarks) as intscoredmarks from tblstudentscoredmarks a,";
                    strsql += " tblreportcard b ,tblstudent c,tblemployee e, tblhomeclass f,";
                    strsql += " tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and b.strexamtype ='" + ddlexamtype.SelectedValue + "' ";
                    strsql += " and a.intreportcard =b.intid and c.intid=b.intstudent and f.strhomeclass=b.strstandard and f.intemployee=e.intid ";
                    strsql += " and b.strstandard = g.strclass and g.strsubject='" + ddlsubject.SelectedValue + "'";
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
                    {
                        strsql += "  and b.strstandard Like '" + ddlstandard.SelectedValue + " -%'";
                    }
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
                    {
                        strsql += "  and b.strstandard ='" + ddlstandard.SelectedValue + " -" + ddlsection.SelectedValue + "'";
                    }
                    strsql += " and a.strexampaper=g.strexampapername and ";
                    strsql += " b.strexamtype = g.strexamtype and b.stryear='" + ddlacademicyear.SelectedValue + "' group by b.intid, b.strexamtype,b.intstudent,b.strstandard,";
                    strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,g.strclass )";
                    strsql += " as a,tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " group by intscoredmarks";
                    strsql += " order by intscoredmarks desc)";
                }
                strsql += " order by intscoredmarks desc";
            }
            else
            {
                strsql = "select (select top 1 strbranch from tbldetails where intschool=" + Session["SchoolID"] + ") as SchoolBranch,(select strfirstname+' '+strmiddlename+' '+strlastname as ";
                strsql += " logedin from tblemployee where intid=" + Session["UserID"] + ") as ReportGeneratedby , a1.*,strgrade as Grade from ";
                strsql += " (select b.intid,b.intstudent, c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as strstudentname,g.strclass, ";
                strsql += " e.strfirstname+' '+e.strmiddlename+' '+e.strlastname as strhometeacher,b.strstandard,b.strexamtype,sum(a.intscoredmarks) ";
                strsql += " as intscoredmarks, sum(g.intmaxmark) as totalmarks, sum(a.intscoredmarks) *100 /sum(g.intmaxmark) as Average from ";
                strsql += " tblstudentscoredmarks a,tblreportcard b ,tblstudent c,tblemployee e, tblhomeclass f,tblschoolexamsettings g where ";
                strsql += " b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + "  and g.intschool=" + Session["SchoolID"] + " and b.strexamtype ='" + ddlexamtype.SelectedValue + "' and a.intreportcard =b.intid and ";
                strsql += " c.intid=b.intstudent and f.strhomeclass=b.strstandard and f.intemployee=e.intid and b.strstandard = g.strclass  ";
                if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
                {
                    strsql += "  and b.strstandard Like '" + ddlstandard.SelectedValue + " -%'";
                }
                if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
                {
                    strsql += "  and b.strstandard ='" + ddlstandard.SelectedValue + " -" + ddlsection.SelectedValue + "'";
                }
                strsql += " and a.strexampaper=g.strexampapername and b.strexamtype = g.strexamtype and ";
                strsql += " b.stryear='"+ddlacademicyear.SelectedValue+"' group by b.intid, b.strexamtype,b.intstudent,b.strstandard,";
                strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,g.strclass )";
                strsql += " as a1,tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " and  a1.Average>=intfrommarks and a1.Average<=inttomarks";
                if (txtavgfrom.Text != "" && txtavgto.Text != "")
                {
                    strsql += "  and Average in(select top " + ddltopten.SelectedValue + " a.* from  (select sum(a.intscoredmarks) *100 /sum(g.intmaxmark) as Average from tblstudentscoredmarks a,";
                    strsql += " tblreportcard b ,tblstudent c,tblemployee e, tblhomeclass f,";
                    strsql += " tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and b.strexamtype ='" + ddlexamtype.SelectedValue + "' ";
                    strsql += " and a.intreportcard =b.intid and c.intid=b.intstudent and f.strhomeclass=b.strstandard and f.intemployee=e.intid ";
                    strsql += " and b.strstandard = g.strclass ";
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
                    {
                        strsql += "  and b.strstandard Like '" + ddlstandard.SelectedValue + " -%'";
                    }
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
                    {
                        strsql += "  and b.strstandard ='" + ddlstandard.SelectedValue + " -" + ddlsection.SelectedValue + "'";
                    }
                    strsql += " and a.strexampaper=g.strexampapername and ";
                    strsql += " b.strexamtype = g.strexamtype and b.stryear='" + ddlacademicyear.SelectedValue + "' group by b.intid, b.strexamtype,b.intstudent,b.strstandard,";
                    strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,g.strclass )";
                    strsql += " as a,tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " and a.Average between " + txtavgfrom.Text + " and " + txtavgto.Text + " group by Average";
                    strsql += " order by Average desc)";
                }
                else
                {
                    strsql += "  and intscoredmarks in(select top " + ddltopten.SelectedValue + " a.* from  (select sum(a.intscoredmarks) as intscoredmarks from tblstudentscoredmarks a,";
                    strsql += " tblreportcard b ,tblstudent c,tblemployee e, tblhomeclass f,";
                    strsql += " tblschoolexamsettings g where b.intschool=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and g.intschool=" + Session["SchoolID"] + " and b.strexamtype ='" + ddlexamtype.SelectedValue + "' ";
                    strsql += " and a.intreportcard =b.intid and c.intid=b.intstudent and f.strhomeclass=b.strstandard and f.intemployee=e.intid ";
                    strsql += " and b.strstandard = g.strclass ";
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
                    {
                        strsql += "  and b.strstandard Like '" + ddlstandard.SelectedValue + " -%'";
                    }
                    if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
                    {
                        strsql += "  and b.strstandard ='" + ddlstandard.SelectedValue + " -" + ddlsection.SelectedValue + "'";
                    }
                    strsql += " and a.strexampaper=g.strexampapername and ";
                    strsql += " b.strexamtype = g.strexamtype and b.stryear='" + ddlacademicyear.SelectedValue + "' group by b.intid, b.strexamtype,b.intstudent,b.strstandard,";
                    strsql += " c.strfirstname+' '+c.strmiddlename+' '+c.strlastname, e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,g.strclass )";
                    strsql += " as a,tblschoolgrading b where b.intschool=" + Session["SchoolID"] + " group by intscoredmarks";
                    strsql += " order by intscoredmarks desc)";
                }
                strsql += " order by intscoredmarks desc";
            }
            da = new SqlDataAdapter(strsql, conn);
            ds = new DataSet1();
            da.Fill(ds, "tbleroportcard");
            if (ds.tbleroportcard.Rows.Count > 0)
            {
                if (ddlsubject.SelectedIndex > 0 && ddlstandard.SelectedIndex > 0)
                {
                    reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Subject_performance.rpt");
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_ExamReportcard/CR_EReport_Performance.rpt");
                }
            }
            else
            {
                reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
            }
            CrystalReportViewer1.Visible = true;
            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(reportfilepath);
            repDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = repDoc;
            //CrystalReportViewer1.DisplayGroupTree = false;
            CrystalReportViewer1.DataBind();
        }
        catch { }
    }
    protected void fillacademicyear()
    {
        strsql = "select intYear from tblAcademicYear where intschool='" + Session["SchoolID"] + "' and intID <=(select intID from tblacademicyear where intactive = 1 and intschool =" + Session["SchoolID"] + ") order by intyear desc";
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
        if (ds1.Tables[0].Rows.Count > 0)
        {
            ddlstandard.Items.Clear();
            string classname = "";
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string[] strclass = ds1.Tables[0].Rows[i]["strstandard"].ToString().Split(" - ".ToCharArray());
                if(classname==strclass[0])
                {
                    continue;
                }
                else
                {
                ddlstandard.Items.Insert(i, strclass[0]);
                classname = strclass[0];
                }
            }
            ddlstandard.Items.Insert(0, "-Select-");
        }        
    }
    protected void fillsubject()
    {
        try
        {
            strsql = "select strsubject from tblschoolexamsettings where intschool = " + Session["SchoolID"] + " and strexamtype = '" + ddlexamtype.SelectedValue + "' ";
            if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex == 0)
            {
                strsql += " and strclass Like '" + ddlstandard.SelectedValue + " -%'";
            }
            if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
            {
                strsql += " and strclass = '" + ddlstandard.SelectedValue + "' - '" + ddlsection.SelectedValue + "' ";
            }
            strsql += " group by strsubject";
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            ddlsubject.Items.Clear();
            ddlsubject.DataSource = ds1;
            ddlsubject.DataTextField = "strsubject";
            ddlsubject.DataValueField = "strsubject";
            ddlsubject.DataBind();
            ddlsubject.Items.Insert(0, "-Select-");

        }
        catch { }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            strsql = "select strstandard from tblreportcard where intschool = " + Session["SchoolID"] + " group by strstandard";
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddlsection.Items.Clear();
                string section = "";
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string[] strclass = ds1.Tables[0].Rows[i]["strstandard"].ToString().Split("-".ToCharArray());
                    if (section == strclass[1])
                    {
                        continue;
                    }
                    else
                    {
                        ddlsection.Items.Insert(i, strclass[1]);
                        section = strclass[1];
                    }
                }
                ddlsection.Items.Insert(0, "-All-");
            }
            fillsubject();
            fillreport();
        }
        catch { }
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillreport();
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillreport();
    }
    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
        ddlsection.Items.Clear();
        ddlsection.Items.Insert(0, "-All-");
        ddlsubject.Items.Clear();
        ddlsubject.Items.Insert(0, "-Select-");
        txtavgfrom.Text = "";
        txtavgto.Text = "";
        fillreport();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        fillstandard();
        ddlsection.Items.Clear();
        ddlsection.Items.Insert(0, "-All-");
        ddlsubject.Items.Clear();
        ddlsubject.Items.Insert(0, "-Select-");
        txtavgfrom.Text = "";
        txtavgto.Text = "";
        CrystalReportViewer1.Visible = false;
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("EReportcard_Individual.aspx");
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("EReportcard.aspx");
    }
}
