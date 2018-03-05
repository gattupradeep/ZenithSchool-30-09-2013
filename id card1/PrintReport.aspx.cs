using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.IO;

public partial class id_card_PrintReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["hid1"] != null)
            {
                GenerateJpeg();

            }
            if (Request["hid"] != null)
            {
                GenerateJpeg1();
            }
        }
       
    }
    protected void GenerateJpeg()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;

        str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,a.strstudentbirthcertificateno as studentbirth,";
        str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
        str += " where b.intactive=1 and a.intschool=" + Session["SchoolID"].ToString();
        if (Request["hid1"] != null)
        {
            str += " and a.intid=" + Request["hid1"].ToString();
        }
        ds = da.ExceuteSql(str);
        
        
        Bitmap oBitmap = new Bitmap(420, 400);
        Graphics oGraphic = Graphics.FromImage(oBitmap);
       
        Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
        Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + ds.Tables[0].Rows[0]["intid"].ToString() + ".jpg");
       
        String sname = ds.Tables[0].Rows[0]["name"].ToString();
        String sstandard = ds.Tables[0].Rows[0]["standard"].ToString();
        String sadmin = ds.Tables[0].Rows[0]["intadmitno"].ToString();
        String svalidity = ds.Tables[0].Rows[0]["year"].ToString() + " to " + ds.Tables[0].Rows[0]["year"].ToString();
        String sprinciplesign = Label8.Text;
        String sline = lblline.Text;
        String sreg = lblreg.Text;
        String sstudent = lblstudent.Text;
        
        String sFont = "10px";
        Color oColor = Color.FromName("Green");
        SolidBrush oBrush = new SolidBrush(oColor);
        SolidBrush oBrushwrite = new SolidBrush(Color.White);
        oGraphic.FillRectangle(oBrush, 0, 0, 420, 400);
        Font oFont = new Font(sFont, 10);
        PointF oPoint1 = new PointF(5f, 200f);
        PointF oPoint3 = new PointF(8f, 230f);
        PointF oPoint5 = new PointF(310f, 200f);
        PointF oPoint9 = new PointF(10f, 270f);
        PointF oPoint13 = new PointF(320f, 60f);
        PointF oPoint11 = new PointF(260f, 250f);
        PointF oPoint12 = new PointF(290f, 290f);

        oGraphic.DrawString(sname, oFont, oBrushwrite, oPoint1);
        oGraphic.DrawString(sstandard, oFont, oBrushwrite, oPoint3);
        oGraphic.DrawString(sadmin, oFont, oBrushwrite, oPoint5);
        oGraphic.DrawString(svalidity, oFont, oBrushwrite, oPoint9);
        oGraphic.DrawImage(oBitmap2, 10, 90, 100f, 100f);
        oGraphic.DrawString(sline, oFont, oBrushwrite, oPoint11);
        oGraphic.DrawString(sreg, oFont, oBrushwrite, oPoint12);
        oGraphic.DrawString(sstudent, oFont, oBrushwrite, oPoint13);
        oGraphic.DrawImage(oBitmap1, 300, 90, 100f, 100f);

        //oBitmap.Save(Server.MapPath(@"~\id card\card\generated_image.jpg"), ImageFormat.Jpeg);
        //Response.ContentType = "image/jpg";
        //oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
        //Response.Redirect("card\\generated_image.jpg?id=1");
        oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "id card1\\card\\" + ds.Tables[0].Rows[0]["name"].ToString() + "_" + ds.Tables[0].Rows[0]["standard"].ToString() + ".jpg", ImageFormat.Jpeg);
        Response.ContentType = "image/jpeg";
        Response.AddHeader("content-disposition", "attachment;filename=" + ds.Tables[0].Rows[0]["name"].ToString() + ".jpg");
        oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
        Response.End();
    }
    protected void GenerateJpeg1()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
        str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
        str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();

        if (Request["hid"] != null)
        {
            str += " and a.intid=" + Request["hid"].ToString();
        }
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Bitmap oBitmap = new Bitmap(420, 400);
                Graphics oGraphic = Graphics.FromImage(oBitmap);
                Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
                Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + ds.Tables[0].Rows[0]["intid"].ToString() + ".jpg");

                String sintid = ds.Tables[0].Rows[i]["intid"].ToString();
                String sname = ds.Tables[0].Rows[i]["name"].ToString();
                String sstandard = ds.Tables[0].Rows[i]["standard"].ToString();
                String sadmin = ds.Tables[0].Rows[i]["intadmitno"].ToString();
                String svalidity = ds.Tables[0].Rows[i]["year"].ToString() + " to " + ds.Tables[0].Rows[i]["year"].ToString();
                String sFont = "10px";
                Color oColor = Color.FromName("Green");
                SolidBrush oBrush = new SolidBrush(oColor);
                SolidBrush oBrushwrite = new SolidBrush(Color.White);
                oGraphic.FillRectangle(oBrush, 0, 0, 420, 400);
                Font oFont = new Font(sFont, 10);
                PointF oPoint1 = new PointF(5f, 200f);
                PointF oPoint3 = new PointF(8f, 230f);
                PointF oPoint5 = new PointF(310f, 200f);
                PointF oPoint9 = new PointF(10f, 270f);
                PointF oPoint11 = new PointF(260f, 250f);
                PointF oPoint12 = new PointF(290f, 290f);

                oGraphic.DrawString(sname, oFont, oBrushwrite, oPoint1);
                oGraphic.DrawString(sstandard, oFont, oBrushwrite, oPoint3);
                oGraphic.DrawString(sadmin, oFont, oBrushwrite, oPoint5);
                oGraphic.DrawString(svalidity, oFont, oBrushwrite, oPoint9);
                oGraphic.DrawImage(oBitmap2, 10, 90, 100f, 100f);
                oGraphic.DrawImage(oBitmap1, 300, 90, 100f, 100f);
                oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "id card1\\card\\" + ds.Tables[0].Rows[0]["name"].ToString() + "_" + ds.Tables[0].Rows[0]["standard"].ToString() + ".jpg", ImageFormat.Jpeg);
                Response.ContentType = "image/jpeg";
                Response.AddHeader("content-disposition", "attachment;filename=" + ds.Tables[0].Rows[0]["name"].ToString() + ".jpg");
                oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
                //Response.End();

            }

        }

    }



}
