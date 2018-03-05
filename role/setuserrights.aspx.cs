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

public partial class role_setuserrights : System.Web.UI.Page
{
    public string staffhead, inht;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillusertype();
            fillstaff();
        }
        FillModules();
    }
    protected void fillusertype()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string strsql = "select * from tblstafftype order by intid";
        ds = da.ExceuteSql(strsql);
        ddltype.DataSource = ds;
        ddltype.DataValueField = "strstafftype";
        ddltype.DataTextField = "strstafftype";
        ddltype.DataBind();
    }
    private void fillstaff()
    {
        DataAccess da = new DataAccess();
        string sql = "select intid, strfirstname + ' ' + strmiddlename + ' ' + strlastname as staffname from tblemployee where strtype='" + ddltype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlstaff.DataSource = ds;
        ddlstaff.DataTextField = "staffname";
        ddlstaff.DataValueField = "intid";
        ddlstaff.Items.Clear();
        ddlstaff.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlstaff.Items.Insert(0, li);
        if (ds.Tables[0].Rows.Count > 0)
        {
            FillModules();
            boxchecked();
            ddlstaff.Enabled = true;
        }
        else
        {
            ddlstaff.Enabled = false;
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (ddlstaff.SelectedIndex > 0)
            SaveRights();
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select a Staff!')", true);
    }

    protected void SaveRights()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;

        DataAccess dau = new DataAccess();
        DataSet dsu = new DataSet();
        qry = "select intuserrightid from tbluserrights where intstaffid = " + ddlstaff.SelectedValue + " and intschoolid=" + Session["SchoolID"].ToString();
        dsu = dau.ExceuteSql(qry);
        if (dsu.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < dsu.Tables[0].Rows.Count; j++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tbluserrights", dsu.Tables[0].Rows[j]["intuserrightid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 108);
            }
        }
        qry = "delete from tbluserrights where intstaffid = " + ddlstaff.SelectedValue + " and intschoolid=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(qry);

        qry = "SELECT menuid from tblmenus where parentmenu<>99";
        ds = da.ExceuteSql(qry);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            CheckBox chkbox = new CheckBox();
            foreach (Control c in Panel1.Controls)
            {
                chkbox = (CheckBox)c.FindControl(ds.Tables[0].Rows[i][0].ToString());
                break;
            }
            try
            {
                if (chkbox.Checked == true)
                {
                    qry = "insert into tbluserrights(menuid,intstaffid,intschoolid) values (" + ds.Tables[0].Rows[i][0].ToString() + "," + ddlstaff.SelectedValue + "," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(qry);
                    DataSet ds2 = new DataSet();
                    qry = "select max(intuserrightid) as intuserrightid from tbluserrights";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tbluserrights", ds2.Tables[0].Rows[0]["intuserrightid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),108);
                }
            }
            catch { }
        }
    }

    protected void FillModules()
    {
        HtmlGenericControl c = new HtmlGenericControl();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;
        string inht;
        Panel1.Controls.Clear();
        qry = "SELECT menuid,menuname from tblmenus where parentmenu in(0)";
        if (ddltype.SelectedValue == "Teaching Staffs")
        {
            qry += " and intIsMenuTeachingStaff=0";
        }
        else
        {
            qry += " and intIsMenuOthers=0";
        }
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

        qry = "SELECT menuid,menuname,dropdownmenu from tblmenus where parentmenu =" + parentid + " and dropdownmenu = 1";
        if (ddltype.SelectedValue == "Teaching Staffs")
        {
            qry += " and intIsMenuTeachingStaff=0";
        }
        else
        {
            qry += " and intIsMenuOthers=0";
        }
        ds = da.ExceuteSql(qry);
        int n = 0;
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
            //if (parentid == 1 && n == 1)
            //{
            //}
            //else
                FillMiniModules(int.Parse(ds.Tables[0].Rows[i][0].ToString()), int.Parse(ds.Tables[0].Rows[i][2].ToString()));
            //if (parentid == 1)
            //    n = 1;
        }
    }

    protected void FillMiniModules(int parentid, int ddm)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string qry;
        int rco;
        rco = 0;

        qry = "SELECT menuid,menuname from tblmenus where parentmenu =" + parentid + " and dropdownmenu = 1 and menuurl <> 'Side Menu'";
        if (ddltype.SelectedValue == "Teaching Staffs")
        {
            qry += " and intIsMenuTeachingStaff=0";
        }
        else
        {
            qry += " and intIsMenuOthers=0";
        }
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


        qry = "SELECT * from tbluserrights where intstaffid=" + ddlstaff.SelectedValue + " and intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(qry);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
        {
            qry = "SELECT * from tbldefaultuserrights where stafftype='" + ddltype.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            da = new DataAccess();
            ds = da.ExceuteSql(qry);
        }

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            foreach (Control c in Panel1.Controls)
            {
                try
                {
                    chkbox = c.FindControl(ds.Tables[0].Rows[i][1].ToString()) as CheckBox;
                    chkbox.Checked = true;
                    break;
                }
                catch { }
            }
        }
    }

    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillModules();
            boxchecked();
        }
        catch { }
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstaff();
    }
}
