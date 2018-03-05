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

public partial class communication_smshomework : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public string receiverids;
    public string conditionquery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlsubject.Items.Insert(0,"-Select-");
            fillsmskeyword();
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid =2";
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
        ddlstandardsingle.Items.Insert(0,"-Select-");
    }  
    protected void fillsubjects()
    {
        ddlsubject.Items.Clear();
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strsubject from (select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where";
        sql += " intschool=" + Session["SchoolID"].ToString() + " and strsubject !='Second Language' and strsubject!='Third language' and strstandard+' - '+strsection ='" + ddlstandardsingle.SelectedValue + "' group by strstandard+' - '+strsection,strsubject";
        sql += " UNION ALL select strstandard+' - '+strsection as class,strsecondlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandardsingle.SelectedValue + "' and strsecondlanguage !=''";
        sql += "  group by strsecondlanguage,strstandard+' - '+strsection UNION ALL";
        sql += " select strstandard+' - '+strsection as class,strthirdlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandardsingle.SelectedValue + "' and strthirdlanguage !=''";
        sql += " group by strthirdlanguage,strstandard+' - '+strsection) a group by strsubject";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        ddlsubject.Items.Clear();
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strsubject"].ToString(), ds.Tables[0].Rows[i - 1]["strsubject"].ToString());

            ddlsubject.Items.Add(li);
        }
    }
    protected void ddlstandardsingle_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubjects();
        if (txtfromdtdate.Text != "" && ddlstandardsingle.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "" && ddlstandardsingle.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void dtdate_TextChanged(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "" && ddlstandardsingle.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
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
        dghomework.Visible = true;
        Hiddenerror.Text = "";
        trsendbutton.Visible = true;
        strsql = "select distinct a.* from tblhomework a,tblhomeworkAttachments b where a.strstandard+' - '+a.strsection='" + ddlstandardsingle.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and b.dtassigndate=convert(datetime,'" + txtfromdtdate.Text + "',103) and a.intid=b.inthomeworkid";
        lblconditionquery.Text = strsql;
        ds = da.ExceuteSql(strsql);
        dghomework.DataSource = ds;
        dghomework.DataBind();
        if (dghomework.Items.Count <= 0)
        {
            dghomework.Visible = false;
            trsendbutton.Visible = false;
            Hiddenerror.Text = "There is no data to display";
        }
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = sender as CheckBox;
        foreach (DataGridItem gvr in dghomework.Items)
        {
            CheckBox chkSelect = gvr.FindControl("chkselect") as CheckBox;
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
        strsql = "select intid, strtemplatename,strmessage from tblsmstemplate where intcategoryid=2 and intschool=" + Session["SchoolID"];
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
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=2 and intid=" + ddlpredefinedmsg.SelectedValue + " and intschool=" + Session["SchoolID"];
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
        if(txtfromdtdate.Text !="")
        {
            if (ddlstandardsingle.SelectedIndex > 0)
            {
                if (ddlsubject.SelectedIndex > 0)
                {
                    if (dghomework.Items.Count > 0)
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
                                string sql = "select strdescription,strkeyword,strcolumnname,strtablename from tblsmskeyword where intsmscategoryid =2";
                                dskey = dakey.ExceuteSql(sql);
                                string receiverids = "";
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    for (int j = 0; j < dghomework.Items.Count; j++)
                                    {
                                        DataGridItem dgh = dghomework.Items[j];
                                        string colsql = "select * from tblhomework where intid=" + dgh.Cells[0].Text;
                                        SqlDataAdapter da1 = new SqlDataAdapter(colsql, conn);
                                        da1.Fill(ds, "tblhomework");
                                        string message = txtmessage.Text;
                                        if (dskey.Tables[0].Rows.Count > 0)
                                        {
                                            for (int z = 0; z < dskey.Tables[0].Rows.Count; z++)
                                            {
                                                if (dskey.Tables[0].Rows[z]["strtablename"].ToString() == "tblhomework")
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
                            msgbox.alert("SMS Header is empty");
                        }
                    }
                }
            }
        }
    }
    protected void submitdelay_Click(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "")
        {
            if (ddlstandardsingle.SelectedIndex > 0)
            {
                if (ddlsubject.SelectedIndex > 0)
                {
                    if (dghomework.Items.Count > 0)
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
                                command.Parameters.Add("@intcategoryid", "2");
                                command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                                command.Parameters.Add("@strmessage", txtmessage.Text);
                                command.Parameters.Add("@strpatrontype", "");
                                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                                command.ExecuteNonQuery();
                                conn.Close();
                            }
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            strsql = "";
                            strsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intschool=" + Session["SchoolID"] + " and strstandard+' - '+strsection ='" + ddlstandardsingle.SelectedValue + "'";
                            ds = da.ExceuteSql(strsql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    receiverids = receiverids + ds.Tables[0].Rows[i]["intid"].ToString() + ",";
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
                        else
                        {
                            msgbox.alert("SMS Header is empty");
                        }
                    }
                }
            }
        }
    }
}

