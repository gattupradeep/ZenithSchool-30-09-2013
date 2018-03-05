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

public partial class school_Edit_subject_language_ExtraCurricular : System.Web.UI.Page
{
    public DataAccess da, da1;
    public string str, sql;
    public DataSet ds, ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillsubject();
            fillextracurricular();
            //filllanguages();
            //fillthirdlanguages();
            //fillgroups();
            if (Session["SEASLTLstandard"] != null)
                edit();

        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();

            str = "select intid from tblstandard_section_subject where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_subject", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }

            string sql = "delete tblstandard_section_subject where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(sql);

            for (int i = 0; i < chksubject.Items.Count; i++)
            {
                if (chksubject.Items[i].Selected == true)
                {
                    da = new DataAccess();
                    sql = "insert into tblstandard_section_subject(strstandard,strsection,strsubject,intschoolid)values('" + lblstandard.Text + "','" + lblsection.Text + "','" + chksubject.Items[i].Text + "'," + Session["SchoolID"] + ")";
                    da.ExceuteSqlQuery(sql);

                    DataSet ds2 = new DataSet();
                    sql = "select max(intid) as intid from tblstandard_section_subject";
                    ds2 = da.ExceuteSql(sql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_subject", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);
                }
            }
        }
        catch { }

        //try
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "delete tblstandard_section_language  where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        //    da.ExceuteSqlQuery(sql);

        //    for (int i = 0; i < chklanguages.Items.Count; i++)
        //    {
        //        if (chklanguages.Items[i].Selected == true)
        //        {
        //            da = new DataAccess();
        //            sql = "insert into tblstandard_section_language(strstandard,strsection,strlanguage2,intschoolid)values('" + lblstandard.Text + "','" + lblsection.Text + "','" + chklanguages.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
        //            da.ExceuteSqlQuery(sql);
        //        }
        //    }
        //}
        //catch { }

        //try
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "delete tblstandard_section_thirdlanguage  where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        //    da.ExceuteSqlQuery(sql);

        //    for (int i = 0; i < chkthirdlanguages.Items.Count; i++)
        //    {
        //        if (chkthirdlanguages.Items[i].Selected == true)
        //        {
        //            da = new DataAccess();
        //            sql = "insert into tblstandard_section_thirdlanguage(strstandard,strsection,strlanguage2,intschoolid)values('" + lblstandard.Text + "','" + lblsection.Text + "','" + chkthirdlanguages.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
        //            da.ExceuteSqlQuery(sql);
        //        }
        //    }
        //}
        //catch { }

        try
        {
            DataAccess da = new DataAccess();

            str = "select intid from tblstandard_section_extraCurricular where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_subject", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }

            string sql = "delete tblstandard_section_extraCurricular  where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(sql);

            for (int i = 0; i < chkextra.Items.Count; i++)
            {
                if (chkextra.Items[i].Selected == true)
                {
                    da = new DataAccess();
                    sql = "insert into tblstandard_section_extraCurricular(strstandard,strsection,strcurricular,intschoolid)values('" + lblstandard.Text + "','" + lblsection.Text + "','" + chkextra.Items[i].Text + "'," + Session["SchoolID"] + ")";
                    da.ExceuteSqlQuery(sql);


                    DataSet ds2 = new DataSet();
                    sql = "select max(intid) as intid from tblstandard_section_extraCurricular";
                    ds2 = da.ExceuteSql(sql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_extraCurricular", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);
                }
            }
        }
        catch { }

        //try
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "delete tblstandard_section_groups where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        //    da.ExceuteSqlQuery(sql);
        //    da = new DataAccess();
        //    sql = "insert into tblstandard_section_groups(strstandard,strsection,strgroup,intschoolid)values('" + lblstandard.Text + "','" + lblsection.Text + "','" + ddlgroup.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
        //    da.ExceuteSqlQuery(sql);
        //}
        //catch { }

        Response.Redirect("view_subject_language_ExtraCurricular.aspx?edit=1");
    }

    public void edit()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        sql = "select * from tblstandard_section_subject where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        {
            for (int i = 0; i < chksubject.Items.Count; i++)
            {
                if ( chksubject.Items[i].Value ==ds.Tables[0].Rows[j]["strsubject"].ToString())
                {
                    chksubject.Items[i].Selected = true;
                    str = " select * from dbo.tblschoolexampaper a,tblschoolexamsettings b where a.strsubject='" + chksubject.Items[i].Text + "' and b.strsubject='" + chksubject.Items[i].Text + "' and a.intschoolid=" + Session["SchoolID"].ToString();
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(str);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        chksubject.Items[i].Enabled = false;
                    }
                }
            }
        }

        sql = "select * from tblstandard_section_extraCurricular where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            for (int j = 0; j < chkextra.Items.Count; j++)
            {
                if (chkextra.Items[j].Value == ds.Tables[0].Rows[i]["strcurricular"].ToString())
                {
                    chkextra.Items[j].Selected = true;
                    //str = " select * from dbo.tblschoolexampaper where strcurricular='" + chkextra.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                    //da1 = new DataAccess();
                    //ds1 = new DataSet();
                    //ds1 = da1.ExceuteSql(str);
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    chkextra.Items[i].Enabled = false;
                    //}
                }
            }
        }

        //sql = "select * from tblstandard_section_language where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        //ds = new DataSet();
        //ds = da.ExceuteSql(sql);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    for (int j = 0; j < chklanguages.Items.Count; j++)
        //    {
        //        if (ds.Tables[0].Rows[i]["strlanguage2"].ToString() == chklanguages.Items[j].Value)
        //            chklanguages.Items[j].Selected = true;
        //    }
        //}

        //sql = "select * from tblstandard_section_thirdlanguage where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        //ds = new DataSet();
        //ds = da.ExceuteSql(sql);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    for (int j = 0; j < chkthirdlanguages.Items.Count; j++)
        //    {
        //        if (ds.Tables[0].Rows[i]["strlanguage2"].ToString() == chkthirdlanguages.Items[j].Value)
        //            chkthirdlanguages.Items[j].Selected = true;
        //    }
        //}

        //sql = "select * from tblstandard_section_groups where strstandard='" + Session["SEASLTLstandard"].ToString() + "' and strsection='" + Session["SEASLTLsection"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString();
        //ds = new DataSet();
        //ds = da.ExceuteSql(sql);
        //ddlgroup.SelectedValue = ds.Tables[0].Rows[0]["strgroup"].ToString();

        lblstandard.Text = Session["SEASLTLstandard"].ToString();
        lblsection.Text = Session["SEASLTLsection"].ToString();
    }

    private void fillsubject()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolsubject where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chksubject.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strsubject"].ToString(), ds.Tables[0].Rows[i]["strsubject"].ToString());
                chksubject.Items.Add(li);
            }
        }
        catch { }
    }

    private void fillextracurricular()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolExtracurricular where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chkextra.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strextracurricular"].ToString(), ds.Tables[0].Rows[i]["strextracurricular"].ToString());
                chkextra.Items.Add(li);
            }
        }
        catch { }
    }

    //private void fillgroups()
    //{
    //    try
    //    {
    //        string sql = "";
    //        ListItem li;
    //        DataSet ds = new DataSet();
    //        DataAccess da = new DataAccess();

    //        sql = "select strschoolgroupname from tblschoolgroup where intschoolid=" + Session["SchoolID"].ToString() + " group by strschoolgroupname";
    //        ds = da.ExceuteSql(sql);

    //        li = new ListItem("None", "None");
    //        ddlgroup.DataTextField = "strschoolgroupname";
    //        ddlgroup.DataValueField = "strschoolgroupname";
    //        ddlgroup.DataSource = ds;
    //        ddlgroup.DataBind();
    //        ddlgroup.Items.Insert(0, li);
    //    }
    //    catch { }
    //}

    //private void filllanguages()
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "select * from tblschoolLanguages where intschoolid="+ Session["SchoolID"].ToString();
    //        DataSet ds = new DataSet();
    //        ds = da.ExceuteSql(sql);
    //        chklanguages.Items.Clear();
    //        ListItem li;
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            li = new ListItem(ds.Tables[0].Rows[i]["strlanguagename"].ToString(), ds.Tables[0].Rows[i]["strlanguagename"].ToString());
    //            chklanguages.Items.Add(li);
    //        }
    //    }
    //    catch { }
    //}

    //private void fillthirdlanguages()
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "select * from tblschoolthirdLanguages where intschoolid=" + Session["SchoolID"].ToString();
    //        DataSet ds = new DataSet();
    //        ds = da.ExceuteSql(sql);
    //        chkthirdlanguages.Items.Clear();
    //        ListItem li;
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            li = new ListItem(ds.Tables[0].Rows[i]["strlanguagename"].ToString(), ds.Tables[0].Rows[i]["strlanguagename"].ToString());
    //            chkthirdlanguages.Items.Add(li);
    //        }
    //    }
    //    catch { }
    //}
}
