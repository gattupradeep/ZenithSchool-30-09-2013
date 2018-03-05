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
using System.Text.RegularExpressions;

public partial class communication_smsfeestatus : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string sql;
    public string conditionquery;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillsmskeyword();
            fillstandard();
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 16";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblkeywords.Text += ds.Tables[0].Rows[i]["strdescription"].ToString() + " : <font class='sms_keywords'>" + ds.Tables[0].Rows[i]["strkeyword"].ToString() + "</font>, ";
            }
        }
    }
    protected void fillstandard()
    {
        ddlclass.Items.Clear();
        string str = "select strstandard+' - '+strsection as Classandsec from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strstandard,strsection";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "Classandsec";
        ddlclass.DataValueField = "Classandsec";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
    }
    protected void fillgrid()
    {
        try
        {            
            da = new DataAccess();
            ds = new DataSet();
            grdstudentfeedue.Visible = true;
            Hiddenerror.Text = "";
            trsendbutton.Visible = true;
            sql = " select * from (";
            sql += " select a.intid as studentid,a.strfirstname+''+strmiddlename+' '+strlastname as name,a.strstandard+' - '+a.strsection as strstandard,";
            sql += " b.strfeemode,c.strfeetype,d.amount,e.intyear,e.strfinemode,e.intfine,convert(varchar(50),e.dtuptodate,103) as uptodate,";
            sql += " convert(varchar(50), e.dtduedate,103) as duedate,e.dtduedate,f.latefee as paidlatefee,f.paid,0 as latefee,";
            sql += " 0 as withlatefee,0 as balance,((d.amount)+f.latefee)-(f.paid) as dues";

            sql += " from tblstudent a,";

            sql += " (select * from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -2 as intid,'New Admission' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -1 as intid,'Others' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"] + ") b,";

            sql += " tblfeemaster c,";

            sql += " (select SUM(a.intamount) as amount,a.intfeetype,a.intschool,a.intassignid,a.intfeemode,a.intstudent,a.strstandard from ";
            sql += " ( select a.intamount,a.strreceipt,a.intbreakups,d.strfeebreakups,b.intassignid,d.intfeemode,d.intfeetype, a.intschool,";
            sql += " b.intstudent,c.strstandard from tblreceiptitem a,tblstudentreceipts b,tblassignfees c, tblfeetypes d,tblaccounttransaction e,";
            sql += " tblstudent f where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and d.intschool=e.intschool ";
            sql += " and e.intschool=f.intschool and a.strreceipt=b.strreceiptno and b.intassignid=c.intid and b.intassignid=c.intid and c.intfeetype=d.intfeetype and ";
            sql += " a.intschool=" + Session["SchoolID"] + " and ((b.intstudent in ( f.intid)  and e.inttogroups != 4) or (b.intstudent in ";
            sql += " (SELECT PARSENAME(REPLACE('f.intadmitno', '-','.' ), 1)) and e.inttogroups = 4)) and";
            sql += " c.intfeemode=d.intfeemode and d.intid=a.intbreakups and c.strstandard=d.strstandard and b.inttransactionid=e.inttransactionid ";
            sql += " group by a.strreceipt,a.intamount,a.intbreakups,d.strfeebreakups,b.intassignid,d.intfeemode,d.intfeetype, a.intschool,";
            sql += " b.intassignid,d.intfeemode,b.intstudent,c.strstandard)  a group by a.intfeetype,a.intschool,a.intassignid,a.intfeemode,";
            sql += " a.intstudent,a.strstandard) d,";

            sql += " tblassignfees e,";

            sql += " (select (paid+discount) as paid,studentid,intassignid,";
            sql += " latefee,intschool,a.intfeemode,a.intfeetype,a.strstandard from ((select intassignid,max(intlatefee) as latefee,";
            sql += " SUM(intpaid) as paid,SUM(intdiscount) as discount,b.intid as studentid, a.intschool,c.intfeemode,c.intfeetype,";
            sql += " c.strstandard from tblstudentreceipts a,tblstudent b,tblassignfees c,tblaccounttransaction d where ";
            sql += " intstudent=b.intid and a.intassignid=c.intID and a.intschool=b.intschool and b.intschool=c.intschool";
            sql += " and c.intschool=d.intschool and a.inttransactionid=d.inttransactionid";
            if (ddlfeestatus.SelectedIndex == 1)
            {
                sql += " and a.intcancel = 1";
            }
            else
            {
                sql += " and a.intcancel = 0";
            }
           
            sql += " group by intassignid,b.intid,a.intschool,c.intfeemode,c.intfeetype,c.strstandard) ) a ) f,";

            sql += " tblaccounttransaction g,tblAcademicYear h,tblstudentreceipts i";

            sql += " where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and d.intschool=e.intschool and ";
            sql += " e.intschool=f.intschool and f.intschool=g.intschool and g.intschool=h.intschool and h.intschool=i.intschool and ";
            sql += " a.intID=d.intstudent and d.intstudent=f.studentid and b.intid=c.intfeemode and c.intfeemode=d.intfeemode and";
            sql += " d.intfeemode=e.intfeemode and e.intfeemode=f.intfeemode and c.intID=d.intfeetype and d.intfeetype=e.intfeetype";
            sql += " and d.intfeetype=e.intfeetype and a.strstandard+' - '+a.strsection=d.strstandard and d.strstandard=f.strstandard and";
            sql += " (a.intid in ( f.studentid) or (SELECT PARSENAME(REPLACE('a.intadmitno', '-','.' ), 1)) in (f.studentid)) ";
            sql += " and e.intID in ( f.intassignid) and e.intyear=h.intYear";

            if (ddlclass.SelectedIndex > 0)
            {
                sql += " and e.strstandard='" + ddlclass.SelectedValue + "'";
            }
            if (ddlfeestatus.SelectedIndex == 1 )
            {
                grdstudentfeedue.Columns[0].Visible = true;
                sql += " and ((d.amount)+f.latefee)-(f.paid) != 0";
            }

            sql += " group by a.intid,a.strfirstname+''+strmiddlename+' '+strlastname,a.strstandard+' - '+a.strsection,b.strfeemode,";
            sql += " c.strfeetype,d.amount,d.amount,e.intyear,e.strfinemode,e.intfine,e.dtuptodate,e.dtduedate,";
            sql += " f.latefee,f.paid,d.amount,f.latefee,f.paid";

            sql += " union all";

            sql += " select a.intid as studentid,a.strfirstname+''+strmiddlename+' '+strlastname as name,a.strstandard+' - '+a.strsection as strstandard,";
            sql += " b.strfeemode,c.strfeetype,d.amount,e.intyear,e.strfinemode,e.intfine,convert(varchar(50),e.dtuptodate,103) as uptodate,";
            sql += " convert(varchar(50), e.dtduedate,103) as duedate,e.dtduedate,0 as paidlatefee, 0 as paid,0 as latefee,";
            sql += " 0 as withlatefee,0 as balance,d.amount as dues";

            sql += " from tblstudent a,";

            sql += " (select * from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -2 as intid,'New Admission' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";

            sql += " select distinct -1 as intid,'Others' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"] + ") b,";

            sql += " tblfeemaster c,";

            sql += " (select sum(a.intamount) as amount,a.intfeetype,a.intfeemode,a.intschool,a.strstandard,a.intactivate from tblfeetypes a,";
            sql += " tblassignfees b where a.intschool=b.intschool and a.intfeetype=b.intfeetype and a.intfeemode=b.intfeemode and a.intactivate=0 and ";
            sql += " a.strstandard=b.strstandard and a.intschool=" + Session["SchoolID"] + " group by a.intfeetype,a.intfeemode,a.intschool,a.strstandard,a.intactivate) d,";
            sql += " tblassignfees e,";

            sql += " tblAcademicYear h";

            sql += " where a.intschool=b.intschool and b.intschool=c.intschool and c.intschool=d.intschool and d.intschool=e.intschool and";
            sql += " a.strstandard+' - '+a.strsection=d.strstandard and d.strstandard=e.strstandard and b.intid=d.intfeemode and";
            sql += " d.intfeemode=e.intfeemode and d.intactivate=0 and c.intID=d.intfeetype and d.intfeetype=e.intfeetype  and e.intyear=h.intYear ";
            //if (txtnameAdmno.Text == "")
            //{
            sql += " and ( a.intid not in (select a.intstudent from tblstudentreceipts a,tblaccounttransaction b where a.intschool=b.intschool and";
            sql += " a.inttransactionid=b.inttransactionid and a.intschool=" + Session["SchoolID"] + " and b.inttogroups != 4 and a.intcancel=0  group by a.intstudent) or";
            sql += " e.intID not in (select intassignid from tblstudentreceipts where intschool=" + Session["SchoolID"] + " and intcancel=0 group by intassignid))";
            sql += " and ((SELECT PARSENAME(REPLACE('a.intadmitno', '-','.' ), 1)) not in (select a.intstudent from tblstudentreceipts a,tblaccounttransaction b where";
            sql += " a.intschool=b.intschool and a.inttransactionid=b.inttransactionid and a.intschool=" + Session["SchoolID"] + " and b.inttogroups = 4 and a.intcancel=0  group by a.intstudent) or";
            sql += " e.intID not in (select intassignid from tblstudentreceipts where intschool=" + Session["SchoolID"] + " and intcancel=0 group by intassignid))";
            //}
            if (ddlclass.SelectedIndex > 0)
            {
                sql += " and e.strstandard='" + ddlclass.SelectedValue + "'";
            }
            if (ddlfeestatus.SelectedIndex == 1)
            {
                sql += " and d.amount != 0";
            }
            sql += " group by a.intid,a.strfirstname+''+strmiddlename+' '+strlastname,a.strstandard+' - '+a.strsection,b.strfeemode,";
            sql += " c.strfeetype,d.amount,e.intyear,e.strfinemode,e.intfine,e.dtuptodate,e.dtduedate ) as a order  by a.studentid";
            ds = da.ExceuteSql(sql);
            int count = 0;
            string sid = "";
            string ch = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (double.Parse(ds.Tables[0].Rows[i]["dues"].ToString()) != 0)
                    {
                        DateTime dtdue = DateTime.Parse(ds.Tables[0].Rows[i]["dtduedate"].ToString());
                        double fine = double.Parse(ds.Tables[0].Rows[i]["intfine"].ToString());
                        string mode = ds.Tables[0].Rows[i]["strfinemode"].ToString();
                        double actualfee = double.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                        ds.Tables[0].Rows[i]["withlatefee"] = actualfee + fillamount(dtdue, mode, fine);
                        ds.Tables[0].Rows[i]["latefee"] = fillamount(dtdue, mode, fine);
                        double paid = double.Parse(ds.Tables[0].Rows[i]["paid"].ToString());
                        ds.Tables[0].Rows[i]["Balance"] = actualfee + fillamount(dtdue, mode, fine) - paid;
                    }
                    else
                    {
                        double actualfee = double.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                        double paid = double.Parse(ds.Tables[0].Rows[i]["paid"].ToString());
                        double paidlatefee = double.Parse(ds.Tables[0].Rows[i]["paidlatefee"].ToString());
                        ds.Tables[0].Rows[i]["withlatefee"] = actualfee + paidlatefee;
                    }


                    ch = ds.Tables[0].Rows[i]["studentid"].ToString();
                    if (sid == "")
                    {
                        sid = ds.Tables[0].Rows[i]["studentid"].ToString();
                    }

                    else
                    {
                        if (sid.IndexOf(ch) > -1)
                        {

                        }
                        else
                        {
                            sid = sid + " , " + ds.Tables[0].Rows[i]["studentid"].ToString();
                            count = sid.Length - sid.Replace(",", "").Length;

                        }
                    }                    
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscripts", "alert('No records found for selected Criteria')", true);
            }
            grdstudentfeedue.DataSource = ds;
            grdstudentfeedue.DataBind();
            if (grdstudentfeedue.Items.Count <= 0)
            {
                grdstudentfeedue.Visible = false;
                Hiddenerror.Text = "There is no data to display";
                trsendbutton.Visible = false;
            }
        }
        catch { }
    }
    protected double fillamount(DateTime dtdue, string finemode, double fine)
    {
        double latefee = 0;
        TimeSpan ts = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) - (dtdue);
        int day = ts.Days;
        if (day > 0)
        {
            if (finemode != "Null")
            {
                if (finemode == "Day")
                {
                    latefee = fine * day;
                }
                else if (finemode == "Week")
                {
                    if (day > 7)
                    {
                        latefee = fine * (day / 7);
                    }
                }
                else if (finemode == "Month")
                {
                    if (day > 30)
                    {
                        latefee = fine * (day / 30);
                    }
                }
                else if (finemode == "Year")
                {
                    if (day > 365)
                    {
                        latefee = fine * (day / 365);
                    }
                }
                else
                {
                    int c = 0;
                    string[] a = Regex.Split(finemode, @"\D+");
                    foreach (string ab in a)
                    {
                        c = int.Parse(ab);
                        break;
                    }
                    if (day > c)
                    {
                        latefee = fine * (day / c);
                    }
                }
            }
            else
            {
                latefee = 0;
            }
        }
        return latefee;
    }
   
    protected void dgchkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = sender as CheckBox;
        foreach (DataGridItem gvr in grdstudentfeedue.Items)
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
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=16 and intid=" + ddlpredefinedmsg.SelectedValue + " and intschool=" + Session["SchoolID"];
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
        if (grdstudentfeedue.Items.Count > 0)
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
                        cmd.Parameters.Add("@intcategoryid", "16");
                        cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        cmd.Parameters.Add("@strmessage", txtmessage.Text);
                        cmd.Parameters.Add("@strpatrontype", "");
                        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    DataAccess dakeyword = new DataAccess();
                    DataSet dskeyword = new DataSet();
                    strsql = "select strkeyword,strtablename,strcolumnname from tblsmskeyword where intsmscategoryid = 16";
                    dskeyword = dakeyword.ExceuteSql(strsql);
                    string receiverids = "";
                    for (int i = 0; i < grdstudentfeedue.Items.Count; i++)
                    {
                        DataSet ds = new DataSet();
                        DataGridItem dgi = grdstudentfeedue.Items[i];
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
    protected void submitdelay_Click(object sender, EventArgs e)
    {
         conditionquery = lblconditionquery.Text.Replace("'", "''");
            if (grdstudentfeedue.Items.Count > 0)
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
                        cmd.Parameters.Add("@intcategoryid", "16");
                        cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                        cmd.Parameters.Add("@strmessage", txtmessage.Text);
                        cmd.Parameters.Add("@strpatrontype", "");
                        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    string receiverids = "";
                    for (int i = 0; i < grdstudentfeedue.Items.Count; i++)
                    {
                        DataSet ds = new DataSet();
                        DataGridItem dgi = grdstudentfeedue.Items[i];
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

    protected void ddlfeestatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlfeestatus.SelectedIndex > 0)
        {
            if (ddlclass.SelectedIndex > 0)
            {
                fillgrid();
            }
        }
    }
}
