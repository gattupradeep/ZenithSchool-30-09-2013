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
using System.IO;

public partial class school_student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            clear();
            if (Request["intID"] != null)
                filldetails();
            //txtreligion.Visible = false;
            trroll.Visible = false;
            trfincome.Visible = false;
            tag5.Visible = false;
            txtadmitno.Enabled = false;
            //txtadmitdate.Enabled = false;
            //txtstudentbirth.Enabled = false;
        }
    }
    protected void filldetails()
    {
        try
        {
            string str;
            DataSet ds;
            DataAccess da = new DataAccess();
            str = "select *,CONVERT(VARCHAR(10),stradmitdate ,101) as admissiondate,CONVERT(VARCHAR(10),strdateofbirth , 101) as birthdate,CONVERT(VARCHAR(10),Date_of_Registration, 101) as registerdate from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and intid=" + Request["intID"].ToString();
            da = new DataAccess();
            ds = da.ExceuteSql(str);

            txtfirst.Text = ds.Tables[0].Rows[0]["strFirstname"].ToString();
            txtmiddle.Text = ds.Tables[0].Rows[0]["strmiddlename"].ToString();
            txtlast.Text = ds.Tables[0].Rows[0]["strLastname"].ToString();
            txtadmitno.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            txtadmitdate.Text = ds.Tables[0].Rows[0]["admissiondate"].ToString();
            //txtrollno.Text = ds.Tables[0].Rows[0]["introllno"].ToString();
            txtbirthdate.Text = ds.Tables[0].Rows[0]["birthdate"].ToString();
            txtheight.Text = ds.Tables[0].Rows[0]["intheight"].ToString();
            txtweight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
            txtidentification1.Text = ds.Tables[0].Rows[0]["stridentification1"].ToString();
            txtidentification2.Text = ds.Tables[0].Rows[0]["stridentification2"].ToString();
            txtnationality.Text = ds.Tables[0].Rows[0]["strnationality"].ToString();
            txtstudentbirth.Text = ds.Tables[0].Rows[0]["strstudentbirthcertificateno"].ToString();
            //txtstudentpassport.Text = ds.Tables[0].Rows[0]["strstudentpassportoricno"].ToString();
            if (ds.Tables[0].Rows[0]["strreligion"].ToString() == "Hindu" || ds.Tables[0].Rows[0]["strreligion"].ToString() == "Islam" || ds.Tables[0].Rows[0]["strreligion"].ToString() == "Christian")
            {
                ddlreli.SelectedValue = ds.Tables[0].Rows[0]["strreligion"].ToString();
                ddlreli.Visible = true;
                txtreligion.Visible = false;
            }
            else
            {
                txtreligion.Text = ds.Tables[0].Rows[0]["strreligion"].ToString();
                ddlreli.SelectedValue = "Others";
                txtreligion.Visible = true;
            }
            //ddlcommunity.SelectedValue = ds.Tables[0].Rows[0]["strcommunity"].ToString();
            //txtcaste.Text = ds.Tables[0].Rows[0]["strcaste"].ToString();
            txtresidential.Text = ds.Tables[0].Rows[0]["strresidanceaddress"].ToString();
            fillcountry();
            ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["intcountry"].ToString();
            fillstate();
            int s = int.Parse(ds.Tables[0].Rows[0]["intstate"].ToString());
            ddlstate.SelectedValue = s.ToString();
            fillcity();
            ddlcity.SelectedValue = ds.Tables[0].Rows[0]["intcity"].ToString();
            txtzipcode.Text = ds.Tables[0].Rows[0]["strzipcode"].ToString();
            txtphoneno.Text = ds.Tables[0].Rows[0]["strphone"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["strmobile"].ToString();
            if (ds.Tables[0].Rows[0]["straltmobile"].ToString() == "0")
                txtaltmobileno.Text = "";
            else
                txtaltmobileno.Text = ds.Tables[0].Rows[0]["straltmobile"].ToString();
            ddlbloodgroup.SelectedValue = ds.Tables[0].Rows[0]["strbloodgroup"].ToString();
            if (ds.Tables[0].Rows[0]["strallergies"].ToString() == "0")
                txtallergies.Text = "";
            else
                txtallergies.Text = ds.Tables[0].Rows[0]["strallergies"].ToString();
            txtfathername.Text = ds.Tables[0].Rows[0]["strfatherorguardname"].ToString();
            txtfatherOccupation.Text = ds.Tables[0].Rows[0]["strfatherORguardOccupation"].ToString();
            txtfatherorganisation.Text = ds.Tables[0].Rows[0]["strfathercompanyname"].ToString();
            txtfatherdesignation.Text = ds.Tables[0].Rows[0]["strfatherorguarddesignation"].ToString();
            txtfatherworkaddress.Text = ds.Tables[0].Rows[0]["strfathercompanyaddress"].ToString();
            txtfathermobileno.Text = ds.Tables[0].Rows[0]["fathermobileno"].ToString();
            txtfatherpincode.Text = ds.Tables[0].Rows[0]["fathercompanyzipcode"].ToString();
            ddlFcountry.SelectedValue = ds.Tables[0].Rows[0]["intFcountry"].ToString();
            fillFstate();
            ddlFstate.SelectedValue = ds.Tables[0].Rows[0]["intfathercompanystate"].ToString();
            fillFcity();
            ddlFcity.SelectedValue = ds.Tables[0].Rows[0]["intfathercompanycity"].ToString();
            txtmothername.Text = ds.Tables[0].Rows[0]["strmothername"].ToString();
            txtmotherdesignation.Text = ds.Tables[0].Rows[0]["strmotherdesignation"].ToString();
            txtmothermobileno.Text = ds.Tables[0].Rows[0]["strmothermobileno"].ToString();
            txtmotherorganisation.Text = ds.Tables[0].Rows[0]["strmothercompanyname"].ToString();
            txtmotherpincode.Text = ds.Tables[0].Rows[0]["strmothercompanyzipcode"].ToString();
            txtmotherworkaddress.Text = ds.Tables[0].Rows[0]["strmothercompanyaddress"].ToString();
            ddlMcountry.SelectedValue = ds.Tables[0].Rows[0]["intMcountry"].ToString();
            
            txtparentpassport.Text=ds.Tables[0].Rows[0]["strparentpassportoricno"].ToString();
            txtemergencyname.Text=ds.Tables[0].Rows[0]["stremergencyname"].ToString();
            txtemergencypassport.Text=ds.Tables[0].Rows[0]["stremergencypassportoricno"].ToString();
            txtemergencyoffice.Text=ds.Tables[0].Rows[0]["stremergencyofficeno"].ToString();
            txtemergencymobile.Text=ds.Tables[0].Rows[0]["stremergencymobileno"].ToString();
            txtemergencyhome.Text = ds.Tables[0].Rows[0]["stremergencyhouseno"].ToString();
            txtrelation.Text=ds.Tables[0].Rows[0]["stremergencyrelation"].ToString();
            fillMstate();
            ddlMstate.SelectedValue = ds.Tables[0].Rows[0]["intmothercompanystate"].ToString();
            fillMcity();
            ddlMcity.SelectedValue = ds.Tables[0].Rows[0]["intmothercompanycity"].ToString();
            if (ds.Tables[0].Rows[0]["intsiblings"].ToString() == "0")
                txtnoofsiblings.Text = "";
            else
                txtnoofsiblings.Text = ds.Tables[0].Rows[0]["intsiblings"].ToString();
            if (ds.Tables[0].Rows[0]["intsiblings"].ToString() == "0")
            {
                RBsN.Checked = true;
                RBsY.Checked = false;
            }
            else
            {
                RBsY.Checked = true;
                RBsN.Checked = false;
            }
            if (ds.Tables[0].Rows[0]["strsiblingdetails"].ToString() == "0")
                txtsiblingdetails.Text = "";
            else
                txtsiblingdetails.Text = ds.Tables[0].Rows[0]["strsiblingdetails"].ToString();
            txtpersonalemail.Text = ds.Tables[0].Rows[0]["strparentsemailid"].ToString();
            if (ds.Tables[0].Rows[0]["strothernoforsms"].ToString() == "0")
                txtothermobileno.Text = "";
            else
                txtothermobileno.Text = ds.Tables[0].Rows[0]["strothernoforsms"].ToString();
            ddlmobileforsms.SelectedValue = ds.Tables[0].Rows[0]["strmobilenoforsms"].ToString();
            if (ddlmobileforsms.SelectedValue == "Other")
                txtothermobileno.Enabled = true;
            txtcorresaddress.Text = ds.Tables[0].Rows[0]["strcorrespondanceaddress"].ToString();
            txtdocuments.Text = ds.Tables[0].Rows[0]["stroriginaldocuments"].ToString();
            txtremarks.Text = ds.Tables[0].Rows[0]["strotherRemarks"].ToString();
            ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
            ddlsection.SelectedValue = ds.Tables[0].Rows[0]["strsection"].ToString();
            txtprviousinstitute.Text = ds.Tables[0].Rows[0]["previousinstitute"].ToString();
            if (ds.Tables[0].Rows[0]["hostler"].ToString() == "0")
                hostlerno.Checked = true;
            else
                hostleryes.Checked = true;
            if (RBfemale.Text == ds.Tables[0].Rows[0]["strgender"].ToString())
            {
                RBfemale.Checked = true;
                RBmale.Checked = false;
            }
            else
            {
                RBmale.Checked = true;
                RBfemale.Checked = false;
            }
            string parentdetail = ds.Tables[0].Rows[0]["str_Parent_details"].ToString();
            if (parentdetail == "Father/Guardian")
            {
                Ftag.Visible = true;
                Mtag.Visible = false;
            }
            else if (parentdetail == "Father & Mother")
            {
                Ftag.Visible = true;
                Mtag.Visible = true;
                if (RBhomemaker.Text == ds.Tables[0].Rows[0]["strmotheroccupation"].ToString())
                {
                    RBother.Checked = false;
                    RBhomemaker.Checked = true;
                    tag1.Visible = false;
                    tag2.Visible = false;
                    tag3.Visible = false;
                    tag4.Visible = false;
                }
                else
                {
                    RBhomemaker.Checked = false;
                    RBother.Checked = true;
                    tag1.Visible = true;
                    tag2.Visible = true;
                    tag3.Visible = true;
                    tag4.Visible = true;
                }
            }
            else if (parentdetail == "Mother")
            {
                Ftag.Visible = false;
                Mtag.Visible = true;
                if (RBhomemaker.Text == ds.Tables[0].Rows[0]["strmotheroccupation"].ToString())
                {
                    RBother.Checked = false;
                    RBhomemaker.Checked = true;
                    tag1.Visible = false;
                    tag2.Visible = false;
                    tag3.Visible = false;
                    tag4.Visible = false;
                }
                else
                {
                    RBhomemaker.Checked = false;
                    RBother.Checked = true;
                    tag1.Visible = true;
                    tag2.Visible = true;
                    tag3.Visible = true;
                    tag4.Visible = true;
                }
            }

            ddlsecondlanguage.SelectedValue = ds.Tables[0].Rows[0]["strsecondlanguage"].ToString();
            ddlthirdlanguage.SelectedValue = ds.Tables[0].Rows[0]["strthirdlanguage"].ToString();
            ddlroute.SelectedValue = ds.Tables[0].Rows[0]["introute"].ToString();
            vehicleAnddriver();
            ddlpickanddrop.SelectedValue=ds.Tables[0].Rows[0]["intTransportdestination"].ToString();
            ddlhouse.SelectedValue = ds.Tables[0].Rows[0]["strhouse"].ToString();
            //lblteacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
            txtappnumber.Text = ds.Tables[0].Rows[0]["str_App_No"].ToString();
            txtdateofreg.Text = ds.Tables[0].Rows[0]["registerdate"].ToString();
            txtmothertongue.Text = ds.Tables[0].Rows[0]["str_MotherTongue"].ToString();
            ddlparent.SelectedValue = ds.Tables[0].Rows[0]["str_Parent_details"].ToString();
            txtFofficephone.Text = ds.Tables[0].Rows[0]["str_Father_Off_phone"].ToString();
            //txtfatherincome.Text = ds.Tables[0].Rows[0]["str_Father_income"].ToString();
            txtfatheremail.Text = ds.Tables[0].Rows[0]["str_Father_email"].ToString();
            txtMofficephone.Text = ds.Tables[0].Rows[0]["str_mother_off_phone"].ToString();
            //txtmotherincome.Text = ds.Tables[0].Rows[0]["str_mother_income"].ToString();
            txtMemail.Text = ds.Tables[0].Rows[0]["str_mother_email"].ToString();
            txtpreviousclass.Text = ds.Tables[0].Rows[0]["str_Previous_class"].ToString();
            txtconcession.Text = ds.Tables[0].Rows[0]["str_Concession_details"].ToString();
            fillsubject_Extracurricular_teacher();
            string[] abc = ds.Tables[0].Rows[0]["strExtracurricular"].ToString().Split(',');
            for (int i = 0; i < chkextra.Items.Count; i++)
            {
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chkextra.Items[i].Value.ToString() == abc[j].Trim())
                        chkextra.Items[i].Selected = true;
                }
            }
            btnSave.Text = "Update";
            btnClear.Text = "Cancel";
            lblstudid.Text = Request["intID"].ToString();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ex.Message + "')", true);
        }
    }

    protected void fillstandard()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strstandard from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString()+"' group by strstandard";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
        fillsubject_Extracurricular_teacher();
    }

    protected void fillsection()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strsection from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strsection";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        ddlsection.Items.Insert(0, "--Select--");
        fillsubject_Extracurricular_teacher();
    }

    protected void fillLanguages()
    {
        string str;
        DataSet ds=new DataSet();
        DataAccess da = new DataAccess();
        if (lblsubjects.Text.IndexOf("Second Language") > -1)
        {
            str = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlsecondlanguage.DataSource = ds;
            ddlsecondlanguage.DataTextField = "strlanguagename";
            ddlsecondlanguage.DataValueField = "strlanguagename";
            ddlsecondlanguage.DataBind();
            ddlsecondlanguage.Items.Insert(0, "--Select--");
            ddlsecondlanguage.Enabled = true;
        }
        else
            ddlsecondlanguage.Enabled = false;

        if (lblsubjects.Text.IndexOf("Third Language") > -1)
        {
            str = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            ddlthirdlanguage.DataSource = ds;
            ddlthirdlanguage.DataTextField = "strlanguagename";
            ddlthirdlanguage.DataValueField = "strlanguagename";
            ddlthirdlanguage.DataBind();
            ddlthirdlanguage.Items.Insert(0, "--Select--");
            ddlthirdlanguage.Enabled = true;
        }
        else
            ddlthirdlanguage.Enabled = false;
    }

    protected void fillcountry()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strcountryname,intcountryID from tblcountry order by strcountryname";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlcountry.DataSource = ds;
        ddlcountry.DataTextField = "strcountryname";
        ddlcountry.DataValueField = "intcountryID";
        ddlcountry.DataBind();
        

        ddlFcountry.DataSource = ds;
        ddlFcountry.DataTextField = "strcountryname";
        ddlFcountry.DataValueField = "intcountryID";
        ddlFcountry.DataBind();
        

        ddlMcountry.DataSource = ds;
        ddlMcountry.DataTextField = "strcountryname";
        ddlMcountry.DataValueField = "intcountryID";
        ddlMcountry.DataBind();
        
    }
    protected void fillstate()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strstate,intstateID from tblstate where intcountryid=" + ddlcountry.SelectedValue+" order by strstate";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "strstate";
        ddlstate.DataValueField = "intstateID";
        ddlstate.DataBind();
        
    }
    protected void fillFstate()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strstate,intstateID from tblstate where intcountryid=" + ddlFcountry.SelectedValue+" order by strstate";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlFstate.DataSource = ds;
        ddlFstate.DataTextField = "strstate";
        ddlFstate.DataValueField = "intstateID";
        ddlFstate.DataBind();
       
    }
    protected void fillMstate()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strstate,intcountryID from tblstate where intcountryid=" + ddlMcountry.SelectedValue+" order by strstate";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlMstate.DataSource = ds;
        ddlMstate.DataTextField = "strstate";
        ddlMstate.DataValueField = "intcountryID";
        ddlMstate.DataBind();
       
    }
    protected void fillFcity()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strcity,intcityID from tblcity where intstateid=" + ddlFstate.SelectedValue+" order by strcity";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlFcity.DataSource = ds;
        ddlFcity.DataTextField = "strcity";
        ddlFcity.DataValueField = "intcityID";
        ddlFcity.DataBind();
        
    }
    protected void fillMcity()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strcity,intcityID from tblcity where intstateid=" + ddlMstate.SelectedValue + " order by strcity";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlMcity.DataSource = ds;
        ddlMcity.DataTextField = "strcity";
        ddlMcity.DataValueField = "intcityID";
        ddlMcity.DataBind();
        
    }
    protected void fillcity()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strcity,intcityID from tblcity where intstateid=" + ddlstate.SelectedValue + " order by strcity";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlcity.DataSource = ds;
        ddlcity.DataTextField = "strcity";
        ddlcity.DataValueField = "intcityID";
        ddlcity.DataBind();
        
    }

    protected void fillhouse()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblschoolhouse where intschool="+Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlhouse.DataSource = ds;
        ddlhouse.DataTextField = "strhousename";
        ddlhouse.DataValueField = "strhousename";
        ddlhouse.DataBind();
        ddlhouse.Items.Insert(0, "--Select--");
    }

    protected void fillroute()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblroute where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlroute.DataSource = ds;
        ddlroute.DataTextField = "strroutename";
        ddlroute.DataValueField = "intid";
        ddlroute.DataBind();
        ListItem li;
        li = new ListItem("---Select---", "0");
        ddlroute.Items.Insert(0, li);
    }

    protected void fillsubject_Extracurricular_teacher()
    {
        try
        {
            string str;
            DataSet ds;
            DataAccess da = new DataAccess();
            str = "select strsubject from tblstandard_section_subject where strstandard='" + ddlstandard.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = da.ExceuteSql(str);
            lblsubjects.Text = "";
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                if (lblsubjects.Text == "")
                    lblsubjects.Text = lblsubjects.Text + ds.Tables[0].Rows[j]["strsubject"].ToString();
                else
                    lblsubjects.Text = lblsubjects.Text + "," + ds.Tables[0].Rows[j]["strsubject"].ToString();
            }

            str = "select * from tblstandard_section_extraCurricular  where strstandard='" + ddlstandard.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = da.ExceuteSql(str);
            chkextra.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strcurricular"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                chkextra.Items.Add(li);
            }

            if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
            {
                string stdsec = ddlstandard.SelectedValue + " - " + ddlsection.SelectedValue;

                str = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername from tblemployee a,tblhomeclass b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.intemployee and b.strhomeclass='" + stdsec + "'";
                ds = new DataSet();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblteacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
                    btnassignhome.Visible = false;
                }
                else
                {
                    lblteacher.Text = "No Home Teacher assigned for the selected standard and section";
                    btnassignhome.Visible = true;
                }
            }
            fillLanguages();
        }
        catch { }
    }

    protected void ddlroute_SelectedIndexChanged(object sender, EventArgs e)
    {
        vehicleAnddriver();
    }

    protected void vehicleAnddriver()
    {
        try
        {
            string str;
            DataSet ds,ds1;
            DataAccess da = new DataAccess();
            str = "select a.*, b.strvehicleno from tblroute a,dbo.tblvehiclemaster b where a.intvehicle=b.intid and a.intid=" + ddlroute.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbusnumber.Text = ds.Tables[0].Rows[0]["strvehicleno"].ToString();
            }

            str = "select a.*,b.strdrivername from tblroute a,tbldriver b where a.intdriver=b.intid and a.intid=" + ddlroute.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
                lbldriver.Text = ds.Tables[0].Rows[0]["strdrivername"].ToString();

            str = "select *,CONVERT(VARCHAR(5),dtpickuptime,108) as picktime,CONVERT(VARCHAR(5),dtdroptime,108)as droptime from dbo.tblassignbusroute where introute=" + ddlroute.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(str);
            ListItem li;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds1.Tables[0].Rows[i]["strdestination"].ToString() + " - Pick Time :" + ds1.Tables[0].Rows[i]["picktime"].ToString() + " - Drop Time :" + ds1.Tables[0].Rows[i]["droptime"].ToString(), ds1.Tables[0].Rows[i]["intid"].ToString());
                ddlpickanddrop.Items.Add(li);
            }
            li = new ListItem("---Select---", "0");
            ddlpickanddrop.Items.Insert(0, li);
        }
        catch { }
    }
    protected string selectedExtraCurricular()
    {
        string str = "";
        for (int i = 0; i <chkextra.Items.Count; i++)
        {
            if (chkextra.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkextra.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkextra.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int interror=0;
            if (ddlreli.SelectedValue == "")
            {
                if (txtreligion.Text == "")
                    interror = 1;
            }
            //if (ddlmobileforsms.SelectedValue == "Other")
            //{
            //    if (txtothermobileno.Text == "")
            //        interror = 2;
            //}
            //if (ddlmobileforsms.SelectedIndex == 0)
            //        interror = 3;
            if (interror == 0)
            {
                SqlCommand command;
                SqlParameter outparam;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("SpStudent", conn);
                command.CommandType = CommandType.StoredProcedure;
                outparam = command.Parameters.Add("@ID", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                if (btnSave.Text == "Save")
                {
                    command.Parameters.Add("@intid", "0");
                }
                else
                {
                    command.Parameters.Add("@intid", lblstudid.Text);
                }
                command.Parameters.Add("@strFirstname", txtfirst.Text.Trim());
                command.Parameters.Add("@strmiddlename", txtmiddle.Text.Trim());
                command.Parameters.Add("@strLastname", txtlast.Text.Trim());
                command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
                command.Parameters.Add("@strsection", ddlsection.SelectedValue);
                command.Parameters.Add("@intadmitno", txtadmitno.Text.Trim());
                if(txtadmitdate.Text !="")
                command.Parameters.Add("@stradmitdate", txtadmitdate.Text.Trim());
                else
                command.Parameters.Add("@stradmitdate", "1900/01/01");
                command.Parameters.Add("@introllno", "");
                command.Parameters.Add("@strstudentbirthcertificateno", txtstudentbirth.Text.Trim());
                command.Parameters.Add("@strstudentpassportoricno", "");
                string gender;
                if (RBfemale.Checked)
                    gender = RBfemale.Text;
                else
                    gender = RBmale.Text;
                command.Parameters.Add("@strgender", gender);
                if (txtbirthdate.Text != "")
                command.Parameters.Add("@strdateofbirth", txtbirthdate.Text.Trim());
                else
                    command.Parameters.Add("@strdateofbirth", "1900/01/01");
                command.Parameters.Add("@intAge", getage());
                command.Parameters.Add("@intheight", txtheight.Text.Trim());
                //command.Parameters.Add("@Weight", txtweight.Text.Trim());
                if (txtweight.Text == "")
                {
                    command.Parameters.Add("@Weight", "0.00");
                }
                else
                {
                    command.Parameters.Add("@Weight", txtweight.Text.Trim());
                }
                command.Parameters.Add("@stridentification1", txtidentification1.Text.Trim());
                command.Parameters.Add("@stridentification2", txtidentification2.Text.Trim());
                command.Parameters.Add("@strnationality", txtnationality.Text.Trim());
                if (ddlreli.SelectedIndex > 0)
                {
                    if (ddlreli.SelectedValue == "Others")
                        command.Parameters.Add("@strreligion", txtreligion.Text.Trim());
                    else
                        command.Parameters.Add("@strreligion", ddlreli.SelectedValue);
                }
                else
                {
                    command.Parameters.Add("@strreligion", txtreligion.Text.Trim());
                }

                //if (ddlreli.SelectedValue == "Others")
                //    command.Parameters.Add("@strreligion", txtreligion.Text.Trim());
                //else
                //    command.Parameters.Add("@strreligion", ddlreli.SelectedValue);
                command.Parameters.Add("@strcommunity", "");
                command.Parameters.Add("@strcaste", "");
                command.Parameters.Add("@strresidanceaddress", txtresidential.Text.Trim());
                command.Parameters.Add("@intcountry", ddlcountry.SelectedValue);
                command.Parameters.Add("@intstate", ddlstate.SelectedValue);
                command.Parameters.Add("@intcity", ddlcity.SelectedValue);
                command.Parameters.Add("@strzipcode", txtzipcode.Text.Trim());
                command.Parameters.Add("@strphone", txtphoneno.Text.Trim());
                command.Parameters.Add("@strmobile", txtmobile.Text.Trim());
                if (txtaltmobileno.Text == "")
                    command.Parameters.Add("@straltmobile", "0");
                else
                    command.Parameters.Add("@straltmobile", txtaltmobileno.Text.Trim());
                if (ddlhouse.SelectedValue == "--Select--")
                    command.Parameters.Add("@strhouse", "");
                else
                    command.Parameters.Add("@strhouse", ddlhouse.SelectedValue);
                command.Parameters.Add("@strbloodgroup", ddlbloodgroup.SelectedValue);
                command.Parameters.Add("@strallergies", txtallergies.Text.Trim());

                command.Parameters.Add("@strfatherorguardname", txtfathername.Text.Trim());
                command.Parameters.Add("@strfatherORguardOccupation", txtfatherOccupation.Text.Trim());
                command.Parameters.Add("@strfatherorguarddesignation", txtfatherdesignation.Text.Trim());
                command.Parameters.Add("@strfathercompanyname", txtfatherorganisation.Text.Trim());
                command.Parameters.Add("@strfathercompanyaddress", txtfatherworkaddress.Text.Trim());
                command.Parameters.Add("@str_Parent_details", ddlparent.SelectedValue);
                if (ddlparent.SelectedValue == "Father" || ddlparent.SelectedValue == "Father & Mother")
                {
                    command.Parameters.Add("@intFcountry", ddlFcountry.SelectedValue);
                    command.Parameters.Add("@intfathercompanystate", ddlFstate.SelectedValue);
                    command.Parameters.Add("@intfathercompanycity", ddlFcity.SelectedValue);
                }
                else
                {
                    command.Parameters.Add("@intFcountry", "0");
                    command.Parameters.Add("@intfathercompanystate", "0");
                    command.Parameters.Add("@intfathercompanycity", "0");
                }
                command.Parameters.Add("@fathercompanyzipcode", txtfatherpincode.Text.Trim());
                command.Parameters.Add("@str_Father_Off_phone", txtFofficephone.Text.Trim());
                command.Parameters.Add("@str_Father_email", txtfatheremail.Text.Trim());
                command.Parameters.Add("@fathermobileno", txtfathermobileno.Text.Trim());
                command.Parameters.Add("@str_Father_income","");
                command.Parameters.Add("@strmothername", txtmothername.Text.Trim());
                command.Parameters.Add("@strmothermobileno", txtmothermobileno.Text.Trim());
                command.Parameters.Add("@strparentpassportoricno", txtparentpassport.Text.Trim());
                command.Parameters.Add("@stremergencyname", txtemergencyname.Text.Trim());
                //string gender1;
                //if (RBfemale.Checked)
                //    gender1 = RBfemale1.Text;
                //else
                //    gender1 = RBmale1.Text;
                //command.Parameters.Add("@strgender", gender);
                command.Parameters.Add("@stremergencypassportoricno", txtemergencypassport.Text.Trim());
                command.Parameters.Add("@stremergencyofficeno", txtemergencyoffice.Text.Trim());
                command.Parameters.Add("@stremergencymobileno", txtemergencymobile.Text.Trim());
                command.Parameters.Add("@stremergencyhouseno", txtemergencyhome.Text.Trim());
                command.Parameters.Add("@stremergencyrelation", txtrelation.Text.Trim());
                
                if (RBhomemaker.Checked)
                {
                    command.Parameters.Add("@strmotheroccupation", RBhomemaker.Text);
                    command.Parameters.Add("@strmotherdesignation", "0");
                    command.Parameters.Add("@strmothercompanyname", "0");
                    command.Parameters.Add("@strmothercompanyaddress", "0");
                    command.Parameters.Add("@intMcountry", "0");
                    command.Parameters.Add("@intmothercompanystate", "0");
                    command.Parameters.Add("@intmothercompanycity", "0");
                    command.Parameters.Add("@strmothercompanyzipcode", "0");
                    command.Parameters.Add("@str_mother_income", "0");
                    command.Parameters.Add("@str_mother_off_phone", "0");
                    command.Parameters.Add("@str_mother_email", "0");
                }
                else
                {
                    command.Parameters.Add("@strmotheroccupation", RBother.Text);
                    command.Parameters.Add("@strmotherdesignation", txtmotherdesignation.Text.Trim());
                    command.Parameters.Add("@strmothercompanyname", txtmotherorganisation.Text.Trim());
                    command.Parameters.Add("@strmothercompanyaddress", txtmotherworkaddress.Text.Trim());
                    command.Parameters.Add("@str_mother_income", "");
                    command.Parameters.Add("@str_mother_off_phone", txtMofficephone.Text.Trim());
                    command.Parameters.Add("@str_mother_email", txtMemail.Text.Trim());
                    if (ddlparent.SelectedValue == "Father & Mother" || ddlparent.SelectedValue == "Mother")
                    {
                        command.Parameters.Add("@intMcountry", ddlMcountry.SelectedValue);
                        command.Parameters.Add("@intmothercompanystate", ddlMstate.SelectedValue);
                        command.Parameters.Add("@intmothercompanycity", ddlMcity.SelectedValue);
                    }
                    else
                    {
                        command.Parameters.Add("@intMcountry", "0");
                        command.Parameters.Add("@intmothercompanystate", "0");
                        command.Parameters.Add("@intmothercompanycity", "0");
                    }
                    command.Parameters.Add("@strmothercompanyzipcode", txtmotherpincode.Text.Trim());

                }
                if (txtnoofsiblings.Text == "")
                    command.Parameters.Add("@intsiblings", "0");
                else
                    command.Parameters.Add("@intsiblings", txtnoofsiblings.Text.Trim());
                if (txtsiblingdetails.Text == "")
                    command.Parameters.Add("@strsiblingdetails", "0");
                else
                    command.Parameters.Add("@strsiblingdetails", txtsiblingdetails.Text.Trim());
                if (ddlmobileforsms.SelectedValue == "--Select--")
                    command.Parameters.Add("@strmobilenoforsms", "");
                else
                    command.Parameters.Add("@strmobilenoforsms", ddlmobileforsms.SelectedValue);

                command.Parameters.Add("@strcorrespondanceaddress", txtcorresaddress.Text.Trim());
                if (txtothermobileno.Text == "")
                    command.Parameters.Add("@strothernoforsms", "0");
                else
                    command.Parameters.Add("@strothernoforsms", txtothermobileno.Text.Trim());
                command.Parameters.Add("@strparentsemailid", txtpersonalemail.Text.Trim());
                command.Parameters.Add("@strsecondlanguage", ddlsecondlanguage.SelectedValue);
                command.Parameters.Add("@strthirdlanguage", ddlthirdlanguage.SelectedValue);
                command.Parameters.Add("@strExtracurricular", selectedExtraCurricular());
                command.Parameters.Add("@introute", ddlroute.SelectedValue);
                command.Parameters.Add("@intTransportdestination", ddlpickanddrop.SelectedValue);
                command.Parameters.Add("@stroriginaldocuments", txtdocuments.Text.Trim());
                command.Parameters.Add("@strotherRemarks", txtremarks.Text.Trim());
                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                command.Parameters.Add("@previousinstitute", txtprviousinstitute.Text);
                if(txtdateofreg.Text!="")
                command.Parameters.Add("@Date_of_Registration", txtdateofreg.Text.Trim());
                else
                    command.Parameters.Add("@Date_of_Registration", "1900/01/01");
                command.Parameters.Add("@str_App_No", txtappnumber.Text.Trim());
                command.Parameters.Add("@str_MotherTongue", txtmothertongue.Text.Trim());
                command.Parameters.Add("@str_Previous_class", txtpreviousclass.Text.Trim());
                command.Parameters.Add("@str_Concession_details", txtconcession.Text.Trim());

                string transport = "";
                if (rbschool.Checked == true)
                    transport = rbschool.Text;
                else
                    transport = rbown.Text;
                command.Parameters.Add("@str_Transport", transport);
                int hostler;
                if (hostleryes.Checked)
                    hostler = 1;
                else
                    hostler = 0;
                command.Parameters.Add("@hostler", hostler);
                command.ExecuteNonQuery();
                string id = Convert.ToString(outparam.Value);
                if (btnSave.Text == "Save")
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 21);
                }
                else
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 123);
                }
                if ((int)(command.Parameters["@ID"].Value) > 0)
                {
                    int sid = (int)(command.Parameters["@ID"].Value);
                    if (FileUpload1.PostedFile.FileName != "")
                    {
                        FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + sid + ".jpg");
                    }
                    lblstudid.Text = sid.ToString();
                    if (btnSave.Text == "Save")
                    {
                        DataAccess da = new DataAccess();
                        string str = "update tblstudent set strstudentusername=strfirstname+ltrim(str(intid)),strstudentpassword=(SELECT ltrim(substring(str(floor(RAND((DATEPART(mm, GETDATE()) * 100000)+ (DATEPART(ss, GETDATE()) * 1000 )+ DATEPART(ms, GETDATE())) * 1000000000)),1,7))) where intid=" + sid.ToString();
                        //Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", sid.ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),21);

                        da.ExceuteSqlQuery(str);

                        da = new DataAccess();
                        string str2 = "update tblstudent set strparentusername=strfirstname+ltrim(str(intid)),strparentpassword=(SELECT ltrim(substring(str(floor(RAND((DATEPART(mm, GETDATE()) * 100000)+ (DATEPART(ss, GETDATE()) * 1000 )+ DATEPART(ms, GETDATE())) * 1000000000)),1,7))) where intid=" + sid.ToString();
                        //Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", sid.ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),21);

                        da.ExceuteSqlQuery(str2);

                        da = new DataAccess();
                        str2 = "select strparentsemailid,strfatherorguardname,strparentusername,strparentpassword,strstudentusername,strstudentpassword,strschoolname, strsubdomain from tblstudent a, tblschool b where a.intschool=b.intschoolid and a.intid=" + sid.ToString();
                        DataSet ds=new DataSet();
                        ds=da.ExceuteSql(str2);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string msg = "";
                            msg = msg + "    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"700\">";
                            msg = msg + "        <tr>";
                            msg = msg + "            <td style=\"width: 125px; height: 75px\" align=\"left\"><img src=\"http://www.theschools.in/Media/Images/emaillogotop.png\" border=\"0\" alt=\"logo\" /></td>";
                            msg = msg + "            <td style=\"width: 575px; height: 75px; font-family: Arial Black; font-size: 20px\" align=\"left\"></td>";
                            msg = msg + "        </tr>";
                            msg = msg + "        <tr>";
                            msg = msg + "            <td colspan=\"2\" style=\"width: 700px; padding-top: 20px; padding-bottom: 20px; text-align: justify; line-height: 25px; font-family: Tahoma; font-size: 12px\">";
                            msg = msg + "Dear " + ds.Tables[0].Rows[0]["strfatherorguardname"].ToString() + "<br/>";
                            msg = msg + "Welcome to " + ds.Tables[0].Rows[0]["strschoolname"].ToString() + " web portal<br/>";
                            msg = msg + "For your convenience, here are your login details for yourself and your ward<br/><br/>";
                            msg = msg + "Your school site :<a href=\"http://" + ds.Tables[0].Rows[0]["strsubdomain"].ToString() + ".theschools.in\">http://" + ds.Tables[0].Rows[0]["strsubdomain"].ToString() + ".theschools.in</a><br />";
                            msg = msg + "Parent login credentials : <br/>";
                            msg = msg + "Username : " + ds.Tables[0].Rows[0]["strparentusername"].ToString() + "<br/>";
                            msg = msg + "Password : " + ds.Tables[0].Rows[0]["strparentpassword"].ToString() + "<br/><br/>";
                            msg = msg + "Student login credentials : <br/>";
                            msg = msg + "Username : " + ds.Tables[0].Rows[0]["strstudentusername"].ToString() + "<br/>";
                            msg = msg + "Password : " + ds.Tables[0].Rows[0]["strstudentpassword"].ToString() + "<br/><br/>";
                            msg = msg + "Should you need any assistance when you're on the website, please mail us on <a href=\"mail: support@theschools.in>TheSchools.in - Support Team</a><br /><br />";
                            msg = msg + "Thanks<br/>";
                            msg = msg + "Best Regards,<br/>";
                            msg = msg + "" + ds.Tables[0].Rows[0]["strschoolname"].ToString() + " Management<br/>";
                            msg = msg + "            </td>";
                            msg = msg + "        </tr>";
                            msg = msg + "        <tr>";
                            msg = msg + "            <td colspan=\"2\" style=\"width: 700px; height: 75px\" align=\"center\">";
                            msg = msg + "                <img src=\"http://www.theschools.in/Media_front/Images/logo.png\" border=\"0\" alt=\"logo\" /><br /><br />";
                            msg = msg + "            </td>";
                            msg = msg + "        </tr>";
                            msg = msg + "    </table>";
                            Functions.Sendmail1(ds.Tables[0].Rows[0]["strparentsemailid"].ToString(), "support@theschools.in", "Login Credentials", msg);
                        }
                    }
                }

                conn.Close();
                //if (btnSave.Text == "Save")
                //{
                //    DataAccess da = new DataAccess();
                //    da.filllogs(int.Parse(Session["UserID"].ToString()), "Student added", int.Parse(lblstudid.Text), int.Parse(Session["SchoolID"].ToString()));
                //}
                //else if (btnSave.Text == "Update")
                //{
                //    DataAccess da = new DataAccess();
                //    da.filllogs(int.Parse(Session["UserID"].ToString()), "Student Updated", int.Parse(lblstudid.Text), int.Parse(Session["SchoolID"].ToString()));
                //}
                clear();
                if (Request["intID"] != null)
                {
                    if (Request["rd"] != null)
                    {
                        if (Request["rd"].ToString() == "1")
                        {
                            //Response.Redirect("view_studentdetails.aspx?rd=" + Request["rd"].ToString());
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Updated Successfully!'); location.href='view_studentdetails.aspx?rd=1';", true);
                        }
                        if (Request["rd"].ToString() == "2")
                        {
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully')", true);
                            //Response.Redirect("edit_student_details.aspx?intid=" + Request["rd"].ToString());
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Updated Successfully!'); location.href='edit_student_details.aspx?rd=2';", true);

                            
                        }
                       
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
            }
            else if (interror == 1)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter the Other Religion')", true);
            //else if (interror == 2)
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter the Other Mobile No for SMS')", true);
            //else if (interror == 3)
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Mobile No for SMS')", true);
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ex.Message + "')", true);
        }
    }
    protected void RBhomemaker_CheckedChanged(object sender, EventArgs e)
    {
        tag1.Visible = false;
        tag2.Visible = false;
        tag3.Visible = false;
        tag4.Visible = false;
        tag5.Visible = false;
        lblMdesig.Visible = false;
        txtmotherdesignation.Visible = false;
    }
    protected void RBother_CheckedChanged(object sender, EventArgs e)
    {
        tag1.Visible = true;
        tag2.Visible = true;
        tag3.Visible = true;
        tag4.Visible = true;
        tag5.Visible = false;
        lblMdesig.Visible = true;
        txtmotherdesignation.Visible = true;
    }
    protected void clear()
    {
        txtfirst.Text = "";
        txtmiddle.Text = "";
        txtlast.Text = "";
        txtadmitno.Text = "";
        txtadmitdate.Text = "";
        txtrollno.Text = "";
        txtbirthdate.Text = "";
        txtheight.Text = "";
        txtidentification1.Text = "";
        txtidentification2.Text = "";
        txtnationality.Text = "";       
        txtresidential.Text = "";
        txtzipcode.Text = "";
        txtphoneno.Text = "";
        txtmobile.Text = "";
        txtaltmobileno.Text = "";        
        txtallergies.Text = "";
        txtfathername.Text = "";
        txtfatherOccupation.Text = "";
        txtfatherorganisation.Text = "";
        txtfatherdesignation.Text = "";
        txtfatherworkaddress.Text = "";
        txtfathermobileno.Text = "";
        txtfatherpincode.Text = "";
        txtfatheremail.Text = "";
        txtfatherincome.Text = "";
        txtFofficephone.Text = "";
        txtmothername.Text = "";
        txtmotherdesignation.Text = "";
        txtmothermobileno.Text = "";
        txtmotherorganisation.Text = "";
        txtmotherpincode.Text = "";
        txtmotherworkaddress.Text = "";        
        txtnoofsiblings.Text = "";
        txtsiblingdetails.Text = "";
        txtpersonalemail.Text = "";
        txtothermobileno.Text = "";
        txtcorresaddress.Text = "";
        txtdocuments.Text = "";
        txtremarks.Text = "";
        txtprviousinstitute.Text = "";
        txtappnumber.Text = "";
        txtdateofreg.Text = "";
        //txtcaste.Text = "";
        txtmothertongue.Text = "";
        txtweight.Text = "";
        txtpreviousclass.Text = "";
        txtconcession.Text = "";
        txtstudentbirth.Text = "";
        txtstudentpassport.Text = "";
        txtparentpassport.Text = "";
        txtemergencyname.Text = "";
        txtemergencypassport.Text = "";
        txtemergencyoffice.Text = "";
        txtemergencymobile.Text = "";
        txtemergencyhome.Text = "";
        txtrelation.Text = "";
        fillroute();
        fillstandard();
        fillsection();
        fillhouse();
        fillcountry();
        RBhomemaker.Checked = true;
        RBother.Checked = false;
        tag1.Visible = false;
        RBother.Checked = true;
        RBmale.Checked = true;
        RBsN.Checked = true;
        trtag.Visible = false;
        hostleryes.Checked = true;
        hostlerno.Checked = false;
        trtransport.Visible = false;
        trtransporthead.Visible = false;
        rbschool.Checked = false;
        rbown.Checked = false;
        lblteacher.Text = "Please select standard and section";
        lblsubjects.Text = "Please select standard and section";
        lblbusnumber.Text = "please select the route";
        lbldriver.Text = "Please select the route";
        ddlstate.Items.Clear();
        ddlstate.Items.Insert(0, "--Select--");
        ddlFstate.Items.Clear();
        ddlFstate.Items.Insert(0, "--Select--");
        ddlMstate.Items.Clear();
        ddlMstate.Items.Insert(0, "--Select--");
        ddlFcity.Items.Clear();
        ddlFcity.Items.Insert(0, "--Select--");
        ddlMcity.Items.Clear();
        ddlMcity.Items.Insert(0, "--Select--");
        ddlcity.Items.Clear();
        ddlcity.Items.Insert(0, "--Select--");
        //ddlcommunity.SelectedIndex = 0;
        ddlcountry.Items.Insert(0, "--Select--");
        ddlFcountry.Items.Insert(0, "--Select--");
        ddlMcountry.Items.Insert(0, "--Select--");
        ddlbloodgroup.SelectedValue = "0";
        ddlsecondlanguage.Items.Insert(0, "--Select--");
        //ddlreli.Items.Insert(0, "Select");
        ddlreli.SelectedValue = "0";
        txtreligion.Text ="";
        Mtag.Visible = false;
        rbschool.Checked = true;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (btnClear.Text == "Cancel")
        {
            if (Request["rd"] != null)
            {
                if (Request["rd"].ToString() == "1")
                {
                    Response.Redirect("student_details.aspx?rd=" + Request["rd"].ToString());
                }
                if (Request["rd"].ToString() == "2")
                {
                    Response.Redirect("edit_student_details.aspx?rd=" + Request["rd"].ToString());
                }
            }
        }
        else
            clear();
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstate();
        fillcity();
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillcity();
    }

    protected void ddlFcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFstate();
        fillFcity();
    }

    protected void ddlFstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFcity();
    }

    protected void ddlMcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillMstate();
        fillMcity();
    }
    protected void ddlMstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillMcity();
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile == null || String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) || FileUpload1.PostedFile.InputStream == null)
        {
            lit_Status.Text = "<br />Error - unable to upload file. Please try again.<br />";
        }
        else
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("SPstudentimages", conn);
                command.CommandType = CommandType.StoredProcedure; 
                byte[] imageBytes = new byte[FileUpload1.PostedFile.InputStream.Length + 1];
                FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);
                command.Parameters.AddWithValue("@strimage", FileUpload1.PostedFile.ContentType);
                command.Parameters.AddWithValue("@BinaryData", imageBytes);
                command.Parameters.AddWithValue("@DateTimeUploaded", DateTime.Now);
                command.Parameters.AddWithValue("@intschool", Session["SchoolID"].ToString());
                command.ExecuteNonQuery();
                conn.Close();                
                lit_Status.Text = "<br />File successfully uploaded - thank you.<br />";
                
           }
           catch{}
        }       

    }
    protected string getage()
    {
        string strsql = "select year(getdate()) as gyear,year('"+ txtbirthdate.Text+"') as dobyear, year(getdate())-year('" + txtbirthdate.Text + "') as age,month('" + txtbirthdate.Text + "') as dobmonth,month(getdate()) as gmonth,day('" + txtbirthdate.Text + "') as dobday,day(getdate()) as gday";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        string gmonth = ds.Tables[0].Rows[0]["gmonth"].ToString();
        string dobmonth = ds.Tables[0].Rows[0]["dobmonth"].ToString();
        string dobday = ds.Tables[0].Rows[0]["dobday"].ToString();
        string gday = ds.Tables[0].Rows[0]["gday"].ToString();
        string z = ds.Tables[0].Rows[0]["age"].ToString();
        int zy = int.Parse(z);
        int gm = int.Parse(gmonth);
        int dm = int.Parse(dobmonth);
        int gd = int.Parse(gday);
        int dd = int.Parse(dobday);
        int gy = int.Parse(ds.Tables[0].Rows[0]["gyear"].ToString());
        int doby = int.Parse(ds.Tables[0].Rows[0]["dobyear"].ToString());
        if (doby < gy)
        {
            if (gm > dm)
            {
                return z.ToString();
            }
            else if (gm == dm)
            {
                if (gd > dd)
                    return z.ToString();
                else
                    return (zy - 1).ToString();
            }
            else
                return (zy - 1).ToString();
        }
        else
        {
            return "0";
        }
    }
    protected void RBsY_CheckedChanged(object sender, EventArgs e)
    {
        trtag.Visible = true;
    }
    protected void RBsN_CheckedChanged(object sender, EventArgs e)
    {
        trtag.Visible = false;
    }
    protected void hostleryes_CheckedChanged(object sender, EventArgs e)
    {
        rbschool.Enabled = false;
        rbown.Enabled = false;
        tr1.Visible = false;
        tr2.Visible = false;
        //tr4.Visible = true;
    }
    protected void hostlerno_CheckedChanged(object sender, EventArgs e)
    {
        rbschool.Enabled = true;
        rbown.Enabled = true;
        //tr4.Visible = false;
        if (rbschool.Checked == true)
        {
            tr1.Visible = true;
            tr2.Visible = true;            
        }
        else if(rbown.Checked ==true)
        {
            tr1.Visible = false;
            tr2.Visible = false;
        }
    }
    protected void rbschool_CheckedChanged(object sender, EventArgs e)
    {
        tr1.Visible = true;
        tr2.Visible = true;
    }
    protected void rbown_CheckedChanged(object sender, EventArgs e)
    {
        tr1.Visible = false;
        tr2.Visible = false;
    }
    protected void ddlparent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlparent.SelectedValue == "Father & Mother")
        {
            Ftag.Visible = true;
            Mtag.Visible = true;
        }
        else if (ddlparent.SelectedValue == "Father/Guardian")
        {
            Ftag.Visible = true;
            Mtag.Visible = false;
        }
        else if (ddlparent.SelectedValue == "Mother")
        {
            Ftag.Visible = false;
            Mtag.Visible = true;
        }        
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject_Extracurricular_teacher();
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject_Extracurricular_teacher();
    }
    protected void hostleryes_CheckedChanged1(object sender, EventArgs e)
    {
        if (hostleryes.Checked)
        {
            trtransport.Visible = false;
            trtransporthead.Visible = false;
        }
        else
        {
            trtransport.Visible = true;
            trtransporthead.Visible = true;
        }
    }
    protected void hostlerno_CheckedChanged1(object sender, EventArgs e)
    {
        if (hostlerno.Checked)
        {
            trtransport.Visible = true;
            trtransporthead.Visible = true;
        }
        else
        {
            trtransport.Visible = false;
            trtransporthead.Visible = false;
        }
    }
    protected void ddlmobileforsms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmobileforsms.SelectedIndex > 0)
        {
            if (ddlmobileforsms.SelectedValue == "Father")
            {
                if (txtfathermobileno.Text != "")
                {
                    txtothermobileno.Text = txtfathermobileno.Text;
                    txtothermobileno.Enabled = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter Father Mobile No')", true);
                    ddlmobileforsms.SelectedIndex = 0;
                }
            }
            else if (ddlmobileforsms.SelectedValue == "Mother")
            {
                if (txtmothermobileno.Text != "")
                {
                    txtothermobileno.Text = txtmothermobileno.Text;
                    txtothermobileno.Enabled = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter Mother Mobile No')", true);
                    ddlmobileforsms.SelectedIndex = 0;
                }
            }
            else if (ddlmobileforsms.SelectedValue == "Other")
            {
                txtothermobileno.Text = "";
                txtothermobileno.Enabled = true;
            }
        }
    }
    protected void btnassignhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("addeditstaff.aspx");
    }
    protected void ddlreli_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlreli.SelectedValue == "Others")
        {
            txtreligion.Visible = true;
        }
        else
        {
            txtreligion.Visible = false;
        }
    }
    protected void txtstudentbirth_TextChanged(object sender, EventArgs e)
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblstudent where strstudentbirthcertificateno='" + txtstudentbirth.Text + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This id already registered')", true);
        }
     }
    protected void txtadmitno_TextChanged(object sender, EventArgs e)
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblstudent where intadmitno='" + txtadmitno.Text + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This id already registered')", true);
        }
    }
}


