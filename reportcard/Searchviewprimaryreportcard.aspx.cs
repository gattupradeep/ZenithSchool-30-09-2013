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

public partial class reportcard_Searchviewprimaryreportcard : System.Web.UI.Page
{
    public string strsql, strMsg;
    public DataAccess da, da1, da2, da3;
    public DataSet ds, ds1, ds2, ds3;
   
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
        str = "select strstandard from tblprimaryreportcard group by strstandard";
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
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.intid,b.inthometeacher from tblemployee a,tblprimaryreportcard b where a.intid=b.inthometeacher and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["Schoolid"].ToString() + " group by a.strfirstname,a.strmiddlename,a.strlastname,a.intid,b.inthometeacher";
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
        str = "select a.strexamtype,a.intexamtypeid,b.intexamtype from tblexamtype a,tblprimaryreportcard b where a.intexamtypeid=b.intexamtype group by a.strexamtype,a.intexamtypeid,b.intexamtype";
        ds = da.ExceuteSql(str);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "intexamtype";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0, "--Select--");
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillteacher();
        fillexamtype();
        fillbystandard();
        //fillgrid();
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
    protected void fillgrid()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,b.intstudent,b.stradmissionno,b.intexamtype,b.inthometeacher from tblstudent a,tblprimaryreportcard b where b.strstandard='" + ddlstandard.SelectedValue + "' and b.intstudent=a.intid and a.intschool=" + Session["Schoolid"].ToString();
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
        Response.Redirect("viewprimaryreportcard.aspx?hid=" + e.Item.Cells[1].Text + "&hid3='" + e.Item.Cells[3].Text + "'&hid1=" + e.Item.Cells[4].Text + "&hid2=" + e.Item.Cells[5].Text + " &sbackto=0");
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
   
    protected void dgstudent_EditCommand1(object source, DataGridCommandEventArgs e)
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
         CheckBox chkSelectAll = sender as CheckBox;
         foreach (DataGridItem gvr in dgstudent.Items)
         {
             CheckBox chkSelect = gvr.FindControl("chk") as CheckBox;
             if (chkSelect.Checked == true)
             {
                
                    
                     createpdfall();
                     //Response.Redirect("Printprimaryreportcard.aspx?hid=" + dgi.Cells[1].Text + "&hid3='" + dgi.Cells[3].Text + "'&hid1=" + dgi.Cells[4].Text + "&hid2=" + dgi.Cells[5].Text);

                
             }
         }
    }

    protected void createpdf(string hid,string hid1,string hid2,string hid3)
    {
        try
        {
            string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Primaryreportcard.pdf";
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
                strsql = "select a.strstandard,a.stradmissionno,b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,c.strfirstname+''+c.strmiddlename+''+c.strlastname as name1, d.strexamtype from tblprimaryreportcard a,tblstudent b,tblemployee c,tblexamtype d where a.intstudent=b.intid";
                strsql = strsql + " and a.inthometeacher=c.intid and a.intexamtype=d.intexamtypeid and b.intschool=" + Session["Schoolid"].ToString() + " and c.intschool=" + Session["Schoolid"].ToString() + " and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "' group by a.strstandard,a.stradmissionno,b.strfirstname,b.strmiddlename,b.strlastname,b.intid,c.strfirstname,c.strmiddlename,c.strlastname,d.strexamtype";
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strMsg = "";
                    strMsg = strMsg + "<table>";
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\" align=\"center\"><font face=\"Verdana\" style=\"font-size:12px;\" color=\"#000000\"><b>STUDENT PROGRESS</b></font></td>";
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
                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
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
                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
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
                    strMsg = strMsg + "<td colspan=\"4\" align=\"center\"><font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>PURPOSE OF REPORTING STUDENT PROGRESS</b></font> ";
                    strMsg = strMsg + "</td>";
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
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>INDICATORS OF ACHIEVEMENT</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"8px\">Your child’s learning, social and personal development are reported by the following indicators :</font>";
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
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Indicator</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Description</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\"> ";
                string url10 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\1.png";
                strMsg = strMsg + "<img src='" + url10 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Rarely</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string url11 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\2.png";
                strMsg = strMsg + "<img src='" + url11 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Sometimes</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string url12 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\3.png";
                strMsg = strMsg + "<img src='" + url12 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Most of the time</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string url13 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\4.png";
                strMsg = strMsg + "<img src='" + url13 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Always</font>";
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
                strMsg = strMsg + "<td align=\"center\"><font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>YOUR CHILD AS A LEARNER</b></font></td>";
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
                strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td>&nbsp;</td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\1.png";
                strMsg = strMsg + "<img src='" + url1 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url2 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\2.png";
                strMsg = strMsg + "<img src='" + url2 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url3 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\3.png";
                strMsg = strMsg + "<img src='" + url3 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url4 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\4.png";
                strMsg = strMsg + "<img src='" + url4 + "' alt='' /></td>";
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
                da = new DataAccess();
                ds = new DataSet();
                strsql = "select a.strexampaper from tblprimaryreportcard a,tblreportindicator b where a.strexampaper=b.strindicatorsubject and a.strsubject='General' and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "'";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                        strMsg = strMsg + "<td align=\"left\">";
                        strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[i]["strexampaper"].ToString() + "</font>";
                        strMsg = strMsg + "</td>";

                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and strexampaper='" + ds.Tables[0].Rows[0]["strexampaper"].ToString() + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                        ds1 = da1.ExceuteSql(strsql);

                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td></td>";

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td></td>";

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td></td>";

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td align=\"center\"></td>";


                        }
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
                strMsg = strMsg + "<td align=\"center\" colspan=\"2\">";
                strMsg = strMsg + "<font size=\"9px\"><b>INDICATORS OF ACHIEVEMENT</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"left\" colspan=\"2\">";
                strMsg = strMsg + "<font size=\"8px\">The level at which your child is demonstrating learning in relation to the expectation for this time in the school year is reported by the following indicators:</font>";
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
                string indicator5 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\1.png";
                strMsg = strMsg + "<img src='" + indicator5 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Experiencing significant difficulty</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator6 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\2.png";
                strMsg = strMsg + "<img src='" + indicator6 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Experiencing some difficulty</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator7 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\3.png";
                strMsg = strMsg + "<img src='" + indicator7 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Managing comfortably</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator8 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\4.png";
                strMsg = strMsg + "<img src='" + indicator8 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Capable and competent</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator9 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\5.png";
                strMsg = strMsg + "<img src='" + indicator9 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Highly capable and competent</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<tr>";
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
                strMsg = strMsg + "<td align=\"center\"><font size=\"9px\"><b>YOUR CHILD’S LEARNING DURING THE TERM</b></font></td>";
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
                strMsg = strMsg + "<td align=\"left\" colspan=\"6\"><font size=\"9px\"><b>Subject</b></font></td>";
                strMsg = strMsg + "</tr>";

                da = new DataAccess();
                ds = new DataSet();
                strsql = "select strsubject from tblprimaryreportcard where strsubject!='General' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "' group by strsubject";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strMsg = strMsg + "<tr>";
                        strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
                        strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "</font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\" style=\"width:250px\">";
                        strMsg = strMsg + "<font size=\"11px\">Grade Awarded:</font> ";
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
                        string indicator1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\1.png";
                        strMsg = strMsg + "<img src='" + indicator1 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator2 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\2.png";
                        strMsg = strMsg + "<img src='" + indicator2 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator3 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\3.png";
                        strMsg = strMsg + "<img src='" + indicator3 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator4 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\4.png";
                        strMsg = strMsg + "<img src='" + indicator4 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\5.png";
                        strMsg = strMsg + "<img src='" + indicator + "' alt='' /></td>";
                        strMsg = strMsg + "</tr>";

                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        strsql = "select strexampaper from tblprimaryreportcard where strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                                strMsg = strMsg + "<td style=\"width:450px\" align=\"left\">";
                                strMsg = strMsg + "<font size=\"8px\">" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "</font>";
                                strMsg = strMsg + "</td>";
                                da2 = new DataAccess();
                                ds2 = new DataSet();
                                strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and strexampaper='" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                                ds2 = da1.ExceuteSql(strsql);
                                if (ds2.Tables[0].Rows.Count > 0)
                                {


                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";
                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";


                                }
                                strMsg = strMsg + "</tr>";
                            }
                        }

                    }
                }
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
                strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font>";
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
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Principal’s Signature :</b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "________________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font>";
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
            Response.Write("<script type=\"text/javascript\">window.open(\"printreport.aspx?id=2\",\"_blank\", \"status=1,toolbar=1\");</script>");
            
           
        }
        catch { }
    }
    protected void createpdfall()
    {
        string hid, hid1, hid2, hid3;
        try
        {
            string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Primaryreportcard.pdf";
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
                strsql = "select a.strstandard,a.stradmissionno,b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,c.strfirstname+''+c.strmiddlename+''+c.strlastname as name1, d.strexamtype from tblprimaryreportcard a,tblstudent b,tblemployee c,tblexamtype d where a.intstudent=b.intid";
                strsql = strsql + " and a.inthometeacher=c.intid and a.intexamtype=d.intexamtypeid and b.intschool=" + Session["Schoolid"].ToString() + " and c.intschool=" + Session["Schoolid"].ToString() + " and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "' group by a.strstandard,a.stradmissionno,b.strfirstname,b.strmiddlename,b.strlastname,b.intid,c.strfirstname,c.strmiddlename,c.strlastname,d.strexamtype";
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strMsg = "";
                    strMsg = strMsg + "<table>";
                    strMsg = strMsg + "<tr>";
                    strMsg = strMsg + "<td colspan=\"4\" align=\"center\"><font face=\"Verdana\" style=\"font-size:12px;\" color=\"#000000\"><b>STUDENT PROGRESS</b></font></td>";
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
                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
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
                    strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
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
                    strMsg = strMsg + "<td colspan=\"4\" align=\"center\"><font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>PURPOSE OF REPORTING STUDENT PROGRESS</b></font> ";
                    strMsg = strMsg + "</td>";
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
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>INDICATORS OF ACHIEVEMENT</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"8px\">Your child’s learning, social and personal development are reported by the following indicators :</font>";
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
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Indicator</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>Description</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\"> ";
                string url10 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\1.png";
                strMsg = strMsg + "<img src='" + url10 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Rarely</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string url11 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\2.png";
                strMsg = strMsg + "<img src='" + url11 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Sometimes</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string url12 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\3.png";
                strMsg = strMsg + "<img src='" + url12 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Most of the time</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string url13 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\4.png";
                strMsg = strMsg + "<img src='" + url13 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Always</font>";
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
                strMsg = strMsg + "<td align=\"center\"><font face=\"Verdana\" style=\"font-size:9px;\" color=\"#000000\"><b>YOUR CHILD AS A LEARNER</b></font></td>";
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
                strMsg = strMsg + "<tr border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td>&nbsp;</td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\1.png";
                strMsg = strMsg + "<img src='" + url1 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url2 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\2.png";
                strMsg = strMsg + "<img src='" + url2 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url3 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\3.png";
                strMsg = strMsg + "<img src='" + url3 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"center\">";
                string url4 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator\\4.png";
                strMsg = strMsg + "<img src='" + url4 + "' alt='' /></td>";
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
                da = new DataAccess();
                ds = new DataSet();
                strsql = "select a.strexampaper from tblprimaryreportcard a,tblreportindicator b where a.strexampaper=b.strindicatorsubject and a.strsubject='General' and a.intexamtype='" + hid3.ToString() + "' and a.intstudent='" + hid.ToString() + "'";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                        strMsg = strMsg + "<td align=\"left\">";
                        strMsg = strMsg + "<font size=\"8px\">" + ds.Tables[0].Rows[i]["strexampaper"].ToString() + "</font>";
                        strMsg = strMsg + "</td>";

                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and strexampaper='" + ds.Tables[0].Rows[0]["strexampaper"].ToString() + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                        ds1 = da1.ExceuteSql(strsql);

                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td></td>";

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td></td>";

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td></td>";

                            if (ds1.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                            {
                                strMsg = strMsg + "<td align=\"center\">";
                                string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                            }
                            else
                                strMsg = strMsg + "<td align=\"center\"></td>";


                        }
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
                strMsg = strMsg + "<td align=\"center\" colspan=\"2\">";
                strMsg = strMsg + "<font size=\"9px\"><b>INDICATORS OF ACHIEVEMENT</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr>";
                strMsg = strMsg + "<td align=\"left\" colspan=\"2\">";
                strMsg = strMsg + "<font size=\"8px\">The level at which your child is demonstrating learning in relation to the expectation for this time in the school year is reported by the following indicators:</font>";
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
                string indicator5 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\1.png";
                strMsg = strMsg + "<img src='" + indicator5 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Experiencing significant difficulty</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator6 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\2.png";
                strMsg = strMsg + "<img src='" + indicator6 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Experiencing some difficulty</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator7 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\3.png";
                strMsg = strMsg + "<img src='" + indicator7 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Managing comfortably</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator8 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\4.png";
                strMsg = strMsg + "<img src='" + indicator8 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Capable and competent</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"center\">";
                string indicator9 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\5.png";
                strMsg = strMsg + "<img src='" + indicator9 + "' alt='' /></td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"8px\">Highly capable and competent</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<tr>";
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
                strMsg = strMsg + "<td align=\"center\"><font size=\"9px\"><b>YOUR CHILD’S LEARNING DURING THE TERM</b></font></td>";
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
                strMsg = strMsg + "<td align=\"left\" colspan=\"6\"><font size=\"9px\"><b>Subject</b></font></td>";
                strMsg = strMsg + "</tr>";

                da = new DataAccess();
                ds = new DataSet();
                strsql = "select strsubject from tblprimaryreportcard where strsubject!='General' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "' group by strsubject";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strMsg = strMsg + "<tr>";
                        strMsg = strMsg + "<td align=\"left\" colspan=\"4\">";
                        strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "</font>";
                        strMsg = strMsg + "</td>";
                        strMsg = strMsg + "<td align=\"center\" style=\"width:250px\">";
                        strMsg = strMsg + "<font size=\"11px\">Grade Awarded:</font> ";
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
                        string indicator1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\1.png";
                        strMsg = strMsg + "<img src='" + indicator1 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator2 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\2.png";
                        strMsg = strMsg + "<img src='" + indicator2 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator3 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\3.png";
                        strMsg = strMsg + "<img src='" + indicator3 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator4 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\4.png";
                        strMsg = strMsg + "<img src='" + indicator4 + "' alt='' /></td>";
                        strMsg = strMsg + "<td align=\"center\">";
                        string indicator = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\indicator1\\5.png";
                        strMsg = strMsg + "<img src='" + indicator + "' alt='' /></td>";
                        strMsg = strMsg + "</tr>";

                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        strsql = "select strexampaper from tblprimaryreportcard where strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                strMsg = strMsg + "<tr  border='1' width='100%' style='margin:0px;padding:0px;height:70px'>";
                                strMsg = strMsg + "<td style=\"width:450px\" align=\"left\">";
                                strMsg = strMsg + "<font size=\"8px\">" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "</font>";
                                strMsg = strMsg + "</td>";
                                da2 = new DataAccess();
                                ds2 = new DataSet();
                                strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and strexampaper='" + ds1.Tables[0].Rows[j]["strexampaper"].ToString() + "' and intexamtype='" + hid3.ToString() + "' and intstudent='" + hid.ToString() + "'";
                                ds2 = da1.ExceuteSql(strsql);
                                if (ds2.Tables[0].Rows.Count > 0)
                                {


                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";

                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";
                                    if (ds2.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                                    {
                                        strMsg = strMsg + "<td align=\"right\">";
                                        string update1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\UpdateRad.gif";
                                        strMsg = strMsg + "<img src='" + update1 + "' alt='' /></td>";
                                    }
                                    else
                                        strMsg = strMsg + "<td class=\"title_label\" align=\"center\"></td>";


                                }
                                strMsg = strMsg + "</tr>";
                            }
                        }

                    }
                }
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
                strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font>";
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
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Principal’s Signature :</b></font> ";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "________________";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td>";
                strMsg = strMsg + "<font size=\"9px\"><b>Date :</b></font>";
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
            Response.Write("<script type=\"text/javascript\">window.open(\"printreport.aspx?id=2\",\"_blank\", \"status=1,toolbar=1\");</script>");
            
            //System.IO.FileStream fs = new System.IO.FileStream(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Primaryreportcard2.pdf", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //byte[] ar = new byte[(int)fs.Length];
            //fs.Read(ar, 0, (int)fs.Length);
            //fs.Close();

            //Response.AddHeader("content-disposition", "attachment;pdffilest=" + filepath + "Primaryreportcard2.pdf");
            //Response.ContentType = "application/octectstream";
            //Response.BinaryWrite(ar);
            //Response.End();

        }
        catch { }
    }

   
}
