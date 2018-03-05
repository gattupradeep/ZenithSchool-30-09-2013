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
            trback.Visible = false;
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || Session["PatronType"].ToString() == "Teaching Staffs")
            {
                trsidemenu.Visible = false;
            }
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
            {
                ddlstandard.SelectedValue = Session["StudentClass"].ToString();
                fillsubject();
            }
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
        string sql = "select strtextbookname from tblschoolsyllabus a, tblschooltextbook b where a.intschool=" + Session["SchoolID"].ToString() + "  and a.inttextbook=b.intid and strclass='" + ddlstandard.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' group by strtextbookname";
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
                    li = new ListItem(ds.Tables[0].Rows[i - 1]["strtextbookname"].ToString(), ds.Tables[0].Rows[i - 1]["strtextbookname"].ToString());

                ddltextbook.Items.Add(li);
            }
            
        }
        filldatagrid();
    }

    protected void filldatagrid()
    {
        string strsql = "";
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
            strsql = "select b.intid,strclass,a.strsubject,strtextbookname,strauthorname from dbo.tblschoolsyllabus a, tblschooltextbook b where strclass='" + ddlstandard.SelectedValue + "'and a.strsubject='" + ddlsubject.SelectedValue + "'  and a.inttextbook=b.intid and a.intschool=" + Session["SchoolID"].ToString() + "group by strclass,a.strsubject,strtextbookname,strauthorname";
        else if (ddlstandard.SelectedIndex > 0)
            strsql = "select b.intid,strclass,a.strsubject,strtextbookname,strauthorname from dbo.tblschoolsyllabus a, tblschooltextbook b where strclass='" + ddlstandard.SelectedValue + "'  and a.inttextbook=b.intid and a.intschool=" + Session["SchoolID"].ToString() + "group by strclass,a.strsubject,strtextbookname,strauthorname";
        else if (ddlsubject.SelectedIndex > 0)
            strsql = "select b.intid,strclass,a.strsubject,strtextbookname,strauthorname from dbo.tblschoolsyllabus a, tblschooltextbook b where a.strsubject='" + ddlsubject.SelectedValue + "'  and a.inttextbook=b.intid and a.intschool=" + Session["SchoolID"].ToString() + "group by strclass,a.strsubject,strtextbookname,strauthorname";
        else
        {
            strsql = "select b.intid,strclass,a.strsubject,strtextbookname,strauthorname from dbo.tblschoolsyllabus a, tblschooltextbook b where a.intschool=0 and a.inttextbook=b.intid ";
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        datagrid.DataSource = ds;
        datagrid.DataBind();
        datagrid.Visible = true;
        trtag2.Visible = false;
        trtag.Visible = false;
        trback.Visible = false;
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
        str = "select c.strunitno,c.strunitno+' - '+c.strunitname as unit from tblschoolsyllabus a, tblschooltextbook b, tblschooltextbookunits c where a.inttextbook=b.intid and a.inttextbook=c.inttextbook and a.intschool=" + Session["SchoolID"].ToString() + " and strclass='" + ddlstandard.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and strtextbookname='" + ddltextbook.SelectedValue + "' group by c.strunitno,c.strunitname";
        dataset = new DataSet();
        dataset = da.ExceuteSql(str);

        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            str = "select strlessonName from tblschoolsyllabus a, tblschooltextbook b where a.inttextbook=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and strunitno='" + dataset.Tables[0].Rows[i]["strunitno"].ToString() + "' and strstandard='" + ddlstandard.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and strtextbookname='" + ddltextbook.SelectedValue + "'";
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
        str = "select strauthorname from tblschoolsyllabus a, tblschooltextbook b where a.intschool=" + Session["SchoolID"].ToString() + "  and a.inttextbook=b.intid and  strclass='" + ddlstandard.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and strtextbookname='" + ddltextbook.SelectedValue + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblauthor.Text = ds.Tables[0].Rows[0]["strauthorname"].ToString();
            trtag.Visible = true;
            trtag2.Visible = true;
            trback.Visible = true;
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
        str = "select isnull(strauthorname,'None') as strauthorname from tblschooltextbook where intid=" + dgi.Cells[7].Text + " and intschool=" + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        lblauthor.Text = ds.Tables[0].Rows[0]["strauthorname"].ToString();        
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
        str = "select c.strunitno,c.strunitno+' - '+c.strunitname as unit from tblschoolsyllabus a, tblschooltextbook b, tblschooltextbookunits c where a.inttextbook=b.intid and a.inttextbook=c.inttextbook and a.intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + dgi.Cells[0].Text + "' and a.strsubject='" + dgi.Cells[1].Text + "' and strtextbookname='" + dgi.Cells[2].Text + "' group by c.strunitno,c.strunitname";
        dataset = new DataSet();
        dataset = da.ExceuteSql(str);

        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            str = "select strlessonName from tblschoolsyllabus a, tblschooltextbook b where a.inttextbook=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and strunitno='" + dataset.Tables[0].Rows[i]["strunitno"].ToString() + "' and strstandard='" + dgi.Cells[0].Text + "' and a.strsubject='" + dgi.Cells[1].Text + "' and strtextbookname='" + dgi.Cells[2].Text + "'";
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
        trback.Visible = true;
        datagrid.Visible = false;

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        trtag.Visible = false;
        trtag2.Visible = false;
        trback.Visible = false;
        filldatagrid();
    }
}
