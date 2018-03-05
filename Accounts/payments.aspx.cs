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

public partial class fee_management_payments : System.Web.UI.Page
{
    public string sql;
    public DataSet ds;
    public DataAccess da;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillledger();
            filltogroup();
            fillledger2();
            unvisiblerow();
            unvisiblerow2();
            fillgrid();
        }
    }

    protected void drp_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_mode.SelectedIndex > 0)
        {
            fillledger();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select a Mode!')", true);
        }
    }

    protected void drp_Fromledger_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_mode.SelectedValue.ToString() == "Cheque/DD")
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            sql = "select intid,strbankname,strbranch from tblbankaccount where intid=" + drp_Fromledger.SelectedValue.ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtbankname.Text = ds.Tables[0].Rows[0]["strbankname"].ToString();
                txtbranch.Text = ds.Tables[0].Rows[0]["strbranch"].ToString();
            }
            chequedelailrowvisible();
        }
    }

    protected void drptogroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillledger2();
    }

    protected void drptogroup_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (drptogroup.SelectedIndex == 1)
        {
            studentrowvisible2();
            standard();
            section();
            student();
        }
        else if (drptogroup.SelectedIndex == 2)
        {
            staffrowvisible2();
            dept();
            designation();
            staffname();
        }
        else
        {
            unvisiblerow2();
            fillledger2();
        }
    }

    protected void drpstandard2_SelectedIndexChanged(object sender, EventArgs e)
    {
        section();
    }

    protected void drpsection2_SelectedIndexChanged(object sender, EventArgs e)
    {
        student();
    }

    protected void drpdept2_SelectedIndexChanged(object sender, EventArgs e)
    {
        designation();
    }

    protected void drpdesignation2_SelectedIndexChanged(object sender, EventArgs e)
    {
        staffname();
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
        drp_mode.SelectedValue = e.Item.Cells[2].Text;
        if (drp_mode.SelectedValue != "Cash")
        {
            chequedelailrowvisible();
            txtbankname.Text = e.Item.Cells[9].Text;
            txtbranch.Text = e.Item.Cells[10].Text;
            txtchequeno.Text = e.Item.Cells[11].Text;
            txtchequedate.Text = e.Item.Cells[12].Text;
        }

        fillledger();
        drp_Fromledger.SelectedValue = e.Item.Cells[5].Text;

        filltogroup();
        drptogroup.SelectedValue = e.Item.Cells[4].Text;
        if (drptogroup.SelectedIndex == 1)
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select b.strstandard,b.strsection from tblaccounttransaction a,tblstudent b where a.inttoledgers=" + e.Item.Cells[6].Text + " and";
            sql += " a.inttogroups=" + e.Item.Cells[4].Text + " and a.intid=" + e.Item.Cells[0].Text + " and b.intid=inttoledgers and a.intschool=" + Session["schoolID"].ToString();
            ds = da.ExceuteSql(sql);
            studentrowvisible2();
            standard();
            drpstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
            section();
            drpsection.SelectedValue = ds.Tables[0].Rows[0]["strsection"].ToString();
            student();
            drpstudentname.SelectedValue = e.Item.Cells[6].Text;
        }
        else if (drptogroup.SelectedIndex == 2)
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select b.intdesignation,b.intdepartment from tblaccounttransaction a,tblemployee b where";
            sql += " a.inttoledgers=" + e.Item.Cells[6].Text + " and a.intid=" + e.Item.Cells[0].Text + " and";
            sql += " a.inttogroups=" + e.Item.Cells[4].Text + " and b.intid=inttoledgers and  a.intschool=" + Session["schoolID"].ToString();
            ds = da.ExceuteSql(sql);
            staffrowvisible2();
            dept();
            drpdept.SelectedValue = ds.Tables[0].Rows[0]["intdepartment"].ToString();
            designation();
            drpdesignation.SelectedValue = ds.Tables[0].Rows[0]["intdesignation"].ToString();
            staffname();
            drpstaffname.SelectedValue = e.Item.Cells[6].Text;
        }
        else
        {
            unvisiblerow1();
            fillledger2();
            drptoledger.SelectedValue = e.Item.Cells[6].Text;
        }
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

        if (btnSave.Text == "Payment")
        {
            RegCommand.Parameters.Add("@intid", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
        }

        RegCommand.Parameters.Add("@intschool", Session["schoolID"].ToString());

        if (drp_mode.SelectedValue.ToString() == "Cash")
        {
            RegCommand.Parameters.Add("@intfromgroups", "5");
        }
        else
        {
            RegCommand.Parameters.Add("@intfromgroups", "3");
        }

        RegCommand.Parameters.Add("@intfromledgers", drp_Fromledger.SelectedValue);
        RegCommand.Parameters.Add("@inttogroups", drptogroup.SelectedValue);

        if (drptogroup.SelectedIndex == 1)
        {
            RegCommand.Parameters.Add("@inttoledgers", drpstudentname.SelectedValue);
        }
        else if (drptogroup.SelectedIndex == 2)
        {
            RegCommand.Parameters.Add("@inttoledgers", drpstaffname.SelectedValue);
        }
        else
        {
            RegCommand.Parameters.Add("@inttoledgers", drptoledger.SelectedValue);
        }

        RegCommand.Parameters.Add("@strmodeofpayment", drp_mode.SelectedValue);
        RegCommand.Parameters.Add("@strnarration", txtnarration.Text.Trim());

        if (drp_mode.SelectedValue == "Cheque/DD")
        {
            RegCommand.Parameters.Add("@strbankname", txtbankname.Text.Trim());
            RegCommand.Parameters.Add("@strbranchname", txtbranch.Text.Trim());
            RegCommand.Parameters.Add("@strchequeorddno", txtchequeno.Text.Trim());
            RegCommand.Parameters.Add("@strchequeordddate", txtchequedate.Text.Trim());
        }
        else
        {
            RegCommand.Parameters.Add("@strbankname", "0");
            RegCommand.Parameters.Add("@strbranchname", "0");
            RegCommand.Parameters.Add("@strchequeorddno", "0");
            RegCommand.Parameters.Add("@strchequeordddate", "0");
        }

        RegCommand.Parameters.Add("@intamount", txtamount.Text.Trim());
        RegCommand.Parameters.Add("@dttransactiondate", DateTime.Now.ToString());
        RegCommand.Parameters.Add("@strmodeoftransaction", "Payments");
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

    protected void fillledger()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        drp_Fromledger.Items.Clear();
        if (drp_mode.SelectedIndex > 0)
        {
            if (drp_mode.SelectedValue.ToString() == "Cash")
            {
                sql = "select intid,strledgername as stracc from tblledger where intschool=" + Session["schoolID"].ToString() + " and intgroup=5";
            }
            else if (drp_mode.SelectedValue.ToString() == "Cheque/DD")
            {
                sql = "select intid,strbankname + '-' + straccountno as stracc from tblbankaccount where intschool=" + Session["schoolID"].ToString();
            }

            ds = da.ExceuteSql(sql);
            drp_Fromledger.DataSource = ds;
            drp_Fromledger.DataTextField = "stracc";
            drp_Fromledger.DataValueField = "intid";
            drp_Fromledger.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drp_Fromledger.Items.Insert(0, list);
        drp_Fromledger.SelectedValue = "0";
    }

    protected void filltogroup()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tblgroups where intid != 3 and intid !=5 and intschool=" + Session["schoolID"].ToString();
        ds = da.ExceuteSql(sql);
        drptogroup.DataSource = ds;
        drptogroup.DataTextField = "strgroupname";
        drptogroup.DataValueField = "intid";
        drptogroup.DataBind();

        ListItem list = new ListItem("-Select-", "0");
        drptogroup.Items.Insert(0, list);
    }

    protected void fillledger2()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        drptoledger.Items.Clear();
        sql = "select * from tblledger where intschool=" + Session["schoolID"].ToString() + " and intgroup=" + drptogroup.SelectedValue + "";
        ds = da.ExceuteSql(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drptoledger.DataSource = ds;
            drptoledger.DataTextField = "strledgername";
            drptoledger.DataValueField = "intid";
            drptoledger.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drptoledger.Items.Insert(0, list);
    }

    protected void standard()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strstandard from tblschoolstandard where intschool=" + Session["schoolID"].ToString();
        ds = da.ExceuteSql(sql);

        drpstandard.DataSource = ds;
        drpstandard.DataTextField = "strstandard";
        drpstandard.DataValueField = "strstandard";
        drpstandard.DataBind();

        ListItem list = new ListItem("-Select-", "0");
        drpstandard.Items.Insert(0, list);
    }

    protected void section()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select distinct(strsection) from tblstandard_section_subject where strstandard = '" + drpstandard.SelectedValue.ToString() + "' and intschool = " + Session["schoolID"].ToString();
        ds = da.ExceuteSql(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drpsection.DataSource = ds;
            drpsection.DataTextField = "strsection";
            drpsection.DataValueField = "strsection";
            drpsection.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drpsection.Items.Insert(0, list);
    }

    protected void student()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as studentname from tblstudent";
        sql += " where strstandard='" + drpstandard.SelectedValue + "' and strsection='" + drpsection.SelectedValue + "'";
        sql += " and intschool=" + Session["schoolID"].ToString() + "";
        ds = da.ExceuteSql(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drpstudentname.DataSource = ds;
            drpstudentname.DataTextField = "studentname";
            drpstudentname.DataValueField = "intid";
            drpstudentname.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drpstudentname.Items.Insert(0, list);
    }

    protected void dept()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tbldepartment where intschool=" + Session["schoolID"].ToString();
        ds = da.ExceuteSql(sql);

        drpdept.DataSource = ds;
        drpdept.DataTextField = "strdepartmentname";
        drpdept.DataValueField = "intid";
        drpdept.DataBind();

        ListItem list = new ListItem("-Select-", "0");
        drpdept.Items.Insert(0, list);
    }

    protected void designation()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tbldesignation where intid in(select distinct(intdesignation) from tblemployee where intschool = " + Session["schoolID"].ToString() + " and intdepartment = " + drpdept.SelectedValue.ToString() + ")";
        ds = da.ExceuteSql(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drpdesignation.DataSource = ds;
            drpdesignation.DataTextField = "strdesignation";
            drpdesignation.DataValueField = "intid";
            drpdesignation.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drpdesignation.Items.Insert(0, list);
    }

    protected void staffname()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee";
        sql += " where intschool=" + Session["schoolID"].ToString() + "";
        sql += " and intdepartment=" + drpdept.SelectedValue + "";
        sql += " and intdesignation=" + drpdesignation.SelectedValue + "";
        ds = da.ExceuteSql(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drpstaffname.DataSource = ds;
            drpstaffname.DataTextField = "staffname";
            drpstaffname.DataValueField = "intid";
            drpstaffname.DataBind();
        }

        ListItem list = new ListItem("-Select-", "0");
        drpstaffname.Items.Insert(0, list);
    }

    protected void unvisiblerow()
    {
        tr_ledger.Visible = true;

        trbank.Visible = false;
        trbranch.Visible = false;
        trchequedate.Visible = false;
        trchequeno.Visible = false;
    }

    protected void unvisiblerow1()
    {
        tr_ledger.Visible = true;
    }

    protected void unvisiblerow2()
    {
        trledger2.Visible = true;

        trstandard2.Visible = false;
        trsection.Visible = false;
        trstudent2.Visible = false;

        trdept2.Visible = false;
        trdesignation2.Visible = false;
        trstaffname2.Visible = false;
    }

    protected void chequedelailrowvisible()
    {
        trbank.Visible = true;
        trbranch.Visible = true;
        trchequedate.Visible = true;
        trchequeno.Visible = true;
    }

    protected void chequeinvisible()
    {
        trbank.Visible = false;
        trbranch.Visible = false;
        trchequedate.Visible = false;
        trchequeno.Visible = false;
    }

    protected void staffrowvisible2()
    {
        trledger2.Visible = false;

        trdept2.Visible = true;
        trdesignation2.Visible = true;
        trstaffname2.Visible = true;

        trstandard2.Visible = false;
        trsection.Visible = false;
        trstudent2.Visible = false;
    }

    protected void studentrowvisible2()
    {
        trledger2.Visible = false;

        trstandard2.Visible = true;
        trsection.Visible = true;
        trstudent2.Visible = true;

        trdept2.Visible = false;
        trdesignation2.Visible = false;
        trstaffname2.Visible = false;
    }

    protected void fillgrid()
    {
        sql = "";
        string serchcond = "";

        DataSet acctds = new DataSet();
        DataSet ledgds = new DataSet();
        DataSet bankds = new DataSet();
        DataSet studds = new DataSet();
        DataSet stafds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select intid,intschool,strmodeofpayment,intfromgroups,inttogroups,intfromledgers,inttoledgers,intamount,";
        sql += " strnarration,strbankname,strbranchname,strchequeorddno,strchequeordddate,'' as fromledger,'' as toledger,";
        sql += " CONVERT(VARCHAR(10), dttransactiondate, 103) AS transdt from tblaccounttransaction";
        sql += " where strmodeoftransaction ='Payments' and intschool=" + Session["schoolID"].ToString() + "order by intid desc";
        acctds = da.ExceuteSql(sql);

        sql = "select intid,strledgername from tblledger where intschool=" + Session["schoolID"].ToString() + "";
        ledgds = da.ExceuteSql(sql);

        sql = "select intid,strbankname + '-' + straccountno from tblbankaccount where intschool=" + Session["schoolID"].ToString();
        bankds = da.ExceuteSql(sql);

        sql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as stuname from tblstudent where intschool=" + Session["schoolID"].ToString() + "";
        studds = da.ExceuteSql(sql);

        sql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as stfname from tblemployee where intschool=" + Session["schoolID"].ToString() + "";
        stafds = da.ExceuteSql(sql);

        for (int i = 0; i < acctds.Tables[0].Rows.Count; i++)
        {
            serchcond = "";
            serchcond = "intid ='" + acctds.Tables[0].Rows[i]["intfromledgers"].ToString() + "'";
            if (acctds.Tables[0].Rows[i]["strmodeofpayment"].ToString() == "Cash")
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

            if (int.Parse(acctds.Tables[0].Rows[i]["inttogroups"].ToString()) == 1)
            {
                DataRow[] tolegdr = studds.Tables[0].Select(serchcond.ToString());
                if (tolegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["toledger"] = tolegdr[0][1].ToString();
                }
            }
            else if (int.Parse(acctds.Tables[0].Rows[i]["inttogroups"].ToString()) == 2)
            {
                DataRow[] tolegdr = stafds.Tables[0].Select(serchcond.ToString());
                if (tolegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["toledger"] = tolegdr[0][1].ToString();
                }
            }
            else
            {
                DataRow[] tolegdr = ledgds.Tables[0].Select(serchcond.ToString());
                if (tolegdr.Length > 0)
                {
                    acctds.Tables[0].Rows[i]["toledger"] = tolegdr[0][1].ToString();
                }
            }
        }

        grd_trasaction.DataSource = acctds.Tables[0];
        grd_trasaction.DataBind();


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
        //sql += " and a.inttoledgers = b.intid and a.inttogroups >3) b  where b.intid=a.intid";
        //sql += " union all";
        //sql += " select distinct b.intid,a.strchequeordddate,b.toledger from  tblaccounttransaction a,";
        //sql += " (select a.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as toledger  from tblaccounttransaction a, tblemployee b ";
        //sql += " where a.intschool=b.intschool and a.inttoledgers = b.intid and a.inttogroups =2) b  where b.intid=a.intid ";
        //sql += " union all";
        //sql += " select distinct b.intid,a.strchequeordddate,b.toledger from  tblaccounttransaction a,";
        //sql += " (select a.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as toledger from tblaccounttransaction a, tblstudent b ";
        //sql += " where a.intschool=b.intschool and a.inttoledgers = b.intid and a.inttogroups =1) b   where b.intid=a.intid";
        //sql += " union all";
        //sql += " select distinct b.intid,a.strchequeordddate,b.toledger from  tblaccounttransaction a,";
        //sql += " (select a.intid, b.straccountno as toledger from tblaccounttransaction a, tblbankaccount b";
        //sql += " where a.intschool=b.intschool and a.inttoledgers = b.intid and a.inttogroups =3) b  where b.intid=a.intid) b";
        //sql += " where b.intid=a.intid) c where a.intschool=" + Session["schoolID"].ToString() + " and a.intid=b.intid and a.intid=c.intid";
        //sql += " and strmodeoftransaction ='Payments' order by a.intid desc";
    }

    protected void clear()
    {
        fillledger();
        fillledger2();
        filltogroup();
        unvisiblerow();
        unvisiblerow2();
        txtbankname.Text = "";
        txtbranch.Text = "";
        txtchequedate.Text = "";
        txtchequeno.Text = "";
        txtamount.Text = "";
        txtnarration.Text = "";
        btnSave.Text = "Payment";
        drp_mode.SelectedIndex = 0;
    }
   
}
