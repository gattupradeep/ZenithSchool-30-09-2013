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

public partial class Changepassword_Changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void changepassword()
    {
        try
        {
            if (Page.IsValid)
            {
                DataAccess da1 = new DataAccess();
                DataSet ds1 = new DataSet();
                string sql = "";
                int flag=1;
                if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
                {
                    sql = "select strstudentpassword,strparentpassword from tblstudent where intid =" + Session["UserID"];
                }
                else
                {
                    sql = "select strpassword from tblemployee where intid=" + Session["UserID"];
                }                
                ds1 = da1.ExceuteSql(sql);
                if (Session["PatronType"] == "Students" )
                {
                    if (ds1.Tables[0].Rows[0]["strstudentpassword"].ToString() != txtoldpassword.Text)
                        msgbox.alert("Old password is incorrect");
                    else
                        flag = 0;

                }
                else if (Session["PatronType"] == "Parents")
                {
                    if (ds1.Tables[0].Rows[0]["strparentpassword"].ToString() != txtoldpassword.Text)
                        msgbox.alert("Old password is incorrect");
                    else
                        flag = 0;
                }
                else
                {
                    if (ds1.Tables[0].Rows[0]["strpassword"].ToString() != txtoldpassword.Text)
                        msgbox.alert("Old password is incorrect");
                    else
                        flag = 0;
                }
                if (flag == 0)
                {
                    DataAccess da = new DataAccess();
                    string strsql = "";
                    if (Session["PatronType"] == "Students")
                    {
                        strsql = "update tblstudent set strstudentpassword = '" + txtnewpassword.Text + "' where intid =" + Session["UserID"];
                        Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", Session["UserID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),326);
                    }
                    else if (Session["PatronType"] == "Parents")
                    {
                        strsql = "update tblstudent set strparentpassword = '" + txtnewpassword.Text + "' where intid =" + Session["UserID"];
                        Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", Session["UserID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),326);
                    }
                    else
                    {
                        strsql = "update tblemployee set strpassword = '" + txtnewpassword.Text + "' where intid=" + Session["UserID"];
                        Functions.UserLogs(Session["UserID"].ToString(), "tblemployee", Session["UserID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),326);
                    }
                    da.ExceuteSqlQuery(strsql);
                    msgbox.alert("Your password has been changed successfully");
                }
            }
        }
        catch { }
    }
    protected void btnChangepwd_Click(object sender, EventArgs e)
    {
        changepassword();
    }
}
