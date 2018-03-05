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

public partial class vendor_group : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    private void fillgrid()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblgroup";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dggroup.DataSource = ds.Tables[0];
            dggroup.DataBind();
        }
        catch { }

        Clear();
    }
    private void Clear()
    {
        txtgroup.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;      
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spgroup", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;       
        string sql = "select strgroup from tblgroup where strgroup =  '" + txtgroup.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            msgbox.alert(" Group already exists");
        }
        else
        {

            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@intID", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
            }
            RegCommand.Parameters.Add("@strgroup", txtgroup.Text);
            RegCommand.ExecuteNonQuery();            
            Conn.Close();
            Clear();
            fillgrid();
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void dggroup_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string sql = "delete tblgroup where intid=" + e.Item.Cells[0].Text;
        cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
    protected void dggroup_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtgroup.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
}
