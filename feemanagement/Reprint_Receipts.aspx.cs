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

public partial class feemanagement_Reprint_Receipts : System.Web.UI.Page
{
    Csfeemenagement csfee = new Csfeemenagement();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillYear();
            fillClass();
            fillStudent();
            fillAdmission();
            fillgrid();
        }
    }
    protected void fillYear()
    {
        ds = new DataSet();
        ds = csfee.fncGetAllYear();
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "Year";
        ddlyear.DataValueField = "Year";
        ddlyear.DataBind();
        HidCyear.Value = ds.Tables[0].Rows[0]["CYear"].ToString();
        ddlyear.SelectedValue = HidCyear.Value;
    }
    protected void fillClass()
    {
        ds = new DataSet();
        ds = csfee.fncGetAllClass();
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "Class";
        ddlclass.DataValueField = "Class";
        ddlclass.DataBind();
        ListItem List = new ListItem("All", "All");
        ddlclass.Items.Insert(0, List);
    }
    protected void fillStudent()
    {
        ds = new DataSet();
        ds = csfee.fncGetStudentForClass(ddlclass.SelectedValue.Trim(), ddlAdmission.SelectedValue.Trim(), "S");
        ddlName.DataSource = ds;
        ddlName.DataTextField = "Name";
        ddlName.DataValueField = "AdmissionNo";
        ddlName.DataBind();
        ListItem List = new ListItem("All", "All");
        ddlName.Items.Insert(0, List);
    }
    protected void fillAdmission()
    {
        ds = new DataSet();
        ds = csfee.fncGetStudentForClass(ddlclass.SelectedValue.Trim(), ddlName.SelectedValue.Trim(), "A");
        ddlAdmission.DataSource = ds;
        ddlAdmission.DataTextField = "AdmissionNo";
        ddlAdmission.DataValueField = "AdmissionNo";
        ddlAdmission.DataBind();
        ListItem List = new ListItem("All", "All");
        ddlAdmission.Items.Insert(0, List);
    }
    protected void fillgrid()
    {
        ds = new DataSet();
        ds = csfee.fncGetReceiptReprint(Int32.Parse(ddlyear.SelectedValue), ddlclass.SelectedValue.Trim(), ddlAdmission.SelectedValue.Trim());
        dgReceipts.DataSource = ds;
        dgReceipts.DataBind();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        fillAdmission();
        fillgrid();
    }
    protected void ddlAdmission_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlName.SelectedValue = ddlAdmission.SelectedValue;
        fillgrid();
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAdmission.SelectedValue = ddlName.SelectedValue;
        fillgrid();
    }
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Button Print = (Button)sender;
        TableCell cell = Print.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string rn = item.Cells[2].Text;
        string rd = item.Cells[6].Text;
        string adn = item.Cells[4].Text;
        string sn = item.Cells[3].Text;
        string rf = item.Cells[9].Text;
        string dc = item.Cells[7].Text;
        string amt = item.Cells[5].Text;
        string pm = item.Cells[11].Text;
        string cn = item.Cells[8].Text;
        string cr = item.Cells[10].Text;
        string url = "Print_Receipt.aspx?rn=" + rn + "&rd=" + rd + "&adn=" + adn + "&cr=" + cr + "&sn=" + sn + "&rf=" + rf + "&dc=" + dc + "&amt=" + amt + "&pm=" + pm + "&cn=" + cn + "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "<script type='text/javascript'> window.open('" + url + "','mynewwin','width=100,height=100,toolbar=1,scrollbars=no')</script>", false);

    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlyear.SelectedValue = HidCyear.Value;
        ddlclass.SelectedIndex = 0;
        ddlName.SelectedIndex = 0;
        ddlAdmission.SelectedIndex = 0;
        dgReceipts.DataSource = null;
        dgReceipts.DataBind();
        fillgrid();
    }
    protected void dgReceipts_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgReceipts.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
}
