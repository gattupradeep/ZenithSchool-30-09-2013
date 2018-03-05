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

public partial class transport_routemaster : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            fillgrid();
            filldriver();
            fillvehicle();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.strvehicleno,b.strdrivername,c.* from tblvehiclemaster a,tbldriver b,tblroute c where c.intdriver= b.intid and c.intvehicle=a.intid and  a.intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgroute.DataSource = ds;
        dgroute.DataBind();
    }

    private void filldriver()
    {
        string sql;
        sql = "select strdrivername,intid from tbldriver where intschool=" + Session["SchoolID"].ToString();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddldriver.DataSource = ds;
        ddldriver.DataTextField = "strdrivername";
        ddldriver.DataValueField = "intid";
        ddldriver.DataBind();
    }
   private void fillvehicle()
    {
        string sql;
        sql = "select strvehicleno,intid from tblvehiclemaster where intschool=" + Session["SchoolID"].ToString();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlvehicle.DataSource = ds;
        ddlvehicle.DataTextField = "strvehicleno";
        ddlvehicle.DataValueField = "intid";
        ddlvehicle.DataBind();       
    }
    private void Clear()
    {
        txtroutename.Text = "";
        txtstartsat.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        da = new DataAccess();
        ds = new DataSet();
        if (btnSave.Text == "Save")
        {
            strsql = "select * from tblroute where strroutename='" + txtroutename.Text + "' and intschool=" + Session["SchoolID"].ToString();
        }
        else
        {
            strsql = "select * from tblroute where strroutename='" + txtroutename.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and intid !=" + hdnid.Value;
        }
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            msgbox.alert("Route name already Exists!");
        }
        else
        {
            try
            {
                SqlCommand RegCommand;
                //SqlParameter OutPutParam;
                SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                Conn.Open();
                RegCommand = new SqlCommand("sproute", Conn);
                RegCommand.CommandType = CommandType.StoredProcedure;
                //OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
                //OutPutParam.Direction = ParameterDirection.Output;
                if (btnSave.Text == "Save")
                {
                    RegCommand.Parameters.Add("@intID", "0");
                }
                else
                {
                    RegCommand.Parameters.Add("@intID", hdnid.Value);
                }
                RegCommand.Parameters.Add("@strroutename", txtroutename.Text);
                RegCommand.Parameters.Add("@intdriver", ddldriver.SelectedValue);
                RegCommand.Parameters.Add("@intvehicle", ddlvehicle.SelectedValue);
                RegCommand.Parameters.Add("@strstartsat", txtstartsat.Text);
                RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                RegCommand.ExecuteNonQuery();
                Conn.Close();
                Clear();
                fillgrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
            }
            catch
            {
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }     
   
    //protected void dgroute_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string sql = "delete tblroute where intid=" + e.Item.Cells[0].Text;
    //    cmd = new SqlCommand(sql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    fillgrid();
    //    Clear();
    //}
    protected void dgroute_EditCommand(object source, DataGridCommandEventArgs e)
    {
        hdnid.Value = e.Item.Cells[0].Text;
        txtroutename.Text = e.Item.Cells[1].Text;
        ddldriver.Text = e.Item.Cells[4].Text;
        ddlvehicle.Text = e.Item.Cells[5].Text;
        txtstartsat.Text = e.Item.Cells[6].Text;
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
            string sql = "delete tblroute where intid=" + item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            Functions.UserLogs(Session["UserID"].ToString(), "tblroute", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),117);
            fillgrid();
            Clear();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
        }
       
    }
}
