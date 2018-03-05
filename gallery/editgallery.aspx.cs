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

public partial class gallery_editgallegy : System.Web.UI.Page
{
    string sql;
    public DataSet ds;
    public DataAccess da;
    int checktrue = 0;
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
            sql = "select distinct b.intid,b.strgroups from tblgallery a, tblgallerygroups b where a.intschool=b.intschool and a.intschool=" + Session["SchoolID"];
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
            if (drpstatus.SelectedIndex == 1)
            {
                sql += " and intpublished=1";
            }
            if (drpstatus.SelectedIndex == 2)
            {
                sql += " and intpublished=0";
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
            deletegroups();
        }
        catch { }
    }
    protected void deletegroups()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select intid from tblgallerygroups where intid not in (select intgroups from tblgallery where intschool=" + Session["SchoolID"] + ") and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblgallerygroups", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);

                }
            }
            
            sql = "delete tblgallerygroups where intid not in (select intgroups from tblgallery where intschool=" + Session["SchoolID"] + ") and intschool=" + Session["SchoolID"];
            //Functions.UserLogs(Session["UserID"].ToString(), "tblgallerygroups", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
            da.ExceuteSqlQuery(sql);
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
            string str = "select top 1 intYear from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"] + " order by intID desc";
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
            drpstatus.SelectedIndex = 0;
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
            sql += "  and intgroups =" + dr["intid"] + " order by intid desc";
            ds = da.ExceuteSql(sql);
            dlimage.DataSource = ds;
            dlimage.DataBind();
        }
        catch { }
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        chk.Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        chk.Checked = true;
                    }
                }
            }
        }
        catch { }
    }
    protected void btndeselectall_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        chk.Checked = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        chk.Checked = false;
                    }
                }
            }
        }
        catch { }
    }
    protected void btnpublished_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        Label lbl = (Label)ditem.FindControl("lblid");
                        if (chk.Checked == true)
                        {
                            int index = ditem.ItemIndex;
                            DataAccess da = new DataAccess();
                            string sql = "update tblgallery set intpublished=1 where intschool=" + Session["SchoolID"] + " and intid=" + lbl.Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                        chk.Checked = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        Label lbl = (Label)ditem.FindControl("lblid");
                        if (chk.Checked == true)
                        {
                            int index = ditem.ItemIndex;
                            DataAccess da = new DataAccess();
                            string sql = "update tblgallery set intpublished=1 where intschool=" + Session["SchoolID"] + " and intid=" + lbl.Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                        chk.Checked = false;
                    }
                }
            }
            if (checktrue == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Published selected item successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Please select items to Proceed')", true);
            }
        }
        catch { }
    }
    protected void btndeleteall_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        Label lbl = (Label)ditem.FindControl("lblid");
                        if (chk.Checked == true)
                        {
                            int index = ditem.ItemIndex;
                            DataAccess da = new DataAccess();
                            string sql = "delete tblgallery where intschool=" + Session["SchoolID"] + " and intid=" + lbl.Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        Label lbl = (Label)ditem.FindControl("lblid");
                        if (chk.Checked == true)
                        {
                            int index = ditem.ItemIndex;
                            DataAccess da = new DataAccess();
                            string sql = "delete tblgallery where intschool=" + Session["SchoolID"] + " and intid=" + lbl.Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                    }
                }
            }
            if (checktrue != 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Please select items to Proceed')", true);
            }
            fillgrid();
        }
        catch { }
    }
    protected void btnunpublished_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        Label lbl = (Label)ditem.FindControl("lblid");
                        if (chk.Checked == true)
                        {
                            DataAccess da = new DataAccess();
                            string sql = "update tblgallery set intpublished=0 where intschool=" + Session["SchoolID"] + " and intid=" + lbl.Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                        chk.Checked = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    DataList dl = (DataList)item.FindControl("dlimage");
                    for (int j = 0; j < dl.Items.Count; j++)
                    {
                        DataListItem ditem = dl.Items[j];
                        CheckBox chk = (CheckBox)ditem.FindControl("checkimage");
                        Label lbl = (Label)ditem.FindControl("lblid");
                        if (chk.Checked == true)
                        {
                            DataAccess da = new DataAccess();
                            string sql = "update tblgallery set intpublished=0 where intschool=" + Session["SchoolID"] + " and intid=" + lbl.Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                        chk.Checked = false;
                    }
                }
            }
            if (checktrue == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('unpublished selected item successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Please select items to Proceed')", true);
            }
        }
        catch { }
    }
    protected void dlimage_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblname = (Label)e.Item.FindControl("lblname");
            TextBox txtname = (TextBox)e.Item.FindControl("txtname");
            Label lbldes = (Label)e.Item.FindControl("lbldescription");
            TextBox txtdes = (TextBox)e.Item.FindControl("txtdescription");
            ImageButton imageedit = (ImageButton)e.Item.FindControl("imageedit");
            Label lblid = (Label)e.Item.FindControl("lblid");
            ASPNetFlashVideo.FlashVideo flsvideo = (ASPNetFlashVideo.FlashVideo)e.Item.FindControl("FlashVideo1");
            Label lblvideoname = (Label)e.Item.FindControl("lblvideoname");
            HtmlImage image12 = (HtmlImage)e.Item.FindControl("Image1");
            Label id = (Label)e.Item.FindControl("id");
            Label thumb = (Label)e.Item.FindControl("Label1");
            HtmlAnchor a = (HtmlAnchor)e.Item.FindControl("imageLink");
            try
            {
                image12.Src = "galleryimage/Thumbimage/" + thumb.Text;
                a.HRef = "galleryimage/orgimage/" + id.Text;
                flsvideo.VideoURL = "galleryvideo/orgvideo/" + lblvideoname.Text;
            }
            catch { }
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select * from tblgallery where intschool=" + Session["SchoolID"] + " and intid=" + lblid.Text + " and intedit=0 order by intid desc";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (lblname.Text == "")
                {
                    txtname.Visible = true;
                    lblname.Visible = false;
                }
                else
                {
                    txtname.Visible = false;
                    lblname.Visible = true;
                }
                if (lbldes.Text == "")
                {
                    txtdes.Visible = true;
                    lbldes.Visible = false;
                }
                else
                {
                    txtdes.Visible = false;
                    lbldes.Visible = true;
                }
            }
            else
            {
                txtdes.Visible = false;
                txtname.Visible = false;
            }
        }
    }
    protected void imageedit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton image = (ImageButton)sender;
            DataListItem ditem = image.Parent as DataListItem;
            Label lblname = (Label)ditem.FindControl("lblname");
            TextBox txtname = (TextBox)ditem.FindControl("txtname");
            Label lbldes = (Label)ditem.FindControl("lbldescription");
            TextBox txtdes = (TextBox)ditem.FindControl("txtdescription");
            ImageButton imageedit = (ImageButton)ditem.FindControl("imageedit");
            Label lblid = (Label)ditem.FindControl("lblid");
            if (imageedit.ImageUrl != "~/media/images/Update.gif")
            {
                txtname.Visible = true;
                lblname.Visible = false;
                if (lblname.Text != "")
                    txtname.Text = lblname.Text;
                txtdes.Visible = true;
                lbldes.Visible = false;
                if (lbldes.Text != "")
                    txtdes.Text = lbldes.Text;

                imageedit.ImageUrl = "~/media/images/Update.gif";
                imageedit.ToolTip = "Edit name and description";
            }
            else
            {
                if (txtname.Text != "")
                    lblname.Text = txtname.Text;
                txtname.Visible = false;
                lblname.Visible = true;

                if (txtdes.Text != "")
                    lbldes.Text = txtdes.Text;
                txtdes.Visible = false;
                lbldes.Visible = true;
                DataAccess da = new DataAccess();
                string sql = "update tblgallery set strname='" + txtname.Text + "',strdescription='" + txtdes.Text + "' where intschool=" + Session["SchoolID"] + " and intid=" + lblid.Text;
                Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lblid.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                da.ExceuteSqlQuery(sql);

                imageedit.ImageUrl = "~/media/images/edit.gif";
                imageedit.ToolTip = "Update name and description";
            }
        }
        catch { }
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
    protected void btnrename_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    Label lblrename = (Label)item.FindControl("lblrename");
                    TextBox txtrename = (TextBox)item.FindControl("txtrename");
                    Button btnrename = (Button)item.FindControl("btnrename");
                    Button btncancel = (Button)item.FindControl("btncancel");
                    if (btnrename.Text != "Rename")
                    {
                        DataAccess da = new DataAccess();
                        DataSet ds = new DataSet();
                        string sql = "select * from tblgallerygroups where strgroups='" + txtrename.Text + "'  and intschool=" + Session["SchoolID"];
                        ds = da.ExceuteSql(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Already Exist!')", true);
                        }
                        else
                        {
                            string sql1 = "update tblgallerygroups set strgroups='" + txtrename.Text + "' where intschool=" + Session["SchoolID"] + " and intid=" + item.Cells[0].Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallerygroups", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql1);
                            txtrename.Visible = false;
                        }
                        fillgrid();
                    }
                    else
                    {
                        btnrename.Text = "Save";
                        btncancel.Text = "Cancel";
                        txtrename.Visible = true;
                        lblrename.Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    Label lblrename = (Label)item.FindControl("lblrename");
                    TextBox txtrename = (TextBox)item.FindControl("txtrename");
                    Button btnrename = (Button)item.FindControl("btnrename");
                    Button btncancel = (Button)item.FindControl("btncancel");
                    if (btnrename.Text != "Rename")
                    {
                        DataAccess da = new DataAccess();
                        DataSet ds = new DataSet();
                        string sql = "select * from tblgallerygroups where strgroups='" + txtrename.Text + "'  and intschool=" + Session["SchoolID"];
                        ds = da.ExceuteSql(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Already Exist!')", true);
                        }
                        else
                        {
                            string sql1 = "update tblgallerygroups set strgroups='" + txtrename.Text + "' where intschool=" + Session["SchoolID"] + " and intid=" + item.Cells[0].Text;
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallerygroups", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
                            da.ExceuteSqlQuery(sql1);
                            txtrename.Visible = false;
                        }
                        fillgrid();
                    }
                    else
                    {
                        btnrename.Text = "Save";
                        btncancel.Text = "Cancel";
                        txtrename.Visible = true;
                        lblrename.Visible = false;
                    }
                }
            }
        }
        catch { }
    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        try
        {
            if (radiophoto.Checked == true)
            {
                for (int i = 0; i < grdimagegallery.Items.Count; i++)
                {
                    DataGridItem item = grdimagegallery.Items[i];
                    Label lblrename = (Label)item.FindControl("lblrename");
                    TextBox txtrename = (TextBox)item.FindControl("txtrename");
                    Button btnrename = (Button)item.FindControl("btnrename");
                    Button btncancel = (Button)item.FindControl("btncancel");
                    if (btncancel.Text != "Delete")
                    {
                        btnrename.Text = "Rename";
                        txtrename.Visible = false;
                        lblrename.Visible = true;
                        btncancel.Text = "Delete";
                    }
                    else
                    {
                        DataAccess da = new DataAccess();
                        DataSet ds = new DataSet();
                        string sql = "select * from tblgallery where intgroups=" + item.Cells[0].Text + " and intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolID"];
                        ds = da.ExceuteSql(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Delete items First!')", true);
                        }
                        else
                        {
                            string str = "select intid from tblgallery where intgroups=" + item.Cells[0].Text + " and intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolID"];
                            ds = da.ExceuteSql(str);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 318);
                                }
                            }
                            str = "delete tblgallery where intgroups=" + item.Cells[0].Text + " and intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolID"];
                            da.ExceuteSqlQuery(str);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdvideogallery.Items.Count; i++)
                {
                    DataGridItem item = grdvideogallery.Items[i];
                    Label lblrename = (Label)item.FindControl("lblrename");
                    TextBox txtrename = (TextBox)item.FindControl("txtrename");
                    Button btnrename = (Button)item.FindControl("btnrename");
                    Button btncancel = (Button)item.FindControl("btncancel");
                    if (btncancel.Text != "Delete")
                    {
                        btnrename.Text = "Rename";
                        txtrename.Visible = false;
                        lblrename.Visible = true;
                        btncancel.Text = "Delete";
                    }
                    else
                    {
                        DataAccess da = new DataAccess();
                        DataSet ds = new DataSet();
                        string sql = "select * from tblgallery where intgroups=" + item.Cells[0].Text + " and intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolID"];
                        ds = da.ExceuteSql(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Delete items First!')", true);
                        }
                        else
                        {
                            string str = "select intid from tblgallery where intgroups=" + item.Cells[0].Text + " and intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolID"];
                            ds = da.ExceuteSql(str);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 318);
                                }
                            }
                            str = "delete tblgallery where intgroups=" + item.Cells[0].Text + " and intacademicyear=" + drpacademicyear.SelectedValue + " and intschool=" + Session["SchoolID"];
                            da.ExceuteSqlQuery(str);
                        }
                    }
                }
            }
        }
        catch { }
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
            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lblid.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),318);
            da.ExceuteSqlQuery(sql);
            fillgrid();
        }
        catch { }
    }
    protected void drpstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
