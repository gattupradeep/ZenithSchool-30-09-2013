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

public partial class admission_viewassignedroom_date : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            standard();
            buildname();
            fillgrid();
            tdbuild.Visible = false;
            tdbuildname.Visible = false;
        }
    }
    protected void buildname()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select b.strbuildname from tbladmissioninterview a,tblbuilding b where dtdate='" + ddldate.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intid=a.strbuildingname and a.intschool=" + Session["SchoolID"].ToString()+" group by b.strbuildname";
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildname";
            ddlbuildname.DataValueField = "strbuildname";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");
            ddlbuildname.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select b.strbuildname from tbladmissioninterview a,tblbuilding b where dtdate='" + ddldate.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intid=a.strbuildingname and a.intschool=" + Session["SchoolID"].ToString() + " group by b.strbuildname";
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildname";
            ddlbuildname.DataValueField = "strbuildname";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");
            ddlbuildname.Items.Insert(1, "-All-");
        }
    }
    protected void standard()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissioninterview where dtdate='" + ddldate.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
            ddlstandard.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissioninterview where dtdate='" + ddldate.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
            ddlstandard.Items.Insert(1, "-All-");
        }
    }
    protected void date()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
    }
    protected void fillgrid()
    {
        if (RBsY.Checked == true)
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblbuilding b,tblemployee c,tblstudentadmission d where a.strbuildingname=b.intid and a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddllist.SelectedValue + " and d.intapprove=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl ";
                if (ddldate.SelectedIndex > 1)
                {
                    str = str + " and a.dtdate='" + ddldate.SelectedValue + "'";
                }
                if (ddldate.SelectedValue == "-All-")
                {
                    str = str + " and a.dtdate !=''";
                }
                if (ddlbuildname.SelectedIndex > 1)
                {
                    str = str + " and b.strbuildname='" + ddlbuildname.SelectedValue + "'";
                }
                if (ddlbuildname.SelectedValue == "-All-")
                {
                    str = str + " and b.strbuildname!=''";
                }
                if (ddlstandard.SelectedIndex > 1)
                {
                    str = str + " and a.strstandard='" + ddlstandard.SelectedValue + "'";
                }
                if (ddlstandard.SelectedValue == "-All-")
                {
                    str = str + " and a.strstandard!=''";
                }

                str = str + " group by  a.intid,a.dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = true;
                    dgadmissioninterview.Columns[4].Visible = true;
                    dgadmissioninterview.Columns[5].Visible = true;
                }
            }
            if (ddllist.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblbuilding b,tblemployee c,tblstudentadmission d where a.strbuildingname=b.intid and a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddllist.SelectedValue + " and d.intwaitlist=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl ";
                if (ddldate.SelectedIndex > 1)
                {
                    str = str + " and a.dtdate='" + ddldate.SelectedValue + "'";
                }
                if (ddldate.SelectedValue == "-All-")
                {
                    str = str + " and a.dtdate !=''";
                }
                if (ddlbuildname.SelectedIndex > 1)
                {
                    str = str + " and b.strbuildname='" + ddlbuildname.SelectedValue + "'";
                }
                if (ddlbuildname.SelectedValue == "-All-")
                {
                    str = str + " and b.strbuildname!=''";
                }
                if (ddlstandard.SelectedIndex > 1)
                {
                    str = str + " and a.strstandard='" + ddlstandard.SelectedValue + "'";
                }
                if (ddlstandard.SelectedValue == "-All-")
                {
                    str = str + " and a.strstandard!=''";
                }

                str = str + " group by  a.intid,a.dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = true;
                    dgadmissioninterview.Columns[4].Visible = true;
                    dgadmissioninterview.Columns[5].Visible = true;
                }
            }
        }
        else
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddllist.SelectedValue + " and d.intapprove=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl ";
                if (ddldate.SelectedIndex > 1)
                {
                    str = str + " and a.dtdate='" + ddldate.SelectedValue + "'";
                }
                if (ddldate.SelectedValue == "-All-")
                {
                    str = str + " and a.dtdate !=''";
                }
                
                if (ddlstandard.SelectedIndex > 1)
                {
                    str = str + " and a.strstandard='" + ddlstandard.SelectedValue + "'";
                }
                if (ddlstandard.SelectedValue == "-All-")
                {
                    str = str + " and a.strstandard!=''";
                }

                str = str + " group by  a.intid,a.dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = false;
                    dgadmissioninterview.Columns[4].Visible = false;
                    dgadmissioninterview.Columns[5].Visible = false;
                }
            }
            if (ddllist.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddllist.SelectedValue + " and d.intwaitlist=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl ";
                if (ddldate.SelectedIndex > 1)
                {
                    str = str + " and a.dtdate='" + ddldate.SelectedValue + "'";
                }
                if (ddldate.SelectedValue == "-All-")
                {
                    str = str + " and a.dtdate !=''";
                }
               if (ddlstandard.SelectedIndex > 1)
                {
                    str = str + " and a.strstandard='" + ddlstandard.SelectedValue + "'";
                }
                if (ddlstandard.SelectedValue == "-All-")
                {
                    str = str + " and a.strstandard!=''";
                }

                str = str + " group by  a.intid,a.dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = false;
                    dgadmissioninterview.Columns[4].Visible = false;
                    dgadmissioninterview.Columns[5].Visible = false;
                }
            }
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
       fillgrid();
    }
    protected void ddlapplication_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlbuildname_SelectedIndexChanged(object sender, EventArgs e)
    {
       standard();
       fillgrid();
    }
    protected void dgadmissioninterview_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("view_assigned_room_date.aspx?lid=" + e.Item.Cells[0].Text);
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        date();
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBsY.Checked == true)
        {
            buildname();
            standard();
            fillgrid();
        }
        else
        {
            standard();
            fillgrid();
        }
    }
    protected void RBsY_CheckedChanged(object sender, EventArgs e)
    {
        tdbuild.Visible = true;
        tdbuildname.Visible = true;
        dgadmissioninterview.Columns[3].Visible = true;
        dgadmissioninterview.Columns[4].Visible = true;
        dgadmissioninterview.Columns[5].Visible = true;
    }
    protected void RBsN_CheckedChanged(object sender, EventArgs e)
    {
        tdbuild.Visible = false;
        tdbuildname.Visible = false;
        dgadmissioninterview.Columns[3].Visible = false;
        dgadmissioninterview.Columns[4].Visible = false;
        dgadmissioninterview.Columns[5].Visible = false;
    }
}
