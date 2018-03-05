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

public partial class attendance_staffattendance_report : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstafftype();
            ddlstaffname.Items.Insert(0, "Select");
            txtdate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            lbldate.Text = DateTime.Now.ToShortDateString();
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            //string a;
            //a = Session["Patrontype"].ToString();

            if (Session["Strtype"] == "Teaching Staffs")
            {
                try
                {
                    trsidemenu.Visible = false;

                    da = new DataAccess();
                    strsql = "select strstandard + ' - ' + strsection as strclass from tblstudent where intid=" + Session["UserID"].ToString();
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    ddlstafftype.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
                    fillstaffname();
                    lblstafftype.Text = ddlstafftype.SelectedItem.Text;
                    holidays();
                    fillgrd();
                    //fillgrd2();
                    tr1.Visible = true;
                    tr2.Visible = true;
                    tr3.Visible = true;
                    ddlstaffname.SelectedValue = Session["UserID"].ToString();
                    fillgrd3();
                    Label22.Visible = false;
                    Label1.Visible = false;
                    ddlstaffname.Visible = false;
                    ddlstafftype.Visible = false;
                }
                catch { }
            }
        }
        Exemplo01();
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
        ListItem list = new ListItem("All", "All");
        ddlstafftype.Items.Insert(0, list);
    }

    protected void fillstaffname()
    {
        ddlstaffname.Items.Clear();
        da = new DataAccess();
        ds = new DataSet();
        strsql = " select intid, strfirstname + ' ' + strmiddlename + ' ' + strlastname as name from tblemployee where strtype='" + ddlstafftype.SelectedValue + "'  and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        ddlstaffname.Items.Clear();
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "name";
        ddlstaffname.DataValueField = "intid";
        ddlstaffname.DataBind();
        ddlstaffname.Items.Insert(0, "All");

    }
    protected void fillgrd()
    {
        if (Session["PatronType"] == "Teaching Staffs" || ddlstaffname.SelectedIndex > 0)
        {
            int year = DateTime.Parse(DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/" + DateTime.Parse(txtdate.Text).Day.ToString()).Year;
            int month = DateTime.Parse(DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/" + DateTime.Parse(txtdate.Text).Day.ToString()).Month;
            int noofdays = DateTime.DaysInMonth(year, month);
            string mm;
            mm = DateTime.Parse(txtdate.Text).Month.ToString();
            if (DateTime.Parse(txtdate.Text).Month < 10)
                mm = "0" + mm;

            string startdate = mm + "/01/" + DateTime.Parse(txtdate.Text).Year.ToString();
            string enddate = mm + "/" + noofdays.ToString() + "/" + DateTime.Parse(txtdate.Text).Year.ToString();

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
            str = "select 'Total  No Of Days Staff Present' as strtext,Atten.ct-Abs.ct as ct from(( select 'Total No Of Staffs Absent' as strtext, count(*) as ct from tblstaffattendance where strtype='" + ddlstafftype.SelectedValue + "' and dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intstaff='" + Session["UserID"].ToString() + "' ) ) as Abs ,(select 'Attendance Taken' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, (select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=1 and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ) as Atten";
            str = str + " union all ";
            str = str + " select 'Total No Of Days Staffs Absent' as strtext, count(*) as ct from tblstaffattendance where strtype='" + ddlstafftype.SelectedValue + "' and dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intstaff='" + Session["UserID"].ToString() + "'";
            str = str + " union all ";
            str = str + " select 'Total Working Days' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, ";
            str = str + " (select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            str = str + " union all ";
            str = str + " select 'Attendance Taken' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, ";
            str = str + " (select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            str = str + " union all";
            str = str + " select 'Total No Of Days' as strtext, " + noofdays + " as Days";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            dgattendance.DataSource = ds;
            dgattendance.DataBind();
        }
        else
        {
            int year = DateTime.Parse(DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/" + DateTime.Parse(txtdate.Text).Day.ToString()).Year;
            int month = DateTime.Parse(DateTime.Parse(txtdate.Text).Year.ToString() + "/" + DateTime.Parse(txtdate.Text).Month.ToString() + "/" + DateTime.Parse(txtdate.Text).Day.ToString()).Month;
            int noofdays = DateTime.DaysInMonth(year, month);
            string mm;
            mm = DateTime.Parse(txtdate.Text).Month.ToString();
            if (DateTime.Parse(txtdate.Text).Month < 10)
                mm = "0" + mm;

            string startdate = mm + "/01/" + DateTime.Parse(txtdate.Text).Year.ToString();
            string enddate = mm + "/" + noofdays.ToString() + "/" + DateTime.Parse(txtdate.Text).Year.ToString();

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

            str = "select 'Total No Of Staffs Present' as strtext, a.ct-b.ct as ct from ";
            str = str + " (select count(*) as ct from tblemployee where strtype='" + ddlstafftype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") as a, ";
            str = str + " (select count(*) as ct from tblstaffattendance where strtype='" + ddlstafftype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and dtdate='" + txtdate.Text + "') as b ";
            str = str + " union all ";
            str = str + " select 'Total No Of Staffs Absent' as desc1,count(*) as ct from tblstaffattendance where strtype='" + ddlstafftype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and dtdate='" + txtdate.Text + "' ";
            str = str + " union all ";
            str = str + " select 'Total Working Days' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, ";
            str = str + " (select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            str = str + " union all ";
            str = str + " select 'Attendance Taken' as desc1, noofdays-(holidays+" + wh1.ToString() + ") as ct from (select DATEDIFF(d,'" + DateTime.Parse(txtdate.Text).Month.ToString() + "/1/" + DateTime.Parse(txtdate.Text).Year.ToString() + "','" + txtdate.Text + "')+1 as noofdays) as a, ";
            str = str + " (select count(*) as holidays from tblacademiccalender where dtdate>='" + startdate + "' and dtdate<='" + txtdate.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b ";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            dgattendance.DataSource = ds;
            dgattendance.DataBind();
        }
       
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
            if (Session["PatronType"] == "Teaching Staffs")
            {
                string str = "";
                DataSet ds = new DataSet();
                DataAccess da = new DataAccess();
                str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as staffname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
                str += " 'P' as c7,'P' as c8,'P' as c9,";
                str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
                str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
                str += " " + noofdays.ToString() + ".00 as present, 0.00 as absent, 0.00 as percentage from tblemployee where";
                str += " intschool=" + Session["schoolID"].ToString() + " and strtype='" + ddlstafftype.SelectedValue + "' and intstaff='"+Session["Userid"].ToString()+"'";
                ds = da.ExceuteSql(str);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds1 = new DataSet();
                    DataAccess da1 = new DataAccess();
                    string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstaffattendance where";
                    sql += " intstaff=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                    sql += " strtype='" + ddlstafftype.SelectedValue + "' and month(dtdate)=" + month + " and";
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
            else
            {
                string str = "";
                DataSet ds = new DataSet();
                DataAccess da = new DataAccess();
                str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as staffname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
                str += " 'P' as c7,'P' as c8,'P' as c9,";
                str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
                str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
                str += " " + noofdays.ToString() + ".00 as present, 0.00 as absent, 0.00 as percentage from tblemployee where";
                str += " intschool=" + Session["schoolID"].ToString() + " and strtype='" + ddlstafftype.SelectedValue + "'";
                ds = da.ExceuteSql(str);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds1 = new DataSet();
                    DataAccess da1 = new DataAccess();
                    string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstaffattendance where";
                    sql += " intstaff=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                    sql += " strtype='" + ddlstafftype.SelectedValue + "' and month(dtdate)=" + month + " and";
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
    protected void fillgrd2()
    {
        string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
        lblmonthandyear.Text = "Month & Year : " + CurrentMonth + " - " + DateTime.Now.Year.ToString();

        DataSet ds2 = new DataSet();
        DataAccess da2 = new DataAccess();
        int noofdays = 0;
        string str = "";
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

        string startdate = DateTime.Parse(txtdate.Text).Month.ToString() + "/01/" + DateTime.Parse(txtdate.Text).Year.ToString();
        string enddate = DateTime.Parse(txtdate.Text).Month.ToString() + "/" + noofdays.ToString() + "/" + DateTime.Parse(txtdate.Text).Year.ToString();
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
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
        str = "select intid,strfirstname+''+strmiddlename+' '+strlastname as staffname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
        str += " 'P' as c7,'P' as c8,'P' as c9,";
        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
        str += " cast(" + nod.ToString() + " as numeric(15,2)) as present, 0.00 as absent, 0.00 as percentage from tblemployee where";
        str += " intschool='" + Session["schoolID"].ToString() + "' and strtype='" + ddlstafftype.SelectedValue + "'";
        //if (ddlstafftype.SelectedIndex > 0)
        //    str += " and strtype='" + ddlstafftype.SelectedValue + "'";

        ds = da.ExceuteSql(str);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataSet ds1 = new DataSet();
            DataAccess da1 = new DataAccess();
            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstaffattendance where";
            sql += " intstaff=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
            sql += " strtype='" + ddlstafftype.SelectedValue + "' and month(dtdate)=" + month + " and";
            sql += " year(dtdate)=" + year + "";
            //if(ddlstafftype.SelectedIndex>0)
            //sql += " and strtype='" + ddlstafftype.SelectedValue + "'";
            ds1 = da1.ExceuteSql(sql);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows[i]["percentage"] = "100.00";
            }
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                {
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
        if(ddlstaffname.SelectedIndex <= 0)
        {
            dgattendancedetail.Columns[0].HeaderText = "Name";
        }
        else
        {
            dgattendancedetail.Columns[0].HeaderText = "Month";
        }
        dgattendancedetail.DataBind();
    }
    protected void fillgrd3()
    {
        string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
        lblmonthandyear.Text = ddlstaffname.SelectedItem.Text + " - " + DateTime.Now.Year.ToString();

        DataSet ds2 = new DataSet();
        DataAccess da2 = new DataAccess();
        int noofdays = 0;
        string str = "";
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

        string startdate = DateTime.Parse(txtdate.Text).Month.ToString() + "/01/" + DateTime.Parse(txtdate.Text).Year.ToString();
        string enddate = DateTime.Parse(txtdate.Text).Month.ToString() + "/" + noofdays.ToString() + "/" + DateTime.Parse(txtdate.Text).Year.ToString();
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + "";
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

        str = " select intid,datename(month,'" + txtdate.Text + "') as staffname , 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
        str += " 'P' as c7,'P' as c8,'P' as c9,";
        str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
        str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
        str += " cast(" + nod.ToString() + " as numeric(15,2)) as present, 0.00 as absent, 0.00 as percentage from tblemployee where";
        str += " intschool='" + Session["schoolID"].ToString() + "' and intid=" + ddlstaffname.SelectedValue;
        ds = da.ExceuteSql(str);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataSet ds1 = new DataSet();
            DataAccess da1 = new DataAccess();
            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstaffattendance where";
            sql += " intstaff=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
            sql += " strtype='" + ddlstafftype.SelectedValue + "' and month(dtdate)=" + month + " and";
            sql += " year(dtdate)=" + year + "";
            ds1 = da1.ExceuteSql(sql);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                {
                    ds.Tables[0].Rows[i][ds1.Tables[0].Rows[j]["days"].ToString()] = "A";
                    ds.Tables[0].Rows[i]["present"] = float.Parse(ds.Tables[0].Rows[i]["present"].ToString()) - 1;
                    ds.Tables[0].Rows[i]["absent"] = float.Parse(ds.Tables[0].Rows[i]["absent"].ToString()) + 1;
                }
                else
                {
                    if (ds1.Tables[0].Rows[i]["strsession"].ToString() == "Half Day - Morning")
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
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows[i]["percentage"] = "100.00";
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
        if (ddlstaffname.SelectedIndex <= 0)
        {
            dgattendancedetail.Columns[0].HeaderText = "Name";
        }
        else
        {
            dgattendancedetail.Columns[0].HeaderText = "Month";
        }
        dgattendancedetail.DataBind();
        fillleaveavail();
    }
    protected void fillleaveavail()
    {
        string resleavetype = "";
        strsql = "";
        strsql = strsql + "select c.strleavetype,intnoofdays-ct as avail,intnoofdays from tblassignstaffleave a, ";
        strsql = strsql + " (select intstaff,intleavetype,sum(ct) as ct from ";
        strsql = strsql + " (select intstaff,intleavetype,count(*) as ct from tblstaffattendance ";
        strsql = strsql + " where intstaff=" + ddlstaffname.SelectedValue + " and strsession='Full Day' and intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + " group by intstaff,intleavetype ";
        strsql = strsql + " union all ";
        strsql = strsql + " select intstaff,intleavetype,count(*)*.5 as ct from tblstaffattendance ";
        strsql = strsql + " where intstaff=" + ddlstaffname.SelectedValue + " and strsession like 'Half Day%' and intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + " group by intstaff,intleavetype) as a ";
        strsql = strsql + " group by intstaff,intleavetype) as b,tblschoolleavecategory c ";
        strsql = strsql + " where a.intstaffid=b.intstaff and a.intleavecategory=b.intleavetype and a.intleavecategory=c.intid ";
        strsql = strsql + " and a.intschool=" + Session["SchoolID"].ToString() + " ";
        strsql = strsql + " union all ";
        strsql = strsql + " select b.strleavetype,intnoofdays as avail,intnoofdays ";
        strsql = strsql + " from tblassignstaffleave a, tblschoolleavecategory b where ";
        strsql = strsql + " a.intleavecategory=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intstaffid=" + ddlstaffname.SelectedValue + " ";
        strsql = strsql + " and b.intid not in( ";
        strsql = strsql + " select intleavetype from tblstaffleaves a, tblleaverequest b ";
        strsql = strsql + " where a.intleaverequest=b.intid and b.intstaff=" + ddlstaffname.SelectedValue + " and b.intschool=" + Session["SchoolID"].ToString() + " group by intleavetype) ";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (double.Parse(ds.Tables[0].Rows[i]["avail"].ToString()) == 0)
                {
                    if (resleavetype != "")
                        resleavetype = resleavetype + ",'" + ds.Tables[0].Rows[i]["strleavetype"].ToString() + "'";
                    else
                        resleavetype = resleavetype + "'" + ds.Tables[0].Rows[i]["strleavetype"].ToString() + "'";
                }
            }
            Session["ResLeavetype"] = resleavetype;
            dgleave.DataSource = ds;
            dgleave.DataBind();
            dgleave.Visible = true;
        }
        else
            dgleave.Visible = false;
    }
    protected void holidays()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select strweekholidays from dbo.tblworkingdays where intschoolid=" + Session["schoolID"].ToString() + " and strmode='Holiday'";
        ds = da.ExceuteSql(str);
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
        string str1 = "select strweekholidays from dbo.tblworkingdays where intschoolid=" + Session["schoolID"].ToString() + " and strmode='Halfday'";
        ds = da.ExceuteSql(str1);
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
        ds = da.ExceuteSql(str2);
        try
        {
            a = int.Parse(ds.Tables[0].Rows[0]["years"].ToString());
            days = DateTime.DaysInMonth(a, 1);
            finalcount = days - total;
        }
        catch { }

        string str3 = "select * from tempholidaycount where dtdate='" + txtdate.Text + "'";
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
            lblsunday.Text = count.ToString();
        }
    }

   protected void ddlstafftype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaffname();
        lblstafftype.Text = ddlstafftype.SelectedItem.Text;
        holidays();
        fillgrd();
        fillgrd2();
        tr1.Visible = true;
        tr2.Visible = true;
        tr3.Visible = true;
        Exemplo01();
    }
    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstaffname.SelectedIndex > 0)
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
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        if (Session["PatronType"] == "Staffs")
        {
            da = new DataAccess();
            strsql = "select strstandard + ' - ' + strsection as strclass from tblstudent where intid=" + Session["UserID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlstafftype.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
            fillstaffname();
            //fillhometeacher();
            lblstafftype.Text = ddlstafftype.SelectedItem.Text;
            holidays();
            fillgrd();
            //fillgrd2();
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            ddlstaffname.SelectedValue = Session["UserID"].ToString();
            fillgrd3();
            Label22.Visible = false;
            Label1.Visible = false;
            ddlstaffname.Visible = false;
            ddlstafftype.Visible = false;
        }
        else
        {
        lbldate.Text = "";
        lbldate.Text = txtdate.Text.Trim();
        holidays();
        fillgrd();
        fillgrd2();
        ddlstaffname.SelectedIndex = 0;
        DateTime dt = DateTime.Parse(txtdate.Text.Trim(), CultureInfo.GetCultureInfo("en-US"));
        string month1 = dt.ToString("MMMM", CultureInfo.GetCultureInfo("en-US"));
        //string month2 = DateTimeFormatInfo.GetInstance(CultureInfo.GetCultureInfo("en-US")).MonthNames[dt.Month - 1];
        int year = DateTime.ParseExact(txtdate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture).Year;
        lblmonthandyear.Text = month1 + " - " + year;
        }
    }
}