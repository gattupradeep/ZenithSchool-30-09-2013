using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_newuser : System.Web.UI.Page
{
    int intStaffId;
    public string staffhead, inht;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["staffid"] != null)
        {
            intStaffId = int.Parse(Request["staffid"].ToString());
        }
        FillModules();

        if (!IsPostBack)
        {
            if (Request["staffid"] != null)
            {
                staffhead = "Update Staff Details";
                showData();
                boxchecked();
            }
            else
            {
                staffhead = "Add New Staff";
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter param;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        CheckBox chkbox = new CheckBox();

        Conn.Open();
        RegCommand = new SqlCommand("spInsertEditStaff", Conn);
        RegCommand.Parameters.Add("@intStaffId", intStaffId);
        RegCommand.CommandType = CommandType.StoredProcedure;
        param = RegCommand.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = RegCommand.Parameters.Add("@intUserId", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;

        RegCommand.Parameters.Add("@strFirstName", Functions.StrAlignText(txtFirstName.Value.ToString()));
        RegCommand.Parameters.Add("@strAddress", Functions.StrAlignWords(txtAddress.Value.ToString()));
        RegCommand.Parameters.Add("@strArea", Functions.StrAlignWords(txtArea.Value.ToString()));
        RegCommand.Parameters.Add("@strTown", city.Value.ToString());
        RegCommand.Parameters.Add("@strPostCode", txtPin.Value.ToString().ToUpper());
        RegCommand.Parameters.Add("@strPhone", txtPh.Value.ToString());
        RegCommand.Parameters.Add("@strMobile", txtMobile.Value.ToString());
        RegCommand.Parameters.Add("@strFax", txtFax1.Value.ToString());
        RegCommand.Parameters.Add("@strCountry", Functions.StrAlignWords(txtCounty.Value.ToString()));
        RegCommand.Parameters.Add("@strEMail", txtEMail.Value.ToString().ToLower());
        RegCommand.Parameters.Add("@strPassword", txtPassword.Text.ToString());
        RegCommand.Parameters.Add("@strUserName", txtUserName.Value.ToString());
        RegCommand.Parameters.Add("@strLastName", Functions.StrAlignText(txtLastName.Value.ToString()));
        if (optactive.Checked)
            RegCommand.Parameters.Add("@intStatus", "1");
        else
            RegCommand.Parameters.Add("@intStatus", "0");
        RegCommand.Parameters.Add("@salesmanager", "0");
        RegCommand.Parameters.Add("@consumers", "0");
        RegCommand.Parameters.Add("@branchid", "0");

        RegCommand.ExecuteNonQuery();

        if ((int)(RegCommand.Parameters["@intuserid"].Value) > 0)
        {
            intStaffId = (int)RegCommand.Parameters["@intUserId"].Value;
            SaveRights();
            Response.Redirect("userdetails.aspx");
        }
        else
        {
            Response.Write("<script>alert('UserName already exists. Please choose another!')</script>");
        }
        Conn.Close();
        //string id = Convert.ToString(OutPutParam.Value);
        //Functions.UserLogs(Session["UserID"].ToString(), "tbluserrights", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),0);
    }

    protected void SaveRights()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;

        qry = "delete from tbluserrights where staffid = " + intStaffId + "";
        //Functions.UserLogs(Session["UserID"].ToString(), "tbluserrights", intStaffId.ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

        da.ExceuteSqlQuery(qry);

        qry = "SELECT menuid from tblmenus";
        ds = da.ExceuteSql(qry);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            CheckBox chkbox = new CheckBox();
            foreach (Control c in Panel1.Controls)
            {
                chkbox = (CheckBox)c.FindControl(ds.Tables[0].Rows[i][0].ToString());
                break;
            }

            if (chkbox.Checked == true)
            {
                qry = "insert into tbluserrights(menuid,staffid) values (" + ds.Tables[0].Rows[i][0] + "," + intStaffId + ")";
                da.ExceuteSqlQuery(qry);
                DataSet ds2 = new DataSet();
                qry = "select max(intuserrightid) as intuserrightid from tbluserrights";
                ds2 = da.ExceuteSql(qry);
               // Functions.UserLogs(Session["UserID"].ToString(), "tbluserrights", ds2.Tables[0].Rows[0]["intuserrightid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString());
            }
        }
    }

    protected void FillModules()
    {
        HtmlGenericControl c = new HtmlGenericControl();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;
        string inht;

        qry = "SELECT menuid,menuname from tblmenus where parentmenu =0";
        ds = da.ExceuteSql(qry);

        inht = "";
        inht = inht + "<table width='740' border='0' cellspacing='0' cellpadding='0'>";
        c.InnerHtml = inht.ToString();
        Panel1.Controls.Add(c);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            inht = "";
            inht = inht + "<tr>";
            inht = inht + "<td height='30' align='left' valign='middle' class='style10'>";
            c = new HtmlGenericControl();
            c.InnerHtml = inht;
            Panel1.Controls.Add(c);

            CheckBox chk = new CheckBox();
            chk.ForeColor = System.Drawing.Color.Red;
            chk.ID = ds.Tables[0].Rows[i][0].ToString();
            chk.Text = "<B>" + ds.Tables[0].Rows[i][1] + "</B>";
            Panel1.Controls.Add(chk);

            inht = "";
            inht = inht + "</td></tr>";
            c = new HtmlGenericControl();
            c.InnerHtml = inht;
            Panel1.Controls.Add(c);

            Fillsidemenu(int.Parse(ds.Tables[0].Rows[i][0].ToString()));
        }

        inht = "";
        inht = inht + "</table>";
        c = new HtmlGenericControl();
        c.InnerHtml = inht;
        Panel1.Controls.Add(c);
    }

    protected void Fillsidemenu(int parentid)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;

        qry = "SELECT menuid,menuname,dropdownmenu from tblmenus where parentmenu =" + parentid + " and menuurl = 'Side Menu'";
        ds = da.ExceuteSql(qry);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            HtmlGenericControl c = new HtmlGenericControl();

            inht = "";
            inht = inht + "<tr> ";
            inht = inht + "<td>";
            inht = inht + "<table width='740' border='0' cellspacing='0' cellpadding='0'>";
            inht = inht + "<tr>";
            inht = inht + "<td width='20' height='30'></td>";
            inht = inht + "<td align='left' valign='middle' class='style10'>";
            c.InnerHtml = inht;
            Panel1.Controls.Add(c);

            CheckBox chk = new CheckBox();
            chk.ForeColor = System.Drawing.Color.Blue;
            chk.ID = ds.Tables[0].Rows[i][0].ToString();
            chk.Text = "<B>" + ds.Tables[0].Rows[i][1] + "</B>";
            Panel1.Controls.Add(chk);

            HtmlGenericControl c1 = new HtmlGenericControl();
            inht = "";
            inht = inht + "</td></tr>";
            inht = inht + "</table>";
            inht = inht + "</td>";
            inht = inht + "</tr>";
            c1.InnerHtml = inht;
            Panel1.Controls.Add(c1);

            FillMiniModules(parentid, int.Parse(ds.Tables[0].Rows[i][2].ToString()));
        }
    }

    protected void FillMiniModules(int parentid, int ddm)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;
        int rco;
        rco = 0;

        qry = "SELECT menuid,menuname from tblmenus where parentmenu =" + parentid + " and dropdownmenu = " + ddm + " and menuurl <> 'Side Menu'";
        ds = da.ExceuteSql(qry);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            HtmlGenericControl c1 = new HtmlGenericControl();
            if (rco == 0)
            {
                inht = "";
                inht = inht + "<tr>";
                inht = inht + "<td>";
                inht = inht + "<table width='740' border='0' cellspacing='0' cellpadding='0'>";
                inht = inht + "<tr>";
                inht = inht + "<td width='40' height='30' class='style10'></td>";
                c1.InnerHtml = inht;
                Panel1.Controls.Add(c1);
            }

            inht = "";
            inht = inht + "<td width='230' align='left' valign='middle' class='style10'>";
            c1 = new HtmlGenericControl();
            c1.InnerHtml = inht;
            Panel1.Controls.Add(c1);

            CheckBox chk = new CheckBox();
            //chk.Width = Unit.Pixel(150)
            chk.ID = ds.Tables[0].Rows[i][0].ToString();
            chk.Text = ds.Tables[0].Rows[i][1].ToString();
            Panel1.Controls.Add(chk);

            inht = "";
            inht = inht + "</td>";
            c1 = new HtmlGenericControl();
            c1.InnerHtml = inht;
            Panel1.Controls.Add(c1);

            rco = rco + 1;

            if (rco == 3 || i == ds.Tables[0].Rows.Count - 1)
            {
                for (int j = 1; j <= 3 - rco; j++)
                {
                    inht = "";
                    inht = inht + "<td width='230' align='left' valign='middle' class='style10'></td>";
                    c1 = new HtmlGenericControl();
                    c1.InnerHtml = inht;
                    Panel1.Controls.Add(c1);
                }
                inht = "";
                inht = inht + "</tr>";
                inht = inht + "</table>";
                inht = inht + "</td>";
                inht = inht + "</tr>";
                c1 = new HtmlGenericControl();
                c1.InnerHtml = inht;
                Panel1.Controls.Add(c1);
                rco = 0;
            }
        }
    }

    protected void boxchecked()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;

        CheckBox chkbox = new CheckBox();

        qry = "SELECT * from tbluserrights where staffid = " + Request.QueryString["staffid"] + "";
        ds = da.ExceuteSql(qry);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            foreach (Control c in Panel1.Controls)
            {
                chkbox = c.FindControl(ds.Tables[0].Rows[i][1].ToString()) as CheckBox;
                chkbox.Checked = true;
                break;
            }
        }
    }

    protected void showData()
    {
        string qry = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        qry = "SELECT * from tblstaff where intstaffid = " + Request.QueryString["staffid"] + "";
        ds = da.ExceuteSql(qry);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtFirstName.Value = ds.Tables[0].Rows[0]["strfirstname"].ToString();
            txtAddress.Value = ds.Tables[0].Rows[0]["straddress"].ToString();
            txtArea.Value = ds.Tables[0].Rows[0]["strarea"].ToString();
            city.Value = ds.Tables[0].Rows[0]["strtown"].ToString();
            txtCounty.Value = ds.Tables[0].Rows[0]["strcountry"].ToString();
            txtPin.Value = ds.Tables[0].Rows[0]["strpostcode"].ToString();
            txtPh.Value = ds.Tables[0].Rows[0]["strphone"].ToString();
            txtMobile.Value = ds.Tables[0].Rows[0]["strmobile"].ToString();
            txtFax1.Value = ds.Tables[0].Rows[0]["strfax"].ToString();
            txtEMail.Value = ds.Tables[0].Rows[0]["stremail"].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0]["strpassword"].ToString();
            txtConfirmPassword.Text = ds.Tables[0].Rows[0]["strpassword"].ToString();
            txtUserName.Value = ds.Tables[0].Rows[0]["strusername"].ToString();
            txtLastName.Value = ds.Tables[0].Rows[0]["strlastname"].ToString();
            if (ds.Tables[0].Rows[0]["intstatus"].ToString() == "1")
                optactive.Checked = true;
            else
                optdeactive.Checked  = true;
            txtPassword.TextMode = TextBoxMode.Password;
            txtConfirmPassword.TextMode = TextBoxMode.Password;
            txtPassword.Attributes.Add("Value", ds.Tables[0].Rows[0]["strpassword"].ToString());
            txtConfirmPassword.Attributes.Add("Value", ds.Tables[0].Rows[0]["strpassword"].ToString());
        }
    }
}
