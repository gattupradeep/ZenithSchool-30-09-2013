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

public partial class Leave_approveleave : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
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
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql;
        sql = "select intID from tblleaverequest where intapproved=0 and cast(convert(varchar(10),dtfromdate,101) as datetime)<cast(convert(varchar(10),getdate(),101) as datetime)";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", ds.Tables[0].Rows[0]["intID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);
            }
        }
        sql = "update tblleaverequest set intapproved=2 where intapproved=0 and cast(convert(varchar(10),dtfromdate,101) as datetime)<cast(convert(varchar(10),getdate(),101) as datetime)";
        da.ExceuteSqlQuery(sql);

        da = new DataAccess();
        sql = "select intID from tblleaverequest where intcancel=1 and cast(convert(varchar(10),dtfromdate,101) as datetime)<cast(convert(varchar(10),getdate(),101) as datetime)";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", ds.Tables[0].Rows[0]["intID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);
            }
        }
        sql = "update tblleaverequest set intcancel=3 where intcancel=1 and cast(convert(varchar(10),dtfromdate,101) as datetime)<cast(convert(varchar(10),getdate(),101) as datetime)";
        da.ExceuteSqlQuery(sql);
        
        sql = "select * from (select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, ";
        sql = sql + "d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Pending' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 ";
        sql = sql + "from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment ";
        sql = sql + "and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and intcancel=0 and a.intapproved=0 and ";
        sql = sql + "a.intschool=" + Session["SchoolID"].ToString() + " union all ";
        sql = sql + "select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, ";
        sql = sql + "d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Approved' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 ";
        sql = sql + "from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment ";
        sql = sql + "and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and a.intapproved=1 and intcancel=0 ";
        sql = sql + "and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
        sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
        sql = sql + "'Rejected' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d ";
        sql = sql + "where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and intcancel=0 ";
        sql = sql + "and a.intapproved=2 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation,";
        sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
        sql = sql + "'Cancelled' as strstatus,'Leave Request' as strrequest,'Approved' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
        sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and ";
        sql = sql + "intcancel=2 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
        sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
        sql = sql + "'Approved' as strstatus,'Leave Request' as strrequest,'Pending' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
        sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and ";
        sql = sql + "intcancel=1 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
        sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
        sql = sql + "'Approved' as strstatus,'Leave Request' as strrequest,'Rejected' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
        sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and ";
        sql = sql + "intcancel=3 and a.intschool=" + Session["SchoolID"].ToString() + ") as a1 order by intid desc";
        //DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgapproveleave.DataSource = ds;
        dgapproveleave.DataBind();
    }

    protected void app_Click(object sender, EventArgs e)
    {
        Button list = (Button)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        Button Approve = new Button();
        Approve = (Button)item.FindControl("app");
        da = new DataAccess();
        if (Approve.Text == "Approve")
        {
            string strsql;
            if (item.Cells[11].Text == "Leave Request" && item.Cells[13].Text != "Cancellation Request")
            {
                strsql = "update tblleaverequest set intapproved = 1,intapprovedby=" + Session["userID"].ToString() + ",dtapproveddate=getdate() where intid ='" + item.Cells[0].Text + "'";
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text , "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

                da.ExceuteSqlQuery(strsql);
                fillstaffattendance(item.Cells[0].Text);
            }
            else
            {
                strsql = "update tblleaverequest set intcancel = 2,intcanceledby=" + Session["userID"].ToString() + ",dtcanceleddate=getdate() where intid ='" + item.Cells[0].Text + "'";
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

                da.ExceuteSqlQuery(strsql);
                delstaffattendance(item.Cells[0].Text);
            }
        }
        if (Approve.Text == "Unapprove")
        {              
            string strsql;
            if (item.Cells[11].Text == "Leave Request")
            {
                strsql = "update tblleaverequest set intapproved = 0,intapprovedby=" + Session["userID"].ToString() + " where intid ='" + item.Cells[0].Text + "'";
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

                da.ExceuteSqlQuery(strsql);
                delstaffattendance(item.Cells[0].Text);
            }
            else
            {
                strsql = "update tblleaverequest set intcancel = 1,intcanceledby=" + Session["userID"].ToString() + " where intid ='" + item.Cells[0].Text + "'";
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

                da.ExceuteSqlQuery(strsql);
                fillstaffattendance(item.Cells[0].Text);
            }
        }
        fillgrid();
    }

    protected void fillstaffattendance(string id)
    {
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
        da = new DataAccess();
        ds = new DataSet();
        strsql = "delete tblstaffattendance where intleaverequest=" + id;
        Functions.UserLogs(Session["UserID"].ToString(), "tblstaffattendance", id , "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),65);

        da.ExceuteSqlQuery(strsql);
    }

    protected void dgapproveleave_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            Button btnapp = (Button)e.Item.FindControl("app");
            HtmlInputButton btnreject = (HtmlInputButton)e.Item.FindControl("reject");
            //LinkButton btnview = (LinkButton)e.Item.FindControl("btnview");
            DataRowView dr = (DataRowView)e.Item.DataItem;
            //btnview.PostBackUrl="javascript:void(0);";
            //btnview.Attributes.Add("onclick", "showModal('viewstaffleaverequestdetails.aspx?id=" + dr["intid"].ToString() + "','755','400');");

            if ((dr["strstatus"].ToString() == "Approved" || dr["strstatus1"].ToString() == "Cancelled") && dr["strstatus1"].ToString() != "Pending")
            {
                if (DateTime.Today.Date > DateTime.Parse(dr["dtapproveddate"].ToString()).Date)
                {
                    btnapp.Text = "Approved";
                    btnapp.Enabled = false;
                    btnreject.Visible = false;
                    btnreject.Attributes.Add("Visible", "False");
                }
                else
                {
                    btnapp.Text = "Unapprove";
                    btnapp.Enabled = true;
                    btnreject.Visible = false;
                    btnreject.Attributes.Add("Visible", "False");
                }
            }
            else if (dr["strstatus1"].ToString() == "Pending" && dr["strrequest1"].ToString() == "Cancellation Request")
            {
                if (DateTime.Today.Date > DateTime.Parse(dr["dtapproveddate"].ToString()))
                {
                    btnapp.Text = "Approved";
                    btnapp.Enabled = false;
                    btnreject.Visible = false;
                    btnreject.Attributes.Add("Visible", "False");
                }
                else
                {
                    btnapp.Text = "Approve";
                    btnapp.Enabled = true;
                }
            }
            else if (dr["strstatus"].ToString() == "Rejected" || dr["strstatus1"].ToString() == "Rejected")
            {
                btnapp.Text = "Rejected";
                btnapp.Enabled = false;
                btnreject.Visible = false;
                btnreject.Attributes.Add("Visible", "False");
            }
            else if (dr["strstatus1"].ToString() == "Approved" && dr["strrequest1"].ToString() == "Cancellation Request")
            {
                btnapp.Text = "Approved";
                btnapp.Enabled = false;
                btnreject.Visible = false;
                btnreject.Attributes.Add("Visible", "False");
            }
            else if (dr["strstatus"].ToString() == "Pending" && dr["strrequest"].ToString() == "Leave Request")
            {
                btnapp.Text = "Approve";
                btnapp.Enabled = true;
            }
        }
        catch { }
    }
    protected void dgapproveleave_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("viewstaffleaverequestdetails.aspx?id=" +e.Item.Cells[0].Text);
    }
}
