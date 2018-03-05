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

public partial class student_viewhomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
        {
            Response.Redirect("view_student_homework.aspx");
        }
        if (!IsPostBack)
        {
          
            fillstandard();
            ddlsubject.Items.Insert(0, "--Select--");
            ddlteacher.Items.Insert(0, "--Select--");
            if (Request["hid1"] == null)
            {
                try
                {
                    if (Session["SearchStudentStandard"] != null)
                    {
                        ddlstandard.SelectedValue = Session["SearchStudentStandard"].ToString();
                        fillbystandard();
                        fillgrid(1);
                    }
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
                    if (Session["SearchStudentPublish"] != null)
                    {
                        ddlteacher.SelectedValue = Session["SearchStudentPublish"].ToString();
                        fillbypublish();
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
    protected void fillstandard()
    {
        string str;
        str = "select strstandard from tblhomeworktopics where intschool=" + Session["SchoolID"].ToString() + " group by strstandard ";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlstandard.Items.Insert(0, li);
    }
    protected void fillteacher()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select c.intid,c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname";
        str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
        str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
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
        //ListItem li = new ListItem("All", "0");
        ddlteacher.Items.Insert(0, "All");
    }
    protected void fillsubject()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select b.strsubject as strsubject";
        str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
        str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString() + " group by strsubject";
        ds = da.ExceuteSql(str);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "All");
     }

   
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillgrid(1);
            fillsubject();
            fillteacher();
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
        DataSet ds, ds1 = new DataSet();
        str = "select a.inthwfrom,a.intid, c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname,";
        str = str + " b.strsubject,a.strtopic,a.strdescription,convert(varchar(10),dtassigndate,103) as strassigndate,";
        str = str + " convert(varchar(10),dtduedate,103) as strduedate,convert(varchar(10),dtpublishdate,103) as strpublishdate";
        str = str + " from tblhomework a, tblhomeworktopics b, tblemployee c";
        str = str + " where b.intid=a.inttopic and a.intemployee=c.intid and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
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
            errormessage.Text = "No homework assigned for selected criteria ";
            trsearch.Visible = true;
            trdghomework.Visible = false;

        }
      }
        catch
        {
        }
    }

    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        fillgrid(0);
        fillbyteacher();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid(0);
        fillteacher();
        ddlteacher.SelectedIndex = 0;
        fillbysubject();
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
        Response.Redirect("homeworkdetails.aspx?hid1=" + e.Item.Cells[0].Text + "&hwf=" + e.Item.Cells[1].Text);
    }
    protected void fillbystandard()
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillgrid(1);
            fillsubject();
            fillteacher();
        }
        else
        {
            ddlsubject.Items.Clear();
            ddlsubject.Items.Insert(0, "--Select--");
            ddlteacher.Items.Clear();
            ddlteacher.Items.Insert(0, "--Select--");
            fillgrid(1);
        }
        Session["SearchStudentStandard"] = ddlstandard.SelectedValue;
    }
    protected void fillbysubject()
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            fillgrid(1);
            fillteacher();
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
            //assigndate();
            //publishdate();
            //duedate();
            fillgrid(1);

        }
        else
        {
           
            fillgrid(1);
        }
        Session["SearchStudentTeacher"] = ddlteacher.SelectedValue;
    }
    protected void fillbyassign()
    {
        if (txtdate.Text!="")
        {
            //publishdate();
            //duedate();
            fillgrid(1);
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentAssign"] = ddlteacher.SelectedValue;
    }
    protected void fillbypublish()
    {
        if (txtpublish.Text!="")
        {
            //duedate();
            fillgrid(1);
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentPublish"] = ddlteacher.SelectedValue;
    }
    protected void fillbydue()
    {
        if (txtdue.Text!="")
        {
            fillgrid(1);
        }
        else
        {

            fillgrid(1);
        }
        Session["SearchStudentDue"] = ddlteacher.SelectedValue;
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
    protected void txtpublish_TextChanged(object sender, EventArgs e)
    {
        fillgrid(1);
        fillbypublish();
        
    }
}