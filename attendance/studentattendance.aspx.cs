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

public partial class attendance_studentattendance : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillday();
            fillyear();
            ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
            ddlday2.SelectedValue = DateTime.Now.Day.ToString();
            ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
            fillstandard();
        }
    }

    protected void fillday()
    {
        int j = 0;
        for (int i = 1; i < 32; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlday2.Items.Insert(j, li);
            j++;
        }
    }
    protected void fillyear()
    {
        int j = 0;
        for (int i = DateTime.Now.Year - 1; i <= DateTime.Now.Year; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear2.Items.Insert(j, li);
            j++;
        }
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
        int err = 0;
        da = new DataAccess();
        strsql = "select strweekholidays from tblworkingdays where strmode='Holiday' and intschoolid=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue).ToLongDateString().IndexOf(ds.Tables[0].Rows[i]["strweekholidays"].ToString()) > -1)
            {
                err = 1;
            }
        }
        if (err == 0)
        {
            err=0;
            da = new DataAccess();
            strsql = "select * from tblacademiccalender where dtdate='" + ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and stryear = (select top 1 ltrim(str(intyear)) from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ")";
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance Cannot Be Assigned On Holidays')", true);
                ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
                ddlday2.SelectedValue = DateTime.Now.Day.ToString();
                ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
            }
            else
            {
                if (DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue) <= DateTime.Today)
                {
                    btnsave.Text = "Save";
                    da = new DataAccess();
                    strsql = "select strfirstname + ' ' + strmiddlename + ' ' + strlastname as studentname,intid from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "'";
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgstudentattend.DataSource = ds;
                        dgstudentattend.DataBind();
                        trgrid.Visible = true;
                        trbutton.Visible = true;
                        lblerror.Visible = false;
                    }
                    else
                    {
                        trgrid.Visible = false;
                        trbutton.Visible = false;
                        lblerror.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance Can Be Assigned Only For Current And Previous Dates')", true);
                    ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
                    ddlday2.SelectedValue = DateTime.Now.Day.ToString();
                    ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance Cannot Be Assigned On Holidays')", true);
            ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
            ddlday2.SelectedValue = DateTime.Now.Day.ToString();
            ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int err = 0;
        try
        {
            DateTime sdt = DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue);
        }
        catch
        {
            err = 1;
        }
        if (err == 0)
        {
            if (ddlstandard.SelectedIndex > 0)
            {
                string strsql = "select intid from tblstudentattendance where dtdate='" + ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "' and strclass='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "";
                DataSet ds2 = new DataSet();
                DataAccess da2 = new DataAccess();
                ds2 = da2.ExceuteSql(strsql);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblstudentattendance", ds2.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),57);
                    }
                }

                da = new DataAccess();
                string str = "delete tblstudentattendance where dtdate='" + ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "' and strclass='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "";
                da.ExceuteSqlQuery(str);
                foreach (DataGridItem dgit in dgstudentattend.Items)
                {
                    DataRowView drd = (DataRowView)dgit.DataItem;
                    RadioButton rbtnpresent = (RadioButton)dgit.FindControl("rbtnpresent");
                    RadioButton rbtnabsent = (RadioButton)dgit.FindControl("rbtnabsent");
                    TextBox txtreason = (TextBox)dgit.FindControl("txtreason");
                    DropDownList ddlsession = (DropDownList)dgit.FindControl("ddlseasion");
                    if (rbtnabsent.Checked)
                    {
                        SqlCommand RegCommand;
                        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                        Conn.Open();
                        RegCommand = new SqlCommand("spstudentattendance", Conn);
                        RegCommand.CommandType = CommandType.StoredProcedure;
                        RegCommand.Parameters.Add("@intID", "0");
                        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        RegCommand.Parameters.Add("@intstaff", Session["UserID"].ToString());
                        RegCommand.Parameters.Add("@strclass", ddlstandard.SelectedValue);
                        RegCommand.Parameters.Add("@intstudent", dgit.Cells[0].Text);
                        RegCommand.Parameters.Add("@dtdate", ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue);
                        RegCommand.Parameters.Add("@strsession", ddlsession.SelectedValue);
                        RegCommand.Parameters.Add("@strclassteacher", lblhometeacher.Text);
                        RegCommand.Parameters.Add("@strreason", txtreason.Text.Trim());
                        RegCommand.ExecuteNonQuery();
                        Conn.Close();
                    }
                }
                //Response.Redirect("studentattendance.aspx");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Saved Successfully!'); location.href='studentattendance.aspx';", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Date')", true);

    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0)
        {
            da = new DataAccess();
            ds = new DataSet();
            string stdsec = ddlstandard.SelectedValue;
            strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername,a.intid from tblemployee a,tblhomeclass b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.intemployee and b.strhomeclass='" + stdsec + "'";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
                lblhometeacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
            else
                lblhometeacher.Text = "Home Teacher Not Assigned";
            trgrid.Visible = true;
            trbutton.Visible = true;
            fillstudent();
        }
        else
        {
            lblhometeacher.Text = "Select Class & Section";
            trgrid.Visible = false;
            trbutton.Visible = false;
        }
    }

    protected void leaveRequest()
    {   
        //strsql = "select * from dbo.tblstudentleaverequest where strstudentname=" + ddlstudent.SelectedValue + " and intapproved=0 and dtfromdate<='" + txtdate.Text + "' and dttodate>='" + txtdate.Text + "'";
        //da = new DataAccess();
        //ds = new DataSet();
        //ds = da.ExceuteSql(strsql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    btnsave.Visible = true;
        //    lblmsg.Text = "this student's leave request did not approved";
        //    lblmsg.Visible = true;
        //} 
        //strsql = "select * from dbo.tblstudentleaverequest where strstudentname=" + ddlstudent.SelectedValue + " and intapproved=0 and dtfromdate<='" +txtdate.Text.Trim() + "' and dttodate>='" + txtdate.Text.Trim()+"'";
        //da = new DataAccess();
        //ds = new DataSet();
        //ds = da.ExceuteSql(strsql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    btnsave.Visible = false;
        //    lblmsg.Text = "this student's leave request is approved";
        //    lblmsg.Visible = true;
        //}
        //else
        //{
        //    btnsave.Visible = true;
        //    lblmsg.Visible = false;
        //}
    }

    protected void dgstudentattend_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DropDownList ddlsession = (DropDownList)e.Item.FindControl("ddlseasion");
            RadioButton rbtnpresent = (RadioButton)e.Item.FindControl("rbtnpresent");
            RadioButton rbtnabsent = (RadioButton)e.Item.FindControl("rbtnabsent");
            TextBox txtreason = (TextBox)e.Item.FindControl("txtreason");
            DataRowView dr = (DataRowView)e.Item.DataItem;

            da = new DataAccess();
            strsql = "select * from tblstudentattendance where strclass='" + ddlstandard.SelectedValue + "' and dtdate='" + ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "' and intstudent=" + dr["intid"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsession.SelectedValue = ds.Tables[0].Rows[0]["strsession"].ToString();
                txtreason.Text = ds.Tables[0].Rows[0]["strreason"].ToString();
                rbtnabsent.Checked = true;
                rbtnpresent.Checked = false;
                btnsave.Text = "Update";
            }
            else
            {
                rbtnabsent.Checked = false;
                rbtnpresent.Checked = true;
            }
        }
        catch { }
    }
    protected void ddlday2_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }

    protected void ddlmonth2_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }

    protected void ddlyear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("studentattendance.aspx");
    }
}
