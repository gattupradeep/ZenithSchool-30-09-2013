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

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (Session["PatronType"].ToString() == "Admin" || Session["PatronType"].ToString() == "Parents" || Session["PatronType"].ToString() == "Students" || Session["PatronType"].ToString() == "Teaching Staffs" || Session["PatronType"].ToString() == "Non Teaching Staff")
                {
                    Session.Abandon();
                    HttpCookie myCookie = new HttpCookie("logintype");
                    myCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    HttpCookie myCookie = new HttpCookie("logintype");
                    myCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("login.aspx");
                }
            }
        }
        catch { }
    }
}
