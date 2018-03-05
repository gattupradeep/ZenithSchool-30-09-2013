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

public partial class communication_smsreportcard : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillexamtype();
            fillsmskeyword();
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 4";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblkeywords.Text += ds.Tables[0].Rows[i]["strdescription"].ToString() + " : <font class='sms_keywords'>" + ds.Tables[0].Rows[i]["strkeyword"].ToString() + "</font>, ";
            }
        }
    }
    //to select multiple standard and section
    protected void fillstandard()
    {
        ddlstandardsingle.Items.Clear();
        string str = "select strstandard+' - '+strsection as Classandsec from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strstandard,strsection";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandardsingle.DataSource = ds;
        ddlstandardsingle.DataTextField = "Classandsec";
        ddlstandardsingle.DataValueField = "Classandsec";
        ddlstandardsingle.DataBind();
        ddlstandardsingle.Items.Insert(0, "-Select-");
    }
    protected void fillexamtype()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select strexamtype from tblschoolexamtypes where intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0, "-Select-");
    }
    protected void ddlstandardsingle_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlstandardsingle.SelectedIndex > 0 && ddlexamtype.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandardsingle.SelectedIndex > 0 && ddlexamtype.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        lblconditionquery.Text = "";
        dgreportcard.Visible = true;
        Hiddenerror.Text = "";
        trsendbutton.Visible = true;
        strsql = "select a.intid as reportcarid,a.intstudent,a.strstandard+' - '+a.strsection as class,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname from tblreportcard a,tblstudent b where a.strstandard+' - '+a.strsection ='" + ddlstandardsingle.SelectedValue + "' and a.strexamtype='" + ddlexamtype.SelectedValue + "' and a.intstudent=b.intid";
        lblconditionquery.Text = strsql;
        ds = da.ExceuteSql(strsql);
        dgreportcard.DataSource = ds;
        dgreportcard.DataBind();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            dgreportcard.Visible = false;
            trsendbutton.Visible = false;
            Hiddenerror.Text = "There is no data to display";
        }
    }
    protected void rdPremsg_CheckedChanged(object sender, EventArgs e)
    {
        hidetrpredefined();
    }
    protected void rdnewmsg_CheckedChanged(object sender, EventArgs e)
    {
        hidetrpredefined();
    }
    protected void hidetrpredefined()
    {
        if (rdnewmsg.Checked == true)
        {
            trpredefined.Visible = false;
            trnewsms.Visible = true;
            txtmessage.Text = "";
            ddlpredefinedmsg.SelectedIndex = 0;
        }
        if (rdPremsg.Checked == true)
        {
            fillsmstemplate();
            trpredefined.Visible = true;
            trnewsms.Visible = false;
            txtnewsmsheader.Text = "";
        }
    }
    protected void dgreportcardchkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkselectall = sender as CheckBox;
        foreach (DataGridItem gvs in dgreportcard.Items)
        {
            CheckBox chkselect = gvs.FindControl("dgreporcardchkselect") as CheckBox;
            if (chkselect != null)
            {
                chkselect.Checked = chkselectall.Checked;
            }
        }
    }
    protected void fillsmstemplate()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select strtemplatename,strmessage from tblsmstemplate where intcategoryid=4 and intschool=" + Session["SchoolID"];
        ds = da.ExceuteSql(strsql);
        ddlpredefinedmsg.DataSource = ds;
        ddlpredefinedmsg.DataTextField = "strtemplatename";
        ddlpredefinedmsg.DataValueField = "strmessage";
        ddlpredefinedmsg.DataBind();
        ddlpredefinedmsg.Items.Insert(0, "-Select-");
    }
    protected void ddlpredefinedmsg_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtmessage.Text = ddlpredefinedmsg.SelectedValue;
    }
    protected void sendlater_Click(object sender, EventArgs e)
    {
        trdelaydate.Visible = true;
    }
    protected void Sendsms_Click(object sender, EventArgs e)
    {
        if (ddlstandardsingle.SelectedIndex > 0 && ddlexamtype.SelectedIndex > 0)
        {
            if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
            {
                if (txtnewsmsheader.Text != "")
                {
                    SqlCommand cmd;
                    SqlParameter ouptparm;
                    conn.Open();
                    cmd = new SqlCommand("spsmstemplate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    ouptparm = cmd.Parameters.Add("@rc", SqlDbType.Int);
                    ouptparm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@intid", "0");
                    cmd.Parameters.Add("@intcategoryid", "4");
                    cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    cmd.Parameters.Add("@strmessage", txtmessage.Text);
                    cmd.Parameters.Add("@strpatrontype", "");
                    cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                DataAccess dakey = new DataAccess();
                DataSet dskey = new DataSet();
                string sql = "select strdescription,strkeyword,strcolumnname,strtablename from tblsmskeyword where intsmscategoryid =4";
                dskey = dakey.ExceuteSql(sql);
                if (dgreportcard.Items.Count > 0)
                {
                    string receiverids = "";
                    for (int i = 0; i < dgreportcard.Items.Count; i++)
                    {
                        DataGridItem dgi = dgreportcard.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgreporcardchkselect");
                        if (ch.Checked == true)
                        {
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            strsql = "select a.intid as reportcarid,a.intstudent,a.strexamtype,a.strstandard+' - '+a.strsection as class,'' as  paperandmarks, '' as totalmarks,'' as averagemark, b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname from tblreportcard a,tblstudent b where a.strstandard+' - '+a.strsection ='" + ddlstandardsingle.SelectedValue + "'and a.intschool=" + Session["SchoolID"] + " and a.strexamtype='" + ddlexamtype.SelectedValue + "' and a.intstudent=b.intid and a.intid=" + dgi.Cells[1].Text;
                            ds = da.ExceuteSql(strsql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataAccess damarks = new DataAccess();
                                DataSet dsmarks = new DataSet();
                                strsql = "select strexampaper+' - '+convert(varchar(10),intscoredmarks) as paperandmarks from tblstudentscoredmarks where intreportcard =" + ds.Tables[0].Rows[0]["reportcarid"];
                                dsmarks = damarks.ExceuteSql(strsql);
                                if (dsmarks.Tables[0].Rows.Count > 0)
                                {
                                    string subjectandmarks = "";
                                    for (int j = 0; j < dsmarks.Tables[0].Rows.Count; j++)
                                    {
                                        subjectandmarks = subjectandmarks + dsmarks.Tables[0].Rows[j]["paperandmarks"].ToString() + ',';
                                    }
                                    DataAccess datotal = new DataAccess();
                                    DataSet dstotal = new DataSet();
                                    strsql = "select SUM(intscoredmarks) as totalmarks ,AVG(intscoredmarks) as avgmarks from(select strexampaper+' - '+convert(varchar(10),intscoredmarks) as paperandmarks,intscoredmarks from tblstudentscoredmarks where intreportcard ="+dgi.Cells[1].Text+") as a";
                                    dstotal = datotal.ExceuteSql(strsql);
                                    ds.Tables[0].Rows[0]["paperandmarks"] = subjectandmarks;
                                    ds.Tables[0].Rows[0]["totalmarks"] = dstotal.Tables[0].Rows[0]["totalmarks"];
                                    ds.Tables[0].Rows[0]["averagemark"] = dstotal.Tables[0].Rows[0]["avgmarks"];
                                }
                                string message = txtmessage.Text;
                                for (int k = 0; k < dskey.Tables[0].Rows.Count; k++)
                                {
                                    message = message.Replace(dskey.Tables[0].Rows[k]["strkeyword"].ToString(), ds.Tables[0].Rows[0][dskey.Tables[0].Rows[k]["strcolumnname"].ToString()].ToString());
                                }
                                //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                                receiverids = receiverids + ds.Tables[0].Rows[0]["intstudent"] + ',';
                            }
                        }
                    }
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                    sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Student'," + Session["SchoolID"] + ")";
                    dssent = dasent.ExceuteSql(sqlsent);
                    Response.Redirect("smsreportcard.aspx");
                }
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
    protected void submitdelay_Click(object sender, EventArgs e)
    {
        if (ddlstandardsingle.SelectedIndex > 0 && ddlexamtype.SelectedIndex > 0)
        {
            if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
            {
                if (txtnewsmsheader.Text != "")
                {
                    SqlCommand cmd;
                    SqlParameter ouptparm;
                    conn.Open();
                    cmd = new SqlCommand("spsmstemplate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    ouptparm = cmd.Parameters.Add("@rc", SqlDbType.Int);
                    ouptparm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@intid", "0");
                    cmd.Parameters.Add("@intcategoryid", "4");
                    cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    cmd.Parameters.Add("@strmessage", txtmessage.Text);
                    cmd.Parameters.Add("@strpatrontype", "");
                    cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (dgreportcard.Items.Count > 0)
                {
                    string receiverids = "";
                    for (int i = 0; i < dgreportcard.Items.Count; i++)
                    {
                        DataGridItem dgi = dgreportcard.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgreporcardchkselect");
                        if (ch.Checked == true)
                        {
                            receiverids = receiverids + dgi.Cells[2].Text + ',';
                        }
                    }
                    conditionquery = lblconditionquery.Text.Replace("'", "''");
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                    sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','Student'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                    dssent = dasent.ExceuteSql(sqlsent);
                    Response.Redirect("smsreportcard.aspx");
                }
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
}

