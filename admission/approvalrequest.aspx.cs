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

public partial class admission_approvalrequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tredit.Visible = false;
            //age();
            //fatheroccupation();
            //fatherqualification();
            //standard();
            //student();
            //motheroccupation();
            //motherqualification();
            //hostel();
            //transport();
            //staff();
            //department();
            //designation();
            year();
        }
    }
    protected void standard()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select str_standard from dbo.tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_standard";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "str_standard";
        ddlstandard.DataValueField = "str_standard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");
        ddlstandard.Items.Insert(1, "-All-");
    }
    protected void student()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select str_firstname +' '+ str_middlename +' '+ str_lastname as name,intid from dbo.tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "-Select-");
    }

    protected void motherqualification()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_motherqualification from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_motherqualification";
        ds = da.ExceuteSql(str);
        searchbymotherqualification.DataSource = ds;
        searchbymotherqualification.DataTextField = "str_motherqualification";
        searchbymotherqualification.DataValueField = "str_motherqualification";
        searchbymotherqualification.DataBind();
        searchbymotherqualification.Items.Insert(0, "-Select-");
    }
    protected void motheroccupation()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_motheroccupation from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_motheroccupation";
        ds = da.ExceuteSql(str);
        searchbymotheroccupation.DataSource = ds;
        searchbymotheroccupation.DataTextField = "str_motheroccupation";
        searchbymotheroccupation.DataValueField = "str_motheroccupation";
        searchbymotheroccupation.DataBind();
        searchbymotheroccupation.Items.Insert(0, "-Select-");
    }
    protected void fatherqualification()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_fatherorguardianqualification from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_fatherorguardianqualification";
        ds = da.ExceuteSql(str);
        searchbyfatherqualification.DataSource = ds;
        searchbyfatherqualification.DataTextField = "str_fatherorguardianqualification";
        searchbyfatherqualification.DataValueField = "str_fatherorguardianqualification";
        searchbyfatherqualification.DataBind();
        searchbyfatherqualification.Items.Insert(0, "-Select-");
    }
    protected void fatheroccupation()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_fatherorguardianoccupation from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_fatherorguardianoccupation";
        ds = da.ExceuteSql(str);
        searchbyfatheroccupation.DataSource = ds;
        searchbyfatheroccupation.DataTextField = "str_fatherorguardianoccupation";
        searchbyfatheroccupation.DataValueField = "str_fatherorguardianoccupation";
        searchbyfatheroccupation.DataBind();
        searchbyfatheroccupation.Items.Insert(0, "-Select-");
    }
    protected void hostel()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_hostel from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_hostel";
        ds = da.ExceuteSql(str);
        searchbyhostel.DataSource = ds;
        searchbyhostel.DataTextField = "str_hostel";
        searchbyhostel.DataValueField = "str_hostel";
        searchbyhostel.DataBind();
        searchbyhostel.Items.Insert(0, "-Select-");
    }
    protected void transport()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_transport from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_transport";
        ds = da.ExceuteSql(str);
        searchbytransport.DataSource = ds;
        searchbytransport.DataTextField = "str_transport";
        searchbytransport.DataValueField = "str_transport";
        searchbytransport.DataBind();
        searchbytransport.Items.Insert(0, "-Select-");
    }
    protected void staff()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_staff1 from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_staff1";
        ds = da.ExceuteSql(str);
        searchbystaffname.DataSource = ds;
        searchbystaffname.DataTextField = "str_staff1";
        searchbystaffname.DataValueField = "str_staff1";
        searchbystaffname.DataBind();
        searchbystaffname.Items.Insert(0, "-Select-");
    }
    protected void department()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_department1 from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_department1";
        ds = da.ExceuteSql(str);
        searchbydepartment.DataSource = ds;
        searchbydepartment.DataTextField = "str_department1";
        searchbydepartment.DataValueField = "str_department1";
        searchbydepartment.DataBind();
        searchbydepartment.Items.Insert(0, "-Select-");
    }
    protected void designation()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_designation1 from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by str_designation1";
        ds = da.ExceuteSql(str);
        searchbydesignation.DataSource = ds;
        searchbydesignation.DataTextField = "str_designation1";
        searchbydesignation.DataValueField = "str_designation1";
        searchbydesignation.DataBind();
        searchbydesignation.Items.Insert(0, "-Select-");
    }
    protected void age()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select intage from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and str_standard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        searchbyage.DataSource = ds;
        searchbyage.DataTextField = "intage";
        searchbyage.DataValueField = "intage";
        searchbyage.DataBind();
        searchbyage.Items.Insert(0, "-Select-");
    }
    protected void year()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select intyear from tblstudentadmission where intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "intyear";
        ddlyear.DataValueField = "intyear";
        ddlyear.DataBind();
        //ddlyear.Items.Insert(0, "-Select-");
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ddllist.SelectedValue == "General")
            {
                str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Approved' as status from tblstudentadmission where intapprove=1 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
                str = str + "  union all select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Rejected' as status from tblstudentadmission where intapprove=2 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
                str = str + "  union all select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Waitlisted' as status from tblstudentadmission where intapprove=3 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
                str = str + "  union all select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Status' as status from tblstudentadmission where intapprove=0 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();

                if (ddlstandard.SelectedIndex > 1)
                {
                    str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                }
                if (ddlstudent.SelectedIndex > 0)
                {
                    str = str + "and intid ='" + ddlstudent.SelectedValue + "'";
                }
                if (searchbymotherqualification.SelectedIndex > 0)
                {
                    str = str + "and str_motherqualification='" + searchbymotherqualification.SelectedValue + "'";
                }
                if (searchbymotheroccupation.SelectedIndex > 0)
                {
                    str = str + "and str_motheroccupation='" + searchbymotheroccupation.SelectedValue + "'";
                }
                if (searchbyhostel.SelectedIndex > 0)
                {
                    str = str + "and str_hostel='" + searchbyhostel.SelectedValue + "'";
                }
                if (searchbytransport.SelectedIndex > 0)
                {
                    str = str + "and str_transport='" + searchbytransport.SelectedValue + "'";
                }
                if (searchbystaffname.SelectedIndex > 0)
                {
                    str = str + "and str_staff1='" + searchbystaffname.SelectedValue + "'";
                }
                if (searchbydepartment.SelectedIndex > 0)
                {
                    str = str + "and str_department1='" + searchbydepartment.SelectedValue + "'";
                }
                if (searchbydesignation.SelectedIndex > 0)
                {
                    str = str + "and str_designation1='" + searchbydesignation.SelectedValue + "'";
                }
                if (searchbyage.SelectedIndex > 0)
                {
                    str = str + "and intage='" + searchbyage.SelectedValue + "'";
                }
                if (searchbyfatheroccupation.SelectedIndex > 0)
                {
                    str = str + " and str_fatherorguardianoccupation='" + searchbyfatheroccupation.SelectedValue + "'";
                }
                if (searchbyfatherqualification.SelectedIndex > 0)
                {
                    str = str + "and str_fatherorguardianqualification='" + searchbyfatherqualification.SelectedValue + "'";
                }

            }
            if (ddllist.SelectedValue == "Waitlisted")
            {
                str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Approved' as status from tblstudentadmission where intapprove=3 and intwaitlist=1 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
                str = str + " union all select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Rejected' as status from tblstudentadmission where intapprove=3 and intwaitlist=2 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
                str = str + " union all select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport,intage,str_fatherorguardianqualification,str_fatherorguardianoccupation,'Status' as status from tblstudentadmission where intapprove=3 and intwaitlist=0 and intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();

                if (ddlstandard.SelectedIndex > 1)
                {
                    str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                }
                if (ddlstudent.SelectedIndex > 0)
                {
                    str = str + "and str_student ='" + ddlstudent.SelectedValue + "'";
                }
                if (searchbymotherqualification.SelectedIndex > 0)
                {
                    str = str + "and str_motherqualification='" + searchbymotherqualification.SelectedValue + "'";
                }
                if (searchbymotheroccupation.SelectedIndex > 0)
                {
                    str = str + "and str_motheroccupation='" + searchbymotheroccupation.SelectedValue + "'";
                }
                if (searchbyhostel.SelectedIndex > 0)
                {
                    str = str + "and str_hostel='" + searchbyhostel.SelectedValue + "'";
                }
                if (searchbytransport.SelectedIndex > 0)
                {
                    str = str + "and str_transport='" + searchbytransport.SelectedValue + "'";
                }
                if (searchbystaffname.SelectedIndex > 0)
                {
                    str = str + "and str_staff1='" + searchbystaffname.SelectedValue + "'";
                }
                if (searchbydepartment.SelectedIndex > 0)
                {
                    str = str + "and str_department1='" + searchbydepartment.SelectedValue + "'";
                }
                if (searchbydesignation.SelectedIndex > 0)
                {
                    str = str + "and str_designation1='" + searchbydesignation.SelectedValue + "'";
                }
                if (searchbyage.SelectedIndex > 0)
                {
                    str = str + "and intage='" + searchbyage.SelectedValue + "'";
                }
                if (searchbyfatheroccupation.SelectedIndex > 0)
                {
                    str = str + " and str_fatherorguardianoccupation='" + searchbyfatheroccupation.SelectedValue + "'";
                }
                if (searchbyfatherqualification.SelectedIndex > 0)
                {
                    str = str + "and str_fatherorguardianqualification='" + searchbyfatherqualification.SelectedValue + "'";
                }
            }
        }
        ds = da.ExceuteSql(str);
        dgadmission.DataSource = ds;
        dgadmission.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            tr1.Visible = false;
            trgrid.Visible = true;
            tredit.Visible = true;
        }
        else
        {
            tr1.Visible = true;
            trgrid.Visible = false;
            tredit.Visible = false;
            errormessage.Text = "There is no Admission Form";
        }

    }
    protected void dgadmission_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("view_approvalrequest.aspx?lid=" + e.Item.Cells[0].Text);
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //we select particular stundent for standard that student parents are working in this school staff,designation and departments are visible otherwise its invisible.
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_staff1,str_department1,str_designation1 from tblstudentadmission where intyear='" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and intid=" + ddlstudent.SelectedValue + " group by str_staff1,str_department1,str_designation1";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows[0]["str_staff1"] != "")
        {
            trstaff.Visible = true;
            trdesignation.Visible = true;
            trdepartment.Visible = true;
        }
        else
        {
            trstaff.Visible = false;
            trdesignation.Visible = false;
            trdepartment.Visible = false;
        }
        motheroccupation();
        motherqualification();
        hostel();
        transport();
        staff();
        department();
        designation();
        age();
        fatheroccupation();
        fatherqualification();
        fillgrid();
    }
    protected void searchbymotherqualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbymotheroccupation_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbyhostel_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbytransport_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbystaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbydepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbydesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbygroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void dgadmission_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            //In grid there is no staff,department,designation and groups(that means in grid) we hide in this process.
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblstaff = (Label)e.Item.FindControl("lblstaffname");
            if (dr["str_staff1"].ToString() == "")
                lblstaff.Visible = false;
            Label lbldept = (Label)e.Item.FindControl("lbldepartment");
            if (dr["str_department1"].ToString() == "")
                lbldept.Visible = false;
            Label lbldesig = (Label)e.Item.FindControl("lbldesignation");
            if (dr["str_designation1"].ToString() == "")
                lbldesig.Visible = false;

            // once we give approve or reject or waitlisted its shown in grid approved,rejected and waitlisted.
            Label lblstatus = (Label)e.Item.FindControl("status");
            lblstatus.Text = dr["status"].ToString();
            if (dr["status"].ToString() == "Approved")
                dgadmission.Columns[3].Visible = false;
            if (dr["status"].ToString() == "Rejected")
                dgadmission.Columns[3].Visible = false;
            if (dr["status"].ToString() == "Waitlisted")
                dgadmission.Columns[3].Visible = false;

            DropDownList dls = (DropDownList)e.Item.FindControl("shortlist");
            dls.Items.Clear();
            if (ddllist.SelectedValue == "Waitlisted")
            {
                dls.Items.Insert(0, "Select");
                dls.Items.Insert(1, "Approve");
                dls.Items.Insert(2, "Reject");
            }
            else
            {
                dls.Items.Insert(0, "Select");
                dls.Items.Insert(1, "Approve");
                dls.Items.Insert(2, "Reject");
                dls.Items.Insert(3, "Waitlist");
            }
        }
        catch { }
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        // we select below XI standard groups is invisible in refined search

        student();
        fillgrid();
        tredit.Visible = false;
        dgadmission.Visible = true;
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();

        tredit.Visible = false;
        fillgrid();
        //dgadmission.Visible = false;
    }

    protected void searchbyage_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbyincome_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbyfatherqualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void searchbyfatheroccupation_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        dgadmission.Columns[2].Visible = true;
        dgadmission.Columns[3].Visible = true;
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dgadmission.Items.Count; i++)
        {
            DataGridItem dgi = dgadmission.Items[i];
            DropDownList ddlshortlist = (DropDownList)dgi.FindControl("shortlist");
            if (ddlshortlist.SelectedValue == "Approve")
            {
                //once we select approve in general or waitlist page then we select update button approve becomes to approved in status then that dropdown hide in this function.
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                if (ddllist.SelectedValue == "General")
                {
                    string str = "update tblstudentadmission set intapprove=1,intapprovedby=" + Session["UserID"].ToString() + " where intid=" + dgi.Cells[0].Text;
                    ds = da.ExceuteSql(str);

                }
                else
                {
                    string str = "update tblstudentadmission set intwaitlist=1,intwaitlistapprovedby=" + Session["UserID"].ToString() + " where intid=" + dgi.Cells[0].Text;
                    ds = da.ExceuteSql(str);

                }
            }
            //once we select reject in general or waitlist page then we select update button approve becomes to rejected in status then that dropdown hide in this function.

            if (ddlshortlist.SelectedValue == "Reject")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                if (ddllist.SelectedValue == "General")
                {
                    string str = "update tblstudentadmission set intapprove=2,intapprovedby=" + Session["UserID"].ToString() + " where intid=" + dgi.Cells[0].Text;
                    ds = da.ExceuteSql(str);
                }
                else
                {
                    string str = "update tblstudentadmission set intwaitlist=2,intwaitlistapprovedby=" + Session["UserID"].ToString() + " where intid=" + dgi.Cells[0].Text;
                    ds = da.ExceuteSql(str);
                }
            }
            //once we select waitlist in only general page then we select update button approve becomes to waitlisted in status then that dropdown hide in this function.

            if (ddlshortlist.SelectedValue == "Waitlist")
            {
                if (ddllist.SelectedValue == "General")
                {
                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    string str = "update tblstudentadmission set intapprove=3,intapprovedby=" + Session["UserID"].ToString() + " where intid=" + dgi.Cells[0].Text + " and intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    str = "select * from tblstudentadmission where intapprove=3 and intid=" + dgi.Cells[0].Text + " and intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                        Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["str_mobile"].ToString() + "&message= Your Application is Waiting List  &priority=1");
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Message is send Successfully!')", true);

                }
            }
        }

        fillgrid();
        dgadmission.Columns[3].Visible = false;
        dgadmission.Columns[2].Visible = true;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        dgadmission.Columns[2].Visible = true;
        dgadmission.Columns[3].Visible = false;
        fillgrid();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }

}

