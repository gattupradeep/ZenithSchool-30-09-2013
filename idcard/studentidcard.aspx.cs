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
using System.Drawing.Printing;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;



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
            trgenerate.Visible = false;
            trbackside.Visible = false;
            trstudent.Visible = false;
            trstaff.Visible = false;
        }
    }
    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strstandard+' - '+strsection as standard from tblstudent where intschool=" + Session["Schoolid"].ToString() + " group by strstandard,strsection";
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "standard";
        ddlstandard.DataValueField = "standard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
    }
    protected void fillstudent()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "--Select--");
        ddlstudent.Items.Insert(1, "--All--");
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        if (ddlstudent.SelectedValue == "--All--")
        {
            str = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as standard,intadmitno,strstudentbirthcertificateno from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        }
        else
        {
            str = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as standard,intadmitno,strstudentbirthcertificateno from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString() + " and intid=" + ddlstudent.SelectedValue;
        }
       
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["standard"].ToString();
            lbladmin.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            lblidno.Text = ds.Tables[0].Rows[0]["strstudentbirthcertificateno"].ToString();
        }
    }
    protected void fillgrid1()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as standard,intadmitno from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblid.Text = ds.Tables[0].Rows[i]["intid"].ToString();
                lblname.Text = ds.Tables[0].Rows[i]["name"].ToString();
                lblstandard.Text = ds.Tables[0].Rows[i]["standard"].ToString();
                lbladmin.Text = ds.Tables[0].Rows[i]["intadmitno"].ToString();
            }
        }
    }
    protected void year()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
       // string str = " select Datename(yy,StartDate) as year, Datename(yy,EndDate) as year1  from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
        string str = " select convert(varchar(10),StartDate,103) as startdate,convert(varchar(10),EndDate,103) as enddate from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvalidity.Text = ds.Tables[0].Rows[0]["startdate"].ToString() + " to " + ds.Tables[0].Rows[0]["enddate"].ToString();
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        //trimage1.Visible = true;
        //trgenerate.Visible = true;
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //trimage1.Visible = true;
        //trgenerate.Visible = true;
        fillgrid();
        year();
    }
    protected void fillgenerate1()
    {
            Color FontColor = Color.Silver;
            Color BackColor = Color.Black;
            Bitmap oBitmap = new Bitmap(1223, 1423);
            Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
            Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid.Text + ".jpg");
            Graphics oGraphic = Graphics.FromImage(oBitmap);
            String slabel1 = lblname.Text;
            String slabel2 = lblidnocard.Text;
            String slabel3 = lblidno.Text;
            String slabel4 = lblstandard.Text;
            String slabel5 = Label4.Text;
            String slabel6 = lblvalidity.Text;
            String slabel7 = Label5.Text;
            String slabel8 = lbladmin.Text;
            String slabel9 = Label6.Text;
            String slabel10 = Label7.Text;
            String slabel11 = Label8.Text;
            String slabel12 = Label9.Text;
            String slabel13 = Label10.Text;
            String slabel14 = Label11.Text;
            String slabel15 = Label12.Text;
            String slabel16 = Label13.Text;
            String slabel17 = Label14.Text;
            String slabel18 = Label15.Text;
            String slabel19 = Label16.Text;
            String slabel20 = Label17.Text;
            String slabel21 = Label18.Text;
            String slabel22 = Label19.Text;
            Font oFont = new Font("Arial", 30, FontStyle.Bold);
            Font oFont1 = new Font("Arial", 20, FontStyle.Bold);
            Font oFont2 = new Font("Arial", 20);
            Font oFont3 = new Font("Arial", 20, FontStyle.Bold);
            Font oFont4 = new Font("Arial", 30, FontStyle.Bold);
            Font oFont5 = new Font("Arial", 25);
            Font oFont6 = new Font("Arial", 25);
            SolidBrush oBrush = new SolidBrush(FontColor);
            SolidBrush oBrushwrite = new SolidBrush(BackColor);
            oGraphic.FillRectangle(oBrush, 0, 0, 1223, 1423);
            PointF name = new PointF(170f, 380f);
            PointF idno = new PointF(170f, 430f);
            PointF idcard = new PointF(270f, 430f);
            PointF standard = new PointF(170f, 480f);
            PointF validity = new PointF(150f, 530f);
            PointF year = new PointF(300f, 530f);
            PointF line = new PointF(690f, 530f);
            PointF student = new PointF(770f, 50f);
            PointF admission = new PointF(770f, 450f);
            PointF register = new PointF(770f, 570f);
            PointF point1 = new PointF(350f, 800f);
            PointF point2 = new PointF(300f, 850f);
            PointF point3 = new PointF(170f, 900f);
            PointF point4 = new PointF(210f, 950f);
            PointF point5 = new PointF(90f, 980f);
            PointF point6 = new PointF(150f, 1020f);
            PointF point7 = new PointF(150f, 1050f);
            PointF point8 = new PointF(150f, 1090f);
            PointF point9 = new PointF(150f, 1140f);
            PointF point10 = new PointF(150f, 1190f);
            PointF point11 = new PointF(150f, 1240f);
            PointF point12 = new PointF(150f, 1270f);
            oGraphic.DrawImage(oBitmap1, 200, 100, 190, 250);
            oGraphic.DrawImage(oBitmap2, 720, 120, 270, 320);
            oGraphic.DrawString(slabel1, oFont, oBrushwrite, name);
            oGraphic.DrawString(slabel2, oFont2, oBrushwrite, idno);
            oGraphic.DrawString(slabel3, oFont2, oBrushwrite, idcard);
            oGraphic.DrawString(slabel4, oFont1, oBrushwrite, standard);
            oGraphic.DrawString(slabel5, oFont2, oBrushwrite, validity);
            oGraphic.DrawString(slabel6, oFont2, oBrushwrite, year);
            oGraphic.DrawString(slabel7, oFont, oBrushwrite, student);
            oGraphic.DrawString(slabel8, oFont2, oBrushwrite, admission);
            oGraphic.DrawString(slabel9, oFont1, oBrushwrite, line);
            oGraphic.DrawString(slabel10, oFont1, oBrushwrite, register);
            oGraphic.DrawString(slabel11, oFont5, oBrushwrite, point1);
            oGraphic.DrawString(slabel12, oFont4, oBrushwrite, point2);
            oGraphic.DrawString(slabel13, oFont5, oBrushwrite, point3);
            oGraphic.DrawString(slabel14, oFont5, oBrushwrite, point4);
            oGraphic.DrawString(slabel15, oFont6, oBrushwrite, point5);
            oGraphic.DrawString(slabel16, oFont6, oBrushwrite, point6);
            oGraphic.DrawString(slabel17, oFont6, oBrushwrite, point7);
            oGraphic.DrawString(slabel18, oFont6, oBrushwrite, point8);
            oGraphic.DrawString(slabel19, oFont6, oBrushwrite, point9);
            oGraphic.DrawString(slabel20, oFont6, oBrushwrite, point10);
            oGraphic.DrawString(slabel21, oFont6, oBrushwrite, point11);
            oGraphic.DrawString(slabel22, oFont6, oBrushwrite, point12);
            oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\" + lblname.Text + "_"+lblstandard.Text+".jpg", ImageFormat.Jpeg);
            Response.ContentType = "image/jpeg";
            Response.AddHeader("content-disposition", "attachment;filename=" + lblname.Text + "_" + lblstandard.Text + ".jpg");
            oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg); 
            Response.End();

            //oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\generated_image.jpg", ImageFormat.Jpeg);
            //Response.Write("<script type=\"text/javascript\">window.open(\"card.aspx?id=1\",\"_blank\", \"status=1,toolbar=1\");</script>");
    }
    protected void fillgenerate()
    {
        Color FontColor = Color.Silver;
        Color BackColor = Color.Black;
        Bitmap oBitmap = new Bitmap(511, 571);
        Graphics oGraphic = Graphics.FromImage(oBitmap);
        String slabel1 = Label8.Text;
        String slabel2 = Label9.Text;
        String slabel3 = Label10.Text;
        String slabel4 = Label11.Text;
        String slabel5 = Label12.Text;
        String slabel6 = Label13.Text;
        String slabel7 = Label14.Text;
        String slabel8 = Label15.Text;
        String slabel9 = Label16.Text;
        String slabel10 = Label17.Text;
        String slabel11 = Label18.Text;
        String slabel12 = Label19.Text;
        Font oFont = new Font("Arial", 13, FontStyle.Bold);
        Font oFont1 = new Font("Arial", 10);
        Font oFont2 = new Font("Arial", 10);
        SolidBrush oBrush = new SolidBrush(FontColor);
        SolidBrush oBrushwrite = new SolidBrush(BackColor);
        oGraphic.FillRectangle(oBrush, 0, 0, 511, 571);
        PointF point1 = new PointF(160f, 50f);
        PointF point2 = new PointF(120f, 70f);
        PointF point3 = new PointF(70f, 90f);
        PointF point4 = new PointF(90f, 110f);
        PointF point5 = new PointF(40f, 130f);
        PointF point6 = new PointF(70f, 150f);
        PointF point7 = new PointF(70f, 170f);
        PointF point8 = new PointF(70f, 190f);
        PointF point9 = new PointF(70f, 210f);
        PointF point10 = new PointF(70f, 230f);
        PointF point11 = new PointF(70f, 250f);
        PointF point12 = new PointF(70f, 270f);
        oGraphic.DrawString(slabel1, oFont1, oBrushwrite, point1);
        oGraphic.DrawString(slabel2, oFont, oBrushwrite, point2);
        oGraphic.DrawString(slabel3, oFont1, oBrushwrite, point3);
        oGraphic.DrawString(slabel4, oFont1, oBrushwrite, point4);
        oGraphic.DrawString(slabel5, oFont2, oBrushwrite, point5);
        oGraphic.DrawString(slabel6, oFont2, oBrushwrite, point6);
        oGraphic.DrawString(slabel7, oFont2, oBrushwrite, point7);
        oGraphic.DrawString(slabel8, oFont2, oBrushwrite, point8);
        oGraphic.DrawString(slabel9, oFont2, oBrushwrite, point9);
        oGraphic.DrawString(slabel10, oFont2, oBrushwrite, point10);
        oGraphic.DrawString(slabel11, oFont2, oBrushwrite, point11);
        oGraphic.DrawString(slabel12, oFont2, oBrushwrite, point12);
        oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\generated_image.jpg", ImageFormat.Jpeg);
        Response.Write("<script type=\"text/javascript\">window.open(\"card.aspx?id=1\",\"_blank\", \"status=1,toolbar=1\");</script>");
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue == "1")
        {
           
            trimage1.Visible = true;
            trbackside.Visible = false;
            trgenerate.Visible = true;
        }
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        fillgenerate1();
       // fillgenerate();
        
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != "")
        {
            string filename = FileUpload1.FileName;
            string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid.Text + ".jpg");
           
        }
    }
    protected void ddlpatrontype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            trstaff.Visible = false;
            trstudent.Visible = true;
        }
        else
        {
            trstaff.Visible = true;
            trstudent.Visible = false;
        }
    }
    protected void teachingstaff()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        if (ddlstaff.SelectedValue == "Teaching Staffs")
        {
            str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblemployee where strtype='Teaching Staffs' and intschool=" + Session["Schoolid"].ToString();
            ds = da.ExceuteSql(str);
            ddlstaffname.DataSource = ds;
            ddlstaffname.DataTextField = "name";
            ddlstaffname.DataValueField = "intid";
            ddlstaffname.DataBind();
            ddlstaffname.Items.Insert(0, "--Select--");
            ddlstaffname.Items.Insert(1, "--All--");
        }
        else
        {
            str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblemployee where strtype!='Teaching Staffs' and intschool=" + Session["Schoolid"].ToString();
            ds = da.ExceuteSql(str);
            ddlstaffname.DataSource = ds;
            ddlstaffname.DataTextField = "name";
            ddlstaffname.DataValueField = "intid";
            ddlstaffname.DataBind();
            ddlstaffname.Items.Insert(0, "--Select--");
            ddlstaffname.Items.Insert(1, "--All--");
        }
        
    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstaff.SelectedValue == "Teaching Staffs")
        {
           teachingstaff();
           trimage1.Visible = true;
           trgenerate.Visible = true;
        }
        else
        {
            teachingstaff();
            trimage1.Visible = true;
            trgenerate.Visible = true;
        }
    }
    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        //trimage1.Visible = true;
        //trgenerate.Visible = true;
        fillgrid();
        year();
    }
}
