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

public partial class detailsrecord_view_employeedetails : System.Web.UI.Page
{
    public string str,strempid;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnedit.Visible = false;
        if (!IsPostBack)
        {
            if (Request["empid"] != null)
            {
                strempid = Request["empid"].ToString();
                filldetails();
            }
            if (Session["PatronType"] != null && Session["UserID"] != null)
            {
                string pat = Session["PatronType"].ToString();
                if (pat != "Super Admin")
                {
                    strempid = Session["UserID"].ToString();
                    tdtitle.InnerHtml = "My Profile";
                    filldetails();
                    btnedit.Visible = false;
                    btnback.Visible = false;
                    if (pat == "Admin")
                    {
                        trsidemenu.Visible = true;
                    }
                    else
                    {
                        trsidemenu.Visible = false;
                    }
                }
            }
        }
    }

    protected void filldetails()
    {
        string subject = "";
        string standard = "";
        string language = "";
        string homeclass = "";
        string mode = "";
        string degree = "";
        string major = "";
        string institution = "";
        string organization = "";
        string dept = "";
        string desig = "";

        string strsql = "select strteachsubject from tblteachingsubjects where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + strempid + " group by strteachsubject";
        DataSet ds1 = new DataSet();
        DataAccess da = new DataAccess();
        ds1 = da.ExceuteSql(strsql);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (j == 0)
                    subject = ds1.Tables[0].Rows[j]["strteachsubject"].ToString();
                else
                    subject = subject + "," + ' ' + ds1.Tables[0].Rows[j]["strteachsubject"].ToString();
            }

            if (subject.IndexOf("Language") > -1)
            {
                strsql = "select strlanguage from tblteachinglanguages where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + strempid + " group by strlanguage";
                DataSet ds5 = new DataSet();
                da = new DataAccess();
                ds5 = da.ExceuteSql(strsql);
                for (int j = 0; j < ds5.Tables[0].Rows.Count; j++)
                {

                    if (j == 0)
                        language = ds5.Tables[0].Rows[j]["strlanguage"].ToString();
                    else
                        language = language + "," + ' ' + ds5.Tables[0].Rows[j]["strlanguage"].ToString();
                }

                subject = subject.Replace("Language", language);
            }

            if (subject.IndexOf("Extra Activities") > -1)
            {
                strsql = "select strextraactivities from tblteachingextraactivities where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + strempid + " group by strextraactivities";
                ds1 = new DataSet();
                da = new DataAccess();
                ds1 = da.ExceuteSql(strsql);
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {

                    if (j == 0)
                        language = ds1.Tables[0].Rows[j]["strextraactivities"].ToString();
                    else
                        language = language + "," + ' ' + ds1.Tables[0].Rows[j]["strextraactivities"].ToString();
                }

                subject = subject.Replace("Extra Activities", language);
            }
        }
        else
        {
            subject = "N/A";
        }

        strsql = "select strteachclass from tblteachingclass where intschool= " + Session["SchoolID"].ToString() + " and intemployee= " + strempid + " group by strteachclass";
        DataSet ds2 = new DataSet();
        ds2 = da.ExceuteSql(strsql);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                if (j == 0)
                    standard = ds2.Tables[0].Rows[j]["strteachclass"].ToString();
                else
                    standard = standard + "," + ' ' + ds2.Tables[0].Rows[j]["strteachclass"].ToString();
            }
            ds2.Tables[0].Rows[0]["strteachclass"] = standard;
        }
        else
        {
            standard = "0";
        }

        strsql = "select strhomeclass from tblhomeclass where intschool= " + Session["SchoolID"].ToString() + " and intemployee= " + strempid + " group by strhomeclass";
        DataSet ds3 = new DataSet();
        ds3 = da.ExceuteSql(strsql);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
            {
                if (j == 0)
                    homeclass = ds3.Tables[0].Rows[j]["strhomeclass"].ToString();
                else
                    homeclass = standard + "," + ' ' + ds3.Tables[0].Rows[j]["strhomeclass"].ToString();
            }
            ds3.Tables[0].Rows[0]["strhomeclass"] = homeclass;
        }
        else
        {
            homeclass = "0";
        }

        da = new DataAccess();
        strsql = "select * from tblemployeeeducation where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee=" + strempid;
        DataSet ds4 = new DataSet();
        ds4 = da.ExceuteSql(strsql);
        dgeducation.DataSource = ds4;
        dgeducation.DataBind();
        if (ds4.Tables[0].Rows.Count > 0)
        {
            treducation1.Visible = true;
            treducation2.Visible = true;
        }
        else
        {
            treducation1.Visible = false;
            treducation2.Visible = false;
        }

        string sql = "select a.*,a.strFirstname + ' ' + a.strmiddlename + ' ' + a.strLastname AS name,convert(varchar(10),a.dtdateofjoining,103) as dtdateofjoining1,convert(varchar(10),a.dtdob,103) as dtdob1,b.strdepartmentname,c.strdesignation,d.strcountryname,e.strstate,f.strcity FROM tblemployee a,tbldepartment b ,tbldesignation c,tblcountry d, tblstate e,tblcity f where a.intdepartment=b.intid and a.intdesignation=c.intid and a.intcountry=d.intcountryid and a.intstate=e.intstateid and a.intcity=f.intcityid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=" + strempid;
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblgender.Text = ds.Tables[0].Rows[0]["strgender"].ToString();
            lbldob.Text = ds.Tables[0].Rows[0]["dtdob1"].ToString();
            lblage.Text = ds.Tables[0].Rows[0]["intage"].ToString();
            lblstafftype.Text = ds.Tables[0].Rows[0]["strtype"].ToString();
            lblguardian.Text = ds.Tables[0].Rows[0]["strguardian"].ToString();
            lblguardname.Text = ds.Tables[0].Rows[0]["strguardianname"].ToString();
            lblreligion.Text = ds.Tables[0].Rows[0]["strreligion"].ToString();
            lblemail.Text = ds.Tables[0].Rows[0]["stremail"].ToString();
            lbladdproof.Text = ds.Tables[0].Rows[0]["straddproof"].ToString();
            //lblcommunity.Text = ds.Tables[0].Rows[0]["strcommunity"].ToString();
            lblnationality.Text = ds.Tables[0].Rows[0]["strnationality"].ToString();
            lbladdrs.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
            lblpcountry.Text = ds.Tables[0].Rows[0]["strcountryname"].ToString();
            lblpstate.Text = ds.Tables[0].Rows[0]["strstate"].ToString();
            lblpcity.Text = ds.Tables[0].Rows[0]["strcity"].ToString();
            lblzip.Text = ds.Tables[0].Rows[0]["strzipcode"].ToString();
            lblpmobile.Text = ds.Tables[0].Rows[0]["strmobile"].ToString();
            lblphoneno.Text = ds.Tables[0].Rows[0]["strphone"].ToString();
            lbljoindate.Text = ds.Tables[0].Rows[0]["dtdateofjoining1"].ToString();
            lbldept.Text = ds.Tables[0].Rows[0]["strdepartmentname"].ToString();
            lbldesig.Text = ds.Tables[0].Rows[0]["strdesignation"].ToString();
            lblmobileforsms.Text = ds.Tables[0].Rows[0]["mobilesms"].ToString();
            //lblheight.Text = ds.Tables[0].Rows[0]["strheight"].ToString();
            lblidentification.Text = ds.Tables[0].Rows[0]["identitymark"].ToString();
            lblblood.Text = ds.Tables[0].Rows[0]["strblood"].ToString();
            lblsalary.Text = ds.Tables[0].Rows[0]["intsalary"].ToString();
            lblexperience.Text = ds.Tables[0].Rows[0]["intexpyear"].ToString() + "Year(s) " + ds.Tables[0].Rows[0]["intexpmonth"].ToString()+"Month(s)";
            lblloginuserid.Text = ds.Tables[0].Rows[0]["loginid"].ToString();
            lbltransport.Text = ds.Tables[0].Rows[0]["transport"].ToString();
            if (ds.Tables[0].Rows[0]["intexperienced"].ToString() == "1")
            {
                da = new DataAccess();
                strsql = "select *,convert(varchar(10),dtperiodfrom,101) as dtperiodfrom1 ,convert(varchar(10),dtperiodto,101) as dtperiodto1 from tblemployeeexperience where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee=" + strempid;
                DataSet ds5 = new DataSet();
                ds5 = da.ExceuteSql(strsql);
                dgexperience.DataSource = ds5;
                dgexperience.DataBind();
            }
            else
            {
                trexprience1.Visible = false;
                trexprience2.Visible = false;
            }

            if (ds2.Tables[0].Rows.Count > 0)
                lblteachclass.Text = ds2.Tables[0].Rows[0]["strteachclass"].ToString();
            else
                lblteachclass.Text = "0";

            if (ds1.Tables[0].Rows.Count > 0)
                lblteachsubject.Text = subject;
            else
                lblteachsubject.Text = "0";

            if (ds3.Tables[0].Rows.Count > 0)
                lblhomeclass.Text = ds3.Tables[0].Rows[0]["strhomeclass"].ToString();
            else
                lblhomeclass.Text = "0";
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("addeditstaff.aspx?empid=" + Request["empid"].ToString() + "&rd=1");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Request["backto"].ToString() != "0")
        {
            Response.Redirect("employeedetails.aspx?rd=1");
        }
        else
        {
            Response.Redirect("edit_employee_details.aspx?rd=1");
        }
    }
}
