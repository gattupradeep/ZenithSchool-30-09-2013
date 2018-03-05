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

public partial class transport_Search_view_vehicle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillowner();
        }
    }
    private void fillowner()
    {
        DataAccess da = new DataAccess();
        string sql = "select intid, strownername from tblowner where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlowner.DataSource = ds;
        ddlowner.DataTextField = "strownername";
        ddlowner.DataValueField = "intid";
        ddlowner.DataBind();
        ddlowner.Items.Insert(0, "-Select-");
        ddlowner.Items.Insert(1, "-All Contractor-");
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.intid, a.strregno,a.strvehicleno,a.strengineno,a.strchassisno,a.strbrand,a.strmodel,a.strvehiclecolor,b.strownername from dbo.tblvehiclemaster a,dbo.tblowner b where a.intownerid=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlowner.SelectedIndex == 0)
        {
            sql += " and intownerid = ''";
        }
        if (ddlowner.SelectedIndex == 1)
        {
            sql += " and intownerid != ''";
        }
        if (ddlowner.SelectedIndex > 1)
        {
            sql += " and intownerid =" + ddlowner.SelectedValue;
        }
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            trnodata.Visible = false;
            trdg.Visible = true;
            dgvehicle.Visible = true;
            dgvehicle.DataSource = ds;
            dgvehicle.DataBind();
        }
        else
        {
            trdg.Visible = false;
            trnodata.Visible = true;
            dgvehicle.Visible = false;
        }
    }
    protected void dgvehicle_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "select a.intID,c.strvehiclecategory, a.strownername, b.*,convert(varchar(10),b.dtfcdate,103) as fcdate,convert(varchar(10),b.dtfcedate,103) as fcedate,convert(varchar(10),b.dtinsurancesdate,103) as insurancesdate,convert(varchar(10),b.dtinsuranceedate,103) as insuranceedate from tblvehiclemaster b,tblowner a,tblvehiclecategory c where a.intid=b.intownerid " + " and c.intid=b.inttypeid and b.intschool=" + Session["SchoolID"].ToString() + " and b.intid=" + e.Item.Cells[0].Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtvehiclecontractor.Text = ds.Tables[0].Rows[0]["strownername"].ToString();
            txtregno.Text = ds.Tables[0].Rows[0]["strregno"].ToString();
            txtvehicleno.Text = ds.Tables[0].Rows[0]["strvehicleno"].ToString();
            txtengineno.Text = ds.Tables[0].Rows[0]["strengineno"].ToString();
            txtchassisno.Text = ds.Tables[0].Rows[0]["strchassisno"].ToString();
            txtbrand.Text = ds.Tables[0].Rows[0]["strbrand"].ToString();
            txtmodel.Text = ds.Tables[0].Rows[0]["strmodel"].ToString();
            txtfuel.Text = ds.Tables[0].Rows[0]["strfueltype"].ToString();
            txtinsuranceno.Text = ds.Tables[0].Rows[0]["strinsuranceno"].ToString();
            txtluxury.Text = ds.Tables[0].Rows[0]["strluxuryinfo"].ToString();
            txtpermit.Text = ds.Tables[0].Rows[0]["strpermitinfo"].ToString();
            txtrate.Text = ds.Tables[0].Rows[0]["intratekm"].ToString();
            txtfreeservices.Text = ds.Tables[0].Rows[0]["intfreeservices"].ToString();
            txtfcno.Text = ds.Tables[0].Rows[0]["strfcno"].ToString();
            txtboardcolor.Text = ds.Tables[0].Rows[0]["strboardcolor"].ToString();
            txtseats.Text = ds.Tables[0].Rows[0]["intseats"].ToString();
            txtvehiclecolor.Text = ds.Tables[0].Rows[0]["strvehiclecolor"].ToString();
            txttypeofvehicle.Text = ds.Tables[0].Rows[0]["strvehiclecategory"].ToString();
            txtfcissuedate.Text = ds.Tables[0].Rows[0]["fcdate"].ToString();
            txtfcenddate.Text = ds.Tables[0].Rows[0]["fcedate"].ToString();
            txtinsuranceissuedate.Text = ds.Tables[0].Rows[0]["insurancesdate"].ToString();
            txtinsuranceenddate.Text = ds.Tables[0].Rows[0]["insuranceedate"].ToString();
            trvehicledetails.Visible = true;
            trdg.Visible = false;
            trback.Visible = true;
        }
    }
    protected void ddlowner_SelectedIndexChanged(object sender, EventArgs e)
    {
        trvehicledetails.Visible = false;
        fillgrid();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        trvehicledetails.Visible = false;
        trdg.Visible = true;
    }
}
