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

public partial class admin_admissionexam_min_maxmarks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtdate.Text= DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            fillstandard();
            fillgrid();
        }
    }
    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select strstandard from tblschoolstandard where intschoolid="+Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.Items.Clear();
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
            {
                li = new ListItem("-Select-", i.ToString());
            }
            else
            {
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strstandard"].ToString(), ds.Tables[0].Rows[i - 1]["strstandard"].ToString());
            }
            ddlstandard.Items.Add(li);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spadmissionpassmarkassigned", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
        }
        RegCommand.Parameters.Add("@dtdate", txtdate.Text.Trim());
        RegCommand.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
        RegCommand.Parameters.Add("@intmarksrequired",txtmarksrequired.Text.Trim());
        RegCommand.Parameters.Add("@intpassmarks",txtpassmark.Text.Trim());
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbladmissionpassmarkassigned", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),0);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbladmissionpassmarkassigned", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),0);
        }
        fillgrid();
        clear();
    }
    protected void clear()
    {
        txtmarksrequired.Text = "";
        txtpassmark.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select intid,convert(varchar(10),dtdate,111) as dtdate,strstandard,intmarksrequired,intpassmarks from tbladmissionpassmarkassigned where intschool=" + Session["SchoolID"].ToString();
        ds=da.ExceuteSql(str);
        dgadmissionmarks.DataSource = ds;
        dgadmissionmarks.DataBind();
    }
    protected void dgadmissionmarks_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string str = "delete tbladmissionpassmarkassigned where intid=" + e.Item.Cells[0].Text;
       // Functions.UserLogs(Session["UserID"].ToString(), "tbladmissionpassmarkassigned", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

        da.ExceuteSqlQuery(str);
        fillgrid();
    }
    protected void dgadmissionmarks_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtdate.Text = e.Item.Cells[1].Text;
        ddlstandard.SelectedValue = e.Item.Cells[2].Text;
        txtmarksrequired.Text = e.Item.Cells[3].Text;
        txtpassmark.Text = e.Item.Cells[4].Text;
        btnSave.Text = "Update";
    }
}
