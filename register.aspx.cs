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

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillschooltype();
            fillcountry();
            fillstate();
            fillcity();
            clear();
            chkschooltype.Attributes.Add("onclick", "return HandleOnCheck()");
        }
        txtemailid.Attributes.Add("onblur", "document.getElementById('" + chkemail.UniqueID + "').click();");
    }
    protected void fillschooltype()
    {
        string qry = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        qry = "select * from tblschooltype";
        ds = new DataSet();
        ds = da.ExceuteSql(qry);
        chkschooltype.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strschooltype"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
            chkschooltype.Items.Add(li);
        }
    }
    private void fillcountry()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblcountry";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcountry.DataSource = ds;
        ddlcountry.DataTextField = "strcountryname";
        ddlcountry.DataValueField = "intcountryid";
        ddlcountry.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlcountry.Items.Insert(0, li);
    }
    private void fillstate()
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            string sql = "select * from tblstate where countryid=" + ddlcountry.SelectedValue;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlstate.DataSource = ds;
            ddlstate.DataTextField = "strstate";
            ddlstate.DataValueField = "intstateid";
            ddlstate.DataBind();
            ListItem li = new ListItem("-Select-", "0");
            ddlstate.Items.Insert(0, li);
        }
        catch { }
    }

    private void fillcity()
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            string sql = "select * from tblcity where countryid=" + ddlcountry.SelectedValue + " and stateid=" + ddlstate.SelectedValue;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlcity.DataSource = ds;
            ddlcity.DataTextField = "strcity";
            ddlcity.DataValueField = "intcityid";
            ddlcity.DataBind();
            ListItem li = new ListItem("-Select-", "0");
            ddlcity.Items.Insert(0, li);
        }
        catch { }
    }

    private void clear()
    {
        txtaddress.Text = "";
        txtcpassword.Text = "";
        txtpassword.Text = "";
        txtphoneno.Text = "";
        txtschoolname.Text = "";
        txtyourname.Text = "";
        txtzipcode.Text = "";
        txtemailid.Text = "";
        txtdomainname.Text = "";
        chk1.Checked = false;
    }

    protected string selectedcategory()
    {
        string str = "";
        for (int i = 0; i < chkschooltype.Items.Count; i++)
        {
            if (chkschooltype.Items[i].Selected == true)
            {
                str = chkschooltype.Items[i].Value.ToString();
            }
        }
        return str;
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillcity();
            string qry = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            qry = "select intcode from tblcity where id=" + ddlcity.SelectedValue;
            ds = da.ExceuteSql(qry);
            if (ds.Tables[0].Rows.Count > 0)
                txtcitycode.Text = ds.Tables[0].Rows[0]["intcode"].ToString();
        }
        catch { }
    }
    protected void btncrtsch_Click(object sender, EventArgs e)
    {
        if (lblemailmsg.Text == "")
        {
            if (chk1.Checked)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                SqlCommand command;
                SqlParameter param;
                SqlParameter OutPutParam;
                conn.Open();
                command = new SqlCommand("SPschool", conn);
                param = command.Parameters.Add("ReturnValue", SqlDbType.Int);
                param.Direction = ParameterDirection.ReturnValue;

                OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
                OutPutParam.Direction = ParameterDirection.Output;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@intid", "0");
                command.Parameters.Add("@strschoolname", txtschoolname.Text.Trim());
                command.Parameters.Add("@strname", txtyourname.Text.Trim());
                command.Parameters.Add("@stremailid", txtemailid.Text.Trim());
                command.Parameters.Add("@strphoneno", txtphoneno.Text.Trim());
                command.Parameters.Add("@straddress", txtaddress.Text.Trim());
                command.Parameters.Add("@intcity", ddlcity.SelectedValue);
                command.Parameters.Add("@intstate", ddlstate.SelectedValue);
                command.Parameters.Add("@intcountry", ddlcountry.SelectedValue);
                command.Parameters.Add("@strzipcode", txtzipcode.Text.Trim());
                command.Parameters.Add("@strpassword", txtpassword.Text.Trim());
                command.Parameters.Add("@strsubdomain", txtdomainname.Text.Trim());
                command.Parameters.Add("@strcountrycode", "0");
                command.Parameters.Add("@strcitycode", txtcitycode.Text.Trim());
                int j = 0;
                for (int i = 0; i < chkschooltype.Items.Count; i++)
                {
                    if (chkschooltype.Items[i].Selected == true)
                    {
                        string schooltype = chkschooltype.Items[i].Value.ToString();
                        j = i;
                        break;
                    }
                }
                command.Parameters.Add("@intschooltype", j);
                command.Parameters.Add("@intstudents", ddlnoofstudents.SelectedValue);
                command.ExecuteNonQuery();
                conn.Close();

                string msg = "";
                msg = msg + "    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"700\">";
                msg = msg + "        <tr>";
                msg = msg + "            <td style=\"width: 125px; height: 75px\" align=\"left\"><img src=\"http://www.theschools.in/Media/Images/emaillogotop.png\" border=\"0\" alt=\"logo\" /></td>";
                msg = msg + "            <td style=\"width: 575px; height: 75px; font-family: Arial Black; font-size: 20px\" align=\"left\">TheSchools.in 30 Days Trial</td>";
                msg = msg + "        </tr>";
                msg = msg + "        <tr>";
                msg = msg + "            <td colspan=\"2\" style=\"width: 700px; padding-top: 20px; padding-bottom: 20px; text-align: justify; line-height: 25px; font-family: Tahoma; font-size: 12px\">";
                msg = msg + "                Dear " + txtyourname.Text + ",<br /><br />";
                msg = msg + "                We're excited that you've decided to take the 30-day trial. You are one step closer to experiencing TheSchools.in's potential to the fullest. As promised, you are online!<br />";
                msg = msg + "                For your convenience, here are your login details:<br />";
                msg = msg + "                Your school site: <a href=\"http://" + txtdomainname.Text + ".theschools.in\">http://" + txtdomainname.Text + ".theschools.in</a><br />";
                msg = msg + "                Username:  " + txtemailid.Text + "<br />";
                msg = msg + "                Password:  " + txtpassword.Text + "<br /><br />";
                msg = msg + "                Should you need live assistance when you're on the website, do click the chat box at the bottom right of the screen and ask away.<br /><br />";
                msg = msg + "                Best Regards,<br />";
                msg = msg + "                Jaya Krishna<br />";
                msg = msg + "                TheSchools.in<br />";
                msg = msg + "                Powerfully Simple School Management<br /><br />";
                msg = msg + "                TheSchools Blog: <a href=\"http://blog.theschools.in\">http://blog.theschools.in</a>";
                msg = msg + "            </td>";
                msg = msg + "        </tr>";
                msg = msg + "        <tr>";
                msg = msg + "            <td colspan=\"2\" style=\"width: 700px; height: 75px\" align=\"center\">";
                msg = msg + "                <img src=\"http://www.theschools.in/Media_front/Images/logo.png\" border=\"0\" alt=\"logo\" /><br /><br />";
                msg = msg + "                <a href=\"mail: support@theschools.in>TheSchools.in - Support Team</a><br /><br />";
                msg = msg + "            </td>";
                msg = msg + "        </tr>";
                msg = msg + "    </table>";
                Functions.Sendmail(txtemailid.Text, "support@theschools.in", "New School Registration", msg);
                clear();
                Response.Redirect("congratulations.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please accept our Privacy Policy to Continue!')", true);
            }
        }
    }

    protected void chkemail_Click(object sender, ImageClickEventArgs e)
    {
        DataAccess da = new DataAccess();
        string str = "select * from tblschool where stremailid='" + txtemailid.Text + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblemailmsg.Text = "Email ID Already Registered with us.";
        }
        else
        {
            lblemailmsg.Text = "";
        }
    }
    protected void chkschooltype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string qry = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            qry = "select intcode from tblcity where id=" + ddlcity.SelectedValue;
            ds = da.ExceuteSql(qry);
            if (ds.Tables[0].Rows.Count > 0)
                txtcitycode.Text = ds.Tables[0].Rows[0]["intcode"].ToString();
        }
        catch { }
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillstate();
            fillcity();
        }
        catch { }
    }
}
