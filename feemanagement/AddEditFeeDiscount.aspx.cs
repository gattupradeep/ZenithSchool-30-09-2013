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

public partial class feemanagement_AddEditFeeDiscount : System.Web.UI.Page
{
    public DataSet ds;
    public ListItem list;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillyear();
            Clear();
        }
    }
    protected void fillyear()
    {
        ds = new DataSet();
        ds = Csfee.fncGetAllYear();
        drpyear.DataSource = ds;
        drpyear.DataTextField = "Year";
        drpyear.DataValueField = "Year";
        drpyear.DataBind();
        drpyear.SelectedValue = ds.Tables[0].Rows[0]["CYear"].ToString();
        Cyear.Value = ds.Tables[0].Rows[0]["CYear"].ToString();

    }
    private void fillstandard()
    {
        ds = new DataSet();
        ds = Csfee.fncGet_Fee_Assignd_Class(Int32.Parse(drpyear.SelectedValue));
        drpclass.DataSource = ds;
        drpclass.DataTextField = "strstandard";
        drpclass.DataValueField = "strstandard";
        drpclass.DataBind();
        list = new ListItem("-ALL-", "0");
        drpclass.Items.Insert(0, list);
    }
    private void Clear()
    {
        drpyear.SelectedValue = Cyear.Value;
        fillstandard();
        fillfeemode();
        fillStudent();
        fillAdmission();
        ResetGrid();
    }
    protected void ResetGrid()
    {
        dgFeeDiscount.DataSource = null;
        dgFeeDiscount.DataBind();
        trSave.Visible = false;
    }
    protected void fillfeemode()
    {
        ds = new DataSet();
        ds = Csfee.Class_FeeMode_Year_Class(Int32.Parse(drpyear.SelectedValue), drpclass.SelectedValue);
        drpfeemode.DataSource = ds;
        drpfeemode.DataTextField = "FeemodeName";
        drpfeemode.DataValueField = "FeemodeID";
        drpfeemode.DataBind();
        list = new ListItem("-ALL-", "0");
        drpfeemode.Items.Insert(0, list);
    }
    protected void fillStudent()
    {
        ddlStudent.Items.Clear();
        ds = new DataSet();
        ds = Csfee.fncGetStudentForClassYear(Int32.Parse(drpyear.SelectedValue), drpclass.SelectedValue.Trim(), string.Empty, "S");
        ddlStudent.DataSource = ds;
        ddlStudent.DataTextField = "Name";
        ddlStudent.DataValueField = "AdmissionNo";
        ddlStudent.DataBind();
        list = new ListItem("All", "All");
        ddlStudent.Items.Insert(0, list);
    }
    protected void fillAdmission()
    {
        ddlAdmission.Items.Clear();
        ds = new DataSet();
        ds = Csfee.fncGetStudentForClassYear(Int32.Parse(drpyear.SelectedValue), drpclass.SelectedValue.Trim(), string.Empty, "A");
        ddlAdmission.DataSource = ds;
        ddlAdmission.DataTextField = "AdmissionNo";
        ddlAdmission.DataValueField = "AdmissionNo";
        ddlAdmission.DataBind();
        list = new ListItem("All", "All");
        ddlAdmission.Items.Insert(0, list);
    }
    private void fillgrid()
    {
        ds = new DataSet();
        ds = Csfee.fncEditFeeDiscount(Int32.Parse(drpyear.SelectedValue),drpclass.SelectedValue, ddlStudent.SelectedValue, Int32.Parse(drpfeemode.SelectedValue));
        dgFeeDiscount.DataSource = ds;
        dgFeeDiscount.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            trSave.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No record found for selected Creteria')", true);
        }
        else
        {
            trSave.Visible = true;
            if(drpclass.SelectedIndex == 0)
                drpclass.SelectedValue = ds.Tables[0].Rows[0]["Class"].ToString();
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void drpclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        fillAdmission();
        fillfeemode();
        ResetGrid(); ;
    }
    protected void drpfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpclass.SelectedIndex = 0;
        ddlAdmission.SelectedValue = ddlStudent.SelectedValue;
        fillgrid();
    }
    protected void ddlAdmission_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpclass.SelectedIndex = 0;
        ddlStudent.SelectedValue = ddlAdmission.SelectedValue;
        fillgrid();
    }
    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
        fillStudent();
        fillAdmission();
        fillfeemode();
        ResetGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Fee_Dis = string.Empty;
        for (int i = 0; i < dgFeeDiscount.Items.Count; i++)
        {
            DataGridItem Item = dgFeeDiscount.Items[i];
            TextBox txtDiscount = (TextBox)Item.FindControl("txtDiscount");
            if (double.Parse(txtDiscount.Text) > 0 && txtDiscount.Text != string.Empty)
            {
                if (Fee_Dis == string.Empty)
                    Fee_Dis = Item.Cells[0].Text + '-' + txtDiscount.Text;
                else
                    Fee_Dis = Fee_Dis + ',' + Item.Cells[0].Text + '-' + txtDiscount.Text;
            }
        }
        if (Fee_Dis != string.Empty)
        {
            string Message = Csfee.fncAddFeeDiscount(ddlAdmission.SelectedValue, Fee_Dis, Int32.Parse(drpyear.SelectedValue));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "')", true);
        }
    }
}
