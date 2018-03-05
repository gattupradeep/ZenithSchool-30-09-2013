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

public partial class transport_busbooking : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillroute();
            fillstandard();
            clear();
            lblalert.Visible = false;
            if (Session["PatronType"].ToString() == "Students" || Session["PatronType"].ToString() == "Parents")
            {
                fillstudent();
                ddlstandard.SelectedValue = Session["StudentClass"].ToString();
                ddlstudent.SelectedValue = Session["UserID"].ToString();
                ddlstudent.Enabled = false;
                ddlstandard.Enabled = false;
            }
        }
        if (Session["PatronType"].ToString() == "Students" || Session["PatronType"].ToString() == "Parents")
        {
            fillstudent();
            ddlstandard.SelectedValue = Session["StudentClass"].ToString();
            ddlstudent.SelectedValue = Session["UserID"].ToString();
            ddlstudent.Enabled = false;
            ddlstandard.Enabled = false;
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        strsql = " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Approved' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "' and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=0 "; 
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Waiting for Approval' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "' and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=0 and e.intRCStatus=0 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancellation request' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "' and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=1 and e.intRCStatus=1 ";
        strsql += " union all  ";
        strsql += " select e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,e.intid,f.strstandard+' - '+f.strsection as class,f.intadmitno,convert(varchar(10),e.dtdate,103) as date ";
        strsql += " , f.strfirstname + ' ' + f.strlastname as name,'Cancel request rejected' as status from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
        strsql += " where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid and f.strstandard+' - '+f.strsection='" + ddlstandard.SelectedValue + "' and e.intstudentid=" + ddlstudent.SelectedValue;
        strsql += " and a.intschool=2 and e.intARStatus=4 and e.intRCStatus=1 ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgasgnbusroute.DataSource = ds;
            dgasgnbusroute.DataBind();
            dgasgnbusroute.Visible = true;
        }
        else
        {
            dgasgnbusroute.Visible = false;
        }
    }
    protected void fillroute()
    {
        strsql = "select strroutename,intid from tblroute where intschool=" + Session["SchoolID"].ToString()  ;
        da = new DataAccess();       
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlrouteno.DataSource = ds;
        ddlrouteno.DataTextField = "strroutename";
        ddlrouteno.DataValueField = "intid";
        ddlrouteno.DataBind();
        ddlrouteno.Items.Insert(0, "-Select-");
        if (ds.Tables[0].Rows.Count == 0)
            MsgBox1.alert("There is no Bus Route Added for Booking");
    }

   protected void filldriver()
    {
        strsql = "  select a.strdrivername,b.strvehicleno,b.intseats,c.* from tbldriver a,tblvehiclemaster b,tblroute c where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid="+ddlrouteno.SelectedValue+"";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbldrivername.Text = ds.Tables[0].Rows[0]["strdrivername"].ToString();
            lblnoofseats.Text = ds.Tables[0].Rows[0]["intseats"].ToString();
            lblvehicleno.Text = ds.Tables[0].Rows[0]["strvehicleno"].ToString();
            availability();
        }
    }
    protected void ddlrouteno_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldriver();
        dgasgnbusroute.Visible = false;
        filldestination();
    }
    protected void fillstandard()
    {
        strsql = " select strstandard+' - '+strsection as standard from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard,strsection";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "standard";
        ddlstandard.DataValueField = "standard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");       
    }
    protected void fillstudent()
    {
        strsql = " select strfirstname + ' ' + strlastname as name,intid from tblstudent where strstandard+' - '+strsection='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "-Select-");
        
    }
    protected void availability()
    {
        strsql = " select intseats-cnt as available from (select SUM(ct) as cnt from (";
        strsql += " select count(*) as ct from tblbusbooking where ";
        strsql += " introuteid=" + ddlrouteno.SelectedValue + " and intARStatus=1 and intRCStatus=0 and intschool=" + Session["Schoolid"].ToString();
        strsql += " union all select count(*) as ct from tblbusbooking where ";
        strsql += " introuteid=" + ddlrouteno.SelectedValue + " and intARStatus=0 and intRCStatus=0 and intschool=" + Session["Schoolid"].ToString();
        strsql += " union all select count(*) as ct from tblbusbooking where ";
        strsql += " introuteid=" + ddlrouteno.SelectedValue + " and intARStatus=1 and intRCStatus=1 and intschool=" + Session["Schoolid"].ToString();
        strsql += " union all select count(*) as ct from tblbusbooking where ";
        strsql += " introuteid=" + ddlrouteno.SelectedValue + " and intARStatus=4 and intRCStatus=1 and intschool=" + Session["Schoolid"].ToString();
        strsql += " ) as a1 ) as a,";
        strsql += " (select intseats from tblvehiclemaster where intid =(select intvehicle from tblroute where intid= " + ddlrouteno.SelectedValue + ")) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        lblavailable.Text = ds.Tables[0].Rows[0]["available"].ToString();
    }
    protected void btnbook_Click(object sender, EventArgs e)
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select * from tblbusbooking where intARStatus in(0,1) and intstudentid=" + ddlstudent.SelectedValue;
        if (btnbook.Text == "Update")
            strsql += " and intID!=" + hid.Value;
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already Exist !')", true);
        }
        else
        {
            SqlCommand RegCommand;
            SqlParameter OutPutParam;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            Conn.Open();
            RegCommand = new SqlCommand("spbusbooking", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnbook.Text == "Request for booking")
            {
                RegCommand.Parameters.Add("@intID", "0");
                RegCommand.Parameters.Add("@introuteid", ddlrouteno.SelectedValue);
                RegCommand.Parameters.Add("@intstudentid", ddlstudent.SelectedValue);
                RegCommand.Parameters.Add("@strdestination", ddldestination.SelectedValue);
                RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                RegCommand.Parameters.Add("@intRCStatus", "0");
                RegCommand.Parameters.Add("@intARStatus", "0");
                RegCommand.ExecuteNonQuery();
                if ((int)(RegCommand.Parameters["@rc"].Value) != 0)
                {
                    Session["intid"] = (int)(RegCommand.Parameters["@rc"].Value);
                }
                Conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 119);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
            }
            else
            {
                RegCommand.Parameters.Add("@intID", hid.Value);
                RegCommand.Parameters.Add("@introuteid", ddlrouteno.SelectedValue);
                RegCommand.Parameters.Add("@intstudentid", ddlstudent.SelectedValue);
                RegCommand.Parameters.Add("@strdestination", ddldestination.SelectedValue);
                RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                RegCommand.Parameters.Add("@intRCStatus", "0");
                RegCommand.Parameters.Add("@intARStatus", "0");
                RegCommand.ExecuteNonQuery();
                if ((int)(RegCommand.Parameters["@rc"].Value) != 0)
                {
                    Session["intid"] = (int)(RegCommand.Parameters["@rc"].Value);
                }
                Conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 119);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Updated Successfully!')", true);
            }
            //availability();
            fillgrid();
            clear();
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
     protected void filldestination()
     {
         strsql = "select strdestination,intid from tblassignbusroute where introute="+ddlrouteno.SelectedValue+" and intschool=" + Session["SchoolID"].ToString();
         da = new DataAccess();
         ds = new DataSet();
         ds = da.ExceuteSql(strsql);
         ddldestination.DataSource = ds;
         ddldestination.DataTextField = "strdestination";
         ddldestination.DataValueField = "strdestination";
         ddldestination.DataBind();
         ddldestination.Items.Insert(0, "-Select-");
     }
     protected void pickuptime()
     {
         strsql=" SELECT CONVERT(VARCHAR,dtpickuptime,108) as picktime,CONVERT(VARCHAR,dtdroptime,108) as droptime from tblassignbusroute where introute="+ddlrouteno.SelectedValue+" and strdestination='"+ddldestination.SelectedValue+"' and intschool=" + Session["SchoolID"].ToString();
         da = new DataAccess();
         ds = new DataSet();
         ds = da.ExceuteSql(strsql);
         lblpickup.Text = ds.Tables[0].Rows[0]["picktime"].ToString();
         lbldropup.Text = ds.Tables[0].Rows[0]["droptime"].ToString();
     }
     protected void ddldestination_SelectedIndexChanged(object sender, EventArgs e)
     {
         pickuptime();
     }
     protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
     {
         DataAccess da = new DataAccess();
         string str = "select * from tblbusbooking where intstudentid=" + ddlstudent.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
         DataSet ds = new DataSet();
         ds = da.ExceuteSql(str);
         if (ds.Tables[0].Rows.Count>0)
         {
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already booked for this student!')", true);
             lblalert.Visible = true;
         }
         fillgrid();
     }
     protected void btndelete_Click(object sender, ImageClickEventArgs e)
     {
         try
         {
             ImageButton delete = (ImageButton)sender;
             TableCell cell = delete.Parent as TableCell;
             DataGridItem item = cell.Parent as DataGridItem;
             DataAccess da = new DataAccess();
             string str = "delete tblbusbooking where intid=" + item.Cells[0].Text + " and intARStatus=0";
             da.ExceuteSqlQuery(str);
             Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 213);
             fillgrid();
         }
         catch
         {
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
         }
     }

     protected void clear()
     {
         ddlrouteno.SelectedIndex = 0;
         ddlstandard.SelectedIndex = 0;
         ddldestination.SelectedIndex = 0;
         //ddlsection.SelectedValue = "-Select-";
         //ddlstudent.SelectedValue = "0";
         lbldrivername.Text = "";
         lblvehicleno.Text = "0";
         lbldropup.Text = "0";
         lblavailable.Text = "0";
         lblnoofseats.Text = "0";
         lblpickup.Text = "0";
         lbldropup.Text = "0";
         hid.Value = "0";
         btnbook.Text = "Request for booking";
     }
     protected void btncancel_Click(object sender, EventArgs e)
     {
         clear();
     }
     protected void dgasgnbusroute_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
         try
         {
             Button btnapprove = (Button)e.Item.FindControl("btnapprove");
             ImageButton btndelete = (ImageButton)e.Item.FindControl("btndelete");
             DataRowView dr = (DataRowView)e.Item.DataItem;

             if (dr["status"].ToString() == "Waiting for Approval")
             {
                 dgasgnbusroute.Columns[9].Visible = true;
                 dgasgnbusroute.Columns[10].Visible = true;
                 dgasgnbusroute.Columns[11].Visible = false;
                 btndelete.Visible = true;
                 btndelete.Attributes.Add("Visible", "False");
             }
             else if (dr["status"].ToString() == "Approved")
             {
                 dgasgnbusroute.Columns[11].Visible = true;
                 dgasgnbusroute.Columns[10].Visible = false;
                 dgasgnbusroute.Columns[9].Visible = false;
                 btndelete.Attributes.Add("Visible", "False");
             }
             else
             {
                 dgasgnbusroute.Columns[11].Visible = false;
                 dgasgnbusroute.Columns[10].Visible = false;
                 dgasgnbusroute.Columns[9].Visible = false;
             }
         }
         catch { }
     }
     protected void btncancel_Click1(object sender, EventArgs e)
     {
         Button list = (Button)sender;
         TableCell cell = list.Parent as TableCell;
         DataGridItem item = cell.Parent as DataGridItem;
         int index = item.ItemIndex;
         Button btncancel = (Button)item.FindControl("btncancel");
         da = new DataAccess();
         if (btncancel.Text == "Cancel Booking")
         {
             if (item.Cells[8].Text == "Approved")
             {
                 strsql = "update tblbusbooking set intRCStatus=1,dtApprovedDate=getdate() where intid=" + item.Cells[0].Text;
                 da.ExceuteSqlQuery(strsql);
             }             
         }
         fillgrid();
     }

     protected void btnedit_Click(object sender, ImageClickEventArgs e)
     {
         ImageButton list = (ImageButton)sender;
         TableCell cell = list.Parent as TableCell;
         DataGridItem item = cell.Parent as DataGridItem;
         int index = item.ItemIndex;
         ImageButton btnedit = (ImageButton)item.FindControl("btnedit");
         DataAccess dae = new DataAccess();
         hid.Value = item.Cells[0].Text;
         strsql = " select e.intid,c.strroutename,a.strdrivername,e.introuteid,b.strvehicleno,f.strstandard+' - '+f.strsection as class,f.intadmitno,f.intid as intstudent ";
         strsql += " ,f.strfirstname + ' ' + f.strlastname as name,e.strdestination from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f  ";
         strsql += " where a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid ";
         strsql += " and a.intschool=2 and e.intARStatus=0 and e.intRCStatus=0 and e.intid=" + item.Cells[0].Text;
         DataSet dse = new DataSet();
         dse = dae.ExceuteSql(strsql);
         if (dse.Tables[0].Rows.Count > 0)
         {
             fillroute();
             ddlrouteno.SelectedValue = dse.Tables[0].Rows[0]["introuteid"].ToString();
             filldriver();
             lbldrivername.Text = dse.Tables[0].Rows[0]["strdrivername"].ToString();
             lblvehicleno.Text = dse.Tables[0].Rows[0]["strvehicleno"].ToString();
             fillstandard();
             ddlstandard.SelectedValue = dse.Tables[0].Rows[0]["class"].ToString();
             fillstudent();
             ddlstudent.SelectedValue = dse.Tables[0].Rows[0]["intstudent"].ToString();
             filldestination();
             ddldestination.SelectedValue = dse.Tables[0].Rows[0]["strdestination"].ToString();
             pickuptime();
         }
         btnbook.Text = "Update";
     }
}
