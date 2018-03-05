/*-------------------------------------------------------------------------------------------------------------
DATE			DEVELOPER					MOFIFIER			PURPOSE
=====			==========					=========			=======
05-05-2013		PrabaaKaran										Assign fee	
-------------------------------------------------------------------------------------------------------------*/
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

public partial class Fee_assignfee : System.Web.UI.Page
{
    public DataSet ds;
    Csfeemenagement Clsfee = new Csfeemenagement();
    int SchollID = 0;
    string Mode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillYear();
            fillfeemode();
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetAssignFeeDetails(Convert.ToInt32(ddlYear.SelectedValue));
        dgsetfee.DataSource = ds;
        try
        {
            dgsetfee.DataBind();
        }
        catch
        {
            if(dgsetfee.CurrentPageIndex != 1)
                dgsetfee.CurrentPageIndex = dgsetfee.CurrentPageIndex - 1;
            else
                dgsetfee.CurrentPageIndex = 0;
            dgsetfee.DataBind();
        }
    }
    protected void fillYear()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetAcademicYear();
        ddlYear.DataSource = ds;
        ddlYear.DataTextField = "AcademicYear";
        ddlYear.DataValueField = "AcademicYear";
        ddlYear.DataBind();
    }
    protected void fillfeemode()
    {
        ds = new DataSet();
        ds = Clsfee.fncGet_Feemode_AcademicYear(Int32.Parse(ddlYear.SelectedValue));
        ddlfeemode.DataSource = ds;
        ddlfeemode.DataValueField = "FeemodeID";
        ddlfeemode.DataTextField = "FeemodeName";
        ddlfeemode.DataBind();
        ListItem list = new ListItem("Select", "0");
        ddlfeemode.Items.Insert(0,list);
    }
    protected void ddlfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillClass();
        fillgrid();
    }
    protected void fillClass()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetClassForAssignFee(Convert.ToInt32(ddlfeemode.SelectedValue),Int32.Parse(ddlYear.SelectedValue));
        ddlstandard.DataSource = ds;
        ddlstandard.DataValueField = "Class";
        ddlstandard.DataTextField = "Class";
        ddlstandard.DataBind();
        txtstd.Text =string.Empty;
        if(ds.Tables[0].Rows.Count == 0 )
            Page.ClientScript.RegisterStartupScript(this.GetType(),"Alert","Message(); ",true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string SelectedClass = string.Empty;
        if (txtstd.Text == "Select All")
            SelectedClass = lblSelectAll.Value;
        else
            SelectedClass = txtstd.Text;
        if (btnSave.Text == "Save")
            Mode = "ADD";
        else
            Mode = "UPDATE";
        Clsfee.fncInsertAssignedFeeDetails(Convert.ToInt32(ddlYear.SelectedValue), SelectedClass, Convert.ToInt32(ddlfeemode.SelectedValue), Convert.ToInt32(Session["UserID"]), double.Parse(txtAmount.Text), Convert.ToInt32(lblEditID.Text), Mode);
        string Syear = ddlYear.SelectedValue;
        Clear();
        ddlYear.SelectedValue = Syear;
        fillfeemode();
        fillgrid();
    }
    protected void dgsetfee_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgsetfee.CurrentPageIndex =0;
        dgsetfee.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void dgsetfee_EditCommand(object source, DataGridCommandEventArgs e)
    {
        lblEditID.Text = e.Item.Cells[0].Text;
        ds = new DataSet();
        ds = Clsfee.fncEditAssignFee(Convert.ToInt32(lblEditID.Text.ToString()));
        if (ds.Tables[0].Rows[0]["STATUS"].ToString() == "True")
        {
            string Syear = ddlYear.SelectedValue;
            ddlYear.Items.Clear();
            ListItem list2 = new ListItem(Syear, Syear);
            ddlYear.Items.Insert(0, list2);
            ddlfeemode.Items.Clear();
            ListItem list1 = new ListItem(e.Item.Cells[2].Text, e.Item.Cells[1].Text);
            ddlfeemode.Items.Insert(0, list1);
            ddlfeemode.SelectedValue = e.Item.Cells[1].Text;
            ddlstandard.Items.Clear();
            ListItem list = new ListItem(e.Item.Cells[3].Text, e.Item.Cells[3].Text);
            ddlstandard.Items.Insert(0, list);
            ddlstandard.SelectedValue = e.Item.Cells[3].Text;
            txtstd.Text = e.Item.Cells[3].Text; ;
            txtAmount.Text = e.Item.Cells[4].Text;
            btnSave.Text = "Update";
            fillgrid();
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already fee collected under the fee mode" + e.Item.Cells[2].Text + "');", true);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton image = sender as ImageButton;
        TableCell cell = image.Parent as TableCell;
        DataGridItem Item = cell.Parent as DataGridItem;
        int index = Item.ItemIndex;
        lblEditID.Text =Item.Cells[0].Text.ToString();
        ds = new DataSet();
        ds = Clsfee.fncDeleteAssignFee(Convert.ToInt32(lblEditID.Text.ToString()));
        if(ds.Tables[0].Rows[0]["STATUS"].ToString() == "True")
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected row deleted');", true);
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already fee collected under the fee mode" + Item.Cells[2].Text + "');", true);
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("assignfee.aspx", false);
    }
    protected void Clear()
    {
        fillYear();
        txtstd.Text = string.Empty;
        ddlstandard.Items.Clear();
        txtAmount.Text = string.Empty;
        btnSave.Text = "Save";
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillfeemode();
        fillgrid();
    }
}
