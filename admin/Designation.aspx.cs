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

public partial class admin_Admin_Designation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldesig();
        }
    }

    private void filldesig()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select * from tbldesignation where intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            dgdesig.DataSource = ds;
            dgdesig.DataBind();
        }
        catch { }

        Clear();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtdesig.Text == "")
        {
            msgbox.alert("Enter Designation name");
        }
        else
        {
            SqlCommand command;
            SqlParameter OutPutParam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("Spdesignation", conn);
            command.CommandType = CommandType.StoredProcedure;
            OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save")
            {
                command.Parameters.Add("@intID", "0");
            }
            else
            {
                command.Parameters.Add("@intID", Session["intid"].ToString());
            }
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.Parameters.Add("@strdesignation", txtdesig.Text.Trim());
            command.ExecuteNonQuery();
            if ((int)(command.Parameters["@rc"].Value) == 0)
            {
                msgbox.alert("Designation already Exists!");
            }
            conn.Close();
            string id = Convert.ToString(OutPutParam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tbldesignation", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 110);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tbldesignation", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 110);
            }
            filldesig();
            Clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();  
    }
    private void Clear()
    {
        txtdesig.Text = "";
        btnSave.Text = "Save";
    }
    //protected void dgdesig_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete tbldesignation where intid=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //    }
    //    catch { }
    //    filldesig();
    //}
    protected void dgdesig_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtdesig.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tbldesignation where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tbldesignation", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),110);

            da.ExceuteSqlQuery(sql);
        }
        catch { }
        filldesig();
    }
}
