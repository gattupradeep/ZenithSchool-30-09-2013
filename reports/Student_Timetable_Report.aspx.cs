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


public partial class reports_Student_Timetable_Report : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet ds, ds1, ds2, ds3, ds4;
    public DataAccess da, da1, da2, da3, da4;
    public DataSet1 rds;
    public SqlDataAdapter rda;
    public string strsql;
    public string reportfilepath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldays();
            fillclass();
            fillsubject();
            fillreport();
        }
        else
        {
            fillreport();
        }
    }
    protected void fillreport()
    {
        da = new DataAccess();
        ds = new DataSet();
        string sql = "";
        string str = "";
        sql = "select * from (";
        sql = sql + " select * from (select 'Monday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 2 as intday  from ";
        sql = sql + " tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Tuesday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 3 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Wednesday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 4 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Thursday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 5 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Friday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 6 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Saturday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 7 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Sunday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 1 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString() + ") as a";
        sql = sql + " where strweekholidays not in (select strweekholidays from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + ")";
        sql = sql + " union all select strweekholidays,strmode,strhstarttime,strhendtime,intday from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + ") as b order by intday";
        ds = da.ExceuteSql(sql);
        DataSet1 rds = new DataSet1();
        if (ddlclass.SelectedIndex > 0)
        {
            string[] strclass = ddlclass.SelectedValue.Split('-');
            str = "select a.intorder, b.strstandard + ' - ' + b.strsection as teachername,a.strperiod,a.strSTHH + ':' + a.strSTMM as strstarttime,a.strETHH + ':' + a.strETMM as strendtime,c.strbranch as SchoolBranch,b.strstandard from tblschoolperiods a,tbltimetable b,tblschooldetails c where a.intschoolid=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and c.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")" + " and b.strstandard + ' - ' + b.strsection ='" + ddlclass.SelectedValue + "' and a.strclass='"+strclass[0]+"-"+strclass[1]+"' group by b.strstandard + ' - ' + b.strsection, a.strperiod,a.strSTHH + ':' + a.strSTMM,a.strETHH + ':' + a.strETMM,c.strbranch,a.intorder,b.strstandard order by a.intorder";
            rda = new SqlDataAdapter(str, conn);
            rda.Fill(rds, "tblstafftimetable");
        }
        else
        {
            str = "select m.*,n.intorder from (select distinct * from (select b.strstandard + ' - ' + b.strsection as teachername,a.strperiod,'' as strstarttime,'' as strendtime,c.strbranch as SchoolBranch,b.strstandard from tblschoolperiods a,tbltimetable b,tblschooldetails c where a.intschoolid=" + Session["SchoolID"] + " and b.intschool=" + Session["SchoolID"] + " and c.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")" + " group by b.strstandard + ' - ' + b.strsection, a.strperiod,a.strSTHH + ':' + a.strSTMM,a.strETHH + ':' + a.strETMM,c.strbranch,a.intorder,b.strstandard ) as main) as m,tblschoolperiods n where m.strstandard=n.strclass and m.strperiod=n.strperiod order by intorder";
            rda = new SqlDataAdapter(str, conn);
            rda.Fill(rds, "tblstafftimetable");
            for (int y = 0; y < rds.tblstafftimetable.Rows.Count; y++)
            {
                DataAccess dane = new DataAccess();
                DataSet dsne = new DataSet();
                sql = "select strSTHH + ':' + strSTMM +' - '+strETHH + ':' + strETMM as strendtime from tblschoolperiods where strclass ='" + rds.tblstafftimetable.Rows[y]["strstandard"] + "' and strperiod='" + rds.tblstafftimetable.Rows[y]["strperiod"] + "'";
                dsne = dane.ExceuteSql(sql);
                if (dsne.Tables[0].Rows.Count > 0)
                {
                    rds.Tables["tblstafftimetable"].Rows[y]["strendtime"] = dsne.Tables[0].Rows[0][0].ToString();
                }
            }

        }
        DataAccess logrda = new DataAccess();
        DataSet logrds = new DataSet();
        string rsqlquery = string.Empty;
        if (Session["UserID"].ToString() != "0")
        {
            rsqlquery = "select strfirstname+' '+strmiddlename+' '+strlastname as logedinname from tblemployee where intID='" + Session["UserID"] + "' ";
        }
        else
        {
            rsqlquery = "select 'Super Admin' as logedinname";
        }
        logrds = logrda.ExceuteSql(rsqlquery);
        for (int x = 0; x < rds.tblstafftimetable.Rows.Count; x++)
        {
            rds.tblstafftimetable.Rows[x]["ReportGeneratedby"] = logrds.Tables[0].Rows[0]["logedinname"];
            rds.tblstafftimetable.Rows[x]["Reportsortby"] = ddlclass.SelectedValue + ", " + ddldays.SelectedValue + ", " + ddlsubject.SelectedValue;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() != "Holiday")
                {
                    //sql = "select a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as empname from tbltimetable a,tblemployee b where a.intschool=" + Session["SchoolID"].ToString() + " and b.intID=a.strteacher and a.strstandard + ' - ' + a.strsection='" + rds.tblstafftimetable.Rows[x]["teachername"] + "' and a.strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and a.strperiod LIKE '%Period'";
                    sql = "select a.*,empname,c.strSTHH + ':' + c.strSTMM +' - '+c.strETHH + ':' + c.strETMM as strendtime from tbltimetable a, (select intid,strfirstname +' ' + strmiddlename +' '+strlastname as empname,intschool from tblemployee  where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'Not Assigned' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b,tblschoolperiods c  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard + ' - ' + a.strsection ='" + rds.tblstafftimetable.Rows[x]["teachername"] + "' and a.strteacher=b.intid and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and a.strperiod LIKE '%Period' and c.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and strclass='" + rds.tblstafftimetable.Rows[x]["strstandard"] + "'";
                    if (ddldays.SelectedIndex > 0)
                    {
                        sql += " and strday='" + ddldays.SelectedValue + "'";
                        if(ddldays.SelectedValue=="Monday")
                        {
                            i = 1;
                        }
                        else if (ddldays.SelectedValue == "Tuesday")
                        {
                            i = 2;
                        }
                        else if (ddldays.SelectedValue == "Wednesday")
                        {
                            i = 3;
                        }
                        else if (ddldays.SelectedValue == "Thursday")
                        {
                            i = 4;
                        }
                        else if (ddldays.SelectedValue == "Friday")
                        {
                            i = 5;
                        }
                        else if (ddldays.SelectedValue == "Saturday")
                        {
                            i = 6;
                        }
                        else if (ddldays.SelectedValue == "Sunday")
                        {
                            i = 7;
                        }
                    }
                    else
                    {
                        sql += " and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "'";
                    }
                    if (ddlsubject.SelectedIndex > 0)
                    {
                        sql += " and strsubject ='" + ddlsubject.SelectedValue + "'";
                    }
                    sql += "  order by a.intid";
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(sql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0]["strsubject"].ToString().IndexOf("Second Language") > -1 || ds1.Tables[0].Rows[0]["strsubject"].ToString().IndexOf("Third Language") > -1)
                        {
                            //sql = "select a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as empname from tbltimetable2 a,tblemployee b where a.intschool=" + Session["SchoolID"].ToString() + " and b.intID=a.strteacher and a.strstandard1 + ' - ' + a.strsection1 ='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString() + "' and a.strday='" + ds1.Tables[0].Rows[0]["strday"].ToString() + "' and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "'";
                            sql = "select a.*,empname,c.strSTHH + ':' + c.strSTMM +' - '+c.strETHH + ':' + c.strETMM as strendtime from tbltimetable2 a, (select intid,strfirstname +' ' + strmiddlename +' '+strlastname as empname,intschool from tblemployee  where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'Not Assigned' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b,tblschoolperiods c  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard1 + ' - ' + a.strsection1 ='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString() + "' and a.strteacher=b.intid and strday='" + ds1.Tables[0].Rows[0]["strday"].ToString() + "' and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and a.strperiod LIKE '%Period'  and c.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and strclass='" + rds.tblstafftimetable.Rows[x]["strstandard"] + "' order by a.intid";
                            da3 = new DataAccess();
                            ds3 = new DataSet();
                            ds3 = da3.ExceuteSql(sql);
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds3.Tables[0].Rows[0]["strlanguage"].ToString();
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = ds3.Tables[0].Rows[0]["empname"].ToString();
                            }
                            else
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds1.Tables[0].Rows[0]["strsubject"].ToString();
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = ds1.Tables[0].Rows[0]["empname"].ToString();
                            }
                        }
                        else if (ds1.Tables[0].Rows[0]["strsubject"].ToString().IndexOf("Extra Activities") > -1)
                        {
                            //sql = "select a.*,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as empname from tbltimetable3 a,tblemployee b where a.intschool=" + Session["SchoolID"].ToString() + " and b.intID=a.strteacher and a.strteacher='" + rds.Tables["tblstafftimetable"].Rows[x]["teachername"].ToString() + "' and a.strstandard + ' - ' + a.strsection ='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString() + "' and a.strday='" + ds1.Tables[0].Rows[0]["strday"].ToString() + "' and a.strperiod='" + ds1.Tables[0].Rows[0]["strperiod"].ToString() + "'";
                            sql = "select a.*,empname,c.strSTHH + ':' + c.strSTMM +' - '+c.strETHH + ':' + c.strETMM as strendtime from tbltimetable3 a, (select intid,strfirstname +' ' + strmiddlename +' '+strlastname as empname,intschool from tblemployee  where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'Not Assigned' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b,tblschoolperiods c  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard + ' - ' + a.strsection ='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString() + "' and a.strteacher=b.intid and strday='" + ds1.Tables[0].Rows[0]["strday"].ToString() + "' and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and a.strperiod LIKE '%Period' and c.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and strclass='" + rds.tblstafftimetable.Rows[x]["strstandard"] + "' order by a.intid";
                            da3 = new DataAccess();
                            ds3 = new DataSet();
                            ds3 = da3.ExceuteSql(sql);
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds3.Tables[0].Rows[0]["strlanguage"].ToString();
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = ds3.Tables[0].Rows[0]["empname"].ToString();
                            }
                            else
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds1.Tables[0].Rows[0]["strsubject"].ToString();
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = ds1.Tables[0].Rows[0]["empname"].ToString();
                            }
                        }
                        else
                        {
                            rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds1.Tables[0].Rows[0]["strsubject"].ToString();
                            rds.tblstafftimetable.Rows[x]["teachername" + i] = ds1.Tables[0].Rows[0]["empname"].ToString();
                            rds.tblstafftimetable.Rows[x]["strendtime"] = ds1.Tables[0].Rows[0]["strendtime"].ToString();
                        }                        
                    }
                    if (ddldays.SelectedIndex > 0)
                    {
                        break;
                    }
                }
            }
        }
        //to delete empty rows in the reports
        for (int z = 0; z < rds.tblstafftimetable.Rows.Count; z++)
        {
            if (rds.tblstafftimetable.Rows[z]["strsubject1"].ToString() == "" && rds.tblstafftimetable.Rows[z]["strsubject2"].ToString() == "" && rds.tblstafftimetable.Rows[z]["strsubject3"].ToString() == "" && rds.tblstafftimetable.Rows[z]["strsubject4"].ToString() == "" && rds.tblstafftimetable.Rows[z]["strsubject5"].ToString() == "" && rds.tblstafftimetable.Rows[z]["strsubject6"].ToString() == "" && rds.tblstafftimetable.Rows[z]["strsubject7"].ToString() == "")
            {
                rds.tblstafftimetable.Rows[z].Delete();
            }
        }
        reportfilepath = Server.MapPath("CR_Timetable/CR_Student_timetable.rpt");
        ReportDocument staffrep = new ReportDocument();
        staffrep.Load(reportfilepath);
        staffrep.SetDataSource(rds);
        CrystalReportViewer1.ReportSource = staffrep;
        CrystalReportViewer1.DataBind();
    }
    protected void filldays()
    {
        try
        {
            strsql = "select strday from tbltimetable where intschool=" + Session["SchoolID"];
            if (ddlclass.SelectedIndex > 0)
            {
                strsql += " and strstandard + ' - ' + strsection='" + ddlclass.SelectedValue + "'";
            }
            strsql += " group by strday";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddldays.DataSource = ds;
                ddldays.DataTextField = "strday";
                ddldays.DataValueField = "strday";
                ddldays.Items.Clear();
                ddldays.DataBind();
                ListItem li = new ListItem("All Days", "All Days");
                ddldays.Items.Insert(0, li);
            }
        }
        catch
        {
        }
    }
    protected void fillclass()
    {
        try
        {
            strsql = "select strstandard + ' - ' + strsection as class from tbltimetable where intschool=" + Session["SchoolID"];
            if (ddldays.SelectedIndex > 0)
            {
                strsql += " and strday='" + ddldays.SelectedValue + "'";
            }
            strsql += "  group by strstandard + ' - ' +strsection";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlclass.DataSource = ds;
                ddlclass.DataTextField = "class";
                ddlclass.DataValueField = "class";
                ddlclass.Items.Clear();
                ddlclass.DataBind();
                ListItem li = new ListItem("All Class", "All Class");
                ddlclass.Items.Insert(0, li);
            }
        }
        catch { }
    }
    protected void fillsubject()
    {
        try
        {
            strsql = "select strsubject from tbltimetable where intschool = " + Session["SchoolID"];
            if (ddlclass.SelectedIndex > 0)
            {
                strsql += " and strstandard + ' - ' + strsection='" + ddlclass.SelectedValue + "'";
            }
            strsql += " group by strsubject";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsubject.DataSource = ds;
                ddlsubject.DataTextField = "strsubject";
                ddlsubject.DataValueField = "strsubject";
                ddlsubject.Items.Clear();
                ddlsubject.DataBind();
                ListItem li = new ListItem("All Subject", "All Subject");
                ddlsubject.Items.Insert(0, li);
            }
        }
        catch { }
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        fillreport();
    }
    protected void ddldays_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillclass();
        fillreport();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillreport();
    }
}
