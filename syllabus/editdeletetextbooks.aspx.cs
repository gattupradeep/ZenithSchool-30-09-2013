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

public partial class syllabus_editdeletetextbooks : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            trsubject.Visible = false;
            ddlsubject.Items.Insert(0, "-Select-");
        }
    }

    private void fillstandard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strclass from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + " group by strclass";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strclass"].ToString(), ds.Tables[0].Rows[i - 1]["strclass"].ToString());

            ddlstandard.Items.Add(li);
        }
    }

    private void fillsubject()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strsubject from tblschooltextbook where strclass='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strsubject";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        ddlsubject.Items.Clear();
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strsubject"].ToString(), ds.Tables[0].Rows[i - 1]["strsubject"].ToString());

            ddlsubject.Items.Add(li);
        }
        if (ds.Tables[0].Rows.Count > 0)
            trsubject.Visible = true;
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        filltextbook();
    }

    protected void filltextbook()
    {
        tr2.Visible = false;

        strsql = "select intid,strtextbookname,strauthorname,intsame from tblschooltextbook where strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            datagrid.DataSource = ds;
            datagrid.DataBind();
            tr2.Visible = true;
        }
        else
        {
            tr2.Visible = false;
        }
    }

    protected void btnaddunit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        lblsame.Text = item.Cells[0].Text;
        ImageButton btnaddunit = (ImageButton)item.FindControl("btnaddunit");
        Label lbltextbookname = (Label)item.FindControl("lbltextbookname");
        TextBox txttextbookname = (TextBox)item.FindControl("txttextbookname");
        Label lblauthorname = (Label)item.FindControl("lblauthorname");
        TextBox txtauthorname = (TextBox)item.FindControl("txtauthorname");
        da = new DataAccess();
        if (btnaddunit.ImageUrl == "../media/images/edit.gif")
        {
            btnaddunit.ImageUrl = "../media/images/update.gif";
            txttextbookname.Visible = true;
            lbltextbookname.Visible = false;
            txtauthorname.Visible = true;
            lblauthorname.Visible = false;
        }
        else
        {
            strsql = "update tblschooltextbook set strtextbookname='" + txttextbookname.Text.Replace("'", "''") + "',strauthorname='" + txtauthorname.Text + "' where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbook", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),190);

            da.ExceuteSqlQuery(strsql);
            filltextbook();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully')", true);
        }
    }

    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        TextBox txtunitname = (TextBox)item.FindControl("txtunitname");
        ImageButton btnaddunit = (ImageButton)item.FindControl("btnaddunit");
        da = new DataAccess();
        strsql = "select * from tblschooltextbookunits where inttextbook=" + item.Cells[0].Text;
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Sorry Cannont Be Deleted! This Textbook Has Units')", true);
        }
        else
        {
            da = new DataAccess();
            strsql = "delete tblschooltextbook  where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbook", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),190);

            da.ExceuteSqlQuery(strsql);
            filltextbook();
        }
    }

    protected void btndone_Click(object sender, EventArgs e)
    {
        Response.Redirect("editdeletetextbooks.aspx");
    }
    protected void datagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            ((ImageButton)e.Item.Cells[1].FindControl("btndelete")).Attributes.Add("onclick", "return confirm('Do You Want To Delete Permanently?');");
        }
        catch { }
    }
}
