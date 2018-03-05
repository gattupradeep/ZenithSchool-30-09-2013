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

public partial class student_approve_lesson_plan : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclass();
            fillteacher();
            ddlsubject.Items.Insert(0, "-Select-");
            filldatagrid();
        }
    }
    protected void fillclass()
    {
        string strsql = "";
        strsql = "select strstandard + ' - ' + strsection as classandsec from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard + ' - ' + strsection ";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "classandsec";
        ddlclass.DataValueField = "classandsec";
        ddlclass.Items.Clear();
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
        ddlclass.Items.Insert(1, "-All-");
    }
    protected void fillteacher()
    {
        ddlteacher.Items.Clear();
        string strsql = "";
        if (ddlclass.SelectedIndex > 1)
        {
            strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername, a.intid from tblemployee a,tblteachingclass b where b.intschool =" + Session["SchoolID"] + " and b.strteachclass='" + ddlclass.SelectedValue + "' and a.intid=b.intemployee group by a.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname";
        }
        else
        {
            strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as teachername, intid from tblemployee where strtype='Teaching Staffs' and intschool =" + Session["SchoolID"].ToString();
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "teachername";
        ddlteacher.DataValueField = "intid";
        ddlteacher.Items.Clear();
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "-Select-");
        ddlteacher.Items.Insert(1, "-All-");
    }
    protected void fillsubject()
    {
        ddlsubject.Items.Clear();
        string strsql = "";
        strsql = "select strsubject from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard ='" + ddlclass.SelectedValue + "' group by strsubject";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.Items.Clear();
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "-Select-");
        ddlsubject.Items.Insert(1, "-All-");
    }
    protected void ddllessonstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldatagrid();
        fillclass();
        fillteacher(); 
        fillsubject();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillteacher();
        fillsubject();
        filldatagrid();
    }
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        filldatagrid();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldatagrid();       
    }
    protected void filldatagrid()
    {
        if (ddllessonstatus.SelectedValue == "Pending")
        {
            sql = "";
            sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname from tblsetlessonplan a, tblemployee b,tblschooltextbook c where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval=0 and a.intid not in (select intlessonid from tblsetlessonplanchanges where intchanges = 0)";
        }
        if (ddllessonstatus.SelectedValue == "Approved")
        {
            sql = "";
            sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname from tblsetlessonplan a, tblemployee b,tblschooltextbook c where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval=1";
        }
        if (ddllessonstatus.SelectedValue == "Changes Req")
        {
            sql = "";
            sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname,d.intlessonid from tblsetlessonplan a, tblemployee b,tblschooltextbook c,tblsetlessonplanchanges d where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval=0 and a.intid=d.intlessonid and d.intchanges=0";
        }
        if (ddllessonstatus.SelectedIndex < 2)
        {
            sql += " and a.intactivemode < 2";
        }
        if (ddlclass.SelectedIndex > 1)
        {
            sql += " and a.strclassperiod LIKE '%" + ddlclass.SelectedValue + "'";
        }
        if (ddlclass.SelectedIndex <= 1)
        {
            sql += " and a.strclassperiod !=''";
        }
        if (ddlteacher.SelectedIndex > 1)
        {
            sql += " and a.intteacher ='" + ddlteacher.SelectedValue + "'";
        }
        if (ddlteacher.SelectedIndex <= 1)
        {
            sql += " and a.intteacher !=''";
        }
        if (ddlsubject.SelectedIndex > 1)
        {
            sql += " and a.strsubject='" + ddlsubject.SelectedValue + "'";
        }
        if (ddlsubject.SelectedIndex <= 1)
        {
            sql += " and a.strsubject !=''";
        }
        if (txtfrom.Text != "" && txtTo.Text != "")
        {
            sql += " and a.dtdate between convert(datetime,'" + txtfrom.Text + "',103) and convert(datetime,'" + txtTo.Text + "',103)";
        }
        sql += "order by dtdate";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dglessons.DataSource = ds;
            dglessons.DataBind();
            dglessons.Visible = true;
            trerrorid.Visible = false;
            if (ddllessonstatus.SelectedValue == "Pending")
            {
                dglessons.Columns[1].Visible = true;
                dglessons.Columns[11].Visible = true;
                dglessons.Columns[12].Visible = false;
                dglessons.Columns[13].Visible = true;
            }
            if (ddllessonstatus.SelectedValue == "Approved")
            {
                dglessons.Columns[1].Visible = false;
                dglessons.Columns[11].Visible = false;
                dglessons.Columns[12].Visible = true;
                dglessons.Columns[13].Visible = false;
            }
            if(ddllessonstatus.SelectedValue == "Changes Req")
            {
                dglessons.Columns[1].Visible = false;
                dglessons.Columns[11].Visible = false;
                dglessons.Columns[12].Visible = false;
                dglessons.Columns[13].Visible = false;
            }
        }
        else
        {
            dglessons.Visible = false;
            trerrorid.Visible = true;
            lblerror.Text = "No Data to display";
        }
    }
    protected void bttnsearch_click(object sender, EventArgs e)
    {
        filldatagrid();
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = sender as CheckBox;
        foreach (DataGridItem gvr in dglessons.Items)
        {
            CheckBox chkSelect = gvr.FindControl("chkselect") as CheckBox;
            if (chkSelect != null)
            {
                chkSelect.Checked = chkSelectAll.Checked;
            }
        }
    }
    protected void approveall()
    {
        DataAccess da = new DataAccess();
        string str;
        string alertmsg = "";
        for (int i = 1; i <= dglessons.Items.Count; i++)
        {
            DataGridItem dgi = dglessons.Items[i - 1];
            CheckBox ch = (CheckBox)dgi.Cells[i - 1].FindControl("chkselect");
            if (ch.Checked == true)
            {
                str = "update tblsetlessonplan set intapproval='1' where intschool=" + Session["SchoolID"].ToString() + " and intid=" + dgi.Cells[0].Text;
                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", dgi.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),142);

                da.ExceuteSqlQuery(str);
                alertmsg = "true";

            }
            else
            {
                msgbox.alert("Please Select atleast one record to Approve");
            }
        }
        if (alertmsg == "true")
        {
            msgbox.alert("Approved Succesfully");
        }
        filldatagrid();
    }
    protected void btnapproveall_Click(object sender, EventArgs e)
    {
        approveall();
    }
    protected void dgaprovelessons_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        sql = "update tblsetlessonplan set intapproval ='1' where intschool='" + Session["SchoolID"].ToString() + "' and intid='" + e.Item.Cells[0].Text + "'";
        Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),142);

        da.ExceuteSqlQuery(sql);
        filldatagrid();
    }
    protected void btnunapprove_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        sql = "update tblsetlessonplan set intapproval ='0' where intschool='" + Session["SchoolID"].ToString() + "' and intid='" + e.Item.Cells[0].Text + "'";
        Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),142);

        da.ExceuteSqlQuery(sql);
        filldatagrid();
    }
}

