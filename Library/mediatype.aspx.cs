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

public partial class Library_mediatype : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillmediatypes();
        }
    }

    private void fillmediatypes()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblmediatype where intschool="+Session["SchoolID"];
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgboard.DataSource = ds;
        dgboard.DataBind();
        allclear();
    }

    protected void dgboard_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtmediatype.Text = e.Item.Cells[1].Text;
        btnSave.Text = "Update";
    }

    //protected void dgboard_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblmediatype where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillmediatypes();
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
            SqlParameter OutPutParam;
            conn.Open();
            cmd = new SqlCommand("spmediatype", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OutPutParam = cmd.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save")
            {
                cmd.Parameters.Add("@intid", "0");
            }
            else
            {
                cmd.Parameters.Add("@intid", Session["intid"].ToString());
            }
                cmd.Parameters.Add("@strmediatype",txtmediatype.Text.Trim());
                cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                cmd.ExecuteNonQuery();
                if ((int)(cmd.Parameters["@rc"].Value) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Media Type Already Exists!')", true);
                }
                conn.Close();
                fillmediatypes();
                allclear();
   }
 

    protected void allclear()
    {
        txtmediatype.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblmediatype where intid=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillmediatypes();
    }
}