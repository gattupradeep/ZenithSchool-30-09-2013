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

public partial class reportcard_Primaryreportcard : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da,da1,da2,da3;
    public DataSet ds,ds1,ds2,ds3;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["hid"] != null)

                Editprimaryreportcard();
            else
            {
                fillstandard();
                fillstudent();
                fillteacher();
                
                trdatagrid.Visible = false;
                tr1.Visible = false;
                trdggrid.Visible = false;
                tr2.Visible = false;
                trdone.Visible = false;
            }
        }
    }
    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strstandard+' - '+ strsection as strstandard from tblstudent where strstandard+' - '+ strsection in('Year- 1 - NIL','Year- 2 - NIL','Year- 3 - NIL','Year- 4 - NIL','Year- 5 - NIL','Year- 6 - NIL') and intschool=" + Session["Schoolid"].ToString() + " group by strstandard,strsection";
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
        str = "select strfirstname+''+strmiddlename+''+strlastname as name,intid from tblstudent where strstandard+' - '+ strsection ='" + ddlstandard.SelectedValue + "' and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "--Select--");
    }
    protected void fillteacher()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.intid,b.intemployee from tblemployee a,tblhomeclass b where a.intid=b.intemployee and b.strhomeclass='" + ddlstandard.SelectedValue + "' and b.intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "name";
        ddlteacher.DataValueField = "intemployee";
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "--Select--");
    }
    protected void fillexamtype()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.intexamtypeid,a.strexamtype,b.strexamtype from tblexamtype a,tblexamschedule b where a.strexamtype=b.strexamtype and b.strclass='"+ddlstandard.SelectedValue+"' group by a.intexamtypeid,a.strexamtype,b.strexamtype ";
        ds = da.ExceuteSql(str);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "intexamtypeid";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0, "--Select--");
    }

    protected void fillstudentno()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select intadmitno,intid from tblstudent where strstandard+' - '+ strsection='" + ddlstandard.SelectedValue + "' and intid=" + ddlstudent.SelectedValue + " and intschool=" + Session["Schoolid"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbladmission.Text = ds.Tables[0].Rows[0]["intadmitno"].ToString();
        }
    }
    protected void fillattendance()
    {
        strsql = "select convert(varchar(10),startdate,111) as startdate from tblacademicyear where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        DateTime dtstartdate = DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString());
        strsql = "select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' and intschool=" + Session["Schoolid"].ToString() + " order by dtexamdate desc";
        da1 = new DataAccess();
        ds1 = new DataSet();
        ds1 = da1.ExceuteSql(strsql);
        DateTime dtenddate = DateTime.Parse(ds1.Tables[0].Rows[0]["dtexamdate"].ToString());

        string str;
        str = "select totaldays-holidays as workingdays from (select datediff(day,startdate,dtexamdate) as totaldays from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as a,";
        str = str + " (select count(*) as holidays from tblacademiccalender c,(select * from (select convert(varchar(10),startdate,111) as startdate from tblacademicYear where intschool=2 and intactive=1) as a,(select top 1 convert(varchar(10),dtexamdate,111) as dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        int workingdays = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        int weeklyholidays = 0;
       
        str = "select strweekholidays from tblworkingdays where intschoolid="+Session["Schoolid"].ToString()+" and strmode='Holiday'";
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

            str = "select dbo.NumberOfSundays('"+dtstartdate+"','"+dtenddate+"',"+intday+")";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(str);
            weeklyholidays = weeklyholidays + int.Parse(ds2.Tables[0].Rows[0][0].ToString());
            
        }
        int workingdays1;
        workingdays1 = workingdays - weeklyholidays;
        double intstudentleave = 0.00;
        str = "select fullleave + halfleave as studentleave from (select count(*) as fullleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
        str = str + "(select top 1 dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.strsession='Full Day' and c.intstudent="+ddlstudent.SelectedValue+" and c.dtdate >=startdate and c.dtdate<=dtexamdate) as a,";
        str = str + " (select count(*)*.5 as halfleave from tblstudentattendance c,(select * from (select startdate from tblacademicYear where intschool=2 and intactive=1) as a,";
        str = str + " (select top 1 dtexamdate from tblexamschedule where strclass='" + ddlstandard.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedItem.Text + "' order by dtexamdate desc) as b) as d where c.strsession!='Full Day' and c.intstudent="+ddlstudent.SelectedValue+" and c.dtdate >=startdate and c.dtdate<=dtexamdate) as b";
        da3 = new DataAccess();
        ds3 = new DataSet();
        ds3 = da3.ExceuteSql(str);
        
        intstudentleave = double.Parse(ds3.Tables[0].Rows[0][0].ToString());
        double presentdays = workingdays1 - intstudentleave;
        double percentage = ((presentdays / workingdays1) *100 );
        double b = double.Parse(String.Format("{0:0.##}", percentage));
        lblattendance.Text = b.ToString() + " %"; 

        }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
        fillteacher();
        fillsocialsubject();
        fillsubject();
        //fillexamtype();
        
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudentno();
        fillsocialsubject();
        fillsubject();
        fillexamtype();
        //fillattendance();
    }
    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillattendance();
        fillsocialsubject();
        fillsubject();
        trdatagrid.Visible = true;
        tr1.Visible = true;
        trdggrid.Visible = true;
        tr2.Visible = true;
        trdone.Visible = true;
    }
    protected void fillsocialsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select * from tblreportindicator";
        ds = da.ExceuteSql(strsql);
        datagrid.DataSource = ds;
        datagrid.DataBind();
    }
    protected void datagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            RadioButtonList RBindicatorleaner = (RadioButtonList)e.Item.FindControl("RBindicatorleaner");
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select '<img src=''../images/Indicator/' + ltrim(str(intIndicatorID)) + '.png''/>' + ' ' + strindicator as strimage,intIndicatorID from tblindicator";
            ds = da.ExceuteSql(strsql);
            RBindicatorleaner.DataSource = ds;
            RBindicatorleaner.DataTextField = "strimage";
            RBindicatorleaner.DataValueField = "intIndicatorID";
            RBindicatorleaner.DataBind();

        }
        catch { }
    }
   
    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strsubject from tblschoolexampaper where strclass='" + ddlstandard.SelectedValue + "' and intschoolid=" + Session["Schoolid"].ToString() + " group by strsubject";
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
            strsql = "select strexampaper from tblschoolexampaper where strsubject='" + lblsubject.Text + "' and strclass='" + ddlstandard.SelectedValue + "' and intschoolid=" + Session["Schoolid"].ToString();
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
            DataRowView dr = (DataRowView)e.Item.DataItem;
            RadioButtonList RBindicatorsubject = (RadioButtonList)e.Item.FindControl("RBindicatorsubject");
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select '<img src=''../images/Indicator1/' + ltrim(str(intIndicatorID)) + '.png''/>' + ' ' + strsubjectIndicator as strimage,intIndicatorID from tblsubjectindicator";
            ds = da.ExceuteSql(strsql);
            RBindicatorsubject.DataSource = ds;
            RBindicatorsubject.DataTextField = "strimage";
            RBindicatorsubject.DataValueField = "intIndicatorID";
            RBindicatorsubject.DataBind();
        }
        catch { }
    }

    protected void btndone_Click(object sender, EventArgs e)
    {
        if (btndone.Text == "Done")
        {
            da = new DataAccess();
            ds = new DataSet();

            strsql = "select intreportid from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intstudent=" + ddlstudent.SelectedValue + " and inthometeacher=" + ddlteacher.SelectedValue + " and stradmissionno= '" + lbladmission.Text + "' and intexamtype=" + ddlexamtype.SelectedValue;
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds.Tables[0].Rows[i]["intreportid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),208);
                }
            }

            strsql = "delete tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intstudent=" + ddlstudent.SelectedValue + " and inthometeacher=" + ddlteacher.SelectedValue + " and stradmissionno= '" + lbladmission.Text + "' and intexamtype=" + ddlexamtype.SelectedValue;
            da.ExceuteSqlQuery(strsql);
            foreach (DataGridItem dlit in datagrid.Items)
            {
                RadioButtonList RBindicatorleaner = (RadioButtonList)dlit.FindControl("RBindicatorleaner");
                da = new DataAccess();
                for (int i = 0; i < RBindicatorleaner.Items.Count; i++)
                {
                    if (RBindicatorleaner.Items[i].Selected)
                    {
                        strsql = "insert into tblprimaryreportcard(strstandard,intstudent,inthometeacher,stradmissionno,intexamtype,strsubject,strexampaper,intsubjectindicator)values('" + ddlstandard.SelectedValue + "'," + ddlstudent.SelectedValue + "," + ddlteacher.SelectedValue + ",'" + lbladmission.Text + "'," + ddlexamtype.SelectedValue + ",'General','" + dlit.Cells[1].Text + "'," + RBindicatorleaner.Items[i].Value + ")";
                        da.ExceuteSqlQuery(strsql);

                        strsql = "select max(intreportid) as intreportid from tblprimaryreportcard";
                        ds2 = da.ExceuteSql(strsql);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds2.Tables[0].Rows[0]["intreportid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),208);
                    }
                }
            }
            foreach (DataGridItem dlit in dgreport.Items)
            {
                DataGrid dgexampaper = (DataGrid)dlit.FindControl("dgexampaper");
                Label lblsubject = (Label)dlit.FindControl("lblsubject");
                foreach (DataGridItem dlit1 in dgexampaper.Items)
                {
                    RadioButtonList RBindicatorsubject = (RadioButtonList)dlit1.FindControl("RBindicatorsubject");
                    da = new DataAccess();
                    for (int i = 0; i < RBindicatorsubject.Items.Count; i++)
                    {
                        if (RBindicatorsubject.Items[i].Selected)
                        {
                            strsql = "insert into tblprimaryreportcard(strstandard,intstudent,inthometeacher,stradmissionno,intexamtype,strsubject,strexampaper,intsubjectindicator)values('" + ddlstandard.SelectedValue + "'," + ddlstudent.SelectedValue + "," + ddlteacher.SelectedValue + ",'" + lbladmission.Text + "'," + ddlexamtype.SelectedValue + ",'" + lblsubject.Text + "','" + dlit1.Cells[0].Text + "'," + RBindicatorsubject.Items[i].Value + ")";
                            da.ExceuteSqlQuery(strsql);

                            strsql = "select max(intreportid) as intreportid  from tblprimaryreportcard";
                            ds2 = da.ExceuteSql(strsql);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds2.Tables[0].Rows[0]["intreportid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),208);

                        }
                    }
                }
            }
            btndone.Text = "Done";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
        }
        else
        {
            da = new DataAccess();
            ds = new DataSet();

            strsql = "select intreportid from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intstudent=" + ddlstudent.SelectedValue + " and inthometeacher=" + ddlteacher.SelectedValue + " and stradmissionno= '" + lbladmission.Text + "' and intexamtype=" + ddlexamtype.SelectedValue;
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds.Tables[0].Rows[i]["intreportid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),208);
                }
            }

            strsql = "delete tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intstudent=" + ddlstudent.SelectedValue + " and inthometeacher=" + ddlteacher.SelectedValue + " and stradmissionno= '" + lbladmission.Text + "' and intexamtype=" + ddlexamtype.SelectedValue;
            da.ExceuteSqlQuery(strsql);
            foreach (DataGridItem dlit in datagrid.Items)
            {
                RadioButtonList RBindicatorleaner = (RadioButtonList)dlit.FindControl("RBindicatorleaner");
                da = new DataAccess();
                DataSet ds2 = new DataSet();
                for (int i = 0; i < RBindicatorleaner.Items.Count; i++)
                {
                    if (RBindicatorleaner.Items[i].Selected)
                    {
                        strsql = "insert into tblprimaryreportcard(strstandard,intstudent,inthometeacher,stradmissionno,intexamtype,strsubject,strexampaper,intsubjectindicator)values('" + ddlstandard.SelectedValue + "'," + ddlstudent.SelectedValue + "," + ddlteacher.SelectedValue + ",'" + lbladmission.Text + "'," + ddlexamtype.SelectedValue + ",'General','" + dlit.Cells[1].Text + "'," + RBindicatorleaner.Items[i].Value + ")";
                        da.ExceuteSqlQuery(strsql);

                        strsql = "select max(intreportid) as intreportid  from tblprimaryreportcard";
                        ds2 = da.ExceuteSql(strsql);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds2.Tables[0].Rows[0]["intreportid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),208);

                    }
                }
            }
            foreach (DataGridItem dlit in dgreport.Items)
            {
                DataGrid dgexampaper = (DataGrid)dlit.FindControl("dgexampaper");
                Label lblsubject = (Label)dlit.FindControl("lblsubject");
                foreach (DataGridItem dlit1 in dgexampaper.Items)
                {
                    RadioButtonList RBindicatorsubject = (RadioButtonList)dlit1.FindControl("RBindicatorsubject");
                    da = new DataAccess();
                    for (int i = 0; i < RBindicatorsubject.Items.Count; i++)
                    {
                        if (RBindicatorsubject.Items[i].Selected)
                        {
                            strsql = "insert into tblprimaryreportcard(strstandard,intstudent,inthometeacher,stradmissionno,intexamtype,strsubject,strexampaper,intsubjectindicator)values('" + ddlstandard.SelectedValue + "'," + ddlstudent.SelectedValue + "," + ddlteacher.SelectedValue + ",'" + lbladmission.Text + "'," + ddlexamtype.SelectedValue + ",'" + lblsubject.Text + "','" + dlit1.Cells[0].Text + "'," + RBindicatorsubject.Items[i].Value + ")";
                            da.ExceuteSqlQuery(strsql);

                            strsql = "select max(intreportid) as intreportid from tblprimaryreportcard";
                            ds2 = da.ExceuteSql(strsql);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds2.Tables[0].Rows[0]["intreportid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),208);
                        }
                    }
                }
            }
            btndone.Text = "Done";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
            //Response.Redirect("editprimaryreportcard.aspx?hid=1");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='editprimaryreportcard.aspx?hid=1';", true);
        }
    }
   
 protected void Editprimaryreportcard()
 {
     DataAccess da = new DataAccess();
     string str;
     DataSet ds;
     da = new DataAccess();
     str = "select a.strsubject,a.strexampaper,a.intsubjectindicator,a.strstandard,a.intexamtype,a.intstudent,a.stradmissionno,a.inthometeacher,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name from tblprimaryreportcard a,tblstudent b where a.intstudent=b.intid and a.intstudent='"+ Request["hid"].ToString() +"' and b.intschool=" + Session["Schoolid"].ToString();
     ds = new DataSet();
     ds = da.ExceuteSql(str);
     fillstandard();
     ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
     fillstudent();
     ddlstudent.SelectedValue = ds.Tables[0].Rows[0]["intstudent"].ToString();
     fillexamtype();
     ddlexamtype.SelectedValue = ds.Tables[0].Rows[0]["intexamtype"].ToString();
     fillstudentno();
     lbladmission.Text = ds.Tables[0].Rows[0]["stradmissionno"].ToString();
     fillteacher();
     ddlteacher.SelectedValue=ds.Tables[0].Rows[0]["inthometeacher"].ToString();
     fillattendance();
     fillsocialsubject();
     foreach (DataGridItem dlit in datagrid.Items)
     {
         da = new DataAccess();
         ds=new DataSet();
         strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intstudent=" + ddlstudent.SelectedValue + " and inthometeacher=" + ddlteacher.SelectedValue;
         strsql = strsql + " and stradmissionno= '" + lbladmission.Text + "' and intexamtype=" + ddlexamtype.SelectedValue + " and strsubject='General' and strexampaper='" + dlit.Cells[1].Text + "'";
         ds = da.ExceuteSql(strsql);
         RadioButtonList RBindicatorleaner = (RadioButtonList)dlit.FindControl("RBindicatorleaner");
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < RBindicatorleaner.Items.Count; i++)
             {
                 if (RBindicatorleaner.Items[i].Value == ds.Tables[0].Rows[0]["intsubjectindicator"].ToString())
                 {
                     RBindicatorleaner.Items[i].Selected = true;
                 }
             }
         }
     }
     fillsubject();
     foreach (DataGridItem dlit in dgreport.Items)
     {
         DataGrid dgexampaper = (DataGrid)dlit.FindControl("dgexampaper");
         Label lblsubject = (Label)dlit.FindControl("lblsubject");
         foreach (DataGridItem dlit1 in dgexampaper.Items)
         {
             RadioButtonList RBindicatorsubject = (RadioButtonList)dlit1.FindControl("RBindicatorsubject");
             da = new DataAccess();
             ds = new DataSet();
             strsql = "select intsubjectindicator from tblprimaryreportcard where strstandard='" + ddlstandard.SelectedValue + "' and intstudent=" + ddlstudent.SelectedValue + " and inthometeacher=" + ddlteacher.SelectedValue;
             strsql = strsql + " and stradmissionno= '" + lbladmission.Text + "' and intexamtype=" + ddlexamtype.SelectedValue + " and strsubject='" + lblsubject.Text + "' and strexampaper='" + dlit1.Cells[0].Text + "'";
             ds = da.ExceuteSql(strsql);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 for (int i = 0; i < RBindicatorsubject.Items.Count; i++)
                 {
                     if (RBindicatorsubject.Items[i].Value == ds.Tables[0].Rows[0]["intsubjectindicator"].ToString())
                     {
                         RBindicatorsubject.Items[i].Selected = true;
                     }
                 }
             }
         }
     }
     ddlstandard.Enabled = false;
     ddlteacher.Enabled = false;
     ddlstudent.Enabled = false;
     ddlteacher.Enabled = false;
     ddlexamtype.Enabled = false;
     lblattendance.Enabled = false;
     lbladmission.Enabled = false;
     trdatagrid.Visible = true;
     tr1.Visible = true;
     trdggrid.Visible = true;
     tr2.Visible = true;
     btndone.Text = "Update";
 }




}
 
 
