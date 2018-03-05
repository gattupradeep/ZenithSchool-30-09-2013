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


public partial class school_workingdays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trtag.Visible = false;
            fillgrid();
            fillworkingdays();
            if (Request["id"] != null)
                Button1.Text = "Done";
            int SPI = 0;
            try
            {
                SPI = int.Parse(Session["SProfileIndex"].ToString());
            }
            catch
            {
                SPI = 0;
            }
            if (SPI < 3 && SPI != 0)
                Session["SProfileIndex"] = 3;
        }
    }

    protected void dgholidays_EditCommand(object source, DataGridCommandEventArgs e)
    {        
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();        
        string sql = "";
        sql = "select * from tblworkingdays where intworkingdaysid =" + e.Item.Cells[0].Text;
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["strmode"].ToString() == "Holiday")
            {
                rbholiday.Checked = true;
                rbhalfday.Checked = false;
                trtag.Visible = false;
            }
            else
            {
                rbhalfday.Checked = true;
                rbholiday.Checked = false;
                txtstarttime.Text = ds.Tables[0].Rows[0]["strhstarttime"].ToString();
                txtendtime.Text = ds.Tables[0].Rows[0]["strhendtime"].ToString();
                trtag.Visible = true;
            }
            ddlday.SelectedValue = ds.Tables[0].Rows[0]["strweekholidays"].ToString();
            
        }
        Session["intworkingid"] = e.Item.Cells[0].Text;
        btnSave.Text = "Update";
        btnSave.Enabled = true;
    }

    protected void rbhalfday_CheckedChanged(object sender, EventArgs e)
    {
        trtag.Visible = true;
    }

    protected void rbholiday_CheckedChanged(object sender, EventArgs e)
    {
        trtag.Visible = false;
    }

    //protected void dgholidays_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete tblworkingdays where intworkingdaysid=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //    }
    //    catch { }
    //    fillgrid();
    //    fillworkingdays();
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Done")
            Response.Redirect("../school/viewworkingdays.aspx");
        else
            redirectpages();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlday.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the Day!')", true);
        }
        else
        {
            if (rbhalfday.Checked)
            {
                try
                {
                    if (DateTime.Parse(txtstarttime.Text) > DateTime.Parse(txtendtime.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid End Time')", true);
                    }
                    else
                    {
                        DataAccess da = new DataAccess();
                        DataSet ds = new DataSet();
                        string sql = "";
                        sql = " select strendtime from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
                        ds = da.ExceuteSql(sql);
                        if (DateTime.Parse(txtendtime.Text) >= DateTime.Parse(ds.Tables[0].Rows[0]["strendtime"].ToString()))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('End time exceeds school end time')", true);
                        }
                        else
                        {
                            saveworkingdays();
                            txtstarttime.Text = "";
                            txtendtime.Text = "";
                            btnSave.Text = "Save";
                            fillgrid();
                            fillworkingdays();
                        }
                    }
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Time Format - Please Enter in HH:MM')", true);
                }
            }
            else
            {
                txtstarttime.Text = "";
                txtendtime.Text = "";
                saveworkingdays();
                btnSave.Text = "Save";
                fillgrid();
                fillworkingdays();
            }
        }
    }

    protected void saveworkingdays()
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter OutPutParam;
        conn.Open();
        command = new SqlCommand("spworkingdays", conn);
        command.CommandType = CommandType.StoredProcedure;
        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intid", "0");
        }
        else
        {
            command.Parameters.Add("@intid", Session["intworkingid"].ToString());
        }
        command.Parameters.Add("@intschool", Session["SchoolID"]);
        command.Parameters.Add("@strweekholidays", ddlday.SelectedValue);
        string strmode;
        if (rbhalfday.Checked)
            strmode = "Halfday";
        else
            strmode = "Holiday";

        command.Parameters.Add("@strmode", strmode);
        command.Parameters.Add("@strhstarttime", txtstarttime.Text.Trim());
        command.Parameters.Add("@strhendtime", txtendtime.Text.Trim());
        command.Parameters.Add("@intday", ddlday.SelectedIndex);
        command.ExecuteNonQuery();
        if ((int)(command.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Already Exists!");
        }
        conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblworkingdays", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 28);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblworkingdays", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 28);
        }
    }

    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "";
        sql = "select * from tblworkingdays where strmode='Holiday' and intschoolid=" + Session["SchoolID"].ToString() + " union all select * from tblworkingdays where strmode='Halfday' and intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        dgholidays.DataSource = ds;
        dgholidays.DataBind();
        if (ds.Tables[0].Rows.Count > 2)
        {
            btnSave.Enabled = false;
            btnSave.Text = "Only Three Holidays Allowed";
        }
        else
        {
            btnSave.Enabled = true;
            btnSave.Text = "Save";
        }
    }

    protected void fillworkingdays()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "";
        sql = "select * from (";
        sql = sql + " select * from (select 'Monday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 2 as intday  from ";
        sql = sql + " tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Tuesday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 3 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Wednesday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 4 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Thursday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 5 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Friday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 6 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Saturday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 7 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        sql = sql + " union all select 'Sunday' as strweekholidays, 'Fullday' as strmode,strstarttime,strendtime, 1 as intday  from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString() + ") as a";
        sql = sql + " where strweekholidays not in (select strweekholidays from tblworkingdays where intschoolid=" + Session["SchoolID"].ToString() + ")";
        sql = sql + " union all select strweekholidays,strmode,strhstarttime,strhendtime,intday from tblworkingdays where strmode!='Holiday' and intschoolid=" + Session["SchoolID"].ToString() + ") as b order by intday";

        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgworkingdays.DataSource = ds;
            dgworkingdays.DataBind();
        }
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

    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblworkingdays where intworkingdaysid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblworkingdays", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),28);

            da.ExceuteSqlQuery(sql);
        }
        catch { }
        fillgrid();
        fillworkingdays();
    }
}
