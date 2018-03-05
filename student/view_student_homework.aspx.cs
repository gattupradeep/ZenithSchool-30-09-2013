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

public partial class student_view_student_homework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid(1);
            fillsubject();
            fillteacher();
            //tr1.Visible = false;
            trsearch.Visible = true;
           if (Request["hid"] == null)
            {
                try
                {
                   if (Session["SearchStudentSubject"] != null)
                    {
                        ddlsubject.SelectedValue = Session["SearchStudentSubject"].ToString();
                        fillbysubject();
                        fillgrid(1);
                    }
                    if (Session["SearchStudentTeacher"] != null)
                    {
                        ddlteacher.SelectedValue = Session["SearchStudentTeacher"].ToString();
                        fillbyteacher();
                        fillgrid(1);
                    }
                    if (Session["SearchStudentAssign"] != null)
                    {
                        ddlteacher.SelectedValue = Session["SearchStudentAssign"].ToString();
                        fillbyassign();
                        fillgrid(1);
                    }
                    if (Session["SearchStudentDue"] != null)
                    {
                        ddlteacher.SelectedValue = Session["SearchStudentDue"].ToString();
                        fillbydue();
                        fillgrid(1);
                    }
                }
                catch { }
            }
        }
        
        
    }

    protected void fillteacher()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select c.intid,c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname";
        str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
        str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + Session["StudentClass"].ToString() + "' and a.intschool=" + Session["SchoolID"].ToString() ;
        if (ddlsubject.SelectedValue != "All")
        {
            str += " and b.strsubject='" + ddlsubject.SelectedValue + "'";
        }
        str += " group by c.intid,strfirstname,strmiddlename,strlastname";
        ds = da.ExceuteSql(str);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "strstaffname";
        ddlteacher.DataValueField = "intid";
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "All");
        //ListItem li = new ListItem("All", "0");
        //ddlteacher.Items.Insert(0, li);
    }
    protected void fillsubject()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select b.strsubject";
        str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
        str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + Session["StudentClass"].ToString() + "' and a.intschool=" + Session["SchoolID"].ToString() + " group by strsubject";
        ds = da.ExceuteSql(str);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "All");
        //ListItem li = new ListItem("0", "All");
        //ddlsubject.Items.Insert(0, li);
    }
    //protected void assigndate()
    //{
    //    string str;
    //    DataAccess da = new DataAccess();
    //    DataSet ds = new DataSet();
    //    str = "select convert(varchar(10),a.dtassigndate,103) as strassigndate";
    //    str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
    //    str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + Session["StudentClass"].ToString() + "' and a.intschool=" + Session["SchoolID"].ToString() + " group by  a.dtassigndate";
    //    ds = da.ExceuteSql(str);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        txtdate.Text = ds.Tables[0].Rows[0]["strassigndate"].ToString();
    //    }
    //}
    //protected void duedate()
    //{
    //    string str;
    //    DataAccess da = new DataAccess();
    //    DataSet ds = new DataSet();
    //    str = "select convert(varchar(10),a.dtduedate,103) as strduedate";
    //    str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
    //    str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + Session["StudentClass"].ToString() + "' and a.intschool=" + Session["SchoolID"].ToString() + " group by  a.dtduedate";
    //    ds = da.ExceuteSql(str);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        txtdue.Text = ds.Tables[0].Rows[0]["strduedate"].ToString();
    //    }
    //}
    protected void fillgrid(int frm)
    {
        try
        {
            string str;
            DataAccess da = new DataAccess();
            DataSet ds, ds1 = new DataSet();
            str = "select a.inthwfrom, a.intid, c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname,";
            str = str + " b.strsubject,a.strtopic,a.strdescription,convert(varchar(10),dtassigndate,103) as strassigndate,";
            str = str + " convert(varchar(10),dtduedate,103) as strduedate,convert(varchar(10),dtpublishdate,103) as strpublishdate";
            str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
            str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + Session["StudentClass"].ToString() + "' and a.intschool=" + Session["SchoolID"].ToString() + " and  convert(varchar(10),a.dtpublishdate,111)<=convert(varchar(10),getdate(),111)";

            if (ddlteacher.SelectedIndex > 0)
                str = str + " and a.intemployee=" + ddlteacher.SelectedValue;
            if (ddlsubject.SelectedIndex > 0)
                if (txtdate.Text != "")
                    str = str + " and dtassigndate='" + txtdate.Text.Trim() + "'";
            if (txtdue.Text != "")
                str = str + " and dtduedate='" + txtdue.Text.Trim() + "'";
            str = str + " order by dtpublishdate desc";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dghomework.DataSource = ds;
                dghomework.DataBind();
                trsearch.Visible = true;
                trgrid.Visible = true;
                tr1.Visible = false;
               
                    
                
            }
            else
            {
                errormessage.Text = "No homework assigned for selected criteria";
                trsearch.Visible = true;
                tr1.Visible = true;
                trgrid.Visible = false;

            }
        }
        catch
        {
        }
    }

    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlsubject.SelectedIndex = 0;
        fillgrid(0);
        fillbyteacher();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid(0);
        fillteacher();
        fillbysubject();
        ddlteacher.SelectedIndex = 0;
    }

   protected void dghomework_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((ImageButton)e.Item.Cells[1].FindControl("delButton")).Attributes.Add("onclick", "return confirm('The selected will be permanently deleted!');");
        }
    }

    protected void dghomework_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("homeworkdetails.aspx?hid=" + e.Item.Cells[0].Text + "&hwf=" + e.Item.Cells[1].Text);
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid(1);
        fillbyassign();
    }
    protected void txtdue_TextChanged(object sender, EventArgs e)
    {
        fillgrid(1);
        fillbydue();
    }
   
    protected void fillbysubject()
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            fillgrid(1);
            fillteacher();
            //assigndate();
            //duedate();
        }
        else
        {
            ddlteacher.Items.Clear();
            ddlteacher.Items.Insert(0, "--Select--");
            fillgrid(1);
        }
        Session["SearchStudentSubject"] = ddlsubject.SelectedValue;
    }
    protected void fillbyteacher()
    {
        if (ddlteacher.SelectedIndex > 0)
        {
            fillgrid(1);
            //assigndate();
            //duedate();
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentTeacher"] = ddlteacher.SelectedValue;
    }
    protected void fillbyassign()
    {
        if (txtdate.Text != "")
        {
            fillgrid(1);
            //duedate();
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentAssign"] = ddlteacher.SelectedValue;
    }
    protected void fillbydue()
    {
        if (txtdue.Text != "")
        {
            fillgrid(1);
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentDue"] = ddlteacher.SelectedValue;
    }
}


