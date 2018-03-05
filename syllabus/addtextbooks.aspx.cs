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

public partial class syllabus_addtextbooks : System.Web.UI.Page
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
            trpaper.Visible = false;
            tr1.Visible = false;
            ddlsubject.Items.Insert(0, "-Select-");
        }
    }

    private void fillstandard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strstandard,strsection from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strstandard"].ToString() + " - " + ds.Tables[0].Rows[i - 1]["strsection"].ToString(), ds.Tables[0].Rows[i - 1]["strstandard"].ToString() + " - " + ds.Tables[0].Rows[i - 1]["strsection"].ToString());

            ddlstandard.Items.Add(li);
        }
    }

    private void fillsubject()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        //string sql = "select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection ='" + ddlstandard.SelectedValue + "' group by strstandard+' - '+strsection,strsubject";
        string sql = "select strsubject from (select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where";
        sql += " intschoolid=" + Session["SchoolID"].ToString() + " and strsubject !='Second Language' and strsubject!='Third language' and strstandard+' - '+strsection ='" + ddlstandard.SelectedValue + "' group by strstandard+' - '+strsection,strsubject";
        sql += " UNION ALL select strstandard+' - '+strsection as class,strsecondlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandard.SelectedValue + "' and strsecondlanguage !=''";
        sql += "  group by strsecondlanguage,strstandard+' - '+strsection UNION ALL";
        sql += " select strstandard+' - '+strsection as class,strthirdlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandard.SelectedValue + "' and strthirdlanguage !=''";
        sql += " group by strthirdlanguage,strstandard+' - '+strsection) a group by strsubject";
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

    private void fillpaper()
    {
        strsql = "select strexampaper from tblschoolexampaper where strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + " group by strexampaper";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlpaper.DataSource = ds;
        ddlpaper.DataTextField = "strexampaper";
        ddlpaper.DataValueField = "strexampaper";
        ddlpaper.DataBind();
        ListItem li = new ListItem("Select", "0");
        ddlpaper.Items.Insert(0, li);
        if (ds.Tables[0].Rows.Count > 0)
            trpaper.Visible = true;
        else
            msgbox.alert("No Paper Assinged for this subject");
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
        fillsubject();
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            fillpaper();
        }
        else
        {
            trbelow.Visible = false;
        }
    }

    protected void filltextbook()
    {
        trbelow.Visible = true;
        tr2.Visible = false;

        strsql = "select intid,strtextbookname from tblschooltextbook where strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strpaper='" + ddlpaper.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltextbook.DataSource = ds;
            ddltextbook.DataTextField = "strtextbookname";
            ddltextbook.DataValueField = "intid";
            ddltextbook.DataBind();
            ListItem li = new ListItem("Select Textbook", "0");
            ddltextbook.Items.Insert(0, li);
            txttextbookname.Visible = false;
            txtauthor.Visible = false;
            ddltextbook.Visible = true;
            lblauthor.Visible = true;
            lblauthor.Text = "";
            btnaddtext.Text = "Add New";
        }
        else
        {
            txttextbookname.Visible = true;
            txtauthor.Visible = true;
            ddltextbook.Visible = false;
            lblauthor.Visible = false;
            btnaddtext.Visible = true;
            tr1.Visible = true;
            btnaddtext.Text = "Save";
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
        DataAccess da = new DataAccess();
        strsql = "select intid from tblschoolsyllabus where intid='" + e.Item.Cells[0].Text + "' and strlessonName='" + e.Item.Cells[1].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);

            }
        }
        strsql = "delete tblschoolsyllabus where intid='" + e.Item.Cells[0].Text + "' and strlessonName='" + e.Item.Cells[1].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
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
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);

            }
        }

        strsql = "delete tblschoolsyllabus where strstandard='" + e.Item.Cells[0].Text + "' and strsubject='" + e.Item.Cells[1].Text + "' and strtextbook='" + e.Item.Cells[2].Text + "' and strauthor='" + e.Item.Cells[3].Text + "'and strunitno='" + e.Item.Cells[5].Text + "'and strunitname='" + e.Item.Cells[6].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
    }

    protected void btnaddtext_Click(object sender, EventArgs e)
    {
        if (btnaddtext.Text == "Save")
        {
            if (txttextbookname.Text != "")
            {
                if (txtauthor.Text != "")
                {
                    da = new DataAccess();
                    strsql = "select * from tblschooltextbook where strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strpaper='" + ddlpaper.SelectedValue + "' and strtextbookname='" + txttextbookname.Text + "' and strauthorname='" + txtauthor.Text + "'";
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Textbook For Same Author Already Exists')", true);
                    }
                    else
                    {
                        int intsame = 0;
                        if (rbtnyes.Checked)
                            intsame = 1;
                        da = new DataAccess();
                        strsql = "insert into tblschooltextbook (strclass,strsubject,strtextbookname,strauthorname,intsame,intschool,strpaper) ";
                        strsql = strsql + "values('" + ddlstandard.SelectedValue + "','" + ddlsubject.SelectedValue + "','" + txttextbookname.Text.Replace("'", "''") + "','" + txtauthor.Text + "'," + intsame.ToString() + "," + Session["SchoolID"].ToString() + ",'" + ddlpaper.SelectedValue + "')";
                        da.ExceuteSqlQuery(strsql);
                        lblauthor.Text = "";
                        tr1.Visible = false;
                        filltextbook();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);

                        DataSet ds2 = new DataSet();
                        strsql = "select max(intid) as intid from tblschooltextbook";
                        ds2 = da.ExceuteSql(strsql);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbook", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);


                        strsql = "select intid from tblschooltextbook where strclass='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strpaper='" + ddlpaper.SelectedValue + "' and strtextbookname='" + txttextbookname.Text.Replace("'", "''") + "' and strauthorname='" + txtauthor.Text + "' and intschool=" + Session["SchoolID"].ToString();
                        da = new DataAccess();
                        ds = new DataSet();
                        ds = da.ExceuteSql(strsql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddltextbook.SelectedValue = ds.Tables[0].Rows[0]["intid"].ToString();
                            settextbook();
                        }
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Author Name')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Textbook Name')", true);
        }
        else
        {
            txtauthor.Text = "";
            txttextbookname.Text = "";
            txttextbookname.Visible = true;
            ddltextbook.Visible = false;
            txtauthor.Visible = true;
            lblauthor.Visible = false;
            btnaddtext.Text = "Save";
            tr1.Visible = true;
            tr2.Visible = false;
        }
    }

    protected void settextbook()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strauthorname,intsame from tblschooltextbook where intid=" + ddltextbook.SelectedValue;
        ds = da.ExceuteSql(strsql);
        lblauthor.Text = ds.Tables[0].Rows[0]["strauthorname"].ToString();
        lblsame.Text = ds.Tables[0].Rows[0]["intsame"].ToString();
        fillunits();
        tr2.Visible = true;
    }

    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltextbook.SelectedIndex > 0)
        {
            settextbook();
        }
        else
        {
            lblauthor.Text = "";
            tr2.Visible = false;
        }
    }

    protected void fillunits()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select 0 as intunitno,*,'' as strunitname1 from tblschooltextbookunits where inttextbook=" + ddltextbook.SelectedValue + " order by intid";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["strunitno"].ToString() == "Unit - " + (i + 1).ToString())
                {
                }
                else
                {
                    da = new DataAccess();
                    strsql = "update tblschoolsyllabus set strunitno='Unit - " + (i + 1).ToString() + "' where strunitno='" + ds.Tables[0].Rows[i]["strunitno"].ToString() + "' and inttextbook=" + ddltextbook.SelectedValue;
                    da.ExceuteSql(strsql);

                    da = new DataAccess();
                    if (lblsame.Text == "1")
                    {
                        strsql = "update tblschooltextbookunits set strunitno='Unit - " + (i + 1).ToString() + "',strunitname='Unit - " + (i + 1).ToString() + "' where inttextbook=" + ddltextbook.SelectedValue + " and strunitno='" + ds.Tables[0].Rows[i]["strunitno"].ToString() + "'";
                    }
                    else
                    {
                        strsql = "update tblschooltextbookunits set strunitno='Unit - " + (i + 1).ToString() + "' where inttextbook=" + ddltextbook.SelectedValue + " and strunitno='" + ds.Tables[0].Rows[i]["strunitno"].ToString() + "'";                        
                    }
                    da.ExceuteSql(strsql);
                }
            }
        }

        da = new DataAccess();
        ds = new DataSet();
        strsql = "select 0 as intunitno,*,'' as strunitname1 from tblschooltextbookunits where inttextbook=" + ddltextbook.SelectedValue + " ";
        strsql = strsql + " union all select 0 as intid,0 as intunitno," + ddltextbook.SelectedValue + " as inttextbook,'' as strunitno,'' as strunitname,0 as intedit,'' as strunitname1";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["intunitno"] = (i + 1).ToString();
                if (ds.Tables[0].Rows.Count - 1 == i)
                    ds.Tables[0].Rows[i]["strunitno"] = "Unit - " + (i + 1).ToString();
                if (lblsame.Text == "1")
                {
                    ds.Tables[0].Rows[i]["strunitname1"] = "Unit - " + (i + 1).ToString();
                }
            }
            if (lblsame.Text == "0")
            {
                datagrid.Columns[3].HeaderText = "Unit No";
                datagrid.Columns[5].Visible = true;
            }
            else
            {
                datagrid.Columns[3].HeaderText = "Unit No/Unit Name";
                datagrid.Columns[5].Visible = false;
            }
            datagrid.DataSource = ds;
            datagrid.DataBind();
        }
    }

    protected void datagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ImageButton btnaddunit = (ImageButton)e.Item.FindControl("btnaddunit");
            ImageButton btndelete = (ImageButton)e.Item.FindControl("btndelete");
            Label lblunitname = (Label)e.Item.FindControl("lblunitname");
            TextBox txtunitname = (TextBox)e.Item.FindControl("txtunitname");
            if (dr["intid"].ToString() == "0")
            {
                btnaddunit.ImageUrl = "../media/images/add.gif";
                btndelete.Visible = false;
                lblunitname.Visible = false;
            }
            else
            {
                btnaddunit.ImageUrl = "../media/images/update.gif";
                if (lblsame.Text == "1")
                {
                    btnaddunit.Visible = false;
                }
                else
                {
                    if (dr["intedit"].ToString() == "1")
                    {
                        btnaddunit.Visible = false;
                        lblunitname.Visible = true;
                        txtunitname.Visible = false;
                    }
                    else
                    {
                        btnaddunit.Visible = true;
                        lblunitname.Visible = false;
                        txtunitname.Visible = true;
                    }
                }
            }
            ((ImageButton)e.Item.Cells[1].FindControl("btndelete")).Attributes.Add("onclick", "return confirm('Do You Want To Delete Permanently?');");
        }
        catch { }

    }

    protected void btnaddunit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        TextBox txtunitname = (TextBox)item.FindControl("txtunitname");
        ImageButton btnaddunit = (ImageButton)item.FindControl("btnaddunit");
        if (btnaddunit.ImageUrl == "../media/images/update.gif")
        {
            if (lblsame.Text == "0")
            {
                da = new DataAccess();
                strsql = "select * from tblschooltextbookunits where strunitname='" + txtunitname.Text + "' and inttextbook=" + ddltextbook.SelectedValue + " and intid!=" + item.Cells[0].Text;
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Unit Name Already Exists For This Textbook')", true);
                }
                else
                {
                    da = new DataAccess();
                    strsql = "update tblschooltextbookunits set strunitname='" + txtunitname.Text + "' where intid=" + item.Cells[0].Text;
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbookunits", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);

                    da.ExceuteSqlQuery(strsql);
                    fillunits();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully!')", true);

                }
            }
        }
        else
        {
            if (lblsame.Text == "0")
            {
                da = new DataAccess();
                strsql = "select * from tblschooltextbookunits where strunitname='" + txtunitname.Text + "' and inttextbook=" + ddltextbook.SelectedValue + " and intid!=" + item.Cells[0].Text;
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Unit Name Already Exists For This Textbook')", true);
                }
                else
                {
                    da = new DataAccess();
                    strsql = "insert into tblschooltextbookunits (inttextbook,strunitno,strunitname,intedit) values(" + ddltextbook.SelectedValue + ",'" + item.Cells[3].Text + "','" + txtunitname.Text + "',0)";
                    da.ExceuteSqlQuery(strsql);
                    fillunits();
                    
                    DataSet ds2 = new DataSet();
                    strsql = "select max(intid) as intid from tblschooltextbookunits";
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbookunits", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);

                }
            }
            else
            {
                da = new DataAccess();
                strsql = "insert into tblschooltextbookunits (inttextbook,strunitno,strunitname,intedit) values(" + ddltextbook.SelectedValue + ",'" + item.Cells[3].Text + "','" + item.Cells[4].Text + "',0)";
                da.ExceuteSqlQuery(strsql);
                fillunits();

                DataSet ds2 = new DataSet();
                strsql = "select max(intid) as intid from tblschooltextbookunits";
                ds2 = da.ExceuteSql(strsql);
                Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbookunits", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);
            }
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
        strsql = "select * from tblschoolsyllabus where inttextbook=" + ddltextbook.SelectedValue + " and strunitno='" + item.Cells[3].Text + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Sorry Cannont Be Deleted! This Unit Has Lessons')", true);
        }
        else
        {
            da = new DataAccess();
            strsql = "delete tblschooltextbookunits where intid=" + item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbookunits", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);

            da.ExceuteSqlQuery(strsql);
            fillunits();
        }
    }

    protected void btndone_Click(object sender, EventArgs e)
    {
        da = new DataAccess();

        strsql = "select intid from tblschooltextbookunits where inttextbook in(select intid from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + ")";
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschooltextbookunits", ds.Tables[0].Rows[i]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),300);

            }
        }

        strsql = "update tblschooltextbookunits set intedit=1 where inttextbook in(select intid from tblschooltextbook where intschool=" + Session["SchoolID"].ToString() + ")";
        da.ExceuteSqlQuery(strsql);
        //Response.Redirect("addtextbooks.aspx");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "redirect script", "alert('Details Done Successfully!'); location.href='addtextbooks.aspx';", true);

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        lblauthor.Text = "";
        tr1.Visible = false;
        filltextbook();
    }

    protected void ddlpaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpaper.SelectedIndex > 0)
        {
            txttextbookname.Text = "";
            txtauthor.Text = "";
            tr1.Visible = false;
            filltextbook();
        }
        else
        {
            trbelow.Visible = false;
        }
    }
    protected void txtunitname_TextChanged(object sender, EventArgs e)
    {

    }
}
