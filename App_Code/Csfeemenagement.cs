/*-------------------------------------------------------------------------------------------------------------
DATE			DEVELOPER					MOFIFIER			PURPOSE
=====			==========					=========			=======
05-05-2013		PrabaaKaran										
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class Csfeemenagement
{
    DataSet ds;
    SqlDataAdapter da;
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd;
    // Return All Feemode
    // Return Value Fieled == FeemodeID 
    // Return text Fieled == FeemodeName 
	public DataSet fncGetAllFeemode()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ALL_FEEMODE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGetFeemodeForFeeModeID(int FeemodeID)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_FEEMODE_FOR_FEEMODEID", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@FeeModeID", FeemodeID);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGetFeemodeForPayment(string Class)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_FEEMODE_PAYMENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // Return Class based on selected feemode for assign fee
    // Return Value Fieled == Class 
    // Return text Fieled == Class 
    public DataSet fncGetClassForAssignFee(int Feemode ,int Year)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_CLASS_ASSIGN_FEE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Feemode", Feemode);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGetAcademicYear()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ACADEMIC_YEAR_FEEASSIGN", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
     }
    public void fncInsertAssignedFeeDetails(int AcademicYear, string Class, int FeemodeID, int UserID, double Amount, int EditID , string Mode)
    {
        cmd = new SqlCommand("DBSP_INSERT_ASSIGNED_FEE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@FeemodeID", FeemodeID);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@Amount", Amount);
        cmd.Parameters.AddWithValue("@EditID", EditID);
        cmd.Parameters.AddWithValue("@MODE", Mode); 
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public DataSet fncGetAssignFeeDetails(int AcademicYear)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ASSIGNED_FEE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncDeleteAssignFee(int EditID)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_DELETE_ASSIGNED_FEE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@EditID", EditID);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncEditAssignFee(int EditID)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_EDIT_STATUS_ASSIGNFEE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@EditID", EditID);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // return -- intAssignID , AcademicYear , FeemodeID , FeemodeName , FeeAmount , PaidAmount , Balance , LastPaidDate
    public DataSet fncGetAssignFeeForPayment(string AssignFee, string Class, string AdmissionNo, string Discount,int IntakeYear, int Year)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_FEE_FOR_PAYMENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AssignFee", AssignFee);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Concession", Discount);
        cmd.Parameters.AddWithValue("@IntakeYear", IntakeYear);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGetStudentNameforAdmision(string AdmisionNo)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_STUDENT_FOR_ADMITION_NO", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AdmisionNo", AdmisionNo);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public string fncInsertAccountTransaction(int intfromgroups, string intfromledgers, int inttogroups, int UserID, double intamount, string strmodeofpayment, string strnarration, string strbankname, string strbranchname, string strchequeorddno, string strchequeordddate, string strmodeoftransaction, double intdiscount, int intreceiptmode, string strdiscountreason, string Remitter, string FName, string MName, string LName, string Class, string IC_PassportNo, string Concession, string StrAssignID, string PaidByAssignID, string Year, string Month, string Sstatus, string ReceiptNO,string ReceiptDate)
    {
        string ReceiptNo = string.Empty;
        cmd = new SqlCommand("DBSP_ACCOUNT_TRANSACTION", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@intschool", HttpContext.Current.Session["SchoolID"]);
        cmd.Parameters.AddWithValue("@intfromgroups", intfromgroups);
        cmd.Parameters.AddWithValue("@intfromledgers", intfromledgers);
        cmd.Parameters.AddWithValue("@inttogroups", inttogroups);
        cmd.Parameters.AddWithValue("@inttoledgers", UserID);
        cmd.Parameters.AddWithValue("@intamount", intamount);
        cmd.Parameters.AddWithValue("@strmodeofpayment", strmodeofpayment);
        cmd.Parameters.AddWithValue("@strnarration", strnarration);
        cmd.Parameters.AddWithValue("@strbankname", strbankname);
        cmd.Parameters.AddWithValue("@strbranchname", strbranchname);
        cmd.Parameters.AddWithValue("@strchequeorddno", strchequeorddno);
        cmd.Parameters.AddWithValue("@strchequeordddate", strchequeordddate);
        cmd.Parameters.AddWithValue("@strmodeoftransaction", strmodeoftransaction);
        cmd.Parameters.AddWithValue("@intdiscount", intdiscount);
        cmd.Parameters.AddWithValue("@intreceiptmode", intreceiptmode);
        cmd.Parameters.AddWithValue("@strdiscountreason", strdiscountreason);
        cmd.Parameters.AddWithValue("@Remitter", Remitter);
        cmd.Parameters.AddWithValue("@FName", FName);
        cmd.Parameters.AddWithValue("@MName", MName);
        cmd.Parameters.AddWithValue("@LName", LName);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@IC_PassportNo", IC_PassportNo);
        cmd.Parameters.AddWithValue("@Concession", Concession);
        cmd.Parameters.AddWithValue("@StrAssignID", StrAssignID);
        cmd.Parameters.AddWithValue("@PaidByAssignID", PaidByAssignID);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@Month", Month);
        cmd.Parameters.AddWithValue("@Sstatus", Sstatus);
        cmd.Parameters.AddWithValue("@ManualReceiptNO", ReceiptNO);
        cmd.Parameters.AddWithValue("@ReceiptDate", ReceiptDate);
        SqlParameter Param = new SqlParameter("@ReturnValue", SqlDbType.VarChar, 20);
        Param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(Param);
        cmd.ExecuteNonQuery();
        conn.Close();
        ReceiptNo = (string)Param.Value;
        return ReceiptNo;
    }
    //return [Year],[Student],[Class],[Feemode],[Amount],[Paid],[Balance]
    public DataSet fncGetFeePaymentDetails(int AcademicYear , string AdmissionNo,string Class,int FeemodeID,int ReceiptMode,string PayMode ,int Ledger,string Status ,string FromDate ,string ToDate)
    {
        
            ds = new DataSet();
            cmd = new SqlCommand("DBSP_STUDENT_FEE_PAYMENT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            conn.Open();
            cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
            cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
            cmd.Parameters.AddWithValue("@Class", Class);
            cmd.Parameters.AddWithValue("@FeemodeID", FeemodeID);
            cmd.Parameters.AddWithValue("@ReceiptMode", ReceiptMode);
            cmd.Parameters.AddWithValue("@PayMode", PayMode);
            cmd.Parameters.AddWithValue("@Ledger", Ledger);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
            cmd.ExecuteNonQuery();
            da.Fill(ds);
            conn.Close();
            return ds;
       
    }
    //return [Year],[Student],[Class],[Feemode],[Amount],[Paid],[Balance]
    public DataSet1 fncGetFeePaymentDetailsForReport(int AcademicYear, string AdmissionNo, string Class, int FeemodeID, int ReceiptMode, string PayMode, int Ledger, string Status, string FromDate, string ToDate, int UserID)
    {
        DataSet1 ds = new DataSet1();
        cmd = new SqlCommand("DBSP_STUDENT_FEE_PAYMENT_REPORT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@FeemodeID", FeemodeID);
        cmd.Parameters.AddWithValue("@ReceiptMode", ReceiptMode);
        cmd.Parameters.AddWithValue("@PayMode", PayMode);
        cmd.Parameters.AddWithValue("@Ledger", Ledger);
        cmd.Parameters.AddWithValue("@Status", Status);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.ExecuteNonQuery();
        da.Fill(ds,"StudentFeeDetails");
        conn.Close();
        return ds;
    }
    public DataSet fncGetFeePaymentForGRID(string AdmissionNo, string Class, string UserID)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_STUDENT_PAYMENT_AMOUNT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // To get all fee assigned class 
    public DataSet fncGet_Fee_Assignd_Class(int Year)
    {
        ds = new DataSet();
        cmd = new SqlCommand("GET_FEE_ASSIGNED_CLASS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // To get admission number for new student
    public DataSet fncGet_Generate_AdmnNum(string Year , string Month)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GENARATE_ADMISSION_NUMBER", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@Month", Month);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGet_All_Feemode_Grd()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_FILL_FEEMODE_GRID", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGet_Delete_Feemode_Grd(int EditID, string FeemodeName)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_DELETE_FEEMODE_GRID", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@EditID", EditID);
        cmd.Parameters.AddWithValue("@FeemodeName", FeemodeName);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGet_Feemode_AcademicYear(int Year)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_FEEMODE_ACADEMIC_YEAR", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGet_School_Fee_Structure(int FeeID,int Year)
    {
        ds = new DataSet(); 
        cmd = new SqlCommand("DBSP_SCHOOL_FEE_STUCTURE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@FeemodeID", FeeID);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public void fncCancelFeePayment(int TransactionID,int UserID)
    {
        cmd = new SqlCommand("DBSP_CACEL_FEE_PAYMENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@EditID", TransactionID);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public void fncSendMail(int ID, int UserID , string AdmissionNo,string Subject , string Message , int Viewed , string PatronType , string SenderType , string date)
    {
        cmd = new SqlCommand("SPmailbox", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@intid", ID);
        cmd.Parameters.AddWithValue("@intschool", HttpContext.Current.Session["SchoolID"]);
        cmd.Parameters.AddWithValue("@intsenderid", UserID);
        cmd.Parameters.AddWithValue("@strreceiverids", AdmissionNo);
        cmd.Parameters.AddWithValue("@strsubject", Subject);
        cmd.Parameters.AddWithValue("@strmessage", Message);
        cmd.Parameters.AddWithValue("@intviewed", Viewed);
        cmd.Parameters.AddWithValue("@strpatrontype", PatronType);
        cmd.Parameters.AddWithValue("@strsenderpatrontype", SenderType);
        cmd.Parameters.AddWithValue("@dtdate", date);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    // return Class which is asssigned for new admission 
    public DataSet fncGetClassForNewAdmission(int year)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_CLASS_FOR_NEWADMISSSION", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Year", year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // return FeeMode which is asssigned for new admission 
    public DataSet fncGetFeeModeForNewAdmission(int year, string Class)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_FEEMODE_FOR_NEWADMISSSION", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Year", year);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // return FeeMode which is asssigned for new admission 
    public DataSet fncGetNewAdmissionDetails(int year, string Month, string Class,string AdmissionNo , int FeemodeID,string Status)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GRID_NEWADMISSSION", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AcademicYear", year);
        cmd.Parameters.AddWithValue("@Month", Month);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@FeemodeID", FeemodeID);
        cmd.Parameters.AddWithValue("@Status", Status);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet fncGetUserName(int UserID)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_USER_NANE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    public string fncGetAdmissionNoForReceiptNo(string ReceiptNO)
    {
        string AdmissionNo = string.Empty;
        cmd = new SqlCommand("DBSP_GET_ADMISSION_NO_FOR_RECEIPT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@ReceiptNO", ReceiptNO);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        SqlParameter Param = new SqlParameter("@AdmissionNo", SqlDbType.VarChar, 10);
        Param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(Param);
        cmd.ExecuteNonQuery();
        conn.Close();
        AdmissionNo = (string)Param.Value;
        return AdmissionNo;
    }
    public DataSet fncGetNewAdmissionStudent(int year,string Month, string Class)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_FILL_NEWADMISSSION_STUDENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AcademicYear", year);
        cmd.Parameters.AddWithValue("@Month", Month);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataSet1 fncGetDailyFeeCollectioReport(string Fdate, string Tdate)
    {
        DataSet1 ds = new DataSet1();
        cmd = new SqlCommand("DBSP_DAILY_FEECOLLECTION_REPORT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@FromDate", Fdate);
        cmd.Parameters.AddWithValue("@ToDate", Tdate);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds, "DailyFeeCollection");
        conn.Close();
        return ds;
    }
    // Return all Year with current Year
    // Name : Year,CYear
    public DataSet fncGetAllYear()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ALL_ACADEMIC_YEAR", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    // Return all year for selected student from intake year
    public DataSet fncGetAllYearForSelectedStudent(string AdmissionNO)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ALL_ACADEMIC_YEAR_STUDENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AdmissionNO", AdmissionNO);
        cmd.Parameters.AddWithValue("@SchoolID",HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    // Return all Class by Order 
    // Name : Class
    public DataSet fncGetAllClass()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ALL_CLASS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    // Return all Student for selected Class by Order 
    // Name : AdmissionNo,Name
    public DataSet fncGetStudentForClassYear(int Year,string Class,string AdmissionNo,string NameORadmn)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_STUDENT_FOR_SELECTED_YEAR_CLASS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@NameORadmn", NameORadmn);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    public DataSet Class_FeeMode_Year_Class(int Year, string Class)
    {
        try
        {
            conn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("DBSP_GET_FEEMODE_FROR_YEAR_CLASS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@Class", Class);
            cmd.Parameters.AddWithValue("@SchoolID",System.Web.HttpContext.Current.Session["SchoolID"]);
            cmd.ExecuteNonQuery();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data error=" + err.Message.ToString());
        }
    }
    // Return all Student for selected Class by Order 
    // Name : AdmissionNo,Name
    public DataSet fncGetStudentForClass(string Class, string AdmissionNo, string NameORadmn)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_STUDENT_FOR_SELECTED_CLASS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@NameORadmn", NameORadmn);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    public DataSet fncGetReceiptReprint(int year, string Class, string AdmissionNo)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_STUDENT_RECEIPT_REPRINT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Year", year);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        conn.Close();
        return ds;
    }
    // To get all class for selected student year wise 
    public DataSet GetAll_ClassFor_SelecledStudent(int Year,string AdmissionNO)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_CLASS_FOR_YEAR_AND_SELECLED_STUDENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@AdmissionNO", AdmissionNO);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // To get all class for selected student year wise 
    public DataSet GetAll_ViewFeeDetails_SelecledStudent(int Year,string Class,int FeeModeID, string AdmissionNO)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_VIEW_FEEDETAILS_FOR_YEAR_CLASS_FEEMODE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@FeeModeID", FeeModeID);
        cmd.Parameters.AddWithValue("@AdmissionNO", AdmissionNO);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public string fncGET_ADMISSION_NO_FOR_GIVEN_USERID_FOR_USER_RIGHTS()
    {
        string AdmissionNo = string.Empty;
        cmd = new SqlCommand("GET_ADMISSION_NO_FOR_GIVEN_USERID_FOR_USER_RIGHTS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        SqlParameter ParamOut = new SqlParameter("@AdmissionNO", SqlDbType.VarChar, 10);
        ParamOut.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(ParamOut);
        cmd.ExecuteNonQuery();
        conn.Close();
        AdmissionNo = (string)ParamOut.Value;
        return AdmissionNo;
    }
    // To section for standard 
    public DataSet fncFill_Standard()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_FILL_STANDARD", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // To section for standard 
    public DataSet Get_Section_For_Standard(string Standard)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_SECTION_FOR_STANDARD", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Standard", Standard);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // Fill Student name fro section and standard 
    public DataSet fncFillStudent_For_Section_Standard(string Standard,string Section)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_FILL_STUDENT_FOR_STANDARD_SECTION", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Standard", Standard);
        cmd.Parameters.AddWithValue("@Section", Section);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // Fill Student name fro section and standard 
    public DataSet fncGetParent_For_Student(string Standard, string Section,string AdmissionNO)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_PARENT_NAME_FOR_STUDENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Standard", Standard);
        cmd.Parameters.AddWithValue("@Section", Section);
        cmd.Parameters.AddWithValue("@AdmissionNO", AdmissionNO);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // Fill Cashier For selecte year
    // Return intUserID, Name
    public DataSet fncGetCashierFor_SelectedYear(int Year)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_CASHIER_FOR_YEAR", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AcademicYear", Year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    // Fill Cashier For selecte year
    // Return intUserID, Name
    public string fncGetMobileNO_SelectedStudent(string AdmissionNO)
    {
        string MobileNO = string.Empty;
        cmd = new SqlCommand("DBSP_CASHIER_FOR_YEAR", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@AdmissionNO", AdmissionNO);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        SqlParameter Param = new SqlParameter("@MobileNO", SqlDbType.VarChar, 30);
        Param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(Param);
        cmd.ExecuteNonQuery();
        conn.Close();
        MobileNO = (string)Param.Value;
        return MobileNO;
    }
    // Fill student for year, class
    // Return Student, AdmissionNo
    public DataSet fncFillStudent_SelectedYearClass(int Year, string Class, string AdmissionNO)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_FILL_STUDENT_FOR_YEAR_CLASS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@AdmissionNO", AdmissionNO);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public string fncGetFeeIDWithDiscount(string FeeModeName_ID)
    {
        string Fee_Dis = string.Empty;
        cmd = new SqlCommand("DBSP_GET_DISCOUNT_FEEID_FOR_FEEMODE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        conn.Open();
        cmd.Parameters.AddWithValue("@FeeModeName_ID", FeeModeName_ID);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        SqlParameter Param = new SqlParameter("@Fee_Dis", SqlDbType.VarChar,200);
        Param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(Param);
        cmd.ExecuteNonQuery();
        conn.Close();
        Fee_Dis = (string)Param.Value;
        return Fee_Dis;
    }
    public DataSet1 fncGetStudentDailyFeeCollectioReport(int Year, string AdmissionNo, string Class)
    {
        DataSet1 ds = new DataSet1();
        cmd = new SqlCommand("DBSP_STUDENT_WISE_FEE_PAYMENT_REPORT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AcademicYear", Year);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds, "StudentWiseFeeCollection");
        conn.Close();
        return ds;
    }
    public DataSet1 fncGetStudentDailyAllFeeCollectioReport(int Year, string AdmissionNo, string Class)
    {
        DataSet1 ds = new DataSet1();
        cmd = new SqlCommand("DBSP_STUDENT_WISE_ALL_FEE_PAYMENT_REPORT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AcademicYear", Year);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds, "StudentWiseAllFeeCollection");
        conn.Close();
        return ds;
    }
    public DataSet fncEditFeeDiscount(int Year, string Class, string AdmissionNo, int FeemodeID)
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_EDIT_FEE_DISCOUNT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@FeemodeID", FeemodeID);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public string fncAddFeeDiscount(string AdmissionNo, string Concession, int Year)
    {
        string Status = string.Empty;
        cmd = new SqlCommand("DBSP_ADD_FEE_DISCOUNT_DETAILS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Concession", Concession);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        SqlParameter Rparam = new SqlParameter("@Msg", SqlDbType.VarChar, 100);
        Rparam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(Rparam);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Status = (string)Rparam.Value;
        return Status;
    }
    public DataSet1 fncStudentPaymentHistoryReport(int Year, string AdmissionNo, string Class)
    {
        DataSet1 ds = new DataSet1();
        cmd = new SqlCommand("DBSP_STUDENT_PAYMENT_HISTORY_REPORT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AcademicYear", Year);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds, "StudentPaymentHistory");
        conn.Close();
        return ds;
    }
    public DataSet1 fncStudentDateWisePaymentReport(int Year, string AdmissionNo, string Class, string FromDate, string ToDate, string PayMode)
    {
        DataSet1 ds = new DataSet1();
        cmd = new SqlCommand("DBSP_DATE_WISE_STUDENT_PAYMENT_REPORT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@AcademicYear", Year);
        cmd.Parameters.AddWithValue("@AdmissionNo", AdmissionNo);
        cmd.Parameters.AddWithValue("@Class", Class);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@PayMode", PayMode);
        cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds, "StudentDateWisePayment");
        conn.Close();
        return ds;
    }
    // It return all fee mode name by comma seperated
    public DataSet fncGetAll_Feemode_For_TC_REQUEST()
    {
        ds = new DataSet();
        cmd = new SqlCommand("DBSP_GET_ALL_FEEMODE_FOR_TC", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@SchoolID", HttpContext.Current.Session["SchoolID"]);
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
}
