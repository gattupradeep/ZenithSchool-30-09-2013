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

public partial class reports_Timetable_Report : System.Web.UI.Page
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
            fillstaff();
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
        string str ="";
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
        if (ddlstaff.SelectedIndex > 0)
            str = "select * from (select distinct b.intid as teachername,b.strfirstname +' '+b.strmiddlename+' '+b.strlastname as staffname,'' as strteacherid, a.strperiod,'' as strstarttime,'' as strendtime,c.strbranch as SchoolBranch, cast(replace(replace(replace(replace(replace(a.strperiod,' period',''),'th',''),'st',''),'nd',''),'rd','') as int) as intorder from tblschoolperiods a,tblemployee b,tblschooldetails c where a.intschoolid=" + Session["SchoolID"].ToString() + " and b.strtype='Teaching Staffs' and b.intschool=" + Session["SchoolID"] + " and b.intid=" + ddlstaff.SelectedValue + " and c.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ") and strperiod like '%Period') as a1 order by staffname,intorder";
        //str = "select distinct b.intid as teachername,b.strfirstname +' '+b.strmiddlename+' '+b.strlastname as staffname,'' as strteacherid, a.strperiod,'' as strstarttime,'' as strendtime,c.strbranch as SchoolBranch from tblschoolperiods a,tblemployee b,tblschooldetails c where a.intschoolid=" + Session["SchoolID"] + "and b.strtype='Teaching Staffs' and b.intschool=" + Session["SchoolID"] + " and b.intid=" + ddlstaff.SelectedValue + " and c.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")";
        else
            str = "select * from (select distinct b.intid as teachername,b.strfirstname +' '+b.strmiddlename+' '+b.strlastname as staffname,'' as strteacherid, a.strperiod,'' as strstarttime,'' as strendtime,c.strbranch as SchoolBranch, cast(replace(replace(replace(replace(replace(a.strperiod,' period',''),'th',''),'st',''),'nd',''),'rd','') as int) as intorder from tblschoolperiods a,tblemployee b,tblschooldetails c where a.intschoolid=" + Session["SchoolID"].ToString() + " and b.strtype='Teaching Staffs' and b.intschool=" + Session["SchoolID"].ToString() + " and c.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ") and strperiod like '%Period') as a1 order by staffname,intorder";
            //str = "select distinct b.intid as teachername,b.strfirstname +' '+b.strmiddlename+' '+b.strlastname as staffname,'' as strteacherid, a.strperiod,'' as strstarttime,'' as strendtime,c.strbranch as SchoolBranch from tblschoolperiods a,tblemployee b,tblschooldetails c where a.intschoolid=" + Session["SchoolID"] + "and b.strtype='Teaching Staffs' and b.intschool=" + Session["SchoolID"] + " and c.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")";
        DataSet1 rds = new DataSet1();
        rda = new SqlDataAdapter(str, conn);
        rda.Fill(rds, "tblstafftimetable");
        
        DataAccess logrda = new DataAccess();
        DataSet logrds = new DataSet(); string rsqlquery = string.Empty;
        if (Session["UserID"].ToString() != "0")
        {
            rsqlquery = "select strfirstname+' '+strmiddlename+' '+strlastname as logedinname from tblemployee where intID=" + Session["UserID"].ToString();
        }
        else
        {
            rsqlquery = "select 'Super Admin' as logedinname";
        } 
        logrds = logrda.ExceuteSql(rsqlquery);
        for (int x = 0; x < rds.tblstafftimetable.Rows.Count; x++)
        {
            rds.tblstafftimetable.Rows[x]["ReportGeneratedby"] = logrds.Tables[0].Rows[0]["logedinname"];
            rds.tblstafftimetable.Rows[x]["Reportsortby"] = ddlstaff.SelectedItem.Text + ", " + ddlclass.SelectedValue + ", " + ddldays.SelectedValue + ", " + ddlsubject.SelectedValue;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strmode"].ToString() != "Holiday")
                {
                    string[] strclass = ddlclass.SelectedValue.Split('-');
                    sql = "select a.*,strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tbltimetable a,tblschoolperiods b where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + rds.tblstafftimetable.Rows[x]["teachername"] + " and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and a.strperiod LIKE '%Period'  and b.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and b.intschoolid=" + Session["SchoolID"].ToString() + " ";
                    if (ddlclass.SelectedIndex > 0)
                    {
                        sql += " and strstandard +' - ' + strsection='" + ddlclass.SelectedValue + "' and b.strclass='" + strclass[0] +"- "+strclass[1].Trim()+"'";
                    }
                    if (ddldays.SelectedIndex > 0)
                    {
                        sql += " and strday='" + ddldays.SelectedValue + "'";
                    }
                    if (ddlsubject.SelectedIndex > 0)
                    {
                        sql += " and strsubject ='" + ddlsubject.SelectedValue + "'";
                    }
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(sql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0]["strsubject"].ToString().IndexOf("Second Language") > -1 || ds1.Tables[0].Rows[0]["strsubject"].ToString().IndexOf("Third Language") > -1)
                        {
                            sql = "select a.*,strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tbltimetable2 a,tblschoolperiods b where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + rds.tblstafftimetable.Rows[x]["teachername"] + " and strstandard1 + ' - ' + strsection1 ='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString() + "' and strday='" + ds1.Tables[0].Rows[0]["strday"].ToString() + "' and a.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and b.strperiod='" + rds.tblstafftimetable.Rows[x]["strperiod"] + "' and b.intschoolid=" + Session["SchoolID"].ToString() + " and b.strclass='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + "'";
                            da3 = new DataAccess();
                            ds3 = new DataSet();
                            ds3 = da3.ExceuteSql(sql);
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds3.Tables[0].Rows[0]["strlanguage"].ToString();
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = ds3.Tables[0].Rows[0]["strstandard1"].ToString() + " - " + ds3.Tables[0].Rows[0]["strsection1"].ToString();
                                rds.tblstafftimetable.Rows[x]["time" + i] = ds3.Tables[0].Rows[0]["strstartendtime"].ToString();
                            }
                            else
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = "";
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = "";
                            }
                        }
                        else if (ds1.Tables[0].Rows[0]["strsubject"].ToString().IndexOf("Extra Activities") > -1)
                        {
                            sql = "select a.*,strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tbltimetable3 a,tblschoolperiods b where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + rds.Tables["tblstafftimetable"].Rows[x]["teachername"].ToString() + " and strstandard + ' - ' + strsection ='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString() + "' and strday='" + ds1.Tables[0].Rows[0]["strday"].ToString() + "' and a.strperiod='" + ds1.Tables[0].Rows[0]["strperiod"].ToString() + "' and b.strperiod='" + ds1.Tables[0].Rows[0]["strperiod"].ToString() + "' and b.intschoolid=" + Session["SchoolID"].ToString() + " and b.strclass='" + ds1.Tables[0].Rows[0]["strstandard"].ToString() + "'";
                            da3 = new DataAccess();
                            ds3 = new DataSet();
                            ds3 = da3.ExceuteSql(sql);
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds3.Tables[0].Rows[0]["strlanguage"].ToString();
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = ds3.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds3.Tables[0].Rows[0]["strsection"].ToString();
                                rds.tblstafftimetable.Rows[x]["time" + i] = ds3.Tables[0].Rows[0]["strstartendtime"].ToString();
                            }
                            else
                            {
                                rds.tblstafftimetable.Rows[x]["strsubject" + i] = "";
                                rds.tblstafftimetable.Rows[x]["teachername" + i] = "";
                            }
                        }
                        else
                        {
                            rds.tblstafftimetable.Rows[x]["strsubject" + i] = ds1.Tables[0].Rows[0]["strsubject"].ToString();
                            rds.tblstafftimetable.Rows[x]["teachername" + i] = ds1.Tables[0].Rows[0]["strstandard"].ToString() + " - " + ds1.Tables[0].Rows[0]["strsection"].ToString();
                            rds.tblstafftimetable.Rows[x]["time" + i] = ds1.Tables[0].Rows[0]["strstartendtime"].ToString();
                        }                        
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
        reportfilepath = Server.MapPath("CR_Timetable/CR_Staff_timetable.rpt");
        ReportDocument staffrep = new ReportDocument();
        staffrep.Load(reportfilepath);
        staffrep.SetDataSource(rds);
        CrystalReportViewer1.ReportSource = staffrep;
        CrystalReportViewer1.DataBind();
    }
    protected void fillstaff()
    {
        try
        {
            strsql = "select intid,strfirstname +' ' + strmiddlename +' '+strlastname as teachername from tblemployee where intschool=" + Session["SchoolID"] + " and intid in(select strteacher from tbltimetable where intschool=" + Session["SchoolID"] + " union all select strteacher from tbltimetable2 where intschool=" + Session["SchoolID"] + " union all select strteacher from tbltimetable3 where intschool=" + Session["SchoolID"] + ")";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlstaff.DataSource = ds;
                ddlstaff.DataTextField = "teachername";
                ddlstaff.DataValueField = "intid";
                ddlstaff.Items.Clear();
                ddlstaff.DataBind();
                ListItem li = new ListItem("All Staff", "All Staff");
                ddlstaff.Items.Insert(0, li);
            }
        }
        catch { }
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
            if (ddlstaff.SelectedIndex > 0)
            {
                strsql += " and strteacher='" + ddlstaff.SelectedValue + "'";
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
            if (ddlstaff.SelectedIndex > 0)
            {
                strsql += " and strteacher='" + ddlstaff.SelectedValue + "'";
            }
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
            if (ddlstaff.SelectedIndex > 0)
            {
                strsql += " and strteacher='" + ddlstaff.SelectedValue + "'";
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
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldays();
        fillclass();
        fillsubject();
        fillreport();
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
