using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class communication_smsgeneral : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string returnvalue;
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
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid =5";
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
                sql += " group by strdescription,strkeyword HAVING(COUNT(strkeyword)>1)";
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
            if (txtclass.Text != "")
            {
                dggeneral.Visible = true;
                Hiddenerror.Text = "";
                trsendbutton.Visible = true;
                strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as classanddept, strgender,* from tblstudent where intschool=" + Session["SchoolID"] + " and strstandard+' - '+strsection in('" + txtclass.Text.Replace(", ", "','") + "')";
                lblconditionquery.Text = strsql;
                ds = da.ExceuteSql(strsql);
                dggeneral.DataSource = ds;
                dggeneral.Columns[3].HeaderText = "Standard & Sec";
                dggeneral.DataBind();
                if (dggeneral.Items.Count <= 0)
                {
                    dggeneral.Visible = false;
                    Hiddenerror.Text = "There is no data to display";
                    trsendbutton.Visible = false;
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            dggeneral.Visible = true;
            Hiddenerror.Text = "";
            trsendbutton.Visible = true;
            strsql = "select a.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as name,a.intDepartment,b.strdepartmentname as classanddept, a.strGender as strgender,a.* from tblemployee a,tbldepartment b where a.intschool=" + Session["SchoolID"] + " and a.strtype='" + ddlpatrontype.SelectedValue + "' and b.intid=a.intDepartment";
            lblconditionquery.Text = strsql;
            ds = da.ExceuteSql(strsql);
            dggeneral.DataSource = ds;
            dggeneral.Columns[3].HeaderText = "Department";
            dggeneral.DataBind();
            if (dggeneral.Items.Count <= 0)
            {
                dggeneral.Visible = false;
                Hiddenerror.Text = "There is no data to display";
                trsendbutton.Visible = false;
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
        }
        if (rdPremsg.Checked == true)
        {
            fillsmstemplate();
            trpredefined.Visible = true;
            trnewsms.Visible = false;
        }
    }
    protected void dggeneralchkselectall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkselectall = sender as CheckBox;
        foreach (DataGridItem gvs in dggeneral.Items)
        {
            CheckBox chkselect = gvs.FindControl("dggeneralchkselect") as CheckBox;
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
        strsql = "select intid, strtemplatename,strmessage from tblsmstemplate where intcategoryid=5 and intschool=" + Session["SchoolID"];
        if (ddlpatrontype.SelectedValue == "Student")
        {
            strsql += " and strpatrontype='Student'";
        }
        if (ddlpatrontype.SelectedIndex > 2)
        {
            strsql += " and strpatrontype='Staff'";
        }
        if (ddlpatrontype.SelectedIndex <= 1)
        {
            strsql = "select intid, strtemplatename,strmessage from tblsmstemplate where intcategoryid=0 and intschool=" + Session["SchoolID"];
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
            dggeneral.Visible = false;
            trsendbutton.Visible = false;
            fillgrid();
        }
        else if (ddlpatrontype.SelectedValue == "All")
        {
            fillsmskeyword();
            fillsmstemplate();
            dggeneral.Visible = false;
            trmulticlass.Visible = false;
            trsendbutton.Visible = true;
            dggeneral.Visible = false;
        }
        else if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            fillsmskeyword();
            fillsmstemplate();
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
            dggeneral.Visible = false;
            trmulticlass.Visible = false;
        }
    }
    protected void ddlpredefinedmsg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpredefinedmsg.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=5 and intid=" + ddlpredefinedmsg.SelectedValue + " and intschool=" + Session["SchoolID"];
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
        if (ddlpatrontype.SelectedValue == "Student")
        {
            if (txtclass.Text != "")
            {
                if (dggeneral.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "5");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Student");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            returnvalue = (command.Parameters["@rc"].Value).ToString();
                            conn.Close();
                        }
                        DataAccess dakeyword = new DataAccess();
                        DataSet dskeyword = new DataSet();
                        strsql = "select strkeyword,strcolumnname from tblsmskeyword where intsmscategoryid = 5 and strpatrontype = 'Student'";
                        dskeyword = dakeyword.ExceuteSql(strsql);
                        string receiverids = "";
                        for (int i = 0; i < dggeneral.Items.Count; i++)
                        {
                            DataGridItem dgi = dggeneral.Items[i];
                            CheckBox ch = (CheckBox)dgi.Cells[1].FindControl("dggeneralchkselect");
                            if (ch.Checked == true)
                            {
                                strsql = "";
                                DataAccess dastud = new DataAccess();
                                DataSet dsstud = new DataSet();
                                strsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intid=" + dgi.Cells[0].Text;
                                dsstud = dastud.ExceuteSql(strsql);
                                string message = txtmessage.Text;
                                for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                                {
                                    message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables[0].Rows[0][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                                }
                                //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                                receiverids = receiverids + dgi.Cells[0].Text + ",";
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
                    msgbox.alert("SMS Heading is Empty");
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Teaching Staffs" ||ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            if (dggeneral.Items.Count > 0)
            {
                DataAccess dakeyword = new DataAccess();
                DataSet dskeyword = new DataSet();
                strsql = "select strkeyword,strcolumnname from tblsmskeyword where intsmscategoryid = 5 and strpatrontype = 'Staff'";
                dskeyword = dakeyword.ExceuteSql(strsql);
                string receiverids = "";
                for (int i = 0; i < dggeneral.Items.Count; i++)
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
                            command.Parameters.Add("@intcategoryid", "5");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Staff");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            returnvalue = (command.Parameters["@rc"].Value).ToString();
                            conn.Close();
                        }
                        DataGridItem dgi = dggeneral.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[1].FindControl("dggeneralchkselect");
                        if (ch.Checked == true)
                        {
                            strsql = "";
                            DataAccess dastud = new DataAccess();
                            DataSet dsstud = new DataSet();
                            strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as staffname,* from tblemployee where intid=" + dgi.Cells[0].Text;
                            dsstud = dastud.ExceuteSql(strsql);
                            string message = txtmessage.Text;
                            for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                            {
                                message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables[0].Rows[0][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                            }
                            //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                            //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                            receiverids = receiverids + dgi.Cells[0].Text + ",";
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
                    command.Parameters.Add("@intcategoryid", "5");
                    command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    command.Parameters.Add("@strmessage", txtmessage.Text);
                    command.Parameters.Add("@strpatrontype", "All");
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                DataAccess dakeyword = new DataAccess();
                DataSet dskeyword = new DataSet();
                strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 5 group by strkeyword,strtablename,strcolumnname HAVING(COUNT(strkeyword) > 1)";
                dskeyword = dakeyword.ExceuteSql(strsql);

                strsql = "";
                DataSet dsstud = new DataSet();
                strsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intschool=" + Session["SchoolID"];
                SqlDataAdapter sda = new SqlDataAdapter(strsql, conn);
                sda.Fill(dsstud, "tblstudent");
                strsql = "select strfirstname+' '+strmiddlename+' '+strlastname as staffname,* from tblemployee where intschool=" + Session["SchoolID"];
                SqlDataAdapter sdastaff = new SqlDataAdapter(strsql, conn);
                sdastaff.Fill(dsstud, "tblemployee");
                string message = txtmessage.Text;
                for (int i = 0; i < dsstud.Tables["tblstudent"].Rows.Count; i++)
                {
                    for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                    {
                        message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables["tblstudent"].Rows[i][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                    }
                    //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                    //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + dsstud.Tables["tblstudent"].Rows[i]["strmobile"].ToString() + "&message=" + message + "&priority=1");
                }
                for (int i = 0; i < dsstud.Tables["tblemployee"].Rows.Count; i++)
                {
                    for (int j = 0; j < dskeyword.Tables[0].Rows.Count; j++)
                    {
                        message = message.Replace(dskeyword.Tables[0].Rows[j]["strkeyword"].ToString(), dsstud.Tables["tblemployee"].Rows[i][dskeyword.Tables[0].Rows[j]["strcolumnname"].ToString()].ToString());
                    }
                    //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                    //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + dsstud.Tables["tblemployee"].Rows[i]["strmobile"].ToString() + "&message=" + message + "&priority=1");
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
        if (ddlpatrontype.SelectedValue == "Student")
        {
            if (txtclass.Text != "")
            {
                if (dggeneral.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "5");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Student");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            returnvalue = (command.Parameters["@rc"].Value).ToString();
                            conn.Close();
                        }
                        string receiverids = "";
                        for (int i = 0; i < dggeneral.Items.Count; i++)
                        {
                            DataGridItem dgi = dggeneral.Items[i];
                            CheckBox ch = (CheckBox)dgi.Cells[1].FindControl("dggeneralchkselect");
                            if (ch.Checked == true)
                            {
                                receiverids = receiverids + dgi.Cells[0].Text + ",";
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
                    msgbox.alert("SMS Heading is Empty");
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Teaching Staffs" || ddlpatrontype.SelectedValue == "Non Teaching Staffs" || ddlpatrontype.SelectedValue == "Others")
        {
            if (dggeneral.Items.Count > 0)
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
                        command.Parameters.Add("@intcategoryid", "5");
                        command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        command.Parameters.Add("@strmessage", txtmessage.Text);
                        command.Parameters.Add("@strpatrontype", "Staff");
                        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        command.ExecuteNonQuery();
                        returnvalue = (command.Parameters["@rc"].Value).ToString();
                        conn.Close();
                    }
                    string receiverids = "";
                    for (int i = 0; i < dggeneral.Items.Count; i++)
                    {
                        DataGridItem dgi = dggeneral.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[1].FindControl("dggeneralchkselect");
                        if (ch.Checked == true)
                        {
                            receiverids = receiverids + dgi.Cells[0].Text + ",";
                        }
                    }
                    conditionquery = lblconditionquery.Text.Replace("'", "''");
                    DataAccess dasent = new DataAccess();
                    DataSet dssent = new DataSet();
                    string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate";
                    sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                    sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','Staff'," + Session["SchoolID"] + ",'" + conditionquery + "')";
                    dssent = dasent.ExceuteSql(sqlsent);
                }
            }
            else
            {
                msgbox.alert("SMS Heading is Empty");
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
                    command.Parameters.Add("@intcategoryid", "5");
                    command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    command.Parameters.Add("@strmessage", txtmessage.Text);
                    command.Parameters.Add("@strpatrontype", "");
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.ExecuteNonQuery();
                    returnvalue = (command.Parameters["@rc"].Value).ToString();
                    conn.Close();
                }
                DataAccess dasent = new DataAccess();
                DataSet dssent = new DataSet();
                string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate";
                sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'All',";
                sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'" + txtDelaydate.Text + "',103),'0','All'," + Session["SchoolID"] + ")";
                dssent = dasent.ExceuteSql(sqlsent);
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
}