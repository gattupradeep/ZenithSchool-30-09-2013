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

public partial class admin_viewdiscipline : System.Web.UI.Page
{
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
    public SqlCommand RegCommand;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PatronType"].ToString() == "Parents" || Session["PatronType"].ToString() == "Students")
                Response.Redirect("view_student_discipline.aspx");
            LoadData();
        }
    }
    // Added By Prabaa on 04-10-13
    protected void LoadData()
    {
        fillstandard();
        fillsection();
        fillTeacher();
        fillstudent();
        fillgrid();
    }
    protected void fillgrid()
    {
        try
        {
            errormessage.Visible = false;
            string str;
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            // added By Prabaa on 04-10-13

            str = "select b.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as Studentname,e.strfirstname+' '+e.strmiddlename+' '+e.strlastname as Staffname,b.strstandard,b.strsection,convert(varchar(10),dtdate,103) as dtdate,strdiscipline from tblstudent a,tbldiscipline b, tblemployee e where a.intid=b.intstudent and a.intschool = b.intschool and b.intschool = e.intschool and b.StaffID = e.intid and b.intschool=" + Session["SchoolID"].ToString() + "";
            if (ddlstandard.SelectedIndex > 1)
                str = str + " and b.strstandard='" + ddlstandard.SelectedValue + "'";
            if (ddlsection.SelectedIndex > 0)
                str = str + " and b.strsection='" + ddlsection.SelectedValue + "'";
            if (ddlstudent.SelectedIndex > 0)
                str = str + " and b.intstudent='" + ddlstudent.SelectedValue + "'";
            if (txtfrom.Text != "" && txtTo.Text != "" && lblhidden.Text == "ok")
                str += " and dtdate between convert(datetime,'" + txtfrom.Text + "',103) and convert(datetime,'" + txtTo.Text + "',103)";
            if (Session["PatronType"].ToString() == "Teaching Staffs")
                str += " and b.StaffID = " + Session["UserID"];
            str += " group by b.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname,e.strfirstname+' '+e.strmiddlename+' '+e.strlastname,b.strstandard,b.strsection,convert(varchar(10),dtdate,103),strdiscipline";
            str += " order by dtdate desc";

            ds = da.ExceuteSql(str);
            
            if (Session["PatronType"].ToString() == "Teaching Staffs")
                dgdiscipline.Columns[4].Visible = false;
            else
                dgdiscipline.Columns[4].Visible = false;
            // end
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgdiscipline.DataSource = ds;
                dgdiscipline.DataBind();
                dgdiscipline.Visible = true;
            }
            else
            {
                dgdiscipline.Visible = false;
                errormessage.Visible = true;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Not Assigne disciplines ')", true);
                errormessage.Text = "There is no Discipline entries found for the selected criteria";
            }
        }
        catch { }
    }
    // added By Prabaa on 04-10-13
    protected void fillTeacher()
    {
        string str;
        str = "select e.intid,e.strfirstname+' '+e.strmiddlename+' '+e.strlastname as Staffname from tblstudent a,tbldiscipline b, tblemployee e where  b.intschool = e.intschool and b.StaffID = e.intid and b.intschool=" + Session["SchoolID"];
        if (ddlstandard.SelectedIndex > 1)
            str = str + " and b.strstandard='" + ddlstandard.SelectedValue + "'";
        if (ddlsection.SelectedIndex > 0)
            str = str + " and b.strsection='" + ddlsection.SelectedValue + "'";
        if (Session["PatronType"].ToString() == "Teaching Staffs")
            str += " and b.StaffID = " + Session["UserID"];
        str += " group by e.intid,e.strfirstname+' '+e.strmiddlename+' '+e.strlastname";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);

        ddlTeacher.DataSource = ds;
        ddlTeacher.DataTextField = "Staffname";
        ddlTeacher.DataValueField = "intID";
        ddlTeacher.DataBind();
        if (Session["PatronType"].ToString() != "Teaching Staffs")
            ddlTeacher.Items.Insert(0, "-Select-");
    }
    // Modified By Prabaa on 04-10-13
    protected void fillstandard()
    {
        string str;
        str = "select strstandard from tbldiscipline where intschool=" + Session["SchoolID"];
        if (Session["PatronType"].ToString() == "Teaching Staffs")
            str += " and StaffID = " + Session["UserID"];
        str += " group by strstandard";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--select--");
        ddlstandard.Items.Insert(1, "All");
        
    }
    // Modified By Prabaa on 04-10-13
   protected void fillsection()
    {
       string str;
       str = "select strsection from tbldiscipline where intschool=" + Session["SchoolID"].ToString();
       if (ddlstandard.SelectedIndex > 1)
            str += " and strstandard='" + ddlstandard.SelectedValue +"'";
       if (Session["PatronType"].ToString() == "Teaching Staffs")
           str += " and StaffID = " + Session["UserID"];
       str += " group by strsection";
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       ds = da.ExceuteSql(str);
       ddlsection.DataSource = ds;
       ddlsection.DataTextField = "strsection";
       ddlsection.DataValueField = "strsection";
       ddlsection.DataBind();
       ddlsection.Items.Insert(0, "--select--");
    }
   // Modified By Prabaa on 04-10-13
   protected void fillstudent()
    {
       string str = "";
       str = "select distinct a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,a.intid from tblstudent a,tbldiscipline b where b.strsection='" + ddlsection.SelectedValue + "' and a.intid=b.intstudent and a.intschool=" + Session["SchoolID"].ToString();
       if (ddlstandard.SelectedIndex > 1)
            str += " and b.strstandard='" + ddlstandard.SelectedValue + "'";
       if (ddlTeacher.SelectedValue != "-Select-")
           str += " and b.StaffID = " + ddlTeacher.SelectedValue;
       str += " group by a.strfirstname+' '+a.strmiddlename+' '+a.strlastname,a.intid";
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       ds = da.ExceuteSql(str);
       ddlstudent.DataSource = ds;
       ddlstudent.DataTextField = "name";
       ddlstudent.DataValueField = "intid";
       ddlstudent.DataBind();
       ListItem li = new ListItem("-Select-", "0");
       ddlstudent.Items.Insert(0, li);
    }
  
  protected void bttnget_Click(object sender, EventArgs e)
   {
       lblhidden.Text = "ok";
       fillgrid();
      
   }
   protected void ddlstudent_SelectedIndexChanged1(object sender, EventArgs e)
   {
       if (ddlstudent.SelectedIndex > 0)
       {
           fillgrid();
           txtfrom.Text = "";
           txtTo.Text = "";
       }
   }
   protected void ddlstandard_SelectedIndexChanged1(object sender, EventArgs e)
   {
       fillsection();
       fillTeacher();
       fillgrid();
       txtfrom.Text = "";
       txtTo.Text = "";
   }
   protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
   {
       fillTeacher();
       fillstudent();
       fillgrid();
       txtfrom.Text = "";
       txtTo.Text = "";
   }
   protected void btnclear_Click(object sender, EventArgs e)
   {
       Response.Redirect("viewdiscipline.aspx", false);
   }
   protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
   {
       if (int.Parse(ddlTeacher.SelectedValue) > 0)
       {
           fillstudent();
           fillgrid();
           txtfrom.Text = "";
           txtTo.Text = "";
       }
   }
}

