using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_mangedb : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public String str;
    public SqlDataAdapter da;
    public DataSet ds;
    public SqlDataReader dtr;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtfinalquery.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if ((txtfinalquery.Text.IndexOf("select") > -1 && txtfinalquery.Text.IndexOf("alter") < 0) || txtfinalquery.Text.IndexOf("sp_helptext") > -1)
        {
            try
            {
                str = txtfinalquery.Text;
                da = new SqlDataAdapter(str, conn);
                ds = new DataSet();
                da.Fill(ds);
                dgbranchmaster.DataSource = ds;
                dgbranchmaster.DataBind();
            }
            catch
            {
                MsgBox1.alert("Incorrect Query");
            }
        }
        else
        //else if(txtfinalquery.Text.IndexOf("update") > -1 || txtfinalquery.Text.IndexOf("delete") > -1)
        {
            try
            {
                conn.Open();
                str = txtfinalquery.Text;
                cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MsgBox1.alert("Incorrect Query");
            }
        }
    }
}
