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

public partial class timetable_viewmenutimetable : System.Web.UI.Page
{
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
         {
            //if (Session["sid"] != null)
            // {
                 //ddlday.SelectedValue = Session["day"].ToString();
                 search();
             //}
         }
         if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || Session["PatronType"].ToString() == "Teaching Staffs")
         {
             trsidemenu.Visible = false;
         }
    }

    protected void search()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;

        if (ddlday.SelectedValue == "All")
        {
            //str = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString();
            //if (ddlsearch.SelectedIndex > 0)
            //{
                str = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString() + " and strtype='" + ddlsearch.SelectedValue + "'";
            //}
        }

        else
        {
            //str = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString() + " and strday='" + ddlday.SelectedValue + "'";
            //if (ddlsearch.SelectedIndex > 0)
            //{
                str = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString() + " and strtype='" + ddlsearch.SelectedValue + "' and strday='" + ddlday.SelectedValue + "'";
            //}
        }
        ds = da.ExceuteSql(str);
        dglunchmenu.DataSource = ds;
        dglunchmenu.DataBind();
        if (ddlsearch.SelectedValue == "Lunch")
        {
            dglunchmenu.Columns[4].Visible = false;
            dglunchmenu.Columns[5].Visible = false;
            dglunchmenu.Columns[6].Visible = true;
            dglunchmenu.Columns[7].Visible = true;
            dglunchmenu.Columns[8].Visible = true;
        }
        else if (ddlsearch.SelectedValue == "Breakfast")
        {
            dglunchmenu.Columns[4].Visible = true;
            dglunchmenu.Columns[5].Visible = true;
            dglunchmenu.Columns[6].Visible = false;
            dglunchmenu.Columns[7].Visible = false;
            dglunchmenu.Columns[8].Visible = false;
        }
        else
        {

            dglunchmenu.Columns[4].Visible = true;
            dglunchmenu.Columns[5].Visible = true;
            dglunchmenu.Columns[6].Visible = true;
            dglunchmenu.Columns[7].Visible = true;
            dglunchmenu.Columns[8].Visible = true;
        }
    }
   protected void ddlday_SelectedIndexChanged(object sender, EventArgs e)
   {
       search();
   }
   protected void ddlsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        search();
    }
 }
