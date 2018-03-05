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

public partial class communication_smsstaffsubstitute : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillsmskeyword();
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 18";
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
    protected void dtdate_TextChanged(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "")
        {
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        dgstaffsubstitute.Visible = true;
        Hiddenerror.Text = "";
        trsendbutton.Visible = true;
        strsql = "select b.strfirstname+' '+strmiddlename+' '+strlastname as staffname, a.strclass as class, a.* from tblsubstitutetimetable a, tblemployee b where a.intschool = " + Session["SchoolID"] + " and b.intID=a.intstaff and a.dtdate=convert(datetime,'" + txtfromdtdate.Text + "',103)";
        ds = da.ExceuteSql(strsql);
        dgstaffsubstitute.DataSource = ds;
        dgstaffsubstitute.DataBind();
        if (dgstaffsubstitute.Items.Count <= 0)
        {
            dgstaffsubstitute.Visible = false;
            Hiddenerror.Text = "There is no data to display";
            trsendbutton.Visible = false;
        }
    }
    protected void dgchkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = sender as CheckBox;
        foreach (DataGridItem gvr in dgstaffsubstitute.Items)
        {
            CheckBox chkSelect = gvr.FindControl("dgchkselect") as CheckBox;
            if (chkSelect != null)
            {
                chkSelect.Checked = chkSelectAll.Checked;
            }
        }
    }
    protected void rdPremsg_CheckedChanged(object sender, EventArgs e)
    {
        hidetrpredefined();
        txtnewsmsheader.Text = "";
        txtmessage.Text = "";
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
    protected void fillsmstemplate()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intid,strtemplatename,strmessage from tblsmstemplate where intcategoryid=18 and intschool=" + Session["SchoolID"];
        ds = da.ExceuteSql(strsql);
        ddlpredefinedmsg.DataSource = ds;
        ddlpredefinedmsg.DataTextField = "strtemplatename";
        ddlpredefinedmsg.DataValueField = "intid";
        ddlpredefinedmsg.DataBind();
        ddlpredefinedmsg.Items.Insert(0, "-Select-");
    }
    protected void ddlpredefinedmsg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpredefinedmsg.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=18 and intid=" + ddlpredefinedmsg.SelectedValue + " and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(strsql);
            txtmessage.Text = ds.Tables[0].Rows[0]["strmessage"].ToString();
        }
    }
    protected void sendlater_Click(object sender, EventArgs e)
    {
        trdelaydate.Visible = true;
    }
    protected void Sendsms_Click(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "")
        {
            if (dgstaffsubstitute.Items.Count > 0)
            {
                if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
                {
                    if (txtnewsmsheader.Text != "")
                    {
                        SqlCommand cmd;
                        SqlParameter outputparm;
                        conn.Open();
                        cmd = new SqlCommand("spsmstemplate", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        outputparm = cmd.Parameters.Add("@rc", SqlDbType.Int);
                        outputparm.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@intid", "0");
                        cmd.Parameters.Add("@intcategoryid", "18");
                        cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        cmd.Parameters.Add("@strmessage", txtmessage.Text);
                        cmd.Parameters.Add("@strpatrontype", "");
                        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    DataAccess dakeyword = new DataAccess();
                    DataSet dskeyword = new DataSet();
                    strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 18";
                    dskeyword = dakeyword.ExceuteSql(strsql);
                    string receiverids = "";
                    for (int i = 0; i < dgstaffsubstitute.Items.Count; i++)
                    {
                        DataSet ds = new DataSet();
                        DataGridItem dgi = dgstaffsubstitute.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgchkselect");
                        if (ch.Checked == true)
                        {
                            string colsql = "select b.strfirstname+' '+strmiddlename+' '+strlastname as staffname, a.strclass as class, a.* from tblsubstitutetimetable a, tblemployee b where a.intschool = " + Session["SchoolID"] + " and b.intID=a.intstaff and a.intid=" + dgi.Cells[1].Text;
                            SqlDataAdapter da1 = new SqlDataAdapter(colsql, conn);
                            da1.Fill(ds, "tblsubstitutetimetable");
                            string message = txtmessage.Text;
                            for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                            {
                                message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), ds.Tables[dskeyword.Tables[0].Rows[j]["strtablename"].ToString()].Rows[0][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                            }
                            //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                            //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                            receiverids = receiverids + dgi.Cells[2].Text + ",";
                        }
                    }
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                    sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Staff'," + Session["SchoolID"] + ")";
                    dssent = dasent.ExceuteSql(sqlsent);
                    Response.Redirect("smsstaffsubstitute.aspx");
                }
                else
                {
                    msgbox.alert("SMS Header is Empty");
                }
            }
        }
    }
    protected void submitdelay_Click(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "")
        {
            conditionquery = lblconditionquery.Text.Replace("'", "''");
            if (dgstaffsubstitute.Items.Count > 0)
            {
                if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
                {
                    if (txtnewsmsheader.Text != "")
                    {
                        SqlCommand cmd;
                        SqlParameter outputparm;
                        conn.Open();
                        cmd = new SqlCommand("spsmstemplate", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        outputparm = cmd.Parameters.Add("@rc", SqlDbType.Int);
                        outputparm.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@intid", "0");
                        cmd.Parameters.Add("@intcategoryid", "18");
                        cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        cmd.Parameters.Add("@strmessage", txtmessage.Text);
                        cmd.Parameters.Add("@strpatrontype", "");
                        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    string receiverids = "";
                    for (int i = 0; i < dgstaffsubstitute.Items.Count; i++)
                    {
                        DataSet ds = new DataSet();
                        DataGridItem dgi = dgstaffsubstitute.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgchkselect");
                        if (ch.Checked == true)
                        {
                            receiverids = receiverids + dgi.Cells[2].Text + ",";
                        }
                    }
                    conditionquery = lblconditionquery.Text.Replace("'", "''");
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                    sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','Staff'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                    dssent = dasent.ExceuteSql(sqlsent);
                    Response.Redirect("smsdiscipline.aspx");
                }
                else
                {
                    msgbox.alert("SMS Header is Empty");
                }
            }
        }
    }
}
