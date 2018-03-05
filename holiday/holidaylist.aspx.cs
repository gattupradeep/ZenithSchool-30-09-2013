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

public partial class school_holidaylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillyear();
            Clear();
            fillcalender();
        }
    }

    private void fillyear()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblacademicyear where intyear > = (select intyear from tblacademicyear where intactive=1 and intschool=" + Session["SchoolID"].ToString() + ") and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "intyear";
        ddlyear.DataValueField = "intyear";
        ddlyear.DataBind();
    }

    private void fillcalender()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intid,convert(varchar(10),dtdate,111) as date,datename(dw,dtdate) as dayname,strholidayname from tblacademiccalender  where intschool=" + Session["SchoolID"].ToString() + " and stryear='" + ddlyear.SelectedValue + "' order by dtdate asc";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgcalender.DataSource = ds;
            dgcalender.DataBind();
            dgcalender.Visible = true;
        }
        else
        {
            dgcalender.Visible = false;
        }
        Clear();
    }

    private void Clear()
    {
        txtfromdate.Text = "";
        //txtTodate.Text = "";
        txtnameofholiday.Text = "";       
        btnSave.Text = "Save";
    }

    protected void dgcalender_EditCommand(object source, DataGridCommandEventArgs e)
    {
        hdnid.Value = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select *,convert(varchar(10),dtFromdate,111) as fromdate,convert(varchar(10),dtTodate,111) as todate from tblacademiccalender where intschool=" + Session["SchoolID"].ToString() + " and strholidayname='" + e.Item.Cells[2].Text.Replace("'","'+'''") + "' and dtdate='" + e.Item.Cells[1].Text + "'";
        ds = da.ExceuteSql(str);
        txtnameofholiday.Text = ds.Tables[0].Rows[0]["strholidayname"].ToString();
        txtfromdate.Text = ds.Tables[0].Rows[0]["fromdate"].ToString();
        //txtTodate.Text = ds.Tables[0].Rows[0]["todate"].ToString();
        ddlyear.SelectedValue = ds.Tables[0].Rows[0]["stryear"].ToString();
        btnSave.Text = "Update";
    }

    //protected void dgcalender_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete from tblacademiccalender where intid=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //        fillcalender();
    //    }
    //    catch { }
    //}

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "";
    //    DataSet ds;
    //    string found = "";
    //    if (txtTodate.Text != "")
    //    {
    //        TimeSpan ts = DateTime.Parse(txtTodate.Text.Trim()) - DateTime.Parse(txtfromdate.Text.Trim());
    //        int days = ts.Days;
    //        for (int i = 0; i <= days; i++)
    //        {
    //            sql = "select * from tblacademiccalender where intschool=" + Session["SchoolID"].ToString() + " and stryear='" + ddlyear.SelectedValue + "' and dtdate=dateadd(day," + i + ",CONVERT(VARCHAR(10),'" + txtfromdate.Text.Trim() + "',111))";
    //            ds = new DataSet();
    //            ds = da.ExceuteSql(sql);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('holiday is already assigned for selected date')", true);
    //                found = "true";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        sql = "select * from tblacademiccalender where intschool=" + Session["SchoolID"].ToString() + " and stryear='" + ddlyear.SelectedValue + "' and dtdate='" + txtfromdate.Text.Trim() + "'";
    //        ds = new DataSet();
    //        ds = da.ExceuteSql(sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('holiday is already assigned for selected date')", true);
    //            found = "true";
    //        }
    //    }
    //    if (found != "true")
    //    {
    //        if (btnSave.Text == "Save")
    //        {
    //            if (txtTodate.Text != "")
    //            {
    //                TimeSpan ts = DateTime.Parse(txtTodate.Text.Trim()) - DateTime.Parse(txtfromdate.Text.Trim());
    //                int days = ts.Days;
    //                for (int i = 0; i <= days; i++)
    //                {
    //                    string str = "insert into tblacademiccalender(dtdate,dtFromdate,strholidayname,intschool,dtTodate,stryear) values(dateadd(day," + i + ",CONVERT(VARCHAR(10),'" + txtfromdate.Text.Trim() + "',111)),'" + txtfromdate.Text.Trim() + "','" + txtnameofholiday.Text.Trim().Replace("'","'+'''") + "'," + Session["SchoolID"].ToString() + ",'" + txtTodate.Text.Trim() + "','" + ddlyear.SelectedValue + "')";
    //                    da.ExceuteSqlQuery(str);
    //                }
    //            }
    //            else
    //            {
    //                string str = "insert into tblacademiccalender(dtdate,dtFromdate,strholidayname,intschool,dtTodate,stryear) values('" + txtfromdate.Text.Trim() + "','" + txtfromdate.Text.Trim() + "','" + txtnameofholiday.Text.Trim().Replace("'", "'+'''") + "'," + Session["SchoolID"].ToString() + ",'" + txtfromdate.Text.Trim() + "','" + ddlyear.SelectedValue + "')";
    //                da.ExceuteSqlQuery(str);
    //            }
    //            Clear();
    //            fillcalender();
    //        }
    //        if (btnSave.Text == "Update")
    //        {
    //            string str = "delete tblacademiccalender where strholidayname='" + txtnameofholiday.Text.Trim() + "'";
    //            da.ExceuteSqlQuery(str);
    //            if (txtTodate.Text != "")
    //            {
    //                TimeSpan ts = DateTime.Parse(txtTodate.Text.Trim()) - DateTime.Parse(txtfromdate.Text.Trim());
    //                int days = ts.Days;
    //                for (int i = 0; i <= days; i++)
    //                {
    //                    str = "insert into tblacademiccalender(dtdate,dtFromdate,strholidayname,intschool,dtTodate,stryear)values(dateadd(day," + i + ",CONVERT(VARCHAR(10),'" + txtfromdate.Text.Trim() + "',111)),'" + txtfromdate.Text.Trim() + "','" + txtnameofholiday.Text.Trim() + "'," + Session["SchoolID"].ToString() + ",'" + txtTodate.Text.Trim() + "','" + ddlyear.SelectedValue + "')";
    //                    da.ExceuteSqlQuery(str);
    //                }
    //            }
    //            else
    //            {
    //                str = "insert into tblacademiccalender(dtdate,dtFromdate,strholidayname,intschool,dtTodate,stryear)values('" + txtfromdate.Text.Trim() + "','" + txtfromdate.Text.Trim() + "','" + txtnameofholiday.Text.Trim() + "'," + Session["SchoolID"].ToString() + ",'" + txtfromdate.Text.Trim() + "','" + ddlyear.SelectedValue + "')";
    //                da.ExceuteSqlQuery(str);
    //            }
    //            Clear();
    //            fillcalender();
    //        }
    //    }
    //    found = "";
    //}

    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillcalender();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string strsql;
        DataSet ds2 = new DataSet();

        if (btnSave.Text == "Save")
        {
            strsql = "insert into tblacademiccalender(dtdate,dtFromdate,strholidayname,intschool,dtTodate,stryear) values('" + txtfromdate.Text.Trim() + "','" + txtfromdate.Text.Trim() + "','" + txtnameofholiday.Text.Trim().Replace("'", "'+'''") + "'," + Session["SchoolID"].ToString() + ",'" + txtfromdate.Text.Trim() + "','" + ddlyear.SelectedValue + "')";
            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);

            strsql = "select max(intid)as intid from tblacademiccalender";
            ds2 = da.ExceuteSql(strsql);
            Functions.UserLogs(Session["UserID"].ToString(), "tblacademiccalender", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),223);
        }
        else
        {
            strsql = "update tblacademiccalender set dtdate='" + txtfromdate.Text.Trim() + "',dtFromdate='" + txtfromdate.Text.Trim() + "',strholidayname='" + txtnameofholiday.Text.Trim().Replace("'", "'+'''") + "',intschool=" + Session["SchoolID"].ToString() + ",dtTodate='" + txtfromdate.Text.Trim() + "',stryear='" + ddlyear.SelectedValue + "' where intid=" + hdnid.Value;
            Functions.UserLogs(Session["UserID"].ToString(), "tblacademiccalender", hdnid.Value, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 223);

            da = new DataAccess();
            da.ExceuteSqlQuery(strsql);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully!')", true);
        }
        fillcalender();
        Clear();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete from tblacademiccalender where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblacademiccalender", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),223);

            da.ExceuteSqlQuery(sql);
            fillcalender();
        }
        catch { }
    }
}
