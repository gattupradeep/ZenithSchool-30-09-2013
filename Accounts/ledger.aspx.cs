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

public partial class fee_management_ledger : System.Web.UI.Page
{
    public string sql;
    public DataSet ds;
    public DataAccess da;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgroups();
            fillgrid();
        }

    }

    protected void fillgroups()
    { 
        sql = "select intid,strgroupname from tblgroups where intschool=" + Session["SchoolID"].ToString() + " and intid >= 4 group by intid,strgroupname";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlgroups.DataSource = ds;
        ddlgroups.DataTextField = "strgroupname";
        ddlgroups.DataValueField = "intid";
        ddlgroups.DataBind();
        ListItem list = new ListItem("-Select-", "0");
        ddlgroups.Items.Insert(0, list);
    }

    protected void fillgrid()
    {
        sql = "select distinct CONVERT(varchar(50),a.dtopeningdate,103) as dates, a.*,b.strgroupname from tblledger a,tblgroups b";
        sql += " where b.intid=a.intgroup and b.intid > 4 and a.intschool=" + Session["SchoolID"].ToString();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgd_ledger.DataSource = ds.Tables[0];
            dgd_ledger.DataBind();
        }
       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        cmd = new SqlCommand("spledger", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        if (int.Parse(ddlgroups.SelectedValue.ToString()) > 0)
        {
            if (btn_Save.Text == "Save")
            {
                cmd.Parameters.Add("@intid", "0");
            }
            else
            {
                cmd.Parameters.Add("@intid", Session["intid"].ToString());
            }
            cmd.Parameters.Add("@intgroup", ddlgroups.SelectedValue);
            cmd.Parameters.Add("@strledgername", txtledger.Text.Trim());
            cmd.Parameters.Add("@intopeningbalance", txtopenbalance.Text.Trim());
            cmd.Parameters.Add("@dtopeningdate", txtopendate.Text.Trim());
            cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            cmd.Parameters.Add("@straddress", txtaddress.Text.Trim());
            cmd.Parameters.Add("@strphone", txtphoneno.Text.Trim());
            cmd.Parameters.Add("@strmobileno", txtmobile.Text.Trim());
            cmd.Parameters.Add("@stremailid", txtemail.Text.Trim());
            cmd.ExecuteNonQuery();
            conn.Close();
            clear();
            fillgrid();
        }
        else
        {

        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        fillgroups();
        txtledger.Text = "";
        txtopenbalance.Text = "";
        txtopendate.Text = "";
        txtaddress.Text="";
        txtphoneno.Text="";
        txtmobile.Text="";
        txtemail.Text = "";
        btn_Save.Text = "Save";
    }

    protected void  dgd_ledger_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        da = new DataAccess();
        sql="delete tblledger where intid="+e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }

    protected void dgd_ledger_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        fillgroups();
        ddlgroups.SelectedValue = e.Item.Cells[10].Text;
        txtledger.Text = e.Item.Cells[2].Text;
        txtopenbalance.Text = e.Item.Cells[3].Text;
        txtopendate.Text = e.Item.Cells[11].Text;
        txtaddress.Text = e.Item.Cells[5].Text;
        txtphoneno.Text = e.Item.Cells[6].Text;
        txtmobile.Text = e.Item.Cells[7].Text;
        txtemail.Text = e.Item.Cells[8].Text;
        btn_Save.Text = "Update";
    }
   
}

