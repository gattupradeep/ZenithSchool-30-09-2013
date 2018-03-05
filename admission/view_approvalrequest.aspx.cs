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

public partial class admission_view_approvalrequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["lid"] != null)
                filldetails();
        }
    }
    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + ' ' + str_middlename + ' ' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport from tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " and intid=" + Request["lid"].ToString(); 
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbldate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
            lblno.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblstudentname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblfathername.Text = ds.Tables[0].Rows[0]["str_fatherorguardianname"].ToString();
            lblstudentbirth.Text = ds.Tables[0].Rows[0]["str_studentbirth"].ToString();
            lbldateofbirth.Text = ds.Tables[0].Rows[0]["str_dateofbirth"].ToString();
            lblage.Text = ds.Tables[0].Rows[0]["intage"].ToString();
            lblgender.Text = ds.Tables[0].Rows[0]["str_gender"].ToString();
            lblappliedfor.Text = ds.Tables[0].Rows[0]["str_standard"].ToString();
            lblseclanguage.Text = ds.Tables[0].Rows[0]["str_second_language"].ToString();
            lblmotheroccupation.Text = ds.Tables[0].Rows[0]["str_motheroccupation"].ToString();
            lblmotherqualification.Text = ds.Tables[0].Rows[0]["str_motherqualification"].ToString();
            lblfatherqualification.Text = ds.Tables[0].Rows[0]["str_fatherorguardianqualification"].ToString();
            lblthirdlanguage.Text = ds.Tables[0].Rows[0]["str_third_language"].ToString();
            lblfatheroccupation.Text = ds.Tables[0].Rows[0]["str_fatherorguardianoccupation"].ToString();
            lbltransport.Text = ds.Tables[0].Rows[0]["str_transport"].ToString();
            lblhostel.Text = ds.Tables[0].Rows[0]["str_hostel"].ToString();
            lblstaffname.Text = ds.Tables[0].Rows[0]["str_staff1"].ToString();
            lbldepartment.Text = ds.Tables[0].Rows[0]["str_department1"].ToString();
            lbldesignation.Text = ds.Tables[0].Rows[0]["str_designation1"].ToString();
            lblemail.Text = ds.Tables[0].Rows[0]["str_emailid"].ToString();
            lblmobile.Text = ds.Tables[0].Rows[0]["str_mobile"].ToString();
            lblphone.Text = ds.Tables[0].Rows[0]["str_phone"].ToString();
        }   
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewapproved_rejected_waitlistapproved.aspx?lid");
    }
}
