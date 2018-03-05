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
            string sql = "select convert(varchar(10),dtdate,111) as date,* from tblnoticeboard  where intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            dgnoticename.DataSource = ds;
            dgnoticename.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtnotice.Text == "")
        {
            msgbox.alert("Please enter notice name");
        }
        if (txtdate.Text == "")
        {
            msgbox.alert("Please enter Date");
        }
        if (txtdate.Text == "" && txtnotice.Text == "")
        {
            msgbox.alert("Please enter Date and notice name");
        }
        if (txtdate.Text != "" && txtnotice.Text != "")
        {
            SqlCommand command;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            SqlParameter OutPutParam;
            conn.Open();
            command = new SqlCommand("SPnoticename", conn);
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
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.Parameters.Add("@strnoticename", txtnotice.Text.Trim());
            command.Parameters.Add("@dtdate", txtdate.Text.Trim());
            command.ExecuteNonQuery();
            if ((int)(command.Parameters["@rc"].Value) == 0)
            {
                msgbox.alert("Already have the data for same thought and date");
            }
            conn.Close();
            string id = Convert.ToString(OutPutParam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 111);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 111);
            }
            Clear();
            fillgrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtnotice.Text = "";
        txtdate.Text = "";
        btnSave.Text = "Save";
    }
    //protected void dgnoticename_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblnoticeboard where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void dgnoticename_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtnotice.Text = e.Item.Cells[1].Text;
        txtdate.Text = e.Item.Cells[2].Text;
        btnSave.Text = "Update";  
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblnoticeboard where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),111);

        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}
