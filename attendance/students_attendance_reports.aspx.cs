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
using System.IO;
using System.Globalization;
using System.Collections.ObjectModel;
using Highchart.Core.Data.Chart;
using Highchart.Core;

public partial class detailsrecord_studentattendance_report : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlstudent.Items.Insert(0, "Select");
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            string str = "select convert(varchar(10),getdate(),111) as date";
            ds1 = da1.ExceuteSql(str);
            txtdate.Text=ds1.Tables[0].Rows[0][0].ToString();
            //txtdate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            lbldate.Text = DateTime.Now.ToShortDateString();
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
            {
                trsidemenu.Visible = false;
                
                da = new DataAccess();
                strsql = "select strstandard + ' - ' + strsection as strclass from tblstudent where intid=" + Session["UserID"].ToString();
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
                fillstudent();
                fillhometeacher();
                lblstandard.Text = ddlstandard.SelectedItem.Text;
                holidays();
                fillgrd();
                //fillgrd2();
                tr1.Visible = true;
                tr2.Visible = true;
                tr3.Visible = true;
                ddlstudent.SelectedValue = Session["UserID"].ToString();
                fillgrd3();
                Label22.Visible = false;
                Label1.Visible = false;
                ddlstudent.Visible = false;
                ddlstandard.Visible = false;
            }
        }
        Exemplo01();
        //txtdate.Attributes.Add("OnTextChanged","javascript:return Validation()");
    }

    protected void fillgrd()
    {
        if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || ddlstudent.SelectedIndex > 0)
        {
            int year = DateTime.Parse(txtdate.Text).Year;
            int month = DateTime.Parse(txtdate.Text).Month;
            int noofdays = DateTime.DaysInMonth(year, month);
            string mm;
            mm = DateTime.Parse(txtdate.Text).Month.ToString();
            if (DateTime.Parse(txtdate.Text).Month < 10)
                mm = "0" + mm;

            string startdate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + mm + "/01";
            string enddate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + mm + "/" + noofdays.ToString();
            DataSet ds;
            DataAccess da = new DataAccess();
            da = new DataAccess();
            string str = "";
            double wh = 0;
            double wh1 = 0;
            str = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
            ds = da.ExceuteSql(str);


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                    wh = wh + getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate), DateTime.Parse(enddate));
                else
                    wh = wh + (getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate), DateTime.Parse(enddate)) * .5);

            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                    wh1 = wh1 + getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate), DateTime.Parse(txtdate.Text));
                else
                    wh1 = wh1 + (getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate), DateTime.Parse(txtdate.Text)) * .5);

            }
            str = "";
            str = "select 'Total  No Of Days Student Present' as strtext,Atten.ct-Abs.ct as ct from ( ( select 'Total No Of Students Absent' as strtext, count(*) as ct from tblstudentattendance where strclass='" + ddlstandard.SelectedValue + "' and dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intstudent='" + Session["UserID"].ToString() + "' ) ) as Abs ,(select 'Attendance Taken' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, (select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=1 and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ) as Atten";
            str = str + " union all ";
            str = str + "select 'Total No Of Days Student Absent' as strtext, count(*) as ct from tblstudentattendance where strclass='" + ddlstandard.SelectedValue + "' and dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intstudent='" + Session["UserID"].ToString() + "'";
            str = str + " union all ";
            str = str + "select 'Total Working Days' as desc1, noofdays-(holidays+" + wh.ToString() + ") as ct from (select datepart(dd,dateadd(dd,-1,dateadd(mm,1,cast(cast(year('" + txtdate.Text + "') as varchar)+'-'+cast(month('" + txtdate.Text + "') as varchar)+'-01' as datetime)))) as noofdays) as a, ";
            str = str + "(select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + enddate + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            str = str + " union all ";
            str = str + "select 'Attendance Taken' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, ";
            str = str + "(select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            str = str + " union all ";
            //str = str + "SELECT 'Total  No Of Days' as strtext, DATEPART (day, DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE())+1,0))) as Days";
            //str = str + "SELECT 'Total  No Of Days' as strtext, Day(DateAdd(day, -Day(DateAdd(month, 1, getdate())),DateAdd(month, 1, getdate()))) as Days";
            str = str + "select 'Total No Of Days' as strtext, " + noofdays + " as Days";
            ds = da.ExceuteSql(str);
            dgattendance.DataSource = ds;
            dgattendance.DataBind();
        }
        else
        {
            int year = DateTime.Parse(txtdate.Text).Year;
            int month = DateTime.Parse(txtdate.Text).Month;
            int noofdays = DateTime.DaysInMonth(year, month);
            string mm;
            mm = DateTime.Parse(txtdate.Text).Month.ToString();
            if (DateTime.Parse(txtdate.Text).Month < 10)
                mm = "0" + mm;

            //string startdate = mm + "/01/" + DateTime.Parse(txtdate.Text).Year.ToString();
            //string enddate = mm + "/" + noofdays.ToString() + "/" + DateTime.Parse(txtdate.Text).Year.ToString();
            string startdate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + mm + "/01";
            string enddate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + mm + "/" + noofdays.ToString();
            DataSet ds;
            DataAccess da = new DataAccess();
            da = new DataAccess();
            string str = "";
            double wh = 0;
            double wh1 = 0;
            str = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
            ds = da.ExceuteSql(str);

            getnoofweekholidays("Saturday", DateTime.Parse("2013/07/01"), DateTime.Parse("2013/07/31"));
            DateTime dt = DateTime.Today;
            Console.WriteLine(dt.ToLongDateString().IndexOf("Saturday"));

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                    wh = wh + getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(enddate, CultureInfo.InvariantCulture));
                else
                    wh = wh + (getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(enddate, CultureInfo.InvariantCulture)) * .5);

            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                    wh1 = wh1 + getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(txtdate.Text, CultureInfo.InvariantCulture));
                else
                    wh1 = wh1 + (getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(txtdate.Text, CultureInfo.InvariantCulture)) * .5);

            }

            str = "";
            str = "select 'Total  No Of Students' as strtext,count(*) as ct from tblstudent where strstandard+' - ' + strsection='" + ddlstandard.SelectedValue + "' ";
            str = str + "union all ";
            str = str + "select 'Total  No Of Students Present' as strtext,a.ct-b.ct as ct from(select count(*) as ct from tblstudent where strstandard+' - ' + strsection='" + ddlstandard.SelectedValue + "' ) as a, (select count(*) as ct from tblstudentattendance where strclass='" + ddlstandard.SelectedValue + "' and dtdate='" + txtdate.Text + "') as b ";
            str = str + "union all ";
            str = str + "select 'Total No Of Students Absent' as strtext, count(*) as ct from tblstudentattendance where strclass='" + ddlstandard.SelectedValue + "' and dtdate='" + txtdate.Text + "' ";
            str = str + "union all ";
            str = str + "select 'Total Working Days' as desc1, noofdays-(holidays+" + wh.ToString() + ") as ct from (select datepart(dd,dateadd(dd,-1,dateadd(mm,1,cast(cast(year('" + txtdate.Text + "') as varchar)+'-'+cast(month('" + txtdate.Text + "') as varchar)+'-01' as datetime)))) as noofdays) as a, ";
            str = str + "(select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + enddate + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            str = str + "union all ";
            str = str + "select 'Attendance Taken' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, ";
            str = str + "(select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            ds = da.ExceuteSql(str);
            dgattendance.DataSource = ds;
            dgattendance.DataBind();
        }
    }

    private void getnoofweekholidays(string p, string p_2, string p_3)
    {
        throw new NotImplementedException();
    }

    protected double getnoofweekholidays(string strday, DateTime sdt, DateTime edt)
    {
        double wh = 0;
        for (DateTime dt = sdt; dt <= edt; dt = dt.AddDays(1))
        {
            if (dt.ToLongDateString().IndexOf(strday) > -1)
                wh = wh + 1;
        }
        return wh;
    }

    protected void fillgrd2()
    {
        string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
        lblmonthandyear.Text = "Month & Year : " + CurrentMonth + " - " + DateTime.Now.Year.ToString();

        DataSet ds2 = new DataSet();
        DataAccess da2 = new DataAccess();
        int noofdays = 0;
        string str2 = "select year('" + txtdate.Text + "') as years,month('" + txtdate.Text + "') as months";
        ds2 = da2.ExceuteSql(str2);
        int year =int.Parse( ds2.Tables[0].Rows[0]["years"].ToString());
        int month = int.Parse(ds2.Tables[0].Rows[0]["months"].ToString());
        int mon =int.Parse(DateTime.Now.Month.ToString());
        int yea =int.Parse(DateTime.Now.Year.ToString());
        if ((month == mon) && (year == yea))
        {
            noofdays = DateTime.Today.Day;
        }
        else
        {
            noofdays = DateTime.DaysInMonth(year, month);
        }

        //string startdate = DateTime.Parse(txtdate.Text).Month.ToString() + "/01/" + DateTime.Parse(txtdate.Text).Year.ToString();
        //string enddate = DateTime.Parse(txtdate.Text).Month.ToString() + "/" + noofdays.ToString() + "/" + DateTime.Parse(txtdate.Text).Year.ToString();
        string startdate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/01";
        string enddate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/" + noofdays.ToString();
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        string str = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
        ds = da.ExceuteSql(str);
        double wh1 = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                wh1 = wh1 + getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(txtdate.Text, CultureInfo.InvariantCulture));
            else
                wh1 = wh1 + (getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(txtdate.Text, CultureInfo.InvariantCulture)) * .5);

        }

        double nod = double.Parse(noofdays.ToString()) - wh1;

        ds = new DataSet();
        da = new DataAccess();
        str = "select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + enddate + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
        ds = da.ExceuteSql(str);
        nod = nod - double.Parse(ds.Tables[0].Rows[0]["holidays"].ToString());

        ds = new DataSet();
        da = new DataAccess();
        str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as studentname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
        str += " 'P' as c7,'P' as c8,'P' as c9,";
        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
        str += " cast(" + nod.ToString() + " as numeric(15,2)) as present, 0.00 as absent, 0.00 as percentage from tblstudent where";
        str += " intschool='" + Session["schoolID"].ToString() + "' and strstandard + ' - ' + strsection='" + ddlstandard.SelectedValue + "'";
        ds = da.ExceuteSql(str);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataSet ds1 = new DataSet();
            DataAccess da1 = new DataAccess();
            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
            sql += " intstudent=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
            sql += " strclass='" + ddlstandard.SelectedValue + "' and month(dtdate)=" + month + " and";
            sql += " year(dtdate)=" + year + "";
            ds1 = da1.ExceuteSql(sql);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows[i]["percentage"] = 100.00;
            }
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                {
                    int k = int.Parse(ds1.Tables[0].Rows[j]["days"].ToString().Replace("c", ""));
                    ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "A";
                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 1;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 1;
                }
                else
                {
                    if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Morning")
                        ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "M/A";
                    else
                        ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "A/A";


                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 0.5;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 0.5;
                }
                double p = double.Parse(ds.Tables[0].Rows[i]["present"].ToString());
                double percentage = ((p / nod) * 100);
                double b = double.Parse(String.Format("{0:0.##}", percentage));
                ds.Tables[0].Rows[i]["percentage"] = b;
            }

            ds1 = new DataSet();
            da1 = new DataAccess();
            sql = "select 'c'+ltrim(str(day(dtdate))) as days from tblacademiccalender where ";
            sql += " intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
            sql += " and month(dtdate)=" + month + " and year(dtdate)=" + year + "";
            ds1 = da1.ExceuteSql(sql);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "F";
            }

            ds1 = new DataSet();
            da1 = new DataAccess();
            sql = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
            ds1 = da1.ExceuteSql(sql);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                for (DateTime dt = DateTime.Parse(startdate, CultureInfo.InvariantCulture); dt <= DateTime.Parse(enddate, CultureInfo.InvariantCulture); dt = dt.AddDays(1))
                {
                    if (dt.ToLongDateString().IndexOf(ds1.Tables[0].Rows[j]["strweekholidays"].ToString()) > -1)
                    {
                        string c = "c" + dt.Day.ToString();
                        if (ds1.Tables[0].Rows[j]["strmode"].ToString() == "Holiday")
                            ds.Tables[0].Rows[i]["c" + dt.Day.ToString()] = "H";
                        else
                            ds.Tables[0].Rows[i]["c" + dt.Day.ToString()] = "HH";
                    }
                }
            }
        }

        for (int i = 1; i <= 31; i++)
        {
            dgattendancedetail.Columns[i].Visible = true;
        }
        for (int i = noofdays + 1; i <= 31; i++) 
        {
                dgattendancedetail.Columns[i].Visible = false;
        }
        dgattendancedetail.DataSource = ds;
        if (ddlstudent.SelectedIndex <= 0)
        {
            dgattendancedetail.Columns[0].HeaderText = "Name";
        }
        else
        {
            dgattendancedetail.Columns[0].HeaderText = "Month";
        }
        dgattendancedetail.DataBind();

    }

    private void Exemplo01()
    {
        try
        {
            DataSet ds2 = new DataSet();
            DataAccess da2 = new DataAccess();
            int noofdays = 0;
            string str2 = "select datename(month,'" + txtdate.Text + "') as monthname,year('" + txtdate.Text + "') as years,month('" + txtdate.Text + "') as months";
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

            string[] myStringArray;
            myStringArray = new string[noofdays];
            object[] abc;
            abc = new object[noofdays];
            for (int i = 1; i <= noofdays; i++)
            {
                myStringArray[i - 1] = i.ToString();
                abc[i - 1] = noofdays;
            }

            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
                {
                    if (ddlstandard.SelectedIndex > 0)
                    {
                        DataSet ds = new DataSet();
                        DataAccess da = new DataAccess();
                        string str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as studentname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
                        str += " 'P' as c7,'P' as c8,'P' as c9,";
                        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
                        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
                        str += " " + noofdays.ToString() + ".00 as present, 0.00 as absent, 0.00 as percentage from tblstudent where";
                        str += " intschool='" + Session["schoolID"].ToString() + "' and strstandard + ' - ' + strsection='" + ddlstandard.SelectedValue + "' and intid='"+Session["Userid"].ToString()+"'";
                        ds = da.ExceuteSql(str);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataSet ds1 = new DataSet();
                            DataAccess da1 = new DataAccess();
                            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
                            sql += " intstudent=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                            sql += " strclass='" + ddlstandard.SelectedValue + "' and month(dtdate)=" + month + " and";
                            sql += " year(dtdate)=" + year + "";
                            ds1 = da1.ExceuteSql(sql);
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                                {
                                    try
                                    {
                                        int k = int.Parse(ds1.Tables[0].Rows[j]["days"].ToString().Replace("c", ""));
                                        abc[k - 1] = int.Parse(abc[k - 1].ToString()) - 1;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ddlstandard.SelectedIndex > 0)
                    {
                        DataSet ds = new DataSet();
                        DataAccess da = new DataAccess();
                        string str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as studentname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
                        str += " 'P' as c7,'P' as c8,'P' as c9,";
                        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
                        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
                        str += " " + noofdays.ToString() + ".00 as present, 0.00 as absent, 0.00 as percentage from tblstudent where";
                        str += " intschool='" + Session["schoolID"].ToString() + "' and strstandard + ' - ' + strsection='" + ddlstandard.SelectedValue + "'";
                        ds = da.ExceuteSql(str);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataSet ds1 = new DataSet();
                        DataAccess da1 = new DataAccess();
                        string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
                        sql += " intstudent=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                        sql += " strclass='" + ddlstandard.SelectedValue + "' and month(dtdate)=" + month + " and";
                        sql += " year(dtdate)=" + year + "";
                        ds1 = da1.ExceuteSql(sql);
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                            {
                                try
                                {
                                    int k = int.Parse(ds1.Tables[0].Rows[j]["days"].ToString().Replace("c", ""));
                                    abc[k - 1] = int.Parse(abc[k - 1].ToString()) - 1;
                                }
                                catch { }
                            }
                        }
                    }
                }
            }

            hcVendas.YAxis = new YAxis { title = new Title(ds2.Tables[0].Rows[0]["monthname"].ToString() + " - " + year.ToString() + " - Noofdays") };
            hcVendas.XAxis = new XAxis { categories = myStringArray };
            var series = new Collection<Serie>();
            series.Add(new Serie { name = "Day", color = "#67F835", data = abc });
            //series.Add(new Serie { name = "Year", color = "#FE438E", data = abc });
            hcVendas.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#dedede", borderRadius = 4 };
            hcVendas.Theme = Highchart.Core.Appearance.ThemeName.darkblue;
            hcVendas.DataSource = series;
            hcVendas.DataBind();
        }
        catch { }
    }

    protected void fillstandard()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strstandard + ' - ' + strsection as strclass from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strstandard,strsection";
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataBind();
        ListItem list = new ListItem("-Select-", "0");
        ddlstandard.Items.Insert(0,list);        
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        ddlstudent.SelectedIndex = 0;
        fillhometeacher();
        lblstandard.Text = ddlstandard.SelectedItem.Text;
        holidays();
        fillgrd();
        fillgrd2();
        tr1.Visible = true;
        tr2.Visible = true;
        tr3.Visible = true;
        Exemplo01();
    }

    protected void fillstudent()
    {
        ddlstudent.Items.Clear();
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select intid,strfirstname + ' ' + strmiddlename + ' ' + strlastname as studentname from tblstudent where strstandard + ' - ' + strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "studentname";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ListItem list = new ListItem("All", "0");
        ddlstudent.Items.Insert(0, list);
    }

    protected void fillhometeacher()
    {
        DataAccess da=new DataAccess();
        string str;
        DataSet ds;
        if (ddlstandard.SelectedIndex > 0)
        {
            lblstandard.Text = "";
            lblsection.Text = "";
            lblhometeacher.Text = "";
            lbldate.Text = "";

            str = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername from tblemployee a,tblhomeclass b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.intemployee and b.strhomeclass='" + ddlstandard.SelectedValue + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
                lblhometeacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
            else
                lblhometeacher.Text = "Home Teacher Not Assigned";
             lblstandard.Text = ddlstandard.SelectedItem.Text;     
             lbldate.Text = txtdate.Text.Trim();
        }
    }

    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
        {
            da = new DataAccess();
            strsql = "select strstandard + ' - ' + strsection as strclass from tblstudent where intid=" + Session["UserID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
            fillstudent();
            fillhometeacher();
            lblstandard.Text = ddlstandard.SelectedItem.Text;
            holidays();
            fillgrd();
            //fillgrd2();
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            ddlstudent.SelectedValue = Session["UserID"].ToString();
            fillgrd3();
            Label22.Visible = false;
            Label1.Visible = false;
            ddlstudent.Visible = false;
            ddlstandard.Visible = false;
        }
        else
        {
            lbldate.Text = "";
            lbldate.Text = txtdate.Text.Trim();
            holidays();
            fillgrd();
            ddlstudent.SelectedIndex = 0;
            fillgrd2();
            DateTime dt = DateTime.Parse(txtdate.Text.Trim(), CultureInfo.GetCultureInfo("en-US"));
            string month1 = dt.ToString("MMMM", CultureInfo.GetCultureInfo("en-US"));
            //string month2 = DateTimeFormatInfo.GetInstance(CultureInfo.GetCultureInfo("en-US")).MonthNames[dt.Month - 1];
            int year = DateTime.ParseExact(txtdate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture).Year;
            lblmonthandyear.Text = month1 + " - " + year;
        }
    }

    protected void holidays()
    {
        DataAccess da = new DataAccess();
        DataSet ds=new DataSet();
        string str="select strweekholidays from dbo.tblworkingdays where intschoolid=" +Session["schoolID"].ToString() + " and strmode='Holiday'";
        ds=da.ExceuteSql(str);
        int holidayc = 0;
        string holiday = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            holiday = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
            DayOfWeek illegal = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holiday);
            PrintSundays(2011, 10, illegal);
        }
        holidayc = int.Parse(lblsunday.Text);

        string holidayhalf = "";
        int totalcount = 0;
        int halfdayc = 0;
        int total = 0;
        string str1="select strweekholidays from dbo.tblworkingdays where intschoolid=" +Session["schoolID"].ToString() + " and strmode='Halfday'";
        ds=da.ExceuteSql(str1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            holidayhalf = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
            DayOfWeek illegalhalf = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayhalf);
            PrintSundays(2011, 10, illegalhalf);
        }
        totalcount = int.Parse(lblsunday.Text);
        halfdayc = totalcount / 2;
        total = holidayc + halfdayc;

        int a = 0;
        int days = 0;
        int finalcount = 0;
        string str2 = "select year('" + txtdate.Text.Trim() + "') as years";
        ds=da.ExceuteSql(str2);
        try
        {
            a = int.Parse(ds.Tables[0].Rows[0]["years"].ToString());
            days = DateTime.DaysInMonth(a, 1);
            finalcount = days - total;
        }
        catch { }

        string str3 = "select * from tempholidaycount where dtdate='"+txtdate.Text+"'";
        ds = da.ExceuteSql(str3);
        if (ds.Tables[0].Rows.Count == 0)
        {
            SqlCommand command;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("sptempholidaycount", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@intid", "0");
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.Parameters.Add("@dtdate", txtdate.Text.Trim());
            command.Parameters.Add("@intmonthdays", days);
            command.Parameters.Add("@intholidays", total);
            command.Parameters.Add("@intworkingdays", finalcount);
            command.ExecuteNonQuery();
            conn.Close();
        }        
    }    

    protected void PrintSundays(int year, int month, DayOfWeek dayName)
    {
        year = DateTime.Parse(txtdate.Text).Year;
        month = DateTime.Parse(txtdate.Text).Month;
        int count = 0;
        CultureInfo ci = new CultureInfo("en-US");
        for (int i = 1; i <= ci.Calendar.GetDaysInMonth(year, month); i++)
        {
            if (new DateTime(year, month, i).DayOfWeek == dayName)
            {
                if (count == 0)
                {
                    Session["count"] = 1;
                    count = 1;
                }
                else
                    count = count + 1;
            }
            lblsunday.Text=count.ToString();
        }
    }

    protected void fillgrd3()
    {
        string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
        lblmonthandyear.Text = ddlstudent.SelectedItem.Text + " - " + DateTime.Now.Year.ToString();

        DataSet ds2 = new DataSet();
        DataAccess da2 = new DataAccess();
        int noofdays = 0;
        string str2 = "select year('" + txtdate.Text + "') as years,month('" + txtdate.Text + "') as months";
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

        string startdate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/01";
        string enddate = DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/" + noofdays.ToString();
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        string str = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
        ds = da.ExceuteSql(str);
        double wh1 = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["strmode"].ToString() == "Holiday")
                wh1 = wh1 + getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(txtdate.Text, CultureInfo.InvariantCulture));
            else
                wh1 = wh1 + (getnoofweekholidays(ds.Tables[0].Rows[i]["strweekholidays"].ToString(), DateTime.Parse(startdate, CultureInfo.InvariantCulture), DateTime.Parse(txtdate.Text, CultureInfo.InvariantCulture)) * .5);

        }

        double nod = double.Parse(noofdays.ToString()) - wh1;

        ds = new DataSet();
        da = new DataAccess();
        str = "select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + enddate + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
        ds = da.ExceuteSql(str);
        nod = nod - double.Parse(ds.Tables[0].Rows[0]["holidays"].ToString());

        ds = new DataSet();
        da = new DataAccess();
        str = " select intid,datename(month,'" + txtdate.Text + "') as studentname, 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
        str += " 'P' as c7,'P' as c8,'P' as c9,";
        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
        str += " cast(" + nod.ToString() + " as numeric(15,2)) as present, 0.00 as absent, 0.00 as percentage from tblstudent where";
        str += " intschool='" + Session["schoolID"].ToString() + "' and intid=" + ddlstudent.SelectedValue;
        ds = da.ExceuteSql(str);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataSet ds1 = new DataSet();
            DataAccess da1 = new DataAccess();
            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
            sql += " intstudent=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
            sql += " strclass='" + ddlstandard.SelectedValue + "' and month(dtdate)=" + month + " and";
            sql += " year(dtdate)=" + year + "";
            ds1 = da1.ExceuteSql(sql);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows[i]["percentage"] = 100;
            }
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                {
                    int k = int.Parse(ds1.Tables[0].Rows[j]["days"].ToString().Replace("c", ""));
                    //abc[k - 1] = int.Parse(abc[k - 1].ToString()) - 1;
                    ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "A";
                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 1;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 1;
                }
                else
                {
                    if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Morning")
                        ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "M/A";
                    else
                        ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "A/A";
                    //ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "H";
                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 0.5;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 0.5;
                }
                double p = double.Parse(ds.Tables[0].Rows[i]["present"].ToString());
                double percentage = ((p / nod) * 100);
                double b = double.Parse(String.Format("{0:0.##}", percentage));
                ds.Tables[0].Rows[i]["percentage"] = b;
            }
            ds1 = new DataSet();
            da1 = new DataAccess();
            sql = "select 'c'+ltrim(str(day(dtdate))) as days from tblacademiccalender where ";
            sql += " intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
            sql += " and month(dtdate)=" + month + " and year(dtdate)=" + year + "";
            ds1 = da1.ExceuteSql(sql);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "F";
            }

            ds1 = new DataSet();
            da1 = new DataAccess();
            sql = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
            ds1 = da1.ExceuteSql(sql);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                for (DateTime dt = DateTime.Parse(startdate, CultureInfo.InvariantCulture); dt <= DateTime.Parse(enddate, CultureInfo.InvariantCulture); dt = dt.AddDays(1))
                {
                    if (dt.ToLongDateString().IndexOf(ds1.Tables[0].Rows[j]["strweekholidays"].ToString()) > -1)
                    {
                        string c = "c" + dt.Day.ToString();
                        if (ds1.Tables[0].Rows[j]["strmode"].ToString() == "Holiday")
                            ds.Tables[0].Rows[i]["c" + dt.Day.ToString()] = "H";
                        else
                            ds.Tables[0].Rows[i]["c" + dt.Day.ToString()] = "HH";
                    }
                }
            }
        }

        for (int i = 1; i <= 31; i++)
        {
            dgattendancedetail.Columns[i].Visible = true;
        }
        for (int i = noofdays + 1; i <= 31; i++)
        {
            dgattendancedetail.Columns[i].Visible = false;
        }
        dgattendancedetail.DataSource = ds;
        if (ddlstudent.SelectedIndex <= 0)
        {
            dgattendancedetail.Columns[0].HeaderText = "Name";
        }
        else
        {
            dgattendancedetail.Columns[0].HeaderText = "Month";
        }
        dgattendancedetail.DataBind();

    }

    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstudent.SelectedIndex > 0)
        {
            fillgrd();
            fillgrd3();
        }
        else
        {
            fillgrd();
            fillgrd2();
        }
    }
}
