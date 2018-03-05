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

public partial class detailsrecord_edit_employee_details : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //trcommunication.Visible = false;
            trmsg.Visible = false;
            trtag.Visible = false;
            trgrid.Visible = false;
            fillstaff();
            ddldepart.Items.Insert(0, "Select");
            ddldesignation.Items.Insert(0, "Select");
            ddlstaffname.Items.Insert(0, "Select");
            if (Request["rd"] != null)
            {
                if (Session["SearchSatffStaffType"] != null)
                {
                    ddlstaff.SelectedValue = Session["SearchSatffStaffType"].ToString();
                    fillaccordigntostafftype();
                }
                if (Session["SearchSatffDepartment"] != null)
                {
                    ddldepart.SelectedValue = Session["SearchSatffDepartment"].ToString();
                    fillaccordingtodepartment();
                }
                if (Session["SearchSatffDesignation"] != null)
                {
                    ddldesignation.SelectedValue = Session["SearchSatffDesignation"].ToString();
                    fillaccordingtodesignation();
                }
                if (Session["SearchSatffName"] != null)
                {
                    ddlstaffname.SelectedValue = Session["SearchSatffName"].ToString();
                    fillaccordingtostaffname();
                }
            }
        }
    }

    //protected void dgemployee_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete tblemployee where intid=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //        fillgrid();
    //    }
    //    catch { }
    //}

    protected void dgemployee_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("addeditstaff.aspx?empid=" + e.Item.Cells[0].Text + "&rd=2");
    }

    protected void dgemployee_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("employeeeducationandexperience.aspx?empid=" + e.Item.Cells[0].Text);
    }

    protected void fillstaff()
    {
        strsql = " select strstafftype from tblstafftype";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaff.DataSource = ds;
        ddlstaff.DataTextField = "strstafftype";
        ddlstaff.DataValueField = "strstafftype";
        ddlstaff.DataBind();
        ddlstaff.Items.Insert(0, "Select");
        ddlstaff.Items.Insert(1, "All");
    }

    protected void filldept()
    {
        if (ddlstaff.SelectedValue != "All")
            strsql = "select b.strdepartmentname,b.intid from tblemployee a, tbldepartment b where b.intid=a.intdepartment and a.intschool= " + Session["SchoolID"].ToString() + " and a.strtype= '" + ddlstaff.SelectedValue + "' group by b.strdepartmentname,b.intid";
        else
            strsql = "select b.strdepartmentname,b.intid from tblemployee a, tbldepartment b where b.intid=a.intdepartment and a.intschool= " + Session["SchoolID"].ToString() + " group by b.strdepartmentname,b.intid";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldepart.DataSource = ds;
        ddldepart.DataTextField = "strdepartmentname";
        ddldepart.DataValueField = "intid";
        ddldepart.DataBind();
        ddldepart.Items.Insert(0, "All");
    }

    protected void filldesig()
    {
        strsql = "select b.strdesignation,b.intid from tblemployee a, tbldesignation b where a.intdesignation=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedValue != "All")
            strsql = strsql + " and a.strtype= '" + ddlstaff.SelectedValue + "'";
        if (ddldepart.SelectedIndex > 0)
            strsql = strsql + " and a.intdepartment=" + ddldepart.SelectedValue;
        strsql = strsql + " group by  b.strdesignation,b.intid";

        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "strdesignation";
        ddldesignation.DataValueField = "intid";
        ddldesignation.DataBind();
        ddldesignation.Items.Insert(0, "All");
    }

    protected void fillstaffname()
    {
        strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name from tblemployee a, tbldesignation b where a.intdesignation=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedValue != "All")
            strsql = strsql + " and a.strtype= '" + ddlstaff.SelectedValue + "'";
        if (ddldepart.SelectedIndex > 0)
            strsql = strsql + " and a.intdepartment=" + ddldepart.SelectedValue;
        if (ddldesignation.SelectedIndex > 0)
            strsql = strsql + " and a.intDesignation=" + ddldesignation.SelectedValue;

        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "name";
        ddlstaffname.DataValueField = "name";
        ddlstaffname.DataBind();
        ddlstaffname.Items.Insert(0, "Name");
    }

    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillaccordigntostafftype();
    }

    protected void fillaccordigntostafftype()
    {
        if (ddlstaff.SelectedIndex > 0)
        {
            filldept();
            ddldepart.Enabled = true;
            filldesig();
            ddldesignation.Enabled = true;
            fillstaffname();
            ddlstaffname.Enabled = true;
            fillgrid();
        }
        else
        {
            ddldepart.SelectedIndex = 0;
            ddldepart.Enabled = false;
            if (ddldesignation.Enabled == true)
            {
                ddldesignation.SelectedIndex = 0;
                ddldesignation.Enabled = false;
            }
            if (ddlstaffname.Enabled == true)
            {
                ddlstaffname.SelectedIndex = 0;
                ddlstaffname.Enabled = false;
            }

            trtag.Visible = false;
            trgrid.Visible = false;
            trmsg.Visible = true;
            //trcommunication.Visible = false;
        }
        Session["SearchSatffStaffType"] = ddlstaff.SelectedValue;
    }

    protected void fillgrid()
    {
        string subject = "";
        string standard = "";
        string language = "";

        if (ddlstaff.SelectedValue == "All")
            strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,'' as strhomeclass,b.strdepartmentname,c.strdesignation from tblemployee a left outer join tbldepartment b on a.intdepartment=b.intid left outer join tbldesignation c on a.intdesignation=c.intid left outer join tblhomeclass d on a.intid=d.intemployee where a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedValue == "Teaching Staffs")
            strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,b.strdepartmentname,c.strdesignation,d.strhomeclass from tblemployee a left outer join tbldepartment b on a.intdepartment=b.intid left outer join tbldesignation c on a.intdesignation=c.intid left outer join tblhomeclass d on a.intid=d.intemployee where a.strtype='" + ddlstaff.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedValue == "Admin")
            strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,'' as strhomeclass,b.strdepartmentname,c.strdesignation from tblemployee a left outer join tbldepartment b on a.intdepartment=b.intid left outer join tbldesignation c on a.intdesignation=c.intid left outer join tblhomeclass d on a.intid=d.intemployee where a.strtype='" + ddlstaff.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedValue == "Non Teaching Staff")
            strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,'' as strhomeclass,b.strdepartmentname,c.strdesignation from tblemployee a left outer join tbldepartment b on a.intdepartment=b.intid left outer join tbldesignation c on a.intdesignation=c.intid left outer join tblhomeclass d on a.intid=d.intemployee where a.strtype='" + ddlstaff.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
        if (ddldepart.SelectedIndex > 0)
            strsql = strsql + " and a.intdepartment=" + ddldepart.SelectedValue;

        if (ddldesignation.SelectedIndex > 0)
            strsql = strsql + " and a.intdesignation=" + ddldesignation.SelectedValue + "";

        if (ddlstaffname.SelectedIndex > 0)
            strsql = strsql + " and strfirstname + ' ' + strmiddlename + ' ' + strlastname ='" + ddlstaffname.SelectedValue + "'";

        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);

        if (ddlstaff.SelectedValue == "Teaching Staffs" || ddlstaff.SelectedValue == "All")
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                subject = "";
                standard = "";
                strsql = "select strteachsubject from tblteachingsubjects where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strteachsubject";
                DataSet ds1 = new DataSet();
                da = new DataAccess();
                ds1 = da.ExceuteSql(strsql);
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {

                    if (j == 0)
                        subject = ds1.Tables[0].Rows[j]["strteachsubject"].ToString();
                    else
                        subject = subject + "," + ' ' + ds1.Tables[0].Rows[j]["strteachsubject"].ToString();
                }

                if (subject.IndexOf("Language") > -1)
                {
                    strsql = "select strlanguage from tblteachinglanguages where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strlanguage";
                    ds1 = new DataSet();
                    da = new DataAccess();
                    ds1 = da.ExceuteSql(strsql);
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {

                        if (j == 0)
                            language = ds1.Tables[0].Rows[j]["strlanguage"].ToString();
                        else
                            language = language + "," + ' ' + ds1.Tables[0].Rows[j]["strlanguage"].ToString();
                    }

                    subject = subject.Replace("Language", language);
                }

                if (subject.IndexOf("Extra Activities") > -1)
                {
                    strsql = "select strextraactivities from tblteachingextraactivities where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strextraactivities";
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
                ds.Tables[0].Rows[i]["strteachsubject"] = subject;

                strsql = "select strteachclass from tblteachingclass where intschool= " + Session["SchoolID"].ToString() + " and intemployee= " + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strteachclass";

                DataSet ds2 = new DataSet();
                da = new DataAccess();
                ds2 = da.ExceuteSql(strsql);
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    if (j == 0)
                        standard = ds2.Tables[0].Rows[j]["strteachclass"].ToString();
                    else
                        standard = standard + "," + ' ' + ds2.Tables[0].Rows[j]["strteachclass"].ToString();

                }
                ds.Tables[0].Rows[i]["strteachclass"] = standard;
            }
            if (ddlstaff.SelectedValue == "Teaching Staffs")
            {
                trteachingclasssubject.Visible = true;
            }
            else
            {
                trteachingclasssubject.Visible = false;
            }
        }
        else
        {
            trteachingclasssubject.Visible = false;        
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            lblmsg.Text = "No search criteria found for selected";
            trgrid.Visible = false;
            trmsg.Visible = true;
            //trcommunication.Visible = false;
            trtag.Visible = false;
        }
        else
        {
            dgemployee.DataSource = ds;
            dgemployee.DataBind();
            trgrid.Visible = true;
            trmsg.Visible = false;
            trtag.Visible = true;
            //trcommunication.Visible = true;
            if (ddlstaff.SelectedValue == "Teaching Staffs")
            {
                fillteachsubject();
                fillstandard();
            }
            else
            {
                searchbyteachsubject.Items.Clear();
                searchbystandard.Items.Clear();
                searchbyteachsubject.Items.Insert(0, "--Select--");
                searchbystandard.Items.Insert(0, "--Select--");
            }
            searchbygender.SelectedIndex = 0;
            searchbytransport.SelectedIndex = 0;
            //searchbycommunity.SelectedIndex = 0;
            searchbyreligion.SelectedIndex = 0;
            searchbystandard.SelectedIndex = 0;
            searchbyteachsubject.SelectedIndex = 0;
            searchbybirthday.SelectedIndex = 0;
            searchbyblood.SelectedIndex = 0;
        }
    }

    protected void ddldepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillaccordingtodepartment();
    }

    protected void fillaccordingtodepartment()
    {
        if (ddlstaff.SelectedIndex > 0)
        {
            filldesig();
            ddldesignation.Enabled = true;
            fillstaffname();
            ddlstaffname.Enabled = true;
            fillgrid();
        }
        else
        {
            if (ddldesignation.Enabled == true)
            {
                ddldesignation.SelectedIndex = 0;
                ddldesignation.Enabled = false;
            }
            if (ddlstaffname.Enabled == true)
            {
                ddlstaffname.SelectedIndex = 0;
                ddlstaffname.Enabled = false;
            }

            trtag.Visible = false;
            trgrid.Visible = false;
            trmsg.Visible = true;
            //trcommunication.Visible = false;
        }
        Session["SearchSatffDepartment"] = ddldepart.SelectedValue;
    }

    protected void ddldesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillaccordingtodesignation();
    }

    protected void fillaccordingtodesignation()
    {
        if (ddlstaff.SelectedIndex > 0)
        {
            fillstaffname();
            ddlstaffname.Enabled = true;
            fillgrid();
        }
        else
        {
            if (ddlstaffname.Enabled == true)
            {
                ddlstaffname.SelectedIndex = 0;
                ddlstaffname.Enabled = false;
            }

            trtag.Visible = false;
            trgrid.Visible = false;
            trmsg.Visible = true;
            //trcommunication.Visible = false;
        }
        Session["SearchSatffDesignation"] = ddldesignation.SelectedValue;
    }

    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillaccordingtostaffname();
    }

    protected void fillaccordingtostaffname()
    {
        if (ddlstaff.SelectedIndex > 0)
        {
            fillgrid();
        }
        else
        {
            trtag.Visible = false;
            trgrid.Visible = false;
            trmsg.Visible = true;
            //trcommunication.Visible = false;
        }
        Session["SearchSatffName"] = ddlstaffname.SelectedValue;
    }

    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        strsql = " select strteachclass from tblteachingclass where  intschool='" + Session["SchoolID"].ToString() + "' group by strteachclass";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbystandard.DataSource = ds;
        searchbystandard.DataTextField = "strteachclass";
        searchbystandard.DataValueField = "strteachclass";
        searchbystandard.DataBind();
        searchbystandard.Items.Insert(0, "--Select--");
    }

    protected void fillteachsubject()
    {
        DataAccess da = new DataAccess();
        strsql = " select strteachsubject from tblteachingsubjects where  intschool='" + Session["SchoolID"].ToString() + "' group by strteachsubject";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            searchbyteachsubject.DataSource = ds;
            searchbyteachsubject.DataTextField = "strteachsubject";
            searchbyteachsubject.DataValueField = "strteachsubject";
            searchbyteachsubject.DataBind();
            searchbyteachsubject.Items.Insert(0, "--Select--");
            trtag.Visible = true;
        }
    }
    protected void searchbygender_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        fillgrid1();
    }

    protected void fillgrid1()
    {
        string subject = "";
        string standard = "";
        strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,b.strdepartmentname,c.strdesignation from tblemployee a ,tbldepartment b,tbldesignation c where a.intdepartment=b.intid and a.intdesignation=c.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedValue != "All")
            strsql = strsql + " and a.strtype='" + ddlstaff.SelectedValue + "'";

        if (ddldepart.SelectedIndex > 0)
            strsql = strsql + " and a.intdepartment=" + ddldepart.SelectedValue;

        if (ddldesignation.SelectedIndex > 0)
            strsql = strsql + " and a.intdesignation=" + ddldesignation.SelectedValue + "";

        if (ddlstaffname.SelectedIndex > 0)
            strsql = strsql + " and strfirstname + ' ' + strmiddlename + ' ' + strlastname ='" + ddlstaffname.SelectedValue + "'";

        if (searchbygender.SelectedIndex > 0)
            strsql = strsql + " and strgender ='" + searchbygender.SelectedValue + "'";

        if (searchbytransport.SelectedIndex > 0)
            strsql = strsql + " and a.transport='" + searchbytransport.SelectedValue + "'";

        //if (searchbycommunity.SelectedIndex > 0)
        //    strsql = strsql + " and a.strcommunity='" + searchbycommunity.SelectedValue + "' ";

        if (searchbyreligion.SelectedIndex > 0)
            strsql = strsql + " and a.strreligion= '" + searchbyreligion.SelectedValue + "' ";

        if (searchbystandard.SelectedIndex > 0)
            strsql = strsql + " and a.intid in(select intemployee from tblteachingclass where strteachclass='" + searchbystandard.SelectedValue + "' group by intemployee)";

        if (searchbyteachsubject.SelectedIndex > 0)
            strsql = strsql + " and a.intid in(select intemployee from tblteachingsubjects where strteachsubject='" + searchbyteachsubject.SelectedValue + "' group by intemployee)";

        if (searchbyblood.SelectedIndex > 0)
            strsql = strsql + " and a.strblood='" + searchbyblood.SelectedValue + "' ";

        if (searchbybirthday.SelectedIndex > 0)
        {
            if (searchbybirthday.SelectedValue == "Today")
                strsql = strsql + " and month(getdate())= month(dtdob) and day(getdate())=day(dtdob) ";
            else if (searchbybirthday.SelectedValue == "This Month")
                strsql = strsql + " and month(getdate())= month(dtdob) ";
            else if (searchbybirthday.SelectedValue == "This Week")
                strsql = strsql + " and Month(dtdob)= Month(getdate()) and Day(dtdob) Between (Day(Getdate())) And (Day(dateadd(dd,7,getdate())))";
        }

        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);

        if (ddlstaff.SelectedValue == "Teaching Staffs" || ddlstaff.SelectedValue == "All")
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strsql = "select strteachsubject from tblteachingsubjects where intschool= " + Session["SchoolID"].ToString() + " and intemployee=" + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strteachsubject";
                DataSet ds1 = new DataSet();
                da = new DataAccess();
                ds1 = da.ExceuteSql(strsql);
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {

                    if (j == 0)
                        subject = ds1.Tables[0].Rows[j]["strteachsubject"].ToString();
                    else
                        subject = subject + "," + ' ' + ds1.Tables[0].Rows[j]["strteachsubject"].ToString();
                }

                ds.Tables[0].Rows[i]["strteachsubject"] = subject;

                strsql = "select strteachclass from tblteachingclass where intschool= " + Session["SchoolID"].ToString() + " and intemployee= " + ds.Tables[0].Rows[i]["intid"].ToString() + " group by strteachclass";

                DataSet ds2 = new DataSet();
                da = new DataAccess();
                ds2 = da.ExceuteSql(strsql);
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {

                    if (j == 0)
                        standard = ds2.Tables[0].Rows[j]["strteachclass"].ToString();
                    else
                        standard = standard + "," + ' ' + ds2.Tables[0].Rows[j]["strteachclass"].ToString();


                }
                ds.Tables[0].Rows[i]["strteachclass"] = standard;
            }
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            lblmsg.Text = "No search criteria found for selected";
            trgrid.Visible = false;
            trmsg.Visible = true;
            //trcommunication.Visible = false;
            trtag.Visible = false;
        }
        else
        {
            dgemployee.DataSource = ds;
            dgemployee.DataBind();
            trgrid.Visible = true;
            trmsg.Visible = false;
            trtag.Visible = true;
            //trcommunication.Visible = true;
        }
    }

    protected void searchbytransport_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbygender.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        fillgrid1();
    }

    //protected void searchbycommunity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    searchbygender.SelectedIndex = 0;
    //    searchbytransport.SelectedIndex = 0;
    //    searchbyreligion.SelectedIndex = 0;
    //    searchbystandard.SelectedIndex = 0;
    //    searchbyteachsubject.SelectedIndex = 0;
    //    searchbybirthday.SelectedIndex = 0;
    //    searchbyblood.SelectedIndex = 0;
    //    fillgrid1();
    //}
    protected void searchbyreligion_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        fillgrid1();
    }

    protected void searchbydistrange_SelectedIndexChanged(object sender, EventArgs e)
    {
        strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,b.strdepartmentname,c.strdesignation from tblemployee a ,tbldepartment b,tbldesignation c where a.intdepartment=b.intid and a.intdesignation=c.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlstaff.SelectedIndex > 1)
            strsql = strsql + " and a.strtype='" + ddlstaff.SelectedValue + "'";
        if (ddldepart.SelectedIndex > 1)
            strsql = strsql + " and a.intdepartment=" + ddldepart.SelectedValue;
        if (ddldesignation.SelectedIndex > 1)
            strsql = strsql + " and a.intdesignation=" + ddldesignation.SelectedValue + "";
        if (ddlstaffname.SelectedIndex > 0)
            strsql = strsql + " and strfirstname + ' ' + strmiddlename + ' ' + strlastname ='" + ddlstaffname.SelectedValue + "'";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblmsg.Text = "No search criteria found for selected";
            dgemployee.Visible = false;
            lblmsg.Visible = true;
            //menu00.Visible = false;
            trmsg.Visible = true;
        }
        else
        {
            dgemployee.DataSource = ds;
            dgemployee.DataBind();
            dgemployee.Visible = true;
            lblmsg.Visible = false;
            //menu00.Visible = true;
            trmsg.Visible = false;
        }
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
    }
    protected void searchbystandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        fillgrid1();
    }

    protected void searchbyteachsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        fillgrid1();
    }
    protected void searchbybirthday_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        fillgrid1();
    }
    protected void searchbyblood_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        //searchbycommunity.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbystandard.SelectedIndex = 0;
        searchbyteachsubject.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        fillgrid1();
    }
    //protected void searchbystaffid_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    strsql = "select a.strfirstname + ' ' + a.strmiddlename + ' ' + a.strlastname as name,convert(varchar(10),dtdob,103) as dtdob, a.*,'' as strteachsubject, '' as strteachclass,b.strdepartmentname,c.strdesignation from tblemployee a ,tbldepartment b,tbldesignation c where a.intdepartment=b.intid and a.intdesignation=c.intid and a.intschool=" + Session["SchoolID"].ToString();
    //    if (ddlstaff.SelectedIndex > 1)
    //        strsql = strsql + " and a.strtype='" + ddlstaff.SelectedValue + "'";
    //    if (ddldepart.SelectedIndex > 1)
    //        strsql = strsql + " and a.intdepartment=" + ddldepart.SelectedValue;
    //    if (ddldesignation.SelectedIndex > 1)
    //        strsql = strsql + " and a.intdesignation=" + ddldesignation.SelectedValue + "";
    //    if (ddlstaffname.SelectedIndex > 0)
    //        strsql = strsql + " and strfirstname + ' ' + strmiddlename + ' ' + strlastname ='" + ddlstaffname.SelectedValue + "'";
    //    da = new DataAccess();
    //    ds = new DataSet();
    //    ds = da.ExceuteSql(strsql);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        lblmsg.Text = "No search criteria found for selected";
    //        dgemployee.Visible = false;
    //        lblmsg.Visible = true;
    //        menu00.Visible = false;
    //    }
    //    else
    //    {
    //        dgemployee.DataSource = ds;
    //        dgemployee.DataBind();
    //        dgemployee.Visible = true;
    //        lblmsg.Visible = false;
    //        menu00.Visible = true;

    //    }
    //}

    protected void btnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        ImageButton btnview = new ImageButton();
        btnview = (ImageButton)item.FindControl("btnview");
        DataGridItem dgi = dgemployee.Items[index];
        Response.Redirect("view_employeedetails.aspx?empid=" + dgi.Cells[0].Text + "&backto=0");
    }

    //protected void btnsendmsg_Click(object sender, EventArgs e)
    //{
    //    int j = 0;
    //    for (int i = 0; i < dgemployee.Items.Count; i++)
    //    {
    //        DataGridItem dgi = dgemployee.Items[i];
    //        CheckBox chkselect = (CheckBox)dgi.FindControl("chkselect");
    //        if (chkselect.Checked)
    //        {
    //            j++;
    //            da = new DataAccess();
    //            string str = "select mobilesms from tblemployee where intid=" + dgi.Cells[0].Text;
    //            ds = new DataSet();
    //            ds = da.ExceuteSql(str);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                string strUrl = "http://sms1.mmsworld.in/pushsms.php";
    //                Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["mobilesms"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
    //                //api_password=9d04ex0qz0zb3qcca
    //            }
    //        }
    //    }

    //    if (j != 0)
    //    {
    //        txtmessage.Text = "";
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Message is send Successfully')", true);
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select atleast one record')", true);
    //    }
    //}

    //protected void btnsendmail_Click(object sender, EventArgs e)
    //{
    //    string dtdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    //    string str = "";

    //    for (int i = 0; i < dgemployee.Items.Count; i++)
    //    {
    //        int j = i + 1;
    //        DataGridItem dgimail = dgemployee.Items[i];
    //        CheckBox chkselect = (CheckBox)dgimail.FindControl("chkselect");
    //        if (chkselect.Checked)
    //        {
    //            if (str.Length == 0)
    //            {
    //                str = dgimail.Cells[0].Text;
    //            }
    //            else
    //            {
    //                str = str + "," + dgimail.Cells[0].Text;
    //            }
    //        }
    //    }

    //    if (str.Length == 0)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select at least one record')", true);
    //    }
    //    else
    //    {
    //        SqlCommand command;
    //        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    //        conn.Open();
    //        command = new SqlCommand("SPmailbox", conn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        if (btnsendmail.Text == "Send Mail")
    //        {
    //            command.Parameters.Add("@intid", "0");
    //        }
    //        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
    //        command.Parameters.Add("@intsenderid", Session["UserID"].ToString());
    //        command.Parameters.Add("@strreceiverids", str);
    //        command.Parameters.Add("@strsubject", txtsubject.Text.Trim());
    //        command.Parameters.Add("@strmessage", txtmail.Content.Trim());
    //        command.Parameters.Add("@intviewed", "0");
    //        command.Parameters.Add("@strpatrontype", "Employee");
    //        command.Parameters.Add("@strsenderpatrontype", Session["PatronType"].ToString());
    //        command.Parameters.Add("@dtdate", dtdate);
    //        command.ExecuteNonQuery();
    //        conn.Close();

    //        da = new DataAccess();
    //        strsql = "select stremail from tblemployee where intid in(" + str + ")";
    //        ds = new DataSet();
    //        ds = da.ExceuteSql(strsql);
    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            Functions.Sendmail(ds.Tables[0].Rows[j]["stremail"].ToString(), "support@theschools.in", txtsubject.Text, txtmail.Content);
    //        }

    //        txtsubject.Text = "";
    //        txtmail.Content = "";
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Mail sent Successfully')", true);
    //    }
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblemployee where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblemployee", item.Cells[0].Text , "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),126);

            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch { }
    }
}
