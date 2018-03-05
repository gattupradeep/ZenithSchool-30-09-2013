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

public partial class vendor_building : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    private void fillgrid()
    {       
            DataAccess da = new DataAccess();
            string sql = "select * from tblbuilding where intschool=" + Session["SchoolID"].ToString();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgbuilding.DataSource = ds.Tables[0];
            dgbuilding.DataBind();      
    }
    private void Clear()
    {
        txtbuildid.Text = "";
        txtbuildname.Text = "";
        txtnooffloor.Text = "";
        btnSave.Text = "Save";     
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spbuilding", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;

        string sql;
        if (btnSave.Text == "Save")
            sql = "select * from tblbuilding where  strbuildname = '" + txtbuildname.Text + "' and intschool=" + Session["SchoolID"].ToString();
        else
            sql = "select * from tblbuilding where  strbuildname = '" + txtbuildname.Text + "' and intid <> " + Session["intID"].ToString() + " and intschool=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            msgbox.alert(" Building Name already exists");
        }
        else
        {
            try
            {
                int norooms = int.Parse(txtnooffloor.Text);
                if (btnSave.Text == "Save")
                {
                    RegCommand.Parameters.Add("@intID", "0");
                }
                else
                {
                    RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
                }
                RegCommand.Parameters.Add("@strbuildid", txtbuildid.Text);
                RegCommand.Parameters.Add("@strbuildname", txtbuildname.Text);
                RegCommand.Parameters.Add("@intnooffloors", txtnooffloor.Text);
                RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                RegCommand.ExecuteNonQuery();
                Conn.Close();
                Clear();
                fillgrid();
            }
            catch 
            {
                msgbox.alert("Invalid No. of Floors!");
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    //protected void dgbuilding_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string sql = "delete tblbuilding where intid=" + e.Item.Cells[0].Text;
    //    cmd = new SqlCommand(sql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    fillgrid();
    //}

    protected void dgbuilding_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtbuildid.Text = e.Item.Cells[1].Text;
        txtbuildname.Text = e.Item.Cells[2].Text;
        txtnooffloor.Text = e.Item.Cells[3].Text;
        btnSave.Text = "Update";       
        fillgrid();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string sql = "delete tblbuilding where intid=" + item.Cells[0].Text;
        cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
}
