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

public partial class communication_smsfoodmenu : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string conditionquery;
    public string strsql;
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
        string sql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid = 6";
        if (ddlfoodmenutype.SelectedIndex > 0)
        {
            trkeywords.Visible = true;
            if (ddlfoodmenutype.SelectedValue == "Breakfast")
            {
                sql += " and strpatrontype='Breakfast'";
            }
            else if (ddlfoodmenutype.SelectedValue == "Lunch")
            {
                sql += " and strpatrontype='Lunch'";
            }
            else if (ddlfoodmenutype.SelectedValue == "Dinner")
            {
                sql += " and strpatrontype='Dinner'";
            }
            else if (ddlfoodmenutype.SelectedValue == "All")
            {
                sql += " group by strdescription,strkeyword ";
            }
            else
            {
                sql += " and strpatrontype !='Breakfast' group by strdescription,strkeyword";
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
        strsql = "";
        lblconditionquery.Text = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select * from tblmenutimetable where intschool=" + Session["SchoolID"];
        if (ddlfoodday.SelectedIndex > 1)
        {
            strsql += " and strday='" + ddlfoodday.SelectedValue + "'";
        }
        if (ddlfoodday.SelectedIndex == 1)
        {
            strsql += " and strday!=''";
        }
        if (ddlfoodmenutype.SelectedIndex > 0)
        {
            strsql += " and strtype='" + ddlfoodmenutype.SelectedValue + "'";
        }
        lblconditionquery.Text = strsql;
        ds = da.ExceuteSql(strsql);
        dgfoodmenu.DataSource = ds;
        dgfoodmenu.DataBind();
        
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
    protected void fillsmstemplate()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select strtemplatename,strmessage from tblsmstemplate where intcategoryid=6 and intschool=" + Session["SchoolID"];
        if (ddlfoodmenutype.SelectedIndex > 0)
        {
            strsql += " and strpatrontype = '"+ddlfoodmenutype.SelectedValue+"'";
        }
        ds = da.ExceuteSql(strsql);
        ddlpredefinedmsg.DataSource = ds;
        ddlpredefinedmsg.DataTextField = "strtemplatename";
        ddlpredefinedmsg.DataValueField = "strmessage";
        ddlpredefinedmsg.DataBind();
        ddlpredefinedmsg.Items.Insert(0, "-Select-");
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
    }
    
    protected void ddlpredefinedmsg_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtmessage.Text = ddlpredefinedmsg.SelectedValue;
    }

    protected void sendlater_Click(object sender, EventArgs e)
    {
        trdelaydate.Visible = true;
    }
    protected void ddlfoodday_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtclass.Text != "")
        {
            fillgrid();
            if (ddlfoodday.SelectedIndex > 0)
            {
                if (ddlfoodstudtype.SelectedIndex > 0)
                {
                    if (ddlfoodmenutype.SelectedIndex > 0)
                    {
                        trsendbutton.Visible = true;
                    }
                    else
                    {
                        trsendbutton.Visible = false;
                    }
                }
                else
                {
                    trsendbutton.Visible = false;
                }
            }
            else
            {
                trsendbutton.Visible = false;
            }
        }
        else
        {
            trsendbutton.Visible = false;
        }
    }
    protected void ddlfoodmenutype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtclass.Text != "")
        {
            if (ddlfoodday.SelectedIndex > 0)
            {
                if (ddlfoodstudtype.SelectedIndex > 0)
                {
                    if (ddlfoodmenutype.SelectedIndex > 0)
                    {
                        fillgrid();
                        trsendbutton.Visible = true;
                        fillsmskeyword();
                        fillsmstemplate();
                    }
                    else
                    {
                        trsendbutton.Visible = false;
                        trkeywords.Visible = false;
                    }
                }
                else
                {
                    trsendbutton.Visible = false;
                }
            }
            else
            {
                trsendbutton.Visible = false;
            }
        }
        else
        {
            trsendbutton.Visible = false;
        }
    }
    protected void ddlfoodstudtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtclass.Text != "")
        {
            if (ddlfoodday.SelectedIndex > 0)
            {
                if (ddlfoodstudtype.SelectedIndex > 0)
                {
                    if (ddlfoodmenutype.SelectedIndex > 0)
                    {
                        fillgrid();
                        trsendbutton.Visible = true;
                    }
                    else
                    {
                        trsendbutton.Visible = false;
                    }
                }
                else
                {
                    trsendbutton.Visible = false;
                }
            }
            else
            {
                trsendbutton.Visible = false;
            }
        }
        else
        {
            trsendbutton.Visible = false;
        }
    }
    protected void Sendsms_Click(object sender, EventArgs e)
    {
        if (ddlfoodstudtype.SelectedIndex > 0 && txtclass.Text != "" && ddlfoodday.SelectedIndex > 0 && ddlfoodstudtype.SelectedIndex > 0)
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
                    cmd.Parameters.Add("@intid","0");
                    cmd.Parameters.Add("@intcategoryid", "6");
                    cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    cmd.Parameters.Add("@strmessage", txtmessage.Text);
                    cmd.Parameters.Add("@strpatrontype", ddlfoodmenutype.SelectedValue);
                    cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (dgfoodmenu.Items.Count > 0)
                {
                    DataSet sds = new DataSet();
                    strsql = "select * from tblstudent where intschool="+Session["SchoolID"]+" and strstandard+' - '+strsection in('"+txtclass.Text.Replace(", ", "','")+"') and hostler="+ddlfoodstudtype.SelectedValue;
                    SqlDataAdapter sda = new SqlDataAdapter(strsql,conn);
                    sda.Fill(sds,"tblstudent");
                    if (sds.Tables["tblstudent"].Rows.Count > 0)
                    {
                        DataAccess da = new DataAccess();
                        DataSet dskey = new DataSet();
                        strsql = "select * from tblsmskeyword where intsmscategoryid = 6";
                        if (ddlfoodmenutype.SelectedIndex > 0)
                        {
                            strsql += " and strpatrontype='" + ddlfoodmenutype.SelectedValue +"'";
                        }
                        if (ddlfoodmenutype.SelectedIndex == 0)
                        {
                            strsql += " and strpatrontype !=''";
                        }
                        dskey = da.ExceuteSql(strsql);
                        string receiverids = "";
                        for (int i = 0; i < sds.Tables["tblstudent"].Rows.Count; i++)
                        {
                            strsql = "";
                            for (int j = 0; j < dgfoodmenu.Items.Count; j++)
                            {
                                DataGridItem dgi = dgfoodmenu.Items[j];
                                strsql = "select * from tblmenutimetable where intid="+dgi.Cells[0].Text;
                                SqlDataAdapter sda1 = new SqlDataAdapter(strsql,conn);
                                sda1.Fill(sds, "tblmenutimetable");
                                string message = txtmessage.Text;
                                if (dskey.Tables[0].Rows.Count > 0)
                                {
                                    for (int z = 0; z < dskey.Tables[0].Rows.Count; z++)
                                    {
                                        if (dskey.Tables[0].Rows[z]["strtablename"].ToString() == "tblmenutimetable")
                                            message = message.Replace(dskey.Tables[0].Rows[z]["strkeyword"].ToString(), sds.Tables[dskey.Tables[0].Rows[z]["strtablename"].ToString()].Rows[j][dskey.Tables[0].Rows[z]["strcolumnname"].ToString()].ToString());
                                        else
                                            message = message.Replace(dskey.Tables[0].Rows[z]["strkeyword"].ToString(), sds.Tables[dskey.Tables[0].Rows[z]["strtablename"].ToString()].Rows[i][dskey.Tables[0].Rows[z]["strcolumnname"].ToString()].ToString());
                                    }
                                    //string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                                    //Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables["tblstudent"].Rows[i]["strmobile"].ToString() + "&message=" + txtmessage.Text + "&priority=1");
                                }
                            }
                            receiverids = receiverids + sds.Tables["tblstudent"].Rows[i]["intid"].ToString() + ",";
                        }
                        DataAccess dasent = new DataAccess();
                        DataSet dssent = new DataSet();
                        string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,";
                        sqlsent += " intqueueid,strpatron,intschool) values(" + Session["UserID"] + ",'" + receiverids + "',";
                        sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'1','0','Student'," + Session["SchoolID"] + ")";
                        dssent = dasent.ExceuteSql(sqlsent);
                    }
                    sds.Clear();
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
        if (ddlfoodstudtype.SelectedIndex > 0 && txtclass.Text != "" && ddlfoodday.SelectedIndex > 0 && ddlfoodstudtype.SelectedIndex > 0)
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
                    cmd.Parameters.Add("@intcategoryid", "6");
                    cmd.Parameters.Add("@strtemplatename", txtnewsmsheader.Text);
                    cmd.Parameters.Add("@strmessage", txtmessage.Text);
                    cmd.Parameters.Add("@strpatrontype", ddlfoodmenutype.SelectedValue);
                    cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (dgfoodmenu.Items.Count > 0)
                {
                    DataSet sds = new DataSet();
                    strsql = "select * from tblstudent where intschool=" + Session["SchoolID"] + " and strstandard+' - '+strsection in('" + txtclass.Text.Replace(", ", "','") + "') and hostler=" + ddlfoodstudtype.SelectedValue;
                    SqlDataAdapter sda = new SqlDataAdapter(strsql, conn);
                    sda.Fill(sds, "tblstudent");
                    if (sds.Tables["tblstudent"].Rows.Count > 0)
                    {
                        string receiverids = "";
                        for (int i = 0; i < sds.Tables["tblstudent"].Rows.Count; i++)
                        {
                           receiverids = receiverids + sds.Tables["tblstudent"].Rows[i]["intid"].ToString() + ",";
                        }
                        conditionquery = lblconditionquery.Text.Replace("'", "''");
                        DataAccess dasent = new DataAccess();
                        DataSet dssent = new DataSet();
                        string sqlsent = "insert into tblsmssentitems(intsenderid,strreceiverids,strsmsbody,dtdate,strsmssentmode,dtdelaydate,";
                        sqlsent += " intqueueid,strpatron,intschool,strconditionquery) values(" + Session["UserID"] + ",'" + receiverids + "',";
                        sqlsent += " '" + txtmessage.Text + "',CAST (GETDATE() AS DATE),'0',convert(datetime,'"+txtDelaydate.Text+"',103),'0','Student'," + Session["SchoolID"] + ",'"+conditionquery+"')";
                        dssent = dasent.ExceuteSql(sqlsent);
                    }
                    sds.Clear();
                }
            }
            else
            {
                msgbox.alert("SMS Header is Empty");
            }
        }
    }
}
