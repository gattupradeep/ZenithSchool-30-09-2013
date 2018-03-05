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

public partial class admission_viewadmissionexamattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            attendance();
            date();
            time();
            buildname();
            floor();
            roomno();
            standard();
            dgadmissionattendance.Visible = false;
            trpresent.Visible = false;
            trabsent.Visible = false;
            trrefined.Visible = false;
            trbuilding.Visible = false;
            trfloor.Visible = false;
            trroom.Visible = false;

        }
        
    }
    protected void standard()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionattendance where dtdate='" + ddldate.SelectedValue + "' and  intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
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
            string str = "select strstandard from tbladmissionattendance where dtdate='" + ddldate.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
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
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissionattendance where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
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
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissionattendance where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
    }
    protected void time()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select dttime from tbladmissionattendance where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dttime";
            ds = da.ExceuteSql(str);
            ddltime.DataTextField = "dttime";
            ddltime.DataValueField = "dttime";
            ddltime.DataSource = ds;
            ddltime.DataBind();
            ddltime.Items.Insert(0, "-Select-");
            ddltime.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select dttime from tbladmissionattendance where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dttime";
            ds = da.ExceuteSql(str);
            ddltime.DataTextField = "dttime";
            ddltime.DataValueField = "dttime";
            ddltime.DataSource = ds;
            ddltime.DataBind();
            ddltime.Items.Insert(0, "-Select-");
            ddltime.Items.Insert(1, "-All-");
        }
    }
    protected void buildname()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strbuildingname from tbladmissionattendance  where  strstandard='"+ddlstandard.SelectedValue+"' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strbuildingname";
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildingname";
            ddlbuildname.DataValueField = "strbuildingname";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");
           
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strbuildingname from tbladmissionattendance  where strstandard='"+ddlstandard.SelectedValue+"' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strbuildingname";
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildingname";
            ddlbuildname.DataValueField = "strbuildingname";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");
           
        }
    }
    protected void floor()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strfloor from tbladmissionattendance  where strbuildingname='" + ddlbuildname.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strfloor";
            ds = da.ExceuteSql(str);
            ddlfloor.DataTextField = "strfloor";
            ddlfloor.DataValueField = "strfloor";
            ddlfloor.DataSource = ds;
            ddlfloor.DataBind();
            ddlfloor.Items.Insert(0, "-Select-");
            
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strfloor from tbladmissionattendance  where strbuildingname='" + ddlbuildname.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strfloor";
            ds = da.ExceuteSql(str);
            ddlfloor.DataTextField = "strfloor";
            ddlfloor.DataValueField = "strfloor";
            ddlfloor.DataSource = ds;
            ddlfloor.DataBind();
            ddlfloor.Items.Insert(0, "-Select-");
            
        }
    }
    protected void roomno()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select introomno from tbladmissionattendance  where strstandard='"+ddlstandard.SelectedValue+"' and strfloor='" + ddlfloor.SelectedValue + "' and strbuildingname='" + ddlbuildname.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by introomno";
            ds = da.ExceuteSql(str);
            ddlroom.DataTextField = "introomno";
            ddlroom.DataValueField = "introomno";
            ddlroom.DataSource = ds;
            ddlroom.DataBind();
            ddlroom.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select introomno from tbladmissionattendance  where strstandard='" + ddlstandard.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strbuildingname='" + ddlbuildname.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by introomno";
            ds = da.ExceuteSql(str);
            ddlroom.DataTextField = "introomno";
            ddlroom.DataValueField = "introomno";
            ddlroom.DataSource = ds;
            ddlroom.DataBind();
            ddlroom.Items.Insert(0, "-Select-");
         }
    }
    protected void attendance()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strattendance from tbladmissionattendance  where strstandard='"+ddlstandard.SelectedValue+"' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strattendance";
            ds = da.ExceuteSql(str);
            ddlattendance.DataTextField = "strattendance";
            ddlattendance.DataValueField = "strattendance";
            ddlattendance.DataSource = ds;
            ddlattendance.DataBind();
            ddlattendance.Items.Insert(0, "-Select-");
            
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strattendance from tbladmissionattendance  where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strattendance";
            ds = da.ExceuteSql(str);
            ddlattendance.DataTextField = "strattendance";
            ddlattendance.DataValueField = "strattendance";
            ddlattendance.DataSource = ds;
            ddlattendance.DataBind();
            ddlattendance.Items.Insert(0, "-Select-");
            
        }
    }
    protected void filldetails()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select count(*) as ct from tbladmissionattendance a where intapprove_waitlist=" + ddllist.SelectedValue + " and strattendance='" + ddlattendance.SelectedValue + "' and strstandard='" + ddlstandard.SelectedValue + "'";
            ds = da.ExceuteSql(str);
          
                if (ddlattendance.SelectedValue == "Present")
                {
                    lblpresent.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                    trabsent.Visible = false;
                    trpresent.Visible = true;
                }
                else
                {
                    lblabsent.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                    trpresent.Visible = false;
                    trabsent.Visible = true;
                }
            
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select count(*) as ct from tbladmissionattendance a where intapprove_waitlist="+ddllist.SelectedValue+" and strattendance='" + ddlattendance.SelectedValue + "' and strstandard='" + ddlstandard.SelectedValue + "'";
            ds = da.ExceuteSql(str);

            if (ddlattendance.SelectedValue == "Present")
            {
                lblpresent.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                trabsent.Visible = false;
                trpresent.Visible = true;
            }
            else
            {
                lblabsent.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                trpresent.Visible = false;
                trabsent.Visible = true;
            }
        }
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = false;
        time();
        standard();
       
    }
    protected void ddltime_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = false;
        standard();
        buildname();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = true;
        fillgrid();
        attendance();
        buildname();
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = false;
        date();
       
    }
    protected void ddlfloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = true;
        roomno();
    }
    protected void ddlroom_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = true;
        fillgrid();
    }
    
    protected void ddlbuildname_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = true;
        floor();
        roomno();
    }
    protected void ddlattendance_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgadmissionattendance.Visible = true;
        filldetails();
    }
    protected void fillgrid()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select intid,intapplication,convert(varchar(10),dtdate,111) as dtdate,dttime,strstandard,strstudent,strattendance,strbuildingname,strfloor,introomno from tbladmissionattendance where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            if (ddldate.SelectedValue == "-All-")
            {
              str = str + " and dtdate !=''";
            }
            if (ddldate.SelectedIndex > 1)
            {
            str = str + " and dtdate='" + ddldate.SelectedValue + "'";
            }
            if (ddltime.SelectedValue == "-All-")
            {
                str = str + " and dttime !=''";
            }
            if (ddltime.SelectedIndex > 1)
            {
                str = str + " and dttime='" + ddltime.SelectedValue + "'";
            }
            if (ddlstandard.SelectedValue == "-All-")
            {
                str = str + " and strstandard !=''";
            }
            if (ddlstandard.SelectedIndex > 1)
            {
                str = str + " and strstandard='" + ddlstandard.SelectedValue + "'";
            }
            if (ddlattendance.SelectedIndex > 0)
            {
                str = str + " and strattendance='" + ddlattendance.SelectedValue + "'";
            }
            if (ddlbuildname.SelectedIndex > 0)
            {
                str = str + " and strbuildingname='" + ddlbuildname.SelectedValue + "'";
            }
            if (ddlfloor.SelectedIndex > 0)
            {
                str = str + " and strfloor='" + ddlfloor.SelectedValue + "'";
            }
            if (ddlroom.SelectedIndex > 0)
            {
                str = str + " and introomno=" + ddlroom.SelectedValue + "";
            }
            str = str + " group by  intid,intapplication,dtdate,dttime,strstandard,strstudent,strattendance,strbuildingname,strfloor,introomno";
            ds = da.ExceuteSql(str);
            dgadmissionattendance.DataSource = ds;
            dgadmissionattendance.DataBind();
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select intid,intapplication,convert(varchar(10),dtdate,111) as dtdate,dttime,strstandard,strstudent,strattendance,strbuildingname,strfloor,introomno from tbladmissionattendance where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            if (ddldate.SelectedValue == "-All-")
            {
                str = str + " and dtdate !=''";
            }
            if (ddldate.SelectedIndex > 1)
            {
                str = str + " and dtdate='" + ddldate.SelectedValue + "'";
            }
            if (ddltime.SelectedValue == "-All-")
            {
                str = str + " and dttime !=''";
            }
            if (ddltime.SelectedIndex > 1)
            {
                str = str + " and dttime='" + ddltime.SelectedValue + "'";
            }
            if (ddlstandard.SelectedValue == "-All-")
            {
                str = str + " and strstandard !=''";
            }
            if (ddlstandard.SelectedIndex > 1)
            {
                str = str + " and strstandard='" + ddlstandard.SelectedValue + "'";
            }
            if (ddlattendance.SelectedIndex > 0)
            {
                str = str + " and strattendance='" + ddlattendance.SelectedValue + "'";
            }
            if (ddlroom.SelectedValue == "All")
            {
                str = str + " and introomno!=''";
            }
            if (ddlroom.SelectedIndex > 1)
            {
                str = str + " and introomno=" + ddlroom.SelectedValue + "";
            }
            str = str + " group by  intid,intapplication,dtdate,dttime,strstandard,strstudent,strattendance,strbuildingname,strfloor,introomno";
            ds = da.ExceuteSql(str);
            dgadmissionattendance.DataSource = ds;
            dgadmissionattendance.DataBind();
        }
    }
    protected void RBsN_CheckedChanged(object sender, EventArgs e)
    {
        trrefined.Visible = false;
        trbuilding.Visible = false;
        trfloor.Visible = false;
        trroom.Visible = false;
    }
    protected void RBsY_CheckedChanged(object sender, EventArgs e)
    {
        trrefined.Visible = true;
        trbuilding.Visible = true;
        trfloor.Visible = true;
        trroom.Visible = true;
    }
}
