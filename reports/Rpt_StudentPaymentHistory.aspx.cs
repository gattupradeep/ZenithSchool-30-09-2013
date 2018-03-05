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
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Reflection;

public partial class reports_Rpt_StudentPaymentHistory : System.Web.UI.Page
{
    Csfeemenagement csfee = new Csfeemenagement();
    DataSet ds;
    ListItem List;
    public string reportfilepath;
    public string[] str;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
        fillYear();
        fillClass();
        fillStudent();
        fillAdmission();
        fillReports();
    }
    protected void fillYear()
    {
        ddlyear.Items.Clear();
        ds = new DataSet();
        ds = csfee.fncGetAllYear();
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "Year";
        ddlyear.DataValueField = "Year";
        ddlyear.DataBind();
        ddlyear.SelectedValue = ds.Tables[0].Rows[0]["CYear"].ToString();
        HidCyear.Value = ds.Tables[0].Rows[0]["CYear"].ToString();
    }
    protected void fillClass()
    {
        ddlclass.Items.Clear();
        ds = new DataSet();
        ds = csfee.fncGetAllClass();
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "Class";
        ddlclass.DataValueField = "Class";
        ddlclass.DataBind();
        List = new ListItem("All", "All");
        ddlclass.Items.Insert(0, List);
    }
    protected void fillStudent()
    {
        ddlName.Items.Clear();
        ds = new DataSet();
        ds = csfee.fncGetStudentForClassYear(Int32.Parse(ddlyear.SelectedValue), ddlclass.SelectedValue.Trim(), string.Empty, "S");
        ddlName.DataSource = ds;
        ddlName.DataTextField = "Name";
        ddlName.DataValueField = "AdmissionNo";
        ddlName.DataBind();
        List = new ListItem("All", "All");
        ddlName.Items.Insert(0, List);

    }
    protected void fillAdmission()
    {
        ddlAdmission.Items.Clear();
        ds = new DataSet();
        ds = csfee.fncGetStudentForClassYear(Int32.Parse(ddlyear.SelectedValue), ddlclass.SelectedValue.Trim(), string.Empty, "A");
        ddlAdmission.DataSource = ds;
        ddlAdmission.DataTextField = "AdmissionNo";
        ddlAdmission.DataValueField = "AdmissionNo";
        ddlAdmission.DataBind();
        List = new ListItem("All", "All");
        ddlAdmission.Items.Insert(0, List);
    }
    protected void fillReports()
    {
        DataSet1 ds = new DataSet1();
        ds = csfee.fncStudentPaymentHistoryReport(Int32.Parse(ddlyear.SelectedValue), ddlAdmission.SelectedValue, ddlclass.SelectedValue);
        reportfilepath = Server.MapPath("CR_StudentPaymentHistory.rpt");
        CrystalReportViewer1.EnableDatabaseLogonPrompt = false;
        ReportDocument FeeDetails = new ReportDocument();
        FeeDetails.Load(reportfilepath);
        FeeDetails.SetDataSource(ds.Tables["StudentPaymentHistory"]);
        CrystalReportViewer1.ReportSource = FeeDetails;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        fillAdmission();
        fillReports();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        fillAdmission();
        fillReports();
    }
    protected void ddlAdmission_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlName.SelectedValue = ddlAdmission.SelectedValue;
        fillReports();
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAdmission.SelectedValue = ddlName.SelectedValue;
        fillReports();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        ddlyear.SelectedValue = HidCyear.Value;
        ddlclass.SelectedIndex = 0;
        fillStudent();
        fillAdmission();
    }
}
