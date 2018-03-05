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

public partial class vendor_logintheme : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataSet ds;
    public string sql;
    public DataAccess da;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillgrid();
    }

    protected void fillgrid()
    {
        sql = "select *,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strbackground +'\"></td></tr></table>' as strback,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strnavigation +'\"></td></tr></table>' as strnav,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strfooter +'\"></td></tr></table>' as strfoot,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strimagestitle +'\"></td></tr></table>' as strtitle from tbltheme";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgdesig.DataSource = ds;
        dgdesig.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

        Conn.Open();
        RegCommand = new SqlCommand("sptheme", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intid", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intid", Session["ID"].ToString());
        }
        RegCommand.Parameters.Add("@strbackground", txtbackground.Text);
        RegCommand.Parameters.Add("@strnavigation", txtnavigation.Text);
        RegCommand.Parameters.Add("@strimagestitle", txttitle.Text);
        RegCommand.Parameters.Add("@strfooter", txtfooter.Text);
        RegCommand.ExecuteNonQuery();
        Conn.Close();
        fillgrid();
        clear();
    }

    protected void clear()
    {
        txtbackground.Text = "";
        txtnavigation.Text = "";
        txtfooter.Text = "";
        txttitle.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void dgdesig_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        sql = "delete tbltheme where intid=" + e.Item.Cells[0].Text;
        cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();

    }

    protected void dgdesig_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        txtbackground.Text = e.Item.Cells[1].Text;
        txtnavigation.Text = e.Item.Cells[2].Text;
        txtfooter.Text = e.Item.Cells[3].Text;
        txttitle.Text = e.Item.Cells[4].Text;
        btnSave.Text = "Update";
    }
}
