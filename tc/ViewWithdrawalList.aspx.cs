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

public partial class student_ViewWithdrawalList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["wid"] != null)
            {
                filldetails();
            }
        }
    }
    protected void filldetails()
    {
        
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select a.*,CONVERT(varchar(11),a.stradmitdate,103) as admissiondate,a.strfirstname+' '+a.strmiddlename+' '+strlastname as name,CONVERT(varchar(11),a.strdateofbirth,103) as dateofbirth,";
        str = str + " a.stridentification1+' '+a.stridentification2 as identificationmark,YEAR(a.stradmitdate) as year,b.strStandardSec,c.*,convert(varchar(11),c.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),c.dt_dateOf_studentleft,103) as dtleft,convert(varchar(11),c.dt_dateOf_requestOfwithdrawal,103) as dtrequest ";
        str = str + " from tblstudent a,dbo.tblPromoted b,tblstudentwithdrawal c where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.intadmitno=b.strAdmissionNo and c.int_studentid=a.intid and c.intid=" + Request["wid"].ToString();
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
            lblpreviousclass.Text = ds.Tables[0].Rows[0]["strstandardsec"].ToString();
            lblidentificationmark.Text = ds.Tables[0].Rows[0]["identificationmark"].ToString();
            lbldocuments.Text = ds.Tables[0].Rows[0]["stroriginaldocuments"].ToString();
            //lblfirstclass.Text = ds.Tables[0].Rows[0]["stroldstandard"].ToString() + " " + ds.Tables[0].Rows[0]["stroldsection"].ToString() + " " + ds.Tables[0].Rows[0]["year"].ToString();
            if (int.Parse(ds.Tables[0].Rows[0]["int_qualified_Forpromotion"].ToString()) == 0)
                lblpromotion.Text = "No";
            else
                lblpromotion.Text = "Yes";
            if (int.Parse(ds.Tables[0].Rows[0]["int_scholarship_ifany"].ToString()) == 0)
                lblscholarship.Text = "No";
            else
                lblscholarship.Text = "Yes" + ". Details :" + ds.Tables[0].Rows[0]["str_scholarshipDetails"].ToString();
            if (int.Parse(ds.Tables[0].Rows[0]["int_concession_ifany"].ToString()) == 0)
                lblconcession.Text = "No";
            else
                lblconcession.Text = "Yes" + ". Details :" + ds.Tables[0].Rows[0]["str_ConcessionDetails"].ToString();
            lblconduct.Text = ds.Tables[0].Rows[0]["str_conduct_andCharecter"].ToString();
            lbltcrequest.Text = ds.Tables[0].Rows[0]["dtrequest"].ToString();
            lblLeavingschool.Text = ds.Tables[0].Rows[0]["dtleft"].ToString();
            lbltcissued.Text = ds.Tables[0].Rows[0]["tcissued"].ToString();
            lbltcnumber.Text = ds.Tables[0].Rows[0]["str_TcNumber"].ToString();
            lblreasonforleavingschool.Text = ds.Tables[0].Rows[0]["str_Reason"].ToString();
            lblremarks.Text = ds.Tables[0].Rows[0]["str_remarks"].ToString();
            if(ds.Tables[0].Rows[0]["intapprove"].ToString()=="1")
            {
                lblstatus.Text="Approved";
            }

            if (ds.Tables[0].Rows[0]["intapprove"].ToString() == "2")
            {
                lblstatus.Text = "Rejected" + "." + "<br />" + " Reason for rejected :" + ds.Tables[0].Rows[0]["str_ReasonForRejecting"].ToString();
            }

            //string st = Session["status"].ToString();
            //if (st == "Rejected")
            //    lblstatus.Text = Session["status"].ToString() + "."+"<br />"+" Reason for rejected :" + ds.Tables[0].Rows[0]["str_ReasonForRejecting"].ToString();
            //else
            //    lblstatus.Text = Session["status"].ToString();
            
        }
    }   
}
