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

public partial class timetable_viewalltimetable : System.Web.UI.Page
{
    public string str;
    public DataSet ds, ds1,ds2,ds3,ds4;
    public DataAccess da, da1,da2,da3,da4;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PatronType"] != null && Session["UserID"] != null)
            {
                if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
                {
                    trgrid.Visible = false;
                    Session["EditTT"] = "View";
                    fillclasstype();
                    fillsection();
                    fillstaff();
                    lblmode.Text = "Student Timetable View";
                    fillforstudents();
                }
                else
                {
                    if (Session["PatronType"].ToString() == "Teaching Staffs")
                    {
                        trsidemenu.Visible = false;
                    }
                    if (Request["m"] != null)
                        lblmode.Text = Request["m"].ToString();

                    trgrid.Visible = false;
                    Session["EditTT"] = "View";
                    fillclasstype();
                    fillstaff();
                    lblmode.Text = "Staff Timetable View";
                }
            }
        }
    }

    protected void fillforstudents()
    {
        da = new DataAccess();
        str = "select strstandard,strsection from tblstudent where intid=" + Session["UserID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rbtnstaff.Checked = false;
            rbtstudent.Checked = true;
            ddlclass.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
            ddlsection.SelectedValue = ds.Tables[0].Rows[0]["strsection"].ToString();
            lblmode.Text = ds.Tables[0].Rows[0]["strstandard"].ToString() +" "+ds.Tables[0].Rows[0]["strsection"].ToString();
            Session["EditTT"] = "View";
            fillperiods();
            fillworkingdays();
            trgrid.Visible = true;
            trfilter.Visible = false;
        }
        else
            trgrid.Visible = false;
    }

    protected void fillclasstype()
    {
        try
        {
            str = "select strstandard from tbltimetable where intschool=" + Session["SchoolID"] + " group by strstandard";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlclass.DataSource = ds;
                ddlclass.DataTextField = "strstandard";
                ddlclass.DataValueField = "strstandard";
                ddlclass.DataBind();
                //ddlclass.Items.Insert(0, "Select");
                if (rbtnstaff.Checked)
                {
                    ListItem li = new ListItem("ALL", "0");
                    ddlclass.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("Select Class", "0");
                    ddlclass.Items.Insert(0, li);
                }
            }
        }
        catch { }
    }
    protected void fillsection()
    {
        try
        {
            str = "select strsection from tbltimetable where intschool=" + Session["SchoolID"] + " group by strsection";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsection.DataSource = ds;
                ddlsection.DataTextField = "strsection";
                ddlsection.DataValueField = "strsection";
                ddlsection.DataBind();
                
            }
        }
        catch { }
    }

    protected void fillstaff()
    {
        try
        {
            str = "select intid,strfirstname +' ' + strmiddlename  as teachername from tblemployee where intschool=" + Session["SchoolID"] + " and intid in(select strteacher from tbltimetable where intschool=" + Session["SchoolID"] + " union all select strteacher from tbltimetable2 where intschool=" + Session["SchoolID"] + " union all select strteacher from tbltimetable3 where intschool=" + Session["SchoolID"] + ")";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlstaff.DataSource = ds;
                ddlstaff.DataTextField = "teachername";
                ddlstaff.DataValueField = "intid";
                ddlstaff.DataBind();
                ListItem li = new ListItem("Select Staff", "0");
                ddlstaff.Items.Insert(0, li);
                trstaff.Visible = true;
             }
            else
            {
                trstaff.Visible = false;
            }
        }
        catch { }
    }

    protected void fillperiods()
    {

        if (rbtnstaff.Checked)
        {
            if (ddlclass.SelectedIndex > 0)
            {
                try
                {
                    DataAccess da = new DataAccess();

                    str = "select * from (select strperiod,cast(replace(replace(replace(replace(substring(strperiod,1,2),'s',''),'n',''),'r',''),'t','') as int) as intorder from tblschoolperiods where intschoolid=" + Session["Schoolid"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' and strperiod like '%Period' group by strperiod) as a order by intorder";
                    ds = new DataSet();
                    ds = da.ExceuteSql(str);
                    dgtimetable.DataSource = ds;
                    dgtimetable.DataBind();
                }
                catch { }
            }
            else
            {
                try
                {
                    DataAccess da = new DataAccess();
                    str = "select * from (select strperiod,cast(replace(replace(replace(replace(substring(strperiod,1,2),'s',''),'n',''),'r',''),'t','') as int) as intorder from tblschoolperiods where intschoolid=" + Session["Schoolid"].ToString() + " and strperiod like '%Period' group by strperiod) as a order by intorder";
                    ds = new DataSet();
                    ds = da.ExceuteSql(str);
                    dgtimetable.DataSource = ds;
                    dgtimetable.DataBind();
                }
                catch { }
            }
        }
        else
        {
            DataAccess da = new DataAccess();
            str = "select strperiod,intorder from tblschoolperiods where intschoolid=" + Session["Schoolid"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' group by strperiod,intorder order by intorder";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            dgtimetable.DataSource = ds;
            dgtimetable.DataBind();

        }
    }

    protected void fillworkingdays()
    {
        da = new DataAccess();
        ds = new DataSet();
        string sql = "";
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
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["strmode"].ToString() != "Holiday")
            {
                if (rbtnstaff.Checked)
                {
                    Session["EditTT"] = "New";


                    if (ddlclass.SelectedIndex > 0)
                        sql = "select *,'' as strsubject,'Leisure' as teachername,0 as strteacher,'' as strclass from (select strperiod,cast(replace(replace(replace(replace(substring(strperiod,1,2),'s',''),'n',''),'r',''),'t','') as int) as intorder from tblschoolperiods where intschoolid=2 and strclass='"+ddlclass.SelectedValue+"' and strperiod like '%Period' group by strperiod) as a order by intorder";
                    else
                    {
                        sql = "select *,'' as strsubject,'None' as teachername,0 as strteacher,'' as strclass from (select strperiod,cast(replace(replace(replace(replace(substring(strperiod,1,2),'s',''),'n',''),'r',''),'t','') as int) as intorder from tblschoolperiods where intschoolid=2 and strperiod like '%Period' group by strperiod) as a order by intorder";
                    }
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(sql);
                  

                    if (ddlclass.SelectedIndex > 0)
                    {
                        sql = "select * from (select a.*,teachername from tbltimetable a, ";
                        sql = sql + "(select intid,strfirstname +' ' + strmiddlename  as teachername,intschool ";
                        sql = sql + "from tblemployee  where strtype='Teaching Staffs' ";
                        sql = sql + "union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool ";
                        sql = sql + "union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b  ";
                        sql = sql + "where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strsubject not like '%Language'  and strsubject != 'Language' and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' ";
                        sql = sql + "and a.strteacher=" + ddlstaff.SelectedValue + " ";
                        sql = sql + "union all ";
                        sql = sql + "select a.intid,a.strstandard1 as strstandard,a.strsection1 as strsection,strday,strperiod,";
                        sql = sql + "a.strlanguage as strsubject,'' as strlanguage,a.strteacher,a.intschool,teachername from tbltimetable2 a, ";
                        sql = sql + "(select intid,strfirstname +' ' + strmiddlename  as teachername,intschool ";
                        sql = sql + "from tblemployee  where strtype='Teaching Staffs' ";
                        sql = sql + ") as b  ";
                        sql = sql + "where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' ";
                        sql = sql + "and a.strteacher=" + ddlstaff.SelectedValue + " ";
                        sql = sql + "union all ";
                        sql = sql + "select a.intid,a.strstandard,a.strsection,strday,strperiod,";
                        sql = sql + "a.strlanguage as strsubject,'' as strlanguage,a.strteacher,a.intschool,teachername from tbltimetable3 a, ";
                        sql = sql + "(select intid,strfirstname +' ' + strmiddlename  as teachername,intschool ";
                        sql = sql + "from tblemployee  where strtype='Teaching Staffs' ";
                        sql = sql + ") as b  ";
                        sql = sql + "where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' ";
                        sql = sql + "and a.strteacher=" + ddlstaff.SelectedValue + ") as a1 where strstandard='" + ddlclass.SelectedValue + "' and strsection='"+ddlsection.SelectedValue+"'";
                    }
                    else
                    {
                        sql = "select * from (select a.*,teachername from tbltimetable a, ";
                        sql = sql + " (select intid,strfirstname +' ' + strmiddlename  as teachername,intschool ";
                        sql = sql + " from tblemployee  where strtype='Teaching Staffs' ";
                        sql = sql + " union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool ";
                        sql = sql + " union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b  ";
                        sql = sql + " where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strsubject not like '%Language'  and strsubject != 'Language' and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' ";
                        sql = sql + " and a.strteacher=" + ddlstaff.SelectedValue + " ";
                        sql = sql + " union all ";
                        sql = sql + " select a.intid,a.strstandard1 as strstandard,a.strsection1 as strsection,strday,strperiod,";
                        sql = sql + " a.strlanguage as strsubject,'' as strlanguage,a.strteacher,a.intschool,teachername from tbltimetable2 a, ";
                        sql = sql + " (select intid,strfirstname +' ' + strmiddlename as teachername,intschool ";
                        sql = sql + " from tblemployee  where strtype='Teaching Staffs' ";
                        sql = sql + " ) as b  ";
                        sql = sql + " where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' ";
                        sql = sql + " and a.strteacher=" + ddlstaff.SelectedValue + " ";
                        sql = sql + " union all ";
                        sql = sql + " select a.intid,a.strstandard,a.strsection,strday,strperiod,";
                        sql = sql + " a.strlanguage as strsubject,'' as strlanguage,a.strteacher,a.intschool,teachername from tbltimetable3 a, ";
                        sql = sql + " (select intid,strfirstname +' ' + strmiddlename as teachername,intschool ";
                        sql = sql + " from tblemployee  where strtype='Teaching Staffs' ";
                        sql = sql + " ) as b";
                        sql = sql + " where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' ";
                        sql = sql + " and a.strteacher=" + ddlstaff.SelectedValue + ") as a1";
                    }
                    da2 = new DataAccess();
                    ds2 = new DataSet();
                    ds2 = da2.ExceuteSql(sql);
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        for (int j1 = 0; j1 < ds2.Tables[0].Rows.Count; j1++)
                        {
                            if (ds1.Tables[0].Rows[j]["strperiod"].ToString() == ds2.Tables[0].Rows[j1]["strperiod"].ToString())
                            {
                                if (ds2.Tables[0].Rows[j1]["strsubject"].ToString().IndexOf("Second Language") > -1 || ds2.Tables[0].Rows[j1]["strsubject"].ToString().IndexOf("Third Language") > -1)
                                {
                                    sql = "select * from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + ddlstaff.SelectedValue + " and strstandard1 + ' - ' + strsection1 ='" + ds2.Tables[0].Rows[j1]["strstandard"].ToString() + " - " + ds2.Tables[0].Rows[j1]["strsection"].ToString() + "' and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' and strperiod='" + ds2.Tables[0].Rows[j1]["strperiod"].ToString() + "'";
                                    da3 = new DataAccess();
                                    ds3 = new DataSet();
                                    ds3 = da3.ExceuteSql(sql);
                                    if (ds3.Tables[0].Rows.Count > 0)
                                        ds1.Tables[0].Rows[j]["strsubject"] = ds3.Tables[0].Rows[0]["strlanguage"].ToString();
                                    else
                                    {
                                        ds1.Tables[0].Rows[j]["strsubject"] = ds2.Tables[0].Rows[j1]["strsubject"].ToString();
                                    }
                                }
                                else if (ds2.Tables[0].Rows[j1]["strsubject"].ToString().IndexOf("Extra Activities") > -1)
                                {
                                    sql = "select * from tbltimetable3 where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + ddlstaff.SelectedValue + " and strstandard + ' - ' + strsection ='" + ds2.Tables[0].Rows[j1]["strstandard"].ToString() + " - " + ds2.Tables[0].Rows[j1]["strsection"].ToString() + "' and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' and strperiod='" + ds2.Tables[0].Rows[j1]["strperiod"].ToString() + "'";
                                    da3 = new DataAccess();
                                    ds3 = new DataSet();
                                    ds3 = da3.ExceuteSql(sql);
                                    if (ds3.Tables[0].Rows.Count > 0)
                                        ds1.Tables[0].Rows[j]["strsubject"] = ds3.Tables[0].Rows[0]["strlanguage"].ToString();
                                    else
                                    {
                                        ds1.Tables[0].Rows[j]["strsubject"] = ds2.Tables[0].Rows[j1]["strsubject"].ToString();
                                    }
                                }
                                else
                                {
                                    ds1.Tables[0].Rows[j]["strsubject"] = ds2.Tables[0].Rows[j1]["strsubject"].ToString();
                                }
                                ds1.Tables[0].Rows[j]["teachername"] = ds2.Tables[0].Rows[j1]["strstandard"].ToString() + " - " + ds2.Tables[0].Rows[j1]["strsection"].ToString();
                                ds1.Tables[0].Rows[j]["strclass"] = ds2.Tables[0].Rows[j1]["strstandard"].ToString();
                            }
                        }
                    }

                    if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Sunday")
                    {
                        dlsunday.DataSource = ds1;
                        dlsunday.DataBind();
                    }
                    else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Monday")
                    {
                        dlmonday.DataSource = ds1;
                        dlmonday.DataBind();
                    }
                    else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Tuesday")
                    {
                        dltuesday.DataSource = ds1;
                        dltuesday.DataBind();
                    }
                    else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Wednesday")
                    {
                        dlwednesday.DataSource = ds1;
                        dlwednesday.DataBind();
                    }
                    else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Thursday")
                    {
                        dlthursday.DataSource = ds1;
                        dlthursday.DataBind();
                    }
                    else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Friday")
                    {
                        dlfriday.DataSource = ds1;
                        dlfriday.DataBind();
                    }
                    else
                    {
                        dlsaturday.DataSource = ds1;
                        dlsaturday.DataBind();
                    }
                }
                else
                {
                    sql = "select a.*,teachername,strstandard as strclass from tbltimetable a, (select intid,strfirstname +' ' + strmiddlename as teachername,intschool from tblemployee  where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard ='" + ddlclass.SelectedValue + "' and a.strsection='" + ddlsection.SelectedValue + "' and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' order by a.intid";
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(sql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Sunday")
                        {
                            dlsunday.DataSource = ds1;
                            dlsunday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Monday")
                        {
                            dlmonday.DataSource = ds1;
                            dlmonday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Tuesday")
                        {
                            dltuesday.DataSource = ds1;
                            dltuesday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Wednesday")
                        {
                            dlwednesday.DataSource = ds1;
                            dlwednesday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Thursday")
                        {
                            dlthursday.DataSource = ds1;
                            dlthursday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Friday")
                        {
                            dlfriday.DataSource = ds1;
                            dlfriday.DataBind();
                        }
                        else
                        {
                            dlsaturday.DataSource = ds1;
                            dlsaturday.DataBind();
                        }
                    }
                    else
                    {
                        Session["EditTT"] = "New";
                        sql = "select strperiod,'' as strsubject,'' as teachername,0 as strteacher, strclass  from tblschoolperiods where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' order by intorder";
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(sql);
                        if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Sunday")
                        {
                            dlsunday.DataSource = ds1;
                            dlsunday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Monday")
                        {
                            dlmonday.DataSource = ds1;
                            dlmonday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Tuesday")
                        {
                            dltuesday.DataSource = ds1;
                            dltuesday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Wednesday")
                        {
                            dlwednesday.DataSource = ds1;
                            dlwednesday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Thursday")
                        {
                            dlthursday.DataSource = ds1;
                            dlthursday.DataBind();
                        }
                        else if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Friday")
                        {
                            dlfriday.DataSource = ds1;
                            dlfriday.DataBind();
                        }
                        else
                        {
                            dlsaturday.DataSource = ds1;
                            dlsaturday.DataBind();
                        }
                    }
                }
            }
            else
            {
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Sunday")
                    tdsunday.Visible = false;
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Monday")
                    tdmonday.Visible = false;
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Tuesday")
                    tdtuesday.Visible = false;
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Wednesday")
                    tdwednesday.Visible = false;
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Thursday")
                    tdthursday.Visible = false;
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Friday")
                    tdfriday.Visible = false;
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Saturday")
                    tdsaturday.Visible = false;
            }
        }
    }
        
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtstudent.Checked)
        {
            if (ddlclass.SelectedIndex > 0)
            {
                Session["EditTT"] = "View";
                fillsection();
                fillperiods();
                fillworkingdays();
                
                trgrid.Visible = true;
                if (rbtnstaff.Checked)
                    lblmode.Text = "Staff Timetable View - " + ddlclass.SelectedItem.Text;
                else
                    lblmode.Text = "Student Timetable View - " + ddlclass.SelectedItem.Text;
            }
            else
                trgrid.Visible = false;
        }
        else
        {
            lblmonnoofdays.Text = "0";
            lblsatnoofdays.Text = "0";
            lblsunnoofdays.Text = "0";
            lblthunoofdays.Text = "0";
            lbltuenoofdays.Text = "0";
            lblwednoofdays.Text = "0";
            lblfrinoofdays.Text = "0";
            Session["EditTT"] = "View";
            fillsection();
            fillperiods();
            fillworkingdays();
            
            trgrid.Visible = true; trtotaldays.Visible = true;

        }
    }

    protected void dlmonday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lblmonsub");
            Label lbltech = (Label)e.Item.FindControl("lblmontech");
            Label lblbreak = (Label)e.Item.FindControl("lblmonbreak");
            Label lblstart = (Label)e.Item.FindControl("lblmonstarttime");
            Label lblend = (Label)e.Item.FindControl("lblmonendtime");
            Label lblmonperiod = (Label)e.Item.FindControl("lblmonperiod");
            Label lblmonclass = (Label)e.Item.FindControl("lblmonclass");
            lblbreak.Visible = false;
            try
            {
                da4 = new DataAccess();

                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblmonperiod.Text + "' and strclass='" + lblmonclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                   // lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }

            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblend.Visible = true;
                lblstart.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 ='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lblmonnoofdays.Text = (int.Parse(lblmonnoofdays.Text) + 1).ToString();
            }
        }
        catch { }
    }

    protected void dltuesday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lbltuesub");
            Label lbltech = (Label)e.Item.FindControl("lbltuetech");
            Label lblbreak = (Label)e.Item.FindControl("lbltuebreak");
            Label lblstart = (Label)e.Item.FindControl("lbltuestarttime");
            Label lblend = (Label)e.Item.FindControl("lbltueendtime");
            Label lbltueperiod = (Label)e.Item.FindControl("lbltueperiod");
            Label lbltueclass = (Label)e.Item.FindControl("lbltueclass");
            lblbreak.Visible = false;
            try
            {
                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lbltueperiod.Text + "' and strclass='" + lbltueclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                   // lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblend.Visible = true;
                lblstart.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 ='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lbltuenoofdays.Text = (int.Parse(lbltuenoofdays.Text) + 1).ToString();
            }
        }
        catch { }

    }

    protected void dlwednesday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lblwedsub");
            Label lbltech = (Label)e.Item.FindControl("lblwedtech");
            Label lblbreak = (Label)e.Item.FindControl("lblwedbreak");
            Label lblstart = (Label)e.Item.FindControl("lblwedstarttime");
            Label lblend = (Label)e.Item.FindControl("lblwedendtime");
            Label lblwedperiod = (Label)e.Item.FindControl("lblwedperiod");
            Label lblwedclass = (Label)e.Item.FindControl("lblwedclass");
            lblbreak.Visible = false;
            try
            {
                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblwedperiod.Text + "' and strclass='" + lblwedclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                    //lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblend.Visible = true;
                lblstart.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 ='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lblwednoofdays.Text = (int.Parse(lblwednoofdays.Text) + 1).ToString();
            }
        }
        catch { }

    }

    protected void dlthursday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lblthusub");
            Label lbltech = (Label)e.Item.FindControl("lblthutech");
            Label lblbreak = (Label)e.Item.FindControl("lblthubreak");
            Label lblstart = (Label)e.Item.FindControl("lblthustarttime");
            Label lblend = (Label)e.Item.FindControl("lblthuendtime");
            Label lblthuperiod = (Label)e.Item.FindControl("lblthuperiod");
            Label lblthuclass = (Label)e.Item.FindControl("lblthuclass");
            lblbreak.Visible = false;
            try
            {
                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblthuperiod.Text + "' and strclass='" + lblthuclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                    // lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblend.Visible = true;
                lblstart.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage from tbltimetable2 where strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage from tbltimetable3 where strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 ='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lblthunoofdays.Text = (int.Parse(lblthunoofdays.Text) + 1).ToString();
            }
        }
        catch { }

    }

    protected void dlfriday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lblfrisub");
            Label lbltech = (Label)e.Item.FindControl("lblfritech");
            Label lblbreak = (Label)e.Item.FindControl("lblfribreak");
            Label lblstart = (Label)e.Item.FindControl("lblfristarttime");
            Label lblend = (Label)e.Item.FindControl("lblfriendtime");
            Label lblfriperiod = (Label)e.Item.FindControl("lblfriperiod");
            Label lblfriclass = (Label)e.Item.FindControl("lblfriclass");
            lblbreak.Visible = false;
            try
            {
                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblfriperiod.Text + "' and strclass='" + lblfriclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                    // lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblend.Visible = true;
                lblstart.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage from tbltimetable2 where strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and  strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage from tbltimetable3 where strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename  as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lblfrinoofdays.Text = (int.Parse(lblfrinoofdays.Text) + 1).ToString();
            }
        }
        catch { }

    }
    protected void dlsaturday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lblsatsub");
            Label lbltech = (Label)e.Item.FindControl("lblsattech");
            Label lblbreak = (Label)e.Item.FindControl("lblsatbreak");
            Label lblstart = (Label)e.Item.FindControl("lblsatstarttime");
            Label lblend = (Label)e.Item.FindControl("lblsatendtime");
            Label lblsatperiod = (Label)e.Item.FindControl("lblsatperiod");
            Label lblsatclass = (Label)e.Item.FindControl("lblsatclass");
            lblbreak.Visible = false;
            try
            {
                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblsatperiod.Text + "' and strclass='" + lblsatclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                    //lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblend.Visible = true;
                lblstart.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage from tbltimetable2 where strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage from tbltimetable3 where strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 ='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable3 a, tblemployee b where a.strteacher=b.intid and strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lblsatnoofdays.Text = (int.Parse(lblsatnoofdays.Text) + 1).ToString();
            }
        }
        catch { }
    }

    protected void dlsunday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsub = (Label)e.Item.FindControl("lblsunsub");
            Label lbltech = (Label)e.Item.FindControl("lblsuntech");
            Label lblbreak = (Label)e.Item.FindControl("lblsunbreak");
            Label lblstart = (Label)e.Item.FindControl("lblsunstarttime");
            Label lblend = (Label)e.Item.FindControl("lblsunendtime");
            Label lblsunperiod = (Label)e.Item.FindControl("lblsunperiod");
            Label lblsunclass = (Label)e.Item.FindControl("lblsunclass");
            lblbreak.Visible = false;
            try
            {
                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblsunperiod.Text + "' and strclass='" + lblsunclass.Text + "'";
                ds4 = new DataSet();
                ds4 = da4.ExceuteSql(str);
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds4.Tables[0].Rows[0]["strstartendtime"].ToString();
                    //lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                lbltech.Visible = false;
                lblbreak.Visible = true;
                lblend.Visible = false;
                lblstart.Visible = false;
            }
            else
            {
                lblsub.Visible = true;
                lbltech.Visible = true;
                lblstart.Visible = true;
                lblend.Visible = true;
                if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                {
                    if (rbtnstaff.Checked)
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage from tbltimetable2 where strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage from tbltimetable3 where strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + lbltech.Text + "' and strteacher=" + ddlstaff.SelectedValue;
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                        }
                    }
                    else
                    {
                        da4 = new DataAccess();
                        if (lblsub.Text == "Language" || lblsub.Text == "Second Language" || lblsub.Text == "Third Language")
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1 +''+ strsection1 ='" + ddlclass.SelectedValue + "'";
                        if (lblsub.Text == "Extra Activities")
                        {
                            str = "select strlanguage,strfirstname + ' ' + strmiddlename as strstaffname from tbltimetable2 a, tblemployee b where a.strteacher=b.intid and strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard +''+ strsection ='" + ddlclass.SelectedValue + "'";
                        }
                        ds4 = new DataSet();
                        ds4 = da4.ExceuteSql(str);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            lblsub.Text = ds4.Tables[0].Rows[0]["strlanguage"].ToString();
                            lbltech.Text = ds4.Tables[0].Rows[0]["strstaffname"].ToString();
                        }
                    }
                }
                if (lblsub.Text != "")
                    lblsunnoofdays.Text = (int.Parse(lblsunnoofdays.Text) + 1).ToString();
            }
        }
        catch { }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstaff.SelectedIndex == 0)
        {
            ddlclass.SelectedIndex = 0;
            ddlclass.Enabled = false;
            trgrid.Visible = false;
            trnd1.Visible = false;
            trnd2.Visible = false;
            trnd3.Visible = false;
            trnd4.Visible = false;
            trnd5.Visible = false;
            trnd6.Visible = false;
            trnd7.Visible = false;
            trtotaldays.Visible = false;
        }
        else
        {
            lblmonnoofdays.Text = "0";
            lblsatnoofdays.Text = "0";
            lblsunnoofdays.Text = "0";
            lblthunoofdays.Text = "0";
            lbltuenoofdays.Text = "0";
            lblwednoofdays.Text = "0";
            lblfrinoofdays.Text = "0";
            try
            {
                ddlclass.SelectedIndex = 0;
            }
            catch { }
            fillperiods();
            fillworkingdays();
            trgrid.Visible = true;
            ddlclass.Enabled = true;
            if (rbtnstaff.Checked)
                lblmode.Text = "Staff Timetable View - " + ddlstaff.SelectedItem.Text;
            else
                lblmode.Text = "Staff Timetable View - " + ddlstaff.SelectedItem.Text;
            trnd1.Visible = true;
            trnd2.Visible = true;
            trnd3.Visible = true;
            trnd4.Visible = true;
            trnd5.Visible = true;
            trnd6.Visible = true;
            trnd7.Visible = true;
            trtotaldays.Visible = true;
        }
    }

    protected void rbtnstaff_CheckedChanged(object sender, EventArgs e)
    {
        ddlstaff.SelectedIndex = 0;
        ddlstaff.Enabled = true;
        ddlclass.SelectedIndex = 0;
        ddlclass.Enabled = false;
        trgrid.Visible = false;
        lblmode.Text = "Staff Timetable View";
    }

    protected void rbtstudent_CheckedChanged(object sender, EventArgs e)
    {
        ddlstaff.SelectedIndex = 0;
        ddlstaff.Enabled = false;
        ddlclass.SelectedIndex = 0;
        ddlclass.Enabled = true;
        trgrid.Visible = false;
        lblmode.Text = "Student Timetable View";
        trnd1.Visible = false;
        trnd2.Visible = false;
        trnd3.Visible = false;
        trnd4.Visible = false;
        trnd5.Visible = false;
        trnd6.Visible = false;
        trnd7.Visible = false;
        trtotaldays.Visible = false;
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillworkingdays();
        fillperiods();
    }
}
