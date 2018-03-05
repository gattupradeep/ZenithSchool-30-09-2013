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

public partial class transport_student_booking : System.Web.UI.Page
{   
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["studentid"] = 2;
        if (!IsPostBack)
        {
            fillroute();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,b.intid,f.strstandard,f.strsection, f.strfirstname + ' ' + f.strlastname as name from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid and e.intid=" + Session["studentid"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgasgnbusroute.DataSource = ds;
            dgasgnbusroute.DataBind();
            dgasgnbusroute.Visible = true;
        }
        else
        {
            dgasgnbusroute.Visible = false;
        }
    }
    protected void fillroute()
    {
        strsql = "select strroutename,intid from tblroute where intschool=" + Session["SchoolID"].ToString()  ;
        da = new DataAccess();       
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlrouteno.DataSource = ds;
        ddlrouteno.DataTextField = "strroutename";
        ddlrouteno.DataValueField = "intid";
        ddlrouteno.DataBind();
        ddlrouteno.Items.Insert(0, "-Select-");
    }
    protected void filldriver()
    {
        strsql = " select a.strdrivername,b.strvehicleno,b.intseats,c.* from tbldriver a,tblvehiclemaster b,tblroute c,tblassignbusroute d where  a.intid=c.intdriver and b.intid=c.intvehicle and d.introute= " + ddlrouteno.SelectedValue ;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbldrivername.Text = ds.Tables[0].Rows[0]["strdrivername"].ToString();
            lblnoofseats.Text = ds.Tables[0].Rows[0]["intseats"].ToString();
            lblvehicleno.Text = ds.Tables[0].Rows[0]["strvehicleno"].ToString();
            availability();
        }
    }
    protected void ddlrouteno_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldriver();
        fillgrid();
    }
   protected void availability()
    {
        strsql = "select intseats-ct as available from (select count(*) as ct from tblbusbooking where introuteid=" + ddlrouteno.SelectedValue + " and intschool= " + Session["Schoolid"].ToString() + ") as a,(select intseats from tblvehiclemaster where intid =(select intvehicle from tblroute where intid= " + ddlrouteno.SelectedValue + ")) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        lblavailable.Text = ds.Tables[0].Rows[0]["available"].ToString();
    }
   protected void dgasgnbusroute_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string str = "delete tblbusbooking where intid=" + e.Item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),215);
        da.ExceuteSqlQuery(str);
        fillgrid();
    }
}
