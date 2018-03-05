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

public partial class school_searchpage : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
           // fillgrid();

    }
    protected void fillgrid()
    {
        try
        {
            strsql = "select * from tblroomcapacity where intschool=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
                dgsearch.DataSource = ds;
                dgsearch.DataBind();
        }
        catch { }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillsearch();        

    }
    protected void fillsearch()
    {
        try
        {
            strsql = "select * from tblroomcapacity  where intbuildname like '%" + txtsearch.Text + "%' or strclass like '%" + txtsearch.Text + "%' or strsection like '%" + txtsearch.Text + "%' or strfloor like '%" + txtsearch.Text + "%' or strroomno like '%" + txtsearch.Text + "%' or strcapacity like '%" + txtsearch.Text + "%'";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgsearch.DataSource = ds;
                dgsearch.DataBind();
            }
            else
            {
                msgbox.alert("Search result not found. Try another one");
                fillgrid();
                txtsearch.Text = "";
            }
        }
        catch { }
    }
}
