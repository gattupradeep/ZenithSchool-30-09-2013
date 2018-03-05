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

public partial class reports_Staff_Leave_Reports : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds;
    public SqlDataAdapter da;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fillacademicyear();
            fillstafftype();
            filldepartment();
            fillstaff();
            txtfrom.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            txtTo.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            
            fillreport();
        }
        else
        {
            fillreport();
        }
    }
    protected void Page_init(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            fillreport();
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        fillstafftype();
        filldepartment();
        fillstaff();
    }
    protected void fillreport()
    {

        SqlDataAdapter da = new SqlDataAdapter();
        string repFilePath = "";

        strsql = "select d.strbranch as SchoolBranch, b.intid,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname+' - '+";
        strsql += " convert(varchar(50),b.intID) as staffname, b.strtype as stafftype,c.strdepartmentname,";
        strsql += " convert(varchar(10),a.dtdate,103) as leavedate,isnull(e.strleavetype,'Paid Leave') as leavetype,a.strsession";
        strsql += " from tblStaffAttendance a left outer join tblemployee b on a.intstaff=b.intid";
        strsql += " left outer join tbldepartment c on c.intid=b.intdepartment";
        strsql += " left outer join tblschooldetails d on d.intschoolid = " + Session["SchoolID"].ToString();
        strsql += " left outer join tblschoolleavecategory e on a.intleavetype=e.intid";
        strsql += " where b.intschool=" + Session["SchoolID"] + " and a.dtdate ";
        strsql += " between convert(datetime,'" + txtfrom.Text + "',103)and convert(datetime,'" + txtTo.Text + "',103)";

        //search by Staff Type 
        if (ddlstafftype.SelectedIndex > 1)
            strsql += " and b.strtype='" + ddlstafftype.SelectedValue + "'";
        //search by Department
        if (ddldepartment.SelectedIndex > 1)
            strsql += " and b.intDepartment = " + ddldepartment.SelectedValue;
        //search by Staff Name
        if (ddlstaff.SelectedIndex > 1)
            strsql += " and b.intid = " + ddlstaff.SelectedValue;

        /////////////////////////////////////////////////////////PRINT CUSTOM REPORT///////////////////////////////////////////////////////////////////
        DataSet1 ds = new DataSet1();
        da = new SqlDataAdapter(strsql, conn);
        da.Fill(ds, "tblstaffattendance");
        if (ds.Tables["tblstaffattendance"].Rows.Count > 0)
        {
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
            if (logrds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["tblstaffattendance"].Rows.Count; i++)
                {
                    string reportsortby = "";
                    ds.tblstaffattendance.Rows[i]["ReportGeneratedby"] = logrds.Tables[0].Rows[0]["logedinname"];
                    if (ddlstafftype.SelectedIndex > 1)
                    {
                        reportsortby = ddlstafftype.SelectedValue;
                    }
                    else if (ddldepartment.SelectedIndex > 1)
                    {
                        reportsortby += " And " + ddldepartment.SelectedValue;
                    }
                    else if (ddlstaff.SelectedIndex > 1)
                    {
                        reportsortby += " And " + ddlstaff.SelectedValue;
                    }
                    else if (txtfrom.Text != "" && txtTo.Text != "")
                    {
                        reportsortby += "From :" + txtfrom.Text + " To :" + txtTo.Text;
                    }
                    else
                    {
                        reportsortby = "All";
                    }
                    ds.tblstaffattendance.Rows[i]["Reportsortby"] = reportsortby;
                }
            }

            repFilePath = Server.MapPath("CR_Staff_Attendance/CR_StaffAttendance_all.rpt");
            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(repFilePath);
            repDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = repDoc;
            CrystalReportViewer1.DataBind();
        }
        else
        {
            repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(repFilePath);
            repDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = repDoc;
            CrystalReportViewer1.DataBind();
        }
    }
    //protected void fillacademicyear()
    //{
    //    try
    //    {
    //        strsql = "select intID,intYear, convert(varchar(4),Year(StartDate)) +' - '+ convert(varchar(4),Year(EndDate)) as acdyear from tblacademicyear where intschool = " + Session["SchoolID"] + " order by intID desc";
    //        DataAccess da1 = new DataAccess();
    //        DataSet ds1 = new DataSet();
    //        ds1 = da1.ExceuteSql(strsql);
    //        ddlacademicyear.DataSource = ds1;
    //        ddlacademicyear.DataTextField = "intYear";
    //        ddlacademicyear.DataValueField = "intYear";
    //        ddlacademicyear.DataBind();
    //    }
    //    catch { }
    //}
    protected void fillstafftype()
    {
        strsql = "Select 'All' as strstafftype union all Select strstafftype from tblstafftype";
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        ddlstafftype.DataSource = ds1;
        ddlstafftype.DataTextField = "strstafftype";
        ddlstafftype.DataValueField = "strstafftype";
        ddlstafftype.DataBind();
        ddlstafftype.Items.Insert(0, "-Select-");
    }
    protected void filldepartment()
    {
        try
        {
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            strsql = "select * from tbldepartment where intschool="+Session["SchoolID"];
            ds1 = da1.ExceuteSql(strsql);
            ddldepartment.DataSource = ds1;
            ddldepartment.DataTextField = "strdepartmentname";
            ddldepartment.DataValueField = "intid";
            ddldepartment.Items.Clear();
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, "-Select-");
            ddldepartment.Items.Insert(1, "-All-");
        }
        catch { }
    }
    protected void fillstaff()
    {
        try
        {
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname+' - '+convert(varchar(50),intID) as staffname from tblemployee where intschool="+Session["SchoolID"];
            if (ddlstafftype.SelectedIndex > 1)
            {
                strsql += " and strtype='" + ddlstafftype.SelectedValue + "'";
            }
            if (ddldepartment.SelectedIndex > 1)
            {
                strsql += " and intdepartment = " + ddldepartment.SelectedValue;
            }
            ds1 = da1.ExceuteSql(strsql);
            ddlstaff.DataSource = ds1;
            ddlstaff.DataTextField = "staffname";
            ddlstaff.DataValueField = "intID";
            ddlstaff.Items.Clear();
            ddlstaff.DataBind();
            ddlstaff.Items.Insert(0, "-Select-");
            ddlstaff.Items.Insert(1, "-All-");
        }
        catch { }
    }
    protected void ddlstafftype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaff();
        
    }
    protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaff();
    }
    //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    //{
    //    txtfrom.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
    //    txtTo.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
    //}
    //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    //{
    //    DateTime currentday = DateTime.Today;
    //    var daysTillThursday = (int)DayOfWeek.Sunday -(int)currentday.DayOfWeek;
    //    var weekstartdate = currentday.AddDays(daysTillThursday);
    //    txtfrom.Text = weekstartdate.Day.ToString() + "/" + weekstartdate.Month.ToString() + "/" + weekstartdate.Year.ToString();
    //    txtTo.Text = currentday.Day.ToString() + "/" + currentday.Month.ToString() + "/" + currentday.Year.ToString();
    //}
    //protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    //{
    //    DateTime currentday = DateTime.Today;
    //    var daysTillThursday = (int)currentday.DayOfWeek - (int)DayOfWeek.Sunday;
    //    var weekstartdate = currentday.AddDays(daysTillThursday);
    //    txtfrom.Text = "01/" + weekstartdate.Month.ToString() + "/" + weekstartdate.Year.ToString();
    //    txtTo.Text = currentday.Day.ToString() + "/" + currentday.Month.ToString() + "/" + currentday.Year.ToString();
    //}
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstaff.SelectedIndex > 0)
        {
            fillreport();
        }
    }
}
