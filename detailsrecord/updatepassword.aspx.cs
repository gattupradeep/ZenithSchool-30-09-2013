using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class detailsrecord_updatepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnupdatepassword_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string strsql = "select intid,strfirstname from tblstudent";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string strname = "";
            if (ds.Tables[0].Rows[i]["strfirstname"].ToString().IndexOf(" ") > -1)
                strname = ds.Tables[0].Rows[i]["strfirstname"].ToString().Substring(0, ds.Tables[0].Rows[i]["strfirstname"].ToString().IndexOf(" "));
            else
                strname = ds.Tables[0].Rows[i]["strfirstname"].ToString();

            da = new DataAccess();
            strsql = "update tblstudent set strstudentusername='" + strname + "' + ltrim(str(intid)),strstudentpassword=(SELECT ltrim(substring(str(floor(RAND((DATEPART(mm, GETDATE()) * 100000)+ (DATEPART(ss, GETDATE()) * 1000 )+ DATEPART(ms, GETDATE())) * 1000000000)),1,7))) where intid=" + ds.Tables[0].Rows[i]["intid"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", ds.Tables[0].Rows[i]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),326);

            da.ExceuteSqlQuery(strsql);

            da = new DataAccess();
            strsql = "update tblstudent set strparentusername='" + strname + "' + ltrim(str(intid)),strparentpassword=(SELECT ltrim(substring(str(floor(RAND((DATEPART(mm, GETDATE()) * 100000)+ (DATEPART(ss, GETDATE()) * 1000 )+ DATEPART(ms, GETDATE())) * 1000000000)),1,7))) where intid=" + ds.Tables[0].Rows[i]["intid"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", ds.Tables[0].Rows[i]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),326);

            da.ExceuteSqlQuery(strsql);
        }
    }

    protected void btnsendemail_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string str2 = "select strparentsemailid,strfatherorguardname,strparentusername,strparentpassword,strstudentusername,strstudentpassword,strschoolname, strsubdomain from tblstudent a, tblschool b where a.intschool=b.intid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str2);

        if (ds.Tables[0].Rows.Count > 0)
        {
            string msg = "";
            msg = msg + "    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"700\">";
            msg = msg + "        <tr>";
            msg = msg + "            <td style=\"width: 125px; height: 75px\" align=\"left\"><img src=\"http://www.theschools.in/Media/Images/emaillogotop.png\" border=\"0\" alt=\"logo\" /></td>";
            msg = msg + "            <td style=\"width: 575px; height: 75px; font-family: Arial Black; font-size: 20px\" align=\"left\"></td>";
            msg = msg + "        </tr>";
            msg = msg + "        <tr>";
            msg = msg + "            <td colspan=\"2\" style=\"width: 700px; padding-top: 20px; padding-bottom: 20px; text-align: justify; line-height: 25px; font-family: Tahoma; font-size: 12px\">";
            msg = msg + "Dear " + ds.Tables[0].Rows[0]["strfatherorguardname"].ToString() + "<br/>";
            msg = msg + "Welcome to " + ds.Tables[0].Rows[0]["strschoolname"].ToString() + " web portal<br/>";
            msg = msg + "For your convenience, here are your login details for yourself and your ward<br/><br/>";
            msg = msg + "Your school site :<a href=\"http://" + ds.Tables[0].Rows[0]["strsubdomain"].ToString() + ".theschools.in\">http://" + ds.Tables[0].Rows[0]["strsubdomain"].ToString() + ".theschools.in</a><br />";
            msg = msg + "Parent login credentials : <br/>";
            msg = msg + "Username : " + ds.Tables[0].Rows[0]["strparentusername"].ToString() + "<br/>";
            msg = msg + "Password : " + ds.Tables[0].Rows[0]["strparentpassword"].ToString() + "<br/><br/>";
            msg = msg + "Student login credentials : <br/>";
            msg = msg + "Username : " + ds.Tables[0].Rows[0]["strstudentusername"].ToString() + "<br/>";
            msg = msg + "Password : " + ds.Tables[0].Rows[0]["strstudentpassword"].ToString() + "<br/><br/>";
            msg = msg + "Should you need any assistance when you're on the website, please mail us on <a href=\"mail: support@theschools.in>TheSchools.in - Support Team</a><br /><br />";
            msg = msg + "Thanks<br/>";
            msg = msg + "Best Regards,<br/>";
            msg = msg + "" + ds.Tables[0].Rows[0]["strschoolname"].ToString() + " Management<br/>";
            msg = msg + "            </td>";
            msg = msg + "        </tr>";
            msg = msg + "        <tr>";
            msg = msg + "            <td colspan=\"2\" style=\"width: 700px; height: 75px\" align=\"center\">";
            msg = msg + "                <img src=\"http://www.theschools.in/Media_front/Images/logo.png\" border=\"0\" alt=\"logo\" /><br /><br />";
            msg = msg + "            </td>";
            msg = msg + "        </tr>";
            msg = msg + "    </table>";
            Functions.Sendmail(ds.Tables[0].Rows[0]["strparentsemailid"].ToString(), "support@theschools.in", "Login Credentials", msg);
        }
    }
}
