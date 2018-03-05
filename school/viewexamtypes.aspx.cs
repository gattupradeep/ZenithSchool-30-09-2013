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

public partial class school_viewexamtypes : System.Web.UI.Page
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
            fillexamtypes();
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("assignexamtypes.aspx?sid=" + Session["SchoolID"].ToString());
    }

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select strexamtype from tblexamorder where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/assignexamtypes.aspx");
    }

    protected void fillexamtypes()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strexamtype from tblexamorder where intschoolid=" + Session["SchoolID"].ToString() + " order by intorderno";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            blexamtypes.DataSource = ds.Tables[0];
            blexamtypes.DataTextField = "strexamtype";
            blexamtypes.DataValueField = "strexamtype";
            blexamtypes.DataBind();
        }
        else
            Response.Redirect("../school/assignexamtypes.aspx");

    }
}
