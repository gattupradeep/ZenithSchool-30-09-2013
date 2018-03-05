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

public partial class Leave_viewstaffleaverequest : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            
        }
    }
    protected void fillgrid()
    {
        da = new DataAccess();
        ds = new DataSet();
        sql = "select * from (";

        sql += "select convert(varchar(50), a.dtdateofrequest,103) as requestdate,CONVERT(varchar(50),a.dtfromdate,106)+' - '+CONVERT(varchar(50),a.dttodate,106) as leavedays,";
        sql += " b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,d.strleavetype,'Pending' as Status,a.dtfromdate,a.dttodate,a.intschool from tblleaverequest a,";
        sql += " tblemployee b,tblstaffleaves c,tblschoolleavecategory d where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and";
        sql += " a.intstaff=b.intID and c.intleavetype=d.intID and a.intapproved=0 and a.intschool=" + Session["SchoolID"] + " and a.intID=c.intleaverequest group by a.dtdateofrequest,";
        sql += " a.dtfromdate,a.dttodate, b.strfirstname+' '+b.strmiddlename+' '+b.strlastname ,d.strleavetype,a.intapproved,a.dtfromdate,a.dttodate,a.intschool";

        sql += " union all";

        sql += " select convert(varchar(50), a.dtdateofrequest,103) as requestdate,CONVERT(varchar(50),a.dtfromdate,106)+' - '+CONVERT(varchar(50),a.dttodate,106) as leavedays,";
        sql += " b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,d.strleavetype,'Approved' as Status,a.dtfromdate,a.dttodate,a.intschool from tblleaverequest a,";
        sql += " tblemployee b,tblstaffleaves c,tblschoolleavecategory d where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and";
        sql += " a.intstaff=b.intID and c.intleavetype=d.intID and a.intapproved=1 and a.intcancel !=2 and a.intschool=" + Session["SchoolID"] + " and a.intID=c.intleaverequest group by a.dtdateofrequest,";
        sql += " a.dtfromdate,a.dttodate, b.strfirstname+' '+b.strmiddlename+' '+b.strlastname ,d.strleavetype,a.intapproved,a.dtfromdate,a.dttodate,a.intschool";

        sql += " union all";


        sql += " select convert(varchar(50), a.dtdateofrequest,103) as requestdate,CONVERT(varchar(50),a.dtfromdate,106)+' - '+CONVERT(varchar(50),a.dttodate,106) as leavedays,";
        sql += " b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,d.strleavetype,'canceled' as Status,a.dtfromdate,a.dttodate,a.intschool from tblleaverequest a,";
        sql += " tblemployee b,tblstaffleaves c,tblschoolleavecategory d where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and";
        sql += " a.intstaff=b.intID and c.intleavetype=d.intID and a.intcancel=2 and a.intschool=" + Session["SchoolID"] + " and a.intID=c.intleaverequest group by a.dtdateofrequest,";
        sql += " a.dtfromdate,a.dttodate, b.strfirstname+' '+b.strmiddlename+' '+b.strlastname ,d.strleavetype,a.intapproved,a.dtfromdate,a.dttodate,a.intschool";

        sql += " union all";

        sql += " select convert(varchar(50), a.dtdateofrequest,103) as requestdate,CONVERT(varchar(50),a.dtfromdate,106)+' - '+CONVERT(varchar(50),a.dttodate,106) as leavedays,";
        sql += " b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,d.strleavetype,'Rejected' as Status,a.dtfromdate,a.dttodate,a.intschool from tblleaverequest a,";
        sql += " tblemployee b,tblstaffleaves c,tblschoolleavecategory d where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and";
        sql += " a.intstaff=b.intID and c.intleavetype=d.intID and a.intapproved=2 and a.intschool=" + Session["SchoolID"] + " and a.intID=c.intleaverequest group by a.dtdateofrequest,";
        sql += " a.dtfromdate,a.dttodate, b.strfirstname+' '+b.strmiddlename+' '+b.strlastname ,d.strleavetype,a.intapproved,a.dtfromdate,a.dttodate,a.intschool ) as a";

        sql += " where a.intschool=" + Session["SchoolID"];

        if (txtgrdriseddate.Text != "")
        {
            sql += " and a.requestdate='" + txtgrdriseddate.Text+"'";
        }
        if (txtgrdfromto.Text != "")
        {
            sql += " and (CONVERT(varchar(50),a.dtfromdate,103) = '" + txtgrdfromto.Text + "' or CONVERT(varchar(50),a.dttodate,103)='" + txtgrdfromto.Text + "' )";
        }
        if (Session["PatronType"].ToString() == "Admin" || Session["PatronType"].ToString() == "Teaching Staffs" || Session["PatronType"].ToString() == "Non Teaching Staff")
        {
            try
            {
                string sql1 = "select strfirstname+' '+strmiddlename+' '+strlastname as name from tblemployee where intid=" + Session["UserID"].ToString();
                da = new DataAccess();
                ds = new DataSet();
                ds = da.ExceuteSql(sql1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql += " and a.name like '" + ds.Tables[0].Rows[0]["name"].ToString() + "%'";
                }
            }
            catch { }
        }
        else
        {
            if (txtgrdname.Text != "")
            {
                sql += " and a.name like '" + txtgrdname.Text + "%'";
            }
        }
        if (txtgrdleavetype.Text != "")
        {
            sql += "  and a.strleavetype like '"+txtgrdleavetype.Text+"%'";
        }
        if (txtstatus.Text != "")
        {
            sql += " and a.Status like '"+txtstatus.Text+"%'";
        }
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdstaffleaverequest.Visible = true;
            grdstaffleaverequest.DataSource = ds;
            grdstaffleaverequest.DataBind();
            errormessage.Visible = false;
        }
        else
        {
            grdstaffleaverequest.Visible = false;
            errormessage.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"clientscipts","alert('No records found for selected Criteria')",true);
            errormessage.Text = "No records found for selected Criteria";
        }
    }
    protected void grdstaffleaverequest_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        grdstaffleaverequest.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void txtgrdname_OnTextChanged(object sender, EventArgs e)
    {
        clearname();
        fillgrid();
    }
    protected void txtgrdriseddate_TextChanged(object sender, EventArgs e)
    {
        clearriseddate();
        fillgrid();
    }
    protected void txtgrdfromto_TextChanged(object sender, EventArgs e)
    {
        clearfromto();
        fillgrid();
    }
    protected void txtgrdleavetype_TextChanged(object sender, EventArgs e)
    {
        clearcategory();
        fillgrid();
    }
    protected void txtstatus_TextChanged(object sender, EventArgs e)
    {
        clearstatus();
        fillgrid();
    }
    protected void clearriseddate()
    {
        txtgrdfromto.Text = "";
        txtgrdname.Text = "";
        txtgrdleavetype.Text = "";
        txtstatus.Text = "";
    }
    protected void clearfromto()
    {
        txtgrdriseddate.Text = "";
        txtgrdname.Text = "";
        txtgrdleavetype.Text = "";
        txtstatus.Text = "";
    }
    protected void clearname()
    {
        txtgrdriseddate.Text = "";
        txtgrdfromto.Text = "";
        txtgrdleavetype.Text = "";
        txtstatus.Text = "";
    }
    protected void clearcategory()
    {
        txtgrdriseddate.Text = "";
        txtgrdfromto.Text = "";
        txtgrdname.Text = "";
        txtstatus.Text = "";
    }
    protected void clearstatus()
    {
        txtgrdriseddate.Text = "";
        txtgrdfromto.Text = "";
        txtgrdname.Text = "";
        txtgrdleavetype.Text = "";
    }
}
