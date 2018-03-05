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
using System.IO;
using System.Drawing;

public partial class gallery_viewgallery : System.Web.UI.Page
{
    string sql;
    public DataSet ds;
    public DataAccess da;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpacademicyear.Focus();
            clear();
            fillgrid();
            Radiovideo.Visible = false;
        }
    }
    protected void fillgrid()
    {
        try
        {
            ds = new DataSet();
            da = new DataAccess();
            string sql = "";
            sql = "select distinct b.intid,b.strgroups from tblgallery a, tblgallerygroups b where a.intschool=b.intschool and a.intpublished=1 and a.intschool=" + Session["SchoolID"];
            if (drpacademicyear.SelectedIndex > 0)
            {
                sql += " and a.intacademicyear=" + drpacademicyear.SelectedValue;
            }
            if (drptitle.SelectedIndex > 0)
            {
                sql += " and a.intgroups ='" + drptitle.SelectedValue + "'";
            }
            if (Radiovideo.Checked != true)
            {
                sql += " and a.strcategory='Photos'";
            }
            else
            {
                sql += " and a.strcategory='Videos'";
            }
            sql += " and a.intgroups=b.intid order by b.intid desc";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Radiovideo.Checked != true)
                {
                    grdimagegallery.Visible = true;
                    grdvideogallery.Visible = false;
                    grdimagegallery.DataSource = ds;
                    grdimagegallery.DataBind();
                }
                else
                {
                    grdvideogallery.Visible = true;
                    grdimagegallery.Visible = false;
                    grdvideogallery.DataSource = ds;
                    grdvideogallery.DataBind();
                }
            }
            else
            {
                grdimagegallery.Visible = false;
                grdvideogallery.Visible = false;
            }
        }
        catch { }
    }
    protected void fillacademicyear()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select intYear from tblAcademicYear where intschool=" + Session["SchoolID"] + " group by intYear";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            drpacademicyear.DataTextField = "intYear";
            drpacademicyear.DataValueField = "intYear";
            drpacademicyear.DataSource = ds;
            drpacademicyear.DataBind();
            ListItem li = new ListItem("-ALL-", "0");
            drpacademicyear.Items.Insert(0, li);
            DataSet ds1 = new DataSet();
            string str = "select top 1 intYear from tblAcademicYear where intschool=" + Session["SchoolID"] + " and intactive=1 order by intID desc";
            ds1 = da.ExceuteSql(str);
            drpacademicyear.SelectedValue = ds1.Tables[0].Rows[0]["intYear"].ToString();
        }
        catch { }
    }
    protected void filltitle()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select b.intid,b.strgroups from tblgallery a,tblgallerygroups b where a.intschool=b.intschool and a.intschool= " + Session["SchoolID"];
            if (drpacademicyear.SelectedIndex > 0)
            {
                sql += " and a.intacademicyear=" + drpacademicyear.SelectedValue;
            }
            sql += " and b.intid in (select intgroups from tblgallery where intschool=" + Session["SchoolID"] + " and intpublished=1 group by intgroups)";
            if (radiophoto.Checked == true)
            {
                sql += " and  a.strcategory='Photos'";
            }
            else
            {
                sql += " and  a.strcategory='Videos'";
            }
            sql += " and a.intgroups=b.intid group by b.intid,b.strgroups";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            drptitle.DataTextField = "strgroups";
            drptitle.DataValueField = "intid";
            drptitle.DataSource = ds;
            drptitle.DataBind();
            ListItem li = new ListItem("-ALL-", "0");
            drptitle.Items.Insert(0, li);
        }
        catch { }
    }
    protected void clear()
    {
        try
        {
            radiophoto.Checked = true;
            Radiovideo.Checked = false;
            fillacademicyear();
            filltitle();
            trtitledrp.Visible = true;
        }
        catch { }
    }
    protected void drpacademicyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select * from tblgallery where intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolId"];
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                trtitledrp.Visible = true;
                filltitle();
                drptitle.Focus();
            }
            else
            {
                trtitledrp.Visible = false;
            }
            fillgrid();
        }
        catch { }
    }
    protected void drptitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void btncanceladd_Click(object sender, EventArgs e)
    {
        trtitledrp.Visible = true;
        drptitle.Focus();
    }
    protected void grdimagegallery_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataList dlimage = (DataList)e.Item.FindControl("dlimage");
            ds = new DataSet();
            da = new DataAccess();
            sql = "select * from tblgallery where intschool=" + Session["SchoolID"];
            if (drpacademicyear.SelectedIndex > 0)
            {
                sql += " and intacademicyear=" + drpacademicyear.SelectedValue;
            }
            sql += "  and intpublished=1 and intgroups =" + dr["intid"] + " order by intid desc";
            ds = da.ExceuteSql(sql);
            dlimage.DataSource = ds;
            dlimage.DataBind();
        }
        catch { }
    }
    protected void dlimage_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblid = (Label)e.Item.FindControl("lblid");
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ASPNetFlashVideo.FlashVideo flsvideo = (ASPNetFlashVideo.FlashVideo)e.Item.FindControl("FlashVideo1");
                Label lblvideoname = (Label)e.Item.FindControl("lblvideoname");
                HtmlImage image12 = (HtmlImage)e.Item.FindControl("Image1");
                Label id = (Label)e.Item.FindControl("id");
                Label thumb = (Label)e.Item.FindControl("Label1");
                HtmlAnchor a = (HtmlAnchor)e.Item.FindControl("imageLink");
                try
                {
                    flsvideo.VideoURL = "galleryvideo/orgvideo/" + lblvideoname.Text;
                }
                catch { }
                try
                {
                    image12.Src = "galleryimage/Thumbimage/" + thumb.Text;
                    a.HRef = "galleryimage/orgimage/" + id.Text;
                }
                catch { }
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string sql = "select * from tblgallery where intschool=" + Session["SchoolID"] + " and intid=" + lblid.Text + " and intedit=0 order by intid desc";
                ds = da.ExceuteSql(sql);
            }
        }
    }
    protected void radiophoto_CheckedChanged(object sender, EventArgs e)
    {
        Radiovideo.Checked = false;
        filltitle();
        lbltitle.Text = "Image Title";
        fillgrid();
    }
    protected void Radiovideo_CheckedChanged(object sender, EventArgs e)
    {
        radiophoto.Checked = false;
        filltitle();
        lbltitle.Text = "Video Title";
        fillgrid();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton image = (ImageButton)sender;
            DataListItem ditem = image.Parent as DataListItem;
            ImageButton imageedit = (ImageButton)ditem.FindControl("ImageButton1");
            Label lblid = (Label)ditem.FindControl("lblid");
            DataAccess da = new DataAccess();
            string sql = "delete from tblgallery  where intschool=" + Session["SchoolID"] + " and intid=" + lblid.Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lblid.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),317);
            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch { }
    }
}
