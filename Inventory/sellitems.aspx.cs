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

public partial class Inventory_sellitemsnew : System.Web.UI.Page
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
            sellitems();
            drppatron.SelectedValue = "1";
            standard();
            section();
            student();
            unvisible();
            fillcategory();
            fillitems();
            Quantity();
            price();
            
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
    protected void sellitems()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.intid,b.intid,a.strcategory,b.stritemname,c.intid as id,c.intcategory,c.intitem,c.intprice,c.intqty,c.intdiscount,(c.intprice*c.intqty) as total from tblitemcategory a,tblitemmaster b,tbltempsalesentry c where a.intid=c.intcategory and b.intid=c.intitem";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grdsellitems.DataSource = ds.Tables[0];
        grdsellitems.DataBind();
    }
    protected void standard()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblstandard";
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
        string sql = "select * from tblsection";
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
        string sql = "select * from tblstudent";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpstudentname.DataSource = ds;
        drpstudentname.DataTextField = "strfirstname";
        drpstudentname.DataValueField = "strfirstname";
        drpstudentname.DataBind();
    }
    protected void dept()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tbldepartment";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpdept.DataSource = ds;
        drpdept.DataTextField = "strdepartmentname";
        drpdept.DataValueField = "strdepartmentname";
        drpdept.DataBind();
    }
    protected void staffname()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblstaff";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpstaffname.DataSource = ds;
        drpstaffname.DataTextField = "strFirstName";
        drpstaffname.DataValueField = "strFirstName";
        drpstaffname.DataBind();
    }
    protected void designation()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tbldesignation";
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
        string sql = "select a.strcategory,a.intid,b.intcategory from tblitemcategory a,tblbalance b where a.intid=b.intcategory group by a.strcategory,a.intid,b.intcategory ";
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
        string sql = "select a.stritemname,a.intid,b.intitem from tblitemmaster a,tblbalance b where a.intid=b.intitem and intcategory='" + drpcategory.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        drpitems.DataSource = ds;
        drpitems.DataTextField = "stritemname";
        drpitems.DataValueField = "intid";
        drpitems.DataBind();
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
            int b =int.Parse(txtquantity.Text);
            int c=a-b;
            int d = s + b;
            if (a >= b)
            {
                salesbills();
                string sq = "update tblbalance set intbalanceqty='" + c + "',intsalesqty='" + d + "' where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "'";
                ds = da.ExceuteSql(sq);
            }
            else
            {
                MsgBox.alert("Quantity Is out Of range");
            }

        }


    }
    protected void salesbillentry()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblsalesbillentry where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "' and intbillid='" + txtbillno.Text + "'";
        ds = da.ExceuteSql(sql);
        int p = int.Parse(txtprice.Text);
        int q = int.Parse(txtquantity.Text);
        int d = int.Parse(txtdiscount.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int a = int.Parse(ds.Tables[0].Rows[0]["intqty"].ToString());
            int b = a + q;
            int t = p * b;
            int TD = b * d;
            string sq = "update tblsalesbillentry set intqty='" + b + "', inttotalprice='" + t + "',inttotaldiscount='"+TD+"' where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "' and intbillid='" + txtbillno.Text + "'";
            ds = da.ExceuteSql(sq);
        }
        else
        {
            int t = p * q;
            int td = q * d;
            string sql1 = "insert into tblsalesbillentry(intschool,intstaff,intbillid,intcategory,intitem,intprice,intqty,intdiscount,inttotalprice,inttotaldiscount)values('" + Session["intschool"].ToString() + "','" + Session["intstaff"].ToString() + "','" + txtbillno.Text + "','" + drpcategory.SelectedValue + "','" + drpitems.SelectedValue + "','" + txtprice.Text + "','" + txtquantity.Text + "','" + txtdiscount.Text + "','" + t + "','"+td+"')";
            ds = da.ExceuteSql(sql1);
        }
                  
    }

    protected void salesbills()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string s = "select sum(inttotalprice) as total,sum(inttotaldiscount) as totaldiscount,(sum(inttotalprice)-sum(inttotaldiscount)) as final from tblsalesbillentry where intbillid=" + txtbillno.Text;
        ds = da.ExceuteSql(s);
        if (ds.Tables[0].Rows.Count > 0)
        {
            double a = double.Parse(ds.Tables[0].Rows[0]["total"].ToString());
            double b = double.Parse(ds.Tables[0].Rows[0]["totaldiscount"].ToString());
            double c = double.Parse(ds.Tables[0].Rows[0]["final"].ToString());
            string sq = "select intbillno from tblsalesbill where intbillno=" + txtbillno.Text;
            ds = da.ExceuteSql(sq);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (drppatron.SelectedValue == "1")
                {
                    string sql = "insert into tblsalesbill(intschool,intstaff,intbillno,strpatron,strstandard,strsection,strstudentname,strdepartment,strdesignation,strstaffname,inttotalamount,inttotaldiscount,intgrandtotal)values('" + Session["intschool"].ToString() + "','" + Session["intstaff"].ToString() + "','" + txtbillno.Text + "','" + drppatron.SelectedValue + "','" + drpstandard.SelectedValue + "','" + drpsection.SelectedValue + "','" + drpstudentname.SelectedValue + "','" + '-' + "','" + '-' + "','" + '-' + "','" + a + "','" + b + "','" + c + "')";
                    ds = da.ExceuteSql(sql);

                }
                else
                {
                    string sql = "insert into tblsalesbill(intschool,intstaff,intbillno,strpatron,strstandard,strsection,strstudentname,strdepartment,strdesignation,strstaffname,inttotalamount,inttotaldiscount,intgrandtotal)values('" + Session["intschool"].ToString() + "','" + Session["intstaff"].ToString() + "','" + txtbillno.Text + "','" + drppatron.SelectedValue + "','" + '-' + "','" + '-' + "','" + '-' + "','" + drpdept.SelectedValue + "','" + drpdesignation.SelectedValue + "','" + drpstaffname.SelectedValue + "','" + a + "','" + b + "','" + c + "')";
                    ds = da.ExceuteSql(sql);
                }
            }
            else
            {
                string sql = "update tblsalesbill set inttotalamount='" + a + "',inttotaldiscount='" + b + "',intgrandtotal='" + c + "' where intbillno='" + txtbillno.Text + "'";
                ds = da.ExceuteSql(sql);
            }

        }

    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            salesbillentry();
            mainbalance();
            SqlCommand RegCommand;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("sptempsalesentry", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            if (btnSave.Text == "Add")
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
            RegCommand.Parameters.Add("@intqty", txtquantity.Text.Trim());
            RegCommand.Parameters.Add("@intdiscount", txtdiscount.Text.Trim());
            RegCommand.Parameters.Add("@intbillid", txtbillno.Text.Trim());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            Quantity();
            sellitems();
            addclear();

        }
        catch
        {
            MsgBox.alert("Please Check The Values Given");
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        txtbillno.Text = "";
        drppatron.SelectedValue = "1";
        standard();
        section();
        student();
        unvisible();
        fillcategory();
        fillitems();
        price();
        Quantity();
        txtquantity.Text = "";
        txtdiscount.Text = "";
        txttotalamount.Text = "";
        txttotaldiscount.Text = "";
        txtgrand.Text = "";
        btnSave.Text = "Add";
    }
    protected void addclear()
    {
        txtquantity.Text = "";
        txtdiscount.Text = "";
        btnSave.Text = "Add";
    }
   

    protected void drpcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillitems();
        price();
        Quantity();
    }
    protected void grdsellitems_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tbltempsalesentry where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        sellitems();
    }
    protected void grdsellitems_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        fillcategory();
        drpcategory.SelectedValue = e.Item.Cells[6].Text;
        fillitems();
        drpitems.SelectedValue = e.Item.Cells[7].Text;
        txtprice.Text = e.Item.Cells[3].Text;
        txtquantity.Text = e.Item.Cells[4].Text;
        txtdiscount.Text = e.Item.Cells[5].Text;
        btnSave.Text = "Update";
    }
    protected void drpitems_SelectedIndexChanged(object sender, EventArgs e)
    {
        price();
        Quantity();
        lblavailable1.Visible = true;
    }
    protected void Quantity()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intbalanceqty from tblbalance where intcategory='" + drpcategory.SelectedValue + "' and intitem='" + drpitems.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int b = int.Parse(ds.Tables[0].Rows[0]["intbalanceqty"].ToString());
            lblavailable1.Text = b.ToString();
        }
        else
        {
            MsgBox.alert("This Item is not available");
        }
    }
    protected void price()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intsalesrate from tblitemmaster where intitemcategory='" + drpcategory.SelectedValue + "' and intid='" + drpitems.SelectedValue + "'";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int b = int.Parse(ds.Tables[0].Rows[0]["intsalesrate"].ToString());
            txtprice.Text = b.ToString();
        }
        else
        {
            MsgBox.alert("0");
        }
    }
    protected void drppatron_SelectedIndexChanged(object sender, EventArgs e)
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


    protected void btnFinal_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string s = "select * from tblsalesbill where intbillno='"+ txtbillno.Text+"'";
        ds = da.ExceuteSql(s);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txttotalamount.Text = ds.Tables[0].Rows[0]["inttotalamount"].ToString();
            txttotaldiscount.Text = ds.Tables[0].Rows[0]["inttotaldiscount"].ToString();
            txtgrand.Text = ds.Tables[0].Rows[0]["intgrandtotal"].ToString();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tbltempsalesentry";
        ds = da.ExceuteSql(sql);
        clear();
        sellitems();

    }
}

