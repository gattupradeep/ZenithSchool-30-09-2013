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

public partial class Leave_schoolleavecategory : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public string strsql;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillleavetype();
            fillgrid();
            txtleave0.Visible = false;
        }

    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from (select *,'paid' as strpaytype from tblschoolleavecategory where intpay=1 and intschool=" + Session["SchoolID"].ToString() + " union all select *,'Unpaid' as strpaytype from tblschoolleavecategory where intpay=0 and intschool=" + Session["SchoolID"].ToString() + ") as a order by strleavetype";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgleavecat.DataSource = ds;
        dgleavecat.DataBind();
        
    }
    protected void fillleavetype()
    {
        DataAccess da = new DataAccess();
        string sql = "select strleavecategory from tblleavecategory";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlleavetype.DataSource = ds;
        ddlleavetype.DataTextField = "strleavecategory";
        ddlleavetype.DataValueField = "strleavecategory";
        ddlleavetype.DataBind();
        ListItem list = new ListItem("-select-", "0");
        ddlleavetype.Items.Insert(0, list);
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (btnadd.Text == "Add New Leave Type")
        {
            btnadd.Text = "Save";
            ddlleavetype.Visible = false;
            txtleave0.Visible = true;
            trpay.Visible = false;
            trdeduction.Visible = false;
            btnsubmit.Visible = false;
            trgrid.Visible = false;
        }
        else
        {
            if (txtleave0.Text != "")
            {
                da = new DataAccess();
                strsql = "select * from tblleavecategory where strleavecategory='" + txtleave0.Text + "'";
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MsgBox.alert("Leave Type Already Exists");
                }
                else
                {
                    strsql = "insert into tblleavecategory(strleavecategory)values('" + txtleave0.Text + "')";
                    cmd = new SqlCommand(strsql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    strsql = "select max(intID) as intID from tblleavecategory";
                    DataSet ds2 = new DataSet();
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblleavecategory", ds2.Tables[0].Rows[0]["intID"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),70);
                    conn.Close();
                    clear();
                }
            }
            else
                MsgBox.alert("Please Enter The Leave Type");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                SqlCommand RegCommand;
                SqlParameter OutPutParam;
                SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                Conn.Open();
                RegCommand = new SqlCommand("spschoolleavecategory", Conn);
                RegCommand.CommandType = CommandType.StoredProcedure;
                OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
                OutPutParam.Direction = ParameterDirection.Output;
                if (btnsubmit.Text == "Save")
                {
                    RegCommand.Parameters.Add("@intID", "0");
                }
                else
                {
                    RegCommand.Parameters.Add("@intID", Session["ID"].ToString());
                }
                RegCommand.Parameters.Add("@strleavetype", ddlleavetype.SelectedValue);
                RegCommand.Parameters.Add("@intdeduction", txtdeduction.Text.Trim());
                RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());

                int ch = 0;
                if (rbtpaid.Checked)
                    ch = 1;
                RegCommand.Parameters.Add("@intpay", ch);
                RegCommand.ExecuteNonQuery();
                if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
                {
                    MsgBox.alert("Selected Leave Type Already Exists");
                }
                Conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                if (btnsubmit.Text == "Save")
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolleavecategory", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 70);
                }
                else
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolleavecategory", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 70);
                }
                clear();
                fillgrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
            }
            catch
            {
            }
        }
    }
    protected void clear()
    {
        fillleavetype();
        txtdeduction.Text = "0";
        btnsubmit.Text = "Save";
        btnadd.Text = "Add New Leave Type";
        ddlleavetype.Visible = true;
        txtleave0.Text = "";
        txtleave0.Visible = false;
        trpay.Visible = true;
        trdeduction.Visible = true;
        btnsubmit.Visible = true;
        trgrid.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    //protected void dgleavecat_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblschoolleavecategory where intID=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void dgleavecat_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;      
        ddlleavetype.SelectedValue = e.Item.Cells[1].Text;
        if (e.Item.Cells[2].Text == "1")
        {
            rbtpaid.Checked = true;
            rbtunpaid.Checked = false;
        }
        else
        {
            rbtpaid.Checked = false;
            rbtunpaid.Checked = true;
        }
        txtdeduction.Text = e.Item.Cells[4].Text;        
        btnsubmit.Text = "Update";
    }
    protected void ddlleavetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (btnsubmit.Text == "Save")
        {
            da = new DataAccess();
            ds = new DataSet();
            string sql = "select strleavetype from tblschoolleavecategory where intschool='" + Session["schoolID"].ToString() + "' and strleavetype='" + ddlleavetype.SelectedValue + "'";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MsgBox.alert("Already Exist the entry for selected leavetype");
            }
        }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblschoolleavecategory where intID=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolleavecategory", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),70);

        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}
