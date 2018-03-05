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

public partial class feemanagement_ViewNewAdmissionDetails : System.Web.UI.Page
{
    public DataSet ds;
    Csfeemenagement Clsfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillYear();
            fillClass();
            fillStudent();
            fillFeeMode();
            fillGrid();
        }
    }
    protected void fillYear()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetAcademicYear();
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "AcademicYear";
        ddlyear.DataValueField = "AcademicYear";
        ddlyear.DataBind();
    }
    protected void fillClass()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetClassForNewAdmission(Int32.Parse(ddlyear.SelectedValue));
        ddlClass.DataSource = ds;
        ddlClass.DataTextField = "Class";
        ddlClass.DataValueField = "Class";
        ddlClass.DataBind();
        ListItem List = new ListItem("All", "0");
        ddlClass.Items.Insert(0, List);
    }
    protected void fillStudent()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetNewAdmissionStudent(Int32.Parse(ddlyear.SelectedValue),ddlMonth.SelectedValue,ddlClass.SelectedValue);
        ddlName.DataSource = ds;
        ddlName.DataTextField = "Name";
        ddlName.DataValueField = "ID";
        ddlName.DataBind();
        ListItem List = new ListItem("All", "0");
        ddlName.Items.Insert(0, List);
    }
    protected void fillFeeMode()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetFeeModeForNewAdmission(Int32.Parse(ddlyear.SelectedValue),ddlClass.SelectedValue.Trim());
        ddlFeeMode.DataSource = ds;
        ddlFeeMode.DataTextField = "FeeModeName";
        ddlFeeMode.DataValueField = "FeeModeID";
        ddlFeeMode.DataBind();
        ListItem List = new ListItem("All", "0");
        ddlFeeMode.Items.Insert(0, List);
    }
    protected void fillGrid()
    {
        string Month = string.Empty;
        string Class = string.Empty;
        if(ddlMonth.SelectedValue != "All")
            Month = ddlMonth.SelectedValue.Trim();
        if (ddlClass.SelectedValue != "0")
            Class = ddlClass.SelectedValue.Trim();
        ds = new DataSet();
        ds = Clsfee.fncGetNewAdmissionDetails(Int32.Parse(ddlyear.SelectedValue), Month, Class,ddlName.SelectedValue, Int32.Parse(ddlFeeMode.SelectedValue),ddlStatus.SelectedValue.Trim());
        dgNewAdmn.DataSource = ds;
        dgNewAdmn.DataBind();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillClass();
        fillFeeMode();
        fillStudent();
        dgNewAdmn.CurrentPageIndex = 0;
        fillGrid();
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFeeMode();
        fillStudent();
        dgNewAdmn.CurrentPageIndex = 0;
        fillGrid();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        dgNewAdmn.CurrentPageIndex = 0;
        fillGrid();
    }
    protected void ddlFeeMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgNewAdmn.CurrentPageIndex = 0;
        fillGrid();
    }
    protected void dgNewAdmn_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgNewAdmn.CurrentPageIndex = e.NewPageIndex;
        fillGrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void Clear()
    {
        ddlyear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
        ddlClass.SelectedIndex = 0;
        ddlFeeMode.SelectedIndex = 0;
        dgNewAdmn.CurrentPageIndex = 0;
        ddlStatus.SelectedIndex = 0;
        ddlName.SelectedIndex = 0;
        fillGrid();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgNewAdmn.CurrentPageIndex = 0;
        fillGrid();
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgNewAdmn.CurrentPageIndex = 0;
        fillGrid();
    }
}
