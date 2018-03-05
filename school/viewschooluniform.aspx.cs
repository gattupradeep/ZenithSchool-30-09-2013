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

public partial class school_viewschooluniform : System.Web.UI.Page
{
    //public string str;
    //public DataSet ds;
    //public DataAccess da = new DataAccess();

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
            fillclasstype();
            fillgrid();
        }
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("school_uniform_details.aspx?id=" + Session["SchoolID"].ToString());
    }

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select * from tblschooluniform where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/school_uniform_details.aspx");
    }

    protected void fillclasstype()
    {
        try
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            sql = "select strstandard from tblschoolstandard where intschoolid=" + Session["SchoolID"] + " group by strstandard";
            ds = da.ExceuteSql(sql);

            ddlclass.DataSource = ds;
            ddlclass.DataTextField = "strstandard";
            ddlclass.DataValueField = "strstandard";
            ddlclass.DataBind();
            //ddlclass.Items.Insert(0, "-Select-");
        }
        catch { }
    }    

    protected void fillgrid()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from dbo.tblschooluniform where strstandard  like '%" + ddlclass.SelectedValue + ",%' or strstandard in('" + ddlclass.SelectedValue + "') or strstandard like '%," + ddlclass.SelectedValue + "%' and intschoolid=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dguniformboysj.DataSource = ds;
        dguniformboysj.DataBind();

        sql = "select * from dbo.tblschooluniform where strstandard like '%" + ddlclass.SelectedValue + ",%' or strstandard in('" + ddlclass.SelectedValue + "') or strstandard like '%," + ddlclass.SelectedValue + "%' and intschoolid=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dguniformgirlsj.DataSource = ds;
        dguniformgirlsj.DataBind();
    }
}
