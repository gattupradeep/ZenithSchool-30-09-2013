using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class reportcard_viewprimaryreportcard : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da, da1, da2, da3;
    public DataSet ds, ds1, ds2, ds3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["hid"] != null && Request["hid3"] != null && Request["hid1"] != null && Request["hid2"] != null)
            {

                fillgrid();
                indicator();
                fillsubject();
            }
        }

    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strstandard,a.stradmissionno,b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,c.strfirstname+''+c.strmiddlename+''+c.strlastname as name1, d.strexamtype from tblprimaryreportcard a,tblstudent b,tblemployee c,tblexamtype d where a.intstudent=b.intid";
        str = str + " and a.inthometeacher=c.intid and a.intexamtype=d.intexamtypeid and a.intstudent='" + Request["hid"].ToString() + "' and a.intexamtype=" + Request["hid2"].ToString() + " and b.intschool=" + Session["Schoolid"].ToString() + " and c.intschool=" + Session["Schoolid"].ToString() + " group by a.strstandard,a.stradmissionno,b.strfirstname,b.strmiddlename,b.strlastname,b.intid,c.strfirstname,c.strmiddlename,c.strlastname,d.strexamtype";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblstudent.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lblstudentname.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            lblteacher.Text = ds.Tables[0].Rows[0]["name1"].ToString();
            lblexam.Text = ds.Tables[0].Rows[0]["strexamtype"].ToString();
            lbladmission.Text = ds.Tables[0].Rows[0]["stradmissionno"].ToString();
            fillattendance();
        }

    }
    protected void fillattendance()
    {

        strsql = "select convert(varchar(10),startdate,111) as startdate from tblacademicyear where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        DateTime dtstartdate = DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString());
        strsql = "select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + lblexam.Text + "' and intschool=" + Session["Schoolid"].ToString() + " order by dtexamdate desc";
        da1 = new DataAccess();
        ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        DateTime dtenddate = DateTime.Parse(ds1.Tables[0].Rows[0]["dtexamdate"].ToString());

        string str;
        str = "select totaldays-holidays as workingdays from (select datediff(day,startdate,dtexamdate) as totaldays from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + lblexam.Text + "' order by dtexamdate desc) as b) as a,";
        str = str + " (select count(*) as holidays from tblacademiccalender c,(select * from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + lblexam.Text + "' order by dtexamdate desc) as b) as d where c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
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
        str = str + "(select top 1 dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + lblexam.Text + "' order by dtexamdate desc) as b) as d where c.strsession='Full Day' and c.intstudent=" + lblstudentname.Text + " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as a,";
        str = str + " (select count(*)*.5 as halfleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
        str = str + " (select top 1 dtexamdate from tblexamschedule where strclass='" + lblstandard.Text + "' and strexamtype='" + lblexam.Text + "' order by dtexamdate desc) as b) as d where c.strsession!='Full Day' and c.intstudent=" + lblstudentname.Text + " and c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
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
        str = "select a.strexampaper,b.intindicatorid,b.strindicatorsubject from tblprimaryreportcard a,tblreportindicator b where a.strexampaper=b.strindicatorsubject and a.strsubject='General'and a.strstandard='" + lblstandard.Text + "' and a.intstudent='" + Request["hid"].ToString() + "' and a.inthometeacher='" + Request["hid1"].ToString() + "' and a.intexamtype='" + Request["hid2"].ToString() + "' group by a.strexampaper,b.intindicatorid,b.strindicatorsubject";
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
            //Label rarely = (Label)e.Item.FindControl("rarely");
            //Label some = (Label)e.Item.FindControl("some");
            //Label most = (Label)e.Item.FindControl("most");
            //Label always = (Label)e.Item.FindControl("always");

            btnrarely.Visible = false;
            btnsome.Visible = false;
            btnmost.Visible = false;
            btnalways.Visible = false;
            //rarely.Visible = false;
            //some.Visible = false;
            //most.Visible = false;
            //always.Visible = false;

            DataRowView dr = (DataRowView)e.Item.DataItem;
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + lblstandard.Text + "' and intstudent='" + Request["hid"].ToString() + "' and inthometeacher='" + Request["hid1"].ToString() + "' and intexamtype='" + Request["hid2"].ToString() + "' and strsubject='General' and strexampaper='" + dr[2].ToString() + "'";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "1")
                {
                    btnrarely.Visible = true;
                    //rarely.Visible = true;
                    
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "2")
                {
                    btnsome.Visible = true;
                    //some.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "3")
                {
                    btnmost.Visible = true;
                    //most.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["intsubjectindicator"].ToString() == "4")
                {
                    btnalways.Visible = true;
                    //always.Visible = true;
                }

            }

        }
        catch { }
    }

    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strsubject from tblprimaryreportcard where strsubject!='General' and strstandard='" + lblstandard.Text + "' and intstudent='" + Request["hid"].ToString() + "' and inthometeacher='" + Request["hid1"].ToString() + "' and intexamtype='" + Request["hid2"].ToString() + "' group by strsubject";
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
            strsql = "select strexampaper from tblprimaryreportcard where strsubject='" + lblsubject.Text + "' and strstandard='" + lblstandard.Text + "' and intstudent='" + Request["hid"].ToString() + "' and inthometeacher='" + Request["hid1"].ToString() + "' and intexamtype='" + Request["hid2"].ToString() + "'";
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
            strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + lblstandard.Text + "' and intstudent='" + Request["hid"].ToString() + "' and inthometeacher='" + Request["hid1"].ToString() + "' and intexamtype='" + Request["hid2"].ToString() + "' and strexampaper='" + dr[0].ToString() + "'";
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
   protected void btnback_Click(object sender, EventArgs e)
    {
        if (Request["sbackto"].ToString() == "0")
            Response.Redirect("Searchviewprimaryreportcard.aspx?hid=1");
       else
            Response.Redirect("editprimaryreportcard.aspx?hid=1");
       
    }


}
