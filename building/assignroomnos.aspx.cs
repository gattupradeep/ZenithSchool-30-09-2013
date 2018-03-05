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

public partial class building_assignroomnos : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillbuilding1();
        }
    }

    protected void fillbuilding1()
    {
        strsql = "select * from tblbuilding where intschool=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuilding.DataSource = ds;
        ddlbuilding.DataTextField = "strbuildname";
        ddlbuilding.DataValueField = "intid";
        ddlbuilding.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            fillfloors();
            fillbuilding();
        }
        else
            msgbox.alert("Please Add Buildings");
    }

    protected void fillfloors()
    {
        ddlfloor.Items.Clear();
        strsql = "select strfloortype from tblcountry where intcountryID = (select intcountryid from tbldetails where intschoolid=" + Session["SchoolID"].ToString() + ")";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        string strfloor = "Floor";
        if (ds.Tables[0].Rows.Count > 0)
            strfloor = ds.Tables[0].Rows[0]["strfloortype"].ToString();

        strsql = "select intnooffloors from tblbuilding where intid ="+ ddlbuilding.SelectedValue;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);

        int n = int.Parse(ds.Tables[0].Rows[0]["intnooffloors"].ToString());

        ListItem Li;
        Li = new ListItem("Ground Floor", "Ground Floor");
        ddlfloor.Items.Add(Li);
        for (int i = 1; i <= n; i++)
        {
            string std;
            if (i == 1)
                std = "1st " + strfloor;
            else if (i == 2)
                std = "2nd " + strfloor;
            else if (i == 3)
                std = "3rd " + strfloor;
            else
                std = i.ToString() + "th " + strfloor;

            Li = new ListItem(std, std);
            ddlfloor.Items.Add(Li);
        }
    }

    private void fillbuilding()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select a.*,b.strbuildname,b.intid from tblassignbuilding a, tblbuilding b where a.intbuilding=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        dgbuilding.DataSource = ds;
        dgbuilding.DataBind();
        Clear();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        conn.Open();
        command = new SqlCommand("spassignbuilding", conn);

        param = command.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;

        command.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intid", "0");
        }
        else
        {
            command.Parameters.Add("@intid", Session["ID"].ToString());
        }
        command.Parameters.Add("@intbuilding", ddlbuilding.SelectedValue);
        command.Parameters.Add("@strfloor", ddlfloor.SelectedValue);
        command.Parameters.Add("@intfroom", txtfroom.Text);
        command.Parameters.Add("@inttroom", txttroom.Text);
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.ExecuteNonQuery();

        if ((int)(command.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Same Floor is already Available!");
        }

        conn.Close();
        fillbuilding();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        ddlfloor.SelectedIndex = 0;
        txtfroom.Text = "0";
        txttroom.Text = "0";
        btnSave.Text = "Save";
    }

    protected void dgbuilding_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] =e.Item.Cells[0].Text;
        ddlbuilding.SelectedValue = e.Item.Cells[5].Text;
        ddlfloor.SelectedValue = e.Item.Cells[2].Text;
        txtfroom.Text = e.Item.Cells[3].Text;
        txttroom.Text = e.Item.Cells[4].Text;
        btnSave.Text = "Update";
    }

    //protected void dgbuilding_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblassignbuilding where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillbuilding();
    //}
    protected void ddlbuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillfloors();
        }
        catch { }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblassignbuilding where intid=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillbuilding();
    }
}
