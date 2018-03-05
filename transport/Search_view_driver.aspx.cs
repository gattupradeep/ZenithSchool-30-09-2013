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

public partial class transport_Search_view_driver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldriver();
        }
    }
    protected void filldriver()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string strsql = "select intid,strdrivername from tbldriver where intschool="+Session["SchoolID"];
        ds = da.ExceuteSql(strsql);
        ddldriver.DataSource = ds;
        ddldriver.DataTextField = "strdrivername";
        ddldriver.DataValueField = "intid";
        ddldriver.DataBind();
        ddldriver.Items.Insert(0,"-Select-");
        ddldriver.Items.Insert(1, "-All Driver-");
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select intid,strdrivername,straddress+','+strarea+','+strcity+','+strstate as address,strcountry ,strphoneno+','+strmobileno as contact from tbldriver where intschool=" + Session["SchoolID"].ToString();
        if (ddldriver.SelectedIndex == 0)
        {
            sql += " and intid !=''";
        }
        if (ddldriver.SelectedIndex == 1)
        {
            sql += " and intid !=''";
        }
        if (ddldriver.SelectedIndex > 1)
        {
            sql += " and intid=" + ddldriver.SelectedValue;
        }
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgdriver.Visible = true;
            dgdriver.DataSource = ds;
            dgdriver.DataBind();
        }
        else
        {
            dgdriver.Visible = false;
        }
    }   
    protected void dgdriver_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "select *,convert(varchar(10),dtdateofbirth,103) as dateofbirth,convert(varchar(10),dtlicenceissuedate,103) as licenceissuedate,convert(varchar(10),dtlicennceexpirydate,103) as licennceexpirydate from tbldriver where intschool=" + Session["SchoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtdriver.Text = ds.Tables[0].Rows[0]["strdrivername"].ToString();
            txtdateofbirth.Text = ds.Tables[0].Rows[0]["dateofbirth"].ToString();
            txtlicenceno.Text = ds.Tables[0].Rows[0]["strlicenceno"].ToString();
            txtissuedate.Text = ds.Tables[0].Rows[0]["dtlicenceissuedate"].ToString();
            txtexpirydate.Text = ds.Tables[0].Rows[0]["dtlicennceexpirydate"].ToString();
            txtmode.Text= ds.Tables[0].Rows[0]["strmodeoflicence"].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
            txtarea.Text = ds.Tables[0].Rows[0]["strarea"].ToString();
            txtcity.Text = ds.Tables[0].Rows[0]["strcity"].ToString();
            txtstate.Text = ds.Tables[0].Rows[0]["strstate"].ToString();
            txtcountry.Text = ds.Tables[0].Rows[0]["strcountry"].ToString();
            txtphoneno.Text = ds.Tables[0].Rows[0]["strphoneno"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["strmobileno"].ToString();
            imgdriverphoto.ImageUrl = "../images/Driver/" + e.Item.Cells[0].Text + ".jpg";
            trdriverdetails.Visible = true;
            trgrid1.Visible = false;
        }        
    }
    protected void ddldriver_SelectedIndexChanged(object sender, EventArgs e)
    {
        trdriverdetails.Visible = false;
        fillgrid();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        trdriverdetails.Visible = false;
        trgrid1.Visible = true;
    }
}
