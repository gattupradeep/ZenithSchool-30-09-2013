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
using System.IO;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Reflection;

public partial class reports_DailyFeeCollectionReport : System.Web.UI.Page
{
    Csfeemenagement ClsFee = new Csfeemenagement();
    public DataSet ds;
    public string reportfilepath;
    public string[] str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtfromdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txttodate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            fillReports();
        }
        fillReports();
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        fillReports();
    }
    protected void fillReports()
    {
        if (txtfromdate.Text == string.Empty)
            txtfromdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        if (txttodate.Text == String.Empty)
            txttodate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        string Fdate = txtfromdate.Text.Substring(6, 4) + "/" + txtfromdate.Text.Substring(3, 2) + "/" + txtfromdate.Text.Substring(0, 2);
        String Tdate = txttodate.Text.Trim().Substring(6, 4) + "/" + txttodate.Text.Trim().Substring(3, 2) + "/" + txttodate.Text.Trim().Substring(0, 2);
        DataSet1 ds = new DataSet1();
        ds = ClsFee.fncGetDailyFeeCollectioReport(Fdate, Tdate);
        reportfilepath = Server.MapPath("CR_DailyFeeCollectionReport.rpt");
        CrystalReportViewer1.EnableDatabaseLogonPrompt = false;
        ReportDocument FeeDetails = new ReportDocument();
        FeeDetails.Load(reportfilepath);
        FeeDetails.SetDataSource(ds.Tables["DailyFeeCollection"]);
        CrystalReportViewer1.ReportSource = FeeDetails;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        fillReports();
    }
}
