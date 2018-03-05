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

public partial class attendance_edit_staff_attendance : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            fillstafftype();
            txtdate.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            txtfrom.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            txtto.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            ddlstaff.Items.Insert(0, "-Select-");            
            lblmsg.Visible = false;
            if (Session["intID"] != null)
            {
                fillgrid();
            }
        }

    }
    protected void fillgrid()
    {
        da = new DataAccess();
        string sql = "select convert(varchar(10),a.dtdate,103) as date,a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as staffname,c.strleavecategory from tblstaffattendance a,dbo.tblemployee b,dbo.tblleavecategory c where a.intschool=" + Session["SchoolID"].ToString() + " and a.intemployee = b.intid and a.intleavetype=c.intid and a.intid=" + Session["intID"].ToString() + " order by a.dtdate";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgstaffattend.DataSource = ds;
        dgstaffattend.DataBind();
        dgstaffattend.Visible = true;
        Session["intID"] = null;
    }
    protected void fillstafftype()
    {
        ddltype.Items.Clear();
        DataAccess da = new DataAccess();
        string sql = "select strstafftype from tblstafftype";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddltype.DataSource = ds;
        ddltype.DataTextField = "strstafftype";
        ddltype.DataValueField = "strstafftype";
        ddltype.DataBind();
        ddltype.Items.Insert(0,"--Select--");
        ddltype.Items.Insert(1,"All");
    }
    protected void fillstaffname()
    {
        ddlstaff.Items.Clear();
        da = new DataAccess();
        strsql = " select strfirstname + ' ' + strmiddlename + ' ' + strlastname as staffname, intid from tblemployee where intschool=" + Session["SchoolID"].ToString();
        if(ddltype.SelectedIndex > 1)
        strsql = " select strfirstname + ' ' + strmiddlename + ' ' + strlastname as staffname, intid from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='" + ddltype.SelectedValue + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaff.DataSource = ds;
        ddlstaff.DataTextField = "staffname";
        ddlstaff.DataValueField = "intid";
        ddlstaff.DataBind();
        ddlstaff.Items.Insert(0, "-Select-");
        if (ddltype.SelectedIndex > 1)
        {
            ddlstaff.Items.Insert(1, "All");
        }
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaffname();
        search();
    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        search();
    }
    protected void search()
    {
        da = new DataAccess();
        strsql = "select convert(varchar(10),a.dtdate,103) as date,a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as staffname,c.strleavecategory from tblstaffattendance a,dbo.tblemployee b,dbo.tblleavecategory c where a.intschool=" + Session["SchoolID"].ToString();
        if (ddltype.SelectedIndex > 1)
        {
            strsql = strsql + " and a.strtype='" + ddltype.SelectedValue + "'";
            if (ddlstaff.SelectedIndex > 1)
                strsql = strsql + " and a.intemployee=" + ddlstaff.SelectedValue;
        }
        strsql = strsql + " and a.intemployee = b.intid and a.intleavetype=c.intid and a.dtdate='" + txtdate.Text.Trim() + "' order by a.dtdate";    
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgstaffattend.DataSource = ds;
            dgstaffattend.DataBind();
            dgstaffattend.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            dgstaffattend.Visible = false;
            lblmsg.Text = "No search criteria found for selected date " + txtdate.Text.Trim();
            lblmsg.Visible = true;
        }
    }
    protected void dgstaffattend_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        Response.Redirect("staffattendance.aspx?intID=" + e.Item.Cells[0].Text);
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        search();        
    }
    //protected void dgstaffattend_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblstaffattendance where intID=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    search();
    //}
    protected void txtfrom_TextChanged(object sender, EventArgs e)
    {
        da = new DataAccess();
        strsql = "select convert(varchar(10),a.dtdate,103) as date,a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as staffname,c.strleavecategory from tblstaffattendance a,dbo.tblemployee b,dbo.tblleavecategory c where a.intschool=" + Session["SchoolID"].ToString();
        if (ddltype.SelectedIndex > 1)
        {
            strsql = strsql + " and a.strtype='" + ddltype.SelectedValue + "'";
            if (ddlstaff.SelectedIndex > 1)
                strsql = strsql + " and a.intemployee=" + ddlstaff.SelectedValue;
        }
        strsql = strsql + " and a.intemployee = b.intid and a.intleavetype=c.intid and a.dtdate>='" + txtfrom.Text.Trim() + "' and a.dtdate<='" + txtto.Text.Trim() + "' order by a.dtdate";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgstaffattend.DataSource = ds;
            dgstaffattend.DataBind();
            dgstaffattend.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            dgstaffattend.Visible = false;
            lblmsg.Text = "No search criteria found for selected";
            lblmsg.Visible = true;
        }
    }
    protected void TextTo_TextChanged(object sender, EventArgs e)
    {
        da = new DataAccess();
        strsql = "select convert(varchar(10),a.dtdate,103) as date,a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as staffname,c.strleavecategory from tblstaffattendance a,dbo.tblemployee b,dbo.tblleavecategory c where a.intschool=" + Session["SchoolID"].ToString();
        if (ddltype.SelectedIndex > 1)
        {
            strsql = strsql + " and a.strtype='" + ddltype.SelectedValue + "'";
            if (ddlstaff.SelectedIndex > 1)
                strsql = strsql + " and a.intemployee=" + ddlstaff.SelectedValue;
        }
        strsql = strsql + " and a.intemployee = b.intid and a.intleavetype=c.intid and a.dtdate>='" + txtfrom.Text.Trim() + "' and a.dtdate<='" + txtto.Text.Trim() + "' order by a.dtdate";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgstaffattend.DataSource = ds;
            dgstaffattend.DataBind();
            dgstaffattend.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            dgstaffattend.Visible = false;
            lblmsg.Text = "No search criteria found for selected";
            lblmsg.Visible = true;
        }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblstaffattendance where intID=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblstaffattendance", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),48);

        da.ExceuteSqlQuery(sql);
        search();
    }
}
