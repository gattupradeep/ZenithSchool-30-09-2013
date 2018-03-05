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

public partial class vendor_languages : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillgrid();
    }
    protected void fillgrid()
    {
        strsql = "select * from tbllanguages order by strlanguagename";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dglanguage.DataSource = ds.Tables[0];
        dglanguage.DataBind();
        clear();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand command;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("splanguages", conn);
            command.CommandType = CommandType.StoredProcedure;
            if (btnSave.Text == "Save")
            {
                command.Parameters.Add("@intID", "0");
            }
            else
            {
                command.Parameters.Add("@intID", Session["ID"].ToString());
            }
            command.Parameters.Add("@strlanguagename", txtlanguage.Text);
            command.ExecuteNonQuery();
            conn.Close();
            fillgrid();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already Exists!')", true);
        }

    }

    protected void clear()
    {
        txtlanguage.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void dglanguage_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        strsql = "delete tbllanguages where intid=" + e.Item.Cells[0].Text;
        cmd = new SqlCommand(strsql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }

    protected void dglanguage_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtlanguage.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
