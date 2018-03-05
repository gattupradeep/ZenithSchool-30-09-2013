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

public partial class noticeboard_editnotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillnotice();
            //fillgrid();
            Clear();
        }
    }
    private void fillnotice()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select a.strnoticename,b.intnotice from tblnoticeboard a,tbldailynotice b where b.intnotice=a.intid and b.intschool=" + Session["SchoolID"].ToString() + " group by a.strnoticename,b.intnotice";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlnotice.DataSource = ds;
        ddlnotice.DataTextField = "strnoticename";
        ddlnotice.DataValueField = "intnotice";
        ddlnotice.DataBind();
        ddlnotice.Items.Insert(0, "Select");
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.intid,a.strdescription,convert(varchar(10),a.dtdate,111) as dtdate,a.intnotice,b.strnoticename from tbldailynotice a,tblnoticeboard b where a.intnotice=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        if (ddlnotice.SelectedValue == "All")
        {
            str = "select a.intid,a.strdescription,convert(varchar(10),a.dtdate,111) as dtdate,a.intnotice,b.strnoticename from tbldailynotice a,tblnoticeboard b where a.intnotice=b.intid and a.intschool=" + Session["SchoolID"].ToString();
            if (txtdate.Text != "")
            {
                str += " and a.dtdate = convert(datetime,'" + txtdate.Text + "',111)";
            }
            str += " order by dtdate";
        }
        else
        {
            if (ddlnotice.SelectedIndex > 0)
            {
                str += " and a.intnotice='" + ddlnotice.SelectedValue + "'";
            }
            if (txtdate.Text != "")
            {
                str += " and a.dtdate = convert(datetime,'" + txtdate.Text + "',111)";
            }
            str += " order by dtdate";
        }

        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgnotice.DataSource = ds;
            dgnotice.DataBind();

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No search criteria found for selected!')", true);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlParameter OutPutParam;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        command = new SqlCommand("Spdailynotice", conn);
        command.CommandType = CommandType.StoredProcedure;
        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intID", "0");
        }
        else
        {
            command.Parameters.Add("@intID", Session["intID"].ToString());
        }
        command.Parameters.Add("@intnotice", ddlnotice.SelectedValue);
        command.Parameters.Add("@dtdate", txtdate.Text.Trim());
        command.Parameters.Add("@strdescription", txtdes.Text.Trim());
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.ExecuteNonQuery();
        conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldailynotice", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 257);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
        }
        else 
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldailynotice", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 257);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully!')", true);
        }
        fillgrid();
        Clear();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtdate.Text = "";
        txtdes.Text = "";
        btnSave.Text = "Save";
    }
    protected void dgnotice_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtdate.Text = e.Item.Cells[1].Text;
        txtdes.Text = e.Item.Cells[2].Text;
        fillnotice();
        ddlnotice.SelectedValue = e.Item.Cells[4].Text;
        btnSave.Text = "Update";
    }
    //protected void dgnotice_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete tbldailynotice where intid=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //        fillgrid();
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
    //    }
    //}
    protected void ddlnotice_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tbldailynotice where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tbldailynotice", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),257);

            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
        }
    }
}
