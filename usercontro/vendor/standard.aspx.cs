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

public partial class vendor_standard : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void dgstandard_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblstandard where ID=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);

        fillgrid();
    }
    protected void dgstandard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtstandard.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spstandard", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@ID", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@ID", Session["ID"].ToString());
            }
            RegCommand.Parameters.Add("@strstandard", txtstandard.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            Clear();
            fillgrid();
        }
        catch
        {
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void Clear()
    {
        txtstandard.Text = "";
        btnSave.Text = "Save";
    }

    protected void fillgrid()
    {       
            DataAccess da = new DataAccess();
            string sql = "select * from tblstandard";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgstandard.DataSource = ds.Tables[0];
            dgstandard.DataBind();      
    }
}
