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
        str = "select strstandard from tblstudent where intschool=" + Session["Schoolid"].ToString() + " group by strstandard";
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
        str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "--Select--");
    }
   
    //protected void year()
    //{
    //    DataAccess da = new DataAccess();
    //    DataSet ds = new DataSet();
    //    string str = " select Datename(yy,StartDate) as year, Datename(yy,EndDate) as year1 from tblAcademicYear where intschool=" + Session["Schoolid"].ToString() + " and intactive=1";
    //    ds = da.ExceuteSql(str);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblvalidity.Text = ds.Tables[0].Rows[0]["year"].ToString() + " to " + ds.Tables[0].Rows[0]["year1"].ToString();
    //    }
    //}
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue == "1")
        {
           // fillgrid();
            fillstandard();
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        fillgrid();
        
    }
    protected void fillgrid()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select intid,strfirstname+''+strmiddlename+''+strlastname as name,strstandard+' - '+strsection as standard,intadmitno from tblstudent";
        str += "  where intschool=" + Session["Schoolid"].ToString();
        if (ddlstudent.SelectedIndex > 0)
        {
            str += " and intid=" + ddlstudent.SelectedValue + "";
        }
        if (ddlstandard.SelectedIndex > 0)
        {
            str += " and strstandard='" + ddlstandard.SelectedValue + "'";
        }

        ds = da.ExceuteSql(str);
        GridIDCard.DataSource = ds;
        GridIDCard.DataBind();



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
            str = "select intid,strfirstname+''+strmiddlename+''+strlastname as name,strstandard+' - '+strsection as standard,intadmitno from tblstudent";
            str += "  where intschool=" + Session["Schoolid"].ToString();
            if (ddlstudent.SelectedIndex > 0)
            {
                str += " and intid=" + dr["intid"] + "";
            }
            if (ddlstandard.SelectedIndex > 0)
            {
                str += " and strstandard='" + ddlstandard.SelectedValue + "'";
            }

            ds = new DataSet();
            da = new DataAccess();
            ds = da.ExceuteSql(str);
            dlIdCard.DataSource = ds;
            dlIdCard.DataBind();


        }
        catch
        {
        }
    }
    protected void dlIdCard_ItemDataBound(object sender, DataListItemEventArgs e)
    {
       try
        {
           
                DataRowView dr = (DataRowView)e.Item.DataItem;
                DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
                Label intid = (Label)e.Item.FindControl("intid");
                Label lblname = (Label)e.Item.FindControl("lblname");
                Label lblstandard = (Label)e.Item.FindControl("lblstandard");
                Label lbladmin = (Label)e.Item.FindControl("lbladmin");
                //Label lblvalidity1 = (Label)e.Item.FindControl("lblvalidity1");
                //Label lblvalidity = (Label)e.Item.FindControl("lblvalidity");
               
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str;
                str = "select intid,strfirstname+''+strmiddlename+''+strlastname as name,strstandard+' - '+strsection as standard,intadmitno from tblstudent";
                str += "  where intschool=" + Session["Schoolid"].ToString();
                if (ddlstudent.SelectedIndex > 0)
                {
                    str += " and intid=" + dr["intid"] + "";
                }
                if (ddlstandard.SelectedIndex > 0)
                {
                    str += " and strstandard='" + ddlstandard.SelectedValue + "'";
                }

                ds = new DataSet();
                da = new DataAccess();
                ds = da.ExceuteSql(str);
                //dlIdCard.DataSource = ds;
                //dlIdCard.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        //intid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
                        lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        lblstandard.Text = ds.Tables[0].Rows[0]["standard"].ToString();
                        lbladmin.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
                        //lblvalidity.Text = ds.Tables[0].Rows[0]["year"].ToString();
                    }
                }
            
        }
        catch
        {
        }
       
    }

   
    protected void btnupload_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridIDCard.Items.Count; i++)
        {
            DataGridItem item = GridIDCard.Items[i];
            DataList dl = (DataList)item.FindControl("dlIdCard");
            for (int j = 0; j < dl.Items.Count; j++)
            {
                DataListItem ditem = dl.Items[j];
                Label lblid = (Label)ditem.FindControl("lblid");
                FileUpload FileUpload1 = (FileUpload)ditem.FindControl("FileUpload1");

                string filename = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid.Text + ".jpg");
            }
        }

        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GridIDCard.Items.Count; i++)
            {
                DataGridItem item = GridIDCard.Items[i];
                DataList dl = (DataList)item.FindControl("dlIdCard");
                for (int j = 0; j < dl.Items.Count; j++)
                {
                    DataListItem ditem = dl.Items[j];
                    Label intid = (Label)ditem.FindControl("intid");
                    Label lblname = (Label)ditem.FindControl("lblname");
                    Label lblstandard = (Label)ditem.FindControl("lblstandard");
                    Label lbladmin = (Label)ditem.FindControl("lbladmin");
                    Label Label5 = (Label)ditem.FindControl("Label5");
                    Label Label6 = (Label)ditem.FindControl("Label6");
                    Label Label7 = (Label)ditem.FindControl("Label7");
                    Color FontColor = Color.Silver;
                    Color BackColor = Color.Black;
                    Bitmap oBitmap = new Bitmap(1223, 1423);
                    Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
                    Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + intid .Text+ ".jpg");
                    Graphics oGraphic = Graphics.FromImage(oBitmap);
                    String slabel1 = lblname.Text;
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
                    oGraphic.DrawImage(oBitmap2, 720, 120, 270, 320);
                    oGraphic.DrawString(slabel1, oFont, oBrushwrite, name);
                    //oGraphic.DrawString(slabel2, oFont2, oBrushwrite, idno);
                    //oGraphic.DrawString(slabel3, oFont2, oBrushwrite, idcard);
                    oGraphic.DrawString(slabel4, oFont1, oBrushwrite, standard);
                    //oGraphic.DrawString(slabel5, oFont2, oBrushwrite, validity);
                    //oGraphic.DrawString(slabel6, oFont2, oBrushwrite, year);
                    oGraphic.DrawString(slabel7, oFont, oBrushwrite, student);
                    oGraphic.DrawString(slabel8, oFont2, oBrushwrite, admission);
                    oGraphic.DrawString(slabel9, oFont1, oBrushwrite, line);
                    oGraphic.DrawString(slabel10, oFont1, oBrushwrite, register);
                    oBitmap.Save(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\" + lblname.Text + ".jpg", ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                    Response.AddHeader("content-disposition", "attachment;filename=" + lblname.Text + ".jpg");
                    oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
                    Response.End();
                }

            }
        }
        catch { }
        
    }
}
