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

public partial class communication_smstemplates : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillsmscategory();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlParameter OutPutParam;
        conn.Open();
        command = new SqlCommand("spsmstemplate", conn);
        command.CommandType = CommandType.StoredProcedure;
        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnsave.Text == "Save")
        {
            command.Parameters.Add("@intid", "0");
        }
        else
        {
            command.Parameters.Add("@intid", Session["templateeditid"].ToString());
        }
        command.Parameters.Add("@intcategoryid", ddlsmscategory.SelectedValue);
        command.Parameters.Add("@strtemplatename", txttemplatename.Text);
        command.Parameters.Add("@strmessage", txtmessage.Text);
        if (ddlpatron.SelectedIndex > 0)
        {
            command.Parameters.Add("@strpatrontype", ddlpatron.SelectedValue);
        }
        else
        {
            command.Parameters.Add("@strpatrontype", "");
        }
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.ExecuteNonQuery();
        conn.Close();
        allclear();
        fillgrid();
    }

    protected void dgtemplate_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["templateeditid"] = e.Item.Cells[0].Text;
        DataAccess daedit = new DataAccess();
        DataSet dsedit = new DataSet();
        strsql = "select * from tblsmstemplate where intid ="+e.Item.Cells[0].Text;
        dsedit = daedit.ExceuteSql(strsql);
        if (dsedit.Tables[0].Rows.Count > 0)
        {
            if (ddlsmscategory.SelectedItem.Text == "Leave Management" || ddlsmscategory.SelectedItem.Text == "General" || ddlsmscategory.SelectedItem.Text == "Transport" || ddlsmscategory.SelectedItem.Text == "Events" || ddlsmscategory.SelectedItem.Text == "Transfer Certificate" || ddlsmscategory.SelectedItem.Text == "Food Menu" || ddlsmscategory.SelectedItem.Text == "Birthday" || ddlsmscategory.SelectedItem.Text == "Festival" || ddlsmscategory.SelectedItem.Text == "Notice Board")
            {
                ddlpatron.SelectedValue = dsedit.Tables[0].Rows[0]["strpatrontype"].ToString();
            }
            txttemplatename.Text = dsedit.Tables[0].Rows[0]["strtemplatename"].ToString();
            txtmessage.Text = dsedit.Tables[0].Rows[0]["strmessage"].ToString();
            btnsave.Text = "Update";
        }
    }
    protected void dgtemplate_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess dadelete = new DataAccess();
        DataSet dsdelete = new DataSet();
        strsql = "delete from tblsmstemplate where intid =" + e.Item.Cells[0].Text;
       // Functions.UserLogs(Session["UserID"].ToString(), "tblsmstemplate", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());
        dsdelete = dadelete.ExceuteSql(strsql);
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }

    protected void allclear()
    {
        txtmessage.Text = "";
        txttemplatename.Text = "";
        ddlpatron.SelectedIndex = 0;
        btnsave.Text = "Save";
    }
    protected void fillsmscategory()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select * from tblsmscategory";
        ds = da.ExceuteSql(strsql);
        ddlsmscategory.DataTextField = "strcategory";
        ddlsmscategory.DataValueField = "intid";
        ddlsmscategory.DataSource = ds;
        ddlsmscategory.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlsmscategory.Items.Insert(0, li);
    }
    protected void fillpatrontype()
    {
        ddlpatron.Items.Clear();
        da = new DataAccess();
        ds = new DataSet();
        string sql = "select strpatrontype from tblsmskeyword where intsmscategoryid = " + ddlsmscategory.SelectedValue + " group by strpatrontype";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlpatron.DataTextField = "strpatrontype";
            ddlpatron.DataValueField = "strpatrontype";
            ddlpatron.DataSource = ds;
            ddlpatron.DataBind();
        }
        ddlpatron.Items.Insert(0, "-Select-");
        if (ddlsmscategory.SelectedItem.Text == "General" || ddlsmscategory.SelectedItem.Text == "Events" || ddlsmscategory.SelectedItem.Text == "Birthday" || ddlsmscategory.SelectedItem.Text == "Festival" || ddlsmscategory.SelectedItem.Text == "Notice Board")
        {
            ddlpatron.Items.Insert(1, "All");
        }
        ddlpatron.SelectedIndex = 0;
    }
    protected void fillgrid()
    {
        dgtemplate.Visible = true;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select * from tblsmstemplate where intcategoryid=" + ddlsmscategory.SelectedValue +" and intschool="+Session["SchoolID"];
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgtemplate.DataSource = ds;
            dgtemplate.DataBind();
        }
        else
        {
            dgtemplate.Visible = false;
            msgbox.alert("There is no data to display");
        }
    }
    protected void ddlsmscategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsmscategory.SelectedIndex > 0)
        {
            txttemplatename.Text = "";
            txtmessage.Text = "";
            trpatrontype.Visible = false;
            trkeywords.Visible = true;
            ddlpatron.SelectedIndex = 0;
            DataAccess da1 = new DataAccess();
            DataSet ds1 = new DataSet();
            strsql = "select * from tblsmskeyword where intsmscategoryid = "+ddlsmscategory.SelectedValue+" ";
            ds1 = da1.ExceuteSql(strsql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblkeywords.Text = "";
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    lblkeywords.Text += ds1.Tables[0].Rows[i]["strdescription"].ToString() + " : <font class='sms_keywords'>" + ds1.Tables[0].Rows[i]["strkeyword"].ToString() + "</font>, ";
                }
            }
            else
            {
                trkeywords.Visible = false;
            }
            if (ddlsmscategory.SelectedItem.Text == "Leave Management" || ddlsmscategory.SelectedItem.Text == "General" || ddlsmscategory.SelectedItem.Text == "Transport" || ddlsmscategory.SelectedItem.Text == "Events" || ddlsmscategory.SelectedItem.Text == "Transfer Certificate" || ddlsmscategory.SelectedItem.Text == "Food Menu" || ddlsmscategory.SelectedItem.Text=="Birthday" || ddlsmscategory.SelectedItem.Text=="Festival" || ddlsmscategory.SelectedItem.Text=="Notice Board")
            {
                fillpatrontype();
                trkeywords.Visible = false;
                trpatrontype.Visible = true;
            }
            if (ddlsmscategory.SelectedItem.Text == "Leave Management")
            {
                lblpatrontype.Text = "Leave Type";
            }
            if (ddlsmscategory.SelectedItem.Text == "Transfer Certificate")
            {
                lblpatrontype.Text = "TC Status";
            }
            if (ddlsmscategory.SelectedItem.Text == "Food Menu")
            {
                lblpatrontype.Text = "Menu Type";
            }
            else
            {
                lblpatrontype.Text = "Patron Type";
            }
            fillgrid();
        }
        else
        {
            trkeywords.Visible = false;
            trpatrontype.Visible = false;
        }
    }
    protected void ddlpatron_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccess da1 = new DataAccess();
        DataSet ds1 = new DataSet();
        strsql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid=" + ddlsmscategory.SelectedValue + " ";
        if (ddlsmscategory.SelectedItem.Text == "Leave Management" || ddlsmscategory.SelectedItem.Text == "General" || ddlsmscategory.SelectedItem.Text == "Transport" || ddlsmscategory.SelectedItem.Text == "Events" || ddlsmscategory.SelectedItem.Text == "Transfer Certificate" || ddlsmscategory.SelectedItem.Text == "Food Menu" || ddlsmscategory.SelectedItem.Text == "Birthday" || ddlsmscategory.SelectedItem.Text == "Festival" || ddlsmscategory.SelectedItem.Text=="Notice Board")
        {
            trkeywords.Visible = false;
            trpatrontype.Visible = true;
            if (ddlpatron.SelectedIndex > 0)
            {
                trkeywords.Visible = true;
                strsql += " and strpatrontype='"+ddlpatron.SelectedValue+"'";
            }
            if (ddlpatron.SelectedValue=="All")
            {
                trkeywords.Visible = true;
                strsql = "";
                strsql = "select strdescription,strkeyword from tblsmskeyword where intsmscategoryid=" + ddlsmscategory.SelectedValue + " group by strdescription,strkeyword HAVING(COUNT(strkeyword) > 1)";
            }
        }
        ds1 = da1.ExceuteSql(strsql);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblkeywords.Text = "";
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                lblkeywords.Text += ds1.Tables[0].Rows[i]["strdescription"].ToString() + " : <font class='sms_keywords'>" + ds1.Tables[0].Rows[i]["strkeyword"].ToString() + "</font>, ";
            }
        }
        else
        {
            trkeywords.Visible = false;
        }

    }
}
