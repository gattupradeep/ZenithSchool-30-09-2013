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

public partial class communication_smstransport : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillroutename();
            ddlbusnumber.Items.Insert(0,"-Select-");
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        lblkeywords.Text = "";
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 10";
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
    protected void fillroutename()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select * from tblroute where intschool = "+Session["SchoolID"];
        ds = da.ExceuteSql(strsql);
        ddlroutename.DataSource = ds;
        ddlroutename.DataTextField = "strroutename";
        ddlroutename.DataValueField = "intid";
        ddlroutename.DataBind();
        ddlroutename.Items.Insert(0, "-Select-");
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        lblconditionquery.Text = "";
        if (ddlpatrontype.SelectedValue == "Student")
        {
            if (ddlroutename.SelectedIndex > 0)
            {
                dgtransport.Visible = true;
                Hiddenerror.Text = "";
                trsendbutton.Visible = true;
                strsql = "select a.intid,a.strstandard+' - '+a.strsection as class,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as studentname,b.strdestination,b.intstudentid,c.strvehicleno from";
                strsql += " tblstudent a,tblbusbooking b ,tblvehiclemaster c,tblroute d";
                strsql += " where a.intschool="+Session["SchoolID"]+" and a.intid=b.intstudentid and b.intschool="+Session["SchoolID"]+" and b.introuteid=d.intid and b.introuteid ="+ddlroutename.SelectedValue;
                lblconditionquery.Text = strsql;
                ds = da.ExceuteSql(strsql);
                dgtransport.DataSource = ds;
                dgtransport.DataBind();
                if (dgtransport.Items.Count <= 0)
                {
                    dgtransport.Visible = false;
                    Hiddenerror.Text = "There is no data to display";
                    trsendbutton.Visible = false;
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Staff")
        {
            if (ddlroutename.SelectedIndex > 0)
            {
                dgtransport.Visible = true;
                Hiddenerror.Text = "";
                trsendbutton.Visible = true;
                
                lblconditionquery.Text = strsql;
                ds = da.ExceuteSql(strsql);
                dgtransport.DataSource = ds;
                dgtransport.DataBind();
                if (dgtransport.Items.Count <= 0)
                {
                    dgtransport.Visible = false;
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
            //strsql = "select * from tblstudent where intschool='" + Session["SchoolID"] + "' and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
            dsstu = dastu.ExceuteSql(strsql);
            if (dsstu.Tables[0].Rows.Count > 0)
            {
                patronallstud.Text = dsstu.Tables[0].Rows.Count.ToString() + "Students";
                trsendbutton.Visible = true;
            }
            DataAccess dastu1 = new DataAccess();
            DataSet dsstu1 = new DataSet();
            //strsql = "select * from tblemployee where intschool='" + Session["SchoolID"] + "' and month(dtDOB) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(dtDOB) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
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
            dgtransport.Visible = false;
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
    protected void fillsmstemplate()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intid, strtemplatename,strmessage from tblsmstemplate where intcategoryid=10 and intschool=" + Session["SchoolID"];
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
    protected void ddlpatrontype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            fillsmskeyword();
            fillsmstemplate();
            dgtransport.Visible = false;
            trsendbutton.Visible = false;
            fillgrid();
        }
        else if (ddlpatrontype.SelectedValue == "All")
        {
            fillsmskeyword();
            dgtransport.Visible = false;
            trsendbutton.Visible = false;
        }
        else if (ddlpatrontype.SelectedValue == "Staff")
        {
            fillsmstemplate();
            fillsmskeyword();
            fillgrid();
            
        }
        else
        {
            trkeywords.Visible = false;
        }
    }
    protected void sendlater_Click(object sender, EventArgs e)
    {
        trdelaydate.Visible = true;
    }
    protected void ddlroutename_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedIndex > 0 && ddlroutename.SelectedIndex > 0)
        {
            ddlbusnumber.Items.Clear();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select a.*,b.strvehicleno from tblroute a, tblvehiclemaster b where a.intschool=" + Session["SchoolID"] + " and a.intvehicle=b.intid and b.intschool=" + Session["SchoolID"] + " and a.intid="+ddlroutename.SelectedValue;
            ds = da.ExceuteSql(strsql);
            ddlbusnumber.DataSource = ds;
            ddlbusnumber.DataTextField = "strvehicleno";
            ddlbusnumber.DataValueField = "intvehicle";
            ddlbusnumber.DataBind();
            ddlbusnumber.Items.Insert(0,"-Select-");
            fillgrid();
        }
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
            if (ddlroutename.SelectedIndex > 0)
            {
                if (dgtransport.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "10");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Student");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        DataAccess dakeyword = new DataAccess();
                        DataSet dskeyword = new DataSet();
                        strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 10 and strpatrontype = 'Student'";
                        dskeyword = dakeyword.ExceuteSql(strsql);
                        string receiverids = "";
                        for (int i = 0; i < dgtransport.Items.Count; i++)
                        {
                            DataGridItem dgi = dgtransport.Items[i];
                            CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgtransportchk");
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
                        Response.Redirect("smstransport.aspx");
                    }
                    else
                    {
                        msgbox.alert("SMS Header is Empty");
                    }
                }
            }
        }
        if (ddlpatrontype.SelectedValue == "Staff")
        {
            if (dgtransport.Items.Count > 0)
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
                        command.Parameters.Add("@intcategoryid", "10");
                        command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        command.Parameters.Add("@strmessage", txtmessage.Text);
                        command.Parameters.Add("@strpatrontype", "Staff");
                        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    DataAccess dakeyword = new DataAccess();
                    DataSet dskeyword = new DataSet();
                    strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 10 and strpatrontype = 'Staff'";
                    dskeyword = dakeyword.ExceuteSql(strsql);
                    string receiverids = "";
                    for (int i = 0; i < dgtransport.Items.Count; i++)
                    {
                        DataGridItem dgi = dgtransport.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgtransportchk");
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
                    Response.Redirect("smstransport.aspx");
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
                    command.Parameters.Add("@intcategoryid", "10");
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
                //strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as classanddept,convert(varchar(10), strdateofbirth,103) as dtdateofbirth,strgender from tblstudent where intschool=" + Session["SchoolID"] + " and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
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
                //strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as classanddept,convert(varchar(10), strdateofbirth,103) as dtdateofbirth,strgender from tblstudent where intschool=" + Session["SchoolID"] + " and month(strdateofbirth) = month(convert(datetime,'" + txtfromdtdate.Text + "',103)) and day(strdateofbirth) = day(convert(datetime,'" + txtfromdtdate.Text + "',103))";
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
                Response.Redirect("smstransport.aspx");
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
            if (ddlroutename.SelectedIndex > 0)
            {
                if (dgtransport.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "10");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "Student");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        string receiverids = "";
                        for (int i = 0; i < dgtransport.Items.Count; i++)
                        {
                            DataGridItem dgi = dgtransport.Items[i];
                            CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgtransportchk");
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
                        Response.Redirect("smstransport.aspx");
                    }
                    else
                    {
                        msgbox.alert("SMS Header is Empty");
                    }
                }

            }
        }
        if (ddlpatrontype.SelectedValue == "Staff")
        {
            if (dgtransport.Items.Count > 0)
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
                        command.Parameters.Add("@intcategoryid", "10");
                        command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        command.Parameters.Add("@strmessage", txtmessage.Text);
                        command.Parameters.Add("@strpatrontype", "Staff");
                        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    string receiverids = "";
                    for (int i = 0; i < dgtransport.Items.Count; i++)
                    {
                        DataGridItem dgi = dgtransport.Items[i];
                        CheckBox ch = (CheckBox)dgi.Cells[0].FindControl("dgtransportchk");
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
                    Response.Redirect("smstransport.aspx");
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
                    command.Parameters.Add("@intcategoryid", "10");
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
                Response.Redirect("smstransport.aspx");
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }    
}