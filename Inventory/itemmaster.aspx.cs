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

public partial class Inventory_itemmaster : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillItemMaster();
            fillunit();
            fillcategory();
        }
    }

    private void fillItemMaster()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.intid,a.strcategory,c.intid as id,b.strunitname,b.intid,c.intitemcategory,c.stritemname,c.intunit,c.intsalesrate from tblitemcategory a,tblunitmaster b,tblitemmaster c where a.intid=c.intitemcategory and b.intid=c.intunit";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        GrditemMaster.DataSource = ds.Tables[0];
        GrditemMaster.DataBind();
        clear();
    }

    protected void fillunit()
    {
        string sql = "select * from tblunitmaster";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drp_unit.DataSource = ds;
        drp_unit.DataTextField = "strunitname";
        drp_unit.DataValueField = "intid";
        drp_unit.DataBind();
    }
    protected void fillcategory()
    {
        string sql = "select * from tblitemcategory";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drp_category.DataSource = ds;
        drp_category.DataTextField = "strcategory";
        drp_category.DataValueField = "intid";
        drp_category.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spitemmaster", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btn_Save.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@intitemcategory", drp_category.SelectedValue.Trim());
            RegCommand.Parameters.Add("@stritemname", txt_itemname.Text.Trim());
            RegCommand.Parameters.Add("@intunit", drp_unit.SelectedValue.Trim());
            RegCommand.Parameters.Add("@intsalesrate", txt_salesrate.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            fillItemMaster();
        }
        catch
        {
            MsgBox.alert("Enter Sales Rate value");
        }

    }
   
     protected void clear()
    {
        fillunit();
        fillcategory();
        txt_itemname.Text = "";
        txt_salesrate.Text = "";
        btn_Save.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void GrditemMaster_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblitemmaster where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillItemMaster();

    }
    protected void GrditemMaster_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        drp_category.SelectedValue = e.Item.Cells[5].Text;
        txt_itemname.Text = e.Item.Cells[2].Text;
        drp_unit.SelectedValue = e.Item.Cells[6].Text;
        txt_salesrate.Text = e.Item.Cells[4].Text;
        btn_Save.Text = "Update";

    }
}