using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.OleDb;
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


public partial class student_search_viewWithdrawalList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddladmiss.Items.Insert(0, "--select--");
            ddlstudent.Items.Insert(0, "--Select--");
            txtdate.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            if (Request["wid"] != null)
            {
                fillgrid();
               
            }
        }
    }
    protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldropdowns();
        fillgrid();
    }
    protected void ddladmiss_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    
    //protected void txtdate_TextChanged(object sender, EventArgs e)
    //{
    //    fillgrid();
    //}
    
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void filldropdowns()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "";
        if (ddlList.SelectedValue == "Approved list")
            str = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,a.intid,a.intadmitno from tblstudent a,tblstudentwithdrawal b where b.intapprove=1 and a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.int_studentid";
        if (ddlList.SelectedValue == "Rejected list")
            str = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,a.intid,a.intadmitno from tblstudent a,tblstudentwithdrawal b where b.intapprove=2 and a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.int_studentid";
        if (ddlList.SelectedValue == "All")
            str = "select  a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,a.intid,a.intadmitno from tblstudent a,tblstudentwithdrawal b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.int_studentid";
        ds = da.ExceuteSql(str);
        ddladmiss.Items.Clear();
        ddladmiss.DataSource = ds;
        ddladmiss.DataTextField = "intadmitno";
        ddladmiss.DataValueField = "intadmitno";
        ddladmiss.DataBind();
        ddladmiss.Items.Insert(0, "--Select--");

        ddlstudent.Items.Clear();
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "--Select--");
    }

    protected void dgwithdrawal_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        //Session["wid"] = e.Item.Cells[0].Text;
        //Session["status"] = e.Item.Cells[6].Text;
        //Session["date"] = txtdate.Text.Trim();
        //if (ddlList.SelectedIndex > 0)
        //    Session["list"] = ddlList.SelectedValue;
        //if (ddladmiss.SelectedIndex > 0)
        //    Session["adm"] = ddladmiss.SelectedValue;
        //if (ddlstudent.SelectedIndex > 0)
        //    Session["stid"] = ddlstudent.SelectedValue;
        Response.Redirect("ViewWithdrawalList.aspx?wid="+e.Item.Cells[0].Text);
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "";
        if (ddlList.SelectedValue == "All")
        {
            str = str + "select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),a.dt_dateOf_requestOfwithdrawal,103) as dtrequest,'waiting for approval' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove=0";
            str = str + " union all  select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),a.dt_dateOf_requestOfwithdrawal,103) as dtrequest,'Approved' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove=1";
            str = str + " union all  select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),a.dt_dateOf_requestOfwithdrawal,103) as dtrequest,'Rejected' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove=2";
            if(ddladmiss.SelectedIndex>1)
            {
                str = str + " and intadmitno='" + ddladmiss.SelectedValue + "'";
            }
            if (ddlstudent.SelectedIndex > 1)
            {
                str = str + " and intid='"+ddlstudent.SelectedValue+"'";
            }
        }
        if (ddlList.SelectedValue == "Approved list")
        {
            str = " select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),a.dt_dateOf_requestOfwithdrawal,103) as dtrequest,'Approved' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and  a.intapprove=1 ";
            if (ddladmiss.SelectedIndex > 1)
            {
                str = str + " and intadmitno='" + ddladmiss.SelectedValue + "'";
            }
            if (ddlstudent.SelectedIndex > 1)
            {
                str = str + " and intid='" + ddlstudent.SelectedValue + "'";
            }
        }
        if (ddlList.SelectedValue == "Rejected list")
        {
            str = " select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),a.dt_dateOf_requestOfwithdrawal,103) as dtrequest,'Rejected' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove=2 ";
            if (ddladmiss.SelectedIndex > 1)
            {
                str = str + " and intadmitno='" + ddladmiss.SelectedValue + "'";
            }
            if (ddlstudent.SelectedIndex > 1)
            {
                str = str + " and intid='" + ddlstudent.SelectedValue + "'";
            }
        }
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgwithdrawal.DataSource = ds;
            dgwithdrawal.DataBind();
            dgwithdrawal.Visible = true;
        }
        else
        {
            dgwithdrawal.Visible = false;
        }
    }
    protected void dgwithdrawal_EditCommand(object source, DataGridCommandEventArgs e)
    {
        print(e.Item.Cells[1].Text);
    }
    protected void print(string hid)
    {
        try
        {
            string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "tc\\tcpdf\\TransferCertificate.pdf";
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
            string str = "select a.*,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+' '+a.strmiddlename+' '+strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,";
            str = str + " a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.strStandardSec,c.*,convert(varchar(11),c.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),c.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),c.dt_dateOf_requestOfwithdrawal,103) as dtrequest ";
            str = str + " from tblstudent a,dbo.tblPromoted b,tblstudentwithdrawal c where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.intadmitno=b.strAdmissionNo and c.int_studentid=a.intid and a.intadmitno='" + hid.ToString()+"'";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strMsg = "";
                strMsg = strMsg + "<table border='1'>";
                strMsg = strMsg + "<tr >";
                strMsg = strMsg + "<td  colspan=\"4\" valign=\"bottom\" align=\"center\"><font face=\"Verdana\" style=\"font-size:12px;\" color=\"#000000\"><b>TRANSFER CERTIFICATE</b></font></td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + " <font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Admission No :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["intadmitno"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Admission Date :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["admissiondate"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Student Name :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["name"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Father/Guardian Name :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strfatherorguardname"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Standard :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strstandard"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Section :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strsection"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Date of birth :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["dateofbirth"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Gender :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strgender"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Nationality :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strnationality"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Religion :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strreligion"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Second Language :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"11px\">" + ds.Tables[0].Rows[0]["strsecondlanguage"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Third Language :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["strthirdlanguage"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr  width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Previous Standard :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["strstandardsec"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Personal Identification Marks :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["identificationmark"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Original documents submitted at the time of admission :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["stroriginaldocuments"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Whether student qualified for promotion :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                if (int.Parse(ds.Tables[0].Rows[0]["int_qualified_Forpromotion"].ToString()) == 0)
                {
                    lblpromotion.Text = "No";
                    strMsg = strMsg + "<font size=\"9px\">" + lblpromotion.Text + "</font>";
                }
                else
                {
                    lblpromotion.Text = "Yes";
                    strMsg = strMsg + "<font size=\"9px\">" + lblpromotion.Text + "</font>";
                }
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Scholarship if any :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                if (int.Parse(ds.Tables[0].Rows[0]["int_scholarship_ifany"].ToString()) == 0)
                {
                    lblscholarship.Text = "No";
                    strMsg = strMsg + "<font size=\"9px\">" + lblscholarship.Text + "</font>";
                }
                else
                {
                    lblscholarship.Text = "Yes";
                    strMsg = strMsg + "<font size=\"9px\">" + lblscholarship.Text + "." + "<br />" + " Details :" + ds.Tables[0].Rows[0]["str_scholarshipDetails"].ToString() + "</font>"; 
                }
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Concession if any :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                if (int.Parse(ds.Tables[0].Rows[0]["int_concession_ifany"].ToString()) == 0)
                {
                    lblconcession.Text = "No";
                    strMsg = strMsg + "<font size=\"9px\">" + lblconcession.Text + "</font>";
                }
                else
                {
                    lblconcession.Text = "Yes";
                    strMsg = strMsg + "<font size=\"9px\">" + lblscholarship.Text + "." + "<br />" + " Details :" + ds.Tables[0].Rows[0]["str_ConcessionDetails"].ToString() + "</font>"; 
                }
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Conduct and Character :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["str_conduct_andCharecter"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Date on which transfer certificate is requested :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["dtrequest"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Date on which student left or leaving the school :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["dtleft"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Date on which transfer certificate is issued :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["tcissued"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Transfer certificate number :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["str_TcNumber"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Reason for leaving the school :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["str_Reason"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Other remarks :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                strMsg = strMsg + "<font size=\"9px\">" + ds.Tables[0].Rows[0]["str_remarks"].ToString() + "</font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
                strMsg = strMsg + "<tr width='100%' style='margin:0px;padding:0px;height:70px'>";
                strMsg = strMsg + "<td colspan=\"3\" align=\"left\">";
                strMsg = strMsg + "<font face=\"Verdana\" style=\"font-size:11px;\" color=\"#000000\"><b>Status :</b></font>";
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "<td align=\"left\">";
                if (ds.Tables[0].Rows[0]["intapprove"].ToString() == "1")
                {
                    lblstatus.Text = "Approved";
                    strMsg = strMsg + "<font size=\"9px\">" + lblstatus.Text + "</font>"; 
                }

                if (ds.Tables[0].Rows[0]["intapprove"].ToString() == "2")
                {
                    lblstatus.Text = "Rejected";
                    strMsg = strMsg + "<font size=\"9px\">" + lblstatus.Text + "." + "<br />" + " Reason for rejected :" + ds.Tables[0].Rows[0]["str_ReasonForRejecting"].ToString() + "</font>"; 
                }
                if (ds.Tables[0].Rows[0]["intapprove"].ToString() == "0")
                {
                    lblstatus.Text = "WaitList";
                    strMsg = strMsg + "<font size=\"9px\">" + lblstatus.Text + "</font>";
                }
                strMsg = strMsg + "</td>";
                strMsg = strMsg + "</tr>";
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
            doc.Close();
            Response.Write("<script type=\"text/javascript\">window.open(\"printtc.aspx?id=1\",\"_blank\", \"status=1,toolbar=1\");</script>");
        }
        catch { }

    }
    
}
