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

public partial class timetable_viewtimetable : System.Web.UI.Page
{
    public string str;
    public DataSet ds, ds1;
    public DataAccess da,da1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["m"] != null)
                lblmode.Text = Request["m"].ToString();

            Session["EditTT"] = "View";
            fillclasstype();
            fillsection();
            fillperiods();
            fillworkingdays();
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
        for (int i=0; i<ds.Tables[0].Rows.Count;i++)
        {
            if (ds.Tables[0].Rows[i]["strmode"].ToString() != "Holiday")
            {
                sql = "select a.*,teachername from tbltimetable a, (select intid,strfirstname +' ' + strmiddlename +' '+strlastname as teachername,intschool from tblemployee  where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'  and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "' order by a.intid";
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
                    sql = "select strperiod,'' as strsubject,'' as teachername,0 as strteacher  from tblschoolperiods where intschoolid=" + Session["SchoolID"].ToString() + " order by intorder";
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
            else
            {
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Sunday")
                    tdsunday.Visible = false;
            }
        }
        if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "View")
        {
            if (lblmode.Text == "1")
                btnedit.Visible = true;
            else
                btnedit.Visible = false;
            if (Session["EditTT"].ToString() == "View")
            {
                trupdate.Visible = false;
            }
            if (Session["EditTT"].ToString() == "Edit")
            {
                btnedit.Visible = false;
                btnupdate.Text = "Update";
                trupdate.Visible = true;
            }
        }
        else
        {
            btnedit.Visible = false;
            trupdate.Visible = true;
            btnupdate.Text = "Save";
        }
    }
    
    protected void fillclasstype()
    {
        try
        {
            if(lblmode.Text=="1")
                str = "select strstandard from tblstandard_section_subject where intschoolid=" + Session["SchoolID"] + " group by strstandard";
            else
                str = "select strstandard from tblstandard_section_subject where strstandard in(select strstandard from tbltimetable where intschool=" + Session["SchoolID"] + " group by strstandard) and intschoolid=" + Session["SchoolID"] + " group by strstandard";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlclass.DataSource = ds;
                ddlclass.DataTextField = "strstandard";
                ddlclass.DataValueField = "strstandard";
                ddlclass.DataBind();
            }
            else
            {
                Response.Redirect("viewtimetable.aspx?m=1");
            }
        }
        catch { }
    }

    protected void fillsection()
    {
        try
        {
            if (lblmode.Text == "1")
                str = "select strsection from tblstandard_section_subject  where intschoolid=" + Session["SchoolID"] + " group by strsection";
            else
                str = "select strsection from tblstandard_section_subject  where strsection in(select strsection from tbltimetable where intschool=" + Session["SchoolID"] + " group by strsection) and intschoolid=" + Session["SchoolID"] + " group by strsection";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            ddlsection.DataSource = ds;
            ddlsection.DataTextField = "strsection";
            ddlsection.DataValueField = "strsection";
            ddlsection.DataBind();
        }
        catch { }
    }

    protected void fillperiods()
    {
        try
        {
            DataAccess da = new DataAccess();
            str = "select strperiod,strSTHH + ':' + strSTMM as strstarttime,strETHH + ':' + strETMM as strendtime from tblschoolperiods where intschoolid=" + Session["SchoolID"].ToString() + " order by intorder";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            dgtimetable.DataSource = ds;
            dgtimetable.DataBind();
        }
        catch { }
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["EditTT"] = "View";
        fillperiods();
        fillworkingdays();
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Session["EditTT"] = "Edit";
        fillperiods();
        fillworkingdays();
    }

    //protected void dgtimetable_ItemDataBound(object sender, DataGridItemEventArgs e)
    //{
    //    try
    //    {
    //        DataRowView dr = (DataRowView)e.Item.DataItem;
    //        string strsql;
    //        if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
    //            strsql = "select strstandard,strsection,strday,'' as strteacher,'Interval' as subject from (select *, strsubject as subject from tbltimetable where strsubject not like '%Language%' and intschool=" + Session["SchoolID"].ToString() + " union all select *, replace(strlanguage,',','<br/>') as subject from tbltimetable where strsubject like '%Language%' and intschool=" + Session["SchoolID"].ToString() + ") as  a where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and  strperiod='" + dr["strperiod"].ToString() + "'";
    //        else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
    //            strsql = "select strstandard,strsection,strday,'' as strteacher,'Lunch' as subject from (select *, strsubject as subject from tbltimetable where strsubject not like '%Language%' and intschool=" + Session["SchoolID"].ToString() + " union all select *, replace(strlanguage,',','<br/>') as subject from tbltimetable where strsubject like '%Language%' and intschool=" + Session["SchoolID"].ToString() + ") as  a where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and  strperiod='" + dr["strperiod"].ToString() + "'";
    //        else
    //            strsql = "select strstandard,strsection,strday,strteacher,subject from (select *, strsubject as subject from tbltimetable where strsubject not like '%Language%' and intschool=" + Session["SchoolID"].ToString() + " union all select *, replace(strlanguage,',','<br/>') as subject from tbltimetable where strsubject like '%Language%' and intschool=" + Session["SchoolID"].ToString() + ") as  a where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and  strperiod='" + dr["strperiod"].ToString() + "'";
    //        da = new DataAccess();
    //        ds = new DataSet();
    //        ds = da.ExceuteSql(strsql);
    //        DataList dlper = (DataList)e.Item.FindControl("dlperiods");
    //        dlper.DataSource = ds;
    //        dlper.DataBind();
    //    }
    //    catch { }
    //}

    protected void dlmonday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddlmonsubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlmonteacher");
            Label lblsub = (Label)e.Item.FindControl("lblmonsub");
            Label lbltech = (Label)e.Item.FindControl("lblmontech");
            Label lblbreak = (Label)e.Item.FindControl("lblmonbreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnmonsecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Monday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void dltuesday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddltuesubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddltueteacher");
            Label lblsub = (Label)e.Item.FindControl("lbltuesub");
            Label lbltech = (Label)e.Item.FindControl("lbltuetech");
            Label lblbreak = (Label)e.Item.FindControl("lbltuebreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btntuesecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and  intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Tuesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }

    }

    protected void dlwednesday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddlwedsubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlwedteacher");
            Label lblsub = (Label)e.Item.FindControl("lblwedsub");
            Label lbltech = (Label)e.Item.FindControl("lblwedtech");
            Label lblbreak = (Label)e.Item.FindControl("lblwedbreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnwedsecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and  intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Wednesday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }

    }

    protected void dlthursday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddlthusubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlthuteacher");
            Label lblsub = (Label)e.Item.FindControl("lblthusub");
            Label lbltech = (Label)e.Item.FindControl("lblthutech");
            Label lblbreak = (Label)e.Item.FindControl("lblthubreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnthusecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and  intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Thursday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }

    }

    protected void dlfriday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddlfrisubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlfriteacher");
            Label lblsub = (Label)e.Item.FindControl("lblfrisub");
            Label lbltech = (Label)e.Item.FindControl("lblfritech");
            Label lblbreak = (Label)e.Item.FindControl("lblfribreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnfrisecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and  intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Friday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }

    }
    protected void dlsaturday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddlsatsubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlsatteacher");
            Label lblsub = (Label)e.Item.FindControl("lblsatsub");
            Label lbltech = (Label)e.Item.FindControl("lblsattech");
            Label lblbreak = (Label)e.Item.FindControl("lblsatbreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnsatsecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and  intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Saturday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void dlsunday_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)e.Item.FindControl("ddlsunsubject");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlsunteacher");
            Label lblsub = (Label)e.Item.FindControl("lblsunsub");
            Label lbltech = (Label)e.Item.FindControl("lblsuntech");
            Label lblbreak = (Label)e.Item.FindControl("lblsunbreak");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnsunsecond");
            ddlsub.Visible = false;
            ddltech.Visible = false;
            lblbreak.Visible = false;
            btnchnage.Visible = false;
            if (lblmode.Text == "1")
                btnchnage.ImageUrl = "../media/images/change.jpg";
            else
                btnchnage.ImageUrl = "../media/images/view.png";

            string extra = "";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select * from tblstandard_section_extracurricular where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + "";
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
                extra = " union all select 'Extra Activities' as strsubject ";

            strsql = "select 'None' as strsubject" + " union all SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'" + extra;
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsub.DataSource = ds2;
            ddlsub.DataTextField = "strsubject";
            ddlsub.DataValueField = "strsubject";
            ddlsub.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard+strsection<>'" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            btnchnage.Visible = false;
            strsql = "select strlanguage from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strday='Sunday' and strperiod='" + dr["strperiod"].ToString() + "' and strstandard1+strsection1='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "' and strstandard+strsection!='" + ddlclass.SelectedValue + ddlsection.SelectedValue + "'";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblsub.Visible = true;
                lbltech.Visible = false;
                lblsub.Text = ds2.Tables[0].Rows[0]["strlanguage"].ToString();
            }
            else
            {
                if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
                {
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblbreak.Visible = true;
                }
                else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
                {
                    lblbreak.Text = dr["strperiod"].ToString();
                    lblsub.Visible = false;
                    lbltech.Visible = false;
                    ddlsub.Visible = false;
                    ddltech.Visible = false;
                    lblbreak.Visible = true;
                }
                else
                {
                    if (Session["EditTT"].ToString() == "Edit" || Session["EditTT"].ToString() == "New")
                    {
                        ddlsub.Visible = true;
                        ddltech.Visible = true;
                        lblsub.Visible = false;
                        lbltech.Visible = false;

                        if (Session["EditTT"].ToString() == "Edit")
                        {
                            ddlsub.SelectedValue = dr["strsubject"].ToString();
                            ddltech.SelectedValue = dr["strteacher"].ToString();
                        }

                    }
                    else
                    {
                        ddlsub.Visible = false;
                        ddltech.Visible = false;
                        lblsub.Visible = true;
                        lbltech.Visible = true;
                        if (lblsub.Text == "Second Language" || lblsub.Text == "Third Language" || lblsub.Text == "Extra Activities")
                        {
                            lbltech.Visible = false;
                            btnchnage.Visible = true;
                            if (lblsub.Text == "Extra Activities")
                            {
                                if (lblmode.Text == "1")
                                    btnchnage.ImageUrl = "../media/images/change1.jpg";
                                else
                                    btnchnage.ImageUrl = "../media/images/view1.png";
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select intid from tbltimetable where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);

            }
        }
        da = new DataAccess();
        str = "delete tbltimetable where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
        da.ExceuteSqlQuery(str);

        foreach (DataListItem dlit in dlmonday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddlmonsubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddlmonteacher");
            Label lblbreak = (Label)dlit.FindControl("lblmonbreak");
            Label lblperiod = (Label)dlit.FindControl("lblmonperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Monday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Monday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Monday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }
        foreach (DataListItem dlit in dltuesday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddltuesubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddltueteacher");
            Label lblbreak = (Label)dlit.FindControl("lbltuebreak");
            Label lblperiod = (Label)dlit.FindControl("lbltueperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Tuesday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Tuesday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Tuesday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }
        foreach (DataListItem dlit in dlwednesday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddlwedsubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddlwedteacher");
            Label lblbreak = (Label)dlit.FindControl("lblwedbreak");
            Label lblperiod = (Label)dlit.FindControl("lblwedperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Wednesday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Wednesday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Wednesday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }
        foreach (DataListItem dlit in dlthursday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddlthusubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddlthuteacher");
            Label lblbreak = (Label)dlit.FindControl("lblthubreak");
            Label lblperiod = (Label)dlit.FindControl("lblthuperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Thursday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Thursday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Thursday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }
        foreach (DataListItem dlit in dlfriday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddlfrisubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddlfriteacher");
            Label lblbreak = (Label)dlit.FindControl("lblfribreak");
            Label lblperiod = (Label)dlit.FindControl("lblfriperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Friday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Friday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Friday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }
        foreach (DataListItem dlit in dlsaturday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddlsatsubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddlsatteacher");
            Label lblbreak = (Label)dlit.FindControl("lblsatbreak");
            Label lblperiod = (Label)dlit.FindControl("lblsatperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Saturday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Saturday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Saturday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }
        foreach (DataListItem dlit in dlsunday.Items)
        {
            DataRowView drv = (DataRowView)dlit.DataItem;
            string strsql;
            DropDownList ddlsub = (DropDownList)dlit.FindControl("ddlsunsubject");
            DropDownList ddltech = (DropDownList)dlit.FindControl("ddlsunteacher");
            Label lblbreak = (Label)dlit.FindControl("lblsunbreak");
            Label lblperiod = (Label)dlit.FindControl("lblsunperiod");
            if (ddlsub.Visible == true)
            {
                if (ddlsub.SelectedValue == "None")
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Sunday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','-1'," + Session["SchoolID"].ToString() + ")";
                }
                else
                {
                    strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                    strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Sunday',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddlsub.SelectedValue + "','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                }
            }
            else
            {
                strsql = "insert into tbltimetable (strstandard,strsection,strday,strperiod,strsubject,strlanguage,strteacher,intschool)";
                strsql = strsql + " values('" + ddlclass.SelectedValue + "','" + ddlsection.SelectedValue + "','Sunday',";
                strsql = strsql + "'" + lblperiod.Text + "','Language','','" + ddltech.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
            }
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);

            DataSet ds2 = new DataSet();
            strsql = "select max(intid) as intid from tbltimetable";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
        }

        Session["EditTT"] = "View";
        fillperiods();
        fillworkingdays();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Session["EditTT"] = "View";
        fillperiods();
        fillworkingdays();
    }

    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["EditTT"] = "View";
        fillperiods();
        fillworkingdays();
    }

    protected void dlsunday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lblsunperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnsunsecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Sunday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }
    }

    protected void dlmonday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lblmonperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnmonsecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Monday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }
    }
    protected void dltuesday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lbltueperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btntuesecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Tuesday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }

    }
    protected void dlwednesday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lblwedperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnwedsecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Wednesday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }

    }
    protected void dlthursday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lblthuperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnthusecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Thursday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }

    }
    protected void dlfriday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lblfriperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnfrisecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Friday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }

    }

    protected void dlsaturday_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label lblperiod = (Label)e.Item.FindControl("lblsatperiod");
            ImageButton btnchnage = (ImageButton)e.Item.FindControl("btnsatsecond");
            Session["2ndlangstandard"] = ddlclass.SelectedValue;
            Session["2ndlangsection"] = ddlsection.SelectedValue;
            Session["2ndlangday"] = "Saturday";
            Session["2ndlangperiod"] = lblperiod.Text;
            Session["setlangclass"] = ddlclass.SelectedValue + " - " + ddlsection.SelectedValue;
            if (btnchnage.ImageUrl == "../media/images/change.jpg")
            {
                string url = "setlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>openNewWin1('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/change1.jpg")
            {
                string url = "setextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin2", "<script>openNewWin2('" + url + "')</script>");
            }
            else if (btnchnage.ImageUrl == "../media/images/view1.png")
            {
                string url = "showextraactivities.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin3", "<script>openNewWin3('" + url + "')</script>");
            }
            else
            {
                string url = "showsecondlanguage.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
        catch { }

    }
}
