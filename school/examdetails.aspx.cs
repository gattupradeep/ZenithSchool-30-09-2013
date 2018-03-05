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

public partial class school_examdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["PatronType"].ToString() != "Admin" && Session["PatronType"].ToString() != "Super Admin")
            {
                btnaddnew.Visible = false;
                std1edit.Visible = false;
            }
        }
        catch
        {
            Response.Redirect("../login.aspx");
        }
        if (!IsPostBack)
        {
            fillstandard1();
            fillexamtype1();
            fillgrid1();
        }
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillexamtype1();
        fillgrid1();
    }

    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid1();
    }

    protected void dgexamsettings1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgexamsettings1.CurrentPageIndex = e.NewPageIndex;
        fillgrid1();
    }

    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("examdetailsettings.aspx");
    }

    protected void std1edit_Click(object sender, EventArgs e)
    {
        Session["examstandard"] = ddlstandard.SelectedValue;
        Session["examtype"] = ddlexamtype.SelectedValue;
        Response.Redirect("Editexamdetails.aspx");

    }

    protected void fillstandard1()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select strclass from tblschoolexamsettings where intschoolid='" + Session["SchoolID"].ToString() + "' group by strclass";
        ds = da.ExceuteSql(sql);

        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataSource = ds;
        ddlstandard.DataBind();
    }

    protected void fillexamtype1()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strexamtype from tblschoolexamsettings where intschoolid='" + Session["SchoolID"].ToString() + "' and strclass='" + ddlstandard.SelectedValue + "' group by strexamtype";
        ds = da.ExceuteSql(sql);
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataBind();
    }

    protected void fillgrid1()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select ltrim(str(timedurationhour))+ ':' + ltrim(str(timedurationmin))  as dttimeduration, * from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "' order by strclass,strexamtype";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgexamsettings1.DataSource = ds;
            dgexamsettings1.DataBind();
            dgexamsettings1.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            Response.Redirect("examdetailsettings.aspx");
        }
    } 
    
}
