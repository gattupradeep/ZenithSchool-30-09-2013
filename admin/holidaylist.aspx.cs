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
            //fillcalender();
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
           j++;
        }

        ddlyear.Items.Insert(0, "Select");
    }
    private void fillcalender()
    {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select id,convert(varchar(10),dtdate,111) as dtdate,strdescription,intpay from tblacademiccalender  where intschool=" + Session["SchoolID"].ToString() + " and year(dtdate)='" + ddlyear.SelectedValue + "' order by dtdate";
            ds = da.ExceuteSql(sql);
            dgcalender.DataSource = ds;
            dgcalender.DataBind();
            Clear();
    }
    private void Clear()
    {
        txtdate.Text = "";
        txtdescription.Text = "";
        chkpay.Checked = false;
        btnSave.Text = "Save";
    }
    protected void dgcalender_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtdate.Text = e.Item.Cells[1].Text;
        txtdescription.Text = e.Item.Cells[2].Text;
        if (e.Item.Cells[3].Text == "1")
            chkpay.Checked = true;
        else
            chkpay.Checked = false;
        btnSave.Text = "Update";
    }
    //protected void dgcalender_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete tblacademiccalender where id=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //        fillcalender();
    //    }
    //    catch { }
    //}
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtdate.Text == "")
        {
            msgbox.alert("Please enter the date before save/update");
        }
        if (txtdescription.Text == "")
        {
            msgbox.alert("Please enter the details before save/update");
        }
        if (txtdate.Text == "" && txtdescription.Text == "")
        {
            msgbox.alert("Please enter the Date and details before save/update");
        }
        if (txtdate.Text != "" && txtdescription.Text != "")
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
            RegCommand.Parameters.Add("@dtdate", txtdate.Text.Trim());
            RegCommand.Parameters.Add("@strdescription", txtdescription.Text.Trim());
            RegCommand.Parameters.Add("@intpay", chkpay.Checked);
            RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            RegCommand.ExecuteNonQuery();
            if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
            {
                msgbox.alert("Holiday Date already Exists!");
            }
            Conn.Close();
            string id = Convert.ToString(OutPutParam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblacademiccalender", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 223);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblacademiccalender", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 223);
            }
            fillcalender();
            Clear();
        }
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillcalender();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblacademiccalender where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblacademiccalender", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),223);

            da.ExceuteSqlQuery(sql);
            fillcalender();
        }
        catch { }
    }
}
