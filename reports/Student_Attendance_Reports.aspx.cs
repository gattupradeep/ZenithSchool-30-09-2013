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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Globalization;

public partial class reports_CR_Student_Attendance_Student_Attendance_Reports : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds1;
    public SqlDataAdapter da1;
    public string strsql;
    public int ttmonth;
    public int ttyear;
    public int ttdays;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CR_Student_Att_report_ID"] = 0;
            fillstandard();
            academicyear();
        }
        else
        {
            fillreport((int)Session["CR_Student_Att_report_ID"]);
        }
    }
    protected void fillreport(int id)
    {
        //to find the name of the logged in user //starts here
        DataAccess rda = new DataAccess();
        DataSet rds = new DataSet();
        string rsqlquery = string.Empty;
        if (Session["UserID"].ToString() != "0")
        {
            rsqlquery = "select strfirstname+' '+strmiddlename+' '+strlastname as emplname from tblemployee where intID='" + Session["UserID"] + "' ";
        }
        else
        {
            rsqlquery = "select 'Super Admin' as emplname";
        }
        rds = rda.ExceuteSql(rsqlquery);
        //to find the name of the logged in user // ends here
        if (id == 2)
        {
            string repFilePath = "";
            int noofdays = 0;
            string f = month_year.SelectedValue; //returns selected Month and year value
            string s = f.ToString();
            string[] split = s.Split(" - ".ToCharArray()); //split month and year //split[0] holds (Monthvalue) //split[4] holds (year value)
            int month = DateTime.Parse("1." + split[0] + " 2008").Month;
            int year = DateTime.Parse("1." + "05." + split[4]).Year;
            int mon = int.Parse(DateTime.Now.Month.ToString());
            int yea = int.Parse(DateTime.Now.Year.ToString());
            string changemonthG = "";
            if (month < 9)
            {
                changemonthG = String.Format("{0:00}", month);
            }
            else
            {
                changemonthG = month.ToString();
            }
            if ((month == mon) && (year == yea))
            {
                noofdays = DateTime.Today.Day; 
            }
            else
            {
                noofdays = DateTime.DaysInMonth(year, month); // returns total no of days in selected month
            }


            string str = "select a.intid,a.strstandard,a.strsection,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as studentname,b.intemployee,c.strfirstname + ' ' +c.strmiddlename +' '+c.strlastname as employeename,";
            str += " c.strfirstname + ' ' +c.strmiddlename +' '+c.strlastname as teachername, 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
            str += " 'P' as c7,'P' as c8,'P' as c9,";
            str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
            str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
            str += " cast(" + noofdays.ToString() + " as numeric(15,2)) as present, 0 as absent, 0.00 as percentage,d.strbranch as SchoolBranch from tblstudent a,tblhomeclass b,tblemployee c,tblschooldetails d where";
            str += " a.intschool='" + Session["schoolID"].ToString() + "' and a.strstandard + ' - ' + a.strsection in('" + classandsec.Text.Replace(", ", "','") + "') and d.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")";
            str += " and a.strstandard+' - '+a.strsection = b.strhomeclass and c.intID=b.intemployee";
            if (ddlname.SelectedIndex > 1)
            {
                str += " and a.intid='" + ddlname.SelectedValue + "'";
            }
            ds1 = new DataSet1();
            da1 = new SqlDataAdapter(str, conn);
            da1.Fill(ds1, "tblstudentattendance");

            if (ds1.Tables[2].Rows.Count > 0)
            {
                
                if (id == 2)
                {
                    for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
                    {
                        DataSet dss = new DataSet();
                        DataAccess daa = new DataAccess();
                        string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
                        sql += " intstudent=" + ds1.Tables[2].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                        sql += " strclass in('" + classandsec.Text.Replace(", ", "','") + "') and month(dtdate)=" + month + " and";
                        sql += " year(dtdate)=" + year + "";
                        dss = daa.ExceuteSql(sql);
                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            ds1.Tables[2].Rows[i]["percentage"] = 100;
                        }
                        for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                        {
                            if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                            {
                                ds1.Tables[2].Rows[i][dss.Tables[0].Rows[j]["days"].ToString()] = "A";
                                ds1.Tables[2].Rows[i]["present"] = float.Parse(ds1.Tables[2].Rows[i]["present"].ToString()) - 1;
                                ds1.Tables[2].Rows[i]["absent"] = float.Parse(ds1.Tables[2].Rows[i]["absent"].ToString()) + 1;
                                int countme = int.Parse(ds1.Tables[2].Rows[i]["Fullday"].ToString()) + 1;
                                ds1.Tables[2].Rows[i]["Fullday"] = countme.ToString();
                            }
                            if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Afternoon")
                            {
                                ds1.Tables[2].Rows[i][dss.Tables[0].Rows[j]["days"].ToString()] = "A/A";
                                ds1.Tables[2].Rows[i]["present"] = float.Parse(ds1.Tables[2].Rows[i]["present"].ToString()) - 0.5;
                                ds1.Tables[2].Rows[i]["absent"] = float.Parse(ds1.Tables[2].Rows[i]["absent"].ToString()) + 0.5;
                                ds1.Tables[2].Rows[i]["Afternoon"] = int.Parse(ds1.Tables[2].Rows[i]["Afternoon"].ToString()) + 1;
                            }
                            if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Morning")
                            {
                                ds1.Tables[2].Rows[i][dss.Tables[0].Rows[j]["days"].ToString()] = "M/A";
                                ds1.Tables[2].Rows[i]["present"] = float.Parse(ds1.Tables[2].Rows[i]["present"].ToString()) - 0.5;
                                ds1.Tables[2].Rows[i]["absent"] = float.Parse(ds1.Tables[2].Rows[i]["absent"].ToString()) + 0.5;
                                ds1.Tables[2].Rows[i]["Morning"] = int.Parse(ds1.Tables[2].Rows[i]["Morning"].ToString()) + 1;
                            }
                            double p = double.Parse(ds1.Tables[2].Rows[i]["present"].ToString());
                            double percentage = ((p / noofdays) * 100);
                            double b = double.Parse(String.Format("{0:0.##}", percentage));
                            ds1.Tables[2].Rows[i]["percentage"] = b;
                        }
                        //---------------
                        DataAccess da_h = new DataAccess();
                        DataSet ds_h = new DataSet();
                        string sql_h = "select datepart(D,dtdate) as dtdate from tblacademiccalender where intschool='" + Session["SchoolID"] + "' and month(dtdate)=" + changemonthG + " and year(dtdate)=" + year + "";
                        ds_h = da_h.ExceuteSql(sql_h);
                        if (ds_h.Tables[0].Rows.Count > 0)
                        {
                            for (int q = 0; q < ds_h.Tables[0].Rows.Count; q++)
                            {
                                ds1.Tables[2].Rows[i]["c" + ds_h.Tables[0].Rows[q]["dtdate"].ToString()] = "F";
                                ds1.Tables[2].Rows[i]["present"] = double.Parse(ds1.Tables[2].Rows[i]["present"].ToString()) - 1;
                            }
                        }

                        CultureInfo ci = new CultureInfo("en-US");
                        for (int x = 1; x <= ci.Calendar.GetDaysInMonth(year, month); x++)
                        {
                            DataAccess daholi = new DataAccess();
                            DataSet dsholi = new DataSet();
                            string strsqlholi = "select strweekholidays from tblworkingdays where strmode='Holiday' and intschoolid= '" + Session["schoolID"].ToString() + "'";
                            dsholi = daholi.ExceuteSql(strsqlholi);
                            if (dsholi.Tables[0].Rows.Count > 0)
                            {
                                for (int y = 0; y < dsholi.Tables[0].Rows.Count; y++)
                                {
                                    string dayname = dsholi.Tables[0].Rows[y]["strweekholidays"].ToString();
                                    DayOfWeek daynameno = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayname);
                                    if (new DateTime(year, month, x).DayOfWeek == daynameno)
                                    {
                                        ds1.Tables[2].Rows[i]["c" + x] = "H";
                                        ds1.Tables[2].Rows[i]["present"] = double.Parse(ds1.Tables[2].Rows[i]["present"].ToString()) - 1;
                                    }
                                }
                            }

                        }
                        //---------------
                        ds1.Tables[2].Rows[i]["Totalnoofdays"] = noofdays;
                        ds1.Tables[2].Rows[i]["Reportsortby"] = month_year.SelectedValue;
                        string classtitle = classandsec.Text;
                        if(chkAll.Checked==true)
                            ds1.Tables[2].Rows[i]["Reporttitle"] = "ALL";
                        else
                            ds1.Tables[2].Rows[i]["Reporttitle"] = classtitle;
                        
                        if (rds.Tables[0].Rows.Count > 0)
                        {
                            ds1.Tables[2].Rows[i]["ReportGeneratedby"] = rds.Tables[0].Rows[0]["emplname"]; // print name of the user logged in 
                        }
                    }
                    for (int i = noofdays + 1; i <= 31; i++)
                    {
                        for (int j = 0; j < ds1.Tables[2].Rows.Count; j++)
                        {
                            ds1.Tables[2].Rows[j]["c" + i] = "-";
                        }
                    }
                    
                    holidays();
                    if (id == 0)
                    {
                        repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                    }
                    if (id == 2)
                    {
                        repFilePath = Server.MapPath("CR_Student_Attendance/CR_Stud_Attd_CurMonth.rpt");
                    }
                    if (ddlname.SelectedIndex > 1)
                    {
                        repFilePath = Server.MapPath("CR_Student_Attendance/CR_Stud_Att_curMonth_Ind.rpt");
                    }
                }
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(repFilePath);
                reportdocument.SetDataSource(ds1);
                CrystalReportViewer1.ReportSource = reportdocument;
                CrystalReportViewer1.DataBind();
            }
            else
            {
                repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(repFilePath);
                reportdocument.SetDataSource(ds1);
                CrystalReportViewer1.ReportSource = reportdocument;
                CrystalReportViewer1.DataBind();
            }
        }
        if (id == 4)
        {
            DataSet ds2 = new DataSet();
            DataAccess da2 = new DataAccess();
            int noofdays = 0;
            string str2 = "select year('" + Attnd_Date.Text + "') as years,month('" + Attnd_Date.Text + "') as months,day('" + Attnd_Date.Text + "') as curdate";
            ds2 = da2.ExceuteSql(str2);
            int year = int.Parse(ds2.Tables[0].Rows[0]["years"].ToString());
            int month = int.Parse(ds2.Tables[0].Rows[0]["months"].ToString());
            int curdaate = int.Parse(ds2.Tables[0].Rows[0]["curdate"].ToString());
            string changemonthG = "";
            if (month < 9)
            {
                changemonthG = String.Format("{0:00}", month);
            }
            else
            {
                changemonthG = month.ToString();
            }
            string repFilePath = "";
            int mon = int.Parse(DateTime.Now.Month.ToString());
            int yea = int.Parse(DateTime.Now.Year.ToString());
            if ((month == mon) && (year == yea))
            {
                noofdays = DateTime.Today.Day;
            }
            else
            {
                noofdays = DateTime.DaysInMonth(year, month); // returns total no of days in selected month
            }


            string str = "select a.intid,a.strstandard,a.strsection,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as studentname,b.intemployee,c.strfirstname + ' ' +c.strmiddlename +' '+c.strlastname as employeename, ";
            str += " c.strfirstname + ' ' +c.strmiddlename +' '+c.strlastname as teachername, 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
            str += " 'P' as c7,'P' as c8,'P' as c9,";
            str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
            str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
            str += " 'P' as present, '' as absent, '' as percentage,d.strbranch as SchoolBranch from tblstudent a,tblhomeclass b,tblemployee c,tblschooldetails d where";
            str += " a.intschool='" + Session["schoolID"].ToString() + "' and a.strstandard + ' - ' + a.strsection in('" + classandsec.Text.Replace(", ", "','") + "') and d.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")";
            str += " and a.strstandard+' - '+a.strsection = b.strhomeclass and c.intID=b.intemployee";
            if (ddlname.SelectedIndex > 1)
            {
                str += " and a.intid='" + ddlname.SelectedValue + "'";
            }
            ds1 = new DataSet1();
            da1 = new SqlDataAdapter(str, conn);
            da1.Fill(ds1, "tblstudentattendance");

            if (ds1.Tables[2].Rows.Count > 0)
            {
                if (id == 0)
                {
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                }
                if (id == 4)
                {
                    for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
                    {
                        DataSet dss = new DataSet();
                        DataAccess daa = new DataAccess();
                        string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
                        sql += " intstudent=" + ds1.Tables[2].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                        sql += " strclass in('" + classandsec.Text.Replace(", ", "','") + "') and day(dtdate)=" + curdaate + " and month(dtdate)=" + month + " and";
                        sql += " year(dtdate)=" + year + "";
                        dss = daa.ExceuteSql(sql);
                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            //ds1.Tables[2].Rows[i]["Present"] = "1";
                        }
                       
                        for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                        {
                            if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                            {
                                ds1.Tables[2].Rows[i][dss.Tables[0].Rows[j]["days"].ToString()] = "A";
                                ds1.Tables[2].Rows[i]["Fullday"] = "A";
                                ds1.Tables[2].Rows[i]["Present"] = "x";
                            }
                            if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Afternoon")
                            {
                                ds1.Tables[2].Rows[i][dss.Tables[0].Rows[j]["days"].ToString()] = "A/A";
                                ds1.Tables[2].Rows[i]["Afternoon"] = "A/A";
                                ds1.Tables[2].Rows[i]["Present"] = "x";
                            }
                            if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Morning")
                            {
                                ds1.Tables[2].Rows[i][dss.Tables[0].Rows[j]["days"].ToString()] = "M/A";
                                ds1.Tables[2].Rows[i]["Morning"] = "M/A";
                                ds1.Tables[2].Rows[i]["Present"] = "x";
                            }
                        }
                        //---------------

                        DataAccess da_h = new DataAccess();
                        DataSet ds_h = new DataSet();
                        string sql_h = "select datepart(D,dtdate) as dtdate from tblacademiccalender where intschool='" + Session["SchoolID"] + "' and month(dtdate)=" + changemonthG + " and year(dtdate)=" + year + "";
                        ds_h = da_h.ExceuteSql(sql_h);
                        if (ds_h.Tables[0].Rows.Count > 0)
                        {
                            for (int q = 0; q < ds_h.Tables[0].Rows.Count; q++)
                            {
                                if (curdaate == int.Parse(ds_h.Tables[0].Rows[q]["dtdate"].ToString()))
                                {
                                   ds1.Tables[2].Rows[i]["c"+ds_h.Tables[0].Rows[q]["dtdate"].ToString()]="F";
                                }
                            }
                        }

                        CultureInfo ci = new CultureInfo("en-US");
                        for (int x = 1; x <= ci.Calendar.GetDaysInMonth(year, month); x++)
                        {
                            DataAccess daholi = new DataAccess();
                            DataSet dsholi = new DataSet();
                            string strsqlholi = "select strweekholidays from tblworkingdays where strmode='Holiday' and intschoolid= '" + Session["schoolID"].ToString() + "'";
                            dsholi = daholi.ExceuteSql(strsqlholi);
                            if (dsholi.Tables[0].Rows.Count > 0)
                            {
                                for (int y = 0; y < dsholi.Tables[0].Rows.Count; y++)
                                {
                                    string dayname = dsholi.Tables[0].Rows[y]["strweekholidays"].ToString();
                                    DayOfWeek daynameno = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayname);
                                    if (new DateTime(year, month, curdaate).DayOfWeek == daynameno)
                                    {
                                        ds1.Tables[2].Rows[i]["c" + curdaate] = "H";
                                    }
                                }
                            }

                        }

                        //---------------
                        //ds1.Tables[2].Rows[i]["Totalnoofdays"] = noofdays;
                        string classtitle = classandsec.Text;
                        if (chkAll.Checked == true)
                            ds1.Tables[2].Rows[i]["Reporttitle"] = "ALL";
                        else
                            ds1.Tables[2].Rows[i]["Reporttitle"] = classtitle;

                        if (rds.Tables[0].Rows.Count > 0)
                        {
                            ds1.Tables[2].Rows[i]["ReportGeneratedby"] = rds.Tables[0].Rows[0]["emplname"]; // print name of the user logged in 
                            ds1.Tables[2].Rows[i]["Reportsortby"] = Attnd_Date.Text;
                        }
                    }
                    for (int i = curdaate + 1; i <= 31; i++)
                    {
                        for (int j = 0; j < ds1.Tables[2].Rows.Count; j++)
                        {
                            ds1.Tables[2].Rows[j]["c" + i] = "-";
                        }
                    }
                    for (int i = curdaate-1; i >= 1; i--)
                    {
                        for (int j = 0; j < ds1.Tables[2].Rows.Count; j++)
                        {
                            ds1.Tables[2].Rows[j]["c" + i] = "-";
                        }
                    }
                    if (ddlname.SelectedIndex > 1)
                    {
                        repFilePath = Server.MapPath("CR_Student_Attendance/CR_Student_Att_curdate_Ind.rpt");
                    }
                    else
                    {
                        repFilePath = Server.MapPath("CR_Student_Attendance/CR_Student_Att_curdate.rpt");
                    }
                }
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(repFilePath);
                reportdocument.SetDataSource(ds1);
                CrystalReportViewer1.ReportSource = reportdocument;
                CrystalReportViewer1.DataBind();
            }
            else
            {
                repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(repFilePath);
                reportdocument.SetDataSource(ds1);
                CrystalReportViewer1.ReportSource = reportdocument;
                CrystalReportViewer1.DataBind();
            }
        }

        if (id == 3)
        {
            ttmonth = 0;
            ttyear = 0;
            ttdays = 0;
            string repFilePath = "";
            DataAccess dadelete = new DataAccess();
            DataSet dsdelete = new DataSet();
            string strsqldelete = "delete from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'";
            dsdelete = dadelete.ExceuteSql(strsqldelete);

            string f0 = from_year.SelectedValue;
            string s0 = f0.ToString();
            string[] split0 = s0.Split(" - ".ToCharArray());
            int month1 = DateTime.Parse("1." + split0[0] + " 2008").Month;
            string changemonth1 = "";
            if (month1 < 9)
            {
                changemonth1 = String.Format("{0:00}", month1);
            }
            else
            {
                changemonth1 = month1.ToString();
            }
            string f1 = to_year.SelectedValue;
            string s1 = f1.ToString();
            string[] split1 = s1.Split(" - ".ToCharArray());
            int month2 = DateTime.Parse("1." + split1[0] + " 2008").Month;
            string changemonth2 = "";
            if (month1 < 9)
            {
                changemonth2 = String.Format("{0:00}", month2);
            }
            else
            {
                changemonth2 = month2.ToString();
            }
            DataAccess damonth = new DataAccess();
            DataSet dsmonth = new DataSet();
            string sqlmonth = "SELECT DATEDIFF(mm,'1 " + split0[0] + " " + split0[4] + "','1 " + split1[0] + " " + split1[4] + "') as countofmonth";
            dsmonth = damonth.ExceuteSql(sqlmonth);
            int countofmonth = int.Parse(dsmonth.Tables[0].Rows[0]["countofmonth"].ToString());
            int fs = from_year.SelectedIndex;
            for (int z = 0; z <= countofmonth; z++)
            {
                int noofdays = 0;
                string f = from_year.Items[fs+z].Value;

                //string f = from_year.SelectedValue;
                string s = f.ToString();
                string[] split = s.Split(" - ".ToCharArray());
                int month = DateTime.Parse("1." + split[0] + " 2008").Month;
                int year = DateTime.Parse("1." + "05." + split[4]).Year;
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
                ttmonth = month;
                ttyear = year;
                ttdays = noofdays;
                string[] splitG = f.Split(" - ".ToCharArray());
                int monthG = DateTime.Parse("1." + splitG[0] + " 2008").Month;
                string changemonthG = "";
                if (monthG < 9)
                {
                    changemonthG = String.Format("{0:00}", monthG);
                }
                else
                {
                    changemonthG = monthG.ToString();
                }
                string str = "select '" + splitG[4] + "-" + changemonthG + "-01 00:00:000' as periodmonthandyear,a.intid as intstudentid,a.strstandard,a.strsection,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as studentname,b.intemployee,c.strfirstname + ' ' +c.strmiddlename +' '+c.strlastname as employeename, 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
                str += " c.strfirstname + ' ' +c.strmiddlename +' '+c.strlastname as teachername, 'P' as c1,'P' as c2,'P' as c3,'P' as c4,'P' as c5,'P' as c6,";
                str += " 'P' as c7,'P' as c8,'P' as c9,";
                str += " 'P' as c10,'P' as c11,'P' as c12,'P' as c13,'P' as c14,'P' as c15,'P' as c16,'P' as c17,'P' as c18,'P' as c19,'P' as c20,'P' as c21,";
                str += " 'P' as c22,'P' as c23,'P' as c24,'P' as c25,'P' as c26,'P' as c27,'P' as c28,'P' as c29,'P' as c30,'P' as c31,";
                str += " cast(" + noofdays.ToString() + " as numeric(15,2)) as present, 0 as absent, 0.00 as percentage,d.strbranch as SchoolBranch from tblstudent a,tblhomeclass b,tblemployee c,tblschooldetails d where";
                str += " a.intschool='" + Session["schoolID"].ToString() + "' and a.strstandard + ' - ' + a.strsection in('" + classandsec.Text.Replace(", ", "','") + "') and d.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")";
                str += " and a.strstandard+' - '+a.strsection = b.strhomeclass and c.intID=b.intemployee";
                if (ddlname.SelectedIndex > 1)
                {
                    str += " and a.intid='" + ddlname.SelectedValue + "'";
                }
                DataSet dsft = new DataSet();
                DataAccess daft = new DataAccess();
                dsft = daft.ExceuteSql(str);

                if (dsft.Tables[0].Rows.Count > 0)
                {
                    for (int q = 0; q < dsft.Tables[0].Rows.Count; q++)
                    {
                        DataAccess daftinsert = new DataAccess();
                        DataSet dsftinsert = new DataSet();
                        string strsqlft = "insert into tbltempstudentattndCRreports values(";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["studentname"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["strstandard"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["strsection"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c1"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c2"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c3"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c4"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c5"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c6"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c7"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c8"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c9"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c10"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c11"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c12"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c13"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c14"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c15"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c16"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c17"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c18"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c19"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c20"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c21"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c22"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c23"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c24"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c25"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c26"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c27"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c28"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c29"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c30"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["c31"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["present"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["absent"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["percentage"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["periodmonthandyear"] + "',";
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["intstudentid"] + "',";
                        strsqlft += "'" + Session["SchoolID"] + "',";
                        strsqlft += "'" + Session["UserID"] + "',";
                        strsqlft += "'" + noofdays + "',"; //Totalnoofdays
                        strsqlft += "'0',"; //Totalfestivalholidays
                        strsqlft += "'0',"; //Totalholidays
                        strsqlft += "'0',"; //TotalNoWorkingdays
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["teachername"] + "',";
                        strsqlft += "'0',"; //Reporttitle
                        strsqlft += "'0',"; //ReportGeneratedby
                        strsqlft += "'0',"; //Reportsortby
                        strsqlft += "'" + dsft.Tables[0].Rows[q]["SchoolBranch"] + "',";//SchoolBranch
                        strsqlft += "'0',"; //Morning Absent count
                        strsqlft += "'0',"; //Afternoon absent count
                        strsqlft += "'0')"; //Fullday absent count
                        dsftinsert = daftinsert.ExceuteSql(strsqlft);
                    }

                    DataAccess daupdate = new DataAccess();
                    DataSet dsupdate = new DataSet();
                    string strsqlupdate = "select * from dbo.tbltempstudentattndCRreports where intschool='" + Session["schoolID"].ToString() + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                    dsupdate = daupdate.ExceuteSql(strsqlupdate);
                    if (dsupdate.Tables[0].Rows.Count > 0)
                    {
                        for (int m = 0; m < dsupdate.Tables[0].Rows.Count; m++)
                        {
                            DataAccess da_h = new DataAccess();
                            DataSet ds_h = new DataSet();
                            string sql_h = "select datepart(D,dtdate) as dtdate from tblacademiccalender where intschool='" + Session["SchoolID"] + "' and month(dtdate)=" + changemonthG + " and year(dtdate)=" + splitG[4] + "";
                            ds_h = da_h.ExceuteSql(sql_h);
                            if (ds_h.Tables[0].Rows.Count > 0)
                            {
                                for (int q = 0; q < ds_h.Tables[0].Rows.Count; q++)
                                {
                                    DataAccess da_hup = new DataAccess();
                                    DataSet ds_hup = new DataSet();
                                    string sql_hup = "update dbo.tbltempstudentattndCRreports set c"+ds_h.Tables[0].Rows[q]["dtdate"]+"='F'  where intschool='" + Session["schoolID"].ToString() + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    ds_hup = da_hup.ExceuteSql(sql_hup);
                                }
                            }

                            CultureInfo ci = new CultureInfo("en-US");
                            for (int i = 1; i <= ci.Calendar.GetDaysInMonth(year, month); i++)
                            {
                                DataAccess daholi = new DataAccess();
                                DataSet dsholi = new DataSet();
                                string strsqlholi = "select strweekholidays from tblworkingdays where strmode='Holiday' and intschoolid= '" + Session["schoolID"].ToString() + "'";
                                dsholi = daholi.ExceuteSql(strsqlholi);
                                if (dsholi.Tables[0].Rows.Count > 0)
                                {
                                    for (int y = 0; y < dsholi.Tables[0].Rows.Count; y++)
                                    {
                                        string dayname=dsholi.Tables[0].Rows[y]["strweekholidays"].ToString();
                                        DayOfWeek daynameno = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayname);
                                        if (new DateTime(year, month, i).DayOfWeek == daynameno)
                                        {
                                            DataAccess daupholidays = new DataAccess();
                                            DataSet dsupholidays = new DataSet();
                                            string strsqlHup = "update tbltempstudentattndCRreports set c" + i + "='H' where intschool='" + Session["schoolID"].ToString() + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                            dsupholidays = daupholidays.ExceuteSql(strsqlHup);
                                        }
                                    }
                                }
                                
                            }

                            DataSet dss = new DataSet();
                            
                            DataAccess daa = new DataAccess();
                            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
                            sql += " intstudent=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                            sql += " strclass in('" + classandsec.Text.Replace(", ", "','") + "') and month(dtdate)=" + month + " and";
                            sql += " year(dtdate)=" + year + "";
                            dss = daa.ExceuteSql(sql);
                            if (dss.Tables[0].Rows.Count == 0)
                            {
                                DataAccess daup1 = new DataAccess();
                                DataSet dsup1 = new DataSet();
                                string strsqlup1 = "update dbo.tbltempstudentattndCRreports set percentage='100' where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                dsup1 = daup1.ExceuteSql(strsqlup1);
                            }
                            for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                            {
                                if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                                {
                                    DataAccess dasearch0 = new DataAccess();
                                    DataSet dssearch0 = new DataSet();
                                    string sql10 = "select present,absent from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dssearch0 = dasearch0.ExceuteSql(sql10);
                                    float pr1 = float.Parse(dssearch0.Tables[0].Rows[0]["present"].ToString()) - 1;
                                    float ap1 = float.Parse(dssearch0.Tables[0].Rows[0]["absent"].ToString()) + 1;
                                    DataAccess daup1 = new DataAccess();
                                    DataSet dsup1 = new DataSet();
                                    string strsqlup1 = "update dbo.tbltempstudentattndCRreports set " + dss.Tables[0].Rows[j]["days"] + "='A' ,";
                                    strsqlup1 += "present = " + pr1 + ",";
                                    strsqlup1 += "absent = " + ap1 + ",";
                                    strsqlup1 += "Fullday = " + ap1 + "";
                                    strsqlup1 += " where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dsup1 = daup1.ExceuteSql(strsqlup1);
                                }
                                if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Morning")
                                {
                                    DataAccess dasearch2 = new DataAccess();
                                    DataSet dssearch2 = new DataSet();
                                    string sql12 = "select present,absent,Morning from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dssearch2 = dasearch2.ExceuteSql(sql12);
                                    DataAccess dasearch1 = new DataAccess();
                                    DataSet dssearch1 = new DataSet();
                                    string sql11 = "select present from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dssearch1 = dasearch1.ExceuteSql(sql11);
                                    double pr1 = float.Parse(dssearch2.Tables[0].Rows[0]["present"].ToString()) - 0.5;
                                    double ap1 = float.Parse(dssearch2.Tables[0].Rows[0]["absent"].ToString()) + 0.5;
                                    double ap2 = float.Parse(dssearch2.Tables[0].Rows[0]["Morning"].ToString()) + 1;
                                    DataAccess daup1 = new DataAccess();
                                    DataSet dsup1 = new DataSet();
                                    string strsqlup1 = "update dbo.tbltempstudentattndCRreports set " + dss.Tables[0].Rows[j]["days"] + "='M/A',";
                                    strsqlup1 += "present = " + pr1 + ",";
                                    strsqlup1 += "absent = " + ap1 + ",";
                                    strsqlup1 += "Morning = " + ap2 + "";
                                    strsqlup1 += " where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dsup1 = daup1.ExceuteSql(strsqlup1);
                                }
                                if (dss.Tables[0].Rows[j]["strsession"].ToString() == "Half Day - Afternoon")
                                {
                                    DataAccess dasearch2 = new DataAccess();
                                    DataSet dssearch2 = new DataSet();
                                    string sql12 = "select present,absent,Afternoon from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dssearch2 = dasearch2.ExceuteSql(sql12);
                                    DataAccess dasearch1 = new DataAccess();
                                    DataSet dssearch1 = new DataSet();
                                    string sql11 = "select present from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dssearch1 = dasearch1.ExceuteSql(sql11);
                                    double pr1 = float.Parse(dssearch2.Tables[0].Rows[0]["present"].ToString()) - 0.5;
                                    double ap1 = float.Parse(dssearch2.Tables[0].Rows[0]["absent"].ToString()) + 0.5;
                                    double ap2 = float.Parse(dssearch2.Tables[0].Rows[0]["Afternoon"].ToString()) + 1;
                                    DataAccess daup1 = new DataAccess();
                                    DataSet dsup1 = new DataSet();
                                    string strsqlup1 = "update dbo.tbltempstudentattndCRreports set " + dss.Tables[0].Rows[j]["days"] + "='A/A',";
                                    strsqlup1 += "present = " + pr1 + ",";
                                    strsqlup1 += "absent = " + ap1 + ",";
                                    strsqlup1 += "Afternoon = " + ap2 + "";
                                    strsqlup1 += " where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                    dsup1 = daup1.ExceuteSql(strsqlup1);
                                }
                                DataAccess dasearch = new DataAccess();
                                DataSet dssearch = new DataSet();
                                string sql1 = "select present from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                dssearch = dasearch.ExceuteSql(sql1);
                                double p = double.Parse(dssearch.Tables[0].Rows[0]["present"].ToString());
                                double percentage = ((p / noofdays) * 100);
                                double b = double.Parse(String.Format("{0:0.##}", percentage));
                                //dsupdate.Tables[0].Rows[m]["percentage"] = b;
                                DataAccess daup2 = new DataAccess();
                                DataSet dsup2 = new DataSet();
                                string strsqlup2 = "update dbo.tbltempstudentattndCRreports set percentage =" + b + " ";
                                strsqlup2 += " where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and intstudentid=" + dsupdate.Tables[0].Rows[m]["intstudentid"].ToString() + " and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                                dsup2 = daup2.ExceuteSql(strsqlup2);
                            }
                            // dsupdate.Tables[0].Rows[m]["Totalnoofdays"] = noofdays;
                            string strsqlupdateme = "";
                            string classtitle = classandsec.Text;
                            DataAccess daaup = new DataAccess();
                            DataSet dssup = new DataSet();
                            if (chkAll.Checked == true)
                            {
                                strsqlupdateme = "update tbltempstudentattndCRreports set Reporttitle='ALL',Reportsortby='"+from_year.SelectedValue+" To "+to_year.SelectedValue+"',ReportGeneratedby='" + rds.Tables[0].Rows[0]["emplname"] + "' where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000' ";
                            }
                            else
                            {
                                strsqlupdateme = "update tbltempstudentattndCRreports set Reporttitle='" + classtitle + "',Reportsortby='" + from_year.SelectedValue + " To " + to_year.SelectedValue + "',ReportGeneratedby='" + rds.Tables[0].Rows[0]["emplname"] + "' where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000' ";
                            }
                            dssup = daaup.ExceuteSql(strsqlupdateme);
                        }
                    }

                }
                for (int a = noofdays + 1; a <= 31; a++)
                {
                    DataAccess dasearcha = new DataAccess();
                    DataSet dssearcha = new DataSet();
                    string sql1a = "select * from dbo.tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                    dssearcha = dasearcha.ExceuteSql(sql1a);
                    if (dssearcha.Tables[0].Rows.Count > 0)
                    {
                        for (int b = 0; b < dssearcha.Tables[0].Rows.Count; b++)
                        {
                        
                            DataAccess daup2search = new DataAccess();
                            DataSet dsup2search = new DataSet();
                            string strsqlup2search = "update dbo.tbltempstudentattndCRreports set c" + a + " ='" + '-' + "' ";
                            strsqlup2search += " where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'and periodmonthandyear ='" + splitG[4] + "-" + changemonthG + "-01 00:00:000'";
                            dsup2search = daup2search.ExceuteSql(strsqlup2search);
                        }
                    }
                }

                holidays1();
            }
            string strsql = "select CONVERT(CHAR(4), convert(datetime,periodmonthandyear), 100) +' - '+ CONVERT(CHAR(4), periodmonthandyear, 120) as periodmonthandyear,TotalNoWorkingdays-absent as present,* from tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "'";
            ds1 = new DataSet1();
            da1 = new SqlDataAdapter(strsql, conn);
            da1.Fill(ds1, "tblstudentattendance");

            if (ds1.Tables[2].Rows.Count > 0)
            {
                if (id == 0)
                {
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                }
                if (id == 3)
                {
                    repFilePath = Server.MapPath("CR_Student_Attendance/CR_Stud_Attd_FT.rpt");
                }
                if (ddlname.SelectedIndex > 1)
                {
                    repFilePath = Server.MapPath("CR_Student_Attendance/CR_Stud_Attd_FT_Ind.rpt");
                }
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(repFilePath);
                reportdocument.SetDataSource(ds1);
                CrystalReportViewer1.ReportSource = reportdocument;
                CrystalReportViewer1.DataBind();
            }
            else
            {
                repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(repFilePath);
                reportdocument.SetDataSource(ds1);
                CrystalReportViewer1.ReportSource = reportdocument;
                CrystalReportViewer1.DataBind();
            }
        }
    }
    protected void fillstandard()
    {
        string str = "select strstandard+' - '+strsection as Classandsec from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        chklstandard.DataSource = ds;
        chklstandard.DataTextField = "Classandsec";
        chklstandard.DataValueField = "Classandsec";
        chklstandard.DataBind();
    }
    protected void fillstudent()
    {
        string strsql = "";
        DataAccess da = new DataAccess();
        strsql = "select intid, strfirstname + ' ' + strmiddlename + ' ' + strlastname as name from tblstudent where  intschool=" + Session["SchoolID"].ToString();
        if (classandsec.Text != "")
            strsql = strsql + "  and strstandard + ' - ' + strsection in('" + classandsec.Text.Replace(", ", "','") + "')";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlname.DataSource = ds;
        ddlname.DataTextField = "name";
        ddlname.DataValueField = "intid";
        ddlname.DataBind();
        ddlname.Items.Insert(0, "--Select--");
        ddlname.Items.Insert(1, "-ALL-");
    }
 
   protected void chklstandard_SelectedIndexChanged(object sender, EventArgs e)
   {
       string name = "";
       for (int i = 0; i < chklstandard.Items.Count; i++)
       {
           if (chklstandard.Items[i].Selected)
           {
               name += chklstandard.Items[i].Text + ", ";
           }
       }
       classandsec.Text = name;

       if (name != "")
       {
           fillstudent();
       }
       else
       {
           ddlname.Items.Clear();
           ddlname.Items.Insert(0, "-Select-");
       }
   }
   protected void academicyear()
   {
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string sqlquery = "select intYear from tblAcademicYear where intschool='" + Session["SchoolID"] + "' and intID <=(select intID from tblacademicyear where intactive = 1 and intschool =" + Session["SchoolID"] + ") order by intyear desc";
       ds = da.ExceuteSql(sqlquery);
       ddlacademicyear.DataSource = ds;
       ddlacademicyear.DataTextField = "intYear";
       ddlacademicyear.DataValueField = "intyear";
       ddlacademicyear.DataBind();
       fillmonth();
       fillfrommonthyear();
       filltomonthyear();
   }
   protected void fillmonth()
   {
      
       month_year.Items.Clear();
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string sqlquery = "SELECT DATEDIFF(MONTH, StartDate, EndDate ) as totalmonth from tblAcademicYear where intschool=" + Session["SchoolID"] + " and intYear='" + ddlacademicyear.SelectedValue + "'";
       ds = da.ExceuteSql(sqlquery);
       if (ds.Tables[0].Rows.Count > 0)
       {
           for (int i = 0; i < int.Parse(ds.Tables[0].Rows[0]["totalmonth"].ToString()); i++)
           {
               DataAccess das = new DataAccess();
               DataSet dss = new DataSet();
               string strsqlquery = "SELECT CONVERT(CHAR(4), DATEADD(month, " + i + ", StartDate), 100) +' - '+ CONVERT(CHAR(4), DATEADD(month, " + i + ", StartDate), 120) as months from tblAcademicYear where intschool ='" + Session["SchoolID"] + "' and intYear='" + ddlacademicyear.SelectedValue + "'";
               dss = das.ExceuteSql(strsqlquery);
               month_year.Items.Insert(i, dss.Tables[0].Rows[0]["months"].ToString());
           }
       }
      
   }
   protected void fillfrommonthyear()
   {
       
       from_year.Items.Clear();
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string sqlquery = "SELECT DATEDIFF(MONTH, StartDate, EndDate ) as totalmonth from tblAcademicYear where intschool='"+Session["SchoolID"]+"' and intYear='" + ddlacademicyear.SelectedValue + "'";
       ds = da.ExceuteSql(sqlquery);
       if (ds.Tables[0].Rows.Count > 0)
       {
           for (int i = 0; i < int.Parse(ds.Tables[0].Rows[0]["totalmonth"].ToString());i++ )
           {
               DataAccess das = new DataAccess();
               DataSet dss = new DataSet();
               string strsqlquery = "SELECT CONVERT(CHAR(4), DATEADD(month, " + i + ", StartDate), 100) +' - '+ CONVERT(CHAR(4), DATEADD(month, " + i + ", StartDate), 120) as months from tblAcademicYear where intschool ='" + Session["SchoolID"] + "' and intYear='" + ddlacademicyear.SelectedValue + "'";
               dss = das.ExceuteSql(strsqlquery);
               from_year.Items.Insert(i, dss.Tables[0].Rows[0]["months"].ToString());
           }
       }
   }
   protected void filltomonthyear()
   {
       to_year.Items.Clear();
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string sqlquery = "SELECT DATEDIFF(MONTH, StartDate, EndDate ) as totalmonth from tblAcademicYear where intschool='" + Session["SchoolID"] + "' and intYear='" + ddlacademicyear.SelectedValue + "'";
       ds = da.ExceuteSql(sqlquery);
       if (ds.Tables[0].Rows.Count > 0)
       {
           for (int i = 0; i < int.Parse(ds.Tables[0].Rows[0]["totalmonth"].ToString()); i++)
           {
               DataAccess das = new DataAccess();
               DataSet dss = new DataSet();
               string strsqlquery = "SELECT CONVERT(CHAR(4), DATEADD(month, " + i + ", StartDate), 100) +' - '+ CONVERT(CHAR(4), DATEADD(month, " + i + ", StartDate), 120) as months from tblAcademicYear where intschool ='" + Session["SchoolID"] + "' and intYear='" + ddlacademicyear.SelectedValue + "'";
               dss = das.ExceuteSql(strsqlquery);
               to_year.Items.Insert(i, dss.Tables[0].Rows[0]["months"].ToString());
           }
       }
   }
   protected void ddlacademicyear_SelectedIndexChanged(object sender, EventArgs e)
   {
       fillmonth();
       fillfrommonthyear();
       filltomonthyear();
   }
   protected void Attnd_month_SelectedIndexChanged(object sender, EventArgs e)
   {
      
   }
   protected void month_year_SelectedIndexChanged(object sender, EventArgs e)
   {
       //to print report for the selected month
       if (classandsec.Text != "")
       {
           Session["CR_Student_Att_report_ID"] = 2;
           fillreport(2);
       }
   }
   protected void Attnd_Date_TextChanged(object sender, EventArgs e)
   {
       //to print report for the selected month
       if (classandsec.Text != "")
       {
           Session["CR_Student_Att_report_ID"] = 4;
           fillreport(4);
       }
   }
   protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
   {
       //to print the report for selected name
       //if (classandsec.Text != "")
       //{
       //    Session["CR_Student_Att_report_ID"] = 2;
       //    fillreport(2);
       //}
   }
   protected void to_year_SelectedIndexChanged(object sender, EventArgs e)
   {    //to print the report for selected from and to months
       if (classandsec.Text != "")
       {
           Session["CR_Student_Att_report_ID"] = 3;
           fillreport(3);
       }
   }
   protected void holidays()
   {
       string f = month_year.SelectedValue;
       string s = f.ToString();
       string[] split = s.Split(" - ".ToCharArray());
       int smonth = DateTime.Parse("1." + split[0] + " 2008").Month;
       int ayear = DateTime.Parse("1." + "05." + split[4]).Year;
       int days = DateTime.DaysInMonth(ayear, DateTime.Parse("1." + split[0] + " 2008").Month);
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string str = "select strweekholidays from dbo.tblworkingdays where intschoolid=" + Session["schoolID"].ToString() + " and strmode='Holiday'";
       ds = da.ExceuteSql(str);
       //string holiday = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
       //DayOfWeek illegal = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holiday);
       //PrintSundays(ayear, smonth, illegal);
       int holidayc = 0;
       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
       {
           string holiday = ds.Tables[0].Rows[i]["strweekholidays"].ToString();
           DayOfWeek illegal = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holiday);
           PrintSundays(ayear, smonth, illegal);
           if (holidayc == 0)
               holidayc = int.Parse(lblsunday.Text);
           else
               holidayc = holidayc + int.Parse(lblsunday.Text);
       }
       //string str1 = "select strweekholidays from dbo.tblworkingdays where intschool=" + Session["schoolID"].ToString() + " and strmode='Halfday'";
       //ds = da.ExceuteSql(str1);
       //string holidayhalf = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
       //DayOfWeek illegalhalf = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayhalf);
       //PrintSundays(ayear, smonth, illegalhalf);
       //int totalcount = int.Parse(lblsunday.Text);
       //int halfdayc = totalcount / 2;
       //int total = holidayc + halfdayc;
       int total = holidayc ;
       
       int finalcount = days - total;
       int festivaldays = 0;
       DataAccess da_h = new DataAccess();
       DataSet ds_h = new DataSet();
       string sql_h = "select count(*) as holidays from tblacademiccalender where DATENAME(DW,dtdate) not in(select strweekholidays from tblworkingdays where intschoolid=2) and intschool='" + Session["SchoolID"] + "'  and month(dtdate)=" + smonth + " and year(dtdate)=" + ayear + "";
       ds_h = da_h.ExceuteSql(sql_h);
       if (ds_h.Tables[0].Rows.Count > 0)
       {
            festivaldays= int.Parse(ds_h.Tables[0].Rows[0]["holidays"].ToString()); 
       }
       for (int j = 0; j < ds1.Tables[2].Rows.Count; j++)
       {
           ds1.Tables[2].Rows[j]["Totalfestivalholidays"] = festivaldays;
           ds1.Tables[2].Rows[j]["Totalholidays"] = total;
           ds1.Tables[2].Rows[j]["TotalNoWorkingdays"] = finalcount - int.Parse(ds_h.Tables[0].Rows[0]["holidays"].ToString());
       }
      
   }
   protected void PrintSundays(int year, int month, DayOfWeek dayName)
   {
       string f = month_year.SelectedValue;
       string s = f.ToString();
       string[] split = s.Split(" - ".ToCharArray());
       month = DateTime.Parse("1." + split[0] + " 2008").Month;
       year = DateTime.Parse("1." + "05." + split[4]).Year;
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


    //--------------------------------------------------------------------------------------------------------------------
   protected void holidays1()
   {

       int smonth = ttmonth;
       int ayear = ttyear;
       int days = ttdays;
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string str = "select strweekholidays from dbo.tblworkingdays where intschoolid=" + Session["schoolID"].ToString() + " and strmode='Holiday'";
       ds = da.ExceuteSql(str);
       //string holiday = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
       //DayOfWeek illegal = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holiday);
       //PrintSundays1(ayear, smonth, illegal);
       //int holidayc = int.Parse(lblsunday.Text);
       int holidayc = 0;
       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
       {
           string holiday = ds.Tables[0].Rows[i]["strweekholidays"].ToString();
           DayOfWeek illegal = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holiday);
           PrintSundays(ayear, smonth, illegal);
           if (holidayc == 0)
               holidayc = int.Parse(lblsunday.Text);
           else
               holidayc = holidayc + int.Parse(lblsunday.Text);
       }
       //string str1 = "select strweekholidays from dbo.tblworkingdays where intschool=" + Session["schoolID"].ToString() + " and strmode='Halfday'";
       //ds = da.ExceuteSql(str1);
       //string holidayhalf = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
       //DayOfWeek illegalhalf = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayhalf);
       //PrintSundays1(ayear, smonth, illegalhalf);
       //int totalcount = int.Parse(lblsunday.Text);
       //int halfdayc = totalcount / 2;
       //int total = holidayc + halfdayc;
       int total = holidayc;

       int finalcount = days - total;
       int festivaldays = 0;
       DataAccess da_h = new DataAccess();
       DataSet ds_h = new DataSet();
       string sql_h = "select count(*) as holidays from tblacademiccalender where DATENAME(DW,dtdate) not in(select strweekholidays from tblworkingdays where intschoolid=2) and intschool='" + Session["SchoolID"] + "'  and month(dtdate)=" + smonth + " and year(dtdate)=" + ayear + "";
       ds_h = da_h.ExceuteSql(sql_h);
       if (ds_h.Tables[0].Rows.Count > 0)
       {
           festivaldays = int.Parse(ds_h.Tables[0].Rows[0]["holidays"].ToString());
       }
       string ttchangemonth = "";
       if (smonth < 9)
       {
           ttchangemonth = String.Format("{0:00}", smonth);
       }
       else
       {
           ttchangemonth = smonth.ToString();
       }
       int totalnoofworkingdays=finalcount-festivaldays;
       DataAccess dacount= new DataAccess();
       DataSet dscount = new DataSet();
       string strsqlcount = "select * from tbltempstudentattndCRreports where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "' and periodmonthandyear='" + ttyear + "-" + ttchangemonth + "-01 00:00:000' ";
       dscount = dacount.ExceuteSql(strsqlcount);
       if (dscount.Tables[0].Rows.Count > 0)
       {
           for (int j = 0; j < dscount.Tables[0].Rows.Count; j++)
           {
               DataAccess dacountup = new DataAccess();
               DataSet dscountup = new DataSet();
               string strsqlcountup = "update tbltempstudentattndCRreports set Totalfestivalholidays='" + festivaldays + "',Totalholidays='" + total + "',TotalNoWorkingdays='" + totalnoofworkingdays + "' where intschool='" + Session["SchoolID"] + "' and intuserlogedid='" + Session["UserID"] + "' and periodmonthandyear='" + ttyear + "-" + ttchangemonth + "-01 00:00:000' ";
               dscountup = dacountup.ExceuteSql(strsqlcountup);
           }
       }

   }
   protected void PrintSundays1(int year, int month, DayOfWeek dayName)
   {

       month = ttmonth;
       year = ttyear;
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
           if (i == ttdays)
           {
               break;
           }
           lblsunday.Text = count.ToString();
       }
   }
   
}
