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
using System.Reflection;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text.html;

public partial class Fee_studentfee : System.Web.UI.Page
{
    public DataSet ds;
    string ReceiptNo = string.Empty;
    string Cashier = string.Empty;
    string Feemode = string.Empty;
    string AssignID = string.Empty;
    string PaidByAssignID = string.Empty;
    string AdmissionNo = string.Empty;
    string Month = string.Empty;
    Csfeemenagement ClsFee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtreceiptdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            StudentDeteails();
            fillgrid();
        }
        removequerystring();
    }
    protected void StudentDeteails()
    {
        if (Request["AdmissionNo"] != null)
        {
            txtadmno.Text = Request["AdmissionNo"].ToString();
            txtreceiptdate.Text = Request["date"];
            StudentDetailsForSelectedAdmdNO();
            fillFeemode();
            fillgrid();
            removequerystring();
        }
    }
    protected void removequerystring()
    {
        PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        isreadonly.SetValue(this.Request.QueryString, false, null);
        this.Request.QueryString.Remove("date");
        this.Request.QueryString.Remove("AdmissionNo");
        this.Request.QueryString.Remove("Class");
        this.Request.QueryString.Remove("StudentName");
        this.Request.QueryString.Remove("IntakeMonth");
        this.Request.QueryString.Remove("IntakeYear");
        this.Request.QueryString.Remove("IC_Passport");
        this.Request.QueryString.Remove("sFName");
        this.Request.QueryString.Remove("sMName");
        this.Request.QueryString.Remove("sLName");
        this.Request.QueryString.Remove("Dis");
    }
    protected void fillFeemode()
    {
        ds = new DataSet();
        ds = ClsFee.fncGetFeemodeForPayment(tdstandardtxt.InnerHtml.Trim());
        ddlSingle.DataSource = ds;
        ddlSingle.DataTextField = "FeemodeName";
        ddlSingle.DataValueField = "FeemodeID";
        ddlSingle.DataBind();
    }
    protected void fillgrd()
    {
        dgStudentfee.DataSource = null;
        dgStudentfee.DataBind();
        ds = new DataSet();
        if (txtFeemode.Text == "Select All")
            ds = ClsFee.fncGetAssignFeeForPayment(lblSelectAll.Value, tdstandardtxt.InnerHtml.ToString(), txtadmno.Text.Trim(), HidDis.Value,Int32.Parse(tdYeartxt.InnerHtml) ,0);
        else
            ds = ClsFee.fncGetAssignFeeForPayment(txtFeemode.Text, tdstandardtxt.InnerHtml, txtadmno.Text, HidDis.Value, Int32.Parse(tdYeartxt.InnerHtml), 0);
        dgStudentfee.DataSource = ds;
        dgStudentfee.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            HidPaidYear.Value = string.Empty;
            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                if (HidPaidYear.Value == string.Empty)
                    HidPaidYear.Value = ds.Tables[0].Rows[i]["AcademicYear"].ToString();
                else
                    HidPaidYear.Value = HidPaidYear.Value + "," + ds.Tables[0].Rows[i]["AcademicYear"].ToString();
            }
        }
        if (ds.Tables[0].Rows.Count > 0)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowDiscountReason", "ShowDiscountReason();", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidegrd", "hidegrd();", true);
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        fillgrd();
    }
    protected void txtadmno_TextChanged(object sender, EventArgs e)
    {
        if (txtadmno.Text != string.Empty)
        {
            StudentDetailsForSelectedAdmdNO();
            fillFeemode();
            fillgrid();
        }
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatetxtAdm", "ValidatetxtAdm();", true);
    }
    protected void StudentDetailsForSelectedAdmdNO()
    {
        Page Page = (Page)HttpContext.Current.CurrentHandler;
        if (!String.IsNullOrEmpty(Page.Request.QueryString["sFName"]))
        {
            tdstandardtxt.InnerHtml = Request["Class"].ToString();
            tdnametxt.InnerHtml = Request["sFName"].ToString()+' '+Request["sMName"].ToString()+' '+Request["sLName"].ToString();
            tdYeartxt.InnerHtml = Request["IntakeYear"].ToString();
            tdMonthtxt.InnerHtml = Request["IntakeMonth"].ToString();
            HidPassport.Value = Request["IC_Passport"].ToString();
            HidFname.Value=Request["sFName"].ToString();
            HidMname.Value=Request["sMName"].ToString();
            HidLname.Value = Request["sLName"].ToString();
            HidDis.Value = Request["Dis"].ToString();
            HidNewOld.Value = "NEW_ADMISSION"; // This string value used in Procedure DBSP_ACCOUNT_TRANSACTION
            trStudentName.Visible = true;
            trSIn.Visible = true;
        }
        else
        {
            ds = new DataSet();
            ds = ClsFee.fncGetStudentNameforAdmision(txtadmno.Text);
            if (ds.Tables[0].Rows[0]["ERROR"].ToString() == "VALID")
            {
                tdstandardtxt.InnerHtml = ds.Tables[0].Rows[0]["Class"].ToString();
                tdnametxt.InnerHtml = ds.Tables[0].Rows[0]["StudentName"].ToString();
                HidNewOld.Value = string.Empty;
                HidNewOld.Value = ds.Tables[0].Rows[0]["NewOld"].ToString();
                tdYeartxt.InnerHtml = ds.Tables[0].Rows[0]["IntakeYear"].ToString();
                tdMonthtxt.InnerHtml = ds.Tables[0].Rows[0]["IntakeMonth"].ToString();
                trStudentName.Visible = true;
            }
            else
            {
                trStudentName.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Invalid", "Invalid(); ", true);
            }
            trSIn.Visible = false;
        }
    }
    protected void fillreceiptsDetails()
    {
        tdReceiptNo.InnerHtml = ReceiptNo;
        tdReceiptDate.InnerHtml = txtreceiptdate.Text;
        tdStudentNo.InnerHtml = AdmissionNo;
        tdStudentName.InnerHtml = tdnametxt.InnerHtml;
        tdReceivedFrom.InnerHtml = txtRemitter.Text;
        tdDiscription.InnerHtml = Feemode + " for " + HidPaidYear.Value;
        tdAmount.InnerHtml = Hidden.Value;
        tdPaymode.InnerHtml = drp_mode.SelectedValue;
        tdChequeNo.InnerHtml = txtchequeno.Text;
        tdCashier.InnerHtml = Cashier;
    }
    protected void fillPrintReceipts()
    {
        string rn = tdReceiptNo.InnerHtml;
        string rd = tdReceiptDate.InnerHtml;
        string adn = tdStudentNo.InnerHtml;
        string sn = tdStudentName.InnerHtml;
        string rf = tdReceivedFrom.InnerHtml;
        string dc = tdDiscription.InnerHtml;
        string amt = tdAmount.InnerHtml;
        string pm = tdPaymode.InnerHtml;
        string cn = tdChequeNo.InnerHtml;
        string cr = tdCashier.InnerHtml;
        string url = "Print_Receipt.aspx?rn=" + rn + "&rd=" + rd + "&adn=" + adn + "&cr=" + cr + "&sn=" + sn + "&rf=" + rf + "&dc=" + dc + "&amt=" + amt + "&pm=" + pm + "&cn=" + cn + "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "<script type='text/javascript'> window.open('" + url + "','mynewwin','width=150,height=150,toolbar=1,scrollbars=no')</script>", false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Month = string.Empty;
        int FromGroup = 0;
        // when new student selected ,, the row id -- trSIn   visible
        if (HidNewOld.Value != string.Empty && HidNewOld.Value != "OLD")
        {
            FromGroup = 4;  // 4 means  New Admission groups from tblgroups
            if (HidNewOld.Value == "NEW_ADMISSION")
            {
                if (tdMonthtxt.InnerHtml == "January")
                    Month = "01";
                else
                    Month = "09";
            }
        }
        else
            FromGroup = 1;
        int ToGroup = 0;
        if (drp_mode.SelectedValue == "Cash")
            ToGroup = 5; // 5 means  Cash groups from tblgroups
        else
            ToGroup = 3; // 3 means  Cash groups from tblgroups
        double Discount = 0;
        if (txtDiscount.Text != String.Empty)
            Discount = double.Parse(txtDiscount.Text);
        int ReceiptMode = 0;
        if (ratiomanual.Checked == true)
            ReceiptMode = 1; 
        inserttable();
        ReceiptNo = ClsFee.fncInsertAccountTransaction(FromGroup, txtadmno.Text.Trim(), ToGroup, Int32.Parse(Session["UserID"].ToString()), double.Parse(Hidden.Value), drp_mode.SelectedValue, txtnarration.Text.Trim(), txtbankname.Text.Trim(), txtbranch.Text.Trim(), txtchequeno.Text.Trim(), txtchequedate.Text.Trim(), "Receipts", Discount, ReceiptMode, txtDiscountReason.Text.Trim(), txtRemitter.Text.Trim(), HidFname.Value.Trim(), HidMname.Value.Trim(), HidLname.Value.Trim(), tdstandardtxt.InnerHtml.Trim(), HidPassport.Value.Trim(), HidDis.Value, AssignID, PaidByAssignID, tdYeartxt.InnerHtml, Month, HidNewOld.Value, txtReceiptNo.Text, txtreceiptdate.Text);
        if (ReceiptNo != "FAILED")
        {
            ds = new DataSet();
            ds = ClsFee.fncGetUserName(Int32.Parse(Session["UserID"].ToString()));
            Cashier = ds.Tables[0].Rows[0]["Name"].ToString();
            AdmissionNo = ClsFee.fncGetAdmissionNoForReceiptNo(ReceiptNo);
            fillgrid();
            fillreceiptsDetails();
            Clear();
            removequerystring();
            fillPrintReceipts();
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Payment process not succeed');", true);
            
        
   }
    protected void Clear()
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Invalid", "Clear1(); ", true);
    }
    protected void inserttable()
    {
        try
        {
            HidPaidYear.Value = string.Empty;
            for (int i = 0; i < dgStudentfee.Items.Count; i++)
            {
                DataGridItem item = dgStudentfee.Items[i];
                if (HidPaidYear.Value == string.Empty)
                    HidPaidYear.Value = item.Cells[0].Text;
                else
                    HidPaidYear.Value = HidPaidYear.Value + "," + item.Cells[0].Text;
                
                DataGrid dgpayable = (DataGrid)item.FindControl("dgpayable");
                for (int j = 0; j < dgpayable.Items.Count; j++)
                {
                    DataGridItem PayItem = dgpayable.Items[j];
                    DataSet ds = new DataSet();
                    TextBox txt1 = (TextBox)PayItem.FindControl("txtpayable");
                    if (Feemode == string.Empty)
                        Feemode = PayItem.Cells[2].Text;
                    else
                    {
                        int Exists = Feemode.IndexOf(PayItem.Cells[2].Text);
                        if (Exists == -1)
                            Feemode = Feemode + "," + PayItem.Cells[2].Text;
                    }
                    if (AssignID == string.Empty)
                        AssignID = PayItem.Cells[0].Text;
                    else
                        AssignID = AssignID + "," + PayItem.Cells[0].Text;
                    if (PaidByAssignID == string.Empty)
                        PaidByAssignID =txt1.Text;
                    else
                        PaidByAssignID = PaidByAssignID + "," + txt1.Text;
                }
            }
        }
        catch { }
    }
    protected void fillgrid()
    {
        grd_trasaction.DataSource = null;
        grd_trasaction.DataBind();
        ds = new DataSet();
        ds = ClsFee.fncGetFeePaymentForGRID(txtadmno.Text.Trim(), tdstandardtxt.InnerHtml.Trim(),Session["UserID"].ToString());
        grd_trasaction.DataSource = ds;
        grd_trasaction.DataBind();
        if(grd_trasaction.Items.Count > 0 )
            grd_trasaction.Visible = true;
        else
            grd_trasaction.Visible = false;
    }
    protected void grd_trasaction_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        grd_trasaction.CurrentPageIndex = 0;
        grd_trasaction.CurrentPageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void dgStudentfee_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataGrid dgfeetype = (DataGrid)e.Item.FindControl("DgPayable");
            DataSet ds = new DataSet();
            if (txtFeemode.Text == "Select All")
                ds = ClsFee.fncGetAssignFeeForPayment(lblSelectAll.Value, tdstandardtxt.InnerHtml.ToString(), txtadmno.Text.Trim(), HidDis.Value,Int32.Parse(tdYeartxt.InnerHtml), Int32.Parse(dr["AcademicYear"].ToString()));
            else
                ds = ClsFee.fncGetAssignFeeForPayment(txtFeemode.Text, tdstandardtxt.InnerHtml, txtadmno.Text,HidDis.Value,Int32.Parse(tdYeartxt.InnerHtml), Int32.Parse(dr["AcademicYear"].ToString()));
            dgfeetype.DataSource = ds;
            dgfeetype.DataBind();
            for (int i = 0; i < dgfeetype.Items.Count; i++)
            {
                DataGridItem item = dgfeetype.Items[i];
                HtmlTableCell lblconPercentage = (HtmlTableCell)item.FindControl("tdcontxt");
                HtmlTableCell lblConAmount = (HtmlTableCell)item.FindControl("tdConAmount");
                HtmlTableRow rowPercentage = (HtmlTableRow)item.FindControl("trConcession");
                HtmlTableRow rowAmount = (HtmlTableRow)item.FindControl("trConAmount");
                HtmlTableRow trPaidDate = (HtmlTableRow)item.FindControl("trPaidDate");
                TextBox txtpayable = (TextBox)item.FindControl("txtpayable");
                if (double.Parse(ds.Tables[0].Rows[i]["Concession"].ToString()) > 0)
                {
                    if (double.Parse(ds.Tables[0].Rows[i]["Concession"].ToString()) < 100)
                        txtpayable.ReadOnly = false;
                    else
                    {
                        txtpayable.ReadOnly = true;
                        txtpayable.Text = "0";
                    }

                    rowPercentage.Visible = true;
                    rowAmount.Visible = true;
                    lblconPercentage.InnerHtml = ds.Tables[0].Rows[i]["Concession"].ToString() + " %";
                    lblConAmount.InnerHtml = ds.Tables[0].Rows[i]["Discount"].ToString();
                }
                else
                {
                    rowPercentage.Visible = false;
                    rowAmount.Visible = false;
                }
                if (ds.Tables[0].Rows[i]["LastPaidDate"].ToString() != string.Empty)
                    trPaidDate.Visible = true;
                else
                    trPaidDate.Visible = false;
            }
        }
        catch { }
    }
}
