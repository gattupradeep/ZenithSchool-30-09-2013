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

public partial class school_profile : System.Web.UI.Page
{
    public string str;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

        filldetails();
    }

    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        str = "select a.*,strschooltype,countryname,strstate,city from tblschool a, tblschooltype b ,tblcountry c,tblstate d, tblcity e where a.intschooltype=b.intid and a.intcountry=c.id and a.intstate=d.id and a.intcity=e.id and a.intid=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblschoolname.Text = ds.Tables[0].Rows[0]["strschoolname"].ToString();
            lbladdress.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
            lblcountry.Text = ds.Tables[0].Rows[0]["countryname"].ToString() + ", " + ds.Tables[0].Rows[0]["strstate"].ToString() + ", " + ds.Tables[0].Rows[0]["city"].ToString() + ", " + ds.Tables[0].Rows[0]["strzipcode"].ToString();
            lblphone.Text = ds.Tables[0].Rows[0]["strphoneno"].ToString();
            lblemailid.Text = ds.Tables[0].Rows[0]["stremailid"].ToString();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../school/Editprofile.aspx");
    }
}
