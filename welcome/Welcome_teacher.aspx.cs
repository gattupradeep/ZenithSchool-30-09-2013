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
using System.Reflection;


public partial class welcome_Welcome_teacher : System.Web.UI.Page
{
    //Session["UserID"]
    public DataAccess da;
    public DataSet ds;
    public string str;
    public int nindex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Schoolid"] = 2;
        if (!IsPostBack)
        {
            fillnoticegrid();
            fillremaindergrid();
            fillquickviewgrid();
            lbltimetabledate.Text = DateTime.Today.Date.ToString();
            lbltimetabletoday.Text = DateTime.Today.DayOfWeek.ToString();
            lbltimetable2marrow.Text = DateTime.Today.AddDays(1).DayOfWeek.ToString();
            lbltimetableyesterday.Text = DateTime.Today.AddDays(-1).DayOfWeek.ToString();
            filltimetable();
            DateTime dt = DateTime.Now;
            lblsheduledate.Text = string.Format("{0:dd\\/MM\\/yyyy }", dt);
            lblhomeworkdate.Text = string.Format("{0:dd\\/MM\\/yyyy }", dt);
            fillThisweek();
            fillclass();            
            fillattendance();
            fillLeave();
            ddlHsubject.Items.Insert(0, "Subject");
            ddlSsubject.Items.Insert(0, "Subject");
        }
    }

    protected void btnNprevious_Click(object sender, ImageClickEventArgs e)
    {
        nindex = int.Parse(lblnoticeindex.Text) + 1;
        if (nindex < int.Parse(lblnoticecount.Text))
        {
            dgnotice.CurrentPageIndex = nindex;
            lblnoticeindex.Text = nindex.ToString();
            fillnoticegrid();
        }
    }

    protected void btnNnext_Click(object sender, ImageClickEventArgs e)
    {
        nindex = int.Parse(lblnoticeindex.Text) - 1;
        if (nindex >= 0)
        {
            dgnotice.CurrentPageIndex = nindex;
            lblnoticeindex.Text = nindex.ToString();
            fillnoticegrid();
        }
    }

    protected void fillnoticegrid()
    {
        da = new DataAccess();
        str = "select top 1 a.*,strnoticename,convert(varchar(11),a.dtdate,113) as date from tbldailynotice a,tblnoticeboard b where a.intnotice=b.intid  and a.intschool=" + Session["SchoolID"] + " order by dtdate desc";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        lblnoticecount.Text = ds.Tables[0].Rows.Count.ToString();
        dgnotice.DataSource = ds;
        dgnotice.DataBind();
    }

    protected void fillremaindergrid()
    {
        da = new DataAccess();
        str = "SELECT *,convert(varchar(10),remainder_end,103) as strdate FROM tblremainder WHERE intschool=2 and strpatrontype='" + Session["Patrontype"].ToString() + "' and Userid=" + Session["Userid"].ToString() + " order by remainder_end desc";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        dgreminder.DataSource = ds;
        dgreminder.DataBind();
    }
    protected void fillquickviewgrid()
    {
        string strtype = Session["PatronType"].ToString();
        if (Session["PatronType"] == "Teaching Staffs")
        {
            da = new DataAccess();
            str = "select(select count(*) from(select * from tblmailbox where intreceiverid='" + Session["UserID"].ToString() + "' and intviewed = 0) as a) as unreadcount,count(*) as totalcount from tblmailbox where intreceiverid='" + Session["UserID"].ToString() + "' and strpatrontype='Teaching Staffs'";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            dgquickview.DataSource = ds;
            dgquickview.DataBind();
        }
        else
        {
            da = new DataAccess();
            str = "select(select count(*) from(select * from tblmailbox where intreceiverid='" + Session["UserID"].ToString() + "' and intviewed = 0) as a) as unreadcount,count(*) as totalcount from tblmailbox where intreceiverid='" + Session["UserID"].ToString() + "' and strpatrontype='Non Teaching Staff'";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            dgquickview.DataSource = ds;
            dgquickview.DataBind();
        }
      
    }
    protected void fillattendance()
    {
        //Session["admin"] = 2;
        DataSet ds2 = new DataSet();
        DataAccess da2 = new DataAccess();
        int noofdays = 0;
        string str = "";
        string str2 = "select year('" + DateTime.Now.ToString("yyyy/MM/dd") + "') as years,month('" + DateTime.Now.ToString("yyyy/MM/dd") + "') as months";
        ds2 = da2.ExceuteSql(str2);
        int year = int.Parse(ds2.Tables[0].Rows[0]["years"].ToString());
        int month = int.Parse(ds2.Tables[0].Rows[0]["months"].ToString());
        int mon = int.Parse(DateTime.Now.Month.ToString());
        int yea = int.Parse(DateTime.Now.Year.ToString());
        if ((month == mon) && (year == yea))
        {
            noofdays = DateTime.Today.Day;
        }
        else
        {
            noofdays = DateTime.DaysInMonth(year, month);
        }

        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as staffname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
        str += " 'P' as c7,'P' as c8,'P' as c9,";
        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
        str += " " + noofdays.ToString() + ".00 as present, 0.00 as absent, 0.00 as percentage from tblemployee where";
        str += " intschool='" + Session["schoolID"].ToString() + "' and intid=" + Session["UserID"].ToString();
        ds = da.ExceuteSql(str);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataSet ds1 = new DataSet();
            DataAccess da1 = new DataAccess();
            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstaffattendance where";
            sql += " intstaff=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
            sql += " strtype='" + Session["PatronType"].ToString() + "' and month(dtdate)=" + month + " and";
            sql += " year(dtdate)=" + year + "";
            ds1 = da1.ExceuteSql(sql);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Fullday")
                {
                    ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "A";
                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 1;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 1;
                }
                else
                {
                    ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "H";
                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 0.5;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 0.5;
                }
                double p = double.Parse(ds.Tables[0].Rows[i]["present"].ToString());
                double percentage = ((p / noofdays) * 100);
                double b = double.Parse(String.Format("{0:0.##}", percentage));
                ds.Tables[0].Rows[i]["percentage"] = b;
            }
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows[i]["percentage"] = "100.00";
            }
        }
        lblabsent.Text = ds.Tables[0].Rows[0]["absent"].ToString();
        lblpresent.Text = ds.Tables[0].Rows[0]["present"].ToString();
    }

    protected void fillLeave()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.intid as id,'Approved' as intapproved,a.*,convert(varchar(11),a.dtdateofrequest,103) as redate,b.strdepartmentname,";
        sql += " c.strdesignation,d.strfirstname+''+d.strmiddlename+''+d.strlastname as name from tblleaverequest a,";
        sql += " tbldepartment b,tbldesignation c,tblemployee d where day(dtfromdate) <= day(getdate())  and";
        sql += " month(dtfromdate)<= month(getdate()) and year(dtfromdate) <= year(getdate()) and intapproved=1 and day(dttodate) >= day(getdate()) and month(dttodate) >= month(getdate()) and year(dttodate) >= year(getdate()) and";
        sql += " intcancel<=1 and a.intschool='" + Session["SchoolID"].ToString() + "' and b.intid=d.intdepartment and c.intid=d.intdesignation and";
        sql += " d.intid=a.intstaff and";
        sql += " d.intid=" + Session["UserID"].ToString();
        sql += " union all select a.intid as id,'Pending' as intapproved, a.*,convert(varchar(11),a.dtdateofrequest,103) as redate,";
        sql += " b.strdepartmentname,c.strdesignation,d.strfirstname+''+d.strmiddlename+''+d.strlastname as name from";
        sql += " tblleaverequest a,tbldepartment b,tbldesignation c,tblemployee d where a.intapproved=0 and intcancel<=1 and";
        sql += " a.intschool='" + Session["SchoolID"].ToString() + "' and b.intid=d.intdepartment and c.intid=d.intdesignation and";
        sql += " d.intid=" + Session["UserID"].ToString() + " and";
        sql += " d.intid=a.intstaff";
        sql += " union all select a.intid as id,'Rejected' as intapproved, a.*,convert(varchar(11),a.dtdateofrequest,103) as redate,";
        sql += " b.strdepartmentname,c.strdesignation,d.strfirstname+''+d.strmiddlename+''+d.strlastname as name";
        sql += " from tblleaverequest a,tbldepartment b,tbldesignation c,tblemployee d where";
        sql += " day(dtfromdate) <= day(getdate())  and month(dtfromdate) <= month(getdate()) and";
        sql += " year(dtfromdate) <= year(getdate()) and day(dttodate) >= day(getdate()) and month(dttodate) >= month(getdate()) and year(dttodate) >= year(getdate()) and intapproved=2 and intcancel<=1 and";
        sql += " a.intschool='" + Session["SchoolID"].ToString() + "' and b.intid=d.intdepartment and c.intid=d.intdesignation and";
        sql += " d.intid=a.intstaff and d.intid=" + Session["UserID"].ToString();
        sql += " union all select a.intid as id,'Canceled' as intapproved, a.*,convert(varchar(11),a.dtdateofrequest,103) as redate,";
        sql += " b.strdepartmentname,c.strdesignation,d.strfirstname+''+d.strmiddlename+''+d.strlastname as name from";
        sql += " tblleaverequest a,tbldepartment b,tbldesignation c,tblemployee d where day(dtfromdate) <= day(getdate())  and";
        sql += "  month(dtfromdate) <= month(getdate()) and year(dtfromdate) <= year(getdate()) and day(dttodate) >= day(getdate()) and month(dttodate) >= month(getdate()) and year(dttodate) >= year(getdate()) and intapproved=1 and";
        sql += " intcancel=2 and a.intschool='" + Session["SchoolID"].ToString() + "' and b.intid=d.intdepartment and c.intid=d.intdesignation and";
        sql += " d.intid=a.intstaff and";
        sql += " d.intid=" + Session["UserID"].ToString();
        sql += " union all select a.intid as id,'Canceled' as intapproved, a.*,convert(varchar(11),a.dtdateofrequest,103) as redate,";
        sql += " b.strdepartmentname,c.strdesignation,d.strfirstname+''+d.strmiddlename+''+d.strlastname as name from";
        sql += " tblleaverequest a,tbldepartment b,tbldesignation c,tblemployee d where day(dtfromdate) <= day(getdate())  and";
        sql += "  month(dtfromdate) <= month(getdate()) and year(dtfromdate) <= year(getdate()) and day(dttodate) >= day(getdate()) and month(dttodate) >= month(getdate()) and year(dttodate) >= year(getdate()) and";
        sql += " intcancel=4 and a.intschool='" + Session["SchoolID"].ToString() + "' and b.intid=d.intdepartment and c.intid=d.intdesignation and";
        sql += " d.intid=a.intstaff and";
        sql += " d.intid=" + Session["UserID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["intapproved"].ToString() == "Pending")
            {
                lblpending.Text = ds.Tables[0].Rows.Count.ToString();
                lblreject.Text = "0";
            }
            else if (ds.Tables[0].Rows[0]["intapproved"].ToString() == "Rejected")
            {
                lblreject.Text = ds.Tables[0].Rows.Count.ToString();
                lblpending.Text = "0";
            }
            else
            {
                lblreject.Text = "0";
                lblpending.Text = "0";
            }
        }
        else
        {
            lblreject.Text = "0";
            lblpending.Text = "0";
        }
    }

    protected void fillclass()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strteachclass from tblteachingclass where intschool='" + Session["SchoolID"].ToString() + "' and intemployee=" + Session["UserID"].ToString() + " group by strteachclass";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlSclass.Items.Clear();
        ddlSclass.DataSource = ds;
        ddlSclass.DataTextField = "strteachclass";
        ddlSclass.DataValueField = "strteachclass";
        ddlSclass.DataBind();
        ddlSclass.Items.Insert(0, "Class");
        ddlHclass.Items.Clear();
        ddlHclass.DataSource = ds;
        ddlHclass.DataTextField = "strteachclass";
        ddlHclass.DataValueField = "strteachclass";
        ddlHclass.DataBind();
        ddlHclass.Items.Insert(0, "Class");
    }

    protected void fillsubject()
    {
        string str;
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select strsubject from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard +' - ' + strsection='" + ddlSclass.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(str);
        ddlSsubject.Items.Clear();
        ddlSsubject.DataSource = ds;
        ddlSsubject.DataTextField = "strsubject";
        ddlSsubject.DataValueField = "strsubject";
        ddlSsubject.DataBind();
        ddlSsubject.Items.Insert(0, "Subject");        
    }

    protected void fillhsubject()
    {
        string str;
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select strsubject from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard +' - ' + strsection='" + ddlHclass.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(str);
        ddlHsubject.Items.Clear();
        ddlHsubject.DataSource = ds;
        ddlHsubject.DataTextField = "strsubject";
        ddlHsubject.DataValueField = "strsubject";
        ddlHsubject.DataBind();
        ddlHsubject.Items.Insert(0, "Subject");
    }

    protected void fillTeachingshedule()
    {
        string str;
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select a.dtdate,b.strtextbookname+'/'+a.strunitname as unit,a.strlessonName as lesson, a.strtopic from tblsetlessonplan a,tblschooltextbook b where a.intteacher=" + Session["UserID"].ToString() + " and a.inttextbook=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
        if (ddlSsubject.SelectedIndex > 0)
            str = str + " and a.strsubject='" + ddlSsubject.SelectedValue + "'";
        str = str + " and convert(varchar(10),a.dtdate,103)='" + lblsheduledate.Text + "'";
        str = str + " and b.strclass='" + ddlSclass.SelectedValue + "' group by a.dtdate,a.inttextbook,a.strunitname,a.strlessonName,a.strtopic,b.strtextbookname order by a.dtdate desc";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgteachingshedule.DataSource = ds;
            dgteachingshedule.DataBind();
            dgteachingshedule.Visible = true;
            lblshedule.Visible = false;
        }
        else
        {
            dgteachingshedule.Visible = false;
            lblshedule.Visible = true;
            lblshedule.Text = "No schedule is added";
        }
    }

    protected void ddlSclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgteachingshedule.Visible = false;        
        fillsubject();
    }

    protected void ddlSsec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSclass.SelectedIndex > 0 && ddlSsubject.SelectedIndex > 0)
        {
            fillTeachingshedule();
            dgteachingshedule.Visible = true;
        }
        else
            dgteachingshedule.Visible = false; 
        
    }

    protected void ddlSsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSclass.SelectedIndex > 0 && ddlSsubject.SelectedIndex > 0)
        {
            fillTeachingshedule();
            dgteachingshedule.Visible = true;
        }
        else
        {
            dgteachingshedule.Visible = false;
        }
    }

    protected void fillhomework()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds, ds1 = new DataSet();
        str = "select a.intid, b.strstandard,b.strsubject,b.strtopic,convert(varchar(10),a.dtduedate,103)as duedate,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tblhomework a, tblhomeworktopics b,tblemployee c where a.inttopic=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and c.intid=a.intemployee";
        if (ddlHclass.SelectedIndex > 0)
            str = str + " and b.strstandard='" + ddlHclass.SelectedValue + "'";
        if (ddlHsubject.SelectedIndex > 0)
            str = str + " and b.strsubject='" + ddlHsubject.SelectedValue + "'";
        str = str + " and c.intid=" + Session["UserID"].ToString() + " and convert(varchar(10),a.dtassigndate,103)='" + lblhomeworkdate.Text + "'";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblhomework.Text = "No homework is assigned";
            dghomework.Visible = false;
            lblhomework.Visible = true;
        }
        else
        {
            dghomework.DataSource = ds;
            dghomework.DataBind();
            dghomework.Visible = true;
            lblhomework.Visible = false;
        }
    }

    protected void ddlHclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        dghomework.Visible = false;
        fillhsubject();
    }

    protected void ddlHsec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHclass.SelectedIndex > 0 && ddlHsubject.SelectedIndex > 0)
        {
            fillhomework();
            dghomework.Visible = true;
        }
        else
            dghomework.Visible = false;       
    }

    protected void ddlHsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHclass.SelectedIndex > 0 && ddlHsubject.SelectedIndex > 0)
        {
            fillhomework();
            dghomework.Visible = true;
        }
        else
        {
            dghomework.Visible = false;
        }
    }

    protected void fillThisweek()
    {
        string str;
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select convert(varchar(7),event_start,100)+' To '+convert(varchar(7),event_end,100)as date,*,title as streventname  from tblevents where event_start between dateadd(day,-7,getdate()) AND dateadd(day,+1,getdate()) or event_end between dateadd(day,-7,getdate()) AND dateadd(day,+1,getdate())";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgThisweek.Visible = true;
            dgThisweek.DataSource = ds;
            dgThisweek.DataBind();
            lblthisweek.Visible = false;
        }
        else
        {
            dgThisweek.Visible = false;
            lblthisweek.Visible = true;
            lblthisweek.Text = "No events this week";
        }
    }

    protected void btnSyeaterday_Click(object sender, ImageClickEventArgs e)
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        DateTime dt = Convert.ToDateTime(lblsheduledate.Text, dateInfo);
        DateTime date = dt.AddDays(-1);
        lblsheduledate.Text = string.Format("{0:dd\\/MM\\/yyyy }", date);
        fillTeachingshedule();  
    }
    protected void btnStomorrow_Click(object sender, ImageClickEventArgs e)
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        DateTime dt = Convert.ToDateTime(lblsheduledate.Text, dateInfo);
        DateTime date = dt.AddDays(+1);
        lblsheduledate.Text = string.Format("{0:dd\\/MM\\/yyyy }", date);
        fillTeachingshedule();
    }

    protected void btnHyesterday_Click(object sender, ImageClickEventArgs e)
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        DateTime dt = Convert.ToDateTime(lblhomeworkdate.Text, dateInfo);
        DateTime date = dt.AddDays(-1);
        lblhomeworkdate.Text = string.Format("{0:dd\\/MM\\/yyyy }", date);
        fillhomework();
    }

    protected void btnHtommorow_Click(object sender, ImageClickEventArgs e)
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        DateTime dt = Convert.ToDateTime(lblhomeworkdate.Text, dateInfo);
        DateTime date = dt.AddDays(+1);
        lblhomeworkdate.Text = string.Format("{0:dd\\/MM\\/yyyy }", date);
        fillhomework();
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select * from tblworkingdays where intschoolid="+ Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        string day;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            day = ds.Tables[0].Rows[i]["strweekholidays"].ToString();
            DayOfWeek NewVal = (DayOfWeek)StringToEnum(typeof(DayOfWeek), day);
            if (e.Day.Date.DayOfWeek == NewVal)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                    e.Cell.BackColor = System.Drawing.Color.FromArgb(177, 177, 255);
                if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Halfday")
                    e.Cell.BackColor = System.Drawing.Color.LightSeaGreen;
            }
        }
    }
    static object StringToEnum(Type t, string Value)
    {
        foreach (FieldInfo fi in t.GetFields())
            if (fi.Name == Value)
                return fi.GetValue(null);    // We use null because
        // enumeration values
        // are static

        throw new Exception(string.Format("Can't convert {0} to {1}", Value, t.ToString()));
    }

    protected void filltimetable()
    {
        da = new DataAccess();
        str = "select * from (select strSTHH,strSTMM,strETHH,strETMM,strperiod ,''as strper,cast(replace(replace(replace(replace(substring(strperiod,1,2),'s',''),'n',''),'r',''),'t','') as int) as intorder from tblschoolperiods where intschoolid=" + Session["Schoolid"].ToString() + " and strperiod like '%Period' group by strperiod,strSTHH,strSTMM,strETHH,strETMM) as a order by intorder";

        //str = "select *,replace(strperiod,' Period','') as strper from tblschoolperiods where intschoolid=" + Session["SchoolID"].ToString();
        //str = "select *,replace(strperiod,' Period','') as strper from tblschoolperiods a,tblemployee b,tblhomeclass c where a.intschoolid=" + Session["SchoolID"].ToString() + " and b.intid=" + Session["UserID"]+" and c.strhomeclass=a.strclass" ;
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstarttimings1.Text = ds.Tables[0].Rows[0]["strSTHH"].ToString() + " : " + ds.Tables[0].Rows[0]["strSTMM"].ToString();
            dlperiods.DataSource = ds;
            dlperiods.DataBind();
        }
    }

    protected void dlperiods_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataGrid dgstudentmarks = (DataGrid)e.Item.FindControl("dgstudentmarks");
            Label lblperiod = (Label)e.Item.FindControl("lblperiod");
            Label lblteacher = (Label)e.Item.FindControl("lblteacher");
            Label lblsubject = (Label)e.Item.FindControl("lblsubject");
            DataAccess da = new DataAccess();
            DataSet ds;

            str = "select * from (";
            str = str + " select a.intid,a.strperiod,a.strsubject,b.strtittle + ' ' + ltrim(b.strfirstname) + ' ' + ltrim(b.strmiddlename) + ' ' + ltrim(b.strlastname) as strteacher,strclass from (";
            str = str + " select intid,strperiod,strsubject,strteacher,strstandard + ' - ' + strsection as strclass from tbltimetable where strteacher='" + Session["UserID"].ToString() + "' and strday='" + lbltimetabletoday.Text + "'";
            str = str + " and strsubject not like '%Language' and strsubject not like 'Extra Activities'";
            str = str + " and strsubject not like 'None' and strperiod not like '%Interval' and strperiod not like 'Lunch'";
            str = str + " union all";
            str = str + " select a.intid,a.strperiod,b.strlanguage as strsubject,b.strteacher,b.strstandard1 + ' - ' + b.strsection1 as strclass from tbltimetable a, tbltimetable2 b where a.strstandard=b.strstandard1 and ";
            str = str + " a.strsection=b.strsection1 and a.strday=b.strday and a.strperiod=b.strperiod and ";
            str = str + " b.strteacher='" + Session["UserID"].ToString() + "' and a.strday='" + lbltimetabletoday.Text + "'";
            str = str + " and a.strsubject like '%Language' and a.strsubject not like 'Extra Activities' and a.strsubject not like 'None'";
            str = str + " and a.strperiod not like '%Interval' and a.strperiod not like 'Lunch'";
            str = str + " union all";
            str = str + " select a.intid,a.strperiod,b.strlanguage as strsubject,b.strteacher,a.strstandard + ' - ' + a.strsection as strclass from tbltimetable a, tbltimetable3 b where a.strstandard=b.strstandard and ";
            str = str + " a.strsection=b.strsection and a.strday=b.strday and a.strperiod=b.strperiod and ";
            str = str + " b.strteacher='" + Session["UserID"].ToString() + "' and a.strday='" + lbltimetabletoday.Text + "'";
            str = str + " and a.strsubject not like '%Language' and a.strsubject like 'Extra Activities' and a.strsubject not like 'None'";
            str = str + " and a.strperiod not like '%Interval' and a.strperiod not like 'Lunch') as a, tblemployee b";
            str = str + " where a.strteacher=b.intid";
            str = str + " union all ";
            str = str + " select intid,strperiod,strperiod as strsubject,'' as strteacher,strstandard + ' - ' + strsection as strclass  from tbltimetable where strteacher='" + Session["UserID"].ToString() + "' and strday='" + lbltimetabletoday.Text + "'";
            str = str + " and (strperiod like '%Interval' or strperiod like 'Lunch')";
            str = str + " union all ";
            str = str + " select intid,strperiod,'Not Alloted' as strsubject,'Not Alloted' as strteacher,strstandard + ' - ' + strsection as strclass  from tbltimetable where strteacher='" + Session["UserID"].ToString() + "' and strday='" + lbltimetabletoday.Text + "'";
            str = str + " and strsubject like 'None'";
            str = str + " union all";
            str = str + " select intid,strperiod,'Not Alloted' as strsubject,'Not Alloted' as strteacher,strstandard + ' - ' + strsection as strclass from tbltimetable where strteacher='" + Session["UserID"].ToString() + "' and strday='" + lbltimetabletoday.Text + "'";
            str = str + " and strsubject like '%Language' and strsubject not like 'Extra Activities' and strsubject not like 'None' ";
            str = str + " and strperiod not like '%Interval' and strperiod not like 'Lunch'";
            str = str + " and intid not in(";
            str = str + " select a.intid from tbltimetable a, tbltimetable2 b where a.strstandard=b.strstandard1 and ";
            str = str + " a.strsection=b.strsection1 and a.strday=b.strday and a.strperiod=b.strperiod and ";
            str = str + " b.strteacher='" + Session["UserID"].ToString() + "' and a.strday='" + lbltimetabletoday.Text + "'";
            str = str + " and a.strsubject like '%Language' and a.strsubject not like 'Extra Activities' and a.strsubject not like 'None'";
            str = str + " and a.strperiod not like '%Interval' and a.strperiod not like 'Lunch'";
            str = str + " )";
            str = str + " union all";
            str = str + " select intid,strperiod,'Not Alloted' as strsubject,'Not Alloted' as strteacher,strstandard + ' - ' + strsection as strclass from tbltimetable where strteacher='" + Session["UserID"].ToString() + "' and strday='" + lbltimetabletoday.Text + "'";
            str = str + " and strsubject not like '%Language' and strsubject like 'Extra Activities' and strsubject not like 'None' ";
            str = str + " and strperiod not like '%Interval' and strperiod not like 'Lunch'";
            str = str + " and intid not in(";
            str = str + " select a.intid from tbltimetable a, tbltimetable3 b where a.strstandard=b.strstandard and ";
            str = str + " a.strsection=b.strsection and a.strday=b.strday and a.strperiod=b.strperiod and ";
            str = str + " b.strteacher='" + Session["UserID"].ToString() + "' and a.strday='" + lbltimetabletoday.Text + "'";
            str = str + " and a.strsubject not like '%Language' and a.strsubject like 'Extra Activities' and a.strsubject not like 'None'";
            str = str + " and a.strperiod not like '%Interval' and a.strperiod not like 'Lunch'";
            str = str + " )";
            str = str + " ) as a1 where strperiod='" + lblperiod.Text + "' order by intid";

            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblteacher.Text = ds.Tables[0].Rows[0]["strclass"].ToString();
                lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
            }
            else
            {
                lblteacher.Text = "Leisure";
                lblsubject.Text = "";
            }
        }
        catch { }
    }

    protected void btntimetableyesterday_Click(object sender, ImageClickEventArgs e)
    {
        lbltimetabledate.Text = DateTime.Parse(lbltimetabledate.Text).AddDays(-1).Date.ToString();
        lbltimetabletoday.Text = DateTime.Parse(lbltimetabledate.Text).DayOfWeek.ToString();
        lbltimetable2marrow.Text = DateTime.Parse(lbltimetabledate.Text).AddDays(1).DayOfWeek.ToString();
        lbltimetableyesterday.Text = DateTime.Parse(lbltimetabledate.Text).AddDays(-1).DayOfWeek.ToString();
        filltimetable();
    }

    protected void btntimetable2marrow_Click(object sender, ImageClickEventArgs e)
    {
        lbltimetabledate.Text = DateTime.Parse(lbltimetabledate.Text).AddDays(1).Date.ToString();
        lbltimetabletoday.Text = DateTime.Parse(lbltimetabledate.Text).DayOfWeek.ToString();
        lbltimetable2marrow.Text = DateTime.Parse(lbltimetabledate.Text).AddDays(1).DayOfWeek.ToString();
        lbltimetableyesterday.Text = DateTime.Parse(lbltimetabledate.Text).AddDays(-1).DayOfWeek.ToString();
        filltimetable();
    }
}
