using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class admin_search_view_syllabus : System.Web.UI.Page
{
    public string str;
    public DataSet dataset;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            trtag.Visible = false;
            trtag2.Visible = false;
            ddlsubject.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(0, "-Select-");
            datagrid.Visible = false;
        }
    }
    private void fillstandard()
    {
        DataAccess da = new DataAccess();
        string sql = "select strstandard from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " group by strstandard";       
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListItem li;
            for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                    li = new ListItem("-Select-", "0");
                else
                    li = new ListItem(ds.Tables[0].Rows[i - 1]["strstandard"].ToString());

                ddlstandard.Items.Add(li);
            }
        }
    }
    private void fillsubject()
    {
        DataAccess da = new DataAccess();
        string sql = "select strsubject from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstandard.SelectedValue + "' group by strsubject";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
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
        }
    }
    private void filltextbook()
    {
        DataAccess da = new DataAccess();
        string sql = "select strtextbook from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' group by strtextbook";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListItem li;
            ddltextbook.Items.Clear();
            for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                    li = new ListItem("-Select-", "0");
                else
                    li = new ListItem(ds.Tables[0].Rows[i - 1]["strtextbook"].ToString(), ds.Tables[0].Rows[i - 1]["strtextbook"].ToString());

                ddltextbook.Items.Add(li);
            }
            
        }
        filldatagrid();
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
        else
        {
            strsql = "select strstandard,strsubject,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where intschool=0";
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        datagrid.DataSource = ds;
        datagrid.DataBind();
        datagrid.Visible = true;
        trtag2.Visible = false;
        trtag.Visible = false;
    }
    protected void filldesign()
    {
        DataAccess da = new DataAccess();
        DataSet ds, ds1;
        string str;
        DataTable dtProducts = new DataTable("table1");
        ds = new DataSet();
        dtProducts = new DataTable("table1");
        dtProducts.Columns.Add("strunitno");
        dtProducts.Columns.Add("unit");
        dtProducts.Columns.Add("ProductID");
        dtProducts.Columns.Add("count");
        DataTable dtProductsDetails = new DataTable("table2");
        dtProductsDetails = new DataTable("table2");
        dtProductsDetails.Columns.Add("ProductID");
        dtProductsDetails.Columns.Add("strunitno");
        dtProductsDetails.Columns.Add("unit");
        dtProductsDetails.Columns.Add("strlessonName");
        dtProductsDetails.Columns.Add("count");
        str = "select strunitno,strunitno+' - '+strunitname as unit from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + ddltextbook.SelectedValue + "' group by strunitno,strunitname";
        dataset = new DataSet();
        dataset = da.ExceuteSql(str);

        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            str = "select strlessonName from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strunitno='" + dataset.Tables[0].Rows[i]["strunitno"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + ddltextbook.SelectedValue + "'";
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(str);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {                
                DataRow drProductsDetails = dtProductsDetails.NewRow();
                drProductsDetails["ProductID"] = j;
                drProductsDetails["strlessonName"] = ds1.Tables[0].Rows[j]["strlessonName"].ToString();
                drProductsDetails["strunitno"] = dataset.Tables[0].Rows[i]["strunitno"].ToString();
                drProductsDetails["unit"] = dataset.Tables[0].Rows[i]["unit"].ToString();
                if (Session["count"] == null)
                {
                    drProductsDetails["count"] = j + 1;
                }
                else
                {
                    int k = j;
                    j = int.Parse(Session["count"].ToString());
                    if (Session["c"] == null)
                        drProductsDetails["count"] = j + 1;
                    else
                    {
                        j = int.Parse(Session["c"].ToString());
                        drProductsDetails["count"] = j + 1;
                    }
                    Session["c"] = j + 1;
                    j = k;
                }
                dtProductsDetails.Rows.Add(drProductsDetails);
                
            }
            if (Session["count"] == null)
                Session["count"] = ds1.Tables[0].Rows.Count;
            else
                Session["count"] = int.Parse(Session["count"].ToString()) + ds1.Tables[0].Rows.Count;
            DataRow drProducts = dtProducts.NewRow();
            drProducts["ProductID"] = i;
            drProducts["strunitno"] = dataset.Tables[0].Rows[i]["strunitno"].ToString();
            drProducts["unit"] = dataset.Tables[0].Rows[i]["unit"].ToString();
            dtProducts.Rows.Add(drProducts);
        }
        ds.Tables.Add(dtProducts);
        ds.Tables.Add(dtProductsDetails);
        ds.Relations.Add("myRelation", ds.Tables["table1"].Columns["strunitno"], ds.Tables["table2"].Columns["strunitno"]);
        DataGrid1.DataSource = ds.Tables["table1"];
        DataGrid1.DataBind();
        Session["count"] = null;
        Session["c"] = null;
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedValue != "-Select-")
        {
            fillsubject();
            filldatagrid();
            ddltextbook.Items.Clear();
            ddltextbook.Items.Insert(0, "-Select-");
        }
        else
        {
            ddlsubject.Items.Clear();
            ddlsubject.Items.Insert(0,"-Select-");
        }

    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedItem.Text!="-Select-")
        {
            filltextbook();
        }
        else
        {
            ddltextbook.Items.Clear();
            ddltextbook.Items.Insert(0,"-Select-");
            filldatagrid();
        }
    }
    protected void ddltextbook_SelectedIndexChanged1(object sender, EventArgs e)
    {
        filldesign();
        lblstandard.Text = ddlstandard.SelectedValue;
        lblsubject.Text = ddlsubject.SelectedValue;
        lbltextbook.Text = ddltextbook.SelectedValue;
        DataAccess da = new DataAccess();
        DataSet ds;
        string str;
        str = "select strauthor from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and  strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + ddltextbook.SelectedValue + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblauthor.Text = ds.Tables[0].Rows[0]["strauthor"].ToString();
            trtag.Visible = true;
            trtag2.Visible = true;
            datagrid.Visible = false;
        }
        else
        {
            filldatagrid();
        }
    }
    protected void btnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        ImageButton btnview = new ImageButton();
        btnview = (ImageButton)item.FindControl("btnview");
        DataGridItem dgi = datagrid.Items[index];        
        lblstandard.Text = dgi.Cells[0].Text;
        lblsubject.Text = dgi.Cells[1].Text;
        lbltextbook.Text = dgi.Cells[2].Text;
        DataAccess da = new DataAccess();
        DataSet ds,ds1;
        string str;
        str = "select strauthor from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and  strstandard='" + dgi.Cells[0].Text + "' and strsubject='" + dgi.Cells[1].Text + "' and strtextbook='" +  dgi.Cells[2].Text  + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        lblauthor.Text = ds.Tables[0].Rows[0]["strauthor"].ToString();        
        DataTable dtProducts = new DataTable("table1");
        ds = new DataSet();
        dtProducts = new DataTable("table1");
        dtProducts.Columns.Add("strunitno");
        dtProducts.Columns.Add("unit");
        dtProducts.Columns.Add("ProductID");
        dtProducts.Columns.Add("count");
        DataTable dtProductsDetails = new DataTable("table2");
        dtProductsDetails = new DataTable("table2");
        dtProductsDetails.Columns.Add("ProductID");
        dtProductsDetails.Columns.Add("strunitno");
        dtProductsDetails.Columns.Add("unit");
        dtProductsDetails.Columns.Add("strlessonName");
        dtProductsDetails.Columns.Add("count");
        str = "select strunitno,strunitno+' - '+strunitname as unit from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + dgi.Cells[0].Text + "' and strsubject='" + dgi.Cells[1].Text + "' and strtextbook='" + dgi.Cells[2].Text + "' group by strunitno,strunitname";
        dataset = new DataSet();
        dataset = da.ExceuteSql(str);

        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            str = "select strlessonName from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strunitno='" + dataset.Tables[0].Rows[i]["strunitno"].ToString() + "' and strstandard='" + dgi.Cells[0].Text + "' and strsubject='" + dgi.Cells[1].Text + "' and strtextbook='" + dgi.Cells[2].Text + "'";
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(str);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                DataRow drProductsDetails = dtProductsDetails.NewRow();
                drProductsDetails["ProductID"] = j;
                drProductsDetails["strlessonName"] = ds1.Tables[0].Rows[j]["strlessonName"].ToString();
                drProductsDetails["strunitno"] = dataset.Tables[0].Rows[i]["strunitno"].ToString();
                drProductsDetails["unit"] = dataset.Tables[0].Rows[i]["unit"].ToString();
                if (Session["count"] == null)
                {
                    drProductsDetails["count"] = j + 1;
                }
                else
                {
                    int k = j;
                    j = int.Parse(Session["count"].ToString());
                    if (Session["c"] == null)
                        drProductsDetails["count"] = j + 1;
                    else
                    {
                        j = int.Parse(Session["c"].ToString());
                        drProductsDetails["count"] = j + 1;
                    }
                    Session["c"] = j + 1;
                    j = k;
                }
                dtProductsDetails.Rows.Add(drProductsDetails);

            }
            if (Session["count"] == null)
                Session["count"] = ds1.Tables[0].Rows.Count;
            else
                Session["count"] = int.Parse(Session["count"].ToString()) + ds1.Tables[0].Rows.Count;
            DataRow drProducts = dtProducts.NewRow();
            drProducts["ProductID"] = i;
            drProducts["strunitno"] = dataset.Tables[0].Rows[i]["strunitno"].ToString();
            drProducts["unit"] = dataset.Tables[0].Rows[i]["unit"].ToString();
            dtProducts.Rows.Add(drProducts);
        }
        ds.Tables.Add(dtProducts);
        ds.Tables.Add(dtProductsDetails);
        ds.Relations.Add("myRelation", ds.Tables["table1"].Columns["strunitno"], ds.Tables["table2"].Columns["strunitno"]);
        DataGrid1.DataSource = ds.Tables["table1"];
        DataGrid1.DataBind();
        Session["count"] = null;
        Session["c"] = null;
        trtag.Visible = true;
        trtag2.Visible = true;
        datagrid.Visible = false;

    }
    
}
