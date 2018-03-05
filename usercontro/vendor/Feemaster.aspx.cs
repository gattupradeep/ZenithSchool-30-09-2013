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

public partial class school_Feemaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblfeemaster";
        ds = da.ExceuteSql(sql);
        dgfee.DataSource = ds;
        dgfee.DataBind();
        Clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);       
        conn.Open();
        command = new SqlCommand("SPfeemaster", conn);
        command.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intID", "0");
        }
        else
        {
            command.Parameters.Add("@intID", Session["intID"].ToString());
        }
        command.Parameters.Add("@strfeename",txtfee.Text.Trim());
        command.Parameters.Add("@intschool","1");
        command.ExecuteNonQuery();
        conn.Close();
        fillgrid();
        Clear();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtfee.Text = "";
        btnSave.Text = "Save";
    }
    protected void dgfee_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "delete tblfeemaster where intID=" + e.Item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch { }
    }
    protected void dgfee_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            Session["intID"] = e.Item.Cells[0].Text;
            txtfee.Text = e.Item.Cells[1].Text;
            btnSave.Text = "Update";
        }
        catch { }

    }
}
