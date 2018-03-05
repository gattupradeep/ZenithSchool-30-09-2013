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
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public partial class gallery_gallery : System.Web.UI.Page
{
    string sql;
    public DataSet ds;
    public DataAccess da;
    string postedfile;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    int checktrue = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpacademicyear.Focus();
            radiophoto.Checked = true;
            clear();
            updateedit();
            fillgrid();
            Radiovideo.Visible = false;
        }
        grdmenu();
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
        catch
        { }
    }
    protected void updateedit()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "update tblgallery set intedit=1 where intschool=" + Session["SchoolID"];
            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", Session["SchoolID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);
            da.ExceuteSqlQuery(sql);
        }
        catch { }
        
    }
    protected void grdmenu()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select * from tblgallery where intedit=0 and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                trgrdmenu.Visible = true;
            }
            else
            {
                trgrdmenu.Visible = false;
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
            string str = "select top 1 intYear from tblAcademicYear where intactive=1 and intschool=" + Session["SchoolID"] + " order by intid desc";
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                trtitledrp.Visible = true;
                trtitletxt.Visible = false;
                drptitle.DataTextField = "strgroups";
                drptitle.DataValueField = "intid";
                drptitle.DataSource = ds;
                drptitle.DataBind();
                ListItem li = new ListItem("-ALL-", "0");
                drptitle.Items.Insert(0, li);
            }
            else
            {
                trtitledrp.Visible = false;
                trtitletxt.Visible = true;
            }
        }
        catch { }
    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        trtitletxt.Visible = true;
        trtitledrp.Visible = false;
        trtitlelbl.Visible = false;
        txttitle.Focus();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txttitle.Text != "" || drptitle.SelectedIndex > 0 || lbltitleview.Text != "")
            {
                int ImageName = 1;
                int ActualWidth = 0;
                int ActualHeight = 0;
                string extension = "";
                groups();
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("spgallery", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = command.Parameters.Add("@rc", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    HttpPostedFile userPostedFile = uploadedFiles[i];
                    postedfile = userPostedFile.ToString();
                    extension = System.IO.Path.GetExtension(userPostedFile.FileName).ToLower();
                    if (userPostedFile.ContentLength > 0)
                    {
                        if (btnAdd.Text == "Upload")
                        {
                            command.Parameters.Add("@intid", "0");
                        }
                        else
                        {
                            command.Parameters.Add("@intid", Session["intid"]);
                        }
                        command.Parameters.Add("@intacademicyear", drpacademicyear.SelectedValue);

                        if (trtitletxt.Visible == true)
                        {
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            string sql = "select intid from tblgallerygroups where intschool=" + Session["SchoolID"] + " and strgroups='" + txttitle.Text + "' order by intid desc";
                            ds = da.ExceuteSql(sql);
                            command.Parameters.Add("@intgroups", ds.Tables[0].Rows[0]["intid"].ToString());
                        }
                        else if (drptitle.Visible == true)
                        {
                            command.Parameters.Add("@intgroups", drptitle.SelectedValue);
                        }
                        else
                        {
                            DataAccess da = new DataAccess();
                            DataSet ds = new DataSet();
                            string sql = "select intid from tblgallerygroups where intschool=" + Session["SchoolID"] + " and strgroups='" + lbltitleview.Text + "' order by intid desc";
                            ds = da.ExceuteSql(sql);
                            command.Parameters.Add("@intgroups", ds.Tables[0].Rows[0]["intid"].ToString());
                        }
                        command.Parameters.Add("@intpublished", "0");
                        DataAccess da2 = new DataAccess();
                        DataSet ds2 = new DataSet();
                        string sql2 = "select top 1 intid from tblgallery where intschool=" + Session["SchoolID"] + " order by intid desc";
                        ds2 = da2.ExceuteSql(sql2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            ImageName = int.Parse(ds2.Tables[0].Rows[0]["intid"].ToString()) + 1;
                        }
                        if (radiophoto.Checked == true)
                        {
                            String[] allowedExtensions = { ".jpg", ".gif", ".png", ".jpeg" };
                            for (int j = 0; j < allowedExtensions.Length; j++)
                            {
                                if (extension == allowedExtensions[j])
                                {
                                    //userPostedFile.SaveAs(Server.MapPath("galleryimage/orgimage/" + ImageName + extension));
                                    command.Parameters.Add("@strphotoorvideo", ImageName + extension);
                                    //System.Drawing.Image image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "/gallery/galleryimage/orgimage/" + ImageName + extension);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(userPostedFile.InputStream);
                                    ActualWidth = image.Width;
                                    ActualHeight = image.Height;
                                    if (ActualWidth > 1000)
                                    {
                                        var newWidth = 0;
                                        var newHeight = 0;
                                        if (ActualWidth > 4000)
                                        {
                                             newWidth = (int)(image.Width * 0.3);
                                             newHeight = (int)(image.Height * 0.3);
                                        }
                                        else if (ActualWidth > 3000)
                                        {
                                            newWidth = (int)(image.Width * 0.4);
                                            newHeight = (int)(image.Height * 0.4);
                                        }
                                        else if (ActualWidth > 2000)
                                        {
                                            newWidth = (int)(image.Width * 0.5);
                                            newHeight = (int)(image.Height * 0.5);
                                        }
                                        else
                                        {
                                            newWidth = (int)(image.Width * 0.8);
                                            newHeight = (int)(image.Height * 0.8);
                                        }
                                        var thumbnailImage = new Bitmap(newWidth, newHeight);
                                        var thumbGraph = Graphics.FromImage(thumbnailImage);
                                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                                        thumbGraph.DrawImage(image, imageRectangle);
                                        thumbnailImage.Save(Server.MapPath("galleryimage/orgimage/" + ImageName + extension));
                                        thumbnailImage.Save(Server.MapPath("galleryimage/Thumbimage/" + ImageName + "_thumb" + extension));
                                        thumbnailImage.Dispose();
                                        thumbGraph.Dispose();
                                        image.Dispose();
                                    }
                                    else
                                    {
                                        userPostedFile.SaveAs(Server.MapPath("galleryimage/orgimage/" + ImageName + extension));
                                        var newWidth = (int)(image.Width * 0.2);
                                        var newHeight = (int)(image.Height * 0.2);
                                        var thumbnailImage = new Bitmap(newWidth, newHeight);
                                        var thumbGraph = Graphics.FromImage(thumbnailImage);
                                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                                        thumbGraph.DrawImage(image, imageRectangle);
                                        thumbnailImage.Save(Server.MapPath("galleryimage/Thumbimage/" + ImageName + "_thumb" + extension));
                                        thumbnailImage.Dispose();
                                        thumbGraph.Dispose();
                                        image.Dispose();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (extension != ".flv")
                            {
                                string strFLVFileName = System.IO.Path.GetFileNameWithoutExtension("galleryvideo/orgvideo/" + userPostedFile.FileName) + ".flv";
                                string strArgs = "-i " + Server.MapPath("galleryvideo/orgvideo/" + strFLVFileName) + "  -ar 22050 " + Server.MapPath("galleryvideo/orgvideo/" + strFLVFileName);
                                Process proc = new Process();
                                proc.StartInfo.FileName = Server.MapPath("../ffmpeg-0.5/ffmpeg.exe");
                                proc.StartInfo.Arguments = strArgs;
                                proc.StartInfo.UseShellExecute = false;
                                proc.StartInfo.CreateNoWindow = false;
                                proc.StartInfo.RedirectStandardOutput = false;
                                try
                                {
                                    proc.Start();
                                }
                                catch (Exception ex)
                                {
                                    Response.Write(ex.Message);
                                }
                                proc.WaitForExit();
                                proc.Close();
                            }
                            userPostedFile.SaveAs(Server.MapPath("galleryvideo/orgvideo/" + ImageName + ".flv"));
                            command.Parameters.Add("@strphotoorvideo", ImageName + ".flv");
                        }

                    }
                    command.Parameters.Add("dtuploadeddate", DateTime.Now.ToString("yyyy/MM/dd"));
                    command.Parameters.Add("@intschool", Session["SchoolID"]);
                    if (trtitletxt.Visible == true)
                    {
                        command.Parameters.Add("@strname", txttitle.Text.Trim());
                    }
                    else
                    {
                        command.Parameters.Add("@strname", lbltitleview.Text.Trim());
                    }
                    command.Parameters.Add("@strdescription", "");
                    command.Parameters.Add("@intedit", "0");
                    if (radiophoto.Checked == true)
                    {
                        command.Parameters.Add("@strthumbnail", ImageName + "_thumb" + extension);
                        command.Parameters.Add("@strcategory", "Photos");
                    }
                    else
                    {
                        command.Parameters.Add("@strthumbnail", "-");
                        command.Parameters.Add("@strcategory", "Videos");
                    }
                    command.Parameters.Add("@intwidth", ActualWidth);
                    command.Parameters.Add("@intheight", ActualHeight);
                    command.ExecuteNonQuery();
                    conn.Close();
                    string id = Convert.ToString(param.Value);
                    if (btnAdd.Text == "Upload")
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 316);
                    }
                    else
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 318);
                    }
                }
                lastupload();
                fillgrid();
                grdmenu();
                drpacademicyear.Focus();
            }
            else
            {
                MsgBox1.alert("Please select Image/Video title to Proceed");
            }
        }
        catch { }
    }
    protected void groups()
    {
        try
        {
            if (trtitledrp.Visible != true)
            {
                SqlCommand command;
                SqlParameter outpuparam;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("SPgallerygroups", conn);
                command.CommandType = CommandType.StoredProcedure;
                outpuparam = command.Parameters.Add("@rc", SqlDbType.Int);
                outpuparam.Direction = ParameterDirection.Output;
                if (btnsave.Text == "Save")
                {
                    command.Parameters.Add("@intid", "0");
                }
                else
                {
                    command.Parameters.Add("@intid", Session["intID"].ToString());
                }
                if (trtitletxt.Visible == true)
                {
                    command.Parameters.Add("@strgroups", txttitle.Text.Trim());
                }
                else
                {
                    command.Parameters.Add("@strgroups", lbltitleview.Text.Trim());
                }
                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                if (radiophoto.Checked == true)
                {                                                                                                                                                                                                              
                    command.Parameters.Add("@strcategory", "Photos");
                }
                else
                {
                    command.Parameters.Add("@strcategory", "Videos");
                }
                command.ExecuteNonQuery();
                if ((int)command.Parameters["@rc"].Value == 0)
                {

                }
                conn.Close();
                string id = Convert.ToString(outpuparam.Value);
                if (btnsave.Text == "Save")
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblgallerygroups", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 316);
                }
                else
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblgallerygroups", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 316);
                }
            }
        }
        catch { }
    }
    protected void lastupload()
    {
        try
        {
            trtitledrp.Visible = true;
            filltitle();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select top 1 intgroups from tblgallery where intschool=" + Session["SchoolID"] + " order by intid desc";
            ds = da.ExceuteSql(sql);
            drptitle.SelectedValue = ds.Tables[0].Rows[0]["intgroups"].ToString();
            trtitletxt.Visible = false;
            txttitle.Text = "";
            trtitlelbl.Visible = false;
            lbltitleview.Text = "";
        }
        catch { }
    }
    protected void clear()
    {
        grdmenu();
        fillacademicyear();
        filltitle();
        txttitle.Text = "";
        trtitlelbl.Visible = false;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
        fillgrid();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txttitle.Text != "")
            {

                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string sql = "select b.strgroups from tblgallery a,tblgallerygroups b where a.intschool=b.intschool and b.strgroups ='" + txttitle.Text + "' and";
                sql += " a.intgroups=b.intid and a.intacademicyear=" + drpacademicyear.SelectedValue + " and a.intschool=" + Session["SchoolID"];
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('The entered Image title already exist!')", true);
                    txttitle.Text = "";
                    txttitle.Focus();
                }
                else
                {
                    trtitletxt.Visible = false;
                    trtitlelbl.Visible = true;
                    lbltitleview.Text = txttitle.Text;
                    trtitledrp.Visible = false;
                    btnedit.Focus();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscripts", "alert('Please enter title to Proceed')", true);
                txttitle.Focus();
            }
        }
        catch { }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        trtitledrp.Visible = false;
        trtitletxt.Visible = true;
        trtitlelbl.Visible = false;
        txttitle.Focus();
    }
    protected void drpacademicyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radiophoto.Checked == true)
        {
            try
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string sql = "select * from tblgallery where intacademicyear=" + drpacademicyear.SelectedValue + " and strcategory='Photos' and intschool=" + Session["SchoolId"];
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    trtitledrp.Visible = true;
                    filltitle();
                    trtitletxt.Visible = false;
                    trtitlelbl.Visible = false;
                    txttitle.Text = "";
                    drptitle.Focus();
                }
                else
                {
                    trtitledrp.Visible = false;
                    trtitletxt.Visible = true;
                    trtitlelbl.Visible = false;
                }
                fillgrid();
            }
            catch { }
        }
        else
        {
            try
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string sql = "select * from tblgallery where intacademicyear=" + drpacademicyear.SelectedValue + " and strcategory='Videos' and intschool=" + Session["SchoolId"];
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    trtitledrp.Visible = true;
                    filltitle();
                    trtitletxt.Visible = false;
                    trtitlelbl.Visible = false;
                    txttitle.Text = "";
                    drptitle.Focus();
                }
                else
                {
                    trtitledrp.Visible = false;
                    trtitletxt.Visible = true;
                    trtitlelbl.Visible = false;
                }
                fillgrid();
            }
            catch { }
        }
    }
    protected void drptitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        btnaddnew.Focus();
    }
    protected void btncanceladd_Click(object sender, EventArgs e)
    {
        filltitle();
        txttitle.Text = "";
        trtitlelbl.Visible = false;
        drptitle.Focus();
    }
    protected void grdimagegallery_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataList dlimage = (DataList)e.Item.FindControl("dlimage");
            sql = "select * from tblgallery where intschool=" + Session["SchoolID"];
            if (drpacademicyear.SelectedIndex > 0)
            {
                sql += " and intacademicyear=" + drpacademicyear.SelectedValue;
            }
            if (radiophoto.Checked == true)
            {
                sql += " and strcategory='Photos'";
            }
            else
            {
                sql += " and strcategory='Videos'";
            }
            sql += "  and intgroups =" + dr["intid"] + " order by intid desc";
            ds = new DataSet();
            da = new DataAccess();
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
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);

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
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 316);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Please select item to Proceed')", true);
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
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);

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
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);

                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                    }
                }
            }
            if (checktrue != 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Please select Item to Proceed')", true);
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
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);

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
                            Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lbl.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);

                            da.ExceuteSqlQuery(sql);
                            checktrue = 1;
                        }
                        chk.Checked = false;
                    }
                }
            }
            if (checktrue == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Unpublished selected item successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientscripts", "alert('Please select item to Proceed')", true);
            }
        }
        catch { }
    }
    protected void dlimage_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblname = (Label)e.Item.FindControl("lblname");
                TextBox txtname = (TextBox)e.Item.FindControl("txtname");
                Label lbldes = (Label)e.Item.FindControl("lbldescription");
                TextBox txtdes = (TextBox)e.Item.FindControl("txtdescription");
                ImageButton imageedit = (ImageButton)e.Item.FindControl("imageedit");
                Label lblid = (Label)e.Item.FindControl("lblid");
                CheckBox chkimage = (CheckBox)e.Item.FindControl("checkimage");
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
                string sql = "select * from tblgallery where intschool=" + Session["SchoolID"];
                sql += " and intid=" + lblid.Text + "";
                if (radiophoto.Checked == true)
                {
                    sql += " and strcategory='Photos'";
                }
                else
                {
                    sql += " and strcategory='Videos'";
                }
                sql += " and intedit=0 order by intid desc";
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (radiophoto.Checked == true)
                    {
                        //HtmlInputButton tag = (HtmlInputButton)e.Item.FindControl("tag");
                        //HtmlInputButton crop = (HtmlInputButton)e.Item.FindControl("crop");
                        HtmlControl crop = (HtmlControl)e.Item.FindControl("crop");
                        //Button crop = (Button)e.Item.FindControl("crop");
                        //tag.Visible = true;
                        crop.Visible = true;
                    }
                    chkimage.Visible = true;
                    imageedit.Visible = true;
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
                    if (radiophoto.Checked == true)
                    {
                        //HtmlInputButton tag = (HtmlInputButton)e.Item.FindControl("tag");
                       // HtmlInputButton crop = (HtmlInputButton)e.Item.FindControl("crop");
                        //Button crop = (Button)e.Item.FindControl("crop");
                        HtmlControl crop = (HtmlControl)e.Item.FindControl("crop");
                        //tag.Visible = false;
                        crop.Visible = false;
                    }
                    chkimage.Visible = false;
                    imageedit.Visible = false;
                    txtdes.Visible = false;
                    txtname.Visible = false;
                }
                if (lblname.Text != "" && lbldes.Text != "")
                {
                    imageedit.ImageUrl = "~/media/images/edit.gif";
                    imageedit.ToolTip = "Edit name and description";
                }
                else
                {
                    imageedit.ImageUrl = "~/media/images/Update.gif";
                    imageedit.ToolTip = "Update name and description";
                }
            }
        }
        catch { }
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
                Functions.UserLogs(Session["UserID"].ToString(), "tblgallery", lblid.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),316);

                da.ExceuteSqlQuery(sql);

                imageedit.ImageUrl = "~/media/images/edit.gif";
                imageedit.ToolTip = "Update name and description";
            }
        }
        catch { }
    }
    protected void radiophoto_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            Radiovideo.Checked = false;
            filltitle();
            lbltitle.Text = "Image Title";
            lbltitle1.Text = "Image Title";
            lbltitle2.Text = "Image Title";
            lblselectimage.Text = "Selected Image";
            fillgrid();
        }
        catch { }
    }
    protected void Radiovideo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            radiophoto.Checked = false;
            filltitle();
            lbltitle.Text = "Video Title";
            lbltitle1.Text = "Video Title";
            lbltitle2.Text = "Video Title";
            lblselectimage.Text = "Selected Video";
            fillgrid();
        }
        catch { }
    }
}
