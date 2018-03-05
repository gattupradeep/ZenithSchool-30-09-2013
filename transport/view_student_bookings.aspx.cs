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

public partial class transport_view_student_booking : System.Web.UI.Page
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
            if (Session["PatronType"].ToString() == "Students" || Session["PatronType"].ToString() == "Parents")
            {
                fillgrid();
            }
        }
        //fillgrid();
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        strsql = " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Approved' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        strsql += " and f.strstandard+' - '+f.strsection='" + Session["StudentClass"].ToString() + "' and e.intstudentid=" + Session["UserID"].ToString();
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        strsql += " and f.strstandard+' - '+f.strsection='" + Session["StudentClass"].ToString() + "' and e.intstudentid=" + Session["UserID"].ToString();
        strsql += " and a.intschool=2 and e.intARStatus=3 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Waiting for Approval' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        strsql += " and f.strstandard+' - '+f.strsection='" + Session["StudentClass"].ToString() + "' and e.intstudentid=" + Session["UserID"].ToString();
        strsql += " and a.intschool=2 and e.intARStatus=0 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancellation request' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        strsql += " and f.strstandard+' - '+f.strsection='" + Session["StudentClass"].ToString() + "' and e.intstudentid=" + Session["UserID"].ToString();
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=1 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancelled' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        strsql += " and f.strstandard+' - '+f.strsection='" + Session["StudentClass"].ToString() + "' and e.intstudentid=" + Session["UserID"].ToString();
        strsql += " and a.intschool=2 and e.intARStatus=2 and e.intRCStatus=1 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancel request rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
        strsql += " and f.strstandard+' - '+f.strsection='" + Session["StudentClass"].ToString() + "' and e.intstudentid=" + Session["UserID"].ToString();
        strsql += " and a.intschool=2 and e.intARStatus=4 and e.intRCStatus=1 ";
        DataSet ds = new DataSet();

        ds = da.ExceuteSql(strsql);
        dgasgnbusroute.DataSource = ds;
        dgasgnbusroute.DataBind();
    }
}


