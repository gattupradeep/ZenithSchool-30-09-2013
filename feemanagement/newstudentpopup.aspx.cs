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
using System.Xml.Linq;

public partial class feemanagement_newstudentpopup : System.Web.UI.Page
{
    public DataSet ds;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        string Dis = string.Empty;
        if(HidDisDetails.Value != string.Empty)
            Dis = Csfee.fncGetFeeIDWithDiscount(HidDisDetails.Value);
        ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'studentfee.aspx?date=" + Request["date"] + "&AdmissionNo=" + txtadmno.Text.Trim() + "&Class=" + ddlClass.SelectedValue.Trim() + "&sFName=" + txtFName.Text.Trim() + "&sMName=" + txtMName.Text.Trim() + "&sLName=" + txtLName.Text.Trim() + "&IntakeYear=" + ddlyear.SelectedValue.Trim() + "&IntakeMonth=" + ddlMonth.SelectedItem + "&IC_Passport=" + txtICPASS.Text.Trim() + "&Dis=" + Dis + "'; </script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'studentfee.aspx?date=" + Request["date"] + "'; </script>");
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = Csfee.fncGet_Generate_AdmnNum(ddlyear.SelectedValue.Trim(),ddlMonth.SelectedValue.Trim());
        txtadmno.Text = ds.Tables[0].Rows[0]["AdmnNum"].ToString();
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFeemode();
    }
    protected void fillFeemode()
    {
        ds = new DataSet();
        ds = Csfee.Class_FeeMode_Year_Class(Int32.Parse(ddlyear.SelectedValue), ddlClass.SelectedValue);
        ddlSingle.DataSource = ds;
        ddlSingle.DataTextField = "FeemodeName";
        ddlSingle.DataValueField = "FeemodeID";
        ddlSingle.DataBind();
    }
}
