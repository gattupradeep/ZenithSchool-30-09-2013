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

public partial class student_edit_homework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlsubject.Items.Insert(0, "--Select--");
            //ddlteacher.Items.Insert(0, "--Select--");
            //fillstandard();
            fillteacher();

            if (Request.QueryString["hid2"] != null && Request["tr"] != null)
            {
                ddlteacher.SelectedValue = Request["tr"];
                fillstandard();
                ddlstandard.SelectedValue = Request.QueryString["hid2"];
                fillgrid(1);
                fillbystandard();
                fillsubject();
            }
            if (Request.QueryString["hid"] != null && Request["staff"] != null)
            {
                ddlteacher.SelectedValue = Request["staff"];
                fillstandard();
                ddlstandard.SelectedValue = Request.QueryString["hid"];
                fillgrid(1);
                fillbystandard();
                fillsubject();
            }
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
                fillstandard();
            }

        }
        else
        {
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
                //fillstandard();
            }
        }
    }

    protected void fillteacher()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds;
        da = new DataAccess();
        //str = "select intid,strtittle+' ' +strfirstname +' ' +ltrim(strmiddlename)+' ' + ltrim(strlastname) as staffname from tblemployee where intid in(select strteacher from tbltimetable where strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "'  and strsubject!='Language' and strsubject!='%Language' and strsubject!='Extra Activities' and intschool=" + Session["SchoolID"].ToString() + " group by strteacher union all select strteacher from tbltimetable2 where strstandard1 + ' - ' + strsection1 ='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strteacher union all select strteacher from tbltimetable3 where strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strteacher) order by staffname";
        str = "select intid,strtittle+' ' +strfirstname +' ' +ltrim(strmiddlename)+' ' + ltrim(strlastname) as staffname from tblemployee where intschool= " + Session["SchoolID"].ToString() + " and strtype='Teaching Staffs'";
        if (Session["PatronType"].ToString() == "Teaching Staffs")
        {
            str += " and intID=" + Session["UserID"];
        }
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "staffname";
        ddlteacher.DataValueField = "intid";
        ddlteacher.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlteacher.Items.Insert(0, li);
    }

    protected void fillstandard()
    {
        //string str = "select strstandards from (select strstandard+' - '+strsection as strstandards from tbltimetable where strteacher=" + ddlteacher.SelectedValue + " and strsubject!='Language' and strsubject!='%Language' and strsubject!='Extra Activities' and intschool=" + Session["SchoolID"].ToString() + " union all select strstandard+' - '+strsection as strstandards from tbltimetable2 where strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " union all select strstandard+' - '+strsection as strstandards  from tbltimetable3 where strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " ) as a group by strstandards ";
        string str = "select strstandard from tblhomework a,tblhomeworktopics b where a.inttopic=b.intid and intemployee=" + ddlteacher.SelectedValue + " and a.intschool=b.intschool and a.intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.Items.Clear();
        ddlstandard.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlstandard.Items.Insert(0, li);
    }

    //protected void fillteacher()
    //{
    //    DataAccess da = new DataAccess();
    //    DataSet ds = new DataSet();
    //    string str = "select c.intid,c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname";
    //    str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
    //    str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and a.intschool=" + Session["SchoolID"].ToString();

    //    if (ddlstandard.SelectedIndex > 0)
    //    {
    //        str = str + " and b.strstandard='" + ddlstandard.SelectedValue + "'";
    //    }
    //    str = str + " group by c.intid,strfirstname,strmiddlename,strlastname";
    //    ds = da.ExceuteSql(str);
    //    ddlteacher.DataSource = ds;
    //    ddlteacher.DataTextField = "strstaffname";
    //    ddlteacher.DataValueField = "intid";
    //    ddlteacher.DataBind();
    //    ListItem li = new ListItem("All", "0");
    //    ddlteacher.Items.Insert(0, li);
    //    if (Session["PatronType"].ToString() == "Teaching Staffs")
    //    {
    //        try
    //        {
    //            ddlteacher.SelectedValue = Session["UserID"].ToString();
    //            //fillgrid(1);
    //        }

    //        catch { }
    //        trsearch.Visible = false;
    //        ddlteacher.Enabled = false;
    //        ddlsubject.Enabled = false;
    //    }
    //}
    protected void fillsubject()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select b.strsubject";
        str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
        str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString() + " group by strsubject";
        ds = da.ExceuteSql(str);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlsubject.Items.Insert(0, li);
    }
   protected void fillbystandard()
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillgrid(1);
            fillsubject();
            //fillteacher();
           
        }
        else
        {
            //ddlsubject.Items.Clear();
            //ddlsubject.Items.Insert(0, "--Select--");
            //ddlteacher.Items.Clear();
            //ddlteacher.Items.Insert(0, "--Select--");
            fillgrid(1);
        }
        Session["SearchStudentStandard"] = ddlstandard.SelectedValue;
    }
    protected void fillbysubject()
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            fillgrid(1);
            //fillteacher();
           
        }
        else
        {
            //ddlteacher.Items.Clear();
            //ddlteacher.Items.Insert(0, "--Select--");
            fillgrid(1);
        }
        Session["SearchStudentSubject"] = ddlsubject.SelectedValue;
    }
    //protected void fillbyteacher()
    //{
    //    if (ddlteacher.SelectedIndex > 0)
    //    {
    //        fillgrid(1);
    //        //assigndate();
    //        //publishdate();
    //        //duedate();

    //    }
    //    else
    //    {

    //        fillgrid(1);
    //    }
    //    Session["SearchStudentTeacher"] = ddlteacher.SelectedValue;
    //}
    protected void fillbyassign()
    {
        if (txtdate.Text != "")
        {
            fillgrid(1);
            //publishdate();
            //duedate();
        }
            
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentAssign"] = ddlteacher.SelectedValue;
    }
    protected void fillbypublish()
    {
        if (txtpublish.Text != "")
        {
            fillgrid(1);
            //duedate();
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentPublish"] = ddlteacher.SelectedValue;
    }
    protected void fillbydue()
    {
        if (txtdue.Text != "")
        {
            fillgrid(1);
            //duedate();
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentDue"] = ddlteacher.SelectedValue;
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillgrid(1);
            fillsubject();
            //fillteacher();
            fillbystandard();
          
        }
        else
        {
            trsearch.Visible = false;
            trgrid.Visible = false;
        }
    }
    protected void fillgrid(int frm)
    {
        try
        {
            string str;
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            str = "select a.inthwfrom,a.intid, c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname,";
            str = str + " b.strsubject,a.strtopic,a.strdescription,convert(varchar(10),dtassigndate,111) as strassigndate,";
            str = str + " convert(varchar(10),dtduedate,111) as strduedate,convert(varchar(10),dtpublishdate,111) as strpublishdate";
            str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
            str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and a.intschool=" + Session["SchoolID"].ToString();
            if(ddlstandard.SelectedIndex>0)
                str =str + " and b.strstandard='" + ddlstandard.SelectedValue + "'";
            if (ddlsubject.SelectedIndex > 0)
                str = str + " and b.strsubject='" + ddlsubject.SelectedValue + "'";
            if (ddlteacher.SelectedIndex > 0)
                str = str + " and a.intemployee=" + ddlteacher.SelectedValue;
            if (txtdate.Text != "")
                str = str + " and dtassigndate='" + txtdate.Text.Trim() + "'";
            if (txtdue.Text != "")
                str = str + " and dtduedate='" + txtdue.Text.Trim() + "'";
            if (txtpublish.Text != "")
                str = str + " and dtpublishdate='" + txtpublish.Text.Trim() + "'";
            str = str + " order by dtpublishdate desc";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dghomework.DataSource = ds;
                dghomework.DataBind();
                trsearch.Visible = true;
                trdghomework.Visible = true;
                trgrid.Visible = true;
                tr1.Visible = false;
            }
           else
            {
                tr1.Visible = true;
                trsearch.Visible = true;
                trdghomework.Visible = false;
                errormessage.Text = "No homework assigned for selected criteria";
            }
        }
        catch
        {
        }
    }

    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlsubject.SelectedIndex = 0;
        //fillgrid(0);
        //fillbyteacher();
        fillstandard();
        fillgrid(0);
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid(0);
        //fillteacher();
        //ddlteacher.SelectedIndex = 0;
        fillbysubject();
    }

    protected void dghomework_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("homeworkdetails.aspx?hid2=" + e.Item.Cells[0].Text + "&hwf=" + e.Item.Cells[1].Text);
    }

    protected void dghomework_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("homework.aspx?hid=" + e.Item.Cells[0].Text + "&hwf=" + e.Item.Cells[1].Text);
    }

    //protected void dghomework_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblhomework where intID=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid(1);

    //}

    //protected void dghomework_ItemDataBound(object sender, DataGridItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        ((ImageButton)e.Item.Cells[1].FindControl("delButton")).Attributes.Add("onclick", "return confirm('The selected will be permanently deleted!');");
    //    }
    //}
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid(1);
        fillbyassign();
    }
    protected void txtpublish_TextChanged(object sender, EventArgs e)
    {
        fillgrid(1);
        fillbypublish();
    }
    protected void txtdue_TextChanged(object sender, EventArgs e)
    {
        fillgrid(1);
        fillbydue();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblhomework where intID=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblhomework", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),136);
        da.ExceuteSqlQuery(sql);
        fillgrid(1);
    }
    
}

