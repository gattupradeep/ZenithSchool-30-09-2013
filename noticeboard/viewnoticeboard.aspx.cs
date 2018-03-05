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

public partial class noticeboard_viewnoticeboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            fillnotice();
            //txtdate.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            txtbox.Visible = false;
            trcancel.Visible = false;
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || Session["PatronType"].ToString() == "Teaching Staffs")
            {
                trsidemenu.Visible = false;
            }
        }
    }

    private void fillnotice()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select a.strnoticename,b.intnotice from tblnoticeboard a,tbldailynotice b where b.intnotice=a.intid and b.intschool=" + Session["SchoolID"].ToString() + " group by a.strnoticename,b.intnotice";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        ds = da.ExceuteSql(sql);
        ddlnotice.DataSource = ds;
        ddlnotice.DataTextField = "strnoticename";
        ddlnotice.DataValueField = "intnotice";
        ddlnotice.DataBind();
        ddlnotice.Items.Insert(0, "Select");
        ddlnotice.Items.Insert(1, "All");
        
    }

    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.intid,a.strdescription,convert(varchar(10),a.dtdate,111) as dtdate,a.intnotice,b.strnoticename from tbldailynotice a,tblnoticeboard b where a.intnotice=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlnotice.SelectedValue == "All")
        {
            str = "select a.intid,a.strdescription,convert(varchar(10),a.dtdate,111) as dtdate,a.intnotice,b.strnoticename from tbldailynotice a,tblnoticeboard b where a.intnotice=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            if (txtdate.Text != "")
            {
                str += " and a.dtdate = convert(datetime,'" + txtdate.Text + "',111)";
            }
            str += " order by dtdate";
        }
        else
        {
            if (ddlnotice.SelectedIndex > 0)
            {
                str += " and a.intnotice='" + ddlnotice.SelectedValue + "'";
            }
            if (txtdate.Text != "")
            {
                str += " and a.dtdate = convert(datetime,'" + txtdate.Text + "',111)";
            }
            str += " order by dtdate";
        }
       
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgnotice.DataSource = ds;
            dgnotice.DataBind();
           
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No search criteria found for selected!')", true);
        }
    }

    protected void ddlnotice_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        fillgrid();
    }

    protected void dgnotice_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.*,b.strnoticename,CONVERT(VARCHAR(11), a.dtdate, 106) as date from tbldailynotice a,tblnoticeboard b where a.intid=" + e.Item.Cells[0].Text + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.intnotice=b.intid";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtbox.Visible = true;
            trcancel.Visible = true;
            txtbox.Text = "Date  : " + ds.Tables[0].Rows[0]["date"].ToString() + "\r\n" + "Notice name : " + ds.Tables[0].Rows[0]["strnoticename"].ToString() + "\r\n" + "Description : " + ds.Tables[0].Rows[0]["strdescription"].ToString();
        }
        else
        {
            txtbox.Visible = false;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtbox.Visible = false;
        trcancel.Visible = false;
    }
    protected void txtdate_TextChanged1(object sender, EventArgs e)
    {
       
        fillgrid();
    }
}

