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

public partial class communication_smsbirthday : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        lblkeywords.Text = "";
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 14";
        if (ddlpatrontype.SelectedIndex > 0)
        {
            trkeywords.Visible = true;
            if (ddlpatrontype.SelectedValue == "Student")
            {
                sql += " and strpatrontype='Student'";
            }
            if (ddlpatrontype.SelectedIndex > 2)
            {
                sql += " and strpatrontype='Staff'";
            }
            if (ddlpatrontype.SelectedValue == "All")
            {
                sql += " group by strdescription,strkeyword HAVING(COUNT(strkeyword) > 1 ) ";
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
    //to select multiple standard and section
    protected void fillstandard()
    {
        string str = "select strstandard+' - '+strsection as Classandsec from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strstandard,strsection";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "Classandsec";
        ddlstandard.DataValueField = "Classandsec";
        ddlstandard.DataBind();
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        lblconditionquery.Text = "";
        if (ddlpatrontype.SelectedValue == "Student")
        {
            if (txtfromdtdate.Text != "")
            {
                dgbirthday.Visible = true;
                Hiddenerror.Text = "";
                trsendbutton.Visible = true;
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as classanddept,convert(varchar(10), strdateofbirth,103) as dtdateofbirth,strgender from tblstudent where intschool=" + Session["SchoolID"] + " and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
                lblconditionquery.Text = strsql;
                ds = da.ExceuteSql(strsql);
                dgbirthday.DataSource = ds;
                dgbirthday.DataBind();
                if (dgbirthday.Items.Count <= 0)
                {
                    dgbirthday.Visible = false;
                    Hiddenerror.Text = "There is no data to display";
                    trsendbutton.Visible = false;
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            if (txtfromdtdate.Text != "")
            {
                dgbirthday.Visible = true;
                Hiddenerror.Text = "";
                trsendbutton.Visible = true;
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strGender as strgender,convert(varchar(14),dtDOB,103)as dtdateofbirth from tblemployee where intschool=" + Session["SchoolID"] + " and strtype='" + ddlpatrontype.SelectedValue + "'and month(dtDOB) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(dtDOB) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
                lblconditionquery.Text = strsql;
                ds = da.ExceuteSql(strsql);
                dgbirthday.DataSource = ds;
                dgbirthday.DataBind();
                if (dgbirthday.Items.Count <= 0)
                {
                    dgbirthday.Visible = false;
                    Hiddenerror.Text = "There is no data to display";
                    trsendbutton.Visible = false;
                }
            }
        }
        if (ddlpatrontype.SelectedIndex == 1)
        {
            patronallstud.Text = "";
            patrongallstaff.Text = "";
            Hiddenerror.Text = "";
            trpatronall.Visible = true;
            DataAccess dastu = new DataAccess();
            DataSet dsstu = new DataSet();
            strsql = "select * from tblstudent where intschool='" + Session["SchoolID"] + "' and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
            dsstu = dastu.ExceuteSql(strsql);
            if (dsstu.Tables[0].Rows.Count > 0)
            {
                patronallstud.Text = dsstu.Tables[0].Rows.Count.ToString() + "Students";
                trsendbutton.Visible = true;
            }
            DataAccess dastu1 = new DataAccess();
            DataSet dsstu1 = new DataSet();
            strsql = "select * from tblemployee where intschool='" + Session["SchoolID"] + "' and month(dtDOB) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(dtDOB) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
            dsstu1 = dastu1.ExceuteSql(strsql);
            if (dsstu1.Tables[0].Rows.Count > 0)
            {
                patrongallstaff.Text = dsstu1.Tables[0].Rows.Count.ToString() + "Staffs";
                trsendbutton.Visible = true;
            }
            if (dsstu.Tables[0].Rows.Count <= 0 && dsstu1.Tables[0].Rows.Count <= 0)
            {
                Hiddenerror.Text = "There is no data to display";
                trsendbutton.Visible = false;
            }
            dgbirthday.Visible = false;
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
        }
        if (rdPremsg.Checked == true)
        {
            fillsmstemplate();
            trpredefined.Visible = true;
            trnewsms.Visible = false;
        }
    }
    protected void dgbirthdaychkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkselectall = sender as CheckBox;
        foreach (DataGridItem gvs in dgbirthday.Items)
        {
            CheckBox chkselect = gvs.FindControl("dgbirthdaychkbox") as CheckBox;
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
        strsql = "select intid, strtemplatename,strmessage from tblsmstemplate where intcategoryid=14 and intschool=" + Session["SchoolID"];
        if (ddlpatrontype.SelectedValue == "Student")
        {
            strsql += " and strpatrontype='Student'";
        }
        if (ddlpatrontype.SelectedIndex > 2)
        {
            strsql += " and strpatrontype='Staff'";
        }
        if (ddlpatrontype.SelectedValue == "All")
        {
            strsql = "and strpatrontype='All'";
        }
        ds = da.ExceuteSql(strsql);
        ddlpredefinedmsg.DataSource = ds;
        ddlpredefinedmsg.DataTextField = "strtemplatename";
        ddlpredefinedmsg.DataValueField = "intid";
        ddlpredefinedmsg.DataBind();
        ddlpredefinedmsg.Items.Insert(0, "-Select-");
    }
    protected void dgpresms_EditCommand(object source, DataGridCommandEventArgs e)
    {
        txtmessage.Text = "";
        txtmessage.Text = e.Item.Cells[1].Text;
    }
    protected void btnsend_Click1(object sender, EventArgs e)
    {
        string name = "";
        for (int i = 0; i < ddlstandard.Items.Count; i++)
        {
            if (ddlstandard.Items[i].Selected)
            {
                name += ddlstandard.Items[i].Text + ", ";
            }
        }
        txtclass.Text = name;
        fillgrid();
    }
    protected void ddlpatrontype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            fillsmskeyword();
            fillsmstemplate();
            fillstandard();
            trmulticlass.Visible = true;
            dgbirthday.Visible = false;
            trsendbutton.Visible = false;
            fillgrid();
        }
        else if (ddlpatrontype.SelectedValue == "All")
        {
            fillsmskeyword();
            dgbirthday.Visible = false;
            trmulticlass.Visible = false;
            trsendbutton.Visible = false;
            dgbirthday.Visible = false;
        }
        else if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            fillsmstemplate();
            fillsmskeyword();
            txtclass.Text = "";
            chkAll.Checked = false;
            ddlstandard.Items.Clear();
            fillgrid();
            trmulticlass.Visible = false;
        }
        else
        {
            trkeywords.Visible = false;
            txtclass.Text = "";
            chkAll.Checked = false;
            ddlstandard.Items.Clear();
            dgbirthday.Visible = false;
            trmulticlass.Visible = false;
        }
    }
    protected void dtdate_TextChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedIndex > 0)
        {
            if (txtfromdtdate.Text != "")
            {
                fillgrid();
            }
        }
    }
    protected void sendlater_Click(object sender, EventArgs e)
    {
        trdelaydate.Visible = true;
    }
    protected void ddlpredefinedmsg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpredefinedmsg.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=14 and intid=" + ddlpredefinedmsg.SelectedValue + " and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(strsql);
            txtmessage.Text = ds.Tables[0].Rows[0]["strmessage"].ToString();
        }
    }
    protected void Sendsms_Click(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            if (txtclass.Text != "")
            {
                if (dgbirthday.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "14");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Student");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        DataAccess dakeyword = new DataAccess();
                        DataSet dskeyword = new DataSet();
                        strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 14 and strpatrontype = 'Student'";
                        dskeyword = dakeyword.ExceuteSql(strsql);
                        string receiverids = "";
                        for (int i = 0; i < dgbirthday.Items.Count; i++)
                        {
                            DataGridItem dgi = dgbirthday.Items[i];
                            CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgbirthdaychkbox");
                            if (ch.Checked == true)
                            {
                                strsql = "";
                                DataAccess dastud = new DataAccess();
                                DataSet dsstud = new DataSet();
                                strsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intid=" + dgi.Cells[1].Text;
                                dsstud = dastud.ExceuteSql(strsql);
                                string message = txtmessage.Text;
                                for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                                {
                                    message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables[0].Rows[0][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                                }
                                //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                                receiverids = receiverids + dgi.Cells[1].Text + ",";
                            }
                        }
                        DataAccess dasent = new DataAccess();
                        DataSet dssent = new DataSet();
                        string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                        sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                        sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Student'," + Session["SchoolID"] + ")";
                        dssent = dasent.ExceuteSql(sqlsent);
                        Response.Redirect("smsbirthday.aspx");
                    }
                    else
                    {
                        msgbox.alert("SMS Header is Empty");
                    }
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            if (dgbirthday.Items.Count > 0)
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
                        command.Parameters.Add("@intcategoryid", "14");
                        command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        command.Parameters.Add("@strmessage", txtmessage.Text);
                        command.Parameters.Add("@strpatrontype", "Staff");
                        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    DataAccess dakeyword = new DataAccess();
                    DataSet dskeyword = new DataSet();
                    strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 14 and strpatrontype = 'Staff'";
                    dskeyword = dakeyword.ExceuteSql(strsql);
                    string receiverids = "";
                    for (int i = 0; i < dgbirthday.Items.Count; i++)
                    {
                        DataGridItem dgi = dgbirthday.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgbirthdaychkbox");
                        if (ch.Checked == true)
                        {
                            strsql = "";
                            DataAccess dastud = new DataAccess();
                            DataSet dsstud = new DataSet();
                            strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as staffname,* from tblemployee where intid=" + dgi.Cells[1].Text;
                            dsstud = dastud.ExceuteSql(strsql);
                            string message = txtmessage.Text;
                            for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                            {
                                message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables[0].Rows[0][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                            }
                            //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                            //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                            receiverids = receiverids + dgi.Cells[1].Text + ",";
                        }
                    }
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                    sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Staff'," + Session["SchoolID"] + ")";
                    dssent = dasent.ExceuteSql(sqlsent);
                    Response.Redirect("smsbirthday.aspx");
                }
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
        if (ddlpatrontype.SelectedValue == "All")
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
                    command.Parameters.Add("@intcategoryid", "14");
                    command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    command.Parameters.Add("@strmessage", txtmessage.Text);
                    command.Parameters.Add("@strpatrontype", "All");
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                DataAccess dakeyword = new DataAccess();
                DataSet dskeyword = new DataSet();
                strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 14 group by strkeyword,strtablename,strcolumnname HAVING(COUNT(strkeyword) > 1)";
                dskeyword = dakeyword.ExceuteSql(strsql);
                DataAccess dastud = new DataAccess();
                DataSet dsstud = new DataSet();
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as classanddept,convert(varchar(10), strdateofbirth,103) as dtdateofbirth,strgender from tblstudent where intschool=" + Session["SchoolID"] + " and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
                dsstud = dastud.ExceuteSql(strsql);
                string message = txtmessage.Text;
                for (int i = 0; i < dsstud.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                    {
                        message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables[0].Rows[i][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                    }
                    //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                    //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + dsstud.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                }
                DataAccess dastaff = new DataAccess();
                DataSet dsstaff = new DataSet();
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as classanddept,convert(varchar(10), strdateofbirth,103) as dtdateofbirth,strgender from tblstudent where intschool=" + Session["SchoolID"] + " and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
                dsstaff = dastaff.ExceuteSql(strsql);
                for (int i = 0; i < dsstaff.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                    {
                        message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstaff.Tables[0].Rows[i][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                    }
                    //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                    //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + dsstaff.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                }
                Response.Redirect("smsbirthday.aspx");
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
    protected void submitdelay_Click(object sender, EventArgs e)
    {
        conditionquery = lblconditionquery.Text.Replace("'", "''");
        if (ddlpatrontype.SelectedValue == "Student")
        {
            if (txtclass.Text != "")
            {
                if (dgbirthday.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "14");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Student");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        string receiverids = "";
                        for (int i = 0; i < dgbirthday.Items.Count; i++)
                        {
                            DataGridItem dgi = dgbirthday.Items[i];
                            CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgbirthdaychkbox");
                            if (ch.Checked == true)
                            {
                                receiverids = receiverids + dgi.Cells[1].Text + ",";
                            }
                        }
                        DataAccess dasent = new DataAccess();
                        DataSet dssent = new DataSet();
                        string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                        sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                        sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','Student'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                        dssent = dasent.ExceuteSql(sqlsent);
                        Response.Redirect("smsbirthday.aspx");
                    }
                    else
                    {
                        msgbox.alert("SMS Header is Empty");
                    }
                }

            }
        }
        if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            if (dgbirthday.Items.Count > 0)
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
                        command.Parameters.Add("@intcategoryid", "14");
                        command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        command.Parameters.Add("@strmessage", txtmessage.Text);
                        command.Parameters.Add("@strpatrontype", "Staff");
                        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    string receiverids = "";
                    for (int i = 0; i < dgbirthday.Items.Count; i++)
                    {
                        DataGridItem dgi = dgbirthday.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgbirthdaychkbox");
                        if (ch.Checked == true)
                        {
                            receiverids = receiverids + dgi.Cells[1].Text + ",";
                        }
                    }
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                    sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','Staff'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                    dssent = dasent.ExceuteSql(sqlsent);
                    Response.Redirect("smsbirthday.aspx");
                }
                else
                {
                    msgbox.alert("SMS Header is Empty");
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "All")
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
                    command.Parameters.Add("@intcategoryid", "14");
                    command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    command.Parameters.Add("@strmessage", txtmessage.Text);
                    command.Parameters.Add("@strpatrontype", "All");
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                DataAccess dasent = new DataAccess();
                DataSet dssent = new DataSet();
                string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'All',";
                sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','All'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                dssent = dasent.ExceuteSql(sqlsent);
                Response.Redirect("smsbirthday.aspx");
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
}