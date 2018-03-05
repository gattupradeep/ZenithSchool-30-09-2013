// send  Sms script code used
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
using System.Text.RegularExpressions;

public partial class feemanagement_viewfeedue : System.Web.UI.Page
{
    Csfeemenagement ClsFee = new Csfeemenagement();
    public DataSet ds;
    public ListItem list;
    public string sid = string.Empty;
    public string feedetail = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserRights();
            clear();
            grdstudentfeedue.AllowPaging = true;
            grdstudentfeedue.CurrentPageIndex = 0;
            fillgrid();
        }
    }
    protected void UserRights()
    {
        if (Session["PatronType"] != null && Session["PatronType"].ToString() == "Students" || Session["PatronType"].ToString() == "Parents")
        {
            HidAdm.Value = ClsFee.fncGET_ADMISSION_NO_FOR_GIVEN_USERID_FOR_USER_RIGHTS();
            txtnameAdmno.ReadOnly = true;
            trcount.Visible = false;
            trmessage.Visible = false;
            grdstudentfeedue.Columns[0].Visible = false;
            tdChkall.Visible = false;
            tdChkall2.Visible = false;
            tdChkall1.Visible = false;
        }
        else
            txtnameAdmno.ReadOnly = false;
    }
    protected void fillgrid()
    {
        if (drpfeemode.SelectedValue != "" )
        {
            trsms.Visible = false;
            trmessage.Visible = false;
            string Class = string.Empty;
            string Mode = string.Empty;
            string duetype = string.Empty;
            string Fromdate = string.Empty;
            string Todate = string.Empty;
            ds = new DataSet();
            if (drpclass.SelectedValue == "0")
                Class = string.Empty;
            else
                Class = drpclass.SelectedValue;
            if (drpmode.SelectedValue == "0")
                Mode = string.Empty;
            else
                Mode = drpmode.SelectedValue;

            if (drpduetype.SelectedValue == "0")
                duetype = string.Empty;
            else
                duetype = drpduetype.SelectedValue;
            if (txtfromdate.Text != string.Empty)
                Fromdate = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
            else
                Fromdate = string.Empty;
            if (txttodate.Text != string.Empty)
                Todate = Convert.ToDateTime(txttodate.Text).ToString("yyyy-MM-dd");
            else
                Todate = string.Empty;
            ds = new DataSet();
            ds = ClsFee.fncGetFeePaymentDetails(int.Parse(drpyear.SelectedValue), txtnameAdmno.Text, Class, int.Parse(drpfeemode.SelectedValue), int.Parse(drpreceipt.SelectedValue), Mode, int.Parse(drpledger.SelectedValue), duetype, Fromdate, Todate);

            if (Session["PatronType"] != null && Session["PatronType"].ToString() != "Students" && Session["PatronType"].ToString() != "Parents")
            {
                int count = 0;
                string sid = string.Empty;
                string ch = string.Empty;
                if (drpduetype.SelectedIndex == 0)
                    lblcount.Text = "Total number of Student :";
                else if (drpduetype.SelectedIndex == 1)
                    lblcount.Text = "Total number of paid Student :";
                else if (drpduetype.SelectedIndex == 2)
                    lblcount.Text = "Total number of unpaid Student :";
                else
                    lblcount.Text = "Total number of Canceled receipts :";
                if (drpreceipt.SelectedIndex > 0 || drpmode.SelectedIndex > 0 || drpledger.SelectedIndex > 0)
                    lblcount.Text = "Total number of receipts :";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 15 && drpduetype.SelectedValue != "Unpaid")
                    {
                        grdstudentfeedue.AllowPaging = true;
                        grdstudentfeedue.PageSize = 15;
                    }
                    else
                        grdstudentfeedue.AllowPaging = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        trcount.Visible = true;

                        ch = ds.Tables[0].Rows[i]["StudentID"].ToString();
                        if (sid == string.Empty)
                            sid = ds.Tables[0].Rows[i]["StudentID"].ToString();
                        else
                        {
                            if (sid.IndexOf(ch) > -1)
                            {

                            }
                            else
                            {
                                sid = sid + " , " + ds.Tables[0].Rows[i]["studentid"].ToString();
                                count = sid.Length - sid.Replace(",", "").Length;

                            }
                        }
                        if (lblcount.Text != "Total number of receipts :")
                            lbcounttxt.Text = (count + 1).ToString();
                        else
                            lbcounttxt.Text = ds.Tables[0].Rows.Count.ToString();
                    }
                    if (drpduetype.SelectedIndex == 2)
                    {
                        grdstudentfeedue.Columns[0].Visible = true;
                        tdChkall.Visible = true;
                        tdChkall1.Visible = true;
                        tdChkall2.Visible = true;
                        trsms.Visible = true;
                    }
                    else
                    {
                        trsms.Visible = false;
                        trmessage.Visible = false;
                        grdstudentfeedue.Columns[0].Visible = false;
                        tdChkall.Visible = false;
                        tdChkall1.Visible = false;
                        tdChkall2.Visible = false;
                    }
                }
                else
                {
                    trcount.Visible = false;
                    trsms.Visible = false;
                    trmessage.Visible = false;
                    lbcounttxt.Text = string.Empty;
                    lbcounttxt.Text = string.Empty;
                    grdstudentfeedue.Columns[0].Visible = false;
                    tdChkall.Visible = false;
                    tdChkall1.Visible = false;
                    tdChkall2.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No records found for selected Criteria');", true);
                }
            }
            grdstudentfeedue.DataSource = ds;
            grdstudentfeedue.DataBind();
            if(ds.Tables[0].Rows.Count == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No records found for selected Criteria');", true);
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No record found!');", true);
    }
    protected void fillyear()
    {
        ds = new DataSet();
        if (HidAdm.Value == string.Empty)
            ds = ClsFee.fncGetAllYear();
        else
            ds = ClsFee.fncGetAllYearForSelectedStudent(HidAdm.Value);
        drpyear.DataSource = ds;
        drpyear.DataTextField = "Year";
        drpyear.DataValueField = "Year";
        drpyear.DataBind();
        drpyear.SelectedValue = ds.Tables[0].Rows[0]["CYear"].ToString();
        HidCyear.Value = ds.Tables[0].Rows[0]["CYear"].ToString();
    }
    protected void fillfeemode()
    {
        ds = new DataSet();
        ds = ClsFee.Class_FeeMode_Year_Class(Int32.Parse(drpyear.SelectedValue), drpclass.SelectedValue);
        drpfeemode.DataSource = ds;
        drpfeemode.DataTextField = "FeemodeName";
        drpfeemode.DataValueField = "FeemodeID";
        drpfeemode.DataBind();
        list = new ListItem("-ALL-", "0");
        drpfeemode.Items.Insert(0, list);
    }
    protected void fillclass()
    {
        ds = new DataSet();
        if (HidAdm.Value == string.Empty)
            ds = ClsFee.fncGet_Fee_Assignd_Class(Int32.Parse(drpyear.SelectedValue));
        else
            ds = ClsFee.GetAll_ClassFor_SelecledStudent(Int32.Parse(drpyear.SelectedValue), HidAdm.Value);
        drpclass.DataSource = ds;
        drpclass.DataTextField = "strstandard";
        drpclass.DataValueField = "strstandard";
        drpclass.DataBind();
        if (HidAdm.Value == string.Empty)
        {
            list = new ListItem("-ALL-", "0");
            drpclass.Items.Insert(0, list);
        }
    }
    protected void fillStudent()
    {
        ds = new DataSet();
        ds = ClsFee.fncFillStudent_SelectedYearClass(Int32.Parse(drpyear.SelectedValue),drpclass.SelectedValue,HidAdm.Value);
        ddlStudent.DataSource = ds;
        ddlStudent.DataTextField = "Student";
        ddlStudent.DataValueField = "AdmissionNo";
        ddlStudent.DataBind();
        if (HidAdm.Value == string.Empty)
        {
            list = new ListItem("-ALL-", "0");
            ddlStudent.Items.Insert(0, list);
        }
    }
    protected void fillledger()
    {
        ds = new DataSet();
        ds = ClsFee.fncGetCashierFor_SelectedYear(Int32.Parse(drpyear.SelectedValue));
        drpledger.DataSource = ds;
        drpledger.DataTextField = "Name";
        drpledger.DataValueField = "intUserID";
        drpledger.DataBind();
    }
    protected void clear()
    {
        fillyear();
        drpduetype.SelectedIndex = 0;
        fillclass();
        fillfeemode();
        fillStudent();
        trdate.Visible = false;
        txtfromdate.Text = string.Empty;
        txttodate.Text = string.Empty;
        clear2();
        trsms.Visible = false;
        trmessage.Visible = false;
    }
    protected void clear2()
    {
        fillledger();
        Admn();
        drpledger.SelectedIndex = 0;
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
    }
    protected void resetforadmnno()
    {
        Admn();
        fillclass();
        drpreceipt.SelectedIndex = 0;
        drpmode.SelectedIndex = 0;
        fillledger();
    }
    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillclass();
        fillfeemode();
        fillStudent();
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void drpduetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HidAdm.Value == string.Empty) // Not student and parent... only for admin
        {
            if (drpduetype.SelectedIndex > 0 && drpduetype.SelectedIndex == 1)
                trdate.Visible = true;
            else
                trdate.Visible = false;
        }
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
       
    }
    protected void drpfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void Admn()
    {
        if (HidAdm.Value != string.Empty)
            txtnameAdmno.Text = HidAdm.Value;
        else if (ddlStudent.SelectedIndex > 0)
            txtnameAdmno.Text = ddlStudent.SelectedValue;
        else
            txtnameAdmno.Text = string.Empty;
    }
    protected void txtfromdate_TextChanged(object sender, EventArgs e)
    {
        txtnameAdmno.Text = HidAdm.Value;
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void txttodate_TextChanged(object sender, EventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
        grdstudentfeedue.AllowPaging = true;
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void drpclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillfeemode();
        fillStudent();
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void txtnameAdmno_TextChanged(object sender, EventArgs e)
    {
        if (txtnameAdmno.Text != string.Empty)
        {
            ds = new DataSet();
            ds = ClsFee.fncGetStudentNameforAdmision(txtnameAdmno.Text);
            if (ds.Tables[0].Rows[0]["ERROR"].ToString() != "VALID")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Admission number!');", true);
                txtnameAdmno.Text = "";
            }
        }
        ResetforAdmission();
    }
    protected void ResetforAdmission()
    {
        if (txtnameAdmno.Text != string.Empty)
            ddlStudent.SelectedValue = txtnameAdmno.Text;
        else
            ddlStudent.SelectedIndex = 0;
        resetforadmnno();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void drpreceipt_SelectedIndexChanged(object sender, EventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void drpmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void drpledger_SelectedIndexChanged(object sender, EventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
    protected void grdstudentfeedue_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnsms_Click(object sender, EventArgs e)
    {
        //send  Sms script code start 
        try
        {
            string sid = string.Empty;
            string feedetail = string.Empty;
            string MobileNO = string.Empty;
            string ch = string.Empty;
            foreach (DataGridItem item in grdstudentfeedue.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkunpaid");
                if (chk.Checked == true)
                {
                    ch = item.Cells[1].Text;
                    if (sid == string.Empty)
                    {
                        sid = item.Cells[1].Text;
                        feedetail = ("Dear student, You have to pay for feetype " + item.Cells[5].Text + " . Your fee amount " + item.Cells[6].Text + ". you paid " + item.Cells[7].Text + ",remaining " + item.Cells[8].Text);
                    }

                    else
                    {
                        if (sid.IndexOf(ch) > -1)
                        {
                            sid = item.Cells[1].Text;
                            feedetail = feedetail + " , " + ("Dear student, You have to pay for feetype " + item.Cells[5].Text + ". Your fee amount " + item.Cells[6].Text + ". you paid " + item.Cells[7].Text + ",remaining " + item.Cells[8].Text);
                        }
                        else
                        {
                            MobileNO = ClsFee.fncGetMobileNO_SelectedStudent(item.Cells[1].Text);
                            if (MobileNO != string.Empty)
                            {
                                string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + MobileNO + "&message= Dear Student," + feedetail + "&priority=1");
                            }
                            sid = item.Cells[1].Text;
                            feedetail = ("Dear student, You have to pay for feetype " + item.Cells[5].Text + ". Your fee amount " + item.Cells[6].Text + ". you paid " + item.Cells[7].Text + ",remaining " + item.Cells[8].Text);
                        }
                    }
                }
            }
            if (sid != string.Empty)
            {
                MobileNO = ClsFee.fncGetMobileNO_SelectedStudent(sid);
                if (MobileNO != string.Empty)
                {
                    string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                    Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + MobileNO + "&message= Dear Student," + feedetail + "&priority=1");
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Message is sent Successfully!');", true);
                clear();
                grdstudentfeedue.AllowPaging = true;
                grdstudentfeedue.CurrentPageIndex = 0;
                fillgrid();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select student to Procede!');", true);
        }
        catch { }
        //send  Sms script code end
    }
    protected void btnmail_Click(object sender, EventArgs e)
    {
        try
        {
            string ch = string.Empty;
            foreach (DataGridItem item in grdstudentfeedue.Items)
            {
                
                CheckBox chk = (CheckBox)item.FindControl("chkunpaid");
                if (chk.Checked == true)
                {
                    ch = item.Cells[1].Text;
                    if (sid == string.Empty)
                    {
                        sid = item.Cells[1].Text;
                        feedetail = ("Dear student, You have to pay for feetype " + item.Cells[5].Text + ". your fee amount " + item.Cells[6].Text + ". you paid " + item.Cells[7].Text + ",remaining " + item.Cells[8].Text);
                    }

                    else
                    {
                        if (sid.IndexOf(ch) > -1)
                        {
                            sid = item.Cells[1].Text;
                            feedetail = feedetail + " , " + ("Dear student, You have to pay for feetype " + item.Cells[5].Text + ". your fee amount " + item.Cells[6].Text + ". you paid " + item.Cells[7].Text + ",remaining " + item.Cells[8].Text);
                        }
                        else
                        {
                            if (sid != string.Empty)
                            {
                                ClsFee.fncSendMail(0,Int32.Parse(Session["UserID"].ToString()), sid, "Information about fee dues", feedetail, 0, "Student", "Employee", DateTime.Today.ToString("yyyy/MM/dd"));
                                sid = item.Cells[1].Text;
                                feedetail = ("Dear student, You have to pay for feetype " + item.Cells[5].Text + ". your fee amount " + item.Cells[6].Text + ". you paid " + item.Cells[7].Text + ",remaining " + item.Cells[8].Text);
                            }
                        }
                    }
                }
            }
            if (sid != string.Empty)
            {
                ClsFee.fncSendMail(0,Int32.Parse(Session["UserID"].ToString()), sid, "Information about fee dues", feedetail, 0, "Student", "Employee", DateTime.Today.ToString("yyyy/MM/dd"));
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mail is sent Successfully!');", true);
                clear();
                grdstudentfeedue.AllowPaging = true;
                grdstudentfeedue.CurrentPageIndex = 0;
                fillgrid();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select student to Procede!');", true);
        }
        catch
        { }
    }
    protected void btnyes_Click(object sender, EventArgs e)
    {
        trmessage.Visible = true;
        trsms.Visible = false;
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        Admn();
        grdstudentfeedue.CurrentPageIndex = 0;
        fillgrid();
    }
}
