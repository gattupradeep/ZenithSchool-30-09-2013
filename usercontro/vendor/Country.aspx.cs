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

public partial class Country : System.Web.UI.Page
{
    public SqlCommand cmd;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcountry();
        }
    }   
    private void fillcountry()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblcountry";
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
        txtcountryname.Text = "";
        txtcurrencycode.Text = "";
        txtfloortype.Text = "";
        txtisdcode.Text = "";
        btnsave.Text = "Save";
    }

    protected void dgcountry_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            strsql = "delete tblcountry where id=" + e.Item.Cells[0].Text;
            cmd = new SqlCommand(strsql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            fillcountry();
        }
        catch { }
    }

    protected void dgcountry_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtcountryname.Text = e.Item.Cells[1].Text;
        txtfloortype.Text = e.Item.Cells[2].Text;
        txtisdcode.Text = e.Item.Cells[3].Text;
        txtcurrencycode.Text = e.Item.Cells[4].Text;
        btnsave.Text = "Update";
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            int isdcode = int.Parse(txtisdcode.Text);
            try
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
                command.Parameters.Add("@countryname", txtcountryname.Text.Trim());
                command.Parameters.Add("@strfloortype", txtfloortype.Text.Trim());
                command.Parameters.Add("@intcode", txtisdcode.Text.Trim());
                command.Parameters.Add("@strcurrency", txtcurrencycode.Text.Trim());
                command.ExecuteNonQuery();
                conn.Close();
                fillcountry();
            }
            catch
            {
                msgbox.alert("Country Already Exists!");
            }
        }
        catch
        {
            msgbox.alert("Invalid ISD Code!");
        }
    }
}
