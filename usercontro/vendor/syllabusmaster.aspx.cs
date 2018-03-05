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

public partial class vendor_syllabusmaster : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            fillboard();
            fillclasstype();
        }
    }
    private void fillboard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblboard";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlboard.DataSource = ds;
        ddlboard.DataTextField = "boardname";
        ddlboard.DataValueField = "ID";
        ddlboard.DataBind();
    }
    private void fillclasstype()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblclasstype";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strclasstype";
        ddlclass.DataValueField = "strclasstype";
        ddlclass.DataBind();
        ListItem Li;
        for (int i = 1; i <= 12; i++)
        {
            Li = new ListItem("Form" + " " + i.ToString(), "Form" + " " + i.ToString());
            ddlstandard.Items.Add(Li);
        }
    }
    protected void fillgrid()
    {
        strsql = "select a.*,b.boardname from tblsyllabus a,tblboard b where a.intboard=b.ID";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgsyllabus.DataSource = ds;
        dgsyllabus.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlParameter OutPutParam;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        command = new SqlCommand("spsyllabus", conn);
        command.CommandType = CommandType.StoredProcedure;
        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intID", "0");
        }
        else
        {
            command.Parameters.Add("@intID", Session["ID"].ToString());
        }
        command.Parameters.Add("@intboard", ddlboard.SelectedValue);
        command.Parameters.Add("@strclasstype", ddlclass.SelectedValue);
        command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
        command.Parameters.Add("@strtextbookname", txttextbookname.Text);
        command.Parameters.Add("@intnoofunits", txtunits.Text);
        command.Parameters.Add("@strauthor", txtauthor.Text);
        command.ExecuteNonQuery();
        if ((int)(command.Parameters["@rc"].Value) == 0)
        {
            msgbox.alert("Already Exists!");
        }
        conn.Close();
        clear();
        fillgrid();
    }
    protected void clear()
    {
        txttextbookname.Text = "";
        txtunits.Text = "";
        txtauthor.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void dgsyllabus_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        strsql = "delete tblsyllabus where intid=" + e.Item.Cells[0].Text;
        cmd = new SqlCommand(strsql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
    protected void dgsyllabus_EditCommand(object source, DataGridCommandEventArgs e)
    {
        strsql = "select a.*,b.boardname from tblsyllabus a,tblboard b where a.intboard=b.ID";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        Session["ID"] = e.Item.Cells[0].Text;
        ddlboard.SelectedItem.Text =ds.Tables[0].Rows[0]["boardname"].ToString();
        ddlstandard.SelectedValue = e.Item.Cells[2].Text;
        txttextbookname.Text = e.Item.Cells[3].Text;
        txtunits.Text = e.Item.Cells[4].Text;
        txtauthor.Text = e.Item.Cells[5].Text;
        btnSave.Text = "Update";
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
    }
    private void fillstandard()
    {
        try
        {
            ddlstandard.Items.Clear();
            ListItem Li;            
            if (ddlclass.SelectedValue == "Form")
            {
                for (int i = 1; i <= 12; i++)
                {
                    Li = new ListItem(ddlclass.SelectedValue + " " + i.ToString(), ddlclass.SelectedValue + " " + i.ToString());
                    ddlstandard.Items.Add(Li);
                }
            }
            if (ddlclass.SelectedValue == "Grade")
            {
                for (int i = 1; i <= 12; i++)
                {
                    string std;
                    if (i == 1)
                        std = "1st " + ddlclass.SelectedValue;
                    else if (i == 2)
                        std = "2nd " + ddlclass.SelectedValue;
                    else if (i == 3)
                        std = "3rd " + ddlclass.SelectedValue;
                    else
                        std = i.ToString() + "th " + ddlclass.SelectedValue;

                    Li = new ListItem(std, std);
                    ddlstandard.Items.Add(Li);
                }
            }

            if (ddlclass.SelectedValue == "Standard")
            {
                string[] std = new string[12] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };

                for (int i = 0; i < 12; i++)
                {
                    Li = new ListItem(ddlclass.SelectedValue + " " + std[i], ddlclass.SelectedValue + " " + std[i]);
                    ddlstandard.Items.Add(Li);
                }
            }
        }

        catch { }
    }
    
}
