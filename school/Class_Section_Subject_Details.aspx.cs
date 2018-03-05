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
using System.Text;

public partial class school_Class_Section_Subject_Details : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da1;
    public DataSet ds1;

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
            if (SPI < 4 && SPI != 0)
                Session["SProfileIndex"] = 4;

            fillsubject();
            fillclasstype();
            fillsection();
            fillextracurricular();
            filllanguages();
            //fillthirdlanguages();
            if (Request["sid"] != null)
            {
                Editstandard();
                EditExtracurricular();
                Editsection();
                Editsubject();
                Editlanguages();
                //Editthirdlanguages();
                btnsave.Text = "Update";
                btncancel.Visible = true;
            }
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../school/viewClass_section_subject_details.aspx");
    }

    protected void addstandard_Click(object sender, EventArgs e)
    {
        Session["SelectedStandard"] = selectedstandard1();
        try
        {
            if (txtstandard.Text != "")
            {
                string qry = "";
                DataAccess da = new DataAccess();
                qry = "insert into tblstandard(strstandard)values('" + txtstandard.Text.Trim() + "')";
                da.ExceuteSqlQuery(qry);
                fillclasstype();
                fillclasstype1();
                txtstandard.Text = "";

                DataSet ds2 = new DataSet();
                qry = "select max(ID) as ID from tblstandard";
                ds2 = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tblstandard", ds2.Tables[0].Rows[0]["ID"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Standard Added Successfully')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Standard Already Exist')", true);
        }

    }

    protected void addsection_Click(object sender, EventArgs e)
    {
        Session["SelectedSection"] = selectedsection1();
        try
        {
            if (txtsection.Text != "")
            {
                if (txtsection.Text == "0" || txtsection.Text == "00" || txtsection.Text == "000" || txtsection.Text == "0000" || txtsection.Text == "00.00" || txtsection.Text == "0.0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Section is Invalid')", true);
                }
                else
                {
                    string qry = "";
                    DataAccess da = new DataAccess();
                    qry = "insert into tblsection(strsection)values('" + txtsection.Text.Trim() + "')";
                    da.ExceuteSqlQuery(qry);
                    fillsection();
                    fillsection1();
                    txtsection.Text = "";

                    DataSet ds2 = new DataSet();
                    qry = "select max(intsectionID) as intsectionID from tblsection";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblsection", ds2.Tables[0].Rows[0]["intsectionID"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Section Added Successfully')", true);
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Section Already Exist')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Section Already Exist')", true);
        }
    }

    protected void addsubject_Click(object sender, EventArgs e)
    {
        Session["SelectedSubject"] = selectedsubject1();
        try
        {
            if (txtsubject.Text != "" || txtsubject.Text != "Second Language" || txtsubject.Text != "Third Language")
            {
                string qry = "";
                DataAccess da = new DataAccess();
                qry = "insert into tblSubject(strsubject)values('" + txtsubject.Text.Trim() + "')";
                da.ExceuteSqlQuery(qry);
                fillsubject();
                fillsubject1();
                txtsubject.Text = "";

                DataSet ds2 = new DataSet();
                qry = "select max(intsubjectid) as intsubjectid from tblSubject";
                ds2 = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tblSubject", ds2.Tables[0].Rows[0]["intsubjectid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Subject Added Successfully')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter a Valid Subject')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Subject Already Exist')", true);
        }
    }

    protected void btnaddlang_Click(object sender, EventArgs e)
    {
        Session["SelectedLang"] = selectedlang1();
        try
        {
            if (txtlang.Text != "")
            {
                string qry = "";
                DataAccess da = new DataAccess();
                qry = "insert into tbllanguages(strlanguagename)values('" + txtlang.Text.Trim() + "')";
                da.ExceuteSqlQuery(qry);
                filllanguages();
                filllanguages1();
                txtlang.Text = "";

                DataSet ds2 = new DataSet();
                qry = "select max(intlanguagesid) as intlanguagesid from tbllanguages";
                ds2 = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tbllanguages", ds2.Tables[0].Rows[0]["intlanguagesid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Language Added Successfully')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already Exist')", true);
        }

    }

    protected void addextra_Click(object sender, EventArgs e)
    {
        Session["SelectedExtra"] = selectedextra1();
        try
        {
            if (txtextra.Text != "")
            {
                string qry = "";
                DataAccess da = new DataAccess();
                qry = "insert into tblextracurricular(strextracurricular)values('" + txtextra.Text.Trim() + "')";
                da.ExceuteSqlQuery(qry);
                fillextracurricular();
                fillextracurricular1();
                txtextra.Text = "";

                DataSet ds2 = new DataSet();
                qry = "select max(intcurricularid) as intcurricularid from tblextracurricular";
                ds2 = da.ExceuteSql(qry);
                Functions.UserLogs(Session["UserID"].ToString(), "tblextracurricular", ds2.Tables[0].Rows[0]["intcurricularid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Activity Added Successfully')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already Exist')", true);
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        selectedstandard();
        selectedsection();
        selectedsubject();
        selectedExtracurricular();
        selectedlang();
        //selectedthirdlang();
        if (btnsave.Text == "Update")
            Response.Redirect("viewClass_section_subject_details.aspx");
        else
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "";
            sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
                redirectpages();
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Set Class - Section - Subject Details!')", true);
        }
    }

    protected void Editstandard()
    {

        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    for (int i = 0; i < chkstandard.Items.Count; i++)
                    {
                        if (chkstandard.Items[i].Text == ds.Tables[0].Rows[j]["strstandard"].ToString())
                        {
                            chkstandard.Items[i].Selected = true;
                            strsql = " select * from dbo.tblstandard_section_subject where strstandard='" + chkstandard.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                            da1 = new DataAccess();
                            ds1 = new DataSet();
                            ds1 = da1.ExceuteSql(strsql);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                chkstandard.Items[i].Enabled = false;
                            }
                        }

                    }
                }
            }
        }
        catch { }
    }

    protected void Editsection()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolsection where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    for (int i = 0; i <chksection.Items.Count; i++)
                    {
                        if (chksection.Items[i].Text == ds.Tables[0].Rows[j]["strsection"].ToString())
                        {
                            chksection.Items[i].Selected = true;
                            strsql = "select * from dbo.tblstandard_section_subject where strsection='" + chksection.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                            da1 = new DataAccess();
                            ds1 = new DataSet();
                            ds1 = da1.ExceuteSql(strsql);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                chksection.Items[i].Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void Editsubject()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolsubject where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    for (int i = 0; i <chksubject.Items.Count; i++)
                    {
                        if (chksubject.Items[i].Text == ds.Tables[0].Rows[j]["strsubject"].ToString())
                        {
                            chksubject.Items[i].Selected = true;
                            strsql = " select * from dbo.tblstandard_section_subject where strsubject='" + chksubject.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                            da1 = new DataAccess();
                            ds1 = new DataSet();
                            ds1 = da1.ExceuteSql(strsql);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                chksubject.Items[i].Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void Editlanguages()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoollanguages where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    for (int i = 0; i < chklang.Items.Count; i++)
                    {
                        if (chklang.Items[i].Text == ds.Tables[0].Rows[j]["strlanguagename"].ToString())
                        {
                            chklang.Items[i].Selected = true;
                            strsql = " select * from tblschoollanguages where strlanguagename='" + chklang.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                            da1 = new DataAccess();
                            ds1 = new DataSet();
                            ds1 = da1.ExceuteSql(strsql);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                chklang.Items[i].Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void EditExtracurricular()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolExtracurricular where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    for (int i = 0; i <chkextra.Items.Count; i++)
                    {
                        if (chkextra.Items[i].Text == ds.Tables[0].Rows[j]["strextracurricular"].ToString())
                        {
                            chkextra.Items[i].Selected = true;
                            strsql = " select * from tblstandard_section_extraCurricular where strcurricular='" + chkextra.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                            da1 = new DataAccess();
                            ds1 = new DataSet();
                            ds1 = da1.ExceuteSql(strsql);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                chkextra.Items[i].Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void fillclasstype()
    {
        chkstandard.Items.Clear();
        try
        {
            //DataAccess da = new DataAccess();
            //string sql = "select strclasstype from tblschooldetails where intschoolid=" + Session["SchoolID"];
            //DataSet ds = new DataSet();
            //ds = da.ExceuteSql(sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ListItem Li;
            //    if (ds.Tables[0].Rows[0]["strclasstype"].ToString() == "Form")
            //    {
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            Li = new ListItem(ds.Tables[0].Rows[0]["strclasstype"].ToString() + " " + i.ToString(), ds.Tables[0].Rows[0]["strclasstype"].ToString() + " " + i.ToString());
            //            chkstandard.Items.Add(Li);
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[0]["strclasstype"].ToString() == "Grade")
            //    {
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            string std;
            //            if (i == 1)
            //                std = "1st " + ds.Tables[0].Rows[0]["strclasstype"].ToString();
            //            else if (i == 2)
            //                std = "2nd " + ds.Tables[0].Rows[0]["strclasstype"].ToString();
            //            else if (i == 3)
            //                std = "3rd " + ds.Tables[0].Rows[0]["strclasstype"].ToString();
            //            else
            //                std = i.ToString() + "th " + ds.Tables[0].Rows[0]["strclasstype"].ToString();

            //            Li = new ListItem(std, std);
            //            chkstandard.Items.Add(Li);
            //        }
            //    }
            //    else
            //    {
            //        string[] std = new string[12] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };

            //        for (int i = 0; i < 12; i++)
            //        {
            //            Li = new ListItem(ds.Tables[0].Rows[0]["strclasstype"].ToString() + " " + std[i], ds.Tables[0].Rows[0]["strclasstype"].ToString() + " " + std[i]);
            //            chkstandard.Items.Add(Li);
            //        }
            //    }
            //}

            string sql = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            sql = "select strstandard from tblstandard";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ListItem Li;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Li = new ListItem(ds.Tables[0].Rows[i]["strstandard"].ToString(), ds.Tables[0].Rows[i]["strstandard"].ToString());
                    chkstandard.Items.Add(Li);
                }
            }
        }
        catch { }
    }

    protected void fillclasstype1()
    {
        try
        {
            for (int i = 0; i < chkstandard.Items.Count; i++)
            {
                string[] abc = Session["SelectedStandard"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chkstandard.Items[i].Value.ToString() == abc[j].Trim())
                    {
                        chkstandard.Items[i].Selected = true;
                        strsql = " select * from dbo.tblstandard_section_subject where strstandard='" + abc[j].Trim() + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chkstandard.Items[i].Enabled = false;
                        }

                    }
                }
            }
        }
        catch { }
    }

    private void fillsection()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblsection";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chksection.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strsection"].ToString(), ds.Tables[0].Rows[i]["intsectionid"].ToString());
                chksection.Items.Add(li);
            }
        }
        catch { }
    }

    protected void fillsection1()
    {
        try
        {
            for (int i = 0; i < chksection.Items.Count; i++)
            {
                string[] abc = Session["SelectedSection"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chksection.Items[i].Value.ToString() == abc[j].Trim())
                    {
                        chksection.Items[i].Selected = true;

                        strsql = " select * from dbo.tblstandard_section_subject where strsection='" + abc[j].Trim() + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chksection.Items[i].Enabled = false;
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void fillsubject()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblSubject";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chksubject.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strsubject"].ToString(), ds.Tables[0].Rows[i]["intsubjectid"].ToString());
                chksubject.Items.Add(li);
            }
        }
        catch { }
    }

    protected void fillsubject1()
    {
        try
        {
            for (int i = 0; i < chksubject.Items.Count; i++)
            {
                string[] abc = Session["SelectedSubject"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chksubject.Items[i].Value.ToString() == abc[j].Trim())
                    {
                        chksubject.Items[i].Selected = true;
                        strsql = " select * from dbo.tblstandard_section_subject where strsubject='" + abc[j].Trim() + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chksubject.Items[i].Enabled = false;
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void filllanguages()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tbllanguages order by strlanguagename";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chklang.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strlanguagename"].ToString(), ds.Tables[0].Rows[i]["intlanguagesid"].ToString());
                chklang.Items.Add(li);

            }
        }
        catch { }
    }

    protected void filllanguages1()
    {
        try
        {
            for (int i = 0; i < chklang.Items.Count; i++)
            {
                string[] abc = Session["SelectedLang"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chklang.Items[i].Value.ToString() == abc[j].Trim())
                    {
                        chklang.Items[i].Selected = true;
                        strsql = " select * from tblschoollanguages where strlanguagename='" + abc[j].Trim() + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chklang.Items[i].Enabled = false;
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void fillextracurricular()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblextracurricular";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chkextra.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strextracurricular"].ToString(), ds.Tables[0].Rows[i]["intcurricularid"].ToString());
                chkextra.Items.Add(li);
            }
        }
        catch { }
    }

    protected void fillextracurricular1()
    {
        try
        {
            for (int i = 0; i < chkextra.Items.Count; i++)
            {
                string[] abc = Session["SelectedExtra"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chkextra.Items[i].Value.ToString() == abc[j].Trim())
                    {
                        chkextra.Items[i].Selected = true;
                        strsql = " select * from tblstandard_section_extraCurricular where strcurricular='" + chkextra.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chkextra.Items[i].Enabled = false;
                        }
                    }
                }
            }
        }
        catch { }
    }

    protected void selectedstandard()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            qry = "delete tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolstandard", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

            da.ExceuteSqlQuery(qry);
            for (int i = 0; i < chkstandard.Items.Count; i++)
            {
                if (chkstandard.Items[i].Selected == true)
                {
                    qry = "";
                    da = new DataAccess();
                    qry = "insert into tblschoolstandard(strstandard,intschoolid)values('" + chkstandard.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(qry);

                    DataSet ds2 = new DataSet();
                    qry = "select max(intschoolstandardid) as intschoolstandardid from tblschoolstandard";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolstandard", ds2.Tables[0].Rows[0]["intschoolstandardid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);


                }
            }
        }
        catch { }
    }

    protected void selectedsection()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            qry = "delete tblschoolsection where intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsection", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

            da.ExceuteSqlQuery(qry);
            for (int i = 0; i < chksection.Items.Count; i++)
            {
                if (chksection.Items[i].Selected == true)
                {
                    qry = "";
                    da = new DataAccess();
                    qry = "insert into tblschoolsection(strsection,intschoolid)values('" + chksection.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(qry);

                    DataSet ds2 = new DataSet();
                    qry = "select max(intschoolsectionid) as intschoolsectionid from tblschoolsection";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsection", ds2.Tables[0].Rows[0]["intschoolsectionid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

                }
            }
        }
        catch { }
    }

    protected void selectedsubject()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            qry = "delete tblschoolsubject where intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsubject", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

            da.ExceuteSqlQuery(qry);
            for (int i = 0; i < chksubject.Items.Count; i++)
            {
                if (chksubject.Items[i].Selected == true)
                {
                    qry = "";
                    da = new DataAccess();
                    qry = "insert into tblschoolsubject(strsubject,intschoolid)values('" + chksubject.Items[i].Text + "'," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(qry);

                    DataSet ds2 = new DataSet();
                    qry = "select max(intschoolsubjectid) as intschoolsubjectid from tblschoolsubject";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsubject", ds2.Tables[0].Rows[0]["intschoolsubjectid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

                }
            }
        }
        catch { }
    }

    protected void selectedlang()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            qry = "delete tblschoollanguages where intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoollanguages", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

            da.ExceuteSqlQuery(qry);
            for (int i = 0; i < chklang.Items.Count; i++)
            {
                if (chklang.Items[i].Selected == true)
                {
                    qry = "";
                    da = new DataAccess();
                    qry = "insert into tblschoollanguages(strlanguagename,intschoolid)values('" + chklang.Items[i].Text + "'," + Session["SchoolID"] + ")";
                    da.ExceuteSqlQuery(qry);

                    DataSet ds2 = new DataSet();
                    qry = "select max(intschoollanguagesid) as intschoollanguagesid from tblschoollanguages";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoollanguages", ds2.Tables[0].Rows[0]["intschoollanguagesid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

                }
            }
        }
        catch { }
    }

    protected void selectedExtracurricular()
    {
        try
        {
            string qry = "";
            DataAccess da = new DataAccess();
            qry = "delete tblschoolExtracurricular where intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolExtracurricular", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

            da.ExceuteSqlQuery(qry);
            for (int i = 0; i < chkextra.Items.Count; i++)
            {
                if (chkextra.Items[i].Selected == true)
                {
                    qry = "";
                    da = new DataAccess();
                    qry = "insert into tblschoolExtracurricular(strextracurricular,intschoolid)values('" + chkextra.Items[i].Text + "'," + Session["SchoolID"] + ")";
                    da.ExceuteSqlQuery(qry);

                    DataSet ds2 = new DataSet();
                    qry = "select max(intschoolcurricularid) as intschoolcurricularid from tblschoolExtracurricular";
                    ds2 = da.ExceuteSql(qry);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolExtracurricular", ds2.Tables[0].Rows[0]["intschoolcurricularid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),29);

                }
            }
        }
        catch { }
    }

    protected string selectedstandard1()
    {
        string str = "";
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            if (chkstandard.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkstandard.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkstandard.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected string selectedsection1()
    {
        string str = "";
        for (int i = 0; i < chksection.Items.Count; i++)
        {
            if (chksection.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chksection.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chksection.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected string selectedsubject1()
    {
        string str = "";
        for (int i = 0; i < chksubject.Items.Count; i++)
        {
            if (chksubject.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chksubject.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chksubject.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected string selectedextra1()
    {
        string str = "";
        for (int i = 0; i < chkextra.Items.Count; i++)
        {
            if (chkextra.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkextra.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkextra.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected string selectedlang1()
    {
        string str = "";
        for (int i = 0; i < chklang.Items.Count; i++)
        {
            if (chklang.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chklang.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chklang.Items[i].Value.ToString();
                }
            }
        }
        return str;
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



    

    //private void fillthirdlanguages()
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "select * from tbllanguages where strtype='Third' order by strlanguagename";
    //        DataSet ds = new DataSet();
    //        ds = da.ExceuteSql(sql);
    //        chkthirdlang.Items.Clear();
    //        ListItem li;
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            li = new ListItem(ds.Tables[0].Rows[i]["strlanguagename"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
    //            chkthirdlang.Items.Add(li);
    //        }
    //    }
    //    catch { }
    //}

    //protected void fillthirdlanguages1()
    //{
    //    try
    //    {
    //        for (int i = 0; i < chkthirdlang.Items.Count; i++)
    //        {
    //            string[] abc = Session["SelectedthirdLang"].ToString().Split(',');
    //            for (int j = 0; j < abc.Length; j++)
    //            {
    //                if (chkthirdlang.Items[i].Value.ToString() == abc[j].Trim())
    //                    chkthirdlang.Items[i].Selected = true;
    //            }
    //        }
    //    }
    //    catch { }
    //}

    //protected string selectedthirdlang1()
    //{
    //    string str = "";
    //    for (int i = 0; i < chkthirdlang.Items.Count; i++)
    //    {
    //        if (chkthirdlang.Items[i].Selected == true)
    //        {
    //            if (str.Length == 0)
    //            {
    //                str = chkthirdlang.Items[i].Value.ToString();
    //            }
    //            else
    //            {
    //                str = str + "," + chkthirdlang.Items[i].Value.ToString();
    //            }
    //        }
    //    }
    //    return str;
    //}

    //protected void selectedthirdlang()
    //{
    //    try
    //    {
    //        string qry = "";
    //        DataAccess da = new DataAccess();
    //        qry = "delete tblschoolthirdlanguages where intschoolid=" + Session["SchoolID"].ToString();
    //        da.ExceuteSqlQuery(qry);
    //        for (int i = 0; i < chkthirdlang.Items.Count; i++)
    //        {
    //            if (chkthirdlang.Items[i].Selected == true)
    //            {
    //                qry = "";
    //                da = new DataAccess();
    //                qry = "insert into tblschoolthirdlanguages(strlanguagename,intschoolid)values('" + chkthirdlang.Items[i].Text + "'," + Session["SchoolID"] + ")";
    //                da.ExceuteSqlQuery(qry);
    //            }
    //        }
    //    }
    //    catch { }
    //}

    //protected void Editthirdlanguages()
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "select * from tblschoolthirdlanguages where intschoolid=" + Session["SchoolID"];
    //        DataSet ds = new DataSet();
    //        ds = da.ExceuteSql(sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //            {
    //                for (int i = 0; i < chkthirdlang.Items.Count; i++)
    //                {
    //                    if (chkthirdlang.Items[i].Text == ds.Tables[0].Rows[j]["strlanguagename"].ToString())
    //                        chkthirdlang.Items[i].Selected = true;
    //                }
    //            }
    //        }
    //    }
    //    catch { }
    //}

    //protected void btnaddlangthird_Click(object sender, EventArgs e)
    //{
    //    Session["SelectedthirdLang"] = selectedthirdlang1();
    //    try
    //    {
    //        if (txtthirdlang.Text != "")
    //        {
    //            string qry = "";
    //            DataAccess da = new DataAccess();
    //            qry = "insert into tbllanguages(strlanguagename,strtype)values('" + txtthirdlang.Text.Trim() + "','Third')";
    //            da.ExceuteSqlQuery(qry);
    //            fillthirdlanguages();
    //            fillthirdlanguages1();
    //            txtthirdlang.Text = "";
    //        }
    //    }
    //    catch
    //    {
    //        MsgBox1.alert("Already Exist!");
    //    }
    //}
}
