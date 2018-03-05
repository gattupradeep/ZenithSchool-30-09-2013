using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class school_viewexamdetails : System.Web.UI.Page
{
    //public string str;
    //public DataSet ds, ds1;
    //public DataAccess da;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclasstype();
            filldgstandard();
        }
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldgstandard();
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../school/subject_language_ExtraCurricular.aspx");
    }

    protected void fillclasstype()
    {
        try
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            sql = "select strstandard from tblstandard_section_subject  where intschoolid=" + Session["SchoolID"] + " group by strstandard";
            ds = da.ExceuteSql(sql);

            ddlclass.DataSource = ds;
            ddlclass.DataTextField = "strstandard";
            ddlclass.DataValueField = "strstandard";
            ddlclass.DataBind();
        }
        catch { }
    }    

    protected void filldgstandard()
    {
        try
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataAccess da = new DataAccess();

            sql = "select strstandard,strsection,intschoolid,'' as subject,'' as language,'' as extracurricular from tblstandard_section_subject  where strstandard='" + ddlclass.SelectedValue + "' and intschoolid=" + Session["SchoolID"] + " group by strstandard,strsection,intschoolid";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sql = "select strsubject from tblstandard_section_subject  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    string strsbject = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        strsbject = strsbject + ds1.Tables[0].Rows[j]["strsubject"].ToString() + ", ";

                    }
                    ds.Tables[0].Rows[i]["subject"] = strsbject;

                    sql = "select strlanguage2 from tblstandard_section_language  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    string strlanguage = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        strlanguage = strlanguage + ds1.Tables[0].Rows[j]["strlanguage2"].ToString() + ", ";

                    }
                    ds.Tables[0].Rows[i]["language"] = strlanguage;

                    sql = "select strcurricular from tblstandard_section_extraCurricular  where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    string strextra = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        strextra = strextra + ds1.Tables[0].Rows[j]["strcurricular"].ToString() + ", ";

                    }
                    ds.Tables[0].Rows[i]["extracurricular"] = strextra;

                }
            }
            dlsubjects.DataSource = ds;
            dlsubjects.DataBind();
        }
        catch { }
    }
    
}
