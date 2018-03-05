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

public partial class communication_smstransfercertificate : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlpredefinedmsg.Items.Insert(0,"-Select-");
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        lblkeywords.Text = "";
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 7";
        if (ddltcstatus.SelectedIndex > 0)
        {
            trkeywords.Visible = true;
            if (ddltcstatus.SelectedValue == "1")
            {
                sql += " and strpatrontype='Approved'";
            }
            else if (ddltcstatus.SelectedValue == "2")
            {
                sql += " and strpatrontype='Rejected'";
            }
        }
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblkeywords.Text += ds.Tables[0].Rows[i]["strdescription"].ToString() + " : <font class='sms_keywords'>" + ds.Tables[0].Rows[i]["strkeyword"].ToString() + "</font>, ";
            }
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        lblconditionquery.Text = "";
        dgtc.Visible = true;
        Hiddenerror.Text = "";
        trsendbutton.Visible = true;
        strsql = "select convert(varchar(10),a.dt_dateOf_requestOfwithdrawal,103) as dt_dateOf_requestOfwithdrawal,a.*, b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,b.strstandard+' - '+strsection as class from tblstudentwithdrawal a,tblstudent b where a.intschool=" + Session["SchoolID"] + " and a.int_studentid=b.intid and intapprove=" + ddltcstatus.SelectedValue;
        lblconditionquery.Text = strsql;
        ds = da.ExceuteSql(strsql);
        dgtc.DataSource = ds;
        dgtc.DataBind();
        if (dgtc.Items.Count <= 0)
        {
            dgtc.Visible = false;
            Hiddenerror.Text = "There is no data to display";
            trsendbutton.Visible = false;
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
            txtmessage.Text = "";
            trnewsms.Visible = true;
            ddlpredefinedmsg.SelectedIndex = 0;
        }
        if (rdPremsg.Checked == true)
        {
            trpredefined.Visible = true;
            trnewsms.Visible = false;
            txtnewsmsheader.Text = "";
        }
    }
    protected void fillsmstemplate()
    {
        ddlpredefinedmsg.Items.Clear();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select strtemplatename,strmessage from tblsmstemplate where intcategoryid=7 and intschool=" + Session["SchoolID"];
        if (ddltcstatus.SelectedIndex > 0)
        {
            if (ddltcstatus.SelectedIndex == 1)
            {
                strsql += " and strpatrontype='Approved'";
            }
            if (ddltcstatus.SelectedIndex == 2)
            {
                strsql += " and strpatrontype='Rejected'";
            }
        }
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
    protected void dgtcchkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkselectall = sender as CheckBox;
        foreach (DataGridItem gvs in dgtc.Items)
        {
            CheckBox chkselect = gvs.FindControl("dgtcchkselect") as CheckBox;
            if (chkselect != null)
            {
                chkselect.Checked = chkselectall.Checked;
            }
        }
    }
    protected void ddltcstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltcstatus.SelectedIndex > 0)
        {
            fillsmstemplate();
            fillsmskeyword();
            fillgrid();
        }
        if (ddltcstatus.SelectedIndex == 0)
        {
            trkeywords.Visible = false;
            dgtc.Visible = false;
            trsendbutton.Visible = false;
        }
    }
    protected void Sendsms_Click(object sender, EventArgs e)
    {
        if (ddltcstatus.SelectedIndex > 0)
        {
            if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
            {
                if (txtnewsmsheader.Text != "")
                {
                    SqlCommand command;
                    SqlParameter OutPutParam;
                    conn.Open();
                    command = new SqlCommand("spsmstemplate", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
                    OutPutParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add("@intid", "0");
                    command.Parameters.Add("@intcategoryid", "7");
                    command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    command.Parameters.Add("@strmessage", txtmessage.Text);
                    if (ddltcstatus.SelectedValue == "1")
                        command.Parameters.Add("@strpatrontype", "Approved");
                    else
                        command.Parameters.Add("@strpatrontype", "Rejected");
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                if (dgtc.Items.Count > 0)
                {
                    DataAccess keyda = new DataAccess();
                    DataSet keyds = new DataSet();
                    if (ddltcstatus.SelectedValue == "1")
                        strsql = "select * from tblsmskeyword where intsmscategoryid = 7 and strpatrontype='Approved'";
                    else
                        strsql = "select * from tblsmskeyword where intsmscategoryid = 7 and strpatrontype='Rejected'";
                    keyds = keyda.ExceuteSql(strsql);
                    string receiverids = "";
                    for (int i = 0; i < dgtc.Items.Count; i++)
                    {
                        DataGridItem dgi = dgtc.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgtcchkselect");
                        if (ch.Checked == true)
                        {
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            if (ddltcstatus.SelectedValue == "1")
                                strsql = "select 'Approved' as status,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname,b.strstandard+'-'+strsection as class ,a.* from tblstudentwithdrawal a,tblstudent b where a.intid=' " + dgi.Cells[1].Text + "' and a.intid=b.intid";
                            else
                                strsql = "select 'Rejected' as status,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname,b.strstandard+'-'+strsection as class ,a.* from tblstudentwithdrawal a,tblstudent b where a.intid=' " + dgi.Cells[1].Text + "' and a.intid=b.intid";
                            ds = da.ExceuteSql(strsql);
                            string message = txtmessage.Text;
                            for (int j = 0; j < keyds.Tables[0].Rows.Count; j++)
                            {
                                message = message.Replace(keyds.Tables[0].Rows[j]["strkeyword"].ToString(), ds.Tables[0].Rows[0][keyds.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                            }
                            receiverids = receiverids + ds.Tables[0].Rows[i]["int_studentid"].ToString() + ",";
                        }
                    }
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                    sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Student'," + Session["SchoolID"] + ")";
                    dssent = dasent.ExceuteSql(sqlsent);
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
        if (ddltcstatus.SelectedIndex > 0)
        {
            if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
            {
                if (txtnewsmsheader.Text != "")
                {
                    SqlCommand command;
                    SqlParameter OutPutParam;
                    conn.Open();
                    command = new SqlCommand("spsmstemplate", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
                    OutPutParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add("@intid", "0");
                    command.Parameters.Add("@intcategoryid", "7");
                    command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    command.Parameters.Add("@strmessage", txtmessage.Text);
                    if (ddltcstatus.SelectedValue == "1")
                        command.Parameters.Add("@strpatrontype", "Approved");
                    else
                        command.Parameters.Add("@strpatrontype", "Rejected");
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                if (dgtc.Items.Count > 0)
                {
                    string receiverids = "";
                    for (int i = 0; i < dgtc.Items.Count; i++)
                    {
                        DataGridItem dgi = dgtc.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgtcchkselect");
                        if (ch.Checked == true)
                        {
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            if (ddltcstatus.SelectedValue == "1")
                                strsql = "select 'Approved' as status,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname,b.strstandard+'-'+strsection as class ,a.* from tblstudentwithdrawal a,tblstudent b where a.intid=' " + dgi.Cells[1].Text + "' and a.intid=b.intid";
                            else
                                strsql = "select 'Rejected' as status,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname,b.strstandard+'-'+strsection as class ,a.* from tblstudentwithdrawal a,tblstudent b where a.intid=' " + dgi.Cells[1].Text + "' and a.intid=b.intid";
                            ds = da.ExceuteSql(strsql);
                            receiverids = receiverids + ds.Tables[0].Rows[i]["int_studentid"].ToString() + ",";
                        }
                    }
                    conditionquery = lblconditionquery.Text.Replace("'", "''");
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                    sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','Student'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                    dssent = dasent.ExceuteSql(sqlsent);
                }
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
}
