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

public partial class admin_notice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillnotice();
            Clear();
        }
    }
    private void fillnotice()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblnoticeboard where intschool=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlnotice.DataSource = ds;
        ddlnotice.DataTextField = "strnoticename";
        ddlnotice.DataValueField = "intID";
        ddlnotice.DataBind();
        ddlnotice.Items.Insert(0, "Select");
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.intid,a.strdescription,convert(varchar(10),a.dtdate,103) as dtdate,a.intnotice,b.strnoticename,b.intid from tbldailynotice a,tblnoticeboard b where a.intnotice=b.intid and a.intnotice=" + ddlnotice.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " order by dtdate desc";
        ds = da.ExceuteSql(sql);
        dgnotice.DataSource = ds;
        dgnotice.DataBind();
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
            Functions.UserLogs(Session["UserID"].ToString(), "tbldailynotice", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 256);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbldailynotice", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 256);
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
        ddlnotice.SelectedIndex = 0;
        txtdate.Text = "";
        txtdes.Text = "";
        btnSave.Text = "Save";
    }


    protected void ddlnotice_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
