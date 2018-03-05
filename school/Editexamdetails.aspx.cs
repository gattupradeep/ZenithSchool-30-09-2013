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


public partial class school_Editexamdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard1();
            fillexamtype();
            fillpapers();
        }
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillexamtype();
        fillpapers();
    }

    protected void chksubject_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox list = (CheckBox)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DataGrid dgexamsettings = (DataGrid)item.FindControl("dgexamsettings");
        for (int i = 0; i < dgexamsettings.Items.Count; i++)
        {
            DataGridItem dgi = dgexamsettings.Items[i];
            CheckBox chkpaper = (CheckBox)dgi.FindControl("chkpaper");
            if (list.Checked)
                chkpaper.Checked = true;
            else
                chkpaper.Checked = false;
        }
    }

    protected void dgsubjects_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            DataRowView dr = (DataRowView)e.Item.DataItem;

            DataGrid dgpaper = (DataGrid)e.Item.FindControl("dgexamsettings");
            CheckBox chksubject = (CheckBox)e.Item.FindControl("chksubject");

            if (dr["active"].ToString() == "1")
                chksubject.Checked = true;

            else
                chksubject.Checked = false;

            str = "select strexampaper,100 as intmaxmark,35 as intpassmark,'0' as timedurationmin,'2' as timedurationhour, 0 as active from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + dr["strsubject"].ToString() + "' and strexampaper not in (select strexampapername from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + dr["strsubject"].ToString() + "' and strexamtype='" + ddlexamtype.SelectedValue + "') union all ";
            str = str + "select strexampapername,intmaxmark,intpassmark,timedurationmin,timedurationhour, 1 as active from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + dr["strsubject"].ToString() + "' and strexamtype='" + ddlexamtype.SelectedValue + "'";
            ds = da.ExceuteSql(str);
            dgpaper.DataSource = ds;
            dgpaper.DataBind();
        }
        catch { }
    }

    protected void dgexamsettings_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;

            TextBox txtmax = (TextBox)e.Item.FindControl("txtmaxmarks");
            TextBox txtpass = (TextBox)e.Item.FindControl("txtpassmark");

            DropDownList ddlhour = (DropDownList)e.Item.FindControl("ddlhour");

            CheckBox chkpaper = (CheckBox)e.Item.FindControl("chkpaper");
            if (dr["active"].ToString() == "1")
                chkpaper.Checked = true;
            else
                chkpaper.Checked = false;
            int j = 0;
            ListItem li;
            for (int i = 0; i <= 12; i++)
            {
                if (i < 10)
                {
                    li = new ListItem("0" + i.ToString(), i.ToString());
                }
                else
                {
                    li = new ListItem(i.ToString(), i.ToString());
                }
                ddlhour.Items.Add(li);
                j++;
            }

            DropDownList ddlmin = (DropDownList)e.Item.FindControl("ddlmin");
            for (int i = 0; i <= 55; i = i + 5)
            {
                if (i < 10)
                {
                    li = new ListItem("0" + i.ToString(), i.ToString());
                }
                else
                {
                    li = new ListItem(i.ToString(), i.ToString());
                }
                ddlmin.Items.Add(li);
                j++;
            }

            ddlhour.SelectedValue = dr["timedurationhour"].ToString();
            ddlmin.SelectedValue = dr["timedurationmin"].ToString();

            txtmax.Text = dr["intmaxmark"].ToString();
            txtpass.Text = dr["intpassmark"].ToString();
        }
        catch { }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("examdetails.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int k = 0;
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();

        strsql = "select intschoolexamsettingsid from tblschoolexamsettings where strexamtype='" + ddlexamtype.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolexamsettings", ds.Tables[0].Rows[0]["intschoolexamsettingsid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),45);

            }
        }

        strsql = "delete tblschoolexamsettings where strexamtype='" + ddlexamtype.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";
        da.ExceuteSqlQuery(strsql);
        for (int l = 0; l < dgsubjects.Items.Count; l++)
        {
            DataGridItem dgsub = dgsubjects.Items[l];
            DataGrid dgexamsettings = (DataGrid)dgsub.FindControl("dgexamsettings");
            for (int i = 0; i < dgexamsettings.Items.Count; i++)
            {
                k++;
                DataGridItem dgi = dgexamsettings.Items[i];
                DropDownList ddlhh = (DropDownList)dgi.FindControl("ddlhour");
                DropDownList ddlmm = (DropDownList)dgi.FindControl("ddlmin");
                TextBox txtmax = (TextBox)dgi.FindControl("txtmaxmarks");
                TextBox txtpass = (TextBox)dgi.FindControl("txtpassmark");
                CheckBox chkpaper = (CheckBox)dgi.FindControl("chkpaper");
                if (chkpaper.Checked)
                {
                    strsql = " insert into tblschoolexamsettings (intschoolid,intstaffid,strclass,strexamtype,strpaper,strsubject,strexampapername,intmaxmark,intpassmark,timedurationhour,timedurationmin)";
                    strsql = strsql + "  values(" + Session["SchoolID"].ToString() + "," + Session["UserID"].ToString() + ",'" + ddlstandard.SelectedValue + "','" + ddlexamtype.SelectedValue + "','Paper " + k.ToString() + "',";
                    strsql = strsql + "'" + dgsub.Cells[0].Text + "','" + dgi.Cells[0].Text + "','" + txtmax.Text + "','" + txtpass.Text + "',";
                    strsql = strsql + " '" + ddlhh.SelectedValue + "','" + ddlmm.SelectedValue + "')";
                    da.ExceuteSqlQuery(strsql);

                    DataSet ds2 = new DataSet();
                    strsql = "select max(intschoolexamsettingsid) as intschoolexamsettingsid from tblschoolexamsettings";
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolexamsettings", ds2.Tables[0].Rows[0]["intschoolexamsettingsid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),45);

                }
            }
        }

        Session["SProfileIndex"] = 9;
        Response.Redirect("../school/examdetails.aspx");
    }

    protected void fillstandard1()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select strclass from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " group by strclass";
        ds = da.ExceuteSql(sql);

        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataSource = ds;
        ddlstandard.DataBind();
        ddlstandard.SelectedValue = Session["examstandard"].ToString();
    }

    protected void fillexamtype()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strexamtype from tblschoolexamsettings where intschoolid='" + Session["SchoolID"].ToString() + "' and strclass='" + ddlstandard.SelectedValue + "' group by strexamtype";
        ds = da.ExceuteSql(sql);

        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataBind();
        ddlexamtype.SelectedValue = Session["examtype"].ToString();
    }

    protected void fillpapers()
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            str = "select strsubject, 0 as active from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject not in (select strsubject from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "') group by strsubject union all ";
            str = str + "select strsubject, 1 as active from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "' group by strsubject";
            ds = da.ExceuteSql(str);

            dgsubjects.DataSource = ds;
            dgsubjects.DataBind();
        }
        catch 
        { 
        }
    }
}
