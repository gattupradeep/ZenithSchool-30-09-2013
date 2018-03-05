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

public partial class reports_Students_strength_report : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataSet1 ds;
    public SqlDataAdapter da;
    public string strsql;
    public string strsqlunion;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CR_Strength_report_ID"] = 0;
            fillstandard();
            fillbirthday();
            fillhousename();
            trsort.Visible = false;
        }
        else
        {
            fillreport((int)Session["CR_Strength_report_ID"]);
        }
    }
    protected void fillreport(int id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        string repFilePath = "";
        string strsql = "select a.strhouse, isnull(a.strfirstname,'') + ' ' + isnull(a.strmiddlename,'') + ' ' + isnull(a.strlastname,'') as studname,a.strsecondlanguage + ',' + a.strthirdlanguage as language,convert(varchar(11),a.strdateofbirth,106) as strdateofbirth,convert(varchar(10),a.stradmitdate,103) as stradmitdate,convert(varchar(10),a.Date_of_Registration,103) as Date_of_Registration,b.intCountryID,b.strcountryname as intcountry,c.intStateID,c.strstate as intstate,d.intCityID,d.strcity as intcity,a.strstandard+' - '+a.strsection as stdandsec,h.strbranch, a.* from tblstudent a";
        strsql += " LEFT OUTER JOIN tblcountry b ON a.intcountry=b.intCountryID";
        strsql += " LEFT OUTER JOIN tblstate c ON a.intstate=c.intStateID";
        strsql += " LEFT OUTER JOIN tblcity d ON a.intcity=d.intCityID";
        strsql += " LEFT OUTER JOIN tblschooldetails h ON h.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString() + ")";
        strsql += " where a.intschool=" + Session["SchoolID"].ToString() ;
        ///////////////////////////////////////////////////SEARCH STANDARD AND SECTION WITH LEFT SIDE SEARCH GROUP///////////////////////////////////////////////////////////////////////////
        if (TextBox1.Text != "")
        {
            strsql = strsql + " and a.strstandard + ' - ' + a.strsection in('" + TextBox1.Text.Replace(", ", "','") + "')";
            //search by Gender id value=2
            if (id == 2)
            {
                if (searchbygender.SelectedIndex > 1)
                {
                    strsql += " and a.strgender= '" + searchbygender.SelectedValue + "'";
                }
            }
            //search by Transport id value=3
            if (id == 3)
            {
                if (searchbytransport.SelectedValue == "School")
                {
                    strsql = strsql + " and a.inttransportdestination > '0'";
                }
                if (searchbytransport.SelectedValue == "Own")
                {
                    strsql = strsql + " and a.inttransportdestination= '0'";
                }
                else
                {
                    strsql = strsql + " and a.inttransportdestination>= '0'";
                }
            }
            //search by Hostler id value = 4
            if (id == 4)
            {
                if (searchbyhostler.SelectedValue == "Hostel Inmates")
                    strsql = strsql + " and a.hostler=1";

                if (searchbyhostler.SelectedValue == "dayscholor")
                    strsql = strsql + " and a.hostler=0";

                if (searchbyhostler.SelectedValue == "1")
                    strsql = strsql + " and a.hostler>=0";
            }
            //search by community id value = 5
            if (id == 5)
            {
                //if (searchbycommunity.SelectedIndex > 1)
                //    strsql = strsql + " and a.strcommunity= '" + searchbycommunity.SelectedValue + "'";
            }
            //search by religion id value = 6
            if (id == 6)
            {
                if (searchbyreligion.SelectedIndex > 1)
                {
                    if (searchbyreligion.SelectedValue == "Others")
                    {
                        strsql = strsql + " and a.strreligion not like 'Hindu' and a.strreligion not like 'Christian' and a.strreligion not like 'Muslim'";
                    }
                    else
                    {
                        strsql = strsql + " and a.strreligion= '" + searchbyreligion.SelectedValue + "'";
                    }
                }
            }
            //search by date of birth id value = 7
            if (id == 7)
            {
                if (searchbybirthday.SelectedIndex > 1)
                {
                    if (searchbybirthday.SelectedValue == "Today")
                    {
                        strsql = strsql + " and month(getdate())= month(a.strdateofbirth) and day(getdate())=day(a.strdateofbirth)";
                    }
                    else if (searchbybirthday.SelectedValue == "This Month")
                    {
                        strsql = strsql + " and month(getdate())= month(a.strdateofbirth)";
                    }
                    else if (searchbybirthday.SelectedValue == "This Week")
                    {
                        strsql = strsql + " and day(getdate()+5)>= day(a.strdateofbirth) and month(getdate())=month(a.strdateofbirth) and year(getdate())=year(a.strdateofbirth)";
                    }
                }
            }
            //search by blood group id value = 8
            if (id == 8)
            {
                if (searchbyblood.SelectedIndex > 1)
                    strsql = strsql + " and a.strbloodgroup= '" + searchbyblood.SelectedValue + "'";
            }
            //search by school house id value = 9
            if (id == 9)
            {
                if (searchbyhouse.SelectedIndex > 1)
                    strsql = strsql + " and a.strhouse= '" + searchbyhouse.SelectedValue + "'";
            }
            //search by Date of Birth from and to id value = 11
            if (id == 11)
            {
                if (DOBfromdate.Text != "" && DOBtodate.Text != "")
                    strsql = strsql + " and a.strdateofbirth between convert(datetime,'" + DOBfromdate.Text + "',103) and convert(datetime,'" + DOBtodate.Text + "',103) ";
            }
        }
        ///////////////////////////////////////////////////SEARCH INDIVIDUAL///////////////////////////////////////////////////////////////////////////
        //search by Gender id value=2
        if (id == 2)
        {
            if (searchbygender.SelectedIndex > 1)
            {
                strsql += " and a.strgender= '" + searchbygender.SelectedValue + "'";
            }
            else
            {
                strsql += " and a.strgender!=''";
            }
        }
        //search by Transport id value=3
        if (id == 3)
        {
            if (searchbytransport.SelectedValue == "School")
            {
                strsql = strsql + " and a.inttransportdestination > '0'";
            }
            if (searchbytransport.SelectedValue == "Own")
            {
                strsql = strsql + " and a.inttransportdestination= '0'";
            }
            else
            {
                strsql = strsql + " and a.inttransportdestination>= '0'";
            }
        }
        //search by Hostler id value = 4
        if (id == 4)
        {
            if (searchbyhostler.SelectedValue == "Hostel Inmates")
            {
                strsql = strsql + " and a.hostler=1";
                //strsqlunion += " and hostler=1";
            }
            if (searchbyhostler.SelectedValue == "dayscholor")
            {
                strsql = strsql + " and a.hostler=0";
                //strsqlunion += " and hostler=0";
            }
            if (searchbyhostler.SelectedValue == "1")
            {
                strsql = strsql + " and a.hostler>=0";
                //strsqlunion += " and hostler>=0";
            }
        }
        //search by community id value = 5
        if (id == 5)
        {
            //if (searchbycommunity.SelectedIndex > 1)
            //    strsql = strsql + " and a.strcommunity= '" + searchbycommunity.SelectedValue + "'";
            //else
            //    strsql = strsql + " and a.strcommunity!= ''";
        }
        //search by religion id value = 6
        if (id == 6)
        {
            if (searchbyreligion.SelectedIndex > 1)
            {
                if (searchbyreligion.SelectedValue == "Others")
                {
                    strsql = strsql + " and a.strreligion not like 'Hindu' and a.strreligion not like 'Christian' and a.strreligion not like 'Islam'";
                }
                else
                {
                    strsql = strsql + " and a.strreligion= '" + searchbyreligion.SelectedValue + "'";
                }
            }
            else
                strsql = strsql + " and a.strreligion!= ''";
        }
        //search by date of birth id value = 7
        if (id == 7)
        {
            if (searchbybirthday.SelectedIndex > 1)
            {
                if (searchbybirthday.SelectedValue == "Today")
                {
                    strsql = strsql + " and month(getdate())= month(a.strdateofbirth) and day(getdate())=day(a.strdateofbirth)";
                }
                else if (searchbybirthday.SelectedValue == "This Month")
                {
                    strsql = strsql + " and month(getdate())= month(a.strdateofbirth)";
                }
                else if (searchbybirthday.SelectedValue == "This Week")
                {
                    strsql = strsql + " and day(getdate()+5)>= day(a.strdateofbirth) and month(getdate())=month(a.strdateofbirth) and year(getdate())=year(a.strdateofbirth)";
                }
                else
                {
                    strsql = strsql + " and a.strdateofbirth !=''";
                }
            }
        }
        //search by blood group id value = 8
        if (id == 8)
        {
            if (searchbyblood.SelectedIndex > 1)
                strsql = strsql + " and a.strbloodgroup= '" + searchbyblood.SelectedValue + "'";
            else
                strsql = strsql + " and a.strbloodgroup!= ''";
        }
        //search by school house id value = 9
        if (id == 9)
        {
            if (searchbyhouse.SelectedIndex > 1)
                strsql = strsql + " and a.strhouse= '" + searchbyhouse.SelectedValue + "'";
            else
                strsql = strsql + " and a.strhouse!= ''";
        }
        //search by Date of Birth from and to id value = 11
        if (id == 11)
        {
            if (DOBfromdate.Text != "" && DOBtodate.Text != "")
                strsql = strsql + " and a.strdateofbirth between convert(datetime,'" + DOBfromdate.Text + "',103) and convert(datetime,'" + DOBtodate.Text + "',103) ";
        }
        /////////////////////////////////////////////////////////PRINT CUSTOM REPORT///////////////////////////////////////////////////////////////////
        DataSet1 ds = new DataSet1();
        da = new SqlDataAdapter(strsql, conn);
        da.Fill(ds, "tblstudent");
        if (ds.tblstudent.Rows.Count > 0)
        {
            string title = "";
            string classtitle = TextBox1.Text;
            if (TextBox1.Text != "")
            {
                if(chkAll.Checked==true)
                {
                    for (int j = 0; j < ds.tblstudent.Rows.Count; j++)
                    {
                        ds.Tables[0].Rows[j]["Reporttitle"] = "ALL";
                    }
                }
                else
                {
                    for (int j = 0; j < ds.tblstudent.Rows.Count; j++)
                {
                    ds.Tables[0].Rows[j]["Reporttitle"] = classtitle;
                }
                }
            }
            else
            {
                for (int j = 0; j < ds.tblstudent.Rows.Count; j++)
                {
                    ds.Tables[0].Rows[j]["Reporttitle"] = "ALL";
                }
            }
            //search by Gender id value=2 print report
            if (id == 2)
            {
                if (searchbygender.SelectedIndex > 0)
                {
                    title = searchbygender.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_gender_num.rpt");
                }
                else
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
            //search by Transport id value=3 print report
            if (id == 3)
            {
                if (searchbytransport.SelectedIndex > 0)
                {
                    string strtrans = "";
                    DataAccess dat = new DataAccess();
                    DataSet dst = new DataSet();
                    if (searchbytransport.SelectedIndex == 1)
                    {
                        strtrans = "select 'School' as strdestination,inttransportdestination from tblstudent where intschool='" + Session["SchoolID"] + "' and inttransportdestination >'0'";
                        strtrans += " union all select 'Own' as strdestination,inttransportdestination from tblstudent where intschool='" + Session["SchoolID"] + "' and inttransportdestination ='0'";
                    }
                    if (searchbytransport.SelectedValue == "School")
                    {
                        strtrans = "select 'School' as strdestination,inttransportdestination from tblstudent where intschool='" + Session["SchoolID"] + "' and inttransportdestination >'0'";
                    }
                    if (searchbytransport.SelectedValue == "Own")
                    {
                        strtrans = "select 'Own' as strdestination,inttransportdestination from tblstudent where intschool='" + Session["SchoolID"] + "' and inttransportdestination ='0'";
                    }
                    dst = dat.ExceuteSql(strtrans);
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.tblstudent.Rows.Count; i++)
                        {
                            ds.Tables[0].Rows[i]["inttransportdestination"] = dst.Tables[0].Rows[i]["strdestination"];
                        }
                    }
                    title = searchbytransport.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_transport_num.rpt");
                }
                else
                {
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            //search by Hostler id value = 4 print report
            if (id == 4)
            {
                if (searchbyhostler.SelectedIndex > 0)
                {
                    string strh = "";
                    DataAccess dah = new DataAccess();
                    DataSet dsh = new DataSet();
                    if (searchbyhostler.SelectedIndex == 1)
                    {
                        strh = "select 'Day Scholor' as hostler from tblstudent where intschool='" + Session["SchoolID"] + "' and hostler='0'";
                        strh += " union all select 'Residential' as hostler from tblstudent where intschool='" + Session["SchoolID"] + "' and hostler='1'";
                    }
                    if (searchbyhostler.SelectedValue == "Hostel Inmates")
                    {
                        strh = "select 'Residential' as hostler from tblstudent where intschool='" + Session["SchoolID"] + "' and hostler='1'";
                    }
                    if (searchbyhostler.SelectedValue == "dayscholor")
                    {
                        strh = "select 'Day Scholor' as hostler from tblstudent where intschool='" + Session["SchoolID"] + "' and hostler='0'";
                    }
                    dsh = dah.ExceuteSql(strh);
                    if (dsh.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.tblstudent.Rows.Count; j++)
                        {
                            ds.Tables[0].Rows[j]["hostler"] = dsh.Tables[0].Rows[j]["hostler"];
                        }
                    }
                    title = searchbyhostler.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_hostler_num.rpt");
                }
                else
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
            //search by community id value = 5 print report
            if (id == 5)
            {
                //if (searchbycommunity.SelectedIndex > 0)
                //{
                //    title = searchbycommunity.SelectedItem.Text;
                //    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                //    {
                //        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                //    }
                //    repFilePath = Server.MapPath("CR_Student/St_Strength_report/Cr_Student_comm_num.rpt");
                //}
                //else
                //    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
            //search by religion id value = 6 print report
            if (id == 6)
            {
                if (searchbyreligion.SelectedIndex > 0)
                {
                    title = searchbyreligion.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_religion_num.rpt");
                }
                else
                {
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            //search by date of birth id value = 7 print report
            if (id == 7)
            {
                if (searchbybirthday.SelectedIndex > 0)
                {
                    title = searchbybirthday.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_DOB_num.rpt");
                }
                else
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
            //search by blood group id value = 8 print report
            if (id == 8)
            {
                if (searchbyblood.SelectedIndex > 0)
                {
                    title = searchbyblood.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_BloodGp_num.rpt");
                }
                else
                {
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            //search by school house id value = 9 print report
            if (id == 9)
            {
                if (searchbyhouse.SelectedIndex > 0)
                {
                    title = searchbyhouse.SelectedItem.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_SHouse_num.rpt");
                }
                else
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
            //search by dateof birth from and to id value = 11 print report
            if (id == 11)
            {
                if (DOBfromdate.Text != "" && DOBtodate.Text != "")
                {
                    title = DOBfromdate.Text;
                    string todate = DOBtodate.Text;
                    for (int k = 0; k < ds.tblstudent.Rows.Count; k++)
                    {
                        ds.Tables[0].Rows[k]["Reportsortby"] = title;
                        ds.Tables[0].Rows[k]["DOBTodate"] = todate;
                    }
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_DOBFromandTo_num.rpt");
                }
                else
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
            //search by STANDARD id value = 13 print report
            if (id == 13)
            {
                //ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Reporttitle"] = all;
                if (TextBox1.Text != "")
                {
                    repFilePath = Server.MapPath("CR_Student/St_Strength_report/CR_Student_subreport.rpt");
                    
                }
                else
                {
                    repFilePath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            //search by STANDARD AND SECTION id value = 14 print report
            if (id == 0)
            {
                repFilePath = Server.MapPath("CR_Nodatafound.rpt");
            }
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
    protected void fillstandard()
    {
        string str = "select strstandard+' - '+strsection as Classandsec from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strstandard,strsection";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "Classandsec";
        ddlstandard.DataValueField = "Classandsec";
        ddlstandard.DataBind();
    }
    protected void fillhostler()
    {
        DataAccess da = new DataAccess();
        strsql = "select distinct hostler from tblstudent where intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        if (TextBox1.Text != "")
            strsql = strsql + "  and strstandard + ' - ' + strsection in('" + TextBox1.Text.Replace(",", "','") + "')";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbyhostler.DataSource = ds;
        searchbyhostler.DataTextField = "hostler";
        searchbyhostler.DataValueField = "hostler";
        searchbyhostler.DataBind();
        searchbyhostler.Items.Insert(0, "-Select-");
        searchbyhostler.Items.Insert(1, "All");
    }
    //protected void fillcommunity()
    //{
    //    DataAccess da = new DataAccess();
    //    strsql = "select distinct strcommunity from tblstudent where intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
    //    if (TextBox1.Text != "")
    //        strsql = strsql + "  and strstandard + ' - ' + strsection in('" + TextBox1.Text.Replace(",", "','") + "')";
    //    DataSet ds = new DataSet();
    //    ds = da.ExceuteSql(strsql);
    //    searchbycommunity.DataSource = ds;
    //    searchbycommunity.DataTextField = "strcommunity";
    //    searchbycommunity.DataValueField = "strcommunity";
    //    searchbycommunity.DataBind();
    //    searchbycommunity.Items.Insert(0, "-Select-");
    //    searchbycommunity.Items.Insert(1, "All");
    //}
    protected void fillreligion()
    {
        DataAccess da = new DataAccess();
        strsql = "select distinct strreligion from tblstudent where intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        if (TextBox1.Text != "")
            strsql = strsql + "  and strstandard + ' - ' + strsection in('" + TextBox1.Text.Replace(",", "','") + "')";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbyreligion.DataSource = ds;
        searchbyreligion.DataTextField = "strreligion";
        searchbyreligion.DataValueField = "strreligion";
        searchbyreligion.DataBind();
        searchbyreligion.Items.Insert(0, "-Select-");
        searchbyreligion.Items.Insert(1, "All");
    }
    protected void fillhousename()
    {
        DataAccess da = new DataAccess();
        strsql = "select distinct strhouse from tblstudent where intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        if (TextBox1.Text != "")
            strsql = strsql + "  and strstandard + ' - ' + strsection in('" + TextBox1.Text.Replace(",", "','") + "')";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbyhouse.DataSource = ds;
        searchbyhouse.DataTextField = "strhouse";
        searchbyhouse.DataValueField = "strhouse";
        searchbyhouse.DataBind();
        searchbyhouse.Items.Insert(0, "-Select-");
        searchbyhouse.Items.Insert(1, "All");
    }
    protected void fillbirthday()
    {
        searchbybirthday.Items.Clear();
        searchbybirthday.Items.Insert(0, "-Select-");
        searchbybirthday.Items.Insert(1, "All");
        searchbybirthday.Items.Insert(2, "Today");
        searchbybirthday.Items.Insert(3, "This Week");
        searchbybirthday.Items.Insert(4, "This Month");
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "";
        for (int i = 0; i < ddlstandard.Items.Count; i++)
        {
            if (ddlstandard.Items[i].Selected)
            {
                name += ddlstandard.Items[i].Text + ", ";
            }
        }
        TextBox1.Text = name;
        //SEARCH BY STANDARD ID VALUE = 13;
        Session["CR_Strength_report_ID"] = 13;
        if (ddlstandard.SelectedValue == "All")
        {
            fillreport(13);
        }
        else
        {
            fillreport(13);
        }
        if (name == "")
        {
            trsort.Visible = false;
        }
        else
        {
            trsort.Visible = true;
        }
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";

    }
    protected void DOBtodate_TextChanged(object sender, EventArgs e)
    {
        //SEARCH BY DATEOF BIRTH FROM AND TO ID VALUE = 11
        Session["CR_Strength_report_ID"] = 11;
        fillreport(11);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
    }
    protected void searchbygender_SelectedIndexChanged(object sender, EventArgs e)
    {
        //search by Gender id value=2
        Session["CR_Strength_report_ID"] = 2;
        fillreport(2);
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbytransport_SelectedIndexChanged(object sender, EventArgs e)
    {
        //search by Gender id value=3
        Session["CR_Strength_report_ID"] = 3;
        fillreport(3);
        searchbygender.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbyhostler_SelectedIndexChanged(object sender, EventArgs e)
    {
        // SEARCH BY HOSTLER ID VALUE = 4
        Session["CR_Strength_report_ID"] = 4;
        fillreport(4);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbycommunity_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SEARCH BY COMMUNITY ID VALUE = 5
        Session["CR_Strength_report_ID"] = 5;
        fillreport(5);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbyreligion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SEARCH BY RELIGION ID VALUE = 6
        Session["CR_Strength_report_ID"] = 6;
        fillreport(6);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbybirthday_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SEARCH BY BIRDAY ID VALUE = 7
        Session["CR_Strength_report_ID"] = 7;
        fillreport(7);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbyblood_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SEARCH BY BLOOK GROUP ID VALUE = 8
        Session["CR_Strength_report_ID"] = 8;
        fillreport(8);
        
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void searchbyhouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SEARCH BY SCHOOL HOUSE ID VALUE = 9
        Session["CR_Strength_report_ID"] = 9;
        fillreport(9);
        
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "";
        for (int i = 0; i < ddlstandard.Items.Count; i++)
        {
            if (ddlstandard.Items[i].Selected)
            {
                name += ddlstandard.Items[i].Text + ",";
            }
        }
        TextBox1.Text = name;
    }
}
