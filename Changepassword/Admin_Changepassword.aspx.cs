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

public partial class Changepassword_Admin_Changepassword : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da = new DataAccess();
    public DataSet ds = new DataSet();
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstafftype();
            filldepartment();
            fillstaff();
            trstudentdetails.Visible = false;
        }        
    }
    protected void fillstafftype()
    {
        strsql = " select strstafftype from tblstafftype";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstafftype.DataSource = ds;
        ddlstafftype.DataTextField = "strstafftype";
        ddlstafftype.DataValueField = "strstafftype";
        ddlstafftype.DataBind();
    }
    protected void filldepartment()
    {
        strsql = "select * from tbldepartment where intschool="+Session["SchoolID"];
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "strdepartmentname";
        ddldepartment.DataValueField = "intid";
        ddldepartment.DataBind();
        ddldepartment.Items.Insert(0, "All");
    }
    protected void fillstaff()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as studentname from tblemployee where intschool=" + Session["SchoolID"]+" and strtype='"+ddlstafftype.SelectedValue+"'";
        if (ddldepartment.SelectedIndex > 0)
        {
            strsql += " and intdepartment="+ddldepartment.SelectedValue;
        }
        ds = da.ExceuteSql(strsql);
        ddlstaff.DataSource = ds;
        ddlstaff.DataTextField = "studentname";
        ddlstaff.DataValueField = "intid";
        ddlstaff.DataBind();
        ddlstaff.Items.Insert(0, "-Select-");
    }
    protected void fillclass()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strstandard+' - '+strsection as class from tblstudent where intschool="+Session["SchoolID"]+" group by strstandard+' - '+strsection";
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataValueField = "class";
        ddlclass.DataTextField = "class";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
    }
    protected void fillstudent()
    {
        try
        {
            if (ddlclass.SelectedIndex > 0)
            {
                da = new DataAccess();
                ds = new DataSet();
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as studentname from tblstudent where intschool = " + Session["SchoolID"] + " and strstandard+' - '+strsection = '" + ddlclass.SelectedValue + "'";
                ds = da.ExceuteSql(strsql);
                ddlstudent.DataSource = ds;
                ddlstudent.DataTextField = "studentname";
                ddlstudent.DataValueField = "intid";
                ddlstudent.DataBind();
                ddlstudent.Items.Insert(0, "-Select-");
            }
            else
            {
                ddlstudent.Items.Clear();
                ddlstudent.Items.Insert(0, "-Select-");
            }
        }
        catch { }
    }
    protected void ddlstafftype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaff();
        hideviewtrpassword();
    }
    protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaff();
        hideviewtrpassword();
    }
    protected void btnChangepwd_Click(object sender, EventArgs e)
    {
        if (ddlstaff.SelectedIndex > 0 || ddlstudent.SelectedIndex > 0)
        {
            if (Page.IsValid)
            {
                da = new DataAccess();
                ds = new DataSet();
                if (ddlpatrontype.SelectedValue == "Staff")
                {
                    strsql = "update tblemployee set strpassword = '" + txtnewpassword.Text + "' where intid = " + ddlstaff.SelectedValue;
                    Functions.UserLogs(Session["UserID"].ToString(), "tblemployee", ddlstaff.SelectedValue, "Updated", Session["PatronType"].ToString(),Session["SchoolID"].ToString(),327);
                }
                else if (ddlpatrontype.SelectedValue == "Student")
                {
                    strsql = "update tblstudent set strstudentpassword = '" + txtnewpassword.Text + "' where intid = " + ddlstudent.SelectedValue;
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", ddlstudent.SelectedValue, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),327);
                }
                else if (ddlpatrontype.SelectedValue == "Parents")
                {
                    strsql = "update tblstudent set strparentpassword = '" + txtnewpassword.Text + "' where intid = " + ddlstudent.SelectedValue;
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", ddlstudent.SelectedValue, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),327);
                }
                else
                {
                    strsql = "";
                }
                ds = da.ExceuteSql(strsql);
                msgbox.alert("Password has been changed");
            }
        }        
    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        hideviewtrpassword();
    }
    protected void ddlpatrontype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Staff")
        {
            trstudentdetails.Visible = false;
            trstaffdetailes.Visible = true;
            fillclass();
            fillstudent();
            fillstafftype();
            filldepartment();
            fillstaff();
            hideviewtrpassword();
        }
        else
        {
            trstaffdetailes.Visible = false;
            trstudentdetails.Visible = true;
            fillclass();
            fillstudent();
            fillstafftype();
            filldepartment();
            fillstaff();
            hideviewtrpassword();
        }
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        hideviewtrpassword();
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        hideviewtrpassword();
    }
    protected void hideviewtrpassword()
    {
        if (ddlstudent.SelectedIndex > 0 || ddlstaff.SelectedIndex > 0)
        {
            trchangepwd.Visible = true;
            trchangepwd2.Visible = true;
        }
        else
        {
            trchangepwd.Visible = false;
            trchangepwd2.Visible = false;
        }
    }
}
