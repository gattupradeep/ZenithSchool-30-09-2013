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

public partial class vendor_state : System.Web.UI.Page
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

    private void fillstate()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblstate where countryid=" + ddlcountry.SelectedValue;
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
        txtstate.Text = "";
        btnsave.Text = "Save";
    }

    protected void dgcountry_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            strsql = "delete tblstate where id=" + e.Item.Cells[0].Text;
            cmd = new SqlCommand(strsql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            fillstate();
        }
        catch { }
    }

    protected void dgcountry_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtstate.Text = e.Item.Cells[1].Text;
        btnsave.Text = "Update";
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnsave.Text == "Save")
                strsql = "Select * from tblstate where countryid=" + ddlcountry.SelectedValue + " and strstate='" + txtstate.Text + "'";
            else
                strsql = "Select * from tblstate where countryid=" + ddlcountry.SelectedValue + " and strstate='" + txtstate.Text + "' and id <>" + Session["ID"].ToString();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                msgbox.alert("State Already Exists for This Country!");
            }
            else
            {
                SqlCommand command;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("spcountry", conn);
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
                command.Parameters.Add("@strstate", txtstate.Text.Trim());
                command.ExecuteNonQuery();
                conn.Close();
                fillstate();
            }
        }
        catch (Exception ex)
        {
            msgbox.alert(ex.Message);
        }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillstate();
        }
        catch { }
    }
}
