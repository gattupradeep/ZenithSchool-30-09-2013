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
public partial class school_setlesson : System.Web.UI.Page
{
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents")
        {
            Response.Redirect("view_lesson_plan.aspx");
        }
        if (!IsPostBack)
        {
            fillteacher();            
        }
    }
    protected void fillteacher()
    {
        DataAccess da = new DataAccess();
        string strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as name from tblemployee where intschool=" + Session["SchoolID"] + " and strtype='Teaching Staffs'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlteacher.DataSource = ds;
            ddlteacher.DataTextField = "name";
            ddlteacher.DataValueField = "intid";
            ddlteacher.DataBind();
            ddlteacher.Items.Insert(0, "-Select-");
        }
        try
        {
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
            }
        }
        catch { }
    }
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlteacher.SelectedIndex > 0 && txtfrom.Text != "" && txtTo.Text != "")
            {
                DataAccess da;
                strsql = "";
                DataAccess daq = new DataAccess();
                DataSet dsq = new DataSet();
                string strsqlq = "select strstandard,strsection,strday,strsubject,strteacher,strperiod from tbltimetable where ";
                strsqlq += " intschool='" + Session["SchoolID"] + "' and strteacher='" + ddlteacher.SelectedValue + "' and strperiod LIKE '%Period' and ";
                strsqlq += " strsubject not like '%Language' and strsubject !='Language' and strsubject!='Extra Activities'";
                strsqlq += " union all  ";
                strsqlq += " select strstandard1,strsection1,strday,strlanguage,strteacher,strperiod from tbltimetable2 where";
                strsqlq += " intschool='" + Session["SchoolID"] + "' and strteacher='" + ddlteacher.SelectedValue + "' and strperiod LIKE '%Period' ";
                dsq = daq.ExceuteSql(strsqlq);
                if (dsq.Tables[0].Rows.Count > 0)
                {
                    strsql = "delete tblsetlessontemp where intschool=" + Session["SchoolID"].ToString() + " and intuserlogedin =" + Session["UserID"].ToString();
                    Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessontemp", Session["UserID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);

                    da = new DataAccess();
                    da.ExceuteSqlQuery(strsql);

                    DataAccess daTime = new DataAccess();
                    DataSet dsTime = new DataSet();
                    strsql = "select datediff(day,'" + txtfrom.Text.Trim() + "','" + txtTo.Text.Trim() + "')";
                    dsTime = daTime.ExceuteSql(strsql);
                    //TimeSpan ts =  Convert.ToDateTime(txtTo.Text.Trim()) - Convert.ToDateTime(txtfrom.Text.Trim());
                    //int days = ts.Days;
                    int days = int.Parse(dsTime.Tables[0].Rows[0][0].ToString());
                    for (int x = 0; x <= days; x++)
                    {

                        DataAccess daholiday = new DataAccess();
                        DataSet dsholiday = new DataSet();
                        string strholiday = "select dtdate from tblacademiccalender where intschool= " + Session["SchoolID"].ToString() + " and dtdate=dateadd(day," + x + ",CONVERT(VARCHAR(10),'" + txtfrom.Text.Trim() + "',111))";
                        dsholiday = daholiday.ExceuteSql(strholiday);
                        if (dsholiday.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            DateTime dates = DateTime.Parse(txtfrom.Text.Trim()).AddDays(x);
                            string Daynameofthedate = dates.DayOfWeek.ToString();
                            DataAccess dayleave = new DataAccess();
                            DataSet dsleave = new DataSet();
                            string leavemode = "";
                            string strleave = "select dtdate,strsession from tblstaffattendance where intschool= " + Session["SchoolID"].ToString() + " and dtdate=dateadd(day," + x + ",CONVERT(VARCHAR(10),'" + txtfrom.Text.Trim() + "',111)) and intstaff=" + ddlteacher.SelectedValue;
                            dsleave = dayleave.ExceuteSql(strleave);
                            if (dsleave.Tables[0].Rows.Count > 0)
                            {
                                if (dsleave.Tables[0].Rows[0]["strsession"].ToString() != "Full Day")
                                {
                                    if (dsleave.Tables[0].Rows[0]["strsession"].ToString() == "Half Day - Morning")
                                    {
                                        leavemode = "Afternoon";
                                    }
                                    else
                                    {
                                        leavemode = "Forenoon";
                                    }
                                    DataAccess daq1 = new DataAccess();
                                    DataSet dsq1 = new DataSet();
                                    string strsqlq1 = "select strstandard+' - '+strsection as class,strday,strsubject,strteacher,strperiod from tbltimetable where ";
                                    strsqlq1 += " intschool='" + Session["SchoolID"] + "' and strteacher='" + ddlteacher.SelectedValue + "' and strperiod in (select strperiod from tblschoolperiods where intschool = " + Session["SchoolID"] + " and strsession='" + leavemode + "' and strperiod LIKE '%Period') and strday='" + Daynameofthedate + "' and ";
                                    strsqlq1 += " strsubject not like '%Language' and strsubject !='Language' and strsubject!='Extra Activities'";
                                    strsqlq1 += " union all  ";
                                    strsqlq1 += " select strstandard1+' - '+strsection1 as class,strday,strlanguage,strteacher,strperiod from tbltimetable2 where";
                                    strsqlq1 += " intschool='" + Session["SchoolID"] + "' and strteacher='" + ddlteacher.SelectedValue + "' and strperiod in (select strperiod from tblschoolperiods where intschool = " + Session["SchoolID"] + " and strsession='" + leavemode + "' and strperiod LIKE '%Period') and strday='" + Daynameofthedate + "' ";
                                    dsq1 = daq1.ExceuteSql(strsqlq1);
                                    if (dsq1.Tables[0].Rows.Count > 0)
                                    {
                                        if (Daynameofthedate == dsq1.Tables[0].Rows[0]["strday"].ToString())
                                        {
                                            strsql = "";
                                            DataAccess dainsert = new DataAccess();
                                            DataSet dsinsert = new DataSet();
                                            for (int q = 0; q < dsq1.Tables[0].Rows.Count; q++)
                                            {
                                                strsql = "insert into tblsetlessontemp(dtdate,strclass,strsubject,strperiod,intschoolid,intuserlogedin)values(dateadd(day," + x + ",CONVERT(VARCHAR(10),'" + txtfrom.Text.Trim() + "',111)),";
                                                strsql += " '" + dsq1.Tables[0].Rows[q]["class"].ToString() + "','" + dsq1.Tables[0].Rows[q]["strsubject"].ToString() + "','" + dsq1.Tables[0].Rows[q]["strperiod"].ToString() + "','" + Session["SchoolID"].ToString() + "','" + Session["UserID"] + "')";
                                                dsinsert = dainsert.ExceuteSql(strsql);

                                                DataSet ds2 = new DataSet();
                                                strsql = "select max(intid) as intid from tblsetlessontemp";
                                                ds2 = da.ExceuteSql(strsql);
                                                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessontemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);

                                            }
                                        }
                                        else { }
                                    }
                                }
                                else { }
                            }
                            else
                            {
                                DataAccess daq1 = new DataAccess();
                                DataSet dsq1 = new DataSet();
                                string strsqlq1 = "select strstandard+' - '+strsection as class,strday,strsubject,strteacher,strperiod from tbltimetable where ";
                                strsqlq1 += " intschool='" + Session["SchoolID"] + "' and strteacher='" + ddlteacher.SelectedValue + "' and strperiod LIKE '%Period' and strday='" + Daynameofthedate + "' and ";
                                strsqlq1 += " strsubject not like '%Language' and strsubject !='Language' and strsubject!='Extra Activities'";
                                strsqlq1 += " union all  ";
                                strsqlq1 += " select strstandard1+' - '+strsection1 as class,strday,strlanguage,strteacher,strperiod from tbltimetable2 where";
                                strsqlq1 += " intschool='" + Session["SchoolID"] + "' and strteacher='" + ddlteacher.SelectedValue + "' and strperiod LIKE '%Period' and strday='" + Daynameofthedate + "' ";
                                dsq1 = daq1.ExceuteSql(strsqlq1);
                                if (dsq1.Tables[0].Rows.Count > 0)
                                {
                                    if (Daynameofthedate == dsq1.Tables[0].Rows[0]["strday"].ToString())
                                    {
                                        strsql = "";
                                        DataAccess dainsert = new DataAccess();
                                        DataSet dsinsert = new DataSet();
                                        for (int q = 0; q < dsq1.Tables[0].Rows.Count; q++)
                                        {
                                            strsql = "insert into tblsetlessontemp(dtdate,strclass,strsubject,strperiod,intschool,intuserlogedin)values(dateadd(day," + x + ",CONVERT(VARCHAR(10),'" + txtfrom.Text.Trim() + "',111)),";
                                            strsql += " '" + dsq1.Tables[0].Rows[q]["class"].ToString() + "','" + dsq1.Tables[0].Rows[q]["strsubject"].ToString() + "','" + dsq1.Tables[0].Rows[q]["strperiod"].ToString() + "','" + Session["SchoolID"].ToString() + "','" + Session["UserID"] + "')";
                                            dsinsert = dainsert.ExceuteSql(strsql);

                                            DataSet ds2 = new DataSet();
                                            strsql = "select max(intid) as intid from tblsetlessontemp";
                                            ds2 = da.ExceuteSql(strsql);
                                            Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessontemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);
                                        }
                                    }
                                    else { }
                                }
                            }
                        }
                    }
                    fillgrid();
                    dglesson.Visible = true;
                }
            }
            else
            {
                msgbox.alert("Please complete the fields");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select all the needed Details!')", true);
        }
    }
    protected void fillgrid()
    {
       DataAccess da = new DataAccess();
        DataSet ds;
        strsql = "";
        strsql = "select a.intid,CONVERT(varchar(10),a.dtdate,112) as sortdate, convert(varchar(10),a.dtdate,103)as dtdate,a.strclassperiod,a.strsubject,a.inttextbook,a.strunitname,a.strlessonname,a.strtopic,a.strdescription,b.strtextbookname from tblsetlessonplan a,tblschooltextbook b where a.intschool=" + Session["SchoolID"] + " and a.intteacher=" + ddlteacher.SelectedValue + " and a.dtdate between convert(datetime,'" + txtfrom.Text + "',111) and convert(datetime,'" + txtTo.Text + "',111)and a.dtdate >=convert(varchar(10),GETDATE(),101) and b.intid=a.inttextbook and intactivemode=0";
        strsql += " union all select 0 as intid,'' as sortdate, '' as dtdate,'' as strclassperiod,''as strsubject,'' as inttextbook,'' as strunitname,'' as strlessonname,'' as strtopic,'' asstrdescription,'' as strtextbookname order by sortdate desc";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                dglesson.Columns[10].Visible = false;
            }
            else
            {
                dglesson.Columns[10].Visible = true;
            }
            dglesson.DataSource = ds;
            dglesson.DataBind();
            //btndone.Visible = true;
        }
    }
    protected void dglesson_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ImageButton btladdlesson = (ImageButton)e.Item.FindControl("btnaddlesson");
            ImageButton btndeletelesson = (ImageButton)e.Item.FindControl("btndeletelesson");
            DropDownList date = (DropDownList)e.Item.FindControl("ddldate");
            DropDownList classpreiod = (DropDownList)e.Item.FindControl("ddlclassperiod");
            DropDownList subject = (DropDownList)e.Item.FindControl("ddlsubject");
            DropDownList textbook = (DropDownList)e.Item.FindControl("ddltextbook");
            DropDownList unit = (DropDownList)e.Item.FindControl("ddlunitname");
            DropDownList lesson = (DropDownList)e.Item.FindControl("ddllesson");
            TextBox txttopic = (TextBox)e.Item.FindControl("txttopic");
            TextBox txtdesc = (TextBox)e.Item.FindControl("txtdescription");

            Label lbldate = (Label)e.Item.FindControl("lbldate");
            Label lblclasspreiod = (Label)e.Item.FindControl("lblclasspreiod");
            Label lblsubject = (Label)e.Item.FindControl("lblsubject");
            Label lbltextbook = (Label)e.Item.FindControl("lbltextbook");
            Label lblunitname = (Label)e.Item.FindControl("lblunitname");
            Label lbllesson = (Label)e.Item.FindControl("lbllesson");
            Label lbltopic = (Label)e.Item.FindControl("lbltopic");
            Label lbldescription = (Label)e.Item.FindControl("lbldescription");            
            
            DataAccess da1 = new DataAccess();
            string strsql1 = "select convert(varchar(10),dtdate,103) as dtdate from tblsetlessontemp where intschool=" + Session["SchoolID"] + " and intuserlogedin=" + Session["UserID"] +" group by dtdate";
            DataSet ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql1);            
            date.DataSource = ds1.Tables[0];
            date.DataTextField = "dtdate";
            date.DataValueField = "dtdate";
            date.Items.Clear();
            date.DataBind();
            date.Items.Insert(0,"-Select-");

            string strsql2 = "select strperiod+' /'+strclass as classperiod from tblsetlessontemp where intschool=" + Session["SchoolID"] + " and intuserlogedin=" + Session["UserID"] + " group by strperiod+' /'+strclass order by classperiod asc";
            DataSet ds2 = new DataSet();
            ds2 = da1.ExceuteSql(strsql2);           
            classpreiod.DataSource = ds2.Tables[0];
            classpreiod.DataTextField = "classperiod";
            classpreiod.DataValueField = "classperiod";
            classpreiod.DataBind();
            classpreiod.Items.Insert(0, "-Select-");
            
            subject.Items.Insert(0, "-Select-");            
            textbook.Items.Insert(0, "-Select-");            
            unit.Items.Insert(0, "-Select-");            
            lesson.Items.Insert(0, "-Select-");
            if (dr["intid"].ToString() == "0")
            {
                date.Visible = true;
                classpreiod.Visible = true;
                subject.Visible = true;
                textbook.Visible = true;
                unit.Visible = true;
                lesson.Visible = true;
                txttopic.Visible = true;
                txtdesc.Visible = true;

                lbldate.Visible = false;
                lblclasspreiod.Visible = false;
                lblsubject.Visible = false;
                lbltextbook.Visible = false;
                lblunitname.Visible = false;
                lbllesson.Visible = false;
                lbltopic.Visible = false;
                lbldescription.Visible = false;
                btladdlesson.ImageUrl = "../media/images/add.gif";
                btndeletelesson.Visible = false;
            }
            else
            {
                date.Visible = false;
                classpreiod.Visible = false;
                subject.Visible = false;
                textbook.Visible = false;
                unit.Visible = false;
                lesson.Visible = false;
                txttopic.Visible = false;
                txtdesc.Visible = false;

                lbldate.Visible = true;
                lblclasspreiod.Visible = true;
                lblsubject.Visible = true;
                lbltextbook.Visible = true;
                lblunitname.Visible = true;
                lbllesson.Visible = true;
                lbltopic.Visible = true;
                lbldescription.Visible = true;
                btladdlesson.ImageUrl = "../media/images/edit.gif";                
            }
        }
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds;
        strsql = "";
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dldate = new DropDownList();
        DropDownList dlclass = new DropDownList();
        dldate = (DropDownList)item.FindControl("ddldate");
        dlclass = (DropDownList)item.FindControl("ddlclassperiod");
        strsql = "select strperiod+' /'+strclass as classperiod from tblsetlessontemp where intschool=" + Session["SchoolID"] + " and dtdate=convert(datetime,'" + dldate.SelectedValue + "',103) and intuserlogedin=" + Session["UserID"] + " group by strperiod+' /'+strclass order by classperiod asc";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dlclass.DataSource = ds;
        dlclass.DataTextField = "classperiod";
        dlclass.DataValueField = "classperiod";
        dlclass.Items.Clear();
        dlclass.DataBind();
        dlclass.Items.Insert(0, "-Select-");
        DropDownList dlsubject = (DropDownList)item.FindControl("ddlsubject");
        DropDownList dltextbook = (DropDownList)item.FindControl("ddltextbook");
        DropDownList dlunit = (DropDownList)item.FindControl("ddlunitname");
        DropDownList dllesson = (DropDownList)item.FindControl("ddllesson");
        dlsubject.Items.Clear();
        dlsubject.Items.Insert(0, "-Select-");
        dltextbook.Items.Clear();
        dltextbook.Items.Insert(0, "-Select-");
        dlunit.Items.Clear();
        dlunit.Items.Insert(0, "-Select-");
        dllesson.Items.Clear();
        dllesson.Items.Insert(0, "-Select-");
    }
    protected void ddlclassperiod_SelectedIndexchanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string strsq = "";
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dldate = new DropDownList();
        DropDownList dlclassperiod = new DropDownList();
        DropDownList dlsubject = new DropDownList();
        dldate = (DropDownList)item.FindControl("ddldate");
        dlclassperiod = (DropDownList)item.FindControl("ddlclassperiod");
        string[] period = dlclassperiod.SelectedValue.ToString().Split('/');
        dlsubject = (DropDownList)item.FindControl("ddlsubject");
        if (dldate.SelectedIndex < 1)
        {
            msgbox.alert("Please select date");
            dldate.Focus();
            dlclassperiod.SelectedIndex = 0;
        }
        else
        {
            strsq = "select distinct strsubject from tblsetlessontemp where intschool=" + Session["SchoolID"] + " and intuserlogedin=" + Session["UserID"] + " and dtdate=convert(datetime,'" + dldate.SelectedValue + "',103) and strperiod='" + period[0] + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(strsq);
            dlsubject.DataSource = ds;
            dlsubject.DataTextField = "strsubject";
            dlsubject.DataValueField = "strsubject";
            dlsubject.Items.Clear();
            dlsubject.DataBind();
            dlsubject.Items.Insert(0, "-Select-");

            DropDownList dltextbook = (DropDownList)item.FindControl("ddltextbook");
            DropDownList dlunit = (DropDownList)item.FindControl("ddlunitname");
            DropDownList dllesson = (DropDownList)item.FindControl("ddllesson");
            dltextbook.Items.Clear();
            dltextbook.Items.Insert(0, "-Select-");
            dlunit.Items.Clear();
            dlunit.Items.Insert(0, "-Select-");
            dllesson.Items.Clear();
            dllesson.Items.Insert(0, "-Select-");
        }
    }
    protected void ddlsubject_SelectedIndexchanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "";
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dlclassperiod = new DropDownList();
        DropDownList dlsubject = new DropDownList();
        DropDownList dltextbook = new DropDownList();
        dlclassperiod = (DropDownList)item.FindControl("ddlclassperiod");
        string[] classname = dlclassperiod.SelectedValue.ToString().Split('/');
        dlsubject = (DropDownList)item.FindControl("ddlsubject");
        dltextbook = (DropDownList)item.FindControl("ddltextbook");
        if (dlsubject.SelectedIndex > 0)
        {
            strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + classname[1] + "' and strsubject='" + dlsubject.SelectedValue + "'";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dltextbook.DataSource = ds;
                dltextbook.DataTextField = "strtextbookname";
                dltextbook.DataValueField = "intid";
                dltextbook.Items.Clear();
                dltextbook.DataBind();
                dltextbook.Items.Insert(0, "-Select-");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "open", "show();", true);
            }
        }
        else
        {
        }
    }
    protected void ddltextbook_SelectedIndexchanged(object sender, EventArgs e)
    
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dltextbook = new DropDownList();
        DropDownList dlunit = new DropDownList();
        DropDownList dllesson = new DropDownList();
        dltextbook = (DropDownList)item.FindControl("ddltextbook");
        dlunit = (DropDownList)item.FindControl("ddlunitname");
        dllesson = (DropDownList)item.FindControl("ddllesson");
        strsql = "select distinct strunitno from tblschooltextbookunits where inttextbook=" + dltextbook.SelectedValue;
        ds = da.ExceuteSql(strsql);
        dlunit.DataSource = ds;
        dlunit.DataTextField = "strunitno";
        dlunit.DataValueField = "strunitno";
        dlunit.Items.Clear();
        dlunit.DataBind();
        strsql = "";
        strsql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
        ds = da.ExceuteSql(strsql);
        dllesson.DataSource = ds;
        dllesson.DataTextField = "strlessonname";
        dllesson.DataValueField = "strlessonname";
        dllesson.Items.Clear();
        dllesson.DataBind();
    }
    protected void ddlunit_SelectedIndexchanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dltextbook = new DropDownList();
        DropDownList dlunit = new DropDownList();
        DropDownList dllesson = new DropDownList();
        dltextbook = (DropDownList)item.FindControl("ddltextbook");
        dlunit = (DropDownList)item.FindControl("ddlunitname");
        dllesson = (DropDownList)item.FindControl("ddllesson");
        strsql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
        ds = da.ExceuteSql(strsql);
        dllesson.DataSource = ds;
        dllesson.DataTextField = "strlessonname";
        dllesson.DataValueField = "strlessonname";
        dllesson.Items.Clear();
        dllesson.DataBind();
    }
    protected void btnaddlesson_Click(object sender, EventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string dr = item.Cells[0].Text;
        ImageButton btnaddlesson = (ImageButton)item.FindControl("btnaddlesson");
        ImageButton btndeletelesson = (ImageButton)item.FindControl("btndeletelesson");
        DropDownList dldate = (DropDownList)item.FindControl("ddldate");
        DropDownList dlclassperiod = (DropDownList)item.FindControl("ddlclassperiod");
        DropDownList dlsubject = (DropDownList)item.FindControl("ddlsubject");
        DropDownList dltextbook = (DropDownList)item.FindControl("ddltextbook");
        DropDownList dlunit = (DropDownList)item.FindControl("ddlunitname");
        DropDownList dllesson = (DropDownList)item.FindControl("ddllesson");
        TextBox txttopic = (TextBox)item.FindControl("txttopic");
        TextBox txtdesc = (TextBox)item.FindControl("txtdescription");

        Label lbldate = (Label)item.FindControl("lbldate");
        Label lblclasspreiod = (Label)item.FindControl("lblclasspreiod");
        Label lblsubject = (Label)item.FindControl("lblsubject");
        Label lbltextbook = (Label)item.FindControl("lbltextbook");
        Label lblunitname = (Label)item.FindControl("lblunitname");
        Label lbllesson = (Label)item.FindControl("lbllesson");
        Label lbltopic = (Label)item.FindControl("lbltopic");
        Label lbldescription = (Label)item.FindControl("lbldescription");
        TextBox lbldesc = (TextBox)item.FindControl("txtdescription");

        if (btnaddlesson.ImageUrl == "../media/images/add.gif")
        {
            if (dldate.SelectedIndex < 1 && dlclassperiod.SelectedIndex < 1 && dlsubject.SelectedIndex < 1 && dltextbook.SelectedIndex < 1 && dlunit.SelectedIndex < 1 && dllesson.SelectedIndex < 1)
            {
                msgbox.alert("Please fill all the fields");
            }
            else
            {
                DataAccess da = new DataAccess();
                strsql = "insert into tblsetlessonplan(dtdate,strclassperiod,strsubject,inttextbook,strunitname,strlessonname,strtopic,strdescription,intschool,intteacher)";
                strsql += "values(convert(datetime,'" + dldate.SelectedValue + "',103),'" + dlclassperiod.SelectedValue + "','" + dlsubject.SelectedValue + "','" + dltextbook.SelectedValue + "','" + dlunit.SelectedValue + "','" + dllesson.SelectedValue + "','" + txttopic.Text + "','" + txtdesc.Text + "','" + Session["SchoolID"] + "','" + ddlteacher.SelectedValue + "')";
                da.ExceuteSqlQuery(strsql);
                fillgrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
                DataSet ds2 = new DataSet();
                strsql = "select max(intid) as intid from tblsetlessonplan";
                ds2 = da.ExceuteSql(strsql);
                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);
                
            }
        }
        if (btnaddlesson.ImageUrl == "../media/images/update.gif")
        {
            if (dldate.SelectedIndex < 1 && dlclassperiod.SelectedIndex < 1 && dlsubject.SelectedIndex < 1 && dltextbook.SelectedIndex < 1 && dlunit.SelectedIndex < 1 && dllesson.SelectedIndex < 1)
            {
                msgbox.alert("Please fill all the fields");
            }
            else
            {
                DataAccess da = new DataAccess();
                strsql = "update tblsetlessonplan set dtdate=convert(datetime,'" + dldate.SelectedValue + "',103),strclassperiod='" + dlclassperiod.SelectedValue + "',strsubject='" + dlsubject.SelectedValue + "',inttextbook='" + dltextbook.SelectedValue + "',strunitname='" + dlunit.SelectedValue + "',strlessonname='" + dllesson.SelectedValue + "',strtopic='" + txttopic.Text + "',strdescription='" + txtdesc.Text + "' where intid="+item.Cells[0].Text;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully')", true);
                Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);

                da.ExceuteSqlQuery(strsql);
                fillgrid();
            }
        }
        if (btnaddlesson.ImageUrl == "../media/images/edit.gif")
        {
            dldate.Visible = true;
            dlclassperiod.Visible = true;
            dlsubject.Visible = true;
            dltextbook.Visible = true;
            dlunit.Visible = true;
            dllesson.Visible = true;
            txttopic.Visible = true;
            txtdesc.Visible = true;

            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select *,convert(varchar(10),dtdate,103) as dtdates from tblsetlessonplan where intschool=" + Session["SchoolID"] + " and intteacher=" + ddlteacher.SelectedValue + " and intid=" + dr.ToString();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dldate.SelectedValue = ds.Tables[0].Rows[0]["dtdates"].ToString();
                txttopic.Text = ds.Tables[0].Rows[0]["strtopic"].ToString();
                txtdesc.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();

                DataAccess daclass = new DataAccess();
                strsql = "select strperiod+' /'+strclass as classperiod from tblsetlessontemp where intschool=" + Session["SchoolID"] + " and dtdate=convert(datetime,'" + dldate.SelectedValue + "',103) and intuserlogedin=" + Session["UserID"] + " group by strperiod+' /'+strclass order by classperiod asc";
                DataSet dsclass = new DataSet();
                dsclass = daclass.ExceuteSql(strsql);
                dlclassperiod.DataSource = dsclass;
                dlclassperiod.DataTextField = "classperiod";
                dlclassperiod.DataValueField = "classperiod";
                dlclassperiod.Items.Clear();
                dlclassperiod.DataBind();
                dlclassperiod.Items.Insert(0, "-Select-");
                dlclassperiod.SelectedValue = ds.Tables[0].Rows[0]["strclassperiod"].ToString();

                string[] period = dlclassperiod.SelectedValue.ToString().Split('/');
                DataAccess dasub = new DataAccess();
                strsql = "select distinct strsubject from tblsetlessontemp where intschool=" + Session["SchoolID"] + " and intuserlogedin=" + Session["UserID"] + " and dtdate=convert(datetime,'" + dldate.SelectedValue + "',103) and strperiod='" + period[0] + "'";
                DataSet dssub = new DataSet();
                dssub = da.ExceuteSql(strsql);
                dlsubject.DataSource = dssub;
                dlsubject.DataTextField = "strsubject";
                dlsubject.DataValueField = "strsubject";
                dlsubject.Items.Clear();
                dlsubject.DataBind();
                dlsubject.Items.Insert(0, "-Select-");
                dlsubject.SelectedValue = ds.Tables[0].Rows[0]["strsubject"].ToString();

                DataAccess datextb = new DataAccess();
                strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + period[1] + "' and strsubject='" + dlsubject.SelectedValue + "'";
                DataSet dstextb = new DataSet();
                dstextb = datextb.ExceuteSql(strsql);
                dltextbook.DataSource = dstextb;
                dltextbook.DataTextField = "strtextbookname";
                dltextbook.DataValueField = "intid";
                dltextbook.Items.Clear();
                dltextbook.DataBind();
                dltextbook.Items.Insert(0, "-Select-");
                dltextbook.SelectedValue = ds.Tables[0].Rows[0]["inttextbook"].ToString();

                DataAccess daunit = new DataAccess();
                strsql = "select distinct strunitno from tblschooltextbookunits where inttextbook=" + dltextbook.SelectedValue;
                DataSet dsunit = new DataSet();
                dsunit = daunit.ExceuteSql(strsql);
                dlunit.DataSource = dsunit;
                dlunit.DataTextField = "strunitno";
                dlunit.DataValueField = "strunitno";
                dlunit.Items.Clear();
                dlunit.DataBind();
                dlunit.SelectedValue = ds.Tables[0].Rows[0]["strunitname"].ToString();
                DataAccess dalesson = new DataAccess();
                strsql = "select distinct strlessonname from tblschoolsyllabus where inttextbook=" + dltextbook.SelectedValue + " and strunitno='" + dlunit.SelectedValue + "'";
                DataSet dslesson = new DataSet();
                dslesson = dalesson.ExceuteSql(strsql);
                dllesson.DataSource = dslesson;
                dllesson.DataTextField = "strlessonname";
                dllesson.DataValueField = "strlessonname";
                dllesson.Items.Clear();
                dllesson.DataBind();
                dllesson.SelectedValue = ds.Tables[0].Rows[0]["strlessonname"].ToString();
            }
            lbldate.Visible = false;
            lblclasspreiod.Visible = false;
            lblsubject.Visible = false;
            lbltextbook.Visible = false;
            lblunitname.Visible = false;
            lbllesson.Visible = false;
            lbltopic.Visible = false;
            lbldescription.Visible = false;
            btnaddlesson.ImageUrl = "../media/images/update.gif";
            btndeletelesson.Visible = true;
        }        
    }
    protected void btndeletelesson_Click(object sender, EventArgs e)
    {
        try
        {            
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            string deleteid = item.Cells[0].Text;
            DataAccess da = new DataAccess();
            strsql = "delete from tblsetlessonplan where intschool=" + Session["SchoolID"] + " and intid=" + deleteid;
            Functions.UserLogs(Session["UserID"].ToString(), "tblsetlessonplan", deleteid, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),60);

            da.ExceuteSqlQuery(strsql);
            fillgrid();
        }
        catch
        {
            msgbox.alert("Please Try Again");
        }
    }
  
  
}
