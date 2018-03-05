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


public partial class student_Editlessons : System.Web.UI.Page
{
    string sql;
    public string editintid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            editintid = Request["lesson"];
            editmode();
            changestable();
        }
        else
        {
            editintid=Request["lesson"];
        }
    }
   
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds;
        string strsql = "";
        if (editintid != null)
        {
            strsql = "select CONVERT(VARCHAR(10),dtdate,101) as Date,* from tblsetlesson where intlesson='" + editintid + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            dglesson.DataSource = ds;
            dglesson.DataBind();
        }
    }
    protected void dglesson_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        string strsql = "";
        
        if (editintid == null)
        {
            strsql = "select strunitno+'-'+strunitname as unit from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + lblsubject.Text + "' and strstandard='" + lblstandard.Text + " - "+ lblsection.Text +"' and  strtextbook='" + lbltextbook.Text + "' group by strunitno,strunitname";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList unit = (DropDownList)e.Item.FindControl("ddlunitname");
                unit.DataSource = ds.Tables[0];
                unit.DataTextField = "unit";
                unit.DataValueField = "unit";
                unit.DataBind();

                string[] unitname = unit.SelectedValue.ToString().Split('-');
                strsql = "select strlessonName,intid from dbo.tblschoolsyllabus where strstandard='" + lblstandard.Text + " - " + lblsection.Text +"' and strsubject='" + lblsubject.Text + "' and strtextbook='" + lbltextbook.Text + "' and strunitno='" + unitname[0] + "'";
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                DropDownList lesson = (DropDownList)e.Item.FindControl("ddllesson");
                lesson.DataSource = ds;
                lesson.DataTextField = "strlessonName";
                lesson.DataValueField = "intid";
                lesson.DataBind();
                DataRowView dr1 = (DataRowView)e.Item.DataItem;
                DropDownList dlu = new DropDownList();
                DropDownList dlL = new DropDownList();
                dlu = (DropDownList)e.Item.FindControl("ddlunitname");
                dlL = (DropDownList)e.Item.FindControl("ddllesson");
                dlu.SelectedValue = dr1["strunitname"].ToString();
                dlL.SelectedValue = dr1["intid"].ToString();
            }
        }
       else
        {
            strsql = "select strunitno+'-'+strunitname as strunitname from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + lblsubject.Text + "' and strstandard='" + lblstandard.Text + " - " + lblsection.Text +"' and  strtextbook='" + lbltextbook.Text + "' group by strunitno,strunitname";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList unit = (DropDownList)e.Item.FindControl("ddlunitname");
                unit.DataSource = ds;
                unit.DataTextField = "strunitname";
                unit.DataValueField = "strunitname";
                unit.DataBind();
                DataRowView dr1 = (DataRowView)e.Item.DataItem;
                DropDownList dlu = new DropDownList();
                DropDownList dlL = new DropDownList();
                TextBox txttopic = new TextBox();
                TextBox txtdescript = new TextBox();
                dlu = (DropDownList)e.Item.FindControl("ddlunitname");
                dlL = (DropDownList)e.Item.FindControl("ddllesson");
                txttopic = (TextBox)e.Item.FindControl("txttopic");
                txtdescript = (TextBox)e.Item.FindControl("txtdescription");
                dlu.SelectedValue = dr1["strunitname"].ToString();
                //dlL.SelectedValue = dr1["intid"].ToString();
                string[] unitname = dlu.SelectedValue.ToString().Split('-');
                strsql = "select strlessonName,intid from dbo.tblschoolsyllabus where strstandard='" + lblstandard.Text + " - " + lblsection.Text + "' and strsubject='" + lblsubject.Text + "' and strtextbook='" + lbltextbook.Text + "' and strunitno='" + unitname[0] + "'";
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                
                DropDownList lesson = (DropDownList)e.Item.FindControl("ddllesson");
                lesson.DataSource = ds;
                lesson.DataTextField = "strlessonName";
                lesson.DataValueField = "intid";
                lesson.DataBind();
                dlu = (DropDownList)e.Item.FindControl("ddlunitname");
                dlL = (DropDownList)e.Item.FindControl("ddllesson");
                txttopic = (TextBox)e.Item.FindControl("txttopic");
                txtdescript = (TextBox)e.Item.FindControl("txtdescription");
                dlu.SelectedValue = dr1["strunitname"].ToString();
                dlL.SelectedValue = dr1["intid"].ToString();
                txttopic.Text = dr1["strtopic"].ToString();
                txtdescript.Text = dr1["strdescription"].ToString();
            }
        }
    }
    protected void ddlunitname_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds;
        string strsql = "";
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dlu = new DropDownList();
        DropDownList dlL = new DropDownList();
        TextBox txttopic = new TextBox();
        TextBox txtdescript = new TextBox();
        dlu = (DropDownList)item.FindControl("ddlunitname");
        dlL = (DropDownList)item.FindControl("ddllesson");
        txttopic = (TextBox)item.FindControl("txttopic");
        txtdescript = (TextBox)item.FindControl("txtdescription");
        DataGridItem dgi = dglesson.Items[index];
        string[] unitname = dlu.SelectedValue.ToString().Split('-');
        strsql = "select strlessonName,intid from dbo.tblschoolsyllabus where strstandard='" + lblstandard.Text + " - "+ lblsection.Text +"' and strsubject='" + lblsubject.Text + "' and strtextbook='" + lbltextbook.Text + "' and strunitno='" + unitname[0] + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlL.DataSource = ds;
        dlL.DataTextField = "strlessonName";
        dlL.DataValueField = "intid";
        dlL.DataBind();
    }
    protected void editmode()
    {
        DataAccess da = new DataAccess();
        //sql = "select strstandard,strsection,convert(varchar(10),dtfromdate,111) as dtfromdate, convert(varchar(10),dttodate,111) as dttodate,strsubject,strtextbook,intemployee from tblsetlessondetails where intschool='" + Session["SchoolID"] + "' and intid='" + editintid + "'";
        sql = "select a.strstandard,a.strsection,convert(varchar(10),a.dtfromdate,111) as dtfromdate,";
        sql += " convert(varchar(10),a.dttodate,111) as dttodate,a.strsubject,a.strtextbook,";
        sql += " a.intemployee,b.strfirstname+' '+  b.strmiddlename+' '+b.strlastname as teachername";
        sql += " from tblsetlessondetails a,tblemployee b where a.intschool='" + Session["SchoolID"] + "' and a.intid='" + editintid + "'";
        sql += " and b.intID = a.intemployee";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        lblstandard.Text=ds.Tables[0].Rows[0]["strstandard"].ToString();
        lblsection.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0]["dtfromdate"].ToString();
        lbltodate.Text = ds.Tables[0].Rows[0]["dttodate"].ToString();
        lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
        lbltextbook.Text = ds.Tables[0].Rows[0]["strtextbook"].ToString();
        lblteacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
        fillgrid();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds;
            for (int i = 0; i < dglesson.Items.Count; i++)
            {
                DataGridItem dg = dglesson.Items[i];
                DropDownList strunit = (DropDownList)dg.FindControl("ddlunitname");
                DropDownList strlesson = (DropDownList)dg.FindControl("ddllesson");
                TextBox strtopic = new TextBox();
                strtopic = (TextBox)dg.FindControl("txttopic");
                TextBox strdescription = new TextBox();
                strdescription = (TextBox)dg.FindControl("txtdescription");
                sql = "update tblsetlesson set dtdate='" + dg.Cells[1].Text + "',strlessonname ='" + strlesson.SelectedValue + "',strtopic='" + strtopic.Text + "',strdescription='" + strdescription.Text + "',strunitname='" + strunit.SelectedValue + "' where intid='" + dg.Cells[0].Text + "'";
                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlesson", dg.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);

                ds = new DataSet();
                ds = da.ExceuteSql(sql);
            }
            sql = "update tblsetlessonreqchanges set intchanges=1 where intidlessondetails='" + editintid + "'";
            Functions.UserLogs(Session["UserID"].ToString(), "tblsetlesson", editintid, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);

            DataSet ds5 = new DataSet();
            ds5 = da.ExceuteSql(sql);
            Response.Redirect("edit_lesson_plan.aspx?up=1");
        }
        catch { }
        
    }
    protected void changestable()
    {
        DataAccess da = new DataAccess();
        sql = "select * from tblsetlessonreqchanges where intidlessondetails =" + editintid + " and intchanges=0";
        DataSet ds6 = new DataSet();
        ds6 = da.ExceuteSql(sql);
        if (ds6.Tables[0].Rows.Count > 0)
        {
            tdchanges.Visible = true;
            lblchanges.Text=ds6.Tables[0].Rows[0]["strreqchanges"].ToString();

        }
        else
        {
            tdchanges.Visible = false;
        }
     }
}
