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

public partial class Inventory_iteminward1 : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillIteminward();
            fillsupplier();
            fillinvoiceno();
            fillcategory();
            fillitems();
        }
    }
    private void fillIteminward()
    {
        DataAccess da = new DataAccess();
        string sql = "select convert(varchar(10),d.dtinwarddate,103) as inwarddate,a.strcategory,d.intid as id,b.stritemname,c.strvendorname,d.dtinwarddate,d.strsupplier,d.intcategory,d.intitemid,d.intnoofitems,d.strinvoiceno from tblitemcategory a,tblitemmaster b,tblvendormaster c,tbliteminwardnew d where a.intid=d.intcategory and b.intid=d.intitemid and c.strvendorname=d.strsupplier";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grditeminward.DataSource = ds.Tables[0];
        grditeminward.DataBind();
    }
    protected void fillitems()
    {
        string sql = "select * from tblitemmaster where intitemcategory='" + drpcategory.SelectedValue + "'";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpitems.DataSource = ds;
        drpitems.DataTextField = "stritemname";
        drpitems.DataValueField = "intid";
        drpitems.DataBind();
    }
    protected void fillbalance()
    {
        conn.Open();
        string sql = "select * from tblbalance where intitem='"+drpitems.SelectedValue +"' and intcategory='"+drpcategory.SelectedValue+"'";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count == 0)
        {
            sql = "insert into tblbalance(intcategory,intitem,intinwardqty,intsalesqty,intreturnqty,intbalanceqty,intschool)values('" + drpcategory.SelectedValue + "','" + drpitems.SelectedValue + "','" + txtnoofitems.Text + "','" + 0 + "','" + 0 + "','" + txtnoofitems.Text + "','" + 0 + "')";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        else
        {
            int s = int.Parse(ds.Tables[0].Rows[0]["intinwardqty"].ToString());
            int r = int.Parse(ds.Tables[0].Rows[0]["intreturnqty"].ToString());
            int a = int.Parse(txtnoofitems.Text);
            int c = a + s;
            int b = c - r;
            sql = "update tblbalance set intinwardqty='" + c + "',intbalanceqty='" + b + "' where intcategory='"+drpcategory.SelectedValue+"' and intitem='"+drpitems.SelectedValue+"'";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();  
        }
        conn.Close();
    }      
    protected void fillcategory()
    {
        string sql = "select * from tblitemcategory";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpcategory.DataSource = ds;
        drpcategory.DataTextField = "strcategory";
        drpcategory.DataValueField = "intid";
        drpcategory.DataBind();
    }
    protected void fillsupplier()
    {
        string sql = "select * from tblvendormaster";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpsupplier.DataSource = ds;
        drpsupplier.DataTextField = "strvendorname";
        drpsupplier.DataValueField = "strvendorname";
        drpsupplier.DataBind();
    }
    protected void fillinvoiceno()
    {
        string sql = "select * from tblvendor where strsuppliername='"+drpsupplier.SelectedValue+"'";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpinvoiceno.DataSource = ds;
        drpinvoiceno.DataTextField = "strinvoiceno";
        drpinvoiceno.DataValueField = "strinvoiceno";
        drpinvoiceno.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            fillbalance();
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spiteminwardnew", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@intitemid", drpitems.SelectedValue.Trim());
            RegCommand.Parameters.Add("@intcategory", drpcategory.SelectedValue.Trim());
            RegCommand.Parameters.Add("@strinvoiceno", drpinvoiceno.SelectedValue.Trim());
            RegCommand.Parameters.Add("@dtinwarddate", txtinwarddate.Text.Trim());
            RegCommand.Parameters.Add("@strsupplier", drpsupplier.SelectedValue.Trim());
            RegCommand.Parameters.Add("@intnoofitems", txtnoofitems.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            fillIteminward();
            clear();
        }
        catch
        {
            MsgBox.alert("Enter proper values");
        }
    }

    protected void  btnClear_Click(object sender, EventArgs e)
   {
       clear();
   }

   protected void clear()
    {
        fillsupplier();
        fillinvoiceno();
        fillcategory();
        fillitems();
        txtinwarddate.Text = "";
        txtnoofitems.Text = "";
        btnSave.Text = "Save";
    }
    
    protected void grditeminward_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        drpsupplier.SelectedValue = e.Item.Cells[1].Text;
        fillinvoiceno();
        drpinvoiceno.SelectedValue= e.Item.Cells[2].Text;
        drpcategory.SelectedValue = e.Item.Cells[7].Text;
        fillitems();
        drpitems.SelectedValue = e.Item.Cells[8].Text;
        txtinwarddate.Text = e.Item.Cells[5].Text;
        txtnoofitems.Text = e.Item.Cells[6].Text;
        btnSave.Text = "update";
    }
    protected void grditeminward_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tbliteminwardnew where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillIteminward();
    }
    protected void drpsupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillinvoiceno();
    }
    protected void drpcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillitems();
    }
 }
