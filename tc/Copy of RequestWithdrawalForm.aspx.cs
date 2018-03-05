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
    public string strsql;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["admissionno"] != null)
            {
                txtadmissionno.Text = Session["admissionno"].ToString();
                filldetails();
                dues();
               // withdrawaldetails();
                Session["admissionno"] = null;
                dues();
            }
            lblapprove.Visible = false;
            tdconcession.Visible = false;
            tdscholarship.Visible = false;
        }
    }
    protected void filldetails()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            //string str = "select a.*,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+' '+a.strmiddlename+' '+strlastname as name,";
            //str = str + " CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.stroldstandard,b.stroldsection,b.strstandard+' '+b.strsection as currentclass from tblstudent a,dbo.tblstudentcurrentstatus b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=" + Session["studentid"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.intstudentid";
            string str = "select *,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.intYear from tblstudent a,tblNewAdmission b where a.intschool=" + Session["SchoolID"].ToString() + " and b.strAdmissionNo=a.intadmitno and a.intid=" + Session["studentid"].ToString();
            ds = da.ExceuteSql(str);
            lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            lbladmissiondate.Text = ds.Tables[0].Rows[0]["admissiondate"].ToString();
            lblstudentname.Text = ds.Tables[0].Rows[0]["name"].ToString();

            string parents = ds.Tables[0].Rows[0]["str_Parent_details"].ToString();
            if (parents == "Father/Guardian")
            {
                lblfathername.Text = ds.Tables[0].Rows[0]["strfatherorguardname"].ToString();
            }
            else if (parents == "Father & Mother")
            {
                lblfathername.Text = ds.Tables[0].Rows[0]["strfatherorguardname"].ToString();
            }
            else if (parents == "Mother")
            {
                lblfathername.Text = ds.Tables[0].Rows[0]["strmothername"].ToString();
            }
            lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblsection.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
            lbldateofbirth.Text = ds.Tables[0].Rows[0]["dateofbirth"].ToString();
            lblgender.Text = ds.Tables[0].Rows[0]["strgender"].ToString();
            lblreligion.Text = ds.Tables[0].Rows[0]["strreligion"].ToString();
            lblnationality.Text = ds.Tables[0].Rows[0]["strnationality"].ToString();
            lblsecondlang.Text = ds.Tables[0].Rows[0]["strsecondlanguage"].ToString();
            lblthirdlang.Text = ds.Tables[0].Rows[0]["strthirdlanguage"].ToString();
            //lblpreviousclass.Text = ds.Tables[0].Rows[0]["strstandardsec"].ToString();
            lblidentificationmark.Text = ds.Tables[0].Rows[0]["identificationmark"].ToString();
            lbldocuments.Text = ds.Tables[0].Rows[0]["stroriginaldocuments"].ToString();
            lblYear.Text = ds.Tables[0].Rows[0]["intyear"].ToString();
            
            //lblfirstclass.Text = ds.Tables[0].Rows[0]["stroldstandard"].ToString() + " " + ds.Tables[0].Rows[0]["stroldsection"].ToString() + " " + ds.Tables[0].Rows[0]["year"].ToString();
        }
        catch { }
    }
    //protected void withdrawaldetails()
    //{
    //    DataAccess da = new DataAccess();
    //    DataSet ds = new DataSet();
    //    string str = "select *,convert(varchar(11),dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),dt_dateOf_Tcrequested,103) as tcrequest from tblstudentwithdrawal where intschool=" + Session["SchoolID"].ToString() + " and int_studentid=" + Session["studentid"].ToString();
    //    ds = da.ExceuteSql(str);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (int.Parse(ds.Tables[0].Rows[0]["str_TcNumber"].ToString()) == 0)
    //        {
    //            btnsave.Visible = false;
    //            btncancel.Visible = false;
    //            btnprint.Visible = false;
    //            txtTcno.Enabled = false;
    //            lblapprove.Text = "Not yet approved";
    //            lblapprove.Visible = true;
    //        }
    //        else
    //        {
    //            txtTcno.Text = ds.Tables[0].Rows[0]["str_TcNumber"].ToString();
    //            txtTcno.Enabled = true;                
    //            btnsave.Visible = false;
    //            btncancel.Visible = false;
    //            btnprint.Visible = true;
    //            lblapprove.Visible = true;
    //            lblapprove.Text = "Tc is approved";
    //        }
                
    //            if (int.Parse(ds.Tables[0].Rows[0]["int_qualified_Forpromotion"].ToString()) == 0)
    //            {
    //                rbnPNo.Checked = true;
    //                rbnPyes.Checked = false;
    //            }
    //            else
    //            {
    //                rbnPNo.Checked = false;
    //                rbnPyes.Checked = true;
    //            }
    //            if (int.Parse(ds.Tables[0].Rows[0]["int_scholarship_ifany"].ToString()) == 0)
    //            {
    //                rbnSno.Checked = true;
    //                rbnSy.Checked = false;
    //                txtscholarship.Text = "";
    //            }
    //            else
    //            {
    //                rbnSno.Checked = false;
    //                rbnSy.Checked = true;
    //                txtscholarship.Text = ds.Tables[0].Rows[0]["str_scholarshipDetails"].ToString();
    //            }
    //            if (int.Parse(ds.Tables[0].Rows[0]["int_concession_ifany"].ToString()) == 0)
    //            {
    //                rbnCno.Checked = true;
    //                rbnCy.Checked = false;
    //                txtconcession.Text = "";
    //            }
    //            else
    //            {
    //                rbnCy.Checked = true;
    //                rbnCno.Checked = false;
    //                txtconcession.Text = ds.Tables[0].Rows[0]["str_ConcessionDetails"].ToString();
    //            }
    //            txtconduct.Text = ds.Tables[0].Rows[0]["str_conduct_andCharecter"].ToString();
    //            txtTcissued.Text = ds.Tables[0].Rows[0]["tcissued"].ToString();
    //            txtstudentleft.Text = ds.Tables[0].Rows[0]["dtleft"].ToString();
    //            txtTcRequested.Text = ds.Tables[0].Rows[0]["tcrequest"].ToString();                
    //            txtreason.Text = ds.Tables[0].Rows[0]["str_Reason"].ToString();
    //            txtremarks.Text = ds.Tables[0].Rows[0]["str_remarks"].ToString();            
            
    //    }
    //    else
    //    {
    //        txtscholarship.Text = "";
    //        txtconcession.Text = "";
    //        txtconduct.Text = "";
    //        txtTcRequested.Text = "";
    //        txtstudentleft.Text = "";
    //        txtTcissued.Text = "";
    //        txtreason.Text = "";
    //        txtremarks.Text = "";
    //        txtadmissionno.Text = "";
    //        txtTcno.Text = "";
    //        rbnCno.Checked = false;
    //        rbnCy.Checked = false;
    //        rbnSno.Checked = false;
    //        rbnSy.Checked = false;
    //        rbnPNo.Checked = false;
    //        rbnPyes.Checked = false;
    //        txtTcno.Visible = true;
    //        btnsave.Visible = true;
    //        btncancel.Visible = true;
    //        btnprint.Visible = true;
    //        lblapprove.Visible = false;
    //    }
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {

        fillstudentdetails();
        dues();
    }
    protected void fillstudentdetails()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            //string str = "select a.*,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,year(a.stradmitdate) as year,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,";
            //str = str + " CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,b.stroldstandard,b.stroldsection,b.strstandard+' '+b.strsection as currentclass from tblstudent a ,dbo.tblstudentcurrentstatus b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intadmitno='" + txtadmissionno.Text.Trim() + "' and b.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.intstudentid";
            //string str = "select *,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.strstandardsec from tblstudent a,tblPromoted b where a.intschool=" + Session["SchoolID"].ToString() + " and b.strAdmissionNo=a.intadmitno and a.intadmitno='" + txtadmissionno.Text + "'";
            string str = "select *,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.intYear from tblstudent a,tblNewAdmission b where a.intschool=" + Session["SchoolID"].ToString() + " and b.strAdmissionNo=a.intadmitno and a.intadmitno='"+txtadmissionno.Text+"'";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
                lbladmissiondate.Text = ds.Tables[0].Rows[0]["admissiondate"].ToString();
                lblstudentname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                string parents = ds.Tables[0].Rows[0]["str_Parent_details"].ToString();
                if (parents == "Father/Guardian")
                {
                    lblfathername.Text = ds.Tables[0].Rows[0]["strfatherorguardname"].ToString();
                }
                else if (parents == "Father & Mother")
                {
                    lblfathername.Text = ds.Tables[0].Rows[0]["strfatherorguardname"].ToString();
                }
                else if (parents == "Mother")
                {
                    lblfathername.Text = ds.Tables[0].Rows[0]["strmothername"].ToString();
                }
                lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
                lblsection.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
                lbldateofbirth.Text = ds.Tables[0].Rows[0]["dateofbirth"].ToString();
                lblgender.Text = ds.Tables[0].Rows[0]["strgender"].ToString();
                lblreligion.Text = ds.Tables[0].Rows[0]["strreligion"].ToString();
                lblnationality.Text = ds.Tables[0].Rows[0]["strnationality"].ToString();
                lblsecondlang.Text = ds.Tables[0].Rows[0]["strsecondlanguage"].ToString();
                lblthirdlang.Text = ds.Tables[0].Rows[0]["strthirdlanguage"].ToString();
                //lblpreviousclass.Text = ds.Tables[0].Rows[0]["strstandardsec"].ToString();
                lblidentificationmark.Text = ds.Tables[0].Rows[0]["identificationmark"].ToString();
                lbldocuments.Text = ds.Tables[0].Rows[0]["stroriginaldocuments"].ToString();
                lblYear.Text = ds.Tables[0].Rows[0]["intyear"].ToString();
                //lblfirstclass.Text = ds.Tables[0].Rows[0]["stroldstandard"].ToString() + " " + ds.Tables[0].Rows[0]["stroldsection"].ToString() + " " + ds.Tables[0].Rows[0]["year"].ToString();
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
        int a;
        if (rbnPyes.Checked)
        {
            a = 1;
        }
        else
            a = 0;
        command.Parameters.Add("@int_qualified_Forpromotion", a);
        int b;
        if (rbnSy.Checked)
        {
            b = 1;
            command.Parameters.Add("@str_scholarshipDetails", txtscholarship.Text.Trim());
        }
        else
        {
            b = 0;
            command.Parameters.Add("@str_scholarshipDetails", "");
        }
        command.Parameters.Add("@int_scholarship_ifany", b);
        int c;
        if (rbnCy.Checked)
        {
            c = 1;
            command.Parameters.Add("@str_ConcessionDetails", txtconcession.Text.Trim());
        }
        else
        {
            c = 0;
            command.Parameters.Add("@str_ConcessionDetails", txtconcession.Text.Trim());
        }
        command.Parameters.Add("@int_concession_ifany", c);
        command.Parameters.Add("@intapprove", "0");
        command.Parameters.Add("@str_ReasonForRejecting","0");
        command.Parameters.Add("@dt_approveddate", "");
        command.Parameters.Add("@dt_rejecteddate", "");
        command.Parameters.Add("@str_conduct_andCharecter", txtconduct.Text.Trim());
        command.Parameters.Add("@dt_dateOf_Tcrequested", txtTcRequested.Text.Trim());
        command.Parameters.Add("@dt_dateOf_studentleft", txtstudentleft.Text.Trim());
        command.Parameters.Add("@dt_dateOf_TCissued", txtTcissued.Text.Trim());
        command.Parameters.Add("@str_TcNumber", txtTcno.Text.Trim());
        command.Parameters.Add("@str_Reason", txtreason.Text.Trim());
        command.Parameters.Add("@str_remarks", txtremarks.Text.Trim());
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
        lblfathername.Text = "";
        lblstandard.Text = "";
        lblsection.Text = "";
        lbldateofbirth.Text = "";
        lblgender.Text = "";
        lblreligion.Text = "";
        lblnationality.Text = "";
        lblsecondlang.Text = "";
        lblthirdlang.Text = "";
        //lblpreviousclass.Text = "";
        lblidentificationmark.Text ="";
        lbldocuments.Text = "";
        txtscholarship.Text="";
        txtconcession.Text="";
        txtconduct.Text="";
        txtTcRequested.Text="";
        txtstudentleft.Text="";
        txtTcissued.Text="";
        txtreason.Text="";
        txtremarks.Text = "";
        txtadmissionno.Text = "";
        txtTcno.Text = "";
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
        ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblstandard.Text + " - " + lblsection.Text, txtadmissionno.Text.Trim(), string.Empty, Int32.Parse(lblYear.Text), 0);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblstandard.Text + " - " + lblsection.Text, txtadmissionno.Text.Trim(), string.Empty, Int32.Parse(lblYear.Text), Int32.Parse(ds.Tables[0].Rows[0]["AcademicYear"].ToString()));
                lblfeetype.Text = ds.Tables[0].Rows[0]["FeemodeName"].ToString();
                lblfee.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds = Csfee.fncGetAssignFeeForPayment(Feemode, lblstandard.Text + " - " + lblsection.Text, txtadmissionno.Text.Trim(), string.Empty, Int32.Parse(lblYear.Text), Int32.Parse(ds.Tables[0].Rows[0]["AcademicYear"].ToString()));
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
    protected void rbnSy_CheckedChanged(object sender, EventArgs e)
    {
        tdscholarship.Visible = true;
    }
    protected void rbnCy_CheckedChanged(object sender, EventArgs e)
    {
        tdconcession.Visible = true;
    }
    protected void rbnSno_CheckedChanged(object sender, EventArgs e)
    {
        tdscholarship.Visible = false;
    }
    protected void rbnCno_CheckedChanged(object sender, EventArgs e)
    {
        tdconcession.Visible = false;
    }
    protected void txtTcno_TextChanged(object sender, EventArgs e)
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblstudentwithdrawal where str_TcNumber='" + txtTcno.Text + "' and intschool=" + Session["SchoolID"].ToString();
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
        dues();
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
