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

public partial class reports_Staffs_reports : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    public DataSet1 rds;
    public SqlDataAdapter rda;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CR_staff_report_ID"] = 0;
            fillstaff();
            fillexperience();
            ddldepart.Items.Insert(0, "-Select-");
            ddlstaffname.Items.Insert(0, "-Select-");
        }
        else
        {
            fillreport((int)Session["CR_staff_report_ID"]);
        }
    }
    protected void fillreport(int id)
    {
        SqlDataAdapter sda = new SqlDataAdapter();
        string reportfilepath = "";
        strsql = "select a.strfirstname + ' ' + isnull(a.strmiddlename,'') + ' ' + isnull(a.strlastname,'') as fullname,convert(varchar(11),dtdob,106) as dtdob,convert(varchar(11),dtDateofJoining,106) as dtDateofJoining, a.*,'' as Teachingsubjects, '' as strteachclass,b.strdepartmentname,c.strdesignation,d.strbranch,e.strcountryname as countryname,f.strstate as statename,g.strcity as cityname from tblemployee a ,tbldepartment b,tbldesignation c,tblschooldetails d,tblcountry e,tblstate f,tblcity g where a.intdepartment=b.intid and a.intdesignation=c.intid and a.intcountry=e.intcountryID and a.intstate=f.intstateID and a.intcity = g.intcityID and d.intschooldetailsid =(select max(intschooldetailsid) from tblschooldetails where intschoolid= '" + Session["SchoolID"].ToString() + "') and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedIndex > 0)
        {
            if (ddlstaff.SelectedValue == "All")
            {
                strsql += " and a.strtype !=''";
                if (ddldepart.SelectedValue == "All")
                {
                    strsql += " and a.intDepartment !=''";
                }
                //Search by Individual Name
                if (ddlstaffname.SelectedIndex > 0)
                {
                    strsql += " and a.intID ='" + ddlstaffname.SelectedValue + "'";
                }
            }
            if (ddlstaff.SelectedIndex > 1)
            {
                strsql += " and a.strtype ='"+ddlstaff.SelectedValue+"'";
                //search by Department
                if (ddldepart.SelectedValue == "All") 
                {
                    strsql += " and a.intDepartment !=''";
                }
                if (ddldepart.SelectedIndex > 1)
                {
                    strsql += " and a.intDepartment ='" + ddldepart.SelectedValue + "'";
                }
                //Search by Individual Name
                if (ddlstaffname.SelectedIndex > 0)
                {
                    strsql += " and a.intID ='"+ ddlstaffname.SelectedValue +"'";
                }
                //Search by Gender
                if (id == 4)
                {
                    if (searchbygender.SelectedIndex > 1)
                    {
                        strsql += " and a.strGender = '" + searchbygender.SelectedValue + "'";
                    }
                    else
                    {
                        strsql += " and a.strGender !=''";
                    }
                }
                //Search by Years of Experience
                if (id == 5)
                {
                    if (searchbyExperience.SelectedIndex > 1)
                    {
                        strsql += " and a.intexpyear = '" + searchbyExperience.SelectedValue + "'";
                    }
                    else
                    {
                        strsql += " and a.intexpyear > '0'";
                    }
                }
                //Search by Community 
                if (id == 6)
                {
                    //if (searchbycommunity.SelectedIndex > 1)
                    //{
                    //    strsql += " and a.strcommunity = '" + searchbycommunity.SelectedValue + "'";
                    //}
                    //else
                    //{
                    //    strsql += " and a.strcommunity !=''";
                    //}
                }
                //Search by Staff Birthday
                if (id == 7)
                {
                    if (searchbybirthday.SelectedValue == "Today")
                        strsql = strsql + " and month(getdate())= month(a.dtdob) and day(getdate())=day(a.dtdob) ";
                    if (searchbybirthday.SelectedValue == "This Week")
                        strsql = strsql + " and Month(a.dtdob)= Month(getdate()) and Day(a.dtdob) Between (Day(Getdate())) And (Day(dateadd(dd,7,getdate())))";
                    if (searchbybirthday.SelectedValue == "This Month")
                        strsql = strsql + " and month(getdate())= month(a.dtdob) ";
                }
                //Search by Blood Group
                if (id == 8)
                {
                    if (searchbyblood.SelectedIndex > 1)
                    {
                        strsql += " and a.strblood = '" + searchbyblood.SelectedValue + "'";
                    }
                    else
                    {
                        strsql += " and a.strblood!=''";
                    }
                }
                //Search by Transport
                if (id == 9)
                {
                    if (searchbytransport.SelectedIndex > 1)
                    {
                        strsql += " and a.transport = '" + searchbytransport.SelectedValue + "'";
                    }
                    else
                    {
                        strsql += " and a.transport !=''";
                    }
                }
                //Search by Date of Birth between from date and todat
                if (id == 10)
                {
                    if (DOBfromdate.Text != "" && DOBtodate.Text != "")
                    {
                        strsql += " and a.dtDOB between '" + DOBfromdate.Text + "' and '" + DOBtodate.Text + "'";
                    }
                }
                //search by Date of Joining in the school between from and todates
                if (id == 11)
                {
                    if (DOJFromdate.Text != "" && DOJTodate.Text != "")
                    {
                        strsql += " and a.dtDateofJoining between '" + DOJFromdate.Text + "' and '" + DOJTodate.Text + "'";
                    }
                }
            }
        }
        //////////////////////////////////////////////////////-SEARCH INDIVIDUAL -///////////////////////////////////////////////////////////////////////////
        //search by Gender 
        if (id == 4)
        {
            if (searchbygender.SelectedIndex > 1)
            {
                strsql += " and a.strGender = '" + searchbygender.SelectedValue + "'";
            }
            else
            {
                strsql += " and a.strGender !=''";
            }
        }
        //Search by Years of Experience
        if (id == 5)
        {
            if (searchbyExperience.SelectedIndex > 1)
            {
                strsql += " and a.intexpyear = '" + searchbyExperience.SelectedValue + "'";
            }
            else
            {
                strsql += " and a.intexpyear > '0'";
            }
        }
        //Search by Community 
        if (id == 6)
        {
            //if (searchbycommunity.SelectedIndex > 1)
            //{
            //    strsql += " and a.strcommunity = '" + searchbycommunity.SelectedValue + "'";
            //}
            //else
            //{
            //    strsql += " and a.strcommunity !=''";
            //}
        }
        //Search by Staff Birthday
        if (id == 7)
        {
            if (searchbybirthday.SelectedValue == "Today")
                strsql = strsql + " and month(getdate())= month(a.dtdob) and day(getdate())=day(a.dtdob) ";
            if (searchbybirthday.SelectedValue == "This Week")
                strsql = strsql + " and Month(a.dtdob)= Month(getdate()) and Day(a.dtdob) Between (Day(Getdate())) And (Day(dateadd(dd,7,getdate())))";
            if (searchbybirthday.SelectedValue == "This Month")
                strsql = strsql + " and month(getdate())= month(a.dtdob) ";
        }
        //Search by Blood Group
        if (id == 8)
        {
            if (searchbyblood.SelectedIndex > 1)
            {
                strsql += " and a.strblood = '" + searchbyblood.SelectedValue + "'";
            }
            else
            {
                strsql += " and a.strblood!=''";
            }
        }
        //Search by Transport
        if (id == 9)
        {
            if (searchbytransport.SelectedIndex > 1)
            {
                strsql += " and a.transport = '" + searchbytransport.SelectedValue + "'";
            }
            else
            {
                strsql += " and a.transport !=''";
            }
        }
        //Search by Date of Birth between from date and todat
        if (id == 10)
        {
            if (DOBfromdate.Text != "" && DOBtodate.Text != "")
            {
                strsql += " and a.dtDOB between '" + DOBfromdate.Text + "' and '" + DOBtodate.Text + "'";
            }
        }
        //search by Date of Joining in the school between from and todates
        if (id == 11)
        {
            if (DOJFromdate.Text != "" && DOJTodate.Text != "")
            {
                strsql += " and a.dtDateofJoining between '" + DOJFromdate.Text + "' and '" + DOJTodate.Text + "'";
            }
        }
        ////////////////////////////////////////////////////////////////////PRINT REPORT FOR SELECTED SORT OPTION////////////////////////////////////////
        DataSet1 rds = new DataSet1();
        rda = new SqlDataAdapter(strsql, conn);
        rda.Fill(rds, "tblemployee");
        if (rds.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
            {
                rds.Tables[1].Rows[i]["ReportGeneratedby"] = "Barathi A";
                if(ddlstaff.SelectedIndex > 1)
                    rds.Tables[1].Rows[i]["sortbyStafftype"] = ddlstaff.SelectedValue;
                if(ddlstaff.SelectedIndex <=1)
                    rds.Tables[1].Rows[i]["sortbyStafftype"] = "All";
                if (ddldepart.SelectedIndex > 1)
                    rds.Tables[1].Rows[i]["sortbyDept"] = ddldepart.SelectedItem.Text;
                if (ddldepart.SelectedIndex <= 1)
                    rds.Tables[1].Rows[i]["sortbyDept"] = "All";
            }
            if (id == 1) // Report for Selected Staff Type
            {
                if (ddlstaff.SelectedIndex > 0)
                {
                    reportfilepath = Server.MapPath("CR_Staff/CR_Stafftype.rpt");
                }
                else
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
            }
            if (id == 2) // Report for selected Department
            {
                reportfilepath = Server.MapPath("CR_Staff/CR_Stafftype.rpt");
            }
            if (id == 3) // Report for individual Name
            {
                if (ddlstaffname.SelectedIndex > 0)
                {
                    string sqlquery = "";
                    string teachingsubject = "";
                    DataAccess da_staff = new DataAccess();
                    DataSet ds_staff = new DataSet();
                    sqlquery = "select distinct strteachsubject from tblteachingsubjects where intschool='"+Session["SchoolID"]+"' and intemployee = '"+ddlstaffname.SelectedValue+"'";
                    ds_staff = da_staff.ExceuteSql(sqlquery);
                    if (ds_staff.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_staff.Tables[0].Rows.Count;i++ )
                        {
                            if (i == 0)
                            {
                                teachingsubject = ds_staff.Tables[0].Rows[i]["strteachsubject"].ToString();
                            }
                            else
                            {
                                teachingsubject = teachingsubject + ", " + ds_staff.Tables[0].Rows[i]["strteachsubject"].ToString();
                            }
                        }
                        rds.Tables[1].Rows[0]["Teachingsubjects"] = teachingsubject;
                    }
                    else
                    {
                        rds.Tables[1].Rows[0]["Teachingsubjects"] = "Nil";
                    }
                    string Teachingclass = "";
                    ds_staff = new DataSet();
                    sqlquery = "select distinct strteachclass from tblteachingclass where intemployee='"+ddlstaffname.SelectedValue+"' and intschool = '"+Session["SchoolID"]+"'";
                    ds_staff = da_staff.ExceuteSql(sqlquery);
                    if (ds_staff.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_staff.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                Teachingclass = ds_staff.Tables[0].Rows[i]["strteachclass"].ToString();
                            }
                            else
                            {
                                Teachingclass = Teachingclass + ", " + ds_staff.Tables[0].Rows[i]["strteachclass"].ToString();
                            }
                        }
                        rds.Tables[1].Rows[0]["TeachingClass"] = Teachingclass;
                    }
                    else
                    {
                        rds.Tables[1].Rows[0]["TeachingClass"] = "Nil";
                    }
                    string Homeclass = "";
                    ds_staff = new DataSet();
                    sqlquery = "select strhomeclass from tblhomeclass where intemployee = '" + ddlstaffname.SelectedValue + "' and intschool = '" + Session["SchoolID"] + "'";
                    ds_staff = da_staff.ExceuteSql(sqlquery);
                    if (ds_staff.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_staff.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                Homeclass = ds_staff.Tables[0].Rows[i]["strhomeclass"].ToString();
                            }
                            else
                            {
                                Homeclass = Homeclass + ", " + ds_staff.Tables[0].Rows[i]["strhomeclass"].ToString();
                            }
                        }
                        rds.Tables[1].Rows[0]["Homeclass"] = Homeclass;
                    }
                    else
                    {
                        rds.Tables[1].Rows[0]["Homeclass"] = "Nil";
                    }
                    string strmode = "";
                    string strdegree = "";
                    string strmajor = "";
                    string strinstitution = "";
                    string intyearpass = "";
                    string intpercent = "";
                    ds_staff = new DataSet();
                    sqlquery = "select strmode,strdegree,strmajor,strinstitution,intyearpass,intpercent from tblemployeeeducation where intemployee = '" + ddlstaffname.SelectedValue + "' and intschool = '" + Session["SchoolID"] + "'";
                    ds_staff = da_staff.ExceuteSql(sqlquery);
                    if (ds_staff.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_staff.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                strmode = ds_staff.Tables[0].Rows[i]["strmode"].ToString();
                                strdegree = ds_staff.Tables[0].Rows[i]["strdegree"].ToString();
                                strmajor = ds_staff.Tables[0].Rows[i]["strmajor"].ToString();
                                strinstitution = ds_staff.Tables[0].Rows[i]["strinstitution"].ToString();
                                intyearpass = ds_staff.Tables[0].Rows[i]["intyearpass"].ToString();
                                intpercent = ds_staff.Tables[0].Rows[i]["intpercent"].ToString();
                            }
                            else
                            {
                                strmode += "\n\n" + ds_staff.Tables[0].Rows[i]["strmode"].ToString();
                                strdegree += "\n\n" + ds_staff.Tables[0].Rows[i]["strdegree"].ToString();
                                strmajor += "\n\n" + ds_staff.Tables[0].Rows[i]["strmajor"].ToString();
                                strinstitution += "\n\n" + ds_staff.Tables[0].Rows[i]["strinstitution"].ToString();
                                intyearpass += "\n\n" + ds_staff.Tables[0].Rows[i]["intyearpass"].ToString();
                                intpercent += "\n\n" + ds_staff.Tables[0].Rows[i]["intpercent"].ToString();
                            }
                        }
                        rds.Tables[1].Rows[0]["Edustrmode"] = strmode;
                        rds.Tables[1].Rows[0]["Edustrdegree"] = strdegree;
                        rds.Tables[1].Rows[0]["Edustrmajor"] = strmajor;
                        rds.Tables[1].Rows[0]["Edustrinstitution"] = strinstitution;
                        rds.Tables[1].Rows[0]["Eduintyearpass"] = intyearpass;
                        rds.Tables[1].Rows[0]["Eduintpercent"] = intpercent;
                    }
                    else
                    {
                        rds.Tables[1].Rows[0]["Edustrmode"] = "Nil";
                        rds.Tables[1].Rows[0]["Edustrdegree"] = "Nil";
                        rds.Tables[1].Rows[0]["Edustrmajor"] = "Nil";
                        rds.Tables[1].Rows[0]["Edustrinstitution"] = "Nil";
                        rds.Tables[1].Rows[0]["Eduintyearpass"] = "Nil";
                        rds.Tables[1].Rows[0]["Eduintpercent"] = "Nil";
                    }

                    string organization = "";
                    string fromperiod = "";
                    string toperiod = "";
                    string workdepartment = "";
                    string workdesignation = "";
                    ds_staff = new DataSet();
                    sqlquery = "select convert(varchar(10),dtperiodfrom,103) as dtperiodfrom,convert(varchar(10),dtperiodto,103) as dtperiodto,* from tblemployeeexperience where intemployee = '" + ddlstaffname.SelectedValue + "' and intschool = '" + Session["SchoolID"] + "'";
                    ds_staff = da_staff.ExceuteSql(sqlquery);
                    if (ds_staff.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_staff.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                organization = ds_staff.Tables[0].Rows[i]["strorganization"].ToString();
                                fromperiod = ds_staff.Tables[0].Rows[i]["dtperiodfrom"].ToString();
                                toperiod = ds_staff.Tables[0].Rows[i]["dtperiodto"].ToString();
                                workdepartment = ds_staff.Tables[0].Rows[i]["strdepartment"].ToString();
                                workdesignation = ds_staff.Tables[0].Rows[i]["strdesignation"].ToString();
                            }
                            else
                            {
                                organization += "\n\n" + ds_staff.Tables[0].Rows[i]["strorganization"].ToString();
                                fromperiod += "\n\n" + ds_staff.Tables[0].Rows[i]["dtperiodfrom"].ToString();
                                toperiod += "\n\n" + ds_staff.Tables[0].Rows[i]["dtperiodto"].ToString();
                                workdepartment += "\n\n" + ds_staff.Tables[0].Rows[i]["strdepartment"].ToString();
                                workdesignation += "\n\n" + ds_staff.Tables[0].Rows[i]["strdesignation"].ToString();
                            }
                        }
                        rds.Tables[1].Rows[0]["Workorganization"] = organization;
                        rds.Tables[1].Rows[0]["Workfromperiod"] = fromperiod;
                        rds.Tables[1].Rows[0]["Worktoperiod"] = toperiod;
                        rds.Tables[1].Rows[0]["Workworkdepartment"] = workdepartment;
                        rds.Tables[1].Rows[0]["Workworkdesignation"] = workdesignation;
                    }
                    else
                    {
                        rds.Tables[1].Rows[0]["Workorganization"] = "Nil";
                        rds.Tables[1].Rows[0]["Workfromperiod"] = "Nil";
                        rds.Tables[1].Rows[0]["Worktoperiod"] = "Nil";
                        rds.Tables[1].Rows[0]["Workworkdepartment"] = "Nil";
                        rds.Tables[1].Rows[0]["Workworkdesignation"] = "Nil";
                    }
                    for (int k = 0; k < rds.Tables[1].Rows.Count; k++)
                    {
                        FileStream fs;
                        BinaryReader br;
                        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "images/staff/" + ddlstaffname.SelectedValue + ".jpg"))
                        {
                            fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "images/staff/" + ddlstaffname.SelectedValue + ".jpg", FileMode.Open);
                        }
                        else
                        {
                            fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/images/NoPhotoAvailable.jpg", FileMode.Open);
                        }
                        br = new BinaryReader(fs);
                        byte[] imgbyte = new byte[fs.Length + 1];
                        imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                        rds.Tables[1].Rows[k]["image_stream"] = imgbyte;
                        br.Close();
                        fs.Close();
                    }
                }
                reportfilepath = Server.MapPath("CR_Staff/CR_Staff_Individual.rpt");
            }
            if (id == 4) // Report for gender
            {

                if (searchbygender.SelectedIndex > 0)
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = searchbygender.SelectedValue;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_Gender.rpt");
                }
                else
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
            }
            if (id == 5) // Report for Experience
            {
                if (searchbyExperience.SelectedIndex > 0)
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = searchbyExperience.SelectedValue;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_Experience.rpt");
                }
                else
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
            }
            if (id == 6) // Report for Community
            {
                //if (searchbycommunity.SelectedIndex > 0)
                //{
                //    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                //    {
                //        rds.Tables[1].Rows[i]["Reportsortby"] = searchbycommunity.SelectedValue;
                //    }
                //    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_Community.rpt");
                //}
                //else
                //{
                //    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                //}
            }
            if (id == 7) // Report for Birthday
            {
                if (searchbybirthday.SelectedIndex > 0)
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = searchbybirthday.SelectedValue;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_Birthday.rpt");
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            if (id == 8) // Report for Blood group
            {
                if (searchbyblood.SelectedIndex > 0)
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = searchbyblood.SelectedValue;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_BloodGP.rpt");
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            if (id == 9) // Report for Transport
            {
                if (searchbytransport.SelectedIndex > 0)
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = searchbytransport.SelectedValue;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_transport.rpt");
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            if (id == 10) // Report for Date Of Birth
            {
                if (DOBfromdate.Text !="" && DOBtodate.Text !="")
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = DOBfromdate.Text;
                        rds.Tables[1].Rows[i]["SortbyTodate"] = DOBtodate.Text;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_DOBfandT.rpt");
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            if (id == 11) // Report for Date of Joined
            {
                if (DOJFromdate.Text != "" && DOJTodate.Text != "")
                {
                    for (int i = 0; i < rds.Tables[1].Rows.Count; i++)
                    {
                        rds.Tables[1].Rows[i]["Reportsortby"] = DOJFromdate.Text;
                        rds.Tables[1].Rows[i]["SortbyTodate"] = DOJTodate.Text;
                    }
                    reportfilepath = Server.MapPath("CR_Staff/CR_Staff_DOJ.rpt");
                }
                else
                {
                    reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
                }
            }
            if (id == 0) // IF Data not found while sorting the report
            {
                reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
            }
            ReportDocument staffrep = new ReportDocument();
            staffrep.Load(reportfilepath);
            staffrep.SetDataSource(rds);
            CrystalReportViewer1.ReportSource = staffrep;
            CrystalReportViewer1.DataBind();
        }
        else
        {
            reportfilepath = Server.MapPath("CR_Nodatafound.rpt");
            ReportDocument staffrep = new ReportDocument();
            staffrep.Load(reportfilepath);
            staffrep.SetDataSource(rds);
            CrystalReportViewer1.ReportSource = staffrep;
            CrystalReportViewer1.DataBind();
        }
    }
    protected void fillstaff()
    {
        strsql = " select strstafftype from tblstafftype ";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaff.DataSource = ds;
        ddlstaff.DataTextField = "strstafftype";
        ddlstaff.DataValueField = "strstafftype";
        ddlstaff.DataBind();
        ddlstaff.Items.Insert(0, "-Select-");
        ddlstaff.Items.Insert(1, "All");
    }
    protected void filldept()
    {
        if (ddlstaff.SelectedIndex > 1)
        {
            strsql = "select b.strdepartmentname,b.intid from tblemployee a, tbldepartment b where b.intid=a.intdepartment and a.intschool= " + Session["SchoolID"].ToString() + " and a.strtype= '" + ddlstaff.SelectedValue + "' group by b.strdepartmentname,b.intid";
        }
        if (ddlstaff.SelectedValue == "All")
        {
            strsql = "select b.strdepartmentname,b.intid from tblemployee a, tbldepartment b where b.intid=a.intdepartment and a.intschool= " + Session["SchoolID"].ToString() + " and a.strtype= '' group by b.strdepartmentname,b.intid";
        }
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldepart.DataSource = ds;
        ddldepart.DataTextField = "strdepartmentname";
        ddldepart.DataValueField = "intid";
        ddldepart.DataBind();
        ddldepart.Items.Insert(0, "-Select-");
        ddldepart.Items.Insert(1, "All");
    }
    protected void fillstaffname()
    {
        strsql = "";
        strsql = "select intid, strfirstname + ' ' + strmiddlename + ' ' + strlastname as name from tblemployee where intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedIndex > 1)
            strsql += " and strtype='" + ddlstaff.SelectedValue + "'";
        if (ddldepart.SelectedIndex > 1)
            strsql += " and intDepartment=" + ddldepart.SelectedValue;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "name";
        ddlstaffname.DataValueField = "intid";
        ddlstaffname.DataBind();
        ddlstaffname.Items.Insert(0, "-Select-");
    }
    protected void fillexperience()
    {
        strsql = "select intexpyear from tblemployee where intschool = " + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedIndex > 1)
        {
            strsql += " and strtype='"+ddlstaff.SelectedValue+"'";
        }
        if (ddldepart.SelectedIndex > 1)
        {
            strsql += " and intDepartment = '"+ ddldepart.SelectedValue+"'";
        }
        strsql += " group by intexpyear";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbyExperience.DataSource = ds;
        searchbyExperience.DataTextField = "intexpyear";
        searchbyExperience.DataValueField = "intexpyear";
        searchbyExperience.DataBind();
        searchbyExperience.Items.Insert(0,"-Select-");
        searchbyExperience.Items.Insert(1,"All");
    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["CR_staff_report_ID"] = 1;
        fillreport(1);
        if (ddlstaff.SelectedValue == "All")
        {
            filldept();
            fillstaffname();
            ddldepart.SelectedIndex = 1;
        }
        if(ddlstaff.SelectedIndex > 1)
        {
            filldept();
            fillstaffname();
        }
        if (ddlstaff.SelectedIndex == 0)
        {
            ddldepart.Items.Clear();
            ddldepart.Items.Insert(0,"-Select-");
            ddlstaffname.Items.Clear();
            ddlstaffname.Items.Insert(0,"-Select-");
        }
        
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void ddldepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["CR_staff_report_ID"] = 2;
        fillstaffname();
        fillreport(2);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
      
    }
    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["CR_staff_report_ID"] = 3;
        fillreport(3);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";

    }
    
    protected void searchbygender_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 4;
        fillreport(4);
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void searchbyExperience_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 5;
        fillreport(5);
        searchbygender.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void searchbycommunity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 6;
        fillreport(6);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void searchbybirthday_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 7;
        fillreport(7);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void searchbyblood_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 8;
        fillreport(8);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void searchbytransport_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 9;
        fillreport(9);
        searchbygender.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void DOBtodate_TextChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 10;
        fillreport(10);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOJFromdate.Text = "";
        DOJTodate.Text = "";
    }
    protected void DOJTodate_TextChanged(object sender, EventArgs e)
    {
        ddlstaffname.SelectedIndex = 0;
        Session["CR_staff_report_ID"] = 11;
        fillreport(11);
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyExperience.SelectedIndex = 0;
        DOBfromdate.Text = "";
        DOBtodate.Text = "";
    }
   
}
