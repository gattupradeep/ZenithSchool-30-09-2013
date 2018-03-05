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

public partial class admin_schoolgrading : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    
    protected void dggrade_EditCommand(object source, DataGridCommandEventArgs e)
    {
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        strsql = "select top 1 intschoolgradingid,inttomarks from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString() + " and intschoolgradingid > " + e.Item.Cells[0].Text + " order by intschoolgradingid";
        ds = da.ExceuteSql(strsql);
        double ntm=100;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ntm = double.Parse(ds.Tables[0].Rows[0]["inttomarks"].ToString())-1;
        }

        TextBox txttomarks = (TextBox)e.Item.FindControl("txttomarks");
        TextBox txtgrade = (TextBox)e.Item.FindControl("txtgrade");
        double fm = double.Parse(e.Item.Cells[3].Text);
        double tm;
        try
        {
            tm = double.Parse(txttomarks.Text);
            if (tm <= 100)
            {
                if (tm > fm)
                {
                    if (tm < ntm)
                    {
                        if (txtgrade.Text != "")
                        {
                            strsql = "update tblschoolgrading set strgrade='" + txtgrade.Text + "',inttomarks=" + txttomarks.Text + " where intschoolgradingid="+ e.Item.Cells[0].Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgrading", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),33);

                            da.ExceuteSqlQuery(strsql);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ntm = tm + 1;
                                strsql = "update tblschoolgrading set intfrommarks=" + ntm.ToString() + " where intschoolgradingid=" + ds.Tables[0].Rows[0]["intschoolgradingid"].ToString();
                                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgrading", ds.Tables[0].Rows[0]["intschoolgradingid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),33);

                                da.ExceuteSqlQuery(strsql);
                            }
                            fillgrid();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please enter grade')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('To Marks cannont be more than " + ntm.ToString() + "')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('To Marks cannont be less than from marks')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('To Marks cannont be more than 100')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid To Marks')", true);
        }
    }

    //protected void dggrade_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string strsql = "";
    //    DataSet ds = new DataSet();
    //    DataAccess da = new DataAccess();

    //    strsql = "select top 1 intschoolgradingid,inttomarks from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString() + " and intschoolgradingid < " + e.Item.Cells[0].Text + " order by intschoolgradingid desc";
    //    ds = new DataSet();
    //    ds = da.ExceuteSql(strsql);
    //    double ntm = 0;
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ntm = double.Parse(ds.Tables[0].Rows[0]["inttomarks"].ToString()) + 1;
    //    }

    //    strsql = "select top 1 intschoolgradingid,inttomarks from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString() + " and intschoolgradingid > " + e.Item.Cells[0].Text + " order by intschoolgradingid";
    //    ds = new DataSet();
    //    ds = da.ExceuteSql(strsql);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        strsql = "update tblschoolgrading set intfrommarks=" + ntm.ToString() + " where intschoolgradingid=" + ds.Tables[0].Rows[0]["intschoolgradingid"].ToString();
    //        da.ExceuteSqlQuery(strsql);
    //    }

    //    strsql = "delete from tblschoolgrading where intschoolgradingid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(strsql);
    //    fillgrid();
    //}

    protected void dggrade_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            TextBox txttomarks = (TextBox)e.Item.FindControl("txttomarks");
            TextBox txtgrade = (TextBox)e.Item.FindControl("txtgrade");
            txttomarks.Text = dr["inttomarks"].ToString();
            txtgrade.Text = dr["strgrade"].ToString();
        }
        catch { }
    }

    protected void dggrade1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            TextBox txttomarks = (TextBox)e.Item.FindControl("txttomarks");
            txttomarks.Text = dr["inttomarks"].ToString();
        }
        catch { }
    }

    protected void dggrade1_EditCommand(object source, DataGridCommandEventArgs e)
    {
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        TextBox txttomarks = (TextBox)e.Item.FindControl("txttomarks");
        TextBox txtgrade = (TextBox)e.Item.FindControl("txtgrade");
        double fm = double.Parse(e.Item.Cells[2].Text);
        double tm;
        try
        {
            tm = double.Parse(txttomarks.Text);
            if (tm <= 100)
            {
                if (tm > fm)
                {
                    if (txtgrade.Text != "")
                    {
                        strsql = "insert into tblschoolgrading (intschoolid,strgrade,intfrommarks,inttomarks) values(" + Session["SchoolID"].ToString() + ",'" + txtgrade.Text + "'," + e.Item.Cells[2].Text + "," + txttomarks.Text + ")";
                        da.ExceuteSqlQuery(strsql);
                        fillgrid();

                        DataSet ds2 = new DataSet();
                        strsql = "select max(intschoolgradingid) as intschoolgradingid from tblschoolgrading";
                        ds2 = da.ExceuteSql(strsql);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgrading", ds2.Tables[0].Rows[0]["intschoolgradingid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),33);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please enter grade')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('To Marks cannont be less than from marks')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('To Marks cannont be more than 100')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid To Marks')", true);
        }
    }

    protected void Btnsave_Click(object sender, EventArgs e)
    {
        if (Request["sid"] != null)
            Response.Redirect("../school/viewschoolgrading.aspx");
        else
        {
            Session["SProfileIndex"] = 10;
            Session["UserRights"] = "Yes";
            Response.Redirect("../school/viewschoolgrading.aspx");
        }
    }

    protected void fillgrid()
    {
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        strsql = "select * from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString() + " order by intfrommarks";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dggrade.DataSource = ds;
        dggrade.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            strsql = "select '' as strgrade,0 as intfrommarks,100 as inttomarks";
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            dggrade1.DataSource = ds;
            dggrade1.DataBind();
            Btnsave.Visible = false;
        }
        else
        {
            strsql = "select MAX(inttomarks)from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (double.Parse(ds.Tables[0].Rows[0][0].ToString()) < 100)
            {
                double fm = double.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                da = new DataAccess();
                strsql = "select '' as strgrade," + fm.ToString() + " as intfrommarks,100 as inttomarks";
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                dggrade1.DataSource = ds;
                dggrade1.DataBind();
                dggrade1.Visible = true;
            }
            else
            {
                dggrade1.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You have completed Grading')", true);
            }

            Btnsave.Visible = true;
        }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        strsql = "select top 1 intschoolgradingid,inttomarks from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString() + " and intschoolgradingid < " + item.Cells[0].Text + " order by intschoolgradingid desc";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        double ntm = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ntm = double.Parse(ds.Tables[0].Rows[0]["inttomarks"].ToString()) + 1;
        }

        strsql = "select top 1 intschoolgradingid,inttomarks from tblschoolgrading where intschoolid=" + Session["SchoolID"].ToString() + " and intschoolgradingid > " + item.Cells[0].Text + " order by intschoolgradingid";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            strsql = "update tblschoolgrading set intfrommarks=" + ntm.ToString() + " where intschoolgradingid=" + ds.Tables[0].Rows[0]["intschoolgradingid"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgrading", ds.Tables[0].Rows[0]["intschoolgradingid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),33);

            da.ExceuteSqlQuery(strsql);
        }

        strsql = "delete from tblschoolgrading where intschoolgradingid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolgrading", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),33);

        da.ExceuteSqlQuery(strsql);
        fillgrid();
    }
}
