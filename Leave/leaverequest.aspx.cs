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

public partial class school_leaverequest : System.Web.UI.Page
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
            fillstafftype();
            filldepartment();
            filldesignation();
            fillstaffname();
            fillday();
            fillyear();
            ddlday2.SelectedValue = DateTime.Now.Day.ToString();
            ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
            ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
            ddlday3.SelectedValue = DateTime.Now.Day.ToString();
            ddlmonth3.SelectedValue = DateTime.Now.Month.ToString();
            ddlyear3.SelectedValue = DateTime.Now.Year.ToString();
            trleavegrid.Visible = false;
            if (Session["PatronType"].ToString() == "Admin" || Session["PatronType"].ToString() == "Teaching Staffs" || Session["PatronType"].ToString() == "Non Teaching Staff")
            {
                try
                {
                    strsql="select * from tblemployee where intid=" + Session["UserID"].ToString();
                    da = new DataAccess();
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlstafftype.SelectedValue = ds.Tables[0].Rows[0]["strtype"].ToString();
                        filldepartment();
                        ddldepartment.SelectedValue = ds.Tables[0].Rows[0]["intdepartment"].ToString();
                        filldesignation();
                        ddldesignation.SelectedValue = ds.Tables[0].Rows[0]["intdesignation"].ToString();
                        fillstaffname();
                        ddlstaffname.SelectedValue = Session["UserID"].ToString();
                        ddlstafftype.Enabled = false;
                        ddldepartment.Enabled = false;
                        ddldesignation.Enabled = false;
                        ddlstaffname.Enabled = false;
                        fillgrid();
                    }
                }
                catch { }
            }
        }
    }

    protected void fillday()
    {
        int j = 0;
        for (int i = 1; i < 32; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlday2.Items.Insert(j, li);
            ddlday3.Items.Insert(j, li);
            j++;
        }
    }
    protected void fillyear()
    {
        int j = 0;
        for (int i = DateTime.Now.Year - 15; i < DateTime.Now.Year + 50; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear2.Items.Insert(j, li);
            ddlyear3.Items.Insert(j, li);
            j++;
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
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", ds.Tables[0].Rows[0]["intID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),64);

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
                Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", ds.Tables[0].Rows[0]["intID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),64);

            }
        }

        sql = "update tblleaverequest set intcancel=3 where intcancel=1 and cast(convert(varchar(10),dtfromdate,101) as datetime)<cast(convert(varchar(10),getdate(),101) as datetime)";
        da.ExceuteSqlQuery(sql);
       
        if (Session["PatronType"].ToString() == "Admin" || Session["PatronType"].ToString() == "Teaching Staffs" || Session["PatronType"].ToString() == "Non Teaching Staff")

        {
            sql = "select *,'' as leavetypes from (select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, ";
            sql = sql + "d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Pending' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 ";
            sql = sql + "from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment ";
            sql = sql + "and c.intid=d.intdesignation and d.intid=a.intstaff and intcancel=0 and a.intapproved=0 and d.intid="+ddlstaffname.SelectedValue+" and ";
            sql = sql + "a.intschool=" + Session["SchoolID"].ToString() + " union all ";
            sql = sql + "select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, ";
            sql = sql + "d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Approved' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 ";
            sql = sql + "from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment ";
            sql = sql + "and c.intid=d.intdesignation and d.intid=a.intstaff and a.intapproved=1 and intcancel=0 and d.intid="+ddlstaffname.SelectedValue+" and ";
            sql = sql + "a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Rejected' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d ";
            sql = sql + "where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and intcancel=0 and  d.intid="+ddlstaffname.SelectedValue+" and ";
            sql = sql + "a.intapproved=2 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation,";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Cancelled' as strstatus,'Leave Request' as strrequest,'Cancelled' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
            sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and  d.intid="+ddlstaffname.SelectedValue+" and ";
            sql = sql + "intcancel=2 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Approved' as strstatus,'Leave Request' as strrequest,'Pending' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
            sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and  d.intid="+ddlstaffname.SelectedValue+" and ";
            sql = sql + "intcancel=1 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Approved' as strstatus,'Leave Request' as strrequest,'Rejected' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
            sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and  d.intid="+ddlstaffname.SelectedValue+" and ";
            sql = sql + "intcancel=3 and a.intschool=" + Session["SchoolID"].ToString() + ") as a1 order by intid desc";
        }
        else
        {

            sql = "select *,'' as leavetypes from (select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, ";
            sql = sql + "d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Pending' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 ";
            sql = sql + "from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment ";
            sql = sql + "and c.intid=d.intdesignation and d.intid=a.intstaff and intcancel=0 and a.intapproved=0 and ";
            sql = sql + "a.intschool=" + Session["SchoolID"].ToString() + " union all ";
            sql = sql + "select a.*,b.strdepartmentname,c.strdesignation, convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, ";
            sql = sql + "d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,'Approved' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 ";
            sql = sql + "from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d where b.intid=d.intdepartment ";
            sql = sql + "and c.intid=d.intdesignation and d.intid=a.intstaff and a.intapproved=1 and intcancel=0 ";
            sql = sql + "and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Rejected' as strstatus,'Leave Request' as strrequest,'-' as strstatus1,'-' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, tblemployee d ";
            sql = sql + "where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and intcancel=0 ";
            sql = sql + "and a.intapproved=2 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation,";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Cancelled' as strstatus,'Leave Request' as strrequest,'Cancelled' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
            sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and ";
            sql = sql + "intcancel=2 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Approved' as strstatus,'Leave Request' as strrequest,'Pending' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
            sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and ";
            sql = sql + "intcancel=1 and a.intschool=" + Session["SchoolID"].ToString() + " union all select a.*,b.strdepartmentname,c.strdesignation, ";
            sql = sql + "convert(varchar(10),a.dtdateofrequest,103) as strdateofrequest, convert(varchar(10),a.dtfromdate,103) as strfromdate, convert(varchar(10),a.dttodate,103) as strtodate, d.strfirstname+' '+d.strmiddlename+' '+d.strlastname as name,";
            sql = sql + "'Approved' as strstatus,'Leave Request' as strrequest,'Rejected' as strstatus1,'Cancellation Request' as strrequest1 from tblleaverequest a, tbldepartment b, tbldesignation c, ";
            sql = sql + "tblemployee d where b.intid=d.intdepartment and c.intid=d.intdesignation and d.intid=a.intstaff and ";
            sql = sql + "intcancel=3 and a.intschool=" + Session["SchoolID"].ToString() + ") as a1 order by intid desc";
        }
       // DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string leavetype = "";
                sql = "select strleavetype + ' - ' + ltrim(str(sum(ct))) from(select strleavetype, count(*) as ct from tblstaffleaves a, tblschoolleavecategory b where strsession='Full Day' and a.intleavetype=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and intleaverequest=" + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strleavetype union all select strleavetype, count(*)*.5 as ct from tblstaffleaves a, tblschoolleavecategory b where strsession='Half Day' and a.intleavetype=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and intleaverequest=" + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strleavetype) as a group by strleavetype";
                DataSet ds1 = new DataSet();
                da = new DataAccess();
                ds1 = da.ExceuteSql(sql);
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    leavetype = leavetype + ds1.Tables[0].Rows[j][0].ToString() + "<br/>";
                ds.Tables[0].Rows[i]["leavetypes"] = leavetype;
            }
            dgleaverequest1.DataSource = ds;
            dgleaverequest1.DataBind();
            dgleaverequest1.Visible = true;
        }
        else
            dgleaverequest1.Visible = false;
    }

    protected void fillstafftype()
    {
        DataAccess da = new DataAccess();
        string sql = "select strtype from tblemployee where intschool= '" + Session["SchoolID"].ToString() + "' group by strtype ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlstafftype.DataSource = ds;
        ddlstafftype.DataTextField = "strtype";
        ddlstafftype.DataValueField = "strtype";
        ddlstafftype.DataBind();
        ListItem list = new ListItem("-select-", "0");
        ddlstafftype.Items.Insert(0, list);
    }

    protected void filldepartment()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select a.intdepartment,b.strdepartmentname,b.intid from tblemployee a, tbldepartment b where b.intid=a.intdepartment and a.intschool= '" + Session["SchoolID"].ToString() + "' and strtype= '" + ddlstafftype.SelectedValue + "' group by a.intdepartment,b.strdepartmentname,b.intid";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepartment.DataSource = ds;
        ddldepartment.DataTextField = "strdepartmentname";
        ddldepartment.DataValueField = "intid";
        ddldepartment.DataBind();
        ListItem list = new ListItem("-select-", "0");
        ddldepartment.Items.Insert(0, list);
    }

    protected void filldesignation()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select a.intdesignation,a.intdepartment,b.strdesignation,b.intid, c.strdepartmentname from tblemployee a, tbldesignation b,tbldepartment c where b.intid=a.intdesignation and c.intid=a.intdepartment and a.intschool= '" + Session["schoolID"].ToString() + "' and c.intid = '" + ddldepartment.SelectedValue + "' and a.strtype= '" + ddlstafftype.SelectedValue + "' group by a.intdesignation,a.intdepartment,b.strdesignation,b.intid, c.strdepartmentname";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "strdesignation";
        ddldesignation.DataValueField = "intid";
        ddldesignation.DataBind();
        ListItem list = new ListItem("-select-", "0");
        ddldesignation.Items.Insert(0, list);
    }

    protected void fillstaffname()
    {
        da = new DataAccess();
        strsql = "select intid,strfirstname + '' + strmiddlename + '' + strlastname as staffname, intid from tblemployee where intdepartment='" + ddldepartment.SelectedValue + "' and intdesignation='" + ddldesignation.SelectedValue + "' and strtype= '" + ddlstafftype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "staffname";
        ddlstaffname.DataValueField = "intid";
        ddlstaffname.DataBind();
        ListItem list = new ListItem("-select-", "0");
        ddlstaffname.Items.Insert(0, list);
    }

    protected void leavecalculation()
    {
        //da = new DataAccess();
        //DataSet ds = new DataSet();
        //strsql = "select a.intnoofdays from tblassignstaffleave a,tblschoolleavecategory b where a.intstaffid='" + ddlstaffname.SelectedValue + "' and a.intleavecategory='" + ddlleavetype.SelectedValue + "' and a.intschool='" + Session["schoolID"].ToString() + "'  and b.intid=a.intleavecategory";
        //ds = da.ExceuteSql(strsql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    float a = float.Parse(ds.Tables[0].Rows[0]["intnoofdays"].ToString());
        //    if (a == 0)
        //    {
        //        string sql4 = "delete tblleaverequest where intdept='" + ddldepartment.SelectedValue + "' and intdesig='" + ddldesignation.SelectedValue + "' and strstaffname='" + ddlstaffname.SelectedValue + "' and day(dtfromdate)=" + ddlday2.SelectedValue + " and month(dtfromdate)=" + ddlmonth2.SelectedValue + " and year(dtfromdate)=" + ddlyear2.SelectedValue + " and day(dttodate)=" + ddlday3.SelectedValue + " and month(dttodate)=" + ddlmonth3.SelectedValue + " and year(dttodate)=" + ddlyear3.SelectedValue + " and intschool='" + Session["schoolID"].ToString() + "'";
        //        da.ExceuteSqlQuery(sql4);
        //        MsgBox.alert("Number Of day is out of range");
        //    }
        //}
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strerror = checkleavevalidation();
            if (strerror == "")
            {
                if (btnSave.Text == "Save")
                {
                    SqlCommand command;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                    SqlParameter param;
                    SqlParameter OutPutParam;
                    conn.Open();
                    command = new SqlCommand("SPLeaverequest", conn);
                    param = command.Parameters.Add("ReturnValue", SqlDbType.Int);
                    param.Direction = ParameterDirection.ReturnValue;

                    OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
                    OutPutParam.Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@intid", "0");
                    command.Parameters.Add("@dtdateofrequest", DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString());
                    command.Parameters.Add("@dtfromdate", ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue);
                    command.Parameters.Add("@dttodate", ddlmonth3.SelectedValue + "/" + ddlday3.SelectedValue + "/" + ddlyear3.SelectedValue);
                    command.Parameters.Add("@strreason", txtreason.Text.Trim());
                    command.Parameters.Add("@intapproved", "0");
                    command.Parameters.Add("@intapprovedby", "0");
                    command.Parameters.Add("@dtapproveddate", DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString());
                    command.Parameters.Add("@intstaff", ddlstaffname.SelectedValue);
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.Parameters.Add("@intcancel", "0");
                    command.Parameters.Add("@intcanceledby", "0");
                    command.Parameters.Add("@strrejectreason", "0");
                    command.Parameters.Add("@dtcanceleddate", DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString());
                    command.ExecuteNonQuery();
                    if ((int)(command.Parameters["@rc"].Value) > 0)
                    {
                        int sid = (int)(command.Parameters["@rc"].Value);
                        saveleavedetails(sid);
                    }
                    conn.Close();
                }
                Response.Redirect("leaverequest.aspx");
            }
            else
            {
                MsgBox.alert(strerror);
            }
        }
        catch (Exception ex)
        {
            MsgBox.alert(ex.Message);
        }
    }

    protected string checkleavevalidation()
    {
        string[] a = new string[20];
        double[] b = new double[20];
        //int i = 0;
        int k = 0; 
        string strerror = "";
        foreach (DataGridItem dgi in dgleaverequest.Items)
        {
            int n = 0;
            DropDownList ddlLT = (DropDownList)dgi.FindControl("ddlleavetype");
            DropDownList ddlMOL = (DropDownList)dgi.FindControl("ddlmodeofleave");
            DropDownList ddlS = (DropDownList)dgi.FindControl("ddlsession");
            if (ddlLT.SelectedIndex > 0)
            {
                for (int j = 1; j <= k; j++)
                {
                    if (a[j] == ddlLT.SelectedValue)
                        n = j;
                }
                if (n == 0)
                {
                    k++;
                    a[k] = ddlLT.SelectedValue;
                    b[k] = 0;
                    if (ddlMOL.SelectedValue == "Full Day")
                        b[k] = b[k] + 1;
                    else
                        b[k] = b[k] + .5;
                }
                else
                {
                    if (ddlMOL.SelectedValue == "Full Day")
                        b[n] = b[n] + 1;
                    else
                        b[n] = b[n] + .5;
                }
                ddlLT.BackColor = System.Drawing.Color.White;
                ddlLT.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                ddlLT.BackColor = System.Drawing.Color.Red;
                ddlLT.ForeColor = System.Drawing.Color.White;
                strerror = "Please Select Leave Type";
            }
        }

        if (strerror == "")
        {
            for (int j = 1; j <= k; j++)
            {
                strsql = "";
                strsql = strsql + "select * from(select c.intid,c.strleavetype,intnoofdays-ct as avail from tblassignstaffleave a, ";
                strsql = strsql + "(select intstaff,intleavetype,sum(ct) as ct from ";
                strsql = strsql + "(select intstaff,intleavetype,count(*) as ct from tblstaffattendance ";
                strsql = strsql + "where intstaff=" + ddlstaffname.SelectedValue + " and strsession='Full Day' and intschool=" + Session["SchoolID"].ToString() + " ";
                strsql = strsql + " group by intstaff,intleavetype ";
                strsql = strsql + "union all ";
                strsql = strsql + "select intstaff,intleavetype,count(*)*.5 as ct from tblstaffattendance ";
                strsql = strsql + "where intstaff=" + ddlstaffname.SelectedValue + " and strsession like 'Half Day%' and intschool=" + Session["SchoolID"].ToString() + " ";
                strsql = strsql + "group by intstaff,intleavetype ";
                strsql = strsql + " union all select intstaff,intleavetype,count(*) as ct from tblleaverequest a, tblstaffleaves b where a.intid=b.intleaverequest and ";
                strsql = strsql + " a.intstaff=" + ddlstaffname.SelectedValue + " and strsession='Full Day' and intapproved=0 and intcancel=0 and a.intschool=" + Session["SchoolID"].ToString() + " ";
                strsql = strsql + " group by intstaff,intleavetype ";
                strsql = strsql + " union all select intstaff,intleavetype,count(*)*.5 as ct from tblleaverequest a, tblstaffleaves b where a.intid=b.intleaverequest and ";
                strsql = strsql + " a.intstaff=" + ddlstaffname.SelectedValue + " and strsession like 'Half Day%' and intapproved=0 and intcancel=0 and a.intschool=" + Session["SchoolID"].ToString() + " ";
                strsql = strsql + "group by intstaff,intleavetype) as a ";
                strsql = strsql + "group by intstaff,intleavetype) as b,tblschoolleavecategory c ";
                strsql = strsql + "where a.intstaffid=b.intstaff and a.intleavecategory=b.intleavetype and a.intleavecategory=c.intid ";
                strsql = strsql + "and a.intschool=" + Session["SchoolID"].ToString() + " ";
                strsql = strsql + "union all ";
                strsql = strsql + "select b.intid,b.strleavetype,intnoofdays as avail ";
                strsql = strsql + "from tblassignstaffleave a, tblschoolleavecategory b where ";
                strsql = strsql + "a.intleavecategory=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intstaffid=" + ddlstaffname.SelectedValue + " ";
                strsql = strsql + "and b.intid not in( ";
                strsql = strsql + "select intleavetype from tblstaffattendance ";
                strsql = strsql + "where intstaff=" + ddlstaffname.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by intleavetype)) as a where intid=" + a[j].ToString();
                da = new DataAccess();
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (b[j] > double.Parse(ds.Tables[0].Rows[0]["avail"].ToString()))
                    {
                        strerror = "Requested " + ds.Tables[0].Rows[0]["strleavetype"].ToString() + "Exceeds available no of leaves,";
                    }
                }
            }
            return strerror;
        }
        else
            return strerror;
    }

    protected void saveleavedetails(int id)
    {
        foreach (DataGridItem dgi in dgleaverequest.Items)
        {
            DropDownList ddlLT = (DropDownList)dgi.FindControl("ddlleavetype");
            DropDownList ddlMOL = (DropDownList)dgi.FindControl("ddlmodeofleave");
            string strsql;
            if (ddlMOL.SelectedIndex == 0)
            {
                strsql = "insert into tblstaffleaves (intleaverequest,dtleavedate,intleavetype,strdaymode,strsession,intschool)";
                strsql = strsql + " values(" + id + ",'" + dgi.Cells[0].Text + "','" + ddlLT.SelectedValue + "','Fullday',";
                strsql = strsql + "'" + ddlMOL.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            else
            {
                strsql = "insert into tblstaffleaves (intleaverequest,dtleavedate,intleavetype,strdaymode,strsession,intschool)";
                strsql = strsql + " values(" + id + ",'" + dgi.Cells[0].Text + "','" + ddlLT.SelectedValue + "','Halfday',";
                strsql = strsql + "'" + ddlMOL.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            //if (ddlMOL.SelectedValue.IndexOf("Fullday") > -1)
            //{
            //    strsql = "insert into tblstaffleaves (intleaverequest,dtleavedate,intleavetype,strdaymode,strsession,intschool)";
            //    strsql = strsql + " values(" + id + ",'" + dgi.Cells[0].Text + "','" + ddlLT.SelectedValue + "','Fullday',";
            //    strsql = strsql + "'" + ddlMOL.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            //}
            //else
            //{
            //    strsql = "insert into tblstaffleaves (intleaverequest,dtleavedate,intleavetype,strdaymode,strsession,intschool)";
            //    strsql = strsql + " values(" + id + ",'" + dgi.Cells[0].Text + "','" + ddlLT.SelectedValue + "','Halfday',";
            //    strsql = strsql + "'" + ddlMOL.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            //}
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void Clear()
    {
        fillstafftype();
        fillstaffname();
        filldepartment();
        filldesignation();
        txtreason.Text = "";
        ddlday2.SelectedValue = DateTime.Now.Day.ToString();
        ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
        ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
        ddlday3.SelectedValue = DateTime.Now.Day.ToString();
        ddlmonth3.SelectedValue = DateTime.Now.Month.ToString();
        ddlyear3.SelectedValue = DateTime.Now.Year.ToString();
        btnSave.Text = "Save";
        trleavegrid.Visible = false;
        dlavailleave.Visible = false;
    }   

    protected void dgleaverequest_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        fillstafftype();
        ddlstafftype.SelectedValue = e.Item.Cells[1].Text;
        filldepartment();
        ddldepartment.SelectedValue = e.Item.Cells[13].Text;
        filldesignation();
        ddldesignation.SelectedValue = e.Item.Cells[14].Text;
        fillstaffname();       
        ddlstaffname.SelectedValue = e.Item.Cells[4].Text;
    }

    protected void ddlstafftype_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldepartment();
        filldesignation();
        fillstaffname();
    }

    protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldesignation();
        fillstaffname();
    }

    protected void ddldesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaffname();
    }

    protected void ddlleavetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        leavecalculation();
    }

    protected void btnsetleave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlstafftype.SelectedIndex > 0)
            {
                if (ddldepartment.SelectedIndex > 0)
                {
                    if (ddldesignation.SelectedIndex > 0)
                    {
                    if (ddlstaffname.SelectedIndex > 0)
                    {
                        if (DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue) > DateTime.Parse(ddlyear3.SelectedValue + "/" + ddlmonth3.SelectedValue + "/" + ddlday3.SelectedValue))
                        {
                            MsgBox.alert("To Date should not be Less Than From Date");
                        }
                        else if (DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue) < DateTime.Today)
                        {
                            MsgBox.alert("From Date should not be Less Than Current Date");
                        }
                        else
                        {
                            da = new DataAccess();
                            strsql = "select * from tblstaffattendance where strtype='" + ddlstafftype.SelectedValue + "' and dtdate='" + ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "' and intleaverequest=0 and intschool=" + Session["SchoolID"].ToString();
                            ds = new DataSet();
                            ds = da.ExceuteSql(strsql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MsgBox.alert("Attendance Has Been Taken For The Selected Date. Please Select Another Date To Continue");
                            }
                            else
                            {
                                fillleaveavail();
                                strsql = "";
                                DateTime fdt = DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue);
                                DateTime tdt = DateTime.Parse(ddlyear3.SelectedValue + "/" + ddlmonth3.SelectedValue + "/" + ddlday3.SelectedValue);
                                for (DateTime dt = fdt; dt <= tdt; dt = dt.AddDays(1))
                                {
                                    da = new DataAccess();
                                    string strsql1 = "select * from tblacademiccalender where intschool=" + Session["SchoolID"].ToString() + " and dtdate='" + dt.ToString("yyyy/MM/dd") + "'";
                                    ds = new DataSet();
                                    ds = da.ExceuteSql(strsql1);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                    }
                                    else
                                    {
                                        da = new DataAccess();
                                        strsql1 = "select intid from tblstaffattendance where intstaff=" + ddlstaffname.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " and dtdate='" + dt.ToString("yyyy/MM/dd") + "'";
                                        strsql1 = strsql1 + " union all select intid from tblstaffleaves where intleaverequest in (select intid from tblleaverequest where intstaff=" + ddlstaffname.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + ") and dtleavedate='" + dt.ToString("yyyy/MM/dd") + "'";
                                        ds = new DataSet();
                                        ds = da.ExceuteSql(strsql1);
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                        }
                                        else
                                        {
                                            if (strsql == "")
                                                strsql = "select '" + dt.ToString("yyyy/MM/dd") + "' as strdate ";
                                            else
                                                strsql = strsql + "union all select '" + dt.ToString("yyyy/MM/dd") + "' as strdate ";
                                        }
                                    }
                                }
                                da = new DataAccess();
                                ds = new DataSet();
                                if (strsql != "")
                                {
                                    ds = da.ExceuteSql(strsql);
                                    dgleaverequest.DataSource = ds;
                                    dgleaverequest.DataBind();
                                    trleavegrid.Visible = true;
                                }
                                else
                                {
                                    MsgBox.alert("Already Leave Assigned for the Requested Date(s)");
                                    trleavegrid.Visible = false;
                                }
                            }
                        }
                    }
                    else
                        MsgBox.alert("Select Staff Name");
                    }
                    else
                        MsgBox.alert("Select Designation");
                }
                else
                    MsgBox.alert("Select Department");
            }
            else
                MsgBox.alert("Select StaffType");
            fillgrid();
        }
        catch (Exception ex)
        {
            MsgBox.alert(ex.Message);
        }
    }

    protected void fillleaveavail()
    {
        string resleavetype="";
        strsql = "";
        strsql = strsql + "select c.strleavetype,intnoofdays-ct as avail,intnoofdays from tblassignstaffleave a, ";
        strsql = strsql + "(select intstaff,intleavetype,sum(ct) as ct from ";
        strsql = strsql + "(select intstaff,intleavetype,count(*) as ct from tblstaffattendance ";
        strsql = strsql + "where intstaff=" + ddlstaffname.SelectedValue + " and strsession='Full Day' and intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + " group by intstaff,intleavetype ";
        strsql = strsql + "union all ";
        strsql = strsql + "select intstaff,intleavetype,count(*)*.5 as ct from tblstaffattendance ";
        strsql = strsql + "where intstaff=" + ddlstaffname.SelectedValue + " and strsession like 'Half Day%' and intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + "group by intstaff,intleavetype ";
        strsql = strsql + " union all select intstaff,intleavetype,count(*) as ct from tblleaverequest a, tblstaffleaves b where a.intid=b.intleaverequest and ";
        strsql = strsql + " a.intstaff=" + ddlstaffname.SelectedValue + " and strsession='Full Day' and intapproved=0 and intcancel=0 and a.intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + " group by intstaff,intleavetype ";
        strsql = strsql + " union all select intstaff,intleavetype,count(*)*.5 as ct from tblleaverequest a, tblstaffleaves b where a.intid=b.intleaverequest and ";
        strsql = strsql + " a.intstaff=" + ddlstaffname.SelectedValue + " and strsession like 'Half Day%' and intapproved=0 and intcancel=0 and a.intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + "group by intstaff,intleavetype) as a ";
        strsql = strsql + "group by intstaff,intleavetype) as b,tblschoolleavecategory c ";
        strsql = strsql + "where a.intstaffid=b.intstaff and a.intleavecategory=b.intleavetype and a.intleavecategory=c.intid ";
        strsql = strsql + "and a.intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + "union all ";
        strsql = strsql + "select b.strleavetype,intnoofdays as avail,intnoofdays ";
        strsql = strsql + "from tblassignstaffleave a, tblschoolleavecategory b where ";
        strsql = strsql + "a.intleavecategory=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intstaffid=" + ddlstaffname.SelectedValue + " ";
        strsql = strsql + "and b.intid not in( ";
        strsql = strsql + "select intleavetype from tblstaffattendance ";
        strsql = strsql + "where intstaff=" + ddlstaffname.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by intleavetype) ";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if(double.Parse(ds.Tables[0].Rows[i]["avail"].ToString())==0)
                {
                    if (resleavetype != "")
                        resleavetype = resleavetype + ",'" + ds.Tables[0].Rows[i]["strleavetype"].ToString() + "'";
                    else
                        resleavetype = resleavetype +  "'" + ds.Tables[0].Rows[i]["strleavetype"].ToString() + "'";
                }
            }
            Session["ResLeavetype"] = resleavetype;
            dlavailleave.DataSource = ds;
            dlavailleave.DataBind();
            dlavailleave.Visible = true;
        }
        else
            dlavailleave.Visible = false;
    }

    protected void dgleaverequest_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DropDownList ddlLT = (DropDownList)e.Item.FindControl("ddlleavetype");
            DropDownList ddlMOL = (DropDownList)e.Item.FindControl("ddlmodeofleave");
            DropDownList ddlS = (DropDownList)e.Item.FindControl("ddlsession");
            DataAccess da = new DataAccess();
            string sql;
            if (Session["ResLeavetype"] != null && Session["ResLeavetype"].ToString() != "")
                sql = "select a.intleavecategory, b.strleavetype from tblassignstaffleave a,tblschoolleavecategory b  where intstaffid='" + ddlstaffname.SelectedValue + "' and b.intid=a.intleavecategory and a.intschool=" + Session["SchoolID"].ToString() + "  and strleavetype not in(" + Session["ResLeavetype"].ToString() + ") order by strleavetype";
            else
                sql = "select a.intleavecategory, b.strleavetype from tblassignstaffleave a,tblschoolleavecategory b  where intstaffid='" + ddlstaffname.SelectedValue + "' and b.intid=a.intleavecategory and a.intschool=" + Session["SchoolID"].ToString() + "  order by strleavetype";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            ddlLT.DataSource = ds;
            ddlLT.DataTextField = "strleavetype";
            ddlLT.DataValueField = "intleavecategory";
            ddlLT.DataBind();
            ListItem list = new ListItem("-Select-", "-1");
            ddlLT.Items.Insert(0, list);
            list = new ListItem("Paid Leave", "0");
            ddlLT.Items.Add(list);
            list = new ListItem("Unpaid Leave", "-1");
            ddlLT.Items.Add(list);
            list = new ListItem("Rest Day", "-2");
            ddlLT.Items.Add(list);
        }
        catch { }
    }

    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstaffname.SelectedIndex > 0)
        {
            fillgrid();
        }
        else
        {
            dgleaverequest1.Visible = false;
        }
    }

    protected void btnreject_Click(object sender, EventArgs e)
    {
        Button list = (Button)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        Button Approve = new Button();
        Approve = (Button)item.FindControl("app");
        da = new DataAccess();
        string strsql;
        strsql = "delete tblleaverequest where intid ='" + item.Cells[0].Text + "'";
        Functions.UserLogs(Session["UserID"].ToString(), "tblleaverequest", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),64);

        da.ExceuteSqlQuery(strsql);
        fillgrid();
    }
    protected void dgleaverequest1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            Button btnreject = (Button)e.Item.FindControl("btnreject");
            DataRowView dr = (DataRowView)e.Item.DataItem;

            if (dr["strstatus"].ToString() == "Pending")
                btnreject.Enabled = true;
            else
                btnreject.Enabled = false;
        }
        catch { }
    }
}
