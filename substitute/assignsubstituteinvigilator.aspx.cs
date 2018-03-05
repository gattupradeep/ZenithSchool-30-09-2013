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

public partial class Leave_assignsubstituteinvigilator : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            staffname();
            lblintid.Visible = false;
            trmsg.Visible = false;
            trsub.Visible = false;
            grid();
        }

    }
    protected void date()
    {
        drpdate.Items.Clear();
        DataAccess da=new DataAccess();
        DataSet ds;
        sql = "select dtfromdate,dttodate,";
        sql += " b.strfirstname+''+b.strmiddlename+''+b.strlastname as name";
        sql += " from tblleaverequest a,tblemployee b  where a.intapproved=1 and";
        sql += " a.intcancel!=2 and a.strstaffname=b.intid and a.intschool='" + Session["schoolID"].ToString() + "' and";
        sql += " a.strstaffname='" + drpstaffname.SelectedValue + "' and";
        sql += " day(a.dtfromdate) >= day(getdate()) and month(a.dtfromdate) >= month(getdate())and year(a.dtfromdate)>= year(getdate())";
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        TimeSpan ts = DateTime.Parse(ds.Tables[0].Rows[0]["dttodate"].ToString()) - DateTime.Parse(ds.Tables[0].Rows[0]["dtfromdate"].ToString());
        int days = ts.Days+1;
        int j=0;
        for (int i = 0; i < days; i++)
        {
            DateTime prabaa = DateTime.Parse(ds.Tables[0].Rows[0]["dtfromdate"].ToString()).AddDays(i);
            ListItem li=new ListItem(prabaa.ToString());
            drpdate.Items.Insert(j, li);
            j++;
        }        
    }    
    protected void period()
    {
        DataAccess da = new DataAccess();
        sql = "select strperiod from tbltimetable where strteacher='" + drpstaffname.SelectedValue + "' and";
        sql += " strstandard='" + drpstandard.SelectedValue + "' and strsection='" + drpsection.SelectedValue + "' and";
        sql += " intschool='" + Session["SchoolID"].ToString() + "' and";
        sql += " strday=datename (dw, '" + drpdate.Text+ "') group by strperiod";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpperiod.DataSource = ds;
        drpperiod.DataTextField = "strperiod";
        drpperiod.DataValueField = "strperiod";
        drpperiod.DataBind();
        ListItem li = new ListItem("-select-","0");
        drpperiod.Items.Insert(0, li);
    }

    protected void grid()
    {
        DataAccess da = new DataAccess();
        sql = "select a.intid,a.intstaffid,a.strstandard,a.strsection,a.strperiod,a.strsubject,b.strteacher,c.strfirstname+''+c.strmiddlename+''+c.strlastname as Teacher,";
        sql += " d.strfirstname+''+d.strmiddlename+''+d.strlastname as substitute,a.dtdate,a.inttimetable from  tblperiodsubtitute a,tbltimetable b,tblemployee c,";
        sql += " tblemployee d where a.intschool='" + Session["schoolID"].ToString() + "' and day(a.dtdate) >= day(getdate()) and";
        sql += " month(a.dtdate) >= month(getdate()) and year(a.dtdate)>= year(getdate()) and  b.intid=a.inttimetable and  b.strteacher=c.intid and";
        sql += " a.intstaffid=d.intid group by a.intid,a.intstaffid,a.dtdate,b.strteacher,a.strstandard,a.strsection,a.strperiod,a.strsubject,";
        sql += " c.strfirstname+''+c.strmiddlename+''+c.strlastname ,d.strfirstname+''+d.strmiddlename+''+d.strlastname,a.inttimetable";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        grdsubtitute.DataSource = ds;
        grdsubtitute.DataBind();
    }
    protected void standard()
    {
        DataAccess da = new DataAccess();
        string sql = "select strstandard from tbltimetable where strteacher='" + drpstaffname.SelectedValue + "' and";
        sql += " intschool='" + Session["SchoolID"].ToString() + "' and";
        sql += " strday=datename (dw,'" + drpdate.Text+ "' ) group by strstandard";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpstandard.DataSource = ds;
        drpstandard.DataTextField = "strstandard";
        drpstandard.DataValueField = "strstandard";
        drpstandard.DataBind();
        ListItem li = new ListItem("-select-","0");
        drpstandard.Items.Insert(0, li);
    }
    protected void section()
    {
        DataAccess da = new DataAccess();
        string sql = "select strsection from tbltimetable where strteacher='" + drpstaffname.SelectedValue + "' and";
        sql += " strstandard='" + drpstandard.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "' and";
        sql += " strday=datename (dw, '" + drpdate.Text+ "') group by strsection";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        drpsection.DataSource = ds;
        drpsection.DataTextField = "strsection";
        drpsection.DataValueField = "strsection";
        drpsection.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpsection.Items.Insert(0, li);
    }
    protected void staffname()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as staffname from tblleaverequest a,tblemployee b where";
        sql += " a.intschool='" + Session["SchoolID"].ToString() + "' and intapproved=1 and intcancel!=2 and a.strstaffname=b.intid and";
        sql += " day(dtfromdate) >= day(getdate()) and month(dtfromdate) >= month(getdate()) and year(dtfromdate)>= year(getdate()) group by";
        sql += " b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname";
        ds = da.ExceuteSql(sql);
        drpstaffname.DataSource = ds;
        drpstaffname.DataTextField = "staffname";
        drpstaffname.DataValueField = "intid";
        drpstaffname.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpstaffname.Items.Insert(0, li);

    }
    protected void subject()
    {
        drpsubject.Items.Clear();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strsubject from tbltimetable where strteacher='" + drpstaffname.SelectedValue + "' and";
        sql += " strstandard='" + drpstandard.SelectedValue + "' and strsection='" + drpsection.SelectedValue + "' and";
        sql += " strperiod='" + drpperiod.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "' and";
        sql += " strday=datename (dw, '" + drpdate.Text+ "') group by strsubject";
        ds = da.ExceuteSql(sql);
        drpsubject.DataSource = ds;
        drpsubject.DataTextField = "strsubject";
        drpsubject.DataValueField = "strsubject";
        drpsubject.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpsubject.Items.Insert(0, li);

    }
    protected void intid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intid,strsubject from tbltimetable a where strteacher='" + drpstaffname.SelectedValue + "' and strstandard='" + drpstandard.SelectedValue + "' and strsection='" + drpsection.SelectedValue + "' and strperiod='" + drpperiod.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "' and strsubject='"+drpsubject.SelectedValue+"' and strday=datename (dw, '" + drpdate.Text+ "') group by intid,strsubject";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblintid.Text =ds.Tables[0].Rows[0]["intid"].ToString();
        }
    }
    protected void substitute()
    {
        drpsubstitute.Items.Clear();
        da = new DataAccess();
        ds = new DataSet();
        sql = "select b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as substitute from tbltimetable a,";
        sql += " tblemployee b where a.intschool='" + Session["schoolid"].ToString() + "' and a.strperiod";
        sql += " not in('" + drpperiod.SelectedValue + "') and b.intid not in (select intstaffid from tblperiodsubtitute  where";
        sql += " dtdate='" + drpdate.Text + "' and strperiod='" + drpperiod.SelectedValue + "')  and b.intid=a.strteacher and";
        sql += " a.strday=datename (dw, '" + drpdate.Text + "') and a.strsubject='" + drpsubject.SelectedValue + "' and"; 
        sql += " a.strteacher not in (select strstaffname from tblleaverequest where intschool=17 and intapproved=1 and";
        sql += " intcancel!=2 and dtfromdate <= '" + drpdate.Text + "' and dttodate >= '" + drpdate.Text + "') group by";
        sql += " b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname";
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpsubstitute.DataSource = ds;
            drpsubstitute.DataTextField = "substitute";
            drpsubstitute.DataValueField = "intid";
            drpsubstitute.DataBind();
            ListItem li = new ListItem("-select-", "0");
            drpsubstitute.Items.Insert(0, li);
        }
        else 
        {
            trmsg.Visible = true;
            lblmsg.Text = "There is no Subject oriented Teacher. Do you want to Assign anyone?";
            
        }
    }

    protected void drpstaffname_SelectedIndexChanged1(object sender, EventArgs e)
    {
        date();
        standard();
        section();
        period();
        subject();
    }
    protected void drpstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        section();
        period();
        subject();
        sub.Visible = true;
        trsub.Visible = false;
        trmsg.Visible = false;
    }
    protected void drpsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        period();
        subject();
        sub.Visible = true;
        trsub.Visible = false;
        trmsg.Visible = false;
    }
    protected void drpperiod_SelectedIndexChanged(object sender, EventArgs e)
    {
        subject();
        sub.Visible = true;
        trsub.Visible = false;
        trmsg.Visible = false;
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand command;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("spperiodsubtitute", conn);
            command.CommandType = CommandType.StoredProcedure;
            if (btnsave.Text == "Save")
            {
                ds = new DataSet();
                da = new DataAccess();
                sql = "select * from  tblperiodsubtitute where intschool=" + Session["schoolID"].ToString() + " and strperiod='" + drpperiod.SelectedValue + "' and strsection='"+drpsection.SelectedValue+"' and strstandard='"+drpstandard.SelectedValue+"' and dtdate='" + drpdate.Text+ "'";
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    command.Parameters.Add("@intid", "0");
                }
                else
                {
                    MsgBox.alert("Already assigned teacher for this Period");
                }
            }
            else
            {
                command.Parameters.Add("@intid", Session["intID"].ToString());
            }
            command.Parameters.Add("@intschool", Session["schoolid"].ToString());
            if (trsub.Visible == true)
            {
                command.Parameters.Add("@intstaffid", drpsubstitute0.SelectedValue);
                command.Parameters.Add("@strsubject", drpsubject0.SelectedValue);
            }
            else
            {
                command.Parameters.Add("@intstaffid", drpsubstitute.SelectedValue);
                command.Parameters.Add("@strsubject", drpsubject.SelectedValue);
            }
            command.Parameters.Add("@inttimetable", lblintid.Text.Trim());
            command.Parameters.Add("@strperiod", drpperiod.SelectedValue);
            command.Parameters.Add("@strstandard",drpstandard.SelectedValue);
            command.Parameters.Add("@strsection",drpsection.SelectedValue);
            command.Parameters.Add("@dtdate", drpdate.SelectedValue);
            command.ExecuteNonQuery();
            conn.Close();
            grid();
            clear();
        }
        catch
        {
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        staffname();
        standard();
        section();
        period();
        subject();
        substitute();
        sub.Visible = true;
        trsub.Visible = false;
        trmsg.Visible = false;
        btnsave.Text = "Save";
    }
    protected void drpsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        intid();
        substitute();
    }
    //protected void grdsubtitute_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    da = new DataAccess();
    //    sql = "delete tblperiodsubtitute where intid="+ e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    grid();
    //}
    protected void grdsubtitute_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        staffname();
        drpstaffname.SelectedValue = e.Item.Cells[7].Text;
        date();
        drpdate.Text = e.Item.Cells[9].Text;
        standard();
        drpstandard.SelectedValue = e.Item.Cells[1].Text;
        section();
        drpsection.SelectedValue = e.Item.Cells[2].Text;
        period();
        drpperiod.SelectedValue = e.Item.Cells[3].Text;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strsubject from tbltimetable a where strteacher='" + drpstaffname.SelectedValue + "' and strstandard='" + drpstandard.SelectedValue + "' and strsection='" + drpsection.SelectedValue + "' and strperiod='" + drpperiod.SelectedValue + "' and intschool='" + Session["SchoolID"].ToString() + "' and strday=datename (dw, '" + drpdate.Text+ "') group by strsubject";
        ds = da.ExceuteSql(sql);
        btnsave.Text = "Update";
        if (ds.Tables[0].Rows.Count > 0)
        {
            string subj = ds.Tables[0].Rows[0]["strsubject"].ToString();
            if (subj == e.Item.Cells[4].Text)
            {
                sub.Visible = true;
                trsub.Visible = false;
                subject();
                drpsubject.SelectedValue = e.Item.Cells[4].Text;
                substitute();
                drpsubstitute.SelectedValue = e.Item.Cells[8].Text;
            }
            else
            {
                sub.Visible = false;
                trsub.Visible = true;
                anysubject();
                drpsubject0.SelectedValue = e.Item.Cells[4].Text;
                anystaff();
                drpsubstitute0.SelectedValue = e.Item.Cells[8].Text;
            }
        }
        intid();
        lblintid.Text = e.Item.Cells[10].Text;
     }
    protected void drpday_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
        section();
        period();
        subject();
   }
    protected void drpmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
        section();
        period();
        subject();
   }
    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
        section();
        period();
        subject();
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        trsub.Visible = true;
        sub.Visible = false;
        anysubject();
        trmsg.Visible = false;
    }
    protected void anystaff()
    {
        drpsubstitute0.Items.Clear();
        da = new DataAccess();
        ds = new DataSet();
        if (btnsave.Text == "Save")
        {
            sql = "select b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as substitute from tbltimetable a,";
            sql += " tblemployee b where a.intschool='" + Session["schoolid"].ToString() + "' and a.strperiod";
            sql += " not in('" + drpperiod.SelectedValue + "') and b.intid not in (select intstaffid from tblperiodsubtitute  where";
            sql += " dtdate='" + drpdate.Text + "' and strperiod='" + drpperiod.SelectedValue + "')  and b.intid=a.strteacher and";
            sql += " a.strday=datename (dw, '" + drpdate.Text + "') and a.strsubject='" + drpsubject0.SelectedValue + "' and";
            sql += " a.strteacher not in (select strstaffname from tblleaverequest where intschool=17 and intapproved=1 and";
            sql += " intcancel!=2 and dtfromdate <= '" + drpdate.Text + "' and dttodate >= '" + drpdate.Text + "') group by b.intid,";
            sql += " b.strfirstname+''+b.strmiddlename+''+b.strlastname";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpsubstitute0.DataSource = ds;
                drpsubstitute0.DataTextField = "substitute";
                drpsubstitute0.DataValueField = "intid";
                drpsubstitute0.DataBind();
                ListItem li = new ListItem("-select-", "0");
                drpsubstitute0.Items.Insert(0, li);
            }
            else
            {
                MsgBox.alert("There is no Staff free to " + drpsubject0.SelectedValue + ". Please try another subject");
            }
        }
        else
        {
            sql = "select b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as substitute from tbltimetable a,";
            sql += " tblemployee b where a.intschool='" + Session["schoolid"].ToString() + "' and a.strperiod";
            sql += " not in('" + drpperiod.SelectedValue + "') and b.intid=a.strteacher and";
            sql += " a.strday=datename (dw, '" + drpdate.Text + "') and a.strsubject='" + drpsubject0.SelectedValue + "' and";
            sql += " a.strteacher not in (select strstaffname from tblleaverequest where intschool=17 and intapproved=1 and";
            sql += " intcancel!=2 and dtfromdate <= '" + drpdate.Text + "' and dttodate >= '" + drpdate.Text + "') group by b.intid,";
            sql += " b.strfirstname+''+b.strmiddlename+''+b.strlastname";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpsubstitute0.DataSource = ds;
                drpsubstitute0.DataTextField = "substitute";
                drpsubstitute0.DataValueField = "intid";
                drpsubstitute0.DataBind();
                ListItem li = new ListItem("-select-", "0");
                drpsubstitute0.Items.Insert(0, li);
            }
            else
            {
                MsgBox.alert("There is no Staff free to " + drpsubject0.SelectedValue + ". Please try another subject");
            }

        }
    }
    protected void anysubject()
    {
        drpsubject0.Items.Clear();
        da = new DataAccess();
        ds = new DataSet();
        sql = "select strsubject from tbltimetable where intschool='" + Session["schoolid"].ToString() + "' and strstandard='"+drpstandard.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(sql);
        drpsubject0.DataSource = ds;
        drpsubject0.DataTextField = "strsubject";
        drpsubject0.DataValueField = "strsubject";
        drpsubject0.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpsubject0.Items.Insert(0, li);
   
    }

    protected void drpsubject0_SelectedIndexChanged(object sender, EventArgs e)
    {
        anystaff();
    }
    protected void drpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
        section();
        period();
        subject();
        sub.Visible = true;
        trsub.Visible = false;
        trmsg.Visible = false;
    }

    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        da = new DataAccess();
        sql = "delete tblperiodsubtitute where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblperiodsubtitute", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),92);

        da.ExceuteSqlQuery(sql);
        grid();
    }
}
