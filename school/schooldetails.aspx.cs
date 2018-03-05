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

public partial class school_schooldetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlcountry();
            fillgroups();
            fillboard();
            fillclasstype();
            //fillhousenameandcolor();
            trgroup.Visible = false;
            
            if (Request["sid"] != null)
                filldetails();
            else
                filldetails1();
        }
        txtEmail.Attributes.Add("onblur", "document.getElementById('" + chkemail.UniqueID + "').click();");
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillcountrycode();
            fillddlstate();
            fillddlcity();
        }
        catch 
        { 
        }
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillddlcity();
            fillcitycode();
        }
        catch { }
    }

    protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lblcitycheck.Text != ddlcity.SelectedValue + "-" + txtcitycode.Text)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Check City Code!')", true);
    }

    protected void chkemail_Click(object sender, ImageClickEventArgs e)
    {
        DataAccess da = new DataAccess();
        string str = "select * from tblschool where stremailid='" + txtEmail.Text + "' and intschoolid <>" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblemailmsg.Text = "Email ID Already Registered with us.";
            lblemailmsg.Visible = true;
        }
        else
        {
            lblemailmsg.Text = "";
            lblemailmsg.Visible = false;
        }
    }

    protected void btngroup_Click1(object sender, EventArgs e)
    {
        Session["SelectedGroups"] = selectedgroups();
        try
        {
            if (txtgroup.Text != "")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                string sql = "insert into tblgroup(strgroup)values('" + txtgroup.Text + "')";
                DataAccess da = new DataAccess();
                da.ExceuteSqlQuery(sql);
                fillgroups();
                fillgroups1();
                txtgroup.Text = "";

                DataSet ds2 = new DataSet();
                sql = "select max(intgroupid) as intgroupid from tblgroup";
                ds2 = da.ExceuteSql(sql);
                Functions.UserLogs(Session["UserID"].ToString(), "tblgroup", ds2.Tables[0].Rows[0]["intgroupid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),26);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Group Name Already Exists!')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../school/viewschooldetails.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int dtacst = DateTime.Parse(txtstart.Text).Year;
        int dtacet = DateTime.Parse(txtend.Text).Year;
        int eyear = int.Parse(txtyear.Text);
        if (dtacst < eyear)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Academic Start Year Less than Year Established!')", true);
        }
        else if (dtacet < eyear)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Academic End Year Less than Year Established!')", true);
        }
        else if (DateTime.Parse(txtstart.Text) > DateTime.Parse(txtend.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Academic Start Year Greater than Academic End Year!')", true);
        }
        else if (ddlboard.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the Board!')", true);
        }
        else if (ddlcountry.SelectedIndex == 0)
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
        else if (ddlclasstype.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the Class Type!')", true);
        }
        else
        {
            DataAccess da = new DataAccess();
            string str = "select * from tblschool where stremailid='" + txtEmail.Text + "' and intschoolid =" + Session["SchoolID"].ToString();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblemailmsg.Text = "Email ID Already Registered with us.";
                lblemailmsg.Visible = true;
            }
            else
            {
                lblemailmsg.Text = "";
                lblemailmsg.Visible = false;
            }

            if (lblemailmsg.Text == "")
            {
                try
                {
                    SqlCommand command;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                    conn.Open();
                    command = new SqlCommand("spdetails", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@strschoolname", txtschoolname.Text.Trim());
                    command.Parameters.Add("@intyear", txtyear.Text.Trim());
                    command.Parameters.Add("@intboard", ddlboard.SelectedValue);
                    command.Parameters.Add("@strclasstype", ddlclasstype.SelectedValue);
                    if (selectedgroups().Length > 0)
                        command.Parameters.Add("@strgpavailable", selectedgroups());
                    else
                        command.Parameters.Add("@strgpavailable", "0");
                    command.Parameters.Add("@dtaccyearstart", txtstart.Text.Trim());
                    command.Parameters.Add("@dtaccyearend", txtend.Text.Trim());
                    if (rbty.Checked)
                        str = "1";
                    else
                        str = "0";
                    command.Parameters.Add("@inttransport", str);
                    string str1;
                    if (rbhy.Checked)
                        str1 = "1";
                    else
                        str1 = "0";
                    command.Parameters.Add("@inthostelfecility", str1);
                    command.Parameters.Add("@straddress", txtaddr.Text.Trim());
                    command.Parameters.Add("@intcountry", ddlcountry.SelectedValue);
                    command.Parameters.Add("@intstate", ddlstate.SelectedValue);
                    command.Parameters.Add("@intcity", ddlcity.SelectedValue);
                    command.Parameters.Add("@strpincode", txtzip.Text.Trim());
                    command.Parameters.Add("@stremail", txtEmail.Text.Trim());
                    command.Parameters.Add("@strphone", txtphone.Text.Trim());
                    command.Parameters.Add("@strwebsite", txtweb.Text.Trim());
                    command.Parameters.Add("@strfax", txtfax.Text.Trim());
                    command.Parameters.Add("@strbranch", txtbranch.Text.Trim());
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.Parameters.Add("@strcountrycode", txtcountrycode.Text.Trim());
                    command.Parameters.Add("@strcitycode", txtcitycode.Text.Trim());
                    command.Parameters.Add("@strmedium", ddlmedium.SelectedValue);
                    int L = 0;
                    if (rbLy.Checked == true)
                        L = 1;
                    else
                        if (rbLn.Checked == true)
                            L = 0;
                    command.Parameters.Add("@intlibrary", L);
                    command.ExecuteNonQuery();
                    conn.Close();
                    savegroups();
                    //selectedhousename();
                    if (btnSave.Text == "Update")
                        Response.Redirect("../school/viewschooldetails.aspx");
                    else
                        Response.Redirect("../school/timingsandperiods.aspx");
                }
                catch (Exception ex)
                {
                    msgbox.alert(ex.Message);
                }
            }
        }
    }

    private void fillddlcountry()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblcountry order by strcountryname";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcountry.DataSource = ds;
        ddlcountry.DataTextField = "strcountryname";
        ddlcountry.DataValueField = "intcountryid";
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, "-Select-");
    }

    private void fillddlstate()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblstate where intcountryid=" + ddlcountry.SelectedValue + " order by strstate";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "strstate";
        ddlstate.DataValueField = "intstateid";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, "-Select-");
    }

    private void fillddlcity()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblcity where intstateid=" + ddlstate.SelectedValue + " order by strcity";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcity.Items.Clear();
        ddlcity.DataSource = ds;
        ddlcity.DataTextField = "strcity";
        ddlcity.DataValueField = "intcityid";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, "-Select-");
    }

    private void fillboard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblboard";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlboard.DataSource = ds;
        ddlboard.DataTextField = "strboardname";
        ddlboard.DataValueField = "intboardid";
        ddlboard.DataBind();
        ddlboard.Items.Insert(0, "-Select-");
    }    

    private void fillclasstype()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblclasstype";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlclasstype.DataSource = ds;
        ddlclasstype.DataTextField = "strclasstype";
        ddlclasstype.DataValueField = "strclasstype";
        ddlclasstype.DataBind();
        ddlclasstype.Items.Insert(0, "-Select-");
    }

    protected void fillgroups()
    {
        string qry = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        qry = "select * from tblgroup order by strgroupname";
        ds = new DataSet();
        ds = da.ExceuteSql(qry);
        chkgroups.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strgroupname"].ToString(), ds.Tables[0].Rows[i]["intgroupid"].ToString());
            chkgroups.Items.Add(li);
        }
    }

    protected void fillgroups1()
    {
        try
        {
            for (int i = 0; i < chkgroups.Items.Count; i++)
            {
                string[] abc = Session["SelectedGroups"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chkgroups.Items[i].Value.ToString() == abc[j].Trim())
                        chkgroups.Items[i].Selected = true;
                }
            }
        }
        catch { }
    }

    protected string selectedgroups()
    {
        string str = "";
        for (int i = 0; i < chkgroups.Items.Count; i++)
        {
            if (chkgroups.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkgroups.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkgroups.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected void filldetails()
    {
        string str = "";
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select *,convert(varchar(10),dtaccyearstart,111) as dtstart,convert(varchar(10),dtaccyearend,111) as dtend from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtschoolname.Text = ds.Tables[0].Rows[0]["strschoolname"].ToString();
            txtyear.Text = ds.Tables[0].Rows[0]["intyear"].ToString();
            txtbranch.Text = ds.Tables[0].Rows[0]["strbranch"].ToString();
            ddlboard.SelectedValue = ds.Tables[0].Rows[0]["intboardid"].ToString();
            ddlclasstype.SelectedValue = ds.Tables[0].Rows[0]["strclasstype"].ToString();
            txtstart.Text = ds.Tables[0].Rows[0]["dtstart"].ToString();
            txtend.Text = ds.Tables[0].Rows[0]["dtend"].ToString();
            txtaddr.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
            ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["intcountryid"].ToString();
            fillddlstate();
            ddlstate.SelectedValue = ds.Tables[0].Rows[0]["intstateid"].ToString();
            fillddlcity();
            ddlcity.SelectedValue = ds.Tables[0].Rows[0]["intcityid"].ToString();
            txtzip.Text = ds.Tables[0].Rows[0]["strpincode"].ToString();
            txtphone.Text = ds.Tables[0].Rows[0]["strphone"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["stremail"].ToString();
            txtfax.Text = ds.Tables[0].Rows[0]["strfax"].ToString();
            txtweb.Text = ds.Tables[0].Rows[0]["strwebsite"].ToString();
            ddlmedium.SelectedValue = ds.Tables[0].Rows[0]["strmedium"].ToString();
            if (int.Parse(ds.Tables[0].Rows[0]["inttransport"].ToString()) == 1)
                rbty.Checked = true;
            else
                rbtn.Checked = true;
            if (int.Parse(ds.Tables[0].Rows[0]["inthostelfecility"].ToString()) == 1)
                rbhy.Checked = true;
            else
                rbhn.Checked = true;
            if (int.Parse(ds.Tables[0].Rows[0]["intlibrary"].ToString()) == 1)
                rbLy.Checked = true;
            else
                rbLn.Checked = true;
            txtcitycode.Text = ds.Tables[0].Rows[0]["strcitycode"].ToString();
            txtcountrycode.Text = ds.Tables[0].Rows[0]["strcountrycode"].ToString();
            lblcitycheck.Text = ds.Tables[0].Rows[0]["intcityid"].ToString() + "-" + ds.Tables[0].Rows[0]["strcitycode"].ToString();
        }

        str = "select * from tblschoolgroup where intschoolid = " + Session["SchoolID"];
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < chkgroups.Items.Count; i++)
                {
                    if (chkgroups.Items[i].Text == ds.Tables[0].Rows[j]["strschoolgroupname"].ToString())
                        chkgroups.Items[i].Selected = true;
                }
            }
        }
                
        btnSave.Text = "Update";
        btnCancel.Visible = true;
        txtstart.Enabled = false;
        txtend.Enabled = false;
    }

    protected void filldetails1()
    {
        try
        {
            string str = "";
            DataSet ds;
            DataAccess da = new DataAccess();
            str = "select * from tblschool where intschoolid=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtschoolname.Text = ds.Tables[0].Rows[0]["strschoolname"].ToString();
                txtaddr.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
                ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["intcountryid"].ToString();
                fillcountrycode();
                fillddlstate();
                ddlstate.SelectedValue = ds.Tables[0].Rows[0]["intstateid"].ToString();
                fillddlcity();
                ddlcity.SelectedValue = ds.Tables[0].Rows[0]["intcityid"].ToString();
                txtcitycode.Text = ds.Tables[0].Rows[0]["strcitycode"].ToString();
                txtzip.Text = ds.Tables[0].Rows[0]["strzipcode"].ToString();
                txtphone.Text = ds.Tables[0].Rows[0]["strphoneno"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["stremailid"].ToString();
                lblcitycheck.Text = ds.Tables[0].Rows[0]["intcityid"].ToString() + "-" + ds.Tables[0].Rows[0]["strcitycode"].ToString();
            }
        }
        catch (Exception ex)
        {
            msgbox.alert(ex.Message);
        }
    }

    protected void savegroups()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            qry = "delete tblschoolgroup where intschoolid =" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgroup", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),26);
            da.ExceuteSqlQuery(qry);
            for (int i = 0; i <chkgroups.Items.Count; i++)
            {
                if (chkgroups.Items[i].Selected == true)
                {
                    qry = "";
                    da = new DataAccess();
                    qry = "insert into tblschoolgroup(strschoolgroupname,intschoolid)values('" + chkgroups.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(qry);

                    DataSet ds2 = new DataSet();
                    qry = "select max(intschoolgroupid) as intschoolgroupid from tblschoolgroup";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgroup", ds2.Tables[0].Rows[0]["intschoolgroupid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),26);
                }
            }
        }
        catch { }
    }

    protected void fillcountrycode()
    {
        string qry = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        qry = "select intcode from tblcountry where intcountryid=" + ddlcountry.SelectedValue;
        ds = da.ExceuteSql(qry);
        if (ds.Tables[0].Rows.Count > 0)
            txtcountrycode.Text = ds.Tables[0].Rows[0]["intcode"].ToString();
    }

    protected void fillcitycode()
    {
        string qry = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        qry = "select intcode from tblcity where intcityid=" + ddlcity.SelectedValue;
        ds = da.ExceuteSql(qry);
        if (ds.Tables[0].Rows.Count > 0)
            txtcitycode.Text = ds.Tables[0].Rows[0]["intcode"].ToString();
    }

    //protected void addhousename_Click1(object sender, EventArgs e)
    //{
    //    Session["SelectedHousenames"] = selectedhouse();
    //    if ((txthousename.Text != "") && (txthousecolor.Text != ""))
    //    {
    //        try
    //        {
    //            string qry;
    //            DataAccess da = new DataAccess();
    //            DataSet ds = new DataSet();
    //            qry = "select * from tblhousemaster where strhousename='" + txthousename.Text.ToString() + "'";
    //            ds=da.ExceuteSql(qry);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('House Name Already Exists!')", true);
    //            }
    //            else
    //            {
    //                da = new DataAccess();
    //                qry = "insert into tblhousemaster(strhousename,strhousecolor)values('" + txthousename.Text.ToString() + "','" + txthousecolor.Text.ToString() + "')";
    //                da.ExceuteSqlQuery(qry);
    //                txthousename.Text = "";
    //                txthousecolor.Text = "";
    //                fillhousenameandcolor();
    //                fillhousenameandcolor1();
    //            }
    //        }
    //        catch
    //        {
    //        }
    //    }

    //}

    //protected void fillhousenameandcolor1()
    //{
    //    try
    //    {
    //        for (int i = 0; i < chkhousename.Items.Count; i++)
    //        {
    //            string[] abc = Session["SelectedHousenames"].ToString().Split(',');
    //            for (int j = 0; j < abc.Length; j++)
    //            {
    //                if (chkhousename.Items[i].Value.ToString() == abc[j].Trim())
    //                    chkhousename.Items[i].Selected = true;
    //            }
    //        }
    //    }
    //    catch { }
    //}

    //protected string selectedhouse()
    //{
    //    string str = "";
    //    for (int i = 0; i < chkhousename.Items.Count; i++)
    //    {
    //        if (chkhousename.Items[i].Selected == true)
    //        {
    //            if (str.Length == 0)
    //            {
    //                str = chkhousename.Items[i].Value.ToString();
    //            }
    //            else
    //            {
    //                str = str + "," + chkhousename.Items[i].Value.ToString();
    //            }
    //        }
    //    }
    //    return str;
    //}


    //protected void selectedhousename()
    //{
    //    string qry = "";
    //    DataAccess da = new DataAccess();
    //    qry = "delete tblschoolhouse where intschool=" + Session["SchoolID"].ToString();
    //    da.ExceuteSqlQuery(qry);
    //    for (int i = 0; i < chkhousename.Items.Count; i++)
    //    {

    //        if (chkhousename.Items[i].Selected == true)
    //        {
    //            qry = "";
    //            da = new DataAccess();
    //            qry = "insert into tblschoolhouse(strhousename,intschool)values('" + chkhousename.Items[i].Value + "'," + Session["SchoolID"].ToString() + ")";
    //            da.ExceuteSqlQuery(qry);
    //        }
    //    }
    //}

    //protected void fillhousenameandcolor()
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "select intid, strhousename + ' / ' +  strhousecolor as housenameandcolor from tblhousemaster ";
    //    DataSet ds = new DataSet();
    //    ds = da.ExceuteSql(sql);
    //    chkhousename.Items.Clear();
    //    ListItem li;
    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        li = new ListItem(ds.Tables[0].Rows[i]["housenameandcolor"].ToString(), ds.Tables[0].Rows[i]["housenameandcolor"].ToString());
    //        chkhousename.Items.Add(li);
    //    }
    //}
            
}
