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

public partial class admission_admissioncriteria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SchoolID"] = 17;
            
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select * from tbladmissioncriteria where intschool=" + Session["SChoolID"].ToString();
        ds = da.ExceuteSql(str);
        dgcriteria.DataSource = ds;
        dgcriteria.DataBind();
        clear();
    }
    protected void dgcriteria_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tbladmissioncriteria where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
    protected void dgcriteria_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtcriteria.Text= e.Item.Cells[1].Text;
        txtrank.Text = e.Item.Cells[2].Text;
        btnSave.Text = "Update";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("spadmissioncriteria", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intid", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@strcriteria", txtcriteria.Text.Trim());
        RegCommand.Parameters.Add("@intrank", txtrank.Text.Trim());
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Criteria already Exists!");
        }
        Conn.Close();
        fillgrid();
        clear();
    }
    protected void clear()
    {
        txtcriteria.Text = "";
        txtrank.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
}
