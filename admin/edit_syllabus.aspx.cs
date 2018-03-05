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

public partial class admin_edit_syllabus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlsubject.Items.Insert(0,"--Select--");
            ddltextbook.Items.Insert(0,"--Select--");
            
        }
    }
    private void fillstandard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strstandard from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strstandard"].ToString() );

            ddlstandard.Items.Add(li);
        }
    }
    private void fillsubject()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strsubject from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstandard.SelectedValue + "' group by strsubject";
        //string sql = "select strsubject from (select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where";
       // sql += " intschool=" + Session["SchoolID"].ToString() + " and strsubject !='Second Language' and strsubject!='Third language' and strstandard+' - '+strsection ='" + ddlstandard.SelectedValue + "' group by strstandard+' - '+strsection,strsubject";
        //sql += " UNION ALL select strstandard+' - '+strsection as class,strsecondlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandard.SelectedValue + "' and strsecondlanguage !=''";
        //sql += "  group by strsecondlanguage,strstandard+' - '+strsection UNION ALL";
        //sql += " select strstandard+' - '+strsection as class,strthirdlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandard.SelectedValue + "' and strthirdlanguage !=''";
        //sql += " group by strthirdlanguage,strstandard+' - '+strsection) a group by strsubject";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        ddlsubject.Items.Clear();
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("--select--", "0");
            else
                //li = new ListItem(ds.Tables[0].Rows[i - 1]["strsubject"].ToString(), ds.Tables[0].Rows[i - 1]["strsubject"].ToString());
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strsubject"].ToString());
            ddlsubject.Items.Add(li);
        }
    }
     private void filltextbook()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strtextbook from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' group by strtextbook";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        ddltextbook.Items.Clear();
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("--select--", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strtextbook"].ToString(), ds.Tables[0].Rows[i - 1]["strtextbook"].ToString());

            ddltextbook.Items.Add(li);
        }
    }
    protected void filldatagrid()
    {
        string strsql = "";
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
            strsql = "select strstandard,strsubject,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "'and strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "group by strstandard,strsubject,strtextbook,strauthor,intunits";
        else if (ddlstandard.SelectedIndex > 0)
            strsql = "select strstandard,strsubject,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "'and intschool=" + Session["SchoolID"].ToString() + "group by strstandard,strsubject,strtextbook,strauthor,intunits";
        else if (ddlsubject.SelectedIndex > 0)
            strsql = "select strstandard,strsubject,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "group by strstandard,strsubject,strtextbook,strauthor,intunits";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        datagrid.DataSource = ds;
        datagrid.DataBind();
    }
    protected void fillgrid()
    {
        DataSet ds,ds1;
        string str = "";
        str = "select strstandard,strsubject,strtextbook,strauthor,strunitno+' - '+strunitname as unit,'' as strlessonName,strunitno,strunitname from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "'and strsubject='" + ddlsubject.SelectedValue + "'and strtextbook='" + ddltextbook.SelectedValue + "'and intschool=" + Session["SchoolID"].ToString() + " group by strstandard,strsubject,strtextbook,strauthor,strunitno,strunitname";
        DataAccess da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            str = "select strlessonName from tblschoolsyllabus where strstandard='" + ds.Tables[0].Rows[i]["strstandard"].ToString() + "' and strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strtextbook='" + ds.Tables[0].Rows[i]["strtextbook"].ToString() + "' and strauthor='" + ds.Tables[0].Rows[i]["strauthor"].ToString() + "' and strunitno='" + ds.Tables[0].Rows[i]["strunitno"].ToString() + "' and strunitname='" + ds.Tables[0].Rows[i]["strunitname"].ToString() + "' and intschool=" + Session["SchoolID"].ToString();
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(str);
            string lesson = "";
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (lesson == "")
                    lesson = ds1.Tables[0].Rows[j]["strlessonName"].ToString();
                else
                    lesson = lesson + "<br /><br />" + ds1.Tables[0].Rows[j]["strlessonName"].ToString();
            }
            ds.Tables[0].Rows[i]["strlessonName"] = lesson;
        }
        dgsyllabus.DataSource = ds;
        dgsyllabus.DataBind();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedValue != "-Select-")
        {
            fillsubject();
            filldatagrid();
            ddltextbook.Items.Clear();
            ddltextbook.Items.Insert(0, "-Select-");
            dgsyllabus.Visible = false;
            datagrid.Visible = true;
        }
        else
        {
            ddlsubject.Items.Clear();
            ddlsubject.Items.Insert(0, "-Select-");
        }

      
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
            filldatagrid();        
        dgsyllabus.Visible = false;
        datagrid.Visible = true;
        filltextbook();
    }
    protected void datagrid_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["text"] = e.Item.Cells[2].Text;
        Session["std"] = e.Item.Cells[0].Text;
        Session["sub"] = e.Item.Cells[1].Text;
        Response.Redirect("School_Syllabus.aspx?text="+e.Item.Cells[2].Text);
    }
    //protected void datagrid_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string strsql = "";
    //    strsql = "delete tblschoolsyllabus where strstandard='" + e.Item.Cells[0].Text + "' and strsubject='" + e.Item.Cells[1].Text + "' and strtextbook='" + e.Item.Cells[2].Text + "' and strauthor='" + e.Item.Cells[3].Text + "'  and intschool=" + Session["SchoolID"].ToString();
    //    DataAccess da = new DataAccess();
    //    da.ExceuteSqlQuery(strsql);
    //    filldatagrid();
    //}    
    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        dgsyllabus.Visible = true;
        datagrid.Visible = false;
    }
    protected void dgsyllabus_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            Session["stand"] = e.Item.Cells[0].Text;
            Session["subj"] = e.Item.Cells[1].Text;
            Session["txt"] = e.Item.Cells[2].Text;
            Session["unit"] = e.Item.Cells[5].Text;
            Response.Redirect("School_Syllabus.aspx?stand=" + e.Item.Cells[0].Text);
        }
        catch { }
    }
    //protected void dgsyllabus_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string strsql = "";
    //    strsql = "delete tblschoolsyllabus where strsubject='" + e.Item.Cells[1].Text + "' and strtextbook='" + e.Item.Cells[2].Text + "' and strauthor='" + e.Item.Cells[3].Text + "' and strunitno='" + e.Item.Cells[5].Text + "' and strlessonName='" + e.Item.Cells[6].Text + "' and intschool=" + Session["SchoolID"].ToString();
    //    DataAccess da = new DataAccess();
    //    da.ExceuteSqlQuery(strsql);
    //    fillgrid();
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intid from tblschoolsyllabus where strstandard='" + item.Cells[0].Text + "' and strsubject='" + item.Cells[1].Text + "' and strtextbook='" + item.Cells[2].Text + "' and strauthor='" + item.Cells[3].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),189);

            }
        }
        strsql = "delete tblschoolsyllabus where strstandard='" + item.Cells[0].Text + "' and strsubject='" + item.Cells[1].Text + "' and strtextbook='" + item.Cells[2].Text + "' and strauthor='" + item.Cells[3].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        filldatagrid();
    }
    protected void btndelete1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intid from tblschoolsyllabus where strsubject='" + item.Cells[1].Text + "' and strtextbook='" + item.Cells[2].Text + "' and strauthor='" + item.Cells[3].Text + "' and strunitno='" + item.Cells[5].Text + "' and strlessonName='" + item.Cells[6].Text + "' and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),189);

            }
        }
        strsql = "delete tblschoolsyllabus where strsubject='" + item.Cells[1].Text + "' and strtextbook='" + item.Cells[2].Text + "' and strauthor='" + item.Cells[3].Text + "' and strunitno='" + item.Cells[5].Text + "' and strlessonName='" + item.Cells[6].Text + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        fillgrid();
    }
}
