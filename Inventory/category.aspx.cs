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

public partial class Inventory_category : System.Web.UI.Page
{
   public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
   public SqlCommand cmd;
   public DataAccess da;
   public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillBoard();
        }
    }

    private void fillBoard()
    {
        DataAccess da = new DataAccess();        
        string sql = "select * from tblitemcategory";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgd_category.DataSource = ds.Tables[0];
        dgd_category.DataBind();
        allclear();
    }

    protected void dgboard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtboard.Text = e.Item.Cells[1].Text;
        btn_Save.Text = "Update";
    }
    protected void dgboard_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblitemcategory where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillBoard();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spitemcategory", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btn_Save.Text == "Save")
            {
               RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
               RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@strcategory", txtboard.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            fillBoard();
        }
        catch 
        {
            MsgBox1.alert("Item Category Already Exists!");
        }
    }

    protected void allclear()
    {
        txtboard.Text = "";
        btn_Save.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }
}