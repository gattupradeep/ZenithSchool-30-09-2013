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

public partial class admission_viewselected_rejected_studentlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            standard();
            fillstudent();
            filldetails();
        }
    }
    protected void standard()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionstudentmarks where dtdate='" + ddldate.SelectedValue + "' and  intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
            ddlstandard.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionstudentmarks where dtdate='" + ddldate.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
            ddlstandard.Items.Insert(1, "-All-");
        }
    }
    protected void date()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissionstudentmarks where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissionstudentmarks where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
    }
    protected void fillstudent()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstudent from tbladmissionattendance  where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlstudent.DataTextField = "strstudent";
            ddlstudent.DataValueField = "strstudent";
            ddlstudent.DataSource = ds;
            ddlstudent.DataBind();
            ddlstudent.Items.Insert(0, "-Select-");
            ddlstudent.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstudent from tbladmissionattendance  where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlstudent.DataTextField = "strstudent";
            ddlstudent.DataValueField = "strstudent";
            ddlstudent.DataSource = ds;
            ddlstudent.DataBind();
            ddlstudent.Items.Insert(0, "-Select-");
            ddlstudent.Items.Insert(1, "-All-");
        }
    }
    protected void filldetails()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name ,a.intapplication,a.strstandard,a.strresult from tbladmissionstudentmarks a,tblstudentadmission b where b.intadmissionapprove=" + ddlstatus.SelectedValue + " and b.intapprove=1 and a.intapplication=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //results approved
                if (ddlstatus.SelectedValue == "1")
                {
                    str = "select intid,intid as intapplication,str_firstname+' '+str_middlename+' '+str_lastname as name,str_standard from tblstudentadmission where intadmissionapprove=" + ddlstatus.SelectedValue + " and intapprove=1 and intschool=" + Session["SchoolID"].ToString();

                    if (ddlstandard.SelectedIndex > 1)
                    {
                        str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                    }
                    if (ddlstandard.SelectedValue == "-All-")
                    {
                        str = str + " and str_standard !=''";
                    }
                    if (ddlstudent.SelectedIndex > 1)
                    {
                        str = str + " and str_firstname+' '+str_middlename+' '+str_lastname='" + ddlstudent.SelectedValue + "'";
                    }
                    if (ddlstudent.SelectedValue == "-All-")
                    {
                        str = str + " and  str_firstname+' '+str_middlename+' '+str_lastname  !=''";
                    }
                }
                // results rejected
                if (ddlstatus.SelectedValue == "2")
                {
                    str = "select intid,intid as intapplication,str_firstname+' '+str_middlename+' '+str_lastname as name,str_standard from tblstudentadmission where intadmissionapprove=" + ddlstatus.SelectedValue + " and intapprove=1 and intschool=" + Session["SchoolID"].ToString();

                    if (ddlstandard.SelectedIndex > 1)
                    {
                        str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                    }
                    if (ddlstandard.SelectedValue == "-All-")
                    {
                        str = str + " and str_standard !=''";
                    }
                    if (ddlstudent.SelectedIndex > 1)
                    {
                        str = str + " and str_firstname+' '+str_middlename+' '+str_lastname='" + ddlstudent.SelectedValue + "'";
                    }
                    if (ddlstudent.SelectedValue == "-All-")
                    {
                        str = str + " and  str_firstname+' '+str_middlename+' '+str_lastname  !=''";
                    }

                }
            }
            ds = da.ExceuteSql(str);
            dgadmissionapproveresult.DataSource = ds;
            dgadmissionapproveresult.DataBind();
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name ,a.intapplication,a.strstandard,a.strresult from tbladmissionstudentmarks a,tblstudentadmission b where b.intadmissionapprove=" + ddlstatus.SelectedValue + " and b.intwaitlist=1 and a.intapplication=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // results approved in waitlisted approved 
                if (ddlstatus.SelectedValue == "1")
                {
                    str = "select intid,intid as intapplication,str_firstname+' '+str_middlename+' '+str_lastname as name,str_standard from tblstudentadmission where intadmissionapprove=" + ddlstatus.SelectedValue + " and intwaitlist=1 and intschool=" + Session["SchoolID"].ToString();

                    if (ddlstandard.SelectedIndex > 1)
                    {
                        str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                    }
                    if (ddlstandard.SelectedValue == "-All-")
                    {
                        str = str + " and str_standard !=''";
                    }
                    if (ddlstudent.SelectedIndex > 1)
                    {
                        str = str + " and str_firstname+' '+str_middlename+' '+str_lastname='" + ddlstudent.SelectedValue + "'";
                    }
                    if (ddlstudent.SelectedValue == "-All-")
                    {
                        str = str + " and  str_firstname+' '+str_middlename+' '+str_lastname  !=''";
                    }
                }
                if (ddlstatus.SelectedValue == "2")
                {
                    // results rejected in waitlisted approved
                    str = "select intid,intid as intapplication,str_firstname+' '+str_middlename+' '+str_lastname as name,str_standard from tblstudentadmission where intadmissionapprove=" + ddlstatus.SelectedValue + " and intwaitlist=1 and intschool=" + Session["SchoolID"].ToString();

                    if (ddlstandard.SelectedIndex > 1)
                    {
                        str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                    }
                    if (ddlstandard.SelectedValue == "-All-")
                    {
                        str = str + " and str_standard !=''";
                    }
                    if (ddlstudent.SelectedIndex > 1)
                    {
                        str = str + " and str_firstname+' '+str_middlename+' '+str_lastname='" + ddlstudent.SelectedValue + "'";
                    }
                    if (ddlstudent.SelectedValue == "-All-")
                    {
                        str = str + " and  str_firstname+' '+str_middlename+' '+str_lastname  !=''";
                    }

                }
            }
            ds = da.ExceuteSql(str);
            dgadmissionapproveresult.DataSource = ds;
            dgadmissionapproveresult.DataBind();
        }
    }
    protected void dgadmissionresult_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("view_admission_result.aspx?lid=" + e.Item.Cells[0].Text);
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        filldetails();
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        date();
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        date();
    }
}
