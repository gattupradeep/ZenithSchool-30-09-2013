using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_usercontrol_topbanner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null && Request.Cookies["logintype"].Value == "Super Admin")
        {
            Response.Redirect("../login.aspx");
        }
        else if (Session["UserID"] == null && Request.Cookies["logintype"].Value != "Super Admin")
        {
            Response.Redirect("../Default.aspx");
        }
        else
        {
            Page.Title = "Zenith International School";
            //Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) - 60));
            if (!IsPostBack)
            {
                fillprofile();
            }
        }
    }
    protected void btndash_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["PatronType"].ToString() == "Students")
            Response.Redirect("../welcome/welcome_students.aspx");
        else if (Session["PatronType"].ToString() == "Parents")
            Response.Redirect("../welcome/welcome_students.aspx");
        else if (Session["PatronType"].ToString() == "Admin")
            Response.Redirect("../welcome/welcome_admin.aspx");
        else if (Session["PatronType"].ToString() == "Super Admin")
            Response.Redirect("../school/viewschooldetails.aspx");
        else if (Session["PatronType"].ToString() == "Teaching Staffs")
            Response.Redirect("../welcome/welcome_teacher.aspx");
        else if (Session["PatronType"].ToString() == "Non Teaching Staff")
            Response.Redirect("../welcome/welcome_teacher.aspx");            
    }
    protected void fillprofile()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string strsql = string.Empty;
        if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
        {
            logeduser.Src = "../images/student/"+Session["UserID"]+".jpg";
            strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as class from tblstudent where intid = " + Session["UserID"];
        }
        else if (Session["PatronType"] != "Super Admin" && Session["PatronType"] != "Students" && Session["PatronType"] != "Parents")
        {
            logeduser.Src = "../images/staff/" + Session["UserID"] + ".jpg";
            strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as name from tblemployee where intid= " + Session["UserID"];
        }
        else
        {
            logeduser.Src = "../images/whyschools.jpg";
            strsql = "select strschoolname as name from tblschool where intschoolid= " + Session["SchoolID"];
        }        
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
            {
                lblviewname.Text = ds.Tables[0].Rows[0][0].ToString();
                lblusertype.Text = Session["PatronType"].ToString();
                Label2.Text = "Class";
                Label5.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                lblviewname.Text = ds.Tables[0].Rows[0][0].ToString();
                lblusertype.Text = Session["PatronType"].ToString();
                Label2.Visible = false;
                Label5.Visible = false;
                tr1tag.Visible = false;
            }            
        }
        else
        {
            lblviewname.Text = ds.Tables[0].Rows[0][0].ToString();
            lblusertype.Text = Session["PatronType"].ToString();
            Label2.Visible = false;
            Label5.Visible = false;
        }
    }
}
