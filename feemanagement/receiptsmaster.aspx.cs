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

public partial class feemanagement_receiptsmaster : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da = new DataAccess();
    public DataSet ds = new DataSet();
    string sql;
    public SqlCommand command = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtprefix.Focus();
            fillgrid();
            clear();
        }
    }
    protected void fillgrid()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from tblreceiptsmaster where intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdreceipts.Visible = true;
                grdreceipts.DataSource = ds;
                grdreceipts.DataBind();
            }
            else
            {
                grdreceipts.Visible = false;
            }
        }
        catch { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtstartNo.Text != "")
            {
                SqlParameter param = new SqlParameter();
                conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("spreceiptmaster", conn);
                command.CommandType = CommandType.StoredProcedure;
                param = command.Parameters.AddWithValue("@rc", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                if (btnSave.Text == "Save")
                {
                    command.Parameters.AddWithValue("@intID", "0");
                }
                else
                {
                    command.Parameters.AddWithValue("@intID", int.Parse(lbleditid.Text.Trim()));
                }
                command.Parameters.AddWithValue("@strprefix", txtprefix.Text.Trim());
                command.Parameters.AddWithValue("@intstartno", txtstartNo.Text.Trim());
                command.Parameters.AddWithValue("@intschool", Session["SchoolID"]);
                command.ExecuteNonQuery();
                if ((int)command.Parameters["@rc"].Value == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Starting number is Already given. if any changes, use edit or delete')", true);
                }
                conn.Close();
                fillgrid();
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please enter Starting number')", true);
            }
            txtprefix.Focus();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter numbers only in vocNo and StartNo')", true);
            txtprefix.Focus();
        }
    }
    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
        txtprefix.Focus();
    }
    protected void clear()
    {
        try
        {
            txtprefix.Text = "";
            txtstartNo.Text = "";
            btnSave.Text = "Save";
        }
        catch { }
    }
    protected void grdreceipts_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            lbleditid.Text = "";
            lbleditid.Text = e.Item.Cells[0].Text;
            txtprefix.Text = e.Item.Cells[1].Text;
            txtstartNo.Text = e.Item.Cells[2].Text;
            btnSave.Text = "Update";
            txtprefix.Focus();
        }
        catch { }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton btnimage = (ImageButton)sender;
            TableCell cell = btnimage.Parent as TableCell;
            DataGridItem Item = cell.Parent as DataGridItem;
            da = new DataAccess();
            sql = "";
            sql = "delete tblreceiptsmaster where intschool=" + Session["SchoolID"] + " and intid=" + Item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            fillgrid();
            grdreceipts.Focus();
        }
        catch { }
    }
}
