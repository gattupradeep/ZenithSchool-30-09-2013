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

public partial class transport_view_bookings : System.Web.UI.Page
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
            fillroute();
            fillstandard();
        }
    }
    private void fillgrid()
    {
        da = new DataAccess();
        strsql = " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Approved' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        if (ddlstandard.SelectedIndex > 0)
            strsql += " and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "'";
        if (ddlstudent.SelectedIndex > 0)
            strsql += " and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        if (ddlstandard.SelectedIndex > 0)
            strsql += " and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "'";
        if (ddlstudent.SelectedIndex > 0)
            strsql += " and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=3 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Waiting for Approval' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        if (ddlstandard.SelectedIndex > 0)
            strsql += " and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "'";
        if (ddlstudent.SelectedIndex > 0)
            strsql += " and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=0 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancellation request' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        if (ddlstandard.SelectedIndex > 0)
            strsql += " and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "'";
        if (ddlstudent.SelectedIndex > 0)
            strsql += " and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=1 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancelled' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        if (ddlstandard.SelectedIndex > 0)
            strsql += " and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "'";
        if (ddlstudent.SelectedIndex > 0)
            strsql += " and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=2 and e.intRCStatus=1 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancel request rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        if (ddlstandard.SelectedIndex > 0)
            strsql += " and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "'";
        if (ddlstudent.SelectedIndex > 0)
            strsql += " and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=4 and e.intRCStatus=1 ";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgasgnbusroute.DataSource = ds;
        dgasgnbusroute.DataBind();
    }
    protected void fillroute()
    {
        strsql = "select strroutename,intid from tblroute where intschool=" + Session["SchoolID"].ToString();
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
        strsql = " select a.strdrivername,b.strvehicleno,b.intseats,c.* from tbldriver a,tblvehiclemaster b,tblroute c,tblassignbusroute d where  a.intid=c.intdriver and b.intid=c.intvehicle and d.introute= " + ddlrouteno.SelectedValue;
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
        fillgrid();
        filldriver();
    }
    protected void fillstandard()
    {
        strsql = " select strstandard+' - '+strsection as standard from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "standard";
        ddlstandard.DataValueField = "standard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");
    }

    protected void fillstudent()
    {
        strsql = " select strfirstname + ' ' + strlastname as name,intid from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "-Select-");
    }

    protected void availability()
    {
        strsql = "select intseats-ct as available from (select count(*) as ct from tblbusbooking where introuteid=" + ddlrouteno.SelectedValue + " and intschool= " + Session["Schoolid"].ToString() + ") as a,(select intseats from tblvehiclemaster where intid =(select intvehicle from tblroute where intid= " + ddlrouteno.SelectedValue + ")) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        lblavailable.Text = ds.Tables[0].Rows[0]["available"].ToString();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        fillgrid();
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}

