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

public partial class substitute_assigneditsubstitute : System.Web.UI.Page
{
    public string str;
    public DataSet ds, ds1, ds2, ds3;
    public DataAccess da, da1, da2, da3;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillperiods();
            fillworkingdays();
        }
    }

    protected void fillperiods()
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

    protected void fillworkingdays()
    {
        da = new DataAccess();
        string sql = "select a.* from(select strfirstname + ' ' + strmiddlename + ' ' + strlastname as strstaffname,datename(dw,dtdate)as strday,convert(varchar(10),dtdate,103) as strleavedate,convert(varchar(10),dtdate,101) as strleavedate1,b.* from tblstaffattendance b, tblemployee c where b.intstaff=c.intid and cast(convert(varchar(10),dtdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and b.intschool=" + Session["SchoolID"].ToString() + ")";
        sql = sql + " as a,(select strday,strteacher from tbltimetable where intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject !='Language' and strsubject!='Extra Activities' group by strday,strteacher union all select strday,strteacher from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " group by strday,strteacher union all select strday,strteacher from tbltimetable3 where intschool=" + Session["SchoolID"].ToString() + " group by strday,strteacher) as b where a.intstaff=b.strteacher and a.strday=b.strday ";
        sql=sql+" and a.intstaff=" + Request["sid"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
            lblmode.Text = ds.Tables[0].Rows[0]["strstaffname"].ToString();
        dldays.DataSource = ds;
        dldays.DataBind();
    }

    protected void dldays_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            string sql;
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataList dlperiods = (DataList)e.Item.FindControl("dlperiods");
            Label lblday = (Label)e.Item.FindControl("lblday");
            Label lblleavedate = (Label)e.Item.FindControl("lblleavedate");

            sql = "select *,'' as strsubject,'None' as teachername,0 as strteacher,'' as strclass,'' as strday,'' as strleavedate from (select strperiod,cast(replace(replace(replace(replace(substring(strperiod,1,2),'s',''),'n',''),'r',''),'t','') as int) as intorder from tblschoolperiods where intschoolid=2 and strperiod like '%Period' group by strperiod) as a order by intorder";
            da1 = new DataAccess();
            ds1 = new DataSet();
            ds1 = da1.ExceuteSql(sql);

            sql = "select a.*,teachername from tbltimetable a, (select intid,strfirstname +' ' + strmiddlename +' '+strlastname as teachername,intschool from tblemployee  where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as b  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.strteacher=b.intid and strday='" + lblday.Text + "' and a.strteacher=" + Request["sid"].ToString() + " order by a.intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(sql);
            if (ds2.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                sql = "select a.*,b.strteacher as 'test',c.teachername from tbltimetable a,tbltimetable2 b,(select intid,strfirstname +' ' + strmiddlename +' '+strlastname as teachername,intschool from tblemployee where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as c  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and  a.strday=b.strday and a.strstandard=b.strstandard and a.strperiod=b.strperiod and a.strday='" + lblday.Text + "' and a.strteacher=-1 and b.strteacher=c.intID and b.strteacher=" + Request["sid"].ToString() + " order by a.intid";
                da2 = new DataAccess();
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(sql);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    sql = "select a.*,b.strteacher as 'test',c.teachername from tbltimetable a,tbltimetable3 b,(select intid,strfirstname +' ' + strmiddlename +' '+strlastname as teachername,intschool from tblemployee where strtype='Teaching Staffs' union all select 0 as intid,'Shift Teacher' as teachername," + Session["SchoolID"].ToString() + " as intschool union all select -1 as intid,'None' as teachername," + Session["SchoolID"].ToString() + " as intschool) as c  where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and  a.strday=b.strday and a.strstandard=b.strstandard and a.strperiod=b.strperiod and a.strday='" + lblday.Text + "' and a.strteacher=-1 and b.strteacher=c.intID and b.strteacher=" + Request["sid"].ToString() + " order by a.intid";
                    da2 = new DataAccess();
                    ds2 = new DataSet();
                    ds2 = da2.ExceuteSql(sql);
                }
            }
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                for (int j1 = 0; j1 < ds2.Tables[0].Rows.Count; j1++)
                {
                    if (ds1.Tables[0].Rows[j]["strperiod"].ToString() == ds2.Tables[0].Rows[j1]["strperiod"].ToString())
                    {
                        if (ds2.Tables[0].Rows[j1]["strsubject"].ToString().IndexOf("Second Language") > -1 || ds2.Tables[0].Rows[j1]["strsubject"].ToString().IndexOf("Third Language") > -1)
                        {
                            sql = "select * from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + Request["sid"].ToString() + " and strstandard1 + ' - ' + strsection1 ='" + ds2.Tables[0].Rows[j1]["strstandard"].ToString() + " - " + ds2.Tables[0].Rows[j1]["strsection"].ToString() + "' and strday='" + lblday.Text + "' and strperiod='" + ds2.Tables[0].Rows[j1]["strperiod"].ToString() + "'";
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
                            sql = "select * from tbltimetable3 where intschool=" + Session["SchoolID"].ToString() + " and strteacher=" + Request["sid"].ToString() + " and strstandard + ' - ' + strsection ='" + ds2.Tables[0].Rows[j1]["strstandard"].ToString() + " - " + ds2.Tables[0].Rows[j1]["strsection"].ToString() + "' and strday='" + lblday.Text + "' and strperiod='" + ds2.Tables[0].Rows[j1]["strperiod"].ToString() + "'";
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
                        ds1.Tables[0].Rows[j]["strclass"] = ds2.Tables[0].Rows[j1]["strstandard"].ToString();
                    }
                }
                ds1.Tables[0].Rows[j]["strday"] = lblday.Text;
                ds1.Tables[0].Rows[j]["strleavedate"] = lblleavedate.Text;
            }
            dlperiods.DataSource = ds1;
            dlperiods.DataBind();
        }
        catch { }
    }

    protected void dlperiods_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlsunteacher");
            Label lblday = (Label)e.Item.FindControl("lblday");
            Label lblleavedate = (Label)e.Item.FindControl("lblleavedate");
            Label lblsub = (Label)e.Item.FindControl("lblsunsub");
            Label lbltech = (Label)e.Item.FindControl("lblsuntech");
            Label lblperiod = (Label)e.Item.FindControl("lblsunperiod");
            Label lblclass = (Label)e.Item.FindControl("lblclass");
            Label lblstart = (Label)e.Item.FindControl("lblstarttime");
            Label lblend = (Label)e.Item.FindControl("lblendtime");
            //Label lbltotalperiods = (Label)e.Item.Parent.FindControl("lbltotalperiods");
            //Label lblassigned = (Label)e.Item.Parent.FindControl("lblassinged");
            //Label lblunassigned = (Label)e.Item.Parent.FindControl("lblunassigned");

            //int tp = 0;
            //int ap = 0;
            //int uap = 0;
            try
            {
                da2 = new DataAccess();

                str = "select strSTHH+':'+strSTMM +' - '+strETHH+':'+strETMM as strstartendtime from tblschoolperiods where strperiod='" + lblperiod.Text + "' and strclass='" + lblclass.Text + "'";
                ds2 = new DataSet();
                ds2 = da2.ExceuteSql(str);
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    lblstart.Text = ds2.Tables[0].Rows[0]["strstartendtime"].ToString();
                    // lblend.Text = ds4.Tables[0].Rows[0]["strendtime"].ToString();
                }
            }
            catch { }

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where strtype='Teaching Staffs' and intschool=" + Session["SchoolID"].ToString() + " and  intid not in( select strteacher from tbltimetable where strday='" + lblday.Text + "' and strperiod='" + lblperiod.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject not like 'Extra Activities') and  intid not in( select strteacher from tbltimetable2 where strday='" + lblday.Text + "' and strperiod='" + lblperiod.Text + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in( select strteacher from tbltimetable3 where strday='" + lblday.Text + "' and strperiod='" + lblperiod.Text + "' and intschool=" + Session["SchoolID"].ToString() + ") and  intid not in(select intstaff from tblstaffattendance where dtdate='" + lblleavedate.Text + "' and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            string sql = "select strteacher from tblsubstitutetimetable where intschool=" + Session["SchoolID"].ToString() + " and intstaff=" + Request["sid"].ToString() + " and strday='" + lblday.Text + "' and strperiod='" + lblperiod.Text + "' and dtdate='" + lblleavedate.Text + "'";
            da3 = new DataAccess();
            ds3 = new DataSet();
            ds3 = da3.ExceuteSql(sql);
            if (ds3.Tables[0].Rows.Count > 0)
                ddltech.SelectedValue = ds3.Tables[0].Rows[0]["strteacher"].ToString();

            if (lblsub.Text == "")
                ddltech.Visible = false;
            else
                ddltech.Visible = true;

            if (ddltech.SelectedValue == "-1" && lblsub.Text != "")
            {
                e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#4F6228");
                //tp = tp + 1;
                //uap = uap + 1;
            }
            else if (ddltech.SelectedValue != "0" && ddltech.SelectedValue != "-1" && lblsub.Text != "")
            {
                e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBB59");
                //tp = tp + 1;
                //ap = ap + 1;
            }
            //lbltotalperiods.Text = tp.ToString();
            //lblassigned.Text = ap.ToString();
            //lblunassigned.Text = uap.ToString();
        }
        catch { }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        foreach (DataListItem dlit in dldays.Items)
        {
            DataRowView drd = (DataRowView)dlit.DataItem;
            string strsql;
            Label lblday = (Label)dlit.FindControl("lblday");
            Label lblleavedate = (Label)dlit.FindControl("lblleavedate");
            DataList dlperiods1 = (DataList)dlit.FindControl("dlperiods");

            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            string str = "select intid from tblsubstitutetimetable where dtdate='" + lblleavedate.Text + "' and intstaff=" + Request["sid"].ToString() + " and intschool=" + Session["SchoolID"].ToString() + "";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblsubstitutetimetable", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),92);
                }
            }
            str = "delete tblsubstitutetimetable where dtdate='" + lblleavedate.Text + "' and intstaff=" + Request["sid"].ToString() + " and intschool=" + Session["SchoolID"].ToString() + "";
            da.ExceuteSqlQuery(str);
            foreach (DataListItem dlpe in dlperiods1.Items)
            {
                DataRowView drp = (DataRowView)dlpe.DataItem;
                DropDownList ddltech = (DropDownList)dlpe.FindControl("ddlsunteacher");
                Label lblperiod = (Label)dlpe.FindControl("lblsunperiod");
                Label lblclass = (Label)dlpe.FindControl("lblclass");
                if (ddltech.Visible == true)
                {
                    strsql = "insert into tblsubstitutetimetable (strclass,dtdate,strday,strperiod,strteacher,intstaff,intschool)";
                    strsql = strsql + " values('" + lblclass.Text + "','" + lblleavedate.Text + "','" + lblday.Text + "',";
                    strsql = strsql + "'" + lblperiod.Text + "','" + ddltech.SelectedValue + "','" + Request["sid"].ToString() + "'," + Session["SchoolID"].ToString() + ")";
                    da = new DataAccess();
                    ds2 = new DataSet();
                    da.ExceuteSqlQuery(strsql);

                    strsql = "select max(intid) as intid from tblsubstitutetimetable";
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblsubstitutetimetable", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),92);
                }
            }
        }
        //Response.Redirect("assignsubstitute.aspx");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='assignsubstitute.aspx';", true);
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("assignsubstitute.aspx");
    }
}
