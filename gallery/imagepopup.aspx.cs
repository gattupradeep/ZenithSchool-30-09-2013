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
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class gallery_imagepopup : System.Web.UI.Page
{
    public DataSet ds;
    public DataAccess da;
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    string id = "";
    string ImageName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgallery();
        }
    }
    String path = HttpContext.Current.Request.PhysicalApplicationPath + "gallery\\galleryimage\\orgimage\\";
    String paththumb = HttpContext.Current.Request.PhysicalApplicationPath + "gallery\\galleryimage\\Thumbimage\\";
    protected void fillgallery()
    {
        try
        {
            fillvisible();
            if (lblnextback.Text == "")
            {
                lblnextback.Text = id;
            }
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "SELECT *, ROW_NUMBER() OVER (ORDER BY intid DESC) AS ROWID FROM tblgallery  where intschool=" + Session["SchoolID"] + " and intid=" + lblnextback.Text;
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                image.Src = "~/gallery/galleryimage/orgimage/" + ds.Tables[0].Rows[0]["strphotoorvideo"].ToString();
                image.Alt = "~/gallery/galleryimage/orgimage/" + ds.Tables[0].Rows[0]["strphotoorvideo"].ToString();
                lblname.Text = ds.Tables[0].Rows[0]["strname"].ToString();
                lbldescription.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();
                Session["imagerowid"] = ds.Tables[0].Rows[0]["ROWID"].ToString();
            }
        }
        catch { }
    }
    protected void fillvisible()
    {
        try
        {
            if (Request["imgid"] != null)
            {
                id = Request["imgid"];
                trtagcropchange.Visible = false;
            }
            else
            {
                trtagcropchange.Visible = true;
            }
            if (Request["cropid"] != null)
            {
                id = Request["cropid"];
                btntag.Visible = false;
                btncrop.Visible = true;
                btnchange.Visible = false;
            }
            if (Request["tagid"] != null)
            {
                id = Request["tagid"];
                btntag.Visible = true;
                btncrop.Visible = false;
                btnchange.Visible = false;
            }
            if (Request["changeid"] != null)
            {
                id = Request["changeid"];
                btntag.Visible = false;
                btncrop.Visible = false;
                btnchange.Visible = true;
                trupload.Visible = false;
            }
        }
        catch { }
    }
    protected void btncrop_Click(object sender, EventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select strphotoorvideo,strthumbnail from tblgallery where intid=" + lblnextback.Text + " and strcategory='Photos' and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            ImageName = ds.Tables[0].Rows[0]["strphotoorvideo"].ToString();
            string thumbimage = ds.Tables[0].Rows[0]["strthumbnail"].ToString();
            if (W.Value != "" && H.Value != "" && X.Value != "" && Y.Value != "")
            {
                int w = Convert.ToInt32(W.Value);
                int h = Convert.ToInt32(H.Value);
                int x = Convert.ToInt32(X.Value);
                int y = Convert.ToInt32(Y.Value);
                byte[] CropImage = Crop(path + ImageName, w, h, x, y);
                using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
                {
                    ms.Write(CropImage, 0, CropImage.Length);
                    using (System.Drawing.Image CroppedImage = System.Drawing.Image.FromStream(ms, true))
                    {
                        CroppedImage.Save(path + ImageName, CroppedImage.RawFormat);
                        image.Src = "~/gallery/galleryimage/orgimage/" + ds.Tables[0].Rows[0]["strphotoorvideo"].ToString();
                        System.Drawing.Image croppedimage = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "/gallery/galleryimage/orgimage/" + ImageName);
                        var newWidth = (int)(croppedimage.Width * 0.2);
                        var newHeight = (int)(croppedimage.Height * 0.2);
                        var thumbnailImage = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbnailImage);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(croppedimage, imageRectangle);
                        thumbnailImage.Save(Server.MapPath("galleryimage/Thumbimage/" + thumbimage));
                        thumbnailImage.Dispose();
                        thumbGraph.Dispose();
                        image.Dispose();
                    }
                }
            }
        }
        catch { }
    }
    static byte[] Crop(string Img, int Width, int Height, int X, int Y)
    {
        try
        {
            using (System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(Img))
            {
                using (Bitmap bmp = new Bitmap(Width, Height))
                {
                    bmp.SetResolution(OriginalImage.HorizontalResolution,
                    OriginalImage.VerticalResolution);
                    using (Graphics Graphic = Graphics.FromImage(bmp))
                    {
                        Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Graphic.DrawImage(OriginalImage, new Rectangle(0, 0, Width, Height), X, Y, Width, Height, GraphicsUnit.Pixel);
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, OriginalImage.RawFormat);
                        return ms.GetBuffer();
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            throw (Ex);
        }
    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        trupload.Visible = true;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string sql = "select strphotoorvideo,strthumbnail from tblgallery where intid=" + lblnextback.Text + " and strcategory='Photos' and intschool=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            ImageName = ds.Tables[0].Rows[0]["strphotoorvideo"].ToString();
            string[] name = ImageName.Split(".".ToCharArray());
            string newname = name[0];
            string thumbimage = ds.Tables[0].Rows[0]["strthumbnail"].ToString();
            HttpFileCollection uploadedFiles = Request.Files;
            HttpPostedFile userPostedFile = uploadedFiles[0];
            string postedfile = userPostedFile.ToString();
            if (userPostedFile.ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(userPostedFile.FileName).ToLower();
                String[] allowedExtensions = { ".jpg", ".gif", ".png", ".jpeg" };
                for (int j = 0; j < allowedExtensions.Length; j++)
                {
                    if (extension == allowedExtensions[j])
                    {
                        File.Delete(Server.MapPath("~/gallery/galleryimage/orgimage/" + ImageName));
                        //userPostedFile.SaveAs(Server.MapPath("~/gallery/galleryimage/orgimage/" + newname + extension));
                        //System.Drawing.Image image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "/gallery/galleryimage/orgimage/" + newname + extension);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(userPostedFile.InputStream);
                        int ActualWidth = image.Width;
                        int ActualHeight = image.Height;

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
                            thumbnailImage.Save(Server.MapPath("galleryimage/orgimage/" + newname + extension));
                            File.Delete(Server.MapPath("~/gallery/galleryimage/Thumbimage/" + thumbimage));
                            thumbnailImage.Save(Server.MapPath("~/gallery/galleryimage/Thumbimage/" + newname + "_thumb" + extension));
                            thumbnailImage.Dispose();
                            thumbGraph.Dispose();
                            image.Dispose();
                        }
                        else
                        {
                            int newWidth = (int)(image.Width * 0.5);
                            int newHeight = (int)(image.Height * 0.5);
                            var thumbnailImage = new Bitmap(newWidth, newHeight);
                            var thumbGraph = Graphics.FromImage(thumbnailImage);
                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            thumbGraph.DrawImage(image, imageRectangle);
                            userPostedFile.SaveAs(Server.MapPath("~/gallery/galleryimage/orgimage/" + newname + extension));
                            File.Delete(Server.MapPath("~/gallery/galleryimage/Thumbimage/" + thumbimage));
                            thumbnailImage.Save(Server.MapPath("~/gallery/galleryimage/Thumbimage/" + newname + "_thumb" + extension));
                            thumbnailImage.Dispose();
                            thumbGraph.Dispose();
                            image.Dispose();
                        }
                        string str = "update tblgallery set strphotoorvideo='" + newname + extension + "',";
                        str += " strthumbnail='" + newname + "_thumb" + extension + "' , intwidth=" + ActualWidth + " ,intedit=1,";
                        str += " intheight=" + ActualHeight + " where intschool=" + Session["SchoolID"] + " and intid=" + lblnextback.Text;
                        da.ExceuteSqlQuery(str);
                        ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href ='" + Request["page"].ToString() + "'; </script>");
                    }
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"Clientsripts","alert('Please select image to Proceed')",true);
            }
        }
        catch { }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href ='" + Request["page"].ToString() + "'; </script>");
    }
}
