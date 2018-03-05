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

public partial class Inventory_returnbill : System.Web.UI.Page
{
   public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["intschool"] = 17;
            Session["intstaff"] = 1;
            returnitems();
            unvisible();
        }

    }
    protected void unvisible()
    {
        trstd.Visible = true;
        trsec.Visible = true;
        trstdname.Visible = true;
        trdept.Visible = false;
        trdesig.Visible = false;
        trstaff.Visible = false;      
    }
    protected void returnitems()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.intid,b.intid,a.strcategory,b.stritemname,c.intid as id,c.intcategory,c.intitem,c.intprice,c.intqty,c.intdiscount,(c.intprice*c.intqty) as total from tblitemcategory a,tblitemmaster b,tbltempsalesreturnentry c where a.intid=c.intcategory and b.intid=c.intitem and intbillid='" + txtbillno.Text + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grdreturnitems.DataSource = ds.Tables[0];
        grdreturnitems.DataBind();
    }
    protected void standard()
    {
        DataAccess da = new DataAccess();
        string sql = "select strstandard from tblsalesbill where intbillno='" + txtbillno.Text + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpstandard.DataSource = ds;
        drpstandard.DataTextField = "strstandard";
        drpstandard.DataValueField = "strstandard";
        drpstandard.DataBind();
    }
    protected void section()
    {
        DataAccess da = new DataAccess();
        string sql = "select strsection from tblsalesbill where intbillno='" + txtbillno.Text + "' ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpsection.DataSource = ds;
        drpsection.DataTextField = "strsection";
        drpsection.DataValueField = "strsection";
        drpsection.DataBind();
    }
    protected void student()
    {
        DataAccess da = new DataAccess();
        string sql = "select strstudentname from tblsalesbill where intbillno='" + txtbillno.Text + "' ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpstudentname.DataSource = ds;
        drpstudentname.DataTextField = "strstudentname";
        drpstudentname.DataValueField = "strstudentname";
        drpstudentname.DataBind();
    }
    protected void dept()
    {
        DataAccess da = new DataAccess();
        string sql = "select strdepartment from tblsalesbill where intbillno='" + txtbillno.Text + "' ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpdept.DataSource = ds;
        drpdept.DataTextField = "strdepartment";
        drpdept.DataValueField = "strdepartment";
        drpdept.DataBind();
    }
    protected void staffname()
    {
        DataAccess da = new DataAccess();
        string sql = "select strstaffname from tblsalesbill where intbillno='" + txtbillno.Text + "' ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpstaffname.DataSource = ds;
        drpstaffname.DataTextField = "strstaffname";
        drpstaffname.DataValueField = "strstaffname";
        drpstaffname.DataBind();
    }
    protected void designation()
    {
        DataAccess da = new DataAccess();
        string sql = "select strdesignation from tblsalesbill where intbillno='" + txtbillno.Text + "' ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpdesignation.DataSource = ds;
        drpdesignation.DataTextField = "strdesignation";
        drpdesignation.DataValueField = "strdesignation";
        drpdesignation.DataBind();
    }
    protected void fillcategory()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.strcategory,a.intid,b.intcategory from tblitemcategory a,tblsalesbillentry b where a.intid=b.intcategory and b.intbillid='"+txtbillno.Text+"' group by a.strcategory,a.intid,b.intcategory ";
        ds = da.ExceuteSql(sql);
        drpcategory.DataSource = ds;
        drpcategory.DataTextField = "strcategory";
        drpcategory.DataValueField = "intid";
        drpcategory.DataBind();
    }
    protected void fillitems()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.stritemname,a.intid,b.intitem from tblitemmaster a,tblsalesbillentry b where a.intid=b.intitem and intcategory='" + drpcategory.SelectedValue + "' and b.intbillid='"+txtbillno.Text+"'";
        ds = da.ExceuteSql(sql);
        drpitems.DataSource = ds;
        drpitems.DataTextField = "stritemname";
        drpitems.DataValueField = "intid";
        drpitems.DataBind();
    }
    protected void patron()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strpatron from tblsalesbill where intbillno='" + txtbillno.Text + "'";
        ds = da.ExceuteSql(sql);
        drppatron.DataSource = ds;
        drppatron.DataTextField = "strpatron";
        drppatron.DataValueField = "strpatron";
        drppatron.DataBind();
    }
    protected void discount()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intdiscount from tblsalesbillentry where intbillid='" + txtbillno.Text + "' and intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        txtdiscount.Text = ds.Tables[0].Rows[0]["intdiscount"].ToString();
    }
    
   protected void Quantity()
    {
        
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intqty from tblsalesbillentry where intitem='" + drpitems.SelectedValue + "' and intbillid='"+txtbillno.Text+"'";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int b = int.Parse(ds.Tables[0].Rows[0]["intqty"].ToString());
            string sq = "select intqty from tblreturnbillentry where intitem='" + drpitems.SelectedValue + "'and intbillid='" + txtbillno.Text + "'";
            ds = da.ExceuteSql(sq);
            if(ds.Tables[0].Rows.Count>0)
            {
                int a=int.Parse(ds.Tables[0].Rows[0]["intqty"].ToString());
                lblsoldqty.Text=(b-a).ToString();
            }
            else
            {
               lblsoldqty.Text=b.ToString();
            }
        }
        
    }
    protected void price()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intsalesrate from tblitemmaster where  intid='" + drpitems.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int b = int.Parse(ds.Tables[0].Rows[0]["intsalesrate"].ToString());
            txtprice.Text = b.ToString();
        }
        else
        {
            MsgBox.alert("Price is not fixed");
        }
    }
   
    protected void txtbillno_TextChanged(object sender, EventArgs e)
    {
        patron();
        patronselection();
        fillcategory();
        fillitems();
        Quantity();
        price();
        discount();
        returnitems();
                
    }
    protected void drpcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillitems();
        price();
        Quantity();
        discount();
    }
    protected void patronselection()
    {
        if (drppatron.SelectedValue == "1")
        {
            standard();
            section();
            student();
            trstd.Visible = true;
            trsec.Visible = true;
            trstdname.Visible = true;
            trdept.Visible = false;
            trdesig.Visible = false;
            trstaff.Visible = false;
        }
        else
        {
            dept();
            designation();
            staffname();
            trstd.Visible = false;
            trsec.Visible = false;
            trstdname.Visible = false;
            trdept.Visible = true;
            trdesig.Visible = true;
            trstaff.Visible = true;
        }
    }
    protected void drpitems_SelectedIndexChanged(object sender, EventArgs e)
    {
        price();
        Quantity();
        discount();
        lblsoldqty.Visible = true;

    }
    protected void returnbillentry()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql="select * from tblreturnbillentry where intcategory='"+drpcategory.SelectedValue+"' and intitem='"+drpitems.SelectedValue+"' and intbillid='"+txtbillno.Text+"'";
        ds = da.ExceuteSql(sql);
        int p = int.Parse(txtprice.Text);
        int q = int.Parse(txtreturnquantity.Text);
        //int d = int.Parse(txtdiscount.Text);
        double d = double.Parse(txtdiscount.Text);
        if(ds.Tables[0].Rows.Count>0)
        {
        int a = int.Parse(ds.Tables[0].Rows[0]["intqty"].ToString());
        int b=a+q;
        int t = p * b;
        //int td =b*d;
        double td = b * d;
        string sq = "update tblreturnbillentry set intqty='" + b + "', inttotalprice='" + t + "',inttotaldiscount='"+td+"' where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "' and intbillid='" + txtbillno.Text + "'";
        ds = da.ExceuteSql(sq);
        }
        else
        {
            int t = p * q;
            //int td = q * d;
            double td = q * d;
            string sql1 = "insert into tblreturnbillentry(intschool,intstaff,intbillid,intcategory,intitem,intprice,intqty,intdiscount,inttotalprice,inttotaldiscount)values('" + Session["intschool"].ToString() + "','" + Session["intstaff"].ToString() + "','" + txtbillno.Text + "','" + drpcategory.SelectedValue + "','" + drpitems.SelectedValue + "','" + txtprice.Text + "','" + txtreturnquantity.Text + "','" + txtdiscount.Text + "','" + t + "','"+td+"')";
            ds = da.ExceuteSql(sql1);
        }

    }
   
    protected void mainbalance()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intbalanceqty,intsalesqty from tblbalance where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int a = int.Parse(ds.Tables[0].Rows[0]["intbalanceqty"].ToString());
            int s = int.Parse(ds.Tables[0].Rows[0]["intsalesqty"].ToString());
            int b = int.Parse(txtreturnquantity.Text);
            int c = a + b;
            int d = s - b;
            if (a >= b)
            {
                returnbills();
                string sq = "update tblbalance set intbalanceqty='" + c + "',intsalesqty='" + d + "' where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "'";
                ds = da.ExceuteSql(sq);
            }
            else
            {
                MsgBox.alert("Quantity Is out Of range");
            }

        }


    }
    protected void returnbills()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string s = "select sum(inttotalprice) as total,sum(inttotaldiscount) as totaldiscount,(sum(inttotalprice)-sum(inttotaldiscount)) as final from tblreturnbillentry where intbillid=" + txtbillno.Text;
        ds = da.ExceuteSql(s);
        if (ds.Tables[0].Rows.Count > 0)
        {
            double a = double.Parse(ds.Tables[0].Rows[0]["total"].ToString());
            double b = double.Parse(ds.Tables[0].Rows[0]["totaldiscount"].ToString());
            double c = double.Parse(ds.Tables[0].Rows[0]["final"].ToString());
            string sq = "select intbillno from tblreturnbill where intbillno=" + txtbillno.Text;
            ds = da.ExceuteSql(sq);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (drppatron.SelectedValue == "1")
                {
                    string sql = "insert into tblreturnbill(intschool,intstaff,intbillno,strpatron,strstandard,strsection,strstudentname,strdepartment,strdesignation,strstaffname,inttotalamount,inttotaldiscount,intsalesreturn)values('" + Session["intschool"].ToString() + "','" + Session["intstaff"].ToString() + "','" + txtbillno.Text + "','" + drppatron.SelectedValue + "','" + drpstandard.SelectedValue + "','" + drpsection.SelectedValue + "','" + drpstudentname.SelectedValue + "','" + '-' + "','" + '-' + "','" + '-' + "','" + a + "','" + b + "','" + c + "')";
                    ds = da.ExceuteSql(sql);

                }
                else
                {
                    string sql = "insert into tblreturnbill(intschool,intstaff,intbillno,strpatron,strstandard,strsection,strstudentname,strdepartment,strdesignation,strstaffname,inttotalamount,inttotaldiscount,intsalesreturn)values('" + Session["intschool"].ToString() + "','" + Session["intstaff"].ToString() + "','" + txtbillno.Text + "','" + drppatron.SelectedValue + "','" + '-' + "','" + '-' + "','" + '-' + "','" + drpdept.SelectedValue + "','" + drpdesignation.SelectedValue + "','" + drpstaffname.SelectedValue + "','" + a + "','" + b + "','" + c + "')";
                    ds = da.ExceuteSql(sql);
                }
            }
            else
            {
                string sql = "update tblreturnbill set inttotalamount='" + a + "',inttotaldiscount='" + b + "',intsalesreturn='" + c + "' where intbillno='" + txtbillno.Text + "'";
                ds = da.ExceuteSql(sql);
            }

        }

    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        try
        {
            returnbillentry();
            mainbalance();
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("sptempsalesreturnentry", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btnreturn.Text == "Return")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            RegCommand.Parameters.Add("@intschool", Session["intschool"].ToString());
            RegCommand.Parameters.Add("@intstaff", Session["intstaff"].ToString());
            RegCommand.Parameters.Add("@intcategory", drpcategory.SelectedValue.Trim());
            RegCommand.Parameters.Add("@intitem", drpitems.SelectedValue.Trim());
            RegCommand.Parameters.Add("@intprice", txtprice.Text.Trim());
            RegCommand.Parameters.Add("@intqty", txtreturnquantity.Text.Trim());
            RegCommand.Parameters.Add("@intdiscount", txtdiscount.Text.Trim());
            RegCommand.Parameters.Add("@intbillid", txtbillno.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            Quantity();
            returnitems();
        }
        catch
        {
        }
    }
   
    protected void btnfinal_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string s = "select * from tblreturnbill where intbillno=" + txtbillno.Text;
        ds = da.ExceuteSql(s);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txttotalamount.Text =ds.Tables[0].Rows[0]["inttotalamount"].ToString();
            txttotaldiscount.Text= ds.Tables[0].Rows[0]["inttotaldiscount"].ToString();
            txtreturnamount.Text =ds.Tables[0].Rows[0]["intsalesreturn"].ToString();
        }
    }
    protected void btnrepay_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tbltempsalesreturnentry";
        ds = da.ExceuteSql(sql);
        returnitems();
        clear();
    }
    protected void clear()
    {
        unvisible();
        txtbillno.Text = "";
        patron();
        patronselection();
        fillcategory();
        fillitems();
        txtprice.Text = "";
        lblsoldqty.Text = "";
        txtdiscount.Text = "";
        txtreturnamount.Text = "";
        txttotaldiscount.Text = "";
        txttotalamount.Text = "";
        txtreturnquantity.Text = "";
        returnitems();
    }
    protected void drppatron_SelectedIndexChanged(object sender, EventArgs e)
    {
        patronselection();
    }
}

