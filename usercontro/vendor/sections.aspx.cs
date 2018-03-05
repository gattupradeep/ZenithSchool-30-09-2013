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

public partial class admin_Admin_sections : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void dgboard_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblsection where intID=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);

        fillgrid();
    }
    protected void dgboard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtsubject.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("Sections_I", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;

        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
        }
        RegCommand.Parameters.Add("@strsection", txtsubject.Text.Trim());
        RegCommand.ExecuteNonQuery();

        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Section already Exists!");
        }
        
        Conn.Close();
        Clear();
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtsubject.Text = "";
        btnSave.Text = "Save";
    }
    private void fillgrid()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblsection";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgboard.DataSource = ds.Tables[0];
            dgboard.DataBind();
        }
        catch { }

        Clear();
    }
}
