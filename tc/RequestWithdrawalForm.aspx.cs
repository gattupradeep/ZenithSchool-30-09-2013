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


public partial class student_RequestWithdrawalForm : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql,str;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["admissionno"] != null)
            {
                txtadmissionno.Text = Session["admissionno"].ToString();
                //filldetails();
                //dues();
               // withdrawaldetails();
                Session["admissionno"] = null;
                //dues();
            }
        }
    }
    protected void filldetails()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select *,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.intYear from tblstudent a,tblNewAdmission b where a.intschool=" + Session["SchoolID"].ToString() + " and b.strAdmissionNo=a.intadmitno and a.intid=" + Session["studentid"].ToString();
            ds = da.ExceuteSql(str);
            lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            lbladmissiondate.Text = ds.Tables[0].Rows[0]["admissiondate"].ToString();
            lblstudentname.Text = ds.Tables[0].Rows[0]["name"].ToString();

            string parents = ds.Tables[0].Rows[0]["str_Parent_details"].ToString();
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillstudentdetails();
        fillattendance();
        //dues();
    }
    protected void fillstudentdetails()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            //string str = "select *,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.intYear from tblstudent a,tblNewAdmission b where a.intschool=" + Session["SchoolID"].ToString() + " and b.strAdmissionNo=a.intadmitno and a.intadmitno='"+txtadmissionno.Text+"'";
            str = "select *,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate ";
            str += " ,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth";
            str += " ,c.strStandardSec,b.Class as classenrolled";
            str += " ,b.intYear from tblstudent a,tblNewAdmission b,tblPromoted c ";
            str += " where a.intschool=" + Session["SchoolID"].ToString() + " and b.strAdmissionNo=a.intadmitno and a.intschool=b.intSchool and b.intSchool=c.intSchool and";
            str += " c.intYear=(select intYear-1 from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ") and a.intadmitno=c.strAdmissionNo";
            str += " and a.intadmitno='" + txtadmissionno.Text + "'";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblstudentname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
                lblbirthcertificateno.Text = ds.Tables[0].Rows[0]["strstudentbirthcertificateno"].ToString();
                lbldateofbirth.Text = ds.Tables[0].Rows[0]["dateofbirth"].ToString();
                lblpreviousschool.Text = ds.Tables[0].Rows[0]["previousinstitute"].ToString();
                lbladmissiondate.Text = ds.Tables[0].Rows[0]["admissiondate"].ToString();
                lblclass.Text = ds.Tables[0].Rows[0]["classenrolled"].ToString();
                lblhighestlevelcompleted.Text = ds.Tables[0].Rows[0]["strStandardSec"].ToString();
                Session["studentid"] = ds.Tables[0].Rows[0]["intid"].ToString();
                //withdrawaldetails();
            }
            else
            {
                clear();
            }
        }
        catch { }
    }

    protected void fillattendance()
    {
        strsql = "select convert(varchar(10),StartDate,111) as startdate,convert(varchar(10),EndDate,111) as enddate from tblacademicyear where intschool=" + Session["SchoolID"].ToString();
        strsql += " and intYear=(select intYear-1 as previousyear from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        string dtstartdate = DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString()).ToString("yyyy/MM/dd");
        string dtenddate = DateTime.Parse(ds.Tables[0].Rows[0]["enddate"].ToString()).ToString("yyyy/MM/dd");

        string str;
        str = "select totaldays-holidays as workingdays from ";
        str += " (select DATEDIFF(DAY, StartDate ,EndDate) as totaldays from tblAcademicYear ";
        str += " where intYear=(select intYear-1 as previousyear from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + ") as a,";
        str += " (select count(*) as holidays from tblacademiccalender where stryear=(select intYear-1 from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        int workingdays = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        int weeklyholidays = 0;

        str = "select strweekholidays from tblworkingdays where intschoolid=" + Session["Schoolid"].ToString() + " and strmode='Holiday'";
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        ds1 = da1.ExceuteSql(str);
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

            str = "select dbo.NumberOfSundays('" + dtstartdate + "','" + dtenddate + "'," + intday + ")";
            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();
            ds2 = da2.ExceuteSql(str);
            weeklyholidays = weeklyholidays + int.Parse(ds2.Tables[0].Rows[0][0].ToString());

        }
        int workingdays1;
        workingdays1 = workingdays - weeklyholidays;
        double intstudentleave = 0.00;
        str = "select fullday+halfday as studentleave from ";
        str += " (select COUNT(*) as fullday from tblstudentattendance SA,";
        str += " (select StartDate ,EndDate from tblAcademicYear ";
        str += " where intYear=(select intYear-1 as previousyear from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
        str += " and intschool=" + Session["SchoolID"].ToString() + ") as SE where strsession='Full Day' and SA.intstudent=" + Session["studentid"] + " and SA.intschool=" + Session["SchoolID"].ToString() + " and SA.dtdate>=StartDate and sa.dtdate<=EndDate) as FL,";
        str += " (select COUNT(*)*.5 as halfday from tblstudentattendance SA,";
        str += " (select StartDate ,EndDate from tblAcademicYear ";
        str += " where intYear=(select intYear-1 as previousyear from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
        str += " and intschool=" + Session["SchoolID"].ToString() + ") as SE where strsession!='Full Day' and SA.intstudent=" + Session["studentid"] + " and SA.intschool=" + Session["SchoolID"].ToString() + " and SA.dtdate>=StartDate and sa.dtdate<=EndDate) as HL";
        DataAccess da3 = new DataAccess();
        DataSet ds3 = new DataSet();
        ds3 = da3.ExceuteSql(str);

        intstudentleave = double.Parse(ds3.Tables[0].Rows[0][0].ToString());
        double presentdays = workingdays1 - intstudentleave;
        double percentage = ((presentdays / workingdays1) * 100);
        double b = double.Parse(String.Format("{0:0.##}", percentage));
        lblattendance.Text = b.ToString() + " %";

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlParameter OutPutParam;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        command = new SqlCommand("spstudentwithdrawal", conn);
        command.CommandType = CommandType.StoredProcedure;
        OutPutParam = command.Parameters.Add("@ID", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        command.Parameters.Add("@intid", "0");
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.Parameters.Add("@intapprove", "0");
        command.Parameters.Add("@str_ReasonForRejecting","0");
        command.Parameters.Add("@dt_approveddate", "");
        command.Parameters.Add("@dt_rejecteddate", "");
        command.Parameters.Add("@str_conduct_andCharecter", txtconduct.Text.Trim());
        command.Parameters.Add("@dt_dateOf_Tcrequested", txtTcRequested.Text.Trim());
        command.Parameters.Add("@dt_dateOf_studentleft", txtstudentleft.Text.Trim());
        //command.Parameters.Add("@dt_dateOf_TCissued", txtTcissued.Text.Trim());
        command.Parameters.Add("@str_Reason", txtreason.Text.Trim());
        command.Parameters.Add("@int_studentid", Session["studentid"].ToString());
        command.Parameters.Add("@dt_dateOf_requestOfwithdrawal", DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString());
        command.ExecuteNonQuery();
        conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        Functions.UserLogs(Session["UserID"].ToString(), "tblstudentwithdrawal", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 280);
        clear();
    }
    protected void clear()
    {
        lbladmission.Text = "";
        lbladmissiondate.Text = "";
        lblstudentname.Text = "";
        lbldateofbirth.Text = "";
        txtconduct.Text="";
        txtTcRequested.Text="";
        txtstudentleft.Text="";
        //txtTcissued.Text="";
        txtreason.Text="";
        txtadmissionno.Text = "";
    }
    protected void dues()
    {
        string Feemode = string.Empty;
        string Status = string.Empty;
        ds = new DataSet();
        ds = Csfee.fncGetAll_Feemode_For_TC_REQUEST();
        Feemode = ds.Tables[0].Rows[0]["FeeMode"].ToString();
        ds = null;
        ds = new DataSet();
        ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblclass.Text, txtadmissionno.Text.Trim(), string.Empty, Int32.Parse(lblfee.Text), 0);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblclass.Text, txtadmissionno.Text.Trim(), string.Empty, Int32.Parse(lblfee.Text), Int32.Parse(ds.Tables[0].Rows[0]["AcademicYear"].ToString()));
                lblfeetype.Text = ds.Tables[0].Rows[0]["FeemodeName"].ToString();
                lblfee.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblclass.Text, txtadmissionno.Text.Trim(), string.Empty, Int32.Parse(lblfee.Text), Int32.Parse(ds.Tables[0].Rows[0]["AcademicYear"].ToString()));
                    lblfeetype.Text = ds.Tables[0].Rows[0]["FeemodeName"].ToString();
                    lblfee.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                }
            }
        }
        else
            lblfee.Text = "No Dues";
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void txtTcno_TextChanged(object sender, EventArgs e)
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblstudentwithdrawal where str_TcNumber='' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This tc is already issued')", true);
        }
    }
    protected void txtadmissionno_TextChanged(object sender, EventArgs e)
    {
        fillstudentdetails();
        fillattendance();
        //dues();
        //string Feemode = string.Empty;
        //string Status = string.Empty;
        //ds = new DataSet();
        //ds = Csfee.fncGetAll_Feemode_For_TC_REQUEST();
        //Feemode = ds.Tables[0].Rows[0]["FeeMode"].ToString();
        //ds = null;
        //ds = new DataSet();
        //ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblpreviousclass.Text.Trim(), txtadmissionno.Text.Trim(), string.Empty,Int32.Parse(lblYear.Text) ,0);
        //if (ds.Tables[0].Rows.Count > 0)
        //    Status = "Pending";
        //else
        //    Status = "No Dues"; 
    }   
}
