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

public partial class Leave_cancelstaffleave : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    public string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clear();
            if (Session["PatronType"].ToString() == "Admin" || Session["PatronType"].ToString() == "Teaching Staffs" || Session["PatronType"].ToString() == "Non Teaching Staff")
            {
                try
                {
                    sql = "select * from tblemployee where intid=" + Session["UserID"].ToString();
                    da = new DataAccess();
                    ds = new DataSet();
                    ds = da.ExceuteSql(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlstafftype.SelectedValue = ds.Tables[0].Rows[0]["strtype"].ToString();
                        fillstaffname();
                        ddlstaffname.SelectedValue = Session["UserID"].ToString();
                        ddlstafftype.Enabled = false;
                        ddlstaffname.Enabled = false;
                        fillgrid();
                    }
                }
                catch { }
            }
        }
    }

    protected void fillgrid()
    {
        if (ddlstaffname.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            string sql = "select * from (select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Pending' as strstatus from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and intcancel=0 and a.intapproved=0 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Approved' as strstatus from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and a.intapproved=1 and (intcancel=0 or intcancel=3) and a.intschool=" + Session["SchoolID"].ToString() + " ) as a1 where intstaff=" + ddlstaffname.SelectedValue + " order by intid";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgapproveleave.DataSource = ds;
            dgapproveleave.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgapproveleave.Visible = true;
                lblerror.Visible = false;
            }
            else
            {
                clear();
            }
        }
    }

    protected void fillstafftype()
    {
        DataAccess da = new DataAccess();
        string sql = "select strtype from tblemployee where intid in(select intstaff from tblleaverequest where intapproved=1 and (intcancel=0 or intcancel=3) and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and intschool= " + Session["schoolID"].ToString() + ") group by strtype";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlstafftype.DataSource = ds;
        ddlstafftype.DataTextField = "strtype";
        ddlstafftype.DataValueField = "strtype";
        ddlstafftype.DataBind();
        ListItem list = new ListItem("All", "0");
        ddlstafftype.Items.Insert(0, list);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblerror.Visible = true;
            ddlstafftype.Enabled = false;
            ddlstaffname.Enabled = false;
        }
    }

    protected void fillstaffname()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql;
        if(ddlstafftype.SelectedIndex>0)
        sql= "select strfirstname + '' + strmiddlename + '' + strlastname as strstaffname,intid from tblemployee where intid in(select intstaff from tblleaverequest where intschool=2 and (intcancel=0 or intcancel=3) and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and intschool= " + Session["schoolID"].ToString() + ") and strtype='" + ddlstafftype.SelectedValue + "' and intschool='" + Session["schoolID"].ToString() + "'";
        else
            sql = "select strfirstname + '' + strmiddlename + '' + strlastname as strstaffname,intid from tblemployee where intid in(select intstaff from tblleaverequest where intapproved=1 and (intcancel=0 or intcancel=3) and cast(convert(varchar(10),dtfromdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and intschool= " + Session["schoolID"].ToString() + "  ) and intschool='" + Session["schoolID"].ToString() + "'";

        ds = da.ExceuteSql(sql);
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "strstaffname";
        ddlstaffname.DataValueField = "intid";
        ddlstaffname.DataBind();
        ListItem li = new ListItem("All", "0");
        ddlstaffname.Items.Insert(0, li);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        fillstafftype();
        fillstaffname();
        fillgrid();
    }

    protected void ddlstafftype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaffname();
    }

    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }


    protected void btnreject_Click(object sender, EventArgs e)
    {
        Button list = (Button)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        da = new DataAccess();
        string strsql;
        if (item.Cells[11].Text == "Approved")
        {
            strsql = "update tblleaverequest set intcancel=1,intcanceledby=" + Session["userID"].ToString() + ",dtcanceleddate=getdate() where intid ='" + item.Cells[0].Text + "'";
            Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),155);

        }
        else
        {
            strsql = "delete tblleaverequest where intid ='" + item.Cells[0].Text + "'";
            Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),155);
        }

        da.ExceuteSqlQuery(strsql);
        fillgrid();
    }

}
