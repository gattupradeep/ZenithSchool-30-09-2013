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

public partial class admin_Admin_board : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillBoard();
        }
    }

    private void fillBoard()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblboard";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgboard.DataSource = ds.Tables[0];
        dgboard.DataBind();
        allclear();
    }

    protected void dgboard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtboard.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
    protected void dgboard_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblboard where id=" + e.Item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblboard", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 215);
        da.ExceuteSqlQuery(sql);
        fillBoard();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("Board_I", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@ID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@ID", Session["ID"].ToString());
        }
        RegCommand.Parameters.Add("@boardname", txtboard.Text.Trim());
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblboard", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 215);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblboard", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 215);
        }
        fillBoard();
    }

    protected void allclear()
    {
        txtboard.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }
}