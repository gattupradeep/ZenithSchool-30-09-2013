using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class school_view_subject_language_ExtraCurricular : System.Web.UI.Page
{
    //public string str;
    //public DataSet ds, ds1;
    //public DataAccess da;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["PatronType"].ToString() != "Admin" && Session["PatronType"].ToString() != "Super Admin")
            {
                btnedit.Visible = false;
                btnadd.Visible = false;
            }
        }
        catch
        {
            Response.Redirect("../login.aspx");
        }

        if (!IsPostBack)
        {
            if (Request["view"] != null)
            {
                fillclasstype();
                ddlclass.SelectedValue = Session["ViewSLEAstd"].ToString();
                fillsection();
                ddlsection.SelectedValue = Session["ViewSLEAsec"].ToString();
                filldgstandard();
            }
            else
            {
                setnext();
                fillclasstype();
                fillsection();
                filldgstandard2();
            }
            if (Request["edit"] != null)
            {
                fillclasstype();
                ddlclass.SelectedValue = Session["SEASLTLstandard"].ToString();
                fillsection();
                ddlsection.SelectedValue = Session["SEASLTLsection"].ToString();
                filldgstandard2();
            }
        }
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsection();
        filldgstandard2();
    }

    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldgstandard2();
    }

    protected void btnedit_Click2(object sender, EventArgs e)
    {
        Session["SEASLTLstandard"] = ddlclass.SelectedValue;
        Session["SEASLTLsection"] = ddlsection.SelectedValue;
        Response.Redirect("Edit_subject_language_ExtraCurricular.aspx");
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataAccess da = new DataAccess();

        try
        {
            sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);

            ListItem li;
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sql = "select strsection from tblschoolsection where intschoolid=" + Session["SchoolID"].ToString() + " and strsection not in(select strsection from tblstandard_section_subject where strstandard='" + ds.Tables[0].Rows[i]["strstandard"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString() + " group by strsection) order by strsection";
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    j++;
                }
            }
            if (j == 0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('All Standard & Sections Assigned!')", true);
            else
                Response.Redirect("subject_language_ExtraCurricular.aspx?sid=" + Session["SchoolID"].ToString());
        }
        catch { }
    }

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        sql = "select * from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/subject_language_ExtraCurricular.aspx");
    }

    protected void fillclasstype()
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            str = "select strstandard from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);

            ddlclass.Items.Clear();
            ddlclass.DataSource = ds;
            ddlclass.DataTextField = "strstandard";
            ddlclass.DataValueField = "strstandard";
            ddlclass.DataBind();
        }
        catch { }
    }

    protected void fillsection()
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            str = "select strsection from tblstandard_section_subject where  strstandard='" + ddlclass.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + " group by strsection";
            ds = da.ExceuteSql(str);

            ddlsection.Items.Clear();
            ddlsection.DataSource = ds;
            ddlsection.DataTextField = "strsection";
            ddlsection.DataValueField = "strsection";
            ddlsection.DataBind();
        }
        catch { }
    }
    
    protected void filldgstandard()
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataAccess da = new DataAccess();

            str = "select strstandard,strsection,intschoolid,'' as subject,'' as language,'' as extracurricular,'' as groups,'' as thirdlanguage from tblstandard_section_subject  where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"] + " group by strstandard,strsection,intschoolid";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str = "select strsubject from tblstandard_section_subject  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(str);
                    string strsbject = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (strsbject == "")
                            strsbject = ds1.Tables[0].Rows[j]["strsubject"].ToString();
                        else
                            strsbject = strsbject + ", " + ds1.Tables[0].Rows[j]["strsubject"].ToString();

                    }
                    ds.Tables[0].Rows[i]["subject"] = strsbject;

                    if (strsbject.IndexOf("Second Language") > -1)
                    {
                        str = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
                        ds1 = new DataSet();
                        ds1 = da.ExceuteSql(str);
                        string strlanguage = "";
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            if (strlanguage == "")
                                strlanguage = ds1.Tables[0].Rows[j]["strlanguagename"].ToString();
                            else
                                strlanguage = strlanguage + ", " + ds1.Tables[0].Rows[j]["strlanguagename"].ToString();

                        }
                        ds.Tables[0].Rows[i]["language"] = strlanguage;
                    }
                    else
                        ds.Tables[0].Rows[i]["language"] = "N/A";

                    if (strsbject.IndexOf("Third Language") > -1)
                    {
                        str = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
                        ds1 = new DataSet();
                        ds1 = da.ExceuteSql(str);
                        string strthirdlanguage = "";
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            if (strthirdlanguage == "")
                                strthirdlanguage = ds1.Tables[0].Rows[j]["strlanguagename"].ToString();
                            else
                                strthirdlanguage = strthirdlanguage + ", " + ds1.Tables[0].Rows[j]["strlanguagename"].ToString();

                        }
                        ds.Tables[0].Rows[i]["thirdlanguage"] = strthirdlanguage;
                    }
                    else
                        ds.Tables[0].Rows[i]["thirdlanguage"] = "N/A";

                    str = "select strcurricular from tblstandard_section_extraCurricular  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(str);
                    string strextra = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (strextra == "")
                            strextra = ds1.Tables[0].Rows[j]["strcurricular"].ToString();
                        else
                            strextra = strextra + ", " + ds1.Tables[0].Rows[j]["strcurricular"].ToString();

                    }
                    ds.Tables[0].Rows[i]["extracurricular"] = strextra;

                    //str = "select strgroup from tblstandard_section_groups where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    //ds1 = new DataSet();
                    //ds1 = da.ExceuteSql(str);
                    //string strgroup = "";
                    //for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    //{
                    //    if (strgroup == "")
                    //        strgroup = strgroup + ds1.Tables[0].Rows[j]["strgroup"].ToString();
                    //    else
                    //        strgroup = strgroup + ", " + ds1.Tables[0].Rows[j]["strgroup"].ToString();

                    //}
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //    ds.Tables[0].Rows[i]["groups"] = strgroup;
                    //else
                    //    ds.Tables[0].Rows[i]["groups"] = "--";
                }
            }
            dlsubjects.DataSource = ds;
            dlsubjects.DataBind();
        }
        catch { }
    }

    protected void filldgstandard2()
    {
        try
        {
            string str = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataAccess da = new DataAccess();
            
            str = "select strstandard,strsection,intschoolid,'' as subject,'' as language,'' as extracurricular,'' as groups,'' as thirdlanguage from tblstandard_section_subject  where strstandard='" + ddlclass.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschoolid=" + Session["SchoolID"] + " group by strstandard,strsection,intschoolid";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str = "select strsubject from tblstandard_section_subject  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(str);
                    string strsbject = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (strsbject == "")
                            strsbject = ds1.Tables[0].Rows[j]["strsubject"].ToString();
                        else
                            strsbject = strsbject + ", " + ds1.Tables[0].Rows[j]["strsubject"].ToString();

                    }
                    ds.Tables[0].Rows[i]["subject"] = strsbject;

                    if (strsbject.IndexOf("Second Language") > -1)
                    {
                        str = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
                        ds1 = new DataSet();
                        ds1 = da.ExceuteSql(str);
                        string strlanguage = "";
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            if (strlanguage == "")
                                strlanguage = ds1.Tables[0].Rows[j]["strlanguagename"].ToString();
                            else
                                strlanguage = strlanguage + ", " + ds1.Tables[0].Rows[j]["strlanguagename"].ToString();

                        }
                        ds.Tables[0].Rows[i]["language"] = strlanguage;
                    }
                    else
                        ds.Tables[0].Rows[i]["language"] = "N/A";

                    if (strsbject.IndexOf("Third Language") > -1)
                    {
                        str = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
                        ds1 = new DataSet();
                        ds1 = da.ExceuteSql(str);
                        string strthirdlanguage = "";
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            if (strthirdlanguage == "")
                                strthirdlanguage = ds1.Tables[0].Rows[j]["strlanguagename"].ToString();
                            else
                                strthirdlanguage = strthirdlanguage + ", " + ds1.Tables[0].Rows[j]["strlanguagename"].ToString();

                        }
                        ds.Tables[0].Rows[i]["thirdlanguage"] = strthirdlanguage;
                    }
                    else
                        ds.Tables[0].Rows[i]["thirdlanguage"] = "N/A";

                    str = "select strcurricular from tblstandard_section_extraCurricular  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(str);
                    string strextra = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (strextra == "")
                            strextra = ds1.Tables[0].Rows[j]["strcurricular"].ToString();
                        else
                            strextra = strextra + ", " + ds1.Tables[0].Rows[j]["strcurricular"].ToString();

                    }
                    ds.Tables[0].Rows[i]["extracurricular"] = strextra;

                    //str = "select strgroup from tblstandard_section_groups where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    //ds1 = new DataSet();
                    //ds1 = da.ExceuteSql(str);
                    //string strgroup = "";
                    //for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    //{
                    //    if (strgroup == "")
                    //        strgroup = strgroup + ds1.Tables[0].Rows[j]["strgroup"].ToString();
                    //    else
                    //        strgroup = strgroup + ", " + ds1.Tables[0].Rows[j]["strgroup"].ToString();

                    //}
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //    ds.Tables[0].Rows[i]["groups"] = strgroup;
                    //else
                    //    ds.Tables[0].Rows[i]["groups"] = "--";
                }
            }
            dlsubjects.DataSource = ds;
            dlsubjects.DataBind();
        }
        catch { }
    }

    
    
    
}
