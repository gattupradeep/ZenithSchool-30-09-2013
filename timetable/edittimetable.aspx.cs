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

public partial class timetable_edittimetable : System.Web.UI.Page
{
    public string str;
    public DataSet ds, ds1;
    public DataAccess da, da1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclasstype();
            fillsection();
            //filldgstandard();
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
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["strmode"].ToString() != "Holiday")
            {
                sql = "select a.*,b.strfirstname+' ' + b.strmiddlename +' '+b.strlastname as teachername from tbltimetable a, tblemployee b where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strday='" + ds.Tables[0].Rows[i]["strweekholidays"].ToString() + "'";
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
            else
            {
                if (ds.Tables[0].Rows[i]["strweekholidays"].ToString() == "Sunday")
                    tdsunday.Visible = false;
            }
        }
    }

    protected void fillclasstype()
    {
        try
        {
            str = "select strstandard from tblstandard_section_subject  where intschoolid=" + Session["SchoolID"] + " group by strstandard";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            ddlclass.DataSource = ds;
            ddlclass.DataTextField = "strstandard";
            ddlclass.DataValueField = "strstandard";
            ddlclass.DataBind();
        }
        catch { }
    }

    protected void fillsection()
    {
        try
        {
            str = "select strsection from tblstandard_section_subject  where intschoolid=" + Session["SchoolID"] + " group by strsection";
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
        fillperiods();
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("setclassrooms.aspx");
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
            Label lblsub = (Label)e.Item.FindControl("lblmonsubtech");
            Label lblbreak = (Label)e.Item.FindControl("lblmonbreak");

            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();
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
            Label lblsub = (Label)e.Item.FindControl("lbltuesubtech");
            Label lblbreak = (Label)e.Item.FindControl("lbltuebreak");
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();
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
            Label lblsub = (Label)e.Item.FindControl("lblwedsubtech");
            Label lblbreak = (Label)e.Item.FindControl("lblwedbreak");
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();
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
            Label lblsub = (Label)e.Item.FindControl("lblthusubtech");
            Label lblbreak = (Label)e.Item.FindControl("lblthubreak");
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();
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
            Label lblsub = (Label)e.Item.FindControl("lblfrisubtech");
            Label lblbreak = (Label)e.Item.FindControl("lblfribreak");
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();
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
            Label lblsub = (Label)e.Item.FindControl("lblsatsubtech");
            Label lblbreak = (Label)e.Item.FindControl("lblsatbreak");
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();
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
            Label lblsub = (Label)e.Item.FindControl("lblsunsubtech");
            Label lblbreak = (Label)e.Item.FindControl("lblsunbreak");
            if (dr["strperiod"].ToString().IndexOf("Interval") > -1)
            {
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Text = dr["strperiod"].ToString();
                lblbreak.Visible = true;
            }
            else if (dr["strperiod"].ToString().IndexOf("Lunch") > -1)
            {
                lblbreak.Text = dr["strperiod"].ToString();
                lblsub.Visible = false;
                ddlsub.Visible = false;
                ddltech.Visible = false;
                lblbreak.Visible = true;
            }
            else
            {
                strsql = "SELECT strsubject FROM tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "'";
                DataAccess da2 = new DataAccess();
                DataSet ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddlsub.DataSource = ds2;
                ddlsub.DataTextField = "strsubject";
                ddlsub.DataValueField = "strsubject";
                ddlsub.DataBind();

                strsql = "select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intID in (select intemployee from tblteachingclass where strteachclass='" + ddlclass.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + "";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(strsql);
                ddltech.DataSource = ds2;
                ddltech.DataTextField = "teachername";
                ddltech.DataValueField = "intid";
                ddltech.DataBind();

                ddlsub.Visible = true;
                ddltech.Visible = true;
                lblsub.Visible = false;

                //ddlsub.Visible = false;
                //ddltech.Visible = false;
                //lblsub.Visible = true;
            }
        }
        catch { }

    }
}
