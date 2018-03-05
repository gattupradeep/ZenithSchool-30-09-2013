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

public partial class Leave_viewstaffleavetaken : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillleavetype();
            fillyear();
            fill_Name_and_Id();
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        try
        {
            if (Request["staffid"] != null && Request["leavecategory"] != null)
            {
                dgstaffleave.Visible = true;
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string sql = "";
                sql = "select * from ( ";

                sql += " select b1.*,c1.ct,intnoofdays-ct as availdays,'' as leavedate,'' as session, '' as reason,'' as mode from (";
                sql += " select strleavetype,intleavecategory,intnoofdays from tblassignstaffleave a, tblschoolleavecategory b";
                sql += " where a.intschool=b.intschool and a.intschool=" + Session["SchoolID"] + " and intstaffid=" + Request["staffid"] + " and a.intleavecategory=b.intid) as b1,";
                sql += " (select intleavetype,SUM(lt) as ct from(";
                sql += " select intleavetype,count(*) as lt from tblstaffleaves where intleaverequest in(";
                sql += " select a.intID from tblleaverequest a,tblAcademicYear b where a.intschool=b.intschool and a.intschool="+Session["SchoolID"]+" and a.intapproved=1 ";
                sql += " and a.intcancel=0 and a.intstaff="+Request["staffid"]+"  and a.dtdateofrequest >= b.StartDate and a.dtdateofrequest<= b.EndDate";
                if(drpyear.SelectedIndex > 0)
                {
                    sql += " and b.intYear="+drpyear.SelectedValue;
                }
                sql += " )";
                sql += " and strdaymode like 'Fullday%' group by intleavetype";
                sql += " union all";
                sql += " select intleavetype,count(*) * 0.5 as lt from tblstaffleaves where intleaverequest in(";
                sql += " select a.intID from tblleaverequest a,tblAcademicYear b where a.intschool=b.intschool and a.intschool="+Session["SchoolID"]+" and a.intapproved=1 ";
                sql += " and a.intcancel=0 and a.intstaff="+Request["staffid"]+"  and a.dtdateofrequest >= b.StartDate and a.dtdateofrequest<= b.EndDate";
                if(drpyear.SelectedIndex > 0)
                {
                    sql += " and b.intYear="+drpyear.SelectedValue;
                }
                sql += " )";
                sql += " and strdaymode like 'Halfday%' group by intleavetype) as a1 group by intleavetype) as c1";
                sql += " where b1.intleavecategory=c1.intleavetype";
                sql += " union all";
                sql += " select strleavetype,intleavecategory,intnoofdays,0 as ct, intnoofdays as availdays,'  -  ' as leavedate,'  -  ' as session, '  -  ' as reason,'  -  ' as mode ";
                sql += " from tblassignstaffleave a, tblschoolleavecategory b ";
                sql += " where a.intschool=b.intschool and a.intschool=" + Session["SchoolID"] + " and intstaffid=" + Request["staffid"] + " and a.intleavecategory=b.intid and b.intid not in(";
                sql += " select intleavetype from tblstaffleaves where intleaverequest in(";
                sql += " select a.intID from tblleaverequest a,tblAcademicYear b where a.intschool=b.intschool and a.intschool="+Session["SchoolID"]+" and a.intapproved=1 ";
                sql += " and a.intcancel=0 and a.intstaff=" + Request["staffid"] + "  and a.dtdateofrequest >= b.StartDate and a.dtdateofrequest<= b.EndDate";
                if(drpyear.SelectedIndex > 0)
                {
                    sql += " and b.intYear="+drpyear.SelectedValue;
                }
                sql += "))) a";
                if (drpleavetype.SelectedIndex > 0)
                {
                    sql += " where a.intleavecategory=" + drpleavetype.SelectedValue;
                }
                ds = da.ExceuteSql(sql);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    da = new DataAccess();
                    DataSet ds1 = new DataSet();
                    sql = "select CONVERT(varchar(50), a.dtleavedate,106) as leavedate,a.*,b.strreason from tblstaffleaves a,tblleaverequest b where a.intleaverequest in(select a.intid from";
                    sql += " tblleaverequest a,tblAcademicYear b where a.intschool=b.intschool and a.intschool=" + Session["SchoolID"];
                    sql += " and a.intapproved=1 and a.intcancel=0 and a.intstaff=" + Request["staffid"] + " and a.dtdateofrequest >= b.StartDate";
                    if(drpyear.SelectedIndex > 0)
                    {
                        sql += "  and b.intYear=" + drpyear.SelectedValue;
                    } 
                    sql += " and a.dtdateofrequest <= b.EndDate";
                    if(drpyear.SelectedIndex > 0)
                    {
                        sql += "  and b.intYear=" + drpyear.SelectedValue;
                    }
                    sql += " ) and  a.intschool=b.intschool and b.intID=a.intleaverequest and intleavetype=" + ds.Tables[0].Rows[i]["intleavecategory"].ToString();

                    ds1 = da.ExceuteSql(sql);
                    int leavetype = 0;
                    string leavedate="";
                    string mode="";
                    string session="";
                    string reason="";
                    for(int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (leavetype == 0)
                        {
                            leavetype = int.Parse(ds1.Tables[0].Rows[j]["intleavetype"].ToString());
                            leavedate = ds1.Tables[0].Rows[j]["leavedate"].ToString();
                            mode = ds1.Tables[0].Rows[j]["strdaymode"].ToString();
                            session = ds1.Tables[0].Rows[j]["strsession"].ToString();
                            reason = ds1.Tables[0].Rows[j]["strreason"].ToString();
                        }
                        else
                        {
                            leavedate = leavedate + "<br /> " + ds1.Tables[0].Rows[j]["leavedate"].ToString();
                            mode = mode + "<br /> " + ds1.Tables[0].Rows[j]["strdaymode"].ToString();
                            session = session + "<br /> " + ds1.Tables[0].Rows[j]["strsession"].ToString();
                            reason = reason + "<br /> " + ds1.Tables[0].Rows[j]["strreason"].ToString();
                        }
                    }
                    if (leavedate != "")
                    {
                        ds.Tables[0].Rows[i]["leavedate"] = leavedate.ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["leavedate"] = " - ";
                    }
                    if (mode != "")
                    {
                        ds.Tables[0].Rows[i]["mode"] = mode.ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["mode"] = " - ";
                    }
                    if (session != "")
                    {
                        ds.Tables[0].Rows[i]["session"] = session.ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["session"] = " - ";
                    }
                    if (reason != "")
                    {
                        ds.Tables[0].Rows[i]["reason"] = reason.ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["reason"] = " - ";
                    }
                }
                dgstaffleave.DataSource = ds;
                dgstaffleave.DataBind();

            }
        }
        catch { }
       
    }
    protected void fill_Name_and_Id()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name from tblemployee where intschool="+Session["SchoolID"]+" and intid=" + Request["staffid"];
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblidtxt.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblnametxt.Text = ds.Tables[0].Rows[0]["name"].ToString();
        }
    }
    protected void fillleavetype()
    {
        if (Request["staffid"] != null && Request["leavecategory"] != null)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select a.intleavecategory,b.strleavetype from tblassignstaffleave a,tblschoolleavecategory b where a.intleavecategory=b.intID";
            sql += " and a.intstaffid=" + Request["staffid"] + " group by a.intleavecategory,b.strleavetype";
            ds = da.ExceuteSql(sql);
            drpleavetype.DataSource = ds;
            drpleavetype.DataValueField = "intleavecategory";
            drpleavetype.DataTextField = "strleavetype";
            drpleavetype.DataBind();
            ListItem list = new ListItem("-ALL-", "0");
            drpleavetype.Items.Insert(0, list);
        }
    }
    protected void fillyear()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intYear from tblAcademicYear where intschool=" + Session["SchoolID"] + "  group by intYear";
        ds = da.ExceuteSql(sql);
        drpyear.DataSource = ds;
        drpyear.DataTextField = "intYear";
        drpyear.DataValueField = "intYear";
        drpyear.DataBind();
        ListItem list = new ListItem("--ALL--", "0");
        drpyear.Items.Insert(0, list);
        string str = "select top 1 intYear from tblAcademicYear where intschool=" + Session["SchoolID"] + " and intactive=1";
        DataSet ds1 = new DataSet();
        ds = da.ExceuteSql(str);
        drpyear.SelectedValue =ds.Tables[0].Rows[0]["intYear"].ToString();
    }
    protected void dgstaffleave_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgstaffleave.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Request["vwtype"].ToString() == "0")
        {
            Response.Redirect("viewleavecategory.aspx");
        }
        else
        {
            Response.Redirect("viewmyleavecategory.aspx");
        }
    }
    protected void drpleavetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
