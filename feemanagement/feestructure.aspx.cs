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

public partial class feemanagement_feestructure : System.Web.UI.Page
{
    public DataSet ds;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillYear();
            fillgrid();
        }
    }
    protected void fillYear()
    {
        ds = new DataSet();
        ds = Csfee.fncGetAllYear();
        ddlYear.DataSource = ds;
        ddlYear.DataTextField = "Year";
        ddlYear.DataValueField = "Year";
        ddlYear.DataBind();
        ddlYear.SelectedValue = ds.Tables[0].Rows[0]["CYear"].ToString();
    }
    protected void fillgrid()
    {
        try
        {
            ds = new DataSet();
            ds = Csfee.fncGetAllClass();
            dlstandard.DataSource = ds;
            dlstandard.DataBind();
            ds = new DataSet();
            ds = Csfee.fncGetAllFeemode();
            grdfeemode.DataSource = ds;
            grdfeemode.DataBind();
        }
        catch { }
    }
    protected void grdfeemode_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataGrid dgfeetype = (DataGrid)e.Item.FindControl("grdparticular");
            ds = new DataSet();
            ds = Csfee.fncGetFeemodeForFeeModeID(Int32.Parse(dr["FeemodeID"].ToString()));
            dgfeetype.DataSource = ds;
            dgfeetype.DataBind();
        }
        catch { }
    }
    protected void grdparticular_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataList dgfeetype = (DataList)e.Item.FindControl("dlstandardfee");
            ds = new DataSet();
            ds = Csfee.fncGet_School_Fee_Structure(Int32.Parse(dr["FeemodeID"].ToString()), Int32.Parse(ddlYear.SelectedValue));
            dgfeetype.DataSource = ds;
            dgfeetype.DataBind();
        }
        catch { }
    }
    protected void ddlYear_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fillgrid();
    }
}
