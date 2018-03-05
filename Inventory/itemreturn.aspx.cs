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

public partial class Inventory_itemreturn : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillItemreturn();
            fillsupplier();
            fillinvoiceno();
            fillcategory();
            fillitems();
        }

    }
    private void fillItemreturn()
    {
        DataAccess da = new DataAccess();
        string sql = "select convert(varchar(10),d.dtreturndate,103) as returndate,a.strcategory,d.intid as id,b.stritemname,d.strsupplier,d.dtreturndate,d.strsupplier,d.intcategory,d.intitemid,d.intnoofitems,d.strinvoiceno from tblitemcategory a,tblitemmaster b,tblitemreturn d where a.intid=d.intcategory and b.intid=d.intitemid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grditemreturn.DataSource = ds.Tables[0];
        grditemreturn.DataBind();
        clear();
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
        string sql = "select strsuppliername from tblcreditnote group by strsuppliername";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpsupplier.DataSource = ds;
        drpsupplier.DataTextField = "strsuppliername";
        drpsupplier.DataValueField = "strsuppliername";
        drpsupplier.DataBind();      
    }
    protected void fillbalance()
    {
        conn.Open();
        string sql = "select * from tblbalance where intitem='" + drpitems.SelectedValue + "' and intcategory='" + drpcategory.SelectedValue + "'";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int r = int.Parse(ds.Tables[0].Rows[0]["intreturnqty"].ToString());
            int b = int.Parse(ds.Tables[0].Rows[0]["intbalanceqty"].ToString());
            int a = int.Parse(txtnoofitems.Text);
            int t = r + a;
            int c = b - a;
            sql = "update tblbalance set intreturnqty='" + t + "',intbalanceqty='" + c + "'where intitem='" + drpitems.SelectedValue + "' and intcategory='" + drpcategory.SelectedValue + "'";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        else
       {
           MsgBox.alert("No items to Return");
       }
        conn.Close();
    }      
    protected void fillinvoiceno()
    {
        string sql = "select strinvoiceno from tblcreditnote where strsuppliername='" + drpsupplier.SelectedValue + "'";
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
        RegCommand = new SqlCommand("spitemreturn", Conn);
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
        RegCommand.Parameters.Add("@dtreturndate", txtreturndate.Text.Trim());
        RegCommand.Parameters.Add("@strsupplier", drpsupplier.SelectedValue.Trim());
        RegCommand.Parameters.Add("@intnoofitems", txtnoofitems.Text.Trim());
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        clear();
        fillItemreturn();
        }
        catch
        {
            MsgBox.alert("plese enter Proper Value in No of Items Field AND Date");
        }
}

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        fillsupplier();
        fillinvoiceno();
        fillcategory();
        fillitems();
        txtreturndate.Text = "";
        txtnoofitems.Text = "";
        btnSave.Text = "Save";
    }
    protected void grditemreturn_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblitemreturn where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillItemreturn();
    }
    protected void grditemreturn_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        drpsupplier.SelectedValue = e.Item.Cells[1].Text;
        fillinvoiceno();
        drpinvoiceno.SelectedValue = e.Item.Cells[2].Text;
        drpcategory.SelectedValue = e.Item.Cells[7].Text;
        fillitems();
        drpitems.SelectedValue = e.Item.Cells[8].Text;
        txtreturndate.Text = e.Item.Cells[5].Text;
        txtnoofitems.Text = e.Item.Cells[6].Text;
        btnSave.Text = "update";
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
