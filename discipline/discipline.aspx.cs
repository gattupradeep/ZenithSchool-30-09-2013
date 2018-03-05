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


public partial class admin_discipline : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillsection();
            fillstudent();
            if (Session["PatronType"].ToString() == "Teaching Staffs")
                fillTeacher();
            if (Request["Did"] != null)
            {
                edit();
            }
        }
    }
    protected void fillstandard()
    {
        string str;
        str = "select TT.strstandard,STD.intschoolstandardid from tbltimetable TT,tblschoolstandard STD where TT.intschool = STD.intschoolid and TT.intschool = " + Session["SchoolID"].ToString() + " and TT.strstandard =STD.strstandard";
        if (Session["PatronType"].ToString() == "Teaching Staffs")
            str += " and TT.strteacher = '" + Session["UserID"].ToString()+"'"; 
        str += " group by TT.strstandard,STD.intschoolstandardid";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);

        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");
        // ddlstandard.Items.Insert(1, "All");
    }
    protected void fillTeacher()
    {
        string str;
        str = "select EMP.intID,EMP.strfirstname+' '+EMP.strmiddlename+' '+EMP.strlastname [Teacher] from tbltimetable TT,tblemployee EMP where EMP.intID = CONVERT(INT, TT.strteacher) and TT.intschool = EMP.intSchool and TT.intschool = "+Session["SchoolID"];
        if(ddlstandard.SelectedIndex > 0)
            str += " and TT.strstandard ='"+ddlstandard.SelectedValue+"'";
        if(ddlsection.SelectedIndex >0 )
            str += " AND TT.strsection ='"+ddlsection.SelectedValue+"'";
        if (Session["PatronType"].ToString() == "Teaching Staffs")
            str += " AND EMP.intID =" + Session["UserID"];
        str += " group by EMP.intID,EMP.strfirstname+' '+EMP.strmiddlename+' '+EMP.strlastname";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);

        ddlTeacher.DataSource = ds;
        ddlTeacher.DataTextField = "Teacher";
        ddlTeacher.DataValueField = "intID";
        ddlTeacher.DataBind();
        if (Session["PatronType"].ToString() != "Teaching Staffs")
            ddlTeacher.Items.Insert(0, "-Select-");
        // ddlstandard.Items.Insert(1, "All");
    }
    protected void fillsection()
    {
        string str;
        str = "select TT.strsection,SEC.intschoolsectionid from tbltimetable TT,tblschoolsection SEC where TT.intschool = SEC.intschoolid and TT.intschool = "+Session["SchoolID"];
        str += " and TT.strsection =SEC.strsection"; 
        if(ddlstandard.SelectedIndex > 0)
            str += " and TT.strstandard = '"+ddlstandard.SelectedValue+"'";
        if (Session["PatronType"].ToString() == "Teaching Staffs")
            str += " and TT.strteacher = '" + Session["UserID"].ToString()+"'";
        str += " group by TT.strsection,SEC.intschoolsectionid";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        ddlsection.Items.Insert(0, "-Select-");
    }

    protected void fillstudent()
    {
        string str = "";
        str = "select strfirstname+' '+strmiddlename+' '+strlastname as name,intid from dbo.tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "-Select-");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Text == "Save")
            {
                SqlCommand command;
                SqlParameter Outputparameter;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("SPdiscipline", conn);
                command.CommandType = CommandType.StoredProcedure;
                Outputparameter = command.Parameters.Add("@rc", SqlDbType.Int);
                Outputparameter.Direction = ParameterDirection.Output;
                command.Parameters.Add("@intID", "0");
                command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
                command.Parameters.Add("@strsection", ddlsection.SelectedValue);
                command.Parameters.Add("@intstudent", ddlstudent.SelectedValue);
                //command.Parameters.Add("@dtdate", DateTime.Parse(txtdate.Text.Trim()).ToString("yyyy/MM/dd"));
                command.Parameters.Add("@dtdate", txtdate.Text.Trim());
                command.Parameters.Add("@strdiscipline", txtdiscipline.Text.Trim());
                command.Parameters.Add("@StaffID", ddlTeacher.SelectedValue.Trim());
                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                command.ExecuteNonQuery();
                conn.Close();
                string id = Convert.ToString(Outputparameter.Value);
                Functions.UserLogs(Session["UserID"].ToString(), "tbldiscipline", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 246);
                fillgrid();
                trdiscipline.Visible = true;
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
            }
            else
            {
                SqlCommand command;
                SqlParameter Outputparameter;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("SPdiscipline", conn);
                command.CommandType = CommandType.StoredProcedure;
                Outputparameter = command.Parameters.Add("@rc", SqlDbType.Int);
                Outputparameter.Direction = ParameterDirection.Output;
                command.Parameters.Add("@intID", Request["Did"].ToString());
                command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
                command.Parameters.Add("@strsection", ddlsection.SelectedValue);
                command.Parameters.Add("@intstudent", ddlstudent.SelectedValue);
                //command.Parameters.Add("@dtdate", DateTime.Parse(txtdate.Text.Trim()).ToString("yyyy/MM/dd"));
                command.Parameters.Add("@dtdate", txtdate.Text.Trim());
                command.Parameters.Add("@strdiscipline", txtdiscipline.Text.Trim());
                command.Parameters.Add("@StaffID", ddlTeacher.SelectedValue.Trim());
                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                command.ExecuteNonQuery();
                conn.Close();
                string id = Convert.ToString(Outputparameter.Value);
                Functions.UserLogs(Session["UserID"].ToString(), "tbldiscipline", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 247);
                //Response.Redirect("editdiscipline.aspx?Dstd=" + ddlstandard.SelectedValue);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='editdiscipline.aspx?Dstd=" + ddlstandard.SelectedValue+"';", true);
            }
        }
        catch { }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsection();
        trdiscipline.Visible = false;
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        fillTeacher();
        trdiscipline.Visible = false;
    }
    protected void fillgrid()
    {
        errormessage.Visible = false;
        string str;
        str = "select b.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,b.strstandard,b.strsection,convert(varchar(10),dtdate,103) as dtdate,strdiscipline from tblstudent a,tbldiscipline b where a.intid=b.intstudent  and b.intschool=" + Session["SchoolID"].ToString();
        if (ddlstandard.SelectedValue == "-Select-")
        {
            str = "select b.intid,a.strfirstname+' '+a.strlastname as name,b.strstandard,b.strsection,convert(varchar(10),dtdate,103) as dtdate,strdiscipline from tblstudent a,tbldiscipline b where a.intid=b.intstudent  and b.intschool=" + Session["SchoolID"].ToString();
        }
        else
        {
            if (ddlstandard.SelectedIndex > -1)
            {
                str = str + " and b.strstandard='" + ddlstandard.SelectedValue + "'";
            }
            if (ddlsection.SelectedIndex > -1)
            {
                str = str + " and b.strsection='" + ddlsection.SelectedValue + "'";
            }
            if (ddlstudent.SelectedIndex > 0)
            {
                str = str + " and b.intstudent='" + ddlstudent.SelectedValue + "'";
            }
        }
        str = str + " order by dtdate desc ";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgdiscipline.DataSource = ds;
            dgdiscipline.DataBind();
            dgdiscipline.Visible = true;
        }
        else
        {
            dgdiscipline.Visible = false;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Not Assigne disciplines these particular student')", true);
            //errormessage.Visible = true;
            errormessage.Text = "There is no Discipline entries found for the selected criteria";
        }
    }
    protected void edit()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select a.intid,b.intstudent,b.strstandard,b.strsection,convert(varchar(10),dtdate,111) as dtdate,b.strdiscipline from tblstudent a,tbldiscipline b where a.intid=b.intstudent and b.intid=" + Request["Did"].ToString();
        ds = da.ExceuteSql(str);
        fillstandard();
        ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
        ddlstandard.Enabled = false;
        fillsection();
        ddlsection.SelectedValue = ds.Tables[0].Rows[0]["strsection"].ToString();
        ddlsection.Enabled = false;
        fillstudent();
        ddlstudent.SelectedValue = ds.Tables[0].Rows[0]["intstudent"].ToString();
        ddlstudent.Enabled = false;
        txtdate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
        txtdiscipline.Text = ds.Tables[0].Rows[0]["strdiscipline"].ToString();
        btnSave.Text = "Update";
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        ddlstandard.SelectedIndex = 0;
        ddlstudent.SelectedIndex = 0;
        ddlsection.SelectedIndex = 0;
        txtdate.Text = "";
        txtdiscipline.Text = "";
        btnSave.Text = "Save";
        ddlstandard.Enabled = true;
        ddlsection.Enabled = true;
        ddlstudent.Enabled = true;
    }
}
