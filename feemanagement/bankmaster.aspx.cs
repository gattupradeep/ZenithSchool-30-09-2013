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

public partial class feemanagement_bankmaster : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drp_pay_mode.Focus();
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
            sql = "select distinct a.intid,a.strledger,a.intgroups,a.intfeetype,b.strgroupname,c.strfeetype,a.strpaymode from tblbankmaster a,";
            sql += " tblgroups b,tblfeemaster c where a.intgroups=b.intid and a.intfeetype=c.intID and a.intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd_bankmaster.DataSource = ds;
                grd_bankmaster.DataBind();
                grd_bankmaster.Visible = true;
            }
            else
                grd_bankmaster.Visible = false;
        }
        catch { }
    }
    protected void fillledger()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            if (drp_pay_mode.SelectedIndex > 0 && drp_pay_mode.SelectedIndex != 1)
            {
                sql = "select * from tblbankaccount where intschool=" + Session["SchoolID"];
                ds = da.ExceuteSql(sql);
                drp_ledger.DataSource = ds;
                drp_ledger.DataTextField = "straccountno";
                drp_ledger.DataValueField = "straccountno";
            }
            else
            {
                sql = "select * from tblledger where intgroup=5 and intschool=" + Session["SchoolID"];
                ds = da.ExceuteSql(sql);
                drp_ledger.DataSource = ds;
                drp_ledger.DataTextField = "strledgername";
                drp_ledger.DataValueField = "strledgername";
            }
            drp_ledger.DataBind();
            ListItem list = new ListItem("-Select-", "0");
            drp_ledger.Items.Insert(0, list);
            trbankname.Visible = false;
            trbranch.Visible = false;
        }
        catch { }
    }
    protected void fillfeetypes()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from tblfeemaster where intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            drpfeetype.DataSource = ds;
            drpfeetype.DataTextField = "strfeetype";
            drpfeetype.DataValueField = "intid";
            drpfeetype.DataBind();
            ListItem list = new ListItem("-Select-", "0");
            drpfeetype.Items.Insert(0, list);
        }
        catch { }
    }
    protected void clear()
    {
        try
        {
            drp_pay_mode.SelectedIndex = 0;
            fillledger();
            fillfeetypes();
            trbankname.Visible = false;
            trbranch.Visible = false;
            lblbankname1.Text = "";
            lblbranch1.Text = "";
            btnSave.Text = "Enter";
        }
        catch { }
    }
    protected void drp_ledger_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from tblbankaccount where straccountno='" + drp_ledger.SelectedValue + "' and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            if (drp_pay_mode.SelectedIndex > 1 && ds.Tables[0].Rows.Count > 0)
            {
                lblbankname1.Text = ds.Tables[0].Rows[0]["strbankname"].ToString();
                lblbranch1.Text = ds.Tables[0].Rows[0]["strbranch"].ToString();
                trbankname.Visible = true;
                trbranch.Visible = true;
            }
            btnSave.Focus();
        }
        catch { }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (drp_pay_mode.SelectedIndex > 0 && drpfeetype.SelectedIndex > 0 && drp_ledger.SelectedIndex > 0)
            {
                SqlParameter param;
                conn.Open();
                SqlCommand command = new SqlCommand("spbankmaster", conn);
                command.CommandType = CommandType.StoredProcedure;
                param = command.Parameters.AddWithValue("@rc", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                if (btnSave.Text == "Enter")
                {
                    command.Parameters.AddWithValue("@intid", "0");
                }
                else
                {
                    command.Parameters.AddWithValue("@intid", int.Parse(lbleditid.Text.Trim()));
                }
                command.Parameters.AddWithValue("@intgroups", 1);
                command.Parameters.AddWithValue("@intfeetype", drpfeetype.SelectedValue.Trim());
                command.Parameters.AddWithValue("@intschool", Session["SchoolID"]);
                command.Parameters.AddWithValue("@strledger", drp_ledger.SelectedValue.Trim());
                command.Parameters.AddWithValue("@strpaymode", drp_pay_mode.SelectedValue.Trim());
                command.ExecuteNonQuery();
                if ((int)(command.Parameters["@rc"].Value) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Already Exist')", true);
                }
                conn.Close();
                fillgrid();
                clear();
                btnClear.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Required Data for all field')", true);
            }
        }
        catch { }
    }
    protected void grd_bankmaster_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            da = new DataAccess();
            sql = "delete tblbankmaster where intid=" + e.Item.Cells[0].Text;
            ds = da.ExceuteSql(sql);
            fillgrid();
        }
        catch { }
    }
    protected void grd_bankmaster_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            lbleditid.Text = "";
            lbleditid.Text = e.Item.Cells[0].Text;
            lbl_group.Text = e.Item.Cells[1].Text;
            drp_pay_mode.SelectedValue = e.Item.Cells[4].Text;
            fillledger();
            drp_ledger.SelectedValue = e.Item.Cells[5].Text;
            fillfeetypes();
            drpfeetype.SelectedValue = e.Item.Cells[6].Text;
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from tblbankaccount where straccountno='" + drp_ledger.SelectedValue + "' and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbankname1.Text = ds.Tables[0].Rows[0]["strbankname"].ToString();
                lblbranch1.Text = ds.Tables[0].Rows[0]["strbranch"].ToString();
                trbankname.Visible = true;
                trbranch.Visible = true;
            }
            btnSave.Text = "Update";
        }
        catch { }
    }
    protected void drpfeetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillledger();
            fillgrid();
            drp_ledger.Focus();
            trbankname.Visible = false;
            trbranch.Visible = false;
        }
        catch { }
    }
    protected void drp_pay_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillfeetypes();
            fillledger();
            drpfeetype.Focus();
        }
        catch { }
    }
}
