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
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using EACompression;

public partial class idcard_idcard : System.Web.UI.Page
{

    public string strsql, strMsg;
    public DataAccess da, da1, da2, da3;
    public DataSet ds, ds1, ds2, ds3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fillstandard();
            trimage1.Visible = false;
            trstudent.Visible = false;
            trstaff.Visible = false;
            trbutton.Visible = false;
            trbackside.Visible = false;
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
        ddlstandard.Items.Insert(1, "All");
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
    protected void stafftype()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strtype from tblemployee where intschool=" + Session["Schoolid"].ToString() + " group by strtype";
        ds = da.ExceuteSql(str);
        ddlstaff.DataSource = ds;
        ddlstaff.DataTextField = "strtype";
        ddlstaff.DataValueField = "strtype";
        ddlstaff.DataBind();
        ddlstaff.Items.Insert(0, "--Select--");
        ddlstaff.Items.Insert(1, "All");
    }
    protected void staffname()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblemployee where strtype='" + ddlstaff.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataTextField = "name";
        ddlstaffname.DataValueField = "intid";
        ddlstaffname.DataBind();
        ddlstaffname.Items.Insert(0, "--Select--");
        ddlstaffname.Items.Insert(1, "All");
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        trbutton.Visible = true;
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue == "1")
        {
            trimage1.Visible = true;
            trbackside.Visible = false;
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        fillgrid();
        trimage1.Visible = true;
        trbutton.Visible = true;
        trbackside.Visible = false;
    }
    protected void fillgrid()
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str;
            str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,a.strstudentbirthcertificateno as studentbirth,";
            str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
            str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();
            if (ddlstudent.SelectedIndex > 1)
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
        else
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str;
            str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strtype,'' as standard,'' as studentbirth,'' as intadmitno,";
            str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblemployee a";
            str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();
            if (ddlstaffname.SelectedIndex > 1)
            {
                str += " and a.intid=" + ddlstaffname.SelectedValue + "";
            }
            if (ddlstaff.SelectedIndex > 0)
            {
                str += " and a.strtype='" + ddlstaff.SelectedValue + "'";
            }

            ds = da.ExceuteSql(str);
            GridIDCard.DataSource = ds;
            GridIDCard.DataBind();
        }
    }
    protected void GridIDCard_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            if (ddlpatrontype.SelectedValue == "Student")
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str;
                str = "select '../images/student/' + ltrim(str(a.intid)) + '.jpg' as strimage,a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,a.strstudentbirthcertificateno as studentbirth,";
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
            else
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str;
                str = "select '../images/Staff/' + ltrim(str(a.intid)) + '.jpg' as strimage,a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strtype,'' as standard,'' as studentbirth,'' as intadmitno,";
                str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblemployee a";
                str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();
                str += " and a.intid=" + dr["intid"] + "";

                if (ddlstaff.SelectedIndex > 0)
                {
                    str += " and a.strtype='" + ddlstaff.SelectedValue + "'";
                }

                ds = da.ExceuteSql(str);
                dlIdCard.DataSource = ds;
                dlIdCard.DataBind();
            }
        }

        catch
        {
        }

    }
    protected void dlIdCard_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (ddlpatrontype.SelectedValue == "Student")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView dr = (DataRowView)e.Item.DataItem;
                    DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
                    Label lblid = (Label)e.Item.FindControl("lblid");
                    Label lblintid = (Label)e.Item.FindControl("lblintid");
                    Label lblname = (Label)e.Item.FindControl("lblname");
                    Label lblstandard = (Label)e.Item.FindControl("lblstandard");
                    Label lbladmin = (Label)e.Item.FindControl("lbladmin");
                    Label lblstartdate = (Label)e.Item.FindControl("lblstartdate");
                    Label lblenddate = (Label)e.Item.FindControl("lblenddate");
                    Label lblidcardno1 = (Label)e.Item.FindControl("lblidcardno1");
                    Label lblstaff = (Label)e.Item.FindControl("lblstaff");
                    TextBox txtname = (TextBox)e.Item.FindControl("txtname");
                    TextBox txtstart = (TextBox)e.Item.FindControl("txtstart");
                    TextBox txtend = (TextBox)e.Item.FindControl("txtend");
                    lblstaff.Visible = false;
                    txtend.Visible = false;
                    txtstart.Visible = false;
                    txtname.Visible = false;

                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    string str;
                    str = "select '../images/student/' + ltrim(str(a.intid)) + '.jpg' as strimage,a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,a.strstudentbirthcertificateno as studentbirth,";
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
                    lblidcardno1.Text = ds.Tables[0].Rows[0]["studentbirth"].ToString();

                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView dr = (DataRowView)e.Item.DataItem;
                    DataList dlIdCard = (DataList)e.Item.FindControl("dlIdCard");
                    Label lblid = (Label)e.Item.FindControl("lblid");
                    Label lblname = (Label)e.Item.FindControl("lblname");
                    Label lblstartdate = (Label)e.Item.FindControl("lblstartdate");
                    Label lblenddate = (Label)e.Item.FindControl("lblenddate");
                    Label lblidcardno = (Label)e.Item.FindControl("lblidcardno");
                    Label lblstudent = (Label)e.Item.FindControl("lblstudent");
                    TextBox txtname = (TextBox)e.Item.FindControl("txtname");
                    TextBox txtstart = (TextBox)e.Item.FindControl("txtstart");
                    TextBox txtend = (TextBox)e.Item.FindControl("txtend");
                    txtend.Visible = false;
                    txtstart.Visible = false;
                    txtname.Visible = false;
                    lblstudent.Visible = false;
                    lblidcardno.Visible = false;
                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    string str;
                    str = "select '../images/staff/' + ltrim(str(a.intid)) + '.jpg' as strimage,a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strtype,'' as studentintid,'' as standard,'' as studentbirth,'' as intadmitno,";
                    str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblemployee a";
                    str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();
                    str += " and a.intid=" + dr["intid"] + "";

                    ds = new DataSet();
                    da = new DataAccess();
                    ds = da.ExceuteSql(str);

                    lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
                    lblstartdate.Text = ds.Tables[0].Rows[0]["year"].ToString();
                    lblenddate.Text = ds.Tables[0].Rows[0]["year1"].ToString();
                }
            }
        }
        catch
        {
        }

    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            foreach (DataGridItem dlit in GridIDCard.Items)
            {
                DataRowView dr = (DataRowView)dlit.DataItem;
                DataList dl = (DataList)dlit.FindControl("dlIdCard");
                for (int j = 0; j < dl.Items.Count; j++)
                {
                    DataListItem ditem = dl.Items[j];
                    Label lblid = (Label)ditem.FindControl("lblid");
                    FileUpload FileUpload1 = (FileUpload)ditem.FindControl("FileUpload1");
                    Button btnupload = (Button)ditem.FindControl("btnUpload");
                    if (FileUpload1.HasFile)
                    {
                        string fileName = FileUpload1.FileName;
                        string exten = Path.GetExtension(fileName);
                        //here we have to restrict file type            
                        FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + dlit.Cells[0].Text + ".jpg");

                    }
                }
            }
        }
        else
        {
            foreach (DataGridItem dlit in GridIDCard.Items)
            {
                DataRowView dr = (DataRowView)dlit.DataItem;
                DataList dl = (DataList)dlit.FindControl("dlIdCard");
                for (int j = 0; j < dl.Items.Count; j++)
                {
                    DataListItem ditem = dl.Items[j];
                    Label lblid = (Label)ditem.FindControl("lblid");
                    FileUpload FileUpload1 = (FileUpload)ditem.FindControl("FileUpload1");
                    Button btnupload = (Button)ditem.FindControl("btnUpload");
                    if (FileUpload1.HasFile)
                    {
                        string fileName = FileUpload1.FileName;
                        string exten = Path.GetExtension(fileName);
                        FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\staff\\" + dlit.Cells[0].Text + ".jpg");

                    }
                }
            }
        }
    }

    protected void ddlstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        trbutton.Visible = true;
    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        staffname();
        fillgrid();
        trimage1.Visible = true;
        trbutton.Visible = true;

    }
    protected void ddlpatrontype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatrontype.SelectedValue == "Student")
        {
            fillstandard();
            trstaff.Visible = false;
            trstudent.Visible = true;
            trimage1.Visible = false;


        }
        else
        {
            stafftype();
            trstaff.Visible = true;
            trstudent.Visible = false;
            trimage1.Visible = false;
        }
    }

    protected void btngenerate_Click(object sender, EventArgs e)
    {
        GenerateJpeg1();
    }
    protected void GenerateJpeg1()
    {
        try
        {
            if (ddlpatrontype.SelectedValue == "Student")
            {
                string path1 = ddlstandard.SelectedValue;
                string path = Regex.Replace(path1, @" - ", string.Empty);
                if (File.Exists("../Downloaded/" + path + ".zip"))
                {
                    File.Delete("../Downloaded/" + path + ".zip");
                }
                ZipArchive oZip = new ZipArchive("TryIt");
                oZip.Create(Server.MapPath("../Downloaded/" + path + ".zip"), true);
                string password = "";

                try
                {
                    foreach (DataGridItem dlit in GridIDCard.Items)
                    {
                        DataRowView dr = (DataRowView)dlit.DataItem;
                        DataList dl = (DataList)dlit.FindControl("dlIdCard");

                        for (int j = 0; j < dl.Items.Count; j++)
                        {
                            DataListItem ditem = dl.Items[j];
                            Label lblid = (Label)ditem.FindControl("lblid");
                            Label lblname = (Label)ditem.FindControl("lblname");
                            Label lblstandard = (Label)ditem.FindControl("lblstandard");
                            Label lblidcardno = (Label)ditem.FindControl("lblidcardno");
                            Label lblidcardno1 = (Label)ditem.FindControl("lblidcardno1");
                            Label lblvalidity = (Label)ditem.FindControl("lblvalidity");
                            Label lblstartdate = (Label)ditem.FindControl("lblstartdate");
                            Label lblenddate = (Label)ditem.FindControl("lblenddate");
                            Label lblstudent = (Label)ditem.FindControl("lblstudent");
                            Label lbladmin = (Label)ditem.FindControl("lbladmin");
                            Label lblline = (Label)ditem.FindControl("lblline");
                            Label lblreg = (Label)ditem.FindControl("lblreg");
                            Color FontColor = Color.Silver;
                            Color BackColor = Color.Black;
                            Bitmap oBitmap = new Bitmap(1223, 1423);
                            Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
                            Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + dlit.Cells[j].Text + ".jpg");
                            Graphics oGraphic = Graphics.FromImage(oBitmap);
                            String sname = lblname.Text;
                            String sstandard = lblstandard.Text;
                            String sadmin = lbladmin.Text;
                            String svalidity = lblstartdate.Text + " to " + lblenddate.Text;
                            String sstudentbirth = lblidcardno1.Text;
                            String sidcard = lblidcardno.Text;
                            String svalidity1 = lblvalidity.Text;
                            String sstudent = lblstudent.Text;
                            String sline = lblline.Text;
                            String sreg = lblreg.Text;
                            String s1 = lbl1.Text;
                            String s2 = lbl2.Text;
                            String s3 = lbl3.Text;
                            String s4 = lbl4.Text;
                            String s5 = lbl5.Text;
                            String s6 = lbl6.Text;
                            String s7 = lbl7.Text;
                            String s8 = lbl8.Text;
                            String s9 = lbl9.Text;
                            String s10 = lbl10.Text;
                            String s11 = lbl11.Text;
                            String s12 = lbl12.Text;
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
                            oGraphic.DrawString(sname, oFont, oBrushwrite, name);
                            oGraphic.DrawString(sidcard, oFont2, oBrushwrite, idno);
                            oGraphic.DrawString(sstudentbirth, oFont2, oBrushwrite, idcard);
                            oGraphic.DrawString(sstandard, oFont1, oBrushwrite, standard);
                            oGraphic.DrawString(svalidity1, oFont2, oBrushwrite, validity);
                            oGraphic.DrawString(svalidity, oFont2, oBrushwrite, year);
                            oGraphic.DrawString(sstudent, oFont, oBrushwrite, student);
                            oGraphic.DrawString(sadmin, oFont2, oBrushwrite, admission);
                            oGraphic.DrawString(sline, oFont1, oBrushwrite, line);
                            oGraphic.DrawString(sreg, oFont1, oBrushwrite, register);
                            oGraphic.DrawString(s1, oFont5, oBrushwrite, point1);
                            oGraphic.DrawString(s2, oFont4, oBrushwrite, point2);
                            oGraphic.DrawString(s3, oFont5, oBrushwrite, point3);
                            oGraphic.DrawString(s4, oFont5, oBrushwrite, point4);
                            oGraphic.DrawString(s5, oFont6, oBrushwrite, point5);
                            oGraphic.DrawString(s6, oFont6, oBrushwrite, point6);
                            oGraphic.DrawString(s7, oFont6, oBrushwrite, point7);
                            oGraphic.DrawString(s8, oFont6, oBrushwrite, point8);
                            oGraphic.DrawString(s9, oFont6, oBrushwrite, point9);
                            oGraphic.DrawString(s10, oFont6, oBrushwrite, point10);
                            oGraphic.DrawString(s11, oFont6, oBrushwrite, point11);
                            oGraphic.DrawString(s12, oFont6, oBrushwrite, point12);
                            var filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\" + lbladmin.Text + ".jpg";
                            oBitmap.Save(filePath, ImageFormat.Jpeg);
                            oBitmap.Dispose();
                            oZip.AddFile(Server.MapPath("card\\" + lbladmin.Text + ".jpg"), lbladmin.Text + ".jpg", password);
                        }
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Open", "<script type='text/javascript'>window.open('popupwindow.aspx?pathid=" + path + "','width=100,height=100,toolbar=1,scrollbars=no') </script>", false);
                }
                catch { }
                finally
                {
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                Response.End();

            }
            else
            {
                if (ddlpatrontype.SelectedValue == "Staffs")
                {
                    string path1 = ddlstaff.SelectedValue;
                    string path = Regex.Replace(path1, @" ", string.Empty);
                    if (File.Exists("../Downloaded/" + path + ".zip"))
                    {
                        File.Delete("../Downloaded/" + path + ".zip");
                    }
                    ZipArchive oZip = new ZipArchive("TryIt");
                    oZip.Create(Server.MapPath("../Downloaded/" + path + ".zip"), true);
                    string password = "";

                    try
                    {
                        //File.Delete(ddlstandard.SelectedValue);

                        foreach (DataGridItem dlit in GridIDCard.Items)
                        {
                            DataRowView dr = (DataRowView)dlit.DataItem;
                            DataList dl = (DataList)dlit.FindControl("dlIdCard");

                            for (int j = 0; j < dl.Items.Count; j++)
                            {
                                DataListItem ditem = dl.Items[j];
                                Label lblid = (Label)ditem.FindControl("lblid");
                                Label lblname = (Label)ditem.FindControl("lblname");
                                Label lblstandard = (Label)ditem.FindControl("lblstandard");
                                Label lblidcardno = (Label)ditem.FindControl("lblidcardno");
                                Label lblidcardno1 = (Label)ditem.FindControl("lblidcardno1");
                                Label lblvalidity = (Label)ditem.FindControl("lblvalidity");
                                Label lblstartdate = (Label)ditem.FindControl("lblstartdate");
                                Label lblenddate = (Label)ditem.FindControl("lblenddate");
                                Label lblstudent = (Label)ditem.FindControl("lblstudent");
                                Label lbladmin = (Label)ditem.FindControl("lbladmin");
                                Label lblline = (Label)ditem.FindControl("lblline");
                                Label lblreg = (Label)ditem.FindControl("lblreg");
                                Color FontColor = Color.Silver;
                                Color BackColor = Color.Black;
                                Bitmap oBitmap = new Bitmap(1223, 1423);
                                Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
                                Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\staff\\" + dlit.Cells[j].Text + ".jpg");
                                Graphics oGraphic = Graphics.FromImage(oBitmap);
                                String sname = lblname.Text;
                                String sstandard = lblstandard.Text;
                                String sadmin = lbladmin.Text;
                                String svalidity = lblstartdate.Text + " to " + lblenddate.Text;
                                String sstudentbirth = lblidcardno1.Text;
                                String sidcard = lblidcardno.Text;
                                String svalidity1 = lblvalidity.Text;
                                String sstudent = lblstudent.Text;
                                String sline = lblline.Text;
                                String sreg = lblreg.Text;
                                String s1 = lbl1.Text;
                                String s2 = lbl2.Text;
                                String s3 = lbl3.Text;
                                String s4 = lbl4.Text;
                                String s5 = lbl5.Text;
                                String s6 = lbl6.Text;
                                String s7 = lbl7.Text;
                                String s8 = lbl8.Text;
                                String s9 = lbl9.Text;
                                String s10 = lbl10.Text;
                                String s11 = lbl11.Text;
                                String s12 = lbl12.Text;
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
                                oGraphic.DrawString(sname, oFont, oBrushwrite, name);
                                oGraphic.DrawString(sidcard, oFont2, oBrushwrite, idno);
                                oGraphic.DrawString(sstudentbirth, oFont2, oBrushwrite, idcard);
                                oGraphic.DrawString(sstandard, oFont1, oBrushwrite, standard);
                                oGraphic.DrawString(svalidity1, oFont2, oBrushwrite, validity);
                                oGraphic.DrawString(svalidity, oFont2, oBrushwrite, year);
                                oGraphic.DrawString(sstudent, oFont, oBrushwrite, student);
                                oGraphic.DrawString(sadmin, oFont2, oBrushwrite, admission);
                                oGraphic.DrawString(sline, oFont1, oBrushwrite, line);
                                oGraphic.DrawString(sreg, oFont1, oBrushwrite, register);
                                oGraphic.DrawString(s1, oFont5, oBrushwrite, point1);
                                oGraphic.DrawString(s2, oFont4, oBrushwrite, point2);
                                oGraphic.DrawString(s3, oFont5, oBrushwrite, point3);
                                oGraphic.DrawString(s4, oFont5, oBrushwrite, point4);
                                oGraphic.DrawString(s5, oFont6, oBrushwrite, point5);
                                oGraphic.DrawString(s6, oFont6, oBrushwrite, point6);
                                oGraphic.DrawString(s7, oFont6, oBrushwrite, point7);
                                oGraphic.DrawString(s8, oFont6, oBrushwrite, point8);
                                oGraphic.DrawString(s9, oFont6, oBrushwrite, point9);
                                oGraphic.DrawString(s10, oFont6, oBrushwrite, point10);
                                oGraphic.DrawString(s11, oFont6, oBrushwrite, point11);
                                oGraphic.DrawString(s12, oFont6, oBrushwrite, point12);
                                var filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\" + lblid.Text + ".jpg";
                                oBitmap.Save(filePath, ImageFormat.Jpeg);
                                oBitmap.Dispose();
                                oZip.AddFile(Server.MapPath("card\\" + lblid.Text + ".jpg"), lblname.Text + ".jpg", password);
                            }
                        }
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Open", "<script type='text/javascript'>window.open('popupwindow.aspx?pathid=" + path + "','width=100,height=100,toolbar=1,scrollbars=no') </script>", false);
                    }
                    catch { }
                    finally
                    {
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
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
            TextBox txtstart = (TextBox)ditem.FindControl("txtstart");
            TextBox txtend = (TextBox)ditem.FindControl("txtend");
            Label lblstartdate = (Label)ditem.FindControl("lblstartdate");
            Label lblenddate = (Label)ditem.FindControl("lblenddate");
            ImageButton imageedit = (ImageButton)ditem.FindControl("imageedit");
            Label lblid = (Label)ditem.FindControl("lblid");
            if (imageedit.ImageUrl != "~/media/images/Update.gif")
            {

                txtname.Visible = true;
                lblname.Visible = false;
                if (lblname.Text != "")
                    txtname.Text = lblname.Text;
                txtstart.Visible = true;
                lblstartdate.Visible = false;
                if (lblstartdate.Text != "")
                    txtstart.Text = lblstartdate.Text;
                txtend.Visible = true;
                lblenddate.Visible = false;
                if (lblenddate.Text != "")
                    txtend.Text = lblenddate.Text;

                imageedit.ImageUrl = "~/media/images/Update.gif";
                imageedit.ToolTip = "Edit name and Validity";
            }
            else
            {
                if (txtname.Text != "")
                    lblname.Text = txtname.Text;
                txtname.Visible = false;
                lblname.Visible = true;

                if (txtstart.Text != "")
                    lblstartdate.Text = txtstart.Text;
                txtstart.Visible = false;
                lblstartdate.Visible = true;
                if (txtend.Text != "")
                    lblenddate.Text = txtend.Text;
                txtend.Visible = false;
                lblenddate.Visible = true;
                imageedit.ImageUrl = "~/media/images/edit.gif";
                imageedit.ToolTip = "Update name and Validity";
            }
        }
        catch { }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlpatrontype.SelectedValue == "Student")
            {
                Button print = (Button)sender;
                DataListItem dlitem = print.Parent as DataListItem;

                DataRowView dr = (DataRowView)dlitem.DataItem;
                DataList dlit = (DataList)dlitem.FindControl("dlIdCard");

                Label lblid1 = (Label)dlitem.FindControl("lblid");
                Label lblname1 = (Label)dlitem.FindControl("lblname");
                Label lblstandard1 = (Label)dlitem.FindControl("lblstandard");
                Label lblidcardno1 = (Label)dlitem.FindControl("lblidcardno");
                Label lblidcardno2 = (Label)dlitem.FindControl("lblidcardno1");
                Label lblvalidity1 = (Label)dlitem.FindControl("lblvalidity");
                Label lblstartdate1 = (Label)dlitem.FindControl("lblstartdate");
                Label lblenddate1 = (Label)dlitem.FindControl("lblenddate");
                Label lblstudent1 = (Label)dlitem.FindControl("lblstudent");
                Label lbladmin1 = (Label)dlitem.FindControl("lbladmin");
                Label lblline1 = (Label)dlitem.FindControl("lblline");
                Label lblreg1 = (Label)dlitem.FindControl("lblreg");
                Color FontColor = Color.Silver;
                Color BackColor = Color.Black;
                Bitmap oBitmap = new Bitmap(1223, 1423);
                Bitmap oBitmap1 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "media\\images\\reportcard.png");
                Bitmap oBitmap2 = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\student\\" + lblid1.Text + ".jpg");
                Graphics oGraphic = Graphics.FromImage(oBitmap);
                String ssname = lblname1.Text;
                String ssstandard = lblstandard1.Text;
                String ssadmin = lbladmin1.Text;
                String ssvalidity = lblstartdate1.Text + " to " + lblenddate1.Text;
                String ssstudentbirth = lblidcardno2.Text;
                String ssidcard = lblidcardno1.Text;
                String ssvalidity1 = lblvalidity1.Text;
                String ssstudent = lblstudent1.Text;
                String ssline = lblline1.Text;
                String ssreg = lblreg1.Text;
                String s1 = lbl1.Text;
                String s2 = lbl2.Text;
                String s3 = lbl3.Text;
                String s4 = lbl4.Text;
                String s5 = lbl5.Text;
                String s6 = lbl6.Text;
                String s7 = lbl7.Text;
                String s8 = lbl8.Text;
                String s9 = lbl9.Text;
                String s10 = lbl10.Text;
                String s11 = lbl11.Text;
                String s12 = lbl12.Text;
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
                oGraphic.DrawString(ssname, oFont, oBrushwrite, name);
                oGraphic.DrawString(ssidcard, oFont2, oBrushwrite, idno);
                oGraphic.DrawString(ssstudentbirth, oFont2, oBrushwrite, idcard);
                oGraphic.DrawString(ssstandard, oFont1, oBrushwrite, standard);
                oGraphic.DrawString(ssvalidity1, oFont2, oBrushwrite, validity);
                oGraphic.DrawString(ssvalidity, oFont2, oBrushwrite, year);
                oGraphic.DrawString(ssstudent, oFont, oBrushwrite, student);
                oGraphic.DrawString(ssadmin, oFont2, oBrushwrite, admission);
                oGraphic.DrawString(ssline, oFont1, oBrushwrite, line);
                oGraphic.DrawString(ssreg, oFont1, oBrushwrite, register);
                oGraphic.DrawString(s1, oFont5, oBrushwrite, point1);
                oGraphic.DrawString(s2, oFont4, oBrushwrite, point2);
                oGraphic.DrawString(s3, oFont5, oBrushwrite, point3);
                oGraphic.DrawString(s4, oFont5, oBrushwrite, point4);
                oGraphic.DrawString(s5, oFont6, oBrushwrite, point5);
                oGraphic.DrawString(s6, oFont6, oBrushwrite, point6);
                oGraphic.DrawString(s7, oFont6, oBrushwrite, point7);
                oGraphic.DrawString(s8, oFont6, oBrushwrite, point8);
                oGraphic.DrawString(s9, oFont6, oBrushwrite, point9);
                oGraphic.DrawString(s10, oFont6, oBrushwrite, point10);
                oGraphic.DrawString(s11, oFont6, oBrushwrite, point11);
                oGraphic.DrawString(s12, oFont6, oBrushwrite, point12);
                var filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\" + lbladmin1.Text + ".jpg";
                oBitmap.Save(filePath, ImageFormat.Jpeg);
                Response.ContentType = "image/jpeg";
                Response.AddHeader("content-disposition", "attachment;filename=" + lbladmin1.Text + ".jpg");
                oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
                Response.Close();
            }
        }
        catch { }
    }
}
