using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class transport_Approvecancellation : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        ds = new DataSet();
        da = new DataAccess();
        //strsql = "select a.stradmissionid,CONVERT(varchar(11),a.dtdate,103) as dtdate,a.strreason,b.strdestination,b.introuteid,c.strfirstname+''+strmiddlename+''+strlastname as studentname,strstandard+' - '+strsection as standard from tblstudentbuscancelation a,tblbusbooking b,tblstudent c,tblroute d where a.stradmissionid=c.intadmitno and b.introuteid=d.intid and a.intschool=" + Session["Schoolid"].ToString() + " and c.intschool=" + Session["Schoolid"].ToString();
        //strsql = " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        //strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Approved' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        //strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  ";
        //strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=0 ";
        //strsql += " union all  ";
        //strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        //strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        //strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  ";
        //strsql += " and a.intschool=2 and e.intARStatus=3 and e.intRCStatus=0 ";
        //strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Waiting for Approval' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  ";
        strsql += " and a.intschool=2 and e.intARStatus=0 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancellation request' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  ";
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=1 ";
        //strsql += " union all  ";
        //strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        //strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancelled' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        //strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  ";
        //strsql += " and a.intschool=2 and e.intARStatus=2 and e.intRCStatus=1 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancel request rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  ";
        strsql += " and a.intschool=2 and e.intARStatus=4 and e.intRCStatus=1 ";
        ds = da.ExceuteSql(strsql);
        dgapprovebus.DataSource = ds;
        dgapprovebus.DataBind();

    }
    
    protected void btnapprove_Click(object sender, EventArgs e)
    {
        Button list = (Button)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        Button Approve = (Button)item.FindControl("btnapprove");
        da = new DataAccess();
        if (Approve.Text == "Approve")
        {
            if (item.Cells[7].Text == "Waiting for Approval")
            {
                strsql = "update tblbusbooking set intARStatus=1,dtApprovedDate=getdate() where intid=" + item.Cells[0].Text;
                da.ExceuteSqlQuery(strsql);
            }
            else if (item.Cells[7].Text == "Cancellation request")
            {
                strsql = "update tblbusbooking set intARStatus=2,dtCancelledDate=getdate() where intid=" + item.Cells[0].Text;
                da.ExceuteSqlQuery(strsql);
            }
        }
        fillgrid();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Button list = (Button)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        Button Reject = (Button)item.FindControl("btncancel");
        da = new DataAccess();
        if (Reject.Text == "Reject")
        {
            if (item.Cells[7].Text == "Waiting for Approval")
            {
                strsql = "update tblbusbooking set intARStatus=3,dtCancelledDate=getdate() where intid=" + item.Cells[0].Text;
                da.ExceuteSqlQuery(strsql);
            }
            else if (item.Cells[7].Text == "Cancellation request")
            {
                strsql = "update tblbusbooking set intARStatus=4,dtCancelledDate=getdate() where intid=" + item.Cells[0].Text;
                da.ExceuteSqlQuery(strsql);
            }
        }
        fillgrid();
    }
    protected void dgapprovebus_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            Button btnapprove = (Button)e.Item.FindControl("btnapprove");
            Button btnreject = (Button)e.Item.FindControl("btncancel");
            DataRowView dr = (DataRowView)e.Item.DataItem;

            if (dr["status"].ToString() == "Approved" || dr["status"].ToString() == "Cancelled" || dr["status"].ToString() == "Rejected")
            {
                btnapprove.Text = "----";
                btnreject.Text = "----";
                btnapprove.Enabled = false;
                btnreject.Attributes.Add("Visible", "False");
           }
            else if (dr["status"].ToString() == "Waiting for Approval" || dr["status"].ToString() == "Cancellation Request")
            {
                if (DateTime.Today.Date > DateTime.Parse(dr["dtapproveddate"].ToString()))
                {
                    btnapprove.Text = "Approved";
                    btnapprove.Enabled = false;
                    btnreject.Visible = false;
                    btnreject.Attributes.Add("Visible", "False");
                }
                else
                {
                    btnapprove.Text = "Approve";
                    btnapprove.Enabled = true;
                }
            }
        }
        catch { }
    }
}
