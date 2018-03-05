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

public partial class noticeboard_editremainder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intid,convert(varchar(10),dtdate,111) as dtdate,strremainder,strtitle from tblremainder where intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        dgremainder.DataSource = ds;
        dgremainder.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlParameter OutPutParam;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        command = new SqlCommand("Spremainder", conn);
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
        command.Parameters.Add("@dtdate", txtdate.Text.Trim());
        command.Parameters.Add("@strremainder", txtremainder.Text.Trim());
        command.Parameters.Add("@strtitle", txttitle.Text.Trim());
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.ExecuteNonQuery();
        conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblremainder", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 273);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblremainder", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 273);
        }
        fillgrid();
        Clear();
    }
    private void Clear()
    {
        txtdate.Text = "";
        txtremainder.Text = "";
        txttitle.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void dgremainder_editcommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtdate.Text = e.Item.Cells[1].Text;
        txtremainder.Text = e.Item.Cells[2].Text;
        txttitle.Text = e.Item.Cells[3].Text;
        btnSave.Text = "Update";
    }
    //protected void dgremainder_deletecommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblremainder where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblremainder where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblremainder", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),273);

        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}

