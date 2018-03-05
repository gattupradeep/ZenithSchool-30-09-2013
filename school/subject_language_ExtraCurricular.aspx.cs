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

public partial class school_subject_language_ExtraCurricular : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int SPI = 0;
            try
            {
                SPI = int.Parse(Session["SProfileIndex"].ToString());
            }
            catch
            {
                SPI = 0;
            }
            if (SPI < 5 && SPI != 0)
                Session["SProfileIndex"] = 5;
            fillddlstandard();
            fillddlsection();
            fillsubject();
            fillextracurricular();
            //filllanguages();
            //fillthirdlanguages();
            //fillgroups();            
            setnext();
            if (Request["sid"] != null)
                btndone.Text = "Cancel";
        }
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlsection();
        filldgstandard();
    }

    protected void dgstandard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ViewSLEAstd"] = e.Item.Cells[0].Text;
        Session["ViewSLEAsec"] = e.Item.Cells[1].Text;
        Response.Redirect("../school/view_subject_language_ExtraCurricular.aspx?view=1");
    }

    protected void dgstandard_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string sql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        try
        {
            sql = "select intid from tblstandard_section_subject where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_subject", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }
            sql = "delete tblstandard_section_subject where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(sql);
        }
        catch { }

        try
        {
            sql = "select intid from tblstandard_section_language where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_language", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }
            sql = "delete tblstandard_section_language where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(sql);
        }
        catch { }

        try
        {
            sql = "select intid from tblstandard_section_extraCurricular where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_extraCurricular", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }
            sql = "delete tblstandard_section_extraCurricular where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(sql);
        }
        catch { }

        //try
        //{
        //    sql = "delete tblstandard_section_groups where strstandard='" + e.Item.Cells[0].Text + "' and strsection='" + e.Item.Cells[1].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
        //    da.ExceuteSqlQuery(sql);
        //}
        //catch { }

        filldgstandard();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        ddlstandard.Enabled = true;
        btnSave.Text = "Save";
        for (int i = 0; i < chksubject.Items.Count; i++)
        {
            chksubject.Items[i].Selected = false;
        }
        for (int j = 0; j < chkextra.Items.Count; j++)
        {
            chkextra.Items[j].Selected = false;
        }
        //for (int j = 0; j < chklanguages.Items.Count; j++)
        //{
        //    chklanguages.Items[j].Selected = false;
        //}
        //ddlgroup.SelectedIndex = 0;
    }

    protected void btndone_Click(object sender, EventArgs e)
    {
        if (Request["sid"] != null)
        {
            Response.Redirect("../school/view_subject_language_ExtraCurricular.aspx");
        }
        else
        {
            redirectpages();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please select a class')", true);
        }
        else
        {
            string qry = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            
            if (btnSave.Text == "Save")
            {
                string sec = "";
                for (int s = 0; s < chksection.Items.Count; s++)
                {
                    if (chksection.Items[s].Selected == true)
                    {
                        if (sec == "")
                            sec = chksection.Items[s].Text;
                        else
                            sec = sec + "," + chksection.Items[s].Text;
                    }

                }
                if (sec != "")
                {
                    qry = "select * from tblstandard_section_subject where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(qry);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Already Exists for this Standard & Section')", true);
                    }
                    else
                    {
                        saveExtraCurricular();
                        //savelanguage();
                        //savethirdlanguage();
                        savesubject();
                        //savegroups();

                        for (int i = 0; i < chksubject.Items.Count; i++)
                        {
                            chksubject.Items[i].Selected = false;
                        }
                        for (int j = 0; j < chkextra.Items.Count; j++)
                        {
                            chkextra.Items[j].Selected = false;
                        }
                        //for (int j = 0; j < chklanguages.Items.Count; j++)
                        //{
                        //    chklanguages.Items[j].Selected = false;
                        //}
                        for (int j = 0; j < chksection.Items.Count; j++)
                        {
                            chksection.Items[j].Selected = false;
                        }
                        //for (int j = 0; j < chkthirdlanguages.Items.Count; j++)
                        //{
                        //    chkthirdlanguages.Items[j].Selected = false;
                        //}
                        fillddlstandard();
                        btnSave.Text = "Save";
                        filldgstandard();
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please select atleast one section')", true);
            }
            else
            {
                saveExtraCurricular();
                //savelanguage();
                //savethirdlanguage();
                savesubject();
                //savegroups();
                filldgstandard();
                for (int i = 0; i < chksubject.Items.Count; i++)
                {
                    chksubject.Items[i].Selected = false;
                }
                for (int j = 0; j < chkextra.Items.Count; j++)
                {
                    chkextra.Items[j].Selected = false;
                }
                //for (int j = 0; j < chklanguages.Items.Count; j++)
                //{
                //    chklanguages.Items[j].Selected = false;
                //}
                //ddlgroup.SelectedIndex = 0;
                //ddlsection.Enabled = true;
                ddlstandard.Enabled = true;
                btnSave.Text = "Save";
            }
        }
        setnext();
    }

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select * from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
            btndone.Visible = true;
        else
            btndone.Visible = false;
    }

    private void fillddlstandard()
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
            ddlstandard.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sql = "select strsection from tblschoolsection where intschoolid=" + Session["SchoolID"].ToString() + " and strsection not in(select strsection from tblstandard_section_subject where strstandard='" + ds.Tables[0].Rows[i]["strstandard"].ToString() + "' and intschoolid=" + Session["SchoolID"].ToString() + " group by strsection) order by strsection";
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    li = new ListItem(ds.Tables[0].Rows[i]["strstandard"].ToString(), ds.Tables[0].Rows[i]["strstandard"].ToString());
                    ddlstandard.Items.Add(li);
                    j++;
                }
            }
            if(j==0)
                Response.Redirect("class_section_subject_details.aspx");

            ddlstandard.Items.Insert(0, "-Select-");
        }
        catch { }
    }

    private void fillddlsection()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        if (ddlstandard.SelectedIndex > 0)
        {
            try
            {
                
                sql = "select strsection from tblschoolsection where intschoolid=" + Session["SchoolID"].ToString() + " and strsection not in(select strsection from tblstandard_section_subject where strstandard='" + ddlstandard.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + " group by strsection) order by strsection";
                ds = da.ExceuteSql(sql);
                chksection.Items.Clear();
                ListItem li;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    li = new ListItem(ds.Tables[0].Rows[i]["strsection"].ToString(), ds.Tables[0].Rows[i]["strsection"].ToString());
                    chksection.Items.Add(li);
                }
            }
            catch { }
        }
    }

    private void fillsubject()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        try
        {
            sql = "select * from tblschoolsubject where intschoolid=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            chksubject.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strsubject"].ToString(), ds.Tables[0].Rows[i]["intschoolsubjectid"].ToString());
                chksubject.Items.Add(li);
            }
        }
        catch { }
    }

    private void fillextracurricular()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        try
        {
            sql = "select * from tblschoolExtracurricular where intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            chkextra.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strextracurricular"].ToString(), ds.Tables[0].Rows[i]["intschoolcurricularid"].ToString());
                chkextra.Items.Add(li);
            }
        }
        catch { }
    }

    //private void fillgroups()
    //{
    //    string sql = "";
    //    DataSet ds = new DataSet();
    //    DataAccess da = new DataAccess();

    //    try
    //    {
    //        sql = "select strschoolgroupname from tblschoolgroup where intschoolid=" + Session["SchoolID"].ToString() + " group by strschoolgroupname";
    //        ds = da.ExceuteSql(sql);
    //        ListItem li;
    //        li = new ListItem("None", "None");
    //        ddlgroup.DataTextField = "strschoolgroupname";
    //        ddlgroup.DataValueField = "strschoolgroupname";
    //        ddlgroup.DataSource = ds;
    //        ddlgroup.DataBind();
    //        ddlgroup.Items.Insert(0, li);
    //    }
    //    catch { }
    //}

    private void savesubject()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sec = "";
            for (int s = 0; s < chksection.Items.Count; s++)
            {
                if (chksection.Items[s].Selected == true)
                {
                    if (sec == "")
                        sec = chksection.Items[s].Text;
                    else
                        sec = sec + "," + chksection.Items[s].Text;
                }
            }
            qry = "select intid from tblstandard_section_subject where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(qry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_subject", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }
            qry = "delete tblstandard_section_subject where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(qry);
            for (int j = 0; j < chksection.Items.Count; j++)
            {
                if (chksection.Items[j].Selected == true)
                {
                    for (int i = 0; i < chksubject.Items.Count; i++)
                    {
                        if (chksubject.Items[i].Selected == true)
                        {
                            qry = "insert into tblstandard_section_subject(strstandard,strsection,strsubject,intschoolid)values('" + ddlstandard.SelectedValue + "','" + chksection.Items[j].Text + "','" + chksubject.Items[i].Text + "'," + Session["SchoolID"] + ")";
                            da.ExceuteSqlQuery(qry);

                            DataSet ds2 = new DataSet();
                            qry = "select max(intid) as intid from tblstandard_section_subject";
                            ds2 = da.ExceuteSql(qry);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_subject", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);
                        }
                    }
                }
            }
        }
        catch { }

    }

    private void saveExtraCurricular()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();

            string sec = "";
            for (int s = 0; s < chksection.Items.Count; s++)
            {
                if (chksection.Items[s].Selected == true)
                {
                    if (sec == "")
                        sec = chksection.Items[s].Text;
                    else
                        sec = sec + "," + chksection.Items[s].Text;
                }
            }

            qry = "select intid from tblstandard_section_extraCurricular where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(qry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_extraCurricular", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);

                }
            }
            qry = "delete tblstandard_section_extraCurricular where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(qry);
            for (int j = 0; j < chksection.Items.Count; j++)
            {
                if (chksection.Items[j].Selected == true)
                {
                    for (int i = 0; i < chkextra.Items.Count; i++)
                    {
                        if (chkextra.Items[i].Selected == true)
                        {
                            qry = "insert into tblstandard_section_extraCurricular(strstandard,strsection,strcurricular,intschoolid)values('" + ddlstandard.SelectedValue + "','" + chksection.Items[j].Text + "','" + chkextra.Items[i].Text + "'," + Session["SchoolID"] + ")";
                            da.ExceuteSqlQuery(qry);

                            DataSet ds2 = new DataSet();
                            qry = "select max(intid) as intid from tblstandard_section_extraCurricular";
                            ds2 = da.ExceuteSql(qry);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblstandard_section_extraCurricular", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),30);
                        }
                    }
                }
            }
        }
        catch { }
    }

    //protected void savegroups()
    //{
    //    try
    //    {
    //        string qry = "";
    //        DataSet ds = new DataSet();
    //        DataAccess da = new DataAccess();
            
    //        string sec = "";
    //        for (int s = 0; s < chksection.Items.Count; s++)
    //        {
    //            if (chksection.Items[s].Selected == true)
    //            {
    //                if (sec == "")
    //                    sec = chksection.Items[s].Text;
    //                else
    //                    sec = sec + "," + chksection.Items[s].Text;
    //            }
    //        }

    //        qry = "delete tblstandard_section_groups where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
    //        da.ExceuteSqlQuery(qry);
    //        for (int j = 0; j < chksection.Items.Count; j++)
    //        {
    //            if (chksection.Items[j].Selected == true)
    //            {
    //                qry = "insert into tblstandard_section_groups(strstandard,strsection,strgroup,intschoolid)values('" + ddlstandard.SelectedValue + "','" + chksection.Items[j].Text + "','" + ddlgroup.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
    //                da.ExceuteSqlQuery(qry);
    //            }
    //        }
    //    }
    //    catch { }
    //}

    protected void filldgstandard()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataAccess da = new DataAccess();

        try
        {
            sql = "select strstandard,strsection,intschoolid,'' as subject,'' as language,'' as extracurricular,'' as groups,'' as thirdlanguage from tblstandard_section_subject  where intschoolid=" + Session["SchoolID"] + " and strstandard='" + ddlstandard.SelectedValue + "' group by strstandard,strsection,intschoolid";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sql = "select strsubject from tblstandard_section_subject where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    string strsbject = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        strsbject = strsbject + ds1.Tables[0].Rows[j]["strsubject"].ToString() + Environment.NewLine;

                    }
                    ds.Tables[0].Rows[i]["subject"] = strsbject;

                    if (strsbject.IndexOf("Second Language") > -1)
                    {
                        sql = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
                        ds1 = new DataSet();
                        ds1 = da.ExceuteSql(sql);
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
                        sql = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
                        ds1 = new DataSet();
                        ds1 = da.ExceuteSql(sql);
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

                    sql = "select strcurricular from tblstandard_section_extraCurricular where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    string strextra = "";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        strextra = strextra + ds1.Tables[0].Rows[j]["strcurricular"].ToString() + Environment.NewLine;

                    }
                    ds.Tables[0].Rows[i]["extracurricular"] = strextra;

                    //sql = "select strgroup from tblstandard_section_groups where strstandard='" + ds.Tables[0].Rows[i]["strstandard"] + "' and strsection='" + ds.Tables[0].Rows[i]["strsection"] + "' and intschoolid=" + Session["SchoolID"];
                    //ds1 = new DataSet();
                    //ds1 = da.ExceuteSql(sql);
                    //string strgroup = "";
                    //for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    //{
                    //    strgroup = strgroup + ds1.Tables[0].Rows[j]["strgroup"].ToString() + Environment.NewLine;

                    //}
                    //ds.Tables[0].Rows[i]["groups"] = strgroup;
                }
            }
            dgstandard.DataSource = ds;
            dgstandard.DataBind();
        }
        catch { }
    }

    protected void redirectpages()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        Session["UserRights"] = "No";

        sql = "select * from tbldetails where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        Session["SProfileIndex"] = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            sql = "select * from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            Session["SProfileIndex"] = 2;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sql = "select * from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString();
                ds = new DataSet();
                ds = da.ExceuteSql(sql);
                Session["SProfileIndex"] = 3;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
                    ds = new DataSet();
                    ds = da.ExceuteSql(sql);
                    Session["SProfileIndex"] = 4;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sql = "select * from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString();
                        ds = new DataSet();
                        ds = da.ExceuteSql(sql);
                        Session["SProfileIndex"] = 5;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sql = "select * from tblexamorder where intschoolid=" + Session["SchoolID"].ToString();
                            ds = new DataSet();
                            ds = da.ExceuteSql(sql);
                            Session["SProfileIndex"] = 6;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "select * from tblschoolexampaper where intschoolid=" + Session["SchoolID"].ToString();
                                ds = new DataSet();
                                ds = da.ExceuteSql(sql);
                                Session["SProfileIndex"] = 7;
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sql = "select * from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString();
                                    ds = new DataSet();
                                    ds = da.ExceuteSql(sql);
                                    Session["SProfileIndex"] = 8;
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        sql = "select * from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString();
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



    //private void filllanguages()
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "select * from tblschoolLanguages where intschoolid=" + Session["SchoolID"].ToString();
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

    //private void savelanguage()
    //{
    //    try
    //    {
    //        string qry = "";
    //        DataAccess da = new DataAccess();
    //        string sec = "";
    //        for (int s = 0; s < chksection.Items.Count; s++)
    //        {
    //            if (chksection.Items[s].Selected == true)
    //            {
    //                if (sec == "")
    //                    sec = chksection.Items[s].Text;
    //                else
    //                    sec = sec + "," + chksection.Items[s].Text;
    //            }
    //        }
    //        qry = "delete tblstandard_section_language where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
    //        da.ExceuteSqlQuery(qry);
    //        for (int j = 0; j < chksection.Items.Count; j++)
    //        {
    //            if (chksection.Items[j].Selected == true)
    //            {
    //                for (int i = 0; i < chklanguages.Items.Count; i++)
    //                {
    //                    if (chklanguages.Items[i].Selected == true)
    //                    {
    //                        da = new DataAccess();
    //                        qry = "insert into tblstandard_section_language(strstandard,strsection,strlanguage2,intschoolid)values('" + ddlstandard.SelectedValue + "','" + chksection.Items[j].Text + "','" + chklanguages.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
    //                        da.ExceuteSqlQuery(qry);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch { }
    //}

    //private void savethirdlanguage()
    //{
    //    try
    //    {
    //        string qry = "";
    //        DataAccess da = new DataAccess();
    //        string sec = "";
    //        for (int s = 0; s < chksection.Items.Count; s++)
    //        {
    //            if (chksection.Items[s].Selected == true)
    //            {
    //                if (sec == "")
    //                    sec = chksection.Items[s].Text;
    //                else
    //                    sec = sec + "," + chksection.Items[s].Text;
    //            }
    //        }
    //        qry = "delete tblstandard_section_thirdlanguage where strstandard='" + ddlstandard.SelectedValue + "' and strsection in('" + sec.Replace(",", "','") + "') and intschoolid=" + Session["SchoolID"].ToString();
    //        da.ExceuteSqlQuery(qry);
    //        for (int j = 0; j < chksection.Items.Count; j++)
    //        {
    //            if (chksection.Items[j].Selected == true)
    //            {
    //                for (int i = 0; i < chkthirdlanguages.Items.Count; i++)
    //                {
    //                    if (chkthirdlanguages.Items[i].Selected == true)
    //                    {
    //                        da = new DataAccess();
    //                        qry = "insert into tblstandard_section_thirdlanguage(strstandard,strsection,strlanguage2,intschoolid)values('" + ddlstandard.SelectedValue + "','" + chksection.Items[j].Text + "','" + chkthirdlanguages.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
    //                        da.ExceuteSqlQuery(qry);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch { }
    //}
}
