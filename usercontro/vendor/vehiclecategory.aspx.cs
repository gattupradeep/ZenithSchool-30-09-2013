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

public partial class transport_vehiclecategory : System.Web.UI.Page
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
        string sql = "select * from tblvehiclecategory";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgvehicle.DataSource = ds;
        dgvehicle.DataBind();
        clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        Conn.Open();
        RegCommand = new SqlCommand("SPvehiclecategory", Conn);
        param = RegCommand.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intid", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@strvehiclecategory",txtvehicle.Text.Trim());
        RegCommand.Parameters.Add("@intschool", "0");
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            resultlabel.Text = "Same is already Available!";
        }
        Conn.Close();
        clear();
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        txtvehicle.Text = "";
        btnSave.Text = "Save";  
    }
    protected void dgvehicle_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblvehiclecategory where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
    protected void dgvehicle_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtvehicle.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
}
