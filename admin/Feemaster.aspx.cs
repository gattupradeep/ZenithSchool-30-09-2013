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

public partial class school_Feemaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {            
            fillfeemode();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblfeemaster where strfeemode='"+ddlfeemode.SelectedValue+"' and intschool="+Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        dgfee.DataSource = ds;
        dgfee.DataBind();
      Clear();
    }
    protected void fillfeemode()
    {
        DataAccess da = new DataAccess();
        string sql = "select strfeemode from tblfeemode";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlfeemode.DataSource= ds;
        ddlfeemode.DataTextField = "strfeemode";
        ddlfeemode.DataValueField = "strfeemode";
        ddlfeemode.DataBind();
        ddlfeemode.Items.Insert(0, "Select");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtfee.Text == "")
        {
            msgbox.alert("Please enter feetype before save/update");
        }
        if (ddlfeemode.SelectedIndex == 0)
        {
            msgbox.alert("Please select feemode before save/update");
        }
        if (ddlfeemode.SelectedIndex > 0 && txtfee.Text != "")
        {
            SqlCommand command;
            SqlParameter OutPutParam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("SPfeemaster", conn);
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
            command.Parameters.Add("@strfeemode", ddlfeemode.SelectedValue);
            command.Parameters.Add("@strfeetype", txtfee.Text.Trim());
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.ExecuteNonQuery();
            if ((int)(command.Parameters["@rc"].Value) == 0)
            {
                msgbox.alert("Already exists data for selected feemode and feetype");
            }
            conn.Close();
            fillgrid();
            Clear();
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
   protected void Clear()
    {
        txtfee.Text = "";
        btnSave.Text = "Save";
    }
    protected void dgfee_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "delete tblfeemaster where intID=" + e.Item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblfeemaster", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),298);

            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch { }
    }
    protected void dgfee_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str="select * from tblfeemaster where intID=" + e.Item.Cells[0].Text;
        ds = da.ExceuteSql(str);
        ddlfeemode.SelectedValue = ds.Tables[0].Rows[0]["strfeemode"].ToString();
        txtfee.Text = ds.Tables[0].Rows[0]["strfeetype"].ToString();
        btnSave.Text = "Update";
    }
    protected void ddlfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
