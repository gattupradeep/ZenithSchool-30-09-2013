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

public partial class fee_management_Bankaccount : System.Web.UI.Page
{
    public string sql;
    public DataSet ds;
    public DataAccess da;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            fillaccounttype();
            tractype.Visible = false;
            tractypedropdown.Visible = true;
        }
    }

    protected void drpaccounttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpaccounttype.SelectedValue == "-Others-")
        {
            tractype.Visible = true;
            tractypedropdown.Visible = false;
        }
        else
        {
            tractype.Visible = false;
            tractypedropdown.Visible = true;
        }
    }

    protected void dgd_bankaccount_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtbank.Text = e.Item.Cells[1].Text;
        txtbranch.Text = e.Item.Cells[2].Text;
        txtaccountno.Text = e.Item.Cells[3].Text;
        da = new DataAccess();
        ds = new DataSet();
        sql = "select * from tblbankaccount where intschool=" + Session["schoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string actype = ds.Tables[0].Rows[0]["straccounttype"].ToString();
            DataAccess da1 = new DataAccess();
            sql = "select * from tblaccounttype where intschool=" + Session["schoolID"].ToString();
            ds = da1.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
                if (ds.Tables[0].Rows[0]["straccounttype"].ToString() == actype)
                {
                    tractype.Visible = false;
                    tractypedropdown.Visible = true;
                    drpaccounttype.SelectedValue = e.Item.Cells[4].Text;
                }
                else
                {
                    tractype.Visible = true;
                    tractypedropdown.Visible = false;
                    txtaccounttype.Text = e.Item.Cells[4].Text;
                }
        }
        txtholdername.Text = e.Item.Cells[5].Text;
        txtaddress.Text = e.Item.Cells[6].Text;
        btn_Save.Text = "Update";
    }

    protected void dgd_bankaccount_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        da = new DataAccess();
        sql = "delete tblbankaccount where intid='" + e.Item.Cells[0].Text + "'";
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        conn.Open();
        cmd = new SqlCommand("spbankaccount", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        if (btn_Save.Text == "Save")
        {
            cmd.Parameters.Add("@intid", "0");
        }
        else
        {
            cmd.Parameters.Add("@intid", Session["intid"].ToString());
        }
        cmd.Parameters.Add("@strbankname", txtbank.Text.Trim());
        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        cmd.Parameters.Add("@straddress", txtaddress.Text.Trim());
        cmd.Parameters.Add("@strbranch", txtbranch.Text.Trim());
        if (tractypedropdown.Visible == false)
        {
            cmd.Parameters.Add("@straccounttype", txtaccounttype.Text.Trim());
        }
        else
        {
            cmd.Parameters.Add("@straccounttype", drpaccounttype.SelectedValue.Trim());
        }
        cmd.Parameters.Add("@straccountno", txtaccountno.Text.Trim());
        cmd.Parameters.Add("@straccountholdername", txtholdername.Text.Trim());
        cmd.ExecuteNonQuery();
        conn.Close();

        clear();
        fillgrid();
    }

    protected void clear()
    {
        txtbank.Text = "";
        txtbranch.Text = "";
        txtaccountno.Text = "";
        fillaccounttype();
        txtaccounttype.Text = "";
        txtaddress.Text = "";
        txtholdername.Text = "";
        tractype.Visible = false;
        tractypedropdown.Visible = true;
        btn_Save.Text = "Save";
    }

    protected void fillaccounttype()
    {
        sql = "select * from tblaccounttype";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);

        drpaccounttype.DataTextField = "straccounttype";
        drpaccounttype.DataValueField = "straccounttype";
        drpaccounttype.DataSource = ds;
        drpaccounttype.DataBind();

        ListItem li = new ListItem("-select-", "0");
        drpaccounttype.Items.Insert(0, li);
    }

    protected void fillgrid()
    {
        sql = "select * from tblbankaccount where intschool='"+Session["schoolID"].ToString()+"'";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgd_bankaccount.DataSource = ds.Tables[0];
            dgd_bankaccount.DataBind();
        }
    }
}
