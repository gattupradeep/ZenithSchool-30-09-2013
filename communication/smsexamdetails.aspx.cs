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

public partial class communication_smsexamdetails : System.Web.UI.Page
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
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 3";
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
        dgexamdetails.Visible = true;
        Hiddenerror.Text = "";
        trsendbutton.Visible = true;
        strsql = "select convert(varchar(10),dtexamdate,103) as dtexamdate, * from tblexamschedule where intschool='" + Session["SchoolID"].ToString() + "' and strclass='" + ddlstandardsingle.SelectedValue.Replace(" - ", " ") + "' and strexamtype='" + ddlexamtype.SelectedValue + "' ";
        lblconditionquery.Text = strsql;
        ds = da.ExceuteSql(strsql);
        dgexamdetails.DataSource = ds;
        dgexamdetails.DataBind();
        if (dgexamdetails.Items.Count <= 0)
        {
            dgexamdetails.Visible = false;
            trsendbutton.Visible = false;
            Hiddenerror.Text = "There is no data to display";
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
        strsql = "select intid,strtemplatename,strmessage from tblsmstemplate where intcategoryid=3 and intschool=" + Session["SchoolID"];
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
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=3 and intid=" + ddlpredefinedmsg.SelectedValue + " and intschool=" + Session["SchoolID"];
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
        if (ddlstandardsingle.SelectedIndex> 0)
        {
            if (ddlexamtype.SelectedIndex > 0)
            {
                conditionquery = lblconditionquery.Text.Replace("'", "''");
                if (dgexamdetails.Items.Count > 0)
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
                            cmd.Parameters.Add("@intcategoryid", "3");
                            cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            cmd.Parameters.Add("@strmessage", txtmessage.Text);
                            cmd.Parameters.Add("@strpatrontype", "");
                            cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        DataSet ds = new DataSet();
                        strsql = "";
                        strsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intschool=" + Session["SchoolID"] + " and strstandard+' - '+strsection ='" + ddlstandardsingle.SelectedValue + "'";
                        SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                        da.Fill(ds, "tblstudent");
                        if (ds.Tables["tblstudent"].Rows.Count > 0)
                        {
                            DataAccess dakey = new DataAccess();
                            DataSet dskey = new DataSet();
                            string sql = "select strdescription,strkeyword,strcolumnname,strtablename from tblsmskeyword where intsmscategoryid =3";
                            dskey = dakey.ExceuteSql(sql);
                            string receiverids = "";
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                for (int j = 0; j < dgexamdetails.Items.Count; j++)
                                {
                                    DataGridItem dgh = dgexamdetails.Items[j];
                                    string colsql = "select * from tblexamschedule where intid=" + dgh.Cells[0].Text;
                                    SqlDataAdapter da1 = new SqlDataAdapter(colsql, conn);
                                    da1.Fill(ds, "tblexamschedule");
                                    string message = txtmessage.Text;
                                    if (dskey.Tables[0].Rows.Count > 0)
                                    {
                                        for (int z = 0; z < dskey.Tables[0].Rows.Count; z++)
                                        {
                                            if (dskey.Tables[0].Rows[z]["strtablename"].ToString() == "tblexamschedule")
                                                message = message.Replace(dskey.Tables[0].Rows[z]["strkeyword"].ToString(), ds.Tables[dskey.Tables[0].Rows[z]["strtablename"].ToString()].Rows[j][dskey.Tables[0].Rows[z]["strcolumnname"].ToString()].ToString());
                                            else
                                                message = message.Replace(dskey.Tables[0].Rows[z]["strkeyword"].ToString(), ds.Tables[dskey.Tables[0].Rows[z]["strtablename"].ToString()].Rows[i][dskey.Tables[0].Rows[z]["strcolumnname"].ToString()].ToString());
                                        }
                                    }
                                    //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                    //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables["tblstudent"].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                                }
                                receiverids = receiverids + ds.Tables["tblstudent"].Rows[i]["intid"].ToString() + ",";
                            }
                            DataAccess dasent = new DataAccess();
                            DataSet dssent = new DataSet();
                            string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                            sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                            sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Student'," + Session["SchoolID"] + ")";
                            dssent = dasent.ExceuteSql(sqlsent);
                        }
                        ds.Clear();
                    }
                    else
                    {
                        msgbox.alert("SMS Header is Empty");
                    }
                }
            }
        }
    }
    protected void submitdelay_Click(object sender, EventArgs e)
    {
        if (ddlstandardsingle.SelectedIndex > 0)
        {
            if (ddlexamtype.SelectedIndex > 0)
            {
                conditionquery = lblconditionquery.Text.Replace("'", "''");
                if (dgexamdetails.Items.Count > 0)
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
                            cmd.Parameters.Add("@intcategoryid", "3");
                            cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            cmd.Parameters.Add("@strmessage", txtmessage.Text);
                            cmd.Parameters.Add("@strpatrontype", "");
                            cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        DataSet ds = new DataSet();
                        string receiverids = "";
                        strsql = "";
                        strsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intschool=" + Session["SchoolID"] + " and strstandard+' - '+strsection ='" + ddlstandardsingle.SelectedValue + "'";
                        SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                        da.Fill(ds, "tblstudent");
                        if (ds.Tables["tblstudent"].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                receiverids = receiverids + ds.Tables["tblstudent"].Rows[i]["intid"].ToString() + ",";
                            }
                        }
                        DataAccess dasent = new DataAccess();
                        DataSet dssent = new DataSet();
                        string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                        sqlsent += " intqueueid,dtdelaydate,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                        sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0','0',convert(datetime,'" + txtDelaydate.Text + "',103),'Student'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                        dssent = dasent.ExceuteSql(sqlsent);
                    }
                    else
                    {
                        msgbox.alert("SMS Header is Empty");
                    }
                }
            }
        }
    }      
}

