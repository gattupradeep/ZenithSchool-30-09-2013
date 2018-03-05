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

public partial class specialclasses_assign_specialclasses : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclass();
            ddlteacher.Items.Insert(0, "-Select-");
            ddlsubject.Items.Insert(0, "-Select-");
            ddlstaff.Items.Insert(0, "-Select-");
            ddlstaff.Enabled = false;
            if (Request["rd"] != null)
            {
                fillclass();
                fillteachsubject();
                fillstaffname();
                fillstaff();
                btnback.Visible = true;                
                edit();
            }
            else
            {
                btnback.Visible = false;
            }
            
        }
    }
    
    protected void fillteachsubject()
    {
        DataAccess da = new DataAccess();
        strsql = " select strsubject from (select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strsubject !='Second Language' and strsubject!='Third language' and strstandard='"+ddlclass.SelectedValue+"' group by strstandard,strsection,strsubject";
        strsql += " UNION ALL select strstandard+' - '+strsection as class,strsecondlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strsecondlanguage !='' group by strsecondlanguage,strstandard+' - '+strsection";
        strsql += " UNION ALL select strstandard+' - '+strsection as class,strthirdlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strthirdlanguage !='' group by strthirdlanguage,strstandard+' - '+strsection ";
        strsql += "  UNION ALL select strstandard+' - '+strsection as class,strcurricular from tblstandard_section_extraCurricular where intschoolid=" + Session["SchoolID"].ToString() + " ) a group by strsubject";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlsubject.Items.Insert(0, li);
    }
    protected void fillstaffname()
    {
        strsql = " select strfirstname + ' ' + strmiddlename + ' ' + strlastname as name,intid from tblemployee where strtype='Teaching Staffs' and intSchool=" + Session["SchoolID"].ToString()+" group by strfirstname,strmiddlename,strlastname,intid";
        strsql = strsql + " union all select 'Others' as  name,'' as intid";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlteacher.DataSource = ds;
        ddlteacher.Items.Clear();
        ddlteacher.DataTextField = "name";
        ddlteacher.DataValueField = "intid";
        ddlteacher.DataBind();
        ListItem li = new ListItem("-Select-", "-1");
        ddlteacher.Items.Insert(0, li);
        //ddlteacher.Items.Insert(0, "--select--");
    }
    protected void fillclass()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strstandard+' - '+strsection as teachclass from dbo.tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "teachclass";
        ddlclass.DataValueField = "teachclass";
        ddlclass.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlclass.Items.Insert(0, li);
        //ddlclass.Items.Insert(0, "--select--");
    }
    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strSubject from tblspecialclasses where intSpecialClassesID=" + Request["rd"].ToString();
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strSubject";
        ddlsubject.DataValueField = "strSubject";
        ddlsubject.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlsubject.Items.Insert(0, li);
        //ddlsubject.Items.Insert(0, "--select--");
    }

    protected void fillstaff()
    {
        strsql = " select strfirstname + ' ' + strmiddlename + ' ' + strlastname as name,intid from tblemployee where strtype!='Teaching Staffs' and intSchool=" + Session["SchoolID"].ToString() ;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstaff.DataSource = ds;
        ddlstaff.Items.Clear();
        ddlstaff.DataTextField = "name";
        ddlstaff.DataValueField = "intid";
        ddlstaff.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlstaff.Items.Insert(0, li);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    { 
        try
        {
            da = new DataAccess();
            if (btnsave.Text == "Save")
                strsql = "select * from tblspecialclasses where strClass ='" + ddlclass.SelectedValue + "' and dtDate='" + txtdate.Text.Trim() + "' and strStartTime='" + txtfromtime.Text.Trim() + "' and strEndTime='" + txttotime.Text.Trim() + "' and intSchoolID=" + Session["SchoolID"].ToString();
            else
            {
                if (ddlteacher.SelectedIndex > 0)
                    strsql = "select * from tblspecialclasses where strClass='" + ddlclass.SelectedValue + "' and dtDate='" + txtdate.Text.Trim() + "' and strStartTime='" + txtfromtime.Text.Trim() + "' and strEndTime='" + txttotime.Text.Trim() + "' and strSubject='" + ddlsubject.SelectedValue + "' and intEmployeeID=" + ddlteacher.SelectedValue + " and intSchoolID=" + Session["SchoolID"].ToString() + " and intSpecialClassesID !=" + Request["rd"].ToString();
                else if (ddlstaff.SelectedIndex > 0)
                    strsql = "select * from tblspecialclasses where strClass='" + ddlclass.SelectedValue + "' and dtDate='" + txtdate.Text.Trim() + "' and strStartTime='" + txtfromtime.Text.Trim() + "' and strEndTime='" + txttotime.Text.Trim() + "' and strSubject='" + ddlsubject.SelectedValue + "' and intEmployeeID=" + ddlstaff.SelectedValue + " and intSchoolID=" + Session["SchoolID"].ToString() + " and intSpecialClassesID !=" + Request["rd"].ToString();
            }
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                msgbox.alert("Already assigned same class and timings");
            }
            else
            {
                DateTime st = DateTime.Parse(txtfromtime.Text.Trim());
                DateTime et = DateTime.Parse(txttotime.Text.Trim());
                if (st > et)
                {
                    msgbox.alert("Invalid end time.");
                }
                else
                {
                    if (btnsave.Text == "Save")
                    {
                        SqlCommand command;
                        SqlParameter outputparam;
                        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                        conn.Open();
                        command = new SqlCommand("SPSpecialClasses", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        outputparam = command.Parameters.Add("@ID", SqlDbType.Int);
                        outputparam.Direction = ParameterDirection.Output;
                        command.Parameters.Add("@intSpecialClassesID", "0");
                        command.Parameters.Add("@strClass", ddlclass.SelectedValue);
                        command.Parameters.Add("@dtDate", txtdate.Text.Trim());
                        command.Parameters.Add("@strStartTime", txtfromtime.Text);
                        command.Parameters.Add("@strEndTime", txttotime.Text);
                        command.Parameters.Add("@strSubject", ddlsubject.SelectedValue);
                        command.Parameters.Add("@strRemarks", txtremarks.Text);
                        command.Parameters.Add("@intSchoolID", Session["SchoolID"].ToString());
                        command.Parameters.Add("@strSMSBody", "special classes assigned.Date:" + txtdate.Text.Trim() + ",Time:" + txtfromtime.Text.Trim() + "-" + txttotime.Text.Trim() + ",subject:" + ddlsubject.SelectedValue + "'");
                        command.Parameters.Add("@intSMSFlag", "1");
                        if (ddlteacher.SelectedItem.Text == "Others")
                        {
                            command.Parameters.Add("@intEmployeeID", ddlstaff.SelectedValue);
                            command.Parameters.Add("@IsEmployeeOthers", "1");
                        }
                        else
                        {
                            command.Parameters.Add("@intEmployeeID", ddlteacher.SelectedValue);
                            command.Parameters.Add("@IsEmployeeOthers", "0");
                        }
                        command.ExecuteNonQuery();
                        conn.Close();
                        string id;
                        id = Convert.ToString(outputparam.Value);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblspecialclasses", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 304);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Saved Successfully')", true);
                    }
                    else
                    {
                        SqlCommand command;
                        SqlParameter outputparam;
                        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                        conn.Open();
                        command = new SqlCommand("SPSpecialClasses", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        outputparam = command.Parameters.Add("@ID", SqlDbType.Int);
                        outputparam.Direction = ParameterDirection.Output;
                        command.Parameters.Add("@intSpecialClassesID", Request["rd"].ToString());
                        command.Parameters.Add("@strClass", ddlclass.SelectedValue);
                        command.Parameters.Add("@dtDate", txtdate.Text.Trim());
                        command.Parameters.Add("@strStartTime", txtfromtime.Text);
                        command.Parameters.Add("@strEndTime", txttotime.Text);
                        command.Parameters.Add("@strSubject", ddlsubject.SelectedValue);
                        command.Parameters.Add("@strRemarks", txtremarks.Text);
                        command.Parameters.Add("@intSchoolID", Session["SchoolID"].ToString());
                        command.Parameters.Add("@strSMSBody", "special classes assigned.Date:" + txtdate.Text.Trim() + ",Time:" + txtfromtime.Text.Trim() + "-" + txttotime.Text.Trim() + ",subject:" + ddlsubject.SelectedValue);
                        command.Parameters.Add("@intSMSFlag", "1");
                        if (ddlteacher.SelectedItem.Text == "Others")
                        {
                            command.Parameters.Add("@intEmployeeID", ddlstaff.SelectedValue);
                            command.Parameters.Add("@IsEmployeeOthers", "1");
                        }
                        else
                        {
                            command.Parameters.Add("@intEmployeeID", ddlteacher.SelectedValue);
                            command.Parameters.Add("@IsEmployeeOthers", "0");
                        }
                        command.ExecuteNonQuery();
                        conn.Close();
                        string id;
                        id = Convert.ToString(outputparam.Value);

                        Functions.UserLogs(Session["UserID"].ToString(), "tblspecialclasses", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 305);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='Edit_delete_specialclasses.aspx?std=" + ddlclass.SelectedValue+"';", true);
                        //Response.Redirect("Edit_delete_specialclasses.aspx?std=" + ddlclass.SelectedValue);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='assignsubstitute.aspx';", true);
                    }
                }
            }
        }
        catch { }
        clear();
    }
    
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        ddlclass.SelectedIndex = 0;
        ddlteacher.SelectedItem.Text = "-Select-";
        ddlsubject.SelectedIndex = 0;
        txtdate.Text = "";
        txtfromtime.Text = "";
        txttotime.Text = "";
        txtremarks.Text = "";
        btnsave.Text = "Save";
        ddlstaff.SelectedIndex = 0;
        ddlstaff.Enabled = false;
        btnback.Visible = false;
    }
    protected void edit()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select *,convert(varchar(10),dtDate,111) as date from tblspecialclasses where intSpecialClassesID =" + Request["rd"].ToString();
        ds = da.ExceuteSql(strsql);
        ddlclass.SelectedValue = ds.Tables[0].Rows[0]["strClass"].ToString();
        txtdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
        txtfromtime.Text = ds.Tables[0].Rows[0]["strStartTime"].ToString();
        txttotime.Text = ds.Tables[0].Rows[0]["strEndTime"].ToString();
        ddlsubject.SelectedValue = ds.Tables[0].Rows[0]["strSubject"].ToString();
        if (ds.Tables[0].Rows[0]["IsEmployeeOthers"].ToString() == "1")
        {
            ddlstaff.Enabled = true;
            ddlteacher.SelectedItem.Text = "Others";
            ddlstaff.SelectedValue = ds.Tables[0].Rows[0]["intEmployeeID"].ToString();
        }
        else
        {
            ddlteacher.SelectedValue = ds.Tables[0].Rows[0]["intEmployeeID"].ToString();
            ddlstaff.SelectedIndex = 0;
            ddlstaff.Enabled = false;
        }
        txtremarks.Text = ds.Tables[0].Rows[0]["strRemarks"].ToString();
        btnsave.Text = "Update";
    }
    //protected void btnsendsms_Click(object sender, EventArgs e)
    //{
    //    string clas = "";

    //    for (int i = 0; i < chkhomeclass.Items.Count; i++)
    //    {
    //        if (chkhomeclass.Items[i].Selected == true)
    //        {
    //            if (clas == "")
    //                clas = chkhomeclass.Items[i].Text;
    //            else
    //                clas = clas + "," + chkhomeclass.Items[i].Text;
    //        }
    //    }
    //    try
    //    {
    //        da = new DataAccess();
    //        if (btnsave.Text == "Save &amp; send sms")
    //            strsql = "select * from tblspecialclasses where strClass in('" + clas.Replace(",", "','") + "') and dtDate='" + txtdate.Text.Trim() + "' and strStartTime='" + txtfromtime.Text.Trim() + "' and strEndTime='" + txttotime.Text.Trim() + "' and intSchoolID=" + Session["SchoolID"].ToString();
    //        else
    //            strsql = "select * from tblspecialclasses where strClass='" + ddlclass.SelectedValue + "' and dtDate='" + txtdate.Text.Trim() + "' and strStartTime='" + txtfromtime.Text.Trim() + "' and strEndTime='" + txttotime.Text.Trim() + "' and str_subject='" + ddlsubject.SelectedValue + "' and intEmployee=" + ddlteacher.SelectedValue + " and intSchoolID=" + Session["SchoolID"].ToString();
    //        ds = new DataSet();
    //        ds = da.ExceuteSql(strsql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //        }
    //        else
    //        {
    //            DateTime st = DateTime.Parse(txtfromtime.Text.Trim());
    //            DateTime et = DateTime.Parse(txttotime.Text.Trim());
    //            if (st > et)
    //            {
    //                msgbox.alert("Invalid end time.");
    //            }
    //            else
    //            {
    //                if (btnsendsms.Text == "Save &amp; send sms")
    //                {
    //                    if (clas != "")
    //                    {
    //                        for (int i = 0; i < chkhomeclass.Items.Count; i++)
    //                        {
    //                            if (chkhomeclass.Items[i].Selected == true)
    //                            {
    //                                da = new DataAccess();
    //                                strsql = "insert into tblspecialclasses(strClass,dtDate,strStartTime,strEndTime,str_subject,intEmployee,strRemarks,intSchoolID)";
    //                                strsql = strsql + " values('" + chkhomeclass.Items[i].Text + "','" + txtdate.Text.Trim() + "','" + txtfromtime.Text.Trim() + "','" + txttotime.Text.Trim() + "','" + ddlsubject.SelectedValue + "'," + ddlteacher.SelectedValue + ",'" + txtremarks.Text.Trim() + "'," + Session["SchoolID"].ToString() + ")";
    //                                da.ExceuteSqlQuery(strsql);
    //                            }
    //                        }
    //                        msgbox.alert("successfully saved...");

    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("select atleast one class");
    //                    }
    //                }
    //                else
    //                {
    //                    da = new DataAccess();
    //                    strsql = "update tblspecialclasses set strClass='" + ddlclass.SelectedValue + "',dtDate='" + txtdate.Text.Trim() + "',strStartTime='" + txtfromtime.Text.Trim() + "',strEndTime='" + txttotime.Text.Trim() + "',str_subject='" + ddlsubject.SelectedValue + "',intEmployee=" + ddlteacher.SelectedValue + ",strRemarks='" + txtremarks.Text.Trim() + "' where intid=" + Session["intid"].ToString();
    //                    da.ExceuteSqlQuery(strsql);
    //                    msgbox.alert("successfully updated...");

    //                    Response.Redirect("Edit_delete_specialclasses.aspx");
    //                }
    //            }
    //        }

    //    }
    //    catch { }
    //    clear();
    //}

    //protected void sendsms()
    //{
    //    da = new DataAccess();
    //    if(Session["std"] != null)
    //    {
    //        string[] abc = Session["std"].ToString().Split(',');
    //        for(int i=0; i < abc.Length; i++)
    //        {
    //            string[] xy = abc[i].Split('-');

    //            strsql = "select strmobile from tblstudent where strstandard='" + xy[0].Trim() + "' and strsection='" + xy[1].Trim() + "' group by strmobile";
    //            ds = new DataSet();
    //            ds = da.ExceuteSql(strsql);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    string strUrl = "http://sms1.mmsworld.in/pushsms.php";
    //                    Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[k]["strmobile"].ToString() + "&message=Special &priority=1");
    //                    //api_password=9d04ex0qz0zb3qcca
    //                }

    //            }                
    //        }
    //    }
        
    //}
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlteacher.SelectedItem.Text == "Others")
        {
            fillstaff();
            ddlstaff.Enabled = true;
        }
        else
            ddlstaff.Enabled = false;
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillteachsubject();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaffname();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit_delete_specialclasses.aspx?Class1=" + ddlclass.SelectedValue);
    }
}

