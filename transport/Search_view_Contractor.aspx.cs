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

public partial class transport_Search_view_Contractor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcontractor();
        }
    }
    protected void fillcontractor()
    {
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intID,strownername from tblowner where intschool =" + Session["SchoolID"];
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcontractor.DataSource = ds;
            ddlcontractor.DataTextField = "strownername";
            ddlcontractor.DataValueField = "intID";
            ddlcontractor.DataBind();            
            ddlcontractor.Items.Insert(0, "-Select-");
            ddlcontractor.Items.Insert(1, "-All Contractor-");
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select intID, strownername, straddress +','+strarea+','+strcity+','+strstate as address,strcountry,strphoneno+','+strmobile as contact from tblowner where intschool=" + Session["SchoolID"].ToString();
        if (ddlcontractor.SelectedIndex == 0)
        {
            sql += " and intID =''";
        }
        if(ddlcontractor.SelectedIndex == 1)
        {
            sql += " and intID != ''";
        }
        if (ddlcontractor.SelectedIndex > 1)
        {
            sql += " and intID ="+ddlcontractor.SelectedValue;
        }
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgowner.DataSource = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgowner.Visible = true;
            dgowner.DataBind();
        }
        else
        {
            dgowner.Visible = false;
        }
    }
    protected void ddlcontractor_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        viewdriverdetails.Visible = false;
    }
    protected void dgowner_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string strsql = "select * from tblowner where intID=" + e.Item.Cells[0].Text;
        ds = da.ExceuteSql(strsql);
        txtcontractorname.Text = ds.Tables[0].Rows[0]["strownername"].ToString();
        txtaddress.Text = ds.Tables[0].Rows[0]["straddress"].ToString() + "<br />";
        txtaddress.Text += ds.Tables[0].Rows[0]["strarea"].ToString() + "<br />";
        txtaddress.Text += ds.Tables[0].Rows[0]["strcity"].ToString() + "<br />";
        txtaddress.Text += ds.Tables[0].Rows[0]["strstate"].ToString() + "<br />";
        txtaddress.Text += ds.Tables[0].Rows[0]["strcountry"].ToString();
        txtcontactdetails.Text = "Mobile : " + ds.Tables[0].Rows[0]["strmobile"].ToString();
        if (ds.Tables[0].Rows[0]["strphoneno"].ToString() != "")
        {
            txtcontactdetails.Text += "<br > Phone : " + ds.Tables[0].Rows[0]["strphoneno"].ToString();
        }
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        string strsql1 = "select * from tblvehiclemaster where intownerid= "+e.Item.Cells[0].Text;
        ds1 = da.ExceuteSql(strsql1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            dgvehicledetails.Visible = true;
            txtnoofvehicle.Text = ds1.Tables[0].Rows.Count.ToString();
            dgvehicledetails.DataSource = ds1;
            dgvehicledetails.DataBind();
        }
        else
        {
            dgvehicledetails.Visible = false;
            txtnoofvehicle.Text = "Vehicle Not contracted with school";
        }
        
        viewdriverdetails.Visible = true;
        trgrid.Visible = false;
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        viewdriverdetails.Visible = false;
        trgrid.Visible = true;
    }
}
