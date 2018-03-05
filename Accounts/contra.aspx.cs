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

public partial class fee_management_contra : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    public string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgroup();
            fillledger();

            filltogroup();
            fillledger2();
            fillgrid();
        }
    }

    protected void drp_Fromgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillledger();
    }

    protected void drp_Fromledger_SelectedIndexChanged(object sender, EventArgs e)
    {
        filltogroup();
        fillledger2();
    }

    protected void drptogroup_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fillledger2();
    }

    protected void grd_trasaction_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        da = new DataAccess();
        sql = "delete tblaccounttransaction where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }

    protected void grd_trasaction_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        fillgroup();
        drp_Fromgroup.SelectedValue = e.Item.Cells[3].Text;
        fillledger();
        drp_Fromledger.SelectedValue = e.Item.Cells[5].Text;
        filltogroup();
        drptogroup.SelectedValue = e.Item.Cells[4].Text;
        fillledger2();
        drptoledger.SelectedValue = e.Item.Cells[6].Text;
        txtamount.Text = e.Item.Cells[7].Text;
        txtnarration.Text = e.Item.Cells[8].Text;
        btnSave.Text = "Update";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spaccounttransaction", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Enter")
        {
            RegCommand.Parameters.Add("@intid", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@intschool", Session["schoolID"].ToString());
        RegCommand.Parameters.Add("@intfromgroups", drp_Fromgroup.SelectedValue);
        RegCommand.Parameters.Add("@intfromledgers", drp_Fromledger.SelectedValue);
        RegCommand.Parameters.Add("@inttogroups", drptogroup.SelectedValue);
        RegCommand.Parameters.Add("@inttoledgers", drptoledger.SelectedValue);
        RegCommand.Parameters.Add("@strmodeofpayment", "0");
        RegCommand.Parameters.Add("@strbankname", "0");
        RegCommand.Parameters.Add("@strbranchname", "0");
        RegCommand.Parameters.Add("@strchequeorddno", "0");
        RegCommand.Parameters.Add("@strchequeordddate", "0");
        RegCommand.Parameters.Add("@intamount", txtamount.Text.Trim());
        RegCommand.Parameters.Add("@strnarration", txtnarration.Text.Trim());
        RegCommand.Parameters.Add("@dttransactiondate", DateTime.Now.ToString());
        RegCommand.Parameters.Add("@strmodeoftransaction", "Contra");
        RegCommand.Parameters.Add("@dtuptodate", DateTime.Now.ToString());
        RegCommand.Parameters.Add("@intreceiptno", "0");
        RegCommand.Parameters.Add("@intreceiptmode", "0");
        RegCommand.Parameters.Add("@intcancel", "0");
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        fillgrid();
        clear();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void fillgroup()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblgroups where intid in(3,5) and intschool=" + Session["schoolID"].ToString();
        ds = da.ExceuteSql(sql);
        drp_Fromgroup.DataSource = ds;
        drp_Fromgroup.DataTextField = "strgroupname";
        drp_Fromgroup.DataValueField = "intid";
        drp_Fromgroup.DataBind();
        ListItem list = new ListItem("-Select-", "0");
        drp_Fromgroup.Items.Insert(0, list);
    }

    protected void filltogroup()
    {
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        string sql = "select distinct * from tblgroups where intid in(3,5) and intschool=" + Session["schoolID"].ToString();
        ds = da.ExceuteSql(sql);
        drptogroup.DataSource = ds;
        drptogroup.DataTextField = "strgroupname";
        drptogroup.DataValueField = "intid";
        drptogroup.DataBind();
        ListItem list = new ListItem("-Select-", "0");
        drptogroup.Items.Insert(0, list);
    }

    protected void fillledger()
    {
        string sql; 
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();

        drp_Fromledger.Items.Clear();
        if (int.Parse(drp_Fromgroup.SelectedValue.ToString()) == 3)
        {
            sql = "select intid,strbankname + '-' + straccountno as stracc from tblbankaccount where intschool=" + Session["schoolID"].ToString();
            ds = da.ExceuteSql(sql);
            drp_Fromledger.DataSource = ds;
            drp_Fromledger.DataTextField = "stracc";
            drp_Fromledger.DataValueField = "intid";
            drp_Fromledger.DataBind();
        }
        else 
        {
            sql = "select intid,strledgername from tblledger where intschool=" + Session["schoolID"].ToString() + " and intgroup=" + drp_Fromgroup.SelectedValue + "";
            ds = da.ExceuteSql(sql);
            drp_Fromledger.DataSource = ds;
            drp_Fromledger.DataTextField = "strledgername";
            drp_Fromledger.DataValueField = "intid";
            drp_Fromledger.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drp_Fromledger.Items.Insert(0, list);
    }

    protected void fillledger2()
    {
        string sql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();

        drptoledger.Items.Clear();
        if (drptogroup.SelectedValue == "3")
        {
            if (drp_Fromgroup.SelectedValue == "3")
            {
                sql = "select intid,strbankname + '-' + straccountno as stracc from tblbankaccount where intid <>" + drp_Fromledger.SelectedValue + "  and intschool=" + Session["schoolID"].ToString();
                ds = da.ExceuteSql(sql);
                drptoledger.DataSource = ds;
                drptoledger.DataTextField = "stracc";
                drptoledger.DataValueField = "intid";
                drptoledger.DataBind();
            }
            else
            {
                sql = "select intid,strbankname + '-' + straccountno as stracc from tblbankaccount where intschool=" + Session["schoolID"].ToString();
                ds = da.ExceuteSql(sql);
                drptoledger.DataSource = ds;
                drptoledger.DataTextField = "stracc";
                drptoledger.DataValueField = "intid";
                drptoledger.DataBind();
            }
        }
        else if (drptogroup.SelectedValue == "5")
        {
            if (drp_Fromgroup.SelectedValue == "5")
            {
                sql = "select intid,strledgername from tblledger where intid <>" + drp_Fromledger.SelectedValue + " and intschool=" + Session["schoolID"].ToString() + " and intgroup=" + drptogroup.SelectedValue + "";
                ds = da.ExceuteSql(sql);
                drptoledger.DataSource = ds;
                drptoledger.DataTextField = "strledgername";
                drptoledger.DataValueField = "intid";
                drptoledger.DataBind();
            }
            else
            {
                sql = "select intid,strledgername from tblledger where intschool=" + Session["schoolID"].ToString() + " and intgroup=" + drptogroup.SelectedValue + "";
                ds = da.ExceuteSql(sql);
                drptoledger.DataSource = ds;
                drptoledger.DataTextField = "strledgername";
                drptoledger.DataValueField = "intid";
                drptoledger.DataBind();
            }
        }
       
        ListItem list = new ListItem("-Select-", "0");
        drptoledger.Items.Insert(0, list);
    }

    protected void fillgrid()
    {
        sql = "";
        string serchcond = "";

        DataSet acctds = new DataSet();
        DataSet ledgds = new DataSet();
        DataSet bankds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select intid,intschool,strmodeofpayment,intfromgroups,inttogroups,intfromledgers,inttoledgers,intamount,";
        sql += " strnarration,strbankname,strbranchname,strchequeorddno,strchequeordddate,'' as fromledger,'' as toledger,";
        sql += " CONVERT(VARCHAR(10), dttransactiondate, 103) AS transdt from tblaccounttransaction";
        sql += " where strmodeoftransaction ='Contra' and intschool=" + Session["schoolID"].ToString() + "order by intid desc";
        acctds = da.ExceuteSql(sql);

        sql = "select intid,strledgername from tblledger where intschool=" + Session["schoolID"].ToString() + "";
        ledgds = da.ExceuteSql(sql);

        sql = "select intid,strbankname + '-' + straccountno from tblbankaccount where intschool=" + Session["schoolID"].ToString();
        bankds = da.ExceuteSql(sql);

        for (int i = 0; i < acctds.Tables[0].Rows.Count; i++)
        {
            serchcond = "";
            serchcond = "intid ='" + acctds.Tables[0].Rows[i]["intfromledgers"].ToString() + "'";
            if (int.Parse(acctds.Tables[0].Rows[i]["intfromgroups"].ToString()) == 5)
            {
                DataRow[] frmlegdr = ledgds.Tables[0].Select(serchcond.ToString());
                if (frmlegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["fromledger"] = frmlegdr[0][1].ToString();
                }
            }
            else
            {
                DataRow[] frmlegdr = bankds.Tables[0].Select(serchcond.ToString());
                if (frmlegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["fromledger"] = frmlegdr[0][1].ToString();
                }
            }

            serchcond = "";
            serchcond = "intid ='" + acctds.Tables[0].Rows[i]["inttoledgers"].ToString() + "'";

            if (int.Parse(acctds.Tables[0].Rows[i]["inttogroups"].ToString()) == 5)
            {
                DataRow[] tolegdr = ledgds.Tables[0].Select(serchcond.ToString());
                if (tolegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["toledger"] = tolegdr[0][1].ToString();
                }
            }
            else
            {
                DataRow[] tolegdr = bankds.Tables[0].Select(serchcond.ToString());
                if (tolegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["toledger"] = tolegdr[0][1].ToString();
                }
            }
        }

        grd_contra.DataSource = acctds.Tables[0];
        grd_contra.DataBind();

        //sql = "select distinct a.*, b.intid,b.intamount,b.fromledger,b.strchequeordddate,c.toledger from tblaccounttransaction a,";
        //sql += " (select distinct a.intamount,b.intid, b.fromledger,b.strchequeordddate from tblaccounttransaction a,";
        //sql += " (select distinct b.intid, a.strchequeordddate, b.fromledger from  tblaccounttransaction a,";
        //sql += " (select  a.intid,b.strledgername as fromledger from tblaccounttransaction a, tblledger b where a.intschool=b.intschool";
        //sql += " and a.intfromledgers = b.intid and a.intfromgroups =4) b  where b.intid=a.intid";
        //sql += " union all";
        //sql += " select distinct b.intid,a.strchequeordddate,b.fromledger from  tblaccounttransaction a,";
        //sql += " (select a.intid, b.straccountno as fromledger from tblaccounttransaction a, tblbankaccount b ";
        //sql += " where a.intschool=b.intschool and a.intfromledgers = b.intid and a.intfromgroups =3) b  where b.intid=a.intid) b ";
        //sql += " where b.intid=a.intid) b,";
        //sql += " (select distinct a.intamount,b.intid,b.toledger,b.strchequeordddate from tblaccounttransaction a,";
        //sql += " (select distinct b.intid, a.strchequeordddate, b.toledger from  tblaccounttransaction a,";
        //sql += " (select  a.intid,b.strledgername as toledger from tblaccounttransaction a, tblledger b where a.intschool=b.intschool";
        //sql += " and a.inttoledgers = b.intid and a.inttogroups =4) b  where b.intid=a.intid";
        //sql += " union all";
        //sql += " select distinct b.intid,a.strchequeordddate,b.toledger from  tblaccounttransaction a,";
        //sql += " (select a.intid, b.straccountno as toledger from tblaccounttransaction a, tblbankaccount b";
        //sql += " where a.intschool=b.intschool and a.inttoledgers = b.intid and a.inttogroups =3) b  where b.intid=a.intid) b";
        //sql += " where b.intid=a.intid) c where a.intschool=" + Session["schoolID"].ToString() + " and a.intid=b.intid and a.intid=c.intid";
        //sql += " and strmodeoftransaction ='Contra' order by a.intid desc";
    }

    protected void clear()
    {
        fillgroup();
        fillledger();
        fillledger2();
        filltogroup();
        fillledger2();
        txtamount.Text = "";
        txtnarration.Text="";
        btnSave.Text = "Enter";
    }

   
}
