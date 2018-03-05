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

public partial class discipline_viewstudentsdiscipline : System.Web.UI.Page
{
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
    public SqlCommand RegCommand;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void fillgrid()
    {
        errormessage.Visible = false;
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select b.intid,a.strfirstname+' '+strmiddlename+' '+strlastname as name,b.strstandard,b.strsection,convert(varchar(10),dtdate,111) as dtdate,strdiscipline from tblstudent a,tbldiscipline b where a.intid=b.intstudent and b.intschool=" + Session["SchoolID"].ToString() + " and a.intid=" + Session["UserID"].ToString();
        if (txtfrom.Text != "" && txtTo.Text != "" && lblhidden.Text == "ok")
        {
            str += " and dtdate between  convert(datetime,'" + txtfrom.Text + "',103) and convert(datetime,'" + txtTo.Text + "',103)";

        }
        str += "order by dtdate desc";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgdiscipline.DataSource = ds;
            dgdiscipline.DataBind();
            dgdiscipline.Visible = true;
        }
        else
        {
            dgdiscipline.Visible = false;
            errormessage.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Not Assigne disciplines ')", true);
            errormessage.Text = "There is no Discipline entries found for the selected criteria";
        }
    }

    protected void bttnget_Click(object sender, EventArgs e)
    {
        lblhidden.Text = "ok";
        fillgrid();

    }
}

