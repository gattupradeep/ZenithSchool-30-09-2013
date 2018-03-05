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

public partial class communication_smsattendance : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillsmskeyword();
        }
    }
    protected void fillsmskeyword()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 1";
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
        dgattendance.Visible = true;
        Hiddenerror.Text = "";
        trsendbutton.Visible = true;
        strsql = "select a.intid,intstudent, a.strclass as stdsec,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as studentname,convert(varchar(10),dtdate,103)as dtdate,a.strsession,a.strreason  from tblstudentattendance a,tblstudent b where a.intschool = " + Session["SchoolID"].ToString() + " and a.intstudent=b.intid";
        if (txtfromdtdate.Text != "")
        {
            strsql += " and a.dtdate = convert(datetime,'" + txtfromdtdate.Text.Trim() + "',103)";
        }
        if (txtclass.Text != "")
        {
            strsql += " and a.strclass in('" + txtclass.Text.Replace(", ", "','") + "')";
        }
        ds = da.ExceuteSql(strsql);
        dgattendance.DataSource = ds;
        dgattendance.DataBind();
        if (dgattendance.Items.Count <= 0)
        {
            dgattendance.Visible = false;
            Hiddenerror.Text = "There is no data to display";
            trsendbutton.Visible = false;
        }
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = sender as CheckBox;
        foreach (DataGridItem gvr in dgattendance.Items)
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
        strsql = "select intid,strtemplatename,strmessage from tblsmstemplate where intcategoryid=1 and intschool=" + Session["SchoolID"];
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
        if(txtfromdtdate.Text !="")
        fillgrid();
    }
    protected void ddlpredefinedmsg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpredefinedmsg.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select intid,strmessage from tblsmstemplate where intcategoryid=1 and intid="+ddlpredefinedmsg.SelectedValue+" and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(strsql);
            txtmessage.Text=ds.Tables[0].Rows[0]["strmessage"].ToString();
        }
    }
    protected void Sendsms_Click(object sender, EventArgs e)
    {
        if (txtfromdtdate.Text != "")
        {
            if (txtclass.Text != "")
            {
                if (dgattendance.Items.Count > 0)
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
                            command.Parameters.Add("@intcategoryid", "1");
                            command.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                            command.Parameters.Add("@strmessage", txtmessage.Text);
                            command.Parameters.Add("@strpatrontype", "");
                            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        DataAccess dakey = new DataAccess();
                        DataSet dskey = new DataSet();
                        string sql = "select strdescription,strkeyword,strcolumnname,strtablename from tblsmskeyword where intsmscategoryid =1";
                        dskey = dakey.ExceuteSql(sql);
                        string receiverids = "";
                        for (int j = 0; j < dgattendance.Items.Count; j++)
                        {
                            DataSet ds = new DataSet();
                            DataGridItem dga = dgattendance.Items[j];
                            CheckBox ch = (CheckBox)dga.Cells[2].FindControl("chkselect");
                            if (ch.Checked == true)
                            {
                                string colsql = "select strstandard+' - '+strsection as class,strfirstname+' '+strmiddlename+' '+strlastname as studentname,* from tblstudent where intschool=" + Session["SchoolID"] + " and intid=" + dga.Cells[0].Text;
                                SqlDataAdapter da1 = new SqlDataAdapter(colsql, conn);
                                da1.Fill(ds, "tblstudent");
                                string attsql = "select 'Absent' as status,* from tblstudentattendance where intid=" + dga.Cells[1].Text;
                                SqlDataAdapter da2 = new SqlDataAdapter(attsql, conn);
                                da2.Fill(ds, "tblstudentattendance");
                                string message = txtmessage.Text;
                                if (dskey.Tables[0].Rows.Count > 0)
                                {
                                    for (int z = 0; z < dskey.Tables[0].Rows.Count; z++)
                                    {
                                        message = message.Replace(dskey.Tables[0].Rows[z]["strkeyword"].ToString(), ds.Tables[dskey.Tables[0].Rows[z]["strtablename"].ToString()].Rows[0][dskey.Tables[0].Rows[z]["strcolumnname"].ToString()].ToString());
                                    }
                                }
                                //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                                receiverids = receiverids + ds.Tables["tblstudent"].Rows[0]["intid"].ToString() + ",";
                            }
                        }
                        DataAccess dasent = new DataAccess();
                        DataSet dssent = new DataSet();
                        string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                        sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                        sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),1,0,'Student'," + Session["SchoolID"] + ")";
                        dssent = dasent.ExceuteSql(sqlsent);
                        Response.Redirect("smsattendance.aspx");
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
