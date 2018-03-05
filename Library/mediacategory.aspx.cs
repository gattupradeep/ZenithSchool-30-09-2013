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

public partial class Library_mediacategory : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;   
    protected void Page_Load(object sender,EventArgs e)
    {
         if (!IsPostBack)
        {
            fillmediacatagory();
        }
    }
     private void fillmediacatagory()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblmediacategory where intschool="+Session["SchoolID"];
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgboard1.DataSource = ds;
        dgboard1.DataBind();
        allclear();
    }
    protected void dgboard1_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        txtmediacat.Text = e.Item.Cells[1].Text;
        btn1Save.Text = "Update";
    }

    //protected void dgboard1_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblmediacategory where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillmediacatagory();
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tblmediacategory where intschool="+Session["SchoolID"].ToString()+" and strmediacategory='"+txtmediacat.Text.Trim()+"'";
        DataSet ds = new DataSet();
        ds=da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Media Category Already Exists!')", true);
        }
        else
        {
            SqlParameter OutPutParam;
            conn.Open();
            cmd = new SqlCommand("spmediacategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OutPutParam = cmd.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btn1Save.Text == "Save")
            {
                cmd.Parameters.Add("@intid", "0");
            }
            else
            {
                cmd.Parameters.Add("@intid", Session["intid"].ToString());
            }
            cmd.Parameters.Add("@strmediacategory", txtmediacat.Text.Trim());
            cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            cmd.ExecuteNonQuery();
            if ((int)(cmd.Parameters["@rc"].Value) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Media Category Already Exist')", true);
                //MsgBox1.alert("Media Category Already Exists!");
            }
            conn.Close();
            fillmediacatagory();
            allclear();
        }
    }

    protected void allclear()
    {
        txtmediacat.Text = "";
        btn1Save.Text = "Save";
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
        string sql = "delete tblmediacategory where intid=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillmediacatagory();
    }
}
     
    

