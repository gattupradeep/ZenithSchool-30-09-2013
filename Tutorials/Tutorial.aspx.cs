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

public partial class Tutorials_Tutorial : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fillgrid();
           if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
            {
                fillclass();
                ddlclass.SelectedValue = Session["StudentClass"].ToString();
                ddlclass.Enabled = false;
                fillteacher();
                fillgrid();
                Response.Redirect("studenttutorial.aspx");
            }
            fillclass();
            ddlteacher.Items.Insert(0, "-Select-");
            ddlsubject.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(0, "-Select-");
            ddlunit.Items.Insert(0, "-Select-");
            ddllesson.Items.Insert(0, "-Select-");
            //txtdate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        }
    }
    protected void fillclass()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strstandard+' - '+strsection as class from tblstandard_section_subject where intschoolid=" + Session["SchoolID"] + " group by strstandard+' - '+strsection";
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataValueField = "class";
        ddlclass.DataTextField = "class";
        ddlclass.Items.Clear();
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
    }
    protected void fillteacher()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername, a.intid from tblemployee a,tblteachingclass b where b.intschool =" + Session["SchoolID"] + " and b.strteachclass='" + ddlclass.SelectedValue + "' and a.intid=b.intemployee group by a.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname";
        ds = da.ExceuteSql(strsql);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "teachername";
        ddlteacher.DataValueField = "intid";
        ddlteacher.Items.Clear();
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "-Select-");
    }
    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strsubject from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard ='" + ddlclass.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.Items.Clear();
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "-Select-");
    }
    protected void filltextbook()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + ddlclass.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
        ds = da.ExceuteSql(strsql);
        ddltextbook.DataSource = ds;
        ddltextbook.DataTextField = "strtextbookname";
        ddltextbook.DataValueField = "intid";
        ddltextbook.Items.Clear();
        ddltextbook.DataBind();
        ddltextbook.Items.Insert(0, "-Select-");
    }
    protected void fillunit()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strunitno from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' group by strunitno";
        ds = da.ExceuteSql(strsql);
        ddlunit.DataSource = ds;
        ddlunit.DataTextField = "strunitno";
        ddlunit.DataValueField = "strunitno";
        ddlunit.Items.Clear();
        ddlunit.DataBind();
        ddlunit.Items.Insert(0, "-Select-");
    }
    protected void filllesson()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strlessonname from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' and strunitno='" + ddlunit.SelectedValue + "' group by strlessonname";
        ds = da.ExceuteSql(strsql);
        ddllesson.DataSource = ds;
        ddllesson.DataTextField = "strlessonname";
        ddllesson.DataValueField = "strlessonname";
        ddllesson.Items.Clear();
        ddllesson.DataBind();
        ddllesson.Items.Insert(0, "-Select-");
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlclass.SelectedIndex > 0)
        {
            fillteacher();
            ddlsubject.Items.Clear();
            ddlsubject.Items.Insert(0,"-Select-");
            ddltextbook.Items.Clear();
            ddltextbook.Items.Insert(0,"-Select-");
            ddlunit.Items.Clear();
            ddlunit.Items.Insert(0, "-Select-");
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
        fillgrid();
    }
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlteacher.SelectedIndex > 0)
        {
            fillsubject();
            ddltextbook.Items.Clear();
            ddltextbook.Items.Insert(0, "-Select-");
            ddlunit.Items.Clear();
            ddlunit.Items.Insert(0, "-Select-");
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
        fillgrid();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            filltextbook();
            ddlunit.Items.Clear();
            ddlunit.Items.Insert(0, "-Select-");            
        }
        fillgrid();
    }
    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltextbook.SelectedIndex > 0)
        {
            fillunit();
            ddllesson.Items.Clear();
            ddllesson.Items.Insert(0, "-Select-");
        }
        fillgrid();
    }
    protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlunit.SelectedIndex > 0)
        {
            filllesson();
        }
        fillgrid();
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select a.*,convert(varchar(10),dtpublishdate,111) as publishdate,convert(varchar(10),dtdate,111) as date,b.strfirstname +' '+strmiddlename+' '+strlastname as teachername,c.strtextbookname from tbltutorial a,tblemployee b,tblschooltextbook c where a.intschool =" + Session["SchoolID"] + " and b.intid = a.intteacher and c.intid=a.inttextbook ";
        if (txtdate.Text != "")
        {
            strsql += " and dtdate='" + txtdate.Text.Trim() + "'";
        }
        if (txtpublishdate.Text != "")
        {
            strsql += " and dtpublishdate='" + txtpublishdate.Text.Trim() + "'";
        }
        if (ddlclass.SelectedIndex > 0)
        {
            strsql += " and a.strclass='"+ddlclass.SelectedValue+"'";
        }
        if (ddlteacher.SelectedIndex > 0)
        {
            strsql += " and a.intteacher='" + ddlteacher.SelectedValue + "'";
        }
        if (ddlsubject.SelectedIndex > 0)
        {
            strsql += " and a.strsubject='"+ddlsubject.SelectedValue+"'";
        }
        if (ddltextbook.SelectedIndex > 0)
        {
            strsql += " and a.inttextbook='" + ddltextbook.SelectedValue + "'";
        }
        if (ddlunit.SelectedIndex > 0)
        {
            strsql += " and a.strunit='" + ddlunit.SelectedValue + "'";
        }
        if (ddllesson.SelectedIndex > 0)
        {
            strsql += " and a.strlesson='" + ddllesson.SelectedValue + "'";
        }
        strsql = strsql + " order by dtpublishdate desc";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgtutorial.DataSource = ds;
            dgtutorial.DataBind();
            tr1.Visible = false;
            trdgtutorial.Visible = true;
        }
        else
        {
            tr1.Visible = true;
            trdgtutorial.Visible = false;
            errormessage.Text = "No Class notes assigned for selected criteria ";
        }
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void txtpublishdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}