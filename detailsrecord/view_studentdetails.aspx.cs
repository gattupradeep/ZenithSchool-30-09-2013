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

public partial class detailsrecord_view_studentdetails : System.Web.UI.Page
{
    public string str;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnedit.Visible = false;
        if (!IsPostBack)
        {
            if (Request["StudentID"] != null)
                filldetails(Request["StudentID"].ToString());
            if (Session["PatronType"] != null && Session["UserID"] != null)
            {
                if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
                {
                    filldetails(Session["UserID"].ToString());
                    btnedit.Visible = false;
                    btnback.Visible = false;
                    trsidemenu1.Visible = false;
                    trsidemenu2.Visible = false;
                }
            }
            trroll.Visible = false;
            trincome.Visible = false;
            tdmincome.Visible = false;
            tdfincome.Visible = false;
            
        }
    }
    protected void filldetails(string sid)
    {
        DataAccess da = new DataAccess();
        string sql = "";
        sql = "select a.* ,a.strFirstname + ' ' + a.strmiddlename + ' ' + a.strLastname AS name,convert(varchar(10),a.stradmitdate,103)as stradmitdate1,convert(varchar(10),a.Date_of_Registration,103) as registeredDate,convert(varchar(10),a.strdateofbirth,103) as strdateofbirth1,d.strcountryname,e.strstate,f.strcity from tblstudent a,dbo.tblcountry d,dbo.tblstate e,tblcity f where a.intid=" + sid.ToString() + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.intcountry=d.intcountryid and a.intstate=e.intstateid and a.intcity=f.intcityid ";
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lbltit.Text = lbltit.Text + " - " + ds.Tables[0].Rows[0]["name"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblgender.Text = ds.Tables[0].Rows[0]["strgender"].ToString();
            lbldob.Text = ds.Tables[0].Rows[0]["strdateofbirth1"].ToString();
            lblage.Text = ds.Tables[0].Rows[0]["intage"].ToString();
            //lblrollno.Text = ds.Tables[0].Rows[0]["introllno"].ToString();
            lbladmissionno.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            lbldateofadmiss.Text = ds.Tables[0].Rows[0]["stradmitdate1"].ToString();
            lblreligion.Text = ds.Tables[0].Rows[0]["strreligion"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblsection.Text = ds.Tables[0].Rows[0]["strsection"].ToString();
            //lblcommunity.Text = ds.Tables[0].Rows[0]["strcommunity"].ToString();
            //lblcaste.Text = ds.Tables[0].Rows[0]["strcaste"].ToString();
            lblnationality.Text = ds.Tables[0].Rows[0]["strnationality"].ToString();
            lbladdrs.Text = ds.Tables[0].Rows[0]["strresidanceaddress"].ToString();
            lblpcountry.Text = ds.Tables[0].Rows[0]["strcountryname"].ToString();
            lblpstate.Text = ds.Tables[0].Rows[0]["strstate"].ToString();
            lblpcity.Text = ds.Tables[0].Rows[0]["strcity"].ToString();
            lblzip.Text = ds.Tables[0].Rows[0]["strzipcode"].ToString();
            lblpmobile.Text = ds.Tables[0].Rows[0]["strmobile"].ToString();
            lblphoneno.Text = ds.Tables[0].Rows[0]["strphone"].ToString();
            //lblstudentpassport.Text = ds.Tables[0].Rows[0]["strstudentpassportoricno"].ToString();
            lblbirthno.Text = ds.Tables[0].Rows[0]["strstudentbirthcertificateno"].ToString();
            
            Ftag.Visible = false;
            Mtag.Visible = false;
            if (ds.Tables[0].Rows[0]["str_parent_details"].ToString() == "Father" || ds.Tables[0].Rows[0]["str_parent_details"].ToString() == "Father & Mother")
            {
                da = new DataAccess();
                sql = "select d.strcountryname,e.strstate,f.strcity from tblstudent a,dbo.tblcountry d,dbo.tblstate e,tblcity f where a.intid=" + sid.ToString() + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.intfcountry=d.intcountryid and a.intfathercompanystate=e.intstateid and a.intfathercompanycity=f.intcityid ";
                DataSet ds1 = new DataSet();
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lblfathername.Text = ds.Tables[0].Rows[0]["strfatherorguardname"].ToString();
                    lblfatheroccupation.Text = ds.Tables[0].Rows[0]["strfatherorguardoccupation"].ToString();
                    lbldesig.Text = ds.Tables[0].Rows[0]["strfatherorguarddesignation"].ToString();
                    lblorgname.Text = ds.Tables[0].Rows[0]["strfathercompanyname"].ToString();
                    lblworkadds.Text = ds.Tables[0].Rows[0]["strfathercompanyaddress"].ToString();
                    lblcountry.Text = ds1.Tables[0].Rows[0]["strcountryname"].ToString();
                    lblstate.Text = ds1.Tables[0].Rows[0]["strstate"].ToString();
                    lblcity.Text = ds1.Tables[0].Rows[0]["strcity"].ToString();
                    lblzipcode.Text = ds.Tables[0].Rows[0]["strzipcode"].ToString();
                    lblfathermobile.Text = ds.Tables[0].Rows[0]["fathermobileno"].ToString();
                    //lblFannualincome.Text = ds.Tables[0].Rows[0]["str_Father_income"].ToString();
                    lblFofficenumber.Text = ds.Tables[0].Rows[0]["str_Father_Off_phone"].ToString();
                    lblFemail.Text = ds.Tables[0].Rows[0]["str_Father_email"].ToString();
                    lblparentpassport.Text=ds.Tables[0].Rows[0]["strparentpassportoricno"].ToString();
                    Ftag.Visible = true;
                }
            }
            if (ds.Tables[0].Rows[0]["str_parent_details"].ToString() == "Mother" || ds.Tables[0].Rows[0]["str_parent_details"].ToString() == "Father & Mother")
            {
                lblmothername.Text = ds.Tables[0].Rows[0]["strmothername"].ToString();
                lblmotheroccup.Text = ds.Tables[0].Rows[0]["strmotheroccupation"].ToString();
                lblmothermobile.Text = ds.Tables[0].Rows[0]["strmothermobileno"].ToString();
                string Moccupation = ds.Tables[0].Rows[0]["strmotheroccupation"].ToString();
                if (Moccupation == "Home Maker")
                {
                    trtag1.Visible = false;
                    trtag2.Visible = false;
                    trtag3.Visible = false;
                    trtag4.Visible = false;
                }
                else
                {
                    trtag1.Visible = true;
                    trtag2.Visible = true;
                    trtag3.Visible = true;
                    trtag4.Visible = true;
                    da = new DataAccess();
                    sql = "select d.strcountryname,e.strstate,f.strcity from tblstudent a,dbo.tblcountry d,dbo.tblstate e,tblcity f where a.intid=" + sid.ToString() + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.intmcountry=d.intcountryid and a.intmothercompanystate=e.intstateid and a.intmothercompanycity=f.intcityid ";
                    DataSet ds1 = new DataSet();
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lblmotherdesig.Text = ds.Tables[0].Rows[0]["strmotherdesignation"].ToString();
                        lblMorganization.Text = ds.Tables[0].Rows[0]["strmothercompanyname"].ToString();
                        lblMworkaddress.Text = ds.Tables[0].Rows[0]["strmothercompanyaddress"].ToString();
                        lblMcountry.Text = ds1.Tables[0].Rows[0]["strcountryname"].ToString();
                        lblMstate.Text = ds1.Tables[0].Rows[0]["strstate"].ToString();
                        lblMcity.Text = ds1.Tables[0].Rows[0]["strcity"].ToString();
                        lblMofficenumber.Text = ds.Tables[0].Rows[0]["str_mother_off_phone"].ToString();
                        lblMemail.Text = ds.Tables[0].Rows[0]["str_mother_email"].ToString();
                        //lblMannualincome.Text = ds.Tables[0].Rows[0]["str_mother_income"].ToString();
                    }
                }
                Mtag.Visible = true;
            }
            lblname1.Text=ds.Tables[0].Rows[0]["stremergencyname"].ToString();
            lblpassport.Text=ds.Tables[0].Rows[0]["stremergencypassportoricno"].ToString();
            lblrelation.Text=ds.Tables[0].Rows[0]["stremergencyrelation"].ToString();
            lblofficeno.Text=ds.Tables[0].Rows[0]["stremergencyofficeno"].ToString();
            lblhomeno.Text=ds.Tables[0].Rows[0]["stremergencyhouseno"].ToString();
            lblmobileno.Text = ds.Tables[0].Rows[0]["stremergencymobileno"].ToString();
            lblmobilesms.Text = ds.Tables[0].Rows[0]["strmobilenoforsms"].ToString();
            lblparentusername.Text = ds.Tables[0].Rows[0]["strparentusername"].ToString();
            lblstudentusername.Text = ds.Tables[0].Rows[0]["strstudentusername"].ToString();
            lblparentemail.Text = ds.Tables[0].Rows[0]["strparentsemailid"].ToString();
            lblcorradds.Text = ds.Tables[0].Rows[0]["strcorrespondanceaddress"].ToString();
            lblseclanguage.Text = ds.Tables[0].Rows[0]["strsecondlanguage"].ToString();
            lblthirdlanguage.Text = ds.Tables[0].Rows[0]["strthirdlanguage"].ToString();
            lblheight.Text = ds.Tables[0].Rows[0]["intheight"].ToString();
            lblweight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
            lblidentification.Text = ds.Tables[0].Rows[0]["stridentification1"].ToString();
            lblblood.Text = ds.Tables[0].Rows[0]["strbloodgroup"].ToString();
            lblallergies.Text = ds.Tables[0].Rows[0]["strallergies"].ToString();

            lbloriginaldoc.Text = ds.Tables[0].Rows[0]["stroriginaldocuments"].ToString();
            lblremark.Text = ds.Tables[0].Rows[0]["strotherremarks"].ToString();
            previousinstitute.Text = ds.Tables[0].Rows[0]["previousinstitute"].ToString();
            int hosteler = int.Parse(ds.Tables[0].Rows[0]["hostler"].ToString());
            if (hosteler == 0)
            {
                lblhosteler.Text = "No";
                lbltransport.Text = ds.Tables[0].Rows[0]["str_Transport"].ToString();
                tag1.Visible = false;
                tag2.Visible = false;
                tag3.Visible = false;
            }
            else
            {
                lblhosteler.Text = "Yes";
                lbltransport.Text = "No transport";
                tag1.Visible = false;
                tag2.Visible = false;
                tag3.Visible = false;
            }

            double mincome, fincome;
            try
            {
                mincome = double.Parse(ds.Tables[0].Rows[0]["str_Father_income"].ToString());
            }
            catch
            {
                mincome = 0;
            }
            try
            {
                fincome = int.Parse(ds.Tables[0].Rows[0]["str_Father_income"].ToString());
            }
            catch
            {
                fincome = 0;
            }
            double total = mincome + fincome;
            lblannualfamincome.Text = total.ToString();

            string[] abc = ds.Tables[0].Rows[0]["strExtracurricular"].ToString().Split(',');
            string extracurricular = "";
            for (int j = 0; j < abc.Length; j++)
            {
                try
                {
                    str = "select * from tblstandard_section_extraCurricular  where intid=" + abc[j].Trim() + " and intschoolid=" + Session["SchoolID"].ToString();
                    da = new DataAccess();
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (extracurricular == "")
                            extracurricular = extracurricular + ds.Tables[0].Rows[0]["strcurricular"].ToString();
                        else
                            extracurricular = extracurricular + "," + ds.Tables[0].Rows[0]["strcurricular"].ToString();
                    }
                }
                catch { }
            }
            if (extracurricular != "")
                lblextracurricular.Text = extracurricular;
            else
                lblextracurricular.Text = "N/A";

            if (lblfatheroccupation.Text == "")
                lblfatheroccupation.Text = "---";
            if (lblworkadds.Text == "")
                lblworkadds.Text = "---";
            if (lblorgname.Text == "")
                lblorgname.Text = "---";
            if (lblidentification.Text == "")
                lblidentification.Text = "---";
            if (lblremark.Text == "")
                lblremark.Text = "---";
            if (previousinstitute.Text == "")
                previousinstitute.Text = "---";
            if (lblcorradds.Text == "")
                lblcorradds.Text = "---";
            if (lblFemail.Text == "")
                lblFemail.Text = "---";
            if (lblzip.Text == "")
                lblzip.Text = "---";
            if (lblMorganization.Text == "")
                lblMorganization.Text = "---";
            if (lblMworkaddress.Text == "")
                lblMworkaddress.Text = "---";
            if (lblMannualincome.Text == "")
                lblMannualincome.Text = "---";
            if (lblMofficenumber.Text == "")
                lblMofficenumber.Text = "---";
            if (lblallergies.Text == "")
                lblallergies.Text = "---";
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (Request["rd"] != null)
            Response.Redirect("student.aspx?intID=" + Request["StudentID"].ToString() + "&rd=2");
        else
            Response.Redirect("student.aspx?intID=" + Request["StudentID"].ToString() + "&rd=1");
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        if(Request["sbackto"].ToString()=="0")
        Response.Redirect("student_details.aspx?rd=1");
        else
            Response.Redirect("edit_student_details.aspx?rd=1");
    }
}
