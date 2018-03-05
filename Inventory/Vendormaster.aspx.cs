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
using System.Text.RegularExpressions;

public partial class Inventory_Vendor_Master : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            vendormaster();
        }
    }
    private void vendormaster()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblvendormaster";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grdvendor.DataSource = ds.Tables[0];
        grdvendor.DataBind();
    }
    protected void btnSaveClick(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spvendormaster", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intid", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@strvendorname",txtname.Text.Trim());
        RegCommand.Parameters.Add("@strcontactperson",txtconperson.Text.Trim());
        RegCommand.Parameters.Add("@straddress",txtaddress.Text.Trim());
        RegCommand.Parameters.Add("@strmobileno", txtmobile.Text.Trim());
        RegCommand.Parameters.Add("@strphoneno",txtphone.Text.Trim());
        RegCommand.Parameters.Add("@strmailid",txtmailid.Text.Trim());
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        clear();
        vendormaster();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();  
    }
    protected void clear()
    {
        txtname.Text = "";
        txtconperson.Text = "";
        txtaddress.Text = "";
        txtmobile.Text = "";
        txtphone.Text = "";
        txtmailid.Text = "";
        btnSave.Text = "Save";
    }
    protected void grdvendor_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblvendormaster where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        vendormaster();
    }
    protected void grdvendor_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtname.Text = e.Item.Cells[1].Text;
        txtconperson.Text = e.Item.Cells[2].Text;
        txtaddress.Text = e.Item.Cells[3].Text;
        txtmobile.Text = e.Item.Cells[4].Text;
        txtphone.Text = e.Item.Cells[5].Text;
        txtmailid.Text = e.Item.Cells[6].Text;      
        btnSave.Text = "update";
    }
}
