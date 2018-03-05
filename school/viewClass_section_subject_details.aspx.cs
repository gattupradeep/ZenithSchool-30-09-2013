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

public partial class school_viewClass_section_subject_details : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public DataSet ds;

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
            fillclassdetails();
            fillsectiondetails();
            fillsubjectdetails();
            //filllanguagedetails();
            fillextracurriculardetails();
            fillsecondlang();
            ///fillthirdlang();
        }

    }

    protected void setnext()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "";
        sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/Class_Section_Subject_Details.aspx");
    }


    protected void fillclassdetails()
    {
        strsql = " select strstandard from tblschoolstandard  where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlclasses.DataSource = ds;
        dlclasses.DataBind();
    }
    protected void fillsectiondetails()
    {
        strsql = " select strsection from tblschoolsection where intschoolid=" + Session["SchoolID"].ToString() + " group by strsection";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlsection.DataSource = ds;
        dlsection.DataBind();
    }
    protected void fillsubjectdetails()
    {
        strsql = " select strsubject from tblschoolsubject where intschoolid=" + Session["SchoolID"].ToString() + " group by strsubject";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlsubject.DataSource = ds;
        dlsubject.DataBind();
    }
    //protected void filllanguagedetails()
    //{
    //    strsql = " select strlanguage2 from tblstandard_section_language where intschoolid=" + Session["SchoolID"].ToString() + " group by strlanguage2";
    //    da = new DataAccess();
    //    ds = new DataSet();
    //    ds = da.ExceuteSql(strsql);
    //    dllanguage.DataSource = ds;
    //    dllanguage.DataBind();
    //}
    protected void fillextracurriculardetails()
    {
        strsql = " select strextracurricular from tblschoolExtracurricular where intschoolid=" + Session["SchoolID"].ToString() + " group by strextracurricular";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlextra.DataSource = ds;
        dlextra.DataBind();
    }

    protected void fillsecondlang()
    {
        strsql = " select strlanguagename from tblschoollanguages where intschoolid=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlsecondlang.DataSource = ds;
        dlsecondlang.DataBind();
    }

    //protected void fillthirdlang()
    //{
    //    strsql = " select strlanguagename from tblschoolthirdlanguages where intschoolid=" + Session["SchoolID"].ToString();
    //    da = new DataAccess();
    //    ds = new DataSet();
    //    ds = da.ExceuteSql(strsql);
    //    dlthirdlang.DataSource = ds;
    //    dlthirdlang.DataBind();
    //}

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Class_Section_Subject_Details.aspx?sid=" + Session["SchoolID"].ToString());
    }
}
