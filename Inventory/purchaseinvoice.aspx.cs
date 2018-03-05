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

public partial class Inventory_vendor : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillsupplier();
            vendor();
        }

    }
    private void vendor()
    {
        DataAccess da = new DataAccess();
        string sql = "select convert(varchar(10),dtinvoicedate,103) as invoicedate, * from tblvendor";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grdvendor.DataSource = ds.Tables[0];
        grdvendor.DataBind();
    }
    
    protected void fillsupplier()
    {
        string sql = "select strvendorname from tblvendormaster";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drp_supplier.DataSource = ds;
        drp_supplier.DataTextField = "strvendorname";
        drp_supplier.DataValueField = "strvendorname";
        drp_supplier.DataBind();
     }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spvendor", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@strinvoiceno", txtinvoiceno.Text.Trim());
            RegCommand.Parameters.Add("@dtinvoicedate", txtinvoicedate.Text.Trim());
            RegCommand.Parameters.Add("@strsuppliername", drp_supplier.Text.Trim());
            RegCommand.Parameters.Add("@numamount", txtamount.Text.Trim());
            RegCommand.Parameters.Add("@numtax", txttax.Text.Trim());
            RegCommand.Parameters.Add("@numgrandtotal", txtgrandtotal.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            clear();
            vendor();
        }
        catch
        {
            MsgBox.alert("Enter The values Properly");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();  
    }
    protected void clear()
    {
        fillsupplier();
        txtinvoiceno.Text = "";
        txtinvoicedate.Text = "";
        txtamount.Text = "";
        txttax.Text = "";
        txtgrandtotal.Text = "";
        btnSave.Text = "Save";
    }
    protected void grdvendor_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblvendor where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        vendor();
    }
    protected void grdvendor_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtinvoiceno.Text = e.Item.Cells[1].Text;
        txtinvoicedate.Text = e.Item.Cells[7].Text;
        drp_supplier.SelectedValue = e.Item.Cells[3].Text;
        txtamount.Text = e.Item.Cells[4].Text;
        txttax.Text = e.Item.Cells[5].Text;
        txtgrandtotal.Text = e.Item.Cells[6].Text;
        btnSave.Text = "update";
    }
    
}
