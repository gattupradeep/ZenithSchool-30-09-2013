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

public partial class exam_edit_examschedule : System.Web.UI.Page
{
    DataAccess da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillexamtype();
            tr1tag.Visible = false;
            if (Request["eid"] != null)
            {
                try
                {
                    if (Session["SearchStudentStandard"] != null)
                    {
                        ddlstandard.SelectedValue = Session["SearchStudentStandard"].ToString();
                        fillbystandard();
                        search(2);
                    }
                    if (Session["SearchStudentExamtype"] != null)
                    {
                        ddlexamtype.SelectedValue = Session["SearchStudentExamtype"].ToString();
                        fillbyexamtype();
                        search(2);
                    }
                    
                }
                catch { }
            }
            
        }
    }

    protected void fillstandard()
    {
        string str = "select strclass from tblexamschedule where intschool = " + Session["SchoolID"].ToString() + " group by strclass";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataBind();
        ListItem li = new ListItem("---Select---", "-1");
        ddlstandard.Items.Insert(0, li);
        li = new ListItem("All Classes", "All Classes");
        ddlstandard.Items.Insert(1, li);
    }
    protected void fillbystandard()
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            search(2);
            fillexamtype();
            filldate();
            fillsubject();
            fillmonth();
        }
        else
        {
            ddlexamtype.Items.Clear();
            ddlexamtype.Items.Insert(0, "--Select--");
            search(2);
        }
        Session["SearchStudentStandard"] = ddlstandard.SelectedValue;
    }
    protected void fillexamtype()
    {
        string str;
        if (ddlstandard.SelectedIndex == 1)
            str = "select strexamtype from tblexamschedule where intschool = " + Session["SchoolID"].ToString() + " group by strexamtype";
        else
            str = "select strexamtype from tblexamschedule where intschool = " + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' group by strexamtype";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListItem li = new ListItem("All Exams", "0");
            ddlexamtype.Items.Insert(0, li);
        }
        else
        {
            ListItem li = new ListItem("---Select---", "0");
            ddlexamtype.Items.Insert(0, li);
        }
    }
    protected void fillbyexamtype()
    {
        if (ddlexamtype.SelectedIndex > 0)
        {
            search(2);
            filldate();
            fillsubject();
            fillmonth();

        }
        else
        {

            search(2);
        }
        Session["SearchStudentExamtype"] = ddlexamtype.SelectedValue;
    }
    protected void fillsubject()
    {
        string str;
        if (ddlstandard.SelectedIndex == 1)
            str = "select strsubjectname from tblexamschedule where intschool = " + Session["SchoolID"].ToString();
        else
            str = "select strsubjectname from tblexamschedule where intschool = " + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";

        if (ddlexamtype.SelectedIndex > 0)
            str = str + " and strexamtype='" + ddlexamtype.SelectedValue + "'";

        str = str + " group by strsubjectname";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubjectname";
        ddlsubject.DataValueField = "strsubjectname";
        ddlsubject.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlsubject.Items.Insert(0, li);
    }

    protected void filldate()
    {
        string str;
        if (ddlstandard.SelectedIndex == 1)
            str = "select CONVERT(VARCHAR(11), dtexamdate, 106)  AS date from tblexamschedule where intschool = " + Session["SchoolID"].ToString();
        else
            str = "select CONVERT(VARCHAR(11), dtexamdate, 106)  AS date from tblexamschedule where intschool = " + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";

        if (ddlexamtype.SelectedIndex > 0)
            str = str + " and strexamtype='" + ddlexamtype.SelectedValue + "'";

        str = str + " group by dtexamdate";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddldate.DataSource = ds;
        ddldate.DataTextField = "date";
        ddldate.DataValueField = "date";
        ddldate.DataBind();
        ListItem li = new ListItem("All", "0");
        ddldate.Items.Insert(0, li);
    }

    protected void fillmonth()
    {
        string str;
        if (ddlstandard.SelectedIndex == 1)
            str = "select CONVERT(CHAR(4),dtexamdate, 100) as month from tblexamschedule where intschool = " + Session["SchoolID"].ToString();
        else
            str = "select CONVERT(CHAR(4),dtexamdate, 100) as month from tblexamschedule where intschool = " + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";

        if (ddlexamtype.SelectedIndex > 0)
            str = str + " and strexamtype='" + ddlexamtype.SelectedValue + "'";

        str = " select month from (" + str + ") as a group by month";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlmonth.DataSource = ds;
        ddlmonth.DataTextField = "month";
        ddlmonth.DataValueField = "month";
        ddlmonth.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlmonth.Items.Insert(0, li);
    }

    protected void search(int id)
    {
        DataSet ds;
        string str = "";
        str = "select a.intid, CONVERT(VARCHAR(11), a.dtexamdate, 106) as date,CONVERT(CHAR(4),a.dtexamdate, 100) as month,a.strclass,a.strsubjectname,a.strexampaper,a.strexamstarttime+' To '+a.strexamendtime as time,b.intmaxmark, c.strtittle + ' ' + c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + c.strlastname as staffname from tblexamschedule a,tblschoolexamsettings b, tblemployee c where a.strinvegilator=c.intid and  a.intschool=b.intschoolid and a.strclass=b.strclass and a.strexamtype=b.strexamtype and a.strsubjectname=b.strsubject and a.strexampaper=b.strexampapername and a.intschool=" + Session["SchoolID"].ToString();
        lblexamtype.Text = "Exam Schedule for " + ddlstandard.SelectedValue;
        if (ddlstandard.SelectedIndex > 1)
            str = str + " and a.strclass='" + ddlstandard.SelectedValue + "'";
        if (ddlexamtype.SelectedIndex > 0)
        {
            str = str + " and a.strexamtype='" + ddlexamtype.SelectedValue + "'";
            lblexamtype.Text = lblexamtype.Text + " - " + ddlexamtype.SelectedValue;
        }
        if (id == 2)
        {
            if (ddlsubject.SelectedIndex > 0)
                str = str + " and a.strsubjectname='" + ddlsubject.SelectedValue + "'";
            if (ddldate.SelectedIndex > 0)
                str = str + " and CONVERT(VARCHAR(11), a.dtexamdate, 106)='" + ddldate.SelectedValue + "'";
            if (ddlmonth.SelectedIndex > 0)
                str = str + " and CONVERT(CHAR(4),a.dtexamdate, 100)='" + ddlmonth.SelectedValue + "'";
        }
        str = str + " order by a.dtexamdate asc";
        DataAccess da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgexam.DataSource = ds;
            dgexam.DataBind();
            tr1tag.Visible = true;
            if (id == 1)
            {
                filldate();
                fillsubject();
                fillmonth();
            }
            trsearch.Visible = true;
        }
        else
        {
            trerror.Visible = true;
            lblmsg.Text = "No search criteria found for selected";
          
        }
       
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillbystandard();
            fillexamtype();
            search(1);
            tr1tag.Visible = true;
        }
    }

    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        search(1);
        fillbyexamtype();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddldate.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        search(2);
    }

    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddldate.SelectedIndex = 0;
        ddlsubject.SelectedIndex = 0;
        search(2);
    }

    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlsubject.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        search(2);
    }

    protected void dgexam_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            string str = "select * from tblsetportion where intschool=" + Session["SchoolID"].ToString() + " and dtdate='" + e.Item.Cells[1].Text + "' and strclass='" + e.Item.Cells[2].Text + "' and strsubject='" + e.Item.Cells[3].Text + "' and strpaper='" + e.Item.Cells[5].Text + "'";
            DataAccess da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count == 0)
            {
                e.Item.Cells[7].Text = "Portion not assigned";
            }
        }
        catch { }
    }

   
    protected void dgexam_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("examschedule.aspx?eid=" + e.Item.Cells[0].Text);
    }

    protected void dgexam_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string strsql = "delete tblexamschedule where intid=" + e.Item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedule", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),203);
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);

        strsql = "select intid from tblschoolsetseating where intexamid=" + e.Item.Cells[0].Text;
        DataAccess dass = new DataAccess();
        DataSet dsss = new DataSet();
        dsss = dass.ExceuteSql(strsql);
        if (dsss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsss.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsetseating", dsss.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 203);
            }
        }
        strsql = "delete tblschoolsetseating where intexamid=" + e.Item.Cells[0].Text;
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);

        strsql = "select intid from tblexamschedulelessons where intexamid=" + e.Item.Cells[0].Text;
        DataAccess daes = new DataAccess();
        DataSet dses = new DataSet();
        dses = daes.ExceuteSql(strsql);
        if (dsss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsss.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedulelessons", dses.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 203);
            }
        }
        strsql = "delete tblexamschedulelessons where intexamid=" + e.Item.Cells[0].Text;
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);

        search(1);
    }
    protected void btnsave2_Click(object sender, EventArgs e)
    {
        trexamgrid.Visible = true;
        trexamtype.Visible = true;
        tr1tag.Visible = true;
      
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string strsql = "delete tblexamschedule where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedule", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),203);

        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);

        strsql = "select intid from tblschoolsetseating where intexamid=" + item.Cells[0].Text;
        DataAccess dass = new DataAccess();
        DataSet dsss = new DataSet();
        dsss = dass.ExceuteSql(strsql);
        if (dsss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsss.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsetseating", dsss.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 203);
            }
        }
        strsql = "delete tblschoolsetseating where intexamid=" + item.Cells[0].Text;
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);

        strsql = "select intid from tblexamschedulelessons where intexamid=" + item.Cells[0].Text;
        DataAccess daes = new DataAccess();
        DataSet dses = new DataSet();
        dses = daes.ExceuteSql(strsql);
        if (dsss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsss.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedulelessons", dses.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 203);
            }
        }
        strsql = "delete tblexamschedulelessons where intexamid=" + item.Cells[0].Text;
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        search(1);
    }
   
    protected void dgexam_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("viewpopup.aspx?hid=" + e.Item.Cells[0].Text);
    }
}

