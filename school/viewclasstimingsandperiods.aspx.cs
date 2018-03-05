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

public partial class school_viewclasstimingsandperiods : System.Web.UI.Page
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
            fillclass();
            filltimings();
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Session["ClassTimingsClassID"] = ddlclass.SelectedValue;
        Response.Redirect("classtimingsandperiods.aspx?sid=" + Session["SchoolID"].ToString());
    }

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tblclasstimings where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/classtimingsandperiods.aspx");
    }

    protected void filltimings()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tblclasstimings where strclass='" + ddlclass.SelectedValue + "' and intschoolid=" + Session["SchoolID"];
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlclass.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
            lblperiods.Text = ds.Tables[0].Rows[0]["intperiods"].ToString();
            lblintervals.Text = ds.Tables[0].Rows[0]["intintervals"].ToString();
            lblfirstinterval.Text = ds.Tables[0].Rows[0]["intfirstintervals"].ToString();
            lblsecondinterval.Text = ds.Tables[0].Rows[0]["intsecondintervals"].ToString();
            lbllunch.Text = ds.Tables[0].Rows[0]["intlunch"].ToString();
              
                     
        }
        sql = "select *,replace(strperiod,' Period','') as strper from tblschoolperiods where strclass='"+ddlclass.SelectedValue+"' and intschoolid=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstarttimings1.Text = ds.Tables[0].Rows[0]["strSTHH"].ToString() + " : " + ds.Tables[0].Rows[0]["strSTMM"].ToString();
            dlperiods.DataSource = ds;
            dlperiods.DataBind();
        }
        else
            Response.Redirect("classtimingsandperiods.aspx?sid=" + Session["SchoolID"].ToString());
    }
    private void fillclass()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strclass from tblclasstimings where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strclass";
        ddlclass.DataValueField = "strclass";
        ddlclass.DataBind();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        filltimings();
       

    }
}
