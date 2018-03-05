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

public partial class admin_housemaster : System.Web.UI.Page
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
        clear();
        sql = "select * from tblschoolhouse";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dghouse.DataSource = ds.Tables[0];
        dghouse.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("spschoolhouse", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["ID"].ToString());
        }
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.Parameters.Add("@strhousename", txthousename.Text);
        RegCommand.Parameters.Add("@strhousecolor", txthousecolor.Text);
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        //if (btnSave.Text == "Save")
        //{
        //    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolhouse", item.Cells[0].Text, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 290);
        //}
        //else
        //{
        //    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolhouse", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 290);
        //}
        fillgrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
    }

    protected void clear()
    {
        txthousecolor.Text = "";
        txthousename.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    //protected void dghouse_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    sql = "delete tblschoolhouse where intid=" + e.Item.Cells[0].Text;
    //    cmd = new SqlCommand(sql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    fillgrid();
    //}
    protected void dghouse_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txthousename.Text = e.Item.Cells[1].Text;
        txthousecolor.Text = e.Item.Cells[2].Text;
        btnSave.Text = "Update";
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        sql = "delete tblschoolhouse where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolhouse", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),290);

        cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
}
