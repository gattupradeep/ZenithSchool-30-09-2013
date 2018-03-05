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

public partial class Library_Default : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlmt();
            fillddlmc();
        }
    }
    protected void fillddlmt()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblmediatype where intschool='" + Session["SchoolID"].ToString() + "' order by intid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlmt.DataSource = ds;
        ddlmt.DataTextField = "strmediatype";
        ddlmt.DataValueField = "intid";
        ddlmt.DataBind();
        ListItem li = new ListItem("All","0");
        ddlmt.Items.Insert(0, li);
    }
    protected void fillddlmc()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblmediacategory where intschool='"+ Session["SchoolID"].ToString() +"' order by intid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlmc.DataSource = ds;
        ddlmc.DataTextField = "strmediacategory";
        ddlmc.DataValueField = "intid";
        ddlmc.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlmc.Items.Insert(0,li);
    }
    protected void allclear()
    {
        Txtnoofrenewal.Text = "";
        txtupto1.Text = ""; ;
        txtfineamount1.Text = "";
        txtupto2.Text = "";
        txtfineamount2.Text = "";
        txtupto3.Text = "";
        txtfineamount3.Text = "";
        txtupto4.Text = "";
        txtfineamount4.Text = "";
        Txtnoofdays.Text = "";
        txtfineperday.Text = "";
        Btnsave.Text = "Save";
        fillgrid();
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        allclear();
    }
    protected void filldept()
    {
        strsql = " select * from tbldepartment where intschool="+ Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldept.DataSource = ds;
        ddldept.DataTextField = "strdepartmentname";
        ddldept.DataValueField = "intid";
        ddldept.DataBind();
        ddldept.Items.Insert(0, "-Select-");
    }
    protected void filldesig()
     {
        strsql = " select * from tbldesignation where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldesig.DataSource = ds;
        ddldesig.DataTextField = "strdesignation";
        ddldesig.DataValueField = "intid";
        ddldesig.DataBind();
        ddldesig.Items.Insert(0, "-Select-");
     }
    protected void fillstd()
     {
         strsql = " select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
         da = new DataAccess();
         ds = new DataSet();
         ds = da.ExceuteSql(strsql);
         ddlstd.DataSource = ds;
         ddlstd.DataTextField = "strstandard";
         ddlstd.DataValueField = "strstandard";
         ddlstd.DataBind();
         ddlstd.Items.Insert(0, "-Select-");
     }
    protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
     {
         fillgrid();
     }
    protected void Btnsave_Click(object sender, EventArgs e)
    {

        SqlCommand cmd;
        SqlParameter OutPutParam;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        cmd = new SqlCommand("SPmediareturndate", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        OutPutParam = cmd.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (Btnsave.Text == "Save")
        {
            cmd.Parameters.Add("@intid", "0");
        }
        else

            cmd.Parameters.Add("@intid", Session["intid"].ToString());
        cmd.Parameters.Add("@strpatron", ddlpatron.SelectedValue);

        if (ddlpatron.SelectedValue == "Student")
        {
            cmd.Parameters.Add("@strstandard", ddlstd.SelectedValue);
        }
        else
        {
            cmd.Parameters.Add("@strstandard", "0");
        }
        if (ddlpatron.SelectedValue == "Employee")
        {
            cmd.Parameters.Add("@intdepartment", ddldept.SelectedValue);
            cmd.Parameters.Add("@intdesignation", ddldesig.SelectedValue);
        }
        else
        {
            cmd.Parameters.Add("@intdepartment", "0");
            cmd.Parameters.Add("@intdesignation", "0");
        }
        cmd.Parameters.Add("@intmediatype", ddlmt.SelectedValue);
        cmd.Parameters.Add("@intmediacategory", ddlmc.SelectedValue);
        cmd.Parameters.Add("@intnoofdays", Txtnoofdays.Text.Trim());
        cmd.Parameters.Add("@intnoofrenewals", Txtnoofrenewal.Text.Trim());
        cmd.Parameters.Add("@intupto1", txtupto1.Text.Trim());
        cmd.Parameters.Add("@intfine1", txtfineamount1.Text.Trim());
        cmd.Parameters.Add("@intupto2", txtupto2.Text.Trim());
        cmd.Parameters.Add("@intfine2", txtfineamount2.Text.Trim());
        cmd.Parameters.Add("@intupto3", txtupto3.Text.Trim());
        cmd.Parameters.Add("@intfine3", txtfineamount3.Text.Trim());
        cmd.Parameters.Add("@intupto4", txtupto4.Text.Trim());
        cmd.Parameters.Add("@intfine4", txtfineamount4.Text.Trim());
        cmd.Parameters.Add("@intfineperday", txtfineperday.Text.Trim());
        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        cmd.ExecuteNonQuery();
        if ((int)(cmd.Parameters["@rc"].Value) == 0)
        {
            MsgBox1.alert("Oops! already Exist");
        }
        conn.Close();
        fillgrid();
        allclear();
    }
    protected void dgreturndate_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string sql = "select * from tblreturndate where intschool='" + Session["SchoolID"].ToString() + "' and intid='" + Session["intid"] + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlpatron.SelectedValue = ds.Tables[0].Rows[0]["strpatron"].ToString();
        if (ddlpatron.SelectedValue == "Student")
        {
            ddlstd.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
        }
        else
        {
            ddldept.SelectedValue = ds.Tables[0].Rows[0]["intdepartment"].ToString();
            ddldesig.SelectedValue = ds.Tables[0].Rows[0]["intdesignation"].ToString();
        }
        ddlmt.SelectedValue = ds.Tables[0].Rows[0]["intmediatype"].ToString();
        ddlmc.SelectedValue = ds.Tables[0].Rows[0]["intmediacategory"].ToString();
        Txtnoofdays.Text = ds.Tables[0].Rows[0]["intnoofdays"].ToString();
        Txtnoofrenewal.Text = ds.Tables[0].Rows[0]["intnoofrenewals"].ToString();
        txtupto1.Text = ds.Tables[0].Rows[0]["intupto1"].ToString();
        txtfineamount1.Text = ds.Tables[0].Rows[0]["intfine1"].ToString();
        txtupto2.Text = ds.Tables[0].Rows[0]["intupto2"].ToString();
        txtfineamount2.Text = ds.Tables[0].Rows[0]["intfine2"].ToString();
        txtupto3.Text = ds.Tables[0].Rows[0]["intupto3"].ToString();
        txtfineamount3.Text = ds.Tables[0].Rows[0]["intfine3"].ToString();
        txtupto4.Text = ds.Tables[0].Rows[0]["intupto4"].ToString();
        txtfineamount4.Text = ds.Tables[0].Rows[0]["intfine4"].ToString();
        txtfineperday.Text = ds.Tables[0].Rows[0]["intfineperday"].ToString();
        Btnsave.Text = "Update";
        fillgrid();
    }
    //protected void dgreturndate_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete from tblreturndate where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void fillgrid()
    {
        string sql;
        if (ddlpatron.SelectedValue == "Employee")
        {
            sql = "select a.*, b.strdesignation, c.strdepartmentname, d.strmediatype, e.strmediacategory";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and a.intdesignation=b.intid ";
            sql += " and c.intid=a.intdepartment and d.intid=a.intmediatype and e.intid=a.intmediacategory and a.intmediatype>0 union";
            sql += " select a.*,b.strdesignation,c.strdepartmentname,'All' as strmediatype,e.strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and a.intdesignation=b.intid ";
            sql += " and c.intid=a.intdepartment and e.intid=a.intmediacategory and intmediatype=0 union";
            sql += " select a.*,b.strdesignation,c.strdepartmentname,d.strmediatype,e.strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and a.intdesignation=b.intid ";
            sql += " and c.intid=a.intdepartment and d.intid=a.intmediatype and e.intid=a.intmediacategory and a.intmediacategory>0 union";
            sql += " select a.*,b.strdesignation,c.strdepartmentname,d.strmediatype,'All' as strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and a.intdesignation=b.intid ";
            sql += " and c.intid=a.intdepartment and d.intid=a.intmediatype and a.intmediacategory=0 union";
            sql += " select a.*,b.strdesignation,c.strdepartmentname,'All' as strmediatype,'All' as strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and a.intdesignation=b.intid ";
            sql += " and c.intid=a.intdepartment and a.intmediacategory=0 and a.intmediatype=0";

        }

        else
        {
            //sql = " select a.*,d.strmediatype,e.strmediacategory,'' as strdesignation,'' as strdepartmentname from tblreturndate a,dbo.tblmediatype d,dbo.tblmediacategory e where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and d.intid=a.intmediatype and e.intid=a.intmediacategory";
            sql = "select a.*,'' as strdesignation,'' as strdepartmentname,d.strmediatype,e.strmediacategory";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e ";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and d.intid=a.intmediatype and e.intid=a.intmediacategory";
            sql += " and intmediatype>0 union select a.*,'' as strdesignation,'' as strdepartmentname,'All' as strmediatype,e.strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e ";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and e.intid=a.intmediacategory and intmediatype=0 union";
            sql += " select a.*,'' as strdesignation,'' as strdepartmentname,d.strmediatype,e.strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e ";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and d.intid=a.intmediatype and e.intid=a.intmediacategory and intmediacategory>0 union";
            sql += " select a.*,'' as strdesignation,'' as strdepartmentname,d.strmediatype,'All' as strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e ";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and d.intid=a.intmediatype and intmediacategory=0 union";
            sql += " select a.*,'' as strdesignation,'' as strdepartmentname,'All' as strmediatype,'All' as strmediacategory ";
            sql += " from tblreturndate a,dbo.tbldesignation b,dbo.tbldepartment c,dbo.tblmediatype d,dbo.tblmediacategory e ";
            sql += " where a.strpatron ='" + ddlpatron.SelectedValue + "' and a.intschool ='" + Session["SchoolID"].ToString() + "' and intmediacategory=0 and intmediatype=0";
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgreturndate.DataSource = ds;
        dgreturndate.DataBind();
        
        if (ddlpatron.SelectedValue == "Employee")
        {
            trstd.Visible = false;
            trdept.Visible = true;
            trdesig.Visible = true;
            dgreturndate.Columns[4].Visible = false;
            dgreturndate.Columns[2].Visible = true;
            dgreturndate.Columns[3].Visible = true;
            filldept();
            filldesig();
        }
        else
        {
            trstd.Visible = true;
            trdept.Visible = false;
            trdesig.Visible = false;
            dgreturndate.Columns[4].Visible = true;
            dgreturndate.Columns[2].Visible = false;
            dgreturndate.Columns[3].Visible = false;
            fillstd();
        }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete from tblreturndate where intid=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}
