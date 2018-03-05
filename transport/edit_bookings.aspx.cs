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

public partial class transport_edit_bookings : System.Web.UI.Page
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
            fillsection();
            fillstudent();
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = " select e.intid,e.intstudentid,e.strdestination,e.introuteid,a.strdrivername,b.strvehicleno,c.strroutename,b.intid,f.strstandard,f.strsection, f.strfirstname + ' ' + f.strlastname as name from tbldriver a,tblvehiclemaster b,tblroute c,tblbusbooking e,tblstudent f where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid= e.introuteid and e.intstudentid=f.intid  and e.introuteid=" + ddlrouteno.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        dgasgnbusroute.DataSource = ds;
        dgasgnbusroute.DataBind();
    }
    protected void fillroute()
    {
        strsql = "select strroutename,intid from tblroute where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlrouteno.DataSource = ds;
        ddlrouteno.DataTextField = "strroutename";
        ddlrouteno.DataValueField = "intid";
        ddlrouteno.DataBind();
        ddlrouteno.Items.Insert(0, "-Select-");
    }
    protected void filldriver()
    {
        strsql = "  select a.strdrivername,b.strvehicleno,b.intseats,c.* from tbldriver a,tblvehiclemaster b,tblroute c where  a.intid=c.intdriver and b.intid=c.intvehicle and c.intid=" + ddlrouteno.SelectedValue + "";
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
        fillgrid();
        filldriver();
        filldestination();
    }
    protected void fillstandard()
    {
        strsql = " select strstandard from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " group by strstandard";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");
    }
    protected void fillsection()
    {
        strsql = " select strsection from tblstandard_section_subject  where strstandard='" + ddlstandard.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString() + " group by strsection ";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        ddlsection.Items.Insert(0, "-Select-");
    }
    protected void fillstudent()
    {
        strsql = " select strfirstname + ' ' + strlastname as name,intid from tblstudent where strstandard='" + ddlstandard.SelectedValue + "' and strsection='" + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
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
        strsql = "select intseats-ct as available from (select count(*) as ct from tblbusbooking where introuteid=" + ddlrouteno.SelectedValue + " and intschool= " + Session["Schoolid"].ToString() + ") as a,(select intseats from tblvehiclemaster where intid =(select intvehicle from tblroute where intid= " + ddlrouteno.SelectedValue + ")) as b";
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        lblavailable.Text = ds.Tables[0].Rows[0]["available"].ToString();
    }
   protected void dgasgnbusroute_editcommand(object source, DataGridCommandEventArgs e)
    {
        hdn1.Value = e.Item.Cells[0].Text;
        ddlstandard.SelectedValue = e.Item.Cells[4].Text;
        fillsection();
        ddlsection.SelectedValue = e.Item.Cells[5].Text;
        fillstudent();
        ddlstudent.SelectedValue = e.Item.Cells[8].Text;
        ddldestination.SelectedValue = e.Item.Cells[7].Text;
        pickuptime();
        btnbook.Text = "Update";
    }
    //protected void dgasgnbusroute_deletecommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string str = "delete tblbusbooking where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(str);
    //    fillgrid();
    //}
    protected void btnbook_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spbusbooking", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnbook.Text == "Book")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", hdn1.Value);
        }
        RegCommand.Parameters.Add("@introuteid", ddlrouteno.SelectedValue);
        RegCommand.Parameters.Add("@intstudentid", ddlstudent.SelectedValue);
        RegCommand.Parameters.Add("@strdestination", ddldestination.SelectedValue);
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already booked for this student!')", true);
        }
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnbook.Text == "Book")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 213);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 213);
        }
        fillgrid();
        //btnbook.Text = "Book";
        Clear();
        availability();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsection();
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
        strsql = " SELECT CONVERT(VARCHAR,dtpickuptime,108) as picktime,CONVERT(VARCHAR,dtdroptime,108) as droptime from tblassignbusroute where introute=" + ddlrouteno.SelectedValue + " and strdestination='" + ddldestination.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
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
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already booked for this student!')", true);
            lblalert.Visible = true;
        }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string str = "delete tblbusbooking where intid=" + item.Cells[0].Text;
            da.ExceuteSqlQuery(str);
            Functions.UserLogs(Session["UserID"].ToString(), "tblbusbooking", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 213);
            fillgrid();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected record cannot be deleted since it is linked to other modules')", true);
        }
    }
    protected void Clear()
    {
        //ddlrouteno.SelectedValue = "-Select-";
        lbldrivername.Text = "";
        lblvehicleno.Text = "0";
        lblnoofseats.Text = "0";
        ddlstandard.SelectedValue = "-Select-";
        ddlsection.SelectedValue = "-Select-";
        ddlstudent.SelectedValue = "-Select-";
        ddldestination.SelectedValue = "-Select-";
        lblpickup.Text = "0";
        lbldropup.Text = "0";
        btnbook.Text = "Book";

    }
}
