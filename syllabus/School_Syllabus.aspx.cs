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

public partial class admin_School_Syllabus : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlsubject.Items.Insert(0, "-Select-");
            trtextbook.Visible = false;
            tr2.Visible = false;
            trerror.Visible = false;
        }
    }

    private void fillstandard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strclass from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + " and intid in(select inttextbook from tblschooltextbookunits) group by strclass";
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
        string sql = "select strsubject from tblschooltextbook where strclass='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and intid in(select inttextbook from tblschooltextbookunits) group by strsubject";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ListItem li;
        li = new ListItem("-Select-", "0");
        ddlsubject.Items.Insert(0, li);
    }

    protected void Btnadd_Click(object sender, EventArgs e)
    {
        //if (Btnadd.Text == "update")
        //{
        //    updatedatagrid();
        //    clear();
        //}
        //else
        //{
        //    SqlCommand command;
        //    SqlParameter OutPutParam;
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        //    conn.Open();
        //    command = new SqlCommand("SPschoolsyllabus", conn);
        //    command.CommandType = CommandType.StoredProcedure;
        //    OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        //    OutPutParam.Direction = ParameterDirection.Output;            
        //    if (Btnadd.Text == "Add")
        //    {
        //        command.Parameters.Add("@intID", "0");
        //    }
        //    else if (Btnadd.Text == "Update")
        //    {
        //        command.Parameters.Add("@intID", Session["ID"].ToString());
        //    }
        //    command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
        //    command.Parameters.Add("@strsubject", ddlsubject.SelectedValue);
        //    command.Parameters.Add("@strtextbook", txttextbookname.Text.Trim());
        //    command.Parameters.Add("@intunits", ddlnumberofunits.SelectedValue);
        //    command.Parameters.Add("@strunitno", ddlunitno.SelectedValue);
        //    command.Parameters.Add("@strunitname", txtunitname.Text.Trim());
        //    command.Parameters.Add("@strlessonName", txtlessonName.Text.Trim());
        //    command.Parameters.Add("@strauthor", txtauthor.Text.Trim());
        //    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        //    command.ExecuteNonQuery();

        //    if ((command.Parameters["@rc"].Value).ToString() == "0")
        //    {
        //        msgbox.alert("Lesson Already assigned to this unit");
        //    }            
        //    conn.Close();
        //    txtlessonName.Text = "";
        //    fillgrid();
        //    Btnadd.Text = "Add";
        //    datagrid.Visible = false;
        //    dgsyllabus.Visible = true;
        //}
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        trtextbook.Visible = false;
        tr2.Visible = false;
        trerror.Visible = false;
        fillsubject();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblauthor.Text = "";
        trtextbook.Visible = false;
        tr2.Visible = false;
        trerror.Visible = false;
        filltextbook();
    }

    protected void filltextbook()
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and intid in(select inttextbook from tblschooltextbookunits)";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddltextbook.DataSource = ds;
            ddltextbook.DataTextField = "strtextbookname";
            ddltextbook.DataValueField = "intid";
            ddltextbook.DataBind();
            ListItem li = new ListItem("Select Textbook", "0");
            ddltextbook.Items.Insert(0, li);
            if (ds.Tables[0].Rows.Count > 0)
            {
                trtextbook.Visible = true;
            }
            else
            {
                lblerror.Text = "No Textbooks Found For This Subject";
                trerror.Visible = true;
            }
        }
    }

    protected void dgsub_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            Session["ID"] = e.Item.Cells[0].Text;
            DataGrid dg = (DataGrid)e.Item.FindControl("dgsub");
        }
        catch { }
    }

    protected void dgsub_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string strsql = "";
        strsql = "delete tblschoolsyllabus where intid='" + e.Item.Cells[0].Text + "' and strlessonName='" + e.Item.Cells[1].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 101);
    }

    protected void datagrid_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string strsql = "";
        DataAccess da = new DataAccess();
        strsql = "select intid from tblschoolsyllabus where strstandard='" + e.Item.Cells[0].Text + "' and strsubject='" + e.Item.Cells[1].Text + "' and strtextbook='" + e.Item.Cells[2].Text + "' and strauthor='" + e.Item.Cells[3].Text + "'and strunitno='" + e.Item.Cells[5].Text + "'and strunitname='" + e.Item.Cells[6].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

            }
        }
        strsql = "delete tblschoolsyllabus where strstandard='" + e.Item.Cells[0].Text + "' and strsubject='" + e.Item.Cells[1].Text + "' and strtextbook='" + e.Item.Cells[2].Text + "' and strauthor='" + e.Item.Cells[3].Text + "'and strunitno='" + e.Item.Cells[5].Text + "'and strunitname='" + e.Item.Cells[6].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
    }


    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr2.Visible = false;
        trerror.Visible = false;
        if (ddltextbook.SelectedIndex > 0)
        {
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select strauthorname,intsame from tblschooltextbook where intid=" + ddltextbook.SelectedValue;
            ds = da.ExceuteSql(strsql);
            lblauthor.Text = ds.Tables[0].Rows[0]["strauthorname"].ToString();
            lblsame.Text = ds.Tables[0].Rows[0]["intsame"].ToString();
            fillgrid();
        }
    }

    protected void datagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ImageButton btnaddunit = (ImageButton)e.Item.FindControl("btnaddunit");
            DropDownList ddlunitno = (DropDownList)e.Item.FindControl("ddlunitno");
            Label lblunitno = (Label)e.Item.FindControl("lblunitno");
            TextBox txtlessonname = (TextBox)e.Item.FindControl("txtlessonname");
            Label lbllessonname = (Label)e.Item.FindControl("lbllessonname");
            if (dr["intid"].ToString() == "0")
            {
                btnaddunit.ImageUrl = "../media/images/add.gif";
                lbllessonname.Visible = false;
                txtlessonname.Visible = true;
                ddlunitno.Visible = true;
                lblunitno.Visible = false;
            }
            else
            {
                ddlunitno.Visible = false;
                lblunitno.Visible = true;
                btnaddunit.Visible = false;
                lbllessonname.Visible = true;
                txtlessonname.Visible = false;
                if (dr["intedit"].ToString() == "0")
                {
                    ddlunitno.Visible = true;
                    ddlunitno.SelectedValue = lblunitno.Text;  
                    lblunitno.Visible = false;
                    txtlessonname.Visible = true;
                    lbllessonname.Visible = false;
                    btnaddunit.ImageUrl = "../media/images/update.gif";
                    btnaddunit.Visible = true;
                }
            }

            da = new DataAccess();
            ds = new DataSet();
            if(lblsame.Text=="0")
                strsql = "select strUnitno + ' - ' + strunitname as strunit, strunitno from tblschooltextbookunits where inttextbook in(select intid from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + ") and inttextbook=" + ddltextbook.SelectedValue;
            else
                strsql = "select strunitno as strunit,strunitno from tblschooltextbookunits where inttextbook in(select intid from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + ") and inttextbook=" + ddltextbook.SelectedValue;
            ds = da.ExceuteSql(strsql);
            ddlunitno.DataSource = ds;
            ddlunitno.DataTextField = "strunit";
            ddlunitno.DataValueField = "strunitno";
            ddlunitno.DataBind();
        }
        catch { }

    }
    protected void btnaddunit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        ImageButton btnaddunit = (ImageButton)item.FindControl("btnaddunit");
        DropDownList ddlunitno = (DropDownList)item.FindControl("ddlunitno");
        //Label lblunitno = (Label)item.FindControl("lblunitno");
        //TextBox txtunitname = (TextBox)item.FindControl("txtunitname");
        //Label lblunitname = (Label)item.FindControl("lblunitname");
        TextBox txtlessonname = (TextBox)item.FindControl("txtlessonname");
        //Label lbllessonname = (Label)item.FindControl("lbllessonname");
        if (btnaddunit.ImageUrl == "../media/images/add.gif")
        {
            da = new DataAccess();
            strsql = "select * from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and inttextbook=" + ddltextbook.SelectedValue + " and strunitno='" + ddlunitno.SelectedValue + "' and strlessonname='" + txtlessonname.Text + "' and intschool=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Sorry Lesson Name Cannont Be Duplicated')", true);
            }
            else
            {
                da = new DataAccess();
                strsql = "insert into tblschoolsyllabus (strstandard,strsubject,inttextbook,strunitno,strlessonname,intschool,intedit) values(";
                strsql = strsql + "'" + ddlstandard.SelectedValue + "','" + ddlsubject.SelectedValue + "'," + ddltextbook.SelectedValue + ",'" + ddlunitno.SelectedValue + "','" + txtlessonname.Text + "'," + Session["SchoolID"].ToString() + ",0)";
                da.ExceuteSqlQuery(strsql);

                DataSet ds2 = new DataSet();
                strsql = "select max(intid) as intid from tblschoolsyllabus";
                ds2 = da.ExceuteSql(strsql);
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);
            }
        }
        else
        {
            da = new DataAccess();
            strsql = "select * from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and inttextbook=" + ddltextbook.SelectedValue + " and strunitno='" + ddlunitno.SelectedValue + "' and strlessonname='" + txtlessonname.Text + "' and intschool=" + Session["SchoolID"].ToString() + " and intid !=" + item.Cells[0].Text;
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Sorry Lesson Name Cannont Be Duplicated')", true);
            }
            else
            {
                da = new DataAccess();
                strsql = "update tblschoolsyllabus set strunitno='" + ddlunitno.SelectedValue + "',strlessonname='" + txtlessonname.Text + "' where intid=" + item.Cells[0].Text;
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

                da.ExceuteSqlQuery(strsql);
            }
        }
        fillgrid();
    }

    //protected void btndelete_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton view = (ImageButton)sender;
    //    TableCell cell = view.Parent as TableCell;
    //    DataGridItem item = cell.Parent as DataGridItem;
    //    da = new DataAccess();
    //    strsql = "delete tblschoolsyllabus where intid=" + item.Cells[0].Text;
    //    da.ExceuteSqlQuery(strsql);
    //    fillgrid();
    //}

    protected void ddlunits_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr2.Visible = false;
        fillgrid();
    }

    protected void fillgrid()
    {
        strsql = "select a.intid,a.strunitno,a.strlessonname,b.strunitname,a.intedit from tblschoolsyllabus a, tblschooltextbookunits b where a.strunitno=b.strunitno and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and a.inttextbook=" + ddltextbook.SelectedValue + " and b.inttextbook=" + ddltextbook.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
        strsql = strsql + " union all select 0 as intid,'' as strunitno,'' as strlessonname,'' as strunitname,0 as intedit";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            datagrid.DataSource = ds;
            datagrid.DataBind();
            tr2.Visible = true;
        }
    }

    protected void btndone_Click(object sender, EventArgs e)
    {
        da = new DataAccess();
        strsql = "select intid from tblschoolsyllabus where inttextbook=" + ddltextbook.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[i]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 101);

            }
        }
        
        strsql = "update tblschoolsyllabus set intedit=1 where inttextbook=" + ddltextbook.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
        //Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ddltextbook.SelectedValue, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

        da.ExceuteSqlQuery(strsql);
        //Response.Redirect("school_syllabus.aspx");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Saved Successfully!'); location.href='school_syllabus.aspx';", true);

    }
   
}
