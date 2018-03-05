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

public partial class attendance_edit_students_attendance : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtdate.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            txtfrom.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            txtto.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            lblmsg.Visible = false;
            fillstandard();
            ddlsection.Items.Insert(0, "--Select--");
            if (Session["attendance"] != null)
            {
                fillgrid();
                
            }
            
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.*,b.strfirstname + ' ' + b.strmiddlename + ' '+ b.strlastname as staffname,c.strfirstname + ' ' + c.strmiddlename + ' '+ c.strlastname as studentname,convert(varchar(10),a.dtdate,103) as date,a.strstandard + '' +a.strsection as class,";
        sql = sql + " a.intstaff as id from tblstudentattendance a,tblemployee b, tblstudent c where b.intid=a.intstaff and c.intid=a.intstudent  and a.intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgstudentattend.DataSource = ds;
        dgstudentattend.DataBind();
        dgstudentattend.Visible = true;
        Session["attendance"] = null;
    }
    protected void fillstandard()
    {
        DataAccess da;
        DataSet ds;
        string strsql;
        da = new DataAccess();
        strsql = "select strstandard from tblstandard_section_subject where intschoolid = '" + Session["SchoolID"].ToString() + "' group by strstandard ";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstandard.Items.Clear();
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
        ddlstandard.Items.Insert(1, "All");
    }
    protected void fillsection()
    {
        DataAccess da;
        DataSet ds;
        string strsql;
        da = new DataAccess();        
        strsql = " select strsection from tblstandard_section_subject where strstandard='" + ddlstandard.SelectedValue + "' and intschoolid = '" + Session["SchoolID"].ToString() + "'  group by strsection ";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsection.Items.Clear();
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("--Select--", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strsection"].ToString(), ds.Tables[0].Rows[i - 1]["strsection"].ToString());
            ddlsection.Items.Add(li);
        }
    }
    protected void search()
    {
        DataAccess da;
        DataSet ds;
        string strsql;
        da = new DataAccess();
        strsql = "select a.*,b.strfirstname + ' ' + b.strmiddlename + ' '+ b.strlastname as staffname,c.strfirstname + ' ' + c.strmiddlename + ' '+ c.strlastname as studentname,convert(varchar(10),a.dtdate,103) as date,a.strstandard + '' +a.strsection as class,";
        strsql = strsql + " a.intstaff as id from tblstudentattendance a,tblemployee b, tblstudent c where b.intid=a.intstaff and c.intid=a.intstudent  and a.intschool=" + Session["SchoolID"].ToString() + " and a.dtdate='" + txtdate.Text + "'";
            if (ddlstandard.SelectedIndex > 1)
            {
                strsql = strsql +  " and a.strstandard='"+ddlstandard.SelectedValue+"'";
                if (ddlsection.SelectedIndex > 0)
                    strsql =strsql +  " and a.strsection='"+ddlsection.SelectedValue+"'";
            }
            strsql = strsql + " order by a.strstandard,a.dtdate"; 
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgstudentattend.DataSource = ds;
                dgstudentattend.DataBind();
                dgstudentattend.Visible = true;
                lblmsg.Visible = false;
            }
            else
            {
                lblmsg.Text = "No search criteria found for selected";
                dgstudentattend.Visible = false;
                lblmsg.Visible = true;
            }
    }
    protected void txtfrom_TextChanged(object sender, EventArgs e)
    {
        DataAccess da;
        DataSet ds;
        string strsql;
        da = new DataAccess();
        strsql = "select a.*,b.strfirstname + ' ' + b.strmiddlename + ' '+ b.strlastname as staffname,c.strfirstname + ' ' + c.strmiddlename + ' '+ c.strlastname as studentname,convert(varchar(10),a.dtdate,103) as date,a.strstandard +' ' +a.strsection as class,";
        strsql = strsql + " a.intstaff as id from tblstudentattendance a,tblemployee b, tblstudent c where b.intid=a.intstaff and c.intid=a.intstudent and a.intschool=" + Session["SchoolID"].ToString() + " and a.dtdate>='" + txtfrom.Text.Trim() + "' and a.dtdate<='" + txtto.Text.Trim() + "'";
        if (ddlstandard.SelectedIndex > 1)
        {
            strsql = " and strstandard='" + ddlstandard.SelectedValue + "'";
            if (ddlsection.SelectedIndex > 1)
                strsql = " and strsection='" + ddlsection.SelectedValue + "'";
        }
        strsql = strsql + " order by a.strstandard,a.dtdate";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgstudentattend.DataSource = ds;
            dgstudentattend.DataBind();
            dgstudentattend.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            lblmsg.Text = "No search criteria found for selected";
            dgstudentattend.Visible = false;
            lblmsg.Visible = true;
        }
    }
    protected void TextTo_TextChanged(object sender, EventArgs e)
    {
        DataAccess da;
        DataSet ds;
        string strsql;
        da = new DataAccess();
        strsql = "select a.*,b.strfirstname + ' ' + b.strmiddlename + ' '+ b.strlastname as staffname,c.strfirstname + ' ' + c.strmiddlename + ' '+ c.strlastname as studentname,convert(varchar(10),a.dtdate,103) as date,a.strstandard +' ' +a.strsection as class,";
        strsql = strsql + " a.intstaff as id from tblstudentattendance a,tblemployee b, tblstudent c where b.intid=a.intstaff and c.intid=a.intstudent and a.intschool=" + Session["SchoolID"].ToString() + " and a.dtdate>='" + txtfrom.Text.Trim() + "' and a.dtdate<='" + txtto.Text.Trim() + "'";
        if (ddlstandard.SelectedIndex > 1)
        {
            strsql = " and strstandard='" + ddlstandard.SelectedValue + "'";
            if (ddlsection.SelectedIndex > 1)
                strsql = " and strsection='" + ddlsection.SelectedValue + "'";
        }
        strsql = strsql + " order by a.strstandard,a.dtdate"; 
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgstudentattend.DataSource = ds;
            dgstudentattend.DataBind();
            dgstudentattend.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            lblmsg.Text = "No search criteria found for selected";
            dgstudentattend.Visible = false;
            lblmsg.Visible = true;
        }
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        search();
    }
    //protected void dgstudentattend_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da;       
    //    string strsql;
    //    da = new DataAccess();
    //    strsql = "delete tblstudentattendance where intid=" + e.Item.Cells[0].Text;
    //    cmd = new SqlCommand(strsql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    search();
    //}
    protected void dgstudentattend_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["studid"] = e.Item.Cells[0].Text;
        Response.Redirect("studentattendance.aspx?studid=" + e.Item.Cells[0].Text);
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsection();
        search();
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        search();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da;
        string strsql;
        da = new DataAccess();
        strsql = "delete tblstudentattendance where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblstudentattendance", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),57);

        cmd = new SqlCommand(strsql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        search();
    }
}
