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

public partial class Leave_viewstaffleaverequestdetails : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldetails();
            fillgrid();
            if (Request["rj"] != null)
            {
                lblreason1.Visible = false;
                txtreason.Visible = true;
                trreject.Visible = true;
            }
            else
            {
                lblreason1.Visible = true;
                txtreason.Visible = false;
                trreject.Visible = false;
            }
        }
    }

    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.*,b.strdepartmentname,c.strdesignation,d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,d.strtype,convert(varchar(10),dtdateofrequest,103) as strdateofrequest from tblleaverequest a,tbldesignation c,tbldepartment b,tblemployee d where d.intdepartment=b.intid and d.intdesignation=c.intid and a.intid='" + Request["id"].ToString() +"' and a.intschool='" + Session["SchoolID"].ToString() + "' and d.intid=a.intstaff";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstafftype1.Text = ds.Tables[0].Rows[0]["strtype"].ToString();
            lblstaffname1.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbldept1.Text = ds.Tables[0].Rows[0]["strdepartmentname"].ToString();
            lbldesig1.Text = ds.Tables[0].Rows[0]["strdesignation"].ToString();
            lblrequestdate2.Text = ds.Tables[0].Rows[0]["strdateofrequest"].ToString();
            lblreason1.Text = ds.Tables[0].Rows[0]["strreason"].ToString();
            if ((ds.Tables[0].Rows[0]["intapproved"].ToString() == "0" || ds.Tables[0].Rows[0]["intapproved"].ToString() == "1") && ds.Tables[0].Rows[0]["intcancel"].ToString() == "0")
                btnSave.Text = "Reject - Leave Request";
            if (ds.Tables[0].Rows[0]["intcancel"].ToString() == "1" || ds.Tables[0].Rows[0]["intcancel"].ToString() == "2")
                btnSave.Text = "Reject - Cancellation Request";
        }
    }

    protected void fillgrid()
    {
        DataAccess da = new DataAccess();

        string sql = "select a.*,convert(varchar(10),dtleavedate,103) as strleavedate,strleavetype from tblstaffleaves a, (select intid, strleavetype from tblschoolleavecategory union all select 0 as intid, 'Paid Leave' as strleavetype union all select -2 as intid, 'Rest Day' as strleavetype union all select -1 as intid, 'Unpaid Leave' as strleavetype) as b where a.intleavetype=b.intid and a.intleaverequest=" + Request["id"].ToString() + " order by dtleavedate";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgleaverequest1.DataSource = ds;
        dgleaverequest1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        da = new DataAccess();
        string strsql;
        if (btnSave.Text == "Reject - Leave Request")
        {
            strsql = "update tblleaverequest set intapproved = 2,strrejectreason='" + txtreason.Text + "',intapprovedby=" + Session["userID"].ToString() + " where intid =" + Request["id"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", Request["id"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

            da.ExceuteSqlQuery(strsql);
            delstaffattendance(Request["id"].ToString());
        }
        else if (btnSave.Text == "Reject - Cancellation Request")
        {
            strsql = "update tblleaverequest set intcancel = 3,strrejectreason='" + txtreason.Text + "',intcanceledby=" + Session["userID"].ToString() + " where intid =" + Request["id"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", Request["id"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

            da.ExceuteSqlQuery(strsql);
            //fillstaffattendance(Request["id"].ToString());
        }
        ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'approveleave.aspx'; </script>");
    }

    protected void fillstaffattendance(string id)
    {
        string strsql;
        da = new DataAccess();
        DataSet ds2 = new DataSet();
        strsql = "select intstaff,strtype,strreason,a.*,convert(varchar(10),dtleavedate,101) as strdate from tblstaffleaves a, tblleaverequest b, tblemployee c where b.intstaff=c.intid and a.intleaverequest=b.intid and b.intid=" + id;
        ds = da.ExceuteSql(strsql);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            da = new DataAccess();
            strsql = "insert into tblstaffattendance (intschool,strtype,intstaff,dtdate,strsession,strreason,intleaverequest,intleavetype)";
            strsql = strsql + "values(" + Session["SchoolID"].ToString() + ",'" + ds.Tables[0].Rows[i]["strtype"].ToString() + "'," + ds.Tables[0].Rows[i]["intstaff"].ToString() + ",'" + ds.Tables[0].Rows[i]["strdate"].ToString() + "','" + ds.Tables[0].Rows[i]["strsession"].ToString() + "','" + ds.Tables[0].Rows[i]["strreason"].ToString() + "'," + id + "," + ds.Tables[0].Rows[i]["intleavetype"].ToString() + ")";
            da.ExceuteSqlQuery(strsql);

            strsql = "select max(intid) as intid from tblstaffattendance";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tblstaffattendance", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);
        }
    }

    protected void delstaffattendance(string id)
    {
        string strsql;
        da = new DataAccess();
        ds = new DataSet();
        strsql = "delete tblstaffattendance where intleaverequest=" + id;
        Functions.UserLogs(Session["UserID"].ToString(), "tblstaffattendance", id, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

        da.ExceuteSqlQuery(strsql);
    }


}

