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

public partial class school_examdetailsettings : System.Web.UI.Page
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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("examdetails.aspx");
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
        DataRowView dr = (DataRowView)e.Item.DataItem;

        DataGrid dgpaper = (DataGrid)e.Item.FindControl("dgexamsettings");
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            str = "select strexampaper,100 as intmaxmark,35 as intpassmark,'0' as timedurationmin,'2' as timedurationhour from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + dr["strsubject"].ToString() + "'";
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
        }
        catch { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int examtype = 0;
        int hr = 0;
        int marks = 0;
        int paper = 0;

        string strsql = "";
        DataAccess da = new DataAccess();

        for (int j = 0; j < chkexamtype.Items.Count; j++)
        {
            if (chkexamtype.Items[j].Selected == true)
            {
                examtype = 1;
                int k = 0;
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
                        if (ddlhh.SelectedIndex == 0 && ddlmm.SelectedIndex == 0)
                            hr = 1;
                        TextBox txtmax = (TextBox)dgi.FindControl("txtmaxmarks");
                        TextBox txtpass = (TextBox)dgi.FindControl("txtpassmark");
                        if (int.Parse(txtmax.Text) == 0 || int.Parse(txtpass.Text) == 0 || int.Parse(txtmax.Text) < int.Parse(txtpass.Text))
                            marks = 1;

                        CheckBox chkpaper = (CheckBox)dgi.FindControl("chkpaper");
                        if (chkpaper.Checked)
                            paper = 1;
                    }
                }
            }
        }
        if (hr == 1)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Hours')", true);
        else if (marks == 1)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Marks')", true);
        else if (examtype == 0)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select Atleast One Exam Type')", true);
        else if (paper == 0)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select Papers')", true);
        else
        {
            for (int j = 0; j < chkexamtype.Items.Count; j++)
            {
                if (chkexamtype.Items[j].Selected == true)
                {
                    examtype = 1;
                    int k = 0;
                    DataSet ds = new DataSet();
                    strsql = "select intschoolexamsettingsid from tblschoolexamsettings where strexamtype='" + chkexamtype.Items[j].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";
                    ds = da.ExceuteSql(strsql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolexamsettings", ds.Tables[0].Rows[0]["intschoolexamsettingsid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),45);

                        }
                    }


                    strsql = "delete tblschoolexamsettings where strexamtype='" + chkexamtype.Items[j].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "'";
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
                            if (ddlhh.SelectedIndex == 0 && ddlmm.SelectedIndex == 0)
                                hr = 1;
                            TextBox txtmax = (TextBox)dgi.FindControl("txtmaxmarks");
                            TextBox txtpass = (TextBox)dgi.FindControl("txtpassmark");
                            if (int.Parse(txtmax.Text) == 0 || int.Parse(txtpass.Text) == 0 || int.Parse(txtmax.Text) < int.Parse(txtpass.Text))
                                marks = 1;

                            CheckBox chkpaper = (CheckBox)dgi.FindControl("chkpaper");
                            if (chkpaper.Checked)
                            {
                                paper = 1;
                                if (hr == 0 && marks == 0)
                                {
                                    strsql = " insert into tblschoolexamsettings (intschoolid,intstaffid,strclass,strexamtype,strpaper,strsubject,strexampapername,intmaxmark,intpassmark,timedurationhour,timedurationmin)";
                                    strsql = strsql + "  values(" + Session["SchoolID"].ToString() + "," + Session["UserID"].ToString() + ",'" + ddlstandard.SelectedValue + "','" + chkexamtype.Items[j].ToString() + "','Paper " + k.ToString() + "',";
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
                    }
                }
            }
            //Session["SProfileIndex"] = 9;
            //Response.Redirect("../school/viewschooldetails.aspx");
            redirectpages();
        }
        
    }

    protected void fillstandard1()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        sql = "select strstandard + ' - ' + strsection as strclass from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        ds = da.ExceuteSql(sql);
        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataSource = ds;
        ddlstandard.DataBind();
    }

    protected void fillexamtype()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select strexamtype from tblexamorder where intschoolid=" + Session["SchoolID"].ToString() + " and strexamtype not in (select strexamtype from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' group by strexamtype)";
        ds = da.ExceuteSql(sql);
        chkexamtype.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strexamtype"].ToString(), i.ToString());
            chkexamtype.Items.Add(li);
        }
    }

    protected void fillpapers()
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            str = "select strsubject from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' group by strsubject";
            ds = da.ExceuteSql(str);
            dgsubjects.DataSource = ds;
            dgsubjects.DataBind();
        }
        catch { }
    }
    
    protected int getexamtypes()
    {
        int i = 0;
        for (int j = 0; j < chkexamtype.Items.Count; j++)
        {
            if (chkexamtype.Items[j].Selected == true)
            {
                i++;
            }
        }
        return i;
    }
    protected void redirectpages()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        Session["UserRights"] = "No";

        sql = "select * from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        Session["SProfileIndex"] = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            sql = "select * from tbltimingsandperiods where intschoolid = " + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            Session["SProfileIndex"] = 2;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sql = "select * from tblworkingdays where intschoolid = " + Session["SchoolID"].ToString();
                ds = new DataSet();
                ds = da.ExceuteSql(sql);
                Session["SProfileIndex"] = 3;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "select * from tblschoolstandard where intschoolid = " + Session["SchoolID"].ToString();
                    ds = new DataSet();
                    ds = da.ExceuteSql(sql);
                    Session["SProfileIndex"] = 4;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sql = "select * from tblstandard_section_subject where intschoolid = " + Session["SchoolID"].ToString();
                        ds = new DataSet();
                        ds = da.ExceuteSql(sql);
                        Session["SProfileIndex"] = 5;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sql = "select * from tblexamorder where intschoolid = " + Session["SchoolID"].ToString();
                            ds = new DataSet();
                            ds = da.ExceuteSql(sql);
                            Session["SProfileIndex"] = 6;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "select * from tblschoolexampaper where intschoolid = " + Session["SchoolID"].ToString();
                                ds = new DataSet();
                                ds = da.ExceuteSql(sql);
                                Session["SProfileIndex"] = 7;
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sql = "select * from tblschoolexamsettings where intschoolid = " + Session["SchoolID"].ToString();
                                    ds = new DataSet();
                                    ds = da.ExceuteSql(sql);
                                    Session["SProfileIndex"] = 8;
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        sql = "select * from tblschoolgrading where intschoolid = " + Session["SchoolID"].ToString();
                                        ds = new DataSet();
                                        ds = da.ExceuteSql(sql);
                                        Session["SProfileIndex"] = 9;
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            Session["SProfileIndex"] = 10;
                                            Session["UserRights"] = "Yes";
                                            Response.Redirect("../school/viewschooldetails.aspx");
                                        }
                                        else
                                            Response.Redirect("../school/schoolgrading.aspx");
                                    }
                                    else
                                        Response.Redirect("../school/examdetailsettings.aspx");
                                }
                                else
                                    Response.Redirect("../school/assignexampapers.aspx");
                            }
                            else
                                Response.Redirect("../school/assignexamtypes.aspx");
                        }
                        else
                            Response.Redirect("../school/subject_language_ExtraCurricular.aspx");
                    }
                    else
                        Response.Redirect("../school/Class_Section_Subject_Details.aspx");
                }
                else
                    Response.Redirect("../school/workingdays.aspx");
            }
            else
                Response.Redirect("../school/timingsandperiods.aspx");
        }
        else
            Response.Redirect("../school/schooldetails.aspx");
    }
    


 }
