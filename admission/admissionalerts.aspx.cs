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

public partial class admission_admissionalerts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            filldetails();
        }
    }
    protected void year()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select intyear from tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " group by intyear";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "intyear";
        ddlyear.DataValueField = "intyear";
        ddlyear.DataBind();
        ddlyear.Items.Insert(0, "-Select-");
    }
    protected void fillstandard()
    {
        if (ddllist.SelectedValue == "1")
        {
            string str;
            DataSet ds;
            DataAccess da = new DataAccess();
            str = "select strstandard from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and dttime='" + ddltime.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            da = new DataAccess();
            ds = da.ExceuteSql(str);
            ddlstandard.DataSource = ds;
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            string str;
            DataSet ds;
            DataAccess da = new DataAccess();
            str = "select strstandard from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and dttime='" + ddltime.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            da = new DataAccess();
            ds = da.ExceuteSql(str);
            ddlstandard.DataSource = ds;
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
        }
    }
    protected void filldate()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,103) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataSource = ds;
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,103) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataSource = ds;
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
        }
    }
    protected void filltime()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select dttime from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + "  and intschool=" + Session["SchoolID"].ToString() + " group by dttime";
            ds = da.ExceuteSql(str);
            ddltime.DataSource = ds;
            ddltime.DataTextField = "dttime";
            ddltime.DataValueField = "dttime";
            ddltime.DataBind();
            ddltime.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select dttime from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dttime";
            ds = da.ExceuteSql(str);
            ddltime.DataSource = ds;
            ddltime.DataTextField = "dttime";
            ddltime.DataValueField = "dttime";
            ddltime.DataBind();
            ddltime.Items.Insert(0, "-Select-");
        }
    }
    protected void filldetails()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select intid  from tbladmissioninterview where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["interviewid"] = ds.Tables[0].Rows[0]["intid"].ToString();
            }
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select intid from tbladmissioninterview where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["interviewid"] = ds.Tables[0].Rows[0]["intid"].ToString();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddllist.SelectedValue == "1")
        {
            SqlCommand RegCommand;
            SqlParameter OutPutParam;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

            Conn.Open();
            RegCommand = new SqlCommand("spadmissionalerts", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            filldetails();
            RegCommand.Parameters.Add("@intinterviewid", Session["interviewid"].ToString());
            RegCommand.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
            int alert = 0;
            if (RBtoday.Checked)
            {
                RegCommand.Parameters.Add("@intnoofdays", alert);
            }
            else
            {
                RegCommand.Parameters.Add("@intnoofdays", txtnoofdays.Text.Trim());
                alert = int.Parse(txtnoofdays.Text);
            }

            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            dateInfo.ShortDatePattern = "dd/MM/yyyy";
            DateTime dt = Convert.ToDateTime(ddldate.SelectedValue, dateInfo);
            DateTime date = dt.AddDays(-alert);
            RegCommand.Parameters.Add("@dtalertdate", date);
            RegCommand.Parameters.Add("@intyear", ddlyear.SelectedValue);
            RegCommand.Parameters.Add("@intapprove_waitlist", ddllist.SelectedValue);
            RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            fillgrid();
            clear();
        }
        if (ddllist.SelectedValue == "2")
        {
            SqlCommand RegCommand;
            SqlParameter OutPutParam;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

            Conn.Open();
            RegCommand = new SqlCommand("spadmissionalerts", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
            }
            filldetails();
            RegCommand.Parameters.Add("@intinterviewid", Session["interviewid"].ToString());
            RegCommand.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
            int alert = 0;
            if (RBtoday.Checked)
            {
                RegCommand.Parameters.Add("@intnoofdays", alert);
            }
            else
            {
                RegCommand.Parameters.Add("@intnoofdays", txtnoofdays.Text.Trim());
                alert = int.Parse(txtnoofdays.Text);
            }
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            dateInfo.ShortDatePattern = "dd/MM/yyyy";
            DateTime dt = Convert.ToDateTime(ddldate.SelectedValue, dateInfo);
            DateTime date = dt.AddDays(-alert);
            RegCommand.Parameters.Add("@dtalertdate", date);
            RegCommand.Parameters.Add("@intyear", ddlyear.SelectedValue);
            RegCommand.Parameters.Add("@intapprove_waitlist", ddllist.SelectedValue);
            RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            fillgrid();
            clear();
        }
    }
    protected void clear()
    {
        txtnoofdays.Text = "";
        btnSave.Text = "Save";
    }
    protected void fillgrid()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,convert(varchar(10),a.dttime,103) as dttime,b.intyear,b.intnoofdays,convert(varchar(10),b.dtalertdate,103) as dtalertdate,b.strstandard from tbladmissioninterview a,tbladmissionalerts b where a.intid=b.intinterviewid and b.strstandard='" + ddlstandard.SelectedValue + "' and b.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            dgadmissionalert.DataSource = ds;
            dgadmissionalert.DataBind();
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,convert(varchar(10),a.dttime,103) as dttime,b.intyear,b.intnoofdays,convert(varchar(10),b.dtalertdate,103) as dtalertdate,b.strstandard from tbladmissioninterview a,tbladmissionalerts b where a.intid=b.intinterviewid and b.strstandard='" + ddlstandard.SelectedValue + "' and b.intapprove_waitlist=" + ddllist.SelectedValue + " and  b.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            dgadmissionalert.DataSource = ds;
            dgadmissionalert.DataBind();
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void dgadmissionalert_EditCommand(object source, DataGridCommandEventArgs e)
    {
        if (ddllist.SelectedValue == "1")
        {
            Session["intid"] = e.Item.Cells[0].Text;
            ddlyear.SelectedValue = e.Item.Cells[1].Text;
            ddldate.Text = e.Item.Cells[2].Text;
            ddltime.Text = e.Item.Cells[3].Text;
            txtnoofdays.Text = e.Item.Cells[4].Text;
            ddlstandard.SelectedValue = e.Item.Cells[6].Text;
            btnSave.Text = "Update";
        }
        if (ddllist.SelectedValue == "2")
        {
            Session["intid"] = e.Item.Cells[0].Text;
            ddlyear.SelectedValue = e.Item.Cells[1].Text;
            ddldate.Text = e.Item.Cells[2].Text;
            ddltime.Text = e.Item.Cells[3].Text;
            txtnoofdays.Text = e.Item.Cells[4].Text;
            ddlstandard.SelectedValue = e.Item.Cells[6].Text;
            btnSave.Text = "Update";
        }
    }
    protected void dgadmissionalert_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string str = "delete tbladmissionalerts where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(str);
        fillgrid();
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldate();
        filldetails();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        filltime();
        year();
        fillstandard();
    }
    protected void ddltime_SelectedIndexChanged(object sender, EventArgs e)
    {
        year();
        fillstandard();
    }
    protected void RBtoday_CheckedChanged(object sender, EventArgs e)
    {
        trlater.Visible = false;
    }
    protected void RBlater_CheckedChanged(object sender, EventArgs e)
    {
        trlater.Visible = true;
    }
    protected void mail()
    {
        
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select strstandard,convert(varchar(10),dtalertdate,103) as dtalertdate,intyear from tbladmissionalerts where intapprove_waitlist='" + ddllist.SelectedValue + "' and convert(varchar(10),dtalertdate,103)=convert(varchar(10),getdate(),103) and strstandard='"+ddlstandard.SelectedValue+"' and intyear="+ ddlyear.SelectedValue;
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string strsql = "select b.str_emailid,b.str_mobile,+'Standard:'+a.strstandard+',Interview Time:'+a.dttime+',Interview Date:'+convert(varchar(10),a.dtdate,103) as Message,a.strcontactperson,b.intid from tbladmissioninterview a,tblstudentadmission b where a.intapprove_waitlist='" + ddllist.SelectedValue + "' and a.strstandard=b.str_standard and b.str_standard='" + ddlstandard.SelectedValue + "'";
                ds = da.ExceuteSql(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strUrl = "http://sms1.mmsworld.in/pushsms.php";
                    Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["str_mobile"].ToString() + "&message= 'Your have been selected and Your registered number is:=" + ds.Tables[0].Rows[0]["Message"].ToString() + "' &priority=1");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Message is send Successfully!')", true);
                }

            }
        }
    }
        
}
