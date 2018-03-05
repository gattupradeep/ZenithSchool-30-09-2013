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

public partial class fee_management_groups : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    public string sql;

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
        string sql = "select distinct * from tblgroups where intid > 5 and intschool="+Session["schoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgd_groups.DataSource = ds;
            dgd_groups.DataBind();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtgroups.Text == "")
        {
            MsgBox.alert("Enter the group name");
        }
        else
        {
            SqlCommand RegCommand;
            SqlParameter Outputparameter;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spgroups", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            Outputparameter = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
            Outputparameter.Direction = ParameterDirection.Output;
            if (btn_Save.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@intschool", Session["schoolID"].ToString());
            RegCommand.Parameters.Add("@strgroupname", txtgroups.Text.Trim());
            RegCommand.ExecuteNonQuery();
            if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
            {
                MsgBox.alert(" already Exists!");
            }
            Conn.Close();
            fillgrid();
            clear();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        txtgroups.Text = "";
        btn_Save.Text = "Save";
    }

    protected void dgd_groups_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        sql = "";
        DataSet ds=new DataSet();
        sql = "select COUNT(*) as counts from tblledger where intgroup='" + e.Item.Cells[0].Text + "' and intgroup > 5 and intschool='" + Session["schoolID"].ToString() + "'";
        DataAccess da = new DataAccess();
        ds = da.ExceuteSql(sql);
        int counts;
        if (int.Parse(ds.Tables[0].Rows[0]["counts"].ToString()) == 0)
        {
            sql = "delete tblgroups where intid=" + e.Item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        else
        { 
            counts=(int.Parse(ds.Tables[0].Rows[0]["counts"].ToString()));
            sql = "select distinct a.strgroupname from tblgroups a,tblledger b where a.intid='" + e.Item.Cells[0].Text + "'";
            ds = da.ExceuteSql(sql);
            MsgBox.alert("You can not Delete. Because " + counts + " Ledger is under the Group of " + ds.Tables[0].Rows[0]["strgroupname"].ToString() + " ");
        }
    }

    protected void dgd_groups_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        if (int.Parse(e.Item.Cells[0].Text) > 4)
            txtgroups.Text = e.Item.Cells[1].Text;
        else
            MsgBox.alert("You can not Delete or Edit this");
        btn_Save.Text = "Update";
    }
}
