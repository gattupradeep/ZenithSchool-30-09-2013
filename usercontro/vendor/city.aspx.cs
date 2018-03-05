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

public partial class vendor_city : System.Web.UI.Page
{
    public SqlCommand cmd;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcountry();
            fillstate();
        }
    }

    protected void fillcountry()
    {
        strsql = "select * from tblcountry";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlcountry.DataSource = ds;
        ddlcountry.DataTextField = "countryname";
        ddlcountry.DataValueField = "id";
        ddlcountry.DataBind();
    }

    protected void fillstate()
    {
        strsql = "select * from tblstate where countryid=" + ddlcountry.SelectedValue;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "strstate";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
    }

    private void fillcity()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblcity where countryid=" + ddlcountry.SelectedValue + " and stateid=" + ddlstate.SelectedValue;
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgcountry.DataSource = ds;
            dgcountry.DataBind();
        }
        allclear();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }

    protected void allclear()
    {
        txtcity.Text = "";
        txtstdcode.Text = "";
        btnsave.Text = "Save";
    }

    protected void dgcountry_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            strsql = "delete tblcity where id=" + e.Item.Cells[0].Text;
            cmd = new SqlCommand(strsql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            fillcity();
        }
        catch { }
    }

    protected void dgcountry_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtcity.Text = e.Item.Cells[1].Text;
        txtstdcode.Text = e.Item.Cells[2].Text;
        btnsave.Text = "Update";
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            int isdcode = int.Parse(txtstdcode.Text);
            try
            {
                if (btnsave.Text == "Save")
                    strsql = "Select * from tblcity where countryid=" + ddlcountry.SelectedValue + " and stateid=" + ddlstate.SelectedValue + " and city='" + txtcity.Text + "'";
                else
                    strsql = "Select * from tblcity where countryid=" + ddlcountry.SelectedValue + " and  stateid=" + ddlstate.SelectedValue + " and city='" + txtcity.Text + "' and id <>" + Session["ID"].ToString();
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msgbox.alert("City Already Exists for This Country & State!");
                }
                else
                {
                    SqlCommand command;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                    conn.Open();
                    command = new SqlCommand("spcity", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (btnsave.Text == "Save")
                    {
                        command.Parameters.Add("@ID", "0");
                    }
                    else
                    {
                        command.Parameters.Add("@ID", Session["ID"].ToString());
                    }
                    command.Parameters.Add("@countryid", ddlcountry.SelectedValue);
                    command.Parameters.Add("@stateid", ddlstate.SelectedValue);
                    command.Parameters.Add("@city", txtcity.Text.Trim());
                    command.Parameters.Add("@intcode", txtstdcode.Text.Trim());
                    command.ExecuteNonQuery();
                    conn.Close();
                    fillcity();
                }
            }
            catch (Exception ex)
            {
                msgbox.alert(ex.Message);
            }
        }
        catch
        {
            msgbox.alert("Invalid STD Code!");
        }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillstate();
            fillcity();
        }
        catch { }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillcity();
        }
        catch { }

    }
}
