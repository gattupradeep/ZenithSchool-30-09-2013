using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using System.Reflection;
using System.IO;

public partial class reports_StudentFeeDetails : System.Web.UI.Page
{
    Csfeemenagement ClsFee = new Csfeemenagement();
    public DataSet ds;
    ListItem list;
    public string reportfilepath;
    public string[] str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clear();
            fillReports();
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        clear();
        fillReports();
    }
    private void setDBLOGONforREPORT(ConnectionInfo myconnectioninfo)
    {
        TableLogOnInfos mytableloginfos = new TableLogOnInfos();
        mytableloginfos = CrystalReportViewer1.LogOnInfo;
        foreach (TableLogOnInfo myTableLogOnInfo in mytableloginfos)
        {
            myTableLogOnInfo.ConnectionInfo = myconnectioninfo;
        }

    }
    protected void fillyear()
    {
        ds = new DataSet();
        ds = ClsFee.fncGetAllYear();
        drpyear.DataSource = ds;
        drpyear.DataTextField = "Year";
        drpyear.DataValueField = "Year";
        drpyear.DataBind();
        drpyear.SelectedValue = ds.Tables[0].Rows[0]["CYear"].ToString();
    }
    protected void fillfeemode()
    {
        ds = new DataSet();
        ds = ClsFee.Class_FeeMode_Year_Class(Int32.Parse(drpyear.SelectedValue), drpclass.SelectedValue);
        drpfeemode.DataSource = ds;
        drpfeemode.DataTextField = "FeemodeName";
        drpfeemode.DataValueField = "FeemodeID";
        drpfeemode.DataBind();
        list = new ListItem("-ALL-", "0");
        drpfeemode.Items.Insert(0, list);
    }
    protected void fillclass()
    {
        ds = new DataSet();
        ds = ClsFee.fncGet_Fee_Assignd_Class(Int32.Parse(drpyear.SelectedValue));
        drpclass.DataSource = ds;
        drpclass.DataTextField = "strstandard";
        drpclass.DataValueField = "strstandard";
        drpclass.DataBind();
        list = new ListItem("-ALL-", "0");
        drpclass.Items.Insert(0, list);
    }
    protected void fillledger()
    {
        ds = new DataSet();
        ds = ClsFee.fncGetCashierFor_SelectedYear(Int32.Parse(drpyear.SelectedValue));
        drpledger.DataSource = ds;
        drpledger.DataTextField = "Name";
        drpledger.DataValueField = "intUserID";
        drpledger.DataBind();
    }
    protected void drpclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetforclass();
        fillReports();
    }
    protected void drpreceipt_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetforreceipt();
        fillReports();
    }
    protected void drpmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetformode();
        fillReports();
    }
    protected void drpledger_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetforledger();
        fillReports();
    }
    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillclass();
        fillfeemode();
        fillReports();
    }
    protected void drpduetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpduetype.SelectedIndex > 0 && drpduetype.SelectedIndex == 1)
            trdate.Visible = true;
        else
            trdate.Visible = false;
        fillReports();
    }
    protected void drpfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillReports();
    }
    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        fillReports();
    }
    protected void txttodate_TextChanged(object sender, EventArgs e)
    {
        fillReports();
    }
    protected void txtnameAdmno_TextChanged(object sender, EventArgs e)
    {
        if (txtnameAdmno.Text != string.Empty)
        {
            ds = new DataSet();
            ds = ClsFee.fncGetStudentNameforAdmision(txtnameAdmno.Text);
            if (ds.Tables[0].Rows[0]["ERROR"].ToString() != "VALID")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Admission number!');", true);
                txtnameAdmno.Text = "";
            }
        }
        resetforadmnno();
        fillReports();
    }
    protected void fillReports()
    {
        string Class = string.Empty;
        string Mode = string.Empty;
        string duetype = string.Empty;
        string Fromdate = string.Empty;
        string Todate = string.Empty;
        DataSet1 ds = new DataSet1();
        if (drpclass.SelectedValue == "0")
            Class = string.Empty;
        else
            Class = drpclass.SelectedValue;
        if (drpmode.SelectedValue == "0")
            Mode = string.Empty;
        else
            Mode = drpmode.SelectedValue;

        if (drpduetype.SelectedValue == "0")
            duetype = string.Empty;
        else
            duetype = drpduetype.SelectedValue;
        if (txtfromdate.Text != string.Empty)
            Fromdate = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
        else
            Fromdate = string.Empty;
        if (txttodate.Text != string.Empty)
            Todate = Convert.ToDateTime(txttodate.Text).ToString("yyyy-MM-dd");
        else
            Todate = string.Empty;
        ds = ClsFee.fncGetFeePaymentDetailsForReport(int.Parse(drpyear.SelectedValue), txtnameAdmno.Text, Class, int.Parse(drpfeemode.SelectedValue), int.Parse(drpreceipt.SelectedValue), Mode, int.Parse(drpledger.SelectedValue), duetype, Fromdate, Todate, Int32.Parse(Session["UserID"].ToString()));
        
        reportfilepath = Server.MapPath("CR_StudentFeeDetailslReport.rpt");
        CrystalReportViewer1.EnableDatabaseLogonPrompt = false;
        ReportDocument FeeDetails = new ReportDocument();

        FeeDetails.Load(reportfilepath);
        FeeDetails.SetDataSource(ds.Tables["StudentFeeDetails"]);
        CrystalReportViewer1.ReportSource = FeeDetails;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
        fillReports();
    }
    protected void clear()
    {
        fillyear();
        drpduetype.SelectedIndex = 0;
        fillfeemode();
        trdate.Visible = false;
        txtfromdate.Text = string.Empty;
        txttodate.Text = string.Empty;
        clear2();
    }
    protected void clear2()
    {
        fillledger();
        fillclass();
        txtnameAdmno.Text = string.Empty;
        drpledger.SelectedIndex = 0;
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
    }
    protected void resetforclass()
    {
        txtnameAdmno.Text = string.Empty;
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
        fillledger();
    }
    protected void resetforadmnno()
    {
        fillclass();
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
        fillledger();
    }
    protected void resetforreceipt()
    {
        fillclass();
        txtnameAdmno.Text = string.Empty;
        drpmode.SelectedIndex = 0;
        fillledger();
    }
    protected void resetformode()
    {
        fillclass();
        txtnameAdmno.Text = string.Empty;
        drpreceipt.SelectedIndex = 0;
        fillledger();
    }
    protected void resetforledger()
    {
        fillclass();
        txtnameAdmno.Text = string.Empty;
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
    }
    protected void resetforafter()
    {
        fillclass();
        txtnameAdmno.Text = string.Empty;
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
        fillledger();
    }
    protected void btnclear_Click1(object sender, EventArgs e)
    {
        clear();
        fillReports();
    }
}
