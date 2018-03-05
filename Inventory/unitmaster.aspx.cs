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

public partial class Inventory_unitmaster : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillUnitName();
        }
    }

    private void fillUnitName()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblunitmaster";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        GrdunitMaster.DataSource = ds.Tables[0];
        GrdunitMaster.DataBind();
        clear();
    }

    protected void dgboard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txt_unitname.Text = e.Item.Cells[1].Text;
        btn_Save.Text = "Update";
    }
    protected void dgboard_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblunitmaster where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillUnitName();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spunitmaster", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btn_Save.Text == "Save")
            {
               RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
               RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@strunitname", txt_unitname.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            fillUnitName();
        }
        catch
        {
            MsgBox.alert("alredy Exist");
        }
    }

    protected void clear()
    {
        txt_unitname.Text = "";
        btn_Save.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
}