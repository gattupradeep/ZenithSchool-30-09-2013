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

public partial class student_Lessons : System.Web.UI.Page

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
            filllessonstatus();
            fillteacher();
            ddlsubject.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(0, "-Select-");
            ddlunitno.Items.Insert(0, "-Select-");
            ddllesson.Items.Insert(0, "-Select-");
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
    protected void filllessonstatus()
    {
        ddllessonstatus.Items.Insert(0, "-Select-");
        ddllessonstatus.Items.Insert(1, "-All-");
        ddllessonstatus.Items.Insert(2, "Completed");
        ddllessonstatus.Items.Insert(3, "Not Completed");
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
    protected void filltextbook()
    {
        if (ddlsubject.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + ddlclass.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddltextbook.DataSource = ds;
            ddltextbook.DataTextField = "strtextbookname";
            ddltextbook.DataValueField = "intid";
            ddltextbook.Items.Clear();
            ddltextbook.DataBind();
            ddltextbook.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(1, "-All-");
        }
        else
        {
        }
    }
    protected void fillunit()
    {
        if (ddltextbook.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select strunitno from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' group by strunitno";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlunitno.DataSource = ds;
            ddlunitno.DataTextField = "strunitno";
            ddlunitno.DataValueField = "strunitno";
            ddlunitno.Items.Clear();
            ddlunitno.DataBind();
            ddlunitno.Items.Insert(0, "-Select-");
            ddlunitno.Items.Insert(1, "-All-");
        }
        else
        {
            ddlunitno.Items.Clear();
            ddlunitno.Items.Insert(0, "-Select-");
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
    }
    protected void filllesson()
    {
        if (ddlunitno.SelectedIndex > 1 && ddltextbook.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select strlessonname from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' and strunitno='" + ddlunitno.SelectedValue + "' group by strlessonname";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddllesson.DataSource = ds;
            ddllesson.DataTextField = "strlessonname";
            ddllesson.DataValueField = "strlessonname";
            ddllesson.Items.Clear();
            ddllesson.DataBind();
            ddllesson.Items.Insert(0, "-Select-");
            ddllesson.Items.Insert(1, "-All-");
        }
        else
        {
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        unitreset();
        trtxtbook.Visible = false;
        fillteacher();
        fillsubject();
        filldatagrid();
    }
    protected void ddllessonstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldatagrid();
    }
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        filldatagrid();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedIndex > 1)
        {
            trtxtbook.Visible = true;
            filltextbook();
            filldatagrid();
        }
        else
        {
            unitreset();
            trtxtbook.Visible = false;
        }
    }
    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillunit();
        filldatagrid();
    }
    protected void ddlunitno_SelectedIndexChanged(object sender, EventArgs e)
    {
        filllesson();
        filldatagrid();
    }
    protected void ddllesson_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldatagrid();
    }
    protected void unitreset()
    {
        ddltextbook.Items.Clear();
        ddlunitno.Items.Clear();
        ddllesson.Items.Clear();
        ddltextbook.Items.Insert(0, "-Select-");
        ddlunitno.Items.Insert(0, "-Select-");
        ddllesson.Items.Insert(0, "-Select-");
    }
    protected void filldatagrid()
    {
        sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname,a.intcompleted from tblsetlessonplan a, tblemployee b,tblschooltextbook c where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval = 1";
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
        if (ddltextbook.SelectedIndex > 1)
        {
            sql += " and a.inttextbook='" + ddltextbook.SelectedValue + "'";
        }
        if (ddltextbook.SelectedIndex <= 1)
        {
            sql += " and a.inttextbook !=''";
        }
        if (ddlunitno.SelectedIndex > 1)
        {
            sql += " and a.strunitname='" + ddlunitno.SelectedValue + "'";
        }
        if (ddlunitno.SelectedIndex <= 1)
        {
            sql += " and a.strunitname !=''";
        }
        if (ddllesson.SelectedIndex > 1)
        {
            sql += " and a.strlessonname='" + ddllesson.SelectedValue + "'";
        }
        if (ddllesson.SelectedIndex <= 1)
        {
            sql += " and a.strlessonname !=''";
        }
        if (ddllessonstatus.SelectedIndex == 2)
        {
            sql += " and a.intcompleted=1";
        }
        if (ddllessonstatus.SelectedIndex == 3)
        {
            sql += " and a.intcompleted=0";
        }
        if (ddllessonstatus.SelectedIndex < 2)
        {
            sql += " and a.intcompleted < 2";
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
        }
        else
        {
            dglessons.Visible = false;
            trerrorid.Visible = true;
            lblerror.Text = "No Data to display";
        }
    }
    protected void dglessons_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Button status = (Button)e.Item.FindControl("btnstatus");
            if (dr["intcompleted"].ToString() == "1")
            {
                status.Text = "Completed";
            }
            else
            {
                status.Text="Not Completed";
            }            
        }
    }
    protected void bttnsearch_click(object sender, EventArgs e)
    {
        filldatagrid();
    }
    protected void dglessons_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        Button status = (Button)e.Item.FindControl("btnstatus");
        if (status.Text == "Not Completed")
        {
            sql = "update tblsetlessonplan set intcompleted = 1 where intid=" + e.Item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);
        }
        else
        {
            sql = "update tblsetlessonplan set intcompleted = 0 where intid=" + e.Item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);
        }
        da.ExceuteSqlQuery(sql);
        filldatagrid();
    }
}
