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

public partial class admin_editdiscipline : System.Web.UI.Page
{
    string intid ="";
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
    public SqlCommand RegCommand;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (!IsPostBack)
        {
            fillstandard();
            ddlsection.Items.Insert(0, "-Select-");
            ddlstudent.Items.Insert(0, "-Select-");
            //btnSave.Visible = false;
            editclear.Visible = false;
            if (Request.QueryString["Dstd"] != null)
            {
                ddlstandard.SelectedValue = Request.QueryString["Dstd"];
                fillsection();
                fillgrid();
            }
        }
    }
    protected void fillgrid()
    {
        string str;
        str = "select b.intid,a.strfirstname+' '+strmiddlename+' '+strlastname as name,b.strstandard,b.strsection,convert(varchar(10),dtdate,103) as dtdate,strdiscipline from tblstudent a,tbldiscipline b where a.intid=b.intstudent  and b.intschool=" + Session["SchoolID"].ToString() + "";
        if (ddlstandard.SelectedIndex > 0)
        {
            str = str + " and b.strstandard='" + ddlstandard.SelectedValue + "'";
        }
        if (ddlsection.SelectedIndex > 0)
        {
            str = str + " and b.strsection='" + ddlsection.SelectedValue + "'";
        }
        if (ddlstudent.SelectedIndex > 0)
        {
            str = str + " and b.intstudent='" + ddlstudent.SelectedValue + "'";
        }
        if (txtfrom.Text != "" && txtTo.Text != "" )
        {
            str += " and dtdate between convert(datetime,'" + txtfrom.Text + "',103) and convert(datetime,'" + txtTo.Text + "',103)";
        }
        str += " order by dtdate desc";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgdiscipline.DataSource = ds;
            dgdiscipline.DataBind();
            dgdiscipline.Visible = true;
            errormessage.Visible = false;
        }
        else
        {
            dgdiscipline.Visible = false;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Not Assigne disciplines ')", true);
            errormessage.Visible = true;
            errormessage.Text = "There is no Discipline entries found for the selected criteria";
        }
    }
    protected void fillstandard()
    {
        string str;
        str = "select strstandard from tbldiscipline where intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");
        //ddlstandard.Items.Insert(1, "All");
    }
    protected void fillsection()
    {
        string str;
        str = "select strsection from tbldiscipline where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstandard.SelectedValue + "'group by strsection";
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
        str = "select distinct a.strfirstname+' '+strmiddlename+' '+strlastname as name,a.intid from tblstudent a,tbldiscipline b where b.strstandard='" + ddlstandard.SelectedValue + "' and b.strsection='" + ddlsection.SelectedValue + "' and a.intid=b.intstudent and a.intschool=" + Session["SchoolID"].ToString(); 
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "-Select-");
    }
    //protected void btnSave_Click(object sender, EventArgs e)
    //{

    //    SqlCommand command;
    //    SqlParameter Outputparameter;
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    //    conn.Open();
    //    command = new SqlCommand("SPdiscipline", conn);
    //    command.CommandType = CommandType.StoredProcedure;
    //    Outputparameter = command.Parameters.Add("@rc", SqlDbType.Int);
    //    Outputparameter.Direction = ParameterDirection.Output;
    //    if (btnSave.Text == "Save")
    //    {
    //        command.Parameters.Add("@intID", "0");
    //    }
    //    else
    //    {
    //        command.Parameters.Add("@intID", Session["intid"].ToString());
    //        intid = Session["intid"].ToString();
    //    }
    //    command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
    //    command.Parameters.Add("@strsection", ddlsection.SelectedValue);
    //    command.Parameters.Add("@intstudent", ddlstudent.SelectedValue);
    //    command.Parameters.Add("@dtdate", labdate.Text.Trim());
    //    command.Parameters.Add("@strdiscipline", txtdiscipline.Text.Trim());
    //    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
    //    command.ExecuteNonQuery();
    //    conn.Close();
    //    if (btnSave.Text == "Update")
    //    {
    //        ddlstandard.Enabled = true;
    //        ddlsection.Enabled = true;
    //        ddlstudent.Enabled = true;
    //        btnClear.Visible = false;
    //        btnSave.Visible = false;
    //        Label1.Visible = false;
    //        txtdiscipline.Visible = false;
    //        labdate.Text = "";
    //        txtTo.Visible = true;
    //        txtfrom.Visible = true;
    //        lblto.Visible = true;
    //        lblfrom.Visible = true;
    //        lblfrom.Text = "from Date";
    //        labdate.Visible = false;
    //        bttnget.Visible = true;
    //    }
    //    fillgrid();
    //    Clear();

    //}
    protected void Clear()
    {
       txtdiscipline.Text = "";
       //btnSave.Text = "Update";
    }
    protected void Clear1()
    {
        labdate.Text = "";
        txtdiscipline.Text = "";
        ddlstandard.SelectedIndex = 0;
        ddlsection.SelectedIndex = 0;
        ddlstudent.SelectedIndex = 0;
        dgdiscipline.Visible = false;
        txtfrom.Text = "";
        txtTo.Text = "";
       
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear1();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        fillsection();
        fillstudent();
        errormessage.Visible = false;
        //if (ddlstandard.SelectedValue == "--select--")
        //{
        //    dgdiscipline.Visible = false; 
        //}
        //if (ddlstandard.SelectedValue == "All")
        //{
            fillgrid();
        //}
        labdate.Text = "";
        txtdiscipline.Text = "";
        txtfrom.Text = "";
        txtTo.Text = "";
        
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        //fillgrid();
        labdate.Text = "";
        txtdiscipline.Text = "";
        errormessage.Visible = false;
        txtfrom.Text = "";
        txtTo.Text = "";
    }
    protected void editcommand_dgdiscipline(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        Response.Redirect("discipline.aspx?Did=" + e.Item.Cells[0].Text);
    }
    protected void editclear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void bttnget_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void ddlstudent_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fillgrid();
    }
    
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tbldiscipline where intID=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tbldiscipline", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 247);
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}


