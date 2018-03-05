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

public partial class Library_addmedia : System.Web.UI.Page
   
{
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         fillddl1();
         fillddl2();
         Txtbarcde.Text = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
         fillgrid();
        }
    }
    private void fillddl1()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblmediatype where intschool="+Session["SchoolID"];
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddl1.DataSource = ds;
        ddl1.DataTextField = "strmediatype";
        ddl1.DataValueField = "intid";
        ddl1.DataBind();
        //Txtcode.Text = ds.Tables[0].Rows[0]["intid"].ToString();
        ddl1.Items.Insert(0, "-Select-");
    }

    private void fillddl2()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblmediacategory where intschool=" + Session["SchoolID"];
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddl2.DataSource = ds;
        ddl2.DataTextField = "strmediacategory";
        ddl2.DataValueField = "intid";
        ddl2.DataBind();
       // Txtcode.Text = ds.Tables[0].Rows[0]["intid"].ToString();
        ddl2.Items.Insert(0, "-Select-");
    }  
    protected void btnsave_Click(object sender, EventArgs e)
    {
        
            SqlCommand cmd;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
            Conn.Open();
            cmd = new SqlCommand("SPaddmedia", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            if (btnsave.Text == "Save")
                cmd.Parameters.Add("@intid", "0");
            else
            cmd.Parameters.Add("@intid", Session["intid"].ToString());
            cmd.Parameters.Add("@intmediatype", ddl1.SelectedValue);
            cmd.Parameters.Add("@intmediacategory", ddl2.SelectedValue);
            cmd.Parameters.Add("@intcode", Txtcode.Text.Trim());
            cmd.Parameters.Add("@strtitle", Txtname.Text.Trim());
            cmd.Parameters.Add("@strauthorname", Txtauthor.Text.Trim());
            cmd.Parameters.Add("@strpublisher", Txtvendor.Text.Trim());
            cmd.Parameters.Add("@stredition", Txtedition.Text.Trim());
            cmd.Parameters.Add("@intprice", Txtprice.Text.Trim());
            cmd.Parameters.Add("@intnoofcopies", Txtcopies.Text.Trim());
            cmd.Parameters.Add("@intbarcode", Txtbarcde.Text.Trim());
            cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            cmd.ExecuteNonQuery();
            Conn.Close();
            allclear();
            fillgrid();            
            Txtbarcde.Text = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
           
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.*, b.strmediacategory,c.strmediatype from dbo.tbladdmedia a,dbo.tblmediacategory b,dbo.tblmediatype c  where a.intmediacategory=b.intid and a.intmediatype=c.intid and a.intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgaddmedia.DataSource = ds;
        dgaddmedia.DataBind();
    }
    protected void allclear()
    {
        ddl1.SelectedIndex = 0;
        ddl2.SelectedIndex = 0;
        Txtcode.Text = "";
        Txtname.Text = "";
        Txtauthor.Text = "";
        Txtvendor.Text = "";
        Txtedition.Text = "";
        Txtprice.Text = "";
        Txtcopies.Text = "";
        //Txtbarcde.Text = "";
        btnsave.Text = "Save";
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        allclear();
    }

    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Txtcode.Text = ddl1.SelectedValue;
    }

    protected void dgaddmedia_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "select * from dbo.tbladdmedia  where intschool=" + Session["SchoolID"].ToString()+" and intid="+e.Item.Cells[0].Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        Session["intid"] = e.Item.Cells[0].Text;
        ddl1.SelectedValue = ds.Tables[0].Rows[0]["intmediatype"].ToString();
        ddl2.SelectedValue = ds.Tables[0].Rows[0]["intmediacategory"].ToString();
        Txtcode.Text = ds.Tables[0].Rows[0]["intcode"].ToString();
        Txtname.Text = ds.Tables[0].Rows[0]["strtitle"].ToString();
        Txtauthor.Text = ds.Tables[0].Rows[0]["strauthorname"].ToString();
        Txtvendor.Text = ds.Tables[0].Rows[0]["strpublisher"].ToString();
        Txtedition.Text = ds.Tables[0].Rows[0]["stredition"].ToString();
        Txtprice.Text = ds.Tables[0].Rows[0]["intprice"].ToString();
        Txtcopies.Text = ds.Tables[0].Rows[0]["intnoofcopies"].ToString();
        Txtbarcde.Text = ds.Tables[0].Rows[0]["intbarcode"].ToString();
        btnsave.Text = "Update";
    }
    //protected void dgaddmedia_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tbladdmedia where intschool=" + Session["SchoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tbladdmedia where intschool=" + Session["SchoolID"].ToString() + " and intid=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}

   
    

   