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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.IO;

//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;

public partial class id_card_StudentIdCard1 : System.Web.UI.Page
{
    public string strsql, strMsg;
    public DataAccess da, da1, da2, da3;
    public DataSet ds, ds1, ds2, ds3;
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();

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
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
        str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
        str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();
        if (ddlstudent.SelectedIndex > 0)
        {
            str += " and a.intid=" + ddlstudent.SelectedValue + "";
        }
        if (ddlstandard.SelectedIndex > 0)
        {
            str += " and a.strstandard+' - '+a.strsection='" + ddlstandard.SelectedValue + "'";
        }

        ds = da.ExceuteSql(str);
        GridIDCard.DataSource = ds;
        GridIDCard.DataBind();

    }

    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();

    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue == "1")
        {
            //fillgrid();
            fillstandard();
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        fillgrid();

    }
    protected void dlIdCard_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
                Label lblid = (Label)e.Item.FindControl("lblid");
                Label lblname = (Label)e.Item.FindControl("lblname");
                Label lblname1 = (Label)e.Item.FindControl("lblname1");
                Label lblstandard = (Label)e.Item.FindControl("lblstandard");
                Label lblstandard1 = (Label)e.Item.FindControl("lbladmin1");
                Label lbladmin = (Label)e.Item.FindControl("lbladmin");
                Label lbladmin1 = (Label)e.Item.FindControl("lbladmin1");
                Label lblstartdate = (Label)e.Item.FindControl("lblstartdate");
                Label lblenddate = (Label)e.Item.FindControl("lblenddate");

                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str;
                str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
                str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
                str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();

                str += " and a.intid=" + dr["intid"] + "";

                ds = new DataSet();
                da = new DataAccess();
                ds = da.ExceuteSql(str);

                lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                lblstandard.Text = ds.Tables[0].Rows[0]["standard"].ToString();
                lbladmin.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
                lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
                lblstartdate.Text = ds.Tables[0].Rows[0]["year"].ToString();
                lblenddate.Text = ds.Tables[0].Rows[0]["year1"].ToString();

            }
        }
        catch
        {
        }

    }

    protected void GridIDCard_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str;
            str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
            str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
            str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();

            str += " and a.intid=" + dr["intid"] + "";


            if (ddlstandard.SelectedIndex > 0)
            {
                str += " and a.strstandard+' - '+a.strsection='" + ddlstandard.SelectedValue + "'";
            }

            ds = da.ExceuteSql(str);
            dlIdCard.DataSource = ds;
            dlIdCard.DataBind();
        }
        catch
        {
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        Button btn1 = (Button)sender;
        DataListItem dlitem2 = btn1.Parent as DataListItem;
        DataRowView dr = (DataRowView)dlitem2.DataItem;
        DataList dlIdCard = (DataList)dlitem2.FindControl("dlIdCard");

        FileUpload FileUpload1 = (FileUpload)dlitem2.FindControl("FileUpload1");
        Button btnupload = (Button)dlitem2.FindControl("btnupload");
        Label lblid = (Label)dlitem2.FindControl("lblid");
        if (FileUpload1.HasFile)
        {
            string filename = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid.Text + ".jpg");

        }
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}

    //protected void btngenerate_Click(object sender, EventArgs e)
    //{
       
        

        //DataAccess da = new DataAccess();
        //DataSet ds = new DataSet();
        //string str;
        //str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
        //str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
        //str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();

        //if (ddlstandard.SelectedIndex > 0)
        //{
        //    str += " and a.strstandard+' - '+a.strsection='" + ddlstandard.SelectedValue + "'";
        //}
        //ds = da.ExceuteSql(str);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {

        //        Bitmap oBitmap = new Bitmap(420, 400);
        //        Graphics oGraphic = Graphics.FromImage(oBitmap);
        //        Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
        //        Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + ds.Tables[0].Rows[0]["intid"].ToString() + ".jpg");

        //        String sintid = ds.Tables[0].Rows[i]["intid"].ToString();
        //        String sname = ds.Tables[0].Rows[i]["name"].ToString();
        //        String sstandard = ds.Tables[0].Rows[i]["standard"].ToString();
        //        String sadmin = ds.Tables[0].Rows[i]["intadmitno"].ToString();
        //        String svalidity = ds.Tables[0].Rows[i]["year"].ToString() + " to " + ds.Tables[0].Rows[i]["year"].ToString();
        //        String sFont = "10px";
        //        Color oColor = Color.FromName("Green");
        //        SolidBrush oBrush = new SolidBrush(oColor);
        //        SolidBrush oBrushwrite = new SolidBrush(Color.White);
        //        oGraphic.FillRectangle(oBrush, 0, 0, 420, 400);
        //        Font oFont = new Font(sFont, 10);
        //        PointF oPoint1 = new PointF(5f, 200f);
        //        PointF oPoint3 = new PointF(8f, 230f);
        //        PointF oPoint5 = new PointF(310f, 200f);
        //        PointF oPoint9 = new PointF(10f, 270f);
        //        PointF oPoint11 = new PointF(260f, 250f);
        //        PointF oPoint12 = new PointF(290f, 290f);

        //        oGraphic.DrawString(sname, oFont, oBrushwrite, oPoint1);
        //        oGraphic.DrawString(sstandard, oFont, oBrushwrite, oPoint3);
        //        oGraphic.DrawString(sadmin, oFont, oBrushwrite, oPoint5);
        //        oGraphic.DrawString(svalidity, oFont, oBrushwrite, oPoint9);
        //        oGraphic.DrawImage(oBitmap2, 10, 90, 100f, 100f);
        //        oGraphic.DrawImage(oBitmap1, 300, 90, 100f, 100f);
        //        oBitmap.Save(Server.MapPath(@"~\id card\card\IdCard_" + ds.Tables[0].Rows[i]["intid"].ToString() + ".jpg"), ImageFormat.Jpeg);

        //        Response.ContentType = "image/jpg";
        //        oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);

        //    }
           
        //}
        //Response.Redirect(@"~\id card\card\generated_image.jpg?id=1");
        //}
       
                   
    //}
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn1 = (Button)sender;
        DataListItem dlitem2 = btn1.Parent as DataListItem;

        DataRowView dr = (DataRowView)dlitem2.DataItem;
        DataList dlIdCard = (DataList)dlitem2.FindControl("dlIdCard");
        Label lblid = (Label)dlitem2.FindControl("lblid");
        Response.Redirect("PrintReport.aspx?hid1=" + lblid.Text);


    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {
       
        GenerateJpeg1();
          
        
    }
    protected void GenerateJpeg1()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
        str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
        str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();

        if (ddlstandard.SelectedIndex > 0)
        {
            str += " and a.strstandard+' - '+a.strsection='" + ddlstandard.SelectedValue + "'";
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
                Response.End();

            }

        }

    }
}




        



      

    


        
           
        

    
    
    

