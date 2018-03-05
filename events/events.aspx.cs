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
using System.Web.Mail;

public partial class school_events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filleventtype();
            fillgrid();
         }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select convert(varchar(10),event_start,103) as event_start, convert(varchar(10),event_end,103) as event_end, * from tblevents where intschool=" + Session["schoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgevents.DataSource = ds;
            dgevents.DataBind();
        }
    }
    
    protected void filleventtype()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tbleventtype where intschool='"+Session["schoolID"].ToString()+"'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddleventtype.DataSource = ds;
        ddleventtype.DataTextField = "streventtype";
        ddleventtype.DataValueField = "streventtype";
        ddleventtype.DataBind();
        ListItem list = new ListItem("--Select--", "0");
        ddleventtype.Items.Insert(0, list);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    
    {
        try
        {
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            SqlParameter param;
            SqlParameter OutPutParam;
            Conn.Open();
            RegCommand = new SqlCommand("SPevents", Conn);
            param = RegCommand.Parameters.Add("ReturnValue", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            RegCommand.CommandType = CommandType.StoredProcedure;

            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@event_id", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@event_id", Session["editID"].ToString());
            }
            RegCommand.Parameters.Add("@intschool",Session["SchoolID"].ToString());
            RegCommand.Parameters.Add("@UserId", Session["Userid"].ToString());
            RegCommand.Parameters.Add("@title", ddleventtype.SelectedItem.Text);
            RegCommand.Parameters.Add("@description",txteventname.Text.Trim());
            RegCommand.Parameters.Add("@event_start", DateTime.Parse(txtfromdate.Text).ToString("yyyy/MM/dd"));
            RegCommand.Parameters.Add("@event_end", DateTime.Parse(txttodate.Text).ToString("yyyy/MM/dd"));            
            RegCommand.Parameters.Add("@strbackgroundcolor",txtbackgroundcolor.Value);
            RegCommand.Parameters.Add("@strtextcolor",txttextcolor.Value);
            
            RegCommand.ExecuteNonQuery();
            if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
            {
                MsgBox.alert("Same event is already Available!");                
            }
            Session.Remove("editID");
            Conn.Close();
            string id=Convert.ToString(OutPutParam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblevents", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 244);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblevents", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 244);
            }
            fillgrid();
            clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
        }
        catch
        {
            MsgBox.alert("Please enter Proper Values");
        }
    }    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        txteventname.Text = "";
        btnSave.Text = "Save";
        txtfromdate.Text = "";
        txttodate.Text = "";
        filleventtype();
    }
    //protected void dgevents_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblevents where event_id=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void dgevents_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["editID"] = e.Item.Cells[0].Text;
        filleventtype();
        DataAccess da = new DataAccess();
        DataSet ds;
        string sql = "select *,convert(varchar(10),event_start,103) as fromdate,convert(varchar(10),event_end,103)as todate from tblevents where event_id=" + e.Item.Cells[0].Text;
        ds = new DataSet();
        ds = da.ExceuteSql(sql);        
        ddleventtype.SelectedValue = ds.Tables[0].Rows[0]["title"].ToString();
        txteventname.Text = ds.Tables[0].Rows[0]["description"].ToString();        
        txtfromdate.Text = ds.Tables[0].Rows[0]["fromdate"].ToString();
        txttodate.Text = ds.Tables[0].Rows[0]["todate"].ToString();
        txtbackgroundcolor.Value = ds.Tables[0].Rows[0]["strbackgroundcolor"].ToString();
        txttextcolor.Value = ds.Tables[0].Rows[0]["strtextcolor"].ToString();
        divbackcolor.Attributes.CssStyle.Add("background-color", ds.Tables[0].Rows[0]["strbackgroundcolor"].ToString());
        divtextcolor.Attributes.CssStyle.Add("background-color", ds.Tables[0].Rows[0]["strtextcolor"].ToString());
        btnSave.Text = "Update";
    }
    
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }


    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblevents where event_id=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblevents", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),244);
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}
