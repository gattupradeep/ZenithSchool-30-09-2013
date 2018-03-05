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

public partial class student_lesson_plan_status : System.Web.UI.Page
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
        fillteacher();
        fillsubject();
        fillclass();
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
            sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname,'' as strreqchanges from tblsetlessonplan a, tblemployee b,tblschooltextbook c where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval=0 and a.intid not in (select intlessonid from tblsetlessonplanchanges where intchanges = 0)";
        }
        if (ddllessonstatus.SelectedValue == "Approved")
        {
            sql = "";
            sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname,'' as strreqchanges from tblsetlessonplan a, tblemployee b,tblschooltextbook c where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval=1";
        }
        if (ddllessonstatus.SelectedValue == "Changes Req")
        {
            sql = "";
            sql = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,strdescription,a.intteacher,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as teachername,c.strtextbookname,d.intlessonid,d.strreqchanges from tblsetlessonplan a, tblemployee b,tblschooltextbook c,tblsetlessonplanchanges d where a.intschool='" + Session["SchoolID"] + "' and a.intteacher=b.intid and c.intid=a.inttextbook and a.intapproval=0 and a.intid=d.intlessonid and d.intchanges=0";
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
            if (ddllessonstatus.SelectedValue == "Pending" || ddllessonstatus.SelectedValue == "Approved" )
            {
                dglessons.Columns[10].Visible = false;
                dglessons.Columns[11].Visible = false;
            }
            if (ddllessonstatus.SelectedValue == "Changes Req")
            {
                dglessons.Columns[10].Visible = true;
                dglessons.Columns[11].Visible = true;
            }
        }
        else
        {
            dglessons.Visible = false;
            trerrorid.Visible = true;
            lblerror.Text = "No Data to display";
        }
    }
    protected void dglesson_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ImageButton btnedit = (ImageButton)e.Item.FindControl("btnedit");

            DropDownList dltextbook = (DropDownList)e.Item.FindControl("ddltextbook");
            DropDownList dlunit = (DropDownList)e.Item.FindControl("ddlunitname");
            DropDownList dllesson = (DropDownList)e.Item.FindControl("ddllesson");
            TextBox txttopic = (TextBox)e.Item.FindControl("txttopic");
            TextBox txtdesc = (TextBox)e.Item.FindControl("txtdescription");

            Label lbltextbook = (Label)e.Item.FindControl("lbltextbook");
            Label lblunitname = (Label)e.Item.FindControl("lblunitname");
            Label lbllesson = (Label)e.Item.FindControl("lbllesson");
            Label lbltopic = (Label)e.Item.FindControl("lbltopic");
            Label lbldescription = (Label)e.Item.FindControl("lbldescription");
            TextBox lbldesc = (TextBox)e.Item.FindControl("txtdescription");

            if (btnedit.ImageUrl == "../media/images/edit.gif")
            {
                dltextbook.Visible = false;
                dlunit.Visible = false;
                dllesson.Visible = false;
                txttopic.Visible = false;
                txtdesc.Visible = false;

                lbltextbook.Visible = true;
                lblunitname.Visible = true;
                lbllesson.Visible = true;
                lbltopic.Visible = true;
                lbldescription.Visible = true;
            }
            if (btnedit.ImageUrl == "../media/images/update.gif")
            {
                dltextbook.Visible = true;
                dlunit.Visible = true;
                dllesson.Visible = true;
                txttopic.Visible = true;
                txtdesc.Visible = true;

                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                sql = "select *,convert(varchar(10),dtdate,103) as dtdates from tblsetlessonplan where intschool=" + Session["SchoolID"] + " and intid=" + e.Item.Cells[0].Text;
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txttopic.Text = ds.Tables[0].Rows[0]["strtopic"].ToString();
                    txtdesc.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();
                    string[] period = e.Item.Cells[3].Text.Split('/');
                    DataAccess datextb = new DataAccess();
                    sql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + period[1] + "' and strsubject='" + e.Item.Cells[4].Text + "'";
                    DataSet dstextb = new DataSet();
                    dstextb = datextb.ExceuteSql(sql);
                    dltextbook.DataSource = dstextb;
                    dltextbook.DataTextField = "strtextbookname";
                    dltextbook.DataValueField = "intid";
                    dltextbook.Items.Clear();
                    dltextbook.DataBind();
                    dltextbook.Items.Insert(0, "-Select-");
                    dltextbook.SelectedValue = ds.Tables[0].Rows[0]["inttextbook"].ToString();

                    DataAccess daunit = new DataAccess();
                    sql = "select distinct strunitno from tblschooltextbookunits where inttextbook=" + dltextbook.SelectedValue;
                    DataSet dsunit = new DataSet();
                    dsunit = daunit.ExceuteSql(sql);
                    dlunit.DataSource = dsunit;
                    dlunit.DataTextField = "strunitno";
                    dlunit.DataValueField = "strunitno";
                    dlunit.Items.Clear();
                    dlunit.DataBind();
                    dlunit.SelectedValue = ds.Tables[0].Rows[0]["strunitname"].ToString();
                    DataAccess dalesson = new DataAccess();
                    sql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
                    DataSet dslesson = new DataSet();
                    dslesson = dalesson.ExceuteSql(sql);
                    dllesson.DataSource = dslesson;
                    dllesson.DataTextField = "strlessonname";
                    dllesson.DataValueField = "strlessonname";
                    dllesson.Items.Clear();
                    dllesson.DataBind();
                    dllesson.SelectedValue = ds.Tables[0].Rows[0]["strlessonname"].ToString();
                }
                lbltextbook.Visible = false;
                lblunitname.Visible = false;
                lbllesson.Visible = false;
                lbltopic.Visible = false;
                lbldescription.Visible = false;
                btnedit.ImageUrl = "../media/images/update.gif";
            }
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string dr = item.Cells[0].Text;
        ImageButton btnedit = (ImageButton)item.FindControl("btnedit");
        
        DropDownList dltextbook = (DropDownList)item.FindControl("ddltextbook");
        DropDownList dlunit = (DropDownList)item.FindControl("ddlunitname");
        DropDownList dllesson = (DropDownList)item.FindControl("ddllesson");
        TextBox txttopic = (TextBox)item.FindControl("txttopic");
        TextBox txtdesc = (TextBox)item.FindControl("txtdescription");

        Label lbltextbook = (Label)item.FindControl("lbltextbook");
        Label lblunitname = (Label)item.FindControl("lblunitname");
        Label lbllesson = (Label)item.FindControl("lbllesson");
        Label lbltopic = (Label)item.FindControl("lbltopic");
        Label lbldescription = (Label)item.FindControl("lbldescription");
        TextBox lbldesc = (TextBox)item.FindControl("txtdescription");

        if (btnedit.ImageUrl == "../media/images/update.gif")
        {
            if (dltextbook.SelectedIndex < 1 && dlunit.SelectedIndex < 1 && dllesson.SelectedIndex < 1 && txttopic.Text !="")
            {
                msgbox.alert("Please fill all the fields");
            }
            else
            {
                DataAccess da = new DataAccess();
                sql = "update tblsetlessonplan set inttextbook='" + dltextbook.SelectedValue + "',strunitname='" + dlunit.SelectedValue + "',strlessonname='" + dllesson.SelectedValue + "',strtopic='" + txttopic.Text + "',strdescription='" + txtdesc.Text + "' where intid=" + item.Cells[0].Text;
                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),143);

                da.ExceuteSqlQuery(sql);
                DataAccess da1 = new DataAccess();
                sql = "update tblsetlessonplanchanges set intchanges=1 where intlessonid=" + item.Cells[0].Text;
                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplanchanges", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),143);

                da1.ExceuteSqlQuery(sql);
                filldatagrid();
            }
        }
        if (btnedit.ImageUrl == "../media/images/edit.gif")
        {
            dltextbook.Visible = true;
            dlunit.Visible = true;
            dllesson.Visible = true;
            txttopic.Visible = true;
            txtdesc.Visible = true;

            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            sql = "select *,convert(varchar(10),dtdate,103) as dtdates from tblsetlessonplan where intschool=" + Session["SchoolID"] + " and intid=" + dr.ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txttopic.Text = ds.Tables[0].Rows[0]["strtopic"].ToString();
                txtdesc.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();
                string[] period = item.Cells[3].Text.Split('/');
                DataAccess datextb = new DataAccess();
                sql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + period[1] + "' and strsubject='" + item.Cells[4].Text + "'";
                DataSet dstextb = new DataSet();
                dstextb = datextb.ExceuteSql(sql);
                dltextbook.DataSource = dstextb;
                dltextbook.DataTextField = "strtextbookname";
                dltextbook.DataValueField = "intid";
                dltextbook.Items.Clear();
                dltextbook.DataBind();
                dltextbook.Items.Insert(0, "-Select-");
                dltextbook.SelectedValue = ds.Tables[0].Rows[0]["inttextbook"].ToString();

                DataAccess daunit = new DataAccess();
                sql = "select distinct strunitno from tblschooltextbookunits where inttextbook=" + dltextbook.SelectedValue;
                DataSet dsunit = new DataSet();
                dsunit = daunit.ExceuteSql(sql);
                dlunit.DataSource = dsunit;
                dlunit.DataTextField = "strunitno";
                dlunit.DataValueField = "strunitno";
                dlunit.Items.Clear();
                dlunit.DataBind();
                dlunit.SelectedValue = ds.Tables[0].Rows[0]["strunitname"].ToString();
                DataAccess dalesson = new DataAccess();
                sql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
                DataSet dslesson = new DataSet();
                dslesson = dalesson.ExceuteSql(sql);
                dllesson.DataSource = dslesson;
                dllesson.DataTextField = "strlessonname";
                dllesson.DataValueField = "strlessonname";
                dllesson.Items.Clear();
                dllesson.DataBind();
                dllesson.SelectedValue = ds.Tables[0].Rows[0]["strlessonname"].ToString();
            }
            lbltextbook.Visible = false;
            lblunitname.Visible = false;
            lbllesson.Visible = false;
            lbltopic.Visible = false;
            lbldescription.Visible = false;
            btnedit.ImageUrl = "../media/images/update.gif";            
        }
    }

    protected void ddltextbook_SelectedIndexchanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dltextbook = new DropDownList();
        DropDownList dlunit = new DropDownList();
        DropDownList dllesson = new DropDownList();
        dltextbook = (DropDownList)item.FindControl("ddltextbook");
        dlunit = (DropDownList)item.FindControl("ddlunitname");
        dllesson = (DropDownList)item.FindControl("ddllesson");
        sql = "select distinct strunitno from tblschooltextbookunits where inttextbook=" + dltextbook.SelectedValue;
        ds = da.ExceuteSql(sql);
        dlunit.DataSource = ds;
        dlunit.DataTextField = "strunitno";
        dlunit.DataValueField = "strunitno";
        dlunit.Items.Clear();
        dlunit.DataBind();
        sql = "";
        sql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        dllesson.DataSource = ds;
        dllesson.DataTextField = "strlessonname";
        dllesson.DataValueField = "strlessonname";
        dllesson.Items.Clear();
        dllesson.DataBind();
    }
    protected void ddlunit_SelectedIndexchanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dltextbook = new DropDownList();
        DropDownList dlunit = new DropDownList();
        DropDownList dllesson = new DropDownList();
        dltextbook = (DropDownList)item.FindControl("ddltextbook");
        dlunit = (DropDownList)item.FindControl("ddlunitname");
        dllesson = (DropDownList)item.FindControl("ddllesson");
        sql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        dllesson.DataSource = ds;
        dllesson.DataTextField = "strlessonname";
        dllesson.DataValueField = "strlessonname";
        dllesson.Items.Clear();
        dllesson.DataBind();
    }
    protected void bttnsearch_click(object sender, EventArgs e)
    {
        filldatagrid();
    }
}
