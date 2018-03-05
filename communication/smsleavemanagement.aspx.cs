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

public partial class communication_smsleavemanagement : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        lblkeywords.Text = "";
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 13";
        if (ddlleavestatus.SelectedIndex > 0)
        {
            trkeywords.Visible = true;
            if (ddlleavestatus.SelectedValue == "1")
            {
                sql += " and strpatrontype='Approved'";
            }
            else if (ddlleavestatus.SelectedValue == "2")
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
        strsql = "";
        lblconditionquery.Text = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        if (txtfromdtdate.Text != "")
        {
            dgleavemngt.Visible = true;
            Hiddenerror.Text = "";
            trsendbutton.Visible = true;
            strsql = "select intid,intstaff,convert(varchar(10),dtdateofrequest,103) as dtdateofrequest from tblleaverequest where intschool=" + Session["SchoolID"] + " and intapproved = " + ddlleavestatus.SelectedValue + " and dtdateofrequest=convert(datetime,'" + txtfromdtdate.Text + "',103)";
            lblconditionquery.Text = strsql;
            ds = da.ExceuteSql(strsql);
            dgleavemngt.DataSource = ds;
            dgleavemngt.DataBind();
            if (dgleavemngt.Items.Count <= 0)
            {
                dgleavemngt.Visible = false;
                Hiddenerror.Text = "There is no data to display";
                trsendbutton.Visible = false;
            }
        }
    }
    protected void dtdate_TextChanged(object sender, EventArgs e)
    {
        if (ddlleavestatus.SelectedIndex > 0)
        {
            if (txtfromdtdate.Text != "")
            {
                fillgrid();
            }
        }
    }
    protected void ddlleavestatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlleavestatus.SelectedIndex > 0)
        {
            fillsmstemplate();
            fillsmskeyword();
            if (txtfromdtdate.Text != "")
            {
                fillgrid();
            }
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
        }
    }
    protected void dgleavemngtchkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkselectall = sender as CheckBox;
        foreach (DataGridItem gvs in dgleavemngt.Items)
        {
            CheckBox chkselect = gvs.FindControl("dgleavemngtcheckbox") as CheckBox;
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
        strsql = "select strtemplatename,strmessage from tblsmstemplate where intcategoryid=13 and strpatrontype = '" + ddlleavestatus.SelectedItem.Text + "' and intschool=" + Session["SchoolID"];
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
        if (ddlleavestatus.SelectedIndex > 0 && txtfromdtdate.Text != "")
        {
            if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
            {
                if (txtnewsmsheader.Text != "")
                {
                    SqlCommand cmd;
                    SqlParameter outputparam;
                    conn.Open();
                    cmd = new SqlCommand("spsmstemplate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    outputparam = cmd.Parameters.Add("@rc", SqlDbType.Int);
                    outputparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@intid", "0");
                    cmd.Parameters.Add("@intcategoryid", "13");
                    cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    cmd.Parameters.Add("@strmessage", txtmessage.Text);
                    cmd.Parameters.Add("@strpatrontype", ddlleavestatus.SelectedItem.Text);
                    cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                DataAccess dakeyword = new DataAccess();
                DataSet dskeyword = new DataSet();
                strsql = "select strkeyword,strcolumnname from tblsmskeyword where intsmscategoryid = 13 and strpatrontype ='"+ddlleavestatus.SelectedItem.Text+"'";
                dskeyword = dakeyword.ExceuteSql(strsql);
                string receiverids = "";
                if (dgleavemngt.Items.Count > 0)
                {
                    for(int i = 0;i<dgleavemngt.Items.Count;i++)
                    {
                        DataGridItem dgi = dgleavemngt.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgleavemngtcheckbox");
                        if (ch.Checked == true)
                        {
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            if (ddlleavestatus.SelectedItem.Text == "Approved")
                            {
                                strsql = "select distinct a.*,'Approved' as leavestatus,b.strfirstname as staffname,c.strleavetype as leavetype from tblleaverequest a,tblemployee b,tblschoolleavecategory c,tblstaffleaves d where a.intstaff = b.intid and c.intid=d.intleavetype and a.intID=d.intleaverequest and a.intid =" + dgi.Cells[1].Text;
                            }
                            if (ddlleavestatus.SelectedItem.Text == "Rejected")
                            {
                                strsql = "select distinct a.*,'Rejected' as leavestatus,b.strfirstname as staffname,c.strleavetype as leavetype from tblleaverequest a,tblemployee b,tblschoolleavecategory c,tblstaffleaves d where a.intstaff = b.intid and c.intid=d.intleavetype and a.intID=d.intleaverequest and a.intid =" + dgi.Cells[1].Text;
                            }
                            ds = da.ExceuteSql(strsql);
                            string message = txtmessage.Text;
                            for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                            {
                                message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), ds.Tables[0].Rows[0][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
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
        if (ddlleavestatus.SelectedIndex > 0 && txtfromdtdate.Text != "")
        {
            if (rdnewmsg.Checked == true && txtnewsmsheader.Text != "" || rdPremsg.Checked == true && ddlpredefinedmsg.SelectedIndex > 0)
            {
                if (txtnewsmsheader.Text != "")
                {
                    SqlCommand cmd;
                    SqlParameter outputparam;
                    conn.Open();
                    cmd = new SqlCommand("spsmstemplate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    outputparam = cmd.Parameters.Add("@rc", SqlDbType.Int);
                    outputparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@intid", "0");
                    cmd.Parameters.Add("@intcategoryid", "13");
                    cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    cmd.Parameters.Add("@strmessage", txtmessage.Text);
                    cmd.Parameters.Add("@strpatrontype", ddlleavestatus.SelectedItem.Text);
                    cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                string receiverids = "";
                if (dgleavemngt.Items.Count > 0)
                {
                    for (int i = 0; i < dgleavemngt.Items.Count; i++)
                    {
                        DataGridItem dgi = dgleavemngt.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgleavemngtcheckbox");
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
                }
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
}