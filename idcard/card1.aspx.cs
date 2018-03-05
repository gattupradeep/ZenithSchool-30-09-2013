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
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

public partial class id_card_card1 : System.Web.UI.Page
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
    
    protected void year()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        // string str = " select Datename(yy,StartDate) as year, Datename(yy,EndDate) as year1  from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
        string str = " select convert(varchar(10),StartDate,103) as startdate,convert(varchar(10),EndDate,103) as enddate from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
        ds = da.ExceuteSql(str);
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridIDCard.DataSource = ds;
            GridIDCard.DataBind();
        }
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue == "1")
        {
            trimage1.Visible = true;
            
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
       

    }
    protected void fillgrid()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        if (ddlstudent.SelectedValue == "--All--")
        {
            str = "select intid as lblid,intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as standard,intadmitno,strstudentbirthcertificateno from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        }
        else
        {
            str = "select intid as lblid,intid,strfirstname+' '+strmiddlename+' '+strlastname as name,strstandard+' - '+strsection as standard,intadmitno,strstudentbirthcertificateno from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString() + " and intid=" + ddlstudent.SelectedValue;
        }
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridIDCard.DataSource = ds;
            GridIDCard.DataBind();
        }


    }
    protected void GridIDCard_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblid = (Label)e.Item.FindControl("lblid");
            Label lblname = (Label)e.Item.FindControl("lblname");
            Label lblstandard = (Label)e.Item.FindControl("lblstandard");
            Label lbladmin = (Label)e.Item.FindControl("lbladmin");
            Label lblidno = (Label)e.Item.FindControl("lblidno");
            lblname.Text = dr["name"].ToString();
            lblstandard.Text = dr["standard"].ToString();
            lbladmin.Text = dr["intadmitno"].ToString();
            lblidno.Text = dr["strstudentbirthcertificateno"].ToString();
            lblid.Text = dr["intid"].ToString();

            //lblvalidity.Text = ds.Tables[0].Rows[0]["year"].ToString();
              
        }
        catch
        {
        }

    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridItem dlit in GridIDCard.Items)
            {
                DataRowView dr = (DataRowView)dlit.DataItem;
                FileUpload FileUpload1 = (FileUpload)dlit.FindControl("FileUpload1");
                Button btnupload = (Button)dlit.FindControl("btnUpload");
                Label lblid = (Label)dlit.FindControl("lblid");

                if (FileUpload1.HasFile)
                {
                    string fileName = FileUpload1.FileName;
                    string exten = Path.GetExtension(fileName);
                    //here we have to restrict file type            
                    FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + dlit.Cells[0].Text + ".jpg");

                }
            }
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (DataGridItem dlit in GridIDCard.Items)
        {
            Label lblid = (Label)dlit.FindControl("lblid");
            Label lblname = (Label)dlit.FindControl("lblname");
            Label lblstandard = (Label)dlit.FindControl("lblstandard");
            Label lbladmin = (Label)dlit.FindControl("lbladmin");
            Label lblidnocard = (Label)dlit.FindControl("lblidnocard");
            Label lblidno = (Label)dlit.FindControl("lblidno");
            //Label Label4 = (Label)dlit.FindControl("Label4");
            //Label lblvalidity = (Label)dlit.FindControl("lblvalidity");
            Label Label5 = (Label)dlit.FindControl("Label5");
            Label Label6 = (Label)dlit.FindControl("Label6");
            Label Label7 = (Label)dlit.FindControl("Label7");
            Color FontColor = Color.Silver;
            Color BackColor = Color.Black;
            Bitmap oBitmap = new Bitmap(1223, 1423);
            Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
            Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + dlit.Cells[0].Text + ".jpg");
            Graphics oGraphic = Graphics.FromImage(oBitmap);
            String slabel1 = lblname.Text;
            String slabel2 = lblidnocard.Text;
            String slabel3 = lblidno.Text;
            String slabel4 = lblstandard.Text;
            //String slabel5 = Label4.Text;
            //String slabel6 = lblvalidity.Text;
            String slabel7 = Label5.Text;
            String slabel8 = lbladmin.Text;
            String slabel9 = Label6.Text;
            String slabel10 = Label7.Text;
            Font oFont = new Font("Arial", 30, FontStyle.Bold);
            Font oFont1 = new Font("Arial", 20, FontStyle.Bold);
            Font oFont2 = new Font("Arial", 20);
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
            oGraphic.DrawImage(oBitmap1, 200, 100, 190, 250);
            //oGraphic.DrawImage(oBitmap2, 720, 120, 270, 320);
            oGraphic.DrawString(slabel1, oFont, oBrushwrite, name);
            oGraphic.DrawString(slabel2, oFont2, oBrushwrite, idno);
            oGraphic.DrawString(slabel3, oFont2, oBrushwrite, idcard);
            oGraphic.DrawString(slabel4, oFont1, oBrushwrite, standard);
            //oGraphic.DrawString(slabel5, oFont2, oBrushwrite, validity);
            //oGraphic.DrawString(slabel6, oFont2, oBrushwrite, year);
            oGraphic.DrawString(slabel7, oFont, oBrushwrite, student);
            oGraphic.DrawString(slabel8, oFont2, oBrushwrite, admission);
            oGraphic.DrawString(slabel9, oFont1, oBrushwrite, line);
            oGraphic.DrawString(slabel10, oFont1, oBrushwrite, register);
            oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\" + lblname.Text + "_" + lblstandard.Text + ".jpg", ImageFormat.Jpeg);
            Response.ContentType = "image/jpeg";
            Response.AddHeader("content-disposition", "attachment;filename=" + lblname.Text + "_" + lblstandard.Text + ".jpg");
            oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
           
        }
        Response.End();
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
            
        }
        else
        {
            teachingstaff();
            trimage1.Visible = true;
            
        }
    }
    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        //trimage1.Visible = true;
        //trgenerate.Visible = true;
        fillgrid();
       
    }
    protected void dlIdCard_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }
}
