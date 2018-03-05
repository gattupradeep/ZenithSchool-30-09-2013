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

public partial class detailsrecord_addeditstaff : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    public int intsub, intlan,intextra,intactivities;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstaff();
            fillddlcountry();
            fillddldepart();
            fillddldesig();
            fillteachsubject();
            fillteachclass();
            filllanguages();
            fillextraactivities();
            fillhomeclass();
            //ddlcommunity.Items.Insert(0, "--Select--");
            ddltittle.Items.Insert(0, "--Select--");
            ddlgen.Items.Insert(0, "--Select--");
            //ddlreli.Items.Insert(0, "--Select--");
            ddladdproof.Items.Insert(0, "--Select--");
            ddlbloodgp.Items.Insert(0, "--Select--");
            //ddlmode.Items.Insert(0, "--Select--");
            ddlcountry.SelectedIndex = 0;
            ddlcity.Items.Insert(0, "--Select--");
            ddlstate.Items.Insert(0, "--Select--");
            ddldesignation.Items.Insert(0, "--Select--");
            ddldepart.Items.Insert(0, "--Select--");
            txtreligion.Visible = false;
            //trcommunity.Visible = false;
            disablecontrols();
            if (Request["empid"] != null)
            {
                lblempid.Text = Request["empid"].ToString();
                fillstaffdetails();
                btnSave.Text = "Update";
                btnClear3.Visible = true;
            }
        }
    }

    protected void fillstaff()
    {
        strsql = " select strstafftype from tblstafftype";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddltype.DataSource = ds;
        ddltype.DataTextField = "strstafftype";
        ddltype.DataValueField = "strstafftype";
        ddltype.DataBind();
        ListItem li = new ListItem("--Select--", "0");
        ddltype.Items.Insert(0, li);
    }

    protected void disablecontrols()
    {
        ddlmode.Enabled = false;
        txtdegree.Enabled = false;
        txtmajor.Enabled = false;
        txtinstitutename.Enabled = false;
        txtpassedout.Enabled = false;
        txtpercent.Enabled = false;
        txtorgname.Enabled = false;
        txtperiodfrom.Enabled = false;
        txtperiodto.Enabled = false;
        txtorgdept.Enabled = false;
        txtorgdesig.Enabled = false;
        btnsave2.Enabled = false;
        btnclear2.Enabled = false;
        btnsubmit.Enabled = false;
        btnerase.Enabled = false;
        btndone.Enabled = false;
    }

    protected void enablecontrols()
    {
        ddlmode.Enabled = true;
        txtdegree.Enabled = true;
        txtmajor.Enabled = true;
        txtinstitutename.Enabled = true;
        txtpassedout.Enabled = true;
        txtpercent.Enabled = true;
        txtorgname.Enabled = true;
        txtperiodfrom.Enabled = true;
        txtperiodto.Enabled = true;
        txtorgdept.Enabled = true;
        txtorgdesig.Enabled = true;
        btnsave2.Enabled = true;
        btnclear2.Enabled = true;
        btnsubmit.Enabled = true;
        btnerase.Enabled = true;
        btndone.Enabled = true;
    }

    private void fillddlcountry()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblcountry ORDER BY strcountryname ASC";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcountry.DataSource = ds;
        ddlcountry.DataTextField = "strcountryname";
        ddlcountry.DataValueField = "intcountryID";
        ddlcountry.DataBind();
        ListItem li = new ListItem("--Select--", "0");
        ddlcountry.Items.Insert(0, li);
    }

    private void fillddlstate()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblstate where intcountryid= " + ddlcountry.SelectedValue + " order by strstate";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "strstate";
        ddlstate.DataValueField = "intstateID";
        ddlstate.DataBind();
        ListItem li = new ListItem("--Select--", "0");
        ddlstate.Items.Insert(0, li);
    }

    private void fillddlcity()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblcity where intstateid=" + ddlstate.SelectedValue + " order by strcity";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcity.DataSource = ds;
        ddlcity.DataTextField = "strcity";
        ddlcity.DataValueField = "intcityID";
        ddlcity.DataBind();
        ListItem li = new ListItem("--Select--", "0");
        ddlcity.Items.Insert(0, li);
    }

    private void fillddldepart()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tbldepartment where intschool=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldepart.DataSource = ds;
        ddldepart.DataTextField = "strdepartmentname";
        ddldepart.DataValueField = "intid";
        ddldepart.DataBind();
    }

    private void fillddldesig()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tbldesignation where intschool=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddldesignation.DataSource = ds;
        ddldesignation.DataTextField = "strdesignation";
        ddldesignation.DataValueField = "intid";
        ddldesignation.DataBind();
    }

    protected string getage()
    {
        string strsql = "select year(getdate())-year('" + txtdob.Text + "') as age,month('" + txtdob.Text + "') as dobmonth,month(getdate()) as gmonth,day('" + txtdob.Text + "') as dobday,day(getdate()) as gday";

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
        if (gm > dm)
        {
            return z;
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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void fillhomeclass()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strstandard+' - '+strsection as teachclass from dbo.tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li = new ListItem("---Select---", "0");

        ddlhomeclass.DataTextField = "teachclass";
        ddlhomeclass.DataValueField = "teachclass";
        ddlhomeclass.DataSource = ds;
        ddlhomeclass.DataBind();
        ddlhomeclass.Items.Insert(0, li);
    }

    protected void fillteachsubject()
    {
        DataAccess da = new DataAccess();
        string sql = "select intschoolsubjectid,strsubject from tblschoolsubject where strsubject not like '%Language' and intschoolid=" + Session["SchoolID"].ToString() + " union all select 0 as intschoolsubjectid ,'Language' as strsubject union all select 0 as intschoolsubjectid ,'Extra Activities' as strsubject";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        chkteachsubject.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strsubject"].ToString(), ds.Tables[0].Rows[i]["intschoolsubjectID"].ToString());
            chkteachsubject.Items.Add(li);
        }
    }

    protected void filllanguages()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        chklanguages.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strlanguagename"].ToString(), ds.Tables[0].Rows[i]["intschoollanguagesID"].ToString());
            chklanguages.Items.Add(li);
        }
    }

    protected void fillextraactivities()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblschoolextracurricular where intschoolid=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        chkextraactivities.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strextracurricular"].ToString(), ds.Tables[0].Rows[i]["intschoolcurricularID"].ToString());
            chkextraactivities.Items.Add(li);
        }
    }

    protected void fillteachclass()
    {
        DataAccess da = new DataAccess();
        string sql = " select strstandard+' - '+strsection as teachclass from dbo.tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        chkteachclass.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["teachclass"].ToString(), ds.Tables[0].Rows[i]["teachclass"].ToString());
            chkteachclass.Items.Add(li);
        }
    }

    protected void selectedteachclass()
    {
        DataAccess da = new DataAccess();
        string sql = " select strstandard+' - '+strsection as teachclass from dbo.tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows[0]["teachclass"].ToString() != lblempid.Text)
        {
            for (int i = 0; i < chkteachclass.Items.Count; i++)
            {
                if (chkteachclass.Items[i].Selected == true)
                {
                    string qry = "";
                    
                    DataSet ds2 = new DataSet();
                    qry = "insert into tblteachingclass(strteachclass,intschool,intemployee)values('" + chkteachclass.Items[i].Text + "'," + Session["SchoolID"].ToString() + "," + lblempid.Text + ")";
                    da.ExceuteSqlQuery(qry);
                    qry = "select max(intid) as intid from tblteachingclass";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblteachingclass", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);
                }
            }
        }
    }

    protected void selectedteachsubject()
    {
        string qry = "";
        DataAccess da = new DataAccess();
        qry = "delete tblteachingsubjects where intschool=" + Session["SchoolID"].ToString() + " and intemployee=" + lblempid.Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblteachinglanguages", lblempid.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);

        da.ExceuteSqlQuery(qry);
        for (int i = 0; i < chkteachsubject.Items.Count; i++)
        {
            if (chkteachsubject.Items[i].Selected == true)
            {
                da = new DataAccess();
                DataSet ds2 = new DataSet();
                qry = "insert into tblteachingsubjects(strteachsubject,intschool,intemployee)values('" + chkteachsubject.Items[i].Text + "'," + Session["SchoolID"].ToString() + "," + lblempid.Text + ")";
                da.ExceuteSqlQuery(qry);

                qry = "select max(intid) as intid from tblteachingsubjects";
                ds2 = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tblteachingsubjects", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);

            }
        }
        if (intsub == 1)
            selectedlanguages();
        if (intextra == 1)
            selectedextraactivities();
    }

    protected void selectedlanguages()
    {
        string qry = "";
        DataAccess da = new DataAccess();
        qry = "delete tblteachinglanguages where intschool=" + Session["SchoolID"].ToString() + " and intemployee=" + lblempid.Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblteachinglanguages", lblempid.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);

        da.ExceuteSqlQuery(qry);
        for (int i = 0; i < chklanguages.Items.Count; i++)
        {
            if (chklanguages.Items[i].Selected == true)
            {
                da = new DataAccess();
                DataSet ds2 = new DataSet();
                qry = "insert into tblteachinglanguages(strlanguage,intschool,intemployee)values('" + chklanguages.Items[i].Text + "'," + Session["SchoolID"].ToString() + "," + lblempid.Text + ")";
                da.ExceuteSqlQuery(qry);

                qry = "select max(intid) as intid from tblteachinglanguages";
                ds2 = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tblteachinglanguages", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);
            }
        }
    }

    protected void selectedextraactivities()
    {
        string qry = "";
        DataAccess da = new DataAccess();
        qry = "delete tblteachingextraactivities where intschool=" + Session["SchoolID"].ToString() + " and intemployee=" + lblempid.Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblteachingextraactivities", lblempid.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);

        da.ExceuteSqlQuery(qry);
        for (int i = 0; i < chkextraactivities.Items.Count; i++)
        {
            if (chkextraactivities.Items[i].Selected == true)
            {
                da = new DataAccess();
                DataSet ds2 = new DataSet();
                qry = "insert into tblteachingextraactivities(strextraactivities,intschool,intemployee)values('" + chkextraactivities.Items[i].Text + "'," + Session["SchoolID"].ToString() + "," + lblempid.Text + ")";
                da.ExceuteSqlQuery(qry);

                da = new DataAccess();
                qry = "select max(intid) as intid from tblteachingextraactivities";
                ds = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tblteachingextraactivities", ds.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);
            }
        }
    }

    protected void Clear()
    {
        txtfirst.Text = "";
        txtmiddle.Text = "";
        txtlast.Text = "";
        txtguardianname.Text = "";
        txtsal.Text = "0";
        txtnation.Text = "";
        txtaddr.Text = "";
        txtzip.Text = "";
        txtEmail.Text = "";
        txtph.Text = "";
        txtmobile.Text = "";
        txtproofno.Text = "";
        txtyesdetail.Text = "";
        txtother.Text = "";
        txtotherremark.Text = "";
        txtprohibitto.Text = "";
        txtworkftime.Text = "";
        txtworktotime.Text = "";
        txtallergies.Text = "";
        txtidentificationmark.Text = "";
        txtjoiningdate.Text = "";
        txtmobilesms.Text = "";
        txtotherremark.Text = "";
        btnSave.Text = "Save";
        txtoriginalreceive.Text = "";
        ddlhomeclass.SelectedIndex = 0;
        ddlreli.SelectedIndex = 0;
        ddlcountry.SelectedIndex = 0;
        ddlstate.SelectedIndex = 0;
        ddlcity.SelectedIndex = 0;
        ddltype.SelectedIndex = 0;
        ddldepart.SelectedIndex = 0;
        ddlgen.SelectedIndex = 0;
        ddltittle.SelectedIndex = 0;
        ddldesignation.SelectedIndex = 0;
    }

    protected void fillsubject_class()
    {
        string sql = " select * from tblteachingsubjects where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee =" + Request["empid"].ToString();

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < chkteachsubject.Items.Count; i++)
                {
                    if (chkteachsubject.Items[i].Text == ds.Tables[0].Rows[j]["strteachsubject"].ToString())
                        chkteachsubject.Items[i].Selected = true;
                }
            }
        }
    }

    protected void fillteaching_languages()
    {
        string sql = " select * from tblteachinglanguages where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee =" + Request["empid"].ToString();

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < chklanguages.Items.Count; i++)
                {
                    if (chklanguages.Items[i].Text == ds.Tables[0].Rows[j]["strlanguage"].ToString())
                        chklanguages.Items[i].Selected = true;
                }
            }
        }
    }

    protected void fillteaching_extraactivities()
    {
        string sql = " select * from tblteachingextraactivities where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee =" + Request["empid"].ToString();

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < chkextraactivities.Items.Count; i++)
                {
                    if (chkextraactivities.Items[i].Text == ds.Tables[0].Rows[j]["strextraactivities"].ToString())
                        chkextraactivities.Items[i].Selected = true;
                }
            }
        }
    }

    protected void fillhome_class()
    {
        string sql = "select strhomeclass from tblhomeclass where intschool=" + Session["SchoolID"].ToString() + " and intemployee=" + Request["empid"].ToString();

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlhomeclass.SelectedValue = ds.Tables[0].Rows[0]["strhomeclass"].ToString();
        }
    }

    protected void fill_class()
    {
        string sql = " select * from tblteachingclass where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee =" + Request["empid"].ToString();

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < chkteachclass.Items.Count; i++)
                {
                    if (chkteachclass.Items[i].Text == ds.Tables[0].Rows[j]["strteachclass"].ToString())
                        chkteachclass.Items[i].Selected = true;
                }
            }
        }
    }

    protected void fillstaffdetails()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select convert(varchar(10),dtdob,111) as dtdob,convert(varchar(10),dtdateofjoining,111) as dtdateofjoining,convert(varchar(10),dtprohibitfrom,111) as dtprohibitfrom,convert(varchar(10),dtprohibitto,111) as dtprohibitto,convert(varchar(5),dtworkftime,114) as dtworkftime, convert(varchar(5),dtworktotime,114) as dtworktotime,* from tblemployee where intID =" + Request["empid"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltittle.SelectedValue = ds.Tables[0].Rows[0]["strtittle"].ToString();
            txtfirst.Text = ds.Tables[0].Rows[0]["strfirstname"].ToString();
            txtmiddle.Text = ds.Tables[0].Rows[0]["strmiddlename"].ToString();
            txtlast.Text = ds.Tables[0].Rows[0]["strlastname"].ToString();
            txtguardianname.Text = ds.Tables[0].Rows[0]["strguardianname"].ToString();
            txtdob.Text = ds.Tables[0].Rows[0]["dtdob"].ToString();
            txtexpmonth.Text = ds.Tables[0].Rows[0]["intexpmonth"].ToString();
            txtexpyear.Text = ds.Tables[0].Rows[0]["intexpyear"].ToString();
            ddltype.SelectedValue = ds.Tables[0].Rows[0]["strtype"].ToString();
            if (ds.Tables[0].Rows[0]["strguardian"].ToString() == "Father")
            {
                rbtfather.Checked = true;
            }
            else
            {
                rbthusband.Checked = true;
            }
            ddlgen.SelectedValue = ds.Tables[0].Rows[0]["strGender"].ToString();
            txtsal.Text = ds.Tables[0].Rows[0]["intsalary"].ToString();
            txtnation.Text = ds.Tables[0].Rows[0]["strnationality"].ToString();
            if (ds.Tables[0].Rows[0]["strreligion"].ToString() == "Hindu" || ds.Tables[0].Rows[0]["strreligion"].ToString() == "Islam" || ds.Tables[0].Rows[0]["strreligion"].ToString() == "Christian")
            {
                ddlreli.SelectedValue = ds.Tables[0].Rows[0]["strreligion"].ToString();
                ddlreli.Visible = true;
                txtreligion.Visible = false;
            }
            else
            {
                txtreligion.Text = ds.Tables[0].Rows[0]["strreligion"].ToString();
                //ddlreli.Visible = false;
                ddlreli.SelectedValue = "Others";
                txtreligion.Visible = true;
            }
            txtaddr.Text = ds.Tables[0].Rows[0]["strAddress"].ToString();
            fillddlcountry();
            ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["intcountry"].ToString();
            fillddlstate();
            int s = int.Parse(ds.Tables[0].Rows[0]["intstate"].ToString());
            ddlstate.SelectedValue = s.ToString();
            fillddlcity();
            ddlcity.SelectedValue = ds.Tables[0].Rows[0]["intcity"].ToString();
            txtzip.Text = ds.Tables[0].Rows[0]["strZipCode"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["strEMail"].ToString();
            txtph.Text = ds.Tables[0].Rows[0]["strPhone"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["strmobile"].ToString();
            ddldepart.SelectedValue = ds.Tables[0].Rows[0]["intDepartment"].ToString();
            ddldesignation.SelectedValue = ds.Tables[0].Rows[0]["intDesignation"].ToString();
            ddladdproof.SelectedValue = ds.Tables[0].Rows[0]["straddproof"].ToString();
            if (ds.Tables[0].Rows[0]["strchildstudy"].ToString() == "Yes")
            {
                rbtyes.Checked = true;
                rbtno.Checked = false;
                trchild.Visible = true;
            }
            else
            {
                rbtyes.Checked = false;
                rbtno.Checked = true;
                trchild.Visible = false;
            }
            txtyesdetail.Text = ds.Tables[0].Rows[0]["strchilddetail"].ToString();
            txtjoiningdate.Text = ds.Tables[0].Rows[0]["dtdateofjoining"].ToString();
            txtprohibitto.Text = ds.Tables[0].Rows[0]["dtprohibitto"].ToString();
            txtworkftime.Text = ds.Tables[0].Rows[0]["dtworkftime"].ToString();
            txtworktotime.Text = ds.Tables[0].Rows[0]["dtworktotime"].ToString();
            txtproofno.Text = ds.Tables[0].Rows[0]["strproofno"].ToString();
            txtmobilesms.Text = ds.Tables[0].Rows[0]["mobilesms"].ToString();
            txtallergies.Text = ds.Tables[0].Rows[0]["strallergy"].ToString();
            txtidentificationmark.Text = ds.Tables[0].Rows[0]["identitymark"].ToString();
            txtoriginalreceive.Text = ds.Tables[0].Rows[0]["docreceive"].ToString();
            txtotherremark.Text = ds.Tables[0].Rows[0]["strremarks"].ToString();
            txtother.Text = ds.Tables[0].Rows[0]["strproofother"].ToString();
            //txtheight.Text = ds.Tables[0].Rows[0]["strheight"].ToString();
            //ddlcommunity.SelectedValue = ds.Tables[0].Rows[0]["strcommunity"].ToString();
            ddlbloodgp.SelectedValue = ds.Tables[0].Rows[0]["strblood"].ToString();

            if (ds.Tables[0].Rows[0]["transport"].ToString() == "Own")
            {
                rbtown.Checked = true;
            }
            else
            {
                rbtschool.Checked = true;
            }

            if (ds.Tables[0].Rows[0]["inthosteler"].ToString() == "1")
            {
                rbthostelyes.Checked = true;
                rbthostelno.Checked = false;
            }
            else
            {
                rbthostelyes.Checked = false;
                rbthostelno.Checked = true;
            }

            if (ds.Tables[0].Rows[0]["intexperienced"].ToString() == "1")
            {
                txtexpyear.Enabled = true;
                txtexpmonth.Enabled = true;
                trexperienced.Visible = true;
                rbtexpyes.Checked = true;
                rbtexpno.Checked = false;
            }
            else
            {
                txtexpyear.Enabled = false;
                txtexpmonth.Enabled = false;
                trexperienced.Visible = false;
                rbtexpno.Checked = true;
                rbtexpyes.Checked = false;
            }

            if (ddltype.SelectedValue != "Teaching Staffs")
            {
                trteaching.Visible = false;
                ddlhomeclass.Enabled = false;
            }
            else
            {
                trteaching.Visible = true;
                ddlhomeclass.Enabled = true;
                fill_class();
                fillhome_class();
                fillsubject_class();
                fillteaching_languages();
                fillteaching_extraactivities();
            }

            btnSave.Text = "Update";
            Session["empid"] = Request["empid"].ToString();
            filleducationgrid();
            fillexperiencegrid();
            enablecontrols();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
     {
        try
        {
            if (ddltype.SelectedIndex > 0)
            {
                if (ddldepart.SelectedIndex > 0)
                {
                    if (ddldesignation.SelectedIndex > 0)
                    {
                        if (ddltype.SelectedValue == "Teaching Staffs")
                        {
                            intsub = 0;
                            intextra = 0;
                            int interror = 0;
                            for (int i = 0; i < chkteachsubject.Items.Count; i++)
                            {
                                if (chkteachsubject.Items[i].Selected == true)
                                {
                                    if (chkteachsubject.Items[i].Text == "Language")
                                        intsub = 1;
                                    if (chkteachsubject.Items[i].Text == "Extra Activities")
                                        intextra = 1;
                                }
                            }
                            intlan = 0;
                            intactivities = 0;
                            if (intsub == 1)
                            {
                                for (int i = 0; i < chklanguages.Items.Count; i++)
                                {
                                    if (chklanguages.Items[i].Selected == true)
                                    {
                                        intlan = 1;
                                    }
                                }
                                if (intlan == 0)
                                    interror = 1;
                            }
                            if (intextra == 1)
                            {
                                for (int i = 0; i < chkextraactivities.Items.Count; i++)
                                {
                                    if (chkextraactivities.Items[i].Selected == true)
                                    {
                                        intactivities = 1;
                                    }
                                }
                                if (intactivities == 0)
                                    interror = 2;
                            }

                            if (interror == 0)
                            {
                                if (intsub == 0)
                                {
                                    for (int i = 0; i < chklanguages.Items.Count; i++)
                                    {
                                        chklanguages.Items[i].Selected = false;
                                    }
                                }

                                if (intextra == 0)
                                {
                                    for (int i = 0; i < chkextraactivities.Items.Count; i++)
                                    {
                                        chkextraactivities.Items[i].Selected = false;
                                    }
                                }

                                if (ddlhomeclass.SelectedIndex > 0)
                                {
                                    string qry = "";
                                    DataAccess da = new DataAccess();
                                    DataSet ds = new DataSet();
                                    if (lblempid.Text == "0")
                                        qry = "select * from tblhomeclass where intschool=" + Session["SchoolID"].ToString() + " and strhomeclass='" + ddlhomeclass.SelectedValue + "'";
                                    else
                                        qry = "select * from tblhomeclass where intschool=" + Session["SchoolID"].ToString() + " and strhomeclass='" + ddlhomeclass.SelectedValue + "' and intemployee !=" + lblempid.Text;
                                    ds = da.ExceuteSql(qry);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        msgbox.alert("These class is assigned to another teacher");
                                    }
                                    else
                                    {
                                        savestaffdetails();
                                    }
                                }
                                else
                                    savestaffdetails();
                            }
                            else
                            {
                                if (interror == 1)
                                    msgbox.alert("Please select atleast one language");
                                if (interror == 2)
                                    msgbox.alert("Please select atleast one Extra Activities");
                            }
                        }
                        else
                        {
                            savestaffdetails();
                        }
                    }
                    else
                        msgbox.alert("Please select Designation");
                }
                else
                    msgbox.alert("Please select Department");
            }
            else
                msgbox.alert("Please select Staff Type");
        }
        catch { }
    }


    protected void savestaffdetails()
    {
        try
        {
            SqlCommand command;
            SqlParameter outputparam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("SPemployee", conn);
            command.CommandType = CommandType.StoredProcedure;
            outputparam = command.Parameters.Add("@ID", SqlDbType.Int);
            outputparam.Direction = ParameterDirection.Output;
            command.Parameters.Add("@intid", lblempid.Text);
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.Parameters.Add("@strfirstname", txtfirst.Text.Trim());
            command.Parameters.Add("@strmiddlename", txtmiddle.Text.Trim());
            command.Parameters.Add("@strlastname", txtlast.Text.Trim());
            command.Parameters.Add("@strguardianname", txtguardianname.Text.Trim());
            command.Parameters.Add("@strGender", ddlgen.SelectedValue);
            if (txtdob.Text != "")
                command.Parameters.Add("@dtDOB", txtdob.Text);
            else
                command.Parameters.Add("@dtDOB", "1900/01/01");
            if (txtjoiningdate.Text != "")
            {
                command.Parameters.Add("@dtDateofJoining", txtjoiningdate.Text);
                command.Parameters.Add("@dtprohibitfrom", txtjoiningdate.Text);
            }
            else
            {
                command.Parameters.Add("@dtDateofJoining", "1900/01/01");
                command.Parameters.Add("@dtprohibitfrom", "1900/01/01");
            }
            command.Parameters.Add("@intsalary", txtsal.Text.Trim());
            command.Parameters.Add("@strnationality", txtnation.Text.Trim());
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
            command.Parameters.Add("@strAddress", txtaddr.Text.Trim());

            command.Parameters.Add("@intcountry", ddlcountry.SelectedValue);

            command.Parameters.Add("@intstate", ddlstate.SelectedValue);

            command.Parameters.Add("@intcity", ddlcity.SelectedValue);
            command.Parameters.Add("@strZipCode", txtzip.Text.Trim());
            command.Parameters.Add("@strEMail", txtEmail.Text.Trim());
            command.Parameters.Add("@strPhone", txtph.Text.Trim());
            command.Parameters.Add("@intDepartment", ddldepart.SelectedValue);
            command.Parameters.Add("@intDesignation", ddldesignation.SelectedValue);
            if (ddladdproof.SelectedIndex > 0)
            {
                command.Parameters.Add("@straddproof", ddladdproof.SelectedValue);
            }
            else
            {
                command.Parameters.Add("@straddproof", "");
            }
            command.Parameters.Add("@strproofno", txtproofno.Text);
            if (rbtfather.Checked)
            {
                rbtfather.Checked = true;
                command.Parameters.Add("@strguardian", rbtfather.Text);
            }
            else
            {
                rbtfather.Checked = false;
                command.Parameters.Add("@strguardian", rbthusband.Text);
            }

            if (rbthostelyes.Checked)
            {
                command.Parameters.Add("@inthosteler", "1");
            }
            else
            {
                command.Parameters.Add("@inthosteler", "0");
            }

            if (rbtexpyes.Checked)
            {
                command.Parameters.Add("@intexperienced", "1");
            }
            else
            {
                command.Parameters.Add("@intexperienced", "0");
                txtexpmonth.Text = "0";
                txtexpyear.Text = "0";
            }

            command.Parameters.Add("@strproofother", txtother.Text);
            if (rbtyes.Checked)
            {
                rbtyes.Checked = true;
                command.Parameters.Add("@strchildstudy", rbtyes.Text);
            }
            else
            {
                rbtyes.Checked = false;
                command.Parameters.Add("@strchildstudy", rbtno.Text);
            }
            command.Parameters.Add("@strchilddetail", txtyesdetail.Text);
            if (txtprohibitto.Text != "")
                command.Parameters.Add("@dtprohibitto", txtprohibitto.Text);
            else
                command.Parameters.Add("@dtprohibitto", "1900/01/01");
            if (txtworkftime.Text != "")
                command.Parameters.Add("@dtworkftime", txtworkftime.Text);
            else
                command.Parameters.Add("@dtworkftime", "1900/01/01");
            if (txtworktotime.Text != "")
                command.Parameters.Add("@dtworktotime", txtworktotime.Text);
            else
                command.Parameters.Add("@dtworktotime", "1900/01/01");
            command.Parameters.Add("@strmobile", txtmobile.Text.Trim());
            command.Parameters.Add("@strtittle", ddltittle.SelectedValue);
            command.Parameters.Add("@intage", getage());
            command.Parameters.Add("@mobilesms", txtmobilesms.Text);
            command.Parameters.Add("@strallergy", txtallergies.Text);
            command.Parameters.Add("@identitymark", txtidentificationmark.Text);
            command.Parameters.Add("@docreceive", txtoriginalreceive.Text);
            command.Parameters.Add("@strremarks", txtotherremark.Text);
            command.Parameters.Add("@strtype", ddltype.SelectedValue);
            command.Parameters.Add("@intexpyear", txtexpyear.Text);
            command.Parameters.Add("@intexpmonth", txtexpmonth.Text);
            //command.Parameters.Add("@strheight", txtheight.Text);
            command.Parameters.Add("@strheight", "");
            if (ddlbloodgp.SelectedIndex > 0)
            {
                command.Parameters.Add("@strblood", ddlbloodgp.SelectedValue);
            }
            else
            {
                command.Parameters.Add("@strblood", "");
            }

            command.Parameters.Add("@strcommunity", "");
            if (rbtown.Checked)
            {
                rbtown.Checked = true;
                command.Parameters.Add("@transport", rbtown.Text);
            }
            else
            {
                rbtschool.Checked = true;
                command.Parameters.Add("@transport", rbtschool.Text);
            }
            command.ExecuteNonQuery();

            string id = Convert.ToString(outputparam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblemployee", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 23);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblemployee", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 126);
            }
            int sid = (int)(command.Parameters["@ID"].Value);
            if (sid > 0)
            {
                try
                {
                    if (file.PostedFile.FileName != "")
                    {
                        file.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\staff\\" + sid + ".jpg");
                    }
                }
                catch { }
                if (btnSave.Text == "Save")
                {
                    da = new DataAccess();
                    string str = "update tblemployee set loginid=strfirstname+ltrim(str(intid)),strpassword=(SELECT ltrim(substring(str(floor(RAND((DATEPART(mm, GETDATE()) * 100000)+ (DATEPART(ss, GETDATE()) * 1000 )+ DATEPART(ms, GETDATE())) * 1000000000)),1,7))) where intid=" + sid.ToString();
                    //Functions.UserLogs(Session["UserID"].ToString(), "tblemployee", sid.ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),23);

                    da.ExceuteSqlQuery(str);
                }
                lblempid.Text = sid.ToString();
                if (ddltype.SelectedValue == "Teaching Staffs")
                {
                    if (ddlhomeclass.SelectedIndex > 0)
                    {
                        strsql = "select intid from tblhomeclass where intschool=" + Session["SchoolID"].ToString() + " and intemployee=" + sid.ToString();
                        DataAccess dah = new DataAccess();
                        DataSet dsh = new DataSet();
                        dsh = dah.ExceuteSql(strsql);
                        if (dsh.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsh.Tables[0].Rows.Count; i++)
                            {
                                Functions.UserLogs(Session["UserID"].ToString(), "tblhomeclass", dsh.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 23);
                            }
                        }
                        da = new DataAccess();
                        strsql = "delete tblhomeclass where intschool=" + Session["SchoolID"].ToString() + " and intemployee=" + sid.ToString();
                        da.ExceuteSqlQuery(strsql);

                        da = new DataAccess();
                        DataSet ds = new DataSet();
                        strsql = "insert into tblhomeclass (strhomeclass,intschool,intemployee) values('" + ddlhomeclass.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + sid.ToString() + ")";
                        da.ExceuteSqlQuery(strsql);
                        strsql = "select max(intid) as intid from tblhomeclass";
                        ds = da.ExceuteSql(strsql);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblhomeclass", ds.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 23);

                    }
                    selectedteachsubject();
                    selectedteachclass();
                }

                conn.Close();
                filleducationgrid();
                fillexperiencegrid();
                enablecontrols();
                //btnSave.Text = "Update";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
            }
        }
        catch { }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlstate();
        fillddlcity();
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlcity();
    }

    protected void ddladdproof_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladdproof.SelectedValue == "Other")
        {
            txtother.Text = "";
            txtother.Visible = true;
            Label30.Visible = true;
        }
        else
        {
            txtother.Text = "";
            txtother.Visible = false;
            Label30.Visible = false;
        }
    }

    private void filleducationgrid()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblemployeeeducation where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee=" + lblempid.Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgeducation.DataSource = ds;
        dgeducation.DataBind();
    }

    private void fillexperiencegrid()
    {
        DataAccess da = new DataAccess();
        strsql = "select *,convert(varchar(10),dtperiodfrom,101) as dtperiodfrom1 ,convert(varchar(10),dtperiodto,101) as dtperiodto1 from tblemployeeexperience where intschool= '" + Session["SchoolID"].ToString() + "' and intemployee=" + lblempid.Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgexperience.DataSource = ds;
        dgexperience.DataBind();
    }

    public void clear()
    {
        //ddlmode.Items.Insert(0, "--Select--");
        txtpercent.Text = "";
        txtpassedout.Text = "";
        txtmajor.Text = "";
        txtdegree.Text = "";
        txtinstitutename.Text = "";
        btnsave2.Text = "Save";
    }

    public void erase()
    {
        txtorgdesig.Text = "";
        txtorgname.Text = "";
        txtperiodfrom.Text = "";
        txtperiodto.Text = "";
        txtorgdept.Text = "";
        btnsubmit.Text = "Save";
    }

    protected int educon()
    {
        int i = 0;
        if (trdegree.Visible == true)
        {
            if (txtdegree.Text == "")
            {
                msgbox.alert("Enter the degree");
                i = 1;
            }
        }
        else if (txtmajor.Text == "")
        {
            msgbox.alert("Enter the Major");
            i = 1;
        }
        else if (txtinstitutename.Text == "")
        {
            msgbox.alert("Enter the Institution Name");
            i = 1;
        }
        else if (txtpercent.Text == "")
        {
            msgbox.alert("Enter the Percentage");
            i = 1;
        }
        else if (txtpassedout.Text == "")
        {
            msgbox.alert("Enter the Passedout year");
            i = 1;
        }
        return i;
    }

    protected void btnSave2_Click(object sender, EventArgs e)
    {
        if (lblempid.Text != "0")
        {
            if (educon() == 0)
            {
                SqlCommand RegCommand;
                SqlParameter outputparam;
                SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                Conn.Open();
                RegCommand = new SqlCommand("spemployeeeducation", Conn);
                RegCommand.CommandType = CommandType.StoredProcedure;
                outputparam = RegCommand.Parameters.Add("@ID", SqlDbType.Int);
                outputparam.Direction = ParameterDirection.Output;
                if (btnsave2.Text == "Save")
                {
                    RegCommand.Parameters.Add("@intID", "0");
                }
                else
                {
                    RegCommand.Parameters.Add("@intID", lbleduid.Text);
                }

                RegCommand.Parameters.Add("@intschool", Session["schoolID"].ToString());
                RegCommand.Parameters.Add("@intemployee", lblempid.Text);
                RegCommand.Parameters.Add("@strmode", ddlmode.SelectedValue);
                RegCommand.Parameters.Add("@strdegree", txtdegree.Text.Trim());
                RegCommand.Parameters.Add("@strmajor", txtmajor.Text.Trim());
                RegCommand.Parameters.Add("@strinstitution", txtinstitutename.Text.Trim());
                RegCommand.Parameters.Add("@intyearpass", txtpassedout.Text.Trim());
                RegCommand.Parameters.Add("@intpercent", txtpercent.Text.Trim());
                RegCommand.ExecuteNonQuery();
                string id1 = Convert.ToString(outputparam.Value);
                if (btnsave2.Text == "Save")
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeeducation", id1, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 23);
                }
                else
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeeducation", id1, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 126);
                }
                if ((int)(RegCommand.Parameters["@ID"].Value) > 0)
                {
                    int s = (int)(RegCommand.Parameters["@ID"].Value);
                    lbleduid.Text = s.ToString();
                }
                Conn.Close();
                clear();
                filleducationgrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
            }
        }
        else
            msgbox.alert("Please Save the Personal Details");
    }

    protected int expcon()
    {
        int i = 0;
        if (txtorgname.Text == "")
        {
            msgbox.alert("Enter the Organization name");
            i = 1;
        }
        else if (txtorgdept.Text == "")
        {
            msgbox.alert("Enter the Department Name");
            i = 1;
        }
        else if (txtorgdesig.Text == "")
        {
            msgbox.alert("Enter the Designation");
            i = 1;
        }
        else if (txtperiodfrom.Text == "")
        {
            msgbox.alert("Enter the Period");
            i = 1;
        }
        else if (txtperiodto.Text == "")
        {
            msgbox.alert("Enter the Period");
            i = 1;
        }
        return i;
    }

    protected void btnerase_Click(object sender, EventArgs e)
    {
        erase();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (lblempid.Text != "0")
        {
            da = new DataAccess();
            strsql = "select intexperienced from tblemployee where intid=" + lblempid.Text;
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                if (expcon() == 0)
                {
                    SqlCommand RegCommand;
                    SqlParameter outputparam;
                    SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                    Conn.Open();
                    RegCommand = new SqlCommand("spemployeeexperience", Conn);
                    RegCommand.CommandType = CommandType.StoredProcedure;
                    outputparam = RegCommand.Parameters.Add("@ID", SqlDbType.Int);
                    outputparam.Direction = ParameterDirection.Output;
                    if (btnsubmit.Text == "Save")
                    {
                        RegCommand.Parameters.Add("@intID", "0");
                    }
                    else
                    {
                        RegCommand.Parameters.Add("@intID", lblexpid.Text);
                    }
                    expcon();
                    RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    RegCommand.Parameters.Add("@intemployee", lblempid.Text);
                    RegCommand.Parameters.Add("@strorganization", txtorgname.Text.Trim());
                    RegCommand.Parameters.Add("@dtperiodfrom", DateTime.Parse(txtperiodfrom.Text).Year.ToString() + "/" + DateTime.Parse(txtperiodfrom.Text).Month.ToString() + "/" + DateTime.Parse(txtperiodfrom.Text).Day.ToString());
                    RegCommand.Parameters.Add("@dtperiodto", DateTime.Parse(txtperiodto.Text).Year.ToString() + "/" + DateTime.Parse(txtperiodto.Text).Month.ToString() + "/" + DateTime.Parse(txtperiodto.Text).Day.ToString());
                    RegCommand.Parameters.Add("@strdepartment", txtorgdept.Text.Trim());
                    RegCommand.Parameters.Add("@strdesignation", txtorgdesig.Text.Trim());
                    RegCommand.ExecuteNonQuery();
                    string id1 = Convert.ToString(outputparam.Value);
                    if (btnsubmit.Text == "Save")
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeexperience", id1, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 23);
                    }
                    else
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeexperience", id1, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 126);
                    }
                    if ((int)(RegCommand.Parameters["@ID"].Value) > 0)
                    {
                        int s = (int)(RegCommand.Parameters["@ID"].Value);
                        lblexpid.Text = s.ToString();
                    }
                    Conn.Close();
                    try
                    {
                        if (btnsubmit.Text == "Update")
                        {
                            da = new DataAccess();
                            da.filllogs(int.Parse(Session["UserID"].ToString()), "Employee experience details Updated", int.Parse(Session["experience"].ToString()), int.Parse(Session["SchoolID"].ToString()));
                        }
                    }
                    catch { }
                    erase();
                    fillexperiencegrid();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
                }
            }
            else
                msgbox.alert("Please Save the Personal Details");
        }
        else
            msgbox.alert("Please Save the Personal Details");
    }

    protected void btndone_Click(object sender, EventArgs e)
    {
        if (Request["rd"] != null)
        {
            if (Request["rd"].ToString() == "1")
                Response.Redirect("employeedetails.aspx?rd=1");
            else if (Request["rd"].ToString() == "2")
                Response.Redirect("edit_employee_details.aspx?rd=1");
        }
        else
            Response.Redirect("employeedetails.aspx");
    }

    protected void btnclear2_Click(object sender, EventArgs e)
    {
        clear();
    }

    //protected void dgeducation_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    strsql = "delete tblemployeeeducation where intid=" + e.Item.Cells[0].Text;
    //    Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeeducation", e.Item.Cells[0].Text , "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),126);

    //    cmd = new SqlCommand(strsql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    filleducationgrid();
    //    try
    //    {
    //        da.filllogs(int.Parse(Session["UserID"].ToString()), "Employee education details deleted", int.Parse(e.Item.Cells[0].Text), int.Parse(Session["SchoolID"].ToString()));
    //    }
    //    catch { }
    //}
    protected void btndelete1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblemployeeeducation where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeeducation", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 126);

            da.ExceuteSqlQuery(sql);
            filleducationgrid();
        }
        catch { }
    }
    protected void dgeducation_EditCommand(object source, DataGridCommandEventArgs e)
    {
        lbleduid.Text = e.Item.Cells[0].Text;
        ddlmode.SelectedValue = e.Item.Cells[2].Text;
        txtdegree.Text = e.Item.Cells[3].Text;
        txtmajor.Text = e.Item.Cells[4].Text;
        txtinstitutename.Text = e.Item.Cells[5].Text;
        txtpassedout.Text = e.Item.Cells[6].Text;
        txtpercent.Text = e.Item.Cells[7].Text;
        btnsave2.Text = "Update";
    }

    //protected void dgexperience_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    strsql = "delete tblemployeeexperience where intid=" + e.Item.Cells[0].Text;
    //    Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeexperience", e.Item.Cells[0].Text , "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),126);

    //    cmd = new SqlCommand(strsql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    fillexperiencegrid();
    //    da = new DataAccess();
    //    try
    //    {
    //        da.filllogs(int.Parse(Session["UserID"].ToString()), "Employee experience details deleted", int.Parse(e.Item.Cells[0].Text), int.Parse(Session["SchoolID"].ToString()));
    //    }
    //    catch { }
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblemployeeexperience where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblemployeeexperience", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 126);

            da.ExceuteSqlQuery(sql);
            fillexperiencegrid();
        }
        catch { }
    }
    protected void dgexperience_EditCommand(object source, DataGridCommandEventArgs e)
    {
        lblexpid.Text = e.Item.Cells[0].Text;
        da = new DataAccess();
        strsql = "select *,convert(varchar(10),dtperiodfrom,101) as dtperiodfrom1 ,convert(varchar(10),dtperiodto,101) as dtperiodto1  from tblemployeeexperience where intschool=" + Session["SchoolID"].ToString() + " and intid=" + e.Item.Cells[0].Text;
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        txtorgname.Text = ds.Tables[0].Rows[0]["strorganization"].ToString();
        txtperiodfrom.Text = ds.Tables[0].Rows[0]["dtperiodfrom1"].ToString();
        txtperiodto.Text = ds.Tables[0].Rows[0]["dtperiodto1"].ToString();
        txtorgdept.Text = ds.Tables[0].Rows[0]["strdepartment"].ToString();
        txtorgdesig.Text = ds.Tables[0].Rows[0]["strdesignation"].ToString();
        btnsubmit.Text = "Update";
    }

    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmode.SelectedValue == "SSLC")
        {
            trdegree.Visible = false;
            txtdegree.Text = "";
        }
        else if (ddlmode.SelectedValue == "HSC")
        {
            trdegree.Visible = false;
            txtdegree.Text = "";
        }
        else
        {
            trdegree.Visible = true;
            txtdegree.Text = "";
        }
    }

    protected void rbtyes_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtyes.Checked)
            trchild.Visible = true;
        else
            trchild.Visible = false;
    }

    protected void rbtno_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtno.Checked)
            trchild.Visible = false;
        else
            trchild.Visible = true;
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

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedValue != "Teaching Staffs")
        {
            trteaching.Visible = false;
            ddlhomeclass.Enabled = false;
        }
        else
        {
            trteaching.Visible = true;
            ddlhomeclass.Enabled = true;
        }
    }

    protected void rbtexpno_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtexpno.Checked)
        {
            txtexpyear.Enabled = false;
            txtexpmonth.Enabled = false;
            trexperienced.Visible = false;
        }
    }

    protected void rbtexpyes_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtexpyes.Checked)
        {
            txtexpyear.Enabled = true;
            txtexpmonth.Enabled = true;
            trexperienced.Visible = true;
        }
    }
    protected void btnClear3_Click(object sender, EventArgs e)
    {
        if (Request["rd"] != null)
        {
            if (Request["rd"].ToString() == "1")
            {
                Response.Redirect("employeedetails.aspx?rd=" + Request["rd"].ToString());
            }
            if (Request["rd"].ToString() == "2")
            {
                Response.Redirect("edit_employee_details.aspx?rd=" + Request["rd"].ToString());
            }
        }
    }



   
   
}
