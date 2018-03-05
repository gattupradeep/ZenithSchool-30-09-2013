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

public partial class communication_smskeyword : System.Web.UI.Page
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
        string typename = "";
        da = new DataAccess();
        ds = new DataSet();
        if (ddlpatron.SelectedIndex > 0)
        {
            typename = ddlpatron.SelectedValue;
        }
        if (ddlleavestatus.SelectedIndex > 0)
        {
            typename = ddlleavestatus.SelectedValue;
        }
        if (ddlmenutype.SelectedIndex > 0)
        {
            typename = ddlmenutype.SelectedValue;
        }
        if (ddltcstatus.SelectedIndex > 0)
        {
            typename = ddltcstatus.SelectedValue;
        }
        strsql = "insert into tblsmskeyword values('" + ddlsmscategory.SelectedValue + "','" + typename + "','" + txtkeyworddesc.Text + "','" + txtkeyword.Text + "','" + txtcolumnname.Text + "','"+txttablename.Text+"')";
        ds = da.ExceuteSql(strsql);
        txtkeyworddesc.Text = "";
        txtkeyword.Text = "";
        fillgrid();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        allclear();
    }
    protected void allclear()
    {
        ddlsmscategory.SelectedIndex = 0;
        txtcolumnname.Text = "";
        txtkeyword.Text = "";
        txtkeyworddesc.Text = "";
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
    protected void ddlsmscategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlpatron.SelectedIndex = 0;
        trpatrontype.Visible = false;
        ddlleavestatus.SelectedIndex = 0;
        trleavestatus.Visible = false;
        ddlmenutype.SelectedIndex = 0;
        trfoodmenutype.Visible = false;
        ddltcstatus.SelectedIndex = 0;
        trtcstatus.Visible = false;
        txtkeyworddesc.Text = "";
        txtkeyword.Text = "";
        if (ddlsmscategory.SelectedItem.Text == "General" || ddlsmscategory.SelectedItem.Text == "Transport" || ddlsmscategory.SelectedItem.Text == "Events" || ddlsmscategory.SelectedItem.Text=="Festival" ||ddlsmscategory.SelectedItem.Text=="Birthday")
        {
            trpatrontype.Visible = true;
        }
        if (ddlsmscategory.SelectedItem.Text == "Leave Management")
        {
            trleavestatus.Visible = true;
        }
        if (ddlsmscategory.SelectedItem.Text == "Food Menu")
        {
            trfoodmenutype.Visible = true;
        }
        if (ddlsmscategory.SelectedItem.Text == "Transfer Certificate")
        {
            trtcstatus.Visible = true;
        }
        if (ddlsmscategory.SelectedItem.Text == "Notice Board")
        {
            trpatrontype.Visible = true;
        }
        if (ddlsmscategory.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        DataAccess dgda = new DataAccess();
        DataSet dgds = new DataSet();
        strsql = "select a.*,b.strcategory as categoryname from tblsmskeyword a,tblsmscategory b where a.intsmscategoryid='"+ddlsmscategory.SelectedValue+"' and a.intsmscategoryid=b.intid";
        if (ddlpatron.SelectedIndex > 0)
        {
            strsql += " and a.strpatrontype='" + ddlpatron.SelectedValue + "'";
        }
        if (ddlleavestatus.SelectedIndex > 0)
        {
            strsql += " and a.strpatrontype='" + ddlleavestatus.SelectedValue + "'";
        }
        if (ddlmenutype.SelectedIndex > 0)
        {
            strsql += " and a.strpatrontype='" + ddlmenutype.SelectedValue + "'";
        }
        if (ddltcstatus.SelectedIndex > 0)
        {
            strsql += " and a.strpatrontype='" + ddltcstatus.SelectedValue + "'";
        }
        dgds = dgda.ExceuteSql(strsql);
        dgsmskeywords.DataSource = dgds;
        dgsmskeywords.DataBind();
    }
    protected void ddlpatron_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatron.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void ddlleavestatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlleavestatus.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
    protected void ddlmenutype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmenutype.SelectedIndex > 0)
        {
            fillgrid();
        }
    }
}
