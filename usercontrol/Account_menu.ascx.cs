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

public partial class usercontrol_Account_menu : System.Web.UI.UserControl
{
    public string sqlstr, strmenus;
    public DataSet ds, ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
        fillmenu();
    }

    protected void fillmenu()
    {
        strmenus = "";
        DataAccess da = new DataAccess();
        StringBuilder sb = new StringBuilder();

        sqlstr = "select * from tblmenus where dropdownmenu=1 and parentmenu=71";
        ds1 = new DataSet();
        ds1 = da.ExceuteSql(sqlstr);
        int SPI = 0;
        try
        {
            SPI = int.Parse(Session["SProfileIndex"].ToString());
        }
        catch
        {
            SPI = 0;
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"app_leftmenu_width\">");
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (j < SPI)
                    sb.Append("<tr class=\"sidemenu1\"><td align=\"left\"><a href=\"" + ds1.Tables[0].Rows[j]["menuurl"].ToString() + "\" class=\"sidemenu\">" + ds1.Tables[0].Rows[j]["menuname"].ToString() + "</a></td></tr>");
            }
            sb.Append("</table> ");
        }
        strmenus = sb.ToString();
    }
}
