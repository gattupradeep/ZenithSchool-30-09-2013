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

public partial class Leave_Viewmyleavecategory : System.Web.UI.Page
{
    public DataAccess da = new DataAccess();
    public DataSet ds = new DataSet();
    string sql;
    string studentid;
    public DataAccess da1 = new DataAccess();
    public DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillyear();            
            try
            {
                
                sql = "select *,strfirstname+' '+strmiddlename+' '+strlastname as name from tblemployee where intid=" + Session["UserID"].ToString();
                da1 = new DataAccess();
                ds1 = new DataSet();
                ds1 = da1.ExceuteSql(sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    
                    filldept();
                    try
                    {
                        drp_dept.SelectedValue = ds1.Tables[0].Rows[0]["intdepartment"].ToString();
                    }
                    catch { }
                    filldesignation();
                    try
                    {
                        drp_desig.SelectedValue = ds1.Tables[0].Rows[0]["intdesignation"].ToString();
                    }
                    catch { }
                    drp_dept.Enabled = false;
                    drp_desig.Enabled = false;
                    txtname.Text = ds1.Tables[0].Rows[0]["name"].ToString();
                    txtname.Enabled = false;
                    fillgrid();
                }
            }
            catch { }
        }
    }
    protected void fillgrid()
    {
        try
        {
            grdleavecategory.Visible = true;
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from (";

            sql += " (select a.intstaff,a.name,a.strleavetype,a.intnoofdays,";
            sql += " SUM(a.useddays) as useddays, (a.intnoofdays-SUM(a.useddays)) as availabledays,a.intschool,";
            sql += " a.intDepartment,a.intDesignation,a.intleavecategory from (";

            sql += " select b.intstaff,c.strfirstname+' '+strmiddlename+' '+strlastname as name,d.strleavetype,e.intnoofdays,";
            sql += " COUNT(a.intleaverequest) as useddays,(e.intnoofdays-COUNT(a.intleaverequest)) as availabledays,e.intschool,";
            sql += " c.intDepartment,c.intDesignation,e.intleavecategory from ";
            sql += " tblstaffleaves a,tblleaverequest b,tblemployee c,tblschoolleavecategory d,tblassignstaffleave e,tblAcademicYear f,";
            sql += " (select top 1 * from tblAcademicYear where intschool=" + Session["SchoolID"].ToString() + " order by intid desc) as g where a.intschool=b.intschool and";
            sql += " b.intschool=c.intschool and c.intschool=d.intschool and d.intschool=e.intschool and e.intschool=f.intschool and f.intschool=g.intschool";
            sql += " and c.intID=b.intstaff and b.intstaff=e.intstaffid and d.intID=a.intleavetype and a.intleavetype=e.intleavecategory ";
            sql += " and a.intleaverequest=b.intID and b.intapproved=1 and b.intcancel = 0 and a.strdaymode='Fullday' and ";
            sql += " b.dtfromdate >= f.StartDate and b.dtfromdate <= f.EndDate and b.dttodate >= f.StartDate  and b.dttodate <= f.EndDate";

            //if (drpyear.SelectedIndex > 0)
            //{
            //    sql += " and f.intYear='" + drpyear.SelectedValue + "'";
            //}
            //else
            //{
            //    sql += " and f.intYear=g.intYear";
            //}

            sql += " group by b.intstaff,c.strfirstname+' '+strmiddlename+' '+strlastname,d.strleavetype,e.intnoofdays,e.intschool,";
            sql += " c.intDepartment,c.intDesignation,e.intleavecategory";

            sql += " union all ";

            sql += " select b.intstaff,c.strfirstname+' '+strmiddlename+' '+strlastname as name,d.strleavetype,e.intnoofdays,";
            sql += " COUNT(a.intleaverequest)*0.5 as useddays,(e.intnoofdays-(COUNT(a.intleaverequest)*0.5)) as availabledays,e.intschool,";
            sql += " c.intDepartment,c.intDesignation,e.intleavecategory";
            sql += " from tblstaffleaves a,tblleaverequest b,tblemployee c,tblschoolleavecategory d,tblassignstaffleave e,tblAcademicYear f,";
            sql += " (select top 1 * from tblAcademicYear where intschool=" + Session["SchoolID"].ToString() + " order by intid desc) as g where a.intschool=b.intschool and ";
            sql += " b.intschool=c.intschool and c.intschool=d.intschool and d.intschool=e.intschool and e.intschool=f.intschool and f.intschool=g.intschool and ";
            sql += " c.intID=b.intstaff and b.intstaff=e.intstaffid and d.intID=a.intleavetype and a.intleavetype=e.intleavecategory ";
            sql += " and a.intleaverequest=b.intID and b.intapproved=1 and b.intcancel = 0 and a.strdaymode='Halfday' and ";
            sql += " b.dtfromdate >= f.StartDate and b.dtfromdate <= f.EndDate and b.dttodate >= f.StartDate  and b.dttodate <= f.EndDate ";

            //if (drpyear.SelectedIndex > 0)
            //{
            //    sql += " and f.intYear='" + drpyear.SelectedValue + "'";
            //}
            //else
            //{
            //    sql += " and f.intYear=g.intYear";
            //}

            sql += " group by b.intstaff,c.strfirstname+' '+strmiddlename+' '+strlastname,";
            sql += " d.strleavetype,e.intnoofdays,e.intschool,c.intDepartment,c.intDesignation,e.intleavecategory";

            sql += " ) as a group by a.intstaff,a.name,a.strleavetype,a.intnoofdays,";
            sql += " a.intschool, a.intDepartment,a.intDesignation,a.intleavecategory)";

            sql += " union all";

            sql += " select e.intstaffid,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name,d.strleavetype,e.intnoofdays,";
            sql += " 0.0 as useddays,e.intnoofdays as availabledays,e.intschool,c.intDepartment,c.intDesignation,e.intleavecategory from tblemployee c,tblschoolleavecategory d,";
            sql += " tblassignstaffleave e where c.intschool=d.intschool and d.intschool=e.intschool and c.intID=e.intstaffid and d.intID=e.intleavecategory and";
            sql += " (e.intstaffid not in  (select a.intstaff from tblleaverequest a, tblstaffleaves b,tblAcademicYear c,";
            sql += " (select top 1 * from tblAcademicYear where intschool=" + Session["SchoolID"].ToString() + " order by intid desc) d where a.intschool=b.intschool ";
            sql += " and b.intschool=c.intschool and c.intschool=d.intschool and a.intID=b.intleaverequest and intapproved = 1  and ";
            sql += " intcancel = 0 and c.intYear=d.intYear and a.dtfromdate >= c.StartDate and a.dtfromdate <= c.EndDate and ";
            sql += " a.dttodate >= c.StartDate  and a.dttodate <= c.EndDate group by a.intstaff) or  e.intleavecategory not in ";
            sql += " (select b.intleavetype from tblleaverequest a, tblstaffleaves b, tblAcademicYear c ,(select top 1 * from tblAcademicYear";
            sql += " where intschool=" + Session["SchoolID"].ToString() + " order by intid desc) d where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool";
            sql += " and a.intID=b.intleaverequest and intapproved = 1  and c.intYear=d.intYear and intcancel = 0 and ";
            sql += " a.dtfromdate >= c.StartDate and a.dtfromdate <= c.EndDate and  a.dttodate >= c.StartDate  and ";
            sql += " a.dttodate <= c.EndDate group by b.intleavetype)) group by e.intstaffid,c.strfirstname+' '+strmiddlename+' '+strlastname,";
            sql += " d.strleavetype,e.intnoofdays,e.intschool,c.intDepartment,c.intDesignation,e.intleavecategory";

            sql += " ) as a where a.intschool=" + Session["SchoolID"].ToString();

            if (drp_dept.SelectedIndex > 0)
            {
                sql += " and a.intDepartment=" + drp_dept.SelectedValue;
            }
            if (drp_desig.SelectedIndex > 0)
            {
                sql += " and a.intDesignation=" + drp_desig.SelectedValue;
            }
            if (txtname.Text != "")
            {
                sql += " and a.intstaff ="+Session["UserID"].ToString();
            }
            
            sql += "  order by a.intstaff";

            ds = da.ExceuteSql(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grdleavecategory.DataSource = ds;
                grdleavecategory.DataBind();
            }            
        }
        catch
        { }
    }
    
    protected void filldept()
    {
        da = new DataAccess();
        ds = new DataSet();
        sql = "select a.intid,a.strdepartmentname from tbldepartment a, tblemployee b where a.intschool=" + Session["SchoolID"].ToString();
        sql += " and a.intid=b.intDepartment group by a.intid,a.strdepartmentname";
        ds = da.ExceuteSql(sql);
        drp_dept.DataSource = ds;
        drp_dept.DataTextField = "strdepartmentname";
        drp_dept.DataValueField = "intid";
        drp_dept.DataBind();
        ListItem list = new ListItem("-ALL-", "0");
        drp_dept.Items.Insert(0, list);
    }
    protected void filldesignation()
    {
        da = new DataAccess();
        ds = new DataSet();
        sql = "select a.intid, a.strdesignation from tbldesignation a,tblemployee b where a.intschool=b.intschool and a.intschool=" + Session["SchoolID"].ToString();
        if (drp_dept.SelectedIndex > 0)
        {
            sql += " and b.intDepartment=" + drp_dept.SelectedValue;
        }
        sql += " and a.intid=b.intDesignation GROUP BY a.intid, a.strdesignation";
        ds = da.ExceuteSql(sql);
        drp_desig.DataSource = ds;
        drp_desig.DataValueField = "intid";
        drp_desig.DataTextField = "strdesignation";
        drp_desig.DataBind();
        ListItem list = new ListItem("-ALL-", "0");
        drp_desig.Items.Insert(0, list);
    }
    protected void fillyear()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intYear from tblAcademicYear where intschool=" + Session["SchoolID"].ToString() + " group by intYear";
        ds = da.ExceuteSql(sql);
        drpyear.DataSource = ds;
        drpyear.DataTextField = "intYear";
        drpyear.DataValueField = "intYear";
        drpyear.DataBind();
        ListItem list = new ListItem("--ALL--", "0");
        drpyear.Items.Insert(0, list);
        string str = "select intYear from tblAcademicYear where intschool=" + Session["SchoolID"].ToString() + " and intactive=1";
        DataSet ds1 = new DataSet();
        ds = da.ExceuteSql(str);
        drpyear.SelectedValue = ds.Tables[0].Rows[0]["intYear"].ToString();
    }
    protected void btnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton list = (ImageButton)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        Response.Redirect("viewstaffleavetaken.aspx?staffid=" + item.Cells[0].Text + "&leavecategory=" + item.Cells[6].Text + "&year=" + drpyear.SelectedValue + "&vwtype=1", true);
    }
    protected void grdleavecategory_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        grdleavecategory.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }   
}
