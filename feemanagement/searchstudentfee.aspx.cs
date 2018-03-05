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

public partial class feemanagement_searchstudentfee : System.Web.UI.Page
{
    public DataSet ds;
    public ListItem list;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserRights();
            Clear();
        }
    }
    protected void UserRights()
    {
        if (Session["PatronType"] != null && Session["PatronType"].ToString() == "Students" || Session["PatronType"].ToString() == "Parents")
            HidAdm.Value = Csfee.fncGET_ADMISSION_NO_FOR_GIVEN_USERID_FOR_USER_RIGHTS();
    }
    protected void fillyear()
    {
        ds = new DataSet();
        if (HidAdm.Value == string.Empty)
            ds = Csfee.fncGetAllYear();
        else
            ds = Csfee.fncGetAllYearForSelectedStudent(HidAdm.Value);
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "Year";
        ddlyear.DataValueField = "Year";
        ddlyear.DataBind();
        ddlyear.SelectedValue = ds.Tables[0].Rows[0]["CYear"].ToString();
        HidCyear.Value = ds.Tables[0].Rows[0]["CYear"].ToString();
    }
    private void fillstandard()
    {
        ds = new DataSet();
        if (HidAdm.Value == string.Empty)
            ds = Csfee.fncGet_Fee_Assignd_Class(Int32.Parse(ddlyear.SelectedValue));
        else
            ds = Csfee.GetAll_ClassFor_SelecledStudent(Int32.Parse(ddlyear.SelectedValue),HidAdm.Value);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        if (HidAdm.Value == string.Empty)
        {
            list = new ListItem("-ALL-", "0");
            ddlstandard.Items.Insert(0, list);
        }
    }
    private void Clear()
    {
        fillyear();
        fillfeemode();
        fillstandard();
        dgstudentfee.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void fillfeemode()
    {
        ds = new DataSet();
        ds = Csfee.Class_FeeMode_Year_Class(Int32.Parse(ddlyear.SelectedValue), ddlstandard.SelectedValue);
        ddlfeemode.DataSource = ds;
        ddlfeemode.DataTextField = "FeemodeName";
        ddlfeemode.DataValueField = "FeemodeID";
        ddlfeemode.DataBind();
        list = new ListItem("-ALL-", "0");
        ddlfeemode.Items.Insert(0, list);
    }
    private void fillgrid()
    {
        ds = new DataSet();
        ds = Csfee.GetAll_ViewFeeDetails_SelecledStudent(Int32.Parse(ddlyear.SelectedValue), ddlstandard.SelectedValue, Int32.Parse(ddlfeemode.SelectedValue), HidAdm.Value);
        dgstudentfee.DataSource = ds;
        dgstudentfee.DataBind();
        if(ds.Tables[0].Rows.Count == 0 )
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No record found for selected Creteria')", true);
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
        fillfeemode();
        dgstudentfee.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void ddlfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgstudentfee.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillfeemode();
        dgstudentfee.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void dgstudentfee_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgstudentfee.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
}
