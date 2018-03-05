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

public partial class vendor_competitions : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataSet ds;
    public string sql;
    public DataAccess da;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillgrid();
    }
    protected void fillgrid()
    {
        sql = "select * from tblcompetitions";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgcompetition.DataSource = ds.Tables[0];
        dgcompetition.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("spcompetitions", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["ID"].ToString());
        }
        RegCommand.Parameters.Add("@strcompetitiontype", txtcompetition.Text);
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        fillgrid();
        clear();
    }
    protected void clear()
    {
        txtcompetition.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void dgcompetition_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        sql = "delete tblcompetitions where intid=" + e.Item.Cells[0].Text;
        cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
    protected void dgcompetition_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtcompetition.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
        clear();
    }
}
