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

public partial class school_viewprofile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        trsubdomain.Visible = false;
        if (!IsPostBack)
        {
            fillschooltype();
            fillcountry();
            fillstate();
            fillcity();
            fillprofile();
        }
        txtemail.Attributes.Add("onblur", "document.getElementById('" + chkemail.UniqueID + "').click();");
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
        ddlcountry.DataTextField = "countryname";
        ddlcountry.DataValueField = "id";
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, "-Select-");
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
            ddlstate.DataValueField = "id";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, "-Select-");
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
            ddlcity.DataTextField = "city";
            ddlcity.DataValueField = "id";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, "-Select-");
        }
        catch { }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstate();
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillcity();
    }

    protected void fillprofile()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds;
            string str = "";
            da = new DataAccess();
            str = "select * from tblschool where intid=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtschoolname.Text = ds.Tables[0].Rows[0]["strschoolname"].ToString();
                txtname.Text = ds.Tables[0].Rows[0]["strname"].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
                ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["intcountry"].ToString();
                fillstate();
                ddlstate.SelectedValue = ds.Tables[0].Rows[0]["intstate"].ToString();
                fillcity();
                ddlcity.SelectedValue = ds.Tables[0].Rows[0]["intcity"].ToString();
                txtemail.Text = ds.Tables[0].Rows[0]["stremailid"].ToString();
                txtweb.Text = ds.Tables[0].Rows[0]["strsubdomain"].ToString();
                ddlnoofstudents.SelectedValue = ds.Tables[0].Rows[0]["intstudents"].ToString();
                txtphone.Text = ds.Tables[0].Rows[0]["strphoneno"].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0]["strzipcode"].ToString();
                txtpassword.Text = ds.Tables[0].Rows[0]["strpassword"].ToString();
                txtcpassword.Text = ds.Tables[0].Rows[0]["strpassword"].ToString();
                txtcpassword.TextMode = TextBoxMode.Password;
                txtpassword.TextMode = TextBoxMode.Password;
                txtpassword.Attributes.Add("Value", ds.Tables[0].Rows[0]["strpassword"].ToString());
                txtcpassword.Attributes.Add("Value", ds.Tables[0].Rows[0]["strpassword"].ToString());

                string abc = ds.Tables[0].Rows[0]["intschooltype"].ToString();
                for (int i = 0; i < chkschooltype.Items.Count; i++)
                {                    
                   if (chkschooltype.Items[i].Value == abc)
                   chkschooltype.Items[i].Selected = true;                    
                }
            }
        }
        catch { }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (ddlcountry.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the Country!')", true);
        }
        else if (ddlstate.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the State!')", true);
        }
        else if (ddlcity.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the City!')", true);
        }
        else if (ddlnoofstudents.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the Number of Students!')", true);
        }
        else
        {
            if (lblemailmsg.Text == "")
            {
                string schooltype = "0";
                for (int i = 0; i < chkschooltype.Items.Count; i++)
                {
                    if (chkschooltype.Items[i].Selected == true)
                    {
                        schooltype = chkschooltype.Items[i].Value.ToString();
                        break;
                    }
                }
                if (schooltype != "0")
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
                    command.Parameters.Add("@intid", Session["SchoolID"].ToString());
                    command.Parameters.Add("@strschoolname", txtschoolname.Text.Trim());
                    command.Parameters.Add("@strname", txtname.Text.Trim());
                    command.Parameters.Add("@stremailid", txtemail.Text.Trim());
                    command.Parameters.Add("@strphoneno", txtphone.Text.Trim());
                    command.Parameters.Add("@straddress", txtaddress.Text.Trim());
                    command.Parameters.Add("@intcity", ddlcity.SelectedValue);
                    command.Parameters.Add("@intstate", ddlstate.SelectedValue);
                    command.Parameters.Add("@intcountry", ddlcountry.SelectedValue);
                    command.Parameters.Add("@strzipcode", txtpincode.Text.Trim());
                    command.Parameters.Add("@strpassword", txtpassword.Text.Trim());
                    command.Parameters.Add("@strsubdomain", txtweb.Text.Trim());
                    command.Parameters.Add("@intschooltype", schooltype);
                    command.Parameters.Add("@intstudents", ddlnoofstudents.SelectedValue);
                    command.ExecuteNonQuery();
                    conn.Close();
                    //string id = Convert.ToString(OutPutParam.Value);
                    //Functions.UserLogs(Session["UserID"].ToString(),"",id,"Updated",Session["PatronType"].ToString(),Session["SchoolID"].ToString(),);
                    Response.Redirect("profile.aspx");
                }
                else
                    lbltypemsg.Text = "Select Atleast one School Type";

            }
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("profile.aspx");
    }

    protected void chkemail_Click(object sender, ImageClickEventArgs e)
    {
        DataAccess da = new DataAccess();
        string str = "select * from tblschool where stremailid='" + txtemail.Text + "' and intid <>" + Session["SchoolID"].ToString();
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
}
