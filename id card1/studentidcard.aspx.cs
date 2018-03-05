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

public partial class id_card_studentidcard : System.Web.UI.Page
{
    public string strsql, strMsg;
    public DataAccess da, da1, da2, da3;
    public DataSet ds, ds1, ds2, ds3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            fillstandard();
            trimage1.Visible = false;
            //trtext.Visible = false;
            trback.Visible = false;
            trfont.Visible = false;
            trgenerate.Visible = false;
        }
     }

   
    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strstandard from tblstudent where intschool="+Session["Schoolid"].ToString()+" group by strstandard";
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
    }
    protected void fillstudent()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and intschool="+Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "--Select--");
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select intid,strfirstname+''+strmiddlename+''+strlastname as name,strstandard+' - '+strsection as standard,intadmitno from tblstudent where intid=" + ddlstudent.SelectedValue + " and strstandard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["standard"].ToString();
            lbladmin.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
        }
    }
    protected void year()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = " select Datename(yy,StartDate) as year, Datename(yy,EndDate) as year1 from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvalidity.Text = ds.Tables[0].Rows[0]["year"].ToString() + " to " + ds.Tables[0].Rows[0]["year1"].ToString();
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
       
    }

    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        trimage1.Visible = true;
        fillgrid();
        year();

    }
     
    protected void fillgenerate1()
    {
        Bitmap oBitmap = new Bitmap(420, 400);
        Graphics oGraphic = Graphics.FromImage(oBitmap);
        String scolor = BackgroundColor.SelectedValue;
        Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
        Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid.Text + ".jpg");

        String slabel1 = Label7.Text; 
        String sname = lblname.Text;
        String slabel2 = Label9.Text;
        String sstandard = lblstandard.Text;
        String slabel3 = Label10.Text;
        String sadmin = lbladmin.Text;
        String slabel4 = Label11.Text;
        String scardno = lblno.Text;
        String slabel5 = Label13.Text;
        String svalidity = lblvalidity.Text;
        String sprinciplesign = Label8.Text;

        String sFont = Font.Text;
        Color oColor = Color.FromName(BackgroundColor.SelectedValue);
        SolidBrush oBrush = new SolidBrush(oColor);
        SolidBrush oBrushwrite = new SolidBrush(Color.White);
        oGraphic.FillRectangle(oBrush, 0, 0, 420, 400);
        Font oFont = new Font(sFont, 10);
     
        PointF oPoint = new PointF(5f, 200f);
        PointF oPoint1 = new PointF(160f, 200f);
        PointF oPoint2 = new PointF(8f, 230f);
        PointF oPoint3 = new PointF(160f, 230f);
        PointF oPoint4 = new PointF(11f, 260f);
        PointF oPoint5 = new PointF(160f, 260f);
        PointF oPoint6 = new PointF(12f, 290f);
        PointF oPoint7 = new PointF(160f, 290f);
        PointF oPoint8 = new PointF(15f, 320f);
        PointF oPoint9 = new PointF(160f, 320f);
        PointF oPoint10 = new PointF(310f, 350f);

        oGraphic.DrawString(slabel1, oFont, oBrushwrite, oPoint);
        oGraphic.DrawString(sname, oFont, oBrushwrite, oPoint1);
        oGraphic.DrawString(slabel2, oFont, oBrushwrite, oPoint2);
        oGraphic.DrawString(sstandard, oFont, oBrushwrite, oPoint3);
        oGraphic.DrawString(slabel3, oFont, oBrushwrite, oPoint4);
        oGraphic.DrawString(sadmin, oFont, oBrushwrite, oPoint5);
        oGraphic.DrawString(slabel4, oFont, oBrushwrite, oPoint6);
        oGraphic.DrawString(scardno, oFont, oBrushwrite, oPoint7);
        oGraphic.DrawString(slabel5, oFont, oBrushwrite, oPoint8);
        oGraphic.DrawString(svalidity, oFont, oBrushwrite, oPoint9);
        oGraphic.DrawString(sprinciplesign, oFont, oBrushwrite, oPoint10);
        oGraphic.DrawImage(oBitmap2,150,10,100f,100f);
        oGraphic.DrawImage(oBitmap1,310,210,100f, 100f);


        oBitmap.Save(Server.MapPath(@"~\id card\card\generated_image.jpg"), ImageFormat.Jpeg);
        Response.ContentType = "image/jpg";
        oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
        //Response.Redirect("card\\generated_image.jpg?id=1");
    }
   
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (ddlyear.SelectedValue == "1")
        {
        
            fillstandard();
            trimage1.Visible = true;
            //trtext.Visible = true;
            trback.Visible = true;
            trfont.Visible = true;
            trgenerate.Visible = true;
            
           
        }
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        fillgenerate1();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filename = FileUpload1.FileName;
            string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid.Text + ".jpg" );
            
        }
    }
}
