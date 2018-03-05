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

public partial class Library_issueamedia : System.Web.UI.Page
{
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
    public SqlCommand RegCommand;
    public string strsql;
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "select convert(varchar(10),getdate(),111) as currentdate";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        Txtdateofissue.Text = ds.Tables[0].Rows[0]["currentdate"].ToString();
        if (!IsPostBack)
        {
            fillddlmt();
            fillddlmc();
            fillddlbt();
            fillddldept();
            fillddldesig();
            if (ddlpatron.SelectedValue == "Employee")
            {
                trstd.Visible = false;
                trsec.Visible = false;
                trdept.Visible = true;
                trdesig.Visible = true;
            }
            else
            {
                trsec.Visible = true;
                trsec.Visible = true;
                trdept.Visible = false;
                trdesig.Visible = false;
            }
        }
    }

    protected void fillddlmt()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblmediatype where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlmt.DataSource = ds;
        ddlmt.DataTextField = "strmediatype";
        ddlmt.DataValueField = "intid";
        ddlmt.DataBind();
        ddlmt.Items.Insert(0, "All");
    }

    protected void fillddlmc()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblmediacategory where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlmc.DataSource = ds;
        ddlmc.DataTextField = "strmediacategory";
        ddlmc.DataValueField = "intid";
        ddlmc.DataBind();
        ddlmc.Items.Insert(0, "All");
    }
    protected void fillddlbt()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tbladdmedia where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlbt.DataSource = ds;
        ddlbt.DataTextField = "strtitle";
        ddlbt.DataValueField = "strtitle";
        ddlbt.DataBind();
        ddlbt.Items.Insert(0, "All");
    }
    protected void fillddldept()
    {
        DataAccess da = new DataAccess();
        strsql = "select* from tbldepartment where intschool=" + Session["SchoolID"].ToString();
        DataSet ds =new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldept.DataSource = ds;
        ddldept.DataTextField = "strdepartmentname";
        ddldept.DataValueField = "intid";
        ddldept.DataBind();
        ddldept.Items.Insert(0, "All");
    }
    protected void fillddldesig()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tbldesignation where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldesig.DataSource = ds;        
        ddldesig.DataTextField = "strdesignation";
        ddldesig.DataValueField = "intid";
        ddldesig.DataBind();
        ddldesig.Items.Insert(0, "All");
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            string sql;
            if (ddlpatron.SelectedValue == "Student")
                sql = "select *,strfirstname++strmiddlename++strlastname as name from tblstudent  where intid =" + int.Parse(Txtregcode.Text) + "";
            else
                sql = "select *,strfirstname++strmiddlename++strlastname as name from tblemployee where intid =" + int.Parse(Txtregcode.Text) + "";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ddlpatron.SelectedValue == "Student")
            {
                labname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                labstd.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
                labsec.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
            }
            else
            {
                labname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                ddldept.SelectedValue = ds.Tables[0].Rows[0]["intDepartment"].ToString();
                ddldesig.SelectedValue = ds.Tables[0].Rows[0]["intDesignation"].ToString();
            }
        }
        catch { }
    }

    protected void btn1search_Click(object sender, EventArgs e)
    {
        try
        {
            string sql;
            sql = " select * from tbladdmedia where intbarcode=" + Txtbarcode.Text;
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            ddlmt.SelectedValue = ds.Tables[0].Rows[0]["intmediatype"].ToString();
            ddlmc.SelectedValue = ds.Tables[0].Rows[0]["intmediacategory"].ToString();
            ddlbt.SelectedValue = ds.Tables[0].Rows[0]["strtitle"].ToString();
        }
        catch { }
    }

    protected void allclear()
    {
        labsec.Text = "";
        labstd.Text = "";
        labname.Text = "";
        Txtregcode.Text = "";
        Txtbarcode.Text = "";
        Txtdateofissue.Text = "";
        ddlmt.SelectedIndex = 0;
        ddlmc.SelectedIndex = 0;
        ddlbt.SelectedIndex = 0;
        Btnsave.Text = "Save";
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        allclear();
    }
    protected void ddlmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        Txtbarcode.Text = ddlmt.SelectedValue;
    }
    protected void ddlmc_SelectedIndexChanged(object sender, EventArgs e)
    {
        Txtbarcode.Text = ddlmc.SelectedValue;

    }
    protected void ddlbt_SelectedIndexChanged(object sender, EventArgs e)
    {
        Txtbarcode.Text = ddlbt.SelectedValue;
    }

    protected void ddlpatron_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();

    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        if (ddlpatron.SelectedValue == "Employee")
            strsql = "select a.*,b.strdepartmentname,c.strdesignation as desig,convert(varchar(10),dtdateofissue,111) as issuedate from tblissueamedia a, tbldepartment b, tbldesignation c where a.strdepartment=b.intid and a.strdesignation=c.intid and a.intschool=1";
        else
            strsql = "select *,'' as strdepartmentname, '' as desig,convert(varchar(10),dtdateofissue,111) as issuedate from tblissueamedia where intschool=2 and strpatrontype='" + ddlpatron.SelectedValue + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgissuemedia.DataSource = ds;
        dgissuemedia.DataBind();

        if (ddlpatron.SelectedValue == "Employee")
        {
            trstd.Visible = false;
            trsec.Visible = false;
            trdept.Visible = true;
            trdesig.Visible = true;
            dgissuemedia.Columns[2].Visible = true;
            dgissuemedia.Columns[3].Visible = true;
            dgissuemedia.Columns[4].Visible = false;
            dgissuemedia.Columns[5].Visible = false;

        }
        else
        {
            trstd.Visible = true;
            trsec.Visible = true;
            trdept.Visible = false;
            trdesig.Visible = false;
            dgissuemedia.Columns[4].Visible = true;
            dgissuemedia.Columns[5].Visible = true;
            dgissuemedia.Columns[2].Visible = false;
            dgissuemedia.Columns[3].Visible = false;
        }

    }

    protected void dgissuemedia_EditCommand(object source, DataGridCommandEventArgs e)
    {
         hdnid.Value = e.Item.Cells[0].Text;
         DataAccess da = new DataAccess();
         string sql = "select *,convert(varchar(10),dtdateofissue,111) as issuedate from tblissueamedia where intschool=" + Session["SchoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
         DataSet ds = new DataSet();
         ds = da.ExceuteSql(sql);

         labname.Text = ds.Tables[0].Rows[0]["strname"].ToString();
         if (ddlpatron.SelectedValue == "Employee")
         {
             ddldept.SelectedValue = ds.Tables[0].Rows[0]["strdepartment"].ToString();
             ddldesig.SelectedValue = ds.Tables[0].Rows[0]["strdesignation"].ToString();
         }
         else
         {
             labstd.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
             labsec.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
         }

         ddlbt.SelectedValue = ds.Tables[0].Rows[0]["strtitle"].ToString();
         Txtdateofissue.Text = ds.Tables[0].Rows[0]["issuedate"].ToString();
         ddlmt.SelectedValue = ds.Tables[0].Rows[0]["intmediatype"].ToString();
         ddlmc.SelectedValue = ds.Tables[0].Rows[0]["intmediacategory"].ToString();
         Txtbarcode.Text = ds.Tables[0].Rows[0]["intbarcode"].ToString();
         Txtregcode.Text = ds.Tables[0].Rows[0]["intregistrationcode"].ToString();
         Btnsave.Text = "Update";
    }

    protected void Btnsave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter Outputparameter;

        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spissueamedia", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        Outputparameter = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        Outputparameter.Direction = ParameterDirection.Output;
        if (Btnsave.Text == "Save")
            RegCommand.Parameters.Add("@intid", "0");
        else
            RegCommand.Parameters.Add("@intid", hdnid.Value);
        RegCommand.Parameters.Add("@strpatrontype", ddlpatron.SelectedValue);
        if (ddlpatron.SelectedValue == "Student")
        {
            RegCommand.Parameters.Add("@strstandard", labstd.Text.Trim());
            RegCommand.Parameters.Add("@strsection", labsec.Text.Trim());
        }
        else
        {
            RegCommand.Parameters.Add("@strstandard", "0");
            RegCommand.Parameters.Add("@strsection", "0");
        }
        if (ddlpatron.SelectedValue == "Employee")
        {
            RegCommand.Parameters.Add("@strdepartment", ddldept.SelectedValue);
            RegCommand.Parameters.Add("@strdesignation", ddldesig.SelectedValue);
        }
        else
        {
            RegCommand.Parameters.Add("@strdepartment", "0");
            RegCommand.Parameters.Add("@strdesignation", "0");
        }
        RegCommand.Parameters.Add("@intregistrationcode", Txtregcode.Text.Trim());
        RegCommand.Parameters.Add("@strname", labname.Text.Trim());
        RegCommand.Parameters.Add("@intbarcode", Txtbarcode.Text.Trim());
        RegCommand.Parameters.Add("@intmediatype", ddlmt.SelectedValue);
        RegCommand.Parameters.Add("@intmediacategory", ddlmc.SelectedValue);
        RegCommand.Parameters.Add("@strtitle", ddlbt.SelectedValue);
        RegCommand.Parameters.Add("@dtdateofissue", Txtdateofissue.Text.Trim());
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.Parameters.Add("@intreturn", "1");
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        allclear();
        fillgrid();
    }
    //protected void dgissuemedia_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete from tblissueamedia where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    allclear();
    //    fillgrid();
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete from tblissueamedia where intid=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        allclear();
        fillgrid();

    }
}




