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

public partial class school_noticename : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            Clear();
        }
    }
    private void fillgrid()
    {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select * from tblnoticeboard  where intschool=1";
            ds = da.ExceuteSql(sql);
            dgnoticename.DataSource = ds;
            dgnoticename.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        conn.Open();
        command = new SqlCommand("SPnoticename", conn);
        param = command.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        command.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intID", "0");
        }
        else
        {
            command.Parameters.Add("@intID", Session["intID"].ToString());
        }
        command.Parameters.Add("@intschool", "1");
        command.Parameters.Add("@strnoticename", txtnotice.Text.ToString());
        command.ExecuteNonQuery();
        conn.Close();
        Clear();
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtnotice.Text = "";
        btnSave.Text = "Save";
    }
    protected void dgnoticename_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblnoticeboard where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
    protected void dgnoticename_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtnotice.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";  
    }
}
