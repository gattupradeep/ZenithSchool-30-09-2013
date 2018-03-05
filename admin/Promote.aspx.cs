using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_Promote : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            year();
            promotestandard();
            fillstandard();
            txtdate.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
        }
    }
    protected void year()
    {
        da = new DataAccess();
        strsql = " select intyear from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
        ds = da.ExceuteSql(strsql);
        ddlyear.DataTextField = "intyear";
        ddlyear.DataValueField = "intyear";
        ddlyear.DataSource = ds;
        ddlyear.DataBind();
        ListItem li;
        li = new ListItem("--Select--", "0");
        ddlstandard.Items.Insert(0, li);
    }
    protected void fillstandard()
    {
        da = new DataAccess();
        strsql = "select strstandard + ' - ' + strsection as strclass from tblstandard_section_subject where intschoolid = '" + Session["SchoolID"].ToString() + "' group by strstandard,strsection";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstandard.DataTextField = "strclass";
        ddlstandard.DataValueField = "strclass";
        ddlstandard.DataSource = ds;
        ddlstandard.DataBind();
        ListItem li;
        li = new ListItem("--Select--", "0");
        ddlstandard.Items.Insert(0, li);
    }
    protected void fillstudent()
    {
        da = new DataAccess();
        //strsql = "select strfirstname + ' ' + strmiddlename + ' ' + strlastname as studentname,intid,intadmitno from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "'";
        strsql = "select strfirstname + ' ' + strmiddlename + ' ' + strlastname as studentname,intid,intadmitno from tblstudent ";
        strsql += " where intadmitno not in(select strAdmissionNo from tblPromoted where intYear in (select intYear from tblAcademicYear where intschool=" + Session["SchoolID"].ToString() + " and intactive=1) ";
        strsql += " and strstandard+' - '+strsection !=strStandardSec and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString() + " and intTransferredID=0 and strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "'";

        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgpromote.DataSource = ds;
            dgpromote.DataBind();
            trgrid.Visible = true;
            trbutton.Visible = true;
        }
        else
        {
            trgrid.Visible = false;
            trbutton.Visible = false;
        }
        clear();
    }
    protected void promotestandard()
    {
        da = new DataAccess();
        strsql = "select strstandard from tblstandard_section_subject where intschoolid = '" + Session["SchoolID"].ToString() + "' group by strstandard";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlpromotestand.DataTextField = "strstandard";
        ddlpromotestand.DataValueField = "strstandard";
        ddlpromotestand.DataSource = ds;
        ddlpromotestand.DataBind();
        ListItem li;
        li = new ListItem("--Select--", "0");
        ddlpromotestand.Items.Insert(0, li);
    }
    protected void section()
    {
        da = new DataAccess();
        strsql = "select strsection from tblstandard_section_subject where strstandard='" + ddlpromotestand.SelectedValue + "' and intschoolid = '" + Session["SchoolID"].ToString() + "' group by strsection";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataSource = ds;
        ddlsection.DataBind();
        //ListItem li;
        //li = new ListItem("--Select--", "0");
        //ddlsection.Items.Insert(0, li);
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (DataGridItem dgit in dgpromote.Items)
        {
            DataRowView drd = (DataRowView)dgit.DataItem;
            RadioButton rbtnpromote = (RadioButton)dgit.FindControl("rbtnpromote");
            RadioButton rbtndepromote = (RadioButton)dgit.FindControl("rbtndepromote");
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select b.* from tblstudent a,tblPromoted b where a.strstandard+' - '+a.strsection=b.strStandardSec ";
            strsql += " and a.intadmitno=b.strAdmissionNo and intYear in(select intYear from tblAcademicYear where intschool=" + Session["Schoolid"].ToString()+" and intactive=1) and stradmissionno='" + dgit.Cells[2].Text + "' and b.intschool=" + Session["Schoolid"].ToString();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (rbtnpromote.Checked)
                {                    
                    strsql = "update tblstudent set strstandard='" + ddlpromotestand.SelectedValue + "',strsection='" + ddlsection.SelectedValue + "',intPromotedID=1 where intadmitno='" + dgit.Cells[2].Text + "' and intid=" + dgit.Cells[0].Text;
                    da.ExceuteSqlQuery(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", dgit.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 361);
                }
                else
                {
                    
                }
            }
            else
            {
                if (rbtnpromote.Checked)
                {
                    da = new DataAccess();
                    DataSet ds2 = new DataSet();
                    strsql = " insert into tblPromoted (stradmissionno,strstandardsec,intyear,intschool) values ('" + dgit.Cells[2].Text + "','" + ddlstandard.SelectedValue + "','" + ddlyear.SelectedValue + "'," + Session["Schoolid"].ToString() + ")";
                    da.ExceuteSqlQuery(strsql);

                    da = new DataAccess();
                    ds2 = new DataSet();
                    strsql = "select max(intPromotedID) as intPromotedID from tblPromoted";
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblPromoted", ds2.Tables[0].Rows[0]["intPromotedID"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 361);

                    strsql = "update tblstudent set strstandard='" + ddlpromotestand.SelectedValue + "',strsection='" + ddlsection.SelectedValue + "',intPromotedID=1 where intadmitno='" + dgit.Cells[2].Text + "' and intid=" + dgit.Cells[0].Text;
                    da.ExceuteSqlQuery(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", dgit.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 361);
                }
                else
                {
                    da = new DataAccess();
                    DataSet ds2 = new DataSet();
                    strsql = " insert into tblPromoted (stradmissionno,strstandardsec,intyear,intschool) values ('" + dgit.Cells[2].Text + "','" + ddlstandard.SelectedValue + "','" + ddlyear.SelectedValue + "'," + Session["Schoolid"].ToString() + ")";
                    da.ExceuteSqlQuery(strsql);

                    strsql = "select max(intPromotedID) as intPromotedID from tblPromoted";
                    da = new DataAccess();
                    ds2 = new DataSet();
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblPromoted", ds2.Tables[0].Rows[0]["intPromotedID"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 361);
                }
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Promoted Successfully')", true);
        fillstudent();
    }
   
    protected void ddlpromotestand_SelectedIndexChanged(object sender, EventArgs e)
    {
        section();
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void clear()
    {
        ddlpromotestand.SelectedIndex = 0;
        //ddlsection.SelectedIndex = 0;
    }
}
