using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Fee_Feemode : System.Web.UI.Page
{
    DataSet ds;
    Csfeemenagement Csfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtfeemode.Focus();
            fillgrid();
        }
    }
    private void fillgrid()
    {
        ds = new DataSet();
        ds = Csfee.fncGet_All_Feemode_Grd();
        dgfee.DataSource = ds;
        dgfee.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand command;
            SqlParameter outpuparam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("SPfeemode", conn);
            command.CommandType = CommandType.StoredProcedure;
            outpuparam = command.Parameters.Add("@rc", SqlDbType.Int);
            outpuparam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save")
                command.Parameters.AddWithValue("@intID", "0");
            else
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string sql = "select strfeemode from tblfeemode where intid != " + int.Parse(lbleditid.Text.Trim()) + " and strfeemode='" + txtfeemode.Text + "'";
                sql += " and intschool=" + Session["SchoolID"];
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                    command.Parameters.AddWithValue("@intID", int.Parse(lbleditid.Text.Trim()));
                lbleditid.Text = string.Empty;
            }
            command.Parameters.AddWithValue("@strfeemode", txtfeemode.Text.Trim());
            command.Parameters.AddWithValue("@intschool", Session["SchoolID"]);
            command.ExecuteNonQuery();
            if ((int)command.Parameters["@rc"].Value == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The entered feemode already exist!');", true);
            conn.Close();
            fillgrid();
            Clear();
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The entered feemode already exist!');", true);
            Clear();
        }
    }
    protected void dgfee_EditCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.Cells[1].Text != "Application fees" && e.Item.Cells[1].Text != "Registration fees")
        {
            lbleditid.Text = string.Empty;
            lbleditid.Text = e.Item.Cells[0].Text;
            txtfeemode.Text = e.Item.Cells[1].Text;
            btnSave.Text = "Update";
            txtfeemode.Focus();
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to delete or edit Admission fee and Registration fee!');", true);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnimage = sender as ImageButton;
        TableCell cell = btnimage.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        ds = new DataSet();
        ds = Csfee.fncGet_Delete_Feemode_Grd(Int32.Parse(item.Cells[0].Text), item.Cells[1].Text);
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ds.Tables[0].Rows[0]["STATUS"].ToString() + "');", true);
        fillgrid();
        dgfee.Focus();
    }
    protected void Clear()
    {
        txtfeemode.Text = string.Empty;
        lbleditid.Text=string.Empty;
        btnSave.Text = "Save";
        fillgrid();
        txtfeemode.Focus();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
