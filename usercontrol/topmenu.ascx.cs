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
using System.Text;

public partial class admin_usercontrol_topmenu : System.Web.UI.UserControl
{
    public string sqlstr,strmenus;
    public DataSet ds,ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
            fillmenu1();
    }

    protected void fillmenu()
    {
        strmenus = "";
        DataAccess da = new DataAccess();
        if(Session["PatronType"].ToString()=="Parents")
            sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbldefaultuserrights where  stafftype='Parents') order by intschoolid";
        else if (Session["PatronType"].ToString() == "Students")
            sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbldefaultuserrights where stafftype='Students') order by intschoolid";
        else if (Session["PatronType"].ToString() == "Admin")
            sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbldefaultuserrights where stafftype='Admin') order by intschoolid";
        else
        {
            sqlstr = "select menuid from tbluserrights where intstaffid=" + Session["UserID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
                sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString() + ") order by intschoolid";
            else
                sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbldefaultuserrights where stafftype='" + Session["PatronType"].ToString() + "') order by intschoolid";
        }
        StringBuilder sb = new StringBuilder();
        ds = new DataSet();
        ds = da.ExceuteSql(sqlstr);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sb.Append("<li>");
            if (ds.Tables[0].Rows[i]["menuurl"].ToString() == "")
                sb.Append("    <a href=\"#\">" + ds.Tables[0].Rows[i]["menuname"].ToString() + "</a>");
            else
                sb.Append("    <a href=\"" + ds.Tables[0].Rows[i]["menuurl"].ToString() + "\">" + ds.Tables[0].Rows[i]["menuname"].ToString() + "</a>");

            if (Session["PatronType"].ToString() == "Parents")
                sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbldefaultuserrights where stafftype='Parents') order by intschoolid";
            else if (Session["PatronType"].ToString() == "Students")
                sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbldefaultuserrights where stafftype='Students') order by intschoolid";
            else if (Session["PatronType"].ToString() == "Admin")
                sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbldefaultuserrights where stafftype='Admin') order by intschoolid";
            else
            {
                sqlstr = "select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString();
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(sqlstr);
                if (ds1.Tables[0].Rows.Count > 0)
                    sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString() + ") order by intschoolid";
                else
                    sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbldefaultuserrights where stafftype='" + Session["PatronType"].ToString() + "') order by intschoolid";
            }
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                sb.Append("    <span>");
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    //if (j == 10)
                    //    sb.Append("<br /><br />");
                    if (j == ds1.Tables[0].Rows.Count - 1)
                        sb.Append("<a href=\"" + ds1.Tables[0].Rows[j]["menuurl"].ToString() + "\">" + ds1.Tables[0].Rows[j]["menuname"].ToString() + "</a>");
                    else
                        sb.Append("<a href=\"" + ds1.Tables[0].Rows[j]["menuurl"].ToString() + "\">" + ds1.Tables[0].Rows[j]["menuname"].ToString() + "</a> | ");
                }
                sb.Append("    </span>");
            }
            sb.Append("</li>");
        }
        strmenus = sb.ToString();
    }

    protected void fillmenu1()
    {
        strmenus = "";
        DataAccess da = new DataAccess();
        sqlstr = "select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
            sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString() + ") order by intschoolid";
        else
            sqlstr = "select * from tblmenus where parentmenu=0 and menuid in (select menuid from tbldefaultuserrights where stafftype='" + Session["PatronType"].ToString() + "') order by menuid";

        StringBuilder sb = new StringBuilder();
        ds = new DataSet();
        ds = da.ExceuteSql(sqlstr);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sb.Append("<li class=\"haschildren\">");

            sqlstr = "select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString();
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
                sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbluserrights where intschoolid=" + Session["SchoolID"].ToString() + " and intstaffid=" + Session["UserID"].ToString() + ") order by intschoolid";
            else
                sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=" + ds.Tables[0].Rows[i]["menuid"].ToString() + " and menuid in (select menuid from tbldefaultuserrights where stafftype='" + Session["PatronType"].ToString() + "') order by intschoolid";

            ds1 = new DataSet();
            ds1 = da.ExceuteSql(sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[i]["menuurl"].ToString() == "")
                {
                    if (Session["PatronType"].ToString() == "Students")
                        sb.Append("<a class=\"\" href=\"#\">" + ds.Tables[0].Rows[i]["menuname"].ToString().Replace("Details Record", "Student Details") + "<span class=\"arrow\"></span></a>");
                    else
                        sb.Append("<a class=\"\" href=\"#\">" + ds.Tables[0].Rows[i]["menuname"].ToString() + "<span class=\"arrow\"></span></a>");
                }
                else
                {
                    if (Session["PatronType"].ToString() == "Students")
                        sb.Append("<a class=\"\" href=\"" + ds.Tables[0].Rows[i]["menuurl"].ToString() + "\">" + ds.Tables[0].Rows[i]["menuname"].ToString().Replace("Details Record", "Student Details") + "<span class=\"arrow\"></span></a>");
                    else
                        sb.Append("<a class=\"\" href=\"" + ds.Tables[0].Rows[i]["menuurl"].ToString() + "\">" + ds.Tables[0].Rows[i]["menuname"].ToString() + "<span class=\"arrow\"></span></a>");
                }

                sb.Append("<div style=\"z-index: 1; display: none;\" class=\"products submenu\">");
                sb.Append("	<ul>");
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    sb.Append("<li><img src=\"../images/icons/25x25/" + ds1.Tables[0].Rows[j]["menuid"].ToString() + ".png\" width=\"25\" height=\"25\"><a href=\"" + ds1.Tables[0].Rows[j]["menuurl"].ToString() + "\">" + ds1.Tables[0].Rows[j]["menuname"].ToString() + "</a></li>");
                }
                sb.Append("</ul>");
                sb.Append("</div>");
            }
            else
            {
                if (ds.Tables[0].Rows[i]["menuurl"].ToString() == "")
                {
                    if (Session["PatronType"].ToString() == "Students")
                        sb.Append("<a class=\"\" href=\"#\">" + ds.Tables[0].Rows[i]["menuname"].ToString().Replace("Details Record", "Student Details") + "</a>");
                    else
                        sb.Append("<a class=\"\" href=\"#\">" + ds.Tables[0].Rows[i]["menuname"].ToString() + "</a>");
                }
                else
                {
                    if (Session["PatronType"].ToString() == "Students")
                        sb.Append("<a class=\"\" href=\"" + ds.Tables[0].Rows[i]["menuurl"].ToString() + "\">" + ds.Tables[0].Rows[i]["menuname"].ToString().Replace("Details Record", "Student Details") + "</a>");
                    else
                        sb.Append("<a class=\"\" href=\"" + ds.Tables[0].Rows[i]["menuurl"].ToString() + "\">" + ds.Tables[0].Rows[i]["menuname"].ToString() + "</a>");
                }
            }
            sb.Append("</li>");
        }
        strmenus = sb.ToString();
    }

}
