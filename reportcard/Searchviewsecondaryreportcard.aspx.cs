using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Web.Mail;
using System.ComponentModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections.Generic;



public partial class reportcard_Searchviewsecondaryreportcard : System.Web.UI.Page
{
    public string strsql,strMsg;
    public DataAccess da,da1,da2,da3;
    public DataSet ds,ds1,ds2,ds3;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlexamtype.Items.Insert(0, "--Select--");
            if (Request["hid"] != null)
            {

                if (Session["SearchStudentStandard"] != null)
                {
                    ddlstandard.SelectedValue = Session["SearchStudentStandard"].ToString();
                    fillbystandard();
                    fillgrid();
                }
                if (Session["SearchStudentExamtype"] != null)
                {
                    ddlexamtype.SelectedValue = Session["SearchStudentExamtype"].ToString();
                    fillbyexamtype();
                    fillgrid();
                }

            }
        }
    }

    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strstandard from tblsecondaryreportcard group by strstandard";
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
    }
    protected void fillteacher()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.intid,b.inthometeacher from tblemployee a,tblsecondaryreportcard b where a.intid=b.inthometeacher and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["Schoolid"].ToString() + " group by a.strfirstname,a.strmiddlename,a.strlastname,a.intid,b.inthometeacher";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblteacher.Text = ds.Tables[0].Rows[0]["name"].ToString();
        }
    }
    protected void fillexamtype()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strexamtype,a.intexamtypeid,b.intexamtype from tblexamtype a,tblsecondaryreportcard b where a.intexamtypeid=b.intexamtype group by a.strexamtype,a.intexamtypeid,b.intexamtype";
        ds = da.ExceuteSql(str);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "intexamtype";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0, "--Select--");
    }
    protected void fillbystandard()
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillgrid();
            fillteacher();
            fillexamtype();
        }
        else
        {
            ddlexamtype.Items.Clear();
            ddlexamtype.Items.Insert(0, "--Select--");
            fillgrid();
        }
        Session["SearchStudentStandard"] = ddlstandard.SelectedValue;
    }
    protected void fillbyexamtype()
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            fillgrid();

        }
        else
        {

            fillgrid();
        }
        Session["SearchStudentExamtype"] = ddlexamtype.SelectedValue;
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillteacher();
        fillexamtype();
        fillbystandard();
        //fillgrid();
    }
    protected void fillgrid()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,b.intstudent,b.stradmissionno,b.intexamtype,b.inthometeacher from tblstudent a,tblsecondaryreportcard b where b.strstandard='" + ddlstandard.SelectedValue + "' and b.intstudent=a.intid and a.intschool=" + Session["Schoolid"].ToString();
        if (ddlexamtype.SelectedIndex > 0)
        {
            str = str + " and b.intexamtype='" + ddlexamtype.SelectedValue + "'";
        }
        str = str + " group by a.strfirstname,a.strmiddlename,a.strlastname,b.intstudent,b.stradmissionno,b.intexamtype,b.inthometeacher";
        ds = da.ExceuteSql(str);
        dgstudent.DataSource = ds;
        dgstudent.DataBind();
    }
    protected void dgstudent_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("viewsecondaryreportcard.aspx?hid=" + e.Item.Cells[1].Text + "&hid3='" + e.Item.Cells[3].Text + "'&hid1=" + e.Item.Cells[4].Text + "&hid2=" + e.Item.Cells[5].Text + " &sbackto=0");
    }
    protected void chkhead_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkSelectAll = sender as CheckBox;
            foreach (DataGridItem gvr in dgstudent.Items)
            {
                CheckBox chkSelect = gvr.FindControl("chk") as CheckBox;
                if (chkSelect != null)
                {
                    chkSelect.Checked = chkSelectAll.Checked;
                }
            }
        }
        catch { }
    }
    protected void dgstudent_EditCommand(object source, DataGridCommandEventArgs e)
    {
        createpdf(e.Item.Cells[1].Text, e.Item.Cells[3].Text, e.Item.Cells[4].Text, e.Item.Cells[5].Text);
    }
    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillbyexamtype();
        fillgrid();
    }
   
    protected void btnprintall_Click(object sender, EventArgs e)
    {
       creadpdfall();
    }

    protected void createpdf(string hid, string hid1, string hid2, string hid3)
    {
        try
        {
            string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Secondaryreportcard.pdf";
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filepath.ToString(), FileMode.Create));
            StringBuilder strB = new StringBuilder();
            doc.Open();
            doc.NewPage();

            string strMsg = " <br /><br /> <br />";
            string url = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png";
            strMsg = strMsg + "<div style='width:100%;text-align:center'><img src='" + url + "' alt='' style='align:center' /></div><br />";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str;
            str = "select a.strstandard,a.intstudent,a.stradmissionno,b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,c.strfirstname+''+c.strmiddlename+''+c.strlastname as name1, d.strexamtype from tblsecondaryreportcard a,tblstudent b,tblemployee c,tblexamtype d where a.intstudent=b.intid";
            str = str + " and a.inthometeacher=c.intid and a.intexamtype=d.intexamtypeid and c.intschool=" + Session["Schoolid"].ToString() + " and a.intexamtype='"+hid3.ToString()+"' and a.intstudent='"+hid.ToString()+"' group by a.strstandard,a.stradmissionno,b.intid,b.strfirstname,b.strmiddlename,b.strlastname,c.strfirstname,c.strmiddlename,c.strlastname,d.strexamtype,a.intstudent";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {

                strMsg = "";
                strMsg = strMsg + "<table >";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"4\" valign=\"bottom\" align=\"center\"><font face=\"Verdana\" style=\"font-size:12px;\" color=\"#000000\"><b>STUDENT PROGRESS</b></font></td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + " <font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Standard:</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["strstandard"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Student Name:</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["name"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Class Teacher:</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["name1"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Exam Type:</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["strexamtype"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Student No</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["stradmissionno"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Attendance:</b></font>";
                strMsg = strMsg + "</td>";
                strsql = "select convert(varchar(10),startdate,111) as startdate from tblacademicyear where intschool=" + Session["SchoolID"].ToString();
                da = new DataAccess();
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                DateTime dtstartdate = DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString());
                strsql = "select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" +ddlexamtype.SelectedItem.Text+ "' and intschool=" + Session["Schoolid"].ToString() + " order by dtexamdate desc";
                da1 = new DataAccess();
                ds1 = new DataSet();
                ds1 = da1.ExceuteSql(strsql);
                DateTime dtenddate = DateTime.Parse(ds1.Tables[0].Rows[0]["dtexamdate"].ToString());

                strsql = "select totaldays-holidays as workingdays from (select datediff(day,startdate,dtexamdate) as totaldays from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" +ddlexamtype.SelectedItem.Text+ "' order by dtexamdate desc) as b) as a,";
                strsql = strsql + " (select count(*) as holidays from tblacademiccalender c,(select * from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" +ddlexamtype.SelectedItem.Text+ "' order by dtexamdate desc) as b) as d where c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
                da = new DataAccess();
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                int workingdays = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                int weeklyholidays = 0;

                strsql = "select strweekholidays from tblworkingdays where intschoolid=" + Session["Schoolid"].ToString() + " and strmode='Holiday'";
                da1 = new DataAccess();
                ds1 = new DataSet();
                ds1 = da1.ExceuteSql(strsql);
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    int intday = 0;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Sunday")
                        intday = 1;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Monday")
                        intday = 2;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Tuesday")
                        intday = 3;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Wednesday")
                        intday = 4;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Thursday")
                        intday = 5;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Friday")
                        intday = 6;
                    if (ds1.Tables[0].Rows[i][0].ToString() == "Saturday")
                        intday = 7;

                    strsql = "select dbo.NumberOfSundays('" + dtstartdate + "','" + dtenddate + "'," + intday + ")";
                    da2 = new DataAccess();
                    ds2 = new DataSet();
                    ds2 = da2.ExceuteSql(strsql);
                    weeklyholidays = weeklyholidays + int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                }
                int workingdays1;
                workingdays1 = workingdays - weeklyholidays;
                double intstudentleave = 0.00;
                strsql = "select fullleave + halfleave as studentleave from (select count(*) as fullleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
                strsql = strsql + "(select top 1 dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" +ddlexamtype.SelectedItem.Text+ "' order by dtexamdate desc) as b) as d where c.strsession='Full Day' and c.intstudent=" +hid.ToString()+ " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as a,";
                strsql = strsql + " (select count(*)*.5 as halfleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
                strsql = strsql + " (select top 1 dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" +ddlexamtype.SelectedItem.Text+ "' order by dtexamdate desc) as b) as d where c.strsession!='Full Day' and c.intstudent=" +hid.ToString()+ " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
                da3 = new DataAccess();
                ds3 = new DataSet();
                ds3 = da3.ExceuteSql(strsql);

                intstudentleave = double.Parse(ds3.Tables[0].Rows[0][0].ToString());
                double presentdays = workingdays1 - intstudentleave;
                double percentage = ((presentdays / workingdays1) * 100);
                lblattendance.Text = percentage.ToString() + " %";

                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">" + lblattendance.Text + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"4\" align=\"center\"><font size=\"9px\"><b>PURPOSE OF REPORTING STUDENT PROGRESS</b></font></td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"4\">";
                strMsg = strMsg + "<font size=\"8px\">This report card is designed to provide you with an accurate interpretation of your child’s achievement on graded curriculum over a period of time. It emphasizes “how” students learn and where they are on the learning continuum, rather than “what” students learn.</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"4\">";
                strMsg = strMsg + "<font size=\"8px\">It also reflects the consistency of the skills outcomes across all grade levels Kindergarten through Grade 9. It will assist you and your child in understanding areas of strength, areas for growth and strategies for improvement. The report card is one means of reporting achievement and it should be considered within a comprehensive approach to reporting learning (e.g. student led conferences, celebrations of learning, digital portfolios, emails, blogs, etc.). If you require more information, or have any questions about the information contained in this report please contact the school at your earliest convenience. Meaningful communication is important in order to support student learning.</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "</table>";
            }

            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            strMsg = "";
            strMsg = strMsg + "<table>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"center\" colspan=\"2\">";
            strMsg = strMsg + "<font size=\"9px\"><b>INDICATORS OF ACHIEVEMENT</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
            strMsg = strMsg + "<font size=\"8px\">The level at which your child is demonstrating learning in relation to the expectation for this time in the school year is reported by the following indicators: </font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"center\">";
            strMsg = strMsg + "<font size=\"9px\"><b>Indicator</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td align=\"left\">";
            strMsg = strMsg + "<font size=\"9px\"><b>Description</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"center\">";
            strMsg = strMsg + "<font size=\"8px\">A</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td align=\"left\">";
            strMsg = strMsg + "<font size=\"8px\">Well above the standard expected at this time of year</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"center\">";
            strMsg = strMsg + "<font size=\"8px\">B</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td align=\"left\">";
            strMsg = strMsg + "<font size=\"8px\">Above the standard expected at this time of year</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"center\">";
            strMsg = strMsg + "<font size=\"8px\">C</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td align=\"left\">";
            strMsg = strMsg + "<font size=\"8px\">At the standard expected at this time of year</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>  ";
            strMsg = strMsg + "<td align=\"center\">";
            strMsg = strMsg + "<font size=\"8px\">D</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td align=\"left\">";
            strMsg = strMsg + "<font size=\"8px\">Below the standard expected at this time of year</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"center\">";
            strMsg = strMsg + "<font size=\"8px\">E</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td align=\"left\">";
            strMsg = strMsg + "<font size=\"8px\">Well below the standard expected at this time of year</font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "</table>";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            strMsg = "";
            strMsg = strMsg + "<table >";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td align=\"center\" colspan=\"4\">";
            strMsg = strMsg + "<font size=\"9px\"><b>CITIZENSHIP AND SOCIAL RESPONSIBILITY</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
            strMsg = strMsg + "<font size=\"8px\">The indicators reflect personal and social development, as well as work habits and study skills.<font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
            strMsg = strMsg + "<font size=\"9px\"><b>Skills,Attitudes And Behaviours</b><font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";

            strMsg = strMsg + "</table >";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            strMsg = "";
            strMsg = strMsg + "<table>";
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select a.strsubject from tblsecondaryreportcard a,tblsecondindicator b where a.strsubject=b.strsecondindicatorsubject and strstandard='" + ddlstandard.SelectedValue + "' and a.intexamtype='" +hid3.ToString()+ "' and a.intstudent='"+hid.ToString()+"' group by a.strsubject";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td colspan=\"6\" align=\"left\">";
                    strMsg = strMsg + "<font size=\"11px\"><b>" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>Exam Paper</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>A</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>B</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>C</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>D</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>E</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";

                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    strsql = "select strexampaper from tblsecondaryreportcard where strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='"+hid3.ToString()+"' and intstudent='"+hid.ToString()+"' group by strexampaper";
                    ds1 = da1.ExceuteSql(strsql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                            strMsg = strMsg + "<td align=\"left\">";
                            strMsg = strMsg + "<font size=\"8px\">" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "</font>";
                            strMsg = strMsg + "</td>";
                            da2 = new DataAccess();
                            ds2 = new DataSet();
                            strsql = "select intsubjectindicator from tblsecondaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and strexampaper='" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "' and intexamtype='"+hid3.ToString()+"' and intstudent='"+hid.ToString()+"'";
                            ds2 = da2.ExceuteSql(strsql);

                            if (ds2.Tables[0].Rows.Count > 0)
                            {

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td></td>";

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td></td>";

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td></td>";

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td></td>";
                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td></td>";


                            }
                            strMsg = strMsg + "</tr>";
                        }
                    }

                }
            }
            strMsg = strMsg + "</table>";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            strMsg = "";
            strMsg = strMsg + "<table>";
            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
            strMsg = strMsg + "<td colspan=\"6\" align=\"left\">";
            strMsg = strMsg + "<font size=\"9px\"><b>Teacher’s Comments :</b></font> ";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "</table>";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            strMsg = "";
            strMsg = strMsg + "<table>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td colspan=\"6\" align=\"center\"><font size=\"9px\"><b>SUMMARY OF ACADEMIC PERFORMANCE</b></font></td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "</table>";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }

            strMsg = "";
            strMsg = strMsg + "<table>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td align=\"left\" colspan=\"6\"><font size=\"12px\"><b>Subject</b></font></td>";
            strMsg = strMsg + "</tr>";
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select a.strsubject from tblsecondaryreportcard a,tblschoolexampaper b where a.strsubject=b.strsubject and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intexamtype='" +hid3.ToString()+ "' and a.intstudent='"+hid.ToString()+"' group by a.strsubject";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\" align=\"left\">";
                    strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\" style=\"width:250px\">";
                    strMsg = strMsg + "<font size=\"9px\">Grade Awarded:</font> ";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"right\">";
                    strMsg = strMsg + "________";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>Exam Paper</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>A</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>B</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>C</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>D</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"center\">";
                    strMsg = strMsg + "<font size=\"8px\"><b>E</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    strsql = "select strexampaper from tblsecondaryreportcard where strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" +hid3.ToString()+ "' and intstudent='"+hid.ToString()+"'";
                    ds1 = da1.ExceuteSql(strsql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                            strMsg = strMsg + "<td align=\"left\">";
                            strMsg = strMsg + "<font size=\"8px\">" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "</font>";
                            strMsg = strMsg + "</td>";

                            da2 = new DataAccess();
                            ds2 = new DataSet();
                            strsql = "select intsubjectindicator from tblsecondaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" +hid3.ToString()+ "' and intstudent='"+hid.ToString()+"' and strexampaper='" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "'";
                            ds2 = da2.ExceuteSql(strsql);
                            if (ds2.Tables[0].Rows.Count > 0)
                            {

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";
                                if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                                {
                                    strMsg = strMsg + "<td align=\"center\">";
                                    string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                    strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                }
                                else
                                    strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";


                            }
                            strMsg = strMsg + "</tr>";
                        }
                    }

                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td colspan=\"6\" align=\"left\">";
                    strMsg = strMsg + "<font size=\"9px\"><b>Teacher’s Comments :</b></font> ";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                }
            }
            strMsg = strMsg + "</table>";

            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            strMsg = "";
            strMsg = strMsg + "<table>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td colspan=\"4\">";
            strMsg = strMsg + "<font size=\"9px\"><b>Class Teacher’s Comments :</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "<font size=\"9px\"><b>Signature :</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "________________";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font> ";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "________________";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td colspan=\"4\">";
            strMsg = strMsg + "<font size=\"9px\"><b>Parent’s Comments :</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "<font size=\"9px\"><b>Signature :</b></font>";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "_______________";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font> ";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "_______________";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "<tr>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "<font size=\"9px\"><b>Principal’s Signature :</b></font> ";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "_______________";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "<font size=\"9px\"><b>Date :<b></font> ";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "<td>";
            strMsg = strMsg + "________________";
            strMsg = strMsg + "</td>";
            strMsg = strMsg + "</tr>";
            strMsg = strMsg + "</table>";
            strB = new StringBuilder(strMsg);
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                for (int k = 0; k < list.Count; k++)
                {
                    doc.Add((IElement)list[k]);
                }
            }
            doc.Close();

            Response.Write("<script type=\"text/javascript\">window.open(\"printreport.aspx?id=1\",\"_blank\", \"status=1,toolbar=1\");</script>");
           
        }
        catch { }

       
    }
    //Response.Write("<script>");
    //Response.Write("window.open('../Inventory/pages/printableads.pdf', '_newtab');");
    //Response.Write("</script>");

    protected void creadpdfall()
    {
        string hid, hid1, hid2, hid3;
        try
        {
            string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Secondaryreportcard.pdf";
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filepath.ToString(), FileMode.Create));
            StringBuilder strB = new StringBuilder();
            doc.Open();
            doc.NewPage();
            for (int l = 0; l < dgstudent.Items.Count; l++)
            {
                hid = dgstudent.Items[l].Cells[1].Text;
                hid1 = dgstudent.Items[l].Cells[3].Text;
                hid2 = dgstudent.Items[l].Cells[4].Text;
                hid3 = dgstudent.Items[l].Cells[5].Text;

                string strMsg = "<br /><br /> <br />";
                string url = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png";
                strMsg = strMsg + "<div style='width:100%;text-align:center'><img src='" + url + "' alt='' style='align:center' /></div><br />";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str;
                str = "select a.strstandard,a.intstudent,a.stradmissionno,b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,c.strfirstname+''+c.strmiddlename+''+c.strlastname as name1, d.strexamtype from tblsecondaryreportcard a,tblstudent b,tblemployee c,tblexamtype d where a.intstudent=b.intid";
                str = str + " and a.inthometeacher=c.intid and a.intexamtype=d.intexamtypeid and c.intschool=" + Session["Schoolid"].ToString() + " and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "' group by a.strstandard,a.stradmissionno,b.intid,b.strfirstname,b.strmiddlename,b.strlastname,c.strfirstname,c.strmiddlename,c.strlastname,d.strexamtype,a.intstudent";
                ds = new DataSet();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    strMsg = "";
                    strMsg = strMsg + "<table>";
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\" valign=\"bottom\" align=\"center\"><font face=\"Verdana\" style=\"font-size:12px;\" color=\"#000000\"><b>STUDENT PROGRESS</b></font></td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + " <font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Standard:</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["strstandard"].ToString() + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Student Name:</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["name"].ToString() + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Class Teacher:</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["name1"].ToString() + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Exam Type:</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["strexamtype"].ToString() + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Student No</b></font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[0]["stradmissionno"].ToString() + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Attendance:</b></font>";
                    strMsg = strMsg + "</td>";
                    strsql = "select convert(varchar(10),startdate,111) as startdate from tblacademicyear where intschool=" + Session["SchoolID"].ToString();
                    da = new DataAccess();
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    DateTime dtstartdate = DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString());
                    strsql = "select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' and intschool=" + Session["Schoolid"].ToString() + " order by dtexamdate desc";
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(strsql);
                    DateTime dtenddate = DateTime.Parse(ds1.Tables[0].Rows[0]["dtexamdate"].ToString());

                    strsql = "select totaldays-holidays as workingdays from (select datediff(day,startdate,dtexamdate) as totaldays from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as a,";
                    strsql = strsql + " (select count(*) as holidays from tblacademiccalender c,(select * from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
                    da = new DataAccess();
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    int workingdays = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    int weeklyholidays = 0;

                    strsql = "select strweekholidays from tblworkingdays where intschoolid=" + Session["Schoolid"].ToString() + " and strmode='Holiday'";
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(strsql);
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        int intday = 0;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Sunday")
                            intday = 1;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Monday")
                            intday = 2;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Tuesday")
                            intday = 3;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Wednesday")
                            intday = 4;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Thursday")
                            intday = 5;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Friday")
                            intday = 6;
                        if (ds1.Tables[0].Rows[i][0].ToString() == "Saturday")
                            intday = 7;

                        strsql = "select dbo.NumberOfSundays('" + dtstartdate + "','" + dtenddate + "'," + intday + ")";
                        da2 = new DataAccess();
                        ds2 = new DataSet();
                        ds2 = da2.ExceuteSql(strsql);
                        weeklyholidays = weeklyholidays + int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                    }
                    int workingdays1;
                    workingdays1 = workingdays - weeklyholidays;
                    double intstudentleave = 0.00;
                    strsql = "select fullleave + halfleave as studentleave from (select count(*) as fullleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
                    strsql = strsql + "(select top 1 dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.strsession='Full Day' and c.intstudent=" + hid.ToString() + " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as a,";
                    strsql = strsql + " (select count(*)*.5 as halfleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
                    strsql = strsql + " (select top 1 dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.strsession!='Full Day' and c.intstudent=" + hid.ToString() + " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
                    da3 = new DataAccess();
                    ds3 = new DataSet();
                    ds3 = da3.ExceuteSql(strsql);

                    intstudentleave = double.Parse(ds3.Tables[0].Rows[0][0].ToString());
                    double presentdays = workingdays1 - intstudentleave;
                    double percentage = ((presentdays / workingdays1) * 100);
                    lblattendance.Text = percentage.ToString() + " %";

                    strMsg = strMsg + "<td align=\"left\">";
                    strMsg = strMsg + "<font size=\"8px\">" + lblattendance.Text + "</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\" align=\"center\"><font size=\"9px\"><b>PURPOSE OF REPORTING STUDENT PROGRESS</b></font></td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\">";
                    strMsg = strMsg + "<font size=\"8px\">This report card is designed to provide you with an accurate interpretation of your child’s achievement on graded curriculum over a period of time. It emphasizes “how” students learn and where they are on the learning continuum, rather than “what” students learn.</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\">";
                    strMsg = strMsg + "<font size=\"8px\">It also reflects the consistency of the skills outcomes across all grade levels Kindergarten through Grade 9. It will assist you and your child in understanding areas of strength, areas for growth and strategies for improvement. The report card is one means of reporting achievement and it should be considered within a comprehensive approach to reporting learning (e.g. student led conferences, celebrations of learning, digital portfolios, emails, blogs, etc.). If you require more information, or have any questions about the information contained in this report please contact the school at your earliest convenience. Meaningful communication is important in order to support student learning.</font>";
                    strMsg = strMsg + "</td>";
                    strMsg = strMsg + "</tr>";
                    strMsg = strMsg + "</table>";
                }

                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                strMsg = "";
                strMsg = strMsg + "<table>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\" colspan=\"2\">";
                strMsg = strMsg + "<font size=\"9px\"><b>INDICATORS OF ACHIEVEMENT</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
                strMsg = strMsg + "<font size=\"8px\">The level at which your child is demonstrating learning in relation to the expectation for this time in the school year is reported by the following indicators: </font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font size=\"9px\"><b>Indicator</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\"><b>Description</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font size=\"8px\">A</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Well above the standard expected at this time of year</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font size=\"8px\">B</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Above the standard expected at this time of year</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font size=\"8px\">C</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">At the standard expected at this time of year</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>  ";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font size=\"8px\">D</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Below the standard expected at this time of year</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font size=\"8px\">E</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Well below the standard expected at this time of year</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "</table>";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                strMsg = "";
                strMsg = strMsg + "<table >";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"center\" colspan=\"4\">";
                strMsg = strMsg + "<font size=\"9px\"><b>CITIZENSHIP AND SOCIAL RESPONSIBILITY</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
                strMsg = strMsg + "<font size=\"8px\">The indicators reflect personal and social development, as well as work habits and study skills.<font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
                strMsg = strMsg + "<font size=\"9px\"><b>Skills,Attitudes And Behaviours</b><font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";

                strMsg = strMsg + "</table >";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                strMsg = "";
                strMsg = strMsg + "<table>";
                da = new DataAccess();
                ds = new DataSet();
                strsql = "select a.strsubject from tblsecondaryreportcard a,tblsecondindicator b where a.strsubject=b.strsecondindicatorsubject and strstandard='" + ddlstandard.SelectedValue + "' and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "' group by a.strsubject";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                        strMsg = strMsg + "<td colspan=\"6\" align=\"left\">";
                        strMsg = strMsg + "<font size=\"11px\"><b>" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "</tr>";
                        strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                        strMsg = strMsg + "<td align=\"left\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>Exampaper</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>A</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>B</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>C</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>D</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>E</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "</tr>";

                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        strsql = "select strexampaper from tblsecondaryreportcard where strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "' group by strexampaper";
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                                strMsg = strMsg + "<td align=\"left\">";
                                strMsg = strMsg + "<font size=\"8px\">" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "</font>";
                                strMsg = strMsg + "</td>";
                                da2 = new DataAccess();
                                ds2 = new DataSet();
                                strsql = "select intsubjectindicator from tblsecondaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and strexampaper='" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                                ds2 = da2.ExceuteSql(strsql);

                                if (ds2.Tables[0].Rows.Count > 0)
                                {

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";
                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";


                                }
                                strMsg = strMsg + "</tr>";
                            }
                        }

                    }
                }
                strMsg = strMsg + "</table>";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                strMsg = "";
                strMsg = strMsg + "<table>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"6\" align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\"><b>Teacher’s Comments :</b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "</table>";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                strMsg = "";
                strMsg = strMsg + "<table>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"6\" align=\"center\"><font size=\"9px\"><b>SUMMARY OF ACADEMIC PERFORMANCE</b></font></td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "</table>";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }

                strMsg = "";
                strMsg = strMsg + "<table>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"left\" colspan=\"6\"><font size=\"12px\"><b>Subject</b></font></td>";
                strMsg = strMsg + "</tr>";
                da = new DataAccess();
                ds = new DataSet();
                strsql = "select a.strsubject from tblsecondaryreportcard a,tblschoolexampaper b where a.strsubject=b.strsubject and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "' group by a.strsubject";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strMsg = strMsg + "<tr>";
                        strMsg = strMsg + "<td colspan=\"4\" align=\"left\">";
                        strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "</font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\" style=\"width:250px\">";
                        strMsg = strMsg + "<font size=\"9px\">Grade Awarded:</font> ";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"right\">";
                        strMsg = strMsg + "________";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "</tr>";
                        strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                        strMsg = strMsg + "<td align=\"left\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>Exampaper</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>A</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>B</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>C</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>D</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        strMsg = strMsg + "<font size=\"8px\"><b>E</b></font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "</tr>";
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        strsql = "select strexampaper from tblsecondaryreportcard where strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                                strMsg = strMsg + "<td align=\"left\">";
                                strMsg = strMsg + "<font size=\"8px\">" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "</font>";
                                strMsg = strMsg + "</td>";

                                da2 = new DataAccess();
                                ds2 = new DataSet();
                                strsql = "select intsubjectindicator from tblsecondaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "' and strexampaper='" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "'";
                                ds2 = da2.ExceuteSql(strsql);
                                if (ds2.Tables[0].Rows.Count > 0)
                                {

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";
                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                                    {
                                        strMsg = strMsg + "<td align=\"center\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";


                                }
                                strMsg = strMsg + "</tr>";
                            }
                        }

                        strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                        strMsg = strMsg + "<td colspan=\"6\" align=\"left\">";
                        strMsg = strMsg + "<font size=\"9px\"><b>Teacher’s Comments :</b></font> ";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "</tr>";
                    }
                }
                strMsg = strMsg + "</table>";

                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
                strMsg = "";
                strMsg = strMsg + "<table>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"4\">";
                strMsg = strMsg + "<font size=\"9px\"><b>Class Teacher’s Comments :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Signature :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "________________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "________________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td colspan=\"4\">";
                strMsg = strMsg + "<font size=\"9px\"><b>Parent’s Comments :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Signature :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "_______________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "_______________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Principal’s Signature :</b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "_______________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Date :<b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "________________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "</table>";
                strB = new StringBuilder(strMsg);
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    for (int k = 0; k < list.Count; k++)
                    {
                        doc.Add((IElement)list[k]);
                    }
                }
            }
            doc.Close();
            Response.Write("<script type=\"text/javascript\">window.open(\"printreport.aspx?id=1\",\"_blank\", \"status=1,toolbar=1\");</script>");
        }

        catch { }


    }

   
}
