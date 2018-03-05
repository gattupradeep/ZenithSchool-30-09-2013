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

public partial class school_timingsandperiods : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            timepicker_3.Text = "08:00";
            timepicker_4.Text = "08:00";
            timepicker_5.Text = "08:00";
            timepicker_6.Text = "08:00";
            timepicker_7.Text = "08:00";
            timepicker_8.Text = "08:00";
            
           
            if (Request["sid"] != null)
                filldetails();

            int SPI = 0;
            try
            {
                SPI = int.Parse(Session["SProfileIndex"].ToString());
            }
            catch
            {
                SPI = 0;
            }
            if (SPI < 2 && SPI !=0)
                Session["SProfileIndex"] = 2;
        }
        trassembly.Visible = false;
    }
        
    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        filltheperiods();
       
        Response.Redirect("../school/viewtimingsandperiods.aspx?sid=" + Session["SchoolID"].ToString());
        
    }
    
    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select * from tbltimingsandperiods where intschoolid=" + Request["sid"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            timepicker_3.Text = ds.Tables[0].Rows[0]["strstarttime"].ToString();
            timepicker_4.Text = ds.Tables[0].Rows[0]["strendtime"].ToString();
            timepicker_5.Text = ds.Tables[0].Rows[0]["strfirstbell"].ToString();
            timepicker_6.Text = ds.Tables[0].Rows[0]["strsecondbell"].ToString();
            timepicker_7.Text = ds.Tables[0].Rows[0]["strassembly"].ToString();
            timepicker_8.Text = ds.Tables[0].Rows[0]["strassemblyend"].ToString();
          
        }
        
        btnSave.Text = "Update";
       
    }

   protected void filltheperiods()
    {
        
        try
        {
            DateTime sST;
            DateTime sET;
            DateTime sFB;
            DateTime sSB;
            DateTime aST;
            DateTime aET;

            if(timepicker_3.Text!="")
                sST = DateTime.Parse(timepicker_3.Text);
            else
                sST = DateTime.Parse("08:00");

            if (timepicker_4.Text != "")
                sET = DateTime.Parse(timepicker_4.Text);
            else
                sET = DateTime.Parse("08:00");

            if (timepicker_5.Text != "")
                sFB = DateTime.Parse(timepicker_5.Text);
            else
                sFB = DateTime.Parse("08:00");

            if (timepicker_6.Text != "")
                sSB = DateTime.Parse(timepicker_6.Text);
            else
                sSB = DateTime.Parse("08:00");

            if (timepicker_7.Text != "")
                aST = DateTime.Parse(timepicker_7.Text);
            else
                aST = DateTime.Parse("08:00");

            if (timepicker_8.Text != "")
                aET = DateTime.Parse(timepicker_8.Text);
            else
                aET = DateTime.Parse("08:00");


            //if (sET < aST || sFB < sST || sFB > sET || sSB < sFB || sSB < sST || sSB > sET || aST < sST || aST > sET || aET < aST || aET < sST || aET > sET || sSB > aET)
            if (sET < aST || sFB < sST || sFB > sET || sSB < sFB || sSB < sST || aST < sST || aST > sET || aET < aST || aET < sST || aET > sET)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('School Timings are Wrong Pls Check!')", true);
            }
            else
            {
                SqlCommand command;
                SqlParameter OutPutParam;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("sptimingsandperiods", conn);
                command.CommandType = CommandType.StoredProcedure;
                OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
                OutPutParam.Direction = ParameterDirection.Output;
                command.Parameters.Add("@intschoolid", Session["SchoolID"].ToString());
                command.Parameters.Add("@strstarttime", timepicker_3.Text.Trim());
                command.Parameters.Add("@strendtime", timepicker_4.Text.Trim());
                command.Parameters.Add("@strfirstbell", timepicker_5.Text.Trim());
                command.Parameters.Add("@strsecondbell", timepicker_6.Text.Trim());
                command.Parameters.Add("@strassembly", timepicker_7.Text.Trim());
                command.Parameters.Add("@strassemblyend", timepicker_8.Text.Trim());
                command.ExecuteNonQuery();
                conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                Functions.UserLogs(Session["UserID"].ToString(), "tbltimingsandperiods", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 27);
            }
           
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Time Format!')", true);
        }
    }

    private void clear()
    {
        timepicker_3.Text = "";
        timepicker_4.Text = "";
        timepicker_5.Text = "";
        timepicker_6.Text = "";
        timepicker_7.Text = "";
        timepicker_8.Text = "";
    }
    protected void ddlETHH_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dlhh = new DropDownList();
        DropDownList dlmm = new DropDownList();
        dlhh = (DropDownList)item.FindControl("ddlETHH");
        dlmm = (DropDownList)item.FindControl("ddlETMM");
        if (DateTime.Parse(item.Cells[1].Text) > DateTime.Parse(dlhh.SelectedValue + ":" + dlmm.SelectedValue))
        {
            //lblerror.Text = "Invalid Time!";
        }
        else
        {
            DataAccess da = new DataAccess();

            string str = "select intid from tblschoolperiodstemp where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds.Tables[0].Rows[0]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),27);

                }
            }
            str = "update tblschoolperiodstemp set strSTHH='" + dlhh.SelectedValue + "',strSTMM='" + dlmm.SelectedValue + "' where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            da.ExceuteSqlQuery(str);

            da = new DataAccess();
            str = "update tblschoolperiodstemp set strETHH='" + dlhh.SelectedValue + "',strETMM='" + dlmm.SelectedValue + "' where intid=" + item.Cells[3].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", item.Cells[3].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),27);

            da.ExceuteSqlQuery(str);
            filltheperiods();
        }
    }

    protected void ddlETMM_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dlhh = new DropDownList();
        DropDownList dlmm = new DropDownList();
        dlhh = (DropDownList)item.FindControl("ddlETHH");
        dlmm = (DropDownList)item.FindControl("ddlETMM");
        if (DateTime.Parse(item.Cells[1].Text) > DateTime.Parse(dlhh.SelectedValue + ":" + dlmm.SelectedValue))
        {
            //lblerror.Text = "Invalid Time!";
        }
        else
        {
            ///lblerror.Text = "";
            DataAccess da = new DataAccess();

            string str = "select intid from tblschoolperiodstemp where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds.Tables[0].Rows[0]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),27);

                }
            }

            str = "update tblschoolperiodstemp set strSTHH='" + dlhh.SelectedValue + "',strSTMM='" + dlmm.SelectedValue + "' where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            da.ExceuteSqlQuery(str);

            da = new DataAccess();
            str = "update tblschoolperiodstemp set strETHH='" + dlhh.SelectedValue + "',strETMM='" + dlmm.SelectedValue + "' where intid=" + item.Cells[3].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", item.Cells[3].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),27);

            da.ExceuteSqlQuery(str);

            filltheperiods();
        }
    }

    protected void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DropDownList dlhh = new DropDownList();
            DropDownList dlmm = new DropDownList();
            dlhh = (DropDownList)e.Item.FindControl("ddlETHH");
            dlmm = (DropDownList)e.Item.FindControl("ddlETMM");
            dlhh.SelectedValue = dr["strETHH"].ToString();
            dlmm.SelectedValue = dr["strETMM"].ToString();
        }
        catch { }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
}
