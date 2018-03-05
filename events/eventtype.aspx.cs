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

public partial class school_eventtype : System.Web.UI.Page
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
        string sql = "select intID,streventtype from tbleventtype where intschool="+Session["schoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgevent.DataSource = ds;
        dgevent.DataBind();        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txteventtype.Text == "")
        {
            MsgBox.alert("Please enter eventtype before save/update");
        }
        else
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            SqlParameter param;
            SqlParameter OutPutParam;
            Conn.Open();
            RegCommand = new SqlCommand("SPeventtype", Conn);
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
                RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
            }
            RegCommand.Parameters.Add("@intschool", Session["schoolID"].ToString());
            RegCommand.Parameters.Add("@streventtype", txteventtype.Text.Trim());
            RegCommand.ExecuteNonQuery();
            if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
            {
                MsgBox.alert("Event type is already Available!");
                resultlabel.Text = "Same eventtye is already Available!";
            }
            Conn.Close();
            string id = Convert.ToString(OutPutParam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tbleventtype", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 243);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tbleventtype", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 243);
            }
            clear();
            fillgrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully')", true);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        txteventtype.Text = "";
        btnSave.Text = "Save";
    }
    //protected void dgboard_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tbleventtype where intID=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void dgboard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txteventtype.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tbleventtype where intID=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tbleventtype", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),243);
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}
