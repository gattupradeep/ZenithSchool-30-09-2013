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

public partial class vendor_classtype : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
        }
    }

    private void fillstandard()
    {
        try
        {
            string sql;
                sql = "select * from tblclasstype";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgstandardtype.DataSource = ds;
            dgstandardtype.DataBind();
            allclear();
        }
        catch { }
    }

    protected void allclear()
    {
        txtstandardtype.Text = "";
        btnSave.Text = "Save";
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }

    protected void dgclasstype_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "delete tblclasstype where intid=" + e.Item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            fillstandard();
        }
        catch { }
    }
    protected void dgclasstype_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtstandardtype.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("spclasstype", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["ID"].ToString());
        }
            RegCommand.Parameters.Add("@strclasstype", txtstandardtype.Text);
        RegCommand.ExecuteNonQuery();
        Conn.Close();

        fillstandard();
    }
}