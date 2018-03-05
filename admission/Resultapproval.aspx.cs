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

public partial class admission_resultapproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            standard();
            fillstudent();
            filldetails();
            date();
            dgadmissionresult.Visible = false;
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select intadmissionapprove from tblstudentadmission where intschool=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            for (int i = 0; i < dgadmissionresult.Items.Count; i++)
            {
                DataGridItem dgi = dgadmissionresult.Items[i];
                Button btnapprove = (Button)dgi.FindControl("app");
                Button btnreject = (Button)dgi.FindControl("rej");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[i]["intadmissionapprove"].ToString()) == 1)
                    {
                        btnapprove.Text = "Approved";
                        btnapprove.Enabled = false;
                        btnreject.Enabled = false;
                    }
                    else
                    {
                        btnapprove.Text = "Approve";
                    }

                    if (int.Parse(ds.Tables[0].Rows[i]["intadmissionapprove"].ToString()) == 2)
                    {
                        btnreject.Text = "Rejected";
                        btnapprove.Enabled = false;
                        btnreject.Enabled = false;
                    }
                    else
                    {
                        btnreject.Text = "Reject";
                    }


                }
            }
           
        }
            
    }
    protected void standard()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionattendance where dtdate='" + ddldate.SelectedValue + "' and  intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
            ddlstandard.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionattendance where dtdate='" + ddldate.SelectedValue + "' and  intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
            ddlstandard.Items.Insert(1, "-All-");
        }
    }
    protected void date()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
    }
    protected void fillstudent()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select b.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name from tbladmissionattendance a,tblstudentadmission b where b.intapprove=1 and a.intapplication=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlstudent.DataTextField = "name";
            ddlstudent.DataValueField = "intid";
            ddlstudent.DataSource = ds;
            ddlstudent.DataBind();
            ddlstudent.Items.Insert(0, "-Select-");
            ddlstudent.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name from tbladmissionattendance a,tblstudentadmission b where b.intwaitlist=1 and a.intapplication=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlstudent.DataTextField = "name";
            ddlstudent.DataValueField = "name";
            ddlstudent.DataSource = ds;
            ddlstudent.DataBind();
            ddlstudent.Items.Insert(0, "-Select-");
            ddlstudent.Items.Insert(1, "-All-");
        }
    }
    //protected void fillresult()
    //{
    //    if (ddllist.SelectedValue == "1")
    //    {
    //        DataAccess da = new DataAccess();
    //        DataSet ds = new DataSet();
    //        string str = "select strresult from tbladmissionstudentmarks where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strresult";
    //        ds = da.ExceuteSql(str);
    //        ddlresult.DataTextField = "strresult";
    //        ddlresult.DataValueField = "strresult";
    //        ddlresult.DataSource = ds;
    //        ddlresult.DataBind();
    //        ddlresult.Items.Insert(0, "-Select-");
    //        ddlresult.Items.Insert(1, "-All-");
    //    }
    //    if (ddllist.SelectedValue == "2")
    //    {
    //        DataAccess da = new DataAccess();
    //        DataSet ds = new DataSet();
    //        string str = "select strresult from tbladmissionstudentmarks where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strresult";
    //        ds = da.ExceuteSql(str);
    //        ddlresult.DataTextField = "strresult";
    //        ddlresult.DataValueField = "strresult";
    //        ddlresult.DataSource = ds;
    //        ddlresult.DataBind();
    //        ddlresult.Items.Insert(0, "-Select-");
    //        ddlresult.Items.Insert(1, "-All-");
    //    }
    //}
    protected void filldetails()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name,a.intapplication,a.strstandard,a.strresult from tbladmissionstudentmarks a,tblstudentadmission b where b.intapprove=1 and intapprove_waitlist=" + ddllist.SelectedValue + " and a.intapplication=b.intid and b.str_standard=a.strstandard and a.strstandard='"+ddlstandard.SelectedValue+"' and a.intschool=" + Session["SchoolID"].ToString();
            str = str + " union all select b.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name,b.intid as intapplication,a.strstandard,'Fail' as strresult from tbladmissionstudentmarks a,tblstudentadmission b where b.intid not in(select intapplication from tbladmissionstudentmarks) and b.intapprove=1 and b.str_standard=a.strstandard and a.intschool=" + Session["SchoolID"].ToString();
            if (ddlstandard.SelectedIndex > 1)
            {
                str = str + " and a.strstandard='" + ddlstandard.SelectedValue + "'";
            }
            if (ddlstandard.SelectedValue == "-All-")
            {
                str = str + " and a.strstandard !=''";
            }
            if (ddlresult.SelectedIndex > 0)
            {
               str = str + " and a.strresult='" + ddlresult.SelectedValue + "'";
            }
            if (ddlresult.SelectedValue == "-All-")
            {
                str = str + " and a.strresult !=''";
            }
            if (ddlstudent.SelectedIndex > 1)
            {
                str = str + " and b.intid=" + ddlstudent.SelectedValue + "";
            }
            if (ddlstudent.SelectedValue == "-All-")
            {
                str = str + " and b.intid  !=''";
            }
            str = str + " group by b.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname,a.strstandard";
            ds = da.ExceuteSql(str);
            dgadmissionresult.DataSource = ds;
            dgadmissionresult.DataBind();
            str = "select intadmissionapprove from tblstudentadmission where intschool=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            for (int i = 0; i < dgadmissionresult.Items.Count; i++)
            {
                DataGridItem dgi = dgadmissionresult.Items[i];
                Button btnapprove = (Button)dgi.FindControl("app");
                Button btnreject = (Button)dgi.FindControl("rej");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[i]["intadmissionapprove"].ToString()) == 1)
                    {
                        btnapprove.Text = "Approved";
                        btnapprove.Enabled = false;
                        btnreject.Enabled = false;
                    }
                    else
                    {
                        btnapprove.Text = "Approve";
                    }

                    if (int.Parse(ds.Tables[0].Rows[i]["intadmissionapprove"].ToString()) == 2)
                    {
                        btnreject.Text = "Rejected";
                        btnapprove.Enabled = false;
                        btnreject.Enabled = false;
                    }
                    else
                    {
                        btnreject.Text = "Reject";
                    }


                }
            }
        }

        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name,a.intapplication,a.strstandard,a.strresult from tbladmissionstudentmarks a,tblstudentadmission b where b.intwaitlist=1 and intapprove_waitlist=" + ddllist.SelectedValue + " and a.intapplication=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            str = str + "union all select b.intid,b.str_firstname+' '+b.str_middlename+' '+b.str_lastname as name,b.intid as intapplication,a.strstandard,'Fail' as strresult from tbladmissionstudentmarks a,tblstudentadmission b where b.intid not in(select intapplication from tbladmissionstudentmarks) and b.intwaitlist=1 and b.str_standard=a.strstandard and a.intschool=" + Session["SchoolID"].ToString();
            if (ddlstandard.SelectedIndex > 1)
            {
                str = str + " and strstandard='" + ddlstandard.SelectedValue + "'";
            }
            if (ddlstandard.SelectedValue == "-All-")
            {
                str = str + " and strstandard !=''";
            }
            if (ddlresult.SelectedIndex > 1)
            {
                str = str + " and strresult='" + ddlresult.SelectedValue + "'";
            }
            if (ddlresult.SelectedValue == "-All-")
            {
                str = str + " and strresult !=''";
            }
            if (ddlstudent.SelectedIndex > 1)
            {
                str = str + " and b.intid=" + ddlstudent.SelectedValue + "";
            }
            if (ddlstudent.SelectedValue == "-All-")
            {
                str = str + " and b.intid  !=''";
            }
            ds = da.ExceuteSql(str);
            dgadmissionresult.DataSource = ds;
            dgadmissionresult.DataBind();
           
            str = "select intadmissionapprove from tblstudentadmission where intschool=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            for (int i = 0; i < dgadmissionresult.Items.Count; i++)
            {
                DataGridItem dgi = dgadmissionresult.Items[i];
                Button btnapprove = (Button)dgi.FindControl("app");
                Button btnreject = (Button)dgi.FindControl("rej");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[i]["intadmissionapprove"].ToString()) == 1)
                    {
                        btnapprove.Text = "Approved";
                        btnapprove.Enabled = false;
                        btnreject.Enabled = false;
                    }
                    else
                    {
                        btnapprove.Text = "Approve";
                    }

                    if (int.Parse(ds.Tables[0].Rows[i]["intadmissionapprove"].ToString()) == 2)
                    {
                        btnreject.Text = "Rejected";
                        btnapprove.Enabled = false;
                        btnreject.Enabled = false;
                    }
                    else
                    {
                        btnreject.Text = "Reject";
                    }


                }
            }
        }
       
    }
    protected void dgadmissionresult_EditCommand(object source, DataGridCommandEventArgs e)
    {
       
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "update tblstudentadmission set intadmissionapprove=1,intadmissionapprovedby=" + Session["UserID"].ToString() + " where intapprove=1 and intid=" + e.Item.Cells[0].Text;
            ds = da.ExceuteSql(str);
            //str = "select a.strstandard,convert(varchar(10),a.dtjoiningdate,103)as dtjoiningdate,a.intamount,a.intyear from tbladmissionfeedetails a,tbladmissionstudentmarks b where a.strstandard=b.strstandard and a.intid=b.intid and  b.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intschool=" + Session["SchoolID"].ToString();
            str = "select a.strstandard,b.intyear,b.str_firstname+''+str_middlename+''+str_lastname as name from tbladmissionstudentmarks a,tblstudentadmission b where a.strstandard=b.str_standard and a.intapplication=b.intid and  b.intadmissionapprove=1 and a.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count < 0)
            {
               msgbox1.alert("The Fees details not allocated for this standard");
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //str = "select a.intid,a.str_mobile,a.str_emailid,+'Joining Date:'+convert(varchar(10),c.dtjoiningdate,103)+',Standard:'+c.strstandard+',Amount Details Per Year:'+c.intamount as Message from tblstudentadmission a,tbladmissionstudentmarks b,tbladmissionfeedetails c  where a.intadmissionapprove=1 and a.intid=b.intapplication and  a.str_standard=b.strstandard  and b.strstandard=c.strstandard and b.intid=" + e.Item.Cells[0].Text + " and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and c.intschool=" + Session["SchoolID"].ToString();
                    str = "select a.intid,a.str_mobile,a.str_emailid,a.str_standard as Message from tblstudentadmission a,tbladmissionstudentmarks b  where a.intadmissionapprove=1 and a.intid=b.intapplication and  a.str_standard=b.strstandard and b.intid=" + e.Item.Cells[0].Text + " and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                        Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["str_mobile"].ToString() + "&message= 'Your have been selected and Your registered number is:=" + ds.Tables[0].Rows[0]["Message"].ToString() + "' &priority=1");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Message is send Successfully!')", true);
                    }

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    MailMessage msg = new MailMessage();
                    //    msg.To = ds.Tables[0].Rows[0]["str_emailid"].ToString();
                    //    msg.From = "info@theschools.in";
                    //    msg.Subject = "Request for Demo";
                    //    msg.BodyFormat = MailFormat.Html;
                    //    msg.Body = "<html><head></head><body><table cellpadding='5' cellspacing='0' border='0' style='font-family:Trebuchet MS;color:#666666;border:silver solid thin;' align='center'><tr bgcolor='#A3C608' style='color:#FFFFFF;font-size:16px;' align='center'><td colspan='2'><p style='margin:0px;'>Requested for Demo</p></td></tr><tr ><td>Interview Date :" + txtdate.Text + "</td><tr><td> Interview Time : " + txttime.Text + "</td><td> Contact Person : " + txtcontact.Text + "</td><tr><td> Place : " + txtplace.Text + "</td><td> Remarks: " + txtremarks.Text + "</td><td></td></tr></table>";

                    //    SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SmtpServerName"];
                    //    SmtpMail.Send(msg);
                    //}
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Email is send Successfully!')", true);
                }
                filldetails();
            }
       
        
    }
    protected void dgadmissionresult_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
       
        
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "update tblstudentadmission set intadmissionapprove=2,intadmissionapprovedby=" + Session["UserID"].ToString() + " where intapprove=1 and intid=" + e.Item.Cells[0].Text;
            ds = da.ExceuteSql(str);
            str = "select a.str_mobile,a.str_emailid from tblstudentadmission a,tbladmissionstudentmarks b where a.intid=b.intapplication and a.intadmissionapprove=2 and b.intid=" + e.Item.Cells[0].Text + " and b.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["str_mobile"].ToString() + "&message= Your Application is Rejected  &priority=1");
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Message is send Successfully!')", true);
            filldetails();
       
       
    }
    protected void dgadmissionresult_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("view_admission_result.aspx?lid=" + e.Item.Cells[0].Text);
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fillresult();
        filldetails();
        dgadmissionresult.Visible = true;
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
        dgadmissionresult.Visible = true;
    }
    protected void ddlresult_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
        dgadmissionresult.Visible = true;
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        date();
        dgadmissionresult.Visible = false;
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
        fillstudent();
        dgadmissionresult.Visible = false;
    }

    
}
