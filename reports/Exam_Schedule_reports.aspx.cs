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

public partial class reports_Exam_Schedule_reports : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds;
    public SqlDataAdapter da;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillexamtypes();
            fillsubject();
        }
        else
        {
            fillreport();
        }
    }
   
    protected void fillreport()
    {
        string repFilePath = "";
        SqlDataAdapter da = new SqlDataAdapter();
        strsql = "select a.strclass,a.strexamtype,a.strsubjectname,a.strexampaper, convert(varchar(10),a.dtexamdate,103) as dtexamdate,a.strexamstarttime,a.strexamendtime,b.strfirstname+' '+strmiddlename+''+strlastname as  strinvegilator,c.strbranch as SchoolBranch,e.intmaxmark,e.intpassmark from tblexamschedule a,tblemployee b,tblschooldetails c,tblschoolexamsettings e where a.intschool=" + Session["SchoolID"] + " and b.intid=a.strinvegilator and c.intschoolid = " + Session["SchoolID"] + " and a.strclass=e.strclass and a.strsubjectname = e.strsubject and a.strexamtype=e.strexamtype and a.strexampaper = e.strexampapername and e.intschoolid=" + Session["SchoolID"];
        if(txtclass.Text != "")
        {
            strsql = strsql + " and a.strclass in('" + txtclass.Text.Replace(", ", "','") + "')";
        }
        if (ddlexamtype.SelectedIndex > 1)
        {
            strsql += " and a.strexamtype= '" + ddlexamtype.SelectedValue + "'";
        }
        if (ddlsubject.SelectedIndex > 1)
        {
            strsql += " and a.strsubjectname='" + ddlsubject.SelectedValue + "'";
        }
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            strsql += " and a.dtexamdate between convert(datetime,'" + txtfromdate.Text.Trim() + "',103) and convert(datetime,'" + txttodate.Text.Trim() + "',103)";
        }
        DataSet1 ds = new DataSet1();
        da = new SqlDataAdapter(strsql, conn);
        da.Fill(ds, "tblexamschedule");
        DataAccess logrda = new DataAccess();
        DataSet logrds = new DataSet();
        string rsqlquery = "";
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
            for (int i = 0; i < ds.Tables["tblexamschedule"].Rows.Count; i++)
            {
                string reportsortby = "";
                ds.tblexamschedule.Rows[i]["ReportGeneratedby"] = logrds.Tables[0].Rows[0]["logedinname"];
                if (txtclass.Text != "")
                {
                    reportsortby = txtclass.Text;
                }
                if (ddlexamtype.SelectedIndex > 0)
                {
                    reportsortby += " And "+ ddlexamtype.SelectedValue; 
                }
                if (ddlsubject.SelectedIndex > 0)
                {
                    reportsortby += " And " + ddlsubject.SelectedValue;
                }
                if (txtfromdate.Text != "" && txttodate.Text != "")
                {
                    reportsortby += "From :" + txtfromdate.Text + " To :" + txttodate.Text;
                }
                ds.tblexamschedule.Rows[i]["Reportsortby"] = reportsortby;
            }
        }
        if (ds.Tables["tblexamschedule"].Rows.Count != 0)
        {
            repFilePath = Server.MapPath("CR_Examschedule/CR_Exam_report.rpt");
        }
        else
        {
            repFilePath = Server.MapPath("CR_Nodatafound.rpt");
        }
        ReportDocument repDoc = new ReportDocument();
        repDoc.Load(repFilePath);
        repDoc.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = repDoc;
        CrystalReportViewer1.DataBind();
    }
    protected void fillstandard()
    {
        string str = "select strclass from tblexamschedule where intschool='" + Session["SchoolID"].ToString() + "' group by strclass";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataBind();

    }
    protected void fillexamtypes()
    {
        strsql = "select strexamtype from tblexamschedule where intschool=" + Session["SchoolID"] + " group by strexamtype";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0,"-Select-");
        ddlexamtype.Items.Insert(1, "All");
    }
    protected void fillsubject()
    {
        strsql = "select strsubjectname from tblexamschedule where intschool=" + Session["SchoolID"];
        if (ddlexamtype.SelectedIndex > 1)
        {
            strsql += " and strexamtype='"+ddlexamtype.SelectedValue + "'";
        }
        strsql += " group by strsubjectname";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubjectname";
        ddlsubject.DataValueField = "strsubjectname";
        ddlsubject.Items.Clear();
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "-Select-");
        ddlsubject.Items.Insert(1, "-All-");
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        string name = "";
        for (int i = 0; i < ddlstandard.Items.Count; i++)
        {
            if (ddlstandard.Items[i].Selected)
            {
                name += ddlstandard.Items[i].Text + ", ";
            }
        }
        txtclass.Text = name;        
        fillreport();
    }
    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        fillreport();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillreport();
    }
    protected void bttnsearch_click(object sender, EventArgs e)
    {
        fillreport();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtclass.Text = "";
        ddlexamtype.SelectedIndex = 0;
        ddlsubject.SelectedIndex = 0;
        txtfromdate.Text = "";
        txttodate.Text = "";
        fillreport();
    }
}
