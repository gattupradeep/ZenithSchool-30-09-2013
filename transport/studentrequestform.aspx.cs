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

public partial class transport_studentrequestform : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldetails();
        }
    }
   protected void filldetails()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        if (btnok.Text == "0")
        {
            str = "select a.intadmitno,a.strstandard,a.strsection,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,convert(varchar(11),b.dtdate,103) as dtdate,b.strdestination,c.strroutename from tblstudent a,tblbusbooking b,tblroute c where a.intid=b.intstudentid and b.introuteid=c.intid and a.intschool=" + Session["Schoolid"].ToString() + " and a.intid=" + Session["studentid"].ToString();
            ds = da.ExceuteSql(str);
        }
        else
        {
            str = "select a.intadmitno,a.strstandard,a.strsection,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,convert(varchar(11),b.dtdate,103) as dtdate,b.strdestination,c.strroutename from tblstudent a,tblbusbooking b,tblroute c where a.intid=b.intstudentid and b.introuteid=c.intid and a.intschool=" + Session["Schoolid"].ToString() + " and a.intid=" + Session["studentid"].ToString();
            ds = da.ExceuteSql(str);
        }
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblsection.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
            lbldate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
            lbldestination.Text = ds.Tables[0].Rows[0]["strdestination"].ToString();
            lblroute.Text = ds.Tables[0].Rows[0]["strroutename"].ToString();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        da = new DataAccess();
        ds = new DataSet();
        str = "insert into tblstudentbuscalcelation(dtdate,stradmissionno,intapprove,strreason,intschool) values ('"+txtdate.Text+"','"+lbladmission.Text+"',0,'"+txtreason.Text+"',"+Session["Schoolid"].ToString()+")";
        da.ExceuteSqlQuery(str);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        filldetails();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
}
