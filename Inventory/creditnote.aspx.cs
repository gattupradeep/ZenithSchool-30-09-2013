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

public partial class Inventory_creditnote : System.Web.UI.Page
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
            credit();
        }
    }
        private void credit()
        {
            DataAccess da = new DataAccess();
            string sql = "select convert(varchar(10),dtinvoicedate,103) as invoicedate, * from tblcreditnote";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            grdcredit.DataSource = ds.Tables[0];
            grdcredit.DataBind();
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
            RegCommand = new SqlCommand("spcreditnote", Conn);
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
            RegCommand.ExecuteNonQuery();
            credit();
            Conn.Close();
            clear();
           
            
        }
        catch
        {
            MsgBox.alert("plese enter Proper Value in Amount and Tax Field");
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
            btnSave.Text = "Save";
        }
    protected void grdcredit_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblcreditnote where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        credit();
    }
    protected void grdcredit_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtinvoiceno.Text = e.Item.Cells[1].Text;
        txtinvoicedate.Text = e.Item.Cells[2].Text;
        drp_supplier.SelectedValue = e.Item.Cells[3].Text;
        txtamount.Text = e.Item.Cells[4].Text;
        txttax.Text = e.Item.Cells[5].Text;
        btnSave.Text = "update";
     }

   
}

