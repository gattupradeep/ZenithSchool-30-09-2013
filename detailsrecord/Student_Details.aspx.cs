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

public partial class school_Student_Details : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataSet ds;
    public DataAccess da;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PatronType"] != null && Session["UserID"] != null)
            {
                string pat = Session["PatronType"].ToString();
                if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
                {
                    Response.Redirect("../detailsrecord/view_studentdetails.aspx");
                }
            }
            //menu00.Visible = false;
            fillstandard();
            trtag.Visible = false;
            ddlsection.Items.Insert(0, "--Select--");
            if (Request["rd"] != null)
            {
                try
                {
                    if (Session["SearchStudentStandard"] != null)
                    {
                        ddlstandard.SelectedValue = Session["SearchStudentStandard"].ToString();
                        fillbystandard();
                        fillsearch();
                    }
                    if (Session["SearchStudentSection"] != null)
                    {
                        ddlsection.SelectedValue = Session["SearchStudentSection"].ToString();
                        fillbysection();
                        fillsearch();
                    }
                    if (Session["SearchStudentName"] != null)
                    {
                        txtname.Text = Session["SearchStudentName"].ToString();
                        fillsearch();
                    }
                }
                catch { }
            }
        }
        if (ddlstandard.SelectedIndex > 1 && ddlsection.SelectedIndex > -1)
        {
            autocomplete1.ContextKey = ddlstandard.SelectedValue + " - " + ddlsection.SelectedValue;
            AutoCompleteExtender2.ContextKey = ddlstandard.SelectedValue + " - " + ddlsection.SelectedValue;
        }
        else
        {
            autocomplete1.ContextKey = ddlstandard.SelectedValue;
            AutoCompleteExtender2.ContextKey = ddlstandard.SelectedValue;
        }
    }

    protected void dgstudetails_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        Response.Redirect("student.aspx?intID=" + e.Item.Cells[0].Text);
    }

    protected void dgstudetails_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblstudent where intID=" + e.Item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 20);

        da.ExceuteSqlQuery(sql);
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillbystandard();
        fillsearch();
    }

    protected void fillbystandard()
    {
        clearindv();
        if (ddlstandard.SelectedIndex > 1)
        {
            fillsection();
            if (ddlstandard.SelectedIndex > 1 && ddlsection.SelectedIndex > -1)
            {
                autocomplete1.ContextKey = ddlstandard.SelectedValue + " - " + ddlsection.SelectedValue;
                AutoCompleteExtender2.ContextKey = ddlstandard.SelectedValue + " - " + ddlsection.SelectedValue;
            }
            else
            {
                autocomplete1.ContextKey = ddlstandard.SelectedValue;
                AutoCompleteExtender2.ContextKey = ddlstandard.SelectedValue;
            }
            search(1);
        }
        else
        {
            ddlsection.Items.Clear();
            ddlsection.Items.Insert(0, "--Select--");
            txtname.Text = "";
            search(1);
        }
        Session["SearchStudentStandard"] = ddlstandard.SelectedValue;
    }

    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillbysection();
        fillsearch();
    }

    protected void fillbysection()
    {
        clearindv();
        if (ddlsection.SelectedIndex > 0)
        {
            search(1);
        }
        else
        {
            txtname.Text = "";
            search(1);
        }
        Session["SearchStudentSection"] = ddlsection.SelectedValue;
    }

    #region filldropdowns

    protected void fillstandard()
    {
        string str = "select strstandard from tblstudent where intschool = '" + Session["SchoolID"].ToString() + "' group by strstandard";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
        ddlstandard.Items.Insert(1, "All");
    }

    protected void fillsection()
    {
        string str = "select strsection from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and intschool = '" + Session["SchoolID"].ToString() + "'  group by strsection ";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        //ddlsection.Items.Insert(0, "All");
    }

    protected void fillreligion()
    {
        DataAccess da = new DataAccess();
        if (ddlstandard.SelectedIndex > 1)
            strsql = " select strreligion from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        else
            strsql = " select strreligion from tblstudent where intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        if (ddlsection.SelectedIndex > 0)
            strsql = strsql + " and strsection='" + ddlsection.SelectedValue + "'";
        strsql = strsql + " group by strreligion";

        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbyreligion.DataSource = ds;
        searchbyreligion.DataTextField = "strreligion";
        searchbyreligion.DataValueField = "strreligion";
        searchbyreligion.DataBind();
        searchbyreligion.Items.Insert(0, "All");
    }

    protected void fillhousename()
    {
        DataAccess da = new DataAccess();
        if (ddlstandard.SelectedIndex > 1)
            strsql = " select strhouse from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        else
            strsql = " select strhouse from tblstudent where intschool='" + Session["SchoolID"].ToString() + "'";// and intid="+ Session["intid"].ToString();
        if (ddlsection.SelectedIndex > 0)
            strsql = strsql + " and strsection='" + ddlsection.SelectedValue + "'";
        strsql = strsql + " group by strhouse";

        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        searchbyhouse.DataSource = ds;
        searchbyhouse.DataTextField = "strhouse";
        searchbyhouse.DataValueField = "strhouse";
        searchbyhouse.DataBind();
        searchbyhouse.Items.Insert(0, "All");
    }

    protected void fillbirthday()
    {
        searchbybirthday.Items.Clear();
        searchbybirthday.Items.Insert(0, "All");
        searchbybirthday.Items.Insert(1, "Today");
        searchbybirthday.Items.Insert(2, "This Week");
        searchbybirthday.Items.Insert(3, "This Month");
    }

    #endregion



    protected void clearindv()
    {
        try
        {
            txtadmissionno.Text = "";
            searchbygender.SelectedIndex = 0;
            searchbytransport.SelectedIndex = 0;
            searchbyhostler.SelectedIndex = 0;
            searchbyreligion.SelectedIndex = 0;
            searchbybirthday.SelectedIndex = 0;
            searchbyblood.SelectedIndex = 0;
            searchbyhouse.SelectedIndex = 0;
        }
        catch { }
    }

    protected void searchbyadmission_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }

    protected void searchbyrollno_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }

    protected void searchbygender_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }

    protected void searchbytransport_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }
    protected void searchbyhostler_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }

    protected void searchbyreligion_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }
    protected void searchbybirthday_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }

    protected void searchbyblood_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }

    protected void searchbyhouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        search(2);
    }

    protected void search(int md)
    {
        DataAccess da = new DataAccess();
        strsql = "select strhouse, strfirstname + ' ' + strmiddlename + ' ' + strlastname as name,strsecondlanguage + ',' + strthirdlanguage as language,convert(varchar(10),strdateofbirth,103) as strdateofbirth, * from tblstudent where intTransferredID=0 and intschool='" + Session["SchoolID"].ToString() + "'";
        if (ddlstandard.SelectedIndex > 1)
            strsql = strsql + " and strstandard='" + ddlstandard.SelectedValue + "'";

        if (ddlsection.SelectedIndex > 0)
            strsql = strsql + " and strsection='" + ddlsection.SelectedValue + "'";

        if (txtname.Text != "")
            strsql = strsql + " and strfirstname + ' ' + strmiddlename + ' ' + strlastname= '" + txtname.Text + "'";

        if (txtadmissionno.Text != "")
            strsql = strsql + " and intadmitno='" + txtadmissionno.Text + "'";

        if (searchbygender.SelectedIndex > 0)
            strsql = strsql + " and strgender= '" + searchbygender.SelectedValue + "'";

        if (searchbytransport.SelectedIndex > 0)
            strsql = strsql + " and str_transport='" + searchbytransport.SelectedValue + "'";

        if (searchbyhostler.SelectedIndex > 0)
            strsql = strsql + " and hostler=" + searchbyhostler.SelectedValue;

        if (searchbyreligion.SelectedIndex > 0)
            strsql = strsql + " and strreligion= '" + searchbyreligion.SelectedValue + "'";

        if (searchbybirthday.SelectedIndex > 0)
        {
            if (searchbybirthday.SelectedValue == "Today")
            {
                strsql = strsql + " and month(getdate())= month(strdateofbirth) and day(getdate())=day(strdateofbirth)";
            }
            else if (searchbybirthday.SelectedValue == "This Month")
            {
                strsql = strsql + " and month(getdate())= month(strdateofbirth)";
            }
            else if (searchbybirthday.SelectedValue == "This Week")
            {
                strsql = strsql + " and day(getdate()+5)>= day(strdateofbirth) and month(getdate())=month(strdateofbirth) and year(getdate())=year(strdateofbirth)";
            }
        }

        if (searchbyblood.SelectedIndex > 0)
            strsql = strsql + " and strbloodgroup= '" + searchbyblood.SelectedValue + "'";

        if (searchbyhouse.SelectedIndex > 0)
            strsql = strsql + " and strhouse= '" + searchbyhouse.SelectedValue + "'";

        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (md == 1)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgstudetails.DataSource = ds;
                dgstudetails.DataBind();
                dgstudetails.Visible = true;
                trmsg.Visible = false;
                //menu00.Visible = true;
            }
            else
            {
                dgstudetails.Visible = false;
                trmsg.Visible = true;
                lblmsg.Text = "No records found for the selected search criteria";
                //menu00.Visible = false;
            }

            if (ds.Tables[0].Rows.Count > 1)
                trtag.Visible = true;
            else
                trtag.Visible = false;
        }
        else
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgstudetails.DataSource = ds;
                dgstudetails.DataBind();
                dgstudetails.Visible = true;
                trmsg.Visible = false;
                //menu00.Visible = true;
            }
            else
            {
                dgstudetails.Visible = false;
                trmsg.Visible = true;
                lblmsg.Text = "No records found for the selected search criteria";
                //menu00.Visible = false;
            }
        }
    }

    protected void fillsearch()
    {
        fillbirthday();
        fillhousename();
        fillreligion();
        clearindv();
    }

    protected void btnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        ImageButton btnview = new ImageButton();
        btnview = (ImageButton)item.FindControl("btnview");
        DataGridItem dgi = dgstudetails.Items[index];
        Response.Redirect("view_studentdetails.aspx?StudentID=" + dgi.Cells[0].Text + "&sbackto=0");
    }

    //protected void btnsendmsg_Click(object sender, EventArgs e)
    //{
    //    int j = 0;
    //    for (int i = 0; i < dgstudetails.Items.Count; i++)
    //    {
    //        DataGridItem dgi = dgstudetails.Items[i];
    //        CheckBox chkselect = (CheckBox)dgi.FindControl("chkselect");
    //        if (chkselect.Checked)
    //        {
    //            j = i + 1;
    //            da = new DataAccess();
    //            string str = "select strmobile from tblstudent where intid=" + dgi.Cells[0].Text;
    //            ds = new DataSet();
    //            ds = da.ExceuteSql(str);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                string strUrl = "http://sms1.mmsworld.in/pushsms.php";
    //                Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
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

    //    for (int i = 0; i < dgstudetails.Items.Count; i++)
    //    {
    //        int j = i + 1;
    //        DataGridItem dgimail = dgstudetails.Items[i];
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
    //        command.Parameters.Add("@strpatrontype", "Student");
    //        command.Parameters.Add("@strsenderpatrontype", Session["PatronType"].ToString());
    //        command.Parameters.Add("@dtdate", dtdate);
    //        command.ExecuteNonQuery();
    //        conn.Close();
    //        da = new DataAccess();
    //        strsql = "select strparentsemailid from tblstudent where intid in(" + str + ")";
    //        ds = new DataSet();
    //        ds = da.ExceuteSql(strsql);
    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            Functions.Sendmail(ds.Tables[0].Rows[j]["strparentsemailid"].ToString(), "support@theschools.in", txtsubject.Text, txtmail.Content);
    //        }
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Mail Sent Successfully')", true);
    //        txtsubject.Text = "";
    //        txtmail.Content = "";
    //    }
    //}
    protected void txtname_TextChanged(object sender, EventArgs e)
    {
        txtadmissionno.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = -1;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = -1;
        search(2);
    }
    protected void txtadmissionno_TextChanged(object sender, EventArgs e)
    {
        txtname.Text = "";
        searchbygender.SelectedIndex = 0;
        searchbytransport.SelectedIndex = 0;
        searchbyhostler.SelectedIndex = 0;
        searchbyreligion.SelectedIndex = 0;
        searchbybirthday.SelectedIndex = 0;
        searchbyblood.SelectedIndex = 0;
        searchbyhouse.SelectedIndex = 0;
        search(2);
    }
}

