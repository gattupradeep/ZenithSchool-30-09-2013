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

public partial class school_leavecategory : System.Web.UI.Page
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
        string sql = "select * from tblleavecategory";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgcategory.DataSource = ds.Tables[0];
        dgcategory.DataBind();
        clear();
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        Conn.Open();
        RegCommand = new SqlCommand("SPleavecategory", Conn);
        param = RegCommand.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["ID"].ToString());
        }
        RegCommand.Parameters.Add("@strleavecategory", txtcategory.Text.Trim());
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            resultlabel.Text = "Category already Exists!";
        }
        Conn.Close();
        fillgrid();
        clear();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        txtcategory.Text = "";
        btnSave.Text = "Save";
    }

    protected void dgcategory_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "delete tblleavecategory where intID=" + e.Item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch { }
    }

    protected void dgcategory_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtcategory.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
}
