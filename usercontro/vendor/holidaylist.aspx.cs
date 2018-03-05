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

public partial class school_holidaylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillyear();
            Clear();
            fillcalender();
        }
    }

    private void fillyear()
    {
        int i;
        int j = 0;
        for (i = 2011; i <= DateTime.Today.Year + 10; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear.Items.Insert(j, li);
            ddlyear0.Items.Insert(j, li);
            j++;
        }
    }
    
    private void fillcalender()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select * from tblacademiccalender order by dtdate";
            ds = da.ExceuteSql(sql);
            dgcalender.DataSource = ds;
            dgcalender.DataBind();

            Clear();
        }
        catch { }
    }

    private void Clear()
    {
        ddlyear.SelectedValue = DateTime.Today.Year.ToString();
        ddlyear0.SelectedValue = DateTime.Today.Year.ToString();
        ddlday.SelectedValue = DateTime.Today.Day.ToString();
        ddlmonth.SelectedValue = DateTime.Today.Month.ToString();
        txtdescription.Text = "";
        chkpay.Checked = false;
        btnSave.Text = "Save";
    }

    protected void dgcalender_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        ddlday.SelectedValue = DateTime.Parse(e.Item.Cells[1].Text).Day.ToString();
        ddlmonth.SelectedValue = DateTime.Parse(e.Item.Cells[1].Text).Month.ToString();
        ddlyear.SelectedValue = DateTime.Parse(e.Item.Cells[1].Text).Year.ToString();
        txtdescription.Text = e.Item.Cells[2].Text;
        if (e.Item.Cells[3].Text == "1")
            chkpay.Checked = true;
        else
            chkpay.Checked = false;
        btnSave.Text = "Update";
    }
    protected void dgcalender_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "delete tblacademiccalender where id=" + e.Item.Cells[0].Text;
            da.ExceuteSqlQuery(sql);
            fillcalender();
        }
        catch { }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("AcademicCalender_I", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@ID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@ID", Session["ID"].ToString());
        }
        RegCommand.Parameters.Add("@dtdate", ddlmonth.SelectedValue + "/ " + ddlday.SelectedValue + " / " + ddlyear.SelectedValue);
        RegCommand.Parameters.Add("@strdescription", txtdescription.Text.Trim());
        RegCommand.Parameters.Add("@intpay", chkpay.Checked);
        RegCommand.Parameters.Add("@intschool", "1");
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Holiday Date already Exists!");
        }
        Conn.Close();
        fillcalender();
        Clear();
    }
}
