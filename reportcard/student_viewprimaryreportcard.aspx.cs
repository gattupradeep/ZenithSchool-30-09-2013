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

public partial class reportcard_student_viewprimaryreportcard : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da, da1, da2, da3;
    public DataSet ds, ds1, ds2, ds3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
            {
                fillexamtype();
                fillgrid();
               
                if (Session["StudentClass"].ToString() == "Year- 7 - NIL" || Session["StudentClass"].ToString() == "Year- 8 - NIL" || Session["StudentClass"].ToString() == "Year- 9 - NIL" || Session["StudentClass"].ToString() == "Year- 10 - A" || Session["StudentClass"].ToString() == "Year- 10 - S")
                {
                    Response.Redirect("student_viewsecondaryreportcard.aspx");
                }
            }

        }
    }
    protected void fillexamtype()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strexamtype,a.intexamtypeid,b.intexamtype from tblexamtype a,tblprimaryreportcard b where a.intexamtypeid=b.intexamtype and intstudent="+Session["UserID"].ToString() +" group by a.strexamtype,a.intexamtypeid,b.intexamtype";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlexamtype.DataSource = ds;
            ddlexamtype.DataTextField = "strexamtype";
            ddlexamtype.DataValueField = "intexamtypeid";
            ddlexamtype.DataBind();
            ddlexamtype.Items.Insert(0, "--Select--");
            tr2.Visible = false;
            trindicator.Visible = true;
            trindicator1.Visible = true;
            trteacher.Visible = true;
            trleaner.Visible = true;
            trlearner1.Visible = true;
            trtitle.Visible = true;
            trsubtitle.Visible = true;
            trsubtitle1.Visible = true;
        }
        else
        {
            errormessage.Text = "No reportcard assigned for selected student";
            tr2.Visible = true;
            trindicator.Visible = false;
            trindicator1.Visible = false;
            trteacher.Visible = false;
            trleaner.Visible = false;
            trlearner1.Visible = false;
            trtitle.Visible = false;
            trsubtitle.Visible = false;
            trsubtitle1.Visible = false;
        }

   
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strstandard+' - '+a.strsection as standard,a.intadmitno,a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name, c.strfirstname+''+c.strmiddlename+''+c.strlastname as name1,c.intid,b.intemployee,b.strhomeclass from tblstudent a,tblhomeclass b,tblemployee c";
        str = str + " where c.intID=b.intemployee and a.intschool=2 and b.intschool=" + Session["Schoolid"].ToString() + " and c.intSchool=" + Session["Schoolid"].ToString() + " and a.intid='" + Session["UserID"].ToString() + "' and a.strstandard+' - '+a.strsection=b.strhomeclass";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstandard.Text = ds.Tables[0].Rows[0]["standard"].ToString();
            lblstudent.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblstudentname.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblteacher.Text = ds.Tables[0].Rows[0]["name1"].ToString();
            lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
            //fillattendance();
        }

    }
    protected void fillattendance()
    {

        strsql = "select convert(varchar(10),startdate,111) as startdate from tblacademicyear where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        DateTime dtstartdate = DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString());
        strsql = "select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' and intschool=" + Session["Schoolid"].ToString() + " order by dtexamdate desc";
        da1 = new DataAccess();
        ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        DateTime dtenddate = DateTime.Parse(ds1.Tables[0].Rows[0]["dtexamdate"].ToString());

        string str;
        str = "select totaldays-holidays as workingdays from (select datediff(day,startdate,dtexamdate) as totaldays from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as a,";
        str = str + " (select count(*) as holidays from tblacademiccalender c,(select * from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        int workingdays = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        int weeklyholidays = 0;

        str = "select strweekholidays from tblworkingdays where intschoolid=" + Session["Schoolid"].ToString() + " and strmode='Holiday'";
        da1 = new DataAccess();
        ds1 = new DataSet();
        ds1 = da1.ExceuteSql(str);
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            int intday = 0;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Sunday")
                intday = 1;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Monday")
                intday = 2;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Tuesday")
                intday = 3;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Wednesday")
                intday = 4;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Thursday")
                intday = 5;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Friday")
                intday = 6;
            if (ds1.Tables[0].Rows[i][0].ToString() == "Saturday")
                intday = 7;

            str = "select dbo.NumberOfSundays('" + dtstartdate + "','" + dtenddate + "'," + intday + ")";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(str);
            weeklyholidays = weeklyholidays + int.Parse(ds2.Tables[0].Rows[0][0].ToString());

        }
        int workingdays1;
        workingdays1 = workingdays - weeklyholidays;
        double intstudentleave = 0.00;
        str = "select fullleave + halfleave as studentleave from (select count(*) as fullleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
        str = str + "(select top 1 dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.strsession='Full Day' and c.intstudent=" + lblstudentname.Text + " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as a,";
        str = str + " (select count(*)*.5 as halfleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
        str = str + " (select top 1 dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.strsession!='Full Day' and c.intstudent=" + lblstudentname.Text + " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
        da3 = new DataAccess();
        ds3 = new DataSet();
        ds3 = da3.ExceuteSql(str);

        intstudentleave = double.Parse(ds3.Tables[0].Rows[0][0].ToString());
        double presentdays = workingdays1 - intstudentleave;
        double percentage = ((presentdays / workingdays1) * 100);
        lblattendance.Text = percentage.ToString() + " %";


    }

    protected void indicator()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strexampaper,b.intindicatorid,b.strindicatorsubject from tblprimaryreportcard a,tblreportindicator b where a.strexampaper=b.strindicatorsubject and a.strsubject='General' and intstudent='" + Session["UserID"].ToString() + "' and intexamtype='" + ddlexamtype.SelectedValue + "'";
        ds = da.ExceuteSql(str);
        dgleaner.DataSource = ds;
        dgleaner.DataBind();
    }
    protected void dgleaner_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            ImageButton btnrarely = (ImageButton)e.Item.FindControl("btnrarely");
            ImageButton btnsome = (ImageButton)e.Item.FindControl("btnsome");
            ImageButton btnmost = (ImageButton)e.Item.FindControl("btnmost");
            ImageButton btnalways = (ImageButton)e.Item.FindControl("btnalways");

            btnrarely.Visible = false;
            btnsome.Visible = false;
            btnmost.Visible = false;
            btnalways.Visible = false;

            DataRowView dr = (DataRowView)e.Item.DataItem;
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + lblstandard.Text + "' and intstudent='" + Session["UserID"].ToString() + "' and intexamtype='" + ddlexamtype.SelectedValue + "' and strsubject='General' and strexampaper='" + dr[2].ToString() + "'";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                {
                    btnrarely.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                {
                    btnsome.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                {
                    btnmost.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                {
                    btnalways.Visible = true;
                }

            }

        }
        catch { }
    }

    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strsubject from tblprimaryreportcard where strsubject!='General' and strstandard='" + lblstandard.Text + "' and intstudent='" + Session["UserID"].ToString() + "' and intexamtype='" + ddlexamtype.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(strsql);
        dgreport.DataSource = ds;
        dgreport.DataBind();
    }

    protected void dgreport_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblsubject = (Label)e.Item.FindControl("lblsubject");
            DataGrid dgexampaper = (DataGrid)e.Item.FindControl("dgexampaper");
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select strexampaper from tblprimaryreportcard where strsubject='" + lblsubject.Text + "' and strstandard='" + lblstandard.Text + "' and intstudent='" + Session["UserID"].ToString() + "' and intexamtype='" + ddlexamtype.SelectedValue + "'";
            ds = da.ExceuteSql(strsql);
            dgexampaper.DataSource = ds;
            dgexampaper.DataBind();
        }
        catch { }
    }
    protected void dgexampaper_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            ImageButton btnSignificant = (ImageButton)e.Item.FindControl("btnSignificant");
            ImageButton btnSome = (ImageButton)e.Item.FindControl("btnSome");
            ImageButton btnManaging = (ImageButton)e.Item.FindControl("btnManaging");
            ImageButton btnCapable = (ImageButton)e.Item.FindControl("btnCapable");
            ImageButton btnHighly = (ImageButton)e.Item.FindControl("btnHighly");

            btnSignificant.Visible = false;
            btnSome.Visible = false;
            btnManaging.Visible = false;
            btnCapable.Visible = false;
            btnHighly.Visible = false;

            DataRowView dr = (DataRowView)e.Item.DataItem;
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + lblstandard.Text + "' and intstudent='" + Session["UserID"].ToString() + "' and intexamtype='" + ddlexamtype.SelectedValue + "' and strexampaper='" + dr[0].ToString() + "'";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                {
                    btnSignificant.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                {
                    btnSome.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                {
                    btnManaging.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                {
                    btnCapable.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "5")
                {
                    btnHighly.Visible = true;
                }
            }
        }
        catch { }
    }
   
    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        indicator();
        fillsubject();
        fillattendance();
    }
}
