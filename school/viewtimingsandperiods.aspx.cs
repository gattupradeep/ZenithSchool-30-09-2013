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

public partial class school_viewtimingsandperiods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["PatronType"].ToString() != "Admin" && Session["PatronType"].ToString() != "Super Admin")
                btnedit.Visible = false;
        }
        catch
        {
            Response.Redirect("../login.aspx");
        }
        if (!IsPostBack)
        {
            setnext();
            filltimings();
            
        }
        trassembly.Visible = false;
       
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("timingsandperiods.aspx?sid=" + Session["SchoolID"].ToString());
        
    }   

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select * from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/timingsandperiods.aspx");
    }

    protected void filltimings()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tbltimingsandperiods where intschoolid=" + Session["SchoolID"];
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstarttime.Text = ds.Tables[0].Rows[0]["strstarttime"].ToString();
            lblschoolendtime.Text = ds.Tables[0].Rows[0]["strendtime"].ToString();
            lblassembly.Text = ds.Tables[0].Rows[0]["strassembly"].ToString();
            lblassemblyend.Text = ds.Tables[0].Rows[0]["strassemblyend"].ToString();
            lblfirstbell.Text = ds.Tables[0].Rows[0]["strfirstbell"].ToString();
            lblsecondbell.Text = ds.Tables[0].Rows[0]["strsecondbell"].ToString();
                     
           
        }

        sql = "select *,replace(strperiod,' Period','') as strper from tblschoolperiods where intschoolid=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        
    }
}
