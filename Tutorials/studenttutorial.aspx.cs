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

public partial class Tutorials_studenttutorial : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclass();
            fillteacher();
            ddlsubject.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(0, "-Select-");
            ddlunit.Items.Insert(0, "-Select-");
            ddllesson.Items.Insert(0, "-Select-");
            txtdate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            fillgrid();
        }
    }
    protected void fillclass()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strclass from tbltutorial where intschool=" + Session["SchoolID"] + " and strclass='" + Session["StudentClass"].ToString() + "' group by strclass";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstandard.Text = ds.Tables[0].Rows[0]["strclass"].ToString();
        }
        else
        {
            lblstandard.Text = Session["StudentClass"].ToString();
        }
       
    }
    protected void fillteacher()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername, a.intid from tblemployee a,tbltutorial b where b.intschool =" + Session["SchoolID"] + " and b.strclass='" + Session["StudentClass"].ToString() + "' and a.intid=b.intteacher group by a.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname";
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
        strsql = "select strsubject from tbltutorial where intschool=" + Session["SchoolID"].ToString() + " and strclass ='" + Session["StudentClass"].ToString() + "' group by strsubject";
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
        //strsql = "select a.intid,a.strtextbookname from tblschooltextbook a,tbltutorial b where b.intschool=" + Session["SchoolID"] + " and b.strclass='" + Session["StudentClass"].ToString() + "'";
        strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + Session["StudentClass"].ToString() + "' and strsubject='" + ddlsubject.SelectedValue + "'";
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
        strsql = "select strunit from tbltutorial where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strclass='" + Session["StudentClass"].ToString() + "' and  inttextbook='" + ddltextbook.SelectedValue + "' group by strunit";
        ds = da.ExceuteSql(strsql);
        ddlunit.DataSource = ds;
        ddlunit.DataTextField = "strunit";
        ddlunit.DataValueField = "strunit";
        ddlunit.Items.Clear();
        ddlunit.DataBind();
        ddlunit.Items.Insert(0, "-Select-");
    }
    protected void filllesson()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strlesson from tbltutorial where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strclass='" + Session["StudentClass"].ToString() + "' and  inttextbook='" + ddltextbook.SelectedValue + "' and strunit='" + ddlunit.SelectedValue + "' group by strlesson";
        ds = da.ExceuteSql(strsql);
        ddllesson.DataSource = ds;
        ddllesson.DataTextField = "strlesson";
        ddllesson.DataValueField = "strlesson";
        ddllesson.Items.Clear();
        ddllesson.DataBind();
        ddllesson.Items.Insert(0, "-Select-");
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
        strsql = "select a.*,convert(varchar(10),dtdate,103) as date,b.strfirstname +' '+strmiddlename+' '+strlastname as teachername,c.strtextbookname from tbltutorial a,tblemployee b,tblschooltextbook c where a.intschool =" + Session["SchoolID"] + " and a.strclass='" + Session["StudentClass"].ToString() + "' and b.intid = a.intteacher and c.intid=a.inttextbook and  convert(varchar(10),a.dtpublishdate,111)<=convert(varchar(10),getdate(),111)";
        if (txtdate.Text != "")
        {
            strsql += " and dtdate='" + txtdate.Text.Trim() + "'";
        }
        if (ddlteacher.SelectedIndex > 0)
        {
            strsql += " and a.intteacher='" + ddlteacher.SelectedValue + "'";
        }
        if (ddlsubject.SelectedIndex > 0)
        {
            strsql += " and a.strsubject='" + ddlsubject.SelectedValue + "'";
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
            dgtutorial.Visible = true;
            dgtutorial.DataSource = ds;
            dgtutorial.DataBind();
            tr1.Visible = false;
        }
        else
        {
            dgtutorial.Visible = false;
            tr1.Visible = true;
        }
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}