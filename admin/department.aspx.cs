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

public partial class admin_Admin_department : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldepartment();
        }
    }

    private void filldepartment()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tbldepartment where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgdepart.DataSource = ds.Tables[0];
        dgdepart.DataBind();
        allclear();
    }

    protected void dgdepart_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtdapartment.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }

    //protected void dgdepart_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tbldepartment where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    filldepartment();
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("Spdepartment", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@strdepartmentname", txtdapartment.Text.Trim());
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Department already Exists!");
        }
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldepartment", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 109);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldepartment", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 109);
        }
        filldepartment();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
    }

    protected void allclear()
    {
        txtdapartment.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tbldepartment where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tbldepartment", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),109);

        da.ExceuteSqlQuery(sql);
        filldepartment();
    }
}