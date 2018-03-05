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

public partial class noticeboard_noticetype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillnoticetype();
            trdate.Visible = false;
        }
    }
    protected void fillnoticetype()
    {
        clear();
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblnoticeboard where intschool=" + Session["SchoolID"].ToString();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgnoticetype.DataSource = ds.Tables[0];
            dgnoticetype.DataBind();
        }
        catch { }
    }

    protected void clear()
    {
        txtnoticename.Text = "";
        txtdate.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("SPnoticename", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intid"].ToString());
        }
        RegCommand.Parameters.Add("@strnoticename",txtnoticename.Text.Trim());
        RegCommand.Parameters.Add("@dtdate","");
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 254);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblnoticeboard", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 254);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully!')", true);
        }
        fillnoticetype();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
}

