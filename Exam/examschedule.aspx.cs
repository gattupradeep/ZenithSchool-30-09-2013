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

public partial class school_examschedule : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    public SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            fillclass();
            fillexamtype();
            fillsubject();
            fillexampaper();
            fillinvegilator();
            fillgrid();
            fillyear();
            ddlyear.SelectedValue = DateTime.Now.Year.ToString();
            fillday();
            ddlday.SelectedValue = DateTime.Now.Day.ToString();
            ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
            lbldate.Text = "";
            lblfromtime.Text = "";
            lbltotime.Text = "";
            lbldate.Visible = false;
            lblfromtime.Visible = false;
            ddlday.Visible = true;
            ddlmonth.Visible = true;
            ddlyear.Visible = true;
            txtstarttime.Visible = true;
            txtendtime.Visible = true;
            Button1.Visible = false;
           // btnsetseat.Visible = false;
            Button4.Visible = false;
            if (Request["eid"] != null)
                fillupdatedetails();

        }
    }

    protected void fillupdatedetails()
    {
        DataAccess da = new DataAccess();
        string sql = "select *  from tblexamschedule where intid=" + Request["eid"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlclass.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
            fillexamtype();
            ddlexamtype.SelectedValue = ds.Tables[0].Rows[0]["strexamtype"].ToString();
            fillsubject();
            ddlsubject.SelectedValue = ds.Tables[0].Rows[0]["strsubjectname"].ToString();
            fillexampaper();
            ddlexampaper.SelectedValue = ds.Tables[0].Rows[0]["strexampaper"].ToString();
            ddlclass.Enabled = false;
            ddlexamtype.Enabled = false;
            ddlsubject.Enabled = false;
            ddlexampaper.Enabled = false;
            fillinvegilator();
            lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
            ddlday.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtexamdate"].ToString()).Day.ToString();
            ddlmonth.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtexamdate"].ToString()).Month.ToString();
            ddlyear.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtexamdate"].ToString()).Year.ToString();
            ddlinvegilator1.SelectedValue = ds.Tables[0].Rows[0]["strinvegilator"].ToString();
            txtstarttime.Text = ds.Tables[0].Rows[0]["strexamstarttime"].ToString();
            txtendtime.Text = ds.Tables[0].Rows[0]["strexamendtime"].ToString();
            btnsave.Visible = true;
           // btnsetseat.Visible = true;
            Button1.Visible = true;
            Button4.Visible = true;
        }
    }

    protected void fillclass()
    {
        DataAccess da = new DataAccess();
        strsql = "select strclass from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " group by strclass";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strclass";
        ddlclass.DataValueField = "strclass";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "--Select--");
    }

    protected void fillyear()
    {
        int i;
        int j = 0;
        for (i = 2011; i <= DateTime.Today.Year + 20; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear.Items.Insert(j, li);
            j++;
        }
        ddlyear.SelectedValue = DateTime.Today.Year.ToString();
    }

    protected void fillday()
    {
        int i;
        int j = 0;
        for (i = 1; i <= 31; i++)
        {
            ListItem li;
            if (i < 10)
            {
                li = new ListItem("0" + i.ToString(), i.ToString());
            }
            else
            {
                li = new ListItem(i.ToString(), i.ToString());
            }
            ddlday.Items.Insert(j, li);
            j++;
        }
        int d = DateTime.Today.Day;
        ddlday.SelectedValue = DateTime.Today.Day.ToString();
    }

    protected void fillinvegilator()
    {
        try
        {
            strsql = "select intid,strfirstname+' ' +ltrim(strmiddlename)+' ' +ltrim(strlastname) as name from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and intid";
            strsql += " not in(select intstaff from tblstaffattendance  where convert(varchar(11),dtdate,103)='" + ddlday.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlyear.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ")";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlinvegilator1.DataSource = ds;
            ddlinvegilator1.DataTextField = "name";
            ddlinvegilator1.DataValueField = "intid";
            ddlinvegilator1.DataBind();
            ddlinvegilator1.Items.Insert(0, "--Select--");
        }
        catch
        {
            ddlinvegilator1.Items.Insert(0, "--Select--");
        }
    }

    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.*,convert(varchar(10),a.dtexamdate,103) as strexamdate,a.strclass1 as room,";
        sql = sql + "a.strexamstarttime+' - '+a.strexamendtime as time,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name ";
        sql = sql + "from tblexamschedule a,tblemployee b where a.strinvegilator=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " ";
        sql = sql + " and strclass='" + ddlclass.SelectedValue + "' and strsubjectname='" + ddlsubject.SelectedValue + "'";
        sql = sql + " and strexampaper='" + ddlexampaper.SelectedValue + "'";
        if (ddlexamtype.SelectedIndex > 0)
            sql += " and strexamtype='" + ddlexamtype.SelectedValue + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgexamschedule.DataSource = ds;
            dgexamschedule.DataBind();
            dgexamschedule.Visible = true;
        }
        else
        {
            dgexamschedule.Visible = false;
        }
    }

    protected void filllesson()
    {
        DataAccess da = new DataAccess();
        string sql = "select strunitno from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + "";
        sql = sql + " and strstandard='" + ddlclass.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' group by strunitno";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dglesson1.DataSource = ds;
            dglesson1.DataBind();
            dglesson1.Visible = true;
            trsetportion.Visible = true;
        }
        else
        {
            dglesson1.Visible = false;
            trsetportion.Visible = false;
            //msgbox.alert("There is no Lesson set for this Exam Paper");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('There is no Lesson set for this Exam Paper')", true);
        }
    }

    protected void fillexamtype()
    {
        strsql = "select strexamtype from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' group by strexamtype";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "strexamtype";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0, "--Select--");
    }

    protected void fillsubject()
    {
        strsql = "select strsubject from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "' group by strsubject";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "--Select--");
    }

    protected void fillexampaper()
    {
        strsql = "select strexampapername from tblschoolexamsettings where intschoolid=" + Session["SchoolID"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' group by strexampapername";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlexampaper.DataSource = ds;
        ddlexampaper.DataTextField = "strexampapername";
        ddlexampaper.DataValueField = "strexampapername";
        ddlexampaper.DataBind();
        ddlexampaper.Items.Insert(0, "--Select--");
    }

    protected void fillrollno()
    {
        string strsql = "";
        strsql = "select strrollnos,strroomtype,strclass from tblschoolsetseating where intexamid=" + lblid.Text;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        string strrollno = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
            {
                if (ddlroomtype.SelectedIndex > 0 && ddlclass1.SelectedIndex > 0)
                {
                }
                else
                {
                    ddlroomtype.SelectedValue = ds.Tables[0].Rows[i]["strroomtype"].ToString();
                    fillclass1();
                    ddlclass1.SelectedValue = ds.Tables[0].Rows[i]["strclass"].ToString();
                }
            }

            if (strrollno == "")
                strrollno = ds.Tables[0].Rows[i]["strrollnos"].ToString();
            else
                strrollno = strrollno + "," + ds.Tables[0].Rows[i]["strrollnos"].ToString();
        }
        if (strrollno != "")
            strsql = "select introllno from tblstudent where introllno not in (" + strrollno + ") and intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection='" + ddlclass.SelectedValue + "' group by introllno order by introllno asc";
        else
            strsql = "select introllno from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection='" + ddlclass.SelectedValue + "' group by introllno order by introllno asc";

        Session["SetRoolNos"] = strsql;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        //lblcount.Text = ds.Tables[0].Rows.Count.ToString();
        int ItemCount = (int)Math.Ceiling(ds.Tables[0].Rows.Count / 10m);
        strsql = "";
        for (int i = 1; i <= ItemCount; i++)
        {
            if (strsql == "")
                strsql = "select " + i.ToString() + " as ct ";
            else
                strsql = strsql + "union all select " + i.ToString() + " as ct ";
        }
        if (strsql != "")
        {
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            dlrollno.DataSource = ds;
            dlrollno.DataBind();
            trrollno.Visible = true;
            trrollnoadd.Visible = true;
        }
        else
        {
            trrollno.Visible = false;
            trrollnoadd.Visible = false;
        }
        fillrollno1();
    }
    protected void fillrollno1()
    {
        if (ddlroomtype.SelectedIndex > 0 && ddlclass1.SelectedIndex > 0)
        {
            string strsql = "";
            strsql = "select strrollnos,strroomtype,strclass from tblschoolsetseating where intexamid=" + lblid.Text + " and strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "'";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            string strrollno = "";
            if (ds.Tables[0].Rows.Count > 0)
                strrollno = ds.Tables[0].Rows[0]["strrollnos"].ToString();

            if (strrollno != "")
            {
                strsql = "select introllno from tblstudent where introllno in (" + strrollno + ") and intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection='" + ddlclass.SelectedValue + "' group by introllno order by introllno asc";
                Session["SetRoolNos1"] = strsql;
                da = new DataAccess();
                ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                //lblcount.Text = ds.Tables[0].Rows.Count.ToString();
                int ItemCount = (int)Math.Ceiling(ds.Tables[0].Rows.Count / 10m);
                strsql = "";
                for (int i = 1; i <= ItemCount; i++)
                {
                    if (strsql == "")
                        strsql = "select " + i.ToString() + " as ct ";
                    else
                        strsql = strsql + "union all select " + i.ToString() + " as ct ";
                }
                if (strsql != "")
                {
                    da = new DataAccess();
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    dlrollno1.DataSource = ds;
                    dlrollno1.DataBind();
                    traddednos.Visible = true;
                    btnremove.Visible = true;
                }
                else
                {
                    traddednos.Visible = false;
                    btnremove.Visible = false;
                }
            }
            else
            {
                traddednos.Visible = false;
                btnremove.Visible = false;
            }
        }
        else
        {
            traddednos.Visible = false;
            btnremove.Visible = false;
        }
        availability();
    }

    protected void fillclass1()
    {
        if (ddlroomtype.SelectedValue == "Classes")
            strsql = "select strclass + ' - ' + strsection as strclass,strcapacity from tblroomcapacity where intschool=" + Session["SchoolID"].ToString() + " and strclass!='' and strroomtype='Classes'";
        else
            strsql = "select strother as strclass,strcapacity from tblroomcapacity where intschool=" + Session["SchoolID"].ToString() + " and strother!='' and strroomtype='Others'";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlclass1.DataSource = ds;
        ddlclass1.Items.Clear();
        ddlclass1.DataTextField = "strclass";
        ddlclass1.DataValueField = "strclass";
        ddlclass1.DataBind();
        ddlclass1.Items.Insert(0, "Select");
    }

    protected void fillsection1()
    {
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillexamtype();
        fillsubject();
        fillexampaper();
        fillinvegilator();
        fillgrid();
        ddlexamtype.SelectedIndex = 0;
        ddlsubject.SelectedIndex = 0;
        ddlexampaper.SelectedIndex = 0;
        ddlyear.SelectedValue = DateTime.Now.Year.ToString();
        int d = DateTime.Today.Day;
        if (d < 10)
            ddlday.SelectedValue = DateTime.Today.Day.ToString();
        else
            ddlday.SelectedValue = DateTime.Today.Day.ToString();
        ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
        trsetportion.Visible = false;
        trsetseating.Visible = false;
        lblid.Text = "0";
    }

    protected void ddlsubject_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fillexampaper();
        fillinvegilator();
        ddlexampaper.SelectedIndex = 0;
        ddlyear.SelectedValue = DateTime.Now.Year.ToString();
        int d = DateTime.Today.Day;
        if (d < 10)
            ddlday.SelectedValue = DateTime.Today.Day.ToString();
        else
            ddlday.SelectedValue = DateTime.Today.Day.ToString();
        ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
        trsetportion.Visible = false;
        trsetseating.Visible = false;
        Button1.Visible = false;
       // btnsetseat.Visible = false;
        Button4.Visible = false;
        lblid.Text = "0";
    }

    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsubject();
        fillexampaper();
        fillinvegilator();
        fillgrid();
        ddlexampaper.SelectedIndex = 0;
        ddlsubject.SelectedIndex = 0;
        ddlyear.SelectedValue = DateTime.Now.Year.ToString();
        int d = DateTime.Today.Day;
        if (d < 10)
            ddlday.SelectedValue = DateTime.Today.Day.ToString();
        else
            ddlday.SelectedValue = DateTime.Today.Day.ToString();
        ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
        trsetportion.Visible = false;
        trsetseating.Visible = false;
        Button1.Visible = false;
        //btnsetseat.Visible = false;
        Button4.Visible = false;
        lblid.Text = "0";
    }

    protected void ddlexampaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlexampaper.SelectedIndex > 0)
        {
            Button1.Visible = true;
            //btnsetseat.Visible = true;
            Button4.Visible = false;
            fillinvegilator();
            fillgrid();
            trsetportion.Visible = false;
            trsetseating.Visible = false;
            lblid.Text = "0";
        }
        else
        {
            Button1.Visible = false;
           // btnsetseat.Visible = false;
            Button4.Visible = false;
            trsetportion.Visible = false;
            trsetseating.Visible = false;
            lblid.Text = "0";
        }
    }

    protected void ddlroomtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlroomtype.SelectedIndex > 0)
        {
            fillclass1();
            fillrollno1();
        }
        lblremaining.Text = "";
        lblroomcapacity.Text = "";
    }

    protected void ddlclass1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlclass1.SelectedIndex > 0)
        {
            lblroomcapacity.Text = ddlclass1.SelectedValue;
            fillrollno1();
            availability();
        }
    }

    protected void saveexamschedule()
    {
        if (ddlclass.SelectedIndex > 0)
        {
            if (ddlexamtype.SelectedIndex > 0)
            {
                if (ddlsubject.SelectedIndex > 0)
                {
                    if (ddlexampaper.SelectedIndex > 0)
                    {
                        DataAccess da = new DataAccess();
                        string sql = "select intid,strinvegilator,strexamstarttime,strexamendtime from tblexamschedule where intschool=" + Session["SchoolID"].ToString() + " ";
                        sql = sql + " and strclass='" + ddlclass.SelectedValue + "' and strsubjectname='" + ddlsubject.SelectedValue + "'";
                        sql = sql + " and strexampaper='" + ddlexampaper.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "' and dtexamdate='" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue + "/" + ddlyear.SelectedValue + "'";
                        DataSet ds = new DataSet();
                        ds = da.ExceuteSql(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblid.Text = ds.Tables[0].Rows[0]["intid"].ToString();
                            ddlinvegilator1.SelectedValue = ds.Tables[0].Rows[0]["strinvegilator"].ToString();
                            txtstarttime.Text = ds.Tables[0].Rows[0]["strexamstarttime"].ToString();
                            txtendtime.Text = ds.Tables[0].Rows[0]["strexamendtime"].ToString();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already Exam is Scheduled')", true);
                        }
                        else
                        {
                            int interror = 0;
                            sql = "select intid,strinvegilator,strexamstarttime,strexamendtime from tblexamschedule where intschool=" + Session["SchoolID"].ToString() + " ";
                            sql = sql + " and strclass='" + ddlclass.SelectedValue + "'";
                            sql = sql + " and dtexamdate='" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue + "/" + ddlyear.SelectedValue + "'";
                            ds = new DataSet();
                            ds = da.ExceuteSql(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DateTime st = DateTime.Parse(txtstarttime.Text.Trim());
                                DateTime et = DateTime.Parse(txtendtime.Text.Trim());
                                DateTime st1 = DateTime.Parse(ds.Tables[0].Rows[0]["strexamstarttime"].ToString());
                                DateTime et1 = DateTime.Parse(ds.Tables[0].Rows[0]["strexamendtime"].ToString());
                                if ((st >= st1 && st <= et1) || (et > st1 && et <= et1))
                                    interror = 1;
                            }
                            if (interror == 0)
                            {
                                if (ddlinvegilator1.SelectedIndex > 0)
                                {
                                    if (txtstarttime.Text != "" && txtstarttime.Text != "0:00" && txtstarttime.Text != "00:00")
                                    {
                                        if (txtendtime.Text != "" && txtendtime.Text != "0:00" && txtendtime.Text != "00:00")
                                        {
                                            try
                                            {
                                                DateTime st = DateTime.Parse(txtstarttime.Text.Trim());
                                                DateTime et = DateTime.Parse(txtendtime.Text.Trim());
                                                if (et > st)
                                                {
                                                    string strdt = ddlyear.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue;
                                                    if ((DateTime.Parse(ddlmonth.SelectedValue + "/" + ddlday.SelectedValue + "/" + ddlyear.SelectedValue) > DateTime.Today))
                                                        if ((DateTime.Parse(ddlyear.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue) > DateTime.Today))
                                                        {
                                                            sql = "select * from tblexamschedule where dtexamdate='" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue + "/" + ddlyear.SelectedValue + "' and (('" + txtstarttime.Text.Trim() + "' >= strexamstarttime and '" + txtstarttime.Text.Trim() + "'<= strexamendtime) or ('" + txtendtime.Text.Trim() + "' >= strexamstarttime and '" + txtendtime.Text.Trim() + "'<= strexamendtime)) and strinvegilator=" + ddlinvegilator1.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
                                                            ds = new DataSet();
                                                            da = new DataAccess();
                                                            ds = da.ExceuteSql(sql);
                                                            if (ds.Tables[0].Rows.Count > 0)
                                                            {
                                                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invigilator Already Assinged to " + ds.Tables[0].Rows[0]["strclass"].ToString() + "')", true);
                                                            }
                                                            else
                                                            {
                                                                SqlCommand cmd;
                                                                SqlParameter Outputparameter;
                                                                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                                                                conn.Open();
                                                                cmd = new SqlCommand("spexamschedule", conn);
                                                                cmd.CommandType = CommandType.StoredProcedure;
                                                                Outputparameter = cmd.Parameters.Add("@rc", SqlDbType.Int);
                                                                Outputparameter.Direction = ParameterDirection.Output;
                                                                cmd.Parameters.Add("@intid", lblid.Text);
                                                                cmd.Parameters.Add("@strclass", ddlclass.SelectedValue);
                                                                cmd.Parameters.Add("@strexamtype", ddlexamtype.SelectedValue);
                                                                cmd.Parameters.Add("@strsubjectname", ddlsubject.SelectedValue);
                                                                cmd.Parameters.Add("@strexampaper", ddlexampaper.SelectedValue);

                                                                if (lbldate.Text != "")
                                                                    cmd.Parameters.Add("@dtexamdate", lbldate.Text);
                                                                else
                                                                    cmd.Parameters.Add("@dtexamdate", ddlyear.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue);
                                                                if (lblfromtime.Text != "")
                                                                    cmd.Parameters.Add("@strexamstarttime", lblfromtime.Text);
                                                                else
                                                                    cmd.Parameters.Add("@strexamstarttime", txtstarttime.Text.Trim());
                                                                if (lbltotime.Text != "")
                                                                    cmd.Parameters.Add("@strexamendtime", lbltotime.Text);
                                                                else
                                                                    cmd.Parameters.Add("@strexamendtime", txtendtime.Text.Trim());
                                                                cmd.Parameters.Add("@intfromrollno", "0");
                                                                cmd.Parameters.Add("@inttorollno", "0");
                                                                cmd.Parameters.Add("@strroomtype", ddlroomtype.SelectedValue);
                                                                cmd.Parameters.Add("@strclass1", ddlclass1.SelectedValue);
                                                                cmd.Parameters.Add("@strroomcapacity", lblroomcapacity.Text.Trim());
                                                                cmd.Parameters.Add("@strinvegilator", ddlinvegilator1.SelectedValue);
                                                                cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                                                                cmd.ExecuteNonQuery();
                                                                if ((int)(cmd.Parameters["@rc"].Value) > 0)
                                                                {
                                                                    lblid.Text = ((int)(cmd.Parameters["@rc"].Value)).ToString();
                                                                }
                                                                conn.Close();
                                                                string id = Convert.ToString(Outputparameter.Value);
                                                                Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedule", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 46);
                                                                fillgrid();
                                                            }
                                                        }
                                                        else
                                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Date')", true);
                                                }
                                                else
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Start Time or End Time')", true);
                                            }
                                            catch
                                            {
                                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Start Time or End Time')", true);
                                            }
                                        }
                                        else
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select End Time')", true);
                                    }
                                    else
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Start Time')", true);
                                }
                                else
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select The Invigilator')", true);
                            }
                            else
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Class has another exam in same time')", true);
                        }
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Exam Paper')", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Subject')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Exam Type')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class')", true);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (ddlinvegilator1.SelectedIndex > 0)
        {
            if (txtstarttime.Text != "")
            {
                if (txtendtime.Text != "")
                {
                    strsql = "update tblexamschedule set dtexamdate='" + ddlyear.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue + "', strexamstarttime='" + txtstarttime.Text + "', strexamendtime='" + txtendtime.Text + "',strinvegilator=" + ddlinvegilator1.SelectedValue + " where intid=" + lblid.Text;
                    Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedule",lblid.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),46);
                    da = new DataAccess();
                    da.ExceuteSqlQuery(strsql);
                }

                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select End Time')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Start Time')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select The Invigilator')", true);
        if (Request["eid"] != null)
            //Response.Redirect("edit_examschedule.aspx?eid=1");
           ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='edit_examschedule.aspx?eid=1';", true);
    }

    protected void btnClear_Click1(object sender, EventArgs e)
    {
        allclear();
        fillrollno();
        ddlroomtype.SelectedIndex = 0;
        fillclass1();
        fillsection1();
        fillinvegilator();
        lblroomcapacity.Text = "";
        lblremaining.Text = "";
        btnsave.Text = "Save";
        ddlclass.SelectedIndex = 0;
        ddlsubject.SelectedIndex = 0;
        ddlexamtype.SelectedIndex = 0;
        ddlexampaper.SelectedIndex = 0;
        ddlyear.SelectedValue = DateTime.Now.Year.ToString();
        fillday();
        ddlday.SelectedValue = DateTime.Now.Day.ToString();
        ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
        lblfromtime.Visible = false;
        lbltotime.Visible = false;
        txtendtime.Visible = true;
        txtstarttime.Visible = true;
        txtstarttime.Text = "";
        txtendtime.Text = "";
    }

    protected void availability()
    {
        if (ddlroomtype.SelectedValue == "Classes")
            strsql = "select * from tblroomcapacity where intschool=" + Session["SchoolID"].ToString() + " and strclass+ ' - ' + strsection='" + ddlclass1.SelectedValue + "' and strroomtype='" + ddlroomtype.SelectedValue + "'";
        else
            strsql = "select * from tblroomcapacity where intschool=" + Session["SchoolID"].ToString() + " and strother='" + ddlclass1.SelectedValue + "' and strroomtype='" + ddlroomtype.SelectedValue + "'";
        ds = new DataSet();
        da = new DataAccess();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
            lblroomcapacity.Text = ds.Tables[0].Rows[0]["strcapacity"].ToString();
        else
            lblroomcapacity.Text = "0";

        strsql = "select sum(intnoofstudents) as ct from tblschoolsetseating where intschool=" + Session["SchoolID"].ToString() + " and intexamid in(select intid from tblexamschedule where dtexamdate='" + ddlyear.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlday.SelectedValue + "')and strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "'";
        ds = new DataSet();
        da = new DataAccess();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                lblremaining.Text = (int.Parse(lblroomcapacity.Text) - int.Parse(ds.Tables[0].Rows[0]["ct"].ToString())).ToString();
            }
            catch
            {
                lblremaining.Text = lblroomcapacity.Text;
            }
        }
        else
            lblremaining.Text = int.Parse(lblroomcapacity.Text).ToString();
    }

    protected void changerollno()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string strsql;
        string[] rno;
        string[] rno2;
        int c = 0;
        strsql = "select strrollno from tblexamschedule where intid=" + Session["id"].ToString() + " and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rno = ds.Tables[0].Rows[0]["strrollno"].ToString().Split(',');
            strsql = "select * from tblexamschedule where intschool=" + Session["SchoolID"].ToString() + " and intid <>" + Session["id"].ToString() + " and strclass='" + ddlclass.SelectedValue + "' and strsubjectname='" + ddlsubject.SelectedValue + "' and strexamtype='" + ddlexamtype.SelectedValue + "' and strexampaper='" + ddlexampaper.SelectedValue + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                rno2 = ds.Tables[0].Rows[i]["strrollno"].ToString().Split(',');
                for (int k = 0; k < rno.Length; k++)
                {
                    for (int j = 0; j < rno2.Length; j++)
                    {
                        if (rno[k] == rno2[j])
                        {
                            rno2[j] = null;
                            rno2 = rno2.Where(ele => ele != null).Select(ele => ele).ToArray();//removing null from string array
                            c = 1;
                        }
                    }
                }
                if (c == 1)
                {
                    string rollno = string.Join(",", rno2);//converting string array to string                    
                    da = new DataAccess();
                    strsql = "update tblexamschedule set strrollno='" + rollno + "' where intid=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and intschool=" + Session["SchoolID"].ToString();
                    Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedule", ds.Tables[0].Rows[i]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),46);

                    da.ExceuteSqlQuery(strsql);
                    c = 0;
                }
            }
        }
    }

    protected void allclear()
    {
        fillrollno1();
        ddlroomtype.SelectedIndex = 0;
        fillclass1();
        fillsection1();
        fillinvegilator();
        lblroomcapacity.Text = "";
        lblremaining.Text = "";
        btnsave.Text = "Save";
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (lblid.Text == "0")
        {
            saveexamschedule();
        }
        if (lblid.Text != "0")
        {
            filllesson();
            trsetseating.Visible = false;
            //trsetportion.Visible = true;
            Button4.Visible = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        saveexamschedule();
        if (Request["eid"] != null)
            Response.Write("<script>javascript:history.go(-1);</script>");
        else
        {
            fillclass();
            fillexamtype();
            fillsubject();
            fillexampaper();
            fillinvegilator();
            fillgrid();
            fillyear();
            ddlyear.SelectedValue = DateTime.Now.Year.ToString();
            fillday();
            ddlday.SelectedValue = DateTime.Now.Day.ToString();
            ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
            lbldate.Text = "";
            lblfromtime.Text = "";
            lbltotime.Text = "";
            lbldate.Visible = false;
            lblfromtime.Visible = false;
            ddlday.Visible = true;
            ddlmonth.Visible = true;
            ddlyear.Visible = true;
            txtstarttime.Visible = true;
            txtendtime.Visible = true;
            Button1.Visible = false;
            //btnsetseat.Visible = false;
            Button4.Visible = false;
            ddlinvegilator1.SelectedIndex = 0;
            txtendtime.Text = "";
            txtstarttime.Text = "";
            lblid.Text = "0";
        }
    }

    protected void btnsetseat_Click(object sender, EventArgs e)
    {
        if (lblid.Text == "0")
        {
            saveexamschedule();
        }
        if (lblid.Text != "0")
        {
            fillrollno();
            trsetseating.Visible = true;
            trsetportion.Visible = false;
            Button4.Visible = true;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        trsetseating.Visible = false;
        trsetportion.Visible = false;
    }

    protected void dlrollno_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblrid = (Label)e.Item.FindControl("lblrid");
            CheckBoxList chkrollno = (CheckBoxList)e.Item.FindControl("chkrollno");
            CheckBox chkselectall = (CheckBox)e.Item.FindControl("chkselectall");
            string strsql = "";
            //strsql = "select introllno from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection='" + ddlclass.SelectedValue + "' group by introllno order by introllno asc";
            strsql = Session["SetRoolNos"].ToString();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            int s, n = 0;
            s = int.Parse(lblrid.Text);
            s = ((s - 1) * 10);
            n = s + 9;
            if (n > ds.Tables[0].Rows.Count - 1)
                n = ds.Tables[0].Rows.Count - 1;
            chkrollno.Items.Clear();
            for (int i = s; i <= n; i++)
            {
                ListItem li = new ListItem(ds.Tables[0].Rows[i]["introllno"].ToString(), ds.Tables[0].Rows[i]["introllno"].ToString());
                chkrollno.Items.Add(li);
            }
        }
        catch { }
    }

    protected void chksellectall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox list = (CheckBox)sender;
            DataListItem item = list.Parent as DataListItem;
            CheckBox chkall = (CheckBox)item.FindControl("chkselectall");
            CheckBoxList chkrollno = (CheckBoxList)item.FindControl("chkrollno");
            for (int i = 0; i < chkrollno.Items.Count; i++)
            {
                if (list.Checked)
                    chkrollno.Items[i].Selected = true;
                else
                    chkrollno.Items[i].Selected = false;
            }
        }
        catch
        {
        }
    }

    protected void btnaddtoroom_Click(object sender, EventArgs e)
    {
        if (ddlroomtype.SelectedIndex > 0)
        {
            if (ddlclass1.SelectedIndex > 0)
            {
                string str = "";
                int rct = 0;
                foreach (DataListItem dlit in dlrollno.Items)
                {
                    DataRowView drd = (DataRowView)dlit.DataItem;
                    CheckBoxList chkrollno = (CheckBoxList)dlit.FindControl("chkrollno");

                    for (int i = 0; i < chkrollno.Items.Count; i++)
                    {
                        if (chkrollno.Items[i].Selected == true)
                        {
                            rct++;
                            if (str.Length == 0)
                            {
                                str = chkrollno.Items[i].Value.ToString();
                            }
                            else
                            {
                                str = str + "," + chkrollno.Items[i].Value.ToString();
                            }
                        }
                    }
                }
                if (rct <= int.Parse(lblremaining.Text))
                {
                    string strsql;
                    da = new DataAccess();
                    strsql = "select strrollnos,intnoofstudents from tblschoolsetseating where strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                    ds = new DataSet();
                    ds = da.ExceuteSql(strsql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["strrollnos"].ToString() != "" && str != "")
                            str = ds.Tables[0].Rows[0]["strrollnos"].ToString() + "," + str;
                        rct = rct + int.Parse(ds.Tables[0].Rows[0]["intnoofstudents"].ToString());
                    }

                    DataAccess da1 = new DataAccess();
                    DataSet ds1 = new DataSet();
                    strsql = "select intid from tblschoolsetseating where strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                    ds1 = da1.ExceuteSql(strsql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsetseating", ds1.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),46);
                        }
                    }
                    da = new DataAccess();
                    strsql = "delete tblschoolsetseating where strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                    da.ExceuteSqlQuery(strsql);

                    da = new DataAccess();
                    DataSet ds2 = new DataSet();
                    strsql = "insert into tblschoolsetseating (strroomtype,strclass,strrollnos,intnoofstudents,intexamid,intschool) values(";
                    strsql = strsql + "'" + ddlroomtype.SelectedValue + "','" + ddlclass1.SelectedValue + "','" + str + "'," + rct + "," + lblid.Text + "," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(strsql);

                    da = new DataAccess();
                    strsql = "select max(intid) as intid from tblschoolsetseating";
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsetseating", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),46);
                    fillrollno();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No of Selected Seats are Greater Than Avilable Seats')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Room Type')", true);
    }
    protected void dlrollno1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblrid = (Label)e.Item.FindControl("lblrid");
            CheckBoxList chkrollno = (CheckBoxList)e.Item.FindControl("chkrollno");
            CheckBox chkselectall = (CheckBox)e.Item.FindControl("chkselectall");
            string strsql = "";
            //strsql = "select introllno from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection='" + ddlclass.SelectedValue + "' group by introllno order by introllno asc";
            strsql = Session["SetRoolNos1"].ToString();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            int s, n = 0;
            s = int.Parse(lblrid.Text);
            s = ((s - 1) * 10);
            n = s + 9;
            if (n > ds.Tables[0].Rows.Count - 1)
                n = ds.Tables[0].Rows.Count - 1;
            chkrollno.Items.Clear();
            for (int i = s; i <= n; i++)
            {
                ListItem li = new ListItem(ds.Tables[0].Rows[i]["introllno"].ToString(), ds.Tables[0].Rows[i]["introllno"].ToString());
                chkrollno.Items.Add(li);
            }
        }
        catch { }

    }
    protected void chksellectall1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox list = (CheckBox)sender;
            DataListItem item = list.Parent as DataListItem;
            CheckBoxList chkrollno = (CheckBoxList)item.FindControl("chkrollno");
            for (int i = 0; i < chkrollno.Items.Count; i++)
            {
                if (list.Checked)
                    chkrollno.Items[i].Selected = true;
                else
                    chkrollno.Items[i].Selected = false;
            }
        }
        catch
        {
        }
    }

    protected void btnremove_Click(object sender, EventArgs e)
    {
        if (ddlroomtype.SelectedIndex > 0)
        {
            if (ddlclass1.SelectedIndex > 0)
            {
                string str = "";
                int rct = 0;
                foreach (DataListItem dlit in dlrollno1.Items)
                {
                    DataRowView drd = (DataRowView)dlit.DataItem;
                    CheckBoxList chkrollno = (CheckBoxList)dlit.FindControl("chkrollno");

                    for (int i = 0; i < chkrollno.Items.Count; i++)
                    {
                        if (chkrollno.Items[i].Selected == false)
                        {
                            rct++;
                            if (str.Length == 0)
                            {
                                str = chkrollno.Items[i].Value.ToString();
                            }
                            else
                            {
                                str = str + "," + chkrollno.Items[i].Value.ToString();
                            }
                        }
                    }
                }
                strsql = "select intid from tblschoolsetseating where strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsetseating", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 46);

                    }
                }
                da = new DataAccess();
                strsql = "delete tblschoolsetseating where strroomtype='" + ddlroomtype.SelectedValue + "' and strclass='" + ddlclass1.SelectedValue + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                da.ExceuteSqlQuery(strsql);

                if (str != "")
                {
                    da = new DataAccess();
                    DataSet ds2 = new DataSet();
                    strsql = "insert into tblschoolsetseating (strroomtype,strclass,strrollnos,intnoofstudents,intexamid,intschool) values(";
                    strsql = strsql + "'" + ddlroomtype.SelectedValue + "','" + ddlclass1.SelectedValue + "','" + str + "'," + rct + "," + lblid.Text + "," + Session["SchoolID"].ToString() + ")";
                    da.ExceuteSqlQuery(strsql);

                    strsql = "select max(intid) as intid from tblschoolsetseating";
                    ds = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsetseating", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 46);

                }

                fillrollno();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Room Type')", true);
    }

    protected void btnaddlesson_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        foreach (DataGridItem dlit in dglesson1.Items)
        {
            string str = "";
            DataRowView drd = (DataRowView)dlit.DataItem;
            CheckBox chkunitno = (CheckBox)dlit.FindControl("chkunitno");
            CheckBoxList chklesson = (CheckBoxList)dlit.FindControl("chklesson");

            if (chkunitno.Checked == true)
            {
                for (int i = 0; i < chklesson.Items.Count; i++)
                {
                    if (chklesson.Items[i].Selected == true)
                    {
                        if (str.Length == 0)
                        {
                            str = chklesson.Items[i].Value.ToString();
                        }
                        else
                        {
                            str = str + "," + chklesson.Items[i].Value.ToString();
                        }
                    }
                }

                strsql = "select intid from tblexamschedulelessons where strunintno='" + chkunitno.Text + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedulelessons", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 46);
                    }
                }

                da = new DataAccess();
                strsql = "delete tblexamschedulelessons where strunintno='" + chkunitno.Text + "' and intexamid=" + lblid.Text + " and intschool=" + Session["SchoolID"].ToString() + "";
                da.ExceuteSqlQuery(strsql);

                da = new DataAccess();
                DataSet ds2 = new DataSet();
                strsql = "insert into tblexamschedulelessons (strunintno,strlessonnames,intexamid,intschool) values(";
                strsql = strsql + "'" + chkunitno.Text + "','" + str + "'," + lblid.Text + "," + Session["SchoolID"].ToString() + ")";
                da.ExceuteSqlQuery(strsql);

                strsql = "select max(intid) as intid from tblexamschedulelessons";
                ds2 = da.ExceuteSql(strsql);
                Functions.UserLogs(Session["UserID"].ToString(), "tblexamschedulelessons", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 46);

            }
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Leasons are added')", true);
    }

    protected void dglesson1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblrid = (Label)e.Item.FindControl("lblrid");
            CheckBoxList chklesson = (CheckBoxList)e.Item.FindControl("chklesson");
            CheckBox chkunitno = (CheckBox)e.Item.FindControl("chkunitno");
            DataAccess da = new DataAccess();
            string sql = "select a.strlessonname,a.intid,'Red' as strcolor from tblschoolsyllabus a,tblsetlessonplan b";
            sql = sql + " where a.strstandard=substring(strclassperiod,charindex('/',strclassperiod)+1,len(strclassperiod)-charindex('/',strclassperiod))";
            sql = sql + " and a.inttextbook=b.inttextbook and a.strunitno=b.strunitname and a.strlessonname=b.strlessonname and a.strsubject=b.strsubject and a.intschool=b.intschool and b.intapproval=0";
            sql = sql + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard='" + ddlclass.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and a.strunitno='" + chkunitno.Text + "' group by a.strlessonname,a.intid";

            sql = sql + " union all select a.strlessonname,a.intid,'#C1590F' as strcolor from tblschoolsyllabus a,tblsetlessonplan b";
            sql = sql + " where a.strstandard=substring(strclassperiod,charindex('/',strclassperiod)+1,len(strclassperiod)-charindex('/',strclassperiod))";
            sql = sql + " and a.inttextbook=b.inttextbook and a.strunitno=b.strunitname and a.strlessonname=b.strlessonname and a.strsubject=b.strsubject and a.intschool=b.intschool and b.intapproval=1";
            sql = sql + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard='" + ddlclass.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and a.strunitno='" + chkunitno.Text + "' group by a.strlessonname,a.intid";

            sql = sql + " union all select a.strlessonname,a.intid,'Green' as strcolor from tblschoolsyllabus a,tblsetlessonplan b";
            sql = sql + " where a.strstandard=substring(strclassperiod,charindex('/',strclassperiod)+1,len(strclassperiod)-charindex('/',strclassperiod))";
            sql = sql + " and a.inttextbook=b.inttextbook and a.strunitno=b.strunitname and a.strlessonname=b.strlessonname and a.strsubject=b.strsubject and a.intschool=b.intschool and b.intcompleted=1";
            sql = sql + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard='" + ddlclass.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and a.strunitno='" + chkunitno.Text + "' group by a.strlessonname,a.intid";

            sql = sql + " union all select strlessonname,intid,'Red' as strcolor from tblschoolsyllabus";
            sql = sql + " where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlclass.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strunitno='" + chkunitno.Text + "'";
            sql = sql + " and intid not in (";
            sql = sql + "select a.intid from tblschoolsyllabus a,tblsetlessonplan b";
            sql = sql + " where a.strstandard=substring(strclassperiod,charindex('/',strclassperiod)+1,len(strclassperiod)-charindex('/',strclassperiod))";
            sql = sql + " and a.inttextbook=b.inttextbook and a.strunitno=b.strunitname and a.strlessonname=b.strlessonname and a.strsubject=b.strsubject and a.intschool=b.intschool ";
            sql = sql + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.strstandard='" + ddlclass.SelectedValue + "' and a.strsubject='" + ddlsubject.SelectedValue + "' and a.strunitno='" + chkunitno.Text + "' group by a.strlessonname,a.intid";
            sql = sql + " )group by strlessonname,intid";

            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chklesson.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li = new ListItem("<span style=\"color:" + ds.Tables[0].Rows[i]["strcolor"].ToString() + "\">" + ds.Tables[0].Rows[i]["strlessonname"].ToString() + "</span>", ds.Tables[0].Rows[i]["intid"].ToString());
                chklesson.Items.Add(li);
            }
            da = new DataAccess();
            sql = "select strlessonnames from tblexamschedulelessons where intschool=" + Session["SchoolID"].ToString() + "";
            sql = sql + " and intexamid=" + lblid.Text + " and strunintno='" + chkunitno.Text + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int sl = 0;
                try
                {
                    for (int i = 0; i < chklesson.Items.Count; i++)
                    {
                        string[] abc = ds.Tables[0].Rows[0]["strlessonnames"].ToString().Split(',');
                        for (int j = 0; j < abc.Length; j++)
                        {
                            if (chklesson.Items[i].Value.ToString() == abc[j].Trim())
                            {
                                chklesson.Items[i].Selected = true;
                                sl++;
                            }
                        }
                    }
                    if (sl == chklesson.Items.Count)
                        chkunitno.Checked = true;
                    else
                        chkunitno.Checked = false;
                }
                catch { }
            }
        }
        catch { }
    }

    protected void chkunitno_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox list = (CheckBox)sender;
            TableCell cell = list.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            CheckBox chkunitno = (CheckBox)item.FindControl("chkunitno");
            CheckBoxList chklesson = (CheckBoxList)item.FindControl("chklesson");
            for (int i = 0; i < chklesson.Items.Count; i++)
            {
                if (chkunitno.Checked)
                    chklesson.Items[i].Selected = true;
                else
                    chklesson.Items[i].Selected = false;
            }
        }
        catch
        {
        }
    }
}
